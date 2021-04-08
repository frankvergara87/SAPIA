Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_prepago_renovacion
    'Inherits System.Web.UI.Page
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnActualizarFlujo As System.Web.UI.WebControls.Button
    Protected WithEvents ifrOperador149 As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ifrBusquedaPrepago As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ifrDetalleCliente As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ifrDetalleVenta As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden

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
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If
        If (Session("codUsuarioSisact") Is Nothing Or Session("CodVendedorSAP") Is Nothing) Then
            Dim strUsuarioExt As String = Request.QueryString("cu")
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        If Not Page.IsPostBack Then
            Inicio()
        End If
    End Sub

    Private Sub Inicio()
        Try
            Session("TipoVentaExpress") = ConfigurationSettings.AppSettings("ExpressModoPrepagoRenovacion")
            Session("CanalSelected") = Nothing
            Session("PuntoVentaSelected") = Nothing
            Session("VendedorSelected") = Nothing
            Session("LineaSelected") = Nothing

            Dim pasosVenta(1) As String
            pasosVenta(1) = "4"
            pasosVenta(0) = "1"

            Session("PasosVenta") = pasosVenta

            Refrescar()
        Catch ex As Exception
            hidMsg.Value = "Error. " & ex.Message
        End Try
    End Sub

    Private Sub RetrocederPaso()
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
            pasosVenta(0) = CheckStr(CheckInt(pasosVenta(0)) - 1)
            Session("PasosVenta") = pasosVenta

            Refrescar()
        Catch
        End Try
    End Sub

    Private Sub Refrescar()
        Try
            Dim pasosVenta() As String = CType(Session("PasosVenta"), String())
            Dim strScript As String = String.Format("refrescar({0},{1});", pasosVenta(0), pasosVenta(1))
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
        Catch ex As Exception
            hidMsg.Value = String.Format("Error. No se pudo continuar con Siguiente Paso. {0}", ex.Message)
        End Try
    End Sub

End Class
