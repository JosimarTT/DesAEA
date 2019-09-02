using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for Ejercicio02.xaml
    /// </summary>
    public partial class Ejercicio02 : Window
    {

        ClsDatos datos = new ClsDatos();

        public Ejercicio02()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbAnios.ItemsSource = datos.EJ02_ListaAnios().DefaultView;
            cbMeses.ItemsSource = datos.EJ02_ListaMeses().DefaultView;
            cbEmpleados.ItemsSource = datos.EJ02_ListaEmpleados().DefaultView;
        }

        private void BtnLista_Click(object sender, RoutedEventArgs e)
        {
            dgCliente.ItemsSource = datos.EJ02_ListarClientesPorEmpleado(
                (int)cbAnios.SelectedValue,
                (int)cbMeses.SelectedValue,
                (int)cbEmpleados.SelectedValue).DefaultView;
        }

        private void DgPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idPedido;
            var item = dgPedido.SelectedItem as DataRowView;
            if (item == null) return;
            idPedido =Convert.ToInt32(item.Row["IdPedido"]);
            dgDetalles.ItemsSource = datos.EJ02_ListarProductoPorPedido(idPedido).DefaultView;
            TotalProductos();
            Monto();
        }

        private void DgCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idCliente;
            var item = dgCliente.SelectedItem as DataRowView;
            if (item == null) return;
            idCliente = item.Row["id"].ToString();

            dgPedido.ItemsSource = datos.EJ02_ListarPedidosPorCliente(
                (int)cbAnios.SelectedValue,
                (int)cbMeses.SelectedValue,
                (int)cbEmpleados.SelectedValue,
                idCliente).DefaultView;
            txtPedidos.Text = dgPedido.Items.Count.ToString();
        }

        private void TotalProductos()
        {
            int sum = 0;
            foreach (DataRowView row in dgDetalles.ItemsSource)
            {
                sum += (int)row["cantidad"];
            }
            txtProductos.Text = sum.ToString();
        }

        private void Monto()
        {
            decimal sum = 0;
            foreach (DataRowView row in dgDetalles.ItemsSource)
            {
                sum += (decimal)row["Monto"];
            }
            txtTotal.Text = sum.ToString();
        }

    }
}
