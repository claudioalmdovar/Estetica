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
    /// Lógica de interacción para frmCita.xaml
    /// </summary>
    public partial class frmCita : Window
    {
        frmCitaVM _vm;
        public frmCita()
        {
            InitializeComponent();
            _vm = new frmCitaVM();
            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = _vm.citaGuardar();
            if (result.Value)
            {
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_vm.clientesCon())
                {
                    txthora.SelectAll();
                    txthora.Focus();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtpDesde.SelectedDate = DateTime.Now;
            txtbuscar.Focus();
        }

        private void txthora_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtmin.SelectAll();
                txtmin.Focus();
            }
        }

        private void txtmin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cmbAmPm.Focus();
                cmbAmPm.IsDropDownOpen = true;
            }
        }
    }
}
