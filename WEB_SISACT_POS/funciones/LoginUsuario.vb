Option Strict Off
Imports System.Data.OleDb
Imports ADODB
Imports System.Text
Imports System.Data
Imports System.Web
Imports System.Collections
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios

Namespace Claro.SisAct.Web.Funciones
    Public Class LoginUsuario
        Public Shared Function CargarDatosLogin(ByVal strUsuario As String, ByVal oserver As System.Web.HttpServerUtility) As Usuario

            Dim oUsuario As New Usuario
            Dim rsVerificaUsuario As Recordset
            Dim rsDatosUsuario As Recordset
            Dim objAccesoAplicativo As Object
            Dim objEmpleado As Object

            Dim daRecord As New OleDbDataAdapter
            Dim daRecordNombre As New OleDbDataAdapter
            Dim ds As New DataSet
            Dim strPerfilLista As String
            Dim intUsuarioId As Int64 = 0
            Dim row As DataRow
            Dim objServAcceso As New GeneralNegocios

            Dim codAplicacion As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Try
                objAccesoAplicativo = oserver.CreateObject("Segu_DB.Acceso")
                rsVerificaUsuario = objAccesoAplicativo.GetVerificaUsuario(strUsuario, codAplicacion)
                daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
                daRecord.Fill(ds, rsVerificaUsuario, "Usuario")

                If Not rsVerificaUsuario Is Nothing AndAlso ds.Tables("Usuario").Rows.Count > 0 Then
                    intUsuarioId = CheckInt(ds.Tables("Usuario").Rows(0).Item("USUAC_COD"))
                    strPerfilLista = ds.Tables("Usuario").Rows(0).Item("PERFC_COD")

                    strPerfilLista = ""
                    For Each row In ds.Tables("Usuario").Rows
                        strPerfilLista &= row("PERFC_COD") & ","
                    Next
                    If strPerfilLista <> "" Then strPerfilLista = strPerfilLista.Substring(0, strPerfilLista.Length - 1)

                    'objEmpleado = oserver.CreateObject("IntraTIM_DB.Empleado")
                    'rsDatosUsuario = objEmpleado.getDatosUsuario(intUsuarioId)
                    'daRecordNombre.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    'daRecordNombre.Fill(ds, rsDatosUsuario, "Nombres")
                    Dim apellidos, nombres, email, area, codVendedor As String
                    'If Not rsDatosUsuario Is Nothing AndAlso ds.Tables("Nombres").Rows.Count > 0 Then
                    '    nombres = CheckStr(ds.Tables("Nombres").Rows(0)("nombre"))
                    '    apellidos = CheckStr(ds.Tables("Nombres").Rows(0)("apellido"))
                    '    codVendedor = CheckStr(ds.Tables("Nombres").Rows(0)("cod_vendedor"))
                    '    area = CheckStr(ds.Tables("Nombres").Rows(0)("area"))
                    '    area = area.Replace("--", "")
                    'End If

                    oUsuario = objServAcceso.DatosUsuario(intUsuarioId, strUsuario)

                    If Not oUsuario Is Nothing Then
                        
                        oUsuario.UsuarioId = intUsuarioId
                        oUsuario.Login = strUsuario
                        oUsuario.Perfil = strPerfilLista
                        oUsuario.AreaUsuario = oUsuario.AreaUsuario
                        oUsuario.Apellidos = oUsuario.Apellidos.ToUpper
                        oUsuario.Nombre = oUsuario.Nombre.ToUpper

                        oUsuario.CodigoVendedor = codVendedor
                        If strPerfilLista = ConfigurationSettings.AppSettings("PerfilConsulta") Then
                            oUsuario.FlagConsulta = True
                        Else
                            oUsuario.FlagConsulta = False
                        End If
                        sisact_session.IngresoPorLogin = "S"
                        oUsuario.OpcionesMenu = CargarOpciones(oUsuario.UsuarioId, oserver)
                        sisact_session.Usuario = oUsuario

                    End If

                 
                    'oUsuario.AreaUsuario = area
                    'oUsuario.Apellidos = apellidos
                    'oUsuario.Nombre = nombres
                    'oUsuario.Email = email
                    'oUsuario.CodigoVendedor = codVendedor



                Else
                    oUsuario = Nothing
                    sisact_session.Usuario = Nothing
                    sisact_session.IngresoPorLogin = Nothing
                End If
            Catch ex As Exception
                oUsuario = Nothing
                sisact_session.Usuario = Nothing
                sisact_session.IngresoPorLogin = Nothing
                Throw ex
            End Try
            Return oUsuario
        End Function

        Public Shared Function ObtenerDatosUsuario(ByVal strUsuario As String, ByVal server As System.Web.HttpServerUtility) As Usuario
            Dim oUsuario As Usuario = Claro.SisAct.Web.Funciones.sisact_session.Usuario
            If oUsuario.Login <> "" Then Return oUsuario
            oUsuario = CargarDatosLogin(strUsuario, server)
            Return oUsuario
        End Function
        Public Shared Function CargarOpciones(ByVal intUsuarioId As Integer, ByVal oserver As System.Web.HttpServerUtility) As String
            Dim strOpcionId As String
            Dim codAplicacion As Integer
            Dim contador1, contador2, contador3, contador4 As Integer
            Dim item, nombre_opcion, ruta As String
            Dim rsConsulta1, rsConsulta2, rsConsulta3, rsConsulta4 As ADODB.Recordset
            Dim objMenu As Object
            codAplicacion = CheckInt(ConfigurationSettings.AppSettings("CodigoAplicacion"))
            Dim rutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Dim patron_item As String = "[""" & nombre_opcion & """,""" & ruta & """,1,0,{0}]"
            Dim sb1 As New StringBuilder
            Dim sb2 As New StringBuilder
            Dim sb3 As New StringBuilder
            Dim sb4 As New StringBuilder

                rsConsulta1 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                objMenu = oserver.CreateObject("Segu_DB.Acceso")
                rsConsulta1 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 2, 0)
                Dim opcion As New OpcionMenu
                Dim tiene_hijos As String = "0"

                sb1.Append(" HM_Array1= [ " + ControlChars.NewLine)
                sb1.Append(" [iWidth,  iLeftPos, iTopPos, sFontColor, sFontHighColor, sBackgroundColor, sBackgroundHighColor, sTableBorderColor, sLineColor, 1,	0, 0, 1, 1, 1, 'null', 'null',]," + ControlChars.NewLine)
                contador1 = 1

                Do While Not rsConsulta1.EOF
                    strOpcionId = CheckStr(rsConsulta1.Fields("OPCIC_COD").Value)
                    rsConsulta2 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                    rsConsulta2 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 3, strOpcionId)
                    tiene_hijos = "0"
                    If Not rsConsulta2 Is Nothing Then
                        If rsConsulta2.RecordCount > 0 Then
                            tiene_hijos = "1"
                        End If
                    End If
                    nombre_opcion = CheckStr(rsConsulta1.Fields("OPCIC_DES").Value)
                    ruta = CheckStr(rsConsulta1.Fields("OPCIC_NOMPAG").Value)
                    If ruta <> "" Then ruta = rutaSite + ruta
                    rsConsulta1.MoveNext()
                    patron_item = "[""" & nombre_opcion & """,""" & ruta & """,1,0,{0}]"
                    item = String.Format(patron_item, tiene_hijos)
                    If rsConsulta1.EOF Then
                        item += ControlChars.NewLine + "]" + ControlChars.NewLine
                    Else
                        item += "," + ControlChars.NewLine
                    End If
                    sb1.Append(item)
                    If tiene_hijos = "1" Then
                        item = String.Format("HM_Array1_{0} = [[],", contador1)
                        sb2.Append(item + ControlChars.NewLine)
                    End If

                    contador2 = 1
                    Do While Not rsConsulta2.EOF
                        strOpcionId = CheckStr(rsConsulta2.Fields("OPCIC_COD").Value)
                        rsConsulta3 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                        rsConsulta3 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 4, strOpcionId)
                        tiene_hijos = "0"
                        If Not rsConsulta3 Is Nothing Then
                            If rsConsulta3.RecordCount > 0 Then
                                tiene_hijos = "1"
                            End If
                        End If
                        nombre_opcion = CheckStr(rsConsulta2.Fields("OPCIC_DES").Value)
                        ruta = CheckStr(rsConsulta2.Fields("OPCIC_NOMPAG").Value)
                        If ruta <> "" Then ruta = rutaSite + ruta
                        rsConsulta2.MoveNext()
                        patron_item = "[""" & nombre_opcion & """,""" & ruta & """,1,0,{0}]"
                        item = String.Format(patron_item, tiene_hijos)
                        If rsConsulta2.EOF Then
                            item += ControlChars.NewLine + "]" + ControlChars.NewLine
                        Else
                            item += "," + ControlChars.NewLine
                        End If
                        sb2.Append(item)
                        If tiene_hijos = "1" Then
                            item = String.Format("HM_Array1_{0}_{1} = [[],", contador1, contador2)
                            sb3.Append(item + ControlChars.NewLine)
                        End If
                        contador3 = 1
                        Do While Not rsConsulta3.EOF
                            strOpcionId = CheckStr(rsConsulta3.Fields("OPCIC_COD").Value)
                            rsConsulta4 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                            rsConsulta4 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 5, strOpcionId)
                            tiene_hijos = "0"

                            If Not rsConsulta4 Is Nothing Then
                                If rsConsulta4.RecordCount > 0 Then
                                    tiene_hijos = "1"
                                End If
                            End If

                            nombre_opcion = CheckStr(rsConsulta3.Fields("OPCIC_DES").Value)
                            ruta = CheckStr(rsConsulta3.Fields("OPCIC_NOMPAG").Value)
                            If ruta <> "" Then ruta = rutaSite + ruta
                            rsConsulta3.MoveNext()

                            patron_item = "[""" & nombre_opcion & """,""" & ruta & """,1,0,{0}]"
                            item = String.Format(patron_item, tiene_hijos)
                            If rsConsulta3.EOF Then
                                item += ControlChars.NewLine + "]" + ControlChars.NewLine
                            Else
                                item += "," + ControlChars.NewLine
                            End If
                            sb3.Append(item)
                            If tiene_hijos = "1" Then
                                item = String.Format("HM_Array1_{0}_{1}_{2} = [[],", contador1, contador2, contador3)
                                sb4.Append(item + ControlChars.NewLine)
                            End If

                            contador4 = 1
                            Do While Not rsConsulta4.EOF
                                nombre_opcion = CheckStr(rsConsulta4.Fields("OPCIC_DES").Value)
                                ruta = CheckStr(rsConsulta4.Fields("OPCIC_NOMPAG").Value)
                                If ruta <> "" Then ruta = rutaSite + ruta
                                rsConsulta4.MoveNext()

                                patron_item = "[""" & nombre_opcion & """,""" & ruta & """,1,0,{0}]"
                                item = String.Format(patron_item, tiene_hijos)
                                If rsConsulta4.EOF Then
                                    item += ControlChars.NewLine + "]" + ControlChars.NewLine
                                Else
                                    item += "," + ControlChars.NewLine
                                End If
                                sb4.Append(item)
                                contador4 += 1
                            Loop
                            contador3 += 1
                        Loop
                        contador2 += 1
                    Loop
                    contador1 += 1
                Loop
                Dim salida As String
                salida = sb1.ToString()
                salida += sb2.ToString()
                salida += sb3.ToString()
                salida += sb4.ToString()

                Return salida
       
        End Function
        Public Shared Function CargarOpciones2(ByVal intUsuarioId As Integer, ByVal oserver As System.Web.HttpServerUtility) As ArrayList
            Dim arrOpciones As New ArrayList
            Dim strOpcionId As String
            Dim codAplicacion As Integer
            Dim rsConsulta1, rsConsulta2, rsConsulta3, rsConsulta4 As ADODB.Recordset
            Dim objMenu As Object
            codAplicacion = CheckInt(ConfigurationSettings.AppSettings("CodigoAplicacion"))
            Dim inicio_arreglo As New StringBuilder
       
                rsConsulta1 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                objMenu = oserver.CreateObject("Segu_DB.Acceso")
                rsConsulta1 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 2, 0)
                Dim opcion As New OpcionMenu
                Dim tiene_hijos As String = "0"

                inicio_arreglo.Append(" HM_Array1= [ " + ControlChars.NewLine)
                inicio_arreglo.Append(" [iWidth,  iLeftPos, iTopPos, sFontColor, sFontHighColor, sBackgroundColor, sBackgroundHighColor, sTableBorderColor, sLineColor, 1,	0, 0, 1, 1, 1, 'null', 'null',]," + ControlChars.NewLine)
                Do While Not rsConsulta1.EOF
                    strOpcionId = CheckStr(rsConsulta1.Fields("OPCIC_COD").Value)
                    rsConsulta2 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                    rsConsulta2 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 3, strOpcionId)
                    objMenu = Nothing
                    tiene_hijos = "0"
                    If Not rsConsulta2 Is Nothing Then
                        If rsConsulta2.RecordCount > 0 Then
                            tiene_hijos = "1"
                        End If
                    End If

                    opcion = ObtenerDatosOpcionMenu(rsConsulta1, 1, tiene_hijos, inicio_arreglo.ToString())

                    If tiene_hijos = "1" Then opcion.TieneHijos = True
                    arrOpciones.Add(opcion)
                    Do While Not rsConsulta2.EOF
                        strOpcionId = CheckStr(rsConsulta2.Fields("OPCIC_COD").Value)
                        rsConsulta3 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                        rsConsulta3 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 4, strOpcionId)
                        tiene_hijos = "0"
                        If Not rsConsulta3 Is Nothing Then
                            If rsConsulta3.RecordCount > 0 Then
                                tiene_hijos = "1"
                            End If
                        End If
                        opcion = ObtenerDatosOpcionMenu(rsConsulta2, 2, tiene_hijos, inicio_arreglo.ToString())
                        If tiene_hijos = "1" Then opcion.TieneHijos = True
                        arrOpciones.Add(opcion)

                        Do While Not rsConsulta3.EOF
                            strOpcionId = CheckStr(rsConsulta3.Fields("OPCIC_COD").Value)
                            rsConsulta4 = CType(oserver.CreateObject("ADODB.Recordset"), ADODB.Recordset)
                            rsConsulta4 = objMenu.GetOpcionesMenu(intUsuarioId, codAplicacion, 5, strOpcionId)
                            tiene_hijos = "0"

                            If Not rsConsulta4 Is Nothing Then
                                If rsConsulta4.RecordCount > 0 Then
                                    tiene_hijos = "1"
                                End If
                            End If
                            opcion = New OpcionMenu
                            opcion = ObtenerDatosOpcionMenu(rsConsulta3, 3, tiene_hijos, inicio_arreglo.ToString())
                            If tiene_hijos = "1" Then opcion.TieneHijos = True
                            arrOpciones.Add(opcion)

                            Do While Not rsConsulta4.EOF
                                tiene_hijos = "0"
                                opcion = ObtenerDatosOpcionMenu(rsConsulta4, 4, tiene_hijos, inicio_arreglo.ToString())
                                arrOpciones.Add(opcion)
                                rsConsulta4.MoveNext()
                            Loop
                            rsConsulta3.MoveNext()
                        Loop
                        arrOpciones.Add(opcion)
                        rsConsulta2.MoveNext()
                    Loop
                    rsConsulta1.MoveNext()
                Loop
                Return arrOpciones
     
        End Function
        Public Shared Function FormarOpcionesMenu(ByVal lista As ArrayList) As String
            Dim i As Integer
            Dim sb As New StringBuilder
            Dim opcion As String
            Dim nivel As Integer = 0
            Dim arreglo_nivel_1, arreglo_nivel_2, arreglo_nivel_3, arreglo_nivel_4 As Boolean
            For i = 0 To lista.Count - 1
                Dim oMenu As OpcionMenu = CType(lista(i), OpcionMenu)
                nivel = oMenu.OpcionNivel
                opcion = oMenu.OpcionMenuScript
                If nivel = 1 Then
                    If arreglo_nivel_1 = False Then
                        sb.Append(" HM_Array1= [ " + ControlChars.NewLine)
                        sb.Append(" [iWidth,  iLeftPos, iTopPos, sFontColor, sFontHighColor, sBackgroundColor, sBackgroundHighColor, sTableBorderColor, sLineColor, 1,	0, 0, 1, 1, 1, 'null', 'null',]," + ControlChars.NewLine)
                    Else
                        sb.Append(opcion + ControlChars.NewLine)
                    End If
                End If
            Next
            Return sb.ToString
        End Function
        Private Shared Function ObtenerDatosOpcionMenu(ByVal rs As ADODB.Recordset, ByVal nivel As Integer, ByVal tiene_hijos As String, ByVal inicio_arreglo As String) As OpcionMenu
            Dim item As New OpcionMenu
            item.AplicacionId = CheckInt(rs.Fields("APLIC_COD").Value)
            item.OpcionPadreId = CheckInt(rs.Fields("OPCIC_CODPAD").Value)
            item.OpcionId = CheckInt(rs.Fields("OPCIC_COD").Value)
            item.OpcionNivelPadre = CheckInt(rs.Fields("OPCIC_NIV_PAD").Value)
            item.OpcionNivel = CheckInt(rs.Fields("OPCIC_NIV").Value)
            item.OpcionDes = CheckStr(rs.Fields("OPCIC_DES").Value)
            item.OpcionAbrev = CheckStr(rs.Fields("OPCIC_ABREV").Value)
            item.OpcionNombrePagina = CheckStr(rs.Fields("OPCIC_NOMPAG").Value)
            item.OpcionOrden = CheckInt(rs.Fields("OPCIC_NUMORD").Value)
            item.OpcionD1 = CheckInt(rs.Fields("OPCIC_D1").Value)
            item.OpcionNivel = nivel
            Dim strOpcion As String = ""
            Dim ruta As String = item.OpcionNombrePagina
            Dim nombre_opcion As String = item.OpcionDes
            If nombre_opcion <> "" Then nombre_opcion = "&nbsp;" + nombre_opcion
            strOpcion = "[" & """ & nombre_opcion & """ & "," & """ & ruta & """ & "1,0,{0}],"
            strOpcion = String.Format(strOpcion, tiene_hijos)
            If inicio_arreglo <> "" Then strOpcion = inicio_arreglo + ControlChars.NewLine + strOpcion
            item.OpcionMenuScript = strOpcion
            Return item
        End Function

        Public Shared Function ListarAccesosPagina(ByVal strCodUsuario As String) As String
            Dim strClaves As String = ""
            Try
                Dim objOpciones As Object
                Dim rsConsulta As ADODB.Recordset
                Dim rsVerificaUsuario As Recordset
                Dim codAplicacion As String
                Dim daRecord As New OleDbDataAdapter
                Dim ds As New DataSet
                codAplicacion = CType(ConfigurationSettings.AppSettings("CodigoAplicacion"), Integer)
                rsConsulta = CreateObject("ADODB.Recordset")
                objOpciones = CreateObject("Segu_DB.Acceso")
                Dim intUsuarioId As Integer = 0
                rsVerificaUsuario = objOpciones.GetVerificaUsuario(strCodUsuario, codAplicacion)
                daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
                daRecord.Fill(ds, rsVerificaUsuario, "Usuario")
                If Not rsVerificaUsuario Is Nothing AndAlso ds.Tables("Usuario").Rows.Count > 0 Then
                    intUsuarioId = CheckInt(ds.Tables("Usuario").Rows(0).Item("USUAC_COD"))
                End If
                daRecord = Nothing
                ds = Nothing
                rsConsulta = objOpciones.GetOpcionesPagina(intUsuarioId, codAplicacion)
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
            Catch ex As Exception
            End Try
            Return strClaves
        End Function

        Public Shared Function ListarAccesosPaginaNP(ByVal strCodUsuario As String) As String
            Dim strClaves As String = ""
            Dim prueba As String = ""
            Try
                Dim objOpciones As New Object
                Dim rsConsulta As New ADODB.Recordset
                Dim rsVerificaUsuario As New Recordset

                Dim codAplicacion As String = ""
                Dim daRecord As New OleDbDataAdapter
                Dim ds As New DataSet
                codAplicacion = CType(ConfigurationSettings.AppSettings("CodigoAplicacion"), Integer)
                rsConsulta = CreateObject("ADODB.Recordset")
                objOpciones = CreateObject("Segu_DB.Acceso")
                Dim intUsuarioId As Integer = 0
                rsVerificaUsuario = objOpciones.GetVerificaUsuario(strCodUsuario, codAplicacion)
                daRecord.MissingSchemaAction = MissingSchemaAction.AddWithKey
                daRecord.Fill(ds, rsVerificaUsuario, "Usuario")
                If Not rsVerificaUsuario Is Nothing AndAlso ds.Tables("Usuario").Rows.Count > 0 Then
                    intUsuarioId = CheckInt(ds.Tables("Usuario").Rows(0).Item("USUAC_COD")) 
                End If
                daRecord = Nothing
                ds = Nothing
                rsConsulta = objOpciones.GetOpcionesPagina(CType(strCodUsuario, Integer), codAplicacion)
                objOpciones = Nothing
                If Not (rsConsulta.EOF And rsConsulta.BOF) Then
                    strClaves = ""
                    If rsConsulta.RecordCount > 0 Then
                        While Not rsConsulta.EOF
                            If strClaves = "" Then
                                strClaves = CType(rsConsulta("clave").Value, String)
                            Else
                                strClaves += "," + CType(rsConsulta("clave").Value, String)
                            End If
                            rsConsulta.MoveNext()
                        End While
                    End If
                End If
                rsConsulta.Close()
                rsConsulta = Nothing
                strClaves = UCase(strClaves)
            Catch ex As Exception
                strClaves = ex.Message & " | " & ex.StackTrace
                strClaves += " --------------------------------------- " & prueba
            End Try
            Return strClaves

        End Function
    End Class
End Namespace