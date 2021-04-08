Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones

Public Class sisact_pop_cargarCanal
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
    Protected WithEvents btnAgregarPdv As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents txtAccionGrabarPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents divBusquedaPdv As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents trGrillaPdv As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgCanal As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Shared CHECKED_ITEMS As String = "CHECKED_ITEMS_CANAL"
    Shared CHECK_TOTAL As Boolean
    Dim oDataTableSessionCanal As New DataTable
    Dim oDataTableCanal As New DataTable

    Dim oArrayListCanal As New ArrayList
    Dim oArrayListSessionCanal As New ArrayList


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Session("oArrayListSessionCanal") Is Nothing Then ' Testing
            oArrayListSessionCanal = CType(Session("oArrayListSessionCanal"), ArrayList)
        End If

        If Not Page.IsPostBack Then
            cltCanal.DataValueField = "TOFIC_CODIGO"
            cltCanal.DataTextField = "TOFIV_DESCRIPCION"
            cltCanal.DataSource = New RestriccionCanalBusinessLogic().fdtbListarTipoOficina ' objLRestriccionPDV.fdtbListarTipoOficina
            cltCanal.DataBind()

            chkBusqueda2.Attributes.Add("onClick", "deshabilitarControles(this," & txtBusquedaCodPdv.ClientID & ");")
            chkBusqueda3.Attributes.Add("onClick", "deshabilitarControles(this," & txtDescripcionPdv.ClientID & ");")
        End If
    End Sub


    Private Sub dgCanal_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgCanal.PageIndexChanged
        RememberOldValues()
        dgCanal.CurrentPageIndex = e.NewPageIndex
        BuscarCanal()
        RePopulateValues()
    End Sub

    Private Sub btnBuscarPDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPDV.Click
        dgCanal.CurrentPageIndex = 0
        BuscarCanal()
    End Sub
    Private Sub BuscarCanal()
        Dim strCanales As String = String.Empty
        Dim strCodigo As String = String.Empty
        Dim strDescripcion As String = String.Empty
        Dim objLRestriccionPDV As LRestriccionPDV
        Dim dtCanal As DataTable
        Dim oArrayList As New ArrayList

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

        oArrayList = New RestriccionCanalBusinessLogic().ListarCanal(strCanales, strCodigo, strDescripcion)
        dgCanal.DataSource = oArrayList
        Session("oArrayListCanal") = oArrayList
        dgCanal.DataBind()

        RePopulateValues() 'test
    End Sub

    Private Sub RememberOldValues()
        Dim categoryIDList As New ArrayList
        Dim oString As String = ""
        Dim oItem As DataGridItem
        oArrayListCanal = CType(Session("oArrayListCanal"), ArrayList)

        For Each oItem In dgCanal.Items
            oString = dgCanal.DataKeys(oItem.ItemIndex).ToString() 'devuelve el codigo que se asigno como pk para la consulta
            Dim result As Boolean = (CType(oItem.FindControl("fila"), CheckBox)).Checked

            If Not Session("oArrayListSessionCanal") Is Nothing Then
                oArrayListSessionCanal = CType(Session("oArrayListSessionCanal"), ArrayList)
            End If

            If result Then
                For Each oCanal As Canal In oArrayListCanal
                    If oCanal.CANAC_CODIGO = oString Then
                        If Not existeRowCanal(oString) Then oArrayListSessionCanal.Add(oCanal) ' oDataTableSessionPdv.Rows.Add(RowTemp)
                    End If
                Next

            Else
                Try
                    If oArrayListSessionCanal.Count > 0 Then
                        For Each oCanal As Canal In oArrayListSessionCanal
                            If oCanal.CANAC_CODIGO = oString Then
                                oArrayListSessionCanal.Remove(oCanal)
                            End If
                        Next
                    End If
                Catch ex As Exception

                End Try
            End If
            If oArrayListSessionCanal.Count > 0 Then
                Session("oArrayListSessionCanal") = oArrayListSessionCanal
            End If
        Next

    End Sub

    Function existeRowCanal(ByVal cod As String) As Boolean

        If Not Session("oArrayListSessionCanal") Is Nothing Then ' Testing
            Dim oArrayListTemp As ArrayList = CType(Session("oArrayListSessionCanal"), ArrayList)
            If oArrayListTemp.Count > 0 Then
                For Each oCanal As Canal In oArrayListTemp
                    If oCanal.CANAC_CODIGO = cod Then
                        Return True
                        Exit Function
                    End If
                Next
            End If
        End If
        Return False
    End Function

    Private Sub RePopulateValues()
        If Not Session("oArrayListSessionCanal") Is Nothing Then ' Testing
            oArrayListSessionCanal = CType(Session("oArrayListSessionCanal"), ArrayList)

            Dim oCheckBox As CheckBox
            Dim oItem As DataGridItem
            If oArrayListSessionCanal.Count > 0 Then  ' marca los check de cada pagina que ya estan seleccionado en la session
                For Each oItem In dgCanal.Items
                    Dim index As String = dgCanal.DataKeys(oItem.ItemIndex).ToString()
                    For Each oCanal As Canal In oArrayListSessionCanal
                        If oCanal.CANAC_CODIGO = index Then
                            oCheckBox = CType(oItem.FindControl("fila"), CheckBox)
                            oCheckBox.Checked = True
                        End If
                    Next

                Next
            Else
                For Each oItem In dgCanal.Items ' desmarca los check que no estan seleccionados de la grilla que estan en la session
                    oCheckBox = CType(oItem.FindControl("fila"), CheckBox)
                    oCheckBox.Checked = False
                Next
            End If
        End If
    End Sub

    Public Sub chkTotalGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim categoryIDList As New ArrayList
        Dim chkTotalGrilla As CheckBox = DirectCast(sender, CheckBox)

        Dim dtbTotal As DataTable = DirectCast(Session("ITEMS_TOTAL_CANAL"), DataTable)

        If chkTotalGrilla.Checked Then
            For Each ditItem As DataRow In dtbTotal.Rows
                categoryIDList.Add(ditItem(0))
            Next

            CHECK_TOTAL = True
        Else
            CHECK_TOTAL = False
            categoryIDList.Clear()
        End If

        If Not categoryIDList Is Nothing Then
            Session(CHECKED_ITEMS) = categoryIDList
        End If

        RePopulateValues()
    End Sub


    Private Sub dgCanal_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCanal.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim chkTotal As CheckBox = CType(e.Item.FindControl("chkTotalGrilla"), CheckBox)
            chkTotal.Checked = CHECK_TOTAL
        End If
    End Sub

    Private Sub btnAgregarPdv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPdv.Click
        RememberOldValues() 'aqui e carga la info que contiene la sesion

        oArrayListSessionCanal = CType(Session("oArrayListSessionCanal"), ArrayList)
        If oArrayListSessionCanal.Count = 0 Then
            RegisterStartupScript("script", "<script>alert('Debe seleccionar al menos un punto de venta');</script>")
            Exit Sub
        End If
        Session("oArrayListCanal") = Nothing

        Session("oArrayListSessionCanal") = oArrayListSessionCanal
        RegisterStartupScript("script", "<script>llamarPadre();</script>")
    End Sub
End Class
