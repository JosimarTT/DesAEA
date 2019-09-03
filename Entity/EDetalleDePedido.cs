using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EDetalleDePedido
    {
        public int idpedido { get; set; }
        public int idproducto { get; set; }
        public decimal preciounidad { get; set; }
        public int cantidad { get; set; }
        public decimal descuento { get; set; }

        public EPedido EPedido { get; set; }
    }
}
