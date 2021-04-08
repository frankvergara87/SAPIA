Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System
Imports System.Data
Imports System.Collections

Public Class sisact_mant_paquetes
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstadoPlan3Play As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrKitMaterialCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKitMaterialDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnMaterialQuitar As System.Web.UI.WebControls.Button
    Protected WithEvents btnMaterialAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrMaterialCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrMaterialDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCantidadPlazo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrdenPaquete As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlProductoMod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProducto As System.Web.UI.WebControls.DropDownList

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
    Dim oPlanTarifarioBusinessLogic As New PlanTarifarioBusinessLogic

    Dim oPaquete3PlayNegocios As New Paquete3PlayNegocios
    Dim oPaquete3Play As New Paquete3Play

    Dim oPaquetePlan3PlayNegocios As New PaquetePlan3PlayNegocios
    Dim oPaquetePlan3Play As New PaquetePlan3Play

    Dim dtbKitMaterial As DataTable
    Dim dtbMaterial As DataTable
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
   
                dgrKitMaterialCabecera.DataSource = ""
                dgrKitMaterialCabecera.DataBind()

                dgrMaterialCabecera.DataSource = ""
                dgrMaterialCabecera.DataBind()

                CargarPagina()
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
        hidOrdenPaquete.Value = "0"

        Auditoria(ConfigurationSettings.AppSettings("AUDIT_CON_PAQUETE_3PLAY"), "Consulta Paquetes 3Play.")
    End Sub

'ldrz
    Private Sub Limpiar()
        hidCodigo.Value = String.Empty
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        ddlEstado.SelectedIndex = -1
        ddlEstadoPlan3Play.SelectedValue = "1"

        ddlProductoMod.SelectedIndex = -1
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

'ldrz
    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        hidOrdenPaquete.Value = "0"
        Dim dt As DataTable = oPaquete3PlayNegocios.ListarPaquete3Play(ddlProducto.SelectedValue.ToString(), hidCodigo.Value.ToString(), "%%", ddlEstadoPlan3Play.SelectedValue.ToString())

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                txtCodigo.Text = Convert.ToString(dt.Rows(0)("PAQTV_CODIGO"))
                txtDescripcion.Text = Convert.ToString(dt.Rows(0)("PAQTV_DESCRIPCION"))
                ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("PAQTC_ESTADO"))
                ddlProductoMod.SelectedValue = Convert.ToString(dt.Rows(0)("PRDC_CODIGO")) ''ddlProducto.SelectedValue

                ListarPaquetePlan(Convert.ToString(dt.Rows(0)("PRDC_CODIGO")), Convert.ToString(dt.Rows(0)("PAQTV_CODIGO")))
                ListarPlan(Convert.ToString(dt.Rows(0)("PRDC_CODIGO")), Convert.ToString(dt.Rows(0)("PAQTV_CODIGO")))
            End If
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    End Sub

'ldrz
    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        ListarPaquetePlan(ddlProductoMod.SelectedValue, "0")
        ListarPlan(ddlProductoMod.SelectedValue, "0")
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        hidOrdenPaquete.Value = "0"
        ddlEstado.SelectedValue = "1"
    End Sub

'ldrz
    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim strPrdc_Codigo As String

            strPrdc_Codigo = ddlProducto.SelectedValue.ToString()
            oPaquete3PlayNegocios.EliminarPaquete3Play(strPrdc_Codigo, hidCodigo.Value.ToString(), CurrentUser)

            Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_PAQUETE_3PLAY"), "Desactivar Paquete 3Play (Código: " & hidCodigo.Value & " )")

            btnBuscar_Click(Nothing, Nothing)

    End Sub

