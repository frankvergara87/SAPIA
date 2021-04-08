Option Strict Off
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports System.IO

Public Class sisact_mant_edificios
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnModificar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnAgregar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnEliminar As System.Web.UI.WebControls.Button
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    Protected WithEvents ddlTipoEmpresa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRanking As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidEliminar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtComentario As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlBusquedaTipoEmpresa As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents hidSecuencia As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlDpto As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDistrito As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProvincia As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDistritoM As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDptoM As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlProvinciaM As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDireccionM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDireccion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNodo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEdificio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfechaActiv As System.Web.UI.WebControls.TextBox
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
            Try
                RegisterStartupScript("script", "<script>f_Inicio()</script>")
                Dim lista As ArrayList
                Dim hasListas As New Hashtable

                Dim tablas() As Integer = {1, 3, 4, 5, 8, 9, 10, 12, 13, 14, 15}
                Dim oConsulta As New MaestroNegocio
                hasListas = oConsulta.ListarItemsGenericos(tablas)

                lista = CType(hasListas(5), ArrayList)
                lista.Insert(0, New Departamento("-1", "--Seleccionar--", ""))
                With ddlDpto
                    .DataSource = lista
                    .DataValueField = "DEPAC_CODIGO"
                    .DataTextField = "DEPAV_DESCRIPCION"
                    .DataBind()
                End With

                With ddlDptoM
                    .DataSource = lista
                    .DataValueField = "DEPAC_CODIGO"
                    .DataTextField = "DEPAV_DESCRIPCION"
                    .DataBind()
                End With

                ddlProvincia.Items.Add(New ListItem("--Seleccionar--", "-1"))
                ddlDistrito.Items.Add(New ListItem("--Seleccionar--", "-1"))
                ddlProvinciaM.Items.Add(New ListItem("--Seleccionar--", "-1"))
                ddlDistritoM.Items.Add(New ListItem("--Seleccionar--", "-1"))

            Catch ex As Exception
                Throw ex
            End Try
        End If

        btnBuscar.Attributes.Add("onclick", "return f_Buscar();")
        btnLimpiar.Attributes.Add("onclick", "return f_Limpiar();")
        btnAceptar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        btnEliminar.Attributes.Add("onclick", "return f_eliminarSeleccionados();")
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            dgrGrillaDetalle.CurrentPageIndex = 0
            Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Limpiar()
        Try
            hidSecuencia.Value = String.Empty
            txtDireccion.Text = String.Empty
            txtNodo.Text = String.Empty
            txtfechaActiv.Text = Today.ToString("dd/MM/yyyy")
            txtEdificio.Text = String.Empty
            txtDireccionM.Text = String.Empty
            txtNodo.Text = String.Empty
            ddlEstado.SelectedValue = 1
            ddlDistritoM.SelectedValue = -1
            ddlDptoM.SelectedValue = -1
            ddlProvinciaM.SelectedValue = -1

            Session("ITEMS_TOTAL") = Nothing
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
        Dim objEdificio As DataTable
        Dim objMaestro As MaestroNegocio
        Dim dt As DataTable
        Try
            objMaestro = New MaestroNegocio            
            objEdificio = objMaestro.listarEdificio("-1", "-1", "-1", "", hidSecuencia.Value)

            ViewState("EstadoActual") = "MODIF"

            ddlDptoM.SelectedValue = CheckStr(objEdificio.Rows(0).Item("DEPAC_CODIGO"))
            ddlDptoM_SelectedIndexChanged(Nothing, Nothing)
            ddlProvinciaM.SelectedValue = CheckStr(objEdificio.Rows(0).Item("PROVC_CODIGO"))
            ddlProvinciaM_SelectedIndexChanged(Nothing, Nothing)
            ddlDistritoM.SelectedValue = CheckStr(objEdificio.Rows(0).Item("DISTC_CODIGO"))
            txtDireccionM.Text = CheckStr(objEdificio.Rows(0).Item("EDIFV_DIRECCION"))
            txtNodo.Text = CheckStr(objEdificio.Rows(0).Item("EDIFV_NODO"))
            txtEdificio.Text = CheckStr(objEdificio.Rows(0).Item("EDIFV_DESCRIPCION"))
            txtfechaActiv.Text = Format("dd/MM/yyyy", CheckDate(objEdificio.Rows(0).Item("EDIFD_FECHA_ACTIV")))
            If CheckStr(objEdificio.Rows(0).Item("EDIFC_ESTADO")) = "HABILITADO" Then
                ddlEstado.SelectedValue = 1
            Else
                ddlEstado.SelectedValue = 0
            End If


            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
        Catch ex As Exception
            Throw ex
        Finally
            objMaestro = Nothing
        End Try
    End Sub

    Private Sub btnAgregar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.ServerClick
        Limpiar()
        ViewState("EstadoActual") = "NUEVO"
        RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objMaestro As MaestroNegocio
        Dim curSalida As String
        Dim Msg As String
        Dim resultado As Boolean
        Dim strDescripcion As String = String.Empty
        Dim oEdif As Edificio

        Try
            oEdif = New Edificio
            oEdif.DEPAC_CODIGO = CheckStr(ddlDptoM.SelectedValue)
            oEdif.PROVC_CODIGO = CheckStr(ddlProvinciaM.SelectedValue)
            oEdif.DISTC_CODIGO = CheckStr(ddlDistritoM.SelectedValue)
            oEdif.EDIFV_DIRECCION = CheckStr(txtDireccionM.Text)
            oEdif.EDIFV_NODO = CheckStr(txtNodo.Text)
            oEdif.EDIFV_DESCRIPCION = CheckStr(txtEdificio.Text)
            oEdif.EDIFD_FECHA_ACTIV = CheckDate(txtfechaActiv.Text)
            oEdif.EDIFC_ESTADO = CheckStr(ddlEstado.SelectedValue)

            objMaestro = New MaestroNegocio

            If hidSecuencia.Value.Length = 0 Then
                objMaestro.insertarEdificio(oEdif)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Insertar"), "Registrar Edificios.")
            Else
                oEdif.EDIFV_CODIGO = hidSecuencia.Value
                objMaestro.actualizarEdificio(oEdif)
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Modificar"), "Actualizar Edificios.")
            End If

            btnBuscar_Click(Nothing, Nothing)
            RegisterStartupScript("script1", "<script>alert('Los Datos se Registraron satisfactoriamente.')</script>")

        Catch ex As Exception
            If ex.Message.IndexOf("ORA-20770") > -1 Then
                RegisterStartupScript("script1", "<script>f_MostrarTab('EDICION');alert('Error: El registro ya existe.')</script>")
            Else
                Throw ex
            End If
        Finally
            objMaestro = Nothing
            oEdif = Nothing
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        btnBuscar_Click(Nothing, Nothing)
    End Sub

    Private Sub Buscar()
        Dim objEdificio As MaestroNegocio
        Dim strDireccion As String = txtDireccion.Text.Trim
        Dim strDepartamento As String = ddlDpto.SelectedValue
        Dim strProvincia As String = ddlProvincia.SelectedValue
        Dim strDistrito As String = ddlDistrito.SelectedValue
        Dim dtbLista As New DataTable

        Try
            objEdificio = New MaestroNegocio
            dtbLista = objEdificio.listarEdificio(strDepartamento, strProvincia, strDistrito, strDireccion, "")
            dgrGrillaDetalle.DataSource = dtbLista
            dgrGrillaDetalle.DataBind()

            Session("ITEMS_TOTAL") = dtbLista

            RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
        Catch ex As Exception
            Throw ex
        Finally
            objEdificio = Nothing
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Consulta"), "Consulta Edificios.")
        End Try
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
        Try
            If strSeleccionados.Length > 0 Then
                objMaestro = New MaestroNegocio
                objMaestro.eliminarSeleccionadosEdificio(strSeleccionados, curSalida, Msg)
                btnBuscar_Click(Nothing, Nothing)
                hidEliminar.Value = String.Empty

                Session(CHECKED_ITEMS) = Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objMaestro = Nothing
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Eliminar"), "Eliminar Edificios.")
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
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Carga_File"), "Cargar Archivo de Edificios.")
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
            strArchivo = "Edificios_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

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

    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoCargados As String
        Dim strArchivoError As String
        Try
            strArchivo = Server.MapPath(rutaOrigen) & "\" & "Edificios_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & "EdificiosReport_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
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

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function procesarArchivo() As String
        Dim obj As New MaestroNegocio
        Dim archivo As String = ViewState("File")
        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)
        Dim strDatos As String = String.Empty
        Dim ErrorFile As String = "Detalle_Carga_Edificio_Errada_" & DateTime.Now.ToString("ddMMyyyy")
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
            obj.CargaMasivaEdificio(strDatos)

            re.Close()
            re = Nothing

            retorno = "El archivo se cargo correctamente"
        Catch ex As Exception
            re = Nothing
            sw.Close()
            Dim mensaje = ex.Message
            retorno = "error al validar el archivo"
        Finally
            sw.Close()
        End Try

        Return retorno
    End Function

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If Not Session("ITEMS_TOTAL") Is Nothing Then
            Dim dtbLista As DataTable = DirectCast(Session("ITEMS_TOTAL"), DataTable)
            Dim newFile As String = "WhitelistFlexiReport_" & DateTime.Now.ToString("ddMMyyyy")
            Dim Linea As String
            eliminarArchivo()
            Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".csv"), False, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            Dim totalReg As Integer = dtbLista.Rows.Count

            Try
                If totalReg > 0 Then
                    Linea = "DEPARTAMENTO" & "," & _
                        "PROVINCIA" & "," & _
                        "DISTRITO" & "," & _
                        "DIRECCION" & "," & _
                        "NODO" & "," & _
                        "EDIFICIO" & "," & _
                        "FECHA ACTIVACION" & "," & _
                        "ESTADO"
                    sw.WriteLine(Linea)
                    For i As Integer = 0 To totalReg - 1
                        Linea = dtbLista.Rows(i)("DEPAV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("PROVV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("DISTV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("EDIFV_DIRECCION") & "," & _
                            dtbLista.Rows(i)("EDIFV_NODO") & "," & _
                            dtbLista.Rows(i)("EDIFV_DESCRIPCION") & "," & _
                            dtbLista.Rows(i)("EDIFD_FECHA_ACTIV") & "," & _
                            dtbLista.Rows(i)("EDIFC_ESTADO")

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
                Auditoria(ConfigurationSettings.AppSettings("codTrsMantEdificio_Exportar"), "Exportar Archivo Lista de Edificios.")
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
                If categoryIDList.Contains(Convert.ToString(index)) Then
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

    Private Sub ddlDpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDpto.SelectedIndexChanged
        Dim oConsulta As New MaestroNegocio
        Dim provincias As ArrayList
        ddlProvincia.Items.Clear()
        ddlDistrito.Items.Clear()
        ddlDistrito.Items.Add(New ListItem("--Seleccionar--", "-1"))
        Dim item As New Provincia
        provincias = oConsulta.ListaProvincia("000", ddlDpto.SelectedValue, "A")
        item.PROVC_CODIGO = "-1"
        item.PROVV_DESCRIPCION = "--Seleccionar--"
        provincias.Insert(0, item)

        With ddlProvincia
            .DataSource = provincias
            .DataValueField = "PROVC_CODIGO"
            .DataTextField = "PROVV_DESCRIPCION"
            .DataBind()
        End With
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub ddlProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProvincia.SelectedIndexChanged
        Dim oConsulta As New MaestroNegocio
        Dim distritos As ArrayList
        ddlDistrito.Items.Clear()
        distritos = oConsulta.ListaDistrito("0000", ddlProvincia.SelectedValue, ddlDpto.SelectedValue, "A")
        Dim item As New Distrito
        item.DISTC_CODIGO = "-1"
        item.DISTV_DESCRIPCION = "--Seleccionar--"
        distritos.Insert(0, item)
        With ddlDistrito
            .DataSource = distritos
            .DataValueField = "DISTC_CODIGO"
            .DataTextField = "DISTV_DESCRIPCION"
            .DataBind()
        End With
        RegisterStartupScript("script", "<script>f_MostrarTab('BUSQUEDA')</script>")
    End Sub

    Private Sub ddlDptoM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDptoM.SelectedIndexChanged
        Dim oConsulta As New MaestroNegocio
        Dim provincias As ArrayList
        Dim estadoActual As String = ViewState("EstadoActual")

        ddlProvinciaM.Items.Clear()
        ddlDistritoM.Items.Clear()
        ddlDistritoM.Items.Add(New ListItem("--Seleccionar--", "-1"))
        Dim item As New Provincia
        provincias = oConsulta.ListaProvincia("000", ddlDptoM.SelectedValue, "A")
        item.PROVC_CODIGO = "-1"
        item.PROVV_DESCRIPCION = "--Seleccionar--"
        provincias.Insert(0, item)

        With ddlProvinciaM
            .DataSource = provincias
            .DataValueField = "PROVC_CODIGO"
            .DataTextField = "PROVV_DESCRIPCION"
            .DataBind()
        End With

        If estadoActual.Equals("NUEVO") Then
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        ElseIf estadoActual.Equals("MODIF") Then
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
        End If
    End Sub

    Private Sub ddlProvinciaM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProvinciaM.SelectedIndexChanged
        Dim oConsulta As New MaestroNegocio
        Dim distritos As ArrayList
        Dim estadoActual As String = ViewState("EstadoActual")

        ddlDistritoM.Items.Clear()
        distritos = oConsulta.ListaDistrito("0000", ddlProvinciaM.SelectedValue, ddlDptoM.SelectedValue, "A")
        Dim item As New Distrito
        item.DISTC_CODIGO = "-1"
        item.DISTV_DESCRIPCION = "--Seleccionar--"
        distritos.Insert(0, item)
        With ddlDistritoM
            .DataSource = distritos
            .DataValueField = "DISTC_CODIGO"
            .DataTextField = "DISTV_DESCRIPCION"
            .DataBind()
        End With

        If estadoActual.Equals("NUEVO") Then
            RegisterStartupScript("script", "<script>f_MostrarTab('NUEVO')</script>")
        ElseIf estadoActual.Equals("MODIF") Then
            RegisterStartupScript("script", "<script>f_MostrarTab('EDICION')</script>")
        End If

    End Sub
End Class
