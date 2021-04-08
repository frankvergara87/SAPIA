using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for PaquetePlan3PlayDatos.
	/// </summary>
	public class PaquetePlan3PlayDatos
	{
		public PaquetePlan3PlayDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//ldrz
		public bool InsertarPaqueteDetalle3Play(PaquetePlan3Play oPaquetePlan3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 5,  ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQUETE_PLAN", DbType.String, 5000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = oPaquetePlan3Play.PRDC_CODIGO;
			arrParam[2].Value = oPaquetePlan3Play.PAQTV_CODIGO;
			arrParam[3].Value = oPaquetePlan3Play.PAQUETE_PLAN;
			arrParam[4].Value = oPaquetePlan3Play.PAQPV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PAQUETE_DET_3PLAY";
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
				string rMsg = "Error al Insertar en Paquete Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool InsertarPaquetePlan3Play(PaquetePlan3Play oPaquetePlan3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PAQPN_SECUENCIA", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLNV_CODIGO", DbType.String, 4, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPaquetePlan3Play.PAQPN_SECUENCIA;
			arrParam[1].Value = oPaquetePlan3Play.PAQTV_CODIGO;
			arrParam[2].Value = oPaquetePlan3Play.PLNV_CODIGO;
			arrParam[3].Value = oPaquetePlan3Play.PAQPV_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PAQUETE_PLAN_3PLAY";
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
				string rMsg = "Error al Insertar en Paquete Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}
//ldrz
		public bool EliminarPaquetePlan3Play(string P_PRDC_CODIGO,string P_PAQTV_CODIGO)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_PRDC_CODIGO;
			arrParam[1].Value = P_PAQTV_CODIGO;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_DEL_PAQUETE_PLAN_3PLAY";
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
				string rMsg = "Error al Eliminar en Paquete Plan 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		//ldrz
                public DataTable ListarPaquetePlan3Play(string P_PRDC,string P_PAQTV_CODIGO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PRDC;
			arrParam[1].Value = P_PAQTV_CODIGO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PAQUETE_PLAN_3PLAY";
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
