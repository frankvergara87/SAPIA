Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_vendedor_pp
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalleServicios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDNI As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefono As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPosicion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSupervisor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigoEli As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSupervisor As System.Web.UI.HtmlControls.HtmlInputHidden

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
        'If Request.QueryString("cu") Is Nothing Then
        '    Response.Write("<script language=javascript>validarUrl();</script>")
        'Else
        '    Response.Write("<script language=javascript>restringirEventos();</script>")
        'End If

        'If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
        '    Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
        '    If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
        '        Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
        '        Response.Redirect(strRutaSite)
        '        Response.End()
        '        Exit Sub
        '    End If
        'End If

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnAceptar.Attributes.Add("onclick", "return f_Aceptar();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgrGrillaDetalle.CurrentPageIndex = 0
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strTipo As String = ddlBusqueda.SelectedValue
        Dim strDescripcion As String = txtBusDescripcion.Text.Trim.ToUpper

        Try
            If strDescripcion.Length > 0 Then
                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                objConsumerNegocio = New ConsumerNegocio
                dgrGrillaDetalle.DataSource = objConsumerNegocio.ListarVendedorPP(strTipo, strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        Catch ex As Exception
            Throw ex
        Finally
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantVendedor_Consultar"), "Consulta Vendedor.")
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strEstado As String = ddlEstado.SelectedValue
        Dim strPosicion As String = ddlPosicion.SelectedValue
        Dim strSupervisor As String = ddlSupervisor.SelectedValue
        Dim strCodigo As String = txtCodigo.Text
        Dim strDNI As String = txtDNI.Text
        Dim strEmail As String = txtEmail.Text.Trim.ToUpper
        Dim strNombre As String = txtNombre.Text.Trim.ToUpper
        Dim strTelefono As String = txtTelefono.Text.Trim
        Dim strUsuario As String = CurrentUser
        Dim strRetorno As String = String.Empty
        Dim strRetorno1 As String = String.Empty
        Try
            objConsumerNegocio = New ConsumerNegocio

            If strCodigo.Length = 0 Then
                objConsumerNegocio.InsertarVendedorPP(strDNI, strEmail, strNombre, strTelefono, strPosicion, strSupervisor, strUsuario, strRetorno)
                strRetorno1 = "f_MostrarTab('NUEVO')"
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantVendedor_Insertar"), "Registrar Vendedor.")
            Else
                objConsumerNegocio.ModificarVendedorPP(strCodigo, strDNI, strEmail, strNombre, strTelefono, strPosicion, strSupervisor, strEstado, strUsuario, strRetorno)
                strRetorno1 = "f_MostrarTab('EDICION')"
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantVendedor_Modificar"), "Actualizar Vendedor.")
            End If

            If strRetorno.Length = 0 Then
                btnBuscar_Click(Nothing, Nothing)

                RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
            Else
                RegisterStartupScript("script1", String.Format("<script>{0};alert('{1}')</script>", strRetorno1, strRetorno))
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objConsumerNegocio As ConsumerNegocio

        Try
            objConsumerNegocio = New ConsumerNegocio
            objConsumerNegocio.DesactivarVendedorPP(hidCodigoEli.Value, CurrentUser)

            btnBuscar_Click(Nothing, Nothing)

            RegisterStartupScript("script1", "<script>alert('Se desactivó el vendedor.')</script>")

            Auditoria(ConfigurationSettings.AppSettings("codTrsMantVendedor_Eliminar"), "Actualizar Estado Vendedor.")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ddlPosicion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPosicion.SelectedIndexChanged
        Dim strPosicion As String = ddlPosicion.SelectedValue
        Dim objConsumerNegocio As ConsumerNegocio

        Try
            objConsumerNegocio = New ConsumerNegocio
            ddlSupervisor.DataSource = objConsumerNegocio.ListarSupervisorPP(strPosicion)
            ddlSupervisor.DataValueField = "svppn_codigo"
            ddlSupervisor.DataTextField = "svppv_nombre"
            ddlSupervisor.DataBind()
            ddlSupervisor.Items.Insert(0, New ListItem("--SELECCIONAR--", "0"))

            If txtCodigo.Text.Length = 0 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION')</script>")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Try
            ddlPosicion_SelectedIndexChanged(Nothing, Nothing)
            ddlSupervisor.SelectedValue = hidSupervisor.Value

            If txtCodigo.Text.Length = 0 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION')</script>")
            End If
        Catch ex As Exception
            Throw ex
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
