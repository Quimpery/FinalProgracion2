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
    public partial class FormServicios : Form
    {
        public FormServicios()
        {
            InitializeComponent();
            Servicio s1 = new Servicio(210, "Flete", 150.00);
            Servicio s2 = new Servicio(215, "Plomeria", 200.00);
            cbServicios.Items.Add(s1);
            cbServicios.Items.Add((s2));
        }

        private void cbServicios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
