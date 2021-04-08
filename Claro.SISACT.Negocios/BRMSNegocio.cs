using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Negocios.ReglasEvaluacionWS;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Data;
using System.Text;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de BRMSNegocio.
	/// </summary>
	public class BRMSNegocio
	{
		ClaroEvalClientesReglasDecisionService _oTransaccion = new ClaroEvalClientesReglasDecisionService();

		public BRMSNegocio()
		{
			_oTransaccion.Url = ConfigurationSettings.AppSettings["constURLReglasCrediticiaBRMS"].ToString();
			_oTransaccion.Credentials= System.Net.CredentialCache.DefaultCredentials;
			_oTransaccion.Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeOut_ReglasCrediticiaRenov"].ToString());
		}

		public Ofrecimiento ConsultaReglaCrediticia(ClaroEvalClientesReglasRequest oRequest)
		{	
			Ofrecimiento oOfrecimiento = new Ofrecimiento(); 
			ClaroEvalClientesReglasResponse oResponse = new ClaroEvalClientesReglasResponse();
			try
			{
				oResponse = _oTransaccion.ClaroEvalClientesReglas(oRequest);	

				oOfrecimiento.CantidadDeLineasAdicionalesRUC = oResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasAdicionalesRUC;
				oOfrecimiento.CantidadDeLineasMaximas = oResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasMaximas;
				oOfrecimiento.AutonomiaRenovacion = oResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasRenovaciones;
				oOfrecimiento.MontoCFParaRUC = oResponse.ofrecimiento.ofrecimiento1.autonomia.montoCFParaRUC;
				oOfrecimiento.TipoDeAutonomiaCargoFijo = oResponse.ofrecimiento.ofrecimiento1.autonomia.tipoDeAutonomiaCargoFijo;
				oOfrecimiento.ControlDeConsumo = oResponse.ofrecimiento.ofrecimiento1.controlDeConsumo;
				oOfrecimiento.CostoDeInstalacion = oResponse.ofrecimiento.ofrecimiento1.costoDeInstalacion;
				oOfrecimiento.CantidadDeAplicacionesRenta = oResponse.ofrecimiento.ofrecimiento1.garantia.cantidadDeAplicacionesRenta;
				oOfrecimiento.FrecuenciaDeAplicacionMensual = oResponse.ofrecimiento.ofrecimiento1.garantia.frecuenciaDeAplicacionMensual;
				oOfrecimiento.MesInicioRentas = oResponse.ofrecimiento.ofrecimiento1.garantia.mesInicioRentas;
				oOfrecimiento.MontoDeGarantia = oResponse.ofrecimiento.ofrecimiento1.garantia.montoDeGarantia;
				oOfrecimiento.Tipodecobro = oResponse.ofrecimiento.ofrecimiento1.garantia.tipodecobro.ToString();
				oOfrecimiento.TipoDeGarantia = oResponse.ofrecimiento.ofrecimiento1.garantia.tipoDeGarantia;
				oOfrecimiento.LimiteDeCreditoCobranza = oResponse.ofrecimiento.ofrecimiento1.limiteDeCreditoCobranza;
				oOfrecimiento.MontoTopeAutomatico = oResponse.ofrecimiento.ofrecimiento1.montoTopeAutomatico;
				oOfrecimiento.PrioridadPublicar = oResponse.ofrecimiento.ofrecimiento1.prioridadPublicar.ToString();
				oOfrecimiento.ProcesoDeExoneracionDeRentas = oResponse.ofrecimiento.ofrecimiento1.procesoDeExoneracionDeRentas.ToString();
				oOfrecimiento.ProcesoIDValidator = oResponse.ofrecimiento.ofrecimiento1.procesoIDValidator.ToString();
				oOfrecimiento.ProcesoValidacionInternaClaro = oResponse.ofrecimiento.ofrecimiento1.procesoValidacionInternaClaro.ToString();
				oOfrecimiento.Publicar = oResponse.ofrecimiento.ofrecimiento1.publicar.ToString();
				oOfrecimiento.Restriccion = oResponse.ofrecimiento.ofrecimiento1.restriccion.ToString();
				oOfrecimiento.CapacidadDePago = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.capacidadDePago;
				oOfrecimiento.ComportamientoConsolidado = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.comportamientoConsolidado;
				oOfrecimiento.ComportamientoDePagoC1 = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.comportamientoDePagoC1;
				oOfrecimiento.CostoTotalEquipos = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.costoTotalEquipos;
				oOfrecimiento.FactorDeEndeudamientoCliente = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.factorDeEndeudamientoCliente;
				oOfrecimiento.FactorDeRenovacionCliente = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.factorDeRenovacionCliente;
				oOfrecimiento.PrecioDeVentaTotalEquipos = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.precioDeVentaTotalEquipos;
				oOfrecimiento.RiesgoEnClaro = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoEnClaro;
				oOfrecimiento.RiesgoOferta = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoOferta;
				oOfrecimiento.RiesgoTotalEquipo = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoTotalEquipo;
				oOfrecimiento.RiesgoTotalRepLegales = oResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoTotalRepLegales;		
				oOfrecimiento.FlagExito = "S";
			}
			catch(Exception ex)
			{
				oOfrecimiento.FlagExito = "N";
				oOfrecimiento.Mensaje = ex.Message;
			}
			finally 
			{
				_oTransaccion.Dispose(); 
			}

			return oOfrecimiento;
		}
	}
}
