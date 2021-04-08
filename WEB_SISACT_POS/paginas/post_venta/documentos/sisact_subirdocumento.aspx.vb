Option Strict Off
Imports System
Imports System.Math
Imports System.IO
Imports System.Configuration
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports System.Text.RegularExpressions


Public Class sisact_subirdocumento
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblOperacion As System.Web.UI.WebControls.Label
    Protected WithEvents btnCerrar As Anthem.Button
    Protected WithEvents btnAnexar As Anthem.Button
    Protected WithEvents filNombreArchivo As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents hidIdDocumentoSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents trDatosSubsanar As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hidIdRow As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaArchivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAnexar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVisible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaRecibo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroFilas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_OBSERVADO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_APROBADO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoSEC_NUEVO As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDG As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagEnvio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLoadFrame As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hiListaArchivosLoad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArchivosElim As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRecibosElim As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumSec As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidtamanioMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidtamanioMin As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCerrar As System.Web.UI.HtmlControls.HtmlInputHidden



    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

#Region "Propiedades"

    Public Property NroSolicitudSEC() As Integer
        Get
            Return Funciones.CheckInt(Me.ViewState("NroSolicitudSEC"))
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("NroSolicitudSEC") = Value
        End Set
    End Property

    Public Property IdDocumento() As Integer
        Get
            Return Funciones.CheckInt(Me.ViewState("IdDocumento"))
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("IdDocumento") = Value
        End Set
    End Property

    Public Property NombreGlosa() As String
        Get
            Return Funciones.CheckStr(Me.ViewState("NombreGlosa"))
        End Get
        Set(ByVal Value As String)
            Me.ViewState("NombreGlosa") = Value
        End Set
    End Property

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '---
        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        Try
            Anthem.Manager.Register(Me)

            '--recuperar Id de documento SEC, nro de solicitud, ID de documento y para estructurar nombre
            If Not Page.IsPostBack Then
                InicializaControles()
            End If

            'MARVIN ANDIA
            Dim accion As String = Request.QueryString("hidProceso")
            If hidProceso.Value = Nothing Then hidProceso.Value = ""
            If hidProceso.Value = "" Then
                accion = Request.QueryString("hidProceso")
            End If
            accion = hidProceso.Value
            Select Case accion
                Case "grabar"
                    grabar()
            End Select

            '---
        Catch ex As Exception
            Anthem.Manager.AddScriptForClientSideEval("alert('" + Mensajes.ERROR_CARGARPAGINA + "');")
        End Try

    End Sub

    Private Sub InicializaControles()

        '--recupera parametro de entrada
		If Me.Request.QueryString("NS") = "" Or Me.Request.QueryString("DC") = "" Then
			Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
			Response.Redirect(strRutaSite)
			Response.End()
			Exit Sub
		End If

		If Me.Request.QueryString("NS") <> "" Then
			Me.NroSolicitudSEC = Funciones.CheckInt(Request.QueryString("NS"))
			hidNumSec.Value = Request.QueryString("NS")
		End If

		If Me.Request.QueryString("DC") <> "" Then
			Me.IdDocumento = Funciones.CheckInt(Request.QueryString("DC"))
		End If

		If Me.Request.QueryString("NG") <> "" Then
			Me.NombreGlosa = Request.QueryString("NG")
		End If

		'T12646
		If Not Me.Request.QueryString("OP") Is Nothing Then
			If Me.Request.QueryString("OP") = "S" Then
				trDatosSubsanar.Style.Add("display", "")
				hidIdDocumentoSEC.Value = Request.QueryString("ID")
				hidIdRow.Value = Request.QueryString("IR")

			ElseIf Me.Request.QueryString("OP") = "A" Then
				'CAMBIO MARVIN ANDIA
				Anthem.Manager.RegisterStartupScript("script", "<script>mostrarFrameRecibo();</script>")
				'FIN CAMBIO
			End If
		End If

		btnAnexar.Attributes.Add("onmouseover", "this.className='BotonResaltado';")
		btnAnexar.Attributes.Add("onmouseout", "this.className='Boton';")

		btnCerrar.Attributes.Add("onmouseover", "this.className='BotonResaltado';")
		btnCerrar.Attributes.Add("onmouseout", "this.className='Boton';")

		btnCerrar.Attributes.Add("onclick", "javascript:CerrarVentanaDialog();")

    End Sub

    Public Function CalculodeMb(ByVal tamanio As Integer)
        Dim tamanioMb As Decimal
        tamanioMb = (tamanio) / 1048576
        Return tamanioMb
    End Function

    Public Function CalculodeKb(ByVal tamanioMinimo)
        Dim tamanioMinimokb As Integer
        tamanioMinimokb = (tamanioMinimo) / 1024
        Return tamanioMinimokb
    End Function

    Private Function adjuntar(ByVal ruta As String) As Boolean
        Dim flag As Integer = 0
        Dim tamanioMaximo, tamanioMinimo As Integer
        Dim RequestXForm As Object
        Dim objFile As Object
        Dim strFile As String = ""
        Dim strRutaAux As String = ""
        Dim strRuta As String = ""
        Dim result As String = ""
        Dim strNombreArchivo As String = ""
        Dim blnResp As Boolean = False

        tamanioMaximo = Convert.ToInt32(ConfigurationSettings.AppSettings("TamanioMaximoArchivoSP"))
        tamanioMinimo = Convert.ToInt32(ConfigurationSettings.AppSettings("TamanioMinimoArchivoSP"))

        hidtamanioMax.Value() = Round(CalculodeMb(tamanioMaximo), 1)
        hidtamanioMin.Value() = Round(CalculodeMb(tamanioMinimo), 1)

        If Fix(CalculodeMb(tamanioMinimo)) = 0 Then
            flag = 1
        End If

        If Fix(CalculodeMb(tamanioMaximo)) = 0 Then
            flag = 2
        End If

        If Fix(CalculodeMb(tamanioMaximo)) = 0 And Fix(CalculodeMb(tamanioMinimo)) = 0 Then
            flag = 3
        End If

        Try
            'Instanciando al objeto servidor
            RequestXForm = Server.CreateObject("ABCUpload4.XForm")
            RequestXForm.MaxUploadSize = tamanioMaximo
            RequestXForm.AbsolutePath = True
            RequestXForm.Overwrite = True
            objFile = RequestXForm("filNombreArchivo")(1)
            If objFile.RawLength > tamanioMaximo Then
                MostrarMensajeDialog("El documento debe tener como máximo " & (CType(tamanioMaximo, Double) / 1024) / 1024 & " Mb.")
                ''Response.Write("<script language=javascript>")
                ''Response.Write("alert('El documento debe tener como máximo " & (CType(tamanioMaximo, Double) / 1024) / 1024 & " Mb.');")
                ''Response.Write("</script>")
                hidMsg.Value = "FileSize"
                result = "mayor"
                Exit Function
            End If
            If objFile.RawLength < tamanioMinimo Then
                If flag = 1 Or flag = 3 Then
                    MostrarMensajeDialog("El documento debe ser mayor a " & CType(tamanioMinimo, Double) / 1024 & " Kb.")
                    ''Response.Write("<script language=javascript>")
                    ''Response.Write("alert('El documento debe ser mayor a " & CType(tamanioMinimo, Double) / 1024 & " Kb. ')")
                    ''Response.Write("</script>")
                    hidMsg.Value = "FileSize"
                    result = "menor"
                    Exit Function
                Else
                    MostrarMensajeDialog("El documento debe ser mayor a " & (CType(tamanioMinimo, Double) / 1024) / 1024 & " Mb.")
                    ''Response.Write("<script language=javascript>")
                    ''Response.Write("alert('El documento debe ser mayor a " & (CType(tamanioMinimo, Double) / 1024) / 1024 & " Mb. ')")
                    ''Response.Write("</script>")
                    hidMsg.Value = "FileSize"
                    result = "menor"
                    Exit Function
                End If
            End If

            If (objFile.rawfilename <> "") Then strFile = objFile.rawFileName
            Dim SaveLocation As String = AppDomain.CurrentDomain.BaseDirectory
            Dim arrArchivo As String() = strFile.Split("."c)

            objFile.Save(ruta)
            blnResp = True
            objFile = Nothing
            RequestXForm = Nothing

        Catch ex As Exception
            Dim alreadyError As String = ""
            hidMsg.Value = "FileSize"

            objFile = Nothing
            RequestXForm = Nothing
            Dim var, var2 As String
            var = "Upload size is greater than the maximum allowed"
            var2 = "A Windows error occurred that indicates that a file could not be found"
            If ex.Message.StartsWith(var) Then
                If flag = 2 Or flag = 3 Then
                    MostrarMensajeDialog("El documento debe tener como máximo " & CType(tamanioMaximo, Double) / 1024 & " Kb.')")
                    ''Response.Write("<script language=javascript>")
                    ''Response.Write("alert('El documento debe tener como máximo " & CType(tamanioMaximo, Double) / 1024 & " Kb.');")
                    ''Response.Write("</script>")
                Else
                    MostrarMensajeDialog("El documento debe tener como máximo " & CType(tamanioMaximo, Double) / 1024 / 1024 & " Mb.');")
                    ''Response.Write("<script language=javascript>")
                    ''Response.Write("alert('El documento debe tener como máximo " & CType(tamanioMaximo, Double) / 1024 / 1024 & " Mb.');")
                    ''Response.Write("</script>")
                End If
                alreadyError = "ERROR"
            End If
            If alreadyError = "" Then
                If ex.Message.ToUpper.StartsWith(var2.ToUpper) Then
                    MostrarMensajeDialog("No se pudo encontrar la carpeta destino de archivos")
                    ''Response.Write("<script language=javascript>")
                    ''Response.Write("alert('No se pudo encontrar la carpeta destino de archivos');")
                    ''Response.Write("</script>")
                    alreadyError = "ERROR"
                End If
            End If
            If alreadyError = "" Then
                MostrarMensajeDialog(ex.Message)
                ''Response.Write("<script language=javascript>")
                ''Response.Write("alert('" & ex.Message & "');")
                ''Response.Write("</script>")
            End If
            Exit Function
        End Try

        Return blnResp

    End Function

    Private Sub AnexarDocumento_old()
        '--
        If ((Not filNombreArchivo.PostedFile Is Nothing) AndAlso (filNombreArchivo.PostedFile.ContentLength > 0)) Then
            '--
            Dim sRutaDestino As String = ConfigurationSettings.AppSettings("ACU_CORP_RutaDestino").ToString
            Dim fileExtension As String = Path.GetExtension(filNombreArchivo.PostedFile.FileName)
            Dim sNombreCompletoDestino As String
            Dim intIDDocumentoSEC As Integer
            Dim objDocSECNegocio As New DocumentoSECNegocio
            Try
                '---determina nombre de archivo con el cual se grabara y descargara 
                Dim strFecha As String = String.Format("{0:yyyyMMdd}", Now)
                Dim sNuevoNombre As String = Funciones.CheckStr(Me.NroSolicitudSEC) & "_" & strFecha & fileExtension

                '*****primero grabar en la BD
                '--Determina nombre
                Dim objDocSECEntidad As New DocumentoSEC
                objDocSECEntidad.COD_SEC = Me.NroSolicitudSEC
                objDocSECEntidad.ID_DOCUMENTO = Me.IdDocumento
                objDocSECEntidad.NOMBRE_GLOSA = Me.NombreGlosa
                objDocSECEntidad.TIPO_CREACION = ConfigurationSettings.AppSettings("TCREACION_DIGITALIZADO").ToString()
                objDocSECEntidad.USUARIO_CREACION = CurrentUser.ToUpper()
                objDocSECEntidad.NOMBRE_ARCHIVO = sNuevoNombre

                objDocSECEntidad.NOMBRE_ARCHIVO = Funciones.CheckStr(Me.NroSolicitudSEC) & "_" & strFecha & hidIdDocumentoSEC.Value & fileExtension
                If Not Me.Request.QueryString("OP") Is Nothing Then
                    If Me.Request.QueryString("OP") = "S" Then
                        objDocSECEntidad.ID_DOCUMENTO_SEC = CInt(hidIdDocumentoSEC.Value)
                        intIDDocumentoSEC = objDocSECNegocio.SubsanaDocumento(objDocSECEntidad)
                    Else
                        intIDDocumentoSEC = objDocSECNegocio.Crear(objDocSECEntidad)
                    End If
                Else
                    intIDDocumentoSEC = objDocSECNegocio.Crear(objDocSECEntidad)
                End If


                If intIDDocumentoSEC > 0 Then
                    '---obtine nombre guardado
                    sNuevoNombre = objDocSECNegocio.ObtenerNombreArchivo(intIDDocumentoSEC)
                    '---sube documento a repositorio
                    sNombreCompletoDestino = sRutaDestino & sNuevoNombre
                    '---sube a carpeta de web server y trasfiere archivo a file server via FTP
                    If adjuntar(sNombreCompletoDestino) Then
                        MostrarMensajeDialog("El archivo del documento ha sido cargado.")
                    Else
                        '''MostrarMensajeDialog("Error. El archivo del documento no ha sido cargado.")
                    End If
                    '''filNombreArchivo.PostedFile.SaveAs(sNombreCompletoDestino)

                    '---
                    AuditoriaPagina.Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SISACT_ACUERDO_SD"), String.Format("Se anexó el documento/acuerdo con ID {0} para la SEC número {1}", intIDDocumentoSEC, Me.hidNumSec.Value), Me.CurrentUser, Me.CurrentTerminal)
                    '---

                    If Not Me.Request.QueryString("OP") Is Nothing Then
                        If Me.Request.QueryString("OP") = "S" Then
                            Anthem.Manager.AddScriptForClientSideEval("retornarDatos('" & hidIdRow.Value & "','" & sNuevoNombre & "');")
                        End If
                    Else
                        Anthem.Manager.AddScriptForClientSideEval("CerrarVentanaDialog();")
                    End If
                Else
                    MostrarMensajeDialog("Error grave al registrar el documento a anexar.")
                End If

            Catch ex As Exception

                '--elimina  archivo y registro de BD debido a que no se pudo anexar
                objDocSECNegocio.Eliminar(intIDDocumentoSEC)

                '--muestra mensaje
                MostrarMensajeDialog(ex.Message)
            End Try
        Else
            MostrarMensajeDialog("Seleccione el archivo a anexar.")
        End If
    End Sub

    Private Sub AnexarDocumento()
        '--
        Dim sCodigoError As Short
        Dim lTamanioMin As Integer
        Dim lTamanioMax As Integer
        Dim lTamanioFileMin As Integer
        Dim lTamanioFileMax As Integer
        Dim RequestXForm As Object
        Dim objFile As Object
        Dim sRutaOrigen As String = ConfigurationSettings.AppSettings("ACU_CORP_RutaOrigen").ToString
        Dim sRutaRepositorio As String = ConfigurationSettings.AppSettings("ACU_CORP_RutaDestino").ToString
        Dim sFileName As String
        Dim sNombreCompletoOrigen As String
        Dim sNombreCompletoDestino As String
        Dim lIDDocumentoSEC As Long
        Dim bResultado As Boolean = False
        '---
        Dim objDocSECNegocio As New DocumentoSECNegocio
        Try
            '---determina codigo de error, de existir, en base a tamaño de archivo. Es cero si no existe.
            If (filNombreArchivo.PostedFile Is Nothing) Then
                sCodigoError = -1
            Else
                '--calcula el tamaño de archivo
                lTamanioMin = Convert.ToInt32(ConfigurationSettings.AppSettings("TamanioMinimoArchivoSP")) '//10Kb
                lTamanioMin = CalculodeKb(lTamanioMin)
                lTamanioMax = Convert.ToInt32(ConfigurationSettings.AppSettings("TamanioMaximoArchivoSP")) '//5MB
                '---
                lTamanioFileMin = CalculodeKb(filNombreArchivo.PostedFile.ContentLength) ''objFile.RawLength) ''
                lTamanioFileMax = CalculodeMb(filNombreArchivo.PostedFile.ContentLength)

                If (lTamanioFileMin < lTamanioMin) Then
                    sCodigoError = -2
                ElseIf (lTamanioFileMax > CalculodeMb(lTamanioMax)) Then
                    sCodigoError = -3
                Else
                    sCodigoError = 0 '//exito
                End If
            End If
            '---trasnfiere archivo solo sino existe error en tamaño
            If (sCodigoError = 0) Then '//exito
                '----Instancia objeto servidor            
                RequestXForm = Server.CreateObject("ABCUpload4.XForm")
                RequestXForm.MaxUploadSize = lTamanioMax
                RequestXForm.AbsolutePath = True
                RequestXForm.Overwrite = True
                objFile = RequestXForm("filNombreArchivo")(1)
                If (objFile.rawfilename <> String.Empty) Then sFileName = objFile.rawFileName
                Dim fileExtension As String = Path.GetExtension(sFileName)

                '---determina pre-nombre de archivo con el cual se grabara y descargara (al crear se agrega el identificador unico de registro)
                Dim sFecha As String = String.Format("{0:yyyyMMdd}", Now)
                Dim sNuevoNombre As String = Funciones.CheckStr(Me.NroSolicitudSEC) & "_" & sFecha & fileExtension

                '----primero graba en la BD
                Dim objDocSECEntidad As New DocumentoSEC
                objDocSECEntidad.COD_SEC = Me.NroSolicitudSEC
                objDocSECEntidad.ID_DOCUMENTO = Me.IdDocumento
                objDocSECEntidad.NOMBRE_GLOSA = Me.NombreGlosa
                objDocSECEntidad.TIPO_CREACION = ConfigurationSettings.AppSettings("TCREACION_DIGITALIZADO").ToString()
                objDocSECEntidad.USUARIO_CREACION = CurrentUser.ToUpper()
                objDocSECEntidad.FECHA_CREACION = DateTime.Now
                objDocSECEntidad.NOMBRE_ARCHIVO = sNuevoNombre

                If Not Me.Request.QueryString("OP") Is Nothing Then
                    If Me.Request.QueryString("OP") = "S" Then
                        objDocSECEntidad.ID_DOCUMENTO_SEC = CInt(hidIdDocumentoSEC.Value)
                        '---E75810 20100818
                        objDocSECEntidad.NOMBRE_ARCHIVO = "S_" & Funciones.CheckStr(Me.NroSolicitudSEC) & "_" & sFecha & hidIdDocumentoSEC.Value & fileExtension
                        '---
                        lIDDocumentoSEC = objDocSECNegocio.SubsanaDocumento(objDocSECEntidad)
                    Else
                        lIDDocumentoSEC = objDocSECNegocio.Crear(objDocSECEntidad)
                    End If
                Else
                    lIDDocumentoSEC = objDocSECNegocio.Crear(objDocSECEntidad)
                End If
                '----
                If lIDDocumentoSEC > 0 Then
                    '---obtine nombre guardado
                    sNuevoNombre = objDocSECNegocio.ObtenerNombreArchivo(lIDDocumentoSEC)
                    '---sube documento a repositorio
                    sNombreCompletoOrigen = sRutaOrigen & "\" & sNuevoNombre '//para eliminar
                    sNombreCompletoDestino = sRutaRepositorio & sNuevoNombre
                    objFile.Save(sNombreCompletoDestino)
                    bResultado = True
                    '---
                    If (bResultado) Then
                        MostrarMensajeDialog("El archivo del documento ha sido cargado.")
                        '---
                        AuditoriaPagina.Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SISACT_ACUERDO_SD"), String.Format("Se anexó el documento/acuerdo con ID {0} para la SEC número {1}", lIDDocumentoSEC, Me.hidNumSec.Value), Me.CurrentUser, Me.CurrentTerminal)
                        '---
                        If Not Me.Request.QueryString("OP") Is Nothing Then
                            If Me.Request.QueryString("OP") = "S" Then
                                Anthem.Manager.AddScriptForClientSideEval("retornarDatos('" & hidIdRow.Value & "','" & sNuevoNombre & "');")
                            End If
                        Else
                            Anthem.Manager.AddScriptForClientSideEval("CerrarVentanaDialog();")
                        End If
                    Else
                        MostrarMensajeDialog("No ha sido posible anexar el documento.")
                    End If
                Else
                    MostrarMensajeDialog("Error grave al registrar el documento a anexar.")
                End If
            ElseIf sCodigoError = -1 Then
                MostrarMensajeDialog("Seleccione el archivo a anexar.")
            ElseIf sCodigoError = -2 Then
                MostrarMensajeDialog(String.Format("Seleccione un archivo con un tamaño mínimo de {0} KB.", lTamanioMin))
            ElseIf sCodigoError = -3 Then
                MostrarMensajeDialog(String.Format("Seleccione un archivo con un tamaño máximo de {0} MB.", CalculodeMb(lTamanioMax)))
            End If

        Catch exHttp As HttpException
            MostrarMensajeDialog(exHttp.Message)
        Catch ex As Exception
            '--elimina archivo y registro de BD debido a que no se pudo anexar
            objDocSECNegocio.Eliminar(lIDDocumentoSEC, False)
            '---???
            If File.Exists(sNombreCompletoOrigen) Then
                File.Delete(sNombreCompletoOrigen)
            End If
            '--muestra mensaje
            MostrarMensajeDialog(ex.Message)
            'MostrarMensajeDialog("Ha ocurrido un error grave al Anexar el archivo. \n Consulte con el Administrador del Sistema.")
        Finally
            objFile = Nothing
            RequestXForm = Nothing
        End Try
    End Sub

    Private Sub btnAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexar.Click
        AnexarDocumento()
    End Sub

    Public Sub MostrarMensajeDialog(ByVal strMensaje As String)
        Anthem.Manager.AddScriptForClientSideEval("alert('" & strMensaje & "');")
    End Sub

    'CAMBIO MARVIN ANDIA
    Function obtenerArrayRecibos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@Recibo@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aRecibo() As String = c.Split("|"c)
                Dim item As New ReciboDeposito
                'Condición para insertar o actualizar evaluar si tiene codigo SOL

                '----macc
                If CheckInt(aRecibo(6)) = 0 Then
                    item.RECIBO_ID = 0
                Else
                    item.RECIBO_ID = CheckInt(aRecibo(0))
                End If
                item.BANCO_ID = CheckInt(aRecibo(1))
                item.BANCO_DES = aRecibo(2)
                item.NRO_OPERACION = aRecibo(3)
                item.MONTO_DEPOSITO = CheckDbl(aRecibo(4))
                item.FECHA_DEPOSITO = CheckDate(aRecibo(5))
                item.LOGIN = CurrentUser
                item.TERMINAL = CurrentTerminal
                item.SOLIN_CODIGO = CheckInt64(Me.NroSolicitudSEC.ToString)
                salida.Add(item)
            End If
        Next
        Return salida
    End Function

    Sub grabar()
        Dim msg As String
        Dim usuario As String = CurrentUser
        Dim oConsulta As New SolicitudNegocios
        Dim listaArchivo As New ArrayList
        Dim listaRecibo As New ArrayList
        listaRecibo = obtenerArrayRecibos(hidListaRecibo.Value)

        Dim i As Integer
        Try
            If hidRecibosElim.Value.Trim.Length > 0 Then
                Dim CadElimRec As String = hidRecibosElim.Value
                Dim aListaRecElim() As String = CadElimRec.Split("|"c)
                For Each c As String In aListaRecElim
                    oConsulta.EliminarRecibo(Me.NroSolicitudSEC.ToString, c.Trim, msg)
                Next
            End If
            If listaRecibo.Count > 0 Then
                For i = 0 To listaRecibo.Count - 1
                    Dim item As ReciboDeposito = CType(listaRecibo(i), ReciboDeposito)
                    Dim codigo As Int64
                    oConsulta.GrabarRecibo(item, codigo, msg)
                Next
            End If
        Catch ex As Exception
            hidMsg.Value = msg
            hidProceso.Value = "LIMPIAR"
        End Try
        hidMsg.Value = "Se registraron los datos satisfactoriamente"
        hidProceso.Value = "LIMPIAR"
        hidVisible.Value = "1"

        '---macc
        hidCerrar.Value = "1"
    End Sub

    'FIN CAMBIO


End Class
