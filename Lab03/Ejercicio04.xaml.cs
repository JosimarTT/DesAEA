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
using System.Windows.Shapes;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for Ejercicio04.xaml
    /// </summary>
    public partial class Ejercicio04 : Window
    {
        ClsDatos datos = new ClsDatos();

        public Ejercicio04()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEmpleados.ItemsSource = datos.EJ03_ListarEmpleado();
        }
    }
}
