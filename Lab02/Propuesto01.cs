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

namespace Lab02
{
    public partial class Propuesto01 : Form
    {
        public Propuesto01()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void CargarEmpleados()
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab02_CargarEmpleados", connection))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbEmpleado.DataSource = dt;
                    cbEmpleado.DisplayMember = "Empleado";
                    cbEmpleado.ValueMember = "IdEmpleado";
                }
            }
        }

        public void CargarPedidosPorEmpleado()
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab02_CargarPedidosPorEmpleado", connection))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idEmpleado", (int)cbEmpleado.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgPedidos.DataSource = dt;
                    lblPedidos.Text = dt.Rows.Count.ToString();
                }
            }
        }

        private void Propuesto01_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void cbEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarPedidosPorEmpleado();
        }
    }
}
