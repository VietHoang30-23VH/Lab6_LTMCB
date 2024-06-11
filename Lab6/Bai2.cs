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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtCipher.Text = EncryptVigenere(txtInput.Text, txtKey.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtPlain.Text = DecryptVigenere(txtCipher.Text, txtKey.Text);
        }

        private string EncryptVigenere(string plainText, string key)
        {
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0, j = 0; i < plainText.Length; i++)
            {
                char c = plainText[i];
                char keyChar = key[j];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int offset = char.ToUpper(keyChar) - 'A';
                    char encryptedChar = (char)((((c + offset - baseChar) % 26) + baseChar));
                    encryptedText.Append(encryptedChar);
                    j = (j + 1) % key.Length;
                }
                else
                {
                    encryptedText.Append(c);
                }
            }
            return encryptedText.ToString();
        }

        private string DecryptVigenere(string encryptedText, string key)
        {
            StringBuilder decryptedText = new StringBuilder();
            for (int i = 0, j = 0; i < encryptedText.Length; i++)
            {
                char c = encryptedText[i];
                char keyChar = key[j];
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int offset = char.ToUpper(keyChar) - 'A';
                    char decryptedChar = (char)((((c - offset - baseChar + 26) % 26) + baseChar));
                    decryptedText.Append(decryptedChar);
                    j = (j + 1) % key.Length;
                }
                else
                {
                    decryptedText.Append(c);
                }
            }
            return decryptedText.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKey.Clear();
            txtInput.Clear();
            txtCipher.Clear();
            txtPlain.Clear();
        }
    }
}
