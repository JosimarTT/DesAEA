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
    public partial class Ejercicio01 : Form
    {
        public Ejercicio01()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ListaAnios()
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
                    cbAnio.DisplayMember = "Anios";
                    cbAnio.ValueMember = "Anios";
                }
            }
        }

        private void Ejercicio01_Load(object sender, EventArgs e)
        {
            ListaAnios();
        }

        private void cbAnio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lista_Pedidos_Anios", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@anio", cbAnio.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgPedidos.DataSource = dt;
                    lblPedidos.Text = dt.Rows.Count.ToString();
                }
            }
        }

        private void dgPedidos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int codigo;
            codigo = Convert.ToInt32(dgPedidos.CurrentRow.Cells[0].Value);
            using (SqlCommand cmd = new SqlCommand("USP_Detalle_Pedido", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idpedido", codigo);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgDetalles.DataSource = dt;
                    lblMonto.Text = dt.Compute("Sum(Monto)", "").ToString();
                }
            }
        }
    }
}
