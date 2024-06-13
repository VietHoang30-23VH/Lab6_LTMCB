using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Lab6
{
    public partial class Server : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private Dictionary<TcpClient, string> clientDictionary = new Dictionary<TcpClient, string>();
        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(txtIP.Text.Trim()); 
            tcpListener = new TcpListener(ipAddress, int.Parse(txtPort.Text));
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
            AppendToTextBox("Server started.");
            btnStart.Enabled = false;
        }
        private void ListenForClients()
        {
            tcpListener.Start();
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                byte[] buffer = new byte[4096];
                int bytesRead = client.GetStream().Read(buffer, 0, buffer.Length);
                string clientName = Encoding.UTF8.GetString(buffer,0,bytesRead);
                clientDictionary.Add(client, clientName);
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
                UpdateClient();
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }
                if (bytesRead == 0)
                {
                    break;
                }
                string incomingMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                string clientName;
                if (clientDictionary.TryGetValue(tcpClient, out clientName))
                {
                    string formattedMessage = $"{clientName}: " + incomingMessage;
                    AppendToTextBox(formattedMessage);
                    AppendToServer(incomingMessage);
                    BroadcastMessage(formattedMessage);
                }
            }
            tcpClient.Close();
            clientDictionary.Remove(tcpClient);
            UpdateClient();
        }

        private void BroadcastMessage(string message)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            foreach (var clientEntry in clientDictionary)
            {
                try
                {
                    NetworkStream clientStream = clientEntry.Key.GetStream();
                    clientStream.Write(messageBytes, 0, messageBytes.Length);
                    clientStream.Flush();
                }
                catch{}
            }
        }

        private void UpdateClient()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateClient));
                return;
            }

            ClientListBox.Items.Clear();
            foreach (var clientEntry in clientDictionary)
            {
                ClientListBox.Items.Add(clientEntry.Value);
            }
        }
        private void AppendToTextBox(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendToTextBox), new object[] { message });
                return;
            }
            rtbMessage.AppendText(message + Environment.NewLine);
        }
        private void AppendToServer(string message)
        {
            if (txtMessage.InvokeRequired)
            {
                txtMessage.Invoke(new Action<string>(AppendToServer), new object[] { message });
                return;
            }
            txtMessage.Clear();
            txtMessage.AppendText(message + Environment.NewLine);
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (btnDecrypt.Enabled == false)
            {
                txtMessage.Text = AESCrypto.Encrypt(txtMessage.Text);
                btnEncrypt.Enabled = false;
                btnDecrypt.Enabled = true;
            }
            else
                MessageBox.Show("There's nothing to encrypt!");
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                txtMessage.Text = AESCrypto.Decrypt(txtMessage.Text);
                btnDecrypt.Enabled = false;
                btnEncrypt.Enabled = true;
            }
            else
                MessageBox.Show("There's nothing to decrypt!");
        }
    }
}
