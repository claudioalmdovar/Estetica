using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estetica
{
    public class frmClientesVM : INotifyPropertyChanged
    {
        DA _da;
        public frmClientesVM()
        {
            _da = new DA();
        }

        public List<Cliente> Clientes { get; set; }
        public Cliente ClienteSeleccionado { get; set; }
        public void clientesCon()
        {
            try
            {
                var result = _da.clientesCon("0");
                if (result.Value)
                {
                    Clientes = result.Data;
                }
                else
                {
                    Clientes = new List<Cliente>();
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
        }
        public void clienteGuardar()
        {
            try
            {
                if (ClienteSeleccionado.Nombre != null && ClienteSeleccionado.Nombre != "")
                {
                    var result = _da.clienteGuarda(ClienteSeleccionado);
                    if (result.Value)
                    {
                        clientesCon();
                        Msg.Mensaje(result.Message, Msg.Icono.Success);
                    }
                    else
                    {
                        Clientes = new List<Cliente>();
                        Msg.Mensaje(result.Message, Msg.Icono.Error);
                    }
                }
                else
                {
                    Msg.Mensaje("El nombre es obligatorio", Msg.Icono.Warning);
                }
            }
            catch (Exception ex)
            {
                Msg.Mensaje(ex.Message, Msg.Icono.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
