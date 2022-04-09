using FirstDatabaseApplication.Models;
using FirstDatabaseApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstDatabaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private DataBaseInterFace _DataBase;

        public AnimalController(DataBaseInterFace dataBase)
        {
            _DataBase = dataBase;
        }

        [HttpGet]
        public IActionResult GetListAnimals(string columnName)
        {
            if (columnName == null)//ta walidacje da sie lepiej zapisac 
            {
                return Ok(_DataBase.GetAnimalsFromDataBase(columnName));
            }
            else if (columnName.StartsWith("Name") || columnName.StartsWith("Description") || columnName.StartsWith("Category") || columnName.StartsWith("Area"))
            {
                return Ok(_DataBase.GetAnimalsFromDataBase(columnName));
            }
            return BadRequest("Nie poprawny parametr sortujacy");

        }

        [HttpPut("{idAnimal}")]
        public IActionResult ModifyAnimal(int idAnimal, Animal animal)
        {
            Animal updatedAnimal = _DataBase.ModifyAnimal(idAnimal, animal);
            if (updatedAnimal != null)
                return Ok("Zaktualizowano: " + updatedAnimal);
            return NotFound("Nie znaleziono zwierzecia w bazie o id: " + idAnimal);
        }

        [HttpPost]
        public IActionResult AddNewAnimal(Animal newAnimal)
        {
            Animal addedAnimal = _DataBase.AddNewAnimal(newAnimal);
            return Ok("Dodano nowe zwierze: " + addedAnimal);
        }

        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimal(int idAnimal)
        {
            int result = _DataBase.DeleteAnimal(idAnimal);
            if (result != -1)
                return Ok("Usunieto zwierze o id: " + idAnimal);
            return NotFound("Nie znaleziono zwierzecia w bazie o id: " + idAnimal);
        }
    }
}
