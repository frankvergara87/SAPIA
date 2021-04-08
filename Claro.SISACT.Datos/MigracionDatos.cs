using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de MigracionDatos.
	/// </summary>
	public class MigracionDatos
	{
		public MigracionDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public bool RegistrarMigracion(Claro.SisAct.Entidades.DetalleTransaccion detalle,ref string rFlagInsercion ,ref string rMsgText)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("co_id", DbType.Int64,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servd_fechaprog", DbType.Date,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servd_fecha_reg", DbType.Date,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servc_estado", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servc_esbatch", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_usuario_sistema", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_id_eai_sw", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servi_cod", DbType.Int64,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_msisdn", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_usuario_aplicacion", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_email_usuario_app", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("servv_xmlentrada", DbType.String,8000,ParameterDirection.Input), 
												   new DAABRequest.Parameter("nro_cuenta", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("punto_venta", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("asesor", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("codigo_interaccion", DbType.String,ParameterDirection.Input), 
												   new DAABRequest.Parameter("resp", DbType.Int16,ParameterDirection.Output),  
												   new DAABRequest.Parameter("mensaje", DbType.String,ParameterDirection.Output)};




			for(int j=0;j<arrParam.Length;j++)
				arrParam[j].Value = System.DBNull.Value;

			int i=0;
			if(detalle.CO_ID!=0){
				arrParam[i].Value =Funciones.CheckInt64(detalle.CO_ID);	//CO_ID					
			}			
			
			i++;
			if( detalle.SERVD_FECHAPROG != null )
				arrParam[i].Value =Funciones.CheckDate(detalle.SERVD_FECHAPROG);	//SERVD_FECHAPROG
			
			i++;
			if( detalle.SERVD_FECHA_REG != null )
				arrParam[i].Value =Funciones.CheckDate(detalle.SERVD_FECHA_REG);	//SERVD_FECHA_REG
			
			i++;			
			if( detalle.SERVC_ESTADO != null )
				arrParam[i].Value =detalle.SERVC_ESTADO;	//SERVC_ESTADO


			i++;
			if( detalle.SERVC_ESBATCH  != null )
				arrParam[i].Value =detalle.SERVC_ESBATCH;	//SERVC_ESBATCH
			
			i++;
			if( detalle.SERVV_USUARIO_SISTEMA != null )
				arrParam[i].Value =detalle.SERVV_USUARIO_SISTEMA;	//SERVV_USUARIO_SISTEMA
			
			i++;
			if( detalle.SERVV_ID_EAI_SW != null )
				arrParam[i].Value =detalle.SERVV_ID_EAI_SW;	//SERVV_ID_EAI_SW
			
			i++;
			if( detalle.SERVI_COD != -1 )
				arrParam[i].Value =Funciones.CheckInt64(detalle.SERVI_COD);	//SERVI_COD
			
			i++;
			if( detalle.SERVV_MSISDN != null )
				arrParam[i].Value =detalle.SERVV_MSISDN;	//SERVV_MSISDN

			i++;
			if( detalle.SERVV_USUARIO_APLICACION != null )
				arrParam[i].Value =detalle.SERVV_USUARIO_APLICACION; //SERVV_USUARIO_APLICACION

			i++;
			if( detalle.SERVV_EMAIL_USUARIO_APP != null )
				arrParam[i].Value =detalle.SERVV_EMAIL_USUARIO_APP;	//SERVV_EMAIL_USUARIO_APP

			//			i++;
			//			if( detalle.SERVV_ID_BATCH != null )
			//				arrParam[i].Value =detalle.SERVV_ID_BATCH;	//SERVV_ID_BATCH

			i++;
			if( detalle.SERVV_XMLENTRADA  != null )
				arrParam[i].Value =detalle.SERVV_XMLENTRADA; //SERVV_XMLENTRADA

			i++;
			if( detalle.SERVC_NROCUENTA != null )
				arrParam[i].Value =detalle.SERVC_NROCUENTA; //SERVC_NROCUENTA

			i++;
			if( detalle.SERVC_PUNTOVENTA != null )
				arrParam[i].Value =detalle.SERVC_PUNTOVENTA; //SERVC_PUNTOVENTA

			i++;
			if( detalle.SERVC_ASESOR!= null )
				arrParam[i].Value =detalle.SERVC_ASESOR; //SERVC_ASESOR

			i++;
			if( detalle.SERVC_CODIGO_INTERACCION!= null )
				arrParam[i].Value =detalle.SERVC_CODIGO_INTERACCION; //SERVC_CODIGO_INTERACCION

			i++;
			if( detalle.SERVV_COD_ERROR != null )
				arrParam[i].Value =detalle.SERVV_COD_ERROR; //SERVV_COD_ERROR

			i++;
			if( detalle.SERVV_MEN_ERROR != null )
				arrParam[i].Value =detalle.SERVV_MEN_ERROR; //SERVV_MEN_ERROR

		    
			SISACTDatosBDEAI obj = new SISACTDatosBDEAI(BaseDatos.BD_EAI);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_PROCESO_MIGRACION + ".PMPC_REGISTRARPOS_SERVICIOPROG";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
						
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{						
				IDataParameter parSalida1 ,parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-2];
				parSalida2 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];				
				rFlagInsercion = Funciones.CheckStr(parSalida1.Value) ;
				rMsgText  = Funciones.CheckStr(parSalida2.Value) ;
				rMsgText = rFlagInsercion + ";" + rMsgText;

				obRequest.Factory.Dispose();
			}
			return true;
		}

	}
}
