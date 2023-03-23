using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labTi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public byte[] ReadFile(string filePath)
        {
            List<byte> list = new List<byte>();
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                    list.Add( reader.ReadByte());
            }
            return list.ToArray();
        }

        public void WriteInTextbox(string str)
        {
            //lock (locker)
            {
                if (FileText.InvokeRequired)
                {
                    Action safeWrite = delegate { WriteInTextbox(str); };
                    FileText.Invoke(safeWrite);
                }
                else
                {
                    FileText.Text += str;
                }
                    
            }
        }
        

        private Program.PlainText plaintext;
        private Program.Key key;
        private Program.LSFR lsfr;
        
        static object locker = new object();
        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog1.FileName;
            plaintext = new Program.PlainText(ReadFile(filePath));
            MessageBox.Show("прочитано");
            if (plaintext.length > 5000)
            {
                FileText.Text = plaintext.strPlainText.Substring(0, 5000);
            }
            else
            {
                FileText.Text = plaintext.strPlainText;
            }
        }

        private void ButCrypt_Click(object sender, EventArgs e)
        {
            Cypher();
        }

        public void WriteFile(string filePath, byte[] bytes)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    writer.Write(bytes[i]);
                }
            }
        }
        private void ButSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = saveFileDialog1.FileName;
            WriteFile(filePath, lsfr.cipher.bytesCipher);
        }


        private void inputKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar < 48 || e.KeyChar > 49) && number != 8)
            {
                e.Handled = true;
            }
        }

        public void Cypher()
        {
            if (inputKey.Text.Length < 4)
            {
                MessageBox.Show("Длина ключа меньше 26");
            }
            else
            {
                key = new Program.Key(inputKey.Text);
                if(plaintext == null)
                    plaintext = new Program.PlainText(FileText.Text);
                lsfr = new Program.LSFR(4, key, plaintext);
                lsfr.GetResult(lsfr.key.bitsKey, plaintext.bitsPlainText);
                cipherText.Text = "done";
                
                if (lsfr.key.strKey.Length > 3000)
                {
                    keyText.Text = lsfr.key.strKey.Substring(0, 3000);
                }
                else
                {
                    keyText.Text = lsfr.key.strKey;
                }
                
                if (lsfr.cipher.strCipher.Length > 3000)
                {
                    cipherText.Text = lsfr.cipher.strCipher.Substring(0, 3000);
                }
                else
                {
                    cipherText.Text = lsfr.cipher.strCipher;
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filePath = saveFileDialog1.FileName;
                WriteFile(filePath, lsfr.cipher.bytesCipher);
            }
        }
        private void butDecipher_Click(object sender, EventArgs e)
        {
            Cypher();
        }
    }
}