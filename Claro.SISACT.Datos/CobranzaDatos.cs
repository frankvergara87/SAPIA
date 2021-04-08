using System;
using System.Data;
using System.Collections;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Configuration;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de CobranzaDatos.
	/// </summary>
	public class CobranzaDatos
	{
		public CobranzaDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		/* -----------------------------------------------------------------------------------
		 * Objetivo : Permite insertar un ajuste por reclamo
		 * Creación : E77281  / 15-10-2012
		 * -----------------------------------------------------------------------------------*/
		public Int32 InsertarAjustesXReclamos(Int64 vCUSTOMERID, string vCodOCC, string vFecha, string vPeriodo, double vMonto, string vComentario)
		{
			Int32 iRetorno = 0;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_CodCli", DbType.Int64,vCUSTOMERID,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_CodOCC", DbType.String,vCodOCC,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_FecVig", DbType.String,vFecha,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_NumCuo", DbType.String,vPeriodo,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_Monto", DbType.Double,vMonto,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_Coment", DbType.String,vComentario,ParameterDirection.Input),
												   new DAABRequest.Parameter("p_Result", DbType.Int32,ParameterDirection.Output)
											   }; 

			BDBSCS objBSCS = new BDBSCS(BaseDatos.BD_BSCS);

			DAABRequest obRequest = objBSCS.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_BSCS_SIAC_TRAN + ".sp_insert_occ";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);			
			}
			catch( Exception ex )
			{			
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;				
				parSalida1 = (IDataParameter)obRequest.Parameters[obRequest.Parameters.Count-1];
				iRetorno = (Int32)parSalida1.Value;				
				obRequest.Factory.Dispose();
			}
			return iRetorno;
		}
	}
}
