Public Class sisact_cargar_archivo_consumer
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCodSolicitud As System.Web.UI.WebControls.TextBox

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
        'Put user code to initialize the page here
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If Session("CodUsuarioSisact") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not Page.IsPostBack Then
                If Not Request.QueryString("numSolicitud").ToString().Equals("") Then
                    Dim strSolicitud As String = Request.QueryString("numSolicitud").ToString()
                    txtCodSolicitud.Text = strSolicitud
                    RegisterStartupScript("script", "<script>f_Buscar();</script>")
                End If
                If Session("Rechazo") Is "1" Then
                    Session("Rechazo") = "0"
                    RegisterStartupScript("script", "<script>window.close(); parent.cerrarVentana();</script>")
                End If
            End If
        End If
    End Sub

End Class
