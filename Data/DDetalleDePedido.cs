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
    public class DDetalleDePedido
    {
        public List<EDetalleDePedido> GetEDetalleDePedidos (EDetalleDePedido eDetalleDePedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<EDetalleDePedido> detalleDePedido = null;
            try
            {
                commandText = "USP_Lab04_DetallesPorPedido";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", SqlDbType.Int);
                parameters[0].Value = eDetalleDePedido.EPedido.IdPedido;
                detalleDePedido = new List<EDetalleDePedido>();

                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (dr.Read())
                    {
                        detalleDePedido.Add(new EDetalleDePedido
                        {
                            idpedido = dr["idpedido"] != null ? Convert.ToInt32(dr["idpedido"]) : 0,
                            idproducto = dr["idproducto"] != null ? Convert.ToInt32(dr["idproducto"]) : 0,
                            preciounidad = dr["preciounidad"] != null ? Convert.ToDecimal(dr["preciounidad"]) : 0,
                            cantidad = dr["cantidad"] != null ? Convert.ToInt32(dr["cantidad"]) : 0,
                            descuento = dr["descuento"] != null ? Convert.ToDecimal(dr["descuento"]) : 0
                        });
                    }
                }

            }
            catch(Exception e)
            {
                throw e;
            }
            return detalleDePedido;
        }
    }
}
