using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
           var result = MessageBox.Show("¿Está seguro que quiere salir?", "Salir", 
               MessageBoxButton.YesNo);
          //  if (result=DialogResult.Value(Yes))
           // {
                
          //  }
        }

        private void BtnQuienesSomos_Click(object sender, RoutedEventArgs e)
        {
            QuienesSomos quienesSomos = new QuienesSomos();
            this.Hide();
            quienesSomos.ShowDialog();
            this.Close();
        }

        private void BtnReportes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ventas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            ProductosCRUD productosCrud = new ProductosCRUD();
            this.Hide();
            productosCrud.ShowDialog();
            this.Close();
        }
    }
}
