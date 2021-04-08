Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports System.Text.RegularExpressions

Public Class sisact_ListadoArchivosAdjuntos_Consumer
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgLista As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidLista As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidflag As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Page.IsPostBack Then
            If hidProceso.Value = Nothing Then hidProceso.Value = ""
            Dim accion As String = hidProceso.Value
            hidProceso.Value = ""
            Select Case accion
                Case "I"
                    Inicio()
                Case "E"
                    eliminarArchivo()
            End Select
        End If

    End Sub
    Sub Inicio()
        Dim lista As New ArrayList
        Dim archivo As New ItemGenerico
        Dim item As New ItemGenerico
        Dim listaArchivos As String = Request.QueryString("listaArchivos")
        Dim listaTotal As String
        If hidLista.Value = "" Then
            hidLista.Value = listaArchivos
        Else
            hidLista.Value = hidLista.Value & "<@ARCHIVO@>" & listaArchivos
        End If
        lista = obtenerListaArchivos(hidLista.Value)
        cargarListaArchivos(lista)


    End Sub
    Sub cargarListaArchivos(ByVal lista As ArrayList)
        dgLista.DataSource() = lista
        dgLista.DataBind()
    End Sub
    Public Function obtenerListaArchivos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@ARCHIVO@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aArchivo() As String = c.Split("|"c)
                Dim item As New ItemGenerico
                item.Codigo = aArchivo(0)
                item.Descripcion = aArchivo(1)
                salida.Add(item)
            End If
        Next
        Return salida
    End Function
    Sub eliminarArchivo()
        Dim itemGrid As DataGridItem
        Dim lista As New ArrayList
        Dim id As String = hidId.Value
        Dim listaArchivos As ArrayList = obtenerListaArchivos(hidLista.Value)

        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(hidLista.Value, "<@ARCHIVO@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aArchivo() As String = c.Split("|"c)
                Dim item As New ItemGenerico
                item.Codigo = aArchivo(0)
                item.Descripcion = aArchivo(1)
                If id <> item.Codigo Then
                    lista.Add(item)
                End If
            End If
        Next
        hidLista.Value = formarListaArchivos(lista)
        cargarListaArchivos(lista)
    End Sub
    Public Function formarListaArchivos(ByVal lista As ArrayList) As String
        Dim sb As New System.Text.StringBuilder
        Dim archivo As String = ""
        Dim t As Integer = lista.Count - 1
        For i As Integer = 0 To t
            archivo = "{0}|{1}"
            Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
            archivo = String.Format(archivo, item.Codigo, _
                                         item.Descripcion)

            If i <> 0 Then archivo = "<@ARCHIVO@>" + archivo
            sb.Append(archivo)
        Next
        Return sb.ToString
    End Function
    Protected Function abrirArchivo(ByVal ruta As Object) As String
        Dim rutaArchivo As String = Funciones.CheckStr(ruta)
        Dim salida As String
        salida = Replace(rutaArchivo, "\", "\\", 1)

        Return salida
    End Function
End Class
