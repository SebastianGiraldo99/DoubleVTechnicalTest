using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingProjectMVC.Models.DBModels
{
    public class CatTipoCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoClienteId { get; set; }
        public string TipoCliente { get; set; }
    }
}
