Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO

Public Class sisact_mant_empresa_top
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnTraerCliente As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFechaRegistro As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoEmpresa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRanking As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlBusquedaTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusquedaNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidEliminar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtBusquedaRangoInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaRangoFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkVigenciaIndef As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtVigenciaDias As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtBusquedaNombre As System.Web.UI.WebControls.TextBox
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
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
            txtRanking.Text = String.Empty
            ddlTipoEmpresa.SelectedIndex = -1
            chkVigenciaIndef.Checked = False
            ddlTipoDocumento.Enabled = True
            txtNroDocumento.ReadOnly = False
            ddlTipoDocumento.CssClass = "clsSelectEnable"
            txtNroDocumento.CssClass = "clsInputEnable"
            txtVigenciaDias.CssClass = "clsInputEnable"
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
        Dim objLEmpresaTop As LEmpresaTop
        Dim dt As DataTable
        Try
            objLEmpresaTop = New LEmpresaTop
            objWhitelist = New Whitelist
            objWhitelist = objLEmpresaTop.fwhlTraer(hidTipoDocumento.Value, hidNroDocumento.Value)

            txtNombre.Text = CheckStr(objWhitelist.Nombre)
            txtNroDocumento.Text = CheckStr(objWhitelist.NroDocumento)
            txtVigenciaDias.Text = CheckStr(objWhitelist.VigenciaDias)
            chkVigenciaIndef.Checked = CBool(IIf(objWhitelist.VigenciaIndefinida = "S", True, False))
            ddlTipoDocumento.SelectedValue = CheckStr(objWhitelist.TipoDocumento)
            ddlTipoEmpresa.SelectedValue = CheckStr(objWhitelist.Estado)
            txtFechaRegistro.Text = CheckStr(objWhitelist.FechaRegistro)
            txtRanking.Text = CheckStr(objWhitelist.CantidadDias)

            ddlTipoDocumento.Enabled = False
            txtNroDocumento.ReadOnly = True
            ddlTipoDocumento.CssClass = "clsSelectDisable"
            txtNroDocumento.CssClass = "clsInputDisable"
            txtNombre.ReadOnly = False
            txtNombre.CssClass = "clsInputEnable"

            If txtFechaRegistro.Text.Length = 0 Then
                txtFechaRegistro.Text = Today.ToString("dd/MM/yyyy")
            End If

            Dim strRo As String
            If chkVigenciaIndef.Checked Then
                txtVigenciaDias.CssClass = "clsInputDisable"
                strRo = "fActivarVigencia(true, false);"
            Else
                txtVigenciaDias.CssClass = "clsInputEnable"
                strRo = "fActivarVigencia(false, false);"
            End If

            ViewState("EstadoActual") = "MODIF"
            RegisterStartupScript("script", "<script>" & strRo & "f_MostrarTab('EDICION')</script>")
   
        Finally
            objWhitelist = Nothing
            objLEmpresaTop = Nothing
        End Try
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        ViewState("EstadoActual") = "NUEVO"
        RegisterStartupScript("script", "<script>fActivarVigencia(false, false);f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objLEmpresaTop As LEmpresaTop
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim whls As Whitelist

        Try
            whls = New Whitelist
            whls.CantidadDias = CheckInt(txtRanking.Text.Trim)
            whls.NroDocumento = CheckStr(txtNroDocumento.Text.Trim)
            whls.TipoDocumento = CheckStr(ddlTipoDocumento.SelectedValue)
            whls.UsuarioAprobador = CheckStr(Session("codUsuarioSisact"))
            whls.VigenciaDias = CheckInt(txtVigenciaDias.Text.Trim)
            whls.VigenciaIndefinida = CheckStr(IIf(chkVigenciaIndef.Checked, "S", "N"))
            whls.Nombre = CheckStr(txtNombre.Text.Trim.ToUpper)
            whls.Estado = CheckStr(ddlTipoEmpresa.SelectedValue)

            objLEmpresaTop = New LEmpresaTop

            If hidNroDocumento.Value.Length = 0 Then
                objLEmpresaTop.fbooInsertar(whls, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_INSERTAR"), "Registrar Empresa Top.")
            Else
                objLEmpresaTop.fbooModificar(whls, curSalida, Msg)
                Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_ACTUALIZAR"), "Actualizar Empresa Top.")
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
            whls = Nothing
            objLEmpresaTop = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub Buscar()
        Dim objLEmpresaTop As LEmpresaTop
        Dim strTipoDocumento As String = ddlBusquedaTipoDocumento.SelectedValue
        Dim strNroDocumento As String = txtBusquedaNroDocumento.Text.Trim
        Dim strFechaInicio As String = txtBusquedaFechaInicio.Text
        Dim strFechaFin As String = txtBusquedaFechaFin.Text
        Dim intRankingInicio As Integer = CheckInt(txtBusquedaRangoInicio.Text.Trim)
        Dim intRankingFin As Integer = CheckInt(txtBusquedaRangoFin.Text)
        Dim strNombre As String = txtBusquedaNombre.Text.Trim
        Dim dtbLista As New DataTable

        Try
            'If Not (strNroDocumento.Length = 0 AndAlso strFechaInicio.Length = 0 AndAlso strFechaFin.Length = 0 AndAlso intRankingInicio = 0 AndAlso intRankingFin = 0) Then
            objLEmpresaTop = New LEmpresaTop

            'dgrGrillaCabecera.DataSource = ""
            'dgrGrillaCabecera.DataBind()

            dtbLista = objLEmpresaTop.fdtbListarBusqueda(strTipoDocumento, strNroDocumento, strNombre, strFechaInicio, strFechaFin, intRankingInicio, intRankingFin)
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()
            'End If
            Session("ITEMS_TOTAL") = dtbLista

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
  
        Finally
            objLEmpresaTop = Nothing
            Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_CONSULTAR"), "Consulta Empresa Top.")
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
            If ViewState("EstadoActual").ToString = "NUEVO" Then
                If pstrNroDocumento.Length > 0 Then
                    objLWhitelist = New LWhitelist
                    txtNombre.Text = objLWhitelist.fstrClienteTraerNombre(pstrTipoDocumento, pstrNroDocumento)

                    If txtNombre.Text.Length = 0 Then
                        txtNombre.ReadOnly = False
                        txtNombre.CssClass = "clsInputEnable"
                    Else
                        txtNombre.ReadOnly = True
                        txtNombre.CssClass = "clsInputDisable"
                    End If
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
        Dim objLEmpresaTop As LEmpresaTop
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
                objLEmpresaTop = New LEmpresaTop
                objLEmpresaTop.fbooEliminarSeleccionados(strSeleccionados, curSalida, Msg)
                btnBuscar_Click(Nothing, Nothing)
                hidEliminar.Value = String.Empty

                Session(CHECKED_ITEMS) = Nothing
            End If
 
        Finally
            objLEmpresaTop = Nothing
            Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_ELIMINAR"), "Eliminar Empresa Top.")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        End Try
    End Sub

    Private Sub dgrGrillaDetalle_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrGrillaDetalle.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim chkTotal As CheckBox = CType(e.Item.FindControl("chkTotalGrilla"), CheckBox)
            chkTotal.Checked = CHECK_TOTAL
        End If
    End Sub

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

                    RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe Ingresar un Archivo válido con extensión .TXT o .CSV')</script>")
                End If
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe Ingresar una Ruta de Archivo válida')</script>")
            End If
        Catch ex As Exception
        Finally
            Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_CARGA_FILE"), "Cargar Archivo de Empresas Top.")
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
            strArchivo = "EmpresaTop_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

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

            strArchivo = Server.MapPath(rutaOrigen) & "\" & "EmpresaTop_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & "EmpresaTopReport_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
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
                strDatos &= "¬" & input
                input = re.ReadLine()
            End While
            sw.Close()
            obj.CargaMasiva("E", strDatos)

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
            Dim newFile As String = "EmpresaTopReport_" & DateTime.Now.ToString("ddMMyyyy")
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
                        "RANKING" & "," & _
                        "VIGENCIA INDEFINIDA" & "," & _
                        "VIGENCIA DIAS" & "," & _
                        "FECHA"
                    sw.WriteLine(Linea)
                    'Chr(39) & dtbLista.Rows(i)("whlsv_nrodocuform") & "," & _
                    For i As Integer = 0 To totalReg - 1
                        Linea = dtbLista.Rows(i)("tdocc_des") & "," & _
                            dtbLista.Rows(i)("etopv_num_doc") & "," & _
                            dtbLista.Rows(i)("etopv_razon_social") & "," & _
                            dtbLista.Rows(i)("etopc_tipo") & "," & _
                            dtbLista.Rows(i)("etopn_ranking") & "," & _
                            dtbLista.Rows(i)("etopc_vige_inde") & "," & _
                            dtbLista.Rows(i)("etopn_dias_tolerancia") & "," & _
                            dtbLista.Rows(i)("etopc_fech_regi")

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
                Auditoria(ConfigurationSettings.AppSettings("TOP_CODAUDT_EXPORTAR"), "Exportar Archivo Lista de Empresas Top.")
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
                categoryIDList.Add(ditItem(3))
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
