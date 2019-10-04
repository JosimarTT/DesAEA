using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    class Program
    {
        public static DataClassesDataContext context = new DataClassesDataContext();

        static void Main(string[] args)
        {
            var Pedidos = context.Pedidos.ToList();
            var Clientes = context.clientes.ToList();
            var DetallePedidos = context.detallesdepedidos.ToList();
            var Proveedores = context.proveedores.ToList();

            MoreThanTwoPedidos(Pedidos);
            Console.Read();
        }

        static void IntroToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach(int num in numQuery)
            {
                Console.WriteLine("{0,1}", num);
            }
        }

        static void DataSource(List<cliente> clientes)
        {
            var queryAllCustomers = from cust in clientes
                                    select cust;

            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Filtering()
        {
            var queryLondonCustomers = from cust in context.clientes
                                       where cust.Ciudad == "Londres"
                                       select cust;
            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.NombreCompañia + " - " + item.Ciudad);
            }
        }

        static void Ordering()
        {
            var queryLondonCustomers3 =
                from cust in context.clientes
                where cust.Ciudad == "Londres"
                orderby cust.NombreCompañia ascending
                select cust;

            foreach(var item in queryLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Grouping()
        {
            var queryCustomersByCity =
                from cust in context.clientes
                group cust by cust.Ciudad;

            foreach(var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach(cliente customer in customerGroup)
                {
                    Console.WriteLine("    {0}", customer.NombreCompañia);
                }
            }
        }

        static void Grouping2()
        {
            var custQuery =
                from cust in context.clientes
                group cust by cust.Ciudad into custGroup
                where custGroup.Count() > 2
                orderby custGroup.Key
                select custGroup;

            foreach(var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Joining()
        {
            var innerJoinQuery =
                from cust in context.clientes
                join dist in context.Pedidos on cust.idCliente equals dist.IdCliente
                select new { CustomerName = cust.NombreCompañia, DistributorName = dist.PaisDestinatario };
            
            foreach(var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }

        //1. Todos los pedidos de los últimos 5 años
        static void LastFiveYears(List<Pedido> pedidos)
        {
            var lastFiveYears =
                from ped in pedidos
                where Convert.ToDateTime(ped.FechaPedido).Year > Convert.ToDateTime("05/05/1995").Year
                select ped;

            foreach(var item in lastFiveYears)
            {
                Console.WriteLine(item.IdPedido+"   "+item.Destinatario);
            }
        }

        //2. Todos los clientes que tengan más de 2 pedidos
        static void MoreThanTwoPedidos(List<Pedido> pedidos)
        {
            var moreThanTwo =
                from ped in pedidos
                group ped by ped.IdCliente into grp
                where grp.Count() > 2
                orderby grp.Key
                select grp;

            foreach(var item in moreThanTwo)
            {
                Console.WriteLine(item.Key);
            }
        }

        //3. Todos los pedidos donde el precio*cantidad>200
        static void AmmountGreaterThan(List<detallesdepedido> detPedidos)
        {
            var monto =
                from det in detPedidos
                group det by det.idpedido into grp
                select new
                {
                    idpedido = grp.Key,
                    monto = grp.Sum(m => (m.cantidad * m.preciounidad))
                };

            foreach (var item in monto)
            {
                Console.WriteLine("pedidoID: " + item.idpedido +" - " + "Monto: " + item.monto);
            }

        }

        //4. Todos los proveedores que tengan más de 2 productos
        static void MoreThanTwoProductos(List<proveedore> proveedores)
           
        {
            var provs = proveedores.Where(prov => prov.productos.Count() > 2);
            foreach(var items in provs)
            {
                Console.WriteLine(items.idProveedor + " - " + items.nombreCompañia);
            };
        }

        //5. Todos los productos que esten en más de 3 pedidos.
        static void MoreThanThreePedidos(List<detallesdepedido> detPedidos, List<producto> productos)
        {
            //var prods = 
            //    from ped in detPedidos
            //    join prod in productos on ped.idproducto equals prod.idproducto
        }

        //6. Lista de empleados que coincidan en el codigo postal con los clientes.
        //7. Lista de ciudades que tengan al menos un cliente, empleado o proveedor
        //8. Todas las compañias que tengan al menos un empleado que gane más de 1000
        
    }
}
