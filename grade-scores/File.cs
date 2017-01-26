using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace grade_scores
{
    public class File
    {
        String fileName;
        String absoluteFilePath;
        String suffix = "-graded.txt";

        public File(String fileName)
        {
            this.fileName = fileName;
            GetAbsolutePath();
        }

        private void GetAbsolutePath()
        {
            if (fileName == System.IO.Path.GetFullPath(fileName))
            {
                absoluteFilePath = fileName;
            }
            else
            {
                String location = Assembly.GetExecutingAssembly().Location;
                String directory = System.IO.Path.GetDirectoryName(location);
                this.absoluteFilePath = directory + @"\" + fileName;
            }
        }
        public string AbsolutePath
        {
            get
            {
                return absoluteFilePath;
            }
        }
        public String GetFileContents()
        {
            try
            {
                String readText = System.IO.File.ReadAllText(absoluteFilePath);
                return readText;
            }
            catch(FileNotFoundException ex)
            {
                throw new FileNotFoundException("Error accessing file:" + absoluteFilePath);
            }
        }
        public bool WriteToFile(String fileContents)
        {
            String fileNameWithNewSuffix = absoluteFilePath.Replace(".txt", suffix);
            try
            {
                System.IO.File.WriteAllText(fileNameWithNewSuffix, fileContents);
                return true;
            }
            catch(FileNotFoundException ex)
            {
                throw new FileNotFoundException("Error writing to File: " + fileNameWithNewSuffix);
            }
        }
    }
}
