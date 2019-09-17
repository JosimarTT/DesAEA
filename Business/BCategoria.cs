using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<ECategoria> Listar(int idCategoria)
        {
            List<ECategoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new ECategoria { IdCategoria = idCategoria });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        public bool Insertar(ECategoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(ECategoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}