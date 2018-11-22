using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormstest
{
    class Imageinfo
    {

        private int _height;
        private int _width;
        private byte[] _datas;


        public int height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int width
        {
            get { return _width; }
            set { _width = value; }
        }

        public byte[] datas
        {
            get { return _datas; }
            set { _datas = value; }
        }

        public Imageinfo() { 
            this.width = 0;
            this.height = 0;
            this.datas = null;
        }
        public Imageinfo(int width, int height,byte[] datas) {
            this.width = width;
            this.height = height;
            this.datas = datas;
        }

        
    }
}
