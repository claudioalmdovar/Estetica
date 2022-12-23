using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estetica
{
    public class Msg
    {
        public enum Icono
        {
            Success,
            Warning,
            Error,
            Info
        }
        public enum TipoDato
        {
            Entero,
            Decimal,
            String
        }
        public static void Mensaje(string msg, Icono icono)
        {
            string ico = "";
            switch (icono)
            {
                case Icono.Info:
                    ico = "info";
                    break;
                case Icono.Success:
                    ico = "success";
                    break;
                case Icono.Error:
                    ico = "error";
                    break;
                case Icono.Warning:
                    ico = "warning";
                    break;
            }
            frmMessageBox frm = new frmMessageBox();
            frm.frmMessageBoxMensaje(msg, ico);
        }
        public static bool Pregunta(string pregunta)
        {
            frmMessageBox frm = new frmMessageBox();
            return frm.frmMessageBoxPregunta(pregunta);
        }
        public static dynamic PideDato(string texto, TipoDato tipoDato)
        {
            dynamic tipo = null;
            switch (tipoDato)
            {
                case TipoDato.Entero:
                    tipo = TipoDato.Entero;
                    break;
                case TipoDato.Decimal:
                    tipo = TipoDato.Decimal;
                    break;
                case TipoDato.String:
                    tipo = TipoDato.String;
                    break;
            }

            frmMessageBox frm = new frmMessageBox();
            return frm.frmMessageBoxPideDato(texto, tipo);
        }
    }
}
