using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTM_Lab03_Cau01_Server
{
    public partial class Server : Form
    {
        private UdpClient udpClient;
        private Thread listenThread;

        public Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt32(txtPort.Text);
                udpClient = new UdpClient(port);

                // Tạo một luồng phụ để lắng nghe kết nối từ Client
                listenThread = new Thread(new ThreadStart(ListenForMessages));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch
            {
                MessageBox.Show("Vui lòng đúng thông tin!");
            }
        }

        private void ListenForMessages()
        {
            try
            {
                while (true)
                {
                    IPEndPoint IpEnd = new IPEndPoint(IPAddress.Any, 0);
                    //Đón nhận và đẩy dữ liệu nhận được vào mảng Byte
                    Byte[] recvBytes = udpClient.Receive(ref IpEnd);
                    string Data = Encoding.UTF8.GetString(recvBytes);
                    string mess = IpEnd.Address.ToString() + ":" + IpEnd.Port.ToString() + ": " + Data.ToString();
                    // Gọi hàm hiển thị thông điệp nhận được lên màn hình
                    InfoMessage(mess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void InfoMessage(string mess)
        {
            // Gửi yêu cầu thực hiện trên luồng của giao diện người dùng
            txtReMessages.Invoke((MethodInvoker)delegate {
                txtReMessages.AppendText(mess + Environment.NewLine);
            });
        }
    }
}
