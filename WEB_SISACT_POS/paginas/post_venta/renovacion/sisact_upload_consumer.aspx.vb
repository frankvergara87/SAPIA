Option Strict Off
Imports System.IO
Imports Claro.SisAct.Common.Funciones
Imports ABCUpload4

Public Class sisact_upload_consumer
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidNombreArchivo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlag As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLista As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtFile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents hidFl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidtamanioMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidtamanioMin As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsuarioExt As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private strFlagResultado As String
    Private strMensaje As String
    Private rutaDestino As String = ConfigurationSettings.AppSettings("constRutaUploadFileConsumer")

    Dim oLog As New SISACT_Log
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_UploadFileConsumer")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")

        If (Session("codUsuarioSisact") Is Nothing And Request.QueryString("cu") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            hidUsuarioExt.Value = Session("CodUsuarioSisact")
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                Dim lista As String = Request.QueryString("listaArchivos")
                hidLista.Value = lista
            End If
            Dim strAccion As String = Request.QueryString("Action")
            If Trim(strAccion) = "1" Then
                UploadArchivo()
            End If
        End If
    End Sub

    Private Sub UploadArchivo()
        Dim RequestXForm As Object
        Dim objFile As Object
        Dim strFile As String = ""
        Dim strRutaAux As String
        Dim strRuta As String
        Try
            Dim nombreArchivo As String = System.IO.Path.GetFileName(txtFile.PostedFile.FileName)
            Dim rutaArchivo As String = ""
            If txtFile.Value = "" Then
                RegisterStartupScript("script", "<script>alert('Debe Seleccionar un archivo');</script>")
                Exit Sub
            End If

            Dim intExtension As Integer = nombreArchivo.LastIndexOf(".")
            Dim extension As String = nombreArchivo.Substring(intExtension, nombreArchivo.Length - intExtension)
            If extension.ToUpper = ".TIF" Or extension.ToUpper = ".GIF" Or extension.ToUpper = ".JPG" Or extension.ToUpper = ".DOC" Or extension.ToUpper = ".PDF" Or extension.ToUpper = ".XLS" Or extension.ToUpper = ".CSV" Or extension.ToUpper = ".RTF" Or extension.ToUpper = ".TXT" Or extension.ToUpper = ".ZIP" Or extension.ToUpper = ".RAR" Then
                oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso extension")
                If txtFile.PostedFile.ContentLength = 0 Then
                    RegisterStartupScript("script", "<script>alert('El Archivo debe contener información');</script>")
                    Exit Sub

                Else
                    'Instanciando al objeto servidor
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso")
                    RequestXForm = Server.CreateObject("ABCUpload4.XForm")
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso1")
                    RequestXForm.MaxUploadSize = CheckInt(ConfigurationSettings.AppSettings("MAX_UPLOAD_SIZE"))
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso2")
                    RequestXForm.AbsolutePath = True
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso3")
                    RequestXForm.Overwrite = True
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso4")

                    objFile = RequestXForm("txtFile")(1)
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso5")
                    If (objFile.rawfilename <> "") Then strFile = objFile.rawFileName
                    oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso6")
                    If objFile.Length > 512001 Then
                        RegisterStartupScript("script", "<script>alert('El archivo sobrepasa el tamaño máximo permitido');</script>")
                        Exit Sub
                    Else
                        oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso7")
                        strRutaAux = rutaDestino + String.Format("{0:ddMMyyyyhhmmss}", Now()) + strFile
                        oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso8")
                        objFile.Save(strRutaAux)
                        oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso9")
                        objFile = Nothing
                        oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "Ingreso10")
                        RequestXForm = Nothing

                        RegisterStartupScript("script language='javascript'", "<script>   var nombre = getValue('hidNombreArchivo'); if(getValue('hidAccion')=='grabar') { if(getValue('hidFl')!='0') {	 if (confirm('Su archivo ha sido incluido satisfactoriamente, Desea anexar otro documento?')==true) {window.opener.ifrArchivos.location.href = 'sisact_ListadoArchivosAdjuntos_consumer.aspx?listaArchivos='+nombre; setValue('hidAccion','');setValue('hidFlag','1');}else{window.opener.ifrArchivos.location.href = 'sisact_ListadoArchivosAdjuntos_consumer.aspx?listaArchivos='+nombre;window.close();setValue('hidAccion','');}}}</script>")
                    End If
                End If
            Else
                RegisterStartupScript("script", "<script>alert('Debe Seleccionar un archivo con extensión .GIF, .PDF, .TIF, .JPG, .DOC, .XLS, .CSV, .RTF, .TXT, .ZIP, .RAR' );</script>")
                Exit Sub
            End If




        Catch ex As Exception
            hidMsg.Value = ex.Message
            objFile = Nothing
            RequestXForm = Nothing
            oLog.Log_WriteLog(strArchivo, "Prueba" & " - " & "error por el componente")
            RegisterStartupScript("script", "<script>alert('Ocurrio un error interno al momento de cargar el archivo');</script>")
            'Response.Write("<script language=jscript> parent.ResultadoUpload('0','" & strRutaAux & "','" & ex.Message & "')</script>")
        End Try
        hidNombreArchivo.Value = strRutaAux & "|" & strFile & "|" & "0"
        hidFlag.Value = "0"
    End Sub

End Class
