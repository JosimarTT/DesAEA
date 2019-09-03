using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DPedido
    {
        public List<EPedido> GetEPedidos(EPedido pedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<EPedido> pedidos = null;

            try
            {
                commandText = "USP_Lab03_FECHAFECHA";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@fec1", SqlDbType.DateTime);
                parameters[0].Value = pedido.FechaInicio;
                parameters[1] = new SqlParameter("@fec2", SqlDbType.DateTime);
                parameters[1].Value = pedido.FechaFin;
                pedidos = new List<EPedido>();

                using(SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, "USP_Lab03_FECHAFECHA",
                    CommandType.StoredProcedure, parameters))
                {
                    while (dr.Read())
                    {
                        pedidos.Add(new EPedido
                        {
                            IdPedido = dr["IdPedido"] != null ? Convert.ToInt32(dr["IdPedido"]) : 0,
                            IdCliente = dr["IdCliente"] != null ? Convert.ToString(dr["IdCliente"]) : string.Empty,
                            IdEmpleado = dr["IdEmpleado"] != null ? Convert.ToInt32(dr["IdEmpleado"]) : 0,
                            FechaPedido = dr["FechaPedido"] != DBNull.Value ? Convert.ToDateTime(dr["FechaPedido"]) : DateTime.MinValue,
                            FechaEntrega = dr["FechaEntrega"] != DBNull.Value ? Convert.ToDateTime(dr["FechaEntrega"]) : DateTime.MinValue,
                            FechaEnvio = dr["FechaEnvio"] != DBNull.Value ? Convert.ToDateTime(dr["FechaEnvio"]) : DateTime.MinValue,
                            FormaEnvio = dr["FormaEnvio"] != null ? Convert.ToInt32(dr["FormaEnvio"]) : 0,
                            Cargo = dr["Cargo"] != null ? Convert.ToInt32(dr["Cargo"]) : 0,
                            Destinatario = dr["Destinatario"] != null ? Convert.ToString(dr["Destinatario"]) : string.Empty,
                            DireccionDestinatario = dr["DireccionDestinatario"] != null ? Convert.ToString(dr["DireccionDestinatario"]) : string.Empty,
                            RegionDestinatario = dr["RegionDestinatario"] != null ? Convert.ToString(dr["RegionDestinatario"]) : string.Empty,
                            CodPostalDestinatario = dr["CodPostalDestinatario"] != null ? Convert.ToString(dr["CodPostalDestinatario"]) : string.Empty,
                            PaisDestinatario = dr["PaisDestinatario"] != null ? Convert.ToString(dr["PaisDestinatario"]) : string.Empty
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pedidos;
        }
    }
}
