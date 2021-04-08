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
	public class DKit
	{
		public DKit()
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
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_MNTO_KIT";
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

		public DataTable fdtbTraer(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_KIT";
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

		public DataTable fdtbListarTipo()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_TIPOKIT";
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

		public DataTable fdtbListarKitEquipo(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_KIT_MATE";
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

		public DataTable fdtbListarEquipoSinKit(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 10, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_KIT_MATE_PEND";
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

		public DataTable ListarTipoOperacion()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_TIPO_OPER";
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
//gaa20120517
		//public bool fbooInsertar(string pstrDescripcion, string pstrTipo, float pfltMonto, string pstrEstado, string pstrUsuario, ref string sEstado, ref string rMsg)
		public bool fbooInsertar(string pstrDescripcion, string pstrTipo,string pstrTipoOpe, float pfltMonto, float pfltCosto, string pstrEstado, string pstrUsuario, ref string sEstado, ref string rMsg)
//fin gaa20120517
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO", DbType.Currency, 9, ParameterDirection.Input),
//gaa20120517
												   new DAABRequest.Parameter("P_COSTO", DbType.Currency, 9, ParameterDirection.Input),
//fin gaa20120517
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_Tipo_Operacion", DbType.String, 10, ParameterDirection.Input)
			};

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrDescripcion;
			arrParam[2].Value = pstrTipo;
			arrParam[3].Value = pfltMonto;
//gaa20120517
//			arrParam[4].Value = pstrEstado;
//			arrParam[5].Value = pstrUsuario;
			arrParam[4].Value = pfltCosto;
			arrParam[5].Value = pstrEstado;
			arrParam[6].Value = pstrUsuario;
			arrParam[7].Value = pstrTipoOpe;
//fin gaa20120517
			

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_KIT";
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
			return salida;
		}

		public bool fbooEliminar(string pstrCodigo, string pstrUsuario, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
													new DAABRequest.Parameter("P_CODIGO", DbType.Int32, 10, ParameterDirection.Input),
													new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
												};
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrUsuario;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_KIT";
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
//gaa20120517
		//public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrTipo, float pfltMonto, string pstrEstado, string pstrUsuario, ref string sEstado, ref string rMsg)
		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrTipo,string pstrTipoOpe, float pfltMonto, float pfltCosto, string pstrEstado, string pstrUsuario, ref string sEstado, ref string rMsg)
//gaa20120517
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MONTO", DbType.Currency, 9, ParameterDirection.Input),
//gaa20120517
												   new DAABRequest.Parameter("P_COSTO", DbType.Currency, 9, ParameterDirection.Input),
//fin gaa20120517
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_OPERACION", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrTipo;
			arrParam[4].Value = pfltMonto;
//gaa20120517
//			arrParam[5].Value = pstrEstado;
//			arrParam[6].Value = pstrUsuario;
			arrParam[5].Value = pfltCosto;
			arrParam[6].Value = pstrEstado;
			arrParam[7].Value = pstrUsuario;
			arrParam[8].Value = pstrTipoOpe;
//fin gaa20120517
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSM_MODIFI_KIT";
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

		public bool fbooKitMaterialEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, 10, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrCodigo;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_KITMATERIAL";
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

		public bool fbooKitMaterialInsertar(string pstrCodigo, string pstrCodMaterial,
			string pstrIDDET, int pintCantidad, string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODMATERIAL", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_MATV_IDDET", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CANTIDAD", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodMaterial;
			arrParam[2].Value = pstrIDDET;
			arrParam[3].Value = pintCantidad;
			arrParam[4].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_KITMATERIAL";
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
			return salida;
		}

		# endregion

	}
}
