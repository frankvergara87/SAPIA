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
	public class DCampanaKit
	{
		public DCampanaKit()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"

		public DataTable fdtbListarCampana()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMPANA";
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

		public DataTable fdtbListarKit()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_KIT";
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

		public DataTable fdtbListarPlazo()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_PLAZO";
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
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_MNTO_CAMP_KIT";
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
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrServCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_CAMP_KIT";
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

		public bool fbooInsertar(string pstrCampanaCodigo, string pstrKitCodigo, string pstrPlazoCodigo, string pstrPrecio, string pstrInstal,string cf_alquiler_kit, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CAMP_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_KIT_CODIGO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PZAC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_LISTA", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_INSTA", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_ALQUILER_KIT", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
			};

			arrParam[0].Value = pstrCampanaCodigo;
			arrParam[1].Value = pstrKitCodigo;
			arrParam[2].Value = pstrPlazoCodigo;
			arrParam[3].Value = pstrPrecio;
			arrParam[4].Value = pstrInstal;
			arrParam[5].Value = cf_alquiler_kit;
			arrParam[6].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_CAMP_KIT";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);		
				salida = true;
			}
			catch( Exception ex )
			{				
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{				
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)
												};
			arrParam[0].Value = pstrCodigo;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_CAMP_KIT";
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

		public bool fbooModificar(string pstrCodigo, string pstrPrecio, string pstrInstal,string cf_alquiler_kit, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_LISTA", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRECIO_INSTA", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CF_ALQUILER_KIT", DbType.Currency, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrPrecio;
			arrParam[2].Value = pstrInstal;
			arrParam[3].Value = cf_alquiler_kit;
			arrParam[4].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSM_MODIFI_CAMP_KIT";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);			
				salida = true;
			}
			catch( Exception ex )
			{				
				rMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{			
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		# endregion

	}
}
