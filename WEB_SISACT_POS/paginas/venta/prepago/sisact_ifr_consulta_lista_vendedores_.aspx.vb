Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_lista_vendedores_
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRequest As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidResponse As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidParametros As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDatosRetorno As System.Web.UI.HtmlControls.HtmlInputHidden

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
        End If
        If Not IsPostBack Then
            Inicio()
        Else
            If hidRequest.Value = "ConsultarListaVendedores" Then
                ConsultarListaVendedores()
            End If
        End If
    End Sub

    Private Sub Inicio()
        hidParametros.Value = Request.QueryString("oficina")
        If hidParametros.Value = "" Then
            hidResponse.Value = "ExtraerDatos"
        Else
            ConsultarListaVendedores()
        End If
    End Sub

    Private Sub ConsultarListaVendedores()

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogRenovacion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = Me.CurrentUser
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio ConsultarListaVendedores ")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Request.oficina: " & Request.QueryString("oficina"))

        Dim oficina As String = hidParametros.Value
        hidDatosRetorno.Value = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")
        hidResponse.Value = "RetornarDatos"

        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		oficina: " & oficina)

        If oficina = "" Then
            hidMsg.Value = "Error. Parametros para consular Lista de Vendedores no adecuada."
            Exit Sub
        End If

        Dim oConsultarSap As New SapGeneralNegocios
        Dim listaVendedores As New ArrayList
        Try
            ' Consultar
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio oConsultarSap.ConsultarListaVendedores(oficina)")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP oficina: " & oficina)
            listaVendedores = oConsultarSap.ConsultarListaVendedores(oficina)

            For Each item As ItemGenerico In listaVendedores
                If hidDatosRetorno.Value <> "" Then
                    hidDatosRetorno.Value = hidDatosRetorno.Value & ";" & item.Codigo & "," & item.Descripcion & " - " & item.Codigo
                Else
                    hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion & " - " & item.Codigo
                End If
            Next
            'objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT hidDatosRetorno: " & hidDatosRetorno.Value)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin oConsultarSap.ConsultarListaVendedores(oficina)")
            hidResponse.Value = "RetornarDatos"
        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		ERROR: " & ex.Message.ToString())
            hidMsg.Value = "Error. " & ex.Message
            hidResponse.Value = "RetornarDatos"
        Finally
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin ConsultarListaVendedores ")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")

        End Try
    End Sub
End Class
