Option Strict Off
Imports System.IO

Public Class sisact_ver_documento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        If Not Page.IsPostBack Then
            If Request.QueryString("strNomArchivo") Is Nothing Or Request.QueryString("id") Is Nothing Then
                Response.End()
            End If
            MostrarArchivo(Request.QueryString("strNomArchivo"), Request.QueryString("id"))
        End If
    End Sub
    Sub MostrarArchivo(ByVal strArchivo As String, ByVal id As String)
        Try
            strArchivo = strArchivo.Replace("Å", "\")
            Dim objFileFTP As New ControlProxyFTP
            Dim rutaArchivo As String
            Try
                Dim arrExtension() As String
                arrExtension = strArchivo.Split(".")
                rutaArchivo = ConfigurationSettings.AppSettings("strRutaOrigenDOL") & "\" & id & "." & arrExtension(arrExtension.Length() - 1)
                Dim strResultado As String = objFileFTP.DownloadFileFTP(strArchivo, rutaArchivo)
            Catch ex As Exception
                Response.Write("<script>alert('No se pudo obtener el archivo.');window.close();</script>")
            End Try

            Dim strPathFileServer As String = rutaArchivo
            Dim objDocumento As Object
            Dim blnExisteArchivo As Boolean = False
            Dim strExtension() As String
            objDocumento = CreateObject("Documento_Util.clsUtilitario")
            
            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
            Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
            impersonationContext = currentWindowsIdentity.Impersonate()

            blnExisteArchivo = objDocumento.FP_existeArchivo(strPathFileServer)
            objDocumento = Nothing

            If blnExisteArchivo Then
                GenerarArchivo(strPathFileServer, "")
            Else
                Response.Write("<script>alert('El archivo no Existe');window.close();</script>")
            End If
        Catch ex As Exception
            Response.Write("<script>alert('" & ex.Message.ToString & "');window.close();</script>")
        End Try
    End Sub

    Sub GenerarArchivo(ByVal strFilePath As String, ByVal strExtension As String)
        Dim fs As New FileStream(strFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim Buffer(fs.Length) As Byte
        fs.Read(Buffer, 0, CInt(fs.Length))
        fs.Close()
        Response.BufferOutput = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.AddHeader("content-length", Buffer.Length)
        Response.AddHeader("content-disposition", "inline")
        If strExtension = "pdf" Then
            Response.ContentType = "application/pdf"
        ElseIf strExtension = "gif" Then
            Response.ContentType = "image/gif"
        ElseIf strExtension = "tif" Then
            Response.ContentType = "image/tiff"
        End If

        Response.BinaryWrite(Buffer)
        fs.Close()
        Response.Flush()
        eliminarArchivo(strFilePath)
        Response.End()
    End Sub

    Sub eliminarArchivo(ByVal strArchivo As String)
        Try
            File.Delete(strArchivo)
        Catch ex As Exception
        End Try
    End Sub
End Class
