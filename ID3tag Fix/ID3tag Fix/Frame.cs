using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3tag_Fix
{
    class Frame
    {
        OpNumber opNumber = new OpNumber();
        private string name;
        private long size;
        private long dataPos;
        private string storage;
        //private byte ver;
        /*public Frame(byte ver)
        {
            name = "";
            size = 0;
            storage = "";
            dataPos = 0;
            ver = this.ver;
        }*/
        public Frame(byte[] rawData, byte ver, long pos)
        {
            for(byte i=0;i<4;i++)
            {
                this.name += (char)rawData[i];
            }
            if(ver==4)
            {
                size = opNumber.Arr7BitToNum(rawData);
            }
            else
            {
                size = opNumber.Arr8BitoNum(rawData);
            }
            dataPos = pos + 10; 
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public long Size
        {
            get
            {
                return size;
            }
        }
        public string Storage
        {
            get
            {
                return storage;
            }
        }
        public long DataPos
        {
            get
            {
                return dataPos;
            }
        }
    }
}
