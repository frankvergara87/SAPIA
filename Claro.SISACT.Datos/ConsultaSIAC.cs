using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for ConsultaSIAC.
	/// </summary>
	public class ConsultaSIAC
	{
		public ConsultaSIAC()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string ValidaBloqueoLinea(string p_numero_telefono)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_phone", DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("txtbloqueo", DbType.String,ParameterDirection.Output)
											   };

			for (int i = 0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if (p_numero_telefono != null && p_numero_telefono != "") arrParam[0].Value = p_numero_telefono;

			string resultado = "";
			BDSIAC obj = new BDSIAC(BaseDatos.BD_SIAC);
			DAABRequest obRequest = obj.CreaRequest();
            
			try
			{

				obRequest.CommandType = CommandType.StoredProcedure;
				obRequest.Command = BaseDatos.PKG_SIAC_GENERICO + ".valida_bloqueo_linea_detalle";
				obRequest.Parameters.AddRange(arrParam);

            
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
                
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[1];
				resultado = Funciones.CheckStr(parSalida.Value);

			}
			catch (Exception e)
			{
				return e.Message;
			}
			finally
			{
                
				obRequest.Factory.Dispose();
			}
			return resultado;
		
		}
	}
}
