Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Common
Imports COM_SIC_Activaciones
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO
Imports System

Public Class sisact_migracion_prepago_postpago
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDoc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTipoDoc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNroDoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPlazoAcuerdo As Anthem.DropDownList
    Protected WithEvents ddlPlan As Anthem.DropDownList
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTipoOperacion As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnBuscar As Anthem.Button
    Protected WithEvents hdnValCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnWhitelist As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents chkCorreo As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtCorreo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCargarPlanes As Anthem.Button
    Protected WithEvents hdnCargoFijoMax As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnPlazoDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgServicios As Anthem.DataGrid
    Protected WithEvents txtTipoGarantia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumeroCF As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRiesgo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtImporte As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgPlan As Anthem.DataGrid
    Protected WithEvents btnAgregarPlan As Anthem.Button
    Protected WithEvents hdnServicios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnQuitarPlan As Anthem.Button
    Protected WithEvents hdnFlagControlConsumo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnMigrar As Anthem.Button
    Protected WithEvents hdnWhiteListCadena As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Usc_direccion1 As usc_direccion
    Protected WithEvents Usc_direccion2 As usc_direccion
    Protected WithEvents Usc_direccion3 As usc_direccion
    Protected WithEvents hdnTipoCargo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCFPlanServicios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlOficina As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumero As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApePat As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtApeMat As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents txtConfirmCorreo As System.Web.UI.WebControls.TextBox
    Protected WithEvents hdnTiposDocumento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnCampanaDefault As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCancelar As Anthem.Button
    Protected WithEvents lblCampana As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCampana As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents hdnMontoFlat As System.Web.UI.HtmlControls.HtmlInputHidden

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
        'Introducir aquí el código de usuario para inicializar la página

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

        Anthem.Manager.Register(Me.Page)

        If Not Page.IsPostBack Then
            inicio()
            llenaCombos()
        End If
    End Sub


