using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Configuration;
using Claro.SisAct.Common;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Diagnostics;
using Claro.SisAct.DAAB;




namespace Claro.SisAct.Datos
{
	//PROY-24724-IDEA-28174 - CLASE NUEVA
	public class DAProteccionMovil
	{
		public void BorrarServicioProteccionMovil(string strNroSec, string strCodServProteccionMovil,string strCodSolPlan, ref string strCodRespuesta, ref string strMsjRespuesta)
		{
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("K_COD_SEC", DbType.Int64, ParameterDirection.Input),
												 new DAABRequest.Parameter("K_COD_SERV", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_SLPLN_CODIGO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_MSJ_RESULTADO", DbType.String, ParameterDirection.Output)
											   };
			arrParam[0].Value = Funciones.CheckInt64(strNroSec);
			arrParam[1].Value = strCodServProteccionMovil;
			arrParam[2].Value = Funciones.CheckInt64(strCodSolPlan);

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			//objRequest.Command = BaseDatos.SISACT_PKG_TRANS_ASURION + ".SISACTSD_BORRAR_SERV_EVAL";
			objRequest.Command = BaseDatos.SISACT_PKG_TRANS_ASURION + ".SISACTSD_BORRAR_SERV_VENTA";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[3];
				strCodRespuesta = Funciones.CheckStr(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)objRequest.Parameters[4];
				strMsjRespuesta = Funciones.CheckStr(parSalida2.Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
		}//

		public void EliminarProteccionMovil (string strNroSec, string strNroCertificado,ref string strCodRespuesta, ref string strMsjRespuesta)
		{
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("K_NRO_SEC", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CERTIF_TEMP", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_COD_RESULTADO", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("K_MSJ_RESULTADO", DbType.String, ParameterDirection.Output)
											   };
			arrParam[0].Value = Funciones.CheckInt64(strNroSec);
			arrParam[1].Value = strNroCertificado;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT); 
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.SISACT_PKG_TRANS_ASURION + ".SISACTSU_ELIMINA_EVAL_SEGURO";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);

				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[2];
				strCodRespuesta = Funciones.CheckStr(parSalida1.Value);

				IDataParameter parSalida2;
				parSalida2 = (IDataParameter)objRequest.Parameters[3];
				strMsjRespuesta = Funciones.CheckStr(parSalida2.Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
		}

	}
}



