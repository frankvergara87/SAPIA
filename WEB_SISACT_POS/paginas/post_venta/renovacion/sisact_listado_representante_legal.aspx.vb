Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Web.Mail
Imports System.Text

Public Class sisact_listado_representante_legal
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents dgRepresentanteLegal As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidMensajeResultado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRazonSocial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodTipoRiesgo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagEjecucion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodSolicitud As System.Web.UI.HtmlControls.HtmlInputHidden    
    Protected WithEvents hidNombre As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApellidoPaterno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApellidoMaterno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoPersona As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagInterno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSituacionOK As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSituacionNOOK As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroFilas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDeudaFinanciera As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidForm As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoRUC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodError As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidError As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidContFact As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBuroConsultado As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not Page.IsPostBack Then
            hidFlagEjecucion.Value = ""
            hidNumeroOperacion.Value = ""
            hidRazonSocial.Value = ""
            hidCodTipoRiesgo.Value = ""
            hidCodSolicitud.Value = ""
            hidNombre.Value = ""
            hidApellidoPaterno.Value = ""
            hidApellidoMaterno.Value = ""
            hidTipoPersona.Value = ""
            hidSituacionOK.Value = ConfigurationSettings.AppSettings("constMensajeEstatusRRLLOK")
            hidSituacionNOOK.Value = ConfigurationSettings.AppSettings("constMensajeEstatusRRLLNOOK")
            hidForm.Value = CheckStr(Request("form"))

            dgRepresentanteLegal.DataSource = Nothing
            Dim oDataCreditoCorpIN As New DataCreditoCorpIN
            Try
                oDataCreditoCorpIN.istrTipoDocumento = CheckStr(Request("strTipoDocumento"))
                oDataCreditoCorpIN.istrNumeroDocumento = CheckStr(Request("strNumeroDocumento"))
                oDataCreditoCorpIN.istrNombres = Mid(CheckStr(Request("strNombre")).ToUpper(), 1, 40)
                oDataCreditoCorpIN.istrApellidoPaterno = Mid(CheckStr(Request("strApellidoPaterno")).ToUpper(), 1, 40)
                oDataCreditoCorpIN.istrApellidoMaterno = Mid(CheckStr(Request("strApellidoMaterno")).ToUpper(), 1, 40)
                oDataCreditoCorpIN.istrTipoPersona = CheckStr(Request("strTipoPersona"))
                oDataCreditoCorpIN.istrCodSolicitud = CheckStr(Request("strCodSolicitud"))
                oDataCreditoCorpIN.istrTipoSEC = CheckStr(Request("strTipoSEC"))

                If oDataCreditoCorpIN.istrTipoDocumento <> "" Or oDataCreditoCorpIN.istrCodSolicitud <> "" Then
                    hidFlagEjecucion.Value = "1"
                    Consultar(oDataCreditoCorpIN)
                End If
            Catch ex As Exception
                ' Guardar Archivo LOG
                GuardarLogErrorDC(oDataCreditoCorpIN, "DataCreditoCorp Error: Variables de Entrada no adecuadas. " & ex.Message)
                RegisterStartupScript("script", "<script> alert('DataCreditoCorp Error: Variables de Entrada no adecuadas. " & ex.Message & "');</script>")
                Exit Sub
            End Try
        End If
    End Sub

    Sub Consultar(ByRef oDataCreditoCorpIN As DataCreditoCorpIN)
        Dim nroFilas As Integer = 0
        Dim mensajeAudit As String = ""
        If (oDataCreditoCorpIN.istrCodSolicitud.Equals(String.Empty)) Then
            Dim blnResultado As Boolean = False

            ' INICIO Consulta DataCredito Corp
            Dim oConsultaDCCorp As New DataCreditoCorpNegocios
            Dim OConsultaWSDCCorp As New CreditosWSNegocios 'ADD PROY-20054-IDEA-23849
            Dim oEmpresaExperto As New EmpresaExperto
            Dim ListaRepresentante As New ArrayList
            Dim mensajeError As String = ""

            'INICIO: PROY-20054-IDEA-23849
			Dim usuario As String = CurrentUser()
			Dim oUsuarioNegocio As New LoginUsuarioNegocios
			Dim oUsuario As New usuario
			oUsuario = oUsuarioNegocio.ConsultaDatosUsuario(usuario)
			oDataCreditoCorpIN.istrPuntoVenta = Funciones.CheckStr(oUsuario.OficinaId)
			
            If ConfigurationSettings.AppSettings("flagBuroCorporativoAntiguo") = "1" Then
            If ConfigurationSettings.AppSettings("Flag_DC_Equifax") = "1" Then
                Dim nombreHost As String = System.Net.Dns.GetHostName
                Dim nombreServer As String = System.Net.Dns.GetHostName
                Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
                Dim usuario_id As String = CurrentUser
                Dim ipcliente As String = CurrentTerminal
                oEmpresaExperto = oConsultaDCCorp.ConsultaBuroCrediticio(oDataCreditoCorpIN, CurrentUser(), mensajeError, nombreHost, nombreServer, ipServer, ipcliente)
            End If
            Else
                Dim nombreHost As String = System.Net.Dns.GetHostName
                Dim nombreServer As String = System.Net.Dns.GetHostName
                Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
                Dim usuario_id As String = CurrentUser
                Dim ipcliente As String = CurrentTerminal

                oEmpresaExperto = OConsultaWSDCCorp.ConsultaDataCreditoCorp(oDataCreditoCorpIN, CurrentUser(), mensajeError, nombreHost, nombreServer, ipServer, ipcliente, Session("beUsuario"))
            End If
            'FIN: PROY-20054-IDEA-23849

            oConsultaDCCorp = Nothing

            Session("EmpresaExperto") = oEmpresaExperto 'ADD PROY-20054-IDEA-23849
            Session("OrigenExperto") = oEmpresaExperto.origen_experto

            If oEmpresaExperto Is Nothing Or oEmpresaExperto.strCodRetorno Is Nothing Then
                hidMensajeResultado.Value = "Error: Servicio DataCredito Corporativo no disponible. " & Chr(13) & mensajeError
                hidNroFilas.Value = nroFilas.ToString

                ' Registrar Auditoria DataCredito
                mensajeAudit = "Consulta DataCredito Corp RESPUESTA NULA. (" & _
                    "" & ";" & oDataCreditoCorpIN.istrTipoDocumento & ";" & oDataCreditoCorpIN.istrNumeroDocumento & ";" & _
                    oDataCreditoCorpIN.istrPuntoVenta & ";" & "" & ";" & _
                    "" & ";" & oDataCreditoCorpIN.istrApellidoPaterno & ";" & _
                    oDataCreditoCorpIN.istrApellidoMaterno & ";" & oDataCreditoCorpIN.istrNombres & ";" & oDataCreditoCorpIN.istrTipoSEC & ") ERROR: " & mensajeError

                AuditoriaConsultaDC(mensajeAudit, oDataCreditoCorpIN, oEmpresaExperto)

                Exit Sub
            End If

            blnResultado = (oEmpresaExperto.strFlagInterno.Equals("0"))
            If oEmpresaExperto.strFlagInterno.Equals("3") Then blnResultado = True ' Excepcion Servicio 53 (dejar Pasar)

            hidFlagInterno.Value = oEmpresaExperto.strFlagInterno
            If (Not blnResultado) Then
                Dim mensaje As String = ""
                If (oEmpresaExperto.strCodError <> "") Then
                    mensaje = mensajeError & " (CodigoRetorno: " & oEmpresaExperto.strCodRetorno & "; CodigoError: " & oEmpresaExperto.strCodError & "; Descripcion: " & oEmpresaExperto.strMensajeError & ")."
                    ' PABLO OJO - VALIDAR LOS CODIGOS DE RETORNO (13, 09, etc)???
                Else
                    mensaje = mensajeError & " (CodigoRetorno: " & oEmpresaExperto.strCodRetorno & ")."
                End If
                hidMensajeResultado.Value = "Error: " & mensaje

                hidNroFilas.Value = nroFilas.ToString

                ' Registrar Auditoria DataCredito
                mensajeAudit = "Consulta DataCredito Corp RESPUESTA CON ERROR. (" & _
                    oEmpresaExperto.strNroOperacion & ";" & oDataCreditoCorpIN.istrTipoDocumento & ";" & oDataCreditoCorpIN.istrNumeroDocumento & ";" & _
                    oDataCreditoCorpIN.istrPuntoVenta & ";" & oEmpresaExperto.strRiesgo & ";" & _
                    oEmpresaExperto.strCodError & ";" & oEmpresaExperto.strApellidoPaterno & ";" & _
                    oEmpresaExperto.strApellidoMaterno & ";" & oEmpresaExperto.strNombres & ";" & oDataCreditoCorpIN.istrTipoSEC & ")"

                AuditoriaConsultaDC(mensajeAudit, oDataCreditoCorpIN, oEmpresaExperto)

                ' Guardar Archivo LOG
                GuardarLogErrorDC(oDataCreditoCorpIN, "DataCreditoCorp Error: " & mensaje)

                ' Enviar Correo
                Dim mensajeRespuesta As String
                Dim body As String = ""
                If Not oEmpresaExperto.strCodRetorno.Equals(ConfigurationSettings.AppSettings("DcCorpCodigoRetornoOk").ToString()) Then
                    body = Body_Correo_DC(oDataCreditoCorpIN, oEmpresaExperto, mensajeError)
                    EnviarCorreos(body)
                End If
                Exit Sub
            End If

            ' Registrar Auditoria DataCredito
            mensajeAudit = "Consulta DataCredito Corp RESPUESTA EXITOSA. (" & _
                oEmpresaExperto.strNroOperacion & ";" & oDataCreditoCorpIN.istrTipoDocumento & ";" & oDataCreditoCorpIN.istrNumeroDocumento & ";" & _
                oDataCreditoCorpIN.istrPuntoVenta & ";" & oEmpresaExperto.strRiesgo & ";" & _
                oEmpresaExperto.strCodError & ";" & oEmpresaExperto.strApellidoPaterno & ";" & _
                oEmpresaExperto.strApellidoMaterno & ";" & oEmpresaExperto.strNombres & ";" & oDataCreditoCorpIN.istrTipoSEC & ")"

            AuditoriaConsultaDC(mensajeAudit, oDataCreditoCorpIN, oEmpresaExperto)

            Try
                hidTipoPersona.Value = oDataCreditoCorpIN.istrTipoPersona
                hidNumeroOperacion.Value = oEmpresaExperto.strNroOperacion
                hidRazonSocial.Value = oEmpresaExperto.strRazonSocial
                hidNombre.Value = oEmpresaExperto.strNombres
                hidApellidoPaterno.Value = oEmpresaExperto.strApellidoPaterno
                hidApellidoMaterno.Value = oEmpresaExperto.strApellidoMaterno
                hidCodTipoRiesgo.Value = oEmpresaExperto.strRiesgo
                hidDeudaFinanciera.Value = oEmpresaExperto.deuda_financiera.ToString
                hidEstadoRUC.Value = oEmpresaExperto.estado_ruc
                hidBuroConsultado.Value = oEmpresaExperto.buro_consultado 'ADD PROY-20054-IDEA-23849

                If hidEstadoRUC.Value.Equals("B") Then
                    'obtenemos el mensaje de la tabla de parametros
                    Dim msg As String = mensajeError
                    Dim oGeneral As New MaestroNegocio
                    Dim ListaParametro As ArrayList
                    ListaParametro = oGeneral.ListaParametros(70)
                    If ListaParametro.Count > 0 Then msg = CType(ListaParametro(0), Parametro).Valor
                    hidMensajeResultado.Value = msg
                    Return
                    'Exit Sub
                End If
            Catch ex As Exception
                hidMensajeResultado.Value = "Error en la informacion enviada por DataCredito Corp. Comunicarse con Creditos. " & ex.Message
            End Try

            If oEmpresaExperto.strFlagInterno.Equals("3") Then
                If (oEmpresaExperto.strCodError <> "") Then
                    hidMensajeResultado.Value = "Error: " & mensajeError & " (CodigoRetorno: " & oEmpresaExperto.strCodRetorno & "; CodigoError: " & oEmpresaExperto.strCodError & "; Descripcion: " & oEmpresaExperto.strMensajeError & ")."
                Else
                    hidMensajeResultado.Value = "Error: " & mensajeError & " (CodigoRetorno: " & oEmpresaExperto.strCodRetorno & ")."
                End If
            End If

            Try
                Dim oRepresentanteAux As New RepresentanteLegal

                If oEmpresaExperto.ListaRepresentanteLegal.Count > 0 Then
                    For i As Integer = 0 To oEmpresaExperto.ListaRepresentanteLegal.Count - 1
                        oRepresentanteAux = CType(oEmpresaExperto.ListaRepresentanteLegal(i), RepresentanteLegal)
                        Dim ListaRepresentanteAux As ArrayList = ObtenerListaValoresXML("ListaTipoDocumentoExperto", oRepresentanteAux.APODC_TIP_DOC_REP, "1")
                        If ListaRepresentanteAux.Count > 0 Then
                            oRepresentanteAux.APODC_TIP_DOC_REP = CType(ListaRepresentanteAux(0), ItemGenerico).Codigo2
                            oRepresentanteAux.APODV_NUM_DOC_REP = Funciones.NroDocumentoIdentidad(oRepresentanteAux.APODC_TIP_DOC_REP, oRepresentanteAux.APODV_NUM_DOC_REP)
                            oRepresentanteAux.TDOCV_DESCRIPCION_REP = CType(ListaRepresentanteAux(0), ItemGenerico).Descripcion
                            ListaRepresentante.Add(oRepresentanteAux)
                        End If
                    Next
                End If
                nroFilas = ListaRepresentante.Count

                dgRepresentanteLegal.DataSource = ListaRepresentante
                dgRepresentanteLegal.DataBind()
            Catch ex As Exception
                If hidMensajeResultado.Value.Equals(String.Empty) Then
                    hidMensajeResultado.Value = "Error en la informacion enviada por DataCredito Corp. Comunicarse con Creditos. " & ex.Message
                Else
                    hidMensajeResultado.Value = hidMensajeResultado.Value & Chr(13) & "Error en la informacion enviada por DataCredito Corp. Comunicarse con Creditos. " & ex.Message
                End If
            End Try
            'Muestra Resultado de la Evaluacion para RUC
            RegisterStartupScript("script", "<script>self.parent.mostrarDatosResultado();</script>")
        Else
            Dim oConsulta As New SolicitudNegocios
            Dim oSolicitud As SolicitudEmpresa
            oSolicitud = oConsulta.ObtenerSolicitudEmpresa(oDataCreditoCorpIN.istrCodSolicitud)
            oConsulta = Nothing

            If oSolicitud.FLAG_RESPONSABLE_PUNTO_VENTA <> "1" Then
                If oSolicitud.REPRESENTANTE_LEGAL.Count > 0 Then
                    nroFilas = oSolicitud.REPRESENTANTE_LEGAL.Count
                    dgRepresentanteLegal.DataSource = oSolicitud.REPRESENTANTE_LEGAL
                    dgRepresentanteLegal.DataBind()
                End If
            End If
            hidCodSolicitud.Value = oDataCreditoCorpIN.istrCodSolicitud
        End If

        hidNroFilas.Value = nroFilas.ToString()
    End Sub

    Public Sub GuardarLogErrorDC(ByRef oDataCreditoCorpIN As DataCreditoCorpIN, ByVal mensajeError As String)
        Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("Log_ErrorConsultaDcCorp")
        Dim objLog As New SISACT_Log

        objLog.Log_WriteLog(strArchivoLOG, "**************************** ERROR CONSULTA DATACREDITO CORP ****************************")
        objLog.Log_WriteLog(strArchivoLOG, "  PARAMETROS")
        objLog.Log_WriteLog(strArchivoLOG, "  Tipo de Documento                 : " & oDataCreditoCorpIN.istrTipoDocumento)
        objLog.Log_WriteLog(strArchivoLOG, "  Numero de Documento de Identidad  : " & oDataCreditoCorpIN.istrNumeroDocumento)

        If Not oDataCreditoCorpIN.istrCodSolicitud.Equals(String.Empty) Then
            objLog.Log_WriteLog(strArchivoLOG, "  Codigo de Solicitud               : " & oDataCreditoCorpIN.istrCodSolicitud)
        End If
        objLog.Log_WriteLog(strArchivoLOG, "  ----------------------------------------------------------------------------------")
        objLog.Log_WriteLog(strArchivoLOG, "  ERROR")
        objLog.Log_WriteLog(strArchivoLOG, "  Descripcion Error                 : " & mensajeError)
        objLog.Log_WriteLog(strArchivoLOG, "************************************************************************************")

        objLog = Nothing
    End Sub

    Private Function Body_Correo_DC(ByRef oDataCreditoCorpIN As DataCreditoCorpIN, ByRef oDataCreditoCorpOUT As EmpresaExperto, ByVal mensajeError As String) As String
        Dim cuerpo As New StringBuilder
        Dim flag As String = ConfigurationSettings.AppSettings("FlagPrueba").ToString()
        If flag.Equals("0") Then
            cuerpo.Append("AMBIENTE DE PRODUCCION - CORREO DE ALERTA - DATACREDITO CORP")
        Else
            cuerpo.Append("PRUEBAS EN DESARROLLO O EN QA - CORREO DE ALERTA - DATACREDITO CORP")
        End If
        cuerpo.Append("<br><hr align='left' style='height:1px;width:570px;border:1px solid #000;'>")
        cuerpo.Append(mensajeError)
        cuerpo.Append("Consulta a DataCredito Nº " & oDataCreditoCorpOUT.strNroOperacion)
        cuerpo.Append("<br><br><hr align='left' style='height:1px;width:570px;border:1px solid #000;'>")
        cuerpo.Append("Respuesta devuelta:")
        cuerpo.Append("<br><br>")
        cuerpo.Append("&nbsp;&nbsp;Mensaje : " & oDataCreditoCorpOUT.strMensajeError)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Codigo  : " & oDataCreditoCorpOUT.strCodError)
        cuerpo.Append("<br><hr align='left' style='height:1px;width:570px;border:1px solid #000;'>")
        cuerpo.Append("Datos del Cliente:")
        cuerpo.Append("<br><br>")
        cuerpo.Append("&nbsp;&nbsp;Tipo Documento   : " & oDataCreditoCorpIN.istrTipoDocumento)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Numero Documento : " & oDataCreditoCorpIN.istrNumeroDocumento)
        cuerpo.Append("<br>") 'PABLO OJO
        cuerpo.Append("&nbsp;&nbsp;Nombre           : " & oDataCreditoCorpOUT.strNombres)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Apellido Paterno : " & oDataCreditoCorpOUT.strApellidoPaterno)
        cuerpo.Append("<br>")
        cuerpo.Append("&nbsp;&nbsp;Apellido Materno : " & oDataCreditoCorpOUT.strApellidoMaterno)
        cuerpo.Append("<br><hr align='left' style='height:1px;width:570px;border:1px solid #000;'>")
        cuerpo.Append("Código de Punto de Venta que realizó la consulta: " & oDataCreditoCorpIN.istrPuntoVenta)
        Return cuerpo.ToString
    End Function

    Public Sub EnviarCorreos(ByVal mensaje As String)
        Dim MyMail As MailMessage = New MailMessage
        MyMail.From = ConfigurationSettings.AppSettings("DcEmailRemitente").ToString()
        MyMail.Subject = "Informe Consulta DataCredito Corporativo"
        MyMail.Body = Trim(mensaje)
        MyMail.BodyFormat = MailFormat.Html
        SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("DcEmailSmtpServer").ToString()

        Try
            Dim FlagPrueba As String = ConfigurationSettings.AppSettings("FlagPrueba").ToString()
            If FlagPrueba.Equals("0") Then
            MyMail.To = ConfigurationSettings.AppSettings("DcEmailDestinatarioPRD").ToString()
            SmtpMail.Send(MyMail)
            End If
            MyMail.To = ConfigurationSettings.AppSettings("DcEmailDestinatarioDES").ToString()
            SmtpMail.Send(MyMail)
        Catch ex As Exception
        Finally
            MyMail = Nothing
        End Try
    End Sub

    Public Sub AuditoriaConsultaDC(ByVal mensaje As String, ByRef oDataCreditoCorpIN As DataCreditoCorpIN, ByRef oDataCreditoCorpOUT As EmpresaExperto)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

            Dim strCodTrans As String = ConfigurationSettings.AppSettings("DcCorpAuditConsultaDataCredito" & oDataCreditoCorpIN.istrTipoSEC)

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", mensaje)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria la Consulta a DataCredito (OficinaVenta: " & oDataCreditoCorpIN.istrPuntoVenta & " | Nro Operacion: " & oDataCreditoCorpOUT.strNroOperacion & ").")
            End If
        Catch ex As Exception

        End Try
    End Sub
    '//PROY 31636 RENTESEG
    Public Function obtenerNacionalidad() As ArrayList
        Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("Log_Representante_legal")
        Dim objLog As New SISACT_Log
        Dim lstArrNacionalidad As ArrayList = New ArrayList
        objLog.Log_WriteLog(strArchivoLOG, "***************** INICIO NACIONALIDAD REPRESENTANTE LEGAL ************")
        Try
            lstArrNacionalidad = CType(Session("lstArraNacionalidad"), ArrayList)
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivoLOG, "ERROR al cargar Nacionalidad Representante legal ")
        End Try
        objLog.Log_WriteLog(strArchivoLOG, "***************** FIN NACIONALIDAD REPRESENTANTE LEGAL ************")
        Return lstArrNacionalidad
    End Function
    '//PROY 31636 RENTESEG
End Class
