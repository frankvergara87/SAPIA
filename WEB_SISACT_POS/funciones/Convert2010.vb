Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios

Module Convert2010
    Public Function ObtenerNumero(ByVal flagPais As Boolean, ByVal strNro As String) As String
        Dim vNroGenerado As String
        If strNro.Length = ConfigurationSettings.AppSettings("gConstKeyLongitudMaximaTelefono") Then
            If flagPais = True Then
                Return ConfigurationSettings.AppSettings("gConstKeyCodigoInternacional") + strNro
            Else
                Return strNro
            End If
        Else
            Return strNro
        End If
    End Function

End Module
