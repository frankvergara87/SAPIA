Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.SapGeneral

Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones

Public Class sisact_pop_cargarCampanias
    Inherits SisAct_WebBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents btnMarcarServer As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgrCampanias As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnCargarSesion As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Dim SAP_FECHA_ACTUAL As String = Now.ToString("yyyyMMdd")
    Dim SAP_TIPO_VENTA As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("SAP_TIPO_VENTA"))
    Dim CE_EXCLUSIVA_CHECK As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_EXCLUSIVA_CHECK"))
    Dim CE_EXCLUSIVA_NOCHECK As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("CE_EXCLUSIVA_NOCHECK"))

    Private ent As New CasoEspecial
    Private obj As New CasoEspecialNegocios
    Private sap As New clsGeneral

    Private DtCampa�as As New DataTable
    'Private Marcar As Boolean

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Not Session("Campanias") Is Nothing Then
                DtCampa�as = CType(Session("Campanias"), DataTable)
                Session("Campa�asTemporal") = DtCampa�as
                Dim Dt As DataTable = Campa�asOrdenadas()
                Me.dgrCampanias.DataSource = Dt
                Me.dgrCampanias.DataBind()
                Call RepoblarValores()
                Me.btnCancelar.Attributes.Add("onclick", "return f_CerrarVentana();")
            End If
        End If
    End Sub

    Private Function Campa�asOrdenadas() As DataTable
        Dim DtSap As New DataTable
        DtSap.Columns.Add("IdCampania", GetType(String))
        DtSap.Columns.Add("Campania", GetType(String))
        DtSap.Columns.Add("Exclusiva", GetType(String))
        Dim ListaArreglo As New ArrayList
        ListaArreglo = sap.Get_ConsultaCampana(SAP_FECHA_ACTUAL, SAP_TIPO_VENTA)
        For Each Item As Claro.SisAct.Entidades.ItemGenerico In ListaArreglo
            Dim Fila As DataRow = DtSap.NewRow
            Fila("IdCampania") = Item.Codigo
            Fila("Campania") = Item.Descripcion
            Fila("Exclusiva") = "0"
            DtSap.Rows.Add(Fila)
        Next
        Dim Dt As DataTable = DtSap.Clone
        Dim Ordenacion As String = "Campania Asc"
        Dim Rows() As DataRow = DtSap.Select("", Ordenacion)
        For Each Dr As DataRow In Rows
            Dim Row As DataRow = Dt.NewRow
            Row("IdCampania") = Funciones.CheckStr(Dr("IdCampania"))
            Row("Campania") = Funciones.CheckStr(Dr("Campania"))
            Row("Exclusiva") = Funciones.CheckStr(Dr("Exclusiva"))
            Dt.Rows.Add(Row)
        Next
        Return Dt
    End Function

    Private Sub RecordarValores()
        If Not Session("Campa�asTemporal") Is Nothing Then
            DtCampa�as = CType(Session("Campa�asTemporal"), DataTable)
            For Each Item As DataGridItem In Me.dgrCampanias.Items
                Dim IdCampa�a As String = Item.Cells(1).Text.ToString.Trim
                Dim Check As Boolean = (CType(Item.FindControl("chkMarcar"), CheckBox)).Checked
                If Check = True Then
                    Dim Filtro As String = ""
                    Filtro = Filtro + "IdCampania= '" + IdCampa�a + "' "
                    Dim ArrDr() As DataRow = DtCampa�as.Select(Filtro)
                    If ArrDr.Length > 0 Then
                        For Each Dr As DataRow In ArrDr
                            DtCampa�as.Rows.Remove(Dr)
                        Next
                        Dim Fila As DataRow = DtCampa�as.NewRow
                        Fila("IdCampania") = IdCampa�a
                        Fila("Campania") = Item.Cells(2).Text
                        Dim chkExclusiva As CheckBox = DirectCast(Item.Cells(3).FindControl("chkExclusiva"), CheckBox)
                        If chkExclusiva.Checked Then
                            Fila("Exclusiva") = CE_EXCLUSIVA_CHECK
                        Else
                            Fila("Exclusiva") = CE_EXCLUSIVA_NOCHECK
                        End If
                        DtCampa�as.Rows.Add(Fila)
                    Else
                        Dim Fila As DataRow = DtCampa�as.NewRow
                        Fila("IdCampania") = IdCampa�a
                        Fila("Campania") = Item.Cells(2).Text
                        Dim chkExclusiva As CheckBox = DirectCast(Item.Cells(3).FindControl("chkExclusiva"), CheckBox)
                        If chkExclusiva.Checked Then
                            Fila("Exclusiva") = CE_EXCLUSIVA_CHECK
                        Else
                            Fila("Exclusiva") = CE_EXCLUSIVA_NOCHECK
                        End If
                        DtCampa�as.Rows.Add(Fila)
                    End If
                Else
                    Dim Filtro As String = ""
                    Filtro = Filtro + "IdCampania= '" + IdCampa�a + "' "
                    Dim ArrDr() As DataRow = DtCampa�as.Select(Filtro)
                    If ArrDr.Length > 0 Then
                        For Each Dr As DataRow In ArrDr
                            DtCampa�as.Rows.Remove(Dr)
                        Next
                    End If
                End If
            Next
            Session("Campa�asTemporal") = DtCampa�as
        End If
    End Sub

    Function ExisteFila(ByVal Codigo As String) As Boolean
        If Not Session("Campa�asTemporal") Is Nothing Then
            Dim Dt As DataTable = CType(Session("Campa�asTemporal"), DataTable)
            If Dt.Rows.Count > 0 Then
                For Each Dr As DataRow In Dt.Rows
                    If Codigo = Funciones.CheckStr(Dr("IdCampania")) Then
                        Return True
                        Exit Function
                    End If
                Next
            End If
        End If
        Return False
    End Function

    Private Sub RepoblarValores()
        If Not Session("Campa�asTemporal") Is Nothing Then
            DtCampa�as = CType(Session("Campa�asTemporal"), DataTable)
            Dim CheckBox As CheckBox
            Dim Item As DataGridItem
            If DtCampa�as.Rows.Count > 0 Then
                For Each Item In dgrCampanias.Items
                    Dim Codigo As String = Item.Cells(1).Text
                    For Each Dr As DataRow In DtCampa�as.Rows
                        If Codigo = Funciones.CheckStr(Dr("IdCampania")) Then
                            CheckBox = CType(Item.FindControl("chkMarcar"), CheckBox)
                            CheckBox.Checked = True
                            If Funciones.CheckStr(Dr("Exclusiva")) = CE_EXCLUSIVA_CHECK Then
                                CheckBox = CType(Item.FindControl("chkExclusiva"), CheckBox)
                                CheckBox.Checked = True
                            Else
                                CheckBox = CType(Item.FindControl("chkExclusiva"), CheckBox)
                                CheckBox.Checked = False
                            End If
                        End If
                    Next
                Next
            Else
                For Each Item In dgrCampanias.Items
                    CheckBox = CType(Item.FindControl("chkMarcar"), CheckBox)
                    CheckBox.Checked = False
                    CheckBox = CType(Item.FindControl("chkExclusiva"), CheckBox)
                    CheckBox.Checked = False
                Next
            End If
        End If
    End Sub

    Private Sub Agregar()
        Call RecordarValores()
        If DtCampa�as.Rows.Count = 0 Then
            RegisterStartupScript("script", "<script>alert('Marque Registros para Agregar'); document.getElementById('" & Me.dgrCampanias.ClientID & "').focus();</script>")
        Else
            Dim Dt As DataTable = DtCampa�as.Clone
            Dim Ordenacion As String = "Campania Asc"
            Dim Rows() As DataRow = DtCampa�as.Select("", Ordenacion, DataViewRowState.CurrentRows)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = Dt.NewRow
                Row("IdCampania") = Funciones.CheckStr(Dr("IdCampania"))
                Row("Campania") = Funciones.CheckStr(Dr("Campania"))
                Row("Exclusiva") = Funciones.CheckStr(Dr("Exclusiva"))
                Dt.Rows.Add(Row)
            Next
            Session("Campanias") = Nothing
            Session("Campanias") = Dt
            Session("TemporalCampanias") = Nothing
            RegisterStartupScript("script", "<script>llamarPadre();</script>")
        End If
    End Sub

    Private Sub dgrCampanias_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrCampanias.PageIndexChanged
        Call RecordarValores()
        DtCampa�as = Campa�asOrdenadas()
        Me.dgrCampanias.CurrentPageIndex = e.NewPageIndex
        Me.dgrCampanias.DataSource = DtCampa�as
        Me.dgrCampanias.DataBind()
        Session("TemporalCampanias") = DtCampa�as
        Call RepoblarValores()
    End Sub

    Private Sub btnCargarSesion_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarSesion.ServerClick
        If Me.hidCondicion.Value = "TODOS" Then
            Dim DtSinOrdenar As DataTable = Campa�asOrdenadas()
            Dim Dt As DataTable = DtSinOrdenar.Clone
            Dim Ordenacion As String = "Campania Asc"
            Dim Rows() As DataRow = DtSinOrdenar.Select("", Ordenacion)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = Dt.NewRow
                Row("IdCampania") = Funciones.CheckStr(Dr("IdCampania"))
                Row("Campania") = Funciones.CheckStr(Dr("Campania"))
                Row("Exclusiva") = Funciones.CheckStr(Dr("Exclusiva"))
                Dt.Rows.Add(Row)
            Next
            Session("Campa�asTemporal") = Dt
        Else
            Dim DtSinOrdenar As DataTable = DtCampa�as
            Dim Dt As DataTable = DtSinOrdenar.Clone
            Dim Ordenacion As String = "Campania Asc"
            Dim Rows() As DataRow = DtSinOrdenar.Select("", Ordenacion)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = Dt.NewRow
                Row("IdCampania") = Funciones.CheckStr(Dr("IdCampania"))
                Row("Campania") = Funciones.CheckStr(Dr("Campania"))
                Row("Exclusiva") = Funciones.CheckStr(Dr("Exclusiva"))
                Dt.Rows.Add(Row)
            Next
            Session("Campa�asTemporal") = Dt
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Call Agregar()
    End Sub

    'Private Sub dgrCampanias_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrCampanias.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Header Then
    '        Dim chkTodos As CheckBox = CType(e.Item.FindControl("chkTodos"), CheckBox)
    '        If Not chkTodos Is Nothing Then
    '            chkTodos.Checked = Marcar
    '        End If
    '    End If
    'End Sub

End Class
