Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO


Public Class sisact_mant_idvalidator
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusquedaTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusquedaNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBusquedaFechaFin As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents lblTipoLista As System.Web.UI.WebControls.Label
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkVigenciaIndef As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtVigenciaDias As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    Protected WithEvents lblTipoListaE As System.Web.UI.WebControls.Label
    Protected WithEvents btnTraerCliente As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidTipoLista As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigoPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidCondicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnEliminarPDV As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dlTipoOperacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnEliminar As System.Web.UI.WebControls.Button
    Protected WithEvents btnModifGeneral As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCodigoGen As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents hidErrorCarga As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
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
        If hidCondicion.Value = "PDV" Then
            hidCondicion.Value = String.Empty
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
  
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objMant As MaestroNegocio
        Dim tipoList As String = hidTipoLista.Value
        Try
            objMant = New MaestroNegocio

            Dim nroDoc As String = txtNroDocumento.Text
            Dim TipoDoc As String = ddlTipoDocumento.SelectedValue
            Dim nombre As String = (txtNombre.Text).ToUpper()
            Dim chkVigInd As String
            If chkVigenciaIndef.Checked Then
                chkVigInd = "S"
            Else
                chkVigInd = "N"
            End If
            Dim diasVig As Integer = CheckInt(txtVigenciaDias.Text)


            Dim auditTipoList As String
            If tipoList.Equals("W") Then
                auditTipoList = "Whitelist"
            ElseIf tipoList.Equals("B") Then
                auditTipoList = "Blacklist"
            End If
            If hidCodigo.Value.Length = 0 Then
                If nroDoc.Length = 0 Then
                    RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');</script>")
                    RegisterStartupScript("script3", "<script>alert('Debe ingresar DNI de cliente.')</script>")
                    Exit Sub
                ElseIf nombre.Length = 0 Then
                    RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO');</script>")
                    RegisterStartupScript("script3", "<script>alert('Debe ingresar nombre de cliente.')</script>")
                    Exit Sub
                End If
                objMant.insertarIDValidatorList(TipoDoc, nroDoc, nombre, chkVigInd, diasVig, tipoList, CurrentUser)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Insertar"), "Registrar cliente " & auditTipoList & " en IDValidator")
            Else
                objMant.actualizarIDValidatorList(hidCodigo.Value, chkVigInd, diasVig, nombre, CurrentUser)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Modificar"), "Actualizar cliente " & auditTipoList & " en IDValidator")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los datos se registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Error: DNI configurado en Blacklist.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20771") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Error: DNI configurado en Whitelist.')</script>")
            ElseIf ex.Message.IndexOf("ORA-20772") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Error: DNI ya se encuentra configurado.')</script>")
            Else
                RegisterStartupScript("script1", "<script>f_MostrarTab('BUSQUEDA');alert('Ocurrió un error en el proceso.');</script>")
            End If
        Finally
            objMant = Nothing
        End Try
    End Sub

    Private Sub btnModificar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.ServerClick
        Dim objMaestro As MaestroNegocio
        Dim dt As DataTable
        Dim codigo As Integer
        Dim tipoList As String
        Try
            objMaestro = New MaestroNegocio

            codigo = CheckInt(hidCodigo.Value)
            tipoList = hidTipoLista.Value

            dt = objMaestro.listarIDValidatorList("", "", "", tipoList, "", codigo)

            txtNombre.Text = CheckStr(dt.Rows(0).Item("LISTV_NOMBRE"))
            txtNroDocumento.Text = CheckStr(dt.Rows(0).Item("LISTV_NRO_DOC"))
            txtVigenciaDias.Text = CheckStr(dt.Rows(0).Item("LISTN_VIGE_DIAS"))
            chkVigenciaIndef.Checked = CBool(IIf(dt.Rows(0).Item("LISTC_VIGE_INDEF") = "S", True, False))
            If CheckStr(dt.Rows(0).Item("LISTC_TIPO_DOC")) = "DNI" Then
                ddlTipoDocumento.SelectedValue = "01"
            Else
                ddlTipoDocumento.SelectedValue = "04"
            End If


            txtNombre.ReadOnly = False
            ddlTipoDocumento.Enabled = False
            txtNroDocumento.ReadOnly = True
            txtNombre.CssClass = "clsInputEnable"
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
            objMaestro = Nothing
        End Try
    End Sub

    Private Sub btnTraerCliente_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraerCliente.ServerClick
        Dim pstrTipoDocumento As String = ddlTipoDocumento.SelectedValue
        Dim pstrNroDocumento As String = txtNroDocumento.Text.Trim
        Dim objLWhitelist As LWhitelist
        Try
            If pstrNroDocumento.Length > 0 Then
                objLWhitelist = New LWhitelist
                txtNombre.Text = Trim(objLWhitelist.fstrClienteTraerNombre(pstrTipoDocumento, pstrNroDocumento))
            End If
            If hidCodigo.Value = "" Then
                If txtNombre.Text.Length = 0 Then
                    txtNombre.ReadOnly = False
                    txtNombre.CssClass = "clsInputEnable"
                Else
                    txtNombre.ReadOnly = True
                    txtNombre.CssClass = "clsInputDisable"
                End If
                RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
            Else
                txtNombre.ReadOnly = False
                txtNombre.CssClass = "clsInputEnable"
                RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
            End If
 
        Finally
            objLWhitelist = Nothing
        End Try
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        LimpiarGeneral()
        ViewState("EstadoActual") = "NUEVO"
        RegisterStartupScript("script", "<script>fActivarVigencia(false, false);f_MostrarTab('NUEVO')</script>")
    End Sub

    Public Sub chkTotalGrilla_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim categoryIDList As New ArrayList
        Dim chkTotalGrilla As CheckBox = DirectCast(sender, CheckBox)

        Dim dtbTotal As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)

        If chkTotalGrilla.Checked Then
            For Each ditItem As DataRow In dtbTotal.Rows
                categoryIDList.Add(ditItem(0))
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

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        RememberOldValues()
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        Buscar()
        RePopulateValues()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objMaestro As MaestroNegocio
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

        Dim auditTipoList As String
        If hidTipoLista.Value.Equals("W") Then
            auditTipoList = "Whitelist"
        ElseIf hidTipoLista.Value.Equals("B") Then
            auditTipoList = "Blacklist"
        End If

        Try
            If strSeleccionados.Length > 0 Then
                objMaestro = New MaestroNegocio
                objMaestro.eliminarSeleccionadosIDValidator(strSeleccionados, curSalida, Msg)
                btnBuscar_Click(Nothing, Nothing)
                'hidEliminar.Value = String.Empty
                RegisterStartupScript("script1", "<script>alert('Se eliminaron el/los registro(s) seleccionado(s)')</script>")
                Session(CHECKED_ITEMS) = Nothing
            End If
     
        Finally
            objMaestro = Nothing
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Eliminar"), "Eliminar cliente(s) " & auditTipoList & " en IDValidator")
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not Session("ITEMS_TOTAL") Is Nothing Then
            Dim dtbLista As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)
            Dim newFile As String
            If hidTipoLista.Value = "W" Then
                newFile = "IDV_Whitelist_" & DateTime.Now.ToString("ddMMyyyy")
            ElseIf hidTipoLista.Value = "B" Then
                newFile = "IDV_Blacklist_" & DateTime.Now.ToString("ddMMyyyy")
            End If
            Dim Linea As String
            eliminarArchivo()
            Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim totalReg As Integer = dtbLista.Rows.Count

            Try
                If totalReg > 0 Then
                    Linea = "TIPO DOC" & "," & _
                        "NRO DOC" & "," & _
                        "NOMBRE" & "," & _
                        "VIGENCIA INDEFINIDA" & "," & _
                        "VIGENCIA DIAS" & "," & _
                        "FECHA REGISTRO" & "," & _
                        "FECHA VIGENCIA"
                    sw.WriteLine(Linea)

                    For i As Integer = 0 To totalReg - 1
                        Linea = dtbLista.Rows(i)("LISTC_TIPO_DOC") & "," & _
                            dtbLista.Rows(i)("LISTV_NRO_DOC") & "," & _
                            dtbLista.Rows(i)("LISTV_NOMBRE") & "," & _
                            dtbLista.Rows(i)("LISTC_VIGE_INDEF") & "," & _
                            dtbLista.Rows(i)("LISTN_VIGE_DIAS") & "," & _
                            dtbLista.Rows(i)("LISTD_FCHA_REG") & "," & _
                            dtbLista.Rows(i)("LISTD_FCHA_VIGE")

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
                Dim auditTipoList As String
                If hidTipoLista.Value.Equals("W") Then
                    auditTipoList = "Whitelist"
                ElseIf hidTipoLista.Value.Equals("B") Then
                    auditTipoList = "Blacklist"
                End If
                sw.Close()
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Exportar"), "Exportar Archivo Lista de Clientes " & auditTipoList & " en IDValidator")
            End Try
        Else
            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA');alert('No existen registros cargados')</script>")
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

                    RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe ingresar un archivo válido con extensión .TXT o .CSV')</script>")
                End If
            Else
                RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('Debe ingresar una ruta de archivo válida')</script>")
            End If
        Catch ex As Exception
        Finally
            Dim auditTipoList As String
            If hidTipoLista.Value.Equals("W") Then
                auditTipoList = "Whitelist"
            ElseIf hidTipoLista.Value.Equals("B") Then
                auditTipoList = "Blacklist"
            End If

            Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Carga_File"), "Cargar Archivo clientes" & auditTipoList & " en IDValidator")
        End Try
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

    Private Sub Limpiar()

            txtNombre.Text = String.Empty
            txtNroDocumento.Text = String.Empty
            txtVigenciaDias.Text = String.Empty
            ddlTipoDocumento.SelectedIndex = -1
            chkVigenciaIndef.Checked = False
            ddlTipoDocumento.Enabled = True
            txtNroDocumento.ReadOnly = False
            ddlTipoDocumento.CssClass = "clsSelectEnable"
            txtNroDocumento.CssClass = "clsInputEnable"
            txtVigenciaDias.CssClass = "clsInputEnable"
            txtNombre.ReadOnly = True
            txtNombre.CssClass = "clsInputDisable"
            hidCodigo.Value = ""
            ' limpiar id validator general
            hidCodigoGen.Value = ""
            hidErrorCarga.Value = ""

            Session("ITEMS_TOTAL") = Nothing
            Session("ITEMS_GENERAL") = Nothing
            Session("CHECK_GENERAL") = Nothing

    End Sub
    Private Sub LimpiarGeneral()

            hidCodigo.Value = ""
            ' limpiar id validator generals
            hidCodigoGen.Value = ""

            Session("ITEMS_TOTAL") = Nothing
            Session("ITEMS_GENERAL") = Nothing
            Session("CHECK_GENERAL") = Nothing
 
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

    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoCargados As String
        Dim strArchivoError As String
        Dim strNombreAr As String
   

            If hidTipoLista.Value = "W" Then
                strNombreAr = "IDV_Whitelist_"
            ElseIf hidTipoLista.Value = "B" Then
                strNombreAr = "IDV_Blacklist_"
            End If

            strArchivo = Server.MapPath(rutaOrigen) & "\" & strNombreAr & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & strNombreAr & DateTime.Now.ToString("yyyyMMdd") & ".csv"
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

    Public Sub cargarArchivo()
        Dim RequestXForm As Object
        Dim objFilex As Object
        Dim strArchivo As String
        Dim strRutaWeb As String
        Dim strNombreAr As String
        Try

            If hidTipoLista.Value = "W" Then
                strNombreAr = "IDV_Whitelist_"
            ElseIf hidTipoLista.Value = "B" Then
                strNombreAr = "IDV_Blacklist_"
            End If
            'RequestXForm = Server.CreateObject("ABCUpload4.XForm")
            'RequestXForm.AbsolutePath = True
            'RequestXForm.Overwrite = True
            'objFilex = RequestXForm("FileToUpload")(1)
            strArchivo = strNombreAr & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            strRutaWeb = Server.MapPath(rutaOrigen) & "/" & strArchivo

            'objFilex.Save(strRutaWeb)
            'RequestXForm = Nothing
            'objFilex = Nothing
            FileToUpload.PostedFile.SaveAs(strRutaWeb)
            ViewState("File") = strArchivo
        Catch ex As Exception
            Dim mensaje = ex.Message
            RegisterStartupScript("script", "<script>f_MostrarTab('CARGAMASIVA');alert('error al cargar el archivo')</script>")
        End Try
    End Sub

    Function procesarArchivo() As String
        Dim obj As New MaestroNegocio
        Dim archivo As String = ViewState("File")
        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)
        Dim strDatos As String = String.Empty
        Dim strErrores As String = String.Empty
        Dim strNombreAr As String
        If hidTipoLista.Value = "W" Then
            strNombreAr = "IDV_Whitelist_Errada_"
        ElseIf hidTipoLista.Value = "B" Then
            strNombreAr = "IDV_Blacklist_Errada_"
        End If
        Dim ErrorFile As String = strNombreAr & DateTime.Now.ToString("ddMMyyyy")
        Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & ErrorFile & ".txt"))

        Dim retorno As String
        Try
            Dim correcto As Boolean
            Dim input As String
            input = re.ReadLine()
            Dim contError As Integer = 0
            Dim contCorrecto As Integer = 0
            Dim cadena As String
            Dim errores As String = ""
            Dim longitud As Integer

            Dim datos1 As String()
            Dim datos2 As String()
            Dim row As Integer = 1
            Dim valError As Integer = 0

            While Not input Is Nothing
                If Not input.Equals("") Then
                    strDatos &= "¬" & input & "," & CurrentUser
                End If
                input = re.ReadLine()
            End While

            datos1 = strDatos.Split("¬"c)
            datos2 = strDatos.Split("¬"c)
            For Each item As String In datos1
                If Not (item Is Nothing Or item.Equals("")) Then
                    Dim dni As String = item.Split(","c)(1)
                    For Each item2 As String In datos2
                        If Not (item2 Is Nothing Or item2.Equals("")) Then
                            Dim dni2 As String = item2.Split(","c)(1)
                            If dni = dni2 Then
                                valError += 1
                                If valError > 1 Then
                                    sw.WriteLine(dni & " --> " & "DNI se encuentra duplicado.")
                                    errores = errores & "Error fila" & row & ". DNI se encuentra duplicado" & "<BR>"
                                    contError = 1
                                End If
                            End If
                        End If
                    Next
                    valError = 0
                    row += 1
                End If
            Next
            If contError = 0 Then
                obj.CargaMasivaIDValidatorList(strDatos, strErrores)
            End If

            lblError.Text = ""
            hidErrorCarga.Value = ""

            If strErrores.Trim.Length > 0 Then
                Dim arrayItems As String() = strErrores.Split("|"c)
                For Each item As String In arrayItems
                    Dim datos As String() = item.Split(";"c)

                    If datos(2).Equals("-10") Then
                        If datos(3).Equals("W") Then
                            sw.WriteLine(datos(1) & " --> " & "DNI configurado en Blacklist.")
                            errores = errores & "Error fila" & datos(0) & ". DNI configurado en Blacklist" & "<BR>"
                        ElseIf datos(3).Equals("B") Then
                            sw.WriteLine(datos(1) & " --> " & "DNI configurado en Whitelist.")
                            errores = errores & "Error fila" & datos(0) & ". DNI configurado en Whitelist" & "<BR>"
                        End If
                    ElseIf datos(2).Equals("-20") Then
                        sw.WriteLine(datos(1) & " --> " & "DNI ya se encuentra configurado.")
                    ElseIf datos(2).Equals("-30") Then
                        sw.WriteLine(datos(1) & " --> " & "Número de DNI no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo número  de documento, no tiene el formato correcto. DNI: 8 dígitos, CE: 9 dígitos" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-40") Then
                        sw.WriteLine(datos(1) & " --> " & "Tipo de documento no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo tipo de documento, no tiene el formato correcto. DNI: 01, CE: 04" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-50") Then
                        sw.WriteLine(datos(1) & " --> " & "Nombre no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo nombre o razón social del cliente, no tiene el formato correcto. Máximo 50 dígitos" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-60") Then
                        sw.WriteLine(datos(1) & " --> " & "fecha indefinidad no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo fecha indefinida, no tiene el formato correcto. Si: S, No: N" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-70") Then
                        sw.WriteLine(datos(1) & " --> " & "cantidad de dias no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo cantidad de días, no tiene el formato correcto. Máximo 365 días" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-80") Then
                        sw.WriteLine(datos(1) & " --> " & "Nombre no valido.")
                        errores = errores & "Error fila" & datos(0) & ". El campo tipo de lista, no tiene el formato correcto. Blacklist: B, Whitlist: W" & "<BR>"
                        contError = 1
                    ElseIf datos(2).Equals("-90") Then
                        sw.WriteLine(datos(1) & " --> " & "DNI se encuentra duplicado.")
                        errores = errores & "Error fila" & datos(0) & ". DNI se encuentra duplicado" & "<BR>"
                        contError = 1
                    End If
                Next
            End If

            sw.Close()
            re.Close()
            re = Nothing

            If Trim(strErrores).Length = 0 And Trim(errores).Length = 0 Then
                retorno = "El archivo se cargo correctamente"
            Else
                lblError.Text = errores
                retorno = "Error en archivo"
                hidErrorCarga.Value = "ERROR"
            End If

        Catch ex As Exception
            re.Close()
            re = Nothing
            sw.Close()
            Dim mensaje = ex.Message
            retorno = "Error al validar el archivo"
        End Try

        Return retorno
    End Function

    Private Sub Buscar()
        Dim objMaestro As MaestroNegocio
        Dim strNroDocumento As String = txtBusquedaNroDocumento.Text.Trim
        Dim strFechaInicio As String = txtBusquedaFechaInicio.Text
        Dim strFechaFin As String = txtBusquedaFechaFin.Text
        Dim strTipoLista As String = hidTipoLista.Value
        Dim strTipoDoc As String = ddlBusquedaTipoDocumento.SelectedValue
        Dim dtbLista As New DataTable

        Try
            objMaestro = New MaestroNegocio

            dtbLista = objMaestro.listarIDValidatorList(strNroDocumento, strFechaInicio, strFechaFin, strTipoLista, strTipoDoc, Nothing)
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()

            Session("ITEMS_TOTAL") = dtbLista

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
            RegisterStartupScript("script2", "<script>f_mostrarGrilla()</script>")
        Finally
            Dim auditTipoList As String
            If hidTipoLista.Value.Equals("W") Then
                auditTipoList = "Whitelist"
            ElseIf hidTipoLista.Value.Equals("B") Then
                auditTipoList = "Blacklist"
            End If
            objMaestro = Nothing
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantIDValidator_Consulta"), "Consulta Cliente " & auditTipoList & " en IDValidator")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        ddlBusquedaTipoDocumento.SelectedValue = "00"
        txtBusquedaNroDocumento.Text = ""
        txtBusquedaFechaInicio.Text = ""
        txtBusquedaFechaFin.Text = ""
        RegisterStartupScript("script", "<script>f_MostrarTab('LIMPIAR')</script>")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub btnLimpiarGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub
End Class
