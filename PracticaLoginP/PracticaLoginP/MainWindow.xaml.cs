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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticaLoginP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathName = @"./login";
        public MainWindow()
        {
            InitializeComponent();
            VerificarArchivo();
        }
        private void VerificarArchivo()
        {
            try
            {
                if (!File.Exists(pathName))
                {
                    File.Create(pathName).Dispose();
                    Escribir("administrador,administrador,administrador,administrador");
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void Escribir(string mensaje)
        {
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            tuberiaEscritura.WriteLine(mensaje);
            tuberiaEscritura.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (usuario != "" && password != "")
                {
                    if (ValidarUsuario(usuario, password))
                    {

                        VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                        this.Hide();
                        ventanaPrincipal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                       
                        MessageBox.Show("datos incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos");
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void lblCuenta_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            MessageBox.Show("Abrimos otra pagina");
        }

        private void lblCuenta_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void lblCuenta_MouseEnter(object sender, MouseEventArgs e)
        {
            var color = (Color)ColorConverter.ConvertFromString("#FFFFFF");
            Color rg = new Color();
            rg = Color.FromRgb(77, 77, 77);
            lblCuenta.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#616161"));

        }

        private void lblCuenta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Abrimos otra pagina");
        }

        private void lblCuenta_MouseLeave(object sender, MouseEventArgs e)
        {

            lblCuenta.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF898181"));
        }
        private bool ValidarUsuario(string usuario, string password)
        {
            bool resultado = false;
            string[] datosUsuario;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosUsuario = linea.Split(',');
                if (datosUsuario[2] == usuario && datosUsuario[3] == password)
                {
                    resultado = true;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return resultado;
        }
    }
}


