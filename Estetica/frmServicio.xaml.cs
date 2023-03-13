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

namespace Estetica
{
    /// <summary>
    /// Lógica de interacción para frmServicio.xaml
    /// </summary>
    public partial class frmServicio : Window, INotifyPropertyChanged
    {
        DA _da;
        public Cita _cita { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal importe { get; set; }
        public string observacion { get; set; }
        public frmServicio(Cita cita)
        {
            InitializeComponent();
            _da = new DA();
            DataContext = this;
            _cita = cita;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtdetalle.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Msg.Pregunta("¿Desea finalizar la cita?"))
                {
                    if (_cita.Importe > 0)
                    {
                        if (_cita.Descripcion != null && _cita.Descripcion != "")
                        {
                            Servicio ser = new Servicio();
                            ser.CodCliente = _cita.CodCliente;
                            ser.IdCitas = _cita.IdCitas;
                            ser.Descripcion = _cita.Descripcion;
                            ser.Importe = _cita.Importe;

                            var result = _da.servicioGuarda(ser);

                            if (result.Value)
                            {
                                Msg.Mensaje(result.Message, Msg.Icono.Success);
                                this.Close();
                            }
                            else
                            {
                                Msg.Mensaje(result.Message, Msg.Icono.Error);
                            }
                        }
                        else
                        {
                            Msg.Mensaje("Ingrese el detalle.", Msg.Icono.Warning);
                            txtdetalle.Focus();
                        }
                    }
                    else
                    {
                        Msg.Mensaje("El importe debe ser mayor a 0.", Msg.Icono.Warning);
                        txtimporte.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
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

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
