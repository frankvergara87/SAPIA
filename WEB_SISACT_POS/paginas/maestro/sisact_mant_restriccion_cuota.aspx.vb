Option Strict Off
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_restriccion_cuota
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlRiesgo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPV_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlan_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hid_Validacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlPlazoAcuerdo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCuotas As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoDocumentoMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRiesgoMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCuotaMant As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAgregarGrilla As System.Web.UI.WebControls.Button
    Protected WithEvents trBusquedaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trGrillaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgDetallePlan As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtValorCuota As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEliminarDetalle As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminarItems As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents hidCuota As System.Web.UI.HtmlControls.HtmlInputHidden

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
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
        
        End If

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnEliminarItems.Attributes.Add("onclick", "return f_EliminarItems();")
        btnAgregarGrilla.Attributes.Add("onclick", "return f_ValidarGrabar();")
    End Sub

    Sub llenarDataListas()

        ddlCuotaMant.DataValueField = "CUOC_CODIGO"
        ddlCuotaMant.DataTextField = "CUOV_DESCRIPCION"
        Me.ddlCuotaMant.DataSource = New PlanTarifarioBusinessLogic().ListarCuotas() 'dtPlazoAcuerdo
        Me.ddlCuotaMant.DataBind()
        ddlCuotaMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        ddlTipoDocumentoMant.DataValueField = "DOCC_CODIGO"
        ddlTipoDocumentoMant.DataTextField = "DOCV_DESCRIPCION"
        ddlTipoDocumentoMant.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento() 'dtTipoDocumento 
        ddlTipoDocumentoMant.DataBind()
        ddlTipoDocumentoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

        ddlEstado.DataValueField = "ITEMN_CODIGO"
        ddlEstado.DataTextField = "ITEMN_DESCRIPCION"
        ddlEstado.DataSource = New PlanTarifarioBusinessLogic().ListarEstado()
        ddlEstado.DataBind()
        ddlEstado.SelectedIndex = 1
    End Sub


    Private Sub ListarGrillaCuotas(ByVal pstrPlanCodigo As String)
        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub llenarCombosConsulta() 'armar la cascada tambien aqui


        ddlCuotas.DataValueField = "CUOC_CODIGO"
        ddlCuotas.DataTextField = "CUOV_DESCRIPCION"
        Me.ddlCuotas.DataSource = New PlanTarifarioBusinessLogic().ListarCuotas() 'dtPlazoAcuerdo
        Me.ddlCuotas.DataBind()
        ddlCuotas.Items.Insert(0, New ListItem("TODOS", String.Empty))

        ddlTipoDocumento.DataValueField = "DOCC_CODIGO"
        ddlTipoDocumento.DataTextField = "DOCV_DESCRIPCION"
        ddlTipoDocumento.DataSource = New PlanTarifarioBusinessLogic().ListarTipoDocumento() 'dtTipoDocumento 
        ddlTipoDocumento.DataBind()
        ddlTipoDocumento.Items.Insert(0, New ListItem("TODOS", String.Empty))

        ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
    
            dgrGrillaCabecera.DataSource = String.Empty
            dgrGrillaCabecera.DataBind()

            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

    End Sub

    Private Sub Limpiar()
     
            hidCodigo.Value = String.Empty
            Session("ListaResCuota") = Nothing
            Me.dgDetallePlan.DataSource = Nothing
            Me.dgDetallePlan.DataBind()

            Me.ddlCuotaMant.SelectedIndex = -1

            Me.ddlTipoDocumentoMant.SelectedIndex = -1
            Me.ddlCuotaMant.SelectedIndex = -1
            Me.ddlEstado.SelectedIndex = 1
            Me.txtValorCuota.Text = "0"
            ddlRiesgoMant.Items.Clear()
            ddlRiesgo.Items.Clear()
            ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))

            Session("ListaResCuota") = Nothing

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick

            Dim dtTemp As DataTable

            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Dim sRiesgo As String = Coleccion(0)
            Dim sTipoDoc As String = Coleccion(1)
            Dim sCuota As String = Coleccion(2)
            Dim oDetallePlanTarifario As DetallePlanTarifario = New PlanTarifarioBusinessLogic().getRestriccionCuota(sRiesgo, sTipoDoc, sCuota)
            Me.ddlTipoDocumentoMant.SelectedValue = IIf(oDetallePlanTarifario.IdDocumento = String.Empty, ddlTipoDocumentoMant.SelectedValue, oDetallePlanTarifario.IdDocumento)
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
            End If
            Session("ListaResCuota") = Nothing
            Me.ddlRiesgoMant.SelectedValue = IIf(oDetallePlanTarifario.IdPlazo = String.Empty, ddlRiesgoMant.SelectedValue, oDetallePlanTarifario.IdPlazo)
            Me.ddlRiesgoMant.Enabled = False
            Me.ddlCuotaMant.SelectedValue = IIf(oDetallePlanTarifario.IdCuota = String.Empty, ddlCuotaMant.SelectedValue, oDetallePlanTarifario.IdCuota)
            Me.ddlCuotaMant.Enabled = False
            Me.txtValorCuota.Text = oDetallePlanTarifario.ValorCuota
            Me.ddlEstado.SelectedValue = IIf(oDetallePlanTarifario.IdEstado = String.Empty, ddlEstado.SelectedValue, oDetallePlanTarifario.IdEstado)
            ddlEstado.Enabled = True
            Me.hid_Validacion.Value = "MODIFICAR"
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")

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


            Limpiar()
            Me.ddlTipoDocumentoMant.Enabled = True
            Me.ddlRiesgoMant.Enabled = True
            Me.ddlCuotaMant.Enabled = True
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")

    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Try
            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Dim sRiesgo As String = Coleccion(0)
            Dim sTipoDoc As String = Coleccion(1)
            Dim sCuota As String = Coleccion(2)

            Dim result As Boolean = True

            If result = True Then
                RegisterStartupScript("script1", "<script>alert('El Registro se Deshabilitó satisfactoriamente.')</script>")
            End If

            btnBuscar_Click(Nothing, Nothing)

        Finally
            Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_ELIMINAR"), "Eliminar Restricción por Cuota.")
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

        Try 'InsertarRestriccionCuota
            Dim validacion As Boolean = False
            Dim mensaje As String = String.Empty
            Dim ListaResCuota As ArrayList
            Dim strUsuario As String = CurrentUser

            If Not Session("ListaResCuota") Is Nothing Then
                ListaResCuota = DirectCast(Session("ListaResCuota"), ArrayList)
                If ListaResCuota.Count = 0 Then
                    validacion = False
                Else
                    validacion = True
                End If
            Else
                If hidCodigo.Value.Length <> 0 Then
                    validacion = True
                Else
                    validacion = False
                End If
            End If

            If validacion Then
                If hidCodigo.Value.Length = 0 Then
                    resultado = New PlanTarifarioBusinessLogic().InsertarRestriccionCuota(ListaResCuota, strUsuario)
                    Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_INSERTAR"), "Registrar Restricción Cuota.")
                Else
                    Dim oDetallePlanTarifario As New DetallePlanTarifario
                    oDetallePlanTarifario.IdDocumento = Me.ddlTipoDocumentoMant.SelectedValue.ToString
                    oDetallePlanTarifario.IdCuota = Me.ddlCuotaMant.SelectedValue.ToString
                    oDetallePlanTarifario.IdPlazo = Me.ddlRiesgoMant.SelectedValue.ToString
                    oDetallePlanTarifario.ValorCuota = CDec(Me.txtValorCuota.Text)

                    resultado = New PlanTarifarioBusinessLogic().ModificarRestriccionCuota(oDetallePlanTarifario, Me.ddlEstado.SelectedValue.ToString)
                    Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_ACTUALIZAR"), "Actualizar Restricción Cuota.")
                End If

                LimpiarViewState()
                btnBuscar_Click(Nothing, Nothing)
                If resultado = False Then 'BUSQUEDA
                    RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('Error. Verificar los datos seleccionados, ya se registraron.')</script>")
                Else
                    Me.ddlRiesgo.SelectedIndex = -1
                    Me.ddlTipoDocumento.SelectedIndex = -1
                    Me.ddlCuotas.SelectedIndex = -1
                    Buscar()
                    RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Los Datos se Registraron satisfactoriamente.')</script>")
                    Me.hid_Validacion.Value = String.Empty
                    Limpiar()
                End If

            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('Debe agregar registros al detalle para grabar grabar')</script>")
                Me.ddlEstado.SelectedIndex = 1
                Me.hid_Validacion.Value = String.Empty
                'Exit Sub
            End If

        Catch ex As Exception
            Limpiar()
            Me.hid_Validacion.Value = String.Empty
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
        Me.ddlCuotas.SelectedIndex = -1
        Limpiar()
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Try
            Dim oListaRestriccion As DataTable = New PlanTarifarioBusinessLogic().ListarRestriccionCuota(Me.ddlTipoDocumento.SelectedValue().ToString, Me.ddlRiesgo.SelectedValue().ToString, Me.ddlCuotas.SelectedValue().ToString)

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
            Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_CONSULTAR"), "Consultar Restricción por Cuota.")
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
                ddlRiesgoMant.DataSource = dtTemp
                ddlRiesgoMant.DataBind()
                ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            Else
                ddlRiesgoMant.Items.Clear()
                ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))

            End If
            Me.ddlEstado.SelectedIndex = 1
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregarGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarGrilla.Click
        'dtbCampanaPV = DirectCast(ViewState("dtbCampanaPV"), DataTable)
        Try
            Dim oDetallePlanTarifario As New DetallePlanTarifario
            oDetallePlanTarifario.IdDocumento = Me.ddlTipoDocumentoMant.SelectedValue.ToString
            oDetallePlanTarifario.DescripcionDocumento = Me.ddlTipoDocumentoMant.Items(Me.ddlTipoDocumentoMant.SelectedIndex).Text
            oDetallePlanTarifario.IdPlazo = Me.ddlRiesgoMant.SelectedValue.ToString
            oDetallePlanTarifario.DescripcionPlazo = Me.ddlRiesgoMant.Items(Me.ddlRiesgoMant.SelectedIndex).Text
            oDetallePlanTarifario.IdCuota = Me.ddlCuotaMant.SelectedValue.ToString
            oDetallePlanTarifario.DescripcionCuota = Me.ddlCuotaMant.Items(Me.ddlCuotaMant.SelectedIndex).Text
            'oDetallePlanTarifario.ValorCuota = CDec(txtValorCuota.Text)
            oDetallePlanTarifario.ValorCuota = CDec(Me.hidCuota.Value)

            'oDetallePlanTarifario.DescripcionPlazo = ddlPlazoAcuerdo.Items(ddlPlazoAcuerdo.SelectedIndex).Text
            If Not existeDato(oDetallePlanTarifario) Then
                Dim ListaResCuota As ArrayList

                Dim existe As Boolean = False

                If Not Session("ListaResCuota") Is Nothing Then
                    ListaResCuota = DirectCast(Session("ListaResCuota"), ArrayList)
                    For Each oDetPT As DetallePlanTarifario In ListaResCuota
                        If oDetPT.IdCuota = Me.ddlCuotaMant.SelectedValue.ToString And oDetPT.IdDocumento = Me.ddlTipoDocumentoMant.SelectedValue.ToString And oDetPT.IdPlazo = Me.ddlRiesgoMant.SelectedValue.ToString Then
                            existe = True
                            Exit For
                        End If
                    Next
                    If existe Then
                        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');alert('Los datos seleccionados ya se ingresaron al detalle.')</script>")
                        Me.ddlEstado.SelectedIndex = 1
                        Exit Sub
                    Else
                        ListaResCuota.Add(oDetallePlanTarifario)
                    End If
                Else
                    ListaResCuota = New ArrayList
                    ListaResCuota.Add(oDetallePlanTarifario)
                End If
                Me.dgDetallePlan.DataSource = ListaResCuota
                Me.dgDetallePlan.DataBind()
                Session("ListaResCuota") = ListaResCuota
                Me.hid_Validacion.Value = "CON_DATOS"
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');alert('Los datos seleccionados ya fueron registrados.')</script>")
                Me.ddlCuotaMant.SelectedIndex = -1
                Me.ddlRiesgoMant.SelectedIndex = -1
                Me.ddlEstado.SelectedIndex = 1
                Me.ddlTipoDocumentoMant.SelectedIndex = -1
                Me.txtValorCuota.Text = "0"
                'RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
                Exit Sub
            End If
            Me.ddlCuotaMant.SelectedIndex = -1
            Me.ddlTipoDocumentoMant.SelectedIndex = -1
            Me.txtValorCuota.Text = "0"
            Me.ddlEstado.SelectedIndex = 1
            ddlRiesgoMant.Items.Clear()
            ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Catch ex As Exception

        End Try


    End Sub

    Function existeDato(ByVal obj As DetallePlanTarifario) As Boolean
        Return New PlanTarifarioBusinessLogic().validarRestriccionCuota(obj.IdPlazo, obj.IdDocumento, obj.IdCuota)
    End Function

    Private Sub ddlTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTipoDocumento.SelectedIndexChanged
        Try
            Dim dtTemp As DataTable

            If ddlTipoDocumento.SelectedValue.ToString <> String.Empty Then
                Dim Valores() As String = Split(ConfigurationSettings.AppSettings("ConstRiesgoTiposTipoDocM").ToString(), ",")
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
            Else
                ddlRiesgo.Items.Clear()
                ddlRiesgo.Items.Insert(0, New ListItem("TODOS", String.Empty))
            End If
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminarDetalle_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarDetalle.ServerClick
        'aqui
        Dim resultado As Boolean
 
            Dim Coleccion() As String = Split(hidCodigo.Value.ToString(), ",")
            Dim sTipoDoc As String = Coleccion(0)
            Dim sPlazo As String = Coleccion(1)
            Dim sCuota As String = Coleccion(2)

            Dim ArrayListTemporal As ArrayList = CType(Session("ListaResCuota"), ArrayList)
            Session("ListaResCuota") = Nothing

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
            Session("ListaResCuota") = oArrayList

        Me.ddlCuotaMant.SelectedIndex = -1
        Me.ddlTipoDocumentoMant.SelectedIndex = -1
        Me.ddlEstado.SelectedIndex = 1
        Me.txtValorCuota.Text = "0"
        ddlRiesgoMant.Items.Clear()
        ddlRiesgoMant.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminarItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarItems.Click

        Dim result As Boolean = New PlanTarifarioBusinessLogic().EliminarRestriccionCuota(getItemsForDelete())
        If result = True Then
            'chkTotalGrilla.

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

        Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_ELIMINAR"), "Eliminar Restricción por Cuota")
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Function getItemsForDelete() As DataTable
        'sRiesgo, sTipoDoc, sCuota
        Dim dt As New DataTable
        Dim ddl As DropDownList
        Dim chk As CheckBox
        Dim dr As DataRow
            dt = New DataTable
            dt.Columns.Add("sRiesgo")
            dt.Columns.Add("sTipoDoc")
            dt.Columns.Add("sCuota")

            For Each dgi As DataGridItem In dgrGrillaDetalle.Items
                chk = DirectCast(dgi.Cells(9).Controls(1), CheckBox)
                If chk.Checked Then
                    dr = dt.NewRow()
                    dr(0) = dgi.Cells(3).Text
                    dr(1) = dgi.Cells(1).Text
                    dr(2) = dgi.Cells(5).Text
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
            applicationPath = System.Web.HttpContext.Current.Server.MapPath(applicationPath & "\RestriccionCuota.csv")
            exportarCsv(applicationPath)
            Response.Redirect("DownloadFiles.aspx?FileName=RestriccionCuota.csv")
        Finally
            Auditoria(ConfigurationSettings.AppSettings("RES_C_CODAUDT_EXPORTAR"), "Exportar Archivo Restricción por Cuota.")
        End Try
    End Sub

    Sub exportarCsv(ByVal ruta As String)
        Dim myTable As DataTable = New PlanTarifarioBusinessLogic().ListarRestriccionCuotaExportar(Me.ddlTipoDocumento.SelectedValue.ToString, Me.ddlRiesgo.SelectedValue.ToString, Me.ddlCuotas.SelectedValue.ToString)

        Dim dr As DataRow = myTable.NewRow
        dr(0) = "TIPO_DOCUMENTO"
        dr(1) = "RIESGO"
        dr(2) = "CUOTA"
        dr(3) = "% CUOTA INICIAL"
        dr(4) = " ESTADO"

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
