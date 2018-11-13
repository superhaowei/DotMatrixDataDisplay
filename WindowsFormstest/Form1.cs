using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormstest
{
    public partial class FormDotMatrixDisplay : Form
    {
        public FormDotMatrixDisplay()
        {
            InitializeComponent();
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            hexString = hexString.Replace("\r", "");
            hexString = hexString.Replace("\n", "");
            hexString = hexString.Replace("0x", "");
            hexString = hexString.Replace(",", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static string byteToHexStr(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }


        public static string byteToDotMatrixDisplay(byte[] bytes, int width)
        {
            StringBuilder sb = new StringBuilder();
            bool end_flag = false;

            int hight = bytes.Length * 8 / width;
            if (bytes != null)
            {
                for (int j = 0; j < hight; j++)
                {
                    sb.Append("//");
                    for (int i = 0; i < width; i++)
                    {
                        int bit = (j * width + i) % 8;
                        int index = (j * width + i) / 8;
                        if (0 != (bytes[index] & (byte)(0x80 >> bit)))
                        {
                            sb.Append(" * ");
                        }
                        else
                        {
                            sb.Append("   ");
                        }
                    }
                    if (end_flag)
                        break;
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //for test 
            //textBox1.Text = "0x00, 0x00, 0x07, 0xC0, 0x08, 0x20, 0x13, 0x90, 0x24, 0x48, 0x09, 0x20, 0x02, 0x80, 0x00, 0x00,0x0C, 0x60, 0x1E, 0xF0, 0x3F, 0xF8, 0x02, 0x80, 0x04, 0x40, 0x08, 0x20, 0x00, 0x00, 0x00, 0x00";


            String text = textBox1.Text;
            byte[] hex = null;
            try
            {
                hex = strToToHexByte(text);
            

                if (null != hex) {
                    string width = comboBox1.Text;
                    int num = Convert.ToInt32(width,10);
                    textBox3.Text = (hex.Length*8)/num + "";
                    textBox2.Text = byteToDotMatrixDisplay(hex, num);
                }
            }
            catch (Exception exxx)
            {
                MessageBox.Show("注意控制你自己！");
            }
        }
    }
}
