using FileWriterProject.Models;
using System;
using System.IO;

namespace FileWriterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Univeristy university = new Univeristy();
            FileTypeReader fileTypeReader = new FileTypeReader(university,args[0]);
            FileTypeWriter fileTypeWriter = new FileTypeWriter(args[1]);
            try
            {
                fileTypeReader.ReadFile();
                fileTypeWriter.SaveAS(args[2], university.ToString());
            }
            catch (Exception ex)
            {
                SaveToLogsFile(ex.Message); 
            }
            university.DisplayStudents();
        }
        public static void SaveToLogsFile(string description)
        {
            using StreamWriter streamWriter = File.AppendText("logs.txt"); streamWriter.WriteLine("Data: " + DateTime.Now + " Blad: " + description);
        }
    }
}
