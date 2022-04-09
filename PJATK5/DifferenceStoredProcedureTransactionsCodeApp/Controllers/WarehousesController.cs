using DifferenceStoredProcedureTransactionsCodeApp.InterFaces;
using DifferenceStoredProcedureTransactionsCodeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DifferenceStoredProcedureTransactionsCodeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private DataBaseInterFace _DataBaseInterFace;

        public WarehousesController(DataBaseInterFace dataBaseInterFace)
        {
            _DataBaseInterFace = dataBaseInterFace;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            if(product._Amount > 0)
            {
                if (!await _DataBaseInterFace.CheckIdProduct(product._IdProduct))
                    return NotFound("Produkt o danym id: " + product._IdProduct + " nie istnieje");
                else if (!await _DataBaseInterFace.CheckIdWareHouse(product._IdWareHouse))
                    return NotFound("Hurtownia o danym id: " + product._IdWareHouse + " nie istnieje");
                else if (!await _DataBaseInterFace.IfOrderExist(product))
                    return NotFound("Brak odpowiedniego zlecenia");
                else if (await _DataBaseInterFace.CheckOrderAtProduct_Warehouse(product))
                    return BadRequest("Zamowienie zostalo juz zrealizowane");
                return Ok("Produkt zostal dodany do hurtowni. Id produktu w hurtowni: " + await _DataBaseInterFace.AddNewProduct(product)); 
            }
            return BadRequest("Ilosc danego produktu musi byc wieksza od 0");
        }
    }
}
