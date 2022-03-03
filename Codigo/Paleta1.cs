using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaPaleta
{
    public class Paleta
    {
        private Tempera[] temperas;
        private int cantidadMaximaColores;

        #region Contructor
        private Paleta() : this(5)
        {
        }

        private Paleta(int cantidadMaximaColores)
        {
            this.cantidadMaximaColores = cantidadMaximaColores;
            this.temperas = new Tempera[this.cantidadMaximaColores];
            
        }

        #endregion

        #region Metodos
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cantidad maxima de colores: ");
            sb.AppendLine(this.cantidadMaximaColores.ToString());
            sb.AppendLine("Listado de temperas: ");
            foreach (Tempera item in temperas)
            {
                if(item != null)
                {
                    sb.AppendLine(Tempera.Mostrar(item));
                }
            }
            return sb.ToString();
        }

        public int ObtenerIndice()
        {
            int indice = -1;
            for (int i =0; i < this.cantidadMaximaColores; i++)
            {
                if(this.temperas[i] == null)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public int ObtenerIndice(Tempera tempera)
        {
            int indice = -1;
            for (int i = 0; i < this.cantidadMaximaColores; i++)
            {
                if (this.temperas[i] == tempera)
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }
        #endregion

        #region Operadores
        public static implicit operator Paleta(int cantidadMaximaColores)
        {
            Paleta retorno = new Paleta(cantidadMaximaColores); // ?????????????
            return retorno;
        }
        //mostrar()
        public static explicit operator string(Paleta paleta)
        {
            return paleta.Mostrar();
        }

        public static bool operator ==(Paleta paleta, Tempera tempera)
        {
            bool retorno = false;
            foreach (Tempera item in paleta.temperas)
            {
                if(tempera == item)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Paleta paleta, Tempera tempera)
        {
            return !(paleta == tempera);
        }

        public static Paleta operator +(Paleta paleta, Tempera tempera)
        {
            int indice;
            if(paleta == tempera)
            {
                indice = paleta.ObtenerIndice(tempera);
                paleta.temperas[indice] += tempera;
            }
            else
            {
                indice = paleta.ObtenerIndice();
                if(indice !=-1) // arreglado, si da -1, no hay mas espacio en la paleta
                { 
                    paleta.temperas[indice] = tempera;
                }
            }
            return paleta;
        }

        public static Paleta operator -(Paleta paleta, Tempera tempera)
        {
            int indice;
            if (paleta == tempera)
            {
                indice = paleta.ObtenerIndice(tempera);
                paleta.temperas[indice] += (- tempera);// al tener el implicit int de tempera, podemos restarselo a 0, y como tenemos la sobrecarga de +(tempera, int), podemos sumarlo con otra tempera
                if(paleta.temperas[indice] <= 0)
                {
                    paleta.temperas[indice] = null;
                }
            }
            return paleta;
        }

        public static Paleta operator +(Paleta p1, Paleta p2)
        {
            Paleta paletaSuma = null; //p1? 
            int indice;
            if ((object)p1 !=null && (object)p2 != null) // no  es necesario
            {
                paletaSuma = p1.cantidadMaximaColores + p2.cantidadMaximaColores; // uso el implicit de Paleta(int)
                //foreach (Tempera item in p1.temperas)
                //{
                //    if(item != null)
                //    {
                //        paletaSuma.temperas.SetValue(item, paletaSuma.ObtenerIndice()); // seteo la tempera en el primer lugar libre de la nueva paleta
                //    }// metodo copy
                //}
                p1.temperas.CopyTo(paletaSuma.temperas, 0);

                foreach (Tempera item2 in p2.temperas)
                {
                    if (item2 != null) // puede tomar item2 el valor null?
                    {
                        indice = paletaSuma.ObtenerIndice(item2);
                        if (indice == -1) // si el item no esta en la nueva paleta
                        {
                            //paletaSuma.temperas.SetValue(item2, paletaSuma.ObtenerIndice()); // cuidado retorno obtenerindice
                            paletaSuma.temperas[paletaSuma.ObtenerIndice()] = item2;
                        }
                        else
                        {
                            paletaSuma.temperas[indice] += item2; // si encontro una tempera igual, tomamos el indice y le sumamos la tempera(item2)
                            // sumar temperas
                        }

                    }
                }
            }
            return paletaSuma;
        }
        #endregion
        }
}
