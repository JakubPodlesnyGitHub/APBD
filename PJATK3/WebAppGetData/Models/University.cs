using System;
using System.Collections.Generic;
using System.IO;

namespace WebAppGetData.Models
{
    public class Univeristy
    {
        List<Student> StudentsList;
        ReadFile readFile;
        WriteFile writeFile;
        FileInfo fileInfo;
        public Univeristy()
        {
            StudentsList = new List<Student>();
            fileInfo = new FileInfo(@".\Data\StudentsDataFile.csv");
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                throw new ArgumentException("Podana sciezka: " + fileInfo.DirectoryName + " jest niepoprawna");
            }
            else if (!File.Exists(fileInfo.FullName))
            {
                throw new FileNotFoundException("Podany plik: " + fileInfo.FullName + " nie istnieje");
            }
            else
            {
                readFile = new ReadFile(fileInfo);
                writeFile = new WriteFile(fileInfo);
                readFile.ReadStudentsFile(this);

            }

        }

        public void AddStudent(Student student)
        {
            if (!StudentsList.Contains(student))
            {
                StudentsList.Add(student);
            }
        }

        public void DeleteStudent(Student student)
        {
            if (StudentsList.Contains(student))
            {
                StudentsList.Remove(student);
            }
        }

        public List<Student> GetStudentsList()
        {
            return StudentsList;
        }

        public void ChangeStudentsData(string indexnumber,Student studentToUpdate)
        {
            foreach (Student student in StudentsList)
            {
                if (student._IndexNumber.Equals(indexnumber))
                {
                    student.ChangeStudnetsData(studentToUpdate);
                }
            }
        }

        public Student GetStudentFromFile(String indexNumber)
        {
            foreach (Student s in StudentsList)
            {
                if (s._IndexNumber.Equals(indexNumber))
                {
                    return s;
                }
            }
            return null;
        }

        public void FileSaveStudent(Student student)
        {
            writeFile.WriteStudentToFile(student);
        }

        public void FileRemoveStudent(Student student)
        {
            readFile.DeleteStudentFromFile(student);
        }

        public void FileUpdateStudent(Student student,string indexNumber)
        {
            readFile.UpdateStudentFromFile(student,indexNumber);
        }

    }
}
