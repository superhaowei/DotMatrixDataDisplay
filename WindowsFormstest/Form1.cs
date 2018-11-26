using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

            if ((null == bytes) || (0 == width)) {
                //throw new Exception("参数异常");
                return "";
            }


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
        private Imageinfo imageinfo = new Imageinfo();


        private void fullImageInfo(){
            String text = textBox1.Text;
            try
            {
                imageinfo.datas = strToToHexByte(text);


                if (null != imageinfo.datas)
                {
                    string str = comboBox1.Text;
                    int num = Convert.ToInt32(str, 10);
                    imageinfo.width = num;
                    imageinfo.height = (imageinfo.datas.Length * 8) / num;
                    textBox3.Text = imageinfo.height + "";
                }
            }
            catch (Exception ex)
            {
                imageinfo.height = 0;
                imageinfo.width = 0;
                MessageBox.Show("注意控制你自己！\r\n"+ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for test 
            //textBox1.Text = "0x00, 0x00, 0x07, 0xC0, 0x08, 0x20, 0x13, 0x90, 0x24, 0x48, 0x09, 0x20, 0x02, 0x80, 0x00, 0x00,0x0C, 0x60, 0x1E, 0xF0, 0x3F, 0xF8, 0x02, 0x80, 0x04, 0x40, 0x08, 0x20, 0x00, 0x00, 0x00, 0x00";

            fullImageInfo();
            try
            {
                textBox2.Text = byteToDotMatrixDisplay(imageinfo.datas, imageinfo.width);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注意控制你自己！\r\n"+ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fullImageInfo();
            if ((0 != imageinfo.height) && (0 != imageinfo.width))
            {
                ShowSaveFileDialog();
            }
        }

        private void CreatePicture(int width, int height, byte[] datas, string picSavePath)
        {
            try
            {
                Bitmap bmp = new Bitmap(width, height);

                
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        int bit = (j * width + i) % 8;
                        int index = (j * width + i) / 8;
                        if (0 != (datas[index] & (byte)(0x80 >> bit)))
                        {
                            bmp.SetPixel(i, j, Color.Black);
                        }
                        else
                        {
                            bmp.SetPixel(i, j, Color.Transparent);
                        }
                    }
                }
                bmp.Save(picSavePath, ImageFormat.Bmp);
                bmp.Dispose();
            }
            catch (Exception ex) {
                MessageBox.Show("注意控制你自己！\r\n"+ex.ToString());
            }
        }

        private void ShowSaveFileDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Image（*.bmp）|*.bmp";
 
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
 
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            string newFileName = DateTime.Now.ToString("yyyy_MM_dd") + "_" + imageinfo.width + "x" + imageinfo.height;
            sfd.FileName = newFileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                //string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件
               
                CreatePicture(imageinfo.width, imageinfo.height, imageinfo.datas, localFilePath);
            }
        }

    }
}
