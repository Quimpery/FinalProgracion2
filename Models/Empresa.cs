using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion2Final.Models
{
    [Serializable]
    internal class Empresa
    {
        string nombre;
        long cuit;
        double facturacionTotal;
        Queue<Persona> ListaClientes;
        Stack<Factura> ListaFacturas; 

        public Empresa(string nombre, long cuit)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            this.facturacionTotal = 0;
            ListaClientes = new Queue<Persona> ();
            ListaFacturas=new Stack<Factura>();
        }

        public Queue<Persona> VerClientes()
        {
            return ListaClientes;
        }

        public void AgregarCliente(Persona persona)
        {
            ListaClientes.Enqueue (persona);
        }

        public Persona BuscarCliente(long cuit)
        {
            Persona buscado = null;
            foreach (Persona persona in ListaClientes)
            {
                

                if (persona.VerCuit() == cuit)
                {
                    buscado = persona;
                }

            }
            return buscado;
        }
        

        public void AgregarFactura(Factura factura)
        {
            ListaFacturas.Push (factura);
            facturacionTotal += factura.PrecioTotal;

        }
        public Stack<Factura> VerFactura()
        {
            return ListaFacturas;
        }
        
    }
}
