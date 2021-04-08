Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios

Public Class sisact_mant_camp_kits
    Inherits SisAct_WebBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtPrecio As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCampana As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlKit As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlazo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtInstalacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCFAlquilerKit As System.Web.UI.WebControls.TextBox

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
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
            Dim objLCampanaKit As LCampanaKit


                objLCampanaKit = New LCampanaKit
                ddlCampana.DataValueField = "campv_codigo"
                ddlCampana.DataTextField = "campv_descripcion"
                ddlCampana.DataSource = objLCampanaKit.fdtbListarCampana()
                ddlCampana.DataBind()

                objLCampanaKit = New LCampanaKit
                ddlKit.DataValueField = "kitv_codigo"
                ddlKit.DataTextField = "kitv_descripcion"
                ddlKit.DataSource = objLCampanaKit.fdtbListarKit()
                ddlKit.DataBind()

                objLCampanaKit = New LCampanaKit
                ddlPlazo.DataValueField = "plzac_codigo"
                ddlPlazo.DataTextField = "plzav_descripcion"
                ddlPlazo.DataSource = objLCampanaKit.fdtbListarPlazo()
                ddlPlazo.DataBind()

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
        Try
            hidCodigo.Value = String.Empty
            ddlCampana.SelectedIndex = -1
            ddlKit.SelectedIndex = -1
            ddlPlazo.SelectedIndex = -1
            txtPrecio.Text = String.Empty
            txtInstalacion.Text = String.Empty
            txtCFAlquilerKit.Text = String.Empty
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objLCampanaKit As LCampanaKit
        Dim dt As DataTable

            objLCampanaKit = New LCampanaKit
            dt = New DataTable

            dt = objLCampanaKit.fdtbTraer(hidCodigo.Value)

            ddlCampana.SelectedValue = Convert.ToString(dt.Rows(0)("campv_codigo"))
            ddlKit.SelectedValue = Convert.ToString(dt.Rows(0)("kitv_codigo"))
            ddlPlazo.SelectedValue = Convert.ToString(dt.Rows(0)("plzac_codigo"))
            txtPrecio.Text = Convert.ToString(dt.Rows(0)("ckitn_precio_lista"))
            txtInstalacion.Text = Convert.ToString(dt.Rows(0)("ckitn_precio_inst"))
            txtCFAlquilerKit.Text = Convert.ToString(dt.Rows(0)("CF_ALQUILER_KIT"))

            ddlCampana.CssClass = "clsSelectEnableC"
            ddlCampana.Enabled = False
            ddlKit.CssClass = "clsSelectEnableC"
            ddlKit.Enabled = False
            ddlPlazo.CssClass = "clsSelectEnableC"
            ddlPlazo.Enabled = False

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")

    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()

        ddlCampana.CssClass = "clsSelectEnable0"
        ddlCampana.Enabled = True
        ddlKit.CssClass = "clsSelectEnable0"
        ddlKit.Enabled = True
        ddlPlazo.CssClass = "clsSelectEnable0"
        ddlPlazo.Enabled = True

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objLCampanaKit As LCampanaKit
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean

            objLCampanaKit = New LCampanaKit
            objLCampanaKit.fbooEliminar(hidCodigo.Value, curSalida, Msg)
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampKitDTH_Eliminar"), "Eliminar Campa�a Kit DTH")
            btnBuscar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLCampanaKit As LCampanaKit
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strCampana As String = String.Empty
        Dim strKit As String = String.Empty
        Dim strPlazo As String = String.Empty
        Dim strPrecio As String = String.Empty
        Dim strInstal As String = String.Empty
        Dim strCFAlquilerKit As String = String.Empty

        Try
            strCampana = ddlCampana.SelectedValue
            strKit = ddlKit.SelectedValue
            strPlazo = ddlPlazo.SelectedValue
            strPrecio = txtPrecio.Text
            strInstal = txtInstalacion.Text
            strCFAlquilerKit = txtCFAlquilerKit.Text

            'gaa20120223
            Dim strUsuario As String = Convert.ToString(Session("codUsuarioSisact"))
            'fin gaa20120223

            objLCampanaKit = New LCampanaKit

            If hidCodigo.Value.Length = 0 Then
                objLCampanaKit.fbooInsertar(strCampana, strKit, strPlazo, strPrecio, strInstal, strCFAlquilerKit, _
                    strUsuario, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampKitDTH_Insertar"), "Insertar Campa�a Kit DTH")
            Else
                objLCampanaKit.fbooModificar(hidCodigo.Value, strPrecio, strInstal, strCFAlquilerKit, _
                    strUsuario, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampKitDTH_Modificar"), "Modificar Campa�a Kit DTH")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La descripci�n ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20660") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El c�digo del kit de campa�a ya existe.')</script>")
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
        Dim objLCampanaKit As LCampanaKit
        Dim strDescripcion As String

            strDescripcion = txtBusDescripcion.Text.Trim

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objLCampanaKit = New LCampanaKit

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                dgrGrillaDetalle.DataSource = objLCampanaKit.fdtbListarBusqueda(strDescripcion)
                dgrGrillaDetalle.DataBind()
            End If
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampKitDTH_Consulta"), "Consulta Campa�a Kit DTH")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")

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
