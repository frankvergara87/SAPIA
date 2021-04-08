Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_activar_bolsa_masiva
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroDoc As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtNombres As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtCustcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlGrupoBolsa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBolsa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnModificarEstado As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidBolsa As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidListaPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPDVactual As System.Web.UI.HtmlControls.HtmlInputHidden

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
            Dim objConsumerNegocio As ConsumerNegocio
            Try
                'gaa20131115
                Dim oConsulta As New MaestroNegocio
                'Dim oUsuario As New usuario
                Dim oUsuarioNegocio As New LoginUsuarioNegocios
                'Dim usuario As String = CurrentUser
                'oUsuario = oUsuarioNegocio.ConsultaDatosUsuario(usuario)

                Dim arrPuntoVenta As New ArrayList
                Dim arrListaTipoOficina As New ArrayList
                arrPuntoVenta = oConsulta.ListaPDVUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
                arrListaTipoOficina = oConsulta.ListaTipoOficinaVentaUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

                LlenaCombo(arrListaTipoOficina, ddlCanal, "CODIGO", "DESCRIPCION", False, False)
                ddlCanal.Items.Insert(0, New ListItem("SELECCIONE...", String.Empty))
                'ddlCanal.SelectedIndex = 1

                'Cadena de Punto de Ventas
                Dim strCadenaPuntoVenta As String = ""
                For Each oPuntoVenta As PuntoVenta In arrPuntoVenta
                    strCadenaPuntoVenta = strCadenaPuntoVenta & CheckStr(oPuntoVenta.OVENC_CODIGO) & ";" & CheckStr(oPuntoVenta.OVENV_DESCRIPCION) & ";"
                    strCadenaPuntoVenta = strCadenaPuntoVenta & CheckStr(oPuntoVenta.TOFIC_CODIGO) & ";" & CheckStr(oPuntoVenta.CANAC_CODIGO) & ";"
                    strCadenaPuntoVenta = strCadenaPuntoVenta & CheckStr(oPuntoVenta.OVENC_REGION) & "|"
                Next
                hidListaPuntoVenta.Value = strCadenaPuntoVenta
                'fin gaa20131115
                objConsumerNegocio = New ConsumerNegocio
                ddlGrupoBolsa.DataSource = objConsumerNegocio.ListarGrupoBolsa
                ddlGrupoBolsa.DataValueField = "shbolsa"
                ddlGrupoBolsa.DataTextField = "descripcion"
                ddlGrupoBolsa.DataBind()
                ddlGrupoBolsa.Items.Insert(0, "SELECCIONE...")
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
            Finally
                objConsumerNegocio = Nothing
            End Try
        End If
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objConsumerNegocio As ConsumerNegocio
        Dim intTipoDocumento As Integer
        Dim strNroDocumento As String
        Dim dstResultado As DataSet
        Dim alsListaDocum As ArrayList
        Dim strMostrarNombres As String = String.Empty
        Try
            objConsumerNegocio = New ConsumerNegocio
            alsListaDocum = objConsumerNegocio.ListarTipoDocumento()
            For Each item As TipoDocumento In alsListaDocum
                If item.TDOCC_CODIGO = ddlTipoDocumento.SelectedValue Then
                    intTipoDocumento = CheckInt(item.COD_BSCS)
                End If
            Next

            strNroDocumento = txtNroDoc.Value.Trim
            dstResultado = New DataSet
            objConsumerNegocio = New ConsumerNegocio
            dstResultado = objConsumerNegocio.ListarBolsaMasiva(intTipoDocumento, strNroDocumento)

            If Not dstResultado Is Nothing Then
                If dstResultado.Tables(0).Rows.Count > 0 Then
                    txtNombres.Value = CheckStr(dstResultado.Tables(0).Rows(0)("CCNAME"))
                    strMostrarNombres = "trNombres.style.display = ''; "
                End If
                If dstResultado.Tables(1).Rows.Count > 0 Then
                    dgrGrillaCabecera.DataSource = String.Empty
                    dgrGrillaCabecera.DataBind()
                    dgrGrillaDetalle.DataSource = dstResultado.Tables(1)
                    dgrGrillaDetalle.DataBind()
                End If
            End If

            RegisterStartupScript("script", String.Format("<script>{0}f_MostrarTab('BUSQUEDA')</script>", strMostrarNombres))
        Finally
            objConsumerNegocio = Nothing
            dstResultado = Nothing
            alsListaDocum = Nothing
            Auditoria(ConfigurationSettings.AppSettings("COD_AUDIT_CON_BOLSA_MASIVO"), "Consulta Bolsa. Documento: " & strNroDocumento)
        End Try
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        hidAccion.Value = "A"
        RegisterStartupScript("script", "<script>document.getElementById('ddlBolsa').innerHTML = ''; f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub ddlGrupoBolsa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGrupoBolsa.SelectedIndexChanged
        Dim objConsumerNegocio As ConsumerNegocio
        Try
            objConsumerNegocio = New ConsumerNegocio
            ddlBolsa.DataSource = objConsumerNegocio.ListarTipoBolsa(ddlGrupoBolsa.SelectedValue)
            ddlBolsa.DataValueField = "fu_pack_id"
            ddlBolsa.DataTextField = "descripcion"
            ddlBolsa.DataBind()
            ddlBolsa.Items.Insert(0, "SELECCIONE...")
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        Finally
            objConsumerNegocio = Nothing
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RealizarAccion(txtCustcode.Text.Trim, hidAccion.Value, CheckInt(ddlBolsa.SelectedValue), CheckStr(hidPDVactual.Value))
    End Sub

    Private Sub btnModificarEstado_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarEstado.ServerClick
        RealizarAccion(hidCodigo.Value, hidAccion.Value, CheckInt(hidBolsa.Value), CheckStr(hidPDVactual.Value))
    End Sub

    Private Sub RealizarAccion(ByVal pstrCustcode As String, ByVal pstrAccion As String, ByVal pintBolsa As Integer, ByVal pstrPDV As String)
        Dim objConsumerNegocio As ConsumerNegocio
        Dim strCustCode As String
        Dim strAccion As String
        Dim intBolsa As Integer
        Dim strCodError As String
        Dim strDesError As String
        Dim strPDV As String
        Try
            strCustCode = pstrCustcode
            strAccion = pstrAccion
            intBolsa = pintBolsa
            strPDV = pstrPDV

            objConsumerNegocio = New ConsumerNegocio
            objConsumerNegocio.ProcesarBolsa(strCustCode, strAccion, intBolsa, CurrentUser, strPDV, strCodError, strDesError)

            Limpiar()

            If strCodError = "0" Then
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA'); alert('La operación fue realizado satisfactoriamente.')</script>")
            Else
                RegisterStartupScript("script", String.Format("<script>f_MostrarTab('BUSQUEDA'); alert('{0}')</script>", strDesError))
            End If
        Finally
            objConsumerNegocio = Nothing
            If strAccion = "A" Then
                Auditoria(ConfigurationSettings.AppSettings("COD_AUDIT_INS_BOLSA_MASIVO"), "Insertar Bolsa. Código: " & intBolsa)
            Else
                Auditoria(ConfigurationSettings.AppSettings("COD_AUDIT_ACT_BOLSA_MASIVO"), "Actualizar Bolsa. Código: " & intBolsa)
            End If
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CheckStr(DataBinder.Eval(e.Item.DataItem, "ESTADO")) <> "S" Then
                e.Item.FindControl("imgReactivar").Visible = False
            Else
                e.Item.FindControl("imgSuspender").Visible = False
            End If
            If CheckStr(DataBinder.Eval(e.Item.DataItem, "ESTADO")) = "D" Then
                e.Item.FindControl("imgSuspender").Visible = False
                e.Item.FindControl("imgDesactivar").Visible = False
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        RegisterStartupScript("script", "<script>trNombres.style.display = 'none'; f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub Limpiar()
        txtNroDoc.Value = String.Empty
        txtCustcode.Text = String.Empty
        txtNombres.Value = String.Empty
        ddlGrupoBolsa.SelectedIndex = 0
        ddlBolsa.DataSource = Nothing
        ddlBolsa.DataBind()

        dgrGrillaCabecera.DataSource = Nothing
        dgrGrillaCabecera.DataBind()
        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        hidPDVactual.Value = String.Empty
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnLimpiar_Click(Nothing, Nothing)
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