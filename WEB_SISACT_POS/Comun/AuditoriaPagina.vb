Imports Claro.SisAct.Negocios

Public Class AuditoriaPagina
    Public Shared Function Auditoria(ByVal strTransaccion As String, ByVal strDesTransaccion As String, ByVal usuario_id As String, ByVal ipcliente As String) As Boolean


        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

        Dim flag As Boolean
        Try
            flag = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTransaccion)
        Catch ex As Exception
            flag = False
        End Try

        Return flag

        '//Return True

    End Function
End Class
