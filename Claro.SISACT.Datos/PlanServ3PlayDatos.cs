using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PlanServ3PlayDatos.
	/// </summary>
	public class PlanServ3PlayDatos
	{
		public PlanServ3PlayDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPlanServ3Play(PlanServ3Play oPlanServ3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_SERVICIOS", DbType.String, 1000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oPlanServ3Play.PLNV_CODIGO;
			arrParam[2].Value = oPlanServ3Play.SERVV_CODIGO;
			arrParam[3].Value = oPlanServ3Play.PSRVV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PLAN_SERV_3PLAY";
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
				string rMsg = "Error al Insertar en Plan Servicio 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public DataTable ListarPlanServ3Play(string P_PLNV_CODIGO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PLNV_CODIGO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PLAN_SERV_3PLAY";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool EliminarPlanServ3Play(string P_PLNV_CODIGO)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_PLNV_CODIGO;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_DEL_PLAN_SERV_3PLAY";
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
				string rMsg = "Error al Eliminar en Plan Servicio 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

//gaa20130724
		public DataTable ListarEquipoxNoPlan(string pstrProductoCodigo, string pstrPlanCodigo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = pstrProductoCodigo;
			arrParam[1].Value = pstrPlanCodigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_CON_MATERIAL_X_NOPLAN";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public DataTable ListarEquipoxPlan(string pstrProductoCodigo, string pstrPlanCodigo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = pstrProductoCodigo;
			arrParam[1].Value = pstrPlanCodigo;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_CON_MATERIAL_X_PLAN";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}

		public bool InsertarPlanEqui3Play(PlanServ3Play oPlanServ3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CADENA", DbType.String, 4000, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oPlanServ3Play.PLNV_CODIGO;
			arrParam[2].Value = oPlanServ3Play.SERVV_CODIGO;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".MANTSS_INS_MATERIAL3P_X_PLAN";
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
				string rMsg = "Error al Insertar en Plan Equipo 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
//fin gaa20130724
//gaa20131104
		public DataTable ListarPlanServicioBSCS(string pstrPlanCodigo)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("p_co_plan", DbType.String, ParameterDirection.Input),
													new DAABRequest.Parameter("p_co_paq", DbType.String, ParameterDirection.Input),
													new DAABRequest.Parameter("p_co_ser", DbType.String, ParameterDirection.Input),
												    new DAABRequest.Parameter("p_cursor", DbType.Object, ParameterDirection.Output)
												}; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
		
			arrParam[0].Value = pstrPlanCodigo;
		
			BDBSCS oBDBSCS = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest oDAABRequest = oBDBSCS.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = "tim.pp006_sisact.sp_consultar_asocplanxserv";
			oDAABRequest.Parameters.AddRange(arrParam);

			try
			{
				dtResultado = oDAABRequest.Factory.ExecuteDataset(ref oDAABRequest).Tables[0];
			}
			catch( Exception ex )
			{
				throw ex;
			}
			finally
			{			
				oDAABRequest.Parameters.Clear();
				oDAABRequest.Factory.Dispose();
			}
			return dtResultado;
		}
//fin gaa20131104
	}
}
