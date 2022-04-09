using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace FileWriterProject.Models
{
    class FileTypeWriter
    {
        FileInfo targetFIle;

        public FileTypeWriter(string targetFileName)
        {
            targetFIle = new FileInfo(targetFileName);
        }

        public void SaveAS(string format, string content)
        {
            if (format.StartsWith("Json"))
            {
                SaveAsJson(content);
            }
        }
        public void SaveAsJson(string c)
        {
            if (!Directory.Exists(targetFIle.Directory.ToString()))
            {
                throw new ArgumentException("Podana sciezka: " + targetFIle.Directory.ToString() + " nie istnieje");
            }
            else if (!targetFIle.Exists)
            {
               throw new FileNotFoundException("Plik: " + targetFIle.Name + " nie istnieje");
            }
            else
            {
                var jsonString = JsonSerializer.Serialize(c, new JsonSerializerOptions { WriteIndented = true,Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping});
                using StreamWriter streamWriter = new StreamWriter(targetFIle.OpenWrite()); streamWriter.WriteLine(jsonString);
            }
        }
    }
}
