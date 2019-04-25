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
            string path = @"Z:\ID3\Billy Idol - Eyes Without a Face.mp3";
            string newPath = @"Z:\ID3\Remake\Billy Idol - Eyes Without a Face.mp3";
            File.Copy(path, newPath, true);
            using (FileStream audio = new FileStream(newPath, FileMode.Open))
            {
                parser.Parsing(audio, 0, true);
            }
        }
    }
}
