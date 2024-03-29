﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Lab03.Entity;

namespace Lab03
{
    class ClsDatos
    {
        //Conexion
        public SqlConnection LeerCadena()
        {
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MFQH1VL\\MSSQLSERVER,1433;Initial Catalog=neptuno;Integrated Security=True");
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-HE6KK6M\\MSSQLSERVER,1433;Initial Catalog=neptuno;Integrated Security=True");
            return connection;
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["neptunoDB"].ConnectionString);

        #region EJERCICIO 01
        public DataTable ListaPedidoFechas(DateTime x, DateTime y)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_FECHAFECHA", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@FEC1", x);
                    da.SelectCommand.Parameters.AddWithValue("@FEC2", y);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ListarDetalle(int x)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_Detalle", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idPedido", x);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public double PedidoTotal(Int32 idpedido)
        {
            SqlConnection conn = LeerCadena();
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_Total", conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    da.SelectCommand.Parameters.Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output;
                    da.SelectCommand.ExecuteScalar();
                    Int32 total = Convert.ToInt32(da.SelectCommand.Parameters["@Total"].Value);

                    return total;
                }
            }
        }
        #endregion

        #region EJERCICIO 02
        public DataTable EJ02_ListaAnios()
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab03_ListaAnios", LeerCadena()))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EJ02_ListaMeses()
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_ListarMeses", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EJ02_ListaEmpleados()
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_ListarEmpleados", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EJ02_ListarClientesPorEmpleado(int Anios, int Meses, int id)
        {
            using(SqlCommand cmd = new SqlCommand("USP_Lab03_ListarClientesPorEmpleado", LeerCadena()))
            {
                using(SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Anios", Anios);
                    da.SelectCommand.Parameters.AddWithValue("@Meses", Meses);
                    da.SelectCommand.Parameters.AddWithValue("@idEmpleado", id);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EJ02_ListarPedidosPorCliente(int Anio, int Mes, int idEmpleado, string idCliente)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_SeleccionarPedidoPorCliente", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Anio", Anio);
                    da.SelectCommand.Parameters.AddWithValue("@Mes", Mes);
                    da.SelectCommand.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    da.SelectCommand.Parameters.AddWithValue("@idCliente", idCliente);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EJ02_ListarProductoPorPedido(int idPedido)
        {
            using (SqlCommand cmd = new SqlCommand("USP_Lab03_DetallesPorProducto", LeerCadena()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@idPedido", idPedido);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion

        #region EJERCICIO 03
        public SqlDataReader EJ03_Listaclientes()
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("USP_Lab03_ListarClientes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return dr;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public List<ECliente> EJ03_ListarClientes()
        {
            using (conn)
            {
                List<ECliente> Lista = new List<ECliente>();
                ECliente cliente;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_Lab03_ListarClientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cliente = new ECliente();
                            cliente.idCliente = (string)(dr[0]);
                            cliente.NombreCompañia = (string)(dr[1]);
                            cliente.Pais = (string)(dr[2]);
                            cliente.Telefono = (string)(dr[3]);
                            Lista.Add(cliente);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.Write(e.Message);
                }
                return Lista;
            }
        }

        public List<EEmpleado> EJ03_ListarEmpleado()
        {
            using (conn)
            {
                List<EEmpleado> Lista = new List<EEmpleado>();
                EEmpleado empleado;
                SqlDataReader dr;
                try
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand("USP_Lab03_ListarEmpleados02", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            empleado = new EEmpleado();
                            empleado.IdEmpleado = (int)(dr[0]);
                            empleado.Apellidos = (string)(dr[1]);
                            empleado.Nombre = (string)(dr[2]);
                            empleado.FechaNacimiento = (DateTime)(dr[3]);
                            empleado.direccion = (string)(dr[4]);
                            Lista.Add(empleado);
                        }
                    }
                }
                catch(Exception e)
                {
                    System.Console.Write(e.Message);
                }
                return Lista;
            }
        }
        #endregion


    }
}
