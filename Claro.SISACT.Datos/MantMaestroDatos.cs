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
	/// Summary description for MantMaestroDatos.
	/// </summary>
	public class MantMaestroDatos
	{
		public MantMaestroDatos()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ObtenerValorContingenciaDC(int codParametro) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CODPARAMETRO", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("K_VALOR", DbType.String, ParameterDirection.Output)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			i=0;
			arrParam[i].Value = codParametro;      
			string salida = "";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 
			obRequest.Command = BaseDatos.PCK_MANT_TABLAS + ".MANTSS_OBTENER_VALOR_CONT_DC";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			int bb;
			try
			{
				bb=Convert.ToInt16(obRequest.Factory.ExecuteScalar(ref obRequest));
				obRequest.Factory.CommitTransaction();
			}
			catch( Exception ex )
			{
				obRequest.Factory.RollBackTransaction();
				throw ex;
			}
			finally
			{
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				salida = Funciones.CheckStr(parSalida1.Value);
				obRequest.Factory.Dispose();
			}                 
			return salida;
		}

		public ArrayList ListaTablaGeneralSISACT(string tipo,string estado )//SE REPLICO METODO DE MAESTRO DATOS SE CAMBIO LA CLACE ITEM PARA LLENAR GRID
		{			
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_TABLN_TIPO", DbType.String,2,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TABLN_ESTADO", DbType.String,1,ParameterDirection.Input),
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			arrParam[0].Value = tipo;
			arrParam[1].Value = estado;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TABLA_TABLAS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					TabladeTablas item = new TabladeTablas();
					item.TABLN_CODIGO= Funciones.CheckStr(dr["TABLN_CODIGO"]);
					item.TABLN_DESCRIPCION = Funciones.CheckStr(dr["TABLN_DESCRIPCION"]);										
					item.TABLN_ORDEN = Funciones.CheckStr(dr["TABLN_ORDEN"]) ;					
					item.TABLN_ESTADO = Funciones.CheckStr(dr["TABLN_ESTADO"]) ;					
					item.TABLN_TIPO= Funciones.CheckStr(dr["TABLN_TIPO"]) ;					
					item.TABLN_FLAG_SISTEMA= Funciones.CheckStr(dr["TABLN_FLAG_SISTEMA"]) ;	

					filas.Add(item);
				}
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return filas;
		}

	}
}
