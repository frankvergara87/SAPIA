Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_imei
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidCodImei As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidskuimei As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVentaCod As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsoHLR As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidHlr As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region
    Dim oLog As New SISACT_Log
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_consulta_imei")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")
        If Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not IsPostBack Then
                Inicio()
            Else
                If hidRequest.Value = "BuscarImei" Then
                    BuscarImei()
                End If
            End If
            Dim strScript3 As String = "inicio();"
            RegisterStartupScript("script", "<script>" & strScript3 & "</script>")
        End If

    End Sub

    Private Sub Inicio()
        oLog.Log_WriteLog(strArchivo, " - " & "Obtener los datos del IMEI")

        hidCodImei.Value = Request.QueryString("codImei")
        oLog.Log_WriteLog(strArchivo, " - " & "Codigo del Imei    : " & CheckStr(hidCodImei.Value))
        hidCanal.Value = Request.QueryString("hidCanal")
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material    : " & CheckStr(hidCanal.Value))
        hidOfVentaCod.Value = Request.QueryString("hidOfVentaCod")
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material    : " & CheckStr(hidOfVentaCod.Value))
        hidUsoHLR.Value = Request.QueryString("usaHLR")
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material    : " & CheckStr(hidUsoHLR.Value))
        hidHlr.Value = Request.QueryString("nroHLR")
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material    : " & CheckStr(hidHlr.Value))
        If hidCodImei.Value = "" Then
            hidResponse.Value = "ExtraerDatos"
        Else
            oLog.Log_WriteLog(strArchivo, " - " & "Ingreso al Buscar Imei")
            BuscarImei()
        End If
    End Sub

    Private Sub BuscarImei()
        Dim codImei As String = hidCodImei.Value
        Dim usoHLR As String = hidUsoHLR.Value
        Dim nroHLR As String = hidHlr.Value
        Dim Oficina As String = hidOfVentaCod.Value
        Dim listArrayPVD As New ArrayList
        Dim strTipoVenta As String = ConfigurationSettings.AppSettings("strPostpagoTipoVenta")
        Dim strTipoOperacion As String = ConfigurationSettings.AppSettings("strPostpagoTipoOperacion")
        oLog.Log_WriteLog(strArchivo, " - " & "INGRESO1")
        If codImei <> "" Then
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO2")
            'Dim oConsultarSap As New SapGeneralNegocios '--dga
            Dim oConsulta As New VentaExpressNegocios
            Dim item As New ItemGenerico
            Dim item1 As New ItemGenerico
            Dim OBJPTOVENTA As PuntoVenta
            Dim oBLConsultaMssap As New BLConsultaMssap '--dga
            'Consulta Disponibilidad de Material en Sap
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO3")

            Try
                item = oBLConsultaMssap.ConsultarSerie(codImei)

            Catch

                RegisterStartupScript("script", "<script> alert('LA SERIE NO SE ENCUENTRA REGISTRADA');</script>")
                hidResponse.Value = "Error"
                Exit Sub
            End Try


            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO4")
            'item = oConsultarSap.ConsultarMaterial(codImei)'--dga

            'Consulta Equipo Bloqueado
            Dim objVentaExpress As New VentaExpressNegocios
            Dim intValidarBloqueo As Integer = 0
            Dim booBoqueo As Boolean = False
            Dim strDescrResp As String = ""
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO5")
            Dim switchSimlock As String = ConfigurationSettings.AppSettings("switchSIMLOCK")
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO6")
            Dim strSimLock As String = "", strCodError As String = "", strMsgError As String = ""

            Dim oPuntoVenta As PuntoVenta
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO7")
            oPuntoVenta = CType(Session("PuntoVentaSelected"), PuntoVenta)
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO8")
            Dim strCanal As String = oPuntoVenta.TOFIC_CODIGO
            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO9")


            'INICIO|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados

            Dim CodRed As String
            CodRed = CurrentUser
            Dim Cod_respuesta As Integer
            Dim msj_respuesta As String = ""
            Dim cod_desbloqueo As String = ""
            Dim strCodimei As String = codImei
            If (strCodimei.Length > 15) Then
                strCodimei = strCodimei.Substring(strCodimei.Length - 15, 15)
            End If
            
            oLog.Log_WriteLog(strArchivo, "INICIO|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados")

            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Inicio Método: consultarImeiBloqueado|Url: " + ConfigurationSettings.AppSettings("ConstConsultaImeiBloqueado_Url"))
            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Método: consultarImeiBloqueado|[INPUT].[Usuario Aplicación]: " + CodRed)
            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Método: consultarImeiBloqueado|[INPUT].[Serie IMEI]: " + strCodimei)

            intValidarBloqueo = (New Claro.SisAct.Negocios.BWConsultarImeiBloqueado).ConsultarImeiBloqueado(CodRed, strCodimei, Cod_respuesta, msj_respuesta, cod_desbloqueo)

            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Método: consultarImeiBloqueado|[OUTPUT].[Código de Respuesta]: " + String.Format("{0}", Cod_respuesta))
            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Método: consultarImeiBloqueado|[OUTPUT].[Mensaje de Respuesta]: " + msj_respuesta)
            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Método: consultarImeiBloqueado|[OUTPUT].[Código de Desbloqueo]: " + cod_desbloqueo)
            oLog.Log_WriteLog(strArchivo, "PROY-27029 - IDEA-29524 - Venta fluida de equipos desbloqueados|Fin Método: consultarImeiBloqueado")

            If intValidarBloqueo < 1 Then
                ' PROY 27029 - Venta Fluida de equipos desbloqueados  

                If (Cod_respuesta = 0) Then
                    If (cod_desbloqueo <> "") Then
                        RegisterStartupScript("script", "<script> alert(' " & ConfigurationSettings.AppSettings("MsgVerifEquipoBloqueo") & ". Codigo Desbloqueo: " & cod_desbloqueo.ToString() & "');</script>")
                        oLog.Log_WriteLog(strArchivo, " - " & "PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados|ALERTA : " + ConfigurationSettings.AppSettings("MsgVerifEquipoBloqueo") & ". Codigo Desbloqueo: " & cod_desbloqueo.ToString())
                    End If
                    Else
                    oLog.Log_WriteLog(strArchivo, " - " & "Canal de venta : " + strCanal)
                        If strCanal <> "02" Then
                            hidResponse.Value = "Error"
                        RegisterStartupScript("script", "<script> alert(' " & ConfigurationSettings.AppSettings("MsgErrorEquipoBloqueo") & "');</script>")
                        oLog.Log_WriteLog(strArchivo, " - " & "PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados|ALERTA : " + ConfigurationSettings.AppSettings("MsgErrorEquipoBloqueo").ToString())
                        oLog.Log_WriteLog(strArchivo, "FIN|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados")
                        Exit Sub
                        Else
                            RegisterStartupScript("script", "<script> alert('" & ConfigurationSettings.AppSettings("MsgVerifEquipoBloqueo") & "');</script>")
                        oLog.Log_WriteLog(strArchivo, " - " & "PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados|ALERTA : " + ConfigurationSettings.AppSettings("MsgVerifEquipoBloqueo").ToString())
                        End If

                    End If
                Else
                Dim strCodRpta As String
                strCodRpta = ConfigurationSettings.AppSettings("consCodigoRespuestaConsultarImei")
                hidResponse.Value = "Error"

                If (Cod_respuesta = Convert.ToInt32(strCodRpta.Split("|"c)(0)) Or Cod_respuesta = Convert.ToInt32(strCodRpta.Split("|"c)(1))) Then
                    RegisterStartupScript("script", "<script> alert(' " & ConfigurationSettings.AppSettings("consMensajeAlertaErrorBD") & "');</script>")
                    oLog.Log_WriteLog(strArchivo, " - " & "PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados|ALERTA : " + ConfigurationSettings.AppSettings("consMensajeAlertaErrorBD"))
                    'Exit Sub
                Else
                    RegisterStartupScript("script", "<script> alert(' " & ConfigurationSettings.AppSettings("consMensajeAlertaErrorWS") & "');</script>")
                    oLog.Log_WriteLog(strArchivo, " - " & "PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados|ALERTA : " + ConfigurationSettings.AppSettings("consMensajeAlertaErrorWS"))
                    'Exit Sub
                End If

                oLog.Log_WriteLog(strArchivo, "FIN|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados")
                Exit Sub

            End If

            oLog.Log_WriteLog(strArchivo, "FIN|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados")

            'FIN|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados

            Try

                'consolidado 14122014
                Dim oMensaje As String
                Dim ofi As New ConsultaMsSapNegocio
                Dim oPar As New BEParametroOficina
                Dim codSinergia As String
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO15")
                'Consulta Disponibilidad de Material en Sap
                'item = oConsultarSap.ConsultarMaterial(codImei)'-dga
                item = oBLConsultaMssap.ConsultarSerie(codImei)
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO16")
                'Validar que codigo material de Imei nunca comience con "PS"
                'If item.Codigo = "" Or item.Codigo.StartsWith("PS") '--dga
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO17")

                '05102015
                oPar = ofi.ConsultaParametrosOficina(hidOfVentaCod.Value, "")
                item1 = oBLConsultaMssap.ConsultarSerieXPDV(oPar.cPuntoVentaSinergia, String.Empty)

                If strCanal <> CheckStr(ConfigurationSettings.AppSettings("constCodTipoCRN")) Then
                If item1.CodInterlocutorPadre <> item.CodInterlocutor Then
                    oMensaje = "No existen series para el punto de venta."
                    Throw New Exception(oMensaje)
                End If
                End If
                '05102015

                If item.Codigo = "" Or item.Tipo <> ConfigurationSettings.AppSettings("consGrupoEquipo") Then
                    Throw New Exception("Numero de Serie ingresado no pertenece a un IMEI.")
                End If

                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO18")
                If item.estado <> ConfigurationSettings.AppSettings("ConsLiberarSerieMaterial") Then
                    oMensaje = "Numero de Serie no se encuentra disponible"
                    Throw New Exception(oMensaje)
                End If
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO19")
                If usoHLR = "RP" Then
                    strTipoOperacion = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")
                End If

                ''////// IMEI CONSULTA ESTADO EN SISCAD ///////

                '01092015

                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO20")


                '01092015 oBLConsultaMssap
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO21")
                If strCanal = CheckStr(ConfigurationSettings.AppSettings("constCodTipoCRN")) Then
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO22")
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO26" & CheckStr(hidOfVentaCod.Value))
                    oPar = ofi.ConsultaParametrosOficina(hidOfVentaCod.Value, "")
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO26")
                    codSinergia = oPar.cPuntoVentaSinergia
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO27")
                    oLog.Log_WriteLog(strArchivo, " - " & "codSinergia ......" & CheckStr(codSinergia))
                    OBJPTOVENTA = oConsulta.ObtenerDatosOficinaventa(codSinergia)


                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO23")
                    If (CheckStr(OBJPTOVENTA.OVENV_DESCRIPCION) <> "") Then
                        oLog.Log_WriteLog(strArchivo, " - " & "INGRESO24")
                        Dim canalcorner As String = ConfigurationSettings.AppSettings("CacCorner")
                        Dim estadomaterial As String = ConfigurationSettings.AppSettings("EstadoMaterial")
                        Dim estado_materialBD As String
                        oLog.Log_WriteLog(strArchivo, " - " & "INGRESO25")
                        'oLog.Log_WriteLog(strArchivo, " - " & "codSinergia ------  : " & CheckStr(codSinergia))
                        If (Me.hidCanal.Value = canalcorner) Then
                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO28")

                            'Poner codigo aqui
                            'INICIO WHZR 555
                            'If (ValidaBloqueoPDV()) Then
                            'RegisterStartupScript("script", "<script>alert('El Punto de Venta se encuentra bloqueado');</script>")
                            'Exit Sub
                            'End If
                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO29")

                        'FIN WHZR 555
                            estado_materialBD = oConsulta.ObtenerEstMat(codImei.Substring(3), item.Codigo, codSinergia)
                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO30")

                            If (estadomaterial <> estado_materialBD) Then
                                RegisterStartupScript("script", "<script> alert('El equipo no se encuentra disponible para la renovación.');</script>")
                                hidResponse.Value = "Error"
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                '/////////////////////////////////////////////
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO31")

                'Dim listaMaterial As ArrayList = oConsultarSap.Get_ObtenerMaterialesPDV(strTipoOperacion, "", "", Oficina, strTipoVenta)'--dga
                Dim listaMaterial As ArrayList = oBLConsultaMssap.ConsultaMaterialXOficina(Oficina, "", "", "", "") '--dga
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO32")

                Dim blnFound As Boolean = False

                'Si el Chip no pertenece al punto de venta  
                If listaMaterial.Count = 0 Then
                    If usoHLR = "RP" Then
                        Throw New Exception("El Equipo no pertenece al punto de venta.")
                    End If
                End If



                'consolidado 14122014



                hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion
                hidMsg.Value = String.Empty '"Serie Equipo correcto."
                hidResponse.Value = "RetornarDatos"

            Catch ex As Exception
                hidMsg.Value = "Error 1. " & ex.Message
                oLog.Log_WriteLog(strArchivo, " - " & "Error de Validacion Imei  : " & CheckStr(hidMsg.Value))
                hidResponse.Value = "Error"
            End Try
        End If
    End Sub

    'INICIO WHZR
    Private Function ValidaBloqueoPDV() As Boolean
        Dim blnEstadoBloqueo As Boolean = False
        Dim objoficinaventa As New PuntoVenta
        Dim objofventanegocios As New VentaExpressNegocios

        Try
            objoficinaventa = objofventanegocios.ListaOficinaVentaxID(hidOfVentaCod.Value)

            If objoficinaventa.OVENC_CODIGO = "0" Then
                blnEstadoBloqueo = True
            End If
        Catch ex As Exception
            blnEstadoBloqueo = True
            oLog.Log_WriteLog(strArchivo, " - " & "ValidaBloqueoPDV  : " & ex.Message)
        End Try

        Return blnEstadoBloqueo
    End Function

    'FIN WHZR
End Class
