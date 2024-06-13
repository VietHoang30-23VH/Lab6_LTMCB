using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream clientStream;
        public Client()
        {
            InitializeComponent();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCipher.Text))
            {
                txtPlain.Text = AESCrypto.Decrypt(txtCipher.Text.Trim());
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = false;
            }
            else MessageBox.Show("Nothing for decryption!");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPlain.Text))
            {
                txtCipher.Text = AESCrypto.Encrypt(txtPlain.Text.Trim());
                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = true;
            }
            else MessageBox.Show("Input your message please!");
        }
        private void StartListening()
        {
            Task.Run(() =>
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while (true)
                {
                    try
                    {
                        bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            break;
                        }
                        string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        AppendToTextBox(receivedMessage);
                    }
                    catch
                    {
                        break;
                    }
                }
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                client = new TcpClient("127.0.0.1", 9999);
                clientStream = client.GetStream();
                try
                {
                    byte[] nameMessage = Encoding.ASCII.GetBytes(txtName.Text);
                    clientStream.Write(nameMessage, 0, nameMessage.Length);
                    AppendToTextBox("Connected to server.");
                    btnConnect.Enabled = false;
                    StartListening();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
            else MessageBox.Show("Type your name please!");
        }

        private void AppendToTextBox(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendToTextBox), new object[] { message });
                return;
            }
            if (!message.StartsWith("Me: "))
            {
                rtbReceived.AppendText(message + Environment.NewLine);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                if (!string.IsNullOrEmpty(txtCipher.Text))
                {
                    byte[] message = Encoding.ASCII.GetBytes(txtCipher.Text);
                    clientStream.Write(message, 0, message.Length);
                    AppendToTextBox("Me: " + txtCipher.Text);
                    txtCipher.Clear();
                    txtPlain.Clear();
                    btnEncrypt.Enabled = true;
                    btnDecrypt.Enabled = true;
                }
                else
                {
                    MessageBox.Show("You must encrypt your message for protection.!");
                }
            }
            else
            {
                MessageBox.Show("Not connected to server.");
            }
        }
    }
}
