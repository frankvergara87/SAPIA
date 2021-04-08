using System;
using System.Collections;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de EvaluacionNegocio.
	/// </summary>
	public class EvaluacionNegocio
	{
		public EvaluacionNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ArrayList ObtenerMontoFactxBilletera(string strNroDocumento, string strCadena)
		{
			return new EvaluacionDatos().ObtenerMontoFactxBilletera(strNroDocumento, strCadena);
		}

		public ArrayList ObtenerPlanesxBilletera(int flgSistema)
		{
			return new EvaluacionDatos().ObtenerPlanesxBilletera(flgSistema);
		}

		public ArrayList ObtenerLCxBilletera(string strRiesgo, string strTipoDoc, string strNroDocumento, string essaludSunat, string strClienteNuevo, double dblLC)
		{
			return new EvaluacionDatos().ObtenerLCxBilletera(strRiesgo, strTipoDoc, strNroDocumento, essaludSunat, strClienteNuevo, dblLC);
		}

		public string ConsultarTextoRangoLC(string strTipoDocumento, string strNroDocumento, double dblLC)
		{
			return new EvaluacionDatos().ConsultarTextoRangoLC(strTipoDocumento, strNroDocumento, dblLC);
		}

		public ArrayList ObtenerPlanesBSCSxCE(string strCasoEspecial)
		{
			return new EvaluacionDatos().ObtenerPlanesBSCSxCE(strCasoEspecial);
		}

		public ArrayList ConsultarDetalleDecoxKIT(string idKIT)
		{
			return new EvaluacionDatos().ConsultarDetalleDecoxKIT(idKIT);
		}

		public double ObtenerCFPromocional(string strIdCampana)
		{
			return new EvaluacionDatos().ObtenerCFPromocional(strIdCampana);
		}

		public ArrayList ObtenerBilleteraxPlan(string strListaPlan)
		{
			return new EvaluacionDatos().ObtenerBilleteraxPlan(strListaPlan);
		}
		public DataSet ObtenerDatosEvaluacion(string strOficina, string strTipoDoc, string strNroDoc, string strNroOperacion)
		{
			return new EvaluacionDatos().ObtenerDatosEvaluacion(strOficina, strTipoDoc, strNroDoc, strNroOperacion);
		}
	}
}
