Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_precio_
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidConsultaPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRespuestaPrecio As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

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
            Else
                If hidRequest.Value = "ConsultarPrecio" Then
                    ConsultarPrecio()
                End If
            End If

            Dim strScript3 As String = "inicio();"
            RegisterStartupScript("script", "<script>" & strScript3 & "</script>")
        End If
    End Sub

    Private Sub Inicio()
        Dim grabarAudit As String = Request.QueryString("auditoria")
        If grabarAudit <> "" Then
            Dim arrayValores() As String = grabarAudit.Split(CChar(","))
            Dim tipoAudit As String = arrayValores(0)
            Dim nroSec As String = arrayValores(1)
            Dim oficina As String = arrayValores(2)

            Select Case tipoAudit
                Case "CancelarPlan"
                    ' Auditoria
                    Dim serieIccid As String
                    Dim serieImei As String
                    If arrayValores.Length > 3 Then
                        serieIccid = arrayValores(3)
                    End If
                    If arrayValores.Length > 4 Then
                        serieImei = arrayValores(4)
                    End If

                    Dim descTrans As String = "Se realizó evento Cancelar Plan Venta Express. Filtros (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & " | Serie Iccid: " & serieIccid & " | Serie Imei: " & serieImei & ")."
                    AuditoriaCancelarPlan(descTrans)
                Case "CancelarPedido"
                    ' Auditoria
                    Dim descTrans As String = "Se realizó evento Cancelar Pedido Venta Express. Filtros (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & ")."
                    AuditoriaCancelarPedido(descTrans)
            End Select
            Response.End()
            Exit Sub
        End If

        hidConsultaPrecio.Value = Request.QueryString("consultaPlan")
        If hidConsultaPrecio.Value = "" Then
            hidResponse.Value = "ExtraerDatos"
        Else
            ConsultarPrecio()
        End If

    End Sub

    Private Sub ConsultarPrecio()
        Dim dblIccidPrecio As Decimal
        Dim dblIccidDescuento As Decimal
        Dim dblIccidPreIGV As Decimal
        Dim dblIccidTotal As Decimal

        Dim dblImeiPrecio As Decimal
        Dim dblImeiDescuento As Decimal
        Dim dblImeiPreIGV As Decimal
        Dim dblImeiTotal As Decimal

        Dim strConsulta As String = hidConsultaPrecio.Value
        If strConsulta <> "" Then
            Dim arrayValores() As String = strConsulta.Split(CChar(","))
            Dim oConsultarSap As New SapGeneralNegocios
            Dim dsPrecio As New DataSet

            Dim oficina As String = arrayValores(0)
            Dim tipoDocCliente As String = arrayValores(1)
            Dim materialIccid As String = arrayValores(2)
            Dim materialImei As String = arrayValores(3)
            Dim precio As String = arrayValores(4)
            Dim cantidad As Decimal = CDec(arrayValores(5))
            Dim fecha As String = Format(Year(Now.Date), "0000") & "/" & Format(Month(Now.Date), "00") & "/" & Format(Day(Now.Date), "00")
            Dim serieIccid As String = arrayValores(6)
            Dim nroLinea As String = String.Empty
            Dim serieImei As String = arrayValores(8)
            Dim disponibImei As String = arrayValores(9)

            Dim nroSec As String = arrayValores(10)
            Dim tipoSec As String = arrayValores(11).ToUpper()

            Try
                Dim tipoVentaPreRenov As String = ConfigurationSettings.AppSettings("ExpressModoPrepagoRenovacion").ToUpper()
                Dim tipoVentaPos As String = ConfigurationSettings.AppSettings("ExpressModoPostpago").ToUpper()
                Dim tipoVentaPosPort As String = ConfigurationSettings.AppSettings("ExpressModoPostpagoPort").ToUpper()

                If tipoSec.Equals(tipoVentaPos) Then
                    ' Consulta con WS, validacion de ICCID - MSISDN
                    Dim mensajeErrorValida As String
                    Dim timeOut As Integer = CheckInt(ConfigurationSettings.AppSettings("ExpressVentaWsTimeOut"))
                    Dim url1 As String = CheckStr(ConfigurationSettings.AppSettings("ExpressVentaWsUrl_01"))
                    Dim url2 As String = CheckStr(ConfigurationSettings.AppSettings("ExpressVentaWsUrl_02"))

                    nroLinea = arrayValores(7)
                    If nroLinea.Length > 9 Then nroLinea = nroLinea.Substring(nroLinea.Length - 9)
                    Dim validaTelfDisp As Boolean = New VentaExpressNegocios().ValidarIccidMsisdn(nroLinea, serieIccid, timeOut, url1, url2, mensajeErrorValida)
                    If Not validaTelfDisp Then
                        Throw New Exception(mensajeErrorValida)
                    End If
                End If

                Dim dsOficina As New DataSet
                dsOficina = oConsultarSap.ConsultarParametrosOfVenta(oficina)
                Dim canal As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG")))
                Dim orgVenta As String = Trim(CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG")))

                Dim dsClasePedido As New DataSet
                dsClasePedido = oConsultarSap.ConsultarTipoDocumentoOfVenta(oficina)
                Dim tipoDocVenta As String = ""

                Dim consTipoDoc As String = ""
                Select Case tipoSec
                    Case tipoVentaPreRenov
                        consTipoDoc = "ExpressTipoDocVentaPreRen"
                    Case tipoVentaPos, tipoVentaPosPort
                        consTipoDoc = "ExpressTipoDocVentaPos"
                End Select

                Dim arrayTipoDocVenta() As String = ConfigurationSettings.AppSettings(consTipoDoc & tipoDocCliente).Split(CChar(","))
                For Each tipoDocVentaTmp As String In arrayTipoDocVenta
                    If tipoDocVenta <> "" Then
                        Exit For
                    End If
                    For Each rowTmp As System.Data.DataRow In dsClasePedido.Tables(0).Rows
                        If CheckStr(rowTmp.Item("AUART")) = tipoDocVentaTmp Then
                            tipoDocVenta = tipoDocVentaTmp
                            Exit For
                        End If
                    Next
                Next

                Dim usuario_id As String = CurrentUser
                If serieIccid <> "" Then
                    dsPrecio = (New SansNegocio).ConsultarPrecio(oficina, _
                                          "", _
                                          "", _
                                          materialIccid, _
                                          precio, _
                                          cantidad, _
                                          fecha, _
                                          serieIccid, _
                                          nroLinea, _
                                          tipoDocVenta, _
                                          "", _
                                          canal, _
                                          orgVenta, _
                                          disponibImei, _
                                          dblIccidDescuento, _
                                          dblIccidPreIGV, _
                                          dblIccidPrecio, _
                                          dblIccidTotal, _
                                          usuario_id)
                End If
                If serieImei <> "" Then
                    dsPrecio = (New SansNegocio).ConsultarPrecio(oficina, _
                                          "", _
                                          "", _
                                          materialImei, _
                                          precio, _
                                          cantidad, _
                                          fecha, _
                                          serieImei, _
                                          "", _
                                          tipoDocVenta, _
                                          "", _
                                          canal, _
                                          orgVenta, _
                                          "P", _
                                          dblImeiDescuento, _
                                          dblImeiPreIGV, _
                                          dblImeiPrecio, _
                                          dblImeiTotal, _
                                          usuario_id)
                    'nroLinea, _
                    'disponibImei, _
                End If

                Dim precioIccid As String = CheckStr(dblIccidDescuento) & "," & CheckStr(dblIccidPreIGV) & _
                "," & CheckStr(dblIccidPrecio) & "," & CheckStr(dblIccidTotal)

                Dim precioImei As String = CheckStr(dblImeiDescuento) & "," & CheckStr(dblImeiPreIGV) & _
                "," & CheckStr(dblImeiPrecio) & "," & CheckStr(dblImeiTotal)

                hidRespuestaPrecio.Value = precioIccid & "," & precioImei

                hidResponse.Value = "RetornarDatos"

            Catch ex As Exception                
                hidMsg.Value = "Error. El equipo no se encuentra disponible para la renovación"
                hidResponse.Value = "Error"
            End Try

            ' Auditoria
            'Dim descTrans As String = "Se realizó evento Aceptar Plan Venta Express. Filtros (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & " | Serie Iccid: " & serieIccid & " | Serie Imei: " & serieImei & ")."
            'AuditoriaAceptarPlan(descTrans)
        End If
    End Sub

#Region " Auditoria"
    Private Sub AuditoriaAceptarPlan(ByVal descTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strConsulta As String = hidConsultaPrecio.Value
            Dim oficina As String
            Dim serieIccid As String
            Dim serieImei As String
            Dim nroSec As String
            If strConsulta <> "" Then
                Dim arrayValores() As String = strConsulta.Split(CChar(","))

                oficina = arrayValores(0)
                serieIccid = arrayValores(6)
                serieImei = arrayValores(7)
                nroSec = arrayValores(9)
            End If

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressAuditAceptarPlan")

            'Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", descTrans)
            'If Not auditoriaGrabado Then
            '    Throw New Exception("Error. No se registro en Auditoria el Evento Aceptar Plan Venta Express (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & " | Serie Iccid: " & serieIccid & " | Serie Imei: " & serieImei & ").")
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AuditoriaCancelarPlan(ByVal descTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim grabarAudit As String = Request.QueryString("auditoria")

            Dim tipoAudit As String
            Dim oficina As String
            Dim serieIccid As String
            Dim serieImei As String
            Dim nroSec As String

            If grabarAudit <> "" Then
                Dim arrayValores() As String = grabarAudit.Split(CChar(","))

                tipoAudit = arrayValores(0)
                nroSec = arrayValores(1)
                oficina = arrayValores(2)

                If arrayValores.Length > 3 Then
                    serieIccid = arrayValores(3)
                End If
                If arrayValores.Length > 4 Then
                    serieImei = arrayValores(4)
                End If
            End If

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressAuditCancelarPlan")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", descTrans)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria el Evento Cancelar Plan Venta Express (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & " | Serie Iccid: " & serieIccid & " | Serie Imei: " & serieImei & ").")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AuditoriaCancelarPedido(ByVal descTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim grabarAudit As String = Request.QueryString("auditoria")

            Dim tipoAudit As String
            Dim oficina As String
            Dim nroSec As String

            If grabarAudit <> "" Then
                Dim arrayValores() As String = grabarAudit.Split(CChar(","))

                tipoAudit = arrayValores(0)
                nroSec = arrayValores(1)
                oficina = arrayValores(2)
            End If

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressAuditCancelarPedido")

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", descTrans)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria el Evento Cancelar Pedido Venta Express (Nro SEC: " & nroSec & " | Cod Oficina: " & oficina & ").")
            End If
        Catch ex As Exception 
        End Try
    End Sub
#End Region
End Class
