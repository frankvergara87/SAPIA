Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Public Class sisact_pop_seguros
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrima As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeducible As System.Web.UI.WebControls.TextBox

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
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        Inicio()

    End Sub
    Private Sub Inicio()
        Try
            Dim strPrima As String = Funciones.CheckStr(Request.QueryString("strPrima"))
            Dim strDesEquipo As String = Funciones.CheckStr(Request.QueryString("strDesEquipo"))
            Dim strDeducible As String = Funciones.CheckStr(Request.QueryString("strDeducible")).Replace("=", "ñ")

            txtEquipo.Text = strDesEquipo.Trim()
            txtDeducible.Text = strDeducible.Trim()
            txtPrima.Text = strPrima.Trim()
        Catch ex As Exception
            'Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
