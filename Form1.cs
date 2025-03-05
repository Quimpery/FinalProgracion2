using Programacion2Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        FormsProductos vProductos = new FormsProductos();
        FormServicios vServicios = new FormServicios();

        public Form1()
        {
            InitializeComponent();
           
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] datos = linea.Split(';');

                        int codigo = Convert.ToInt32(datos[0]);
                        string nombre = datos[1];
                        string unidadMedida = datos[2];
                        double precio = Convert.ToDouble(datos[3]);

                        ProdUnitario producto = new ProdUnitario(codigo, nombre, unidadMedida, precio);

                        vProductos.cbProdcutos.Items.Add(producto);
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(fs != null) fs.Close();
                if(sr != null) sr.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FileStream fs = null;
            try
            {
                fs = new FileStream("sacor.bin", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                sacor=bf.Deserialize(fs) as Empresa;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            

            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(sf.FileName, FileMode.CreateNew, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    Stack<Factura> factura = new Stack<Factura>();
                    factura = sacor.VerFactura();
                    foreach (Factura fac in factura)
                    {
                        sw.WriteLine($"{fac.VerNumero().ToString()};{fac.cliente.VerCuit().ToString()};{fac.FechaHora.Date};{fac.FechaHora.TimeOfDay};{fac.PrecioTotal}");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            finally
            {
                if( fs != null) fs.Close();
                 if(sw != null) sw.Close();
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;

            try
            {
                fs= new FileStream("sacor.bin",FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, sacor);
            }
            catch(Exception ex)
            {
                MessageBox.Show (ex.Message );
            }
            finally
            {
                if( fs != null) fs.Close();
            }
        }
    }
}
