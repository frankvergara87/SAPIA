Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_kits
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
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgrKitMaterialCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrKitMaterialDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrMaterialCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrMaterialDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnMaterialQuitar As System.Web.UI.WebControls.Button
    Protected WithEvents btnMaterialAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents txtMonto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCostoInstalacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlTipoOperacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipo As System.Web.UI.WebControls.DropDownList

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim dtbKitMaterial As DataTable
    Dim dtbMaterial As DataTable

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
            Dim objLKit As LKit

                objLKit = New LKit

                dgrKitMaterialCabecera.DataSource = ""
                dgrKitMaterialCabecera.DataBind()

                dgrMaterialCabecera.DataSource = ""
                dgrMaterialCabecera.DataBind()

                ddlTipo.DataValueField = "prmtn_codigo_param"
                ddlTipo.DataTextField = "prmtv_descripcion"
                ddlTipo.DataSource = objLKit.fdtbListarTipo
                ddlTipo.DataBind()

                ddlTipoOperacion.DataValueField = "TOPEN_CODIGO"
                ddlTipoOperacion.DataTextField = "TOPEV_DESCRIPCION"
                ddlTipoOperacion.DataSource = objLKit.ListarTipoOperacion()
                ddlTipoOperacion.DataBind()

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
    
            hidCodigo.Value = String.Empty
            txtCodigo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            ddlEstado.SelectedIndex = -1
            ddlTipo.SelectedIndex = -1
            ddlTipoOperacion.SelectedIndex = -1
            txtMonto.Text = String.Empty
            'gaa20120517
            txtCostoInstalacion.Text = String.Empty
            'fin gaa20120517

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLKit As LKit
        Dim dt As DataTable

            objLKit = New LKit
            dt = New DataTable

            dt = objLKit.fdtbTraer(hidCodigo.Value)

            txtCodigo.Text = Convert.ToString(dt.Rows(0)("kitv_codigo"))
            txtDescripcion.Text = Convert.ToString(dt.Rows(0)("kitv_descripcion"))
            ddlTipo.SelectedValue = Convert.ToString(dt.Rows(0)("tkitc_codigo")).Trim
            ddlTipoOperacion.SelectedValue = Convert.ToString(dt.Rows(0)("TIPO_OPERACION")).Trim
            txtMonto.Text = Convert.ToString(dt.Rows(0)("kitn_precio_base")).Trim
            txtCostoInstalacion.Text = Convert.ToString(dt.Rows(0)("kitn_costo_inst")).Trim
            ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("kitc_estado"))

            objLKit = New LKit
            dtbKitMaterial = New DataTable
            dtbKitMaterial = objLKit.fdtbListarKitEquipo(hidCodigo.Value)
            dgrKitMaterialDetalle.DataSource = dtbKitMaterial
            dgrKitMaterialDetalle.DataBind()

            ViewState("dtbKitMaterial") = dtbKitMaterial

            objLKit = New LKit
            dtbMaterial = New DataTable
            dtbMaterial = objLKit.fdtbListarEquipoSinKit(hidCodigo.Value)
            dgrMaterialDetalle.DataSource = dtbMaterial
            dgrMaterialDetalle.DataBind()

            ViewState("dtbMaterial") = dtbMaterial

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
   
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Dim objLKit As LKit

            Limpiar()

            objLKit = New LKit
            dtbKitMaterial = New DataTable
            dtbKitMaterial = objLKit.fdtbListarKitEquipo(String.Empty)
            dgrKitMaterialDetalle.DataSource = dtbKitMaterial
            dgrKitMaterialDetalle.DataBind()

            ViewState("dtbKitMaterial") = dtbKitMaterial

            objLKit = New LKit
            dtbMaterial = New DataTable
            dtbMaterial = objLKit.fdtbListarEquipoSinKit(String.Empty)
            dgrMaterialDetalle.DataSource = dtbMaterial
            dgrMaterialDetalle.DataBind()

            ViewState("dtbMaterial") = dtbMaterial

            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")

    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLKit As LKit
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean

            objLKit = New LKit
            objLKit.fbooEliminar(hidCodigo.Value, CurrentUser, curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantKitDTH_Eliminar"), "Eliminar Kit DTH")
            btnBuscar_Click(Nothing, Nothing)
 
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLKit As LKit
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim sngMonto As Single = 0
        'gaa20120517
        Dim sngCosto As Single = 0
        'fin gaa20120517
        Dim strIddet As String = "0"
        Dim strCantidad As String = "0"
        Dim intRepetido As Integer = 0
        Dim drw As DataRow

        Try
            strDescripcion = txtDescripcion.Text.Trim.ToUpper
            sngMonto = Convert.ToSingle(txtMonto.Text)
            'gaa20120517
            sngCosto = Convert.ToSingle(txtCostoInstalacion.Text)
            'fin gaa20120517

            dtbKitMaterial = New DataTable
            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable).Clone

            For Each dgi As DataGridItem In dgrKitMaterialDetalle.Items
                strIddet = DirectCast(dgi.Cells(5).FindControl("txtCargoFijo"), TextBox).Text()
                strCantidad = DirectCast(dgi.Cells(6).FindControl("txtCantidad"), TextBox).Text()
                If Not IsNumeric(strIddet) Then strIddet = "0"
                strCantidad = CheckInt(strCantidad).ToString
                'gaa20120518:Validacion de iddets repetidos
                For Each dgi1 As DataGridItem In dgrKitMaterialDetalle.Items
                    If strIddet = DirectCast(dgi1.Cells(5).FindControl("txtCargoFijo"), TextBox).Text() Then
                        intRepetido += 1
                    End If

                    If intRepetido > 1 Then
                        RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('El iddet " & strIddet & " se encuentra mas de una vez.')</script>")
                        Exit Sub
                    End If
                Next
                'fin gaa20120518
                drw = dtbKitMaterial.NewRow
                drw("kitv_codigo") = 0
                drw("keqv_codigo") = dgi.Cells(2).Text
                drw("matv_iddet") = strIddet
                drw("keqn_cantidad") = strCantidad
                dtbKitMaterial.Rows.Add(drw)
                'gaa20120518
                intRepetido = 0
                'fin gaa20120518
            Next

            dtbKitMaterial.AcceptChanges()

            'gaa20120223
            Dim strUsuario As String = CurrentUser
            'fin gaa20120223

            objLKit = New LKit

            If hidCodigo.Value.Length = 0 Then
                'gaa20120517
                'objLKit.fbooInsertar(strDescripcion, ddlTipo.SelectedValue, sngMonto, ddlEstado.SelectedValue, _
                '    strUsuario, dtbKitMaterial, curSalida, Msg)
                objLKit.fbooInsertar(strDescripcion, ddlTipo.SelectedValue, ddlTipoOperacion.SelectedValue, sngMonto, sngCosto, _
                    ddlEstado.SelectedValue, strUsuario, dtbKitMaterial, curSalida, Msg)
                'fin gaa20120517
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantKitDTH_Insertar"), "Insertar Kit DTH")
            Else
                'gaa20120517
                'objLKit.fbooModificar(hidCodigo.Value, strDescripcion, ddlTipo.SelectedValue, sngMonto, ddlEstado.SelectedValue, _
                '    strUsuario, dtbKitMaterial, curSalida, Msg)
                objLKit.fbooModificar(hidCodigo.Value, strDescripcion, ddlTipo.SelectedValue, ddlTipoOperacion.SelectedValue, sngMonto, sngCosto, _
                    ddlEstado.SelectedValue, strUsuario, dtbKitMaterial, curSalida, Msg)
                'gaa20120517
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantKitDTH_Modificar"), "Modificar Kit DTH")
            End If

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

    Private Sub btnMaterialQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialQuitar.Click
        Dim chk As CheckBox
        Dim drwMaterial As DataRow

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)

            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            For i As Integer = 0 To dgrKitMaterialDetalle.Items.Count - 1
                chk = DirectCast(dgrKitMaterialDetalle.Items(i).Cells(0).FindControl("chkSD"), CheckBox)

                If chk.Checked Then
                    'drwMaterial = dtbMaterial.NewRow
                    'drwMaterial("matv_codigo") = dgrKitMaterialDetalle.Items(i).Cells(2).Text
                    'drwMaterial("matv_descripcion") = dgrKitMaterialDetalle.Items(i).Cells(3).Text
                    'dtbMaterial.Rows.Add(drwMaterial)

                    dtbKitMaterial.Rows(i).Delete()
                End If
            Next

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")

    End Sub

    Private Sub btnMaterialAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterialAgregar.Click
        Dim chk As CheckBox
        Dim drwKitMaterial As DataRow

            dtbKitMaterial = DirectCast(ViewState("dtbKitMaterial"), DataTable)
            dtbMaterial = DirectCast(ViewState("dtbMaterial"), DataTable)

            dtbKitMaterial = GuardarCantidades(dtbKitMaterial)

            For i As Integer = 0 To dgrMaterialDetalle.Items.Count - 1
                chk = DirectCast(dgrMaterialDetalle.Items(i).Cells(0).FindControl("chkMD"), CheckBox)

                If chk.Checked Then
                    drwKitMaterial = dtbKitMaterial.NewRow
                    drwKitMaterial("keqv_codigo") = dgrMaterialDetalle.Items(i).Cells(1).Text
                    drwKitMaterial("matv_descripcion") = dgrMaterialDetalle.Items(i).Cells(2).Text
                    dtbKitMaterial.Rows.Add(drwKitMaterial)

                    'dtbMaterial.Rows(i).Delete()
                End If
            Next

            dtbKitMaterial.AcceptChanges()
            dtbMaterial.AcceptChanges()

            ViewState("dtbKitMaterial") = dtbKitMaterial
            ViewState("dtbMaterial") = dtbMaterial

            EnlazarGrillaMaterial(dtbKitMaterial, dtbMaterial)

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")

    End Sub

    Private Function GuardarCantidades(ByVal pdtbKitMaterial As DataTable) As DataTable
        Dim txt As TextBox
        Dim strIddet As String = "0"
        Dim strCantidad As String = "0"
        Dim drw As DataRow
        pdtbKitMaterial.Rows.Clear()
        pdtbKitMaterial.AcceptChanges()

        For Each dgi As DataGridItem In dgrKitMaterialDetalle.Items
            strIddet = DirectCast(dgi.Cells(5).FindControl("txtCargoFijo"), TextBox).Text
            strCantidad = DirectCast(dgi.Cells(6).FindControl("txtCantidad"), TextBox).Text
            If Not IsNumeric(strIddet) Then strIddet = "0"
            strCantidad = CheckInt(strCantidad).ToString

            drw = pdtbKitMaterial.NewRow
            drw("kitv_codigo") = 0
            drw("keqv_codigo") = dgi.Cells(2).Text
            drw("matv_descripcion") = dgi.Cells(3).Text
            drw("matv_iddet") = strIddet
            drw("keqn_cantidad") = strCantidad
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
        Dim txtCargoFijo As TextBox
        Dim txtCantidad As TextBox

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            txtCargoFijo = DirectCast(e.Item.Cells(5).FindControl("txtCargoFijo"), TextBox)
            txtCargoFijo.Text = e.Item.Cells(4).Text.Replace("&nbsp;", String.Empty)
            txtCantidad = DirectCast(e.Item.Cells(7).FindControl("txtCantidad"), TextBox)
            txtCantidad.Text = e.Item.Cells(6).Text.Replace("&nbsp;", String.Empty)
        End If
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objLKit As LKit
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLKit = New LKit

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLKit.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantKitDTH_Consulta"), "Consulta Kit DTH")
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
End Class
