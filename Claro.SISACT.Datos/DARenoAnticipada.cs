using System;
using Claro.SisAct.Entidades;
using System.Data;
using System.Collections;
using Claro.SisAct.Common;
using Claro.SisAct.DAAB;

namespace Claro.SisAct.Datos
{
	
	public class DARenoAnticipada
	{
		public DARenoAnticipada()
		{
			
		}



		public bool RegRenoAnticipada(BERenoAnti oRenoAnticipada,ref string oCodRpta, ref string oMensaje)
		{
			DAABRequest.Parameter[] arrParam ={	
												  new DAABRequest.Parameter("N_NRO_PEDIDO", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_NRO_CONTRATO", DbType.Int64, ParameterDirection.Input),													
												  new DAABRequest.Parameter("V_MSISDN", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CO_ID", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_CUSTOMER_ID", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_TIPO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_NRO_DOCUMENTO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_TIPO_CLIENTE", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_COD_EQUIPO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_COD_MATERIAL", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_ESTADO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_TIPO_RENOVACION", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_NRO_SEC", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_ID_ACUERDO", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("D_FECHA_ACUERDO", DbType.Date, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_ESTADO_ACUERDO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_MONTO_ORIGINAL", DbType.Double, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_MONTO_REINTEGRO", DbType.Double, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_MONTO_FIDELIZA", DbType.Double, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_FLAG_APLICA_REINTEGRO", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_FLAG_FIDELIZA", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("CL_DATOS_ACTUALIZA", DbType.String, 32000, ParameterDirection.Input),

												  new DAABRequest.Parameter("CL_DATOS_ROLLBACK", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("CL_OBSERVACIONES", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("N_ID_ACUERDO_SIGA", DbType.Int64, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_COD_EQUIPO_CANJE", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_COD_MATERIAL_CANJE", DbType.String, ParameterDirection.Input),
												  

												  new DAABRequest.Parameter("V_BD_ORIGEN", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_CANAL", DbType.String, ParameterDirection.Input),
												  new DAABRequest.Parameter("V_USU_CREACION", DbType.String, ParameterDirection.Input),

												  new DAABRequest.Parameter("P_CODIGO_RESPUESTA", DbType.Int64, ParameterDirection.Output),
												  new DAABRequest.Parameter("P_MENSAJE_RESPUESTA", DbType.String, ParameterDirection.Output),

											  };

			bool retorno = false;
			int i = 0;
			for (i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = oRenoAnticipada.N_NRO_PEDIDO;
			arrParam[1].Value = oRenoAnticipada.N_NRO_CONTRATO;
			arrParam[2].Value = oRenoAnticipada.V_MSISDN;
			arrParam[3].Value = oRenoAnticipada.V_CO_ID;
			arrParam[4].Value = oRenoAnticipada.N_CUSTOMER_ID;
			arrParam[5].Value = oRenoAnticipada.V_TIPO_DOCUMENTO;
			arrParam[6].Value = oRenoAnticipada.N_NRO_DOCUMENTO;
			arrParam[7].Value = oRenoAnticipada.V_TIPO_CLIENTE;
			arrParam[8].Value = oRenoAnticipada.V_COD_EQUIPO;
			arrParam[9].Value = oRenoAnticipada.V_COD_MATERIAL;
			arrParam[10].Value = oRenoAnticipada.V_ESTADO;
			arrParam[11].Value = oRenoAnticipada.V_TIPO_RENOVACION;
			arrParam[12].Value = oRenoAnticipada.N_NRO_SEC;
			arrParam[13].Value = oRenoAnticipada.N_ID_ACUERDO;
			arrParam[14].Value = oRenoAnticipada.D_FECHA_ACUERDO;
			arrParam[15].Value = oRenoAnticipada.V_ESTADO_ACUERDO;
			arrParam[16].Value = oRenoAnticipada.N_MONTO_ORIGINAL;
			arrParam[17].Value = oRenoAnticipada.N_MONTO_REINTEGRO;
			arrParam[18].Value = oRenoAnticipada.N_MONTO_FIDELIZA;
			arrParam[19].Value = oRenoAnticipada.V_FLAG_APLICA_REINTEGRO;
			arrParam[20].Value = oRenoAnticipada.V_FLAG_FIDELIZA;
			arrParam[21].Value = oRenoAnticipada.CL_DATOS_ACTUALIZA;

			arrParam[22].Value = ""; //CL_DATOS_ROLLBACK
			arrParam[23].Value = ""; //CL_OBSERVACIONES
			arrParam[24].Value = 0; //N_ID_ACUERDO_SIGA
			arrParam[25].Value = ""; //V_COD_EQUIPO_CANJE
			arrParam[26].Value = ""; //V_COD_MATERIAL_CANJE

			arrParam[27].Value = oRenoAnticipada.V_BD_ORIGEN;
			arrParam[28].Value = oRenoAnticipada.V_CANAL;
			arrParam[29].Value = oRenoAnticipada.V_USU_CREACION;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_RENO_ANTICIPADA + ".SISACTSI_ACUERDO_RENOVACION";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);

				IDataParameter parSalida;
				IDataParameter parSalida2;
				parSalida = (IDataParameter)obRequest.Parameters[30];
				parSalida2 = (IDataParameter)obRequest.Parameters[31];
				oCodRpta = Funciones.CheckStr(parSalida.Value);
				oMensaje = Funciones.CheckStr(parSalida2.Value);

				retorno = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return retorno;
		}


	}
}

