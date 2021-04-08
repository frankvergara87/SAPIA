Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports Claro.SisAct.Common


Imports Claro.SisAct.Negocios

Public Class sisact_ifr_ValidarCliente
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblValidacionClaro As System.Web.UI.WebControls.Label
    Protected WithEvents rblListaNumeros As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSolicitarClave As System.Web.UI.WebControls.Button
    Protected WithEvents lblClaveSMS As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaveSMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button
    Protected WithEvents chbPermiso As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hidNroSec As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents hidIntentos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocu As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocu As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCerrar As System.Web.UI.WebControls.Button
    Protected WithEvents hiRespuesta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuesta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTiempo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hitTiempoOut As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hitIntTiempo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIDAudi As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNuevo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtSMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents hitTiempo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValidarCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblMensaje As System.Web.UI.WebControls.Label
    Protected WithEvents hidIntentoSMS As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Public strClaveEncriptada As String = ""
    Public strClaveDesencriptada As String = ""
    Public encrypted As Byte()
    'Private strTipDoc As String
    'Private strDocumento As String = ""
    Private strSec As String = ""
    Dim objLog As New SISACT_Log
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("Log_Validar_Cliente")
    Dim intIntentos As Integer = 1
    Dim intIntentoSMS As Integer = 0
    Private dttHoraInic As Date
    Public p_Auditoria As New Claro.SisAct.Entidades.AuditoriaLogs


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        If Not (IsPostBack) Then

            hidNroSec.Value = Request.QueryString("nroSec")
            hidIntentos.Value = "1"
            hidTipoDocu.Value = Request.QueryString("TipoDocument")
            hidNroDocu.Value = Request.QueryString("Documento")
            hidIDAudi.Value = Request.QueryString("intIDLog")
            hidValidarCliente.Value = Request.QueryString("ValidarCliente")
            hidIntentoSMS.Value = "0"
            Me.RegisterStartupScript("script1", "<script>f_inicio();</script>")
            'If ValidarCliente() Then
            ListarLineasActivas()
            Obtener_Logs()
            If hidValidarCliente.Value = "2" Then
                chbPermiso.Visible = False
            End If
            ' Buscar LOG, de acuerdo a la validacion.

            'Else
            '    Me.RegisterStartupScript("script1", "<script>f_Salir(0);</script>")
            '    Exit Sub
            'End If
        End If
    End Sub

