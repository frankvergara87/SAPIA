Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_TipoProducto_Msjs
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
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidServCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodCorreo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodApp As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidTipoClienteCod As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoCli As System.Web.UI.WebControls.DropDownList

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
            Dim objMant As MaestroNegocio


                objMant = New MaestroNegocio
                ddlTipo.DataValueField = "CODIGO"
                ddlTipo.DataTextField = "DESCRIPCION"
                ddlTipo.DataSource = objMant.listarTipoProducto
                ddlTipo.DataBind()

                objMant = New MaestroNegocio
                ddlTipoCli.DataValueField = "CODIGO"
                ddlTipoCli.DataTextField = "DESCRIPCION"
                ddlTipoCli.DataSource = objMant.listarTipoCliente
                ddlTipoCli.DataBind()

                RegisterStartupScript("script", "<script>f_Inicio()</script>")
      
        End If

        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")

        If ddlBusqueda.SelectedValue = "1" Then
            txtBusDescripcion.ReadOnly = True
            txtBusDescripcion.CssClass = "clsInputDisable"
        Else
            txtBusDescripcion.ReadOnly = False
            txtBusDescripcion.CssClass = "clsInputEnable"
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
   
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()
 
    End Sub

    Private Sub Limpiar()
     
            hidServCodigo.Value = String.Empty
            hidTipoClienteCod.Value = String.Empty
            txtBusDescripcion.Text = String.Empty
            txtCodCorreo.Text = String.Empty
            txtCodApp.Text = String.Empty
            ddlTipo.SelectedIndex = -1
            ddlTipoCli.SelectedIndex = -1
    
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objMant As MaestroNegocio
        Dim dt As DataTable
        
            objMant = New MaestroNegocio
            dt = New DataTable

            dt = objMant.listarTipProdMensaje("", hidServCodigo.Value, hidTipoClienteCod.Value)

            txtCodCorreo.Text = Convert.ToString(dt.Rows(0)("CODIGO_MS_CORREO"))
            txtCodApp.Text = Convert.ToString(dt.Rows(0)("CODIGO_MS_APP"))
            ddlTipo.SelectedValue = Convert.ToString(dt.Rows(0)("CODIGO"))
            ddlTipoCli.SelectedValue = Convert.ToString(dt.Rows(0)("CODCLI"))

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
    
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objMant As MaestroNegocio
        Dim curSalida As Integer
        Dim Msg As String
        Dim resultado As Boolean

            objMant = New MaestroNegocio
            objMant.eliminarTipoProdMsj(hidServCodigo.Value, hidTipoClienteCod.Value)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantMsjTipoProd_Eliminar"), "Eliminar msj tipo producto")
            btnBuscar_Click(Nothing, Nothing)
  
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objMant As MaestroNegocio
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strCodCorreo As String = String.Empty
        Dim strCodApp As String = String.Empty

        Try
            strCodCorreo = txtCodCorreo.Text.Trim.ToUpper
            strCodApp = txtCodApp.Text.Trim.ToUpper

            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            objMant = New MaestroNegocio

            If hidServCodigo.Value.Length = 0 Then
                objMant.insertarTipoProdMsj(ddlTipo.SelectedValue, strCodCorreo, strCodApp, ddlTipoCli.SelectedValue)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantMsjTipoProd_Insertar"), "Insertar msj tipo producto")
            Else
                objMant.modificarTipoProdMsj(hidServCodigo.Value, strCodCorreo, strCodApp, hidTipoClienteCod.Value)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantMsjTipoProd_Modificar"), "Modificar msj tipo producto")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Error: El tipo de producto ya existe.')</script>")
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objMant As MaestroNegocio
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objMant = New MaestroNegocio

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objMant.listarTipProdMensaje(strDescripcion, "", "")
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantMsjTipoProd_Consulta"), "Consulta msj tipo producto")
  
    End Sub

    Private Sub Auditoria(ByVal strCodTrans As String, ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub
End Class
