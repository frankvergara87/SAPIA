using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de ReglasEvaluacionNegocio.
	/// </summary>
	public class ReglasEvaluacionNegocio
	{
		public ReglasEvaluacionNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		//Renovacion

		public string ConsultaClienteBlackList(string p_tipo_doc, string p_nro_doc) 
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ConsultaClienteBlackList(p_tipo_doc, p_nro_doc);		
		}
		public string ConsultaBlackListCE(string p_caso_especial, string p_tipo_doc, string p_nro_doc, ref double cf_maximo) 
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ConsultaBlackListCE(p_caso_especial, p_tipo_doc, p_nro_doc, ref cf_maximo);		
		}
		public void ObtenerCEReglas(string strCasoEspecial, string strRiesgo, ref string listaCEPlanBscs, ref string listaCEPlan, ref string listaCERiesgo)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			obj.ObtenerCEReglas(strCasoEspecial, strRiesgo, ref listaCEPlanBscs, ref listaCEPlan, ref listaCERiesgo);
		}
                public ArrayList ObtenerLCxProducto(string p_riesgo, string p_tipo_doc, string p_essalud_sunat, string p_nuevo, double p_lc_dc)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ObtenerLCxProducto(p_riesgo, p_tipo_doc, p_essalud_sunat, p_nuevo, p_lc_dc);	
		}
                public ArrayList ObtenerFactxProducto(string p_planes)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ObtenerFactxProducto(p_planes);	
		}
		public ArrayList ObtenerPlanxProducto(string p_listaPlan)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ObtenerPlanxProducto(p_listaPlan);
		}
		
		public ArrayList ObtenerProductosxPlanes(string p_listaPlan)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ObtenerProductosxPlanes(p_listaPlan);
		}
		public ArrayList ObtenerPlanesxBilletera(string p_sistema)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ObtenerPlanesxBilletera(p_sistema);
		}

		public DataSet ConsultaDatosEvaluacionCliente(string strOficina, string strTipoDoc, string strNroDoc, string strNroOperacion)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.ConsultaDatosEvaluacionCliente(strOficina, strTipoDoc, strNroDoc, strNroOperacion);
		}

		public bool InsertarDatosBRMS(Int64 nroSEC, Int64 pln_codigo, Ofrecimiento oOfrecimiento)
		{
			ReglasEvaluacionDatos obj = new ReglasEvaluacionDatos();
			return obj.InsertarDatosBRMS(nroSEC, pln_codigo, oOfrecimiento);		
		}
	}
}
