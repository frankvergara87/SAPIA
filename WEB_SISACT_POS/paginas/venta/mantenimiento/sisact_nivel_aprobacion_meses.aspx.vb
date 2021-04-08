Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions



Public Class sisact_nivel_aprobacion_meses
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgNivelAprobacion As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden

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
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_nivel_aprobacion_meses")
    Dim strIdentifyLog As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If (Not Page.IsPostBack) Then
            ListarGrilla()
        End If
    End Sub
    Private Sub ListarGrilla()

        Dim msgerr As String = ""
        Dim coderr As String = ""
        ' Dim objAudit As New BSWAuditoria
        Dim objAudit As New AuditoriaNegocio
        Dim perfilws As New ArrayList
        Dim tabla As New DataTable
        oLog.Log_WriteLog(strArchivo, "Inicio Nivel Aprobación Meses")
        oLog.Log_WriteLog(strArchivo, "Leer Perfiles por APP")
        oLog.Log_WriteLog(strArchivo, "Codido Aplicación: " & ConfigurationSettings.AppSettings("CodAplicacionSISACT"))
        perfilws = objAudit.LeerPerfilesPorApp(ConfigurationSettings.AppSettings("CodAplicacionSISACT"), msgerr, coderr)
        oLog.Log_WriteLog(strArchivo, "Perfilesws: " & perfilws.Count)
        oLog.Log_WriteLog(strArchivo, "Mensaje Error: " & msgerr)
        oLog.Log_WriteLog(strArchivo, "Codigo Error: " & coderr)
        Dim tabla2 As New DataTable
        Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelMeses")
        Dim obj As New NivelAprobacionNegocio 'NivelAprobacionNegocio
        Dim perfilfinal As New ArrayList
        Dim tableArraylist As New ArrayList

        oLog.Log_WriteLog(strArchivo, "Tipo: " & strTipo)
        tableArraylist = obj.ListarNivelesDeAprobacionMeses(strTipo)
        oLog.Log_WriteLog(strArchivo, "tableArraylist: " & tableArraylist.Count)
        For Each item3 As NivelAprobacion In tableArraylist
            perfilfinal.Add(item3)
        Next
        oLog.Log_WriteLog(strArchivo, "perfilfinal: " & perfilfinal.Count)
        For Each item As NivelAprobacion In perfilws
            Dim cont As Integer

            For Each item2 As NivelAprobacion In tableArraylist
                If item.CODIGO = item2.CODIGO Then
                    cont += 1
                End If
            Next

            If cont = 0 Then
                perfilfinal.Add(item)
            End If
            cont = 0
        Next
        oLog.Log_WriteLog(strArchivo, "perfilfinal: " & perfilfinal.Count)
        dgNivelAprobacion.DataSource = perfilfinal
        dgNivelAprobacion.DataBind()
        oLog.Log_WriteLog(strArchivo, "Fin Nivel Aprobación Meses")

    End Sub
    Private Sub dgNivelAprobacion_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.CancelCommand
        dgNivelAprobacion.EditItemIndex = -1
        ListarGrilla()
    End Sub
    Private Sub dgNivelAprobacion_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.EditCommand
        dgNivelAprobacion.EditItemIndex = e.Item.ItemIndex
        ListarGrilla()
    End Sub
    Private Sub dgNivelAprobacion_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgNivelAprobacion.PageIndexChanged
        dgNivelAprobacion.CurrentPageIndex = e.NewPageIndex
        ListarGrilla()
    End Sub
    Private Sub dgNivelAprobacion_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgNivelAprobacion.UpdateCommand

        oLog.Log_WriteLog(strArchivo, "Inicio Actualizar perfil")
        Dim msgerr As String = ""
        Dim strCodigo As Integer = Integer.Parse(CType(e.Item.Cells(3).FindControl("edit_hidCodigo"), System.Web.UI.HtmlControls.HtmlInputHidden).Value)
        oLog.Log_WriteLog(strArchivo, "Codigo: " & strCodigo)
        Dim strTempEstado As String = CType(e.Item.Cells(3).FindControl("edit_ckbEstado"), CheckBox).Checked.ToString
        oLog.Log_WriteLog(strArchivo, "Estado: " & strTempEstado)
        Dim strPerfilDesc As String = CType(e.Item.Cells(3).FindControl("Label3"), Label).Text
        oLog.Log_WriteLog(strArchivo, "Descripcion: " & strPerfilDesc)
        Dim strEstado As String
        Dim strTipo As String = ConfigurationSettings.AppSettings("constTipoNivelMeses")
        oLog.Log_WriteLog(strArchivo, "Tipo: " & strTipo)
        Dim strCantidad As Integer
        If CType(e.Item.Cells(3).FindControl("edit_txtCantidad"), TextBox).Text <> "" Then
            strCantidad = Integer.Parse(CType(e.Item.Cells(3).FindControl("edit_txtCantidad"), TextBox).Text)
            oLog.Log_WriteLog(strArchivo, "Cantidad:" & strCantidad)
        Else
            strCantidad = Integer.Parse("0")
            oLog.Log_WriteLog(strArchivo, "Cantidad:" & strCantidad)
        End If

        Dim obj As New NivelAprobacionNegocio

        If strTempEstado = "True" Then
            strEstado = "1"
            oLog.Log_WriteLog(strArchivo, "Estado: " & strEstado)
        Else
            strEstado = "0"
        End If

        Dim msgerror As String
        Dim iderror As String

        If CType(e.Item.Cells(3).FindControl("edit_txtCantidad"), TextBox).Text = "" Then
            RegisterStartupScript("script", "<script>alert('Debe ingresar una cantidad.')</script>")
            Return
        End If

        Try
            oLog.Log_WriteLog(strArchivo, "Insertar Actualizacion")
            obj.InsertarActualizaDatosNivelesAprobacionXtipo(CheckStr(strCodigo), strTipo, strEstado, strPerfilDesc, CheckStr(strCantidad), CheckStr(Session("codUsuarioSisact")), iderror, msgerror)
            oLog.Log_WriteLog(strArchivo, "iderror: " + iderror)
            oLog.Log_WriteLog(strArchivo, "msgerror: " + msgerror)
            oLog.Log_WriteLog(strArchivo, "Fin Insertar Actualizacion")
            If iderror <> "0" Then
                Anthem.Manager.RegisterClientScriptBlock("alerta", msgerror)
                Response.Redirect(Request.Url.ToString())
            End If

        dgNivelAprobacion.EditItemIndex = -1
            ListarGrilla()
        Catch ex As Exception
            ListarGrilla()
        End Try
        oLog.Log_WriteLog(strArchivo, "Fin Actualizar perfil")
    End Sub


End Class
