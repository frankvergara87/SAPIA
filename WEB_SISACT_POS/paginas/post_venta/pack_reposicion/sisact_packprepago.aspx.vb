Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports System.Text.RegularExpressions
Imports System.IO

Public Class sisact_packprepago
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlCanal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPuntoVenta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlVendedorSAP As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnPaso1 As System.Web.UI.WebControls.Button
    Protected WithEvents hidMsg As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntosVentas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPuntoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVendedorSAP As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPerfil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioCodigo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDocVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaCampanias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaMotivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMotivoSel As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMotivoDesSel As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBloqueo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents ddlTipoDocId As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNumeroDocId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroLinea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHlr As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTipoDoc As System.Web.UI.WebControls.Label
    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents LabelPaterno As System.Web.UI.WebControls.Label
    Protected WithEvents txtApellidoPaterno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApellidoMaterno As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dropdownlist4 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist5 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Textbox4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dropdownlist6 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist7 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist10 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist8 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Dropdownlist9 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents btnArea3 As System.Web.UI.WebControls.Button
    Protected WithEvents txtTipoVenta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTipoOperacion As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPlanTarifarioActual As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlTipoReposicion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMotivoReposicion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnArea4 As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodSIM As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlArticuloICCID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSerieSim As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCodEquipo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCodEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlSerieEquipo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCampania As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlListaPrecio As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPlanTarifario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hidCampanias As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents btnArea2 As System.Web.UI.WebControls.Button
    Protected WithEvents hidMensajeValidaCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTelefono As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoOperacion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOrgVenta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPLSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaSelected As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOfVentaDesc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCampaniaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidVentaExpress As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNumeroPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanes As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodMaterial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidArticuloIccid As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodEquipoSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEqSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidItemSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaIMEI As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargaICCID As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPTarifaActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPTarifa As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioSubTotalEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotalEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioSubTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPrecioTotal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalTexto As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidSerieEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMotivoReposicion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMaxLenTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipoPostBack As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPrecios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPreciosSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidOperacion As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Dim oLog As New SISACT_Log
    Dim nameFile As String = ConfigurationSettings.AppSettings("CONS_NAMELOG_REPOPACKPREPAGO")
    Dim oFile As String = oLog.Log_CrearNombreArchivo(nameFile)
    Dim strIdentifyLog As String = ""

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

        'Tipo de operacion' EMC***
        Dim constTipoOperacion As String = ConfigurationSettings.AppSettings("CONS_REPOSICION_TIPOREPO")
        Dim tipoOperacion As String = constTipoOperacion.Split(","c)(0)
        hidTipoOperacion.Value = tipoOperacion

        hidPlanDefault.Value = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")

        ddlListaPrecio.Attributes.Add("onChange", "cargarPrecio();")
        ddlCodEquipo.Attributes.Add("onChange", "f_CambiaImei()")
        ddlArticuloICCID.Attributes.Add("onChange", "f_CambiaIccid()")

        If Not Page.IsPostBack Then
            Session("CanalSelected") = Nothing
            Session("PuntoVentaSelected") = Nothing
            Session("VendedorSelected") = Nothing
            Inicio()
        Else
            Dim accion As String = hidAccion.Value
            If accion = "Consultar" Then
                Consultar()
            ElseIf accion = "GenerarPedido" Then
                GenerarPedido()
            ElseIf accion = "CargaAreaFinal" Then
                CargarHidden()
            End If
        End If
    End Sub

    Private Sub Inicio()
        Try
            hidTipoVenta.Value = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
            ObtenerPerfiles()
            CargarTipoDocumento()
            CargarCampanias()
            CargarMotivosReposicion()
            CargarTipoReposicion()
            CargarPlan()
            ConsultarDatosVenta()
            CargarArticuloIMEI()
            cargarArticuloICCID()

        Catch ex As Exception            
            hidMsg.Value = ex.Message
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & ex.Message)
        End Try
    End Sub

    Private Sub CargarTipoDocumento()
        Dim lista As ArrayList = (New VentaNegocios).ListaTipoDocumento("")
        lista.RemoveRange(3, 1)
        lista.RemoveRange(1, 1)

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        LlenaCombo(lista, ddlTipoDocId, "Codigo", "Descripcion")
    End Sub

    Public Sub CargarMotivosReposicion()
        Dim lista As ArrayList = (New SapGeneralNegocios).Get_ConsultaMotivosReposicion("")
        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        LlenaCombo(lista, ddlMotivoReposicion, "Codigo", "Descripcion")
    End Sub

    Private Sub CargarCampanias()
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
        Dim lista As ArrayList = (New SapGeneralNegocios).Get_ConsultaCampana(Now.ToString("yyyy/MM/dd"), tipoVenta)

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        lista.Insert(0, oItem)
        LlenaCombo(lista, ddlCampania, "Codigo", "Descripcion")
    End Sub

    Private Sub CargarPlan()
        Dim tipoVenta As String = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
        Dim tipoCliente As String = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")

        Dim listaPlan As ArrayList = (New SapGeneralNegocios).Get_ConsultaPlanTarifario(tipoCliente, "", tipoVenta, "")
        Dim oItem As New Plan(0, ConfigurationSettings.AppSettings("Seleccionar"))
        listaPlan.Insert(0, oItem)
        LlenaCombo(listaPlan, ddlPlanTarifario, "PLANC_CODIGO", "PLANV_DESCRIPCION")

    End Sub

    Private Sub ConsultarDatosVenta()
        Dim dsOficina As DataSet = (New SapGeneralNegocios).ConsultarParametrosOfVenta(CheckStr(hidOfVenta.Value))
        hidCanal.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VTWEG"))
        hidOrgVenta.Value = CheckStr(dsOficina.Tables(0).Rows(0).Item("VKORG"))
        dsOficina = Nothing
    End Sub

    Private Sub ObtenerPerfiles()
        Try
            Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
            Dim ctaRed As String = Me.CurrentUser
            strIdentifyLog = ctaRed

            'Validar Cuenta de Red Usuario
            If CheckStr(ctaRed).Equals(String.Empty) Then
                Throw New Exception("Cuenta de Red del Usuario. [" & ctaRed & "]")
            End If

            'Obtener Codigo Usuario Sisact
            Dim oUsuario As Usuario = (New MaestroNegocio).ObtenerUsuarioLogin(ctaRed)
            Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)
            If codUsuario = 0 Then
                Throw New Exception("Codigo Usuario Sisact. [" & codUsuario & "]")
            End If

            'Consultar Punto de Venta asociado al Usuario
            Dim listaOficinas As ArrayList = (New VentaNegocios).ListaPDVUsuario(codUsuario, "")
            If IsNothing(listaOficinas) OrElse listaOficinas.Count = 0 Then
                Throw New Exception("Lista de Punto de Venta asociado al Usuario.")
            End If

            'Guardar los datos generales de Venta
            Dim oPuntoVenta As PuntoVenta = CType(listaOficinas(0), PuntoVenta)
            If IsNothing(oPuntoVenta) Then
                Throw New Exception("No tiene Punto de Venta asociado al Usuario.")
            End If

            'Validar si el usuario NO pertenece a un DAC o Cadena
            Dim strCanal As String = oPuntoVenta.TOFIC_CODIGO
            If Not strCanal = "01" Then
                Throw New Exception("El canal del Usuario no pertenece a un CAC.")
            End If

            'Asignación Oficina
            hidOfVenta.Value = CheckStr(oPuntoVenta.OVENC_CODIGO)

            'Validar si el vendedor SAP se encuentra configurado
            Dim listaVendedor As New ArrayList
            Dim strVendedor As String
            For Each item As ItemGenerico In (New SapGeneralNegocios).ConsultarListaVendedores(hidOfVenta.Value)
                If (CheckInt64(item.Codigo) = CheckInt64(Session("CodVendedorSAP"))) Then
                    strVendedor = item.Codigo
                    listaVendedor.Add(item)
                    Exit For
                End If
            Next

            Dim listaCanal As ArrayList = (New ConsumerNegocio).ListaCanales(0, ConfigurationSettings.AppSettings("constCodTipoProductoCON"))

            'Cargar Canal/Oficina/Vendedor Sap
            LlenaCombo(listaCanal, ddlCanal, "CANAC_CODIGO", "CANAV_DESCRIPCION")
            LlenaCombo(listaOficinas, ddlPuntoVenta, "OVENC_CODIGO", "OVENV_DESCRIPCION")
            LlenaCombo(listaVendedor, ddlVendedorSAP, "CODIGO", "DESCRIPCION")

            'Asignar Canal/Punto de Venta asociado al Usuario
            ddlCanal.SelectedValue = oPuntoVenta.TOFIC_CODIGO
            ddlPuntoVenta.SelectedValue = oPuntoVenta.OVENC_CODIGO
            ddlVendedorSAP.SelectedValue = strVendedor
            ddlCanal.Enabled = False
            ddlPuntoVenta.Enabled = False
            ddlVendedorSAP.Enabled = False

            hidCanal.Value = oPuntoVenta.CANAC_CODIGO + ";" + oPuntoVenta.CANAV_DESCRIPCION
            hidCanalTexto.Value = oPuntoVenta.CANAV_DESCRIPCION

        Catch ex As Exception
            Dim listaCanal As New ArrayList
            LlenaCombo(listaCanal, ddlCanal, "CANAC_CODIGO", "CANAV_DESCRIPCION")
            Throw New Exception("Error. Consulta Datos del Vendedor.")
        End Try
    End Sub

    Private Sub CargarArticuloIMEI()
        Dim lista As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim tipoVenta As String = hidTipoVenta.Value
        lista = (New SapGeneralNegocios).get_ConsultaMaterial(Now.ToString("yyyy/MM/dd"), "", tipoVenta, hidOfVenta.Value, "")

        For Each it As ItemGenerico In lista
            If CheckStr(it.Codigo).StartsWith("PB") Then
                listaMaterial.Add(it)
            End If
        Next

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        listaMaterial.Insert(0, oItem)
        LlenaCombo(listaMaterial, ddlCodEquipo, "Codigo", "Descripcion")
    End Sub

    Private Sub cargarArticuloICCID()
        Dim lista As New ArrayList
        Dim listaMaterial As New ArrayList
        Dim tipoVenta As String = hidTipoVenta.Value
        lista = (New SapGeneralNegocios).get_ConsultaMaterial(Now.ToString("yyyy/MM/dd"), "", tipoVenta, hidOfVenta.Value, "11")

        For Each it As ItemGenerico In lista
            If CheckStr(it.Codigo).StartsWith("PS") Then
                listaMaterial.Add(it)
            End If
        Next

        Dim oItem As New ItemGenerico("00", ConfigurationSettings.AppSettings("Seleccionar"))
        listaMaterial.Insert(0, oItem)
        LlenaCombo(listaMaterial, ddlArticuloICCID, "Codigo", "Descripcion")
    End Sub

