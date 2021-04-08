Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.Text

Public Class sisact_mant_rangos_lcdisponible
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlBusquedaTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBusquedaEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnActivar As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminar As System.Web.UI.WebControls.Button
    Protected WithEvents hidBusqItemsSel As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBusqItems As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCheckTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCambiarEstado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRangoInicial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRangoFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMensajeSISACT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMensajeSMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList

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
        'If Request.QueryString("cu") Is Nothing Then
        '    Response.Write("<script language=javascript>validarUrl();</script>")
        'Else
        '    Response.Write("<script language=javascript>restringirEventos();</script>")
        'End If

        'If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
        '    Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
        '    If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
        '        Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
        '        Response.Redirect(strRutaSite)
        '        Response.End()
        '        Exit Sub
        '    End If
        'End If

        btnAceptar.Attributes.Add("onclick", "return f_Aceptar();")
        btnActivar.Attributes.Add("onclick", "return f_Activar();")
        btnEliminar.Attributes.Add("onclick", "return f_Eliminar();")
    End Sub

    Private Sub Buscar()
        Dim objConsumerNegocio As ConsumerNegocio
        Dim dtResultado As DataTable
        Dim strTipoDocumento As String = ddlBusquedaTipoDocumento.SelectedValue
        Dim strEstado As String = ddlBusquedaEstado.SelectedValue
        Dim strItems As String = String.Empty
        Try
            objConsumerNegocio = New ConsumerNegocio
            dtResultado = objConsumerNegocio.ListarRangoLCDisponible(strTipoDocumento, strEstado)
            dgrGrillaDetalle.DataSource = dtResultado
            dgrGrillaDetalle.DataBind()

            For Each dr As DataRow In dtResultado.Rows
                strItems &= String.Format("[{0}]", dr("rng_codigo"))
            Next

            hidBusqItems.Value = strItems

            ViewState("dtResultado") = dtResultado

            RegisterStartupScript("script", "<script>f_LlenarCheckXPagina();</script>")
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_CON_RANGO_LC"), "", "Consulta LC Disponible. Tipo de Busqueda: " & ddlBusquedaTipoDocumento.SelectedItem.Text)
            objConsumerNegocio = Nothing
            dtResultado = Nothing
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

            hidCheckTotal.Value = String.Empty
            hidBusqItemsSel.Value = String.Empty
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

            If ddlBusquedaEstado.SelectedValue = "1" Then
                hidCambiarEstado.Value = "0"
                btnActivar.Text = "Desactivar"
            Else
                hidCambiarEstado.Value = "1"
                btnActivar.Text = "Activar"
            End If

    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strItemsSel As String = hidBusqItemsSel.Value
        Dim strEstado As String = hidCambiarEstado.Value
        Try
            objConsumerNegocio = New ConsumerNegocio
            objConsumerNegocio.ActivarRangoLCDisponible(strItemsSel, CurrentUser, strEstado)
            btnBuscar_Click(Nothing, Nothing)

            RegisterStartupScript("script1", "<script>alert('Los Datos se Actualizaron satisfactoriamente.')</script>")

        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_RANGO_LC"), "", "Actualización estado de Rango LC Disponible. Items: " & strItemsSel & " Estado: " & strEstado)
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strItemsSel As String = hidBusqItemsSel.Value
        Try
            objConsumerNegocio = New ConsumerNegocio
            objConsumerNegocio.EliminarRangoLCDisponible(strItemsSel)

            btnBuscar_Click(Nothing, Nothing)

            RegisterStartupScript("script1", "<script>alert('Los Datos se Eliminaron satisfactoriamente.')</script>")
  
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_ELIM_RANGO_LC"), "", "Eliminación de Rango LC Disponible. Items: " & strItemsSel)
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strCodigo As String = hidCodigo.Value
        Dim strTipoDocumento As String = ddlTipoDocumento.SelectedValue
        Dim strRangoInicial As String = txtRangoInicial.Text
        Dim strRangoFinal As String = txtRangoFinal.Text
        Dim strMensajeSISACT As String = txtMensajeSISACT.Text.Trim
        Dim strMensajeSMS As String = txtMensajeSMS.Text.Trim
        Dim strEstado As String = ddlEstado.SelectedValue
        Dim strUsuario As String = CurrentUser
        Dim intRetorno As Integer
        Dim strRetorno As String = String.Empty
        Try
            objConsumerNegocio = New ConsumerNegocio

            If strCodigo.Length = 0 Then
                objConsumerNegocio.InsertarRangoLCDisponible(strTipoDocumento, strRangoInicial, strRangoFinal, strMensajeSISACT, strMensajeSMS, strUsuario, intRetorno)
                strRetorno = "f_MostrarTab('NUEVO')"

                InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_INS_RANGO_LC"), "", "Registro Rango LC Disponible. Documento|RangoInicial|RangoFinal: " & strTipoDocumento & "|" & strRangoInicial & "|" & strRangoFinal)
            Else
                objConsumerNegocio.ModificarRangoLCDisponible(strCodigo, strTipoDocumento, strRangoInicial, strRangoFinal, strMensajeSISACT, strMensajeSMS, strEstado, strUsuario, intRetorno)
                strRetorno = "f_MostrarTab('EDICION')"

                InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_MOD_RANGO_LC"), "", "Actualización Rango LC Disponible. Código: " & strCodigo)
            End If

            If intRetorno = 1 Then
                btnBuscar_Click(Nothing, Nothing)

                RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
            Else
                RegisterStartupScript("script1", String.Format("<script>{0}; alert('El rango especificado se solapa con otro ya existente.')</script>", strRetorno))
            End If
  
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim stb As StringBuilder
        Dim dtResultado As DataTable
        Dim intContar As Integer = 0
        Try
            If ViewState("dtResultado") Is Nothing Then
                RegisterStartupScript("script1", "<script>alert('No hay registros a exportar.')</script>")
                Return
            End If

            dtResultado = DirectCast(ViewState("dtResultado"), DataTable)

            intContar = dtResultado.Rows.Count

            If intContar = 0 Then
                RegisterStartupScript("script1", "<script>alert('No hay registros a exportar.')</script>")
                Return
            End If

            stb = New StringBuilder
            stb.Append("<style type='text/css'>.EstiloTablaPlantilla {")
            stb.Append("BORDER-RIGHT: white 1px solid; FONT-SIZE: 10px; BORDER-LEFT: white 1px solid; COLOR: navy; BACKGROUND-REPEAT: repeat-x; FONT-FAMILY: Verdana;")
            stb.Append("TEXT-DECORATION: none")
            stb.Append("}</style>")
            stb.Append("<table class='EstiloTablaPlantilla' cellSpacing='0' cellPadding='0' border='1'>")
            stb.Append("	<tr>")
            stb.Append("		<td align='center' colspan='9'>")
            stb.Append("			<b>RANGOS PARA MOSTRAR LC DISPONIBLE</b>")
            stb.Append("		<td>")
            stb.Append("	</tr>")
            stb.Append("	<tr>")
            stb.Append("		<td><b>ITEM</b></td>")
            stb.Append("		<td><b>TIPO DOCUMENTO</b></td>")
            stb.Append("		<td><b>RANGO INICIAL</b></td>")
            stb.Append("		<td><b>RANGO FINAL</b></td>")
            stb.Append("		<td><b>MENSAJE A MOSTRAR SISACT</b></td>")
            stb.Append("		<td><b>MENSAJE A MOSTRAR SMS</b></td>")
            stb.Append("		<td><b>ESTADO</b></td>")
            stb.Append("		<td><b>USUARIO MODIFICADOR</b></td>")
            stb.Append("		<td><b>FECHA MODIFICACION</b></td>")
            stb.Append("	</tr>")

            For i As Integer = 0 To intContar - 1
                stb.Append("	<tr>")
                stb.Append(String.Format("		<td>{0}</td>", i + 1))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("tdocv_descripcion")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_minimo")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_maximo")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_comentario")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_texto_sms")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_estado_descripcion")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_usuario_mod")))
                stb.Append(String.Format("		<td>{0}</td>", dtResultado.Rows(i)("rng_fecha_mod")))
                stb.Append("	</tr>")
            Next
            stb.Append("</table>")

            Me.EnableViewState = False
            Response.AddHeader("content-disposition", "attachment;filename=myexcel.xls")
            Response.ContentEncoding = System.Text.Encoding.Unicode
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
            Response.Write(stb)
            Response.End()
   
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_EXP_RANGO_LC"), "", "Exportar reporte Rango LC Disponible.")
            dtResultado = Nothing
        End Try
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
