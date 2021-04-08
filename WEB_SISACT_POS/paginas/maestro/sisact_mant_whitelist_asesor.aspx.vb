Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_whitelist_asesor
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtDNI As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombres As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPaterno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaterno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefono As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidOficina As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOficina As System.Web.UI.HtmlControls.HtmlInputHidden

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
    
                Dim oUsuarioNegocio As New LoginUsuarioNegocios
                Dim oUsuario As New Usuario
                oUsuario = oUsuarioNegocio.ConsultaDatosUsuario(CurrentUser())
                hidOficina.Value = oUsuario.OficinaId
                hidTipoOficina.Value = oUsuario.TipoOficinaId
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
      
        End If
        ddlBusqueda.Attributes.Add("onchange", "f_CambiarBusqueda(true);")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()
 
    End Sub

    Private Sub Limpiar()
     
            hidCodigo.Value = String.Empty
            txtDNI.Text = String.Empty
            txtNombres.Text = String.Empty
            txtPaterno.Text = String.Empty
            txtMaterno.Text = String.Empty
            txtTelefono.Text = String.Empty
            ddlEstado.SelectedIndex = -1
   
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()
        RegisterStartupScript("script", "<script>f_MostrarTab('INICIO')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
     
            Dim dt As DataTable = (New LWhitelistAsesor).fdtbTraer(hidCodigo.Value)
            txtDNI.Text = CheckStr(dt.Rows(0)("DNI"))
            txtNombres.Text = CheckStr(dt.Rows(0)("NOMBRES"))
            txtPaterno.Text = CheckStr(dt.Rows(0)("APELLIDO_PATERNO"))
            txtMaterno.Text = CheckStr(dt.Rows(0)("APELLIDO_MATERNO"))
            txtTelefono.Text = CheckStr(dt.Rows(0)("NRO_CELULAR"))
            ddlEstado.SelectedValue = CheckStr(dt.Rows(0)("ESTADO"))
            txtDNI.CssClass = "clsInputDisable"
            txtDNI.ReadOnly = True
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        txtDNI.CssClass = "clsInputEnable"
        txtDNI.ReadOnly = False
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim Msg As String
        Try
            Dim objLAsesorSMS As New LWhitelistAsesor
            objLAsesorSMS.pEliminar(hidCodigo.Value, CurrentUser, Msg)
            btnBuscar_Click(Nothing, Nothing)
      
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("COD_SISACT_MOD_ASESOR"), "", "Modificar Estado Asesor. Id: " & hidCodigo.Value)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDNI As String = String.Empty
        Dim strNombre As String = String.Empty
        Dim strPaterno As String = String.Empty
        Dim strMaterno As String = String.Empty
        Dim strTelefono As String = String.Empty
        Dim strEstado As String = String.Empty
        Try
            strDNI = CheckStr(txtDNI.Text)
            strNombre = CheckStr(txtNombres.Text).ToUpper
            strPaterno = CheckStr(txtPaterno.Text).ToUpper
            strMaterno = CheckStr(txtMaterno.Text).ToUpper
            strTelefono = CheckStr(txtTelefono.Text)
            strEstado = ddlEstado.SelectedValue

            Dim objLAsesorSMS As New LWhitelistAsesor
            If hidCodigo.Value.Length = 0 Then
                objLAsesorSMS.pInsertar(strDNI, strNombre, strPaterno, strMaterno, strTelefono, CurrentUser, hidTipoOficina.Value, hidOficina.Value, Msg)
                InsertarAuditoria(ConfigurationSettings.AppSettings("COD_SISACT_INS_ASESOR"), "", "Insertar Asesor. DNI: " & strDNI)
            Else
                objLAsesorSMS.pModificar(strDNI, strNombre, strPaterno, strMaterno, strTelefono, strEstado, CurrentUser, Msg)
                InsertarAuditoria(ConfigurationSettings.AppSettings("COD_SISACT_MOD_ASESOR"), "", "Modificar Asesor. DNI: " & strDNI)
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")
        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('Error: El dni del asesor ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20771") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('NUEVO');alert('Error: El teléfono ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20772") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El teléfono ya existe.')</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        RegisterStartupScript("script", "<script>f_MostrarTab('INICIO')</script>")
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Try
            Dim strOficina As String = hidOficina.Value
            Dim strDescripcion As String = CheckStr(txtBusDescripcion.Text).ToUpper
            Dim strTipo As String = ddlBusqueda.SelectedValue
            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()
                dgrGrillaDetalle.DataSource = (New LWhitelistAsesor).fdtbListarBusqueda(strTipo, strDescripcion, strOficina)
                dgrGrillaDetalle.DataBind()
            End If
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false)</script>")
        Finally
            InsertarAuditoria(ConfigurationSettings.AppSettings("COD_SISACT_CON_ASESOR"), "", "Consulta Asesor. Tipo de Busqueda: " & ddlBusqueda.SelectedItem.Text)
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
