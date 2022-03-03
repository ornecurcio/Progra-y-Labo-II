using System;

namespace MetodosExtension_Generics
{
 
        public static class ClaseExtensora
        {
            public static string MostrarMiembros(this ClaseSellada sellada)
            {
                return sellada.cadena + " " + sellada.entero;
            }



            public static string MostrarInterface(this ImiInterface inter)
            {
                return "Método extensor de la interface";
            }


            public static int ContarCaracteres(this string cadenita)
            {
                return cadenita.Length;
            }



            public static string Reemplazar(this string cadenita, string nuevaCadena)
            {
                return cadenita.Replace(cadenita, nuevaCadena);
            }


            public static int Sumar(this int e, int e2, int e3, int e4)
            {
                return e + e2 + e3 + e4;
            }

        }
    
}
