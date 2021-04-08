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
	public class DWhiLstCasoEspecial
	{
		public DWhiLstCasoEspecial()
		{
			//
			// TODO: Add constructor logic here 
			//
		}

		# region "Consultas"

		public ArrayList ListarCasoEspecial()
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 
            
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".SP_CON_CASO_ESPECIAL";
                  
			obRequest.Parameters.AddRange(arrParam);
                  
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{                            
					CasoEspecial oCasoEspecial = new CasoEspecial();
					oCasoEspecial.TCESC_CODIGO = Funciones.CheckStr(dr["TCESC_CODIGO"]);
					oCasoEspecial.TCESC_DESCRIPCION = Funciones.CheckStr(dr["TCESC_DESCRIPCION"]);
//					oCasoEspecial.TCEN_MAX_PLANES = Funciones.CheckInt(dr["TCEN_MAX_PLANES"]);
//					oCasoEspecial.TCEN_MAX_PLAN_VOZ = Funciones.CheckInt(dr["TCEN_MAX_PLAN_VOZ"]);
//					oCasoEspecial.TCEN_MAX_PLAN_DATOS = Funciones.CheckInt(dr["TCEN_MAX_PLAN_DATOS"]);
//					oCasoEspecial.FLAG_WHITELIST = Funciones.CheckStr(dr["TCESI_FLAG_WHITELIST"]);
//
//					oCasoEspecial.TCESC_DESCRIPCION2 = oCasoEspecial.TCESC_CODIGO + "_";
//					oCasoEspecial.TCESC_DESCRIPCION2 += oCasoEspecial.FLAG_WHITELIST + "_";
//					oCasoEspecial.TCESC_DESCRIPCION2 += oCasoEspecial.TCEN_MAX_PLANES + "_";
//					oCasoEspecial.TCESC_DESCRIPCION2 += oCasoEspecial.TCEN_MAX_PLAN_VOZ + "_";
//					oCasoEspecial.TCESC_DESCRIPCION2 += oCasoEspecial.TCEN_MAX_PLAN_DATOS;

					filas.Add(oCasoEspecial);
				}
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}
			
		//public DataTable fdtbListarBusqueda(string pstrCasoEspecial, string pstrTipoDocumento, string pstrNroDocumento, string pstrVigenciaInicio, string pstrVigenciaFin, string pstrFechaInicio, string pstrFechaFin)
		public DataTable fdtbListarBusqueda(string pstrCasoEspecial,string pstrTipoDocumento,string pstrNroDocumento,string pstrVigenciaInicio,string pstrVigenciaFin,string pstrFechaInicio,string pstrFechaFin)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CASOESPE", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEINIC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGEFIN", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHINIC", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHFIN", DbType.String, 10, ParameterDirection.Input)
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCasoEspecial;
			arrParam[2].Value = pstrTipoDocumento;
			arrParam[3].Value = pstrNroDocumento;
			arrParam[4].Value = pstrVigenciaInicio;
			arrParam[5].Value = pstrVigenciaFin;
			arrParam[6].Value = pstrFechaInicio;
			arrParam[7].Value = pstrFechaFin;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_LISTAR_WHLSTCASOESPE";
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

		public Whitelist fwhlTraer(Int64 pintSecuencia)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SECUENCIA", DbType.Int64, ParameterDirection.Input)
			}; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pintSecuencia;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSS_TRAER_WHLSTCASOESPE";
			objRequest.Parameters.AddRange(arrParam);

			Whitelist item = new Whitelist();
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					item.Estado = Funciones.CheckStr(dr["tcec_codigo"]);
					item.TipoDocumento = Funciones.CheckStr(dr["docc_codigo"]);
					item.NroDocumento = Funciones.CheckStr(dr["whlv_nro_documento"]);
					item.VigenciaDias = Funciones.CheckInt((dr["whln_vigencia"] != DBNull.Value)? dr["whln_vigencia"] : -1);
					item.FechaRegistro = Funciones.CheckStr(dr["whlv_fecha_registro"]);
					item.MontoDeuda = Funciones.CheckInt((dr["whln_cargo_fijo_max"] != DBNull.Value)? dr["whln_cargo_fijo_max"] : -1);
					item.UsuarioAprobador = Funciones.CheckStr(dr["whlv_usuario_crea"]);
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
												new DAABRequest.Parameter("P_CASOESPE", DbType.String, 2, ParameterDirection.Input),
												new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												new DAABRequest.Parameter("P_VIGE", DbType.Int32, ParameterDirection.Input),
												new DAABRequest.Parameter("P_CARGFIJO", DbType.Single, ParameterDirection.Input),
												new DAABRequest.Parameter("P_USUACREA", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = whls.Estado;
			arrParam[2].Value = whls.TipoDocumento;
			arrParam[3].Value = whls.NroDocumento;
			if (whls.VigenciaDias > -1)
				arrParam[4].Value = whls.VigenciaDias;
			else
				arrParam[4].Value = DBNull.Value;
			if (whls.MontoDeuda > -1)
				arrParam[5].Value = whls.MontoDeuda;
			else
				arrParam[5].Value = DBNull.Value;
			arrParam[6].Value = whls.UsuarioAprobador;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSI_INSERT_WHLSTCASOESPE";
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
												   //new DAABRequest.Parameter("P_CASOESPE", DbType.String, 2, ParameterDirection.Input),
												   //new DAABRequest.Parameter("P_TIPODOCU", DbType.String, 2, ParameterDirection.Input),
												   //new DAABRequest.Parameter("P_NRODOCU", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VIGE", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CARGFIJO", DbType.Single, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SECUENCIA", DbType.Int64, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			//arrParam[1].Value = whls.Estado;
			//arrParam[2].Value = whls.TipoDocumento;
			//arrParam[3].Value = whls.NroDocumento;
			if (whls.VigenciaDias > -1)
				arrParam[1].Value = whls.VigenciaDias;
			else
				arrParam[1].Value = DBNull.Value;
			if (whls.MontoDeuda > -1)
				arrParam[2].Value = whls.MontoDeuda;
			else
				arrParam[2].Value = DBNull.Value;
			arrParam[3].Value = whls.CantidadDias;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_MODIFI_WHLSTCASOESPE";
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
												   new DAABRequest.Parameter("P_SECUENCIAS", DbType.String, 32767, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = DBNull.Value;

			if (strSeleccionados.Length > 0)
				arrParam[1].Value = strSeleccionados;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_GENERAL_II + ".MANTSM_ELISEL_WHLSTCASOESPE";
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