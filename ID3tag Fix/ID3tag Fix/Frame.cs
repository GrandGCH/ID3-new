using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ID3tag_Fix
{
    class Frame
    {
        OpNumber opNumber = new OpNumber();
        private string name;
        private long size;
        private long dataPos;
        private string storage="";
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
        public void DecodeStorage(FileStream audio)
        {
            if (name != "APIC")
            {
                byte[] tArr = new byte[size];
                audio.Seek(dataPos, 0);
                audio.Read(tArr, 0, (int)size);
                for (uint i = 0; i < size; i++)
                    storage += (char)tArr[i];
            }
        }
        public void OutTag()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("Tag name: {0}", Name);
            Console.WriteLine("Tag contains: {0}", Storage);
            Console.WriteLine("Tag begin position: {0}", dataPos-10);
            Console.WriteLine("Tag size: {0}", Size);
            Console.WriteLine("-----------------");
        }
    }
}
