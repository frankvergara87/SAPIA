Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_campania
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPV_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlan_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidKit_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPDVs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfiDescrips As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfiTipos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlaDescrips As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNomPromo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSeleccionarPDV As System.Web.UI.WebControls.Button
    Protected WithEvents dgrOACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrOADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrODCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrODDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSeleccionarPlan As System.Web.UI.WebControls.Button
    Protected WithEvents dgrPACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrPADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrPDCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrPDDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button


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
            Dim objLServicio As LServicio
            dgrOACabecera.DataSource = ""
            dgrOACabecera.DataBind()

            dgrODCabecera.DataSource = ""
            dgrODCabecera.DataBind()

            dgrPACabecera.DataSource = ""
            dgrPACabecera.DataBind()

            dgrPDCabecera.DataSource = ""
            dgrPDCabecera.DataBind()

            RegisterStartupScript("script", "<script>f_Inicio()</script>")
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnSeleccionarPDV.Attributes.Add("onclick", "return f_MostrarPV();")
        btnSeleccionarPlan.Attributes.Add("onclick", "return f_MostrarPlan();")

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

        Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_CAMPANA_3PLAY"), "Consulta Campañas 3Play.")
    End Sub

    Private Sub Limpiar()
        hidCodigo.Value = String.Empty
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtNomPromo.Text = String.Empty
        txtFechaInicio.Text = String.Empty
        txtFechaFin.Text = String.Empty
        ddlEstado.SelectedIndex = -1

        ddlBusqueda.SelectedIndex = 1
        txtBusDescripcion.ReadOnly = True
        txtBusDescripcion.Text = String.Empty
        txtBusDescripcion.CssClass = "clsInputDisable"
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLCampana3Play As LCampana3Play
        Dim dtb As DataTable

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable

            dtb = objLCampana3Play.fdtbTraer(hidCodigo.Value)

            txtCodigo.Text = Convert.ToString(dtb.Rows(0)("campv_codigo"))
            txtDescripcion.Text = Convert.ToString(dtb.Rows(0)("campv_descripcion"))
            txtNomPromo.Text = Convert.ToString(dtb.Rows(0)("campv_promocion"))
            txtFechaInicio.Text = Left(Convert.ToString(dtb.Rows(0)("campd_fecha_inicio")), 10)
            txtFechaFin.Text = Left(Convert.ToString(dtb.Rows(0)("campd_fecha_fin")).Trim, 10)
            ddlEstado.SelectedValue = Convert.ToString(dtb.Rows(0)("campc_estado"))

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarCampanaPV(hidCodigo.Value)
            dgrOADetalle.DataSource = dtb
            dgrOADetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarPVSinCampana(hidCodigo.Value)
            dgrODDetalle.DataSource = dtb
            dgrODDetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarCampanaPlan(hidCodigo.Value)
            dgrPADetalle.DataSource = dtb
            dgrPADetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarPlanSinCampana(hidCodigo.Value)
            dgrPDDetalle.DataSource = dtb
            dgrPDDetalle.DataBind()

            txtCodigo.CssClass = "clsInputDisable"
            txtCodigo.ReadOnly = True

            PasarALiteral()

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Dim objLCampana3Play As LCampana3Play
        Dim dtb As DataTable
    
            Limpiar()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarCampanaPV(String.Empty)
            dgrOADetalle.DataSource = dtb
            dgrOADetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarPVSinCampana(String.Empty)
            dgrODDetalle.DataSource = dtb
            dgrODDetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarCampanaPlan(String.Empty)
            dgrPADetalle.DataSource = dtb
            dgrPADetalle.DataBind()

            objLCampana3Play = New LCampana3Play
            dtb = New DataTable
            dtb = objLCampana3Play.fdtbListarPlanSinCampana(String.Empty)
            dgrPDDetalle.DataSource = dtb
            dgrPDDetalle.DataBind()

            txtCodigo.CssClass = "clsInputEnable"
            txtCodigo.ReadOnly = False

            RegisterStartupScript("script", "<script>document.getElementById('tblPV').style.display = 'none';document.getElementById('tblPlan').style.display = 'none';f_MostrarTab('NUEVO')</script>")
   
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLCampana3Play As LCampana3Play
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean

        Try
            objLCampana3Play = New LCampana3Play
            objLCampana3Play.fbooEliminar(hidCodigo.Value, CurrentUser, curSalida, Msg)

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_CAMPANA_3PLAY"), "Desactivar Campaña 3Play (Código: " & hidCodigo.Value & " )")

            btnBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.')</script>")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLCampana3Play As LCampana3Play
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strCodigo As String = String.Empty
        Dim strDescripcion As String = String.Empty
        Dim strPromocion As String = String.Empty
        Dim strTipoProd As String = String.Empty
        Dim dtmFechaInicio As DateTime
        Dim dtmFechaFin As DateTime
        Dim dtbCampanaPV As DataTable
        Dim dtbCampanaPlan As DataTable
        Dim dtbCampanaKit As DataTable
        Dim strPDVs As String = "|" & hidPDVs.Value
        Dim strPlanes As String = "|" & hidPlanes.Value
        Dim strUsuario As String = CurrentUser

        Try
            strDescripcion = CheckStr(txtDescripcion.Text)
            strPromocion = CheckStr(txtNomPromo.Text).ToUpper
            dtmFechaInicio = Convert.ToDateTime(txtFechaInicio.Text)
            dtmFechaFin = Convert.ToDateTime(txtFechaFin.Text)

            objLCampana3Play = New LCampana3Play

            If hidCodigo.Value.Length = 0 Then
                objLCampana3Play.fbooInsertar(strDescripcion, strPromocion, ddlEstado.SelectedValue, _
                    strUsuario, dtmFechaInicio, dtmFechaFin, curSalida, Msg, strPDVs, strPlanes)

                Auditoria(ConfigurationSettings.AppSettings("AUDIT_INS_CAMPANA_3PLAY"), "Insertar Campaña 3Play (Código: " & strCodigo & " )")
            Else
                objLCampana3Play.fbooModificar(hidCodigo.Value, strDescripcion, strPromocion, strTipoProd, ddlEstado.SelectedValue, _
                    strUsuario, dtmFechaInicio, dtmFechaFin, curSalida, Msg, strPDVs, strPlanes)

                Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_CAMPANA_3PLAY"), "Modificar Campaña 3Play (Código: " & hidCodigo.Value & " )")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 And hidCodigo.Value.Length = 0 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('La campaña ya se encuentra registrada.');fAsociarOficinas();fAsociarPlanes()</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.')</script>")
            End If

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub EnlazarGrillaCampana(ByVal pdtbCampanaPV As DataTable, ByVal pdtbPV As DataTable)
        dgrOADetalle.DataSource = pdtbCampanaPV
        dgrOADetalle.DataBind()

        dgrODDetalle.DataSource = pdtbPV
        dgrODDetalle.DataBind()

        DirectCast(dgrOACabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalOA"), CheckBox).Checked = False
        DirectCast(dgrODCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalOD"), CheckBox).Checked = False
    End Sub

    Private Sub EnlazarGrillaCampanaPlan(ByVal pdtbCampanaPlan As DataTable, ByVal pdtbPlan As DataTable)
        dgrPADetalle.DataSource = pdtbCampanaPlan
        dgrPADetalle.DataBind()

        dgrPDDetalle.DataSource = pdtbPlan
        dgrPDDetalle.DataBind()

        DirectCast(dgrPACabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalPA"), CheckBox).Checked = False
        DirectCast(dgrPDCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalPD"), CheckBox).Checked = False
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    'Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
    '    If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
    '        If Not ddlEstadoPlan3Play.SelectedValue.ToString() = "1" Then
    '            e.Item.Cells(7).Text = ""
    '        End If
    '    End If
    'End Sub

    Private Sub Buscar()
        Dim objLCampana3Play As LCampana3Play
        Dim strDescripcion As String = txtBusDescripcion.Text.Trim

        If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
            objLCampana3Play = New LCampana3Play

            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()
            dgrGrillaDetalle.DataSource = objLCampana3Play.fdtbListarBusqueda(strDescripcion)
            dgrGrillaDetalle.DataBind()
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub PasarALiteral()
        Dim Fila As DataGridItem

        hidPDVs.Value = ""
        hidOfiDescrips.Value = String.Empty
        hidOfiTipos.Value = String.Empty
        hidPlanes.Value = ""
        hidPlaDescrips.Value = String.Empty

        For Each Fila In dgrOADetalle.Items
            hidPDVs.Value &= Fila.Cells(1).Text & "|"
            hidOfiDescrips.Value &= Fila.Cells(2).Text & "|"
            hidOfiTipos.Value &= Fila.Cells(3).Text & "|"
        Next
        For Each Fila In dgrPADetalle.Items
            hidPlanes.Value &= Fila.Cells(1).Text & "|"
            hidPlaDescrips.Value &= Fila.Cells(2).Text & "|"
        Next
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
