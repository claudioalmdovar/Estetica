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
    /// Lógica de interacción para frmClientes.xaml
    /// </summary>
    public partial class frmClientes : Window
    {
        frmClientesVM _VM;
        public frmClientes()
        {
            InitializeComponent();
            _VM = new frmClientesVM();
            this.DataContext = _VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmCliente frm = new frmCliente(_VM.ClienteSeleccionado);
            frm.ShowDialog();
            if (frm.guardar)
            {
                _VM.clienteGuardar();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _VM.ClienteSeleccionado = new Cliente();
            frmCliente frm = new frmCliente(_VM.ClienteSeleccionado);
            frm.ShowDialog();
            if (frm.guardar)
            {
                _VM.clienteGuardar();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM.clientesCon();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
