using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarmPack.Classes;
using WarmPack.Database;

namespace Estetica
{
    class DA
    {
        private readonly Conexion _conexion = null;

        public DA()
        {
            try
            {
                //_conexion = new Conexion(ConexionType.MSSQLServer, "data source=DESKTOP-3VDQ3FV\\LOCALHOST; initial catalog=Estetica; user id=sa; password=triplea");
                _conexion = new Conexion(ConexionType.MSSQLServer, "data source=LOCALHOST; initial catalog=Estetica; user id=sa; password=triplea");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        //citas
        public Result<List<Cita>> citasCon()
        {
            var resultado = new Result<List<Cita>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.ExecuteWithResults<Cita>("procCitasCon", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }
        public Result citaGuarda(Cita cita)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodCliente", ConexionDbType.Int, cita.CodCliente);
                parametros.Add("@pFecha", ConexionDbType.DateTime, cita.Fecha);
                parametros.Add("@pObservacion", ConexionDbType.VarChar, cita.Observacion);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.Execute("procCitaGuarda", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }
        public Result citaCancelar(int idCita)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pIdCita", ConexionDbType.Int, idCita);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.Execute("procCitaCancelar", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        //servicios
        public Result<List<Servicio>> serviciosCon(int codCliente)
        {
            var resultado = new Result<List<Servicio>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodCliente", ConexionDbType.Int, codCliente);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.ExecuteWithResults<Servicio>("procServiciosCon", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }
        public Result servicioGuarda(Servicio servicio)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodCliente", ConexionDbType.Int, servicio.CodCliente);
                parametros.Add("@pIdCitas", ConexionDbType.Int, servicio.IdCitas);
                parametros.Add("@pDescripcion", ConexionDbType.VarChar, servicio.Descripcion);
                parametros.Add("@pImporte", ConexionDbType.Decimal, servicio.Importe);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.Execute("procServicioGuarda", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }

        //clientes
        public Result<List<Cliente>> clientesCon(string Cliente)
        {
            var resultado = new Result<List<Cliente>>();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCliente", ConexionDbType.NVarChar, Cliente);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.ExecuteWithResults<Cliente>("procClientesCon", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }
        public Result clienteGuarda(Cliente cliente)
        {
            var resultado = new Result();
            try
            {
                var parametros = new ConexionParameters();
                parametros.Add("@pCodCliente", ConexionDbType.Int, cliente.CodCliente);
                parametros.Add("@pNombre", ConexionDbType.VarChar, cliente.Nombre);
                parametros.Add("@pTelefono", ConexionDbType.VarChar, cliente.Telefono);
                parametros.Add("@pCorreo", ConexionDbType.VarChar, cliente.Correo);
                parametros.Add("@pResultado", ConexionDbType.Bit, System.Data.ParameterDirection.Output);
                parametros.Add("@pMsg", ConexionDbType.VarChar, System.Data.ParameterDirection.Output, 300);

                resultado = _conexion.Execute("procClientesGuarda", parametros);
            }
            catch (Exception ex)
            {
                resultado.Value = false;
                resultado.Message = ex.Message;
            }
            return resultado;
        }
    }
}
