using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion2Final.Models
{
    internal class ProdUnitario:Items
    {
        string nombre;
        string unidadDeMedida;
        public double Cantidad {  get; set; }
        public double PrecioUnidad {  get; set; }
        


        public ProdUnitario(int codigo, string nombre, string unidadDeMedidad, double precioUnidad) : base(codigo)
        {
            Codigo=codigo;
            this.nombre=nombre;
            this.unidadDeMedida=unidadDeMedidad;
            PrecioUnidad=precioUnidad;
        }

        public override string Descripcion()
        {
            string descripcion = ($"Codigo:{Codigo}\n\t Nombre:{nombre}\n\t Unidad de medida:{unidadDeMedida}\n\t Precio:{PrecioUnidad}\n\t Cantidad:{Cantidad}");
            return descripcion;
        }

        public override double Precio()
        {
            double precio = 0;

            precio = (PrecioUnidad * Cantidad) + (PrecioUnidad * Cantidad) * 0.07;
            return precio;
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
