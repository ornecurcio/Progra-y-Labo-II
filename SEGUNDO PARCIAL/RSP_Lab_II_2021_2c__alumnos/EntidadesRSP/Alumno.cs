using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRSP
{
    ///Alumno (deriva de Persona)
    ///Atributo
    ///nota : double
    ///Propiedad pública de lectura y escritura para su atributo.
    ///Constructor que reciba parámetro para cada atributo
    ///Polimorfismo sobre ToString
    ///Eventos (diseñados según convenciones vistas)
    ///Aprobar
    ///NoAprobar
    ///Promocionar
    ///Método de instancia (público)
    ///Clasificar() : void
    ///Si el atributo nota es menor a 4, lanzará el evento NoAprobar.
    ///Si el atributo nota es menor a 6 (y mayor o igual a 4), lanzará el evento Aprobar.
    ///Si el atributo nota es mayor o igual a 6, lanzará el evento Promocionar.
    public class Alumno : Persona
    {
        private double nota;
        public delegate void EventoNota(object sender, EventArgs e);
        public EventoNota Aprobar;
        public EventoNota NoAprobar;
        public EventoNota Promocionar; 

        public Alumno()
        {
        }
        public Alumno(string apellido, string nombre, int dni, double nota) : base(apellido, nombre, dni)
        {
            this.Nota = nota; 
        }

        public double Nota
        {
            get
            {
                return this.nota; 
            }
            set
            {
                if(value > 0 && value < 11)
                {
                    this.nota = value; 
                    this.Clasificar(); 

                }
            }
        }

        public void Clasificar()
        {
            if (this.Nota < 4)
            {
                NoAprobar.Invoke(this, EventArgs.Empty);
            }
            else if(this.Nota < 6 && this.nota > 3)
            {
                Aprobar.Invoke(this, EventArgs.Empty); 
            }
            else
            {
                Promocionar.Invoke(this, EventArgs.Empty); 
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Nota: {this.nota}\n";
        }
    }
}
