using FirstDatabaseApplication.Models;
using System.Collections.Generic;

namespace FirstDatabaseApplication.Services
{
    public interface DataBaseInterFace
    {
        public Animal AddNewAnimal(Animal animal);
        public Animal ModifyAnimal(int idAnimal, Animal animal);
        public List<Animal> GetAnimalsFromDataBase(string oderColumn);
        public int DeleteAnimal(int idAnimal);
    }
}
