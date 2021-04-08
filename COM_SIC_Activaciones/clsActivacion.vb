Imports System.EnterpriseServices
Imports System.Configuration
'Imports COM_SIC_Promociones
'<Transaction(TransactionOption.Required), Synchronization(SynchronizationOption.Required), JustInTimeActivation(True)> _
Public Class clsActivacion
    '   Inherits ServicedComponent
    '<AutoComplete(True)> _
        Public Function FP_AccionGeneral(ByVal p_strURL As String, ByVal p_strServicio As String, _
                                            ByVal p_strUsuario As String, _
                                            ByVal p_strNombreCampo As String, _
                                            ByVal p_strValorCampo As String) As String

        Dim objComponente As Object

        objComponente = CreateObject("COM_PVU_Activacion.clsActivacion")
        objComponente.FP_SetUrlSvr(p_strURL)

        FP_AccionGeneral = objComponente.FP_AccionGeneral(p_strServicio, p_strUsuario, p_strNombreCampo, p_strValorCampo)

        objComponente = Nothing

    End Function
    '<AutoComplete(True)> _
        Public Function FK_ActivacionClienteRecurrente(ByVal p_ValorCampo As String, _
                                        ByVal StrUrl As String, _
                                        ByVal StrNomServicio As String, _
                                        ByVal strUsuario As String) As String

        Dim objComponente As Object

        objComponente = CreateObject("COM_PVU_Clie_Rec.clsActivacionCR")

        FK_ActivacionClienteRecurrente = objComponente.FK_ActivacionClienteRecurrente(p_ValorCampo, StrUrl, StrNomServicio, strUsuario)

        objComponente = Nothing

    End Function

    Public Function FK_CuentasClienteRecurrente(ByVal p_ValorCampo As String, _
                                ByVal StrUrl As String, _
                                ByVal StrNomServicio As String, _
                                ByVal strUsuario As String) As String

        Dim objComponente As Object

        objComponente = CreateObject("COM_PVU_Clie_Rec.clsActivacionCR")

        FK_CuentasClienteRecurrente = objComponente.FK_CuentasClienteRecurrente(p_ValorCampo, StrUrl, StrNomServicio, strUsuario)

        objComponente = Nothing

    End Function




End Class
