using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GhostInTheCell
{
    class Program
    {
        static void Main(string[] args)
        {
            //string directory = otherdirectory
            string directory = "C:\\git\\GhostInTheCell\\GhostInTheCell";
            string outputFileName = "GhostInTheCell.txt";
            string[] fileNames = Directory.GetFiles(directory);
            List<File> files = new List<File>();

            //Load files
            foreach (string fileName in fileNames)
            {
                File file = new File(fileName);

                if (file.fileExtention == "cs" && file.shortFileName != "Program")
                {
                    files.Add(file);
                }
            }

            //Put Player at the front of the list
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].shortFileName == "Player")
                {
                    File playerFile = files[i];
                    files.Remove(playerFile);
                    files.Insert(0, playerFile);
                }
            }


            string path = directory + "\\" + outputFileName;
            //Write to file
            //using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (var outputFile = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                foreach (File file in files)
                {
                    foreach (string line in file.fileLines)
                    {
                        if (line.Length < 5 || (file.shortFileName == "Player" || (line.Substring(0, 5) != "using")))
                        {
                            outputFile.WriteLine(line);
                        }
                    }
                }
                outputFile.Flush();
            }
        }
    }

    class File
    {
        public string fileName;
        public string shortFileName;
        public string fileExtention;
        public string[] fileLines;

        void ReadFile()
        {
            fileLines = System.IO.File.ReadAllLines(fileName);
        }

        public File(string fileName)
        {
            this.fileName = fileName;

            // Get file extention
            int extIndex = -1;
            int fileNameIndex = -1;

            for (int j = 0; j < fileName.Length; j++)
            {
                if (fileName[j] == '.')
                {
                    extIndex = j;
                }
                if (fileName[j] == '\\')
                {
                    fileNameIndex = j;
                }
            }

            if (extIndex != -1)
            {
                fileExtention = fileName.Substring(extIndex + 1, fileName.Length - extIndex - 1);
            }
            else
            {
                fileExtention = "";
            }

            if (fileNameIndex != -1)
            {
                shortFileName = fileName.Substring(fileNameIndex + 1, extIndex - fileNameIndex - 1);
            }
            else
            {
                shortFileName = "";
            }

            if (fileExtention == "cs")
            {
                ReadFile();
            }
        }
    }
}
