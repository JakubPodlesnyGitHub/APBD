using System.IO;

namespace WebAppGetData.Models
{
    public class WriteFile
    {
        FileInfo file;

        public WriteFile(FileInfo file)
        {
            this.file = file;
        }

        public void WriteStudentToFile(Student student)
        {
            using StreamWriter streamWriter = file.AppendText(); streamWriter.WriteLine(student.ToString());
        }
    }
}
