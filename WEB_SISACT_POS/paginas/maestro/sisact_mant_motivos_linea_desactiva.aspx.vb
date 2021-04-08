Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones

Public Class sisact_mant_motivos_linea_desactiva
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrGrillaDetalleServicios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRecomendacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMesesDesactiva As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMesesActiva As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrListado As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnDesactivar As System.Web.UI.HtmlControls.HtmlInputButton

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")

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
            Listar()
        End If

        btnAceptar.Attributes.Add("onclick", "return f_Aceptar()")
    End Sub

    Private Sub Listar()
        Dim objValidacionLinea As LValidacionLinea

        Try
            objValidacionLinea = New LValidacionLinea
            dgrListado.DataSource = objValidacionLinea.fdtbListarBusqueda()
            dgrListado.DataBind()

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        Finally
            objValidacionLinea = Nothing
            Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_MOT_DESAC_LINEA"), "Consulta Motivos de desactivación de líneas.")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objValidacionLinea As LValidacionLinea
        Dim strCodigo As String = txtCodigo.Text
        Dim strDescripcion As String = txtDescripcion.Text.Trim
        Dim strMotivo As String = txtMotivo.Text.Trim
        Dim strRecomendacion As String = txtRecomendacion.Text.Trim
        Dim strEstado As String = ddlEstado.SelectedValue
        Dim strMesesDesactiva As String = txtMesesDesactiva.Text.Trim
        Dim strMesesActiva As String = txtMesesActiva.Text.Trim
        Dim strUsuario As String = CurrentUser

        Dim estado, msg As String

        Try
            objValidacionLinea = New LValidacionLinea
            objValidacionLinea.fbooModificar(strCodigo, strDescripcion, strMotivo, strRecomendacion, strEstado, strMesesDesactiva, strMesesActiva, strUsuario, estado, msg)

            Listar()
        Finally
            objValidacionLinea = Nothing
            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_MOT_DESAC_LINEA"), "Actualización estado motivo de desactivación de línea.")
        End Try
    End Sub

    Private Sub btnDesactivar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesactivar.ServerClick
        Dim objValidacionLinea As LValidacionLinea
        Dim strCodigo As String = hidCodigo.Value
        Dim strUsuario As String = CurrentUser
        Dim estado As Integer
        Dim msg As String

        Try
            objValidacionLinea = New LValidacionLinea
            objValidacionLinea.fbooDesactivar(strCodigo, strUsuario, estado, msg)

            Listar()
        Finally
            objValidacionLinea = Nothing
            Auditoria(ConfigurationSettings.AppSettings("AUDIT_ELIM_MOT_DESAC_LINEA"), "Desactivación estado motivo de desactivación de línea.")
        End Try
    End Sub

    Private Sub Auditoria(ByVal strCodTrans As String, ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub
End Class
