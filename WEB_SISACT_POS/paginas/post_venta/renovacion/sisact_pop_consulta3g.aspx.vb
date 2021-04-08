Imports System
Imports System.Configuration
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Negocios.LineasTecnologiaClienteWS

Public Class sisact_pop_consulta3g
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgLineas3g As System.Web.UI.WebControls.DataGrid
    Protected WithEvents errores As System.Web.UI.WebControls.Label

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private canal As String
    Public consMensajeLineas3G As String

    Private msg As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aquí el código de usuario para inicializar la página
        If Not Page.IsPostBack Then
            Dim objCLT As New ConsultaLineasTecnologiaNegocio
            canal = Request.QueryString("canal")
            Dim tdoc As String = Request.QueryString("tipodoc")
            Dim ndoc As String = Request.QueryString("numdoc")
            'obteniendo del servicio 
            Dim cmens, smens As String
            Try
                Dim lista As ListaLineaTypeListaLineas() = objCLT.consultarLineasPrePost(tdoc, ndoc, cmens, smens)
                If cmens <> "0" Then
                    HelperLog.CrearArchivolog("sisact_consulta_lineas3g", "proceso no exitoso, mensjae de servicio: " & smens, "", "", "")
                End If
                If Not (lista Is Nothing) Then ordenar(lista)
                obtenermsg()
                agregaraDGV(lista)

            Catch ex As Exception
                HelperLog.CrearArchivolog("sisact_consulta_lineas3g", "excepcion " & ex.Message & " " & ex.StackTrace, "", "", "")

            End Try
        End If
    End Sub

    Private Sub ordenar(ByVal lst As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas())
        'ordeno la lista para que sea los postpagos primer
        Dim aux As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas
        Dim i, j As Integer
        For i = 0 To lst.Length - 2
            For j = i + 1 To lst.Length - 1
                Dim p1 As Char = lst(i).planLinea.ToCharArray()(1)
                Dim p2 As Char = lst(j).planLinea.ToCharArray()(1)

                If Asc(p1) > Asc(p2) Then
                    aux = lst(i)
                    lst(i) = lst(j)
                    lst(j) = aux
                End If
            Next
        Next
    End Sub

    Private Sub agregaraDGV(ByVal lst As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas())
        'la lista la preparo para que solo tenga los 5 primeras lineas, o las n primeras
        Dim maxmost As Integer
        maxmost = obtenerCantidadLineas3G()
        msg = msg & "max a mostrar " & maxmost & " cantidad " & lst.Length
        If lst.Length > maxmost Then
            Dim sublista As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas()
            ReDim sublista(maxmost - 1)
            Dim i As Integer
            For i = 0 To maxmost - 1
                sublista(i) = lst(i)
            Next
            dgLineas3g.DataSource = sublista
        Else
            dgLineas3g.DataSource = lst
        End If
        dgLineas3g.DataBind()
    End Sub

    Protected Function mostrarNumLinea(ByVal numLinea As String) As String
        Dim res As String
        If Not (canal = ConfigurationSettings.AppSettings("constCodTipoCAC")) Then
            'como no es CAC (es DAC u otro) entonces pongo los asteriscos
            res = String.Format("{0}{1}", numLinea.Substring(0, 6), "***")
        Else
            res = numLinea
        End If
        Return res
    End Function
    Private Sub dgLineas3g_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLineas3g.ItemDataBound
        'en caso de ser CAC, debo de mostrar todo, sino debo mostrar el numero asi 986144***
        If Not (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then Exit Sub

        Dim lbl As Label = DirectCast(e.Item.Cells(0).FindControl("tplLinea"), Label)
        Dim datoLinea3g As Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas
        datoLinea3g = CType(e.Item.DataItem, Claro.SisAct.Negocios.LineasTecnologiaClienteWS.ListaLineaTypeListaLineas)

        If Not (canal = ConfigurationSettings.AppSettings("constCodTipoCAC")) Then
            'como no es CAC (es DAC u otro) entonces pongo los asteriscos
            lbl.Text = String.Format("{0}{1}", datoLinea3g.linea.Substring(0, 6), "***")
        Else
            lbl.Text = datoLinea3g.linea
        End If  'mostrada la linea, ahora el rsto de campos

        lbl = DirectCast(e.Item.Cells(1).FindControl("tpplanLinea"), Label)
        lbl.Text = datoLinea3g.planLinea
        lbl = DirectCast(e.Item.Cells(2).FindControl("tpestadoLinea"), Label)
        lbl.Text = datoLinea3g.estadoLinea
        lbl = DirectCast(e.Item.Cells(3).FindControl("tptipoBloqueo"), Label)
        lbl.Text = datoLinea3g.tipoBloqueo

    End Sub

    Private Sub obtenermsg()
        Dim codGrupoLineas3G As Long = Funciones.CheckInt64(ConfigurationSettings.AppSettings("codGrupoLineas3g"))
        Dim lista As ArrayList = New MaestroNegocio().ListaParametrosGrupo(codGrupoLineas3G)
        For Each sisactParam As Parametro In lista
            'busco de la lista el mensaje a mostrar.
            If sisactParam.Valor1 = "34" Then
                Dim cadena As String = sisactParam.Valor
                Me.consMensajeLineas3G = cadena
                Exit For
            End If
        Next
    End Sub

    Private Function obtenerCantidadLineas3G() As Integer
        Dim cantidad As Integer = 0
        Dim codGrupoLineas3G As Long = Funciones.CheckInt64(ConfigurationSettings.AppSettings("codGrupoLineas3g"))
        Dim lista As ArrayList = New MaestroNegocio().ListaParametrosGrupo(codGrupoLineas3G)
        For Each sisactParam As Parametro In lista
            'busco de la lista el mensaje a mostrar.
            If sisactParam.Valor1 = "35" Then
                Dim cadena As String = sisactParam.Valor
                cantidad = Funciones.CheckInt(cadena)
                Exit For
            End If
        Next
        Return cantidad
    End Function
End Class