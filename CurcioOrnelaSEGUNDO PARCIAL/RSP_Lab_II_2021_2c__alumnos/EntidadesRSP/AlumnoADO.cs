using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    ///AlumnoADO (hereda de Alumno)
    ///Atributos (estáticos)
    ///conexion : string
    ///connection : SqlConnection
    ///command : SqlCommand
    ///Constructor de clase que inicialice todos sus atributos
    ///Constructor que recibe un objeto de tipo Alumno cómo parámetro
    ///Métodos de instancia (públicos):
    ///ObtenerTodos() : List<Alumno> 
    ///Agregar() : bool
    ///Modificar() : bool -> se modifica a partir del dni
    ///Eliminar() : bool -> se elimina a partir del dni
    ///
    ///Utilizando la clase AlumnoADO, obtener y mostrar todos los productos
    ///
    public class AlumnoADO : Alumno
    {
        static string cadena_conexion;
        static SqlConnection conexion;
        static SqlCommand comando;
        
        static AlumnoADO()
        {
            AlumnoADO.cadena_conexion = @"Server=localhost\SQLEXPRESS;Database=utn_fra_alumnos;Trusted_Connection=True;";
            AlumnoADO.conexion = new SqlConnection(AlumnoADO.cadena_conexion);
            AlumnoADO.comando = new SqlCommand(); 
        }
        public AlumnoADO()
        { }
        public AlumnoADO(Alumno alumno) : base(alumno.Apellido, alumno.Nombre, alumno.Dni, alumno.Nota)
        {
        }
        public static List<Alumno> ObtenerTodos()
        {
            List<Alumno> lista = new List<Alumno>();
            SqlDataReader lector;

            try
            {
                comando.Parameters.Clear(); 
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM dbo.alumnos ";
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Alumno item = new Alumno();

                    item.Apellido = lector["apellido"].ToString();
                    item.Nombre = lector["nombre"].ToString();
                    item.Dni = lector.GetInt32("dni");
                    item.Nota = double.Parse(lector["nota"].ToString());

                    lista.Add(item);
                }

                lector.Close();
            }
            catch (Exception)
            {
                throw; 
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
        public bool Agregar(Alumno param)
        {
            bool rta = true;
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@apellido", param.Apellido);
                comando.Parameters.AddWithValue("@nombre", param.Nombre);
                comando.Parameters.AddWithValue("@dni", param.Dni);
                comando.Parameters.AddWithValue("@nota", param.Nota);
                string sql = "INSERT INTO dbo.alumnos " +
                             "VALUES(@dni,@apellido,@nombre,@nota)";
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
            }

            return rta;
        }


        public bool Modificar()
        {
            bool rta = true;

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@apellido", this.Apellido);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@dni", this.Dni);
                comando.Parameters.AddWithValue("@nota", this.Nota);

                string sql = "UPDATE dbo.alumnos ";
                sql += "SET apellido = @apellido, nombre = @nombre, nota = @nota ";
                sql += "WHERE dni = @dni";

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
                Console.WriteLine(ex); 
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

        public bool Eliminar()
        {
            bool rta = true;

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@dni", this.Dni);

                string sql = "DELETE FROM dbo.alumnos ";
                sql += "WHERE dni= @dni";

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

    }
}
