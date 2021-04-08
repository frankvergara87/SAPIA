using System;
using System.Data;
using System.Collections;
using Claro.SisAct.Entidades;
using Claro.SisAct.Datos;
using Claro.SisAct.Common;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for SolicitudNegocios.
	/// </summary>
	public class SolicitudNegocios
	{
		public SolicitudNegocios(){}

		public ArrayList ObtenerConsultaSolicitudCons(string nroSEC, string tipoDocumento,string nroDocumento)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerConsultaSolicitudCons(nroSEC,tipoDocumento,nroDocumento);
		}

		public bool ModificacionEvaluacionNaturalConsumer(VistaSolicitud objVistaSolicitud)
		{
			return new SolicitudDatos().ModificacionEvaluacionNaturalConsumer(objVistaSolicitud);
		}

		public bool RegistrarEvaluacionNaturalReingreso(string strDatosSolicitud, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarEvaluacionNaturalReingreso(strDatosSolicitud, ref rMsg);
		}
		public bool AnularSEC(string nroSEC,string strResultadoFinal, string strEstado){
			SolicitudDatos obj = new SolicitudDatos();
			return obj.AnularSEC( nroSEC, strResultadoFinal, strEstado);
		}

		public bool InsertarPlanSolicitud(PlanDetalleConsumer objDetalle)
		{
			return new SolicitudDatos().InsertarPlanSolicitud(objDetalle);
		}

		//Renovacion

		public string ValidarVendedorDNI(string pstrNroDocumento)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ValidarVendedorDNI(pstrNroDocumento);
		}

		public ArrayList ConsultarSolDireccion(Int64 nroSEC)
		{
			return new SolicitudDatos().ConsultarSolDireccion(nroSEC);
		}

		public ArrayList ListarPromociones(string pstrSoplnCodigo)
		{
			return new SolicitudDatos().ListarPromociones(pstrSoplnCodigo);
		}
		
		public ArrayList ObtenerSolicitudes(string nroSEC_grupo)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerSolicitudes(nroSEC_grupo);
		}

		public ArrayList ObtenerPlanesCliente(int tipoDoc, string numeroDoc)
		{
			return new SolicitudDatos().ObtenerPlanesCliente(tipoDoc, numeroDoc);
		}

		public ArrayList ObtenerFormulaRecurrente(string dni,int meses, int condicion)
		{
			return new SolicitudDatos().ObtenerFormulaRecurrente(dni,meses,condicion);
		}

		public string ConsultarCalificacionPago(int strTipoDoc, string strNroDoc, ref string mensaje)
		{
			return new SolicitudDatos().ConsultarCalificacionPago(strTipoDoc, strNroDoc, ref mensaje);
		}

		public bool InsertarSolDireccion(DireccionCliente oDireccion, Int64 nroSEC)
		{
			return new SolicitudDatos().InsertarSolDireccion(oDireccion, nroSEC);
		}

		public bool RegistrarEvaluacionPortabilidad(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarEvaluacionPortabilidad(strDatosSolicitud, ref rMsg, ref nroSEC);
		}

		public bool RegistrarEvaluacionDTH_HFC(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarEvaluacionDTH_HFC(strDatosSolicitud, ref rMsg, ref nroSEC);
		}

		public bool RegistrarEvaluacion(string strDatosSolicitud, ref string rMsg, ref Int64 nroSEC)
		{

			string nameArchivo = "LOG_RegistrarEvaluacion" + "_" + string.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";	
			string initFormatLog = nroSEC + " " + string.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | ";
			HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "***************** Inicio RegistrarEvaluacion", false);
			HelperLog.EscribirLog("", nameArchivo, System.Environment.NewLine, false);
			SolicitudDatos obj = new SolicitudDatos();
			
			return obj.RegistrarEvaluacion(strDatosSolicitud, ref rMsg, ref nroSEC);					
			
			//HelperLog.EscribirLog("", nameArchivo, initFormatLog  + "- rMsg= " + rMsg , false);
		}

		public bool GrabarVentaRenovacion(VentaRenovaPost oVentaRenovaPost, Int64 Accion)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.GrabarVentaRenovacion(oVentaRenovaPost, Accion);
		}
		
		public bool AnularSECSAnteriores(VistaSolicitud oSolicitud)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.AnularSECSAnteriores(oSolicitud);
		}

		public bool AnularVentaRenovacion(string NumeroDoc, string SolinCodigo)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.AnularVentaRenovacion(NumeroDoc, SolinCodigo);
		}

		public bool GrabarSolicitudEmpresaPort(SolicitudEmpresa item,ref Int64 codigo,ref string rMsg) 
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.GrabarSolicitudEmpresaPort(item, ref codigo, ref rMsg);
		}

		public bool RegistrarEvaluacionDatosCreditos(DatosCreditos item)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarEvaluacionDatosCreditos(item);
		}

		public bool ValidarEvaluacion(VistaSolicitudEvaluacion objEntidad)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ValidarEvaluacion(objEntidad);
		}
		
		public bool GrabarFlagTerminadoSol_Cons(string P_SOLIN_CODIGO, string P_SOLIC_USU_CRE,double P_SOLIN_ING_SUS,ref string rMsg) 
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarFlagTerminadoSol_Cons(P_SOLIN_CODIGO,P_SOLIC_USU_CRE,P_SOLIN_ING_SUS ,ref rMsg);
		}	

		public bool GrabarRazonesEvaluacion(Int64 nroSEC, string strnodo,ref string rMsg ) 
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarRazonesEvaluacion(nroSEC,strnodo,ref rMsg);
		}

		public bool GrabarLogHistorico(Int64 nroSEC, string strEstado, string strUsuario, ref string rMsg) 
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarLogHistorico(nroSEC,strEstado,strUsuario, ref rMsg );
		}

		public bool GrabarSolicitudEmpresa(SolicitudEmpresa item, ref Int64 codigo,ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			Int64 codigorep=0;
			string mensajerep="";
			int i=0;
			obj.GrabarSolicitudEmpresa(item,ref codigo,ref rMsg);

			string nameArchivo = "LOGGUARDACORPRP";	
				
			HelperLog.EscribirLog("", nameArchivo, "GrabarSolicitudEmpresa nrosec: " + codigo, false);
			HelperLog.EscribirLog("", nameArchivo, " GrabarSolicitudEmpresa mensaje: " + rMsg, false);

			if (item.REPRESENTANTE_LEGAL.Count>0)
			{
				for(i=0;i<item.REPRESENTANTE_LEGAL.Count;i++)
				{
					RepresentanteLegal oRepLegal = new RepresentanteLegal();
					oRepLegal = (RepresentanteLegal) item.REPRESENTANTE_LEGAL[i];
					oRepLegal.SOLIN_CODIGO = codigo;
					obj.GrabarSolicitudRepLegal(oRepLegal,ref codigorep,ref mensajerep);
					rMsg = mensajerep;
				}
			}
			return true;
		}

		public bool Registrar_Monto_Vencido(Int64 nroSEC, Double Monto_Vencido, string Bloqueo) 
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.Registrar_Monto_Vencido(nroSEC, Monto_Vencido, Bloqueo);
		}

		public bool RegistrarVenta_DTH(AP_Venta item, Int64 nroSEC, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarVenta_DTH(item, nroSEC, ref rMsg);
		}

		public bool RegistrarVentaDetalle_DTH(AP_VentaDetalle item, Int64 strIdVenta, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarVentaDetalle_DTH(item, strIdVenta, ref rMsg);
		}

		public bool RegistrarGarantia_DTH(AP_Garantia item, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarGarantia_DTH(item, ref rMsg);
		}

		public bool GrabarComentario(Comentario item, ref int sEstado, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarComentario(item,ref sEstado,ref rMsg);
		}

		public bool GrabarArchivo(string P_SOLIN_CODIGO, string P_ARCHV_NOM_ARC, string P_ARCHV_RUT_ARC, string P_ARCHC_USU_REG, ref Int64 codigo, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarArchivo(P_SOLIN_CODIGO, P_ARCHV_NOM_ARC, P_ARCHV_RUT_ARC, P_ARCHC_USU_REG, ref codigo, ref rMsg);
		}

		public string AsignarBuroCrediticio(string strDocumento, ref string strUrl, ref string strKey)
		{
			return new SolicitudDatos().AsignarBuroCrediticio(strDocumento, ref strUrl, ref strKey);
		}

		/// <summary>
		/// Metodo		:	ObtenerSolicitudEmpresa
		/// Proposito	:	Invoca al componente de datos para obtener las solicitudes por nro de sec, y nro de documento de identidad.
		/// Entradas	:	Nro Sec, tipo documento identidad , nro documento de identidad.
		/// Retono		:	Retorna una lista de objetos del tipo Solicitud.
		/// </summary>		
		public SolicitudEmpresa ObtenerSolicitudEmpresa(string nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerSolicitudEmpresa(nroSEC);
		}

		public ArrayList ObtenerListaPoolEvaluadorPendienteConsumer2(string login,string estado)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerListaPoolEvaluadorPendienteConsumer2(login,estado);
		}

		public bool GrabarRechazoSolicitudConsumer(Int64 secId,string usuario_login,string motivo_id,string obs, string codestado,ref string rProceso, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarRechazoSolicitudConsumer(secId,usuario_login,motivo_id,obs, codestado,ref rProceso, ref rMsg);
		}

		public RazonesEvaluacion ListaRazonesEvaluacion(string nrosec)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ListaRazonesEvaluacion(nrosec);
		}

		public ArrayList ListaNodosAdversas(string nrosec)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ListaNodosAdversas(nrosec);
		}

		public ArrayList ObtenerArchivos(string nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerArchivos(nroSEC);
		}

		public SolicitudPersona ObtenerSolicitudPersonaCons(string nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerSolicitudPersonaCons(nroSEC);
		}

		public DataSet ObtenerDatosContratoDTH(string nroSEC,string NroContrato)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ObtenerDatosContratoDTH(nroSEC,NroContrato);		
		}

		public ArrayList ObtenerKitEquipo_DTH(string KitCodigo)
		{
			return new SolicitudDatos().ObtenerKitEquipo_DTH(KitCodigo);		
		}

		public ArrayList ObtenerListaHistoricoConsumer(int nroSec,string tipo_documento, string nroDocumento,DateTime fecha_inicio,DateTime fecha_fin, string estac_codigo)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ObtenerListaHistoricoConsumer(nroSec,tipo_documento, nroDocumento,fecha_inicio,fecha_fin, estac_codigo);
		}

		public ArrayList ObtenerLogEstados(Int64 NroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ObtenerLogEstados(NroSEC);
		}

		public void Aprobar_Creditos(VistaSolicitudEvaluacion oItem)
		{
			SolicitudDatos obj = new SolicitudDatos();
			obj.Aprobar_Creditos(oItem);
		}

		public void Rechazar_Creditos(VistaSolicitudEvaluacion oItem)
		{
			SolicitudDatos obj = new SolicitudDatos();
			obj.Rechazar_Creditos(oItem);
		}

		public ArrayList ListarEquiposHFC(string pstrSoplnCodigo)
		{
			return new SolicitudDatos().ListarEquiposHFC(pstrSoplnCodigo);
		}

		public ArrayList ObtenerListaPoolEvaluadorLibreConsumer(string estado,DateTime fecha_inicio,DateTime fecha_fin)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerListaPoolEvaluadorLibreConsumer(estado,fecha_inicio,fecha_fin );
		}

		public bool AsignarActivadorDespachador2(Int64 secId,string usuario,string documento, string bandeja, ref string rMsg) 
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.AsignarActivadorDespachador2(secId,usuario,documento,bandeja,ref rMsg);
		}

		public SolicitudEmpresa ObtenerEvaluacionSolicitud(string nroSEC,string flag_bandeja)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ObtenerEvaluacionSolicitud(nroSEC,flag_bandeja);
		}

		public string AsignarSECAutomatica(string strUsuario)
		{
			return new SolicitudDatos().AsignarSECAutomatica(strUsuario);
		}

		public bool LiberarSECAutomatica(Int64 nroSEC)
		{
			return new SolicitudDatos().LiberarSECAutomatica(nroSEC);
		}

		public string AsignarNextBuroCrediticio(string strDocumento, string strBuro, ref string strUrl, ref string strKey)
		{
			return new SolicitudDatos().AsignarNextBuroCrediticio(strDocumento, strBuro, ref strUrl, ref strKey);
		}

		public bool Asociar_Set_Sot(Int64 nroSec_Asoc,Int64  NroSot_Asoc, Int64 nroSec)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.Asociar_Set_Sot(nroSec_Asoc, NroSot_Asoc, nroSec);
		}

		public SolicitudPersona consulta_sec(string nroSEC)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.consulta_sec(nroSEC);
		}

		public ArrayList ConsultaCampanaDependiente(string codCampana)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ConsultaCampanaDependiente(codCampana);
		}

		public DataTable ConsultaEstadoSOT(long intNroSOT)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ConsultaEstadoSOT(intNroSOT);

		}

		public DataTable ConsultarCompatibilidadTelefono(string pTelRef1)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ConsultarCompatibilidadTelefono(pTelRef1);
		}

		public ArrayList ConsultarTelefonoDisponible_DTH()
		{
			return new SolicitudDatos().ConsultarTelefonoDisponible_DTH();
		}

		public bool RegistrarVentaEquipo_DTH(AP_VentaEquipo item, ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.RegistrarVentaEquipo_DTH(item, ref rMsg);
		}

		public DataTable ListarSolicitudesCoincidentesDTH(string pstrCodTipoDocumento, string pstrNroDocumento, 
			string strCodTipoVenta, string pstrCodTipoCliente, string pstrCodPlazoAcuerdo, string pstrCodCasoEspecial)
		{
			return new SolicitudDatos().ListarSolicitudesCoincidentesDTH(pstrCodTipoDocumento, pstrNroDocumento, 
				strCodTipoVenta, pstrCodTipoCliente, pstrCodPlazoAcuerdo, pstrCodCasoEspecial);
		}

		public ArrayList obtenerComentario(int codigoSec,string tipoComentario)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.obtenerComentario(codigoSec,tipoComentario);
		}

		public bool Valida_Sot_Cliente(Int64 nroSot,string tipoDocCliente, string nroDocCliente, string campanaPadre,ref string codRespuesta, ref string msg)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.Valida_Sot_Cliente(nroSot,tipoDocCliente, nroDocCliente, campanaPadre,ref codRespuesta, ref msg);
		}

		public bool TienePlanIgualDTH(int intpCodSolicitud, int pstrCodPlan, int pintCantidad)
		{
			return new SolicitudDatos().TienePlanIgualDTH(intpCodSolicitud, pstrCodPlan, pintCantidad);
		}

		public bool EliminarRecibo(string P_SOLIN_CODIGO,string P_RECIN_CODIGO,ref string rMsg)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.EliminarRecibo(P_SOLIN_CODIGO, P_RECIN_CODIGO,ref rMsg);
		}

		public bool GrabarRecibo(ReciboDeposito item,ref Int64 codigo, ref string rMsg) 
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.GrabarRecibo(item,ref codigo, ref rMsg);
		}

		public ArrayList ListaRecibo(Int64 nrosec, int banco_id, string nro_recibo)
		{
			SolicitudDatos obj = new SolicitudDatos();			
			return obj.ListaRecibo(nrosec,banco_id,nro_recibo);
		}


		//consolidado 05012015
		public string ActualizarVentaRenovacionDatosComp(string strNroSEC, string strNroDoc, string nroFactura, string nroContrato, string nroPedido, string strTipoRenovacion, string flagExoneracion, string flagDescuento, string strCanal, string titular, string descuento, string usuarioValidador, string RetenidoFidelizado, string strflag_renovChip, string strMotivoRenovChip)
		{
			SolicitudDatos obj = new SolicitudDatos();
			return obj.ActualizarVentaRenovacionDatosComp(strNroSEC, strNroDoc, nroFactura, nroContrato, nroPedido, strTipoRenovacion, flagExoneracion, flagDescuento, strCanal, titular, descuento, usuarioValidador, RetenidoFidelizado, strflag_renovChip, strMotivoRenovChip);
		}
		//consolidado 05012015 - MRAF
		//gaa20160308
		public void TraerTipoOperacionBRMS(string pintNroSec, out string pstrTipoOperacion, out string pstrCobroPenalidad)
		{
			SolicitudDatos obj = new SolicitudDatos();
			obj.TraerTipoOperacionBRMS(pintNroSec, out pstrTipoOperacion, out pstrCobroPenalidad);
		}

		public void InsertarTipoOperacionBRMS(Int64 pintCodSolicitud, Int64 pintTipoOperacion, string pstrCobroPenalidad, double pdobPenalidad, double pdobIGV) 
		{
			SolicitudDatos obj = new SolicitudDatos();
			obj.InsertarTipoOperacionBRMS(pintCodSolicitud, pintTipoOperacion, pstrCobroPenalidad, pdobPenalidad, pdobIGV);
		}
		//fin gaa20160308
	}
}