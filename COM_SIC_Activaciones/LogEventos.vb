Imports System.Configuration

Public Class LogEventos
    Private strLOGPATH As String = ConfigurationSettings.AppSettings("strDirectorioLogSISACT")

    Public Function Log_CrearNombreArchivo(ByVal strTransaccion As String) As String
        Dim strFecha As String = Date.Now.ToString("yyyy-MM-dd")
        Dim Archivo As String = ""
        Archivo = strFecha & "_" & strTransaccion
        Return Archivo
    End Function

    Public Function Log_WriteLog(ByVal strNombreArchivoLog As String, ByVal strTexto As String) As String
        'Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
        'Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
        'impersonationContext = currentWindowsIdentity.Impersonate()
        Dim objFSO As Scripting.FileSystemObject
        Dim objFile0 As Scripting.TextStream
        Dim Archivo As String
        Dim strFecha As String = Date.Now.ToString("yyyy-MM-dd-hhmmss")
        Dim vTexto As String = ""
        Dim Resul As String = ""

        Try
            Archivo = strLOGPATH & "\" & strNombreArchivoLog.Trim() & ".txt"
            objFSO = New Scripting.FileSystemObject
            If Not objFSO.FileExists(Archivo) Then
                objFile0 = objFSO.CreateTextFile(Archivo, True, False)
            Else
                objFile0 = objFSO.OpenTextFile(Archivo, Scripting.IOMode.ForAppending)
            End If

            objFile0.Write(vTexto & Environment.NewLine & strFecha & "-->" & strTexto)

            objFile0.Close()
            objFile0 = Nothing
            objFSO = Nothing
            'impersonationContext.Undo()
        Catch ex As Exception
            objFSO = Nothing
            Resul = ex.Message
        End Try
        Return Resul
    End Function

End Class
