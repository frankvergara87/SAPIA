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
	public class DWhitelist
	{
		public DWhitelist()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"
			
		public DataTable fdtbListarBusqueda(string pstrTipoDocumento, string pstrNroDocumento, string pstrFechaInicio, string pstrFechaFin, string pstrUsuarioAprobador)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHINIC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHFIN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUAAPROB", DbType.String, 10, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			arrParam[3].Value = pstrFechaInicio;
			arrParam[4].Value = pstrFechaFin;
			arrParam[5].Value = pstrUsuarioAprobador;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_LISTAR_WHLST";
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

		public Whitelist fwhlTraer(string pstrTipoDocumento, string pstrNroDocumento)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_WHLSTIPODOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_WHLSNRODOC", DbType.String, 16, ParameterDirection.Input),
			}; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_WHLST";
			objRequest.Parameters.AddRange(arrParam);

			Whitelist item = new Whitelist();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					item.TipoDocumento = Funciones.CheckStr(dr["whlsc_tipodocu"]);
					item.NroDocumento = Funciones.CheckStr(dr["whlsv_nrodocu"]);
					item.Nombre = Funciones.CheckStr(dr["whlsv_nombre"]);					
					item.CantidadDias = Funciones.CheckInt((dr["whlsn_cantdias"] != DBNull.Value)? dr["whlsn_cantdias"] : -1);
					item.MontoDeuda = Funciones.CheckInt((dr["whlsn_montdeud"] != DBNull.Value)? dr["whlsn_montdeud"] : -1);
					item.TasaBloqueo = Funciones.CheckInt((dr["whlsn_tasabloq"] != DBNull.Value)? dr["whlsn_tasabloq"] : -1);
					item.ObservacionCredito = Funciones.CheckStr(dr["whlsv_obsecred"]);
					item.VigenciaIndefinida = Funciones.CheckStr(dr["whlsc_vigeinde"]);
					item.VigenciaDias = Funciones.CheckInt(dr["whlsn_vigedias"]);
					item.UsuarioAprobador = Funciones.CheckStr(dr["whlsv_usuaapro"]);
					item.NombreUsuarioAprobador = Funciones.CheckStr(dr["whlsv_nombusuaapro"]);
					//item.Estado = Funciones.CheckStr(dr["whlsc_estado"]);
					item.FechaRegistro = Funciones.CheckStr(dr["whlsc_fechregi"]);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return item;
		}

