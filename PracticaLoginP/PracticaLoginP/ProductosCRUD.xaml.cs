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
    /// Lógica de interacción para ProductosCRUD.xaml
    /// </summary>
    public partial class ProductosCRUD : Window
    {
        string pathName = @"/registroProducto.txt";

        public ProductosCRUD()
        {
            InitializeComponent();
            MostrarRegistro();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AgregarProducto agregarProducto = new AgregarProducto();
                this.Hide();
                agregarProducto.ShowDialog();
                this.Close();
                
            }
            catch
            {

            }
        }
        private void MostrarRegistro()
        {
            try
            {
                txtLista.Text = "";
                if (File.Exists(pathName))
                {
                    string fila;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    fila = tuberiaLectura.ReadLine();
                    while (fila != null)
                    {
                        txtLista.AppendText(fila + "\r\n");
                        fila = tuberiaLectura.ReadLine();
                    }
                    tuberiaLectura.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
