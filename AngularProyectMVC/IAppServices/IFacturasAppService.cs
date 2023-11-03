using AngularProyectMVC.Models;
using AngularProyectMVC.Models.ModelsDTO;
using BillingProjectMVC.Models.DBModels;

namespace AngularProyectMVC.IAppServices
{
    public interface IFacturasAppService
    {
        IEnumerable<TblFacturas> GetFacturas();
        IEnumerable<TblFacturas> GetFactura(int ?client, int ?bill);
        Task<string> SaveFactura(FacturaModel factura);

        IEnumerable<ClientesDTO> GetClientes();

        IEnumerable<CatProductos> GetProducts();

    }
}