#Region "Consultar CLIENTE - AREA 1"
    Private Sub Consultar()
        Dim flagOK As Boolean
        Dim mensaje As String
        Dim flag_valida As String

        Dim nroLinea As String = CheckStr(txtNroLinea.Text)
        Dim nroClieDoc As String = CheckStr(txtNumeroDocId.Text)
        Dim tipoClieDoc As String = CheckStr(ddlTipoDocId.SelectedValue)
        Dim desClieDoc As String = CheckStr(ddlTipoDocId.SelectedItem.Text)

        hidMensajeValidaCliente.Value = "OK"

        If ValidarDatosLinea(nroLinea) Then
            flagOK = (New VentaNegocios).ConsultaValidacionCliente(desClieDoc, nroClieDoc, nroLinea, flag_valida, mensaje)
            Dim strScript As String

            If CheckStr(flag_valida).ToUpper.Equals("OK") Then
                txtHlr.Text = CheckStr(ConsultaHlr(nroLinea))
                hidTelefono.Value = nroLinea
                CargarDatosCliente()
            Else
                hidMsg.Value = mensaje
                txtNumeroDocId.ReadOnly = False
                strScript = "setReadOnly('txtNumeroDocId', false, 'clsInputEnable');alert('Cliente NO encontrado. Verifique.');"
            End If
            strScript = strScript + " validaFlujo('" + CheckStr(flag_valida).ToUpper() + "');"
            RegisterStartupScript("script", "<script>" & strScript & "</script>")            
        End If
    End Sub

    Private Function ValidarDatosLinea(ByVal nroLinea As String) As Boolean
        If Not LeerDatosLinea(nroLinea) Then Return False
        If Not LeerDatosCliente(nroLinea) Then Return False
        Return True
    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String) As Boolean
        Dim oPrepagoNegocios As New DatosPrepagoNegocios
        Dim providerIdPrepago As String = ConfigurationSettings.AppSettings("ProviderIdPrepago").ToString()
        Dim providerIdControl As String = ConfigurationSettings.AppSettings("ProviderIdControl").ToString()
        Dim mensajeError As String = ""

        Dim datosLinea2 As ClienteBSCS = Nothing
        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        datosLinea2 = oPostpagoNegocios.LeerDatosCliente(nroLinea, "", mensajeError)

        If Not datosLinea2 Is Nothing Then
            hidMsg.Value = "Error. Número ingresado NO es prepago o a sido dado de baja."

            Dim msj As String = "<script>setReadOnly('txtNumeroDocId', false, 'clsInputEnable');" + _
                                "document.getElementById('txtNumeroDocId').maxLength = getValue('hidMaxLenTipoDoc');" + _
                                "alert('" + hidMsg.Value + "'); </script>"
            RegisterStartupScript("script", msj)
            Return False
        Else
            Return True
        End If


        Dim datosLinea As ItemGenerico = Nothing
        datosLinea = oPrepagoNegocios.LeerDatosPrepago(nroLinea, providerIdPrepago, providerIdControl, mensajeError)
        If IsNothing(datosLinea) OrElse (Not datosLinea.estado.ToUpper().Equals("P")) Then
            hidMsg.Value = "Error. Número ingresado NO es prepago o a sido dado de baja."

            Dim msj As String = "<script>setReadOnly('txtNumeroDocId', false, 'clsInputEnable');" + _
                                "document.getElementById('txtNumeroDocId').maxLength = getValue('hidMaxLenTipoDoc');" + _
                                "alert('" + hidMsg.Value + "'); </script>"
            RegisterStartupScript("script", msj)
            Return False
        End If
        Return True
    End Function

    Private Function LeerDatosCliente(ByVal nroLinea As String) As Boolean
        Dim oClienteNegocios As New ClienteNegocio
        Dim flagConsulta As String = ""
        Dim mensajeError As String = ""

        oLog.Log_WriteLog(oFile, "-----------------------------------")
        oLog.Log_WriteLog(oFile, "Inicio consulta de Cliente")
        oLog.Log_WriteLog(oFile, "-----------------------------------")
        oLog.Log_WriteLog(oFile, "Nro. Linea: " & nroLinea)

        Dim oCliente As Cliente = oClienteNegocios.ObtenerCliente(nroLinea, "", "", "1", flagConsulta, mensajeError)
        If oCliente.OBJID_CONTACTO Is Nothing Then
            Dim strScript As String = "setReadOnly('txtNumeroDocId', false, 'clsInputEnable');" + _
                                    "alert('Error. La línea NO esta asociada al documento de identidad ingresado.');"
            hidMsg.Value = "Error. Nro de Línea del Cliente no se encuentra en la BD de Clarify."
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
            Return False
        End If
        oLog.Log_WriteLog(oFile, "Consulta Clfy")
        oLog.Log_WriteLog(oFile, "Nombre BD: " & oCliente.NOMBRES)
        oLog.Log_WriteLog(oFile, "Apellidos BD: " & oCliente.APELLIDOS)

        ' Guardar los datos del cliente
        Dim oSolicitudPersona As New SolicitudPersona
        oSolicitudPersona.TVENC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoVentaPrepago")
        oSolicitudPersona.CCLIC_CODIGO = CheckStr(oCliente.ID_CLIENTE) 'Este dato no existe
        oSolicitudPersona.CLIEV_NOMBRE = oCliente.NOMBRES
        oSolicitudPersona.CLIEV_RAZ_SOC = oCliente.RAZON_SOCIAL
        oSolicitudPersona.CLIEV_APE_PAT = oCliente.APELLIDOS '_PATERNO 'Este dato esta junto (Ap_Paterno + ApMaterno)
        oSolicitudPersona.CLIEV_APE_MAT = oCliente.APELLIDO_MATERNO 'Este dato esta junto (Ap_Paterno + ApMaterno)
        oSolicitudPersona.TDOCV_DESCRIPCION = oCliente.TIPO_DOC
        oSolicitudPersona.CLIEC_NUM_DOC = oCliente.NRO_DOC


        ' Por defecto Tipo Documento DNI
        oSolicitudPersona.TDOCC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") 'CheckStr(oCliente.ID_TIP_DOC)
        Dim docDNI, docCE, docRUC, docPASS As String
        docDNI = ConfigurationSettings.AppSettings("ExpressTipoDocDNI")
        docCE = ConfigurationSettings.AppSettings("ExpressTipoDocCE")
        docRUC = ConfigurationSettings.AppSettings("ExpressTipoDocRUC")
        docPASS = ConfigurationSettings.AppSettings("ExpressTipoDocPASS")

        ' Buscar el Tipo de Documento
        If docDNI.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docDNI.Split(";"c)(0)
        ElseIf docCE.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docCE.Split(";"c)(0)
        ElseIf docRUC.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docRUC.Split(";"c)(0)
        ElseIf docPASS.ToUpper().IndexOf(oCliente.TIPO_DOC.ToUpper()) <> -1 Then
            oSolicitudPersona.TDOCC_CODIGO = docPASS.Split(";"c)(0)
        End If

        oSolicitudPersona.CLIEV_PRE_TEL_LEG = ""
        oSolicitudPersona.CLIEV_TEL_LEG = oCliente.TELEFONO_DOMICILIO
        oSolicitudPersona.CLIEV_PRE_DIR = ""
        oSolicitudPersona.CLIEV_DIRECCION = oCliente.DIRECCION
        oSolicitudPersona.DEPAV_DESCRIPCION = oCliente.DEPARTAMENTO
        oSolicitudPersona.PROVV_DESCRIPCION = oCliente.PROVINCIA
        oSolicitudPersona.DISTV_DESCRIPCION = oCliente.DISTRITO


        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsDatosSAP As DataSet = oConsultaSap.Get_ConsultaCliente(oSolicitudPersona.OVENC_CODIGO, oSolicitudPersona.TDOCC_CODIGO, oCliente.NRO_DOC)

        If Not dsDatosSAP Is Nothing Then
            Dim dtCliente As System.Data.DataTable = dsDatosSAP.Tables(0)
            Session("ClienteSAP") = Nothing
            If dtCliente.Rows.Count > 0 Then
                Session("ClienteSAP") = dtCliente
                'oSolicitudPersona.CLIEV_NOMBRE = CheckStr(dtCliente.Rows(0)("NOMBRE"))
                'oSolicitudPersona.CLIEV_RAZ_SOC = CheckStr(dtCliente.Rows(0)("RAZON_SOCIAL"))
                'oSolicitudPersona.CLIEV_APE_PAT = CheckStr(dtCliente.Rows(0)("APELLIDO_PATERNO"))
                'oSolicitudPersona.CLIEV_APE_MAT = CheckStr(dtCliente.Rows(0)("APELLIDO_MATERNO"))               

                oSolicitudPersona.CLIEV_PRE_TEL_LEG = CheckStr(dtCliente.Rows(0)("TELEF_LEGAL_PREF"))
                oSolicitudPersona.CLIEV_TEL_LEG = CheckStr(dtCliente.Rows(0)("TELEF_LEGAL"))
                oSolicitudPersona.CLIEV_PRE_DIR = ""
                oSolicitudPersona.CLIEV_DIRECCION = CheckStr(dtCliente.Rows(0)("CALLE_LEGAL"))
                oLog.Log_WriteLog(oFile, "Consulta SAP")
                oLog.Log_WriteLog(oFile, "------------------------------")
                oLog.Log_WriteLog(oFile, "Nombre: " & oSolicitudPersona.CLIEV_NOMBRE)
                oLog.Log_WriteLog(oFile, "Apellido Pat: " & oSolicitudPersona.CLIEV_APE_PAT)
                oLog.Log_WriteLog(oFile, "Apellido Mat: " & oSolicitudPersona.CLIEV_APE_MAT)
            End If
        End If

        Session("SolicitudSelected") = oSolicitudPersona
        
        Return True

    End Function

    Private Sub CargarDatosCliente()
        Try
            txtNombre.Text = String.Empty
            txtApellidoPaterno.Text = String.Empty
            txtApellidoMaterno.Text = String.Empty

            If Session("SolicitudSelected") Is Nothing Then
                HabilitarControles(False)
                hidMsg.Value = "Error. No existen datos de CLIENTE / SEC."
                RegisterStartupScript("script", "<script>alert('Error. El cliente debe actualizar sus datos personales.'); </script>)")
                Exit Sub
            End If
            Dim oSolicitud As SolicitudPersona = CType(Session("SolicitudSelected"), SolicitudPersona)



            txtNombre.Text = oSolicitud.CLIEV_NOMBRE
            If txtNombre.Text = "" Then
                txtNombre.Text = oSolicitud.CLIEV_RAZ_SOC
            End If

            txtApellidoPaterno.Text = CheckStr(oSolicitud.CLIEV_APE_PAT) + " " + CheckStr(oSolicitud.CLIEV_APE_MAT)
            'txtApellidoMaterno.Text = CheckStr(oSolicitud.CLIEV_APE_PAT) + " " + CheckStr(oSolicitud.CLIEV_APE_MAT)
            oLog.Log_WriteLog(oFile, "-------------------------------------------")
            oLog.Log_WriteLog(oFile, "Consulta Clfy")
            oLog.Log_WriteLog(oFile, "Nombre Web: " & txtNombre.Text)
            oLog.Log_WriteLog(oFile, "Apellidos Web: " & txtApellidoPaterno.Text)
            oLog.Log_WriteLog(oFile, "-----------------------------------")
            oLog.Log_WriteLog(oFile, "FIN consulta de Cliente")
            oLog.Log_WriteLog(oFile, "-----------------------------------")
        
            If txtNombre.Text = String.Empty Or txtApellidoPaterno.Text = String.Empty Then 'Or txtApellidoMaterno.Text = String.Empty Then
                RegisterStartupScript("script", "<script>alert('Error. El cliente debe actualizar sus datos personales.'); </script>")
            Else
                HabilitarControles(True)
            End If


        Catch ex As Exception
            HabilitarControles(True)
            hidMsg.Value = String.Format("Error. {0}", ex.Message)
        End Try
    End Sub

    Private Function ConsultaHlr(ByVal nroLinea As String) As String
        Dim oConsulta As New VentaNegocios
        Dim Msisdn As String = "51" & nroLinea
        Dim strHLR As String
