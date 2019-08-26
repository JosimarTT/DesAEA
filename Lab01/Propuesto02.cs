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
    public partial class Propuesto02 : Form
    {
        public Propuesto02()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ListarPedidos(string idCliente)
        {
            using(SqlDataAdapter da = new SqlDataAdapter("USP_ReportePedidosPorCliente", connection))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@idCliente",
                    Value = idCliente,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 5
                });
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgReporte.DataSource = dt;
                lblTotal.Text = dt.Rows.Count.ToString();
            }
        }

        public void ListarClientes()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("USP_ClientesAll", connection))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbCliente.DataSource = dt;
                cbCliente.ValueMember = "idCliente";
                cbCliente.DisplayMember = "NombreCompañia";
            }
        }

        private void Propuesto02_Load(object sender, EventArgs e)
        {
            ListarPedidos("");
            ListarClientes();
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListarPedidos(cbCliente.SelectedValue.ToString());
        }
    }
}
