using System;
using System.Data;
using System.Collections;
using System.Reflection;

using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de VasDatos.
	/// </summary>
	public class ServicioVasDatos
	{
		public ServicioVasDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public ArrayList ListaPaqueteVas(int vas_codigo)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("P_VSERN_COD_VAS", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(!vas_codigo.Equals("")) arrParam[0].Value = vas_codigo;
			
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SERVICIO_VAS + ".SISACT_CONS_PAQUETE";
			
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					TipoPaqueteVas  item = new TipoPaqueteVas ();		
					item.VASN_CODIGO  = Funciones.CheckInt(dr["VSERN_COD_PAQ"]);								
					item.DESV_PAQUETE  = Funciones.CheckStr(dr["VPAQV_DES_PAQ"]);
					item.DESV_DET_PAQUETE  = Funciones.CheckStr(dr["DETALLE_PAQUETE"]);
					item.COSTN_SERVICIO =Funciones.CheckDbl(dr["VSERN_COS_SERV"]);
					item.FRECV_TIEMPO = Funciones.CheckStr(dr["VSERV_FRECUENCIA"]);

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


		public bool InsertarVas(ServicioVas objDetalle)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("K_RESULTADO" ,DbType.Int64,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_VSERC_CLIE_TIP_DOC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERV_CLIE_DOC" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERV_CLIE_TELF" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERN_COD_PAQ" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERV_DIR_EMAIL" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERN_COD_PROV" ,DbType.Int64,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_VSERN_COD_VAS" ,DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERV_USU_CREA" ,DbType.String,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERN_COS_SERV" ,DbType.Double,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_VSERV_FRECUENCIA" ,DbType.String,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_VSERC_FLAG_ACT" ,DbType.String,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_VSERC_FLAG_TIPF" ,DbType.String,ParameterDirection.Input)
											   }; 
 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			arrParam[1].Value = objDetalle.VSERC_CLIE_TIP_DOC;
			arrParam[2].Value = objDetalle.VSERV_CLIE_DOC;
			arrParam[3].Value = objDetalle.VSERV_CLIE_TELF;
			arrParam[4].Value = objDetalle.VSERN_COD_PAQ;
			arrParam[5].Value = objDetalle.VSERV_DIR_EMAIL;
			arrParam[6].Value = objDetalle.VSERN_COD_PROV;
			arrParam[7].Value = objDetalle.VSERN_COD_VAS;
			arrParam[8].Value = objDetalle.VSERV_USU_CREA;
			arrParam[9].Value = objDetalle.VSERN_COS_SERV;
			arrParam[10].Value = objDetalle.VSERV_FRECUENCIA;
			arrParam[11].Value = objDetalle.VSERC_FLAG_ACT;
			arrParam[12].Value = objDetalle.VSERC_FLAG_TIPF;

			bool salida = false;
                                   
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);    
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;                   
			obRequest.Command = BaseDatos.PKG_SISACT_SERVICIO_VAS + ".SISACT_INS_ACTIVACION_VAS";
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
				throw ex;
			}
			finally
			{                            
				IDataParameter pSalida1;
				pSalida1 = (IDataParameter)obRequest.Parameters[0];
				obRequest.Factory.Dispose();
			}                 
			return salida ;
		}

		public ArrayList ListarParametroConfig(int intCodigoParametro)
		{
			ArrayList lisRetorno=new ArrayList();
			DAABRequest.Parameter[] arrParam =
				{
					new DAABRequest.Parameter("P_CODIGO",DbType.Int64,ParameterDirection.Input),
					new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)
				};			
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = intCodigoParametro;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SERVICIO_VAS + ".SISACT_CONFIG_PARAM";
			obRequest.Parameters.AddRange(arrParam);
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ParametroConsumer itm = new ParametroConsumer();
					itm.PCONI_CODIGO = dr["PCONI_CODIGO"].ToString();					
					itm.PCONV_DESCRIPCION = dr["PCONV_DESCRIPCION"].ToString();					
					itm.PCONV_VALOR = dr["PCONV_VALOR"].ToString();										
					itm.PCONV_MENSAJE =dr["PCONV_MENSAJE"].ToString();					
					lisRetorno.Add(itm);
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


			return lisRetorno;
		}

		//**************************************** INICIO WHZR ****************************************************

		public string ListarOpcionVas(int intCodigoVas)
		{			
			string strOpcionVas = "";

			DAABRequest.Parameter[] arrParam = {new DAABRequest.Parameter("P_CODIGO_VAS", DbType.Int32, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output)}; 
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = intCodigoVas;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_SERVICIO_VAS + ".SISACT_OPCION_VAS";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					//ServicioVas itm = new ServicioVas();
					strOpcionVas = Funciones.CheckStr(dr["VPAQV_NOM_OPCION"]);					
									
					
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
			return strOpcionVas;
		}


		//**************************************** FIN WHZR ****************************************************



	}
}
