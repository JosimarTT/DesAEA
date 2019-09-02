using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for Ejercicio01.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClsDatos obj = new ClsDatos();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idpedido;
            var item = dgvPedido.SelectedItem as DataRowView;
            if (item == null) return;
            idpedido = Convert.ToInt32(item.Row["idPedido"]);
            dgvDetallePedido.ItemsSource = obj.ListarDetalle(idpedido).DefaultView;
            txtTotal.Text = Convert.ToString(obj.PedidoTotal(idpedido));
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            dgvPedido.ItemsSource = obj.ListaPedidoFechas(
                Convert.ToDateTime(txtFechaInicio.Text),
                Convert.ToDateTime(txtFechaFin.Text)).DefaultView;
        }
    }
}
