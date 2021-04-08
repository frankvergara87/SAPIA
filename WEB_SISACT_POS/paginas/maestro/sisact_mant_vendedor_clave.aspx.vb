Option Strict Off
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Web.Funciones.Comunes
Imports Claro.SisAct.Common
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Collections


Public Class sisact_mant_vendedor_clave
    Inherits SisAct_WebBase
    Dim strScript As String
    Dim objLog As New SISACT_Log
    Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("Log_Cambio Clave Usuario")

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTipoMant As System.Web.UI.WebControls.Label
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBusUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgCabUsuario As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgUsuario As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMostrar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDniUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtClaveGen As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidErrorMensaje As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombreUsuario As System.Web.UI.WebControls.TextBox

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

        Session("codProExt") = Perfil()

        If Not IsPostBack Then
            inicio(False)
        Else
            Dim proceso As String = hidProceso.Value
            Select Case proceso
                Case "GenerarClave"
                    Dim sNuevaClave As String = GenNuevaClave() 'GENERA Nueva Clave
                    txtClaveGen.Text = sNuevaClave
                Case "GuardarClave"
                    GuardarClave()
                Case "Buscar"
                    inicio()
            End Select
        End If

    End Sub

    Private Sub GuardarClave()
        Dim oConsulta As New MaestroNegocio
        Dim item As New Vendedor
        Dim msg As String = ""
        Dim estado As Integer = 0
        Dim resultado As Boolean = False
        Dim erro As String = ""

        Dim objLog As New SISACT_Log

        item.NombreCompleto = txtNombreUsuario.Text.Trim
        item.NumeroDocumento = txtDniUsuario.Text.Trim
        item.PuntoVentaId = Session("ALMACEN")
        item.Clave = txtClaveGen.Text.Trim
        item.UsuarioModificacionId = Session("USUARIO")
        Dim strCodActualizarClave As String = ConfigurationSettings.AppSettings("CONS_UPD_CLAVE_VEND")

        objLog.Log_WriteLog(strArchivoLOG, "****************** INICIO ActualizarVendedorClave ******************")
        objLog.Log_WriteLog(strArchivoLOG, "  PARAMETROS")
        objLog.Log_WriteLog(strArchivoLOG, "  NombreCompleto         : " & item.NombreCompleto)
        objLog.Log_WriteLog(strArchivoLOG, "  NumeroDocumento        : " & item.NumeroDocumento)
        objLog.Log_WriteLog(strArchivoLOG, "  PuntoVentaId           : " & item.PuntoVentaId)
        objLog.Log_WriteLog(strArchivoLOG, "  UsuarioModificacionId  : " & item.UsuarioModificacionId)
        objLog.Log_WriteLog(strArchivoLOG, "  Clave                  : " & item.Clave)
        objLog.Log_WriteLog(strArchivoLOG, "------------------------------------------------------")
        Try
            resultado = oConsulta.ActualizarVendedorClave(item, estado, msg)
            objLog.Log_WriteLog(strArchivoLOG, "  RESULTADO              : " & resultado.ToString())
        Catch ex As Exception
            erro = ex.Message().ToString
            objLog.Log_WriteLog(strArchivoLOG, "  ERROR                  : " & erro)
        End Try
        objLog.Log_WriteLog(strArchivoLOG, "****************** FIN ActualizarVendedorClave ******************")

        If resultado = True Then
            Auditoria(strCodActualizarClave, "El usuario " & Session("USUARIO") & " actualizó la clave del Vendeor " & item.NombreCompleto & " con DNI:" & item.NumeroDocumento)
            inicio()
        Else
            hidProceso.Value = "ERROR"
            hidErrorMensaje.Value = erro
        End If

        txtClaveGen.Text = ""
    End Sub

    Private Function GenNuevaClave() As String
        Dim rand As New Random

        Dim numerosPermitidos() As Char = "123456789".ToCharArray() 'Excluir 0
        Dim alphaPermitidos() As Char = "ABCDEFGHIJKLMNPQRSTUVWXYZ".ToCharArray() 'Excluir O

        Dim final As String = String.Empty

        final += numerosPermitidos(rand.Next(numerosPermitidos.Length - 1))
        final += alphaPermitidos(rand.Next(alphaPermitidos.Length - 1))

        Return final

    End Function

    Protected Function Perfil() As String

        objLog.Log_WriteLog(strArchivoLOG, "------------------PERFIL--------------------")

        Dim objAuditoriaWS As New AuditoriaWS.EbsAuditoriaService
        Dim oAccesoRequest As New AuditoriaWS.AccesoRequest
        Dim oAccesoResponse As New AuditoriaWS.AccesoResponse

        objAuditoriaWS.Url = ConfigurationSettings.AppSettings("consRutaWSSeguridad").ToString()
        objAuditoriaWS.Credentials = System.Net.CredentialCache.DefaultCredentials
        oAccesoRequest.usuario = Me.CurrentUser
        oAccesoRequest.aplicacion = ConfigurationSettings.AppSettings("CodigoAplicacion").ToString()

        objLog.Log_WriteLog(strArchivoLOG, "usuario: " & oAccesoRequest.usuario)
        objLog.Log_WriteLog(strArchivoLOG, "aplicacion: " & oAccesoRequest.aplicacion)

        objLog.Log_WriteLog(strArchivoLOG, "-----leerDatosUsuario---")

        oAccesoResponse = objAuditoriaWS.leerDatosUsuario(oAccesoRequest)

        objLog.Log_WriteLog(strArchivoLOG, "-----fin leerDatosUsuario---")

        Dim arrayOpcion As ArrayList
        Dim oConsulta As New MaestroNegocio

        arrayOpcion = oConsulta.ListaParametrosGrupo(CInt(ConfigurationSettings.AppSettings("CodigoGrupoProveedorExterno")))
        objLog.Log_WriteLog(strArchivoLOG, "arrayOpcion: " & arrayOpcion.Count)
        Dim objParamPerfil As Parametro = New Parametro

        If oAccesoResponse.resultado.estado = "1" Then
            For Each item1 As Claro.SisAct.Negocios.AuditoriaWS.AuditoriaType In oAccesoResponse.auditoria.AuditoriaItem.item
                For Each item2 As Parametro In arrayOpcion
                    If item1.perfil = item2.Valor1 Then
                        objParamPerfil = item2
                        Return objParamPerfil.Valor.ToString()
                    End If
                Next
            Next
        End If
        Return Funciones.CheckStr(objParamPerfil.Valor)
    End Function

    Private Sub inicio(Optional ByVal buscar As Boolean = True)

        Dim lista As New ArrayList
        Dim oConsulta As New MaestroNegocio
        Dim flagBuscar As String = "2"

        Dim dni As String
        Dim item As New Vendedor
        Dim tipoUsuario As String

        item.VendedorId = 0

        Dim strCodigoUsuario As String
        Dim oUsuarioAux As Usuario
        Dim ListaTipoOficinaVenta As ArrayList
        Dim ListaPuntoVenta As ArrayList

        oUsuarioAux = oConsulta.ObtenerUsuarioLogin(CurrentUser())

        If Not (oUsuarioAux Is Nothing) Then
            strCodigoUsuario = CType(oUsuarioAux.UsuarioId(), String)
        End If

        ListaPuntoVenta = oConsulta.ListaPDVUsuario((CType(strCodigoUsuario, Int64)), ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

        For Each pdv As PuntoVenta In ListaPuntoVenta
            If pdv.OVENV_DESCRIPCION.Length > 0 Then
                Session("ALMACEN") = pdv.OVENC_CODIGO
                Exit For
            End If
        Next

        item.PuntoVentaId = Session("ALMACEN")
        'Nombre
        item.Nombre = txtBusUsuario.Text.Trim.ToUpper
        'Documento
        item.NumeroDocumento = txtBusUsuario.Text.Trim.ToUpper

        Dim objLog As New SISACT_Log

        If buscar = True Then

            If ddlBusqueda.SelectedItem.Value = "1" Then
                txtBusUsuario.CssClass = "clsInputDisable"
                txtBusUsuario.ReadOnly = True
            Else
                txtBusUsuario.CssClass = "clsInputEnable"
                txtBusUsuario.ReadOnly = False
            End If
            objLog.Log_WriteLog(strArchivoLOG, "****************** INICIO ListaVendedorClave ******************")
            objLog.Log_WriteLog(strArchivoLOG, "  PARAMETROS")
            objLog.Log_WriteLog(strArchivoLOG, "  NombreCompleto         : " & item.NombreCompleto)
            objLog.Log_WriteLog(strArchivoLOG, "  NumeroDocumento        : " & item.NumeroDocumento)
            objLog.Log_WriteLog(strArchivoLOG, "  PuntoVentaId           : " & item.PuntoVentaId)
            objLog.Log_WriteLog(strArchivoLOG, "  Tipo de Busqueda       : " & ddlBusqueda.SelectedItem.Value)

            Dim prom_ext As String = CheckStr(Session("codProExt"))

            If prom_ext <> "" Then
                lista = oConsulta.ListaVendedorClavePro(item, ddlBusqueda.SelectedItem.Value, prom_ext)
            Else
            lista = oConsulta.ListaVendedorClave(item, ddlBusqueda.SelectedItem.Value)
            End If

            objLog.Log_WriteLog(strArchivoLOG, "------------------------------------------------------")
            objLog.Log_WriteLog(strArchivoLOG, " Total de Registros Encontrados: " & lista.Count)
            objLog.Log_WriteLog(strArchivoLOG, "****************** FIN ListaVendedorClave ******************")

            oConsulta = Nothing
            cargarListaUsuario(lista)
        ElseIf buscar = False Then
            Dim listaTipoBusqueda As New ArrayList
            Dim item1 As New ItemGenerico
            Dim arrCriteriosBusq As String() = ConfigurationSettings.AppSettings("CONS_LISTA_BUSQUEDA_VENDEDOR_DAC").Split("|")
            Dim arrItem As String()
            Dim strCriterio As String

            For Each strCriterio In arrCriteriosBusq
                item1 = New ItemGenerico
                arrItem = strCriterio.Split(":")
                item1.Codigo = arrItem(0)
                item1.Descripcion = arrItem(1)
                listaTipoBusqueda.Add(item1)
            Next

            With ddlBusqueda
                .DataSource = listaTipoBusqueda
                .DataValueField = "Codigo"
                .DataTextField = "Descripcion"
                .DataBind()
            End With
        End If

        hidMostrar.Value = "Listado"
        hidProceso.Value = ""

    End Sub

    Private Sub cargarListaUsuario(ByVal lista As ArrayList)
        dgCabUsuario.DataSource = ""
        dgCabUsuario.DataBind()
        dgUsuario.DataSource = lista
        dgUsuario.DataBind()
    End Sub

    Public Sub Auditoria(ByVal strTransaccion As String, ByVal strDesTrans As String)

        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        Dim usuario_id As String = CurrentUser
        Dim ipcliente As String = CurrentTerminal
        Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
        Dim strNomAplica As String = ConfigurationSettings.AppSettings("NombreAplicacion")
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

        Dim objLog As New SISACT_Log

        objLog.Log_WriteLog(strArchivoLOG, "****************** INICIO registrarAuditoria ******************")
        objLog.Log_WriteLog(strArchivoLOG, "  PARAMETROS")
        objLog.Log_WriteLog(strArchivoLOG, "  strTransaccion    : " & strTransaccion)
        objLog.Log_WriteLog(strArchivoLOG, "  strDesTrans    : " & strDesTrans)
        objLog.Log_WriteLog(strArchivoLOG, "  strCodServ        : " & strCodServ)
        objLog.Log_WriteLog(strArchivoLOG, "  ipcliente         : " & ipcliente)
        objLog.Log_WriteLog(strArchivoLOG, "  nombreHost        : " & nombreHost)
        objLog.Log_WriteLog(strArchivoLOG, "  ipServer          : " & ipServer)
        objLog.Log_WriteLog(strArchivoLOG, "  nombreServer      : " & nombreServer)
        objLog.Log_WriteLog(strArchivoLOG, "  usuario_id        : " & usuario_id)
        objLog.Log_WriteLog(strArchivoLOG, "  ----------------------------------------------")
        Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)
        objLog.Log_WriteLog(strArchivoLOG, "  RESULTADO         :" & flag.ToString())
        objLog.Log_WriteLog(strArchivoLOG, "****************** FIN registrarAuditoria ******************")

        If flag = False Then
            strScript += "alert('No se pudo registrar en Auditoria');"
        End If
    End Sub

End Class
