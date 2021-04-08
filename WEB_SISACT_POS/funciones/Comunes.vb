Option Strict Off
Imports System.IO
Imports System.Xml
Imports System.Collections
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Common.Funciones
Imports System.Text.RegularExpressions

Namespace Claro.SisAct.Web.Funciones
    Module Comunes

        Public Const K_TipoProductoConsumer As String = "01"
        Public Const K_TipoProductoBussinees As String = "02"

        Public Enum enumCategoriaEmpresa
            Top = 1
            BlackList = 2
            WhiteList = 3
            Locutorio = 4
            Municipalidad = 5
            Licitación = 6
            ComercializadoraTrafico = 7
        End Enum

        Public Sub LlenaCombo(ByVal source As ArrayList, _
                              ByVal ddlCombo As System.Web.UI.WebControls.ListControl, _
                              ByVal campoValue As String, _
                              ByVal campoText As String, _
                              Optional ByVal blnInsertarTodos As Boolean = False, _
                              Optional ByVal blnInsertarSeleccionar As Boolean = False, _
                              Optional ByVal seleccionar As String = "")

            If source Is Nothing Then Return
            If ddlCombo Is Nothing Then Return
            Dim item As New ItemGenerico

            If blnInsertarSeleccionar = True Then
                If seleccionar = "" Then seleccionar = ConfigurationSettings.AppSettings("Seleccionar")
                item = New ItemGenerico("-1", seleccionar)
                item.Descripcion2 = seleccionar
                source.Insert(0, item)
            End If
            If blnInsertarTodos = True Then
                item = New ItemGenerico("-1", ConfigurationSettings.AppSettings("Todos"))
                item.Descripcion2 = ConfigurationSettings.AppSettings("Todos")
                source.Insert(0, item)
            End If
            With ddlCombo
                .DataSource = source
                .DataValueField = campoValue
                .DataTextField = campoText
                .DataBind()
            End With
        End Sub
        Public Function MontoIGVAdd(ByVal monto As Object) As Double
            Dim m As Double = CheckDbl(monto)
            If m = 0 Then Return 0

            Dim tasaIGV As Double = 0
            If ConfigurationSettings.AppSettings("TasaIGV") = "" Then
                tasaIGV = 19
            Else
                tasaIGV = CheckDbl(ConfigurationSettings.AppSettings("TasaIGV"))
            End If
            m *= (1 + tasaIGV / 100)
            m = CheckDbl(m, 2)
            Return m
        End Function
        Public Function MontoIGVRemove(ByVal monto As Object) As Double
            Dim m As Double = CheckDbl(monto)
            If m = 0 Then Return 0
            Dim tasaIGV As Double = 0
            If ConfigurationSettings.AppSettings("TasaIGV") = "" Then
                tasaIGV = 19
            Else
                tasaIGV = CheckDbl(ConfigurationSettings.AppSettings("TasaIGV"))
            End If
            m /= (1 + tasaIGV / 100)
            m = CheckDbl(m, 2)
            Return m
        End Function
        Public Function ObtenerRutaApp() As String
            Dim strBaseDirectory As String = AppDomain.CurrentDomain.BaseDirectory.ToString()
            Return strBaseDirectory
        End Function
        Public Function ConvertToFecha(ByVal vFecha As String) As String
            If vFecha Is Nothing Then Return ""
            If vFecha.Trim = "" Then Return ""
            Dim salida, fecha, hora As String
            Try
                fecha = String.Format("{0}/{1}/{2}", vFecha.Substring(6, 2), vFecha.Substring(4, 2), vFecha.Substring(0, 4))
                hora = vFecha.Substring(8)
                If hora.Length > 0 Then
                    Dim horaTmp As String = hora
                    If hora.Length > 4 Then
                        hora = String.Format("{0}:{1}:{2}", horaTmp.Substring(0, 2), horaTmp.Substring(2, 2), horaTmp.Substring(4, 2))
                    Else
                        hora = String.Format("{0}:{1}", horaTmp.Substring(0, 2), horaTmp.Substring(2, 2))
                    End If
                End If
                salida = fecha + " " + hora
                salida = salida.Trim
                If IsDate(salida) Then
                    If hora.Length > 0 Then
                        salida = CType(salida, DateTime).ToString()
                    Else
                        salida = CType(salida, DateTime).ToShortDateString()
                    End If
                End If
                Return salida
            Catch ex As Exception
            End Try
            Return vFecha
        End Function
        Public Function EvaluaUsuarioSupervisor(ByVal strPerfiles As String) As Boolean
            Dim arrPerfiles() As String
            If strPerfiles <> "" Then
                arrPerfiles = strPerfiles.Split(","c)
                If Array.IndexOf(arrPerfiles, ConfigurationSettings.AppSettings("PerfilSupervisor")) <> -1 Then
                    Return True
                End If
            End If
            Return False
        End Function
        Public Function EvaluaUsuarioEjecutivo(ByVal strPerfiles As String) As Boolean
            Dim arrPerfiles() As String
            If strPerfiles <> "" Then
                arrPerfiles = strPerfiles.Split(","c)
                If Array.IndexOf(arrPerfiles, ConfigurationSettings.AppSettings("PerfilEjecutivo")) <> -1 Then
                    Return True
                End If
            End If
            Return False
        End Function
        Public Function EvaluaUsuarioSoloConsulta(ByVal strPerfiles As String) As Boolean
            If strPerfiles <> "" Then
                If strPerfiles = ConfigurationSettings.AppSettings("PerfilConsulta") Then
                    Return True
                End If
            End If
            Return False
        End Function
        Public Sub LlamarPaginaError(ByVal ocontext As System.Web.HttpContext, ByVal ex As Exception, ByVal titulo As String, ByVal detalle As String, ByVal origen As String)

            Dim oinfo As New ErrorInfo
            oinfo.error_titulo = titulo
            oinfo.error_detalle = detalle
            oinfo.error_tecnico = ex.Message
            oinfo.error_source = ex.Source
            oinfo.error_trace = ex.StackTrace
            oinfo.pagina_origen = origen
            sisact_session.ErrorPagina = oinfo
            ocontext.Response.Redirect("sisact_error.aspx")
        End Sub
        Public Function NroTelefonoSalida(ByVal telefono As String) As String
            If telefono = "" Then Return ""
            Dim salida As String = telefono
            Dim indice As Integer = 0
            If telefono.Length >= 10 Then
                ' 0619843986
                indice = telefono.Length - 9
                salida = salida.Substring(indice)
            End If
            Return salida
        End Function
        ' E75606 - Venta Express INICIO
        Public Function AdicionarDias(ByVal p_fecha As String, ByVal ndias As Int32) As String
            Dim lfecha As Date
            Dim lfecharesult As String

            If IsDate(p_fecha) Then
                lfecha = DateValue(p_fecha)
                lfecharesult = DateAdd("D", ndias, lfecha).ToString()
            Else
                lfecharesult = "01/01/1900"
            End If
            Return lfecharesult
        End Function
        ' E75606 - Venta Express FIN

        Public Function ObtenerValorFromListaValores(ByVal valor As String, ByVal nombreLista As String) As String
            Dim lista As ArrayList = ObtenerListaValores(nombreLista)
            If lista.Count > 0 Then
                For i As Integer = 0 To lista.Count - 1
                    If CType(lista(i), ItemGenerico).Codigo = valor Then
                        Return CType(lista(i), ItemGenerico).Descripcion
                    End If
                Next
            End If
            Return ""
        End Function

        Public Function ObtenerListaValores(ByVal vNombreFuncion As String) As ArrayList
            Dim salida As New ArrayList
            If vNombreFuncion = "" Then Return salida
            ' buscamos del xml si esta el nombre de funcion sino nos vamos a la base de datos
            If vNombreFuncion = "ListaMotivoRegistroDOL" Then
                salida = ObtenerListaValoresXML(vNombreFuncion)
            End If

            If salida.Count > 0 Then Return salida
            ' aqui rutina para base de datos
            Select Case vNombreFuncion.ToUpper()
                Case "ListaLugarNacimiento".ToUpper()
                    Dim oConsulta As New GeneralNegocios
                    salida = oConsulta.ListarNacionalidad()
                    Dim lista_local As New ArrayList
                    lista_local = ObtenerListaValoresXML("ListaDepartamento", "")
                    If lista_local.Count > 0 Then
                        For i As Integer = lista_local.Count - 1 To 0 Step -1
                            salida.Insert(0, lista_local(i))
                        Next
                    End If
                    Return salida
            End Select
        End Function

        Public Function ObtenerDatosCliente(ByVal strTelefono As String, ByVal strContactoId As String) As Claro.SisAct.Entidades.Cliente
            Dim oCliente As Cliente
            oCliente = sisact_session.DatosCliente
            Dim blnLlenarCliente As Boolean = False
            If oCliente Is Nothing Then
                blnLlenarCliente = True
            Else
                If oCliente.TELEFONO Is Nothing Then
                    blnLlenarCliente = True
                ElseIf oCliente.TELEFONO = "" Then
                    blnLlenarCliente = True
                End If
            End If
            If blnLlenarCliente = True Then
                Dim strCuenta, strFlgRegistrado, strFlagConsulta, strMsgResultado As String
                Dim int64ContactoObjId As Int64
                int64ContactoObjId = CheckInt64(strContactoId)  'SIAC_session.ContactoBJID
                strFlgRegistrado = "1"
                If strTelefono <> "" And int64ContactoObjId > 0 Then
                    Dim oConsulta As New ClienteNegocio
                    'Cambios TFI     -----> NO DOL EN SISACT PARA TFI       
                    'If Claro.SisAct.Web.Funciones.sisact_session.DatosLinea.EsTFI = "SI" Then
                    '    oCliente = oConsulta.ObtenerCliente("000" + strTelefono, strCuenta, int64ContactoObjId.ToString, strFlgRegistrado, strFlagConsulta, strMsgResultado)
                    'Else
                    oCliente = oConsulta.ObtenerCliente(strTelefono, strCuenta, int64ContactoObjId.ToString, strFlgRegistrado, strFlagConsulta, strMsgResultado)
                    'End If
                    sisact_session.DatosCliente = oCliente
                End If
            End If
            Return oCliente
        End Function

        Public Function ObtenerListaValoresXML(ByVal vstrNombreFuncion As String, ByVal vstrFlagObtenerCodigoAdic As String) As ArrayList
            Dim strArchivo, strRuta As String
            strArchivo = "SISACTDatos.xml"
            strRuta = ObtenerRutaApp()
            strRuta += strArchivo
            If File.Exists(strRuta) = False Then
                Return New ArrayList
            End If
            Dim salida As New ArrayList
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(strRuta)
            Dim nodeList As XmlNodeList = doc.SelectNodes("descendant::" & vstrNombreFuncion & "/item")
            Dim I As Integer
            For I = 0 To nodeList.Count - 1
                Dim itemGenerico As itemGenerico
                If vstrFlagObtenerCodigoAdic = "1" Then
                    itemGenerico = New Claro.SisAct.Entidades.ItemGenerico(nodeList.Item(I).ChildNodes(0).InnerText, nodeList.Item(I).ChildNodes(1).InnerText, nodeList.Item(I).ChildNodes(2).InnerText)
                Else
                    itemGenerico = New Claro.SisAct.Entidades.ItemGenerico(nodeList.Item(I).ChildNodes(0).InnerText, nodeList.Item(I).ChildNodes(1).InnerText)
                End If
                salida.Add(itemGenerico)
            Next
            Return salida
        End Function
        Public Function ObtenerListaValoresXML(ByVal vstrNombreFuncion As String) As ArrayList
            Dim strArchivo, strRuta As String
            strArchivo = "SISACTDatos.xml"
            strRuta = ObtenerRutaApp()
            strRuta += strArchivo
            If File.Exists(strRuta) = False Then
                Return New ArrayList
            End If
            Dim salida As New ArrayList
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(strRuta)
            Dim nodeList As XmlNodeList = doc.SelectNodes("descendant::" & vstrNombreFuncion & "/item")
            Dim I As Integer
            For I = 0 To nodeList.Count - 1
                Dim itemGenerico As New Claro.SisAct.Entidades.ItemGenerico(nodeList.Item(I).ChildNodes(0).InnerText, nodeList.Item(I).ChildNodes(1).InnerText)
                salida.Add(itemGenerico)
            Next
            If sisact_session.DatosLinea.EsTFI = "SI" And vstrNombreFuncion = "ListaBolsa" Then
                Dim item As itemGenerico
                For I = 0 To salida.Count - 1
                    item = salida.Item(I)
                    If item.Codigo = "MMSPromoAccountID" Then
                        Exit For
                    End If
                Next
                salida.Remove(item)
            End If
            Return salida
        End Function

        Public Function ObtenerListaValoresXML(ByVal vstrNombreFuncion As String, ByVal vstrCodigoBusqueda As String, ByVal vstrFlagObtenerCodigoAdic As String) As ArrayList
            Dim strArchivo, strRuta As String
            strArchivo = ConfigurationSettings.AppSettings("CONS_XML_SISACT")
            strRuta = ObtenerRutaApp()
            strRuta += strArchivo
            If File.Exists(strRuta) = False Then
                Return New ArrayList
            End If
            Dim salida As New ArrayList
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(strRuta)
            Dim nodeList As XmlNodeList = doc.SelectNodes("descendant::" & vstrNombreFuncion & "/item")
            Dim I As Integer
            Dim itemGenerico As ItemGenerico
            For I = 0 To nodeList.Count - 1
                If (nodeList.Item(I).ChildNodes(0).InnerText = vstrCodigoBusqueda) Then
                    If vstrFlagObtenerCodigoAdic = "1" Then
                        itemGenerico = New Claro.SISACT.Entidades.ItemGenerico(nodeList.Item(I).ChildNodes(0).InnerText, nodeList.Item(I).ChildNodes(1).InnerText, nodeList.Item(I).ChildNodes(2).InnerText, "1")
                    Else
                        itemGenerico = New Claro.SISACT.Entidades.ItemGenerico(nodeList.Item(I).ChildNodes(0).InnerText, nodeList.Item(I).ChildNodes(1).InnerText)
                    End If
                    Exit For
                End If
            Next
            If Not (itemGenerico Is Nothing) Then
                salida.Add(itemGenerico)
            End If
            Return salida
        End Function

        Public Sub LlenarComboOrdenado(ByVal Ddl As DropDownList, ByVal DtSinOrdenar As DataTable, ByVal ValorId As String, ByVal ValorMostrar As String, Optional ByVal AgregarSeleccione As Boolean = True)
            Dim DtOrdenado As DataTable = DtSinOrdenar.Clone
            Dim Ordenacion As String = ValorMostrar + " Asc"
            Dim Rows() As DataRow = DtSinOrdenar.Select("", Ordenacion)
            For Each Dr As DataRow In Rows
                Dim Row As DataRow = DtOrdenado.NewRow
                Row(ValorId) = Dr(ValorId)
                Row(ValorMostrar) = Dr(ValorMostrar)
                DtOrdenado.Rows.Add(Row)
            Next
            Ddl.DataSource = DtOrdenado
            Ddl.DataValueField = ValorId
            Ddl.DataTextField = ValorMostrar
            Ddl.DataBind()
            If AgregarSeleccione = True Then
                Ddl.Items.Insert(0, "--Seleccione--")
            End If
        End Sub

        Public Sub LlenarCombo(ByVal Ddl As DropDownList, ByVal Dt As DataTable, ByVal ValorId As String, ByVal ValorMostrar As String, Optional ByVal AgregarSeleccione As Boolean = True)
            Ddl.DataSource = Dt
            Ddl.DataValueField = ValorId
            Ddl.DataTextField = ValorMostrar
            Ddl.DataBind()
            If AgregarSeleccione = True Then
            Ddl.Items.Insert(0, "--Seleccione--")
            End If
        End Sub

        Public Sub LLenarDataGrid(ByVal Dgd As DataGrid, ByVal Dt As DataTable)
            If Not Dt Is Nothing Then
                Dgd.DataSource = Dt
                Dgd.DataBind()
            End If
        End Sub

        Public Sub Eliminar(ByRef Objeto As Object, ByVal Id As String, ByVal Dg As DataGrid, ByVal CampoHidden As HtmlControls.HtmlInputHidden)
            Dim Dt As DataTable = CType(Objeto, DataTable)
            If Id = "" Then
                If Not Dt Is Nothing Then
                    Dt.Rows.Clear()
                    Objeto = Dt
                    Call LLenarDataGrid(Dg, Dt)
                    CampoHidden.Value = String.Empty
                    Dt.Dispose()
                    Dt = Nothing
                End If
            Else
                Dim Codigo As String = CampoHidden.Value.ToString().Trim().ToUpper()
                If Not Dt Is Nothing Then
                    If Dt.Rows.Count > 0 Then
                        For Each Dr As DataRow In Dt.Rows
                            If Codigo = Dr(Id).ToString().Trim().ToUpper() Then
                                Dt.Rows.Remove(Dr)
                                Exit For
                            End If
                        Next
                        Objeto = Dt
                        Call LLenarDataGrid(Dg, Dt)
                        CampoHidden.Value = String.Empty
                        Dt.Dispose()
                        Dt = Nothing
                    End If
                End If
            End If
        End Sub

        Public Function QuitarSaltosLinea(ByVal Texto As String, ByVal CaracterReemplazar As String) As String
            QuitarSaltosLinea = Replace(Replace(Texto, Chr(10), CaracterReemplazar), Chr(13), CaracterReemplazar)
        End Function

		
		 Public Function getValorParametroGeneral(ByVal codigo As String, ByVal sListaParametros As String) As String
            Dim valor As String = ""
            Dim arrParametros() As String = sListaParametros.Split("|"c)
            For Each sParametro As String In arrParametros
                Dim arrParametro() As String = sParametro.Split(";"c)
                If arrParametro(0) = codigo Then
                    valor = arrParametro(1)
                    Exit For
                End If
            Next
            Return valor
        End Function

    End Module
End Namespace