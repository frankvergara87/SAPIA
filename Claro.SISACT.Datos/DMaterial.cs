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
	/// Summary description for MantenimeintoMaestro.
	/// </summary>
	public class DMaterial
	{
		public DMaterial()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"
			
		public DataTable fdtbListarBusqueda(string pstrDescripcion)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrDescripcion;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_MNTO_MATE";
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

		public DataTable fdtbTraer(string pstrServCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrServCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_MATE";
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

		public DataTable fdtbListarTipoMaterial()
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_TIPO_MATE";
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

		public bool fbooInsertar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrIddet, string pstrTipo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDDET", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
			};

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrEstado;
			arrParam[4].Value = pstrIddet;
			arrParam[5].Value = pstrTipo;
			arrParam[6].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_MATE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
													new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
													new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
												};
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrUsuario;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_MATE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Eliminar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrEstado, string pstrIddet, string pstrTipo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_IDDET", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrEstado;
			arrParam[4].Value = pstrIddet;
			arrParam[5].Value = pstrTipo;
			arrParam[6].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSM_MODIFI_MATE";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				sEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		# endregion

	}
}
