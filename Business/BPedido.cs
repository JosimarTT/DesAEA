using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BPedido
    {
        private DPedido DPedido = null;
        public List<EPedido> GetPedidosEntreFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            List<EPedido> pedidos = null;
            try
            {
                DPedido = new DPedido();
                pedidos = DPedido.GetEPedidos(new EPedido { FechaInicio = FechaInicio, FechaFin = FechaFin });
            }
            catch(Exception e)
            {
                throw e;
            }
            return pedidos;
        }
    }
}
