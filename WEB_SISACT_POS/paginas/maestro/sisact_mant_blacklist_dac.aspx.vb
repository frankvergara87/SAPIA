Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_blacklist_dac
    Inherits SisAct_WebBase 'System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabeceraEdicion As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalleEdicion As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnBusBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnBusLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlBusDepartamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlDepartamento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidBusqItems As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBusqItemsSel As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCheckTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBusqItemsCons As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBusqItemsSelCons As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCheckTotalCons As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEliminarCons As System.Web.UI.WebControls.Button

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

        If Not Page.IsPostBack Then
            Dim tablas() As Integer = {5}
            Dim objLMaestro As New MaestroNegocio
            Dim htbListas As New Hashtable
            Dim alsLista As ArrayList

            Try
                htbListas = objLMaestro.ListarItemsGenericos(tablas)

                alsLista = CType(htbListas(5), ArrayList)
                alsLista.Insert(0, New Departamento(String.Empty, "--Seleccionar--", ""))

                With ddlBusDepartamento
                    .DataSource = alsLista
                    .DataValueField = "DEPAC_CODIGO"
                    .DataTextField = "DEPAV_DESCRIPCION"
                    .DataBind()
                End With

                With ddlDepartamento
                    .DataSource = alsLista
                    .DataValueField = "DEPAC_CODIGO"
                    .DataTextField = "DEPAV_DESCRIPCION"
                    .DataBind()
                End With

                RegisterStartupScript("script", "<script>f_Inicio()</script>")
            Finally
                objLMaestro = Nothing
            End Try
        End If

        btnEliminarCons.Attributes.Add("onclick", "return f_EliminarCons();")

    End Sub

    Private Sub btnBusBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusBuscar.Click
            hidCheckTotalCons.Value = String.Empty
            hidBusqItemsSelCons.Value = String.Empty
            dgrGrillaDetalle.CurrentPageIndex = 0
            BuscarCons()
    End Sub

    Private Sub btnBusLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusLimpiar.Click
        Limpiar()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub Limpiar()
        txtBusDescripcion.Text = String.Empty
        ddlBusDepartamento.SelectedIndex = 0
        txtDescripcion.Text = String.Empty
        ddlDepartamento.SelectedIndex = 0
        hidCodigo.Value = String.Empty
        hidBusqItems.Value = String.Empty
        hidBusqItemsCons.Value = String.Empty
        hidBusqItemsSel.Value = String.Empty
        hidBusqItemsSelCons.Value = String.Empty
        hidCheckTotal.Value = String.Empty
        hidCheckTotalCons.Value = String.Empty
    End Sub

    Private Sub BuscarCons()
        Dim objLBlacklistDAC As LBlacklistDAC
        Dim strDescripcion As String = txtBusDescripcion.Text.Trim
        Dim dtResultado As DataTable
        Dim strItems As String = String.Empty
        Try
            objLBlacklistDAC = New LBlacklistDAC
            dgrGrillaCabecera.DataSource = String.Empty
            dgrGrillaCabecera.DataBind()
            dtResultado = objLBlacklistDAC.fdtbListarBusqueda(strDescripcion, ddlBusDepartamento.SelectedValue)
            dgrGrillaDetalle.DataSource = dtResultado
            dgrGrillaDetalle.DataBind()

            For Each dr As DataRow In dtResultado.Rows
                strItems &= String.Format("[{0}]", dr("ovenc_codigo"))
            Next

            hidBusqItemsCons.Value = strItems

            RegisterStartupScript("script", "<script>f_LlenarCheckXPagina('Cons');</script>")
        Finally
            objLBlacklistDAC = Nothing
        End Try
    End Sub

    Private Sub dgrGrillaDetalleEdicion_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalleEdicion.PageIndexChanged
        dgrGrillaDetalleEdicion.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        BuscarCons()
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        btnLimpiar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            hidCheckTotal.Value = String.Empty
            hidBusqItemsSel.Value = String.Empty
            dgrGrillaDetalleEdicion.CurrentPageIndex = 0
            Buscar()
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_CON_BL_CUOTA_DAC"), "", "Consulta BlackList Cuotas DAC.")
        End Try
    End Sub

    Private Sub Buscar()
        Dim objLBlacklistDAC As LBlacklistDAC
        Dim strDescripcion As String = txtDescripcion.Text.Trim
        Dim dtResultado As DataTable
        Dim strItems As String = String.Empty
        Try
            objLBlacklistDAC = New LBlacklistDAC
            dgrGrillaCabeceraEdicion.DataSource = String.Empty
            dgrGrillaCabeceraEdicion.DataBind()
            dtResultado = objLBlacklistDAC.fdtbListarDAC(strDescripcion, ddlDepartamento.SelectedValue)
            dgrGrillaDetalleEdicion.DataSource = dtResultado
            dgrGrillaDetalleEdicion.DataBind()

            For Each dr As DataRow In dtResultado.Rows
                strItems &= String.Format("[{0}]", dr("ovenc_codigo"))
            Next

            hidBusqItems.Value = strItems

            RegisterStartupScript("script", "<script>f_LlenarCheckXPagina('');</script>")
        Finally
            objLBlacklistDAC = Nothing
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaCabeceraEdicion.DataSource = Nothing
        dgrGrillaCabeceraEdicion.DataBind()

        dgrGrillaDetalleEdicion.DataSource = Nothing
        dgrGrillaDetalleEdicion.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLBlacklistDAC As LBlacklistDAC
        Dim strMsg As String = String.Empty
        Try
            If hidBusqItemsSel.Value.Length > 0 Then
                objLBlacklistDAC = New LBlacklistDAC
                objLBlacklistDAC.fbooInsertar(hidBusqItemsSel.Value, CurrentUser, strMsg)
                hidBusqItemsSel.Value = String.Empty
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA'); alert('Se realizó el registro de los DACs satisfactoriamente.')</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO'); alert('No existen DACs a registrar.')</script>")
            End If
        Catch ex As Exception
            RegisterStartupScript("script", String.Format("<script>alert('{0}')</script>", strMsg))
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_INS_BL_CUOTA_DAC"), "", "Registro BlackList Cuotas DAC.")
            objLBlacklistDAC = Nothing
        End Try
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLBlacklistDAC As LBlacklistDAC
        Dim strMsg As String = String.Empty
        Dim Msg As String

        Try
            objLBlacklistDAC = New LBlacklistDAC
            objLBlacklistDAC.fbooEliminar(hidCodigo.Value, strMsg)

            btnBusBuscar_Click(Nothing, Nothing)

            RegisterStartupScript("script1", "<script>alert('Los Datos se Eliminaron satisfactoriamente.')</script>")
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_ELIM_BL_CUOTA_DAC"), "", "Eliminar BlackList Cuotas DAC. Id: " & hidCodigo.Value)
        End Try

    End Sub

    Private Sub btnEliminarCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCons.Click
        Dim objLBlacklistDAC As LBlacklistDAC
        Dim strItemsSel As String = hidBusqItemsSelCons.Value
        Try
            objLBlacklistDAC = New LBlacklistDAC
            objLBlacklistDAC.fbooEliminarRango(strItemsSel)

            btnBusBuscar_Click(Nothing, Nothing)

            RegisterStartupScript("script1", "<script>alert('Los Datos se Eliminaron satisfactoriamente.')</script>")
        Finally
            objLBlacklistDAC = Nothing
            InsertarAuditoria(ConfigurationSettings.AppSettings("AUDIT_ELIM_BL_CUOTA_DAC"), "", "Eliminar BlackList Cuotas DAC.")
        End Try
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
