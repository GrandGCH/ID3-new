using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3tag_Fix
{
    class OpNumber
    {
        public long Arr7BitToNum(byte[] storage)
        {
            byte sizeArr = (byte)storage.Length;
            long size = 0;
            byte sizeDiff = (byte)(sizeArr == 6 ? 2 : 4);

            for (sbyte i = (sbyte)(sizeArr-1);i>sizeArr-4;i--)
            {
                size += storage[sizeArr - i+sizeDiff] << (8 * (i-sizeDiff) - i-sizeDiff);
            }
            size += storage[sizeArr - 1];
            return size;
        }
        public long Arr8BitoNum(byte[] storage)
        {
            byte sizeArr = (byte)storage.Length;
            long size = 0;
            byte sizeDiff = (byte)(sizeArr == 6 ? 2 : 4);

            for (sbyte i = (sbyte)(sizeArr - 1); i > sizeArr - 4; i--)
            {
                size += storage[sizeArr - i + sizeDiff] << (8 * (i - sizeDiff));
            }
            size += storage[sizeArr - 1];
            return size;
        }
    }
}
