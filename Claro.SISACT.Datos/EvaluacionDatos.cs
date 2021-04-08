using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;


namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Descripción breve de EvaluacionDatos.
	/// </summary>
	public class EvaluacionDatos
	{
		public EvaluacionDatos()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		//PROY-24740
		public ArrayList ObtenerMontoFactxBilletera(string strNroDocumento, string strCadena)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_LISTA_PLANES", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("C_PRODUCTO_FACT", DbType.Object, ParameterDirection.Output)                                                                        
											   };
			arrParam[0].Value = strCadena;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}" ,BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_CALCULO_FACTURA_X_PRODUCTO");
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Billetera objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					objItem = new Billetera();
					objItem.idBilletera = Funciones.CheckInt(dr["CODIGO"]);
					objItem.billetera = Funciones.CheckStr(dr["DESCRIPCION"]);
					objItem.monto = Funciones.CheckDbl(dr["VALOR"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		//PROY-24740
		public ArrayList ObtenerPlanesxBilletera(int flgSistema)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CONSULTA", DbType.Object, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_SISTEMA", DbType.Int16, ParameterDirection.Input)
											   };
			arrParam[1].Value = flgSistema;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI, ".SP_CON_PLAN_BILLETERA");
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ArrayList objListaPlan = new ArrayList();
			PlanBilletera objItem;
			Billetera objBilletera;
			string plan;
			IDataReader dr=null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					plan = Funciones.CheckStr(dr["SOLV_CODIGO"]);
					objBilletera = new Billetera(Funciones.CheckInt(dr["PRCLV_CODIGO"]), 1);
					if (!objListaPlan.Contains(plan))
					{
						objItem = new PlanBilletera();
						objItem.Plan = plan;
						objItem.oBilletera = new ArrayList();
						objItem.oBilletera.Add(objBilletera);
						objLista.Add(objItem);
						objListaPlan.Add(plan);
					}
				}
			}
			finally
			{
				if(dr!=null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		//PROY-24740
		public ArrayList ObtenerLCxBilletera(string strRiesgo, string strTipoDoc, string strNroDocumento, string essaludSunat, string strClienteNuevo, double dblLC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_RIESGO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_ESSALUD_SUNAT", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CLIENTE_NUEVO", DbType.String, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC_DC", DbType.Double, ParameterDirection.Input),
												   new DAABRequest.Parameter("C_PRODUCTO_LC", DbType.Object,ParameterDirection.Output)                                                                        
											   };
			int i = 0; arrParam[i].Value = strRiesgo;
			++i; arrParam[i].Value = strTipoDoc;
			++i; arrParam[i].Value = essaludSunat;
			++i; arrParam[i].Value = strClienteNuevo;
			++i; arrParam[i].Value = dblLC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_CALCULO_LC_X_PRODUCTO");
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			Billetera objItem;
			IDataReader dr = null;
			try
			{  
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;				
				while(dr.Read())
				{
					objItem = new Billetera();
					objItem.idBilletera = Funciones.CheckInt(dr["PRODUCTO_COD"]);
					objItem.billetera = Funciones.CheckStr(dr["DESCRIPCION"]);
					objItem.monto = Funciones.CheckDbl(dr["PRODUCTO_LC"]);
					objLista.Add(objItem);
				}				
			}
			finally
			{
				if (dr != null && dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		//PROY-24740
		public string ConsultarTextoRangoLC(string strTipoDocumento, string strNroDocumento, double dblLC)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_COMENTARIO_LC", DbType.String, 50, ParameterDirection.Output),
												   new DAABRequest.Parameter("P_TIPO_DOC", DbType.String, 2, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_LC", DbType.Double, ParameterDirection.Input)}
				;
			int i;
			i = 1; arrParam[i].Value = strTipoDocumento;
			i++; arrParam[i].Value = dblLC;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_CON_TEXTO_RANGO_LC");
			objRequest.Parameters.AddRange(arrParam);

			string strTextoLC = string.Empty;
			try
			{
				objRequest.Factory.ExecuteNonQuery(ref objRequest);
				strTextoLC = Funciones.CheckStr(((IDataParameter)objRequest.Parameters[0]).Value);
			}
			finally
			{
				objRequest.Factory.Dispose();
			}
			return strTextoLC;
		}

		//PROY-24740
		public ArrayList ObtenerPlanesBSCSxCE(string strCasoEspecial)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CASO_ESPECIAL", DbType.String, 20, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_PLAN", DbType.Object, ParameterDirection.Output)
											   };
			arrParam[0].Value = strCasoEspecial;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_CON_CE_PLANES");
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ItemGenerico objItem;
			IDataReader dr = null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while (dr.Read())
				{
					objItem = new ItemGenerico();
					objItem.Codigo = Funciones.CheckStr(dr["CODIGO_BSCS"]);
					objLista.Add(objItem);
				}
			}
			finally
			{
				if (dr != null && dr.IsClosed == false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}

		public ArrayList ConsultarDetalleDecoxKIT(string idKIT)
								  {
									  DAABRequest.Parameter[] arrParam = {
																			 new DAABRequest.Parameter("P_CUR_EQUIPO", DbType.Object, ParameterDirection.Output),
																			 new DAABRequest.Parameter("P_KIT", DbType.Int64, ParameterDirection.Input)}
										  ;
									  arrParam[1].Value = idKIT;

									  BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
									  DAABRequest objRequest = obj.CreaRequest();
									  objRequest.CommandType = CommandType.StoredProcedure;
									  objRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_BRMS + ".SP_CON_EQUIPO_DECO_KIT";
									  objRequest.Parameters.AddRange(arrParam);

									  ArrayList objLista = new ArrayList();
										  EquipoBRMS objItem;
									  IDataReader dr = null;
									  try
									  {
										  dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
										  while (dr.Read())
										  {
											  objItem = new EquipoBRMS();
											  objItem.kit = Funciones.CheckStr(dr["KITV_DESCRIPCION"]);
											  objItem.modelo = Funciones.CheckStr(dr["MATV_DESCRIPCION"]);
											  objItem.tipoDeDeco = Funciones.CheckStr(dr["TIPO_DECO"]);
											  objLista.Add(objItem);
										  }
									  }
									  catch (Exception ex)
									  {
										  throw ex;
									  }
									  finally
									  {
										  if (dr != null && dr.IsClosed == false) dr.Close();
										  objRequest.Factory.Dispose();
									  }
									  return objLista;
								  }


		public double ObtenerCFPromocional(string strIdCampana)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_CAMPANA", DbType.String, ParameterDirection.Input),												   
												   new DAABRequest.Parameter("P_CF_PROM", DbType.Double, ParameterDirection.Output)
											   };
			arrParam[0].Value = strIdCampana;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_DTH + ".SP_CON_CF_PROMOCIONAL";
			objRequest.Parameters.AddRange(arrParam);

			Double dblCF = 0;
			try
			{
				objRequest.Factory.ExecuteScalar(ref objRequest);
				IDataParameter parSalida1;
				parSalida1 = (IDataParameter)objRequest.Parameters[1];
				dblCF = Funciones.CheckDbl(parSalida1.Value);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return dblCF;
		}


		//PROY-24740
		public ArrayList ObtenerBilleteraxPlan(string strListaPlan)
		{
			DAABRequest.Parameter[] arrParam = {
												   new DAABRequest.Parameter("P_PLANES", DbType.String, 4000, ParameterDirection.Input),
												   new DAABRequest.Parameter("P_CURSOR", DbType.Object, ParameterDirection.Output)
											   };
			arrParam[0].Value = strListaPlan;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = string.Format("{0}{1}", BaseDatos.PKG_SISACT_EVALUACION_UNI , ".SP_PLAN_X_PRODUCTO");
			objRequest.Parameters.AddRange(arrParam);

			ArrayList objLista = new ArrayList();
			ArrayList objListaPlan = new ArrayList();
			PlanBilletera objItem;
			Billetera objBilletera;
			string plan;
			IDataReader dr=null;
			try
			{
				dr = objRequest.Factory.ExecuteReader(ref objRequest).ReturnDataReader;
				while(dr.Read())
				{
					plan = Funciones.CheckStr(dr["PLAN"]);
					objBilletera = new Billetera(Funciones.CheckInt(dr["PRODUCTO"]), Funciones.CheckStr(dr["DESCRIPCION"]));

					if (!objListaPlan.Contains(plan))
					{
						objItem = new PlanBilletera();
						objItem.Plan = plan;
						objItem.oBilletera = new ArrayList();
						objItem.oBilletera.Add(objBilletera);

						objLista.Add(objItem);
						objListaPlan.Add(plan);
					}					
				}
			}
			finally
			{
				if(dr!=null&& dr.IsClosed==false) dr.Close();
				objRequest.Parameters.Clear();
				objRequest.Factory.Dispose();
			}
			return objLista;
		}


		public DataSet ObtenerDatosEvaluacion(string strOficina, string strTipoDoc, string strNroDoc, string strNroOperacion)
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
			int i = 3; arrParam[i].Value = strOficina;
			i++; arrParam[i].Value = strTipoDoc;
			i++; arrParam[i].Value = strNroDoc;
			i++; arrParam[i].Value = strNroOperacion;

			BDSISACT obj = new BDSISACT(BaseDatos.BD_SISACT);
			DAABRequest objRequest = obj.CreaRequest();
			objRequest.CommandType = CommandType.StoredProcedure;
			objRequest.Command = BaseDatos.PKG_SISACT_CONSULTA_BRMS + ".SP_CON_DATOS_EVALUACION";
			objRequest.Parameters.AddRange(arrParam);

			try
			{
				return objRequest.Factory.ExecuteDataset(ref objRequest);
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
