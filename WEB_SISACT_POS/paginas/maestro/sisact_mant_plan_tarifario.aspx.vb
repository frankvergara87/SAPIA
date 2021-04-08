Option Strict Off
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_plan_tarifario
    Inherits SisAct_WebBase 'hereda de la clase SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodPlanSisact As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDesPlanSisact As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodPlanSAP As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkCopiarPlan1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtCodPlanBSCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDesPlanBase As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCargoFijo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLimiteCredito As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents chkSinCuotas As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chk6Cuotas As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chk12Cuotas As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txt6Cuotas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt12Cuotas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt18Cuotas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSinCuotas As System.Web.UI.WebControls.TextBox
    Protected WithEvents chk18Cuotas As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgrTopeConsumoDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkRestriccionPDV As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dgPDV As System.Web.UI.WebControls.DataGrid
    Protected WithEvents trBusquedaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trGrillaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ddlOferta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoDespacho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlExcCasoEsp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSinTope As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSinCF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlConCF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAutomatico As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlGrupoPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlazoAcuerdo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCuotaInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoFlujo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkCopiarPlan As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnEliminarPDV As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlTopeConsumo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstadoTope As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cltCuotas As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents Tr3 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr4 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgDetallePlan As System.Web.UI.WebControls.DataGrid
    Protected WithEvents fagregar As System.Web.UI.WebControls.Button
    Protected WithEvents trPestanas As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnEliminarCanal As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlTipoProducto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarDetalle As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlEstadoListado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEliminarItemsPdv As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarItemsDetalle As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarItems As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminarTodosDetallePlan As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificarDetallePlan As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminarDetallePlan As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ctlTipoDocumento As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chkFlagRenovacion As System.Web.UI.WebControls.CheckBox

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
    
                llenarCombos()
                ListarGrillaConsumo(String.Empty)
                Limpiar()
                RegisterStartupScript("script", "<script>f_Inicio();</script>")
 
        End If

        btnEliminarItems.Attributes.Add("onclick", "return f_EliminarItems();")

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnEliminarItemsPdv.Attributes.Add("onclick", "return f_ConfirmarEliminarItems();")
        btnEliminarItemsDetalle.Attributes.Add("onclick", "return f_ConfirmarEliminarItems();")
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

        If hidCondicion.Value = "PDV" Then
            hidCondicion.Value = String.Empty
            dgPDV.CurrentPageIndex = 0
            ListarPDV()
        End If

        If hidCondicion.Value = "DETALLE" Then
            hidCondicion.Value = String.Empty
            Me.dgDetallePlan.CurrentPageIndex = 0
            ListarDetallePlan()
        End If

        If hidCondicion.Value = "GRUPO" Then
            hidCondicion.Value = String.Empty
            Me.dgDetallePlan.CurrentPageIndex = 0
            agregarGrupo()
        End If

    End Sub

    Private Sub dgrTopeConsumoDetalle_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrTopeConsumoDetalle.ItemDataBound
        Dim ddlConsumoEstado As DropDownList

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            ddlConsumoEstado = DirectCast(e.Item.Cells(3).FindControl("ddlConsumoEstado"), DropDownList)
            ListarComboConsumo(ddlConsumoEstado, e.Item.Cells(2).Text)
        End If
    End Sub

    Private Sub ListarComboConsumo(ByVal pDdlConsumoEstado As DropDownList, ByVal pstrValorSeleccionado As String)
        Dim objLTipoClientePlan As LTipoClientePlan

            objLTipoClientePlan = New LTipoClientePlan

            pDdlConsumoEstado.DataValueField = "ITEMN_CODIGO"
            pDdlConsumoEstado.DataTextField = "ITEMN_DESCRIPCION"
            pDdlConsumoEstado.DataSource = New PlanTarifarioBusinessLogic().ListarEstadoTope()
            pDdlConsumoEstado.DataBind()

    End Sub

    Private Sub ListarGrillaConsumo(ByVal pstrPlanCodigo As String)
        Dim objLTipoClientePlan As LTipoClientePlan

            dgrTopeConsumoDetalle.DataSource = New PlanTarifarioBusinessLogic().ListarTopeConsumo()
            dgrTopeConsumoDetalle.DataBind()
 
    End Sub

    Sub llenarCombos()

        ddlEstado.DataValueField = "ITEMN_CODIGO"
        ddlEstado.DataTextField = "ITEMN_DESCRIPCION"
        ddlEstado.DataSource = New PlanTarifarioBusinessLogic().ListarEstado()
        ddlEstado.DataBind()
        ddlEstado.SelectedIndex = 1

        ddlOferta.DataValueField = "TOFC_CODIGO"
        ddlOferta.DataTextField = "TOFV_DESCRIPCION"
        ddlOferta.DataSource = New PlanTarifarioBusinessLogic().ListarOferta() 'ListarOferta()
        ddlOferta.DataBind()

        ddlTipoDespacho.DataValueField = "DPCHN_CODIGO"
        ddlTipoDespacho.DataTextField = "DPCHV_DESCRIPCION"
        ddlTipoDespacho.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDespacho()
        ddlTipoDespacho.DataBind()

        ddlTipoFlujo.DataValueField = "ITEMN_CODIGO"
        ddlTipoFlujo.DataTextField = "ITEMN_DESCRIPCION"
        ddlTipoFlujo.DataSource = New PlanTarifarioBusinessLogic().ListarTipoFlujo()
        ddlTipoFlujo.DataBind()
        ddlTipoFlujo.SelectedIndex = 2

        agregarGrupo()

        ddlTipoPlan.DataValueField = "ITEMN_CODIGO"
        ddlTipoPlan.DataTextField = "ITEMN_DESCRIPCION"
        ddlTipoPlan.DataSource = New PlanTarifarioBusinessLogic().ListarTipoPlan
        ddlTipoPlan.DataBind()

        ddlTipoProducto.DataValueField = "PRDC_CODIGO"
        ddlTipoProducto.DataTextField = "PRDV_DESCRIPCION"
        ddlTipoProducto.DataSource = New PlanTarifarioBusinessLogic().ListarTipoProducto
        ddlTipoProducto.DataBind()

        'ctlTipoDocumento
        ctlTipoDocumento.DataValueField = "DOCC_CODIGO"
        ctlTipoDocumento.DataTextField = "DOCV_DESCRIPCION"
        ctlTipoDocumento.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento() 'dtTipoDocumento 'New PlanTarifarioBusinessLogic().ListarTipoDocumento()
        ctlTipoDocumento.DataBind()

    End Sub

    Private Sub agregarGrupo()
        ddlGrupoPlan.DataValueField = "GPLNC_CODIGO"
        ddlGrupoPlan.DataTextField = "GPLNV_DESCRIPCION"
        Me.ddlGrupoPlan.DataSource = New PlanTarifarioBusinessLogic().ListarGrupo
        Me.ddlGrupoPlan.DataBind()
        ddlGrupoPlan.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        If Not Session("IdGrupo") Is Nothing Then
            ddlGrupoPlan.SelectedValue = CType(Session("IdGrupo"), String)
            Session("IdGrupo") = Nothing
        End If
        Me.ddlEstado.SelectedIndex = 1
        Me.ddlEstado.Enabled = False

        RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');f_mostrarPestaña(1);</script>")
    End Sub
    Private Sub ListarPDV()

        dgPDV.DataSource = CType(Session("oArrayListSessionPdv"), ArrayList)
        dgPDV.DataBind()
        hidCondicion.Value = String.Empty
        RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(1);</script>")
    End Sub

    Private Sub ListarDetallePlan()
        Me.dgDetallePlan.DataSource = CType(Session("ListaDetalle"), ArrayList)
        dgDetallePlan.DataBind()
        Session("Coleccion") = Nothing
        hidCondicion.Value = String.Empty
        RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(2);</script>")
    End Sub

    Function ListarOferta() As DataTable

        Return New PlanTarifarioBusinessLogic().ListarOferta()
    End Function

    Private Sub Limpiar()
  
            dgPDV.DataSource = Nothing
            dgPDV.DataBind()
            dgDetallePlan.DataSource = Nothing
            dgDetallePlan.DataBind()

            Me.txtBusDescripcion.Text = String.Empty
            Me.txtCargoFijo.Text = "0.0"
            Me.txtCodPlanBSCS.Text = String.Empty
            Me.txtCodPlanSAP.Text = String.Empty
            Me.txtCodPlanSisact.Text = String.Empty
            Me.txtDesPlanBase.Text = String.Empty
            Me.txtDesPlanSisact.Text = String.Empty
            Me.txtLimiteCredito.Text = "0.0"
            Me.ddlBusqueda.SelectedIndex = -1
            Me.ddlEstado.SelectedIndex = 1
            Me.ddlExcCasoEsp.SelectedIndex = 1
            Me.ddlGrupoPlan.SelectedIndex = -1
            Me.ddlOferta.SelectedIndex = -1
            Me.ddlTipoDespacho.SelectedIndex = -1
            Me.ddlTipoFlujo.SelectedIndex = -1
            ddlGrupoPlan.SelectedIndex = -1
            ddlTipoProducto.SelectedValue = ConfigurationSettings.AppSettings("constTipoProductoMovil").ToString()

            Me.chkFlagRenovacion.Checked = False

            For Each lit As ListItem In ctlTipoDocumento.Items
                lit.Selected = False
            Next

            Session("oArrayListSessionPdv") = Nothing
            Session("ListaDetalle") = Nothing
 
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()
        Me.btnExportar.Visible = False
        Me.btnEliminarItems.Visible = False

        If ddlBusqueda.SelectedValue = "1" Then
            txtBusDescripcion.ReadOnly = True
            txtBusDescripcion.CssClass = "clsInputDisable"
        Else
            txtBusDescripcion.ReadOnly = False
            txtBusDescripcion.CssClass = "clsInputEnable"
        End If
        Limpiar()
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick

        Limpiar()
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');</script>")
        txtCodPlanSisact.Enabled = True
        txtCodPlanSisact.CssClass = "clsInputEnable"
        ListarGrillaConsumo(String.Empty)
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick

            Limpiar()
            Dim CodPlan As String = CheckStr(hidCodigo.Value)
            Dim oPlanTarifario As PlanTarifario = New PlanTarifarioBusinessLogic().getPlan(CodPlan)

            txtCodPlanSisact.Text = CodPlan
            txtCodPlanSisact.Enabled = False
            txtCodPlanSisact.CssClass = "clsInputDisable"
            Me.ddlEstado.Enabled = True

            Me.txtDesPlanSisact.Text = oPlanTarifario.DescripcionPlan
            Me.txtCodPlanSAP.Text = oPlanTarifario.CodigoPlanSap
            Me.txtCodPlanBSCS.Text = oPlanTarifario.CodigoPlanBscs
            Me.txtDesPlanBase.Text = oPlanTarifario.DescripcionPlanBase
            Me.txtCargoFijo.Text = oPlanTarifario.CargoFijo
            Me.txtLimiteCredito.Text = oPlanTarifario.LimiteCredito

            Me.ddlOferta.SelectedValue = IIf(oPlanTarifario.IdOferta = String.Empty, ddlOferta.SelectedValue, oPlanTarifario.IdOferta)
            Me.ddlEstado.SelectedValue = IIf(oPlanTarifario.IdEstado = String.Empty, ddlEstado.SelectedValue, oPlanTarifario.IdEstado)
            Me.ddlTipoFlujo.SelectedValue = IIf(oPlanTarifario.IdTipoFlujo = String.Empty, ddlTipoFlujo.SelectedValue, oPlanTarifario.IdTipoFlujo)
            Me.ddlTipoDespacho.SelectedValue = IIf(oPlanTarifario.IdTipoDespacho = String.Empty, ddlTipoDespacho.SelectedValue, oPlanTarifario.IdTipoDespacho)
            Me.ddlTipoPlan.SelectedValue = IIf(oPlanTarifario.IdTipoPlan = String.Empty, ddlTipoPlan.SelectedValue, oPlanTarifario.IdTipoPlan)
            Me.ddlGrupoPlan.SelectedValue = IIf(oPlanTarifario.IdGrupoPlan = String.Empty, ddlGrupoPlan.SelectedValue, oPlanTarifario.IdGrupoPlan)
            Me.ddlTipoProducto.SelectedValue = IIf(oPlanTarifario.IdTipoProducto = String.Empty, ddlTipoProducto.SelectedValue, oPlanTarifario.IdTipoProducto)
            Me.ddlExcCasoEsp.SelectedValue = IIf(oPlanTarifario.IdExclusivoCasoEspecial = String.Empty, ddlExcCasoEsp.SelectedValue, oPlanTarifario.IdExclusivoCasoEspecial)

            Dim strCheck As String = oPlanTarifario.FlagRenovacion
            If strCheck = "1" Then Me.chkFlagRenovacion.Checked = True
            If strCheck = "0" Then Me.chkFlagRenovacion.Checked = False

            ListarGrillaConsumo(String.Empty)
            getConsumoEstado(CodPlan)
            If getRestriccionPdv(CodPlan) = True Then
                'RegisterStartupScript("script1", "<script>refrescarPDV();</script>")
            End If
            If getDetalle(CodPlan) = True Then
                'RegisterStartupScript("script1", "<script>refrescarDetalle()</script>")
            End If
            llenarTipoDocumento(CodPlan)

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(1); </script>")

    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick

        Dim resultado As Boolean
        Try
            Dim item As New Plan
            item.PLANC_CODIGO = CheckStr(hidCodigo.Value)
            item.PLANC_ESTADO = "0"

            If resultado Then
                RegisterStartupScript("script1", "<script>alert('El registro de Inhabilitó correctamente.')</script>")
            End If
            btnBuscar_Click(Nothing, Nothing)

        Finally
            Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_ELIMINAR"), "Deshabilitar Plan Tarifario. Código: " & CheckStr(hidCodigo.Value))
        End Try
    End Sub

    Private Sub btnEliminarPDV_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarPDV.ServerClick

        Dim resultado As Boolean

            Dim ArrayListTemporal As ArrayList = CType(Session("oArrayListSessionPdv"), ArrayList)
            Session("oArrayListSessionPdv") = Nothing

            Dim oArrayList As New ArrayList
            For Each oPuntoVenta As PuntoVenta In ArrayListTemporal
                If oPuntoVenta.OVENC_CODIGO <> hidCodigo.Value.ToString Then
                    oArrayList.Add(oPuntoVenta)
                End If
            Next
            Me.dgPDV.DataSource = oArrayList
            Me.dgPDV.DataBind()
            Session("oArrayListSessionPdv") = oArrayList
            RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(1);</script>")
     
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()
      
        Finally
            Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_CONSULTAR"), "Consultar Plan Tarifario.")
        End Try
    End Sub

    Private Sub Buscar()
      
            Dim lista As DataTable = New PlanTarifarioBusinessLogic().ConsultarPlanTarifario(ddlEstadoListado.SelectedValue.ToString, CheckStr(txtBusDescripcion.Text)) ' (New MaestroNegocio).ConsultarPlanTarifario("", CheckStr(txtBusDescripcion.Text))
            dgrGrillaDetalle.DataSource = lista
            dgrGrillaDetalle.DataBind()

            If dgrGrillaDetalle.Items.Count > 0 Then
                Me.btnEliminarItems.Visible = True
                Me.btnExportar.Visible = True
            Else
                Me.btnEliminarItems.Visible = False
                Me.btnExportar.Visible = False
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
  
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim resultado As Boolean
        Dim strCodigo As String = String.Empty
        Dim strUsuario As String = CurrentUser ' Convert.ToString(Session("codUsuarioSisact"))
        Try
            Dim oPlanTarifario As New PlanTarifario
            With oPlanTarifario
                .CodigoPlan = CheckStr(txtCodPlanSisact.Text).ToUpper()
                .IdOferta = Me.ddlOferta.SelectedValue.ToString
                .DescripcionPlan = Me.txtDesPlanSisact.Text.ToUpper()
                .CodigoPlanSap = Me.txtCodPlanSAP.Text.ToUpper()
                .CodigoPlanBscs = Me.txtCodPlanBSCS.Text
                .DescripcionPlanBase = Me.txtDesPlanBase.Text
                .IdEstado = Me.ddlEstado.SelectedValue.ToString
                .IdTipoDespacho = Me.ddlTipoDespacho.SelectedValue.ToString
                .IdTipoFlujo = Me.ddlTipoFlujo.SelectedValue.ToString
                .IdExclusivoCasoEspecial = Me.ddlExcCasoEsp.SelectedValue.ToString
                .CargoFijo = CDec(IIf(Trim(Me.txtCargoFijo.Text) = String.Empty, 0, Me.txtCargoFijo.Text))
                .LimiteCredito = CDec(IIf(Trim(Me.txtLimiteCredito.Text) = String.Empty, 0, Me.txtLimiteCredito.Text))
                .IdTipoPlan = Me.ddlTipoPlan.SelectedValue.ToString
                .IdGrupoPlan = Me.ddlGrupoPlan.SelectedValue.ToString
                .IdTipoProducto = Me.ddlTipoProducto.SelectedValue.ToString

                Dim strCheck As String = ""
                If Me.chkFlagRenovacion.Checked = True Then strCheck = "1"
                If Me.chkFlagRenovacion.Checked = False Then strCheck = "0"

                .FlagRenovacion = strCheck

            End With

            Dim oListaPdv As ArrayList
            If Session("oArrayListSessionPdv") Is Nothing Then
                oListaPdv = New ArrayList
            Else
                oListaPdv = CType(Session("oArrayListSessionPdv"), ArrayList)
            End If

            Dim oListaDetalle As ArrayList
            If Session("ListaDetalle") Is Nothing Then
                oListaDetalle = New ArrayList
            Else
                oListaDetalle = CType(Session("ListaDetalle"), ArrayList)
            End If

            If hidCodigo.Value.Length = 0 Then
                resultado = New PlanTarifarioBusinessLogic().InsertarPlanTarifario(oPlanTarifario, LlenarDataConsumoEstado(), oListaDetalle, oListaPdv, strUsuario, getTipoDocumentoSeleccionados()) '(New MaestroNegocio).InsertarPlanTarifario(item)
                Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_INSERTAR"), "Registrar Plan Tarifario." & txtCodPlanSisact.Text)
            Else
                resultado = New PlanTarifarioBusinessLogic().ModificarPlanTarifario(oPlanTarifario, LlenarDataConsumoEstado(), oListaDetalle, oListaPdv, strUsuario, getTipoDocumentoSeleccionados())
                Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_ACTUALIZAR"), "Actualizar Plan Tarifario." & txtCodPlanSisact.Text)
            End If

            btnBuscar_Click(Nothing, Nothing)
            If resultado Then
                RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El código de plan ingresado ya existe.');f_mostrarPestaña(1);</script>")
                Me.txtCodPlanSisact.Text = String.Empty
                Exit Sub

            End If
            Limpiar()
            txtCodPlanSisact.Enabled = True
            txtCodPlanSisact.CssClass = "clsInputEnable"
        Catch ex As Exception
            Session("oArrayListSessionPdv") = Nothing
            Session("oArrayListSessionCanal") = Nothing
            Session("ListaDetalle") = Nothing
            Limpiar()
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El registro ya existe.');f_mostrarPestaña(2);</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Function LlenarDataConsumoEstado() As DataTable
        Dim dt As New DataTable
        Dim ddl As DropDownList
        Dim dr As DataRow
  
            dt = New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("valor")

            For Each dgi As DataGridItem In dgrTopeConsumoDetalle.Items
                dr = dt.NewRow()
                ddl = DirectCast(dgi.Cells(3).Controls(1), DropDownList)
                dr(0) = dgi.Cells(4).Text
                dr(1) = ddl.SelectedValue
                dt.Rows.Add(dr)
            Next
            dt.AcceptChanges()
            Return dt
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
     
    End Function

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        txtCodPlanSisact.Enabled = True
        txtCodPlanSisact.CssClass = "clsInputEnable"
        Session("oArrayListSessionPdv") = Nothing
        Session("oArrayListPdv") = Nothing
        Session("oArrayListSessionCanal") = Nothing
        Session("ListaDetalle") = Nothing
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgPDV_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPDV.PageIndexChanged
        dgPDV.CurrentPageIndex = e.NewPageIndex
        ListarPDV()
    End Sub

    Sub getConsumoEstado(ByVal cod As String) 'al momento de editar me carga los datos
        Dim dt As DataTable = New PlanTarifarioBusinessLogic().getConsumoEstado(cod)
        Dim ddl As DropDownList
      
            For Each dr As DataRow In dt.Rows
                For Each dgi As DataGridItem In dgrTopeConsumoDetalle.Items
                    ddl = DirectCast(dgi.Cells(3).Controls(1), DropDownList)
                    If dr(1) = dgi.Cells(2).Text Then
                        ddl.SelectedValue = dr(2)
                    End If

                Next
            Next
     
    End Sub

    Function getRestriccionPdv(ByVal cod As String) As Boolean
        Dim result As Boolean = False
        Dim oArrayList As ArrayList = New PlanTarifarioBusinessLogic().ListarPdvRestriccion(cod) '("'2','25'")
        dgPDV.DataSource = oArrayList
        dgPDV.DataBind()
        Session("oArrayListSessionPdv") = oArrayList
        If oArrayList.Count > 0 Then result = True
        Return result
    End Function

    Function getDetalle(ByVal cod As String) As Boolean
        Dim result As Boolean = False
        Dim oArrayList As ArrayList = New PlanTarifarioBusinessLogic().ListarDetalle(cod) '("'2','25'")

        dgDetallePlan.DataSource = oArrayList
        dgDetallePlan.DataBind()
        Session("ListaDetalle") = oArrayList
        If oArrayList.Count > 0 Then result = True
        Return result
    End Function

    Private Sub btnEliminarDetallePlan_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDetallePlan.ServerClick
        Dim resultado As Boolean
 
            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Dim sTipoDoc As String = Coleccion(0)
            Dim sPlazo As String = Coleccion(1)
            Dim sCuota As String = Coleccion(2)

            Dim ArrayListTemporal As ArrayList = CType(Session("ListaDetalle"), ArrayList)
            Session("ListaDetalle") = Nothing

            Dim oArrayList As New ArrayList
            For Each oDetallePlanTarifario As DetallePlanTarifario In ArrayListTemporal
                If oDetallePlanTarifario.IdDocumento = sTipoDoc And _
                oDetallePlanTarifario.IdPlazo = sPlazo And _
                oDetallePlanTarifario.IdCuota = sCuota Then
                Else
                    oArrayList.Add(oDetallePlanTarifario)
                End If
            Next
            Me.dgDetallePlan.DataSource = oArrayList
            Me.dgDetallePlan.DataBind()
            Session("ListaDetalle") = oArrayList
            RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(2);</script>")
    
    End Sub

    Private Function getItemsForDelete() As DataTable
        'sRiesgo, sTipoDoc, sCuota
        Dim dt As New DataTable
        Dim ddl As DropDownList
        Dim chk As CheckBox
        Dim dr As DataRow
   
            dt = New DataTable
            dt.Columns.Add("sPlanCod")

            For Each dgi As DataGridItem In dgrGrillaDetalle.Items
                chk = DirectCast(dgi.Cells(20).Controls(1), CheckBox)
                If chk.Checked Then
                    dr = dt.NewRow()
                    dr(0) = CheckStr(dgi.Cells(1).Text)
                    dt.Rows.Add(dr)
                End If
            Next
            dt.AcceptChanges()
            Return dt
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
 
    End Function

    Private Sub btnEliminarItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarItems.Click
        Try
            Dim result As Boolean = New PlanTarifarioBusinessLogic().EliminarPlanTarifario(getItemsForDelete())
            If result = True Then
                dgrGrillaDetalle.CurrentPageIndex = 0
                Buscar()
                If dgrGrillaDetalle.Items.Count > 0 Then
                    Me.btnEliminarItems.Visible = True
                    Me.btnExportar.Visible = True
                Else
                    Me.btnEliminarItems.Visible = False
                    Me.btnExportar.Visible = False
                End If
                RegisterStartupScript("script1", "<script>alert('Se eliminó el(los) registro(s) satisfactoriamente.');f_MostrarTab('BUSQUEDA');</script>")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")

        Finally
            Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_ELIMINAR"), "Deshabilitar Plan Tarifario.")
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            If Me.dgrGrillaDetalle.Items.Count = 0 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
                Exit Sub
            End If
            Dim applicationPath As String = System.Web.HttpContext.Current.Request.ApplicationPath
            applicationPath = System.Web.HttpContext.Current.Server.MapPath(applicationPath & "\PlanTarifario.csv")
            exportarCsv(applicationPath)
            Response.Redirect("DownloadFiles.aspx?FileName=PlanTarifario.csv")
     
        Finally
            Auditoria(ConfigurationSettings.AppSettings("PT_CODAUDT_EXPORTAR"), "Exportar Archivo Plan Tarifario.")
        End Try
    End Sub

    Sub exportarCsv(ByVal ruta As String)
        'Dim lista As ArrayList = New PlanTarifarioBusinessLogic().ConsultarPlanTarifario("", CheckStr(txtBusDescripcion.Text)) ' (New MaestroNegocio).ConsultarPlanTarifario("", CheckStr(txtBusDescripcion.Text))
        Dim myTable As DataTable = New PlanTarifarioBusinessLogic().ConsultarPlanTarifarioExportar(Me.ddlEstadoListado.SelectedValue.ToString, CheckStr(txtBusDescripcion.Text))
        Dim dr As DataRow = myTable.NewRow
        dr(0) = "CODIGO"
        dr(1) = "PLAN"
        dr(2) = "TIPO_DOCUMENTO"
        dr(3) = "OFERTA"
        dr(4) = "TIPO_PRODUCTO"
        dr(5) = "CODIGO_SAP"
        dr(6) = "CODIGO_BSCS"
        dr(7) = "TIPO_DESPACHO"
        dr(8) = "TIPO_FLUJO"
        dr(9) = "EXCLUSIVO_CE"
        dr(10) = "TIPO_PLAN"
        dr(11) = "GRUPO_PLAN"
        dr(12) = "CARGO_FIJO"
        dr(13) = "LIMITE_CREDITO"
        dr(14) = "TOPE_CONSUMO_SIN_CF"
        dr(15) = "TOPE_CONSUMO_CON_CF"
        dr(16) = "TOPE_CONSUMO_AUTOM"
        dr(17) = "ESTADO"
        myTable.Rows.InsertAt(dr, 0)
        Dim myRow As DataRow
        Dim numCols As Integer = 0
        Dim myString As String
        Dim myWriter As New System.IO.StreamWriter(ruta)

        For Each myRow In myTable.Rows 'recorre las filas
            myString = String.Empty
            For numCols = 0 To myTable.Columns.Count - 2 'recorre las columnas
                If Object.ReferenceEquals(myRow.Item(numCols).GetType(), myString.GetType()) Then
                    myString = myString & """" & myRow.Item(numCols).ToString() & ""","
                ElseIf Object.ReferenceEquals(myRow.Item(numCols).GetType(), numCols.GetType()) Then
                    myString = myString & myRow.Item(numCols).ToString() & ","
                End If
            Next

            If Object.ReferenceEquals(myRow.Item(numCols).GetType(), myString.GetType()) Then
                myString = myString & """" & myRow.Item(numCols).ToString() & """"
            ElseIf Object.ReferenceEquals(myRow.Item(numCols).GetType(), numCols.GetType()) Then
                myString = myString & myRow.Item(numCols).ToString()
            End If
            myWriter.WriteLine(myString)
        Next

        myWriter.Close()
    End Sub

    Private Sub btnEliminarItemsDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarItemsDetalle.Click
        Session("ListaDetalle") = Nothing
        ListarDetallePlan()
        hidCondicion.Value = String.Empty
        RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(2);</script>")
    End Sub

    Private Sub btnEliminarItemsPdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarItemsPdv.Click
        Session("oArrayListSessionPdv") = Nothing
        ListarPDV()
        hidCondicion.Value = String.Empty
        RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');f_mostrarPestaña(1);</script>")
    End Sub

    Private Sub btnModificarDetallePlan_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarDetallePlan.ServerClick
        Dim resultado As Boolean
        
            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Session("Coleccion") = Coleccion
            RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');cargarPopUpDetalle();f_mostrarPestaña(2);</script>")
  
    End Sub

    Sub llenarTipoDocumento(ByVal cod As String)
        Dim dtTipDoc As DataTable = New PlanTarifarioBusinessLogic().getPlanDocumento(cod)
        For Each odr As DataRow In dtTipDoc.Rows
            For Each lit As ListItem In Me.ctlTipoDocumento.Items
                If lit.Value = odr(1) Then
                    lit.Selected = True
                End If
            Next
        Next
    End Sub

    Private Function getTipoDocumentoSeleccionados() As DataTable
        Dim dt As DataTable
        Dim dr As DataRow

        dt = New DataTable
        dt.Columns.Add("valor")
        For Each lit As ListItem In ctlTipoDocumento.Items
            If lit.Selected Then
                dr = dt.NewRow()
                dr(0) = lit.Value
                dt.Rows.Add(dr)
            End If
        Next
        dt.AcceptChanges()
        Return dt
    End Function

    Private Sub dgDetallePlan_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDetallePlan.PageIndexChanged
        dgDetallePlan.CurrentPageIndex = e.NewPageIndex
        ListarDetallePlan()
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
