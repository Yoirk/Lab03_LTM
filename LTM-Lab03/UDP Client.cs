using System.Net.Sockets;
using System.Net;
using System.Text;

namespace LTM_Lab03
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                IPAddress ipadd = IPAddress.Parse(txtIPhost.Text);
                int port = Convert.ToInt32(txtPort.Text);
                IPEndPoint ipend = new IPEndPoint(ipadd, port);
                //Chuyển chuỗi dữ liệu nhập sang kiểu byte
                Byte[] sendBytes = Encoding.UTF8.GetBytes(txtMessage.Text);
                udpClient.Send(sendBytes, sendBytes.Length, ipend);
                //Xóa dữ liệu vừa gửi ở ô nhập
                txtMessage.Text = "";
            }
            catch {
                MessageBox.Show("Vui lòng nhập đúng thông tin!");
            }
        }
    }
}
