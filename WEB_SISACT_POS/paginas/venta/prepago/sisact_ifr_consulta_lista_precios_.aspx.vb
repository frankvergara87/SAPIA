Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_ifr_consulta_lista_precios_
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

        If Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not IsPostBack Then
                Inicio()
            Else
                If hidRequest.Value = "ConsultarListaPrecios" Then
                    ConsultarListaPrecios()
                End If
            End If

            Dim strScript1 As String = "inicio();"
            RegisterStartupScript("script", "<script>" & strScript1 & "</script>")
        End If

    End Sub

    Private Sub Inicio()
        Dim parametros As String = Request.QueryString("parametros")
        hidParametros.Value = Request.QueryString("parametros")
        If hidParametros.Value = "" Then
            hidResponse.Value = "ExtraerDatos"
        Else
            ConsultarListaPrecios()
        End If
    End Sub

    Private Sub ConsultarListaPrecios()
        Dim param() As String = hidParametros.Value.Split(","c)
        hidDatosRetorno.Value = "00" & "," & ConfigurationSettings.AppSettings("Seleccionar")
        hidResponse.Value = "RetornarDatos"

        If param.Length <> 8 Then
            hidMsg.Value = "Error. Parametros para consular Lista de Precios no adecuada."
            Exit Sub
        End If

        Dim oConsultarSap As New SapGeneralNegocios
        Dim listaPreciosIccid As New ArrayList
        Dim listaPreciosImei As New ArrayList
        Dim listaPrecios As New ArrayList
        Try
            'Obtener "org_venta"
            Dim orgVenta As String = ConfigurationSettings.AppSettings("ExpressOrgVenta")

            ' Consultar 1º para Iccid
            If param(2) <> "" Then
                listaPreciosIccid = oConsultarSap.ConsultarListaPrecios(param(0), param(1), param(2), param(4), orgVenta, Now.ToString("yyyy/MM/dd"), param(7))
            End If
            ' Consultar 2º para Imei
            If param(3) <> "" Then
                listaPreciosImei = oConsultarSap.ConsultarListaPrecios(param(0), param(1), param(3), param(4), orgVenta, Now.ToString("yyyy/MM/dd"), param(7))
            End If

            ' Considerar solo aquellos precios que se encuentran en ambas listas
            If param(2) <> "" And param(3) <> "" Then
                For Each itemImei As ItemGenerico In listaPreciosImei
                    For Each itemIccid As ItemGenerico In listaPreciosIccid
                        If itemImei.Codigo = itemIccid.Codigo Then
                            listaPrecios.Add(itemImei)
                        End If
                    Next
                Next
            ElseIf param(2) <> "" Then ' Podra hacer la venta, sin IMEI
                listaPrecios = listaPreciosIccid
            ElseIf param(3) <> "" Then ' Podra hacer la venta, sin ICCID
                listaPrecios = listaPreciosImei
            End If

            For Each item As ItemGenerico In listaPrecios
                If hidDatosRetorno.Value <> "" Then
                    hidDatosRetorno.Value = hidDatosRetorno.Value & ";" & item.Codigo & "," & item.Descripcion
                Else
                    hidDatosRetorno.Value = item.Codigo & "," & item.Descripcion
                End If
            Next
            hidResponse.Value = "RetornarDatos"
        Catch ex As Exception
            hidMsg.Value = "Error 4. " & ex.Message
            hidResponse.Value = "RetornarDatos"
        End Try
    End Sub
End Class
