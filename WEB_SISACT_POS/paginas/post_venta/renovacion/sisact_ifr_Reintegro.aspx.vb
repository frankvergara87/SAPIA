Public Class sisact_ifr_Reintegro
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rbEfectivo As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbOCC As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblMensajeReintegro As System.Web.UI.WebControls.Label
    Protected WithEvents lblMontoReintegro As System.Web.UI.WebControls.Label
    Protected WithEvents hidFormaPagoReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidModalidadPago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagConfExoneracionReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagExonerarReintegro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOpcionAutorizacion As System.Web.UI.HtmlControls.HtmlInputHidden
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
        lblMontoReintegro.Text = Request.QueryString("msjmonto")
        hidModalidadPago.Value = Request.QueryString("strModalidad")

        If hidModalidadPago.Value = "Fidelizado" Then
            lblMensajeReintegro.Text = Convert.ToString(ConfigurationSettings.AppSettings("consMensajeRegular"))

        Else
            lblMensajeReintegro.Text = Convert.ToString(ConfigurationSettings.AppSettings("consMensajeRetenido"))
        End If

    End Sub

End Class
