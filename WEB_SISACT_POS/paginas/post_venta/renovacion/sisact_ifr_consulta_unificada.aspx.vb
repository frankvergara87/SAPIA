Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions
Imports System.Text

Public Class sisact_ifr_consulta_unificada
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidIdFila As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampana As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents idPlan As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResultado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMetodo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfil149 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlgEvaluarMovil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResultadoAux As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCicloFac As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRepLegal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLimiteCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTitular As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCorreo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaNac As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsgTitularidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMontoRegistrado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaMontoR As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPermanencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazoAcuerdo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesPorVencer As System.Web.UI.HtmlControls.HtmlInputHidden


    Protected WithEvents hidDireccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDepartamento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvincia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistrito As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidTelefonoReferencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaInicioApadece As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaFinApadece As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIMSI As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidSegmento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanAct As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidFlagReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCustumerId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApellidosCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombresCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagConfExoneracionReintegro As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidFlagVentaCuota As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagRenovacionAdelantada As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCFSiga As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCuentaBSCS As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidVigente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodPlanNoVigente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdPlanVig As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidplanDesNoVig As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanNuevo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidHlr As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPl4G As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampanasNoVig As System.Web.UI.HtmlControls.HtmlInputHidden 'Modificacion Planes No Vigentes
    Protected WithEvents hidDiasPendientes As System.Web.UI.HtmlControls.HtmlInputHidden 'Modificacion Planes No Vigentes
    Protected WithEvents hidOfertaLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValidadProtMovil As System.Web.UI.HtmlControls.HtmlInputHidden 'PROY-24724-IDEA-28174 
    Protected WithEvents hdAutoriza As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidInformativo As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim objLog As New SISACT_Log
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("sisact_ifr_consulta_unificada")
    Dim strCodTipoProducto3Play As String = ConfigurationSettings.AppSettings("consTipoProducto3Play")
    Dim strCodTipoProductoDTH As String = ConfigurationSettings.AppSettings("CodTipoProductoDTH")
    Dim strCodTipoProductoFijo As String = ConfigurationSettings.AppSettings("constTipoProductoFijo")
    Dim strCodParamCampanaxCuota As String = ConfigurationSettings.AppSettings("constCodParamCampanaxCuota")
    Dim strCodModalidadCuota As String = ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota")
    Dim strFlagServicioRI As String = String.Empty
    Dim _mpermanencia As Int32

    Dim strTipoDocumento As String
    Dim strTipoDocumentos As String
    Dim strNroDoc As String

    'gaa20150901
    Dim strFlujoRenovacion As String = ConfigurationSettings.AppSettings("constFlujoRenovacion")
    'fin gaa20150901
    Dim MesesMaxAS As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim strIdFila As String = Request.QueryString("idFila")
        Dim strPlazo As String = Request.QueryString("strPlazo")
        Dim strFlujo As String = Request.QueryString("strFlujo")
        Dim strOferta As String = Request.QueryString("strOferta")
        Dim strTipoProducto As String = Request.QueryString("strTipoProducto")
        strTipoDocumento = Request.QueryString("strTipoDocumento")
        Dim strCasoEspecial As String = Request.QueryString("strCasoEspecial")
        Dim strRiesgo As String = Request.QueryString("strRiesgo")
        Dim strCampana As String = Request.QueryString("strCampana")
        Dim strPlan As String = Request.QueryString("strPlan")
        Dim strOficina As String = Request.QueryString("strOficina")
        strNroDoc = Request.QueryString("strNroDoc")
        Dim strPerfil149 As String = Request.QueryString("strPerfil149")
        Dim strTipoCliente As String = Request.QueryString("strTipoCliente")
        Dim strTipoOficina As String = Request.QueryString("strTipoOficina")
        Dim strMaterial As String = Request.QueryString("strMaterial")
        Dim strCanal As String = Request.QueryString("strCanal")
        Dim strOrgVenta As String = Request.QueryString("strOrgVenta")
        Dim strTipoDocVenta As String = Request.QueryString("strTipoDocVenta")
        Dim strCentro As String = Request.QueryString("strCentro")
        Dim intNroCuotas As String = Request.QueryString("intNroCuotas")
        Dim strWhitellist As String = Request.QueryString("strWhitellist")
        Dim strMetodo As String = Request.QueryString("strMetodo")
        Dim strPlanSap As String = Request.QueryString("strPlanSap")
        Dim strPaquete As String = Request.QueryString("strPaquete")
        Dim strSecuencia As String = Request.QueryString("strSecuencia")
        Dim strPlanes As String = Request.QueryString("strPlanes")
        Dim strNroSec As String = Request.QueryString("strNroSec")
        Dim strTipoDocVentaSap As String = Request.QueryString("strTipoDocVentaSap")
        Dim strCanalSap As String = Request.QueryString("strCanalSap")
        Dim strSolucion As String = Request.QueryString("strSolucion")
        Dim strNroPorta As String = Request.QueryString("strNroPorta")
        Dim intTraerCampanasDTH As String = Request.QueryString("intTraerCampanasDTH")
        Dim strNroDocumento As String = Request.QueryString("strNroDocumento")
        Dim strCadenaDetalle As String = Request.QueryString("strCadenaDetalle")
        Dim strNrolinea As String = Request.QueryString("strNrolinea")
        strFlagServicioRI = Request.QueryString("strFlagServicioRI")
        strTipoDocumentos = Request.QueryString("strTipoDocumentos")
        Dim strTipoModalidadVenta As String = Request.QueryString("strTipoModalidadVenta")
        'inicio plan no vigente 30102015
        Dim strMantenerPlan As String = Request.QueryString("strMantenerPlan")
        Dim strCodPlanNoVigente As String = Request.QueryString("strCodPlanNoVigente")
        Dim strIdPlanVig As String = Request.QueryString("strIdPlanVig")
        MesesMaxAS = Request.QueryString("MesesMaxAS")
        Dim strplanDesNoVig As String = Request.QueryString("strplanDesNoVig")
        Dim strCampanasNoVig As String = Request.QueryString("strCampanasNoVig") 'Modificacion Planes No Vigente
        'fin plan no vigente 30102015

        'inicio 24/11/2015
        Dim strGrupoProducto As String = Request.QueryString("strGrupoProducto")
        'fin 24/11/2015


        If (strTipoModalidadVenta = ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota")) Then
            hidFlagVentaCuota.Value = "S"
        End If

        hidOficina.Value = strOficina
        hidFlgEvaluarMovil.Value = Request.QueryString("strFlgEvaluarMovil")
        hidNroDocumento.Value = Session("strNroDocumento")
        hidIdFila.Value = strIdFila
        hidMetodo.Value = strMetodo
        hidPerfil149.Value = strPerfil149
        hidResultado.Value = ""
        hidNroLinea.Value = strNrolinea

        Dim obj As BEFormEvaluacion = New BEFormEvaluacion
        obj.ModalidadVenta = strTipoModalidadVenta
        obj.IdTipoVenta = ConfigurationSettings.AppSettings("strTVPostpago").ToString()
        obj.IdOferta = strOferta
        obj.IdCampana = strCampana
        obj.IdTipoOperacion = ConfigurationSettings.AppSettings("constTipoOperacionREN").ToString()
        obj.IdPlazo = strPlazo
        obj.IdCuota = Request.QueryString("strCuota")
        obj.IdOficina = strOficina
        obj.IdPlan = strPlan
        obj.IdPlanSap = strPlanSap
        obj.IdMaterial = strMaterial
        obj.IdCampanaSap = ObtenerCampanaSap(obj.IdCampana)
        obj.CanalSap = strCanal
        obj.TipoDocumentoSap = strTipoDocVenta
        obj.OrgVentaSap = strOrgVenta
        obj.IdTipoOperacionSap = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP").ToString()
        obj.IdTipoOficina = strTipoOficina
        'gaa20161020
        obj.IdFamiliaPlan = Request.QueryString("strFamiliaPlan")
        'fin gaa20161020
        Dim strResultado As String = String.Empty

        Try
            strCasoEspecial = String.Empty 'CheckStr(strCasoEspecial).Split("_")(0)

            Select Case strMetodo
                Case "LlenarPlan" '20161027
                    strResultado = LlenarPlan(strOferta, strTipoProducto, strTipoDocumento, strOficina, strPlazo, strCampana, strFlujoRenovacion, String.Empty, strMantenerPlan, strCodPlanNoVigente, strIdPlanVig, strplanDesNoVig, strGrupoProducto, obj.IdFamiliaPlan)
                    hidResultado.Value = strResultado
                Case "LlenarMaterial"
                    hidCampana.Value = strCampana
                    strResultado = LlenarMaterial(strCampana, strPlan, strOficina, strOrgVenta, strCentro, strOficina, strTipoProducto, obj.IdTipoOperacion, strTipoDocumento, obj.IdTipoVenta, strPlazo, strOferta)
                    hidResultado.Value = strResultado
                Case "LlenarCampana"
                    strResultado = LlenarCampana(strPlan, strPlazo, strTipoDocumento, strOficina, strCasoEspecial, strRiesgo)
                    hidResultado.Value = strResultado
                Case "LlenarEquipoPrecio"
                    strResultado = LlenarEquipoPrecio(strOficina, strOferta, strPlazo, strPlanSap, Funciones.CheckStr(obj.IdCampanaSap), strMaterial, strCanal, strOrgVenta, strTipoDocVenta, intNroCuotas, strOferta)
                    'strResultado = LlenarEquipoPrecio(obj)'-dga
                    hidResultado.Value = strResultado
                Case "CambiarTipoOferta"
                    CambiarTipoOferta(strTipoCliente, strFlujo, strTipoDocumento, strTipoOficina)
                Case "LlenarMontoTopeConsumo"
                    LlenarMontoTopeConsumo(strPlan)
                Case "ValidarBlacklistComision"
                    ValidarBlacklistComision(strTipoDocumento, strNroDoc, strPerfil149, strOficina, strTipoOficina)
                Case "ValidarBlacklistComisionPostpago"
                    ValidarBlacklistComision(strTipoDocumento, strNroDoc, strPerfil149, strOficina, strTipoOficina)
                Case "CambiarCasoEspecial"
                    CambiarCasoEspecial(strOferta, strFlujo, strTipoDocumento, strNroDoc, strCasoEspecial, strWhitellist, strRiesgo)
                Case "LlenarServicio"
                    LlenarServicio(strCasoEspecial, strPlan, strPlanSap)
                Case "LlenarServicioCampana"
                    LlenarServicioCampana(strPlan, strPlazo, strTipoDocumento, strOficina, strCasoEspecial, strRiesgo, strPlanSap)
                Case "LlenarServicioCampanaCorp"
                    LlenarServicioCampanaCorp(strPlan, strPlazo, strTipoDocumento, strOficina, strCasoEspecial, strRiesgo, strPlanSap, strPaquete, strSecuencia, hidIdFila.Value)
                Case "LlenarServCampCorpTot"
                    LlenarServicioCampanaCorpTotal(strTipoDocumento, strOficina, strCasoEspecial, strRiesgo, strPlanes)
                Case "MostrarSecPendiente"
                    'gaa20161027
                    'MostrarSecPendiente(strNroSec, strFlujo, strTipoDocumento, strOficina, strRiesgo, strOrgVenta, strCentro, strTipoDocVentaSap, strCanalSap)
                    MostrarSecPendiente(strNroSec, strFlujo, strTipoDocumento, strOficina, strRiesgo, strOrgVenta, strCentro, strTipoDocVentaSap, strCanalSap, strTipoModalidadVenta)
                    'fin gaa20161027
                Case "LlenarPlanPaq"
                    LlenarPlanPaq(strPaquete)
                Case "LlenarPaquetePlan"
                    'gaa20170828
                    'LlenarPaquetePlan(strOferta, strTipoProducto, strTipoDocumento, strOficina, strPlazo, strFlujo, strCasoEspecial, strRiesgo)
                    LlenarPaquetePlan(strOferta, strTipoProducto, strTipoDocumento, strOficina, strPlazo, strFlujo, strCasoEspecial, strRiesgo, strNroDocumento, strFlujoRenovacion, strCampana, String.Empty)
                    'fin gaa20170828
                Case "LlenarPlazo"
                    LlenarPlazo(strTipoProducto, strCasoEspecial)
                Case "LlenarServicioCampanaDTH"
                    LlenarServicioCampanaDTH(strPlan, strPlazo)
                Case "LlenarKitDTH"
                    LlenarKitDTH(strPlazo, strCampana)
                Case "LlenarPlanPaq3Play"
                    LlenarPlanPaq3Play(strPaquete)
                Case "LlenarPlazoCampanaDTH"
                    LlenarPlazoCampanaDTH(strTipoProducto, strCasoEspecial, strOficina, intTraerCampanasDTH)
                Case "LlenarPlanDTH"
                    LlenarPlanDTH(strOferta, strCampana)
                Case "LlenarPlazoServicioDTH"
                    LlenarPlazoServicioDTH(strPlan)
                Case "LlenarSolucion"
                    LlenarSolucion(strPlazo)
                Case "LlenarPaquete3Play"
                    LlenarPaquete3Play(strSolucion)
                Case "LlenarCuota"
                    LlenarCuota(strTipoDocumento, strPlan, strPlazo, strRiesgo, strCasoEspecial)
                Case "ValidarNroPortabilidad"
                    ValidarNroPortabilidad(strNroPorta)
                Case "ValidarSECRecurrente"
                    ValidarSECRecurrente(strTipoDocumento, strNroDocumento, strOferta, strCasoEspecial, strCadenaDetalle)
                Case "ValidarVendedorDNI"
                    ValidarVendedorDNI(strTipoDocumento)
                Case "ValidarTitularidad"
                    ConsultarTipoDocVenta(strTipoDocumento)
                    ValidarTitularidad(strNrolinea, strTipoDocumento, strNroDoc.Trim, strCanal)
                Case "LlenarCampanaPlazo" '20150901
                    LlenarCampanaPlazo(String.Empty, strOficina, strOferta, strTipoProducto, strCasoEspecial, strTipoModalidadVenta, strFlujoRenovacion, obj.IdTipoOperacion, strGrupoProducto, strMantenerPlan, strIdPlanVig, strCampanasNoVig) 'Modificacion Plan No Vigente
                Case "LlenarServicioMaterial" 'gaa20151106
                    LlenarServicioMaterial(strTipoProducto, strCasoEspecial, strPlan, strOrgVenta, _
                    strCentro, strOficina, strCampana, strPlanSap, strTipoOficina, strTipoProducto, _
                    obj.IdTipoOperacion, strTipoDocumento, obj.IdTipoVenta, strPlazo, strOferta)
                Case "LlenarFamiliaPlan" 'gaa20161020
                    strResultado = LlenarFamiliaPlan(strOferta, strTipoProducto, strTipoDocumento, strOficina, strPlazo, strCampana, strFlujoRenovacion, String.Empty, strMantenerPlan, strCodPlanNoVigente, strIdPlanVig, strplanDesNoVig, strGrupoProducto, obj.ModalidadVenta)
                    hidResultado.Value = strResultado
                Case "consultarCantidadLineas3G" 'ECM S8
                    strResultado = consultarCantidadLineas3G(strTipoDocumentos, strNroDoc)
                    hidResultado.Value = strResultado   'fin ECM s8 
            End Select

        Catch ex As Exception
            If Not strMetodo = "LlenarEquipoPrecio" Then
                hidMensaje.Value = ConfigurationSettings.AppSettings("constMsjErrorEvaluacion")
            Else
                hidMensaje.Value = ex.Message
            End If
            objLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR METODO " & strMetodo & ": " & ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    'PROY-24740
    '<!-- INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
    '<!-- INICIO MUC2016 -->
    Private Sub ValidarValoresWS(ByVal objAcuerdo As BEGestionAcuerdoWS, ByRef sDato As String)
        Dim sblDato As New StringBuilder(sDato)
        If objAcuerdo.acuerdoOrigen = String.Empty Or _
           objAcuerdo.acuerdoOrigen Is DBNull.Value Then
            sblDato.Append("| AcuerdoOrigen")
        End If

        If objAcuerdo.acuerdoFechaInicio = String.Empty Or _
           objAcuerdo.acuerdoFechaInicio Is DBNull.Value Then
            sblDato.Append("| Fecha Inicio")
        End If

        If objAcuerdo.acuerdoFechaFin = String.Empty Or _
           objAcuerdo.acuerdoFechaFin Is DBNull.Value Then
            sblDato.Append("| Fecha Fin")
        End If

        If objAcuerdo.descPlazoAcuerdo = String.Empty Or _
           objAcuerdo.descPlazoAcuerdo Is DBNull.Value Then
            sblDato.Append("| Plazo Acuerdo")
        End If

        sDato = sblDato.ToString()
    End Sub


    '<!-- FIN MUC2016 -->
    '<!-- FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->

    'PROY-24740
    Public Function LlenarPlan(ByVal strOferta As String, _
                            ByVal strTipoProducto As String, _
                            ByVal strTipoDocumento As String, _
                            ByVal strOficina As String, _
                            ByVal strPlazo As String, _
                            ByVal strCampana As String, _
                            ByVal strFlujo As String, _
                            ByVal strTipoOperacion As String, _
                            ByVal strMantenerPlan As String, _
                            ByVal strCodPlanNoVigente As String, _
                            ByVal strIdPlanVig As String, _
                            ByVal strplanDesNoVig As String, _
                            ByVal strGrupoProducto As String, _
                            ByVal IdFamiliaPlan As String) As String 'gaa20161027


        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strResultado As String = String.Empty
        Dim arrPlan As ArrayList
        Dim sParametros As New StringBuilder
        Try

            If (strTipoDocumento = ConfigurationSettings.AppSettings("TipoDocumentoRUC")) Then
                strTipoDocumento = Funciones.TipoRUC1020(nroDocumento)
            End If

If strGrupoProducto = "00" Then
                'gaa20161020
                'arrPlan = (New ConsumerNegocio).ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujo, strTipoOperacion)
                Dim strFxD As String = ConfigurationSettings.AppSettings("FamiliaPlanxDefecto")
                Dim strFamiliaPlanOferta As String = ConfigurationSettings.AppSettings("FamiliaPlanOferta")
                Dim strFamiliaPlanProducto As String = ConfigurationSettings.AppSettings("FamiliaPlanProducto")

                Dim strTipoOperacionBRMS As String = String.Empty
                If Not Session("TipoOperacionBRMS") Is Nothing Then
                    strTipoOperacionBRMS = Session("TipoOperacionBRMS")
                End If

                Dim strFlujoAlta As String = ConfigurationSettings.AppSettings("flujoAlta")

                If (strOferta = strFamiliaPlanOferta AndAlso strTipoProducto = strFamiliaPlanProducto AndAlso IdFamiliaPlan Is Nothing) Then
                    IdFamiliaPlan = strFxD
            Else
                    If IdFamiliaPlan Is Nothing Then
                        IdFamiliaPlan = String.Empty
                    End If
                End If

                'arrPlan = New ConsumerNegocio().ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujo, strTipoOperacion, IdFamiliaPlan)

                If strTipoOperacionBRMS = ConfigurationSettings.AppSettings("constFlujoRenov") OrElse strTipoOperacionBRMS.Length = 0 Then
                        'arrPlan = (New ConsumerNegocio).ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujo, strTipoOperacion)
                arrPlan = New ConsumerNegocio().ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujo, strTipoOperacion, IdFamiliaPlan)
            Else
                        'arrPlan = (New ConsumerNegocio).ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujoAlta, strTipoOperacionBRMS)
                        arrPlan = New ConsumerNegocio().ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujoAlta, strTipoOperacionBRMS, IdFamiliaPlan)
                End If
            'fin gaa20161020 - MRAF 
            Else
                    arrPlan = (New ConsumerNegocio).ListarPlanCombo(strGrupoProducto)
            End If

            For Each objPlan As Plan In arrPlan

                If strMantenerPlan = "N" Then
                    If strIdPlanVig = objPlan.PLANC_CODIGO Then
                        sParametros.AppendFormat("|{0}_", strIdPlanVig)
                        sParametros.AppendFormat("{0}_", objPlan.PLANN_CAR_FIJ.ToString)
                        sParametros.AppendFormat("{0}_", strIdPlanVig)
                        sParametros.AppendFormat("{0}_", objPlan.PLNN_TIPO_PLAN)
                        sParametros.AppendFormat("{0}_", String.Empty)
                        sParametros.AppendFormat("{0}_", objPlan.GPLNV_DESCRIPCION)
                        sParametros.AppendFormat("{0}_", objPlan.CODIGO_BSCS)
                        sParametros.AppendFormat("{0}", objPlan.TIPO_PRODUCTOS)
                        sParametros.AppendFormat(";{0}", strplanDesNoVig) 'objPlan.PLANV_DESCRIPCION
                    End If
                Else
                    sParametros.AppendFormat("|{0}_", objPlan.PLANC_CODIGO)
                    sParametros.AppendFormat("{0}_", objPlan.PLANN_CAR_FIJ.ToString)
                    sParametros.AppendFormat("{0}_", objPlan.PLANC_EQUI_SAP.ToString)
                    sParametros.AppendFormat("{0}_", objPlan.PLNN_TIPO_PLAN)
                    sParametros.AppendFormat("{0}_", String.Empty)
                    sParametros.AppendFormat("{0}_", objPlan.GPLNV_DESCRIPCION)
                    sParametros.AppendFormat("{0}_", objPlan.CODIGO_BSCS)
                    sParametros.AppendFormat("{0}", objPlan.TIPO_PRODUCTOS)
                    sParametros.AppendFormat(";{0}", objPlan.PLANV_DESCRIPCION)
                End If
            Next

            strResultado = sParametros.ToString()
        Catch ex As Exception
            strResultado = ""
            Throw
        End Try

        Return strResultado
    End Function
    'gaa20161027
    Private Function ListarFamilia(ByVal strModalidadVenta As String, _
                        ByVal strCampana As String) As String
        Dim sbFamilia As New System.Text.StringBuilder
        Dim lstItem As ArrayList = New ConsumerNegocio().ListarFamiliaPlan(strModalidadVenta, strCampana)

        For Each obj As ItemGenerico In lstItem
            sbFamilia.Append("|")
            sbFamilia.Append(obj.Codigo)
            sbFamilia.Append(";")
            sbFamilia.Append(obj.Descripcion)
        Next
        Return sbFamilia.ToString()
    End Function

    Public Function LlenarFamiliaPlan(ByVal strOferta As String, _
                        ByVal strTipoProducto As String, _
                        ByVal strTipoDocumento As String, _
                        ByVal strOficina As String, _
                        ByVal strPlazo As String, _
                        ByVal strCampana As String, _
                        ByVal strFlujo As String, _
                        ByVal strTipoOperacion As String, _
                        ByVal strMantenerPlan As String, _
                        ByVal strCodPlanNoVigente As String, _
                        ByVal strIdPlanVig As String, _
                        ByVal strplanDesNoVig As String, _
                        ByVal strGrupoProducto As String, _
                        ByVal strModalidadVenta As String) As String
        Dim sbFamilia As New System.Text.StringBuilder

        sbFamilia.Append(ListarFamilia(strModalidadVenta, strCampana))
        sbFamilia.Append("¬")
        sbFamilia.Append(LlenarPlan(strOferta, _
                         strTipoProducto, _
                         strTipoDocumento, _
                         strOficina, _
                         strPlazo, _
                         strCampana, _
                         strFlujo, _
                         strTipoOperacion, _
                         strMantenerPlan, _
                         strCodPlanNoVigente, _
                         strIdPlanVig, _
                         strplanDesNoVig, _
                         strGrupoProducto, _
                         Nothing))

        Return sbFamilia.ToString()
    End Function

    'PROY-24740
    Public Function LlenarMaterial(ByVal strCampana As String, _
                                ByVal strPlan As String, _
                                ByVal strOficina As String, _
                                ByVal strOrgVenta As String, _
                                ByVal strCentro As String, _
                                ByVal strTipoOficina As String, _
    ByVal strTipoProducto As String, _
    ByVal strTipoOperacion As String, _
    ByVal strTipoDocumento As String, _
    ByVal strTipoVenta As String, _
    ByVal strPlazo As String, _
    ByVal strTipoCliente As String) As String

        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strResultado As New StringBuilder
        Try
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}", nroDocumento, "INICIO CONSULTA SAP MATERIAL"))

            Dim input As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", CheckStr(strCampana), CheckStr(strPlan), CheckStr(strOficina), CheckStr(strOrgVenta), CheckStr(strCentro), CheckStr(strTipoOficina), CheckStr(strTipoProducto), CheckStr(strTipoOperacion), CheckStr(strTipoDocumento), CheckStr(strTipoVenta), CheckStr(strPlazo), CheckStr(strTipoCliente))

            objLog.Log_WriteLog(strArchivo, String.Format("{0} - Input --> {1}", nroDocumento, input))


            'Consulta Equipos Sap
            Dim sGrupoEquipo() = System.Configuration.ConfigurationSettings.AppSettings("consGrupoEquipo").Split(";"c)

            Dim oParPVU As BEParametroOficina = (New ConsultaMsSapNegocio).ConsultaParametrosOficina(strOficina, String.Empty)
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - departamento --> {1}", nroDocumento, oParPVU.CodigoRegion))

            'Inicio Servicios Adicionales Roaming
            Dim arrListaMaterialLP As New ArrayList            
            Dim sCanalPermitidoConsultaMatLP() As String = ConfigurationSettings.AppSettings("constCanalPermitidoConsultaMatLP").Split(","c)            
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - constCanalPermitidoConsultaMatLP --> {1}", nroDocumento, ConfigurationSettings.AppSettings("constCanalPermitidoConsultaMatLP")))

            If (EsCanalPermitido(strTipoOficina, sCanalPermitidoConsultaMatLP)) Then
                arrListaMaterialLP = (New BLConsulta).ConsultaListaPrecios(strTipoProducto, strTipoVenta, strTipoOficina, oParPVU.CodigoRegion, "", strCampana, strTipoOperacion, strPlazo, strPlan)                
                objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrListaMaterialLP --> {1}", nroDocumento, arrListaMaterialLP.Count.ToString))
            End If

            'gaa20151106
            If Not ValidarAccesoOpcion(strTipoOficina, strTipoProducto, strTipoOperacion, strTipoDocumento, ConfigurationSettings.AppSettings("BloqueoEquipoSinStockCod")) Then
                oParPVU = (New ConsultaMsSapNegocio).ConsultaParametrosOficina(strOficina, String.Empty)


                Dim strX As String = String.Empty

                Dim arrStock As New ArrayList
                Dim booEquipoAltTieneStock As Boolean = False
                Dim arrResultado As New ArrayList
                'Saco materiales en stock validos
                Dim arrMaterial As ArrayList = (New BLConsultaMssap).ConsultaMaterialXOficina(strOficina, String.Empty, strCentro, "", "")
                For Each objMaterial As ItemGenerico In arrMaterial
                    For j As Integer = 0 To sGrupoEquipo.Length - 1
                        Dim sTipo As String = sGrupoEquipo(j)
                        If objMaterial.tipoMaterial = sTipo Then
                            If strX.IndexOf(objMaterial.Codigo) < 0 Then
                                strX = String.Format("&;{0}", objMaterial.Codigo)
                                arrStock.Add(objMaterial)
                            End If
                        End If
                    Next
                Next

                objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrStock --> {1}", nroDocumento, arrStock.Count.ToString))

                'Inicio Servicios Adicionales Roaming

                If (EsCanalPermitido(strTipoOficina, sCanalPermitidoConsultaMatLP)) Then
                    Dim arrStockConLP As New ArrayList

                    For Each oEquipoDisp As ItemGenerico In arrStock
                        Dim oBEItemGenerico As ItemGenerico
                        For Each oEquipoLP As ItemGenerico In arrListaMaterialLP

                            If oEquipoDisp.Codigo = oEquipoLP.Codigo2 Then
                                oBEItemGenerico = New ItemGenerico
                                oBEItemGenerico.Codigo = oEquipoLP.Codigo2
                                oBEItemGenerico.Descripcion = oEquipoDisp.Descripcion
                                arrStockConLP.Add(oBEItemGenerico)
                                Exit For
                            End If
                        Next
                    Next                    
                    objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrStockConLP --> {1}", nroDocumento, arrStockConLP.Count.ToString))
                    arrStock = arrStockConLP

                End If
                'Fin Servicios Adicionales Roaming

                If arrStock.Count > ConfigurationSettings.AppSettings("constStockMinimo") Then
                    For Each objMaterial As ItemGenerico In arrStock
                        strResultado.AppendFormat("|{0};{1}", objMaterial.Codigo, objMaterial.Descripcion)
                    Next
                Else
                    Dim arrEquiposAlt As ArrayList = (New BLConsulta).ConsultaEquiposAlternativos()

                    Dim strR As New StringBuilder

                    objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrEquiposAlt --> {1}", nroDocumento, arrEquiposAlt.Count.ToString))

                    'Inicio Servicios Adicionales Roaming
                    'Setear esta variable arrEquiposAlt
                    Dim arrEquiposAltConLP As New ArrayList
                    If (EsCanalPermitido(strTipoOficina, sCanalPermitidoConsultaMatLP)) Then

                        If (arrListaMaterialLP.Count > 0) Then
                            For Each objEA As ItemGenerico In arrEquiposAlt

                                Dim oBEItemGenerico As ItemGenerico
                                For Each objEquipoLP As ItemGenerico In arrListaMaterialLP
                                    If objEA.Codigo = objEquipoLP.Codigo2 Then

                                        oBEItemGenerico = New ItemGenerico
                                        oBEItemGenerico.Codigo = objEquipoLP.Codigo2
                                        oBEItemGenerico.Descripcion = objEA.Descripcion

                                        arrEquiposAltConLP.Add(oBEItemGenerico)
                                        Exit For
                                    End If
                                Next
                            Next

                        End If
                        arrEquiposAlt = arrEquiposAltConLP
                    End If


                    objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrEquiposAltConLP --> {1}", nroDocumento, arrEquiposAltConLP.Count.ToString))

                    For Each objEA As ItemGenerico In arrEquiposAlt
                        booEquipoAltTieneStock = False
                        For Each objMaterial As ItemGenerico In arrStock
                            If objMaterial.Codigo = objEA.Codigo Then
                                strR.AppendFormat(";{0}", objMaterial.Codigo)
                                arrResultado.Add(String.Format("{0}|{1}", objMaterial.Descripcion, objMaterial.Codigo))
                                booEquipoAltTieneStock = True
                                Exit For
                            End If
                        Next
                        If Not booEquipoAltTieneStock Then
                            strR.AppendFormat(";{0}", objEA.Codigo)
                            arrResultado.Add(String.Format("{0}|^{1}", objEA.Descripcion, objEA.Codigo))
                        End If
                    Next

                    For Each objMaterial As ItemGenerico In arrStock
                        If strR.ToString().IndexOf(objMaterial.Codigo) < 0 Then
                            arrResultado.Add(String.Format("{0}|{1}", objMaterial.Descripcion, objMaterial.Codigo))
                        End If
                    Next

                    arrResultado.Sort()
                    Dim str1() As String
                    For Each str As String In arrResultado
                        str1 = str.Split("|")
                        strResultado.AppendFormat("|{0};{1}", str1(1), str1(0))
                    Next
                End If
            Else
            'Inicio-dga-31072015
            Dim arrMaterial As ArrayList = (New BLConsultaMssap).ConsultaMaterialXOficina(strOficina, String.Empty, strCentro, "", "") 'mssap
                objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrMaterial --> {1}", nroDocumento, arrMaterial.Count.ToString))

                Dim oItem As New ItemGenerico
                Dim arrMaterialConStock As New ArrayList

                If (EsCanalPermitido(strTipoOficina, sCanalPermitidoConsultaMatLP)) Then
                    For Each oMatStock As ItemGenerico In arrMaterial
                        For Each oMatLP As ItemGenerico In arrListaMaterialLP
                            If (oMatStock.Codigo = oMatLP.Codigo2) Then
                                oItem = New ItemGenerico
                                oItem.Codigo = oMatStock.Codigo
                                oItem.Descripcion = oMatStock.Descripcion
                                arrMaterialConStock.Add(oItem)
                                Exit For
                            End If
                        Next
                    Next

                    arrMaterial = arrMaterialConStock
                                        
                    objLog.Log_WriteLog(strArchivo, String.Format("{0} - arrMaterialConStock --> {1}", nroDocumento, arrMaterialConStock.Count.ToString))
                End If

                

                'Dim sGrupoEquipo() = System.Configuration.ConfigurationSettings.AppSettings("consGrupoEquipo").Split(";"c)
            For Each objMaterial As ItemGenerico In arrMaterial
                For j As Integer = 0 To sGrupoEquipo.Length - 1
                    Dim sTipo As String = sGrupoEquipo(j)
                    If objMaterial.tipoMaterial = sTipo Then
                            strResultado.AppendFormat("|{0};{1}", objMaterial.Codigo, objMaterial.Descripcion)
                    End If
                Next
            Next
            End If
            'Fin-dga-31072015

            Dim strMostrarEquipoPromo As String = "N"
            If ValidarAccesoOpcion(strTipoOficina, strTipoProducto, strTipoOperacion, strTipoDocumento, ConfigurationSettings.AppSettings("BloqueoEquipoPromoCod")) Then
            Dim dtGama As DataTable = (New ConsumerNegocio).ObtenerEquipoGama()
            For Each dr As DataRow In dtGama.Rows
                If dr("eqgan_orden") = "1" Then
                        strResultado.Insert(0, String.Format("|{0};{1}", dr("eqgac_codigo"), dr("eqgav_descripcion")))
                Else
                        strResultado.AppendFormat("|{0};{1}", dr("eqgac_codigo"), dr("eqgav_descripcion"))
                End If
            Next
                strMostrarEquipoPromo = "S"
            End If

            Session("MostrarEquipoPromo") = strMostrarEquipoPromo
        Catch ex As Exception
            strResultado.Length = 0
            Throw
        Finally
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - {1}", nroDocumento, "FIN CONSULTA SAP MATERIAL")) 'PROY-24740-FAGP
        End Try

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarCampana(ByVal strPlan As String, _
                                    ByVal strPlazo As String, _
                                    ByVal strTipoDocumento As String, _
                                    ByVal strOficina As String, _
                                    ByVal strCasoEspecial As String, _
                                    ByVal strRiesgo As String) As String

        Dim strResultado As New StringBuilder
        Dim listaCampaniaCE As New ArrayList
        Dim listaNOCampanias As New ArrayList
        Dim listaCampaniaCuota As New ArrayList
        Dim listaCampaniaSap As New ArrayList
        Dim listaCampaniaSapTmp As New ArrayList
        Try
            Dim listaCampaniaSapTmp1 As ArrayList = (New SapGeneralNegocios).Get_ConsultaCampana_X_Plan(strPlan, Nothing)
            Dim oConsumer As New ConsumerNegocio

            Dim codCampañaX As String = ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodParamCampanaX")) 'MMR - CAMPAÑA X
            For Each objItem As ItemGenerico In listaCampaniaSapTmp1
                If objItem.Codigo <> codCampañaX Then 'MMR - CAMPAÑA X
                    listaCampaniaSapTmp.Add(objItem)
                End If 'MMR - CAMPAÑA X
            Next

            If (hidFlagVentaCuota.Value = "S") Then
                listaCampaniaCuota = oConsumer.ListarTipoItem(strCodParamCampanaxCuota)
                Dim strListaCampana As String = CType(listaCampaniaCuota(0), ItemGenerico).Descripcion

                For Each objItem As ItemGenerico In listaCampaniaSapTmp
                    If (strListaCampana.IndexOf(objItem.Codigo) > 0) Then
                        listaCampaniaSap.Add(objItem)
                    End If
                Next
            Else
                listaCampaniaSap = New ArrayList(listaCampaniaSapTmp)
            End If

            If Not strCasoEspecial = "" Then
                'Listar Campañas x Caso Especial
                listaCampaniaCE = oConsumer.ListarCampaniaCE(strCasoEspecial)

                For Each elemento As ItemGenerico In listaCampaniaSap
                    If searchCampana(listaCampaniaCE, elemento.Codigo) Then
                        strResultado.AppendFormat("|{0};{1}", elemento.Codigo, elemento.Descripcion)
                    End If
                Next
            End If

            If listaCampaniaCE.Count = 0 Then
                'Listar Campañas No visualizadas en el Punto de Venta
                listaNOCampanias = oConsumer.ListarNoMostrarCampania(strTipoDocumento, strRiesgo, strPlan, strPlazo, strOficina)

                For Each elemento As ItemGenerico In listaCampaniaSap
                    If Not searchCampana(listaNOCampanias, elemento.Codigo) Then
                        strResultado.AppendFormat("|{0};{1}", elemento.Codigo, elemento.Descripcion)
                    End If
                Next
            End If
        Catch ex As Exception
            strResultado.Length = 0
            Throw
        End Try

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarCampanaDTH(ByVal pstrPlazo As String, ByVal pstrPlan As String) As String
        Dim objConsumer As New ConsumerNegocio
        Dim arlTipoProducto As New ArrayList
        arlTipoProducto = objConsumer.ListarCampanaDTH(pstrPlazo, pstrPlan)
        Dim strResultado As New StringBuilder

        For Each item As AP_Campana In arlTipoProducto
            strResultado.AppendFormat("|{0}", item.CAMPV_CODIGO)
            strResultado.AppendFormat(";{0}", item.CAMPV_DESCRIPCION)
        Next
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarServicioDTH(ByVal pstrPlan As String) As String
        Dim objConsumer As New ConsumerNegocio
        Dim arlServicio As New ArrayList
        arlServicio = objConsumer.ListarServicioDTH(pstrPlan)
        Dim strResultado As New StringBuilder
        Dim alsPSNo As New ArrayList
        Dim alsPS As New ArrayList

        For Each item As SecServicio_AP In arlServicio
            If item.SELECCIONABLE_BASE.Length = 0 Then
                item.SELECCIONABLE_BASE = "0"
            End If

            If item.SELECCIONABLE_BASE = "1" Then
                item.SELECCIONABLE_BASE = "2"
            End If

            If Convert.ToInt32(item.SELECCIONABLE_BASE) > 0 Then
                item.SERVV_DESCRIPCION = String.Format("(*) {0}", item.SERVV_DESCRIPCION)
                alsPS.Add(item)
            Else
                alsPSNo.Add(item)
            End If
        Next

        For Each item As SecServicio_AP In alsPSNo
            strResultado.AppendFormat("|{0}_{1}_{2}_{3}_{4}_{5};{6}", item.SERVN_ORDEN.ToString, item.GSRVC_CODIGO, item.SELECCIONABLE_BASE, item.SERVV_CODIGO, item.CARGO_FIJO_BASE, item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
        Next
        strResultado.Append("¬")
        For Each item As SecServicio_AP In alsPS
            strResultado.AppendFormat("|{0}_{1}_{2}_{3}_{4}_{5};{6}", item.SERVN_ORDEN.ToString, item.GSRVC_CODIGO, item.SELECCIONABLE_BASE, item.SERVV_CODIGO, item.CARGO_FIJO_BASE, item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
        Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Sub LlenarServicioCampanaDTH(ByVal strPlan As String, _
                            ByVal strPlazo As String)
        Dim strResultado As New StringBuilder
        strResultado.Append(LlenarCampanaDTH(strPlazo, strPlan))
        strResultado.Append("~")
        strResultado.Append(LlenarServicioDTH(strPlan))
        hidResultado.Value = strResultado.ToString()
    End Sub

    Private Sub LlenarKitDTH(ByVal pstrPlazo As String, ByVal pstrCampana As String)
        hidResultado.Value = ListarKitDTH(pstrPlazo, pstrCampana)
    End Sub

    'PROY-24740
    Private Function ListarKitDTH(ByVal pstrPlazo As String, ByVal pstrCampana As String) As String
        Dim oConsumerNegocio As ConsumerNegocio
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("contTipOperaDTH_Alta")
        Dim strPlazo As String = pstrPlazo
        Dim strCampania As String = pstrCampana
        Dim strResultado As New StringBuilder
        Dim arlKit As New ArrayList
        Try
            oConsumerNegocio = New ConsumerNegocio
            arlKit = oConsumerNegocio.ConsultarListaKitsDTH(strTipoOperacion, strCampania, strPlazo)

            For Each objKit As SecKit_AP In arlKit
                strResultado.AppendFormat("|{0}_{1}_{2}_{3};{4}", objKit.KITV_CODIGO, objKit.TKITC_CODIGO, objKit.CARGO_FIJO_EN_SEC, objKit.KITN_COSTO_INST, objKit.KITV_DESCRIPCION)
            Next

            Return strResultado.ToString()
    
        Finally
            oConsumerNegocio = Nothing
            arlKit = Nothing
        End Try
    End Function

    Function searchCampana(ByVal listaCampanias As ArrayList, ByVal strCampana As String) As Boolean
        Dim blnFound As Boolean = False

        For Each item As ItemGenerico In listaCampanias
            If CheckStr(strCampana) = CheckStr(item.Codigo) Then
                blnFound = True
                Exit For
            End If
        Next

        Return blnFound
    End Function

    Public Sub LlenarMontoTopeConsumo(ByVal strPlan As String)
        Dim strResultado As String = String.Empty
        Try
            Dim arrTope As ArrayList = (New ConsumerNegocio).ListadoTopeAutomatico(strPlan)
            For Each item As TopeConsumo In arrTope
                strResultado = CheckStr(item.MONTO)
                Exit For
            Next
        Catch ex As Exception
            strResultado = ""
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        hidResultado.Value = strResultado
    End Sub

    Public Sub CambiarCasoEspecial(ByVal strOferta As String, ByVal strFlujo As String, _
                                    ByVal strTipoDocumento As String, _
                                    ByVal strNroDocumento As String, _
                                    ByVal strCasoEspecial As String, _
                                    ByVal strWhitellist As String, _
                                    ByVal strRiesgo As String)
        Dim blnWhitelistOK As String
        Dim listaCEPlanBscs As String
        Dim listaCEPlan As String
        Dim listaCERiesgo As String
        Dim dblCFMaximo As Double
        Dim strResultado As String = "{0}¬{1}"
        Dim strPlazo As String
        Dim strDatosCE As String
        Dim strTipoProd As String
        Try
            If Not strCasoEspecial = "" Then
                Dim oReglas As New ReglasEvaluacionNegocio
                If strWhitellist = "1" Then
                    blnWhitelistOK = oReglas.ConsultaBlackListCE(strCasoEspecial, strTipoDocumento, strNroDocumento, dblCFMaximo)
                End If
                oReglas.ObtenerCEReglas(strCasoEspecial, strRiesgo, listaCEPlanBscs, listaCEPlan, listaCERiesgo)
            End If

            strDatosCE = String.Format("{0}_{1}_{2}_{3}_{4}", blnWhitelistOK, dblCFMaximo, listaCEPlanBscs, listaCEPlan, listaCERiesgo)

            'Tipo Productos x Oferta Configurados
            If strWhitellist = "1" And Not blnWhitelistOK = "S" Then
                strTipoProd = LlenarTipoProductoxOferta(strOferta, strFlujo, strTipoDocumento, "")
            Else
                strTipoProd = LlenarTipoProductoxOferta(strOferta, strFlujo, strTipoDocumento, strCasoEspecial)
            End If

        Catch ex As Exception
            strResultado = ""
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        hidResultado.Value = String.Format(strResultado, strTipoProd, strDatosCE)
    End Sub

    'PROY-24740
    Public Sub ValidarBlacklistComision(ByVal strTipoDoc As String, _
                                        ByVal strNroDoc As String, _
                                        ByVal strPerfil149 As String, _
                                        ByVal strOficina As String, _
                                        ByVal strTipoOficina As String)
        Dim strResultado As String = String.Empty
        Dim strConsultaSap As String = String.Empty
        Try
            strResultado = (New ReglasEvaluacionNegocio).ConsultaClienteBlackList(strTipoDoc, strNroDoc)
            If Not strResultado = "S" Then
                strConsultaSap = ConsultarDatosSap(strPerfil149, strOficina, strTipoDoc, strTipoOficina)
            End If
        Catch ex As Exception
            strResultado = ""
            strConsultaSap = ""
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        hidResultado.Value = String.Format("{0}-{1}", strResultado, strConsultaSap)
    End Sub

    Public Function ConsultarDatosSap(ByVal strPerfil149 As String, ByVal strOficina As String, ByVal strTipoDoc As String, ByVal strTipoOficina As String) As String
        Dim objSapGeneral As New SapGeneralNegocios
        Dim dsOficina As New DataSet
        Dim dsTipoDocVenta As New DataSet
        Dim strCentro As String
        Dim strCanal As String
        Dim strOrgVenta As String
        Dim strTipoDocVenta As String
        Dim strGrupoCadena As String
        Dim strResultado As String = String.Empty
        Dim oConsultaMSSAP As New ConsultaMsSapNegocio
        Dim oPar As BEParametroOficina
        Try
            'Consulta Tipo de Documentos de Venta
            'dsTipoDocVenta = objSapGeneral.ConsultarTipoDocumentoOfVenta(strOficina)
            Dim tipoDocVenta As String = ""
            Dim arrTipoDocVenta() As String 'PROY-31636
            'INI PROY-31636
            If AppSettings.Key_codigoDocMigratorios.IndexOf(strTipoDoc) > -1 Then
                arrTipoDocVenta = AppSettings.Key_ExpressTipoDocVentaPos.Split(CChar(","))
            Else
                arrTipoDocVenta = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & strTipoDoc).Split(CChar(","))
            End If
            'FIN PROY-31636
            'For Each tipoDocVentaTmp As String In arrTipoDocVenta
            '    For Each rowTmp As System.Data.DataRow In dsTipoDocVenta.Tables(0).Rows
            '        If CheckStr(rowTmp.Item("AUART")) = tipoDocVentaTmp Then
            '            strTipoDocVenta = tipoDocVentaTmp
            '            Exit For
            '        End If
            '    Next
            'Next
            strTipoDocVenta = arrTipoDocVenta(2)


            'Consulta Parametros General
            If strPerfil149 = "S" Then

                'dsOficina = objSapGeneral.ConsultarParametrosOfVenta(strOficina)
                'strCanal = CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
                'strOrgVenta = CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))
                'strCentro = CheckStr(dsOficina.Tables(0).Rows(0).Item("WERKS"))

                oPar = oConsultaMSSAP.ParametrosOficina(Funciones.CheckStr(strOficina))    'ParametrosOficinaVenta(oficina)
                Dim oParPVU As BEParametroOficina = oConsultaMSSAP.ConsultaParametrosOficina(Funciones.CheckStr(strOficina), "")

                'Dim dsOficina As DataSet = (New SapGeneralNegocios).ConsultarParametrosOfVenta(oUsuario.OficinaId)
                strCanal = oParPVU.canal  'CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
                strOrgVenta = Funciones.CheckStr(ConfigurationSettings.AppSettings("consOrgVentaSinergia"))  'CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))
                strCentro = oParPVU.codigoCentro 'CheckStr(dsOficina.Tables(0).Rows(0).Item("WERKS"))


                If strTipoOficina = ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") Then
                    strGrupoCadena = (New ConsumerNegocio).ConsultarGrupoCadenaSISACT(strOficina)
                    If strGrupoCadena = "" Then
                        strGrupoCadena = (New ConsumerNegocio).ConsultarGrupoCadena(strOficina)
                    End If
                End If

            End If

            strResultado = String.Format("{0}|{1}|{2}|{3}|{4}", strTipoDocVenta, strCanal, strOrgVenta, strCentro, strGrupoCadena)

        Catch ex As Exception
            strResultado = ""
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        Return strResultado
    End Function
    'gaa20160321 - MRAF
    Private Function ObtenerValorAptoBRMS(ByVal strValor As String) As String
        Return strValor.Replace(" ", "_").ToUpper()
    End Function

    Private Sub ObtenerDatosBRMS(ByVal pstrTipoCliente As String)
        Session("TipoOperacionBRMS") = Nothing
        Session("PenalidadBRMS") = String.Empty
        If pstrTipoCliente <> ConfigurationSettings.AppSettings("constTipoProductoCON") Then Exit Sub

        If pstrTipoCliente = ConfigurationSettings.AppSettings("constTipoProductoCON") Then
            pstrTipoCliente = ConfigurationSettings.AppSettings("consTipoOfertaCons")
            'ElseIf pstrTipoCliente = ConfigurationSettings.AppSettings("constCodTipoProductoB2E") Then
            '    pstrTipoCliente = ConfigurationSettings.AppSettings("consTipoOfertaB2E")
        End If
        Dim strNroLinea As String = Session("nroLinea")
        Dim datosBrms As New BEConsultaBrms
        Dim intCoId As Integer = Convert.ToInt32(Session("intCoId"))
        Dim EstadoAcuerdo As String = Nothing
        Dim SegmentoCliente As String = Nothing
        Dim PeriodoContrato As String = Nothing
        Dim CampaniaActual As String = Nothing
        Dim PlanActual As String = Nothing
        Dim PagoCuotas As String = Nothing
        Dim DiasPendientes As String = Nothing
        Dim DiasPermanencia As String = Nothing
        'Recuperando Bloqueo
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intDiasBloqueo As Integer = Convert.ToInt32(ConfigurationSettings.AppSettings("intBrmsDiasBloqueo"))
        Dim strTipoBloqueo As String = ConfigurationSettings.AppSettings("strBrmsTipoBloqueo")
        Dim intBloqueo As Integer
        Dim intDiasAntiguedad As Integer
        Dim strCampanaActual As String
        Dim intComportamientoPago As Integer
        Dim intCodRpta As Int64
        Dim strDesRpta As String

        Try
            objConsumerNegocio = New ConsumerNegocio
            objConsumerNegocio.ListarBloqueo(strNroLinea, intDiasBloqueo, strTipoBloqueo, intBloqueo, _
                intDiasAntiguedad, strCampanaActual, intComportamientoPago, intCodRpta, strDesRpta)
            Response.Write("Codigo Respuesta:" & intCodRpta & System.Environment.NewLine & "Descripcion Respuesta:" & strDesRpta)
        Catch ex As Exception
            Throw ex
            objLog.Log_WriteLog(strArchivo, strArchivo & "- Exception ListarBloqueo() Mensaje:" & ex.Message)
            Throw New Exception("Error al Consultar Estado del Bloqueo." & ex.Message)
        End Try
        'Recuperando Segmento
        'Dim objSegmento As ConsumerNegocio
        'Dim outCodError As String
        'Dim outDesError As String
        'Try
        '    objSegmento = New ConsumerNegocio
        '    objSegmento.ObtenerSegmento(strNroLinea, SegmentoCliente, outCodError, outDesError)
        '    Response.Write("Codigo Respuesta:" & outCodError & System.Environment.NewLine & "Descripcion Respuesta:" & outDesError)
        'Catch ex As Exception
        '    oLog.Log_WriteLog(strArchivo, strArchivo & "- Exception ObtenerSegmento() Mensaje:" & ex.Message)
        '    Throw New Exception("Error al Consultar Estado del Bloqueo." & ex.Message)
        'End Try
        ''Recuperando existencia de Cuota
        'Dim objCuota As ConsumerNegocio
        'Try
        '    objCuota = New ConsumerNegocio
        '    objSegmento.ObtenerPagoCuotas(strNroLinea, PagoCuotas, outCodError, outDesError)
        '    Response.Write("Codigo Respuesta:" & outCodError & System.Environment.NewLine & "Descripcion Respuesta:" & outDesError)
        'Catch ex As Exception
        '    oLog.Log_WriteLog(strArchivo, strArchivo & "- Exception ObtenerPagoCuotas() Mensaje:" & ex.Message)
        '    Throw New Exception("Error al Consultar Estado del Bloqueo." & ex.Message)
        'End Try
        datosBrms.TipoCliente = UCase(pstrTipoCliente)
        datosBrms.ComportamientoPago = intComportamientoPago.ToString
        datosBrms.Bloqueo = intBloqueo.ToString
        datosBrms.PlanActual = ObtenerValorAptoBRMS(Session("planComercial"))
        datosBrms.CampaniaActual = ObtenerValorAptoBRMS(strCampanaActual)
        datosBrms.AntiguedadLinea = intDiasAntiguedad.ToString

        'gaa20160307: Llamada al nuevo BRMS
        'Llamada para obtener las variables
        Dim intCodErr As Int64
        Dim strDesErr As String

        objConsumerNegocio = New ConsumerNegocio
        objConsumerNegocio.ListarDesCanalxVendedor(Session("CodVendedorSAP"), datosBrms.Canal, intCodErr, strDesErr)

        'EMMH I
        Dim strCanal As String = Session("Canal")
        Dim StrFlagCanalPvu As String = ConfigurationSettings.AppSettings("constConsultaCanalPvu")
        Dim strCanalDescripcion As String = ConfigurationSettings.AppSettings("constDescripcionCanal" + strCanal)

        If datosBrms.Canal.Length = 0 And StrFlagCanalPvu = "1" Then
            datosBrms.Canal = Trim(strCanalDescripcion)
        End If

        If datosBrms.Canal.Length = 0 Then
            hidMensaje.Value = ConfigurationSettings.AppSettings("constErrorSIApdv")
            Return
        End If
        'EMMH F
        'Fin Harcodeado
        objConsumerNegocio = New ConsumerNegocio
        objConsumerNegocio.ListarSegmentoModalidadCuota(strNroLinea, datosBrms.PagoCuotas, datosBrms.ModalidadVenta, datosBrms.SegmentoCliente, intCodErr, strDesErr)
        objConsumerNegocio = Nothing
        'Dim objGestionAcuerdoNegocio As New GestionAcuerdoNegocio
        'objGestionAcuerdoNegocio.ObtenerReintegroEquipo("0", intCoId.ToString, Date.Today.ToShortDateString, "0", _
        '    "0", strNroLinea, CurrentUser, datosBrms.DiasPermanencia, datosBrms.PeriodoContrato, datosBrms.EstadoAcuerdo, _
        '    datosBrms.DiasPendientes)
        Dim objAcuerdo As BEGestionAcuerdoWS = New BEGestionAcuerdoWS
        'gaa20161123
        objAcuerdo = Session("objAcuerdo")
        Dim strAcuerdoEstado As String = objAcuerdo.acuerdoEstado

        'If objAcuerdo.acuerdoVigenciaMeses = "0" Then
        If objAcuerdo.codPlazoAcuerdo = "0" Then
            strAcuerdoEstado = ConfigurationSettings.AppSettings("consEstadoAcuerdoLibre")
            objAcuerdo.acuerdoVigenciaMeses = ConfigurationSettings.AppSettings("acuerdoVigencia0")
        Else
            If strAcuerdoEstado = ConfigurationSettings.AppSettings("consEstadoAcuerdoCodVigente") Then
                strAcuerdoEstado = ConfigurationSettings.AppSettings("consEstadoAcuerdoVigente")
            Else
                strAcuerdoEstado = ConfigurationSettings.AppSettings("consEstadoAcuerdoNoVigente")
            End If

            Select Case objAcuerdo.codPlazoAcuerdo
                Case "4" : objAcuerdo.acuerdoVigenciaMeses = ConfigurationSettings.AppSettings("acuerdoVigencia12")
                Case "15" : objAcuerdo.acuerdoVigenciaMeses = ConfigurationSettings.AppSettings("acuerdoVigencia18")
                Case "16" : objAcuerdo.acuerdoVigenciaMeses = ConfigurationSettings.AppSettings("acuerdoVigencia24")
                Case Else
                    hidMensaje.Value = ConfigurationSettings.AppSettings("constErrorPlazoAcuerdoConf")
                    Return
            End Select
        End If

        'fin gaa20161123
        datosBrms.DiasPermanencia = DateTime.Today.Subtract(Convert.ToDateTime(objAcuerdo.acuerdoFechaInicio)).Days.ToString()
        datosBrms.PeriodoContrato = objAcuerdo.acuerdoVigenciaMeses
        datosBrms.EstadoAcuerdo = strAcuerdoEstado
        datosBrms.DiasPendientes = objAcuerdo.diasPendientes
        Session("datosBrms") = datosBrms
        Session("objAcuerdo") = Nothing
        Try
            'Obtener el tipo de operacion de la llamada al BRMS
            Dim objRenoDecisionNegocio As New RenovacionesDecisionNegocio
            Dim strResultado As String = String.Empty
            Dim strPenalidad As String = "S"
            Dim strMensaje As String = String.Empty
            'strResultado = objRenoDecisionNegocio.TraerTipoOperacion("3", "CONSUMER", 1, _
            '    "ACUERDO_LIBRE", "CLARO_CONEXION_99", 200, "CAC")
            objRenoDecisionNegocio.TraerTipoOperacion(datosBrms, strResultado, strPenalidad, strMensaje)
            'fin gaa20160307
            Dim strDatosLog As String = "DATOS_BRMS-->AntiguedadLinea:{0},Bloqueo:{1},Campana:{2},Canal:{3},ComportamientoPago:{4},DiasPendientes:{5},"
            strDatosLog &= "DiasPermanencia:{6},EstadoAcuerdo:{7},ModalidadVenta:{8},PagoCuotas:{9},PeriodoContrato:{10},Plan:{11},SegmentoCliente:{12}"
            strDatosLog &= "TipoCliente:{13},Linea:{14},CoId:{15},TipoOperacionResultado:{16},PenalidadResultado:{17},MensajeResultado:{18}"
            strDatosLog = String.Format(strDatosLog, datosBrms.AntiguedadLinea, datosBrms.Bloqueo, datosBrms.CampaniaActual, datosBrms.Canal, _
            datosBrms.ComportamientoPago, datosBrms.DiasPendientes, datosBrms.DiasPermanencia, datosBrms.EstadoAcuerdo, datosBrms.ModalidadVenta, _
            datosBrms.PagoCuotas, datosBrms.PeriodoContrato, datosBrms.PlanActual, datosBrms.SegmentoCliente, datosBrms.TipoCliente, strNroLinea, _
                intCoId, strResultado, strPenalidad, strMensaje)
            objLog.Log_WriteLog(strArchivo, strArchivo & strDatosLog)
            If strResultado.Length = 0 Then
                'strResultado = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")
                hidMensaje.Value = strMensaje
                Return
            Else
                hidInformativo.Value = strMensaje
            End If
            Session("TipoOperacionBRMS") = strResultado
            Session("PenalidadBRMS") = strPenalidad
        Catch ex As Exception
            hidMensaje.Value = CheckStr(ex.Message)
        End Try
    End Sub
    'fin gaa20160321 - MRAF
    Public Sub CambiarTipoOferta(ByVal pstrTipoCliente As String, ByVal pstrFlujo As String, ByVal pstrTipoDocumento As String, ByVal pstrTipoOficina As String)
        'gaa20160307  -MRAF
        ObtenerDatosBRMS(pstrTipoCliente)
        'fin gaa20160307
        'gaa20170714
        Dim strResultado As String = "{0}¬{1}¬{2}¬{3}"
        hidResultado.Value = String.Format(strResultado, _
            LlenarTipoProductoxOferta(pstrTipoCliente, pstrFlujo, pstrTipoDocumento, String.Empty), _
            LlenarCasoEspecial(pstrTipoCliente, pstrTipoDocumento, pstrTipoOficina), LlenarPlazo(String.Empty), _
            Session("PenalidadBRMS"))
        'fin gaa20170714
    End Sub

    'PROY-24740
    Public Function LlenarTipoProductoxOferta(ByVal strOferta As String, ByVal strFlujo As String, ByVal strTipoDocumento As String, ByVal strCasoEspecial As String) As String
        Dim objConsumer As New ConsumerNegocio
        Dim arrTipoProducto As New ArrayList
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strOficina As String = hidOficina.Value
        Dim strResultado As New StringBuilder

        'Tipo Documento RUC 10
        If strTipoDocumento = ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") Then
            If Not nroDocumento.Substring(0, 1) = ConfigurationSettings.AppSettings("constRUCInicio") Then
                strTipoDocumento = ConfigurationSettings.AppSettings("constTipoDocumentoRUC10")
            End If
        End If

        arrTipoProducto = objConsumer.ListarTipoProductoxOferta(strOferta, strFlujo, strCasoEspecial, strTipoDocumento, strOficina)
        For Each item As ItemGenerico In arrTipoProducto
            strResultado.AppendFormat("|{0};{1}", item.Codigo, item.Descripcion)
        Next

        Return IIf(strResultado.Length > 0, strResultado.ToString().Substring(1), strResultado.ToString())
    End Function

    'PROY-24740
    Public Function LlenarCasoEspecial(ByVal pstrTipoCliente As String, ByVal pstrTipoDocumento As String, ByVal pstrTipoOficina As String) As String
        Dim objConsumer As New ConsumerNegocio
        Dim strOferta As String = pstrTipoCliente
        Dim strTipoDocumento As String = pstrTipoDocumento
        Dim strOficina As String = pstrTipoOficina
        Dim arlCasoEspecial As New ArrayList
        arlCasoEspecial = objConsumer.ListarCasoEspecial(strOferta, strTipoDocumento, strOficina)
        Dim strResultado As New StringBuilder

        For Each item As CasoEspecial In arlCasoEspecial
            strResultado.AppendFormat("|{0};{1}", item.TCESC_DESCRIPCION2, item.TCESC_DESCRIPCION)
        Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarPlazo(ByVal pstrCasoEspecial As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlazo As New ArrayList

            arrPlazo = objConsumerNegocio.ListarPlazoAcuerdo(pstrCasoEspecial)
            For Each objPlazo As PlazoAcuerdo In arrPlazo
            strResultado.AppendFormat("|{0};{1}", objPlazo.PACUC_CODIGO, objPlazo.PACUV_DESCRIPCION)
            Next

        Return strResultado.ToString()
    End Function

    Public Sub LlenarPlazo(ByVal pstrTipoProducto As String, ByVal pstrCasoEspecial As String)
        Dim strResultado As String = String.Empty
        strResultado = ListarPlazo(pstrTipoProducto, pstrCasoEspecial)
        hidResultado.Value = strResultado
    End Sub

    'PROY-24740
    Private Function ListarPlazo(ByVal pstrTipoProducto As String, ByVal pstrCasoEspecial As String) As String
        Dim strResultado As New StringBuilder

        Dim strPlazoAcuerdo As String = String.Format("00,{0}", ConfigurationSettings.AppSettings("Seleccionar"))
        Dim confPlazoAcuerdo As String() = CheckStr(ConfigurationSettings.AppSettings("constPlazoAcuerdoConf")).Split(","c)
        Dim listaPlazoAcuerdo As ArrayList = (New MaestroNegocio).ListadoPlazoAcuerdo()
        For Each item As ItemGenerico In listaPlazoAcuerdo
            For i As Integer = 0 To confPlazoAcuerdo.Length - 1
                If confPlazoAcuerdo(i) = CheckStr(item.Codigo) Then
                    strResultado.AppendFormat("|{0};{1}", CheckStr(item.Codigo), CheckStr(item.Descripcion))
                End If
            Next
        Next
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarPaquete(ByVal strOferta As String, ByVal strTipoDocumento As String, ByVal strPlazo As String) As String
        Dim strResultado As New StringBuilder
        Try
            Dim arrPaquete As ArrayList = (New ConsumerNegocio).ListarPaqueteUni(strTipoDocumento, strOferta, strPlazo)
            For Each objPaquete As Paquete_AP In arrPaquete
                strResultado.AppendFormat("|{0};{1}", objPaquete.PAQTV_CODIGO, objPaquete.PAQTV_DESCRIPCION)
            Next
        Catch ex As Exception
            strResultado.Length = 0
            Throw
        End Try
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarServicio(ByVal pstrCasoEspecial As String, ByVal pstrPlan As String, ByVal pstrPlanSap As String) As String
        Dim strResultado As New StringBuilder

        If pstrPlan.Length > 0 Then
            Dim oConsultaSap As SapGeneralNegocios
            Dim oConsumer As ConsumerNegocio
            Dim alsPS1 As New ArrayList
            Dim alsPSR As New ArrayList
            Dim alsPSNo As New ArrayList
            Dim alsPS As New ArrayList

            Try
                oConsultaSap = New SapGeneralNegocios
                oConsumer = New ConsumerNegocio
                alsPS1 = oConsultaSap.Get_ConsultaPlanServicio(pstrPlanSap, String.Empty) 'SAP
                alsPSR = oConsumer.ListarPlanIndiRestServ(pstrPlan, pstrCasoEspecial) 'Restricciones SAP

                For Each item As Servicio_AP In alsPS1
                    For Each item1 As SecServicio_AP In alsPSR
                        If ITEM.SERVV_CODIGO = item1.SERVV_CODIGO Then
                            item.SELECCIONABLE_BASE = item1.SELECCIONABLE_BASE
                            item.TSERVC_CODIGO = String.Format("{0}_{1}_{2}_{3}_{4}", item.SERVN_ORDEN.ToString, item.GSRVC_CODIGO, item1.SELECCIONABLE_BASE, item.SERVV_CODIGO, item.CARGO_FIJO_BASE)
                        End If
                    Next
                Next

                For Each item As SecServicio_AP In alsPS1
                    If item.SELECCIONABLE_BASE.Length > 0 Then
                        If item.SELECCIONABLE_BASE <> "0" Then
                            If Convert.ToInt32(item.SELECCIONABLE_BASE) > 1 Then
                                item.SERVV_DESCRIPCION = String.Format("(*) {0}", item.SERVV_DESCRIPCION)
                                alsPS.Add(item)
                            Else
                                If Convert.ToInt32(item.SELECCIONABLE_BASE) > 0 Then
                                    alsPSNo.Add(item)
                                End If
                            End If
                        End If
                    Else
                        alsPSNo.Add(item)
                    End If
                Next

                For Each item As SecServicio_AP In alsPSNo

                    If item.SERVV_CODIGO = ConfigurationSettings.AppSettings("codServRoamingI") Then
                        If strFlagServicioRI = ConfigurationSettings.AppSettings("constFlagRIActivo") Then
                            strResultado.AppendFormat("|{0};{1}", item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
                        End If
                    Else
                        strResultado.AppendFormat("|{0};{1}", item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
                    End If
                Next
                strResultado.Append("¬")
                For Each item As SecServicio_AP In alsPS
                    strResultado.AppendFormat("|{0};{1}", item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
                Next

            Catch ex As Exception
                'Throw ex
            End Try
        End If

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarServicioCorp(ByVal pstrPaquete As String, ByVal pstrPlan As String, ByVal pintSecuencia As Integer, ByVal intFila As Integer) As String
        Dim strResultado As New StringBuilder

        If pstrPlan.Length > 0 Then
            Dim oConsumer As ConsumerNegocio
            Dim alsPS1 As New ArrayList
            Dim alsPSNo As New ArrayList
            Dim alsPS As New ArrayList

            Try
                oConsumer = New ConsumerNegocio
                alsPS1 = oConsumer.ListarServiciosXPaqPlan(pstrPaquete, pstrPlan, pintSecuencia)
                If alsPS1.Count = 0 Then
                    Dim oConsumerNegocio As New ConsumerNegocio
                    Dim mandt As String = ConfigurationSettings.AppSettings("ExpressMandt")
                    Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoProductoBusSAP")
                    alsPS1 = oConsumerNegocio.ConsultarListaServicios(pstrPlan, tipoCliente, mandt)
                End If

                For Each item As SecServicio_AP In alsPS1

                    If (CheckInt(item.SELECCIONABLE_EN_PAQUETE) And (SERVICIOS_SELECCIONABLE.OBLIGATORIO Or SERVICIOS_SELECCIONABLE.SELECCIONADO)) <> 0 Then
                        item.TSERVC_CODIGO = String.Format("{0}_{1}_2_{2}_{3}", item.SERVN_ORDEN.ToString, item.GSRVC_CODIGO, item.SERVV_CODIGO, item.CARGO_FIJO_EN_PAQUETE)

                        item.SERVV_DESCRIPCION = String.Format("(*) {0}", item.SERVV_DESCRIPCION)
                        alsPS.Add(item)
                    Else
                        item.TSERVC_CODIGO = String.Format("{0}_{1}_{2}_{3}_{4}", item.SERVN_ORDEN.ToString, item.GSRVC_CODIGO, item.SELECCIONABLE_BASE, item.SERVV_CODIGO, item.CARGO_FIJO_EN_PAQUETE)
                        alsPSNo.Add(item)
                    End If
                Next

                For Each item As SecServicio_AP In alsPSNo
                    strResultado.AppendFormat("|{0};{1}", item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
                Next
                strResultado.Append("¬")
                For Each item As SecServicio_AP In alsPS
                    strResultado.AppendFormat("|{0};{1}", item.TSERVC_CODIGO, item.SERVV_DESCRIPCION)
                Next

            Catch ex As Exception
                hidMensaje.Value = CheckStr(ex.Message)
                strResultado.Length = 0
            End Try
        End If

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Sub LlenarServicioCampana(ByVal strPlan As String, _
                                ByVal strPlazo As String, _
                                ByVal strTipoDocumento As String, _
                                ByVal strOficina As String, _
                                ByVal strCasoEspecial As String, _
                                ByVal strRiesgo As String, _
                                ByVal pstrPlanSap As String)
        Dim strResultado As New StringBuilder
        strResultado.Append(LlenarCampana(pstrPlanSap, strPlazo, strTipoDocumento, strOficina, strCasoEspecial, strRiesgo))
        strResultado.Append("~")
        strResultado.Append(LlenarServicio(strCasoEspecial, strPlan, pstrPlanSap))
        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Private Function LlenarServicioCampanaCorp(ByVal strPlan As String, _
                                    ByVal strPlazo As String, _
                                    ByVal strTipoDocumento As String, _
                                    ByVal strOficina As String, _
                                    ByVal strCasoEspecial As String, _
                                    ByVal strRiesgo As String, _
                                    ByVal strPlanSap As String, _
                                    ByVal strPaquete As String, _
                                    ByVal intSecuencia As Integer, _
                                    ByVal intIdFila As Integer) As String
        Dim strResultado As New StringBuilder
        strResultado.AppendFormat("°{0}!", intIdFila)
        strResultado.Append(LlenarCampana(strPlanSap, strPlazo, strTipoDocumento, strOficina, strCasoEspecial, strRiesgo))
        strResultado.Append("~")
        strResultado.Append(LlenarServicioCorp(strPaquete, strPlanSap, intSecuencia, -1))
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Function LlenarServicioCampanaCorpTotal(ByVal strTipoDocumento As String, _
                                    ByVal strOficina As String, _
                                    ByVal strCasoEspecial As String, _
                                    ByVal strRiesgo As String, _
                                    ByVal strPlanes As String)
        Dim strResultado As New StringBuilder
        Dim arrPlanes() As String = strPlanes.Split("|")
        For Each str As String In arrPlanes
            If str.Length > 0 Then
                Dim strElementos() As String = str.Split(",")

                strResultado.Append(LlenarServicioCampanaCorp(strElementos(0), strElementos(1), strTipoDocumento, strOficina, strCasoEspecial, strRiesgo, _
                    strElementos(3), strElementos(4), strElementos(5), strElementos(2)))
            End If
        Next

        hidResultado.Value = strResultado.ToString()
    End Function

    'PROY-24740
    Public Sub MostrarSecPendiente(ByVal strNroSec As String, ByVal pstrFlujo As String, ByVal pstrTipoDocumento As String, _
            ByVal pstrOficina As String, ByVal pstrRiesgo As String, ByVal pstrOrgVenta As String, ByVal pstrCentro As String, _
            ByVal pstrTipoDocVentaSap As String, ByVal pstrCanalSap As String, ByVal pstrModalidadVenta As String)
        Dim strResultado As New StringBuilder

        If Not strNroSec = "" Then

            Dim Planes As New ArrayList
            Dim Servicios As New ArrayList
            Dim objConsumerNegocio As New ConsumerNegocio
            Dim strFlujo As String = String.Empty
            Dim intPrimero As Integer = 0
            Dim sngTotal As Single
            Dim strCuota As New StringBuilder
            Dim sngMontoCuotaIni As Single
            Dim sngMontoCuota As Single
            Dim strDdl As New StringBuilder
            Dim strId As String = String.Empty
            Dim strIdAnterior As String = String.Empty
            Dim strServicio As New StringBuilder
            Dim strCuotaActual As String = String.Empty
            Dim strGrupoPaquete As New StringBuilder
            Dim intCuota As Integer = 0
            Dim strOferta As String = String.Empty
            Dim strTipoProducto As String = String.Empty
            Dim strCasoEspecial As String = String.Empty
            Dim strPlanReal As String = String.Empty
            Dim strArrPlan() As String
            Dim strListaPrecioReal As String = String.Empty
            Dim strArrListaPrecio() As String
            Dim i As Integer = 1
            Dim strCuotaInicial As String = String.Empty
            Dim objSolicitudNegocio As SolicitudNegocios
            Dim arlPromociones As ArrayList
            Dim strPromociones As New StringBuilder
            Dim strAgrupaPaquete As String = String.Empty

            'Consultar Detalle de SEC Anterior
            objConsumerNegocio.ObtenerPlanesSolicitud(strNroSec, Planes, Servicios)

            If Not Planes Is Nothing Then
                'gaa20161027
                'strResultado = ValidarSecPendiente(Planes, Servicios, strPlanReal, strListaPrecioReal, pstrFlujo, pstrOficina, pstrTipoDocumento, pstrRiesgo, pstrOrgVenta, pstrCentro, pstrTipoDocVentaSap, pstrCanalSap, pstrModalidadVenta)
                strResultado.Append(ValidarSecPendiente(Planes, Servicios, strPlanReal, strListaPrecioReal, pstrFlujo, pstrOficina, pstrTipoDocumento, pstrRiesgo, pstrOrgVenta, pstrCentro, pstrTipoDocVentaSap, pstrCanalSap, pstrModalidadVenta))
                'fin gaa20161027
                If strResultado.Length = 0 Then

                    strArrPlan = strPlanReal.Split("|")
                    strArrListaPrecio = strListaPrecioReal.Split("|")

                    For Each plan As PlanDetalleVenta In Planes

                        If intPrimero = 0 Then
                            strOferta = plan.OFERTA
                            strTipoProducto = plan.TIPO_PRODUCTO
                            strCasoEspecial = plan.CASO_ESPECIAL
                            strResultado.Length = 0
                            strResultado.Append(String.Format("{0}¬{1}¬{2}", strOferta, "°strGrupoPaquete°", strCasoEspecial))

                            strFlujo = pstrFlujo

                            strOferta = plan.OFERTA
                            hidResultadoAux.Value = LlenarTipoProductoxOferta(strOferta, strFlujo, pstrTipoDocumento, strCasoEspecial)

                            If Not ComprobarCasoEspecial(strOferta, strCasoEspecial, pstrTipoDocumento, pstrOficina) Then
                                strResultado.Length = 0
                                Exit For
                            End If
                            strResultado.AppendFormat("¬{0}", ObtenerTipoProducto(strFlujo, strOferta))
                            strResultado.AppendFormat("¬{0}", ObtenerCasoEspecial(strOferta, pstrTipoDocumento, pstrOficina))
                            strResultado.AppendFormat("¬{0}", plan.TOPEN_CODIGO)
                            strResultado.AppendFormat("~")
                            intPrimero += 1
                        End If
                        strResultado.AppendFormat("¬{0}©{1}©{2}©{3}©", plan.SOPLN_ORDEN, plan.PACUC_CODIGO, plan.PACUV_DESCRIPCION, plan.PAQTV_CODIGO)
                        strResultado.AppendFormat("{0}©{1}©{2}©{3}©", plan.PAQTV_DESCRIPCION, strArrPlan(i), plan.PLANV_DESCRIPCION, plan.CARGO_FIJO_LIN)
                        strResultado.AppendFormat("{0}©{1}©{2}©{3}©", plan.TOPE_MONTO, plan.CAMPANA, plan.CAMPANA_DESC, plan.MATERIAL)
                        strResultado.AppendFormat("{0}©{1}©{2}", plan.MATERIAL_DESC, plan.PRECIO_VENTA, plan.TELEFONO)

                        sngMontoCuotaIni = Math.Round(plan.PRECIO_VENTA * plan.CUOTA_INICIAL / 100, 2)

                        intCuota = CheckInt(plan.CUOTA_CODIGO)
                        intCuota = IIf(intCuota > 0, intCuota, 1)

                        sngMontoCuota = Math.Round((plan.PRECIO_VENTA - sngMontoCuotaIni) / intCuota, 2)
                        strCuotaInicial = plan.CUOTA_INICIAL
                        strCuota.AppendFormat("|*ID{0}*{1}_{2};{3};{4};{5}*/ID{6}*", plan.SOPLN_ORDEN, plan.CUOTA_CODIGO, strCuotaInicial, strCuotaInicial, sngMontoCuotaIni.ToString, sngMontoCuota.ToString, plan.SOPLN_ORDEN)
                        If strDdl.ToString().IndexOf(String.Format("|{0}", plan.CUOTA_CODIGO)) < 0 Then
                            strDdl.AppendFormat("|{0}_{1};{2}", plan.CUOTA_CODIGO, strCuotaInicial, plan.CUOTA_DESCRIPCION)
                        End If
                        strResultado.AppendFormat("©{0}", strCuota.ToString())

                        If sngMontoCuotaIni > 0 Then
                            strCuotaActual = String.Format("{0}_{1}", plan.CUOTA_CODIGO, strCuotaInicial)
                        End If
                        strServicio.Length = 0
                        For Each servicio As SecServicio_AP In Servicios
                            If plan.SOPLN_CODIGO = servicio.SOPLN_CODIGO Then
                                strId = Funciones.CheckStr(plan.SOPLN_ORDEN)
                                If strIdAnterior <> strId Then strServicio.AppendFormat("*ID*{0}", plan.SOPLN_ORDEN)
                                If plan.PRDC_CODIGO <> ConfigurationSettings.AppSettings("consTipoProducto3Play") Then
                                    If servicio.CARGO_FIJO_EN_PAQUETE > 0 Then
                                        strServicio.AppendFormat("|0___{0}_{1};{2}", servicio.SERVV_CODIGO, servicio.CARGO_FIJO_EN_PAQUETE, servicio.SERVV_DESCRIPCION)
                                    Else
                                        strServicio.AppendFormat("|0___{0}_{1}_{2};{3}", servicio.SERVV_CODIGO, servicio.CARGO_FIJO_BASE, servicio.TSERVC_CODIGO, servicio.SERVV_DESCRIPCION)
                                    End If
                                Else
                                    strServicio.AppendFormat("|___{0}.{1}.{2}_{6}___{3}__1_0_0__{4}_;{5}", servicio.IDDET, servicio.IDPRODUCTO, servicio.IDLINEA, servicio.PLSVN_CODIGO, servicio.SERVV_CODIGO, servicio.SERVV_DESCRIPCION, servicio.CARGO_FIJO_BASE)
                                End If

                                strIdAnterior = strId
                            End If
                        Next

                        strResultado.AppendFormat("©{0}", strArrListaPrecio(i))
                        strResultado.AppendFormat("©{0}©{1}©{2}©{3}©{4}©{5}©{6}", plan.TIPO_PRODUCTO, plan.PRDV_DESCRIPCION, plan.ID_SOLUCION, plan.SOLUCION, plan.CARGO_FIJO, plan.PRECIO_VENTA, plan.SOLIN_CODIGO)


                        strResultado.AppendFormat("©{0}", strServicio.ToString())

                        If plan.SOPLV_PAQU_AGRU <> "0" Then
                            If strGrupoPaquete.ToString().IndexOf(plan.SOPLV_PAQU_AGRU) < 0 Then
                                strGrupoPaquete.Append(plan.SOPLV_PAQU_AGRU)
                            End If
                        End If

                        objSolicitudNegocio = New SolicitudNegocios
                        arlPromociones = New ArrayList
                        arlPromociones = objSolicitudNegocio.ListarPromociones(plan.SOPLN_SECUENCIA)
                        strIdAnterior = String.Empty
                        strPromociones.Length = 0
                        For Each promocion As ItemGenerico In arlPromociones
                            If plan.SOPLN_CODIGO = promocion.Codigo2 Then
                                strId = Funciones.CheckStr(plan.SOPLN_ORDEN)
                                If strIdAnterior <> strId Then strPromociones.AppendFormat("*ID*{0}", plan.SOPLN_ORDEN)
                                strPromociones.AppendFormat("|0___{0}.{1}.{2}.{3}_0;{4}", plan.IDDET, plan.IDPRODUCTO, plan.IDLINEA, promocion.Codigo, promocion.Descripcion)
                                strIdAnterior = strId
                            End If
                        Next
                        strResultado.AppendFormat("©{0}", strPromociones.ToString())
                        'gaa20161027
                        strResultado.AppendFormat("©|{0};{1}" , plan.FAMILIA_PLAN , plan.FAMILIA_PLAN_DES)
                        'fin gaa20161027
                        i += 1

                        If plan.PRDC_CODIGO = ConfigurationSettings.AppSettings("consTipoProducto3Play") Then
                            Dim arrDireccion As ArrayList = (New SolicitudNegocios).ConsultarSolDireccion(plan.SOLIN_CODIGO)
                            For Each item As DireccionCliente In arrDireccion
                                If item.IdTipoDireccion = "I" Then
                                    Session(String.Format("oDireccionHFC_{0}", plan.SOPLN_ORDEN)) = item
                                End If
                            Next
                        End If
                        If plan.PRDC_CODIGO = ConfigurationSettings.AppSettings("CodTipoProductoDTH") Then
                            Dim arrDireccion As ArrayList = (New SolicitudNegocios).ConsultarSolDireccion(plan.SOLIN_CODIGO)
                            For Each item As DireccionCliente In arrDireccion
                                If item.IdTipoDireccion = "I" Then
                                    Session(String.Format("oDireccionDTH_{0}", plan.SOPLN_ORDEN)) = item
                                End If
                            Next
                        End If
                    Next
                    strResultado = strResultado.Replace("°strGrupoPaquete°", strGrupoPaquete.ToString())
                Else
                    objLog.Log_WriteLog(strArchivo, String.Format("{0} - SEC Pendiente Nro {1}: {2}", hidNroDocumento.Value, strNroSec, strResultado.ToString()))
                End If
            End If
        End If

        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Public Function ValidarSecPendiente(ByVal arlPlanes As ArrayList, ByVal arlServicios As ArrayList, ByRef pstrPlanReal As String, _
            ByRef strListaPrecioReal As String, ByVal pstrFlujo As String, ByVal pstrOficina As String, _
            ByVal pstrTipoDocumento As String, ByVal pstrRiesgo As String, ByVal pstrOrgVenta As String, _
            ByVal pstrCentro As String, ByVal pstrTipoDocVentaSap As String, ByVal pstrCanalSap As String, ByVal pstrModalidadVenta As String) As String
        Dim strResultado As String = String.Empty
        Dim strFlujo As String = String.Empty
        Dim strPlazos As String = String.Empty
        Dim strPaquetes As String = String.Empty
        Dim strPlanes As String = String.Empty
        Dim strCampanas As String = String.Empty
        Dim strEquipos As String = String.Empty
        Dim strServicios As String = String.Empty
        Dim strCuotas As String = String.Empty
        Dim strPlazo As String = String.Empty
        Dim strPaquete As String = String.Empty
        Dim strPlan As String = String.Empty
        Dim strCampana As String = String.Empty
        Dim strEquipo As String = String.Empty
        Dim strServicio As String = String.Empty
        Dim strCuota As String = String.Empty
        Dim intPrimero As Integer = 0
        Dim strOferta As String = String.Empty
        Dim strTipoProducto As String = String.Empty
        Dim strCasoEspecial As String = String.Empty
        Dim strArrPlanes() As String
        Dim strArrPlan() As String
        Dim strPlanSap As String = String.Empty
        Dim intSecuencia As Long = 0
        Dim strEquipoPrecio As String = String.Empty
        Dim intSecuenciaAct As Long = 0
        Dim strCuotaPorc As Integer = 0
        Dim strCodPuntoVenta As String = pstrOficina
        Dim strArrCuotas() As String
        Dim booCuotaExiste As Boolean = False
        'gaa20161027
        Dim strFamilias As String = String.Empty
        Dim strFamiliaPlan As String = String.Empty
        'fin gaa20161027
        If Not arlPlanes Is Nothing Then
            For Each plan As PlanDetalleVenta In arlPlanes
                strTipoProducto = plan.TIPO_PRODUCTO

                'Cliente con Deuda solo accede a Productos Fijos
                If hidFlgEvaluarMovil.Value = "N" Then
                    If Not (strTipoProducto = strCodTipoProductoFijo Or strTipoProducto = strCodTipoProducto3Play) Then
                        strResultado = String.Format("Cliente con Deuda y tiene productos distintos a Fijo.")
                        Return strResultado
                    End If
                End If

                If intPrimero = 0 Then
                    strFlujo = pstrFlujo

                    strOferta = plan.OFERTA
                    strCasoEspecial = plan.CASO_ESPECIAL

                    If CheckStr(strCasoEspecial) <> "" Then
                        strResultado = String.Format("No recuperar información cuando es CE.")
                        Return strResultado
                    End If
                    If plan.OFICINA <> strCodPuntoVenta Then
                        strResultado = String.Format("Las oficinas son diferentes.")
                        Return strResultado
                    End If

                    intPrimero += 1
                End If
                'Plazo
                strPlazo = CheckStr(plan.PACUC_CODIGO)
                strPlazos = LlenarPlazo1(strCasoEspecial)
                If strPlazos.IndexOf(String.Format("|{0}", strPlazo)) < 0 Then
                    strResultado = String.Format("No existe el plazo {0}.", plan.PACUV_DESCRIPCION)
                    Return strResultado
                End If
                'Paquete y plan
                strPaquete = CheckStr(plan.PAQTV_CODIGO)
                strPlan = CheckStr(plan.PLANC_CODIGO)
                If strPaquete.Length > 0 Then
                    If strTipoProducto <> strCodTipoProducto3Play Then
                        strPaquetes = LlenarPaquete(strOferta, pstrTipoDocumento, strPlazo)
                    Else
                        strPaquetes = ListarPaquete3Play(plan.ID_SOLUCION)
                        strPaquete = strPaquete.Split("_")(0)
                    End If
                    If strPaquetes.IndexOf(String.Format("|{0}", strPaquete)) < 0 Then
                        strResultado = String.Format("No existe el paquete {0}.", plan.PAQTV_DESCRIPCION)
                        Return strResultado
                    End If
                    If strTipoProducto <> strCodTipoProducto3Play Then
                        strPlanes = LlenarPlanPaq1(strPaquete)
                    Else
                        strPlan = CheckStr(String.Format("{0}.{1}.{2}", plan.IDDET, plan.IDPRODUCTO, plan.IDLINEA))
                        strPlanes = ListarPlan3Play(strPaquete)
                    End If
                Else
                    'gaa20161027
                    strFamiliaPlan = CheckStr(plan.FAMILIA_PLAN)
                    'strPlanes = LlenarPlan(strOferta, strTipoProducto, pstrTipoDocumento, pstrOficina, strPlazo, plan.CAMPANA, strFlujoRenovacion, String.Empty, "", "", "", "", "")
                    strPlanes = LlenarPlan(strOferta, strTipoProducto, pstrTipoDocumento, pstrOficina, strPlazo, plan.CAMPANA, strFlujoRenovacion, String.Empty, "", "", "", "", "", strFamiliaPlan)

                    If strFamiliaPlan.Length > 0 Then
                        strFamilias = ListarFamilia(pstrModalidadVenta, plan.CAMPANA)

                        If strFamilias.IndexOf("|" & strFamiliaPlan) < 0 Then
                            strResultado = String.Format("No existe la familia de plan {0}.", plan.FAMILIA_PLAN_DES)
                            Return strResultado
                        End If
                    End If
                    'fin gaa20161027
                End If
                'Plan
                If strPlanes.IndexOf(String.Format("|{0}", strPlan)) < 0 Then
                    strResultado = String.Format("No existe el plan {0}.", plan.PLANV_DESCRIPCION)
                    Return strResultado
                Else
                    strArrPlanes = strPlanes.Split("|")
                    Dim sblPlanReal As New StringBuilder
                    For Each str As String In strArrPlanes
                        If str.Length > 0 Then
                            strArrPlan = str.Split("_")
                            intSecuenciaAct = CheckInt(strArrPlan(4))
                            If strPlan = strArrPlan(0) AndAlso (plan.SOPLN_SECUENCIA = intSecuenciaAct OrElse strTipoProducto = strCodTipoProducto3Play) Then
                                strPlanSap = strArrPlan(2)
                                intSecuencia = intSecuenciaAct
                                sblPlanReal.AppendFormat("|{0}", str.Split(";")(0))
                            End If
                        End If
                    Next
                    pstrPlanReal = sblPlanReal.ToString()
                End If

                'Campana
                strCampana = CheckStr(plan.CAMPANA)
                If strCampana.Length > 0 Then

                    If strTipoProducto <> strCodTipoProductoDTH Then
                        strCampanas = LlenarCampana(strPlanSap, strPlazo, pstrTipoDocumento, pstrOficina, strCasoEspecial, pstrRiesgo)
                    Else
                        strCampanas = ListarCampanaDTH(pstrOficina)
                    End If
                    If strCampanas.IndexOf(String.Format("|{0}", strCampana)) < 0 Then
                        strResultado = String.Format("No existe la campaña {0}.", plan.CAMPANA_DESC)
                        Return strResultado
                    End If
                End If
                'Equipo
                strEquipo = CheckStr(plan.MATERIAL)
                If strEquipo.Length > 0 Then
                    If strTipoProducto <> strCodTipoProductoDTH Then
                        strEquipos = LlenarMaterial(strCampana, strPlanSap, pstrOficina, pstrOrgVenta, pstrCentro, plan.TIPO_OFICINA, strTipoProducto, ConfigurationSettings.AppSettings("constTipoOperacionREN").ToString(), strTipoDocumento, ConfigurationSettings.AppSettings("strTVPostpago").ToString(), strPlazo, strOferta)
                    Else
                        strEquipos = ListarKitDTH(strPlazo, strCampana)
                    End If
                    If strEquipos.IndexOf(String.Format("|{0}", strEquipo)) < 0 Then
                        strResultado = String.Format("No existe el equipo {0}.", plan.MATERIAL_DESC)
                        Return strResultado
                    Else
                        'Precio Equipo
                        If strTipoProducto <> strCodTipoProductoDTH Then
                            'strEquipoPrecio = LlenarEquipoPrecio(pstrOficina, strOferta, strPlazo, strPlanSap, strCampana, strEquipo, pstrCanalSap, pstrOrgVenta, pstrTipoDocVentaSap, CheckInt(plan.CUOTA_CODIGO))
                            If strEquipoPrecio.Length > 0 Then
                                strListaPrecioReal &= String.Format("|{0}", strEquipoPrecio)
                                strEquipoPrecio = strEquipoPrecio.Split("_")(0)
                                If plan.PRECIO_VENTA <> CheckDbl(strEquipoPrecio) Then
                                    strResultado = String.Format("El precio de equipo es diferente {0}.", strEquipoPrecio)
                                    Return strResultado
                                End If
                            Else
                                strResultado = String.Format("No hay precio de equipo.")
                                Return strResultado
                            End If
                        Else
                            strListaPrecioReal &= String.Format("|{0}", plan.PRECIO_LISTA)
                            strEquipoPrecio = strEquipoPrecio.Split("_")(0)
                        End If
                    End If
                Else
                    strListaPrecioReal &= "|"
                    strEquipoPrecio = strEquipoPrecio.Split("_")(0)
                End If
                'Cuota
                strCuota = CheckStr(plan.CUOTA_CODIGO)
                strCuotaPorc = CheckInt(plan.CUOTA_INICIAL)
                If strCuota.Length > 0 Then
                    strCuotas = CheckStr(LlenarCuota1(strCasoEspecial, strPlan, strPlazo, pstrRiesgo, pstrTipoDocumento))
                    If strCuota <> "00" Then

                        booCuotaExiste = False
                        strArrCuotas = strCuotas.Split("|")
                        For Each cuota As String In strArrCuotas
                            If cuota.Length > 0 Then
                                If String.Format("{0}_{1}", strCuota, strCuotaPorc) = cuota.Split(";")(0) Then
                                    booCuotaExiste = True
                                    Exit For
                                End If
                            End If
                        Next
                        If Not booCuotaExiste Then
                            strResultado = String.Format("No existe la cuota {0}.", plan.CUOTA_DESCRIPCION)
                            Return strResultado
                        End If
                    End If
                End If
                'Servicio
                If Not arlServicios Is Nothing Then
                    If strPaquete.Length = 0 Then
                        If strTipoProducto <> strCodTipoProductoDTH Then
                            Try
                                strServicios = LlenarServicio1(strCasoEspecial, strPlan, strPlanSap)
                            Catch ex As Exception
                            End Try
                        Else
                            strServicios = LlenarServicioDTH(strPlan)
                        End If
                    Else
                        If strTipoProducto <> strCodTipoProducto3Play Then
                            strServicios = LlenarServicioCorp1(strPaquete, strPlan, intSecuencia)
                        Else
                            strServicios = strPlanes
                        End If
                    End If

                    For Each Servicio As SecServicio_AP In arlServicios
                        If plan.SOPLN_CODIGO = Servicio.SOPLN_CODIGO Then
                            If strTipoProducto <> strCodTipoProducto3Play Then
                                strServicio = Servicio.SERVV_CODIGO
                            Else
                                strServicio = String.Format("{0}.{1}.{2}", Servicio.IDDET, Servicio.IDPRODUCTO, Servicio.IDLINEA)
                            End If
                            If strTipoProducto = strCodTipoProductoDTH Then
                                If strServicios.IndexOf(String.Format("_{0}_", strServicio)) < 0 Then
                                    strResultado = String.Format("No existe el servicio {0}.", Servicio.SERVV_DESCRIPCION)
                                    Return strResultado
                                End If
                            Else
                                If strServicios.IndexOf(String.Format("|{0}", strServicio)) < 0 Then
                                    strResultado = String.Format("No existe el servicio {0}.", Servicio.SERVV_DESCRIPCION)
                                    Return strResultado
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End If
        Return strResultado
    End Function

    'PROY-24740
    Public Function LlenarPlazo1(ByVal pstrCasoEspecial As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlazo As New ArrayList

            arrPlazo = objConsumerNegocio.ListarPlazoAcuerdo(pstrCasoEspecial)
            For Each objPlazo As PlazoAcuerdo In arrPlazo
            strResultado.AppendFormat("|{0};{1}", objPlazo.PACUC_CODIGO, objPlazo.PACUV_DESCRIPCION)
            Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarPlanPaq1(ByVal pstrPaquete As String) As String
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlan As New ArrayList
        Dim strResultado As New StringBuilder

        Try
            arrPlan = objConsumerNegocio.ListarPlanesXPaquete(pstrPaquete)
            For Each objPlan As SecPlan_AP In arrPlan
                strResultado.AppendFormat("|{0}_{1}_{2}_{3}_{4}_{5}__;{6}", objPlan.PLNV_CODIGO, objPlan.CARGO_FIJO_EN_PAQUETE.ToString, objPlan.PLANC_EQUI_SAP.ToString, objPlan.PLNN_TIPO_PLAN.ToString, objPlan.PAQPN_SECUENCIA, objPlan.GPLNV_DESCRIPCION, objPlan.PLNV_DESCRIPCION)
            Next
        Catch ex As Exception
            strResultado.Length = 0
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarCuota1(ByVal pstrCasoEspecial As String, ByVal pstrPlan As String, ByVal pstrPlazo As String, _
            ByVal pstrRiesgo As String, ByVal pstrTipoDocumento As String) As String
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strRiesgo As String = pstrRiesgo
        Dim intNroPlanes As Integer = 1
        Dim strTipoDocumento As String = pstrTipoDocumento
        Dim strCasoEspecial As String = pstrCasoEspecial
        Dim arrCuota As New ArrayList
        Dim strResultado As New StringBuilder

            objConsumerNegocio = New ConsumerNegocio
            arrCuota = objConsumerNegocio.ListarCuota(strTipoDocumento, strRiesgo, pstrPlan, pstrPlazo, intNroPlanes, strCasoEspecial)

            For Each objItem As ItemGenerico In arrCuota
            strResultado.AppendFormat("|{0};{1}", objItem.Codigo2, objItem.Descripcion)
            Next
   
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarServicio1(ByVal pstrCasoEspecial As String, ByVal pstrPlan As String, ByVal pstrPlanSap As String) As String
        Dim strResultado As New StringBuilder
        If pstrPlan.Length > 0 Then
            Dim oConsultaSap As SapGeneralNegocios
            Dim oConsumer As ConsumerNegocio
            Dim alsPS1 As New ArrayList
            Dim alsPSR As New ArrayList

            Try
                oConsultaSap = New SapGeneralNegocios
                oConsumer = New ConsumerNegocio
                alsPS1 = oConsultaSap.Get_ConsultaPlanServicio(pstrPlanSap, String.Empty) 'SAP
                alsPSR = oConsumer.ListarPlanIndiRestServ(pstrPlan, pstrCasoEspecial) 'Restricciones SAP

                For Each item As Servicio_AP In alsPS1
                    For Each item1 As SecServicio_AP In alsPSR
                        If ITEM.SERVV_CODIGO = item1.SERVV_CODIGO Then
                            item.SELECCIONABLE_BASE = item1.SELECCIONABLE_BASE
                        End If
                    Next
                Next

                For Each item As SecServicio_AP In alsPS1
                    If item.SELECCIONABLE_BASE <> "0" Then
                        strResultado.AppendFormat("|{0}", item.SERVV_CODIGO)
                    End If
                Next

            Catch ex As Exception
            Finally
                oConsultaSap = Nothing
                oConsumer = Nothing
            End Try
        End If

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function LlenarServicioCorp1(ByVal pstrPaquete As String, ByVal pstrPlan As String, ByVal pintSecuencia As Integer) As String
        Dim strResultado As New StringBuilder
        If pstrPlan.Length > 0 Then
            Dim oConsumer As ConsumerNegocio
            Dim alsPS1 As New ArrayList

                oConsumer = New ConsumerNegocio
                alsPS1 = oConsumer.ListarServiciosXPaqPlan(pstrPaquete, pstrPlan, pintSecuencia)

                For Each item As SecServicio_AP In alsPS1

                    If (CheckInt(item.SELECCIONABLE_EN_PAQUETE) And (SERVICIOS_SELECCIONABLE.OBLIGATORIO Or SERVICIOS_SELECCIONABLE.SELECCIONADO)) <> 0 Then
                    strResultado.AppendFormat("|{0}", item.SERVV_CODIGO)
                    End If
                Next

        End If
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function ObtenerTipoProducto(ByVal pstrFlujo As String, ByVal pstrOferta As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumer As New ConsumerNegocio
        Dim strOferta As String = pstrOferta
        Dim strFlujo As String = pstrFlujo
        Dim arrTipoProducto As New ArrayList

            arrTipoProducto = objConsumer.ListarTipoProducto(strOferta, strFlujo)
            For Each objItem As ItemGenerico In arrTipoProducto
            strResultado.AppendFormat("|{0};{1}", objItem.Codigo, objItem.Descripcion)
            Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function ObtenerCasoEspecial(ByVal pstrOferta As String, ByVal pstrTipoDocumento As String, ByVal pstrOficina As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumer As New ConsumerNegocio
        Dim strOferta As String = pstrOferta
        Dim strTipoDocumento As String = pstrTipoDocumento
        Dim strOficina As String = pstrOficina
        Dim arrCasoEspecial As New ArrayList

            arrCasoEspecial = objConsumer.ListarCasoEspecial(strOferta, strTipoDocumento, strOficina)
            For Each objItem As CasoEspecial In arrCasoEspecial
            strResultado.AppendFormat("|{0};{1}", objItem.TCESC_DESCRIPCION2, objItem.TCESC_DESCRIPCION)
            Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function ComprobarCasoEspecial(ByVal pstrTipoCliente As String, ByVal pstrCasoEspecial As String, _
            ByVal pstrTipoDocumento As String, ByVal pstrOficina As String) As Boolean
        Dim objConsumer As New ConsumerNegocio
        Dim strOferta As String = pstrTipoCliente
        Dim strTipoDocumento As String = pstrTipoDocumento
        Dim strOficina As String = pstrOficina
        Dim arlCasoEspecial As New ArrayList
        Dim booResultado As Boolean = False
        arlCasoEspecial = objConsumer.ListarCasoEspecial(strOferta, strTipoDocumento, strOficina)

        If pstrCasoEspecial.Length > 0 Then
            For Each item As CasoEspecial In arlCasoEspecial
                If item.TCESC_CODIGO = pstrCasoEspecial Then
                    booResultado = True
                    Exit For
                End If
            Next
        Else
            booResultado = True
        End If

        Return booResultado
    End Function

    'PROY-24740
    Public Sub LlenarCuota(ByVal pstrTipoDocumento As String, ByVal pstrPlan As String, ByVal pstrPlazo As String, _
                            ByVal pstrRiesgo As String, ByVal pstrCasoEspecial As String)
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intNroPlanes As Integer = 1
        Dim arrCuota As New ArrayList
        Dim strResultado As New StringBuilder

        Try
            If Not pstrCasoEspecial = ConfigurationSettings.AppSettings("constCETrabajadoresCMA") Then
                objConsumerNegocio = New ConsumerNegocio
                arrCuota = objConsumerNegocio.ListarCuota(pstrTipoDocumento, pstrRiesgo, pstrPlan, pstrPlazo, intNroPlanes, pstrCasoEspecial)

                For Each objItem As ItemGenerico In arrCuota
                    strResultado.AppendFormat("|{0};{1}", objItem.Codigo2, objItem.Descripcion)
                Next
            Else
                strResultado.Append(ConfigurationSettings.AppSettings("constCuotaCETrabajadoresCMA"))
            End If
        Catch ex As Exception
            strResultado.Length = 0
            hidMensaje.Value = CheckStr(ex.Message)
        Finally
            objConsumerNegocio = Nothing
        End Try
        hidResultado.Value = strResultado.ToString()

    End Sub

    Public Function LlenarPlanPaq(ByVal pstrPaquete As String) As String
        hidResultado.Value = LlenarPlanPaq1(pstrPaquete)
    End Function

    'PROY-24740
    Public Sub LlenarPaquetePlan(ByVal strOferta As String, _
                            ByVal strTipoProducto As String, _
                            ByVal strTipoDocumento As String, _
                            ByVal strOficina As String, _
                            ByVal strPlazo As String, _
                            ByVal strFlujo As String, _
                            ByVal strCasoEspecial As String, _
                            ByVal strRiesgo As String, _
                            ByVal strNroDocumento As String, _
                            ByVal strFlujoRenovacion As String, _
                            ByVal strCampana As String, _
                            ByVal strTipoOperacion As String)  'gaa20170828

        Dim strDespacho As String = "1"
        Dim strResultado As New StringBuilder
        'gaa20170828
        If (strTipoDocumento = ConfigurationSettings.AppSettings("TipoDocumentoRUC")) Then strTipoDocumento = Funciones.TipoRUC1020(strNroDocumento)
        'fin gaa20170828
        Try
            If strTipoProducto = ConfigurationSettings.AppSettings("constTipoProductoMovil") Then
                Dim arrPaquete As ArrayList = (New ConsumerNegocio).ListarPaqueteUni(strTipoDocumento, strOferta, strPlazo)
                For Each objPaquete As Paquete_AP In arrPaquete
                    strResultado.AppendFormat("|{0};{1}", objPaquete.PAQTV_CODIGO, objPaquete.PAQTV_DESCRIPCION)
                Next
            End If
            strResultado.Append("¬")
            'gaa20170828
            'Dim arrPlan As ArrayList = (New ConsumerNegocio).ListarPlanTarifario(strOferta, strTipoProducto, strDespacho, strFlujo, strTipoDocumento, strOficina, strCasoEspecial, strPlazo, strRiesgo, ConfigurationSettings.AppSettings("FlagRenovPlanTarifario"))
            Dim arrPlan As ArrayList = (New ConsumerNegocio).ListarPlanTarifario(strTipoDocumento, strOferta, strTipoProducto, strPlazo, strOficina, strCampana, strFlujoRenovacion, strTipoOperacion, String.Empty)
            'fin gaa20170828
            For Each objPlan As Plan In arrPlan
                strResultado.AppendFormat("|{0}_{1}_{2}_{3}__{4}_{5};{6}", objPlan.PLANC_CODIGO, objPlan.PLANN_CAR_FIJ.ToString, objPlan.PLANC_EQUI_SAP.ToString, objPlan.PLNN_TIPO_PLAN, objPlan.GPLNV_DESCRIPCION, objPlan.CODIGO_BSCS, objPlan.PLANV_DESCRIPCION)
            Next
        Catch ex As Exception
            strResultado.Length = 0
            hidMensaje.Value = CheckStr(ex.Message)
        End Try

        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Public Sub LlenarPlanPaq3Play(ByVal pstrPaquete As String)
        Dim strResultado As New StringBuilder

        Try
            strResultado.Append(ListarPlan3Play(pstrPaquete))
            strResultado.Append("¬")
            strResultado.Append(LlenarPromocion3Play(pstrPaquete))
        Catch ex As Exception
            strResultado.Length = 0
            hidMensaje.Value = CheckStr(ex.Message)
        End Try
        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Public Function LlenarPromocion3Play(ByVal pstrPaquete As String) As String
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlan As New ArrayList
        Dim strResultado As New StringBuilder

        Try
            arrPlan = objConsumerNegocio.ListarPromocionesXPaquete3Play(pstrPaquete)
            For Each objPlan As SecPlan_AP In arrPlan
                strResultado.AppendFormat("|{0}.{1}.{2}.{3}_", objPlan.PLNV_CODIGO, objPlan.CAMP_CODIGO, objPlan.CAMP_DESCRIPCION, objPlan.PLNC_ESTADO) 'IDDET.IDPRODUCTO.IDLINEA.IDPROM
                strResultado.AppendFormat("{0}__", objPlan.PAQPN_SECUENCIA) 'PAQUETE
                strResultado.Append(objPlan.PLNN_TIPO_PLAN.ToString) 'FLGEDI
                strResultado.AppendFormat(";{0}", objPlan.PLNV_DESCRIPCION) 'DSCPROM
            Next
        Catch ex As Exception
            strResultado.Length = 0
            hidMensaje.Value = CheckStr(ex.Message)
            Throw
        Finally
            objConsumerNegocio = Nothing
        End Try
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function ListarSolucion3Play() As String
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strTipoServicio As String = ConfigurationSettings.AppSettings("constTipoServicio3Play")
        Dim intCodError As Integer
        Dim strMsgError As String
        Dim dtbResultado As New DataTable
        Dim strResultado As New StringBuilder

        Try
            objConsumerNegocio = New ConsumerNegocio
            dtbResultado = objConsumerNegocio.ListadoSolucion3Play(strTipoServicio, intCodError, strMsgError)

            For Each drw As DataRow In dtbResultado.Rows
                strResultado.AppendFormat("|{0};{1}", drw("IDSOLUCION"), drw("SOLUCION"))
            Next
        Finally
            objConsumerNegocio = Nothing
            dtbResultado = Nothing
        End Try

        Return strResultado.ToString()

    End Function

    'PROY-24740
    Public Function ListarPaquete3Play(ByVal plngIdSolucion As Int64) As String
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intCodError As Integer
        Dim strMsgError As String
        Dim dtbResultado As New DataTable
        Dim strResultado As New StringBuilder
        Dim strProductos As String
        Try
            objConsumerNegocio = New ConsumerNegocio
            dtbResultado = objConsumerNegocio.ListadoPaquete3Play(plngIdSolucion, intCodError, strMsgError)
            For Each drw As DataRow In dtbResultado.Rows
                strResultado.AppendFormat("|{0};{1}", drw("idpaq"), drw("OBSERVACION"))
            Next
        Finally
            objConsumerNegocio = Nothing
            dtbResultado = Nothing
        End Try
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Public Function ListarPlan3Play(ByVal pstrPaquete As String) As String
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlan As New ArrayList
        Dim strResultado As New StringBuilder

        Try
            arrPlan = objConsumerNegocio.ListarPlanesXPaquete3Play(pstrPaquete)
            For Each objPlan As ServicioHFC In arrPlan
                strResultado.AppendFormat("|{0}.{1}.{2}_{3}___{4}__{5}_{6}_{7}_{8}_{9}_{10};{11}", objPlan.IDDET, objPlan.IdProducto, objPlan.IdLinea, objPlan.CF_Precio.ToString, objPlan.Grupo, objPlan.FlagDefecto.ToString, objPlan.FlagPrincipal.ToString, objPlan.FlagOpcional.ToString, objPlan.Producto.ToString, objPlan.IdServicio.ToString, objPlan.FlagVOD, objPlan.Servicio)
            Next
        Finally
            objConsumerNegocio = Nothing
            arrPlan = Nothing
        End Try

        Return strResultado.ToString()
    End Function


    Private Sub LlenarCampanaDTH(ByVal pstrOficina As String)
        Dim strResultado As String = String.Empty
        strResultado = ListarCampanaDTH(pstrOficina)
        hidResultado.Value = strResultado
    End Sub

    'PROY-24740
    Private Function ListarCampanaDTH(ByVal pstrOficina As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumer As New ConsumerNegocio
        Dim arlTipoProducto As New ArrayList
        arlTipoProducto = objConsumer.ListarCampanaDTH1(pstrOficina)

        For Each item As AP_Campana In arlTipoProducto
            strResultado.AppendFormat("|{0};{1}", item.CAMPV_CODIGO, item.CAMPV_DESCRIPCION)
        Next
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Sub LlenarPlanDTH(ByVal pstrOferta As String, ByVal pstrCampana As String)
        Dim strResultado As New StringBuilder
        Dim objConsumer As New ConsumerNegocio

        Dim arrPlan As ArrayList = (New ConsumerNegocio).ListarPlanDTH(pstrOferta, pstrCampana)
        For Each objPlan As Plan In arrPlan
            strResultado.AppendFormat("|{0}_{1}_{2}_{3}__{4}_{5};{6}", objPlan.PLANC_CODIGO, objPlan.PLANN_CAR_FIJ.ToString, objPlan.PLANC_EQUI_SAP.ToString, objPlan.PLNN_TIPO_PLAN, objPlan.GPLNV_DESCRIPCION, objPlan.CODIGO_BSCS, objPlan.PLANV_DESCRIPCION)
        Next

        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Public Function LlenarPlazoDTH(ByVal pstrPlan As String) As String
        Dim strResultado As New StringBuilder
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim arrPlazo As New ArrayList

            arrPlazo = objConsumerNegocio.ListarPlazoDTH(pstrPlan)
            For Each objPlazo As PlazoAcuerdo In arrPlazo
            strResultado.AppendFormat("|{0};{1}", objPlazo.PACUC_CODIGO, objPlazo.PACUV_DESCRIPCION)
            Next

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Sub LlenarPlazoServicioDTH(ByVal pstrPlan As String)
        Dim strResultado As New StringBuilder
        strResultado.Append(LlenarPlazoDTH(pstrPlan))
        strResultado.Append("~")
        strResultado.Append(LlenarServicioDTH(pstrPlan))
        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Private Sub LlenarSolucion(ByVal strPlazo As String)
        Dim strResultado As New StringBuilder
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strTipoServicio As String = ConfigurationSettings.AppSettings("constTipoServicio3Play")
        Dim intCodError As Integer
        Dim strMsgError As String

        Try
            objConsumerNegocio = New ConsumerNegocio
            Dim dtb As New DataTable
            dtb = objConsumerNegocio.ListadoSolucion3Play(strTipoServicio, intCodError, strMsgError)

            For Each drw As DataRow In dtb.Rows
                strResultado.AppendFormat("|{0};{1}", drw("IDSOLUCION"), drw("SOLUCION"))
            Next
  
        Finally
            objConsumerNegocio = Nothing
        End Try

        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Private Sub LlenarPaquete3Play(ByVal intSolucion As Int64)
        Dim lngIdSolucion As Int64 = intSolucion
        Dim strResultado As New StringBuilder
        Dim intCodError As Integer
        Dim strMsgError As String
        Dim objConsumerNegocio As ConsumerNegocio
        Dim dtbLista As New DataTable
        Dim strProductos As String
        Try
            objConsumerNegocio = New ConsumerNegocio
            dtbLista = objConsumerNegocio.ListadoPaquete3Play(lngIdSolucion, intCodError, strMsgError)

            If Not dtbLista Is Nothing Then
                For Each drw As DataRow In dtbLista.Rows
                    strProductos = objConsumerNegocio.ConsultarProductoPaquete(drw("IDPAQ"))
                    strResultado.AppendFormat("|{0}_{1}_{2};{3}", drw("IDPAQ"), lngIdSolucion, strProductos, drw("OBSERVACION"))
                Next
            End If
            hidResultado.Value = strResultado.ToString()
    
        Finally
            dtbLista = Nothing
            objConsumerNegocio = Nothing
        End Try
    End Sub

    'PROY-24740
    Public Function ValidarNroPortabilidad(ByVal strNumero As String) As Boolean
        Dim mensajeOut As String
        Dim strResultado As String = "1"
        If (New NumeroPortabilidadNegocio).validarNumeroPortabilidad(strNumero, mensajeOut) Then
            strResultado = "0" 'Error
        End If
        hidResultado.Value = String.Format("{0}|{1}", strResultado, mensajeOut)
    End Function

    'PROY-24740
    Public Sub ValidarSECRecurrente(ByVal strTipoDocumento As String, ByVal strNroDocumento As String, _
                                    ByVal strOferta As String, ByVal strCasoEspecial As String, ByVal strCadenaDetalle As String)

        Dim strCadena As New StringBuilder
        Dim flgReingreso As String = String.Empty
        Dim arrCadenaDetalle As String() = strCadenaDetalle.Split("|")

        For Each item As String In arrCadenaDetalle
            If Not item = String.Empty Then
                Dim arrDetalle As String() = item.Split(";")
                Dim strSubsidio As String = CalificarSubsidio(CheckDbl(arrDetalle(7)), CheckDbl(arrDetalle(8)))
                strCadena.AppendFormat("|{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", arrDetalle(1), _
                                                                                   arrDetalle(2), _
                                                                                   arrDetalle(3), _
                                                                                   arrDetalle(4), _
                                                                                   arrDetalle(5), _
                                                                                   arrDetalle(11), _
                                                                                   arrDetalle(6), _
                                                                                   strSubsidio, _
                                                                                   arrDetalle(9), _
                                                                                   arrDetalle(10))
            End If
        Next

        Dim cantidad As Integer
        Dim arrCadena As String() = strCadena.ToString().Split("|")
        strCadena.Length = 0
        For Each item As String In arrCadena
            If Not item = "" Then
                If strCadena.ToString().IndexOf(item) = -1 Then
                    cantidad = 0
                    For Each item1 As String In arrCadena
                        If item = item1 Then
                            cantidad += 1
                        End If
                    Next
                    If strCadena.Length = 0 Then
                        strCadena.AppendFormat("{0};{1}", item, cantidad)
                    Else
                        strCadena.AppendFormat("|{0};{1}", item, cantidad)
                    End If
                End If
            End If
        Next

        strNroDocumento = Right(String.Format("00000000000000{0}", strNroDocumento), 16)
        hidResultado.Value = (New ConsumerNegocio).ValidarSECRecurrente(strTipoDocumento, strNroDocumento, strOferta, strCasoEspecial, strCadena.ToString(), flgReingreso)
        hidResultado.Value = String.Format("{0}|{1}", hidResultado.Value, flgReingreso)

    End Sub

    'PROY-24740
    Public Function ObtenerParametroGeneral(ByVal CodParametro As String) As String
        Dim listaParametros As New StringBuilder
        Dim arrayListaParametro As ArrayList = New ConsumerNegocio().ListarParametroGeneral(1)
        For Each oItem As ParametroConsumer In arrayListaParametro
            listaParametros.AppendFormat("{0};{1}|", oItem.PCONI_CODIGO, CheckStr(oItem.PCONV_VALOR))
        Next
        Dim valor As String
        Dim arrListaParametro As String() = listaParametros.ToString().Split("|")
        For Each item As String In arrListaParametro
            Dim parametro As String() = item.Split(";")
            If parametro(0) = CodParametro Then
                valor = parametro(1)
            End If
        Next
        Return valor
    End Function

    'PROY-24740
    Public Function CalificarSubsidio(ByVal dblPrecioLista As Double, ByVal dblPrecioVenta As Double) As String
        Dim dblFactor As Double
        Dim strCalificacion As String
        Dim dblFactorSubsidioMenor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMenor")))
        Dim dblFactorSubsidioMayor As Double = CheckDbl(ObtenerParametroGeneral(ConfigurationSettings.AppSettings("constCodFactorSubsidioMayor")))


        objLog.Log_WriteLog(strArchivo, String.Format("{0} - CalificarSubsidio dblPrecioVenta sisact_ifr_consulta_unificada.aspx {1}", hidNroDocumento.Value, dblPrecioVenta))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - CalificarSubsidio dblPrecioLista sisact_ifr_consulta_unificada.aspx {1}", hidNroDocumento.Value, dblPrecioLista))

        If dblPrecioVenta = 0 Then
            dblFactor = 0
        Else
            dblFactor = (dblPrecioLista - dblPrecioVenta) / dblPrecioVenta
            If dblFactor < 0 Then
                dblFactor = 0
            End If
        End If
        dblFactor = CheckDbl(dblFactor, 2)

        objLog.Log_WriteLog(strArchivo, String.Format("{0} - CalificarSubsidio dblFactor {1}", hidNroDocumento.Value, dblFactor))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - CalificarSubsidio dblFactorSubsidioMenor sisact_ifr_consulta_unificada.aspx {1}", hidNroDocumento.Value, dblFactorSubsidioMenor))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - CalificarSubsidio dblFactorSubsidioMayor  sisact_ifr_consulta_unificada.aspx {1}", hidNroDocumento.Value, dblFactorSubsidioMayor))

        If dblFactor < dblFactorSubsidioMenor Then
            strCalificacion = "BAJO"
        ElseIf dblFactor >= dblFactorSubsidioMenor And dblFactor < dblFactorSubsidioMayor Then
            strCalificacion = "MEDIO"
        ElseIf dblFactor >= dblFactorSubsidioMayor Then
            strCalificacion = "ALTO"
        End If
        Return strCalificacion
    End Function

    'PROY-24740
    Public Function ValidarVendedorDNI(ByVal strNroDocumento As String) As String
        Dim strResultado As String = String.Empty
        Dim objSolicitudNegocios As New SolicitudNegocios
        Try
            strResultado = objSolicitudNegocios.ValidarVendedorDNI(strNroDocumento)
        Catch
            strResultado = "ERROR|No es posible validar el vendedor... Intente nuevamente."
        Finally
            objSolicitudNegocios = Nothing
        End Try
        hidResultado.Value = strResultado
    End Function

    Public Sub LlenarPlazoCampanaDTH(ByVal strTipoProducto As String, ByVal strCasoEspecial As String, ByVal strOficina As String, ByVal intTraerCampanasDTH As String)
        Dim strResultado As String = String.Empty
        Dim strCampanasDTH As String = String.Empty
        If intTraerCampanasDTH = "0" Then
            strCampanasDTH = ListarCampanaDTH(strOficina)
        End If
        strResultado = String.Format("{0}¬{1}", ListarPlazo(strTipoProducto, strCasoEspecial), strCampanasDTH)
        hidResultado.Value = strResultado
    End Sub

    'PROY-24740
    Private Sub ConsultarTipoDocVenta(ByVal tipodoc As String)
        Dim dsClasePedido As New DataSet
        Dim oficina As String = hidOficina.Value
        Dim tipoDocCliente As String = tipodoc
        If Not hidOficina.Value.Equals(String.Empty) And Not tipodoc.Equals(String.Empty) Then
            Dim listaTipoDocVenta() As String 'PROY-31636
            'INI PROY-31636
            If AppSettings.Key_codigoDocMigratorios.IndexOf(tipodoc) > -1 Then
                listaTipoDocVenta = AppSettings.Key_ExpressTipoDocVentaPreRen.Split(CChar(","))
            Else
                listaTipoDocVenta = ConfigurationSettings.AppSettings(String.Format("ExpressTipoDocVentaPreRen{0}", tipoDocCliente)).Split(CChar(","))
            End If
            'FIN PROY-31636
            RegisterStartupScript("script", String.Format("<script>AsignarTipoDocVenta('{0}');</script>", listaTipoDocVenta(2)))
            dsClasePedido = Nothing
            listaTipoDocVenta = Nothing
        End If
    End Sub

    'PROY-24740
    Public Function ValidarTitularidad(ByVal nrolinea As String, ByVal tipodoc As String, ByVal nrodoc As String, ByVal strCanal As String) As String

        objLog.Log_WriteLog(strArchivo, nrolinea & " ---- INICIO VALIDAR TITULARIDAD ----")
        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim oVentaExpress As New VentaExpressNegocios

        Dim mensajeError As String = String.Empty
        Dim datosLinea As ClienteBSCS = Nothing
        Dim resp As Boolean = True
        Dim strConsumer As String = ConfigurationSettings.AppSettings("strPostTipClienteConsumer")
'gaa20160613
        Dim strB2E As String = ConfigurationSettings.AppSettings("strPostTipClienteB2E")
        Dim strBusiness As String = ConfigurationSettings.AppSettings("strPostTipClienteBusiness")
        Dim TipoClienteMASCORP As String = strConsumer 'ECM s8
'fin gaa20160613
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM strConsumer - " & strConsumer)
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM strB2E - " & strB2E)
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM strBusiness - " & strBusiness)
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM TipoClienteMASCORP - " & TipoClienteMASCORP)
        'INICIO WHZR 29092014

        Dim oConsumerNegocio As New ConsumerNegocio
        Dim DatosLineaWhitelist As DataTable

        'INICIO WHZR 04112014
        Dim acuerdoApadeceMontoReintegro As Double
        Dim acuerdoApadeceVigenciaMeses As String
        Dim acuerdoApadeceFechaInicio As String
        Dim acuerdoApadeceFechaFin As String
        Dim acuerdoApadeceCodPlazoAcuerdo As String
        Dim _indRenovacion As String
        Dim cfcalculo As String
        Dim indcf As Integer
        'FIN WHZR 04112014

        'inicio whzr 06112014
        Dim intCantidadVentas As Integer
        Dim intDias As Integer
        intDias = CheckInt(ConfigurationSettings.AppSettings("consCantidadDias"))
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM intDias - " & intDias)

        If intDias <> -1 Then
            If strCanal = ConfigurationSettings.AppSettings("constCodTipoDAC") Or strCanal = ConfigurationSettings.AppSettings("constCodTipoCRN") Or strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                intCantidadVentas = oVentaExpress.ObtenerCantidadVentas(nrodoc, nrolinea, intDias)
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM intCantidadVentas - " & intCantidadVentas)
                If intCantidadVentas > 0 Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("msgErrorValidarCantVentas")
                    resp = False
                    Me.hidResultado.Value = resp
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidMensaje - " & hidMensaje.Value)
                    Return False
                End If
            End If
        End If
        'fin whzr 06112014

        DatosLineaWhitelist = oConsumerNegocio.ObtenerNroLineaWhitelist(nrolinea, nrodoc)
       objLog.Log_WriteLog(strArchivo, strArchivo & "- Inicio DatosLineaWhitelist() --> NroLinea: " & nrolinea & ", nrodoc:" & nrodoc & ", CanalesPermitidos:" & ConfigurationSettings.AppSettings("constCanalesPermitidosWhitelist"))
        Dim sCanalesPermitidos() = ConfigurationSettings.AppSettings("constCanalesPermitidosWhitelist").Split(","c)
        If EsCanalPermitido(strCanal, sCanalesPermitidos) Then

            If DatosLineaWhitelist.Rows.Count = 0 Then
                hidMensaje.Value = ConfigurationSettings.AppSettings("consMensajeNroLineaWhitelist")
                resp = False
                Me.hidResultado.Value = resp
                Return False
            Else
                hidMontoRegistrado.Value = CheckStr(DatosLineaWhitelist.Rows(0).ItemArray(0))
            End If
        End If
        'FIN WHZR 29092014

        'jng
        Dim oVentaNegocios As New VentaNegocios
        Dim Msisdn As String = String.Format("51{0}", nrolinea.Trim())
        Dim strHLR As String = oVentaNegocios.ObtenerNroHLR(Msisdn)
        If strHLR <> String.Empty Then
            hidHlr.Value = Right(String.Format("00{0}", strHLR), 2)
        End If

        Dim oChipRespuestoPostpago As New ChipRepuestoPostpagoNegocio
        Dim intResutado As Int32

        Dim strMensaje As String = String.Empty
        intResutado = oChipRespuestoPostpago.ValidarPlanesLTG4G(nrolinea, strMensaje)
        If intResutado = 0 Then
            hidPl4G.Value = ConfigurationSettings.AppSettings("consTextoACTIVO4G").ToString
        Else
            hidPl4G.Value = ConfigurationSettings.AppSettings("consTextoDESACTIVO4G").ToString
        End If
        'jng
        objLog.Log_WriteLog(strArchivo, nrolinea & " PARAM hidPl4G - " & hidPl4G.Value)

        objLog.Log_WriteLog(strArchivo, String.Format("{0}- Inicio LeerDatosCliente() NroLinea -> {1}", nrolinea, nrolinea))
        datosLinea = oPostpagoNegocios.LeerDatosCliente(nrolinea, "", mensajeError)
        TipoClienteMASCORP = datosLinea.Tipo_cliente 'ECM s8 obtenido
        If mensajeError.Equals(String.Empty) Then
            objLog.Log_WriteLog(strArchivo, nrolinea & "- Fin LeerDatosCliente()  (output) -> mensaje: La Lectura de los datos del NroLinea " & nrolinea & " fue correcta")
        Else
            objLog.Log_WriteLog(strArchivo, nrolinea & "- Fin LeerDatosCliente()  (output) -> mensaje: Error al leer datos del NroLinea: " & nrolinea & " " & mensajeError)
        End If

        hidReintegro.Value = "0.00"


        If IsNothing(datosLinea) Then
            objLog.Log_WriteLog(strArchivo, nrolinea & "-  Datos Linea es vacio")
            hidMensaje.Value = "La línea no existe o no es Postpago."
            resp = False
            Return False
        Else
            'Valida APADECE
            Dim intMontoapadece As Int32
            Dim strTipoProducto As String
            Dim intCodError As Int32
            Dim strDesError As String
            'consolidado 11122014
            Dim mesesPorVencer As Integer
            Dim montoReintegro As Double
            'consolidado 11122014
            Dim objApacede As New AcuerdoApadece
            Dim indApadece As Integer 'jmori
            Dim strMensajeNSIGA As String = ""
            Dim strVigencia As Boolean
            Dim strLibre As String = ""
            Dim stcanal As String = ""
            Dim strchipsuelto As Boolean = True

            Dim strIdentifyLog As String
            Dim sMensaje As String

            Try

                'gaa20160609:BuscarPlanesEmpleado
                If UCase(datosLinea.Tipo_cliente) = UCase(strB2E) Then
                    If datosLinea.Tip_doc = ConfigurationSettings.AppSettings("constDescDocuRUC") Then
                        hidMensaje.Value = ConfigurationSettings.AppSettings("strMsgErrorTipoDocumento")
                        resp = False
                        Me.hidResultado.Value = resp
                        Return False
                    End If
                    Dim strCodPlan, strDesPlan As String
                    Dim intDias1 As Integer = ConfigurationSettings.AppSettings("intDiasRenoEmpleado")
                    Dim intCantidadVentas1 As Integer
                    Dim strPlanesEmpleado As String = ConfigurationSettings.AppSettings("strPlanesEmpleado")
                    Try
                        intCantidadVentas1 = oVentaExpress.ObtenerLineasVendidasPVU(nrodoc, nrolinea, intDias1)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "- ObtenerLineasVendidasPVU - " & intCantidadVentas1)
                        If intCantidadVentas1 > 0 Then
                            'Recupero el plan actual
                            oChipRespuestoPostpago = New ChipRepuestoPostpagoNegocio
                            oChipRespuestoPostpago.ListaServicios(datosLinea.Co_id, strCodPlan, strDesPlan)

                            If strPlanesEmpleado.IndexOf(String.Format(",{0},", strCodPlan)) > 0 Then
                                hidMensaje.Value = ConfigurationSettings.AppSettings("strMsgPlanEmpleadoMeses")
                                resp = False
                                Me.hidResultado.Value = resp
                                Return False
                            End If
                        End If
                    Catch ex As Exception
                        objLog.Log_WriteLog(strArchivo, nrolinea & "- Exception ValidarTitularidad:BuscarPlanesEmpleado" & ex.Message)
                    End Try
                End If
                'fin gaa20160609
                    Try

                        Dim estadoContrato As String
                        Dim estadoBloqueo As String
                    objLog.Log_WriteLog(strArchivo, nrolinea & "- Inicio ConsultaStatusContrato()")
                    objLog.Log_WriteLog(strArchivo, nrolinea & "- Canales Permitidos de la validacion contrato:" & ConfigurationSettings.AppSettings("constCanalesPermitidosValContract"))
                    Dim sCanalesPermitidosValContrato() As String = ConfigurationSettings.AppSettings("constCanalesPermitidosValContract").Split(","c)

                    If EsCanalPermitido(strCanal, sCanalesPermitidosValContrato) Then
                        objLog.Log_WriteLog(strArchivo, nrolinea & "- IN datosLinea.Co_id:" & datosLinea.Co_id)
                        Dim objVentaNegocios As VentaNegocios = New VentaNegocios

                        If (objVentaNegocios.ConsultaStatusContrato(datosLinea.Co_id, estadoContrato, estadoBloqueo)) Then
                            objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT estadoContrato:" & estadoContrato)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT estadoBloqueo:" & estadoBloqueo)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "- Estados no permitidos para renovar:" & ConfigurationSettings.AppSettings("constEstadosNoPermitidosContract"))
                            Dim sEstadosNoPermitidosValCont As String() = ConfigurationSettings.AppSettings("constEstadosNoPermitidosContract").Split(","c)

                            If EsValorPermitido(estadoContrato.ToUpper.Trim, sEstadosNoPermitidosValCont) Then
                                hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCACCliDeuda")
                                Return False
                            End If

                            'If (estadoContrato.ToUpper.Trim.Equals("D") = True) Then
                            '    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCACCliDeuda")
                            '    Return False
                            'End If

                            'If (estadoBloqueo.ToUpper.Trim.Equals("A") = True Or estadoBloqueo.ToUpper.Trim.Equals("O") = True) Then
                            '    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCACCliDeuda")
                            '    Return False
                            'End If

                        End If
                    End If


                    Catch ex As Exception
                    objLog.Log_WriteLog(strArchivo, nrolinea & "- Exception ConsultaStatusContrato() Mensaje:" & ex.Message)
                        Throw New Exception("Error al Consultar Estado del Contrato." & ex.Message)
                    Finally
                    objLog.Log_WriteLog(strArchivo, nrolinea & "- Fin ConsultaStatusContrato()")
                    End Try


                '<!-- INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
            '<!-- INICIO MUC2016 -->

                ' GESTION ACUERDO - WS.
            strIdentifyLog = hidNroLinea.Value + " " + String.Format("{0:dd-MM-yyyy hh:mm:ss}", DateTime.Now) + " | "

            Dim usuarioAplicacion As String = CurrentUser
            Dim wsMsisdn As String
            Dim coID As String
            Dim wsCargoFijo As String = ConfigurationSettings.AppSettings("WSGesAcuerdo_RenoAntiCargoFijo")
            Dim wsMotivoApadece As String = ConfigurationSettings.AppSettings("WSGesAcuerdo_RenoAntiMotivo")
            Dim wsFlagEquipo As String = ConfigurationSettings.AppSettings("WSGesAcuerdo_RenoAntiFlagEquipo")
            Dim wsFlagMsisdn As String = ConfigurationSettings.AppSettings("WS_RenoAntiFlagParametroMsisdn")

            Dim sFechaTrans As String

            sFechaTrans = Format(DateTime.Now, "dd/MM/yyyy") 'String.Format("{0:dd/MM/yyyy}", Now)

            If wsFlagMsisdn = 0 Then
                wsMsisdn = hidNroLinea.Value
                coID = ""
            Else
                wsMsisdn = ""
                coID = datosLinea.Co_id
            End If

                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "**************** Inicio Validacion WSGestionAcuerdo")
                objLog.Log_WriteLog(strArchivo, System.Environment.NewLine)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "Parametros de entrada:")
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- msisdn = " & wsMsisdn)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- coid = " & coID)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- Fecha Transaccion = " & sFechaTrans)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- CargoFijo = " & wsCargoFijo)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- MotivoApadece = " & wsMotivoApadece)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "- FlagEquipo = " & wsFlagEquipo)

                Dim objAcuerdo As BEGestionAcuerdoWS = New BEGestionAcuerdoWS
                Dim CodWS As Int32 = 0
                Dim MsgWS As String = ""
                objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : Iniciando Metodo ConsultarGestionAcuerdo")
                objAcuerdo = ConsultarGestionAcuerdo(usuarioAplicacion, wsMsisdn, coID, CodWS, MsgWS)
                objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : ConsultarGestionAcuerdo CodWS - Salida :" & CodWS)
                objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : ConsultarGestionAcuerdo MsgWS - Salida :" & MsgWS)
                If CodWS = 1 Then  ' ERROR WS.. 
                    hidMensaje.Value = String.Format(ConfigurationSettings.AppSettings("constRenoMenWSnoExisteAcuerdo"), wsMsisdn)
                    'hidMensaje.Value = ConfigurationSettings.AppSettings("constRenoMenWSnoExisteAcuerdo")
                    objLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No hay data " & Funciones.CheckStr(hidMensaje.Value))
                                    Return False
                                    End If

                If CodWS = 2 Then  ' ERROR WS.. 
                    hidMensaje.Value = String.Format(ConfigurationSettings.AppSettings("constRenoMenWSfueRangoAcuerdo"), wsMsisdn, Format(DateTime.Now, "yyyy"))
                    'hidMensaje.Value = ConfigurationSettings.AppSettings("constRenoMenWSfueRangoAcuerdo")
                    objLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No hay data " & Funciones.CheckStr(hidMensaje.Value))
                                        Return False
                                End If

                If CodWS = -1 Then  ' ERROR WS.. 
                    hidMensaje.Value = MsgWS
                    objLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No hay data " & Funciones.CheckStr(hidMensaje.Value))
                    Return False
                                    End If

                If CodWS = -2 Then  ' ERROR CONECTIVIDAD.
                    hidMensaje.Value = ConfigurationSettings.AppSettings("constRenoMenWSacceso")
                    objLog.Log_WriteLog(strArchivo, strIdentifyLog & "- Error " & Funciones.CheckStr(hidMensaje.Value))
                    Return False
                                End If

                Dim sDato As String = ""
                ValidarValoresWS(objAcuerdo, sDato)

                If sDato.Length > 0 Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("constRenoMenWSdato") & sDato
                    objLog.Log_WriteLog(strArchivo, strIdentifyLog & "- No hay data " & Funciones.CheckStr(hidMensaje.Value))
                    Return False
                        Else
                    Dim vLibre As Boolean = False
                    Dim vExito As Boolean = False
                    Dim nroMensaje As Int64 = 0
                    Dim mMessage As String = ""

                    Dim oVenta As VentaExpressNegocios = New VentaExpressNegocios

                    If strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : Iniciando Metodo WSValidaApadeceCAC ")
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC nrolinea - Input :" & nrolinea)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC strCanal - Input :" & strCanal)
                        oVenta.WSValidaApadeceCAC(objAcuerdo, vLibre, vExito, nrolinea, strCanal, CheckInt(MesesMaxAS), mMessage)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC vLibre - Salida :" & vLibre)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC vExito - Salida :" & vExito)
                    Else
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : Iniciando Metodo WSValidaApadece ")
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC nrolinea - Input :" & nrolinea)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadeceCAC strCanal - Input :" & strCanal)
                        oVenta.WSValidaApadece(objAcuerdo, vLibre, vExito, nrolinea, strCanal, CheckInt(MesesMaxAS), mMessage)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadece vLibre - Salida :" & vLibre)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WSValidaApadece vExito - Salida :" & vExito)
                        End If

                    If vExito = False Then
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : WvExito : false")
                        hidMensaje.Value = mMessage
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & strArchivo & "- Fecha de activacion: " & Funciones.CheckStr(datosLinea.Fecha_act))
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & strArchivo & "- Pasa bien nuevamente flujo de chip suelto")

                                indApadece = 1
                                hidMsgTitularidad.Value = ""
                        resp = False
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & strArchivo & "- No puedo renovar " & Funciones.CheckStr(hidMensaje.Value))
                            Return False
                    Else
                    hidFlagRenovacionAdelantada.Value = "false"
                    Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelMeses")
                        Dim tipo As String = ConfigurationSettings.AppSettings("constTipoCedeTelefono")
                        'Dim dtCede As DataTable = oVentaExpress.ConsultaDetalleAcuerdo(tipo, nrolinea)
                        'Dim tipoAcuerdoRen As String = ConfigurationSettings.AppSettings("constTipoAcuerdoRen")
                        'Dim tipoAcuerdoRep As String = ConfigurationSettings.AppSettings("constTipoAcuerdoRep")
                        'Dim tipoAcuerdoAct As String = ConfigurationSettings.AppSettings("constTipoAcuerdoAct")
                        Dim fchInicio As String = ""
                        Dim fchFin As String = ""

                        'COBS LIBRE.. NO CARGA DATOS.. Y PERMITE RENOVAR.. 
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : nrolinea :" & nrolinea)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoOrigen :" & objAcuerdo.acuerdoOrigen)
                        objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : vLibre :" & vLibre)
                        If objAcuerdo.acuerdoOrigen = "COBSDB" And vLibre = True Then
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoFechaInicio :" & objAcuerdo.acuerdoFechaInicio)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoFechaFin :" & objAcuerdo.acuerdoFechaFin)
                            fchInicio = String.Format(objAcuerdo.acuerdoFechaInicio, "dd/MM/yyyy")
                            hidFechaInicioApadece.Value = fchInicio
                        Else
                            objLog.Log_WriteLog(strArchivo, System.Environment.NewLine)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoFechaInicio :" & objAcuerdo.acuerdoFechaInicio)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoFechaFin :" & objAcuerdo.acuerdoFechaFin)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoMontoApacedeTotal :" & objAcuerdo.acuerdoMontoApacedeTotal)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.acuerdoVigenciaMeses :" & objAcuerdo.acuerdoVigenciaMeses)
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.codPlazoAcuerdo :" & CheckStr(objAcuerdo.codPlazoAcuerdo))
                            objLog.Log_WriteLog(strArchivo, nrolinea & "-" & "PROY-9067 : objAcuerdo.mesesPendientes :" & objAcuerdo.mesesPendientes)
                            resp = True
                            fchInicio = String.Format(objAcuerdo.acuerdoFechaInicio, "dd/MM/yyyy")
                            fchFin = String.Format(objAcuerdo.acuerdoFechaFin, "dd/MM/yyyy")
                        indApadece = -1
                        hidMsgTitularidad.Value = ""
                        hidMensaje.Value = ""

                            acuerdoApadeceMontoReintegro = Funciones.CheckDbl(objAcuerdo.acuerdoMontoApacedeTotal)
                            acuerdoApadeceVigenciaMeses = objAcuerdo.acuerdoVigenciaMeses
                        acuerdoApadeceFechaInicio = fchInicio
                            acuerdoApadeceFechaFin = fchFin
                        hidFechaInicioApadece.Value = fchInicio
                        'hidFechaFinApadece.Value = objApacede.FECHA_FIN.ToShort++mDateString()
                        hidFechaFinApadece.Value = fchFin
                            mesesPorVencer = objAcuerdo.mesesPendientes
                        acuerdoApadeceFechaFin = fchFin
                            hidPlazoAcuerdo.Value = CheckStr(objAcuerdo.codPlazoAcuerdo)
                            hidMesesPorVencer.Value = objAcuerdo.mesesPendientes
                        _indRenovacion = 1
                        hidMensaje.Value = ""
                    End If
                        ''
                        'gaa20170720: Cambio efectuado para que permita realizar renovaciones anticipadas a cualquier canal
                        'If strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then 'SI ES CAC.
                        If strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Or UCase(datosLinea.Tipo_cliente) = UCase(strConsumer) Then
                            objLog.Log_WriteLog(strArchivo, strArchivo & "- entra a ver si le pone reno adelantada")
                            'fin gaa20170720
                            'If objAcuerdo.acuerdoOrigen = "PVUDB" Then
                        If Convert.ToInt32(acuerdoApadeceVigenciaMeses) > 0 Then
                                objLog.Log_WriteLog(strArchivo, strArchivo & "-" & nrolinea & "***************** - Ingreso1 - **************")
                            'If flgapadece Then
                                objLog.Log_WriteLog(strArchivo, strArchivo & "-" & nrolinea & "***************** - Ingreso2 - **************")
                            hidFechaInicioApadece.Value = acuerdoApadeceFechaInicio
                            hidFechaFinApadece.Value = acuerdoApadeceFechaFin

                            If Convert.ToInt32(acuerdoApadeceVigenciaMeses) <= 0 Then
                                acuerdoApadeceMontoReintegro = 0
                            Else
                                hidFlagConfExoneracionReintegro.Value = "false"
                            End If

                            If acuerdoApadeceMontoReintegro > 0 Then
                                hidFlagReintegro.Value = "true"
                                hidReintegro.Value = Math.Round(acuerdoApadeceMontoReintegro, 2).ToString()
                            Else
                                hidFlagReintegro.Value = "false"
                                hidReintegro.Value = "0"
                            End If

                            If Convert.ToInt32(acuerdoApadeceVigenciaMeses) > 0 Then
                                Dim sPerfilAutoriza As String
                                Dim sPerfilCodigo As String
                                    'SD820360 - INICIO
                                    Dim sCodPerfil As String = String.Empty
                                Try
                                        objLog.Log_WriteLog(strArchivo, nrolinea & "- ObtenerPerfilPorMonto IN strTipo =>" & strTipo)
                                        objLog.Log_WriteLog(strArchivo, nrolinea & "- ObtenerPerfilPorMonto IN mesesPorVencer =>" & mesesPorVencer)
                                        Dim usuario As String = CurrentUser
                                        sCodPerfil = New NivelAprobacionNegocio().ValidarPerfilesMeses(usuario, "", nrolinea, Convert.ToInt32(mesesPorVencer))
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - ObtenerPerfilPorMonto RES =>" & sCodPerfil)
                                    Dim nMaxMesesDias As Int16 = CheckInt16(MesesMaxAS) * 30
                                    Dim nMesesPendientesARenovarDias As Int16 = CInt(DateDiff(DateInterval.Day, Date.Now, CDate(hidFechaFinApadece.Value)))
                                    hidDiasPendientes.Value = Funciones.CheckStr(nMesesPendientesARenovarDias)
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - nMesesPendientesARenovarDias=>" & nMesesPendientesARenovarDias.ToString)
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - nMaxMesesDias=>" & nMaxMesesDias.ToString)
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - Autoriza Si(1), No(-1)=> " & sCodPerfil)
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - Usuario=> " & usuario)
                                        If Not (sCodPerfil.Trim.Equals("-1")) Then
                                            hdAutoriza.Value = "1"
                                            objLog.Log_WriteLog(strArchivo, nrolinea & " - Autoriza=> SI")
                                        Else
                                            hdAutoriza.Value = "-1"
                                            objLog.Log_WriteLog(strArchivo, nrolinea & " - Autoriza=> NO")
                                    End If
                                        'SD820360 - FIN
                                Catch ex As Exception
                                    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoConsNivelAprobAPADECE")
                                        objLog.Log_WriteLog(strArchivo, nrolinea & " - Error Validar Perfiles- " & ex.Message)
                                    Return False
                                End Try
                            Else
                                hidFlagReintegro.Value = "false"
                                hidFlagRenovacionAdelantada.Value = "false"
                                _indRenovacion = 0
                            End If

                            Dim fact = DateTime.Now
                            Dim ffinapa = Convert.ToDateTime(acuerdoApadeceFechaFin)
                                objLog.Log_WriteLog(strArchivo, nrolinea & " - Exception fact" & CheckStr(fact))
                                objLog.Log_WriteLog(strArchivo, nrolinea & " - Exception acuerdoApadeceFechaFin" & CheckStr(ffinapa))
                            If ffinapa < fact Then
                                    objLog.Log_WriteLog(strArchivo, nrolinea & " - Exception ingreso final1111")
                                hidFlagRenovacionAdelantada.Value = "false"
                            Else
                                    objLog.Log_WriteLog(strArchivo, nrolinea & " - Exception ingreso final222222")
                                hidFlagRenovacionAdelantada.Value = "true"
                            End If

                        Else
                                objLog.Log_WriteLog(strArchivo, nrolinea & " - Fecha de activacion: " & Funciones.CheckStr(datosLinea.Fecha_act))
                                objLog.Log_WriteLog(strArchivo, nrolinea & " - Pasa bien nuevamente flujo de chip suelto")
                            If indApadece <> -1 Then
                                hidFlagReintegro.Value = "false"
                                hidFlagRenovacionAdelantada.Value = "false"
                                hidReintegro.Value = "0"
                                _indRenovacion = 0
                            End If
                    End If
                            'Else
                            '    If vExito = True Then
                            '        'pprrobando..

                            'End If
                            'End If

                    CalculaPermanencia(acuerdoApadeceFechaInicio, datosLinea.Fecha_act, _indRenovacion, DateTime.Now.ToShortDateString())

                        End If

                    End If '//FIN VEXITO
                    'gaa20161123
                    Session("objAcuerdo") = objAcuerdo
                    'fin gaa20161123
                End If

            Catch ex As Exception
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "**************** Error:" & "| " & sMensaje)
                'MENSAJE 09O
                hidMsgTitularidad.Value = ConfigurationSettings.AppSettings("msjErrorRevPoAPEDECE")
                objLog.Log_WriteLog(strArchivo, strArchivo & "-" & nrolinea & " - Exception ValidaTituralidad" & ex.Message & " " & ex.StackTrace)
                Return False
            Finally
                objLog.Log_WriteLog(strArchivo, System.Environment.NewLine)
                objLog.Log_WriteLog(strArchivo, strIdentifyLog & "| " & "**************** Fin WSGestionAcuerdo")
                objLog.Log_WriteLog(strArchivo, System.Environment.NewLine)

            End Try
            '<!-- FIN MUC2016 -->
            '<!-- FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->

            'Limite de Credito
            hidLimiteCred.Value = CheckStr(datosLinea.Limite_credito)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidLimiteCred: " & hidLimiteCred.Value)
            'Titular
            Dim apellidosClie As String = UCase(CheckStr(datosLinea.Apellidos))
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM apellidosClie: " & apellidosClie)
            Dim nombresClie As String = UCase(CheckStr(datosLinea.Nombre))
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM nombresClie: " & nombresClie)
            hidApellidosCli.Value = apellidosClie
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidApellidosCli: " & hidApellidosCli.Value)
            hidNombresCli.Value = nombresClie
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidNombresCli: " & hidNombresCli.Value)
            hidTitular.Value = UCase(CheckStr(nombresClie & " " & apellidosClie))
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidTitular: " & hidTitular.Value)
            'Correo
            hidCorreo.Value = datosLinea.Email
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidCorreo: " & hidCorreo.Value)
            'Fecha Nacimiento
            hidFechaNac.Value = datosLinea.Fecha_nac
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidFechaNac: " & hidFechaNac.Value)
            'Ciclo facturacion
            If Not IsNothing(datosLinea.Ciclo_fac) Then
                Me.hidCicloFac.Value = datosLinea.Ciclo_fac
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidCicloFac" & hidCicloFac.Value)
            End If
            'Representante legal
            If Not IsNothing(datosLinea.Rep_legal) Then
                Me.hidRepLegal.Value = datosLinea.Rep_legal
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidRepLegal: " & hidRepLegal.Value)
            End If

            'consolidado whzr 11122014
            'DATOS DE FACTURACIÓN

            Try
                objLog.Log_WriteLog(strArchivo, nrolinea & " - Inicio Datos de linea -")
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM COID: " & CheckStr(datosLinea.Co_id))
            hidPlanAct.Value = CheckStr(oPostpagoNegocios.obtenerIMSI(datosLinea.Co_id, mensajeError)).Split(";"c)(1)
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM Output mensajeError: " & mensajeError)
            Catch ex As Exception
                objLog.Log_WriteLog(strArchivo, nrolinea & " - " & "ERROR DATOS DE FACTURACIÓN " & ": " & ex.Message)
            End Try
            hidDireccion.Value = CheckStr(datosLinea.Direccion_fac)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidDireccion: " & hidDireccion.Value)
            hidDepartamento.Value = CheckStr(datosLinea.Departamento_fac)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidDepartamento: " & hidDepartamento.Value)
            hidProvincia.Value = CheckStr(datosLinea.Provincia_fac)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidProvincia: " & hidProvincia.Value)
            hidDistrito.Value = CheckStr(datosLinea.Distrito_fac)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidDistrito: " & hidDistrito.Value)
            'hidCorreoFact.Value = CheckStr(datosLinea.Email)
            hidTelefonoReferencia.Value = CheckStr(datosLinea.Telef_principal)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidTelefonoReferencia: " & hidTelefonoReferencia.Value)
            'hidLimiteCredito.Value = CheckStr(datosLinea.Limite_credito)
            hidIMSI.Value = CheckStr(oPostpagoNegocios.obtenerIMSI(datosLinea.Co_id, mensajeError)).Split(";"c)(0)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidIMSI: " & hidIMSI.Value)

            'consolidado 22012015
