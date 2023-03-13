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

namespace Estetica
{
    /// <summary>
    /// Lógica de interacción para frmCliente.xaml
    /// </summary>
    public partial class frmCliente : Window
    {
        public bool guardar;
        public frmCliente(Cliente _cliente)
        {
            InitializeComponent();
            this.DataContext = this;
            cliente = _cliente;
        }
        public Cliente cliente { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Msg.Pregunta("¿Guardar cliente?"))
            {
                guardar = true;
                this.Close();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtxnombre.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Escape)
            {
                this.Close();
            }
        }
    }
}
