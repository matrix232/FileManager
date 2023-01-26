using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace FilesManager
{
    internal class FileCreator
    {
        public string FilePath { get; private set; }
        private string _fileName;

        public FileCreator(string filePath, string fileName)
        {
            FilePath = filePath;
            _fileName = fileName;
        }

        public void CreateFile()
        {
            string pathWithName = FilePath + "\\" + _fileName;
            using (FileStream fs = File.Create(pathWithName));
        }
    }
}
