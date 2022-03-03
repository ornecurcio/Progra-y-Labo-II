using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Entidades
{
    ///Crear, en EntidadesSP, la clase ADO.
    ///Dicha clase se deberá comunicar con la base de datos, tendrá:
    ///Métodos de clase:
    ///ObtenerTodos() : List<Producto>
    ///ObtenerTodos(string) : List<Producto> -> se obtienen por marca 
    ///de acuerdo al parámetro recibido
    ///Métodos de instancia:
    ///Agregar(Producto) : bool
    ///Modificar(Producto) : bool -> se modifica a partir del código
    ///Eliminar(Pr
    ///oducto) : bool -> se elimina a partir del código
    ///
    public delegate void DelegadoMarcaExiste(object sender, EventArgs e); 
    public class AccesoDatos
    {
        #region Atributos

        private static string cadena_conexion;
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        public event DelegadoMarcaExiste MarcaExistente;

        #endregion

        #region Constructores

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = @"Server=localhost\SQLEXPRESS;Database=almacen_db;Trusted_Connection=True;";
            // CREO UN OBJETO SQLCONECTION
            AccesoDatos.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        //public AccesoDatos()
        //{
        //    // CREO UN OBJETO SQLCONECTION
        //    conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        //}

        #endregion

        #region Métodos

        #region Probar conexión

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        #endregion

        #region Select

        public static List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                comando = new SqlCommand();

                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM dbo.productos";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto item = new Producto();

                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    item.Marca = lector["marca"].ToString();
                    item.Tipo = lector["tipo"].ToString();
                    item.Codigo = lector.GetInt32("codigo"); 
                    item.Precio = double.Parse(lector["precio"].ToString());

                    lista.Add(item);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return lista;
        }
        public static List<Producto> ObtenerTodos(string marca)
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                comando = new SqlCommand();
                comando.Parameters.AddWithValue("@marca", marca);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM dbo.productos WHERE marca = @marca";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto item = new Producto();

                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    item.Marca = lector["marca"].ToString();
                    item.Tipo = lector["tipo"].ToString();
                    item.Codigo = lector.GetInt32("codigo");
                    item.Precio = double.Parse(lector["precio"].ToString());

                    lista.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return lista;
        }

        #endregion

        #region Insert

        public bool Agregar(Producto param)
        {
            bool rta = true;
            try
            {
                //sql += "WHERE codigo = @codigo";
                //string sql = ;
                //sql = sql + "'" + param.Marca + "','" + param.Tipo + "'," + param.Codigo.ToString() + "," + param.Precio.ToString() + ")";

                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@marca", param.Marca);
                comando.Parameters.AddWithValue("@tipo", param.Tipo);
                comando.Parameters.AddWithValue("@codigo", param.Codigo);
                comando.Parameters.AddWithValue("@precio", param.Precio);

                string sql = "INSERT INTO dbo.productos " +
                             "VALUES(@marca,@tipo,@codigo,@precio)";
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
               
            }
            catch (Exception ex)
            {
                rta = false;
                Console.WriteLine(ex.Message); 
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
                List<Producto> prodXMarca = AccesoDatos.ObtenerTodos(param.Marca);
                if (prodXMarca is not null && prodXMarca.Count > 1)
                {
                    MarcaExistente.Invoke(prodXMarca, EventArgs.Empty);
                }
                //TODO evento
                // agregar comun, luego, obtenertodomarca(param.marca)
                //if(lista.count>1 && !NULL)---> aca se dispara el evento. ((casteo)lista de las marcas, evenarg.empty)
            }

            return rta;
        }

        #endregion

        #region Update

        public bool Modificar(Producto param)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@marca", param.Marca);
                comando.Parameters.AddWithValue("@tipo", param.Tipo);
                comando.Parameters.AddWithValue("@codigo", param.Codigo);
                comando.Parameters.AddWithValue("@precio", param.Precio);

                string sql = "UPDATE dbo.productos ";
                sql += "SET marca = @marca, tipo = @tipo, precio = @precio ";
                sql += "WHERE codigo = @codigo";

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return rta;
        }

        #endregion

        #region Delete

        public bool Eliminar(int codigo)
        {
            bool rta = true;

            try
            {
                comando = new SqlCommand();

                comando.Parameters.AddWithValue("@codigo", codigo);

                string sql = "DELETE FROM dbo.productos ";
                sql += "WHERE codigo = @codigo";

                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return rta;
        }

        #endregion

        #endregion
    }
}