#Region "Metodos"

    Private Sub inicio()
        Try
        chkCorreo.Attributes.Add("onclick", "javascript:chkCorreo_click()")
        Me.hdnTiposDocumento.Value = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") + "|" + ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX")
        Me.hdnPlazoDefault.Value = ConfigurationSettings.AppSettings("cons_plazo_acuerdo_default")
        ObtenerDatosVendedor()
        Catch ex As Exception
            mensajeError(ex)
        End Try
    End Sub

    Private Sub ObtenerDatosVendedor()

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = txtNumero.Text & "|" & txtDocumento.Text & "|" & Me.CurrentUser
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ObtenerDatosVendedor()")
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP CurrentUser: " & Me.CurrentUser)

        If Me.CurrentUser = "" Then
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT ERROR: CurrentUser VACIO.")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo ObtenerDatosVendedor()")
            Throw New Exception("Se perdió la sesión del usuario. Ingrese nuevamente.")
        End If

        ' Buscar Datos del Usuario Logeado
        Dim oUsuario As Usuario
        oUsuario = New MaestroNegocio().ObtenerUsuarioLogin(Me.CurrentUser)
        Dim codUsuario As Integer = CheckInt(oUsuario.UsuarioId)


        ' Buscar Punto de Venta
        Dim listaPuntoVenta As ArrayList = New VentaNegocios().ListaPDVUsuario(codUsuario, "")
        If IsNothing(listaPuntoVenta) OrElse listaPuntoVenta.Count = 0 Then
            Throw New Exception("Error: Usuario no pertenece a algún Punto de Venta.")
        End If


        ' Guardar los datos generales de Venta
        Dim itemPuntoVenta As PuntoVenta = CType(listaPuntoVenta(0), PuntoVenta)
        Session.Add("strCodPuntoVenta", CheckStr(itemPuntoVenta.OVENC_CODIGO))
        Session.Add("strDescPuntoVenta", CheckStr(itemPuntoVenta.OVENV_DESCRIPCION))

        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT OVENC_CODIGO: " & itemPuntoVenta.OVENC_CODIGO)
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT OVENV_DESCRIPCION: " & itemPuntoVenta.OVENV_DESCRIPCION)
        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo ObtenerDatosVendedor()")

        oUsuario = Nothing
        itemPuntoVenta = Nothing
        listaPuntoVenta = Nothing
        objFileLog = Nothing
    End Sub

    Private Sub cargarPlazoAcuerdo()
        Dim objConsumerNegocio As New ConsumerNegocio
        Dim objPlazoAcuerdo As New PlazoAcuerdo
        Dim p As Integer

        Dim tipoproducto As String
        tipoproducto = ConfigurationSettings.AppSettings("constCodTipoProductoCON")
        Dim lista As New ArrayList
        lista = objConsumerNegocio.ListaPlazosAcuerdo("", tipoproducto, "A")

        Dim item As New ItemGenerico
        Dim arrayItems As New ArrayList

        For Each objPlazoAcuerdo In lista
            item = New ItemGenerico
            item.Codigo = objPlazoAcuerdo.PACUC_CODIGO
            item.Descripcion = objPlazoAcuerdo.PACUV_DESCRIPCION
            arrayItems.Add(item)
        Next objPlazoAcuerdo

        LlenaCombo(arrayItems, Me.ddlPlazoAcuerdo, "codigo", "descripcion", False, True, "Seleccione..")
        Me.ddlPlazoAcuerdo.UpdateAfterCallBack = True

        objConsumerNegocio = Nothing
        objPlazoAcuerdo = Nothing

    End Sub

    Private Sub llenaCombos()
        'campaña
        Dim oConsulta As New MaestroNegocio
        Dim lista As New ArrayList
        Dim tipoproducto, tipoVenta, strMandante As String
        Dim fecha As String = Now.ToString("yyyyMMdd")
        Dim strFiltro As String = ConfigurationSettings.AppSettings("constCampanasMigracion")

        tipoproducto = ConfigurationSettings.AppSettings("constCodTipoProductoCON")
        tipoVenta = ConfigurationSettings.AppSettings("constTipoVentaPostPago")
        strMandante = ConfigurationSettings.AppSettings("constCodMandt")

        lista = oConsulta.ConsultarListaCampanias(tipoVenta, fecha, strMandante, strFiltro)

        LlenaCombo(lista, Me.ddlCampana, "Codigo", "Descripcion", False, True)

        Try
            If (Not ConfigurationSettings.AppSettings("cons_campana_default") Is Nothing) Then
                Me.ddlCampana.SelectedValue = ConfigurationSettings.AppSettings("cons_campana_default")
                Me.hdnCampanaDefault.Value = ConfigurationSettings.AppSettings("cons_campana_default")
            End If
        Catch ex As Exception
        End Try

        'tipo de documento
        lista = oConsulta.ListaTipoDocumento("")
        Dim lstDocumentos As New ArrayList
        For Each tdoc As ItemGenerico In lista
            If tdoc.Codigo = ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") Or tdoc.Codigo = ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") Then
                lstDocumentos.Add(tdoc)
            End If
        Next

        'tipo de documento para validacion BSCS
        Me.ddlDoc.Items.Clear()
        Dim li As ListItem
        For Each tdoc As ItemGenerico In lstDocumentos
            li = New ListItem
            li.Text = tdoc.Descripcion
            li.Value = tdoc.Codigo + "|" + tdoc.Codigo2
            ddlDoc.Items.Add(li)
        Next
        Me.ddlDoc.Items.Insert(0, New ListItem("SELECCIONE..", "-1"))

        LlenaCombo(lstDocumentos, Me.ddlTipoDoc, "CODIGO", "DESCRIPCION", False, True)
        lstDocumentos = Nothing

        'plazo acuerdo
        cargarPlazoAcuerdo()

        'tipo de operacion 
        Dim objTipo As New TipoOperacionNegocio
        lista = objTipo.ListarTipoOperacion(0, tipoproducto)

        For Each objTipoOperacion As ItemGenerico In lista
            ddlTipoOperacion.Items.Add(New ListItem(objTipoOperacion.Descripcion, objTipoOperacion.Codigo + "-" + objTipoOperacion.Codigo2))
        Next
        ddlTipoOperacion.SelectedValue = ConfigurationSettings.AppSettings("cons_tipo_operacion_default")

        'oficinas-pto de venta
        lista = oConsulta.ListaPDVPorCanal(tipoproducto, ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT"))

        Me.ddlOficina.DataSource = lista
        Me.ddlOficina.DataTextField = "OVENV_DESCRIPCION"
        Me.ddlOficina.DataValueField = "OVENC_CODIGO"
        Me.ddlOficina.DataBind()
        Me.ddlOficina.Items.Insert(0, New ListItem("Seleccione..", "0"))

        oConsulta = Nothing

        lista = Nothing
    End Sub

    Private Sub cargarPlanes(ByVal cargo As Double)
        'cargar los planes que tengan cargo fijo menor o igual al parametro pasado
        Dim obj As New VentaExpressNegocios
        Dim lista As ArrayList
        Dim strPlanesFiltro As String = ConfigurationSettings.AppSettings("constPlanesExactosYDatos")
        Dim strPlan As String
        Try
            lista = obj.ListaPlanesMaxCF(ConfigurationSettings.AppSettings("constCodTipoClienteConsumer"), cargo)
            Me.ddlPlan.Items.Clear()

            For Each pl As Plan In lista
                strPlan = CType(pl.PLANN_CODIGO, String)
                If strPlanesFiltro.IndexOf(strPlan) < 0 Then
                    ddlPlan.Items.Add(New ListItem(pl.PLANV_DESCRIPCION, pl.PLANN_CODIGO.ToString + "|" + pl.PLANN_CAR_FIJ.ToString))
                End If
            Next

            Me.ddlPlan.Items.Insert(0, New ListItem("SELECCIONE..", "0"))

            Me.ddlPlan.UpdateAfterCallBack = True

        Catch ex As Exception
            mensajeError(ex)
        Finally
            obj = Nothing
            lista = Nothing
        End Try
    End Sub

    Private Sub BuscarServicios(ByVal codplan As String)
        Dim oConsulta As New VentaExpressNegocios
        'buscar los servicios del plan seleccionado
        Dim lista As ArrayList

        Try
            lista = oConsulta.Get_ConsultaPlanServicio(codplan, "")

            dgServicios.DataSource = lista
            dgServicios.DataBind()
            dgServicios.UpdateAfterCallBack = True

            If (lista.Count > 0) Then
                Anthem.Manager.AddScriptForClientSideEval("setVisible('divServicios',true);")
            Else
                Anthem.Manager.AddScriptForClientSideEval("setVisible('divServicios',false);")
            End If

        Catch ex As Exception
            mensajeError(ex)
        Finally
            lista = Nothing
            oConsulta = Nothing
        End Try
    End Sub

    Private Sub GenerarAcuerdo(ByVal objWL As MigracionWL, ByVal nroSEC As String, ByRef nroContrato As String, ByRef strEsPrepago As String, ByRef strDetalleAcuerdo As String, ByRef strMensaje As String)

        Dim oConsulta As New SapGeneralNegocios
        Dim strPrefijo, FechaActual, strTipoPlan As String
        Dim PuntoVenta As String
        Dim arrayContrato(67) As String

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = txtNumero.Text & "|" & txtDocumento.Text

        Try
            'txtNumeroCF
            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                PuntoVenta = CheckStr(Session("strCodPuntoVenta"))    'ConfigurationSettings.AppSettings("cons_cod_pdv_default")
            Else
                PuntoVenta = Me.ddlOficina.SelectedValue
            End If

            Dim x As Int32
            For x = 0 To arrayContrato.Length - 1
                arrayContrato(x) = ""
            Next


            Dim dblFactorCF As Double = CDbl(ConfigurationSettings.AppSettings("cteFactorCargoFijo"))    ' cteFactorCargoFijo = 1.6
            FechaActual = String.Format("{0:dd/MM/yyyy}", Now)

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo Get_Consulta_Prefijo()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP FechaActual: " & FechaActual)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP PuntoVenta: " & PuntoVenta)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP constPrefijoPCS: " & ConfigurationSettings.AppSettings("constPrefijoPCS"))

            strPrefijo = oConsulta.Get_Consulta_Prefijo(FechaActual, PuntoVenta, ConfigurationSettings.AppSettings("constPrefijoPCS"))

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT strPrefijo: " & strPrefijo)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo Get_Consulta_Prefijo()")

            Dim plan As String = CType(Me.dgPlan.Items(0).FindControl("hdnCodPlan"), System.Web.UI.HtmlControls.HtmlInputHidden).Value

            arrayContrato(0) = ""
            arrayContrato(1) = PuntoVenta    'Codigo Punto de Venta
            arrayContrato(2) = strPrefijo     'Prefijo PCS
            arrayContrato(3) = FechaActual    'Fecha de sistema
            arrayContrato(4) = Me.ddlPlazoAcuerdo.SelectedValue      'Codigo Plazo de Acuerdo
            arrayContrato(5) = objWL.NOMBRES
            arrayContrato(6) = objWL.APELLIDO_PATERNO
            arrayContrato(7) = objWL.APELLIDO_MATERNO
            arrayContrato(8) = objWL.APELLIDO_PATERNO + " " + objWL.APELLIDO_MATERNO + ", " + objWL.NOMBRES
            arrayContrato(9) = nroSEC      'Numero de SEC
            arrayContrato(10) = ConfigurationSettings.AppSettings("constEstadoAPRDesc")    'Descripcion estado SEC
            arrayContrato(20) = CStr(Session("CodVendedorSAP"))    'Codigo Vendedor
            arrayContrato(21) = ""      'Telefono_Vendedor
            arrayContrato(25) = ConfigurationSettings.AppSettings("constAnalistaCredito")     'Analista_Credito 
            arrayContrato(26) = "S"     'flag Migracion 
            arrayContrato(27) = ConfigurationSettings.AppSettings("constEstadoAcuerdoMigracion")    'Estado: No se realiza pago, entonces se envia con estado 0:NUEVO
            arrayContrato(32) = objWL.TIPO_DOCUMENTO      'Tipo_Doc_Cliente
            arrayContrato(33) = objWL.NRO_DOCUMENTO    'nro doc Cliente
            arrayContrato(34) = objWL.NRO_LINEA     'Telef migra
            arrayContrato(35) = plan    'cod Plan
            arrayContrato(41) = ddlCampana.SelectedValue     'cod Campana 
            arrayContrato(42) = ConfigurationSettings.AppSettings("constCodAprobadorSEC")     'Aprobador SEC            
            arrayContrato(43) = (CDbl(hdnCFPlanServicios.Value) * dblFactorCF).ToString    '(dblCargoFijoPlan + dblCargoFijoServicios) * dblFactorCF, agregar factor 1.6
            arrayContrato(45) = objWL.SCORE      'Score_Crediticio; a b c d s
            arrayContrato(46) = objWL.SCORE_CRED    'Control_Fraude ?
            arrayContrato(47) = nroSEC     'Codigo_Aprobacio (nroSEC)
            arrayContrato(54) = (CDbl(hdnCFPlanServicios.Value) * dblFactorCF).ToString    '(dblCargoFijoPlan + dblCargoFijoServicios) * dblFactorCF, agregar factor 1.6
            arrayContrato(57) = "1"     'Respons_Pago
            arrayContrato(62) = ConfigurationSettings.AppSettings("constCodTipoClienteConsumer")    'Tipo Cliente SAP
            arrayContrato(65) = "N"     'Con_Sin_Eq 

            If (LeerDatosLinea(Me.txtNumero.Text, strMensaje)) Then
                strEsPrepago = "S"
                arrayContrato(59) = "1"         'Para enviar activacion Recuerrente
                arrayContrato(60) = "X"       'Flag Activacion en Linea
                arrayContrato(63) = ConfigurationSettings.AppSettings("strVentaPrepago")      'strVentaPrepago = 02
                arrayContrato(64) = ConfigurationSettings.AppSettings("cteMotivoMigracionPrePost")     'Nuevo Motivo Prepago
            Else
                strEsPrepago = "N"
                arrayContrato(63) = "0"
                arrayContrato(64) = ""
            End If

            strMensaje = "WSDatosLinea:" & strMensaje
            strDetalleAcuerdo = Join(arrayContrato, ";")

            'METODO SAP generar acuerdo
            Dim mensaje As String
            Dim cadenaServicios As String
            nroContrato = ""
            cadenaServicios = obtenerCadenaServiciosFormatoSAP()

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo Get_RegistroAcuerdoPCS()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP FechaActual: " & FechaActual)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP arrayContrato: " & Join(arrayContrato, "|"))
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP cadenaServicios: " & cadenaServicios)

            'oConsulta.Get_RegistroAcuerdoPCS(arrayContrato, cadenaServicios, nroContrato, mensaje)

            Dim oConsultaSans As New SansNegocio
            Dim usuario_id As String = CurrentUser
            oConsultaSans.Get_RegistroAcuerdoPCS(arrayContrato, cadenaServicios, nroContrato, mensaje, txtNumero.Text, "", "", usuario_id)


            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT nroContrato: " & nroContrato)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT mensaje: " & mensaje)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo Get_RegistroAcuerdoPCS()")

            strMensaje = strMensaje & "|" & "RFCAcuerdo:" & mensaje
        Catch ex As Exception
            strMensaje = ex.Message
        End Try
    End Sub

    Private Sub registrarSolicitud(ByRef strNumSEC As String, ByRef strDetalleSEC As String)

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = txtNumero.Text & "|" & txtDocumento.Text

        Try
            Dim oSolicitud As SolicitudNegocios = New SolicitudNegocios
            Dim bResultado As Boolean
            Dim strNroSEC As String
            Dim DSolicitud As String = ""
            Dim objWL As MigracionWL = CType(Session("objWL"), MigracionWL)

            'cargo fijo seleccionado
            Dim cf_str As String = CType(Me.dgPlan.Items(0).FindControl("hdnCF"), System.Web.UI.HtmlControls.HtmlInputHidden).Value
            Dim cfplan As Double = 0.0

            If (cf_str <> "") Then
                'cargo fijo del plan seleccionado
                cfplan = Double.Parse(cf_str)
            End If

            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                DSolicitud = DSolicitud & CheckStr(Session("strCodPuntoVenta")) & ";"    'P_OVENC_CODIGO 'ConfigurationSettings.AppSettings("cons_cod_pdv_default")
            Else
                'si se solicito renta o deposito garantia entonces jalar la oficina del combo pdv
                DSolicitud = DSolicitud & Me.ddlOficina.SelectedValue & ";"     'P_OVENC_CODIGO
            End If

            Dim strCodPlan As String = CType(Me.dgPlan.Items(0).FindControl("hdnCodPlan"), System.Web.UI.HtmlControls.HtmlInputHidden).Value
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP strCodPlan: " & strCodPlan)

            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT") & ";"     'P_CANAC_CODIGO
            DSolicitud = DSolicitud & CStr(Session("codUsuarioSisact")) & ";"    'P_SOLIN_USU_VEN
            DSolicitud = DSolicitud & "1" & ";"    'P_SOLIC_EXI_BSC_FIN
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constAnalistaCredito") & ";"    'P_ANALC_CODIGO
            DSolicitud = DSolicitud & Me.ddlTipoDoc.SelectedValue & ";"    'P_TDOCC_CODIGO
            DSolicitud = DSolicitud & Right(("0000000000000000" & Trim(Me.txtNroDoc.Text)), 16) & ";"    'P_CLIEC_NUM_DOC
            DSolicitud = DSolicitud & Me.txtNombre.Text.Trim & " " & Me.txtApePat.Text.Trim & " " & Me.txtApeMat.Text.Trim & ";"    'P_CLIEV_RAZ_SOC strRazonSocial 
            DSolicitud = DSolicitud & "" & ";"     'P_CLIEN_PROM_VEN strPromedioVentas
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constCodTipoProductoCON") & ";"    'P_TPROC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constSegmentoConsumer") & ";"      'P_SEGMN_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constCodTipoClienteNAT") & ";"     'P_TCLIC_CODIGO consultar tipo cliente
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constTipoVentaPostPago") & ";"     'P_TVENC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constTipoActivacionInmediata") & ";"     'P_TACTC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constTipoOperacionMigracion") & ";"      'P_TOPEN_CODIGO
            DSolicitud = DSolicitud & strCodPlan & ";"      'P_SOLIC_PLA_MAX_1
            DSolicitud = DSolicitud & "" & ";"     'P_SOLIC_PLA_MAX_2
            DSolicitud = DSolicitud & "" & ";"     'P_SOLIC_PLA_MAX_3
            DSolicitud = DSolicitud & Me.ddlPlazoAcuerdo.SelectedValue & ";"     'P_PACUC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constFormaPagoEfectivo") & ";"     'P_FPAGC_CODIGO forma de pago
            DSolicitud = DSolicitud & "1" & ";"    'P_SOLIN_CAN_LIN
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constTipoActivacionInmediata") & ";"    'P_RFINC_CODIGO
            DSolicitud = DSolicitud & "" & ";"
            'If Me.hdnTipoCargo.Value = "" Then
            'DSolicitud = DSolicitud & "0" & ";" 'P_SOLIC_TIP_CAR_MAN --whitelist tipo cargo
            'Else
            DSolicitud = DSolicitud & Me.hdnTipoCargo.Value & ";"    'P_SOLIC_TIP_CAR_MAN --whitelist tipo cargo
            'End If
            DSolicitud = DSolicitud & Me.txtImporte.Text.Trim & ";"     'P_SOLIN_IMP_DG_MAN --importe
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constEstadoAPR") & ";"    'P_ESTAC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constTipoEvaluacion") & ";"     'P_TEVAC_CODIGO
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constFlagAprobado") & ";"    'P_SOLIC_FLA_TER
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constDescripcionAprobado") & ";"

            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                DSolicitud = DSolicitud & Left(CheckStr(Session("strDescPuntoVenta")), 20) & ";"    'P_SOLIV_DES_EST 
            Else
                DSolicitud = DSolicitud & Left(Me.ddlOficina.SelectedItem.Text, 20) & ";"    'P_SOLIV_DES_EST PMarcos Enviar los 20 primeras letras del punto de venta
            End If

            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constDescripcionAprobado") & ";"    'P_SOLIV_DES_RES_FIN
            DSolicitud = DSolicitud & ConfigurationSettings.AppSettings("constDescripcionActInmediata") & ";"    'P_SOLIV_DES_TIP_ACT
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_COM_PUN_VEN
            DSolicitud = DSolicitud & "" & ";"    'Comentario Evaluacion (Faltaba)
            DSolicitud = DSolicitud & CStr(Session("codUsuarioSisact")) & ";"     'P_SOLIC_USU_CRE
            DSolicitud = DSolicitud & Me.txtNombre.Text.Trim & ";"   'P_CLIEV_NOM
            DSolicitud = DSolicitud & Me.txtApePat.Text.Trim & ";"     'P_CLIEV_APE_PAT
            DSolicitud = DSolicitud & Me.txtApeMat.Text.Trim & ";"     'P_CLIEV_APE_MAT

            'direccion de cliente 
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PRE_DIR     
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_DIRECCION
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_REFERENCIA
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_DEP_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_PRO_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_DIS_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_COD_POS_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PRE_TEL
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_TELEFONO

            'direccion de trabajo
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PRE_DIR_TRA
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_DIR_TRA
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_REF_TRA
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_DEP_3
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_PRO_3
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_DIS_3
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_POS_3

            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PER_REF_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_TEL_REF_1
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PER_REF_2
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_TEL_REF_2

            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_PER_CON_TRA
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_TEL_FIJ_TRA

            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_EVA_ESS strValidacionEssalud
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_EVA_SUN strValidacionSunat
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_COD_RES_DIR strCodResultadoDir
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_DES_RES_DIR strDesResultadoDir
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_CAR_CLI strTipoCaractCliente
            'If Me.hdnTipoCargo.Value = "" Then
            'DSolicitud = DSolicitud & "0" & ";"  'P_SOLIC_TIP_CAR_FIJ strTipoGarantia whitelist
            'Else
            DSolicitud = DSolicitud & Me.hdnTipoCargo.Value & ";"     'P_SOLIC_TIP_CAR_FIJ strTipoGarantia whitelist
            'End If
            DSolicitud = DSolicitud & Me.txtImporte.Text.Trim & ";"     'P_SOLIN_IMP_DG strImporte whitelist
            DSolicitud = DSolicitud & Me.txtRiesgo.Text & ";"     'P_SOLIV_RES_EXP_CON strResultado
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_NUM_OPE_CON strNroOperacion
            DSolicitud = DSolicitud & objWL.LIMITE_CREDITO.ToString & ";"   'P_SOLIN_LIM_CRE_CON strLineaCredito whitelist //consultar manuelito

            DSolicitud = DSolicitud & cfplan.ToString & ";"     'P_SOLIN_SUM_CAR_CON strSumaPlanes CF del plan seleccionado //consultar manuelito
            DSolicitud = DSolicitud & Me.txtNumeroCF.Text.Trim & ";"     'P_SOLIN_NUM_CAR_FIJ strCantidadCF NRO CF WHITELIST
            DSolicitud = DSolicitud & "" & ";"    'P_TCESC_CODIGO strClienteEspecial
            DSolicitud = DSolicitud & objWL.SCORE & ";"     'P_SOLIC_SCO_TXT_CON strLetraScoreCrediticio SCORE WHITELIST
            DSolicitud = DSolicitud & objWL.SCORE_CRED & ";"    'P_SOLIN_SCO_NUM_CON strNumScoreCrediticio WHITELIST
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIN_CODIGO_PADRE strNroSECAnterior
            DSolicitud = DSolicitud & "" & ";"    'P_FLAG_INFOCORP strFlagInfocorp
            DSolicitud = DSolicitud & "" & ";"    'P_HINFV_MENSAJE strMensajeExplicacion
            DSolicitud = DSolicitud & "" & ";"    'P_RUCEMPLEADOR strRUCEmpleador
            DSolicitud = DSolicitud & "" & ";"    'P_NOMBREEMPRESA strNombreEmpresa
            DSolicitud = DSolicitud & Me.ddlCampana.SelectedValue & ";"     'P_CODCAMPANNA strCampanna
            DSolicitud = DSolicitud & "1" & ";"    'P_SOLIC_EXI_BSC_CON strCodExisteBSCS
            DSolicitud = DSolicitud & CStr(Session("CodVendedorSAP")) & ";"    'P_VENDEDOR_ID strIdVendedor
            DSolicitud = DSolicitud & objWL.FLAG_CONTROL_CONSUMO.ToString & ";"   'P_FLAG_CONSUMO strControlConsumo whitelist
            DSolicitud = DSolicitud & CType(IIf(Me.chkCorreo.Checked = True, "X", ""), String) & ";"    'P_SOLIV_FLAG_CORR strFlagCorreo si es que ha dado checkcorreo
            DSolicitud = DSolicitud & CType(IIf(Me.chkCorreo.Checked = True, Me.txtCorreo.Text.Trim, ""), String) & ";"    'P_SOLIV_CORREO strCorreo 

            DSolicitud = DSolicitud & "" & ";"    'P_CLIEV_EST_CIV
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIV_UBIGEO_INEI
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_ORIGEN_LC_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_ANALISIS_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_SCORE_RANKING_OPER_DC
            DSolicitud = DSolicitud & "0" & ";"    'P_SOLIN_PUNTAJE_DC
            DSolicitud = DSolicitud & "0" & ";"    'P_SOLIN_LC_DATA_CREDITO_DC
            DSolicitud = DSolicitud & "0" & ";"    'P_SOLIN_LC_BASE_EXTERNA_DC
            DSolicitud = DSolicitud & "0" & ";"    'P_SOLIN_LC_CLARO_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_REGLAS_DURAS_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_ALERT_COMPORT_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_ALERTAS_DC
            DSolicitud = DSolicitud & "" & ";"    'P_SOLIC_CORRESP_SALDO_DC
            DSolicitud = DSolicitud & "01/01/1900"    'P_CLIED_FEC_NAC



            strDetalleSEC = DSolicitud
            'Registrar Solicitud
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP strDetalleSEC: " & strDetalleSEC)
            bResultado = oSolicitud.RegistrarEvaluacionNaturalReingreso(DSolicitud, strNroSEC)
            strNumSEC = strNroSEC

            If (bResultado) Then
                Dim oDetallePlanes As New SolicitudNegocios
                Dim objItemPlan As New PlanDetalleConsumer

                objItemPlan.PLANC_CODIGO = strCodPlan
                objItemPlan.SOPLN_MONTO_UNIT = cfplan
                objItemPlan.SOPLN_CANTIDAD = 1
                objItemPlan.TPROC_CODIGO = ConfigurationSettings.AppSettings("constCodTipoProductoCON")
                objItemPlan.SOLIN_CODIGO = Funciones.CheckInt(strNumSEC)
                objItemPlan.SOPLC_MONTO_TOTAL = cfplan * 1
                oDetallePlanes.InsertarPlanSolicitud(objItemPlan)
            End If

            ModificarSolicitud(strNroSEC)
  
        Finally
            objFileLog = Nothing
        End Try
    End Sub

    Private Sub ModificarSolicitud(ByVal strCodSolicitud As String)

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = txtNumero.Text & "|" & txtDocumento.Text

        objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ModificarSolicitud()")

        'METODO JALADO DE LA PÁGINA SISACT_PERSONA_NATURAL_MOD.ASPX

        Dim itemDetalle As SolicitudPersona = New ConsumerNegocio().DetalleEvaluacionNatural(strCodSolicitud)
        Dim itemVistaSolicitud As New VistaSolicitud
        Dim itemSolicitud As New ConsultaSolicitud

        Try
            Dim strPrefijoDireccionC, strDireccionC, strReferenciaC, strDepartamentoC, strProvinciaC, strDistritoC, strCodigoPostalC, strPrefijoTelefonoC, strTelefonoC As String
            Dim strPrefijoDireccionT, strDireccionT, strReferenciaT, strDepartamentoT, strProvinciaT, strDistritoT, strCodigoPostalT, strPrefijoTelefonoT, strTelefonoT As String
            Dim strPrefijoDireccionF, strDireccionF, strReferenciaF, strDepartamentoF, strProvinciaF, strDistritoF, strCodigoPostalF, strPrefijoTelefonoF, strTelefonoF As String
            Dim strRUCEmpleador As String
            Dim strNombreEmpresa As String
            Dim strComentarios, strCodEstado, strDesEstado, strDomainUser, strCodUsuario, strTipoOperacion As String

            Dim strCodTipoActivacion As String = itemDetalle.TACTC_CODIGO
            Dim dblCodSolicitud As Double = Double.Parse(strCodSolicitud)
            Dim strNumeroOperacion As String = itemDetalle.SOLIV_NUM_OPE_CON
            Dim strNumeroDocumento As String = itemDetalle.CLIEC_NUM_DOC
            Dim dblLimiteCredito As Double = itemDetalle.SOLIN_LIM_CRE_CON
            Dim strCodTipoAfiliacion As String = itemDetalle.TAFIC_CODIGO

            'DIRECCION DE CLIENTE
            strPrefijoDireccionC = Usc_direccion2.pIdprefijo    'PREFIJO DE DIRECCION CLIENTE
            strDireccionC = Usc_direccion2.pDireccionTotal      'DIRECCION DEL CLIENTE
            Dim strDireccionSAP_c As String = Usc_direccion2.pDireccionSAP
            strReferenciaC = Usc_direccion2.ptxtReferencia     'REFERENCIA DIRECCION DEL CLIENTE
            strDepartamentoC = Usc_direccion2.pddlDepartamento    'DEPARTAMENTO DIRECCION DEL CLIENTE
            strProvinciaC = Usc_direccion2.hiddenProvinciaID     'PROVINCIA DIRECCION DEL CLIENTE
            strDistritoC = Usc_direccion2.hiddenDistritoID      'DISTRITO DIRECCION DEL CLIENTE
            strCodigoPostalC = Usc_direccion2.ptxtCodigoPostal    'COD.POSTAL DIRECCION DEL CLIENTE
            strPrefijoTelefonoC = Usc_direccion2.ptxtPrefijoTelefonoRef    'PREFIJO DEL TELEFONO - CIUDAD
            strTelefonoC = Usc_direccion2.ptxtTelefonoReferencia     'TELEFONO DEL CLIENTE

            'DIRECCION DE TRABAJO
            strPrefijoDireccionT = Usc_direccion3.pIdprefijo      'PREFIJO DE DIRECCION TRABAJO
            strDireccionT = Usc_direccion3.pDireccionTotal     'DIRECCION DE TRABAJO
            Dim strDireccionSAP_t As String = Usc_direccion3.pDireccionSAP
            strReferenciaT = Usc_direccion3.ptxtReferencia      'REFERENCIA DIRECCION DE TRABAJO
            strDepartamentoT = Usc_direccion3.pddlDepartamento     'DEPARTAMENTO DIRECCION DE TRABAJO
            strProvinciaT = Usc_direccion3.hiddenProvinciaID     'PROVINCIA DIRECCION DE TRABAJO
            strDistritoT = Usc_direccion3.hiddenDistritoID    'DISTRITO DIRECCION DE TRABAJO
            strCodigoPostalT = Usc_direccion3.ptxtCodigoPostal     'COD.POSTAL DIRECCION DE TRABAJO
            strPrefijoTelefonoT = Usc_direccion3.ptxtPrefijoTelefonoRef     'PREFIJO DEL TELEFONO - CIUDAD
            strTelefonoT = Usc_direccion3.ptxtTelefonoReferencia      'TELEFONO DEL TRABAJO 

            'DIRECCION DE FACTURACION
            strPrefijoDireccionF = Usc_direccion1.pIdprefijo    'PREFIJO DE DIRECCION FACTURACION
            strDireccionF = Usc_direccion1.pDireccionTotal      'DIRECCION DE FACTURACION
            Dim strDireccionSAP_f As String = Usc_direccion1.pDireccionSAP
            strReferenciaF = Usc_direccion1.ptxtReferencia   'REFERENCIA DIRECCION DE FACTURACION
            strDepartamentoF = Usc_direccion1.pddlDepartamento   'DEPARTAMENTO DIRECCION DE FACTURACION
            strProvinciaF = Usc_direccion1.hiddenProvinciaID     'PROVINCIA DIRECCION DE FACTURACION
            strDistritoF = Usc_direccion1.hiddenDistritoID    'DISTRITO DIRECCION DE FACTURACION
            strCodigoPostalF = Usc_direccion1.ptxtCodigoPostal     'COD.POSTAL DIRECCION DE FACTURACION
            strPrefijoTelefonoF = Usc_direccion1.ptxtPrefijoTelefonoRef    'PREFIJO DEL TELEFONO - CIUDAD
            strTelefonoF = Usc_direccion1.ptxtTelefonoReferencia    'TELEFONO DEL FACTURACION

            strRUCEmpleador = Usc_direccion1.ptxtNumeroRUC    'RUC DEL EMPLEADOR
            strNombreEmpresa = Usc_direccion1.ptxtNombreEmpleador   'NOMBRE DEL EMPLEADOR

            Dim DSolicitud As String = ""

            itemVistaSolicitud.solin_codigo = Funciones.CheckInt64(strCodSolicitud)
            itemVistaSolicitud.CLIED_FEC_NAC = Date.Parse("01/01/1900")
            itemVistaSolicitud.solic_fla_ter = "S"
            itemVistaSolicitud.cliev_pre_tel_leg = strPrefijoTelefonoC
            itemVistaSolicitud.cliev_tel_leg = strTelefonoC
            itemVistaSolicitud.cliev_pre_dir = strPrefijoDireccionC
            itemVistaSolicitud.cliev_direccion = strDireccionC
            itemVistaSolicitud.cliev_ref_dir = strReferenciaC
            itemVistaSolicitud.cliec_cod_dep_dir = strDepartamentoC
            itemVistaSolicitud.cliec_cod_pro_dir = strProvinciaC
            itemVistaSolicitud.cliec_cod_dis_dir = strDistritoC
            itemVistaSolicitud.cliec_cod_pos_dir = strCodigoPostalC
            itemVistaSolicitud.cliev_pre_dir_fac = strPrefijoDireccionF
            itemVistaSolicitud.cliev_dir_fac = strDireccionF
            itemVistaSolicitud.cliev_ref_dir_fac = strReferenciaF
            itemVistaSolicitud.cliec_cod_dep_fac = strDepartamentoF
            itemVistaSolicitud.cliec_cod_pro_fac = strProvinciaF
            itemVistaSolicitud.cliec_cod_dis_fac = strDistritoF
            itemVistaSolicitud.cliec_cod_pos_fac = strCodigoPostalF
            itemVistaSolicitud.cliev_pre_dir_tra = strPrefijoDireccionT
            itemVistaSolicitud.cliev_dir_tra = strDireccionT
            itemVistaSolicitud.cliev_ref_dir_tra = strReferenciaT
            itemVistaSolicitud.cliec_cod_dep_tra = strDepartamentoT
            itemVistaSolicitud.cliec_cod_pro_tra = strProvinciaT
            itemVistaSolicitud.cliec_cod_dis_tra = strDistritoT
            itemVistaSolicitud.cliec_cod_pos_tra = strCodigoPostalT


            itemVistaSolicitud.cliev_tel_fij_tra = strTelefonoT

            itemVistaSolicitud.solin_lim_cre_fin = itemDetalle.SOLIN_LIM_CRE_CON.ToString
            itemVistaSolicitud.solic_sco_txt_fin = itemDetalle.SOLIC_SCO_TXT_CON.ToString
            itemVistaSolicitud.solin_sco_num_fin = itemDetalle.SOLIN_SCO_NUM_CON.ToString

            Dim strResultadoVerificacion, strResultadoFinal, strResultadoMotivoRechazo, strTipoCargoFijoManual, strImporteManual As String
            If strCodTipoActivacion = ConfigurationSettings.AppSettings("constTipoActivacionINM") Then
                strResultadoVerificacion = ConfigurationSettings.AppSettings("constResultadoDireccionPostVenta")
                strResultadoFinal = ConfigurationSettings.AppSettings("constCodResultadoFinalAPR")
                strResultadoMotivoRechazo = ""
                strTipoCargoFijoManual = ""

                strImporteManual = "0"
            Else
                strResultadoVerificacion = itemDetalle.RDIRC_CODIGO
                strResultadoFinal = itemDetalle.RFINC_CODIGO
                strResultadoMotivoRechazo = ""
                strTipoCargoFijoManual = ""

                strImporteManual = "0"
            End If

            itemVistaSolicitud.rdirc_codigo = strResultadoVerificacion
            itemVistaSolicitud.rfinc_codigo = strResultadoFinal
            itemVistaSolicitud.mrecc_codigo = strResultadoMotivoRechazo
            itemVistaSolicitud.solin_imp_dg_man = Double.Parse(strImporteManual)
            itemVistaSolicitud.solic_tip_car_man = strTipoCargoFijoManual
            itemVistaSolicitud.soliv_com_dg = ""
            itemVistaSolicitud.tevac_codigo = ConfigurationSettings.AppSettings("constCodEvaluadorCET")
            strCodEstado = ConfigurationSettings.AppSettings("constEstadoAPR")
            strDesEstado = ConfigurationSettings.AppSettings("constEstadoAPRDesc")
            itemVistaSolicitud.estac_codigo = strCodEstado
            itemVistaSolicitud.soliv_des_est = strDesEstado
            strCodUsuario = CStr(Session("codUsuarioSisact"))
            itemVistaSolicitud.solic_usu_cre = strCodUsuario

            Dim strCodTarjeta, strCodTipoMoneda, strNumeroTarjeta, strNombreTarjeta, strNumeroDocumentoTarjeta, strFechaVigenciaTarjeta, strMontoMaximo As String
            If itemDetalle.FPAGC_CODIGO = ConfigurationSettings.AppSettings("constFormaPagoTAR") Then
                strCodTipoAfiliacion = strCodTipoAfiliacion    'CODIGO TIPO AFILIACION
                strCodTarjeta = ""
                strCodTipoMoneda = ""
                strNumeroTarjeta = ""
                strNombreTarjeta = ""
                strNumeroDocumentoTarjeta = ""
                strFechaVigenciaTarjeta = ""
                strMontoMaximo = ""
            Else
                strCodTipoAfiliacion = ""
                strCodTarjeta = ""
                strCodTipoMoneda = ""
                strNumeroTarjeta = ""
                strNombreTarjeta = ""
                strNumeroDocumentoTarjeta = ""
                strFechaVigenciaTarjeta = ""
                strMontoMaximo = ""
            End If

            itemVistaSolicitud.tafic_codigo = strCodTipoAfiliacion
            itemVistaSolicitud.solic_cod_tar = strCodTarjeta
            itemVistaSolicitud.solic_cod_tip_mon = strCodTipoMoneda
            itemVistaSolicitud.soliv_num_tar = strNumeroTarjeta
            itemVistaSolicitud.soliv_nom_tit_tar = strNombreTarjeta
            itemVistaSolicitud.soliv_doc_tit_tar = strNumeroDocumentoTarjeta
            itemVistaSolicitud.soliv_fec_ven_tar = strFechaVigenciaTarjeta
            itemVistaSolicitud.solin_mntomax = strMontoMaximo
            itemVistaSolicitud.soliv_num_ope_fin = itemSolicitud.SOLIN_CODIGO

            strTipoOperacion = Me.ddlTipoOperacion.SelectedValue.Split("-"c)(0)
            itemVistaSolicitud.SOLID_FEC_APR = Date.Now

            itemVistaSolicitud.topen_codigo = strTipoOperacion
            itemVistaSolicitud.rucempleador = strRUCEmpleador
            itemVistaSolicitud.nombreempresa = strNombreEmpresa
            itemVistaSolicitud.TACTC_CODIGO = ConfigurationSettings.AppSettings("constTipoActivacionInmediata")
            itemVistaSolicitud.SOLIC_COD_APROB = CStr(Session("codUsuarioSisact")).ToUpper

            If itemVistaSolicitud.rfinc_codigo.Equals("") Then
                itemVistaSolicitud.rfinc_codigo = ConfigurationSettings.AppSettings("constTipoActivacionInmediata")
                itemVistaSolicitud.SOLIV_DES_RES_FIN = ConfigurationSettings.AppSettings("constEstadoAPRDesc")
            End If

            Dim arraySol As ArrayList = New SolicitudNegocios().ObtenerConsultaSolicitudCons(strCodSolicitud, "", "")
            Dim parSAP As String = ""
            Dim DclienteSAP(64) As String

            If arraySol.Count > 0 Then
                itemSolicitud = CType(arraySol(0), ConsultaSolicitud)
            End If

            Dim dtDatosSAP As DataSet
            Dim SAPNegocios As New SapGeneralNegocios
            Dim datosenSAP As Boolean = False
            dtDatosSAP = SAPNegocios.Get_ConsultaCliente(itemDetalle.OVENC_CODIGO, itemSolicitud.TDOCC_CODIGO, strNumeroDocumento)
            If dtDatosSAP.Tables(0).Rows.Count > 0 Then
                datosenSAP = True
            End If


            If datosenSAP = False Then
                DclienteSAP(36) = "0.00"
                DclienteSAP(37) = "0.00"
                DclienteSAP(41) = "0.00"

                DclienteSAP(18) = ""    'strCodTipoDocumentoRepLegal
                DclienteSAP(19) = ""    'strNumeroDocumentoRepLegal
                DclienteSAP(20) = ""    'strNombreRepLegal
                DclienteSAP(21) = ""    'strApellidoPaternoRepLegal
                DclienteSAP(22) = ""    'strApellidoManternoRepLegal

                DclienteSAP(24) = ""    'strCodTipoDocumentoContacto
                DclienteSAP(25) = ""    'strNumeroDocumentoContacto	
                DclienteSAP(26) = ""    'strNombreContacto 
                DclienteSAP(27) = ""    'strApellidoPaternoContacto  
                DclienteSAP(28) = ""    'strApellidoManternoContacto 
                DclienteSAP(29) = ""    'strCargoContacto   

                DclienteSAP(40) = ""    'CODIGO TIPO DE MONEDA

                DclienteSAP(7) = "01/01/1900"
                DclienteSAP(8) = ""
                DclienteSAP(9) = ""
                DclienteSAP(10) = ""
                DclienteSAP(11) = " "
                DclienteSAP(12) = "00"
                DclienteSAP(13) = ""
                DclienteSAP(23) = ""
                DclienteSAP(29) = ""
                DclienteSAP(31) = ""
                DclienteSAP(32) = ""
                DclienteSAP(33) = ""
                DclienteSAP(34) = ""
                DclienteSAP(35) = ""
                DclienteSAP(36) = "0.00"
                DclienteSAP(37) = "0.00"
                DclienteSAP(38) = ""
                DclienteSAP(39) = ""
                DclienteSAP(41) = "0.00"
                DclienteSAP(42) = ""
                DclienteSAP(43) = ""
                DclienteSAP(44) = ""
                DclienteSAP(45) = ""
                DclienteSAP(46) = ""
                DclienteSAP(47) = ""
                DclienteSAP(48) = ""
                DclienteSAP(49) = ""
                DclienteSAP(50) = ""
                DclienteSAP(51) = ""
                DclienteSAP(52) = ""
                DclienteSAP(53) = ""
                DclienteSAP(55) = ""
                DclienteSAP(56) = "01"
                DclienteSAP(57) = ""
                DclienteSAP(58) = "00"
                DclienteSAP(59) = "00"
                DclienteSAP(60) = "0"
                DclienteSAP(61) = ""
                DclienteSAP(62) = ""
            Else
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Inicio lectura dtDatosSAP ")
                For i As Integer = 0 To dtDatosSAP.Tables(0).Columns.Count - 1
                    DclienteSAP(i) = CheckStr(dtDatosSAP.Tables(0).Rows(0)(i))
                Next
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Fin lectura dtDatosSAP ")
            End If


            DclienteSAP(0) = strNumeroDocumento    'NUMERO DE DOCUMENTO DE IDENTIDAD
            DclienteSAP(1) = itemSolicitud.TDOCC_CODIGO   'CODIGO ENTERO TIPO DE DOCUMENTO
            DclienteSAP(2) = ConfigurationSettings.AppSettings("constCodTipoProductoConSAP")    '02

            If itemSolicitud.TDOCC_CODIGO = ConfigurationSettings.AppSettings("TipoDocumentoRUC") Then
                DclienteSAP(3) = ""
                DclienteSAP(4) = ""
                DclienteSAP(5) = ""
            Else
                DclienteSAP(3) = itemSolicitud.CLIEV_NOMBRE
                DclienteSAP(4) = itemSolicitud.CLIEV_APE_PAT
                DclienteSAP(5) = itemSolicitud.CLIEV_APE_MAT
            End If

            DclienteSAP(6) = ""    'RAZON SOCIAL DEL CLIENTE	
            DclienteSAP(7) = Convert.ToDateTime("01/01/1900").ToString("yyyy/MM/dd")

            Dim strUbigeoClienteDomicilio As String = Trim(strDepartamentoC) & Trim(strProvinciaC) & Trim(strDistritoC)
            If (Not (Trim(strUbigeoClienteDomicilio) = "")) Then
                DclienteSAP(14) = Mid(Trim(strPrefijoDireccionC) & " " & Trim(strDireccionSAP_c), 1, 40)    'DIRECCION DEL CLIENTE
                DclienteSAP(15) = strUbigeoClienteDomicilio    'UBIGEO DIRECCION DEL CLIENTE 'strDepartamento1 & strProvincia1 & strDistrito1
            End If

            Dim strUbigeoClienteFacturacion As String = Trim(strDepartamentoF) & Trim(strProvinciaF) & Trim(strDistritoF)
            If (Not (Trim(strUbigeoClienteFacturacion) = "")) Then
                DclienteSAP(16) = Mid(Trim(strPrefijoDireccionF) & " " & Trim(strDireccionSAP_f), 1, 40)
                DclienteSAP(17) = strUbigeoClienteFacturacion    'UBIGEO DIRECCION DEL CLIENTE FACTURACION
            End If
            'datos de legal            
            DclienteSAP(54) = Mid(Trim(strReferenciaC), 1, 40)    'REFERENCIA DE DIRECCION
            DclienteSAP(63) = Mid(Trim(strReferenciaF), 1, 40)    'REFERENCIA DE DIRECCION FACT

            Dim ptoVenta As String

            If itemDetalle.CANAC_CODIGO <> ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT") Then
                If Funciones.CheckDbl(itemDetalle.SOLIN_IMP_DG) <> 0.0 Or Funciones.CheckDbl(itemDetalle.SOLIN_IMP_DG_MAN) <> 0.0 Or Funciones.CheckDbl(itemDetalle.SOLIN_IMP_RA) <> 0.0 Then
                    ptoVenta = "0001"
                Else
                    ptoVenta = CStr(itemDetalle.OVENC_CODIGO)
                End If
            Else
                ptoVenta = CStr(itemDetalle.OVENC_CODIGO)
            End If

            Dim res As Boolean
            Dim strConfirma As String
            Dim dt As New DataSet
            Dim sap As New SapGeneralNegocios
            dt = sap.Set_ActualizaCreaCliente(ptoVenta, DclienteSAP)
            Dim strMensaje As String
            strMensaje = ""

            For i As Integer = 0 To dt.Tables(1).Rows.Count - 1
                If CType(dt.Tables(1).Rows(i).Item("TYPE"), String) = "E" Then
                    strMensaje = CType(dt.Tables(1).Rows(i).Item("MESSAGE"), String)
                End If
            Next

            If strMensaje.Length > 0 Then
                strConfirma += "<script>alert('" & strMensaje & "');"
                strConfirma += "</script>"
                RegisterStartupScript("script", strConfirma)
                Exit Sub
            End If

            res = New SolicitudNegocios().ModificacionEvaluacionNaturalConsumer(itemVistaSolicitud)
        Catch ex As Exception
            'Throw ex
        Finally
            itemDetalle = Nothing
            itemVistaSolicitud = Nothing
        End Try
    End Sub

    Private Sub insertarLogMigracion(ByVal nrosec As String, ByVal nroContrato As String, ByVal existeWL As String, ByVal validobscs As String, ByVal esprepago As String, ByVal strMensajeRegMigra As String, ByVal strInputWS As String)
        Dim obj As VentaExpressNegocios
        Dim arrLog(13) As String

        Try
            obj = New VentaExpressNegocios

            arrLog(0) = Me.txtNumero.Text
            arrLog(1) = Me.ddlDoc.SelectedValue.Split("|"c)(0)
            arrLog(2) = Me.txtDocumento.Text
            arrLog(3) = existeWL    'existe wl
            arrLog(4) = validobscs    'valido bscs
            arrLog(5) = esprepago    'v_logmc_es_prepago
            arrLog(6) = nrosec
            arrLog(7) = nroContrato
            arrLog(8) = Me.hdnTipoCargo.Value
            arrLog(9) = strInputWS    'v_logmc_activ_input_param
            If Len(strMensajeRegMigra) > 0 Then
                If CStr(ConfigurationSettings.AppSettings("consFlagNuevoWSMigracion")).Equals("1") Then
                    arrLog(10) = CStr(strMensajeRegMigra.Split(";"c)(0))    'v_logmc_activ_result
                    arrLog(11) = CStr(strMensajeRegMigra.Split(";"c)(1))    'v_logmc_activ_des_result
                Else
                    arrLog(11) = strMensajeRegMigra
                End If
            End If
            arrLog(12) = CStr(Session("CodVendedorSAP"))    'v_logmv_cod_vendedor

            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                arrLog(13) = CheckStr(Session("strCodPuntoVenta"))    'ConfigurationSettings.AppSettings("cons_cod_pdv_default")				'v_logmv_punto_venta
            Else
                arrLog(13) = Me.ddlOficina.SelectedValue    'v_logmv_punto_venta
            End If

            obj.insertarLogMigracion(arrLog)

        Catch ex As Exception
        Finally
            obj = Nothing
        End Try
    End Sub

    Private Function ejecutarMigracionRecurrente(ByVal strContrato As String, ByRef blnRespuestaMig As Boolean) As String

        Dim objActivacion As New clsActivacion
        Dim strRespuesta As String = ""
        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = txtNumero.Text & "|" & txtDocumento.Text

        Try
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo FK_ActivacionClienteRecurrente()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP strContrato: " & strContrato)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP consStrUrlSvrACR: " & ConfigurationSettings.AppSettings("consStrUrlSvrACR"))
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP consStrServicioACR: " & ConfigurationSettings.AppSettings("consStrServicioACR"))
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP consStrUsuarioACR: " & ConfigurationSettings.AppSettings("consStrUsuarioACR"))

            strRespuesta = objActivacion.FK_ActivacionClienteRecurrente(strContrato, ConfigurationSettings.AppSettings("consStrUrlSvrACR"), ConfigurationSettings.AppSettings("consStrServicioACR"), ConfigurationSettings.AppSettings("consStrUsuarioACR"))

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT strRespuesta: " & strRespuesta)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo FK_ActivacionClienteRecurrente()")

            If strRespuesta.ToUpper.Equals(CStr(ConfigurationSettings.AppSettings("consStrRespuestaACR")).ToUpper) Then
                blnRespuestaMig = True
            Else
                blnRespuestaMig = False
            End If

        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT ERROR: " & ex.Message)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo FK_ActivacionClienteRecurrente()")

            strRespuesta = strRespuesta & "|" & ex.Message
            blnRespuestaMig = False
        End Try
        objActivacion = Nothing
        Return strRespuesta
    End Function

    Private Function ejecutarMigracion(ByVal objWL As MigracionWL, ByVal nroContrato As String, ByRef strMensaje As String, ByRef strInputWS As String) As Boolean

        Dim objTransaccion As New Claro.SISACT.Entidades.DetalleTransaccion
        Dim objMigracionNegocios As New MigracionNegocios
        Dim item As New ItemGenerico
        Dim datosCliente As New Cliente
        Dim objInteraccion As New Interaccion
        Dim strCodInteraccion As String
        Dim oXml As String
        Dim strFlagInsercion As String
        Dim blnRegistraMigracion As Boolean
        Dim blnRespuesta As Boolean

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = objWL.NRO_LINEA & "|" & objWL.NRO_DOCUMENTO
        Dim blnRespuestaMig As Boolean
        Me.btnCancelar.Enabled = False

        Try
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo CrearInteraccion()")

            If LeerDatosCliente(objWL.NRO_LINEA, datosCliente) Then
                objInteraccion = ObjetoInteraccion(CheckStr(datosCliente.OBJID_CONTACTO), objWL.NRO_LINEA)
                item = CType(CrearInteraccion(objInteraccion), ItemGenerico)
                strCodInteraccion = CheckStr(item.Codigo)

                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP OBJID_CONTACTO: " & datosCliente.OBJID_CONTACTO)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP NRO_LINEA: " & objWL.NRO_LINEA)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT strCodInteraccion: " & strCodInteraccion)
            End If

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo CrearInteraccion()")

            objTransaccion.SERVD_FECHAPROG = System.DateTime.Now.ToString("dd/MM/yyyy")
            objTransaccion.SERVD_FECHA_REG = System.DateTime.Now.ToString("dd/MM/yyyy")
            objTransaccion.SERVC_ESTADO = ConfigurationSettings.AppSettings("CONS_SERVC_ESTADO")
            objTransaccion.SERVC_ESBATCH = ConfigurationSettings.AppSettings("CONS_SERVC_ESBATCH")
            objTransaccion.SERVV_USUARIO_SISTEMA = ConfigurationSettings.AppSettings("CONS_SERVV_USUARIO_SISTEMA")
            objTransaccion.SERVV_ID_EAI_SW = ConfigurationSettings.AppSettings("CONS_SERVV_ID_EAI_SW")
            objTransaccion.SERVI_COD = Funciones.CheckInt(ConfigurationSettings.AppSettings("CONS_SERVI_COD"))
            objTransaccion.SERVV_MSISDN = objWL.NRO_LINEA
            objTransaccion.SERVV_USUARIO_APLICACION = ConfigurationSettings.AppSettings("CONS_SERVV_USUARIO_APLICACION")
            objTransaccion.SERVV_EMAIL_USUARIO_APP = ConfigurationSettings.AppSettings("CONS_SERVV_EMAIL_USUARIO_APP")
            objTransaccion.SERVC_NROCUENTA = ""    'Es vacío para las migraciones desde prepago. hidNroCuenta.Value
            objTransaccion.SERVC_PUNTOVENTA = Funciones.CheckStr(Session("strDescPuntoVenta"))
            objTransaccion.SERVC_ASESOR = Funciones.CheckStr(Session("codUsuarioSisact"))
            objTransaccion.SERVC_CODIGO_INTERACCION = strCodInteraccion
            objTransaccion.ID_TRANSACCION = GenerarIdTransaccion()

            Dim strXML As String
            oXml = oXml & "<ns0:MigracionRequest xmlns:ns0=""http://pe.com.claro/services/schemas/ProcesoMigracion"">"
            oXml = oXml & "<idTransaccion>{0}</idTransaccion>"
            oXml = oXml & "<flagActLimitCredit>{1}</flagActLimitCredit>"
            oXml = oXml & "<msisdn>{2}</msisdn>"
            oXml = oXml & "<coID>{3}</coID>"
            oXml = oXml & "<csID>{4}</csID>"
            oXml = oXml & "<cuenta>{5}</cuenta>"
            oXml = oXml & "<escenario>{6}</escenario>"
            oXml = oXml & "<codProd>{7}</codProd>"
            oXml = oXml & "<tipoDeActivacion>{8}</tipoDeActivacion>"
            oXml = oXml & "<fechaAplicacion>{9}</fechaAplicacion>"
            oXml = oXml & "<costoMigracion>{10}</costoMigracion>"
            oXml = oXml & "<montoOccApadece>{11}</montoOccApadece>"
            oXml = oXml & "<conceptoOccSerc>{12}</conceptoOccSerc>"
            oXml = oXml & "<montoOccSerc>{13}</montoOccSerc>"
            oXml = oXml & "<cacDac>{14}</cacDac>"
            oXml = oXml & "<asesor>{15}</asesor>"
            oXml = oXml & "<codigoInteraccion>{16}</codigoInteraccion>"
            oXml = oXml & "<acuerdo>{17}</acuerdo>"
            oXml = oXml & "<montoPCS>{18}</montoPCS>"
            oXml = oXml & "<areaPCS>{19}</areaPCS>"
            oXml = oXml & "<motivoPCS>{20}</motivoPCS>"
            oXml = oXml & "<subMotivoPCS>{21}</subMotivoPCS>"
            oXml = oXml & "<cicloFact>{22}</cicloFact>"
            oXml = oXml & "<idTipoCliente>{23}</idTipoCliente>"
            oXml = oXml & "<numDoc>{24}</numDoc>"
            oXml = oXml & "</ns0:MigracionRequest>"

            oXml = String.Format(oXml, _
             objTransaccion.ID_TRANSACCION, _
             "0", _
             objWL.NRO_LINEA, _
             "0", _
             "0", _
             "", _
             ConfigurationSettings.AppSettings("strEscenarioMigracion"), _
             ConfigurationSettings.AppSettings("strCodProductoMigracion"), _
             ConfigurationSettings.AppSettings("strTipoActivacionMigracion"), _
             System.DateTime.Now.ToString("dd/MM/yyyy"), _
             "0", _
             "0", _
             "0", _
             "0", _
             Funciones.CheckStr(Session("strCodPuntoVenta")), _
             Funciones.CheckStr(Session("codUsuarioSisact")), _
             objTransaccion.SERVC_CODIGO_INTERACCION, _
             nroContrato, _
             "0", _
             "0", _
             "0", _
             "0", _
             "0", _
             "0", _
             "")

            objTransaccion.SERVV_XMLENTRADA = CType(oXml, Object)

            strInputWS = GeneraCadenaLogWS(objTransaccion)

            'REGISTRAR MIGRACION
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo RegistrarMigracion()")

            blnRegistraMigracion = objMigracionNegocios.RegistrarMigracion(objTransaccion, strFlagInsercion, strMensaje)

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT strMensaje: " & strMensaje)
            If blnRegistraMigracion Then
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT blnRegistraMigracion: " & "TRUE")
            Else
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 OUT blnRegistraMigracion: " & "FALSE")
            End If
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo RegistrarMigracion()")

            'LLAMAR WS DE MIGRACION
            If blnRegistraMigracion Then
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ejecutarMigracion()")
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP SERVV_MSISDN: " & objTransaccion.SERVV_MSISDN)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP SERVD_FECHAPROG: " & objTransaccion.SERVD_FECHAPROG)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		 INP ID_TRANSACCION: " & objTransaccion.ID_TRANSACCION)

                objMigracionNegocios.ejecutarMigracion(objTransaccion.SERVV_MSISDN, objTransaccion.SERVD_FECHAPROG, "", objTransaccion.ID_TRANSACCION)

                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo ejecutarMigracion()")
            End If

            blnRespuesta = True
        Catch ex As Exception
            blnRespuesta = False
            strMensaje = "1;" & ex.Message
        Finally
            objMigracionNegocios = Nothing
            objFileLog = Nothing
        End Try

        Return blnRespuesta
    End Function

    Private Function GeneraCadenaLogWS(ByVal objTransaccion As DetalleTransaccion) As String
        Dim strInputWS As String = ""
        Try
            strInputWS = strInputWS & "SERVD_FECHAPROG:" & Funciones.CheckStr(objTransaccion.SERVD_FECHAPROG) & "|"
            strInputWS = strInputWS & "SERVD_FECHA_REG:" & Funciones.CheckStr(objTransaccion.SERVD_FECHA_REG) & "|"
            strInputWS = strInputWS & "SERVC_ESTADO:" & Funciones.CheckStr(objTransaccion.SERVC_ESTADO) & "|"
            strInputWS = strInputWS & "SERVC_ESBATCH:" & Funciones.CheckStr(objTransaccion.SERVC_ESBATCH) & "|"
            strInputWS = strInputWS & "SERVV_USUARIO_SISTEMA:" & Funciones.CheckStr(objTransaccion.SERVV_USUARIO_SISTEMA) & "|"
            strInputWS = strInputWS & "SERVV_ID_EAI_SW:" & Funciones.CheckStr(objTransaccion.SERVV_ID_EAI_SW) & "|"
            strInputWS = strInputWS & "SERVI_COD:" & Funciones.CheckStr(objTransaccion.SERVI_COD) & "|"
            strInputWS = strInputWS & "SERVV_MSISDN:" & Funciones.CheckStr(objTransaccion.SERVV_MSISDN) & "|"
            strInputWS = strInputWS & "SERVV_USUARIO_APLICACION:" & Funciones.CheckStr(objTransaccion.SERVV_USUARIO_APLICACION) & "|"
            strInputWS = strInputWS & "SERVV_EMAIL_USUARIO_APP:" & Funciones.CheckStr(objTransaccion.SERVV_EMAIL_USUARIO_APP) & "|"
            strInputWS = strInputWS & "SERVC_NROCUENTA:" & Funciones.CheckStr(objTransaccion.SERVC_NROCUENTA) & "|"
            strInputWS = strInputWS & "SERVC_PUNTOVENTA:" & Funciones.CheckStr(objTransaccion.SERVC_PUNTOVENTA) & "|"
            strInputWS = strInputWS & "SERVC_ASESOR:" & Funciones.CheckStr(objTransaccion.SERVC_ASESOR) & "|"
            strInputWS = strInputWS & "SERVC_CODIGO_INTERACCION:" & Funciones.CheckStr(objTransaccion.SERVC_CODIGO_INTERACCION) & "|"
            strInputWS = strInputWS & "ID_TRANSACCION:" & Funciones.CheckStr(objTransaccion.ID_TRANSACCION) & "|"
            strInputWS = strInputWS & "XMLENTRADA:" & Funciones.CheckStr(objTransaccion.SERVV_XMLENTRADA)
        Catch ex As Exception
            strInputWS = "Error GeneraCadenaLogWS: " & ex.Message
        End Try
        Return strInputWS
    End Function

    Private Function LeerDatosCliente(ByVal nroLinea As String, ByRef oCliente As Cliente) As Boolean
        Dim oClienteNegocio As New ClienteNegocio
        Dim flagConsulta As String = ""
        Dim mensajeError As String = ""

        oCliente = CType(oClienteNegocio.ObtenerCliente(nroLinea, "", "", "1", flagConsulta, mensajeError), Cliente)
        If Not oCliente Is Nothing AndAlso oCliente.OBJID_CONTACTO Is Nothing Then
            'hidMensaje.Value = "Error. Nro de Línea del Cliente no se encuentra en la BD de Clarify."
            Return False
        End If

        Return True
    End Function
    Private Function ObjetoInteraccion(ByVal objId As String, ByVal nroLinea As String) As Interaccion
        Dim objInteraccion As New Interaccion

        With objInteraccion
            .OBJID_CONTACTO = objId
            .TELEFONO = nroLinea
            .TIPO = ConfigurationSettings.AppSettings("CONS_MIGRACION_TIPO")
            .CLASE = ConfigurationSettings.AppSettings("CONS_MIGRACION_CLASE")
            .SUBCLASE = ConfigurationSettings.AppSettings("CONS_MIGRACION_SUBCLASE")
            .METODO = ConfigurationSettings.AppSettings("CONS_MIGRACION_METODO")
            .TIPO_INTER = ConfigurationSettings.AppSettings("CONS_MIGRACION_TIPO_INTER")

            .AGENTE = ConfigurationSettings.AppSettings("CONS_MIGRACION_AGENTE")

            .USUARIO_PROCESO = ConfigurationSettings.AppSettings("CONS_MIGRACION_USUARIO")
            .FLAG_CASO = ConfigurationSettings.AppSettings("CONS_MIGRACION_FLAG")
            .RESULTADO = ConfigurationSettings.AppSettings("CONS_MIGRACION_RESULTADO")
            .HECHO_EN_UNO = ConfigurationSettings.AppSettings("CONS_MIGRACION_HECHO")
        End With
        Return objInteraccion
    End Function

    Private Function CrearInteraccion(ByVal objInteraccion As Interaccion) As ItemGenerico
        Return CType((New InteraccionNegocios).InsertarInteraccion(objInteraccion), ItemGenerico)
    End Function

    Private Sub RegistrarAuditoria(ByVal strDescrip As String)
        Try
            Dim strFlag As String = ConfigurationSettings.AppSettings("CONS_FLAG_AUDITORIA")
            If strFlag = "1" Then
                Dim nombreHost As String = System.Net.Dns.GetHostName
                Dim nombreServer As String = System.Net.Dns.GetHostName
                Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
                Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)
                Dim usuario_id As String = CurrentUser
                Dim ipcliente As String = CurrentTerminal
                Dim strCodAplica As String = ConfigurationSettings.AppSettings("CodigoAplicacion")
                Dim strNomAplica As String = ConfigurationSettings.AppSettings("NombreAplicacion")
                Dim strDesTrans As String = strDescrip
                Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
                Dim strTransaccion As String = ConfigurationSettings.AppSettings("CONS_COD_AUDIT_TRS_MIGRACION")

                Dim flag As Boolean = New AuditoriaNegocio().registrarAuditoria(strTransaccion, strCodServ, ipcliente, nombreHost, ipServer, nombreServer, usuario_id, "", "0", strDesTrans)
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "eventos"

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim sc As String
        Dim objWL As MigracionWL

        Dim existeWL, validoBSCS As String

        Try
            Dim result As Boolean = validacionCliente(objWL, existeWL, validoBSCS)

            If (result) Then
                sc = String.Format("setValue('hdnValCliente','1');datosWhiteList('{0}');setEnabled('btnSgte1',true,'');validacionClienteOk();", cadena(objWL))
                Session("objWL") = objWL
                Me.hdnMontoFlat.Value = objWL.MONTO_FLAT.ToString
            Else
                Me.hdnValCliente.Value = "0"

                'REGISTRA EL LOG
                Me.insertarLogMigracion("", "", existeWL, validoBSCS, "", "", "")
                If existeWL = "X" Then
                    sc = "<script>alert('El N° de Línea " & txtNumero.Text & " ya fue migrado.')</script>"
                ElseIf validoBSCS = "N" Then
                    sc = "<script>alert('El cliente presenta deudas o bloqueo. Cliente debe ser evaluado.')</script>"
                Else
                    sc = "<script>alert('El N° de Documento no pertenece al White List, cliente debe ser evaluado')</script>"
                End If

                Anthem.Manager.RegisterClientScriptBlock("alerta", sc)
                sc = "setValue('hdnValCliente','0');setEnabled('btnSgte1',false,'')"
            End If
            Anthem.Manager.AddScriptForClientSideEval(sc)

        Catch ex As Exception
            mensajeError(ex)
        Finally
            objWL = Nothing
        End Try
    End Sub

    Private Sub btnCargarPlanes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarPlanes.Click
        If (Me.hdnCargoFijoMax.Value <> "") Then
            cargarPlanes(Double.Parse(Me.hdnCargoFijoMax.Value))
        End If
    End Sub

    Private Sub ddlPlan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlan.SelectedIndexChanged
        If (ddlPlan.SelectedValue.IndexOf("|"c) <> -1) Then
            BuscarServicios(ddlPlan.SelectedValue.Split("|"c)(0))
        End If
    End Sub

    Private Sub btnAgregarPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPlan.Click
        Dim plan As New plan
        Dim lista As New ArrayList
        Dim arrPlan() As String
        Try
            arrPlan = Me.ddlPlan.SelectedValue.Split("|"c)
            plan.PLANN_CODIGO = Integer.Parse(arrPlan(0))
            plan.PLANN_CAR_FIJ = Decimal.Parse(arrPlan(1))
            plan.PLANV_DESCRIPCION = Me.ddlPlan.SelectedItem.Text

            'obteniendo los servicios seleccionados.
            plan.SERVICIOS = obtenerServiciosSeleccionados()
            lista.Add(plan)

            Me.dgPlan.DataSource = lista
            Me.dgPlan.DataBind()
            Me.dgPlan.UpdateAfterCallBack = True

            Me.dgServicios.DataSource = Nothing
            Me.dgServicios.DataBind()
            Me.dgServicios.UpdateAfterCallBack = True

            Me.ddlPlan.SelectedValue = "0"
            Me.ddlPlan.UpdateAfterCallBack = True

            Dim sc As String = "setVisible('divServicios',false);"

            Anthem.Manager.AddScriptForClientSideEval(sc)

        Catch ex As Exception
            mensajeError(ex)
        Finally
            plan = Nothing
            arrPlan = Nothing
        End Try
    End Sub

    Private Sub dgPlan_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlan.ItemDataBound
        Dim tbl As Table
        Dim hdnCodPlan, hdnCF As HtmlInputHidden
        Dim objPlan As Plan
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then

            objPlan = CType(e.Item.DataItem, Plan)
            tbl = CType(e.Item.FindControl("tblServicios"), Table)
            hdnCodPlan = CType(e.Item.FindControl("hdnCodPlan"), HtmlInputHidden)
            hdnCF = CType(e.Item.FindControl("hdnCF"), HtmlInputHidden)
            hdnCodPlan.Value = objPlan.PLANN_CODIGO.ToString
            hdnCF.Value = objPlan.PLANN_CAR_FIJ.ToString

            Dim servicios As ArrayList = objPlan.SERVICIOS
            Dim x As Int32 = 1
            For Each serv As Servicio In servicios
                Dim tr As New TableRow
                Dim td As New TableCell

                td.Text = serv.Descripcion
                tr.Cells.Add(td)
                If (x Mod 2 = 0) Then
                    tr.BackColor = System.Drawing.Color.FromName("#DDDEE2")
                End If

                tbl.Rows.Add(tr)
                x += 1
            Next
        End If
    End Sub

    Private Sub btnQuitarPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarPlan.Click

        Me.dgPlan.DataSource = Nothing
        Me.dgPlan.DataBind()
        Me.dgPlan.UpdateAfterCallBack = True
        Me.btnAgregarPlan.Enabled = True
    End Sub


    Private Sub btnMigrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrar.Click

        'validacion para saber si la linea ya ha sido migrada.
        Dim existeWL, validoBSCS, sc As String
        Dim objWLVal As MigracionWL
        Dim result As Boolean = validacionCliente(objWLVal, existeWL, validoBSCS)

        If (result = False) Then
            Me.hdnValCliente.Value = "0"

            If existeWL = "X" Then
                sc = "<script>alert('El N° de Línea " & txtNumero.Text & " ya fue migrado.')</script>"
            ElseIf Not objWLVal Is Nothing And objWLVal.FLAG_MIGRACION = 2 Then
                sc = "<script>alert('El N° de Línea " & txtNumero.Text & " se encuentra en proceso de migración.')</script>"
            ElseIf validoBSCS = "N" Then
                sc = "<script>alert('El cliente presenta deudas o bloqueo. Cliente debe ser evaluado.')</script>"
            Else
                sc = "<script>alert('El N° de Documento no pertenece al White List, cliente debe ser evaluado')</script>"
            End If
            Session("objWL") = Nothing
            Anthem.Manager.RegisterClientScriptBlock("alerta", sc)
            sc = "setValue('hdnValCliente','0');limpiar();"
            Anthem.Manager.AddScriptForClientSideEval(sc)

            Me.dgPlan.DataSource = Nothing
            Me.dgPlan.DataBind()
            Me.dgPlan.UpdateAfterCallBack = True

            Return
        End If

        'validacion de linea

        Dim objVentaExpressNegocios As New VentaExpressNegocios
        Dim rptaValidacion As String = ""


        Dim objWL As MigracionWL = CType(Session("objWL"), MigracionWL)
        objVentaExpressNegocios.actualiza_MigracionWL(objWL.NRO_DOCUMENTO, objWL.NRO_LINEA, "2", rptaValidacion)


        If rptaValidacion = "1" Then
            sc = "<script>alert('El N° de Línea " & txtNumero.Text & " ya fue migrado.')</script>"

        ElseIf rptaValidacion = "2" Then
            sc = "<script>alert('El N° de Línea " & txtNumero.Text & " se encuentra en proceso de migración.')</script>"
        End If

        If (sc <> "") Then

            Anthem.Manager.RegisterClientScriptBlock("alerta", sc)
            sc = "setValue('hdnValCliente','0');limpiar();"
            Anthem.Manager.AddScriptForClientSideEval(sc)
            Session("objWL") = Nothing
            Me.dgPlan.DataSource = Nothing
            Me.dgPlan.DataBind()
            Me.dgPlan.UpdateAfterCallBack = True
            Return

        End If

        'pasa la validación
        Dim strNroSEC, strDetalleSEC, nroContrato, esPrepago, strDetalleAcuerdo, strMensajeRegAcuerdo, strMensajeRegMigra, strInputWS As String

        Dim objFileLog As New SISACT_Log
        Dim nameFile As String = ConfigurationSettings.AppSettings("constNameLogMigracion")
        Dim strArchivo As String = objFileLog.Log_CrearNombreArchivo(nameFile)
        Dim strIdentifyLog As String = objWL.NRO_LINEA & "|" & objWL.NRO_DOCUMENTO
        Dim blnRespuestaMig As Boolean
        Dim blnActualizaWhitelistMig As Boolean
        Me.btnCancelar.Enabled = False

        Try
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Migracion Prepago a Postpago.")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo registrarSolicitud()")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP TipoCargo: " & Me.hdnTipoCargo.Value)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP NroCargos: " & Me.txtNumeroCF.Text)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP txtNumeroCF: " & Me.txtNumeroCF.Text)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP Importe: " & Me.txtImporte.Text)
            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or _
                ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP Oficina: " & CStr(Session("strCodPuntoVenta")))
            Else
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP Oficina: " & Me.ddlOficina.SelectedItem.Text)
            End If

            registrarSolicitud(strNroSEC, strDetalleSEC)    'Registrar Correo electronico, direccion de facturacion y SEC
            blnActualizaWhitelistMig = True

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT strNroSEC: " & strNroSEC)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo registrarSolicitud()")

            'Si no tiene tipo de deposito se crea el acuerdo y se activa la linea.
            'If (Me.hdnTipoCargo.Value = "0" Or Me.hdnTipoCargo.Value = "") Then
            If (Me.txtNumeroCF.Text = "0" Or Me.txtNumeroCF.Text = "") Or ((Me.txtNumeroCF.Text <> "" Or Funciones.CheckInt(Me.txtNumeroCF.Text) > 0) And Funciones.CheckDbl(Me.hdnMontoFlat.Value) > 0) Then
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo GenerarAcuerdo()")

                Me.GenerarAcuerdo(objWL, strNroSEC, nroContrato, esPrepago, strDetalleAcuerdo, strMensajeRegAcuerdo)    'Generar Acuerdo en SAP

                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP strDetalleAcuerdo: " & strDetalleAcuerdo)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT strMensajeRegAcuerdo: " & strMensajeRegAcuerdo)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT nroContrato: " & nroContrato)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo GenerarAcuerdo()")

                objVentaExpressNegocios.Set_Actualiza_Contrato_Solicitud(Long.Parse(strNroSEC), nroContrato)

                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Inicio Metodo ejecutarMigracion()")
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP nroContrato: " & nroContrato)

                If CStr(ConfigurationSettings.AppSettings("consFlagNuevoWSMigracion")).Equals("1") Then
                    blnRespuestaMig = ejecutarMigracion(objWL, FormatoContratoSAP(nroContrato), strMensajeRegMigra, strInputWS)    'Registra e Invoca WS Migracion
                Else
                    strInputWS = FormatoContratoSAP(nroContrato)
                    strMensajeRegMigra = ejecutarMigracionRecurrente(FormatoContratoSAP(nroContrato), blnRespuestaMig)
                End If

                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros INP strInputWS: " & strInputWS)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "		Parametros OUT strMensajeRegMigra: " & strMensajeRegMigra)
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Metodo ejecutarMigracion()")

                If blnRespuestaMig Then
                    Anthem.Manager.AddScriptForClientSideEval(String.Format("alert('Se realizó correctamente la Migración de la Línea: {0}');", objWL.NRO_LINEA))
                    blnActualizaWhitelistMig = True
                'Actualiza el Flag de Pago en la SEC
                objVentaExpressNegocios.ActualizarPagoSolicitud(CLng(strNroSEC), "1")
                objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Se Actualizó el Flag de Pago")
                Else
                    blnActualizaWhitelistMig = False
                    'ANULAR SEC y MIGRACION SAP
                    RollBackMigracion(nroContrato, strNroSEC)

                    Anthem.Manager.AddScriptForClientSideEval(String.Format("alert('Ocurrió un error al Migración de la Línea: {0}');", objWL.NRO_LINEA))
                End If
            Else
                Anthem.Manager.AddScriptForClientSideEval(String.Format("alert('El cliente deberá acercarse a la oficina {0} para culminar con la Migración.');", Me.ddlOficina.SelectedItem.Text))
            End If

            Anthem.Manager.AddScriptForClientSideEval(String.Format("alert('Se registró correctamente la Solicitud N°: {0}');", strNroSEC))

            'ACTUALIZA WHITELIST MIGRACION
            If blnActualizaWhitelistMig Then
                objVentaExpressNegocios.actualiza_MigracionWL(objWL.NRO_DOCUMENTO, objWL.NRO_LINEA, "1", Nothing)
            Else
                objVentaExpressNegocios.actualiza_MigracionWL(objWL.NRO_DOCUMENTO, objWL.NRO_LINEA, "", Nothing)
            End If

            'REGISTRA EL LOG
            If Len(strInputWS) > 150 Then
                Me.insertarLogMigracion(strNroSEC, nroContrato, "S", "S", esPrepago, strMensajeRegMigra, strInputWS.Substring(0, 149))
            Else
                Me.insertarLogMigracion(strNroSEC, nroContrato, "S", "S", esPrepago, strMensajeRegMigra, strInputWS)
            End If

            'REGISTRA AUDITORIA
            RegistrarAuditoria("Linea:" & objWL.NRO_LINEA & "|" & "SEC:" & strNroSEC & "|" & "Contrato:" & nroContrato & "|" & "MensajeRegMigra:" & strMensajeRegMigra)

        Catch ex As Exception
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error Migracion. " & ex.Message.ToString)
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Error StackTrace. " & ex.StackTrace.ToString)
            mensajeError(ex)
        Finally
            Session.Remove("strCodPuntoVenta")
            Session.Remove("strDescPuntoVenta")
            Session.Remove("objWL")

            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "Fin Migracion Prepago a Postpago.")
            objFileLog.Log_WriteLog(strArchivo, strIdentifyLog & "- " & "----------------------------------------------------------------")
            limpiar()

            objVentaExpressNegocios = Nothing
            objFileLog = Nothing
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub mensajeError(ByVal ex As Exception)
        Anthem.Manager.AddScriptForClientSideEval("alert('Ocurrió un error, consulte con el administrador. " & ex.Message & "');")
    End Sub

    Private Sub RollBackMigracion(ByVal nroContrato As String, ByVal nroSEC As String)
        AnularContratoMigracion(nroContrato)
        AnularSECMigracion(nroSEC)
    End Sub
    Private Sub AnularContratoMigracion(ByVal NroContrato As String)
        Dim objNegocios As SapGeneralNegocios
        Try
            objNegocios.Set_EstadoAcuerdoPCS(NroContrato, "", ConfigurationSettings.AppSettings("consStrUsuarioACR"), "", "", "", "", "")
        Catch ex As Exception
        Finally
            objNegocios = Nothing
        End Try
    End Sub
    Private Sub AnularSECMigracion(ByVal nroSEC As String)
        Dim objNegocios As SolicitudNegocios
        Try
            objNegocios.AnularSEC(nroSEC, "ROLLBACK POR MIGRACION", "06")
        Catch ex As Exception
        Finally
            objNegocios = Nothing
        End Try
    End Sub
