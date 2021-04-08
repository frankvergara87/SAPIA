Option Strict Off
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_consulta_venta_cuotas
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCustcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlGrupoBolsa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBolsa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtNroDoc As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtIMEI As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtNroLinea As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button

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

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Limpiar()
        txtNroDoc.Value = String.Empty
        txtIMEI.Value = String.Empty
        txtNroLinea.Value = String.Empty

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dgrGrillaDetalle.CurrentPageIndex = 0
        Listar()
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Listar()
    End Sub

    Private Sub Listar()
        Dim objVentaNegocios As VentaNegocios
        Dim dtbLista As DataTable
        Try
            objVentaNegocios = New VentaNegocios
            dtbLista = objVentaNegocios.ConsultaVentaCuotas(ddlTipoDocumento.SelectedValue, txtNroDoc.Value, txtIMEI.Value, txtNroLinea.Value)
            ViewState("ITEMS_TOTAL") = dtbLista
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()

            Dim strTrxDescripcion As String = "Consulta Reporte Venta Cuotas "
            strTrxDescripcion += "[TipoDoc=" & ddlTipoDocumento.SelectedValue
            strTrxDescripcion += "|NroDoc=" & txtNroDoc.Value
            strTrxDescripcion += "|IMEI=" & txtIMEI.Value
            strTrxDescripcion += "|Telefono=" & txtNroLinea.Value & "]"

            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_CON_REPORTE_VENTA_CUOTA"), "", strTrxDescripcion)
        Finally
            objVentaNegocios = Nothing
            dtbLista = Nothing
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not ViewState("ITEMS_TOTAL") Is Nothing Then
            Dim rutaOrigen As String = ConfigurationSettings.AppSettings("consRutaOrigenLpPa")
            Dim newFile As String = "REPORTE_" & DateTime.Now.ToString("ddMMyyyy_HHmmss")
            Dim dtbLista As DataTable = DirectCast(ViewState("ITEMS_TOTAL"), DataTable)
            Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim totalReg As Integer = dtbLista.Rows.Count

            If totalReg = 0 Then
                RegisterStartupScript("script1", "<script>alert('No hay registros a exportar.')</script>")
                Return
            End If

            Dim Linea As String = "DNI/RUC" & "," & _
                "RAZÓN SOCIAL/NOMBRES" & "," & _
                "IMEI" & "," & _
                "MODELO" & "," & _
                "TELEFONO" & "," & _
                "NRO CUOTAS" & "," & _
                "BOLETA/FACTURA" & "," & _
                "PRECIO VENTA" & "," & _
                "PRECIO LISTA"
            sw.WriteLine(Linea)
            For i As Integer = 0 To totalReg - 1
                Linea = dtbLista.Rows(i)("nro_documento") & "," & _
                    Chr(160) & dtbLista.Rows(i)("cliente") & "," & _
                    dtbLista.Rows(i)("imei") & "," & _
                    Chr(160) & dtbLista.Rows(i)("des_equipo") & "," & _
                    dtbLista.Rows(i)("telefono") & "," & _
                    dtbLista.Rows(i)("nro_cuotas") & "," & _
                    dtbLista.Rows(i)("documento_venta") & "," & _
                    dtbLista.Rows(i)("precio_venta") & "," & _
                    dtbLista.Rows(i)("precio_lista")
                sw.WriteLine(Linea)
            Next
            sw.Flush()
            sw.Close()
            Dim fs As System.IO.FileStream = Nothing
            fs = System.IO.File.Open(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), System.IO.FileMode.Open)
            Dim btFile(fs.Length) As Byte
            fs.Read(btFile, 0, fs.Length)
            fs.Close()
            With Response
                .Clear()
                .AddHeader("Content-disposition", "attachment;filename=" & newFile & ".csv")
                .ContentType = "text/csv; charset=iso-8859-1"
                .BinaryWrite(btFile)
                .End()
            End With

            Dim strTrxDescripcion As String = "Exportar Reporte Venta Cuotas "
            strTrxDescripcion += "[TipoDoc=" & ddlTipoDocumento.SelectedValue
            strTrxDescripcion += "|NroDoc=" & txtNroDoc.Value
            strTrxDescripcion += "|IMEI=" & txtIMEI.Value
            strTrxDescripcion += "|Telefono=" & txtNroLinea.Value & "]"

            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_EXP_REPORTE_VENTA_CUOTA"), "", strTrxDescripcion)
        Else
            RegisterStartupScript("script1", "<script>alert('No hay registros a exportar.')</script>")
        End If
    End Sub

    Private Sub InsertarAuditoria(ByVal strCodigoEvento As String, ByVal strTelefono As String, ByVal strTexto As String)
        Try
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim ipcliente As String = CurrentTerminal
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim usuario_id As String = CurrentUser

            Dim objAudi As New AuditoriaNegocio
            objAudi.registrarAuditoria(strCodigoEvento, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, strTelefono, "0", strTexto)
        Catch ex As Exception

        End Try
    End Sub

End Class
