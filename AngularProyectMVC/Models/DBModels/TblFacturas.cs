using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingProjectMVC.Models.DBModels
{
    public class TblFacturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacturaId { get; set; }
        public DateTime FechaEmisionFactura { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public int NumeroFactura { get; set; }
        public int NumeroTotalArticulos { get; set; }
        public double SubtotalFactura { get; set; }
        public double TotalImpuesto { get; set; }
        public double TotalFactura { get; set; }
        public virtual TblClientes Cliente { get; set; }    
    }

}
