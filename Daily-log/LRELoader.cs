using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Daily_log
{
    class LRELoader
    {
        private readonly static byte version = 1;

        private static SHA512Managed SHA512 = new SHA512Managed();
        public static Encoding UTF8 = Encoding.UTF8;

        public static void read(string path, byte[] password, SortedDictionary<DateTime, string> dictionary)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path", "pathがnullでした。");
            }
            else if (!File.Exists(path))
            {
                throw new ArgumentException("ファイルが存在しません。", "path");
            }
            else if (password == null)
            {
                throw new ArgumentNullException("password", "passwordがnullでした。");
            }
            else if (password.Length > 64)
            {
                throw new ArgumentException("パスワードが長すぎます。", "password");
            }
            else if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary", "dictionaryがnullでした。");
            }
            else
            {
                byte[] hash = SHA512.ComputeHash(password);
                password = password.Concat(BitConverter.GetBytes(password.Length)).ToArray();

                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read)))
                {
                    byte[] header = br.ReadBytes(32);
                    string identifier = new string(new char[] { (char)header[0], (char)header[1], (char)header[2], });
                    if (!identifier.Equals("lre"))
                    {
                        throw new ArgumentException("日々ログファイルではありません。", path);
                    }
                    byte version = header[3];

                    byte[] Read(int length)
                    {
                        byte[] data = br.ReadBytes(length);

                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] ^= hash[i % 64];
                        }

                        return data;
                    }

                    byte[] buf = Read(password.Length);
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (password[i] != buf[i])
                        {
                            throw new ArgumentException("パスワードが違います。", "password");
                        }
                    }

                    dictionary.Clear();

                    int count = BitConverter.ToInt32(Read(4), 0);
                    for (int i = 0; i < count; i++)
                    {
                        buf = Read(7);
                        dictionary.Add(new DateTime(buf[0] + 2000, buf[1], buf[2]), UTF8.GetString(Read(BitConverter.ToInt32(buf, 3))));
                    }
                }
            }
        }

        public static void write(string path, byte[] password, SortedDictionary<DateTime, string> dictionary)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path", "pathがnullでした。");
            }
            else if (password == null)
            {
                throw new ArgumentNullException("password", "passwordがnullでした。");
            }
            else if (password.Length > 64)
            {
                throw new ArgumentException("パスワードが長すぎます。", "password");
            }
            else if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary", "dictionaryがnullでした。");
            }
            else
            {
                byte[] hash = SHA512.ComputeHash(password);
                int count = dictionary.Count;

                using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    byte[] header = new byte[32];
                    header[0] = (byte)'l';
                    header[1] = (byte)'r';
                    header[2] = (byte)'e';
                    header[3] = version;
                    bw.Write(header);

                    void Write(byte[] data)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] ^= hash[i % 64];
                        }

                        bw.Write(data);
                    }

                    Write(password.Concat(BitConverter.GetBytes(password.Length)).ToArray());
                    Write(BitConverter.GetBytes(count));

                    DateTime[] keys = dictionary.Keys.ToArray();

                    for (int i = 0; i < count; i++)
                    {
                        DateTime key = keys[i];
                        byte[] value = UTF8.GetBytes(dictionary[key]);

                        Write(new byte[] { (byte)(key.Year - 2000), (byte)key.Month, (byte)key.Day, }.Concat(BitConverter.GetBytes(value.Length)).ToArray());
                        Write(value);
                    }

                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                    byte[] footer = new byte[new Random().Next(32)];
                    rng.GetNonZeroBytes(footer);
                    Write(footer);

                    rng.Dispose();
                }
            }
        }

        public static void backupRead(string path, byte[] password, out byte[] data)
        {
            if (!File.Exists(path))
            {
                data = null;
                return;
            }

            byte[] hash = SHA512.ComputeHash(password);

            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read)))
            {
                data = br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(4), 0));

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] ^= hash[i % 64];
                }
            }
        }

        public static void backupWrite(string path, byte[] password, byte[] data)
        {
            byte[] hash = SHA512.ComputeHash(password);
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write)))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] ^= hash[i % 64];
                }

                bw.Write(data.Length);
                bw.Write(data);
            }
        }
    }
}