oLog.Log_WriteLog(oFile, "Inicio ConsultaHlr")
        'If (ConfigurationSettings.AppSettings("FLAG_Hlr") = "01") Then '---------------llave agregada para prueba
            strHLR = Right("00" & CheckStr(oConsulta.ObtenerNroHLR(Msisdn)), 2)
            'Else
            '    strHLR = Right("00" & ConfigurationSettings.AppSettings("Nuevo_Hlr"), 2)
            'End If
oLog.Log_WriteLog(oFile, "Inicio ConsultaHlr strHLR:" & strHLR)
        Return strHLR

    End Function

#End Region

#Region "Llenado de comboBox"
    Private Sub CargarTipoReposicion()
        Try

            Dim listaTipoBloqueo As New ArrayList
            Dim itemSeleccionar As New TipoBloqueo
            itemSeleccionar.ID_CODIGO = "00"
            itemSeleccionar.DESCRIPCION = ConfigurationSettings.AppSettings("Seleccionar")
            listaTipoBloqueo.Insert(0, itemSeleccionar)

            Dim tipoReposicion As String = ConfigurationSettings.AppSettings("CONS_REPOSICION_TIPOREPO")
            itemSeleccionar = New TipoBloqueo
            itemSeleccionar.ID_CODIGO = tipoReposicion.Split(","c)(0)
            itemSeleccionar.DESCRIPCION = tipoReposicion.Split(","c)(1)

            listaTipoBloqueo.Insert(1, itemSeleccionar)

            If listaTipoBloqueo.Count > 0 Then LlenaCombo(listaTipoBloqueo, ddlTipoReposicion, "ID_Codigo", "Descripcion")
        Catch ex As Exception
            Dim var As String = ex.Message
        End Try
    End Sub

    Public Sub CargaIMEIS(ByVal strMaterial As String, ByVal strNroTelef As String, ByVal strPuntoVenta As String) 'As String
        Dim strCombo As String = String.Empty
        Dim lista As ArrayList
        Dim oSapNegocios As New SapGeneralNegocios
        lista = oSapNegocios.get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef)
        oSapNegocios = Nothing

        'Dim usuario_id As String = CurrentUser
        'lista = (New SansNegocio).get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef, usuario_id)

        ddlSerieEquipo.Items.Clear()

        If lista.Count > 0 Then
            Dim itemSeleccionar As New ItemGenerico
            itemSeleccionar.Codigo = ConfigurationSettings.AppSettings("Seleccionar")
            itemSeleccionar.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")
            lista.Insert(0, itemSeleccionar)


            For Each item As ItemGenerico In lista
                strCombo = strCombo & ";" & CheckStr(item.Codigo) & "," & CheckStr(item.Descripcion)
            Next
            LlenaCombo(lista, ddlSerieEquipo, "Codigo", "Codigo") '"Descripcion")
            hidCargaIMEI.Value = strCombo
            lista = Nothing

            ddlSerieEquipo.Attributes.Add("onChange", "cargarSerieEquipo();")

            'strCombo = "<select id=cboIMEIArt name=cboIMEIArt class=clsSelectEnable style='width:160px'>"
            'strCombo &= "<option value='0000000000'>" & ConfigurationSettings.AppSettings("Seleccionar") & "</option>"
            'For i As Integer = 0 To lista.Count - 1
            '    Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
            '    strCombo = strCombo & "<option value=" & item.Codigo & "#" & item.Descripcion & ">" & item.Codigo & "</option>"
            'Next
            'strCombo &= "</select>"
        End If

        'Return strCombo
    End Sub

    Public Sub CargaICCID(ByVal strMaterial As String, ByVal strNroTelef As String, ByVal strPuntoVenta As String) ' As String
        Dim strCombo As String = ""
        Dim lista As ArrayList
        'Dim oSapNegocios As New SapGeneralNegocios
        'lista = oSapNegocios.get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef)
        'oSapNegocios = Nothing

        Dim usuario_id As String = CurrentUser
        lista = (New SansNegocio).get_seriesxMaterial(strPuntoVenta, strMaterial, "", strNroTelef, usuario_id)

        ddlSerieSim.Items.Clear()

        If lista.Count > 0 Then
            Dim itemSeleccionar As New ItemGenerico
            itemSeleccionar.Codigo = ConfigurationSettings.AppSettings("Seleccionar")
            itemSeleccionar.Descripcion = ConfigurationSettings.AppSettings("Seleccionar")

            lista.Insert(0, itemSeleccionar)
            For Each item As ItemGenerico In lista
                strCombo = strCombo & ";" & CheckStr(item.Codigo) & "," & CheckStr(item.Descripcion)
            Next
            LlenaCombo(lista, ddlSerieSim, "Codigo", "Codigo")  '
            hidCargaICCID.Value = strCombo
            lista = Nothing


            ddlSerieSim.Attributes.Add("onChange", "cargarICCID();")

            'strCombo = "<select id=cboICCIDArt name=cboICCIDArt class=clsSelectEnable onChange=f_muestraTelefono(); style='width:160px'>"
            'strCombo &= "<option value='0000000000'>" & ConfigurationSettings.AppSettings("Seleccionar") & "</option>"

            'For i As Integer = 0 To lista.Count - 1
            '    Dim item As ItemGenerico = CType(lista(i), ItemGenerico)
            '    strCombo = strCombo & "<option value=" & item.Codigo & "#" & Right(item.Descripcion, 9) & ">" & item.Codigo & "</option>"
            'Next
            'strCombo &= "</select>"
        End If

        'Return strCombo
    End Sub

