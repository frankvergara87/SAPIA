Public Class sisact_matrizdocumentos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents divSustentoIdentidad As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divSustentoDireccion As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divSustentoCapacidadPago As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divSustentoComplementario As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divSustentoTrabajadores As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divSustentoCliente As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divOtrosDocumentos As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents hidIdTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden

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
        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        Me.Response.Expires = 0
        Me.Response.Cache.SetNoStore()

        If Not Me.IsPostBack Then
            RecuperarParametros()
            MostrarPaneles()
        End If
    End Sub

    Private Sub RecuperarParametros()
        If (Me.Request.Params("TD") Is Nothing Or Me.Request.Params("TD") = "") Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If
        hidIdTipoDoc.Value = Me.Request.Params("TD")
    End Sub

    Private Sub MostrarPaneles()

        divSustentoIdentidad.Visible = (hidIdTipoDoc.Value = "4")
        divSustentoDireccion.Visible = (hidIdTipoDoc.Value = "5")
        divSustentoCapacidadPago.Visible = (hidIdTipoDoc.Value = "6")
        divSustentoComplementario.Visible = (hidIdTipoDoc.Value = "7")
        divSustentoTrabajadores.Visible = (hidIdTipoDoc.Value = "8")
        divSustentoCliente.Visible = (hidIdTipoDoc.Value = "9")
        divOtrosDocumentos.Visible = (hidIdTipoDoc.Value = "10")
    End Sub

End Class
