Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_con_pla
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoProducto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cblPlazoAcuerdo As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents dgrServicioCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrServicioDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidPlanCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCargoFijoA As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgrKADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKDDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKDCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidKit As System.Web.UI.HtmlControls.HtmlInputHidden

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
            Dim objLConfiguracionPlan As LConfiguracionPlan


                objLConfiguracionPlan = New LConfiguracionPlan
                ddlTipoProducto.DataValueField = "tproc_codigo"
                ddlTipoProducto.DataTextField = "tprov_descripcion"
                ddlTipoProducto.DataSource = objLConfiguracionPlan.fdtbListarProducto(String.Empty)
                ddlTipoProducto.DataBind()

                objLConfiguracionPlan = New LConfiguracionPlan
                cblPlazoAcuerdo.DataValueField = "plzac_codigo"
                cblPlazoAcuerdo.DataTextField = "plzav_descripcion"
                cblPlazoAcuerdo.DataSource = objLConfiguracionPlan.fdtbListarPlazo(String.Empty)
                cblPlazoAcuerdo.DataBind()

                dgrServicioCabecera.DataSource = ""
                dgrServicioCabecera.DataBind()

                dgrServicioDetalle.DataSource = objLConfiguracionPlan.fdtbListarServicio(String.Empty)
                dgrServicioDetalle.DataBind()

                dgrKACabecera.DataSource = ""
                dgrKACabecera.DataBind()

                dgrKDCabecera.DataSource = ""
                dgrKDCabecera.DataBind()

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

    End Sub

    Private Sub Limpiar()
        Dim objLConfiguracionPlan As LConfiguracionPlan

            objLConfiguracionPlan = New LConfiguracionPlan

            For Each lst As ListItem In cblPlazoAcuerdo.Items
                lst.Selected = False
            Next

            dgrServicioDetalle.DataSource = objLConfiguracionPlan.fdtbListarServicio(String.Empty)
            dgrServicioDetalle.DataBind()

            hidPlanCodigo.Value = String.Empty
            txtDescripcion.Text = String.Empty
            ddlEstado.SelectedIndex = -1
            'gaa20120115
            'ddlTipoProducto.SelectedIndex = -1
            ddlTipoProducto.SelectedValue = "01"
            txtCargoFijoA.Text = String.Empty
            'fin gaa20120115
            'gaa20131011
            hidKit.Value = String.Empty
            'fin gaa20131011
  
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLConfiguracionPlan As LConfiguracionPlan
        Dim dt As DataTable
        Dim strPlanCodigo As String = hidPlanCodigo.Value

            objLConfiguracionPlan = New LConfiguracionPlan
            dt = New DataTable

            dt = objLConfiguracionPlan.fdtbTraer(hidPlanCodigo.Value)

            txtDescripcion.Text = Convert.ToString(dt.Rows(0)("plnv_descripcion"))
            ddlTipoProducto.SelectedValue = Convert.ToString(dt.Rows(0)("tproc_codigo"))
            ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("plnc_estado"))
            'gaa20120115
            txtCargoFijoA.Text = Convert.ToString(dt.Rows(0)("plnn_cargo_fijo"))
            'fin gaa20120115

            objLConfiguracionPlan = New LConfiguracionPlan
            dt = New DataTable

            dt = objLConfiguracionPlan.fdtbListarPlazo(hidPlanCodigo.Value)
            For i As Integer = 0 To cblPlazoAcuerdo.Items.Count - 1
                If dt.Select("plzac_codigo = '" & cblPlazoAcuerdo.Items(i).Value & "'").Length > 0 Then
                    cblPlazoAcuerdo.Items(i).Selected = True
                Else
                    cblPlazoAcuerdo.Items(i).Selected = False
                End If
            Next

            objLConfiguracionPlan = New LConfiguracionPlan
            dgrServicioDetalle.DataSource = objLConfiguracionPlan.fdtbListarServicio(String.Empty)
            dgrServicioDetalle.DataBind()

            objLConfiguracionPlan = New LConfiguracionPlan
            dt = New DataTable

            Dim chk As CheckBox
            Dim txt As TextBox
            Dim ddl As DropDownList

            Dim dr As DataRow()

            dt = objLConfiguracionPlan.fdtbListarServicio(hidPlanCodigo.Value)
            For Each dgi As DataGridItem In dgrServicioDetalle.Items
                chk = DirectCast(dgi.Cells(0).FindControl("chkSD"), CheckBox)
                txt = DirectCast(dgi.Cells(4).FindControl("txtCargoFijo"), TextBox)
                ddl = DirectCast(dgi.Cells(6).FindControl("ddlServicioSeleccionable"), DropDownList)

                dr = dt.Select("servv_codigo = '" & dgi.Cells(1).Text & "'")

                If dr.Length > 0 Then
                    chk.Checked = True
                    txt.Text = Convert.ToString(dr(0).Item("cargoFijo"))
                    ddl.SelectedValue = Convert.ToString(dr(0).Item("seleccionable"))
                Else
                    chk.Checked = False
                End If
            Next
            'dgrServicioDetalle.DataSource = dt
            'dgrServicioDetalle.DataBind()

            'gaa20131010
            objLConfiguracionPlan = New LConfiguracionPlan
            dt = New DataTable
            dt = objLConfiguracionPlan.fdtbListarKitAsociado(strPlanCodigo)
            dgrKADetalle.DataSource = dt
            dgrKADetalle.DataBind()

            objLConfiguracionPlan = New LConfiguracionPlan
            dt = New DataTable
            dt = objLConfiguracionPlan.fdtbListarKitDisponible(strPlanCodigo)
            dgrKDDetalle.DataSource = dt
            dgrKDDetalle.DataBind()

            DirectCast(dgrKACabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalKA"), CheckBox).Checked = False
            DirectCast(dgrKDCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalKD"), CheckBox).Checked = False

            PasarALiteral()
            'fin gaa20131010

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    End Sub

    Private Sub PasarALiteral()
        Dim Fila As DataGridItem

        hidKit.Value = String.Empty

        For Each Fila In dgrKADetalle.Items
            hidKit.Value &= String.Format("|{0};{1};{2};{3}", Fila.Cells(1).Text, Fila.Cells(2).Text, Fila.Cells(3).Text, Fila.Cells(4).Text)
        Next
    End Sub

    Private Sub dgrServicioDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrServicioDetalle.ItemDataBound
        Dim txtCargoFijo As TextBox

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            txtCargoFijo = DirectCast(e.Item.Cells(4).FindControl("txtCargoFijo"), TextBox)
            txtCargoFijo.Text = e.Item.Cells(3).Text
            'txtCargoFijo.Attributes.Add("onkeypress", "javascript:();")
        End If
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Dim objLConfiguracionPlan As LConfiguracionPlan
        Dim dtb As DataTable

        Try
        Limpiar()

            objLConfiguracionPlan = New LConfiguracionPlan
            dtb = New DataTable
            dtb = objLConfiguracionPlan.fdtbListarKitAsociado(String.Empty)
            dgrKADetalle.DataSource = dtb
            dgrKADetalle.DataBind()

            objLConfiguracionPlan = New LConfiguracionPlan
            dtb = New DataTable
            dtb = objLConfiguracionPlan.fdtbListarKitDisponible(String.Empty)
            dgrKDDetalle.DataSource = dtb
            dgrKDDetalle.DataBind()

            DirectCast(dgrKACabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalKA"), CheckBox).Checked = False
            DirectCast(dgrKDCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalKD"), CheckBox).Checked = False

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLConfiguracionPlan As LConfiguracionPlan
        Dim curSalida As Integer
        Dim Msg As String
        Dim resultado As Boolean

            objLConfiguracionPlan = New LConfiguracionPlan
            objLConfiguracionPlan.fbooPlanEliminar(hidPlanCodigo.Value, Convert.ToString(Session("codUsuarioSisact")), curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantPlanDTH_Eliminar"), "Eliminar Plan DTH")
            btnBuscar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLConfiguracionPlan As LConfiguracionPlan
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim dtbPlazo As DataTable
        Dim dtbServicio As DataTable
        Dim drw As DataRow
        Dim chk As CheckBox
        Dim strCargo As String = "0"
        Dim strKits As String = hidKit.Value

        Try
            strDescripcion = txtDescripcion.Text.Trim.ToUpper

            objLConfiguracionPlan = New LConfiguracionPlan

            'Obtener Plazos y Servicios
            dtbPlazo = New DataTable
            dtbPlazo.Columns.Add("PLAZACODIGO")

            For Each lst As ListItem In cblPlazoAcuerdo.Items
                If lst.Selected Then
                    drw = dtbPlazo.NewRow
                    drw("PLAZACODIGO") = lst.Value
                    dtbPlazo.Rows.Add(drw)
                End If
            Next

            dtbPlazo.AcceptChanges()

            dtbServicio = New DataTable
            dtbServicio.Columns.Add("SERVICIOCODIGO")
            dtbServicio.Columns.Add("CARGO")
            dtbServicio.Columns.Add("SELECCIONABLE")

            For Each dgi As DataGridItem In dgrServicioDetalle.Items
                chk = DirectCast(dgi.Cells(0).FindControl("chkSD"), CheckBox)

                If chk.Checked Then
                    strCargo = DirectCast(dgi.Cells(4).FindControl("txtCargoFijo"), TextBox).Text
                    drw = dtbServicio.NewRow
                    drw("SERVICIOCODIGO") = dgi.Cells(1).Text()
                    drw("CARGO") = strCargo
                    drw("SELECCIONABLE") = DirectCast(dgi.Cells(6).FindControl("ddlServicioSeleccionable"), DropDownList).SelectedValue
                    dtbServicio.Rows.Add(drw)
                End If
            Next

            dtbServicio.AcceptChanges()
            '
            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            If hidPlanCodigo.Value.Length = 0 Then
                objLConfiguracionPlan.fbooPlanInsertar(strDescripcion, ddlEstado.SelectedValue, _
                    ddlTipoProducto.SelectedValue, txtCargoFijoA.Text, strUsuario, curSalida, Msg, dtbPlazo, dtbServicio, strKits)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantPlanDTH_Insertar"), "Insertar Plan DTH")
            Else
                objLConfiguracionPlan.fbooPlanModificar(hidPlanCodigo.Value, strDescripcion, ddlEstado.SelectedValue, _
                    ddlTipoProducto.SelectedValue, txtCargoFijoA.Text, strUsuario, curSalida, Msg, dtbPlazo, dtbServicio, strKits)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantPlanDTH_Modificar"), "Modificar Plan DTH")
            End If

            hidKit.Value = String.Empty

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripción ya existe.')</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objLConfiguracionPlan As LConfiguracionPlan
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLConfiguracionPlan = New LConfiguracionPlan

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLConfiguracionPlan.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantPlanDTH_Consulta"), "Consulta Plan DTH")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")

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
