Option Strict Off
Imports System.IO
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Web.Funciones.Comunes
Imports Claro.SisAct.Common
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common.Funciones
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Collections
Imports ABCUpload4

Public Class sisact_mant_vendedores_dac
    Inherits SisAct_WebBase
    Dim FlagFortelCadena As String = "0"

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtBusUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgCabUsuario As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidProceso As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMostrar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCantidadUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtCodUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombreUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlTipoOficina As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDgUsuario_CodUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents hidListaTipoUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodVendedor As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFlagTipoUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOficinaId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNuevoUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblTipoMant As System.Web.UI.WebControls.Label
    'Protected WithEvents hidTipoUsuarioId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents rbListaTipoUsuario As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents hidTipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDistribuidorId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntoVentaId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumentoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfiles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlBusqueda As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDireccion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaNacimiento As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidEstadoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoDocumento As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumeroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgUsuario As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chbVerificacionReniec As System.Web.UI.WebControls.CheckBox
    Protected WithEvents hidVerRen As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDistribuidor As System.Web.UI.WebControls.Label
    Protected WithEvents hidCountEstados As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidMostrarUsuarioBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDniBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombreBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidDireccionBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFechaNacimientoBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVendedorIdBD As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents cu As System.Web.UI.HtmlControls.HtmlInputHidden
    'Protected WithEvents btnAceptar As System.Web.UI.WebControls.Button

    Protected WithEvents hidPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtNumeroCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidNumeroCelularBD As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdCodPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdDesPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtBusPDV As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgCabPdv As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgPdv As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidTipoUsuarioId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodigoPDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombrePDV As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLogin As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEstadoUsuario As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlBusquedaPDV As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTipoMantPDV As System.Web.UI.WebControls.Label
    Protected WithEvents lblTipoPdv As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProv_Exte As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblProvExter As System.Web.UI.WebControls.Label
    Protected WithEvents hidPExterno As System.Web.UI.WebControls.Label
    Protected WithEvents hdPExt As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCargar As System.Web.UI.WebControls.Button
    Protected WithEvents lblRegistrados As System.Web.UI.WebControls.Label
    Protected WithEvents lblNoRegistrados As System.Web.UI.WebControls.Label
    Protected WithEvents txtListaNoCargaron As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtListaBlack As System.Web.UI.WebControls.TextBox
    Protected WithEvents FileToUpload As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents hidLimpiarMasi As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMensaje As System.Web.UI.HtmlControls.HtmlInputHidden

    'Protected WithEvents txtCampania As System.Web.UI.WebControls.TextBox

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
    Dim strArchivoLOG As String = New SISACT_Log().Log_CrearNombreArchivo("LOG_MANTENIMIENTO REPORTE DAC")

