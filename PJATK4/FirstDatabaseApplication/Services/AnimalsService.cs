using FirstDatabaseApplication.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FirstDatabaseApplication.Services
{
    public class AnimalsService : DataBaseInterFace
    {
        private SqlDMLService _SqlDMLService;
        private SqlDQLService _SqlDQLService;
        public AnimalsService(IConfiguration configuration)
        {
            _SqlDMLService = new SqlDMLService(configuration);
            _SqlDQLService = new SqlDQLService(configuration);
        }

        public Animal AddNewAnimal(Animal animal)
        {
           return _SqlDMLService.InsertRecordDataBase(animal);
        }

        public int DeleteAnimal(int idAnimal)
        {
            return _SqlDMLService.DeleteRecordDataBase(idAnimal);
        }

        public List<Animal> GetAnimalsFromDataBase(string orderColumn)
        {
            return _SqlDQLService.GetDataFromDataBase(orderColumn);
        }

        public Animal ModifyAnimal(int idAnimal, Animal animal)
        {
            return _SqlDMLService.UpdateRecordDataBase(idAnimal, animal);
        }
    }
}
