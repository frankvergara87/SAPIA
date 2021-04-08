using System;
using System.Data;
using System.Collections;
using System.Configuration;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de DWhitelistAsesor.
	/// </summary>
	public class DWhitelistAsesor
	{
		public DWhitelistAsesor()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		# region "Consultas"

		public DataTable fdtbListarBusqueda(string pstrTipo, string pstrDescripcion, string pstrOficina)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 100, ParameterDirection.Input)
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrOficina;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_SMS + ".SP_CON_WHITELIST_ASESOR";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = obRequest.Factory.ExecuteDataset(ref obRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable fdtbTraer(string pstrDNI)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DNI", DbType.String, 15, ParameterDirection.Input)
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrDNI;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_SMS + ".SP_CON_DATOS_ASESOR";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = objRequest.Factory.ExecuteDataset(ref objRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		# endregion

		# region "Transacciones"

		public void pInsertar(string pstrDNI, string pstrNombre, string pstrPaterno, string pstrMaterno, string pstrTelefono, string pstrUsuario,
			string pstrTipoOficina, string pstrOficina, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DNI", DbType.String, 8, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PATERNO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERNO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 11, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OFICINA", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 4, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrDNI;
			arrParam[1].Value = pstrNombre;
			arrParam[2].Value = pstrPaterno;
			arrParam[3].Value = pstrMaterno;
			arrParam[4].Value = pstrTelefono;
			arrParam[5].Value = pstrUsuario;
			arrParam[6].Value = pstrTipoOficina;
			arrParam[7].Value = pstrOficina;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_SMS + ".SP_INS_WHITELIST_ASESOR";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
		}

		public void pEliminar(string pstrDNI, string pstrUsuario, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DNI", DbType.String, 8, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrDNI;
			arrParam[1].Value = pstrUsuario;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_SMS + ".SP_ELIM_WHITELIST_ASESOR";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
		}

		public void pModificar(string pstrDNI, string pstrNombre, string pstrPaterno, string pstrMaterno, string pstrTelefono, string pstrEstado, string pstrUsuario,
			ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_DNI", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PATERNO", DbType.String, 30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATERNO", DbType.String, 30, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TELEFONO", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrDNI;
			arrParam[1].Value = pstrNombre;
			arrParam[2].Value = pstrPaterno;
			arrParam[3].Value = pstrMaterno;
			arrParam[4].Value = pstrTelefono;
			arrParam[5].Value = pstrEstado;
			arrParam[6].Value = pstrUsuario;

			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_SMS + ".SP_UPD_WHITELIST_ASESOR";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}
		}

		# endregion
	}
}
