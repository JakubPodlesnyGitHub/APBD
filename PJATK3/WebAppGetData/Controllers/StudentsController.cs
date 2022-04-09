using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppGetData.Models;

namespace WebAppGetData.Controllers
{
    //Zasob id = HTTP METHOD + URL

    //HTTP GET api/students?page=1&pageSize=10 - zapis
    //HTTP GET api/students/s1234 - zwrocenie zasobu
    //HTTP POST api/students - dodanie nowego zasobu
    //HTTP PUT api/students/s1234 - pelna aktualizacja zasobu
    //HTTP PATCH api/students/s1234 - dokonywanie czesciowych zmian w podanym zasobie
    //HTTP DELETE api/students/s1234 - usuniecie danego zasobu
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        Univeristy university;

        public StudentsController()
        {
            university = new Univeristy();
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> tmpListStudents = university.GetStudentsList();
            if(tmpListStudents.Count > 0)
            {
                   return Ok(tmpListStudents);
            }
            else
            {
                return NotFound("Brak danych do wyswietlania");
            }
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            return Ok(university.GetStudentFromFile(indexNumber));
        }

        [HttpPost]
        public IActionResult SaveNewStudentToFile(Student student)
        {
            if (student.CheckStudent())
            {
                university.AddStudent(student);
                university.FileSaveStudent(student);
                return Ok("Zapisano do pliku nowego studenta: " + student);
            }
            else
            {
                return UnprocessableEntity("Podany student nie ma wszystkich danych");
            }

        }

        [HttpDelete("{indexNumber}")]
        public IActionResult deleteStudent(string indexNumber)
        {
            Student studentTMP = university.GetStudentFromFile(indexNumber);
            university.DeleteStudent(studentTMP);
            university.FileRemoveStudent(studentTMP);
            return Ok("Studnet zostal usuniety z listy i pliku: " +  studentTMP);
        }


        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber, Student student)
        {
            if (student.CheckStudent())
            {
                university.ChangeStudentsData(indexNumber,student);
                university.FileUpdateStudent(student,indexNumber);
                return Ok("Student zostal zaktualizowany: " + student);
            }
            else
            {
                return UnprocessableEntity("Podany student nie ma wszystkich danych");
            }

        }


    }
}
