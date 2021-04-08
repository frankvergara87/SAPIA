Imports System.Text
Imports System.Text.RegularExpressions
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Configuration
Public Class sisact_recibo_acuerdo
    Inherits SisAct_WebBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblEquipoDesEdit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlBanco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCantidadEdit As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroOperacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidListaRecibo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMontoOperacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgRecibo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidBancoDes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtFechaDeposito As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label32 As System.Web.UI.WebControls.Label
    Protected WithEvents hidBancoIdFila As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBancoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidReciboIdFila As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidReciboId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFilaRecibo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOcultar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSEC As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLisRecbElim As System.Web.UI.HtmlControls.HtmlInputHidden
    'Protected WithEvents btnAceptar As System.Web.UI.HtmlControls.HtmlButton


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Property IdUltimoNuevoRecibo() As Integer
        Get
            Return CheckInt(Me.ViewState("ID_ULTIMO_NUEVO_RECIBO").ToString)
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("ID_ULTIMO_NUEVO_RECIBO") = CStr(Value)
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Response.Write("<script language=javascript>validarUrl();</script>")

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        Else
            If Not Page.IsPostBack Then
                Inicio()
            Else
                If hidProceso.Value = Nothing Then hidProceso.Value = ""
                Dim accion As String = hidProceso.Value
                hidProceso.Value = ""
                Select Case accion
                    Case "E_E"
                        editar()
                    Case "Elim_E"
                        eliminar()
                    Case "AGR_E"
                        agregar()
                    Case "A_E"
                        actualizar()
                    Case "R_M"
                        cargarBanco()
                        hidProceso.Value = accion
                End Select
            End If
        End If
    End Sub

    Sub Inicio()
        hidFechaActual.Value = Date.Now.ToString("dd/MM/yyyy")
        hidSEC.Value = Request.QueryString("IdSEC")
        Me.IdUltimoNuevoRecibo = 0   '///MACC
        'Omar Garcia
        Dim oConsulta As New SolicitudNegocios
        Dim aArchivos As ArrayList = oConsulta.ListaRecibo(CLng(hidSEC.Value), 0, "")
        If aArchivos.Count > 0 Then
            hidFilaRecibo.Value = CStr(aArchivos.Count)
            Dim listaActual As New ArrayList
            For Each item As ReciboDeposito In aArchivos
                listaActual.Add(item)
            Next
            cargarLista(listaActual) 'llena a hidListaRecibo.Value
        Else
            dgRecibo.DataSource = New ArrayList
            dgRecibo.DataBind()
        End If
        'fin OG        
        cargarBanco()

        If (Not Request.QueryString("estado") Is Nothing) Then
            If (Request.QueryString("estado").ToString <> ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS").ToString()) Then
                Me.dgRecibo.Columns(0).Visible = False
                Me.dgRecibo.Columns(1).Visible = False
            End If
        End If

    End Sub

    Sub cargarBanco()
        Dim lista As New ArrayList
        Dim oConsulta As New MantMaestroNegocio
        Dim tipoProducto, tipoVenta As String
        lista = oConsulta.ListaTablaGeneralSISACT("BR", "1") ' Banco Recibos
        lista.Insert(0, New TabladeTablas("-1", "--Seleccionar--"))
        ddlBanco.DataSource = lista
        ddlBanco.DataValueField = "TABLN_CODIGO"
        ddlBanco.DataTextField = "TABLN_DESCRIPCION"
        ddlBanco.DataBind()
    End Sub

    Sub editar()
        hidProceso.Value = "A_E"
        Dim itemGrid As DataGridItem
        Dim id As String = hidReciboId.Value
        For Each itemGrid In dgRecibo.Items
            If itemGrid.ItemType = ListItemType.Item Or itemGrid.ItemType = ListItemType.AlternatingItem Then
                Dim hidReciboIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidReciboIdFila"), HtmlInputHidden)
                Dim hidBancoIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidBancoIdFila"), HtmlInputHidden)
                Dim lblNroOperacion As Label = CType(itemGrid.FindControl("lblNroOperacion"), Label)
                Dim lblFechaDeposito As Label = CType(itemGrid.FindControl("lblFechaDeposito"), Label)
                Dim lblMontoDeposito As Label = CType(itemGrid.FindControl("lblMontoDeposito"), Label)
                If hidReciboIdFila.Value = id Then
                    ddlBanco.SelectedValue = hidBancoIdFila.Value
                    txtNroOperacion.Text = lblNroOperacion.Text
                    txtMontoOperacion.Text = CheckDbl(lblMontoDeposito.Text).ToString
                    txtFechaDeposito.Text = lblFechaDeposito.Text
                    Return
                End If
            End If
        Next
    End Sub

    Sub eliminar()
        Dim url As String
        Dim itemGrid As DataGridItem
        Dim id As String = hidReciboId.Value '//id del recibo a eliminar
        Dim lista As New ArrayList

        For Each itemGrid In dgRecibo.Items
            If itemGrid.ItemType = ListItemType.Item Or itemGrid.ItemType = ListItemType.AlternatingItem Then
                Dim hidReciboIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidReciboIdFila"), HtmlInputHidden)
                Dim hidBancoIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidBancoIdFila"), HtmlInputHidden)
                Dim lblNroOperacion As Label = CType(itemGrid.FindControl("lblNroOperacion"), Label)
                Dim lblFechaDeposito As Label = CType(itemGrid.FindControl("lblFechaDeposito"), Label)
                Dim lblMontoDeposito As Label = CType(itemGrid.FindControl("lblMontoDeposito"), Label)
                Dim lblBancoDes As Label = CType(itemGrid.FindControl("lblBancoDes"), Label)

                Dim lblSOLIN_CODIGO As Label = CType(itemGrid.FindControl("lblSOLIN_CODIGO"), Label) 'Omar Garcia 1

                If hidReciboIdFila.Value = id Then
                    'Omar Garcia
                    Dim valorID As Integer = CheckInt(hidReciboIdFila.Value)
                    If (valorID > 0) Then  '//ya existía en BD, sino se obvia, eliminación en memoria
                        If hidLisRecbElim.Value = "" Then
                            hidLisRecbElim.Value = hidReciboIdFila.Value
                        Else
                            hidLisRecbElim.Value = hidLisRecbElim.Value & "|" & hidReciboIdFila.Value
                        End If
                    End If
                Else
                    Dim item As New ReciboDeposito
                    item.RECIBO_ID = CheckInt(hidReciboIdFila.Value)
                    item.BANCO_ID = CheckInt(hidBancoIdFila.Value)
                    item.NRO_OPERACION = lblNroOperacion.Text
                    item.FECHA_DEPOSITO = CheckDate(lblFechaDeposito.Text)
                    item.MONTO_DEPOSITO = CheckDbl(lblMontoDeposito.Text)
                    item.BANCO_DES = lblBancoDes.Text
                    item.SOLIN_CODIGO = CLng(lblSOLIN_CODIGO.Text) 'Omar García
                    lista.Add(item)
                End If
            End If
        Next
        cargarLista(lista)
    End Sub

    Sub actualizar()
        Dim url As String
        Dim itemGrid As DataGridItem
        Dim id As String = hidReciboId.Value
        Dim lista As New ArrayList
        Dim listaRecibos As New ArrayList
        Dim oConsulta As New SolicitudNegocios
        Dim bancoid As Integer = CheckInt(ddlBanco.SelectedValue)
        Dim t As Integer
        If bancoid = 1 Then
            t = 0
        Else
            Try
                listaRecibos = oConsulta.ListaRecibo(0, bancoid, txtNroOperacion.Text)
            Catch ex As Exception
            End Try

            t = listaRecibos.Count
        End If

        If t > 0 Then
            hidMsg.Value = "Existe este recibo adjuntado a otra Solicitud"
        Else
            For Each itemGrid In dgRecibo.Items
                If itemGrid.ItemType = ListItemType.Item Or itemGrid.ItemType = ListItemType.AlternatingItem Then
                    Dim hidReciboIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidReciboIdFila"), HtmlInputHidden)
                    Dim hidBancoIdFila As HtmlInputHidden = CType(itemGrid.FindControl("hidBancoIdFila"), HtmlInputHidden)
                    Dim lblNroOperacion As Label = CType(itemGrid.FindControl("lblNroOperacion"), Label)
                    Dim lblFechaDeposito As Label = CType(itemGrid.FindControl("lblFechaDeposito"), Label)
                    Dim lblMontoDeposito As Label = CType(itemGrid.FindControl("lblMontoDeposito"), Label)
                    Dim lblBancoDes As Label = CType(itemGrid.FindControl("lblBancoDes"), Label)
                    Dim lblSOLIN_CODIGO As Label = CType(itemGrid.FindControl("lblSOLIN_CODIGO"), Label)
                    '
                    Dim item As New ReciboDeposito
                    If hidReciboIdFila.Value = id And listaRecibos.Count = 0 Then
                        item.RECIBO_ID = CheckInt(hidReciboIdFila.Value)
                        item.BANCO_ID = CheckInt(ddlBanco.SelectedValue)
                        If txtNroOperacion.Text <> "" Then item.NRO_OPERACION = txtNroOperacion.Text.ToUpper()
                        item.FECHA_DEPOSITO = CheckDate(txtFechaDeposito.Text)
                        item.MONTO_DEPOSITO = CheckDbl(txtMontoOperacion.Text)
                        item.BANCO_DES = ddlBanco.SelectedItem.Text
                        item.SOLIN_CODIGO = CLng(lblSOLIN_CODIGO.Text) 'Omar García
                    Else
                        item.RECIBO_ID = CheckInt(hidReciboIdFila.Value)
                        item.BANCO_ID = CheckInt(hidBancoIdFila.Value)
                        item.NRO_OPERACION = lblNroOperacion.Text
                        item.FECHA_DEPOSITO = CheckDate(lblFechaDeposito.Text)
                        item.MONTO_DEPOSITO = CheckDbl(lblMontoDeposito.Text)
                        item.BANCO_DES = lblBancoDes.Text
                        item.SOLIN_CODIGO = CLng(lblSOLIN_CODIGO.Text) 'Omar García
                    End If
                    lista.Add(item)
                End If
            Next
            cargarLista(lista)
        End If



    End Sub

    Sub cargarLista(ByVal lista As ArrayList)
        hidListaRecibo.Value = ""
        If lista.Count > 0 Then hidListaRecibo.Value = formarLista(lista)
        dgRecibo.DataSource = lista
        dgRecibo.DataBind()
    End Sub

    Sub agregar()
        hidProceso.Value = "AGR_E"
        Dim listaRecibos As New ArrayList
        Dim item As New ReciboDeposito

        '---macc
        Me.IdUltimoNuevoRecibo = Me.IdUltimoNuevoRecibo - 1
        item.RECIBO_ID = Me.IdUltimoNuevoRecibo

        item.BANCO_ID = CheckInt(ddlBanco.SelectedValue)
        item.BANCO_DES = ddlBanco.SelectedItem.Text
        If txtNroOperacion.Text <> "" Then item.NRO_OPERACION = txtNroOperacion.Text.ToUpper()
        item.FECHA_DEPOSITO = CheckDate(txtFechaDeposito.Text)
        item.MONTO_DEPOSITO = CheckDbl(txtMontoOperacion.Text)
        item.SOLIN_CODIGO = 0 'Omar García 1
        Dim oConsulta As New SolicitudNegocios
        Dim t As Integer
        If item.BANCO_ID = 1 Then
            t = 0
        Else
            Try
                listaRecibos = oConsulta.ListaRecibo(0, item.BANCO_ID, item.NRO_OPERACION)
            Catch ex As Exception
            End Try
            t = listaRecibos.Count
        End If
        If t > 0 Then
            hidMsg.Value = "Existe este recibo adjuntado a otra Solicitud"
        Else
            Dim listaActual As New ArrayList
            If hidListaRecibo.Value <> "" Then listaActual = obtenerArrayRecibos(hidListaRecibo.Value)
            listaActual.Add(item)
            cargarLista(listaActual) 'llena a hidListaRecibo.Value
            hidFilaRecibo.Value = (CheckInt(hidFilaRecibo.Value) + 1).ToString
        End If

    End Sub

    Function obtenerArrayRecibos(ByVal lista As String) As ArrayList
        If lista = "" Or lista = "undefined" Then Return New ArrayList
        Dim salida As New ArrayList
        Dim aLista() As String = Regex.Split(lista, "<@Recibo@>")
        For Each c As String In aLista
            If c <> "" Then
                Dim aRecibo() As String = c.Split("|"c)
                Dim item As New ReciboDeposito
                item.RECIBO_ID = CheckInt(aRecibo(0))
                item.BANCO_ID = CheckInt(aRecibo(1))
                item.BANCO_DES = aRecibo(2)
                item.NRO_OPERACION = aRecibo(3)
                item.MONTO_DEPOSITO = CheckDbl(aRecibo(4))
                item.FECHA_DEPOSITO = CheckDate(aRecibo(5))
                item.SOLIN_CODIGO = CheckInt64(aRecibo(6)) 'Omar Garcia 1
                salida.Add(item)
            End If
        Next
        Return salida
    End Function

    Function formarLista(ByVal lista As ArrayList) As String
        Dim sb As New StringBuilder
        Dim linea As String = ""
        Dim t As Integer = lista.Count - 1
        Dim campos As String = "{0}|{1}|{2}|{3}|{4}|{5}|{6}" 'Omar G 1
        For i As Integer = 0 To t
            Dim item As ReciboDeposito = CType(lista(i), ReciboDeposito)
            If i = t Then
                linea = campos
            Else
                linea = campos + "<@Recibo@>"
            End If
            linea = String.Format(linea, item.RECIBO_ID, _
                                        item.BANCO_ID, _
                                        item.BANCO_DES, _
                                        item.NRO_OPERACION, _
                                        item.MONTO_DEPOSITO, _
                                        item.FECHA_DEPOSITO, _
                                        item.SOLIN_CODIGO)
            sb.Append(linea)
        Next
        Return sb.ToString
    End Function

    Protected Function ObtenerFecha(ByVal valor As Object, ByVal f As String) As String
        Dim v As Date = CheckDate(valor)
        Dim salida As String = ""
        If v = New Date(1, 1, 1) Then Return ""
        If f <> "" Then
            salida = String.Format(f, v)
        Else
            salida = String.Format("{0:dd/MM/yyyy hh:mm:ss}", v)
        End If
        Return salida
    End Function

End Class
