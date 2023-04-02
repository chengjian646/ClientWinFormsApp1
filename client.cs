using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinFormsApp1
{
    
    public partial class client : Form
    {
        private Thread readThread;
        private Thread sendThread;
        private Thread receiveThread;
        private Thread TimeScanThread;
        private Thread ShowThread;
        private Socket socketatClient;
        private bool ConnectOnline;

        private int Identification = 1;//报文段标识
        private List<MessageClass> MessageList = new List<MessageClass>();//报文段信息列表
        private int P1=1;
        private int P2=1;
        private int P3=5;
        private bool IsDelete = false;
        public client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//去掉控件的跨线程非法访问属性
        }

        private void button1_Click(object sender, EventArgs e)//连接服务器
        {
            ConnectOnline = true;
            readThread = new Thread(new ThreadStart(AcceptMessage));
            readThread.Start();
        }
        private void AcceptMessage()
        {
            try
            {
                //string IP = "127.0.0.1";
                //Int32 port = 8088;
                Int32 port;
                int.TryParse(Port.Text, out port);
                string IP = IPAddr.Text;
                //将IP地址字符串转换成IPAddress实例
                IPAddress ip = IPAddress.Parse(IP);
                socketatClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                socketatClient.Connect(endPoint);
                if (socketatClient.Connected)
                {
                    Constatus.Text = "连接服务器成功！";

                    receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                    receiveThread.Start();//连接服务器成功后，就开始接收服务器发送的确认信息

                    TimeScanThread = new Thread(new ThreadStart(TimeOutScan));
                    TimeScanThread.Start();//连接服务器成功后，就开始进行超时扫描

                    ShowThread = new Thread(new ThreadStart(SHOWDetail));
                    ShowThread.Start();
                }
                }
            catch (Exception e)
            {
                MessageBox.Show("发送端连接失败！", "连接");
            }
        }

        private void SHOWDetail()
        {
            while(true)
            {
                WindLoca1.Text = "";
                WindLoca2.Text = "";
                for (int i = P1; i < P2; i++)
                {
                    WindLoca1.AppendText(i + " ");
                }
                for (int i = P2; i <= P3; i++)
                {
                    WindLoca2.AppendText(i + " ");
                }
                Thread.Sleep(500);
            }
            
        }

        private void stopconnect_Click(object sender, EventArgs e)
        {
            ConnectOnline = false;
            socketatClient.Close();
            Constatus.Text = "连接断开";
            MessageBox.Show("客户端连接断开", "客户端");

            receiveThread.Interrupt();
            TimeScanThread.Interrupt();
        }

        private void MySend_Click(object sender, EventArgs e)
        {
            sendThread = new Thread(new ThreadStart(SendMessage));
            sendThread.Start();
        }
        private void SendMessage()
        {
            int Times;
            int.TryParse(MyTimes.Text, out Times);
            for(int i=0;i<Times;i++)
            {
                string MessageStr = "0" + "0" + "0";// 规定Identification只占一个字节;数据长度不超过255
                MessageStr += MyMessage.Text;
                MessageStr += "0";//校验和，放在报文的最后
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(MessageStr);
                byteArray[1] = IntToBitConverter(Identification)[0];//暂时规定标识不超过255
                byteArray[2] = IntToBitConverter(byteArray.Length)[0];//数据长度
                byteArray[byteArray.Length - 1] = OutCheck(byteArray);//计算出校验和
                //MessageBox.Show(MessageStr,"dasd");
                MessageList.Add(new MessageClass {IdentiFication=Identification, IsSend=false,IsConfirm=false,message=byteArray });
                Identification++;
            }
            
            foreach(var item in MessageList)
            {
                if (item.IdentiFication > P3)
                    break;
                if(item.IsSend==false)
                {
                    //发送
                    socketatClient.Send(item.message);

                    item.SendTime = System.DateTime.Now;
                    item.IsSend = true;
                    P2 = item.IdentiFication + 1;

                    byte[] tempMessage = new byte[item.message.Length];
                    Array.Copy(item.message, tempMessage, item.message.Length);
                    tempMessage[0] = 32;//空格
                    tempMessage[1] = 32;
                    tempMessage[2] = 32;
                    tempMessage[item.message[2] - 1] = 32;//校验信息位
                    string str = Encoding.Default.GetString(tempMessage);
                    ShowDetail.AppendText("发送报文：" + str + "   " + item.IdentiFication + "\r\n");
                }
                Thread.Sleep(1500);
            }
        }

        private byte OutCheck(byte[] byteArray)
        {
            byte temp = 0;
            for(int i=0;i<byteArray[2]-1;i++)
            {
                temp += byteArray[i];
            }
            return temp;            
        }

        public byte[] IntToBitConverter(int num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            return bytes;
        }
        private void ReceiveMessage()
        {
            byte[] AckMessage = new byte[5];
            while (ConnectOnline)
            {
                try
                {
                    if (socketatClient.Available > 0)
                    {
                        int num = socketatClient.Receive(AckMessage);
                        if (num > 0)
                        {
                            //byte[] tempAck = AckMessage;
                            //tempAck[0] = 32;//空格
                            //tempAck[2] = 32;
                            //string strAck = System.Text.Encoding.Default.GetString(tempAck);
                            
                            ShowDetail.AppendText("收到ACK：" + AckMessage[1] + " 设置当前发送窗口大小为："+AckMessage[2]+"\r\n");
                            if (AckMessage[1] <= P1)
                                continue;
                            foreach (var item in MessageList)
                            {
                                if (item.IdentiFication < P1)
                                    continue;

                                if (item.IdentiFication == AckMessage[1])
                                {
                                    break;
                                }
                                item.IsConfirm = true;
                                
                            }
                            //以下为删除报文段列表中已收到确认的报文，经cj一天研究，无法解决多个线程对于列表的
                            //同时访问，删除会造成这些访问越界出错，所以放弃该步骤
                            //int MinI= MessageList.Count - 1;
                            //bool HaveACK = false;
                            
                            //for(; MinI >= 0; MinI--)
                            //{
                            //    if (MessageList[MinI].IsConfirm == false)
                            //        continue;
                            //    else
                            //    {
                            //        HaveACK = true;
                            //        break;
                            //    }
                            //}
                            //if(HaveACK==true)
                            //{
                            //    IsDelete = true;
                            //    for (; MinI >= 0; MinI--)//删除
                            //    { 
                            //        MessageList.Remove(MessageList[MinI]);
                            //    }
                            //    IsDelete = false;
                            //HaveACK = false;
                            //}
                            
                            //int tempP1=P1;
                            P1 = AckMessage[1];
                            //int tempP3 = P1 + (P3 - tempP1);
                            //滑动
                            P3 = P1 + AckMessage[2] - 1;
                            /*if (P3 < tempP3)
                            {
                                foreach(var item in MessageList)
                                {
                                    if (item.IdentiFication > P3 && item.IdentiFication <= tempP3)
                                    {
                                        item.IsSend = false;
                                        item.SendTime = System.DateTime.Now;
                                    }
                                }
                            }*/

                            foreach (var item in MessageList)
                            {
                                if (item.IdentiFication < P2)
                                    continue;

                                if (item.IdentiFication > P3)
                                {
                                    break;
                                }
                                if (item.IsSend == false)
                                {
                                    //发送
                                    socketatClient.Send(item.message);
                                    item.IsSend = true;
                                    item.SendTime = System.DateTime.Now;

                                    byte[] tempMessage = new byte[item.message.Length];
                                    Array.Copy(item.message, tempMessage, item.message.Length);
                                    tempMessage[0] = 32;//空格
                                    tempMessage[1] = 32;
                                    tempMessage[2] = 32;
                                    tempMessage[item.message[2] - 1] = 32;//校验信息位
                                    string str = System.Text.Encoding.Default.GetString(tempMessage);
                                    ShowDetail.AppendText("（特殊）发送报文：" + str + "   " + item.IdentiFication + "\r\n");
                                }
                                Thread.Sleep(1000);
                                P2 = item.IdentiFication + 1;
                            }
                        }
                    }
                    Thread.Sleep(500);
                }
                catch(ThreadInterruptedException e)
                {
                    break;
                }               
            }
        }
        private void TimeOutScan()
        {
            while (ConnectOnline)
            {
                try
                {
                    DateTime nowtemp;
                    int differentSec;
                    int differentMin;
                    if (IsDelete == true)//避免另一线程中对报文信息列表的删除，导致此处遍历时出错
                        continue;
                    foreach (var item in MessageList)
                    {
                        if (item.IsSend == true)
                        {
                            nowtemp = System.DateTime.Now;
                            differentMin = nowtemp.Minute - item.SendTime.Minute;
                            differentSec = nowtemp.Second - item.SendTime.Second;
                            if (item.IsConfirm == false && (differentMin > 0 || differentSec > 10))
                            {
                                //发送
                                socketatClient.Send(item.message);
                                item.SendTime = System.DateTime.Now;

                                byte[] tempMessage = new byte[item.message.Length];
                                Array.Copy(item.message, tempMessage, item.message.Length);
                                tempMessage[0] = 32;//空格
                                tempMessage[1] = 32;
                                tempMessage[2] = 32;
                                tempMessage[item.message[2] - 1] = 32;//校验信息位
                                string str = System.Text.Encoding.Default.GetString(tempMessage);
                                ShowDetail.AppendText("（超时重发）发送报文：" + str + "   " + item.IdentiFication+ "\r\n");
                            }
                        }
                    }
                }
                catch(ThreadInterruptedException e)
                {
                    break;
                }
                
                Thread.Sleep(500);//每0.5秒执行一此扫描
            }
        }
    }
    public class MessageClass
    {
        public int IdentiFication;
        public bool IsSend;
        public bool IsConfirm;
        public DateTime SendTime;
        public byte[] message = new byte[500];

        public MessageClass()
        {

        }
    }
}
