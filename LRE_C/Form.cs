using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace LRE_C
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();

            try
            {
                a();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void a()
        {
            b();
        }

        private void b()
        {
            c();
        }

        private void c()
        {
            throw new Exception("passed away");
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                byte[] password = Encoding.UTF8.GetBytes(box.Text);
                string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));

                byte[] header = br.ReadBytes(64);
                byte[] managedPassword = new SHA512Managed().ComputeHash(password);

                for (int i=0; i<64; i++)
                {
                    if (header[i] != managedPassword[i])
                    {
                        MessageBox.Show("failed");

                        br.Close();

                        return;
                    }
                }

                Dictionary<string, string> dictionary = new Dictionary<string, string>(0); 

                byte[] shift = new SHA256Managed().ComputeHash(password);
                int per = 0;

                byte[] buf = br.ReadBytes(4);

                for (int i = 0; i < 4; i++)
                {
                    buf[i] -= shift[per % 32];

                    per++;
                }

                int count = BitConverter.ToInt32(buf, 0);

                for (int i = 0; i < count; i++)
                {
                    buf = br.ReadBytes(4);

                    for (int j = 0; j < 4; j++)
                    {
                        buf[j] -= shift[per % 32];

                        per++;
                    }

                    int keyLength = BitConverter.ToInt32(buf, 0);

                    buf = br.ReadBytes(keyLength);

                    for (int j = 0; j < keyLength; j++)
                    {
                        buf[j] -= shift[per % 32];

                        per++;
                    }

                    string key = Encoding.UTF8.GetString(buf);

                    buf = br.ReadBytes(4);

                    for (int j = 0; j < 4; j++)
                    {
                        buf[j] -= shift[per % 32];

                        per++;
                    }

                    int valueLength = BitConverter.ToInt32(buf, 0);

                    buf = br.ReadBytes(valueLength);

                    for (int j = 0; j < valueLength; j++)
                    {
                        buf[j] -= shift[per % 32];

                        per++;
                    }

                    string value = Encoding.UTF8.GetString(buf);

                    dictionary.Add(key, value);
                }

                br.Close();

                BinaryWriter bw = new BinaryWriter(File.Open(file.Insert(file.LastIndexOf('.'), "_C"), FileMode.OpenOrCreate));

                header = new byte[32];
                header[0] = (byte)'l';
                header[1] = (byte)'r';
                header[2] = (byte)'e';
                header[3] = 1;
                bw.Write(header);

                void Write(byte[] data)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] ^= managedPassword[i % 64];
                    }

                    bw.Write(data);
                }
                
                Write(password.Concat(BitConverter.GetBytes(password.Length)).ToArray());
                Write(BitConverter.GetBytes(count));

                string[] keys = dictionary.Keys.ToArray();

                for (int i = 0; i < count; i++)
                {
                    string key = keys[i];
                    byte[] value = Encoding.UTF8.GetBytes(dictionary[key]);

                    buf = new byte[3];
                    buf[0] = (byte)int.Parse(key.Substring(2, 2));
                    buf[1] = (byte)int.Parse(key.Substring(5, 2));
                    buf[2] = (byte)int.Parse(key.Substring(8, 2));
                    Write(buf.Concat(BitConverter.GetBytes(value.Length)).ToArray());

                    Write(value);
                }

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                byte[] footer = new byte[new Random().Next(32)];
                rng.GetNonZeroBytes(footer);
                Write(footer);

                rng.Dispose();

                bw.Close();

                MessageBox.Show("succeeded");
            }
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (File.Exists(file) && Path.GetExtension(file).Equals(".lre"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
