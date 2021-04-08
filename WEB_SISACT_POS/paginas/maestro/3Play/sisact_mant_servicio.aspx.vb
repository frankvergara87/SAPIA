Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_servicio
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtDescripcionBSCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtOrden As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgrGrillaDetalleServicios As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidServCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidServicio3Play As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlGrupo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstadoServ3Play As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodExterno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidIdConfigITW As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDescripcion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIdSISACT As System.Web.UI.HtmlControls.HtmlInputHidden

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
            Dim objLServicio3Play As New LServicio3Play

            ddlEstado.DataValueField = "ITEMN_CODIGO"
            ddlEstado.DataTextField = "ITEMN_DESCRIPCION"
            ddlEstado.DataSource = objLServicio3Play.fdtbListarEstadoServ3Play("2")
            ddlEstado.DataBind()

            ddlGrupo.DataValueField = "GSRVC_CODIGO"
            ddlGrupo.DataTextField = "GSRVV_DESCRIPCION"
            ddlGrupo.DataSource = objLServicio3Play.fdtbListarGrupos()
            ddlGrupo.DataBind()
            RegisterStartupScript("script", "<script>f_Inicio()</script>")
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")

        If ddlBusqueda.SelectedValue = "1" Then
            txtBusDescripcion.ReadOnly = True
            txtBusDescripcion.CssClass = "clsInputDisable"
        Else
            txtBusDescripcion.ReadOnly = False
            txtBusDescripcion.CssClass = "clsInputEnable"
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLServicio3Play As New LServicio3Play
        Dim curSalida As String
        Dim Msg As String
        Try
            Dim strCod As String = CheckStr(txtCodigo.Text)
            Dim strDescripcion As String = CheckStr(txtDescripcion.Text)
            Dim intOrden As Integer = CheckInt(txtOrden.Text)
            'Dim strCodExt As String = CheckStr(txtCodExterno.Text)
            Dim strIdConfigITW As String = CheckStr(hidIdConfigITW.Value)
            Dim strDescripcionExt As String = CheckStr(txtCodExterno.Text)
            'gaa20131003
            Dim strDescripcionBSCS As String = CheckStr(txtDescripcionBSCS.Text)
            'fin gaa20131003
            If hidServCodigo.Value.Length = 0 Then
                objLServicio3Play.fbooServInsertar(strCod, strDescripcion, strIdConfigITW, strDescripcionExt, strDescripcionBSCS, ddlEstado.SelectedValue, ddlGrupo.SelectedValue, intOrden, CurrentUser, curSalida, Msg)

                Auditoria(ConfigurationSettings.AppSettings("AUDIT_INS_SERVICIO_3PLAY"), "Insertar Servicio 3Play (Código: " & strCod & " )")
            Else
                objLServicio3Play.fbooServ3PlayModificar(hidIdSISACT.Value, strDescripcion, strIdConfigITW, strDescripcionExt, strDescripcionBSCS, ddlEstado.SelectedValue, ddlGrupo.SelectedValue, intOrden, CurrentUser, curSalida, Msg)

                Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_SERVICIO_3PLAY"), "Modificar Servicio 3Play (Código: " & strCod & " )")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 And hidServCodigo.Value.Length = 0 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('El Código ya se encuentra registrado.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20771") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('No es posible desactivar el registro porque tiene configuraciones relacionadas.')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.')</script>")
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalleServicios.DataSource = Nothing
        dgrGrillaDetalleServicios.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgrGrillaDetalleServicios.CurrentPageIndex = 0
        Buscar()

        Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_SERVICIO_3PLAY"), "Consulta Servicios 3Play.")
    End Sub

    Private Sub Buscar()
        Dim objLServicio3Play As New LServicio3Play
        Dim strDescripcion As String = CheckStr(txtBusDescripcion.Text)

        If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()
            dgrGrillaDetalleServicios.DataSource = objLServicio3Play.fdtbListarBusquedaServicio3Play(strDescripcion, ddlEstadoServ3Play.SelectedValue)
            dgrGrillaDetalleServicios.DataBind()
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalleServicios.DataSource = Nothing
        dgrGrillaDetalleServicios.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub Limpiar()

        hidServCodigo.Value = String.Empty
        ddlBusqueda.SelectedIndex = 1
        txtBusDescripcion.Text = String.Empty
        txtBusDescripcion.ReadOnly = True
        txtBusDescripcion.CssClass = "clsInputDisable"
        ddlEstadoServ3Play.SelectedIndex = -1
        txtCodigo.Text = String.Empty
        txtDescripcionBSCS.Text = String.Empty
        ddlEstado.SelectedIndex = -1
        ddlGrupo.SelectedIndex = -1
        txtOrden.Text = String.Empty
        hidIdSISACT.Value = String.Empty
        'gaa20130923
        txtCodExterno.Text = String.Empty
        'fin gaa20130923
        'gaa20131003
        txtDescripcion.Text = String.Empty
        'fin gaa20131003
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub dgrGrillaDetalleServicios_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalleServicios.PageIndexChanged
        dgrGrillaDetalleServicios.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub dgrGrillaDetalleServicios_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalleServicios.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            If Not ddlEstadoServ3Play.SelectedValue.ToString() = "1" Then
                e.Item.Cells(6).Text = ""
            End If
        End If
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLServicio3Play As New LServicio3Play
        Dim dt As DataTable = objLServicio3Play.fdtbTraerServicio3Play(hidServCodigo.Value)

        hidIdSISACT.Value = CheckStr(dt.Rows(0)("SERVV_CODIGO"))
        txtCodigo.Text = CheckStr(dt.Rows(0)("SERVV_ID_BSCS"))
        txtDescripcion.Text = CheckStr(dt.Rows(0)("SERVV_DESCRIPCION"))
        ddlEstado.SelectedValue = CheckStr(dt.Rows(0)("SERVC_ESTADO"))
        ddlGrupo.SelectedValue = CheckStr(dt.Rows(0)("GSRVC_CODIGO"))
        txtOrden.Text = CheckStr(dt.Rows(0)("SERVN_ORDEN"))
        'gaa20130923
        txtCodExterno.Text = CheckStr(dt.Rows(0)("SERVV_DES_EXT"))
        hidIdConfigITW.Value = CheckStr(dt.Rows(0)("SERVV_CODIGO_EXT"))
        'fin gaa20130923
        'gaa20131003
        txtDescripcionBSCS.Text = CheckStr(dt.Rows(0)("SERVV_DES_BSCS"))
        'fin gaa20131003
        RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim curSalida As Integer
        Dim Msg As String
        Try
            Dim objLServicio3Play As New LServicio3Play
            objLServicio3Play.fbooServ3PlayEliminar(hidServCodigo.Value, CurrentUser, curSalida, Msg)

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_SERVICIO_3PLAY"), "Desactivar Servicio 3Play (Código: " & hidServCodigo.Value & " )")

            btnBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20771") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('No es posible desactivar el registro porque tiene configuraciones relacionadas.')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.')</script>")
            End If
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
