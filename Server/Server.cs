using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener server;
        private List<TcpClient> clientsList = new List<TcpClient>();
        private Thread listenThread;

        //static Dictionary<string, TcpClient> _data = new Dictionary<string, TcpClient>();
        public Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 8888);
                server.Start();
                listenThread = new Thread(ListenForClients);
                listenThread.Start();
                AppendToLog("Server has started on 127.0.0.1:8888.");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi: "+ ex.Message);
            }
        }
        private void ListenForClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clientsList.Add(client);
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string clientName = "";

            // Lấy tên client
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            clientName = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            AppendToLog($"Client's name: {clientName} connected");

            while (true)
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    break;
                }
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                AppendToLog($"{message}");

                // Broadcast mess tới các client khác
                foreach (TcpClient cl in clientsList)
                {
                    NetworkStream broadcastStream = cl.GetStream();
                    broadcastStream.Write(buffer, 0, bytesRead);
                    broadcastStream.Flush();
                }
            }

            AppendToLog("Client disconnected.");
            clientsList.Remove(client);
            client.Close();
        }
        private void AppendToLog(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => AppendToLog(text)));
                return;
            }
            txtServer.AppendText(text + Environment.NewLine);
        }
    }
}
