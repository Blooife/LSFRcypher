using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labTi2
{
    static class Program
    {
        public abstract class Obj
        {
            public short[] StrToBits(string key)
            {
                short[] res = new short[key.Length];
                for (int i = 0; i < key.Length; i++)
                {
                    res[i] = key[i] == '0' ? (short)0 : (short)1;
                }
                return res;
            }
            
            public short[] ByteArrToBits(byte[] arr)
            {
                short[] res = new short[arr.Length*8];
                int k = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    short[] temp = ToBits(arr[i]);
                    foreach (var bit in temp)
                    {
                        res[k] = bit;
                        k++;
                    }
                }
                return res;
            }
            
            public short[] ToBits(byte b)
            {
                short[] res = new short[8];
                for (int i = 0; i < 8; i++)
                {
                    res[i] = (short)((b >> i) & 1);
                }
                return res;
            }

            public byte ToByte(short[] bits)
            {
                byte b = (byte)((bits[0] << 0)
                                | (bits[1] << 1)
                                | (bits[2] << 2)
                                | (bits[3] << 3)
                                | (bits[4] << 4)
                                | (bits[5] << 5)
                                | (bits[6] << 6)
                                | (bits[7] << 7));
                return b;
            }
            
            public byte[] bitsArrToByte(short[] bits)
            {
                byte[] res = new byte[bits.Length / 8];
                short[] temp = new short[8];
                int k = 0;
                int j = 0;
                while (k < bits.Length)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        temp[i] = bits[k];
                        k++;
                    }
                    res[j] = ToByte(temp);
                    j++;
                }
                return res;
            }

            public string BitsArrToSTr(short[] bits)
            {
                return String.Join("", bits);
            }
        }
        
            

        public class PlainText: Obj
        {

            public short[] bitsPlainText;
           // public byte[] bytesPlainText;
            public string strPlainText;
            public int length;

            public PlainText(byte[] bytes)
            {
             //   bytesPlainText = bytes;
                bitsPlainText = ByteArrToBits(bytes);
                strPlainText = BitsArrToSTr(bitsPlainText);
                length = bitsPlainText.Length;
            }
            
            public PlainText(string str)
            {
                
                bitsPlainText = StrToBits(str);
              //  bytesPlainText = bitsArrToByte(bitsPlainText);
                strPlainText = str;
                length = bitsPlainText.Length;
            }
        }
        
        public class Key: Obj
        {
            public short[] bitsKey;
           // public byte[] bytesKey;
            public string strKey;

            public Key(string k)
            {
                strKey = k;
                bitsKey = StrToBits(strKey);
            }
            
            public Key(short[] bits)
            {
                
                bitsKey = bits;
                strKey = BitsArrToSTr(bits);
            }
        }
        
        public class Cipher: Obj
        {
            public short[] bitsCipher; 
            public byte[] bytesCipher;
            public string strCipher;
            
            
            public Cipher(short[] bits)
            {
                bytesCipher = bitsArrToByte(bits);
                strCipher = BitsArrToSTr(bits);
            }
        }
        public class LSFR: Obj
        {
            public int M;
            private static short[] register;
            public static short[] taps = {26, 8, 7, 1 };
           // public static short[] taps = {4, 1};
            public int period;

           public PlainText plaintext;
           public Key key;
           public Cipher cipher;

            public LSFR(int deg, Key k, PlainText p)
            {
                this.M = deg;
                period = (int)Math.Pow(2, M) - 1;
                
                plaintext = p;
                register = k.bitsKey;
                key = new Key(GetKey());
            }

            static short GetNextBit()
            {
            short res = 0;
            short newBit = 0;
            for (int i = 0; i < taps.Length; i++)
            {
                newBit = (short)(newBit ^ register[taps[i]-1]);
            }
            res = register[register.Length - 1];
            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }

            register[0] = newBit;
            return res;
        }

        public short[] GetResult(short[] key, short[] text)
        {
            short[] res;
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (short)(text[i] ^ key[i]);
            }

            cipher = new Cipher(text);
            return text;
        }
        
        public short[] GetKey()
        {
            short[] res = new short[plaintext.length];
            int l = plaintext.length < period ? plaintext.length : period;
            for (int i = 0; i < l; i++)
                res[i] = GetNextBit();

            for (int i = period; i < plaintext.length; i++)
                res[i] = res[i % period];
            
            return res;
        }
        }
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}