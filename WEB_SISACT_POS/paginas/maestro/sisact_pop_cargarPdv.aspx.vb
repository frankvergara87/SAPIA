Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones

Public Class sisact_pop_cargarPdv
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents cltCanal As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chkBusqueda2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtBusquedaCodPdv As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkBusqueda3 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDescripcionPdv As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscarPDV As System.Web.UI.WebControls.Button
    Protected WithEvents dgPDV As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAgregarPdv As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtAccionGrabarPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents divBusquedaPdv As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents trGrillaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCargarSesion As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnCancelar As System.Web.UI.HtmlControls.HtmlInputButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Shared CHECKED_ITEMS As String = "CHECKED_ITEMS_PDV"
    Shared CHECK_TOTAL As Boolean
    Dim oDataTableSessionPdv As New DataTable
    Dim oDataTablePdv As New DataTable

    Dim oArrayListPdv As New ArrayList
    Dim oArrayListSessionPdv As New ArrayList

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Session("oDataTableSessionPdv") Is Nothing Then ' Testing
            oDataTableSessionPdv = CType(Session("oDataTableSessionPdv"), DataTable)
        End If

        If Not Session("oArrayListSessionPdv") Is Nothing Then ' Testing
            oArrayListSessionPdv = CType(Session("oArrayListSessionPdv"), ArrayList)
        End If

        If Not Page.IsPostBack Then
            'Dim objLRestriccionPDV As New LRestriccionPDV
            cltCanal.DataValueField = "TOFIC_CODIGO"
            cltCanal.DataTextField = "TOFIV_DESCRIPCION"
            cltCanal.DataSource = New RestriccionPdvBusinessLogic().fdtbListarTipoOficina ' objLRestriccionPDV.fdtbListarTipoOficina
            cltCanal.DataBind()

            chkBusqueda2.Attributes.Add("onClick", "deshabilitarControles(this," & txtBusquedaCodPdv.ClientID & ");")
            chkBusqueda3.Attributes.Add("onClick", "deshabilitarControles(this," & txtDescripcionPdv.ClientID & ");")
        End If
    End Sub

    Private Sub dgPDV_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPDV.PageIndexChanged
        RememberOldValues()
        dgPDV.CurrentPageIndex = e.NewPageIndex
        BuscarPDV()
        RePopulateValues()
    End Sub

    Private Sub btnBuscarPDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPDV.Click
        dgPDV.CurrentPageIndex = 0
        BuscarPDV()
    End Sub

    Private Sub BuscarPDV()
        Dim strCanales As String = String.Empty
        Dim strCodigo As String = String.Empty
        Dim strDescripcion As String = String.Empty
        Dim objLRestriccionPDV As LRestriccionPDV

        Dim oArray As ArrayList

        If chkBusqueda2.Checked Then
            strCodigo = txtBusquedaCodPdv.Text.Trim.ToUpper
        Else
            txtBusquedaCodPdv.Text = String.Empty
        End If
        If chkBusqueda3.Checked Then
            strDescripcion = txtDescripcionPdv.Text.Trim.ToUpper
        Else
            txtDescripcionPdv.Text = String.Empty
        End If

        'Canales
        For Each lit As ListItem In cltCanal.Items
            If lit.Selected Then
                strCanales &= "|" & lit.Value
            End If
        Next
        oArray = New RestriccionPdvBusinessLogic().ListarPDV(strCanales, strCodigo, strDescripcion)
        dgPDV.DataSource = oArray
        dgPDV.DataBind()
        Session("oArrayListPdv") = oArray
        RePopulateValues() 'test
    End Sub

    Private Sub RememberOldValues() ' se ejecuta cuando se cambia de pagina y cuando se da en el btn Aceptar
        Dim categoryIDList As New ArrayList
        Dim oString As String = ""
        Dim oItem As DataGridItem
        oArrayListPdv = CType(Session("oArrayListPdv"), ArrayList)

        For Each oItem In dgPDV.Items
            oString = dgPDV.DataKeys(oItem.ItemIndex).ToString() 'devuelve el codigo que se asigno como pk para la consulta
            Dim result As Boolean = (CType(oItem.FindControl("fila"), CheckBox)).Checked

            If Not Session("oArrayListSessionPdv") Is Nothing Then
                oArrayListSessionPdv = CType(Session("oArrayListSessionPdv"), ArrayList)
            End If

            If result Then
                For Each oPuntoVenta As PuntoVenta In oArrayListPdv
                    If oPuntoVenta.OVENC_CODIGO = oString Then
                        If Not existeRowPdv(oString) Then oArrayListSessionPdv.Add(oPuntoVenta) ' oDataTableSessionPdv.Rows.Add(RowTemp)
                    End If
                Next
            Else
                Try
                    If oArrayListSessionPdv.Count > 0 Then
                        For Each oPuntoVenta As PuntoVenta In oArrayListSessionPdv
                            If oPuntoVenta.OVENC_CODIGO = oString Then
                                oArrayListSessionPdv.Remove(oPuntoVenta)
                            End If
                        Next
                    End If
                Catch ex As Exception

                End Try
            End If
            If oArrayListSessionPdv.Count > 0 Then
                Session("oArrayListSessionPdv") = oArrayListSessionPdv
            End If
        Next

    End Sub

    Function existeRowPdv(ByVal cod As String) As Boolean

        If Not Session("oArrayListSessionPdv") Is Nothing Then ' Testing
            Dim oArrayListTemp As ArrayList = CType(Session("oArrayListSessionPdv"), ArrayList)
            If oArrayListTemp.Count > 0 Then
                For Each oPuntoVenta As PuntoVenta In oArrayListTemp
                    If oPuntoVenta.OVENC_CODIGO = cod Then
                        Return True
                        Exit Function
                    End If
                Next
            End If
        End If
        Return False
    End Function

    Private Sub RePopulateValues() 'marca y desmarca los check que se encuentran en la session para pintarlos en la grilla
        If Not Session("oArrayListSessionPdv") Is Nothing Then ' Testing
            oArrayListSessionPdv = CType(Session("oArrayListSessionPdv"), ArrayList)

            Dim oCheckBox As CheckBox
            Dim oItem As DataGridItem
            If oArrayListSessionPdv.Count > 0 Then  ' marca los check de cada pagina que ya estan seleccionado en la session
                For Each oItem In dgPDV.Items
                    Dim index As String = dgPDV.DataKeys(oItem.ItemIndex).ToString()
                    For Each oPuntoVenta As PuntoVenta In oArrayListSessionPdv
                        If oPuntoVenta.OVENC_CODIGO = index Then
                            oCheckBox = CType(oItem.FindControl("fila"), CheckBox)
                            oCheckBox.Checked = True
                        End If
                    Next
                Next
            Else
                For Each oItem In dgPDV.Items ' desmarca los check que no estan seleccionados de la grilla que estan en la session
                    oCheckBox = CType(oItem.FindControl("fila"), CheckBox)
                    oCheckBox.Checked = False
                Next
            End If
        End If

    End Sub

    Public Sub chkTotalGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim categoryIDList As New ArrayList
    '    Dim chkTotalGrilla As CheckBox = DirectCast(sender, CheckBox)

    '    Dim dtbTotal As DataTable = DirectCast(Session("ITEMS_TOTAL_DATATABLE"), DataTable)

    '    If chkTotalGrilla.Checked Then
    '        For Each ditItem As DataRow In dtbTotal.Rows
    '            categoryIDList.Add(ditItem(0))
    '        Next

    '        CHECK_TOTAL = True
    '    Else
    '        CHECK_TOTAL = False
    '        categoryIDList.Clear()
    '    End If

    '    If Not categoryIDList Is Nothing Then
    '        Session(CHECKED_ITEMS) = categoryIDList
    '    End If

    '    RePopulateValues()
        '
    End Sub

    Private Sub dgPDV_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPDV.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim chkTotal As CheckBox = CType(e.Item.FindControl("chkTotalGrilla"), CheckBox)
            chkTotal.Checked = CHECK_TOTAL
        End If
    End Sub

    Private Sub btnAgregarPdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPdv.Click
        RememberOldValues() 'aqui e carga la info que contiene la sesion
        If Not Session("oArrayListSessionPdv") Is Nothing Then ' Testing
            oArrayListSessionPdv = CType(Session("oArrayListSessionPdv"), ArrayList)
            If oArrayListSessionPdv.Count = 0 Then
                RegisterStartupScript("script", "<script>alert('Debe seleccionar al menos un punto de venta');</script>")
                Exit Sub
            End If
            Session("oArrayListPdv") = Nothing
            Session("oArrayListSessionPdv") = oArrayListSessionPdv
            RegisterStartupScript("script", "<script>llamarPadre();</script>")
        Else
            RegisterStartupScript("script", "<script>alert('Debe seleccionar al menos un punto de venta');</script>")
        End If
        
    End Sub

    Private Sub btnCargarSesion_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarSesion.ServerClick

        If Me.hidCondicion.Value = "TODOS" Then
            Dim strCanales As String = String.Empty
            Dim strCodigo As String = String.Empty
            Dim strDescripcion As String = String.Empty
            Dim objLRestriccionPDV As LRestriccionPDV

            Dim oArray As ArrayList

            If chkBusqueda2.Checked Then
                strCodigo = txtBusquedaCodPdv.Text.Trim.ToUpper
            Else
                txtBusquedaCodPdv.Text = String.Empty
            End If
            If chkBusqueda3.Checked Then
                strDescripcion = txtDescripcionPdv.Text.Trim.ToUpper
            Else
                txtDescripcionPdv.Text = String.Empty
            End If

            'Canales
            For Each lit As ListItem In cltCanal.Items
                If lit.Selected Then
                    strCanales &= "|" & lit.Value
                End If
            Next
            Session("oArrayListSessionPdv") = New RestriccionPdvBusinessLogic().ListarPDV(strCanales, strCodigo, strDescripcion)
        Else
            Session("oArrayListSessionPdv") = Nothing
            Session("oArrayListPdv") = Nothing
        End If
    End Sub

    Private Sub btnCancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.ServerClick
        Session("oArrayListSessionPdv") = Nothing
        Session("oArrayListPdv") = Nothing
    End Sub
End Class
