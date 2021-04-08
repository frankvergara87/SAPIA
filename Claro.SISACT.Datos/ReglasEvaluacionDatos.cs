using System;
using System.Data;
using System.Collections;
using System.Reflection;
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using System.Text;
namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de ReglasEvaluacionDatos.
	/// </summary>
	public class ReglasEvaluacionDatos
	{
		public ReglasEvaluacionDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		//Renovacion

		//Validación BlackList Cliente Comisiones
		public string ConsultaClienteBlackList(string p_tipo_doc, string p_nro_doc) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_EXISTE", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input)
											   }; 
			string retorno = "0";
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = p_tipo_doc;
			arrParam[2].Value = p_nro_doc;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest  = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Transactional = true;
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_BLACKLIST_COMISIONES";
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
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				retorno = (Funciones.CheckInt(parSalida1.Value) > 0)? "S" : "N";
				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}

		public string ConsultaBlackListCE(string p_caso_especial, string p_tipo_doc, string p_nro_doc, ref double cf_maximo) 
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_EXISTE", DbType.String, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CF_MAX", DbType.Double, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOC", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, 5, ParameterDirection.Input)
											   }; 
			string retorno = "";
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[2].Value = p_tipo_doc;
			arrParam[3].Value = p_nro_doc;
			arrParam[4].Value = p_caso_especial;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest  = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Transactional = true;
			obRequest.Parameters.Clear();
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_CE_WHITELIST";
			obRequest.Parameters.AddRange(arrParam);
			
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
			}
			catch (Exception)
			{
				retorno = "";
			}
			finally
			{
				IDataParameter parSalida1, parSalida2;
				parSalida1 = (IDataParameter)obRequest.Parameters[0];
				parSalida2 = (IDataParameter)obRequest.Parameters[1];

				retorno = Funciones.CheckStr(parSalida1.Value);
				cf_maximo = Funciones.CheckDbl(parSalida2.Value);

				obRequest.Factory.Dispose();
				obRequest.Parameters.Clear();
			}
			return retorno;	
		}

		//PROY-24740
		public void ObtenerCEReglas(string strCasoEspecial, string strRiesgo, ref string listaCEPlanBscs, ref string listaCEPlan, ref string listaCERiesgo)
		{			
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CE_PLAN", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CE_RIESGO", DbType.Object, ParameterDirection.Output)
											   }; 
			
			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = strCasoEspecial;
			arrParam[1].Value = strRiesgo;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_CON_CE_REGLAS2");
			obRequest.Parameters.AddRange(arrParam);
			
			IDataReader dr= null;
			StringBuilder sblListaCEPlanBscs = new StringBuilder();
			StringBuilder sblListaCEPlan= new StringBuilder();
			StringBuilder sblListaCERiesgo= new StringBuilder();

			try
			{
				dr= obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;

				while( dr.Read())
				{
					sblListaCEPlanBscs.Append("|");
					sblListaCEPlanBscs.Append(dr["CODIGO_BSCS"]);
				}
				listaCEPlanBscs = sblListaCEPlanBscs.ToString();

				dr.NextResult();										
				while(dr.Read())
				{
					sblListaCEPlan.Append("|");
					sblListaCEPlan.Append(dr["PLZAC_CODIGO"]); 
					sblListaCEPlan.Append(";");
					sblListaCEPlan.Append(dr["PLNC_CODIGO"]) ;
					sblListaCEPlan.Append(";");
					sblListaCEPlan.Append(dr["TCEN_NRO_PLANES"]);
					sblListaCEPlan.Append(";");
					sblListaCEPlan.Append(dr["CUOC_CODIGO"]);
					sblListaCEPlan.Append(";");
					sblListaCEPlan.Append(dr["CUON_INICIAL"]);
				}				
				listaCEPlan= sblListaCEPlan.ToString();

				dr.NextResult();
				while(dr.Read())
				{
					sblListaCERiesgo.Append("|");
					sblListaCERiesgo.Append(dr["DOCC_CODIGO"]);
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["RIEN_CODIGO"]); 
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["PLZAC_CODIGO"]);
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["PLNC_CODIGO"]);
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["TCEN_NRO_PLANES"]);
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["CUOC_CODIGO"]);
					sblListaCERiesgo.Append(";");
					sblListaCERiesgo.Append(dr["CUON_INICIAL"]);
				}
				listaCERiesgo= sblListaCERiesgo.ToString();
			}
			finally
			{	
				if(dr!=null && dr.IsClosed==false)dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
		}

		public ArrayList ObtenerPlanxProducto(string p_listaPlan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLANES", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 

			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_listaPlan;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_PLANES_X_PRODUCTO";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PLAN"]);
					oItem.Codigo2 = Funciones.CheckStr(dr["PRODUCTO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					oItem.orden = Funciones.CheckInt(dr["ORDEN"]);
					filas.Add(oItem);
				}	
			}
			catch(Exception e)
			{				
				throw new Exception("ObtenerPlanxProducto@" + e.StackTrace + "@" + e.Message);
			}
			finally
			{				
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}

		public ArrayList ObtenerLCxProducto(string p_riesgo, string p_tipo_doc, string p_essalud_sunat, string p_nuevo, double p_lc_dc)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESSALUD_SUNAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIENTE_NUEVO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_DC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("C_PRODUCTO_LC", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = p_riesgo;
			arrParam[1].Value = p_tipo_doc;
			arrParam[2].Value = p_essalud_sunat;
			arrParam[3].Value = p_nuevo;
			arrParam[4].Value = p_lc_dc;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CALCULO_LC_X_PRODUCTO";
			obRequest.Parameters.AddRange(arrParam);
			
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRODUCTO_COD"]);
					oItem.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					oItem.Valor = Funciones.CheckDbl(dr["PRODUCTO_LC"]);
					filas.Add(oItem);
				}	
			}
			catch(Exception e)
			{				
				throw new Exception("ObtenerLCxProducto@" + e.StackTrace + "@" + e.Message);
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}

		public ArrayList ObtenerFactxProducto(string p_planes)
		{
			ArrayList filas = null;
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_LISTA_PLANES", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("C_PRODUCTO_FACT", DbType.Object,ParameterDirection.Output)                                                                        
											   }; 

			for (int i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
			
			arrParam[0].Value = p_planes;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CALCULO_FACTURA_X_PROD_RP";
			obRequest.Parameters.AddRange(arrParam);
			
			filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["CODIGO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					oItem.Valor = Funciones.CheckDbl(dr["VALOR"]);
					filas.Add(oItem);
				}	
			}
			catch(Exception e)
			{				
				throw new Exception("ObtenerLCxProducto@" + e.StackTrace + "@" + e.Message);
			}
			finally
			{
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}

		public ArrayList ObtenerProductosxPlanes(string p_listaPlan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLANES", DbType.String, 32767, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   }; 

			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[0].Value = p_listaPlan;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_NRO_PRODUCTO_X_PLANES";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["PRODUCTO"]);
					oItem.Descripcion = Funciones.CheckStr(dr["DESCRIPCION"]);
					oItem.Valor = Funciones.CheckDbl(dr["CANTIDAD"]);
					filas.Add(oItem);
				}	
			}
			catch(Exception e)
			{				
				throw new Exception("ObtenerPlanxProducto@" + e.StackTrace + "@" + e.Message);
			}
			finally
			{				
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}

		public ArrayList ObtenerPlanesxBilletera(string p_sistema)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SISTEMA", DbType.String, 32767, ParameterDirection.Input)
											   }; 

			for (int i=0; i < arrParam.Length; i++)
				arrParam[i].Value = DBNull.Value;

			arrParam[1].Value = p_sistema;
	
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);			
			DAABRequest obRequest = obj.CreaRequest(); 
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_EVALUACION_UNI + ".SP_CON_PLAN_BILLETERA";
			obRequest.Parameters.AddRange(arrParam);

			ArrayList filas = new ArrayList();
			IDataReader dr = null;
			try
			{
				dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;				
				while(dr.Read())
				{
					ItemGenerico oItem = new ItemGenerico();
					oItem.Codigo = Funciones.CheckStr(dr["SOLV_CODIGO"]);
					oItem.Valor = Funciones.CheckDbl(dr["PRCLV_CODIGO"]);
					filas.Add(oItem);
				}	
			}
			catch(Exception e)
			{				
				throw new Exception("ObtenerPlanesxBilletera@" + e.StackTrace + "@" + e.Message);
			}
			finally
			{				
				if (dr != null && dr.IsClosed==false ) dr.Close();
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}

			return filas;
		}

		public DataSet ConsultaDatosEvaluacionCliente(string strOficina, string strTipoDoc, string strNroDoc, string strNroOperacion)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CUR_OFICINA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CUR_CLIENTE", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_CUR_REP_LEGAL", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_OFICINA", DbType.String, 5, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOCUMENTO", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_DOCUMENTO", DbType.String, 16, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_NRO_OPERACION", DbType.String, 20, ParameterDirection.Input)
											   };
			int i=0;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;
 
			i = 2;
			i++; arrParam[i].Value = strOficina;
			i++; arrParam[i].Value = strTipoDoc;
			i++; arrParam[i].Value = strNroDoc;
			i++; arrParam[i].Value = strNroOperacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure;             
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_BRMS + ".SP_CON_DATOS_EVALUACION";

			obRequest.Parameters.AddRange(arrParam);
                  
			DataSet ds = null;
			try
			{
				ds = obRequest.Factory.ExecuteDataset(ref obRequest);
			}
			catch(Exception e)
			{                       
				throw e;
			}
			finally
			{
				obRequest.Parameters.Clear();
				obRequest.Factory.Dispose();
			}
			return ds;
		}

		public bool InsertarDatosBRMS(Int64 nroSEC, Int64 pln_codigo, Ofrecimiento oOfrecimiento)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("p_solin_codigo", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_slpln_codigo", DbType.Int64, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_prdc_codigo", DbType.String, 2, ParameterDirection.Input),
												   //new DAABRequest.Parameter("p_fecha_registro", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_solicitud", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_cliente", DbType.String, 150, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_direccion_cliente", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_doc_cliente", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_rrll_cliente", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_equipo", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_oferta", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_campana", DbType.String, 500, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_plan_actual", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_plan_solicitado", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_servicio", DbType.String, 250, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_pdv", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_in_direccion_pdv", DbType.String, 100, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cantidaddeaplicacionesrenta", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_nrolineasadicionalesruc", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_cantidaddelineasmaximas", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_autonomiarenovacion", DbType.String, 50, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_capacidaddepago", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_comportamientoconsolidado", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_comportamientodepagoc1", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_controldeconsumo", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_costodeinstalacion", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_costototalequipos", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_factordeendeudamiento", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_factorderenovacion", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_frecuenciarenta", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_limitedecreditocobranza", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_mesiniciorentas", DbType.Int16, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_montocfpararuc", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_montodegarantia", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_montotopeautomatico", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_preciodeventatotalequipos", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_prioridadpublicar", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_exoneracionderentas", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_idvalidator", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_validacioninternaclaro", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_publicar", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_restriccion", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_riesgoenclaro", DbType.String, 25, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_riesgooferta", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_riesgototalequipo", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_riesgototalreplegales", DbType.String, 10, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipodeautonomiacargofijo", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipodecobro", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_tipodegarantia", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("p_mensajews", DbType.String, 500, ParameterDirection.Input),
			}; 
			int i;
			bool salida = false;
			for (i=0; i<arrParam.Length;i++)
				arrParam[i].Value = DBNull.Value;

			i=0; arrParam[i].Value = nroSEC;
			i++; arrParam[i].Value = pln_codigo;
			i++; arrParam[i].Value = oOfrecimiento.IdProducto;

			i++; arrParam[i].Value = oOfrecimiento.In_solicitud;
			i++; arrParam[i].Value = oOfrecimiento.In_cliente;
			i++; arrParam[i].Value = oOfrecimiento.In_direccion_cliente;
			i++; arrParam[i].Value = oOfrecimiento.In_doc_cliente;
			i++; arrParam[i].Value = oOfrecimiento.In_rrll_cliente;
			i++; arrParam[i].Value = oOfrecimiento.In_equipo;
			i++; arrParam[i].Value = oOfrecimiento.In_oferta;
			i++; arrParam[i].Value = oOfrecimiento.In_campana;
			i++; arrParam[i].Value = oOfrecimiento.In_plan_actual;
			i++; arrParam[i].Value = oOfrecimiento.In_plan_solicitado;
			i++; arrParam[i].Value = oOfrecimiento.In_servicio;
			i++; arrParam[i].Value = oOfrecimiento.In_pdv;
			i++; arrParam[i].Value = oOfrecimiento.In_direccion_pdv;

			i++; arrParam[i].Value = oOfrecimiento.CantidadDeAplicacionesRenta;
			i++; arrParam[i].Value = oOfrecimiento.CantidadDeLineasAdicionalesRUC;
			i++; arrParam[i].Value = oOfrecimiento.CantidadDeLineasMaximas;
			i++; arrParam[i].Value = oOfrecimiento.AutonomiaRenovacion;
			i++; arrParam[i].Value = oOfrecimiento.CapacidadDePago;
			i++; arrParam[i].Value = oOfrecimiento.ComportamientoConsolidado;
			i++; arrParam[i].Value = oOfrecimiento.ComportamientoDePagoC1;
			i++; arrParam[i].Value = oOfrecimiento.ControlDeConsumo;
			i++; arrParam[i].Value = oOfrecimiento.CostoDeInstalacion;
			i++; arrParam[i].Value = oOfrecimiento.CostoTotalEquipos;
			i++; arrParam[i].Value = oOfrecimiento.FactorDeEndeudamientoCliente;
			i++; arrParam[i].Value = oOfrecimiento.FactorDeRenovacionCliente;
			i++; arrParam[i].Value = oOfrecimiento.FrecuenciaDeAplicacionMensual;
			i++; arrParam[i].Value = oOfrecimiento.LimiteDeCreditoCobranza;
			i++; arrParam[i].Value = oOfrecimiento.MesInicioRentas;
			i++; arrParam[i].Value = oOfrecimiento.MontoCFParaRUC;
			i++; arrParam[i].Value = oOfrecimiento.MontoDeGarantia;
			i++; arrParam[i].Value = oOfrecimiento.MontoTopeAutomatico;
			i++; arrParam[i].Value = oOfrecimiento.PrecioDeVentaTotalEquipos;
			i++; arrParam[i].Value = oOfrecimiento.PrioridadPublicar;
			i++; arrParam[i].Value = oOfrecimiento.ProcesoDeExoneracionDeRentas;
			i++; arrParam[i].Value = oOfrecimiento.ProcesoIDValidator;
			i++; arrParam[i].Value = oOfrecimiento.ProcesoValidacionInternaClaro;
			i++; arrParam[i].Value = oOfrecimiento.Publicar;
			i++; arrParam[i].Value = oOfrecimiento.Restriccion;
			i++; arrParam[i].Value = oOfrecimiento.RiesgoEnClaro;
			i++; arrParam[i].Value = oOfrecimiento.RiesgoOferta;
			i++; arrParam[i].Value = oOfrecimiento.RiesgoTotalEquipo;
			i++; arrParam[i].Value = oOfrecimiento.RiesgoTotalRepLegales;
			i++; arrParam[i].Value = oOfrecimiento.TipoDeAutonomiaCargoFijo;
			i++; arrParam[i].Value = oOfrecimiento.Tipodecobro;
			i++; arrParam[i].Value = oOfrecimiento.TipoDeGarantia;
			i++; arrParam[i].Value = oOfrecimiento.Mensaje;
						
			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);	
			DAABRequest obRequest = obj.CreaRequest();
			obRequest.CommandType = CommandType.StoredProcedure; 			
			obRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_BRMS + ".SP_INS_DATOS_EVALUACION";
			obRequest.Parameters.AddRange(arrParam);
			obRequest.Transactional = true;
			try
			{
				obRequest.Factory.ExecuteNonQuery(ref obRequest);
				obRequest.Factory.CommitTransaction();
				salida = true;
			}
			catch(Exception ex)
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
	}
}
