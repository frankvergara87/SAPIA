using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PlanAcuerdo3PlayDatos.
	/// </summary>
	public class PlanAcuerdo3PlayDatos
	{
		public PlanAcuerdo3PlayDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPlanAcuerdo3Play(PlanAcuerdo3Play oPlanAcuerdo3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAZOS", DbType.String, 1000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oPlanAcuerdo3Play.PLNV_CODIGO;
			arrParam[2].Value = oPlanAcuerdo3Play.PLZAC_CODIGO;
			arrParam[3].Value = oPlanAcuerdo3Play.PACUV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PLAN_ACUERDO_3PLAY";
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
				string rMsg = "Error al Insertar en Plan Acuerdo 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public bool EliminarPlanAcuerdo3Play(PlanAcuerdo3Play oPlanAcuerdo3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPlanAcuerdo3Play.PLNV_CODIGO;
			arrParam[1].Value = oPlanAcuerdo3Play.PACUV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_DEL_PLAN_ACUERDO_3PLAY";
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
				string rMsg = "Error al Eliminar en Plan Acuerdo 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}


		public DataTable ListarPlanAcuerdo3Play(string P_PLNV_CODIGO)
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
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PLAN_ACUERDO_3PLAY";
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


	}
}
