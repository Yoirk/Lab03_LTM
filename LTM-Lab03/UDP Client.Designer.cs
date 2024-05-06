namespace LTM_Lab03
{
    partial class Client
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSend = new Button();
            txtPort = new TextBox();
            txtIPhost = new TextBox();
            txtMessage = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "IP Remote host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 16);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 105);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 2;
            label3.Text = "Message";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 249);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(100, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(296, 34);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 23);
            txtPort.TabIndex = 4;
            // 
            // txtIPhost
            // 
            txtIPhost.Location = new Point(12, 34);
            txtIPhost.Name = "txtIPhost";
            txtIPhost.Size = new Size(100, 23);
            txtIPhost.TabIndex = 5;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 123);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(531, 107);
            txtMessage.TabIndex = 6;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 282);
            Controls.Add(txtMessage);
            Controls.Add(txtIPhost);
            Controls.Add(txtPort);
            Controls.Add(btnSend);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Client";
            Text = "UDP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSend;
        private TextBox txtPort;
        private TextBox txtIPhost;
        private TextBox txtMessage;
    }
}
