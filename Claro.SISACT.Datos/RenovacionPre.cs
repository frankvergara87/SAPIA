using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de RenovacionPre.
	/// </summary>
	public class RenovacionPre
	{
		public RenovacionPre()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public int Manten_Periodo_Renov(int Cantidad, int Periodo)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RESULTADO" ,DbType.Int32,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CANTIDAD" ,DbType.Int32,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PERIODO" ,DbType.Int32,ParameterDirection.Input)				
											   };

			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = 0;
			arrParam[1].Value = Cantidad;
			arrParam[2].Value = Periodo;
		
			int salida;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANT_PLN + ".SISACT_MANT_PERIODO_RENOV";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				salida = Funciones.CheckInt16(parSalida1.Value);
			}				
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{					
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}			
			return salida;
		}

		public string ObtienePeriodoRenov()
		{
			DAABRequest.Parameter[] arrParam = {
												new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output)
											   };

			string lista="";
			int i=0;
			arrParam[i].Value = DBNull.Value;

			BDSISACT  obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_MANT_PLN + ".SISACT_CONSULTA_PER_RENOV";
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr=null;
			
			try
			{

				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;	
				while(dr.Read())
				{
					string cantidad = Funciones.CheckStr(dr["TABLN_CANTIDAD"]).Trim();
					string periodo = Funciones.CheckStr(dr["TABLN_PERIODO"]).Trim();
					lista = cantidad + "," + periodo;
				}
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				if(dr != null)
				dr.Close();
				obRequest.Factory.Dispose();
			}
			return lista;
		}



		public string ObtieneUsrSisact(string vUsrNT)
		{
			DAABRequest.Parameter[] arrParam = {
													new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object, ParameterDirection.Output),
													new DAABRequest.Parameter("P_USUAC_CTARED" ,DbType.String,ParameterDirection.Input)
											   };

			string codigo_usuario = "";
			int i=0;
			arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = vUsrNT;
			BDSISACT  obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_DATAENTRY + ".SISACT_DATOSUSUARIO";
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr=null;
			
			try
			{

				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;	
				while(dr.Read())
				{
					codigo_usuario = Funciones.CheckStr(dr["usuan_codigo"]).Trim();
				}
			}
			catch(Exception ex)
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				if(dr != null)
					dr.Close();
				obRequest.Factory.Dispose();
			}
			return codigo_usuario;
		}

	}
}