'gaa20160613
            'If strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") Then
            If strCanal = ConfigurationSettings.AppSettings("constCodTipoCAC") AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
'fin gaa20160613
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM strCanal: " & strCanal)
                Try

                    Dim ID_CCLUB As String
                    ID_CCLUB = getCCLUB(strTipoDocumento)
                    Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
                    Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - INICIO consultarPuntos - ")
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM Input ID_CCLUB: " & ID_CCLUB)
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM Input strNroDoc: " & strNroDoc)
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM Input CurrentUser: " & CurrentUser)
                    objConsultarPuntosResponse = objPuntosClaroClubNegocio.consultarPuntos(ID_CCLUB, _
                                                                                           strNroDoc, _
                                                                                           CurrentUser, "")
                    If objConsultarPuntosResponse.codigoSegmento.Trim <> "" Then
                        hidSegmento.Value = objConsultarPuntosResponse.codigoSegmento.Trim.ToUpper
                        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidSegmento: " & hidSegmento.Value)
                    Else
                        hidSegmento.Value = ""
                    End If
                    objLog.Log_WriteLog(strArchivo, nrolinea & " - FIN consultarPuntos - ")
                Catch ex As Exception

                    objLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR AL INVOCAR AL SEGMENTO " & ": " & ex.Message)

                End Try

            Else
                hidSegmento.Value = ""
                objLog.Log_WriteLog(strArchivo, nrolinea & " - FIN consultarPuntos - ")
            End If




            'consolidado 22012015
            'hidSegmento.Value = CheckStr(datosLinea.Credit_score)

            hidCustumerId.Value = CheckStr(datosLinea.CustomerId)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidCustumerId: " & hidCustumerId.Value)
            hidCuentaBSCS.Value = CheckStr(datosLinea.Cuenta)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidCuentaBSCS: " & hidCuentaBSCS.Value)
            hidCO.Value = CheckStr(datosLinea.Co_id)
            objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM hidCO" & hidCO.Value)
            'consolidado whzr 11122014

            'gaa20160115:Modificado para permitir B2E
            'If (UCase(datosLinea.Tipo_cliente) <> UCase(strConsumer)) Then
            'gaa20170823
            '        If UCase(datosLinea.Tipo_cliente) <> UCase(strConsumer) AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
            '            'gaa20160115:Modificado para poner mensaje mas generico
            '            'hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCliNoComsumer")
            '            hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCli")
            '            objLog.Log_WriteLog(strArchivo, strArchivo & "- 26")
            '            resp = False
            'return resp
            '        End If
            'fin gaa20170823

            'VALIDAR TITULARIDAD DE LA LINEA
            objLog.Log_WriteLog(strArchivo, nrolinea & " - Inicio VALIDAR TITULARIDAD DE LA LINEA -")
            If tipodoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM tipodoc: " & tipodoc)
                If nrodoc <> datosLinea.Ruc_dni.Trim Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaRUCCli")
                    resp = False
                End If

            ElseIf tipodoc = ConfigurationSettings.AppSettings("TipoDocumentoCE") Then
                If nrodoc <> datosLinea.Num_doc.Trim Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaCECli")
                    resp = False
                End If
            ElseIf (AppSettings.Key_codigoDocMigraYPasaporte.IndexOf(tipodoc) > -1) Then 'PROY-31636-RENTESEG
                If nrodoc <> datosLinea.Num_doc.Trim Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaCECli")
                    resp = False
                End If
            Else

                If nrodoc <> datosLinea.Num_doc.Trim Then
                    hidMensaje.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaDNICli")
                    resp = False
                End If

            End If
            objLog.Log_WriteLog(strArchivo, nrolinea & " - Fin VALIDAR TITULARIDAD DE LA LINEA -")
        End If

        'inicio plan no vigente 28102015
        objLog.Log_WriteLog(strArchivo, nrolinea & " - Inicio ObtenerPlanNoVigente -")
        Dim sCanalesPermitidosPlanNoVig() As String
        objLog.Log_WriteLog(strArchivo, nrolinea & " - Inicio validar canal permitido -")
        sCanalesPermitidosPlanNoVig = ConfigurationSettings.AppSettings("constCanalesPermitidosPlanNoVig").Split(","c)
        objLog.Log_WriteLog(strArchivo, nrolinea & " - PARAM strCanal: " & strCanal)
        If EsCanalPermitido(strCanal, sCanalesPermitidosPlanNoVig) Then
            objLog.Log_WriteLog(strArchivo, nrolinea & " - es canal permitido -")
            Dim codPlan As String = String.Empty
            Dim desPlan As String = String.Empty

            Dim strplanDesNoVig As String = String.Empty
            Dim strIdPlanVig As String = String.Empty
            Dim strplanDesVig As String = String.Empty
            Dim strIdPlanNoVig_Out As String = String.Empty
            Dim strCampanasPlan As String = String.Empty 'Modificacion Plan No Vigente

            Dim dsListaServicios As DataSet
            Try
                objLog.Log_WriteLog(strArchivo, nrolinea & "- Co_Id ListaServicios &" & CheckStr(datosLinea.Co_id))
                dsListaServicios = (New ChipRepuestoPostpagoNegocio).ListaServicios(datosLinea.Co_id, codPlan, desPlan)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- codPlan:" & codPlan)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- desPlan:" & desPlan)


                objLog.Log_WriteLog(strArchivo, nrolinea & "- Inicio ObtenerPlanNoVigente ")
                oVentaExpress.ObtenerPlanNoVigente(codPlan, strIdPlanNoVig_Out, strplanDesNoVig, strIdPlanVig, strplanDesVig, strCampanasPlan)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT strIdPlanNoVig_Out:" & strIdPlanNoVig_Out)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT strplanDesNoVig:" & strplanDesNoVig)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT strIdPlanVig:" & strIdPlanVig)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT strplanDesVig:" & strplanDesVig)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- OUT strCampanasPlan:" & strCampanasPlan)
                objLog.Log_WriteLog(strArchivo, nrolinea & "- Fin ObtenerPlanNoVigente ")

            If strIdPlanVig <> "" Then
                hidMensaje.Value = CheckStr(ConfigurationSettings.AppSettings("consMensajePlanNoVigente"))
                hidVigente.Value = CheckStr(ConfigurationSettings.AppSettings("consCodPlanNoVigente"))
                hidCodPlanNoVigente.Value = strIdPlanNoVig_Out
                hidplanDesNoVig.Value = strplanDesNoVig
                hidIdPlanVig.Value = strIdPlanVig
                    hidCampanasNoVig.Value = strCampanasPlan ' Modificacion Plan No Vigente
                resp = True
            Else
                    'hidMensaje.Value = CheckStr(ConfigurationSettings.AppSettings("consMensajePlanVigente"))
                hidVigente.Value = CheckStr(ConfigurationSettings.AppSettings("consCodPlanVigente"))
                hidCodPlanNoVigente.Value = ""
                hidIdPlanVig.Value = ""
                hidplanDesNoVig.Value = ""
                    hidCampanasNoVig.Value = ""
                resp = True
            End If
            Catch ex As Exception
                objLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & "-" & nrolinea & " - " & "ERROR AL LISTA SERVICIOS " & ": " & ex.Message)
            End Try

           
        End If
        'fin plan no vigente 28102015
        'gaa20160408 - MRAF
         Session("intCoId") = datosLinea.Co_id
        Session("Canal") = strCanal
        'fin gaa20160408
        'PROY-24724-IDEA-28174 - INICIO
        Dim sCanalesPermitidosPrimaSeguros() As String
        Dim codTipoClien As String
        Dim ms As String
        sCanalesPermitidosPrimaSeguros = ClsKeyAPP.strCanalesPermitidosProtMovil.Split(","c) ''PROY-24724-IDEA-28174 -Parametro
        hidValidadProtMovil.Value = ""
        If EsCanalPermitido(strCanal, sCanalesPermitidosPrimaSeguros) Then
            objLog.Log_WriteLog(strArchivo, nrolinea & "nrodoc: " & nrodoc & " - Inicio Flujo de Prima de Seguros")
            hidValidadProtMovil.Value = "2"
        End If
        'PROY-24724-IDEA-28174 - FIN 

        Me.hidResultado.Value = resp.ToString() & "|" & TipoClienteMASCORP  'ECM s8
        'Almacenar Datos del Cliente
        Session("Cliente") = datosLinea
        'gaa20160526
        If UCase(datosLinea.Tipo_cliente) = UCase(strB2E) Then
            hidOfertaLinea.Value = ConfigurationSettings.AppSettings("constCodTipoProductoB2E")
        ElseIf UCase(datosLinea.Tipo_cliente) = UCase(strBusiness) Then
            hidOfertaLinea.Value = ConfigurationSettings.AppSettings("constCodTipoProductoBUS")
        Else
            hidOfertaLinea.Value = String.Empty
        End If
        'fin gaa20160526
    End Function


    'consolidado 22012015


    ' Devuelve el còdigo equivalente al tipo de documento entre SISACT y PUNTOSCC
    Public Function getCCLUB(ByVal TipoDocumento As String) As String
        Dim ID_CCLUB As String
        Dim TipoDocumentos() As String = strTipoDocumentos.Split("|"c)
        Dim hstTipoDocumentos As New Hashtable

        For Each item As String In TipoDocumentos
            Dim vItem() As String = item.Split("="c)
            hstTipoDocumentos.Add(vItem(0), vItem(1))
        Next item
        ID_CCLUB = hstTipoDocumentos.Item(TipoDocumento)

        Return ID_CCLUB
    End Function


    'consolidado 22012015



    'inicio whzr 04112014
    Private Function CalculaPermanencia(ByVal fini As String, ByVal fechaAct As String, ByVal indRenovacion As Integer, ByVal fact As String) As Integer

        If indRenovacion = 1 Then
            If Not fini.Equals("") Then
                Dim fi = Convert.ToDateTime(fini)
                Dim fa = Convert.ToDateTime(fact)
                Dim rs = DateDiff(DateInterval.Day, fi, fa)
                _mpermanencia = rs
            Else
                _mpermanencia = 0
            End If
        Else
            If Not fechaAct.Equals("") Then
                Dim fi = Convert.ToDateTime(fechaAct)
                Dim fa = Convert.ToDateTime(fact)
                Dim rs = DateDiff(DateInterval.Day, fi, fa)
                Dim año = rs / 365
                Dim meses = Convert.ToInt32((rs - (año * 365)) / 30.4167)
                _mpermanencia = rs
            Else
                _mpermanencia = 0
            End If
        End If
        Return _mpermanencia
    End Function

    'PROY-24740
    Private Sub LlenarCampanaPlazo(ByVal pstrComboCodigo As String, ByVal pstrOficina As String, ByVal pstrOferta As String, ByVal strTipoProducto As String, ByVal pstrCasoEspecial As String, ByVal pModalidadVenta As String, ByVal pstrFlujo As String, ByVal pstrTipoOperacion As String, ByVal pstrGrupoProducto As String, ByVal pstrMantenerPlan As String, ByVal pstrCodPlan As String, ByVal pstrCampanasNoVig As String)
        Dim strResultado As New StringBuilder

        If pstrGrupoProducto = "00" Then
         'gaa20160314 -MRAF
            Dim strTipoOperacionBRMS As String = String.Empty
            If Not Session("TipoOperacionBRMS") Is Nothing Then
                strTipoOperacionBRMS = Session("TipoOperacionBRMS")
            End If
        Dim strFlujoAlta As String = ConfigurationSettings.AppSettings("flujoAlta")

            If strTipoOperacionBRMS = ConfigurationSettings.AppSettings("constFlujoRenov") OrElse strTipoOperacionBRMS.Length = 0 Then
            strResultado.Append(ListarCampana(pstrComboCodigo, pstrOficina, pstrOferta, strTipoProducto, pstrCasoEspecial, pModalidadVenta, pstrFlujo, pstrTipoOperacion, pstrMantenerPlan, pstrCodPlan, pstrCampanasNoVig)) 'Modificacion Plan No Vigente
        Else
            strResultado.Append(ListarCampana(pstrComboCodigo, pstrOficina, pstrOferta, strTipoProducto, pstrCasoEspecial, pModalidadVenta, strFlujoAlta, strTipoOperacionBRMS, pstrMantenerPlan, pstrCodPlan, pstrCampanasNoVig)) 'Modificacion Plan No Vigente
        End If
        'fin gaa20160314
        Else
            strResultado.Append(ListarCampanaNuevas(pstrGrupoProducto, strTipoProducto))
        End If
        strResultado.Append("¬")
        strResultado.Append(ListarPlazo(strTipoProducto, pstrCasoEspecial, pModalidadVenta))

        hidResultado.Value = strResultado.ToString()
    End Sub

    'PROY-24740
    Private Function ListarCampanaNuevas(ByVal pstrCombo As String, ByVal strTipoProducto As String) As String
        Dim strResultado As New StringBuilder

        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrCombo: {1}", hidNroDocumento.Value, pstrCombo))

        Dim objLista As ArrayList = New ConsumerNegocio().ListarCampanaNuevas(pstrCombo, strTipoProducto)

        For Each obj As ItemGenerico In objLista
            strResultado.AppendFormat("|{0};{1}", obj.Codigo, obj.Descripcion)
        Next

        Return strResultado.ToString()
    End Function

    'PROY-24740        
    Private Function ListarCampana(ByVal pstrComboCodigo As String, ByVal pstrOficina As String, ByVal pstrOferta As String, ByVal strTipoProducto As String, ByVal pstrCasoEspecial As String, ByVal pModalidadVenta As String, ByVal pstrFlujo As String, ByVal pstrTipoOperacion As String, ByVal pstrMantenerPlan As String, ByVal pstrCodPlan As String, ByVal pstrCampanasNoVig As String) As String
        Dim strResultado As New StringBuilder

        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrOficina: {1}", hidNroDocumento.Value, pstrOficina))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrOferta : {1}", hidNroDocumento.Value, pstrOferta))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - strTipoProducto : {1}", hidNroDocumento.Value, strTipoProducto))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pModalidadVenta : {1}", hidNroDocumento.Value, pModalidadVenta))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrCasoEspecial : {1}", hidNroDocumento.Value, pstrCasoEspecial))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrFlujo : {1}", hidNroDocumento.Value, pstrFlujo))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrTipoOperacion : {1}", hidNroDocumento.Value, pstrTipoOperacion))
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrMantenerPlan : {1}", hidNroDocumento.Value, pstrMantenerPlan)) 'Modificacion Plan No Vigente
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrCodPlan : {1}", hidNroDocumento.Value, pstrCodPlan)) 'Modificacion Plan No Vigente
        objLog.Log_WriteLog(strArchivo, String.Format("{0} - Oficina - lista camapañas - pstrCampanasNoVig : {1}", hidNroDocumento.Value, pstrCampanasNoVig)) 'Modificacion Plan No Vigente

        If pstrMantenerPlan = "N" Then
            'Si mantiene su plan, se cargará las campanas asociadas a ese plan no vigente
            Dim objListaCampanaNoVig As ArrayList = New ConsumerNegocio().ListarCampanaNoVig(pstrOficina, pstrOferta, strTipoProducto, pModalidadVenta, pstrFlujo, pstrTipoOperacion, pstrCodPlan, pstrCampanasNoVig)

            For Each obj As ItemGenerico In objListaCampanaNoVig
                strResultado.AppendFormat("|{0};{1}", obj.Codigo, obj.Descripcion)
            Next
        Else
        Dim objLista As ArrayList = New ConsumerNegocio().ListarCampana(pstrOficina, pstrOferta, strTipoProducto, pModalidadVenta, pstrFlujo, pstrTipoOperacion)

        For Each obj As ItemGenerico In objLista
                strResultado.AppendFormat("|{0};{1}", obj.Codigo, obj.Descripcion)
        Next
        End If

        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Function ListarPlazo(ByVal idProducto As String, ByVal idCasoEspecial As String, ByVal modalidadVenta As String) As String
        Dim strResultado As New StringBuilder
        Dim objLista As ArrayList = New ConsumerNegocio().ListarPlazo(idProducto, idCasoEspecial, modalidadVenta)

        For Each obj As ItemGenerico In objLista
            strResultado.AppendFormat("|{0};{1}", obj.Codigo, obj.Descripcion)
        Next
        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Function LlenarServicioNoSap(ByVal idProducto As String, ByVal idCasoEspecial As String, ByVal idPlan As String) As String

        Dim strResultado As New StringBuilder
        Dim strServicioSI As New StringBuilder
        Dim strServicioNO As New StringBuilder

        Try         

            Dim objLista As ArrayList = New ConsumerNegocio().ListarServiciosXPlan(idProducto, idPlan)
            objLog.Log_WriteLog(strArchivo, "objLista" & " - " & objLista.Count)
            Dim objListaTopeConfig As ArrayList = New ConsumerNegocio().ListarPlanTopeConfig(idPlan, idCasoEspecial)
            objLog.Log_WriteLog(strArchivo, "objListaTopeConfig" & " - " & objListaTopeConfig.Count)

            If ConfigurationSettings.AppSettings("consFlagValidacionTopeConsumoExacto") = 1 Then
                objLog.Log_WriteLog(strArchivo, "consFlagValidacionTopeConsumoExacto" & " - " & ConfigurationSettings.AppSettings("consFlagValidacionTopeConsumoExacto"))


                Dim NumeroLineaTope As String = Session("NumeroLineaTope") '"997355458" 
                objLog.Log_WriteLog(strArchivo, "NumeroLineaTope" & " - " & NumeroLineaTope)

                Dim oPostpagoNegocios As New DatosPostpagoNegocios
                Dim datosLinea As ClienteBSCS = Nothing
                Dim mensajeError As String = String.Empty

                datosLinea = oPostpagoNegocios.LeerDatosCliente(NumeroLineaTope, "", mensajeError)
                objLog.Log_WriteLog(strArchivo, "datosLinea" & " - " & datosLinea.Co_id)
                Dim Co_Id As Double = CheckDbl(datosLinea.Co_id)
                Dim SnCode As Double = ConfigurationSettings.AppSettings("consCodigoSNCode")

                Dim objTope As New ConsumerNegocio
                Dim TopeCero As Boolean = objTope.RetornarTopeCero(Co_Id, SnCode)
                If TopeCero = True Then
                    strServicioSI.AppendFormat("|{0}_{1}_{2}_{3}_{4};(*) {5}", "0", ConfigurationSettings.AppSettings("GSRVC_CODIGO"), ConfigurationSettings.AppSettings("SELECCIONABLE_BASE"), ConfigurationSettings.AppSettings("SERVV_CODIGO"), ConfigurationSettings.AppSettings("CARGO_FIJO_BASE"), ConfigurationSettings.AppSettings("SERVV_DESCRIPCION"))

                End If

                For Each obj As Servicio_AP In objLista

                    If Funciones.CheckInt(obj.SELECCIONABLE_BASE) = CInt(TIPO_SELECCION.SELECCIONADO) OrElse Funciones.CheckInt(obj.SELECCIONABLE_BASE) = CInt(TIPO_SELECCION.SELECCIONADO_EDITABLE) Then
                        strServicioSI.AppendFormat("|{0}_{1}_{2}_{3}_{4};(*) {5}", obj.SERVN_ORDEN, obj.GSRVC_CODIGO, obj.SELECCIONABLE_BASE, obj.SERVV_CODIGO, obj.CARGO_FIJO_BASE, obj.SERVV_DESCRIPCION)
                    Else
                        If obj.SERVV_CODIGO <> ConfigurationSettings.AppSettings("codServRoamingI") OrElse (obj.SERVV_CODIGO = ConfigurationSettings.AppSettings("codServRoamingI") AndAlso strFlagServicioRI = ConfigurationSettings.AppSettings("constFlagRIActivo")) Then
                            strServicioNO.AppendFormat("|{0}_{1}_{2}_{3}_{4};{5}", obj.SERVN_ORDEN, obj.GSRVC_CODIGO, obj.SELECCIONABLE_BASE, obj.SERVV_CODIGO, obj.CARGO_FIJO_BASE, obj.SERVV_DESCRIPCION)
                        End If
                    End If
                Next

            Else

                For Each obj As Servicio_AP In objLista
                    For Each objTope As Servicio_AP In objListaTopeConfig
                        If obj.SERVV_CODIGO = objTope.SERVV_CODIGO Then
                            obj.SELECCIONABLE_BASE = objTope.SELECCIONABLE_BASE
                            Exit For
                        End If
                    Next
                    If Funciones.CheckInt(obj.SELECCIONABLE_BASE) = CInt(TIPO_SELECCION.SELECCIONADO) OrElse Funciones.CheckInt(obj.SELECCIONABLE_BASE) = CInt(TIPO_SELECCION.SELECCIONADO_EDITABLE) Then
                        strServicioSI.AppendFormat("|{0}_{1}_{2}_{3}_{4};(*) {5}", obj.SERVN_ORDEN, obj.GSRVC_CODIGO, obj.SELECCIONABLE_BASE, obj.SERVV_CODIGO, obj.CARGO_FIJO_BASE, obj.SERVV_DESCRIPCION)
                    Else
                        If obj.SERVV_CODIGO <> ConfigurationSettings.AppSettings("codServRoamingI") OrElse (obj.SERVV_CODIGO = ConfigurationSettings.AppSettings("codServRoamingI") AndAlso strFlagServicioRI = ConfigurationSettings.AppSettings("constFlagRIActivo")) Then
                            strServicioNO.AppendFormat("|{0}_{1}_{2}_{3}_{4};{5}", obj.SERVN_ORDEN, obj.GSRVC_CODIGO, obj.SELECCIONABLE_BASE, obj.SERVV_CODIGO, obj.CARGO_FIJO_BASE, obj.SERVV_DESCRIPCION)
                        End If
                    End If
                Next

            End If

            strResultado.Append(strServicioNO.ToString())
            strResultado.Append("¬")
            strResultado.Append(strServicioSI.ToString())
        Catch ex As Exception
            
            objLog.Log_WriteLog(strArchivo, hidNroDocumento.Value & " - " & "ERROR METODO :" & ex.Message)
        End Try


        Return strResultado.ToString()
    End Function

    'PROY-24740
    Private Sub LlenarServicioMaterial(ByVal idProducto As String, ByVal idCasoEspecial As String, _
        ByVal idPlan As String, ByVal orgVentaSap As String, ByVal centroSap As String, _
        ByVal idOficina As String, ByVal idCampanaSap As String, ByVal idPlanSap As String, _
        ByVal strTipoOficina As String, ByVal strTipoProducto As String, _
        ByVal strTipoOperacion As String, ByVal strTipoDocumento As String, _
        ByVal strTipoVenta As String, ByVal strPlazo As String, ByVal strTipoCliente As String)
        Dim strResultado As New StringBuilder

        strResultado.Append(LlenarServicioNoSap(idProducto, idCasoEspecial, idPlan))
        strResultado.Append("~")
        strResultado.Append(LlenarMaterial(ObtenerCampanaSap(idCampanaSap), idPlanSap, idOficina, _
            orgVentaSap, centroSap, strTipoOficina, strTipoProducto, strTipoOperacion, _
            strTipoDocumento, strTipoVenta, strPlazo, strTipoCliente))

        hidResultado.Value = strResultado.ToString()
    End Sub

    Private Function ObtenerCampanaSap(ByVal strCampana As String) As String
        Dim strCampanaSap As String
        strCampanaSap = New ConsumerNegocio().ObtenerCampanaSap(strCampana)
        Return strCampanaSap
    End Function

    Private Function LlenarEquipoPrecio(ByVal objForm As BEFormEvaluacion) As String

        Dim strResultado As String = String.Empty
        Dim dtGama As DataTable = (New ConsumerNegocio).ObtenerEquipoGama()

        For Each dr As DataRow In dtGama.Rows
            If dr("eqgac_codigo").ToString = objForm.IdMaterial Then
                strResultado = String.Format("{0}_{1}_{2}_{3}", dr("eqgan_precio"), dr("eqgac_codigo"), dr("eqgav_descripcion"), dr("eqgan_costo"))
                Return strResultado
            End If
        Next

        Dim arrListaPrecio As New ArrayList
        Dim dblCosto As Double = 0
        'gaa20160314 - MRAF
        Dim strTipoOperacionBRMS As String = objForm.IdTipoOperacion
        If Not Session("TipoOperacionBRMS") Is Nothing Then
            strTipoOperacionBRMS = Session("TipoOperacionBRMS")
        End If
        'fin gaa20160314

        If objForm.IdTipoOficina = ConfigurationSettings.AppSettings("constCodTipoOficinaCAC") Then
            Dim oConsultaMSSAP As New ConsultaMsSapNegocio


            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdMaterial : {1}", hidNroDocumento.Value, objForm.IdMaterial))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdProducto : {1}", hidNroDocumento.Value, objForm.IdProducto))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdTipoVenta : {1}", hidNroDocumento.Value, objForm.IdTipoVenta))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdTipoOficina : {1}", hidNroDocumento.Value, objForm.IdTipoOficina))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdCampanaSap : {1}", hidNroDocumento.Value, objForm.IdCampanaSap))
            'gaa20160314 - MRAF
            'objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdTipoOperacion : {1}", hidNroDocumento.Value, objForm.IdTipoOperacion))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdTipoOperacion : {1}", hidNroDocumento.Value, strTipoOperacionBRMS))
            'fin gaa20160314
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdPlazo : {1}", hidNroDocumento.Value, objForm.IdPlazo))
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - objForm.IdPlanSap : {1}", hidNroDocumento.Value, objForm.IdPlanSap))

            ' Obtener Costo Equipo
            Dim lstConsulta As ArrayList = oConsultaMSSAP.ConsultaPrecioBaseMaterial(objForm.IdMaterial)
            dblCosto = CType(lstConsulta(0), ItemGenerico).Monto

            objLog.Log_WriteLog(strArchivo, String.Format("{0} - dblCosto : {1}", hidNroDocumento.Value, dblCosto))

            ' Consultar Lista Precio
            'gaa20160314
            'objForm.IdTipoOperacion
            arrListaPrecio = oConsultaMSSAP.ConsultarListaPrecio(objForm.IdProducto, _
                                                                objForm.IdTipoVenta, _
                                                                objForm.IdTipoOficina, _
                                                                String.Empty, _
                                                                objForm.IdMaterial, _
                                                                objForm.IdCampanaSap, _
                                                                strTipoOperacionBRMS, _
                                                                objForm.IdPlazo, _
                                                                objForm.IdPlanSap)
            'fin gaa20160314  - MRAF
        Else
            ' Obtener Costo Equipo
            Dim objSapGeneral As SapGeneralNegocios = New SapGeneralNegocios
            Dim dtCostoPromedio As DataTable = objSapGeneral.Get_CostoPromedio(String.Empty, objForm.IdMaterial, "")

            For Each dr As DataRow In dtCostoPromedio.Rows
                If dr(3) > dblCosto Then
                    dblCosto = dr(3)
                End If
            Next

            ' Consultar Lista Precio
            'gaa20160314
            'objForm.IdTipoOperacion
            arrListaPrecio = objSapGeneral.ConsultarLPrecio(objForm.CanalSap, _
                                                            objForm.TipoDocumentoSap, _
                                                            objForm.IdTipoVenta, _
                                                            objForm.IdPlanSap, _
                                                            objForm.IdMaterial, _
                                                            objForm.IdCampanaSap, _
                                                            objForm.OrgVentaSap, _
                                                            Now.ToString("yyyyMMdd"), _
                                                            strTipoOperacionBRMS, _
                                                            objForm.IdPlazo, _
                                                            objForm.IdOficina)
            'fin gaa20160314 - MRAF

        End If

        If arrListaPrecio.Count = 0 Then
            Throw New Exception("No existe Configuración Lista de Precio")
        End If

        Dim dblPrecio As Decimal = 0
        Dim strCodLPrecio As String = Nothing
        Dim strDesLPrecio As String = Nothing
        Dim dblPrecioFinal As Decimal = 0
        Dim dblPrecioMenor As Decimal = 999999
        Dim dblPrecioMayor As Decimal = 0

        For Each item As ItemGenerico In arrListaPrecio
            dblPrecio = Funciones.CheckDecimal(item.Valor)

            If Not objForm.ModalidadVenta = strCodModalidadCuota Then
                If dblPrecio < dblPrecioMenor Then
                    dblPrecioMenor = dblPrecio
                    strCodLPrecio = Funciones.CheckStr(item.Codigo)
                    strDesLPrecio = Funciones.CheckStr(item.Descripcion)
                    dblPrecioFinal = dblPrecio
                End If
            Else
                If dblPrecio > dblPrecioMayor Then
                    dblPrecioMayor = dblPrecio
                    strCodLPrecio = Funciones.CheckStr(item.Codigo)
                    strDesLPrecio = Funciones.CheckStr(item.Descripcion)
                    dblPrecioFinal = dblPrecio
                End If
            End If
        Next
        strResultado = String.Format("{0}_{1}_{2}_{3}", dblPrecioFinal, strCodLPrecio, strDesLPrecio, dblCosto.ToString())

        objLog.Log_WriteLog(strArchivo, String.Format("{0} - strResultado : {1}", hidNroDocumento.Value, strResultado))

        Return strResultado
    End Function

    'PROY-24740
    Public Function LlenarEquipoPrecio(ByVal strOficina As String, _
                                     ByVal strOferta As String, _
                                     ByVal strPlazo As String, _
                                     ByVal strPlan As String, _
                                     ByVal strCampana As String, _
                                     ByVal strMaterial As String, _
                                     ByVal strCanal As String, _
                                     ByVal strOrgVenta As String, _
                                     ByVal strTipoDocVenta As String, _
                                     ByVal intNroCuotas As Integer, _
                                     ByVal strTipoCliente As String) As String

        Dim objBLConsulta As BLConsulta
        Dim objBLConsultaMssap As BLConsultaMssap

        Dim strTipoVenta As String = ConfigurationSettings.AppSettings("strTVPostpago")
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")
        'gaa20160308
        If Not Session("TipoOperacionBRMS") Is Nothing Then
        strTipoOperacion = Session("TipoOperacionBRMS")
        End If
        'fin gaa20160308
        Dim arrListaPrecio As New ArrayList
        Dim nroDocumento As String = hidNroDocumento.Value
        Dim strResultado As String = String.Empty

        Try
            Dim dtGama As DataTable = (New ConsumerNegocio).ObtenerEquipoGama()
            For Each dr As DataRow In dtGama.Rows
                If dr("eqgac_codigo") = strMaterial Then
                    strResultado = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", dr("eqgan_precio"), dr("eqgac_codigo"), dr("eqgav_descripcion"), dr("eqgan_costo"), dr("eqgan_precio"), dr("eqgan_costo"))
                    Return strResultado
                End If
            Next

            Dim strCosto As String

            'Consulta Lista de Precios
            Dim input As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", strTipoVenta, strPlan, strMaterial, strCampana, strOrgVenta, strCanal, strTipoOperacion, strTipoDocVenta, strOficina, strPlazo)
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - Input  --> {1}", nroDocumento, input))


            objBLConsulta = New BLConsulta
            arrListaPrecio = objBLConsulta.ConsultaListaPrecios(strTipoCliente, strTipoVenta, "", "", strMaterial, strCampana, _
                                                                strTipoOperacion, strPlazo, strPlan)

            objLog.Log_WriteLog(strArchivo, String.Format("{0} - Output --> Nro LP: {1}", nroDocumento, arrListaPrecio.Count))

            If arrListaPrecio.Count = 0 Then
                Throw New Exception("No existe Configuración Lista de Precio - Plazo Acuerdo (BD SISACT)")
            End If

            Dim dblPrecio As Double
            Dim strCodLPrecio As String
            Dim strDesLPrecio As String
            Dim dblPrecioFinal As Double
            Dim dblPrecioMayor As Decimal = 0
            Dim dblPrecioMenor As Decimal = 999999

            For Each item As ItemGenerico In arrListaPrecio
                dblPrecio = item.PrecioVenta_Out

                If strOferta = ConfigurationSettings.AppSettings("constTipoProductoBUS") Then
                    If intNroCuotas > 0 AndAlso CheckStr(item.Descripcion).ToUpper.IndexOf("CU") Then
                        If dblPrecio > dblPrecioMayor Then
                            dblPrecioMayor = dblPrecio
                            strCodLPrecio = CheckStr(item.Codigo)
                            strDesLPrecio = CheckStr(item.Descripcion)
                            dblPrecioFinal = dblPrecio
                        End If
                    ElseIf intNroCuotas = 0 AndAlso CheckStr(item.Descripcion).ToUpper.IndexOf("CO") Then
                        If dblPrecio < dblPrecioMenor Then
                            dblPrecioMenor = dblPrecio
                            strCodLPrecio = CheckStr(item.Codigo)
                            strDesLPrecio = CheckStr(item.Descripcion)
                            dblPrecioFinal = dblPrecio
                        End If
                    End If
                Else
                    If dblPrecio < dblPrecioMenor Then
                        dblPrecioMenor = dblPrecio
                        strCodLPrecio = CheckStr(item.Codigo)
                        strDesLPrecio = CheckStr(item.Descripcion)
                        dblPrecioFinal = dblPrecio
                    End If
                End If
            Next

            'Se agrego para obtener el PrecioIncIGV y PrecioSinIGV
            Dim dsPrecio As New DataSet
            Dim precios As String = ""
            Dim cantidad As Decimal = 1
            Dim dblIccidPrecio As Decimal
            Dim dblIccidDescuento As Decimal
            Dim dblIccidPreIGV As Decimal
            Dim dblIccidTotal As Decimal
            Dim oItemGenerico As New ItemGenerico

            Dim usuario_id As String = String.Empty
            objBLConsultaMssap = New BLConsultaMssap
            oItemGenerico = objBLConsultaMssap.ConsultaPrecioBase(strMaterial, "")
            strCosto = oItemGenerico.PrecioCompra 'INC000000715147

            oItemGenerico = objBLConsultaMssap.ConsultaPrecioVenta(strMaterial, "", oItemGenerico.PrecioBase, dblPrecio)
            dblIccidDescuento = oItemGenerico.Descuento_Out
            dblIccidPreIGV = dblPrecio
            dblIccidPrecio = oItemGenerico.PrecioBase
            dblIccidTotal = dblPrecio

            Dim output As String = String.Format("{0}|{1}|{2}|{3}", dblPrecioFinal, strCodLPrecio, strDesLPrecio, strCosto)
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - Output --> {1}", nroDocumento, output))

            strResultado = String.Format("{0}_{1}_{2}_{3}_{4}_{5}", dblPrecioFinal, strCodLPrecio, strDesLPrecio, strCosto, CheckStr(dblIccidPreIGV), CheckStr(dblIccidPrecio))

        Catch ex As Exception
            strResultado = String.Empty
            If CheckStr(ex.Message).IndexOf("SAP") > -1 Then
                hidMensaje.Value = CheckStr(ex.Message)
            Else
                hidMensaje.Value = "Error al obtener Precio del Equipo"
            End If
            objLog.Log_WriteLog(strArchivo, String.Format("{0} - ERROR CONSULTA PRECIO: {1}", nroDocumento, ex.Message))

            Throw New Exception(hidMensaje.Value)
        End Try

        Return strResultado
    End Function

    '-fin-dga-04082015
    'gaa20151106
    Private Function ValidarAccesoOpcion(ByVal strCanalCodigo As String, ByVal strProductoCodigo As String, ByVal strTipoOperacion As String, ByVal strTipoDocumento As String, ByVal strTipoValidacion As String) As Boolean
        Dim booResultado As Boolean = True
        Dim objConsumerNegocio As ConsumerNegocio

        Try
            objConsumerNegocio = New ConsumerNegocio
            booResultado = objConsumerNegocio.ValidacionAccesoOpcionEP(strCanalCodigo, strProductoCodigo, strTipoOperacion, strTipoDocumento, strTipoValidacion)

        Finally
            objConsumerNegocio = Nothing
        End Try
        Return booResultado
    End Function
    'fin gaa20151106


    Private Function EsCanalPermitido(ByVal sCanalActual As String, ByVal sCanalesPermitidos() As String) As Boolean

        For i As Integer = 0 To sCanalesPermitidos.Length - 1
            If sCanalesPermitidos(i) = sCanalActual Then
                Return True
            End If
        Next

        Return False

    End Function

    '<!-- INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
    Public Function ConsultarGestionAcuerdo(ByVal user As String, ByVal NumLinea As String, ByVal CodId As String, ByRef CodWS As String, ByRef MsgWS As String)
        Dim objGestionAcuerdoWS As New GestionAcuerdoNegocios
        Dim objGestionAcuerdo As BEGestionAcuerdoWS
        Dim NumErrores As Int32 = 0
        Dim obJPermanenciaDias As Int32 = 0
        Dim objTPlazoAcuerdo As Int32 = 0
        Dim mesesPendientes As Int32 = 0
        Dim NumIntentosWSRealizados As Int32 = 0
        'Dim CodWS As Int32 = 0
        'Dim MsgWS As String = ""
        Dim NumIntentosWS As Int32 = Convert.ToInt32(ConfigurationSettings.AppSettings("WSGesAcuerdo_NumIntentos"))
        objLog.Log_WriteLog(strArchivo, "-Inicio Invocar GestionAcuerdoWS --> Num de intentos:" & NumIntentosWS)
        For index As Integer = 1 To NumIntentosWS
            NumIntentosWSRealizados = index
            objGestionAcuerdo = objGestionAcuerdoWS.ObtenerGestionAcuerdoWS(user, NumLinea, CodId, CodWS, MsgWS)

            Session("GestionAcuerdoWS") = objGestionAcuerdo

        'LMA
            If CodWS = "0" Or MsgWS = "" Then
            obJPermanenciaDias = Funciones.CheckInt16(DateDiff(DateInterval.Month, Funciones.CheckDate(objGestionAcuerdo.acuerdoFechaInicio), Date.Now))   'objGestionAcuerdo.acuerdoFechaInicio
           
            objTPlazoAcuerdo = objGestionAcuerdo.acuerdoVigenciaMeses
            mesesPendientes = objGestionAcuerdo.mesesPendientes

            Session("GestionAcuerdoReno") = obJPermanenciaDias & "|" & objTPlazoAcuerdo & "|" & mesesPendientes
            objLog.Log_WriteLog(strArchivo, "- Invocar GestionAcuerdoWS --> CodWS:" & Session("GestionAcuerdoReno"))
                Exit For
            End If
        Next
        objLog.Log_WriteLog(strArchivo, "-Fin Invocar GestionAcuerdoWS --> Num de intentos Realizados:" & NumIntentosWSRealizados & ", CodWS:" & CodWS & ", MsgWS:" & MsgWS)
        Return objGestionAcuerdo
    End Function
    '<!-- FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->

    'Inicio Correccion JAZ
    Private Function EsValorPermitido(ByVal sValorActual As String, ByVal sValoresPermitidos() As String) As Boolean

        For i As Integer = 0 To sValoresPermitidos.Length - 1
            If sValoresPermitidos(i) = sValorActual Then
                Return True
            End If
        Next

        Return False

    End Function

    'Fin Correccion JAZ
    'ECM s8
    Private Function consultarCantidadLineas3G(ByVal strTipoDocumentos As String, ByVal strNroDoc As String) As String
        Dim resultado As String
        objLog.Log_WriteLog(strArchivo, "iniciando consulta cantidad de lineas -")
        'indico que si hay lineas entonces debo dar el SI para mostrar, caso contrario NO.
        Dim cantidadLineas As Integer = 0
        Dim lineas() As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas
        objLog.Log_WriteLog(strArchivo, "invocando al servicio para tipo doc " & strTipoDocumentos & "y documento  " & strNroDoc)
        'accediendo al objeto consultalineaTecnologiaNegocio para obtener lineas y contarlas
        Dim objLineas As New ConsultaLineasTecnologiaNegocio
        Dim codError, msgError As String
        Try
            objLog.Log_WriteLog(strArchivo, "el objeto del servicio " & IIf(objLineas Is Nothing, "es nulo", "esta instanciado"))
            objLog.Log_WriteLog(strArchivo, "Iniciando la consulta al submetodo consultarLineasPrePost")
            lineas = objLineas.consultarLineasPrePost(strTipoDocumentos, strNroDoc, codError, msgError)
            objLog.Log_WriteLog(strArchivo, "Finaliza la consulta al submetodo consultarLineasPrePost")
            If codError = "0" Then
                cantidadLineas = lineas.Length
            End If
            objLog.Log_WriteLog(strArchivo, String.Format("consultarlineasprepost cantidad lineas: {0}", cantidadLineas))
            objLog.Log_WriteLog(strArchivo, "Resultado WS - Consulta de Lineas 3G - Codigo: " + codError + " Mensaje: " + msgError)
            objLog.Log_WriteLog(strArchivo, "Fin del proceso que consulta la cantidad de líneas 3G")
        Catch e As Exception
            cantidadLineas = 0
            objLog.Log_WriteLog(strArchivo, "EXCEPCION en consulta de lineas: " & e.Message & " " & e.StackTrace)
        End Try
        resultado = IIf(cantidadLineas > 0, "SI", "NO")
        objLog.Log_WriteLog(strArchivo, String.Format("consultarlineasprepost resultado: {0}", resultado))
        Return resultado
    End Function    'fin ECM s8




End Class
