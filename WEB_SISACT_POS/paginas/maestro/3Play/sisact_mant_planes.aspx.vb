Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System
Imports System.Data
Imports System.Collections

Public Class sisact_mant_planes
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkPlazo As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgrServicioAsociado As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnMaterialQuitar As System.Web.UI.WebControls.Button
    Protected WithEvents btnMaterialAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlEstadoPlan3Play As System.Web.UI.WebControls.DropDownList

    Protected WithEvents hidCantidadPlazo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTelefoniaFija As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidInternetFijo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaroTvDigital As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaroTvAnalogico As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgrEquipoAsociadoCab As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrEquipoAsociado As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEquipoQuitar As System.Web.UI.WebControls.Button
    Protected WithEvents btnEquipoAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrEquipoCab As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrEquipo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSeleccionarServicios As System.Web.UI.WebControls.Button
    Protected WithEvents btnSeleccionarEquipos As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPlanBSCS As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoOferta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrServicioDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrServicioAsociadoCab As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrServicioCabecera As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
#Region " Variables Globales "
    Dim oPlan3PlayNegocios As New Plan3PlayNegocios
    Dim oPlan3Play As New Plan3Play
    Dim oPlanTarifarioBusinessLogic As New PlanTarifarioBusinessLogic
    Dim oCasoEspecialNegocios As New CasoEspecialNegocios

    Dim oPlanAcuerdo3Play As New PlanAcuerdo3Play
    Dim oPlanAcuerdo3PlayNegocios As New PlanAcuerdo3PlayNegocios

    Dim oServicio3Play As New Servicio3Play
    Dim oServicio3PlayNegocios As New Servicio3PlayNegocios

    Dim oPlanServ3Play As New PlanServ3Play
    Dim oPlanServ3PlayNegocios As New PlanServ3PlayNegocios

    Dim oLog As New SISACT_Log
    Dim oFile As String = oLog.Log_CrearNombreArchivo("logMantenimiento3play")
    Dim dtbKitMaterial As DataTable
    Dim dtbMaterial As DataTable
    Dim dtbKitMaterialTemp As DataTable
    'gaa20130724
    Dim strProductoCodigo3Play As String = ConfigurationSettings.AppSettings("CodTipoProducto3Play")
    Dim dtbEquipo As DataTable
    Dim dtbEquipoAsociado As DataTable
    'fin gaa20130724

    Dim strSeparador1 As String = "|"
    Dim strSeparador2 As String = ";"
    Dim objLog As New SISACT_Log
    Dim strArchivorLog As String = objLog.Log_CrearNombreArchivo("Log_Mantenimiento_Plan3Play")

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
            Dim objConsumerNegocio As ConsumerNegocio

            Try
                dgrServicioAsociadoCab.DataSource = ""
                dgrServicioAsociadoCab.DataBind()

                dgrServicioCabecera.DataSource = ""
                dgrServicioCabecera.DataBind()

                'gaa20130724
                dgrEquipoAsociadoCab.DataSource = ""
                dgrEquipoAsociadoCab.DataBind()

                dgrEquipoCab.DataSource = ""
                dgrEquipoCab.DataBind()

                objConsumerNegocio = New ConsumerNegocio
                ddlPlanBSCS.DataSource = objConsumerNegocio.ListarPlanHFC(String.Empty, " ")
                ddlPlanBSCS.DataValueField = "COD_PLAN"
                ddlPlanBSCS.DataTextField = "DES_PLAN"
                ddlPlanBSCS.DataBind()
                ddlPlanBSCS.Items.Insert(0, ConfigurationSettings.AppSettings("Seleccionar"))
                'fin gaa20130724
                CargarPagina()
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
    
            Finally
                objConsumerNegocio = Nothing
            End Try
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        'gaa20130724
        btnSeleccionarServicios.Attributes.Add("onclick", "return f_MostrarServicios();")
        btnSeleccionarEquipos.Attributes.Add("onclick", "return f_MostrarEquipos();")
        'fin gaa20130724

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
            ddlEstado.SelectedIndex = -1
            ddlPlanBSCS.SelectedIndex = -1
            ddlTipoOferta.SelectedIndex = -1
            ddlEstadoPlan3Play.SelectedValue = "1"

            ddlBusqueda.SelectedIndex = 1
            txtBusDescripcion.ReadOnly = True
            txtBusDescripcion.Text = String.Empty
            txtBusDescripcion.CssClass = "clsInputDisable"
            DeseleccionarPlazo()

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
        Dim dt As DataTable
        Dim lista As ArrayList
        Dim oLista As New Object
    
            dt = New DataTable
            dt = oPlan3PlayNegocios.ListarPlan3PlayTabla(hidCodigo.Value.ToString(), "%%", ddlEstadoPlan3Play.SelectedValue.ToString())
            ddlPlanBSCS.SelectedIndex = -1

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    txtCodigo.Text = CheckStr(dt.Rows(0)("PLNV_CODIGO"))
                    txtDescripcion.Text = CheckStr(dt.Rows(0)("PLNV_DESCRIPCION"))
                    ddlTipoOferta.SelectedValue = CheckStr(dt.Rows(0)("TPROC_CODIGO"))
                    ddlEstado.SelectedValue = CheckStr(dt.Rows(0)("PLNC_ESTADO"))
                    Try
                        ddlPlanBSCS.SelectedValue = CheckStr(dt.Rows(0)("PLNV_CODIGO_BSCS"))
                    Catch ex As Exception
                    End Try

                    DeseleccionarPlazo()
                    SeleccionarPlazo(txtCodigo.Text)
                    'gaa20130724
                    Dim strPlanCodigo As String = CheckStr(dt.Rows(0)("PLNV_CODIGO"))
                    ListarPlanServicios(strPlanCodigo)
                    ListarServicios(strPlanCodigo)
                    ListarEquipoxNoPlan(strPlanCodigo)
                    ListarEquipoxPlan(strPlanCodigo)
                    'fin gaa20130724
                End If
            End If
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")

    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
 
            Limpiar()
            ListarPlanServicios("0")
            ListarServicios("0")
            'gaa20130724
            ListarEquipoxNoPlan("0")
            ListarEquipoxPlan("0")
            'fin gaa20130724
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
            'ddlEstado.SelectedIndex = -1
  
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLKit As LKit
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strUsuario As String = String.Empty
        Try
            strUsuario = CurrentUser
            oPlan3Play.PLNV_CODIGO = hidCodigo.Value.ToString()
            oPlan3Play.PLNV_USUARIO_CREA = strUsuario
            oPlan3PlayNegocios.EliminarPlan3Play(oPlan3Play)

            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "INACTIVAR PLAN. Codigo= " & oPlan3Play.PLNV_CODIGO)

            Auditoria(ConfigurationSettings.AppSettings("codPlan_Eliminar"), "Eliminar Plan 3Play")
            btnBuscar_Click(Nothing, Nothing)
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "ERROR INACTIVAR. " & ex.Message)

            Dim msjErrorGeneral As String = ConfigurationSettings.AppSettings("consMsjErrorGeneral")
            RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('" & msjErrorGeneral & "')</script>")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim curSalida As String
        Dim Msg As String
        Dim drw As DataRow
        Dim strCargoFijo, strlDefecto, strddlObligatorio As String
        Dim strAccion As String = String.Empty
        Dim strUsuario As String = String.Empty

        Try
            oPlan3Play.PLNV_DESCRIPCION = CheckStr(txtDescripcion.Text).ToUpper
            oPlan3Play.PLNC_ESTADO = ddlEstado.SelectedValue
            oPlan3Play.TPROC_CODIGO = ddlTipoOferta.SelectedValue.ToString()
            oPlan3Play.PLNV_USUARIO_CREA = CurrentUser
            oPlan3Play.PLNV_CODIGO_BSCS = ddlPlanBSCS.SelectedValue

            dtbKitMaterial = New DataTable
            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable).Clone

            For Each dgi1 As DataGridItem In dgrServicioAsociado.Items
                If DirectCast(dgi1.Cells(6).FindControl("txtCargoFijo"), TextBox).Text() = "" Then
                    RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Debe ingresar Cargo Fijo en el Servicio: " & dgi1.Cells(3).Text() & ". ')</script>")
                    MostrarTabs()
                    Return
                End If
            Next

            For Each dgi As DataGridItem In dgrServicioAsociado.Items
                strCargoFijo = DirectCast(dgi.Cells(6).FindControl("txtCargoFijo"), TextBox).Text()
                If strCargoFijo = "" Then strCargoFijo = "0"

                drw = dtbKitMaterial.NewRow
                drw("CODIGO_PLAN") = "0"
                drw("CODIGO_SERVICIO") = dgi.Cells(2).Text
                drw("DESCRIPCION_SERVICIO") = dgi.Cells(3).Text
                drw("CODIGO_GRUPO_SERVICIO") = dgi.Cells(4).Text
                drw("DESCRIPCION_GRUPO_SERVICIO") = dgi.Cells(5).Text
                drw("CARGO_FIJO") = strCargoFijo
                drw("DEFECTO") = strlDefecto
                drw("OBLIGATORIO") = strddlObligatorio
                dtbKitMaterial.Rows.Add(drw)
            Next

            dtbKitMaterial.AcceptChanges()

            strUsuario = CurrentUser
            If hidCodigo.Value.Length = 0 Then
                strAccion = "N"
            Else
                strAccion = "E"
                oPlan3Play.PLNV_CODIGO = CheckStr(hidCodigo.Value)
            End If

            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "INICIO GRABAR/EDITAR PLAN")
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "ACCION=" & strAccion)

            oPlan3Play.PARAM_GENERALES = ObtenerParametrosGenerales()
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "PARAM_GENERALES=" & oPlan3Play.PARAM_GENERALES)

            oPlan3Play.PLAZOS = ObtenerPlazos()
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "PLAZOS=" & oPlan3Play.PLAZOS)

            oPlan3Play.SERVICIOS = ObtenerServicios()
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "SERVICIOS=" & oPlan3Play.SERVICIOS)

            oPlan3Play.ALQUILER = ObtenerEquipos()
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "ALQUILER=" & oPlan3Play.ALQUILER)

            Dim blnOK As Boolean = New Plan3PlayNegocios().MantenimientoPlan3Play(strAccion, oPlan3Play)

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            objLog.Log_WriteLog(strArchivorLog, " -" & strUsuario & "- " & "ERROR. " & ex.Message)

            Dim msjErrorGeneral As String = ConfigurationSettings.AppSettings("consMsjErrorGeneral")
            RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('" & msjErrorGeneral & "')</script>")
        Finally
            If strAccion = "N" Then
                Auditoria(ConfigurationSettings.AppSettings("codPlan_Insertar"), "Insertar Plan 3Play")
            Else
                Auditoria(ConfigurationSettings.AppSettings("codPlan_Modificar"), "Modificar Plan 3Play")
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnMaterialQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialQuitar.Click
        Dim chk As CheckBox
        Dim drwMaterial As DataRow
        Dim aux% = 0

        Dim codGrupoServicio As String
        Dim strCargoFijo, strlDefecto, strddlObligatorio As String

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)

            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            For i As Integer = 0 To dgrServicioAsociado.Items.Count - 1
                chk = DirectCast(dgrServicioAsociado.Items(i).Cells(0).FindControl("chkSD"), CheckBox)

                If chk.Checked Then
                    drwMaterial = dtbMaterial.NewRow
                    drwMaterial("CODIGO_SERVICIO") = dgrServicioAsociado.Items(i).Cells(2).Text
                    drwMaterial("DESCRIPCION_SERVICIO") = dgrServicioAsociado.Items(i).Cells(3).Text
                    'drwMaterial("CODIGO_GRUPO_SERVICIO") = dgrServicioAsociado.Items(i).Cells(4).Text
                    codGrupoServicio = dgrServicioAsociado.Items(i).Cells(4).Text
                    drwMaterial("CODIGO_GRUPO_SERVICIO") = codGrupoServicio
                    drwMaterial("DESCRIPCION_GRUPO_SERVICIO") = dgrServicioAsociado.Items(i).Cells(5).Text
                    'gaa20130724
                    drwMaterial("CODIGO_GRUPO_SERVICIO_PADRE") = dgrServicioAsociado.Items(i).Cells(13).Text
                    'fin gaa20130724
                    'gaa20130724
                    drwMaterial("SERVV_ID_BSCS") = dgrServicioAsociado.Items(i).Cells(14).Text
                    'fin gaa20130724
                    dtbMaterial.Rows.Add(drwMaterial)

                    strlDefecto = DirectCast(dgrServicioAsociado.Items(i).Cells(7).FindControl("ddlDefecto"), DropDownList).SelectedValue

                    dtbKitMaterial.Rows(i).Delete()
                    aux = aux + 1
                End If
            Next

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)
            'RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
            If (hidCodigo.Value = "" Or hidCodigo.Value = "0") Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');f_MostrarServicios()</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_MostrarServicios()</script>")
            End If

            If aux = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub

    Private Sub btnMaterialAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialAgregar.Click
        Dim chk As CheckBox
        Dim drwKitMaterial As DataRow
        Dim aux% = 0
        Dim codGrupoServicio As String

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)
            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            For i As Integer = 0 To dgrServicioDetalle.Items.Count - 1
                chk = DirectCast(dgrServicioDetalle.Items(i).Cells(0).FindControl("chkMD"), CheckBox)

                If chk.Checked Then
                    drwKitMaterial = dtbKitMaterial.NewRow
                    drwKitMaterial("CODIGO_SERVICIO") = dgrServicioDetalle.Items(i).Cells(1).Text
                    drwKitMaterial("DESCRIPCION_SERVICIO") = dgrServicioDetalle.Items(i).Cells(2).Text
                    'drwKitMaterial("CODIGO_GRUPO_SERVICIO") = dgrServicioDetalle.Items(i).Cells(3).Text
                    codGrupoServicio = dgrServicioDetalle.Items(i).Cells(3).Text
                    drwKitMaterial("CODIGO_GRUPO_SERVICIO") = codGrupoServicio
                    drwKitMaterial("DESCRIPCION_GRUPO_SERVICIO") = dgrServicioDetalle.Items(i).Cells(4).Text
                    drwKitMaterial("GSRVC_PRINCIPAL") = dgrServicioDetalle.Items(i).Cells(5).Text
                    drwKitMaterial("CARGO_FIJO") = "0"
                    'gaa20130724
                    drwKitMaterial("CODIGO_GRUPO_SERVICIO_PADRE") = dgrServicioDetalle.Items(i).Cells(6).Text
                    'fin gaa20130724
                    'gaa20131104
                    drwKitMaterial("SERVV_ID_BSCS") = dgrServicioDetalle.Items(i).Cells(7).Text
                    'fin gaa20131104
                    dtbKitMaterial.Rows.Add(drwKitMaterial)
                    dtbMaterial.Rows(i).Delete()
                    aux = aux + 1
                End If
            Next

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)
            If (hidCodigo.Value = "" Or hidCodigo.Value = "0") Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');f_MostrarServicios()</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_MostrarServicios()</script>")
            End If

            If aux = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub

    Private Function GuardarCantidades(ByVal pdtbKitMaterial As DataTable) As DataTable
        Dim drw As DataRow
        pdtbKitMaterial.Rows.Clear()
        pdtbKitMaterial.AcceptChanges()
        Dim strCargoFijo, strlDefecto, strddlObligatorio, strPrincipal, strGrupoPadre, strIdBSCS As String

        For Each dgi As DataGridItem In dgrServicioAsociado.Items
            strCargoFijo = DirectCast(dgi.Cells(6).FindControl("txtCargoFijo"), TextBox).Text
            strlDefecto = DirectCast(dgi.Cells(7).FindControl("ddlDefecto"), DropDownList).SelectedValue
            strddlObligatorio = DirectCast(dgi.Cells(8).FindControl("ddlObligatorio"), DropDownList).SelectedValue
            strPrincipal = DirectCast(dgi.Cells(7).FindControl("hidPRINCIPAL"), HtmlInputHidden).Value
            'gaa20130803
            strGrupoPadre = DirectCast(dgi.Cells(7).FindControl("hidGrupoPadre"), HtmlInputHidden).Value
            'fin gaa20130803
            'gaa20131104
            strIdBSCS = DirectCast(dgi.Cells(7).FindControl("hidIdBSCS"), HtmlInputHidden).Value
            'fin gaa20131104
            If strCargoFijo = "" Then strCargoFijo = "0" 'Modificar campo CargoFijo en SP para que sea string

            drw = pdtbKitMaterial.NewRow
            drw("CODIGO_PLAN") = "0"
            drw("CODIGO_SERVICIO") = dgi.Cells(2).Text
            drw("DESCRIPCION_SERVICIO") = dgi.Cells(3).Text
            drw("CODIGO_GRUPO_SERVICIO") = dgi.Cells(4).Text
            drw("DESCRIPCION_GRUPO_SERVICIO") = dgi.Cells(5).Text
            drw("CARGO_FIJO") = strCargoFijo '6
            drw("DEFECTO") = strlDefecto '7
            drw("OBLIGATORIO") = strddlObligatorio '8
            drw("GSRVC_PRINCIPAL") = strPrincipal '9
            'gaa20130803
            drw("CODIGO_GRUPO_SERVICIO_PADRE") = strGrupoPadre
            'fin gaa20130803
            'gaa20131104
            drw("SERVV_ID_BSCS") = strIdBSCS
            'fin gaa20131104
            pdtbKitMaterial.Rows.Add(drw)
        Next

        pdtbKitMaterial.AcceptChanges()

        Return pdtbKitMaterial
    End Function
    'gaa20130724
    Private Function GuardarCantidadesEquipo(ByVal pdtbEquipoAsociado As DataTable) As DataTable
        Dim drw As DataRow
        pdtbEquipoAsociado.Rows.Clear()
        pdtbEquipoAsociado.AcceptChanges()
        Dim strEquipoPrecio As String

        For Each dgi As DataGridItem In dgrEquipoAsociado.Items
            strEquipoPrecio = DirectCast(dgi.Cells(3).FindControl("txtEquipoPrecio"), TextBox).Text

            If strEquipoPrecio = "" Then strEquipoPrecio = "0" 'Modificar campo CargoFijo en SP para que sea string

            drw = pdtbEquipoAsociado.NewRow
            drw("CODIGO") = dgi.Cells(1).Text
            drw("DESCRIPCION") = dgi.Cells(2).Text
            drw("PRECIO") = strEquipoPrecio
            drw("PRECIO_BASE") = dgi.Cells(5).Text
            drw("SERVV_ID_BSCS") = dgi.Cells(6).Text
            pdtbEquipoAsociado.Rows.Add(drw)
        Next

        pdtbEquipoAsociado.AcceptChanges()

        Return pdtbEquipoAsociado
    End Function
    'fin gaa20130724
    Private Sub EnlazarGrillaMaterial(ByVal pdtbKitMaterial As DataTable, ByVal pdtbMaterial As DataTable)
        dgrServicioAsociado.DataSource = pdtbKitMaterial
        dgrServicioAsociado.DataBind()

        dgrServicioDetalle.DataSource = pdtbMaterial
        dgrServicioDetalle.DataBind()

        DirectCast(dgrServicioAsociadoCab.Controls(0).Controls(0).Controls(0).FindControl("chkTotalSD"), CheckBox).Checked = False
        DirectCast(dgrServicioCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalMD"), CheckBox).Checked = False
    End Sub
    'gaa20130724
    Private Sub EnlazarGrillaEquipo(ByVal pdtbEquipoAsociado As DataTable, ByVal pdtbEquipo As DataTable)
        dgrEquipoAsociado.DataSource = pdtbEquipoAsociado
        dgrEquipoAsociado.DataBind()

        dgrEquipo.DataSource = pdtbEquipo
        dgrEquipo.DataBind()

        DirectCast(dgrEquipoAsociadoCab.Controls(0).Controls(0).Controls(0).FindControl("chkTotalEA"), CheckBox).Checked = False
        DirectCast(dgrEquipoCab.Controls(0).Controls(0).Controls(0).FindControl("chkTotalE"), CheckBox).Checked = False
    End Sub
    'fin gaa20130724
    Private Sub dgrServicioAsociado_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrServicioAsociado.ItemDataBound
        Dim txtCargoFijo As TextBox
        Dim ddlDefecto As DropDownList
        Dim ddlObligatorio As DropDownList
        Dim hidPrincipal As HtmlInputHidden
        'gaa20130724
        Dim hidGrupoPadre As HtmlInputHidden
        'fin gaa20130724
        'gaa20131104
        Dim hidIdBSCS As HtmlInputHidden
        'fin gaa20131104

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            txtCargoFijo = DirectCast(e.Item.Cells(6).FindControl("txtCargoFijo"), TextBox)
            txtCargoFijo.Text = e.Item.Cells(9).Text.Replace("&nbsp;", String.Empty)
            ddlDefecto = DirectCast(e.Item.Cells(7).FindControl("ddlDefecto"), DropDownList)
            ddlObligatorio = DirectCast(e.Item.Cells(8).FindControl("ddlObligatorio"), DropDownList)
            hidPrincipal = DirectCast(e.Item.Cells(7).FindControl("hidPRINCIPAL"), HtmlInputHidden)
            'gaa20130724
            hidGrupoPadre = DirectCast(e.Item.Cells(7).FindControl("hidGrupoPadre"), HtmlInputHidden)
            'fin gaa20130724
            'gaa20131104
            hidIdBSCS = DirectCast(e.Item.Cells(7).FindControl("hidIdBSCS"), HtmlInputHidden)
            'fin gaa20131104
            txtCargoFijo.Text = e.Item.Cells(9).Text.Replace("&nbsp;", String.Empty)
            If e.Item.Cells(10).Text.Replace("&nbsp;", String.Empty) <> "" Then
                ddlDefecto.SelectedValue = e.Item.Cells(10).Text.Replace("&nbsp;", String.Empty)
                ddlDefecto.Attributes.Add("onChange", "cambiarValorDefecto(this)")
                hidPrincipal.Value = e.Item.Cells(12).Text.Replace("&nbsp;", String.Empty)
                'gaa20130724
                hidGrupoPadre.Value = e.Item.Cells(13).Text.Replace("&nbsp;", String.Empty)
                'fin gaa20130724
                'gaa20130808
                ddlObligatorio.SelectedValue = e.Item.Cells(11).Text.Replace("&nbsp;", String.Empty)
                'fin gaa20130808
                'gaa20131104
                hidIdBSCS.Value = e.Item.Cells(14).Text.Replace("&nbsp;", String.Empty)
                'fin gaa20131104
            End If

            'gaa20130724
            'If e.Item.Cells(11).Text.Replace("&nbsp;", String.Empty) <> "" Then
            'fin gaa20130724
            'gaa20130724
            'If Not hidPrincipal.Value = "1" Then
            If hidPrincipal.Value = "1" Then
                'fin gaa20130724
                ddlObligatorio.SelectedIndex = -1
                ddlObligatorio.Enabled = False
                'gaa20130724
            Else
                ddlDefecto.Enabled = False
                'fin gaa20130724
            End If
            'gaa20130724
            'End If
            'fin gaa20130724
        End If
    End Sub

    'gaa20130724
    Private Sub dgrEquipoAsociado_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrEquipoAsociado.ItemDataBound
        Dim txtEquipoPrecio As TextBox

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            txtEquipoPrecio = DirectCast(e.Item.Cells(3).FindControl("txtEquipoPrecio"), TextBox)
            txtEquipoPrecio.Text = e.Item.Cells(4).Text.Replace("&nbsp;", String.Empty)
        End If
    End Sub
    'fin gaa20130724

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            If Not ddlEstadoPlan3Play.SelectedValue.ToString() = "1" Then
                e.Item.Cells(8).Text = ""
            End If
        End If
    End Sub

    Private Sub Buscar()
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim
            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = ListarPlan3Play(strDescripcion)
                dgrGrillaDetalle.DataBind()
                Auditoria(ConfigurationSettings.AppSettings("codPlan_Consulta"), "Consulta Plan 3Play")
            End If

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

    Private Sub MostrarTabs()
        If (hidCodigo.Value = "" Or hidCodigo.Value = "0") Then
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
        End If
    End Sub

#Region "METODOS MANTE 3PLAY"

    Private Function ListarPlan3Play(ByVal strDescripcion As String) As ArrayList
        Dim lista As ArrayList
        Dim descripcion As String = "%" & CheckStr(strDescripcion) & "%"
        lista = oPlan3PlayNegocios.ListarPlan3Play("0", descripcion, ddlEstadoPlan3Play.SelectedValue.ToString())
        Return lista
    End Function

    Private Sub CargarPagina()
        Dim dt As New DataTable
        dt = (New LEquipos3Play).fdtbListarEstadoEquipos("2")
        If Not dt Is Nothing Then
            ddlEstado.DataSource = dt
            ddlEstado.DataValueField = "ITEMN_CODIGO"
            ddlEstado.DataTextField = "ITEMN_DESCRIPCION"
            ddlEstado.DataBind()
        End If

        dt.Clear()
        dt = Nothing
        dt = oPlanTarifarioBusinessLogic.ListarOferta()
        If Not dt Is Nothing Then
            ddlTipoOferta.DataSource = dt
            ddlTipoOferta.DataValueField = "TOFC_CODIGO"
            ddlTipoOferta.DataTextField = "TOFV_DESCRIPCION"
            ddlTipoOferta.DataBind()
        End If

        dt.Clear()
        dt = Nothing
        dt = oCasoEspecialNegocios.ListadoComboPlazoAcuerdo("")
        If Not dt Is Nothing Then
            chkPlazo.DataSource = dt
            chkPlazo.DataValueField = "PLZAC_CODIGO"
            chkPlazo.DataTextField = "PLZAV_DESCRIPCION"
            chkPlazo.DataBind()
            hidCantidadPlazo.Value = dt.Rows.Count.ToString()
        End If
    End Sub

    'PLAN ACUERDO
    Private Sub DeseleccionarPlazo()
        Dim i As Integer
        For i = 0 To Convert.ToInt32(hidCantidadPlazo.Value) - 1 Step 1
            If chkPlazo.Items(i).Selected Then
                chkPlazo.Items(i).Selected = False
            End If
        Next
    End Sub
    Private Sub SeleccionarPlazo(ByVal CodigoPlan As String)
        Dim dt As New DataTable
        dt = oPlanAcuerdo3PlayNegocios.ListarPlanAcuerdo3Play(CodigoPlan)

        If Not dt Is Nothing Then
            Dim i, j As Integer
            Dim PLZAC_CODIGO As String

            For i = 0 To dt.Rows.Count - 1 Step 1
                PLZAC_CODIGO = Convert.ToString(dt.Rows(i)("PLZAC_CODIGO"))

                For j = 0 To Convert.ToInt32(hidCantidadPlazo.Value) - 1 Step 1
                    If PLZAC_CODIGO = chkPlazo.Items(j).Value Then
                        chkPlazo.Items(j).Selected = True
                        Exit For
                    End If
                Next
            Next

        End If
    End Sub

    Private Sub GrabarPlanAcuerdo(ByVal CodigoPlan As String)
        Dim i As Integer
        Dim Codigo, Descripcion, CodigoCadena, DescripcionCadena As String

        For i = 0 To Convert.ToInt32(hidCantidadPlazo.Value) - 1 Step 1
            If chkPlazo.Items(i).Selected Then
                Codigo = chkPlazo.Items(i).Value.ToString()
                Descripcion = chkPlazo.Items(i).Text.ToString()

                CodigoCadena = CodigoCadena & Codigo & ","
                DescripcionCadena = DescripcionCadena & Descripcion & ","
            End If
        Next

        If CodigoCadena <> "" Then
            CodigoCadena = Left(CodigoCadena, CodigoCadena.Length - 1)

            oPlanAcuerdo3Play.PLNV_CODIGO = CodigoPlan
            oPlanAcuerdo3Play.PLZAC_CODIGO = CodigoCadena
            oPlanAcuerdo3Play.PACUV_USUARIO_CREA = CurrentUser
            oPlanAcuerdo3PlayNegocios.InsertarPlanAcuerdo3Play(oPlanAcuerdo3Play)
        End If

    End Sub

    Private Sub EliminarPlanAcuerdo(ByVal CodigoPlan As String)
        oPlanAcuerdo3Play.PLNV_CODIGO = CodigoPlan
        oPlanAcuerdo3Play.PACUV_USUARIO_CREA = CurrentUser
        oPlanAcuerdo3PlayNegocios.EliminarPlanAcuerdo3Play(oPlanAcuerdo3Play)
    End Sub

    'SERVICIOS
    Private Sub ListarServicios(ByVal CodigoPlan As String)
        dtbMaterial = New DataTable
        dtbMaterial = oServicio3PlayNegocios.ListarServicio3PlayTabla(CodigoPlan)
        dgrServicioDetalle.DataSource = dtbMaterial
        dgrServicioDetalle.DataBind()
        ViewState("dtbMaterial") = dtbMaterial
    End Sub

    'SERVICO PLAN
    Private Sub ListarPlanServicios(ByVal CodigoPlan As String)
        dtbKitMaterial = New DataTable
        dtbKitMaterial = oPlanServ3PlayNegocios.ListarPlanServ3Play(CodigoPlan)
        dgrServicioAsociado.DataSource = dtbKitMaterial
        dgrServicioAsociado.DataBind()
        ViewState("dtbKitMaterial") = dtbKitMaterial
    End Sub
    'gaa20130724
    Private Sub ListarEquipoxNoPlan(ByVal pstrPlanCodigo As String)
        dtbEquipo = New DataTable
        dtbEquipo = oPlanServ3PlayNegocios.ListarEquipoxNoPlan(strProductoCodigo3Play, pstrPlanCodigo)
        dgrEquipo.DataSource = dtbEquipo
        dgrEquipo.DataBind()
        ViewState("dtbEquipo") = dtbEquipo
    End Sub

    Private Sub ListarEquipoxPlan(ByVal pstrPlanCodigo As String)
        dtbEquipoAsociado = New DataTable
        dtbEquipoAsociado = oPlanServ3PlayNegocios.ListarEquipoxPlan(strProductoCodigo3Play, pstrPlanCodigo)
        dgrEquipoAsociado.DataSource = dtbEquipoAsociado
        dgrEquipoAsociado.DataBind()
        ViewState("dtbEquipoAsociado") = dtbEquipoAsociado
    End Sub
    'fin gaa20130724
    Private Sub EliminarPlanServicios(ByVal CodigoPlan As String)
        oPlanServ3PlayNegocios.EliminarPlanServ3Play(CodigoPlan)
    End Sub

    Private Sub GrabarPlanServicios(ByVal CodigoPlan As String)
        Dim Codigo, CodigoCadena, strCargoFijo, strlDefecto, strddlObligatorio, strIdBSCS, strSPCODE As String
        Dim objPlanServ As PlanServ3PlayNegocios
        Dim dtbPlanServ As DataTable
        Dim drwPlanServ() As DataRow

            objPlanServ = New PlanServ3PlayNegocios
            dtbPlanServ = objPlanServ.ListarPlanServicioBSCS(ddlPlanBSCS.SelectedValue)

        For Each dgi As DataGridItem In dgrServicioAsociado.Items
            Codigo = dgi.Cells(2).Text ' Codigo de Servicio
            strCargoFijo = DirectCast(dgi.Cells(6).FindControl("txtCargoFijo"), TextBox).Text
            strlDefecto = DirectCast(dgi.Cells(7).FindControl("ddlDefecto"), DropDownList).SelectedValue
            strddlObligatorio = DirectCast(dgi.Cells(8).FindControl("ddlObligatorio"), DropDownList).SelectedValue
            If strCargoFijo = "" Then strCargoFijo = "0"
                strddlObligatorio = strddlObligatorio
                'gaa20131104
                strIdBSCS = dgi.Cells(14).Text
                drwPlanServ = dtbPlanServ.Select(String.Format("sncode = '{0}'", strIdBSCS))
                strSPCODE = "0"

                If Not drwPlanServ Is Nothing Then
                    If drwPlanServ.Length > 0 Then
                        strSPCODE = drwPlanServ(0)("SPCODE")
                    End If
                End If

                'CodigoCadena = CodigoCadena & Codigo & "," & strCargoFijo & "," & strlDefecto & "," & strddlObligatorio
                CodigoCadena = CodigoCadena & Codigo & "," & strCargoFijo & "," & strlDefecto & "," & strddlObligatorio & "," & strSPCODE & "|"
                'fin gaa20131104
        Next

            For Each dgi As DataGridItem In dgrEquipoAsociado.Items()
                Codigo = dgi.Cells(1).Text ' Codigo de Servicio
                strCargoFijo = DirectCast(dgi.Cells(3).FindControl("txtEquipoPrecio"), TextBox).Text

                If strCargoFijo = "" Then strCargoFijo = "0"
                strddlObligatorio = strddlObligatorio
                'gaa20131104
                strIdBSCS = dgi.Cells(6).Text
                drwPlanServ = dtbPlanServ.Select(String.Format("sncode = '{0}'", strIdBSCS))
                strSPCODE = "0"

                If Not drwPlanServ Is Nothing Then
                    If drwPlanServ.Length > 0 Then
                        strSPCODE = drwPlanServ(0)("SPCODE")
                    End If
                End If

                'CodigoCadena = CodigoCadena & Codigo & "," & strCargoFijo & "," & strlDefecto & "," & strddlObligatorio
                CodigoCadena = CodigoCadena & Codigo & "," & strCargoFijo & "," & strlDefecto & "," & strddlObligatorio & "," & strSPCODE & "|"
                'fin gaa20131104
            Next

        If CodigoCadena <> "" Then
            CodigoCadena = Left(CodigoCadena, CodigoCadena.Length - 1)

            oPlanServ3Play.PLNV_CODIGO = CodigoPlan
            oPlanServ3Play.SERVV_CODIGO = CodigoCadena
            oPlanServ3Play.PSRVV_USUARIO_CREA = CurrentUser
            oPlanServ3PlayNegocios.InsertarPlanServ3Play(oPlanServ3Play)
        End If

    End Sub

    'gaa20130724
    Private Sub GrabarPlanEquipos(ByVal pstrPlanCodigo As String)
        Dim strCadena, strCodigo, strPrecio As String

        For Each dgi As DataGridItem In dgrEquipoAsociado.Items
            strCodigo = dgi.Cells(1).Text
            strPrecio = DirectCast(dgi.Cells(3).FindControl("txtEquipoPrecio"), TextBox).Text
            If strPrecio = "" Then strPrecio = "0"

            strCadena = strCadena & strCodigo & "," & strPrecio & "|"
        Next

        If strCadena <> "" Then
            strCadena = Left(strCadena, strCadena.Length - 1)
        End If

        oPlanServ3Play.PLNV_CODIGO = pstrPlanCodigo
        oPlanServ3Play.SERVV_CODIGO = strCadena
        oPlanServ3Play.PSRVV_USUARIO_CREA = CurrentUser
        oPlanServ3PlayNegocios.InsertarPlanEqui3Play(oPlanServ3Play)
    End Sub
    'fin gaa20130724

    'gaa20130724
    Private Sub btnEquipoQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipoQuitar.Click
        Dim chk As CheckBox
        Dim drwEquipo As DataRow
        Dim aux As Integer = 0

            dtbEquipoAsociado = DirectCast(ViewState("dtbEquipoAsociado"), DataTable)
            dtbEquipo = DirectCast(ViewState("dtbEquipo"), DataTable)
            dtbEquipoAsociado = GuardarCantidadesEquipo(dtbEquipoAsociado)

            For i As Integer = 0 To dgrEquipoAsociado.Items.Count - 1
                chk = DirectCast(dgrEquipoAsociado.Items(i).Cells(0).FindControl("chkEA"), CheckBox)

                If chk.Checked Then
                    drwEquipo = dtbEquipo.NewRow
                    drwEquipo("CODIGO") = dgrEquipoAsociado.Items(i).Cells(1).Text
                    drwEquipo("DESCRIPCION") = dgrEquipoAsociado.Items(i).Cells(2).Text
                    drwEquipo("PRECIO_BASE") = dgrEquipoAsociado.Items(i).Cells(5).Text
                    dtbEquipo.Rows.Add(drwEquipo)

                    dtbEquipoAsociado.Rows(i).Delete()
                    aux = aux + 1
                End If
            Next

            dtbEquipoAsociado.AcceptChanges()
            dtbEquipo.AcceptChanges()

            ViewState("dtbEquipoAsociado") = dtbEquipoAsociado
            ViewState("dtbEquipo") = dtbEquipo

            EnlazarGrillaEquipo(dtbEquipoAsociado, dtbEquipo)
            If (hidCodigo.Value = "" Or hidCodigo.Value = "0") Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');f_MostrarEquipos()</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_MostrarEquipos()</script>")
            End If

            If aux = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub

    Private Sub btnEquipoAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipoAgregar.Click
        Dim chk As CheckBox
        Dim drwEquipoAsociado As DataRow
        Dim aux% = 0
        Dim codGrupoServicio As String


            dtbEquipoAsociado = DirectCast(ViewState("dtbEquipoAsociado"), DataTable)
            dtbEquipo = DirectCast(ViewState("dtbEquipo"), DataTable)
            dtbEquipoAsociado = GuardarCantidadesEquipo(dtbEquipoAsociado)

            For i As Integer = 0 To dgrEquipo.Items.Count - 1
                chk = DirectCast(dgrEquipo.Items(i).Cells(0).FindControl("chkENA"), CheckBox)

                If chk.Checked Then
                    drwEquipoAsociado = dtbEquipoAsociado.NewRow
                    drwEquipoAsociado("CODIGO") = dgrEquipo.Items(i).Cells(1).Text
                    drwEquipoAsociado("DESCRIPCION") = dgrEquipo.Items(i).Cells(2).Text
                    drwEquipoAsociado("PRECIO") = dgrEquipo.Items(i).Cells(3).Text
                    drwEquipoAsociado("PRECIO_BASE") = dgrEquipo.Items(i).Cells(3).Text
                    drwEquipoAsociado("SERVV_ID_BSCS") = dgrEquipo.Items(i).Cells(4).Text
                    dtbEquipoAsociado.Rows.Add(drwEquipoAsociado)
                    dtbEquipo.Rows(i).Delete()
                    aux = aux + 1
                End If
            Next

            dtbEquipoAsociado.AcceptChanges()
            dtbEquipo.AcceptChanges()

            ViewState("dtbEquipoAsociado") = dtbEquipoAsociado
            ViewState("dtbEquipo") = dtbEquipo

            EnlazarGrillaEquipo(dtbEquipoAsociado, dtbEquipo)
            If (hidCodigo.Value = "" Or hidCodigo.Value = "0") Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');f_MostrarEquipos()</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION');f_MostrarEquipos()</script>")
            End If

            If aux = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub
    'fin gaa20130724
