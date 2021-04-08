Option Strict Off
Imports System.IO
Imports System.Net.WebRequest
Imports System.Char
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports System.Data.OleDb
Imports ABCUpload4

Public Class sisact_carga_masiva_whitelist_televentas
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents txtConsolidado As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblResultado As System.Web.UI.WebControls.Label
    Protected WithEvents chkBorrarAgregar As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAgregar As System.Web.UI.WebControls.CheckBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private rutaOrigen As String = ConfigurationSettings.AppSettings("consRutaOrigenWhiteList")
    Private rutaDestino As String = ConfigurationSettings.AppSettings("consRutaDestinoWhiteList")
    Private ipFTP As String = ConfigurationSettings.AppSettings("consIPFTPWhiteList")
    Private puertoFTP As String = ConfigurationSettings.AppSettings("consPuertoFTPWhiteList")
    Private strCodigoAppMigra As String = ConfigurationSettings.AppSettings("COD_APP_UPLOAD_MIGRACION")

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
        btnCargar.Attributes.Add("onclick", "return validar();")
        If Not Page.IsPostBack Then
            RegisterStartupScript("script", "<script>document.getElementById('divResultado').style.display='none';</script>")
        End If
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim flag As Boolean

        If FileToUpload.Value <> "" Then
            If (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper = ".TXT" Then

                cargarArchivo()
                If ValidarDuplicados() Then
                    If ValidarArchivo(0) Then
                        CargarConfig()
                        flag = uploadFTP()
                        If (flag = True) Then
                            txtConsolidado.Text = "SE CARGÓ SATISFACTORIAMENTE EL ARCHIVO"
                        Else
                            txtConsolidado.Text = "NO SE PUDO CARGAR EL ARCHIVO"
                        End If
                    End If
                End If
                eliminarArchivo()
            ElseIf (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".TXT" Then
                RegisterStartupScript("script", "<script>alert('Debe Ingresar un Archivo válido con extensión .TXT');</script>")
            End If

        Else
            RegisterStartupScript("script", "<script>alert('Debe Ingresar una Ruta de Archivo válida');</script>")
        End If

    End Sub

    Public Function uploadFTP() As Boolean

        Dim objFileFTP As New ControlProxyFTP
        Dim pRutaArchivoOrigen As String
        Dim pRutaArchivoDestino As String
        Dim pRutaArchivoConfigOrigen As String
        Dim pRutaArchivoConfigDestino As String
        Dim flag As Boolean

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = Session("codUsuarioSisact")

        Try
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Migracion Carga Whitelist.")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")

            pRutaArchivoOrigen = Server.MapPath(rutaOrigen) & "\" & "carga_masiva_televentas_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            pRutaArchivoDestino = rutaDestino & "/" & "carga_masiva_televentas_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo uploadFTP()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP pRutaArchivoOrigen: " & pRutaArchivoOrigen)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP pRutaArchivoDestino: " & pRutaArchivoDestino)

            objFileFTP.PutFileFTP(pRutaArchivoOrigen, pRutaArchivoDestino, ipFTP, puertoFTP, strCodigoAppMigra)

            pRutaArchivoConfigOrigen = Server.MapPath(rutaOrigen) & "\" & "configuracion_wl_televentas.txt"
            pRutaArchivoConfigDestino = rutaDestino & "/" & "configuracion_wl_televentas.txt"

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP pRutaArchivoConfigOrigen: " & pRutaArchivoConfigOrigen)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP pRutaArchivoConfigDestino: " & pRutaArchivoConfigDestino)

            objFileFTP.PutFileFTP(pRutaArchivoConfigOrigen, pRutaArchivoConfigDestino, ipFTP, puertoFTP, strCodigoAppMigra)

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo uploadFTP()")

            flag = True
        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "ERROR Metodo uploadFTP(): " & ex.Message())
            flag = False
        Finally
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Migracion Carga Whitelist.")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        End Try
        Return flag
    End Function


    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoConfig As String
        Try
            strArchivo = Server.MapPath(rutaOrigen) & "\" & "carga_masiva_televentas_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoConfig = Server.MapPath(rutaOrigen) & "\" & "configuracion_wl_televentas.txt"

            If File.Exists(strArchivo) Then
                System.IO.File.Delete(strArchivo)
            End If
            If File.Exists(strArchivoConfig) Then
                System.IO.File.Delete(strArchivoConfig)
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub cargarArchivo()

        Dim RequestXForm As Object
        Dim objFilex As Object
        Dim strArchivo As String
        Dim strRutaWeb As String

        Try

            RequestXForm = Server.CreateObject("ABCUpload4.XForm")
            RequestXForm.MaxUploadSize = CheckInt(ConfigurationSettings.AppSettings("MAX_UPLOAD_SIZE"))
            RequestXForm.AbsolutePath = True
            RequestXForm.Overwrite = True
            objFilex = RequestXForm("FileToUpload")(1)
            strArchivo = "carga_masiva_televentas_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"

            'Grabamos el archivo en la ruta correspondiente
            strRutaWeb = Server.MapPath(rutaOrigen) & "/" & strArchivo

            objFilex.Save(strRutaWeb)
            RequestXForm = Nothing
            objFilex = Nothing
            ViewState("File") = strArchivo

        Catch ex As Exception
            txtConsolidado.Text = "NO SE PUDO CARGAR EL ARCHIVO"
        End Try
    End Sub

    Sub CargarConfig()
        Dim fp As StreamWriter
        Try
            Dim strArchivo As String
            strArchivo = "configuracion_wl_televentas" & ".txt"

            fp = File.CreateText(Server.MapPath(rutaOrigen) & "/" & strArchivo)
            Dim flag As String
            If chkBorrarAgregar.Checked Then
                flag = "1"
            Else
                flag = "0"
            End If

            fp.WriteLine(flag)
            fp.Close()
            ViewState("FileConf") = strArchivo
        Catch err As Exception
            'Error
        Finally
        End Try
    End Sub

    Private Sub Alerta(ByVal cadena As String)
        Page.Controls.Add(New LiteralControl("<script language = 'javascript'>alert('" & cadena & "');</script>"))
    End Sub

    Private Function ValidarArchivo(ByRef contador As Integer) As Boolean
        Dim archivo As String = ViewState("File")

        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)
        Try
            Dim input As String
            input = re.ReadLine()
            Dim cadena As String = ""

            While Not input Is Nothing
                If input <> "" Then
                    Dim linea As String() = input.Split(";")
                    contador = contador + 1
                    Dim tipoDocumento As String
                    If linea.Length = 20 Then
                        For i As Integer = 0 To linea.Length - 1
                            Select Case i
                                Case 0
                                    tipoDocumento = linea(i).Trim()
                                    If Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El codigo de tipo de documento no debe contener caracteres" & vbNewLine
                                    If linea(i).Trim().Length <> 2 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El codigo de tipo de documento debe tener 2 dígitos" & vbNewLine
                                Case 1

                                    If tipoDocumento = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") Then
                                        If Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Nro de documento no debe contener caracteres" & vbNewLine
                                        If linea(i).Trim().Length <> 8 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El DNI debe tener 8 dígitos" & vbNewLine
                                    ElseIf tipoDocumento = ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") Then
                                        If linea(i).Trim().Length <> 9 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Carnet de extranjería debe tener 9 dígitos" & vbNewLine
                                    Else
                                        cadena = cadena & "Error en linea " & contador.ToString() & " : Nro de documento inválido" & vbNewLine
                                    End If
                                Case 2
                                    If linea(i).Trim().Equals("") Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Apellido paterno no puede estar vacío" & vbNewLine
                                    If linea(i).Trim().Length > 30 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Apellido paterno excede el tamaño máximo permitido (30)" & vbNewLine
                                Case 3
                                    If linea(i).Trim().Equals("") Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Apellido materno no puede estar vacío" & vbNewLine
                                    If linea(i).Trim().Length > 30 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Apellido materno excede el tamaño máximo permitido (30)" & vbNewLine
                                Case 4
                                    If linea(i).Trim().Equals("") Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Nombre no puede estar vacío" & vbNewLine
                                    If linea(i).Trim().Length > 50 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Nombre excede el tamaño máximo permitido (50)" & vbNewLine
                                Case 5
                                    If Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Número de línea no debe contener caracteres" & vbNewLine
                                Case 6
                                    If Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Número cargo fijo máximo no debe contener caracteres" & vbNewLine
                                Case 7
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Tipo de garantía máximo no debe contener caracteres" & vbNewLine
                                    If linea(i).Trim().Length > 1 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Tipo de garantía máximo excede el tamaño máximo permitido (1)" & vbNewLine
                                Case 8
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Número de cargos fijos máximo no debe contener caracteres" & vbNewLine
                                Case 9
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El cargo fijo mínimo no debe contener caracteres" & vbNewLine
                                Case 10
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Tipo de garantía mínimo no debe contener caracteres" & vbNewLine
                                    If linea(i).Trim().Length > 1 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Tipo de garantía mínimo excede el tamaño máximo permitido" & vbNewLine
                                Case 11
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Número de cargos fijos mínimo no debe contener caracteres" & vbNewLine
                                Case 12
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Monto flat no debe contener caracteres" & vbNewLine
                                Case 13
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Flag de control de consumo no debe contener caracteres" & vbNewLine
                                    If linea(i).Trim().Length > 1 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Flag de control de consumo excede el tamaño máximo permitido" & vbNewLine
                                Case 14
                                    If linea(i).Trim().Equals("") Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Riesgo no puede estar vacío" & vbNewLine
                                    If Not IsLetter(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Riesgo solo debe contener 1 caracter" & vbNewLine
                                    If linea(i).Trim().Length > 1 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Riesgo excede el tamaño máximo permitido" & vbNewLine
                                Case 15
                                    If Not linea(i).Trim().Equals("") And Not IsLetter(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Score solo debe contener 1 caracter" & vbNewLine
                                    If linea(i).Trim().Length > 1 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Score excede el tamaño máximo permitido (1)" & vbNewLine
                                Case 16
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Score crediticio no debe contener caracteres" & vbNewLine
                                    If linea(i).Trim().Length > 2 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Score crediticio excede el tamaño máximo permitido (2)" & vbNewLine
                                Case 17
                                    If Not linea(i).Trim().Equals("") And Not IsNumeric(linea(i).Trim()) Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Límite de crédito no debe contener caracteres" & vbNewLine
                                Case 18
                                    If linea(i).Trim().Equals("") Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Código de plazo acuerdo no puede estar vacío" & vbNewLine
                                    If linea(i).Trim().Length > 50 Then cadena = cadena & "Error en linea " & contador.ToString() & " : El Código de plazo acuerdo excede el tamaño máximo permitido (50)" & vbNewLine
                            End Select
                        Next
                    Else
                        cadena = cadena & "Error en linea " & contador.ToString() & " : Cantidad de Columnas inválido" & vbNewLine
                    End If
                End If
                input = re.ReadLine()
            End While
            re.Close()
            re = Nothing
            txtConsolidado.Text = cadena
            If cadena.Equals("") Then Return True Else Return False

        Catch ex As Exception
            re = Nothing
            txtConsolidado.Text = "NO SE PUDO CARGAR EL ARCHIVO"
            Return False
        End Try

    End Function

    Private Function ValidarDuplicados() As Boolean
        Dim archivo As String = ViewState("File")

        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo)
        Try
            Dim input As String
            input = re.ReadLine()

            Dim cadena As String
            Dim dt As New DataTable
            Dim dcNro_Docum As New DataColumn("NRO_DOCUM", GetType(String))
            Dim dcNro_Linea As New DataColumn("NRO_LINEA", GetType(String))
            dt.Columns.Add(dcNro_Docum)
            dt.Columns.Add(dcNro_Linea)

            Dim dr As DataRow
            While Not input Is Nothing
                If input <> "" Then
                    Dim linea As String() = input.Split(";")
                    If linea.Length = 20 Then
                        dr = dt.NewRow
                        dr("NRO_DOCUM") = linea(1)
                        dr("NRO_LINEA") = linea(5)
                        dt.Rows.Add(dr)
                    End If
                End If
                input = re.ReadLine()
            End While
            re.Close()
            re = Nothing

            Dim cantidad As Integer
            Dim strMensaje As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                cantidad = dt.Select("NRO_DOCUM = '" & CStr(dt.Rows(i).Item(0)) & "' AND NRO_LINEA= '" & CStr(dt.Rows(i).Item(1)) & "'").Length
                If cantidad > 1 Then strMensaje = strMensaje & "Error en linea " & (i + 1).ToString() & " : El Nro de Documento " & CStr(dt.Rows(i).Item(0)) & " con el número de teléfono " & CStr(dt.Rows(i).Item(1)) & " se encuentra mas de una vez en el archivo" & vbNewLine
            Next
            txtConsolidado.Text = strMensaje
            If strMensaje.Equals("") Then Return True Else Return False

        Catch ex As Exception
            re = Nothing
            txtConsolidado.Text = "ERROR AL VALIDAR EL ARCHIVO"
            Return False
        End Try

    End Function

End Class
