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
using Entity;
using Lab06.ViewModel;

namespace Lab06.View
{
    /// <summary>
    /// Interaction logic for ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel ViewModel;

        public ListaCategoria()
        {
            InitializeComponent();
            ViewModel = new ListaCategoriaViewModel();
            this.DataContext = ViewModel;
        }
    }
}
