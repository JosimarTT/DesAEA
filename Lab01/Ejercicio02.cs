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

namespace Lab01
{
    public partial class Ejercicio02 : Form
    {
        public Ejercicio02()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("Data Source=(local); Initial Catalog = Neptuno; Integrated security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("SELECT * FROM Clientes", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Clientes");
                    dgClientes.DataSource = Da.Tables["Clientes"];
                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }
        }

        private void Ejercicio02_Load(object sender, EventArgs e)
        {
            ListaClientes();
        }
    }
}
