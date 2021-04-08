Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Public Class sisact_mant_buro_crediticio_config
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgDocumento2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgDocumento3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgDocumento4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEditar2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnGrabar2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditar3 As System.Web.UI.WebControls.Button
    Protected WithEvents btnGrabar3 As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditar4 As System.Web.UI.WebControls.Button
    Protected WithEvents btnGrabar4 As System.Web.UI.WebControls.Button
    Protected WithEvents btnGrabar1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnEditar1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents dgDocumento1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnCancelar2 As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar3 As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar4 As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region
    Dim ddl As DropDownList
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

        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            ListarDocumento()
        End If
    End Sub

    Sub ListarDocumento()
        Dim strDocumento As String = ddlDocumento.SelectedValue
        listarBuro(strDocumento)
        Dim dt As DataTable = listarBuroConfig(strDocumento)

        Dim array1 As New ArrayList
        Dim array2 As New ArrayList
        Dim array3 As New ArrayList
        Dim array4 As New ArrayList
        For i As Integer = 0 To dt.Rows.Count - 76
            array1.Add(New ListItem(dt.Rows(i)(0), dt.Rows(i)(1)))
        Next
        dgDocumento1.DataSource = array1
        dgDocumento1.DataBind()

        For x As Integer = 25 To dt.Rows.Count - 51
            array2.Add(New ListItem(dt.Rows(x)(0), dt.Rows(x)(1)))
        Next
        dgDocumento2.DataSource = array2
        dgDocumento2.DataBind()

        For y As Integer = 50 To dt.Rows.Count - 26
            array3.Add(New ListItem(dt.Rows(y)(0), dt.Rows(y)(1)))
        Next
        dgDocumento3.DataSource = array3
        dgDocumento3.DataBind()

        For z As Integer = 75 To dt.Rows.Count - 1
            array4.Add(New ListItem(dt.Rows(z)(0), dt.Rows(z)(1)))
        Next
        dgDocumento4.DataSource = array4
        dgDocumento4.DataBind()
    End Sub

    Private Sub btnEditar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar1.Click
        btnEditar1.Visible = False
        btnCancelar.Visible = True
        btnGrabar1.Enabled = True
        btnEditar2.Enabled = False
        btnEditar3.Enabled = False
        btnEditar4.Enabled = False
        ddlDocumento.Enabled = False

        For Each dgi As DataGridItem In dgDocumento1.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro"), DropDownList)
            ddl.Enabled = True
        Next
    End Sub

    Private Sub btnEditar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar2.Click
        btnEditar2.Visible = False
        btnCancelar2.Visible = True
        btnGrabar2.Enabled = True
        btnEditar1.Enabled = False
        btnEditar3.Enabled = False
        btnEditar4.Enabled = False
        ddlDocumento.Enabled = False
        For Each dgi As DataGridItem In dgDocumento2.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro1"), DropDownList)
            ddl.Enabled = True
        Next
    End Sub

    Private Sub btnEditar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar3.Click
        btnEditar3.Visible = False
        btnCancelar3.Visible = True
        btnGrabar3.Enabled = True
        btnEditar1.Enabled = False
        btnEditar2.Enabled = False
        btnEditar4.Enabled = False
        ddlDocumento.Enabled = False
        For Each dgi As DataGridItem In dgDocumento3.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro2"), DropDownList)
            ddl.Enabled = True
        Next
    End Sub

    Private Sub btnEditar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar4.Click
        btnEditar4.Visible = False
        btnCancelar4.Visible = True
        btnGrabar4.Enabled = True
        btnEditar1.Enabled = False
        btnEditar2.Enabled = False
        btnEditar3.Enabled = False
        ddlDocumento.Enabled = False
        For Each dgi As DataGridItem In dgDocumento4.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro3"), DropDownList)
            ddl.Enabled = True
        Next
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        For Each dgi As DataGridItem In dgDocumento1.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro"), DropDownList)
            ddl.Enabled = False
        Next
        btnEditar1.Visible = True
        btnCancelar.Visible = False
        btnEditar2.Enabled = True
        btnEditar3.Enabled = True
        btnEditar4.Enabled = True
        btnGrabar1.Enabled = False
        ddlDocumento.Enabled = True
        ListarDocumento()
    End Sub

    Private Sub btnCancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar2.Click
        For Each dgi As DataGridItem In dgDocumento2.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro1"), DropDownList)
            ddl.Enabled = False
        Next
        btnEditar2.Visible = True
        btnCancelar2.Visible = False
        btnEditar1.Enabled = True
        btnEditar3.Enabled = True
        btnEditar4.Enabled = True
        btnGrabar2.Enabled = False
        ddlDocumento.Enabled = True
        ListarDocumento()
    End Sub

    Private Sub btnCancelar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar3.Click
        For Each dgi As DataGridItem In dgDocumento3.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro2"), DropDownList)
            ddl.Enabled = False
        Next
        btnEditar3.Visible = True
        btnCancelar3.Visible = False
        btnEditar1.Enabled = True
        btnEditar2.Enabled = True
        btnEditar4.Enabled = True
        btnGrabar3.Enabled = False
        ddlDocumento.Enabled = True
        ListarDocumento()
    End Sub

    Private Sub btnCancelar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar4.Click
        For Each dgi As DataGridItem In dgDocumento4.Items
            ddl = DirectCast(dgi.Cells(1).FindControl("ddlTipoBuro3"), DropDownList)
            ddl.Enabled = False
        Next
        btnEditar4.Visible = True
        btnCancelar4.Visible = False
        btnEditar1.Enabled = True
        btnEditar2.Enabled = True
        btnEditar3.Enabled = True
        btnGrabar4.Enabled = False
        ddlDocumento.Enabled = True
        ListarDocumento()
    End Sub

    Private Sub btnGrabar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar1.Click
        Grabar(dgDocumento1, "")
    End Sub

    Private Sub btnGrabar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar2.Click
        Grabar(dgDocumento2, "1")
    End Sub

    Private Sub btnGrabar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar3.Click
        Grabar(dgDocumento3, "2")
    End Sub

    Private Sub btnGrabar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar4.Click
        Grabar(dgDocumento4, "3")
    End Sub

    Sub Grabar(ByVal dgDocumento As System.Web.UI.WebControls.DataGrid, ByVal idx As String)
        Try
            Dim strBuro As String
            Dim strPosicion As String
            Dim strCadena As String
            Dim ddlTipoBuro As String = "ddlTipoBuro" & idx

            For Each dg As DataGridItem In dgDocumento.Items
                strPosicion = dg.Cells(0).Text()
                strBuro = DirectCast(dg.Cells(1).FindControl(ddlTipoBuro), DropDownList).SelectedValue
                strCadena = strCadena & "|" & strPosicion & ";" & strBuro
            Next
            grabarBuroConfig(strCadena.Substring(1))
        Catch ex As Exception

        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_BURO_CREDITICIO_CONFIG"), "", "Modificar Configuración Buro Crediticio.")
        End Try
    End Sub

    Private Sub listarBuro(ByVal strDocumento As String)
        Dim oData As DataTable = (New LBuroCrediticio).ListarBusqueda("T", "", strDocumento, "1")
        Session("lstBuros") = oData
    End Sub

    Private Function listarBuroConfig(ByVal strDocumento As String) As DataTable
        Dim oData As DataTable = (New LBuroCrediticio).ListarConfigBuro(strDocumento)
        Return oData
    End Function

    Private Sub grabarBuroConfig(ByVal strBuro As String)
        Dim obj As New LBuroCrediticio
        Dim strDocumento As String = ddlDocumento.SelectedValue
        obj.ModificarConfigBuro(strBuro, strDocumento, CurrentUser)
    End Sub

    Private Sub ddlDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDocumento.SelectedIndexChanged
        ListarDocumento()
    End Sub

    Private Sub dgDocumento1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ddl = CType(e.Item.FindControl("ddlTipoBuro"), DropDownList)
            ddl.DataSource = CType(Session("lstBuros"), DataTable)
            ddl.DataValueField = "CODIGO"
            ddl.DataTextField = "NOMBRE"
            ddl.DataBind()
            ddl.SelectedValue = CType(e.Item.DataItem, ListItem).Value
        End If
    End Sub

    Private Sub dgDocumento2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ddl = CType(e.Item.FindControl("ddlTipoBuro1"), DropDownList)
            ddl.DataSource = CType(Session("lstBuros"), DataTable)
            ddl.DataValueField = "CODIGO"
            ddl.DataTextField = "NOMBRE"
            ddl.DataBind()
            ddl.SelectedValue = CType(e.Item.DataItem, ListItem).Value
        End If
    End Sub

    Private Sub dgDocumento3_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento3.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ddl = CType(e.Item.FindControl("ddlTipoBuro2"), DropDownList)
            ddl.DataSource = CType(Session("lstBuros"), DataTable)
            ddl.DataValueField = "CODIGO"
            ddl.DataTextField = "NOMBRE"
            ddl.DataBind()
            ddl.SelectedValue = CType(e.Item.DataItem, ListItem).Value
        End If
    End Sub

    Private Sub dgDocumento4_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDocumento4.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ddl = CType(e.Item.FindControl("ddlTipoBuro3"), DropDownList)
            ddl.DataSource = CType(Session("lstBuros"), DataTable)
            ddl.DataValueField = "CODIGO"
            ddl.DataTextField = "NOMBRE"
            ddl.DataBind()
            ddl.SelectedValue = CType(e.Item.DataItem, ListItem).Value
        End If
    End Sub

    Private Sub InsertarAuditoria(ByVal strCodigoEvento As String, ByVal strTelefono As String, ByVal strTexto As String)
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
        Dim ipcliente As String = CurrentTerminal
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim usuario_id As String = CurrentUser

        Dim objAudi As New AuditoriaNegocio
        objAudi.registrarAuditoria(strCodigoEvento, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, strTelefono, "0", strTexto)
    End Sub
End Class
