using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ID3tag_Fix
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            OpNumber opNumber = new OpNumber();
            string path = @"Z:\ID3\Downplay - The One Who Laughs Last.mp3";
            string newPath = @"Z:\ID3\Remake\Downplay - The One Who Laughs Last.mp3";
            File.Copy(path, newPath, true);

            using (FileStream audio = new FileStream(newPath, FileMode.Open))
            {
                Header header = new Header(parser.Parsing(audio,0,true));
                List<Frame> frame = new List<Frame>();
                long i = audio.Position;
                bool isNoTrash = true; //Первая буква тега не NULL для того чтобы отсеять нулевые теги(или то что идет после APIC)

                while(i<header.Size && isNoTrash)
                {
                    frame.Add(new Frame(parser.Parsing(audio, i, false),header.Ver,i));
                    frame[frame.Count - 1].DecodeStorage(audio);
                    frame[frame.Count - 1].OutTag();
                    i = i + 10 + frame[frame.Count-1].Size;
                    audio.Seek(i, 0);
                    isNoTrash = audio.ReadByte() > 32 ? true : false;
                    audio.Seek(audio.Position-1,0);
                }
            }
        }
    }
}
