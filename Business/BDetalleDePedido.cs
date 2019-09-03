using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BDetalleDePedido
    {
        private DDetalleDePedido DDetalleDePedido = null;

        public List<EDetalleDePedido> GetEDetalleDePedidosPorId(int IdPedido)
        {
            List<EDetalleDePedido> detalleDePedidos = null;
            try
            {
                DDetalleDePedido = new DDetalleDePedido();
                detalleDePedidos = DDetalleDePedido.GetEDetalleDePedidos(new EDetalleDePedido { EPedido = new EPedido { IdPedido = IdPedido } });
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                DDetalleDePedido = null;
            }
            return detalleDePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<EDetalleDePedido> DetalleDePedido = null;
            decimal total = 0;
            try
            {
                DDetalleDePedido = new DDetalleDePedido();
                DetalleDePedido = DDetalleDePedido.GetEDetalleDePedidos(new EDetalleDePedido { EPedido = new EPedido() { IdPedido = IdPedido } });

                foreach(var item in DetalleDePedido)
                {
                    total = total + item.cantidad * item.preciounidad - item.descuento;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                DDetalleDePedido = null;
            }
            return total;
        }
    }

    
}
