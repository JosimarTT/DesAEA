﻿using System;
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
using System.Data;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for Ejercicio03.xaml
    /// </summary>
    public partial class Ejercicio03 : Window
    {
        ClsDatos datos = new ClsDatos();

        public Ejercicio03()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Load(datos.EJ03_Listaclientes());
            //dgCliente.ItemsSource = dt.DefaultView;

            dgCliente.ItemsSource = datos.EJ03_ListarClientes();
            
        }
    }
}
