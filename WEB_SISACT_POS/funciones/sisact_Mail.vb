Imports System.Web.Mail
Module sisact_Mail
    Public Function EnviarEmail(ByVal vRemitente As String, _
                                      ByVal vPara As String, _
                                      ByVal vCC As String, _
                                      ByVal vBCC As String, _
                                      ByVal vAsunto As String, _
                                      ByVal vMensaje As String, _
                                      ByVal vAdjunto As String) As String
        Dim salida As String = ""
        Dim oMail As New MailMessage
        oMail.From = vRemitente
        oMail.To = vPara
        oMail.Cc = vCC
        oMail.Bcc = vBCC
        oMail.Subject = vAsunto
        oMail.Body = System.Web.HttpContext.Current.Server.HtmlDecode(vMensaje)
        oMail.BodyFormat = MailFormat.Html
        Try
            Dim arrAdjuntos As String() = vAdjunto.Split(Char.Parse("|"))
            For Each sArchivo As String In arrAdjuntos
                If System.IO.File.Exists(sArchivo) Then oMail.Attachments.Add(New MailAttachment(sArchivo))
            Next
            SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("strEmailSmtp").ToString()
            SmtpMail.Send(oMail)
            salida = "OK"
        Catch ex As Exception
            salida = ex.Message
        Finally
            oMail = Nothing
        End Try
        Return salida
    End Function

End Module
