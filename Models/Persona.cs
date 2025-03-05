using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion2Final.Models
{
    [Serializable]
    internal class Persona:IComparable<Persona>
    {
        string nombre;
        long cuit;

        public Persona(string name, long cuit)
        {
            nombre = name;
            this.cuit = cuit;

        }

        public int CompareTo(Persona otro)
        {
            int pos = 1;
            if (otro.cuit < this.cuit)
            {
                pos = -1;
            }
            else if(otro.cuit == this.cuit)
            {
                pos = 0;
            }
            
            return pos;
        }

        public override string ToString()
        {
            return "Nombre: " + nombre + "Cuit:" + cuit.ToString();

        }
        public long VerCuit()
        {
            return cuit;
        }


        
    }
}
