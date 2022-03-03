using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ ///Producto:
  ///atributos protegidos: marca:string, tipo:string, codigo:int, precio:double 
    public class Producto
    {
            protected string marca;
            protected string tipo; 
            protected int codigo; 
            protected double precio;
            
        public Producto()
        {
        }
            public Producto(string marca, string tipo, double precio, int codigo)
            {
                this.marca = marca;
                this.precio = precio;
                this.tipo = tipo;
                this.codigo = codigo; 

            }
            public string Marca
        {
            get
            {
                return this.marca; 
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    this.marca = value; 
                }
            }
        }
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.tipo = value;
                }
            }
        }
        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                if (value>-1)
                {
                    this.codigo = value;
                }
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value > -1)
                {
                    this.precio = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Marca: {this.marca}\nTipo: {this.tipo}\nCodigo: {this.codigo}\nPrecio: {this.precio}");

            return sb.ToString();
        }

          
    }
    
}
