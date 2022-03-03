using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Entidades
{
    public class SerializacionAJason 
    {
        /// <summary>
        /// Genera un path donde se puede guardar un archivo
        /// </summary>
        /// <param name="titulo">que tiene el archivo</param>
        /// <returns>path donde se encuentra el archivo</returns>
        public static string GenerarRuta(string titulo)
        {
            try
            {
                string rutaAlt = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = Path.Combine(rutaAlt, titulo);
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puedo generar la ruta", ex); 
            }
        }
        /// <summary>
        /// Genera un archivo Json
        /// </summary>
        /// <typeparam name="T">objeto generico</typeparam>
        /// <param name="ruta">donde va a ir el archivo</param>
        /// <param name="obj">el objeto a serializar</param>
        public static void SerializarAJason<T>(string ruta, T obj) where T : class
        {
            try
            {
                if(obj is null)
                {
                    throw new Exception("objeto nulo"); 
                }
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
                jsonSerializerOptions.WriteIndented = true; 

                string objetoJson = JsonSerializer.Serialize(obj, jsonSerializerOptions);

                File.WriteAllText(ruta, objetoJson);
            }
            catch(Exception ex)
            {
                throw new SerializacionException(ex.Message); 
            }
        }
        /// <summary>
        /// Deserealiza un archivo Json
        /// </summary>
        /// <typeparam name="T">objeto generico</typeparam>
        /// <param name="ruta">desde donde se lee el archivo</param>
        /// <returns>El objeto deserealizado</returns>
        public static T DeserealizarDesdeJson<T>(string ruta) where T : class
        {
            try
            {
                string objetoJson = File.ReadAllText(ruta);
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) } };
                jsonSerializerOptions.WriteIndented = true;

                T objetoDeserealizado = JsonSerializer.Deserialize<T>(objetoJson, jsonSerializerOptions);

                return objetoDeserealizado;
            }
            catch (Exception ex)
            {
                throw new SerializacionException(ex);
            }
        }
    }
}
