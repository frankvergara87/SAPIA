Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios

Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones

Public Class sisact_pop_cargarTopeConsumo
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnCerrar As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents btnMarcarServer As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEliminarServer As System.Web.UI.WebControls.Button
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlPlan As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgTope As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEliminarTodosServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptarServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnValidarServer As System.Web.UI.WebControls.Button
    Protected WithEvents btnActualizarServer As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim CE_TIPO_ITEM_TOPE As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_TIPO_ITEM_TOPE"))
    Dim CE_ET_SELECCIONADO As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ET_SELECCIONADO"))
    Dim CE_ET_SELECCIONADOEDITABLE As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ET_SELECCIONADOEDITABLE"))
    Dim CE_ESTADO_TOPE As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_ESTADO_TOPE"))

    Private ent As New CasoEspecial
    Private obj As New CasoEspecialNegocios

    Private Sub CargarCombos()
        If Not Session("Planes") Is Nothing Then
            Dim DtPlan As DataTable = CType(Session("Planes"), DataTable)
            Dim Dt As New DataTable
            Dt.Columns.Add("IdPlan", GetType(String))
            Dt.Columns.Add("Plan", GetType(String))
            For Each Dr As DataRow In DtPlan.Rows
                Dim Filtro As String = ""
                Filtro = Filtro + "IdPlan= '" + Convert.ToString(Dr("IdPlan")) + "' "
                Dim ArrDr() As DataRow = Dt.Select(Filtro)
                If ArrDr.Length = 0 Then
                    Dim Fila As DataRow = Dt.NewRow
                    Fila("IdPlan") = Convert.ToString(Dr("IdPlan"))
                    Fila("Plan") = Convert.ToString(Dr("Plan"))
                    Dt.Rows.Add(Fila)
                End If
            Next
            Call Comunes.LlenarComboOrdenado(Me.ddlPlan, Dt, "IdPlan", "Plan")
        End If
    End Sub

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
            Call CargarCombos()
            Call LlenarGrilla()
            Me.btnCerrar.Attributes.Add("onclick", "return f_CerrarVentana();")
            Me.btnAceptar.Attributes.Add("onclick", "return f_Validar();")
            RegisterStartupScript("script", "<script>document.getElementById('" & Me.ddlPlan.ClientID & "').focus();</script>")
        Else
            Me.hidCondicion.Value = Nothing
        End If
    End Sub

    Private Sub LlenarGrilla()
        Call LLenarDataGrid(Me.dgTope, obj.ListarTopeConsumo(CE_ESTADO_TOPE))
    End Sub

    Private Sub dgTope_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTope.ItemDataBound
        Dim ddlEstadoTope As DropDownList
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ValorSeleccionado As String = ""
            ddlEstadoTope = DirectCast(e.Item.Cells(2).FindControl("ddlEstadoTope"), DropDownList)
            Call ListarComboConsumo(ddlEstadoTope, ValorSeleccionado)
        End If
    End Sub

    Private Sub ListarComboConsumo(ByVal ddlConsumoEstado As DropDownList, ByVal ValorSeleccionado As String)
        Call LlenarCombo(ddlConsumoEstado, obj.ListarEstadoTope(CE_TIPO_ITEM_TOPE), "ITEMN_CODIGO", "ITEMN_DESCRIPCION")
        If Not ValorSeleccionado Is System.DBNull.Value And ValorSeleccionado <> String.Empty Then
            ddlConsumoEstado.SelectedValue = ValorSeleccionado
        End If
        ddlConsumoEstado.DataBind()
    End Sub

    Private Sub btnValidarServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidarServer.Click
        If Me.ddlPlan.SelectedIndex = 0 Then
            RegisterStartupScript("script", "<script>alert('Seleccione el Plan'); document.getElementById('" & Me.ddlPlan.ClientID & "').focus();</script>")
            Exit Sub
        End If

        If Not Session("TopeConsumo") Is Nothing Then
            Dim Dt As DataTable = CType(Session("TopeConsumo"), DataTable)
            If Dt Is Nothing Then
                Dt = New DataTable
                Dt.Columns.Add("IdPlan", GetType(String))
                Dt.Columns.Add("Plan", GetType(String))
                Dt.Columns.Add("IdTopeConsumo", GetType(Integer))
                Dt.Columns.Add("TopeConsumo", GetType(String))
                Dt.Columns.Add("IdEstadoTope", GetType(String))
                Dt.Columns.Add("EstadoTope", GetType(String))
            End If
            Dim IdPlan As String = Me.ddlPlan.SelectedItem.Value.ToString()

            Dim Contador As Integer = 0
            Dim Repetidos As Integer = 0
            For Each Item As DataGridItem In Me.dgTope.Items
                Dim IdTopeConsumo As Integer = Funciones.CheckInt(Item.Cells(0).Text.ToString())
                Dim ddlEstadoConsumo As DropDownList = DirectCast(Item.Cells(2).FindControl("ddlEstadoTope"), DropDownList)
                Dim IdEstadoTope As String = ddlEstadoConsumo.SelectedItem.Value.ToString()

                If IdEstadoTope = CE_ET_SELECCIONADO Or IdEstadoTope = CE_ET_SELECCIONADOEDITABLE Then
                    Contador = Contador + 1
                End If

                Dim Filtro As String = ""
                Filtro = Filtro + "IdPlan= '" + IdPlan + "' and "
                Filtro = Filtro + "IdTopeConsumo= " + IdTopeConsumo.ToString() + " "

                Dim ArrDr() As DataRow = Dt.Select(Filtro)
                If ArrDr.Length > 0 Then
                    Repetidos = Repetidos + 1
                End If
            Next

            If Contador > 1 Then
                RegisterStartupScript("script", "<script>alert('Solo Puede Haber una opción de Estado Tope (SELECCIONADO O SELECCIONADO EDITABLE) por PLAN, Verifique');</script>")
                Exit Sub
            End If

            If Repetidos > 0 Then
                RegisterStartupScript("script", "<script>f_Actualizar();</script>")
                Exit Sub
            Else
                RegisterStartupScript("script", "<script>f_Aceptar();</script>")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnActualizarServer_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarServer.Click
        If Not Session("TopeConsumo") Is Nothing Then
            Dim Dt As DataTable = CType(Session("TopeConsumo"), DataTable)
            Dim IdPlan As String = Me.ddlPlan.SelectedItem.Value.ToString()
            Dim Plan As String = Me.ddlPlan.SelectedItem.Text.ToString()

            For Each Item As DataGridItem In Me.dgTope.Items
                Dim IdTopeConsumo As Integer = Funciones.CheckInt(Item.Cells(0).Text.ToString())
                Dim TopeConsumo As String = Item.Cells(1).Text.ToString()
                Dim ddlEstadoConsumo As DropDownList = DirectCast(Item.Cells(2).FindControl("ddlEstadoTope"), DropDownList)
                Dim IdEstadoTope As String = ddlEstadoConsumo.SelectedItem.Value.ToString()
                Dim EstadoTope As String = ddlEstadoConsumo.SelectedItem.Text.ToString()

                Dim Filtro As String = ""
                Filtro = Filtro + "IdPlan= '" + IdPlan + "' and "
                Filtro = Filtro + "IdTopeConsumo= " + IdTopeConsumo.ToString() + " "

                Dim ArrDr() As DataRow = Dt.Select(Filtro)
                If ArrDr.Length > 0 Then
                    For Each Dr As DataRow In ArrDr
                        Dt.Rows.Remove(Dr)
                    Next
                End If
            Next

            For Each Item As DataGridItem In Me.dgTope.Items
                Dim IdTopeConsumo As Integer = Funciones.CheckInt(Item.Cells(0).Text.ToString())
                Dim TopeConsumo As String = Item.Cells(1).Text.ToString()
                Dim ddlEstadoConsumo As DropDownList = DirectCast(Item.Cells(2).FindControl("ddlEstadoTope"), DropDownList)
                Dim IdEstadoTope As String = ddlEstadoConsumo.SelectedItem.Value.ToString()
                Dim EstadoTope As String = ddlEstadoConsumo.SelectedItem.Text.ToString()
                Dim Fila As DataRow = Dt.NewRow
                Fila("IdPlan") = IdPlan
                Fila("Plan") = Plan
                Fila("IdTopeConsumo") = IdTopeConsumo
                Fila("TopeConsumo") = TopeConsumo
                Fila("IdEstadoTope") = IdEstadoTope
                Fila("EstadoTope") = EstadoTope
                Dt.Rows.Add(Fila)
            Next

            'Dim Dv As New DataView(Dt, "", "Plan,TopeConsumo Asc", DataViewRowState.CurrentRows)
            'Dt = Dv.Table

            Dim Tabla As DataTable = Dt.Clone
            Dim Ordenacion As String = "Plan,TopeConsumo Asc"
            Dim Rows() As DataRow = Dt.Select("", Ordenacion)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = Tabla.NewRow
                Row("IdPlan") = Funciones.CheckStr(Dr("IdPlan"))
                Row("Plan") = Funciones.CheckStr(Dr("Plan"))
                Row("IdTopeConsumo") = Funciones.CheckStr(Dr("IdTopeConsumo"))
                Row("TopeConsumo") = Funciones.CheckStr(Dr("TopeConsumo"))
                Row("IdEstadoTope") = Funciones.CheckStr(Dr("IdEstadoTope"))
                Row("EstadoTope") = Funciones.CheckStr(Dr("EstadoTope"))
                Tabla.Rows.Add(Row)
            Next
            Session("TopeConsumo") = Nothing
            Session("TopeConsumo") = Tabla
            Tabla.Dispose()
            RegisterStartupScript("script", "<script>llamarPadre();</script>")
        End If
    End Sub

    Private Sub btnAceptarServer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarServer.Click
        If Not Session("TopeConsumo") Is Nothing Then
            Dim Dt As DataTable = CType(Session("TopeConsumo"), DataTable)
            Dim IdPlan As String = Me.ddlPlan.SelectedItem.Value.ToString()
            Dim Plan As String = Me.ddlPlan.SelectedItem.Text.ToString()

            For Each Item As DataGridItem In Me.dgTope.Items
                Dim IdTopeConsumo As Integer = Funciones.CheckInt(Item.Cells(0).Text.ToString())
                Dim TopeConsumo As String = Item.Cells(1).Text.ToString()
                Dim ddlEstadoConsumo As DropDownList = DirectCast(Item.Cells(2).FindControl("ddlEstadoTope"), DropDownList)
                Dim IdEstadoTope As String = ddlEstadoConsumo.SelectedItem.Value.ToString()
                Dim EstadoTope As String = ddlEstadoConsumo.SelectedItem.Text.ToString()
                Dim Fila As DataRow = Dt.NewRow
                Fila("IdPlan") = IdPlan
                Fila("Plan") = Plan
                Fila("IdTopeConsumo") = IdTopeConsumo
                Fila("TopeConsumo") = TopeConsumo
                Fila("IdEstadoTope") = IdEstadoTope
                Fila("EstadoTope") = EstadoTope
                Dt.Rows.Add(Fila)
            Next

            'Dim Dv As New DataView(Dt, "", "Plan,TopeConsumo Asc", DataViewRowState.CurrentRows)
            'Dt = Dv.Table

            Dim Tabla As DataTable = Dt.Clone
            Dim Ordenacion As String = "Plan,TopeConsumo Asc"
            Dim Rows() As DataRow = Dt.Select("", Ordenacion)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = Tabla.NewRow
                Row("IdPlan") = Funciones.CheckStr(Dr("IdPlan"))
                Row("Plan") = Funciones.CheckStr(Dr("Plan"))
                Row("IdTopeConsumo") = Funciones.CheckStr(Dr("IdTopeConsumo"))
                Row("TopeConsumo") = Funciones.CheckStr(Dr("TopeConsumo"))
                Row("IdEstadoTope") = Funciones.CheckStr(Dr("IdEstadoTope"))
                Row("EstadoTope") = Funciones.CheckStr(Dr("EstadoTope"))
                Tabla.Rows.Add(Row)
            Next
            Session("TopeConsumo") = Nothing
            Session("TopeConsumo") = Tabla
            Tabla.Dispose()
            RegisterStartupScript("script", "<script>llamarPadre();</script>")
        End If
    End Sub
End Class
