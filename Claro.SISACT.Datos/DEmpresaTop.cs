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
	public class DEmpresaTop
	{
		public DEmpresaTop()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"
			
		public DataTable fdtbListarBusqueda(string pstrTipoDocumento, string pstrNroDocumento, string pstrNombre, string pstrFechaInicio, string pstrFechaFin, int pintRankingInicio, int pintRankingFin)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 200, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHINIC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHFIN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANKINIC", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANKFIN", DbType.Int32, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			arrParam[3].Value = pstrNombre;
			arrParam[4].Value = pstrFechaInicio;
			arrParam[5].Value = pstrFechaFin;
			arrParam[6].Value = pintRankingInicio;
			arrParam[7].Value = pintRankingFin;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_LISTAR_EMPRTOP";
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
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
			}; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrTipoDocumento;
			arrParam[2].Value = pstrNroDocumento;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_EMPRTOP";
			objRequest.Parameters.AddRange(arrParam);

			Whitelist item = new Whitelist();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					item.TipoDocumento = Funciones.CheckStr(dr["tdocc_codigo"]);
					item.NroDocumento = Funciones.CheckStr(dr["etopv_num_doc"]);
					item.Nombre = Funciones.CheckStr(dr["etopv_razon_social"]);
					item.CantidadDias = Funciones.CheckInt(dr["etopn_ranking"]);
					item.VigenciaIndefinida = Funciones.CheckStr(dr["etopc_vige_inde"]);
					item.VigenciaDias = Funciones.CheckInt(dr["etopn_dias_tolerancia"]);
					item.Estado = Funciones.CheckStr(dr["etopc_tipo"]);
					item.FechaRegistro = Funciones.CheckStr(dr["etopc_fech_regi"]);
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

		# endregion

		# region "Transacciones"

		public bool fbooInsertar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NOMBRE", DbType.String, 100, ParameterDirection.Input),
												new DAABRequest.Parameter("P_TIPO", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_RANKING", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_VIGEINDE", DbType.String, 1, ParameterDirection.Input),
												new DAABRequest.Parameter("P_VIGEDIAS", DbType.Int32, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = whls.TipoDocumento;
			arrParam[2].Value = whls.NroDocumento;
			arrParam[3].Value = whls.Nombre;
			arrParam[4].Value = whls.Estado;
			arrParam[5].Value = whls.CantidadDias;
			arrParam[6].Value = whls.VigenciaIndefinida;
			arrParam[7].Value = whls.VigenciaDias;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSI_INSERT_EMPRTOP";
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

		public bool fbooModificar(Whitelist whls, ref string pstrEstado, ref string pstrMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NOMBRE", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RANKING", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEINDE", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEDIAS", DbType.Int32, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = whls.TipoDocumento;
			arrParam[2].Value = whls.NroDocumento;
			arrParam[3].Value = whls.Nombre;
			arrParam[4].Value = whls.Estado;
			arrParam[5].Value = whls.CantidadDias;
			arrParam[6].Value = whls.VigenciaIndefinida;
			arrParam[7].Value = whls.VigenciaDias;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_MODIFI_EMPRTOP";
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
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_ELISEL_EMPRTOP";
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