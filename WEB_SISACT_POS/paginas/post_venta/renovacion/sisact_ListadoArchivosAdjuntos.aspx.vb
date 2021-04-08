Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports System.Text.RegularExpressions
Public Class sisact_ListadoArchivosAdjuntos
    Inherits System.Web.UI.Page

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgLista As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidListaArchivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLista As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidflag As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLisArchiElim As System.Web.UI.HtmlControls.HtmlInputHidden

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

     If (Session("codUsuarioSisact") Is Nothing) Then
            Response.Write("<script>alert('Su sesión ha expirado, vuelva a ingresar al sistema.');</script>")
            Response.End()
        Exit Sub
     Else
        Response.CacheControl = "NO-CACHE"
        Response.AddHeader("cache-control", "no-cache, private")

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
      End if
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
                item.estado = aArchivo(2) 'Omar Garcia Leyenda 1 Son Extraidos de BD, 0 los nuevos
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
                item.estado = aArchivo(2) 'Omar Garcia
                If id <> item.Codigo Then
                    lista.Add(item)
                ElseIf id = item.Codigo And item.estado = "1" Then 'Omar Garcia
                    If hidLisArchiElim.Value = "" Then
                        hidLisArchiElim.Value = item.Codigo
                    Else
                        hidLisArchiElim.Value = hidLisArchiElim.Value & "|" & item.Codigo
                    End If
                    'Fin OGV
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
            archivo = "{0}|{1}|{2}"
            Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
            archivo = String.Format(archivo, item.Codigo, _
                                         item.Descripcion, item.estado)

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
