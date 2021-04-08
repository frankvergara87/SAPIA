Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.Text.RegularExpressions
Imports System.IO
Imports Claro.SisAct.Common.Funciones
Imports System.Data

Public Class sisact_cargar_archivo_solicitud_consumer
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodSol As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTipoDoc As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblNroDoc As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazon As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaArchivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroSec As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAnexar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVisible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaRecibo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroFilas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMontoIngreso As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblDetalle As System.Web.UI.HtmlControls.HtmlTable

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim accion As String = Request.QueryString("hidProceso")
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If Session("CodUsuarioSisact") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not Page.IsPostBack Then
                buscar()
            Else
                If hidProceso.Value = Nothing Then hidProceso.Value = ""
                If hidProceso.Value = "" Then
                    accion = Request.QueryString("hidProceso")
                End If
                accion = hidProceso.Value
                Select Case accion
                    Case "buscar"
                        buscar()
                    Case "grabar"
                        grabar()
                    Case "grabarRechazo"
                        grabarRechazo()
                End Select
            End If
        End If
    End Sub
    Sub buscar()
        Dim oConsulta As New SolicitudNegocios
        Dim item As New SolicitudPersona
        Dim solEmp As ConsultaSolicitud
        Dim codSol As String = Request.QueryString("strCodSolicitud")

        item = oConsulta.ObtenerSolicitudPersonaCons(codSol)
        lblCodSol.Text = CheckStr(item.SOLIN_CODIGO)
        lblTipoDoc.Text = item.TDOCV_DESCRIPCION
        If item.CLIEV_RAZ_SOC = "" Then
            lblRazon.Text = item.CLIEV_NOMBRE & " " & item.CLIEV_APE_PAT & " " & item.CLIEV_APE_MAT
        Else
            lblRazon.Text = item.CLIEV_RAZ_SOC
        End If
        lblNroDoc.Text = item.CLIEC_NUM_DOC
        hidNroSec.Value = codSol


    End Sub
    Sub grabarRechazo()
        Dim oSolicitud As New SolicitudNegocios
        Dim flag As Boolean
        Dim objSolicitudEval As New VistaSolicitudEvaluacion

        objSolicitudEval.SOLIN_CODIGO = CType(lblCodSol.Text, Integer)
        objSolicitudEval.ESTAC_CODIGO = "R"

        flag = oSolicitud.ValidarEvaluacion(objSolicitudEval)

        If flag = True Then
            RegisterStartupScript("script", "<script>alert('La solicitud Nro. " & lblCodSol.Text & " será rechazada por no adjuntar sustento de ingreso ');</script>")
            Dim strUsuario As String = CurrentUser.ToUpper() 'Usuario de Sesion en Produccion
            Dim strEstado As String = ConfigurationSettings.AppSettings("constcodEstadoRECHAZADOXNOADJSUSTENTO")
            Dim strMensaje As String = ""
            oSolicitud.GrabarLogHistorico(CType(lblCodSol.Text, Integer), strEstado, strUsuario, strMensaje)

            Session("Rechazo") = "1"

        Else
            RegisterStartupScript("script", "<script>alert('Error al enviar la solicitud');</script>")
        End If

        hidProceso.Value = "LIMPIAR"
        hidVisible.Value = "1"

    End Sub
    Sub grabar()
        Dim msg As String
        Dim usuario As String = CurrentUser
        Dim oConsulta As New SolicitudNegocios
        Dim listaArchivo As New ArrayList
        Dim listaRecibo As New ArrayList
        Dim strCadena As String

        listaArchivo = obtenerListaArchivos(hidListaArchivos.Value)
        listaRecibo = obtenerArrayRecibos(hidListaRecibo.Value)
        Dim i As Integer
        Try
            If txtMontoIngreso.Text.Equals("") Then
                txtMontoIngreso.Text = "0"
            End If

            If listaArchivo.Count > 0 Then
                For i = 0 To listaArchivo.Count - 1
                    Dim item As ItemGenerico = CType(listaArchivo(i), ItemGenerico)
                    oConsulta.GrabarArchivo(lblCodSol.Text, item.Descripcion, item.Codigo, usuario, 0, msg)
                Next

                oConsulta.GrabarFlagTerminadoSol_Cons(lblCodSol.Text, usuario, CType(txtMontoIngreso.Text, Decimal), msg)
            End If
        Catch ex As Exception
            hidMsg.Value = msg
            hidProceso.Value = "LIMPIAR"
        End Try
    End Sub
    Public Function obtenerListaArchivos(ByVal lista As String) As ArrayList
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
    Function obtenerArrayRecibos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@Recibo@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aRecibo() As String = c.Split("|"c)
                Dim item As New ReciboDeposito
                item.RECIBO_ID = CheckInt(aRecibo(0))
                item.BANCO_ID = CheckInt(aRecibo(1))
                item.BANCO_DES = aRecibo(2)
                item.NRO_OPERACION = aRecibo(3)
                item.MONTO_DEPOSITO = CheckDbl(aRecibo(4))
                item.FECHA_DEPOSITO = CheckDate(aRecibo(5))
                item.LOGIN = CurrentUser
                item.TERMINAL = CurrentTerminal
                item.SOLIN_CODIGO = CheckInt64(lblCodSol.Text)
                salida.Add(item)
            End If
        Next
        Return salida
    End Function
End Class