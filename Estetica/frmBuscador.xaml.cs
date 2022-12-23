using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WarmPack.Classes;

namespace Estetica
{
    /// <summary>
    /// Lógica de interacción para frmBuscador.xaml
    /// </summary>
    public partial class frmBuscador : Window
    {
        List<Cliente> _lst;
        BackgroundWorker _bwk;
        string _buscar;
        Boolean _primeraVez = true;
        public Cliente ClienteSeleccionado { get; set; }
        DA _da;

        public frmBuscador(string buscar)
        {
            InitializeComponent();
            _da = new DA();

            _bwk = new BackgroundWorker();
            _bwk.WorkerSupportsCancellation = true;
            _bwk.WorkerReportsProgress = true;
            _bwk.DoWork += _bwk_DoWork;
            _bwk.RunWorkerCompleted += _bwk_RunWorkerCompleted;

            txtBeneficiario.Text = buscar;
            txtBeneficiario.SelectionStart = txtBeneficiario.Text.Length;

            BuscarCliente(txtBeneficiario.Text);
        }

        private void _bwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dtgArticulos.ItemsSource = _lst;
            dtgArticulos.SelectedIndex = 0;

            if (_lst.Count == 1 && _primeraVez)
            {
                if (dtgArticulos.SelectedItems.Count > 0)
                {
                    ClienteSeleccionado = dtgArticulos.SelectedItem as Cliente;
                }
            }

            if (_primeraVez)
            {
                if (_lst.Count == 0)
                {
                    Msg.Mensaje("No se encontro cliente", Msg.Icono.Warning);
                }
                _primeraVez = false;
            }
        }

        private void _bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            Result<List<Cliente>> resultado = _da.clientesCon(_buscar);
            if (resultado.Value)
            {
                _lst = resultado.Data;
            }
            else
            {
                _lst = new List<Cliente>();
            }
        }

        private void BuscarCliente(string buscar)
        {
            _buscar = buscar;
            if (!_bwk.IsBusy)
            {
                _bwk.RunWorkerAsync();
            }
        }

        private void dtgArticulos_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (dtgArticulos.SelectedItems.Count > 0)
                {
                    ClienteSeleccionado = dtgArticulos.SelectedItem as Cliente;
                    this.Close();
                }
                e.Handled = true;
            }
        }

        private void DtgArticulos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgArticulos.SelectedItems.Count > 0)
            {
                ClienteSeleccionado = dtgArticulos.SelectedItem as Cliente;
                this.Close();
            }
            e.Handled = true;
        }

        private void TxtBeneficiario_TextChanged(object sender, TextChangedEventArgs e)
        {
            BuscarCliente(txtBeneficiario.Text);
        }

        private void TxtBeneficiario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            else if (e.Key == Key.Up)
            {
                if (dtgArticulos.SelectedIndex > 0)
                {
                    dtgArticulos.SelectedIndex -= 1;
                    this.dtgArticulos.ScrollIntoView(this.dtgArticulos.SelectedItem);
                }
            }
            else if (e.Key == Key.Down)
            {
                if (dtgArticulos.SelectedIndex < dtgArticulos.Items.Count - 1)
                {
                    dtgArticulos.SelectedIndex += 1;
                    this.dtgArticulos.ScrollIntoView(this.dtgArticulos.SelectedItem);
                }
            }
            else if (e.Key == Key.Enter)
            {
                ClienteSeleccionado = dtgArticulos.SelectedItem as Cliente;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBeneficiario.Focus();
        }
    }
}