#Region "Controles"

    Protected Sub btnSolicitarClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolicitarClave.Click
        btnSolicitarClave.Enabled = True

        Dim strClaveAleatoria As String = String.Empty
        Dim strClaveEnvioSMS As String = String.Empty
        Dim strRespuesta As String = String.Empty
        Dim strMensaje As String = String.Empty
        Dim strTiempoWS As String = String.Empty
        Dim booRespuesta As Boolean = False
        Dim strIntentoSMS As String = "0"
        Dim _strNombreServicio As String = System.Net.Dns.GetHostName()
        Dim strNroTelefonico As String = Funciones.CheckStr(rblListaNumeros.SelectedValue)

        Try
            Dim objEncrypt As New Claro.SisAct.Common.Cryptografia
            Dim objBOValidar As New Claro.SisAct.Negocios.BOValidarClienteClaro
            strIntentoSMS = objBOValidar.Capturar_ValorParametros(Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_PARA_INTENTOS")))
            intIntentoSMS = Convert.ToInt32(hidIntentoSMS.Value)
            If intIntentoSMS = Convert.ToInt32(strIntentoSMS) Then
                Me.RegisterStartupScript("script1", "<script>alert('Se excedio el número de intentos de envios SMS.');f_Salir(1);</script>")
                Exit Sub
            Else
                intIntentoSMS = intIntentoSMS + 1
                hidIntentoSMS.Value = Convert.ToString(intIntentoSMS)
            End If
VolverCodigo:
            strClaveAleatoria = GenerarClaveAleatoria()
            If strClaveAleatoria.Length <> 4 Then
                GoTo VolverCodigo
            End If
            hidIntentos.Value = "0"
            p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
            p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)

            p_Auditoria.AUDII_NROENVIOSMS = p_Auditoria.AUDII_NROENVIOSMS + 1
            p_Auditoria.AUDII_DISPONIBLESMS = 1
            p_Auditoria.AUDII_NROINTENTO = Convert.ToInt32(hidIntentos.Value)
            p_Auditoria.AUDIV_COMENTARIO = ""
            Session("p_Auditoria") = p_Auditoria
            GuardarLOG()

            'strClaveEnvioSMS = Funciones.CheckStr(ConfigurationSettings.AppSettings("contMensajeSMS")) & " " & objEncrypt.CifrarCadena(strClaveAleatoria)
            strClaveEnvioSMS = objEncrypt.CifrarCadena(strClaveAleatoria)

            strTiempoWS = objBOValidar.Capturar_ValorParametros(Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_PARA_TIME_EnvioSMS")))
            'Tiempo ingresado en Milisengundos.
            hitTiempoOut.Value = objBOValidar.Capturar_ValorParametros(Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_PARA_TIME_RPTA")))
            txtSMS.Text = strClaveAleatoria
            booRespuesta = objBOValidar.GuardarCodigoSMS(Funciones.CheckStr(rblListaNumeros.SelectedValue), strClaveEnvioSMS, Now)

            If (EnviarSMS(strClaveAleatoria, strTiempoWS, strRespuesta, strMensaje)) Then
                Me.RegisterStartupScript("script1", "<script>IniciarTiempo();</script>")
                txtClaveSMS.ReadOnly = False
                btnAceptar.Enabled = True
                btnSolicitarClave.Enabled = False
                btnAceptar.CssClass = "Boton"
                btnSolicitarClave.CssClass = "Boton"
            End If
            hidNuevo.Value = "0"
        Catch ex As Exception
            Enviar_Email(hidNroDocu.Value, hidNroSec.Value, CurrentUser, strRespuesta, strMensaje)
            LOG_SMS(_strNombreServicio, strNroTelefonico)
            Me.RegisterStartupScript("script1", "<script>alert('El servicio de Validación Cliente Claro por SMS no se encuentra disponible');f_Confirmacion();</script>")

        End Try
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim strClaveDesencriptada As String = String.Empty
        Dim strClaveBDEncriptada As String = String.Empty
        Dim strNrotelefonico As String = String.Empty
        Dim strMensaje As String = ""
        Dim strRespuesta As String = ""
        Dim objBOValidacion As New Claro.SisAct.Negocios.BOValidarClienteClaro

            'Me.RegisterStartupScript("script1", "<script>TerminarTiempo();</script>")
            If chbPermiso.Checked = True Then
                p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
                p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
                p_Auditoria.AUDII_PDV = 1
                Session("p_Auditoria") = p_Auditoria
                objBOValidacion.ActualizarAuditoriaLog(p_Auditoria)
                Me.RegisterStartupScript("script1", "<script>TerminarTiempo();f_excepcion();</script>")
            Else
                If (txtClaveSMS.Text.Trim.Length <= 0) Then
                    Me.RegisterStartupScript("script1", "<script>alert('Ingrese el código SMS');</script>")
                    Return
                End If
                If validar_Tiempo_Excedente(strRespuesta, strMensaje) Then

                Else
                    Dim objCOEncryptar As New Claro.SisAct.Common.Cryptografia
                    Dim strIntentos As String = "1"

                    strNrotelefonico = rblListaNumeros.SelectedValue.ToString()
                    strClaveBDEncriptada = objBOValidacion.ObtenerCodigoSMS(strNrotelefonico)
                    strIntentos = objBOValidacion.Capturar_ValorParametros(Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_PARA_INTENTOS")))

                    strClaveDesencriptada = objCOEncryptar.DescifrarCadena(strClaveBDEncriptada)
                    If (txtClaveSMS.Text.Trim() = strClaveDesencriptada) Then
                        intIntentos = Funciones.CheckInt(hidIntentos.Value)
                        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
                        p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
                        p_Auditoria.AUDII_NROINTENTO = intIntentos
                        p_Auditoria.AUDII_NROINDICADOR = 1
                        Session("p_Auditoria") = p_Auditoria
                        GuardarLOG()
                        Me.RegisterStartupScript("script1", "<script>TerminarTiempo();alert('Validación Exitosa. Continuar con la Venta.');f_Salir(0);</script>")
                        Exit Sub
                    Else
                        intIntentos = Funciones.CheckInt(hidIntentos.Value)
                        If intIntentos = Convert.ToInt32(strIntentos) Then

                            p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
                            p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
                            p_Auditoria.AUDII_NROINTENTO = intIntentos
                            p_Auditoria.AUDII_NROINDICADOR = 2
                            Session("p_Auditoria") = p_Auditoria
                            GuardarLOG()

                            hidIntentos.Value = "1"
                            hidNuevo.Value = "0"
                            Me.RegisterStartupScript("script1", "<script>TerminarTiempo();alert('Se excedio el número de intentos permitidos.');f_Salir(1);</script>")
                            Exit Sub
                        Else
                            p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
                            p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
                            p_Auditoria.AUDII_NROINTENTO = intIntentos
                            p_Auditoria.AUDII_NROINDICADOR = 2
                            Session("p_Auditoria") = p_Auditoria
                            GuardarLOG()
                            Me.RegisterStartupScript("script1", "<script>TerminarTiempo();alert('La Clave ingresada es incorrecta. Vuelva a intentarlo.');</script>")
                            btnAceptar.Enabled = True
                            btnSolicitarClave.Enabled = False
                            txtClaveSMS.Text = ""
                            intIntentos += 1
                            hidNuevo.Value = "1"
                            hidIntentos.Value = Funciones.CheckStr(intIntentos)
                        End If
                    End If
                End If
            End If

    End Sub
#End Region

#Region "Funciones"

    Private Sub ListarLineasActivas()
        If (rblListaNumeros.Items.Count > 0) Then
            rblListaNumeros.SelectedIndex = 0
        End If


            Dim ArrayListaActivas As ArrayList
            Dim ArrayActivos As New ArrayList
            Dim _objNego As New Claro.SisAct.Negocios.BOValidarClienteClaro
            ArrayListaActivas = _objNego.ListarLineasActivas(0, hidNroDocu.Value)
            If (ArrayListaActivas.Count <= 0) Then
                ArrayListaActivas = _objNego.ListarLineasActivas(Funciones.CheckInt(hidTipoDocu.Value), hidNroDocu.Value)
            End If

            For Each intitem As Claro.SisAct.Entidades.ItemGenerico In ArrayListaActivas
                Dim strNumero As String = Funciones.CheckStr(intitem.Codigo)
                Dim strValido As String = ""
                Dim oItem As New Claro.SisAct.Entidades.ItemGenerico

                If (strNumero.Length > 6) Then
                    strValido = "XXXXXX" + strNumero.Substring(6, strNumero.Length - 6)
                Else
                    strValido = Funciones.CheckStr(intitem.Codigo)
                End If
                oItem.Codigo = Convert.ToString(intitem.Codigo)
                oItem.Descripcion = strValido
                ArrayActivos.Add(oItem)
            Next

            rblListaNumeros.DataSource = ArrayActivos
            rblListaNumeros.DataValueField = "Codigo"
            rblListaNumeros.DataTextField = "Descripcion"
            rblListaNumeros.DataBind()
            rblListaNumeros.SelectedIndex = 0

    End Sub

    Private Function GenerarClaveAleatoria() As String

        Dim retorno As String = String.Empty
        Try
            Dim rnd1 As New Random
            Dim intN1 As Integer = 0
            Dim intN2 As Integer = 0
            Dim intN3 As Integer = 0
            Dim intN4 As Integer = 0
            Dim intAleatorio As Integer = 0


            intN1 = rnd1.Next(10)
            Do
                intN2 = rnd1.Next(10)
            Loop While (intN2 = intN1)

            Do
                intN3 = rnd1.Next(10)
            Loop While (intN3 = intN1 OrElse intN3 = intN2)
            Do
                intN4 = rnd1.Next(10)
            Loop While (intN4 = intN1 Or intN4 = intN2 Or intN4 = intN3)

            intAleatorio = intN1 + (intN2 * 10) + (intN3 * 100) + (intN4 * 1000)

            retorno = Funciones.CheckStr(intAleatorio)
        Catch ex As Exception
        End Try
        Return retorno
    End Function

    Private Function EnviarSMS(ByVal strClaveAleatoria As String, ByVal strTiempo As String, ByRef _strRespuesta As String, ByRef _strMensaje As String) As Boolean

        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        Dim _strIdTransaccion As String = String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)
        Dim _strNombreServicio As String = System.Net.Dns.GetHostName()
        Dim _strIp As String = String.Empty
        Dim _strUsuario As String = CurrentUser
        Dim _booCorrecto As Boolean = False
        Dim boolReturn As String = ""
        Dim strNroTelefonico As String = Funciones.CheckStr(rblListaNumeros.SelectedValue)

        Dim strIdentificador As String = ConfigurationSettings.AppSettings("contIdentificadorSMS")

        hidIntentos.Value = "1"

        Try
            dttHoraInic = Now
            hitTiempo.Value = dttHoraInic.ToString
            _booCorrecto = objBOValidarCliente.EnviarSMS(_strIdTransaccion, _strIp, _strUsuario, strClaveAleatoria, strTiempo, strIdentificador, strNroTelefonico, ConfigurationSettings.AppSettings("VCLIENTE_URL_EnvioSMS"), _strRespuesta, _strMensaje)

            If Convert.ToString(_strRespuesta) = "-1" Then
                Enviar_Email(hidNroDocu.Value, hidNroSec.Value, _strUsuario, _strRespuesta, _strMensaje)
                LOG_SMS(_strNombreServicio, strNroTelefonico)
                Me.RegisterStartupScript("script1", "<script>alert('El servicio de Validacion Cliente Claro por SMS no se encuentra disponible');f_Confirmacion();</script>")

            End If
        Catch ex As Exception

            Enviar_Email(hidNroDocu.Value, hidNroSec.Value, _strUsuario, _strRespuesta, _strMensaje)
            LOG_SMS(_strNombreServicio, strNroTelefonico)
            Me.RegisterStartupScript("script1", "<script>alert('El servicio de Validación Cliente Claro por SMS no se encuentra disponible');f_Confirmacion();</script>")

            Throw ex
        End Try
        Return _booCorrecto
    End Function

    Private Sub Enviar_Email(ByVal strDocumento As String, ByVal strSec As String, ByVal strUsuarioApp As String, ByVal _strRespuesta As String, ByVal _strMensaje As String)
        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        Dim _strRemitente As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MAIL_REMI"))
        Dim _strUrl As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_URL_EnvioMAIL"))
        Dim _strAsunto As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_URL_EnvioMAIL"))
        Dim _strDesti1 As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MAIL_DESTI_1"))
        Dim _strDesti2 As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MAIL_DESTI_2"))
        Dim _strDesti3 As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MAIL_DESTI_3"))
        Dim _strDesti4 As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MAIL_DESTI_4"))
        Dim _strMensajeEmail As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_MENSA_TIEMPO"))
        _strMensajeEmail = _strMensajeEmail.Replace("XXXXX", strDocumento)
        _strMensajeEmail = _strMensajeEmail.Replace("YYYYY", strSec)
        objBOValidarCliente.EnviarMail(_strUrl, strUsuarioApp, _strRemitente, _strDesti1, _strAsunto, _strMensajeEmail, _strRespuesta, _strMensaje)
        objBOValidarCliente.EnviarMail(_strUrl, strUsuarioApp, _strRemitente, _strDesti2, _strAsunto, _strMensajeEmail, _strRespuesta, _strMensaje)
        objBOValidarCliente.EnviarMail(_strUrl, strUsuarioApp, _strRemitente, _strDesti3, _strAsunto, _strMensajeEmail, _strRespuesta, _strMensaje)
        objBOValidarCliente.EnviarMail(_strUrl, strUsuarioApp, _strRemitente, _strDesti4, _strAsunto, _strMensajeEmail, _strRespuesta, _strMensaje)

    End Sub

    Private Function validar_Tiempo_Excedente(ByRef _strRespuesta As String, ByRef _strMensaje As String) As Boolean
        Dim strTiempoSMS As String = String.Empty
        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        Dim dttFechaModif As Date
        Dim dttFechaFin As Date = Now
        Dim strUsuarioApp As String = CurrentUser

        dttHoraInic = Convert.ToDateTime(hitTiempo.Value)

        strTiempoSMS = objBOValidarCliente.Capturar_ValorParametros(Funciones.CheckStr(ConfigurationSettings.AppSettings("VCLIENTE_PARA_TIME_SMS")))
        If strTiempoSMS = "" Then strTiempoSMS = "0"
        dttFechaModif = dttHoraInic.AddSeconds(Convert.ToDouble(strTiempoSMS))
        If dttFechaModif >= dttFechaFin Then
            Return False
        Else

            p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
            p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
            p_Auditoria.AUDIV_COMENTARIO = "Supero el Time Out"
            p_Auditoria.AUDII_NROINTENTO = Convert.ToInt32(hidIntentos.Value)
            Session("p_Auditoria") = p_Auditoria
            GuardarLOG()
            hidNuevo.Value = "1"
            Me.RegisterStartupScript("script1", "<script>TerminarTiempo();alert('Codigo de SMS caducado, vuelva a enviar parametros');f_limpiar();</script>")
            Return True
        End If
    End Function

#End Region

#Region "Auditoria LOGS"
    Private Sub Obtener_Logs()
        Dim _objNegocio As New Claro.SisAct.Negocios.BOValidarClienteClaro
        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
        If hidIDAudi.Value = "" Then hidIDAudi.Value = "0"
        p_Auditoria = _objNegocio.ConsultarLogs(Convert.ToInt32(hidIDAudi.Value))
        Session("p_Auditoria") = p_Auditoria
    End Sub

    Private Sub LOG_SMS(ByVal _strNombreServicio As String, ByVal strNroTelefonico As String)
        Dim _strIp As String = System.Net.Dns.Resolve(_strNombreServicio).AddressList(0).ToString()

        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
        p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
        p_Auditoria.AUDIV_USUARIO_MODI = CurrentUser
        p_Auditoria.AUDIV_NROEQUIPO = strNroTelefonico
        p_Auditoria.AUDIV_IPSERVICIO = _strIp
        p_Auditoria.AUDII_NROENVIOSMS = p_Auditoria.AUDII_NROENVIOSMS + 1
        p_Auditoria.AUDII_DISPONIBLESMS = 2
        p_Auditoria.AUDIV_COMENTARIO = "Servicio SMS No Disponible"
        Session("p_Auditoria") = p_Auditoria
        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        objBOValidarCliente.ActualizarAuditoriaLog(p_Auditoria)
    End Sub

    Private Sub GuardarLOG()
        Dim _strNombreServicio As String = System.Net.Dns.GetHostName()
        Dim _strIp As String = System.Net.Dns.Resolve(_strNombreServicio).AddressList(0).ToString()
        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro

        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
        p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)
        p_Auditoria.AUDIV_NROEQUIPO = Funciones.CheckStr(rblListaNumeros.SelectedValue)
        p_Auditoria.AUDIV_IPSERVICIO = _strIp
        p_Auditoria.AUDIV_USUARIO_MODI = CurrentUser
        p_Auditoria.AUDIV_USUARIO_CREAC = CurrentUser

        If hidNuevo.Value = "1" Then
            objBOValidarCliente.GuardarAuditoriaLog(p_Auditoria)
        Else
            objBOValidarCliente.ActualizarAuditoriaLog(p_Auditoria)
        End If
        Session("p_Auditoria") = p_Auditoria
    End Sub

#End Region

#Region "Page Method"

    <Anthem.Method()> _
       Public Function LOGS(ByVal p_intPDV As Integer) As Boolean

        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
        p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)

        p_Auditoria.AUDII_PDV = p_intPDV
        Session("p_Auditoria") = p_Auditoria

        objBOValidarCliente.ActualizarAuditoriaLog(p_Auditoria)

        Return True
    End Function
    <Anthem.Method()> _
      Public Function LimpiarLogs() As Boolean

        Dim objBOValidarCliente As New Claro.SisAct.Negocios.BOValidarClienteClaro
        p_Auditoria = New Claro.SisAct.Entidades.AuditoriaLogs
        p_Auditoria = CType(Session("p_Auditoria"), Claro.SisAct.Entidades.AuditoriaLogs)

        p_Auditoria.AUDIV_NROEQUIPO = ""
        p_Auditoria.AUDIV_COMENTARIO = ""
        p_Auditoria.AUDII_PDV = 0
        p_Auditoria.AUDII_NROINTENTO = 1
        p_Auditoria.AUDII_NROINDICADOR = 1
        p_Auditoria.AUDII_NROENVIOSMS = 1
        p_Auditoria.AUDII_INTENTO_ANT = 1
        p_Auditoria.AUDII_DISPONIBLESMS = 1
        Session("p_Auditoria") = p_Auditoria

        Return True
    End Function
#End Region
End Class