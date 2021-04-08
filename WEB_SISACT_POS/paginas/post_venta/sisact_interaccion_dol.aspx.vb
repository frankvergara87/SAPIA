Option Strict Off
Imports System.Collections
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports System.IO

Public Class sisact_interaccion_dol
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtReferenciaCliente As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroTelefono As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContacto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtClase As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSubclase As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNotas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtApellidos As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents lblEspere As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaNac As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDireccion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCiudad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargarDatosLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidContactoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlantillaId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagValidarDOL As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFocus As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEjecutarTransaccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIMSI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIN As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents flDNI As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents hidEligeMedodoDOL As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodRegistro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNoEspecificado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlLugarNac As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMotivoRegistro As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgListado As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidClaseDes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaseId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSubClaseId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSubClaseDes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsuarioExt As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim objLog As New SISACT_Log
    Dim strArchLog As String = "Log_SISACT_LOG"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If Session("CodUsuarioSisact") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            hidUsuarioExt.Value = Request.QueryString("cu")
        End If

        If Not Page.IsPostBack Then
            CargarInicio()
        Else
            Dim strAccion As String = hidAccion.Value
            hidAccion.Value = ""
            Select Case strAccion
                Case "C"
                    hidAccion.Value = strAccion
                    cargaDatosCliente()

                    If hidIMSI.Value <> "" And hidIN.Value <> "" Then
                        EjecutarCDOL_WS_NEW(txtNroTelefono.Text)
                    End If

                Case "A"
                    AdjuntarArchivo()
            End Select
        End If

        txtNombre.Attributes.Add("oncontextmenu", "return false;")
        txtApellidos.Attributes.Add("oncontextmenu", "return false;")
        txtNumDocumento.Attributes.Add("oncontextmenu", "return false;")
        txtFechaNac.Attributes.Add("oncontextmenu", "return false;")
        txtNroReferencia.Attributes.Add("oncontextmenu", "return false;")

    End Sub

    Private Sub CargarInicio()
        hidCargarDatosLinea.Value = ""
        hidNoEspecificado.Value = ConfigurationSettings.AppSettings("NoEspecificado")
        lblMensaje.Text = ""
        lblMensaje.Visible = False
        sisact_session.DatosCliente = Nothing

        Dim lista As New ArrayList
        hidTelefono.Value = ObtenerNumero(False, Request.QueryString("numTelefono"))
        hidContactoId.Value = Request.QueryString("contactoId")
        txtNroTelefono.Text = Request.QueryString("numTelefono")
        hidIMSI.Value = Request.QueryString("IMSI")
        hidIN.Value = Request.QueryString("IN")

        Session("Almacen") = Obtener_Oficina()

        listaGrilla()
        
        Dim oCliente As Cliente = ObtenerDatosCliente(hidTelefono.Value, hidContactoId.Value)
        txtContacto.Text = oCliente.NOMBRE_COMPLETO
        
        If hidPlantillaId.Value = "" Then hidPlantillaId.Value = "DOL"
        If hidPlantillaId.Value = "DOL" Then
            hidFlagValidarDOL.Value = "1"
        Else
            hidFlagValidarDOL.Value = ""
        End If
        Dim blnNoProcesar As Boolean = False
        Dim intMensaje As Integer
        If hidFlagValidarDOL.Value <> "1" Then ' NO ES DOL
            Return
        End If
        
        txtNombre.Text = oCliente.NOMBRES
        txtApellidos.Text = oCliente.APELLIDOS
        txtNumDocumento.Text = oCliente.NRO_DOC
        txtNroReferencia.Text = oCliente.TELEF_REFERENCIA

        If hidContactoId.Value = "" Then
            txtDireccion.Text = hidNoEspecificado.Value
            txtCiudad.Text = hidNoEspecificado.Value
            'txtNombre.Text = "X"
            'txtApellidos.Text = "X"
            'txtNumDocumento.Text = "X"
        Else
            txtDireccion.Text = oCliente.DOMICILIO
            txtCiudad.Text = oCliente.CIUDAD
        End If

        If oCliente.FECHA_NAC <> "" Then
            Dim fecha_nac As Date = CheckDate(oCliente.FECHA_NAC)
            If fecha_nac <> New DateTime(1753, 1, 1) Then
                txtFechaNac.Text = Format(fecha_nac, "dd/MM/yyyy")
            End If
        End If

        txtTipo.Text = "Prepago"
        txtClase.Text = "Variación - Registro en línea"
        txtSubclase.Text = "DOL"

        Dim oConsulta As New GeneralNegocios
        Dim arrLista As ArrayList = oConsulta.ListarTipoDocumentoCliente()

        LlenaCombo(arrLista, ddlTipoDocumento, "Codigo", "Descripcion", False, False)
        Dim tipoDocu As String = oCliente.TIPO_DOC
        Try
            If tipoDocu Is Nothing Then
                ddlTipoDocumento.SelectedValue = "DNI"
            Else
                ddlTipoDocumento.SelectedValue = tipoDocu
            End If

        Catch ex As Exception
        End Try
        arrLista = ObtenerListaValores("ListaLugarNacimiento")
        LlenaCombo(arrLista, ddlLugarNac, "Codigo", "Descripcion", False, True)

        arrLista = ObtenerListaValores("ListaMotivoRegistroDOL")
        LlenaCombo(arrLista, ddlMotivoRegistro, "Codigo", "Descripcion", False, False)
        Try
            If arrLista.Count = 2 Then
                ddlMotivoRegistro.SelectedIndex = 1
            End If
        Catch ex As Exception
        End Try

        Dim lugar_nac As String = CheckStr(oCliente.LUGAR_NACIMIENTO_DES)
        If lugar_nac = "" Then lugar_nac = ConfigurationSettings.AppSettings("PaisNacimientoDefecto")
        If lugar_nac <> "" Then
            Try
                ddlLugarNac.SelectedValue = lugar_nac
            Catch ex As Exception
            End Try
        End If
    End Sub

    'DolMMS
    Private Sub listaGrilla()
        Dim objCliente As New ClienteNegocio
        Dim arrLista As ArrayList
        Dim strMensaje As String
        arrLista = objCliente.obtieneDatosDolMMS(hidTelefono.Value, strMensaje)
        If (strMensaje <> "" Or Not strMensaje Is Nothing) Then
            hidMsg.Value = strMensaje
            lblMensaje.Text = hidMsg.Value
        End If

        For i As Integer = 0 To arrLista.Count - 1
            CType(arrLista(i), DolMMS).TipoDocumento = descripcion(1, CType(arrLista(i), DolMMS).TipoDocumento, "gConstKeyTipoDocumentoDolMMS")
            CType(arrLista(i), DolMMS).CodSistema = descripcion(1, CType(arrLista(i), DolMMS).CodSistema, "gConstKeyTipoSistemaDolMMS")
        Next

        If arrLista.Count = 0 Or arrLista Is Nothing Then
            hidMsg.Value = ConfigurationSettings.AppSettings("gConstKeyMsgDolMMS")
            lblMensaje.Text = hidMsg.Value
        End If
        dgListado.DataSource = arrLista
        dgListado.DataBind()
    End Sub

    Private Function descripcion(ByVal flag As Integer, ByVal strKey As String, ByVal strKeyWC As String) As String
        Dim strConstTD As String = ConfigurationSettings.AppSettings(strKeyWC)
        Dim arrTD() As String = strConstTD.Split("|")
        For Each strTD As String In arrTD
            If flag = 1 Then
                If strTD.Split(";")(0) = strKey Then
                    Return strTD.Split(";")(1)
                End If
            Else
                If strTD.Split(";")(1).ToUpper = strKey.ToUpper Then
                    Return strTD.Split(";")(0)
                End If
            End If
        Next
        Return ""
    End Function

    Private Sub EjecutarCDOL_WS_NEW(ByVal strTelefono As String)
        Dim strIMSI As String = hidIMSI.Value
        Dim strIN As String = hidIN.Value
        Dim blnVerifica As Boolean = False
        Dim arrResultado As ArrayList
        Dim strMSGError As String = ""
        Dim objResultado As New ItemGenerico
        Dim strCampo As String = ""
        Dim strDescripcion As String = ""
        Dim strCadenaResultadoFinal As String = ""
        Dim strMensaje As String = ""
        Dim strCodError As String = ""
        Dim strInfComando As String = ""
        Dim strComando As String = "RC"
        Dim i As Integer
        Dim strCodEstado As String = "3"

            If (strIMSI <> "" And strIN <> "") Then
                blnVerifica = True
            End If
            If blnVerifica Then
                If EjecutaDOLV10(strTelefono, strMensaje) Then
                    strMensaje = "Registro de DOL de Línea Prepago interfase SISACT."
                    obtieneIdCliente(strTelefono)

                Else
                    strMensaje = "Error en Registro DOL: " & strMensaje
                    strCodEstado = "1"
                End If
            Else
                strMensaje = "Error EjecutarCDOL_WS_NEW(): Error registral DOL, revisar el RC/IMSI"
                strCodEstado = "1"
            End If

            RegisterStartupScript("script", "<script>alert('" & strMensaje & "');</script>")
            cambiaEstadoRegistro(strTelefono, strCodEstado)
            InsertarAuditoria(ConfigurationSettings.AppSettings("CONS_COD_AUDIT_ACTDOL"), strTelefono, Me.CurrentUser & "|" & Session("Almacen") & "|" & DateTime.Now & "|" & strTelefono & "|" & strMensaje)

    End Sub

    Private Function EjecutaDOLV10(ByVal strTelefono As String, ByRef strMsg As String) As Boolean
        Dim booRetorno As Boolean = False
        Try
            Dim eCliente As New Cliente
            Dim nLinea As New LineaNegocios
            Dim strLogin As String
            Dim strUSUARIO_SISTEMA As String = ConfigurationSettings.AppSettings("USRProceso")
            Dim strMensaje As String
            Dim strNotas As String = txtNotas.Text.Trim

            strLogin = Me.CurrentUser()
            eCliente = CType(Session("ClienteDOL"), Cliente)
            Session("ClienteDOL") = Nothing
            Session.Remove("ClienteDOL")

            booRetorno = nLinea.EjecutaDOL(eCliente, strTelefono, strLogin, strUSUARIO_SISTEMA, strNotas, strMensaje)
            strMsg = strMensaje
        Catch ex As Exception
            strMsg = ex.Message.ToString
        Finally
            objLog.Log_WriteLog(strArchLog, "Respuesta Registro DOL|Telf:" & strTelefono & "|MSG:" & strMsg)
        End Try
        Return booRetorno
    End Function

    Sub obtieneIdCliente(ByVal strTelefono As String)
        Dim objCliente As New ClienteNegocio
        Dim eCliente As Cliente
        eCliente = objCliente.ObtenerCliente(strTelefono, "", "", "1", "", "")
        hidContactoId.Value = eCliente.OBJID_CONTACTO
    End Sub

    Sub cambiaEstadoRegistro(ByVal strTelefono As String, ByVal strCodEstado As String)
        Try
            Dim objCliente As New ClienteNegocio
            objCliente.cambiaEstadoDolMMS(CheckInt(hidCodRegistro.Value), strTelefono, strCodEstado)
        Catch ex As Exception
        End Try
    End Sub

    Private Function DatosPlantillaInteracion() As PlantillaInteraccion
        hidFocus.Value = ""
        Dim pDatos As New PlantillaInteraccion
        pDatos.NOMBRE_TRANSACCION = hidEjecutarTransaccion.Value
        pDatos.X_FIRST_NAME = txtNombre.Text
        pDatos.X_LAST_NAME = txtApellidos.Text
        pDatos.X_TYPE_DOCUMENT = ddlTipoDocumento.SelectedValue
        pDatos.X_DOCUMENT_NUMBER = txtNumDocumento.Text
        pDatos.X_REFERENCE_PHONE = txtNroReferencia.Text
        pDatos.X_FLAG_REGISTERED = "1"
        pDatos.X_REGISTRATION_REASON = ddlMotivoRegistro.SelectedValue
        pDatos.X_ADDRESS = txtDireccion.Text
        pDatos.X_CITY = txtCiudad.Text

        If txtFechaNac.Text <> "" Then pDatos.X_BIRTHDAY = CheckDate(txtFechaNac.Text)
        If ddlLugarNac.SelectedValue <> "-1" Then pDatos.X_INTER_1 = ddlLugarNac.SelectedItem.Text
        Return pDatos
    End Function

    Private Function DatosCliente(ByVal oPlantillaInteraccion As PlantillaInteraccion, ByVal vEstadoForm As String) As Cliente
        Dim fecha As DateTime = New DateTime(1, 1, 1)
        Dim oCliente As New Cliente
        oCliente.OBJID_CONTACTO = hidContactoId.Value
        oCliente.FLAG_REGISTRADO = 1
        oCliente.MODALIDAD = ConfigurationSettings.AppSettings("strModalidadPrepagoClarify")
        oCliente.MOTIVO_REGISTRO = CheckStr(oPlantillaInteraccion.X_REGISTRATION_REASON)
        oCliente.TELEFONO = hidTelefono.Value
        oCliente.USUARIO = Me.CurrentUser
        oCliente.NOMBRES = CheckStr(oPlantillaInteraccion.X_FIRST_NAME)
        oCliente.APELLIDOS = CheckStr(oPlantillaInteraccion.X_LAST_NAME)

        If CheckStr(oPlantillaInteraccion.X_BIRTHDAY) <> "" Then
            If oPlantillaInteraccion.X_BIRTHDAY <> fecha Then
                oCliente.FECHA_NAC = oPlantillaInteraccion.X_BIRTHDAY.ToShortDateString()
            End If
        End If
        If CheckStr(oPlantillaInteraccion.X_CONTACT_SEX) <> "" Then
            Dim strSexo As String = ObtenerValorFromListaValores(CheckStr(oPlantillaInteraccion.X_CONTACT_SEX), "ListaSexo")
            If strSexo <> "" Then
                oCliente.SEXO = strSexo
            Else
                oCliente.SEXO = ConfigurationSettings.AppSettings("NoPrecisado")
            End If
        End If
        If CheckStr(oPlantillaInteraccion.X_TYPE_DOCUMENT) <> "" Then
            oCliente.TIPO_DOC = CheckStr(oPlantillaInteraccion.X_TYPE_DOCUMENT)
        End If
        If CheckStr(oPlantillaInteraccion.X_DOCUMENT_NUMBER) <> "" Then
            oCliente.NRO_DOC = CheckStr(oPlantillaInteraccion.X_DOCUMENT_NUMBER)
        End If
        If CheckStr(oPlantillaInteraccion.X_MARITAL_STATUS) <> "" Then
            oCliente.ESTADO_CIVIL = CheckStr(oPlantillaInteraccion.X_MARITAL_STATUS)
        End If
        If CheckStr(oPlantillaInteraccion.X_OCCUPATION) <> "" Then
            oCliente.OCUPACION = CheckStr(oPlantillaInteraccion.X_OCCUPATION)
        End If
        If CheckStr(oPlantillaInteraccion.X_POSITION) <> "" Then
            oCliente.CARGO = CheckStr(oPlantillaInteraccion.X_POSITION)
        End If
        If CheckStr(oPlantillaInteraccion.X_REFERENCE_PHONE) <> "" Then
            oCliente.TELEF_REFERENCIA = CheckStr(oPlantillaInteraccion.X_REFERENCE_PHONE)
        End If
        If CheckStr(oPlantillaInteraccion.X_FAX) <> "" Then
            oCliente.FAX = CheckStr(oPlantillaInteraccion.X_FAX)
        End If
        If CheckStr(oPlantillaInteraccion.X_EMAIL) <> "" Then
            oCliente.EMAIL = CheckStr(oPlantillaInteraccion.X_EMAIL)
        End If

        oCliente.DOMICILIO = CheckStr(oPlantillaInteraccion.X_ADDRESS)
        oCliente.CIUDAD = CheckStr(oPlantillaInteraccion.X_CITY)

        If CheckStr(oPlantillaInteraccion.X_DISTRICT) <> "" Then
            oCliente.DISTRITO = CheckStr(oPlantillaInteraccion.X_DISTRICT)
        End If
        If CheckStr(oPlantillaInteraccion.X_ZIPCODE) <> "" Then
            oCliente.ZIPCODE = CheckStr(oPlantillaInteraccion.X_ZIPCODE)
        End If
        If CheckStr(oPlantillaInteraccion.X_ADDRESS5) <> "" Then
            oCliente.URBANIZACION = CheckStr(oPlantillaInteraccion.X_ADDRESS5)
        End If
        If CheckStr(oPlantillaInteraccion.X_DEPARTMENT) <> "" Then
            oCliente.DEPARTAMENTO = CheckStr(oPlantillaInteraccion.X_DEPARTMENT)
        End If
        If CheckStr(oPlantillaInteraccion.X_REFERENCE_ADDRESS) <> "" Then
            oCliente.REFERENCIA = CheckStr(oPlantillaInteraccion.X_REFERENCE_ADDRESS)
        End If
        If CheckStr(oPlantillaInteraccion.X_EMAIL_CONFIRMATION) <> "-1" Then
            oCliente.FLAG_EMAIL = CheckStr(oPlantillaInteraccion.X_EMAIL_CONFIRMATION)
        End If

        If CheckStr(oPlantillaInteraccion.X_INTER_1) <> "-1" Then
            oCliente.LUGAR_NACIMIENTO_DES = CheckStr(oPlantillaInteraccion.X_INTER_1)
        End If

        objLog.Log_WriteLog(strArchLog, "ContactoID:" & oCliente.OBJID_CONTACTO & "|Telf:" & oCliente.TELEFONO & "|NomCliente:" & oCliente.NOMBRES & "|ApeCliente:" & oCliente.APELLIDOS & "|FecNac:" & oCliente.FECHA_NAC & "|TipoDoc:" & oCliente.TIPO_DOC & "|NroDoc:" & oCliente.NRO_DOC & "|MotivoReg:" & oCliente.MOTIVO_REGISTRO & "|User:" & oCliente.USUARIO)
        Return oCliente
    End Function

    Sub cargaDatosCliente()
        Try
            Dim oPlantillaDatos As PlantillaInteraccion
            Dim oCliente As Cliente
            oPlantillaDatos = DatosPlantillaInteracion()
            oCliente = DatosCliente(oPlantillaDatos, "N")
            Session.Add("ClienteDOL", oCliente)
            hidEjecutarTransaccion.Value = "TRANSACCION_DESACTIVACION_LOCUCION_DOL_HLR"
            seteaMensaje("")
        Catch ex As Exception
            seteaMensaje(ex.Message.ToString)
        End Try
    End Sub

    Private Sub seteaMensaje(ByVal strMsg)
        hidMsg.Value = strMsg
        lblMensaje.Text = hidMsg.Value
    End Sub

    Private Sub AdjuntarArchivo()
        ' Se almacena en el Servidor Temporalmente
        Dim sPath As String = ConfigurationSettings.AppSettings("strRutaOrigenDOL")
        Dim strNombreArchivo As String = ""
        Dim Destino As String

        strNombreArchivo = CStr(Date.Now.ToString("yyyyMMddHHmmss")) & "_"
        strNombreArchivo += hidTelefono.Value & Path.GetExtension(flDNI.PostedFile.FileName)
        Destino = sPath & "\" & strNombreArchivo

        Try
            Dim tamanioArchivo As Integer = flDNI.PostedFile.ContentLength
            Dim tamanioMaximo As Integer = CType(ConfigurationSettings.AppSettings("gConstKeyKbImgDolMMS"), Integer)

            If tamanioMaximo >= tamanioArchivo Then
                If Not System.IO.Directory.Exists(sPath) Then
                    System.IO.Directory.CreateDirectory(sPath)
                End If

                flDNI.PostedFile.SaveAs(Destino)

                Dim strDirectorio As String = CStr(Date.Now.ToString("yyyyMMdd"))
                Dim rutaArchivo As String = ConfigurationSettings.AppSettings("strRutaDestinoDOL") & "/" & strDirectorio

                Dim strMensaje As String
                strMensaje = creaDirectorioFTP(ConfigurationSettings.AppSettings("strRutaDestinoDOL"), strDirectorio)

                strMensaje = UploadArchivoFTP(ConfigurationSettings.AppSettings("strRutaOrigenDOL"), strNombreArchivo, rutaArchivo)

     
                Dim objCliente As New ClienteNegocio

                rutaArchivo += "/" & strNombreArchivo
                Dim strFN As String = txtFechaNac.Text
                Dim dtFN As Date
                If (strFN <> "") Then
                    Try
                        dtFN = CDate(strFN)
                        strFN = Mid(strFN, 1, 2) & Mid(strFN, 4, 2) & Mid(strFN, 7, 4)
                    Catch ex As Exception
                        strFN = ""
                    End Try
                End If
                objCliente.registrarDOL(hidTelefono.Value, descripcion(2, _
                                ddlTipoDocumento.SelectedValue.Trim, "gConstKeyTipoDocumentoDolMMS"), txtNumDocumento.Text.Trim, Me.CurrentUser, Session("Almacen"), rutaArchivo, ConfigurationSettings.AppSettings("gConstCodSistemaDolMMS"), 0, 0, strFN, strMensaje)

                If strMensaje <> "" Then
                    seteaMensaje(strMensaje)
                Else

                    objLog.Log_WriteLog(strArchLog, "Teléfono: " & hidTelefono.Value & "|TipoDoc:" & descripcion(2, ddlTipoDocumento.SelectedValue.Trim, "gConstKeyTipoDocumentoDolMMS") & "|NumDoc:" & txtNumDocumento.Text & "|User:" & Me.CurrentUser & "|Almacen:" & Session("Almacen") & "|RutaArchivo:" & rutaArchivo & "|FecNac:" & strFN)
                    seteaMensaje("Se adjuntó el archivo")
                    strMensaje = "Se adjuntó el archivo " & strNombreArchivo & " a la ruta " & rutaArchivo & " con éxito."
                    listaGrilla()
                End If

            Try
                InsertarAuditoria(ConfigurationSettings.AppSettings("CONS_COD_AUDIT_REGDOL"), hidTelefono.Value, Me.CurrentUser & "|" & Session("Almacen") & "|" & DateTime.Now & "|" & hidTelefono.Value & "|" & strMensaje)
            Catch ex As Exception
            End Try
            Else
            seteaMensaje(ConfigurationSettings.AppSettings("gConstKeyMsgTamArcDolMMS"))
            End If
        Catch ex As Exception
            seteaMensaje(ex.Message.ToString)
        End Try
    End Sub

    Public Function Obtener_Oficina() As String
        Dim oMaestro As New MaestroNegocio
        Dim oUsuario As Usuario
        Dim codUsuario As Integer
        Dim listaPuntoVenta As ArrayList
        Dim puntoVenta As String

        oUsuario = oMaestro.ObtenerUsuarioLogin(Me.CurrentUser)
        codUsuario = CheckInt(oUsuario.UsuarioId)

        ' Buscar Punto de Venta del Usuario logeado
        listaPuntoVenta = oMaestro.ListaOficinaVentaXUsuario(codUsuario, "0000", "1")
        oMaestro = Nothing

        If listaPuntoVenta.Count = 0 Then
            Throw New Exception("Error: Usuario no pertenece a algun Punto de Venta.")
        End If

        puntoVenta = CType(listaPuntoVenta(0), ItemGenerico).Codigo '(verifica el Punto de Venta)
        Obtener_Oficina = puntoVenta

    End Function

    Private Function creaDirectorioFTP(ByVal rutaDestino As String, ByVal directorio As String) As String
        Dim strMensaje As String = ""
        Try
            Dim objFileFTP As New ControlProxyFTP
            Dim pRutaDirectorio As String = rutaDestino & "/" & directorio
            objFileFTP.MakeDirFTP(pRutaDirectorio)
        Catch ex As Exception
            strMensaje = ex.Message()
        End Try
        Return strMensaje
    End Function
    Private Function UploadArchivoFTP(ByVal rutaOrigen As String, ByVal nombreArchivo As String, ByVal rutaDestino As String) As String
        Dim strMensaje As String = ""
        Try
            Dim pRutaArchivoOrigen As String
            Dim pRutaArchivoDestino As String
            Dim objFileFTP As New ControlProxyFTP
            pRutaArchivoOrigen = rutaOrigen & "\" & nombreArchivo
            pRutaArchivoDestino = rutaDestino & "/" & nombreArchivo
            objFileFTP.PutFileFTP(pRutaArchivoOrigen, pRutaArchivoDestino)

        Catch ex As Exception
            strMensaje = "Error: Al adjuntar el archivo en el FTP"
        End Try
        Return strMensaje
    End Function

    Private Sub InsertarAuditoria(ByVal strCodigoEvento As String, ByVal strTelefono As String, ByVal strTexto As String)
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
        Dim ipcliente As String = CurrentTerminal
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim usuario_id As String = CurrentUser

        Dim objAudi As New AuditoriaNegocio
        objAudi.registrarAuditoria(strCodigoEvento, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, strTelefono, "0", strTexto)
    End Sub

    Private Sub dgListado_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgListado.PageIndexChanged
        dgListado.CurrentPageIndex = e.NewPageIndex
        listaGrilla()
    End Sub
End Class
