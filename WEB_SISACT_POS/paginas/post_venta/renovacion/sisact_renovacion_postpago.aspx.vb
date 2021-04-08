Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions
Imports System.Text
Imports Claro.SisAct.Negocios.BWGestionaProteccionMovil 'PROY-24724-IDEA-28174

Public Class sisact_renovacion_postpago
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlNacionalidad As System.Web.UI.WebControls.DropDownList '//PROY 31636 - RENTESEG
    Protected WithEvents ddlOferta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtComentarioPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidFlagExcepcionDC7 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfil_149 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIntentos10 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBLVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVerDetalleLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVerVentaProactiva As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaBlackList As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaParametroGeneral As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTiempoInicioReg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodError As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaRiesgo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRiesgoDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRiesgoTextoDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroOperacionDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDeudaFinancieraDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAutonomia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCreditosxNombres As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAdjuntarIngreso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBlacklistCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidExcepcionBlacklist As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEdadDC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCreditosxReglas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOperadorCedente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroContacto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroFolio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidModalidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArchivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTienePortabilidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroRepresentante As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaRepresentante As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidComentarioPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRazonSocial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaNac As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombre As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApePaterno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApeMaterno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCFTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficinaActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCreditosxCE As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFactorLC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCasoEspecial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCasoEspecialText As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClienteClaro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLineas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTop As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEvaluarMovil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDeuda As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanesActivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaseCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArchivosEnvioCreditos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCreditosxAsesor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensajeAutonomia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCentro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalSap As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrgVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVentaSap As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsuarioNoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesClaro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodEstadoSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLCDisponible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLCDisponiblexProd As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGarantiaxProducto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPoderes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCreditosxDC7 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCadenaDetalle As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrupoPaqueteServer As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidServicioServer As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPromocionServer As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrupoCadena As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCalificacionPago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFactorRenovacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCicloFact As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargoFijoActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLimiteCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRepLegal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTitular As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroPedido As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidnroContrato As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCorreo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumentos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIDCAMPANA As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFactorClaroClub As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodErrorPedido As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClienteSap As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoClienteSAP As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrefijo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidScoreCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSubsidioMenor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSubsidioMayor As System.Web.UI.HtmlControls.HtmlInputHidden
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents ddlTipoOperacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroDoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidarrTipoOferta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txaservadic As System.Web.UI.HtmlControls.HtmlTextArea
    Protected WithEvents btnAgregarPlan As System.Web.UI.HtmlControls.HtmlButton
    Protected WithEvents lblClaroClubMsgError As System.Web.UI.WebControls.Label
    Protected WithEvents txtImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaterialImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArticuloImei As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidProcesarPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMaterialIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVentaCod As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazoAcuerdo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtClaroClubPuntosUtilizar As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescuentoClaroClub As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrecioVenta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotalAPagar As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidPrecioVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanTarifaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidlistaPrecioSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtResultado As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRiesgo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLCDisponible As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTipoGarantia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImporte As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidPrecioVentaEv As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioListaEv As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlVendedorSAP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidVendedorSAP As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsgTitularidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargoFijoNuevo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRatioFactorMin As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRatioFactorMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValidaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOferta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaIniCC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaFinCC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSegmento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagRoamingI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTextRangoLC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRiesgoClaro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidComportamiento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBAM As System.Web.UI.HtmlControls.HtmlInputHidden
    Dim oClienteCuenta As New ClienteCuenta
    Protected WithEvents hidPlanBase As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanCombo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMontoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMSJMontoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtSerieChip As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaterialICCID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArticuloICCID As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidDesMaterialIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValidarIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblPlanChip As System.Web.UI.WebControls.Label
    Protected WithEvents hidPlanBolsaCompartida As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPermanencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazoAcuerdoBRMS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOvencAsistencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDocVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNomVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensajeRenovacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents chkRetenido As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFidelizado As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlCodEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlSerieEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hdnRetenidoFidelizado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlListaPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDescuentoEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCodChip As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrecioVentaEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodChip As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlSerieChipICCID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRenovChip As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroLineaEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPrecioChip As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidRespuestaChip As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSerieEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesPorVencer As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMontoMaxDesAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtpreciochip As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidPlanDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIMEI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosChip As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlModalidad As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidModalidadVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesMaxAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPrecioChips As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidIMSI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPrecioDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPLSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVentaCAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanAct As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagReintegro As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidFlagExonerarReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCustumerId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApellidosCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOpcionAutorizacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagConfExoneracionReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTotalAPagarCAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombresCli As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidValidarCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAuditoriaLogs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrabar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfilCreditos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfilSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalOf As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoRenovacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPrecioVentaChip As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrecioVentaEquipoDAC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumeroLineaChip As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidFlagRenovacionAdelantada As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFormaPagoReintegro As System.Web.UI.HtmlControls.HtmlInputHidden  'jmori add
    Protected WithEvents hidflagIdValidator As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagIdValidator_RespPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSecPadre As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargoFijoSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlgCierre As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hiCFSiga As System.Web.UI.HtmlControls.HtmlInputHidden 'jmori
    Protected WithEvents hidImporteRenta As System.Web.UI.HtmlControls.HtmlInputHidden


    Protected WithEvents hidcodGarantia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagValDcto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCuota As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCuentaBSCS As System.Web.UI.HtmlControls.HtmlInputHidden
    'consolidado 27012015
    Protected WithEvents hidNombredelEquipoCAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdSolPlan As System.Web.UI.HtmlControls.HtmlInputHidden
    'consolidado 27012015


    Protected WithEvents hidMontoMaxDesASMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesMaxASMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents chkPlanNoVigente As System.Web.UI.WebControls.CheckBox

    'jmori

    'plan no vigente 29102015
    Protected WithEvents hidVigente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMantenerPlan As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodPlanNoVigente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidplanDesNoVig As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents chk4G As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ch4G As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hid4G As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdPlanVig As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlGProducto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidplanAsoc As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents lblHLR As System.Web.UI.WebControls.Label
    Protected WithEvents lblHLRCAC As System.Web.UI.WebControls.Label
    Protected WithEvents hidHLR As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombredelChipCAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lbl4GCAC As System.Web.UI.WebControls.Label
    Protected WithEvents hidPlanTLE As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblPlanLTE As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlanLTECAC As System.Web.UI.WebControls.Label
    Protected WithEvents hidTLE As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidPl4G As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dllMotivoDAC As System.Web.UI.WebControls.DropDownList

    Protected WithEvents hidMesesMaxASMaxDias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesMaxASDias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsgPlanEmpleadoDatos As System.Web.UI.HtmlControls.HtmlInputHidden
  'PROY-24724-IDEA-28174 - INICIO
    Protected WithEvents hidPrima As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDeducible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCertificadoPM As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEvalPM As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsjErrorGrabarPM As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents chkProMovil As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtPrima As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeducible As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidErrorGrabarProtMovil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrimaEval As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents HidSecGra As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosAdicionalesPM As System.Web.UI.HtmlControls.HtmlInputHidden
    'PROY-24724-IDEA-28174 - FIN

    'PROY-24724-IDEA-28174 - INI -  Parámetros
    Protected WithEvents hidCodPrecioPrepagoMinimo As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidPM_NoCalifica As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidPM_NoCumpleRequisito As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidErrorGrabarEvalProtMovil As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidConsErrorGrabarProtMovil As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidPM_MontoPrimaMayor As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidConfirmEliminarProtMovil As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidMsjEquipoEvaluado As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidMsjSeleccionarEquipo As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidMsjPMOfrecerSeguro As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidCodServProteccionMovil As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidClienteWsError As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hdCanMaxMeses As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdCanMinMeses As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdAutoriza As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCerrarValid As System.Web.UI.HtmlControls.HtmlInputHidden
    'PROY-24724-IDEA-28174 - FIN -  Parámetros

    'Oscar Atencio Timana
    Protected WithEvents hidCheckCartaPoder As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOVENV_OUTOFFBIO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidflagBioPost As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidflagHuelleroPost As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdPadreBio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBiometriaExito As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosBio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCurrentUser As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSerieLector As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidNacionalidad As System.Web.UI.HtmlControls.HtmlInputHidden '//PROY 31636 
    Protected WithEvents hidNacSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden '//PROY 31636
    Protected WithEvents hidTodoTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden '//PROY 31636
    Protected WithEvents hidSoporteVentaCorp As System.Web.UI.HtmlControls.HtmlInputHidden '//PROY 31636
    Protected WithEvents hidNacionalidadCliente As System.Web.UI.HtmlControls.HtmlInputHidden '//PROY 31636

    Protected WithEvents trCartaPoder As System.Web.UI.HtmlControls.HtmlTableRow

    'Oscar Atencio Timana

    'PROY-32129 :: INI
    Protected WithEvents ddlListaUni As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigoAlumno As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidEstadoCasoEsp As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdCampSelec As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFila As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidTipoDocPermitidoPostCAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocPermitidoPostDAC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocPermitidoPostCAD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigoDocMigraYPasaporte As System.Web.UI.HtmlControls.HtmlInputHidden


    'PROY-32129 :: FIN


    'plan no vigente 29102015
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    End Sub

    Dim oClienteOfrecimiento As New ArrayList
    Protected oSolicitud As New SolicitudPersona
    Dim canalOf As String = String.Empty
#End Region

#Region "Constantes"
    Dim oLog As New SISACT_Log
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_renovacion_postpago")
    Dim strIdentifyLog As String
    Dim strFlujoAlta As String = ConfigurationSettings.AppSettings("flujoAlta")
    Dim strFlujoPortabilidad As String = ConfigurationSettings.AppSettings("flujoPortabilidad")
    Dim constTipoProductoCON As String = ConfigurationSettings.AppSettings("constTipoProductoCON")
    Dim constTipoProductoBUS As String = ConfigurationSettings.AppSettings("constTipoProductoBUS")
    Dim constTipoProductoB2E As String = ConfigurationSettings.AppSettings("constCodTipoProductoB2E")
    Dim constSegmentoCON As String = ConfigurationSettings.AppSettings("constSegmentoCON")
    Dim constSegmentoECA As String = ConfigurationSettings.AppSettings("constSegmentoECA")
    Dim constDesResultadoFinalAPR As String = ConfigurationSettings.AppSettings("constDesResultadoFinalAPR")
    Dim constEstadoAPRENVACT As String = ConfigurationSettings.AppSettings("constEstadoAprobadoEnvActiva")
    Dim constDesEstadoAPRENVACT As String = ConfigurationSettings.AppSettings("constDesEstadoAprobadoEnvActiva")
    Dim constEstadoEnvCreditos As String = ConfigurationSettings.AppSettings("constEstadoEnvCreditos")
    Dim constDesEstadoEnvCreditos As String = ConfigurationSettings.AppSettings("constDesEstadoEnvCreditos")
    Dim constEstadoPENDADJARCH As String = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS")
    Dim constDesEstadoPENDADJARCH As String = ConfigurationSettings.AppSettings("constdesEstadoSECPENDADJARCHIVOS")
    Dim constEstadoENVPOOLEMIT As String = ConfigurationSettings.AppSettings("constEstadoENVPOOLEMIT")
    Dim constCodCodCanalDefectoMT As String = ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT")
    Dim constCodEvaluadorPDV As String = ConfigurationSettings.AppSettings("constCodEvaluadorPDV")
    Dim constCodEvaluadorCET As String = ConfigurationSettings.AppSettings("constCodEvaluadorCET")
    Dim constDesEstadoENVPOOLEMIT As String = ConfigurationSettings.AppSettings("constDesEstadoENVPOOLEMIT")
    Dim constVentaRegistrado As String = ConfigurationSettings.AppSettings("constVentaRegistrado")
    Dim constVentaAprobado As String = ConfigurationSettings.AppSettings("constVentaAprobado")
    Dim constEstadoAPR As String = ConfigurationSettings.AppSettings("constEstadoAPR")
    Dim constDesEstadoAPR As String = ConfigurationSettings.AppSettings("constDesEstadoAPR")
    Dim dblIGV As Double = ConfigurationSettings.AppSettings("TasaIGV")

    'PROY-24724-IDEA-28174 - INICIO 
    Dim strGenerarCadenaCabeceraMSSPM As String = String.Empty
    Dim strGenerarCadenaDetalleMSSPM As String = String.Empty
    Dim strNroPedCabProtMovil As String = String.Empty
    'PROY-24724-IDEA-28174 - FIN 

#End Region

    Dim codMasivo, codCorporativo As String

    'INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
    Private Sub RegistrarAcuerdoReno(ByVal nroPedido As Long, ByVal nroContrato As Long)
        oLog.Log_WriteLog(strArchivo, "PROY-9067 : La Renovacion es anticipada : " & hidFlagRenovacionAdelantada.Value)
        If hidFlagRenovacionAdelantada.Value = True Then
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Pasa RenovacionAnticipada: " & hidFlagRenovacionAdelantada.Value.ToString())

            Dim oRenoAnti As BLRenoAnticipada = New BLRenoAnticipada
            Dim vRenoAnticipada As BERenoAnti = New BERenoAnti
            Dim oCodRpta As String = ""
            Dim oMensaje As String = ""

            vRenoAnticipada.N_NRO_PEDIDO = nroPedido
            vRenoAnticipada.N_NRO_CONTRATO = nroContrato
            vRenoAnticipada.V_MSISDN = hidNroLinea.Value
            vRenoAnticipada.V_CO_ID = hidCO.Value
            vRenoAnticipada.N_CUSTOMER_ID = hidCustumerId.Value
            vRenoAnticipada.V_TIPO_DOCUMENTO = hidTipoDocumento.Value
            vRenoAnticipada.N_NRO_DOCUMENTO = hidNroDocumento.Value
            vRenoAnticipada.V_TIPO_CLIENTE = ConfigurationSettings.AppSettings("TipoClienteRenoAnticipada") 'CUSTOMER
            vRenoAnticipada.V_COD_EQUIPO = CheckStr(hidIMEI.Value)
            vRenoAnticipada.V_COD_MATERIAL = CheckStr(txtCodEquipo.Text)
            vRenoAnticipada.V_ESTADO = ConfigurationSettings.AppSettings("EstadoRenoAnticipada") 'REGISTRADO
            vRenoAnticipada.V_TIPO_RENOVACION = ConfigurationSettings.AppSettings("constTipoRenovAnticipada") 'RENOVACION
            vRenoAnticipada.N_NRO_SEC = hidNroSEC.Value

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_NRO_PEDIDO: " & vRenoAnticipada.N_NRO_PEDIDO.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_NRO_CONTRATO: " & vRenoAnticipada.N_NRO_CONTRATO.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_MSISDN: " & vRenoAnticipada.V_MSISDN)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_CO_ID: " & vRenoAnticipada.V_CO_ID.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_CUSTOMER_ID: " & vRenoAnticipada.N_CUSTOMER_ID.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_TIPO_DOCUMENTO: " & vRenoAnticipada.V_TIPO_DOCUMENTO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_NRO_DOCUMENTO: " & vRenoAnticipada.N_NRO_DOCUMENTO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_TIPO_CLIENTE: " & vRenoAnticipada.V_TIPO_CLIENTE)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_COD_EQUIPO: " & vRenoAnticipada.V_COD_EQUIPO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_COD_MATERIAL: " & vRenoAnticipada.V_COD_MATERIAL)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_ESTADO: " & vRenoAnticipada.V_ESTADO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_TIPO_RENOVACION: " & vRenoAnticipada.V_TIPO_RENOVACION)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_NRO_SEC: " & vRenoAnticipada.N_NRO_SEC.ToString())
            
            Dim oGA As BEGestionAcuerdoWS = New BEGestionAcuerdoWS
            oGA = Session("GestionAcuerdoWS")

            vRenoAnticipada.N_ID_ACUERDO = oGA.acuerdoId
            vRenoAnticipada.D_FECHA_ACUERDO = oGA.acuerdoFechaInicio 'ws
            vRenoAnticipada.V_ESTADO_ACUERDO = oGA.acuerdoEstado 'ws

            Dim oMonFide As Double = 0.0
            Dim oMonApa As Double = 0.0
            oMonApa = oGA.acuerdoMontoApacedeTotal
            oMonFide = IIf(hdnRetenidoFidelizado.Value.ToUpper = "FIDELIZADO", 0, oGA.acuerdoMontoApacedeTotal)

            vRenoAnticipada.N_MONTO_ORIGINAL = oMonApa 'ws
            vRenoAnticipada.N_MONTO_FIDELIZA = oMonFide 'ws
            vRenoAnticipada.N_MONTO_REINTEGRO = oMonApa - oMonFide 'ws

            vRenoAnticipada.V_FLAG_APLICA_REINTEGRO = IIf(vRenoAnticipada.N_MONTO_REINTEGRO = 0, 0, 1) '     hidFlagReintegro.Value 'ws
            'vRenoAnticipada.V_FLAG_FIDELIZA = hdnRetenidoFidelizado.Value ' hidFlagExonerarReintegro.Value  'ws
            vRenoAnticipada.V_FLAG_FIDELIZA = IIf(hdnRetenidoFidelizado.Value.ToUpper = "FIDELIZADO", "NO FIDELIZADO", "FIDELIZADO")
            vRenoAnticipada.CL_DATOS_ACTUALIZA = oGA.CadenaXml 'cadena xml response.
            vRenoAnticipada.V_BD_ORIGEN = oGA.acuerdoOrigen
            vRenoAnticipada.V_CANAL = hidPuntoVenta.Value
            vRenoAnticipada.V_USU_CREACION = CurrentUser

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  D_FECHA_ACUERDO: " & vRenoAnticipada.D_FECHA_ACUERDO.ToShortDateString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_ESTADO_ACUERDO: " & vRenoAnticipada.V_ESTADO_ACUERDO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_MONTO_ORIGINAL: " & vRenoAnticipada.N_MONTO_ORIGINAL.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_MONTO_FIDELIZA: " & vRenoAnticipada.N_MONTO_FIDELIZA.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  N_MONTO_REINTEGRO: " & vRenoAnticipada.N_MONTO_REINTEGRO.ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_FLAG_APLICA_REINTEGRO: " & vRenoAnticipada.V_FLAG_APLICA_REINTEGRO)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  V_FLAG_FIDELIZA: " & vRenoAnticipada.V_FLAG_FIDELIZA)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  CL_DATOS_ACTUALIZA: " & vRenoAnticipada.CL_DATOS_ACTUALIZA)

            oLog.Log_WriteLog(strArchivo, "PROY-9067 : Iniciando Metodo RegRenoAnticipada")
            oRenoAnti.RegRenoAnticipada(vRenoAnticipada, oCodRpta, oMensaje)
            If oCodRpta <> 0 Then
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  ERROR RenovacionAnticipada - RegRenoAnticipada-->  oCodRpta:" & oCodRpta & ", oMensaje: " & oMensaje)
            End If

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Fin RenovacionAnticipada - RegRenoAnticipada -->  oCodRpta:" & oCodRpta & ", oMensaje: " & oMensaje)
        End If
     
    End Sub
    'FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Anthem.Manager.Register(Me)
        hidCurrentUser.Value = CurrentUser() 'PROY-25335 - Contratación Electrónica - Release 0

        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language='javascript'>validarUrl();</script>")
        Else
            Response.Write("<script language='javascript'>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        ddlListaPrecio.Attributes.Add("onChange", "cargarPrecioEquipo();")
        ddlPrecioChip.Attributes.Add("onChange", "cargarPrecioChip();")



        If Not Page.IsPostBack Then
            'PROY-24724-IDEA-28174 - INI -  Parámetros
            Try
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** MaestroNegocio().ListaParametrosGrupo_Keys INI ** -> Paran_Grupo: " & ClsKeyAPP.intParamGrupo)
                ClsKeyAPP.ListParametros = New MaestroNegocio().ListaParametrosGrupo_Keys(ClsKeyAPP.intParamGrupo)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** Total Lista Obtenida: " & ClsKeyAPP.ListParametros.Count)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** MaestroNegocio().ListaParametrosGrupo_Keys FIN  ** ")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** ClsKeyAPP.ObtenerParametro INI ** -> Paran_Grupo: " & ClsKeyAPP.intParamGrupo)
                ClsKeyAPP.ObtenerParametro(ClsKeyAPP.intParamGrupo)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** ClsKeyAPP.ObtenerParametro FIN **")
            Catch ex As Exception
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** Error MaestroNegocio().ListaParametrosGrupo_Keys")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "** Mensaje Ex: " & ex.Message)
            End Try

            hidCodPrecioPrepagoMinimo.Value = ClsKeyAPP.strCodPrecioPrepagoMinimo
            hidPM_NoCalifica.Value = ClsKeyAPP.strNoCalificaProt.Replace("{0} ", "")
            hidPM_NoCumpleRequisito.Value = ClsKeyAPP.strNoCumpleRequisito.Replace("{0} ", "").Replace("{1}.{2}", "")
            hidErrorGrabarEvalProtMovil.Value = ClsKeyAPP.strErrorGrabarEvalProtMovil
            hidConsErrorGrabarProtMovil.Value = ClsKeyAPP.strErrorGrabarProtMovil
            hidPM_MontoPrimaMayor.Value = ClsKeyAPP.strMontoPrimaMayor
            hidConfirmEliminarProtMovil.Value = ClsKeyAPP.strConfirmEliminarProtMovil
            hidMsjEquipoEvaluado.Value = ClsKeyAPP.strMsjEquipoEvaluado
            hidMsjSeleccionarEquipo.Value = ClsKeyAPP.strMsjSeleccionarEquipo
            hidMsjPMOfrecerSeguro.Value = ClsKeyAPP.strMsjPMOfrecerSeguro
            hidCodServProteccionMovil.Value = ClsKeyAPP.strCodServProteccionMovil
            hidClienteWsError.Value = ConfigurationSettings.AppSettings("consClienteProteccionMovilWS_Error")
            'PROY-24724-IDEA-28174 - FIN -  Parámetros

            hidTipoDocPermitidoPostCAC.Value = AppSettings.Key_tipoDocPermitidoPostCAC
            hidTipoDocPermitidoPostDAC.Value = AppSettings.Key_tipoDocPermitidoPostDAC
            hidTipoDocPermitidoPostCAD.Value = AppSettings.Key_tipoDocPermitidoPostCAD
            hidCodigoDocMigraYPasaporte.Value = AppSettings.Key_codigoDocMigraYPasaporte

            Dim oPuntoVenta As New PuntoVenta
            Dim BolPuntoV As Boolean = True
            oPuntoVenta = ObtenerOficina(BolPuntoV)
            Session("PuntoVentaSelected") = oPuntoVenta
            If BolPuntoV Then
                hidPuntoVenta.Value = CheckStr(oPuntoVenta.TOFIC_CODIGO)
                hidOvencAsistencia.Value = CheckStr(oPuntoVenta.OVENC_ASISTENCIA)
                If oPuntoVenta.TOFIC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") AndAlso oPuntoVenta.OVENC_ASISTENCIA = "1" Then

                    Dim flagVendedorValido As String = CheckStr(Request.QueryString("flagVendedorValido"))
                    hidDocVendedor.Value = CheckStr(Request.QueryString("VenDesc"))
                    hidNomVendedor.Value = CheckStr(Request.QueryString("VendDoc"))
                    hidFlagVendedor.Value = CheckStr(flagVendedorValido)

                    If flagVendedorValido = "S" Then
                        Inicio()
                        LlenarTipoOferta()
                        'LlenarTipoOperacion()
                        LLenarListaUniv() 'PROY-32129
                    End If
                Else
                    Inicio()
                    LlenarTipoOferta()
                    LLenarListaUniv() 'PROY-32129
                End If

                LlenarTipoOperacion()
            End If
        Else
            Dim Accion As String = hidAccion.Value
            Select Case Accion
                Case "Grabar"
                    Grabar()
                Case "GenerarPedido"
                    Grabar()
            End Select
        End If
    End Sub

' Inicio PROY-25335 - Contratación Electrónica - Release 0
    Private Sub LleanrParametrosBio(ByRef flagBioPost As String, ByRef flagHuelleroPost As String)
        Dim oMaestro As New MaestroNegocio
        Dim oUsuario As Usuario
        oUsuario = oMaestro.ObtenerUsuarioLogin(CurrentUser)
        Dim listaPuntoVenta As ArrayList = New MaestroNegocio().ListaPDVUsuario(oUsuario.UsuarioId, "")
        Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
        flagBioPost = itemPuntoVenta.OVENC_FLAG_BIO_POST
        flagHuelleroPost = itemPuntoVenta.OVENC_FLAGHUELLERO_POST
    End Sub
'Fin PROY-25335 - Contratación Electrónica - Release 0

    Private Function ObtenerOficina(ByRef BolPuntoV As Boolean) As PuntoVenta
        Dim oPuntoVenta As New PuntoVenta

        Try
            If (Not Session("DatosOficina") Is Nothing) Then
                oPuntoVenta = CType(Session("DatosOficina"), PuntoVenta)
            Else
                Dim oMaestro As New MaestroNegocio
                Dim oMantMaestro As New MantMaestroNegocio
                Dim oUsuario As Usuario

                oUsuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
                oMaestro = Nothing

                ' Buscar Punto de Venta
                Dim listaPuntoVenta As ArrayList = New MaestroNegocio().ListaPDVUsuario(oUsuario.UsuarioId, "")

                If listaPuntoVenta.Count = 0 Then
                    BolPuntoV = False
                    Throw New Exception("Error: Usuario no pertenece a algún Punto de Venta.")
                End If

                ' Guardar los datos escogidos a Session
                oPuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)


                '************************RESTRINGIR PUNTOS DE VENTA*********************************

                'Validar Punto de venta para reposicion
                ' Guardar los datos generales de Venta
                Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
                Dim objUsuarioNeg As LoginUsuarioNegocios = New LoginUsuarioNegocios
                Dim puntoVentaLogin As PuntoVenta = objUsuarioNeg.ValidarOficinaVenta(itemPuntoVenta.OVENC_CODIGO)

                If IsNothing(puntoVentaLogin) Then
                    BolPuntoV = False
                    Throw New Exception("El Punto de Venta " & itemPuntoVenta.OVENV_DESCRIPCION & " no está configurado para la renovación.")
                Else
                    Dim valorRenovacion As String = puntoVentaLogin.OVENC_PDV_RENOV
                    If Not valorRenovacion.Equals("1") Then
                        hidMensajeRenovacion.Value = "El Punto de Venta " & puntoVentaLogin.OVENV_DESCRIPCION & " no está configurado para la renovación."
                        BolPuntoV = False
                        Throw New Exception(hidMensajeRenovacion.Value)
                    End If
                End If

                '************************RESTRINGIR PUNTOS DE VENTA*********************************
            End If
            Session("DatosOficina") = oPuntoVenta
            hidOfVentaCod.Value = CheckStr(oPuntoVenta.OVENC_CODIGO)
        Catch ex As Exception
            BolPuntoV = False
            Alert(ex.Message)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error. En obtener oficina de venta: " & ex.Message)
        End Try
        Return oPuntoVenta
    End Function

    Private Sub CargarTipoDocumento()
        Dim lista As ArrayList = (New VentaNegocios).ListaTipoDocumento("")
        lista.RemoveRange(2, 1) 'Remover CIP - PROY-31636-RENTESEG
        Dim lstTipoDocumentoTemp As New ArrayList

        Dim sbTipoDocumento As New StringBuilder
        Dim strTipoDocumento As String = String.Empty
        Dim strSoporteVentaCorp As String = String.Empty
        For Each item As ItemGenerico In lista
            strTipoDocumento += IIf(strTipoDocumento = String.Empty, item.Codigo & ";" & item.Descripcion, "|" & item.Codigo & ";" & item.Descripcion)
            If ddlCanal.SelectedValue.ToString = ConfigurationSettings.AppSettings("constCodTipoCAC").ToString() Then
                If AppSettings.Key_tipoDocPermitidoPostCAC.IndexOf(item.Codigo) > -1 Then
                    lstTipoDocumentoTemp.Add(item)
                End If
            ElseIf ddlCanal.SelectedValue.ToString = ConfigurationSettings.AppSettings("constCodTipoDAC").ToString() Then
                If AppSettings.Key_tipoDocPermitidoPostDAC.IndexOf(item.Codigo) > -1 Then
                    lstTipoDocumentoTemp.Add(item)
                End If
            ElseIf ddlCanal.SelectedValue.ToString = ConfigurationSettings.AppSettings("constCodTipoCRN").ToString() Then
                If AppSettings.Key_tipoDocPermitidoPostCAD.IndexOf(item.Codigo) > -1 Then
                    lstTipoDocumentoTemp.Add(item)
                End If
            End If
            If item.Codigo = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") Or _
                item.Codigo = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Or _
                item.Codigo = ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") Then
                strSoporteVentaCorp += IIf(strSoporteVentaCorp = String.Empty, item.Codigo & ";" & item.Descripcion, "|" & item.Codigo & ";" & item.Descripcion)
                lstTipoDocumentoTemp.Add(item)
            End If
            strSoporteVentaCorp += IIf(item.Codigo = "07", "|" & item.Codigo & ";" & item.Descripcion, "")
            '//INI PROY 31636 RENTESEG

            sbTipoDocumento.Append(item.Codigo)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.Codigo2)
            sbTipoDocumento.Append("|")
        Next item

        hidTodoTipoDoc.Value = strTipoDocumento
        hidSoporteVentaCorp.Value = strSoporteVentaCorp
        lista = lstTipoDocumentoTemp
        sbTipoDocumento.Remove(sbTipoDocumento.Length - 1, 1)
        hidTipoDocumentos.Value = sbTipoDocumento.ToString

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        Dim oItemTemp As New ItemGenerico

        oItemTemp = lista(1)
        lista(1) = lista(2)
        lista(2) = oItemTemp

        LlenaCombo(lista, ddlTipoDocumento, "Codigo", "Descripcion")
    End Sub

    'Private Function validarClienteSap() As Boolean
    '    Dim oConsultaSap As New SapGeneralNegocios

    '    Dim blnExito As Boolean = True
    '    Dim nroDocCliente As String = hidNroDocumento.Value
    '    Dim tipoDocCliente As String = hidTipoDocumento.Value
    '    Dim oficina As String = CheckStr(hidOficina.Value)
    '    Dim strScript As String

    '    Try
    '        Dim dsCliente As DataSet = oConsultaSap.Get_ConsultaCliente(oficina, tipoDocCliente, nroDocCliente)

    '        If IsNothing(dsCliente) OrElse dsCliente.Tables(0).Rows.Count = 0 Then
    '            hidMsg.Value = String.Format("Error. Cliente no se encuentra registrado en SAP.")
    '            blnExito = False

    '        End If
    '    Catch ex As Exception
    '        blnExito = False
    '        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error. Consultar Cliente Sap: " & ex.Message)

    '    Finally
    '        oConsultaSap = Nothing
    '    End Try

    '    Return blnExito
    'End Function

    Public Sub CrearClientePVU(ByVal nroDocCliente As String, ByVal tipoDocCliente As String, ByVal oSolicitud As SolicitudPersona)
        Try
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "(New BLConsultaMssap).ConsultaCliente: " & Funciones.CheckStr(nroDocCliente) & "|" & Funciones.CheckStr(tipoDocCliente))
            Dim oBEClienteSAP As BECliente = (New BLConsultaMssap).ConsultaCliente(nroDocCliente, tipoDocCliente)
            If (oBEClienteSAP Is Nothing) Then
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Crear cliente")
                oBEClienteSAP = New BECliente
                oBEClienteSAP.Cliente = nroDocCliente
                oBEClienteSAP.TipoDocCliente = tipoDocCliente
                oBEClienteSAP.Nombre = oSolicitud.CLIEV_NOMBRE
                oBEClienteSAP.ApellidoPaterno = oSolicitud.CLIEV_APE_PAT
                oBEClienteSAP.ApellidoMaterno = oSolicitud.CLIEV_APE_MAT
                oBEClienteSAP.RazonSocial = oSolicitud.CLIEV_RAZ_SOC
                oBEClienteSAP.FechaNacimiento = IIf(IsDate(oSolicitud.FECHA_NACIMIENTO), oSolicitud.FECHA_NACIMIENTO, ConfigurationSettings.AppSettings("ConsDefaultFechaNacimiento"))
                oBEClienteSAP.DireccionLegal = "-"
                oBEClienteSAP.UbigeoLegal = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad")
                oBEClienteSAP.VendedorSap = Session("CodVendedorSAP")
                oBEClienteSAP.UsuarioCrea = CurrentUser
                oBEClienteSAP.TipoCliente = ConfigurationSettings.AppSettings("ConsTipoVentasPostpago")

                'Inicio PROY-25335 - Contratación Electrónica - Release 0
                ' OSCAR ATENCIO TIMANA
                If (hidBiometriaExito.Value.Equals("1")) Then

                    If (tipoDocCliente.Equals("06")) Then
                        oBEClienteSAP.ReplegalTipDoc = "01"
                        oBEClienteSAP.ReplegalNroDoc = CheckStr(hidDatosBio.Value).Split(",")(3)
                        oBEClienteSAP.ReplegalNombre = CheckStr(hidDatosBio.Value).Split(",")(0)
                        oBEClienteSAP.ReplegalApePat = CheckStr(hidDatosBio.Value).Split(",")(1)
                        oBEClienteSAP.ReplegalApeMat = CheckStr(hidDatosBio.Value).Split(",")(2)

                    Else
                    oBEClienteSAP.Nombre = CheckStr(hidDatosBio.Value).Split(",")(0)
                    oBEClienteSAP.ApellidoPaterno = CheckStr(hidDatosBio.Value).Split(",")(1)
                    oBEClienteSAP.ApellidoMaterno = CheckStr(hidDatosBio.Value).Split(",")(2)
                End If
                End If
                ' OSCAR ATENCIO TIMANA
                'Fin PROY-25335 - Contratación Electrónica - Release 0

                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "(New ConsultaMsSapNegocio).ActualizaCliente")
                Dim rspta = (New ConsultaMsSapNegocio).ActualizaCliente(oBEClienteSAP)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "(New ConsultaMsSapNegocio).ActualizaCliente -> [rspta]=" & Funciones.CheckStr(rspta))
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "(New BLConsultaMssap).ConsultaCliente: " & ex.Message)
        End Try
    End Sub

    Private Function GenerarCadenaCabecera() As String
        Dim cadenaCabecera As String

        'ini sinergia 31072015
        Dim oConsultarSap As New SapGeneralNegocios
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim ccliente As New BECliente
        'fin sinergia 31072015

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        Try

            Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
            Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)

            If Not hidPerfil_149.Value = "S" Then
                codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
            End If

            Dim nroDocCliente As String = CheckStr(hidNroDocumento.Value)
            Dim tipoDocCliente As String = CheckStr(hidTipoDocumento.Value)
            Dim tipoVenta As String = hidTipoVenta.Value
            Dim tipoCliente As String = hidTipoClienteSAP.Value
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")
            Dim tipoDocVenta As String
            Dim DesTipoOperacion As String = ""

            If (tipoDocCliente = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC")) Then
                tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaRUC")
            Else
                tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaNORUC")
            End If
            If hidValidarIccid.Value.Equals("1") Then
                DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacionpack")
            Else
                DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion")
            End If

            Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")

            Dim precios As String = CheckStr(hidDatosEquipo.Value)
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)
            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))

            'Crear Cliente en PVUDB
            CrearClientePVU(nroDocCliente, tipoDocCliente, oSolicitud)
 
            Dim strSector As String = ConfigurationSettings.AppSettings("constSINERGIASectorPostpagoEquipoChip")
 
            Dim oPar As BEParametroOficina
            oPar = oConsultaMSSAP.ParametrosOficina(strCodOficina)    'ParametrosOficinaVenta(oficina)
            Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(strCodOficina, "")
            Dim canal As String = ConfigurationSettings.AppSettings("ConsCanalMSSAP")
            Dim orgVenta, sector, strCentro As String

            orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia"))
            strCentro = oParPVU.codigoCentro
            sector = strSector.PadLeft(2, CChar("0"))

            Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")

            Dim CodInterlocutor As String = ""

            Dim ClaseFactura As String = ConfigurationSettings.AppSettings("ConsCodigoBoleta"), DescripcionFactura As String = ConfigurationSettings.AppSettings("ConsDescripcionBoleta")

            For Each item As String In ConfigurationSettings.AppSettings("ConsTipoDNIFactura").Split(CChar(";"))
                If tipoDocCliente = Funciones.CheckStr(item) Then
                    ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoFactura")
                    DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionFactura")
                    Exit For
                End If
            Next

            Dim codvend As String = "0000000000" + codigoVendedorSAP
            Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")

            'Cadena Documento
            Dim arrayCabecera(52) As String

            arrayCabecera(0) = ""  '""                                    'Documento
            arrayCabecera(1) = oPar.CodigoInterlocutor ' 'tipoDocVenta                          'Tipo_Documento
            arrayCabecera(2) = ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoVentaAlta") 'oficina                               'Oficina_Venta
            arrayCabecera(3) = orgVenta 'Now.ToString("dd/MM/yyyy")           'String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
            arrayCabecera(4) = canal 'tipoDocCliente                        'Tipo_Doc_Cliente
            arrayCabecera(5) = sector 'nroDocCliente                         'Cliente
            arrayCabecera(6) = ConfigurationSettings.AppSettings("ConsTipoVentasPostpago")
            arrayCabecera(7) = Now.ToString()  'moneda                                'Moneda
            arrayCabecera(8) = ConfigurationSettings.AppSettings("ConsMotivoPedidoPortabilidad")
            arrayCabecera(9) = ClaseFactura  'totalSinIGV                           'Total_Mercaderia
            arrayCabecera(10) = DescripcionFactura 'totalIGV                             'Total_Impuesto
            arrayCabecera(11) = "" 'totalConIGV                          'Total_Documento
            arrayCabecera(12) = ConfigurationSettings.AppSettings("constSINERGIAClasePedidoFacturas") '""                                  'Fecha registro
            arrayCabecera(13) = tipoOperacion
            arrayCabecera(14) = DesTipoOperacion 'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayCabecera(15) = Now.ToString()  'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayCabecera(16) = ConfigurationSettings.AppSettings("constAplicacion") ' tipoVenta                            'Tipo_Venta
            arrayCabecera(17) = CheckStr(Session("CodVendedorSAP")) 'codigoVendedorSAP '""
            arrayCabecera(18) = ConfigurationSettings.AppSettings("ConsDocPrepagoPendientes")
            arrayCabecera(19) = "N"
            arrayCabecera(20) = "0"
            arrayCabecera(21) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad")
            arrayCabecera(22) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta")                                 'Fecha Vta Or
            arrayCabecera(23) = tipoDocCliente
            arrayCabecera(24) = nroDocCliente                            'nro_cuota
            arrayCabecera(25) = Funciones.CheckStr(hidTipoCliente.Value) 'CheckStr(Session("CodVendedorSAP"))  'nro clarify
            arrayCabecera(26) = oSolicitud.CLIEV_NOMBRE
            arrayCabecera(27) = oSolicitud.CLIEV_APE_PAT                   'Vendedor
            arrayCabecera(28) = oSolicitud.CLIEV_APE_MAT
            arrayCabecera(29) = ConfigurationSettings.AppSettings("ConsDefaultFechaNacimiento")                     'Renovacion
            arrayCabecera(30) = oSolicitud.CLIEV_RAZ_SOC                          'Descripción Renovacion
            arrayCabecera(31) = oSolicitud.SOLIV_CORREO
            arrayCabecera(32) = ConfigurationSettings.AppSettings("ConsSinInformacion")
            arrayCabecera(33) = oSolicitud.ESTADO_CIVIL_ID
            arrayCabecera(34) = ConfigurationSettings.AppSettings("ConsSinInformacion")
            arrayCabecera(35) = "0"
            arrayCabecera(36) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(5, 4)  'Nro hdc
            arrayCabecera(37) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(0, 2)
            arrayCabecera(38) = ConfigurationSettings.AppSettings("ConsPais")
            arrayCabecera(39) = tipoDocCliente
            arrayCabecera(40) = nroDocCliente
            arrayCabecera(41) = ""
            arrayCabecera(42) = ""
            arrayCabecera(43) = ""
            If oPar.TipoOficina = ConfigurationSettings.AppSettings("constCodTipoDAC") Then
            arrayCabecera(44) = ConfigurationSettings.AppSettings("constCodTipoDAC")
            Else
                arrayCabecera(44) = ConfigurationSettings.AppSettings("constCodTipoCRN")
            End If
            arrayCabecera(45) = ""                                  'Tipo_Prod_Operad (01 Postpago; 02 Prepago)
            arrayCabecera(46) = CurrentUser
            arrayCabecera(47) = Now.ToString()
            arrayCabecera(48) = CurrentUser                             'Orgvnt
            arrayCabecera(49) = Now.ToString()                                'Canal
            arrayCabecera(50) = ""
            arrayCabecera(51) = "0"

            cadenaCabecera = Join(arrayCabecera, ";")
            'fin sinergia 31072015

        Catch ex As Exception
            cadenaCabecera = ""
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaCabecera: " & ex.Message)
        End Try

        Return cadenaCabecera
    End Function

    Private Function GenerarCadenaDetalle(ByRef montoTotal As Double) As String
        Dim cadenaDetalle As String = String.Empty
        Dim oConsulta As New VentaNegocios

        'Try
            Dim arrayDetalle(28) As String
            Dim arrayDetalle1(28) As String

            'CVM
            Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
            Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

            Dim oConsultaMSSAP As New ConsultaMsSapNegocio
            Dim oPar As BEParametroOficina
            oPar = oConsultaMSSAP.ParametrosOficina(Funciones.CheckStr(strCodOficina))

            Dim NroCuotas As String = hidCuota.Value

            'fin sinergia 03082015

            'Dim consecutivo As String = "000001"
            Dim cantidad As Integer = 1

            Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
            Dim codPlan As String = planTarifa.Split(","c)(1)
            Dim desPlan As String = planTarifa.Split(","c)(2)

            Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
            Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
            Dim desLisPrecio As String = listaPrecio.Split(","c)(1)

            Dim campania As String = CheckStr(hidCampaniaSelected.Value)
            Dim codCampania As String = campania.Split(","c)(0)
            Dim desCampania As String = campania.Split(","c)(1)

            Dim precios As String = CheckStr(hidDatosEquipo.Value)
            Dim descuento As String = precios.Split(","c)(0)
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)
            Dim precioLista As String = precios.Split(","c)(2)
            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
            montoTotal = CheckDbl(totalConIGV)

            'INICIO WHZR 15112014
            Dim descuentoICCID As String = String.Empty
            Dim totalSinIGVICCID As String = String.Empty
            Dim totalConIGVICCID As String = String.Empty
            Dim precioListaICCID As String = String.Empty
            Dim totalIGVICCID As String = String.Empty
            If hidValidarIccid.Value.Equals("1") Then
                Dim preciosICCID As String = CheckStr(hidDatosChip.Value)
                descuentoICCID = preciosICCID.Split(","c)(0)
                totalSinIGVICCID = preciosICCID.Split(","c)(3)
                totalConIGVICCID = preciosICCID.Split(","c)(1)
                precioListaICCID = preciosICCID.Split(","c)(2)
                totalIGVICCID = CheckStr(CheckDbl(totalConIGVICCID) - CheckDbl(totalSinIGVICCID))
            End If

            Dim strMaterialICCID As String = String.Empty
            Dim strArticuloICCID As String = String.Empty
            Dim strSerieChip As String = String.Empty
            Dim strMaterialImei As String = String.Empty
            Dim strArticuloImei As String = String.Empty
            Dim strImei As String = String.Empty
            Dim listaPrecioChip As String = String.Empty
            Dim codLisPrecioChip As String = String.Empty
            Dim desLisPrecioChip As String = String.Empty
        If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            If hidValidarIccid.Value.Equals("1") Then
                listaPrecioChip = CheckStr(hidPLSelected.Value)
                codLisPrecioChip = listaPrecioChip.Split(","c)(0)
                desLisPrecioChip = listaPrecioChip.Split(","c)(1)

                strMaterialICCID = CheckStr(txtCodChip.Text)
                strArticuloICCID = CheckStr(hidNombredelChipCAC.Value)
                strSerieChip = CheckStr(hidIccid.Value)
            End If
            strMaterialImei = CheckStr(txtCodEquipo.Text)
            strArticuloImei = CheckStr(hidNombredelEquipoCAC.Value)  'ddlCodEquipo.SelectedItem.Text
            strImei = CheckStr(hidIMEI.Value)

        Else
            If hidValidarIccid.Value.Equals("1") Then
                listaPrecioChip = CheckStr(hidPLSelected.Value)
                codLisPrecioChip = listaPrecioChip.Split(","c)(0)
                desLisPrecioChip = listaPrecioChip.Split(","c)(1)

                strMaterialICCID = CheckStr(txtMaterialICCID.Text)
                strArticuloICCID = CheckStr(txtArticuloICCID.Text)
                strSerieChip = CheckStr(hidIccid.Value)
            End If
            strMaterialImei = CheckStr(txtMaterialImei.Text)
            strArticuloImei = CheckStr(txtArticuloImei.Text)
            strImei = CheckStr(txtImei.Text)


        End If

        'consolidado 23122014

        'fin whzr 15112014
        Dim contadorDetalle As Integer = 1

        If hidValidarIccid.Value.Equals("1") Then

            'Cadena Detalle ICCID
            arrayDetalle(0) = ""                            'Documento
            arrayDetalle(1) = "" 'Format(contadorDetalle, "000000")              'Consecutivo (codigo 6 digitos)
            arrayDetalle(2) = oPar.CodigoInterlocutor  '"" 'CheckStr(strMaterialImei) 'CheckStr(txtMaterialImei.Text) 'Articulo
            arrayDetalle(3) = CheckStr(strSerieChip)  'CheckStr(strArticuloImei) 'CheckStr(txtArticuloImei.Text) 'Des_Articulo
            arrayDetalle(4) = CheckStr(strMaterialICCID)  'codLisPrecio                  'Utilizacion
            arrayDetalle(5) = CheckStr(strArticuloICCID)   'desLisPrecio                  'Des_Utilizacion
            arrayDetalle(6) = CheckStr(cantidad) 'codCampania
            arrayDetalle(7) = totalSinIGVICCID  'desCampania
            arrayDetalle(8) = CheckStr(hidNroLinea.Value) 'CheckStr(strImei) 'CheckStr(txtImei.Text)        'Serie
            arrayDetalle(9) = "0" 'CheckStr(cantidad)            'Cantidad
            arrayDetalle(10) = "0" 'precioLista                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
            arrayDetalle(11) = "0" 'totalSinIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
            arrayDetalle(12) = NroCuotas 'descuento                    'Descuento
            arrayDetalle(13) = codLisPrecioChip  '""                           'Porc_Descuento
            arrayDetalle(14) = desLisPrecioChip '""                           'Descuento_Adic
            arrayDetalle(15) = CurrentUser 'totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
            arrayDetalle(16) = DateTime.Now.ToString() 'totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
            arrayDetalle(17) = CurrentUser '""                           'Impuesto2
            arrayDetalle(18) = DateTime.Now.ToString() 'codPlan                      'Plan_Tarifario
            arrayDetalle(19) = "" 'desPlan                      'Des_Plan_Tarifar

            If cadenaDetalle.Length > 0 Then
                cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
            Else
                cadenaDetalle = Join(arrayDetalle, ";")
            End If
            montoTotal += totalConIGVICCID
        End If

        'Cadena Detalle IMEI
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = "" 'Format(contadorDetalle, "000000")              'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = oPar.CodigoInterlocutor  '"" 'CheckStr(strMaterialImei) 'CheckStr(txtMaterialImei.Text) 'Articulo
        arrayDetalle(3) = CheckStr(strImei)  'CheckStr(strArticuloImei) 'CheckStr(txtArticuloImei.Text) 'Des_Articulo
        arrayDetalle(4) = CheckStr(strMaterialImei)  'codLisPrecio                  'Utilizacion
        arrayDetalle(5) = CheckStr(strArticuloImei)   'desLisPrecio                  'Des_Utilizacion
        arrayDetalle(6) = CheckStr(cantidad) 'codCampania
        arrayDetalle(7) = totalSinIGV  'desCampania
        arrayDetalle(8) = CheckStr(hidNroLinea.Value) 'CheckStr(strImei) 'CheckStr(txtImei.Text)        'Serie
        arrayDetalle(9) = "0" 'CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = "0" 'precioLista                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = "0" 'totalSinIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = NroCuotas 'descuento                    'Descuento
        arrayDetalle(13) = codLisPrecio '""                           'Porc_Descuento
        arrayDetalle(14) = desLisPrecio '""                           'Descuento_Adic
        arrayDetalle(15) = CurrentUser 'totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = DateTime.Now.ToString() 'totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = CurrentUser '""                           'Impuesto2
        arrayDetalle(18) = DateTime.Now.ToString() 'codPlan                      'Plan_Tarifario
        arrayDetalle(19) = "" 'desPlan                      'Des_Plan_Tarifar
        'arrayDetalle(20) = ""                           'Centro_Costo
        'arrayDetalle(21) = ""                           'Motivo_Devolucio
        'arrayDetalle(22) = ""                           'Asociado
        'arrayDetalle(23) = ""                           'Consecutivo_Padr
        'arrayDetalle(24) = ""                           'Articulo_Asociac
        'arrayDetalle(25) = CheckStr(hidNroLinea.Value)  'Numero_Telefono
        'arrayDetalle(26) = ""                           'Nro_Clarify
        'arrayDetalle(27) = ""                           'Dev_Componente
        'arrayDetalle(28) = ""                           'Serie_Ant




        If cadenaDetalle.Length > 0 Then
            cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
        Else
            cadenaDetalle = Join(arrayDetalle, ";")
        End If

        ' Ordenar el array de Detalle segun el parametro "consecutivo"
        Dim sortCadena() As String = cadenaDetalle.Split("|"c)
        Dim unsortCadena() As String = cadenaDetalle.Split("|"c)
        'For Each cadenaTmp As String In unsortCadena
        '    Dim idx As Integer = CheckInt(cadenaTmp.Split(";"c)(1)) - 1
        '    sortCadena(idx) = cadenaTmp
        'Next
        'FIN - SINERGIA_MSSAP

        GenerarCadenaDetalle = Join(sortCadena, "|"c)


        'Catch ex As Exception
        '    cadenaDetalle = ""
        '    oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaDetalle: " & ex.Message)
        'Finally
        '    oConsulta = Nothing
        'End Try

        'Return cadenaDetalle
    End Function

    Private Function GenerarCadenaAcuerdo() As String
        Dim cadenaAcuerdo As String
        ConsultarPrefijo()

        Dim oficina As String = CheckStr(hidOficina.Value)
        Dim tipoCliente As String = hidTipoClienteSAP.Value    'ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")
        Dim plazoAcuerdo As String = hidPlazoAcuerdo.Value
        Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
        Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)
        If Not hidPerfil_149.Value = "S" Then
            codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
        End If

        Dim telfVendedor As String = "000000000000000"
        Dim prefijo As String = ConfigurationSettings.AppSettings("constRenovPostNroPrefijo") 'hidPrefijo.Value    
        Dim tipoDocCli As String = CheckStr(hidTipoDocumento.Value)
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim codPlan As String = planTarifa.Split(","c)(1)
        Dim analistaCred As String = ConfigurationSettings.AppSettings("ExpressAnalistaCredito")
        Dim codAprobador As String = CheckStr(ConfigurationSettings.AppSettings("constCodAprobadorSECRenov")).Split(";"c)(0)
        Dim scoreCred As String = hidScoreCred.Value

        Dim strNombreCliente As String = CheckStr(hidNombre.Value).ToUpper
        Dim strAPaternoCliente As String = CheckStr(hidApePaterno.Value).ToUpper
        Dim strAMaternoCliente As String = CheckStr(hidApeMaterno.Value).ToUpper
        Dim strRazonSocial As String = CheckStr(hidRazonSocial.Value).ToUpper
        Dim LimiteCred As String = Math.Round(CheckDbl(hidLimiteCred.Value), 2)
        Dim usuario As String = CurrentUser()

        Try

            If usuario <> "" Then
                usuario = usuario.Substring(1)
            End If

            ' ACUERDO (CONTRATO)
            Dim arrayContrato(67) As String
            arrayContrato(0) = ""
            arrayContrato(1) = oficina
            arrayContrato(2) = prefijo
            arrayContrato(3) = Now.ToString("dd/MM/yyyy")
            arrayContrato(4) = plazoAcuerdo
            arrayContrato(5) = strNombreCliente
            arrayContrato(6) = strAPaternoCliente
            arrayContrato(7) = strAMaternoCliente
            arrayContrato(8) = ""
            arrayContrato(9) = hidNroSEC.Value
            arrayContrato(10) = CheckStr(ConfigurationSettings.AppSettings("constRenovResultado")).Split(";"c)(1)
            arrayContrato(11) = ""
            arrayContrato(12) = ""
            arrayContrato(13) = ""
            arrayContrato(14) = ""
            arrayContrato(15) = ""
            arrayContrato(16) = ""
            arrayContrato(17) = ""
            arrayContrato(18) = ""
            arrayContrato(19) = ""
            arrayContrato(20) = codigoVendedorSAP     '"0000070440" 
            arrayContrato(21) = telfVendedor
            arrayContrato(22) = ""
            arrayContrato(23) = ""
            arrayContrato(24) = "N"
            arrayContrato(25) = CheckStr(ConfigurationSettings.AppSettings("constRenovAnalista")).Split(";"c)(0) 'analistaCred
            arrayContrato(26) = ""
            arrayContrato(27) = CheckStr(ConfigurationSettings.AppSettings("constEstadoAcuerdoReservado"))
            arrayContrato(28) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayContrato(29) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayContrato(30) = ""
            arrayContrato(31) = "S"
            arrayContrato(32) = Val(tipoDocCli).ToString
            arrayContrato(33) = hidNroDocumento.Value
            arrayContrato(34) = hidNroLinea.Value
            arrayContrato(35) = codPlan
            arrayContrato(36) = "S"
            arrayContrato(37) = ""
            arrayContrato(38) = CheckStr(Session("CodVendedorSAP"))
            arrayContrato(39) = CheckStr(Session("CodVendedorSAP"))
            arrayContrato(40) = ""
            arrayContrato(41) = ""
            arrayContrato(42) = codAprobador
            arrayContrato(43) = LimiteCred
            arrayContrato(44) = ""
            arrayContrato(45) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(0)
            arrayContrato(46) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(1)
            'arrayContrato(45) = scoreCred.Split("_"c)(0)             'Score_Crediticio = arrAcuerdo [45]; A b c d s
            'arrayContrato(46) = scoreCred.Split("_"c)(1)             'Control_Fraude = arrAcuerdo [46]; "monto columan en tabla sec"
            arrayContrato(47) = hidNroSEC.Value
            arrayContrato(48) = ""
            arrayContrato(49) = ""
            arrayContrato(50) = codPlan
            arrayContrato(51) = ""
            arrayContrato(52) = ""
            arrayContrato(53) = ""
            arrayContrato(54) = ""
            arrayContrato(55) = ""
            arrayContrato(56) = ""
            arrayContrato(57) = ""
            arrayContrato(58) = ""
            arrayContrato(59) = ""
            arrayContrato(60) = ""
            arrayContrato(61) = "X"
            arrayContrato(62) = "" 'tipoCliente
            arrayContrato(63) = ""
            arrayContrato(64) = ""
            arrayContrato(65) = ""
            arrayContrato(66) = ""

            cadenaAcuerdo = Join(arrayContrato, ";")


        Catch ex As Exception
            cadenaAcuerdo = ""
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaAcuerdo: " & ex.Message)
        End Try

        Return cadenaAcuerdo
    End Function

    Private Sub ConsultarPrefijo()
        Dim oficina As String = hidOficina.Value
        Dim tipoDocPrefijo As String = hidTipoDocVenta.Value
        If oficina = "" Or tipoDocPrefijo = "" Then
            Exit Sub
        End If

        Dim oConsultarSap As New SapGeneralNegocios
        Try
            'Obtener el Prefijo de los Documentos de Venta
            Dim prefijo As String = oConsultarSap.ConsultarPrefijo(Now.ToString("yyyy/MM/dd"), oficina, tipoDocPrefijo)
            hidPrefijo.Value = prefijo
        Catch ex As Exception
            If hidMsg.Value <> "" Then
                hidMsg.Value = hidMsg.Value & Chr(13) & "Error. " & ex.Message
            Else
                hidMsg.Value = "Error. " & ex.Message
            End If
            hidResponse.Value = "Error"
        End Try
    End Sub

    Private Function ActualizarVentaRenovacion(ByVal nroFactura As String, ByVal nroContrato As String, ByVal nroPedido As String) As Boolean
        Dim blnOK As Boolean = False
        Dim renof_Flaggener As String = "1"
        Dim oVentaRenovacionPos As New VentaRenovaPost

        Try
            If Not nroFactura.Equals(String.Empty) And Not nroPedido.Equals(String.Empty) Then
                oVentaRenovacionPos.numero_factura = nroFactura
                oVentaRenovacionPos.numero_contrato = nroContrato 'String.Empty
                oVentaRenovacionPos.numero_pedido = nroPedido
                oVentaRenovacionPos.renof_Flaggener = "1"
                oVentaRenovacionPos.numero_sec = hidNroSEC.Value
                Dim oAction As Int64 = 1
                blnOK = GrabarVentaRenovacion(oVentaRenovacionPos, oAction)
            End If
            If Not blnOK Then
                'RollBackVenta(nroFactura)
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Exception GrabarVentaRenovacion - Mensaje: " & ex.Message)
            'RollBackVenta(nroFactura)

            Throw New Exception(" Error al Generar Detalle RenovSap. " & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GrabarVentaRenovacion()")
        End Try

        Return blnOK
    End Function

    Private Sub RollBackVenta(ByVal nroFactura As String)
        Dim bProceso As Boolean
        Try
            Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
            Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
            'Eliminar PEDIDO MSSAP
            bProceso = New ConsultaMsSapNegocio().EliminarPedidoMSSASP(nroFactura, strCodCanal)
        Catch ex As Exception
            bProceso = False
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Exception  --> " & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> " & bProceso)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Rollback Pedido MSSAP")
        End Try

    End Sub

    Private Sub Auditoria(ByVal desTrans As String, ByVal strCodTrans As String)
        Try
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim ipcliente As String = CurrentTerminal
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim usuario_id As String = CurrentUser
            Dim telefono As String = hidNroLinea.Value

            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)


            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Inicio registrarAuditoria()")
            Dim auditoriaGrabado As Boolean = (New AuditoriaNegocio).registrarAuditoria(strCodTrans, _
                                                                                        strCodServ, _
                                                                                        ipcliente, _
                                                                                        nombreHost, _
                                                                                        ipServer, _
                                                                                        nombreServer, _
                                                                                        usuario_id, _
                                                                                        telefono, "0", _
                                                                                        desTrans)

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Exception registrarAuditoria() - Mensaje: " & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Fin registrarAuditoria()")
        End Try
    End Sub

    Private Function AnularVentaRenovacion(ByVal Factura As String, ByVal SolinCodigo As String)
        Try
            Dim oSolicitud As New SolicitudNegocios
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Inicio AnularVentaRenovacion()")

            Dim oVentaRenovacion As New VentaRenovaPost
            oVentaRenovacion.numero_sec = SolinCodigo
            oVentaRenovacion.numero_factura = Factura
            Dim oAction As Int64 = 3
            oSolicitud.GrabarVentaRenovacion(oVentaRenovacion, oAction)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No se puede anular el Pedido SAP en SISACT para las SEC: " & SolinCodigo)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Error:" & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Fin AnularVentaRenovacion()")
        End Try

    End Function

    ' Devuelve el còdigo equivalente al tipo de documento entre SISACT y PUNTOSCC
    Public Function getCCLUB(ByVal TipoDocumento As String) As String
        Dim ID_CCLUB As String
        Dim TipoDocumentos() As String = hidTipoDocumentos.Value.Split("|"c)
        Dim hstTipoDocumentos As New Hashtable

        For Each item As String In TipoDocumentos
            Dim vItem() As String = item.Split("="c)
            hstTipoDocumentos.Add(vItem(0), vItem(1))
        Next item
        ID_CCLUB = hstTipoDocumentos.Item(TipoDocumento)

        Return ID_CCLUB
    End Function

    ' Bloquea los puntos para que no puedan ser utilizados en simultáneo y generar problemas de consistencia.
    Public Sub bloquearPuntos()
        Dim idLog As String

        Try
            idLog = hidNroSEC.Value
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio reservarPuntos()")
            Dim UsuarioProceso As String = CurrentUser ' Usuario Proceso

            Dim ID_CCLUB As String
            Dim TipoDocumento As String
            Dim NroDocumento As String
            Dim tipoClie As String
            TipoDocumento = hidTipoDocumento.Value
            NroDocumento = hidNroDocumento.Value
            tipoClie = ConfigurationSettings.AppSettings("consTipoclie")
            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            ID_CCLUB = getCCLUB(TipoDocumento)
            Dim txId As String = String.Empty
            Dim errorCode As String = String.Empty
            Dim errorMsg As String = String.Empty

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio bloquearPuntos()")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp ID_CCLUB: " & ID_CCLUB)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp NroDocumento: " & NroDocumento)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp tipoClie: " & tipoClie)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inp UsuarioProceso: " & UsuarioProceso)

            objPuntosClaroClubNegocio.bloquearPuntos(ID_CCLUB, _
                                                     NroDocumento, _
                                                     tipoClie, _
                                                     UsuarioProceso, _
                                                     txId, _
                                                     errorCode, _
                                                     errorMsg)

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out txId:" & txId)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out errorCode:" & errorCode)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out errorMsg:" & errorMsg)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin bloquearPuntos()")

            If errorCode <> "0" Then
                Throw New Exception(errorMsg)
            End If

            Dim codTrs As String = ConfigurationSettings.AppSettings("codReservarPuntos")
            Dim descTrs As New StringBuilder("Reservar Puntos Claro Club. NroSec: ")
            descTrs.Append(hidNroSEC.Value)
            descTrs.AppendFormat(" ClaroClubPuntosUtilizar: {0}", txtClaroClubPuntosUtilizar.Text)
            descTrs.AppendFormat(" ClaroClubSolesDeDescuento: {0}", txtDescuentoClaroClub.Text)

            Auditoria(codTrs, descTrs.ToString())
        Finally
            oLog.Log_WriteLog(strArchivo, String.Format("{0} - Fin reservarPuntos()", idLog))
        End Try
    End Sub

    ' Registra en el SISACT la operaciòn de canje de puntos Claro Club.
    Public Sub RegistrarCanjePuntos(ByVal facturaPedido As String, ByVal nroContrato As String, ByVal nroPedido As String, ByRef resultado As Boolean) 'PROY-26366? NUEVA VARIABLE (resultado)

        resultado = False 'PROY-26366?
        Dim idLog As String = hidNroSEC.Value
        Dim oPuntosClaroClub As New PuntosClaroClubNegocio
        Dim objCanjePuntos As New CanjePuntos
        objCanjePuntos.TIPO_DOC = Right("00" & hidTipoDocumento.Value, 2)
        objCanjePuntos.NUM_DOC = hidNroDocumento.Value
        objCanjePuntos.PUNTOS_USADOS = Funciones.CheckDbl(txtClaroClubPuntosUtilizar.Text)
        objCanjePuntos.FACTOR_CONVERSION = Funciones.CheckDbl(hidFactorClaroClub.Value)
        objCanjePuntos.SOLES_DESCUENTO = Funciones.CheckDbl(txtDescuentoClaroClub.Text)
        objCanjePuntos.COD_PDV = hidOficina.Value
        objCanjePuntos.USUARIO_REG = CurrentUser
        objCanjePuntos.NRO_LINEA = Funciones.CheckDbl(txtNroLinea.Text)
        objCanjePuntos.DOCUMENTO_SAP = facturaPedido
        objCanjePuntos.FLAG_CANJE = "0"

        If hidIDCAMPANA.Value <> "" Then
            objCanjePuntos.IDCAMPANA = Funciones.CheckDbl(hidIDCAMPANA.Value)
        End If
        If hidTipoDocumento.Value <> "" Then
            objCanjePuntos.ID_CCLUB = Funciones.CheckDbl(getCCLUB(hidTipoDocumento.Value))
        End If
        objCanjePuntos.DESCRIPCION = ConfigurationSettings.AppSettings("constConstanciaDescripcionCC")


        ' código del asesor
        objCanjePuntos.USUARIO_REG = CurrentUser
        ' Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
        If hidFechaIniCC.Value <> "" Then
            objCanjePuntos.CAMPANA_VIGENCIA_INI = hidFechaIniCC.Value
        End If
        If hidFechaFinCC.Value <> "" Then
            objCanjePuntos.CAMPANA_VIGENCIA_FIN = hidFechaFinCC.Value
        End If
        objCanjePuntos.SEGMENTO = hidSegmento.Value
        objCanjePuntos.NRO_DOC_SAP_NC = nroPedido
        'objCanjePuntos.DOCUMENTO_SAP = nroContrato

        If nroPedido.Trim.Length > 0 Then
            'objCanjePuntos.DOC_SAP_DSCTO_EQUIPO = nroPedido
            objCanjePuntos.DSCTO_EQUIPO = Funciones.CheckDecimal(txtDescuentoClaroClub.Text)
        End If

        ' Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos

        Try
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio RegistrarCanjePuntos()")
            oPuntosClaroClub.InsertarCanjePuntos2(objCanjePuntos)
            resultado = True 'PROY 26366?
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR RegistrarCanjePuntos(): " & ex.Message.ToString())
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR RegistrarCanjePuntos(): " & ex.StackTrace.ToString())
        End Try

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin RegistrarCanjePuntos(): ")
    End Sub

    Public Sub EliminarCanjePuntos(ByVal facturaPedido As String)
        Dim idLog As String = hidNroSEC.Value
        Dim oPuntosClaroClub As New PuntosClaroClubNegocio
        Dim objCanjePuntos As New CanjePuntos
        objCanjePuntos.DOCUMENTO_SAP = facturaPedido

        Try
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio EliminarCanjePuntos()")
            oPuntosClaroClub.EliminarCanjePuntos(objCanjePuntos)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR EliminarCanjePuntos(): " & ex.Message.ToString())
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR EliminarCanjePuntos(): " & ex.StackTrace.ToString())
        End Try

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin EliminarCanjePuntos(): ")
    End Sub

    ' Efectua el desbloqueo de puntos Claro Club con un llamado a webservices.
    Public Sub liberarPuntos(ByVal strNroSec As String)
        Dim idLog As String = strNroSec

        Try
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio liberarPuntos()")
            Dim ID_CCLUB As String
            Dim TipoDocumento As String
            Dim NroDocumento As String
            Dim tipoClie As String
            TipoDocumento = hidTipoDocumento.Value
            NroDocumento = hidNroDocumento.Value
            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            ID_CCLUB = getCCLUB(TipoDocumento)
            Dim txId As String = String.Empty
            Dim errorCode As String = String.Empty
            Dim errorMsg As String = String.Empty

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio liberarPuntos()")
            tipoClie = ConfigurationSettings.AppSettings("consTipoclie")

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "inp ID_CCLUB: " & ID_CCLUB)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "inp NroDocumento: " & NroDocumento)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "inp tipoClie: " & tipoClie)

            objPuntosClaroClubNegocio.liberarPuntos(ID_CCLUB, _
                                                    NroDocumento, _
                                                    tipoClie, _
                                                    txId, _
                                                    errorCode, _
                                                    errorMsg)

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out txId:" & txId)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out errorCode:" & errorCode)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out errorMsg:" & errorMsg)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin liberarPuntos()")

            If errorCode <> "0" Then
                Throw New Exception(errorMsg)
            End If

            ' Implementar la auditoría de liberación de puntos.
            Dim codTrs As String = ConfigurationSettings.AppSettings("codLiberarPuntos")
            Dim descTrs As String = "Liberar Puntos Claro Club. NroSec:" & strNroSec
            Auditoria(codTrs, descTrs)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR liberarPuntos(): " & ex.Message.ToString())
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR liberarPuntos(): " & ex.StackTrace.ToString())
        End Try

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin liberarPuntos(): ")
    End Sub

    Private Function GenerarCadenaServicios() As String
        Dim cadenaServicios As String = ""
        Dim valorSeleccionado As String = "S"
        Dim consecutivo As String
        Dim arrayServAdic(3) As String
        Dim arrayServicios() As String = ObtenerServicios().Split(";"c)
        Dim cont As Integer = 0
        For Each codServicio As String In arrayServicios
            consecutivo = cont + 1
            arrayServAdic(0) = ""                                               'Documento
            arrayServAdic(1) = consecutivo.PadLeft(6, CChar("0"))               'Consecutivo
            arrayServAdic(2) = codServicio                                      'Servicio_Solicit (codigo del servicio 4 digitos)
            arrayServAdic(3) = valorSeleccionado                                'Valor_Selecciona

            If cadenaServicios.Length > 0 Then
                cadenaServicios = cadenaServicios & "|" & Join(arrayServAdic, ";")
            Else
                cadenaServicios = Join(arrayServAdic, ";")
            End If
        Next
        GenerarCadenaServicios = cadenaServicios
    End Function

    Private Function ObtenerServicios() As String
        Dim cadenServicio As String = String.Empty
        Dim arrPlanServDetalle As ArrayList = ObtenerPlanDetalle()
        Dim arrayServicio As New ArrayList
        For Each plan As PlanDetalleVenta In arrPlanServDetalle
            If Not IsNothing(plan.SERVICIO) Then
                For Each Servicio As SecServicio_AP In plan.SERVICIO
                    If Trim(Servicio.SERVV_CODIGO) <> String.Empty Then
                        If Trim(cadenServicio) <> String.Empty Then
                            cadenServicio = cadenServicio & ";" & Servicio.SERVV_CODIGO
                        Else
                            cadenServicio = Servicio.SERVV_CODIGO
                        End If
                    End If
                Next
            End If
        Next
        Return cadenServicio
    End Function

    Private Sub InicioPedido()
        Dim listaSec As New ArrayList
        Dim oConsultaSolicitud As New SolicitudNegocios
        Dim nroSec As String = String.Empty
        nroSec = hidNroSEC.Value
        Dim idLog As String = nroSec

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio ObtenerSolicitudes")
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "inp nroSec:" & nroSec)
        listaSec = oConsultaSolicitud.ObtenerSolicitudes(nroSec) 'Consulta lista SEC por sec padre
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "out listaSec:" & listaSec.Count.ToString())
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin ObtenerSolicitudes")

        Try
            For Each item As SolicitudPersona In listaSec
                'Obtener SEC padre
                If item.SOLIN_CODIGO = item.SOLIN_GRUPO_SEC Then
                    oSolicitud = CType(item, SolicitudPersona)
                End If
            Next
            'Obtiene Puntaje Credito
            hidScoreCred.Value = oSolicitud.SOLIC_SCO_TXT_CON & "_" & oSolicitud.SOLIN_SCO_NUM_CON

            'consolidado 21012015
            hidImporteRenta.Value = oSolicitud.SOLIN_IMP_DG_MAN
            'consolidado 21012015

            Dim tipoCliente As String = oSolicitud.TPROC_CODIGO
            hidTipoCliente.Value = tipoCliente
            ' Convertir el tipoCliente de PVU a su equivalente de SAP
            If tipoCliente = "01" Then 'Sisact: 01 = Consumer - SAP: 02 = Consumer
                tipoCliente = "02"
            ElseIf tipoCliente = "02" Then 'Sisact: 02 = Bussiness - SAP: 01 = Bussiness
                tipoCliente = "01"
            ElseIf tipoCliente = "06" Then 'Sisact: 06 = B2E - SAP: 05 = B2E
                tipoCliente = "05"
            End If
            hidTipoClienteSAP.Value = tipoCliente

            Dim tipoVenta As String = oSolicitud.TVENC_CODIGO
            hidTipoVenta.Value = tipoVenta
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Error: " & ex.Message.ToString())
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Error: " & ex.StackTrace.ToString())
            hidMsg.Value = "Error. " & ex.Message
        End Try

    End Sub

    Private Sub GenerarPedido(ByVal idVenta As Int64, ByVal nroContratoSisact As Int64)
        Dim oVentaExpress As New VentaExpressNegocios
        Dim strScript As String = ""
        Dim cadenaCabecera As String
        Dim cadenaDetalle As String
        Dim cadenaAcuerdo As String
        Dim cadenaServicios As String
        Dim oConsultaSap As New SapGeneralNegocios
        strIdentifyLog = hidNroLinea.Value()
        Dim nroSec As String = String.Empty
        nroSec = hidNroSEC.Value()
        Dim nroDocumentoCli As String = String.Empty
        nroDocumentoCli = hidNroDocumento.Value
        Dim entrega, factura, nroContratoSAP, nroPedido, refHistorico, tipDocCliente As String 'SD_644347 - CUOTAS
        Dim valorDescuento As Decimal
        Dim montoTotal As Double
        Dim NroCuotas As String = hidCuota.Value

        'CVM
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        Dim rspRB As String

		'INICIO IMP SD_818878
        Dim e_CanjePuntos As String = ""
		' FIN IMP SD_818878		

        Dim e_RecalculoDescuento As String = "" 'INC000000830856

        Dim resultado As Boolean = False 'PROY 26366?

        Try
            InicioPedido()

            'Generar Parametros Pedido
            cadenaCabecera = GenerarCadenaCabecera()
            cadenaDetalle = GenerarCadenaDetalle(montoTotal)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Generar Pedido")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> Cabecera : " & cadenaCabecera)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> Detalle  : " & cadenaDetalle)

            Dim oRegPed As New ConsultaMsSapNegocio
            Dim idPedidoMsSap As Int64 = 0
            Dim strCodRspt As String = String.Empty
            Dim strMensRspt As String = String.Empty
            Dim pedidoGenerado As Boolean


            Try
                oRegPed.RegistrarPedido(cadenaCabecera, cadenaDetalle, idPedidoMsSap, strCodRspt, strMensRspt)


            If (idPedidoMsSap > 0) Then
                nroPedido = CheckStr(idPedidoMsSap)
                factura = CheckStr(idPedidoMsSap)
                pedidoGenerado = True
                'ACTUALIZAR MONTO DE PEDIDO
                oRegPed.actualizaPedido(nroPedido)
            Else
                pedidoGenerado = False
            End If
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> pedidoGenerado: " & pedidoGenerado)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> nroContratoSisact: " & Funciones.CheckStr(nroContratoSisact))

            Catch ex3 As Exception
                factura = CheckStr(idPedidoMsSap)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Error al grabar el detalle  : " & factura)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> idPedidoMsSap: " & idPedidoMsSap)
                Throw New Exception("No se pudo Generar el Pedido.")
            End Try





            'consolidado 16012015
            Try
                oVentaExpress.ActualizarContratoSolicitud(CheckInt64(hidNroSEC.Value), Funciones.CheckStr(nroContratoSisact))
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "Fin ActualizarContratoSolicitud")
            Catch ex2 As Exception
                Dim Mensaje As String = ex2.Message.ToString
                Mensaje = QuitarSaltosLinea(Mensaje, " ")
                Mensaje = Mensaje.Replace(Environment.NewLine, " ")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "Error ActualizarContratoSolicitud")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & Mensaje)
            End Try
            'consolidado 16012015

            If pedidoGenerado = False Then
                Throw New Exception("No se pudo Generar el Pedido en Modulo MSSAP.")
            Else
                
                Dim dsAcuerdo As DataSet = New ConsultaMsSapNegocio().ConsultaAcuerdo(nroContratoSisact, "")
                montoTotal = CheckDbl(dsAcuerdo.Tables(1).Rows(0)("PRECIO_VENTA"))

                'Actualiza el Nro de Contrato en la Tabla de SEC
                Dim blnBloqueo As Boolean = False

                Dim ActualizoSEC As Boolean = oVentaExpress.Set_Actualiza_Contrato_Solicitud(CheckInt64(nroSec), Funciones.CheckStr(nroContratoSisact))
                If ActualizoSEC Then
                    'Actualiza Factura, Contrato, NroPedido en SISACT_VENTA_RENOVACION
                    Dim resActualizacion As Boolean = ActualizarVentaRenovacion(factura, Funciones.CheckStr(nroContratoSisact), nroPedido)
                    If resActualizacion Then
                        hidNroPedido.Value = nroPedido
                        hidnroContrato.Value = nroContratoSAP
                        'gaa20160607
                        Dim datosLinea As ClienteBSCS = Session("Cliente")
                        Dim strB2E As String = ConfigurationSettings.AppSettings("strPostTipClienteB2E")
                        'If (strCodCanal <> ConfigurationSettings.AppSettings("CacCorner")) Then
                        If (strCodCanal <> ConfigurationSettings.AppSettings("CacCorner")) AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
                            If (hidBAM.Value <> ConfigurationSettings.AppSettings("constTipoProductoBAM")) Then
                                If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 Then
                                    Try
                                        'INC000000830856
                                        Dim consecutivo As String = "1"

                                        If hidValidarIccid.Value.Equals("1") Then
                                            consecutivo = "2"
                                        End If
                                        'INC000000830856

                                        'Reserva Puntos
                                        bloquearPuntos()

                                        blnBloqueo = True

                                        'Registra Canje de Puntos
                                        'PROY 26366? INICIO
                                        RegistrarCanjePuntos(factura, Funciones.CheckStr(nroContratoSisact), nroPedido, resultado) 

                                        Dim descuentototalsoles As Decimal = Funciones.CheckDecimal(txtDescuentoClaroClub.Text)
                                        Dim descuentototalCP As Decimal = Funciones.CheckDecimal(txtClaroClubPuntosUtilizar.Text)
                                        Dim cantidadequipoventa As Decimal = 1 'Renovacion solo un Equipo.

                                        If (resultado = True) Then

                                            Dim objParametro As New MaestroNegocio
                                            Dim listaClaroPuntos As New ArrayList
                                            Dim factor_parametro As New StringBuilder
                                            Dim idCanjePuntos As New StringBuilder

                                            Dim codigo_rpta As String = String.Empty
                                            Dim mensaje_rpta As String = String.Empty
                                            Dim strImei As String = String.Empty
                                            Dim parametroFactor As String = String.Empty

                                            If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                                                strImei = CheckStr(hidIMEI.Value)
                                            Else
                                                strImei = CheckStr(txtImei.Text)
                                            End If

                                            Dim consfactorDescuentoClaroPuntos As Int64 = Funciones.CheckInt64(ConfigurationSettings.AppSettings("consfactorDescuentoClaroPuntos"))
                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Key para Factor de Descuento : ", consfactorDescuentoClaroPuntos))

                                            Dim obeParametro As ArrayList = objParametro.ListaParametrosGrupo(consfactorDescuentoClaroPuntos)

                                            For Each item As Parametro In obeParametro
                                                If item.Valor1 = "1" Then
                                                    factor_parametro.AppendFormat("{0}", item.Valor)
                                                End If
                                            Next
                                            parametroFactor = factor_parametro.ToString()

                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "% del Factor de Descuento : ", parametroFactor))

                                            Dim factor_desc As Decimal = Funciones.CheckDecimal(parametroFactor) / 100
                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Factor de Descuento en Porcentaje : ", factor_desc))

                                            Dim montoDescuentoDivididoClaroPuntos As Decimal = Math.Round(((descuentototalsoles / cantidadequipoventa) * factor_desc), 2)
                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Monto soles usados por Equipo : ", montoDescuentoDivididoClaroPuntos))

                                            Dim cantidadCPxEquipo As Int64 = Funciones.CheckInt64(Math.Floor((descuentototalCP / cantidadequipoventa) * factor_desc))
                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Claro Puntos usados por Equipo : ", cantidadCPxEquipo))

                                            listaClaroPuntos = PuntosClaroClubNegocio.ListarDatosNCxDocSAP(factura)

                                            For Each item As Parametro In listaClaroPuntos
                                                idCanjePuntos.AppendFormat("{0}", item.Codigo)
                                            Next

                                            Dim ID_CANJE_PUNTOS As Int64 = Funciones.CheckInt64(idCanjePuntos.ToString())
                                            oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1} : {2}", factura, "ID de la Tabla SISACT_CANJE_PUNTOS", ID_CANJE_PUNTOS))

                                            Dim insertDet As Boolean = PuntosClaroClubNegocio.InsertarDetaClaroPuntos(ID_CANJE_PUNTOS, strImei, cantidadCPxEquipo, montoDescuentoDivididoClaroPuntos, codigo_rpta, mensaje_rpta)

                                            If insertDet Then

                                                oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1} - {2} - {3} - {4} - {5} - {6}", factura, "Se Registro detalle de Claro Puntos de la serie", strImei, "con descuento en Claro Puntos de", cantidadCPxEquipo, "y descuento en Soles de", montoDescuentoDivididoClaroPuntos))

                                            Else

                                                oLog.Log_WriteLog(strArchivo, "Error al insertar el detalle de Claro Puntos por equipo")
                                                oLog.Log_WriteLog(strArchivo, "**************************************************")
                                                oLog.Log_WriteLog(strArchivo, "Fin registro Detalle de Claro Puntos por equipo")
                                                oLog.Log_WriteLog(strArchivo, "**************************************************")


                                                oLog.Log_WriteLog(strArchivo, "**************************************************")
                                                oLog.Log_WriteLog(strArchivo, "Fin registro Detalle de Claro Puntos por equipo")
                                                oLog.Log_WriteLog(strArchivo, "**************************************************")

                                            End If

                                        Else

                                            oLog.Log_WriteLog(strArchivo, "No se registro el detalle de Claro puntos por equipo")
                                            oLog.Log_WriteLog(strArchivo, "**************************************************")
                                            oLog.Log_WriteLog(strArchivo, "Fin registro Detalle de Claro Puntos por equipo")
                                            oLog.Log_WriteLog(strArchivo, "**************************************************")


                                        End If
                                        'PROY 26366? FIN

                                        'INC000000830856
                                        If ConfigurationSettings.AppSettings("FlgDescuentoClaroClub") = 1 Then
                                            Dim nroLog1, desLog1, nroLogEsquemaCP, nroLogDesEsquemaCP As String
                                            oRegPed.ActualizarDescuentoPedido(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), ConfigurationSettings.AppSettings("constSINERGIAClaseCondicion53"), descuentototalsoles, nroLog1, desLog1) 'PROY-26366
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Claro Puntos actualizado ==> " & nroLog1)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Claro Puntos actualizado ==> " & desLog1)
                                            oRegPed.RecalculaEsquema(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), nroLogEsquemaCP, nroLogDesEsquemaCP)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogEsquemaCP)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogDesEsquemaCP)
                                        End If
                                        'INC000000830856

                                    Catch ex As Exception

										' INICIO IMP SD_818878
                                        e_CanjePuntos = "Error Claro Puntos" & ex.Message

                                        If blnBloqueo Then
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception ClaroPuntos() - Mensaje: " & ex.Message)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Liberar ClaroPuntos() ")
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "factura " & factura)

                                            'Liberar Claro puntos
                                        liberarPuntos(factura)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Liberar ClaroPuntos() ")

                                        'Elimina Registro de Canje de Puntos
                                        EliminarCanjePuntos(factura)
                                        End If

                                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception Claro Puntos - Mensaje: " & ex.Message)

                                        'Throw New Exception(strMensajeError)
										' FIN IMP SD_818878

                                    End Try
                                End If


                                'INC000000830856
                                If ConfigurationSettings.AppSettings("FlgDescuentoClaroClub") = 1 Then
                                    If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 Then
                                        'RecalculaDescuento
                                        Try
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Recalcular Descuento")
                                            Dim pnrologDescuento, pdeslogDescuento As String
                                            oRegPed.RecalculaDescuento(Convert.ToInt32(idPedidoMsSap), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), pnrologDescuento, pdeslogDescuento)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Recalcula Descuento ==> " & pnrologDescuento)
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Recalcula Descuento ==> " & pdeslogDescuento)
                                        Catch ex As Exception

                                            e_RecalculoDescuento = "Error al generar el recalculo del Descuento. " & ex.Message
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception Recalcular Descuento - Mensaje: " & ex.Message)
                                        Finally
                                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Recalcular Descuento")
                                        End Try
                                    End If

                                    If (idPedidoMsSap > 0) Then
                                        oRegPed.actualizaPedido(nroPedido)
                                    End If
                                End If
                                'INC000000830856

                            End If
                        End If
                        'Registra Auditoria de Grabar Pedido
                        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
                        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacion")
                        Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_GRABAR_RENOV_POST")
                        Dim desAuditoria As String = "Grabando Pedido. OK" & _
                                        "( Punto de venta:" & CheckStr(strCodOficina) & _
                                        " | Vendedor: " & CheckStr(CheckStr(Session("CodVendedorSAP"))) & _
                                        " | Nro de Telefono: " & CheckStr(hidNroLinea.Value) & _
                                        " | Tipo de Documento: " & CheckStr(hidTipoDocumento.Value) & _
                                        " | Numero de Identidad: " & CheckStr(hidNroDocumento.Value) & _
                                        " | Numero IMEI: " & CheckStr(txtImei.Text) & _
                                        " | Código de Material: " & CheckStr(txtMaterialImei.Text) & _
                                        " | Tipo de Venta: " & tipoVenta & _
                                        " | Tipo de Operacion: " & tipoOperacion & ")"

                        Auditoria(desAuditoria, strCodTrans)
						' INICIO IMP SD_818878
						'hidMsg.Value = "El Pedido Nro: " & nroPedido & " para la Solicitud Nro: " & hidNroSEC.Value & " ha sido generado satisfactoriamente."
                        hidMsg.Value = "El Pedido Nro: " & nroPedido & " para la Solicitud Nro: " & hidNroSEC.Value & " ha sido generado satisfactoriamente." & e_CanjePuntos & e_RecalculoDescuento
						' FIN IMP SD_818878

                    Else
                        Throw New Exception("No se pudo crear pedido en SISACT.")
                    End If
                Else
                    Throw New Exception("No se pudo actualizar el Nro de Contrato en la SEC: " & nroSec)
                End If
                If NroCuotas <> "00" Then 'SD_644347 - CUOTAS - INICIO
                    GrabarCuotas(Funciones.CheckStr(nroContratoSisact), factura, hidNroLinea.Value, nroPedido)
                End If 'SD_644347 - CUOTAS - FIN
            End If


            'INC000001019296-INICIO
            ActualizaInfoVentaSAP(montoTotal, factura, idVenta, nroContratoSisact, "Insertar")
            'INC000001019296-FIN

            'INICIO - WHZR

            If strCodCanal = ConfigurationSettings.AppSettings("CacCorner") Then
                If Not RegistrarPreventaSICAD(nroPedido) Then
                    Throw New Exception("Error al registrar la preventa en SISCAD")
                End If
            End If

            'FIN - WHZR

            ' Generar Renta o Depósito
            Dim dblMontoDeposito As Double
            Dim sTipoDeposito As String
            Dim sTipoGarantia As String
            Dim cadenaDeposito As String = ""
            Dim cadenaCabeceraDeposito As String = ""
            Dim nroDeposito As String
            Dim idPedidoRentaAdelantada As Int64 = 0
            Dim pedidoGeneradoRenta As Boolean
            cadenaDeposito = GenerarCadenaDeposito(cadenaCabecera, Funciones.CheckStr(nroContratoSisact), nroPedido, nroSec, dblMontoDeposito, sTipoDeposito, sTipoGarantia)

            Dim nroDRAMssap As Integer = 0
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "cadenaDeposito: " & cadenaDeposito)

            If cadenaDeposito <> "" And cadenaDetalle <> "" Then
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Grabar Renta Adelantada")
                Dim arrCadenaDRA As String

                arrCadenaDRA = String.Format("{0}|{1}|{2}|{3}|{4}", dblMontoDeposito, Funciones.CheckStr(nroContratoSisact), idVenta, "1", sTipoDeposito)
                nroDRAMssap = GenerarRentaAdelantadaMSSAP(nroPedido, cadenaCabecera, cadenaDetalle, arrCadenaDRA, cadenaDeposito, strIdentifyLog)

                If (nroDRAMssap > 0) Then
                    pedidoGeneradoRenta = True
                    'actualizar monto de renta adelantada
                    oRegPed.actualizaPedido(nroDRAMssap)
                Else
                    pedidoGeneradoRenta = False
                End If

                nroDeposito = Funciones.CheckStr(nroDRAMssap)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "out nroDeposito: " & nroDRAMssap)

                'INC000001019296-INICIO
                ActualizaInfoVentaSAP(montoTotal, factura, idVenta, nroContratoSisact, "Actualizar")

                If pedidoGeneradoRenta = False Then
                    Throw New Exception("No se pudo Crear el Deposito de Garantia / Renta Adelantada.")
                End If

                oVentaExpress.actualizarDepositoGarantia(nroSec, nroDeposito, hidCustumerId.Value, sTipoGarantia)
								
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Grabar Renta Adelantada")
            End If
			
			Dim respuesta As String
			Dim negDRA As New BLRentaAdelantada

			oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "INICIO ACTUALIZAR UBIGEO")
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp nroSec: " & nroSec)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp nroDocCliente: " & nroDocumentoCli) 'SD_644347 - CUOTAS
			negDRA.actualizarUbigeo(CheckInt64(nroSec), CheckStr(nroDocumentoCli), respuesta)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp respuesta: " & respuesta)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "FIN ACTUALIZAR UBIGEO")
                      
            'gaa20170719
            'inicio RegistrarAcuerdoReno
            oLog.Log_WriteLog(strArchivo, "PROY-9067 : Iniciando Metodo RegistrarAcuerdoReno")
            oLog.Log_WriteLog(strArchivo, "PROY-9067 : Input nroPedido")
            oLog.Log_WriteLog(strArchivo, "PROY-9067 : Input nroContrato")
            RegistrarAcuerdoReno(nroPedido, nroContratoSisact)
            'fin RegistrarAcuerdoReno
            'Fin gaa20170719
                      
        Catch ex As Exception

            'Anula Factura, Contrato, NroPedido en SISACT_VENTA_RENOVACION
            AnularVentaRenovacion(factura, nroSec)

			' INICIO IMP SD_818878
            'Anula Nro de Contrato en la tabla SEC
            oVentaExpress.Set_Actualiza_Contrato_Solicitud(CheckInt64(nroSec), "00")

            'Rollback PVU - Elimina Pedido y Contrato
            oVentaExpress.RollBackVenta(idVenta, rspRB)

            'Rollback MSSAP
            RollBackVenta(factura)

            hidMsg.Value = " Error. Generar Pedido. " & ex.Message & e_CanjePuntos
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Error  --> GenerarPedido: " & ex.Message)
            hidCodErrorPedido.Value = "1"
			' FIN IMP SD_818878

        Finally
            oConsultaSap = Nothing
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Generar Pedido")
        End Try
    End Sub
    '******************************************** INICIO WHZR ************************************************************

    Private Sub RollBackVentaSAP(ByVal nroPedido As String)

        Dim oficina As String
        Dim arrCabecera(49) As String

        Dim oConsultarSap As New SapGeneralNegocios
        Dim bProceso, bProcesoBoleta As Boolean

        oficina = hidOficina.Value

        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(oficina)
        Dim canal As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG")))
        Dim orgVenta As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG")))

        arrCabecera(0) = nroPedido
        arrCabecera(1) = "ELIM"
        arrCabecera(2) = oficina
        arrCabecera(48) = orgVenta
        arrCabecera(49) = canal
        Dim strCabecera As String = Join(arrCabecera, ";")

        oConsultarSap.RealizarPedido(strCabecera, "", "", "", "", "", "", "", "", "", "", "", 0)
    End Sub

    Private Function RegistrarPreventaSICAD(ByVal nroPedido As String) As Boolean
        Dim oOficina As New PuntoVenta
        Dim oVentaExpress As New VentaExpressNegocios
        Dim blnRetorno As Boolean
        Dim NroTicket As String

        'Parametros de Salida
        Dim listaPedido As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim listaOrden As New ArrayList
        Dim oVenta As New VentaSiscad

        Dim retorno As String
        Dim exito As Boolean = False

        Dim listaSeriesSinSKU As New ArrayList
        Dim listaSeriesSinPrecio As New ArrayList
        Dim arrRetorno() As String
        Dim idLog As String = txtNroLinea.Text
        Dim oPar As New BEParametroOficina
        Dim codSinergia As String
        Dim ofi As New ConsultaMsSapNegocio
        oPar = ofi.ConsultaParametrosOficina(hidOficina.Value, "")
        oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Trae Datos")
        codSinergia = oPar.cPuntoVentaSinergia
        oLog.Log_WriteLog(strArchivo, " -" & idLog & "codSinergia ....... " & codSinergia)
        Try
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio ObtenerDatosOficina")


            If ObtenerDatosOficina(nroPedido, codSinergia, oOficina) Then

                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin ObtenerDatosOficina")

                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio ObtenerDatosVenta")

                If ObtenerDatosVenta(nroPedido, codSinergia, oOficina, _
                                            listaPedido, _
                                            listaMaterial, _
                                            listaOrden, _
                                            oVenta) Then

                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin ObtenerDatosVenta")

                    oVenta.EstadoVenta = ConfigurationSettings.AppSettings("constEstadoVentaPreventa")
                    oVenta.Usuario = Me.CurrentUser
                    'REGISTRAR CABECERA VENTA SISCAD
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio CrearVenta")
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp IdVenta		:" & oVenta.IdVenta)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TicketPreventa :" & oVenta.TicketPreventa)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TipoDocCliente :" & oVenta.TipoDocCliente)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroDocCliente  :" & oVenta.NroDocCliente)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp PuntoVenta     :" & oVenta.PuntoVenta)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroPedidoSap   :" & oVenta.NroPedidoSap)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroEntregaSap  :" & oVenta.NroEntregaSap)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroContratoSap :" & oVenta.NroContratoSap)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroDocumentoSap:" & oVenta.NroDocumentoSap)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TipoVenta      :" & oVenta.TipoVenta)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp EstadoVenta    :" & oVenta.EstadoVenta)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TicketVenta    :" & oVenta.TicketVenta)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TipoOperacion  :" & oVenta.TipoOperacion)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp Usuario        :" & oVenta.Usuario)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp CodAplicacion  :" & oVenta.CodAplicacion)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp FechaCierre    :" & oVenta.FechaCierre)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroDocVendedor :" & oVenta.NroDocVendedor)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NombreVendedor :" & oVenta.NombreVendedor)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp nropedido_mssap :" & oVenta.nropedido_mssap)
                    blnRetorno = oVentaExpress.CrearVenta(oVenta, NroTicket)

                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "out blnRetorno: " & blnRetorno)
                    oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin CrearVenta")

                    If blnRetorno Then
                        oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
                        For Each orden As OrdenVentaSiscad In listaOrden

                            'Agregar Nro. Ticket en la Entidad OrdenSiscad
                            orden.TicketPreventa = NroTicket
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Inicio CrearOrdenVenta")
                            'Grabar información de Orden de Venta
                            orden.EstadoMaterial = ConfigurationSettings.AppSettings("constEstadoMaterialPreventa")
                            orden.OrigenVenta = ConfigurationSettings.AppSettings("constAplicacion")

                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP CodigoMaterial:" & orden.CodigoMaterial)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP Serie:" & orden.Serie)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP ListaPrecio:" & orden.ListaPrecio)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "	INP Precio:" & orden.Precio)

                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio CrearOrdenVenta")
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp TicketPreventa:" & orden.TicketPreventa)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp CodigoMaterial:" & orden.CodigoMaterial)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp Serie:" & orden.Serie)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp Precio:" & orden.Precio)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp ListaPrecio:" & orden.ListaPrecio)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp PuntoVenta:" & orden.PuntoVenta)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp Identificador :" & orden.Identificador)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp EstadoMaterial :" & orden.EstadoMaterial)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp NroTelefono  :" & orden.NroTelefono)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inp OrigenVenta  :" & orden.OrigenVenta)
                            retorno = oVentaExpress.CrearOrdenVenta(orden)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "out retorno: " & retorno)
                            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin CrearOrdenVenta")

                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "    OUT retorno: " & retorno)
                            oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")
                            If retorno <> String.Empty Then
                                arrRetorno = retorno.Split(";"c)
                                If arrRetorno.Length > 2 Then
                                    If CheckInt(arrRetorno(0)) > 0 Then
                                        If arrRetorno(1) = "0" Then
                                            listaSeriesSinPrecio.Add(orden)
                                        End If
                                        If arrRetorno(2) = "0" Then
                                            orden.Precio = Funciones.CheckDecimal(arrRetorno(3))
                                            listaSeriesSinSKU.Add(orden)
                                        End If
                                    End If
                                End If
                            Else
                                exito = False
                                Exit Function
                            End If

                        Next

                        Dim arrID_VENTA() As String
                        Dim id_venta As Integer = 0
                        If NroTicket <> String.Empty Then
                            arrID_VENTA = NroTicket.Split("-"c)
                            id_venta = CheckInt(arrID_VENTA(1))
                        End If

                        Dim EstadoVenta As String = String.Empty
                        EstadoVenta = ConfigurationSettings.AppSettings("constEstadoVentaPreventa")
                        'crear historico''
                        Dim objVenta As New VentaExpressNegocios
                        Dim respuestaHist As Boolean = False
                        oLog.Log_WriteLog(strArchivo, "---RegistroHistoricoVenta---")
                        oLog.Log_WriteLog(strArchivo, "id Venta: " & id_venta)
                        oLog.Log_WriteLog(strArchivo, "Estado: " & EstadoVenta)
                        oLog.Log_WriteLog(strArchivo, "Usuario: " & Me.CurrentUser)
                        respuestaHist = objVenta.RegistroHistoricoVenta(id_venta, EstadoVenta, Me.CurrentUser) 'Session("strUsuario").ToString())
                        oLog.Log_WriteLog(strArchivo, "Resultado: " & respuestaHist.ToString)
                        If Not respuestaHist Then
                            Return False
                        End If

                        If (listaSeriesSinPrecio.Count > 0 OrElse listaSeriesSinSKU.Count > 0) Then
                            EnviarCorreoSiscad(oOficina, listaSeriesSinPrecio, listaSeriesSinSKU)
                        End If

                        oLog.Log_WriteLog(strArchivo, " -" & txtNroLinea.Text & "- " & "Fin CrearOrdenVenta")
                        exito = True
                    Else
                        exito = False
                    End If

                Else
                    exito = False
                End If
            Else
                exito = False
            End If
            If exito = False Then
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio ANULACION_VENTA")
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "inp nroPedido: " & nroPedido)
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "inp Almacen: " & CheckStr(Session("Almacen")))
                oVentaExpress.ANULACION_VENTA(NroTicket, CheckStr(codSinergia))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin ANULACION_VENTA")
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "ERROR: " & ex.Message.ToString())
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio ANULACION_VENTA(2)")
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "inp nroPedido: " & nroPedido)
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "inp Almacen: " & CheckStr(Session("Almacen")))
            oVentaExpress.ANULACION_VENTA(NroTicket, CheckStr(codSinergia))
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin ANULACION_VENTA")
            exito = False
        End Try
        Return exito
    End Function

    Private Function ObtenerDatosOficina(ByVal NroDocSap As String, ByVal PuntoVenta As String, ByRef Oficina As PuntoVenta) As Boolean
        Dim oSiscad As New VentaExpressNegocios
        Dim arrayOficina As New ArrayList
        Dim blnFound As Boolean = False
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Dim idLog As String = txtNroLinea.Text

        Try
            'Verificar Oficina es un Corner y Obtener Datos
            Oficina = oSiscad.ObtenerDatosOficinaventa(PuntoVenta)

            If Oficina.OVENC_CODIGO <> "" Then
                blnFound = True
            End If

        Catch ex As Exception
            blnFound = False
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "ERROR ObtenerDatosOficina:" & ex.Message.ToString())
        Finally
            arrayOficina = Nothing
            oSiscad = Nothing
        End Try

        Return blnFound
    End Function

    Private Sub EnviarCorreoSiscad(ByVal oOficina As PuntoVenta, ByVal listaSeriesSinPrecio As ArrayList, ByVal listaSeriesSinSKU As ArrayList)

        Try
            Dim strMensaje As String
            Dim strListaDistribucion As String
            Dim strCorreoAlerta As String
            Dim strMaterial As String
            Dim strListaPrecios As String

            'Determina Mensaje Series sin precio
            For Each orden As OrdenVentaSiscad In listaSeriesSinPrecio
                strMaterial = orden.CodigoMaterial & " - " & orden.DescMaterial
                strListaPrecios = orden.ListaPrecio & " - " & orden.DesListaPrecio
                strMensaje += String.Format("No se ha encontrado el precio para el material {0} con lista de precios {1} en el punto de venta {2}.", strMaterial, strListaPrecios, oOficina.OVENV_DESCRIPCION) + "|"
            Next

            'Determina Mensaje Precio sin SKU
            For Each orden As OrdenVentaSiscad In listaSeriesSinSKU
                strMensaje += String.Format("No se tiene configurado un SKU para el precio S/. {0} en la cadena {1}.", orden.Precio, oOficina.CANAV_DESCRIPCION) + "|"
            Next

            If strMensaje <> "" Then
                Dim strHTMLCuerpo As String
                Dim arrMensaje() As String
                Dim i As Integer

                arrMensaje = strMensaje.Split("|")
                strHTMLCuerpo = "<HTML>"
                strHTMLCuerpo = strHTMLCuerpo & "<HEAD></HEAD><BODY><table>"
                For i = 0 To UBound(arrMensaje)
                    strHTMLCuerpo = strHTMLCuerpo & "<tr><td>" & arrMensaje(i) & "</tr></td>"
                Next
                strHTMLCuerpo = strHTMLCuerpo & "</table></BODY></HTML>"

                strCorreoAlerta = ObtenerCorreoAlertasSiscad(oOficina.OVENC_CODIGO)
                strListaDistribucion = ObtenerListaDistribucion(ConfigurationSettings.AppSettings("CodParam_CorreoAdmCadenas"))

                sisact_Mail.EnviarEmail(ConfigurationSettings.AppSettings("strEmailRemitente"), strListaDistribucion & ";" & strCorreoAlerta, "", "", ConfigurationSettings.AppSettings("AsuntoCorreoSISCADAlertas"), strHTMLCuerpo, "")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Function ObtenerCorreoAlertasSiscad(ByVal codPdv As String) As String

        Dim strCorreos As String
        Try
            Dim oVentaNegocios As New VentaExpressNegocios
            Dim oAlerta As AlertaSiscad
            oAlerta = oVentaNegocios.CorreoAlertasSiscad(codPdv)
            strCorreos = oAlerta.MAILJEFE & ";" & oAlerta.MAILSECTORISTA
        Catch ex As Exception
            strCorreos = ""
        End Try
        Return strCorreos
    End Function

    Private Function ObtenerListaDistribucion(ByVal key As String) As String

        Dim strCorreos As String
        Try
            Dim oVentaNegocios As New VentaExpressNegocios
            strCorreos = oVentaNegocios.ConsultaParamConfigSiscad(key)
        Catch ex As Exception
            strCorreos = ""
        End Try
        Return strCorreos
    End Function

    Private Function ObtenerDatosVenta(ByVal NroDocSap As String, _
                                        ByVal PuntoVenta As String, _
                                        ByVal oOficina As PuntoVenta, _
                                        ByRef arrayPedido As ArrayList, _
                                        ByRef arrayMaterial As ArrayList, _
                                        ByRef arrayOrden As ArrayList, _
                                        ByRef oVenta As VentaSiscad) As Boolean

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsPedido As New DataSet
        Dim dtCabecera As New DataTable
        Dim dtDetalle As New DataTable
        Dim blnFound As Boolean = False
        Dim idx As Integer = 0
        Dim strKey As String = PuntoVenta & "|" & NroDocSap
        Dim idLog As String = txtNroLinea.Text
        Dim oMssap As New BLConsultaMssap
        Dim item As New ItemGenerico
        Try

            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Inicio Get_ConsultaPedido")
            'Consulta Datos Pedido Sap
            'dsPedido = oConsultaSap.Get_ConsultaPedido("", PuntoVenta, NroDocSap, "")
            dsPedido = oMssap.ConsultaPedido(NroDocSap, PuntoVenta)
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Fin Get_ConsultaPedido")

            If IsNothing(dsPedido) OrElse dsPedido.Tables.Count = 0 Then
                Throw New Exception("No se encontro Registros Consulta Pedido Sap.")
            Else
                '0.Estructuras Tablas Detalle Pedido Sap
                dtCabecera = CType(dsPedido.Tables(0), DataTable)
                dtDetalle = CType(dsPedido.Tables(1), DataTable)

                If dtCabecera.Rows.Count = 0 Or dtDetalle.Rows.Count = 0 Then
                    Throw New Exception("No se encontro Registros Detalle Pedido MSSAP.")
                End If
            End If

            '1.Obtener Datos Venta BD Siscad
            oVenta.NroDocCliente = CheckStr(dtCabecera.Rows(0)("CLIEV_NRODOCCLIENTE"))
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oVenta.NroDocCliente..." & CheckStr(oVenta.NroDocCliente))
            oVenta.TipoDocCliente = CheckStr(dtCabecera.Rows(0)("CLIEC_TIPODOCCLIENTE")).PadLeft(2, "0")
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oVenta.TipoDocCliente..." & CheckStr(oVenta.TipoDocCliente))
            oVenta.NroContratoSap = CheckStr(dtCabecera.Rows(0)("PEDIN_NROPEDIDO"))
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oVenta.NroContratoSap..." & CheckStr(oVenta.NroContratoSap))
            oVenta.PuntoVenta = PuntoVenta
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "PuntoVenta..." & CheckStr(PuntoVenta))
            oVenta.NroDocumentoSap = NroDocSap
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "NroDocSap..." & CheckStr(NroDocSap))
            oVenta.TipoVenta = CheckStr(dtCabecera.Rows(0)("PEDIC_TIPOVENTA"))
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oVenta.TipoVenta..." & CheckStr(oVenta.TipoVenta))
            Dim strDocVendedor As String = CheckStr(hidNomVendedor.Value)
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "strDocVendedor..." & CheckStr(strDocVendedor))
            Dim strNomVendedor As String = CheckStr(hidDocVendedor.Value)
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "strNomVendedor..." & CheckStr(strNomVendedor))

            oVenta.NroDocVendedor = strDocVendedor
            oVenta.NombreVendedor = strNomVendedor
            If CheckStr(dtCabecera.Rows(0)("PEDIC_TIPOVENTA")) = "07" Then
                oVenta.TipoVenta = "3"
            End If

            'Valor de Tipo Operacion
            oVenta.TipoOperacion = CheckStr(dtCabecera.Rows(0)("PEDIC_CODTIPOOPERACION"))
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oVenta.TipoOperacion..." & CheckStr(oVenta.TipoOperacion))
            oVenta.CodAplicacion = ConfigurationSettings.AppSettings("constAplicacion")

            '2.Obtener Detalle Pedido Sap
            For i As Integer = 0 To dtDetalle.Rows.Count - 1

                Dim oPedido As New PedidoSiscad
                Dim oMaterial As New MaterialSiscad

                oPedido.Werks = oOficina.OVENV_CENTRO
                oPedido.Lgort = oOficina.OVENV_ALMACEN
                oPedido.Auart = ConfigurationSettings.AppSettings("clasedocumento")
                oPedido.Vkorg = ConfigurationSettings.AppSettings("Organizacionventas")
                oPedido.Kunnr = oOficina.OVENV_NRO_CLIE_PADRE
                oPedido.Kunag = oOficina.OVENV_NRO_CLIE_HIJO
                oPedido.Vtweg = ConfigurationSettings.AppSettings("Canaldistribucion")
                oPedido.Spart = ConfigurationSettings.AppSettings("Sector")
                oPedido.Vkbur = oOficina.OVENC_CODIGO
                oPedido.Menge = 1

                oPedido.Matnr = CheckStr(dtDetalle.Rows(i)("DEPEC_CODMATERIAL"))
                oPedido.Vkaus = CheckStr(dtDetalle.Rows(i)("DEPEV_CODIGOLP"))

                If arrayPedido.Count > 0 Then

                    For ii As Integer = 0 To arrayPedido.Count - 1
                        Dim pedido As PedidoSiscad = CType(arrayPedido(ii), PedidoSiscad)

                        If oPedido.Matnr = pedido.Matnr And oPedido.Vkaus = pedido.Vkaus Then
                            oPedido.Menge = pedido.Menge + 1
                            arrayPedido.RemoveAt(ii)
                            Exit For
                        End If
                    Next

                End If

                arrayPedido.Add(oPedido)

                '3.Obtener Lista Materiales Sap SERIC_CODSERIE

                oMaterial.Matnr = CheckStr(dtDetalle.Rows(i)("DEPEC_CODMATERIAL"))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oMaterial.Matnr..." & CheckStr(oMaterial.Matnr))
                oMaterial.Sernr = CheckStr(dtDetalle.Rows(i)("SERIC_CODSERIE")).PadLeft(18, "0")
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oMaterial.Sernr..." & CheckStr(oMaterial.Sernr))
                oMaterial.Vkaus = CheckStr(dtDetalle.Rows(i)("DEPEV_CODIGOLP"))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oMaterial.Vkaus..." & CheckStr(oMaterial.Vkaus))

                arrayMaterial.Add(oMaterial)

                '4.Obtener Detalle Orden BD Siscad
                Dim oOrden As New OrdenVentaSiscad

                oOrden.CodigoMaterial = CheckStr(dtDetalle.Rows(i)("DEPEC_CODMATERIAL"))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oOrden.CodigoMaterial..." & CheckStr(oOrden.CodigoMaterial))
                oOrden.PuntoVenta = PuntoVenta
                oOrden.ListaPrecio = CheckStr(dtDetalle.Rows(i)("DEPEV_CODIGOLP"))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oOrden.ListaPrecio..." & CheckStr(oOrden.ListaPrecio))
                oOrden.Precio = CheckDecimal(dtDetalle.Rows(i)("DEPEN_SUBTOTAL")) + CheckDecimal(dtDetalle.Rows(i)("DEPEN_IMPUESTO"))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "Orden.Precio..." & CheckStr(oOrden.Precio))
                oOrden.NroTelefono = FormatoTelefono(CheckStr(dtDetalle.Rows(i)("DEPEV_NROTELEFONO")))
                oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "oOrden.NroTelefono..." & CheckStr(oOrden.NroTelefono))

                item = oMssap.ConsultarSerie(CheckStr(dtDetalle.Rows(i)("SERIC_CODSERIE")))

                If item.Tipo = ConfigurationSettings.AppSettings("consGrupoChip") Then
                    idx = idx + 1
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIC_CODSERIE"))
                    oOrden.Identificador = idx
                Else
                    If arrayOrden.Count > 0 Then
                        For Each chip As OrdenVentaSiscad In arrayOrden
                            If item.Tipo = ConfigurationSettings.AppSettings("consGrupoChip") And chip.NroTelefono = oOrden.NroTelefono Then
                                oOrden.Identificador = chip.Identificador
                                Exit For
                            End If
                        Next
                    End If
                    oOrden.Serie = CheckStr(dtDetalle.Rows(i)("SERIC_CODSERIE")).Substring(3)
                End If

                arrayOrden.Add(oOrden)
            Next

            blnFound = True

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, " -" & idLog & "- " & "ERROR ObtenerDatosVenta: " & ex.Message.ToString())
            blnFound = False
        Finally
            oConsultaSap = Nothing
            dsPedido = Nothing
            dtCabecera = Nothing
            dtDetalle = Nothing
        End Try

        Return blnFound
    End Function


    '******************************************** FIN WHZR ************************************************************

    Private Sub CrearClienteSap(ByVal nroSec As String)
        Dim idLog As String = "Numero de Solicitud: " & nroSec
        Dim sap As New SapGeneralNegocios
        Dim oConsultaSolicitud As New SolicitudNegocios
        Dim DclienteSAP(64) As String

        Dim listaSec As New ArrayList
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio ObtenerSolicitudes")
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "inp nroSec:" & nroSec)
        listaSec = oConsultaSolicitud.ObtenerSolicitudes(nroSec) 'Consulta lista SEC por sec padre
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "out listaSec:" & listaSec.Count.ToString())
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin ObtenerSolicitudes")
        For Each item As SolicitudPersona In listaSec
            Session("Solicitud_" & CheckStr(item.SOLIN_CODIGO)) = item
        Next
        oSolicitud = CType(Session("Solicitud_" & nroSec), SolicitudPersona)

        DclienteSAP(36) = "0.00"
        DclienteSAP(37) = "0.00"
        DclienteSAP(41) = "0.00"

        DclienteSAP(18) = "" 'strCodTipoDocumentoRepLegal
        DclienteSAP(19) = "" 'strNumeroDocumentoRepLegal
        DclienteSAP(20) = "" 'strNombreRepLegal
        DclienteSAP(21) = "" 'strApellidoPaternoRepLegal
        DclienteSAP(22) = "" 'strApellidoManternoRepLegal

        DclienteSAP(24) = "" 'strCodTipoDocumentoContacto
        DclienteSAP(25) = "" 'strNumeroDocumentoContacto	
        DclienteSAP(26) = "" 'strNombreContacto 
        DclienteSAP(27) = "" 'strApellidoPaternoContacto  
        DclienteSAP(28) = "" 'strApellidoManternoContacto 
        DclienteSAP(29) = "" 'strCargoContacto   

        DclienteSAP(40) = "" 'CODIGO TIPO DE MONEDA

        DclienteSAP(7) = "01/01/1900"
        DclienteSAP(8) = ""
        DclienteSAP(9) = ""
        DclienteSAP(10) = ""
        DclienteSAP(11) = " "
        DclienteSAP(12) = "00"
        DclienteSAP(13) = ""
        DclienteSAP(23) = ""
        DclienteSAP(29) = ""
        DclienteSAP(31) = ""
        DclienteSAP(32) = ""
        DclienteSAP(33) = ""
        DclienteSAP(34) = ""
        DclienteSAP(35) = ""
        DclienteSAP(36) = "0.00"
        DclienteSAP(37) = "0.00"
        DclienteSAP(38) = ""
        DclienteSAP(39) = ""
        DclienteSAP(41) = "0.00"
        DclienteSAP(42) = ""
        DclienteSAP(43) = ""
        DclienteSAP(44) = ""
        DclienteSAP(45) = ""
        DclienteSAP(46) = ""
        DclienteSAP(47) = ""
        DclienteSAP(48) = ""
        DclienteSAP(49) = ""
        DclienteSAP(50) = ""
        DclienteSAP(51) = ""
        DclienteSAP(52) = ""
        DclienteSAP(53) = ""
        DclienteSAP(55) = ""
        DclienteSAP(56) = "01"
        DclienteSAP(57) = ""
        DclienteSAP(58) = "00"
        DclienteSAP(59) = "00"
        DclienteSAP(60) = "0"
        DclienteSAP(61) = ""
        DclienteSAP(62) = ""

        DclienteSAP(0) = oSolicitud.CLIEC_NUM_DOC 'NUMERO DE DOCUMENTO DE IDENTIDAD
        DclienteSAP(1) = oSolicitud.TDOCC_CODIGO   'CODIGO ENTERO TIPO DE DOCUMENTO

        If oSolicitud.TPROC_CODIGO = "01" Then 'Sisact: 01 = Consumer - SAP: 02 = Consumer
            DclienteSAP(2) = "02"
        ElseIf oSolicitud.TPROC_CODIGO = "02" Then 'Sisact: 02 = Bussiness - SAP: 01 = Bussiness
            DclienteSAP(2) = "01"
        ElseIf oSolicitud.TPROC_CODIGO = "06" Then 'Sisact: 06 = B2E - SAP: 05 = B2E
            DclienteSAP(2) = "05"
        End If

        If oSolicitud.TDOCC_CODIGO = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
            DclienteSAP(3) = ""
            DclienteSAP(4) = ""
            DclienteSAP(5) = ""
        Else
            DclienteSAP(3) = oSolicitud.CLIEV_NOMBRE
            DclienteSAP(4) = oSolicitud.CLIEV_APE_PAT
            DclienteSAP(5) = oSolicitud.CLIEV_APE_MAT
        End If
        DclienteSAP(6) = oSolicitud.CLIEV_RAZ_SOC  'RAZON SOCIAL DEL CLIENTE	

        If oSolicitud.FECHA_NACIMIENTO.ToString() <> "" Then
            DclienteSAP(7) = oSolicitud.FECHA_NACIMIENTO.ToString("yyyy/MM/dd")
        Else
            DclienteSAP(7) = Convert.ToDateTime("01/01/1900").ToString("yyyy/MM/dd")
        End If

        DclienteSAP(10) = oSolicitud.SOLIV_CORREO
        DclienteSAP(47) = oSolicitud.ESTADO_CIVIL_DES 'ddlEstadoCivil.SelectedValue
        DclienteSAP(48) = "" 'ddlTitulo.SelectedValue

        Dim oDirecionCliente As New DireccionCliente
        oDirecionCliente = ObtenerDireccionCliente(nroSec, "C")

        Dim oDirecionFacturacion As New DireccionCliente
        oDirecionFacturacion = ObtenerDireccionCliente(nroSec, "F")

        Dim strUbigeoClienteDomicilio As String = Trim(oDirecionCliente.IdDepartamento) & Trim(oDirecionCliente.IdProvincia) & Trim(oDirecionCliente.IdDistrito)
        If (Not (Trim(strUbigeoClienteDomicilio) = "")) Then
            DclienteSAP(14) = Mid(Trim(oDirecionCliente.DirCompletaSAP), 1, 40)     'DIRECCION DEL CLIENTE
            DclienteSAP(15) = strUbigeoClienteDomicilio 'UBIGEO DIRECCION DEL CLIENTE 'strDepartamento1 & strProvincia1 & strDistrito1
        End If

        Dim strUbigeoClienteFacturacion As String = Trim(oDirecionFacturacion.IdDepartamento) & Trim(oDirecionFacturacion.IdProvincia) & Trim(oDirecionFacturacion.IdDistrito)
        If (Not (Trim(strUbigeoClienteFacturacion) = "")) Then
            DclienteSAP(16) = Mid(Trim(oDirecionFacturacion.DirCompletaSAP), 1, 40)
            DclienteSAP(17) = strUbigeoClienteFacturacion 'UBIGEO DIRECCION DEL CLIENTE FACTURACION
        End If
        DclienteSAP(54) = Mid(Trim(oDirecionCliente.DirReferenciaSAP), 1, 40) 'REFERENCIA DE DIRECCION
        DclienteSAP(63) = Mid(Trim(oDirecionFacturacion.DirReferenciaSAP), 1, 40) 'REFERENCIA DE DIRECCION FACT
        DclienteSAP(62) = "1"
        DclienteSAP(55) = "1"

        Dim dt As New DataSet
        Dim ptoVenta As String
        ptoVenta = hidOficina.Value

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio Set_ActualizaCreaCliente")
        oLog.Log_WriteLog(strArchivo, idLog & " - " & "DclienteSAP: " & Join(DclienteSAP, ";"))

        dt = sap.Set_ActualizaCreaCliente(ptoVenta, DclienteSAP)

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin Set_ActualizaCreaCliente")
        Dim strMensaje As String
        strMensaje = ""

        For i As Integer = 0 To dt.Tables(1).Rows.Count - 1
            If CheckStr(dt.Tables(1).Rows(i).Item("TYPE")) = "E" Then
                strMensaje = CheckStr(dt.Tables(1).Rows(i).Item("MESSAGE"))
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR Set_ActualizaCreaCliente:" & strMensaje)
            End If
        Next
        If strMensaje.Length > 0 Then
            hidResponse.Value = "FaltaCliente"
            Exit Sub
        Else
            Dim dt1 As DataSet
            dt1 = sap.Get_ConsultaCliente(ptoVenta, oSolicitud.TDOCC_CODIGO, oSolicitud.CLIEC_NUM_DOC)
            If dt1.Tables(0).Rows.Count > 0 Then
                hidClienteSap.Value = CheckStr(dt1.Tables(0).Rows(0)("KUNNR"))
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "CodClienteSAP: " & hidClienteSap.Value)
            End If
        End If
    End Sub

    Private Function ObtenerDireccionCliente(ByVal nroSec As String, ByVal tipoDireccion As String) As DireccionCliente
        Dim oDireccion As New DireccionCliente
        Dim arrDireccion As ArrayList
        arrDireccion = (New SolicitudNegocios).ConsultarSolDireccion(CheckInt(nroSec))
        For Each oDirecTemp As DireccionCliente In arrDireccion
            If oDirecTemp.solin_codigo = nroSec And oDirecTemp.IdTipoDireccion = tipoDireccion Then
                oDireccion = oDirecTemp
                Exit For
            End If
        Next
        Return oDireccion
    End Function

    Private Sub ConsultarTipoDocVenta()
        Dim dsClasePedido As New DataSet
        Dim oficina As String = hidOficina.Value
        Dim tipoDocCliente As String = hidTipoDocumento.Value

        If Not hidOficina.Value.Equals(String.Empty) And Not hidTipoDocumento.Value.Equals(String.Empty) Then
            dsClasePedido = (New SapGeneralNegocios).ConsultarTipoDocumentoOfVenta(hidOficina.Value)
            Dim listaTipoDocVenta() As String 'PROY-31636
            'INI PROY-31636
            If AppSettings.Key_codigoDocMigratorios.IndexOf(tipoDocCliente) > -1 Then
                listaTipoDocVenta = AppSettings.Key_ExpressTipoDocVentaPos.Split(CChar(","))
            Else
                listaTipoDocVenta = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & tipoDocCliente).Split(CChar(","))
            End If
            'FIN PROY-31636
            For Each item As String In listaTipoDocVenta
                If hidTipoDocVenta.Value <> "" Then
                    Exit For
                End If
                For Each fila As System.Data.DataRow In dsClasePedido.Tables(0).Rows
                    If CheckStr(fila.Item("AUART")) = item Then
                        hidTipoDocVenta.Value = item
                        Exit For
                    End If
                Next
            Next

            dsClasePedido = Nothing
            listaTipoDocVenta = Nothing
        End If
    End Sub

    Public Sub CargarSubsidios()
        Dim arrayListaParametro As ArrayList = New ConsumerNegocio().ListarParametroConsumer(1)
        For Each oItem As ParametroConsumer In arrayListaParametro
            If oItem.PCONI_CODIGO = ConfigurationSettings.AppSettings("constCodFactorSubsidioMenor") Then
                hidSubsidioMenor.Value = CheckStr(oItem.PCONV_VALOR)
            End If
            If oItem.PCONI_CODIGO = ConfigurationSettings.AppSettings("constCodFactorSubsidioMayor") Then
                hidSubsidioMayor.Value = CheckStr(oItem.PCONV_VALOR)
            End If
        Next
    End Sub

    Private Sub Inicio()
        hidTiempoInicioReg.Value = Now()
        Dim item As New ItemGenerico
        Dim oUsuario As New usuario
        Dim oConsulta As New MaestroNegocio
        Dim oConsumer As New ConsumerNegocio
        Dim oUsuarioNegocio As New LoginUsuarioNegocios
        Dim usuario As String = CurrentUser()

        hidPlanDefault.Value = ConfigurationSettings.AppSettings("constCodPlanChipRepuestoPospago").ToString()
        hidListaPrecioDefault.Value = ConfigurationSettings.AppSettings("constCodListPrecioChip").ToString()
        hidCampaniaDefault.Value = ConfigurationSettings.AppSettings("constCodCampaniaChipPospago").ToString()
        Try
            oUsuario = oUsuarioNegocio.ConsultaDatosUsuario(usuario)

            If CheckStr(oUsuario.OficinaId) = "" Then
                hidUsuarioNoRegistrado.Value = "S"
                Exit Sub
            End If

            'Consulta Opciones
            Dim codAplicacion As Int64 = CheckInt64(ConfigurationSettings.AppSettings("CodigoAplicacion"))

            Dim objSeguridad As New AuditoriaNegocio
            Dim arrayOpciones As ArrayList = objSeguridad.LeerPaginaOpcionesPorUsuario(CheckInt64(Session("codUsuarioSisact")))
            Dim opciones As String = ""
            For Each opcion As ItemGenerico In arrayOpciones
                If opcion.Codigo2 = ConfigurationSettings.AppSettings("constOpcionConsultaCreditos") Then
                    hidPerfilCreditos.Value = "S"
                End If
                opciones &= "," & opcion.Codigo2
            Next
            hidPerfilSEC.Value = opciones

            hidVerDetalleLinea.Value = "S"
            hidVerVentaProactiva.Value = "S"

            'Punto de Venta x Usuario
            Dim arrPuntoVenta As New ArrayList
            Dim arrListaTipoOficina As New ArrayList
            Dim arrListaCanal As New ArrayList
            Dim CanalDAC As String = ConfigurationSettings.AppSettings("constCodTipoDAC")
            Dim CanalCorner As String = ConfigurationSettings.AppSettings("constCodTipoCRN")
            Dim CanalCAC As String = ConfigurationSettings.AppSettings("constCodTipoCAC")

            oLog.Log_WriteLog(strArchivo, String.Format("{0}- INICIO USUARIO MULTIPUNTO", strIdentifyLog))

            If oUsuario.OficinaId = ConfigurationSettings.AppSettings("CONS_COD_PTOVTA_149") Then
                arrPuntoVenta = oConsulta.ListaPDVUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                oLog.Log_WriteLog(strArchivo, String.Format("{0}- CANTIDAD DE PUNTOS DE VENTA  - {1}", strIdentifyLog, arrPuntoVenta.Count.ToString()))
                Session("session_arrPuntoVenta") = arrPuntoVenta
                arrListaTipoOficina = oConsulta.ListaTipoOficinaVentaUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                For Each tipoOficina As ItemGenerico In arrListaTipoOficina
                    If tipoOficina.Codigo.Equals(CanalDAC) Or tipoOficina.Codigo.Equals(CanalCorner) Or tipoOficina.Codigo.Equals(CanalCAC) Then
                        arrListaCanal.Add(tipoOficina)
                        'Exit For
                    End If
                Next
                arrListaTipoOficina = arrListaCanal
                hidPerfil_149.Value = "S"

            Else
                arrPuntoVenta = oConsulta.ListaPDVUsuario(oUsuario.UsuarioId, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                oLog.Log_WriteLog(strArchivo, String.Format("{0}- CANTIDAD DE PUNTOS DE VENTA  - {1}", strIdentifyLog, arrPuntoVenta.Count.ToString()))
                Session("session_arrPuntoVenta") = arrPuntoVenta
                arrListaTipoOficina = oConsulta.ListaTipoOficinaVentaUsuario(oUsuario.UsuarioId, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

                For Each tipoOficina As ItemGenerico In arrListaTipoOficina
                    If tipoOficina.Codigo.Equals(CanalDAC) Or tipoOficina.Codigo.Equals(CanalCorner) Or tipoOficina.Codigo.Equals(CanalCAC) Then
                        arrListaCanal.Add(tipoOficina)
                        'Exit For
                    End If
                Next
                arrListaTipoOficina = arrListaCanal
            End If
            oLog.Log_WriteLog(strArchivo, String.Format("{0}- FIN USUARIO MULTIPUNTO", strIdentifyLog))

            If arrPuntoVenta.Count = 0 And arrListaTipoOficina.Count = 0 Then
                hidValidaInicial.Value = ConfigurationSettings.AppSettings("msjValidacionRPDAC")
                Exit Sub
            End If

            LlenaCombo(arrListaTipoOficina, ddlCanal, "CODIGO", "DESCRIPCION", False, False)
            ddlCanal.Items.Insert(0, New ListItem("SELECCIONAR...", String.Empty))
            If ddlCanal.Items.Count >= 2 Then
                ddlCanal.SelectedIndex = 1
            End If

            hidTipoVenta.Value = ConfigurationSettings.AppSettings("strTVPostpago")
            'BlackList Vendedores
            If oUsuario.OficinaId = ConfigurationSettings.AppSettings("CONS_COD_PTOVTA_149") Then
                Dim arrBlackListPdv As ArrayList = oConsulta.ListaBlackListCanalPdv()
                For Each oItem As BLCanalPDV In arrBlackListPdv
                    hidListaBlackList.Value = hidListaBlackList.Value + oItem.COD_CANAL + "-" + oItem.COD_PDV & "|"
                Next
            Else
                For Each oPuntoVenta As PuntoVenta In arrPuntoVenta
                    If oConsulta.validoPdvCliente_BlackList(oPuntoVenta.TOFIC_CODIGO, oPuntoVenta.OVENC_CODIGO) = 1 And oPuntoVenta.OVENC_REGION = "L" Then
                        hidBLVendedor.Value = "S"
                    End If
                Next
            End If

            'Lista Riesgo
            Dim strListaRiesgo As String
            Dim arrListaRiesgo As ArrayList = oConsumer.ListarTipoRiesgo("")
            For Each oItem As Riesgo In arrListaRiesgo
                strListaRiesgo = strListaRiesgo & oItem.RIEV_ENTRADA & ";" & oItem.RIEV_DESCRIPCION & "|"
            Next
            hidListaRiesgo.Value = strListaRiesgo

            Dim listaParametros As String
            Dim arrayListaParametro As ArrayList = oConsumer.ListarParametroGeneral(1)
            For Each oItem As ParametroConsumer In arrayListaParametro
                'Lista de Canal / Documentos - Error Tipo 7
                If ConfigurationSettings.AppSettings("COD_GRUPO_CANAL_NO_ERROR_TIPO_7") = CheckStr(oItem.PCONI_CODIGO) Or _
                    ConfigurationSettings.AppSettings("COD_GRUPO_DOC_NO_ERROR_TIPO_7") = CheckStr(oItem.PCONI_CODIGO) Then
                    oitem.PCONV_VALOR = oitem.PCONV_VALOR.Replace("0", "-0")
                End If
                listaParametros = listaParametros & oitem.PCONI_CODIGO & ";" & CheckStr(oitem.PCONV_VALOR) & "|"

                'Carga Ratios Factor Renovacion
                If ConfigurationSettings.AppSettings("consCodRatioFactorMin") = CheckStr(oItem.PCONI_CODIGO) Then
                    hidRatioFactorMin.Value = CheckStr(oItem.PCONV_VALOR)
                ElseIf ConfigurationSettings.AppSettings("consCodRatioFactorMax") = CheckStr(oItem.PCONI_CODIGO) Then
                    hidRatioFactorMax.Value = CheckStr(oItem.PCONV_VALOR)
                End If
            Next
            hidListaParametroGeneral.Value = listaParametros

            Dim intCodFactor As Integer = CheckInt(ConfigurationSettings.AppSettings("ExpressCodFactorLimCred"))
            hidFactorLC.Value = CType((New MaestroNegocio).ListaParametros(intCodFactor)(0), Parametro).Valor

            'Consulta Parametros General

            'ini sinergia 07082015

            Dim oConsultaMSSAP As New ConsultaMsSapNegocio
            Dim oPar As BEParametroOficina

            'fin sinergia 07082015

            If Not oUsuario.OficinaId = ConfigurationSettings.AppSettings("CONS_COD_PTOVTA_149") Then

                oPar = oConsultaMSSAP.ParametrosOficina(Funciones.CheckStr(oUsuario.OficinaId))    'ParametrosOficinaVenta(oficina)
                Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(Funciones.CheckStr(oUsuario.OficinaId), "")

                'Dim dsOficina As DataSet = (New SapGeneralNegocios).ConsultarParametrosOfVenta(oUsuario.OficinaId)
                Dim strCanal As String = oParPVU.canal 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
                Dim strOrgVenta As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia")) 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))
                Dim strCentro As String = oParPVU.codigoCentro 'CheckStr(dsOficina.Tables(0).Rows(0).Item("WERKS"))

                hidCanalSap.Value = strCanal
                hidOrgVenta.Value = strOrgVenta
                hidCentro.Value = strCentro

                If oUsuario.TipoOficinaId = ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") Then
                    hidGrupoCadena.Value = oConsumer.ConsultarGrupoCadenaSISACT(oUsuario.OficinaId)
                    If hidGrupoCadena.Value = "" Then
                        hidGrupoCadena.Value = oConsumer.ConsultarGrupoCadena(oUsuario.OficinaId)
                    End If
                End If
            End If
            '----------- Cambio de bolsa compartida ------- 

            'Bolsa Compartida - Planes Conexion Plus
            Dim intCodParamBolsaCompartida As Integer = CheckInt(ConfigurationSettings.AppSettings("constCodParamBolsaCompartida").ToString())
            hidPlanBolsaCompartida.Value = CType((New MaestroNegocio).ListaParametros(intCodParamBolsaCompartida)(0), Parametro).Valor

            'Plan Base
            Dim arrPlanBase As ArrayList = (New ConsumerNegocio).ListarPlanBase()
            For Each oItem As ItemGenerico In arrPlanBase
                hidPlanBase.Value &= "|" & oItem.Codigo
            Next

            'Plan Combo
            Dim arrPlanCombo As ArrayList = (New ConsumerNegocio).ListarPlanCombo()
            For Each oItem As ItemGenerico In arrPlanCombo
                hidPlanCombo.Value &= "|" & oItem.Codigo
            Next

            '----------- Cambio de bolsa compartida ------- 


            hidCreditosxCE.Value = "S"

            CargarTipoDocumento()
            CargarSubsidios()


            'consolidado 13122014
            CargarMotivoRenovacionChip()

            Dim strOficinaPDV As String = CheckStr(oUsuario.OficinaId)

            If Not (oUsuario.OficinaId = ConfigurationSettings.AppSettings("CONS_COD_PTOVTA_149")) Then
                ConsultarDatosVenta()
                'CargarArticuloIMEI(strOficinaPDV)
            End If

            'CargarMaterialesPostpago(CanalCAC)
           
            'consolidado 13122014

            'INICIO GEJ 20141223
            Call ListarComboModalidad(ddlModalidad, "")
            'FIN GEJ 20141223

            'INICIO CAMPAÑA NUEVAS 23112015
            Call CargarGrupoProducto()

        Catch ex As Exception
            Alert(ex.Message)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error. Consultar Cliente Sap: " & ex.Message)
        End Try
    End Sub

    'FIN CAMPAÑA NUEVAS 23112015

    'INICIO CAMPAÑA NUEVAS 23112015

    Private Sub CargarGrupoProducto()

        Dim strFlujoRenov As String = CheckInt(ConfigurationSettings.AppSettings("constFlujoRenov"))
        Dim lista As ArrayList = (New VentaExpressNegocios).ListarGrupoProducto(strFlujoRenov)


        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        Dim oItemTemp As New ItemGenerico

        oItemTemp = lista(1)
        lista(1) = lista(2)
        lista(2) = oItemTemp

        LlenaCombo(lista, ddlGProducto, "Codigo", "Descripcion")
    End Sub

    'FIN CAMPAÑA NUEVAS 23112015

    Private Sub ListarComboModalidad(ByVal _ddlModalidad As DropDownList, ByVal ValorSeleccionado As String)
        'INICIO GEJ 20141223
        Dim codParamModalidadPago As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("constCodParamModalidadPago"))

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "codParamModalidadPago" & codParamModalidadPago)

        Dim codModalidadChipSuelto As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("constCodModalidadChipSuelto"))

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "codModalidadChipSuelto" & codModalidadChipSuelto)

        Dim arrLista As New ArrayList
        Dim arrListaTmp As ArrayList = New ConsumerNegocio().ListarTipoItem(codParamModalidadPago)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "codModalidadChipSuelto" & arrListaTmp.Count)
        For Each objItem As ItemGenerico In arrListaTmp
            If (objItem.Codigo <> codModalidadChipSuelto) Then
                If (objItem.Codigo = ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota")) Then
                    If (ConfigurationSettings.AppSettings("constFlagModalidadCuota") = "S") Then
                        arrLista.Add(objItem)
                    End If
                Else
                    arrLista.Add(objItem)
                End If
            End If
        Next
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "arrLista" & arrLista.Count)
        _ddlModalidad.DataSource = arrLista
        _ddlModalidad.DataValueField = "Codigo"
        _ddlModalidad.DataTextField = "Descripcion"
        _ddlModalidad.DataBind()
        'FIN GEJ 20141223
    End Sub

#Region "Cargar Controles"

    Public Sub LlenarTipoOferta()
        Try
            Dim objConsumer As New ConsumerNegocio
            Dim strTipoDocumento As String = ddlTipoDocumento.SelectedValue

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Inicio Listar Tipo Oferta *********")

            Dim listaOferta As ArrayList = objConsumer.ListarTipoOferta(strTipoDocumento)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "Valor Tipo Documento: " & strTipoDocumento)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "Cantidad de Registros: " & listaOferta.Count)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "Key 'Const_OfertaMasivo': " & ConfigurationSettings.AppSettings("Const_OfertaMasivo").ToString())

            Dim listaOfertaFiltrada As New ArrayList
            For Each item As ItemGenerico In listaOferta
                'gaa20160112
                'If item.Codigo.Equals(ConfigurationSettings.AppSettings("Const_OfertaMasivo").ToString()) Then
                'If item.Codigo.Equals(ConfigurationSettings.AppSettings("Const_OfertaMasivo").ToString()) OrElse _
                '    item.Codigo.Equals(ConfigurationSettings.AppSettings("constCodTipoProductoB2E").ToString()) Then
                '    'fin gaa20160112
                    listaOfertaFiltrada.Add(item)
                'End If
            Next

            ddlOferta.DataSource = listaOfertaFiltrada
            ddlOferta.DataValueField = "Codigo"
            ddlOferta.DataTextField = "Descripcion"
            ddlOferta.DataBind()
            ddlOferta.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))


        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "Error BD. " & ex.Message)
        End Try
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Fin Listar Tipo Oferta *********")

    End Sub

    Public Sub LlenarTipoOperacion()
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Inicio LlenarTipoOperacion *********")
        Dim objRenovacion As New RenovacionNegocio
        Dim strTipoOperacion As String
        Dim arrTipoOperacion2 As New ArrayList
        Dim arrTipoOperacion As ArrayList = objRenovacion.ListarTipoOperacion()
       
        If ConfigurationSettings.AppSettings("FlagActivaREPU") = "0" Then
            For Each item As ItemGenerico In arrTipoOperacion

                If (CheckStr(item.Codigo2) <> ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto")) Then
                    arrTipoOperacion2.Add(item)
                

                End If
            Next

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "arrTipoOperacion" & arrTipoOperacion.Count)
            For Each item As ItemGenerico In arrTipoOperacion2
                strTipoOperacion = String.Format("{0}|{1};{2};{3};{4}", strTipoOperacion, item.Codigo, item.Tipo, item.Codigo2, item.Descripcion)
            Next
            hidListaTipoOperacion.Value = strTipoOperacion
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "arrTipoOperacion" & hidListaTipoOperacion.Value)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** fin LlenarTipoOperacion *********")

        Else

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "arrTipoOperacion" & arrTipoOperacion.Count)
            For Each item As ItemGenerico In arrTipoOperacion
                strTipoOperacion = String.Format("{0}|{1};{2};{3};{4}", strTipoOperacion, item.Codigo, item.Tipo, item.Codigo2, item.Descripcion)
            Next
            hidListaTipoOperacion.Value = strTipoOperacion
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "arrTipoOperacion" & hidListaTipoOperacion.Value)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** fin LlenarTipoOperacion *********")

        End If

        
    End Sub

#End Region

    Public Sub Grabar()
        oClienteCuenta = CType(Session("oClienteCuenta" & hidNroDocumento.Value), ClienteCuenta)
        oClienteOfrecimiento = CType(Session("oClienteOfrecimiento" & hidNroDocumento.Value), ArrayList)

      
        Session("aux_nroDocumento") = hidNroDocumento.Value
		oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "aux_nroDocumento: " & Funciones.CheckStr(Session("aux_nroDocumento")))
        

        'Inicio Rihu 29122014
        Dim idVenta As Int64, nroAcuerdoSisact As Int64
        Dim oVenta As New VentaExpressNegocios
        Dim mensaje As String
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "strCodOficina: " & strCodOficina)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "strCodCanal: " & strCodCanal)
        If hidGrabar.Value = "0" Then
            If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                GrabarEvaluacionRUC()
            Else
                GrabarEvaluacionDNI()
            End If
        End If
        Dim GrabarEvaluacionOK As Boolean = IIf(hidCodError.Value = "1", False, True)

        'PROY-24724-IDEA-28174 - INICIO
        Dim strPedido As String = String.Empty

        If hidEvalPM.Value = "1" And HidSecGra.Value = "0" And hidAccion.Value = "Grabar" Then
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "hidEvalPM.Value: " & (hidEvalPM.Value).ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "HidSecGra.Value: " & (HidSecGra.Value).ToString())
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "hidAccion.Value: " & (hidAccion.Value).ToString())
            GrabarPrima(strPedido)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "strPedido: " & strPedido)
            HidSecGra.Value = ""
        End If
        'PROY-24724-IDEA-28174 - FIN

        If hidAccion.Value = "GenerarPedido" Then
            If GrabarEvaluacionOK Then
                Try
                GrabarVenta(hidDatosEquipo.Value, idVenta)
                GenerarAcuerdo(idVenta, nroAcuerdoSisact)

                    If idVenta = 0 Or nroAcuerdoSisact = 0 Then
                        oVenta.RollBackVenta(idVenta, mensaje)
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "mensaje: " & mensaje)
                        'Throw New Exception("Error al crear el acuerdo.")
                    End If
                Catch ex As Exception
                    Session("EvaluarIngreso") = Nothing
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "ERROR: " & ex.Message.ToString())
                    oVenta.RollBackVenta(idVenta, mensaje)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "mensaje: " & mensaje)
                    hidMsg.Value = "Error al crear el acuerdo."


                    Throw ex
                End Try

                If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                    GenerarPedidoCAC(idVenta, nroAcuerdoSisact)
                    'PROY-24724-IDEA-28174 - INICIO 
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "hidEvalPM.Value : " & (hidEvalPM.Value).ToString())
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "strPedido : " & strPedido)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "HidSecGra.Value: " & (HidSecGra.Value).ToString())
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "hidAccion.Value: " & (hidAccion.Value).ToString())

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "chkProMovil.Checked: " & chkProMovil.Checked)

                    If (hidEvalPM.Value = "1" And chkProMovil.Checked And HidSecGra.Value = "0") Then
                        GrabarPrima(strPedido)
                        If (strPedido = "SC") Then
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "strNroPedCabProtMovil: " & strNroPedCabProtMovil)
                            GenerarPedidoPrima(strNroPedCabProtMovil)
                        End If
                        HidSecGra.Value = ""
                    End If
                    'PROY-24724-IDEA-28174 - FIN
                Else
                    GenerarPedido(idVenta, nroAcuerdoSisact)
                End If
            Else
                hidAccion.Value = "Grabar"
                Session("EvaluarIngreso") = Nothing
            End If

            '//INI PROY 31636 RENTESEG
			If hidTipoDocumento.Value <> ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Then
            oLog.Log_WriteLog(strArchivo, "Inicio actualizar Nacionalidad cliente")

            Try
                Dim strClienteNacionalidad As String = hidTipoDocumento.Value & ";" & hidNroDocumento.Value & ";" & hidNacSeleccionado.Value & ";" & CurrentUser

                oLog.Log_WriteLog(strArchivo, "Cadena parametro nacionalidad => " + strClienteNacionalidad)
                Dim blnResultadoMSSAP = ConsultaMsSapNegocio.MSSAP_ClienteNacionalidad_Actualizar(strClienteNacionalidad)
                oLog.Log_WriteLog(strArchivo, "Resultado metodo MSSAP_ClienteNacionalidad_Actualizar() => " + blnResultadoMSSAP.ToString())

                Dim blnResultado = ClienteNegocio.ClienteNacionalidad_Actualizar(strClienteNacionalidad)
                oLog.Log_WriteLog(strArchivo, "Resultado metodo ClienteNacionalidad_Actualizar() => " + blnResultado.ToString())

            Catch ex As Exception
                oLog.Log_WriteLog(strArchivo, "ERROR AL ACTUALIZAR NACIONALIDAD CLIENTE => " & ex.Message)
            End Try
            oLog.Log_WriteLog(strArchivo, "Fin actualizar Nacionalidad cliente")
			End If
            '// FIN PROY 31636 RENTESEG
        End If


        ' Inicio PROY-25335 - Contratación Electrónica - Release 0
        If hidAccion.Value = "GenerarPedido" Then
            If GrabarEvaluacionOK Then
                Try
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI BIOMETRIA ----  ")


                    Dim NroSec_ As String = hidNroSEC.Value
                    Dim NroDocumento_ As String = hidNroDocumento.Value
                    Dim NroPedido_ As String = hidNroPedido.Value

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroSec: " & NroSec_)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroDocumento: " & NroDocumento_)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroPedido: " & NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI RegistrarRepresentanteLegalSEC ----  ")

                    RegistrarRepresentanteLegalSEC(NroSec_, NroDocumento_, NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarRepresentanteLegalSEC ----  ")
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI RegistrarCartaPoderSEC ----  ")

                    RegistrarCartaPoderSEC(NroSec_, NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarCartaPoderSEC ----  ")


                    If (hidBiometriaExito.Value.Equals("1")) Then
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI RegistrarBiometriaGendoc ----  ")

                    RegistrarBiometriaGendoc(NroSec_, NroDocumento_, NroPedido_)

                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarBiometriaGendoc ----  ")
                    End If
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN BIOMETRIA ----  ")
                Catch ex As Exception

                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR  --> BIOMETRIA : " & ex.Message)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarMetodosBIO ----  ")

                    Session("EvaluarIngreso") = Nothing

                End Try

            End If
        Else
            If GrabarEvaluacionOK Then
                Try
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI BIOMETRIA ----  ")


                    Dim NroSec_ As String = hidNroSEC.Value
                    Dim NroDocumento_ As String = hidNroDocumento.Value
                    Dim NroPedido_ As String = hidNroPedido.Value

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroSec: " & NroSec_)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroDocumento: " & NroDocumento_)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "NroPedido: " & NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI RegistrarRepresentanteLegalSEC ----  ")

                    RegistrarRepresentanteLegalSEC(NroSec_, NroDocumento_, NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarRepresentanteLegalSEC ----  ")
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- INI RegistrarCartaPoderSEC ----  ")

                    RegistrarCartaPoderSEC(NroSec_, NroPedido_)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN RegistrarCartaPoderSEC ----  ")
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN BIOMETRIA ----  ")
                Catch ex As Exception
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR BIOMETRIA --> BIOMETRIA : " & ex.Message)
                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "---- FIN BIOMETRIA ----  ")
                    Session("EvaluarIngreso") = Nothing
                End Try

            End If
        End If
       'Fin PROY-25335 - Contratación Electrónica - Release 0

    End Sub

    Private Sub GrabarEvaluacionDNI()
        Dim strPlan As String
        Dim strNroSEC As String
        Dim strNroSECPadre As String = "0"
        Dim blnGrabarMovil As Boolean = False
        Dim blnSECPadre As Boolean = False
        Dim strPlazoAcuerdo As String
        Dim oConsumer As New ConsumerNegocio
        Dim strMensajeSEC As String
        Try
            Session("CambioTitularidadDTH") = ""
            Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
            Dim vista As New Vista_SolicitudDC_Reporte
            Dim strCadSECGeneral As String = DatosEvalPersona(vista)
            Dim dblImporteGrupoSEC As Double = ConsultarImporteTotal()
            Dim dblCFGrupoSEC As Double = ConsultarCFTotal(arrPlanDetalle)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCadSECGeneral --> " & strCadSECGeneral)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "dblCFGrupoSEC --> " & dblCFGrupoSEC)

            Dim arrListaProducto As ArrayList = oConsumer.ListarProducto()

            'gaa20170725:Modificado para que cuando brms indique no cobrar muestre fidelizado
            If Not Session("PenalidadBRMS") Is Nothing Then
                If Session("PenalidadBRMS") = "N" Then
                    hdnRetenidoFidelizado.Value = "Fidelizado"
                End If
            End If
                'fin gaa20170725
            For Each item As ItemGenerico In arrListaProducto

                Dim strCadenaSEC As String
                Dim arrPlanGrabar As New ArrayList
                blnGrabarMovil = False
                Dim dblAlquiler As Double = 0.0
                Dim dblInstalacion As Double = 0.0
                Dim dblCFTotal As Double = 0.0
                Dim oGarantia As Renta
                Dim nroPlanesTotal As Integer = 0

                For Each plan As PlanDetalleVenta In arrPlanDetalle

                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "item.Codigo --> " & item.Codigo)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "plan.PRDC_CODIGO --> " & plan.PRDC_CODIGO)
                    If item.Codigo = plan.PRDC_CODIGO Then
                        'gaa20160609
                        If plan.PLANC_CODIGO = ConfigurationSettings.AppSettings("strPlanEmpleadoDatos") Then
                            hidMsgPlanEmpleadoDatos.Value = ConfigurationSettings.AppSettings("strMsgPlanEmpleadoDatos")
                        Else
                            hidMsgPlanEmpleadoDatos.Value = String.Empty
                        End If
                        'fin gaa20160609
                        ' Consultar Garantías x Producto
                        oGarantia = ConsultarRenta(item.Codigo)
                        ' Calcular CF x Producto
                        dblCFTotal = dblCFTotal + plan.CARGO_FIJO_LIN

                        If Not (item.Codigo = CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoDTH")) Or _
                                item.Codigo = CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoHFC"))) Then
                            strPlan = plan.PLANC_CODIGO
                            strPlazoAcuerdo = plan.PACUC_CODIGO
                            arrPlanGrabar.Add(plan)
                            blnGrabarMovil = True
                        Else
                            arrPlanGrabar = New ArrayList
                            arrPlanGrabar.Add(plan)

                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCadSECGeneral --> " & strCadSECGeneral)
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "plan.PACUC_CODIGO --> " & plan.PACUC_CODIGO)
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.codGarantia --> " & CheckStr(oGarantia.codGarantia))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.importe--> " & CheckStr(oGarantia.importe))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.nroRenta --> " & CheckStr(oGarantia.nroRenta))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "dblImporteGrupoSEC --> " & CheckStr(dblImporteGrupoSEC))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "arrPlanDetalle.Count --> " & CheckStr(arrPlanDetalle.Count))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "dblCFTotal --> " & CheckStr(dblCFTotal))
                            strCadenaSEC = String.Format(strCadSECGeneral, item.Codigo, "", plan.PACUC_CODIGO, oGarantia.codGarantia, oGarantia.importe, _
                            oGarantia.nroRenta, arrPlanDetalle.Count, dblCFTotal, "", "0", strNroSECPadre, dblImporteGrupoSEC, dblCFGrupoSEC)

                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CADENA SEC --> " & strCadenaSEC)



                            If item.Codigo = CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoDTH")) Then
                                If Not Session("CambioTitularidadDTH") = "1" Then
                                    oConsumer.ObtenerAlqInstalKIT(plan.MATERIAL, plan.CAMPANA, plan.PACUC_CODIGO, dblAlquiler, dblInstalacion)
                                End If
                                strCadenaSEC &= String.Format(DatosEvalPersonaSGA(), plan.CAMPANA, dblInstalacion, dblAlquiler)
                                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CADENA SEC1 --> " & strCadenaSEC)
                            Else
                                strCadenaSEC &= String.Format(DatosEvalPersonaSGA(), "", 0, 0)
                                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CADENA SEC2 --> " & strCadenaSEC)
                            End If

                            'GRABAR SEC
                            strNroSEC = GrabarPersona(strCadenaSEC, item.Codigo, vista, Nothing, arrPlanGrabar)
                            Dim oDireccion As DireccionCliente = DatosDireccion(item.Codigo, plan.SOPLN_ORDEN)
                            Dim blnOK As Boolean = (New SolicitudNegocios).InsertarSolDireccion(oDireccion, CheckInt64(strNroSEC))
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "NRO DE SEC --> " & strNroSEC)
                            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "INSERTA DIRECCION OK --> " & CheckStr(blnOK))

                            If Not blnSECPadre Then
                                blnSECPadre = True
                                strNroSECPadre = strNroSEC
                            End If

                            dblCFTotal = 0.0
                        End If
                    End If
                Next

                If blnGrabarMovil Then

                    'consolidado 21012015
                    hidcodGarantia.Value = CheckStr(oGarantia.codGarantia)
                    'consolidado 21012015

                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCadSECGeneral --> " & strCadSECGeneral)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "item.Codigo --> " & item.Codigo)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strPlan --> " & strPlan)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strPlazoAcuerdo --> " & strPlazoAcuerdo)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.codGarantia --> " & CheckStr(oGarantia.codGarantia))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.importe --> " & CheckStr(oGarantia.importe))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oGarantia.nroRenta --> " & CheckStr(oGarantia.nroRenta))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "arrPlanDetalle.Count --> " & CheckStr(arrPlanDetalle.Count))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "dblCFTotal --> " & CheckStr(dblCFTotal))

                    strCadenaSEC = String.Format(strCadSECGeneral, item.Codigo, strPlan, strPlazoAcuerdo, oGarantia.codGarantia, oGarantia.importe, oGarantia.nroRenta, _
                    arrPlanDetalle.Count, dblCFTotal, "", "0", strNroSECPadre, dblImporteGrupoSEC, dblCFGrupoSEC)


                    '//PROY 31636 RENTESEG
                    Dim nacionalidad As String = hidNacSeleccionado.Value
                    If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                        strCadenaSEC+=""&";"&""
                    Else
                            Dim strDescNAc() As String = nacionalidad.Split(";")
                            strCadenaSEC += strDescNAc(0) & ";" & strDescNAc(1)
                    End If
                    '//PROY 31636 RENTESEG

                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CADENA SEC --> " & strCadenaSEC)

                    'GRABAR SEC
                    strNroSEC = GrabarPersona(strCadenaSEC, item.Codigo, vista, Nothing, arrPlanGrabar)
                    If Not blnSECPadre Then
                        blnSECPadre = True
                        strNroSECPadre = strNroSEC
                        HidSecGra.Value = "0"     'PROY-24724-IDEA-28174
                    End If
                End If
            Next

            hidNroSEC.Value = strNroSECPadre
         
            Session("aux_strNroSECPadre") = strNroSECPadre
			oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & "- " & "aux_strNroSECPadre: " & Funciones.CheckStr(Session("aux_strNroSECPadre")))
            strMensajeSEC = String.Format(MensajeSEC(), strNroSECPadre)
            Session("EvaluarIngreso") = Nothing
            'gaa20160314 - MRAF
            Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
            Dim objSolicitudNegocio As New SolicitudNegocios
            If Not Session("TipoOperacionBRMS") Is Nothing Then
            objSolicitudNegocio.InsertarTipoOperacionBRMS(strNroSECPadre, Session("TipoOperacionBRMS"), Session("PenalidadBRMS"), Double.Parse(hidReintegro.Value), dblIgv)
            End If
            'fin gaa20160314

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "NRO SEC --> " & strMensajeSEC)

        Catch ex As Exception
            hidCodError.Value = "1"
            Session("EvaluarIngreso") = Nothing
            strMensajeSEC = "Ocurrió un error al registrar la Solicitud."
            If CheckStr(ex.Message).IndexOf("-20662") <> -1 Then
                strMensajeSEC = ConfigurationSettings.AppSettings("constMsjErrorClienteTieneSEC")
            End If
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR  --> Grabar : " & ex.Message)
        Finally
            hidMensaje.Value = strMensajeSEC
        End Try
    End Sub

    Private Sub GrabarEvaluacionRUC()
        Dim strNroSEC As String
        Dim strNroSECPadre As String = "0"
        Dim blnGrabarMovil As Boolean = False
        Dim blnSECPadre As Boolean = False
        Dim strPlazoAcuerdo As String
        Dim strMensajeSEC As String
        Try
            Dim oEmpresa As SolicitudEmpresa = DatosEvalEmpresa()
            Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
            Dim arrListaProducto As ArrayList = (New ConsumerNegocio).ListarProducto()
            Dim dblImporteGrupoSEC As Double = ConsultarImporteTotal()
            Dim dblCFGrupoSEC As Double = ConsultarCFTotal(arrPlanDetalle)
            'gaa20170725:Modificado para que cuando brms indique no cobrar muestre fidelizado
            If Not Session("PenalidadBRMS") Is Nothing Then
                If Session("PenalidadBRMS") = "N" Then
                    hdnRetenidoFidelizado.Value = "Fidelizado"
                End If
            End If
            'fin gaa20170725
            For Each item As ItemGenerico In arrListaProducto
                Dim arrPlanGrabar As New ArrayList
                blnGrabarMovil = False
                Dim dblCFTotal As Double = 0.0
                Dim oGarantia As Renta

                For Each plan As PlanDetalleVenta In arrPlanDetalle
                    If item.Codigo = plan.PRDC_CODIGO Then
                        ' Consultar Garantías x Producto
                        oGarantia = ConsultarRenta(item.Codigo)
                        ' Calcular CF x Producto
                        dblCFTotal = dblCFTotal + plan.CARGO_FIJO_LIN

                        If Not (item.Codigo = ConfigurationSettings.AppSettings("CodTipoProductoDTH") Or item.Codigo = ConfigurationSettings.AppSettings("CodTipoProductoHFC")) Then
                            strPlazoAcuerdo = plan.PACUC_CODIGO
                            arrPlanGrabar.Add(plan)
                            blnGrabarMovil = True
                        End If
                    End If
                Next

                If blnGrabarMovil Then

                    oEmpresa.TPREC_CODIGO = item.Codigo
                    oEmpresa.PRDC_CODIGO = item.Codigo
                    oEmpresa.PACUC_CODIGO = strPlazoAcuerdo
                    oEmpresa.SOLIN_NUM_CAR_FIJ = oGarantia.nroRenta
                    oEmpresa.SOLIC_TIP_CAR_MAN = oGarantia.codGarantia
                    oEmpresa.SOLIC_TIP_CAR_FIJ = oGarantia.codGarantia
                    oEmpresa.SOLIN_IMP_DG = oGarantia.importe
                    oEmpresa.SOLIN_IMP_DG_MAN = oGarantia.importe
                    oEmpresa.SOLIN_CAN_LIN = arrPlanDetalle.Count
                    oEmpresa.SOLIN_GRUPO_SEC = strNroSECPadre

                    oEmpresa.SOLIN_NUM_CAR_FIJ_LINEA = dblCFTotal
                    oEmpresa.SOLIN_LIM_CRE_FIN = dblCFTotal * CheckDbl(hidFactorLC.Value)
                    oEmpresa.SOLIN_SUM_CAR_CON = dblCFTotal
                    oEmpresa.SOLIN_SUM_CAR_FIN = dblCFTotal
                    oEmpresa.SOLIN_IMP_DG_GRUPO_SEC = dblImporteGrupoSEC
                    oEmpresa.SOLIN_CF_GRUPO_SEC = dblCFGrupoSEC

                    'GRABAR SEC
                    strNroSEC = GrabarEmpresa(arrPlanGrabar, oEmpresa)
                    If Not blnSECPadre Then
                        blnSECPadre = True
                        strNroSECPadre = strNroSEC
                        HidSecGra.Value = "0"     'PROY-24724-IDEA-28174
                    End If
                End If
            Next

            hidNroSEC.Value = strNroSECPadre
      
            Session("aux_strNroSECPadre") = strNroSECPadre
			oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & "- " & "aux_strNroSECPadre: " & Funciones.CheckStr(Session("aux_strNroSECPadre")))
            strMensajeSEC = String.Format(MensajeSEC(), strNroSECPadre)
            Session("EvaluarIngreso") = Nothing
            'gaa20160314 - MRAF
            Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
            Dim objSolicitudNegocio As New SolicitudNegocios
            If Not Session("TipoOperacionBRMS") Is Nothing Then
                objSolicitudNegocio.InsertarTipoOperacionBRMS(strNroSECPadre, Session("TipoOperacionBRMS"), Session("PenalidadBRMS"), Double.Parse(hidReintegro.Value), dblIgv)
            End If
            'fin gaa20160314

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "NRO SEC --> " & strMensajeSEC)

        Catch ex As Exception
            Session("EvaluarIngreso") = Nothing
            hidCodError.Value = "1"
            strMensajeSEC = "Ocurrió un error al registrar la Solicitud."
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR GRABAR: " & ex.Message)
        Finally
            hidMensaje.Value = strMensajeSEC
        End Try

    End Sub

#Region "Funciones Grabar"

    Private Function DatosEvalPersona(ByRef vista As Vista_SolicitudDC_Reporte) As String

        Dim DSolicitud As String = ""
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim blnAutonomia As Boolean = (hidAutonomia.Value = "S")
        Dim blnIrCreditos As Boolean = False
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxDC7.Value = "S"))
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxCE.Value = "S"))
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxNombres.Value = "S"))
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxAsesor.Value = "S"))

        Dim blnAdjuntarIngreso As Boolean = (hidAdjuntarIngreso.Value = "S")
        Dim blnPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")

            Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
            Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
            Dim strDesOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(1)
            Dim strTipoOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(2)

            Dim strTipoProducto As String = "{0}"
            Dim strCodEvaluador As String = CurrentUser()
            Dim strCodAnalista As String = ConfigurationSettings.AppSettings("constResultadoCodigoAnalista")
            Dim strCodTipoDocumento As String = Right("00" & hidTipoDocumento.Value, 2)
            Dim strNroDocumento As String = Right("00000000000000" & nroDocumento, 16)
            Dim strCodOferta As String = hidTipoOferta.Value 'ddlOferta.SelectedValue
            Dim strCodCasoEspecial As String = hidCasoEspecial.Value.Split("_")(0)

            Dim strCodSegmento As String
            If (strCodOferta = constTipoProductoCON Or strCodOferta = constTipoProductoB2E) Then
                strCodSegmento = constSegmentoCON
            Else
                strCodSegmento = constSegmentoECA
                If strCodOferta = constTipoProductoBUS Then
                    If strTipoOficina = ConfigurationSettings.AppSettings("constCodTipoOficinaCAC") Then
                        strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBD")
                    Else
                        strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBI")
                    End If
                Else
                    strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBD")
                End If
            End If

            Dim strCodTipoVenta As String = ConfigurationSettings.AppSettings("strTVPostpago")
            Dim strCodTipoCliente As String = ConfigurationSettings.AppSettings("constTipoClienteNAT")
            Dim strCodTipoActivacion As String = ConfigurationSettings.AppSettings("constCodTipoActivacionDIF") 'ConfigurationSettings.AppSettings("SISACT_TipoActivacion_Inmediata")
            Dim strCodTipoOperacion As String = ConfigurationSettings.AppSettings("constTipoOperacionATN")

            'Agregado en caso no tenga kit, se asignara tipo operacion transferencia para no ser listado en venta express
            If Session("CambioTitularidadDTH") = "1" Then
                strCodTipoOperacion = ConfigurationSettings.AppSettings("constTipoOperacionTRA")
            Else
                strCodTipoOperacion = hidTipoOperacion.Value
            End If

            Dim strCodFormaPago As String = ConfigurationSettings.AppSettings("SISACT_FormaPago_Efectivo")
            Dim strCodResultadoFinal As String = ConfigurationSettings.AppSettings("constCodResultadoFinalAPR")

            Dim strExisteBSCS As String = "0"
            If CheckStr(hidClienteClaro.Value) = "S" Then
                strExisteBSCS = "1"
            End If

            Dim strCodPlan1 As String = "{1}"
            Dim strCodPlan2 As String = ""
            Dim strCodPlan3 As String = ""
            Dim strCodPlazo As String = "{2}"

            'RESULTADO DE EVALUACION
            Dim strCodTipoGarantiaCreditos As String = "{3}"
            Dim strCodTipoGarantia As String = "{3}"
            Dim strImporte As String = "{4}"
            Dim strImporteCreditos As String = "{4}"

            Dim strCantidadCF As String = "{5}"
            Dim strCantidadLineas As String = "{6}"
            Dim strSumaPlanes As String = "{7}" 'TOTAL CF
            Dim strTelefonoSMS As String = "{8}"
            Dim strSECAsociada As String = "{9}"
            Dim strSECPadre As String = "{10}"
            Dim strImporteTotal As String = "{11}"  'IMPORTE GRUPO SEC
            Dim strCFTotal As String = "{12}"       'CARGO FIJO GRUPO SEC

            Dim strControlConsumo As String = "0"
            Dim strNroSECAnterior As String = CheckStr(hidNroSEC.Value)

            Dim strCodEstado As String = constEstadoAPR
            Dim strDesEstado As String = constDesEstadoAPR

            If hidTipoOperacion.Value = ConfigurationSettings.AppSettings("constTipoOperacionMIG") Then
                strCodEstado = constEstadoAPRENVACT
                strDesEstado = constDesEstadoAPRENVACT
            End If

            'VALIDACION ESTADO SEC
            If blnAutonomia Then
                If blnPortabilidad Then
                    strCodEstado = constEstadoENVPOOLEMIT
                    strDesEstado = constDesEstadoENVPOOLEMIT
                End If
            Else
                strCodEstado = constEstadoEnvCreditos
                strDesEstado = constDesEstadoEnvCreditos
            End If

            If blnIrCreditos Then
                strCodEstado = constEstadoEnvCreditos
                strDesEstado = constDesEstadoEnvCreditos
            End If

            If blnAdjuntarIngreso Then
                strCodEstado = constEstadoPENDADJARCH
                strDesEstado = constDesEstadoPENDADJARCH
            End If
            hidCodEstadoSEC.Value = strCodEstado

            Dim strCodTipoEvaluador As String = constCodEvaluadorPDV
            If Not strCodCanal = constCodCodCanalDefectoMT Then
                strCodTipoEvaluador = constCodEvaluadorCET
            End If

            Dim strFlagTerminado As String = "N"
            Dim strDesResultadoFinal As String = ""
            Dim strDesTipoActivacion As String = ConfigurationSettings.AppSettings("constDesTipoActivacionDIF")
            Dim strComentarioPDV As String = CheckStr(hidComentarioPDV.Value)
            Dim strComentarioEvaluacion As String = ""
            Dim strCodUsuario As String = CurrentUser()

            Dim strNombreCliente As String = CheckStr(hidNombre.Value).ToUpper
            Dim strAPaternoCliente As String = CheckStr(hidApePaterno.Value).ToUpper
            Dim strAMaternoCliente As String = CheckStr(hidApeMaterno.Value).ToUpper

            Dim strRUCEmpleador As String = ""
            Dim strNombreEmpresa As String = ""

            'DATOS DATACREDITO
            '--------------------
            Dim strDatosDC As String = hidDatosDC.Value
            Dim strResultado As String = ""
            Dim strLineaCredito As String = ""
            Dim strNroOperacion As String = ""
            Dim strTipoClienteDC As String = ""
            Dim strLetraScoreCrediticio As String = ""
            Dim strNumScoreCrediticio As String = ""
            Dim strOrigen_Lc_DC As String = ""
            Dim strANALISIS_DC As String = ""
            Dim strSCORE_RANKING_OPER_DC As String = ""
            Dim strPUNTAJE_DC As String = ""
            Dim strLC_DATA_CREDITO_DC As String = ""
            Dim strLC_BASE_EXTERNA_DC As String = ""
            Dim strLC_CLARO_DC As String = ""
            Dim strRazonesDC As String = ""
            Dim strFechaNacimiento As String = ""
            Dim strBuro As String = ""
            Dim strFactRenovacion As String = String.Empty

            If Not strDatosDC.Equals(String.Empty) Then
                Dim arrDatosDC As String() = strDatosDC.Split("?")

                strResultado = CheckStr(arrDatosDC(1))
                strLineaCredito = CheckStr(CheckDbl(arrDatosDC(2)))
                strNroOperacion = CheckStr(arrDatosDC(4))
                strTipoClienteDC = CheckStr(arrDatosDC(5))
                strLetraScoreCrediticio = CheckStr(arrDatosDC(8))
                strNumScoreCrediticio = CheckStr(arrDatosDC(9))
                strOrigen_Lc_DC = CheckStr(arrDatosDC(17))
                strANALISIS_DC = CheckStr(arrDatosDC(18))
                strSCORE_RANKING_OPER_DC = CheckStr(arrDatosDC(19))
                strPUNTAJE_DC = CheckStr(arrDatosDC(20))
                strLC_DATA_CREDITO_DC = CheckStr(arrDatosDC(21))
                strLC_BASE_EXTERNA_DC = CheckStr(arrDatosDC(22))
                strLC_CLARO_DC = CheckStr(CheckDbl(arrDatosDC(23)))
                strRazonesDC = CheckStr(arrDatosDC(24))
                If Not arrDatosDC(25).Equals(String.Empty) Then
                    strFechaNacimiento = CType(CheckStr(arrDatosDC(25)), Date)
                End If
                strBuro = CheckStr(arrDatosDC(26))
            Else
                strFechaNacimiento = CType(CheckStr(hidFechaNac.Value), Date)
            End If
        'gaa20170329
            If CheckStr(strBuro) = "" Then
            'strBuro = ConfigurationSettings.AppSettings("constCodBuroDataCreditoDNI")
            strBuro = ConfigurationSettings.AppSettings("constCodBuroVacio")
            End If
            'EXTRA DATACREDITO
            If strPUNTAJE_DC = "" Then strPUNTAJE_DC = "0"
            Dim strREGLAS_DURAS_DC As String = String.Empty
            Dim strALERTA_COMPORTAMIENTO_DC As String = String.Empty
            Dim strALERTAS_DC As String = String.Empty
            Dim strCORRESPONDENCIA_SALDO_DC As String = String.Empty
            Dim strRAZONES_NODOS As String = String.Empty
            If strRazonesDC.Length >= 5 Then
                Try
                    If strRazonesDC.Substring(0, 1) <> "V" Then
                        strREGLAS_DURAS_DC = strRazonesDC.Substring(0, 1)
                        strALERTA_COMPORTAMIENTO_DC = strRazonesDC.Substring(1, 1)
                        strALERTAS_DC = strRazonesDC.Substring(2, 1)
                        strCORRESPONDENCIA_SALDO_DC = strRazonesDC.Substring(3, 1)
                    End If
                    strRAZONES_NODOS = strRazonesDC.Substring(5)
                Catch ex As Exception
                End Try
            End If

            'VALIDACION ESSALUD - SUNAT
            Dim strValidacionEssalud As String
            Dim strValidacionSunat As String
            If (CheckInt(strTipoClienteDC) And DataCreditoOUT.TIPO_CLIENTE.SUNAT) <> 0 Then
                strValidacionSunat = "P"
            Else
                strValidacionSunat = "N"
            End If
            If (CheckInt(strTipoClienteDC) And DataCreditoOUT.TIPO_CLIENTE.ESSALUD) <> 0 Then
                strValidacionEssalud = "P"
            Else
                strValidacionEssalud = "N"
            End If

            Dim strCodResultadoDir As String = ConfigurationSettings.AppSettings("constResultadoDireccionPostVenta")
            Dim strDesResultadoDir As String = ConfigurationSettings.AppSettings("constDesResDireccionPostVenta")
            Dim strTipoCaractCliente As String = ""
            Dim strFlagInfocorp As String = "1"
            Dim strMensajeExplicacion As String = ""
            Dim strCampanna As String = ""
            Dim strIdVendedor As String = ""
            Dim strFlagCorreo As String = ""
            Dim strCorreo As String = ""
            Dim strEstadoCivil As String = ConfigurationSettings.AppSettings("ConstEstadoCivilSoltero")
            Dim strDistrito As String = ConfigurationSettings.AppSettings("ConstUbigeoLima")

            Dim fechaNacPdv As Date = CType("01/01/1900", Date)

            strFactRenovacion = String.Format("{0:#,#,#,0.00}", CheckSng(hidFactorRenovacion.Value))

            DSolicitud = DSolicitud & strCodOficina & ";"
            DSolicitud = DSolicitud & strCodCanal & ";"
            DSolicitud = DSolicitud & strCodEvaluador & ";"
            DSolicitud = DSolicitud & strExisteBSCS & ";"
            DSolicitud = DSolicitud & strCodAnalista & ";"
            DSolicitud = DSolicitud & strCodTipoDocumento & ";"
            DSolicitud = DSolicitud & strNroDocumento & ";"
            DSolicitud = DSolicitud & String.Empty & ";"
            DSolicitud = DSolicitud & String.Empty & ";"
            DSolicitud = DSolicitud & strCodOferta & ";"
            DSolicitud = DSolicitud & strCodSegmento & ";"
            DSolicitud = DSolicitud & strCodTipoCliente & ";"
            DSolicitud = DSolicitud & strCodTipoVenta & ";"
            DSolicitud = DSolicitud & strCodTipoActivacion & ";"
            DSolicitud = DSolicitud & strCodTipoOperacion & ";"
            DSolicitud = DSolicitud & strCodPlan1 & ";"
            DSolicitud = DSolicitud & strCodPlan2 & ";"
            DSolicitud = DSolicitud & strCodPlan3 & ";"
            DSolicitud = DSolicitud & strCodPlazo & ";"
            DSolicitud = DSolicitud & strCodFormaPago & ";"
            DSolicitud = DSolicitud & strCantidadLineas & ";"
            DSolicitud = DSolicitud & ";"
            DSolicitud = DSolicitud & strCodResultadoFinal & ";"
            DSolicitud = DSolicitud & strCodTipoGarantiaCreditos & ";"
            DSolicitud = DSolicitud & strImporteCreditos & ";"
            DSolicitud = DSolicitud & strCodEstado & ";"
            DSolicitud = DSolicitud & strCodTipoEvaluador & ";"
            DSolicitud = DSolicitud & strFlagTerminado & ";"
            DSolicitud = DSolicitud & strDesEstado & ";"
            DSolicitud = DSolicitud & Left(strDesOficina, 20) & ";"
            DSolicitud = DSolicitud & strDesResultadoFinal & ";"
            DSolicitud = DSolicitud & strDesTipoActivacion & ";"
            DSolicitud = DSolicitud & strComentarioPDV & ";"
            DSolicitud = DSolicitud & strComentarioEvaluacion & ";"
            DSolicitud = DSolicitud & strCodUsuario & ";"
            DSolicitud = DSolicitud & strNombreCliente & ";"
            DSolicitud = DSolicitud & strAPaternoCliente & ";"
            DSolicitud = DSolicitud & strAMaternoCliente & ";"
            DSolicitud = DSolicitud & strValidacionEssalud & ";"
            DSolicitud = DSolicitud & strValidacionSunat & ";"
            DSolicitud = DSolicitud & strCodResultadoDir & ";"
            DSolicitud = DSolicitud & strDesResultadoDir & ";"
            DSolicitud = DSolicitud & strTipoCaractCliente & ";"
            DSolicitud = DSolicitud & strCodTipoGarantia & ";"
            DSolicitud = DSolicitud & strImporte & ";"
            DSolicitud = DSolicitud & strResultado & ";"
            DSolicitud = DSolicitud & strNroOperacion & ";"
            DSolicitud = DSolicitud & IIf(Trim(strLineaCredito) = String.Empty, "0", strLineaCredito) & ";"
            DSolicitud = DSolicitud & strSumaPlanes & ";"
            DSolicitud = DSolicitud & strCantidadCF & ";"
            DSolicitud = DSolicitud & strCodCasoEspecial & ";"
            DSolicitud = DSolicitud & strLetraScoreCrediticio & ";"
            DSolicitud = DSolicitud & strNumScoreCrediticio & ";"

            If Not blnPortabilidad Then
                DSolicitud = DSolicitud & strNroSECAnterior & ";"
            End If

            DSolicitud = DSolicitud & strFlagInfocorp & ";"
            DSolicitud = DSolicitud & strMensajeExplicacion & ";"
            DSolicitud = DSolicitud & strRUCEmpleador & ";"
            DSolicitud = DSolicitud & strNombreEmpresa & ";"
            DSolicitud = DSolicitud & strCampanna & ";"
            DSolicitud = DSolicitud & strExisteBSCS & ";"
            DSolicitud = DSolicitud & strIdVendedor & ";"
            DSolicitud = DSolicitud & strControlConsumo & ";"

            'Portabilidad
            If blnPortabilidad Then
                DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("FlagPortabilidad") & ";"
                DSolicitud = DSolicitud & hidOperadorCedente.Value & ";"
                DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constEstadoEmitidoPortabilidad") & ";"
                DSolicitud = DSolicitud & hidNumeroContacto.Value & ";"
                DSolicitud = DSolicitud & "0" & ";" 'No hay operador cedente segun PS
                DSolicitud = DSolicitud & "0" & ";" 'No hay operador cedente segun PS
                DSolicitud = DSolicitud & hidNumeroFolio.Value & ";"
            End If

            DSolicitud = DSolicitud & strFlagCorreo & ";"
            DSolicitud = DSolicitud & strCorreo & ";"

            If blnPortabilidad Then
                DSolicitud = DSolicitud & strTelefonoSMS & ";"
            End If

            DSolicitud = DSolicitud & strEstadoCivil & ";"
            DSolicitud = DSolicitud & strDistrito & ";"
            DSolicitud = DSolicitud & strOrigen_Lc_DC & ";"
            DSolicitud = DSolicitud & strANALISIS_DC & ";"
            DSolicitud = DSolicitud & strSCORE_RANKING_OPER_DC & ";"
            DSolicitud = DSolicitud & strPUNTAJE_DC & ";"
            DSolicitud = DSolicitud & IIf(strLC_DATA_CREDITO_DC = String.Empty, "0", strLC_DATA_CREDITO_DC) & ";"
            DSolicitud = DSolicitud & IIf(Trim(strLC_BASE_EXTERNA_DC) = String.Empty, "0", strLC_BASE_EXTERNA_DC) & ";"
            DSolicitud = DSolicitud & IIf(Trim(strLC_CLARO_DC) = String.Empty, "0", strLC_CLARO_DC) & ";"
            DSolicitud = DSolicitud & strREGLAS_DURAS_DC & ";"
            DSolicitud = DSolicitud & strALERTA_COMPORTAMIENTO_DC & ";"
            DSolicitud = DSolicitud & strALERTAS_DC & ";"
            DSolicitud = DSolicitud & strCORRESPONDENCIA_SALDO_DC & ";"
            DSolicitud = DSolicitud & strFechaNacimiento & ";"

            If Not blnPortabilidad Then
                DSolicitud = DSolicitud & fechaNacPdv & ";"
            End If

            DSolicitud = DSolicitud & CheckDbl(hidLCDisponible.Value) & ";"
            DSolicitud = DSolicitud & oClienteCuenta.CF_Menor & ";"
            DSolicitud = DSolicitud & oClienteCuenta.CF_Mayor & ";"

            If Not blnPortabilidad Then
                DSolicitud = DSolicitud & CheckDbl(oClienteCuenta.deudaVencida) & ";"
                DSolicitud = DSolicitud & IIf(oClienteCuenta.nroBloqueo > 0, "1", "0") & ";"
                DSolicitud = DSolicitud & strSECAsociada & ";"
                DSolicitud = DSolicitud & hidRespuestaDC.Value & ";"
                DSolicitud = DSolicitud & strTipoProducto & ";"
            End If

            DSolicitud = DSolicitud & strSECPadre & ";"

            'Mejoras Fase 1
            'Calificacion Pago 
            Dim calificacionPago As String = hidCalificacionPago.Value

            DSolicitud = DSolicitud & calificacionPago & ";"
            DSolicitud = DSolicitud & strBuro & ";"
            DSolicitud = DSolicitud & strImporteTotal & ";"
            DSolicitud = DSolicitud & strCFTotal & ";"
            DSolicitud = DSolicitud & strFactRenovacion & ";"
            '---------------------------------------------------

            'BRMS
            DSolicitud = DSolicitud & hidRiesgoClaro.Value & ";"
        'INC000000882268 - INICIO
        For Each oOfrecimiento As Ofrecimiento In oClienteOfrecimiento
            DSolicitud = DSolicitud & oOfrecimiento.ComportamientoConsolidado & ";"
            Exit For
        Next
        'INC000000882268 - FIN


            oLog.Log_WriteLog(strArchivo, nroDocumento & " - " & "DSolicitud : " & DSolicitud)

            'REPORTE DC
            vista.DCREV_NUM_OPERACION = strNroOperacion
            vista.DCREV_OVEN_CODIGO = strCodOficina
            vista.DCREN_USUARIO_REG = CurrentUser
            vista.DCREC_TIPO_DOCUMENTO = strCodTipoDocumento
            vista.DCREV_NUM_DOCUMENTO = nroDocumento
            vista.DCREV_APELLIDO_PAT = strAPaternoCliente
            vista.DCREV_APELLIDO_MAT = strAMaternoCliente
            vista.DCREV_NOMBRE = strNombreCliente
            vista.DCREN_CANT_INTENTOS = CheckInt(hidIntentos10.Value)
            vista.DCREC_VALIDAR_CLIENTE = "X"

        Return DSolicitud
    End Function

    Private Function DatosEvalPersonaSGA() As String
        Dim DSolicitud As String
        DSolicitud = DSolicitud & "0" & ";"     'FLAG_VTA_PROACTIVA
        DSolicitud = DSolicitud & "{0}" & ";"   'P_CAMPV_CODIGO
        DSolicitud = DSolicitud & "" & ";"      'P_CLIEC_VEN_DNI
        DSolicitud = DSolicitud & "{1}" & ";"   'P_SOLIN_KIT_COS_INST
        DSolicitud = DSolicitud & "" & ";"      'P_CLIEC_BLOQUEO
        DSolicitud = DSolicitud & "" & ";"      'DATO VENTA --> NroCartaPreselecion - P_CLIEV_NRO_CARTA_PRESELEC
        DSolicitud = DSolicitud & "" & ";"      'DATO VENTA --> Operador            - P_CLIEV_OPERADOR
        DSolicitud = DSolicitud & "" & ";"      'DATO VENTA --> PaginasClaro        - P_CLIEV_PAGINA_CLARO
        DSolicitud = DSolicitud & "{2}" & ";"   'ALQUILER KIT                       - P_SOLIN_CF_ALQUILER_KIT

        Return DSolicitud
    End Function

    Private Function DatosEvalEmpresa() As SolicitudEmpresa
        Dim item As New SolicitudEmpresa
        Dim strNroDocumento As String = hidNroDocumento.Value
        Dim blnAutonomia As Boolean = (hidAutonomia.Value = "S")
        Dim blnIrCreditos As Boolean = False
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxCE.Value = "S"))
        blnIrCreditos = (blnIrCreditos Or (hidCreditosxAsesor.Value = "S"))

        Dim blnAdjuntarIngreso As Boolean = (hidAdjuntarIngreso.Value = "S")
        Dim blnPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")

            Dim objConsumer As New ConsumerNegocio
            Dim strFlagCorreo As String, strCorreo As String

            Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
            Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
            Dim strDesOficina As String = Mid(CheckStr(hidOficinaActual.Value).Split(",")(1), 1, 20)
            Dim strTipoOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
            Dim strCodTipoDocumento As String = Right("00" & hidTipoDocumento.Value, 2)
            Dim strCodOferta As String = hidTipoOferta.Value 'ddlOferta.SelectedValue
            Dim strCodPlazoAcuerdo As String '= CheckStr(hidPlazoActual.Value).Split("_")(0)    //PENDIENTE

            If strCodOferta = ConfigurationSettings.AppSettings("constTipoProductoBUS") Then
                If strCodCanal = ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT") Then
                    strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBD")
                Else
                    strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBI")
                End If
            End If

            'VALIDACION ESTADO SEC
            If blnAutonomia Then
                item.SOLIV_FLAG_ENVIO = "1"
                item.ESTAC_CODIGO = ConfigurationSettings.AppSettings("constEstadoAPR")
                item.SOLIV_DES_RES_FIN = ConfigurationSettings.AppSettings("constDesResultadoFinalAPR")
                item.SOLIV_COM_DG = ConfigurationSettings.AppSettings("constTextoAprobadoAutonomia")
            Else
                item.SOLIV_FLAG_ENVIO = "2"
                item.ESTAC_CODIGO = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS")
                item.SOLIV_DES_RES_FIN = ConfigurationSettings.AppSettings("constdesEstadoSECPENDADJARCHIVOS")
                item.SOLIV_COM_DG = ConfigurationSettings.AppSettings("constTextoNoAprobadoAutonomia")
            End If

            If blnPortabilidad Then
                item.ESTAC_CODIGO = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS")
                item.SOLIV_DES_RES_FIN = ConfigurationSettings.AppSettings("constdesEstadoSECPENDADJARCHIVOS")
            End If

            'Enviar a Creditos
            If blnIrCreditos Then
                item.SOLIV_FLAG_ENVIO = "2"
                item.ESTAC_CODIGO = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS")
                item.SOLIV_DES_RES_FIN = ConfigurationSettings.AppSettings("constdesEstadoSECPENDADJARCHIVOS")
                item.SOLIV_COM_DG = ConfigurationSettings.AppSettings("constTextoNoAprobadoAutonomia")
            End If

            hidCodEstadoSEC.Value = item.ESTAC_CODIGO

            item.OVENC_CODIGO = strCodOficina
            item.CANAC_CODIGO = strCodCanal

            item.ANEXO2 = ""
            item.ANALC_CODIGO = ConfigurationSettings.AppSettings("constCodAnalista")
            item.TDOCC_CODIGO = strCodTipoDocumento
            item.CLIEC_NUM_DOC = strNroDocumento
            item.CLIEV_RAZ_SOC = Mid(CheckStr(hidRazonSocial.Value), 1, 40)

            'CLASIFICACION TOP - NO TOP
            item.CLASC_CODIGO = ConfigurationSettings.AppSettings("constCodClasificacionEmpresaNoTop")
            If CheckStr(hidTop.Value) = "S" Then
                item.CLASC_CODIGO = ConfigurationSettings.AppSettings("constCodClasificacionEmpresaTop")
            End If
            item.SOLIN_CAR_FIJO_ACTUAL = 0                              'CF ACTUAL BSCS
            item.SOLIC_EXI_BSC_FIN = "0"                                'DATOS DE BSCS
            If CheckStr(hidClienteClaro.Value) = "S" Then
                item.SOLIC_EXI_BSC_FIN = "1"
            End If
            item.SOLIN_CAN_LIN_EXCOMP = CheckInt(IIf(hidNroLineas.Value = String.Empty, "0", hidNroLineas.Value)) 'LINEAS ACTIVAS BSCS
            item.SOLIN_LINEA_CLIENTE = CheckInt(hidNroLineas.Value)     'LINEAS ACTIVAS BSCS
            Dim iIdTipoCliente As Integer = "1"                         'BSCS '1: NUEVO - 2: RECURRENTE
            If CheckStr(hidClienteClaro.Value) = "S" Then
                iIdTipoCliente = 2
            End If

            item.NRO_LINEAS_MAYOR_N_DIAS = oClienteCuenta.nroLineasMayor
            item.NRO_LINEAS_MENOR_N_DIAS = oClienteCuenta.nroLineasMenor
            item.DIAS_LINEAS_RECURRENTE = 0
            item.NRO_LINEAS_RECURRENTE_ACTUAL = CheckInt(IIf(hidNroLineas.Value = String.Empty, "0", hidNroLineas.Value))

            item.SOLIN_SUBSIDIO_TOTAL = 0
            item.CLIEN_PROM_VEN = 0
            item.SEGMN_CODIGO = CheckInt(ConfigurationSettings.AppSettings("constCodSegmentoBUS"))
            item.TCLIC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoClientePRI")
            item.TACTC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoActivacionINM")
            item.RFINC_CODIGO = ConfigurationSettings.AppSettings("constCodResultadoFinalAPR")
            item.SOLIC_FLA_TER = "N"

            item.SOLIN_DEUDA_CLIENTE = CheckDbl(hidDeudaFinancieraDC.Value)
            item.SOLIV_DES_OFI_VEN = strDesOficina
            item.SOLIV_DES_TIP_ACT = ConfigurationSettings.AppSettings("constDesTipoActivacionINM")
            item.SOLIC_USU_CRE = CurrentUser
            item.USUAN_CODIGO = 0
            item.FLEXN_CODIGO = 0
            item.SOLIV_NUM_OPE_CON = hidNroOperacionDC.Value
            item.TRIEC_CODIGO = hidRiesgoDC.Value

            'CALCULO LINEA DE CREDITO
            Dim iIdSegmento As Integer = CheckInt(item.CLASC_CODIGO)
            Dim iIdRiesgo As Integer = CheckInt(item.TRIEC_CODIGO)
            Dim dDeudaFinanciera As Double = CheckDbl(hidDeudaFinancieraDC.Value)
            Dim dLineaCredito As Double = CheckDbl(objConsumer.CalcularLineaCreditoDescentralizado(iIdTipoCliente, iIdSegmento, iIdRiesgo, dDeudaFinanciera))
            item.SOLIN_LINEA_CREDITO_CALC = dLineaCredito

            item.OPERC_CODIGO = ""
            item.CONSULTOR_ID = 0
            item.SOLIN_ANTIGUEDAD = 0
            item.SOLIC_FLAG_EMPRESA_TRAFICO = 0
            item.FLAG_RESPONSABLE_PUNTO_VENTA = ""
            item.SOLIC_FLAG_EMPRESA_TOLERAN = ""

            'Representante Legal
            Dim arrListaRepresentante As New ArrayList
            Dim cadenaRepresentanteLegal As String = hidListaRepresentante.Value
            If CheckStr(hidListaRepresentante.Value) <> "" Then
                Dim arrRepresentanteLegal() As String = CheckStr(hidListaRepresentante.Value).Split("|"c)
                For Each representantes As String In arrRepresentanteLegal
                    Dim arregloDatos() As String = representantes.Split(";"c)
                    Dim oRepresentanteLegal As New RepresentanteLegal
                    oRepresentanteLegal.CLIEC_NUM_DOC = item.CLIEC_NUM_DOC
                    oRepresentanteLegal.APODC_TIP_DOC_REP = arregloDatos(0)
                    oRepresentanteLegal.APODV_NUM_DOC_REP = arregloDatos(1)
                    oRepresentanteLegal.APODV_NOM_REP_LEG = arregloDatos(2)
                    oRepresentanteLegal.APODV_APA_REP_LEG = arregloDatos(3)
                    oRepresentanteLegal.APODV_AMA_REP_LEG = arregloDatos(4)
                    oRepresentanteLegal.APODV_CAR_REP = arregloDatos(5)
                oRepresentanteLegal.P_SRLC_CODNACIONALIDAD = arregloDatos(6) '//PROY 31636 RENTESEG
                oRepresentanteLegal.P_SRLV_DESCNACIONALIDAD = arregloDatos(7) '//PROY 31636 RENTESEG

                    arrListaRepresentante.Add(oRepresentanteLegal)
                Next
            End If

            item.REPRESENTANTE_LEGAL = arrListaRepresentante
            item.SOLIN_CODIGO_PADRE = 0
            item.SOLIC_FLAG_REINGRESO = ""
            item.EMAIL_AUTORIZADO = ""
            item.DPCHN_CODIGO = CheckInt(ConfigurationSettings.AppSettings("ConstCodTipoDespaDescentra"))
            item.TOPEN_CODIGO = CheckInt(ConfigurationSettings.AppSettings("constTipoOperacionRenovacion"))

            item.TOPEN_CODIGO = CheckInt(hidTipoOperacion.Value)

            item.TPROC_CODIGO = strCodOferta
            item.TVENC_CODIGO = ConfigurationSettings.AppSettings("strTVPostpago")
            item.FPAGC_CODIGO = ConfigurationSettings.AppSettings("SISACT_FormaPago_Efectivo")
            item.SOLIN_USU_VEN = CurrentUser
            item.TEVAC_CODIGO = ConfigurationSettings.AppSettings("constCodEvaluadorPDV")

            'item.SOLIN_LIM_CRE_FIN = CheckDbl(CheckDbl(hidCFTotal.Value)) * CheckDbl(hidFactorLC.Value)
            'item.SOLIN_SUM_CAR_CON = CheckDbl(hidCFTotal.Value)
            'item.SOLIN_SUM_CAR_FIN = CheckDbl(hidCFTotal.Value)

            If hidPoderes.Value <> "" Then
                item.RGLPC_PODERES = hidPoderes.Value
            End If

            item.TCESC_CODIGO = hidCasoEspecial.Value
            If blnPortabilidad Then
                item.FLAG_PORTABILIDAD = ConfigurationSettings.AppSettings("FlagPortabilidad")
                item.PORT_OPER_CED = hidOperadorCedente.Value
                item.TLINC_CODIGO_CEDENTE = "0"
                item.PORT_SOLIN_NRO_FORMATO = hidNumeroFolio.Value
                item.PORT_CARGO_FIJO_OPE_CED = "0"
                item.PORT_TELEF_CONT = hidNumeroContacto.Value
                item.PORT_ESTADO = ConfigurationSettings.AppSettings("constcodEstadoEMITIDOPort")
            End If

            'Mejoras Fase 1
            item.BURO_CODIGO = ConfigurationSettings.AppSettings("constCodBuroDataCreditoRUC")
            item.CLIEV_CALIFICACION_PAGO = CheckStr(hidCalificacionPago.Value)

            item.CLIEN_MONTO_VENCIDO = CheckDbl(oClienteCuenta.deudaVencida)
            item.SOLIV_FACTOR_RENOVACION = String.Format("{0:#,#,#,0.00}", CheckSng(hidFactorRenovacion.Value))

            'BRMS
            item.CLIEV_RIESGO_CLARO = hidRiesgoClaro.Value
            item.CLIEV_COMPORTA_PAGO = hidComportamiento.Value

        'INICIO: PROY-20054-IDEA-23849
        Dim oEmpresaExperto As EmpresaExperto = CType(Session("EmpresaExperto"), EmpresaExperto)
        If Not oEmpresaExperto Is Nothing Then
            item.BURO_CODIGO = oEmpresaExperto.buro_consultado
        Else
            item.BURO_CODIGO = Funciones.CheckInt(ConfigurationSettings.AppSettings("constCodBuroVacio"))
        End If
        'FIN: PROY-20054-IDEA-23849

        Return item
    End Function

    Private Function MensajeSEC() As String

        Dim strMensaje As String
        Dim strCodEstado As String = hidCodEstadoSEC.Value
        Dim blnIrCreditosxDC7 As Boolean = (hidCreditosxDC7.Value = "S")
        Dim blnIrCreditosxNombres As Boolean = (hidCreditosxNombres.Value = "S")
        Dim blnIrCreditosxAsesor As Boolean = (hidCreditosxAsesor.Value = "S")
        Dim blnAutonomia As Boolean = (hidAutonomia.Value = "S")
        Dim blnPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")

        If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
            If blnPortabilidad Then
                strMensaje = "Se registró correctamente la Solicitud N° " & "{0}"
            Else
                If strCodEstado = constEstadoAPR Then
                    strMensaje = "Se registró correctamente la Solicitud N° " & "{0}"
                Else
                    strMensaje = "Se registró correctamente la Solicitud N° " & "{0}" & ". Debera adjuntar los documentos de acuerdo a la Politica Vigente."
                End If
            End If
        Else
            'Aprobado => Altas / PreActivacion => Migracion
            If strCodEstado = constEstadoAPR Or strCodEstado = constEstadoAPRENVACT Or strCodEstado = constEstadoENVPOOLEMIT Then
                strMensaje = "Se registró correctamente la Solicitud N° " & "{0}"
            Else
                strMensaje = "La solicitud " & "{0}" & " ingresada no cumple con autonomía, será enviada a Créditos para su evaluación"
                If blnIrCreditosxDC7 Then
                    strMensaje = "La solicitud " & "{0}" & " está siendo enviada a Créditos para la validación del documento de identidad"
                ElseIf blnIrCreditosxNombres Then
                    strMensaje = "La solicitud " & "{0}" & " está siendo enviada a Créditos para la validación y corrección de datos del cliente"
                End If
                If blnIrCreditosxAsesor Then
                    strMensaje = "Se generó la SEC " & "{0}" & " y será enviada a Créditos para la evaluación respectiva"
                End If
            End If
        End If

        Return strMensaje
    End Function

    Private Function DatosMotivo(ByVal strCodEstado As String) As String

        Dim strMotivo As String = ""
    
            Dim blnIrCreditosxDC7 As Boolean = (hidCreditosxDC7.Value = "S")
            Dim blnIrCreditosxNombres As Boolean = (hidCreditosxNombres.Value = "S")
            Dim blnIrCreditosxAsesor As Boolean = (hidCreditosxAsesor.Value = "S")
            Dim blnAutonomia As Boolean = (hidAutonomia.Value = "S")
            Dim blnPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")
            Dim blnIrCreditosxReglas As Boolean = (hidCreditosxReglas.Value = "S")
            Dim blnIrCreditosxCE As Boolean = (hidCreditosxCE.Value = "S")
            Dim blnAdjuntarIngreso As Boolean = (hidAdjuntarIngreso.Value = "S")
            Dim blnTipoDC7 As Boolean = (CheckStr(hidRespuestaDC.Value) = ConfigurationSettings.AppSettings("strConstanteTipo7"))

            If (strCodEstado = constEstadoAPRENVACT Or strCodEstado = constEstadoAPR) And blnTipoDC7 Then
                strMotivo = ConfigurationSettings.AppSettings("constMsjInconsistenciaDCTipo7")
            Else
                If Not blnAutonomia And (Not blnIrCreditosxReglas) Then
                    strMotivo = ConfigurationSettings.AppSettings("constMsjIncumplimientoAutonomia")
                End If
                If blnIrCreditosxNombres Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjCorreccionNombres")
                End If
                If blnIrCreditosxCE Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjConteoPlanesCE")
                End If
                If blnIrCreditosxDC7 Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjInconsistenciaDCTipo7")
                End If
                If blnIrCreditosxReglas Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjNoTieneReglas")
                End If
                If hidExcepcionBlacklist.Value = "S" Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjClienteFlexi")
                End If
                If blnAdjuntarIngreso Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjRevisionSustento")
                End If
                If hidBlacklistCred.Value = "S" Then
                    strMotivo &= ConfigurationSettings.AppSettings("constMsjBlacklist")
                End If
            End If

            If blnIrCreditosxAsesor Then
                strMotivo = ConfigurationSettings.AppSettings("constMsjRevisionSustento")
            End If

            If strMotivo.Length > 3 Then
                strMotivo = strMotivo.Substring(3)
            End If


        Return strMotivo
    End Function

    Private Function ConsultarRenta(ByVal strTipoProducto As String) As Renta
        Dim oRenta As New Renta(ConfigurationSettings.AppSettings("constCodTipoGarantiaRA"))
        Dim garantiaxProducto As String = hidGarantiaxProducto.Value
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "garantiaxProducto : " & garantiaxProducto)
        For Each item As String In garantiaxProducto.Split("|")
            If Not item = "" Then
                Dim arrGarantia As String() = item.Split(";")
                If arrGarantia(4) = strTipoProducto Then
                    oRenta.codGarantia = arrGarantia(0)
                    oRenta.desGarantia = arrGarantia(1)
                    oRenta.nroRenta = CheckDbl(arrGarantia(2))
                    oRenta.importe = CheckDbl(arrGarantia(3))
                    oRenta.CF = CheckDbl(arrGarantia(6))
                    Exit For
                End If
            End If
        Next
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.codGarantia --> " & CheckStr(oRenta.codGarantia))
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.desGarantia --> " & CheckStr(oRenta.desGarantia))
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.nroRenta --> " & CheckStr(oRenta.nroRenta))
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.importe --> " & CheckStr(oRenta.importe))
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.CF --> " & CheckStr(oRenta.CF))

        Return oRenta
    End Function

    Private Function ConsultarCFTotal(ByVal arrPlanDetalle As ArrayList) As Double
        Dim dblCFTotal As Double = 0.0

        For Each plan As PlanDetalleVenta In arrPlanDetalle
            dblCFTotal = dblCFTotal + CheckDbl(plan.CARGO_FIJO_LIN, 2)
        Next

        Return dblCFTotal
    End Function

    Private Function ConsultarImporteTotal() As Double
        Dim dblImporte As Double = 0.0
        Dim garantiaxProducto As String = hidGarantiaxProducto.Value
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "garantiaxProducto: " & garantiaxProducto)
        For Each item As String In garantiaxProducto.Split("|")
            If Not item = "" Then
                Dim arrGarantia As String() = item.Split(";")
                dblImporte += CheckDbl(arrGarantia(3))
            End If
        Next

        Return dblImporte
    End Function

    Private Function DatosDireccion(ByVal strCodProducto As String, ByVal strIdFila As String) As DireccionCliente
        Dim DSolicitud As String
        Dim oDireccion As New DireccionCliente

            If strCodProducto = ConfigurationSettings.AppSettings("CodTipoProductoDTH") Then
                oDireccion = CType(Session("oDireccionDTH_" & strIdFila), DireccionCliente)
            End If
            If strCodProducto = ConfigurationSettings.AppSettings("CodTipoProductoHFC") Then
                oDireccion = CType(Session("oDireccionHFC_" & strIdFila), DireccionCliente)
            End If
            oDireccion.IdTipoDireccion = "I"
            If oDireccion.IdEdificacion = "-1" Then
                oDireccion.IdEdificacion = ""
                oDireccion.Edificacion = ""
            End If
            If oDireccion.IdTipoInterior = "-1" Then
                oDireccion.IdTipoInterior = ""
                oDireccion.TipoInterior = ""
            End If
            If oDireccion.IdDomicilio = "-1" Then
                oDireccion.IdDomicilio = ""
                oDireccion.Domicilio = ""
            End If
            If oDireccion.IdZona = "-1" Then
                oDireccion.IdZona = ""
                oDireccion.Zona = ""
            End If
 

        Return oDireccion
    End Function

#End Region

#Region "GRABAR"

    Private Function GrabarVentaRenovacion(ByVal oParametro As VentaRenovaPost, ByVal oAccion As Int64) As Boolean

        Dim oSolicitud As New SolicitudNegocios
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        Dim strDesOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(1)
        Dim strTipoOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodVendedor As String = CurrentUser()
        Dim strCodTipoDocumento As String = Right("00" & hidTipoDocumento.Value, 2)
        Dim strNombreCliente As String = CheckStr(hidNombre.Value).ToUpper
        Dim strAPaternoCliente As String = CheckStr(hidApePaterno.Value).ToUpper
        Dim strAMaternoCliente As String = CheckStr(hidApeMaterno.Value).ToUpper
        Dim strTitular As String = String.Empty
        Dim strNroSEC As String = oParametro.numero_sec

        oLog.Log_WriteLog(strArchivo, strNroSEC & "- " & "Iniciando Grabar Venta Renovacion: ")

        If strCodTipoDocumento.Equals(ConfigurationSettings.AppSettings("TipoDocumentoRUC")) Then
            strTitular = CheckStr(hidRazonSocial.Value).ToUpper()
        Else
            strTitular = strNombreCliente & " " & strAPaternoCliente & " " & strAMaternoCliente
        End If

        Dim strCodOferta As String = hidTipoOferta.Value 'ddlOferta.SelectedValue
        Dim strCodSegmento As String
        If (strCodOferta = constTipoProductoCON Or strCodOferta = constTipoProductoB2E) Then
            strCodSegmento = constSegmentoCON
        Else
            strCodSegmento = constSegmentoECA
            If strCodOferta = constTipoProductoBUS Then
                If strTipoOficina = ConfigurationSettings.AppSettings("constCodTipoOficinaCAC") Then
                    strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBD")
                Else
                    strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBI")
                End If
            Else
                strCodCanal = ConfigurationSettings.AppSettings("constCodCanalBD")
            End If
        End If

        Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
        Dim dblCFGrupoSEC As Double = ConsultarCFTotal(arrPlanDetalle)

        Dim oVentaRenovaPost As New VentaRenovaPost
        Dim DSolicitud As String
        'Oficina
        DSolicitud = DSolicitud & strCodOficina & ";"
        oVentaRenovaPost.oficina = strCodOficina
        'Tipo Documento
        DSolicitud = DSolicitud & strCodTipoDocumento & ";"
        oVentaRenovaPost.tipo_documento = strCodTipoDocumento
        'Numero Documento
        DSolicitud = DSolicitud & CheckStr(hidNroDocumento.Value) & ";"
        oVentaRenovaPost.doc_clien_numero = CheckStr(hidNroDocumento.Value)
        'Vendedor
        DSolicitud = DSolicitud & strCodVendedor & ";"
        oVentaRenovaPost.vendedor = strCodVendedor
        'Telefono
        DSolicitud = DSolicitud & CheckStr(txtNroLinea.Text) & ";"
        oVentaRenovaPost.telefono = CheckStr(txtNroLinea.Text)
        'Plan Actual
        DSolicitud = DSolicitud & CheckStr(hidPlanActual.Value) & ";"
        oVentaRenovaPost.plan_actual = CheckStr(hidPlanActual.Value)
        'Plan Nuevo
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim desPlan As String = String.Empty
        Try
            desPlan = planTarifa.Split(","c)(2)
        Catch ex As Exception
            desPlan = String.Empty
        End Try
        DSolicitud = DSolicitud & desPlan & ";"
        oVentaRenovaPost.plan_nuevo = desPlan
        'Ciclo Facturacion
        DSolicitud = DSolicitud & CheckStr(hidCicloFact.Value) & ";"
        oVentaRenovaPost.ciclo_fact = CheckStr(hidCicloFact.Value)
        'Limite de Credito
        Dim vLimiteCred As Double = Convert.ToDouble(CheckDbl(hidLimiteCred.Value))
        DSolicitud = DSolicitud & Math.Round(vLimiteCred, 2) & ";"
        oVentaRenovaPost.limite_credito = Math.Round(vLimiteCred, 2)
        'Servidor
        DSolicitud = DSolicitud & System.Net.Dns.GetHostName & ";"
        oVentaRenovaPost.servidor = System.Net.Dns.GetHostName
        'Canal
        DSolicitud = DSolicitud & strCodCanal & ";"
        oVentaRenovaPost.canal = strCodCanal
        'Solicitud Codigo
        DSolicitud = DSolicitud & strNroSEC & ";"
        oVentaRenovaPost.numero_sec = strNroSEC
        'Titular
        DSolicitud = DSolicitud & strTitular & ";"
        oVentaRenovaPost.titular = strTitular
        'Cargo Fijo Nuevo
        DSolicitud = DSolicitud & Math.Round(dblCFGrupoSEC, 2) & ";"
        oVentaRenovaPost.renof_cnuevo = Math.Round(dblCFGrupoSEC, 2)
        'Cargo Fijo Actual
        Dim vCargoFijoActual As Double = Convert.ToDouble(CheckDbl(hidCargoFijoActual.Value))
        DSolicitud = DSolicitud & Math.Round(vCargoFijoActual, 2) & ";"
        oVentaRenovaPost.renof_cactual = Math.Round(vCargoFijoActual, 2)

        oLog.Log_WriteLog(strArchivo, "Valor hidCargoFijoActual : " & CheckStr(hidCargoFijoActual.Value))
        'Tipo Renovacion
        'INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
        Dim strTipoRenovacion As String = String.Empty
        oLog.Log_WriteLog(strArchivo, "PROY-9067 : Valor hidFlagRenovacionAdelantada : " & hidFlagRenovacionAdelantada.Value)
        If hidFlagRenovacionAdelantada.Value = True Then
            strTipoRenovacion = CheckStr(ConfigurationSettings.AppSettings("constTipoRenovAnticipada"))
        Else
            strTipoRenovacion = CheckStr(ConfigurationSettings.AppSettings("constTipoRenovNormal"))
        End If
        oLog.Log_WriteLog(strArchivo, "PROY-9067 : Valor strTipoRenovacion : " & strTipoRenovacion)

        'FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
        'FIN DBE

        DSolicitud = DSolicitud & strTipoRenovacion & ";"
        oVentaRenovaPost.tipo_renovacion = strTipoRenovacion
        'Representante Legal
        DSolicitud = DSolicitud & CheckStr(hidRepLegal.Value) & ";"
        oVentaRenovaPost.representante = CheckStr(hidRepLegal.Value)
        'Correo
        DSolicitud = DSolicitud & CheckStr(hidCorreo.Value) & ";"
        oVentaRenovaPost.correo = CheckStr(hidCorreo.Value)
        'Usuario Validador
        Dim usuarioValidador As String = CurrentUser
        usuarioValidador = usuarioValidador.ToUpper()
        DSolicitud = DSolicitud & usuarioValidador & ";"
        oVentaRenovaPost.usuario_validador = usuarioValidador
        'Flag Descuento
        Dim flagDescuento As String = 0
        If (hidFlagDescuento.Value = "true") Then
            flagDescuento = 1
        Else
            flagDescuento = 0
        End If
        DSolicitud = DSolicitud & flagDescuento & ";"
        oVentaRenovaPost.flag_descuento = flagDescuento
        'Nro Factura
        DSolicitud = DSolicitud & oParametro.numero_factura & ";"
        oVentaRenovaPost.numero_factura = oParametro.numero_factura
        'Nro Contrato
        DSolicitud = DSolicitud & oParametro.numero_contrato & ";"
        oVentaRenovaPost.numero_contrato = oParametro.numero_contrato
        'Nro Pedido
        DSolicitud = DSolicitud & oParametro.numero_pedido & ";"
        oVentaRenovaPost.numero_pedido = oParametro.numero_pedido
        'Descuento
        Dim descuento As Double = 0
        If Not CheckStr(hidDescuento.Value).Equals(String.Empty) Then
            descuento = CheckDbl(hidDescuento.Value)
            descuento = Math.Round(descuento, 2)
        End If
        DSolicitud = DSolicitud & descuento.ToString() & ";"
        oVentaRenovaPost.descuento = descuento
        'Renof Flaggener
        DSolicitud = DSolicitud & oParametro.renof_Flaggener & ";"
        oVentaRenovaPost.renof_Flaggener = oParametro.renof_Flaggener

        'inicio whzr 05112014
        Dim strDocVendedor As String = CheckStr(hidNomVendedor.Value)
        Dim strNomVendedor As String = CheckStr(hidDocVendedor.Value)

        If hidPuntoVenta.Value = ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") Then

            DSolicitud = DSolicitud & strDocVendedor & ";"
            oVentaRenovaPost.num_vendedor = strDocVendedor

            DSolicitud = DSolicitud & strNomVendedor & ";"
            oVentaRenovaPost.nom_vendedor = strNomVendedor
        Else
            DSolicitud = DSolicitud & strDocVendedor & ";"
            oVentaRenovaPost.num_vendedor = strDocVendedor

            DSolicitud = DSolicitud & strNomVendedor & ";"
            oVentaRenovaPost.nom_vendedor = strNomVendedor
        End If
        Dim strTipoRenovacion1 As String = String.Empty
        Dim strRenovChip As String = String.Empty
        If hidPuntoVenta.Value = ConfigurationSettings.AppSettings("constCodTipoCAC") Then


            strTipoRenovacion1 = CheckStr(hdnRetenidoFidelizado.Value)
            DSolicitud = DSolicitud & strTipoRenovacion1.ToUpper() & ";"
            oVentaRenovaPost.flag_fidelizado_retenido = strTipoRenovacion1.ToUpper()



            'If hidValidarIccid.Value.Equals("1") Then
            '   strRenovChip = CheckStr(ddlRenovChip.SelectedItem.Text)
            '  DSolicitud = DSolicitud & strRenovChip & ";"
            ' oVentaRenovaPost.mot_tip_renovchip = strRenovChip.ToUpper()
            'Else
            DSolicitud = DSolicitud & strRenovChip & ";"
            oVentaRenovaPost.mot_tip_renovchip = strRenovChip
            'End If
        Else
            DSolicitud = DSolicitud & strTipoRenovacion1 & ";"
            oVentaRenovaPost.flag_fidelizado_retenido = strTipoRenovacion1
        End If
        'fin whzr 05112014
        oLog.Log_WriteLog(strArchivo, strNroSEC & "- " & "Parametros enviados Grabar Venta Renovacion: --> " & DSolicitud)

        'Flag Renovacion y chip repuesto

        Dim flagRenovacionChipRepuesto As String = IIf(hidValidarIccid.Value.Equals("1"), "1", "0")
        oVentaRenovaPost.flag_renovacion_y_chip = flagRenovacionChipRepuesto
        '20151029UB
        oVentaRenovaPost.VigenciaPlan = CheckStr(hidMantenerPlan.Value)
        Return oSolicitud.GrabarVentaRenovacion(oVentaRenovaPost, oAccion)
    End Function

    Private Function GrabarPersona(ByVal strSolicitud As String, ByVal strCodTipoProd As String, _
                                    ByVal oReporteDC As Vista_SolicitudDC_Reporte, ByVal oIODatacredito As DataCredito_Input_Output, _
                                    ByVal listaPlanDetalle As ArrayList) As String
        Dim strNroSEC As String
        Dim strMensaje As String
        Dim blnResultado As Boolean
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim tipoDocumento As String = hidTipoDocumento.Value
        Dim nroLinea As String = hidNroLinea.Value
        Dim flgPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")
        Dim strCodTipoOferta As String = hidTipoOferta.Value 'ddlOferta.SelectedValue
        Dim strCodEstado As String = hidCodEstadoSEC.Value
        Dim oSolicitud As New SolicitudNegocios
        Dim intnrosec As Int64

        Try
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Inicio Renovacion PostPago - Grabar Persona *********")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & ">>>>Parametros de entrada:")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Solicitud: " & strSolicitud)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Codigo Tipo Prod: " & strCodTipoProd)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Nro Documento: " & nroDocumento)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Tipo Documento: " & tipoDocumento)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Nro Linea: " & nroLinea)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Portabilidad: " & flgPortabilidad)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Codigo Tipo Oferta: " & strCodTipoOferta)

            'GRABAR SEC
            Try
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "intnrosec : " & intnrosec)
                blnResultado = oSolicitud.RegistrarEvaluacion(strSolicitud, strMensaje, intnrosec)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "RegistrarEvaluacion : " & blnResultado)
            Catch e As Exception

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR al momento de RegistrarEvaluacion : " & blnResultado)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR al momento de RegistrarEvaluacion : " & e.Message)

            End Try
            strNroSEC = CheckStr(intnrosec)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & ">>>>Procesos")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar SEC: " & IIf(blnResultado, "OK", "Error"))

            If Not blnResultado Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al momento de Registrar la Solicitud! ERROR: " & strMensaje)
                Throw New Exception("Ocurrió un error al momento de Registrar la Solicitud! ERROR: " & strMensaje)
            End If

            'oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Nro SEC Generada: " & strNroSEC)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Validar Key (Grabar Detalle SEC)")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "CodTipoProductoHFC: " & CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoHFC")))
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "CodTipoProductoDTH: " & CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoDTH")))

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Cantidad Registros Plan Detalle: " & listaPlanDetalle.Count)

            'GRABAR DETALLE SEC
            Dim objConsumer As New ConsumerNegocio
            Dim objConsultaDTH As New PlanDetalleConsNegocio
            For Each oPlanDetalle As PlanDetalleVenta In listaPlanDetalle

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - NroSEC:" & CheckInt64(strNroSEC))

                oPlanDetalle.SOLIN_CODIGO = CheckInt64(strNroSEC)


                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - SOLIN_CODIGO:" & CheckInt64(oPlanDetalle.SOLIN_CODIGO))
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Registrar Plan *")

                Select Case oPlanDetalle.PRDC_CODIGO
                    Case CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoHFC"))
                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Grabar HFC (Plan Detalle) *")
                        GrabarHFC(oPlanDetalle)
                    Case CheckStr(ConfigurationSettings.AppSettings("CodTipoProductoDTH"))
                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Grabar DTH (Plan Detalle)*")
                        GrabarDTH(oPlanDetalle)
                    Case Else
                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Grabar Movil (Plan Detalle)*")
                        GrabarMovil(oPlanDetalle, flgPortabilidad)
                End Select

                'GRABAR DATOS BRMS
                For Each oOfrecimiento As Ofrecimiento In oClienteOfrecimiento
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strNroSEC --> " & strNroSEC)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oPlanDetalle.SOPLN_CODIGO --> " & CheckStr(oPlanDetalle.SOPLN_CODIGO))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oOfrecimiento.IdFila --> " & CheckStr(oOfrecimiento.IdFila))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oPlanDetalle.SOPLN_ORDEN --> " & CheckStr(oPlanDetalle.SOPLN_ORDEN))
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oRenta.codGarantia --> " & CheckStr(oOfrecimiento.MontoDeGarantia))
                    If oOfrecimiento.IdFila = oPlanDetalle.SOPLN_ORDEN Then
                        Dim blnOK As Boolean = (New ReglasEvaluacionNegocio).InsertarDatosBRMS(strNroSEC, oPlanDetalle.SOPLN_CODIGO, oOfrecimiento)
                        Exit For
                    End If
                Next
            Next

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar detalle SEC: OK")

            'GRABAR EN VENTA RENOVACION
            '---------------------------------------------------
            Dim oVentaRenovacion As New VentaRenovaPost
            oVentaRenovacion.numero_sec = CheckInt64(strNroSEC)
            Dim oAction As Int64 = 1
            If Not GrabarVentaRenovacion(oVentaRenovacion, oAction) Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Venta Renovacion: " + "Ocurrió un error al momento de Grabar la Venta")
                Throw New Exception("Ocurrió un error al momento de Grabar la Venta")
            End If

            'INICIO CAMPAÑAS NUEVAS 25/11/2015
            Dim oVentaNego As New VentaExpressNegocios
            Dim strvalorCombo As String = ""
            If CheckStr(hidplanAsoc.Value) <> "" Then
                strvalorCombo = oVentaNego.ActualizaComboRenov(CheckInt64(strNroSEC), CheckStr(hidplanAsoc.Value))
            End If

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - plan asociado: " & CheckStr(hidplanAsoc.Value))

            'FIN CAMPAÑAS NUEVAS 25/11/2015

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Venta Renovacion: OK")

            'ANULAR SECS ANTERIORES PARA TIPO RENOVACION Y ASOCIADA AL NRO LINEA
            '---------------------------------------------------
            Dim oVistaSolicitud As New VistaSolicitud
            Dim oSolicitudNegocio As New SolicitudNegocios

            oVistaSolicitud.solin_codigo = CheckInt64(strNroSEC)
            oVistaSolicitud.TDOCC_CODIGO = tipoDocumento
            oVistaSolicitud.CLIEC_NUM_DOC = nroDocumento
            oVistaSolicitud.LINEA = nroLinea
            If Not oSolicitudNegocio.AnularSECSAnteriores(oVistaSolicitud) Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al momento de Anular SECs Anteriores para Tipo Operacion: Renovacion, Linea: " & nroLinea)
                Throw New Exception("Ocurrió un error al momento de Anular SECs Anteriores para Tipo Operacion: Renovacion, Linea: " & nroLinea)
            End If
            '----------------------------

            'GRABAR DATOS PORTABILIDAD
            If flgPortabilidad Then

                'GRABAR ARCHIVOS PORTABILIDAD
                Dim arrArchivos As String() = hidArchivos.Value.Split("|"c)
                Dim strVarArchivosTempo As String = ""
                Dim objArchivosRegistrar As New ArrayList
                For Each ArrItemArchivos As String In arrArchivos
                    If ArrItemArchivos <> "" Then
                        Dim oArchivoPortabilidadNegocio As New ArchivoPortabilidadNegocio
                        Dim objArchivoPortabilidad As New ArchivoPortabilidad
                        Dim ArrValorItemArchivoPortabilidad As String() = ArrItemArchivos.Split(";"c)
                        Dim strNombreArchivo As String = strMensaje + "_" + ArrValorItemArchivoPortabilidad(1)
                        Dim strRutaArchivo As String = ConfigurationSettings.AppSettings("constLeerFileServerSPPortINTemp") + strNombreArchivo
                        Dim strNombreTemporalArchivo As String = ArrValorItemArchivoPortabilidad(0)
                        Dim strRutaTemporalArchivo As String = ConfigurationSettings.AppSettings("constLeerFileServerSPPortINTemp") + ArrValorItemArchivoPortabilidad(0)
                        Dim strTipoArchivo As String = ArrValorItemArchivoPortabilidad(2)

                        MoverArchivo(strRutaTemporalArchivo, strRutaArchivo)
                        objArchivoPortabilidad.SOLIN_CODIGO = CheckInt64(strNroSEC)
                        objArchivoPortabilidad.ARCH_NOMBRE = strNombreArchivo
                        objArchivoPortabilidad.ARCH_RUTA = strRutaArchivo
                        objArchivoPortabilidad.FLAG_ESTADO = "1"
                        objArchivoPortabilidad.ARCH_TIPO = strTipoArchivo

                        oArchivoPortabilidadNegocio.InsertarArchivoPortabilidad(objArchivoPortabilidad)
                    End If
                Next

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Archivos Portabilidad: OK")

                'ENVIO DIRECTO A MP
                If strCodEstado = constEstadoENVPOOLEMIT Then
                    Dim oMesaPortabilidadNegocio As New MesaPortabilidadNegocio
                    If Not oMesaPortabilidadNegocio.EnvioMPxSec(CheckInt64(strNroSEC), CurrentUser()) Then
                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al enviar la Solicitud a MP! ERROR: " & strMensaje)
                        Throw New Exception("Ocurrió un error al enviar la Solicitud a MP! ERROR: " & strMensaje)
                    End If
                End If

            End If

            'GRABAR DATOS ADICIONAL DE CREDITOS
            Dim arrFactxProducto As New ArrayList
            Dim arrNoFactxProducto As New ArrayList
            Dim arrLCDispxProducto As New ArrayList
            Dim strMontosxBilletera As String = String.Empty
            Dim dblMontoNoFacturado As Double = 0.0
            Dim dblMontoLC As Double = 0.0
            Dim itemCreditos As New DatosCreditos

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " |oClienteCuenta.nroDoc  - " & oClienteCuenta.nroDoc)

            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & hidNroDocumento.Value), ClienteCuenta)
            If Not IsNothing(objCliente) Then
                arrLCDispxProducto = objCliente.oLCDisponiblexBilletera
                arrFactxProducto = objCliente.oMontoFacturadoxBilletera
                arrNoFactxProducto = objCliente.oMontoNoFacturadoxBilletera

                If Not IsNothing(arrFactxProducto) Then
                    For Each item As Billetera In arrFactxProducto

                        If Not IsNothing(arrNoFactxProducto) Then
                            For Each monto As Billetera In arrNoFactxProducto
                                If item.idBilletera = monto.idBilletera Then
                                    dblMontoNoFacturado = monto.monto
                                End If
                            Next
                        End If

                        If Not IsNothing(arrLCDispxProducto) Then
                            For Each monto As Billetera In arrLCDispxProducto
                                If item.idBilletera = monto.idBilletera Then
                                    dblMontoLC = monto.monto
                                End If
                            Next
                        End If

                        strMontosxBilletera = String.Format("{0}|{1};{2};{3};{4}", strMontosxBilletera, item.idBilletera, dblMontoLC, item.monto, dblMontoNoFacturado)
                    Next
                End If
            End If

            itemCreditos.SOLIN_CODIGO = CheckInt64(strNroSEC)
            itemCreditos.LC_DISPONIBLE = CheckDbl(hidLCDisponible.Value)
            itemCreditos.PRODUCTO_MONTO = strMontosxBilletera
            itemCreditos.MSJ_AUTONOMIA = CheckStr(hidMensajeAutonomia.Value)
            itemCreditos.USUARIO_CREA = CurrentUser
            itemCreditos.MOTIVO = DatosMotivo(strCodEstado)
            itemCreditos.RANGO_LC_DISPONIBLE = hidTextRangoLC.Value

            Dim oNegocios As New SolicitudNegocios
            oNegocios.RegistrarEvaluacionDatosCreditos(itemCreditos)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Datos Creditos : OK")

            'GRABAR SUSTENTO A PEDIDO DEL PDV
            If (hidCreditosxAsesor.Value = "S") Then
                GrabarArchivos(strNroSEC)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Sustento al pedido PDV: OK")
            End If

            'DC RAZONES
            Dim nodos As String
            Dim strRazonesDC As String = ""
            Try
                strRazonesDC = CheckStr(hidDatosDC.Value.Split("?")(24))
            Catch ex As Exception
                strRazonesDC = ""
            End Try

            Dim isrtnodosterminales As String() = strRazonesDC.Split("|"c)
            For Each item As String In isrtnodosterminales
                nodos = CheckStr(item).Split("|"c)(0)
                If Not nodos.Equals(String.Empty) Then
                    Dim razones As Boolean = New SolicitudNegocios().GrabarRazonesEvaluacion(CheckInt64(strNroSEC), nodos, "")
                End If
            Next

            'GUARDAR REPORTE DC
            oReporteDC.DCREN_SOLIN_CODIGO = strNroSEC
            Dim objSolicitudDC As New SolicitudDC_ReporteNegocio
            If CheckStr(Session("FuenteConsulta")) = "DataCredito" Then
                Dim datacredito As String
                datacredito = oReporteDC.DCREC_FACTOR_RENOVACION & "," & _
                oReporteDC.DCREC_VALIDAR_CLIENTE & "," & _
                oReporteDC.DCREN_CANT_INTENTOS & "," & _
                oReporteDC.DCREV_NOMBRE & "," & _
                oReporteDC.DCREV_APELLIDO_MAT & "," & _
                oReporteDC.DCREV_APELLIDO_PAT & "," & _
                oReporteDC.DCREV_NUM_DOCUMENTO & "," & _
                oReporteDC.DCREV_TIPO_DOCUMENTO_DESC & "," & _
                oReporteDC.DCREC_TIPO_DOCUMENTO & "," & _
                oReporteDC.DCREN_USUARIO_REG & "," & _
                oReporteDC.DCREV_OVEN_DESC & "," & _
                oReporteDC.DCREV_OVEN_CODIGO & "," & _
                oReporteDC.DCREN_SOLIN_CODIGO & "," & _
                oReporteDC.DCREV_NUM_OPERACION
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Datos DATACREDITO  --> GrabarPersona : " & datacredito)
                objSolicitudDC.Insertar_DC_Reporte(oReporteDC)

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Reporte DC: OK")

            End If
            Session("FuenteConsulta") = Nothing

            'ACTUALIZAR INPUT / OUTPUT DC
            'oIODatacredito.IODCN_SOLIN_CODIGO = CheckInt64(strNroSEC)
            'objSolicitudDC.Actualizar_Input_Output(oIODatacredito)

            'ACTUALIZAR HISTORICO DC
            Dim objHistoricoNegocio As New SolicitudDC_HistoricoNegocio
            objHistoricoNegocio.Actualizar_DC_Historico(oReporteDC.DCREV_NUM_OPERACION, oReporteDC.DCREC_VALIDAR_CLIENTE)

            'GRABAR HISTORICO APROBADO y ENVIADO A ACTIVACIONES
            Dim log As Boolean
            log = New SolicitudNegocios().GrabarLogHistorico(CheckInt64(strNroSEC), strCodEstado, CurrentUser().ToString(), "")

            Return strNroSEC

        Catch ex As Exception
            strNroSEC = ""
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR al momento de Grabar : " & ex.Message)
            Throw ex
        End Try

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Fin Renovacion PostPago - Grabar Persona *********")


    End Function

    Private Function GrabarEmpresa(ByVal listaPlanDetalle As ArrayList, ByVal oEmpresa As SolicitudEmpresa) As String
        Dim strNroSEC As Int64
        Dim strMensaje As String
        Dim blnResultado As Boolean
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim flgPortabilidad As Boolean = (hidTienePortabilidad.Value = "S")
        Dim strCodEstado As String = hidCodEstadoSEC.Value
        Dim flgAutonomia As Boolean = (hidAutonomia.Value = "S")
        Dim oSolicitud As New SolicitudNegocios
        Dim tipoDocumento As String = hidTipoDocumento.Value
        Dim nroLinea As String = hidNroLinea.Value

        Try

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Inicio Renovacion PostPago - Grabar Empresa *********")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & ">>>>Parametros de entrada:")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Nro Documento: " & nroDocumento)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Tipo Documento: " & tipoDocumento)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Nro Linea: " & nroLinea)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Portabilidad: " & flgPortabilidad)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - Estado SEC: " & strCodEstado)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & ">>>>Procesos")

            'GRABAR SEC
            If flgPortabilidad Then
                blnResultado = oSolicitud.GrabarSolicitudEmpresaPort(oEmpresa, CheckInt64(strNroSEC), strMensaje)
            Else
                blnResultado = oSolicitud.GrabarSolicitudEmpresa(oEmpresa, strNroSEC, strMensaje)
            End If

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar SEC Mensaje: " & strMensaje)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "nroSec" & CheckStr(strNroSEC))
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar SEC: " & IIf(blnResultado, "OK", "Error"))

            If Not blnResultado Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al momento de Registrar la Solicitud! ERROR: " & strMensaje)
                Throw New Exception("Ocurrió un error al momento de Registrar la Solicitud! ERROR: " & strMensaje)
            End If

            'GRABAR COMENTARIOS PDV
            Dim strComentario As String = CheckStr(hidComentarioPDV.Value)
            If Not strComentario = "" Then
                GrabarComentario(CheckInt64(strNroSEC), strComentario)
            End If

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Comentarios PDV: OK")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "nroSec" & CheckStr(strNroSEC))
            'GRABAR DETALLE SEC
            Dim objConsumer As New ConsumerNegocio
            For Each oPlanDetalle As PlanDetalleVenta In listaPlanDetalle
                oPlanDetalle.SOLIN_CODIGO = CheckInt64(strNroSEC)
                GrabarMovil(oPlanDetalle, flgPortabilidad)

                'GRABAR DATOS BRMS
                For Each oOfrecimiento As Ofrecimiento In oClienteOfrecimiento
                    If oOfrecimiento.IdFila = oPlanDetalle.SOPLN_ORDEN Then
                        Dim blnOK As Boolean = (New ReglasEvaluacionNegocio).InsertarDatosBRMS(strNroSEC, oPlanDetalle.SOPLN_CODIGO, oOfrecimiento)
                        Exit For
                    End If
                Next
            Next

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Detalle SEC: OK")

            'GRABAR VENTA RENOVACION
            Dim oVentaRenovacion As New VentaRenovaPost
            oVentaRenovacion.numero_sec = CheckInt64(strNroSEC)
            Dim oAction As Int64 = 1
            If Not GrabarVentaRenovacion(oVentaRenovacion, oAction) Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al momento de Grabar la Venta")
                Throw New Exception("Ocurrió un error al momento de Grabar la Venta")
            End If

            'INICIO CAMPAÑAS NUEVAS 25/11/2015
            Dim oVentaNego As New VentaExpressNegocios
            Dim strvalorCombo As String = ""
            If CheckStr(hidplanAsoc.Value) <> "" Then
                strvalorCombo = oVentaNego.ActualizaComboRenov(CheckInt64(strNroSEC), CheckStr(hidplanAsoc.Value))
            End If
            'FIN CAMPAÑAS NUEVAS 25/11/2015

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Venta Renovacion: OK")

            'ANULAR SECS ANTERIORES PARA TIPO RENOVACION Y ASOCIADA AL NRO LINEA
            '---------------------------------------------------
            Dim oVistaSolicitud As New VistaSolicitud
            Dim oSolicitudNegocio As New SolicitudNegocios

            oVistaSolicitud.solin_codigo = CheckInt64(strNroSEC)
            oVistaSolicitud.TDOCC_CODIGO = tipoDocumento
            oVistaSolicitud.CLIEC_NUM_DOC = nroDocumento
            oVistaSolicitud.LINEA = nroLinea
            If Not oSolicitudNegocio.AnularSECSAnteriores(oVistaSolicitud) Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Ocurrió un error al momento de Anular SECs Anteriores para Tipo Operacion: Renovacion, Linea: " & nroLinea)
                Throw New Exception("Ocurrió un error al momento de Anular SECs Anteriores para Tipo Operacion: Renovacion, Linea: " & nroLinea)
            End If
            '-------------------------------------

            'FIJO INALAMBRICO - BLOQUEO Y/O DEUDA
            Dim dblDeuda As Double = CheckDbl(hidDeuda.Value)
            If dblDeuda > 0 Then
                Dim bln As Boolean = oSolicitud.Registrar_Monto_Vencido(strNroSEC, dblDeuda, "1")
            End If

            'GRABAR DATOS PORTABILIDAD
            If flgPortabilidad Then

                'GRABAR ARCHIVOS PORTABILIDAD
                Dim arrArchivos As String() = hidArchivos.Value.Split("|"c)
                Dim strVarArchivosTempo As String = ""
                Dim objArchivosRegistrar As New ArrayList
                For Each ArrItemArchivos As String In arrArchivos
                    If ArrItemArchivos <> "" Then
                        Dim oArchivoPortabilidadNegocio As New ArchivoPortabilidadNegocio
                        Dim objArchivoPortabilidad As New ArchivoPortabilidad
                        Dim ArrValorItemArchivoPortabilidad As String() = ArrItemArchivos.Split(";"c)
                        Dim strNombreArchivo As String = strMensaje + "_" + ArrValorItemArchivoPortabilidad(1)
                        Dim strRutaArchivo As String = ConfigurationSettings.AppSettings("constLeerFileServerSPPortINTemp") + strNombreArchivo
                        Dim strNombreTemporalArchivo As String = ArrValorItemArchivoPortabilidad(0)
                        Dim strRutaTemporalArchivo As String = ConfigurationSettings.AppSettings("constLeerFileServerSPPortINTemp") + ArrValorItemArchivoPortabilidad(0)
                        Dim strTipoArchivo As String = ArrValorItemArchivoPortabilidad(2)

                        MoverArchivo(strRutaTemporalArchivo, strRutaArchivo)
                        objArchivoPortabilidad.SOLIN_CODIGO = CheckInt64(strNroSEC)
                        objArchivoPortabilidad.ARCH_NOMBRE = strNombreArchivo
                        objArchivoPortabilidad.ARCH_RUTA = strRutaArchivo
                        objArchivoPortabilidad.FLAG_ESTADO = "1"
                        objArchivoPortabilidad.ARCH_TIPO = strTipoArchivo

                        oArchivoPortabilidadNegocio.InsertarArchivoPortabilidad(objArchivoPortabilidad)
                    End If
                Next

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Datos Portabilidad: OK")

            End If

            'GRABAR DATOS ADICIONAL DE CREDITOS
            Dim arrFactxProducto As New ArrayList
            Dim arrNoFactxProducto As New ArrayList
            Dim arrLCDispxProducto As New ArrayList
            Dim strMontosxBilletera As String = String.Empty
            Dim dblMontoNoFacturado As Double = 0.0
            Dim dblMontoLC As Double = 0.0
            Dim itemCreditos As New DatosCreditos

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " |oClienteCuenta.nroDoc  - " & oClienteCuenta.nroDoc)

            Dim objCliente As ClienteCuenta = CType(Session("objCliente" & hidNroDocumento.Value), ClienteCuenta)
            If Not IsNothing(objCliente) Then
                arrLCDispxProducto = objCliente.oLCDisponiblexBilletera
                arrFactxProducto = objCliente.oMontoFacturadoxBilletera
                arrNoFactxProducto = objCliente.oMontoNoFacturadoxBilletera

                If Not IsNothing(arrFactxProducto) Then
                    For Each item As Billetera In arrFactxProducto

                        If Not IsNothing(arrNoFactxProducto) Then
                            For Each monto As Billetera In arrNoFactxProducto
                                If item.idBilletera = monto.idBilletera Then
                                    dblMontoNoFacturado = monto.monto
                                End If
                            Next
                        End If

                        If Not IsNothing(arrLCDispxProducto) Then
                            For Each monto As Billetera In arrLCDispxProducto
                                If item.idBilletera = monto.idBilletera Then
                                    dblMontoLC = monto.monto
                                End If
                            Next
                        End If

                        strMontosxBilletera = String.Format("{0}|{1};{2};{3};{4}", strMontosxBilletera, item.idBilletera, dblMontoLC, item.monto, dblMontoNoFacturado)
                    Next
                End If
            End If

            itemCreditos.SOLIN_CODIGO = CheckInt64(strNroSEC)
            itemCreditos.LC_DISPONIBLE = CheckDbl(hidLCDisponible.Value)
            itemCreditos.PRODUCTO_MONTO = strMontosxBilletera
            itemCreditos.MSJ_AUTONOMIA = CheckStr(hidMensajeAutonomia.Value)
            itemCreditos.USUARIO_CREA = CurrentUser
            itemCreditos.MOTIVO = DatosMotivo(strCodEstado)
            itemCreditos.RANGO_LC_DISPONIBLE = hidTextRangoLC.Value

            Dim oNegocios As New SolicitudNegocios
            oNegocios.RegistrarEvaluacionDatosCreditos(itemCreditos)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar Datos Creditos: OK")

            'GRABAR SUSTENTO A PEDIDO DEL PDV
            If (hidCreditosxAsesor.Value = "S") Then
                GrabarArchivos(strNroSEC)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | - " & "Resultado Grabar sutento a pedido PDV: OK")
            End If

        Catch ex As Exception
            strNroSEC = ""
            Throw ex
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR GRABAR EMPRESA: " & ex.Message)
        End Try

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " | " & "********** Fin Renovacion PostPago - Grabar Empresa *********")


        Return strNroSEC
    End Function

    Private Sub GrabarMovil(ByVal oPlanDetalle As PlanDetalleVenta, ByVal flgPortabilidad As Boolean)
        Dim oConsumer As New ConsumerNegocio
      
            'GRABAR PLANES
            If Not oConsumer.InsertarPlanSolicitud(oPlanDetalle, oPlanDetalle.SOPLN_CODIGO) Then
                Throw New Exception
            End If

            'GRABAR DETALLE VENTA
            If Not oConsumer.InsertarPlanVenta(oPlanDetalle) Then
                Throw New Exception
            End If

            ''GRABAR SERVICIOS
            'If oPlanDetalle.SERVICIO.Count > 0 Then
            '    If Not oConsumer.InsertarPlanServicio(oPlanDetalle.SERVICIO, oPlanDetalle.SOLIN_CODIGO, oPlanDetalle.SOPLN_CODIGO) Then
            '        Throw New Exception
            '    End If
            'End If


            'GRABAR SERVICIOS
            If oPlanDetalle.SERVICIO.Count > 0 Then
                Dim puntoVenta As String = IIf(hidOficina.Value.Equals(""), "", hidOficina.Value)
                Dim codigoPlan As String = IIf(oPlanDetalle.PLANC_CODIGO.Equals(""), "", oPlanDetalle.PLANC_CODIGO)
            If Not oConsumer.InsertarPlanServicio_2(oPlanDetalle.SERVICIO, oPlanDetalle.SOLIN_CODIGO, oPlanDetalle.SOPLN_CODIGO, puntoVenta, codigoPlan, hidPrima.Value) Then 'PROY-24724-IDEA-28174- Nuevo parametro (hidPrima.Value)
                    Throw New Exception
                End If
            End If

            'GRABAR TELEFONOS PORTABILIDAD
            If flgPortabilidad Then
                Dim objPortabilidadNegocio As New NumeroPortabilidadNegocio
                Dim objNroPortabilidad As New NumeroPortabilidad

                objNroPortabilidad.SOLIN_CODIGO = CheckInt64(oPlanDetalle.SOLIN_CODIGO)
                objNroPortabilidad.SOPLN_CODIGO = oPlanDetalle.SOPLN_CODIGO
                objNroPortabilidad.PORT_NUM_DOC = CheckStr(hidNroDocumento.Value)
                objNroPortabilidad.PLANC_CODIGO = oPlanDetalle.PLANC_CODIGO
                objNroPortabilidad.PORT_NUMERO = oPlanDetalle.TELEFONO
                objNroPortabilidad.FLAG_ESTADO = ConfigurationSettings.AppSettings("FlagPortaNumeroNuevo")
                objNroPortabilidad.TPROC_CODIGO = hidTipoOferta.Value 'ddlOferta.SelectedValue

                If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                    objNroPortabilidad.TPROC_CODIGO = ConfigurationSettings.AppSettings("constCodEvaluacionEmpresarial")
                End If

                objNroPortabilidad.PORT_USU_CREA = CurrentUser
                objNroPortabilidad.PORT_MODALIDAD = hidModalidad.Value

                objPortabilidadNegocio.InsertarNumeroPortabilidad(objNroPortabilidad)
            End If
            Session("PlanDetalle") = oPlanDetalle

    End Sub

    Private Sub GrabarDTH(ByVal oPlanDetalle As PlanDetalleVenta)
        Dim strIdVenta As String
        Dim oConsumer As New ConsumerNegocio
        Dim oSolicitud As New SolicitudNegocios
 
            'GRABAR PLANES
            If Not oConsumer.InsertarPlanSolicitud(oPlanDetalle, oPlanDetalle.SOPLN_CODIGO) Then
                Throw New Exception
            End If

            'GRABAR SERVICIOS
            If oPlanDetalle.SERVICIO.Count > 0 Then
                If Not oConsumer.InsertarPlanServicio(oPlanDetalle.SERVICIO, oPlanDetalle.SOLIN_CODIGO, oPlanDetalle.SOPLN_CODIGO) Then
                    Throw New Exception
                End If
            End If

            'GRABAR DETALLE / VENTA
            If Not IsNothing(oPlanDetalle.PLAN_SOL_DTH) Then
                If Not oSolicitud.RegistrarVenta_DTH(oPlanDetalle.PLAN_SOL_DTH.VENTA_DTH, oPlanDetalle.SOLIN_CODIGO, strIdVenta) Then
                    Throw New Exception
                End If
                oSolicitud.RegistrarVentaDetalle_DTH(oPlanDetalle.PLAN_SOL_DTH.VENTA_DET_DTH, CheckInt64(strIdVenta), Nothing)

                'GRABAR GARANTIA
                If Not IsNothing(oPlanDetalle.PLAN_SOL_DTH.GARANTIA_DTH) Then
                    Dim objGarantia As AP_Garantia = oPlanDetalle.PLAN_SOL_DTH.GARANTIA_DTH
                    objGarantia.VENTN_DOCUMENTO = strIdVenta
                    oSolicitud.RegistrarGarantia_DTH(objGarantia, Nothing)
                End If
            End If
  
    End Sub

    Private Sub GrabarHFC(ByVal oPlanDetalle As PlanDetalleVenta)
        Dim idSolHFC As String
        Dim oConsumer As New ConsumerNegocio

            Dim oPlanDetalleHFC As PlanSolicitudHFC = oPlanDetalle.PLAN_SOL_HFC

            'GRABAR PLANES
            If Not oConsumer.InsertarPlanHFC(oPlanDetalle.PLAN_SOL_HFC, oPlanDetalle.SOLIN_CODIGO, idSolHFC) Then
                Throw New Exception
            End If

            'GRABAR SERVICIOS
            If oPlanDetalleHFC.Servicio.Count > 0 Then
                If Not oConsumer.InsertarPlanServicioHFC(oPlanDetalleHFC.Servicio, idSolHFC) Then
                    Throw New Exception
                End If
            End If

            'GRABAR PROMOCIONES
            If oPlanDetalleHFC.Promocion.Count > 0 Then
                If Not oConsumer.InsertarPlanPromocionHFC(oPlanDetalleHFC.Promocion, idSolHFC) Then
                    Throw New Exception
                End If
            End If
  
    End Sub

    Private Sub GrabarComentario(ByVal nroSEC As Int64, ByRef msg As String)
        Dim oConsulta As New SolicitudNegocios
        Dim item As New Comentario
        Dim estado As Int32
        Try
            item.COMEC_ESTADO = "1"
            item.COMEC_FLA_COM = "00"
            item.COMEC_USU_REG = CurrentUser
            item.SOLIN_CODIGO = nroSEC
            item.COMEV_COMENTARIO = UCase(CheckStr(hidComentarioPDV.Value))
            oConsulta.GrabarComentario(item, estado, msg)

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " GrabarComentario mensaje : " & msg)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR  --> GrabarComentario : " & ex.Message)
        End Try

    End Sub

    Private Sub GrabarArchivos(ByVal nroSEC As String)
        Dim msg As String
        Dim oConsulta As New SolicitudNegocios
        Try
            Dim listaArchivo As ArrayList = DatosArchivos(hidArchivosEnvioCreditos.Value)
            For Each item As ItemGenerico In listaArchivo
                oConsulta.GrabarArchivo(nroSEC, item.Descripcion, item.Codigo, CurrentUser, 0, msg)
            Next
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Funciones"

    Public Function DatosArchivos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@ARCHIVO@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aArchivo() As String = c.Split("|"c)
                Dim item As New ItemGenerico
                item.Codigo = aArchivo(0)
                item.Descripcion = aArchivo(1)
                salida.Add(item)
            End If
        Next
        Return salida
    End Function

    Private Sub MoverArchivo(ByVal strRutaTemporalArchivo As String, ByVal strRutaArchivo As String)
        Try
            Dim objFilex As New ABCUpload4.XForm
            objFilex.MaxUploadSize = Convert.ToInt32(ConfigurationSettings.AppSettings("TamanioMaximoArchivoSP"))
            objFilex.AbsolutePath = True
            objFilex.Overwrite = True
            objFilex.Read(strRutaTemporalArchivo)
            objFilex.Save(strRutaArchivo)

            Try
                objFilex.Read("")
            Catch ex As Exception
            End Try

            objFilex = Nothing

            Dim objComponente As Object
            Dim intResult As Object
            objComponente = Server.CreateObject("Documento_Util.ClsUtilitario")
            intResult = objComponente.FP_eliminaArchivo(strRutaTemporalArchivo)

        Catch ex As Exception
            Response.Write("<script language=javascript>")
            Response.Write("alert(' " + ex.Message.ToString + " ');")
            Response.Write("</script>")
        End Try
    End Sub

    Private Sub GrabarAuditoria(ByVal strTransaccion As String, ByVal strTexto As String)
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        Dim usuario_id As String = CurrentUser
        Dim ipcliente As String = CurrentTerminal
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

        Try
            Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strTexto)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Detalle Venta"

    Public Function CalificarSubsidio(ByVal dblPrecioLista As Double, ByVal dblPrecioVenta As Double) As String
        Dim dblFactor As Double
        Dim strCalificacion As String
        Dim dblFactorSubsidioMenor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMenor")))
        Dim dblFactorSubsidioMayor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMayor")))

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblPrecioVenta renovacionpostpago " & dblPrecioVenta)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio dblPrecioLista renovacionpostpago " & dblPrecioLista)

        If dblPrecioVenta = 0 Then
            dblFactor = 0
        Else
            dblFactor = (dblPrecioLista - dblPrecioVenta) / dblPrecioVenta
            If dblFactor < 0 Then
                dblFactor = 0
            End If
        End If
        dblFactor = CheckDbl(dblFactor, 2)

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio renovacionpostpago dblFactor " & dblFactor)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio  renovacionpostpago dblFactorSubsidioMenor " & dblFactorSubsidioMenor)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "CalificarSubsidio  renovacionpostpago dblFactorSubsidioMayor " & dblFactorSubsidioMayor)

        If dblFactor < dblFactorSubsidioMenor Then
            strCalificacion = "BAJO"
        ElseIf dblFactor >= dblFactorSubsidioMenor And dblFactor < dblFactorSubsidioMayor Then
            strCalificacion = "MEDIO"
        ElseIf dblFactor >= dblFactorSubsidioMayor Then
            strCalificacion = "ALTO"
        End If
        Return strCalificacion
    End Function

    Public Function ObtenerParametroGeneral(ByVal CodParametro As String) As String
        Dim valor As String
        Dim listaParametro As String = hidListaParametroGeneral.Value
        Dim arrListaParametro As String() = listaParametro.Split("|")
        For Each item As String In arrListaParametro
            Dim parametro As String() = item.Split(";")
            If parametro(0) = CodParametro Then
                valor = parametro(1)
            End If
        Next
        Return valor
    End Function

    Private Function ObtenerPlanDetalle() As ArrayList

        Dim idx As Integer = 0
        Dim strCadenaEvaluacion As String = CheckStr(hidCadenaDetalle.Value)
        Dim arrPlanes() As String = strCadenaEvaluacion.Split("|")
        Dim arrPlan As String()
        Dim arrDetallePlan As New ArrayList
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        Dim strAgrupaPaquete As String = hidGrupoPaqueteServer.Value 'Cadena Grupo Paquetes
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCodCanal " & strCodCanal)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCodOficina " & strCodOficina)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strAgrupaPaquete " & strAgrupaPaquete)
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCadenaEvaluacion " & strCadenaEvaluacion)
        Try

            For Each strPlanes As String In arrPlanes
                If strPlanes.Length > 0 Then
                    Dim strPlanFila As String() = strPlanes.Split(";")

                    Dim oPlanDetalle As New PlanDetalleVenta
                    oPlanDetalle.SOPLN_ORDEN = strPlanFila(0)
                    oPlanDetalle.TPROC_CODIGO = hidTipoOferta.Value 'ddlOferta.SelectedValue
                    oPlanDetalle.PRDC_CODIGO = strPlanFila(1)
                    oPlanDetalle.PACUC_CODIGO = strPlanFila(2)
                    oPlanDetalle.PACUV_DESCRIPCION = strPlanFila(3)
                    oPlanDetalle.CARGO_FIJO = CheckDbl(strPlanFila(20))
                    oPlanDetalle.MODALIDAD_VENTA = hidModalidadVenta.Value

                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oPlanDetalle.TPROC_CODIGO  " & oPlanDetalle.TPROC_CODIGO)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " oPlanDetalle.PRDC_CODIGO  " & oPlanDetalle.PRDC_CODIGO)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " oPlanDetalle.PACUC_CODIGO " & oPlanDetalle.PACUC_CODIGO)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oPlanDetalle.PACUV_DESCRIPCION " & oPlanDetalle.PACUV_DESCRIPCION)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "oPlanDetalle.MODALIDAD_VENTA  " & oPlanDetalle.MODALIDAD_VENTA)
                    oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " oPlanDetalle.CARGO_FIJO " & oPlanDetalle.CARGO_FIJO)


                    'Tipo Producto
                    If oPlanDetalle.PRDC_CODIGO = ConfigurationSettings.AppSettings("CodTipoProductoHFC") Then

                        'Primer elemento que Agrupa un Paquete => {,[1],[2],[3],[4],[5]}{,[6],[7],[8],[9],[10]}
                        If (strAgrupaPaquete.IndexOf("{,[" & oPlanDetalle.SOPLN_ORDEN & "]") > -1) Then

                            oPlanDetalle.PLAN_SOL_HFC = ObtenerDetalleHFC(oPlanDetalle.SOPLN_ORDEN, oPlanDetalle.CARGO_FIJO_LIN)
                            arrDetallePlan.Add(oPlanDetalle)
                        End If

                    Else
                        oPlanDetalle.PAQTV_CODIGO = strPlanFila(6)
                        oPlanDetalle.PAQTV_DESCRIPCION = strPlanFila(7)

                        arrPlan = strPlanFila(9).Split("_")
                        oPlanDetalle.PLANC_CODIGO = arrPlan(0)
                        oPlanDetalle.PLANV_DESCRIPCION = strPlanFila(11)

                        If Not oPlanDetalle.PAQTV_CODIGO = "" Then
                            oPlanDetalle.SOPLN_SECUENCIA = arrPlan(4) '//PENDIENTE
                            oPlanDetalle.SOPLV_PAQU_AGRU = hidGrupoPaqueteServer.Value
                        End If

                        'Inicio Incidencia 20160114
                        Dim codTope As String = ""

                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " strPlanFila(14) " & strPlanFila(14))
                        If (strPlanFila(14) = ConfigurationSettings.AppSettings("constCodTopeSinCFServicio")) Then
                            codTope = ConfigurationSettings.AppSettings("constCodTopeSinCF")
                        ElseIf (strPlanFila(14) = ConfigurationSettings.AppSettings("constCodTopeCeroServicio")) Then
                            codTope = ConfigurationSettings.AppSettings("constCodTopeCero")
                        ElseIf (strPlanFila(14) = ConfigurationSettings.AppSettings("constCodTopeAutomaticoServicio")) Then
                            codTope = ConfigurationSettings.AppSettings("constCodTopeAutomatico")
                        End If

                        oPlanDetalle.TOPE_CODIGO = codTope
                        'Fin Incidencia 20160114

                        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " oPlanDetalle.TOPE_CODIGO " & oPlanDetalle.TOPE_CODIGO)



                        oPlanDetalle.TOPE_MONTO = CheckDbl(strPlanFila(19))
                        oPlanDetalle.SOPLN_CANTIDAD = 1
                        oPlanDetalle.CAMPANA = strPlanFila(15)
                        oPlanDetalle.CAMPANA_DESC = strPlanFila(16)
                        oPlanDetalle.MATERIAL = strPlanFila(17)
                        oPlanDetalle.MATERIAL_DESC = strPlanFila(18)

                        If Not oPlanDetalle.PRDC_CODIGO = ConfigurationSettings.AppSettings("CodTipoProductoDTH") Then
                            If Not oPlanDetalle.MATERIAL = "" Then
                                Dim arrCadPrecio As String() = strPlanFila(24).Split("_")
                                oPlanDetalle.LISTA_PRECIO = arrCadPrecio(1)
                                oPlanDetalle.LISTA_PRECIO_DESC = arrCadPrecio(2)
                                oPlanDetalle.PRECIO_LISTA = CheckDbl(arrCadPrecio(3))
                                oPlanDetalle.PRECIO_VENTA = CheckDbl(arrCadPrecio(0))
                            End If
                        End If

                        'CUOTA
                        oPlanDetalle.CUOTA_CODIGO = strPlanFila(28)
                        hidCuota.Value = strPlanFila(28)
                        oPlanDetalle.CUOTA_INICIAL = strPlanFila(29)

                        oPlanDetalle.TELEFONO = strPlanFila(30)

                       'PROY-24724-IDEA-28174 - INICIO 
                        oPlanDetalle.SERVICIO = ObtenerServicio(oPlanDetalle.SOPLN_ORDEN)
                        If (oPlanDetalle.SERVICIO.Count > 0) Then
                            If (hidEvalPM.Value = "1" And (hidAccion.Value = "Grabar" Or (hidAccion.Value = "GenerarPedido" And chkProMovil.Checked))) Then
                                For Each srv As SecServicio_AP In oPlanDetalle.SERVICIO
                                    If (srv.SERVV_CODIGO = ClsKeyAPP.strCodServProteccionMovil) Then
                                        oPlanDetalle.CARGO_FIJO_LIN = CheckDbl(strPlanFila(23)) + Funciones.CheckDbl(Funciones.CheckStr(hidPrima.Value).Trim())
                                        Exit For
                                    Else
                        oPlanDetalle.CARGO_FIJO_LIN = CheckDbl(strPlanFila(23))
                                    End If
                                Next
                            Else
                        oPlanDetalle.CARGO_FIJO_LIN = CheckDbl(strPlanFila(23))
                            End If
                        Else
                            oPlanDetalle.CARGO_FIJO_LIN = CheckDbl(strPlanFila(23))
                        End If

                       'PROY-24724-IDEA-28174 - FIN 
                        oPlanDetalle.SUBSIDIO = CalificarSubsidio(oPlanDetalle.PRECIO_LISTA, oPlanDetalle.PRECIO_VENTA)
                        'gaa20161024
                        oPlanDetalle.FAMILIA_PLAN = strPlanFila(36)
                        'fin gaa20161024
                        'VENTA Y DETALLE DTH
                        If oPlanDetalle.PRDC_CODIGO = ConfigurationSettings.AppSettings("CodTipoProductoDTH") Then
                            'EQUIPO CAMBIO TITULARIDAD
                            If Not oPlanDetalle.MATERIAL = "0" Then

                                Dim oVenta As New AP_Venta
                                Dim oVentaDetalle As New AP_VentaDetalle
                                Dim oSolicitudDTH As New PlanSolicitudDTH

                                oVenta.TIPO_DOCUMENTO = "ZPBR"
                                oVenta.CANAL = strCodCanal
                                oVenta.OFICINA_VENTA = strCodOficina
                                oVenta.TIPO_DOC_CLIENTE = hidTipoDocumento.Value
                                oVenta.NRO_DOC_CLIENTE = hidNroDocumento.Value
                                oVenta.MONEDA = "L"
                                oVenta.TOPEN_CODIGO = ConfigurationSettings.AppSettings("constTipoOperacionRenovacion")
                                oVenta.TOTAL_VENTA = (New ConsumerNegocio).fltTraerPrecioKit(oPlanDetalle.CAMPANA, oPlanDetalle.PACUC_CODIGO, oPlanDetalle.MATERIAL)

                                Dim dblImpuesto As Double = (dblIGV / 100) * oVenta.TOTAL_VENTA
                                oVenta.SUBTOTAL_IMPUESTO = dblImpuesto
                                oVenta.SUBTOTAL_VENTA = oVenta.TOTAL_VENTA - dblImpuesto
                                oVenta.TVENC_CODIGO = "01"
                                oVenta.USUARIO_CREA = CurrentUser
                                oVenta.NUMERO_CUOTAS = 0
                                oVenta.VENDEDOR = CurrentUser

                                If CheckStr(hidCodEstadoSEC.Value) = constEstadoEnvCreditos Then
                                    oVenta.ESTADO = constVentaRegistrado
                                Else
                                    oVenta.ESTADO = constVentaAprobado
                                End If

                                oVentaDetalle.ORDEN = 1
                                oVentaDetalle.MATERIAL = oPlanDetalle.MATERIAL
                                oVentaDetalle.MATERIAL_DESC = oPlanDetalle.MATERIAL_DESC
                                oVentaDetalle.PLAN = oPlanDetalle.PLANC_CODIGO
                                oVentaDetalle.PLAN_DESC = oPlanDetalle.PLANV_DESCRIPCION
                                oVentaDetalle.CAMPANA = oPlanDetalle.CAMPANA
                                oVentaDetalle.CAMPANA_DESC = oPlanDetalle.CAMPANA_DESC
                                oVentaDetalle.DESCUENTO = 0
                                oVentaDetalle.PLAZO = oPlanDetalle.PACUC_CODIGO

                                Dim oGarantia As Renta = ConsultarRenta(oPlanDetalle.PRDC_CODIGO)
                                If oGarantia.importe > 0 And hidCodEstadoSEC.Value = constEstadoAPR Then
                                    Dim objGarantia As New AP_Garantia
                                    Dim claseDocumento As String = ConfigurationSettings.AppSettings("codTipGarantiaDTH")
                                    objGarantia.GARAC_TIPO_DOC_CLIENTE = hidTipoDocumento.Value
                                    objGarantia.GARAV_NRO_DOC_CLIENTE = hidNroDocumento.Value
                                    objGarantia.GARAN_MONTO_GARANTIA = oGarantia.importe
                                    objGarantia.GARAV_OFICINA = strCodOficina
                                    objGarantia.GARAV_USUARIO_CREA = CurrentUser
                                    objGarantia.GARAN_NRO_CARGOS = oGarantia.nroRenta
                                    objGarantia.GARAC_TIPO_GARANTIA = oGarantia.codGarantia
                                    objGarantia.CLASE_DOC_SAP = claseDocumento

                                    oSolicitudDTH.GARANTIA_DTH = objGarantia
                                End If

                                oSolicitudDTH.VENTA_DTH = oVenta
                                oSolicitudDTH.VENTA_DET_DTH = oVentaDetalle
                                oPlanDetalle.PLAN_SOL_DTH = oSolicitudDTH

                            Else
                                Session("CambioTitularidadDTH") = "1"
                            End If
                        End If

                        arrDetallePlan.Add(oPlanDetalle)
                    End If
                End If
            Next

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR  --> ObtenerDetalleHFC : " & ex.Message)
            Throw ex
        End Try

        Return arrDetallePlan

    End Function

    Private Function ObtenerDetalleHFC(ByVal idxFila As String, ByRef dblCF As Double) As PlanSolicitudHFC

        Dim strCadenaEvaluacion As String = CheckStr(hidCadenaDetalle.Value)
        Dim arrPlanes() As String = strCadenaEvaluacion.Split("|")
        Dim arrPlan As String()
        Dim arrDetallePlan As New ArrayList
        Dim arrSrv3Play As New ArrayList

        Dim oPlanSolHFC As New PlanSolicitudHFC
        Dim arrPlanSolHFC As New ArrayList

        Dim arrPlanDetHFC As New ArrayList
        Dim strAgrupaPaquete As String = hidGrupoPaqueteServer.Value

            Dim strFilasGrupo As String = ObtenerFilasGrupo(idxFila)

            For Each strPlanes As String In arrPlanes
                If strPlanes.Length > 0 Then
                    Dim strPlanFila As String() = strPlanes.Split(";")

                    Dim idFila As String = strPlanFila(0)
                    Dim strTipoProducto As String = strPlanFila(1)

                    'Producto HFC
                    If strTipoProducto = ConfigurationSettings.AppSettings("CodTipoProductoHFC") And _
                        strFilasGrupo.IndexOf(idFila) > -1 Then

                        dblCF = dblCF + CheckDbl(strPlanFila(23))

                        If idFila = idxFila Then

                            oPlanSolHFC.IdPlazo = strPlanFila(2)
                            oPlanSolHFC.Plazo = strPlanFila(3)
                            oPlanSolHFC.IdSolucion = strPlanFila(4)
                            oPlanSolHFC.Solucion = strPlanFila(5)
                            oPlanSolHFC.IdPaquete = strPlanFila(6).Split("_")(0)
                            oPlanSolHFC.Paquete = strPlanFila(7)
                            oPlanSolHFC.Usuario = CurrentUser

                            'Consulta Servicio HFC x Paquete
                            arrSrv3Play = (New ConsumerNegocio).ListarPlanesXPaquete3Play(oPlanSolHFC.IdPaquete)

                            'Promocion HFC
                            oPlanSolHFC.Promocion = ObtenerPromocionHFC(strFilasGrupo)
                        End If

                        'Servicio Principal
                        Dim oPlanDetHFC As New PlanDetalleHFC
                        arrPlan = strPlanFila(10).Split("_")
                        oPlanDetHFC.IDDET = arrPlan(0).Split(".")(0)
                        oPlanDetHFC.IdProducto = arrPlan(0).Split(".")(1)
                        oPlanDetHFC.IdLinea = arrPlan(0).Split(".")(2)

                        For Each srv As ServicioHFC In arrSrv3Play
                            If srv.IDDET = oPlanDetHFC.IDDET And srv.IdProducto = oPlanDetHFC.IdProducto And srv.IdLinea = oPlanDetHFC.IdLinea Then
                                oPlanDetHFC.Producto = srv.Producto
                                oPlanDetHFC.Grupo = srv.Grupo
                                oPlanDetHFC.IdServicio = srv.IdServicio
                                oPlanDetHFC.Servicio = srv.Servicio
                                oPlanDetHFC.IdEquipo = srv.IdEquipo
                                oPlanDetHFC.Equipo = srv.Equipo
                                oPlanDetHFC.FlagPrincipal = "1"
                                oPlanDetHFC.Cantidad = srv.CantVenta
                                oPlanDetHFC.Orden = idFila
                                oPlanDetHFC.Agrupa = hidGrupoPaqueteServer.Value
                                oPlanDetHFC.Precio = srv.CF_Precio
                                Exit For
                            End If
                        Next

                        'oPlanDetHFC.Precio = CheckDbl(strPlanFila(26))
                        oPlanDetHFC.CF_Linea = CheckDbl(strPlanFila(23))

                        'Servicios Opcional
                        Dim arrSrvDetHFC As ArrayList = ObtenerServicioHFC(idFila, arrSrv3Play)
                        arrSrvDetHFC.Insert(0, oPlanDetHFC)

                        'Servicio
                        For Each item As PlanDetalleHFC In arrSrvDetHFC
                            arrPlanDetHFC.Add(item)
                        Next
                    End If

                End If
            Next

            oPlanSolHFC.Servicio = arrPlanDetHFC


        Return oPlanSolHFC

    End Function

    Private Function ObtenerFilasGrupo(ByVal idFila As String)
        Dim strAgrupaPaquete As String = hidGrupoPaqueteServer.Value
        Dim arrAgrupaPaquete As String() = strAgrupaPaquete.Split("}")
        Dim strCadenaId As String
        For Each item As String In arrAgrupaPaquete
            strCadenaId = item.Replace("{", "").Replace("[", "").Replace("]", "") & ","
            If (strCadenaId.IndexOf("," & idFila & ",") > -1) Then
                Exit For
            End If
        Next
        Return strCadenaId
    End Function

    Private Function ObtenerServicio(ByVal idPlan As String) As ArrayList
        Dim arrServicio As New ArrayList
        Dim strCadenaServicio As String = CheckStr(hidServicioServer.Value).Replace("(*)", "")
     
            Dim arrListaServicio() As String = strCadenaServicio.Split("*ID*")
            For Each strSrv As String In arrListaServicio
                If strSrv.Length > 0 Then
                    Dim arrSrvPlan As String() = strSrv.Split("|")
                    Dim idSrv As String = arrSrvPlan(0)

                    If idSrv = idPlan Then
                        For Each str As String In arrSrvPlan
                            Dim arrSrvPlanFila As String = str.Split(";")(0)
                            If arrSrvPlanFila.Split("_").Length > 1 Then
                                Dim oServicio As New SecServicio_AP
                                oServicio.SOPLN_ORDEN = idSrv
                                oServicio.SERVV_CODIGO = arrSrvPlanFila.Split("_")(3)
                                oServicio.CARGO_FIJO_BASE = arrSrvPlanFila.Split("_")(4)
                                oServicio.SERVV_USUARIO_CREA = CurrentUser
                                '-------Roaming------------
                                oServicio.SERVC_ESTADO = Nothing
                                If arrSrvPlanFila.Split("_").Length >= 8 Then
                                    If Not arrSrvPlanFila.Split("_")(5).Equals(String.Empty) Then
                                        oServicio.SERVC_ESTADO = ConfigurationSettings.AppSettings("ConstPendienteProcesar")
                                    End If
                                    oServicio.SERVC_PLAZO = arrSrvPlanFila.Split("_")(5)
                                Else
                                    oServicio.SERVC_PLAZO = Nothing
                                End If
                                If arrSrvPlanFila.Split("_").Length >= 8 AndAlso arrSrvPlanFila.Split("_")(6) <> "" Then
                                    oServicio.SERVD_FECHA_ACTIVACION = Date.Parse(arrSrvPlanFila.Split("_")(6))
                                Else
                                    oServicio.SERVD_FECHA_ACTIVACION = Nothing
                                End If
                                If arrSrvPlanFila.Split("_").Length >= 8 AndAlso arrSrvPlanFila.Split("_")(7) <> "" Then
                                    If arrSrvPlanFila.Split("_")(5) = ConfigurationSettings.AppSettings("codPlazoDeterminado") Then
                                        oServicio.SERVD_FECHA_DESACTIVACION = Date.Parse(arrSrvPlanFila.Split("_")(7))
                                    Else
                                        oServicio.SERVD_FECHA_DESACTIVACION = Nothing
                                    End If
                                Else
                                    oServicio.SERVD_FECHA_DESACTIVACION = Nothing
                                End If

                                '----------------------------------------------
                                arrServicio.Add(oServicio)
                            End If
                        Next
                    End If
                End If
            Next
 

        Return arrServicio
    End Function

    Private Function ObtenerServicioHFC(ByVal idPlan As String, ByVal arrSrv3Play As ArrayList) As ArrayList
        Dim arrServicio As New ArrayList
    
            Dim arrSrvHFC As ArrayList = ObtenerServicio(idPlan)
            For Each item As SecServicio_AP In arrSrvHFC
                Dim Iddet As Int64 = CheckInt64(item.SERVV_CODIGO.Split(".")(0))
                Dim IdProducto As Int64 = CheckInt64(item.SERVV_CODIGO.Split(".")(1))
                Dim IdLinea As Int64 = CheckInt64(item.SERVV_CODIGO.Split(".")(2))

                For Each srv As ServicioHFC In arrSrv3Play
                    If srv.IDDET = Iddet And srv.IdProducto = IdProducto And srv.IdLinea = IdLinea Then

                        Dim oPlanDetHFC As New PlanDetalleHFC
                        oPlanDetHFC.IDDET = Iddet
                        oPlanDetHFC.IdProducto = IdProducto
                        oPlanDetHFC.IdLinea = IdLinea
                        oPlanDetHFC.Producto = srv.Producto
                        oPlanDetHFC.Grupo = srv.Grupo
                        oPlanDetHFC.IdServicio = srv.IdServicio
                        oPlanDetHFC.Servicio = srv.Servicio
                        oPlanDetHFC.IdEquipo = srv.IdEquipo
                        oPlanDetHFC.Equipo = srv.Equipo
                        oPlanDetHFC.Equipo = srv.Equipo
                        oPlanDetHFC.FlagPrincipal = "0"
                        oPlanDetHFC.Cantidad = srv.CantVenta
                        oPlanDetHFC.Precio = item.CARGO_FIJO_BASE

                        arrServicio.Add(oPlanDetHFC)
                        Exit For
                    End If
                Next
            Next
   

        Return arrServicio
    End Function

    Private Function ObtenerPromocionHFC(ByVal strFilasGrupo As String) As ArrayList
        Dim arrPromocion As New ArrayList
        Dim strCadenaPromocion As String = CheckStr(hidPromocionServer.Value)

            Dim arrPromociones() As String = strCadenaPromocion.Split("*ID*")
            For Each strProm As String In arrPromociones
                If strProm.Length > 0 Then
                    Dim arrPromPlan As String() = strProm.Split("|")
                    Dim idFila As String = arrPromPlan(0)

                    If (strFilasGrupo.IndexOf(idFila) > -1) Then
                        For Each str As String In arrPromPlan
                            Dim arrPromPlanFila As String = str.Split(";")(0)
                            If arrPromPlanFila.Split("_").Length > 1 Then
                                Dim strCodProm As String = arrPromPlanFila.Split("_")(3)
                                Dim oPromocion As New PlanPromocionHFC
                                oPromocion.IDDET = strCodProm.Split(".")(0)
                                oPromocion.IdProducto = strCodProm.Split(".")(1)
                                oPromocion.IdLinea = strCodProm.Split(".")(2)
                                oPromocion.IdPromocion = strCodProm.Split(".")(3)
                                oPromocion.Promocion = str.Split(";")(1)
                                arrPromocion.Add(oPromocion)
                            End If
                        Next
                    End If
                End If
            Next
      

        Return arrPromocion
    End Function

#End Region


#Region "Consolidado CAC"

    Private Sub CargarMotivoRenovacionChip()

        Dim estado As String = ConfigurationSettings.AppSettings("constCodMotivoEstado")
        Dim tipo_ope As String = ConfigurationSettings.AppSettings("constCodMotivo")
        Dim lista As ArrayList = (New MaestroNegocio).ListaMotivoRenovacionChip(tipo_ope, estado)


        'Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        'lista.Insert(0, oItem)
        'Dim oItemTemp As New ItemGenerico

        'oItemTemp = lista(1)
        'lista(1) = lista(2)
        'lista(2) = oItemTemp

        LlenaCombo(lista, dllMotivoDAC, "Codigo", "Descripcion")
        LlenaCombo(lista, ddlRenovChip, "Codigo", "Descripcion")
    End Sub

    'Private Sub CargarArticuloIMEI(ByVal strOficinaPDV As String)
    '    Dim lista As New ArrayList
    '    Dim listaMaterial As New ArrayList
    '    Dim tipoVenta As String = hidPuntoVenta.Value

    '    'hidOfVenta.Value = "0006" '"S025" ' "D016"

    '    lista = (New SapGeneralNegocios).get_ConsultaMaterial(Now.ToString("yyyy/MM/dd"), "", tipoVenta, strOficinaPDV, "")

    '    For Each it As ItemGenerico In lista
    '        If CheckStr(it.Codigo).StartsWith("PB") Then
    '            listaMaterial.Add(it)
    '        End If
    '    Next

    '    Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
    '    listaMaterial.Insert(0, oItem)
    '    LlenaCombo(listaMaterial, ddlCodEquipo, "Codigo", "Descripcion")

    '    ddlCodEquipo.Attributes.Add("onChange", "f_CambiaImei()")

    'End Sub


    'Private Function CargarArticuloIMEI(ByVal strOficinaPDV As String) As ArrayList
    '    Dim lista As New ArrayList
    '    Dim listaMaterial As New ArrayList
    '    Dim tipoVenta As String = hidPuntoVenta.Value
    '    Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
    '    Dim strCampana, strPlan As String

    '    'hidOfVenta.Value = "0006" '"S025" ' "D016"

    '    For Each plan As PlanDetalleVenta In arrPlanDetalle
    '        strCampana = plan.CAMPANA
    '        strPlan = plan.PLANC_CODIGO
    '        Exit For
    '    Next

    '    'lista = (New SapGeneralNegocios).get_ConsultaMaterial(Now.ToString("yyyy/MM/dd"), "", tipoVenta, strOficinaPDV, "")
    '    lista = (New SapGeneralNegocios).get_ConsultaMaterialRe(strCampana, strOficinaPDV, hidOrgVenta.Value, hidCentro.Value, strPlan, Nothing)

    '    For Each it As ItemGenerico In lista
    '        'If CheckStr(it.Codigo).StartsWith("PB") Then
    '        listaMaterial.Add(it)
    '        'End If
    '    Next

    '    Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
    '    listaMaterial.Insert(0, oItem)

    '    'LlenaCombo(listaMaterial, ddlCodEquipo, "Codigo", "Descripcion")

    '    ddlCodEquipo.Attributes.Add("onChange", "f_CambiaImei()")

    '    Return listaMaterial

    'End Function

   
    'PROY-24740
    <Anthem.Method()> _
    Public Function CargarMaterialesPostpago(ByVal codpdv As String)
        Dim listaMateriales As New ArrayList
        Dim listaMaterialesRepo As New ArrayList
        Dim lista As New ArrayList
        Dim consGrupoChip As String = ConfigurationSettings.AppSettings("consGrupoChip")
        Dim strResultado As New StringBuilder
        Dim oConsultaMSS As New ConsultaMsSapNegocio
        Dim Canal As String = hidPuntoVenta.Value
        lista = oConsultaMSS.ConsultarStock(CheckStr(codpdv), "", Canal)

        For Each it As ItemGenerico In lista
            'Filtra chips LTE
            If CheckStr(it.tipoMaterial) = consGrupoChip Then
                listaMateriales.Add(it)
            End If
        Next

        Dim listaMaterialRepo As New ArrayList
        Dim codParam As String = ConfigurationSettings.AppSettings("consCodParamMaterialesCAC")
        listaMaterialRepo = New ConsumerNegocio().ListarParametroGeneral(codParam)

        For Each i As ItemGenerico In listaMateriales
            For Each j As ParametroConsumer In listaMaterialRepo
                If CheckStr(i.Codigo) = CheckStr(j.PCONV_VALOR) Then
                    listaMaterialesRepo.Add(i)
                End If
            Next
        Next

        For Each objMaterial As ItemGenerico In listaMaterialesRepo
            strResultado.AppendFormat("|{0};{1}", objMaterial.Codigo, objMaterial.Descripcion)
        Next

        Return strResultado.ToString()
    End Function

    Private Sub ConsultarDatosVenta()

        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        Dim usuario As String = CurrentUser()
        Dim oUsuarioNegocio As New LoginUsuarioNegocios
        Dim oUsuario As New usuario
        oUsuario = oUsuarioNegocio.ConsultaDatosUsuario(usuario)

        oPar = oConsultaMSSAP.ParametrosOficina(Funciones.CheckStr(oUsuario.OficinaId))    'ParametrosOficinaVenta(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(Funciones.CheckStr(oUsuario.OficinaId), "")

        'Dim dsOficina As DataSet = (New SapGeneralNegocios).ConsultarParametrosOfVenta(oUsuario.OficinaId)
        Dim strCanal As String = oParPVU.canal 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        Dim strOrgVenta As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia")) 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))
        Dim strCentro As String = oParPVU.codigoCentro 'CheckStr(dsOficina.Tables(0).Rows(0).Item("WERKS"))


        'Dim oConsultarSap As New SapGeneralNegocios
        'Dim dsOficina As New DataSet
        'dsOficina = oConsultarSap.ConsultarParametrosOfVenta(CheckStr(hidOfVentaCod.Value))

        canalOf = strCanal 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidCanalOf.Value = strOrgVenta 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidOrgVenta.Value = strCentro 'CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))

        'dsOficina = Nothing
        'oConsultarSap = Nothing

        ' Inicio E77568
        Dim objVenta As New VentaExpressNegocios
        Dim descuento As Double = 0.0
        Dim meses As Double = 0
        Dim descuentoMax As Double = 0.0
        Dim mesesMax As Double = 0
        objVenta.ObtenerMontoMaxDescuentoAS(descuento, meses)

        objVenta.ObtenerMontoMaxMinDescuentoAS(descuentoMax, mesesMax, descuento, meses)

        hidMontoMaxDesASMax.Value = CheckStr(descuentoMax)
        hidMesesMaxASMax.Value = CheckStr(mesesMax)

        'Inicio Renovacion anticipada mayor a 12 meses
        hidMesesMaxASMaxDias.Value = (mesesMax * 30).ToString
        hidMesesMaxASDias.Value = (meses * 30).ToString
        'Fin Renovacion anticipada mayor a 12 meses

        hidMontoMaxDesAS.Value = CheckStr(descuento)
        hidMesesMaxAS.Value = CheckStr(meses)
        oLog.Log_WriteLog(strArchivo, " - " & CheckStr(descuento))
        oLog.Log_WriteLog(strArchivo, " - " & CheckStr(meses))
        objVenta = Nothing
        ' Fin E77568
        'Inicio Falla SD820360
        Try
            oLog.Log_WriteLog(strArchivo, "Validacion Nivel Aprob Meses" & " - Iniciando...")
            Dim oNiveles As New NivelAprobacionNegocio
            Dim nCanMaxima As Double = 0.0
            Dim nCanMinima As Double = 0.0


            oNiveles.ObtenerCantidadMaxMinAutorizacion(nCanMaxima, nCanMinima)

            oLog.Log_WriteLog(strArchivo, "Validacion Nivel Aprob Meses" & " - Cantidad Maxima Meses:" & CheckStr(nCanMaxima))
            oLog.Log_WriteLog(strArchivo, "Validacion Nivel Aprob Meses" & " - Cantidad Maxima Minima:" & CheckStr(nCanMinima))

            hdCanMaxMeses.Value = CheckStr(nCanMaxima)
            hdCanMinMeses.Value = CheckStr(nCanMinima)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, "Validacion Nivel Aprob Meses" & " - ERROR:" & ex.Message)
        End Try
        'Fin Falla SD820360
    End Sub

    'jmori add method

    Private Function GenerarNotaDebito(ByRef documentoSAPNotaDebito As String, ByVal idPedidoMsSap As String) As Boolean

        Dim montodescuento = Double.Parse(hidReintegro.Value)

        Try
            GenerarProcesoNotaCredito(montodescuento, documentoSAPNotaDebito, True, hidReintegro.Value, idPedidoMsSap)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception GenerarNotaDebito()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception. Generar Nota de Debito - " & ex.Message)

            Throw New Exception("No se pudo Generar la Nota de Debito.")
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaDebito()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaDebito()")
        End Try

    End Function

    'INC000001019296-INICIO
    Private Sub ActualizaInfoVentaSAP(ByVal montoTotal, ByVal factura, ByVal idVenta, ByVal nroContrato, ByVal accion)
        Try
            Dim oVentaExpress As New VentaExpressNegocios
            Dim dsPedido As DataSet = New BLConsultaMssap().ConsultaPedido(factura, "")
            Dim TotalMonto As Decimal = montoTotal
            Dim codRpta, codRpta2 As String

            oLog.Log_WriteLog(strArchivo, factura & " - " & accion & " Info Venta Sap")
            If (Not dsPedido Is Nothing AndAlso dsPedido.Tables.Count > 0) Then
                TotalMonto = dsPedido.Tables(0).Rows(0)("INPAN_TOTALDOCUMENTO")
                oLog.Log_WriteLog(strArchivo, factura & " - Obtener total venta Pedido [TotalMonto]:" & TotalMonto.ToString())
            Else
                oLog.Log_WriteLog(strArchivo, factura & " - Error al Obtener total venta Pedido [TotalMonto]:" & TotalMonto.ToString())
                Throw New Exception("Error al traer datos del pedido " & factura)
            End If

            oLog.Log_WriteLog(strArchivo, factura & " - Inicio Grabar InfoVentaSap [idVenta]:" & idVenta)
            codRpta = oVentaExpress.GrabarInfoVentaSap(idVenta, Funciones.CheckStr(nroContrato), 1, factura, "F", TotalMonto)
            codRpta2 = oVentaExpress.GrabarInfoVentaSap(idVenta, Funciones.CheckStr(nroContrato), 1, Funciones.CheckStr(nroContrato), "A", TotalMonto)
            oLog.Log_WriteLog(strArchivo, factura & " - Fin Grabar InfoVentaSap [idVenta]:" & idVenta)

            If (codRpta = "0" And codRpta2 = "0") = False Then
                oLog.Log_WriteLog(strArchivo, factura & " - Error GrabarInfoVentaSap del pedido : " & factura)
                Throw New Exception("Error al Grabar en  InfoVentaSap " & factura)
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, factura & " - Error " & ex.Message)
            Throw New Exception(ex.Message)
        End Try
    End Sub
    'INC000001019296-FIN

    'end jmori

    Private Sub GenerarPedidoCAC(ByVal idVenta As Int64, ByVal nroContrato As String)
        Dim oVentaExpress As New VentaExpressNegocios
        Dim strScript As String = ""
        Dim cadenaCabecera As String
        Dim cadenaDetalle As String
        Dim cadenaAcuerdo As String
        Dim cadenaServicios As String
        Dim oConsultaSap As New SapGeneralNegocios

        strIdentifyLog = hidNroLinea.Value()
        Dim nroSec As String = String.Empty
        nroSec = hidNroSEC.Value()
        Dim nroDocumentoCli As String = String.Empty
        nroDocumentoCli = hidNroDocumento.Value
        Dim entrega, factura, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal
        Dim rspRB As String
        Dim montoTotal As Double
        Dim NroCuotas As String = hidCuota.Value
        Dim iCuota As New Cuota
        Dim nombres As String = hidNombre.Value & " " & hidApePaterno.Value & " " & hidApeMaterno.Value

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        'INICIO IMP SD_818878
        Dim e_Fidelizacion As String = ""
        Dim e_ClaroPuntos As String = ""
        Dim e_RecalculoDescuento As String = ""
        Dim e_GeneraOCC As String = ""
        Dim blnBloqueo As Boolean = False
        'FIN IMP SD_818878

        Dim resultado As Boolean = False 'PROY 26366?

        Try

            InicioPedido()
            cadenaCabecera = GenerarCadenaCabeceraMSS()
            cadenaDetalle = GenerarCadenaDetalleMSS(montoTotal)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Generar Pedido CAC")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> Cabecera CAC : " & cadenaCabecera)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> Detalle CAC : " & cadenaDetalle)
 

            Dim oRegPed As New ConsultaMsSapNegocio
            Dim idPedidoMsSap As Int64 = 0
            Dim strCodRspt As String = String.Empty
            Dim strMensRspt As String = String.Empty
            Dim pedidoGenerado As Boolean
            Try
                oRegPed.RegistrarPedido(cadenaCabecera, cadenaDetalle, idPedidoMsSap, strCodRspt, strMensRspt)


                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strCodRspt  : " & strCodRspt)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strMensRspt  : " & strMensRspt)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> nroPedido: " & CheckStr(idPedidoMsSap))

            If (idPedidoMsSap > 0) Then
                nroPedido = CheckStr(idPedidoMsSap)
                factura = CheckStr(idPedidoMsSap)
                pedidoGenerado = True
            Else
                pedidoGenerado = False
            End If
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> pedidoGenerado: " & pedidoGenerado)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> nroContrato: " & nroContrato)
                strNroPedCabProtMovil = nroPedido 'PROY-24724-IDEA-28174
            Catch ex3 As Exception
                factura = CheckStr(idPedidoMsSap)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Error al grabar el detalle  : " & factura)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> idPedidoMsSap: " & idPedidoMsSap)
                Throw New Exception("No se pudo Generar el Pedido.")
            End Try

            'consolidado 16012015

            Try
                oVentaExpress.ActualizarContratoSolicitud(CheckInt64(hidNroSEC.Value), nroContrato)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "Fin ActualizarContratoSolicitud")
            Catch ex2 As Exception
                Dim Mensaje As String = ex2.Message.ToString
                Mensaje = QuitarSaltosLinea(Mensaje, " ")
                Mensaje = Mensaje.Replace(Environment.NewLine, " ")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "Error ActualizarContratoSolicitud")
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & Mensaje)
            End Try
            'consolidado 16012015
            If Not (idPedidoMsSap > 0) Then
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> idPedidoMsSap: " & idPedidoMsSap)
                Throw New Exception("No se pudo Generar el Pedido.")
            Else
                'consolidado 21012015

                If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Then
                    nombres = hidRazonSocial.Value
                End If

                ' Generar Renta o Depósito
                Dim dblMontoDeposito As Double
                Dim sTipoDeposito As String
                Dim sTipoGarantia As String
                Dim cadenaDeposito As String = ""
                Dim nroDeposito As String

                'If NroCuotas <> "00" Then
                '    oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & " NroCuotas: " & NroCuotas)
                '    Dim strMaterialImei As String
                '    Dim strImei As String
                '    If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                '        strMaterialImei = CheckStr(txtCodEquipo.Text)
                '        strImei = CheckStr(hidIMEI.Value)
                '    Else
                '        strMaterialImei = CheckStr(txtMaterialImei.Text)
                '        strImei = CheckStr(txtImei.Text)
                '    End If
                '    oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & " Grabar cuotas: " & NroCuotas)
                '    GrabarCuotas(nroContrato, factura, hidNroLinea.Value, nroPedido)
                '    With iCuota
                '        .CUOV_NRO_CONTRATO = nroContrato
                '        .CUON_NRO_CUOTA = CheckInt(NroCuotas)
                '        .CUON_MONTO = montoTotal
                '        .CUOV_USUARIO_REG = CurrentUser
                '        .CUOD_FECHA_EMISION = CheckDate(ObtenerFechaEmision())
                '        .CUOV_NRO_DOC_SAP = nroPedido
                '        .CUOV_NRO_CELULAR = hidNroLinea.Value
                '        .CUOV_MATE = strMaterialImei
                '        .CUOV_IMEI = strImei
                '        .CUOV_NOM_CLIENTE = nombres  ''objDeta.K_NOMCLIENTE
                '        .CUOV_NRO_DOC_CLIENTE = hidNroDocumento.Value
                '        .OFICINA = strCodOficina
                '        .FLAG_ENVIO = "0"
                '        .CUENTA_BSCS = hidCuentaBSCS.Value
                '        .CUSTOMER_ID = hidCustumerId.Value
                '        .CONTRATO_SISACT = nroContrato
                '        .CICLO_FACTURACION = hidCicloFact.Value
                '    End With
                '    oVentaExpress.GrabarCuotas(iCuota)
                'End If

                'GRABAR PEDIDO EN SISACT
                Dim DetalleRenovSap As Boolean
                Dim nroDepositoSisact As String
                Dim montoDepositoSisact As Double
				
             
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Factura:" & factura)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Contrato:" & nroContrato)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Pedido:" & nroPedido)
                			
				
                DetalleRenovSap = GenerarDetalleRenovSap(factura, nroContrato, nroPedido)

                If DetalleRenovSap Then
                    hidNroPedido.Value = nroPedido
                    hidnroContrato.Value = nroContrato

                    Dim documentoSAPNotaCredito As String = ""

                    'GENERAR NOTA DE CREDITO POR DESCUENTO EN EQUIPO.
                    If hidFlagDescuento.Value = "true" And hidDescuento.Value <> "" Then
                        Try

                            Dim consecutivo As String = "1"

                            If hidValidarIccid.Value.Equals("1") Then
                                consecutivo = "2"
                            End If

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GenerarNotaCredito() ")
                            'GenerarNotaCredito(documentoSAPNotaCredito, idPedidoMsSap)
                            Dim montoDescuentoDivididoFidelizacion As Decimal = Funciones.CheckDecimal(hidDescuento.Value)
                            Dim nroLog, desLog, nroLogEsquemaF, nroLogDesEsquemaF As String
                            oRegPed.ActualizarDescuentoPedido(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), ConfigurationSettings.AppSettings("constSINERGIAClaseCondicion52"), montoDescuentoDivididoFidelizacion, nroLog, desLog)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Fidelizados actualizado ==> " & nroLog)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Fidelizados actualizado ==> " & desLog)
                            oRegPed.RecalculaEsquema(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), nroLogEsquemaF, nroLogDesEsquemaF)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogEsquemaF)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogDesEsquemaF)
                            'Inicio RNP 16/09/2015
                            oVentaExpress.InsertaVtaFidelizacion(hidNroDocumento.Value, idVenta, nroContrato, idPedidoMsSap, montoDescuentoDivididoFidelizacion, hidOficina.Value, CurrentUser)
                            '************************************************************************************************'
                        Catch ex As Exception
							'INICIO IMP SD_818878
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Rollback Fidelizacion")

                            e_Fidelizacion = "Error al generar descuento por Fidelizacion. " & ex.Message

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "idVenta ==> " & idVenta)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "nroContrato ==> " & nroContrato)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "idPedidoMsSap ==> " & idPedidoMsSap)

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio ActualizaEstadoFidelizacion")
                            'Rollback SP_UPD_EST_FIDELIZACION
                            oVentaExpress.ActualizaEstadoFidelizacion(idVenta, nroContrato, idPedidoMsSap, "1") 'PROY-26366 - Estado se mantiene en 1
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin ActualizaEstadoFidelizacion")

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception GenerarNotaCredito() - Mensaje: " & ex.Message)
                            'Throw ex
							'FIN IMP SD_818878
                        Finally
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GenerarNotaCredito() ")
                        End Try
                    End If

                    Dim documentoSAPNotaCreditoCC As String
                    'gaa20160607
                    Dim strB2E As String = ConfigurationSettings.AppSettings("strPostTipClienteB2E")
                    Dim datosLinea As ClienteBSCS = Session("Cliente")
                    'If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 Then
                    If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
                        Try

                            Dim consecutivo As String = "1"

                            If hidValidarIccid.Value.Equals("1") Then
                                consecutivo = "2"
                            End If

                            ' Hacer Reserva Puntos CC
                            bloquearPuntos()

							'IMP
                            blnBloqueo = True

                            'BYM
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Registrar ClaroPuntos() ")
                            RegistrarCanjePuntos(factura, nroContrato, nroPedido, resultado) 'PROY 26366? NUEVO PARAMETRO resultado
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Registrar ClaroPuntos() ")

                            'INICIO PROY-26366 FIDELIZACION Y CLAROPUNTOS FASE2

                            Dim descuentototalsoles As Decimal = Funciones.CheckDecimal(txtDescuentoClaroClub.Text)
                            Dim descuentototalCP As Decimal = Funciones.CheckDecimal(txtClaroClubPuntosUtilizar.Text)
                            Dim cantidadequipoventa As Decimal = 1.0 'Renovacion solo un Equipo.

                            If (resultado = True) Then

                                oLog.Log_WriteLog(strArchivo, "**************************************************")
                                oLog.Log_WriteLog(strArchivo, "Inicio registro Detalle de Claro Puntos por equipo")
                                oLog.Log_WriteLog(strArchivo, "**************************************************")

                                If (Not Funciones.CheckStr(descuentototalsoles) Is Nothing) AndAlso descuentototalsoles > 0 AndAlso descuentototalCP > 0 Then

                                    Dim objParametro As New MaestroNegocio
                                    Dim listaClaroPuntos As New ArrayList
                                    Dim factor_parametro As New StringBuilder
                                    Dim idCanjePuntos As New StringBuilder

                                    Dim codigo_rpta As String = String.Empty
                                    Dim mensaje_rpta As String = String.Empty
                                    Dim strImei As String = String.Empty
                                    Dim parametroFactor As String = String.Empty

                                    If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                                        strImei = CheckStr(hidIMEI.Value)
                                    Else
                                        strImei = CheckStr(txtImei.Text)
                                    End If

                                    Dim consfactorDescuentoClaroPuntos As Int64 = Funciones.CheckInt64(ConfigurationSettings.AppSettings("consfactorDescuentoClaroPuntos"))
                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Key para Factor de Descuento : ", consfactorDescuentoClaroPuntos))

                                    Dim obeParametro As ArrayList = objParametro.ListaParametrosGrupo(consfactorDescuentoClaroPuntos)

                                    For Each item As Parametro In obeParametro
                                        If item.Valor1 = "1" Then
                                            factor_parametro.AppendFormat("{0}", item.Valor)
                                        End If
                                    Next
                                    parametroFactor = factor_parametro.ToString()

                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "% del Factor de Descuento : ", parametroFactor))

                                    Dim factor_desc As Decimal = Funciones.CheckDecimal(parametroFactor) / 100
                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Factor de Descuento en Porcentaje : ", factor_desc))

                                    Dim DescuentoSolesxEquipo As Decimal = Math.Round(((descuentototalsoles / cantidadequipoventa) * factor_desc), 2)
                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Monto soles usados por Equipo : ", DescuentoSolesxEquipo))

                                    Dim DecuentoCPxEquipo As Int64 = Funciones.CheckInt64(Math.Floor((descuentototalCP / cantidadequipoventa) * factor_desc))
                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "Claro Puntos usados por Equipo : ", DecuentoCPxEquipo))

                                    listaClaroPuntos = PuntosClaroClubNegocio.ListarDatosNCxDocSAP(factura)

                                    For Each item As Parametro In listaClaroPuntos
                                        idCanjePuntos.AppendFormat("{0}", item.Codigo)
                                    Next

                                    Dim ID_CANJE_PUNTOS As Int64 = Funciones.CheckInt64(idCanjePuntos.ToString())
                                    oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1}{2}", factura, "ID de la Tabla SISACT_CANJE_PUNTOS : ", ID_CANJE_PUNTOS))

                                    Dim registrarDetalleCP As Boolean = PuntosClaroClubNegocio.InsertarDetaClaroPuntos(ID_CANJE_PUNTOS, strImei, DecuentoCPxEquipo, DescuentoSolesxEquipo, codigo_rpta, mensaje_rpta)

                                    If registrarDetalleCP Then

                                        oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1} - {2} - {3} - {4} - {5} - {6}", factura, "Se Registro detalle de Claro Puntos de la serie", strImei, "con descuento en Claro Puntos de", DecuentoCPxEquipo, "y descuento en Soles de", DescuentoSolesxEquipo))

                                    Else
                                        oLog.Log_WriteLog(strArchivo, String.Format("[{0}] - {1} - {2}", factura, "Error al insertar el detalle de Claro Puntos por equipo de la Serie", strImei))

                                    End If

                                Else
                                    oLog.Log_WriteLog(strArchivo, "No se registro el detalle de Claro puntos por equipo, No se encontro Descuento")
                                End If

                            Else

                                oLog.Log_WriteLog(strArchivo, "No se registro el detalle de Claro puntos por equipo")

                            End If

                            oLog.Log_WriteLog(strArchivo, "**************************************************")
                            oLog.Log_WriteLog(strArchivo, "Fin registro Detalle de Claro Puntos por equipo")
                            oLog.Log_WriteLog(strArchivo, "**************************************************")
                            'FIN PROY-26366 FIDELIZACION Y CLAROPUNTOS FASE2


                            ' Generar Nota de Crédito Puntos Claro club
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GenerarNotaCreditoCC() ")
                            ' factura = nro doc SAP, de oConsultaSap.RealizarPedido().

                            Dim nroLog1, desLog1, nroLogEsquemaCP, nroLogDesEsquemaCP As String
                            oRegPed.ActualizarDescuentoPedido(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), ConfigurationSettings.AppSettings("constSINERGIAClaseCondicion53"), descuentototalsoles, nroLog1, desLog1) 'PROY-26366
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Claro Puntos actualizado ==> " & nroLog1)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Claro Puntos actualizado ==> " & desLog1)
                            oRegPed.RecalculaEsquema(Convert.ToInt32(idPedidoMsSap), Convert.ToInt32(consecutivo), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), nroLogEsquemaCP, nroLogDesEsquemaCP)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogEsquemaCP)
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de los esquemas de Fidelizados actualizado ==> " & nroLogDesEsquemaCP)

                        Catch ex As Exception

							'INICIO IMP SD_818878
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Rollback Claro Puntos ")

                            e_ClaroPuntos = "Error al generar Descuento Claro Puntos. " & ex.Message

                            If blnBloqueo Then
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception ClaroPuntos() - Mensaje: " & ex.Message)
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Liberar ClaroPuntos() ")
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "factura " & factura)

                                'Liberar Claro puntos WS
                            liberarPuntos(factura)
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Liberar ClaroPuntos() ")

                                'Elimina Registro de Canje de Puntos
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Eliminar Puntos SISACT")
                                EliminarCanjePuntos(factura)
                                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Eliminar Puntos SISACT")
                            End If

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception RegistrarCanjePuntos - Mensaje: " & ex.Message)
                            'Throw ex
							'FIN IMP SD_818878
                        Finally
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin RegistrarCanjePuntos() ")
                        End Try
                    End If

                    If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 Or (hidFlagDescuento.Value = "true" And hidDescuento.Value <> "") Then
                        'INICIO IMP SD_818878
                        'RecalculaDescuento
                        Try
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Recalcular Descuento")
                        Dim pnrologDescuento, pdeslogDescuento As String
                        oRegPed.RecalculaDescuento(Convert.ToInt32(idPedidoMsSap), ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta"), pnrologDescuento, pdeslogDescuento)
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Recalcula Descuento ==> " & pnrologDescuento)
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Retornar datos de Recalcula Descuento ==> " & pdeslogDescuento)
                        Catch ex As Exception

                            e_RecalculoDescuento = "Error al generar el recalculo del Descuento. " & ex.Message
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception Recalcular Descuento - Mensaje: " & ex.Message)
                        Finally
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Recalcular Descuento")
                        End Try
						'FIN IMP SD_818878
                    End If

                    If (idPedidoMsSap > 0) Then
                        oRegPed.actualizaPedido(nroPedido)
                    End If

                    'INC000001019296-INICIO
                    ActualizaInfoVentaSAP(montoTotal, factura, idVenta, nroContrato, "Insertar")

                    'GENERAR OCC
                    'gaa20160328 - MRAF
                    'If hidFlagReintegro.Value = "true" And hidFlagExonerarReintegro.Value = "false" Then
                    If hidFlagReintegro.Value = "true" And hidFlagExonerarReintegro.Value = "false" And Session("PenalidadBRMS") = "S" Then
                        Dim documentosapdebito As String

                        Try
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GenerarOCC() ")
                            'add jmori
                            If Not hidFormaPagoReintegro.Value.Equals("") Then

                                If hidFormaPagoReintegro.Value.Equals("01") Then
                                    GenerarOCC()
                                End If

                            End If
                            'end jmori

                        Catch ex As Exception

							'INICIO IMP SD_818878
                            e_GeneraOCC = "Error al generar OCC. " & ex.Message

                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Exception GenerarOCC() - Mensaje: " & ex.Message)
                            'Throw ex
							'FIN IMP SD_818878
                        Finally
                            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GenerarOCC() ")
                        End Try

                    End If

                    'Registra Auditoria de Grabar Pedido
                    Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
                    Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacion")
                    Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_GRABAR_RENOV_POST")
                    Dim desAuditoria As String = "Grabando Pedido. OK" & _
                                    "( Punto de venta:" & CheckStr(strCodOficina) & _
                                    " | Vendedor: " & CheckStr(CheckStr(Session("CodVendedorSAP"))) & _
                                    " | Nro de Telefono: " & CheckStr(hidNroLinea.Value) & _
                                    " | Tipo de Documento: " & CheckStr(hidTipoDocumento.Value) & _
                                    " | Numero de Identidad: " & CheckStr(hidNroDocumento.Value) & _
                                    " | Numero IMEI: " & CheckStr(txtImei.Text) & _
                                    " | Código de Material: " & CheckStr(txtMaterialImei.Text) & _
                                    " | Tipo de Venta: " & tipoVenta & _
                                    " | Tipo de Operacion: " & tipoOperacion & ")"

                    Auditoria(desAuditoria, strCodTrans)
                    hidMsg.Value = "El Pedido Nro: " & nroPedido & " para la Solicitud Nro: " & hidNroSEC.Value & " ha sido generado satisfactoriamente." & e_Fidelizacion & e_ClaroPuntos & e_RecalculoDescuento & e_GeneraOCC

                    If NroCuotas <> "00" Then 'SD_644347 - CUOTAS - INICIO
                        GrabarCuotas(nroContrato, factura, hidNroLinea.Value, nroPedido)
                    End If 'SD_644347 - CUOTAS - FIN

                    Dim cadenaCabeceraDeposito As String = ""
                    Dim nroDRAMssap As Integer = 0

                    cadenaDeposito = GenerarCadenaDepositoMSS(cadenaCabecera, nroContrato, nroPedido, nroSec, dblMontoDeposito, sTipoDeposito, sTipoGarantia)

                    oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "cadenaDeposito: " & cadenaDeposito)

                    If cadenaDeposito <> "" And cadenaDetalle <> "" Then
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Grabar Renta Adelantada")
                        Dim arrCadenaDRA As String

                        arrCadenaDRA = String.Format("{0}|{1}|{2}|{3}|{4}", dblMontoDeposito, nroContrato, idVenta, "1", sTipoDeposito)
                        nroDRAMssap = GenerarRentaAdelantadaMSSAP(nroPedido, cadenaCabecera, cadenaDetalle, arrCadenaDRA, cadenaDeposito, strIdentifyLog)

                        'actualizar monto de renta adelantada
                        oRegPed.actualizaPedido(nroDRAMssap)

                        nroDeposito = Funciones.CheckStr(nroDRAMssap)
                        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "out nroDeposito: " & nroDRAMssap)

                        oVentaExpress.actualizarDepositoGarantia(nroSec, nroDeposito, hidCustumerId.Value, sTipoGarantia)
						
						oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Grabar Renta Adelantada")
												
                    End If
					
                    'INC000001019296-INICIO
                    ActualizaInfoVentaSAP(montoTotal, factura, idVenta, nroContrato, "Actualizar")

					Dim respuesta As String
					Dim negDRA As New BLRentaAdelantada

					oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "INICIO ACTUALIZAR UBIGEO")
					oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp nroSec: " & nroSec)
					oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp nroDocumentoCli: " & nroDocumentoCli)
					negDRA.actualizarUbigeo(CheckInt64(nroSec), CheckStr(nroDocumentoCli), respuesta)
					oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "inp respuesta: " & respuesta)
					oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - " & "FIN ACTUALIZAR UBIGEO")

                Else
                    Throw New Exception("No se pudo crear pedido en SISACT.")
                End If
                'INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
                'inicio RegistrarAcuerdoReno
                oLog.Log_WriteLog(strArchivo, "PROY-9067 : Iniciando Metodo RegistrarAcuerdoReno")
                oLog.Log_WriteLog(strArchivo, "PROY-9067 : Input nroPedido")
                oLog.Log_WriteLog(strArchivo, "PROY-9067 : Input nroContrato")
                RegistrarAcuerdoReno(nroPedido, nroContrato)
                'fin RegistrarAcuerdoReno
                'FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
            End If

        Catch ex As Exception

			'INICIO IMP SD_818878
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Rollback de la Renovacion - GenerarPedidoCAC() ")

            'Anula Factura, Contrato, NroPedido en SISACT_VENTA_RENOVACION
            AnularVentaRenovacion(factura, nroSec)

            'Anula Nro de Contrato en la tabla SEC
            oVentaExpress.Set_Actualiza_Contrato_Solicitud(CheckInt64(nroSec), "00")

            'Anula Pedido SAP - Eliminina pedido en MSSAP
            RollBackVenta(factura)

            hidMsg.Value = " Error. Generar Pedido. " & ex.Message & e_Fidelizacion & e_ClaroPuntos & e_RecalculoDescuento & e_GeneraOCC
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Error  --> GenerarPedido: " & ex.Message)
            hidCodErrorPedido.Value = "1"

            'Elimina Contrato y Pedido en PVUDB
            oVentaExpress.RollBackVenta(idVenta, rspRB)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Rollback de la Renovacion - GenerarPedidoCAC() ")
			'FIN IMP SD_818878
        Finally
            oConsultaSap = Nothing
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Generar Pedido")
        End Try
    End Sub

    'PROY-24724-IDEA-28174 - INICIO 
    Private Sub GenerarPedidoPrima(ByVal NroPedido As String)

        Dim strcadenaCabecera As String = String.Empty
        Dim strcadenaDetalle As String = String.Empty
        Dim dblmontoTotal As Double
        Dim oRegPed As New ConsultaMsSapNegocio

        Dim intidPedidoMsSapRef As Int64 = 0
        Dim strCodRspt As String = String.Empty
        Dim strMensRspt As String = String.Empty
        Dim blnPedidoGenerado As Boolean
        Dim strNroPedido As String = String.Empty
        'Variables para EliminarProtecionMovil 
        Dim strFlagPedidoPrima As String = "GPP"
        Dim strNroCertificado As String = CheckStr(hidCertificadoPM.Value)
        Dim strPrecioServProtecMovil As String = Funciones.CheckStr(hidPrima.Value).Trim()
        Dim oPrecios As New PreciosMateriales
        Dim strPrecioSinIgv As String = String.Empty

        Try

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Inicio Consultar Precio sin IGV ")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input strPrecioServProtecMovil  : " & strPrecioServProtecMovil)

            oPrecios = oRegPed.Get_PrecioVenta(ClsKeyAPP.strCodMaterial_ServProtMovil, "", strPrecioServProtecMovil, strPrecioServProtecMovil) ' PROY-24724-IDEA-28174 Parametros

            strPrecioSinIgv = Funciones.CheckStr(oPrecios.decPrecioVenta)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Out strPrecioSinIgv  : " & strPrecioSinIgv)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  FIn Consultar Precio sin IGV ")

            'CabeceraPedido
            Dim arrayCabeceraPM(52) As String
            arrayCabeceraPM = strGenerarCadenaCabeceraMSSPM.Split(";")

            arrayCabeceraPM(2) = ClsKeyAPP.strClaseDocumentoPM 
            arrayCabeceraPM(4) = ClsKeyAPP.strCanalPM          
            arrayCabeceraPM(5) = ClsKeyAPP.strSectorPM         
            arrayCabeceraPM(8) = ClsKeyAPP.strMotivoPedidoPM  
            arrayCabeceraPM(12) = ClsKeyAPP.strClasePedidoPM   
            arrayCabeceraPM(13) = ClsKeyAPP.strCodTOperacionPM  
            arrayCabeceraPM(14) = ClsKeyAPP.strDescTOperacionPM 
            arrayCabeceraPM(20) = NroPedido
            arrayCabeceraPM(22) = ClsKeyAPP.strSINERGIAEsquemaPM 
            strcadenaCabecera = Join(arrayCabeceraPM, ";")

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & " Cadena de la cabecera(strCadenaCabecera) : " & strcadenaCabecera)

            Dim nuevaCadenaDetalle As String() = strGenerarCadenaDetalleMSSPM.Split(CChar("|"))

            If nuevaCadenaDetalle.Length > 1 Then
                For i As Integer = 1 To nuevaCadenaDetalle.Length - 1
                    Dim plan As String = nuevaCadenaDetalle(i)

                    Dim arrayItems() As String = plan.Split(";"c)

                    arrayItems(3) = ""
                    arrayItems(4) = ClsKeyAPP.strCodMaterial_ServProtMovil 
                    arrayItems(5) = ClsKeyAPP.strDesc_MaterialServProtMovil 
                    arrayItems(6) = "1"  'cantidad
                    arrayItems(7) = Funciones.CheckStr(strPrecioSinIgv)
                    arrayItems(12) = "0"
                    arrayItems(13) = ClsKeyAPP.strCodListaPrecio 
                    arrayItems(14) = ClsKeyAPP.strDescListaPrecioProtMovil 

                    nuevaCadenaDetalle(i) = ""
                    nuevaCadenaDetalle(i) = Join(arrayItems, ";")
                    strcadenaDetalle = ""
                    strcadenaDetalle = nuevaCadenaDetalle(i)
                    Exit For
                Next
            Else
                Dim arrayDetalle As String() = strGenerarCadenaDetalleMSSPM.Split(CChar(";"))
                arrayDetalle(3) = ""
                arrayDetalle(4) = ClsKeyAPP.strCodMaterial_ServProtMovil 
                arrayDetalle(5) = ClsKeyAPP.strDesc_MaterialServProtMovil  
                arrayDetalle(6) = "1"  'cantidad
                arrayDetalle(7) = Funciones.CheckStr(strPrecioSinIgv)
                arrayDetalle(12) = "0"
                arrayDetalle(13) = ClsKeyAPP.strCodListaPrecio 
                arrayDetalle(14) = ClsKeyAPP.strDescListaPrecioProtMovil  
                strcadenaDetalle = ""
                strcadenaDetalle = Join(arrayDetalle, ";")
            End If



            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Generar Pedido PM CAC")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  -->            Cabecera CAC : " & strcadenaCabecera)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  -->             Detalle CAC : " & strcadenaDetalle)

            oRegPed.RegistrarPedidoPM(strcadenaCabecera, strcadenaDetalle, strCodRspt, strMensRspt, intidPedidoMsSapRef)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output -->        Código Respuesta : " & strCodRspt)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output -->       Mensaje Respuesta : " & strMensRspt)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> Nro Pedido Prot. Movil. : " & intidPedidoMsSapRef)


            If (intidPedidoMsSapRef > 0) Then
                strNroPedido = Funciones.CheckStr(intidPedidoMsSapRef)
                blnPedidoGenerado = True
            Else
                blnPedidoGenerado = False
                hidErrorGrabarProtMovil.Value = "1"
            End If

            If blnPedidoGenerado = False Then
                Throw New Exception("No se pudo crear pedido en MSSAP.")
            End If

            If (intidPedidoMsSapRef > 0) Then
                oRegPed.actualizaPedido(strNroPedido)
            End If

        Catch ex As Exception

            'Variables para EliminarProtecionMovil()
            Dim oBEItemMensaje As New BEItemMensaje
            Dim strNroSecPM As String = Funciones.CheckStr(hidNroSEC.Value)
            Dim arrPlanDetalle As PlanDetalleVenta = Session("PlanDetalle")
            Dim strCodPlan As String = arrPlanDetalle.SOPLN_CODIGO
            oBEItemMensaje.codigo = ""

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Entró al Catch de GenerarPedidoProteccionMovil() ")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Mensaje de error: " & ex.Message)

            hidErrorGrabarProtMovil.Value = "1"
            If blnPedidoGenerado Or intidPedidoMsSapRef > 0 Then
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input RollBackVenta --> strNroPedido  : " & strNroPedido)
                RollBackVenta(intidPedidoMsSapRef)
                oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Fin RollBackVenta --> strNroPedido  : " & strNroPedido)
            End If

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " strNroSecPM" & strNroSecPM)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " strCodPlan" & strCodPlan)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " strFlagPedidoPrima" & strFlagPedidoPrima)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " strNroCertificado" & strNroCertificado)

            EliminarProtecionMovil(strNroSecPM, oBEItemMensaje, strCodPlan, strFlagPedidoPrima, strNroCertificado)

        End Try
    End Sub

    <Anthem.Method()> _
        Public Function ValidarProteccionMovil(ByVal strEquiposDetalle As String, ByVal strNumDocumento As String) As String

        Dim BLProteccionMovil As New BLProteccionMovil
        Dim objBWCliente As New BWClienteProteccionMovil
        Dim Blconsulta As New Blconsulta
        Dim oBEItemMensaje As New BEItemMensaje

        'Hidden limpios
        hidDeducible.Value = String.Empty
        hidPrima.Value = String.Empty

        ''Consulta Lista de Precio
        Dim strCodListaPrecioPrepago As Integer = CheckInt(ClsKeyAPP.strCodListaPrecioPrepagoMes)  ''PROY-24724-IDEA-28174 - Parametro
        Dim dblPrecioPrepagoMinimo As Double = Funciones.CheckDbl(ClsKeyAPP.strCodPrecioPrepagoMinimo) 'PROY-24724-IDEA-28174 - Parametro
        Dim dblPrecioPrepago As Double
        Dim strMsgPrecioPrepago As String = String.Empty
        Dim strCodMaterial As String
        strCodMaterial = strEquiposDetalle

        'Consulta Asurión
        Dim strTipoCliente As String = CheckStr(hidTipoOferta.Value)
        Dim strTipoDocumento As String = CheckStr(hidTipoDocumento.Value)
        Dim strNroDocumento As String = CheckStr(hidNroDocumento.Value)
        Dim strCodRptaPM As String = String.Empty
        Dim strMsjRptaPM As String = String.Empty
        Dim strMontoPrima As String = String.Empty
        Dim strDeducible As String = String.Empty
        Dim strFlagEvalPM As String = String.Empty
        Dim strCertificado As String = String.Empty
        Dim strMontoPrimaEVal As String = (Funciones.CheckStr(hidPrimaEval.Value)).Trim()
        Dim strNombPro As String = String.Empty
        Dim strDescPro As String = String.Empty
        Dim strIncTipoDanio As String = String.Empty
        Dim strIncTipoRobo As String = String.Empty

        Dim strMetodo As String = "consultarPrima()"
        Dim objAudit As New BEItemGenerico

        ' Flag de validación Rpta Asurión
        Dim strRptAsurion As String

        ' Correo 
        Dim oBEItemMsjCorreo As New BEItemMensaje
        Dim strFlagCorreo As String = "CP"
        Dim bolErrorConsulta As Boolean = False

        'Cadena de retorno a aspx
        Dim strResultado As String = String.Empty


        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>> INICIO ConsultarPrecioListaPrepago() <<<<<<<<<<")
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Inp            Cod. Material: " & strCodMaterial)
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Inp Cod. List.Precio Prepago: " & strCodListaPrecioPrepago)
        Blconsulta.ConsultarPrecioListaPrepago(strCodMaterial, strCodListaPrecioPrepago, dblPrecioPrepago, strMsgPrecioPrepago)
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Out   Precio Prepago: " & dblPrecioPrepago)
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Out          Mensaje: " & strMsgPrecioPrepago)
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & ">>>>>> FIN ConsultarPrecioListaPrepago() <<<<<<<<<<")

        If (dblPrecioPrepago >= dblPrecioPrepagoMinimo) Then

            Try
                objAudit.Codigo = strNumDocumento + String.Format("{0:yyyyMMddhhmmss}", DateTime.Now) 'idtransaction
                objAudit.Codigo2 = Funciones.CheckStr(CurrentUser)
                objAudit.Codigo3 = Funciones.CheckStr(ConfigurationSettings.AppSettings("CodigoAplicacion")) '286 creo
                objAudit.Descripcion = Funciones.CheckStr(ConfigurationSettings.AppSettings("constAplicacion")) 'sisact
                objAudit.Descripcion2 = Funciones.CheckStr(CurrentTerminal) 'ipaplicacion
                'PROY-24724-IDEA-28174 - Parametro-FIN
                If (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteMasivo)) Then
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteMasivo)
                ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteB2E)) Then
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteB2E)
                ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteBusiness)) Then
                    strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteBusiness)
                End If
                'PROY-24724-IDEA-28174 - Parametro-INI
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "INICIO ConsultarPrima()")
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Inp  Cod Material: " & strCodMaterial)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Inp  Tipo Cliente: " & strTipoCliente)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Inp Tipo Documento: " & strTipoDocumento)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Inp Nro Documento: " & strNroDocumento)

                oBEItemMensaje = objBWCliente.ConsultarPrima(strCodMaterial, strTipoCliente, strTipoDocumento, strNroDocumento, objAudit, strCodRptaPM, strMsjRptaPM, strMontoPrima, strDeducible, strCertificado, _
                                                            strNombPro, strDescPro, strIncTipoDanio, strIncTipoRobo)

                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out     Cod Rpta : " & strCodRptaPM)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out     Msj Rpta : " & strMsjRptaPM)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  Monto Prima : " & strMontoPrima)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out    Deducible : " & strDeducible)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  Certificado : " & strCertificado)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  strNombPro : " & strNombPro)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  strDescPro : " & strDescPro)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  strIncTipoDanio : " & strIncTipoDanio)
                oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "Out  strIncTipoRobo : " & strIncTipoRobo)


                If (strCodRptaPM = "0") Then
                    If (Funciones.CheckInt(strMontoPrima) > Funciones.CheckInt(strMontoPrimaEVal)) Then
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " Monto Prima consultado mayor al que fue enviado a BRMS")
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " Monto Prima Actual : " & strMontoPrima)
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " Monto Prima Evaluacion : " & strMontoPrimaEVal)
                        strFlagEvalPM = "5"  'Monto Prima consultado mayor al que fue consultado a BRMS
                        strMontoPrima = String.Empty
                    Else
                        strFlagEvalPM = "1"
                        hidDeducible.Value = strDeducible
                        hidPrima.Value = strMontoPrima
                        hidEvalPM.Value = strFlagEvalPM
                        hidCertificadoPM.Value = strCertificado
                        hidDatosAdicionalesPM.Value = strNombPro + "|" + strDescPro + "|" + strIncTipoDanio + "|" + strIncTipoRobo
                    End If
                ElseIf (strCodRptaPM = "2") Then
                    strRptAsurion = "NC" 'No califica cobertura
                    strFlagEvalPM = "2"
                Else
                    bolErrorConsulta = True
                    strRptAsurion = "ES"
                    strFlagEvalPM = "3" 'no respondio asurion
                    strCodRptaPM = "-2"
                    strRptAsurion = "Sin Servicio de ClienteProteccionMovil"
                End If
            Catch ex As Exception
                bolErrorConsulta = True
                strMsjRptaPM = ex.Message.ToString()
                strCodRptaPM = "99"
                strRptAsurion = "ND" '"ND=No Disponibilidad"
                strFlagEvalPM = "3" 'no respondio asurion

            Finally '"Parametros
                If bolErrorConsulta Then
                    Try
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  INICIO EnviarCorreoContingencia()<< ")
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  URL :" & Funciones.CheckStr(ConfigurationSettings.AppSettings("consClienteProteccionMovilWS_Error")))
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  Metodo Aplicación: " & strMetodo)
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Codigo Rpta:" & strCodRptaPM)
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Mensaje Rpta:" & strMsjRptaPM)
                oBEItemMsjCorreo = BLProteccionMovil.EnviarCorreoContingencia(strMetodo, strCodRptaPM, strMsjRptaPM, objAudit, strFlagCorreo)
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >>  FIN EnviarCorreoContingencia()<< ")
                    Catch ex As Exception
                        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & " >> Mensaje Exception:" & ex.Message)
                    End Try
                End If  '"Parametros
            End Try
        Else
            strFlagEvalPM = "4"  'Monto de Equipo inferior a S/150.00
        End If

        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "strRptAsurion: " & strRptAsurion)
        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "strFlagEvalPM: " & strFlagEvalPM)

        If oBEItemMsjCorreo.exito = False Then
            oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> INI Error en envío de correo <>")
            oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Cod: " & oBEItemMsjCorreo.codigo)
            oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> Msj: " & oBEItemMsjCorreo.descripcion)
            oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "    >> FIN Error en envío de correo <>")
        End If

        strResultado &= strMontoPrima & "_"
        strResultado &= strDeducible & "_"
        strResultado &= strFlagEvalPM & "_"
        strResultado &= strCertificado & "_"
        strResultado &= Funciones.CheckStr(hidDatosAdicionalesPM.Value)

        oLog.Log_WriteLog(strArchivo, strNumDocumento & " - " & "strResultado: " & strResultado)

        hidEvalPM.Value = strFlagEvalPM
        Return strResultado

    End Function
    'PROY-24724-IDEA-28174 - FIN 
    Private Function GenerarRentaAdelantadaMSSAP(ByVal nroPedido As String, ByVal cadenaCabecera As String, ByVal cadenaDetalle As String, ByVal strcadenaDRA As String, ByVal cadenaDeposito As String, ByVal idLog As String) As Integer

        oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio RegistrarPedido DRA")

        Dim blnResultado As Boolean = False
        Dim nroDepositoMSSAP As Int64 = 0
        Dim strNroContrato As Int64 = 0
        Dim nroDepositoSISACT As String = String.Empty
        Dim strDescError As String = String.Empty
        Dim strCodError As String = String.Empty
        Dim dblMontoGarantia As Double
        Dim nroTelefono As String = String.Empty
        Dim idCodigoMsSap As Int64 = 0
        Dim tipoOfi As String
        Dim sTipoDeposito As String
        Dim codSKU As String = String.Empty

        Try
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "strcadenaDRA:" & strcadenaDRA)

            Dim arrValoresDRA As String() = Funciones.CheckStr(strcadenaDRA).Split(CChar("|"))

            dblMontoGarantia = Funciones.CheckDecimal(arrValoresDRA(0))
            strNroContrato = Funciones.CheckInt64(arrValoresDRA(1))
            sTipoDeposito = Funciones.CheckStr(arrValoresDRA(4))

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "dblMontoGarantia:" & dblMontoGarantia)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "strNroContrato:" & strNroContrato)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "sTipoDeposito:" & sTipoDeposito)

            Dim nuevaCadenaCabecera As String() = cadenaCabecera.Split(CChar(";"))

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera:" & nuevaCadenaCabecera.Length)
            tipoOfi = nuevaCadenaCabecera(44)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "tipoOfi:" & tipoOfi)
            nuevaCadenaCabecera(2) = ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoRentaAdelantada")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(2):" & ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoRentaAdelantada"))
            nuevaCadenaCabecera(5) = ConfigurationSettings.AppSettings("constSINERGIASectorRentaAdelantada")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(25:" & ConfigurationSettings.AppSettings("constSINERGIASectorRentaAdelantada"))
            nuevaCadenaCabecera(9) = ConfigurationSettings.AppSettings("ConsClaseDocumentoRentaAdelantada").Split(CChar(";"))(0)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(9):" & nuevaCadenaCabecera(9))
            nuevaCadenaCabecera(10) = ConfigurationSettings.AppSettings("ConsClaseDocumentoRentaAdelantada").Split(CChar(";"))(1)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(10):" & nuevaCadenaCabecera(10))
            nuevaCadenaCabecera(12) = ConfigurationSettings.AppSettings("constSINERGIAClasePedidoRentaAdelantada")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(12):" & nuevaCadenaCabecera(12))
            nuevaCadenaCabecera(19) = ConfigurationSettings.AppSettings("constSINERGIAFlagIsRenta")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(19):" & nuevaCadenaCabecera(19))
            nuevaCadenaCabecera(20) = nroPedido
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(20):" & nuevaCadenaCabecera(20))
            nuevaCadenaCabecera(22) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaRentaAdelantada")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nuevaCadenaCabecera(22):" & nuevaCadenaCabecera(22))

            cadenaCabecera = ""
            cadenaCabecera = Join(nuevaCadenaCabecera, ";")

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "cadenaCabecera:" & cadenaCabecera)

            Dim nuevaCadenaDetalle As String() = cadenaDetalle.Split(CChar("|"))

            If nuevaCadenaDetalle.Length > 1 Then
                For i As Integer = 1 To nuevaCadenaDetalle.Length - 1
                    Dim plan As String = nuevaCadenaDetalle(i)

                    Dim arrayItems() As String = plan.Split(";"c)
                    arrayItems(3) = ""
                    arrayItems(4) = ConfigurationSettings.AppSettings("constSINERGIAMaterialRentaAdelantada")
                    arrayItems(7) = CStr(Funciones.CheckDbl(dblMontoGarantia) / 1.18)
                    arrayItems(12) = "0"

                    nuevaCadenaDetalle(i) = ""
                    nuevaCadenaDetalle(i) = Join(arrayItems, ";")
                    cadenaDetalle = ""
                    cadenaDetalle = nuevaCadenaDetalle(i)
                    Exit For
                Next
            Else
                Dim arrayDetalle As String() = cadenaDetalle.Split(CChar(";"))
                arrayDetalle(3) = ""
                arrayDetalle(4) = ConfigurationSettings.AppSettings("constSINERGIAMaterialRentaAdelantada")
                arrayDetalle(7) = CStr(Funciones.CheckDbl(dblMontoGarantia) / 1.18)
                arrayDetalle(12) = "0"

                cadenaDetalle = ""
                cadenaDetalle = Join(arrayDetalle, ";")
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "cadenaDetalle:" & cadenaDetalle)

            Dim oRegPed As New ConsultaMsSapNegocio
            Dim oReg As New BLConsultaMssap
            Dim strCodRspt As String = ""
            Dim strMensRspt As String = ""
            Dim blnDeposito As Boolean = False

            oRegPed.RegistrarPedido(cadenaCabecera, cadenaDetalle, idCodigoMsSap, strCodRspt, strMensRspt)
            If (idCodigoMsSap > 0) Then
                blnDeposito = True
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out idCodigoMsSap:" & idCodigoMsSap)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out strCodRspt:" & strCodRspt)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out strMensRspt:" & strMensRspt)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin RegistrarPedido")

            If Not blnDeposito Then
                Throw New Exception("No se pudo Crear el Depósito de Garantía / Renta Adelantada")
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio RegistrarGarantiaSisact")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "strNroContrato:" & strNroContrato)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "cadenaDeposito:" & cadenaDeposito)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "idCodigoMsSap:" & idCodigoMsSap)
            blnDeposito = RegistrarGarantiaSisact(strNroContrato, sTipoDeposito, idCodigoMsSap.ToString, cadenaDeposito, nroDepositoSISACT)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out nroDepositoSISACT:" & nroDepositoSISACT)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin RegistrarGarantiaSisact")

            If Not blnDeposito Then
                Throw New Exception("No se pudo Crear el Depósito de Garantía / Renta Adelantada")
            End If

            nroTelefono = hidNroLinea.Value

            Dim objDra As New BERentaAdelantada
            Dim objResp As New BERentaAdelantada
            Dim negocioDra As New BLRentaAdelantada
            Dim objTrMssap As New ConsultaMsSapNegocio

            objDra.Drad_fecha_emision = DateTime.Now
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drad_fecha_emision:" & objDra.Drad_fecha_emision)
            objDra.Drad_fecha_vencimiento = DateTime.Now
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drad_fecha_vencimiento:" & objDra.Drad_fecha_vencimiento)
            objDra.Dran_solin_codigo = Funciones.CheckInt(oSolicitud.SOLIN_CODIGO.ToString)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_solin_codigo:" & objDra.Dran_solin_codigo)
            objDra.Dran_usuario_crea = CurrentUser
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_usuario_crea:" & objDra.Dran_usuario_crea)
            objDra.Dran_usuario_mod = CurrentUser
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_usuario_mod:" & objDra.Dran_usuario_mod)
            objDra.Drav_tipo_aplicacion = ConfigurationSettings.AppSettings("constAplicacion")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drav_tipo_aplicacion:" & objDra.Drav_tipo_aplicacion)
            objDra.DRAV_COD_PDV = oSolicitud.OVENC_CODIGO
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "DRAV_COD_PDV:" & objDra.DRAV_COD_PDV)
            objDra.Dran_open_amount = Funciones.CheckDecimal(dblMontoGarantia)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_open_amount:" & objDra.Dran_open_amount)
            objDra.Dran_total_amount = Funciones.CheckDecimal(dblMontoGarantia)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_total_amount:" & objDra.Dran_total_amount)
            objDra.Dran_importe_pago = Funciones.CheckDecimal(dblMontoGarantia)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Dran_importe_pago:" & objDra.Dran_importe_pago)

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "tipoOfi:" & tipoOfi)

            If tipoOfi = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                objDra.Drav_Cod_Cli_Sap_Pdv = codMasivo
            Else
                Dim interlocutorPadre As String
                Dim respInterlocutorPadre As Boolean = False
                Dim objConsulta As New BLConsultaMssap

                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Oficina DAC")
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "codMasivo: " & codMasivo)
                respInterlocutorPadre = objConsulta.ObtenerInterlocutorPadre(codMasivo, interlocutorPadre)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "out interlocutorPadre:" & interlocutorPadre)

                objDra.Drav_Cod_Cli_Sap_Pdv = interlocutorPadre
            End If

            If tipoOfi = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                objDra.DRAV_CANAL_PDV = ConfigurationSettings.AppSettings("DecripcionCAC")
            ElseIf tipoOfi = ConfigurationSettings.AppSettings("constCodTipoDAC") Then
                objDra.DRAV_CANAL_PDV = ConfigurationSettings.AppSettings("DecripcionDAC")
            ElseIf tipoOfi = ConfigurationSettings.AppSettings("constCodTipoCRN") Then
                objDra.DRAV_CANAL_PDV = ConfigurationSettings.AppSettings("DecripcionCAD")
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio obtenerSKURentaAdelantada()")
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "in codMasivo:" & codMasivo)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "in dblMontoGarantia:" & dblMontoGarantia)
                'negocioDra.obtenerSKURentaAdelantada(objDra.DRAV_COD_PDV, dblMontoGarantia, codSKU)
                negocioDra.obtenerSKURentaAdelantada(codMasivo, dblMontoGarantia, codSKU)
                objDra.Sis_Sku_Dra = codSKU
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "out codSKU:" & codSKU)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin obtenerSKURentaAdelantada")
            Else
                objDra.DRAV_CANAL_PDV = ConfigurationSettings.AppSettings("DecripcionCOR")
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "DRAV_CANAL_PDV:" & objDra.DRAV_CANAL_PDV)

            objDra.Drac_tipo_ra = ConfigurationSettings.AppSettings("TipoRentaADMasivo")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drac_tipo_ra:" & objDra.Drac_tipo_ra)
            objDra.Drav_documento_cliente = oSolicitud.CLIEC_NUM_DOC
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drav_documento_cliente:" & objDra.Drav_documento_cliente)

            If oSolicitud.CLIEV_RAZ_SOC <> "" Then
                objDra.DRAV_RAZONSOCIAL_NOMBRE = oSolicitud.CLIEV_RAZ_SOC
            Else
                objDra.DRAV_RAZONSOCIAL_NOMBRE = oSolicitud.CLIEV_NOMBRE + " " + oSolicitud.CLIEV_APE_PAT + " " + oSolicitud.CLIEV_APE_MAT
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "DRAV_RAZONSOCIAL_NOMBRE:" & objDra.DRAV_RAZONSOCIAL_NOMBRE)

            objDra.DRAV_NROGENERADO_SAP = idCodigoMsSap.ToString
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "DRAV_NROGENERADO_SAP:" & objDra.DRAV_NROGENERADO_SAP)
            objDra.DRAN_IDCONTRATO_SI = Funciones.CheckInt(strNroContrato)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "DRAN_IDCONTRATO_SI:" & objDra.DRAN_IDCONTRATO_SI)
            objDra.Drav_linea = nroTelefono
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drav_linea:" & objDra.Drav_linea)
            objDra.Drav_moneda = ConfigurationSettings.AppSettings("constSINERGIAMonedaRentaAdelantada")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drav_moneda:" & objDra.Drav_moneda)
            objDra.Drav_recibo_aplicar = ConfigurationSettings.AppSettings("NroReciboAplicarDRA")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Drav_recibo_aplicar:" & objDra.Drav_recibo_aplicar)

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio GrabarRentaAdelantadaPVUDB: Nro. Pedido " & idCodigoMsSap)

            objResp = negocioDra.GrabarRentaAdelantadaPVUDB(objDra)
            Dim oNroErrorDRA, oDescErrorDRA As String
            Dim nroAsociado As String = objResp.Drav_nro_asociado
            Dim ventaExpNeg As New VentaExpressNegocios

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out codigoDran:" & objResp.DranCodigo)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out nroAsociado:" & nroAsociado)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out Drav_origen:" & objResp.Drav_origen)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out Dran_Igv_Dra:" & objResp.Dran_Igv_Dra)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out Codigo_pago:" & objResp.Codigo_pago)

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin GrabarRentaAdelantadaPVUDB")

            If tipoOfi = ConfigurationSettings.AppSettings("ConsTipoOficinaCOR") Then
                Dim valorRet As String = String.Empty
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio GrabarRentaAdelantadaSISCAD: Nro. Pedido " & idCodigoMsSap)
                objResp.Pediv_PedidoAlta = nroPedido
                valorRet = negocioDra.GrabarRentaAdelantadaSISCAD(objResp)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "out valorRet:" & valorRet)
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin GrabarRentaAdelantadaSISCAD: Nro. Pedido " & idCodigoMsSap)
            End If

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio ActualizarPedidoDRA")
            blnResultado = objTrMssap.ActualizarPedidoDRA(Funciones.CheckInt(idCodigoMsSap), nroAsociado, oNroErrorDRA, oDescErrorDRA)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out oNroErrorDRA: " & oNroErrorDRA)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "out oDescErrorDRA: " & oDescErrorDRA)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin ActualizarPedidoDRA")

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Inicio GrabarInfoVentaSap")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "idVenta: " & arrValoresDRA(2))
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "idContrato: " & strNroContrato)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "recibo: " & arrValoresDRA(3))
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "nroDocumento: " & idCodigoMsSap)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "tipoDocumento: " & "G")
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "monto: " & dblMontoGarantia)
            ventaExpNeg.GrabarInfoVentaSap(Funciones.CheckInt64(arrValoresDRA(2)), Funciones.CheckInt64(strNroContrato), arrValoresDRA(3), idCodigoMsSap.ToString, "G", dblMontoGarantia)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin GrabarInfoVentaSap")

            oLog.Log_WriteLog(strArchivo, idLog & " - " & "Fin RegistrarPedido DRA")

        Catch ex As Exception
            HelperLog.EscribirLog("", strArchivo, idLog & " # ERROR: " & ex.Message.ToString(), False)
            Return 0
            Throw ex
        End Try

        Return Funciones.CheckInt(idCodigoMsSap)

    End Function

    Private Function GenerarCadenaCabeceraCAC() As String
        Dim cadenaCabecera As String

        Try
            Dim oficina As String = CheckStr(hidOficina.Value)
            Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
            Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)
            If Not hidPerfil_149.Value = "S" Then
                codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
            End If

            Dim nroDocCliente As String = CheckStr(hidNroDocumento.Value)
            Dim tipoDocCliente As String = CheckStr(hidTipoDocumento.Value)
            Dim tipoVenta As String = hidTipoVenta.Value            'ConfigurationSettings.AppSettings("strPostpagoTipoVenta") = 01
            Dim tipoCliente As String = hidTipoClienteSAP.Value     'ConfigurationSettings.AppSettings("constCodTipoClienteConsumer") = 02
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacion")

            ConsultarTipoDocVentaCAC()
            Dim tipoDocVenta As String = CheckStr(hidTipoDocVentaCAC.Value)
            Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
            Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")

            Dim precios As String = CheckStr(hidDatosEquipo.Value)
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)

            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
            Dim canal As String = CheckStr(hidCanalSap.Value)
            Dim orgVenta As String = CheckStr(hidOrgVenta.Value)
            Dim Nro_Cuotas As String = hidCuota.Value

            'Cadena Documento
            Dim arrayCabecera(49) As String
            arrayCabecera(1) = tipoDocVenta                          'Tipo_Documento
            arrayCabecera(2) = oficina                               'Oficina_Venta
            arrayCabecera(3) = String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
            arrayCabecera(4) = tipoDocCliente                        'Tipo_Doc_Cliente
            arrayCabecera(5) = nroDocCliente                         'Cliente
            arrayCabecera(7) = moneda                                'Moneda
            arrayCabecera(9) = totalSinIGV                           'Total_Mercaderia
            arrayCabecera(10) = totalIGV                             'Total_Impuesto
            arrayCabecera(11) = totalConIGV                          'Total_Documento
            'arrayCabecera(12) = ""                                  'Fecha registro
            arrayCabecera(14) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayCabecera(15) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayCabecera(16) = tipoVenta                            'Tipo_Venta
            'arrayCabecera(22) = ""                                   'Fecha Vta Or
            arrayCabecera(24) = Nro_Cuotas                             'nro_cuota
            arrayCabecera(25) = "" 'CheckStr(Session("CodVendedorSAP"))  'nro clarify
            arrayCabecera(27) = codigoVendedorSAP '"23175" 'codigoVendedorSAP  modificar                  'Vendedor
            arrayCabecera(29) = tipoOperacion                        'Renovacion
            arrayCabecera(30) = descTipoOp                           'Descripción Renovacion
            arrayCabecera(35) = codigoVendedorSAP 'CheckStr(Session("CodVendedorSAP")) modificar  'Nro hdc
            arrayCabecera(44) = "0"
            arrayCabecera(45) = "0"                                  'Tipo_Prod_Operad (01 Postpago; 02 Prepago)
            arrayCabecera(48) = orgVenta                             'Orgvnt
            arrayCabecera(49) = canal                                'Canal

            cadenaCabecera = Join(arrayCabecera, ";")

        Catch ex As Exception
            cadenaCabecera = ""
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaCabecera: " & ex.Message)
        End Try

        Return cadenaCabecera
    End Function

    Private Function GenerarCadenaAcuerdoCAC(ByVal NroSEC As String) As String
        Dim cadenaAcuerdo As String
        ConsultarPrefijo()

        Dim oficina As String = CheckStr(hidOficina.Value)
        Dim tipoCliente As String = hidTipoClienteSAP.Value    'ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")
        Dim plazoAcuerdo As String = hidPlazoAcuerdo.Value
        Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
        Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)
        If Not hidPerfil_149.Value = "S" Then
            codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
        End If

        Dim telfVendedor As String = "000000000000000"
        Dim prefijo As String = ConfigurationSettings.AppSettings("constRenovPostNroPrefijo") 'hidPrefijo.Value    
        Dim tipoDocCli As String = CheckStr(hidTipoDocumento.Value)
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim codPlan As String = planTarifa.Split(","c)(1)
        Dim analistaCred As String = ConfigurationSettings.AppSettings("ExpressAnalistaCredito")
        Dim codAprobador As String = CheckStr(ConfigurationSettings.AppSettings("constCodAprobadorSECRenov")).Split(";"c)(0)
        Dim scoreCred As String = hidScoreCred.Value

        Dim strNombreCliente As String = CheckStr(hidNombre.Value).ToUpper
        Dim strAPaternoCliente As String = CheckStr(hidApePaterno.Value).ToUpper
        Dim strAMaternoCliente As String = CheckStr(hidApeMaterno.Value).ToUpper
        Dim strRazonSocial As String = CheckStr(hidRazonSocial.Value).ToUpper
        Dim LimiteCred As String = Math.Round(CheckDbl(hidLimiteCred.Value), 2)
        Dim usuario As String = CurrentUser()

        Try

            If usuario <> "" Then
                usuario = usuario.Substring(1)
            End If

            ' ACUERDO (CONTRATO)
            Dim arrayContrato(67) As String
            arrayContrato(0) = ""
            arrayContrato(1) = oficina
            arrayContrato(2) = prefijo
            arrayContrato(3) = Now.ToString("dd/MM/yyyy")
            arrayContrato(4) = plazoAcuerdo
            arrayContrato(5) = strNombreCliente
            arrayContrato(6) = strAPaternoCliente
            arrayContrato(7) = strAMaternoCliente
            arrayContrato(8) = ""
            arrayContrato(9) = hidNroSEC.Value
            arrayContrato(10) = CheckStr(ConfigurationSettings.AppSettings("constRenovResultado")).Split(";"c)(1)
            arrayContrato(11) = ""
            arrayContrato(12) = ""
            arrayContrato(13) = ""
            arrayContrato(14) = ""
            arrayContrato(15) = ""
            arrayContrato(16) = ""
            arrayContrato(17) = ""
            arrayContrato(18) = ""
            arrayContrato(19) = ""
            arrayContrato(20) = codigoVendedorSAP '"23175" 'modificar codigoVendedorSAP     '"0000070440" 
            arrayContrato(21) = telfVendedor
            arrayContrato(22) = ""
            arrayContrato(23) = ""
            arrayContrato(24) = "N"
            arrayContrato(25) = CheckStr(ConfigurationSettings.AppSettings("constRenovAnalista")).Split(";"c)(0) 'analistaCred
            arrayContrato(26) = ""
            arrayContrato(27) = CheckStr(ConfigurationSettings.AppSettings("constEstadoAcuerdoReservado"))
            arrayContrato(28) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayContrato(29) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayContrato(30) = ""
            arrayContrato(31) = "S"
            arrayContrato(32) = Val(tipoDocCli).ToString
            arrayContrato(33) = hidNroDocumento.Value
            arrayContrato(34) = hidNroLinea.Value
            arrayContrato(35) = codPlan
            arrayContrato(36) = "S"
            arrayContrato(37) = ""
            arrayContrato(38) = CheckStr(Session("CodVendedorSAP")) '"23175" ' modificar CheckStr(Session("CodVendedorSAP"))
            arrayContrato(39) = CheckStr(Session("CodVendedorSAP")) '"23175" ' modificar CheckStr(Session("CodVendedorSAP"))
            arrayContrato(40) = ""
            arrayContrato(41) = ""
            arrayContrato(42) = CheckStr(ConfigurationSettings.AppSettings("constRenovAprobador")).Split(";"c)(0)
            arrayContrato(43) = LimiteCred
            arrayContrato(44) = ""
            arrayContrato(45) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(0)
            arrayContrato(46) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(1)
            'arrayContrato(45) = scoreCred.Split("_"c)(0)             'Score_Crediticio = arrAcuerdo [45]; A b c d s
            'arrayContrato(46) = scoreCred.Split("_"c)(1)             'Control_Fraude = arrAcuerdo [46]; "monto columan en tabla sec"
            arrayContrato(47) = hidNroSEC.Value
            arrayContrato(48) = ""
            arrayContrato(49) = ""
            arrayContrato(50) = codPlan
            'arrayContrato(51) = ""
            'arrayContrato(52) = ""
            'arrayContrato(53) = ""
            'arrayContrato(54) = ""
            'arrayContrato(55) = ""
            'arrayContrato(56) = ""
            'arrayContrato(57) = ""
            'arrayContrato(58) = ""
            'arrayContrato(59) = ""
            'arrayContrato(60) = ""
            arrayContrato(61) = "X"
            'arrayContrato(62) = "" 'tipoCliente
            'arrayContrato(63) = ""
            'arrayContrato(64) = ""
            'arrayContrato(65) = ""
            'arrayContrato(66) = ""

            cadenaAcuerdo = Join(arrayContrato, ";")


        Catch ex As Exception
            cadenaAcuerdo = ""
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaAcuerdo: " & ex.Message)
        End Try

        Return cadenaAcuerdo
    End Function

    Private Sub ConsultarTipoDocVentaCAC()
        Dim dsClasePedido As New DataSet
        Dim oficina As String = hidOficina.Value
        Dim tipoDocCliente As String = hidTipoDocumento.Value

        'dsClasePedido = (New SapGeneralNegocios).ConsultarTipoDocumentoOfVenta(hidOficina.Value)
        Dim listaTipoDocVenta() As String 'PROY-31636
        'INI PROY-31636
        If AppSettings.Key_codigoDocMigratorios.IndexOf(tipoDocCliente) > -1 Then
            listaTipoDocVenta = AppSettings.Key_ExpressTipoDocVentaPos.Split(CChar(","))
        Else
            listaTipoDocVenta = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & tipoDocCliente).Split(CChar(","))
        End If
        'FIN PROY-31636
        'For Each item As String In listaTipoDocVenta
        '    If hidTipoDocVentaCAC.Value <> "" Then
        '        Exit For
        '    End If
        '    For Each fila As System.Data.DataRow In dsClasePedido.Tables(0).Rows
        '        If CheckStr(fila.Item("AUART")) = item Then
        '            hidTipoDocVentaCAC.Value = item
        '            Exit For
        '        End If
        '    Next
        'Next
        hidTipoDocVentaCAC.Value = listaTipoDocVenta(2)

        dsClasePedido = Nothing
        listaTipoDocVenta = Nothing
    End Sub

    Private Function GenerarDetalleRenovSap(ByVal nroFactura As String, ByVal nroContrato As String, ByVal nroPedido As String) As Boolean
        Session("UsuarioValidadorDescuento") = ""
        Dim retorno As String
        Dim blnOK As Boolean = False

        Try

            'Dim oConsultaSap As New SapGeneralNegocios
            Dim oConsulta As New VentaExpressNegocios
            Dim motivo As String = ""
            Dim nroLinea As String = hidNroLinea.Value
            Dim doc_tipo As String = hidTipoDocumento.Value
            Dim doc_nro As String = hidNroDocumento.Value
            Dim puntoVenta As String = CheckStr(hidOficina.Value) 'CheckStr(hidOfVenta.Value)
            Dim servidor As String = System.Net.Dns.GetHostName


            Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
            Dim codPlan As String = planTarifa.Split(","c)(0)
            Dim desPlan As String = planTarifa.Split(","c)(1)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "hidLimiteCred.value : " & hidLimiteCred.Value)

            If (hidLimiteCred.Value = "") Then
                hidLimiteCred.Value = "0"
            End If

            Dim limite As Double = CheckDbl(hidLimiteCred.Value)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "limite: " & limite)

            Dim desTope As String = ""


            'Insertar datos adicionales para el pedido sap
            Dim strCanal As String = "CAC"
            Dim strTipoRenovacion As String = ""
            Dim flagExoneracion As Integer = 0
            Dim flagDescuento As Integer = 0


            Dim titular As String = hidTitular.Value
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "titular : " & titular)

            Dim representante As String = hidRepLegal.Value '"" 'txtRepLegal. hidRepresentante.Value
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "representante : " & representante)
            If hidDescuento.Value = "" Then
                hidDescuento.Value = 0
            End If

            Dim descuento As Double = Double.Parse(hidDescuento.Value)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "descuento : " & descuento)

            If Session("UsuarioValidadorDescuento") Is Nothing Then
                Session("UsuarioValidadorDescuento") = ""
            End If

            ' Inicio E77568
            ' PROY-7045RF01 - RF01
            Session("UsuarioValidadorDescuento") = Session("codUsuario")
            ' Fin E77568
            Dim usuarioValidador As String = Session("UsuarioValidadorDescuento")


            If Not Session("UsuarioValidadorDescuento") Is Nothing Then
                usuarioValidador = usuarioValidador.ToUpper()
            End If



            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "usuarioValidador : " & usuarioValidador)

            If hidFlagRenovacionAdelantada.Value = "true" Then
                strTipoRenovacion = "ANTICIPADA"
            Else
                strTipoRenovacion = "NORMAL"
            End If
            ' Inicio E77568
            ' Si es el último mes es una renovación normal
            If hidMesesPorVencer.Value = "1" Then
                strTipoRenovacion = "NORMAL"
            End If
            ' Fin E77568

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strTipoRenovacion : " & strTipoRenovacion)

            If hidFlagReintegro.Value = "true" And hidFlagExonerarReintegro.Value = "true" Then
                flagExoneracion = 1
            End If


            If (hidFlagDescuento.Value = "true") Then
                flagDescuento = 1
            End If

            'consolidado 06012015



            'consolidado 06012015

            Dim strflag_renovChip As String = String.Empty
            Dim strMotivoRenovChip As String = String.Empty
            If hidValidarIccid.Value = "1" Then
                strflag_renovChip = "1"
                strMotivoRenovChip = CheckStr(ddlRenovChip.SelectedItem.Text)
            Else
                strflag_renovChip = "0"
                strMotivoRenovChip = ""
            End If

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Motivo Renovacion : " & strMotivoRenovChip)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "flagDescuento : " & flagDescuento)


            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GrabarVentaRenovacionCAC()")

            ' Inicio E77568
            Dim RetenidoFidelizado As String = hdnRetenidoFidelizado.Value.ToUpper()

            Dim oSolicitudCAC As New SolicitudNegocios

            
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "NroSEC: " & hidNroSEC.Value)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Documento: " & doc_nro)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Factura: " & nroFactura)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Contrato: " & nroContrato)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Pedido: " & nroPedido)
			'
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strTipoRenovacion: " & strTipoRenovacion)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "flagExoneracion: " & Funciones.CheckStr(flagExoneracion))
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "flagDescuento: " & flagDescuento)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strCanal: " & strCanal)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "titular: " & titular)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "descuento: " & descuento)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "usuarioValidador: " & usuarioValidador)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "RetenidoFidelizado: " & RetenidoFidelizado)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strflag_renovChip: " & strflag_renovChip)
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strMotivoRenovChip: " & strMotivoRenovChip)
		
                   
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "aux_strNroSECPadre: " & Funciones.CheckStr(Session("aux_strNroSECPadre")))
			oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "aux_nroDocumento: " & Funciones.CheckStr(Session("aux_nroDocumento")))
			

            
            retorno = oSolicitudCAC.ActualizarVentaRenovacionDatosComp(Funciones.CheckStr(Session("aux_strNroSECPadre")), Funciones.CheckStr(Session("aux_nroDocumento")), nroFactura, nroContrato, nroPedido, strTipoRenovacion, flagExoneracion, flagDescuento, strCanal, titular, descuento, usuarioValidador, RetenidoFidelizado, strflag_renovChip, strMotivoRenovChip)


            'Crear copia de datos de pedido en SISACT
            'retorno = oConsulta.GrabarVentaRenovacionCAC(puntoVenta, _
            '                                            doc_tipo, _
            '                                            doc_nro, _
            '                                            CurrentUser, _
            '                                            nroFactura, _
            '                                            nroContrato, _
            '                                            hidCorreo.Value, _
            '                                            hidPlanAct.Value, _
            '                                            nroLinea, _
            '                                            desPlan, _
            '                                            desTope, _
            '                                            servidor, _
            '                                            limite, _
            '                                            hidCicloFact.Value, _
            '                                            strCanal, _
            '                                            nroPedido, _
            '                                            strTipoRenovacion, _
            '                                            flagExoneracion, _
            '                                            flagDescuento, titular, representante, descuento, usuarioValidador, _
            '                                            RetenidoFidelizado)
            ' Fin E77568

            If Not retorno = "0" Then
                RollBackVenta(nroFactura)
            Else
                blnOK = True
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Exception GrabarVentaRenovacionCAC - Mensaje: " & ex.Message)
 
            Session("aux_nroDocumento") = String.Empty
            Session("aux_strNroSECPadre") = String.Empty

            RollBackVenta(nroFactura)

            Throw New Exception(" Error al Generar Detalle RenovSap. " & ex.Message)

        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GrabarVentaRenovacionCAC()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> retorno : " & retorno)
            
            Session("aux_nroDocumento") = String.Empty
            Session("aux_strNroSECPadre") = String.Empty
        End Try

        Return blnOK

    End Function

    Private Function GenerarNotaCredito(ByRef documentoSAP As String, ByVal idPedidoMsSap As String) As Boolean

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Inicio GenerarNotaCredito()")

        Dim retorno As Boolean = False

        'GENERAR NOTA DE CREDITO
        Dim montoDescuento As Double = Double.Parse(hidDescuento.Value)
        Try

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Inicio GenerarProcesoNotaCredito()")

            GenerarProcesoNotaCredito(montoDescuento, documentoSAP, False, hidDescuento.Value, idPedidoMsSap)

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception GenerarNotaCredito()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception. Generar Nota de Crédito - " & ex.Message)

            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaCredito()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaCredito()")
        End Try

    End Function

    Private Sub GenerarProcesoNotaCredito(ByVal v_montodescuento As Double, ByRef documentoSAP As String, ByVal sFlagNota As Boolean, ByVal strCantidad As String, ByVal idPedidoMsSap As String)

        Dim cadenaCabecera As String
        Dim cadenaDetalle As String

        Dim oficinaVenta As String = hidOficina.Value 'hidOfVenta.Value

        'Generar variables para Generar Nota de Credito
        cadenaCabecera = GenerarCabeceraNotaCredito(v_montodescuento, sFlagNota, idPedidoMsSap)
        cadenaDetalle = GenerarDetalleNotaCredito(v_montodescuento, strCantidad, sFlagNota)

        ' Dim oConsultaSap As New SapGeneralNegocios
        Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GenerarProcesoNotaCredito() ")
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> CabeceraProcesoNotaCredito(): " & cadenaCabecera)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> DetalleProcesoNotaCredito() : " & cadenaDetalle)


        'Grabar Nota de Credito
        'Dim notaCreditoGenerado As Boolean = oConsultaSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
        'nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

        'ini sinergia 10082015

        Dim oRegPed As New ConsultaMsSapNegocio
        Dim idPedidoNotaCredito As Int64 = 0
        Dim strCodRspt As String = String.Empty
        Dim strMensRspt As String = String.Empty
        Dim pedidoGenerado As Boolean
        'RegistrarDevolucion
        idPedidoNotaCredito = oRegPed.RegistrarDevolucion(cadenaCabecera, cadenaDetalle, strCodRspt, strMensRspt)
        'If (idPedidoNotaCredito > 0) Then
        '    nroPedido = CheckStr(idPedidoNotaCredito)
        '    factura = CheckStr(idPedidoNotaCredito)
        '    pedidoGenerado = True
        '    'actualizar monto de pedido
        '    oRegPed.actualizaPedido(idPedidoNotaCredito)
        'Else
        '    pedidoGenerado = False
        'End If


        'fin sinergia 10082015

        documentoSAP = CheckStr(factura)

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strCodRspt  : " & strCodRspt)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strMensRspt  : " & strMensRspt)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GenerarProcesoNotaCredito() ")

        'Graba los valores para que el Almacenero no lo pueda ver dentro del Pool de atenciones	
        'oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Actualizar datos para la nota de credito para POOL de Alamacenero y Despachador")
        'oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Guarda valores para que el Almacenero no lo pueda ver dentro del Pool de atenciones")
        'oConsultaSap.Set_ActualizaEstadoPedido(factura, oficinaVenta, "S", "")

        'Graba los valores para que el Despachador no lo pueda ver dentro del Pool de atenciones	
        'oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Guarda valores para que el Despachador no lo pueda ver dentro del Pool de atenciones")
        'oConsultaSap.Set_ActualizaEstadoPedido(factura, oficinaVenta, "", "S")

        If Not idPedidoNotaCredito > 0 Then
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  No se pudo crear la Nota de Crédito")
            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        End If

    End Sub

    Private Function GenerarCabeceraNotaCredito(ByVal v_montodescuento As Double, ByVal sFlagNota As Boolean, ByVal idPedidoMsSap As String) As String


        Dim cadenaCabecera As String
        Dim tipoDocCliente As String = hidTipoDocumento.Value
        Dim nroDocCliente As String = hidNroDocumento.Value
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim tipoDocVenta As String = ""

        Dim ClaseFactura, DescripcionFactura As String
        'Valores para la cabecera

        If (tipoDocCliente = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC")) Then
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaRUC")
        Else
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaNORUC")
        End If

        Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")


        If sFlagNota = True Then
            ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoNotaDebito")
            DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionNotaDebito")
        Else
            ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoDevol")
            DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionDevol")
        End If

        For Each item As String In ConfigurationSettings.AppSettings("ConsTipoDNIFactura").Split(CChar(";"))
            If tipoDocCliente = Funciones.CheckStr(item) Then
                ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoFactura")
                DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionFactura")
                Exit For
            End If
        Next
        'end jmori

        Dim oficina As String = hidOfVentaCod.Value
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(oficina, "")
        Dim canal As String
        Dim orgVenta, sector, strCentro As String
        canal = CheckStr(ConfigurationSettings.AppSettings("ConsCanalMSSAP")) 'oParPVU.canal
        orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia"))
        strCentro = oParPVU.codigoCentro

        Dim DestinoMercaderia As String = Nothing

        If oPar.TipoOficina <> ConfigurationSettings.AppSettings("ConsTipoOficinaCAC") Then
            DestinoMercaderia = oPar.CodigoInterlocutor
        End If



        Dim fechaDocumento As String = Date.Now.ToShortDateString()
        Dim tipoDocumentoCliente As String = hidTipoDocumento.Value
        Dim nroDocumentoCliente As String = hidNroDocumento.Value
        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
        Dim dblMonto As Double = Math.Round(v_montodescuento / (1 + dblIgv), 2)
        Dim dblMontoIGV As Double = Math.Round(dblMonto * dblIgv, 2)
        Dim dblMontoTotal = Math.Round(dblMonto + dblMontoIGV, 2)

        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim vendedor As String = Session("CodVendedorSAP")
        Dim claseVentaNotaCredito As String = ConfigurationSettings.AppSettings("strClaseVentaNotaCredito")



        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Canal Oficina ******** " & canalOf)
        ' CABECERA
        Dim arrayCabecera(52) As String
        If oPar.TipoOficina = ConfigurationSettings.AppSettings("ConsTipoOficinaCAC") Then
            arrayCabecera(0) = oParPVU.cPuntoVentaSinergia
            arrayCabecera(1) = ""
        Else
            arrayCabecera(0) = ""
            arrayCabecera(1) = oPar.CodigoInterlocutor
        End If

        arrayCabecera(2) = ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoDevol")
        arrayCabecera(3) = orgVenta
        arrayCabecera(4) = canal
        arrayCabecera(5) = sector
        arrayCabecera(6) = ConfigurationSettings.AppSettings("ConsTipoVentasPostpago")
        arrayCabecera(7) = Now.ToString()
        arrayCabecera(8) = ConfigurationSettings.AppSettings("ConsMotivoPedidoPortabilidad")
        arrayCabecera(9) = ClaseFactura
        arrayCabecera(10) = DescripcionFactura
        arrayCabecera(11) = DestinoMercaderia
        arrayCabecera(12) = ConfigurationSettings.AppSettings("constSINERGIAClasePedidoDevol")
        arrayCabecera(13) = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
        arrayCabecera(14) = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion")
        arrayCabecera(15) = Now.ToString()
        arrayCabecera(16) = ConfigurationSettings.AppSettings("K_SISTEMA")
        arrayCabecera(17) = codVendedor
        arrayCabecera(18) = ConfigurationSettings.AppSettings("ConsDocPrepagoPendientes")
        arrayCabecera(19) = "N"
        arrayCabecera(20) = "0"
        arrayCabecera(21) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad")
        arrayCabecera(22) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaDevol")
        arrayCabecera(23) = idPedidoMsSap
        arrayCabecera(24) = tipoDocCliente
        arrayCabecera(25) = nroDocCliente
        arrayCabecera(26) = hidTipoCliente.Value
        ''''''''''' 
        arrayCabecera(27) = oSolicitud.CLIEV_NOMBRE
        arrayCabecera(28) = oSolicitud.CLIEV_APE_PAT
        arrayCabecera(29) = oSolicitud.CLIEV_APE_MAT
        arrayCabecera(30) = ConfigurationSettings.AppSettings("ConsDefaultFechaNacimiento")
        arrayCabecera(31) = oSolicitud.CLIEV_RAZ_SOC
        arrayCabecera(32) = oSolicitud.SOLIV_CORREO
        arrayCabecera(33) = ConfigurationSettings.AppSettings("ConsSinInformacion")
        arrayCabecera(34) = oSolicitud.ESTADO_CIVIL_ID
        arrayCabecera(35) = ConfigurationSettings.AppSettings("ConsSinInformacion")
        arrayCabecera(36) = "0"
        arrayCabecera(37) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(5, 4)
        arrayCabecera(38) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(0, 2)
        arrayCabecera(39) = ConfigurationSettings.AppSettings("ConsPais")
        arrayCabecera(40) = tipoDocCliente
        arrayCabecera(41) = nroDocCliente
        arrayCabecera(42) = Nothing
        arrayCabecera(43) = Nothing
        arrayCabecera(44) = Nothing
        arrayCabecera(45) = oPar.TipoOficina
        arrayCabecera(46) = Nothing
        arrayCabecera(47) = ""
        arrayCabecera(48) = CurrentUser
        arrayCabecera(49) = Now.ToString()
        arrayCabecera(50) = CurrentUser
        arrayCabecera(51) = Now.ToString()
        arrayCabecera(52) = "0"



        cadenaCabecera = Join(arrayCabecera, ";")

        GenerarCabeceraNotaCredito = cadenaCabecera
    End Function

    Private Function GenerarDetalleNotaCredito(ByVal v_montodescuento As Double, ByVal strCantidad As String, ByVal sFlagNota As Boolean) As String

        Dim arrayDetalle(28) As String
        Dim cadenaDetalle As String

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
        Dim dblMonto As Double = Math.Round(v_montodescuento / (1 + dblIgv), 2)
        Dim dblMontoIGV As Double = Math.Round(dblMonto * dblIgv, 2)
        Dim dblMontoTotal = Math.Round(dblMonto + dblMontoIGV, 2)

        Dim consecutivo As String
        Dim codArticulo As String
        Dim desArticulo As String
        Dim codUtilizacion As String
        Dim desUtilizacion As String
        Dim codCamp As String
        Dim desCamp As String
        Dim cantidad As Integer = 1
        Dim codPlanTarifario As String
        Dim desPlanTarifario As String
        Dim nroTelefono As String

        Dim oficina As String = hidOfVentaCod.Value
        Dim strMaterialImei As String = CheckStr(txtCodEquipo.Text)
        Dim strArticuloImei As String = CheckStr(hidNombredelEquipoCAC.Value)
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(oficina)    'ParametrosOficinaVenta(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(oficina, "")
        Dim canal As String     'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFC_CANALDISTRIBUCION")))
        Dim orgVenta, sector, strCentro As String   'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFV_ORGANIZACIONVENTAS")))
        canal = oParPVU.canal
        orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia")) 'oParPVU.orgVenta
        strCentro = oParPVU.codigoCentro
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)

        'añadido 26082015
        Dim oPrecios As New PreciosMateriales
        Dim strImei As String = CheckStr(hidIMEI.Value)
        Dim precioBase As Decimal = Funciones.CheckDecimal(v_montodescuento)
        Dim precioVenta As Decimal = Funciones.CheckDecimal(v_montodescuento)
        oPrecios = oConsultaMSSAP.Get_PrecioVenta(strMaterialImei, strImei, precioBase, precioVenta)
        Dim strPrecioVentaFinal As String = Funciones.CheckStr(oPrecios.decPrecioVenta)

        'añadido 26082015


        arrayDetalle(0) = "" 'K_PEDIN_NROPEDIDO
        arrayDetalle(1) = CheckStr(cantidad)
        If oPar.TipoOficina = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            arrayDetalle(2) = oParPVU.cPuntoVentaSinergia 'K_OFICV_CODOFICINA
            arrayDetalle(3) = "" 'K_INTEV_CODINTERLOCUTOR
        Else
            arrayDetalle(2) = "" 'K_OFICV_CODOFICINA
            arrayDetalle(3) = oPar.CodigoInterlocutor 'K_INTEV_CODINTERLOCUTOR
        End If
        arrayDetalle(4) = "" 'K_SERIC_CODSERIE
        arrayDetalle(5) = strMaterialImei 'K_DEPEC_CODMATERIAL
        arrayDetalle(6) = strArticuloImei 'K_DEPEV_DESCMATERIAL
        arrayDetalle(7) = CheckStr(cantidad)  'K_DEPEN_CANTIDAD
        arrayDetalle(8) = CheckStr(strPrecioVentaFinal) 'K_DEPEN_PRECIOVENTA
        arrayDetalle(9) = Funciones.CheckStr(hidNroLinea.Value)  'K_DEPEV_NROTELEFONO
        arrayDetalle(10) = "" 'K_DEPEV_NROCLARIFY
        arrayDetalle(11) = "" 'K_DEPEN_NRORENTA
        arrayDetalle(12) = "" 'K_DEPEN_TOTALRENTA
        arrayDetalle(13) = "" 'K_DEPEN_NROCUOTA
        arrayDetalle(14) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaDevol")  'K_PEDIC_ESQUEMACALCLULO
        arrayDetalle(15) = ConfigurationSettings.AppSettings("constSINERGIAversion60")  'K_PEDIV_VERSIONSAP
        arrayDetalle(16) = codLisPrecio
        arrayDetalle(17) = desLisPrecio
        arrayDetalle(18) = CurrentUser 'K_DEPEV_USUARIOCREA
        arrayDetalle(19) = DateTime.Now.ToString() 'K_DEPED_FECHACREA
        arrayDetalle(20) = CurrentUser 'K_DEPEV_USUARIOMODI                                
        arrayDetalle(21) = DateTime.Now.ToString() 'K_DEPED_FECHAMODI




        'arrayDetalle(0) = ""  ' Documento 
        'arrayDetalle(1) = consecutivo  ' Consecutivo 
        'arrayDetalle(2) = codArticulo  ' Articulo 
        'arrayDetalle(3) = desArticulo  ' Des_Articulo 
        'arrayDetalle(4) = codUtilizacion  ' Utilizacion
        'arrayDetalle(5) = desUtilizacion ' Des_Utilizacion 
        'arrayDetalle(6) = codCamp  ' Campana 
        'arrayDetalle(7) = desCamp  ' Des_Campana 
        'arrayDetalle(8) = ""  ' Serie

        'arrayDetalle(9) = cantidad  ' Cantidad 
        'arrayDetalle(10) = dblMonto  ' Precio 
        'arrayDetalle(11) = dblMonto  ' Precio_Total 

        'arrayDetalle(12) = "0.00"  ' Descuento 
        'arrayDetalle(13) = ""  ' Porc_Descuento
        'arrayDetalle(14) = ""  ' Descuento_Adic 

        'arrayDetalle(15) = dblMonto  ' Subtotal
        'arrayDetalle(16) = dblMontoIGV  ' Impuesto1 

        'arrayDetalle(17) = ""  ' Impuesto2 
        'arrayDetalle(18) = codPlanTarifario  ' Plan_Tarifario
        'arrayDetalle(19) = desPlanTarifario  ' Des_Plan_Tarifar 
        'arrayDetalle(20) = ""  ' Centro_Costo
        'arrayDetalle(21) = ""  ' Motivo_Devolucio 
        'arrayDetalle(22) = ""  ' Asociado
        'arrayDetalle(23) = ""  ' Consecutivo_Padr 
        'arrayDetalle(24) = ""  ' Articulo_Asociac
        'arrayDetalle(25) = nroTelefono  ' Numero_Telefono
        'arrayDetalle(26) = ""  ' Nro_Clarify 
        'arrayDetalle(27) = ""  ' Dev_Componente 

        cadenaDetalle = Join(arrayDetalle, ";")

        GenerarDetalleNotaCredito = cadenaDetalle

    End Function

    Private Function EliminarPedidoSISACT(ByVal documentoSAP As String)
        Try
            Dim oConsulta As New VentaExpressNegocios

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Inicio EliminarVentaRenovacionPostpago()")

            oConsulta.EliminarVentaRenovacionPostpago(documentoSAP)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No se puede Eliminar el Pedido SAP en SISACT:" & documentoSAP)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Error:" & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Fin EliminarVentaRenovacionPostpago()")
        End Try

    End Function

    Private Function GenerarNotaCreditoCC(ByVal facturaPedido As String, _
                                          ByVal documentoSAPNotaCredito As String, _
                                          ByRef documentoSAP As String, ByVal idPedidoMsSap As String) As Boolean

        Dim retorno As Boolean = False
        Try
            ' GENERAR NOTA DE CREDITO CC
            Dim montoDescuento As Double = Double.Parse(Me.txtDescuentoClaroClub.Text)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Inicio GenerarNotaCreditoCC()")

            GenerarProcesoNotaCreditoCC(facturaPedido, _
                                        montoDescuento, _
                                        documentoSAPNotaCredito, _
                                        documentoSAP, idPedidoMsSap)

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception GenerarNotaCreditoCC()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Exception. Generar Nota de Crédito - " & ex.Message)

            Throw New Exception("No se pudo Generar la Nota de Crédito Puntos Claro Club.")
        Finally
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaCreditoCC()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Fin GenerarNotaCreditoCC()")
        End Try

    End Function
    Private Sub GenerarProcesoNotaCreditoCC(ByVal facturaPedido As String, _
                                                ByVal v_montodescuento As Double, _
                                                ByVal documentoSAPNotaCredito As String, _
                                                ByRef documentoSAP As String, ByVal idPedidoMsSap As String)

        Dim resultado As Boolean = False 'PROY 26366

        Dim cadenaCabecera As String
        Dim cadenaDetalle As String

        Dim oficinaVenta As String = hidOficina.Value 'hidOfVenta.Value

        'Generar variables para Generar Nota de Credito
        cadenaCabecera = GenerarCabeceraNotaCredito(v_montodescuento, False, idPedidoMsSap)
        cadenaDetalle = GenerarDetalleNotaCreditoCC(v_montodescuento)

        Dim oConsultaSap As New SapGeneralNegocios
        Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio GenerarProcesoNotaCreditoCC() ")
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> CabeceraProcesoNotaCreditoCC : " & cadenaCabecera)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Input  --> DetalleProcesoNotaCreditoCC  : " & cadenaDetalle)


        'Grabar Nota de Credito
        'Dim notaCreditoGenerado As Boolean = oConsultaSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
        'nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

        Dim oRegPed As New ConsultaMsSapNegocio
        Dim idPedidoNotaCredito As Int64 = 0
        Dim strCodRspt As String = String.Empty
        Dim strMensRspt As String = String.Empty
        Dim pedidoGenerado As Boolean

        'idPedidoNotaCredito = oRegPed.RegistrarPedido(cadenaCabecera, cadenaDetalle, strCodRspt, strMensRspt)

        idPedidoNotaCredito = oRegPed.RegistrarDevolucion(cadenaCabecera, cadenaDetalle, strCodRspt, strMensRspt)
        If (idPedidoNotaCredito > 0) Then
            nroPedido = CheckStr(idPedidoNotaCredito)
            factura = CheckStr(idPedidoNotaCredito)
            pedidoGenerado = True
            'actualizar monto de pedido
            'oRegPed.actualizaPedido(idPedidoNotaCredito)
        Else
            pedidoGenerado = False
        End If


        If idPedidoNotaCredito > 0 Then
            RegistrarCanjePuntos(facturaPedido, _
                                 nroPedido, _
                                 factura, resultado) 'PROY 26366
        End If

        documentoSAP = CheckStr(factura)

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strCodRspt  : " & strCodRspt)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> strMensRspt  : " & strMensRspt)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin GenerarProcesoNotaCreditoCC() ")

        If Not idPedidoNotaCredito > 0 Then
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "  No se pudo crear la Nota de Crédito")
            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        End If

    End Sub

    Private Function GenerarDetalleNotaCreditoCC(ByVal v_montodescuento As Double) As String

        Dim arrayDetalle(28) As String
        Dim cadenaDetalle As String

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
        Dim dblMonto As Double = Math.Round(v_montodescuento / (1 + dblIgv), 2)
        Dim dblMontoIGV As Double = Math.Round(dblMonto * dblIgv, 2)
        Dim dblMontoTotal = Math.Round(dblMonto + dblMontoIGV, 2)
        Dim cantidad As Integer = 1


        Dim oficina As String = hidOfVentaCod.Value
        Dim strMaterialImei As String = CheckStr(txtCodEquipo.Text)
        Dim strArticuloImei As String = CheckStr(hidNombredelEquipoCAC.Value)
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(oficina)    'ParametrosOficinaVenta(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(oficina, "")
        Dim canal As String     'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFC_CANALDISTRIBUCION")))
        Dim orgVenta, sector, strCentro As String   'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFV_ORGANIZACIONVENTAS")))
        canal = oParPVU.canal
        orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia")) 'oParPVU.orgVenta
        strCentro = oParPVU.codigoCentro
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)

        'añadido 26082015
        Dim oPrecios As New PreciosMateriales
        Dim strImei As String = CheckStr(hidIMEI.Value)
        Dim precioBase As Decimal = Funciones.CheckDecimal(v_montodescuento)
        Dim precioVenta As Decimal = Funciones.CheckDecimal(v_montodescuento)
        oPrecios = oConsultaMSSAP.Get_PrecioVenta(strMaterialImei, strImei, precioBase, precioVenta)
        Dim strPrecioVentaFinal As String = Funciones.CheckStr(oPrecios.decPrecioVenta)

        'añadido 26082015



        arrayDetalle(0) = "" 'K_PEDIN_NROPEDIDO
        arrayDetalle(1) = CheckStr(cantidad)
        If oPar.TipoOficina = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            arrayDetalle(2) = oParPVU.cPuntoVentaSinergia 'K_OFICV_CODOFICINA
            arrayDetalle(3) = "" 'K_INTEV_CODINTERLOCUTOR
        Else
            arrayDetalle(2) = "" 'K_OFICV_CODOFICINA
            arrayDetalle(3) = oPar.CodigoInterlocutor 'K_INTEV_CODINTERLOCUTOR
        End If
        arrayDetalle(4) = "" 'K_SERIC_CODSERIE
        arrayDetalle(5) = strMaterialImei 'K_DEPEC_CODMATERIAL
        arrayDetalle(6) = strArticuloImei 'K_DEPEV_DESCMATERIAL
        arrayDetalle(7) = CheckStr(cantidad)  'K_DEPEN_CANTIDAD
        arrayDetalle(8) = CheckStr(strPrecioVentaFinal) 'K_DEPEN_PRECIOVENTA
        arrayDetalle(9) = Funciones.CheckStr(hidNroLinea.Value)  'K_DEPEV_NROTELEFONO
        arrayDetalle(10) = "" 'K_DEPEV_NROCLARIFY
        arrayDetalle(11) = "" 'K_DEPEN_NRORENTA
        arrayDetalle(12) = "" 'K_DEPEN_TOTALRENTA
        arrayDetalle(13) = "" 'K_DEPEN_NROCUOTA
        arrayDetalle(14) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaDevol")  'K_PEDIC_ESQUEMACALCLULO
        arrayDetalle(15) = ConfigurationSettings.AppSettings("constSINERGIAversion60")  'K_PEDIV_VERSIONSAP
        arrayDetalle(16) = codLisPrecio
        arrayDetalle(17) = desLisPrecio
        arrayDetalle(18) = CurrentUser 'K_DEPEV_USUARIOCREA
        arrayDetalle(19) = DateTime.Now.ToString() 'K_DEPED_FECHACREA
        arrayDetalle(20) = CurrentUser 'K_DEPEV_USUARIOMODI                                
        arrayDetalle(21) = DateTime.Now.ToString() 'K_DEPED_FECHAMODI

        'arrayDetalle(0) = ""  ' Documento 
        'arrayDetalle(1) = consecutivo  ' Consecutivo 
        'arrayDetalle(2) = codArticulo  ' Articulo 
        'arrayDetalle(3) = desArticulo  ' Des_Articulo 
        'arrayDetalle(4) = codUtilizacion  ' Utilizacion
        'arrayDetalle(5) = desUtilizacion ' Des_Utilizacion 
        'arrayDetalle(6) = codCamp  ' Campana 
        'arrayDetalle(7) = desCamp  ' Des_Campana 
        'arrayDetalle(8) = ""  ' Serie

        'arrayDetalle(9) = cantidad  ' Cantidad 
        'arrayDetalle(10) = dblMonto  ' Precio 
        'arrayDetalle(11) = dblMonto  ' Precio_Total 

        'arrayDetalle(12) = "0.00"  ' Descuento 
        'arrayDetalle(13) = ""  ' Porc_Descuento
        'arrayDetalle(14) = ""  ' Descuento_Adic 

        'arrayDetalle(15) = dblMonto  ' Subtotal
        'arrayDetalle(16) = dblMontoIGV  ' Impuesto1 

        'arrayDetalle(17) = ""  ' Impuesto2 
        'arrayDetalle(18) = codPlanTarifario  ' Plan_Tarifario
        'arrayDetalle(19) = desPlanTarifario  ' Des_Plan_Tarifar 
        'arrayDetalle(20) = ""  ' Centro_Costo
        'arrayDetalle(21) = ""  ' Motivo_Devolucio 
        'arrayDetalle(22) = ""  ' Asociado
        'arrayDetalle(23) = ""  ' Consecutivo_Padr 
        'arrayDetalle(24) = ""  ' Articulo_Asociac
        'arrayDetalle(25) = nroTelefono  ' Numero_Telefono
        'arrayDetalle(26) = ""  ' Nro_Clarify 
        'arrayDetalle(27) = ""  ' Dev_Componente 

        cadenaDetalle = Join(arrayDetalle, ";")

        GenerarDetalleNotaCreditoCC = cadenaDetalle

    End Function

    Private Function GenerarOCC()
        Dim objCobranza As New CobranzaNegocios

        Dim codOCC As String = "1163" 'Reintegro de Precio del Equipo
        Dim sFecha As String = DateTime.Now.ToShortDateString
        sFecha = sFecha.Substring(6, 4) + sFecha.Substring(3, 2) + sFecha.Substring(0, 2)
        Dim montoExonerar As Double = Double.Parse(hidReintegro.Value)

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))

        dblIgv = dblIgv + 1

        montoExonerar = montoExonerar / dblIgv

        montoExonerar = Math.Round(montoExonerar, 2)

        Dim resultado As Integer = 1
        Dim codInteraccion As String

        GrabarInteraccionOCC(codInteraccion)

        Dim comentario As String = hidNroLinea.Value.Trim & " C" & codInteraccion

        resultado = objCobranza.InsertarAjustesXReclamos(Long.Parse(hidCustumerId.Value), codOCC, sFecha, "1", montoExonerar, comentario)

        If resultado = 0 Then
            auditoriaOCC()
        Else
            Throw New Exception("Error al generar OCC.")
        End If

    End Function

    Private Function GrabarInteraccionOCC(ByRef codInteraccion As String)

        'Guardar Interaccion 
        Dim oInteraccion = New Interaccion

        With oInteraccion
            '.OBJID_CONTACTO = objId
            .TELEFONO = hidNroLinea.Value
            .TIPO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_TIPO")
            .CLASE = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_CLASE")
            .SUBCLASE = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_SUBCLASE")
            .METODO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_METODO")
            .TIPO_INTER = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_TIPO_INTER")
            .AGENTE = Me.CurrentUser
            .USUARIO_PROCESO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_USUARIO")
            .FLAG_CASO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_FLAG")
            .RESULTADO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_RESULTADO")
            .HECHO_EN_UNO = ConfigurationSettings.AppSettings("CONS_OCC_RENOVACION_HECHO")
            .NOTAS = "OCC Generada por Renovación de Equipo Postpago CAC."

        End With
        Dim oInteraccionNegocios As New InteraccionNegocios
        Dim flagInter As String
        Dim mensajeInter As String
        Dim idInteraccion As String


        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "- " & "--- Inicio Region Tipificacion OCC -  Renovacion de Equipo Postpago CAC ---")

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Tipificacion OCC ---")
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo GrabarInteraccionOCC()")


        Try

            Dim resultadoInteraccion As New ItemGenerico
            resultadoInteraccion = oInteraccionNegocios.InsertarInteraccion(oInteraccion)

            idInteraccion = resultadoInteraccion.Codigo
            flagInter = resultadoInteraccion.estado
            mensajeInter = resultadoInteraccion.Descripcion

            codInteraccion = idInteraccion

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "- " & "Id Interaccion : " & idInteraccion)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Flag Metodo : " & flagInter)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Mensaje : " & mensajeInter)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo GrabarInteraccionOCC()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Fin Tipificacion  OCC ---")

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Error al generar Tipificacion  OCC ---")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Eror:" & ex.Message)

        End Try

        Try
            'Insertar Plantilla para OCC
            Dim objPlantillaNegocios As New PlantillaNegocios
            Dim oPlantillaDatos As PlantillaInteraccion
            Dim flagPlantilla As String
            Dim mensajePlantilla As String

            oPlantillaDatos = DatosPlantillaInteracionOCC()

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Inicio Grabar Plantilla OCC ---")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "- " & "Id Interaccion : " & idInteraccion)

            objPlantillaNegocios.InsertarPlantillaInteraccion(oPlantillaDatos, idInteraccion, flagPlantilla, mensajePlantilla)

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Flag Metodo : " & flagPlantilla)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Mensaje : " & mensajePlantilla)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo InsertarPlantillaInteraccion()")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Fin Grabar Plantilla OCC ---")

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Error al generar Plantilla  OCC ---")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "--- Eror:" & ex.Message)

        End Try



    End Function

    Private Function DatosPlantillaInteracionOCC() As PlantillaInteraccion

        Dim pDatos As New PlantillaInteraccion
        pDatos.X_CLARO_NUMBER = hidNroLinea.Value
        pDatos.X_FIRST_NAME = hidApellidosCli.Value
        pDatos.X_LAST_NAME = hidNombresCli.Value
        pDatos.X_ADJUSTMENT_REASON = "Reintegro de Precio del Equipo"
        pDatos.X_ADJUSTMENT_AMOUNT = hidReintegro.Value
        pDatos.X_AMOUNT_UNIT = "+" 'Signo original del concepto
        pDatos.X_REASON = "Cobro (+)"
        pDatos.X_INTER_3 = "1"
        pDatos.X_FLAG_OTHER = "OCC Generada por Renovación de Equipo Postpago CAC."

        Return pDatos
    End Function

    Private Function auditoriaOCC()
        'REGISTRAR AUDITORIA AL GRABAR PEDIDO
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
        Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_GRABAR_OCC")


        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Inicio auditoriaOCC()")

        Dim desAuditoria As String = "Se genera OCC por Renovación Equipo Postpago CAC. " & _
                        " ( Tipo de Documento: " & hidTipoDocumento.Value & _
                        " | Numero de Identidad: " & hidNroDocumento.Value & _
                        " | Nro de Telefono: " & hidNroLinea.Value & _
                        " | Punto de venta:" & hidOficina.Value & _
                        " | Vendedor: " & CheckStr(Session("CodVendedorSAP")) & _
                        " | Contrato:" & hidCO.Value & _
                        " | Tipo AjusteOCCXReclamos :" & "AjustesXReclamos" & _
                        " | Monto OCC:" & hidReintegro.Value & " )"

        Auditoria(desAuditoria, strCodTrans)

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Fin auditoriaOCC()")
    End Function

#End Region

    'Inicio Rihu 19122014 
    <Anthem.Method()> _
    Public Function GrabarSEC() As String
        oClienteCuenta = CType(Session("oClienteCuenta" & hidNroDocumento.Value), ClienteCuenta)
        oClienteOfrecimiento = CType(Session("oClienteOfrecimiento" & hidNroDocumento.Value), ArrayList)

        If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
            GrabarEvaluacionRUC()
        Else
            GrabarEvaluacionDNI()
        End If
        Dim strResultado As String = 0
        Dim flagIdValidator As String = "0"
        If hidGrabar.Value = "1" Then
            If CheckStr(ConfigurationSettings.AppSettings("VCLIENTE")) = "1" Then

                Dim p_intLogs As Integer = 1
                hidValidarCliente.Value = (New BOValidarClienteClaro).ValidarCliente(hidTipoDocumento.Value, hidNroDocumento.Value, hidNroSEC.Value, "03", Now.ToString("ddMMyyyy"), CurrentUser, p_intLogs)
                hidAuditoriaLogs.Value = p_intLogs

            End If
            'PROY-24724-IDEA-28174 - INCIO
            strResultado = hidValidarCliente.Value + "-" + hidNroSEC.Value + "-" + hidAuditoriaLogs.Value + "-" + hidTipoOferta.Value
            'PROY-24724-IDEA-28174 - FIN
        End If

        Return strResultado
    End Function

    <Anthem.Method()> _
    Public Sub cargarPDV(ByVal pdv As String)
        ConsultarDatosVenta()

    End Sub

    'PROY-24740
    <Anthem.Method()> _
    Public Function cargarListadoEquipo(ByVal pdv As String) As String

        Dim lista As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim tipoVenta As String = hidPuntoVenta.Value
        Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
        Dim strCampana, strPlan As String
        Dim strResultado As New StringBuilder
        Dim oConsultaMSS As New ConsultaMsSapNegocio

        oLog.Log_WriteLog(strArchivo, String.Format("{0}- INICIO CARGAR LISTADO DE EQUIPOS - ", strIdentifyLog))

        For Each plan As PlanDetalleVenta In arrPlanDetalle
            strCampana = plan.CAMPANA
            strPlan = plan.PLANC_CODIGO
            Exit For
        Next

        'CVM
        oLog.Log_WriteLog(strArchivo, String.Format("{0}- PUNTO DE VENTA - {1}", strIdentifyLog, pdv))
        lista = oConsultaMSS.ConsultarStock(pdv, String.Empty, String.Empty)

        oLog.Log_WriteLog(strArchivo, String.Format("{0}- FIN DE CARGAR LISTADO DE EQUIPOS - ", strIdentifyLog))

        For Each it As ItemGenerico In lista
            If CheckStr(it.tipoMaterial) = "TV0003" Then
            listaMaterial.Add(it)
            End If
        Next

        For Each objMaterial As ItemGenerico In listaMaterial
            strResultado.AppendFormat("|{0};{1}", objMaterial.Codigo, objMaterial.Descripcion)
        Next

        Dim strMostrarEquipoPromo As String = String.Empty
        strMostrarEquipoPromo = Session("MostrarEquipoPromo")

        If strMostrarEquipoPromo = "S" Then
        Dim dtGama As DataTable = (New ConsumerNegocio).ObtenerEquipoGama()
        For Each dr As DataRow In dtGama.Rows
            If dr("eqgan_orden") = "1" Then
                    strResultado.Insert(0, String.Format("|{0};{1}", dr("eqgac_codigo"), dr("eqgav_descripcion")))
            Else
                    strResultado.AppendFormat("|{0};{1}", dr("eqgac_codigo"), dr("eqgav_descripcion"))
            End If
        Next
        End If
        Return strResultado.ToString()
    End Function

#Region "Renta Adelantada"

    Private Function GenerarCadenaCabeceraRenta() As String
        Dim cadenaCabeceraRenta As String

        'ini sinergia 31072015
        Dim oConsultarSap As New SapGeneralNegocios
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim ccliente As New BECliente
        'fin sinergia 31072015

        Try
            Dim oficina As String = CheckStr(hidOficina.Value)
            Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
            Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)
            If Not hidPerfil_149.Value = "S" Then
                codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
            End If

            Dim nroDocCliente As String = CheckStr(hidNroDocumento.Value)
            Dim tipoDocCliente As String = CheckStr(hidTipoDocumento.Value)
            Dim tipoVenta As String = hidTipoVenta.Value            'ConfigurationSettings.AppSettings("strPostpagoTipoVenta") = 01
            Dim tipoCliente As String = hidTipoClienteSAP.Value     'ConfigurationSettings.AppSettings("constCodTipoClienteConsumer") = 02
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")

            'ini sinergia 31072015
            'ConsultarTipoDocVenta()
            Dim tipoDocVenta As String ' = CheckStr(hidTipoDocVenta.Value)

            'Dim arrayTipoDocVenta() As String = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & tipoDocCliente).Split(CChar(","))

            If (tipoDocCliente = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC")) Then
                tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaRUC")
                'tipoDocVenta = arrayTipoDocVenta(1)
            Else
                tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaNORUC")
                'tipoDocVenta = arrayTipoDocVenta(2)
            End If

            'fin sinergia 31072015

            Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")

            Dim precios As String = CheckStr(hidDatosEquipo.Value)
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)

            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))

            'ini sinergia 31072015



            Dim strSector As String = ConfigurationSettings.AppSettings("constSINERGIASectorPostpagoEquipoChip")


            'Dim canal As String = CheckStr(hidCanalSap.Value)
            'Dim orgVenta As String = CheckStr(hidOrgVenta.Value)
            Dim oPar As BEParametroOficina
            oPar = oConsultaMSSAP.ParametrosOficina(oficina)    'ParametrosOficinaVenta(oficina)
            Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(oficina, "")
            Dim canal As String     'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFC_CANALDISTRIBUCION")))
            Dim orgVenta, sector, strCentro As String   'Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("PAOFV_ORGANIZACIONVENTAS")))
            canal = CheckStr(ConfigurationSettings.AppSettings("ConsCanalMSSAP")) 'oParPVU.canal
            orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia")) 'oParPVU.orgVenta
            strCentro = oParPVU.codigoCentro
            sector = strSector.PadLeft(2, CChar("0"))

            Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")

            Dim CodInterlocutor As String = ""

            Dim ClaseFactura As String = ConfigurationSettings.AppSettings("ConsCodigoRenta"), DescripcionFactura As String = ConfigurationSettings.AppSettings("ConsDescripcionRenta")

            For Each item As String In ConfigurationSettings.AppSettings("ConsTipoDNIFactura").Split(CChar(";"))
                If tipoDocCliente = Funciones.CheckStr(item) Then
                    ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoFactura")
                    DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionFactura")
                    Exit For
                End If
            Next

            'fin sinergia 31072015
            Dim DestinoMercaderia As String = Nothing

            If oPar.TipoOficina <> ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                DestinoMercaderia = oPar.CodigoInterlocutor
            End If

            'fin sinergia 31072015


            'ini sinergia 31072015

            Dim codvend As String = "0000000000" + codigoVendedorSAP
            Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")

            'Cadena Documento
            Dim arrayCabecera(52) As String

            If oPar.TipoOficina = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                arrayCabecera(0) = oParPVU.cPuntoVentaSinergia     'K_OFICV_CODOFICINA
                arrayCabecera(1) = "" 'oPar.codigoOficinaMSSAP               'K_INTEV_CODINTERLOCUTOR
            Else
                arrayCabecera(0) = "" 'oPar.codigoOficinaMSSAP      'K_OFICV_CODOFICINA
                arrayCabecera(1) = oPar.CodigoInterlocutor          'K_INTEV_CODINTERLOCUTOR
            End If

            'Tipo_Documento
            arrayCabecera(2) = ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoRenta")  'oficina                               'Oficina_Venta
            arrayCabecera(3) = orgVenta 'Now.ToString("dd/MM/yyyy")           'String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
            arrayCabecera(4) = canal 'tipoDocCliente                        'Tipo_Doc_Cliente
            arrayCabecera(5) = sector 'nroDocCliente                         'Cliente
            arrayCabecera(6) = ConfigurationSettings.AppSettings("ConsTipoVentasPostpago")
            arrayCabecera(7) = Now.ToString()  'moneda                                'Moneda
            arrayCabecera(8) = ConfigurationSettings.AppSettings("ConsMotivoPedidoPortabilidad")
            arrayCabecera(9) = ClaseFactura  'totalSinIGV                           'Total_Mercaderia
            arrayCabecera(10) = DescripcionFactura 'totalIGV                             'Total_Impuesto
            arrayCabecera(11) = DestinoMercaderia  'totalConIGV                          'Total_Documento
            arrayCabecera(12) = ConfigurationSettings.AppSettings("constSINERGIAClasePedidoFacturas") '""                                  'Fecha registro
            arrayCabecera(13) = tipoOperacion
            arrayCabecera(14) = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion") 'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayCabecera(15) = Now.ToString()  'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayCabecera(16) = ConfigurationSettings.AppSettings("constAplicacion") ' tipoVenta                            'Tipo_Venta
            arrayCabecera(17) = CheckStr(Session("CodVendedorSAP")) 'codigoVendedorSAP '""
            arrayCabecera(18) = ConfigurationSettings.AppSettings("ConsDocPrepagoPendientes")
            arrayCabecera(19) = "S"
            arrayCabecera(20) = "0"
            arrayCabecera(21) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad")
            arrayCabecera(22) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaRenta")                                 'Fecha Vta Or
            arrayCabecera(23) = tipoDocCliente
            arrayCabecera(24) = nroDocCliente                            'nro_cuota
            arrayCabecera(25) = Funciones.CheckStr(hidTipoCliente.Value) 'CheckStr(Session("CodVendedorSAP"))  'nro clarify
            arrayCabecera(26) = oSolicitud.CLIEV_NOMBRE
            arrayCabecera(27) = oSolicitud.CLIEV_APE_PAT                      'Vendedor
            arrayCabecera(28) = oSolicitud.CLIEV_APE_MAT
            arrayCabecera(29) = ConfigurationSettings.AppSettings("ConsDefaultFechaNacimiento")                       'Renovacion
            arrayCabecera(30) = oSolicitud.CLIEV_RAZ_SOC                             'Descripción Renovacion
            arrayCabecera(31) = oSolicitud.SOLIV_CORREO
            arrayCabecera(32) = ConfigurationSettings.AppSettings("ConsSinInformacion")
            arrayCabecera(33) = oSolicitud.ESTADO_CIVIL_ID
            arrayCabecera(34) = ConfigurationSettings.AppSettings("ConsSinInformacion")
            arrayCabecera(35) = "0"
            arrayCabecera(36) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(5, 4)  'Nro hdc
            arrayCabecera(37) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(0, 2)
            arrayCabecera(38) = ConfigurationSettings.AppSettings("ConsPais")
            arrayCabecera(39) = tipoDocCliente
            arrayCabecera(40) = nroDocCliente
            arrayCabecera(41) = ""
            arrayCabecera(42) = ""
            arrayCabecera(43) = ""
            arrayCabecera(44) = oPar.TipoOficina
            arrayCabecera(45) = ""                                  'Tipo_Prod_Operad (01 Postpago; 02 Prepago)
            arrayCabecera(46) = CurrentUser
            arrayCabecera(47) = Now.ToString()
            arrayCabecera(48) = CurrentUser                             'Orgvnt
            arrayCabecera(49) = Now.ToString()                                'Canal
            arrayCabecera(50) = ""
            arrayCabecera(51) = "0"

            cadenaCabeceraRenta = Join(arrayCabecera, ";")
            'fin sinergia 31072015

        Catch ex As Exception
            cadenaCabeceraRenta = ""
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error GenerarCadenaCabecera: " & ex.Message)
        End Try

        Return cadenaCabeceraRenta
    End Function

    Private Function GenerarCadenaDeposito(ByVal cadenaCabecera As String, ByVal nroContrato As String, ByVal nroPedido As String, ByVal nroSec As String, ByRef dblMontoDeposito As Double, ByRef sTipoDeposito As String, ByRef tipoGarantia As String) As String

        Dim tipoDeposito As String = CheckStr(hidcodGarantia.Value)
        Dim montoDeposito As Double = CheckDbl(hidImporteRenta.Value)  'cambiar a produccion
        Dim tipoGarantiaSAP As String = ""
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        'ini sinergia 06082015
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(strCodOficina)    'ParametrosOficinaVenta(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(strCodOficina, "")
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        'fin sinergia 06082015

        'Código cpd
        codCorporativo = oParPVU.CodigoCpdCorporativo
        codMasivo = oParPVU.CodigoCpdMasivo

        If tipoDeposito = "" Or tipoDeposito = "0" Or montoDeposito <= 0 Then
            GenerarCadenaDeposito = ""
            Exit Function
        End If

        If tipoDeposito = "1" Then ' Deposito en Garantia
            tipoGarantiaSAP = "DE"
        ElseIf tipoDeposito = "2" Then  ' Renta Adelantada
            tipoGarantiaSAP = "DL"
        ElseIf tipoDeposito = "3" Then  ' Pago Adelantado
            tipoGarantiaSAP = "DX"
        End If

        tipoGarantia = tipoGarantiaSAP

        Dim strMaterialImei As String = CheckStr(txtMaterialImei.Text)
        Dim strArticuloImei As String = CheckStr(txtArticuloImei.Text)
        Dim cantidad As Integer = 1
        Dim arrDeposito(23) As String

        ' Dim arrCabecera() As String = cadenaCabecera.Split(";"c)
        arrDeposito(0) = "" 'arrCabecera(4) 'tipo cliente
        arrDeposito(2) = oPar.CodigoInterlocutor  'nro de doc del cliente
        arrDeposito(3) = ""  'fecha actual
        arrDeposito(4) = strMaterialImei ' fecha actual sumado mas 30 dias
        arrDeposito(5) = strArticuloImei
        arrDeposito(6) = Funciones.CheckStr(cantidad)
        arrDeposito(7) = Funciones.CheckStr(montoDeposito)
        arrDeposito(8) = CheckStr(hidNroLinea.Value)
        arrDeposito(9) = "0"   'CheckStr(montoDeposito) modificar produccion
        arrDeposito(10) = "0"
        arrDeposito(11) = ""
        arrDeposito(12) = ""
        arrDeposito(13) = codLisPrecio
        arrDeposito(14) = desLisPrecio
        arrDeposito(15) = CurrentUser
        arrDeposito(16) = DateTime.Now.ToString()
        arrDeposito(17) = CurrentUser
        arrDeposito(18) = DateTime.Now.ToString()
        arrDeposito(19) = ""
        dblMontoDeposito = CheckDbl(hidImporteRenta.Value) 'montoDeposito modificar produccion
        sTipoDeposito = tipoDeposito
        GenerarCadenaDeposito = Join(arrDeposito, ";")

    End Function
#End Region

    Public Sub GrabarVenta(ByVal strCadenaPlanes As String, ByRef IdVenta As Int64)

        Dim dblPrecioSinIGv As Double = 0, dblPrecioConIGv = 0
        Dim oVenta As New VentaExpressNegocios
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Registro Venta SISACT")
        dblPrecioConIGv = ObtenerPreciosTotal(strCadenaPlanes, dblPrecioSinIGv)

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "dblPrecioConIGv: " & dblPrecioConIGv)
        Dim Nro_Cuotas As String = hidCuota.Value
        Dim cadenaCabecera As String = getCadenaVentaCabecera(Nro_Cuotas, dblPrecioSinIGv, dblPrecioConIGv)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "cadenaCabecera: " & cadenaCabecera)
        Dim cadenaDetalle As String = getCadenaVentaDetalle()
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "getCadenaVentaDetalle: " & getCadenaVentaDetalle())
        If Not cadenaDetalle.Equals("") Then
            IdVenta = oVenta.GrabarVenta(cadenaCabecera, cadenaDetalle)
        End If
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "IdVenta: " & IdVenta)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "fin Registro Venta SISACT")

    End Sub

    Public Function ObtenerPreciosTotal(ByVal strCadenaPlanes As String, ByRef dblPrecioSinIgv As Double) As Double

        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "ObtenerPreciosTotal")
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "strCadenaPlanes: " & strCadenaPlanes)
        Dim dblPrecioConIgv As Double = 0
        dblPrecioSinIgv = 0
        Dim arrPlanes As String() = CheckStr(strCadenaPlanes).Split(",")
        dblPrecioSinIgv = Funciones.CheckDbl(arrPlanes(3))
        dblPrecioConIgv = Funciones.CheckDbl(arrPlanes(1))
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "dblPrecioConIgv: " & dblPrecioConIgv)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & " fin ObtenerPreciosTotal")
        Return dblPrecioConIgv
    End Function

    Public Function getCadenaVentaCabecera(ByVal nroCuota As String, ByVal dblPrecioSinIGv As Double, ByVal dblPrecioConIGv As Double) As String
        Dim oMaestro As New MaestroNegocio
        Dim oConsultaSolicitud As New SolicitudNegocios
        Dim oUsuario As Usuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)        
        Dim listaSec As ArrayList = oConsultaSolicitud.ObtenerSolicitudes(hidNroSEC.Value)

        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
        Dim strTipoDocVenta As String = hidTipoDocVentaCAC.Value
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        For Each item As SolicitudPersona In listaSec
            'Obtener SEC padre
            If item.SOLIN_CODIGO = item.SOLIN_GRUPO_SEC Then
                oSolicitud = CType(item, SolicitudPersona)
            End If
        Next

        Dim arrCabecera(21) As String
        arrCabecera(0) = "" 'p_resultado
        arrCabecera(1) = "" 'p_msgerr
        arrCabecera(2) = "" 'p_documento
        arrCabecera(3) = ObtenerTipoDocumentoVenta(oSolicitud.TDOCC_CODIGO) 'p_tipo_documento
        arrCabecera(4) = strCodCanal 'p_canal
        arrCabecera(5) = strCodOficina 'p_oficina_venta
        arrCabecera(6) = oSolicitud.TDOCC_CODIGO 'p_tipo_doc_cliente
        arrCabecera(7) = oSolicitud.CLIEC_NUM_DOC 'p_nro_doc_cliente
        arrCabecera(8) = moneda 'p_moneda
        arrCabecera(9) = Funciones.CheckStr(ConfigurationSettings.AppSettings("constCodOperRenovacionPVU")) 'p_topen_codigo
        arrCabecera(10) = Funciones.CheckStr(dblPrecioConIGv) 'p_total_venta
        arrCabecera(11) = Funciones.CheckStr(dblPrecioConIGv - dblPrecioSinIGv) 'p_subtotal_impuesto
        arrCabecera(12) = Funciones.CheckStr(dblPrecioSinIGv) 'p_subtotal_venta
        arrCabecera(13) = "" 'p_observacion
        arrCabecera(14) = oSolicitud.TVENC_CODIGO 'p_tven_codigo
        arrCabecera(15) = "" 'p_numero_referencia
        arrCabecera(16) = Me.CurrentUser 'p_usuario_crea
        arrCabecera(17) = nroCuota 'p_numero_cuotas
        arrCabecera(18) = CheckStr(Session("CodVendedorSAP")) 'p_vendedor
        arrCabecera(19) = hidOrgVenta.Value 'p_org_venta
        arrCabecera(20) = Funciones.CheckStr(hidNroSEC.Value) 'p_numero_sec
        Return String.Join(";", arrCabecera)
    End Function

    'agregado 12102015

    Function ObtenerTipoDocumentoVenta(ByVal strCodTipoDocCliente As String) As String
        Dim tipoDocVenta As String
        If strCodTipoDocCliente = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Then
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaRUC")
        Else
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaNORUC")
        End If
        Return tipoDocVenta
    End Function

    'agregado 12102015


    Public Function getCadenaVentaDetalle() As String
        Dim arrDetalle(23) As String
        Dim cadenaDetalle As String = ""
        Dim intContDetalle As Integer = 0

        Dim cadenaSeriesAgregadas As String = ""
        Dim strMaterialICCID As String = CheckStr(txtCodChip.Text)
        Dim strArticuloICCID As String = ""
        Dim strSerieChip As String = CheckStr(hidIccid.Value)
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim codPlan As String = planTarifa.Split(","c)(1)
        Dim desPlan As String = planTarifa.Split(","c)(2)
        Dim campania As String = CheckStr(hidCampaniaSelected.Value)
        Dim codCampania As String = campania.Split(","c)(0)
        Dim desCampania As String = campania.Split(","c)(1)
        Dim listaPrecioChip, codLisPrecioChip, desLisPrecioChip As String
        Dim descuentoICCID As String = String.Empty
        Dim totalSinIGVICCID As String = String.Empty
        Dim totalConIGVICCID As String = String.Empty
        Dim precioListaICCID As String = String.Empty
        Dim totalIGVICCID As String = String.Empty

        Dim strMaterialImei As String
        Dim strArticuloImei As String
        Dim strImei As String

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            strMaterialImei = CheckStr(txtCodEquipo.Text)
            strArticuloImei = CheckStr(hidNombredelEquipoCAC.Value)
            strImei = CheckStr(hidIMEI.Value)
        Else
            strMaterialImei = CheckStr(txtMaterialImei.Text)
            strArticuloImei = CheckStr(txtArticuloImei.Text)
            strImei = CheckStr(txtImei.Text)
        End If

        Dim precios As String = CheckStr(hidDatosEquipo.Value)
        Dim descuento As String = precios.Split(","c)(0)
        Dim totalSinIGV As String = precios.Split(","c)(3)
        Dim totalConIGV As String = precios.Split(","c)(1)
        Dim precioLista As String = precios.Split(","c)(2)
        Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        Dim strTelefono As String = CheckStr(hidNroLinea.Value)
        Dim codTipoProducto As String = ConfigurationSettings.AppSettings("constTipoProductoMovil")
        Dim preciosICCID As String

        Dim Nro_Cuotas As String = hidCuota.Value

        If hidValidarIccid.Value.Equals("1") Then
            If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                strArticuloICCID = CheckStr(hidNombredelChipCAC.Value)
            Else
                strMaterialICCID = CheckStr(txtMaterialICCID.Text)
                strArticuloICCID = CheckStr(txtArticuloICCID.Text)
            End If
            preciosICCID = CheckStr(hidDatosChip.Value)
            descuentoICCID = preciosICCID.Split(","c)(0)
            totalSinIGVICCID = preciosICCID.Split(","c)(3)
            totalConIGVICCID = preciosICCID.Split(","c)(1)
            precioListaICCID = preciosICCID.Split(","c)(2)
            totalIGVICCID = CheckStr(CheckDbl(totalConIGVICCID) - CheckDbl(totalSinIGVICCID))

            listaPrecioChip = CheckStr(hidPLSelected.Value)
            codLisPrecioChip = listaPrecioChip.Split(","c)(0)
            desLisPrecioChip = listaPrecioChip.Split(","c)(1)
        End If

        If hidValidarIccid.Value.Equals("1") Then
            intContDetalle += 1

            arrDetalle(0) = "" 'p_resultado         
            arrDetalle(1) = "" 'p_msgerr            
            arrDetalle(2) = intContDetalle.ToString() 'p_correlativo       
            arrDetalle(3) = "" 'p_documento         
            arrDetalle(4) = CheckStr(strMaterialICCID) 'p_material          
            arrDetalle(5) = CheckStr(strArticuloICCID) 'p_material_desc     
            arrDetalle(6) = codPlan 'p_plan              
            arrDetalle(7) = desPlan 'p_plan_desc         
            arrDetalle(8) = strTelefono 'p_telefono          
            arrDetalle(9) = codCampania 'p_campana           
            arrDetalle(10) = desCampania 'p_campana_desc      
            arrDetalle(11) = "1" 'p_cantidad          
            arrDetalle(12) = precioListaICCID 'p_precio            
            arrDetalle(13) = descuentoICCID 'p_descuento         
            arrDetalle(14) = totalSinIGVICCID 'p_subtotal          
            arrDetalle(15) = totalIGVICCID 'p_igv  --> impuesto              
            arrDetalle(16) = totalConIGVICCID 'p_total             
            arrDetalle(17) = codLisPrecioChip 'p_lista_precio      
            arrDetalle(18) = desLisPrecioChip 'p_lista_precio_desc 
            arrDetalle(19) = strSerieChip 'p_imei19   
            arrDetalle(20) = "" 'Funciones.CheckStr(arrPlanDetalle(12).Split("#")(0)) 'p_cuotas   
            arrDetalle(21) = "" 'arrPlanDetalle(12).Split("#")(1) 'p_des_cuotas
            arrDetalle(22) = codTipoProducto

            If (cadenaDetalle.Length > 0) Then
                cadenaDetalle += "|" + String.Join(";", arrDetalle)
            Else
                cadenaDetalle = String.Join(";", arrDetalle)
            End If
            cadenaSeriesAgregadas += "|" + strSerieChip 'p_imei19   
        End If

        intContDetalle += 1
        arrDetalle(0) = "" 'p_resultado         
        arrDetalle(1) = "" 'p_msgerr            
        arrDetalle(2) = intContDetalle.ToString() 'p_correlativo       
        arrDetalle(3) = "" 'p_documento         
        arrDetalle(4) = strMaterialImei 'p_material          
        arrDetalle(5) = strArticuloImei 'p_material_desc 
        arrDetalle(6) = codPlan 'p_plan              
        arrDetalle(7) = desPlan 'p_plan_desc         
        arrDetalle(8) = strTelefono 'p_telefono          
        arrDetalle(9) = codCampania 'p_campana           
        arrDetalle(10) = desCampania 'p_campana_desc 
        arrDetalle(11) = "1" 'p_cantidad          
        arrDetalle(12) = precioLista 'p_precio            
        arrDetalle(13) = descuento 'p_descuento         
        arrDetalle(14) = totalSinIGV 'p_subtotal          
        arrDetalle(15) = totalIGV 'p_igv  --> impuesto              
        arrDetalle(16) = totalConIGV 'p_total
        arrDetalle(17) = codLisPrecio 'p_lista_precio      
        arrDetalle(18) = desLisPrecio 'p_lista_precio_desc 
        arrDetalle(19) = strImei 'p_imei19 
        arrDetalle(20) = Nro_Cuotas 'Funciones.CheckStr(arrPlanDetalle(12).Split("#")(0)) 'p_cuotas   
        arrDetalle(21) = "" 'arrPlanDetalle(12).Split("#")(1) 'p_des_cuotas
        arrDetalle(22) = codTipoProducto

        If (cadenaDetalle.Length > 0) Then
            cadenaDetalle += "|" + String.Join(";", arrDetalle)
        Else
            cadenaDetalle = String.Join(";", arrDetalle)
        End If

        Return cadenaDetalle
    End Function

    Public Sub GenerarAcuerdo(ByVal IdVenta As Int64, ByRef nroAcuerdoSisact As Int64)
        Dim cadenaDetalle As String = "", cadenaServicios = "", cadenaAcuerdo = "", datosAcuerdoEquipo = ""
        Dim arrIdxPosChip As String()
        Dim oVenta As New VentaExpressNegocios

            cadenaDetalle = getCadenaDetalle()
            cadenaServicios = getCadenaServicios(Funciones.CheckStr(hidNroSEC.Value), cadenaDetalle, ObtenerServ())
            cadenaAcuerdo = getCadenaAcuerdo(IdVenta)
            datosAcuerdoEquipo = getCadenaDetalleEquipo()

            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Acuerdo SISACT")
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "cadenaDetalle : " & cadenaDetalle)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "cadenaServicios : " & cadenaServicios)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "cadenaAcuerdo : " & cadenaAcuerdo)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "datosAcuerdoEquipo : " & datosAcuerdoEquipo)

            nroAcuerdoSisact = oVenta.GenerarAcuerdo(cadenaAcuerdo, cadenaDetalle, cadenaServicios, datosAcuerdoEquipo)
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "nro acuerdo: " & nroAcuerdoSisact)

    End Sub

    Public Function getCadenaDetalle() As String

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        'string[] arrPlanes = strCadenaPlanes.Split('|');
        Dim arrAcuerdoDet(35) As String
        Dim cadenaDetalle As String = ""
        'Inicio Servicios Adicionales - Roaming JAZ
        Dim intContDetalle As Integer = 1
        'Fin Servicios Adicionales - Roaming JAZ
        Dim intContLinea As Integer = 0
        Dim arrIdxPosChip As String()
        Dim nroSec As String = ""
        Dim cadenaCodTipoProducto As String = ""
        Dim strTelefono As String = CheckStr(hidNroLinea.Value)
        nroSec = ""
        Dim idSolPlan As String = ""
        Dim strMaterialICCID As String = CheckStr(txtCodChip.Text)
        Dim strArticuloICCID As String = ""
        Dim strSerieChip As String = CheckStr(hidIccid.Value)
        Dim campania As String = CheckStr(hidCampaniaSelected.Value)
        Dim codCampania As String = campania.Split(","c)(0)
        Dim desCampania As String = campania.Split(","c)(1)
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        Dim precios As String = CheckStr(hidDatosEquipo.Value)
        Dim descuento As String = precios.Split(","c)(0)
        Dim totalSinIGV As String = precios.Split(","c)(3)
        Dim totalConIGV As String = precios.Split(","c)(1)
        Dim precioLista As String = precios.Split(","c)(2)
        Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim codPlan As String = planTarifa.Split(","c)(1)
        Dim desPlan As String = planTarifa.Split(","c)(2)
        Dim codTipoProducto As String = ConfigurationSettings.AppSettings("constTipoProductoMovil")
        Dim plazoAcuerdo As String = hidPlazoAcuerdo.Value
        Dim descuentoICCID As String = String.Empty
        Dim totalSinIGVICCID As String = String.Empty
        Dim totalConIGVICCID As String = String.Empty
        Dim precioListaICCID As String = String.Empty
        Dim totalIGVICCID As String = String.Empty
        Dim preciosICCID As String
        'Dim codPlazoAcuerdo As String = "", desPlazoAcuerdo As String = "", tmcode As String = "", strCodPlanSisact As String = ""
        'Dim cargo_fijo As Double = 0
        Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
        Dim cargo_fijo As Double = ConsultarCFTotal(arrPlanDetalle)
        Dim Nro_Cuotas As String = hidCuota.Value

        Dim nroRecibo = "1"
        Dim strMaterialImei As String
        Dim strArticuloImei As String
        Dim strImei As String

        If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            strMaterialImei = CheckStr(txtCodEquipo.Text)
            strArticuloImei = CheckStr(hidNombredelEquipoCAC.Value)
            strImei = CheckStr(hidIMEI.Value)
        Else
            strMaterialImei = CheckStr(txtMaterialImei.Text)
            strArticuloImei = CheckStr(txtArticuloImei.Text)
            strImei = CheckStr(txtImei.Text)
        End If

        'agregado 12102015
        Dim objSans As New SimCardRepoNegocios
        Dim oConsultaMSS As New ConsultaMsSapNegocio
        Dim itemSans As New ItemGenerico
        Dim mensajeResultado As String = String.Empty
        Dim boolsans As Boolean = False
        Dim strSerieSans As String = String.Empty
        Dim strMaterialSans As String = String.Empty
        Dim strMaterialDesSans As String = String.Empty
        Dim arrPrecioBase As ArrayList
        Dim blnMaterial46 As Boolean = True
        boolsans = objSans.ValidaDatosNroTelef(strTelefono, "", "", CurrentUser, strMaterialSans, strSerieSans, mensajeResultado)

        Dim objConsultaMsSap As New BLConsultaMssap
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Inicio ConsultaPrecioApadece - Parametro entrada strMaterialImei " & strMaterialImei)
        Dim strPrecioApadece = objConsultaMsSap.ConsultaPrecioApadece(strMaterialImei)
        oLog.Log_WriteLog(strArchivo, strIdentifyLog & " - Resultado ConsultaPrecioApadece - strPrecioApadece " & strPrecioApadece)

        If boolsans Then
            If strMaterialSans <> String.Empty Then
                Try
                    blnMaterial46 = Not (Funciones.CheckInt(strMaterialSans) > 0)

                Catch ex As Exception
                    blnMaterial46 = True
                End Try

                If blnMaterial46 Then
                    itemSans = oConsultaMSS.ConsultaMaterial46(strMaterialSans)
                End If

                If CheckStr(itemSans.Codigo) <> String.Empty Then
                    strMaterialSans = CheckStr(itemSans.Codigo)
                End If

                arrPrecioBase = oConsultaMSS.ConsultaPrecioBaseMaterial(CheckStr(strMaterialSans))
                For Each item As ItemGenerico In arrPrecioBase
                    strMaterialDesSans = CheckStr(item.Descripcion)
                Next
            Else
                strMaterialSans = String.Empty
                strSerieSans = String.Empty
                strMaterialDesSans = String.Empty
            End If

        Else
            strMaterialSans = String.Empty
            strSerieSans = String.Empty
            strMaterialDesSans = String.Empty
        End If

        'agregado 12102015

        arrAcuerdoDet(0) = "" 'P_COD_RESPUESTA    
        arrAcuerdoDet(1) = "" 'P_MSJ_RESPUESTA    
        arrAcuerdoDet(2) = "" 'P_NROACUERDO       
        arrAcuerdoDet(3) = Funciones.CheckStr(intContDetalle) 'P_CONSECUTIVO      
        arrAcuerdoDet(4) = strMaterialSans 'strMaterialImei 'P_ARTICULO         
        arrAcuerdoDet(5) = "" 'strArticuloImei 'P_DES_ARTICULO     
        arrAcuerdoDet(6) = codLisPrecio 'P_UTILIZACION      
        arrAcuerdoDet(7) = desLisPrecio 'P_DES_UTILIZACION  
        arrAcuerdoDet(8) = codCampania 'P_CAMPANA          
        arrAcuerdoDet(9) = desCampania 'P_DES_CAMPANA      
        arrAcuerdoDet(10) = strSerieSans 'strImei 'P_SERIE            
        arrAcuerdoDet(11) = "1" 'P_CANTIDAD         
        arrAcuerdoDet(12) = strPrecioApadece 'P_PRECIO_LISTA =   P_PRECIO * (1 + IGV) 
        arrAcuerdoDet(13) = totalConIGV 'P_PRECIO_TOTAL  
        arrAcuerdoDet(14) = precioLista 'P_PRECIO    
        arrAcuerdoDet(15) = descuento 'P_DESCUENTO        
        arrAcuerdoDet(16) = totalSinIGV 'P_SUBTOTAL         
        arrAcuerdoDet(17) = totalIGV 'P_IMPUESTO         
        arrAcuerdoDet(18) = codPlan 'arrPlanDetalle(14)'P_PLAN_TARIFARIO   
        arrAcuerdoDet(19) = desPlan 'P_DES_PLAN_TARIFAR 
        arrAcuerdoDet(20) = strTelefono 'P_NUMERO_TELEFONO  
        arrAcuerdoDet(21) = "1" 'P_PRINCIPAL
        arrAcuerdoDet(22) = strMaterialImei 'P_COD_EQUIPO
        arrAcuerdoDet(23) = strArticuloImei 'P_DES_EQUIPO
        arrAcuerdoDet(24) = strImei 'P_SERIE_EQUIPO
        arrAcuerdoDet(25) = plazoAcuerdo 'P_PACUC_CODIGO
        arrAcuerdoDet(26) = "" 'desPlazoAcuerdo 'P_PACUV_DESCRIPCION
        arrAcuerdoDet(27) = codTipoProducto 'P_PRDC_CODIGO
        arrAcuerdoDet(28) = nroRecibo 'P_RECIBO
        arrAcuerdoDet(29) = nroSec 'P_SOLIN_CODIGO
        arrAcuerdoDet(30) = Nro_Cuotas 'arrPlanDetalle(12).Split("#")(0) 'p_cuotas
        arrAcuerdoDet(31) = "" 'arrPlanDetalle(12).Split("#")(1) 'p_des_cuotas
        arrAcuerdoDet(32) = "" 'tmcode 'p_des_cuotas
        arrAcuerdoDet(33) = cargo_fijo.ToString() 'p_cargo_fijo
        arrAcuerdoDet(34) = idSolPlan.ToString() 'p_slpln_codigo

        If hidValidarIccid.Value.Equals("1") Then
            If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                strArticuloICCID = CheckStr(hidNombredelChipCAC.Value)
            Else
                strMaterialICCID = CheckStr(txtMaterialICCID.Text)
                strArticuloICCID = CheckStr(txtArticuloICCID.Text)
            End If
            preciosICCID = CheckStr(hidDatosChip.Value)
            descuentoICCID = preciosICCID.Split(","c)(0)
            totalSinIGVICCID = preciosICCID.Split(","c)(3)
            totalConIGVICCID = preciosICCID.Split(","c)(1)
            precioListaICCID = preciosICCID.Split(","c)(2)
            totalIGVICCID = CheckStr(CheckDbl(totalConIGVICCID) - CheckDbl(totalSinIGVICCID))

            'arrAcuerdoDet(12) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(12)) + Funciones.CheckDbl(precioListaICCID)) 'P_PRECIO_LISTA =   P_PRECIO * (1 + IGV) 
            arrAcuerdoDet(13) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(13)) + Funciones.CheckDbl(totalConIGVICCID)) '//P_PRECIO_TOTAL  
            arrAcuerdoDet(14) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(14)) + Funciones.CheckDbl(precioListaICCID)) ';//P_PRECIO    
            arrAcuerdoDet(15) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(15)) + Funciones.CheckDbl(descuentoICCID)) ';//P_DESCUENTO        
            arrAcuerdoDet(16) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(16)) + Funciones.CheckDbl(totalSinIGVICCID)) ';//P_SUBTOTAL         
            arrAcuerdoDet(17) = Funciones.CheckStr(Funciones.CheckDbl(arrAcuerdoDet(17)) + Funciones.CheckDbl(totalIGVICCID)) ';//P_IMPUESTO         

            arrAcuerdoDet(4) = strMaterialICCID 'P_ARTICULO
            arrAcuerdoDet(5) = strArticuloICCID 'P_DES_ARTICULO
            arrAcuerdoDet(10) = strSerieChip 'P_SERIE
        End If

        If cadenaDetalle.Length > 0 Then
            cadenaDetalle += "|" + String.Join(";", arrAcuerdoDet)
        Else
            cadenaDetalle = String.Join(";", arrAcuerdoDet)
        End If

        cadenaCodTipoProducto += "|" + codTipoProducto + ";" + nroRecibo

        Return cadenaDetalle
    End Function

    Public Function getCadenaServicios(ByVal nroSec As Int64, ByVal cadenaDetalle As String, ByVal strCadenaServicios As String) As String

        Dim cadenaServicios As String = ""
        Dim arrServAdic(9) As String
        Dim intContDetalle As Integer = 0
        Dim nroSecDet As Int64 = 0
        Dim idxPlan As String = ""
        Dim blnAgregar As Boolean = True
        If Funciones.CheckStr(strCadenaServicios) <> "" Then

            Dim arrServicios As String() = strCadenaServicios.Split(";")
            For i As Integer = 0 To arrServicios.Length - 1
                Dim arrServ As String() = arrServicios(i).Split("_")
                Dim codServicio As String = arrServ(0)
                Dim cargoFijo As String = arrServ(2)
                Dim desServicio As String = arrServ(1)
                Dim idSolPlan As String = ""
                Dim consecutivo As String = "1"
                Dim spcode As String = "", sncode As String = ""

                blnAgregar = True
                If blnAgregar Then

                    arrServAdic(0) = "" '; //P_COD_RESPUESTA
                    arrServAdic(1) = "" '; //P_MSJ_RESPUESTA
                    arrServAdic(2) = "" '; //P_NROACUERDO
                    arrServAdic(3) = consecutivo '; //P_ID_DETALLE
                    arrServAdic(4) = codServicio '; //P_SERVICIO
                    arrServAdic(5) = desServicio '; //P_SERVICIO_DES
                    'PROY-24724-IDEA-28174 - INICIO 
                    If (codServicio = ClsKeyAPP.strCodServProteccionMovil And chkProMovil.Checked) Then
                        cargoFijo = Funciones.CheckStr(hidPrima.Value).Trim()
                    End If
                    'PROY-24724-IDEA-28174 - FIN 
                    arrServAdic(6) = cargoFijo '; //p_cargo_fijo
                    arrServAdic(7) = spcode '; //p_spcode
                    arrServAdic(8) = sncode '; //p_sncode
                    cadenaServicios += "|" + String.Join(";", arrServAdic)
                End If
            Next
        End If
        If cadenaServicios.Length > 0 Then
            cadenaServicios = cadenaServicios.Substring(1)
        End If

        Return cadenaServicios
    End Function

    Private Function ObtenerServ() As String
        Dim cadenServicio As String = String.Empty
        Dim arrPlanServDetalle As ArrayList = ObtenerPlanDetalle()
        Dim arrayServicio As New ArrayList
        For Each plan As PlanDetalleVenta In arrPlanServDetalle
            If Not IsNothing(plan.SERVICIO) Then
                For Each Servicio As SecServicio_AP In plan.SERVICIO
                    If Trim(Servicio.SERVV_CODIGO) <> String.Empty Then
                        If Trim(cadenServicio) <> String.Empty Then
                            cadenServicio = cadenServicio & ";" & Servicio.SERVV_CODIGO & "_" & Servicio.SERVV_DESCRIPCION & "_" & Servicio.CARGO_FIJO_BASE
                        Else
                            cadenServicio = Servicio.SERVV_CODIGO & "_" & Servicio.SERVV_DESCRIPCION & "_" & Servicio.CARGO_FIJO_BASE
                        End If
                    End If
                Next
            End If
        Next
        Return cadenServicio
    End Function

    Public Function getCadenaAcuerdo(ByVal IdVenta As Int64) As String
        Dim oMaestro As New MaestroNegocio
        Dim oUsuario As Usuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
        Dim Cs_Large As String = ""
        Dim Cs_Subcuenta As String = ""
        Dim strCicloFact As String = ""

        Dim strTipoClienteSap As String = hidTipoClienteSAP.Value
        Dim dblFactorLC As Double = hidFactorLC.Value
        Dim cargoFijoTotal As Double = hidCargoFijoNuevo.Value
        Dim cadenaAcuerdo As String = ""
        Dim arrAcuerdo(44) As String
        Dim listaSec As New ArrayList
        Dim oConsultaSolicitud As New SolicitudNegocios

        Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
        Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodCanalSAP As String = CheckStr(hidOficinaActual.Value).Split(",")(3)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        If Not hidPerfil_149.Value = "S" Then
            codigoVendedorSAP = CheckStr(Session("CodVendedorSAP"))
        End If

        Dim tipoDocCliente As String = CheckStr(hidTipoDocumento.Value)

        listaSec = oConsultaSolicitud.ObtenerSolicitudes(hidNroSEC.Value)

        For Each item As SolicitudPersona In listaSec
            'Obtener SEC padre
            If item.SOLIN_CODIGO = item.SOLIN_GRUPO_SEC Then
                oSolicitud = CType(item, SolicitudPersona)
            End If
        Next

        'POLAR
        Dim tipoCliente As String = oSolicitud.TPROC_CODIGO
        ' Convertir el tipoCliente de PVU a su equivalente de SAP
        If tipoCliente = "01" Then 'Sisact: 01 = Consumer - SAP: 02 = Consumer
            tipoCliente = "02"
        ElseIf tipoCliente = "02" Then 'Sisact: 02 = Bussiness - SAP: 01 = Bussiness
            tipoCliente = "01"
        ElseIf tipoCliente = "06" Then 'Sisact: 06 = B2E - SAP: 05 = B2E
            tipoCliente = "05"
        End If

        arrAcuerdo(0) = "" 'P_NROACUERDO        
        arrAcuerdo(1) = "" 'P_MSJ_RESPUESTA     
        arrAcuerdo(2) = ConfigurationSettings.AppSettings("constCodTipoVentaPostpago") 'P_TIPO_VENTA        
        arrAcuerdo(3) = ConfigurationSettings.AppSettings("constCodOperRenovacionPVU")  'P_TIPO_OPERACION    
        arrAcuerdo(4) = oSolicitud.PRDC_CODIGO 'P_TIPO_PRODUCTO     
        arrAcuerdo(5) = strCodOficina 'P_OFICINA_VENTAS    
        arrAcuerdo(6) = "" 'strPrefijo 'P_NUMERO_PCS        
        arrAcuerdo(7) = oSolicitud.PACUC_CODIGO 'P_PLAZO_ACUERDO     
        arrAcuerdo(8) = oSolicitud.CLIEV_NOMBRE 'P_FACT_NOMBRE       
        arrAcuerdo(9) = oSolicitud.CLIEV_APE_PAT 'P_FACT_APE_PAT      
        arrAcuerdo(10) = oSolicitud.CLIEV_APE_MAT 'P_FACT_APE_MAT      
        arrAcuerdo(11) = oSolicitud.CLIEV_RAZ_SOC 'P_FACT_R_SOCIAL     
        arrAcuerdo(12) = Funciones.CheckStr(oSolicitud.SOLIN_CODIGO) 'P_CODIGO_APROBACION 
        arrAcuerdo(13) = ConfigurationSettings.AppSettings("constDesResultadoFinalAPR") 'P_RESULTADO
        arrAcuerdo(14) = CheckStr(Session("CodVendedorSAP")) 'P_VENDEDOR          
        arrAcuerdo(15) = CurrentUser 'P_USUARIO           
        arrAcuerdo(16) = oUsuario.NombreCompleto
        arrAcuerdo(17) = Funciones.CheckStr(IdVenta) 'P_DOCUMENTO         
        arrAcuerdo(18) = ObtenerTipoDocumentoVenta(oSolicitud.TDOCC_CODIGO) 'P_TIPO_DOCUMENTO    
        arrAcuerdo(19) = ConfigurationSettings.AppSettings("ExpressAnalistaCredito") 'P_ANALISTA_CREDITO  
        arrAcuerdo(20) = "" 'P_MIGRACION         
        arrAcuerdo(21) = ConfigurationSettings.AppSettings("constEstadoInicialAcuerdoSap") 'P_ESTADO            
        arrAcuerdo(22) = "" 'P_COD_OBSERVACION   
        arrAcuerdo(23) = "" 'P_OBSERVACIONES     
        arrAcuerdo(24) = oSolicitud.TDOCC_CODIGO 'P_TIPO_DOC_CLIENTE  
        arrAcuerdo(25) = oSolicitud.CLIEC_NUM_DOC 'P_CLIENTE           
        arrAcuerdo(26) = "S" 'P_RENOVACION        
        arrAcuerdo(27) = ConfigurationSettings.AppSettings("ExpressCodAprobador") 'P_APROBADOR         
        arrAcuerdo(28) = Funciones.CheckStr(Funciones.CheckDbl(Math.Round(dblFactorLC * cargoFijoTotal, 2))) 'P_LIM_CREDITO       
        arrAcuerdo(29) = oSolicitud.SOLIC_SCO_TXT_CON 'P_SCORE_CREDITICIO  
        arrAcuerdo(30) = Funciones.CheckStr(oSolicitud.SOLIN_SCO_NUM_CON) 'P_CONTROL_FRAUDE    
        arrAcuerdo(31) = Cs_Large 'P_CS_LARGE          
        arrAcuerdo(32) = Cs_Subcuenta 'P_CS_SUBCUENTA      
        arrAcuerdo(33) = Funciones.CheckStr(cargoFijoTotal) 'P_SUM_PLANES_VENDI  
        arrAcuerdo(34) = "1" 'P_RESPONS_PAGO      
        arrAcuerdo(35) = "0" 'P_EXISTE_BSCS       
        arrAcuerdo(36) = "" 'P_ACTIVACION_LINEA  
        arrAcuerdo(37) = "" 'strFlagPrefijoManual 'P_ACUERDO_MANUAL    
        'arrAcuerdo(38) = oSolicitud.TPROC_CODIGO 'P_TIPO_CLI_ACT      
        arrAcuerdo(38) = tipoCliente
        arrAcuerdo(39) = "" 'P_MOTIVO_MIG        
        arrAcuerdo(40) = "" 'P_MOTIVO_REPOS
        arrAcuerdo(41) = strCodCanalSAP 'P_CANAL
        arrAcuerdo(42) = oUsuario.NombreCompleto 'P_USUARIO_NOMBRE 
        arrAcuerdo(43) = strCicloFact 'p_ciclo_fact 

        cadenaAcuerdo = String.Join(";", arrAcuerdo)

        Return cadenaAcuerdo
    End Function

    Public Function getCadenaDetalleEquipo() As String

        'string[] arrPlanes = strCadenaPlanes.Split('|');
        Dim arrAcuerdoEquipo(17) As String
        Dim cadenaDetalle As String = ""
        Dim intContDetalle As Integer = 0

        Dim strMaterialImei As String
        Dim strArticuloImei As String
        Dim strImei As String

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            strMaterialImei = CheckStr(txtCodEquipo.Text)
            strArticuloImei = CheckStr(hidNombredelEquipoCAC.Value)
            strImei = CheckStr(hidIMEI.Value)
        Else
            strMaterialImei = CheckStr(txtMaterialImei.Text)
            strArticuloImei = CheckStr(txtArticuloImei.Text)
            strImei = CheckStr(txtImei.Text)
        End If

        Dim precios As String = CheckStr(hidDatosEquipo.Value)
        Dim descuento As String = precios.Split(","c)(0)
        Dim totalSinIGV As String = precios.Split(","c)(3)
        Dim totalConIGV As String = precios.Split(","c)(1)
        Dim precioLista As String = precios.Split(","c)(2)
        Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        Dim campania As String = CheckStr(hidCampaniaSelected.Value)
        Dim codCampania As String = campania.Split(","c)(0)
        Dim desCampania As String = campania.Split(","c)(1)
        Dim Nro_Cuotas As String = hidCuota.Value

        intContDetalle += 1

        arrAcuerdoEquipo(0) = ""
        arrAcuerdoEquipo(1) = ""
        arrAcuerdoEquipo(2) = "" 'P_ID_CONTRATO
        arrAcuerdoEquipo(3) = "1" 'P_ID_DETALLE
        arrAcuerdoEquipo(4) = strMaterialImei 'P_COD_EQUIPO
        arrAcuerdoEquipo(5) = strArticuloImei 'P_DES_EQUIPO
        arrAcuerdoEquipo(6) = strImei 'P_SERIE_EQUIPO
        arrAcuerdoEquipo(7) = codCampania 'P_CAMPANA
        arrAcuerdoEquipo(8) = desCampania 'P_CAMPANA_DESC
        arrAcuerdoEquipo(9) = codLisPrecio 'P_UTILIZACION
        arrAcuerdoEquipo(10) = desLisPrecio 'P_DES_UTILIZACION
        arrAcuerdoEquipo(11) = precioLista 'P_PRECIO_LISTA
        arrAcuerdoEquipo(12) = totalConIGV 'P_PRECIO_VENTA
        arrAcuerdoEquipo(13) = descuento 'P_DESCUENTO
        arrAcuerdoEquipo(14) = totalIGV 'P_IMPUESTO
        arrAcuerdoEquipo(15) = Nro_Cuotas 'arrPlanDetalle(12).Split("#")(0) 'P_CUOTA
        arrAcuerdoEquipo(16) = "" 'arrPlanDetalle(12).Split("#")(1) 'P_DES_CUOTA

        If (cadenaDetalle.Length > 0) Then
            cadenaDetalle += "|" + String.Join(";", arrAcuerdoEquipo)

        Else
            cadenaDetalle = String.Join(";", arrAcuerdoEquipo)
        End If

        Return cadenaDetalle
    End Function

    Private Function RegistrarGarantiaSisact(ByVal nroAcuerdoSisact As Int64, ByVal tipoGarantiaSisact As String, ByVal nroDepositoSap As String, ByVal cadenaDeposito As String, ByRef nroDepositoSisact As String) As Boolean
        'Dim oMaestro As New MaestroNegocio
        'Dim oVenta As New VentaExpressNegocios
        'Dim oUsuario As New Usuario
        'Dim nroRecibo As String
        'oUsuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
        'Dim blnOk As Boolean = False
        'Dim arrDepositoSap As String() = cadenaDeposito.Split(";")
        'Dim arrDepositoSisact(14) As String
        'arrDepositoSisact(0) = ""
        'arrDepositoSisact(1) = ""
        'arrDepositoSisact(2) = ""
        'arrDepositoSisact(3) = Funciones.CheckStr(nroAcuerdoSisact)
        'arrDepositoSisact(4) = nroRecibo
        'arrDepositoSisact(5) = arrDepositoSap(1)
        'arrDepositoSisact(6) = arrDepositoSap(2)
        'arrDepositoSisact(7) = arrDepositoSap(9)
        'arrDepositoSisact(8) = arrDepositoSap(10)
        'arrDepositoSisact(9) = CurrentUser
        'arrDepositoSisact(10) = arrDepositoSap(19)
        'arrDepositoSisact(11) = tipoGarantiaSisact
        'arrDepositoSisact(12) = arrDepositoSap(18)
        'arrDepositoSisact(13) = nroDepositoSap

        'cadenaDeposito = String.Join(";", arrDepositoSisact)


        'oVenta.GrabarGarantia(cadenaDeposito, nroDepositoSisact)


        'If Funciones.CheckInt64(nroDepositoSisact) > 0 Then
        '    blnOk = True
        'End If
        'dblMontoGarantia = Funciones.CheckDbl(arrDepositoSisact(7))


        Dim oMaestro As New MaestroNegocio
        Dim oVenta As New VentaExpressNegocios
        Dim oUsuario As New Usuario
        Dim nroRecibo As String = "1"
        oUsuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
        Dim blnOk As Boolean = False
        Dim arrDepositoSap As String() = cadenaDeposito.Split(";"c)
        Dim arrDepositoSisact(14) As String
        Dim tipoGarantiaSAP As String

        If tipoGarantiaSisact = "1" Then ' Deposito en Garantia
            tipoGarantiaSAP = "DE"
        ElseIf tipoGarantiaSisact = "2" Then  ' Renta Adelantada
            tipoGarantiaSAP = "DL"
        ElseIf tipoGarantiaSisact = "3" Then  ' Pago Adelantado
            tipoGarantiaSAP = "DX"
        End If

        arrDepositoSisact(0) = ""
        arrDepositoSisact(1) = ""
        arrDepositoSisact(2) = ""
        arrDepositoSisact(3) = Funciones.CheckStr(nroAcuerdoSisact)
        arrDepositoSisact(4) = nroRecibo
        arrDepositoSisact(5) = CheckStr(hidTipoDocumento.Value)
        arrDepositoSisact(6) = Funciones.CheckStr(hidNroDocumento.Value) 'hidNumeroDocumento.Value
        arrDepositoSisact(7) = arrDepositoSap(7)
        arrDepositoSisact(8) = hidOfVentaCod.Value
        arrDepositoSisact(9) = CurrentUser
        arrDepositoSisact(10) = "1"
        arrDepositoSisact(11) = tipoGarantiaSisact
        arrDepositoSisact(12) = tipoGarantiaSAP
        arrDepositoSisact(13) = nroDepositoSap

        cadenaDeposito = String.Join(";", arrDepositoSisact)


        oVenta.GrabarGarantia(cadenaDeposito, nroDepositoSisact)


        If Funciones.CheckInt64(nroDepositoSisact) > 0 Then
            blnOk = True
        End If
        'dblMontoGarantia = Funciones.CheckDbl(arrDepositoSisact(7))
        Return blnOk
    End Function

    Private Sub GrabarCuotas(ByVal NroContrato As String, ByVal factura As String, ByVal Linea As String, ByVal nroPedido As String) 'SD_644347 - CUOTAS - INICIO
        Dim strMaterialImei As String
        Dim strImei As String
        Dim item As New Cuota
        Dim flag As Boolean
        Dim msgError As String
        Dim objVentExpreNegocio As New VentaExpressNegocios
        Dim objConsultaMSSAP As New BLConsultaMssap
        Dim fecha As Date = CheckDate(Format(Date.Now, "dd/MM/yyyyy"))
        Dim nombres As String = hidNombre.Value & " " & hidApePaterno.Value & " " & hidApeMaterno.Value
        Dim arrPlanDetalle As PlanDetalleVenta = Session("PlanDetalle")
        Dim IdSolPlan As Int64 = 0
        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        Dim dblMonto As Double = 0
        'INC000001019296-INICIO
        Dim flgRpta As Boolean
        Dim flag2 As Boolean

        If strCodCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            strMaterialImei = CheckStr(txtCodEquipo.Text)
            strImei = CheckStr(hidIMEI.Value)
        Else
            strMaterialImei = CheckStr(txtMaterialImei.Text)
            strImei = CheckStr(txtImei.Text)
        End If
        Dim strNroError, strDesError As String
        Try
            IdSolPlan = arrPlanDetalle.SOPLN_CODIGO

            'INC000001019296-INICIO
            oLog.Log_WriteLog(strArchivo, nroPedido & " -  Inicio Grabar Cuotas - [SolPlan]:" & IdSolPlan & ", [TipoDocumento]:" & hidTipoDocumento.Value)
            If hidTipoDocumento.Value = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Then
                nombres = hidRazonSocial.Value
            End If

            oLog.Log_WriteLog(strArchivo, nroPedido & " -  ConsultaDetallePrecio - " & " nroPedido: " & nroPedido & ", strImei: " & strImei)
            dblMonto = objConsultaMSSAP.ConsultaDetallePrecio(nroPedido, strImei, strNroError, strDesError)
            oLog.Log_WriteLog(strArchivo, nroPedido & " -  ConsultaDetallePrecio Result - dblMonto:" & Funciones.CheckStr(dblMonto))

            'INC000001019296-INICIO
            If (strNroError = "-1") Then
                oLog.Log_WriteLog(strArchivo, nroPedido & " Error en GrabarCuotas - Consulta Detalle de Precio")
                Throw New Exception("Error en Grabar Cuotas")
            End If

            With item
                .nroContrato = NroContrato
                .nroCuota = CheckInt(CheckStr(hidCuota.Value))
                .monto = dblMonto
                .usuario = CurrentUser
                'polar
                .fechEmision = CheckDate(Me.ObtenerFechaEmision())
                .nroSap = nroPedido
                .telefono = Linea
                .CUOV_NRO_CONTRATO = Funciones.CheckStr(NroContrato)
                .CUON_NRO_CUOTA = CheckInt(CheckStr(hidCuota.Value))
                .CUON_MONTO = dblMonto
                .CUOV_USUARIO_REG = CurrentUser
                .CUOD_FECHA_EMISION = CheckDate(ObtenerFechaEmision())
                .CUOV_NRO_DOC_SAP = nroPedido
                .CUOV_NRO_CELULAR = hidNroLinea.Value
                ''* LCA Nueva Linea
                .CUOV_MATE = strMaterialImei
                .CUOV_IMEI = strImei
                .CUOV_NOM_CLIENTE = nombres  ''objDeta.K_NOMCLIENTE
                .CUOV_NRO_DOC_CLIENTE = Funciones.CheckStr(hidNroDocumento.Value()) '''objDeta.K_NRODOCCLIENTE
                .OFICINA = strCodOficina
                .FLAG_ENVIO = "0"
                .CUENTA_BSCS = hidCuentaBSCS.Value
                .CUSTOMER_ID = hidCustumerId.Value
                .CONTRATO_SISACT = Funciones.CheckStr(NroContrato)
            End With
            oLog.Log_WriteLog(strArchivo, nroPedido & " -  Actualizar Plan Venta - IdSolPlan: " & Funciones.CheckStr(IdSolPlan) & ", Linea: " & Funciones.CheckStr(Linea) & _
            ", strMaterialImei: " & Funciones.CheckStr(strMaterialImei) & ", dblMonto:" & Funciones.CheckStr(dblMonto))

            flgRpta = objVentExpreNegocio.ActualizarPlanVenta(IdSolPlan, Linea, strMaterialImei, dblMonto)

            oLog.Log_WriteLog(strArchivo, nroPedido & " -  Actualizar Plan Venta - flgRpta: " & Funciones.CheckStr(flgRpta))

            'INC000001019296-INICIO
            'If (flgRpta = False) Then
            '    oLog.Log_WriteLog(strArchivo, nroPedido & " - Error al GrabarCuotas en SISACT_SOLICITUD_PLAN_VENTA del Contrato: " & NroContrato)
            '    Throw New Exception("Error en Grabar Cuotas")
            'End If

            oLog.Log_WriteLog(strArchivo, nroPedido & " - InsertaCuotas - Nro Cuota: " & Funciones.CheckStr(item.CUON_NRO_CUOTA) & ", dblMonto:" & Funciones.CheckStr(item.CUON_MONTO))
            flag = objVentExpreNegocio.insertaCuotas(item)

            'INC000001019296-INICIO
            If (flag = False) Then
                oLog.Log_WriteLog(strArchivo, nroPedido & " - Error al GrabarCuotas en SISACT_PAGO_CUOTAS del Contrato: " & NroContrato)
                Throw New Exception("Error en Grabar Cuotas")
            End If

            oLog.Log_WriteLog(strArchivo, nroPedido & " - GrabarCuotas - Nro Cuota: " & Funciones.CheckStr(item.CUON_NRO_CUOTA) & ", dblMonto:" & Funciones.CheckStr(item.CUON_MONTO))
            flag2 = objVentExpreNegocio.GrabarCuotas(item)

            'INC000001019296-INICIO
            If (flag2 = False) Then
                oLog.Log_WriteLog(strArchivo, nroPedido & " - Error al GrabarCuotas en SISACT_CVE del Contrato:" & NroContrato)
                Throw New Exception("Error en Grabar Cuotas")
            End If

        Catch ex As Exception
            msgError = ex.Message
            oLog.Log_WriteLog(strArchivo, nroPedido & msgError)
            Throw New Exception(ex.Message) 'INC000001102169-INICIO
        Finally
            item = Nothing
            oLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & " Inicio grabar cuotas: " & msgError)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Inicio Grabar Cuotas", False)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Input  : " & Linea, False)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Input  : " & dblMonto, False)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Input  : " & CheckStr(fecha), False)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Output : " & msgError, False)
            HelperLog.EscribirLog("", strArchivo, Now() & " -" & NroContrato & "- " & "Fin Grabar Cuotas", False)
        End Try
    End Sub 'SD_644347 - CUOTAS - FIN

#Region "Pedido MSSAP"
    Private Function GenerarCadenaCabeceraMSS() As String
        Dim oConsultarSap As New SapGeneralNegocios
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim ccliente As New BECliente
        Dim tipoDocCliente As String = hidTipoDocumento.Value
        Dim nroDocCliente As String = hidNroDocumento.Value

      
        Session("aux_nroDocumento") = hidNroDocumento.Value       
	oLog.Log_WriteLog(strArchivo, hidTipoDocumento.Value & "- " & "aux_nroDocumento: " & Funciones.CheckStr(Session("aux_nroDocumento")))

        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim tipoCliente As String = hidTipoCliente.Value
        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacionLP") 'hidTipoOperacion.Value
        Dim tipoDocVenta As String = ""

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)

        'ini sinergia 31072015
        Dim vendedorSAP As String = CheckStr(hidVendedorSAP.Value)
        Dim codigoVendedorSAP As String = vendedorSAP.Split(";"c)(0)

        Dim strSector As String = String.Empty
        strSector = ConfigurationSettings.AppSettings("constSINERGIASectorPostpagoEquipoChip")
        'fin sinergia 31072015

        Dim precios As String = CheckStr(hidDatosEquipo.Value)

        'ini sinergia 31072015
        If (tipoDocCliente = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC")) Then
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaRUC")
            'tipoDocVenta = arrayTipoDocVenta(1)
            Else
            tipoDocVenta = ConfigurationSettings.AppSettings("TipoDocVentaNORUC")
            'tipoDocVenta = arrayTipoDocVenta(2)
            End If

        Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")
        'ini sinergia 31072015


        'Crear Cliente en PVUDB
        CrearClientePVU(nroDocCliente, tipoDocCliente, oSolicitud)


        'ini sinergia 05082015

        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(strCodOficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(strCodOficina, "")
        Dim canal As String
        Dim orgVenta, sector, strCentro As String
        canal = CheckStr(ConfigurationSettings.AppSettings("ConsCanalMSSAP")) 'oParPVU.canal
        orgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia"))
        strCentro = oParPVU.codigoCentro
        sector = strSector.PadLeft(2, CChar("0"))

        Dim ClaseFactura As String = ConfigurationSettings.AppSettings("ConsCodigoBoleta"), DescripcionFactura As String = ConfigurationSettings.AppSettings("ConsDescripcionBoleta")

        For Each item As String In ConfigurationSettings.AppSettings("ConsTipoDNIFactura").Split(CChar(";"))
            If tipoDocCliente = Funciones.CheckStr(item) Then
                ClaseFactura = ConfigurationSettings.AppSettings("ConsCodigoFactura")
                DescripcionFactura = ConfigurationSettings.AppSettings("ConsDescripcionFactura")
                Exit For
        End If
        Next
        'fin sinergia 05082015

        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
        Dim totalSinIGV As String = precios.Split(","c)(3)
        Dim totalConIGV As String = precios.Split(","c)(1)
        Dim totalIGV As String = CStr(CheckDecimal(totalConIGV) - CheckDecimal(totalSinIGV))
        Dim DesTipoOperacion As String = ""
        ' CABECERA
        'INICIO - SINERGIA_MSSAP

        If hidValidarIccid.Value.Equals("1") Then
            DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacionpack")
        Else
            DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion")
        End If
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")

        'Cadena Documento
        Dim arrayCabecera(52) As String

        arrayCabecera(0) = oParPVU.cPuntoVentaSinergia ' ""  '""                                    'Documento
        arrayCabecera(1) = "" 'oPar.CodigoInterlocutor ' 'tipoDocVenta                          'Tipo_Documento
        arrayCabecera(2) = ConfigurationSettings.AppSettings("constSINERGIAClaseDocumentoRenta") 'oficina                               'Oficina_Venta
        arrayCabecera(3) = orgVenta 'Now.ToString("dd/MM/yyyy")           'String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
        arrayCabecera(4) = canal 'tipoDocCliente                        'Tipo_Doc_Cliente
        arrayCabecera(5) = sector 'nroDocCliente                         'Cliente
        arrayCabecera(6) = ConfigurationSettings.AppSettings("ConsTipoVentasPostpago")
        arrayCabecera(7) = Now.ToString()  'moneda                                'Moneda
        arrayCabecera(8) = ConfigurationSettings.AppSettings("ConsMotivoPedidoPortabilidad")
        arrayCabecera(9) = ClaseFactura  'totalSinIGV                           'Total_Mercaderia
        arrayCabecera(10) = DescripcionFactura 'totalIGV                             'Total_Impuesto
        arrayCabecera(11) = "" 'totalConIGV                          'Total_Documento
        arrayCabecera(12) = ConfigurationSettings.AppSettings("constSINERGIAClasePedidoFacturas") '""                                  'Fecha registro
        arrayCabecera(13) = tipoOperacion
        arrayCabecera(14) = DesTipoOperacion 'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
        arrayCabecera(15) = Now.ToString()  'CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
        arrayCabecera(16) = ConfigurationSettings.AppSettings("constAplicacion") ' tipoVenta                            'Tipo_Venta
        arrayCabecera(17) = CheckStr(Session("CodVendedorSAP")) 'codigoVendedorSAP '""
        arrayCabecera(18) = ConfigurationSettings.AppSettings("ConsDocPrepagoPendientes")
        arrayCabecera(19) = "N"
        arrayCabecera(20) = "0"
        arrayCabecera(21) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad")
        arrayCabecera(22) = ConfigurationSettings.AppSettings("constSINERGIAEsquemaVentaAlta")                                 'Fecha Vta Or
        arrayCabecera(23) = tipoDocCliente
        arrayCabecera(24) = nroDocCliente                            'nro_cuota
        arrayCabecera(25) = Funciones.CheckStr(hidTipoCliente.Value) 'CheckStr(Session("CodVendedorSAP"))  'nro clarify
        arrayCabecera(26) = oSolicitud.CLIEV_NOMBRE
        arrayCabecera(27) = oSolicitud.CLIEV_APE_PAT                   'Vendedor
        arrayCabecera(28) = oSolicitud.CLIEV_APE_MAT
        arrayCabecera(29) = ConfigurationSettings.AppSettings("ConsDefaultFechaNacimiento")                     'Renovacion
        arrayCabecera(30) = oSolicitud.CLIEV_RAZ_SOC                          'Descripción Renovacion
        arrayCabecera(31) = oSolicitud.SOLIV_CORREO
        arrayCabecera(32) = ConfigurationSettings.AppSettings("ConsSinInformacion")
        arrayCabecera(33) = oSolicitud.ESTADO_CIVIL_ID
        arrayCabecera(34) = ConfigurationSettings.AppSettings("ConsSinInformacion")
        arrayCabecera(35) = "0"
        arrayCabecera(36) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(5, 4)  'Nro hdc
        arrayCabecera(37) = ConfigurationSettings.AppSettings("UbigeoDefaultPedidoPortabilidad").Substring(0, 2)
        arrayCabecera(38) = ConfigurationSettings.AppSettings("ConsPais")
        arrayCabecera(39) = tipoDocCliente
        arrayCabecera(40) = nroDocCliente
        arrayCabecera(41) = ""
        arrayCabecera(42) = ""
        arrayCabecera(43) = ""
        arrayCabecera(44) = ConfigurationSettings.AppSettings("constCodTipoCAC")
        arrayCabecera(45) = ""                                  'Tipo_Prod_Operad (01 Postpago; 02 Prepago)
        arrayCabecera(46) = CurrentUser
        arrayCabecera(47) = Now.ToString()
        arrayCabecera(48) = CurrentUser                             'Orgvnt
        arrayCabecera(49) = Now.ToString()                                'Canal
        arrayCabecera(50) = ""
        arrayCabecera(51) = "0"
        'FIN - SINERGIA_MSSAP
        oConsultarSap = Nothing

        GenerarCadenaCabeceraMSS = Join(arrayCabecera, ";")

        'PROY-24724-IDEA-28174 - INICIO 
        strGenerarCadenaCabeceraMSSPM = GenerarCadenaCabeceraMSS
        'PROY-24724-IDEA-28174 - FIN 
    End Function

    Private Function GenerarCadenaDetalleMSS(ByRef montoTotal As Double) As String
        Dim cadenaDetalle As String = ""
        Dim nomiccid As String
        Dim nomimei As String
        Dim arrayDetalle(28) As String
        Dim mensajeCrear As String
        Dim contadorEquipos As Integer = 0
        Dim arrPlanDetalle As ArrayList = ObtenerPlanDetalle()
        Dim cargoFijoTotal As Double = ConsultarCFTotal(arrPlanDetalle)
        Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
        Dim cantidad As Integer = 1
        Dim codigoPlan As String = planTarifa.Split(","c)(1)
        Dim descPlan As String = planTarifa.Split(","c)(2)
        Dim strMaterialImei As String = CheckStr(txtCodEquipo.Text)
        Dim strArticuloImei As String = CheckStr(hidNombredelEquipoCAC.Value)  'ddlCodEquipo.SelectedItem.Text
        Dim strImei As String = CheckStr(hidIMEI.Value)
        Dim strMaterialICCID As String = CheckStr(txtCodChip.Text)
        Dim strArticuloICCID As String = CheckStr(hidNombredelChipCAC.Value)
        Dim strSerieChip As String = CheckStr(hidIccid.Value)
        Dim listaPrecioChip, codLisPrecioChip, desLisPrecioChip As String
        Dim campania As String = CheckStr(hidCampaniaSelected.Value)
        Dim codCampania As String = campania.Split(","c)(0)
        Dim desCampania As String = campania.Split(","c)(1)
        Dim preciosICCID As String
        Dim descuentoICCID As String = String.Empty
        Dim totalSinIGVICCID As String = String.Empty
        Dim totalConIGVICCID As String = String.Empty
        Dim precioListaICCID As String = String.Empty
        Dim totalIGVICCID As String = String.Empty
        Dim strTelefono As String = CheckStr(hidNroLinea.Value)
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        Dim precios As String = CheckStr(hidDatosEquipo.Value)
        Dim descuento As String = precios.Split(","c)(0)
        Dim totalSinIGV As String = precios.Split(","c)(3)
        Dim totalConIGV As String = precios.Split(","c)(1)
        Dim precioLista As String = precios.Split(","c)(2)

        Dim strCodCanal As String = CheckStr(hidOficinaActual.Value).Split(",")(2)
        Dim strCodOficina As String = CheckStr(hidOficinaActual.Value).Split(",")(0)
        'INICIO - SINERGIA_MSSAP
        ' Iccid

        'ini sinergia 03082015
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(Funciones.CheckStr(strCodOficina))
        Dim NroCuotas As String = hidCuota.Value


        'fin sinergia 03082015

        If hidValidarIccid.Value.Equals("1") Then
            listaPrecioChip = CheckStr(hidPLSelected.Value)
            codLisPrecioChip = listaPrecioChip.Split(","c)(0)
            desLisPrecioChip = listaPrecioChip.Split(","c)(1)
            preciosICCID = CheckStr(hidDatosChip.Value)
            descuentoICCID = preciosICCID.Split(","c)(0)
            totalSinIGVICCID = preciosICCID.Split(","c)(3)
            totalConIGVICCID = preciosICCID.Split(","c)(1)
            precioListaICCID = preciosICCID.Split(","c)(2)
            totalIGVICCID = CheckStr(CheckDbl(totalConIGVICCID) - CheckDbl(totalSinIGVICCID))

            arrayDetalle(0) = ""                            'Documento
            arrayDetalle(1) = oPar.CodigoInterlocutor 'Format(contadorDetalle, "000000")              'Consecutivo (codigo 6 digitos)
            arrayDetalle(2) = ""  '"" 'CheckStr(strMaterialImei) 'CheckStr(txtMaterialImei.Text) 'Articulo
            arrayDetalle(3) = CheckStr(strSerieChip)  'CheckStr(strArticuloImei) 'CheckStr(txtArticuloImei.Text) 'Des_Articulo
            arrayDetalle(4) = CheckStr(strMaterialICCID)  'codLisPrecio                  'Utilizacion
            arrayDetalle(5) = CheckStr(strArticuloICCID)   'desLisPrecio                  'Des_Utilizacion
            arrayDetalle(6) = CheckStr(cantidad) 'codCampania
            arrayDetalle(7) = totalSinIGVICCID 'totalConIGV  'desCampania
            arrayDetalle(8) = CheckStr(hidNroLinea.Value) 'CheckStr(strImei) 'CheckStr(txtImei.Text)        'Serie
            arrayDetalle(9) = "0" 'CheckStr(cantidad)            'Cantidad
            arrayDetalle(10) = "0" 'precioLista                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
            arrayDetalle(11) = "0" 'totalSinIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
            arrayDetalle(12) = NroCuotas 'descuento                    'Descuento
            arrayDetalle(13) = codLisPrecioChip '""                           'Porc_Descuento
            arrayDetalle(14) = desLisPrecioChip '""                           'Descuento_Adic
            arrayDetalle(15) = CurrentUser 'totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
            arrayDetalle(16) = DateTime.Now.ToString() 'totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
            arrayDetalle(17) = CurrentUser '""                           'Impuesto2
            arrayDetalle(18) = DateTime.Now.ToString() 'codPlan                      'Plan_Tarifario
            arrayDetalle(19) = "" 'desPlan     


            If cadenaDetalle.Length > 0 Then
                cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
            Else
                cadenaDetalle = Join(arrayDetalle, ";")
            End If
            montoTotal += totalConIGVICCID
        End If
        ' Imei
        'Cadena Detalle IMEI
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = oPar.CodigoInterlocutor 'Format(contadorDetalle, "000000")              'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = ""  '"" 'CheckStr(strMaterialImei) 'CheckStr(txtMaterialImei.Text) 'Articulo
        arrayDetalle(3) = CheckStr(strImei)  'CheckStr(strArticuloImei) 'CheckStr(txtArticuloImei.Text) 'Des_Articulo
        arrayDetalle(4) = CheckStr(strMaterialImei)  'codLisPrecio                  'Utilizacion
        arrayDetalle(5) = CheckStr(strArticuloImei)   'desLisPrecio                  'Des_Utilizacion
        arrayDetalle(6) = CheckStr(cantidad) 'codCampania
        arrayDetalle(7) = totalSinIGV 'totalConIGV  'desCampania
        arrayDetalle(8) = CheckStr(hidNroLinea.Value) 'CheckStr(strImei) 'CheckStr(txtImei.Text)        'Serie
        arrayDetalle(9) = "0" 'CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = "0" 'precioLista                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = "0" 'totalSinIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = NroCuotas 'descuento                    'Descuento
        arrayDetalle(13) = codLisPrecio '""                           'Porc_Descuento
        arrayDetalle(14) = desLisPrecio '""                           'Descuento_Adic
        arrayDetalle(15) = CurrentUser 'totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = DateTime.Now.ToString() 'totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = CurrentUser '""                           'Impuesto2
        arrayDetalle(18) = DateTime.Now.ToString() 'codPlan                      'Plan_Tarifario
        arrayDetalle(19) = "" 'desPlan     
        If cadenaDetalle.Length > 0 Then
            cadenaDetalle = cadenaDetalle & "|" & Join(arrayDetalle, ";")
        Else
            cadenaDetalle = Join(arrayDetalle, ";")
        End If

        ' Ordenar el array de Detalle segun el parametro "consecutivo"
        Dim sortCadena() As String = cadenaDetalle.Split("|"c)
        Dim unsortCadena() As String = cadenaDetalle.Split("|"c)
        'For Each cadenaTmp As String In unsortCadena
        '    Dim idx As Integer = CheckInt(cadenaTmp.Split(";"c)(1)) - 1
        '    sortCadena(idx) = cadenaTmp
        'Next
        'FIN - SINERGIA_MSSAP
        montoTotal += totalConIGV
        GenerarCadenaDetalleMSS = Join(sortCadena, "|"c)

        'PROY-24724-IDEA-28174 - INICIO 
        strGenerarCadenaDetalleMSSPM = GenerarCadenaDetalleMSS
        'PROY-24724-IDEA-28174 - FIN 
    End Function

    Private Function GenerarCadenaDepositoMSS(ByVal cadenaCabecera As String, ByVal nroContrato As String, ByVal nroPedido As String, ByVal nroSec As String, ByRef dblMontoDeposito As Double, ByRef sTipoDeposito As String, ByRef tipoGarantia As String) As String
        Dim oficina As String = hidOfVentaCod.Value
        Dim tipoDeposito As String = CheckStr(hidcodGarantia.Value)
        Dim montoDeposito As Double = CheckDbl(hidImporteRenta.Value)  'cambiar a produccion
        Dim montoDepositoSinIGV As Double = CheckDbl(hidImporteRenta.Value) / 1.18
        Dim tipoGarantiaSAP As String = ""

        'ini sinergia 06082015
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        oPar = oConsultaMSSAP.ParametrosOficina(oficina)    'ParametrosOficinaVenta(oficina)
        Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(oficina, "")
        Dim listaPrecio As String = CheckStr(hidlistaPrecioSelected.Value)
        Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
        Dim desLisPrecio As String = listaPrecio.Split(","c)(1)
        'fin sinergia 06082015

        'Código cpd
        codCorporativo = oParPVU.CodigoCpdCorporativo
        codMasivo = oParPVU.CodigoCpdMasivo

        If tipoDeposito = "" Or tipoDeposito = "0" Or montoDeposito <= 0 Then
            GenerarCadenaDepositoMSS = ""
            Exit Function
        End If

        If tipoDeposito = "1" Then ' Deposito en Garantia
            tipoGarantiaSAP = "DE"
        ElseIf tipoDeposito = "2" Then  ' Renta Adelantada
            tipoGarantiaSAP = "DL"
        ElseIf tipoDeposito = "3" Then  ' Pago Adelantado
            tipoGarantiaSAP = "DX"
        End If

        tipoGarantia = tipoGarantiaSAP

        Dim strMaterialImei As String = CheckStr(txtCodEquipo.Text)
        Dim strArticuloImei As String = CheckStr(hidNombredelEquipoCAC.Value)
        Dim cantidad As Integer = 1
        Dim arrDeposito(23) As String

        ' Dim arrCabecera() As String = cadenaCabecera.Split(";"c)
        arrDeposito(0) = ""  'arrCabecera(4) 'tipo cliente
        arrDeposito(1) = oPar.CodigoInterlocutor
        arrDeposito(2) = "" 'oPar.CodigoInterlocutor  'nro de doc del cliente
        arrDeposito(3) = ""  'fecha actual
        arrDeposito(4) = strMaterialImei ' fecha actual sumado mas 30 dias
        arrDeposito(5) = strArticuloImei
        arrDeposito(6) = Funciones.CheckStr(cantidad)
        arrDeposito(7) = Funciones.CheckStr(montoDepositoSinIGV)
        arrDeposito(8) = CheckStr(hidNroLinea.Value)
        arrDeposito(9) = "0"   'CheckStr(montoDeposito) modificar produccion
        arrDeposito(10) = "0"
        arrDeposito(11) = ""
        arrDeposito(12) = ""
        arrDeposito(13) = codLisPrecio
        arrDeposito(14) = desLisPrecio
        arrDeposito(15) = CurrentUser
        arrDeposito(16) = DateTime.Now.ToString()
        arrDeposito(17) = CurrentUser
        arrDeposito(18) = DateTime.Now.ToString()
        arrDeposito(19) = ""
        dblMontoDeposito = CheckDbl(hidImporteRenta.Value) 'montoDeposito modificar produccion
        sTipoDeposito = tipoDeposito
        GenerarCadenaDepositoMSS = Join(arrDeposito, ";")
    End Function

#End Region

Function ObtenerFechaEmision() As String
        Dim Ciclo As String
        Dim datfechaEmision As Date
        Dim strfechaEmision As String
        Dim datFechaActiva As Date
        Dim strFechaActiva As String
        Dim idLog As String = CurrentUser
        Dim codResp As String
        Dim strMensaje As String
        Dim obj As New VentaExpressNegocios

        Try
            Ciclo = hidCicloFact.Value

            obj.ObtenerFechaEmision(Ciclo, strfechaEmision, codResp, strMensaje)
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "strfechaEmision: " & strfechaEmision)

            Dim listaParametros As String
            Dim arrayListaParametro As ArrayList = New ConsumerNegocio().ListarParametroConsumer(1)
            For Each oItem As ParametroConsumer In arrayListaParametro
                listaParametros = listaParametros & oItem.PCONI_CODIGO & ";" & CheckStr(oItem.PCONV_VALOR) & "|"
            Next
            Dim dblDiasAdicionales As Double = CheckDbl(getValorParametroGeneral(CheckStr(ConfigurationSettings.AppSettings("codParametroVencimientoCuotas")), listaParametros))
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "dblDiasAdicionales: " & dblDiasAdicionales.ToString())
            If dblDiasAdicionales > 0 Then
                strfechaEmision = (Funciones.CheckDate(strfechaEmision).AddDays(dblDiasAdicionales)).ToShortDateString()
                oLog.Log_WriteLog(strArchivo, idLog & " - " & "strfechaEmision: " & strfechaEmision)
            End If
        Catch ex As Exception
            strfechaEmision = String.Format("{0:dd/MM/yyyy}", Now.AddMonths(1))
            oLog.Log_WriteLog(strArchivo, idLog & " - " & "ERROR ObtenerFechaEmision: " & ex.Message.ToString)
        End Try
        Return strfechaEmision
    End Function
    'PROY-24724-IDEA-28174 - INICIO
    Private Function GrabarPrima(ByRef strPedido)

        Dim strFlagError As String = String.Empty
        strPedido = "SC"
        Try
            strFlagError = "0"

            Dim oBWGestionaProteccionMovil As New BWGestionaProteccionMovil
            Dim BLProteccionMovil As New BLProteccionMovil
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " >>>>>>>>>>>> INICIO GrabarPrima <<<<<<<<<<<< ")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "hidCadenaDetalle: --> " & (hidCadenaDetalle.Value).ToString())

            Dim arrCadDetalle() As String = hidCadenaDetalle.Value.Split(CChar("|"))
            Dim arrCadEval() As String = arrCadDetalle(0).Split(";")
            Dim oBEItemMensaje As New BEItemMensaje
            Dim arrPlanDetalle As PlanDetalleVenta = Session("PlanDetalle")
            Dim strMaterialPM As String = String.Empty
            oBEItemMensaje.codigo = "99"

            If hidAccion.Value = "Grabar" Then
                strMaterialPM = arrPlanDetalle.MATERIAL
            ElseIf hidAccion.Value = "GenerarPedido" Then
                strMaterialPM = txtCodEquipo.Text
            End If
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strMaterialPM: --> " & strMaterialPM)

            Dim strNroSecPM As String = Funciones.CheckStr(hidNroSEC.Value)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strNroSecPM: --> " & strNroSecPM)

            Dim strTipoOperacion As String = Funciones.CheckStr(Funciones.CheckInt16(ConfigurationSettings.AppSettings("constCodOperRenovacionPVU"))) 'CheckStr(hidTipoOperacion.Value)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strTipoOperacion: --> " & strTipoOperacion)

            Dim strCodPlan As String = arrPlanDetalle.SOPLN_CODIGO
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strCodPlan: --> " & strCodPlan)

            Dim strFechaEvaluacion As String = String.Format("{0:dd/MM/yyyy}", Now)

            Dim strTipoCliente As String = CheckStr(hidTipoOferta.Value)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strTipoCliente-antes: --> " & strTipoCliente)

            'PROY-24724-IDEA-28174 - Parametros -INI
            If (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteMasivo)) Then
                strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteMasivo)
            ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteB2E)) Then
                strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteB2E)
            ElseIf (strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTCodClienteBusiness)) Then
                strTipoCliente = Funciones.CheckStr(ClsKeyAPP.strTClienteBusiness)
            End If
            'PROY-24724-IDEA-28174 - Parametros -FIN

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strTipoCliente-convertido: --> " & strTipoCliente)

            Dim strDeducibleReal As String = (Funciones.CheckStr(hidDeducible.Value)).Trim()
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strDeducibleReal: --> " & strDeducibleReal)

            Dim arrDeducibleDesglose() As String
            Dim strDeduDanoFalla As String = String.Empty
            Dim arrDeduDanoFalla() As String
            Dim strDeducibleRobo As String = String.Empty
            Dim arrDedurobo() As String

            arrDeducibleDesglose = strDeducibleReal.Split(Convert.ToChar("-"))

            '' Asignación Robo
            arrDedurobo = Trim(arrDeducibleDesglose(0)).Split(Convert.ToChar(" "))
            strDeducibleRobo = Trim(arrDedurobo(1).Substring(0, (arrDedurobo(1).Length - 1)))
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strDeducibleRobo: --> " & strDeducibleRobo)

            '' Asignación de Dano/Falla
            arrDeduDanoFalla = Trim(arrDeducibleDesglose(1)).Split(Convert.ToChar(" "))
            strDeduDanoFalla = Trim(arrDeduDanoFalla(1).Substring(0, (arrDeduDanoFalla(1).Length - 1)))
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "strDeduDanoFalla: --> " & strDeduDanoFalla)

            Dim strTipoDoc As String = CheckStr(hidTipoDocumento.Value)
            Dim strNroDoc As String = CheckStr(hidNroDocumento.Value)
            Dim strDescProducto As String = ClsKeyAPP.strDesServProteccionMovil
            Dim strCodMaterial As String = strMaterialPM
            Dim strNroCertificado As String = CheckStr(hidCertificadoPM.Value)
            Dim strMontoPrima As String = CheckStr(hidPrima.Value)
            Dim strIncTipoDanoFalla As String = ""
            Dim strIncTipoRobo As String = ""
            Dim strDeducibleDanoFalla As String = strDeduDanoFalla
            Dim strDeducibleRob As String = strDeducibleRobo
            Dim strResultadoRpta As String = ClsKeyAPP.strFlagEstado
            Dim strNomProdRpta As String = String.Empty
            Dim strDescProductoRpta As String = String.Empty
            Dim strFlagEstado As String = ClsKeyAPP.strFlagEstado
            Dim strFechaModifica As String = String.Empty
            Dim strUsuarioModifica As String = String.Empty
            Dim strMetodo As String = "guardarPrima"
            Dim strFlagCorreo As String = "GP"
            Dim strDatosAdicionales As String = Funciones.CheckStr(hidDatosAdicionalesPM.Value)
            Dim arrDatosAdicionales() As String

            Dim objAudit As New BEItemGenerico

            strUsuarioModifica = Funciones.CheckStr(CurrentUser)

            objAudit.Codigo = strNroSecPM + String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)
            objAudit.Codigo2 = strUsuarioModifica
            objAudit.Codigo3 = Funciones.CheckStr(ConfigurationSettings.AppSettings("CodigoAplicacion"))
            objAudit.Descripcion = Funciones.CheckStr(ConfigurationSettings.AppSettings("constAplicacion"))
            objAudit.Descripcion2 = Funciones.CheckStr(CurrentTerminal) '

            Try
                arrDatosAdicionales = strDatosAdicionales.Split("|")
                strNomProdRpta = Funciones.CheckStr(arrDatosAdicionales(0))
                strDescProductoRpta = Funciones.CheckStr(arrDatosAdicionales(1))
                strIncTipoDanoFalla = Funciones.CheckStr(arrDatosAdicionales(2))
                strIncTipoRobo = Funciones.CheckStr(arrDatosAdicionales(3))

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " >>>>>>>>>>>> INICIO GuardarPrima() <<<<<<<<<<<< ")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN            SEC: --> " & strNroSecPM)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN   T. Operación: --> " & strTipoOperacion)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN      Cod. Plan: --> " & strCodPlan)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN     Fecha Eval: --> " & strFechaEvaluacion)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN     T. Cliente: --> " & strTipoCliente)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN   T. Documento: --> " & strTipoDoc)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN       Nro Doc.: --> " & strNroDoc)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN       Producto: --> " & strDescProducto)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN   Cod Material: --> " & strCodMaterial)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN    Certificado: --> " & strNroCertificado)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN          Prima: --> " & strMontoPrima)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN IncTipoDanoFalla: --> " & strIncTipoDanoFalla)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN    IncTipoRobo: --> " & strIncTipoRobo)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN Dedu Dano/Falla: --> " & strDeducibleDanoFalla)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN Deducible Robo: --> " & strDeducibleRob)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN Resultado Rpta: --> " & strResultadoRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN Nombre Prod Rpta: --> " & strNomProdRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN Desc. Prod rpta: --> " & strDescProductoRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN      Flag etado: --> " & strFlagEstado)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "IN F. Modificación: --> " & strFechaModifica)


                oBEItemMensaje = oBWGestionaProteccionMovil.GuardarProteccionMovil(strNroSecPM, strTipoOperacion, strCodPlan, strFechaEvaluacion, strTipoCliente, _
                                                                         strTipoDoc, strNroDoc, strDescProducto, strCodMaterial, strNroCertificado, _
                                                                         strMontoPrima, strIncTipoDanoFalla, strIncTipoRobo, strDeducibleDanoFalla, strDeducibleRob, _
                                                                         strResultadoRpta, strNomProdRpta, strDescProductoRpta, strFlagEstado, strFechaModifica, _
                                                                         strUsuarioModifica, objAudit)

                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "OUT CodRpta          --> " & oBEItemMensaje.codigo)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "OUT MsjRpta         --> " & oBEItemMensaje.descripcion)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " >>>>>>>>>>>> FIN GuardarPrima() <<<<<<<<<<<< ")

            Catch ex As Exception
                strFlagError = "1"
                hidErrorGrabarProtMovil.Value = "1"
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " >>>>>>>>>>>> Entró Catch GuardarPrima() <<<<<<<<<<<< ")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " hidErrorGrabarProtMovil" & hidErrorGrabarProtMovil.Value)

                oBEItemMensaje.exito = False
                oBEItemMensaje.codigo = ""
                oBEItemMensaje.descripcion = "Entró al Catch del método GrabarPrima() - Descripción EX : " & ex.Message
                oBEItemMensaje.descripcion = "Mensaje: " & ConfigurationSettings.AppSettings("consGestionaProteccionMovilWS_Error")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " oBEItemMensaje.descripcion" & oBEItemMensaje.descripcion)
                strPedido = "NC"
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " strPedido" & strPedido)

            End Try

            If oBEItemMensaje.exito = False Then
                strPedido = "NC"
                hidErrorGrabarProtMovil.Value = "1"
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " oBEItemMensaje.exito" & oBEItemMensaje.exito)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " strNroSecPM" & strNroSecPM)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " strCodPlan" & strCodPlan)
                EliminarProtecionMovil(strNroSecPM, oBEItemMensaje, strCodPlan, "", "")
            Else
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & "    Se ejecutó correctamente GuardarPrima() ")
            End If

        Catch ex As Exception
            Dim strNroSecPM As String = Funciones.CheckStr(hidNroSEC.Value)
            Dim oBEItemMensaje As New BEItemMensaje
            Dim arrPlanDetalle As PlanDetalleVenta = Session("PlanDetalle")
            Dim strCodPlan As String = arrPlanDetalle.SOPLN_CODIGO
            hidErrorGrabarProtMovil.Value = "1"
            strPedido = "NC"
            oBEItemMensaje.exito = False
            oBEItemMensaje.codigo = ""
            oBEItemMensaje.descripcion = "Entró al Catch del método GrabarPrima() - Descripción EX : " & ex.Message

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " strNroSecPM" & strNroSecPM)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " strCodPlan" & strCodPlan)

            EliminarProtecionMovil(strNroSecPM, oBEItemMensaje, strCodPlan, "", "")
        End Try
    End Function

    Private Function EliminarProtecionMovil(ByVal strNroSecPM As String, ByVal oBEItemMensaje As BEItemMensaje, ByVal strCodPlan As String, ByVal FlagPedidoPrima As String, ByVal strNCertificado As String)

        Dim oBLProteccionMovil As New BLProteccionMovil
        Dim strCodServProtMovil As String = ClsKeyAPP.strCodServProteccionMovil
        Dim strCodRpta As String = String.Empty
        Dim strMsjRpta As String = String.Empty

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "  FlagPedidoPrima    --> " & FlagPedidoPrima)

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " >>" & " INICIO EliminarProtecionMovil" & " <<<<<<<<<")

        Try
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " >>" & " INICIO BorrarServicioProteccionMovil" & " <<<<<<<<<")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "         PKG_TRANS_ASURION.SISACTSD_BORRAR_SERV_VENTA")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "          IN NroSEC           --> " & strNroSecPM)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "          IN CodServProtMovil --> " & strCodServProtMovil)
            oBLProteccionMovil.BorrarServicioProteccionMovil(strNroSecPM, strCodServProtMovil, strCodPlan, strCodRpta, strMsjRpta)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "         OUT CodRpta    --> " & strCodRpta)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "         OUT strMsjRpta --> " & strMsjRpta)
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " >>" & " Fin BorrarServicioProteccionMovil" & " <<<<<<<<<")

        Catch ex As Exception
            strCodRpta = ""
            strMsjRpta = ex.Message.ToString()
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Entró al Catch del Método BorrarServicioProteccionMovil()")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Error en BorrarServicioProteccionMovil() ")
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " Msj Error: --> " & strMsjRpta)
        End Try


        If Not (strCodRpta = "0") Then
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " Error en  BorrarServicioProteccionMovil()")
        End If


        If FlagPedidoPrima = "GPP" Then 'GPP sólo se usa cuando va al Catch de GrabarPedidoPrima
            Try
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & ">>>>> INICIO oBLProteccionMovil.EliminarProteccionMovil()  <<<<")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "      PKG_TRANS_ASURION.SISACTSU_ELIMINA_EVAL_SEGURO")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "       IN NroSEC         --> " & strNroSecPM)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "       IN NroCertificado --> " & strNCertificado)
                oBLProteccionMovil.EliminarProteccionMovil(strNroSecPM, strNCertificado, strCodRpta, strMsjRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "       OUT CodRpta       --> " & strCodRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "       OUT strMsjRpta    --> " & strMsjRpta)
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & ">>>>> FIN oBLProteccionMovil.EliminarProteccionMovil()     <<<<")
            Catch ex As Exception
                strCodRpta = ""
                strMsjRpta = ex.Message.ToString()
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Entró al Catch del Método EliminarProteccionMovil()")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Error en EliminarProteccionMovil() ")
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " Msj Error: --> " & strMsjRpta)
            End Try

            If Not (strCodRpta = "0") Then
                oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " Error en  EliminarProteccionMovil()")
            End If
        End If
        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & " >>" & " FIN metodo EliminarProtecionMovil" & " <<<<<<<<<")
    End Function

    'PROY-24724-IDEA-28174 - FIN

    <Anthem.Method()> _
   Public Function CargarComboPuntoVenta(ByVal punto As String) As String
        Dim sbPuntosVenta As New StringBuilder
        Dim arrPuntoVenta As ArrayList = Session("session_arrPuntoVenta")
        Dim delimitador As String = String.Empty
        For Each oPuntoVenta As PuntoVenta In arrPuntoVenta
            If oPuntoVenta.TOFIC_CODIGO.Equals(punto) Then
                sbPuntosVenta.AppendFormat("{0}{1};{2};{3};{4};{5}", delimitador, oPuntoVenta.OVENC_CODIGO, oPuntoVenta.OVENV_DESCRIPCION, oPuntoVenta.TOFIC_CODIGO, oPuntoVenta.CANAC_CODIGO, oPuntoVenta.OVENC_REGION)
                delimitador = "|"
            End If
        Next
        Return sbPuntosVenta.ToString()
    End Function
    <Anthem.Method()> _
        Public Function CheckCuotasPendientes() As String
        'PROY-31948 INI 
        Try
            Dim strNroDocumento As String = CheckStr(hidNroDocumento.Value)
            Dim strTipoDocumento As String = CheckStr(hidTipoDocumento.Value)
            Dim strNroLinea As String = CheckStr(hidNroLinea.Value)
            Dim objCuotaOAC As New BWConsultaCuotaCliente
            Dim objMaxCuotasOAC As Cuota
            Dim strMaxCuotas As String = ""
            Dim strMsjCuotas As String = ""

            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Inicio Metodo CheckCuotasPendientes")
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Inicio ConsultarCuotaCliente")
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - strTipoDocumento: " & strTipoDocumento)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - strNroDocumento: " & strNroDocumento)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - strNroLinea: " & strNroLinea)
            objMaxCuotasOAC = objCuotaOAC.ConsultarCuotaCliente(strTipoDocumento, strNroDocumento, strNroLinea)
            strMaxCuotas = objMaxCuotasOAC.CantCuotasPendLinea.ToString()
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Maximo de Cuotas del Cliente: " & strMaxCuotas)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin ConsultarCuotaCliente")

            Dim valor As String = String.Empty
            Dim valor1 As String = String.Empty
            Dim valor2 As String = String.Empty
            Dim lista As New ArrayList

            Dim intParamGrupo As Integer = CheckInt(ConfigurationSettings.AppSettings("consFlagMaxCuotas"))
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Inicio ListaParametrosMaxCuotas_Keys")
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - ParamGrupo: " & intParamGrupo)
            Dim listaParamRenov As ArrayList = New MaestroNegocio().ListaParametrosMaxCuotas_Keys(intParamGrupo)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - ListaParametrosMaxCuotas: " & listaParamRenov.Count.ToString())
            For Each oItem As Parametro In listaParamRenov
                lista.Add(oItem.Valor)
            Next
            valor = lista(0)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - FlagCuotas: " & valor)
            valor1 = lista(1)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Mensaje a mostrar: " & valor1)
            valor2 = lista(2)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Maxima Cuota: " & valor2)
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin ListaParametrosMaxCuotas_Keys")

            If (valor = "1") Then
                If (Funciones.CheckInt(strMaxCuotas) >= Funciones.CheckInt(valor2)) Then
                    strMsjCuotas &= "0"
                    strMsjCuotas &= ";"
                    strMsjCuotas &= valor1
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Cadena Retorno: " & strMsjCuotas)
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin Metodo CheckCuotasPendientes")
                    Return strMsjCuotas

                ElseIf (Funciones.CheckInt(strMaxCuotas) < Funciones.CheckInt(valor2)) Then
                    strMsjCuotas &= "1"
                    strMsjCuotas &= ";"
                    strMsjCuotas &= ""
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Cadena Retorno: " & strMsjCuotas)
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin Metodo CheckCuotasPendientes")
                    Return strMsjCuotas
                Else
                    strMsjCuotas &= "1"
                    strMsjCuotas &= ";"
                    strMsjCuotas &= ""
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Cadena Retorno: " & strMsjCuotas)
                    oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin Metodo CheckCuotasPendientes")
                    Return strMsjCuotas
                End If
            Else
                oLog.Log_WriteLog(strArchivo, "PROY-31948 - FlagSistema Apagado ")
                oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin Metodo CheckCuotasPendientes")
                Return strMsjCuotas
            End If
        Catch ex As Exception
            Dim strMensajeError As String
            strMensajeError &= "2"
            strMensajeError &= ";"
            strMensajeError &= ConfigurationSettings.AppSettings("constMsjErrorEvaluacion")
            oLog.Log_WriteLog(strArchivo, "PROY-31948 - Fin Error: " & ex.Message)
            Return strMensajeError

        End Try
        'PROY-31948 FIN
    End Function

    'Inicio PROY-25335 - Contratación Electrónica - Release 0
    ' OSCAR ATENCIO TIMANA '
    Private Function RegistrarBiometriaGendoc(ByVal NroSEC As String, ByVal DNICliente As String, ByVal NroPedido As String)

        'Representante Legal
        Dim oMantMaestro As New MaestroNegocio
        Dim OBiometria As New BEBiometria
        Dim DesTipoOperacion As String

        If hidValidarIccid.Value.Equals("1") Then
            DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacionpack")
        Else
            DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion")
        End If
        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacion")

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Entró al Método RegistrarBiometriaGendoc()")

        OBiometria.GDOC_NROPEDIDO = Int64.Parse(NroPedido)
        OBiometria.GDOC_NROSEC = Int64.Parse(NroSEC)
        OBiometria.GDOC_TIPODOCUMENTO = hidTipoDocumento.Value
        OBiometria.GDOC_NRODOCUMENTO = DNICliente


        Dim strLineaGendoc As String = Funciones.CheckStr(hidNroLinea.Value)
        If strLineaGendoc.Equals("") Then
            strLineaGendoc = Funciones.CheckStr("0")
        End If

        OBiometria.GDOC_LINEA = strLineaGendoc
        OBiometria.GDOC_PRODUCTO = "MOVIL"
        OBiometria.GDOC_APLICACION = "SISACT"
        OBiometria.GDOC_TIP_OPERACION = tipoOperacion

        Dim strPuntoventaGendoc As String = Funciones.CheckStr(hidOfVentaCod.Value)
        If strPuntoventaGendoc.Equals("") Then
            strPuntoventaGendoc = Funciones.CheckStr(hidOficinaActual.Value.Split(",")(0))
        End If
        OBiometria.GDOC_PDV = strPuntoventaGendoc
        OBiometria.GDOC_MODALIDAD = "POSTPAGO"
        OBiometria.GDOC_DEPARTAMENTO = ""
        OBiometria.GDOC_TIPDOCVEND = "01"
        OBiometria.GDOC_NRODOCVEND = ""
        OBiometria.GDOC_CODVENDEDOR = CheckStr(Session("CodVendedorSAP"))
        OBiometria.GDOC_SERIELECTOR = hidSerieLector.Value
        OBiometria.GDOC_IDPADRE = hidIdPadreBio.Value
        OBiometria.GDOC_CODVENDSEC = CheckStr(Session("CodVendedorSAP"))
        OBiometria.GDOC_USUARIO_CREA = CurrentUser
        OBiometria.GDOC_ESTADO = "3"

        oMantMaestro.RegistrarBiometriaGendoc(OBiometria)

        oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "OK RegistrarBiometriaGendoc()")

    End Function


    Private Function RegistrarRepresentanteLegalSEC(ByVal NroSEC As String, ByVal DNICliente As String, ByVal NroPedido As String)
        'Representante Legal
        Dim oMantMaestro As New MaestroNegocio
        Dim arrListaRepresentante As New ArrayList
        Dim cadenaRepresentanteLegal As String = hidListaRepresentante.Value
        Dim retorno As Boolean = False
        Dim tipoDocRRLL As String = String.Empty

        If CheckStr(hidListaRepresentante.Value) <> "" Then

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Inicio Registro Representante Legal")
            Dim arrRepresentanteLegal() As String = CheckStr(hidListaRepresentante.Value).Split("|"c)


            For Each representantes As String In arrRepresentanteLegal

                Dim arregloDatos() As String = representantes.Split(";"c)
                Dim oRepresentanteLegal As New RepresentanteLegal

                oRepresentanteLegal.CLIEC_NUM_DOC = DNICliente
                oRepresentanteLegal.APODV_NUM_DOC_REP = Funciones.CheckStr(arregloDatos(1))
                oRepresentanteLegal.APODV_NOM_REP_LEG = Funciones.CheckStr(arregloDatos(2))
                oRepresentanteLegal.APODV_APA_REP_LEG = Funciones.CheckStr(arregloDatos(3))
                oRepresentanteLegal.APODV_AMA_REP_LEG = Funciones.CheckStr(arregloDatos(4))
                oRepresentanteLegal.APODV_CAR_REP = Funciones.CheckStr(arregloDatos(5))
                oRepresentanteLegal.SOLIN_CODIGO = Funciones.CheckInt64(NroSEC)
                oRepresentanteLegal.P_SCPN_NRO_PEDIDO = Funciones.CheckInt64(NroPedido)
                oRepresentanteLegal.P_SCPV_APLICACION = "SISACT"
                oRepresentanteLegal.P_SCPV_USUARIO_CREA = CurrentUser
                oRepresentanteLegal.P_SRLV_ID_TX_P = Funciones.CheckStr(hidIdPadreBio.Value)

                '//INI PROY-31636
                oRepresentanteLegal.P_SRLC_CODNACIONALIDAD = Funciones.CheckStr(arregloDatos(6))
                oRepresentanteLegal.P_SRLV_DESCNACIONALIDAD = Funciones.CheckStr(arregloDatos(7))
                '//FIN PROY-31636

                If (Funciones.CheckStr(arregloDatos(0) = "1")) Then
                    tipoDocRRLL = "01"
                ElseIf (Funciones.CheckStr(arregloDatos(0) = "3")) Then
                    tipoDocRRLL = "04"
                ElseIf (Funciones.CheckStr(arregloDatos(0) = "6")) Then
                    tipoDocRRLL = "06"
                    '//'//INI PROY-31636
                ElseIf (Funciones.CheckStr(arregloDatos(0) = AppSettings.Key_codigoDocCIRE)) Then
                    tipoDocRRLL = "11"
                ElseIf (Funciones.CheckStr(arregloDatos(0) = AppSettings.Key_codigoDocCIE)) Then
                    tipoDocRRLL = "12"
                ElseIf (Funciones.CheckStr(arregloDatos(0) = AppSettings.Key_codigoDocCPP)) Then
                    tipoDocRRLL = "13"
                ElseIf (Funciones.CheckStr(arregloDatos(0) = AppSettings.Key_codigoDocCTM)) Then
                    tipoDocRRLL = "14"
                    '//'//INI PROY-31636
                Else
                    tipoDocRRLL = "99"
                End If

                If (Funciones.CheckStr(arregloDatos(0)) = "") Then
                    If (arregloDatos(1).Length = 8) Then
                        tipoDocRRLL = "01"
                    End If
                End If


                oRepresentanteLegal.APODC_TIP_DOC_REP = tipoDocRRLL

                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroDocumentoCliente", Funciones.CheckStr(oRepresentanteLegal.CLIEC_NUM_DOC)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "TipoDocumentoRepLegal", Funciones.CheckStr(oRepresentanteLegal.APODC_TIP_DOC_REP)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroDocumentoRepLegal", Funciones.CheckStr(oRepresentanteLegal.APODV_NUM_DOC_REP)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NombresRepLegal", Funciones.CheckStr(oRepresentanteLegal.APODV_NOM_REP_LEG)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "ApellidoPatRepLegal", Funciones.CheckStr(oRepresentanteLegal.APODV_APA_REP_LEG)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "ApellidoMatRepLegal", Funciones.CheckStr(oRepresentanteLegal.APODV_AMA_REP_LEG)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "Carta Representante", Funciones.CheckStr(oRepresentanteLegal.APODV_CAR_REP)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroSolicitud", Funciones.CheckStr(oRepresentanteLegal.SOLIN_CODIGO)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroPedido", Funciones.CheckStr(oRepresentanteLegal.P_SCPN_NRO_PEDIDO)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "Aplicativo", Funciones.CheckStr(oRepresentanteLegal.P_SCPV_APLICACION)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "Usuario", Funciones.CheckStr(oRepresentanteLegal.P_SCPV_USUARIO_CREA)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "IdPadre", Funciones.CheckStr(oRepresentanteLegal.P_SRLV_ID_TX_P)))
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "CodNacionalidad", Funciones.CheckStr(oRepresentanteLegal.P_SRLC_CODNACIONALIDAD))) '//PROY-31636
                oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "DescNacionalidad", Funciones.CheckStr(oRepresentanteLegal.P_SRLV_DESCNACIONALIDAD))) '//PROY-31636

                retorno = oMantMaestro.RegistrarRepresentanteLegalSEC(oRepresentanteLegal)

                If (retorno) Then
                    oLog.Log_WriteLog(strArchivo, "Se registraron correctamente los Representantes Legales")
                Else
                    oLog.Log_WriteLog(strArchivo, "Ocurrió un error al registrar los Representantes Legales")
                End If

                oLog.Log_WriteLog(strArchivo, "Fin Registro Representante Legal")

            Next
            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "OK RegistrarRepresentanteLegalSEC()")
        End If
    End Function

    Private Function RegistrarCartaPoderSEC(ByVal NroSEC As String, ByVal NroPedido As String)

        If (hidCheckCartaPoder.Value.Equals("S")) Then

            oLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "Entró al Método RegistrarCartaPoderSEC()")
            Dim oMantMaestro As New MaestroNegocio
            Dim OCartaPoder As New BECartaPoder
            Dim DesTipoOperacion As String
            Dim retorno As Boolean = False

            If hidValidarIccid.Value.Equals("1") Then
                DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacionpack")
            Else
                DesTipoOperacion = ConfigurationSettings.AppSettings("constTextoOperacionRenovacion")
            End If
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacion")


            OCartaPoder.SCPN_NRO_PEDIDO = Funciones.CheckInt64(NroPedido)
            OCartaPoder.SCPN_SOLIN_CODIGO = Funciones.CheckInt64(NroSEC)
            OCartaPoder.SCPV_ID_TX_P = ""
            OCartaPoder.SCPV_TIPO_TRANSACCION = ""
            OCartaPoder.SCPV_TIPO_OPERACION = Funciones.CheckStr(tipoOperacion)
            OCartaPoder.SCPV_DESC_OPERACION = Funciones.CheckStr(DesTipoOperacion)
            OCartaPoder.SCPV_TIPO_DOCUMENTO_AP = Funciones.CheckStr(hidTipoDocumento.Value)
            OCartaPoder.SCPV_NRO_DOCUMENTO_AP = Funciones.CheckStr(hidNroDocumento.Value)
            OCartaPoder.SCPV_NOMBRES_AP = Funciones.CheckStr(hidNombre.Value).ToUpper
            OCartaPoder.SCPV_APELLIDOS_PAT_AP = Funciones.CheckStr(hidApePaterno.Value.ToUpper)
            OCartaPoder.SCPV_APELLIDOS_MAT_AP = Funciones.CheckStr(hidApeMaterno.Value.ToUpper)
            OCartaPoder.SCPV_OBSERVACION = ""
            OCartaPoder.SCPV_APLICACION = "SISACT"
            OCartaPoder.SCPV_USUARIO_CREA = CurrentUser


            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroPedido", Funciones.CheckStr(OCartaPoder.SCPN_NRO_PEDIDO)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroSolicitud", Funciones.CheckStr(OCartaPoder.SCPN_SOLIN_CODIGO)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "TipoOperacion", Funciones.CheckStr(OCartaPoder.SCPV_TIPO_OPERACION)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "DescOperacion", Funciones.CheckStr(OCartaPoder.SCPV_DESC_OPERACION)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "TipoDocumentoAP", Funciones.CheckStr(OCartaPoder.SCPV_TIPO_DOCUMENTO_AP)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NumeroDocumentoAP", Funciones.CheckStr(OCartaPoder.SCPV_NRO_DOCUMENTO_AP)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "NombresAP", Funciones.CheckStr(OCartaPoder.SCPV_NOMBRES_AP)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "ApellidoPatAP", Funciones.CheckStr(OCartaPoder.SCPV_APELLIDOS_PAT_AP)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "ApellidoMatAP", Funciones.CheckStr(OCartaPoder.SCPV_APELLIDOS_MAT_AP)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "Aplicacion", Funciones.CheckStr(OCartaPoder.SCPV_APLICACION)))
            oLog.Log_WriteLog(strArchivo, String.Format("{0} => {1}", "UsuarioCrea", Funciones.CheckStr(OCartaPoder.SCPV_USUARIO_CREA)))

            retorno = oMantMaestro.RegistrarCartaPoderSEC(OCartaPoder)

            If (retorno) Then
                oLog.Log_WriteLog(strArchivo, "Se registró correctamente la Carta Poder")
            Else
                oLog.Log_WriteLog(strArchivo, "Ocurrió un error al registrarla Carta Poder")
            End If

            oLog.Log_WriteLog(strArchivo, "Fin Registro Carta Poder")

        End If


    End Function

    <Anthem.Method()> _
    Public Function ObtenerIdPadreBiometria() As String
        Dim retorno As New StringBuilder
        Dim resultado As String = String.Empty
        Dim flagbiopost As String = String.Empty
        Dim flaghuelleropost As String = String.Empty

        LleanrParametrosBio(flagbiopost, flaghuelleropost)

        Dim oConsultar As New MaestroNegocio
        'Obtener el Prefijo de los Documentos de Venta
        Dim prefijo As String = oConsultar.Generar_ID_BIO(1)
        retorno.AppendFormat("{0},{1},{2}", prefijo, flagbiopost, flaghuelleropost)

        Return retorno.ToString

    End Function
    ' OSCAR ATENCIO TIMANA '

    <Anthem.Method()> _
 Public Function MostrarCheckCartaPoder(ByVal canal As String) As String
        Dim result As String = String.Empty

        If AppSettings.Key_canalesPermitidosCP.IndexOf(canal) > -1 Then
            result = "1"
        Else
            result = "0"
        End If

        Return result
    End Function
'Fin PROY-25335 - Contratación Electrónica - Release 0

    'PROY-32129 :: INI
    <Anthem.Method()> _
    Public Function registrarAlumno(ByVal tipoDoc As String, ByVal nroDoc As String, ByVal uni As String, ByVal codAlumno As String) As String

        Dim sCodMensaje As String
        Dim sMensaje As String
        Dim sEstadoGrabar As String

        Try
            Dim objBLCasoEspecial As New BLCasoEspecial
            Dim blEstado As Boolean
            Dim sInstituto As Int64 = Funciones.CheckInt64(uni)

            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "********** Inicio Registro de Alumno *********")

            If (hidEstadoCasoEsp.Value.Equals("1")) Then
                Return "-1"
            End If

            blEstado = objBLCasoEspecial.RegistrarAlumno(tipoDoc, nroDoc, sInstituto, codAlumno, CurrentUser, sCodMensaje, sMensaje)
            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "Resultado del registro")
            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "Codigo Mensaje : " & sCodMensaje)
            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "Mensaje : " & sMensaje)
            'sCodMensaje => 1 = Los datos se grabaron/actualizaron correctamente
            'sCodMensaje => 0 = Los datos NO se grabaron/actualizaron correctamente

            If (blEstado) Then
                oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "Se registro correctamente el alumno : " & codAlumno)
                sEstadoGrabar = "1"
                'hidEstadoCasoEsp.Value = CheckStr(1)
            Else
                oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "No registro el alumno : " & codAlumno)
                sEstadoGrabar = "0"
                'hidEstadoCasoEsp.Value = CheckStr(0)
            End If
        Catch ex As Exception
            sEstadoGrabar = "0"
            'hidEstadoCasoEsp.Value = CheckStr(0)
            sCodMensaje = "-1"
            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "Error al registrar el alumno : " & codAlumno)
        Finally
            oLog.Log_WriteLog(strArchivo, nroDoc & " | " & "********** Fin Registro de Alumno *********")
        End Try

        Return sCodMensaje + ";" + sEstadoGrabar
    End Function

    Public Sub LLenarListaUniv()
        Try
            Dim objBLCasoEspecial As New BLCasoEspecial
            Dim sCodMensaje, sMensaje As String
            oLog.Log_WriteLog(strArchivo, "TEST" & " | " & "********** Inicio Listar Universidades *********")

            Dim lstUniversidad As ArrayList = objBLCasoEspecial.ListarUniversidades(sCodMensaje, sMensaje)
            oLog.Log_WriteLog(strArchivo, "Proy-32129 Campana Caso Especial" & " | " & "Resultado de Consulta")
            oLog.Log_WriteLog(strArchivo, "Proy-32129 Campana Caso Especial" & " | " & "Valor Tipo Documento: " & sCodMensaje)
            oLog.Log_WriteLog(strArchivo, "Proy-32129 Campana Caso Especial" & " | " & "Cantidad de Registros: " & sMensaje)

            Dim lstFiltrada As New ArrayList
            For Each item As ItemGenerico In lstUniversidad
                lstFiltrada.Add(item)
            Next

            ddlListaUni.DataSource = lstFiltrada
            ddlListaUni.DataValueField = "Codigo"
            ddlListaUni.DataTextField = "Descripcion"
            ddlListaUni.DataBind()
            ddlListaUni.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, "Proy-32129 Campana Caso Especial" & " | " & "Error al listar universidades - " & ex.Message.ToString())
        Finally
            oLog.Log_WriteLog(strArchivo, "Proy-32129 Campana Caso Especial" & " | " & "********** Fin Listar Universidades *********")
        End Try
    End Sub
    'PROY-32129 :: FIN

<Anthem.Method()> _
    Public Function obtenerNacionalidad() As String
        Dim objBWNacionalidad As BWConsultaNacionalidad = New BWConsultaNacionalidad
        Dim objConsultaClave As BWConsultaClaves = New BWConsultaClaves

        Dim strNacionalidad As String = String.Empty
        Dim msgRespuesta As String = String.Empty
        Dim codRespuesta As String = String.Empty
        Dim lstArraNacionalidad As ArrayList = New ArrayList
        Try
            oLog.Log_WriteLog(strArchivo, "--- Inicio Método [obtenerNacionalidad] ----")

            Dim wsIp As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("DAT_ConsultaNacionalidad_wsIp"))
            Dim ipTransaccion As String = CurrentTerminal
            Dim usrAplicacion As String = CurrentUser
            Dim codigoAplicacion As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim idAplicacion As String = ConfigurationSettings.AppSettings("system_ConsultaClave")
            Dim usuarioAplicacionEncriptado As String = ConfigurationSettings.AppSettings("User_ConsultaNacionalidad")
            Dim claveEncriptada As String = ConfigurationSettings.AppSettings("Password_ConsultaNacionalidad")


            oLog.Log_WriteLog(strArchivo, "-- INICIO: SERVICIO DESENCRIPTACION -> BWConsultaClaves.ConsultaClavesWS --")

            oLog.Log_WriteLog(strArchivo, String.Format("wsIp => {0}", wsIp))
            oLog.Log_WriteLog(strArchivo, String.Format("ipTransaccion => {0}", ipTransaccion))
            oLog.Log_WriteLog(strArchivo, String.Format("usrAplicacion => {0}", usrAplicacion))
            oLog.Log_WriteLog(strArchivo, String.Format("codigoAplicacion => {0}", codigoAplicacion))
            oLog.Log_WriteLog(strArchivo, String.Format("idAplicacion => {0}", idAplicacion))
            oLog.Log_WriteLog(strArchivo, String.Format("usuarioAplicacionEncriptado => {0}", usuarioAplicacionEncriptado))
            oLog.Log_WriteLog(strArchivo, String.Format("claveEncriptada => {0}", claveEncriptada))

            Dim codigoResultado As String = String.Empty
            Dim mensajeResultado As String = String.Empty
            Dim usuarioAplicacion As String = String.Empty
            Dim clave As String = String.Empty

            codigoResultado = objConsultaClave.ConsultaClavesWS(DateTime.Now.ToString("YYYYMMDDHHMISSMS"), _
                                                                 wsIp, _
                                                                 ipTransaccion, _
                                                                 usrAplicacion, _
                                                                 codigoAplicacion, _
                                                                 idAplicacion, _
                                                                 usuarioAplicacionEncriptado, _
                                                                 claveEncriptada, _
                                                                 mensajeResultado, _
                                                                 usuarioAplicacion, _
                                                                 clave)

            oLog.Log_WriteLog(strArchivo, String.Format("codigoResultado => {0}", codigoResultado))
            oLog.Log_WriteLog(strArchivo, String.Format("mensajeResultado => {0}", mensajeResultado))

            oLog.Log_WriteLog(strArchivo, "-- FIN: SERVICIO DESENCRIPTACION -> BWConsultaClaves.ConsultaClavesWS --")

            lstArraNacionalidad = objBWNacionalidad.ConsultarNacionalidad(usuarioAplicacion, clave, CurrentUser, CurrentTerminal, wsIp, msgRespuesta, codRespuesta, strNacionalidad)

            If (codRespuesta = "0") Then
                oLog.Log_WriteLog(strArchivo, String.Format("Éxito al obtener la Nacionalidad => {0}", msgRespuesta))
                oLog.Log_WriteLog(strArchivo, String.Format("Se cargaron {0} nacionalidades", Funciones.CheckStr(lstArraNacionalidad.Count())))
            Else
                oLog.Log_WriteLog(strArchivo, String.Format("Ocurrió un error al obtener la Nacionalidad => {0}", msgRespuesta))
            End If

            Session("lstArraNacionalidad") = lstArraNacionalidad

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, "Ocurrió un error al obtener la Nacionalidad")
        End Try
        oLog.Log_WriteLog(strArchivo, "--- Fin Método [obtenerNacionalidad] ----")
        Return strNacionalidad
    End Function
End Class