Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO

Public Class sisact_mant_blacklist_clienruc
    Inherits SisAct_WebBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusquedaTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusquedaNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlBusquedaTipoEmpresa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnEliminar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoEmpresa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtComentario As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkVigenciaIndef As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtVigenciaDias As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsuarioAprobador As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaRegistro As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnTraerCliente As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidEliminar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNroDocuRRLL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnTraerUsuarioNombre As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtBusquedaNroDocuRRLL As System.Web.UI.WebControls.TextBox

    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region
    Private rutaOrigen As String = ConfigurationSettings.AppSettings("consRutaOrigenLpPa")
    Shared CHECKED_ITEMS As String = "CHECKED_ITEMS"
    Shared CHECK_TOTAL As Boolean

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

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnEliminar.Attributes.Add("onclick", "return f_eliminarSeleccionados();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

    End Sub

    Private Sub Limpiar()

            hidTipoDocumento.Value = String.Empty
            hidNroDocumento.Value = String.Empty
            txtNombre.Text = String.Empty
            txtNroDocumento.Text = String.Empty
            txtVigenciaDias.Text = String.Empty
            txtFechaRegistro.Text = Today.ToString("dd/MM/yyyy")
            ddlTipoDocumento.SelectedIndex = -1
            ddlTipoEmpresa.SelectedIndex = -1
            chkVigenciaIndef.Checked = False
            ddlTipoDocumento.Enabled = True
            txtNroDocumento.ReadOnly = False
            ddlTipoDocumento.CssClass = "clsSelectEnable"
            txtNroDocumento.CssClass = "clsInputEnable"
            txtVigenciaDias.CssClass = "clsInputEnable"
            txtComentario.Text = String.Empty
            txtNroDocuRRLL.Text = String.Empty
            txtUsuario.Text = String.Empty
            txtUsuarioAprobador.Text = String.Empty
            txtNombre.ReadOnly = True
            txtNombre.CssClass = "clsInputDisable"

            Session("ITEMS_TOTAL") = Nothing

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()

        dgrGrillaDetalle.DataSource = Nothing
        dgrGrillaDetalle.DataBind()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objWhitelist As Whitelist
        Dim objLBlacklist As LBlacklist
        Dim dt As DataTable
        Try
            objLBlacklist = New LBlacklist
            objWhitelist = New Whitelist
            objWhitelist = objLBlacklist.fwhlTraer(hidTipoDocumento.Value, hidNroDocumento.Value)

            txtNombre.Text = CheckStr(objWhitelist.Nombre)
            txtNroDocumento.Text = CheckStr(objWhitelist.NroDocumento)
            txtUsuario.Text = CheckStr(objWhitelist.UsuarioAprobador)
            txtUsuarioAprobador.Text = CheckStr(objWhitelist.NombreUsuarioAprobador)
            txtVigenciaDias.Text = CheckStr(objWhitelist.VigenciaDias)
            chkVigenciaIndef.Checked = CBool(IIf(objWhitelist.VigenciaIndefinida = "S", True, False))
            ddlTipoDocumento.SelectedValue = CheckStr(objWhitelist.TipoDocumento)
            txtFechaRegistro.Text = CheckStr(objWhitelist.FechaRegistro)
            txtComentario.Text = CheckStr(objWhitelist.ObservacionCredito)
            ddlTipoEmpresa.SelectedValue = CheckStr(objWhitelist.CantidadDias)
            txtNroDocuRRLL.Text = CheckStr(objWhitelist.Estado)

            txtNombre.ReadOnly = False
            txtNombre.CssClass = "clsInputEnable"
            ddlTipoDocumento.Enabled = False
            txtNroDocumento.ReadOnly = True
            ddlTipoDocumento.CssClass = "clsSelectDisable"
            txtNroDocumento.CssClass = "clsInputDisable"

            ViewState("EstadoActual") = "MODIF"

            Dim strRo As String
            If chkVigenciaIndef.Checked Then
                strRo = "fActivarVigencia(true, false);"
            Else
                strRo = "fActivarVigencia(false, false);"
            End If

            ViewState("EstadoActual") = "MODIF"
            RegisterStartupScript("script", "<script>" & strRo & "f_MostrarTab('EDICION')</script>")

        Finally
            objLBlacklist = Nothing
            objWhitelist = Nothing
        End Try
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        ViewState("EstadoActual") = "NUEVO"
        txtUsuario.Text = CurrentUser
        TraerUsuarioNombre()
        RegisterStartupScript("script", "<script>fActivarVigencia(false, false);f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLBlacklist As LBlacklist
        Dim objLWhitelist As LWhitelist
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim whls As Whitelist

        Try
            If TraerUsuarioNombre().Length > 0 Then Exit Sub

            If txtNombre.ReadOnly = True Then
            objLWhitelist = New LWhitelist
            txtNombre.Text = objLWhitelist.fstrClienteTraerNombre(CheckStr(ddlTipoDocumento.SelectedValue), CheckStr(txtNroDocumento.Text.Trim))
            End If

            txtUsuario.Text = CurrentUser
            TraerUsuarioNombre()

            whls = New Whitelist
            whls.CantidadDias = CheckInt(ddlTipoEmpresa.SelectedValue)
            whls.NroDocumento = CheckStr(txtNroDocumento.Text.Trim)
            whls.ObservacionCredito = CheckStr(txtComentario.Text.Trim)
            whls.TipoDocumento = CheckStr(ddlTipoDocumento.SelectedValue)
            whls.UsuarioAprobador = CheckStr(txtUsuario.Text.Trim.ToUpper)
            whls.VigenciaDias = CheckInt(txtVigenciaDias.Text.Trim)
            whls.VigenciaIndefinida = CheckStr(IIf(chkVigenciaIndef.Checked, "S", "N"))
            whls.Nombre = CheckStr(txtNombre.Text.Trim.ToUpper)
            whls.NombreUsuarioAprobador = CheckStr(txtUsuarioAprobador.Text.Trim.ToUpper)
            whls.Estado = CheckStr(txtNroDocuRRLL.Text.Trim)

            objLBlacklist = New LBlacklist

            If hidNroDocumento.Value.Length = 0 Then
                objLBlacklist.fbooInsertar(whls, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_INSERTAR"), "Registrar Cliente en Blacklist.")
            Else
                objLBlacklist.fbooModificar(whls, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_ACTUALIZAR"), "Actualizar Cliente en Blacklist.")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El registro ya existe.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20880") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: La razon social pertenece a otra empresa.')</script>")
            Else
                Throw ex
            End If
        Finally
            objLBlacklist = Nothing
            objLWhitelist = Nothing
            whls = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub Buscar()
        Dim objLBlacklist As LBlacklist
        Dim strTipoDocumento As String = ddlBusquedaTipoDocumento.SelectedValue
        Dim strNroDocumento As String = txtBusquedaNroDocumento.Text.Trim
        Dim strNroDocumentoRRLL As String = txtBusquedaNroDocuRRLL.Text.Trim
        Dim strFechaInicio As String = txtBusquedaFechaInicio.Text
        Dim strFechaFin As String = txtBusquedaFechaFin.Text
        Dim intTipoEmpresa As Integer = CheckInt(ddlBusquedaTipoEmpresa.SelectedValue)
        Dim dtbLista As New DataTable

        Try
            'If Not (strNroDocumento.Length = 0 AndAlso strFechaInicio.Length = 0 AndAlso strFechaFin.Length = 0 AndAlso intTipoEmpresa = 0) Then
            objLBlacklist = New LBlacklist

            'dgrGrillaCabecera.DataSource = ""
            'dgrGrillaCabecera.DataBind()

            dtbLista = objLBlacklist.fdtbListarBusqueda(strTipoDocumento, strNroDocumento, strNroDocumentoRRLL, strFechaInicio, strFechaFin, intTipoEmpresa)
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()
            'End If
            Session("ITEMS_TOTAL") = dtbLista

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
 
        Finally
            objLBlacklist = Nothing
            Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_CONSULTAR"), "Consulta Cliente de Blacklist.")
        End Try
    End Sub

    Private Sub Auditoria(ByVal strCodTrans As String, ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            'Dim usuario_id As String = CurrentUser
            'Dim ipcliente As String = CurrentTerminal
            Dim usuario_id As String = String.Empty
            Dim ipcliente As String = String.Empty

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnTraerCliente_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraerCliente.ServerClick
        Dim pstrTipoDocumento As String = ddlTipoDocumento.SelectedValue
        Dim pstrNroDocumento As String = txtNroDocumento.Text.Trim
        Dim objLWhitelist As LWhitelist
        Try
            If pstrNroDocumento.Length > 0 Then
            objLWhitelist = New LWhitelist
            txtNombre.Text = objLWhitelist.fstrClienteTraerNombre(pstrTipoDocumento, pstrNroDocumento)
            End If
            If ViewState("EstadoActual").ToString = "NUEVO" Then
                If txtNombre.Text.Length = 0 Then
                    txtNombre.ReadOnly = False
                    txtNombre.CssClass = "clsInputEnable"
                Else
                    txtNombre.ReadOnly = True
                    txtNombre.CssClass = "clsInputDisable"
                End If
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
            End If

        Finally
            objLWhitelist = Nothing
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objLBlacklist As LBlacklist
        Dim curSalida As String
        Dim Msg As String
        RememberOldValues()
        Dim strSeleccionados As String = String.Empty
        Dim categoryIDList As New ArrayList
        categoryIDList = CType(Session(CHECKED_ITEMS), ArrayList)
        If Not categoryIDList Is Nothing Then
            For Each strNumero As String In categoryIDList
                strSeleccionados &= "|" & strNumero
            Next
        End If
        Try
            If strSeleccionados.Length > 0 Then
                objLBlacklist = New LBlacklist
                objLBlacklist.fbooEliminarSeleccionados(strSeleccionados, curSalida, Msg)
                btnBuscar_Click(Nothing, Nothing)
                hidEliminar.Value = String.Empty

                Session(CHECKED_ITEMS) = Nothing
            End If

        Finally
            objLBlacklist = Nothing
            Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_ELIMINAR"), "Eliminar Cliente de Blacklist.")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim chkTotal As CheckBox = CType(e.Item.FindControl("chkTotalGrilla"), CheckBox)
            chkTotal.Checked = CHECK_TOTAL
        End If
    End Sub

    Private Sub btnTraerUsuarioNombre_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraerUsuarioNombre.ServerClick
        Dim strAlerta As String = TraerUsuarioNombre()
        If ViewState("EstadoActual").ToString = "NUEVO" Then
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')" & strAlerta & "</script>")
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')" & strAlerta & "</script>")
        End If
    End Sub

    Private Function TraerUsuarioNombre() As String
        Dim objLWhitelist As LWhitelist
        Dim strAlerta As String = String.Empty
        Try
            objLWhitelist = New LWhitelist
            txtUsuarioAprobador.Text = objLWhitelist.fstrUsuarioTraerNombre(txtUsuario.Text.Trim.ToUpper)

            If txtUsuarioAprobador.Text.Length = 0 Then
                strAlerta = ";alert('No existe el usuario')"
            End If
        Catch ex As Exception
            strAlerta = ";alert('No existe el usuario')"
            Throw ex
        Finally
            objLWhitelist = Nothing
        End Try
        Return strAlerta
    End Function

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim flag As Boolean
        Try
            If FileToUpload.Value <> "" Then
                If (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper = ".TXT" OrElse _
                    (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper = ".CSV" Then
                    Dim mensaje As String = ""
                    eliminarArchivo()
                    cargarArchivo()
                    mensaje = procesarArchivo()
                    RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('" & mensaje & "')</script>")

                ElseIf (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".TXT" OrElse _
                        (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".TXT" Then

                    RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe Ingresar un Archivo v�lido con extensi�n .TXT o .CSV')</script>")
                End If
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe Ingresar una Ruta de Archivo v�lida')</script>")
            End If
        Catch ex As Exception
        Finally
            Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_CARGA_FILE"), "Cargar Archivo de Clientes de Blacklist.")
        End Try
    End Sub

    Public Sub cargarArchivo()
        Dim RequestXForm As Object
        Dim objFilex As Object
        Dim strArchivo As String
        Dim strRutaWeb As String

        Try
            'RequestXForm = Server.CreateObject("ABCUpload4.XForm")
            'RequestXForm.AbsolutePath = True
            'RequestXForm.Overwrite = True
            'objFilex = RequestXForm("FileToUpload")(1)
            strArchivo = "Blacklist_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            strRutaWeb = Server.MapPath(rutaOrigen) & "/" & strArchivo

            'objFilex.Save(strRutaWeb)
            'RequestXForm = Nothing
            'objFilex = Nothing
            FileToUpload.PostedFile.SaveAs(strRutaWeb)
            ViewState("File") = strArchivo
        Catch ex As Exception
            Dim mensaje As String = ex.Message
            RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('error al cargar el archivo')</script>")
        End Try
    End Sub

    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoCargados As String
        Dim strArchivoError As String
            strArchivo = Server.MapPath(rutaOrigen) & "\" & "Blacklist_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & "BlacklistReport_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
            'strArchivoError = Server.MapPath(rutaOrigen) & "\" & "error_carga_LpPa_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            If File.Exists(strArchivo) Then
                System.IO.File.Delete(strArchivo)
            End If
            If File.Exists(strArchivoCargados) Then
                System.IO.File.Delete(strArchivoCargados)
            End If
            'If File.Exists(strArchivoError) Then
            '    System.IO.File.Delete(strArchivoError)
            'End If

    End Sub

    Function procesarArchivo() As String
        Dim obj As New ConsumerNegocio
        Dim archivo As String = ViewState("File").ToString
        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)
        Dim strDatos As String = String.Empty
        Dim ErrorFile As String = "Detalle_Carga_ListaPrecio_Errada_" & DateTime.Now.ToString("ddMMyyyy")
        Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & ErrorFile & ".txt"))

        Dim retorno As String
        Try
            Dim correcto As Boolean
            Dim input As String
            input = re.ReadLine()
            Dim contError As Integer = 0
            Dim contCorrecto As Integer = 0
            Dim cadena As String
            Dim longitud As Integer
            While Not input Is Nothing
                strDatos &= "�" & input
                input = re.ReadLine()
            End While
            sw.Close()
            obj.CargaMasiva("B", strDatos)

            re.Close()
            re = Nothing

            retorno = "El archivo se cargo correctamente"
        Catch ex As Exception
            re = Nothing
            sw.Close()
            Dim mensaje As String = ex.Message
            retorno = "error al validar el archivo"
        Finally
            sw.Close()
        End Try

        Return retorno
    End Function

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not Session("ITEMS_TOTAL") Is Nothing Then
            Dim dtbLista As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)
            Dim newFile As String = "BlacklistReport_" & DateTime.Now.ToString("ddMMyyyy")
            Dim Linea As String
            eliminarArchivo()
            Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim totalReg As Integer = dtbLista.Rows.Count

            Try
                If totalReg > 0 Then
                    Linea = "TIPO DOC" & "," & _
                        "NRO DOC" & "," & _
                        "NOMBRE" & "," & _
                        "TIPO EMPR" & "," & _
                        "COMENTARIO" & "," & _
                        "VIGENCIA INDEFINIDA" & "," & _
                        "VIGENCIA DIAS" & "," & _
                        "USUARIO" & "," & _
                        "NOMBRE USUARIO" & "," & _
                        "FECHA"
                    sw.WriteLine(Linea)
                    'Chr(39) & dtbLista.Rows(i)("whlsv_nrodocuform") & "," & _
                    For i As Integer = 0 To totalReg - 1
                        Linea = dtbLista.Rows(i)("bklsc_tipodocudesc") & "," & _
                            dtbLista.Rows(i)("bklsv_nrodocuform") & "," & _
                            dtbLista.Rows(i)("bklsv_nombre") & "," & _
                            dtbLista.Rows(i)("bklsn_tipoempr") & "," & _
                            Chr(34) & dtbLista.Rows(i)("bklsv_comentario") & Chr(34) & "," & _
                            dtbLista.Rows(i)("bklsc_vigeinde") & "," & _
                            dtbLista.Rows(i)("bklsn_vigedias") & "," & _
                            dtbLista.Rows(i)("bklsv_usuaapro") & "," & _
                            dtbLista.Rows(i)("bklsv_nombusuaapro") & "," & _
                            dtbLista.Rows(i)("bklsc_fechregi")

                        sw.WriteLine(Linea)

                    Next

                    sw.Flush()
                    sw.Close()
                    Dim fs As System.IO.FileStream = Nothing

                    fs = System.IO.File.Open(Server.MapPath(rutaOrigen & "/" & newFile & _
                            ".csv"), System.IO.FileMode.Open)
                    Dim btFile(fs.Length) As Byte
                    fs.Read(btFile, 0, fs.Length)
                    fs.Close()
                    eliminarArchivo()
                    With Response
                        .Clear()
                        .AddHeader("Content-disposition", "attachment;filename=" & newFile & ".csv")
                        '.ContentType = "application/octet-stream"
                        .ContentType = "text/csv; charset=iso-8859-1"
                        .BinaryWrite(btFile)
                        .End()
                    End With
                Else
                    RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
                End If
            Catch ex As Threading.ThreadAbortException
            Catch ex As Exception
                sw.Flush()
                RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('Error al exportar carga')</script>")
            Finally
                sw.Close()
                Auditoria(ConfigurationSettings.AppSettings("BL_CODAUDT_EXPORTAR"), "Exportar Archivo Lista de Clientes de Blacklist.")
            End Try
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
        End If
    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        RememberOldValues()
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
        RePopulateValues()
    End Sub

    Private Sub RememberOldValues()
        Dim categoryIDList As New ArrayList
        Dim index As String = ""
        Dim dgritem As DataGridItem
        For Each dgritem In dgrGrillaDetalle.Items
            index = dgrGrillaDetalle.DataKeys(dgritem.ItemIndex).ToString()
            Dim result As Boolean = (CType(dgritem.FindControl("fila"), CheckBox)).Checked
            ' Check in the Session
            If Not Session(CHECKED_ITEMS) Is Nothing Then
                categoryIDList = CType(Session(CHECKED_ITEMS), ArrayList)
            End If
            If result Then
                If Not categoryIDList.Contains(index) Then
                    categoryIDList.Add(index)
                End If
            Else
                categoryIDList.Remove(index)
            End If
            If Not categoryIDList Is Nothing AndAlso categoryIDList.Count > 0 Then
                Session(CHECKED_ITEMS) = categoryIDList
            End If
        Next

    End Sub

    Private Sub RePopulateValues()
        Dim categoryIDList As ArrayList = CType(Session(CHECKED_ITEMS), ArrayList)
        Dim myCheckBox As CheckBox
        Dim dgritem As DataGridItem

        If Not categoryIDList Is Nothing AndAlso categoryIDList.Count > 0 Then
            For Each dgritem In dgrGrillaDetalle.Items
                Dim index As String = dgrGrillaDetalle.DataKeys(dgritem.ItemIndex).ToString()
                If categoryIDList.Contains(index) Then
                    myCheckBox = CType(dgritem.FindControl("fila"), CheckBox)
                    myCheckBox.Checked = True
                End If
            Next
        Else
            For Each dgritem In dgrGrillaDetalle.Items
                myCheckBox = CType(dgritem.FindControl("fila"), CheckBox)
                myCheckBox.Checked = False
            Next
        End If
    End Sub

    Public Sub chkTotalGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim categoryIDList As New ArrayList
        Dim chkTotalGrilla As CheckBox = DirectCast(sender, CheckBox)

        Dim dtbTotal As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)

        If chkTotalGrilla.Checked Then
            For Each ditItem As DataRow In dtbTotal.Rows
                categoryIDList.Add(ditItem(2))
            Next

            CHECK_TOTAL = True
        Else
            CHECK_TOTAL = False
            categoryIDList.Clear()
        End If

        If Not categoryIDList Is Nothing Then
            Session(CHECKED_ITEMS) = categoryIDList
        End If

        RePopulateValues()

        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

End Class
