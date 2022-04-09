using System;

namespace WebAppGetData.Models
{
    public class Student
    {
        public string _Name { get; set; }
        public string _Familyname { get; set; }
        public string _MothersName { get; set; }
        public string _FathersName { get; set; }
        public string _FieldOfStudy { get; set; }
        public string _TypeOfStudies { get; set; }
        public string _BirthDate { get; set; }
        public string _Email { get; set; }
        public string _IndexNumber { get; set; }

        public void ChangeStudnetsData(Student student)
        {
            _Name = student._Name;
            _Familyname = student._Familyname;
            _MothersName = student._MothersName;
            _FathersName = student._FathersName;
            _FieldOfStudy = student._FieldOfStudy;
            _TypeOfStudies = student._TypeOfStudies;
            _BirthDate = student._BirthDate;
            _Email = student._Email;
            _BirthDate = student._BirthDate;
        }


        public bool CheckStudent()
        {
            if (!_Name.Equals("") &&
                !_Familyname.Equals("") &&
                !_IndexNumber.Equals("") &&
                !_FathersName.Equals("") &&
                !_MothersName.Equals("") &&
                !_FieldOfStudy.Equals("") &&
                !_TypeOfStudies.Equals("") &&
                !_BirthDate.Equals("") &&
                !_Email.Equals(""))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   _Name == student._Name &&
                   _Familyname == student._Familyname &&
                   _IndexNumber == student._IndexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_Name, _Familyname, _IndexNumber);
        }

        public override string ToString()
        {
            return _Name + "," + _Familyname + "," + _IndexNumber + "," + _BirthDate + "," + _FieldOfStudy + "," + _TypeOfStudies + "," + _Email + "," + _FathersName + "," + _MothersName;
        }
    }
}
