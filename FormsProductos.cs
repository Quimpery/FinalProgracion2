using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion2Final.Models
{
    public partial class FormsProductos : Form
    {
        public FormsProductos()
        {
            InitializeComponent();
            ProdUnitario p1 = new ProdUnitario(100, "Cable Bipolar", "Metro", 2.25);
            ProdUnitario p2 = new ProdUnitario(120, "Cable 2,5mm", "Metro", 1.25);
            ProdUnitario p3 = new ProdUnitario(130, "Soldador 40w", "Unidad", 650.00);
            ProdUnitario p4 = new ProdUnitario(150, "Destornillador punta plana", "Unidad", 870.00);

            cbProdcutos.Items.Add(p1);
            cbProdcutos.Items.Add(p2);
            cbProdcutos.Items.Add(p3);
            cbProdcutos.Items.Add(p4);
        }
    }
}
