namespace AngularProyectMVC.Models
{
    public class DetallesFactura
    {
        public int ?FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double subtotalP { get; set; }
        public string Notas { get; set; }
    }
}
