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
    public partial class Propuesto02 : Form
    {
        public Propuesto02()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ObtenerPedidos()
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab02_CargarPedidos", connection))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgPedidos.DataSource = dt;
                    lblPedidos.Text = dt.Rows.Count.ToString();
                }
            }
        }
        public void ObtenerDetallesPorPedido()
        {
            int codigo;
            codigo = Convert.ToInt32(dgPedidos.CurrentRow.Cells[0].Value);
            using (SqlCommand cmd = new SqlCommand("USP_Lab02_CargarDetallesProductoPorPedido", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idPedido", codigo);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgDetalles.DataSource = dt;
                    lblProductos.Text = dt.Rows.Count.ToString();
                }
            }
        }

        private void Propuesto02_Load(object sender, EventArgs e)
        {
            ObtenerPedidos();
        }

        private void dgPedidos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ObtenerDetallesPorPedido();
        }
    }
}
