Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_equipos
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
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlTipoEquipos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstadoEquipos As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrListadoGrupo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidEquiCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrupo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidChecks As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidGrupoSeleccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidObtValor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlEstadoEquipo3Play As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodigoE As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcionE As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidTipEqu As System.Web.UI.HtmlControls.HtmlInputHidden

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

            Dim objLEquipos3Play As New LEquipos3Play

            ddlEstadoEquipos.DataValueField = "ITEMN_CODIGO"
            ddlEstadoEquipos.DataTextField = "ITEMN_DESCRIPCION"
            ddlEstadoEquipos.DataSource = objLEquipos3Play.fdtbListarEstadoEquipos("2")
            ddlEstadoEquipos.DataBind()

            ddlTipoEquipos.DataValueField = "TMATC_CODIGO"
            ddlTipoEquipos.DataTextField = "TMATV_DESCRIPCION"
            ddlTipoEquipos.DataSource = objLEquipos3Play.fdtbListarTipoEquipos()
            ddlTipoEquipos.DataBind()

            dgrListadoGrupo.DataSource = objLEquipos3Play.fdtbListarGrupos()
            dgrListadoGrupo.DataBind()

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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgrGrillaDetalle.CurrentPageIndex = 0
        Buscar()

        Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_EQUIPO_3PLAY"), "Consulta Equipos 3Play.")
    End Sub

    Private Sub Buscar()
        Dim objLEquipos3Play As New LEquipos3Play
        Dim strDescripcion As String = txtBusDescripcion.Text.Trim

        If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()
            dgrGrillaDetalle.DataSource = objLEquipos3Play.fdtbListarBusquedaEquipos(strDescripcion, ddlEstadoEquipo3Play.SelectedValue.ToString())
            dgrGrillaDetalle.DataBind()
        End If

        hidGrupo.Value = String.Empty
        hidGrupoSeleccion.Value = String.Empty

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub
    Private Sub Limpiar()

        hidEquiCodigo.Value = String.Empty
        ddlBusqueda.SelectedIndex = 1
        txtBusDescripcion.Text = String.Empty
        txtBusDescripcion.ReadOnly = True
        txtBusDescripcion.CssClass = "clsInputDisable"
        ddlEstadoEquipo3Play.SelectedIndex = -1
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        ddlEstadoEquipos.SelectedIndex = -1
        ddlTipoEquipos.SelectedIndex = -1
        txtCodigoE.Text = String.Empty
        txtDescripcionE.Text = String.Empty
        hidTipEqu.Value = String.Empty

        hidGrupo.Value = String.Empty
        hidGrupoSeleccion.Value = String.Empty

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLEquipos3Play As New LEquipos3Play
        Dim dt As DataTable = objLEquipos3Play.fdtbTraerEquipos(hidEquiCodigo.Value)
        Dim strCadena As String = ""

        dt = objLEquipos3Play.fdtbTraerEquipos(hidEquiCodigo.Value)
        txtCodigo.Text = CheckStr(dt.Rows(0)("MATV_CODIGO"))
        txtDescripcion.Text = CheckStr(dt.Rows(0)("MATV_DESCRIPCION"))
        ddlTipoEquipos.SelectedValue = CheckStr(dt.Rows(0)("TMATC_CODIGO"))
        ddlEstadoEquipos.SelectedValue = CheckStr(dt.Rows(0)("MATC_ESTADO"))
        txtCodigoE.Text = CheckStr(dt.Rows(0)("MATV_ID_SAP"))
        hidTipEqu.Value = CheckStr(dt.Rows(0)("TIPEQU"))
        txtDescripcionE.Text = CheckStr(dt.Rows(0)("MATV_DES_SAP"))

        For Each dtRow As DataRow In dt.Rows
            strCadena = strCadena & CheckStr(dtRow.Item("GSRVC_CODIGO")) & "|"
        Next
        hidGrupo.Value = strCadena

        RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLEquipos3Play As New LEquipos3Play
        Dim curSalida As String
        Dim Msg As String

        Try
            Dim strGrupo As String = hidGrupoSeleccion.Value
            Dim strCodigo As String = CheckStr(txtCodigo.Text).ToUpper
            Dim strDescripcion As String = CheckStr(txtDescripcion.Text).ToUpper
            Dim strAccion As String = hidObtValor.Value

            objLEquipos3Play.fbooEquiInsertar(strCodigo, strDescripcion, ddlTipoEquipos.SelectedValue, _
                                ddlEstadoEquipos.SelectedValue, strGrupo, txtCodigoE.Text, txtDescripcionE.Text, hidTipEqu.Value, strAccion, CurrentUser, curSalida, Msg)

            If strAccion = "N" Then
                Auditoria(ConfigurationSettings.AppSettings("AUDIT_INS_EQUIPO_3PLAY"), "Insertar Equipo 3Play (Código: " & strCodigo & " )")
            Else
                Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_EQUIPO_3PLAY"), "Modificar Servicio 3Play (Código: " & strCodigo & " )")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                hidGrupo.Value = hidGrupoSeleccion.Value
                hidGrupoSeleccion.Value = String.Empty
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('El Código ya se encuentra registrado.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20771") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('No es posible desactivar el registro porque tiene configuraciones relacionadas.')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.')</script>")
            End If
        End Try

    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            If Not ddlEstadoEquipo3Play.SelectedValue.ToString() = "1" Then
                e.Item.Cells(4).Text = ""
            End If
        End If
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim curSalida As Integer
        Dim Msg As String
        Try
            Dim objLEquipos3Play As New LEquipos3Play
            objLEquipos3Play.fbooEqui3PlayEliminar(hidEquiCodigo.Value, CurrentUser, curSalida, Msg)

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_EQUIPO_3PLAY"), "Desactivar Servicio 3Play (Código: " & hidEquiCodigo.Value & " )")

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

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV") ' Cambiar por Equipos 
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub

End Class
