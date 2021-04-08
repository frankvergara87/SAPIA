Option Strict Off
Imports System.Text
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones

Public Class sisact_mant_renovaciones
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfiles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProvinciaId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCantidad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPeriodo As System.Web.UI.WebControls.TextBox

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

        If Not Page.IsPostBack Then
            Inicio()
        Else
            Try
                Dim strAccion As String = hidAccion.Value
                Select Case strAccion
                    Case "C"
                        Inicio()
                    Case "G"
                        GuardarMantenimiento()
                End Select
            Catch ex As Exception
                hidMsg.Value = ex.Message
            End Try
        End If
    End Sub

    Sub Inicio()
        Dim login As String = Me.CurrentUser
        Try
            Dim opciones As String = CheckStr(Session("OpcionesPagina"))
            Dim objLoginUsuario As New LoginUsuarioNegocios
            Dim codUsuarioSisact As Int64 = CheckInt64(Session("codUsuarioSisact"))
            Dim codAplicacion As Int64 = CheckInt64(ConfigurationSettings.AppSettings("CodigoAplicacion"))
            Dim oClienteNegocios As New ClienteNegocio
            Dim res As String = oClienteNegocios.ObtienePeriodoRenov()
            Dim arrayDatos() As String = res.Split(CChar(","))
            Dim res1 As String = arrayDatos(0)
            Dim res2 As String = arrayDatos(1)

            txtCantidad.Text = res1
            txtPeriodo.Text = res2

        Catch ex As Exception
            hidMsg.Value = ex.Message
        End Try

    End Sub

    Function GuardarMantenimiento()

        Dim vCantidad, vPeriodo As Integer
        Dim DclienteSAP(64) As String
        Dim existeSAP As Boolean = False

        vCantidad = txtCantidad.Text.Trim()
        vPeriodo = txtPeriodo.Text.Trim()
        Dim rpta As Boolean = False

        'Grabar en BD PVU
        rpta = grabarDatos(vCantidad, vPeriodo)

        If rpta > 0 Or rpta = True Then
            RegisterStartupScript("script", "<script> alert('Se realizó el proceso correctamente');</script>")
        Else
            RegisterStartupScript("script", "<script> alert('Ocurrió un error al realizar el proceso');</script>")
        End If

        hidResponse.Value = "Busqueda"
        Inicio()

    End Function

    Public Function grabarDatos(ByVal vCantidad As Integer, ByVal vPeriodo As Integer)

        Dim oClienteNegocios As New ClienteNegocio
        Dim intTrans As Int32

        Try
            intTrans = oClienteNegocios.Manten_Periodo_Renov(vCantidad, vPeriodo)
        Catch ex As Exception
        End Try

        Return intTrans

    End Function

End Class
