using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SBIgraphic.ReadFile
{
    public class ReadFileTi
    {
        private string _path;
        public string Path { get => _path; }
        public ReadFileTi(string path)
        {
            _path = path;
            ReadFile();
        }
        public List<string> ReadFile()
        {
            if (_path == null)
            {
                throw new ArgumentNullException();
            }
            var listLine = new List<string>();

            try
            {
                string line = string.Empty;
                using var readFile = new StreamReader(_path);
                while ((line = readFile.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        listLine.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{nameof(ReadFile)} - {e.Message} The file could not be read:");
            }
            return listLine;
        }
    }
}
