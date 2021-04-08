Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones.Comunes

Public Class sisact_pop_consulta_sec
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgLista As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblFilas As System.Web.UI.WebControls.Label

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
    Dim strArchivo As String = objLog.Log_CrearNombreArchivo("Log_EvaluacionUnificada")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not IsPostBack Then
            Inicio()
        End If
    End Sub

    Private Sub Inicio()
        Dim strTipoDoc As String = CheckStr(Request.QueryString("tipoDocumento"))
        Dim strNroDoc As String = CheckStr(Request.QueryString("nroDocumento"))
        Dim oConsulta As New ConsumerNegocio
        Dim arrListaSEC As New ArrayList

        objLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "INICIO OBTENER SEC PENDIENTE")

        If strTipoDoc = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
            strNroDoc = strNroDoc & "     "
        Else
            strNroDoc = Right("0000000000000000" & strNroDoc, 16)
        End If
        arrListaSEC = oConsulta.ObtenerSECPendiente(strTipoDoc, strNroDoc)

        dgLista.DataSource = arrListaSEC
        dgLista.DataBind()

        lblFilas.Text = arrListaSEC.Count & " registro(s) encontrado(s)"

        objLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "FIN OBTENER SEC PENDIENTE")
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If e.Item.Cells(9).Text.Equals("VENDIDO") Then
                'RegisterStartupScript("script", "<script>document.getElementById('rbtSEC').disabled='true';</script>")
            End If
        End If
    End Sub


End Class
