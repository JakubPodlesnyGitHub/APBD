using DifferenceStoredProcedureTransactionsCodeApp.InterFaces;
using DifferenceStoredProcedureTransactionsCodeApp.Models;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DifferenceStoredProcedureTransactionsCodeApp.Services
{
    public class SqlService : DataBaseInterFace
    {
        private IConfiguration _Configuration;

        public SqlService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public async Task<int> AddNewProductAsync(Product product)
        {
            var idOrder = await GetIdOrderAsync(product);
            double price;

            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                await sqlConnection.OpenAsync();
                SqlCommand sqlPriceCommand = new SqlCommand("SELECT Price FROM Product WHERE IdProduct = @idProductTMP;", sqlConnection);
                sqlPriceCommand.Parameters.AddWithValue("@idProductTMP", product._IdProduct);
                using (var dataPriceReader = await sqlPriceCommand.ExecuteReaderAsync())
                {
                    await dataPriceReader.ReadAsync();
                    price = double.Parse(dataPriceReader["Price"].ToString());
                }
                DbTransaction transac = await sqlConnection.BeginTransactionAsync();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE [ORDER] SET [Order].FulfilledAt = SYSDATETIME() WHERE IdOrder = @idOrderTMP;", sqlConnection, (SqlTransaction)transac);
                    sqlCommand.Parameters.AddWithValue("@idOrderTMP", idOrder);
                    await sqlCommand.ExecuteNonQueryAsync();
                    sqlCommand.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES (@IdWareHouseTMP,@idProductTMP,@idOrderTMP,@amountTMP,@priceTMP,@CreatedAtTMP);";
                    sqlCommand.Parameters.AddWithValue("@idProductTMP", product._IdProduct);
                    sqlCommand.Parameters.AddWithValue("@amountTMP", product._Amount);
                    sqlCommand.Parameters.AddWithValue("@CreatedAtTMP", product._CreatedAt);
                    sqlCommand.Parameters.AddWithValue("@IdWareHouseTMP", product._IdWareHouse);
                    sqlCommand.Parameters.AddWithValue("@priceTMP", price * product._Amount);
                    await sqlCommand.ExecuteNonQueryAsync();
                    sqlCommand.CommandText = "SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @idOrderTMP";
                    await transac.CommitAsync();
                    using var dataReader = await sqlCommand.ExecuteReaderAsync();
                    await dataReader.ReadAsync();
                    return int.Parse(dataReader["IdProductWarehouse"].ToString());
                }
                catch (SqlException sqlError)
                {
                    await transac.RollbackAsync();
                    return -1;
                }
            }
        }

        public async Task<int> AddNewProduct_StoredProcedureAsync(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                var sqlCommand = new SqlCommand("AddProductToWarehouse", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@IdProduct", product._IdProduct));
                sqlCommand.Parameters.Add(new SqlParameter("@IdWarehouse", product._IdWareHouse));
                sqlCommand.Parameters.Add(new SqlParameter("@Amount", product._Amount));
                sqlCommand.Parameters.Add(new SqlParameter("@CreatedAt", product._CreatedAt));
                await sqlConnection.OpenAsync();
                try
                {
                    await sqlCommand.ExecuteNonQueryAsync();
                    sqlCommand.CommandText = "SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @idOrderTMP";
                    using var dataReader = await sqlCommand.ExecuteReaderAsync();
                    await dataReader.ReadAsync();
                    return int.Parse(dataReader["IdProductWarehouse"].ToString());;
                }
                catch (SqlException sqlError)
                {
                    throw new System.Exception(sqlError.Message);
                }
            }
        }

        public async Task<bool> CheckIdProductAsync(int IdProduct)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand sqlCommand = new SqlCommand("Select 1 FROM Product WHERE Product.IdProduct = @IdProduct;", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IdProduct", IdProduct);
                await sqlConnection.OpenAsync();
                using var dataReader = await sqlCommand.ExecuteReaderAsync();
                return dataReader.HasRows;
            }
        }

        public async Task<bool> CheckIdWareHouseAsync(int IdWareHouse)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT 1 FROM Warehouse WHERE Warehouse.IdWareHouse = @IdWareHouse;", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@IdWareHouse", IdWareHouse);
                await sqlConnection.OpenAsync();
                using var dataReader = await sqlCommand.ExecuteReaderAsync();
                return dataReader.HasRows;
            }
        }

        public async Task<bool> IfOrderExistAsync(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT 1 FROM [Order] WHERE IdProduct = @idProductTMP AND Amount = @amountTMP AND CreatedAt < @createdAtTMP;", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idProductTMP", product._IdProduct);
                sqlCommand.Parameters.AddWithValue("@amountTMP", product._Amount);
                sqlCommand.Parameters.AddWithValue("@createdAtTMP", product._CreatedAt);
                await sqlConnection.OpenAsync();
                using var dataReader = await sqlCommand.ExecuteReaderAsync();
                return dataReader.HasRows;
            }
        }

        public async Task<bool> CheckOrderAtProduct_WarehouseAsync(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB")))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT 1 FROM Product_Warehouse WHERE Product_Warehouse.IdOrder = (SELECT IdOrder FROM [Order] WHERE IdProduct = @idProductTMP AND Amount = @amountTMP AND CreatedAt < @createdAtTMP);", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idProductTMP", product._IdProduct);
                sqlCommand.Parameters.AddWithValue("@amountTMP", product._Amount);
                sqlCommand.Parameters.AddWithValue("@CreatedAtTMP", product._CreatedAt);
                await sqlConnection.OpenAsync();
                using var dataReader = await sqlCommand.ExecuteReaderAsync();
                return dataReader.HasRows;
            }
        }
        
        private async Task<int> GetIdOrderAsync(Product product)
        {
            using SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ProductionDB"));
            SqlCommand sqlCommand = new SqlCommand("SELECT IdOrder FROM [Order] WHERE IdProduct = @idProductTMP AND Amount = @amountTMP AND CreatedAt < @createdAtTMP;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@idProductTMP", product._IdProduct);
            sqlCommand.Parameters.AddWithValue("@amountTMP", product._Amount);
            sqlCommand.Parameters.AddWithValue("@createdAtTMP", product._CreatedAt);
            await sqlConnection.OpenAsync();
            using var dataReader = await sqlCommand.ExecuteReaderAsync();
            await dataReader.ReadAsync();
            return int.Parse(dataReader["IdOrder"].ToString());
        }
    }
}

