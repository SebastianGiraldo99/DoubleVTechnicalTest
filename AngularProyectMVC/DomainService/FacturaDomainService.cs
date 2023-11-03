using AngularProyectMVC.IDomainService;
using AngularProyectMVC.Models;
using AngularProyectMVC.Models.ModelsDTO;
using BillingProjectMVC.Models.DBModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AngularProyectMVC.DomainService
{
    public class FacturaDomainService : IFacturaDomainService
    {
        private readonly IConfiguration _configuration;
        public FacturaDomainService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DevLab");
        }
        public IEnumerable<TblFacturas> GetFactura(int? client, int? bill)
        {
            string connectionString = GetConnectionString();
            List<TblFacturas> facturas = new List<TblFacturas>();
            try
            {
                if (client == 0 && bill == 0)
                {
                    throw new ArgumentNullException(nameof(client));
                }

                string query = "SELECT * FROM TblFacturas WHERE ";

                if (bill > 0)
                {
                    query += $"NumeroFactura = {bill}";
                }

                if (client > 0)
                {
                    query += $"ClienteId = {client}";
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TblFacturas factura = new TblFacturas
                                {
                                    FacturaId = reader.GetInt32(0),
                                    FechaEmisionFactura = reader.GetDateTime(1),
                                    ClienteId = reader.GetInt32(2),
                                    NumeroFactura = reader.GetInt32(3),
                                    NumeroTotalArticulos = reader.GetInt32(4),
                                    SubtotalFactura = reader.GetDouble(5),
                                    TotalImpuesto = reader.GetDouble(6),
                                    TotalFactura = reader.GetDouble(7)
                                };

                                facturas.Add(factura);
                            }
                        }
                    }
                }
                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<TblFacturas> GetFacturas()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveFactura(FacturaModel factura)
        {
            string connectionString = GetConnectionString();
            try
            {
               var save = await SaveTblFactura(factura, connectionString);
                if (save)
                {
                    int idFactura = GetFactura(null, factura.NumeroFactura).First().FacturaId;
                    SaveTblDetallesFactura(factura.DetallesFactura, connectionString, idFactura);
                }
                
                return "Guardado con exito";
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            



        }
        public async Task<bool>SaveTblFactura(FacturaModel factura, string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertTableFactura", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FechaEmisionFactura", factura.FechaEmisionFactura);
                        command.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                        command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                        command.Parameters.AddWithValue("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
                        command.Parameters.AddWithValue("@SubtotalFactura", factura.SubtotalFactura);
                        command.Parameters.AddWithValue("@TotalImpuesto", factura.TotalImpuesto);
                        command.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);

                        command.ExecuteNonQuery();
                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool SaveTblDetallesFactura(List<DetallesFactura> detFactura, string connectionString, int idFactura)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertTablaDetalleFactura", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramFacturaId = command.Parameters.Add("@FacturaId", SqlDbType.Int);
                        SqlParameter paramProductoId = command.Parameters.Add("@ProductoId", SqlDbType.Int);
                        SqlParameter paramCantidadProducto = command.Parameters.Add("@CantidadProducto", SqlDbType.Int);
                        SqlParameter paramPrecioUnitarioProducto = command.Parameters.Add("@PrecioUnitarioProducto", SqlDbType.Decimal);
                        SqlParameter paramSubTotalProducto = command.Parameters.Add("@SubTotalProducto", SqlDbType.Decimal);
                        SqlParameter paramNotas = command.Parameters.Add("@Notas", SqlDbType.NVarChar);
                        foreach (var factura in detFactura)
                        {
                            paramFacturaId.Value = idFactura;
                            paramProductoId.Value = factura.ProductoId;
                            paramCantidadProducto.Value = factura.cantidad;
                            paramPrecioUnitarioProducto.Value = factura.precioUnitario;
                            paramSubTotalProducto.Value = factura.subtotalP;
                            paramNotas.Value = factura.Notas;

                            command.ExecuteNonQuery();
                        }

                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IEnumerable<ClientesDTO> GetClientes()
        {
            List<ClientesDTO> clientes = new List<ClientesDTO>();
            string connectionString = GetConnectionString();
            string query = "SELECT * FROM TblClientes";
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                ClientesDTO cliente = new ClientesDTO
                                {
                                    ClienteId = reader.GetInt32(0),
                                    NombreCliente = reader.GetString(1) 
                                };
                                clientes.Add(cliente);
                            }
                            
                        }
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            throw new NotImplementedException();
        }

        public IEnumerable<CatProductos> GetProducts()
        {
            List<CatProductos> productos = new List<CatProductos>();
            string connectionString = GetConnectionString();
            string query = "SELECT * FROM CatProductos WHERE Ext > 0";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CatProductos catProductos = new CatProductos
                                {
                                    ProductId = reader.GetInt32(0),
                                    NombreProducto = reader.GetString(1),
                                    ImagenProduct = reader.GetString(2),
                                    PrecioUnitario = reader.GetDouble(3),
                                    Ext = reader.GetInt32(4),
                                };
                                productos.Add(catProductos);
                            }

                        }
                    }
                }
                return productos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
