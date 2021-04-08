Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports System.IO

Public Class sisact_mant_porcentaje_facturacion
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAccion As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents lblTextAccion As System.Web.UI.WebControls.Label
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cblBilleteras As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents cblBilleterasAgregar As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents dgDetalleBilletera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNombreCombinacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNombreCombinacion As System.Web.UI.WebControls.Label

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private strNameFile As String = "PorcentajeFacturacion" & "_" & DateTime.Now.ToString("ddMMyyyy")
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

        If Not IsPostBack Then
            FillBilleterasBusqueda(cblBilleteras)
            FillGrilla(String.Empty)
        End If
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnAccion.Attributes.Add("onclick", "return f_ActivarItems();")
    End Sub

    Private Sub FillBilleterasBusqueda(ByVal billeterasActivas As CheckBoxList)
        Dim dtbLista As DataTable = (New LBilletera).ListarBilleterasActivas
        billeterasActivas.DataSource = dtbLista
        billeterasActivas.DataTextField = "PRCLV_DESCRIPCION"
        billeterasActivas.DataValueField = "PRCLN_PROD_BASE"
        billeterasActivas.DataBind()
    End Sub

    Private Sub FillGrilla(ByVal billeterasSelected As String)
        Dim dtbLista As DataTable = (New LBilletera).ListarBilleterasList(billeterasSelected, ddlEstado.SelectedValue.Trim)
        btnAccion.Text = IIf(ddlEstado.SelectedValue.Trim.Equals("1"), "Desactivar", "Activar")
        hidAccion.Value = IIf(ddlEstado.SelectedValue.Trim.Equals("1"), "D", "A")
        Session("ITEMS" + Session.SessionID) = dtbLista
        dgrGrillaDetalle.DataSource = dtbLista
        dgrGrillaDetalle.DataBind()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgrGrillaDetalle.CurrentPageIndex = 0
        Dim strBilleteras As String = ObtenerBilleteras()
        FillGrilla(strBilleteras)

        InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_CON_PORCEN_FACTURACION"), "", "Consulta Porcentaje Facturación.")
    End Sub

    Private Function ObtenerBilleteras() As String
        'Validar los seleccionados
        Dim i As Integer
        Dim strBilleteras As String = String.Empty
        For i = 0 To cblBilleteras.Items.Count - 1
            If (cblBilleteras.Items(i).Selected) Then
                If strBilleteras.Equals(String.Empty) Then
                    strBilleteras = cblBilleteras.Items(i).Value
                Else
                    strBilleteras += "," + cblBilleteras.Items(i).Value
                End If
            End If
        Next
        Return strBilleteras
    End Function

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cblBilleteras.ClearSelection()
        FillGrilla(String.Empty)
        dgrGrillaDetalle.CurrentPageIndex = 0
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick

            lblTextAccion.Text = "Modificar"
            mostrarNombreCombinacion(True)
            Dim dtbLista As DataTable = (New LBilletera).ObtenerBilleteras(Int32.Parse(hidCodigo.Value))
            FillGrillaDetalle(dtbLista)
            RegisterStartupScript("script", "<script>f_MostrarTab('ACCION')</script>")

    End Sub

    Private Sub mostrarNombreCombinacion(ByVal view As Boolean)
        lblNombreCombinacion.Visible = view
        txtNombreCombinacion.Visible = view
        cblBilleterasAgregar.Visible = Not view
    End Sub


    Private Sub FillGrillaDetalle(ByVal dtbLista As DataTable)
        dgDetalleBilletera.DataSource = dtbLista
        dgDetalleBilletera.DataBind()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Select Case validarSumaPorcentaje()
                Case True
                    Dim vaccion As String = CStr(IIf(hidCodigo.Value.ToString.Equals(String.Empty), "insert", "edit"))

                    If registrarPorcentajes(vaccion) Then
                        lblTextAccion.Text = "Agregar"
                        btnBuscar_Click(sender, e)
                        RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
                    End If

                Case False
                    btnBuscar_Click(Nothing, Nothing)
                    RegisterStartupScript("script", "<script>f_MostrarTab('ACCION');alert('La suma de porcentajes debe sumar 100%');</script>")
            End Select

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('ACCION');alert('Error: No se registraron los datos. Vuelva a intentarlo')</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Function validarSumaPorcentaje() As Boolean
        Dim vexito As Boolean = True
        Dim dtgItem As DataGridItem
        Dim TotalPorcentaje As Decimal
        For Each dtgItem In dgDetalleBilletera.Items
            Dim _text As New TextBox
            _text = CType(dtgItem.FindControl("txtFact"), TextBox)
            TotalPorcentaje += CDec(_text.Text)
        Next

        'If TotalPorcentaje > 0 And TotalPorcentaje < 100.0 Then
        If Not TotalPorcentaje = CDec(100) Then
            vexito = False
        End If
        Return vexito
    End Function

    Private Function calcularCodigo() As Integer
        Dim vexito As Boolean = True
        Dim dtgItem As DataGridItem
        Dim Codigo As Integer
        For Each dtgItem In dgDetalleBilletera.Items
            Dim lblCodigoBase As New Label
            lblCodigoBase = CType(dtgItem.FindControl("lblCodigoBase"), Label)
            Codigo += CInt(lblCodigoBase.Text)
        Next
        Return Codigo
    End Function

    Private Function registrarPorcentajes(ByVal vaccion As String) As Boolean
        Dim vexito As Boolean = True
        Dim dtgItem As DataGridItem
        Dim TotalPorcentaje As Decimal

        For Each dtgItem In dgDetalleBilletera.Items
            Dim txtFact As New TextBox
            txtFact = CType(dtgItem.FindControl("txtFact"), TextBox)
            Dim lblCodigoBase As New Label
            lblCodigoBase = CType(dtgItem.FindControl("lblCodigoBase"), Label)
            'Se actualiza
            Select Case vaccion
                Case "insert"
                    Dim _Codigo As Integer = calcularCodigo()
                    Dim _descripcion As String = dtgItem.Cells(0).Text
                    Dim result As Integer = (New LBilletera).AgregarPorcentaje(_Codigo, _descripcion, CInt(lblCodigoBase.Text), CDec(txtFact.Text), CurrentUser)

                    InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_INS_PORCEN_FACTURACION"), "", "Ingresar Porcentaje Facturación.")

                    Select Case result
                        Case 1
                            vexito = True
                        Case 2
                            RegisterStartupScript("script1", "<script>f_MostrarTab('ACCION');alert('La combinación ya existe')</script>")
                            Exit For
                    End Select
                Case "edit"
                    vexito = (New LBilletera).ModificarPorcentaje(CDec(txtFact.Text), CInt(hidCodigo.Value), CInt(lblCodigoBase.Text))
                    InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_PORCEN_FACTURACION"), "", "Actualizar Porcentaje Facturación. Código: " & hidCodigo.Value)
            End Select
        Next

        Return vexito
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        lblTextAccion.Text = "Agregar"
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
 
            hidCodigo.Value = String.Empty
            lblTextAccion.Text = "Agregar"
            mostrarNombreCombinacion(False)
            FillBilleterasBusqueda(cblBilleterasAgregar)
            FillGrillaDetalle(Nothing)
            RegisterStartupScript("script", "<script>f_MostrarTab('ACCION')</script>")


    End Sub

    Private Sub cblBilleterasAgregar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cblBilleterasAgregar.SelectedIndexChanged
        FillGrillaDetalle(LlenarTableAgregar)
        RegisterStartupScript("script", "<script>f_MostrarTab('ACCION')</script>")
    End Sub

    Private Function LlenarTableAgregar() As DataTable
        Dim dtbLista As DataTable = New DataTable
        dtbLista.Columns.Add("PRCLV_DESCRIPCION", GetType(String))
        dtbLista.Columns.Add("PRCLN_PROD_BASE", GetType(String))
        dtbLista.Columns.Add("PRCLN_FACTOR_FACT", GetType(String))
        Dim i As Integer
        For i = 0 To cblBilleterasAgregar.Items.Count - 1
            If (cblBilleterasAgregar.Items(i).Selected) Then
                Dim dr As DataRow = dtbLista.NewRow()
                dr(0) = cblBilleterasAgregar.Items(i).Text
                dr(1) = cblBilleterasAgregar.Items(i).Value
                dr(2) = "0"
                dtbLista.Rows.Add(dr)
            End If
        Next
        Return dtbLista
    End Function

    Public Sub EliminarArchivo()
        Dim strArchivo As String = Server.MapPath(strRutaArchivo) & "\" & strNameFile & ".csv"
        If File.Exists(strArchivo) Then
            System.IO.File.Delete(strArchivo)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Session("ITEMS" + Session.SessionID) Is Nothing Then
            btnBuscar_Click(sender, e)
        End If

        Dim dtbLista As DataTable = DirectCast(Session("ITEMS" + Session.SessionID), DataTable)
        EliminarArchivo()

        Dim strArchivo As String = Server.MapPath(strRutaArchivo) & "/" & strNameFile & ".csv"
        Dim sw As New System.IO.StreamWriter(strArchivo, False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
        Dim nroRegistros As Integer = dtbLista.Rows.Count

        Try
            Dim linea As String = String.Empty
            If nroRegistros > 0 Then

                Dim headerBilleteras As New ArrayList(cblBilleteras.Items.Count)
                For Each item As ListItem In cblBilleteras.Items
                    headerBilleteras.Add(item.Text)
                Next

                linea = "BILLETERA / COMBINACIONES" & "," & _
                                        headerBilleteras(0) & " %" & "," & _
                                        headerBilleteras(1) & " %" & "," & _
                                        headerBilleteras(2) & " %" & "," & _
                                        headerBilleteras(3) & " %" & "," & _
                                        headerBilleteras(4) & " %" & "," & _
                        "ESTADO"
                sw.WriteLine(linea)

                For i As Integer = 0 To nroRegistros - 1
                    linea = CStr(dtbLista.Rows(i)("COMBINACIONES")) & "," & _
                            IIf(IsDBNull(dtbLista.Rows(i)(headerBilleteras(0))), String.Empty, dtbLista.Rows(i)(headerBilleteras(0))) & "," & _
                            IIf(IsDBNull(dtbLista.Rows(i)(headerBilleteras(1))), String.Empty, dtbLista.Rows(i)(headerBilleteras(1))) & "," & _
                            IIf(IsDBNull(dtbLista.Rows(i)(headerBilleteras(2))), String.Empty, dtbLista.Rows(i)(headerBilleteras(2))) & "," & _
                            IIf(IsDBNull(dtbLista.Rows(i)(headerBilleteras(3))), String.Empty, dtbLista.Rows(i)(headerBilleteras(3))) & "," & _
                            IIf(IsDBNull(dtbLista.Rows(i)(headerBilleteras(4))), String.Empty, dtbLista.Rows(i)(headerBilleteras(4))) & "," & _
                            CStr(dtbLista.Rows(i)("ESTADO"))
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
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
            End If
        Catch ex As Threading.ThreadAbortException
        Catch ex As Exception
            sw.Flush()
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Error al exportar carga')</script>")
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_EXP_PORCEN_FACTURACION"), "", "Exportar Reporte Porcentaje Facturación.")
            sw.Close()
        End Try

    End Sub

    Private Sub btnAccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccion.Click
        Try
            Dim dtgItem As DataGridItem
            Dim ListCodigos As String = String.Empty

            For Each dtgItem In dgrGrillaDetalle.Items
                Dim result As Boolean = (CType(dtgItem.FindControl("chkFila"), CheckBox)).Checked
                If (result) Then
                    Dim _codigo As String = dgrGrillaDetalle.DataKeys(dtgItem.ItemIndex).ToString()
                    ListCodigos &= "|" & _codigo
                End If
            Next

            If ListCodigos.Length > 0 Then
                Dim _accion As String = IIf(ddlEstado.SelectedValue.Trim.Equals("1"), "0", "1")
                Dim obj As New LBilletera
                obj.ModificarEstadoBilleteras(ListCodigos, _accion)
                btnBuscar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Error: No se registraron los datos. Vuelva a intentarlo')</script>")
            ElseIf ex.Message.IndexOf("ORA-20661") > -1 Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('" & ConfigurationSettings.AppSettings("msjPorcenFacturacion") & "')</script>")
            Else
                Throw ex
            End If
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_PORCEN_FACTURACION"), "", "Actualizar Estado Porcentaje Facturación.")
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Dim strBilleteras As String = ObtenerBilleteras()
        FillGrilla(strBilleteras)
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