'ldrz
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim curSalida As String
        Dim Msg As String
        Dim drw As DataRow
        Dim strPrdc_Codigo As String
        Dim str_constProd3Play As String
        Dim str_constProd3PlayInalambrico As String

        Try
            strPrdc_Codigo = ddlProductoMod.SelectedValue.ToString()
            str_constProd3Play = ConfigurationSettings.AppSettings("constCodProd3Play")
            str_constProd3PlayInalambrico = ConfigurationSettings.AppSettings("constCodProd3PlayInalambrico")

            oPaquete3Play.PAQTV_DESCRIPCION = CheckStr(txtDescripcion.Text).ToUpper
            oPaquete3Play.PAQTC_ESTADO = ddlEstado.SelectedValue.ToString()
            oPaquete3Play.PAQTV_USUARIO_CREA = CurrentUser
            If strPrdc_Codigo = str_constProd3Play Then '''= '05'
            oPaquete3Play.TPAQTV_CODIGO = CheckInt(ConfigurationSettings.AppSettings("CodTipoPaquete3Play"))
            ElseIf strPrdc_Codigo = str_constProd3PlayInalambrico Then   '''08'
                oPaquete3Play.TPAQTV_CODIGO = CheckInt(ConfigurationSettings.AppSettings("CodTipoPaquete3PlayInalabrico"))
            End If

            oPaquete3Play.TPROC_CODIGO = ConfigurationSettings.AppSettings("CodOfertaMasivo")
            oPaquete3Play.PRDC_CODIGO = strPrdc_Codigo    ''ConfigurationSettings.AppSettings("CodTipoProducto3Play")

            dtbKitMaterial = New DataTable
            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable).Clone

            For Each dgi As DataGridItem In dgrKitMaterialDetalle.Items
                drw = dtbKitMaterial.NewRow
                drw("CODIGO_PAQUETE") = "0"
                drw("CODIGO_PLAN") = dgi.Cells(2).Text
                drw("DESCRIPCION_PLAN") = dgi.Cells(3).Text
                drw("ORDEN_PAQUETE") = dgi.Cells(5).Text
                dtbKitMaterial.Rows.Add(drw)
            Next

            dtbKitMaterial.AcceptChanges()

            If hidCodigo.Value.Length = 0 Then
                oPaquete3Play.PAQTV_CODIGO = CheckStr(txtCodigo.Text).ToUpper.ToString
                If oPaquete3PlayNegocios.InsertarPaquete3Play(oPaquete3Play, curSalida, Msg) Then 'Grabar en Paquete
                    GrabarPaquetePlan(curSalida)

                    Auditoria(ConfigurationSettings.AppSettings("AUDIT_INS_PAQUETE_3PLAY"), "Insertar Paquete 3Play (Código: " & txtCodigo.Text & " )")
                End If
            Else
                oPaquete3Play.PAQTV_CODIGO = CheckStr(hidCodigo.Value)
                If oPaquete3PlayNegocios.ActualizarPaquete3Play(oPaquete3Play) Then 'Actualiza en Paquete
                    EliminarPaquetePlan(oPaquete3Play.PAQTV_CODIGO)
                    GrabarPaquetePlan(oPaquete3Play.PAQTV_CODIGO)

                    Auditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_PAQUETE_3PLAY"), "Modificar Servicio 3Play (Código: " & hidCodigo.Value & " )")
                End If
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20660") > -1 And hidCodigo.Value.Length = 0 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('El Código ya se encuentra registrado.')</script>")
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

    Private Sub btnMaterialQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialQuitar.Click
        Dim chk As CheckBox
        Dim drwMaterial As DataRow
        Dim auxContador% = 0

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)

            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            For i As Integer = 0 To dgrKitMaterialDetalle.Items.Count - 1
                chk = DirectCast(dgrKitMaterialDetalle.Items(i).Cells(0).FindControl("chkSD"), CheckBox)

                If chk.Checked Then
                    drwMaterial = dtbMaterial.NewRow
                    drwMaterial("CODIGO_PLAN") = dgrKitMaterialDetalle.Items(i).Cells(2).Text
                    drwMaterial("DESCRIPCION_PLAN") = dgrKitMaterialDetalle.Items(i).Cells(3).Text
                    dtbMaterial.Rows.Add(drwMaterial)

                    dtbKitMaterial.Rows(i).Delete()
                    auxContador = auxContador + 1
                End If
            Next

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)

            Dim aux%
            aux = 0
            For i As Integer = 0 To dgrKitMaterialDetalle.Items.Count - 1
                Dim lblOrdenPaquete As Label
                lblOrdenPaquete = DirectCast(dgrKitMaterialDetalle.Items(i).Cells(4).FindControl("lblOrdenPaquete"), Label)
                lblOrdenPaquete.Text = dgrKitMaterialDetalle.Items(i).Cells(5).Text.Replace("&nbsp;", String.Empty)
                aux = aux + 1
                lblOrdenPaquete.Text = aux.ToString()
            Next
            hidOrdenPaquete.Value = aux.ToString()

            If hidCodigo.Value.ToString() = "" Or hidCodigo.Value.ToString() = "0" Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
            End If

            If auxContador = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub

    Private Sub btnMaterialAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialAgregar.Click
        Dim chk As CheckBox
        Dim drwKitMaterial As DataRow
        Dim aux%
        Dim auxContador% = 0

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)

            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            aux = Convert.ToInt32(hidOrdenPaquete.Value)
            For i As Integer = 0 To dgrMaterialDetalle.Items.Count - 1
                chk = DirectCast(dgrMaterialDetalle.Items(i).Cells(0).FindControl("chkMD"), CheckBox)

                If chk.Checked Then
                    drwKitMaterial = dtbKitMaterial.NewRow
                    drwKitMaterial("CODIGO_PLAN") = dgrMaterialDetalle.Items(i).Cells(1).Text
                    drwKitMaterial("DESCRIPCION_PLAN") = dgrMaterialDetalle.Items(i).Cells(2).Text
                    aux = aux + 1
                    drwKitMaterial("ORDEN_PAQUETE") = aux.ToString()

                    dtbKitMaterial.Rows.Add(drwKitMaterial)
                    dtbMaterial.Rows(i).Delete()
                    auxContador = auxContador + 1
                End If
            Next
            hidOrdenPaquete.Value = aux.ToString()

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)
            If hidCodigo.Value.ToString() = "" Or hidCodigo.Value.ToString() = "0" Then
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
            End If

            If auxContador = 0 Then
                RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            End If

    End Sub

    Private Function GuardarCantidades(ByVal pdtbKitMaterial As DataTable) As DataTable
        Dim drw As DataRow
        pdtbKitMaterial.Rows.Clear()
        pdtbKitMaterial.AcceptChanges()
        Dim i% = 0
        Dim orden$
        For Each dgi As DataGridItem In dgrKitMaterialDetalle.Items
            drw = pdtbKitMaterial.NewRow
            drw("CODIGO_PAQUETE") = "0"
            drw("CODIGO_PLAN") = dgi.Cells(2).Text
            drw("DESCRIPCION_PLAN") = dgi.Cells(3).Text
            orden = dgi.Cells(5).Text 'dato no confiable
            i = i + 1
            drw("ORDEN_PAQUETE") = i.ToString()
            pdtbKitMaterial.Rows.Add(drw)
        Next

        pdtbKitMaterial.AcceptChanges()

        Return pdtbKitMaterial
    End Function

    Private Sub EnlazarGrillaMaterial(ByVal pdtbKitMaterial As DataTable, ByVal pdtbMaterial As DataTable)
        dgrKitMaterialDetalle.DataSource = pdtbKitMaterial
        dgrKitMaterialDetalle.DataBind()

        dgrMaterialDetalle.DataSource = pdtbMaterial
        dgrMaterialDetalle.DataBind()

        DirectCast(dgrKitMaterialCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalSD"), CheckBox).Checked = False
        DirectCast(dgrMaterialCabecera.Controls(0).Controls(0).Controls(0).FindControl("chkTotalMD"), CheckBox).Checked = False
    End Sub

    Private Sub dgrKitMaterialDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrKitMaterialDetalle.ItemDataBound
        Dim lblOrdenPaquete As Label
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            lblOrdenPaquete = DirectCast(e.Item.Cells(4).FindControl("lblOrdenPaquete"), Label)
            lblOrdenPaquete.Text = e.Item.Cells(5).Text.Replace("&nbsp;", String.Empty)
        End If
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            If Not ddlEstadoPlan3Play.SelectedValue.ToString() = "1" Then
                e.Item.Cells(4).Text = ""
            End If
        End If
    End Sub

'ldrz
    Private Sub Buscar()
        Dim strDescripcion As String = txtBusDescripcion.Text.Trim
        Dim strProducto As String

        strProducto = ddlProducto.SelectedValue         'maquino
        If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()

            dgrGrillaDetalle.DataSource = ListarPaquete3Play(strProducto, strDescripcion)
            dgrGrillaDetalle.DataBind()
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

#Region "METODOS MANTE 3PLAY"

    'ldrz
Private Function ListarPaquete3Play(ByVal pstrProducto As String, ByVal strDescripcion As String) As DataTable
        Dim dt As New DataTable
        Dim descripcion As String
        descripcion = "%" & RTrim(strDescripcion) & "%"
        dt = oPaquete3PlayNegocios.ListarPaquete3Play(pstrProducto, "0", descripcion, ddlEstadoPlan3Play.SelectedValue.ToString())
        Return dt
    End Function

'ldrz
    Private Sub CargarPagina()
        hidOrdenPaquete.Value = "0"
        LlenarProducto()
        LlenarProductoMod()
        Dim dt As New DataTable
        dt = (New LEquipos3Play).fdtbListarEstadoEquipos("2")
        If Not dt Is Nothing Then
            ddlEstado.DataSource = dt
            ddlEstado.DataValueField = "ITEMN_CODIGO"
            ddlEstado.DataTextField = "ITEMN_DESCRIPCION"
            ddlEstado.DataBind()
        End If

    End Sub

'ldrz
    Private Sub ListarPlan(ByVal strProducto As String, ByVal CodigoPlan As String)
        dtbMaterial = New DataTable
        dtbMaterial = oPlan3PlayNegocios.ListarPlanPaquete3Play(strProducto, CodigoPlan)

        dgrMaterialDetalle.DataSource = dtbMaterial
        dgrMaterialDetalle.DataBind()
        ViewState("dtbMaterial") = dtbMaterial
    End Sub

'ldrz
Private Sub ListarPaquetePlan(ByVal strProducto As String, ByVal CodigoPaquete As String)
        dtbKitMaterial = New DataTable
        dtbKitMaterial = oPaquetePlan3PlayNegocios.ListarPaquetePlan3Play(strProducto, CodigoPaquete)
        dgrKitMaterialDetalle.DataSource = dtbKitMaterial
        dgrKitMaterialDetalle.DataBind()
        ViewState("dtbKitMaterial") = dtbKitMaterial

        If (hidCodigo.Value <> "0") Then
            Dim i, orden, ordenAux As Integer
            orden = Convert.ToInt32(Me.hidOrdenPaquete.Value)

            For i = 0 To dgrKitMaterialDetalle.Items.Count - 1
                ordenAux = Convert.ToInt32(dgrKitMaterialDetalle.Items(i).Cells(5).Text)
                If ordenAux > orden Then
                    orden = ordenAux
                End If
            Next

            If i > 0 Then
                hidOrdenPaquete.Value = ordenAux.ToString()
            End If

        End If
    End Sub

'ldrz
    Private Sub GrabarPaquetePlan(ByVal CodigoPaquete As String)
        Dim CodigoPlan, Orden, CodigoCadena As String
        Dim lblOrdenPaquete As Label
        Dim strPrdc_Codigo As String
        Dim i% = 0

        For Each dgi As DataGridItem In dgrKitMaterialDetalle.Items
            CodigoPlan = dgi.Cells(2).Text & "|" 'Codigo de Plan
            'Orden = dgi.Cells(5).Text ' Orden -- dato no confiable
            lblOrdenPaquete = DirectCast(dgrKitMaterialDetalle.Items(i).Cells(4).FindControl("lblOrdenPaquete"), Label)
            Orden = lblOrdenPaquete.Text
            CodigoCadena = CodigoCadena & Orden & "," & CodigoPlan
            i = i + 1
        Next

        If CodigoCadena <> "" Then
            CodigoCadena = Left(CodigoCadena, CodigoCadena.Length - 1)
            strPrdc_Codigo = ddlProductoMod.SelectedValue

            oPaquetePlan3Play.PRDC_CODIGO = strPrdc_Codigo
            oPaquetePlan3Play.PAQTV_CODIGO = CodigoPaquete
            oPaquetePlan3Play.PAQUETE_PLAN = CodigoCadena
            oPaquetePlan3Play.PAQPV_USUARIO_CREA = CurrentUser
            oPaquetePlan3PlayNegocios.InsertarPaqueteDetalle3Play(oPaquetePlan3Play)
        End If

    End Sub

'ldrz
    Private Sub EliminarPaquetePlan(ByVal CodigoPaquete As String)
        Dim strPrdc_Codigo As String

        strPrdc_Codigo = ddlProductoMod.SelectedValue
        oPaquetePlan3PlayNegocios.EliminarPaquetePlan3Play(strPrdc_Codigo, CodigoPaquete)
    End Sub

#End Region

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

'ldrz
    Private Sub ddlProductoMod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProductoMod.SelectedIndexChanged
        ListarPlan(ddlProductoMod.SelectedValue, "0")

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")

    End Sub

   'maquino, ldrz
    Private Sub LlenarProducto()
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Dim strCodProd As String

        Try
            objLServicio3Play = New LServicio3Play
            ddlProducto.DataValueField = "PRDC_CODIGO"
            ddlProducto.DataTextField = "PRDV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarProductos()

            strCodProd = ConfigurationSettings.AppSettings("constProd3Play")
            Dim dv As New DataView(dt)
            dv.RowFilter = "PRDC_CODIGO IN " & strCodProd

            ddlProducto.DataSource = dv ''dt
            ddlProducto.DataBind()
            ddlProducto.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlProducto.SelectedIndex = 0

        Catch ex As Exception
            'RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            'oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Inicio  :::::::::::::")
            'oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            'oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            'oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub

'ldrz
 Private Sub LlenarProductoMod()
        Dim objLServicio3Play As LServicio3Play
        Dim dt As New DataTable
        Dim strCodProd As String

        Try
            objLServicio3Play = New LServicio3Play
            ddlProductoMod.DataValueField = "PRDC_CODIGO"
            ddlProductoMod.DataTextField = "PRDV_DESCRIPCION"
            dt = objLServicio3Play.fdtbListarProductos()

            strCodProd = ConfigurationSettings.AppSettings("constProd3Play")
            Dim dv As New DataView(dt)
            dv.RowFilter = "PRDC_CODIGO IN " & strCodProd

            ddlProductoMod.DataSource = dv ''dt
            ddlProductoMod.DataBind()
            ddlProductoMod.Items.Insert(0, New ListItem("SELECCIONAR", ""))
            ddlProductoMod.SelectedIndex = 0

        Catch ex As Exception
            'RegisterStartupScript("script1", "<script>alert('Debe seleccionar al menos un registro.')</script>")
            'oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Inicio  :::::::::::::")
            'oLog.Log_WriteLog(oFile, "Mensaje: " & ex.Message.ToString())
            'oLog.Log_WriteLog(oFile, "Detalle Tecnico: " & ex.StackTrace.ToString())
            'oLog.Log_WriteLog(oFile, ":::::::::::::  Error LlenarProducto - Fin :::::::::::::")
        Finally
            objLServicio3Play = Nothing
        End Try
    End Sub

End Class
