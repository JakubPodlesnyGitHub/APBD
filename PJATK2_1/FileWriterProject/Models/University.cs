using System;
using System.Collections.Generic;
using System.Linq;

namespace FileWriterProject.Models
{

    class Univeristy
    {
        List<Student> StudentsList;
        Dictionary<string, int> listOfStudyFields;

        public Univeristy()
        {
            StudentsList = new List<Student>();
            listOfStudyFields = new Dictionary<string, int>();
        }

        public void AddFiled(string newFiled)
        {
            if (!listOfStudyFields.ContainsKey(newFiled))
            {
                listOfStudyFields.Add(newFiled, 1);
            }
            else
            {
                listOfStudyFields[newFiled]++;
            }
        }

        public void AddStudent(Student newStudent)
        {

            if (!StudentsList.Contains(newStudent))
            {
                StudentsList.Add(newStudent);
            }
        }

        public void DisplayStudents()
        {
            StudentsList.ForEach(s => Console.WriteLine(s));
            Console.WriteLine(StudentsList.Count);
        }
        
        public string CreateStudiesString()
        {
            string str = "";
            foreach (KeyValuePair<string, int> kvp in listOfStudyFields)
            {
                str += "\n{\nName: " + kvp.Key + ",\nNumberOfStudents: " + kvp.Value + "\n}";
            }
            return str;
        }

        public string CreateStudentsString()
        {
            string str = "";
            StudentsList.ForEach(s => str += s.ToString());
            return str;
        }

        public override string ToString()
        {
            return "Uczelnia:\n" + "CreatedAt: " + DateTime.Now + "\nAuthor: " + "Jakub Podlesny\nStudenci:" + CreateStudentsString() + "\n" + CreateStudiesString();
        }
    }
}
