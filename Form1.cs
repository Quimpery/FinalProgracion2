using Programacion2Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion2Final
{
    public partial class Form1 : Form
    {
        Empresa sacor = new Empresa("Sancor", 210985412);
        Persona cliente;
        Factura Nueva;

        public Form1()
        {
            InitializeComponent();
            FormsProductos vProductos = new FormsProductos();
            FormServicios vServicios = new FormServicios();
        }


        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
           FormServicios vServicios= new FormServicios();
            
            
            if(vServicios.ShowDialog()==DialogResult.OK )
            {
                Servicio ser = (Servicio)vServicios.cbServicios.SelectedItem;
                int tiempo=Convert.ToInt32(vServicios.tbTiempo.Text);
                ser.Tiempo = tiempo;
                ser.Precio();
                Nueva.AgregarItems(ser);
                
             
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            long cuit = Convert.ToInt64(tbCuit.Text);
            cliente = sacor.BuscarCliente(cuit);
            if (cliente == null)
            {
                MessageBox.Show("El cliente no existe");

            }
            else
            {
                MessageBox.Show($"Datos:{cliente.ToString()}");
            }
            tbCuit.Clear();

            Nueva = new Factura(cliente);

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre=tbNombre.Text;
            long cuit= Convert.ToInt64(tbCuitNuevo.Text);
            cliente=new Persona(nombre, cuit);
            sacor.AgregarCliente(cliente);
            tbNombre.Clear();
            tbCuitNuevo.Clear();
            MessageBox.Show("Cliente Agregado");
            Nueva = new Factura(cliente);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FormsProductos vProductos = new FormsProductos();

            if(vProductos.ShowDialog() == DialogResult.OK)
            {
                int cantidad = Convert.ToInt32(vProductos.tbCantidad.Text);
                ProdUnitario i = (ProdUnitario)vProductos.cbProdcutos.SelectedItem;
                
                i.Cantidad = cantidad;
                i.Precio();

                Nueva.AgregarItems(i);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            sacor.AgregarFactura(Nueva);

            FormMostrar vMostrar = new FormMostrar();
            
            vMostrar.lbResumen.Items.Add(Nueva.ToString());

            for (int i = 0; i < Nueva.CantidadItems; i++)
            {
                vMostrar.lbResumen.Items.Add(Nueva.MostrarItems(i).ToString());
                vMostrar.lbResumen.Items.Add("\n");
            }
            vMostrar.lbResumen.Items.Add(Nueva.PrecioSinIva());
            vMostrar.lbResumen.Items.Add(Nueva.PrecioTotal);

            vMostrar.Show();

        }
    }
}
