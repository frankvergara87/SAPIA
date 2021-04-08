using System;
using Claro.SisAct.Common;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Text;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using System.Data;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ConsumerNegocio.
	/// </summary>
	public class ConsumerNegocio
	{
		public ConsumerNegocio()
		{		

		}

		public SolicitudPersona DetalleEvaluacionNatural(string nroSEC)
		{
			ConsumerDatos obj = new ConsumerDatos();
			return obj.DetalleEvaluacionNatural(nroSEC);
		}

		//e75785
		public ArrayList ListaPlazosAcuerdo(string cod_plazoacuerdo,string cod_tipoproducto,string estado)
		{
			ConsumerDatos objConsumerDatos= new ConsumerDatos();
			return objConsumerDatos.ListaPlazosAcuerdo(cod_plazoacuerdo,cod_tipoproducto,estado);
		}
		public ArrayList ListaCanales(Int64 cod_usuario,string cod_producto)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListaCanales(cod_usuario,cod_producto);
		}
		public int CargaMasiva(string pstrTipo, string pstrDatos)
		{
			string strDatos = pstrDatos;
			ConsumerDatos objConsumerDatos;
			int intLar = 4000;//511;
			int intPosIni = 0;
			int intPosFin = 0;

			try
			{
				if (pstrDatos.Length > intLar)
				{
					while (intPosIni < pstrDatos.Length)
					{
						if (intPosIni + intLar <= pstrDatos.Length)
							strDatos = pstrDatos.Substring(intPosIni, intLar);
						else
							strDatos = pstrDatos.Substring(intPosIni);

						intPosFin = strDatos.LastIndexOf("¬");

						if (intPosFin > 0)
						{
							strDatos = pstrDatos.Substring(intPosIni, intPosFin);
							intPosIni += intPosFin;
						}
						else
							intPosIni = pstrDatos.Length;

						objConsumerDatos = new ConsumerDatos();
						objConsumerDatos.CargaMasiva(pstrTipo, strDatos);
					}
				}
				else
				{
					objConsumerDatos = new ConsumerDatos();
					objConsumerDatos.CargaMasiva(pstrTipo, pstrDatos);
				}
			}
			finally
			{
				objConsumerDatos = null;
			}
			return 1;
		}

		public ArrayList ListarTipoDocumento()
		{
			return new ConsumerDatos().ListarTipoDocumento();
		}
		public DataSet ListarBolsaMasiva(int pstrTipoDocumento, string pstrNroDocumento)
		{
			return new ConsumerDatos().ListarBolsaMasiva(pstrTipoDocumento, pstrNroDocumento);
		}
		public void ProcesarBolsa(string pstrCustcode, string pstrAccion, int pintBolsa, string pstrUsuario, string pstrPDV, ref string pstrCodError, ref string pstrDesError)
		{
			new ConsumerDatos().ProcesarBolsa(pstrCustcode, pstrAccion, pintBolsa, pstrUsuario, pstrPDV, ref pstrCodError, ref pstrDesError);
		}
		public DataTable ListarGrupoBolsa()
		{
			return new ConsumerDatos().ListarGrupoBolsa();
		}
		public DataTable ListarTipoBolsa(string pstrTipoBolsa)
		{
			return new ConsumerDatos().ListarTipoBolsa(pstrTipoBolsa);
		}

		public ArrayList ListarSolucion3Play(string pstrTipoServicio, out int pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarSolucion3Play(pstrTipoServicio, out pintCodError, out pstrMsjError);
		}

		public ArrayList ListarPaquete3Play(Int64 plngIdSolucion, out int pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarPaquete3Play(plngIdSolucion, out pintCodError, out pstrMsjError);
		}

		public ArrayList ListarPlanesXPaquete3Play(string pstrPaquete)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarPlanesXPaquete3Play(pstrPaquete);
		}

		//Renovacion
		public ArrayList ListarPlanTarifario(string pstrOferta, string pstrProducto, string pstrDespacho, string pstrFlujo, string pstrDocumento, 
			string pstrOficina, string pstrCasoEspecial, string pstrPlazo, string pstrRiesgo, string pstrFlagRenovacion)
		{
			return new ConsumerDatos().ListarPlanTarifario(pstrOferta, pstrProducto, pstrDespacho, pstrFlujo, pstrDocumento, pstrOficina, 
				pstrCasoEspecial, pstrPlazo, pstrRiesgo, pstrFlagRenovacion);
		}

		public DataTable ObtenerEquipoGama()
		{
			return new ConsumerDatos().ObtenerEquipoGama();
		}

		public ArrayList ListarParametroGeneral(string pstrCodigo)
		{
			return new ConsumerDatos().ListarParametroGeneral(pstrCodigo);
		}

		public string ValidarSECRecurrente(string strTipoDocumento, string strNroDocumento, string strOferta, string strCasoEspecial, 
			string strCadenaDetalle, ref string flgReingresoSec)
		{
			return new ConsumerDatos().ValidarSECRecurrente(strTipoDocumento, strNroDocumento, strOferta, strCasoEspecial, strCadenaDetalle, ref flgReingresoSec);
		}

		public string ConsultarProductoPaquete(string pPaquete)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ConsultarProductoPaquete(pPaquete);
		}

		public DataTable ListadoPaquete3Play(Int64 plngIdSolucion, out int pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListadoPaquete3Play(plngIdSolucion, out pintCodError, out pstrMsjError);
		}

		public ArrayList ListarPlazoDTH(string pstrCodPlan)
		{
			return new ConsumerDatos().ListarPlazoDTH(pstrCodPlan);
		}

 

		public ArrayList ListarCampanaDTH1(string pstrOficina)
		{
			return new ConsumerDatos().ListarCampanaDTH1(pstrOficina);
		}

		public DataTable ListadoSolucion3Play(string pstrTipoServicio, out int pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListadoSolucion3Play(pstrTipoServicio, out pintCodError, out pstrMsjError);
		}

		public ArrayList ListarPromocionesXPaquete3Play(string pstrPaquete)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarPromocionesXPaquete3Play(pstrPaquete);
		}

		public ArrayList ListarPaqueteUni(string pstrDocumento, string pstrOferta, string pstrPlazo)
		{
			return new ConsumerDatos().ListarPaqueteUni(pstrDocumento, pstrOferta, pstrPlazo);
		}

		public ArrayList ListarCuota(string pstrDocumento, string pstrRiesgo, string pstrPlan, string pstrPlazo, 
			int pintNroPlanes, string pstrCasoEspecial)
		{
			return new ConsumerDatos().ListarCuota(pstrDocumento, pstrRiesgo, pstrPlan, pstrPlazo, pintNroPlanes, pstrCasoEspecial);
		}

		public ArrayList ListarCasoEspecial(string pstrOferta, string pstrDocumento, string pstrOficina)
		{
			ConsumerDatos obj = new ConsumerDatos();
			return obj.ListarCasoEspecial(pstrOferta, pstrDocumento, pstrOficina);
		}

		public void ObtenerPlanesSolicitud(string nroSEC, ref ArrayList listaPlanes, ref ArrayList listaServicios)
		{
			new ConsumerDatos().ObtenerPlanesSolicitud(nroSEC, ref listaPlanes, ref listaServicios);
		}

		public ArrayList ConsultarListaServicios(string p_plan_tarifario, string p_tipo_cliente, string p_mandt)
		{
			return new ConsumerDatos().ConsultarListaServicios(p_plan_tarifario, p_tipo_cliente, p_mandt);
		}

		public ArrayList ListarServiciosXPaqPlan(string codPaquete, string codPlan, int idSecuencia)
		{
			return new ConsumerDatos().ListarServiciosXPaqPlan(codPaquete, codPlan, idSecuencia);
		}

		public ArrayList ListarPlanIndiRestServ(string pstrPlan, string pstrCasoEspecial)
		{
			return new ConsumerDatos().ListarPlanIndiRestServ(pstrPlan, pstrCasoEspecial);
		}

		public ArrayList ListarPlazoAcuerdo(string pstrCasoEspecial)
		{
			return new ConsumerDatos().ListarPlazoAcuerdo(pstrCasoEspecial);
		}

		public ArrayList ListarPlazoAcuerdo(string pstrTipoProducto, string pstrCasoEspecial)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarPlazoAcuerdo(pstrTipoProducto, pstrCasoEspecial);
		}

		public ArrayList ListarTipoProductoxOferta(string pstrOferta, string pstrFlujo, string pstrCasoEspecial, string pstrTipoDoc, string pstrOficina)
		{
			return new ConsumerDatos().ListarTipoProductoxOferta(pstrOferta, pstrFlujo, pstrCasoEspecial, pstrTipoDoc, pstrOficina);
		}

		public string ConsultarGrupoCadena(string pOficina)
		{
			return new ConsumerDatos().ConsultarGrupoCadena(pOficina);
		}
		public string ConsultarGrupoCadenaSISACT(string pOficina)
		{
			return new ConsumerDatos().ConsultarGrupoCadenaSISACT(pOficina);
		}

		public ArrayList ListadoTopeAutomatico(string pstrPlanCodigo)
		{
			return new ConsumerDatos().ListadoTopeAutomatico(pstrPlanCodigo);
		}
	
		public ArrayList ConsultarListaKitsDTH(string p_tipo_operacion, string p_cod_campania, string p_plazo_acuerdo)
		{
			return new ConsumerDatos().ConsultarListaKitsDTH(p_tipo_operacion, p_cod_campania, p_plazo_acuerdo);
		}

		public ArrayList ListarTipoProducto(string pstrOferta, string pstrFlujo)
		{
			return new ConsumerDatos().ListarTipoProducto(pstrOferta, pstrFlujo);
		}

		public ArrayList ListarPlanesXPaquete(string codPaquete)
		{
			return new ConsumerDatos().ListarPlanesXPaquete(codPaquete);
		}

		public ArrayList ListarServicioDTH(string pstrCodPlan)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarServicioDTH(pstrCodPlan);
		}

		public ArrayList ListarNoMostrarCampania(string pstrDocumento, string pstrRiesgo, string pstrPlan, 
			string pstrPlazo, string pstrOficina)
		{
			return new ConsumerDatos().ListarNoMostrarCampania(pstrDocumento, pstrRiesgo, pstrPlan, pstrPlazo, pstrOficina);
		}

		public ArrayList ListarCampaniaCE(string pstrCasoEspecial)
		{
			return new ConsumerDatos().ListarCampaniaCE(pstrCasoEspecial);
		}

		public ArrayList ListarCampanaDTH(string pstrCodPlazo, string pstrCodPlan)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarCampanaDTH(pstrCodPlazo, pstrCodPlan);
		}

		public ArrayList ListarParametroConsumer(int intCodigoParametro)
		{
			ConsumerDatos objConsumerDatos= new ConsumerDatos();
			return objConsumerDatos.ListarParametroConsumer(intCodigoParametro);
		}

		public DataSet ListarDetalleLineaSGA(string pstrTipoDocu, string pstrNroDocumento, int pintCantMes)
		{
			return new ConsumerDatos().ListarDetalleLineaSGA(pstrTipoDocu, pstrNroDocumento, pintCantMes);
		}

		public DataSet ListarDetalleLinea(int pstrTipoDocu, string pstrNroDocumento)
		{
			return new ConsumerDatos().ListarDetalleLinea(pstrTipoDocu, pstrNroDocumento);
		}

		public int EvaluacionPendiente(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.EvaluacionPendiente(strCodTipoDocumento,strNumeroDocumento,dblVigencia);
		}

		public void ConsultaTopBlackWhiteList(string pTipoDoc, string pNroDoc, int pDiasDeuda, double pDeuda, int pLineasActivas, 
			int pLineasBloqueo, ref bool pBlack, ref bool pWhite, ref bool pTop)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.ConsultaTopBlackWhiteList(pTipoDoc, pNroDoc, pDiasDeuda, pDeuda, pLineasActivas, pLineasBloqueo, ref pBlack, ref pWhite, ref pTop);
		}

		public ArrayList ListarTipoRiesgo(string pstrTipo)
		{
			return new ConsumerDatos().ListarTipoRiesgo(pstrTipo);
		}

		public ArrayList ListarTipoOperacion()
		{
			return new ConsumerDatos().ListarTipoOperacion();
		}

		public ArrayList ListarTipoOferta(string strTipoDocumento)
		{
			return new ConsumerDatos().ListarTipoOferta(strTipoDocumento);
		}

		public ArrayList ListarProducto()
		{
			return new ConsumerDatos().ListarProducto();
		}

		public void ObtenerAlqInstalKIT(string idKit, string idCampana, string idPlazo, ref double pAlquiler, ref double pInstalacion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.ObtenerAlqInstalKIT(idKit, idCampana, idPlazo, ref pAlquiler, ref pInstalacion);
		}

		public double CalcularLineaCreditoDescentralizado(int pIdTipoCliente,int pIdSegmento,int pIdTipoRiesgo, double pDeudaFinanciera)
		{
			double dLineaCredito = 0.0;
			double dPorcentajeLC = ObtenerPorcentajeLCD(pIdTipoCliente, pIdSegmento, pIdTipoRiesgo);
			if ((dPorcentajeLC >= 0) || (pDeudaFinanciera>=0))
				dLineaCredito =  (dPorcentajeLC*pDeudaFinanciera)/100;

			return dLineaCredito;
		}

		public double ObtenerPorcentajeLCD(int pIdTipoCliente,int pIdSegmento,int pIdTipoRiesgo)
		{
			ConsumerDatos obj = new ConsumerDatos();
			return obj.ObtenerPorcentajeLCD(pIdTipoCliente, pIdSegmento, pIdTipoRiesgo);
		}

		public bool InsertarPlanSolicitud(PlanDetalleVenta oPlan, ref string rMsg)
		{
			return new ConsumerDatos().InsertarPlanSolicitud(oPlan, ref rMsg);
		}

		public bool InsertarPlanVenta(PlanDetalleVenta oPlan)
		{
			return new ConsumerDatos().InsertarPlanVenta(oPlan);
		}

		public bool InsertarPlanServicio(ArrayList listaServicio, Int64 nroSEC, Int64 idPln)
		{
			return new ConsumerDatos().InsertarPlanServicio(listaServicio, nroSEC, idPln);
		}


		public bool InsertarPlanServicio_2(ArrayList listaServicio, Int64 nroSEC, Int64 idPln, string codOficina, string p_Planc_Codigo,string p_Prima) //PROY-24724-IDEA-28174 - Nuevo Parametro (p_Prima)
		{
			return new ConsumerDatos().InsertarPlanServicio_2(listaServicio, nroSEC, idPln,codOficina,p_Planc_Codigo,p_Prima);//PROY-24724-IDEA-28174 - Nuevo Parametro (p_Prima)
		}

		public bool InsertarPlanHFC(PlanSolicitudHFC oPlan, string nroSEC, ref string idSolHFC)
		{
			return new ConsumerDatos().InsertarPlanHFC(oPlan, nroSEC, ref idSolHFC);
		}

		public bool InsertarPlanServicioHFC(ArrayList arrPlanDetalleHFC, Int64 idSolHFC)
		{
			return new ConsumerDatos().InsertarPlanServicioHFC(arrPlanDetalleHFC, idSolHFC);
		}

		public bool InsertarPlanPromocionHFC(ArrayList arrPromocionHFC, Int64 idSolHFC)
		{
			return new ConsumerDatos().InsertarPlanPromocionHFC(arrPromocionHFC, idSolHFC);
		}

		public double fltTraerPrecioKit(string pstrCodCampana, string pstrCodPlaza, int pintcodKit)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.fltTraerPrecioKit(pstrCodCampana, pstrCodPlaza, pintcodKit);
		}

		public int EvaluacionPendiente_DTH(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.EvaluacionPendiente_DTH(strCodTipoDocumento,strNumeroDocumento,dblVigencia);
		}

		public ArrayList ListarTipoGarantia(string tipo_garantia, string estado)
		{
			return new ConsumerDatos().ListarTipoGarantia(tipo_garantia, estado);
		}

		public DataTable ObtenerInformacionCrediticia(string nroSEC)
		{
			return new ConsumerDatos().ObtenerInformacionCrediticia(nroSEC);
		}

		public string ObtenerComentarioPDV(string nroSEC)
		{
			return new ConsumerDatos().ObtenerComentarioPDV(nroSEC);
		}

		public DataTable ListarGarantiaSec(string nroSEC)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarGarantiaSec(nroSEC);
		}

		public string ConsultaObtencionPoderes(string strTipoRiesgo, int numCantMaxLineas)
		{
			return new ConsumerDatos().ConsultaObtencionPoderes(strTipoRiesgo, numCantMaxLineas);
		}

		public double getCFPromocional(string pCodCampana)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.getCFPromocional(pCodCampana);
		}

		public ArrayList ConsultarDepartamentoPDV(string pOficina)
		{
			return new ConsumerDatos().ConsultarDepartamentoPDV(pOficina);
		}

		public ArrayList ListarCampanaDTH2(string pstrCodPlazo, string pstrCodPlan)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarCampanaDTH2(pstrCodPlazo, pstrCodPlan);
		}

		public ArrayList ObtenerSECPendiente(string strCodTipoDoc, string strNroDoc)
		{
			return new ConsumerDatos().ObtenerSECPendiente(strCodTipoDoc, strNroDoc);
		}

		public ArrayList ConsultarListaServiciosDTH(string p_plan_tarifario)
		{
			return new ConsumerDatos().ConsultarListaServiciosDTH(p_plan_tarifario);
		}

		public ArrayList DetalleOferta3Play(Int64 nroSEC)
		{
			return new ConsumerDatos().DetalleOferta3Play(nroSEC);		
		}

		public double fltTraerCFAlquilerKit(int pintcodKit, int pintCampania, string pintPlazo)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.fltTraerCFAlquilerKit(pintcodKit, pintCampania, pintPlazo);
		}

		public double fltTraerCostoInstalacionKit(int pintcodKit, int pintCampania, string pintPlazo)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.fltTraerCostoInstalacionKit(pintcodKit,pintCampania,pintPlazo);
		}

		public ArrayList ListarCampanaDTH(string pstrCodPlan)
		{
			return new ConsumerDatos().ListarCampanaDTH(pstrCodPlan);
		}

		public ArrayList ListarPlan(string codPlan, string codTipoProd, string codTipoVenta, string codPlazo, string tipoPlan, string codEstado)
		{
			return new ConsumerDatos().ListarPlan(codPlan, codTipoProd, codTipoVenta, codPlazo, tipoPlan, codEstado);
		}

		public ArrayList ListarPlanDTH(string pstrOferta, string pstrCampana)
		{
			return new ConsumerDatos().ListarPlanDTH(pstrOferta, pstrCampana);
		}

		public ArrayList ListarPlanDTH(string codPlan, string codTipoProd, string codTipoVenta, string codPlazo, string tipoPlan, string codCampana)
		{
			return new ConsumerDatos().ListarPlanDTH( codPlan,codTipoProd,codTipoVenta,codPlazo,tipoPlan, codCampana);
		}

		public ArrayList ListarPlanDTH1(string codTipoProd, string codTipoVenta, string codCampania)
		{
			return new ConsumerDatos().ListarPlanDTH1(codTipoProd,codTipoVenta,codCampania);
		}

		public int EvaluacionPendienteRenovacion(string strCodTipoDocumento , string strNumeroDocumento, int dblVigencia)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.EvaluacionPendienteRenovacion(strCodTipoDocumento,strNumeroDocumento,dblVigencia);
		}

		public ArrayList ListarBilletera()
		{
			return new ConsumerDatos().ListarBilletera();
		}
		//gaa20130826
		public DataTable ListarRangoLCDisponible(string pstrTipoDocumento, string pstrEstado)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarRangoLCDisponible(pstrTipoDocumento, pstrEstado);			
		}

		public void ActivarRangoLCDisponible(string pstrItemsSel, string pstrCodUsuario, string pstrEstado)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.ActivarRangoLCDisponible(pstrItemsSel, pstrCodUsuario, pstrEstado);
		}

		public void EliminarRangoLCDisponible(string pstrItemsSel)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.EliminarRangoLCDisponible(pstrItemsSel);
		}

		public void InsertarRangoLCDisponible(string pstrTipoDocumento, string pstrRangoInicial, string pstrRangoFinal, string pstrMensajeSISACT, 
			string pstrMensajeSMS, string pstrUsuario, out int pintResultado)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.InsertarRangoLCDisponible(pstrTipoDocumento, pstrRangoInicial, pstrRangoFinal, pstrMensajeSISACT, pstrMensajeSMS, 
				pstrUsuario, out pintResultado);
		}
		
		public void ModificarRangoLCDisponible(string pstrCodigo, string pstrTipoDocumento, string pstrRangoInicial, string pstrRangoFinal, 
			string pstrMensajeSISACT, string pstrMensajeSMS, string pstrEstado, string pstrUsuario, out int pintResultado)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.ModificarRangoLCDisponible(pstrCodigo, pstrTipoDocumento, pstrRangoInicial, pstrRangoFinal, pstrMensajeSISACT, 
				pstrMensajeSMS, pstrEstado, pstrUsuario, out pintResultado);
		}

		//fin gaa20130826
		//--------------------------------
		public string ConsultarTextoRangoLC(string strTipoDocumento, double dblLC)
		{
			return new ConsumerDatos().ConsultarTextoRangoLC(strTipoDocumento, dblLC);
		}
		//---------------------------------

		public DataSet ListarDetalleLineaCantPlanes(int pstrTipoDocu, string pstrNroDocumento)
		{
			return new ConsumerDatos().ListarDetalleLineaCantPlanes(pstrTipoDocu, pstrNroDocumento);
		}

		public DataSet ListarDetalleLineaSISACT(string strTipoDoc, string strNroDoc, string strTelefono)
		{
			return new ConsumerDatos().ListarDetalleLineaSISACT(strTipoDoc, strNroDoc, strTelefono);
		}

		//--- Bolsa Compartida ------------

		public ArrayList ListarPlanBaseCombo(string strPlanBase)
		{
			return new ConsumerDatos().ListarPlanBaseCombo(strPlanBase);
		}
		public ArrayList ListarPlanBase()
		{
			return new ConsumerDatos().ListarPlanBase();
		}
		public ArrayList ListarPlanCombo()
		{
			return new ConsumerDatos().ListarPlanCombo();
		}

		//--- Bolsa Compartida ----------

		//gaa20130730
		public DataTable ListarServicioHFC(string pstrCodigo, string pstrDescripcion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarServicioHFC(pstrCodigo, pstrDescripcion);
		}

		public DataTable ListarPlanHFC(string pstrCodigo, string pstrDescripcion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarPlanHFC(pstrCodigo, pstrDescripcion);
		}

		public DataTable ListarEquipoHFC(string pstrCodigo, string pstrDescripcion, out Int64 pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarEquipoHFC(pstrCodigo, pstrDescripcion, out pintCodError, out pstrMsjError);
		}

		public DataTable ListarCampanaHFC(string pstrDescripcion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarCampanaHFC(pstrDescripcion);
		}
		//fin gaa20130730
		//gaa20130916
		public DataTable ListarServicioCodExt(string pstrId, string pstrCodExt, out Int64 pintCodError, out string pstrMsjError)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarServicioCodExt(pstrId, pstrCodExt, out pintCodError, out pstrMsjError);
		}
		//fin gaa20130916
		//gaa20130916
		public DataTable ListarVendedorPP(string pstrTipo, string pstrDescripcion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarVendedorPP(pstrTipo, pstrDescripcion);
		}

		public DataTable ListarSupervisorPP(string pstrPosicion)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			return objConsumerDatos.ListarSupervisorPP(pstrPosicion);
		}

		public void InsertarVendedorPP(string pstrDNI, string pstrEmail, string pstrNombre, string pstrTelefono, string pstrPosicion, 
			string pstrSupervisor, string pstrUsuario, out string pstrRetorno)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.InsertarVendedorPP(pstrDNI, pstrEmail, pstrNombre, pstrTelefono, pstrPosicion, 
				pstrSupervisor, pstrUsuario, out pstrRetorno);
		}

		public void ModificarVendedorPP(string pstrCodigo, string pstrDNI, string pstrEmail, string pstrNombre, string pstrTelefono, string pstrPosicion, 
			string pstrSupervisor, string pstrEstado, string pstrUsuario, out string pstrRetorno)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.ModificarVendedorPP(pstrCodigo, pstrDNI, pstrEmail, pstrNombre, pstrTelefono, pstrPosicion, 
				pstrSupervisor, pstrEstado, pstrUsuario, out pstrRetorno);
		}

		public void DesactivarVendedorPP(string pstrCodigo, string pstrUsuario)
		{
			ConsumerDatos objConsumerDatos = new ConsumerDatos();
			objConsumerDatos.DesactivarVendedorPP(pstrCodigo, pstrUsuario);
		}
		//fin gaa20130916
		//------ inicio whzr-----------

		public DataTable ObtenerNroLineaWhitelist(string strTelefono, string strNroDoc)
		{
			return new ConsumerDatos().ObtenerNroLineaWhitelist(strTelefono, strNroDoc);
		}
		//------ fin whzr-----------

		public ArrayList ListarTipoItem(string strTipoItem)
		{
			return new ConsumerDatos().ListarTipoItem(strTipoItem);
		}

		public DataSet ListarDetalleLineaBSCS(int tipoDocumento, string nroDocumento)
		{
			return new ConsumerDatos().ListarDetalleLineaBSCS(tipoDocumento, nroDocumento);
		}

		public int ObtenerComportamientoPago(int tipoDocumento, string strNroDoc, ref ItemMensaje objMensaje)
		{
			return new ConsumerDatos().ObtenerComportamientoPago(tipoDocumento, strNroDoc, ref objMensaje);
		}

		public DataTable ListarCantPlanxBilleteraBSCS(int tipoDocumento, string nroDocumento)
		{
			return new ConsumerDatos().ListarCantPlanxBilleteraBSCS(tipoDocumento, nroDocumento);
		}

		public ArrayList ListarListaPrecioxCuota(string strCuota)
		{
			return new ConsumerDatos().ListarListaPrecioxCuota(strCuota);
		}

		public ArrayList ListarItemxPDV(int intTipoItem, string strOficina)
		{
			return new ConsumerDatos().ListarItemxPDV(intTipoItem, strOficina);
		}
