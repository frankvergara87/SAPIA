using System;
using System.Data;
using System.Collections;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de VentaDatos.
	/// </summary>
	public class VentaDatos
	{
		public VentaDatos() 
		{
		}
		public String ObtenerNroHLR(string Msisdn)
		{			
			DAABRequest.Parameter[] arrParam = { new DAABRequest.Parameter("K_TELEFONO", DbType.String,ParameterDirection.Input),
												 new DAABRequest.Parameter("K_RESULTADO", DbType.Int64,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			if ( Msisdn != null && Msisdn != "" ) arrParam[0].Value = Msisdn;

			String resultado = "";
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);				
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_EXPRESS_PORTABILIDAD + ".ADMS_TABLA_NROHLR_TELEFONO";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();								
			}
			catch{}
			finally
			{	
				IDataParameter parSalida;
				parSalida = (IDataParameter)obRequest.Parameters[1];
				resultado = Funciones.CheckStr(parSalida.Value);				
				obRequest.Factory.Dispose();				
			}
			return resultado;
		}
		public bool ConsultaValidacionCliente(string tipoDocumento, string nroDocumento, string nroTelefono, ref string flag_valida, ref string msg_text)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_PHONE", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOC", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_VALIDA", DbType.String,20,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSG_TEXT", DbType.String,200,ParameterDirection.Output),
												   new DAABRequest.Parameter("REFCURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i;
			bool retorno = true;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = nroTelefono;
			++i; arrParam[i].Value = tipoDocumento;
			++i; arrParam[i].Value = nroDocumento;

			Clarify obj = new Clarify(BaseDatos.BD_CLARIFY);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_CUSTOMER_CLFY + ".SP_VALIDATITULARIDAD";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{				
				flag_valida = "";
				msg_text = "Error Conexion a BD Clarify: " + e.Message; 
				retorno = false;
			}
			finally
			{
				IDataParameter parSalida1, parSalida2;	
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				parSalida2 = (IDataParameter)obRequest.Parameters[4];
				flag_valida = Funciones.CheckStr(parSalida1.Value);
				msg_text = Funciones.CheckStr(parSalida2.Value);
				obRequest.Factory.Dispose();
			}
			return retorno;			
		}
		public ArrayList ListaTipoDocumento(string flag_ruc)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLAG_CON", DbType.String,1,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(flag_ruc != "") arrParam[0].Value = flag_ruc;
			
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS + ".SISACT_CON_TIPO_DOC";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["TDOCC_CODIGO"]);
					item.Descripcion = Funciones.CheckStr(dr["TDOCV_DESCRIPCION"]);
					item.Codigo2 = Funciones.CheckStr(dr["ID_CCLUB"]);
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
		public ArrayList ListaPDVUsuario(Int64 cod_usuario,string cod_producto)
		{			

			DAABRequest.Parameter[] arrParam = {   new DAABRequest.Parameter("K_USUAN_CODIGO", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_TPROC_CODIGO", DbType.String,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("K_CUR_SALIDA", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			if(cod_usuario > 0) arrParam[0].Value = cod_usuario;
			arrParam[1].Value = cod_producto;
			

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTAS+ ".SECSS_CON_PDV_X_USUARIO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					PuntoVenta item = new PuntoVenta();					
					item.OVENC_CODIGO= Funciones.CheckStr(dr["OVENC_CODIGO"]);								
					item.OVENV_DESCRIPCION= Funciones.CheckStr(dr["OVENV_DESCRIPCION"]) + " - " + Funciones.CheckStr(dr["OVENC_CODIGO"]);
					item.TOFIC_CODIGO= Funciones.CheckStr(dr["TOFIC_CODIGO"]);
					item.CANAC_CODIGO= Funciones.CheckStr(dr["CANAC_CODIGO"]);
					item.OVENC_REGION= Funciones.CheckStr(dr["OVENC_REGION"]);
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

		public bool ConsultaValidacionClientePostpago(string tipoDocumento, string nroDocumento, string nroTelefono, ref string flag_valida, ref string msg_text)
		{
			DAABRequest.Parameter[] arrParam = {												   
												   new DAABRequest.Parameter("P_PHONE", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NUM_DOC", DbType.String,20,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_FLAG_VALIDA", DbType.String,20,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_MSG_TEXT", DbType.String,200,ParameterDirection.Output),
												   new DAABRequest.Parameter("REFCURSOR", DbType.Object,ParameterDirection.Output)
											   }; 
			int i;
			bool retorno = true;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = nroTelefono;
			++i; arrParam[i].Value = tipoDocumento;
			++i; arrParam[i].Value = nroDocumento;

			Clarify obj = new Clarify(BaseDatos.BD_CLARIFY);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.NOMBRE_PACKAGE_CUSTOMER_CLFY + ".SP_VALIDATITULARIDAD";
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
			}
			catch(Exception e)
			{				
				flag_valida = "";
				msg_text = "Error Conexion a BD Clarify: " + e.Message; 
				retorno = false;
			}
			finally
			{
				IDataParameter parSalida1, parSalida2;	
				parSalida1 = (IDataParameter)obRequest.Parameters[3];
				parSalida2 = (IDataParameter)obRequest.Parameters[4];
				flag_valida = Funciones.CheckStr(parSalida1.Value);
				msg_text = Funciones.CheckStr(parSalida2.Value);
				obRequest.Factory.Dispose();
			}
			return retorno;			
		}
		
		public ArrayList ConsultaLineaBloqueada(string flag_buscar, string p_condicion, int p_tipo_doc)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_FLAG_BUSCAR", DbType.String,1,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_CONDICION", DbType.String,15,ParameterDirection.Input),		
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.Int64,ParameterDirection.Input),												   
												   new DAABRequest.Parameter("CUR_TELEFONO", DbType.Object,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(flag_buscar != "") arrParam[0].Value = flag_buscar;
			if(p_condicion != "") arrParam[1].Value = p_condicion;
			if(p_tipo_doc != 1) arrParam[2].Value = p_tipo_doc;

			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;
			obRequest.Command = BaseDatos.PKG_BSCS_PARAMETRICO_BLOQUEO + ".BUSCAR_TELEFONO_BLOQUEO";
			obRequest.Parameters.AddRange(arrParam);
			
			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
				while(dr.Read())
				{
					ItemGenerico item = new ItemGenerico();
					item.Codigo = Funciones.CheckStr(dr["TICKLER_CODE"]);
					item.Descripcion = Funciones.CheckStr(dr["SHORT_DESCRIPTION"]);
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
public string ConsultaLineaBloqueada(int p_co_id, int p_sncode)
		{	
			String resultado = "";

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CO_ID", DbType.Int64,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_SNCODE", DbType.Int64,ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESTADO", DbType.String,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(p_co_id != 1) arrParam[0].Value = p_co_id;
			if(p_sncode != 1) arrParam[1].Value = p_sncode;

			String strEsquemaBSCS = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			
			if(strEsquemaBSCS == "") obRequest.Command =   "tim075_estado_servicio";
			else obRequest.Command = strEsquemaBSCS + ".tim075_estado_servicio";
			
			
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;	
				parSalida1 = (IDataParameter)obRequest.Parameters[2];
				resultado = Funciones.CheckStr(parSalida1.Value);

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return resultado;

		}


		// FES *****
	

		public Boolean ConsultaStatusContrato(int p_co_id, ref string estadoContrato, ref string estadoBloqueo)
		{	
			Boolean resultado = false;

			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CO_ID", DbType.Int64,ParameterDirection.Input),	
												   new DAABRequest.Parameter("P_CH_STATUS", DbType.String,ParameterDirection.Output),
												   new DAABRequest.Parameter("P_BLOQ", DbType.String,ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			if(p_co_id != 1) arrParam[0].Value = p_co_id;

			String strEsquemaBSCS = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
			
			BDBSCS obj = new BDBSCS(BaseDatos.BD_BSCS);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			
			if(strEsquemaBSCS == "") obRequest.Command =   "TIM114_GET_STATUS_COID";
			else obRequest.Command = strEsquemaBSCS + ".TIM114_GET_STATUS_COID";
			
			
			obRequest.Parameters.AddRange(arrParam);

			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				resultado = true;
			}
			catch(Exception e)
			{				
				throw e;
			}
			finally
			{
				IDataParameter parSalida1;	
				parSalida1 = (IDataParameter)obRequest.Parameters[1];
				estadoContrato = Funciones.CheckStr(parSalida1.Value);


				IDataParameter parSalida2;	
				parSalida2 = (IDataParameter)obRequest.Parameters[2];
				estadoBloqueo = Funciones.CheckStr(parSalida2.Value);

				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			
			return resultado;

		}

		public DataTable ConsultaVentaCuotas(string strTipoDocumento, string strNroDocumento, string strIMEI, string strLinea)
		{			
			DataTable dtResultado = new DataTable();
			DAABRequest.Parameter[] arrParam = {		
				new DAABRequest.Parameter("P_CURSOR", DbType.Object,ParameterDirection.Output),
				new DAABRequest.Parameter("P_TIPODOC", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_NRODOC", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_LINEA", DbType.String, ParameterDirection.Input),
				new DAABRequest.Parameter("P_IMEI", DbType.String, ParameterDirection.Input) 
			}; 

			int i = 0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;		
			
			arrParam[1].Value = strTipoDocumento;
			arrParam[2].Value = strNroDocumento;
			arrParam[3].Value = strLinea;
			arrParam[4].Value = strIMEI;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;		
			objRequest.Command = BaseDatos.PKG_SISACT_REPORTE + ".sp_con_venta_cuotas";
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