#End Region

    Protected Function ObtenerParametrosGenerales() As String
        Dim lResult As String = String.Empty

        lResult &= oPlan3Play.PLNV_CODIGO & strSeparador1
        lResult &= oPlan3Play.PLNV_DESCRIPCION.Replace(strSeparador1, String.Empty) & strSeparador1
        lResult &= oPlan3Play.PLNC_ESTADO & strSeparador1
        lResult &= oPlan3Play.TPROC_CODIGO & strSeparador1
        lResult &= oPlan3Play.PLNN_CARGO_FIJO & strSeparador1
        lResult &= oPlan3Play.PLNV_CODIGO_BSCS

        Return lResult
    End Function

    Protected Function ObtenerPlazos() As String
        Dim i As Integer
        Dim lResult As String = String.Empty
        Dim idPlazo As String = String.Empty

        For i = 0 To Convert.ToInt32(hidCantidadPlazo.Value) - 1 Step 1
            If chkPlazo.Items(i).Selected Then
                idPlazo = CheckStr(chkPlazo.Items(i).Value)
                lResult &= idPlazo & strSeparador1
            End If
        Next

        Return lResult
    End Function

    Protected Function ObtenerServicios() As String
        Dim lResult As String = String.Empty
        Dim strCodServicio As String = String.Empty
        Dim strCargoFijo As String = String.Empty
        Dim strDefecto As String = String.Empty
        Dim strObligatorio As String = String.Empty
        Dim strSrvPrincipal As String = String.Empty
        Dim tmcode As String = String.Empty
        Dim spcode As String = String.Empty
        Dim sncode As String = String.Empty

        ' Consultar Configuración BSCS
        tmcode = ddlPlanBSCS.SelectedValue
        Dim dtbPlanServ As DataTable = New PlanServ3PlayNegocios().ListarPlanServicioBSCS(tmcode)

        For Each dgi As DataGridItem In dgrServicioAsociado.Items
            strCodServicio = dgi.Cells(2).Text
            strCargoFijo = DirectCast(dgi.Cells(6).FindControl("txtCargoFijo"), TextBox).Text
            strDefecto = DirectCast(dgi.Cells(7).FindControl("ddlDefecto"), DropDownList).SelectedValue
            strObligatorio = DirectCast(dgi.Cells(8).FindControl("ddlObligatorio"), DropDownList).SelectedValue
            strSrvPrincipal = DirectCast(dgi.Cells(7).FindControl("hidPRINCIPAL"), HtmlInputHidden).Value

            If strSrvPrincipal = "1" Then
                strObligatorio = "1"
            Else
                strDefecto = "0"
            End If

            sncode = CheckStr(dgi.Cells(14).Text)
            spcode = String.Empty

            If CheckStr(strCargoFijo) = "" Then strCargoFijo = "0"

            Dim drPlanServ() As DataRow
            drPlanServ = dtbPlanServ.Select(String.Format("sncode = '{0}'", sncode))

            If Not drPlanServ Is Nothing Then
                If drPlanServ.Length > 0 Then
                    spcode = drPlanServ(0)("SPCODE")
                End If
            End If

            If CheckStr(spcode) = "" Then
                Dim input As String = String.Format("spcode no encontrado. tmcode={0}|idServ={1}|sncode={2}", tmcode, strCodServicio, sncode)
                Throw New Exception(input)
            End If

            lResult &= strCodServicio & strSeparador2
            lResult &= strCargoFijo & strSeparador2
            lResult &= strObligatorio & strSeparador2
            lResult &= spcode & strSeparador2
            lResult &= strDefecto & strSeparador1
        Next

        For Each dgi As DataGridItem In dgrEquipoAsociado.Items()
            strCodServicio = dgi.Cells(1).Text
            strCargoFijo = DirectCast(dgi.Cells(3).FindControl("txtEquipoPrecio"), TextBox).Text
            strDefecto = "0"
            strObligatorio = "0"
            tmcode = CheckStr(dgi.Cells(6).Text)

            If CheckStr(strCargoFijo) = "" Then strCargoFijo = "0"

            Dim drPlanServ() As DataRow
            drPlanServ = dtbPlanServ.Select(String.Format("sncode = '{0}'", tmcode))

            If Not drPlanServ Is Nothing Then
                If drPlanServ.Length > 0 Then
                    spcode = drPlanServ(0)("SPCODE")
                End If
            End If

            lResult &= strCodServicio & strSeparador2
            lResult &= strCargoFijo & strSeparador2
            lResult &= strObligatorio & strSeparador2
            lResult &= spcode & strSeparador2
            lResult &= strDefecto & strSeparador1
        Next

        Return lResult

    End Function

    Protected Function ObtenerEquipos() As String
        Dim lResult As String = String.Empty
        Dim strCodServicio As String = String.Empty
        Dim strPrecio As String = String.Empty

        For Each dgi As DataGridItem In dgrEquipoAsociado.Items()
            strCodServicio = dgi.Cells(1).Text
            strPrecio = DirectCast(dgi.Cells(3).FindControl("txtEquipoPrecio"), TextBox).Text

            lResult &= strCodServicio & strSeparador2
            lResult &= strPrecio & strSeparador1
        Next

        Return lResult
    End Function

End Class
