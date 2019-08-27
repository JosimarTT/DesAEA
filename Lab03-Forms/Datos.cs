using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab03_Forms
{
    class Datos
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-HE6KK6M\\MSSQLSERVER,1433;Initial Catalog=neptuno;Integrated Security=True");
            return connection;
        }

        public SqlDataReader ListaClientes()
        {
            SqlConnection cn = LeerCadena();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("USP_Lab03_ListarClientes");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
