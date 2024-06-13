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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int shift = Int32.Parse(tbshift.Text);
            string inputtext = tbInput.Text;

            char[] chars = inputtext.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    c = (char)((c + shift - offset) % 26 + offset);

                    if (c < offset)
                    {
                        c = (char)(c + 26);
                    }
                }

                chars[i] = c;
            }

            tbencrypt.Text = new string(chars);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int shift = Int32.Parse(tbshift.Text);
            string encryptedtext = tbencrypt.Text;

            char[] chars = encryptedtext.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    c = (char)((c - shift - offset + 26) % 26 + offset);

                    if (c < offset)
                    {
                        c = (char)(c + 26);
                    }
                }

                chars[i] = c;
            }

            tbdecrypt.Text = new string(chars);
        }


    }
}