#End Region

#Region "GenerarPedido"
    Private Sub GenerarPedido()
        Dim oConsultarSap As New SapGeneralNegocios
        Dim cadenaDetalle As String = ""
        Dim cadenaCabecera As String = ""
		strIdentifyLog = hidNroLinea.Value()
        Try
            Dim entrega, factura, nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente As String
            Dim valorDescuento As Decimal
            ConsultarDatosVenta()
            'Generar los Parametros 
            cadenaCabecera = GenerarCadenaCabecera()
            cadenaDetalle = GenerarCadenaDetalle()
            cadenaDetalle = cadenaDetalle + "|" + GenerarCadenaDetalleEquipo()

			oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Inicio Generar Pedido")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Cabecera : " & cadenaCabecera)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input  --> Detalle  : " & cadenaDetalle)

			
            ' Realizar Pedido
            Dim pedidoGenerado As Boolean = oConsultarSap.RealizarPedido(cadenaCabecera, cadenaDetalle, "", "", "", entrega, factura, _
                                            nroContrato, nroDocCliente, nroPedido, refHistorico, tipDocCliente, valorDescuento)
            ' Dim pedidoGenerado As Boolean = False
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> factura  : " & factura)
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Output --> nroPedido: " & nroPedido)

			If Not pedidoGenerado Then
                CargarError()
                Throw New Exception("No se pudo Generar el Pedido en Sap.")
            End If

            ' Grabar Detalle Chip Repuesto 
            GenerarDetalleChipSap(factura)

            ' Auditoria Realizar Pedido
            Dim descRealizarPedido As String = "Se realizó Transacción exitosa de Generar Reposición Pack Prepago. (OficinaVenta: " & hidOfVenta.Value & " | Nro Pedido: " & nroPedido & " | " & _
                                                    " | Vendedor: " & hidVendedorSAP.Value & _
                                                    " | Nro de Telefono: " & hidNroLinea.Value & _
                                                    " | Tipo de Documento: " & hidTipoDocumento.Value & _
                                                    " | Numero de identidad: " & hidNroDocumento.Value '& _
                                                    '" | Numero Chip: " & txtCodSIM.Text & _
                                                    '" | Serie de Chip: " & ddlSerieSim.SelectedItem.Text & _
                                                    '" | Numero Equipo: " & ddlCodEquipo.SelectedItem.Text & _
                                                    '" | Serie Equipo: " & hidSerieEquipo.Value

            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Inicio Guardado Auditoria")
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Input --> auditoria  : " & descRealizarPedido)

            AuditoriaRealizarPedido(descRealizarPedido)
            
			oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Fin Guardado Auditoria")

            ' Mensaje de Exito al realizar la Venta
            Dim mensaje As String = "Pedido generado satisfactoriamente." & Chr(13) & "Ingresar a Activación/Documentos por pagar para culminar proceso."

            ddlSerieEquipo.Items.Clear()
            ddlSerieSim.Items.Clear()
            txtCodSIM.Text = String.Empty
            txtCodEquipo.Text = String.Empty

            ' GuardarInteraccion()

            Dim strScript As String = "ocultarPaneles();setValue('txtTotal','0.00');alert('Se realizó correctamente la transacción de Generar Pedido Prepago.');"
            hidMsg.Value = mensaje
            hidAccion.Value = String.Empty
            RegisterStartupScript("script", "<script>" & strScript & "</script>")
            hidAccion.Value = ""
        Catch ex As Exception
		    oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Error  --> GenerarPedido: " & ex.Message)

            txtHlr.Text = ""
            hidMsg.Value = "Error. Generar Pedido. " & ex.Message
            CargarError()
        Finally
            oConsultarSap = Nothing
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "Fin Generar Pedido")
        End Try
        oConsultarSap = Nothing
    End Sub

    Private Function GenerarCadenaCabecera() As String

        Dim oConsultarSap As New SapGeneralNegocios
        Dim oficina As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))
        Dim nroDocCliente As String = hidNroDocumento.Value 'ConfigurationSettings.AppSettings("constCodDocClienteChip")
        Dim tipoDocCliente As String = hidTipoDocumento.Value ' ConfigurationSettings.AppSettings("constTipoDocClienteChip")
        Dim tipoVenta As String = hidTipoVenta.Value
        Dim tipoCliente As String = hidTipoCliente.Value

        Dim constTipoOperacion As String = ConfigurationSettings.AppSettings("CONS_REPOSICION_TIPOREPO")
        Dim tipoOperacion As String = constTipoOperacion.Split(","c)(0) ' "33" 'hidTipoOperacion.Value

        Dim motivoReposicion As String = hidMotivoReposicion.Value 'ConfigurationSettings.AppSettings("constCodMotivoReposicion")

        Dim constDocVenta As String = ConfigurationSettings.AppSettings("ExpressTipoDocVentaPos01")
        Dim tipoDocVenta As String = constDocVenta.Split(","c)(2) '"ZPBR" 'ConfigurationSettings.AppSettings("constTipoDocVentaChip")
        Dim moneda As String = ConfigurationSettings.AppSettings("constCodMoneda")


        Dim totalSinIGV As String = CStr(CheckDecimal(hidPrecioSubTotal.Value) + CheckDecimal(hidPrecioSubTotalEquipo.Value))
        Dim totalConIGV As String = CStr(CheckDecimal(hidPrecioTotal.Value) + CheckDecimal(hidPrecioTotalEquipo.Value))
        Dim totalIGV As String = CStr(CheckDecimal(totalConIGV) - CheckDecimal(totalSinIGV)) 'CStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))
        Dim canal As String = hidCanal.Value
        Dim orgVenta As String = hidOrgVenta.Value

        ' Cadena Documento
        Dim arrayCabecera(49) As String
        arrayCabecera(0) = ""                                    'Documento
        arrayCabecera(1) = tipoDocVenta                          'Tipo_Documento
        arrayCabecera(2) = oficina                               'Oficina_Venta
        arrayCabecera(3) = String.Format("{0:dd/MM/yyyy}", Now)  'Fecha_Documento
        arrayCabecera(4) = tipoDocCliente                        'Tipo_Doc_Cliente
        arrayCabecera(5) = nroDocCliente                         'Cliente
        arrayCabecera(6) = motivoReposicion                      'Motivo de Reposicion
        arrayCabecera(7) = moneda                                'Moneda
        arrayCabecera(9) = totalSinIGV                           'Total_Mercaderia
        arrayCabecera(10) = totalIGV                             'Total_Impuesto
        arrayCabecera(11) = totalConIGV                          'Total_Documento
        arrayCabecera(16) = tipoVenta                            'Tipo_Venta
        arrayCabecera(25) = ""                                   'Código Comercial
        arrayCabecera(27) = codVendedor                          'Vendedor
        arrayCabecera(29) = tipoOperacion                        'Chip Repuesto
        arrayCabecera(44) = "01"                                 'Operador
        arrayCabecera(45) = "02"                                 'Tipo de Operador
        arrayCabecera(48) = orgVenta                             'Orgvnt
        arrayCabecera(49) = canal                                'Canal

        oConsultarSap = Nothing
        Return Join(arrayCabecera, ";")
    End Function

    Private Function GenerarCadenaDetalle() As String
        Dim cadenaDetalle As String = ""
        Dim oConsultaExpress As New VentaNegocios

        ' Detalle Linea Venta
        Dim arrayDetalle(28) As String
        Dim consecutivo As String = "000001"
        Dim cantidad As Integer = 1
        Dim codPlan As String = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")
        Dim desPlan As String = ConfigurationSettings.AppSettings("constDesPlanChipRepuesto")
        Dim arrayListaPrecio() As String = hidPLSelected.Value.Split(","c)
        Dim arrayCampania() As String = hidCampaniaSelected.Value.Split(","c)
        Dim totalSinIGV As String = hidPrecioSubTotal.Value
        Dim totalConIGV As String = hidPrecioTotal.Value
        Dim totalIGV As String = CheckStr(CheckDecimal(hidPrecioTotal.Value) - CheckDecimal(hidPrecioSubTotal.Value))

        ' Iccid
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = consecutivo                   'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = txtCodSIM.Text 'txtCodMaterial.Text           'Articulo
        arrayDetalle(3) = ddlArticuloICCID.SelectedItem.Text  'txtDescArticulo.Text          'Des_Articulo
        arrayDetalle(4) = arrayListaPrecio(0)           'Utilizacion
        arrayDetalle(5) = arrayListaPrecio(1)           'Des_Utilizacion
        arrayDetalle(6) = arrayCampania(0)              'Campana
        arrayDetalle(7) = arrayCampania(1)              'Des_Campana
        arrayDetalle(8) = CheckStr(hidIccid.Value)      'Iccid
        arrayDetalle(9) = CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = totalSinIGV                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = totalConIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = totalIGV                     'Descuento
        arrayDetalle(13) = ""                           'Porc_Descuento
        arrayDetalle(14) = ""                           'Descuento_Adic
        arrayDetalle(15) = totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = ""                           'Impuesto2
        arrayDetalle(18) = codPlan                      'Plan_Tarifario
        arrayDetalle(19) = desPlan                      'Des_Plan_Tarifar
        arrayDetalle(20) = ""                           'Centro_Costo
        arrayDetalle(21) = ""                           'Motivo_Devolucio
        arrayDetalle(22) = ""                           'Asociado
        arrayDetalle(23) = ""                           'Consecutivo_Padr
        arrayDetalle(24) = ""                           'Articulo_Asociac
        arrayDetalle(25) = hidTelefono.Value            'Numero_Telefono
        arrayDetalle(26) = ""                           'Nro_Clarify
        arrayDetalle(27) = ""                           'Dev_Componente
        arrayDetalle(28) = ""                           'Serie_Ant

        cadenaDetalle = Join(arrayDetalle, ";")
        oConsultaExpress = Nothing

        Return cadenaDetalle
    End Function

    Private Function GenerarCadenaDetalleEquipo() As String
        Dim cadenaDetalle As String = ""
        Dim oConsultaExpress As New VentaNegocios

        ' Detalle Linea Venta
        Dim arrayDetalle(28) As String
        Dim consecutivo As String = "000002"
        Dim cantidad As Integer = 1
        Dim codPlan As String = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")
        Dim desPlan As String = ConfigurationSettings.AppSettings("constDesPlanChipRepuesto")
        Dim arrayListaPrecio() As String = hidPLSelected.Value.Split(","c)
        Dim arrayCampania() As String = hidCampaniaSelected.Value.Split(","c)



        Dim totalSinIGV As String = hidPrecioSubTotalEquipo.Value
        Dim totalConIGV As String = hidPrecioTotalEquipo.Value
        Dim totalIGV As String = CheckStr(CheckDecimal(hidPrecioTotalEquipo.Value) - CheckDecimal(hidPrecioSubTotalEquipo.Value))

        ' Iccid
        arrayDetalle(0) = ""                            'Documento
        arrayDetalle(1) = consecutivo                   'Consecutivo (codigo 6 digitos)
        arrayDetalle(2) = txtCodEquipo.Text 'txtCodMaterial.Text           'Articulo
        arrayDetalle(3) = ddlCodEquipo.SelectedItem.Text  'txtDescArticulo.Text          'Des_Articulo
        arrayDetalle(4) = arrayListaPrecio(0)           'Utilizacion
        arrayDetalle(5) = arrayListaPrecio(1)           'Des_Utilizacion
        arrayDetalle(6) = arrayCampania(0)              'Campana
        arrayDetalle(7) = arrayCampania(1)              'Des_Campana
        arrayDetalle(8) = CheckStr(hidSerieEquipo.Value)      'Imei
        arrayDetalle(9) = CheckStr(cantidad)            'Cantidad
        arrayDetalle(10) = totalSinIGV                  'Precio (Precio UNITARIO sin IGV :  devuelve la ConsultaPrecio)
        arrayDetalle(11) = totalConIGV                  'Precio_Total (Precio UNIT sin IGV menos el Descuento: devuelve la ConsultaPrecio)
        arrayDetalle(12) = totalIGV                     'Descuento
        arrayDetalle(13) = ""                           'Porc_Descuento
        arrayDetalle(14) = ""                           'Descuento_Adic
        arrayDetalle(15) = totalSinIGV                  'Subtotal (igual q precio total * Cantidad)
        arrayDetalle(16) = totalIGV                     'Impuesto1 (IGV total: Precio con IGV - Precio sin IGV que trae ConsultaPrecio)
        arrayDetalle(17) = ""                           'Impuesto2
        arrayDetalle(18) = codPlan                      'Plan_Tarifario
        arrayDetalle(19) = desPlan                      'Des_Plan_Tarifar
        arrayDetalle(20) = ""                           'Centro_Costo
        arrayDetalle(21) = ""                           'Motivo_Devolucio
        arrayDetalle(22) = ""                           'Asociado
        arrayDetalle(23) = ""                           'Consecutivo_Padr
        arrayDetalle(24) = ""                           'Articulo_Asociac
        arrayDetalle(25) = hidTelefono.Value            'Numero_Telefono
        arrayDetalle(26) = ""                           'Nro_Clarify
        arrayDetalle(27) = ""                           'Dev_Componente
        arrayDetalle(28) = ""                           'Serie_Ant

        cadenaDetalle = Join(arrayDetalle, ";")
        oConsultaExpress = Nothing

        Return cadenaDetalle
    End Function

    Private Sub GenerarDetalleChipSap(ByVal nroPedido As String)

        Dim arrayDetalle(18) As String
        Dim oConsultaSap As New SapGeneralNegocios
        Dim nroLinea As String = CheckStr(hidTelefono.Value)
        Dim motivo As String = ConfigurationSettings.AppSettings("constCodMotivoReposicion")
        Dim puntoVenta As String = CheckStr(hidOfVenta.Value)
        Dim codVendedor As String = CheckStr(Session("CodVendedorSAP"))

        Dim oConsultaSans As New SansNegocio

        Try
            Dim usuario_id As String = CurrentUser
            arrayDetalle(0) = ""
            arrayDetalle(1) = nroLinea
            'arrayDetalle(2) = oConsultaSap.ConsultarIccid("", nroLinea, "")
            arrayDetalle(2) = oConsultaSans.ConsultarIccid("", nroLinea, "", hidCodMaterial.Value, hidIccid.Value, usuario_id)
            arrayDetalle(3) = ""
            arrayDetalle(4) = puntoVenta
            arrayDetalle(5) = nroPedido
            arrayDetalle(6) = motivo
            arrayDetalle(7) = hidIccid.Value
            arrayDetalle(9) = codVendedor
            arrayDetalle(10) = ""
            arrayDetalle(11) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(12) = Format(Now, "H:mm:ss")
            arrayDetalle(13) = ConfigurationSettings.AppSettings("strEstadoSolNuevo")
            arrayDetalle(14) = "X"
            arrayDetalle(15) = ""
            arrayDetalle(16) = String.Format("{0:dd/MM/yyyy}", Now)
            arrayDetalle(17) = Format(Now, "H:mm:ss")
            ' Grabar Datos Pedido
            oConsultaSap.SetGetLogActivacionChip("", "", Join(arrayDetalle, ";"), "")
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region " Auditoria"
    Private Sub AuditoriaRealizarPedido(ByVal desTrans As String)
        Try
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
            Dim usuario_id As String = CurrentUser
            Dim ipcliente As String = CurrentTerminal

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_REPOSICION_SACT_SERV")
            Dim strCodTrans As String = ConfigurationSettings.AppSettings("CONS_REPOSICION_CODAUDIT_REPOPACK")

            'Dim totalConIGV As String = "0"'CStr(CheckDecimal(hidPrecioTotal.Value) + CheckDecimal(hidPrecioTotalEquipo.Value))

            Dim auditoriaGrabado As Boolean = New AuditoriaNegocio().registrarAuditoria(strCodTrans, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, hidTelefono.Value, "", desTrans)            
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- " & "  Transaccion Auditoria  : " & ex.Message)
        End Try
    End Sub
