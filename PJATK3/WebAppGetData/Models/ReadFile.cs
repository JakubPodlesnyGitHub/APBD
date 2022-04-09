using System.IO;
using System.Linq;

namespace WebAppGetData.Models
{
    public class ReadFile
    {
        FileInfo file;

        public ReadFile(FileInfo file)
        {
            this.file = file;
        }

        public void ReadStudentsFile(Univeristy univeristy)
        {
            StreamReader streamReader = new StreamReader(file.OpenRead());
            string textLine;
            string[] txtTab;
            while ((textLine = streamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(textLine))
                {
                    txtTab = textLine.Split(",");
                    univeristy.AddStudent(CreateStudent(txtTab));
                }
            }
            streamReader.Dispose();
        }

        public void DeleteStudentFromFile(Student student)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(file.FullName).Where(l => l != student.ToString());

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(file.FullName);
            File.Move(tempFile, file.FullName);
        }


        public void UpdateStudentFromFile(Student student,string indexNubmer)
        {
            var tempFile = Path.GetTempFileName();
            string [] tabLines = File.ReadAllLines(file.FullName);

            for(int i = 0; i < tabLines.Length; i++)
            {
                string[] tmp = tabLines[i].Split(",");
                if (tmp[2].Equals(indexNubmer))
                {
                    tabLines[i] = student.ToString();
                }
            }

            File.WriteAllLines(tempFile, tabLines);
            File.Delete(file.FullName);
            File.Move(tempFile, file.FullName);
        }


        private Student CreateStudent(string[] dataTab)
        {
            Student student = new Student()
            {
                _Name = dataTab[0],
                _Familyname = dataTab[1],
                _IndexNumber = dataTab[2],
                _BirthDate = dataTab[3],
                _FieldOfStudy = dataTab[4],
                _TypeOfStudies = dataTab[5],
                _Email = dataTab[6],
                _FathersName = dataTab[7],
                _MothersName = dataTab[8]
            };
            return student;
        }
    }
}
