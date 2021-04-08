Imports System.Data
Imports Claro.SisAct.Negocios
Imports System.Collections
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions

Public Class sisact_generacion_acuerdos
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCrear As Anthem.Button
    Protected WithEvents btnAnexar As Anthem.Button
    Protected WithEvents btnConsultar As Anthem.Button
    Protected WithEvents divCrearAnexar As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtNombreGlosa As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgItemsDoc As Anthem.DataGrid
    Protected WithEvents txtNroSolicitud As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidEnviado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAyudaTipoDoc As Anthem.Button
    Protected WithEvents hidTotalDocsAdjunta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblNroSolicitud As Anthem.Label
    Protected WithEvents lblTipoDoc As Anthem.Label
    Protected WithEvents lblNroDoc As Anthem.Label
    Protected WithEvents lblRazon As Anthem.Label
    Protected WithEvents ddlTipoDocumento As Anthem.DropDownList
    Protected WithEvents ddlDocumento As Anthem.DropDownList
    Protected WithEvents btnRetornar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidFechaConsulta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaArchivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAnexar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVisible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaRecibo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroFilas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_OBSERVADO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_APROBADO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_NUEVO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDG As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagEnvio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLoadFrame As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hiListaArchivosLoad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArchivosElim As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRecibosElim As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEnviar As Anthem.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents btnEliminar As Anthem.Button
    Protected WithEvents hidTipoDespacho As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Propiedades"

    Property ID_TIPO_DOCUMENTO_ACUERDO() As Integer
        Get
            Return Funciones.CheckInt(Me.ViewState("ID_TIPO_DOCUMENTO_ACUERDO"))
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("ID_TIPO_DOCUMENTO_ACUERDO") = Value
        End Set
    End Property


    Property ID_DOCUMENTO_ACUERDO_OTROS() As Integer
        Get
            Return Funciones.CheckInt(Me.ViewState("ID_DOCUMENTO_ACUERDO_OTROS"))
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("ID_DOCUMENTO_ACUERDO_OTROS") = Value
        End Set
    End Property

    Property EsActualizable() As Boolean
        Get
            Return CType(Me.ViewState("EsActualizable"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("EsActualizable") = Value
        End Set
    End Property
    
    
    
    Property InvocadoDesdeMenu() As Boolean
        Get
            Return CType(Me.ViewState("InvocadoDesdeMenu"), Boolean)
        End Get
        Set(ByVal Value As Boolean)
            Me.ViewState("InvocadoDesdeMenu") = Value
        End Set
    End Property
    

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
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

        Try
            Anthem.Manager.Register(Me)

            '---
            If Not Page.IsPostBack Then
                '--inicializa datos constantes
                InicializaVariablesControles()
                '--carga combos de seleccion
                'CargarCombos()
                '--
                InicializarGrilla()

                If Not Request("nroSec") Is Nothing Then

                    btnRetornar.Style.Add("display", "")
                    txtNroSolicitud.Text = Request("nroSec").ToString
                    txtNroSolicitud.ReadOnly = True
                    btnConsultar.Visible = False

                    btnEnviar.Style.Add("display", "none")
                    btnEnviar.Visible = False

                    If Not Request("TipoDocumento") Is Nothing And Not Request("IdDocumento") Is Nothing Then
                        ddlTipoDocumento.SelectedValue = Request("TipoDocumento").ToString
                        ddlTipoDocumento_SelectedIndexChanged(Nothing, Nothing)
                        ddlDocumento.SelectedValue = Request("IdDocumento").ToString
                        ddlDocumento_SelectedIndexChanged(Nothing, Nothing)
                        txtNombreGlosa.Text = ddlDocumento.SelectedItem.Text
                        ddlTipoDocumento.Enabled = False
                        ddlDocumento.Enabled = False
                    End If

                    Me.InvocadoDesdeMenu = False

                    'cambio JAR
                    If Not Request("llamadoDesde") Is Nothing And Request("llamadoDesde") = "Evaluacion" Then
                        Me.InvocadoDesdeMenu = True
                        btnEnviar.Style.Add("display", "")
                        btnRetornar.Style.Add("display", "none")
                        Anthem.Manager.RegisterStartupScript("script", "<script>mostrarFrameRecibo()</script>") 'mostrar el frame de recibos
                End If
                    'Fin cambio

                    Call btnConsultar_Click(Nothing, Nothing)
            End If

            End If
            'MARVIN ANDIA
            Dim accion As String = Request.QueryString("hidProceso")
            If hidProceso.Value = Nothing Then hidProceso.Value = ""
            If hidProceso.Value = "" Then
                accion = Request.QueryString("hidProceso")
            End If
            accion = hidProceso.Value
            Select Case accion
                Case "buscar"
                    'buscar()
                Case "grabar"
                    grabar()
            End Select

        Catch ex As Exception
            Anthem.Manager.RegisterStartupScript("Cargar", "<script> alert('" + ex.Message + "'); </script>")

        End Try
    End Sub

#Region "Inicializacion"

    Private Sub InicializaVariablesControles()

        Me.EsActualizable = False
        Me.InvocadoDesdeMenu = True

        '--Recupera Datos de las Variables Globales (WEB CONFIG) e inicializa variables en ViewState
        Dim intTemp As Integer
        intTemp = Funciones.CheckInt(ConfigurationSettings.AppSettings("ID_TIPO_DOCUMENTO_ACUERDO"))
        If (intTemp = 0) Then
            intTemp = -1 '//Valor Null significará -1
        End If
        Me.ID_TIPO_DOCUMENTO_ACUERDO = intTemp
        '--
        intTemp = Funciones.CheckInt(ConfigurationSettings.AppSettings("ID_DOCUMENTO_ACUERDO_OTROS"))
        If (intTemp = 0) Then
            intTemp = -1
        End If

        Me.ID_DOCUMENTO_ACUERDO_OTROS = intTemp
        '--
        txtNroSolicitud.Attributes.Add("onkeyup", "javascript:onKeyUpNroSEC();")
        txtNroSolicitud.Attributes.Add("onkeypress", "javascript:OnKeyPressNumeros();")
        txtNroSolicitud.Attributes.Add("onblur", "javascript:return checknumb(9,0,-1,this.name);")
        txtNombreGlosa.Attributes.Add("onkeypress", "javascript:OnKeyPressNumerosLetrasExt();")
        btnAyudaTipoDoc.Attributes.Add("onclick", "javascript:MostrarAyudaTipoDoc();")

    End Sub

    '***Inicializa grilla vacia***
    Private Sub InicializarGrilla()
      
        '--enlaza data table
        dgItemsDoc.DataSource = New ArrayList
        dgItemsDoc.DataBind()
        '--
        ActualizarControlesEdicion()
    End Sub

    Private Sub CargarCombos()
        CargarComboTipoDocumento()
        CargarComboDocumento()
    End Sub

    '***Recupera y carga tipos de documento***
    Private Sub CargarComboTipoDocumento()
        Dim objTipoDocumentoNeg As New TipoDocumentoNegocio
        Dim arrlstTipoDoc As New ArrayList
        '--obtiene datos y agrega  fila seleccionar
        arrlstTipoDoc = objTipoDocumentoNeg.Listar()

        'Cambio JAR
        'llenamos Tipos de Documentos sin considerar Acuerdos

        If hidTipoDespacho.Value = "2" Then
            Dim NuevoarrlstTipoDoc As New ArrayList
            For i As Integer = 0 To arrlstTipoDoc.Count - 1
                Dim item As TipoDocumentoE = CType(arrlstTipoDoc(i), TipoDocumentoE)
                If item.CODIGO <> CheckInt(ConfigurationSettings.AppSettings("ID_TIPO_DOCUMENTO_ACUERDO")) Then
                    NuevoarrlstTipoDoc.Add(item)
                End If
            Next
            arrlstTipoDoc = NuevoarrlstTipoDoc
        End If
        'Fin Cambio JAR

        Dim TipoDocumentoE As New TipoDocumentoE(-1, "--SELECCIONAR--", -1, 0)
        arrlstTipoDoc.Insert(0, TipoDocumentoE)
        '--carga combo
        LlenaCombo(arrlstTipoDoc, ddlTipoDocumento, "CODIGO", "NOMBRE")
        '--almacena  datos para controlar propiedad enable de ibtnAyudaDoc
        Dim cadena As String = ""
        For Each item As TipoDocumentoE In arrlstTipoDoc
            cadena = cadena & "|" & item.CODIGO & ";" & item.Total_Docs_Adjunta
        Next
        If (cadena.IndexOf("|") = 0) Then
            cadena = cadena.Remove(0, 1) '//Elimina primer caracter insertado para hacer "split", posteriormente
        End If
        hidTotalDocsAdjunta.Value = cadena
    End Sub

    '***Recupera y carga tipos de documento***
    Private Sub CargarComboDocumento()
        Dim objDocumentoNeg As New DocumentoNegocios
        Dim arrlstDocumento As New ArrayList
        '--obtiene Tipo de  Docuemnto seleccionado
        Dim intTipoDoc As Integer = Funciones.CheckInt(ddlTipoDocumento.SelectedValue)
        Dim DocumentoEnt As New Documento(-1, "--SELECCIONAR--", Nothing)
        If intTipoDoc > 0 Then '//se selecciono uno <>"SELECCIONAR"
            arrlstDocumento = objDocumentoNeg.Listar(intTipoDoc)
        End If
        '--
        arrlstDocumento.Insert(0, DocumentoEnt)
        LlenaCombo(arrlstDocumento, ddlDocumento, "CODIGO", "NOMBRE")
        '--habilita o no
        ddlDocumento.Enabled = (ddlDocumento.Items.Count > 1)
        ddlDocumento.AutoUpdateAfterCallBack = True

    End Sub

    Public Sub CargarDatosSolicitud()

            Dim oConsulta As New SolicitudNegocios
            Dim item As New SolicitudEmpresa

            '--asigna lo ingresado a label resultante
            item = oConsulta.ObtenerSolicitudEmpresa(txtNroSolicitud.Text)

            lblNroSolicitud.Text = CheckStr(item.SOLIN_CODIGO)
            lblTipoDoc.Text = item.TDOCV_DESCRIPCION
            '---
            hidEstadoSEC.Value = item.ESTAC_CODIGO
            hidTipoDespacho.Value = CheckStr(item.DPCHN_CODIGO)

            Anthem.Manager.RegisterStartupScript("startscript", String.Format("<script>setValue('hidEstadoSEC','{0}')</script>", item.ESTAC_CODIGO))

            If item.CLIEV_RAZ_SOC = "" Then
                lblRazon.Text = item.CLIEV_NOMBRE & " " & item.CLIEV_APE_PAT & " " & item.CLIEV_APE_MAT
            Else
                lblRazon.Text = item.CLIEV_RAZ_SOC
            End If
            lblNroDoc.Text = item.CLIEC_NUM_DOC
            '---    
            lblNroSolicitud.AutoUpdateAfterCallBack = True
            lblTipoDoc.AutoUpdateAfterCallBack = True
            lblRazon.AutoUpdateAfterCallBack = True
            lblNroDoc.AutoUpdateAfterCallBack = True

            '---
            Me.EsActualizable = EsPosibleActualizarAcuerdos() '//para actualizar tb columa 0,1 y 2 de grilla
            '---
            ObtenerDocumentosSEC()

    End Sub
  
    <Anthem.Method()> _
    Public Sub ObtenerDocumentosSEC()
        Dim objAcuerdoIngresoNeg As New AcuerdoNegocios
        Dim arrlstItemsDocs As New ArrayList
        '--obtiene y carga items de documentos
        If Not Request("nroSec") Is Nothing And Not Request("fechaSubsanacion") Is Nothing Then
            If Request("fechaSubsanacion") <> "" And Mid(Request("fechaSubsanacion"), 1, 10) <> "01/01/1900" Then
                hidFechaConsulta.Value = Request("fechaSubsanacion")
            Else
                If hidFechaConsulta.Value = "" Then
                    hidFechaConsulta.Value = Now.ToShortDateString & " " & Now.ToShortTimeString
                End If
            End If
            arrlstItemsDocs = objAcuerdoIngresoNeg.ListarItemsDocSec(Funciones.CheckInt(lblNroSolicitud.Text), hidFechaConsulta.Value)
        Else
            arrlstItemsDocs = objAcuerdoIngresoNeg.ListarItemsDoc(Funciones.CheckInt(lblNroSolicitud.Text))
        End If
        dgItemsDoc.DataSource = arrlstItemsDocs
        dgItemsDoc.DataBind()
        dgItemsDoc.AutoUpdateAfterCallBack = True

        ActualizarControlesEdicion()

    End Sub

    Private Sub ActualizarControlesEdicion()

        Dim EsActualiz As Boolean = Me.EsActualizable
        Dim sCodEstadoRegPDVSinArchivos As String = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS") '// 20
        '--
        If (Not EsActualiz) Then
            Anthem.Manager.AddScriptForClientSideEval("setVisible('divCrearAnexar',false)")
        Else
            Anthem.Manager.AddScriptForClientSideEval("setVisible('divCrearAnexar',true)")
        End If

        btnEliminar.Visible = (EsActualiz)
        If btnEliminar.Visible Then btnEliminar.Enabled = (dgItemsDoc.Items.Count > 0)
        btnEliminar.UpdateAfterCallBack = True

        btnEnviar.Visible = ((EsActualiz) And (hidEstadoSEC.Value = sCodEstadoRegPDVSinArchivos))
        If btnEnviar.Visible Then btnEnviar.Enabled = (dgItemsDoc.Items.Count > 0)
        btnEnviar.UpdateAfterCallBack = True

    End Sub

#End Region

#Region "Operaciones-Eventos"

    Private Function EsPosibleActualizarAcuerdos() As Boolean
        '----
        Dim sCodEstadoEnviado As String = ConfigurationSettings.AppSettings("constEstadoEnvCreditos")
        Dim sCodEstadoRegPDVSinArchivos As String = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS") '// 20

        Dim sCodEstadoObservado As String = ConfigurationSettings.AppSettings("strEstadoObservado")  '//-- 29
        Dim sCodEstadoObsVoucher As String = ConfigurationSettings.AppSettings("strEstadoObservadoVoucher") '//-- 31
        Dim sCodEstadoObsActivaciones As String = ConfigurationSettings.AppSettings("strEstadoObservadoActivaciones") '//-- 35

        Dim EsPosible As Boolean
        
        EsPosible = ( _
               (Me.InvocadoDesdeMenu() = True And hidEstadoSEC.Value = sCodEstadoRegPDVSinArchivos) Or _
                (Not Me.InvocadoDesdeMenu() And ( _
                                 (hidEstadoSEC.Value = sCodEstadoObservado) Or _
                                       (hidEstadoSEC.Value = sCodEstadoObsVoucher) Or _
                                       (hidEstadoSEC.Value = sCodEstadoObsActivaciones))))
        
        Return EsPosible

    End Function

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

            '---determina existencia de Nro de SEC
            Dim objAcuertoSol As New AcuerdoNegocios
            Dim existe As Boolean = objAcuertoSol.ExisteSolicitud(Funciones.CheckInt64(txtNroSolicitud.Text))
            If existe Then
                CargarDatosSolicitud() '///se carga control lblNroSolicitud
                CargarCombos()
                Anthem.Manager.RegisterClientScriptBlock("script", "<script>mostrarFrameRecibo()</script>")

                If (hidEstadoSEC.Value <> "") Then
                    If (hidEstadoSEC.Value = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS").ToString()) Then
                        Anthem.Manager.RegisterClientScriptBlock("scriptocultar", "<script>ocultarBotonesRecibo(false)</script>")
                    Else
                        Anthem.Manager.RegisterClientScriptBlock("scriptocultar", "<script>ocultarBotonesRecibo(true)</script>")
                    End If
                Else
                    '///nada
                End If

                'mostrarFrameRecibo
            Else
                Anthem.Manager.RegisterStartupScript("Consultar-No existe", "<script> alert('" & String.Format(Mensajes.INFO_SOLICITUD_NO_EXISTE, txtNroSolicitud.Text) & "'); </script> ")
            End If
    End Sub

    Private Sub btnAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexar.Click
        '---determina existencia de Nro de SEC
        Dim objAcuertoSol As New AcuerdoNegocios
        Dim existe As Boolean = objAcuertoSol.ExisteSolicitud(Funciones.CheckInt(lblNroSolicitud.Text))
        If existe Then
            '---variables a psar
            Dim strRuta As String = "sisact_subirdocumento.aspx?NS=" & lblNroSolicitud.Text & _
                       "&DC=" & ddlDocumento.SelectedValue & _
                       "&NG=" & Server.UrlEncode(txtNombreGlosa.Text.Trim.ToUpper)

            Dim strScript As String = "MostrarVentanaPopup('" & strRuta & "', 630,160)"
            Anthem.Manager.AddScriptForClientSideEval(strScript)

        Else
            Anthem.Manager.AddScriptForClientSideEval("alert('" + String.Format(Mensajes.INFO_SOLICITUD_NO_EXISTE, lblNroSolicitud.Text) + "');")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        '---
        Try
            Dim arrItems As ArrayList
            arrItems = ObtenerItemsSeleccionados()
            If arrItems.Count > 0 Then
                '---elimina los seleccionados
                Dim objAcuerdoIngresoNeg As New AcuerdoNegocios
                '---
                Dim sRutaRepositorio As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("ACU_CORP_RutaDestino"))

                Dim iTotalEliminados, iTotalNoEliminados As Long
                objAcuerdoIngresoNeg.EliminarVarios(arrItems, iTotalEliminados, iTotalNoEliminados, sRutaRepositorio)
                objAcuerdoIngresoNeg = Nothing
                '--
                If iTotalEliminados > 0 And iTotalNoEliminados = 0 Then
                    '--mensaje de resultado
                    Anthem.Manager.AddScriptForClientSideEval("alert('" & String.Format(Mensajes.INFO_CANTIDAD_ELIMINADOS, iTotalEliminados) & "'); ")
                    '--actualiza grailla
                    ObtenerDocumentosSEC()

                    'registrar log
                    Dim logeliminados As String = ""
                    Dim itdoc As DocumentoSEC
                    For Each itdoc In arrItems
                        logeliminados = logeliminados + itdoc.ID_DOCUMENTO.ToString + ","
                    Next
                    If (logeliminados <> "") Then
                        logeliminados = logeliminados.Substring(0, logeliminados.Length - 1)
                    End If

                    AuditoriaPagina.Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SISACT_ACUERDO_E"), String.Format("Se eliminaron los documentos con ID {0} para la SEC número {1}", logeliminados, Me.lblNroSolicitud.Text), Me.CurrentUser, Me.CurrentTerminal)

                ElseIf iTotalEliminados > 0 And iTotalNoEliminados > 0 Then
                    Anthem.Manager.AddScriptForClientSideEval("alert('" & String.Format(Mensajes.INFO_CANTIDAD_ELIMINADOS_ERROR, iTotalEliminados, iTotalNoEliminados) & "'); ")
                    ObtenerDocumentosSEC()
                ElseIf iTotalEliminados = 0 And iTotalNoEliminados > 0 Then
                    Anthem.Manager.AddScriptForClientSideEval("alert('" & String.Format(Mensajes.INFO_CANTIDAD_ELIMINADOS_NINGUNO, iTotalNoEliminados) & "'); ")
                    ObtenerDocumentosSEC()
                Else
                    Anthem.Manager.AddScriptForClientSideEval("alert('" & Mensajes.INFO_NINGUNO_ELIMINADOS & "'); ")
                End If
            Else
                Anthem.Manager.AddScriptForClientSideEval("alert('" & Mensajes.INFO_NINGUNO_SELECCIONADO & "'); ")
            End If

        Catch ex As Exception
            Anthem.Manager.AddScriptForClientSideEval("alert('" & ex.Message & "'); ")
        End Try
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            '---actualizar estado de sec
            Dim strScript As String
            Dim iCOD_SEC As Integer = Funciones.CheckInt(lblNroSolicitud.Text)
            If iCOD_SEC > 0 Then
                '---
                Dim sNuevoEstado As String = ConfigurationSettings.AppSettings("constEstadoEnvCreditos")   '//Nuevo Estado
                Dim objDocumentosSEC As New DocumentoSECNegocio
                objDocumentosSEC.EnviarACreditosActivaciones(iCOD_SEC, sNuevoEstado, Me.CurrentUser)
                objDocumentosSEC = Nothing

                '---actualizar controles de crear, editar, eliminar y adjuntar documentos
                hidEstadoSEC.Value = sNuevoEstado


                Me.EsActualizable = EsPosibleActualizarAcuerdos()

                '--actualiza grilla
                ObtenerDocumentosSEC()

                'strScript = "alert('Los documentos fueron enviados a Créditos y Activaciones'); "
                strScript = "alert('Los documentos fueron enviados a Créditos'); "

                Anthem.Manager.AddScriptForClientSideEval(strScript)
                Anthem.Manager.RegisterStartupScript("scriptocultar", String.Format("<script>ocultarBotonesRecibo(true);estadoSec('{0}');mostrarFrameRecibo()</script>", sNuevoEstado))

                If Not Request("llamadoDesde") Is Nothing And Request("llamadoDesde") = "Evaluacion" Then
                    'Anthem.Manager.RegisterStartupScript("script", "<script>window.close();</script>") 'cerrar la ventana
                    Anthem.Manager.AddScriptForClientSideEval("window.close();")
                End If

                Try
                    AuditoriaPagina.Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SISACT_ACUERDO_ENV"), String.Format("Se envió a créditos la SEC número {0} desde la pantalla de generación de acuerdos", Me.lblNroSolicitud.Text), Me.CurrentUser, Me.CurrentTerminal)
                Catch ex As Exception
                    '//--ERROR en auditoria
                    Anthem.Manager.AddScriptForClientSideEval("alert('" & ex.Message & "'); ")
                End Try
            End If
        Catch
            Anthem.Manager.AddScriptForClientSideEval("alert('" & Mensajes.ERROR_ENVIAR_CREDITOS_aCTIVACIONES & "'); ")
        End Try

    End Sub

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        '---
        CargarComboDocumento()
        ddlDocumento.AutoUpdateAfterCallBack = True
        '--
        ddlDocumento_SelectedIndexChanged(Nothing, Nothing)

    End Sub

    Private Sub ddlDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDocumento.SelectedIndexChanged
        '--habilita o no boton Crear
        Dim EsTipoDocumentoAcuerdo As Boolean
        EsTipoDocumentoAcuerdo = (Funciones.CheckInt(ddlTipoDocumento.SelectedValue) = Me.ID_TIPO_DOCUMENTO_ACUERDO)
        btnAnexar.Enabled = ((ddlTipoDocumento.SelectedIndex > 0) And (ddlDocumento.SelectedIndex > 0))
        btnAnexar.AutoUpdateAfterCallBack = True
    End Sub


#End Region

    '//Retorna cadena con el script para ejeución de ventana popup
    Protected Function ObtenerScriptPopup(ByVal pNombrePagina As String, ByVal pIdDocumento As Integer) As String
        ''--determina ancho y alto en funciona  Documento
        Dim iAlto As Integer
        Dim iAncho As Integer
        ConfiguracionAcuerdos.GetDimensionAcuerdo(pIdDocumento, iAncho, iAlto)
        '--
        Dim strScript As String = "MostrarVentanaPopup('" & pNombrePagina & "', " & CStr(iAncho) & ", " & CStr(iAlto) & ");"
        Return strScript
    End Function


#Region "Eventos de Grilla y Metodos sobre ella"

    Private Function ObtenerItemsSeleccionados() As ArrayList
        Dim chbxSeleccion As HtmlInputCheckBox
        Dim objItemAcuerdo As DocumentoSEC '//_Desc
        Dim arrItems As New ArrayList
        Dim itemGrid As DataGridItem
        '---
        For Each itemGrid In Me.dgItemsDoc.Items()
            chbxSeleccion = CType(itemGrid.Cells(0).Controls(1), HtmlInputCheckBox)
            If (chbxSeleccion.Checked) And chbxSeleccion.ID = "chbxSeleccionar" Then
                ' Fila seleccionada
                Dim hidID_SEC As HtmlInputHidden = CType(itemGrid.FindControl("hidID_DOCUMENTO_SEC"), HtmlInputHidden)
                Dim hidCOD_SEC As HtmlInputHidden = CType(itemGrid.FindControl("hidCOD_SEC"), HtmlInputHidden)
                Dim hidID_DOC As HtmlInputHidden = CType(itemGrid.FindControl("hidID_DOCUMENTO"), HtmlInputHidden)
                Dim hidTIPO_CREA As HtmlInputHidden = CType(itemGrid.FindControl("hidTIPO_CREACION"), HtmlInputHidden)
                '--
                objItemAcuerdo = New DocumentoSEC '//_Desc
                objItemAcuerdo.ID_DOCUMENTO_SEC = Funciones.CheckInt(hidID_SEC.Value)
                objItemAcuerdo.COD_SEC = Funciones.CheckInt(hidCOD_SEC.Value)
                objItemAcuerdo.ID_DOCUMENTO = Funciones.CheckInt(hidID_DOC.Value)
                objItemAcuerdo.TIPO_CREACION = Funciones.CheckStr(hidTIPO_CREA.Value)
                arrItems.Add(objItemAcuerdo)
                objItemAcuerdo = Nothing
            End If
        Next
        '---
        Return arrItems
    End Function

    Private Sub CerrarItemDocumento(ByVal filaSelec As Integer)
        '--
        Try
            Dim strScript As String = ""
            Dim itemGrid As DataGridItem = Me.dgItemsDoc.Items(filaSelec)

            Dim hidTmpTIPO_CREACION As HtmlInputHidden = CType(itemGrid.FindControl("hidTIPO_CREACION"), HtmlInputHidden)
            '---

            Dim strTipoIngresoConfig As String = ConfigurationSettings.AppSettings("TCREACION_INGRESO")
            If (hidTmpTIPO_CREACION.Value = strTipoIngresoConfig) Then

                '--Recupera Nro Solicitud y IdDocumento
                Dim hidTmpCOD_SEC As HtmlInputHidden = CType(itemGrid.FindControl("hidCOD_SEC"), HtmlInputHidden)
                Dim hidTmpID_DOCUMENTO As HtmlInputHidden = CType(itemGrid.FindControl("hidID_DOCUMENTO"), HtmlInputHidden)

                '---Crea objeto de entidad
                Dim objAcuerdoEnt As New Acuerdo
                objAcuerdoEnt.COD_SEC = Funciones.CheckInt(hidTmpCOD_SEC.Value)
                objAcuerdoEnt.ID_DOCUMENTO = Funciones.CheckInt(hidTmpID_DOCUMENTO.Value)

                '---Crea objeto de negocio y cierra
                Dim objAcuerdoIng As New AcuerdoNegocios
                If (objAcuerdoIng.Cerrar(objAcuerdoEnt)) Then
                    '--actualiza grilla
                    ObtenerDocumentosSEC()
                    strScript = "alert('" & Mensajes.INFO_DOCUMENTO_FUE_CERRADO & "'); "
                End If
            Else
                strScript = "alert('" & Mensajes.INFO_NO_DOCUMENTO_INGRESO_DATOS & "'); "
            End If

            '---
            If strScript <> "" Then
                Anthem.Manager.AddScriptForClientSideEval(strScript)
        End If
        Catch ex As Exception
            Anthem.Manager.AddScriptForClientSideEval("alert('" & ex.Message & "'); ")
        End Try
    End Sub

    Private Sub MostrarEdicionDocumentoAcuerdo(ByVal filaSelec As Integer)

        '---
        Dim strScript As String
        Dim itemGrid As DataGridItem = Me.dgItemsDoc.Items(filaSelec)

        '--obtiene datos
        Dim hidTmpID_DOCUMENTO_SEC As HtmlInputHidden = CType(itemGrid.FindControl("hidID_DOCUMENTO_SEC"), HtmlInputHidden)
        Dim hidTmpID_DOCUMENTO As HtmlInputHidden = CType(itemGrid.FindControl("hidID_DOCUMENTO"), HtmlInputHidden)
        Dim hidTmpTIPO_CREACION As HtmlInputHidden = CType(itemGrid.FindControl("hidTIPO_CREACION"), HtmlInputHidden)

        '---
        Dim strTipoIngresoConfig As String = ConfigurationSettings.AppSettings("TCREACION_INGRESO")

        If (hidTmpTIPO_CREACION.Value = strTipoIngresoConfig) Then
            '--determina si es para edicion
            Dim strEstadoConfig As String = ConfigurationSettings.AppSettings("ACUERDO_ESTADO_CREADO")
            Dim hidTmpCOD_ESTADO As HtmlInputHidden = CType(itemGrid.FindControl("hidCOD_ESTADO"), HtmlInputHidden)
            '--
            If (strEstadoConfig = hidTmpCOD_ESTADO.Value) Then
                '---obtiene dato de columna tipo documento
                Dim strNombreAbrev As String = itemGrid.Cells(4).Text   'columna NOmbre Doc (Abreviado B01, etcC)
                '---determina pagina en base a documento
                Dim strNombrePaginaMant As String
                strNombrePaginaMant = "sisact_mant_acuerdo_" & strNombreAbrev & ".aspx"
                Dim strVariables As String = "?NS=" & lblNroSolicitud.Text & _
                                            "&DC=" & hidTmpID_DOCUMENTO.Value & _
                                            "&NG=" & txtNombreGlosa.Text.ToUpper & _
                                            "&OP=2"
                                            
                If File.Exists(Me.Server.MapPath(strNombrePaginaMant)) Then '//--Estructura script y muestra popup
                    strScript = ObtenerScriptPopup(strNombrePaginaMant & strVariables, Funciones.CheckInt(hidTmpID_DOCUMENTO.Value))
                Else '//
                    strScript = "alert('" & Mensajes.ERROR_PAGINA_EDICION_DESCONOCIDA & "');"
                End If
            Else '**** strEstadoConfig <> strEstadoAcuerdo
                strScript = "alert('" & Mensajes.INFO_ACUERDO_CERRADO_NO_EDIT & "');"
            End If

        Else
            strScript = "alert('" & Mensajes.INFO_NO_DOCUMENTO_INGRESO_DATOS & "');"
        End If

        Anthem.Manager.AddScriptForClientSideEval(strScript)

    End Sub
    
    Private Sub dgItemsDoc_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgItemsDoc.ItemDataBound

        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            '--
            Dim hidTIPO_CREA As HtmlInputHidden = CType(e.Item.FindControl("hidTIPO_CREACION"), HtmlInputHidden)
            Dim hidESTADO As HtmlInputHidden = CType(e.Item.FindControl("hidCOD_ESTADO"), HtmlInputHidden)
            If (Not hidTIPO_CREA Is Nothing) Then
                Dim valorCreaIngreso As String = ConfigurationSettings.AppSettings("TCREACION_INGRESO").ToString
                Dim EsCreaIngreso As Boolean = (hidTIPO_CREA.Value = valorCreaIngreso)
                Dim chbxSelec As HtmlInputCheckBox = CType(e.Item.FindControl("chbxSeleccionar"), HtmlInputCheckBox)
                Dim ImgCerrar As Anthem.ImageButton = CType(e.Item.FindControl("ibtnCerrar"), Anthem.ImageButton)
                Dim ImgEditar As Anthem.ImageButton = CType(e.Item.FindControl("ibtnEditar"), Anthem.ImageButton)
                Dim valorCerrado As String = ConfigurationSettings.AppSettings("ACUERDO_ESTADO_CERRADO").ToString
                If ((Not ImgCerrar Is Nothing) And (Not EsCreaIngreso) And (Not hidESTADO.Value = valorCerrado)) Then
                    ImgCerrar.Attributes.Add("Style", "display:none")
                    ImgEditar.Attributes.Add("Style", "display:none")
                End If
                '---
                If (Not Me.EsActualizable) Then
                    chbxSelec.Attributes.Add("Style", "display:none")
                    ImgCerrar.Attributes.Add("Style", "display:none")
                    ImgEditar.Attributes.Add("Style", "display:none")
                End If
            End If
            '---para mostrar el archivo
            Dim objDocSEC As DocumentoSEC = CType(e.Item.DataItem, DocumentoSEC)
            If Not objDocSEC Is Nothing Then
                Dim sEvento As String = "javascript:verArchivo('" + objDocSEC.NOMBRE_ARCHIVO + "');"
                Dim hidImagenVer As HtmlImage = CType(e.Item.FindControl("imgVisualizar"), HtmlImage)
                If Not hidImagenVer Is Nothing Then
                    hidImagenVer.Attributes.Add("onclick", sEvento)
                End If
            End If
            objDocSEC = Nothing
        End If
    End Sub

    Private Sub dgItemsDoc_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItemsDoc.ItemCommand
        '--
        Dim indice As Integer
        indice = e.Item.ItemIndex
        '--procesa opcion seleccionada
        'Select Case (CType(e.CommandSource, Anthem.ImageButton)).CommandName
        Select Case e.CommandName
            Case "cerrar"
                CerrarItemDocumento(indice)
            Case "editar"
                MostrarEdicionDocumentoAcuerdo(indice)
            Case Else
                ' Do nothing.
        End Select

    End Sub

#End Region

    'SOLICITUD DE CAMBIO

    Function obtenerArrayRecibos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@Recibo@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aRecibo() As String = c.Split("|"c)
                Dim item As New ReciboDeposito
                'Condición para insertar o actualizar evaluar si tiene codigo SOL
                If CheckInt(aRecibo(6)) = 0 Then
                    item.RECIBO_ID = 0
                Else
                    item.RECIBO_ID = CheckInt(aRecibo(0))
                End If

                item.BANCO_ID = CheckInt(aRecibo(1))
                item.BANCO_DES = aRecibo(2)
                item.NRO_OPERACION = aRecibo(3)
                item.MONTO_DEPOSITO = CheckDbl(aRecibo(4))
                item.FECHA_DEPOSITO = CheckDate(aRecibo(5))
                item.LOGIN = CurrentUser
                item.TERMINAL = CurrentTerminal
                item.SOLIN_CODIGO = CheckInt64(Me.lblNroSolicitud.Text)
                salida.Add(item)
            End If
        Next
        Return salida
    End Function

    Sub grabar()
        Dim msg As String
        Dim usuario As String = CurrentUser
        Dim oConsulta As New SolicitudNegocios
        Dim listaArchivo As New ArrayList
        Dim listaRecibo As New ArrayList
        listaRecibo = obtenerArrayRecibos(hidListaRecibo.Value)

        Dim i As Integer
        Try
            If hidRecibosElim.Value.Trim.Length > 0 Then
                Dim CadElimRec As String = hidRecibosElim.Value
                Dim aListaRecElim() As String = CadElimRec.Split("|"c)
                For Each c As String In aListaRecElim
                    oConsulta.EliminarRecibo(lblNroSolicitud.Text, c.Trim, msg)
                Next
            End If

            If listaRecibo.Count > 0 Then
                For i = 0 To listaRecibo.Count - 1
                    Dim item As ReciboDeposito = CType(listaRecibo(i), ReciboDeposito)
                    Dim codigo As Int64
                    oConsulta.GrabarRecibo(item, codigo, msg)
                Next
            End If
            AuditoriaPagina.Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SISACT_ACUERDO_RECIBO_A"), String.Format("Se agregaron recibos para la SEC número {0}", Me.lblNroSolicitud.Text), Me.CurrentUser, Me.CurrentTerminal)
            ActualizarControlesEdicion()
        Catch ex As Exception
            hidMsg.Value = msg
            hidProceso.Value = "LIMPIAR"
        End Try
        hidMsg.Value = "Se registraron los datos satisfactoriamente"
        hidProceso.Value = "LIMPIAR"
        hidVisible.Value = "1"
    End Sub

End Class
