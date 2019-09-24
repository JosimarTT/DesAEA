using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Lab06.ViewModel
{
    class ListaCategoriaViewModel : ViewModelBase
    {
        public ObservableCollection<ECategoria> _Categorias;
        public ObservableCollection<ECategoria> Categorias {
            get { return _Categorias; }
            set {
                if (_Categorias != value)
                {
                    _Categorias = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }

        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;


            NuevoCommand = new RelayCommand<Window>(
                    Param => Abrir()
                    );

            ConsultarCommand = new RelayCommand<Window>(
                o => { Categorias = new Model.CategoriaModel().Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria();
                window.ShowDialog();

                ConsultarCommand.Execute(window);

            }
        }
    }
}
