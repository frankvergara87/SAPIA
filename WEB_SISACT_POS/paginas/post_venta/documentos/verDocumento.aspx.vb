Option Strict Off
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports System.IO
Imports System.Text
Imports Claro.SisAct.Negocios
Imports System

Public Class verDocumento
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Declare Function InternetCloseHandle Lib "wininet.dll" (ByVal HINet As Integer) As Integer
    Private Declare Function InternetOpen Lib "wininet.dll" Alias "InternetOpenA" (ByVal sAgent As String, ByVal lAccessType As Integer, ByVal sProxyName As String, ByVal sProxyBypass As String, ByVal lFlags As Integer) As Integer
    Private Declare Function InternetConnect Lib "wininet.dll" Alias "InternetConnectA" (ByVal hInternetSession As Integer, ByVal sServerName As String, ByVal nServerPort As Integer, ByVal sUsername As String, ByVal sPassword As String, ByVal lService As Integer, ByVal ByVallFlags As Integer, ByVal lContext As Integer) As Integer
    Private Declare Function FtpPutFile Lib "wininet.dll" Alias "FtpPutFileA" (ByVal hFtpSession As Integer, ByVal lpszLocalFile As String, ByVal lpszRemoteFile As String, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
    Private Declare Function FtpGetFile Lib "wininet.dll" Alias "FtpGetFileA" (ByVal hFtpSession As Integer, ByVal lpszRemoteFile As String, ByVal lpszLocalFile As String, ByVal fFailIfExists As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
    Private Declare Function FtpRenameFile Lib "wininet.dll" Alias "FtpRenameFileA" (ByVal hFtpSession As Integer, ByVal lpszExisting As String, ByVal lpszNew As String) As Boolean
    Const FTP_TRANSFER_TYPE_BINARY = &H2
    Const INTERNET_OPEN_TYPE_PRECONFIG = 0 ' use registry configuration

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        Dim sNombreArchivo As String
        If (Request.QueryString("nombrearchivo").ToString <> "") Then
            '--
            sNombreArchivo = Request.QueryString("nombrearchivo")
            VisualizaDocumento(sNombreArchivo)
        Else
            Me.RegisterStartupScript("Error Reporte", "<script> alert('El archivo o documento solicitado no existe.'); window.close(); </script>")

        End If

    End Sub

    Private Sub VisualizaDocumento_OLD(ByVal p_Archivo As String)
        '--
        Dim bResultado As Boolean = False
        Dim sRutaNombreLocal As String
        Dim sRutaNombreTemp As String
        '---
        Try
            '---
            Dim Random As New Random
            Dim sTipoArchivo As String = Path.GetExtension(p_Archivo)
            Dim sNombreAleatorio As String = Path.GetFileNameWithoutExtension(p_Archivo) + Funciones.CheckStr(Random.Next(0, Integer.MaxValue)) + sTipoArchivo
            Random = Nothing
            '---ruta y nombre local
            sRutaNombreLocal = ConfigurationSettings.AppSettings("ACU_CORP_RutaOrigen").ToString + "\" + sNombreAleatorio
            '---
            sRutaNombreTemp = ConfigurationSettings.AppSettings("ACU_CORP_RutaDestino") + "/" + p_Archivo

            '----download de ruta FTP
            Dim MyFileServer As New ControlFileTransfer
            bResultado = MyFileServer.DownloadFileFTP(sRutaNombreTemp, sRutaNombreLocal)
            MyFileServer = Nothing
            '---
            If (bResultado) Then

                '--
                Dim fecha As String = String.Format("{0:ddMMyyyyhhmmss}", Now())
                Response.Clear()
                Response.ContentType = F_ObtieneContentType(sTipoArchivo)
                Response.AddHeader("Content-Disposition", "attachment; filename=documento_" + fecha + sTipoArchivo)
                Response.WriteFile(sRutaNombreLocal)
                Response.Flush()
                Response.Close()
                '//Response.End()'//no permite ejecutar codigo posterior
                '----
                If (File.Exists(sRutaNombreLocal)) Then
                    File.Delete(sRutaNombreLocal)
                End If

            Else
                Dim script As String = String.Format("<script>alert('{0}');window.close();</script>", Mensajes.CHECKLIST_ERROR_ARCHIVO_NO_EXISTE)
                Me.Page.RegisterClientScriptBlock("clientScript", script)
            End If

        Catch Ex As Exception
            Me.RegisterStartupScript("Error Reporte", "<script> alert('No es posible generar el reporte. Consulte con el Administrador.'); window.close(); </script>")
        End Try

    End Sub

    Public Function VisualizaDocumento(ByVal p_Archivo As String) As Boolean
        Dim flag As Boolean = False

        Dim rutaServ As String = ConfigurationSettings.AppSettings("ACU_CORP_RutaDestino").ToString 'Ruta carpeta compartida
        Dim sRutaNombreServ As String = String.Empty

        Try
            Dim fecha As String = String.Format("{0:ddMMyyyyhhmmss}", Now())
            Dim sTipoArchivo As String = Path.GetExtension(p_Archivo)
            sRutaNombreServ = rutaServ & p_Archivo

            MostrarArchivo(sRutaNombreServ)
        Catch ex As Exception
            'Throw New Exception(ex.Message)
            Me.RegisterStartupScript("Error Reporte", "<script> alert('No es posible descargar el archivo. Consulte con el Administrador.'); window.close(); </script>")
        Finally
            'InternetCloseHandle(INet)
        End Try
        Return flag
    End Function


    Private Sub MostrarArchivo(ByVal strNombreArchivo As String)
        Dim strExtension As String = ""
        Dim strNombreArchivoTemp As String = ""

        Dim objDocumento As Object
        Dim arrDocumento As Object
        Dim strTipoContenido As String = ""
        Dim binStream As Object

        Dim fecha As String = String.Format("{0:ddMMyyyyhhmmss}", Now())
        strExtension = Right(strNombreArchivo, Len(strNombreArchivo) - InStrRev(strNombreArchivo, "."))
        strNombreArchivoTemp = "documento_" & fecha & "." & strExtension

        Try
            objDocumento = Server.CreateObject("GLOBALCARE_DB.clsDocumento")

            arrDocumento = objDocumento.FP_MostrarTipoDoc(strExtension)
            If IsArray(arrDocumento) Then
                strTipoContenido = arrDocumento(0, 0)
            End If

            objDocumento = Server.CreateObject("GLOBALCARE_BUS.clsDocumento")
            binStream = objDocumento.FP_LeerArchivoBinario(strNombreArchivo)

            strTipoContenido = F_ObtieneContentType("." & strExtension)
            Response.Clear()
            Response.BufferOutput = True
            Response.AddHeader("WWW-Authenticate", "BASIC")
            Response.AddHeader("content-disposition", "inline; filename=" & strNombreArchivoTemp)
            Response.ContentType = strTipoContenido
            Response.BinaryWrite(binStream)
            Response.Flush()
            'Response.Close()
            Response.End()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Function F_ObtieneContentType(ByVal pExtArchivo As String) As String

        pExtArchivo = pExtArchivo.ToLower

        If pExtArchivo = ".htm" Or pExtArchivo = ".html" Then
            Return "text/html"
        ElseIf pExtArchivo = ".xls" Then
            Return "application/vnd.ms-excel"
        ElseIf pExtArchivo = ".txt" Then
            Return "text/plain"
        ElseIf pExtArchivo = ".pdf" Then
            Return "application/pdf"
        ElseIf pExtArchivo = ".xml" Then
            Return "text/xml"
        ElseIf pExtArchivo = ".doc" Then
            Return "application/msword"
        ElseIf pExtArchivo = ".rtf" Then
            Return "application/rtf"
        ElseIf pExtArchivo = ".odt" Then
            Return "application/vnd.oasis.opendocument.text"
        ElseIf pExtArchivo = ".ods" Then
            Return "application/vnd.oasis.opendocument.spreadsheet"
            '//imagenes    
        ElseIf pExtArchivo = ".png" Then
            Return "image/png"
        ElseIf pExtArchivo = ".jpg" Or pExtArchivo = ".jpeg" Then
            Return "image/jpeg"
        ElseIf pExtArchivo = ".gif" Then
            Return "image/gif"
        ElseIf pExtArchivo = ".bmp" Then
            Return "image/bmp"
        ElseIf pExtArchivo = ".tif" Or pExtArchivo = ".tiff" Then
            Return "image/tiff"
        ElseIf pExtArchivo = ".zip" Then
            Return "application/zip"
        ElseIf pExtArchivo = ".rar" Then
            Return "application/x-rar-compressed"
        ElseIf pExtArchivo = ".ppt" Then
            Return "application/mspowerpoint"
        Else
            Return ""
        End If

    End Function
End Class