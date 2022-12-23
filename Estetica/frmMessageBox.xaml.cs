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
    /// Lógica de interacción para frmMessageBox.xaml
    /// </summary>
    public partial class frmMessageBox : Window
    {
        public bool _Pregunta { get; set; }
        public dynamic TipoDato;
        public string TextoDato { get; set; }
        public frmMessageBox()
        {
            InitializeComponent();
        }
        //Mensaje
        public void frmMessageBoxMensaje(String msg, string icono)
        {
            InitializeComponent();
            try
            {
                msg = msg.Replace("\\n", "\n");
                string[] lineas = msg.Split('\n');

                foreach (string linea in lineas)
                {
                    lblMensaje.Inlines.Add(linea);
                    lblMensaje.Inlines.Add(new LineBreak());
                }

                panelPregunta.Visibility = Visibility.Collapsed;
                panelMensaje.Visibility = Visibility.Visible;

                switch (icono)
                {
                    case "info":
                        iconoInfo.Visibility = Visibility.Visible;
                        iconoSuccces.Visibility = Visibility.Hidden;
                        iconoError.Visibility = Visibility.Hidden;
                        iconoWarning.Visibility = Visibility.Hidden;
                        break;
                    case "success":
                        iconoInfo.Visibility = Visibility.Hidden;
                        iconoSuccces.Visibility = Visibility.Visible;
                        iconoWarning.Visibility = Visibility.Hidden;
                        iconoWarning.Visibility = Visibility.Hidden;
                        break;
                    case "error":
                        iconoInfo.Visibility = Visibility.Hidden;
                        iconoSuccces.Visibility = Visibility.Hidden;
                        iconoError.Visibility = Visibility.Visible;
                        iconoWarning.Visibility = Visibility.Hidden;
                        break;
                    case "warning":
                        iconoInfo.Visibility = Visibility.Hidden;
                        iconoSuccces.Visibility = Visibility.Hidden;
                        iconoError.Visibility = Visibility.Hidden;
                        iconoWarning.Visibility = Visibility.Visible;
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Inlines.Add(ex.Message);
            }
            btnMensajeOk.Focus();
            this.ShowDialog();
        }
        public bool frmMessageBoxPregunta(String msgPregunta)
        {
            InitializeComponent();
            string[] lineas = msgPregunta.Split('\n');

            foreach (string linea in lineas)
            {
                lblPregunta.Inlines.Add(linea);
                lblPregunta.Inlines.Add(new LineBreak());
            }

            var texto = lblPregunta.Text;

            string[] l = texto.Split('*');

            panelPregunta.Visibility = Visibility.Visible;
            panelMensaje.Visibility = Visibility.Collapsed;

            btnPreguntaCancel.Focus();
            this.ShowDialog();
            return _Pregunta;
        }
        public dynamic frmMessageBoxPideDato(string msg, Msg.TipoDato tipo)
        {
            InitializeComponent();
            string[] lineas = msg.Split('\n');

            dynamic Valor;
            int entero;
            decimal decimales;
            TipoDato = tipo;

            foreach (string linea in lineas)
            {
                lblPideDato.Inlines.Add(linea);
                lblPideDato.Inlines.Add(new LineBreak());
            }

            panelPideDato.Visibility = Visibility.Visible;
            panelPregunta.Visibility = Visibility.Collapsed;
            panelMensaje.Visibility = Visibility.Collapsed;

            txtDato.Focus();
            this.ShowDialog();

            if (tipo == Msg.TipoDato.Entero)
            {
                int.TryParse(txtDato.Text.Trim(), out entero);
                Valor = entero;
            }
            else if (tipo == Msg.TipoDato.Decimal)
            {
                decimal.TryParse(txtDato.Text.Trim(), out decimales);
                Valor = decimales;
            }
            else
            {
                Valor = txtDato.Text.Trim();
            }

            return Valor;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnPreguntaOk_Click(object sender, RoutedEventArgs e)
        {
            _Pregunta = true;
            this.Close();
        }

        private void btnPreguntaCancel_Click(object sender, RoutedEventArgs e)
        {
            _Pregunta = false;
            this.Close();
        }

        private void btnMensajeOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtDato_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (TipoDato == Msg.TipoDato.Entero)
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                {
                    if (txtDato.Text.Length <= 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else if (//(e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                        (e.Key == Key.Back)
                    || (e.Key == Key.Right)
                    || (e.Key == Key.Left)
                    || (e.Key == Key.Down)
                    || (e.Key == Key.Up)
                    || (e.Key == Key.Tab)
                    || (e.Key == Key.Delete)
                    || (e.Key == Key.Home)
                    || (e.Key == Key.End)
                    || (e.Key == Key.LeftShift)
                    || (e.Key == Key.RightShift))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

            if (e.Key == Key.Enter && txtDato.Text.Trim() != "")
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void btnPideDatoOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtDato.Text.Length > 0)
            {
                this.Close();
            }
        }

        private void btnPideDatoCancel_Click(object sender, RoutedEventArgs e)
        {
            txtDato.Text = "-1";

            this.Close();
        }
    }
}
