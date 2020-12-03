using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticaLoginP
{
    /// <summary>
    /// Lógica de interacción para AgregarProducto.xaml
    /// </summary>
    public partial class AgregarProducto : Window
    {
        string pathName = @"/registroProducto.txt";
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void BtnAgregarP_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (File.Exists(pathName))
                {

                    if (txtAgregarP.Text == " " || txtCantidadP.Text == " " || txtPrecioP.Text == " ")
                    {
                        MessageBox.Show("Necesario:Producto,Cantidad y Precio");
                    }
                    else
                    {
                        string producto = txtAgregarP.Text;
                        int cantidad = int.Parse(txtCantidadP.Text);
                        double precio = double.Parse(txtPrecioP.Text);
                        int id = int.Parse(txtID.Text);
                        precio = Math.Round(precio, 2);

                        if (VerificarProducto(producto) )
                        {
                            if (VerificarID(id))
                            {
                                if (VerificarCantidad(cantidad) && VerificarPrecio(precio))
                                {
                                    int codigo = int.Parse(txtCodigo.Text);
                                    StreamWriter tuberiaEscritura = File.AppendText(pathName);
                                    tuberiaEscritura.WriteLine(id + "," + producto + "," + cantidad + precio + "," + txtCodigo.Text);
                                    tuberiaEscritura.Close();
                                    MessageBox.Show("Producto creado con exito");
                                    txtAgregarP.Text = " ";
                                    txtCantidadP.Text = " ";
                                    txtPrecioP.Text = " ";
                                    txtCodigo.Text = " ";
                                    txtID.Text = " ";
                                    //MostrarRegistro();
                                }

                                else
                                {
                                    MessageBox.Show("Los números de:Cantidad y/o Precio no son válidos");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La ID ya fue utilizada");
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("El producto ya existe");
                        }
                    }
                }
                else
                {
                    File.CreateText(pathName);
                    MessageBox.Show("Archivo creado, intente nuevamente");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error "+ ex.Message);
            }
            
        
        }
        private bool VerificarProducto(string producto)
        {
            bool respuesta = true;
            string[] datosProducto;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosProducto = linea.Split(',');
                if (datosProducto[1] == producto)
                {
                    respuesta = false;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return respuesta;
        }
        private bool VerificarID(int id)
        {
            bool respuesta = true;
            string[] datosProducto;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosProducto = linea.Split(',');
                if (datosProducto[0] == id.ToString())
                {
                    respuesta = false;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return respuesta;
        }
        private bool VerificarCantidad(int cantidad)
        {
            bool respuesta = false;
            if (cantidad>=0)
            {
                respuesta = true;
            }
            return respuesta;
        }
        private bool VerificarPrecio(double precio)
        {
            bool respuesta = false;
            if (precio >= 0)
            {
                respuesta = true;
            }
            return respuesta;
        }
       
    }
}
