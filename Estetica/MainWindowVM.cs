using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;

namespace Estetica
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        DA _da;
        public MainWindowVM()
        {
            _da = new DA();
            mostrarTodos = false;
        }

        public List<Cita> Citas { get; set; }
        public Cita CitaSeleccionada { get; set; }
        public List<Servicio> Servicios { get; set; }
        public Servicio ServicioSeleccionado { get; set; }
        public bool mostrarTodos { get; set; }
        public string version { get; set; }
        public void citaCancelar()
        {
            try
            {
                if (Msg.Pregunta("¿Desea cancelar la cita?"))
                {
                    var result = _da.citaCancelar(CitaSeleccionada.IdCitas);
                    if (result.Value)
                    {
                        citasCon();
                        Msg.Mensaje(result.Message, Msg.Icono.Success);
                    }
                    else
                    {
                        Msg.Mensaje(result.Message, Msg.Icono.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
        }
        public void citaFinalizar()
        {
            try
            {
                var result = _da.citaCancelar(CitaSeleccionada.IdCitas);
                if (result.Value)
                {
                    citasCon();
                    Msg.Mensaje(result.Message, Msg.Icono.Success);
                }
                else
                {
                    Msg.Mensaje(result.Message, Msg.Icono.Error);
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
        }
        public void citasCon()
        {
            try
            {
                var result = _da.citasCon();
                if (result.Value)
                {
                    Citas = result.Data;
                }
                else
                {
                    Citas = new List<Cita>();
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
        }
        public Result<List<Servicio>> serviciosCon(int codCliente)
        {
            Result<List<Servicio>> result = new Result<List<Servicio>>();
            try
            {
                result = _da.serviciosCon(codCliente);
                if (result.Value)
                {
                    Servicios = result.Data;
                }
                else
                {
                    Servicios = new List<Servicio>();
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
