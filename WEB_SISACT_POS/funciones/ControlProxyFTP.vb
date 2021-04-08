Option Strict Off
Imports System
Imports System.Web
Imports System.Configuration
Imports System.IO

Public NotInheritable Class ControlProxyFTP

    Const TRANSFER_TYPE_ASCII = 1
    Const TRANSFER_TYPE_BINARY = 2


    Public Shared Function PutFileFTP(ByVal pRutaArchivoOrigen As String, ByVal pRutaArchivoDestino As String) As Boolean
        Dim objFTP As Object
        Dim bResultado As Boolean
        Dim sError As String


        Dim ipFTP As String = ConfigurationSettings.AppSettings("DOC_IPFTP").ToString
        Dim puertoFTP As String = ConfigurationSettings.AppSettings("DOC_PuertoFTP").ToString

        Dim objCuentaSegFS As New CuentaSeguridad(ConfigurationSettings.AppSettings("COD_APP_REGISTRO_DOCUMENTO").ToString)
        Dim userFTP As String = objCuentaSegFS.User
        Dim passFTP As String = objCuentaSegFS.Password
        objCuentaSegFS = Nothing


        'create reference to object
        objFTP = HttpContext.Current.Server.CreateObject("NIBLACK.ASPFTP")

        '---connection worked...now get the file
        bResultado = objFTP.bQPutFile(ipFTP, userFTP, passFTP, pRutaArchivoOrigen, pRutaArchivoDestino, TRANSFER_TYPE_BINARY)

        'get was successful
        If (Not bResultado) Then
            Throw New Exception(objFTP.sError)
        Else
            File.Delete(pRutaArchivoOrigen)
        End If

        '---
        objFTP = Nothing

        Return bResultado

    End Function

    Public Shared Function PutFileFTP(ByVal pRutaArchivoOrigen As String, ByVal pRutaArchivoDestino As String, ByVal strIPFTP As String, ByVal strPuertoFTP As String, ByVal strCodigoAppMigra As String) As Boolean
        Dim objFTP As Object
        Dim bResultado As Boolean
        Dim sError As String

        Dim objCuentaSegFS As New CuentaSeguridad(strCodigoAppMigra)
        Dim userFTP As String = objCuentaSegFS.User
        Dim passFTP As String = objCuentaSegFS.Password
        objCuentaSegFS = Nothing

        'create reference to object
        objFTP = HttpContext.Current.Server.CreateObject("NIBLACK.ASPFTP")

        '---connection worked...now get the file
        bResultado = objFTP.bQPutFile(strIPFTP, userFTP, passFTP, pRutaArchivoOrigen, pRutaArchivoDestino, TRANSFER_TYPE_BINARY)

        'get was successful
        If (Not bResultado) Then
            Throw New Exception(objFTP.sError)
        Else
            File.Delete(pRutaArchivoOrigen)
        End If

        '---
        objFTP = Nothing

        Return bResultado

    End Function

    Public Shared Function DeleteFileFTP(ByVal pRutaArchivo As String) As Boolean
        Dim objFTP As Object
        Dim bResultado As Boolean
        Dim sError As String


        Dim ipFTP As String = ConfigurationSettings.AppSettings("DOC_IPFTP").ToString
        Dim puertoFTP As String = ConfigurationSettings.AppSettings("DOC_PuertoFTP").ToString

        Dim objCuentaSegFS As New CuentaSeguridad(ConfigurationSettings.AppSettings("COD_APP_REGISTRO_DOCUMENTO").ToString)
        Dim userFTP As String = objCuentaSegFS.User
        Dim passFTP As String = objCuentaSegFS.Password
        objCuentaSegFS = Nothing


        'create reference to object
        objFTP = HttpContext.Current.Server.CreateObject("NIBLACK.ASPFTP")

        '---connection worked...now get the file
        bResultado = objFTP.bQDeleteFile(ipFTP, userFTP, passFTP, pRutaArchivo)
        'get was successful
        If (Not bResultado) Then
            Throw New Exception(objFTP.sError)
        End If

        '---
        objFTP = Nothing

        Return bResultado
    End Function

    Public Shared Function DownloadFileFTP(ByVal pRutaArchivoOrigen As String, ByVal pRutaArchivoDestino As String) As Boolean
        Dim objFTP As Object
        Dim bResultado As Boolean
        Dim sError As String


        Dim ipFTP As String = ConfigurationSettings.AppSettings("DOC_IPFTP").ToString
        Dim puertoFTP As String = ConfigurationSettings.AppSettings("DOC_PuertoFTP").ToString

        Dim objCuentaSegFS As New CuentaSeguridad(ConfigurationSettings.AppSettings("COD_APP_REGISTRO_DOCUMENTO").ToString)
        Dim userFTP As String = objCuentaSegFS.User
        Dim passFTP As String = objCuentaSegFS.Password
        objCuentaSegFS = Nothing

        'create reference to object
        objFTP = HttpContext.Current.Server.CreateObject("NIBLACK.ASPFTP")

        '---connection worked...now get the file
        bResultado = objFTP.bQGetFile(ipFTP, userFTP, passFTP, pRutaArchivoOrigen, pRutaArchivoDestino, TRANSFER_TYPE_BINARY, True)
        'get was successful
        If (Not bResultado) Then
            Throw New Exception(objFTP.sError)
        End If

        '---
        objFTP = Nothing

        Return bResultado

    End Function

    Public Shared Function MakeDirFTP(ByVal pDirectorio As String) As Boolean
        Dim objFTP As Object
        Dim bResultado As Boolean
        Dim sError As String


        Dim ipFTP As String = ConfigurationSettings.AppSettings("DOC_IPFTP").ToString
        Dim puertoFTP As String = ConfigurationSettings.AppSettings("DOC_PuertoFTP").ToString

        Dim objCuentaSegFS As New CuentaSeguridad(ConfigurationSettings.AppSettings("COD_APP_REGISTRO_DOCUMENTO").ToString)
        Dim userFTP As String = objCuentaSegFS.User
        Dim passFTP As String = objCuentaSegFS.Password
        objCuentaSegFS = Nothing


        'create reference to object
        objFTP = HttpContext.Current.Server.CreateObject("NIBLACK.ASPFTP")

        '---connection worked...now get the file
        bResultado = objFTP.bQMakeDir(ipFTP, userFTP, passFTP, pDirectorio)

        'get was successful
        If (Not bResultado) Then
            Throw New Exception(objFTP.sError)
        End If

        '---
        objFTP = Nothing

        Return bResultado

    End Function

End Class
