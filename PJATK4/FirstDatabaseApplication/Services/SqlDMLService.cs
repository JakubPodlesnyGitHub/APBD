using FirstDatabaseApplication.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FirstDatabaseApplication.Services
{
    public class SqlDMLService
    {
        private IConfiguration _Configuration;
        public SqlDMLService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        
        public Animal UpdateRecordDataBase(int idAnimal, Animal animal)
        {
            string sqlUpdateCommand = "UPDATE Animal SET Name = @nameTMP," +
                " Description = @descriptionTMP," +
                " Category = @categoryNameTMP," +
                " Area = @areaTMP WHERE Animal.IdAnimal = @idAnimalTMP;";

            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand com = new SqlCommand(sqlUpdateCommand, sqlConnection);
                com.Parameters.AddWithValue("@idAnimalTMP", idAnimal);
                com.Parameters.AddWithValue("@nameTMP", animal._Name);
                com.Parameters.AddWithValue("@descriptionTMP", animal._Description);
                com.Parameters.AddWithValue("@categoryNameTMP", animal._Category);
                com.Parameters.AddWithValue("@areaTMP", animal._Area);
                sqlConnection.Open();
                int rowsAffected = com.ExecuteNonQuery();
                if(rowsAffected != 0)
                {
                    return animal;
                }
            }   
            return null;
        }
        
        public Animal InsertRecordDataBase(Animal animal)
        {
            string sqlInsertCommand = "INSERT INTO Animal (Name,Description,Category,Area) " +
                "VALUES(@nameTMP,@descriptionTMP,@categoryNameTMP,@areaTMP);";

            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand com = new SqlCommand(sqlInsertCommand, sqlConnection);
                com.Parameters.AddWithValue("@nameTMP", animal._Name);
                com.Parameters.AddWithValue("@descriptionTMP", animal._Description);
                com.Parameters.AddWithValue("@categoryNameTMP", animal._Category);
                com.Parameters.AddWithValue("@areaTMP", animal._Area);
                sqlConnection.Open();
                com.ExecuteNonQuery();
            }
            return animal;
        }
        
        public int DeleteRecordDataBase(int idAnimal)
        {
            string sqlDeleteCommand = "DELETE FROM Animal WHERE IdAnimal = @idAnimalTMP;";

            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand com = new SqlCommand(sqlDeleteCommand, sqlConnection);
                com.Parameters.AddWithValue("@idAnimalTMP", idAnimal);
                sqlConnection.Open();
                int rowsAffected =  com.ExecuteNonQuery();
                if(rowsAffected != 0)
                    return 1;
            }
            return -1;
        }
    }
}
