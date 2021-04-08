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
	public class DCampana
	{
		public DCampana()
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
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_MNTO_CAMP";
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
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrServCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_TRAER_CAMP";
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

		public DataTable fdtbListarCampanaPV(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_PUVE";
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

		public DataTable fdtbListarPVSinCampana(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_PUVE_PEND";
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

		public DataTable fdtbListarCampanaPlan(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_PLAN";
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

		public DataTable fdtbListarPlanSinCampana(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_PLAN_PEND";
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

		public DataTable fdtbListarCampanaKit(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_KIT";
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

		public DataTable fdtbListarKitSinCampana(string pstrCodigo)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.Int32, ParameterDirection.Input)												   
											   }; 
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSS_LISTAR_CAMP_KIT_PEND";
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

		public bool fbooInsertar(string pstrCodigo, string pstrDescripcion, string pstrPromocion, string pstrTipoProd,string pstrEstado, string pstrUsuario, DateTime pdtmFechaInicio, 
			DateTime pdtmFechaFin,string CFPromocional,string fechaIniProm,string fechaFinProm, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROMOCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOPRODUCTO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAINI", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAFIN", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cf_promocional", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_fecha_ini_prom", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_fecha_fin_prom", DbType.Date, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrPromocion;
			arrParam[4].Value = pstrTipoProd;
			arrParam[5].Value = pstrEstado;
			arrParam[6].Value = pdtmFechaInicio;
			arrParam[7].Value = pdtmFechaFin;
			arrParam[8].Value = pstrUsuario;
			if(CFPromocional !="") arrParam[9].Value = Funciones.CheckDbl(CFPromocional);
			if(fechaIniProm !="") arrParam[10].Value = fechaIniProm;
			if(fechaFinProm !="") arrParam[11].Value = fechaFinProm;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_CAMP";
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
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };
			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrUsuario;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_CAMP";
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

		public bool fbooModificar(string pstrCodigo, string pstrDescripcion, string pstrPromocion,string pstrTipoProd, string pstrEstado, string pstrUsuario, DateTime pdtmFechaInicio, 
			DateTime pdtmFechaFin,string CFPromocional,string fechaIniProm,string fechaFinProm, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PROMOCION", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPOPRODUCTO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAINI", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FECHAFIN", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cf_promocional", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_fecha_ini_prom", DbType.Date, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_fecha_fin_prom", DbType.Date, ParameterDirection.Input)
											   };

			arrParam[0].Value = DBNull.Value;
			arrParam[1].Value = pstrCodigo;
			arrParam[2].Value = pstrDescripcion;
			arrParam[3].Value = pstrPromocion;
			arrParam[4].Value = pstrTipoProd;
			arrParam[5].Value = pdtmFechaInicio;
			arrParam[6].Value = pdtmFechaFin;
			arrParam[7].Value = pstrEstado;
			arrParam[8].Value = pstrUsuario;
			if(CFPromocional !="") arrParam[9].Value = Funciones.CheckDbl(CFPromocional);
			if(fechaIniProm !="") arrParam[10].Value = fechaIniProm;
			if(fechaFinProm !="") arrParam[11].Value = fechaFinProm;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSM_MODIFI_CAMP";
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

		public bool fbooCampanaPVEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrCodigo;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_CAMPPV";
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

		public bool fbooCampanaPlanEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrCodigo;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_CAMPPLAN";
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

		public bool fbooCampanaKitEliminar(string pstrCodigo, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input)
											   };
			arrParam[0].Value = pstrCodigo;
			
			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSD_ELIMIN_CAMPKIT";
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

		public bool fbooCampanaPVInsertar(string pstrCodigo, string pstrCodPV,
			string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODPV", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodPV;
			arrParam[2].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_CAMP_PUVE";
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

		public bool fbooCampanaPlanInsertar(string pstrCodigo, string pstrCodPlan,
			string pstrUsuario, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CODPLAN", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input)
											   };

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrCodPlan;
			arrParam[2].Value = pstrUsuario;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_CAMP_PLAN";
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
		
		public bool fbooCampanaPVPLInsertar(string pstrCodigo, string pstrUsuario, 
			string pstrPDVs, string pstrPlanes, ref string sEstado, ref string rMsg)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PDVs", DbType.String, 32767, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANES", DbType.String, 32767, ParameterDirection.Input)
											   };

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = pstrCodigo;
			arrParam[1].Value = pstrUsuario;
			if (pstrPDVs.Length > 0)
				arrParam[2].Value = pstrPDVs;
			if (pstrPlanes.Length > 0)
				arrParam[3].Value = pstrPlanes;

			bool salida = false;
			BDSISMANT obj = new BDSISMANT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DTH + ".MANTSI_INSERT_CAMP_PVPL";
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