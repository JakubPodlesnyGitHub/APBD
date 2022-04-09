using System;
using System.IO;

namespace FileWriterProject.Models
{
    class FileTypeReader
    {
        FileInfo readFile;
        Univeristy univeristy;

        public FileTypeReader(Univeristy univeristy,string readFileName)
        {
            this.univeristy = univeristy;
            readFile = new FileInfo(readFileName);
        }

        public void ReadFile()
        {
            if (!Directory.Exists(readFile.Directory.ToString()))
            {
                throw new ArgumentException("Podana sciezka: " + readFile.Directory.ToString() + " nie istnieje");
            }
            else if (!readFile.Exists)
            {
                throw new FileNotFoundException("Plik: " + readFile.Name + " nie istnieje");
            }

            StreamReader streamReader = new StreamReader(readFile.OpenRead());
            string dataLine;
            int countline = 0;
            while ((dataLine = streamReader.ReadLine()) != null)
            {
                string[] dataTMP = dataLine.Split(',');

                if (dataTMP.Length < 9)
                {
                    SaveToLogsFile("Linia: " + countline + "9 Column Error");
                }
                else if (IsContainsEmptyItem(dataTMP))
                {
                    SaveToLogsFile("Linia: " + countline + " Empty Array Error");
                }
                else
                {
                    Student student = CreateStudent(dataTMP);
                    univeristy.AddStudent(student);
                    univeristy.AddFiled(student.FieldOfStudy);
                }
                countline++;
            }
        }

        private bool IsContainsEmptyItem(string[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == "")
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveToLogsFile(string description)
        {
            using StreamWriter streamWriter = File.AppendText("logs.txt"); streamWriter.WriteLine("Data: " + DateTime.Now + " Blad: " + description);
        }

        private Student CreateStudent(string[] dataTMP)
        {
            Student newStudent = new Student
            {
                Name = dataTMP[0],
                Familyname = dataTMP[1],
                FieldOfStudy = dataTMP[2],
                TypeOfStudies = dataTMP[3],
                IndexNumber = "s" + dataTMP[4],
                BirthDate = dataTMP[5],
                Email = dataTMP[6],
                FathersName = dataTMP[8],
                MothersName = dataTMP[7]
            };
            return newStudent;
        }
    }
}
