using First_BlazorApp.Models;
using System;
using System.Collections.Generic;

namespace First_BlazorApp.Data
{
    public interface IStudentsService
    {
        public List<Student> StudentsList { get; set; }
    }

    public class StudentsService : IStudentsService
    {
        private static readonly string[] Studies = new[]
        {
            "IT", "Psychology", "Art", "Engineering", "Computer Graphics", "Linguistics"
        };

        private static readonly string[] FirstNames = new[]
        {
            "John", "Sarah", "Ann", "Michael", "Matthew",
        };

        private static readonly string[] LastNames = new[]
        {
            "Doe", "Parker", "Jones", "Williams", "Evans"
        };
        private static readonly string[] Avatars = new[]
        {
            "https://i.ibb.co/Snhc7c6/Female-Student.png",
            "https://i.ibb.co/f9QSs23/Male-Student.png"
        };
        
        public List<Student> StudentsList { get; set; }
        
        public StudentsService()
        {
            StudentsList = GetStudentsList(128);
        }

        public List<Student> GetStudentsList(int k)
        {
            var random = new Random();
            List<Student> studentsList = new List<Student>();
            for (int i = 0; i < k; i++)
            {
                Student student = new Student
                {
                    FirstName = FirstNames[random.Next(FirstNames.Length)],
                    LastName = LastNames[random.Next(LastNames.Length)],
                    Studies = Studies[random.Next(Studies.Length)],
                    BirthDate = DateTime.Now
                };
                if (student.FirstName == "Sarah" || student.FirstName == "Ann")
                    student.Avatar = Avatars[0];
                else
                    student.Avatar = Avatars[1];

                studentsList.Add(student);
            }
            return studentsList;
        }
    }
}
