Public Class DownloadCasosEspeciales
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
        'Put user code to initialize the page here
        Dim filenamee As String = Request.QueryString.Get("FileName")
        If Not filenamee Is Nothing Then
            Dim applicationPath As String = System.Web.HttpContext.Current.Request.ApplicationPath
            applicationPath = System.Web.HttpContext.Current.Server.MapPath(applicationPath & "\" & filenamee)
            Dim toDownload As System.IO.FileInfo = New System.IO.FileInfo(applicationPath)
            If toDownload.Exists Then
                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=" & toDownload.Name)
                Response.AddHeader("Content-Length", toDownload.Length.ToString())
                Response.ContentType = "application/octet-stream"
                Response.WriteFile(applicationPath)
                Response.End()
            End If
        End If
    End Sub

End Class
