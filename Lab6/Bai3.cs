using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server server = new Server();  
            server.Show();
        }
        private void btnClient_Click_1(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }
    }
}
