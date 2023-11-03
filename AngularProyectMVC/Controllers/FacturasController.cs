using AngularProyectMVC.IAppServices;
using AngularProyectMVC.Models;
using AngularProyectMVC.Models.ModelsDTO;
using BillingProjectMVC.Models.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularProyectMVC.Controllers
{
    
    [ApiController]
    [Route("weatherforecast")]
    public class FacturasController : ControllerBase
    {

        private readonly IFacturasAppService _service;
        public FacturasController(IFacturasAppService service)
        {
            _service = service;
        }

        [HttpGet("GetFacturas")]
        public IEnumerable<TblFacturas> GetFacturas()
        {
            return _service.GetFacturas();
        }

        [HttpGet("GetFactura")]
        public IEnumerable<TblFacturas> GetFactura(int client, int bill)
        {
            // Obtener factura por ID o por Cliente.
            return _service.GetFactura(client, bill);
        }

        [HttpPost("SaveFactura")]
        public string SaveFactura(FacturaModel factura)
        {
            return _service.SaveFactura(factura).Result;
        }

        [HttpGet("GetClientes")]
        public IEnumerable<ClientesDTO> GetClientes()
        {
            return _service.GetClientes();
        }
        [HttpGet("GetProducts")]
        public IEnumerable<CatProductos> GetProductos()
        {
            return _service.GetProducts();
        }





    }
}
