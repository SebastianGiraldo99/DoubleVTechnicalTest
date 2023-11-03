using AngularProyectMVC.IAppServices;
using AngularProyectMVC.IDomainService;
using AngularProyectMVC.Models;
using AngularProyectMVC.Models.ModelsDTO;
using BillingProjectMVC.Models.DBModels;

namespace AngularProyectMVC.AppServices
{
    public class FacturasAppService : IFacturasAppService
    {
        private readonly IFacturaDomainService _service;
        //Agregar el Mapper
        public FacturasAppService(IFacturaDomainService service)
        {
            _service = service;
        }
        public IEnumerable<TblFacturas> GetFactura(int ?client, int ?bill)
        {

            return _service.GetFactura(client, bill);
        }

        public IEnumerable<TblFacturas> GetFacturas()
        {
            return _service.GetFacturas();
        }

        public Task<string> SaveFactura(FacturaModel factura)
        {
            return _service.SaveFactura(factura);
        }
        public IEnumerable<ClientesDTO> GetClientes()
        {
            return _service.GetClientes();
        }

        public IEnumerable<CatProductos> GetProducts()
        {
            return _service.GetProducts();
        }
    }
}
