using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3tag_Fix
{
    class Parser
    {
        private long curPos;
        private byte curPars; //xxxxx000 0-Head/1-Frame 1-Name 1-Flag 1-Size 1-Storage Пока хз
        public byte CurPars
        {
            get
            {
                return CurPars;
            }
            set
            {
                curPars = value;
            }
        }
        public Parser()
        {
        }
        public byte[] Parsing(FileStream audio,long pos, bool isHeader)
        {
            if (isHeader)
            {
                byte[] tempStorage = new byte[6]; //2 Байта - Версия / 4 Байта - Размер
                curPos = 3;
                if (audio.Position != curPos)
                    audio.Seek(curPos, 0);
                audio.Read(tempStorage, 0, 2);
                audio.Seek(6, 0);
                audio.Read(tempStorage, 2, 4);
                curPos = 10;
                return tempStorage;
            }
            else
            {
                byte[] tempStorage = new byte[8]; //4 Байта - Имя / 4 Байта - Размер
                curPos = pos;
                if (audio.Position != curPos)
                    audio.Seek(curPos, 0);
                audio.Read(tempStorage, 0, 4);
                audio.Read(tempStorage, 4, 4);
                curPos = curPos + 10;
                return tempStorage;
            }  
        }
    }
}
