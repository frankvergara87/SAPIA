using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for Paquete3PlayDatos.
	/// </summary>
	public class Paquete3PlayDatos
	{
		public Paquete3PlayDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool InsertarPaquete3Play(Paquete3Play oPaquete3Play, ref string sEstado, ref string rMsg)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPAQTV_CODIGO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPDOC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.String, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPaquete3Play.PAQTV_CODIGO;
			arrParam[1].Value = oPaquete3Play.PAQTV_DESCRIPCION;
			arrParam[2].Value = oPaquete3Play.PAQTC_ESTADO;
			arrParam[3].Value = oPaquete3Play.PAQTV_USUARIO_CREA;
			arrParam[4].Value = oPaquete3Play.TPAQTV_CODIGO; 
			arrParam[5].Value = oPaquete3Play.TPROC_CODIGO; 
			arrParam[6].Value = oPaquete3Play.PLANC_CODIGO; 
			arrParam[7].Value = oPaquete3Play.TPDOC_CODIGO; 
			arrParam[8].Value = oPaquete3Play.PRDC_CODIGO; 

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_INS_PAQUETE_3PLAY";
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
				rMsg = "Error al Insertar Paquete 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[9];//Parameters[0]
				sEstado = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		public bool ActualizarPaquete3Play(Paquete3Play oPaquete3Play)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_DESCRIPCION", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPAQTV_CODIGO", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPROC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLANC_CODIGO", DbType.String, 3, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TPDOC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String, 1, ParameterDirection.Input)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oPaquete3Play.PAQTV_CODIGO;
			arrParam[1].Value = oPaquete3Play.PAQTV_DESCRIPCION;
			arrParam[2].Value = oPaquete3Play.TPAQTV_CODIGO; 
			arrParam[3].Value = oPaquete3Play.TPROC_CODIGO; 
			arrParam[4].Value = oPaquete3Play.PLANC_CODIGO; 
			arrParam[5].Value = oPaquete3Play.TPDOC_CODIGO; 
			arrParam[6].Value = oPaquete3Play.PRDC_CODIGO; 
			arrParam[8].Value = oPaquete3Play.PAQTC_ESTADO; 

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_UPD_PAQUETE_3PLAY";
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
				string rMsg = "Error al Modificar en Paquete 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		//ldrz
public bool EliminarPaquete3Play(string P_PRDC_CODIGO,string P_PAQTV_CODIGO, string P_USUARIO_CREA)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_USUARIO_CREA", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_RESULTADO", DbType.Int32, ParameterDirection.Output)
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = P_PRDC_CODIGO;
			arrParam[1].Value = P_PAQTV_CODIGO;
			arrParam[2].Value = P_USUARIO_CREA;

			bool salida = false;
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);

			DAABRequest obRequest = oBDSISACT.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_DEL_PAQUETE_3PLAY";
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
				string rMsg = "Error al Eliminar en Paquete 3Play. \nMensaje : " + ex.Message;
				throw ex;
			}
			finally
			{
				obRequest.Factory.Dispose();
			}			
			return salida ;
		}

		//ldrz
public DataTable ListarPaquete3Play(string P_PRDC,string P_PAQTV_CODIGO, string P_PAQTV_DESCRIPCION, string P_ESTADO)
		{
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PRDC", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_CODIGO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PAQTV_DESCRIPCION", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = P_PRDC;
			arrParam[1].Value = P_PAQTV_CODIGO;
			arrParam[2].Value = P_PAQTV_DESCRIPCION;
			arrParam[3].Value = P_ESTADO;
			
			BDSISACT oBDSISACT = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest oDAABRequest = oBDSISACT.CreaRequest();
			oDAABRequest.CommandType = CommandType.StoredProcedure;
			oDAABRequest.Command = BaseDatos.PKG_SISACT_MANTENIMIENTO_3PLAY + ".SISACT_SEL_PAQUETE_3PLAY";
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

// ldrz, maquino
		public DataTable fdtbListarProductos()
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = DBNull.Value;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_MANT_POSTVENTA + ".SP_CON_TIPO_PRODUCTO";
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


	}
}
