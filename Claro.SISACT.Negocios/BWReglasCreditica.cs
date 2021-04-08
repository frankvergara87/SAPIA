using System;
using System.Text;
using System.Configuration;
using System.Collections; 
using Claro.SisAct.Datos; 
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Negocios.ReglasEvaluacionWS;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de BWReglasCreditica.
	/// </summary>
	public class BWReglasCreditica
	{
		#region [Declaracion de Constantes - Config]

		ClaroEvalClientesReglasDecisionService _objTransaccion = new ClaroEvalClientesReglasDecisionService();
		//**GeneradorLog _objLog = null;
		string _idAplicacion = null;
		string _usuAplicacion = null;
		string _idTransaccion = null;

		#endregion [Declaracion de Constantes - Config]

		public BWReglasCreditica()
		{
			_objTransaccion.Url = ConfigurationSettings.AppSettings["constURLReglasCrediticiaBRMS"].ToString();
			_objTransaccion.Credentials = System.Net.CredentialCache.DefaultCredentials;
			//_objTransaccion.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["TimeOut_ReglasCrediticia"].ToString());
			_objTransaccion.Timeout = Funciones.CheckInt(ConfigurationSettings.AppSettings["TimeOut_ReglasCrediticiaRenov"].ToString());

			_idAplicacion = ConfigurationSettings.AppSettings["CodigoAplicacion"].ToString();
			_usuAplicacion = ConfigurationSettings.AppSettings["constAplicacion"].ToString();
			_idTransaccion = DateTime.Now.ToString("hhmmssfff");
		}

		public Ofrecimiento ConsultaReglaCrediticia(string nroDocumento, ClaroEvalClientesReglasRequest objRequest, ref ItemMensaje objMensaje)
		{
			Ofrecimiento objOfrecimiento = new Ofrecimiento();

			try
			{
				ClaroEvalClientesReglasResponse objResponse = new ClaroEvalClientesReglasResponse();

				objResponse = _objTransaccion.ClaroEvalClientesReglas(objRequest);

				if (objRequest.solicitud.solicitud1.transaccion == ConfigurationSettings.AppSettings["constTrxVentaCuotas"].ToString())
				{
					Cuota objCuota;
					objOfrecimiento.ListaCuotas = new ArrayList();

					if (objResponse.ofrecimiento.ofrecimiento1.cuota != null)
					{
						foreach (cuota obj in objResponse.ofrecimiento.ofrecimiento1.cuota)
						{
							objCuota = new Cuota();
							objCuota.nroCuota = obj.cantidad;
							objCuota.porcenCuotaInicial = obj.porcentajeInicial;

							//PROY-29123
							objCuota.MaximoCuotas = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.cuotaMaxima;
							objCuota.PrecioEquipoMaximo = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.topeMaximo;
							objCuota.MensajeBRMS = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.mostrarRespuesta;//Agregar Mensaje devuelto por BRMS

							objOfrecimiento.ListaCuotas.Add(objCuota);
						}
					}
					if (objResponse.ofrecimiento.ofrecimiento1.cuota == null){
						objOfrecimiento.MaximoCuotas = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.cuotaMaxima;
						objOfrecimiento.PrecioEquipoMaximo = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.topeMaximo;
						objOfrecimiento.MensajeBRMS = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.mostrarRespuesta; //PROY-29123 Agregar Mensaje Devuelto por BRMS					
					}
				}
				else
				{
					objOfrecimiento.CantidadDeLineasAdicionalesRUC = objResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasAdicionalesRUC;
					objOfrecimiento.CantidadDeLineasMaximas = objResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasMaximas;
					objOfrecimiento.AutonomiaRenovacion = objResponse.ofrecimiento.ofrecimiento1.autonomia.cantidadDeLineasRenovaciones;
					objOfrecimiento.MontoCFParaRUC = objResponse.ofrecimiento.ofrecimiento1.autonomia.montoCFParaRUC;
					objOfrecimiento.TipoDeAutonomiaCargoFijo = objResponse.ofrecimiento.ofrecimiento1.autonomia.tipoDeAutonomiaCargoFijo;
					objOfrecimiento.ControlDeConsumo = objResponse.ofrecimiento.ofrecimiento1.controlDeConsumo;
					objOfrecimiento.CostoDeInstalacion = objResponse.ofrecimiento.ofrecimiento1.costoDeInstalacion;
					objOfrecimiento.CantidadDeAplicacionesRenta = objResponse.ofrecimiento.ofrecimiento1.garantia.cantidadDeAplicacionesRenta;
					objOfrecimiento.FrecuenciaDeAplicacionMensual = objResponse.ofrecimiento.ofrecimiento1.garantia.frecuenciaDeAplicacionMensual;
					objOfrecimiento.MesInicioRentas = objResponse.ofrecimiento.ofrecimiento1.garantia.mesInicioRentas;
					objOfrecimiento.MontoDeGarantia = objResponse.ofrecimiento.ofrecimiento1.garantia.montoDeGarantia;
					objOfrecimiento.Tipodecobro = objResponse.ofrecimiento.ofrecimiento1.garantia.tipodecobro.ToString();
					objOfrecimiento.TipoDeGarantia = objResponse.ofrecimiento.ofrecimiento1.garantia.tipoDeGarantia;
					objOfrecimiento.LimiteDeCreditoCobranza = objResponse.ofrecimiento.ofrecimiento1.limiteDeCreditoCobranza;
					objOfrecimiento.MontoTopeAutomatico = objResponse.ofrecimiento.ofrecimiento1.montoTopeAutomatico;
					objOfrecimiento.PrioridadPublicar = objResponse.ofrecimiento.ofrecimiento1.prioridadPublicar.ToString();
					objOfrecimiento.ProcesoDeExoneracionDeRentas = objResponse.ofrecimiento.ofrecimiento1.procesoDeExoneracionDeRentas.ToString();
					objOfrecimiento.ProcesoIDValidator = objResponse.ofrecimiento.ofrecimiento1.procesoIDValidator.ToString();
					objOfrecimiento.ProcesoValidacionInternaClaro = objResponse.ofrecimiento.ofrecimiento1.procesoValidacionInternaClaro.ToString();
					objOfrecimiento.Publicar = objResponse.ofrecimiento.ofrecimiento1.publicar.ToString();
					objOfrecimiento.Restriccion = objResponse.ofrecimiento.ofrecimiento1.restriccion.ToString();
					objOfrecimiento.CapacidadDePago = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.capacidadDePago;
					objOfrecimiento.ComportamientoConsolidado = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.comportamientoConsolidado;
					objOfrecimiento.ComportamientoDePagoC1 = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.comportamientoDePagoC1;
					objOfrecimiento.CostoTotalEquipos = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.costoTotalEquipos;
					objOfrecimiento.FactorDeEndeudamientoCliente = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.factorDeEndeudamientoCliente;
					objOfrecimiento.FactorDeRenovacionCliente = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.factorDeRenovacionCliente;
					objOfrecimiento.PrecioDeVentaTotalEquipos = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.precioDeVentaTotalEquipos;
					objOfrecimiento.RiesgoEnClaro = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoEnClaro;
					objOfrecimiento.RiesgoOferta = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoOferta;
					objOfrecimiento.RiesgoTotalEquipo = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoTotalEquipo;
					objOfrecimiento.RiesgoTotalRepLegales = objResponse.ofrecimiento.ofrecimiento1.resultadosAdicionales.riesgoTotalRepLegales;
					//PROY-29123
					objOfrecimiento.MaximoCuotas = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.cuotaMaxima;
					objOfrecimiento.PrecioEquipoMaximo = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.topeMaximo;
					objOfrecimiento.MensajeBRMS = objResponse.ofrecimiento.ofrecimiento1.opcionDeCuotas.mostrarRespuesta;
				}
				objMensaje = new ItemMensaje();
			}
			catch(Exception ex)
			{
				objOfrecimiento.TieneAutonomia = "SIN_REGLAS";
				objOfrecimiento.Mensaje = ex.Message;
				objMensaje = new ItemMensaje(ex.Source, ex.Message, false);
			}
			finally 
			{
				_objTransaccion.Dispose(); 
			}
			return objOfrecimiento;
		}
	}
}
