using AngularProyectMVC.Models.ModelsDTO;
using AngularProyectMVC.Models;
using BillingProjectMVC.Models.DBModels;

namespace AngularProyectMVC.IDomainService
{
    public interface IFacturaDomainService
    {
        IEnumerable<TblFacturas> GetFacturas();
        IEnumerable<TblFacturas> GetFactura(int? client, int? bill);
        Task<string> SaveFactura(FacturaModel factura);
        IEnumerable<ClientesDTO> GetClientes();
        IEnumerable<CatProductos> GetProducts();
    }
}
