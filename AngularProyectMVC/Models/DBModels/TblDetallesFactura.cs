using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingProjectMVC.Models.DBModels
{
    public class TblDetallesFactura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleFacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public int FacturaId { get; set; }
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioUnitarioProducto { get; set; }
        public double SubtotalProcuto { get; set; }
        public string Notas { get; set; }
        public virtual TblFacturas Factura { get; set; }    
        public virtual CatProductos Producto { get; set; }
    }
}
