using DifferenceStoredProcedureTransactionsCodeApp.Models;
using System.Threading.Tasks;

namespace DifferenceStoredProcedureTransactionsCodeApp.InterFaces
{
    public interface DataBaseInterFace
    {
        public Task<int> AddNewProductAsync(Product product);
        public Task<int> AddNewProduct_StoredProcedureAsync(Product product);
        public Task<bool> CheckIdProductAsync(int IdProduct);
        public Task<bool> CheckIdWareHouseAsync(int IdWareHouse);
        public Task<bool> IfOrderExistAsync(Product product);
        public Task<bool> CheckOrderAtProduct_WarehouseAsync(Product product);
        
    }
}
