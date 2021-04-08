Option Strict Off
Namespace Claro.SisAct.Web.Funciones
    Public Class sisact_auditoria
        Public Function RegistrarAuditoria(ByVal pdblCodUsuario As Double, ByVal strHost As String, _
                                           ByVal pstrIP As String, ByVal pdblCodOpcion As Double, _
                                           ByVal pintResultado As Integer, ByVal pstrDescripcion As String, _
                                           ByVal pdblCodEvento As Double, _
                                           ByVal pdblCodPerfil As Double, ByVal pstrLogin As String, _
                                           ByVal pintCodEstado As Integer, ByVal pDetalleAuditoria(,) As Object) As Double
            Dim objAuditoria As Object
            Dim dblResultado As Double
            Dim dblCodAplicacion As Double
            objAuditoria = CreateObject("Audi_Bus.Auditoria")
            'Procedemos a la grabacion de los datos.
            'strHost = GetHost(pstrIP)
            dblCodAplicacion = CType(ConfigurationSettings.AppSettings("CodAplicacion"), Double)
            dblResultado = objAuditoria.AddAuditoria(pdblCodUsuario, pstrIP, strHost, pdblCodOpcion, pintResultado, pstrDescripcion, dblCodAplicacion, pdblCodEvento, pdblCodPerfil, pstrLogin, pintCodEstado, pDetalleAuditoria)
            objAuditoria = Nothing
            Return dblResultado
        End Function

        Public Function GetHost(ByVal pstrIP As String) As String
            Dim objSeguBus As Object
            Dim strResultado As String
            objSeguBus = CreateObject("Segu_Bus.Host")
            strResultado = objSeguBus.GetHost(pstrIP)
            objSeguBus = Nothing
            Return strResultado
        End Function

        Public Function ListarAccesosPagina(ByVal strCodUsuario As String) As String
            Dim salida As String = sisact_session.ObtenerListaOpciones
            If salida <> "" Then
                Return salida
            End If
            HttpContext.Current.Session.Add("ListaOpciones", salida)

            Dim objOpciones As Object
            Dim rsConsulta As ADODB.Recordset
            Dim codAplicacion As String
            Dim strClaves As String
            codAplicacion = CType(ConfigurationSettings.AppSettings("CodigoAplicacion"), Integer)
            rsConsulta = CreateObject("ADODB.Recordset")
            objOpciones = CreateObject("Segu_DB.Acceso")
            rsConsulta = objOpciones.GetOpcionesPagina(strCodUsuario, codAplicacion)
            objOpciones = Nothing
            If Not (rsConsulta.EOF And rsConsulta.BOF) Then
                strClaves = ""
                While Not rsConsulta.EOF
                    strClaves = strClaves & CType(rsConsulta("clave").Value, String) & ","
                    rsConsulta.MoveNext()
                End While
            End If
            rsConsulta.Close()
            rsConsulta = Nothing
            strClaves = UCase(strClaves)
            sisact_session.ObtenerListaOpciones = strClaves
            Return strClaves
        End Function
    End Class
End Namespace


