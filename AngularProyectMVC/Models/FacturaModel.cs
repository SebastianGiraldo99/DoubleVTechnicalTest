namespace AngularProyectMVC.Models
{
    public class FacturaModel
    {
        public DateTime FechaEmisionFactura { get; set; }
        public int ClienteId { get; set; }
        public int NumeroFactura { get; set; }
        public int NumeroTotalArticulos { get; set; }
        public double SubtotalFactura { get; set; }
        public double TotalImpuesto { get; set; }
        public double TotalFactura { get; set; }

        public List<DetallesFactura> DetallesFactura { get; set; }


    }
}
