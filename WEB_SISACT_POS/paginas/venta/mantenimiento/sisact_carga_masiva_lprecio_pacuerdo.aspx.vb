Option Strict Off
Imports System
Imports System.IO
Imports ABCUpload4
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones

Public Class sisact_carga_masiva_lprecio_pacuerdo
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents dgPlan As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btDetalle As System.Web.UI.WebControls.LinkButton
    Protected WithEvents btExportar As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dgResultado As System.Web.UI.WebControls.DataGrid

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
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
                    RegisterStartupScript("script", "<script>alert('" & mensaje & "');</script>")

                ElseIf (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".TXT" OrElse _
                        (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".TXT" Then

                    RegisterStartupScript("script", "<script>alert('Debe Ingresar un Archivo válido con extensión .TXT o .CSV');</script>")
                End If
            Else
                RegisterStartupScript("script", "<script>alert('Debe Ingresar una Ruta de Archivo válida');</script>")
            End If
        Catch ex As Exception
        Finally
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantLpPaCargaArchivo"), "Cargar Archivo Lista de Precio - Plazo Acuerdo")
        End Try
    End Sub

    Public Sub cargarArchivo()
        Dim RequestXForm As Object
        Dim objFilex As Object
        Dim strArchivo As String
        Dim strRutaWeb As String

        Try
            RequestXForm = Server.CreateObject("ABCUpload4.XForm")
            'RequestXForm.MaxUploadSize = CheckInt(ConfigurationSettings.AppSettings("MAX_UPLOAD_SIZE"))
            RequestXForm.AbsolutePath = True
            RequestXForm.Overwrite = True
            objFilex = RequestXForm("FileToUpload")(1)
            strArchivo = "Carga_Masiva_ListaPrecio_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            'Grabamos el archivo en la ruta correspondiente
            strRutaWeb = Server.MapPath(rutaOrigen) & "/" & strArchivo

            objFilex.Save(strRutaWeb)
            RequestXForm = Nothing
            objFilex = Nothing
            ViewState("File") = strArchivo
        Catch ex As Exception
            Dim mensaje = ex.Message
            RegisterStartupScript("script", "<script>alert('error al cargar el archivo');</script>")
        End Try
    End Sub

    Function procesarArchivo() As String
        Dim obj As New MaestroNegocio
        Dim archivo As String = ViewState("File")
        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)

        Dim ErrorFile As String = "Detalle_Carga_ListaPrecio_Errada_" & DateTime.Now.ToString("ddMMyyyy")
        Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & ErrorFile & ".txt"))

        Dim arLisPAcuerdo As ArrayList = obj.ListaPlazoAcuerdo()
        Dim retorno As String
        Try
            Dim correcto As Boolean
            Dim input As String
            input = re.ReadLine()
            Dim contError As Integer = 0
            Dim contCorrecto As Integer = 0
            Dim cadena As String
            Dim dtTrue As New DataTable
            Dim dtResultado As New DataTable
            Dim dcListaPrecioC As New DataColumn("LISTA_PRECIO", GetType(String))
            Dim dcPlazoAcuerdoC As New DataColumn("PLAZO_ACUERDO", GetType(String))
            Dim dcDescripcion As New DataColumn("RSL_DESCRIPCION", GetType(String))
            Dim dcCantidad As New DataColumn("RSL_CANTIDAD", GetType(Integer))

            dtTrue.Columns.Add(dcListaPrecioC)
            dtTrue.Columns.Add(dcPlazoAcuerdoC)

            dtResultado.Columns.Add(dcDescripcion)
            dtResultado.Columns.Add(dcCantidad)

            Dim dr As DataRow
            Dim longitud As Integer
            While Not input Is Nothing
                Dim linea As String() = input.Split(",")
                If linea.Length = 2 Then
                    If (linea(0).Length >= 1 And linea(0).Length <= 3) And linea(1).Length = 2 Then
                        If soloLetrasyNumeros(linea(0)) Then
                            If soloNumeros(linea(1)) Then
                                Dim valRespuesta As Boolean = False
                                Dim dato As String
                                For i As Integer = 0 To arLisPAcuerdo.Count - 1
                                    dato = CType(arLisPAcuerdo(i), ItemGenerico).Codigo
                                    If dato = linea(1) Then
                                        valRespuesta = True
                                        Exit For
                                    End If
                                Next
                                If valRespuesta Then
                                    contCorrecto = contCorrecto + 1
                                    dr = dtTrue.NewRow
                                    dr("LISTA_PRECIO") = linea(0)
                                    dr("PLAZO_ACUERDO") = linea(1)
                                    dtTrue.Rows.Add(dr)
                                Else
                                    sw.WriteLine(linea(0) & "," & linea(1) & " " & ConfigurationSettings.AppSettings("msjValidaErrorRegistro"))
                                    contError = contError + 1
                                End If
                            Else
                                sw.WriteLine(linea(0) & "," & linea(1) & " " & ConfigurationSettings.AppSettings("msjValidaErrorFormato"))
                                contError = contError + 1
                            End If
                        Else
                            sw.WriteLine(linea(0) & "," & linea(1) & " " & ConfigurationSettings.AppSettings("msjValidaErrorFormato"))
                            contError = contError + 1
                        End If
                    Else
                        sw.WriteLine(linea(0) & "," & linea(1) & " " & ConfigurationSettings.AppSettings("msjValidaErrorFormato"))
                        contError = contError + 1
                    End If
                Else
                    sw.WriteLine(input & " " & ConfigurationSettings.AppSettings("msjValidaErrorFormato"))
                    contError = contError + 1
                End If
                input = re.ReadLine()
            End While
            sw.Close()
            viewstate("DocError") = ErrorFile
            viewstate("CantError") = contError

            If dtTrue.Rows.Count > 0 Then
                Dim vDatos As String = ""
                Dim cont As Integer = 0
                For c As Integer = 0 To dtTrue.Rows.Count - 1
                    If c = 0 Or vDatos = "" Then
                        vDatos = dtTrue.Rows(c).Item("LISTA_PRECIO") & "," & dtTrue.Rows(c).Item("PLAZO_ACUERDO")
                    Else
                        vDatos = vDatos & "|" & dtTrue.Rows(c).Item("LISTA_PRECIO") & "," & dtTrue.Rows(c).Item("PLAZO_ACUERDO")
                    End If
                    cont = cont + 1
                    If cont = 500 Then
                        obj.GuardarLprecioPacuerdo(vDatos, CurrentUser)
                        cont = 0
                        vDatos = ""
                    End If
                Next
                obj.GuardarLprecioPacuerdo(vDatos, CurrentUser)
            End If
            dr = dtResultado.NewRow
            dr("RSL_DESCRIPCION") = "Registros procesados correctamente"
            dr("RSL_CANTIDAD") = contCorrecto
            dtResultado.Rows.Add(dr)

            dr = dtResultado.NewRow
            dr("RSL_DESCRIPCION") = "Registros no procesados"
            dr("RSL_CANTIDAD") = contError
            dtResultado.Rows.Add(dr)

            dr = dtResultado.NewRow
            dr("RSL_DESCRIPCION") = "Total Registros"
            dr("RSL_CANTIDAD") = contCorrecto + contError
            dtResultado.Rows.Add(dr)

            Me.dgResultado.DataSource = dtResultado
            Me.dgResultado.DataBind()

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

    Function soloNumeros(ByVal cadena As String) As Boolean
        Dim valida As Boolean
        Dim resultado As Boolean = True
        Dim n As Integer

        For n = 0 To Len(cadena) - 1
            valida = Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\d").Success()
            If valida = False Then
                resultado = valida
            End If
        Next n
        Return resultado
    End Function

    Function soloLetrasyNumeros(ByVal cadena As String) As Boolean
        Dim validaN As Boolean
        Dim validaL As Boolean
        Dim resultado As Boolean = True
        Dim n As Integer

        For n = 0 To Len(cadena) - 1
            validaL = Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\w").Success()
            validaN = Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\d").Success()
            If validaL = False And validaN = False Then
                resultado = False
            End If
        Next n
        Return resultado
    End Function

    Private Sub btDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDetalle.Click
        Dim newFile As String = viewstate("DocError")
        Dim cantError As Integer = viewstate("CantError")
        Try
            If Not (newFile Is Nothing) OrElse newFile <> "" Then
                If cantError > 0 Then
                    Dim fs As System.IO.FileStream = Nothing
                    fs = System.IO.File.Open(Server.MapPath(rutaOrigen & "/" & newFile & _
                            ".txt"), System.IO.FileMode.Open)
                    Dim btFile(fs.Length) As Byte
                    fs.Read(btFile, 0, fs.Length)
                    fs.Close()
                    With Response
                        .Clear()
                        .AddHeader("Content-disposition", "attachment;filename=" & newFile & ".txt")
                        .ContentType = "application/octet-stream"
                        .BinaryWrite(btFile)
                        .End()
                    End With
                Else
                    RegisterStartupScript("script", "<script>alert('No existen registros erroneos en la carga');</script>")
                End If
            Else
                RegisterStartupScript("script", "<script>alert('Debe cargar un archivo primero');</script>")
            End If
        Catch ex As Exception

        Finally
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantLpPaDetalle"), "Detalle Lista de Precio - Plazo Acuerdo")
        End Try
    End Sub

    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoCargados As String
        Dim strArchivoError As String
        Try
            strArchivo = Server.MapPath(rutaOrigen) & "\" & "carga_masiva_lpPa_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & "lista_carga_LpPa_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoError = Server.MapPath(rutaOrigen) & "\" & "error_carga_LpPa_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            If File.Exists(strArchivo) Then
                System.IO.File.Delete(strArchivo)
            End If
            If File.Exists(strArchivoCargados) Then
                System.IO.File.Delete(strArchivoCargados)
            End If
            If File.Exists(strArchivoError) Then
                System.IO.File.Delete(strArchivoError)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExportar.Click
        Dim obj As New MaestroNegocio
        Dim strDatos As ArrayList
        Dim strDatosDet As String
        Dim cantProc As Integer
        Dim arDatos() As String
        Dim numReg As Integer = 0
        Dim totalReg As Integer = obj.ListarCantidadRegLpPa
        Dim newFile As String = "Reporte_ListaPrecio_" & DateTime.Now.ToString("ddMMyyyy")
        Dim lprecio, pacuerdo As String
        Dim Linea As String

        eliminarArchivo()

        Dim sw As New System.IO.StreamWriter(Server.MapPath(rutaOrigen & "/" & newFile & ".txt"))

        Try
            If totalReg > 0 Then
                For i As Integer = 0 To totalReg
                    If i < totalReg Then
                        strDatos = obj.ListaLprecioPacuerdo(CStr(numReg))
                        strDatosDet = CType(strDatos(0), ItemGenerico).Descripcion
                        cantProc = CType(strDatos(0), ItemGenerico).orden

                        If strDatosDet <> "" Then
                            For d As Integer = 0 To strDatosDet.Split("|").Length() - 1
                                arDatos = strDatosDet.Split("|")
                                Linea = arDatos(d)
                                sw.WriteLine(Linea)
                            Next
                            i = cantProc - 1
                            numReg = cantProc
                            strDatos = Nothing
                        End If
                    End If
                Next

                sw.Flush()
                sw.Close()
                Dim fs As System.IO.FileStream = Nothing

                fs = System.IO.File.Open(Server.MapPath(rutaOrigen & "/" & newFile & _
                        ".txt"), System.IO.FileMode.Open)
                Dim btFile(fs.Length) As Byte
                fs.Read(btFile, 0, fs.Length)
                fs.Close()
                eliminarArchivo()
                With Response
                    .Clear()
                    .AddHeader("Content-disposition", "attachment;filename=" & newFile & ".txt")
                    .ContentType = "application/octet-stream"
                    .BinaryWrite(btFile)
                    .End()
                End With
            Else
                RegisterStartupScript("script", "<script>alert('No existen registros cargados');</script>")
            End If
        Catch ex As Exception
            sw.Flush()
            RegisterStartupScript("script", "<script>alert('Error al exportar carga');</script>")
        Finally
            sw.Close()
            Auditoria(ConfigurationSettings.AppSettings("codTrsMantLpPaExportar"), "Exportar Archivo Lista de Precio - Plazo Acuerdo")
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

End Class
