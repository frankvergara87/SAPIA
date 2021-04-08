Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions

Public Class sisact_nivel_aprobacion_soles
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgNivelAprobacion As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden

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

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty) Or CheckStr(Session("CodVendedorSAP")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelSoles")
        Dim obj As New NivelAprobacionNegocio
        dgNivelAprobacion.DataSource = obj.ListarNivelesDeAprobacionXTipo(strTipo)
      
    End Sub


    Private Sub dgNivelAprobacion_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.EditCommand
        dgNivelAprobacion.EditItemIndex = e.Item.ItemIndex
    End Sub

    Private Sub dgNivelAprobacion_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.CancelCommand
        Me.dgNivelAprobacion.EditItemIndex = -1
    End Sub

    Private Sub dgNivelAprobacion_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.UpdateCommand

        Dim strCodigo As Integer = Integer.Parse(CType(e.Item.Cells(3).FindControl("edit_hidCodigo"), System.Web.UI.HtmlControls.HtmlInputHidden).Value)
        Dim strTempEstado As String = CType(e.Item.Cells(3).FindControl("edit_ckbEstado"), CheckBox).Checked.ToString
        Dim strEstado As String
        If strTempEstado = "True" Then
            strEstado = "1"
        Else
            strEstado = "0"
        End If

        If CType(e.Item.Cells(3).FindControl("edit_txtCantidad"), TextBox).Text = "" Then
            RegisterStartupScript("script", "<script>alert('Debe ingresar una cantidad.')</script>")
            Return
        End If

        Dim strCantidad As Integer = Integer.Parse(CType(e.Item.Cells(3).FindControl("edit_txtCantidad"), TextBox).Text)

        Dim obj As New NivelAprobacionNegocio

        'ACTUALIZAR NIVEL DE APROBACION
        obj.ActualizarNivelesDeAprobacion(strCodigo, strEstado, strCantidad, Me.CurrentUser)


        dgNivelAprobacion.EditItemIndex = -1
        dgNivelAprobacion.DataSource = obj.ListarNivelesDeAprobacionXTipo(ConfigurationSettings.AppSettings("constTipoNivelSoles"))

    End Sub

    Private Sub dgNivelAprobacion_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgNivelAprobacion.PreRender

        dgNivelAprobacion.DataBind()
    End Sub


End Class
