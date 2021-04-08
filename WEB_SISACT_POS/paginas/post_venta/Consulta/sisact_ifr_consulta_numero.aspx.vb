Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO
Public Class sisact_ifr_consulta_numero
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hidCodSerie As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden
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

    Dim objLog As New SISACT_Log
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("Consulta_SisactPrepago")

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
                If hidRequest.Value = "BuscarImei" Then
                    BuscarNumero()
                End If
            End If
            Dim strScript3 As String = "inicio();"
            RegisterStartupScript("script", "<script>" & strScript3 & "</script>")
        End If

    End Sub
    Private Sub Inicio()
        hidCodSerie.Value = Request.QueryString("codSerie")

        If hidCodSerie.Value = "" Then
            hidResponse.Value = "ExtraerDatos"
        Else
            BuscarNumero()
        End If
    End Sub

    Private Sub BuscarNumero()
        Dim _codSerie As String = hidCodSerie.Value
        Dim _respuesta As String
        Dim listado As New ArrayList
        Dim obj As New ConsultaVentaPrepagoNegocios
        Try
            listado = obj.Lis_Lista_Linea_Material(_codSerie, _respuesta)
        Catch ex As Exception
            hidResponse.Value = "Error"
            hidMsg.Value = ex.Message
        End Try


        Dim _datos As String
        If listado.Count > 0 Then
            For Each item As DetalleLineaMaterial In listado
                If _datos = String.Empty Then
                    _datos = item.COD_MATERIAL_CHIP & ";" & item.DES_MATERIAL_CHIP & ";" & item.LINEA
                Else
                    _datos = _datos & "|" & item.COD_MATERIAL_CHIP & ";" & item.DES_MATERIAL_CHIP & ";" & item.LINEA
                End If
            Next
            hidResponse.Value = "RetornarDatos"
            hidDatosRetorno.Value = _datos
        Else
            hidResponse.Value = "Error"
            hidDatosRetorno.Value = ""
        End If

        Try
        Dim descConsulta As String = "Se realizó la consulta de Sisact Prepago. Serie ingresada: " & _codSerie & " - Respuesta: " & _respuesta
        AuditoriaConsultarPedido(descConsulta)
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Error al registrar auditoria   : " & ex.Message)
        End Try



    End Sub

    Private Sub AuditoriaConsultarPedido(ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("ExpressAuditTransConsultaPrepago")

            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Nombre Host    : " & nombreHost)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Nombre Server  : " & nombreServer)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "ipServer       : " & ipServer)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "HostInfo       : " & hostInfo.ToString())
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Usuario_id     : " & usuario_id)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "ipCliente      : " & ipcliente)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Cod Aplica     : " & strCodAplica)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Cod Serv       : " & strCodServ)
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "CodTrans    : " & strCodTrans)

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", desTrans)
            If Not auditoriaGrabado Then
                Throw New Exception("Error. No se registro en Auditoria la Grabacion Pedido de Venta Prepago.")
            End If
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Error : " & ex.Message)
            If hidMsg.Value <> "" Then
                hidMsg.Value = hidMsg.Value & Chr(13) & "Error AuditoriaRealizarPedido. " & ex.Message
            Else
                hidMsg.Value = "Error AuditoriaRealizarPedido. " & ex.Message
            End If
        End Try

        objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "*********************")
        objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "Fin Proceso Auditoria")
        objLog.Log_WriteLog(strArchivo, Me.CurrentUser & " - " & "*********************")
    End Sub





End Class
