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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarmPack.Classes;

namespace Estetica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM _VM;
        public int CodClienteBuscador { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _VM = new MainWindowVM();
            this.DataContext = _VM;
        }

        private void mnClientes_Click(object sender, RoutedEventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog();
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            frmServicio frm = new frmServicio(_VM.CitaSeleccionada);
            frm.ShowDialog();
            _VM.citasCon();
            _VM.serviciosCon(0);
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            _VM.citaCancelar();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM.version = "v. " + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            _VM.mostrarTodos = true;
            _VM.citasCon();
            _VM.serviciosCon(0);
        }

        private void mnCita_Click(object sender, RoutedEventArgs e)
        {
            frmCita frm = new frmCita();
            frm.ShowDialog();
            _VM.citasCon();
        }

        private void btnDetalle_Click(object sender, RoutedEventArgs e)
        {

            Cita cita = new Cita();
            cita.IdCitas = _VM.ServicioSeleccionado.IdCitas;
            cita.Descripcion = _VM.ServicioSeleccionado.Descripcion;
            cita.Importe = _VM.ServicioSeleccionado.Importe;
            
            frmServicio frmser = new frmServicio(cita);
            frmser.ShowDialog();

            _VM.serviciosCon(CodClienteBuscador);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cliente = Msg.PideDato("nombre del cliente", Msg.TipoDato.String);
            frmBuscador frm = new frmBuscador(cliente);
            frm.ShowDialog();
            if (frm.ClienteSeleccionado != null)
            {
                CodClienteBuscador = frm.ClienteSeleccionado.CodCliente;
                var result = _VM.serviciosCon(frm.ClienteSeleccionado.CodCliente);
                if (result.Value)
                {
                    _VM.mostrarTodos = false;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CodClienteBuscador = 0;
            _VM.serviciosCon(0);
            _VM.mostrarTodos = true;
        }
    }
}
