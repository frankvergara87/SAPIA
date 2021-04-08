Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_campanas
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
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSeleccionarPDV As System.Web.UI.WebControls.Button
    Protected WithEvents dgrOACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrOADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnQuitarOficina As System.Web.UI.WebControls.Button
    Protected WithEvents btnAsociarOficina As System.Web.UI.WebControls.Button
    Protected WithEvents dgrODCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrODDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrPDDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btn As System.Web.UI.WebControls.Button
    Protected WithEvents btnAsociarPlan As System.Web.UI.WebControls.Button
    Protected WithEvents hidPV_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlan_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtODDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnODBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrKACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSeleccionarKit As System.Web.UI.WebControls.Button
    Protected WithEvents btnSeleccionarPlan As System.Web.UI.WebControls.Button
    Protected WithEvents dgrPACabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrPADetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnQuitarPlan As System.Web.UI.WebControls.Button
    Protected WithEvents dgrPDCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnQuitarKit As System.Web.UI.WebControls.Button
    Protected WithEvents btnAsociarKit As System.Web.UI.WebControls.Button
    Protected WithEvents dgrKDCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKDDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidKit_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPDVs As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfiDescrips As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfiTipos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlaDescrips As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNomPromo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoProducto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCFPromocional As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaIniProm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFinProm As System.Web.UI.WebControls.TextBox

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
            Dim objLServicio As LServicio

                dgrOACabecera.DataSource = ""
                dgrOACabecera.DataBind()

                dgrODCabecera.DataSource = ""
                dgrODCabecera.DataBind()

                dgrPACabecera.DataSource = ""
                dgrPACabecera.DataBind()

                dgrPDCabecera.DataSource = ""
                dgrPDCabecera.DataBind()

                dgrKACabecera.DataSource = ""
                dgrKACabecera.DataBind()

                dgrKDCabecera.DataSource = ""
                dgrKDCabecera.DataBind()

                cargarTipoProd()

                RegisterStartupScript("script", "<script>f_Inicio()</script>")
  
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnSeleccionarPDV.Attributes.Add("onclick", "return f_MostrarPV();")
        btnSeleccionarPlan.Attributes.Add("onclick", "return f_MostrarPlan();")
        btnSeleccionarKit.Attributes.Add("onclick", "return f_MostrarKit();")

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
  
            hidCodigo.Value = String.Empty
            txtCodigo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            txtFechaInicio.Text = String.Empty
            txtFechaFin.Text = String.Empty
            ddlEstado.SelectedIndex = -1

            txtCFPromocional.Text = String.Empty
            txtFechaIniProm.Text = String.Empty
            txtFechaFinProm.Text = String.Empty
  
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLCampana As LCampana
        Dim dtb As DataTable

            objLCampana = New LCampana
            dtb = New DataTable

            dtb = objLCampana.fdtbTraer(hidCodigo.Value)

            txtCodigo.Text = Convert.ToString(dtb.Rows(0)("campv_codigo"))
            txtDescripcion.Text = Convert.ToString(dtb.Rows(0)("campv_descripcion"))
            txtNomPromo.Text = Convert.ToString(dtb.Rows(0)("campv_promocion"))
            ddlTipoProducto.SelectedValue = Convert.ToString(dtb.Rows(0)("campv_tipo_producto"))
            txtFechaInicio.Text = Left(Convert.ToString(dtb.Rows(0)("campd_fecha_inicio")), 10)
            txtFechaFin.Text = Left(Convert.ToString(dtb.Rows(0)("campd_fecha_fin")).Trim, 10)
            ddlEstado.SelectedValue = Convert.ToString(dtb.Rows(0)("campc_estado"))

            txtCFPromocional.Text = CheckStr((dtb.Rows(0)("cf_promocional")))
            txtFechaIniProm.Text = String.Format("{0:dd/MM/yyyy}", dtb.Rows(0)("fecha_ini_prom"))
            txtFechaFinProm.Text = String.Format("{0:dd/MM/yyyy}", dtb.Rows(0)("fecha_fin_prom"))

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarCampanaPV(hidCodigo.Value)
            dgrOADetalle.DataSource = dtb
            dgrOADetalle.DataBind()

            'ViewState("dtbCampanaPV") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarPVSinCampana(hidCodigo.Value)
            dgrODDetalle.DataSource = dtb
            dgrODDetalle.DataBind()

            'ViewState("dtbPV") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarCampanaPlan(hidCodigo.Value)
            dgrPADetalle.DataSource = dtb
            dgrPADetalle.DataBind()

            'ViewState("dtbCampanaPlan") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarPlanSinCampana(hidCodigo.Value)
            dgrPDDetalle.DataSource = dtb
            dgrPDDetalle.DataBind()

            'ViewState("dtbPlan") = dtb

            'objLCampana = New LCampana
            'dtb = New DataTable
            'dtb = objLCampana.fdtbListarCampanaKit(hidCodigo.Value)
            'dgrKADetalle.DataSource = dtb
            'dgrKADetalle.DataBind()

            'ViewState("dtbCampanaKit") = dtb

            'objLCampana = New LCampana
            'dtb = New DataTable
            'dtb = objLCampana.fdtbListarKitSinCampana(hidCodigo.Value)
            'dgrKDDetalle.DataSource = dtb
            'dgrKDDetalle.DataBind()

            'ViewState("dtbKit") = dtb

            txtCodigo.CssClass = "clsInputDisable"
            txtCodigo.ReadOnly = True

            PasarALiteral()

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
 
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Dim objLCampana As LCampana
        Dim dtb As DataTable

            Limpiar()

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarCampanaPV(String.Empty)
            dgrOADetalle.DataSource = dtb
            dgrOADetalle.DataBind()

            'ViewState("dtbCampanaPV") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarPVSinCampana(String.Empty)
            dgrODDetalle.DataSource = dtb
            dgrODDetalle.DataBind()

            'ViewState("dtbPV") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarCampanaPlan(String.Empty)
            dgrPADetalle.DataSource = dtb
            dgrPADetalle.DataBind()

            'ViewState("dtbCampanaPlan") = dtb

            objLCampana = New LCampana
            dtb = New DataTable
            dtb = objLCampana.fdtbListarPlanSinCampana(String.Empty)
            dgrPDDetalle.DataSource = dtb
            dgrPDDetalle.DataBind()

            'ViewState("dtbPlan") = dtb

            'objLCampana = New LCampana
            'dtb = New DataTable
            'dtb = objLCampana.fdtbListarCampanaKit(String.Empty)
            'dgrKADetalle.DataSource = dtb
            'dgrKADetalle.DataBind()

            'ViewState("dtbCampanaKit") = dtb

            'objLCampana = New LCampana
            'dtb = New DataTable
            'dtb = objLCampana.fdtbListarKitSinCampana(String.Empty)
            'dgrKDDetalle.DataSource = dtb
            'dgrKDDetalle.DataBind()

            'ViewState("dtbPlan") = dtb

            txtCodigo.CssClass = "clsInputEnable"
            txtCodigo.ReadOnly = False

            RegisterStartupScript("script", "<script>document.getElementById('tblPV').style.display = 'none';document.getElementById('tblPlan').style.display = 'none';document.getElementById('tblKit').style.display = 'none';f_MostrarTab('NUEVO')</script>")
  
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLCampana As LCampana
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean

            objLCampana = New LCampana
            objLCampana.fbooEliminar(hidCodigo.Value, Convert.ToString(Session("codUsuarioSisact")), curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDTH_Eliminar"), "Eliminar Campaña DTH")
            btnBuscar_Click(Nothing, Nothing)
   
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLCampana As LCampana
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
        Dim strPDVs As String = hidPDVs.Value
        Dim strPlanes As String = hidPlanes.Value

        Try
            strCodigo = txtCodigo.Text.Trim.ToUpper
            strDescripcion = txtDescripcion.Text.Trim.ToUpper
            strPromocion = txtNomPromo.Text.Trim.ToUpper
            dtmFechaInicio = Convert.ToDateTime(txtFechaInicio.Text)
            dtmFechaFin = Convert.ToDateTime(txtFechaFin.Text)
            strTipoProd = Convert.ToString(ddlTipoProducto.SelectedValue)
            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            Dim CFPromocional As String = txtCFPromocional.Text
            Dim fechaIniProm As String = txtFechaIniProm.Text
            Dim fechaFinProm As String = txtFechaFinProm.Text

            objLCampana = New LCampana

            If hidCodigo.Value.Length = 0 Then
                'objLCampana.fbooInsertar(strCodigo, strDescripcion, ddlEstado.SelectedValue, _
                '    strUsuario, dtmFechaInicio, dtmFechaFin, curSalida, Msg, dtbCampanaPV, dtbCampanaPlan, dtbCampanaKit)
                objLCampana.fbooInsertar(strCodigo, strDescripcion, strPromocion, strTipoProd, ddlEstado.SelectedValue, _
                    strUsuario, dtmFechaInicio, dtmFechaFin, CFPromocional, fechaIniProm, fechaFinProm, curSalida, Msg, strPDVs, strPlanes)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDTH_Insertar"), "Insertar Campaña DTH")
            Else
                'objLCampana.fbooModificar(hidCodigo.Value, strDescripcion, ddlEstado.SelectedValue, _
                '    strUsuario, dtmFechaInicio, dtmFechaFin, curSalida, Msg, dtbCampanaPV, dtbCampanaPlan, dtbCampanaKit)
                objLCampana.fbooModificar(hidCodigo.Value, strDescripcion, strPromocion, strTipoProd, ddlEstado.SelectedValue, _
                    strUsuario, dtmFechaInicio, dtmFechaFin, CFPromocional, fechaIniProm, fechaFinProm, curSalida, Msg, strPDVs, strPlanes)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDTH_Modificar"), "Modificar Campaña DTH")
            End If

            'LimpiarViewState()
            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripción ya existe.');fAsociarOficinas();fAsociarPlanes()</script>")
            ElseIf ex.Message.IndexOf("ORA-20660") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El código de la campaña ya existe.');fAsociarOficinas();fAsociarPlanes()</script>")
            Else
                Throw ex
            End If

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        'LimpiarViewState()
        btnBuscar_Click(Nothing, Nothing)
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

    Private Sub Buscar()
        Dim objLCampana As LCampana
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLCampana = New LCampana

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLCampana.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDTH_Consulta"), "Consulta Campaña DTH")
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

    Private Sub PasarALiteral()
        Dim Fila As DataGridItem

        hidPDVs.Value = String.Empty
        hidOfiDescrips.Value = String.Empty
        hidOfiTipos.Value = String.Empty
        hidPlanes.Value = String.Empty
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

    Sub cargarTipoProd()
        Dim lista As New ArrayList
        Dim oConsulta As New MaestroNegocio
        'Dim tipoProducto, tipoVenta As String
        lista = oConsulta.ListaTablaGeneralSISACT("CD") ' Tipo Producto
        ddlTipoProducto.DataSource = lista
        ddlTipoProducto.DataValueField = "Codigo"
        ddlTipoProducto.DataTextField = "Descripcion"
        ddlTipoProducto.DataBind()
    End Sub

End Class
