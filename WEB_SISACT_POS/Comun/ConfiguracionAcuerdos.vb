Imports System
Imports Claro.SisAct.Common.Funciones

Public NotInheritable Class ConfiguracionAcuerdos

    Public Shared Sub GetDimensionAcuerdo(ByVal pIDDocumento As Integer, ByRef pAncho As Integer, ByRef pAlto As Integer)
        '--determina ancho y alto en funciona  Documento   
        If (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B01"))) Then
            pAlto = 600
            pAncho = 970
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B02"))) Then
            pAlto = 600
            pAncho = 820
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B03"))) Then
            pAlto = 600
            pAncho = 970
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B04"))) Then
            pAlto = 600
            pAncho = 950
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B05"))) Then
            pAlto = 600
            pAncho = 840
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B22"))) Then
            pAlto = 420
            pAncho = 825
        ElseIf (pIDDocumento = CheckInt(ConfigurationSettings.AppSettings("B29"))) Then
            pAlto = 600
            pAncho = 980
        Else '----
            pAlto = 600
            pAncho = 820
        End If
    End Sub

End Class
