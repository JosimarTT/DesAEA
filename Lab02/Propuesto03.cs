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
    public partial class Propuesto03 : Form
    {
        public Propuesto03()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ListarAnios()
        {
            using (SqlCommand cmd = new SqlCommand("USP_ListaAnios", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbAnio.DataSource = dt;
                    cbAnio.ValueMember = "Anios";
                    cbAnio.DisplayMember = "Anios";
                }
            }
        }

        public void ListarMesesPorAnio()
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab02_SeleccionarMesPorAnio", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@anio", (int)cbAnio.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbMes.DataSource = dt;
                    cbMes.ValueMember = "Mes";
                    cbMes.DisplayMember = "Mes";
                }
            }
        }

        public void ListarPedidos()
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab02_SeleccionarPedidosPorMesAnio", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@anio", (int)cbAnio.SelectedValue);
                    da.SelectCommand.Parameters.AddWithValue("@mes", (int)cbMes.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgPedidos.DataSource = dt;
                }
            }
        }
        private void Propuesto03_Load(object sender, EventArgs e)
        {
            ListarAnios();
        }

        private void cbAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarMesesPorAnio();
        }

        private void cbMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarPedidos();
        }
    }
}
