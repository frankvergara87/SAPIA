using System;
using Claro.SisAct.Entidades;
using System.Configuration;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de RenovacionesDecisionNegocio.
	/// </summary>
	public class RenovacionesDecisionNegocio
	{
		public RenovacionesDecisionNegocio()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

//		public string TraerTipoOperacion(string pstrComportamientoPago, string pstrTipoCliente, int pintCantidadBloqueos,
//				string pstrEstadoContrato, string pstrDesPlanActual, int pintAntiguedadLinea, string pstrTipoCanal)
//		{
//			RenovacionesDecisionService.RenovacionesClaroConsumerRulesDecisionService objRenovacionesDecisionWS;
//			RenovacionesDecisionService.RenovacionesClaroConsumerRulesRequest objRequest; 
//			RenovacionesDecisionService.RenovacionesClaroConsumerRulesResponse objResponse;
//			string strRespuesta = string.Empty;
//			string[] strTipoListaPrecio;
//
//			try
//			{
//				objRenovacionesDecisionWS = new RenovacionesDecisionService.RenovacionesClaroConsumerRulesDecisionService();
//				objRenovacionesDecisionWS.Url = System.Configuration.ConfigurationSettings.AppSettings["consRutaWSRenovacionesDecision"];
//				objRenovacionesDecisionWS.Credentials = System.Net.CredentialCache.DefaultCredentials;
//
//				RenovacionesDecisionService.cliente objCliente = new RenovacionesDecisionService.cliente();
//
//				objCliente.comportamientoPago = pstrComportamientoPago;
//				objCliente.tipoCliente = pstrTipoCliente;
//
//				RenovacionesDecisionService.linea objLinea = new RenovacionesDecisionService.linea();
//
//				objLinea.cantidadBloqueos = pintCantidadBloqueos;
//				objLinea.cantidadBloqueosSpecified = true;
//				objLinea.tiempoAntiguedad = pintAntiguedadLinea;
//				objLinea.tiempoAntiguedadSpecified = true;
//
//				RenovacionesDecisionService.contrato objContrato = new RenovacionesDecisionService.contrato();
//
//				objContrato.estado = pstrEstadoContrato;
//
//				objLinea.contrato = objContrato;
//
//				RenovacionesDecisionService.plan objPlanActual = new RenovacionesDecisionService.plan();
//
//				objPlanActual.descripcion = pstrDesPlanActual;
//
//				objLinea.planActual = objPlanActual;
//
//				RenovacionesDecisionService.puntoVenta objPuntoVenta = new RenovacionesDecisionService.puntoVenta();
//
//				objPuntoVenta.tipoCanal = pstrTipoCanal;
//
//				RenovacionesDecisionService.solicitudRenovacion1 objSolicitudRenovacion1 = new RenovacionesDecisionService.solicitudRenovacion1();
//
//				objSolicitudRenovacion1.cliente = objCliente;
//				objSolicitudRenovacion1.linea = objLinea;
//				objSolicitudRenovacion1.puntoVenta = objPuntoVenta;
//
//				RenovacionesDecisionService.solicitudRenovacion objSolicitudRenovacion = new RenovacionesDecisionService.solicitudRenovacion();
//				
//				objSolicitudRenovacion.solicitudRenovacion1 = objSolicitudRenovacion1;
//
//				objRequest = new RenovacionesDecisionService.RenovacionesClaroConsumerRulesRequest();
//
//				objRequest.solicitudRenovacion = objSolicitudRenovacion;
//
//				objResponse = objRenovacionesDecisionWS.RenovacionesClaroConsumerRules(objRequest);
//
//				strTipoListaPrecio = objResponse.renovacion.renovacion1.tiposListaPrecio;
//				if (strTipoListaPrecio != null)
//				{
//					if (strTipoListaPrecio.Length > 0)
//					{
//						strRespuesta = strTipoListaPrecio[0];
//
//						if (strRespuesta == System.Configuration.ConfigurationSettings.AppSettings["consTipoOperacionAlta"])
//							strRespuesta = System.Configuration.ConfigurationSettings.AppSettings["flujoAlta"];
//						else
//						{
//							if (strRespuesta == System.Configuration.ConfigurationSettings.AppSettings["consTipoOperacionReno"])
//								strRespuesta = System.Configuration.ConfigurationSettings.AppSettings["constFlujoRenov"];
//						}
//					}
//				}
//				return strRespuesta;
//			}
//			catch (Exception ex)
//			{
//				throw (ex);
//			}
//		}

		public void TraerTipoOperacion(BEConsultaBrms pobjParametrosBrms, out string pstrTipoOperacion, out string pstrCobroPenalidad, out string pstrMensaje)
		{
			RenovacionesDecisionService.RenovacionesClaroConsumerRulesDecisionService objRenovacionesDecisionWS;
			RenovacionesDecisionService.RenovacionesClaroConsumerRulesRequest objRequest; 
			RenovacionesDecisionService.RenovacionesClaroConsumerRulesResponse objResponse;
			string strRespuesta = string.Empty;
			string strPenalidad = "S";
			string strMensaje = string.Empty;
			pstrMensaje = string.Empty;
			string[] strTipoListaPrecio;

			try
			{
				objRenovacionesDecisionWS = new RenovacionesDecisionService.RenovacionesClaroConsumerRulesDecisionService();
				objRenovacionesDecisionWS.Url = System.Configuration.ConfigurationSettings.AppSettings["consRutaWSRenovacionesDecision"];
				objRenovacionesDecisionWS.Credentials = System.Net.CredentialCache.DefaultCredentials;

				RenovacionesDecisionService.cliente objCliente = new RenovacionesDecisionService.cliente();

				objCliente.comportamientoPago = pobjParametrosBrms.ComportamientoPago;
				objCliente.tipoCliente = pobjParametrosBrms.TipoCliente;

				RenovacionesDecisionService.linea objLinea = new RenovacionesDecisionService.linea();

				objLinea.segmentoDesarrolloCliente = pobjParametrosBrms.SegmentoCliente;

				if (pobjParametrosBrms.Bloqueo > -1)
				{
					objLinea.cantidadBloqueos = pobjParametrosBrms.Bloqueo;
					objLinea.cantidadBloqueosSpecified = true;
				}
				if (pobjParametrosBrms.AntiguedadLinea > -1)
				{
					objLinea.tiempoAntiguedad = pobjParametrosBrms.AntiguedadLinea;
					objLinea.tiempoAntiguedadSpecified = true;
				}
				RenovacionesDecisionService.contrato objContrato = new RenovacionesDecisionService.contrato();

				objContrato.estado = pobjParametrosBrms.EstadoAcuerdo;
				if (pobjParametrosBrms.DiasPendientes > -1)
				{
					objContrato.diasPendientes = pobjParametrosBrms.DiasPendientes;
					objContrato.diasPendientesSpecified = true;
				}

				objContrato.plazo = pobjParametrosBrms.PeriodoContrato;
				objContrato.plazoSpecified = true;

				if (pobjParametrosBrms.DiasPermanencia > -1)
				{
					objContrato.tiempoPermanencia = pobjParametrosBrms.DiasPermanencia;
					objContrato.tiempoPermanenciaSpecified = true;
				}

				objLinea.contrato = objContrato;
				objLinea.modalidadVenta = pobjParametrosBrms.ModalidadVenta;

				RenovacionesDecisionService.plan objPlanActual = new RenovacionesDecisionService.plan();

				objPlanActual.descripcion = pobjParametrosBrms.PlanActual;
				objLinea.planActual = objPlanActual;

				RenovacionesDecisionService.puntoVenta objPuntoVenta = new RenovacionesDecisionService.puntoVenta();

				objPuntoVenta.tipoCanal = pobjParametrosBrms.Canal;

				RenovacionesDecisionService.campana objCampanaActual = new RenovacionesDecisionService.campana();

				objCampanaActual.tipoCampana = pobjParametrosBrms.CampaniaActual;
				objLinea.campana = objCampanaActual;

				RenovacionesDecisionService.solicitudRenovacion1 objSolicitudRenovacion1 = new RenovacionesDecisionService.solicitudRenovacion1();

				objSolicitudRenovacion1.cliente = objCliente;
				objSolicitudRenovacion1.linea = objLinea;
				objSolicitudRenovacion1.puntoVenta = objPuntoVenta;

				RenovacionesDecisionService.solicitudRenovacion objSolicitudRenovacion = new RenovacionesDecisionService.solicitudRenovacion();
				
				objSolicitudRenovacion.solicitudRenovacion1 = objSolicitudRenovacion1;

				objRequest = new RenovacionesDecisionService.RenovacionesClaroConsumerRulesRequest();

				objRequest.solicitudRenovacion = objSolicitudRenovacion;

				objResponse = objRenovacionesDecisionWS.RenovacionesClaroConsumerRules(objRequest);

				strTipoListaPrecio = objResponse.renovacion.renovacion1.tiposListaPrecio;

				if (strTipoListaPrecio != null)
				{
					if (strTipoListaPrecio.Length > 0)
					{
						strRespuesta = strTipoListaPrecio[0];

						if (objResponse.renovacion.renovacion1.penalidadSpecified)
						{
							if (objResponse.renovacion.renovacion1.penalidad)
								strPenalidad = "S";
							else
								strPenalidad = "N";
						}
						else
							strPenalidad = "N";

						if (strRespuesta == System.Configuration.ConfigurationSettings.AppSettings["consTipoOperacionAlta"])
							strRespuesta = System.Configuration.ConfigurationSettings.AppSettings["flujoAlta"];
						else
						{
							if (strRespuesta == System.Configuration.ConfigurationSettings.AppSettings["consTipoOperacionReno"])
								strRespuesta = System.Configuration.ConfigurationSettings.AppSettings["constFlujoRenov"];
						}
					}
				}

				strMensaje = objResponse.renovacion.renovacion1.mensaje;

				if (strMensaje != null)
					pstrMensaje = strMensaje;

				if (strRespuesta.Length == 0 && strMensaje == null)
					pstrMensaje = ConfigurationSettings.AppSettings["consErrorConsultaBRMS"];

				pstrTipoOperacion = strRespuesta;
				pstrCobroPenalidad = strPenalidad;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
	}
}
