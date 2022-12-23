using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;

namespace Estetica
{
    public class frmCitaVM : INotifyPropertyChanged
    {
        DA _da;
        public frmCitaVM()
        {
            _da = new DA();
            observacion = "";
        }
        public int hora { get; set; }
        public int minuto { get; set; }
        public string cliente { get; set; }
        public int Codcliente { get; set; }
        public string buscar { get; set; }
        public string observacion { get; set; }
        public string ampmSeleccionado { get; set; }
        public DateTime fecha { get; set; }

        public bool clientesCon()
        {
            bool selecciono = false;
            try
            {
                frmBuscador frm = new frmBuscador(buscar);
                frm.ShowDialog();

                if (frm.ClienteSeleccionado != null)
                {
                    buscar = "";
                    selecciono = true;
                    var result = _da.clientesCon(frm.ClienteSeleccionado.CodCliente.ToString());
                    if (result.Value)
                    {
                        Codcliente = result.Data[0].CodCliente;

                        cliente = Codcliente.ToString() + " - " + result.Data[0].Nombre;
                    }
                    else
                    {
                        cliente = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
            return selecciono;
        }
        public Result citaGuardar()
        {
            Result result = new Result();
            try
            {
                if (Codcliente > 0)
                {
                    if (hora > 0 && ampmSeleccionado != null)
                    {
                        Cita cita = new Cita();
                        cita.CodCliente = Codcliente;

                        if (ampmSeleccionado == "PM")
                        {
                            hora = hora + 12;
                        }

                        cita.Fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, minuto, 0);
                        cita.Observacion = observacion;

                        result = _da.citaGuarda(cita);
                        if (result.Value)
                        {
                            Msg.Mensaje(result.Message, Msg.Icono.Success);
                        }
                        else
                        {
                            Msg.Mensaje(result.Message, Msg.Icono.Error);
                        }
                    }
                    else
                    {
                        Msg.Mensaje("Seleccione la hora", Msg.Icono.Warning);
                    }
                }
                else
                {
                    Msg.Mensaje("Ingrese el cliente", Msg.Icono.Warning);
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
