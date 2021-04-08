Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades

Public Class sisact_mant_campana
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
    Protected WithEvents txtBus As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlProductoPadre As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProductoHija As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCampanaPadre As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCampanaHija As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFin As System.Web.UI.WebControls.TextBox

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

                RegisterStartupScript("script", "<script>f_Inicio()</script>")
   
        End If

        dgrGrillaDetalle.Style.Add("table-layout", "fixed")
        ddlBusqueda.Attributes.Add("onchange", "f_InactivarTxtLista(); setValue('txtBus', '');")
        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")

        If ddlBusqueda.SelectedValue = "1" Then
            txtBus.ReadOnly = True
            txtBus.CssClass = "clsInputDisable"
        Else
            txtBus.ReadOnly = False
            txtBus.CssClass = "clsInputEnable"
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

    End Sub

    Private Sub Limpiar()

            hidCodigo.Value = String.Empty

            Dim objMaestroNegocio As New MaestroNegocio
            Dim itmSeleccione As New ItemGenerico
            itmSeleccione.Codigo = "-1"
            itmSeleccione.Descripcion = "Seleccione..."
            Dim arrListaCombo As ArrayList
            arrListaCombo = objMaestroNegocio.ListaTiposProducto()
            arrListaCombo.Insert(0, itmSeleccione)

            ddlProductoPadre.DataValueField = "Codigo"
            ddlProductoPadre.DataTextField = "Descripcion"
            ddlProductoPadre.DataSource = arrListaCombo
            ddlProductoPadre.DataBind()

            ddlProductoHija.DataValueField = "Codigo"
            ddlProductoHija.DataTextField = "Descripcion"
            ddlProductoHija.DataSource = arrListaCombo
            ddlProductoHija.DataBind()

            ddlProductoPadre.ClearSelection()
            ddlProductoHija.ClearSelection()
            txtDescripcion.Text = String.Empty

            ddlCampanaPadre.DataSource = Nothing
            ddlCampanaPadre.DataBind()

            ddlCampanaHija.DataSource = Nothing
            ddlCampanaHija.DataBind()

            'ddlEstado.SelectedIndex = -1

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA'); f_InactivarTxtLista()</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objMaestroNegocio As MaestroNegocio
        Dim arrAC As ArrayList
 
            objMaestroNegocio = New MaestroNegocio


            Dim objAsociacionCampana As AsociacionCampana


            arrAC = objMaestroNegocio.ListaAsociacionCampana(hidCodigo.Value, Nothing, Nothing, Nothing, Nothing)

            objAsociacionCampana = CType(arrAC(0), AsociacionCampana)

            ddlEstado.SelectedValue = objAsociacionCampana.ESTADO
            ''
            Dim itmSeleccione As New ItemGenerico
            itmSeleccione.Codigo = "-1"
            itmSeleccione.Descripcion = "Seleccione..."
            Dim arrListaCombo As ArrayList
            arrListaCombo = objMaestroNegocio.ListaTiposProducto()
            arrListaCombo.Insert(0, itmSeleccione)

            ddlProductoPadre.DataValueField = "Codigo"
            ddlProductoPadre.DataTextField = "Descripcion"
            ddlProductoPadre.DataSource = arrListaCombo
            ddlProductoPadre.DataBind()

            ddlProductoHija.DataValueField = "Codigo"
            ddlProductoHija.DataTextField = "Descripcion"
            ddlProductoHija.DataSource = arrListaCombo
            ddlProductoHija.DataBind()


            ddlProductoPadre.SelectedValue = objAsociacionCampana.TIPO_PRODUCTO_PADRE
            ddlProductoHija.SelectedValue = objAsociacionCampana.TIPO_PRODUCTO_HIJA
            Dim objCampana As New MaestroNegocio
            ''''
            ddlCampanaPadre.DataValueField = "COD_ASOCIACION"
            ddlCampanaPadre.DataTextField = "CAMPANA_PADRE"

            ddlCampanaPadre.DataSource = objCampana.ListaCampana(ddlProductoPadre.SelectedValue)
            ddlCampanaPadre.DataBind()
            ''''
            ddlCampanaHija.DataValueField = "COD_ASOCIACION"
            ddlCampanaHija.DataTextField = "CAMPANA_PADRE"

            ddlCampanaHija.DataSource = objCampana.ListaCampana(ddlProductoHija.SelectedValue)
            ddlCampanaHija.DataBind()
            ''''
            ddlCampanaPadre.SelectedValue = objAsociacionCampana.CAMPANA_PADRE
            ddlCampanaHija.SelectedValue = objAsociacionCampana.CAMPANA_HIJA
            txtDescripcion.Text = objAsociacionCampana.DESCRIPCION

            txtFechaInicio.Text = objAsociacionCampana.FECHA_INICIO.ToShortDateString()
            txtFechaFin.Text = objAsociacionCampana.FECHA_FIN.ToShortDateString()


            ddlProductoPadre.CssClass = "clsInputDisable"
            ddlProductoPadre.Enabled = False

            ddlProductoHija.CssClass = "clsInputDisable"
            ddlProductoHija.Enabled = False

            ddlCampanaPadre.CssClass = "clsInputDisable"
            ddlCampanaPadre.Enabled = False

            ddlCampanaHija.CssClass = "clsInputDisable"
            ddlCampanaHija.Enabled = False

            txtDescripcion.ReadOnly = True
            ddlEstado.Visible = True

            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
  
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()

        ddlEstado.Visible = False
        txtDescripcion.ReadOnly = False
        'txtDescripcion.Enabled = True

        Dim objMaestroNegocio As New MaestroNegocio
        Dim itmSeleccione As New ItemGenerico
        itmSeleccione.Codigo = "-1"
        itmSeleccione.Descripcion = "Seleccione..."
        Dim arrListaCombo As ArrayList
        arrListaCombo = objMaestroNegocio.ListaTiposProducto()
        arrListaCombo.Insert(0, itmSeleccione)

        ddlProductoPadre.DataValueField = "Codigo"
        ddlProductoPadre.DataTextField = "Descripcion"
        ddlProductoPadre.DataSource = arrListaCombo
        ddlProductoPadre.DataBind()

        ddlProductoHija.DataValueField = "Codigo"
        ddlProductoHija.DataTextField = "Descripcion"
        ddlProductoHija.DataSource = arrListaCombo
        ddlProductoHija.DataBind()

        ddlCampanaPadre.Items.Clear()
        ddlCampanaPadre.DataSource = Nothing
        ddlCampanaPadre.DataBind()

        ddlCampanaHija.Items.Clear()
        ddlCampanaHija.DataSource = Nothing
        ddlCampanaHija.DataBind()

        ddlCampanaPadre.CssClass = "clsInputEnable"
        ddlCampanaPadre.Enabled = True

        ddlCampanaHija.CssClass = "clsInputEnable"
        ddlCampanaHija.Enabled = True

        ddlProductoPadre.CssClass = "clsInputEnable"
        ddlProductoPadre.Enabled = True

        ddlProductoHija.CssClass = "clsInputEnable"
        ddlProductoHija.Enabled = True


        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick
        Dim objMaestroNegocio As MaestroNegocio
        Dim Msg As String
        Dim resultado As Boolean

            objMaestroNegocio = New MaestroNegocio
            objMaestroNegocio.EliminarAsociacionCampana(Integer.Parse(hidCodigo.Value))

            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDep_Elimina"), "Elimina Campaña Dependiente Id: " & hidCodigo.Value)

            btnBuscar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objMaestroNegocio As MaestroNegocio
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim strCampanaPadre As String = String.Empty
        Dim strCampanaHija As String = String.Empty
        Dim strProductoPadre As String = String.Empty
        Dim strProductoHija As String = String.Empty
        Dim strFechaInicio As String = String.Empty
        Dim strFechaFin As String = String.Empty
        Dim strEstado As String = String.Empty

        Try
            strDescripcion = txtDescripcion.Text.Trim.ToUpper
            strCampanaPadre = ddlCampanaPadre.SelectedValue
            strCampanaHija = ddlCampanaHija.SelectedValue
            strProductoPadre = ddlProductoPadre.SelectedValue
            strProductoHija = ddlProductoHija.SelectedValue
            strFechaInicio = txtFechaInicio.Text.Trim
            strFechaFin = txtFechaFin.Text.Trim
            strEstado = ddlEstado.SelectedValue

            Dim strUsuario As String = CurrentUser

            objMaestroNegocio = New MaestroNegocio

            If hidCodigo.Value.Length = 0 Then
                Dim objAsociacionCampana As New AsociacionCampana
                objAsociacionCampana.DESCRIPCION = strDescripcion
                objAsociacionCampana.CAMPANA_PADRE = strCampanaPadre
                objAsociacionCampana.CAMPANA_HIJA = strCampanaHija
                objAsociacionCampana.TIPO_PRODUCTO_PADRE = strProductoPadre
                objAsociacionCampana.TIPO_PRODUCTO_HIJA = strProductoHija
                objAsociacionCampana.FECHA_INICIO = Date.Parse(strFechaInicio)
                objAsociacionCampana.FECHA_FIN = Date.Parse(strFechaFin)

                objMaestroNegocio.GrabarAsociacionCampana(objAsociacionCampana)

                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDep_Inserta"), "Registra Campaña Dependiente CAMPANA_PADRE: " & strCampanaPadre & " CAMPANA_HIJA:" & strCampanaHija)
            Else
                Dim objAsociacionCampana As New AsociacionCampana
                objAsociacionCampana.COD_ASOCIACION = hidCodigo.Value
                objAsociacionCampana.FECHA_FIN = Date.Parse(strFechaFin)
                objAsociacionCampana.ESTADO = strEstado
                objMaestroNegocio.ActualizarAsociacionCampana(objAsociacionCampana)

                Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDep_Modifica"), "Modifica Campaña Dependiente Estado: " & strEstado & " FECHA_FIN:" & strFechaFin)
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
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Private Sub Buscar()
        Dim objMaestroNegocio As MaestroNegocio
        Dim strDescripcion As String
        Dim strTipo As String
        Dim i As Integer

        ddlCampanaPadre.ClearSelection()
        ddlCampanaPadre.Items.Clear()
        ddlCampanaPadre.DataSource = Nothing
        ddlCampanaPadre.DataBind()
        ddlCampanaHija.ClearSelection()
        ddlCampanaHija.Items.Clear()
        ddlCampanaHija.DataSource = Nothing
        ddlCampanaHija.DataBind()

            strDescripcion = txtBus.Text.Trim.ToUpper
            strTipo = ddlBusqueda.SelectedValue

            If ddlBusqueda.SelectedValue <> "0" OrElse strDescripcion.Length > 0 Then
                objMaestroNegocio = New MaestroNegocio

                dgrGrillaCabecera.DataSource = ""
                dgrGrillaCabecera.DataBind()

                Dim objResultados As ArrayList
                If ddlBusqueda.SelectedValue = "P" Then
                    objResultados = objMaestroNegocio.ListaAsociacionCampana(Nothing, txtBus.Text, Nothing, Nothing, Nothing)
                ElseIf ddlBusqueda.SelectedValue = "C" Then
                    objResultados = objMaestroNegocio.ListaAsociacionCampana(Nothing, Nothing, txtBus.Text, Nothing, Nothing)
                ElseIf ddlBusqueda.SelectedValue = "F" Then
                    objResultados = objMaestroNegocio.ListaAsociacionCampana(Nothing, Nothing, Nothing, txtBus.Text, Nothing)
                ElseIf ddlBusqueda.SelectedValue = "N" Then
                    objResultados = objMaestroNegocio.ListaAsociacionCampana(Nothing, Nothing, Nothing, Nothing, txtBus.Text)
                Else
                    objResultados = objMaestroNegocio.ListaAsociacionCampana(hidCodigo.Value, Nothing, Nothing, Nothing, Nothing)
                End If
                For i = 0 To objResultados.Count - 1
                    If (CType(objResultados(i), AsociacionCampana).ESTADO = "1") Then
                        CType(objResultados(i), AsociacionCampana).ESTADO = "Activo"
                    Else
                        CType(objResultados(i), AsociacionCampana).ESTADO = "Inactivo"
                    End If

                Next
                dgrGrillaDetalle.DataSource = objResultados
                dgrGrillaDetalle.DataBind()
            End If

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');f_InactivarTxtLista()</script>")
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantCampDep_Consulta"), "Buscar Campaña Dependiente: " & txtBus.Text)
  
    End Sub

    Private Sub ddlProductoPadre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductoPadre.SelectedIndexChanged
        ddlCampanaPadre.DataValueField = "COD_ASOCIACION"
        ddlCampanaPadre.DataTextField = "CAMPANA_PADRE"

        Dim objCampana As New MaestroNegocio

        ddlCampanaPadre.Items.Clear()
        ddlCampanaPadre.DataSource = Nothing
        ddlCampanaPadre.DataBind()

        If (ddlProductoPadre.SelectedValue <> "-1") Then
            ddlCampanaPadre.DataSource = objCampana.ListaCampana(ddlProductoPadre.SelectedValue)
            ddlCampanaPadre.DataBind()
        End If

        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub ddlProductoHija_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductoHija.SelectedIndexChanged
        ddlCampanaHija.DataValueField = "COD_ASOCIACION"
        ddlCampanaHija.DataTextField = "CAMPANA_PADRE"

        Dim objCampana As New MaestroNegocio

        ddlCampanaHija.Items.Clear()
        ddlCampanaHija.DataSource = Nothing
        ddlCampanaHija.DataBind()

        If (ddlProductoHija.SelectedValue <> "-1") Then
            ddlCampanaHija.DataSource = objCampana.ListaCampana(ddlProductoHija.SelectedValue)
            ddlCampanaHija.DataBind()
        End If
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
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
