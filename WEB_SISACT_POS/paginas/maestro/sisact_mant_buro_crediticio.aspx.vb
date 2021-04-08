Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO

Public Class sisact_mant_buro_crediticio
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBuro As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAccion As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombreBuro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcionBuro As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlDocumentoEdit As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstadoEdit As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Shared CHECK_ALL As Boolean
    Private strNameFile As String = "BuroCrediticio" & "_" & DateTime.Now.ToString("ddMMyyyy")
    Private strRutaArchivo As String = ConfigurationSettings.AppSettings("rutaOrigenTmp")

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
            RegisterStartupScript("script", "<script>f_MostrarTab('INICIO')</script>")
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_CambiarBusqueda(true);")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnAccion.Attributes.Add("onclick", "return f_eliminarSeleccionados();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim strTipo As String = ddlBusqueda.SelectedValue
            Dim strDocumento As String = ddlDocumento.SelectedValue
            Dim strEstado As String = ddlEstado.SelectedValue
            Dim strDescripcion As String = CheckStr(txtBuro.Text).ToUpper
            CHECK_ALL = False

            Dim dtbLista As DataTable = (New LBuroCrediticio).ListarBusqueda(strTipo, strDescripcion, strDocumento, strEstado)
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()

            Session("ITEMS") = dtbLista
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_CON_BURO_CREDITICIO"), "", "Consulta Buro. Tipo de Busqueda: " & ddlBusqueda.SelectedItem.Text)
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false)</script>")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        CHECK_ALL = False
        Session("ITEMS") = Nothing
        txtBuro.Text = String.Empty
        hidCodigo.Value = String.Empty
        ddlEstado.SelectedIndex = 0
        ddlBusqueda.SelectedIndex = 0
        ddlDocumento.SelectedIndex = 0
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()
        RegisterStartupScript("script", "<script>f_MostrarTab('INICIO')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
            Dim dt As DataTable = (New LBuroCrediticio).ConsultarDatos(hidCodigo.Value)
            txtCodigo.Text = CheckStr(dt.Rows(0)("CODIGO"))
            txtCodigo.CssClass = "clsInputDisable"
            txtCodigo.ReadOnly = True

            txtNombreBuro.Text = CheckStr(dt.Rows(0)("NOMBRE"))
            txtDescripcionBuro.Text = CheckStr(dt.Rows(0)("DESCRIPCION"))
            ddlDocumentoEdit.SelectedValue = CheckStr(dt.Rows(0)("DOCUMENTO"))
            ddlEstadoEdit.SelectedValue = CheckStr(dt.Rows(0)("ESTADO"))

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    End Sub

    Private Sub btnAccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccion.Click
        Try
            RememberOldValues()

            Dim strItemChecked As String = String.Empty
            Dim arrItemChecked As ArrayList = CType(Session("CHECKED_ITEMS"), ArrayList)
            If Not arrItemChecked Is Nothing Then
                For Each strNumero As String In arrItemChecked
                    strItemChecked &= "|" & strNumero
                Next
            End If

            If strItemChecked.Length > 0 Then
                Dim obj As New LBuroCrediticio
                Dim strAccion As String = IIf(hidAccion.Value = "D", "0", "1")

                obj.ModificarEstado(strItemChecked, strAccion)
                btnBuscar_Click(Nothing, Nothing)

                Session("CHECKED_ITEMS") = Nothing
            End If
        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);alert('" & ConfigurationSettings.AppSettings("msjBuroCrediticio1") & "')</script>")
            Else
                Throw ex
            End If
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_BURO_CREDITICIO"), "", "Actualizar Buro Crediticio.")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim strCodigo As String = hidCodigo.Value
            Dim strNombre As String = UCase(txtNombreBuro.Text)
            Dim strDescripcion As String = UCase(txtDescripcionBuro.Text)
            Dim strDocumento As String = ddlDocumentoEdit.SelectedValue
            Dim strEstado As String = ddlEstadoEdit.SelectedValue

            If Not strCodigo = "" Then
                Dim obj As New LBuroCrediticio
                obj.ModificarDatos(strCodigo, strNombre, strDescripcion, strDocumento, strEstado, CurrentUser)
                InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_BURO_CREDITICIO"), "", "Modificar Buro Crediticio. Buro: " & strNombre)
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('" & ConfigurationSettings.AppSettings("msjBuroCrediticio1") & "')</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        CHECK_ALL = False
        RegisterStartupScript("script", "<script>f_MostrarTab('INICIO')</script>")
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim chkTotal As CheckBox = CType(e.Item.FindControl("chkTotalGrilla"), CheckBox)
            chkTotal.Checked = CHECK_ALL
        End If
    End Sub

    Private Sub RememberOldValues()
        Dim categoryIDList As New ArrayList
        Dim index As String = ""
        Dim dgritem As DataGridItem
        For Each dgritem In dgrGrillaDetalle.Items
            index = dgrGrillaDetalle.DataKeys(dgritem.ItemIndex).ToString()
            Dim result As Boolean = (CType(dgritem.FindControl("fila"), CheckBox)).Checked
            ' Check in the Session
            If Not Session("CHECKED_ITEMS") Is Nothing Then
                categoryIDList = CType(Session("CHECKED_ITEMS"), ArrayList)
            End If
            If result Then
                If Not categoryIDList.Contains(index) Then
                    categoryIDList.Add(index)
                End If
            Else
                categoryIDList.Remove(index)
            End If
            If Not categoryIDList Is Nothing AndAlso categoryIDList.Count > 0 Then
                Session("CHECKED_ITEMS") = categoryIDList
            End If
        Next
    End Sub

    Public Sub chkTotalGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim categoryIDList As New ArrayList
        Dim chkTotalGrilla As CheckBox = DirectCast(sender, CheckBox)
        Dim dtbTotal As DataTable = DirectCast(Session("ITEMS"), DataTable)

        If chkTotalGrilla.Checked Then
            For Each ditItem As DataRow In dtbTotal.Rows
                categoryIDList.Add(CheckStr(ditItem(0)))
            Next
            CHECK_ALL = True
        Else
            CHECK_ALL = False
            categoryIDList.Clear()
        End If

        If Not categoryIDList Is Nothing Then
            Session("CHECKED_ITEMS") = categoryIDList
        End If

        RePopulateValues()
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);</script>")
    End Sub

    Private Sub RePopulateValues()
        Dim categoryIDList As ArrayList = CType(Session("CHECKED_ITEMS"), ArrayList)
        Dim myCheckBox As CheckBox
        Dim dgritem As DataGridItem

        If Not categoryIDList Is Nothing AndAlso categoryIDList.Count > 0 Then
            For Each dgritem In dgrGrillaDetalle.Items
                Dim index As String = dgrGrillaDetalle.DataKeys(dgritem.ItemIndex).ToString()
                If categoryIDList.Contains(index) Then
                    myCheckBox = CType(dgritem.FindControl("fila"), CheckBox)
                    myCheckBox.Checked = True
                End If
            Next
        Else
            For Each dgritem In dgrGrillaDetalle.Items
                myCheckBox = CType(dgritem.FindControl("fila"), CheckBox)
                myCheckBox.Checked = False
            Next
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not Session("ITEMS") Is Nothing Then
            Dim dtbLista As DataTable = DirectCast(Session("ITEMS"), DataTable)
            EliminarArchivo()

            Dim strArchivo As String = Server.MapPath(strRutaArchivo) & "/" & strNameFile & ".csv"
            Dim sw As New System.IO.StreamWriter(strArchivo, False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim nroRegistros As Integer = dtbLista.Rows.Count
            Try

                Dim linea As String
                If nroRegistros > 0 Then
                    linea = "NOMBRE BURO" & "," & _
                            "DESCRIPCION" & "," & _
                            "DOCUMENTO" & "," & _
                            "ESTADO"
                    sw.WriteLine(linea)

                    For i As Integer = 0 To nroRegistros - 1
                        linea = dtbLista.Rows(i)("NOMBRE") & "," & _
                                dtbLista.Rows(i)("DESCRIPCION") & "," & _
                                dtbLista.Rows(i)("DOCUMENTO") & "," & _
                                dtbLista.Rows(i)("ESTADO")
                        sw.WriteLine(linea)
                    Next

                    sw.Flush()
                    sw.Close()

                    Dim fs As System.IO.FileStream = Nothing
                    fs = System.IO.File.Open(strArchivo, System.IO.FileMode.Open)

                    Dim btFile(fs.Length) As Byte
                    fs.Read(btFile, 0, fs.Length)
                    fs.Close()
                    EliminarArchivo()

                    With Response
                        .Clear()
                        .AddHeader("Content-disposition", "attachment;filename=" & strNameFile & ".csv")
                        .ContentType = "text/csv; charset=iso-8859-1"
                        .BinaryWrite(btFile)
                        .End()
                    End With
                Else
                    RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);alert('No existen registros cargados')</script>")
                End If
            Catch ex As Threading.ThreadAbortException
            Catch ex As Exception
                sw.Flush()
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);alert('Error al exportar carga')</script>")
            Finally
                sw.Close()
                InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_EXP_BURO_CREDITICIO"), "", "Exportar Reporte Buro Crediticio.")
            End Try
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);alert('No existen registros cargados')</script>")
        End If
    End Sub

    Public Sub EliminarArchivo()
        Dim strArchivo As String = Server.MapPath(strRutaArchivo) & "\" & strNameFile & ".csv"
        If File.Exists(strArchivo) Then
            System.IO.File.Delete(strArchivo)
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
