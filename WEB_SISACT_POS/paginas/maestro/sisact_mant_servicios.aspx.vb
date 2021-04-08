Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_servicios
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidServCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlGrupo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOrden As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIddet As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodBSCS As System.Web.UI.WebControls.TextBox

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
            Dim objLServicio As LServicio
            Dim objLKit As LKit


                objLServicio = New LServicio
                ddlGrupo.DataValueField = "gsrvc_codigo"
                ddlGrupo.DataTextField = "gsrvv_descripcion"
                ddlGrupo.DataSource = objLServicio.fdtbListarGrupoServicio()
                ddlGrupo.DataBind()

                objLServicio = New LServicio
                ddlTipo.DataValueField = "prmtn_codigo_param"
                ddlTipo.DataTextField = "prmtv_descripcion"
                ddlTipo.DataSource = objLServicio.fdtbListarTipo
                ddlTipo.DataBind()

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
            txtCodigo.Text = String.Empty
            txtDescripcion.Text = String.Empty
            ddlEstado.SelectedIndex = -1
            ddlGrupo.SelectedIndex = -1
            txtOrden.Text = String.Empty
            txtIddet.Text = String.Empty
            txtCodBSCS.Text = String.Empty
            ddlTipo.SelectedIndex = -1
  
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLServicio As LServicio
        Dim dt As DataTable
 
            objLServicio = New LServicio
            dt = New DataTable

            dt = objLServicio.fdtbTraer(hidServCodigo.Value)

            txtCodigo.Text = Convert.ToString(dt.Rows(0)("servv_codigo"))
            txtDescripcion.Text = Convert.ToString(dt.Rows(0)("servv_descripcion"))
            ddlGrupo.SelectedValue = Convert.ToString(dt.Rows(0)("gsrvc_codigo"))
            ddlEstado.SelectedValue = Convert.ToString(dt.Rows(0)("servc_estado"))
            txtOrden.Text = Convert.ToString(dt.Rows(0)("servn_orden"))
            txtIddet.Text = Convert.ToString(dt.Rows(0)("servv_iddet"))
            txtCodBSCS.Text = Convert.ToString(dt.Rows(0)("SERVV_ID_BSCS"))
            If Not dt.Rows(0)("tservc_codigo") Is System.DBNull.Value Then
                ddlTipo.SelectedValue = Convert.ToString(dt.Rows(0)("tservc_codigo")).Trim
            Else
                ddlTipo.SelectedIndex = -1
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
   
    End Sub

    Private Sub dgrServicioDetalle_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Dim txtCargoFijo As TextBox

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            txtCargoFijo = DirectCast(e.Item.Cells(4).FindControl("txtCargoFijo"), TextBox)
            txtCargoFijo.Text = e.Item.Cells(3).Text
        End If
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLServicio As LServicio
        Dim curSalida As Integer
        Dim Msg As String
        Dim resultado As Boolean

            objLServicio = New LServicio
            objLServicio.fbooServEliminar(hidServCodigo.Value, Convert.ToString(Session("codUsuarioSisact")), curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantServDTH_Eliminar"), "Eliminar Servicio DTH")
            btnBuscar_Click(Nothing, Nothing)
  
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLServicio As LServicio
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim strIddet As String = String.Empty
        Dim intOrden As Integer = Convert.ToInt32(txtOrden.Text)
        Dim strCodBSCS As String = txtCodBSCS.Text.Trim()

        Try
            strDescripcion = txtDescripcion.Text.Trim.ToUpper
            strIddet = txtIddet.Text.Trim.ToUpper

            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            objLServicio = New LServicio

            If hidServCodigo.Value.Length = 0 Then
                objLServicio.fbooServInsertar(strDescripcion, ddlEstado.SelectedValue, _
                    ddlGrupo.SelectedValue, intOrden, strIddet, ddlTipo.SelectedValue, strUsuario, strCodBSCS, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantServDTH_Insertar"), "Insertar Servicio DTH")
            Else
                objLServicio.fbooServModificar(hidServCodigo.Value, strDescripcion, ddlEstado.SelectedValue, _
                    ddlGrupo.SelectedValue, intOrden, strIddet, ddlTipo.SelectedValue, strUsuario, strCodBSCS, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantServDTH_Modificar"), "Modificar Servicio DTH")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripción ya existe.')</script>")
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
        Dim objLServicio As LServicio
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLServicio = New LServicio

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLServicio.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantServDTH_Consulta"), "Consulta Servicio DTH")

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