#End Region

#Region "Funciones"
    Function FormatoContratoSAP(ByVal nroContrato As String) As String
        Dim aux As String
        aux = nroContrato
        If aux <> "" Then
            Dim longitud As Integer
            Dim posicion As Integer
            longitud = Len(nroContrato)
            If longitud > 0 Then
                Do While InStr(1, aux, "0") = 1
                    aux = Mid(aux, 2, Len(aux))
                Loop
            End If
        End If
        If aux = "" Then
            FormatoContratoSAP = nroContrato
        Else
            FormatoContratoSAP = aux
        End If
    End Function

    Private Sub limpiar()
        Response.Redirect("sisact_migracion_prepago_postpago.aspx")
    End Sub

    Private Function GenerarIdTransaccion() As String
        Dim strIdTrans As String
        strIdTrans = ConfigurationSettings.AppSettings("gConstIdTransaccion")
        strIdTrans += Funciones.CadenaAleatoria()
        Return strIdTrans
    End Function

    Private Function LeerDatosLinea(ByVal nroLinea As String, ByRef strMensajeError As String) As Boolean
        Dim oPrepagoNegocios As New DatosPrepagoNegocios

        Dim providerIdPrepago As String = ConfigurationSettings.AppSettings("ProviderIdPrepago").ToString()
        Dim providerIdControl As String = ConfigurationSettings.AppSettings("ProviderIdControl").ToString()
        Dim datosLinea As ItemGenerico = Nothing

        datosLinea = oPrepagoNegocios.LeerDatosPrepago(nroLinea, providerIdPrepago, providerIdControl, strMensajeError)
        If IsNothing(datosLinea) OrElse (Not datosLinea.estado.ToUpper().Equals("P")) Then
            Return False
        End If

        Return True
    End Function

    Private Function cadena(ByVal objW As MigracionWL) As String
        Dim sb As New StringBuilder

        sb.Append("{""whitelist"":{")
        sb.Append("""whitelist"":[")

        sb.Append("{" + String.Format(" ""tipodoc"":""{0}"" ,""documento"":""{1}"",""nombre"":""{2}"",""ape_pat"":""{3}"",""ape_mat"":""{4}"",""cf_max"":""{5}"",""cf_min"":""{6}"",""plazo_acuerdo"":""{7}"",""tipo_cargo_max"":""{8}"",""tipo_cargo_min"":""{9}"",""tipo_cargo_max_desc"":""{10}"",""tipo_cargo_min_desc"":""{11}"",""num_cf_max"":""{12}"",""num_cf_min"":""{13}"",""riesgo"":""{14}"",""control_consumo"":""{15}"",""monto_flat"":""{16}"",""cod_control_consumo"":""{17}"",""score"":""{18}"",""score_cred"":""{19}"" ", objW.TIPO_DOCUMENTO, objW.NRO_DOCUMENTO, objW.NOMBRES, objW.APELLIDO_PATERNO, objW.APELLIDO_MATERNO, objW.CARGO_FIJO_MAX, objW.CARGO_FIJO_MIN, objW.PLAZO_ACUERDO, objW.TIPO_CARGO_MAX, objW.TIPO_CARGO_MIN, objW.TIPO_CARGO_MAX_DESC, objW.TIPO_CARGO_MIN_DESC, objW.NRO_CARGOS_FIJOS_MAX, objW.NRO_CARGOS_FIJOS_MIN, objW.RIESGO, objW.FLAG_CONTROL_CONSUMO, objW.MONTO_FLAT, ConfigurationSettings.AppSettings("cons_cod_serv_control_consumo"), objW.SCORE, objW.SCORE_CRED) + "}")

        sb.Append("]}")
        sb.Append("}")
        Return sb.ToString
    End Function

    Private Function validacionBSCS() As Boolean
        'validacion de deuda y bloqueo

        Dim objBuscarCriterio As New ClienteCons_Negocio
        Dim lisClientes As ArrayList


        Dim ObjBuscarCliente, ObjBuscarTelefonoBloqueo, ObjBuscarClienteTelefono As ArrayList

        Dim cont_montoVenc As Double
        Dim result As Boolean = True

        Try
            Dim inttipodoc As Integer = CInt(Me.ddlDoc.SelectedValue.Split("|"c)(1))

            lisClientes = objBuscarCriterio.BuscarClienteCompletoDes(ConfigurationSettings.AppSettings("constCriterioBSCS"), Me.txtDocumento.Text.Trim, inttipodoc)

            ObjBuscarCliente = CType(lisClientes(0), ArrayList)
            ObjBuscarTelefonoBloqueo = CType(lisClientes(2), ArrayList)
            ObjBuscarClienteTelefono = CType(lisClientes(1), ArrayList)

            If ObjBuscarCliente.Count > 0 Then
                If Not CType(ObjBuscarCliente(0), Cliente_Cons).RUC_DNI Is Nothing Then
                    cont_montoVenc = obtenerTotalMontoVencido(ObjBuscarCliente)
                End If
            End If

            Dim objItemClienteTelefono As Cliente_Cons
            Dim bloqueo_des, strFlagBloqueo As String
            For Each objItemClienteTelefono In ObjBuscarClienteTelefono
                For Each objItemClienteTelefonoBloqueo As Cliente_Cons In ObjBuscarTelefonoBloqueo
                    If objItemClienteTelefonoBloqueo.CUSTOMER_ID = objItemClienteTelefono.CUSTOMER_ID Then
                        bloqueo_des = objItemClienteTelefonoBloqueo.SHORT_DESCRIPTION.ToUpper()

                        If objItemClienteTelefonoBloqueo.BLOQUEO.ToUpper() = "SI" Then
                            strFlagBloqueo = "SI"
                        Else
                            If bloqueo_des <> "" Then
                                strFlagBloqueo = "SI"
                            End If
                        End If
                        Exit For
                    End If
                Next
            Next
            If cont_montoVenc > 0 Or strFlagBloqueo = "SI" Then
                result = False
            End If
        Finally
            ObjBuscarCliente = Nothing
            lisClientes = Nothing
            objBuscarCriterio = Nothing
        End Try
        Return result

    End Function

    Private Function validacionCliente(ByRef objOut As MigracionWL, ByRef existeWL As String, ByRef validoBSCS As String) As Boolean
        Dim obj As New VentaExpressNegocios
            'VALIDA WHITELIST
            Dim objWL As MigracionWL = obj.ValidacionWhitelist(Me.txtDocumento.Text, Me.txtNumero.Text)
            existeWL = ""
            validoBSCS = ""

            If (objWL Is Nothing) Then
                existeWL = "N"
                Return False
            Else
                If objWL.FLAG_MIGRACION = 1 Then
                    existeWL = "X"
                    Return False
                End If
            End If

            If (Not validacionBSCS()) Then
                validoBSCS = "N"
                Return False
            End If
            objOut = objWL
            existeWL = "S"
            validoBSCS = "S"

            Return True

    End Function

    Private Function obtenerServiciosSeleccionados() As ArrayList

        Dim lista As New ArrayList
        If (Me.hdnServicios.Value <> "") Then
            Dim arr() As String = Me.hdnServicios.Value.Split("|"c)
            For Each str As String In arr
                Dim arr2() As String = str.Split(";"c)
                lista.Add(New Servicio(arr2(0), arr2(1)))
            Next
        End If
        Return lista
    End Function

    Private Function obtenerCadenaServiciosFormatoSAP() As String

        Dim cadena As String = ""

        If (Me.hdnServicios.Value <> "") Then
            Dim cadena2 As String = ";00001;{0};S|"

            Dim arr() As String = Me.hdnServicios.Value.Split("|"c)
            For Each str As String In arr
                Dim arr2() As String = str.Split(";"c)
                cadena += String.Format(cadena2, arr2(0))
            Next
        End If

        If (cadena <> "") Then
            cadena = cadena.Substring(0, cadena.Length - 1)
        End If

        Return cadena

    End Function

    Private Function obtenerTotalMontoVencido(ByRef p_objBuscarCliente As ArrayList) As Double
        Dim i As Integer
        Dim contMontoVenc As Double
        contMontoVenc = 0.0

        For i = 0 To p_objBuscarCliente.Count - 1

            If CType(p_objBuscarCliente.Item(i), Cliente_Cons).MONTO_VENC < 0 Then
                CType(p_objBuscarCliente.Item(i), Cliente_Cons).MONTO_VENC = 0
            End If
            contMontoVenc = contMontoVenc + CType(p_objBuscarCliente.Item(i), Cliente_Cons).MONTO_VENC
        Next
        Return contMontoVenc

    End Function

#End Region


End Class
