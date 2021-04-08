Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_mant_blacklist_canalpdv
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents dgrGrillaDetalle As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAgregar As System.Web.UI.WebControls.Button
    Protected WithEvents btnEliminar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents hidCargaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btn As System.Web.UI.WebControls.Button
    Protected WithEvents hidPV_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlan_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtODDescripcion As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnODBuscar As System.Web.UI.WebControls.Button
    Protected WithEvents hidKit_Visible As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

    Protected WithEvents hidPuntosVentas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgrGrillaCabecera As System.Web.UI.WebControls.DataGrid

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
        Response.Write("<script language='javascript' src='../../script/funciones_sec.js'></script>")
        If Request.QueryString("cu") Is Nothing Then
            Response.Write("<script language=javascript>validarUrl();</script>")
        Else
            Response.Write("<script language=javascript>restringirEventos();</script>")
        End If

        If (CheckStr(Session("codUsuarioSisact")).Equals(String.Empty)) Then
            Dim strUsuarioExt As String = Request.QueryString("cu") & String.Empty
            If Not AccesoUsuario.VerificarUsuario(strUsuarioExt, CurrentUser) Then
                Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
                Response.Redirect(strRutaSite)
                Response.End()
                Exit Sub
            End If
        End If

        btnAgregar.Attributes.Add("onclick", "return f_ConfirmarGrabar();")
        If Not IsPostBack Then
            Inicio()
        End If

    End Sub

    Private Sub Inicio()

        Try
            CargarCanal()
            CargarPuntoVenta()
            dgrGrillaDetalle.CurrentPageIndex = 0
            CargarGrid()
        Catch ex As Exception
            hidMsg.Value = ex.Message
        End Try

    End Sub

    Private Sub CargarCanal()

        Dim listaCanal As New ArrayList

        If Not Session("CanalSelected") Is Nothing Then
            Dim oCanalTmp As Canal = CType(Session("CanalSelected"), Canal)
            listaCanal.Add(oCanalTmp)
        Else
            ddlCanal.Attributes.Remove("disabled")
            Dim objConsumerNegocio As New ConsumerNegocio
            listaCanal = objConsumerNegocio.ListaCanales(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
            objConsumerNegocio = Nothing

            Dim oCanal As New Canal
            oCanal.CANAC_CODIGO = "00"
            oCanal.CANAV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
            listaCanal.Insert(0, oCanal)
        End If
        With ddlCanal
            .DataSource = listaCanal
            .DataValueField = "CANAC_CODIGO"
            .DataTextField = "CANAV_DESCRIPCION"
            .DataBind()
        End With

        listaCanal = Nothing

    End Sub

    Private Sub CargarPuntoVenta()

        Dim listaPDV As New ArrayList

        If Not Session("PuntoVentaSelected") Is Nothing Then
            Dim oPuntoVentaTmp As PuntoVenta = CType(Session("PuntoVentaSelected"), PuntoVenta)
            listaPDV.Add(oPuntoVentaTmp)
        Else
            ddlPuntoVenta.Attributes.Remove("disabled")
            Dim listaPuntoVenta As New ArrayList
            Dim oConsulta As New MaestroNegocio
            listaPuntoVenta = oConsulta.ListaPDVUsuario(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
            oConsulta = Nothing

            ' SELECCIONE
            Dim oPuntoVenta As New PuntoVenta
            oPuntoVenta.OVENC_CODIGO = "0"
            oPuntoVenta.OVENV_DESCRIPCION = ConfigurationSettings.AppSettings("Todos")
            oPuntoVenta.TOFIC_CODIGO = "00"
            oPuntoVenta.CANAC_CODIGO = "00"
            listaPuntoVenta.Insert(0, oPuntoVenta)
            listaPDV.Add(oPuntoVenta)

            Dim strCadenaPuntoVenta As String = ""
            For Each objPuntoVenta As PuntoVenta In listaPuntoVenta
                strCadenaPuntoVenta = strCadenaPuntoVenta & "|" & objPuntoVenta.OVENC_CODIGO & ";" & objPuntoVenta.OVENV_DESCRIPCION & ";" & objPuntoVenta.TOFIC_CODIGO & ";" & objPuntoVenta.CANAC_CODIGO
            Next

            'cargo todos los Puntos de venta en el hidPuntosVentas
            hidPuntosVentas.Value = strCadenaPuntoVenta.Substring(1)

            listaPuntoVenta = Nothing
        End If
        With ddlPuntoVenta
            .DataSource = listaPDV
            .DataValueField = "OVENC_CODIGO"
            .DataTextField = "OVENV_DESCRIPCION"
            .DataBind()
        End With

        listaPDV = Nothing

    End Sub

    Private Sub CargarGrid()

            Dim oConsulta As New MaestroNegocio
            Dim arrConsulta As New ArrayList
            arrConsulta = oConsulta.ListaBlackListCanalPdv()

            Dim rangoPaginaPosible As Double = CheckDbl(arrConsulta.Count / dgrGrillaDetalle.PageSize)
            Dim nroPaginaVer As Integer = dgrGrillaDetalle.CurrentPageIndex + 1
            If Math.Ceiling(rangoPaginaPosible) < nroPaginaVer Then
                dgrGrillaDetalle.CurrentPageIndex = 0
            End If

            dgrGrillaCabecera.DataSource = ""
            dgrGrillaCabecera.DataBind()

            dgrGrillaDetalle.DataSource = arrConsulta
            dgrGrillaDetalle.DataBind()

    End Sub

    Private Sub dgrGrillaDetalle_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrGrillaDetalle.PageIndexChanged
        dgrGrillaDetalle.CurrentPageIndex = e.NewPageIndex
        CargarGrid()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Try
            Dim oTransaccion As New MaestroNegocio
            Dim oBLCanalPdv As New BLCanalPDV

            ' Guardar los valores de PuntoVenta y Vendedor en sus respectivos DDL
            If hidPuntoVenta.Value = "" Then hidPuntoVenta.Value = "0;TODOS"
            ddlPuntoVenta.SelectedItem.Value = hidPuntoVenta.Value.Split(";"c)(0)
            ddlPuntoVenta.SelectedItem.Text = hidPuntoVenta.Value.Split(";"c)(1)

            oBLCanalPdv.COD_CANAL = ddlCanal.SelectedValue
            oBLCanalPdv.COD_PDV = ddlPuntoVenta.SelectedValue
            oBLCanalPdv.USUARIO_REG = CurrentUser

            Dim intRespuesta As Integer
            Dim strMensaje As String

            intRespuesta = oTransaccion.insertarBlackListCanalPdv(oBLCanalPdv)

            Select Case intRespuesta
                Case 0
                    strMensaje = "Hubo un problema al intentar guardar los datos"
                Case -1
                    strMensaje = "Hubo un problema al intentar guardar los datos"
                Case -2
                    strMensaje = "El registro ya existe"
                Case -3
                    strMensaje = "Elimine los registros existentes para registrar TODOS los Puntos de Venta."
                Case -4
                    strMensaje = "Elimine el registro de TODOS los Puntos de Venta para poder ingresar la combinación seleccionada."
                Case 1
                    strMensaje = "Registro grabado satisfactoriamente."
            End Select

            RegisterStartupScript("script1", "<script>alert('" + strMensaje + "')</script>")
            CargarPuntoVenta()
            CargarGrid()
            If intRespuesta = 1 Then InsertarLogAuditoria("Se agrega al blacklist el Canal: " & ddlCanal.SelectedItem.Text & ", vinculado al Punto de Venta: " & hidPuntoVenta.Value.Split(";"c)(1), "inserción", True, "CONS_COD_MANT_BL_CANALPDV_INS")
            ddlCanal.SelectedIndex = -1
            ddlPuntoVenta.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
            CargarPuntoVenta()
            CargarGrid()
            ddlCanal.SelectedIndex = -1
            ddlPuntoVenta.SelectedIndex = -1
        End Try

    End Sub

    Private Sub btnEliminar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.ServerClick

        Dim Msg As String
        Dim resultado As Boolean
        Dim iCodigo As Integer

            Dim oTransaccion As New MaestroNegocio
            iCodigo = CheckInt(hidCodigo.Value)
            If oTransaccion.eliminarBlackListCanalPdv(iCodigo, Msg) Then
                CargarGrid()
            End If
            InsertarLogAuditoria("Se eliminó del blacklist el registro de ID: " & iCodigo.ToString, "eliminación", True, "CONS_COD_MANT_BL_CANALPDV_DEL")


    End Sub

#Region "Metodos de Registro de Auditoria"
    Private Sub InsertarLogAuditoria(ByVal strDesTrans As String, ByVal accion As String, ByVal evento_anthem As Boolean, ByVal NombreConstCodAuditoria As String)
        'Inserción del Log de Auditoria
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal
            Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
            Dim strNomAplica As String = ConfigurationSettings.AppSettings("NombreAplicacion")

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

            Dim strTransaccion As String = ConfigurationSettings.AppSettings(NombreConstCodAuditoria)

            Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class