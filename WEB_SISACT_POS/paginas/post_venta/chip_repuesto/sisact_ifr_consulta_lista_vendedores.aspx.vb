Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_lista_vendedores
    Inherits System.Web.UI.Page

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

        If Session("codUsuarioSisact") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not IsPostBack Then
                Inicio()
            Else
                If hidRequest.Value = "ConsultarListaVendedores" Then
                    ConsultarListaVendedores()
                End If
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
        Dim oficina As String = hidParametros.Value
        hidDatosRetorno.Value = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")
        hidResponse.Value = "RetornarDatos"

        If oficina = "" Then
            hidMsg.Value = "Error. Parametros para consular Lista de Vendedores no adecuada."
            Exit Sub
        End If

        Dim oConsultarSap As New SapGeneralNegocios
        Dim oconsultaMSSap As New ConsultaMsSapNegocio

        Dim listaVendedores As New ArrayList
        Try
            ' Consultar
            'listaVendedores = oConsultarSap.ConsultarListaVendedores(oficina)

            '-incio-dga-04082015
            'listaVendedores = oconsultaMSSap.ConsultaVendedores(oficina)
            Dim estadoVendedor As String = ConfigurationSettings.AppSettings("constEstadoVendedor")
            listaVendedores = oconsultaMSSap.ConsultaVendedoresPVU(oficina, estadoVendedor)
            '-fin-dga-04082015

            For Each item As ItemGenerico In listaVendedores
                If hidDatosRetorno.Value <> "" Then
                    hidDatosRetorno.Value = hidDatosRetorno.Value & ";" & item.Codigo & "," & item.Descripcion & " - " & item.Codigo
                Else
                    hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion & " - " & item.Codigo
                End If
            Next
            hidResponse.Value = "RetornarDatos"
        Catch ex As Exception
            hidMsg.Value = "Error. " & ex.Message

            hidResponse.Value = "RetornarDatos"
        End Try
    End Sub

End Class