//gaa20161027
		//public ArrayList ListarPlanTarifario(string strTipoDocumento, string strTipoOferta, string strTipoProducto, string strPlazo, string strOficina, string strCampana, string strFlujo, string strTipoOperacion)
		public ArrayList ListarPlanTarifario(string strTipoDocumento, string strTipoOferta, string strTipoProducto, string strPlazo, string strOficina, string strCampana, string strFlujo, string strTipoOperacion, string strFamilia)
		{
			ArrayList objListaPlan = new ArrayList();
			//gaa20161027
			//ArrayList objLista = new ConsumerDatos().ListarPlanTarifario(strTipoDocumento, strTipoOferta, strTipoProducto, strPlazo, strCampana, strFlujo, strTipoOperacion);
			ArrayList objLista = new ConsumerDatos().ListarPlanTarifario(strTipoDocumento, strTipoOferta, strTipoProducto, strPlazo, strCampana, strFlujo, strTipoOperacion, strFamilia);
			//fin gaa20161027
			ArrayList objListaPdv = new ConsumerDatos().ListarItemxPDV(1, strOficina);

			foreach (Plan objPlan in objLista)
			{
				foreach (ItemGenerico obj in objListaPdv)
				{
					if (objPlan.PLANC_CODIGO == obj.Codigo)
					{
						objListaPlan.Add(objPlan);
					}
				}
			}
			return objListaPlan;
		}
		//gaa20150901
		public ArrayList ListarCampana(string pstrOficina, string pstrOferta, string strTipoProducto, string strModalidad, string pstrFlujo, string pstrTipoOperacion)
		{
			return new ConsumerDatos().ListarCampana(pstrOficina, pstrOferta, strTipoProducto, strModalidad, pstrFlujo, pstrTipoOperacion);
		}

		public ArrayList ListarPlazo(string pstrTipoProducto, string pstrCasoEspecial, string pModalidadVenta)
		{
			return new ConsumerDatos().ListarPlazo(pstrTipoProducto, pstrCasoEspecial, pModalidadVenta);
		}

		public ArrayList ListarServiciosXPlan(string pstrTipoProducto, string pstrPlan)
		{
			return new ConsumerDatos().ListarServiciosXPlan(pstrTipoProducto, pstrPlan);
		}

		public ArrayList ListarPlanTopeConfig(string pstrPlan, string pstrCasoEspecial)
		{
			return new ConsumerDatos().ListarPlanTopeConfig(pstrPlan, pstrCasoEspecial);
		}
		//fin gaa20150504

		public string ObtenerCampanaSap(string strCampana)
		{
			return new ConsumerDatos().ObtenerCampanaSap(strCampana);
		}

		//INICIO 23112015
		public ArrayList ListarCampanaNuevas(string pstrCombo, string strTipoProducto)
		{
		return new ConsumerDatos().ListarCampanaNuevas(pstrCombo, strTipoProducto);
		}
		public ArrayList ListarPlanCombo(string pstrCombo)
		{
		return new ConsumerDatos().ListarPlanCombo(pstrCombo);
		}
		//FIN 23112015
		//gaa20160301 - MRAF
		public void ListarBloqueo(string strNroLinea, int intDiasBloqueo, string strTipoBloqueo, 
			out int intBloqueo, out int intDiasAntiguedad, out string strCampanaActual, 
			out int intComportamientoPago, out Int64 intCodRpta, out string strDesRpta)
		{
			new ConsumerDatos().ListarBloqueo(strNroLinea, intDiasBloqueo, strTipoBloqueo, 
				out intBloqueo, out intDiasAntiguedad, out strCampanaActual, 
				out intComportamientoPago, out intCodRpta, out strDesRpta);
		}
		//fin gaa20160301
		//gaa20160318
		public void ListarSegmentoModalidadCuota(string pStrNroLinea, out string pStrCuota, 
			out string pstrModalidad, out string pstrSegmento, out Int64 pIntCodErr, out string pStrDesErr)
		{
			new ConsumerDatos().ListarSegmentoModalidadCuota(pStrNroLinea, out pStrCuota, out pstrModalidad, 
				out pstrSegmento, out pIntCodErr, out pStrDesErr);
		}
		//fin gaa20160318
		//gaa20160321
		public void ListarDesCanalxVendedor(string pStrCodVendedor, out string pStrDesCanal, out Int64 pIntCodRes, out string pStrDesRes)
		{
			new ConsumerDatos().ListarDesCanalxVendedor(pStrCodVendedor, out pStrDesCanal, out pIntCodRes, out pStrDesRes);
		}
		//fin gaa20160321 - MRAF FIN 
		//EMMH I
