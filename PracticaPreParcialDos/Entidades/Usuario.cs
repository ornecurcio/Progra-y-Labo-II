﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
   
   public delegate void InvocarToSring(Usuario sender, EventArgs e);

   public class Usuario : ISerializarJson
    {

        int id;
        string nombre;
        int edad;

        private static SqlConnection connection;
        private static SqlCommand command;
        private static string connectionString;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }

        public event InvocarToSring ToStringInvocado;

        public Usuario()
        {

        }

        public Usuario(int id, string nombre, int edad): this(nombre, edad)
        {
            this.id = id;

        }


        public Usuario(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        static Usuario()
        {
            command = new SqlCommand();
            connectionString = "Server = .; Database=bd-modelo-sp ; Trusted_Connection=true";
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }


        public static List<Usuario> ReadAll()
        {

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM usuario";
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    usuarios.Add(new Usuario((int)sqlDataReader["id"],
                                              sqlDataReader["nombre"].ToString(),
                                              (int) sqlDataReader["edad"]));
                }

                sqlDataReader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();

            }

            return usuarios;
        }

        public static void Create(Usuario usuario)
        {

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "INSERT INTO usuario (nombre, edad) VALUES (@nombre, @edad)";
                command.Parameters.AddWithValue("@nombre", usuario.nombre);
                command.Parameters.AddWithValue("@edad", usuario.edad);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();
            }

        }

         public static void Delete(int id)
        {

            try
            {
                command.Parameters.Clear(); 
                connection.Open();
                command.CommandText = $"DELETE FROM usuario WHERE id = {id}";
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();
            }

        }
        public static void Update(Usuario usuario)
        {

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE  usuario SET nombre = @nombre, edad= @edad WHERE id = {usuario.Id}";
                command.Parameters.AddWithValue("@nombre", usuario.nombre);
                command.Parameters.AddWithValue("@edad", usuario.edad);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();
            }

        }



        public override string ToString()
        {
           //this.ToStringInvocado.Invoke(this, EventArgs.Empty);
            this.ToStringInvocado(this, EventArgs.Empty);
            return "Id: " + this.id + " nombre: " + this.nombre +  " edad: " + this.edad; 
        }

        public bool Serializar(string path)
        {
            bool retorno = false;

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string json = JsonSerializer.Serialize(this);
                streamWriter.Write(json);
                retorno = true;
            }
            return retorno;
        }

        public bool Deserializar(string path, out Usuario datos)
        {
            bool retorno = false;

            using (StreamReader streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                datos = JsonSerializer.Deserialize<Usuario>(json);
                retorno = true;
            }
            return retorno;
        }

        public void RecuperarInfo(string rutaArchivo3)
        {
            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo3))
                {
                    String linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

//9.- DiseÃ±ar un mÃ©todo que, en segundo plano,
//    recupere toda la informaciÃ³n del archivo (*.log) del punto 7 y lo muestre.