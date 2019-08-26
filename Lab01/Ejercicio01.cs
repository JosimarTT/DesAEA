using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Ejercicio01 : Form
    {
        public Ejercicio01()
        {
            InitializeComponent();
        }

        private void Ejercicio01_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'neptunoDataSet.clientes' table. You can move, or remove it, as needed.
            this.clientesTableAdapter.Fill(this.neptunoDataSet.clientes);
            lblTotal.Text = dgClientes.RowCount.ToString();

        }
    }
}