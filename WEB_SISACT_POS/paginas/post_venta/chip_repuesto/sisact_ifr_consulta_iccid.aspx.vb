Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_iccid
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
    Protected WithEvents hidRespuestaChip As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoRenov As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTLE As System.Web.UI.HtmlControls.HtmlInputHidden


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
        hidRespuestaChip.Value = Request.QueryString("RespuestaChip")
        hidEstadoRenov.Value = Request.QueryString("EstRenov")
        Dim strCanalVenta As String = Request.QueryString("canalVenta")
        Dim strCodOfVenta As String = Request.QueryString("codOfVenta")

        Dim strMetodoRetorno As String = "RetornarDatos"

        'Se valida el parametro. Indica que es una consulta Chip Repuesto Postpago CAC/DAC
        If Not Request.QueryString("canalVenta") Is Nothing Then

           
            Select Case strCanalVenta
                Case ConfigurationSettings.AppSettings("constCodTipoCAC")
                    'Se cargará el combo con los ICCID
                    Dim strCombo As String = CargaICCID(hidCodIccid.Value, hidNroLinea.Value, strCodOfVenta)
                    hidDatosRetorno.Value = strCombo
                    hidResponse.Value = "RetornarDatosCAC"
                    Exit Sub

                    'Case ConfigurationSettings.AppSettings("CacCorner")
                    '    'Valida si es CORNER
                    '    If strCanalVenta.Equals(ConfigurationSettings.AppSettings("CacCorner")) Then
                    '        'Se valida el bloqueo PDV
                    '        'If (ValidaBloqueoPDV(strCodOfVenta)) Then
                    '        '    hidMsg.Value = "Error. El Punto de Venta se encuentra bloqueado"
                    '        '    Exit Sub
                    '        'End If

                    '        ''Se valida el estado del material
                    '        'If Not ValidaMaterial(hidCodIccid.Value, strCodOfVenta) Then
                    '        '    hidMsg.Value = "Error. El material no se encuentra disponible para la reposición."
                    '        '    Exit Sub
                    '        'End If

                    '    End If
            End Select
        End If
        oLog.Log_WriteLog(strArchivo, " - " & "ENTRA CHIP")
        'Se busca el ICCID
        BuscarIccid(strCanalVenta, strCodOfVenta)
        oLog.Log_WriteLog(strArchivo, " - " & "SALE CHIP")
    End Sub
	'Inicio Nuevo HLR - UDB - MVC
    Private Sub BuscarIccid(ByVal strCanal As String, ByVal codOfVenta As String)
        oLog.Log_WriteLog(strArchivo, "ingresa al metodo BuscarIccid de sisact_ifr_consulta_iccid postventa")
        Dim codIccid As String = hidCodIccid.Value
        Dim nroLinea As String = hidNroLinea.Value
        oLog.Log_WriteLog(strArchivo, " - " & "VALIDA CHIP")
        If codIccid <> "" Then
            Dim item As New ItemGenerico
            Dim oBLConsultaMssap As New BLConsultaMssap
            Dim oMensaje As String
            Dim ofi As New ConsultaMsSapNegocio
            Dim oPar As New BEParametroOficina
            Dim codSinergia As String
            Dim oConsulta As New VentaExpressNegocios
            Dim item1 As New ItemGenerico
            Dim OBJPTOVENTA As PuntoVenta

            Try

                Dim listaMaterialRepo As New ArrayList
                Dim codParam As String = ConfigurationSettings.AppSettings("consCodParamMaterialesCAC")
                listaMaterialRepo = New ConsumerNegocio().ListarParametroGeneral(codParam)
                Dim repu As Boolean = False



                oLog.Log_WriteLog(strArchivo, " - " & "VALIDA LTE")
                Dim lte As String = codIccid.Trim().Substring(5, 2)
                If (CheckStr(lte) <> "01") Then

                    hidTLE.Value = CheckStr(ConfigurationSettings.AppSettings("consTextoChip3G"))

                Else
                    hidTLE.Value = CheckStr(ConfigurationSettings.AppSettings("consTextoChip4G"))

                End If

                'PROY 28949 inicio DMZ - VAlidacion de tecnologia 3g o 4g de dac y cadenas RF02 renovacion postpago

                oLog.Log_WriteLog(strArchivo, "BuscarIccId - INICIO Validacion de Tecnologia 4G")
                Dim strMensajesVal4G As String = String.Empty
                Dim CodigoParamValidarChip4G As Int64 = CheckInt64(ConfigurationSettings.AppSettings("CodigoParamValidarChip4G"))
                oLog.Log_WriteLog(strArchivo, "BuscarIccId - CodigoParamValidarChip4G : " + CheckStr(CodigoParamValidarChip4G))
                Dim strCodIccid As String = codIccid.Trim()
                Dim tecnoChip As String = CheckStr(strCodIccid.Substring(6, 1)) 
                
                oLog.Log_WriteLog(strArchivo, "BuscarIccId - iccid : " + CheckStr(tecnoChip))

                If tecnoChip <> "1" Then
                    Dim arrMensajes As ArrayList = New MaestroNegocio().ListaParametrosGrupo(CodigoParamValidarChip4G)
                    oLog.Log_WriteLog(strArchivo, "BuscarIccId - arrMensajes : " + CheckStr(arrMensajes.Count()))
                    For Each item4G As Parametro In arrMensajes
                        If item4G.Valor1 = "1" Then
                            strMensajesVal4G = CheckStr(item4G.Valor)
                            Exit For
                        End If
                    Next
                    oLog.Log_WriteLog(strArchivo, "BuscarIccId - strMensajesVal4G : " + strMensajesVal4G)

                    hidMsg.Value = strMensajesVal4G
                    hidResponse.Value = "Validar4G"
                    Exit Sub
                    'Throw New Exception(strMensajesVal4G)
                End If
                oLog.Log_WriteLog(strArchivo, "BuscarIccId - FIN Validacion de Tecnologia 4G")

                'PROY 28949 FIN DMZ - VAlidacion de tecnologia 3g o 4g de renovacio con autonomia

                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO3")
                Try
                    item = oBLConsultaMssap.ConsultarSerie(codIccid)

                Catch
                    Throw New Exception("LA SERIE NO SE ENCUENTRA REGISTRADA")
                End Try


                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO4")

                oLog.Log_WriteLog(strArchivo, " - " & "material" & CheckStr(item.Codigo))
                oLog.Log_WriteLog(strArchivo, " - " & "serie" & CheckStr(codIccid))
                oLog.Log_WriteLog(strArchivo, " - " & "tipo" & CheckStr(item.Tipo))
                oLog.Log_WriteLog(strArchivo, " - " & "estado" & CheckStr(item.estado))
                oLog.Log_WriteLog(strArchivo, " - " & "oficina" & CheckStr(codOfVenta))

                Try
                    oPar = ofi.ConsultaParametrosOficina(codOfVenta, "")
                Catch
                    Throw New Exception("LA OFICINA NO SE ENCUENTRA")
                End Try
                Try
                    item1 = oBLConsultaMssap.ConsultarSerieXPDV(oPar.cPuntoVentaSinergia, String.Empty)
                Catch
                    Throw New Exception("LA SERIE NO SE ENCUENTRA EN EL PUNTO VENTA")
                End Try

                oLog.Log_WriteLog(strArchivo, " - " & "oficina sinergia" & CheckStr(oPar.cPuntoVentaSinergia))

                'descomentar para qa
                If strCanal <> CheckStr(ConfigurationSettings.AppSettings("constCodTipoCRN")) Then
                    If item1.CodInterlocutorPadre <> item.CodInterlocutor Then
                        oMensaje = "No existen series para el punto de venta."
                        Throw New Exception(oMensaje)
                    End If
                End If
                '05102015

                If item.Codigo = "" Or item.Tipo <> ConfigurationSettings.AppSettings("consGrupoChip") Then
                    Throw New Exception("Numero de Serie ingresado no pertenece a un ICCID.")
                End If

                For Each id As ParametroConsumer In listaMaterialRepo
                    oLog.Log_WriteLog(strArchivo, " - " & "materiales de chip" & CheckStr(id.PCONV_VALOR))
                    If CheckStr(id.PCONV_VALOR) = CheckStr(item.Codigo) Then
                        repu = True
                    End If
                Next

                oLog.Log_WriteLog(strArchivo, " - " & "material no es repu" & CheckStr(repu))
                If repu = False Then
                    Throw New Exception("Numero de Serie ingresado no pertenece a un CHIP REPUESTO.")
                End If



                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO18")
                If item.estado <> ConfigurationSettings.AppSettings("ConsLiberarSerieMaterial") Then
                    oMensaje = "Numero de Serie no se encuentra disponible"
                    Throw New Exception(oMensaje)
                End If
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO19")
                'If usoHLR = "RP" Then
                '    strTipoOperacion = ConfigurationSettings.AppSettings("constCodOperRenovacionLP")
                'End If

                ''////// IMEI CONSULTA ESTADO EN SISCAD ///////

                '01092015

                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO20")


                '01092015 oBLConsultaMssap
                oLog.Log_WriteLog(strArchivo, " - " & "INGRESO21")
                If strCanal = CheckStr(ConfigurationSettings.AppSettings("constCodTipoCRN")) Then
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO22")
                    oLog.Log_WriteLog(strArchivo, " - " & "INGRESO26" & CheckStr(codOfVenta))
                    oPar = ofi.ConsultaParametrosOficina(codOfVenta, "")
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
                        If (strCanal = canalcorner) Then
                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO28")

                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO29")

                            'FIN WHZR 555
                            estado_materialBD = oConsulta.ObtenerEstMat(codIccid, item.Codigo, codSinergia)
                            oLog.Log_WriteLog(strArchivo, " - " & "INGRESO30")

                        
                            oLog.Log_WriteLog(strArchivo, " - " & "estado cadena" & CheckStr(estado_materialBD))
                            oLog.Log_WriteLog(strArchivo, " - " & "estado serie" & CheckStr(estadomaterial))

                            If (estado_materialBD <> estadomaterial) Then
                                RegisterStartupScript("script", "<script> alert('El chip no se encuentra disponible para la renovación.');</script>")
                                hidResponse.Value = "Error"
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                ' Verificar HLR
                Dim oVentaNegocios As New VentaNegocios
                Dim Msisdn As String = "51" & nroLinea.Trim()
                Dim strHLR As String = Request.QueryString("HLR")

                oLog.Log_WriteLog(strArchivo, " - " & "hlr" & CheckStr(strHLR))
                If strHLR <> "" Then
                    If strHLR.Length = 2 Then
                        strHLR = Right("00" & strHLR.Substring(1), 2)
                    Else
                        strHLR = Right("00" & strHLR, 2)
                    End If


                    Dim nUDB As Integer = CheckInt(ConfigurationSettings.AppSettings("Nuevo_Hlr"))
                    Dim nHLRiccid As Integer = CheckInt(Trim(codIccid.Substring(7, 1)))
                    oLog.Log_WriteLog(strArchivo, " - " & "hrl chip" & CheckStr(nHLRiccid))
                    Dim oListaHLR As ArrayList = oConsulta.ListarEquivalenciaHLRyUDB(0, nHLRiccid)

                    If oListaHLR.Count > 0 Then

                        If Not CheckInt(CType(oListaHLR(0), ItemGenerico).Codigo2) = CheckInt(nUDB) Then

                            oLog.Log_WriteLog(strArchivo, "Codigo 2 : " & CType(oListaHLR(0), ItemGenerico).Codigo2)
                            oLog.Log_WriteLog(strArchivo, "nUDB : " & nUDB)

                            If Not CheckInt(CType(oListaHLR(0), ItemGenerico).Codigo) = CheckInt(strHLR) Then
                                oLog.Log_WriteLog(strArchivo, "Codigo: " & CType(oListaHLR(0), ItemGenerico).Codigo)
                                oLog.Log_WriteLog(strArchivo, "strHLR : " & strHLR)

                                Throw New Exception("El telefono " & nroLinea.Trim() & " pertenece al HLR " & CStr(strHLR) & Chr(13) & "El ICCID " & codIccid & " pertenece al HLR " & CheckStr(nHLRiccid) & " (Posicion 8 del ICCID)")
                            Exit Sub

                            End If
                        End If

                    End If
                    
                Else
                    Throw New Exception("No existe HLR para el telefono.")

                End If

                'hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion
                Dim msgValidarIccid As String = ""
                hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion & "," & msgValidarIccid
                hidResponse.Value = "RetornarDatos"
            Catch ex As Exception
                hidMsg.Value = "Error. " & ex.Message
                oLog.Log_WriteLog(strArchivo, " - " & "Error de Validacion Iccid  : " & CheckStr(hidMsg.Value))
                hidResponse.Value = "Error"
            Finally
                item = Nothing

            End Try
        End If
        oLog.Log_WriteLog(strArchivo, "sale de BuscarIccid de sisact_ifr_consulta_iccid postventa")
    End Sub
	'Fin Nuevo HLR - UDB - MVC

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

    Public Function CargaICCID(ByVal strMaterial As String, ByVal strNroTelef As String, ByVal strPuntoVenta As String) As String
        oLog.Log_WriteLog(strArchivo, "ingreso al metodo cargarIccid de sisact_ifr_consulta_iccid postventa")

        Dim strCombo As String = ""
        Dim oBLConsultaMssap As New BLConsultaMssap '--dga
        Dim strHLR As String = Request.QueryString("HLR")
        Dim oVentaExpressDatos As New VentaNegocios
        Dim oVentaExpress As New VentaExpressNegocios

        Try

            Dim lista As ArrayList
            Dim listafinal As New ArrayList
            Dim oSapNegocios As New SapGeneralNegocios
            'lista = oSapNegocios.get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef)
            oLog.Log_WriteLog(strArchivo, "CargaICCID ConsultarSerieMaterial strPuntoVenta INP:" & strPuntoVenta)
            oLog.Log_WriteLog(strArchivo, "CargaICCID ConsultarSerieMaterial strMaterial INP:" & strMaterial)
            lista = oBLConsultaMssap.ConsultarSerieMaterial(strPuntoVenta, Nothing, "", "", strMaterial, Nothing, "")
            oLog.Log_WriteLog(strArchivo, "CargaICCID lista.Count RES:" & CheckStr(lista.Count))


            Dim Msisdn As String = "51" & strNroTelef.Trim()
            Dim nHLR_Telefono As Integer = CheckInt(oVentaExpressDatos.ObtenerNroHLR(Msisdn))
         
            Dim nUDB As Integer = CheckInt(ConfigurationSettings.AppSettings("Nuevo_Hlr"))

            If lista.Count > 0 Then

                For i As Integer = 0 To 1
                    Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
                    Dim lte As String = item.Codigo.Trim().Substring(5, 2)
                    If (CheckStr(lte) <> "01") Then

                        hidTLE.Value = CheckStr(ConfigurationSettings.AppSettings("consTextoChip3G"))

                    Else
                        hidTLE.Value = CheckStr(ConfigurationSettings.AppSettings("consTextoChip4G"))

                    End If

                Next

                'Inicio Nuevo HLR - UDB

                oLog.Log_WriteLog(strArchivo, "CargaICCID Inicio Filtro Materiales HLR - UDB")


                Dim bNoIncluyeMaterial As Boolean = False

                For i As Integer = 0 To lista.Count - 1
                    Dim item As ItemGenerico = CType(lista(i), ItemGenerico)

                    'Dim strHLRiccid As String = "0" + item.Codigo.Substring(7, 1)
                    Dim nHLRiccid As Integer = CheckInt(item.Codigo.Substring(7, 1))

                    Dim oListaHLR As ArrayList = oVentaExpress.ListarEquivalenciaHLRyUDB(nHLR_Telefono, 0)

                    If nHLR_Telefono = nUDB Then

                        For Each oItem As ItemGenerico In oListaHLR

                            If nHLRiccid = CheckInt(oItem.Codigo) Then
                                'bNoIncluyeMaterial = True
                            listafinal.Add(item)

                        End If
                        Next
                    Else

                        If nHLRiccid = nHLR_Telefono Then
                            'bNoIncluyeMaterial = True
                        listafinal.Add(item)

                        End If

                    End If

                Next
                'Fin Nuevo HLR - UDB
                oLog.Log_WriteLog(strArchivo, "CargaICCID Fin Filtro Materiales HLR - UDB")
                oLog.Log_WriteLog(strArchivo, "CargaICCID listalistafinal.Count" & CheckStr(listafinal.Count))

                oLog.Log_WriteLog(strArchivo, "ingreso por el FLAG HLR de sisact_ifr_consulta_iccid postventa")

                If listafinal.Count > 0 Then
                    strCombo = "<select id=cboICCIDChip name=cboICCIDChip class=clsSelectEnable onChange=selectedICCID(this.value) style='width:200px'>"
                    strCombo &= "<option value='0000000000'>" & ConfigurationSettings.AppSettings("Seleccionar") & "</option>"

                    For i As Integer = 0 To listafinal.Count - 1
                        Dim item As ItemGenerico = CType(listafinal(i), ItemGenerico)
                        strCombo = strCombo & "<option value='" & item.Codigo & "'>" & item.Codigo & "</option>"
                    Next
                    strCombo &= "</select>"
                End If

            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, " - " & "Error Cargar ICCID : " & ex.Message)
            hidMsg.Value = "Error. " & ex.Message
        End Try

        Return strCombo
        oLog.Log_WriteLog(strArchivo, "sale del metodo cargarIccid de sisact_ifr_consulta_iccid postventa")
    End Function

End Class
