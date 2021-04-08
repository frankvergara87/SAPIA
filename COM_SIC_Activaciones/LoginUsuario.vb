Option Strict Off
Imports System.Data.OleDb
Imports ADODB
Imports System.Text
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Collections
Imports Claro.SisAct.Common.Funciones

Public Class LoginUsuario

    Dim objLog As New LogEventos
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("Log_ListarAccesosPagina")

    Public Function ListarAccesosPagina(ByVal strCodUsuario As String) As String
        Dim strClaves As String = ""
        Try
            objLog.Log_WriteLog(strArchivo, "*******OBTENER OPCIONES PAGINA*******")
            objLog.Log_WriteLog(strArchivo, "  Proyecto       : Portal EXPRESS")
            objLog.Log_WriteLog(strArchivo, "*************************************")

            Dim objOpciones As New Object
            Dim rsConsulta As New ADODB.Recordset
            Dim rsVerificaUsuario As New Recordset
            Dim codAplicacion As String
            Dim daRecord As New OleDbDataAdapter
            Dim ds As New DataSet
            codAplicacion = CType(ConfigurationSettings.AppSettings("CodigoAplicacion"), Integer)
            rsConsulta = CreateObject("ADODB.Recordset")
            objOpciones = CreateObject("Segu_DB.Acceso")
            Dim intUsuarioId As Integer = 0

            objLog.Log_WriteLog(strArchivo, "  INICIO METODO GetVerificaUsuario()")
            objLog.Log_WriteLog(strArchivo, "  Inicio de PARAMETROS ENTRADA")
            objLog.Log_WriteLog(strArchivo, "  CodUsuario     : " & strCodUsuario)
            objLog.Log_WriteLog(strArchivo, "  CodAplicacion  : " & codAplicacion)
            objLog.Log_WriteLog(strArchivo, "  Fin de PARAMETROS ENTRADA")
            rsVerificaUsuario = objOpciones.GetVerificaUsuario(strCodUsuario, codAplicacion)
            objLog.Log_WriteLog(strArchivo, "  FIN METODO GetVerificaUsuario()")
            daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
            daRecord.Fill(ds, rsVerificaUsuario, "Usuario")
            If Not rsVerificaUsuario Is Nothing AndAlso ds.Tables("Usuario").Rows.Count > 0 Then
                intUsuarioId = CheckInt(ds.Tables("Usuario").Rows(0).Item("USUAC_COD"))
                objLog.Log_WriteLog(strArchivo, "  Inicio de PARAMETROS SALIDA")
                objLog.Log_WriteLog(strArchivo, "  UsuarioId      : " & intUsuarioId)
                objLog.Log_WriteLog(strArchivo, "  Fin de PARAMETROS SALIDA")
            End If
            daRecord = Nothing
            ds = Nothing
            objLog.Log_WriteLog(strArchivo, "  INICIO METODO GetOpcionesPagina()")
            objLog.Log_WriteLog(strArchivo, "  Inicio de PARAMETROS ENTRADA")
            objLog.Log_WriteLog(strArchivo, "  UsuarioId      : " & intUsuarioId)
            objLog.Log_WriteLog(strArchivo, "  CodAplicacion  : " & codAplicacion)
            objLog.Log_WriteLog(strArchivo, "  Fin de PARAMETROS ENTRADA")
            rsConsulta = objOpciones.GetOpcionesPagina(intUsuarioId, codAplicacion)
            objLog.Log_WriteLog(strArchivo, "  FIN METODO GetOpcionesPagina()")
            objOpciones = Nothing
            If Not (rsConsulta.EOF And rsConsulta.BOF) Then
                strClaves = ""
                While Not rsConsulta.EOF
                    If strClaves = "" Then
                        strClaves = CheckStr((rsConsulta("clave").Value))
                    Else
                        strClaves += "," + CheckStr((rsConsulta("clave").Value))
                    End If
                    rsConsulta.MoveNext()
                End While
            End If
            rsConsulta.Close()
            rsConsulta = Nothing
            strClaves = UCase(strClaves)
            objLog.Log_WriteLog(strArchivo, "  Inicio de PARAMETROS SALIDA")
            objLog.Log_WriteLog(strArchivo, "  Claves         : " & strClaves)
            objLog.Log_WriteLog(strArchivo, "  Fin de PARAMETROS SALIDA")
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivo, "*********** CATCH ERROR *************")
            objLog.Log_WriteLog(strArchivo, "  Error          : " & ex.Message)
            objLog.Log_WriteLog(strArchivo, "  StackTrace     : " & ex.StackTrace)
        End Try
        objLog.Log_WriteLog(strArchivo, "*************************************")
        Return strClaves
    End Function

End Class
