using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ID3tag_Fix
{
    class Header
    {
        private long size;
        private byte ver;
        public long Size
        {
            get
            {
                return size;
            }
        }
        public byte Ver
        {
            get
            {
                return ver;
            }
        }
        public Header(byte[] rawData)
        {
            ver = rawData[0];
        }

    }
}
