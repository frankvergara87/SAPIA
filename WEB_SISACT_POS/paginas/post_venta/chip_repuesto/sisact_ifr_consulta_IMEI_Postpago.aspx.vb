Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO
Public Class sisact_ifr_consulta_IMEI_Postpago
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents hidCodIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
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
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_consulta_iccid")

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
            End If
        End If
    End Sub

    Private Sub Inicio()
        hidCodIccid.Value = Request.QueryString("codIccid")
        hidNroLinea.Value = Request.QueryString("nroLinea")
        Dim tipoVenta As String = Request.QueryString("tipoVenta")
        Dim strMetodoRetorno As String = "RetornarDatos"

        'Se valida el parametro. Indica que es una consulta Chip Repuesto Postpago CAC/DAC
        If Not Request.QueryString("canalVenta") Is Nothing Then

            Dim strCanalVenta As String = Request.QueryString("canalVenta")
            Dim strCodOfVenta As String = Request.QueryString("codOfVenta")

            Select Case strCanalVenta
                Case ConfigurationSettings.AppSettings("constCodTipoCAC")
                    'Se cargará el combo con los ICCID
                    Dim strCombo As String = CargaIMEI(hidCodIccid.Value, hidNroLinea.Value, strCodOfVenta, tipoVenta)
                    hidDatosRetorno.Value = strCombo
                    hidResponse.Value = "RetornarDatosCAC"
                    Exit Sub

                Case ConfigurationSettings.AppSettings("CacCorner")
                    'Valida si es CORNER
                    If strCanalVenta.Equals(ConfigurationSettings.AppSettings("CacCorner")) Then
                        'Se valida el bloqueo PDV
                        If (ValidaBloqueoPDV(strCodOfVenta)) Then
                            hidMsg.Value = "Error. El Punto de Venta se encuentra bloqueado"
                            Exit Sub
                        End If

                        'Se valida el estado del material
                        If Not ValidaMaterial(hidCodIccid.Value, strCodOfVenta) Then
                            hidMsg.Value = "Error. El material no se encuentra disponible para la reposición."
                            Exit Sub
                        End If
                    End If
            End Select
        End If

        'Se busca el ICCID
        BuscarIccid()
    End Sub

    Private Sub BuscarIccid()
        Dim codIccid As String = hidCodIccid.Value
        Dim nroLinea As String = hidNroLinea.Value

        If codIccid <> "" Then
            Dim item As New ItemGenerico
            Dim oConsultaSap As New SapGeneralNegocios
            Try
                item = oConsultaSap.ConsultarMaterial(codIccid)
                'Validar que codigo material de Iccid siempre comience con "PS"
                If Not item.Codigo.StartsWith("PS") Then
                    Throw New Exception("Numero de Serie ingresado no pertenece a un IMEI.")
                End If

                ' Verificar HLR
                Dim oVentaNegocios As New VentaNegocios
                Dim Msisdn As String = "51" & nroLinea.Trim()
                Dim strHLR As String = oVentaNegocios.ObtenerNroHLR(Msisdn)
                Dim intcodParamHLRS_Digito As Integer = CheckInt(ConfigurationSettings.AppSettings("consHLRREPO_SEGDIGITO"))

                Dim valoresHLR As String = CType((New MaestroNegocio).ListaParametros(intcodParamHLRS_Digito)(0), Parametro).Valor
                Dim valorhlr As Boolean = False
                Dim arravalor As String() = valoresHLR.Split(","c)

                If strHLR <> "" Then
                    strHLR = Right("00" & strHLR, 2)
                    'If (ConfigurationSettings.AppSettings("FLAG_Hlr") = "01") Then ' Inicio llave agregada FDQ
                        If Not codIccid.Substring(6, 2) = strHLR Then
                            For i As Integer = 0 To arravalor.Length
                                If arravalor(i) = strHLR Then
                                    valorhlr = True
                                    Exit For
                                End If
                            Next
                        'If Not valorhlr Then
                        '    Throw New Exception("El telefono " & nroLinea.Trim() & " pertenece al HLR " & CheckStr(strHLR) & Chr(13) & "El ICCID " & codIccid & " pertenece al HLR " & codIccid.Substring(6, 2) & " (Posicion 7 y 8 del ICCID)")
                        '    Exit Sub
                        'End If
                        End If
                    'Else
                    '    oLog.Log_WriteLog(strArchivo, "registro no ingresa por el FLAG HLR de sisact_ifr_consulta_IMEI_Postpago")
                    '    'fin
                    'End If ' Fin llave agregada FDQ
                Else
                    Throw New Exception("No existe HLR para el telefono.")
                End If

                'hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion
                Dim msgValidarIccid As String = validarIccid4G(item.Codigo)
                hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion & "," & msgValidarIccid
                hidResponse.Value = "RetornarDatos"
            Catch ex As Exception
                hidMsg.Value = "Error. " & ex.Message
            Finally
                item = Nothing
                oConsultaSap = Nothing
            End Try
        End If
    End Sub

    Private Function validarIccid4G(ByVal iccid As String) As String
        Dim consCodParamChip4G As String = CheckStr(ConfigurationSettings.AppSettings("consCodParamChip4G"))
        Dim listaParametros As String
        Dim arrayListaParametro As ArrayList = New ConsumerNegocio().ListarParametroGeneral("1")
        For Each oItem As ParametroConsumer In arrayListaParametro
            If (oItem.PCONI_CODIGO.Equals(consCodParamChip4G)) Then
                Dim arrayChips() As String = oItem.PCONV_VALOR.Split(CChar("|"))
                For Each oChip As String In arrayChips
                    If (iccid.StartsWith(oChip)) Then
                        Return CheckStr(ConfigurationSettings.AppSettings("consTextoAlertaChip4G"))
                    End If
                Next
            End If
        Next
        Return String.Empty
    End Function

    Private Function ValidaBloqueoPDV(ByVal codOfVenta As String) As Boolean
        Dim blnEstadoBloqueo As Boolean = False
        Dim objoficinaventa As New PuntoVenta
        Dim objofventanegocios As New VentaExpressNegocios

        Try
            objoficinaventa = objofventanegocios.ListaOficinaVentaxID(codOfVenta)

            If objoficinaventa.OVENC_ESTADO = "0" Then
                blnEstadoBloqueo = True
            End If
        Catch ex As Exception
            blnEstadoBloqueo = True
        End Try

        Return blnEstadoBloqueo
    End Function

    Private Function ValidaMaterial(ByVal codICCID As String, ByVal codOfVenta As String) As Boolean
        'Consulta Disponibilidad de Material en Sap
        Dim oConsultarSap As New SapGeneralNegocios
        Dim objofventanegocios As New VentaExpressNegocios
        Dim blnValidaMaterial As Boolean = True

        Dim item As New ItemGenerico
        item = oConsultarSap.ConsultarMaterial(codICCID)

        Dim estadomaterial As String = ConfigurationSettings.AppSettings("EstadoMaterial")

        Dim estado_materialBD As String = objofventanegocios.ObtenerEstMat(codICCID, item.Codigo, codOfVenta)

        oLog.Log_WriteLog(strArchivo, " - " & "Valida el material")
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material    : " & estadomaterial)
        oLog.Log_WriteLog(strArchivo, " - " & "Estado del material BD : " & estado_materialBD)

        If (estadomaterial <> estado_materialBD) Then
            oLog.Log_WriteLog(strArchivo, " - " & "**Los materiales son diferentes")
            blnValidaMaterial = False
        End If

        Return blnValidaMaterial

    End Function

    Public Function CargaIMEI(ByVal strMaterial As String, ByVal strNroTelef As String, ByVal strPuntoVenta As String, ByVal strTipoVenta As String) As String

        Dim strCombo As String = ""
        Dim oBLConsultaMssap As New BLConsultaMssap '--dga
        Try
            Dim lista As ArrayList
            Dim oSapNegocios As New SapGeneralNegocios

            lista = oBLConsultaMssap.ConsultarSerieMaterial(strPuntoVenta, Nothing, "", "", strMaterial, Nothing, "") '--dga

            'Dim oConsultaMSS As New ConsultaMsSapNegocio'--dga
            'Dim iCantidad As Integer = CheckInt(ConfigurationSettings.AppSettings("ConsTopSeries"))'--dga
            'lista = oSapNegocios.get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef)

            'lista = oConsultaMSS.ConsultarSerieMaterial(strPuntoVenta, "", "", iCantidad, strMaterial, strTipoVenta)'--dga

            If lista.Count > 0 Then
                strCombo = "<select id=cboICCIDArt name=cboIMEIArt class=clsSelectEnable onChange=selectedIMEI(this.value) style='width:200px'>"
                strCombo &= "<option value='0000000000'>" & ConfigurationSettings.AppSettings("Seleccionar") & "</option>"

                For i As Integer = 0 To lista.Count - 1
                    Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
                    strCombo = strCombo & "<option value='" & item.Codigo & "'>" & item.Codigo & "</option>"
                Next
                strCombo &= "</select>"
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, " - " & "Error Cargar IMEI : " & ex.Message)
            hidMsg.Value = "Error. " & ex.Message
        End Try

        Return strCombo

    End Function

End Class
