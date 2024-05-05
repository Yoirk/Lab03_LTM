using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleClient
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string clientName;
        Thread catchMess;
        public Client()
        {
            InitializeComponent();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                SendMessage();
            }
        }
        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();
                clientName = txtName.Text;
                byte[] nameBuffer = Encoding.UTF8.GetBytes(clientName);
                stream.Write(nameBuffer, 0, nameBuffer.Length);
                txtName.Enabled = false;
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
                MessageBox.Show("Đã kết nối với server!");

                // Bắt tin nhắn từ server broadcast về
                catchMess = new Thread(CatchMessages);
                catchMess.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi đang kết nối: " + ex.Message);
            }
        }

        private void SendMessage()
        {
            try
            {
                string message = $"{clientName}: {txtMess.Text}";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
                txtMess.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi đang gởi tin: " + ex.Message);
            }
        }
        private void CatchMessages()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        // Tách thông tin nhận được ra thành tên riêng và tin nhắn riêng
                        string[] parts = receivedMessage.Split(':');
                        if (parts.Length == 2)
                        {
                            string senderName = parts[0].Trim();

                            // Khác tên client thì hiển thị tin nhắn
                            if (senderName != clientName)
                            {
                                DisplayMessage(receivedMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận tin: " + ex.Message);
            }
        }

        private void DisplayMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { DisplayMessage(message); }));
            }
            else
            {
                txtChat.AppendText(message + Environment.NewLine);
            }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            ConnectToServer();
        }
    }
}
