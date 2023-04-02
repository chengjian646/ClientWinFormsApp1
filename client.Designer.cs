
namespace ClientWinFormsApp1
{
    partial class client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IPAddr = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.Constatus = new System.Windows.Forms.TextBox();
            this.MyMessage = new System.Windows.Forms.TextBox();
            this.MyTimes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MySend = new System.Windows.Forms.Button();
            this.ShowDetail = new System.Windows.Forms.TextBox();
            this.stopconnect = new System.Windows.Forms.Button();
            this.WindLoca1 = new System.Windows.Forms.TextBox();
            this.WindLoca2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "接收端 IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "连接状态";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "发送内容";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "发送次数";
            // 
            // IPAddr
            // 
            this.IPAddr.Location = new System.Drawing.Point(167, 25);
            this.IPAddr.Name = "IPAddr";
            this.IPAddr.Size = new System.Drawing.Size(124, 27);
            this.IPAddr.TabIndex = 5;
            this.IPAddr.Text = "127.0.0.1";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(406, 25);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(124, 27);
            this.Port.TabIndex = 6;
            this.Port.Text = "10086";
            // 
            // Constatus
            // 
            this.Constatus.Location = new System.Drawing.Point(123, 59);
            this.Constatus.Name = "Constatus";
            this.Constatus.Size = new System.Drawing.Size(124, 27);
            this.Constatus.TabIndex = 7;
            // 
            // MyMessage
            // 
            this.MyMessage.Location = new System.Drawing.Point(123, 93);
            this.MyMessage.Name = "MyMessage";
            this.MyMessage.Size = new System.Drawing.Size(319, 27);
            this.MyMessage.TabIndex = 8;
            // 
            // MyTimes
            // 
            this.MyTimes.Location = new System.Drawing.Point(123, 127);
            this.MyTimes.Name = "MyTimes";
            this.MyTimes.Size = new System.Drawing.Size(124, 27);
            this.MyTimes.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "连接服务器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MySend
            // 
            this.MySend.Location = new System.Drawing.Point(269, 125);
            this.MySend.Name = "MySend";
            this.MySend.Size = new System.Drawing.Size(93, 29);
            this.MySend.TabIndex = 11;
            this.MySend.Text = "发送";
            this.MySend.UseVisualStyleBackColor = true;
            this.MySend.Click += new System.EventHandler(this.MySend_Click);
            // 
            // ShowDetail
            // 
            this.ShowDetail.Location = new System.Drawing.Point(34, 225);
            this.ShowDetail.Multiline = true;
            this.ShowDetail.Name = "ShowDetail";
            this.ShowDetail.Size = new System.Drawing.Size(497, 373);
            this.ShowDetail.TabIndex = 12;
            // 
            // stopconnect
            // 
            this.stopconnect.Location = new System.Drawing.Point(377, 59);
            this.stopconnect.Name = "stopconnect";
            this.stopconnect.Size = new System.Drawing.Size(93, 29);
            this.stopconnect.TabIndex = 13;
            this.stopconnect.Text = "断开连接";
            this.stopconnect.UseVisualStyleBackColor = true;
            this.stopconnect.Click += new System.EventHandler(this.stopconnect_Click);
            // 
            // WindLoca1
            // 
            this.WindLoca1.Location = new System.Drawing.Point(34, 179);
            this.WindLoca1.Name = "WindLoca1";
            this.WindLoca1.Size = new System.Drawing.Size(245, 27);
            this.WindLoca1.TabIndex = 14;
            // 
            // WindLoca2
            // 
            this.WindLoca2.Location = new System.Drawing.Point(334, 179);
            this.WindLoca2.Name = "WindLoca2";
            this.WindLoca2.Size = new System.Drawing.Size(250, 27);
            this.WindLoca2.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "发送窗口：";
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 645);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WindLoca2);
            this.Controls.Add(this.WindLoca1);
            this.Controls.Add(this.stopconnect);
            this.Controls.Add(this.ShowDetail);
            this.Controls.Add(this.MySend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MyTimes);
            this.Controls.Add(this.MyMessage);
            this.Controls.Add(this.Constatus);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IPAddr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(300, 200);
            this.Name = "client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "发送端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ShowDetail;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox Constatus;
        private System.Windows.Forms.TextBox MyMessage;
        private System.Windows.Forms.TextBox MyTimes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button MySend;
        private System.Windows.Forms.TextBox IPAddr;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Button stopconnect;
        private System.Windows.Forms.TextBox WindLoca1;
        private System.Windows.Forms.TextBox WindLoca2;
        private System.Windows.Forms.Label label6;
    }
}

