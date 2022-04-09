using System;

namespace FileWriterProject.Models
{
    class Student
    {
        public string Name { get; set; }
        public string Familyname { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string FieldOfStudy { get; set; }
        public string TypeOfStudies { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string IndexNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Name == student.Name &&
                   Familyname == student.Familyname &&
                   IndexNumber == student.IndexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Familyname, IndexNumber);
        }

        public override string ToString()
        {
            return "\n{\nName: " + Name + "\nFamilyName: " + Familyname + "\nFathersName: " + FathersName + "\nMotherName: " + MothersName + "\nBirthDate: " + BirthDate + "\nIndexNumber: " + IndexNumber + "\nStudies: {" + "\nName: " + FieldOfStudy + "\nMode: " +TypeOfStudies + "\n}";
        }
    }
}