#Region "PROY 16359 - IDEA 19861"
    Private rutaOrigen As String = ConfigurationSettings.AppSettings("consRutaOrigenLpPa")
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

        Dim login As String = Me.CurrentUser
        hidUsuario.Value = login

        Dim opcionDistribuidor As String = ConfigurationSettings.AppSettings("DistribuidorClaro")
        Dim opcionUniversidad As String = ConfigurationSettings.AppSettings("UniversidadClaro")
        Dim opcionSoporteOpe As String = ConfigurationSettings.AppSettings("SoporteOperacional")
        Dim opcionFortelMantCliente As String = ConfigurationSettings.AppSettings("FortelMantVendedor")
        Dim objLoginUsuario As New LoginUsuarioNegocios
        Dim opciones As String = ""

        Dim codUsuarioSisact As Int64 = CheckInt64(Session("codUsuarioSisact"))
        Dim codAplicacion As Int64 = CheckInt64(ConfigurationSettings.AppSettings("CodigoAplicacion"))
        Dim arrayOpciones As ArrayList = objLoginUsuario.ListarOpcionesPagina(codUsuarioSisact, codAplicacion)
        Dim script As String

        For Each item1 As ItemGenerico In arrayOpciones
            opciones &= "," & item1.Descripcion
        Next

        Session("codProExt") = Perfil()

        If Session("codProExt") = "" Then
            If opciones.IndexOf(opcionFortelMantCliente) >= 0 Then
                FlagFortelCadena = "1"
                hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor")
            ElseIf opciones.IndexOf(opcionDistribuidor) >= 0 Then
                hidPerfiles.Value = ConfigurationSettings.AppSettings("DistribuidorClaro")
            ElseIf opciones.IndexOf(opcionUniversidad) >= 0 Then
                hidPerfiles.Value = ConfigurationSettings.AppSettings("UniversidadClaro")
            ElseIf opciones.IndexOf(opcionSoporteOpe) >= 0 Then
                hidPerfiles.Value = ConfigurationSettings.AppSettings("SoporteOPeracional")
            Else
                Response.Write("<script language=javascript>alert('No tiene un perfil asignado');</script>")
                Exit Sub
            End If
        Else
            hidPerfiles.Value = ConfigurationSettings.AppSettings("PerfilProvExt")
        End If

        'hidPerfiles.Value = "SACT_DIST"
        'hidPerfiles.Value = "SACT_UCL"
        'hidPerfiles.Value = "SACT_SOP"

        Dim oConsulta As New MaestroNegocio
        If hidPerfiles.Value = ConfigurationSettings.AppSettings("DistribuidorClaro") Then
            hidDistribuidorId.Value = oConsulta.ConsultarDac(hidUsuario.Value)
        End If

        If Not IsPostBack Then

            inicioPDV()

            'Obtengo el tipo y la descripcion del Punto de Venta del Usuario
            Dim oUsuarioAux As Usuario
            Dim ListaTipoOficinaVenta As ArrayList
            Dim ListaPuntoVenta As ArrayList

            oUsuarioAux = oConsulta.ObtenerUsuarioLogin(CurrentUser())

            If Not (oUsuarioAux Is Nothing) Then
                cu.Value = CType(oUsuarioAux.UsuarioId(), String)
            End If

            ListaTipoOficinaVenta = oConsulta.ListaTipoOficinaVentaUsuario(CType(cu.Value, Int64), ConfigurationSettings.AppSettings("constCodTipoProductoCON"))
            ListaPuntoVenta = oConsulta.ListaPDVUsuario((CType(cu.Value, Int64)), ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

            For Each tipo As ItemGenerico In ListaTipoOficinaVenta
                If tipo.Descripcion.Length > 0 Then
                    lblTipoPdv.Text = tipo.Descripcion
                    Exit For
                End If
            Next

            For Each pdv As PuntoVenta In ListaPuntoVenta
                If pdv.OVENV_DESCRIPCION.Length > 0 Then
                    lblDistribuidor.Text = pdv.OVENV_DESCRIPCION
                    hidPuntoVentaId.Value = pdv.OVENC_CODIGO
                    Exit For
                End If
            Next

            hidMostrar.Value = "DistribuidorClaro"

            inicio(False)

            Select Case hidPerfiles.Value

                Case ConfigurationSettings.AppSettings("UniversidadClaro")
                    lblTipoMant.Text = "Mantenimiento Universidad Claro"
                    hidTipo.Value = "UniversidadClaro"
                    chbVerificacionReniec.Enabled = True
                Case ConfigurationSettings.AppSettings("DistribuidorClaro")
                    lblTipoMant.Text = "Mantenimiento Vendedores"
                    hidTipo.Value = "VendedorDac"

                Case ConfigurationSettings.AppSettings("SoporteOperacional")
                    lblTipoMant.Text = "Mantenimiento Soporte Operacional"
                    hidTipo.Value = "SoporteOperacional"

                Case ConfigurationSettings.AppSettings("FortelMantVendedor")
                    lblTipoMant.Text = "Mantenimiento Soporte Operacional - Fortel"
                    hidTipo.Value = "FortelMantVendedor"

                Case ConfigurationSettings.AppSettings("PerfilProvExt")
                    lblTipoMant.Text = "Mantenimiento Vendedores - Proveedor Externo"
                    hidTipo.Value = "ProveedorExterno"

            End Select
            cargarTipoDocumento()
        Else
            Dim proceso As String = hidProceso.Value
            Select Case proceso
                Case "Grabar"
                    GrabarVendedorDac()
                Case "Modificar"

                    If (hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor") Or hidPerfiles.Value = ConfigurationSettings.AppSettings("PerfilProvExt")) Then

                        Dim lista As New ArrayList

                        Dim prom_ext As String = CheckStr(Session("codProExt"))
                        Dim codgrupo As String = ConfigurationSettings.AppSettings("CodigoGrupoProveedorExterno")

                        If prom_ext <> "" Then
                            lista = oConsulta.ListaOficinaVentaPro(hidPuntoVentaId.Value, 1, "", prom_ext, codgrupo)
                        Else
                            lista = oConsulta.ListaBuscarOficinaVenta(hidPuntoVentaId.Value, 1, "", codgrupo)
                        End If

                        If lista.Count = 1 Then
                            Dim objVenta As PuntoVenta = lista("0")
                            lblDistribuidor.Text = objVenta.OVENV_DESCRIPCION
                            hdCodPDV.Value = objVenta.OVENC_CODIGO
                            hdDesPDV.Value = objVenta.OVENV_DESCRIPCION
                            hidPuntoVentaId.Value = objVenta.OVENC_CODIGO
                            lblTipoPdv.Text = objVenta.TOFIV_DESCRIPCION
                        End If

                    End If

                    Dim estadoId As String = hidEstadoId.Value
                    cargarDetalleEstado(estadoId)
                    cargarEstado()
                    If hidPerfiles.Value = ConfigurationSettings.AppSettings("UniversidadClaro") Then
                        If hidVerRen.Value = "1" Then
                            chbVerificacionReniec.Checked = True
                            chbVerificacionReniec.Enabled = False
                        Else
                            chbVerificacionReniec.Checked = False
                            chbVerificacionReniec.Enabled = True
                        End If
                    End If
                    ddlTipoDocumento.SelectedValue = Request("hidTipoDocumento")
                    ddlTipoDocumento.Enabled = False

                Case "Buscar"
                    inicio()
                Case "BuscarPDV"
                    cargargrdid()
                Case "PDV"
                    lblDistribuidor.Text = hdDesPDV.Value
                    hidPuntoVentaId.Value = hdCodPDV.Value
                    lblTipoPdv.Text = "CORNER"
                    txtProv_Exte.Text = hdPExt.Value
                Case "Limpiar"
                    dgCabPdv.DataSource = ""
                    dgCabPdv.DataBind()
                    dgPdv.DataSource = ""
                    dgPdv.DataBind()
                    hidProceso.Value = "BuscarPDV"
                Case "Cancelar"
                    dgCabPdv.DataSource = ""
                    dgCabPdv.DataBind()
                    dgPdv.DataSource = ""
                    dgPdv.DataBind()
                Case "CargaMasiva"
                    If (hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor")) Then
                        txtListaNoCargaron.Text = ""
                        txtListaBlack.Text = ""
                        lblRegistrados.Text = ""
                        lblNoRegistrados.Text = ""
                    Else
                        Me.btnCargar.Enabled = False
                    End If

            End Select
        End If
    End Sub

    Private Sub inicio(Optional ByVal buscar As Boolean = True)
        Dim lista As New ArrayList
        Dim oConsulta As New MaestroNegocio
        Dim flagBuscar As String = "2"
        Dim nombre As String
        Dim dni As String
        Dim item As New Vendedor
        Dim tipoUsuario As String
        item.Nombre = txtBusUsuario.Text.Trim.ToUpper
        item.VendedorId = 0
        item.PuntoVentaId = hidPuntoVentaId.Value
    
        If buscar = True Then

            If ddlBusqueda.SelectedItem.Value = "0" Then
                nombre = txtBusUsuario.Text.Trim
            ElseIf ddlBusqueda.SelectedItem.Value = "1" Then
                nombre = ""
            ElseIf ddlBusqueda.SelectedItem.Value = "2" Or ddlBusqueda.SelectedItem.Value = "5" Then
                item.NumeroDocumento = txtBusUsuario.Text.Trim.ToUpper
            End If

            Dim prom_ext As String = CheckStr(Session("codProExt"))
            Dim codgrupo As String = ConfigurationSettings.AppSettings("CodigoGrupoProveedorExterno")
            'Si es OVERAL o ADECCO nueva busqueda sino como esta
            If prom_ext <> "" Then
                lista = oConsulta.ListaVendedorExt(item, ddlBusqueda.SelectedItem.Value, hidDistribuidorId.Value, hidPerfiles.Value, FlagFortelCadena, prom_ext, codgrupo)
            Else
                lista = oConsulta.ListaVendedor(item, ddlBusqueda.SelectedItem.Value, hidDistribuidorId.Value, hidPerfiles.Value, FlagFortelCadena, codgrupo)
            End If

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
        hidCantidadUsuario.Value = Funciones.CheckStr(lista.Count)
        hidProceso.Value = ""

    End Sub

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

    Private Sub inicioPDV()
        Dim item1 As New ItemGenerico
        Dim item2 As New ItemGenerico
        Dim listaTipoBusqueda As New ArrayList
        item1.Codigo = "0"
        item1.Descripcion = "Nombre PDV"
        listaTipoBusqueda.Insert(0, item1)

        item2.Codigo = "1"
        item2.Descripcion = "Codigo PDV"
        listaTipoBusqueda.Insert(1, item2)

        With ddlBusquedaPDV
            .DataSource = listaTipoBusqueda
            .DataValueField = "Codigo"
            .DataTextField = "Descripcion"
            .DataBind()
        End With 'BORRAR
    End Sub

    Private Sub cargarListaUsuario(ByVal lista As ArrayList)
        dgCabUsuario.DataSource = ""
        dgCabUsuario.DataBind()
        dgUsuario.DataSource = lista
        dgUsuario.DataBind()
    End Sub

    Private Sub GrabarVendedorDac()
        Dim tipoUsuario As String
        Dim listaTipo As New ArrayList
        Dim item As New Vendedor
        Dim itemVendedorExistente As New Vendedor
        Dim fechaReg As String
        Dim fechaMod As String

        Dim PuntoVenta As String

        PuntoVenta = Session("ALMACEN")
        If hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor") Then
            PuntoVenta = hdCodPDV.Value
        End If

        item.PuntoVentaId = PuntoVenta
        item.NumeroCelular = txtNumeroCelular.Text.Trim
        item.VendedorId = Funciones.CheckInt(txtCodUsuario.Text)
        item.Nombre = txtNombreUsuario.Text.Trim
        item.TipoDocumento = ddlTipoDocumento.SelectedValue
        item.NumeroDocumento = txtNumeroDocumento.Text.Trim.ToUpper
        item.Direccion = txtDireccion.Text.Trim
        item.FechaNacimiento = txtFechaNacimiento.Text.Trim
        item.NumeroCelular = txtNumeroCelular.Text.Trim

        If ddlEstado.SelectedValue.ToString.Equals("00") Or ddlEstado.SelectedValue.ToString.Equals("") Then
            item.EstadoId = hidEstadoId.Value
        Else
            item.EstadoId = ddlEstado.SelectedValue
        End If

        item.distribuidorId = hidDistribuidorId.Value
        item.UsuarioRegistroId = hidUsuario.Value
        item.UsuarioModificacionId = hidUsuario.Value
        item.Motivo = txtMotivo.Text

        item.PuntoVentaId = hidPuntoVentaId.Value

        If (hidPerfiles.Value <> ConfigurationSettings.AppSettings("DistribuidorClaro")) Then
            If (chbVerificacionReniec.Checked) Then
                item.VerificacionReniec = "1"
            Else
                item.VerificacionReniec = "0"
            End If
        Else
            item.VerificacionReniec = "0"
        End If

        Dim oMantMaestro As New MaestroNegocio
        Dim flagContinuar As String = "0"
        Dim curSalida As Integer
        Dim msg As String = ""

        Dim descripcion_error As String = ""

        Dim msgBlackList As String = ""
        Dim msgDniVendedor As String = ""
        Dim resultado As Boolean = False
        Dim valBlackList As Boolean = False
        Dim validar As Boolean

        Try
            valBlackList = oMantMaestro.ValidarBlackList(item, msg)
            If valBlackList = True Then
                msgBlackList = "No se puede registrar el Vendedor. Contactarse con Soporte Operacional (soporteoperacional@claro.com.pe)"
                hidMsg.Value = msgBlackList
                inicio()
                Exit Sub
            Else
                resultado = oMantMaestro.GrabarVendedor(item, curSalida, msg, itemVendedorExistente)
                hidMsg.Value = msg

                'Coloca los datos y los pone como no editables
                If item.VendedorId <> itemVendedorExistente.VendedorId Then
                    If (hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor")) Then
                        Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SACT_ACTVEN_FORTEL"), "Actualiza Vendedor Fortel")
                    Else
                        Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SACT_INSVEN"), "Registra Vendedor")
                    End If			
                    hidMostrarUsuarioBD.Value = "SI"
                    hidVendedorIdBD.Value = itemVendedorExistente.VendedorId.ToString
                    hidDniBD.Value = itemVendedorExistente.NumeroDocumento
                    hidNombreBD.Value = itemVendedorExistente.NombreCompleto
                    hidDireccionBD.Value = itemVendedorExistente.Direccion
                    hidFechaNacimientoBD.Value = itemVendedorExistente.FechaNacimiento.Substring(0, 10)
                Else
                    If (hidPerfiles.Value = ConfigurationSettings.AppSettings("FortelMantVendedor")) Then
                        Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SACT_INSVEN_FORTEL"), "Registra Vendedor Fortel")
                    Else					
                        Auditoria(ConfigurationSettings.AppSettings("CONS_COD_SACT_ACTVEN"), "Actualiza Vendedor")
                    End If
                    'Falta validar esconder el boton grabar cuando no se ha actualizado
                    hidMostrarUsuarioBD.Value = "NO"
                    hidVendedorIdBD.Value = ""
                    hidDniBD.Value = ""
                    hidNombreBD.Value = ""
                    hidDireccionBD.Value = ""
                    hidFechaNacimientoBD.Value = ""
                    hidNumeroCelularBD.Value = ""
                End If

            End If
        Catch ex As Exception
            Dim erro As String = ex.Message().ToString
        End Try

        If resultado = True Then

            dgCabPdv.DataSource = ""
            dgCabPdv.DataBind()
            dgPdv.DataSource = ""
            dgPdv.DataBind()

            inicio()
        Else
            hidProceso.Value = ""
        End If

    End Sub

    Private Sub cargarDetalleEstado(ByVal estadoId As String)
        cargarEstado()
    End Sub

    Private Sub cargarEstado()
        Dim lista As New ArrayList
        Dim oMantMaestro As New MaestroNegocio
        lista = oMantMaestro.ListaEstadosHabilitados(hidPerfiles.Value, hidEstadoId.Value)
        oMantMaestro = Nothing

        hidCountEstados.Value = lista.Count.ToString

        Dim oestado As New Estado
        oestado.ESTAC_CODIGO = "00"
        oestado.ESTAV_DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
        lista.Insert(0, oestado)

        With ddlEstado
            .DataSource = lista
            .DataValueField = "ESTAC_CODIGO"
            .DataTextField = "ESTAV_DESCRIPCION"
            .DataBind()
            .Visible = True
        End With

    End Sub

    Private Sub cargarTipoDocumento()
        Dim lista As New ArrayList
        Dim oMantMaestro As New MaestroNegocio
        lista = oMantMaestro.ListaTipoDocumento("")
        oMantMaestro = Nothing
        Dim otipodocumento As New ItemGenerico
        otipodocumento.Codigo = "00"
        otipodocumento.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
        lista.Insert(0, otipodocumento)
        With ddlTipoDocumento
            .DataSource = lista
            .DataValueField = "Codigo"
            .DataTextField = "Descripcion"
            .DataBind()
            'Solo DNI para este mantenimiento
            .SelectedValue = "01"

        End With

        ddlTipoDocumento.Items.RemoveAt(2)
        ddlTipoDocumento.Items.RemoveAt(3)
        ddlTipoDocumento.Items.RemoveAt(3)

    End Sub

    Private Sub Auditoria(ByVal strTransaccion As String, ByVal strDesTransaccion As String)
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim nombreServer As String = System.Net.Dns.GetHostName
        Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
        Dim usuario_id As String = CurrentUser
        Dim ipcliente As String = CurrentTerminal
        Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")

        Dim strNomVendedor As String = txtNombreUsuario.Text.Trim
        Dim strDistribuidor As String = lblDistribuidor.Text.Trim
        Dim strTipoDocumento As String = ddlTipoDocumento.SelectedItem.Text.Trim
        Dim strNumeroDocumento As String = txtNumeroDocumento.Text.Trim
        Dim strEstado As String
        If ddlEstado.Visible = False Or ddlEstado.SelectedValue = "00" Then
            strEstado = "NUEVO"
        Else
            strEstado = ddlEstado.SelectedItem.Text
        End If


        Dim strDesTrans As String = strDesTransaccion & " | Vendedor: " & strNomVendedor & " | Tipo Documento: " & strTipoDocumento & " | Nro Documento: " & strNumeroDocumento & " | Estado: " & strEstado & " | Distribuidor: " & strDistribuidor
        Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")

        Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)

    End Sub

    Private Sub cargargrdid()

        Dim lista As New ArrayList
        Dim oConsulta As New MaestroNegocio

        Dim prom_ext As String = CheckStr(Session("codProExt"))
        Dim codgrupo As String = ConfigurationSettings.AppSettings("CodigoGrupoProveedorExterno")
        'Si es OVERAL o ADECCO nueva busqueda sino como esta
        If prom_ext <> "" Then
            lista = oConsulta.ListaOficinaVentaPro(txtBusPDV.Text, ddlBusquedaPDV.SelectedValue, ConfigurationSettings.AppSettings("CacCorner"), prom_ext, codgrupo)
        Else
            lista = oConsulta.ListaBuscarOficinaVenta(txtBusPDV.Text, ddlBusquedaPDV.SelectedValue, ConfigurationSettings.AppSettings("CacCorner"), codgrupo)
        End If

        oConsulta = Nothing

        dgCabPdv.DataSource = ""
        dgCabPdv.DataBind()
        dgPdv.DataSource = lista
        dgPdv.DataBind()

    End Sub

#Region "PROY 16359 - IDEA 19861"
    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        objLog.Log_WriteLog(strArchivoLOG, "INICIO btnCargar_Click()")
        objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        Try

            If FileToUpload.Value <> "" Then
                If (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper = ".CSV" Then
                    Dim mensaje As String = ""
                    Dim resultado As String = "False"

                    eliminarArchivo()
                    cargarArchivo()
                    resultado = procesarArchivo()

                    If (resultado = "True") Then
                        hidMensaje.Value = ""
                    Else
                        If resultado.IndexOf("The underlying") >= 0 Then
                            hidMensaje.Value = resultado + " :Error servicios validaciòn nùmero claro."
                        Else
                            hidMensaje.Value = resultado
                        End If
                    End If

                ElseIf (FileToUpload.Value.Substring(FileToUpload.Value.LastIndexOf("."), FileToUpload.Value.Length - FileToUpload.Value.LastIndexOf("."))).ToUpper <> ".CSV" Then
                    hidMensaje.Value = "Debe Ingresar un Archivo válido con extensión .CSV"
                End If
            Else
                hidMensaje.Value = "Debe Ingresar una Ruta de Archivo válida"
            End If
        Catch ex As Exception
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
            objLog.Log_WriteLog(strArchivoLOG, "Error :"&ex.Message)
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        Finally
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
            objLog.Log_WriteLog(strArchivoLOG, "FIN btnCargar_Click()")
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        End Try
    End Sub

    Public Sub eliminarArchivo()

        Dim strArchivo As String
        Dim strArchivoCargados As String
        Dim strArchivoError As String
        Try
            strArchivo = Server.MapPath(rutaOrigen) & "\" & "carga_masiva_venFort_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoCargados = Server.MapPath(rutaOrigen) & "\" & "lista_carga_venFort_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strArchivoError = Server.MapPath(rutaOrigen) & "\" & "error_carga_venFort_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            If File.Exists(strArchivo) Then
                System.IO.File.Delete(strArchivo)
            End If
            If File.Exists(strArchivoCargados) Then
                System.IO.File.Delete(strArchivoCargados)
            End If
            If File.Exists(strArchivoError) Then
                System.IO.File.Delete(strArchivoError)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub cargarArchivo()
        Dim RequestXForm As Object
        Dim objFilex As Object
        Dim strArchivo As String
        Dim strRutaWeb As String

        Try

            strArchivo = "Carga_Masiva_VendedorFortel_" & DateTime.Now.ToString("yyyyMMdd") & ".txt"
            strRutaWeb = Server.MapPath(rutaOrigen) & "\" & strArchivo
            
            FileToUpload.PostedFile.SaveAs(strRutaWeb)
            ViewState("FileCarga") = strArchivo


        Catch ex As Exception
            Dim mensaje = ex.Message
            FileToUpload.Dispose()
            RegisterStartupScript("script", "<script>alert('error al cargar el archivo');</script>")
        End Try
    End Sub

    Function procesarArchivo() As String
        objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        objLog.Log_WriteLog(strArchivoLOG, "INICIO procesarArchivo()")
        objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        Dim obj As New MaestroNegocio

        Dim archivo As String = ViewState("FileCarga")
        Dim re As StreamReader = New StreamReader(Server.MapPath(rutaOrigen) & "/" & archivo, Encoding.Default)

        Dim retorno As String = "True"
        Dim dr As DataRow
        Dim servicio As String

        Try
            txtListaNoCargaron.Text = ""
            txtListaBlack.Text = ""

            lblRegistrados.Text = ""
            lblNoRegistrados.Text = ""
            Dim webCosultaLinea As New ConsultaLinea

            Dim input As String
            input = re.ReadLine()

            Dim contError As Integer = 0
            Dim contCorrecto As Integer = 0
            Dim contBlack As Integer = 0

            Dim dtListaCorrecta As New DataTable
            Dim dtBlackList As New DataTable
            Dim dtListaError As New DataTable

            Dim dcTipoDocumento As New DataColumn("TIPO_DOCUMENTO", GetType(String))
            Dim dcNroDocumento As New DataColumn("NRO_DOCUMENTO", GetType(String))
            Dim dcEstado As New DataColumn("ESTADO", GetType(String))
            Dim dcNombres As New DataColumn("NOMBRES", GetType(String))
            Dim dcDireccion As New DataColumn("DIRECCION", GetType(String))
            Dim dcFechaNac As New DataColumn("FECHA_NACIMIENTO", GetType(String))
            Dim dcPDV As New DataColumn("PDV", GetType(String))
            Dim dcTipoPDV As New DataColumn("TIPO_PDV", GetType(String))
            Dim dcCelular As New DataColumn("CELULAR", GetType(String))
            Dim dcAccion As New DataColumn("ACCION", GetType(String))
            Dim msgError As String = ""
            Dim sAccion As String = ""


            dtListaCorrecta.Columns.Add(dcTipoDocumento)
            dtListaCorrecta.Columns.Add(dcNroDocumento)
            dtListaCorrecta.Columns.Add(dcEstado)
            dtListaCorrecta.Columns.Add(dcNombres)
            dtListaCorrecta.Columns.Add(dcDireccion)
            dtListaCorrecta.Columns.Add(dcFechaNac)
            dtListaCorrecta.Columns.Add(dcPDV)
            dtListaCorrecta.Columns.Add(dcTipoPDV)
            dtListaCorrecta.Columns.Add(dcCelular)
            dtListaCorrecta.Columns.Add(dcAccion)

            dtBlackList.Columns.Add(New DataColumn("TIPO_DOCUMENTO", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("NRO_DOCUMENTO", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("ESTADO", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("NOMBRES", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("DIRECCION", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("FECHA_NACIMIENTO", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("PDV", GetType(String)))
            dtBlackList.Columns.Add(New DataColumn("CELULAR", GetType(String)))

            dtListaError.Columns.Add(New DataColumn("TIPO_DOCUMENTO", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("NRO_DOCUMENTO", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("ESTADO", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("NOMBRES", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("DIRECCION", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("FECHA_NACIMIENTO", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("PDV", GetType(String)))
            dtListaError.Columns.Add(New DataColumn("CELULAR", GetType(String)))


            While Not input Is Nothing

                Dim vTipoDocumento As String = ""
                Dim vNroDocumento As String = ""
                Dim vEstado As String = ""
                Dim vNombres As String = ""
                Dim vDireccion As String = ""
                Dim vFechaNac As String = ""
                Dim vPDV As String = ""
                Dim vTipoPDV As String = ""
                Dim vCelular As String = ""
                Dim vCodDistribuidor As String = ""
                Dim vCantidad As Integer = 0

                Dim vSinEspacios As String = ""
                Dim bResultado As Boolean = True
                Dim bBlackList As Boolean = False
                Dim linea As String() = input.Split(",")


                If linea.Length = 9 Then

                    vTipoDocumento = (linea(0)).ToString()
                    vNroDocumento = (linea(1)).ToString()
                    vEstado = (linea(2)).ToString()
                    vNombres = (linea(3)).ToString()
                    vDireccion = (linea(4)).ToString()
                    vFechaNac = (linea(5)).ToString()
                    vPDV = (linea(6)).ToString()
                    vTipoPDV = (linea(7)).ToString()
                    vCelular = (linea(8)).ToString()
                    vCodDistribuidor = hidDistribuidorId.Value
                    vCantidad = linea.Length

                    vTipoDocumento = Trim(vTipoDocumento)
                    vNroDocumento = Trim(vNroDocumento)
                    vEstado = Trim(vEstado)
                    vNombres = Trim(vNombres)
                    vDireccion = Trim(vDireccion)
                    vFechaNac = Trim(vFechaNac)
                    vPDV = Trim(vPDV)
                    vTipoPDV = Trim(vTipoPDV)
                    vCelular = Trim(vCelular)
                    vCodDistribuidor = Trim(vCodDistribuidor)
                    vCantidad = linea.Length

                    If bResultado = True Then
                        If Not ValidacionClienteCSV(vCantidad, vTipoDocumento, vNroDocumento, vEstado, vNombres, vDireccion, vFechaNac, vPDV, vCelular) Then
                            bResultado = False
                        End If
                    End If

                    'VALIDACION SI EL NÙMERO ES CLARO
                    If bResultado = True Then

                        Dim EsClaroPostPago As Boolean = False
                        Dim EsClaroPrepago As Boolean = False

                        EsClaroPostPago = webCosultaLinea.ConsultaPostpago(vCelular)
                        EsClaroPrepago = webCosultaLinea.ConsultaPrepago(vCelular)

                        If Not (EsClaroPostPago OrElse EsClaroPrepago) Then
                            bResultado = False
                            objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - CELULAR (ES CLARO):" + "FALSO")
                        End If

                    End If


                    If bResultado = True Then

                        If Not (ValidacionTipoPDV(ConfigurationSettings.AppSettings("PDV_TIPOCORNER"), vPDV)) Then
                            bResultado = False
                            objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - PDV (PDV ES CORNER):" + "FALSO")
                        End If

                    End If


                    If bResultado = True Then

                        If ValidacionBlackList(vNroDocumento) Then
                            contBlack = contBlack + 1

                            dr = dtBlackList.NewRow
                            dr("TIPO_DOCUMENTO") = vTipoDocumento
                            dr("NRO_DOCUMENTO") = vNroDocumento
                            dr("ESTADO") = vEstado
                            dr("NOMBRES") = vNombres
                            dr("DIRECCION") = vDireccion
                            dr("FECHA_NACIMIENTO") = vFechaNac
                            dr("PDV") = vPDV
                            dr("CELULAR") = vCelular

                            dtBlackList.Rows.Add(dr)

                            bResultado = False
                            bBlackList = True
                            contError = contError + 1
                            objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NUMERO DOCUMENTO (EN BLACKLIST):" + "VERDADERO")
                        End If

                    End If


                    If bResultado = True Then

                        Dim item As New Vendedor
                        item.EstadoId = vEstado
                        item.PuntoVentaId = vPDV
                        item.NumeroCelular = vCelular
                        item.VendedorId = 0
                        item.Nombre = vNombres
                        item.TipoDocumento = vTipoDocumento
                        item.NumeroDocumento = vNroDocumento
                        item.Direccion = vDireccion
                        item.FechaNacimiento = vFechaNac
                        item.distribuidorId = ""

                        Dim oMantMaestro As New MaestroNegocio

                        If (oMantMaestro.ValidaNegocio(item, msgError, sAccion)) Then

                            contCorrecto = contCorrecto + 1
                            dr = dtListaCorrecta.NewRow
                            dr("TIPO_DOCUMENTO") = vTipoDocumento
                            dr("NRO_DOCUMENTO") = vNroDocumento
                            dr("ESTADO") = vEstado
                            dr("NOMBRES") = vNombres
                            dr("DIRECCION") = vDireccion
                            dr("FECHA_NACIMIENTO") = vFechaNac
                            dr("PDV") = vPDV
                            dr("TIPO_PDV") = vTipoPDV
                            dr("CELULAR") = vCelular
                            dr("ACCION") = sAccion
                            dtListaCorrecta.Rows.Add(dr)
                        Else
                            bResultado = False
                            objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NO HA PASADO LA VALIDACIÒN DE NEGOCIO")
                        End If

                    End If

                    If (bResultado = False And bBlackList = False) Then

                        dr = dtListaError.NewRow
                        dr("TIPO_DOCUMENTO") = vTipoDocumento
                        dr("NRO_DOCUMENTO") = vNroDocumento
                        dr("ESTADO") = vEstado
                        dr("NOMBRES") = vNombres
                        dr("DIRECCION") = vDireccion
                        dr("FECHA_NACIMIENTO") = vFechaNac
                        dr("PDV") = vPDV
                        dr("CELULAR") = vCelular

                        dtListaError.Rows.Add(dr)
                        contError = contError + 1
                    End If
                End If

                input = re.ReadLine()
            End While


            If dtListaCorrecta.Rows.Count > 0 Then
                Dim vDatos As String = ""
                Dim cont As Integer = 0
                For c As Integer = 0 To dtListaCorrecta.Rows.Count - 1
                    If c = 0 Or vDatos = "" Then
                        vDatos = dtListaCorrecta.Rows(c).Item("TIPO_DOCUMENTO") & "," & dtListaCorrecta.Rows(c).Item("NRO_DOCUMENTO") & "," & dtListaCorrecta.Rows(c).Item("ESTADO") & "," & dtListaCorrecta.Rows(c).Item("NOMBRES") & "," & dtListaCorrecta.Rows(c).Item("DIRECCION") & "," & dtListaCorrecta.Rows(c).Item("FECHA_NACIMIENTO") & "," & dtListaCorrecta.Rows(c).Item("PDV") & "," & dtListaCorrecta.Rows(c).Item("TIPO_PDV") & "," & dtListaCorrecta.Rows(c).Item("CELULAR") & "," & dtListaCorrecta.Rows(c).Item("ACCION") & ","
                    Else
                        vDatos = vDatos & "|" & dtListaCorrecta.Rows(c).Item("TIPO_DOCUMENTO") & "," & dtListaCorrecta.Rows(c).Item("NRO_DOCUMENTO") & "," & dtListaCorrecta.Rows(c).Item("ESTADO") & "," & dtListaCorrecta.Rows(c).Item("NOMBRES") & "," & dtListaCorrecta.Rows(c).Item("DIRECCION") & "," & dtListaCorrecta.Rows(c).Item("FECHA_NACIMIENTO") & "," & dtListaCorrecta.Rows(c).Item("PDV") & "," & dtListaCorrecta.Rows(c).Item("TIPO_PDV") & "," & dtListaCorrecta.Rows(c).Item("CELULAR") & "," & dtListaCorrecta.Rows(c).Item("ACCION") & ","
                    End If
                    cont = cont + 1
                    If cont = 50 Then
                        obj.CargaMasiVendedor(vDatos, hidUsuario.Value, hidDistribuidorId.Value)
                        cont = 0
                        vDatos = ""
                    End If
                Next

                obj.CargaMasiVendedor(vDatos, hidUsuario.Value, hidDistribuidorId.Value)
            End If


            Dim drDatoIncorrecto As DataRow
            For Each drDatoIncorrecto In dtListaError.Rows
                Me.txtListaNoCargaron.Text &= Environment.NewLine + Funciones.CheckStr(drDatoIncorrecto("NRO_DOCUMENTO"))
            Next

            Dim drDatoBlack As DataRow
            For Each drDatoBlack In dtBlackList.Rows
                Me.txtListaBlack.Text() &= Environment.NewLine + Funciones.CheckStr(drDatoBlack("NRO_DOCUMENTO"))
            Next

            lblRegistrados.Text = Funciones.CheckStr(contCorrecto)
            lblNoRegistrados.Text = Funciones.CheckStr(contError)
            hidLimpiarMasi.Value = "NO_LIMPIAR"

            re.Close()
            re = Nothing
            FileToUpload.Dispose()
        Catch ex As Exception
            re.Close()
            re = Nothing
            FileToUpload.Dispose()
            retorno = ex.Message
            objLog.Log_WriteLog(strArchivoLOG, "Error: " & ex.Message)
        Finally
            System.IO.File.Delete(Server.MapPath(rutaOrigen) & "/" & archivo)
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
            objLog.Log_WriteLog(strArchivoLOG, "FIN procesarArchivo()")
            objLog.Log_WriteLog(strArchivoLOG, "--------------------------------------------------")
        End Try

        Return retorno
    End Function

    Function ValidacionClienteCSV(ByVal vCantidad As Integer, ByVal vTipoDocumento As String, ByVal vNroDocumento As String, ByVal vEstado As String, ByVal vNombres As String, ByVal vDireccion As String, ByVal vFechaNac As String, ByVal vPDV As String, ByVal vCelular As String) As Boolean
        Dim retorno As Boolean = True
        Dim vNombresSinEspacios As String = ""
        Dim vDireccionSinEspacios As String = ""

        If retorno = True Then
            If Not (vCantidad = 9) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - CANTIDAD DATOS ENTRADA 9:" + vCantidad.ToString())
            End If
        End If

        If retorno = True Then
            If (vDireccion.Length < 2) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - DIRECCIÒN (LONGITUD CARACTERES MAYOR A 1):" + vDireccion.Length.ToString())
            End If
        End If


        If retorno = True Then
            If Not (vTipoDocumento.Length = 2) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - TIPO DOCUMENTO (LONGITUD CARACTERES 2):" + vTipoDocumento.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vNroDocumento.Length = 8) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NÙMERO DOCUMENTO (LONGITUD CARACTERES 8):" + vNroDocumento.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vNombres.Length <> 0) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NOMBRES (LONGITUD CARACTERES):" + vNombres.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vDireccion.Length <> 0) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - DIRECCION (LONGITUD CARACTERES):" + vDireccion.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vEstado.Length = 2) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - ESTADO (LONGITUD CARACTERES 2):" + vEstado.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vFechaNac.Length = 10) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - FECHA NACIMIENTO (LONGITUD CARACTERES 10):" + vFechaNac.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vPDV.Length = 4) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - PDV (LONGITUD CARACTERES 4):" + vPDV.Length.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vCelular.Length = 9) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - CELULAR (LONGITUD CARACTERES 9):" + vCelular.Length.ToString())
            End If
        End If

        'If retorno = True Then
        '    If Not ((vTipoDocumento.Length = 2) And (vNroDocumento.Length = 8) And (vNombres.Length <> 0) And (vDireccion.Length <> 0) And (vEstado.Length = 2) And (vFechaNac.Length = 10) And (vPDV.Length = 4) And (vCelular.Length = 9)) Then
        '        retorno = False
        '    End If
        'End If

        If retorno = True Then
            If Not soloNumeros(vTipoDocumento) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - TIPO DOCUMENTO (SOLO NÙMEROS):" + vTipoDocumento.ToString())
            End If
        End If

        If retorno = True Then
            If Not soloNumeros(vNroDocumento) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NÙMERO DOCUMENTO (SOLO NÙMEROS):" + vNroDocumento.ToString())
            End If
        End If

        If retorno = True Then
            If Not soloNumeros(vEstado) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - ESTADO (SOLO NÙMEROS):" + vEstado.ToString())
            End If
        End If

        If retorno = True Then
            vNombresSinEspacios = vNombres.Replace(Chr(32), String.Empty)
            If Not soloLetras(vNombresSinEspacios) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - NOMBRES (SOLO LETRAS):" + vNombres.ToString())
            End If
        End If

        If retorno = True Then
            vDireccionSinEspacios = vDireccion.Replace(Chr(32), String.Empty)
            If Not soloLetrasyNumeros(vDireccionSinEspacios) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - DIRECCION (SOLO LETRAS Y NÙMEROS):" + vDireccion.ToString())
            End If
        End If

        If retorno = True Then
            If Not IsDate(vFechaNac) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - FECHA (ES FECHA):" + "FALSO")
            End If
        End If

        If retorno = True Then
            If Not soloLetrasyNumeros(vPDV) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - PDV (SOLO LETRAS Y NÙMEROS):" + vPDV.ToString())
            End If
        End If

        If retorno = True Then
            If Not soloNumeros(vCelular) Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - CELULAR (SOLO NÙMEROS):" + vCelular.ToString())
            End If
        End If

        'If retorno = True Then
        '    vNombresSinEspacios = vNombres.Replace(Chr(32), String.Empty)
        '    vDireccionSinEspacios = vDireccion.Replace(Chr(32), String.Empty)
        '    If Not (soloNumeros(vTipoDocumento) And soloNumeros(vNroDocumento) And soloNumeros(vEstado) And soloLetras(vNombresSinEspacios) And soloLetrasyNumeros(vDireccionSinEspacios) And IsDate(vFechaNac) And soloLetrasyNumeros(vPDV) And soloNumeros(vCelular)) Then
        '        retorno = False
        '    End If
        'End If

        If retorno = True Then
            If Not (vTipoDocumento = "01" OrElse vTipoDocumento = "04") Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - TIPO DOCUMENTO (DEBE SER CUALQUIERA DE ESTOS 01,04):" + vTipoDocumento.ToString())
            End If
        End If

        If retorno = True Then
            If Not (vEstado = "01" OrElse vEstado = "02" OrElse vEstado = "03" OrElse vEstado = "04" OrElse vEstado = "05" OrElse vEstado = "07") Then
                retorno = False
                objLog.Log_WriteLog(strArchivoLOG, vNroDocumento.ToString() + " - ESTADO (DEBE SER CUALQUIERA DE ESTOS 01,02,03,04,05,07):" + vEstado.ToString())
            End If
        End If

        Return retorno
    End Function

    Function ValidacionBlackList(ByVal vNroDocumento As String) As Boolean
        Dim item As New Vendedor
        Dim valBlackList As Boolean = False
        Dim msg As String = ""

        item.NumeroDocumento = vNroDocumento
        Dim oMantMaestro As New MaestroNegocio
        valBlackList = oMantMaestro.ValidarBlackList(item, msg)

        Return valBlackList
    End Function

    Function ValidacionTipoPDV(ByVal tipoOficina As String, ByVal Oficina As String) As Boolean
        Dim item As New Vendedor
        Dim retorno As Boolean = False
        Dim vNroDocumento As String = ""
        Dim msg As String = ""

        Dim oMantMaestro As New MaestroNegocio
        retorno = oMantMaestro.ValidarTipoPDV(tipoOficina, Oficina, msg)

        Return retorno
    End Function

    Function soloLetras(ByVal cadena As String) As Boolean
        Dim validaL As Boolean
        Dim resultado As Boolean = True
        Dim n As Integer

        For n = 0 To Len(cadena) - 1
            validaL = Char.IsLetter(cadena.Chars(n))
            If validaL = False Then
                resultado = False
            End If
        Next n
        Return resultado
    End Function

    Function soloLetrasyNumeros(ByVal cadena As String) As Boolean
        Dim validaN As Boolean
        Dim validaL As Boolean
        Dim resultado As Boolean = True
        Dim n As Integer

        For n = 0 To Len(cadena) - 1
            validaL = System.Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\w").Success()
            validaN = System.Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\d").Success()
            If validaL = False And validaN = False Then
                resultado = False
            End If
        Next n
        Return resultado
    End Function

    Function soloNumeros(ByVal cadena As String) As Boolean
        Dim valida As Boolean
        Dim resultado As Boolean = True
        Dim n As Integer

        For n = 0 To Len(cadena) - 1
            valida = System.Text.RegularExpressions.Regex.Match(cadena.Chars(n), "\d").Success()
            If valida = False Then
                resultado = valida
            End If
        Next n
        Return resultado
    End Function


#End Region


End Class
