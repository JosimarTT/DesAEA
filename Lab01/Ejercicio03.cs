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
    public partial class Ejercicio03 : Form
    {
        public Ejercicio03()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        public void ListaProductos()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("USP_ListaProductos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using(DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Productos");
                    dgProductos.DataSource = Da.Tables["Productos"];
                    lblTotal.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void Ejercicio03_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
