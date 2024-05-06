namespace LTM_Lab03_Cau01_Server
{
    partial class Server
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
            txtPort = new TextBox();
            txtReMessages = new TextBox();
            btnListen = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 1;
            label2.Text = "Received mesages";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(47, 15);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 23);
            txtPort.TabIndex = 2;
            // 
            // txtReMessages
            // 
            txtReMessages.Location = new Point(12, 89);
            txtReMessages.Multiline = true;
            txtReMessages.Name = "txtReMessages";
            txtReMessages.Size = new Size(544, 218);
            txtReMessages.TabIndex = 3;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(481, 14);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(75, 23);
            btnListen.TabIndex = 4;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 315);
            Controls.Add(btnListen);
            Controls.Add(txtReMessages);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Server";
            Text = "UDP Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPort;
        private TextBox txtReMessages;
        private Button btnListen;
    }
}