//		public string fstrClienteTraerNombre(string pstrTipoDocumento, string pstrNroDocumento)
//		{
//			DAABRequest.Parameter[] arrParam = {
//												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
//												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
//												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 15, ParameterDirection.Input)
//											   }; 
//			arrParam[0].Value = System.DBNull.Value;
//			arrParam[1].Value = pstrTipoDocumento;
//			arrParam[2].Value = pstrNroDocumento;
//
//			string pstrNombre = string.Empty;
//			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
//			DAABRequest objRequest = obj.CreaRequest();
//			objRequest.CommandType = CommandType.StoredProcedure;
//			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_CLINOM";
//			objRequest.Parameters.AddRange(arrParam);
//			try
//			{
//				objRequest.Factory.ExecuteNonQuery(ref objRequest);
//			}
//			catch(Exception e)
//			{
//				throw e;
//			}
//			finally
//			{
//				IDataParameter parSalida1;
//				parSalida1 = (IDataParameter)objRequest.Parameters[0];
//				pstrNombre = Funciones.CheckStr(parSalida1.Value);
//				objRequest.Factory.Dispose();
//			}
//			return pstrNombre;
//		}

		public string fstrClienteTraerNombre(int pintTipoDocumento, string pstrNroDocumento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DOC", DbType.String, 15, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RAZON_SOCIAL", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_NOMBRES", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_APELLIDOS", DbType.String, ParameterDirection.Output)
											   }; 
			arrParam[0].Value = pintTipoDocumento;
			arrParam[1].Value = pstrNroDocumento;

			string pstrNombre = string.Empty;
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command =  BaseDatos.PKG_BSCS_PARAMETRICO_BLOQUEO + ".sp_nombre_cliente";
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				if (pintTipoDocumento == 99)
					pstrNombre = Funciones.CheckStr(((IDataParameter)objRequest.Parameters[2]).Value);
				else
					pstrNombre = Funciones.CheckStr(((IDataParameter)objRequest.Parameters[3]).Value) + " " + Funciones.CheckStr(((IDataParameter)objRequest.Parameters[4]).Value);
				objRequest.Factory.Dispose();
			}
			return pstrNombre;
		}

		public string fstrUsuarioTraerNombre(string pstrUsuario)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 15, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = System.DBNull.Value;
			arrParam[1].Value = pstrUsuario;

			string pstrNombre = string.Empty;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_USUNOM";
			objRequest.Parameters.AddRange(arrParam);
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[0];
				pstrNombre = Funciones.CheckStr(parSalida1.Value);
				objRequest.Factory.Dispose();
			}
			return pstrNombre;
		}

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NOMBRE", DbType.String, 100, ParameterDirection.Input),
												new DAABRequest.Parameter("P_CANTDIAS", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_MONTDEUD", DbType.Single, ParameterDirection.Input),
												new DAABRequest.Parameter("P_TASABLOQ", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_OBSECRED", DbType.String, 200, ParameterDirection.Input),
												new DAABRequest.Parameter("P_VIGEINDE", DbType.String, 1, ParameterDirection.Input),
												new DAABRequest.Parameter("P_VIGEDIAS", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_USUAAPRO", DbType.String, 10, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NOMBUSUAAPRO", DbType.String, 50, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = whls.TipoDocumento;
			arrParam[2].Value = whls.NroDocumento;
			arrParam[3].Value = whls.Nombre;
			if (whls.CantidadDias > -1)
				arrParam[4].Value = whls.CantidadDias;
			else
				arrParam[4].Value = DBNull.Value;
			if (whls.MontoDeuda > -1)
				arrParam[5].Value = whls.MontoDeuda;
			else
				arrParam[5].Value = DBNull.Value;
			if (whls.TasaBloqueo > -1)
				arrParam[6].Value = whls.TasaBloqueo;
			else
				arrParam[6].Value = DBNull.Value;
			arrParam[7].Value = whls.ObservacionCredito;
			arrParam[8].Value = whls.VigenciaIndefinida;
			arrParam[9].Value = whls.VigenciaDias;
			arrParam[10].Value = whls.UsuarioAprobador;
			arrParam[11].Value = whls.NombreUsuarioAprobador;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSI_INSERT_WHLST";
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
				pstrMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooEliminar(string pstrTipoDocumento, string pstrNroDocumento, ref string pstrEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSD_ELIMIN_WHLST";
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
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANTDIAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTDEUD", DbType.Single, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TASABLOQ", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_OBSECRED", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEINDE", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEDIAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUAAPRO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBUSUAAPRO", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 100, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = whls.TipoDocumento;
			arrParam[2].Value = whls.NroDocumento;
			if (whls.CantidadDias > -1)
				arrParam[3].Value = whls.CantidadDias;
			else
				arrParam[3].Value = DBNull.Value;
			if (whls.MontoDeuda > -1)
				arrParam[4].Value = whls.MontoDeuda;
			else
				arrParam[4].Value = DBNull.Value;
			if (whls.TasaBloqueo > -1)
				arrParam[5].Value = whls.TasaBloqueo;
			else
				arrParam[5].Value = DBNull.Value;
			arrParam[6].Value = whls.ObservacionCredito;
			arrParam[7].Value = whls.VigenciaIndefinida;
			arrParam[8].Value = whls.VigenciaDias;
			arrParam[9].Value = whls.UsuarioAprobador;
			arrParam[10].Value = whls.NombreUsuarioAprobador;
			arrParam[11].Value = whls.Nombre;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_MODIFI_WHLST";
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
				pstrMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool fbooEliminarSeleccionados(string strSeleccionados, ref string pstrEstado, ref string pstrMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DOCUMENTOS", DbType.String, 32767, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;

			if (strSeleccionados.Length > 0)
				arrParam[1].Value = strSeleccionados;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_ELISEL_WHLST";
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
				pstrMsg = "Error al Insertar. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				pstrEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		# endregion

	}
}