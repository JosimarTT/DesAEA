using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Lab03
{
    class ClsDatos
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-HE6KK6M\\MSSQLSERVER,1433;Initial Catalog=neptuno;Integrated Security=True");
            return connection;
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);


        public DataTable ListaPedidoFechas(DateTime x, DateTime y)
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab03_FECHAFECHA", LeerCadena()))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@FEC1", x);
                    da.SelectCommand.Parameters.AddWithValue("@FEC2", y);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ListarDetalle(int x)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_Detalle", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idPedido", x);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public double PedidoTotal(Int32 idpedido)
        {
            SqlConnection conn = LeerCadena();
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_Total", conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                   
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    da.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output;
                    da.SelectCommand.ExecuteScalar();
                    Int32 total = Convert.ToInt32(da.SelectCommand.Parameters["@Total"].Value);
                    
                    return total;
                }
            }
        }
    }
}
