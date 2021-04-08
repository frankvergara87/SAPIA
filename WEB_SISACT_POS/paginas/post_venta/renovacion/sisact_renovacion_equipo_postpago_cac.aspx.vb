Option Strict Off

Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.DateTime
Imports System.TimeSpan
Imports System.Text
Imports System.Collections.Specialized
Imports System.Collections

Public Class sisact_renovacion_equipo_postpago_cac
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTipoDoc As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTipoDocId As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents LabelPaterno As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTipoCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefonoReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCampania As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPlanTarifario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMaxLenTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIMSI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanAct As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCicloFact As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNomCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombresCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLimiteCred As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNombreCLiente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLineaD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIMSI As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidApellidosCli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCorreo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTelefonoReferencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtApadeceFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtApadeceFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDepartamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProvincia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReintegro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDistrito As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReintegroAFacturar As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrecioVenta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescuentoEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotalAPagar As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDireccion As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidDireccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDepartamento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistrito As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvincia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlCodEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlSerieEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidOfVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEqSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlListaPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidItemSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSerieEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagBuscando As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagBuscandoPaso1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCorreo As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOpcionAutorizacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaPenalidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagExonerarReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagConfExoneracionReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidModalidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCuenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCustumerId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrgVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalOf As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanTarifaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidlistaPrecioSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroPedido As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidnroContrato As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagRenovacionAdelantada As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label24 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPlazoAcuerdo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidTitular As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRepresentante As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesPorVencerApadece As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaInicioApadece As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaFinApadece As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnRetenidoFidelizado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMontoMaxDesAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMesesMaxAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblClaroClubCampana As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaroClubCampana As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClaroClubPuntosPostpago As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaroClubPuntosPostpago As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClaroClubPuntosUtilizar As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaroClubPuntosUtilizar As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClaroClubSolesDeDescuento As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaroClubSolesDeDescuento As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClaroClubSaldoActual As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaroClubSaldoActual As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClaroClubMsgError As System.Web.UI.WebControls.Label
    Protected WithEvents lblDescuentoClaroClub As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescuentoClaroClub As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkRetenido As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFidelizado As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hidFactorClaroClub As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaroClubSolesDeDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorClaroClub As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorClaroClubDesfase As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumentos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTieneReserva As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIDCAMPANA As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSaldosCC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgSaldosCC As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidCCMinimoPuntos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMinimoSoles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorCCPuntosMinimos As System.Web.UI.HtmlControls.HtmlInputHidden
    ' Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
    Protected WithEvents txtFechaIniCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFinCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSegmentoCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidDetalleDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntosQuivalentes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorCodeWSCC As System.Web.UI.HtmlControls.HtmlInputHidden
    ' Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim oLog As New SISACT_Log
    Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRepPostpago")
    Dim oFile As String = oLog.Log_CrearNombreArchivo(nameFile)
    Dim strIdentifyLog As String

    Public Enum Modo
        Valor_Minimo = 0
        Valor_Maximo = 30
    End Enum

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")

        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty) Or CheckStr(Session("CodVendedorSAP")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        strIdentifyLog = Me.CurrentUser
        ddlCodEquipo.Attributes.Add("onChange", "f_CambiaImei()")

        If Not Page.IsPostBack Then
            Inicio()
        Else
            Dim accion As String = hidAccion.Value

            If accion = "Consultar" Then
                Consultar()
            ElseIf accion = "GenerarPedido" Then
                GenerarPedido()
            ElseIf accion = "CargaAreaFinal" Then
                CargarHidden()
            End If
        End If



    End Sub

    Private Sub Inicio()
        Try
            hidFlagBuscando.Value = "false"
            hidFlagBuscandoPaso1.Value = "false"

            hidTipoOperacion.Value = ConfigurationSettings.AppSettings("constCodOperRenovacion")
            hidTipoVenta.Value = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")

            ObtenerPerfiles()
            CargarTipoDocumento()
            CargarArticuloIMEI()
            CargarCampanias()
            CargarPlan()
            CargarPlazoAcuerdo()
            ConsultarDatosVenta()

            ' Inicio E77568
            ' Inicio PS - Automatización de canje y nota de crédito
            hidErrorClaroClubDesfase.Value = ConfigurationSettings.AppSettings("constErrorClaroClubDesfase")
            hidErrorClaroClub.Value = ConfigurationSettings.AppSettings("constErrorClaroClub")
            hidErrorCCPuntosMinimos.Value = (ConfigurationSettings.AppSettings("constErrorCCPuntosMinimos").Replace("{0}", ConfigurationSettings.AppSettings("constMinimoCC")))
            hidCCMinimoPuntos.Value = ConfigurationSettings.AppSettings("constMinimoCC")
            ' Fin PS - Automatización de canje y nota de crédito
            ' Fin E77568
        Catch ex As Exception
            hidMsg.Value = ex.Message
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.Message)
        End Try
    End Sub

    ' Inicio E77568
    ' Inicio PS - Automatización de canje y nota de crédito

    ' Carga los Claro Puntos y sus montos en soles, leidos de un webservice.
    Private Sub CargarDatosDePuntoClaroClub(ByVal TipoDocumento As String, _
                                            ByVal NroDocumento As String)
        Dim SaldoActual As Integer = 0
        Dim PuntosListado As Integer = 0
        Dim PuntosUtilizar As Integer = 0
        Dim constFactorClaroClub As Double
        Dim ClaroClubCampana As String
        Dim idCampana As String
        Dim idLog As String
        Dim constErrorBolsaMovilDes As String = ""
        Dim ErrorBolsaMovilDes As String = ""
        Dim bErrorBolsaMovilDes As Boolean = False
        Dim CCMinimoSoles As Double = 0.0

        Try
            idLog = TipoDocumento & " - " & NroDocumento

            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio CargarDatosDePuntoClaroClub(): " & ConfigurationSettings.AppSettings("ConstUrlConsultarPuntos"))

            Dim ID_CCLUB As String
            ID_CCLUB = getCCLUB(TipoDocumento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "ID_CCLUB:" & ID_CCLUB)

            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            objConsultarPuntosResponse = objPuntosClaroClubNegocio.consultarPuntos(ID_CCLUB, _
                                                                                   NroDocumento, _
                                                                                   CurrentUser, "")

            'Inicio leer WS

            oLog.Log_WriteLog(oFile, idLog & " - " & "out txId:" & objConsultarPuntosResponse.audit.txId)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorCode:" & objConsultarPuntosResponse.audit.errorCode)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorMsg:" & objConsultarPuntosResponse.audit.errorMsg)
            lblClaroClubMsgError.Text = ""

            constErrorBolsaMovilDes = ConfigurationSettings.AppSettings("constErrorBolsaMovilDes")
            hidErrorCodeWSCC.Value = objConsultarPuntosResponse.audit.errorCode.Trim
            If objConsultarPuntosResponse.audit.errorCode.Trim = constErrorBolsaMovilDes Then
                bErrorBolsaMovilDes = True
                ErrorBolsaMovilDes = objConsultarPuntosResponse.audit.errorMsg
                Throw New Exception(objConsultarPuntosResponse.audit.errorCode)
            ElseIf objConsultarPuntosResponse.audit.errorCode.Trim <> "0" Then
                oLog.Log_WriteLog(oFile, idLog & " - " & "Codigo de Repuesta diferente de Cero: " & hidErrorCodeWSCC.Value)
                Throw New Exception(ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible"))
            End If

            If objConsultarPuntosResponse.cursorSaldos Is Nothing Then
                oLog.Log_WriteLog(oFile, idLog & " - " & "Cursor de respuesta nulo")
                Throw New Exception(ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible"))
            End If

            ' Leer Id de la campaña
            If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
                ClaroClubCampana = objConsultarPuntosResponse.curCampana(0).descripcion
                idCampana = objConsultarPuntosResponse.curCampana(0).idCampana
            Else
                ' Mensaje predeterminado si no hay campaña vigente
                ClaroClubCampana = Funciones.CheckStr(ConfigurationSettings.AppSettings("constNoCampanhas"))
            End If


            constFactorClaroClub = Funciones.CheckDbl(objConsultarPuntosResponse.factorConversion)
            If (constFactorClaroClub = 0.0) Then
                oLog.Log_WriteLog(oFile, idLog & " - " & "Factor de conversion cero")
                Throw New Exception(ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible"))
            Else
                Dim CCMinimoPuntos As Integer
                CCMinimoPuntos = Funciones.CheckInt(ConfigurationSettings.AppSettings("constMinimoCC"))
                oLog.Log_WriteLog(oFile, idLog & " - " & "out CCMinimoPuntos:" & CCMinimoPuntos)
                CCMinimoSoles = Math.Ceiling(CCMinimoPuntos * constFactorClaroClub)
                oLog.Log_WriteLog(oFile, idLog & " - " & "out CCMinimoSoles:" & CCMinimoSoles)
                hidMinimoSoles.Value = CCMinimoSoles.ToString
            End If

            ' Grilla
            Call ListarSaldosCC(objConsultarPuntosResponse)

            hidIDCAMPANA.Value = idCampana
            txtClaroClubCampana.Text = ClaroClubCampana
            hidFactorClaroClub.Value = constFactorClaroClub.ToString

            ' Verificar si hay reserva de puntos
            If TieneReserva(ID_CCLUB, _
                            NroDocumento) Then
                txtClaroClubPuntosUtilizar.Text = "0"
                txtClaroClubPuntosUtilizar.Enabled = False

                txtClaroClubSolesDeDescuento.Text = "0"
                hidTieneReserva.Value = "1"
                lblClaroClubMsgError.Text = "El Cliente tiene un Bloqueo por Canje de Puntos."
                lblClaroClubMsgError.CssClass = ""
            Else
                txtClaroClubPuntosUtilizar.Enabled = True
                hidTieneReserva.Value = ""
                lblClaroClubMsgError.CssClass = "Arial10BRed"
            End If

            ' Inicio Modificación en SISACT la invocación de la WS de ConsultaPuntos
            Call VerVigenciaSegmento(objConsultarPuntosResponse)
            Call ConfigurarDatosDetalleDescuento(objConsultarPuntosResponse)
            ' Fin Modificación en SISACT la invocación de la WS de ConsultaPuntos

            oLog.Log_WriteLog(oFile, idLog & " - " & "out ClaroClubPuntosSaldoActual:" & txtClaroClubSaldoActual.Text)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out ClaroClubSolesDeDescuento:" & txtClaroClubSolesDeDescuento.Text)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out constFactorClaroClub:" & constFactorClaroClub)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out idCampana:" & idCampana)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out ClaroClubCampana:" & ClaroClubCampana)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out SegmentoCC:" & txtSegmentoCC.Text)
            ' Implementar la auditoría de cargar datos de Punto Claro Club.
            Dim codTrs As String = ConfigurationSettings.AppSettings("codTDatosPuntoClaroClub")
            Dim descTrs As String = "Cargar Datos De Punto Claro Club. ClaroClubCampana: " & ClaroClubCampana
            descTrs &= " ClaroClubPuntosSaldoActual: " & txtClaroClubSaldoActual.Text
            descTrs &= " ClaroClubSolesDeDescuento: " & txtClaroClubSolesDeDescuento.Text
            descTrs &= " FactorClaroClub: " & constFactorClaroClub.ToString
            descTrs &= " idCampana: " & idCampana
            descTrs &= " ClaroClubCampana: " & ClaroClubCampana
            descTrs &= " CCMinimoSoles: " & CCMinimoSoles
            descTrs &= " SegmentoCC: " & txtSegmentoCC.Text
            Auditoria(descTrs, codTrs)
        Catch ex As Exception
            txtClaroClubPuntosUtilizar.Text = "0"
            txtClaroClubPuntosUtilizar.Enabled = False
            txtClaroClubSolesDeDescuento.Text = "0"
            If bErrorBolsaMovilDes Then
                lblClaroClubMsgError.Text = ErrorBolsaMovilDes
            Else
                lblClaroClubMsgError.Text = ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible")
            End If
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR CargarDatosDePuntoClaroClub: " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR CargarDatosDePuntoClaroClub: " & ex.StackTrace.ToString())
        Finally
        oLog.Log_WriteLog(oFile, idLog & " - " & "Fin CargarDatosDePuntoClaroClub(): ")
        End Try
    End Sub

    ' Verificar si tiene ya los puntos reservados
    Public Function TieneReserva(ByVal k_tipo_doc As String, _
                                 ByVal k_num_doc As String) As Boolean
        Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
        Dim k_tipo_clie As String = ConfigurationSettings.AppSettings("consClienteWS")
        Dim k_tipo_doc2 As String
        Dim k_estado As String
        Dim k_coderror As Double
        Dim k_descerror As String
        Dim bTieneReserva As Boolean = False
        Dim constVALBLOQUEOBOLSA As String = ConfigurationSettings.AppSettings("constVALBLOQUEOBOLSA")
        Dim idLog As String = k_num_doc

        Try
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio TieneReserva(PKG_CC_TRANSACCION.ADMPS_VALBLOQUEOBOLSA)")
            oLog.Log_WriteLog(oFile, idLog & " - " & "inp k_tipo_doc: " & k_tipo_doc)
            oLog.Log_WriteLog(oFile, idLog & " - " & "inp k_num_doc: " & k_num_doc)
            oLog.Log_WriteLog(oFile, idLog & " - " & "inp k_tipo_clie: " & k_tipo_clie)

            objPuntosClaroClubNegocio.ValidaBloqueoBolsa(k_tipo_doc, _
                                                         k_num_doc, _
                                                         k_tipo_clie, _
                                                         k_tipo_doc2, _
                                                         k_estado, _
                                                         k_coderror, _
                                                         k_descerror)

            oLog.Log_WriteLog(oFile, idLog & " - " & "out k_tipo_doc2:" & k_tipo_doc2)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out k_estado:" & k_estado)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out k_coderror:" & k_coderror)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out k_descerror:" & k_descerror)

            If k_coderror = 0.0 Then
                If constVALBLOQUEOBOLSA = k_estado Then
                    bTieneReserva = True
                End If
            End If
            oLog.Log_WriteLog(oFile, idLog & " - " & "bTieneReserva:" & bTieneReserva)

            Return bTieneReserva
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR TieneReserva(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR TieneReserva(): " & ex.StackTrace.ToString())

            Return False
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin TieneReserva()")
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
            idLog = hidNroLinea.Value

            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio reservarPuntos()")
            Dim UsuarioProceso As String = "" ' Usuario Proceso

            Dim ID_CCLUB As String
            Dim TipoDocumento As String
            Dim NroDocumento As String
            Dim tipoClie As String
            TipoDocumento = hidTipoDocumento.Value
            NroDocumento = txtNumeroDocId.Text
            tipoClie = ConfigurationSettings.AppSettings("consTipoclie")
            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            ID_CCLUB = getCCLUB(TipoDocumento)
            Dim txId As String
            Dim errorCode As String
            Dim errorMsg As String

            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio bloquearPuntos()")
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inp ID_CCLUB: " & ID_CCLUB)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inp NroDocumento: " & NroDocumento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inp tipoClie: " & tipoClie)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inp UsuarioProceso: " & UsuarioProceso)

            objPuntosClaroClubNegocio.bloquearPuntos(ID_CCLUB, _
                                                     NroDocumento, _
                                                     tipoClie, _
                                                     UsuarioProceso, _
                                                     txId, _
                                                     errorCode, _
                                                     errorMsg)

            oLog.Log_WriteLog(oFile, idLog & " - " & "out txId:" & txId)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorCode:" & errorCode)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorMsg:" & errorMsg)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin bloquearPuntos()")
            If errorCode <> "0" Then
                Throw New Exception(errorMsg)
            End If

            ' Implementar la auditoría de reserva de puntos.
            Dim codTrs As String = ConfigurationSettings.AppSettings("codReservarPuntos")
            Dim descTrs As String = "Reservar Puntos Claro Club NroLinea: " & hidNroLinea.Value
            descTrs &= " ClaroClubPuntosUtilizar: " & txtClaroClubPuntosUtilizar.Text
            descTrs &= " ClaroClubSolesDeDescuento: " & txtClaroClubSolesDeDescuento.Text

            Auditoria(descTrs, codTrs)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR reservarPuntos(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR reservarPuntos(): " & ex.StackTrace.ToString())

            Throw ex
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin reservarPuntos()")
        End Try
    End Sub

    ' Efectua el desbloqueo de puntos Claro Club con un llamado a webservices.
    Public Function liberarPuntos(ByVal strNroSec As String) As String
        Dim idLog As String = strNroSec

        Try
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio liberarPuntos()")
            '''''''''''' Llamar al famoso WS
            Dim ID_CCLUB As String
            Dim TipoDocumento As String
            Dim NroDocumento As String
            Dim tipoClie As String
            TipoDocumento = hidTipoDocumento.Value
            NroDocumento = txtNumeroDocId.Text
            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            ID_CCLUB = getCCLUB(TipoDocumento)
            Dim txId As String
            Dim errorCode As String
            Dim errorMsg As String

            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio liberarPuntos()")
            tipoClie = ConfigurationSettings.AppSettings("consTipoclie")

            oLog.Log_WriteLog(oFile, idLog & " - " & "inp ID_CCLUB: " & ID_CCLUB)
            oLog.Log_WriteLog(oFile, idLog & " - " & "inp NroDocumento: " & NroDocumento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "inp tipoClie: " & tipoClie)

            objPuntosClaroClubNegocio.liberarPuntos(ID_CCLUB, _
                                                    NroDocumento, _
                                                    tipoClie, _
                                                    txId, _
                                                    errorCode, _
                                                    errorMsg)

            oLog.Log_WriteLog(oFile, idLog & " - " & "out txId:" & txId)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorCode:" & errorCode)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorMsg:" & errorMsg)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin liberarPuntos()")
            If errorCode <> "0" Then
                Throw New Exception(errorMsg)
            End If

            ' Implementar la auditoría de liberación de puntos.
            Dim codTrs As String = ConfigurationSettings.AppSettings("codLiberarPuntos")
            Dim descTrs As String = "Liberar Puntos Claro Club. NroSec:" & strNroSec
            Auditoria(descTrs, codTrs)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR liberarPuntos(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR liberarPuntos(): " & ex.StackTrace.ToString())
        End Try

        oLog.Log_WriteLog(oFile, idLog & " - " & "Fin liberarPuntos(): ")

        Return ""
    End Function

    ' Registra en el SISACT la operaciòn de canje de puntos Claro Club.
    Public Sub RegistrarCanjePuntos(ByVal facturaPedido As String, _
                                    ByVal documentoSAPNotaCredito As String, _
                                    ByVal documentoSAP As String)
        Dim idLog As String = facturaPedido

        Dim oPuntosClaroClub As New PuntosClaroClubNegocio
        Dim objCanjePuntos As New CanjePuntos
        objCanjePuntos.TIPO_DOC = hidTipoDocumento.Value
        objCanjePuntos.NUM_DOC = txtNumeroDocId.Text
        objCanjePuntos.NRO_DOC_SAP_NC = documentoSAP
        objCanjePuntos.PUNTOS_USADOS = Funciones.CheckDbl(txtClaroClubPuntosUtilizar.Text)
        objCanjePuntos.FACTOR_CONVERSION = Funciones.CheckDbl(hidFactorClaroClub.Value)
        objCanjePuntos.SOLES_DESCUENTO = Funciones.CheckDbl(txtClaroClubSolesDeDescuento.Text)
        objCanjePuntos.COD_PDV = hidOfVenta.Value
        ' Inicio SD_812077 
        ' código del asesor
        objCanjePuntos.USUARIO_REG = CurrentUser
        ' Fin SD_812077 
        objCanjePuntos.NRO_LINEA = Funciones.CheckDbl(txtNroLinea.Text)
        objCanjePuntos.DOCUMENTO_SAP = facturaPedido
        If hidIDCAMPANA.Value <> "" Then
            objCanjePuntos.IDCAMPANA = Funciones.CheckDbl(hidIDCAMPANA.Value)
        Else
            objCanjePuntos.IDCAMPANA = -1
        End If
        If hidTipoDocumento.Value <> "" Then
            objCanjePuntos.ID_CCLUB = Funciones.CheckDbl(getCCLUB(hidTipoDocumento.Value))
        Else
            objCanjePuntos.ID_CCLUB = -1
        End If
        objCanjePuntos.DESCRIPCION = ConfigurationSettings.AppSettings("constConstanciaDescripcionCC")

        ' Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
        If txtFechaIniCC.Text <> "" Then
            objCanjePuntos.CAMPANA_VIGENCIA_INI = txtFechaIniCC.Text
        End If
        If txtFechaFinCC.Text <> "" Then
            objCanjePuntos.CAMPANA_VIGENCIA_FIN = txtFechaFinCC.Text
        End If
        objCanjePuntos.SEGMENTO = txtSegmentoCC.Text

        If documentoSAPNotaCredito.Trim.Length > 0 Then
            objCanjePuntos.DOC_SAP_DSCTO_EQUIPO = documentoSAPNotaCredito
            objCanjePuntos.DSCTO_EQUIPO = Funciones.CheckDecimal(txtDescuentoEquipo.Text)
        End If
        ' Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos
        Try
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio RegistrarCanjePuntos()")

            ' Inicio SD_812077 
            oLog.Log_WriteLog(oFile, idLog & " - " & "USUARIO_REG: " & CurrentUser)
            oLog.Log_WriteLog(oFile, idLog & " - " & "NOM_ASESOR: " & Session("NOMBRECOMPLETO"))
            ' Fin SD_812077 
            ' Registrar los datos de la nota de crèdito y los puntos en el SISACT.
            oPuntosClaroClub.InsertarCanjePuntos2(objCanjePuntos)

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR Message(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR StackTrace(): " & ex.StackTrace.ToString())
        End Try

        oLog.Log_WriteLog(oFile, idLog & " - " & "Fin RegistrarCanjePuntos(): ")
    End Sub

    ' Fin PS - Automatización de canje y nota de crédito
    ' Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
    Private Sub ListarSaldosCC(ByRef objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse)
        Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)
        Dim puntos As Integer = 0

        If hidErrorCodeWSCC.Value = "0" AndAlso _
            Not objConsultarPuntosResponse Is Nothing AndAlso _
            Not objConsultarPuntosResponse.cursorSaldos Is Nothing Then
            Dim oBolsas As New ArrayList
            Dim saldosCC As New Hashtable

            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
            saldosCC.Add(bolsaCC(0), bolsaCC(1))
        Next i
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                Dim oCanjePuntos As New CanjePuntos
                oCanjePuntos.COD_BOLSA = objConsultarPuntosResponse.cursorSaldos(i).tipoCliente
                oCanjePuntos.DESCRIP_BOLSA = saldosCC.Item(oCanjePuntos.COD_BOLSA).ToString
                oCanjePuntos.PUNTOS_ASIGNADOS = objConsultarPuntosResponse.cursorSaldos(i).saldoTT
                puntos = puntos + Funciones.CheckInt(oCanjePuntos.PUNTOS_ASIGNADOS)

                oBolsas.Add(oCanjePuntos)
            Next i

            dgSaldosCC.DataSource = oBolsas
            dgSaldosCC.DataBind()
        End If

        txtClaroClubSaldoActual.Text = puntos.ToString
        txtClaroClubPuntosUtilizar.Text = puntos.ToString
    End Sub
    Private Sub VerVigenciaSegmento(ByRef objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse)
        Try
        If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
            If objConsultarPuntosResponse.curCampana(0).fecha_inicio.Trim.Length > 0 Then
                Dim fecha_inicio As String = objConsultarPuntosResponse.curCampana(0).fecha_inicio.Trim.Substring(0, 10)
                Dim vfechaInicio As String() = fecha_inicio.Split("-")
                txtFechaIniCC.Text = vfechaInicio(2) + "/" + vfechaInicio(1) + "/" + vfechaInicio(0)
                Else
                    txtFechaIniCC.Text = ""
            End If

            If objConsultarPuntosResponse.curCampana(0).fecha_fin.Trim.Length > 0 Then
                Dim fecha_fin As String = objConsultarPuntosResponse.curCampana(0).fecha_fin.Trim.Substring(0, 10)
                Dim vfechaFin As String() = fecha_fin.Split("-")
                txtFechaFinCC.Text = vfechaFin(2) + "/" + vfechaFin(1) + "/" + vfechaFin(0)
                Else
                    txtFechaFinCC.Text = ""
            End If
            Else
                txtFechaIniCC.Text = ""
                txtFechaFinCC.Text = ""
        End If

        If objConsultarPuntosResponse.codigoSegmento.Trim <> "" Then
            txtSegmentoCC.Text = objConsultarPuntosResponse.codigoSegmento.Trim.ToUpper
            Else
                txtSegmentoCC.Text = ""
        End If
        Catch ex As Exception
            txtFechaIniCC.Text = ""
            txtFechaFinCC.Text = ""
            txtSegmentoCC.Text = ""
        End Try
    End Sub
    Private Sub ConfigurarDatosDetalleDescuento(ByRef objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse)
        Dim factorConversion As Decimal
        Dim dtBase As New DataTable
        Dim orden As Integer = 1
        Dim bExiste As Boolean = False

        dtBase.Columns.Add(New DataColumn("NORMAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("PROMOCIONAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TOTAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TIPO_DE_DSCTO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("FACTOR", GetType(Integer)))
        dtBase.Columns.Add(New DataColumn("TIPO_CLIENTE", GetType(String)))
        dtBase.Columns.Add(New DataColumn("VALOR_SEGMENTO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("PUNTOS", GetType(String)))
        dtBase.Columns.Add(New DataColumn("ORDEN", GetType(Integer)))

        factorConversion = Funciones.CheckDecimal(objConsultarPuntosResponse.factorConversion)
        If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
            Dim cursorSaldo As ConsultarPuntosWS.CursorSaldosType

            ' Valor de conversión de puntos postpago.
            Dim constPOSTPAGO As String = ConfigurationSettings.AppSettings("constPOSTPAGO")
            Dim constTipoClientePOSTPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO")
            Dim PuntosPostCampaña As Integer = 1
            Dim PuntosPostSegmento As Integer = 1
            Dim FactorPost As Integer = 1
            Dim TipoDsctoPost As String
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                If objConsultarPuntosResponse.curCampana(i).tipo = constPOSTPAGO Then
                    PuntosPostCampaña = Funciones.CheckInt(objConsultarPuntosResponse.curCampana(i).valor)
                    Exit For
                End If
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePOSTPAGO Then
                    PuntosPostSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPostCampaña > PuntosPostSegmento) Then
                FactorPost = PuntosPostCampaña
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPost = PuntosPostSegmento
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPost As DataRow = dtBase.NewRow
            rowPost("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPost("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TIPO_DE_DSCTO") = TipoDsctoPost
            rowPost("FACTOR") = FactorPost
            rowPost("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPost("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPost("PUNTOS") = cursorSaldo.saldoTT
            rowPost("ORDEN") = orden
            If bExiste Then
            orden = orden + 1
            dtBase.Rows.Add(rowPost)
            End If
            bExiste = False

            ' Valor de conversión de puntos prepago.
            Dim constPREPAGO As String = ConfigurationSettings.AppSettings("constPREPAGO")
            Dim constTipoClientePREPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePREPAGO")
            Dim PuntosPreCampaña As Integer = 1
            Dim PuntosPreSegmento As Integer = 0
            Dim FactorPre As Integer = 1
            Dim TipoDsctoPre As String
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                If objConsultarPuntosResponse.curCampana(i).tipo = constPREPAGO Then
                    PuntosPreCampaña = Funciones.CheckInt(objConsultarPuntosResponse.curCampana(i).valor)
                    Exit For
                End If
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePREPAGO Then
                    PuntosPreSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPreCampaña > PuntosPreSegmento) Then
                FactorPre = PuntosPreCampaña
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPre = PuntosPreSegmento
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPre As DataRow = dtBase.NewRow
            rowPre("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPre("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TIPO_DE_DSCTO") = TipoDsctoPre
            rowPre("FACTOR") = FactorPre
            rowPre("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPre("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPre("PUNTOS") = cursorSaldo.saldoTT
            rowPre("ORDEN") = orden
            If bExiste Then
            orden = orden + 1
            dtBase.Rows.Add(rowPre)
            End If

            ' Los demás
            Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)
            Dim saldosCC As New Hashtable
            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
                saldosCC.Add(bolsaCC(0), bolsaCC(2))
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                ' Se evaluan aquellos que no son pre o postpago.
                If objConsultarPuntosResponse.curCampana(i).tipo <> constPOSTPAGO AndAlso objConsultarPuntosResponse.curCampana(i).tipo <> constPREPAGO Then
                    For j As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                        Dim tipo As String = saldosCC(objConsultarPuntosResponse.cursorSaldos(j).tipoCliente).ToString.Trim
                        If tipo = objConsultarPuntosResponse.curCampana(i).tipo.Trim Then
                            Dim rowOtros As DataRow = dtBase.NewRow
                            rowOtros("NORMAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion
                            rowOtros("PROMOCIONAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                            rowOtros("TOTAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                            rowOtros("TIPO_DE_DSCTO") = TipoDsctoPost
                            rowOtros("FACTOR") = FactorPost
                            rowOtros("TIPO_CLIENTE") = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                            rowOtros("VALOR_SEGMENTO") = objConsultarPuntosResponse.cursorSaldos(j).valorSegmento
                            rowOtros("PUNTOS") = objConsultarPuntosResponse.cursorSaldos(j).saldoTT
                            rowOtros("ORDEN") = orden
                            orden = orden + 1
                            dtBase.Rows.Add(rowOtros)
                        End If
                    Next j
                End If
            Next i
        Else
            Dim cursorSaldo As ConsultarPuntosWS.CursorSaldosType

            ' Valor de conversión de puntos postpago.
            Dim constPOSTPAGO As String = ConfigurationSettings.AppSettings("constPOSTPAGO")
            Dim constTipoClientePOSTPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO")
            Dim PuntosPostCampaña As Integer = 1
            Dim PuntosPostSegmento As Integer = 1
            Dim FactorPost As Integer = 1
            Dim TipoDsctoPost As String

            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePOSTPAGO Then
                    PuntosPostSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPostCampaña > PuntosPostSegmento) Then
                FactorPost = PuntosPostCampaña
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPost = PuntosPostSegmento
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPost As DataRow = dtBase.NewRow
            rowPost("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPost("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TIPO_DE_DSCTO") = TipoDsctoPost
            rowPost("FACTOR") = FactorPost
            rowPost("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPost("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPost("PUNTOS") = cursorSaldo.saldoTT
            rowPost("ORDEN") = orden
            If bExiste Then
            orden = orden + 1
            dtBase.Rows.Add(rowPost)
            End If
            bExiste = False

            ' Valor de conversión de puntos prepago.
            Dim constPREPAGO As String = ConfigurationSettings.AppSettings("constPREPAGO")
            Dim constTipoClientePREPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePREPAGO")
            Dim PuntosPreCampaña As Integer = 1
            Dim PuntosPreSegmento As Integer = 0
            Dim FactorPre As Integer = 1
            Dim TipoDsctoPre As String
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePREPAGO Then
                    PuntosPreSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPreCampaña > PuntosPreSegmento) Then
                FactorPre = PuntosPreCampaña
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPre = PuntosPreSegmento
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPre As DataRow = dtBase.NewRow
            rowPre("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPre("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TIPO_DE_DSCTO") = TipoDsctoPre
            rowPre("FACTOR") = FactorPre
            rowPre("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPre("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPre("PUNTOS") = cursorSaldo.saldoTT
            rowPre("ORDEN") = orden
            If bExiste Then
            orden = orden + 1
            dtBase.Rows.Add(rowPre)
            End If

            ' Los demás
            Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)
            Dim saldosCC As New Hashtable
            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
                saldosCC.Add(bolsaCC(0), bolsaCC(2))
            Next i
                ' Se evaluan aquellos que no son pre o postpago.
            For j As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                Dim tipoCliente As String = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                If tipoCliente <> constTipoClientePOSTPAGO AndAlso tipoCliente <> constTipoClientePREPAGO Then
                    Dim rowOtros As DataRow = dtBase.NewRow
                    rowOtros("NORMAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion
                    rowOtros("PROMOCIONAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                    rowOtros("TOTAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                    rowOtros("TIPO_DE_DSCTO") = TipoDsctoPost
                    rowOtros("FACTOR") = FactorPost
                    rowOtros("TIPO_CLIENTE") = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                    rowOtros("VALOR_SEGMENTO") = objConsultarPuntosResponse.cursorSaldos(j).valorSegmento
                    rowOtros("PUNTOS") = objConsultarPuntosResponse.cursorSaldos(j).saldoTT
                    rowOtros("ORDEN") = orden
                    orden = orden + 1
                    dtBase.Rows.Add(rowOtros)
                End If
            Next j
        End If

        If dtBase.Rows.Count > 0 Then
            Dim qs As New StringBuilder
            Dim total As Decimal = 0.0
            Dim puntos As Integer = 0

            For Each dr As DataRow In dtBase.Rows
                qs.Append(dr.Item("NORMAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("PROMOCIONAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TOTAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TIPO_DE_DSCTO").ToString())
                qs.Append("|")
                qs.Append(dr.Item("FACTOR").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TIPO_CLIENTE").ToString())
                qs.Append("|")
                qs.Append(dr.Item("VALOR_SEGMENTO").ToString())
                qs.Append("|")
                qs.Append(dr.Item("PUNTOS").ToString())
                qs.Append("|")
                qs.Append(dr.Item("ORDEN").ToString())
                qs.Append("~")
                puntos = puntos + Funciones.CheckInt(dr.Item("PUNTOS").ToString())
                total = total + Funciones.CheckDecimal(dr.Item("TOTAL").ToString())
            Next dr
            qs.Append(Math.Ceiling(total).ToString("n2"))

            txtClaroClubPuntosUtilizar.Text = txtClaroClubSaldoActual.Text
            txtClaroClubSolesDeDescuento.Text = Math.Ceiling(total).ToString("n2")
            hidClaroClubSolesDeDescuento.Value = Math.Ceiling(total).ToString("n2")
            hidDetalleDescuento.Value = qs.ToString
        End If
    End Sub
    ' Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos
    ' Fin E77568

    Private Sub CargarHidden()
        'Mostrar Area1
        Dim focus As String = hidItemSeleccionado.Value
        Dim strComando As String = "<script>MostrarArea1(true);" + _
                                    "siguiente();" + _
                                    "setFocus('" + focus + "');" + _
                                    " </script>"
        RegisterStartupScript("script", strComando)

        'Area  Busqueda
        txtNroLinea.Text = hidNroLinea.Value.ToString
        ddlTipoDocId.SelectedValue = hidTipoDocumento.Value.ToString
        txtNumeroDocId.Text = hidNroDocumento.Value.ToString


    End Sub

    Private Sub Consultar()
        Dim nroLinea As String = CheckStr(txtNroLinea.Text)
        Dim strScript As String
        Try
            'gaa20160607
            Dim strB2E As String = ConfigurationSettings.AppSettings("strPostTipClienteB2E")
            Dim datosLinea As ClienteBSCS = Session("Cliente")
            'If ConfigurationSettings.AppSettings("constFlagClaroClub") = "1" Then
            If ConfigurationSettings.AppSettings("constFlagClaroClub") = "1" AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
                ' Inicio E77568
                ' Inicio PS - Automatización de canje y nota de crédito
                Dim TipoDocumento As String = hidTipoDocumento.Value
                Dim NumeroDocId As String = txtNumeroDocId.Text
                CargarDatosDePuntoClaroClub(TipoDocumento, NumeroDocId)
                ' Fin PS - Automatización de canje y nota de crédito
                ' Fin E77568
            End If


            'REGISTRAR AUDITORIA AL CONSULTAR LINEA
            auditoriaConsultar()

            Session("UsuarioValidadorDescuento") = ""

           
            If LeerDatosLinea(nroLinea) Then
                'Consultar Tipo Documento de Venta
                ConsultarTipoDocVenta()
                strScript = "<script>validaFlujo('" + "OK" + "');</script>"
            Else
                strScript = "<script>HabilitarBusqueda(); </script>"
            End If

            RegisterStartupScript("script", strScript)

        Catch ex As Exception

            hidMsg.Value = String.Format("Error. Consulta Datos Cliente. {0}", ex.Message)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception LeerDatosLinea() - Mensaje: " & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin LeerDatosLinea()")
        End Try
    End Sub

    Private Function auditoriaConsultar()
        'REGISTRAR AUDITORIA AL CONSULTAR PEDIDO
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
        Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_CONS_RENV_POST")

        'Documento de identidad, número de telefono, punto de venta, vendedor)
        Dim desAuditoria As String = "Se realiza Consulta para Renovación Equipo Postpago CAC. " & _
                        " ( Tipo de Documento: " & hidTipoDocumento.Value & _
                        " | Numero de Identidad: " & hidNroDocumento.Value & _
                        " | Nro de Telefono: " & hidNroLinea.Value & _
                        " | Punto de venta:" & hidOfVenta.Value & _
                        " | Vendedor: " & CheckStr(CheckStr(Session("CodVendedorSAP"))) & " )"

        Auditoria(desAuditoria, strCodTrans)
    End Function

    Private Function auditoriaOCC()
        'REGISTRAR AUDITORIA AL GRABAR PEDIDO
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
        Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_GRABAR_OCC")


        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio auditoriaOCC()")

        Dim desAuditoria As String = "Se genera OCC por Renovación Equipo Postpago CAC. " & _
                        " ( Tipo de Documento: " & hidTipoDocumento.Value & _
                        " | Numero de Identidad: " & hidNroDocumento.Value & _
                        " | Nro de Telefono: " & hidNroLinea.Value & _
                        " | Punto de venta:" & hidOfVenta.Value & _
                        " | Vendedor: " & CheckStr(Session("CodVendedorSAP")) & _
                        " | Contrato:" & hidCO.Value & _
                        " | Tipo AjusteOCCXReclamos :" & "AjustesXReclamos" & _
                        " | Monto OCC:" & hidReintegro.Value & " )"

        Auditoria(desAuditoria, strCodTrans)

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin auditoriaOCC()")
    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean

        strIdentifyLog = nroLinea
        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim oVentaExpress As New VentaExpressNegocios

        Dim mensajeError As String = ""
        Dim datosLinea As ClienteBSCS = Nothing

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio LeerDatosCliente(): " & ConfigurationSettings.AppSettings("RutaWS_DatosPostpago"))

        datosLinea = oPostpagoNegocios.LeerDatosCliente(nroLinea, "", mensajeError)

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin LeerDatosCliente()  (output) -> mensajeError:" & mensajeError)


        If IsNothing(datosLinea) Then
            oLog.Log_WriteLog(oFile, strIdentifyLog & "-  Datos Linea es vacio")
            hidMsg.Value = "La línea no es Postpago."
            Return False
        End If


        Dim strConsumer As String = ConfigurationSettings.AppSettings("strPostTipClienteConsumer")
        If (UCase(datosLinea.Tipo_cliente) <> UCase(strConsumer)) Then
            hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCliNoComsumer")
            Return False
        End If


        'VALIDAR TITULARIDAD DE LA LINEA
        If ddlTipoDocId.SelectedItem.Text = "RUC" Then

            If txtNumeroDocId.Text <> datosLinea.Ruc_dni.Trim Then
                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaDNICli")
                Return False
            End If
        ElseIf ddlTipoDocId.SelectedValue = ConfigurationSettings.AppSettings("ConstTipoDocCE") Then

            If txtNumeroDocId.Text <> datosLinea.Ruc_dni.Trim Then
                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaDNICli")
                Return False
            End If
        Else
            If ddlTipoDocId.SelectedItem.Text <> datosLinea.Tip_doc Or txtNumeroDocId.Text <> datosLinea.Num_doc.Trim Then
                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoLineaDNICli")
                Return False
            End If
        End If


        'Almacenar Datos del Cliente
        Session("Cliente") = datosLinea

        'Validar estado de la linea este Activo y que no se encuentre bloqueada
        Try
            Dim estadoContrato As String
            Dim estadoBloqueo As String

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio ConsultaStatusContrato()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- datosLinea.Co_id:" & datosLinea.Co_id)

            Dim objVentaNegocios As VentaNegocios = New VentaNegocios

            If (objVentaNegocios.ConsultaStatusContrato(datosLinea.Co_id, estadoContrato, estadoBloqueo)) Then

                oLog.Log_WriteLog(oFile, strIdentifyLog & "- estadoContrato:" & estadoContrato)
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- estadoBloqueo:" & estadoBloqueo)

                If (estadoContrato.ToUpper.Trim.Equals("A") <> True) Then
                    hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCACCliDeuda")
                    Return False
                End If

                If (estadoBloqueo.ToUpper.Trim.Equals("A") = True Or estadoBloqueo.ToUpper.Trim.Equals("O") = True) Then
                    hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCACCliDeuda")
                    Return False
                End If

            End If

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Eception ConsultaStatusContrato() Mensaje:" & ex.Message)
            Throw New Exception("Error al Consultar Estado del Contrato." & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin ConsultaStatusContrato()")
        End Try


        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio Get_ConsultaCierreCaja")
        'CONSULTA SI EL CIERRE YA SE HA REALIZADO EN  LA OFICINA DE VENTA 
        Dim oConsultaSap As New SapGeneralNegocios
        Dim cierreRealizado As String
        oConsultaSap.Get_ConsultaCierreCaja(hidOfVenta.Value, Date.Now.ToShortDateString, cierreRealizado)
        If cierreRealizado = "S" Then
            hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoCierreOficina")
            Return False
        End If

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin Get_ConsultaCierreCaja")

        'DATO EXTRA EXTRA NECESARIO PARA OBTENER FECHA DE APLICACION DE OCC
        hidCicloFact.Value = CheckStr(datosLinea.Ciclo_fac)
        hidCO.Value = CheckStr(datosLinea.Co_id)

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio validaAPADECE()")
        'Valida APADECE
        hidFlagRenovacionAdelantada.Value = "false"
        Dim flagValidaApadece As Boolean

        Try
            flagValidaApadece = oVentaExpress.validaAPADECE(datosLinea.Co_id)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception validaAPADECE()" & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin validaAPADECE()")
        End Try


        If Not flagValidaApadece Then

            Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelMeses")
            Dim fechaInicioApadece As DateTime '= DateAdd(DateInterval.Month, -5, DateTime.Now())
            Dim fechaFinApadece As DateTime '= DateTime.Now
            Dim mesesPorVencer As Integer
            Dim montoReintegro As Double


            'CONSULTAR APADECE

            Dim objAcuerdo = New AcuerdoApadece
            Try
                objAcuerdo = oVentaExpress.ConsultarAPADECE(hidNroLinea.Value) ' numero de prueba "987111019"
            Catch ex As Exception
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception validaAPADECE()" & ex.Message)
            Finally
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin validaAPADECE()")
            End Try


            If Not objAcuerdo Is Nothing Then

                'FECHA INICIO APADECE
                hidFechaInicioApadece.Value = objAcuerdo.FECHA_INICIO
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- objAcuerdo.FECHA_INICIO :" & objAcuerdo.FECHA_INICIO)
                'FECHA FIN APADECE
                hidFechaFinApadece.Value = objAcuerdo.FECHA_FIN
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- objAcuerdo.FECHA_FIN :" & objAcuerdo.FECHA_FIN)
                'NUMERO DE MESES RESANTES PARA VENCER APADECE
                mesesPorVencer = objAcuerdo.NRO_MESES_PENDIENTE
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- mesesPorVencer :" & mesesPorVencer)

                hidMesesPorVencerApadece.Value = mesesPorVencer

                'MONTO DE REINTEGRO POR RENOVAR EQUIPO ANTES DE CULMINAR EL APADECE
                If mesesPorVencer > 0 Then
                    montoReintegro = objAcuerdo.MONTO_REINTEGRO
                Else
                    montoReintegro = 0
                End If

                hidFlagConfExoneracionReintegro.Value = "false"

                If (montoReintegro > 0) Then
                    'Si tiene Reintegro
                    hidFlagReintegro.Value = "true"

                    hidReintegro.Value = Math.Round(montoReintegro, 2).ToString()
                Else
                    'No tiene Reintegro
                    hidFlagReintegro.Value = "false"
                End If

            Else
                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoAPEDECEMaxMeses")
                Return False
            End If


            If mesesPorVencer > 0 Then

                Dim sPerfilDeAutorizacion As String = ""
                Dim strPerfilCodigo As String

                Dim obj As New NivelAprobacionNegocio

                Dim strScript As String

                Try

                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio ObtenerPerfilPorMonto()")

                    If obj.ObtenerPerfilPorMonto(strTipo, mesesPorVencer, strPerfilCodigo, sPerfilDeAutorizacion) Then

                        oLog.Log_WriteLog(oFile, strIdentifyLog & "- intPerfilCodigo :" & strPerfilCodigo)
                        oLog.Log_WriteLog(oFile, strIdentifyLog & "- sPerfilDeAutorizacion :" & sPerfilDeAutorizacion)

                        If (strPerfilCodigo = "-1") Then
                            hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoAPEDECEMaxMeses")
                            Return False
                        Else

                            hidFlagRenovacionAdelantada.Value = "true"

                            'VALIDAR REINTEGRO  - LAS SIGUIENTES DOS LINEAS SE DEBEN BORRRAR
                            'obtenerFechaAplicacion()
                            'cargarReintegroApadece()

                        End If

                    Else
                        hidMsg.Value = "Error al consultar Nivel de Aprobacion por APADECE."
                        Return False
                    End If

                Catch ex As Exception

                    Throw New Exception("Exception APADECE Mensaje1: " & ex.Message)

                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception ObtenerPerfilPorMonto()- Mensaje: " & ex.Message)
                    hidMsg.Value = ex.Message
                    Return False

                Finally
                    oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin ObtenerPerfilPorMonto()")
                End Try

            Else
                hidFlagReintegro.Value = "false"
                hidFlagRenovacionAdelantada.Value = "false"

            End If

        Else

            'VALIDAR QUE SI NO TIENE APADECE SU LINEA TENGA MAS DE 6 MESES ACTIVA
            Dim mesesTranscurridos As Long

            mesesTranscurridos = DateDiff(DateInterval.Month, datosLinea.Fecha_act, DateTime.Now)
            If (mesesTranscurridos <= Long.Parse(ConfigurationSettings.AppSettings("constNumMesesPermitidosParaRenovacion"))) Then

                hidMsg.Value = ConfigurationSettings.AppSettings("msjErrorRevPoAcuerdoLibre")
                Return False
            Else
                hidFlagRenovacionAdelantada.Value = "false"
            End If

        End If

        'EXTRAS
        hidPlanAct.Value = CheckStr(oPostpagoNegocios.obtenerIMSI(datosLinea.Co_id, mensajeError)).Split(";"c)(1)
        hidLimiteCred.Value = CheckStr(datosLinea.Limite_credito)


        hidModalidad.Value = CheckStr(datosLinea.Modalidad)
        hidCuenta.Value = CheckStr(datosLinea.Cuenta)
        hidNumeroDocumento.Value = CheckStr(datosLinea.Num_doc)
        hidCustumerId.Value = CheckStr(datosLinea.CustomerId)


        hidApellidosCli.Value = UCase(CheckStr(datosLinea.Apellidos))
        hidNombresCli.Value = UCase(CheckStr(datosLinea.Nombre))

        hidTitular.Value = UCase(CheckStr(datosLinea.Nombre & " " & datosLinea.Apellidos))
        hidRepresentante.Value = datosLinea.Rep_legal

        'DATOS DEL CLIENTE
        hidNomCli.Value = UCase(CheckStr(datosLinea.Nombre & " " & datosLinea.Apellidos))
        hidTipoCli.Value = UCase(CheckStr(datosLinea.Tipo_cliente))
        hidTelefonoReferencia.Value = CheckStr(datosLinea.Telef_principal)


        'DATOS DE A LINEA
        hidIMSI.Value = CheckStr(oPostpagoNegocios.obtenerIMSI(datosLinea.Co_id, mensajeError)).Split(";"c)(0)

        'DATOS DE FACTURACIÓN
        hidDireccion.Value = CheckStr(datosLinea.Direccion_fac)
        hidDepartamento.Value = CheckStr(datosLinea.Departamento_fac)
        hidProvincia.Value = CheckStr(datosLinea.Provincia_fac)
        hidDistrito.Value = CheckStr(datosLinea.Distrito_fac)
        hidCorreo.Value = CheckStr(datosLinea.Email)


        Return True
    End Function

    Private Sub ddlCodEquipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCodEquipo.SelectedIndexChanged

        If ddlCodEquipo.SelectedValue.ToString.Length >= 10 Then
            Dim strMaterial As String = ddlCodEquipo.SelectedValue.ToString.Substring(0, 10)
            Dim strNroTelef As String = String.Empty
            Dim strPuntoVenta As String = hidOfVenta.Value.Trim
            CargaIMEIS(strMaterial, strNroTelef, strPuntoVenta)
        Else
            txtCodEquipo.Text = String.Empty
            ddlSerieEquipo.Items.Clear()
        End If

    End Sub

    Private Sub ObtenerPerfiles()
        Try
            Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
            Dim ctaRed As String = Me.CurrentUser

            'Validar Cuenta de Red Usuario
            If CheckStr(ctaRed).Equals(String.Empty) Then
                Throw New Exception("Cuenta de Red del Usuario. [" & ctaRed & "]")
            End If

            Dim oUsuario As New Usuario
            Dim codUsuario As Integer
            'Obtener Codigo Usuario Sisact
            Try
                Dim objMaestro As New MaestroNegocio
                oUsuario = objMaestro.ObtenerUsuarioLogin(ctaRed)
                codUsuario = CheckInt(oUsuario.UsuarioId)
                If codUsuario = 0 Then
                    Throw New Exception("Codigo Usuario Sisact. [" & codUsuario & "]")
                End If
            Catch ex As Exception
                oLog.Log_WriteLog(oFile, "Exception ObtenerUsuarioLogin " & ex.Message)
            End Try
            'Consultar Punto de Venta asociado al Usuario
            Dim listaOficinas As ArrayList = (New VentaNegocios).ListaPDVUsuario(codUsuario, "")
            If IsNothing(listaOficinas) OrElse listaOficinas.Count = 0 Then
                Throw New Exception("Lista de Punto de Venta asociado al Usuario.")
            End If

            'Guardar los datos generales de Venta
            Dim oPuntoVenta As PuntoVenta = CType(listaOficinas(0), PuntoVenta)
            If IsNothing(oPuntoVenta) Then
                Throw New Exception("No tiene Punto de Venta asociado al Usuario.")
            End If

            'Validar si el usuario NO pertenece a un DAC o Cadena
            Dim strCanal As String = oPuntoVenta.TOFIC_CODIGO
            If Not strCanal = "01" Then
                Throw New Exception("El canal del Usuario no pertenece a un CAC.")
            End If

            'Asignación Oficina
            hidOfVenta.Value = CheckStr(oPuntoVenta.OVENC_CODIGO)

        Catch ex As Exception
            Throw New Exception("Error. Consulta Datos del Vendedor." & ex.Message)
        End Try
    End Sub

    Private Sub CargarTipoDocumento()
        Dim lista As ArrayList = (New VentaNegocios).ListaTipoDocumento("")
        'Remuevo los item de CIP y PASAPORTE segun PS
        lista.RemoveRange(3, 1)
        lista.RemoveRange(1, 1)
        ' Inicio E77568
        ' Inicio PS - Automatización de canje y nota de crédito.
        ' Guarda en un control oculto los códigos de los tipos de documentos para PuntosCC
        Dim sbTipoDocumento As New StringBuilder
        For Each item As ItemGenerico In lista
            sbTipoDocumento.Append(item.Codigo)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.Codigo2)
            sbTipoDocumento.Append("|")
        Next item
        sbTipoDocumento.Remove(sbTipoDocumento.Length - 1, 1)
        hidTipoDocumentos.Value = sbTipoDocumento.ToString
        ' Fin PS - Automatización de canje y nota de crédito.
        ' Fin E77568

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        Dim oItemTemp As New ItemGenerico

        oItemTemp = lista(1)
        lista(1) = lista(2)
        lista(2) = oItemTemp

        LlenaCombo(lista, ddlTipoDocId, "Codigo", "Descripcion")
    End Sub

    Private Sub CargarArticuloIMEI()
        Dim lista As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim tipoVenta As String = hidTipoVenta.Value

        'hidOfVenta.Value = "0006" '"S025" ' "D016"

        lista = (New SapGeneralNegocios).get_ConsultaMaterial(Now.ToString("yyyy/MM/dd"), "", tipoVenta, hidOfVenta.Value, "")

        For Each it As ItemGenerico In lista
            If CheckStr(it.Codigo).StartsWith("PB") Then
                listaMaterial.Add(it)
            End If
        Next

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        listaMaterial.Insert(0, oItem)
        LlenaCombo(listaMaterial, ddlCodEquipo, "Codigo", "Descripcion")
    End Sub

    Public Sub CargaIMEIS(ByVal strMaterial As String, ByVal strNroTelef As String, ByVal strPuntoVenta As String)
        Dim usuario_id As String = CurrentUser
        'Dim lista As ArrayList = (New SapGeneralNegocios).get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef)
        Dim lista As ArrayList = (New SansNegocio).get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef, usuario_id)
        Dim oItem As New ItemGenerico(ConfigurationSettings.AppSettings("Seleccionar"), ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        ddlSerieEquipo.Items.Clear()
        LlenaCombo(lista, ddlSerieEquipo, "Codigo", "Codigo")
        ddlSerieEquipo.Attributes.Add("onChange", "cargarSerieEquipo();")
    End Sub

    Private Sub CargarCampanias()
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim lista As ArrayList = (New SapGeneralNegocios).Get_ConsultaCampana(Now.ToString("yyyy/MM/dd"), tipoVenta)

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        LlenaCombo(lista, ddlCampania, "Codigo", "Descripcion")
    End Sub

    Private Sub CargarPlan()
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")

        Dim listaPlan As ArrayList = (New SapGeneralNegocios).Get_ConsultaPlanTarifario(tipoCliente, "", tipoVenta, "")
        Dim oItem As New Plan(0, ConfigurationSettings.AppSettings("Seleccionar"))
        listaPlan.Insert(0, oItem)
        LlenaCombo(listaPlan, ddlPlanTarifario, "PLANC_CODIGO", "PLANV_DESCRIPCION")

    End Sub

    Private Sub CargarPlazoAcuerdo()
        Dim strPlazoAcuerdo As String = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")
        Dim confPlazoAcuerdo As String() = CheckStr(ConfigurationSettings.AppSettings("constPlazoAcuerdoConfCAC")).Split(","c)
        Dim listaPlazoAcuerdoTotal As ArrayList = (New MaestroNegocio).ListadoPlazoAcuerdo()
        Dim listaPlazoAcuerdo As New ArrayList

        For i As Integer = 0 To confPlazoAcuerdo.Length - 1
            For Each item As ItemGenerico In listaPlazoAcuerdoTotal

                If confPlazoAcuerdo(i) = CheckStr(item.Codigo) Then
                    listaPlazoAcuerdo.Add(New ItemGenerico(CheckStr(item.Codigo), CheckStr(item.Descripcion)))
                End If
            Next
        Next

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        listaPlazoAcuerdo.Insert(0, oItem)
        LlenaCombo(listaPlazoAcuerdo, ddlPlazoAcuerdo, "Codigo", "Descripcion")

    End Sub

    Private Sub ConsultarTipoDocVenta()
        Dim dsClasePedido As New DataSet
        Dim oficina As String = hidOfVenta.Value
        Dim tipoDocCliente As String = hidTipoDocumento.Value

        dsClasePedido = (New SapGeneralNegocios).ConsultarTipoDocumentoOfVenta(hidOfVenta.Value)
        Dim listaTipoDocVenta() As String = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos" & tipoDocCliente).Split(CChar(","))

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
    End Sub

    Private Sub GenerarPedido()

        Dim strScript As String = ""

        Dim cadenaCabecera As String
        Dim cadenaDetalle As String
        Dim cadenaAcuerdo As String


        Dim oConsultaSap As New SapGeneralNegocios
        strIdentifyLog = hidNroLinea.Value()

        Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal

        Try


            'If Not validarClienteSap() Then
            '    Exit Sub
            'End If

            'GENERAR PARAMETROS PEDIDO
            cadenaCabecera = GenerarCadenaCabecera()
            cadenaDetalle = GenerarCadenaDetalle()
            cadenaAcuerdo = GenerarCadenaAcuerdo()


            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio Generar Pedido")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Cabecera : " & cadenaCabecera)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Detalle  : " & cadenaDetalle)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Acuerdo  : " & cadenaAcuerdo)


            'REALIZAR PEDIDO -  GRABAR PEDIDO SAP
            Dim pedidoGenerado As Boolean = oConsultaSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", cadenaAcuerdo, entrega, factura, _
            nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> nroContrato: " & nroContrato)

            If Not pedidoGenerado Then
                Throw New Exception("No se pudo Generar el Pedido en Sap.")
            Else

                'GRABAR PEDIDO EN SISACT
                Dim DetalleRenovSap As Boolean
                DetalleRenovSap = GenerarDetalleRenovSap(factura, nroContrato, nroPedido)
                If DetalleRenovSap Then

                    hidNroPedido.Value = nroPedido
                    hidnroContrato.Value = nroContrato

                    Dim documentoSAPNotaCredito As String = ""

                    'GENERAR NOTA DE CREDITO POR DESCUENTO EN EQUIPO.
                    If hidFlagDescuento.Value = "true" And hidDescuento.Value <> "" Then

                        Try
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GenerarNotaCredito() ")
                            GenerarNotaCredito(documentoSAPNotaCredito)
                        Catch ex As Exception
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Exception GenerarNotaCredito() - Mensaje: " & ex.Message)

                            'Rollback Renovacion de Equipo Postpago SISACT
                            'Eliminar Pedido SISACT
                            EliminarPedidoSISACT(factura)
                            'Eliminar Pedido SAP
                            RollBackVenta(factura)
                            Throw ex
                        Finally
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GenerarNotaCredito() ")
                        End Try

                    End If

                    ' Inicio E77568
                    ' Inicio PS - Automatización de canje y nota de crédito
                    Dim documentoSAPNotaCreditoCC As String
                    If Funciones.CheckDbl(txtDescuentoClaroClub.Text) > 0 Then
                        Try

                            ' Hacer Reserva Puntos CC
                            bloquearPuntos()

                            ' Generar Nota de Crédito Puntos Claro club
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GenerarNotaCreditoCC() ")
                            ' factura = nro doc SAP, de oConsultaSap.RealizarPedido().
                            GenerarNotaCreditoCC(factura, _
                                                 documentoSAPNotaCredito, _
                                                 documentoSAPNotaCreditoCC)

                        Catch ex As Exception
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Exception GenerarNotaCreditoCC() - Mensaje: " & ex.Message)

                            'Rollback Renovacion de Equipo Postpago SISACT
                            'Eliminar Pedido SISACT
                            EliminarPedidoSISACT(factura)
                            'Eliminar Pedido SAP
                            RollBackVenta(factura)

                            liberarPuntos(factura)

                            RollBackVenta(documentoSAPNotaCreditoCC)

                            Throw ex
                        Finally
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GenerarNotaCreditoCC() ")
                        End Try
                    End If
                    ' Fin PS - Automatización de canje y nota de crédito
                    ' Fin E77568

                    'GENERAR OCC
                    If hidFlagReintegro.Value = "true" And hidFlagExonerarReintegro.Value = "false" Then

                        Try
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GenerarOCC() ")

                            GenerarOCC()

                        Catch ex As Exception
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Exception GenerarOCC() - Mensaje: " & ex.Message)

                            'Rollback Renovacion de Equipo Postpago SISACT
                            'Eliminar Pedido SISACT
                            EliminarPedidoSISACT(factura)
                            'Eliminar Pedido SAP
                            RollBackVenta(factura)
                            'Elimkinar Nota de Credito
                            RollBackVenta(documentoSAPNotaCredito)

                            ' Inicio E77568
                            ' Inicio PS - Automatización de canje y nota de crédito
                            liberarPuntos(factura)

                            RollBackVenta(documentoSAPNotaCreditoCC)
                            ' Fin PS - Automatización de canje y nota de crédito
                            ' Fin E77568
                            Throw ex
                        Finally
                            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GenerarOCC() ")
                        End Try

                    End If


                    'REGISTRAR AUDITORIA AL GRABAR PEDIDO
                    Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
                    Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
                    Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_GRABAR_RENOV_POST")

                    Dim desAuditoria As String = "Ped. OK" & _
                                    "( Punto de venta:" & hidOfVenta.Value & _
                                    " | Vendedor: " & CheckStr(CheckStr(Session("CodVendedorSAP"))) & _
                                    " | Nro de Telefono: " & hidNroLinea.Value & _
                                    " | Tipo de Documento: " & hidTipoDocumento.Value & _
                                    " | Numero de Identidad: " & hidNroDocumento.Value & _
                                    " | Numero IMEI: " & ddlSerieEquipo.SelectedItem.Value & _
                                    " | Código de Material: " & txtCodEquipo.Text & _
                                    " | Tipo de Venta: " & tipoVenta & _
                                    " | Tipo de Operacion: " & tipoOperacion & ")"

                    Auditoria(desAuditoria, strCodTrans)

                    strScript = "validarFlujoGenerarPedido('OK');"
                    RegisterStartupScript("script", "<script>" & strScript & "</script>")
                Else

                    hidMsg.Value = "Error. Generar Pedido. Debido a que no se pudo crear pedido en SISACT."
                    strScript = "validarFlujoGenerarPedido('ERROR');"
                    RegisterStartupScript("script", "<script>" & strScript & "</script>")

                End If


            End If

        Catch ex As Exception

            'Eliminar Pedido SAP
            RollBackVenta(factura)

            hidMsg.Value = "Error. Generar Pedido. " & ex.Message
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Error  --> GenerarPedido: " & ex.Message)

            strScript = "validarFlujoGenerarPedido('ERROR');"
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Finally
            Session("UsuarioValidadorDescuento") = ""
            oConsultaSap = Nothing
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin Generar Pedido")
        End Try

    End Sub

    Private Function GenerarNotaCredito(ByRef documentoSAP As String) As Boolean

        oLog.Log_WriteLog(oFile, strIdentifyLog & " - Inicio GenerarNotaCredito()")

        Dim retorno As Boolean = False

        'GENERAR NOTA DE CREDITO
        Dim montoDescuento As Double = Double.Parse(hidDescuento.Value)
        Try

            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Inicio GenerarProcesoNotaCredito()")

            GenerarProcesoNotaCredito(montoDescuento, documentoSAP)

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Exception GenerarNotaCredito()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Exception. Generar Nota de Crédito - " & ex.Message)

            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Fin GenerarNotaCredito()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Fin GenerarNotaCredito()")
        End Try

    End Function

    ' Inicio E77568
    ' Inicio PS - Automatización de canje y nota de crédito
    ' Nota de crédito Puntos Claro Club
    Private Function GenerarNotaCreditoCC(ByVal facturaPedido As String, _
                                          ByVal documentoSAPNotaCredito As String, _
                                          ByRef documentoSAP As String) As Boolean

        Dim retorno As Boolean = False
        Try
            ' GENERAR NOTA DE CREDITO CC
            Dim montoDescuento As Double = Double.Parse(Me.txtDescuentoClaroClub.Text)

            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Inicio GenerarNotaCreditoCC()")

            GenerarProcesoNotaCreditoCC(facturaPedido, _
                                        montoDescuento, _
                                        documentoSAPNotaCredito, _
                                        documentoSAP)

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Exception GenerarNotaCreditoCC()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Exception. Generar Nota de Crédito - " & ex.Message)

            Throw New Exception("No se pudo Generar la Nota de Crédito Puntos Claro Club.")
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Fin GenerarNotaCreditoCC()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & " - Fin GenerarNotaCreditoCC()")
        End Try

    End Function

    ' Genera Nota de crédito cuando se trata de un descuento por Puntos Claro Club
    Private Sub GenerarProcesoNotaCreditoCC(ByVal facturaPedido As String, _
                                            ByVal v_montodescuento As Double, _
                                            ByVal documentoSAPNotaCredito As String, _
                                            ByRef documentoSAP As String)

        Dim cadenaCabecera As String
        Dim cadenaDetalle As String

        Dim oficinaVenta As String = hidOfVenta.Value

        'Generar variables para Generar Nota de Credito
        cadenaCabecera = GenerarCabeceraNotaCredito(v_montodescuento)
        cadenaDetalle = GenerarDetalleNotaCreditoCC(v_montodescuento)

        Dim oConsultaSap As New SapGeneralNegocios
        Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GenerarProcesoNotaCreditoCC() ")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Cabecera : " & cadenaCabecera)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Detalle  : " & cadenaDetalle)


        'Grabar Nota de Credito
        Dim notaCreditoGenerado As Boolean = oConsultaSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
        nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

        If notaCreditoGenerado Then
            RegistrarCanjePuntos(facturaPedido, _
                                 documentoSAPNotaCredito, _
                                 factura)
        End If

        documentoSAP = factura

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GenerarProcesoNotaCreditoCC() ")

        If Not notaCreditoGenerado Then
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  No se pudo crear la Nota de Crédito")
            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        End If

    End Sub

    ' Genera el detalle de la nota de crédito cuando se trata de un descuento por Puntos Claro Club
    Private Function GenerarDetalleNotaCreditoCC(ByVal v_montodescuento As Double) As String

        Dim arrayDetalle(28) As String
        Dim cadenaDetalle As String

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
        Dim dblMonto As Double = Math.Round(v_montodescuento / (1 + dblIgv), 2)
        Dim dblMontoIGV As Double = Math.Round(dblMonto * dblIgv, 2)
        Dim dblMontoTotal = Math.Round(dblMonto + dblMontoIGV, 2)

        Dim consecutivo As String = "000001"
        Dim codArticulo As String = ConfigurationSettings.AppSettings("codArticuloNotaCreditoCC")
        Dim desArticulo As String = ConfigurationSettings.AppSettings("desArticuloNotaCreditoCC")
        Dim codUtilizacion As String = "01"
        Dim desUtilizacion As String = "PVU"
        Dim codCamp As String = "0000"
        Dim desCamp As String = "NO DEFINIDO"
        Dim cantidad As String = v_montodescuento.ToString
        Dim codPlanTarifario As String = "000"
        Dim desPlanTarifario As String = "NO APLICA"
        Dim nroTelefono = hidNroLinea.Value

        arrayDetalle(0) = ""  ' Documento 
        arrayDetalle(1) = consecutivo  ' Consecutivo 
        arrayDetalle(2) = codArticulo  ' Articulo 
        arrayDetalle(3) = desArticulo  ' Des_Articulo 
        arrayDetalle(4) = codUtilizacion  ' Utilizacion
        arrayDetalle(5) = desUtilizacion ' Des_Utilizacion 
        arrayDetalle(6) = codCamp  ' Campana 
        arrayDetalle(7) = desCamp  ' Des_Campana 
        arrayDetalle(8) = ""  ' Serie

        arrayDetalle(9) = cantidad  ' Cantidad 
        arrayDetalle(10) = dblMonto  ' Precio 
        arrayDetalle(11) = dblMonto  ' Precio_Total 

        arrayDetalle(12) = "0.00"  ' Descuento 
        arrayDetalle(13) = ""  ' Porc_Descuento
        arrayDetalle(14) = ""  ' Descuento_Adic 

        arrayDetalle(15) = dblMonto  ' Subtotal
        arrayDetalle(16) = dblMontoIGV  ' Impuesto1 

        arrayDetalle(17) = ""  ' Impuesto2 
        arrayDetalle(18) = codPlanTarifario  ' Plan_Tarifario
        arrayDetalle(19) = desPlanTarifario  ' Des_Plan_Tarifar 
        arrayDetalle(20) = ""  ' Centro_Costo
        arrayDetalle(21) = ""  ' Motivo_Devolucio 
        arrayDetalle(22) = ""  ' Asociado
        arrayDetalle(23) = ""  ' Consecutivo_Padr 
        arrayDetalle(24) = ""  ' Articulo_Asociac
        arrayDetalle(25) = nroTelefono  ' Numero_Telefono
        arrayDetalle(26) = ""  ' Nro_Clarify 
        arrayDetalle(27) = ""  ' Dev_Componente 

        cadenaDetalle = Join(arrayDetalle, ";")

        GenerarDetalleNotaCreditoCC = cadenaDetalle

    End Function

    ' Fin E77568
    ' Fin PS - Automatización de canje y nota de crédito

    Private Function GenerarCabeceraNotaCredito(ByVal v_montodescuento As Double) As String

        Dim arrayCabecera(49) As String
        Dim cadenaCabecera As String

        'Valores para la cabecera
        Dim tipoDocumentoNotaCredito As String = ConfigurationSettings.AppSettings("strTipoDocumentoNotaCredito")
        Dim oficinaVenta As String = hidOfVenta.Value
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
        Dim orgVenta As String = hidOrgVenta.Value
        Dim canalOficina As String = hidCanalOf.Value


        arrayCabecera(0) = ""  'Documento 
        arrayCabecera(1) = tipoDocumentoNotaCredito  'Tipo_Documento 
        arrayCabecera(2) = oficinaVenta  'Oficina_Venta 
        arrayCabecera(3) = fechaDocumento   'Fecha_Documento 
        arrayCabecera(4) = tipoDocumentoCliente   'Tipo_Doc_Cliente 
        arrayCabecera(5) = nroDocumentoCliente  'Cliente 
        arrayCabecera(6) = ""  'Augru 
        arrayCabecera(7) = moneda  'Moneda 
        arrayCabecera(8) = ""  'Tipo_Operacion 

        arrayCabecera(9) = dblMonto  'Total_Mercaderia 
        arrayCabecera(10) = dblMontoIGV  'Total_Impuesto 
        arrayCabecera(11) = dblMontoTotal  'Total_Documento 

        arrayCabecera(12) = ""  'Fecha_Registro 
        arrayCabecera(13) = ""  'Impreso 
        arrayCabecera(14) = ""  'Observacion1 
        arrayCabecera(15) = ""  'Observacion2 
        arrayCabecera(16) = tipoVenta  'Tipo_Venta 
        arrayCabecera(17) = ""  'Numero_Contrato 
        arrayCabecera(18) = ""  'Nro_Referencia 
        arrayCabecera(19) = ""  'Usuario_Registro 
        arrayCabecera(20) = ""  'Anulado 
        arrayCabecera(21) = ""  'Documento_Origen 
        arrayCabecera(22) = ""  'Fecha_Vta_Origen
        arrayCabecera(23) = ""  'Nro_Refer_Origen 
        arrayCabecera(24) = ""  'Nro_Cuotas 
        arrayCabecera(25) = ""  'Nro_Clarify 
        arrayCabecera(26) = ""  'Estado 
        arrayCabecera(27) = vendedor   'Vendedor 
        arrayCabecera(28) = ""  'Mala_Venta 
        arrayCabecera(29) = claseVentaNotaCredito  'Clase_Venta 
        arrayCabecera(30) = ""  'Des_Clase_Venta 
        arrayCabecera(31) = ""  'Mot_Mala_Venta 
        arrayCabecera(32) = ""  'Telefono 
        arrayCabecera(33) = ""  'Referencia 
        arrayCabecera(34) = ""  'Historico 
        arrayCabecera(35) = ""  'Numero_Hdc 
        arrayCabecera(36) = ""  'Nro_Pcs_Asociado
        arrayCabecera(37) = ""  'Nro_Ped_Tg 
        arrayCabecera(38) = ""  'Nro_Acuer_Alqu 
        arrayCabecera(39) = ""  'Trans_Gratuita 
        arrayCabecera(40) = ""  'Fidelizacion 

        arrayCabecera(41) = ""  'Vendedor_Dni 
        arrayCabecera(42) = ""  'Nro_Solicitud 
        arrayCabecera(43) = ""  'Serie_Recibida 
        arrayCabecera(44) = ""  'Operador 
        arrayCabecera(45) = ""  'Tipo_Prod_Operad 
        arrayCabecera(46) = ""  'Clase_Ped_Devol 

        arrayCabecera(47) = ""  'Nro_Factura 
        arrayCabecera(48) = orgVenta  'Orgvnt 
        arrayCabecera(49) = canalOficina  'Canal 

        cadenaCabecera = Join(arrayCabecera, ";")

        GenerarCabeceraNotaCredito = cadenaCabecera
    End Function

    Private Function GenerarDetalleNotaCredito(ByVal v_montodescuento As Double) As String

        Dim arrayDetalle(28) As String
        Dim cadenaDetalle As String

        Dim dblIgv As Double = Double.Parse(ConfigurationSettings.AppSettings("constIGVConsumosoles"))
        Dim dblMonto As Double = Math.Round(v_montodescuento / (1 + dblIgv), 2)
        Dim dblMontoIGV As Double = Math.Round(dblMonto * dblIgv, 2)
        Dim dblMontoTotal = Math.Round(dblMonto + dblMontoIGV, 2)

        Dim consecutivo As String = "000001"
        Dim codArticulo As String = "DESCUENTO1"
        Dim desArticulo As String = "DESCUENTOS AUTORIZADOS POR SUPERVISORES"
        Dim codUtilizacion As String = "01"
        Dim desUtilizacion As String = "PVU"
        Dim codCamp As String = "0000"
        Dim desCamp As String = "NO DEFINIDO"
        Dim cantidad As String = hidDescuento.Value
        Dim codPlanTarifario As String = "000"
        Dim desPlanTarifario As String = "NO APLICA"
        Dim nroTelefono = hidNroLinea.Value

        arrayDetalle(0) = ""  ' Documento 
        arrayDetalle(1) = consecutivo  ' Consecutivo 
        arrayDetalle(2) = codArticulo  ' Articulo 
        arrayDetalle(3) = desArticulo  ' Des_Articulo 
        arrayDetalle(4) = codUtilizacion  ' Utilizacion
        arrayDetalle(5) = desUtilizacion ' Des_Utilizacion 
        arrayDetalle(6) = codCamp  ' Campana 
        arrayDetalle(7) = desCamp  ' Des_Campana 
        arrayDetalle(8) = ""  ' Serie

        arrayDetalle(9) = cantidad  ' Cantidad 
        arrayDetalle(10) = dblMonto  ' Precio 
        arrayDetalle(11) = dblMonto  ' Precio_Total 

        arrayDetalle(12) = "0.00"  ' Descuento 
        arrayDetalle(13) = ""  ' Porc_Descuento
        arrayDetalle(14) = ""  ' Descuento_Adic 

        arrayDetalle(15) = dblMonto  ' Subtotal
        arrayDetalle(16) = dblMontoIGV  ' Impuesto1 

        arrayDetalle(17) = ""  ' Impuesto2 
        arrayDetalle(18) = codPlanTarifario  ' Plan_Tarifario
        arrayDetalle(19) = desPlanTarifario  ' Des_Plan_Tarifar 
        arrayDetalle(20) = ""  ' Centro_Costo
        arrayDetalle(21) = ""  ' Motivo_Devolucio 
        arrayDetalle(22) = ""  ' Asociado
        arrayDetalle(23) = ""  ' Consecutivo_Padr 
        arrayDetalle(24) = ""  ' Articulo_Asociac
        arrayDetalle(25) = nroTelefono  ' Numero_Telefono
        arrayDetalle(26) = ""  ' Nro_Clarify 
        arrayDetalle(27) = ""  ' Dev_Componente 

        cadenaDetalle = Join(arrayDetalle, ";")

        GenerarDetalleNotaCredito = cadenaDetalle

    End Function

    Private Sub GenerarProcesoNotaCredito(ByVal v_montodescuento As Double, ByRef documentoSAP As String)

        Dim cadenaCabecera As String
        Dim cadenaDetalle As String

        Dim oficinaVenta As String = hidOfVenta.Value

        'Generar variables para Generar Nota de Credito
        cadenaCabecera = GenerarCabeceraNotaCredito(v_montodescuento)
        cadenaDetalle = GenerarDetalleNotaCredito(v_montodescuento)

        Dim oConsultaSap As New SapGeneralNegocios
        Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
        Dim valorDescuento As Decimal

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GenerarProcesoNotaCredito() ")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Cabecera : " & cadenaCabecera)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Detalle  : " & cadenaDetalle)


        'Grabar Nota de Credito
        Dim notaCreditoGenerado As Boolean = oConsultaSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
        nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)

        documentoSAP = factura

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GenerarProcesoNotaCredito() ")

        'Graba los valores para que el Almacenero no lo pueda ver dentro del Pool de atenciones	
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Actualizar datos para la nota de credito para POOL de Alamacenero y Despachador")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Guarda valores para que el Almacenero no lo pueda ver dentro del Pool de atenciones")
        oConsultaSap.Set_ActualizaEstadoPedido(factura, oficinaVenta, "S", "")

        'Graba los valores para que el Despachador no lo pueda ver dentro del Pool de atenciones	
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Guarda valores para que el Despachador no lo pueda ver dentro del Pool de atenciones")
        oConsultaSap.Set_ActualizaEstadoPedido(factura, oficinaVenta, "", "S")

        If Not notaCreditoGenerado Then
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  No se pudo crear la Nota de Crédito")
            Throw New Exception("No se pudo Generar la Nota de Crédito.")
        End If

    End Sub


    'Private Function validarClienteSap() As Boolean
    '    Dim oConsultaSap As New SapGeneralNegocios

    '    Dim blnExito As Boolean = True
    '    Dim nroDocCliente As String = hidNroDocumento.Value
    '    Dim tipoDocCliente As String = hidTipoDocumento.Value
    '    Dim oficina As String = CheckStr(hidOfVenta.Value)
    '    Dim strScript As String

    '    Try
    '        Dim dsCliente As DataSet = oConsultaSap.Get_ConsultaCliente(oficina, tipoDocCliente, nroDocCliente)

    '        If IsNothing(dsCliente) OrElse dsCliente.Tables(0).Rows.Count = 0 Then
    '            hidMsg.Value = String.Format("Error. Cliente no se encuentra registrado en SAP.")
    '            blnExito = False

    '            strScript = "validarFlujoGenerarPedido('ERROR');"
    '            RegisterStartupScript("script", "<script>" & strScript & "</script>")
    '        End If
    '    Catch ex As Exception
    '        blnExito = False
    '        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Error. Consultar Cliente Sap: " & ex.Message)

    '        strScript = "validarFlujoGenerarPedido('ERROR');"
    '        RegisterStartupScript("script", "<script>" & strScript & "</script>")
    '    Finally
    '        oConsultaSap = Nothing
    '    End Try

    '    Return blnExito
    'End Function


    Private Function GenerarCadenaCabecera() As String
        Dim cadenaCabecera As String

        Try
            Dim oficina As String = CheckStr(hidOfVenta.Value)
            Dim codVendedor As String = CheckStr(CheckStr(Session("CodVendedorSAP")))  '  CheckStr(CType(Session("VendedorSelected"), Vendedor).Id_Distribuidor_Vendedor)
            Dim nroDocCliente As String = hidNroDocumento.Value
            Dim tipoDocCliente As String = hidTipoDocumento.Value
            Dim tipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
            Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")
            Dim tipoOperacion As String = ConfigurationSettings.AppSettings("ExpressTipoOpeRenovacionSAP")
            Dim tipoDocVenta As String = hidTipoDocVenta.Value
            Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")
            Dim descTipoOp As String = ConfigurationSettings.AppSettings("constDescOperRenovacion")

            Dim precios As String = hidPrecios.Value
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)

            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))
            Dim canal As String = hidCanalOf.Value
            Dim orgVenta As String = hidOrgVenta.Value

            'Cadena Documento
            Dim arrayCabecera(49) As String
            arrayCabecera(0) = ""                                    'Documento
            arrayCabecera(1) = tipoDocVenta                          'Tipo_Documento
            arrayCabecera(2) = oficina                               'Oficina_Venta
            arrayCabecera(3) = String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
            arrayCabecera(4) = tipoDocCliente                        'Tipo_Doc_Cliente
            arrayCabecera(5) = nroDocCliente                         'Cliente
            arrayCabecera(7) = moneda                                'Moneda
            arrayCabecera(9) = totalSinIGV                           'Total_Mercaderia
            arrayCabecera(10) = totalIGV                             'Total_Impuesto
            arrayCabecera(11) = totalConIGV                          'Total_Documento
            arrayCabecera(14) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
            arrayCabecera(15) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
            arrayCabecera(16) = tipoVenta                            'Tipo_Venta
            arrayCabecera(25) = ""                                   'Código Comercial
            arrayCabecera(27) = codVendedor                          'Vendedor
            arrayCabecera(29) = tipoOperacion                        'Renovacion
            arrayCabecera(30) = descTipoOp                           'Descripción Renovacion
            arrayCabecera(35) = CheckStr(Session("CodVendedorSAP"))
            arrayCabecera(44) = "0"                                  'Operador
            arrayCabecera(45) = "0"                                  'Tipo de Operador
            arrayCabecera(48) = orgVenta                             'Orgvnt
            arrayCabecera(49) = canal                                'Canal

            cadenaCabecera = Join(arrayCabecera, ";")

        Catch ex As Exception
            cadenaCabecera = ""
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Error GenerarCadenaCabecera: " & ex.Message)
        End Try

        Return cadenaCabecera
    End Function

    Private Function GenerarCadenaDetalle() As String
        Dim cadenaDetalle As String
        Dim oConsulta As New VentaNegocios

        Try
            Dim arrayDetalle(28) As String
            Dim consecutivo As String = "000001"
            Dim cantidad As Integer = 1

            Dim planTarifa As String = hidPlanTarifaSelected.Value
            Dim codPlan As String = planTarifa.Split(","c)(0)
            Dim desPlan As String = planTarifa.Split(","c)(1)

            Dim listaPrecio As String = hidlistaPrecioSelected.Value
            Dim codLisPrecio As String = listaPrecio.Split(","c)(0)
            Dim desLisPrecio As String = listaPrecio.Split(","c)(1)

            Dim campania As String = hidCampaniaSelected.Value
            Dim codCampania As String = campania.Split(","c)(0)
            Dim desCampania As String = campania.Split(","c)(1)

            Dim precios As String = hidPrecios.Value
            Dim descuento As String = precios.Split(","c)(0)
            Dim totalSinIGV As String = precios.Split(","c)(3)
            Dim totalConIGV As String = precios.Split(","c)(1)
            Dim precioLista As String = precios.Split(","c)(2)
            Dim totalIGV As String = CheckStr(CheckDbl(totalConIGV) - CheckDbl(totalSinIGV))

            'Cadena Detalle
            arrayDetalle(0) = ""                            'Documento
            arrayDetalle(1) = consecutivo                   'Consecutivo (codigo 6 digitos)
            arrayDetalle(2) = txtCodEquipo.Text           'Articulo
            arrayDetalle(3) = ddlCodEquipo.SelectedItem.Text          'Des_Articulo
            arrayDetalle(4) = codLisPrecio                  'Utilizacion
            arrayDetalle(5) = desLisPrecio                  'Des_Utilizacion
            arrayDetalle(6) = codCampania
            arrayDetalle(7) = desCampania
            arrayDetalle(8) = CheckStr(hidSerieEquipo.Value)      'Iccid
            arrayDetalle(9) = CheckStr(cantidad)            'Cantidad
            arrayDetalle(10) = precioLista                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
            arrayDetalle(11) = totalSinIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
            arrayDetalle(12) = descuento                    'Descuento
            arrayDetalle(13) = ""                           'Porc_Descuento
            arrayDetalle(14) = ""                           'Descuento_Adic
            arrayDetalle(15) = totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
            arrayDetalle(16) = totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
            arrayDetalle(17) = ""                           'Impuesto2
            arrayDetalle(18) = codPlan                      'Plan_Tarifario
            arrayDetalle(19) = desPlan                      'Des_Plan_Tarifar
            arrayDetalle(20) = ""                           'Centro_Costo
            arrayDetalle(21) = ""                           'Motivo_Devolucio
            arrayDetalle(22) = ""                           'Asociado
            arrayDetalle(23) = ""                           'Consecutivo_Padr
            arrayDetalle(24) = ""                           'Articulo_Asociac
            arrayDetalle(25) = hidNroLinea.Value            'Numero_Telefono
            arrayDetalle(26) = ""                           'Nro_Clarify
            arrayDetalle(27) = ""                           'Dev_Componente
            arrayDetalle(28) = ""                           'Serie_Ant

            cadenaDetalle = Join(arrayDetalle, ";")

        Catch ex As Exception
            cadenaDetalle = ""
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Error GenerarCadenaDetalle: " & ex.Message)
        Finally
            oConsulta = Nothing
        End Try

        Return cadenaDetalle
    End Function

    Private Function GenerarCadenaAcuerdo() As String
        Dim cadenaAcuerdo As String
        Dim oficina As String = CheckStr(hidOfVenta.Value)
        Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")
        Dim plazoAcuerdo As String = ddlPlazoAcuerdo.SelectedItem.Value
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim telfVendedor As String = "000000000000000" 'Poner sin Telefono
        Dim prefijo As String = ConfigurationSettings.AppSettings("constRenovPostCACNroPrefijo")
        Dim tipoDocCli As String = CheckStr(CheckInt(hidTipoDocumento.Value))
        Dim planTarifa As String = hidPlanTarifaSelected.Value
        Dim codPlan As String = planTarifa.Split(","c)(0)

        Dim apellidos As String() = CheckStr(hidApellidosCli.Value).Split(" "c)
        Dim apePat As String = apellidos(0)
        Dim apeMat As String = ""

        If apellidos.Length > 1 Then
            apeMat = apellidos(1)
        End If

        Dim usuario As String = CurrentUser()

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
        arrayContrato(5) = hidNombresCli.Value
        arrayContrato(6) = apePat
        arrayContrato(7) = apeMat
        arrayContrato(8) = ""
        'arrayContrato(9) = usuario
        arrayContrato(9) = ""
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
        arrayContrato(20) = codVendedor
        arrayContrato(21) = telfVendedor
        arrayContrato(22) = ""
        arrayContrato(23) = ""
        arrayContrato(24) = "N"
        arrayContrato(25) = CheckStr(ConfigurationSettings.AppSettings("constRenovAnalista")).Split(";"c)(0)
        arrayContrato(26) = ""
        arrayContrato(27) = CheckStr(ConfigurationSettings.AppSettings("constEstadoAcuerdoReservado"))
        arrayContrato(28) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(0)
        arrayContrato(29) = CheckStr(ConfigurationSettings.AppSettings("constRenovObservacion")).Split(";"c)(1)
        arrayContrato(30) = ""
        arrayContrato(31) = "S"
        arrayContrato(32) = tipoDocCli
        arrayContrato(33) = hidNroDocumento.Value
        arrayContrato(34) = hidNroLinea.Value
        arrayContrato(35) = codPlan
        arrayContrato(36) = "S"
        arrayContrato(37) = ""
        arrayContrato(38) = codVendedor
        arrayContrato(39) = codVendedor
        arrayContrato(40) = ""
        arrayContrato(41) = ""
        arrayContrato(42) = CheckStr(ConfigurationSettings.AppSettings("constRenovAprobador")).Split(";"c)(0)
        arrayContrato(43) = hidLimiteCred.Value
        arrayContrato(44) = ""
        arrayContrato(45) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(0)
        arrayContrato(46) = CheckStr(ConfigurationSettings.AppSettings("constRenovScoreCred")).Split(";"c)(1)
        'arrayContrato(45) = ""
        'arrayContrato(46) = ""
        arrayContrato(48) = ""
        arrayContrato(49) = ""
        arrayContrato(50) = codPlan
        arrayContrato(61) = "X"

        cadenaAcuerdo = Join(arrayContrato, ";")
        Try

        Catch ex As Exception
            cadenaAcuerdo = ""
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Error GenerarCadenaAcuerdo: " & ex.Message)
        End Try

        Return cadenaAcuerdo
    End Function


    Private Function GenerarDetalleRenovSap(ByVal nroFactura As String, ByVal nroContrato As String, ByVal nroPedido As String) As Boolean

        Dim retorno As String
        Dim blnOK As Boolean = False

        Try

            'Dim oConsultaSap As New SapGeneralNegocios
            Dim oConsulta As New VentaExpressNegocios
            Dim motivo As String = ""
            Dim nroLinea As String = hidNroLinea.Value
            Dim doc_tipo As String = hidTipoDocumento.Value
            Dim doc_nro As String = hidNroDocumento.Value
            Dim puntoVenta As String = CheckStr(hidOfVenta.Value)
            Dim servidor As String = System.Net.Dns.GetHostName


            Dim planTarifa As String = CheckStr(hidPlanTarifaSelected.Value)
            Dim codPlan As String = planTarifa.Split(","c)(0)
            Dim desPlan As String = planTarifa.Split(","c)(1)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "hidLimiteCred.value : " & hidLimiteCred.Value)

            If (hidLimiteCred.Value = "") Then
                hidLimiteCred.Value = "0"
            End If

            Dim limite As Double = CheckDbl(hidLimiteCred.Value)

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "limite: " & limite)

            Dim desTope As String = ""


            'Insertar datos adicionales para el pedido sap
            Dim strCanal As String = "CAC"
            Dim strTipoRenovacion As String = ""
            Dim flagExoneracion As Integer = 0
            Dim flagDescuento As Integer = 0


            Dim titular As String = hidTitular.Value
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "titular : " & titular)

            Dim representante As String = hidRepresentante.Value
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "representante : " & representante)
            If hidDescuento.Value = "" Then
                hidDescuento.Value = 0
            End If

            Dim descuento As Double = Double.Parse(hidDescuento.Value)

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "descuento : " & descuento)

            If Session("UsuarioValidadorDescuento") Is Nothing Then
                Session("UsuarioValidadorDescuento") = ""
            End If

            ' Inicio E77568
            ' PROY-7045RF01 - RF01
            Session("UsuarioValidadorDescuento") = Session("codUsuario")
            ' Fin E77568
            Dim usuarioValidador As String = Session("UsuarioValidadorDescuento")

            usuarioValidador = usuarioValidador.ToUpper()

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "usuarioValidador : " & usuarioValidador)

            If hidFlagRenovacionAdelantada.Value = "true" Then
                strTipoRenovacion = "ANTICIPADA"
            Else
                strTipoRenovacion = "NORMAL"
            End If
            ' Inicio E77568
            ' Si es el último mes es una renovación normal
            If hidMesesPorVencerApadece.Value = "1" Then
                strTipoRenovacion = "NORMAL"
            End If
            ' Fin E77568

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "strTipoRenovacion : " & strTipoRenovacion)

            If hidFlagReintegro.Value = "true" And hidFlagExonerarReintegro.Value = "true" Then
                flagExoneracion = 1
            End If


            If (hidFlagDescuento.Value = "true") Then
                flagDescuento = 1
            End If


            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "flagDescuento : " & flagDescuento)


            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio GrabarVentaRenovacionCAC()")

            ' Inicio E77568
            Dim RetenidoFidelizado As String = hdnRetenidoFidelizado.Value.ToUpper()

            'Crear copia de datos de pedido en SISACT
            retorno = oConsulta.GrabarVentaRenovacionCAC(puntoVenta, _
                                                        doc_tipo, _
                                                        doc_nro, _
                                                        CurrentUser, _
                                                        nroFactura, _
                                                        nroContrato, _
                                                        hidCorreo.Value, _
                                                        hidPlanAct.Value, _
                                                        nroLinea, _
                                                        desPlan, _
                                                        desTope, _
                                                        servidor, _
                                                        limite, _
                                                        hidCicloFact.Value, _
                                                        strCanal, _
                                                        nroPedido, _
                                                        strTipoRenovacion, _
                                                        flagExoneracion, _
                                                        flagDescuento, titular, representante, descuento, usuarioValidador, _
                                                        RetenidoFidelizado)
            ' Fin E77568

            If Not retorno = "0" Then
                RollBackVenta(nroFactura)
            Else
                blnOK = True
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Exception GrabarVentaRenovacionCAC - Mensaje: " & ex.Message)
            RollBackVenta(nroFactura)

            Throw New Exception(" Error al Generar Detalle RenovSap. " & ex.Message)

        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin GrabarVentaRenovacionCAC()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> retorno : " & retorno)
        End Try

        Return blnOK

    End Function

    Private Sub RollBackVenta(ByVal nroFactura As String)


        '*************************************************
        'Anulación con RFC ZPVU_RFC_TRS_PEDIDO_ANULACION
        Dim strUsuario As String = Session("CodVendedorSAP")

        Dim dsResult2 As DataSet

        Dim oficina As String = CheckStr(hidOfVenta.Value)
        Dim arrCabecera(35) As String
        Dim bProceso As Boolean = False
        Dim oConsultarSap As New SapGeneralNegocios

        Try
            arrCabecera(0) = " "
            arrCabecera(1) = "ZAFR"
            arrCabecera(5) = oficina
            arrCabecera(7) = nroFactura

            Dim strCabecera As String = Join(arrCabecera, ";")

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio Rollback Pedido")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input --> nroPedido : " & nroFactura)

            dsResult2 = oConsultarSap.Set_AnularDocumentoJob(CStr(strCabecera), strUsuario)

            If dsResult2.Tables(1).Rows.Count > 0 Then
                Dim drMsg As DataRow
                For Each drMsg In dsResult2.Tables(1).Rows
                    If CStr(drMsg("TYPE")) = "E" Then
                        Throw New ApplicationException(CStr(drMsg("MSG")))
                    End If
                Next

            End If

        Catch ex As Exception
            bProceso = False
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Exception  --> " & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> " & bProceso)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin Rollback Pedido")
        End Try

    End Sub

    Private Sub Auditoria(ByVal desTrans As String, ByVal strCodTrans As String)
        Try

            'Dim strCodTrans As String = ConfigurationSettings.AppSettings("codTransRenovPost")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim ipcliente As String = CurrentTerminal
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim usuario_id As String = CurrentUser
            Dim telefono As String = hidNroLinea.Value

            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)



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
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception registrarAuditoria() - Mensaje: " & ex.Message)
        End Try
    End Sub


    Private Sub ConsultarDatosVenta()

        Dim oConsultarSap As New SapGeneralNegocios
        Dim dsOficina As New DataSet
        dsOficina = oConsultarSap.ConsultarParametrosOfVenta(CheckStr(hidOfVenta.Value))

        hidCanalOf.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidOrgVenta.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))

        dsOficina = Nothing
        oConsultarSap = Nothing

        ' Inicio E77568
        Dim objVenta As New VentaExpressNegocios
        Dim descuento As Double = 0.0
        Dim meses As Double = 0
        objVenta.ObtenerMontoMaxDescuentoAS(descuento, meses)
        hidMontoMaxDesAS.Value = CheckStr(descuento)
        hidMesesMaxAS.Value = CheckStr(meses)
        objVenta = Nothing
        ' Fin E77568
    End Sub


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


        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "- " & "--- Inicio Region Tipificacion OCC -  Renovacion de Equipo Postpago CAC ---")

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Tipificacion OCC ---")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio Metodo GrabarInteraccionOCC()")


        Try

            Dim resultadoInteraccion As New ItemGenerico
            resultadoInteraccion = oInteraccionNegocios.InsertarInteraccion(oInteraccion)

            idInteraccion = resultadoInteraccion.Codigo
            flagInter = resultadoInteraccion.estado
            mensajeInter = resultadoInteraccion.Descripcion

            codInteraccion = idInteraccion

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "- " & "Id Interaccion : " & idInteraccion)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Flag Metodo : " & flagInter)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Mensaje : " & mensajeInter)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin Metodo GrabarInteraccionOCC()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Fin Tipificacion  OCC ---")

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Error al generar Tipificacion  OCC ---")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Eror:" & ex.Message)

        End Try

        Try
            'Insertar Plantilla para OCC
            Dim objPlantillaNegocios As New PlantillaNegocios
            Dim oPlantillaDatos As PlantillaInteraccion
            Dim flagPlantilla As String
            Dim mensajePlantilla As String

            oPlantillaDatos = DatosPlantillaInteracionOCC()

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Inicio Grabar Plantilla OCC ---")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "- " & "Id Interaccion : " & idInteraccion)

            objPlantillaNegocios.InsertarPlantillaInteraccion(oPlantillaDatos, idInteraccion, flagPlantilla, mensajePlantilla)

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Flag Metodo : " & flagPlantilla)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Mensaje : " & mensajePlantilla)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin Metodo InsertarPlantillaInteraccion()")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Fin Grabar Plantilla OCC ---")

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Error al generar Plantilla  OCC ---")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "--- Eror:" & ex.Message)

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

    Private Function EliminarPedidoSISACT(ByVal documentoSAP As String)
        Try
            Dim oConsulta As New VentaExpressNegocios

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio EliminarVentaRenovacionPostpago()")

            oConsulta.EliminarVentaRenovacionPostpago(documentoSAP)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- No se puede Eliminar el Pedido SAP en SISACT:" & documentoSAP)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Error:" & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin EliminarVentaRenovacionPostpago()")
        End Try

    End Function

End Class
