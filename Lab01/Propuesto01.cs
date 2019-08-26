using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab01
{
    public partial class Propuesto01 : Form
    {
        public Propuesto01()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ListadoClientes(string cliente)
        {
            using(SqlDataAdapter da = new SqlDataAdapter("USP_ListarClientePorIniciales", connection))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@idCliente",
                    Value = tbCliente.Text,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 5
                });
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgCliente.DataSource = dt;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
        }

        private void tbCliente_TextChanged(object sender, EventArgs e)
        {
            ListadoClientes(tbCliente.Text);
        }

        private void Propuesto01_Load(object sender, EventArgs e)
        {
            ListadoClientes("");
        }
    }
}