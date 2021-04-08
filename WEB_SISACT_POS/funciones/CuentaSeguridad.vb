Imports System
Imports System.Configuration

Public Class CuentaSeguridad
    Protected _KeyAcuerdoCorp As String
    Protected _User As String
    Protected _Password As String
    Protected _Tipo As Type

    Public ReadOnly Property User() As String
        Get
            Return _User
        End Get

    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _Password
        End Get

    End Property

    Public Sub New(ByVal pCodAplicacion As String)
        If (pCodAplicacion = ConfigurationSettings.AppSettings("COD_APP_REGISTRO_DOCUMENTO").ToString) Then
            InicializarCuenta_APP_ACUERDO_CORPORATIVO()
        End If
        If (pCodAplicacion = ConfigurationSettings.AppSettings("COD_APP_UPLOAD_MIGRACION").ToString) Then
            InicializarCuenta_UPLOAD_MIGRACION()
        End If
    End Sub


    Protected Sub InicializarCuenta_APP_ACUERDO_CORPORATIVO()      

            _KeyAcuerdoCorp = ConfigurationSettings.AppSettings("DOC_Key").ToString()

        Dim oConfigConexionCS As Claro.SisAct.Configuracion.ConfigConexionCS = Claro.SisAct.Configuracion.ConfigConexionCS.GetInstance(_KeyAcuerdoCorp)
        _User = oConfigConexionCS.Parametros.Usuario
        _Password = oConfigConexionCS.Parametros.Password
        
    End Sub

    Protected Sub InicializarCuenta_UPLOAD_MIGRACION()

        _KeyAcuerdoCorp = ConfigurationSettings.AppSettings("KEY_UPLOAD_MIGRACION").ToString()

        Dim oConfigConexionCS As Claro.SisAct.Configuracion.ConfigConexionCS = Claro.SisAct.Configuracion.ConfigConexionCS.GetInstance(_KeyAcuerdoCorp)
        _User = oConfigConexionCS.Parametros.Usuario
        _Password = oConfigConexionCS.Parametros.Password

    End Sub
End Class