//		public void ListarDesCanalxTofic(string pStrTofic, out string pStrDesCanal, out Int64 pIntCodRes, out string pStrDesRes)
//		{
//			new ConsumerDatos().ListarDesCanalxTofic(pStrCodOvenc, out pStrDesCanal, out pIntCodRes, out pStrDesRes);
//		}
		////EMMH F
		//gaa20151929
		public bool ValidacionAccesoOpcionEP(string strCanal, string strProducto, string strTipoOperacion, string strTipoDocumento, string strTipoValidacion)
		{
			return new ConsumerDatos().ValidacionAccesoOpcionEP(strCanal, strProducto, strTipoOperacion, strTipoDocumento, strTipoValidacion);
		}
		//fin gaa20151929

		//Inicio Modificacion Plan No Vigente
		public ArrayList ListarCampanaNoVig(string pstrOficina, string pstrOferta, string strTipoProducto, string strModalidad, string pstrFlujo, string pstrTipoOperacion,string pstrPlanCodigoPlan,string pstrCampanasPlanNoVig)
		{
			return new ConsumerDatos().ListarCampanaNoVig(pstrOficina, pstrOferta, strTipoProducto, strModalidad, pstrFlujo, pstrTipoOperacion,pstrPlanCodigoPlan,pstrCampanasPlanNoVig);
		}
		//Fin Modificacion Plan No Vigente	

		//Inicio Renovacion Por Bloqueo JAZ
		public bool ValidarBloqueoLinea(string pstrCoId, string pstrNumeroDoc,ref bool pEsLineaPrincipal, ref string pTramaMensaje)
		{
			bool bRespuesta = false;
			string sCodRespuesta = "";
			pEsLineaPrincipal = false;
			pTramaMensaje = "";
			string sRespuesta ="";

			ArrayList objDetalleBloqueos = new ArrayList();
			ArrayList objListaLineasAsociadas = new ArrayList();

			LineaBloqueo objBloqueo = new LineaBloqueo();			

			ConsumerDatos objConsumerDatos = new ConsumerDatos();		
			string sTipoBusqueda = ConfigurationSettings.AppSettings["constTipoBusquedaConsumerBloqLinea"];
			objConsumerDatos.ListarLineasConBloqueo(pstrCoId, pstrNumeroDoc,sTipoBusqueda ,ref objDetalleBloqueos,ref sCodRespuesta);

			if (sCodRespuesta == "0")
			{
				bRespuesta = false; // No existe bloqueo
			}
			else if(sCodRespuesta == "1")
			{

				pTramaMensaje = "";

				for (int i = 0; i < objDetalleBloqueos.Count ; i++)
				{
					objBloqueo = (LineaBloqueo)objDetalleBloqueos[i];
					pTramaMensaje += objBloqueo.DESCRIPCION + "-" + objBloqueo.LINEA  + "|";
				}
				
				bRespuesta = true;// Existe Bloqueo
				pEsLineaPrincipal = true;

			}
			else if(sCodRespuesta == "2") 
			{ 
				pTramaMensaje = "";

				for (int i = 0; i < objDetalleBloqueos.Count ; i++)
				{
					objBloqueo = (LineaBloqueo)objDetalleBloqueos[i];
					pTramaMensaje += objBloqueo.DESCRIPCION + "-" + objBloqueo.LINEA  + "|";
				}
				bRespuesta = true;// Existe Bloqueo
				pEsLineaPrincipal = false;
			}
		

			if (pTramaMensaje.Length > 0) 
				sRespuesta = pTramaMensaje.Substring(0,pTramaMensaje.Length -1);

			pTramaMensaje = sRespuesta;

			return bRespuesta;
		}
		//Fin Renovacion Por Bloqueo JAZ
		//gaa20161020
		public ArrayList ListarFamiliaPlan (string strModalidad, string strCampana)
		{
			return new ConsumerDatos().ListarFamiliaPlan(strModalidad, strCampana);
		}
		//fin gaa20161020
		//Inicio - SD1052592
		public double ConsultarCargoFijo(string coID)
		{
			return new ConsumerDatos().ConsultarCargoFijo(coID);
		}
		//Fin - SD1052592
		//INICIO PROY-31008
		public Boolean RetornarTopeCero(double intcoid, double strsncode)
		{
			return new ConsumerDatos().RetornarTopeCero(intcoid,strsncode);
		}
	    //FIN PROY-31008
	}
}
