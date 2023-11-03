using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingProjectMVC.Models.DBModels
{
    public class TblClientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        public string RazonSocial { get; set; }
        [ForeignKey("TipoClienteId")]
        public int TipoClienteId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string RFC { get; set; }
        public virtual CatTipoCliente TipoCliente { get; set; }
    }
}
