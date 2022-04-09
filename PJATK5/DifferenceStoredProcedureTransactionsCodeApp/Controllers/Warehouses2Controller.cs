using DifferenceStoredProcedureTransactionsCodeApp.InterFaces;
using DifferenceStoredProcedureTransactionsCodeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DifferenceStoredProcedureTransactionsCodeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private DataBaseInterFace _DataBaseInterFace;

        public Warehouses2Controller(DataBaseInterFace dataBaseInterFace)
        {
            _DataBaseInterFace = dataBaseInterFace;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _DataBaseInterFace.AddNewProduct_StoredProcedure(product);
                return Ok("Rekord zostal dodany");
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }  
        }

    }
}
