Imports Claro.SisAct.Negocios

Public Class sisact_pop_varios
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrLista As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents hidTipo As System.Web.UI.HtmlControls.HtmlInputHidden

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
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")

        If Not Page.IsPostBack Then
            Dim strTipo As String = Request.QueryString("strTipo")

            If strTipo = "Cmp" Then
                txtCodigo.CssClass = "clsInputDisable"
                txtCodigo.ReadOnly = True
            End If

            hidTipo.Value = Request.QueryString("strTipo")
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
  
            dgrLista.CurrentPageIndex = 0
            Listar()
  
    End Sub

    Private Sub dgrLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrLista.PageIndexChanged
        dgrLista.CurrentPageIndex = e.NewPageIndex
        Listar()
    End Sub

    Private Sub Listar()
        Dim objConsumerNegocio As ConsumerNegocio
        Dim dtLista As DataTable
        Dim dtServicio As DataTable
        Dim drNew As DataRow
        Dim intCodError As Int64
        Dim strCodigo, strDescripcion, strMsjError As String
        Dim strTipo As String = hidTipo.Value
        Dim booEsCodExt As Boolean = False

        Try
            strCodigo = txtCodigo.Text
            strDescripcion = txtDescripcion.Text.Trim.ToUpper

            objConsumerNegocio = New ConsumerNegocio

            dtLista = New DataTable
            dtLista.Columns.Add("CODIGO")
            dtLista.Columns.Add("DESCRIPCION")
            'gaa20130918
            dtLista.Columns.Add("OTRO")
            'fin gaa20130918
            Select Case strTipo
                Case "Srv"
                    dtServicio = objConsumerNegocio.ListarServicioHFC(strCodigo, strDescripcion)
                Case "Pln"
                    dtServicio = objConsumerNegocio.ListarPlanHFC(strCodigo, strDescripcion)
                Case "Eqp"
                    dtServicio = objConsumerNegocio.ListarEquipoHFC(strCodigo, strDescripcion, intCodError, strMsjError)
                Case "Cmp"
                    dtServicio = objConsumerNegocio.ListarCampanaHFC(strDescripcion)
                    'gaa20130923: Codigo externo de servicio
                Case "Sce"
                    dtServicio = objConsumerNegocio.ListarServicioCodExt(strCodigo, strDescripcion, intCodError, strMsjError)
                    booEsCodExt = True
                    'fin gaa20130923
            End Select

            For Each dr As DataRow In dtServicio.Rows
                drNew = dtLista.NewRow

                If strTipo <> "Cmp" Then
                    drNew(0) = dr(0)
                    drNew(1) = dr(1)
                Else
                    drNew(0) = dr(1)
                    drNew(1) = dr(0)
                End If
                'gaa20130918
                If Not dtServicio.Columns("tipequ") Is Nothing Then
                    drNew(2) = dr("tipequ")
                End If
                'fin gaa20130918
                'gaa20131007
                If booEsCodExt Then
                    If Not dtServicio.Columns("descripcion") Is Nothing Then
                        drNew(2) = dr("descripcion")

                        If dgrLista.Columns(3).Visible = False Then
                            dgrLista.Columns(3).HeaderText = "Descripcion Ext"
                            dgrLista.Columns(3).Visible = True
                        End If
                    End If
                End If
                'fin gaa20131007
                dtLista.Rows.Add(drNew)
            Next

            dgrLista.DataSource = dtLista
            dgrLista.DataBind()

            If strTipo = "Cmp" Then
                dgrLista.Columns(1).Visible = False
            End If
    
        Finally
            objConsumerNegocio = Nothing
            dtLista = Nothing
            dtServicio = Nothing
        End Try
    End Sub

    Private Sub dgrLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrLista.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
            Dim hidOtro As HtmlInputHidden = DirectCast(e.Item.Cells(0).FindControl("hidOtro"), HtmlInputHidden)
            Dim strOtro As String = Convert.ToString(DirectCast(e.Item.DataItem, DataRowView)("OTRO"))
            hidOtro.Value = strOtro
        End If
    End Sub
End Class
