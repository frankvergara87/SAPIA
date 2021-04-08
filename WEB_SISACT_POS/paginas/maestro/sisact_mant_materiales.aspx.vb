Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_materiales
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
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtIddet As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipo As System.Web.UI.WebControls.DropDownList

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
            Dim objLMaterial As LMaterial
            'gaa20120518
            objLMaterial = New LMaterial
            ddlTipo.DataValueField = "codigo"
            ddlTipo.DataTextField = "descripcion"
            ddlTipo.DataSource = objLMaterial.fdtbListarTipoMaterial()
            ddlTipo.DataBind()
            'fin gaa20120518
            Try
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
  
            Finally
                objLMaterial = Nothing
            End Try
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

            hidCodigo.Value = String.Empty
            txtCodigo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            ddlEstado.SelectedIndex = -1
            txtIddet.Text = String.Empty
            'gaa20120518
            ddlTipo.SelectedIndex = -1
            'fin gaa20120518

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLMaterial As LMaterial
        Dim dt As DataTable
 
            objLMaterial = New LMaterial
            dt = New DataTable

            dt = objLMaterial.fdtbTraer(hidCodigo.Value)

            txtCodigo.Text = Convert.ToString(dt.Rows(0)("matv_codigo"))
            txtDescripcion.Text = Convert.ToString(dt.Rows(0)("matv_descripcion"))
            ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("matc_estado"))
            txtIddet.Text = Convert.ToString(dt.Rows(0)("matv_iddet"))
            'gaa20120518
            ddlTipo.SelectedValue = Convert.ToString(dt.Rows(0)("TMATC_CODIGO"))
            'fin gaa20120518
            txtCodigo.CssClass = "clsInputDisable"
            txtCodigo.ReadOnly = True

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
  
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()

        txtCodigo.CssClass = "clsInputEnable"
        txtCodigo.ReadOnly = False

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLMaterial As LMaterial
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean

            objLMaterial = New LMaterial
            objLMaterial.fbooEliminar(hidCodigo.Value, Convert.ToString(Session("codUsuarioSisact")), curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantMaterDTH_Eliminar"), "Eliminar Material DTH")
            btnBuscar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLMaterial As LMaterial
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strCodigo As String = String.Empty
        Dim strDescripcion As String = String.Empty
        Dim strIddet As String = String.Empty

        Try
            strCodigo = txtCodigo.Text.Trim.ToUpper
            strDescripcion = txtDescripcion.Text.Trim.ToUpper
            strIddet = txtIddet.Text.Trim.ToUpper

            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            objLMaterial = New LMaterial

            If hidCodigo.Value.Length = 0 Then
                objLMaterial.fbooInsertar(strCodigo, strDescripcion, ddlEstado.SelectedValue, _
                    strIddet, ddlTipo.SelectedValue, strUsuario, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantMaterDTH_Insertar"), "Insertar Material DTH")
            Else
                objLMaterial.fbooModificar(hidCodigo.Value, strDescripcion, ddlEstado.SelectedValue, _
                    strIddet, ddlTipo.SelectedValue, strUsuario, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantMaterDTH_Modificar"), "Modificar Material DTH")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripción ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20660") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El código del material ya existe.')</script>")
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
        Dim objLMaterial As LMaterial
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLMaterial = New LMaterial

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLMaterial.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantMaterDTH_Consulta"), "Consulta Material DTH")

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
