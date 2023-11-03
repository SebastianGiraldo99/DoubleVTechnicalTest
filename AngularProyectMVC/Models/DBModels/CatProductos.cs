using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingProjectMVC.Models.DBModels
{
    public class CatProductos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string NombreProducto { get; set; }
        public string ImagenProduct { get; set; }
        public double PrecioUnitario { get; set; }
        public int  Ext { get; set; }
    }
}
