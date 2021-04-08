Imports System.Text
Imports System.Xml

Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones


Public Class sisact_renovacion_detalle_descuento
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgDescuentoPromocional As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not Page.IsPostBack Then
            Dim querystring As String = HttpUtility.UrlDecode(Request.QueryString("qs"))
            Dim detalle(,) As String
            Dim total As String

            Call ConfigurarDatos(querystring, detalle, total)
            Call MostrarDescuento(detalle, total)
        End If
    End Sub
    Private Sub ConfigurarDatos(ByVal qs As String, ByRef detalle(,) As String, ByRef total As String)
        Dim datos() As String = qs.Split("~"c)
        ReDim detalle(datos.Length - 2, 8)

        total = datos(datos.Length - 1)
        For i As Integer = 0 To datos.Length - 2
            Dim saldo() As String = datos(i).Split("|"c)
            For j As Integer = 0 To saldo.Length - 1
                detalle(i, j) = saldo(j)
            Next j
        Next i
    End Sub
    Private Sub MostrarDescuento(ByVal detalle(,) As String, ByVal total As String)
        Dim dtBase As New DataTable
        dtBase.Columns.Add(New DataColumn("NORMAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("PROMOCIONAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TOTAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TIPO_DE_DSCTO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("FACTOR", GetType(Integer)))
        dtBase.Columns.Add(New DataColumn("ORDEN", GetType(Integer)))

        For i As Integer = 0 To detalle.GetLength(0) - 1
            Dim row As DataRow = dtBase.NewRow
            row("NORMAL") = Funciones.CheckDecimal(detalle(i, 0))
            row("PROMOCIONAL") = Funciones.CheckDecimal(detalle(i, 1))
            row("TOTAL") = Funciones.CheckDecimal(detalle(i, 2))
            row("TIPO_DE_DSCTO") = detalle(i, 3)
            row("FACTOR") = detalle(i, 4)
            row("ORDEN") = Funciones.CheckInt(detalle(i, 5))
            dtBase.Rows.Add(row)
        Next i

        Dim dv As New DataView(dtBase)
        dv.Sort = "ORDEN asc"
        Dim dtResult As DataTable = dv.Table
        dgDescuentoPromocional.DataSource = dtResult
        dgDescuentoPromocional.DataBind()

        txtTotal.Text = total
    End Sub
End Class
