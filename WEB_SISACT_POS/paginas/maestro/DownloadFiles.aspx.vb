Public Class DownloadFiles
    Inherits System.Web.UI.Page

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina

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
