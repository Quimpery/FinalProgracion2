using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion2Final.Models
{
    [Serializable]
    internal class Factura
    {
        public Persona cliente;
        public DateTime FechaHora = DateTime.Now;
        public double Iva;
        public double PrecioTotal;
        public int CantidadItems;
        static int nroFactura = 0;
        List<Items> ListaItems;

        public Factura(Persona cliente)
        {
            this.cliente=cliente;
            ListaItems = new List<Items>();
            PrecioTotal = 0;
        }

        public void AgregarItems(Items linea)
        {
            if(linea != null)
            {
                ListaItems.Add(linea);
            }
            CantidadItems++;
            
        }

        public double PrecioSinIva()
        {

            double precioSinIva = 0;
            ProdUnitario aux;
            Servicio aux2;

            foreach (Items i in ListaItems)
            {
                if (i is ProdUnitario)
                {
                    aux = i as ProdUnitario;
                    precioSinIva += aux.Precio();
                }
                else if(i is Servicio)
                {
                    aux2 = i as Servicio;
                    precioSinIva += aux2.Precio();
                }

            }
            return precioSinIva;
        }

        public Items MostrarItems(int numero)
        {
            return ListaItems[numero];
        }  

        public override string ToString()
        {
            string factura = ($"Factuar Numero:{nroFactura}Cliente:{cliente}\n\t Hora de atencion:{FechaHora}");
            nroFactura++;
            return factura;

        }

        public int VerNumero()
        {
            return nroFactura;
        }
    }
}
