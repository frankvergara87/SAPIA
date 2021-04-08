Option Strict Off
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO
Imports System.Drawing.Printing
Imports System

Public Class sisact_mant_restriccion_riesgo
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodPlanSisact As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminarPDV As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminarCanal As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ctlPlazo As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ctlPlazoAcuerdo As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRiesgo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlazoAcuerdo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidPV_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlan_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnSeleccionarCampana As System.Web.UI.WebControls.Button
    Protected WithEvents dgrPDCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrPDDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hid_Validacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoDocumentoMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRiesgoMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrODCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgCampana As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgPlanes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEliminarItems As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button

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

        If Not Page.IsPostBack Then
                llenarCombosConsulta()
                llenarDataListas()

                dgrODCabecera.DataSource = String.Empty
                dgrODCabecera.DataBind()

                dgrPDCabecera.DataSource = String.Empty
                dgrPDCabecera.DataBind()

                RegisterStartupScript("script", "<script>f_Inicio()</script>")
 
        End If

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnEliminarItems.Attributes.Add("onclick", "return f_EliminarItems();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")

    End Sub

    Sub llenarDataListas()
        ctlPlazoAcuerdo.DataValueField = "PLZAC_CODIGO"
        ctlPlazoAcuerdo.DataTextField = "PLZAV_DESCRIPCION"
        ctlPlazoAcuerdo.DataSource = New PlanTarifarioBusinessLogic().ListarPlazoAcuerdo(ConfigurationSettings.AppSettings("ConstP_Oferta").ToString(), String.Empty)
        ctlPlazoAcuerdo.DataBind()

        ddlTipoDocumentoMant.DataValueField = "DOCC_CODIGO"
        ddlTipoDocumentoMant.DataTextField = "DOCV_DESCRIPCION"
        ddlTipoDocumentoMant.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento()
        ddlTipoDocumentoMant.DataBind()
        ddlTipoDocumentoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        Dim fecha As String = String.Format("{0:yyyy/MM/dd}", Now)
        Dim oListaCamapana As ArrayList = New SapGeneralNegocios().Get_ConsultaCampana(fecha, ConfigurationSettings.AppSettings("ConstTipoVentaCampana").ToString())
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("DESCRIPCION")
        For Each item As ItemGenerico In oListaCamapana
            Dim dr As DataRow = dt.NewRow
            dr(0) = item.Codigo
            dr(1) = item.Descripcion
            dt.Rows.Add(dr)
        Next

        Dim view As New DataView(dt)
        'view.Table = dt
        view.Sort = "DESCRIPCION"

        'oListaCamapana.Sort()
        dgCampana.DataSource = view 'oListaCamapana ' New SapGeneralNegocios().Get_ConsultaCampana(fecha, "01")        
        dgCampana.DataBind()

        dgPlanes.DataSource = New PlanTarifarioBusinessLogic().ListarPLan()
        dgPlanes.DataBind()
    End Sub

    Sub llenarCombosConsulta()

        ddlPlazoAcuerdo.DataValueField = "PLZAC_CODIGO"
        ddlPlazoAcuerdo.DataTextField = "PLZAV_DESCRIPCION"
        ddlPlazoAcuerdo.DataSource = New PlanTarifarioBusinessLogic().ListarPlazoAcuerdo(ConfigurationSettings.AppSettings("ConstP_Oferta").ToString(), String.Empty) '
        ddlPlazoAcuerdo.DataBind()
        ddlPlazoAcuerdo.Items.Insert(0, New ListItem("TODOS", String.Empty))

        ddlTipoDocumento.DataValueField = "DOCC_CODIGO"
        ddlTipoDocumento.DataTextField = "DOCV_DESCRIPCION"
        ddlTipoDocumento.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento()
        ddlTipoDocumento.DataBind()
        ddlTipoDocumento.Items.Insert(0, New ListItem("TODOS", String.Empty))

        ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))

        ddlPlan.DataValueField = "planc_codigo"
        ddlPlan.DataTextField = "planv_descripcion"
        ddlPlan.DataSource = New PlanTarifarioBusinessLogic().ListarPLan()
        ddlPlan.DataBind()
        ddlPlan.Items.Insert(0, New ListItem("TODOS", String.Empty))

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
 
            dgrGrillaCabecera.DataSource = String.Empty
            dgrGrillaCabecera.DataBind()

            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

    End Sub

    Private Sub Limpiar()

            hidCodigo.Value = String.Empty

            Me.ddlTipoDocumentoMant.SelectedIndex = -1
            ddlRiesgoMant.Items.Clear()
            ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

            ddlRiesgo.Items.Clear()
            ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))

            For Each lit As ListItem In ctlPlazoAcuerdo.Items
                lit.Selected = False
            Next

            ddlTipoDocumentoMant.Enabled = True
            ddlRiesgoMant.Enabled = True

            LimpiarPlanes()
            LimpiarCampanas()

    End Sub

    Sub LimpiarCampanas()

        Dim oItem As DataGridItem
        Dim oCheckBox As CheckBox
        For Each oItem In dgCampana.Items
            oCheckBox = CType(oItem.FindControl("FilaCampana"), CheckBox)
            oCheckBox.Checked = False
        Next
    End Sub

    Sub LimpiarPlanes()

        Dim oItem As DataGridItem
        Dim oCheckBox As CheckBox
        For Each oItem In dgPlanes.Items
            oCheckBox = CType(oItem.FindControl("FilaPlan"), CheckBox)
            oCheckBox.Checked = False
        Next
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick

        Dim dtTemp As DataTable
  

            limpiarCtl(Me.ctlPlazoAcuerdo)

            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")

            Dim sRiesgo As String = Coleccion(0)
            Dim sTipoDoc As String = Coleccion(1)

            Me.ddlTipoDocumentoMant.SelectedValue = sTipoDoc
            Me.ddlTipoDocumentoMant.Enabled = False

            If ddlTipoDocumentoMant.SelectedValue.ToString <> String.Empty Then
                Select Case ddlTipoDocumentoMant.SelectedValue.ToString
                    Case ConfigurationSettings.AppSettings("ConstTipoDocMM").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocCE").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocDNI").ToString()
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocM").ToString())
                    Case Else
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocC").ToString())
                End Select
                ddlRiesgoMant.DataValueField = "RIEN_CODIGO"
                ddlRiesgoMant.DataTextField = "RIEV_DESCRIPCION"
                ddlRiesgoMant.DataSource = dtTemp
                ddlRiesgoMant.DataBind()
                ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            End If

            Me.ddlRiesgoMant.SelectedValue = sRiesgo
            Me.ddlRiesgoMant.Enabled = False

            Dim dtPlazo As DataTable = New PlanTarifarioBusinessLogic().getDetallesRestriccionRiesgo(sTipoDoc, sRiesgo, 1)
            For Each odr As DataRow In dtPlazo.Rows
                For Each lit As ListItem In Me.ctlPlazoAcuerdo.Items
                    If lit.Value = odr(0) Then
                        lit.Selected = True
                    End If
                Next
            Next
            llenarCampanas(sTipoDoc, sRiesgo)
            llenarPlanes(sTipoDoc, sRiesgo)

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');</script>")

    End Sub

    Sub llenarCampanas(ByVal stipoDoc As String, ByVal sRiesgo As String)

        Dim dtCampana As DataTable = New PlanTarifarioBusinessLogic().getDetallesRestriccionRiesgo(stipoDoc, sRiesgo, 2)
        Dim oItem As DataGridItem
        Dim oCheckBox As CheckBox
        Dim Id As String
        For Each oItem In dgCampana.Items
            For Each oDataRow As DataRow In dtCampana.Rows
                Id = oItem.Cells(1).Text
                If oDataRow(0) = Id Then
                    oCheckBox = CType(oItem.FindControl("FilaCampana"), CheckBox)
                    oCheckBox.Checked = True
                End If
            Next
        Next
    End Sub

    Sub llenarPlanes(ByVal stipoDoc As String, ByVal sRiesgo As String)
        Dim dtCampana As DataTable = New PlanTarifarioBusinessLogic().getDetallesRestriccionRiesgo(stipoDoc, sRiesgo, 3)
        Dim oItem As DataGridItem
        Dim oCheckBox As CheckBox
        Dim Id As String
        For Each oItem In dgPlanes.Items

            For Each oDataRow As DataRow In dtCampana.Rows
                Id = oItem.Cells(1).Text
                If oDataRow(0) = Id Then
                    oCheckBox = CType(oItem.FindControl("FilaPlan"), CheckBox)
                    oCheckBox.Checked = True
                End If
            Next
        Next
    End Sub

    Sub MarcarDocumento(ByVal cod As String, ByVal oCheckBoxList As CheckBoxList)

        For Each lit As ListItem In oCheckBoxList.Items
            If lit.Value = cod Then
                lit.Selected = True
            End If
        Next
    End Sub

    Sub limpiarCtl(ByVal oCheckBoxList As CheckBoxList)
        For Each lit As ListItem In oCheckBoxList.Items
            lit.Selected = False
        Next
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick

            RegisterStartupScript("script", "<script>;f_MostrarTab('NUEVO');alert('nuevo');</script>")

 
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Try
            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Dim sTipoDoc As String = Coleccion(0)
            Dim sRiesgo As String = Coleccion(1)
            Dim sPlan As String = Coleccion(2)
            Dim sPlazo As String = Coleccion(3)
            Dim sCamapana As String = Coleccion(4)

            Dim result As Boolean = True ' New PlanTarifarioBusinessLogic().EliminarRestriccionRiesgo(sTipoDoc, sRiesgo, sPlan, sPlazo, sCamapana)

            If result = True Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('El Registro se Deshabilitó satisfactoriamente.')</script>")
            End If

            Me.hidCodigo.Value = String.Empty
            btnBuscar_Click(Nothing, Nothing)

        Finally
            Auditoria(ConfigurationSettings.AppSettings("RES_R_CODAUDT_ELIMINAR"), "Eliminar Restricción por Riesgo")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLCampana As LCampana
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean = False
        Dim strCodigo As String = String.Empty
        Dim strDescripcion As String = String.Empty
        Dim dtmFechaInicio As DateTime
        Dim dtmFechaFin As DateTime
        Dim dtbCampanaPV As DataTable
        Dim dtbCampanaPlan As DataTable
        Dim dtbCampanaKit As DataTable
        'Dim Resultado As Boolean
        Try

            If getPlazosSeleccionados.Rows.Count = 0 Then
                'RegisterStartupScript("script", "<script>alert('verificar');</script>")
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');alert('Debe seleccionar al menos 1 plazo')</script>")
            ElseIf getPlanesSeleccionados.Rows.Count = 0 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');alert('Debe seleccionar al menos 1 plan')</script>")
            ElseIf getCampanasSeleccionadas.Rows.Count = 0 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');alert('Debe seleccionar al menos 1 campaña')</script>")
            Else
                Dim validacion As Boolean = True
                Dim mensaje As String = String.Empty

                Dim strUsuario As String = CurrentUser 'Convert.ToString(Session("codUsuarioSisact"))

                dtbCampanaPV = DirectCast(ViewState("dtbCampanaPV"), DataTable)
                dtbCampanaPlan = DirectCast(ViewState("dtbCampanaPlan"), DataTable)

                If validacion Then
                    If hidCodigo.Value.Length = 0 Then
                        Dim resG As Boolean = New PlanTarifarioBusinessLogic().validarDetallesRestriccionRiesgo(Me.ddlTipoDocumentoMant.SelectedValue.ToString, Me.ddlRiesgoMant.SelectedValue.ToString)
                        If resG Then
                            resultado = New PlanTarifarioBusinessLogic().InsertarRestriccionRiesgo(Me.ddlTipoDocumentoMant.SelectedValue.ToString, _
                                                                                                                                        Me.ddlRiesgoMant.SelectedValue.ToString, _
                                                                                                                                        getPlazosSeleccionados, _
                                                                                                                                        getPlanesSeleccionados, _
                                                                                                                                        getCampanasSeleccionadas, _
                                                                                                                                        strUsuario)
                            Auditoria(ConfigurationSettings.AppSettings("FAC_R_CODAUDT_INSERTAR"), "Registrar Restricción Riesgo.")
                        Else
                            resultado = False
                        End If

                    Else
                        Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")

                        Dim resG As Boolean = New PlanTarifarioBusinessLogic().DelDetallesRestriccionRiesgo(Me.ddlTipoDocumentoMant.SelectedValue.ToString, Me.ddlRiesgoMant.SelectedValue.ToString)
                        If resG Then
                            resultado = New PlanTarifarioBusinessLogic().InsertarRestriccionRiesgo(Me.ddlTipoDocumentoMant.SelectedValue.ToString, _
                                                                                                                                        Me.ddlRiesgoMant.SelectedValue.ToString, _
                                                                                                                                        getPlazosSeleccionados, _
                                                                                                                                        getPlanesSeleccionados, _
                                                                                                                                        getCampanasSeleccionadas, _
                                                                                                                                        strUsuario)
                            Auditoria(ConfigurationSettings.AppSettings("FAC_R_CODAUDT_ACTUALIZAR"), "Actualizar Restricción Riesgo.")
                        Else
                            resultado = False
                        End If

                    End If



                    LimpiarViewState()
                    btnBuscar_Click(Nothing, Nothing)
                    If resultado = False Then
                        RegisterStartupScript("script1", "<script>alert('Error. Verificar los datos seleccionados, ya se registraron.')</script>")
                    Else
                        Me.ddlRiesgo.SelectedIndex = -1
                        Me.ddlTipoDocumento.SelectedIndex = -1
                        Me.ddlPlazoAcuerdo.SelectedIndex = -1
                        Me.ddlPlan.SelectedIndex = -1
                        Buscar()
                        RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
                    End If

                Else
                    RegisterStartupScript("script1", "<script>pt>f_MostrarTab('NUEVO');alert('" & mensaje & "')</script>")
                    'Exit Sub
                End If
            End If

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripción ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20660") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El código de la campaña ya existe.')</script>")
            Else
                Throw ex
            End If

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarViewState()
        Me.ddlRiesgo.SelectedIndex = -1
        Me.ddlTipoDocumento.SelectedIndex = -1
        Me.ddlPlazoAcuerdo.SelectedIndex = -1
        Me.ddlPlan.SelectedIndex = -1
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_LimpiarCheck();</script>")
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()

        Try
            Dim oListaRestriccion As DataTable = New PlanTarifarioBusinessLogic().ListarRestriccionRiesgo(Me.ddlTipoDocumento.SelectedValue().ToString, Me.ddlRiesgo.SelectedValue().ToString, Me.ddlPlazoAcuerdo.SelectedValue().ToString, Me.ddlPlan.SelectedValue().ToString)

            dgrGrillaDetalle.DataSource = oListaRestriccion
            dgrGrillaDetalle.DataBind()

            If dgrGrillaDetalle.Items.Count > 0 Then
                Me.btnEliminarItems.Visible = True
                Me.btnExportar.Visible = True
            Else
                Me.btnEliminarItems.Visible = False
                Me.btnExportar.Visible = False
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")

        Finally
            Auditoria(ConfigurationSettings.AppSettings("FAC_R_CODAUDT_CONSULTAR"), "Consultar Restricción por Riesgo.")
        End Try
    End Sub

    Private Sub LimpiarViewState()
        ViewState("dtbCampanaPV") = Nothing
        ViewState("dtbPV") = Nothing
        ViewState("dtbCampanaPlan") = Nothing
        ViewState("dtbPlan") = Nothing
        ViewState("dtbCampanaKit") = Nothing
        ViewState("dtbKit") = Nothing
    End Sub

    Private Function getPlazosSeleccionados() As DataTable
        Dim dt As DataTable
        Dim dr As DataRow

        dt = New DataTable
        dt.Columns.Add("valor")
        For Each lit As ListItem In ctlPlazoAcuerdo.Items
            If lit.Selected Then
                dr = dt.NewRow()
                dr(0) = lit.Value
                dt.Rows.Add(dr)
            End If
        Next
        Return dt
    End Function

    Private Function getCampanasSeleccionadas() As DataTable
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oString As String = String.Empty
        Dim oItem As DataGridItem

        dt = New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("valor")

        For Each oItem In dgCampana.Items
            Dim result As Boolean = (CType(oItem.FindControl("FilaCampana"), CheckBox)).Checked

            If result Then
                dr = dt.NewRow()
                dr(0) = oItem.Cells(1).Text
                dr(1) = oItem.Cells(2).Text
                dt.Rows.Add(dr)
            End If
        Next
        dt.AcceptChanges()
        Return dt

    End Function

    Private Sub ddlTipoDocumentoMant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumentoMant.SelectedIndexChanged
        Try
            Dim dtTemp As DataTable

            If ddlTipoDocumentoMant.SelectedValue.ToString <> String.Empty Then
                Select Case ddlTipoDocumentoMant.SelectedValue.ToString
                    Case ConfigurationSettings.AppSettings("ConstTipoDocMM").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocCE").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocDNI").ToString()
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocM").ToString())
                    Case Else
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocC").ToString())
                End Select
                ddlRiesgoMant.DataValueField = "RIEN_CODIGO"
                ddlRiesgoMant.DataTextField = "RIEV_DESCRIPCION"
                ddlRiesgoMant.DataSource = dtTemp 'New PlanTarifarioBusinessLogic().ListarRiesgo("M")
                ddlRiesgoMant.DataBind()
                ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            Else
                ddlRiesgoMant.Items.Clear()
                ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            End If
            LimpiarCampanas()
            LimpiarPlanes()
            Me.ddlTipoDocumentoMant.Enabled = True
            Me.ddlRiesgoMant.Enabled = True
            For Each lit As ListItem In ctlPlazoAcuerdo.Items
                lit.Selected = False
            Next
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Catch ex As Exception

        End Try
    End Sub

    Function getPlanesSeleccionados() As DataTable

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oString As String = String.Empty
        Dim oItem As DataGridItem

        dt = New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("valor")

        For Each oItem In dgPlanes.Items
            Dim result As Boolean = (CType(oItem.FindControl("FilaPlan"), CheckBox)).Checked

            If result Then
                dr = dt.NewRow()
                dr(0) = oItem.Cells(1).Text
                dr(1) = oItem.Cells(2).Text
                dt.Rows.Add(dr)
            End If
        Next
        dt.AcceptChanges()
        Return dt

    End Function

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        Try
            Dim dtTemp As DataTable

            If ddlTipoDocumento.SelectedValue.ToString <> String.Empty Then
                Select Case ddlTipoDocumento.SelectedValue.ToString
                    Case ConfigurationSettings.AppSettings("ConstTipoDocMM").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocCE").ToString(), ConfigurationSettings.AppSettings("ConstTipoDocDNI").ToString()
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocM").ToString())
                    Case Else
                        dtTemp = New PlanTarifarioBusinessLogic().ListarRiesgo(ConfigurationSettings.AppSettings("ConstRiesgoTipoDocC").ToString())
                End Select
                ddlRiesgo.DataValueField = "RIEN_CODIGO"
                ddlRiesgo.DataTextField = "RIEV_DESCRIPCION"
                ddlRiesgo.DataSource = dtTemp
                ddlRiesgo.DataBind()
                ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');</script>")
            Else
                ddlRiesgo.Items.Clear()
                ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');</script>")
            End If
            RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');</script>")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlRiesgoMant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRiesgoMant.SelectedIndexChanged

        Dim dtPlazo As DataTable = New PlanTarifarioBusinessLogic().getDetallesRestriccionRiesgo(Me.ddlTipoDocumentoMant.SelectedValue.ToString, Me.ddlRiesgoMant.SelectedValue.ToString, 1)
        For Each odr As DataRow In dtPlazo.Rows
            For Each lit As ListItem In Me.ctlPlazoAcuerdo.Items
                If lit.Value = odr(0) Then
                    lit.Selected = True
                End If
            Next
        Next

        If dtPlazo.Rows.Count > 0 Then
            llenarCampanas(Me.ddlTipoDocumentoMant.SelectedValue.ToString, Me.ddlRiesgoMant.SelectedValue.ToString)
            llenarPlanes(Me.ddlTipoDocumentoMant.SelectedValue.ToString, Me.ddlRiesgoMant.SelectedValue.ToString)
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');</script>")
            Me.hidCodigo.Value = Me.ddlRiesgoMant.SelectedValue.ToString & "," & Me.ddlTipoDocumentoMant.SelectedValue.ToString
        Else
            LimpiarCampanas()
            LimpiarPlanes()
            For Each lit As ListItem In ctlPlazoAcuerdo.Items
                lit.Selected = False
            Next
            Me.hidCodigo.Value = String.Empty
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');</script>")
        End If

    End Sub

    Private Sub btnEliminarItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarItems.Click
        'Dim result As Boolean = New PlanTarifarioBusinessLogic().EliminarRestriccionCuota(getItemsForDelete())
        Dim result As Boolean = New PlanTarifarioBusinessLogic().EliminarRestriccionRiesgo(getItemsForDelete())
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

        Auditoria(ConfigurationSettings.AppSettings("FAC_R_CODAUDT_ELIMINAR"), "Eliminar Restricción por Riesgo")
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Function getItemsForDelete() As DataTable
        'sRiesgo, sTipoDoc, sCuota
        Dim dt As New DataTable
        Dim ddl As DropDownList
        Dim chk As CheckBox
        Dim dr As DataRow

            dt = New DataTable
            dt.Columns.Add("sTipoDoc")
            dt.Columns.Add("sRiesgo")
            dt.Columns.Add("sPlazo") 'sPlan
            dt.Columns.Add("sPlan")
            dt.Columns.Add("sCamapana")

            For Each dgi As DataGridItem In dgrGrillaDetalle.Items
                chk = DirectCast(dgi.Cells(12).Controls(1), CheckBox)
                If chk.Checked Then
                    dr = dt.NewRow()
                    dr(0) = dgi.Cells(1).Text
                    dr(1) = dgi.Cells(3).Text
                    dr(2) = dgi.Cells(5).Text
                    dr(3) = dgi.Cells(8).Text
                    dr(4) = dgi.Cells(10).Text
                    dt.Rows.Add(dr)
                End If
            Next
            dt.AcceptChanges()
            Return dt
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")

    End Function

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Try
            If Me.dgrGrillaDetalle.Items.Count = 0 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
                Exit Sub
            End If
            Dim applicationPath As String = System.Web.HttpContext.Current.Request.ApplicationPath
            applicationPath = System.Web.HttpContext.Current.Server.MapPath(applicationPath & "\RestriccionRiesgo.csv")
            exportarCsv(applicationPath)
            Response.Redirect("DownloadFiles.aspx?FileName=RestriccionRiesgo.csv")

        Finally
            Auditoria(ConfigurationSettings.AppSettings("RES_R_CODAUDT_EXPORTAR"), "Exportar Archivo Restricción por Riesgo.")
        End Try
    End Sub

    Sub exportarCsv(ByVal ruta As String)
        Dim myTable As DataTable = New PlanTarifarioBusinessLogic().ListarRestriccionRiesgoExportar(Me.ddlTipoDocumento.SelectedValue().ToString, Me.ddlRiesgo.SelectedValue().ToString, Me.ddlPlazoAcuerdo.SelectedValue().ToString, Me.ddlPlan.SelectedValue().ToString)
        Dim dr As DataRow = myTable.NewRow
        dr(0) = "TIPO_DOCUMENTO"
        dr(1) = "RIESGO"
        dr(2) = "PLAN"
        dr(3) = "OFERTA"
        dr(4) = "PLAZO_ACUERDO"
        dr(5) = "CAMPANA"
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