#End Region

#Region "Procesos Varios"
    Private Sub HabilitarControles(ByVal flag As Boolean)
        If flag Then
            ddlCanal.Attributes.Remove("disabled")
            ddlPuntoVenta.Attributes.Remove("disabled")
            ddlVendedorSAP.Attributes.Remove("disabled")
        Else
            ddlCanal.Attributes.Add("disabled", "disabled")
            ddlPuntoVenta.Attributes.Add("disabled", "disabled")
            ddlVendedorSAP.Attributes.Add("disabled", "disabled")
        End If
    End Sub

    Private Sub CargarHidden()
        'Mostrar area
        Dim focus As String = hidItemSeleccionado.Value
        Dim strComando As String = "<script>mostrarPaneles();" + _
                                    "setFocus('" + focus + "');" + _
                                    "HabilitarControles(false);" + _
                                    "document.getElementById('btnArea3').disabled = true; " + _
                                    "cargarListaPrecio(); </script>"
        RegisterStartupScript("script", strComando)

        'Area 1
        txtNroLinea.Text = hidNroLinea.Value.ToString
        ddlTipoDocId.SelectedValue = hidTipoDocumento.Value.ToString
        txtNumeroDocId.Text = hidNroDocumento.Value.ToString

        'Area 3
        ddlMotivoReposicion.SelectedValue = hidMotivoSel.Value.ToString
        ddlPlanTarifario.SelectedValue = ConfigurationSettings.AppSettings("constCodPlanChipRepuesto")

    End Sub

    Private Sub CargarError()

        'Mostrar area
        Dim focus As String = hidItemSeleccionado.Value
        Dim strComando As String = "<script>mostrarPaneles();" + _
                                    "setFocus('" + focus + "');" + _
                                    "HabilitarControles(false);" + _
                                    "document.getElementById('btnArea3').disabled = true;" + _
                                    "setValue('ddlCampania','00');" + _
                                    "setValue('txtTotal','0.00');" + _
                                    "alert('No se pudo completar la operación. Verifique.');</script>"
        RegisterStartupScript("script", strComando)

        'Area 1
        txtNroLinea.Text = hidNroLinea.Value.ToString
        ddlTipoDocId.SelectedValue = hidTipoDocumento.Value.ToString
        txtNumeroDocId.Text = hidNroDocumento.Value.ToString

        'Area 3
        ddlMotivoReposicion.SelectedValue = hidMotivoSel.Value.ToString

    End Sub

#End Region

    Private Sub ddlCodEquipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCodEquipo.SelectedIndexChanged
       
        If ddlCodEquipo.SelectedValue.ToString.Length >= 10 Then
            Dim strMaterial As String = ddlCodEquipo.SelectedValue.ToString.Substring(0, 10)
            Dim strNroTelef As String = String.Empty
            Dim strPuntoVenta As String = hidOfVenta.Value.Trim
            CargaIMEIS(strMaterial, strNroTelef, strPuntoVenta)
        Else
            txtCodEquipo.Text = String.Empty
            ddlSerieEquipo.Items.Clear()
        End If
    End Sub

    Private Sub ddlArticuloICCID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlArticuloICCID.SelectedIndexChanged
        
        If ddlArticuloICCID.SelectedValue.ToString.Length >= 10 Then
            Dim strMaterial As String = ddlArticuloICCID.SelectedValue.ToString.Substring(0, 10)
            Dim strNroTelef As String = String.Empty
            Dim strPuntoVenta As String = hidOfVenta.Value.Trim
            CargaICCID(strMaterial, strNroTelef, strPuntoVenta)
        Else
            txtCodSIM.Text = String.Empty
            ddlSerieSim.Items.Clear()
        End If

        
    End Sub

   
End Class