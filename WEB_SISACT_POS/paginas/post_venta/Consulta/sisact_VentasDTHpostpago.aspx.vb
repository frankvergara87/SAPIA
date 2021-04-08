Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports COM_SIC_Activaciones
Imports System.IO
Imports System.Text

Public Class sisact_VentasDTHpostpago
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSec As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtFechaInicio As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtFechaFin As System.Web.UI.HtmlControls.HtmlInputText

    Protected WithEvents ddlTipoDocId As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlVendedorSAP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoOper As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgLista As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnbusqueda As System.Web.UI.WebControls.Button
    Protected WithEvents btnExportar As System.Web.UI.WebControls.Button
    Protected WithEvents hidCodPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDesPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden

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
    Dim oFile As String = oLog.Log_CrearNombreArchivo("reporteDTH2")
    Dim strIdentifyLog As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strIdentifyLog = "Reporte_DTH"
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
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

        If Not IsPostBack Then

            Incio()

        Else

            Select Case hidRequest.Value

                Case "Consulta"
                    Consulta()
                    Auditoria(hidDesPuntoVenta.Value, ConfigurationSettings.AppSettings("CONS_COD_VentasDTHpostpago"))

            End Select

        End If

    End Sub

    Private Sub Incio()

        ObtenerDatosVendedor()
        CargarTipoDocumento()
        CargarTipoOperacion()

    End Sub

    Private Sub CargarTipoDocumento()

        Dim listaTipoDoc As New ArrayList
        Dim oMaestro As New MaestroNegocio

        listaTipoDoc = oMaestro.ListaTipoDocumento("")
        oMaestro = Nothing

        Dim oTipoDocumento As New ItemGenerico
        oTipoDocumento.Codigo = "00"
        oTipoDocumento.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
        listaTipoDoc.Insert(0, oTipoDocumento)

        With ddlTipoDocId

            .DataValueField = "Codigo"
            .DataTextField = "Descripcion"
            .DataSource = listaTipoDoc
            .DataBind()

        End With

    End Sub

    Private Sub CargarTipoOperacion()

        Dim oVenta As New VentaExpressNegocios

        Dim dtConsultaEstadoSOT As DataTable = oVenta.ConsultaEstadoSOT()


        Dim strDelete As String = ConfigurationSettings.AppSettings("TipoOperacionesBorrar")
        Dim itemsRemove As String = ""

        For i As Integer = 0 To dtConsultaEstadoSOT.Rows.Count - 1

            Dim drDelete As DataRow = dtConsultaEstadoSOT.Rows(i)
            If strDelete.IndexOf(";" & Trim(drDelete("estsol")) & ";") > -1 Then
                itemsRemove &= i & ";"
            End If

        Next

        If Not itemsRemove.Equals(String.Empty) Then
            itemsRemove = itemsRemove.Substring(0, itemsRemove.Length - 1)
            Dim arrayItems As String() = itemsRemove.Split(";"c)
            Dim intPos As Integer = 0
            For Each item As Integer In arrayItems
                dtConsultaEstadoSOT.Rows.RemoveAt(CInt(item) - intPos)
                intPos += 1
            Next

        End If

        Dim drNew As DataRow = dtConsultaEstadoSOT.NewRow
        drNew("estsol") = "00"
        drNew("descripcion") = ConfigurationSettings.AppSettings("Todos")
        dtConsultaEstadoSOT.Rows.InsertAt(drNew, 0)

        ddlTipoOper.DataValueField = "estsol"
        ddlTipoOper.DataTextField = "descripcion"
        ddlTipoOper.DataSource = dtConsultaEstadoSOT
        ddlTipoOper.DataBind()

        oVenta = Nothing

    End Sub

    Sub Consulta()
        Try



            Dim oVenta As New VentaExpressNegocios
            Dim strTipDoc As Integer = ddlTipoDocId.SelectedValue
            Dim strEstSot As Integer = ddlTipoOper.SelectedValue
            Dim intSec As Integer = CheckInt(IIf(isNumeric(txtSec.Value), txtSec.Value, 0))
        Dim strNumeroDocumento As String = Trim(txtNumeroDocId.Text)
            Dim strTipoDocumento As String = IIf(strTipDoc <> 0, Trim(ddlTipoDocId.SelectedItem.Text), "")
        Dim strFechaInicio As String = (Trim(txtFechaInicio.Value))
        Dim strFechaFin As String = (Trim(txtFechaFin.Value))
            Dim strEstadoSot As String = IIf(strEstSot <> 0, Trim(ddlTipoOper.SelectedItem.Text), "")

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & intSec)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & strNumeroDocumento)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & strTipoDocumento)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & strFechaInicio)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & strFechaFin)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & hidCodPuntoVenta.Value)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & strEstadoSot)

        Dim dtConsultaVenta As DataTable = oVenta.reporteVentasxPtoVenta(intSec, strNumeroDocumento, strTipoDocumento, strFechaInicio, strFechaFin, hidCodPuntoVenta.Value, strEstadoSot)

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & dtConsultaVenta.Rows.Count)

        oVenta = Nothing

        dgLista.DataSource = dtConsultaVenta
        dgLista.DataBind()
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.Message)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.StackTrace)
        End Try
    End Sub

    Private Sub ExportarExcel()

        Dim sValor As String

        Dim Arial10B As String = "FONT-SIZE: 11px;COLOR: navy;FONT-FAMILY: Arial;TEXT-DECORATION: none;FONT-WEIGHT: bold;"
        Dim Contenido As String = "border-right: #95b7f3 1px solid;border-top: #95b7f3 1px solid;font-weight: bold;font-size: 10px;border-left: #95b7f3 1px solid;color: #003399;border-bottom: #95b7f3 1px solid;font-family: Verdana;background-color: white;	TEXT-DECORATION: none;border-color :#95b7f3"
        Dim tdHeader As String = "border-right: #95b7f3 1px solid;border-top: #95b7f3 1px solid;font-weight: bold;font-size: 11px;border-left: #95b7f3 1px solid;color: #003399;border-bottom: #95b7f3 1px solid;font-family: Verdana;background-color: white;TEXT-DECORATION: none;BACKGROUND-REPEAT: repeat-x; BACKGROUND-IMAGE: url(../images/toolgrad.gif); 	border-color :#95b7f3"

        Dim intSec As Integer = CheckInt(txtSec.Value)
        Dim strNumeroDocumento As String = Trim(txtNumeroDocId.Text)
        Dim strTipoDocumento As String = Trim(ddlTipoDocId.SelectedItem.Text)
        Dim strFechaInicio As String = CheckDate(txtFechaInicio.Value)
        Dim strFechaFin As String = CheckDate(txtFechaFin.Value)
        Dim strTipoEstado As String = Trim(ddlTipoOper.SelectedItem.Text)

        ' Damos la salida como attachment con el nombre de Testeo.xls.
        Response.AddHeader("content-disposition", "attachment; filename=VentasDTHpostpago.xls")
        ' Especificamos el tipo de salida.
        Response.ContentType = "application/vnd.ms-excel"
        ' Asociamos la salida con la codificación UTF7 (para poder visualizar los acentos correctamente)
        Response.ContentEncoding = Encoding.UTF8
        Response.Charset = ""


        Response.Write("<TABLE width='100%' style='" & Contenido & "'>")

        Response.Write("<TR>")
        Response.Write("<td colspan='5' style='" & tdHeader & "' width='10%' align='left'>")
        Response.Write("Reporte de Ventas DTH postpago")
        Response.Write("</td>")
        Response.Write("</TR>")


        Response.Write("<TR>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write("<b>Fecha de venta del&nbsp;&nbsp;</b>")
        Response.Write("</td>")
        Response.Write("<td  colspan='4' style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write(strFechaInicio & "&nbsp;&nbsp;al&nbsp;&nbsp;" & strFechaFin)
        Response.Write("</td>")
        Response.Write("</TR>")

        Response.Write("<TR>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write("<b>Sec&nbsp;&nbsp;</b>")
        Response.Write("</td>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write(intSec)
        Response.Write("</td>")
        Response.Write("</TR>")

        Response.Write("<TR>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write("<b>Tipo de Documento&nbsp;&nbsp;</b>")
        Response.Write("</td>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write(strTipoDocumento)
        Response.Write("</td>")
        Response.Write("</TR>")

        Response.Write("<TR>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write("<b>Numero de Documento&nbsp;&nbsp;</b>")
        Response.Write("</td>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write(strNumeroDocumento)
        Response.Write("</td>")
        Response.Write("</TR>")

        Response.Write("<TR>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write("<b>Tipos de Estado&nbsp;</b>")
        Response.Write("</td>")
        Response.Write("<td style='" & Arial10B & "' width='10%' align='left'>")
        Response.Write(strTipoEstado)
        Response.Write("</td>")
        Response.Write("</TR>")

        Response.Write("</TABLE>")

        Response.Write("<BR><BR><BR>")

        Me.EnableViewState = False
        Dim tw As New System.IO.StringWriter
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        dgLista.RenderControl(hw)  ' g es el DATAGRID
        'Escribimos el HTML en el Explorador
        Response.Write(tw.ToString())
        ' Terminamos el Response.

        Auditoria(hidDesPuntoVenta.Value, ConfigurationSettings.AppSettings("CONS_COD_VentasDTHpostpago"))

        Response.End()

    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        'Consulta()
        ExportarExcel()

    End Sub

    Private Sub ObtenerDatosVendedor()

        If Me.CurrentUser = "" Then
            Throw New Exception("Se perdió la sesión del usuario. Ingrese nuevamente.")
        End If

        ' Buscar Datos del Usuario Logeado
        Dim oUsuario As Usuario
        oUsuario = New MaestroNegocio().ObtenerUsuarioLogin(Me.CurrentUser)
        Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)

        ' Buscar Punto de Venta
        Dim listaPuntoVenta As ArrayList = New VentaNegocios().ListaPDVUsuario(codUsuario, "")
        If IsNothing(listaPuntoVenta) OrElse listaPuntoVenta.Count = 0 Then
            Throw New Exception("Error: Usuario no pertenece a algún Punto de Venta.")
        End If

        ' Guardar los datos generales de Venta
        Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)

        hidCodPuntoVenta.Value = CheckStr(itemPuntoVenta.OVENC_CODIGO)
        hidDesPuntoVenta.Value = CheckStr(itemPuntoVenta.OVENV_DESCRIPCION)

        oUsuario = Nothing
        itemPuntoVenta = Nothing
        listaPuntoVenta = Nothing

    End Sub

    Private Sub Auditoria(ByVal oficina As String, ByVal evento As String)
        Dim fecha As String = Now.ToShortDateString
        Dim hora As String = Now.ToShortTimeString
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal
            Dim strDesTrans As String
            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim msg As String = "Error. No se registro en Auditoria de busqueda de Historico de contratos PCS (Fecha: " & fecha & ")."
            Dim strCodTrans As String = evento

            strDesTrans = "Se realizo la auditoria de Excel con fecha : " & fecha & " y hora: " & hora & " en el punto de venta: " & oficina

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)

            If Not auditoriaGrabado Then
                Response.Write("<script>alert('" & msg & "');</script>")
            End If

        Catch ex As Exception
            Dim msg As String = "Error. No se registro en Auditoria de busqueda de Historico de contratos PCS (Fecha: " & fecha & ")."
            Response.Write("<script>alert('" & msg & "');</script>")
        End Try

    End Sub

    Sub limpiar()

        txtSec.Value = ""
        txtNumeroDocId.Text = ""
        ddlTipoDocId.SelectedIndex = 0
        txtFechaInicio.Value = ""
        txtFechaFin.Value = ""
        ddlTipoOper.SelectedIndex = 0

    End Sub

End Class
