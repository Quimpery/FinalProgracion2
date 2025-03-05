using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion2Final.Models
{
    internal class Servicio:Items
    {
        string detalle;
        double precioHora;
        public int Tiempo {  get; set; }

        public Servicio(int codigo, string detalle, double precioHora) : base(codigo)
        {
            Codigo = codigo;
            this.detalle = detalle;
            this.precioHora = precioHora;

        }


        public override string Descripcion()
        {
            string datos = ($"Su codigo:{Codigo}\n\tServicio:{detalle}\n\t Tiempo operando:{Tiempo}");

            return datos;
        }

        public override double Precio()
        {
            double precio = 0;

            precio = Tiempo * precioHora;
            return precio;
        }

        public override string ToString()
        {
            return detalle;
        }




    }
}
