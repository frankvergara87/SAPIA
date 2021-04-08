Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions
Imports System.Text

Public Class sisact_activacion_vas
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtNroCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtemail As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPaquete As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lbOpcion As System.Web.UI.WebControls.Label
    Protected WithEvents hidOpcionServicioVAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidConstServicioVAS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents HidCostoPaquete As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents HidFrecuenciaPaquete As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArrayDataPaquete As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents pnlEmail As System.Web.UI.WebControls.Panel
    Protected WithEvents lblTextoPaqueteDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblTextoCaution As System.Web.UI.WebControls.Label
    Protected WithEvents hidTextoPaqueteDesc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTextoCaution As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensajesRespuestaWS As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim oLog As New SISACT_Log
    Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRepPostpago")
    Dim oFile As String = oLog.Log_CrearNombreArchivo(nameFile)
    Dim strIdentifyLog As String
    Dim strClaroMusica As String = String.Empty
    Dim strClaroProteccion As String = String.Empty
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- CurrentUser: " & CurrentUser)

        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language='javascript'>validarUrl();</script>")
        Else
            Response.Write("<script language='javascript'>restringirEventos();</script>")
        End If
        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        strIdentifyLog = Me.CurrentUser
        Dim opcionServicio As String = IIf(Request.QueryString("co") Is Nothing, "0", Request.QueryString("co"))
        hidOpcionServicioVAS.Value = opcionServicio
        Dim oServicioVas As New ServicioVasNegocios

        Select Case opcionServicio
            Case ConfigurationSettings.AppSettings("consOpcionClaroProteccion")
                strClaroProteccion = CheckStr(oServicioVas.ListarOpcionVas(CheckInt(ConfigurationSettings.AppSettings("consServicioClaroProteccion")))) ' "CLARO PROTECCION"
                lbOpcion.Text = "VAS - " & strClaroProteccion.ToUpper()

            Case ConfigurationSettings.AppSettings("consOpcionIdeasMusik")
                strClaroMusica = CheckStr(oServicioVas.ListarOpcionVas(CheckInt(ConfigurationSettings.AppSettings("consServicioIdeasMusik")))) '"IDEASMUSIK"
                lbOpcion.Text = "VAS - " & strClaroMusica.ToUpper()

            Case Else
                RegisterStartupScript("scriptOption", "<script>alert('Error. Opción del menu incorrecta');</script>")
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
        End Select

        If Not Page.IsPostBack Then
            Inicio()
        Else
            Dim Accion As String = hidAccion.Value
            lblTextoPaqueteDesc.Text = hidTextoPaqueteDesc.Value
            lblTextoCaution.Text = hidTextoCaution.Value
            If Accion = "Validar" Then
                ActivarServicio()
            End If
        End If
    End Sub

    Private Sub ActivarServicio()
        Dim nroLinea As String = CheckStr(txtNroCelular.Text)
        Dim vmensaje As String = String.Empty
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio LeerDatosLinea()")

        Try

            'Se valida los datos ingresados
            If LeerDatosLinea(nroLinea) Then

                Dim codProveedor As String = String.Empty
                Dim codServicioVas As String = String.Empty
                Dim strEmail As String = String.Empty
                Dim nombreGrupo As String = String.Empty
                Dim idServicioWS As String = String.Empty

                If hidOpcionServicioVAS.Value.Equals(ConfigurationSettings.AppSettings("consOpcionClaroProteccion")) Then
                    codProveedor = ConfigurationSettings.AppSettings("consCodigoProveedorClaroProteccion")
                    codServicioVas = ConfigurationSettings.AppSettings("consServicioClaroProteccion")
                    strEmail = txtemail.Text.ToString.Trim()
                    nombreGrupo = ConfigurationSettings.AppSettings("constGrupoNombreCP")
                    idServicioWS = codServicioVas
                Else
                    codProveedor = ConfigurationSettings.AppSettings("consCodigoProveedorIdeasMusik")
                    codServicioVas = ConfigurationSettings.AppSettings("consServicioIdeasMusik")
                    nombreGrupo = ConfigurationSettings.AppSettings("constGrupoNombreIM")
                    idServicioWS = ddlPaquete.SelectedValue.ToString()
                End If

                Dim mensajeRespuesta As String = String.Empty

                'Validacion web service
                If ActivacionVasWS(nroLinea, idServicioWS, nombreGrupo, mensajeRespuesta) Then

                    'Se procede a realizar el registro del servicio
                    Dim oClaroProteccion As New ServicioVasNegocios
                    Dim objClaroProtec As New ServicioVas

                    Dim objResultado As Boolean
                    objClaroProtec.VSERV_CLIE_TELF = nroLinea 'Funciones.CheckStr(txtNroCelular.Text.ToString.Trim())
                    objClaroProtec.VSERC_CLIE_TIP_DOC = ddlTipoDocumento.SelectedValue.ToString()
                    objClaroProtec.VSERV_CLIE_DOC = Funciones.CheckStr(txtNroDocumento.Text.ToString.Trim())
                    objClaroProtec.VSERN_COD_PAQ = Funciones.CheckInt64(ddlPaquete.SelectedValue.ToString())
                    objClaroProtec.VSERV_DIR_EMAIL = Funciones.CheckStr(strEmail)
                    objClaroProtec.VSERN_COD_PROV = Convert.ToInt64(codProveedor)
                    objClaroProtec.VSERN_COD_VAS = Convert.ToInt64(codServicioVas)
                    objClaroProtec.VSERV_USU_CREA = Me.CurrentUser
                    objClaroProtec.VSERN_COS_SERV = Funciones.CheckDbl(HidCostoPaquete.Value)
                    objClaroProtec.VSERV_FRECUENCIA = Funciones.CheckStr(HidFrecuenciaPaquete.Value)
                    objClaroProtec.VSERC_FLAG_ACT = ConfigurationSettings.AppSettings("consFlagActivacion")
                    objClaroProtec.VSERC_FLAG_TIPF = ConfigurationSettings.AppSettings("consFlagTipificacion")

                    objResultado = oClaroProteccion.InsertarVas(objClaroProtec)

                    'If objResultado Then
                    '    vmensaje = "<script>alert('Se grabo Correctamente.');f_cancelar();</script>"
                    'Else
                    '    vmensaje = "<script>alert('No se grabo Correctamente.');</script>"
                    'End If
                    vmensaje = "<script>alert('" & mensajeRespuesta & "');f_cancelar();</script>"
                Else
                    vmensaje = "<script>alert('" & mensajeRespuesta & "');</script>"
                End If

                'vmensaje = "<script>alert('" & mensajeRespuesta & "');f_cancelar();</script>"

            Else
                oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin LeerDatosLinea()")
                Exit Sub
            End If

        Catch ex As Exception
            vmensaje = "<script>alert('Error. Comuniquese con el Administrador. " & ex.Message & "');</script>"
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception: " & ex.Message)
        End Try
        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin LeerDatosLinea()")
        RegisterStartupScript("scriptActivar", vmensaje)
    End Sub

    Private Function ActivacionVasWS(ByVal nroLinea As String, ByVal servicio As String, ByVal nombreGrupo As String, ByRef mensajeRespuesta As String) As Boolean

        Dim oClaroProteccion As New ServicioVasNegocios

        Dim idTransaccion As String = String.Format("{0:yyyyMMddhhmmss}", DateTime.Now)
        Dim _NOMBRE_SERVER As String = System.Net.Dns.GetHostName
        Dim ipAplicacion As String = System.Net.Dns.GetHostByName(_NOMBRE_SERVER).AddressList(0).ToString()
        Dim msisdn As String = "51" & nroLinea
        Dim imsi As String = ""
        Dim tipoLinea As String = "CO"
        Dim trama As String = GetTrama()
        Dim estado As String = String.Empty
        Dim codigoRespuesta As String = String.Empty

        oLog.Log_WriteLog(oFile, System.Environment.NewLine)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "**************** Inicio Activacion VAS WS")
        oLog.Log_WriteLog(oFile, System.Environment.NewLine)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "Parametros de entrada:")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- Id Transaccion = " & idTransaccion)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- Ip Aplicacion = " & ipAplicacion)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- Nombre Aplicacion = " & ConfigurationSettings.AppSettings("constAplicacion"))
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- msisdn = " & msisdn)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- imsi = " & imsi)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- servicio = " & servicio)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- tipoLinea = " & tipoLinea)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- nombreGrupo = " & nombreGrupo)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- trama = " & trama)

        Dim vExito As Boolean = oClaroProteccion.validarActivacionVas(idTransaccion, ipAplicacion, msisdn, _
                        imsi, servicio, tipoLinea, nombreGrupo, trama, mensajeRespuesta, estado, codigoRespuesta)

        oLog.Log_WriteLog(oFile, System.Environment.NewLine)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "Respuesta WS")
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- codigo Respuesta = " & codigoRespuesta)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- mensaje Respuesta = " & mensajeRespuesta)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- estado = " & estado)

        'Personalizar Mensaje Respuesta
        Dim flgMsgPerzonalidado As Boolean = CBool(ConfigurationSettings.AppSettings("constFlagMensajePersonalizadoVAS"))

        If flgMsgPerzonalidado Then

            'Obtener Mensaje Personalizado
            Dim arrMensajes() As String = Split(hidMensajesRespuestaWS.Value, "||||")
            Dim mensajeUsuario As String = String.Empty

            For i As Integer = 1 To arrMensajes.Length - 1 'UBound(arrMensajes)
                Dim arrDetMensaje() = Split(arrMensajes(i), "****")
                Dim _codigoResp As String = arrDetMensaje(0)

                If codigoRespuesta.Equals(_codigoResp) Then

                    Dim _mensajeResp As String = arrDetMensaje(1)

                    If nombreGrupo = ConfigurationSettings.AppSettings("constGrupoNombreCP") Then
                        mensajeUsuario = _mensajeResp.Replace("[NOMBRE_SERVICIO]", strClaroProteccion).Replace("[NOMBRE_PLAN/PAQUETE]", StrConv(ddlPaquete.SelectedItem.Text, vbProperCase))
                    ElseIf nombreGrupo = ConfigurationSettings.AppSettings("constGrupoNombreIM") Then
                        mensajeUsuario = _mensajeResp.Replace("[NOMBRE_SERVICIO]", strClaroMusica).Replace("[NOMBRE_PLAN/PAQUETE]", StrConv(ddlPaquete.SelectedItem.Text, vbProperCase))
                    End If
                    Exit For
                End If
            Next

            mensajeUsuario = IIf(mensajeUsuario.Equals(String.Empty), mensajeRespuesta, mensajeUsuario)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "- mensaje usuario = " & mensajeUsuario)

            mensajeRespuesta = mensajeUsuario

        End If

        oLog.Log_WriteLog(oFile, System.Environment.NewLine)
        oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "***************** Fin Activacion VAS WS")

        If vExito Then
            Dim descActivarServicio As StringBuilder = New StringBuilder
            descActivarServicio.Append("Se realizó la operación exitosa. La activación está en Proceso!")
            descActivarServicio.Append(" (")
            'descActivarServicio.Append("- Id Transaccion = " & idTransaccion)
            'descActivarServicio.Append("- Ip Aplicacion = " & ipAplicacion)
            'descActivarServicio.Append("- Nombre Aplicacion = " & ConfigurationSettings.AppSettings("constAplicacion"))
            descActivarServicio.Append(" msisdn = " & msisdn)
            descActivarServicio.Append(" | imsi = " & imsi)
            descActivarServicio.Append(" | servicio = " & servicio)
            descActivarServicio.Append(" | tipoLinea = " & tipoLinea)
            descActivarServicio.Append(" | nombreGrupo = " & nombreGrupo)
            descActivarServicio.Append(" | trama = " & trama)
            descActivarServicio.Append(" )")

            oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "****** Inicio Guardado Auditoria")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "| " & "  Input --> auditoria  : " & descActivarServicio.ToString)

            AuditoriaActivarServicio(descActivarServicio.ToString())

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "*****  Fin Guardado Auditoria")
        End If

        Return vExito

    End Function

    Private Function GetTrama() As String
        Dim strTrama As StringBuilder = New StringBuilder
        strTrama.Append("<trama>")
        If pnlEmail.Visible = True Then 'Claro Proteccion
            strTrama.Append("<email>" & txtemail.Text & "</email>")
            strTrama.Append("<paquete>" & ddlPaquete.SelectedValue.ToString() & "</paquete>")
        End If
        strTrama.Append("<usuario>" & Me.CurrentUser & "</usuario>")
        strTrama.Append("</trama>")
        Return strTrama.ToString()
    End Function

    Private Sub ObtenerMensajes()
        Dim valorGrupoConfigVAS As Int64 = CheckInt64(ConfigurationSettings.AppSettings("constGrupoConfigVAS"))
        Dim arrParametros As ArrayList = New ServicioVasNegocios().ListarParametroConfig(valorGrupoConfigVAS)

        Dim strRespuestaWS As StringBuilder = New StringBuilder
        For Each item As ParametroConsumer In arrParametros
            strRespuestaWS.Append("||||" & item.PCONI_CODIGO & "****" & item.PCONV_MENSAJE)
        Next
        hidMensajesRespuestaWS.Value = strRespuestaWS.ToString
    End Sub

    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean

        strIdentifyLog = nroLinea
        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim oVentaExpress As New VentaExpressNegocios

        Dim mensajeError As String = ""
        Dim datosLinea As ClienteBSCS = Nothing
	Dim strTipoDocumentoVAS As String = ""

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio LeerDatosCliente()")

        datosLinea = oPostpagoNegocios.LeerDatosCliente(nroLinea, "", mensajeError)

        oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin LeerDatosCliente()  (output) -> mensajeError:" & mensajeError)

        If IsNothing(datosLinea) Then
            oLog.Log_WriteLog(oFile, strIdentifyLog & "-  Datos Linea es vacio")
            RegisterStartupScript("scriptDatosLinea", "<script>alert('" & ConfigurationSettings.AppSettings("consMsgNotLineaPostPago") & "');setFocus('txtNroCelular');</script>")
            Return False
        End If

        'VALIDAR TITULARIDAD DE LA LINEA
        If ddlTipoDocumento.SelectedItem.Text = "RUC" Then
            If txtNroDocumento.Text.Trim <> datosLinea.Ruc_dni.Trim Then
                RegisterStartupScript("scriptDatosLinea", "<script>alert('" & ConfigurationSettings.AppSettings("consMsgNotLineaDNI") & "');setFocus('txtNroDocumento');</script>")
                Return False
            End If
        Else
            Select Case ddlTipoDocumento.SelectedItem.Text 'gdb
                Case "CE"
                    strTipoDocumentoVAS = ConfigurationSettings.AppSettings("DescripcionTipoDocumentoCE")
                Case "DNI"
                    strTipoDocumentoVAS = ddlTipoDocumento.SelectedItem.Text
            End Select
            If strTipoDocumentoVAS <> datosLinea.Tip_doc Or txtNroDocumento.Text.Trim <> datosLinea.Num_doc.Trim Then
                RegisterStartupScript("scriptDatosLinea", "<script>alert('" & ConfigurationSettings.AppSettings("consMsgNotLineaDNI") & "');setFocus('txtNroDocumento');</script>")
                Return False
            End If
        End If

        If datosLinea.Status_cuenta <> "Activo" Then
            RegisterStartupScript("scriptDatosLinea", "<script>alert('" & ConfigurationSettings.AppSettings("consMsgNotLineaActivo") & "');setFocus('txtNroCelular');</script>")
            Return False
        End If

        Return True

    End Function

    Private Sub Inicio()
        SetVisibleEmail()
        CargarTipoDocumento()
        CargarTipoPaquete()
        ObtenerMensajes()
        RegisterStartupScript("scriptInit", "<script>inicio();</script>")
    End Sub

    Private Sub SetVisibleEmail()
        If hidOpcionServicioVAS.Value.Equals(ConfigurationSettings.AppSettings("consOpcionClaroProteccion")) Then
            pnlEmail.Visible = True
        Else
            pnlEmail.Visible = False
        End If
    End Sub

    Private Sub CargarTipoPaquete()

        Dim objtipopaquete As New ServicioVasNegocios
        Dim listaPaquete As New ArrayList
        Dim keyServicioVAS As String = IIf(hidOpcionServicioVAS.Value.Equals(ConfigurationSettings.AppSettings("consOpcionClaroProteccion")), "consServicioClaroProteccion", "consServicioIdeasMusik")
        listaPaquete = objtipopaquete.ListaPaqueteVas(CInt(ConfigurationSettings.AppSettings(keyServicioVAS)))

        Dim oItem As New TipoPaqueteVas("00", ConfigurationSettings.AppSettings("Seleccionar"), Nothing)
        listaPaquete.Insert(0, oItem)

        With ddlPaquete
            .DataSource = listaPaquete
            .DataValueField = "VASN_CODIGO"
            .DataTextField = "DESV_PAQUETE"
            .DataBind()
        End With

        Dim sbTipoDocumento As New StringBuilder

        For Each item As TipoPaqueteVas In listaPaquete
            sbTipoDocumento.Append(item.VASN_CODIGO)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.DESV_DET_PAQUETE)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.COSTN_SERVICIO)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.FRECV_TIEMPO)
            sbTipoDocumento.Append("|")
        Next

        sbTipoDocumento.Remove(sbTipoDocumento.Length - 1, 1)
        hidArrayDataPaquete.Value = sbTipoDocumento.ToString

    End Sub
    Private Sub CargarTipoDocumento()
        Dim lista As ArrayList = (New VentaNegocios).ListaTipoDocumento("")

        'Remuevo los item de CIP y PASAPORTE 
        lista.RemoveRange(3, 1)
        lista.RemoveRange(1, 1)

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)

        LlenaCombo(lista, ddlTipoDocumento, "Codigo", "Descripcion")
    End Sub

#Region " Auditoria"
    Private Sub AuditoriaActivarServicio(ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("COD_SISACT_ACTIVAR_VAS")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, txtNroCelular.Text, "", desTrans)
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Transaccion Auditoria  : " & ex.Message)
        End Try
    End Sub
#End Region

End Class
