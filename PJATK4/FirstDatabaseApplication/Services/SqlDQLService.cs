using FirstDatabaseApplication.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FirstDatabaseApplication.Services
{
    public class SqlDQLService
    {

        private IConfiguration _Configuration;
        public SqlDQLService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public List<Animal> GetDataFromDataBase(string orderColumn)
        {
            List<Animal> animalsList = new List<Animal>();
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Animal ORDER BY Name ASC;",sqlConnection);
                
                if (orderColumn != null)
                {
                    com.CommandText = "SELECT * FROM Animal ORDER BY CASE " +
                        "WHEN @orderColumnTMP='Name' THEN Name " +
                        "WHEN @orderColumnTMP='Category' THEN Category " +
                        "WHEN @orderColumnTMP='Description' THEN Description " +
                        "WHEN @orderColumnTMP='Area' then Area END ASC;";
                    com.Parameters.AddWithValue("@orderColumnTMP", orderColumn);
                }

                sqlConnection.Open();

                SqlDataReader sqlDataReader = com.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    animalsList.Add(new Animal
                    {
                        _Name = sqlDataReader["Name"].ToString(),
                        _Description = sqlDataReader["Description"].ToString(),
                        _Category = sqlDataReader["Category"].ToString(),
                        _Area = sqlDataReader["Area"].ToString()
                    });
                }
            }
            return animalsList;
        }
        
    }

}
