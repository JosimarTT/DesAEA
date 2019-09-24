using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab06.Model;

namespace Lab06.ViewModel
{
    class ManCategoriaViewModel : ViewModelBase
    {
        #region Propiedades
        int _ID;

        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (_Nombre != value)
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (_Descripcion != value)
                {
                    _Descripcion = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public ICommand GrabarCommand { get; set; }
        public ICommand Cerrarcommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public ManCategoriaViewModel()
        {
            GrabarCommand = new RelayCommand<Window>(
                o =>
                {
                    if (ID > 0)
                        new CategoriaModel().Actualizar(new Entity.ECategoria
                        {
                            IdCategoria = ID,
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                    else
                        new CategoriaModel().Insertar(new Entity.ECategoria
                        {
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });

                    o.Close();
                });
                

            Cerrarcommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );
        }

        void Cerrar(Window window)
        {
            if (window != null)
            {
                window.Close();
            }

            //View.ListaCategoria window2 = new View.ListaCategoria();
            //window2.ShowDialog();
        }
    }
}
