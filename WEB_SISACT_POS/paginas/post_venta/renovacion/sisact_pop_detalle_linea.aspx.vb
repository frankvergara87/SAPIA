Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports System.Text
Imports System.Xml
Imports Claro.SisAct.Web.Funciones.Comunes
Public Class sisact_pop_detalle_linea
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents divLista As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divListaSGA As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTokensApellido As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNombres As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidApellidos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidRazonSocial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanesActivos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLineas As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroLineasBSCS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTieneSECPendiente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidNroDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtTipoDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroDocumento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantidadPlan As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCargoFijo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeudaVencida As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeudaCastigada As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBloqueo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSuspension As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgdListaBSCS As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgdListaSGA As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hidTipoDoc As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClienteExiste As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidBlackList As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLblDeudaBloqueo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidLblCliente As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidEvaluarMovil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClienteClaro As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanesDatosVoz As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCalificacionPago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtTipoDocumentoAnexo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNroDocumentoAnexo As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtCantBloqueoMovil As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantSuspMovil As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantLineaMenor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCantLineaMayor As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCantLineaMenor As System.Web.UI.WebControls.Label
    Protected WithEvents lblCantLineaMayor As System.Web.UI.WebControls.Label
    Protected WithEvents hidTop As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidnrolinea As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidservicios As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidplancomercial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidcargofijo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorConsulta As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCodError As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgListaLineas As System.Web.UI.WebControls.DataGrid
    Protected WithEvents detalle_linea_header As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents detalle_linea_body As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgdListaSISACT As System.Web.UI.WebControls.DataGrid
    Protected WithEvents divListaSISACT As System.Web.UI.HtmlControls.HtmlGenericControl

    'Inicio Renovacion Por Bloqueo JAZ
    Protected WithEvents hidCoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCanalActual As System.Web.UI.HtmlControls.HtmlInputHidden
    'Fin Renovacion Por Bloqueo JAZ


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
    Dim strArchivo As String = oLog.Log_CrearNombreArchivo("sisact_pop_detalle_linea")
    Dim strCodigoAnterior As String = String.Empty
    Dim strCodTipoDocRUC As String = ConfigurationSettings.AppSettings("TipoDocumentoRUC")
    Dim blnTipoDocumentoRUC As Boolean = False
    Dim blnConsultaOAC As Boolean = (ConfigurationSettings.AppSettings("constConsultaOAC") = "S")
    Dim dtDetalleSGA As New DataTable
    Dim dtDetalleBSCS As New DataTable
    Dim dtDetalleSISACT As New DataTable
    Dim idNroDocumento As String
    Dim intNroRegistroDataSet As Integer = CheckInt(ConfigurationSettings.AppSettings("constNroRegistroDataSet"))

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Write("<script language='javascript' src='../../../script/funciones_sec.js'></script>")
        Dim strTipoDoc As String = Request("tipoDoc")
        Dim strNroDoc As String = Request("nroDoc")
        Dim strAccion As String = Request("pageOpen")
        Dim strnrolinea As String = Request("nrolinea")
        'Inicio Renovacion por Bloqueo JAZ
        Dim strCanal As String = Request("CanalActual")
        Dim strCoId As String = Request("CoId")
        'Fin Renovacion por Bloqueo JAZ			

        idNroDocumento = strNroDoc

        If (Session("codUsuarioSisact") Is Nothing) Then
            Dim strRutaSite As String = ConfigurationSettings.AppSettings("RutaSite")
            Response.Redirect(strRutaSite)
            Response.End()
            Exit Sub
        End If

        If Not Page.IsPostBack Then
            hidAccion.Value = strAccion
            hidNroDoc.Value = strNroDoc
            hidTipoDoc.Value = strTipoDoc
            blnTipoDocumentoRUC = (hidTipoDoc.Value = strCodTipoDocRUC)
            hidnrolinea.Value = strnrolinea
            'Inicio Renovacion por Bloqueo JAZ
            hidCanalActual.Value = strCanal
            hidCoId.Value = strCoId
            'Fin Renovacion por Bloqueo JAZ			


            Select Case strAccion
                Case "C", "CR"
                    Consultar()
                Case "P"
                    Session.Remove("oClienteCuenta" & strNroDoc)
                    Session.Remove("oDetalleOAC" & strNroDoc)
                    ConsultarPool()
                Case Else
                    Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & strNroDoc), ClienteCuenta)
                    Dim oCuentaCliente As OACWS.DetalleCuentaType() = CType(Session("oDetalleOAC" & strNroDoc), OACWS.DetalleCuentaType())
                    Mostrar(oClienteCta, oCuentaCliente)
            End Select

            'If strAccion.Equals("C") Then
            '    Consultar()
            'ElseIf strAccion.Equals("P") Then
            '    Session.Remove("oClienteCuenta" & strNroDoc)
            '    Session.Remove("oDetalleOAC" & strNroDoc)
            '    ConsultarPool()
            'Else
            '    Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & strNroDoc), ClienteCuenta)
            '    Dim oCuentaCliente As OACWS.DetalleCuentaType() = CType(Session("oDetalleOAC" & strNroDoc), OACWS.DetalleCuentaType())
            '    Mostrar(oClienteCta, oCuentaCliente)
            'End If
        End If
    End Sub

    Private Sub Mostrar(ByVal oClienteCta As ClienteCuenta, ByVal oCuentasCliente As OACWS.DetalleCuentaType())

        dgdListaBSCS.DataSource = Nothing
        dgdListaSGA.DataSource = Nothing

        Try
            dtDetalleSGA = oClienteCta.LineaSGA
            dtDetalleBSCS = oClienteCta.LineaBSCS
            dtDetalleSISACT = oClienteCta.LineaSISACT

            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "antes de recorrer oClienteCta --> ")


            If Not IsNothing(oClienteCta) Then
                oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "ingrese a recorrer oClienteCta --> ")

                If oClienteCta.nroDoc = hidNroDoc.Value Then
                    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "fueron iguales los documentos")

                    txtNroDocumento.Text = hidNroDoc.Value
                    txtTipoDocumento.Text = oClienteCta.tipoDocDes
                    txtCantidadPlan.Text = CheckStr(oClienteCta.nroPlanesActivos)
                    txtCargoFijo.Text = String.Format("{0:#,#,#,0.00}", oClienteCta.CF)
                    txtDeudaVencida.Text = String.Format("{0:#,#,#,0.00}", oClienteCta.deudaVencida)
                    txtDeudaCastigada.Text = String.Format("{0:#,#,#,0.00}", oClienteCta.deudaCastigada)
                    txtNombre.Text = oClienteCta.nombres
                    txtBloqueo.Text = IIf(oClienteCta.nroBloqueo > 0, "SI", "NO").ToString
                    txtSuspension.Text = IIf(oClienteCta.nroSuspension > 0, "SI", "NO").ToString
                    txtTipoDocumentoAnexo.Text = ConfigurationSettings.AppSettings("TipoDocuIdentidad")
                    txtNroDocumentoAnexo.Text = oClienteCta.nroDocAsociado

                    lblCantLineaMenor.Text = CheckStr(oClienteCta.nroRangoDiasBSCS)
                    lblCantLineaMayor.Text = CheckStr(oClienteCta.nroRangoDiasBSCS)
                    txtCantBloqueoMovil.Text = CheckStr(oClienteCta.nroBloqueo)
                    txtCantSuspMovil.Text = CheckStr(oClienteCta.nroSuspension)
                    txtCantLineaMenor.Text = CheckStr(oClienteCta.nroLineaMenor90Dia)
                    txtCantLineaMayor.Text = CheckStr(oClienteCta.nroLineaMayor90Dia)

                    Dim dtListaBSCS As New DataTable
                    Dim dtListaSGA As New DataTable
                    Dim dtListaSISACT As New DataTable

                    'Estructura de tablas
                    estructuraTable(dtListaBSCS)
                    dtListaSGA = dtListaBSCS.Clone
                    dtListaSISACT = dtListaBSCS.Clone

                    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "blnConsultaOAC" & blnConsultaOAC)

                    createTableLineas(oClienteCta.nroDoc, oCuentasCliente, dtListaBSCS, dtListaSGA, oClienteCta.LineaBSCS, oClienteCta.LineaSGA, oClienteCta.listaLineasFraude)

                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "fin createTableLineas")
                    'If Not IsNothing(oCuentasCliente) Then
                    '    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "antes de createTableLineasOAC")

                    '    createTableLineasOAC(oClienteCta.nroDoc, oCuentasCliente, dtListaBSCS, dtListaSGA, oClienteCta.LineaBSCS, oClienteCta.LineaSGA, oClienteCta.listaLineasFraude)

                    '    oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & "Mostrar - " & "despues de createTableLineasOAC")
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "inicio createTableLineasSISACT")
                    createTableLineasSISACT(dtListaSISACT, oClienteCta.LineaSISACT)
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "fin createTableLineasSISACT")

                    dgdListaBSCS.DataSource = dtListaBSCS
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "fin dtListaBSCS")
                    dgdListaSGA.DataSource = dtListaSGA
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "fin dtListaSGA")
                    dgdListaSISACT.DataSource = dtListaSISACT
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineas - " & "fin dtListaSISACT")
                End If


            End If


            dgdListaBSCS.DataBind()
            dgdListaSGA.DataBind()
            dgdListaSISACT.DataBind()

        Catch ex As Exception

            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " Mostrar - Error  --> " & ex.Message)
            Throw
        End Try
    End Sub

    Private Sub Consultar()
        Dim strTipoDoc As String = hidTipoDoc.Value
        Dim strNroDoc As String = hidNroDoc.Value
        Dim intTipoDocBscs As Integer
        Dim strTipoDocSGA As String
        Dim oClienteCta As New ClienteCuenta
        Dim strCoId As String = hidCoId.Value 'SD1052592

        Session.Remove("oClienteCuenta" & strNroDoc)
        Session.Remove("objCliente" & strNroDoc)
        Session.Remove("oDetalleOAC" & strNroDoc)
        Session.Remove("oClienteOfrecimiento" & strNroDoc)
        Session("strNroDocumento") = strNroDoc
        oClienteCta.nroDoc = strNroDoc
        oClienteCta.tipoDoc = strTipoDoc

        Dim arrTipoDoc As ArrayList = (New ConsumerNegocio).ListarTipoDocumento()
        For Each item As TipoDocumento In arrTipoDoc
            If item.TDOCC_CODIGO = strTipoDoc Then
                txtTipoDocumento.Text = item.TDOCV_DESCRIPCION
                intTipoDocBscs = CheckInt(item.COD_BSCS)
                strTipoDocSGA = item.COD_SGA
                oClienteCta.tipoDocDes = item.TDOCV_DESCRIPCION
                Exit For
            End If
        Next

        Try
            'Parametros Generales
            Dim dblConsUmbralDueda As Double
            Dim dblConsPorcDeudaVencida As Double
            Dim intConsMesesRecurrente As Integer
            Dim intConsMesesFactura As Integer
            Dim intTiempoPermanencia As Integer
            Dim arrParametros As ArrayList = New ConsumerNegocio().ListarParametroConsumer(1)
            For Each item As ParametroConsumer In arrParametros
                If item.PCONI_CODIGO.Equals("26") Then
                    dblConsPorcDeudaVencida = Funciones.CheckDbl(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO.Equals("27") Then
                    intConsMesesRecurrente = Funciones.CheckInt(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO.Equals("30") Then
                    intConsMesesFactura = Funciones.CheckInt(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("constUmbralDeuda") Then
                    dblConsUmbralDueda = Funciones.CheckDbl(item.PCONV_VALOR)
                End If

                If blnTipoDocumentoRUC Then
                    If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("TiempoPermanenciaRUC") Then
                        intTiempoPermanencia = Funciones.CheckInt(item.PCONV_VALOR)
                    End If
                Else
                    If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("TiempoPermanenciaDNI") Then
                        intTiempoPermanencia = Funciones.CheckInt(item.PCONV_VALOR)
                    End If
                End If
            Next

            Dim strNombres As String = ""
            Dim strApellidos As String = ""
            Dim strRazonSocial As String = ""
            Dim dblGeneralCF As Double = 0
            Dim intGeneralNroPlanes As Integer = 0
            Dim dblGeneralDeuda As Double = 0
            Dim dblGeneralDeudaCast As Double = 0
            Dim intGeneralBloqueo As Integer = 0
            Dim intGeneralSuspension As Integer = 0
            Dim intDiasDeuda As Integer = 0
            Dim blnClienteClaro As Boolean = False
            Dim arrCuentaMonto As New ArrayList
            Dim strPlanesActivos As String = ""
            Dim nroLineasMayorNmeses As Integer = 0
            Dim nroLineasMenorNmeses As Integer = 0
            Dim intMesesBSCS As Int64 = 0
            Dim intMesesSGA As Int64 = 0
            Dim intMesesClaro As Int64 = 0
            Dim strMensajeDeudaBloqueo As String
            Dim dblDeudaEvaluacion As Double = 0
            Dim blnDeudaEvaluacion As Boolean = False
            Dim blnClienteExiste As Boolean = False
            Dim strNroDocAnexo As String = String.Empty
            Dim strCustomerIdFraude As String = ""
            Dim blnBloqueoLDIFraude As Boolean = False
            Dim dblDeudaLDIFraude As Double = 0.0
            Dim dblDeudaCastLDIFraude As Double = 0.0
            Dim arrNroPlanesActivoxProducto As New ArrayList
            Dim arrNroPlanesActivoxProdSGA As New ArrayList
            Dim arrNroPlanesActivoxProdSISACT As New ArrayList
            Dim listaTelefono As String = String.Empty

            'Inicio Renovacion Por Bloqueo JAZ
            Dim sCanalesPermitidosValidaBloq() As String
            sCanalesPermitidosValidaBloq = ConfigurationSettings.AppSettings("constCanalesPermitidosValidaBloq").Split(","c)

            Dim sCanalesPermitidosVerMsjValidaBloq() As String
            sCanalesPermitidosVerMsjValidaBloq = ConfigurationSettings.AppSettings("constCanalesPermitidosVerMsjValidaBloq").Split(","c)
            Dim bExisteBloqLinea As Boolean = False
            'Fin Renovacion Por Bloqueo JAZ


            If blnTipoDocumentoRUC Then
                strNroDocAnexo = strNroDoc.Substring(2, 8)
            End If

            If blnConsultaOAC Then
                'Consulta OAC ----------------------------------------------------------------------------------------------------------------
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Usuario --> " & CurrentUser())
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "INICIO CONSULTA WS OAC")
                Dim strMensajeOAC As String
                Dim oDetalleCliente As OACWS.DetalleClienteType() = (New OACNegocio).DetalleClienteOAC(strNroDoc, CheckStr(CheckInt(strTipoDoc)), strNroDoc, strMensajeOAC)
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Output --> " & strMensajeOAC)
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "FIN CONSULTA WS OAC")

                'Obteniendo Datos del Cliente
                If oDetalleCliente(0).xCuentas.Length > 0 Then
                    strNombres = CheckStr(oDetalleCliente(0).xNombreCliente)
                    strApellidos = Trim(CheckStr(oDetalleCliente(0).xApePatCliente) & " " & CheckStr(oDetalleCliente(0).xApeMatCliente))
                    strRazonSocial = CheckStr(oDetalleCliente(0).xNombreCliente)
                    strNroDocAnexo = CheckStr(oDetalleCliente(0).xDniAsociado)
                    dblGeneralDeuda = CheckDbl(oDetalleCliente(0).xDeudaVencidaMovil) + CheckDbl(oDetalleCliente(0).xDeudaVencidaFija)
                    dblGeneralDeudaCast = CheckDbl(oDetalleCliente(0).xDeudaCastigadaMovil) + CheckDbl(oDetalleCliente(0).xDeudaCastigadaFija)
                    intDiasDeuda = CheckInt(oDetalleCliente(0).xAntiguedadDeuda)
                    'intGeneralNroPlanes = CheckInt(oDetalleCliente(0).xTotalServicios)

                    Session("oDetalleOAC" & strNroDoc) = oDetalleCliente(0).xCuentas
                    hidClienteExiste.Value = "S"
                    blnClienteExiste = True
                End If
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "blnClienteExiste" & blnClienteExiste)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "blnConsultaOAC" & blnConsultaOAC)

            'Consulta Líneas Menores y Mayores a 90 Días
            If blnTipoDocumentoRUC Then
                Dim arrParametro As ArrayList = (New MaestroNegocio).ListaParametros(0)
                For Each item As Parametro In arrParametro
                    If item.Codigo = 28 Then
                        oClienteCta.nroRangoDiasBSCS = CheckInt(item.Valor)
                        Exit For
                    End If
                Next
            End If


            ' If blnClienteExiste Or Not blnConsultaOAC Then

            'Consulta BSCS ----------------------------------------------------------------------------------------------------------------
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "INICIO CONSULTA DETALLE BSCS/SGA")
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - intTipoDocBscs " & Funciones.CheckStr(intTipoDocBscs))
            Dim dsListaBSCS As DataSet = (New ConsumerNegocio).ListarDetalleLinea(intTipoDocBscs, strNroDoc)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "FIN CONSULTA BSCS")

            If Not IsNothing(dsListaBSCS) Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - dsListaBSCS.Tables(0).Rows.Count --> " & dsListaBSCS.Tables(0).Rows.Count)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - dsListaBSCS.Tables(1).Rows.Count --> " & dsListaBSCS.Tables(1).Rows.Count) ''INC000000968945
            Else
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - IsNothing(dsListaBSCS) -->nulo ")
            End If

            If Not IsNothing(dsListaBSCS) AndAlso dsListaBSCS.Tables(0).Rows.Count > 0 Then
                Dim dtResumen As DataTable = dsListaBSCS.Tables(0)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Ingrese a recorrer BSCS ")

                If Not blnClienteExiste Then
                    strNombres = CheckStr(dtResumen.Rows(0)("NOMBRES"))
                    strApellidos = CheckStr(dtResumen.Rows(0)("APELLIDOS"))
                    strRazonSocial = CheckStr(dtResumen.Rows(0)("RAZON_SOCIAL"))
                    'dblGeneralDeuda = CheckDbl(dtResumen.Rows(0)("DEUV"))
                    'dblGeneralDeudaCast = CheckDbl(dtResumen.Rows(0)("DEUC"))
                    'intDiasDeuda = CheckInt(dtResumen.Rows(0)("DIAS_DEUDA"))
                End If

                hidNroLineasBSCS.Value = CheckStr(CheckInt(dtResumen.Rows(0)("PLANES")))

                intGeneralNroPlanes = CheckInt(dtResumen.Rows(0)("PLANES"))
                dblGeneralCF = (New ConsumerNegocio).ConsultarCargoFijo(strCoId) 'SD1052592 
                intGeneralBloqueo = CheckInt(dtResumen.Rows(0)("BLOQ"))
                intGeneralSuspension = CheckInt(dtResumen.Rows(0)("SUSP"))

                oClienteCta.nroLineasBSCS = CheckInt(dtResumen.Rows(0)("PLANES"))
                oClienteCta.nroLineaMenor7Dia = CheckInt(dtResumen.Rows(0)("NRO_7"))
                oClienteCta.nroLineaMenor30Dia = CheckInt(dtResumen.Rows(0)("NRO_30"))
                oClienteCta.nroLineaMenor90Dia = CheckInt(dtResumen.Rows(0)("NRO_90"))
                oClienteCta.nroLineaMenor180Dia = CheckInt(dtResumen.Rows(0)("NRO_180"))
                oClienteCta.nroLineaMayor90Dia = CheckInt(dtResumen.Rows(0)("NRO_90_MAS"))
                oClienteCta.nroLineaMayor180Dia = CheckInt(dtResumen.Rows(0)("NRO_180_MAS"))

                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool nroLineasBSCS : " & CheckStr(dtResumen.Rows(0)("PLANES")))


                ''Consulta Líneas Menores y Mayores a 90 Días
                'If blnTipoDocumentoRUC Then
                '    Dim arrParametro As ArrayList = (New MaestroNegocio).ListaParametros(0)
                '    For Each item As Parametro In arrParametro
                '        If item.Codigo = 28 Then
                '            oClienteCta.nroRangoDiasBSCS = CheckInt(item.Valor)
                '            Exit For
                '        End If
                '    Next
                '    nroLineasMayorNmeses = CheckInt(dtResumen.Rows(0)("NRO_90_MAS"))
                '    nroLineasMenorNmeses = CheckInt(dtResumen.Rows(0)("NRO_90"))
                'End If

                'Obtener Detalle Líneas
                dtDetalleBSCS = dsListaBSCS.Tables(1)
                DatosServiciosxtelefono(dtDetalleBSCS, dblGeneralCF)




                'Inicio Renovacion Por Bloqueo JAZ
                oLog.Log_WriteLog(strArchivo, strArchivo & "- Inicio EsCanalPermitido - ValidarBloqueoLinea() ")
                oLog.Log_WriteLog(strArchivo, strArchivo & "- IN sCanalesPermitidosValidaBloq =>" & ConfigurationSettings.AppSettings("constCanalesPermitidosValidaBloq"))
                oLog.Log_WriteLog(strArchivo, strArchivo & "- IN hidCanalActual =>" & hidCanalActual.Value)                
                If EsCanalPermitido(hidCanalActual.Value, sCanalesPermitidosValidaBloq) Then
                    Dim objValidaBloqueLinea As New ConsumerNegocio

                    Dim bEsLineaPrincipal As Boolean = False
                    Dim strTramaMensajeBloq As String = ""
                    Dim strTramaMensajeGenBloq As String = ""
                    Try
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- IN Co_id =>" & hidCoId.Value)
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- IN nrodoc =>" & hidNroDoc.Value)

                        bExisteBloqLinea = objValidaBloqueLinea.ValidarBloqueoLinea(hidCoId.Value, hidNroDoc.Value, bEsLineaPrincipal, strTramaMensajeBloq)
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- RES bExisteBloqLinea =>" & bExisteBloqLinea.ToString)
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- OUT bEsLineaPrincipal =>" & bEsLineaPrincipal.ToString)
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- OUT Len(strTramaMensajeBloq) =>" & Len(strTramaMensajeBloq))
                    Catch ex As Exception
                        oLog.Log_WriteLog(strArchivo, strArchivo & "- Error EsCanalPermitido - ValidarBloqueoLinea() :" & ex.Message)
                    End Try


                    If bExisteBloqLinea Then
                        'Si existe bloqueo                        

                        Dim sListaMensajes() As String = strTramaMensajeBloq.Split("|"c)
                        Dim sNumero As String = ""
                        Dim sTickler As String = ""
                        Dim sDescripcion As String = ""
                        Dim sMensajeBloqueo As String
                        Dim sItem As String = ""


                        If bEsLineaPrincipal Then
                            strTramaMensajeGenBloq = String.Format("La Línea {0} no puede realizar una renovación por tener {1}", sListaMensajes(0).Split("-"c)(1), sListaMensajes(0).Split("-"c)(0))
                        Else
                            strTramaMensajeGenBloq = "La Línea no puede realizar una renovación por lo siguiente : " + Chr(13) + Chr(13)

                            Dim nMaxLineasBloqueos As Int16 = Funciones.CheckInt16(ConfigurationSettings.AppSettings("constMsjMaximoBloqueoLineas"))

                            For i As Integer = 0 To sListaMensajes.Length - 1
                                If i <= (nMaxLineasBloqueos - 1) Then
                                    'sTickler = sListaMensajes(i).Split("-"c)(0)
                                    sDescripcion = sListaMensajes(i).Split("-"c)(0)
                                    sNumero = sListaMensajes(i).Split("-"c)(1)

                                    sItem = sItem + "- " + sTickler + " " + sDescripcion + " " + sNumero + " " + Chr(13)
                                Else
                                    Exit For
                                End If
                            Next

                        End If

                        strTramaMensajeGenBloq = strTramaMensajeGenBloq + sItem
                        hidCodError.Value = "2" 'Si o si debe mostrar el boton Detalle X Linea
                        hidErrorConsulta.Value = strTramaMensajeGenBloq
                        
                    End If
                Else
                    oLog.Log_WriteLog(strArchivo, strArchivo & "- OUT No es CanalPermitido")
                End If

                oLog.Log_WriteLog(strArchivo, strArchivo & "- Fin EsCanalPermitido - ValidarBloqueoLinea()")
                'Fin Renovacion Por Bloqueo JAZ

                If Not blnTipoDocumentoRUC Then
                    blnBloqueoLDIFraude = ValidarDeudaFraude(strNroDoc, intTipoDocBscs, dtDetalleBSCS, dblDeudaLDIFraude, dblDeudaCastLDIFraude, strCustomerIdFraude)
                End If

                ObtenerDetalleBSCS(dtDetalleBSCS, strCustomerIdFraude, intGeneralBloqueo, arrCuentaMonto, strPlanesActivos, intMesesBSCS)
                oClienteCta.LineaBSCS = dtDetalleBSCS


                hidClienteExiste.Value = "S"
                blnClienteExiste = True

                'Consulta de Nro Planes x Producto
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "INICIO CONSULTA CANTIDAD DE PLANES BSCS")
                Dim strPlanActivoVozDatos As String
                Dim dsListaBSCSCantPlanes As DataSet = (New ConsumerNegocio).ListarDetalleLineaCantPlanes(intTipoDocBscs, strNroDoc)
                arrNroPlanesActivoxProducto = ObtenerNroPlanesxProductoBSCS(dsListaBSCSCantPlanes.Tables(0), strPlanActivoVozDatos)

            End If

            'Comportamiento Pago ----------------------------------------------------------------------------------------------------------
            Dim strMensaje As String
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "INICIO COMPORTAMIENTO DE PAGO")
            hidCalificacionPago.Value = (New SolicitudNegocios).ConsultarCalificacionPago(intTipoDocBscs, strNroDoc, strMensaje)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Output --> " & strMensaje)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Output [hidCalificacionPago.Value]--> " & hidCalificacionPago.Value)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "KeyApp [consCPValorEspecial]--> " & ConfigurationSettings.AppSettings("consCPValorEspecial"))

            'Consulta SGA -----------------------------------------------------------------------------------------------------------------
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "INICIO CONSULTA SGA")
            Dim dsListaSGA As DataSet = (New ConsumerNegocio).ListarDetalleLineaSGA(strTipoDocSGA, strNroDoc, intConsMesesRecurrente)

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "INICIO PARAMETROS DE ENTRADA")
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Tipo Doc SGA" & strTipoDocSGA)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Nro Documento" & strNroDoc)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Constante Meses Recurrente" & intConsMesesRecurrente)
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "FIN PARAMETROS DE ENTRADA")
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "FIN CONSULTA SGA")

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "antes de ingresar a recorrer dsListaSGA ")

            If Not IsNothing(dsListaSGA) AndAlso dsListaSGA.Tables(0).Rows.Count > 0 Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "ingrese a recorrer dsListaSGA ")

                Dim dtResumenSGA As DataTable = dsListaSGA.Tables(0)

                'Imprimir nombres de las columnas del datatable
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "****** Inicio -> Nombre de las columnas obtenidas en la lista SGA")
                For Each column As DataColumn In dtResumenSGA.Columns
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & column.ColumnName)
                Next
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "****** Fin -> Nombre de las columnas obtenidas en la lista SGA")

                ' If Not blnConsultaOAC Then
                If Not blnClienteExiste Then
                    strNombres = CheckStr(dtResumenSGA.Rows(0)("NOMCLI"))
                    strApellidos = Trim(CheckStr(dtResumenSGA.Rows(0)("APEPAT")) & " " & CheckStr(dtResumenSGA.Rows(0)("APEMAT")))
                    strRazonSocial = CheckStr(dtResumenSGA.Rows(0)("RAZON_SOCIAL"))
                End If

                'If dtResumenSGA.Columns.Contains("DEUDA_VENC") Then
                '    dblGeneralDeuda += CheckDbl(dtResumenSGA.Rows(0)("DEUDA_VENC"))
                'End If

                'If dtResumenSGA.Columns.Contains("DEUDA_CAST") Then
                '    dblGeneralDeudaCast += CheckDbl(dtResumenSGA.Rows(0)("DEUDA_CAST"))
                'End If
                'intDiasDeuda += CheckInt(dtResumenSGA.Rows(0)("DIAS_DEUDA"))
                intGeneralNroPlanes += CheckInt(dtResumenSGA.Rows(0)("NUM_PLAN"))
                'End If
                dblGeneralCF += CheckDbl(dtResumenSGA.Rows(0)("CF_SERVICIOS"))

                If dtResumenSGA.Columns.Contains("NUM_BLOQ") Then
                    intGeneralBloqueo += CheckInt(dtResumenSGA.Rows(0)("NUM_BLOQ"))
                End If
                intGeneralSuspension += CheckInt(dtResumenSGA.Rows(0)("NUM_SUSP"))


                'Obtener Detalle Líneas
                dtDetalleSGA = dsListaSGA.Tables(1)
                ObtenerDetalleSGA(dtDetalleSGA, strPlanesActivos, arrCuentaMonto, arrNroPlanesActivoxProdSGA, intMesesSGA)
                oClienteCta.LineaSGA = dtDetalleSGA


                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & " nroDetalleSGA : " & CheckStr(dtDetalleSGA.Rows.Count))

                Dim idx As Integer = 0
                Dim detalle As String = String.Empty
                For Each dr As DataRow In dtDetalleSGA.Rows
                    If idx <= intNroRegistroDataSet Then
                        detalle = String.Empty
                        For Each dc As DataColumn In dtDetalleSGA.Columns
                            detalle &= String.Format("[{0}={1}]", dc.ColumnName, dr(dc).ToString())
                        Next
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & " detalleSGA : " & detalle)
                    Else
                        Exit For
                    End If
                Next


                hidClienteExiste.Value = "S"
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "saliendo de recorrer dsListaSGA ")


            'CF Mayor/ Menor a N meses
            If Not blnTipoDocumentoRUC Then
                oClienteCta.CF_Menor = CheckDbl(CalcularCF_N_Meses(strNroDoc, intConsMesesRecurrente, 1), 2)
                oClienteCta.CF_Mayor = CheckDbl(CalcularCF_N_Meses(strNroDoc, intConsMesesRecurrente, 2), 2)
            End If

            'Consulta SISACT -----------------------------------------------------------------------------------------------------------------
            oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "INICIO CONSULTA SISACT")
            Dim dsDetalleSISACT As DataSet = (New ConsumerNegocio).ListarDetalleLineaSISACT(strTipoDoc, strNroDoc, listaTelefono)
            oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "FIN CONSULTA SISACT")

            If Not IsNothing(dsDetalleSISACT) AndAlso dsDetalleSISACT.Tables(0).Rows.Count > 0 Then
                Dim dtResumenSISACT As DataTable = dsDetalleSISACT.Tables(0)

                If Not blnClienteExiste Then
                    strNombres = CheckStr(dtResumenSISACT.Rows(0)("NOMBRE"))
                    strApellidos = Trim(CheckStr(dtResumenSISACT.Rows(0)("APELLIDO_PAT")) & " " & CheckStr(dtResumenSISACT.Rows(0)("APELLIDO_MAT")))
                    strRazonSocial = CheckStr(dtResumenSISACT.Rows(0)("RAZON_SOCIAL"))
                End If

                'Obtener Detalle Líneas
                dtDetalleSISACT = dsDetalleSISACT.Tables(1)
                ObtenerDetalleSISACT(dtDetalleSISACT, strPlanesActivos, arrCuentaMonto, arrNroPlanesActivoxProdSISACT)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "dtDetalleSISACT " & CheckStr(dtDetalleSISACT.Rows.Count))
                oClienteCta.LineaSISACT = dtDetalleSISACT

                For Each dr As DataRow In dtDetalleSISACT.Rows
                    intGeneralNroPlanes += 1
                    dblGeneralCF += CheckDbl(dr("CARGO_FIJO"))
                    oClienteCta.CF_Menor += CheckDbl(dr("CARGO_FIJO"))
                    hidClienteExiste.Value = "S"
                    oClienteCta.nroLineasBSCS += 1
                    oClienteCta.nroLineaMenor7Dia += 1
                    oClienteCta.nroLineaMenor30Dia += 1
                    oClienteCta.nroLineaMenor90Dia += 1
                    oClienteCta.nroLineaMenor180Dia += 1
                Next

            End If


            'Consulta Delimitador Nombres
            hidTokensApellido.Value = New MaestroNegocio().ListaPrefijosApellidoCompuesto()

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de ListaPrefijosApellidoCompuesto ")

            'Validaciones Generales ----------------------------------------------------------------------------------------------------------

            dblDeudaEvaluacion = dblGeneralDeuda + dblGeneralDeudaCast
            blnDeudaEvaluacion = (dblDeudaEvaluacion > 0)

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(intGeneralBloqueo))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeuda))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblDeudaEvaluacion))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeudaCast))

            oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - blnTipoDocumentoRUC " & blnTipoDocumentoRUC)
            'Validación Bloqueo LDI/Fraude
            If Not blnTipoDocumentoRUC Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "ingresando a not blnTipoDocumentoRUC")
                If blnBloqueoLDIFraude Then
                    dblGeneralDeuda = dblGeneralDeuda - dblDeudaLDIFraude
                    dblGeneralDeudaCast = dblGeneralDeudaCast - dblDeudaCastLDIFraude
                    dblDeudaEvaluacion = dblGeneralDeuda + dblGeneralDeudaCast

                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeuda))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblDeudaLDIFraude))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeudaCast))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblDeudaCastLDIFraude))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeuda))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo " & CheckStr(dblGeneralDeudaCast))

                End If
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "saliendo a not blnTipoDocumentoRUC")
            'Logica de Bloqueo x Deuda
            If blnDeudaEvaluacion Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "blnDeudaEvaluacion ")
                If CheckDbl(dblDeudaEvaluacion, 2) <= CheckDbl(dblConsUmbralDueda, 2) Then
                    blnDeudaEvaluacion = False
                End If
            End If
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralNroPlanes ")
            'Cliente Nuevo/Claro
            intMesesClaro = intMesesBSCS
            If intGeneralNroPlanes > 0 Then
                If intMesesClaro < intMesesSGA Then
                    intMesesClaro = intMesesSGA
                End If
                If intTiempoPermanencia <= intMesesClaro Then
                    blnClienteClaro = True
                End If
            End If
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "blnTipoDocumentoRUC 2 ")

            'Inicio Renovacion por Bloqueo JAZ
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Inicio Determinando Deuda y bloqueo del cliente")
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "hidCanalActual:" & hidCanalActual.Value)
            If EsCanalPermitido(hidCanalActual.Value, sCanalesPermitidosVerMsjValidaBloq) Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Determina que se visualiza el mensaje")

                If blnDeudaEvaluacion Then
                    strMensajeDeudaBloqueo = "Cliente presenta deuda "
                End If
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "strMensajeDeudaBloqueo :" & strMensajeDeudaBloqueo)

            Else
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Determina que no se visualiza el mensaje")

                'Si existe bloqueo, no debe mostrar el mensaje de bloqueos
                If bExisteBloqLinea Then
                    hidCodError.Value = ""
                    hidErrorConsulta.Value = ""
                End If
            'Determinar Deuda, Bloqueos del Cliente
                If blnDeudaEvaluacion And bExisteBloqLinea Then
                strMensajeDeudaBloqueo = "Cliente presenta Deuda y Bloqueo "
                ElseIf bExisteBloqLinea Then
                strMensajeDeudaBloqueo = "Cliente presenta bloqueos "
            ElseIf blnDeudaEvaluacion Then
                strMensajeDeudaBloqueo = "Cliente presenta deuda "
            End If
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "strMensajeDeudaBloqueo :" & strMensajeDeudaBloqueo)
            End If

            'Si la linea no tiene bloqueo
            If Not bExisteBloqLinea Or hidCalificacionPago.Value = ConfigurationSettings.AppSettings("consCPValorEspecial") Then
                hidCodError.Value = ""
                hidErrorConsulta.Value = ""
            End If


            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Fin Determinando Deuda y bloqueo del cliente")
            'Fin Renovacion por Bloqueo JAZ

            'Consulta Planes Activos x Tipo de Plan
            If Not blnTipoDocumentoRUC Then
                nroPlanDatosVoz(intTipoDocBscs, strNroDoc)
            End If

            ' End If
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "antes de Datos del Cliente  2 ")
            'Datos Cliente
            oClienteCta.nroLineas = intGeneralNroPlanes
            oClienteCta.nroLineasMenor = nroLineasMenorNmeses
            oClienteCta.nroLineasMayor = nroLineasMayorNmeses
            oClienteCta.esClienteClaro = blnClienteClaro
            oClienteCta.CF = CheckDbl(dblGeneralCF, 2)
            oClienteCta.deudaVencida = CheckDbl(dblGeneralDeuda, 2)
            oClienteCta.deudaCastigada = CheckDbl(dblGeneralDeudaCast, 2)
            oClienteCta.nombres = IIf(blnTipoDocumentoRUC, strRazonSocial, Trim(strNombres & " " & strApellidos)).ToString
            oClienteCta.nroBloqueo = intGeneralBloqueo
            oClienteCta.nroSuspension = intGeneralSuspension
            oClienteCta.nroMesesClaro = intMesesClaro
            oClienteCta.montoCuenta = arrCuentaMonto
            oClienteCta.planActivos = strPlanesActivos
            oClienteCta.nroDocAsociado = strNroDocAnexo
            oClienteCta.listaLineasFraude = strCustomerIdFraude


            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de Datos del Cliente  2 ")

            'Validación White/BlackList
            Dim oConsulta As New ConsumerNegocio
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "antes de ConsultaTopBlackWhiteList ")

            oConsulta.ConsultaTopBlackWhiteList(strTipoDoc, strNroDoc, intDiasDeuda, dblGeneralDeuda, intGeneralNroPlanes, intGeneralBloqueo, _
                                                oClienteCta.isBlackList, oClienteCta.isWhiteList, oClienteCta.isTop)

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de ConsultaTopBlackWhiteList ")


            'Validar BlackList de Créditos / WhiteList de Flexibilización
            If (oClienteCta.isBlackList And Not oClienteCta.isWhiteList) AndAlso hidCalificacionPago.Value <> ConfigurationSettings.AppSettings("consCPValorEspecial") Then
                hidBlackList.Value = "S"
            End If
            'Determinar si cliente puede evaluarse productos Móviles
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "intGeneralBloqueo :" & Funciones.CheckStr(intGeneralBloqueo))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "oClienteCta.isWhiteList:" & oClienteCta.isWhiteList.ToString)
            Dim strEvaluarMovil As String = "S"
            If ((blnDeudaEvaluacion) And (Not oClienteCta.isWhiteList)) AndAlso hidCalificacionPago.Value <> ConfigurationSettings.AppSettings("consCPValorEspecial") Then
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "strEvaluarMovil = N")
                strEvaluarMovil = "N"
            End If
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de Validar BlackList de Créditos / WhiteList de Flexibilización ")

            'Determinar Tipo de Cliente Claro/Nuevo
            Dim strCategoriaCliente As String = IIf(oClienteCta.esClienteClaro, "CLIENTE CLARO", "CLIENTE NUEVO").ToString
            If oClienteCta.isTop Then
                hidTop.Value = "S"
                strCategoriaCliente = strCategoriaCliente & " " & "TOP"
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de Determinar Tipo de Cliente ")

            'Datos Cliente
            hidNombres.Value = strNombres
            hidApellidos.Value = strApellidos
            hidRazonSocial.Value = strRazonSocial
            hidNroLineas.Value = CheckStr(intGeneralNroPlanes)
            hidPlanesActivos.Value = strPlanesActivos
            hidClienteClaro.Value = IIf(blnClienteClaro, "S", "N").ToString
            hidLblDeudaBloqueo.Value = strMensajeDeudaBloqueo
            hidLblCliente.Value = strCategoriaCliente
            hidEvaluarMovil.Value = strEvaluarMovil

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "despues de Datos Cliente 2 ")

            'inicio 18122013

            Dim EstadoLinea As String
            Dim strNroLinea As String
            If Not (ValidarEstadoLinea(dtDetalleBSCS, CheckInt(strTipoDoc), strNroDoc, hidnrolinea.Value, EstadoLinea, strNroLinea)) Then

                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Validando si es suspension/desactivacíon en la linea principal")
                oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "Validacion aplica para los canales:" & ConfigurationSettings.AppSettings("constCanalesPermitidosValSusDes"))
                Dim sCanalesPermitidosValSusDes() As String = ConfigurationSettings.AppSettings("constCanalesPermitidosValSusDes").Split(","c)
                If EsCanalPermitido(hidCanalActual.Value, sCanalesPermitidosValSusDes) Then
                    If (EstadoLinea = "Suspendido") AndAlso hidCalificacionPago.Value <> ConfigurationSettings.AppSettings("consCPValorEspecial") Then
                        hidCodError.Value = "1"
                        hidErrorConsulta.Value = ConfigurationSettings.AppSettings("constLineaDesactiva") & " " & "Suspendida"
                        oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & hidErrorConsulta.Value)
                End If
                If (EstadoLinea = "Desactivo") Then
                        hidCodError.Value = "1"
                        hidErrorConsulta.Value = ConfigurationSettings.AppSettings("constLineaDesactiva") & " " & "Desactiva"
                        oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & hidErrorConsulta.Value)
                    End If
                Else
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "No Aplica validacion de suspension/desactivacion")
                End If


                If (EstadoLinea = "") Then
                    hidCodError.Value = "1"
                    hidErrorConsulta.Value = ConfigurationSettings.AppSettings("constEstadoVacio")
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Error de estado de linea vacia - " & EstadoLinea)
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Error de estado de linea vacia - " & hidErrorConsulta.Value)
                End If
                If (strNroLinea = "") Then
                    hidCodError.Value = "1"
                    hidErrorConsulta.Value = ConfigurationSettings.AppSettings("constLineaVacia")
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Error de linea vacia- " & strNroLinea)
                    oLog.Log_WriteLog(strArchivo, strNroDoc & "Error de linea vacia- " & hidErrorConsulta.Value)
                End If

            End If

            'fin 18122013

            'Consulta SEC Pendientes
            Dim strSetNumDoc As String = IIf(strNroDoc.StartsWith("10"), strNroDoc, Right("0000000000000000" & strNroDoc, 16)).ToString()

            Dim intCantidad As Integer = oConsulta.EvaluacionPendiente(strTipoDoc, strSetNumDoc, Nothing)
            If intCantidad > 0 Then
                hidTieneSECPendiente.Value = "S"
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "antes  de Datos Plan 2 ")

            DatosPlan(hidnrolinea.Value)

            'Datos Monto Facturado y NO Facturado x Producto    
            ObtenerFacturacionxProducto(arrCuentaMonto, oClienteCta)

            'Nro Planes Activos x Producto
            For Each item As PlanBilletera In arrNroPlanesActivoxProdSGA
                arrNroPlanesActivoxProducto.Add(item)
            Next
            oClienteCta.oNroPlanesActivosxProducto = arrNroPlanesActivoxProducto

            'Datos Cliente BRMS
            oClienteCta.nroPlanesActivos = intGeneralNroPlanes
            oClienteCta.comportamientoPago = CheckInt(hidCalificacionPago.Value)
            oClienteCta.montoFacturadoTotal = CalcularPromedioFacturado(arrCuentaMonto)
            oClienteCta.tiempoPermanencia = CheckInt(intMesesClaro)
            oClienteCta.tipoCliente = strCategoriaCliente
            oClienteCta.planActual = hidplancomercial.Value
            oClienteCta.planActualCF = CheckDbl(hidcargofijo.Value)
'gaa20160321 - MRAF
            Session("nroLinea") = hidnrolinea.Value
            Session("planComercial") = hidplancomercial.Value
'fin gaa20160321
        Catch ex As Exception
            hidCodError.Value = "1"
            hidErrorConsulta.Value = ex.Message
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "ERROR DETALLE LINEA: " & ex.Message)
        Finally
            Session("oClienteCuenta" & strNroDoc) = oClienteCta
            oLog.Log_WriteLog(strArchivo, strNroDoc & "Consultar - " & "FIN CONSULTA DETALLE BSCS/SGA")
        End Try
    End Sub

    'inicio 18122013
    'Validar Linea Principal
    Public Function ValidarEstadoLinea(ByVal dtDetalleBSCS As DataTable, ByVal pstrTipoDocu As Integer, ByVal pstrNroDocumento As String, ByVal nrolinea As String, ByRef EstadoLinea As String, ByRef strNroLinea As String) As Boolean
        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim strEstadoLinea As String
        Dim strNroCuenta As String
        Dim strLinea As String
        Dim datosLinea As ClienteBSCS = Nothing
        Dim mensajeError As String = String.Empty
        datosLinea = oPostpagoNegocios.LeerDatosCliente(nrolinea, "", mensajeError)
        Dim strCoId As String = CheckStr(datosLinea.CustomerId)

        Dim resulEstado As Boolean = False
        Try
            oLog.Log_WriteLog(strArchivo, strArchivo & "-  INICIO VALIDAR ESTADO LINEA")
            oLog.Log_WriteLog(strArchivo, "CustomerId DE LeerDatosCliente ==>" & strCoId)
            If dtDetalleBSCS.Rows.Count > 0 Then
                oLog.Log_WriteLog(strArchivo, "Ingreso 1:")
                For Each item As DataRow In dtDetalleBSCS.Rows
                    oLog.Log_WriteLog(strArchivo, "Ingreso 2:")
                    strNroCuenta = CheckStr(item("CUSTOMER_ID"))

                    oLog.Log_WriteLog(strArchivo, "CUSTOMER_ID DE BSCS ==>" & strNroCuenta)

                    If strNroCuenta = strCoId Then
                        oLog.Log_WriteLog(strArchivo, "Ingreso 3:")
                    strEstadoLinea = CheckStr(item("ESTADO"))
                        'strLinea = CheckStr(item("NUMERO"))
                        'oLog.Log_WriteLog(strArchivo, "strLinea DE BSCS ==>" & strLinea)
                        'oLog.Log_WriteLog(strArchivo, "Linea:" & strNroCuenta)
                    oLog.Log_WriteLog(strArchivo, "Estado BSCS:" & strEstadoLinea)
                        EstadoLinea = strEstadoLinea
                        strNroLinea = nrolinea
                        If Not strNroLinea = "" Then
                            oLog.Log_WriteLog(strArchivo, "Ingreso 4:")
                        If Not strEstadoLinea Is Nothing Then
                                oLog.Log_WriteLog(strArchivo, "Ingreso 5:")
                            If Not EstadoLinea = "" Then
                                    oLog.Log_WriteLog(strArchivo, "Ingreso 6:")
                                If strEstadoLinea.ToUpper = ConfigurationSettings.AppSettings("CONS_ESTADO_ACTIVO") Then
                                        oLog.Log_WriteLog(strArchivo, "Ingreso 7:")
                                    resulEstado = True
                                        Exit For
                                Else
                                    resulEstado = False
                                End If
                            Else
                                    resulEstado = False
                                End If
                            End If
                        End If
                        resulEstado = False
                    End If
                Next
            End If
            oLog.Log_WriteLog(strArchivo, "Tipo Doumento:" & pstrTipoDocu)
            oLog.Log_WriteLog(strArchivo, "Nro Documento:" & pstrNroDocumento)
            oLog.Log_WriteLog(strArchivo, "Nro Linea:" & nrolinea)
            oLog.Log_WriteLog(strArchivo, "EstadoLinea:" & strEstadoLinea)
            oLog.Log_WriteLog(strArchivo, "Numero de Cuenta:" & strNroCuenta)
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strArchivo & "- Exception ValidarEstadoLinea()" & ex.Message)
        End Try

        Return resulEstado

    End Function

    'fin 18122013

    Private Sub ConsultarPool()
        Dim strTipoDoc As String = hidTipoDoc.Value
        Dim strNroDoc As String = hidNroDoc.Value
        Dim strTipoDocBscs As Integer
        Dim strTipoDocSGA As String
        Dim oClienteCta As New ClienteCuenta
        Session.Remove("oClienteCuenta" & strNroDoc)
        Session.Remove("oDetalleOAC" & strNroDoc)
        oClienteCta.nroDoc = strNroDoc
        oClienteCta.tipoDoc = strTipoDoc

        Dim arrListaDocum As ArrayList = (New ConsumerNegocio).ListarTipoDocumento()
        For Each item As TipoDocumento In arrListaDocum
            If item.TDOCC_CODIGO = strTipoDoc Then
                oClienteCta.tipoDocDes = item.TDOCV_DESCRIPCION
                txtTipoDocumento.Text = item.TDOCV_DESCRIPCION
                strTipoDocBscs = CheckInt(item.COD_BSCS)
                strTipoDocSGA = item.COD_SGA
                Exit For
            End If
        Next

        Try
            'Parametros Generales
            Dim dblConsUmbralDueda As Double
            Dim dblConsPorcDeudaVencida As Double
            Dim intConsMesesRecurrente As Integer
            Dim intConsMesesFactura As Integer
            Dim intTiempoPermanencia As Integer
            Dim arrParametros As ArrayList = New ConsumerNegocio().ListarParametroConsumer(1)
            For Each item As ParametroConsumer In arrParametros
                If item.PCONI_CODIGO.Equals("26") Then
                    dblConsPorcDeudaVencida = Funciones.CheckDbl(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO.Equals("27") Then
                    intConsMesesRecurrente = Funciones.CheckInt(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO.Equals("30") Then
                    intConsMesesFactura = Funciones.CheckInt(item.PCONV_VALOR)
                End If
                If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("constUmbralDeuda") Then
                    dblConsUmbralDueda = Funciones.CheckDbl(item.PCONV_VALOR)
                End If

                If blnTipoDocumentoRUC Then
                    If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("TiempoPermanenciaRUC") Then
                        intTiempoPermanencia = Funciones.CheckInt(item.PCONV_VALOR)
                    End If
                Else
                    If item.PCONI_CODIGO = ConfigurationSettings.AppSettings("TiempoPermanenciaDNI") Then
                        intTiempoPermanencia = Funciones.CheckInt(item.PCONV_VALOR)
                    End If
                End If
            Next

            Dim strNombres As String = ""
            Dim strApellidos As String = ""
            Dim strRazonSocial As String = ""
            Dim dblGeneralCF As Double = 0
            Dim intGeneralNroPlanes As Integer = 0
            Dim dblGeneralDeuda As Double = 0
            Dim dblGeneralDeudaCast As Double = 0
            Dim intGeneralBloqueo As Integer = 0
            Dim intGeneralSuspension As Integer = 0
            Dim intDiasDeuda As Integer = 0
            Dim blnClienteClaro As Boolean = False
            Dim arrCuentaMonto As New ArrayList
            Dim strPlanesActivos As String = ""
            Dim nroLineasMayorNmeses As Integer = 0
            Dim nroLineasMenorNmeses As Integer = 0
            Dim intMesesBSCS As Int64 = 0
            Dim intMesesSGA As Int64 = 0
            Dim intMesesClaro As Int64 = 0
            Dim strMensajeDeudaBloqueo As String
            Dim blnBloqueoEvaluacion As Boolean = False
            Dim dblDeudaEvaluacion As Double = 0
            Dim blnDeudaEvaluacion As Boolean = False
            Dim blnClienteExiste As Boolean = False
            Dim strNroDocAnexo As String = String.Empty
            Dim strCustomerIdFraude As String = ""
            Dim dblDeudaLDIFraude As Double = 0.0
            Dim dblDeudaCastLDIFraude As Double = 0.0
            Dim blnBloqueoLDIFraude As Boolean = False

            If blnTipoDocumentoRUC Then
                strNroDocAnexo = strNroDoc.Substring(2, 8)
            End If

            Dim oDetalleCliente As OACWS.DetalleClienteType()

            If blnConsultaOAC Then
                'Consulta OAC ----------------------------------------------------------------------------------------------------------------
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Usuario --> " & CurrentUser())
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - INICIO CONSULTA WS OAC")
                Dim strMensajeOAC As String
                oDetalleCliente = (New OACNegocio).DetalleClienteOAC(strNroDoc, CheckStr(CheckInt(strTipoDoc)), strNroDoc, strMensajeOAC)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Output --> " & strMensajeOAC)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - FIN CONSULTA WS OAC")

                'Obteniendo Datos del Cliente
                If oDetalleCliente(0).xCuentas.Length > 0 Then
                    strNombres = CheckStr(oDetalleCliente(0).xNombreCliente)
                    strApellidos = Trim(CheckStr(oDetalleCliente(0).xApePatCliente) & " " & CheckStr(oDetalleCliente(0).xApeMatCliente))
                    strRazonSocial = CheckStr(oDetalleCliente(0).xNombreCliente)
                    strNroDocAnexo = CheckStr(oDetalleCliente(0).xDniAsociado)
                    dblGeneralDeuda = CheckDbl(oDetalleCliente(0).xDeudaVencidaMovil) + CheckDbl(oDetalleCliente(0).xDeudaVencidaFija)
                    dblGeneralDeudaCast = CheckDbl(oDetalleCliente(0).xDeudaCastigadaMovil) + CheckDbl(oDetalleCliente(0).xDeudaCastigadaFija)
                    intDiasDeuda = CheckInt(oDetalleCliente(0).xAntiguedadDeuda)
                    intGeneralNroPlanes = CheckInt(oDetalleCliente(0).xTotalServicios)

                    hidClienteExiste.Value = "S"
                    blnClienteExiste = True
                End If
            End If

            oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - blnClienteExiste --> " & blnClienteExiste)
            oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - blnClienteExiste --> " & blnConsultaOAC)

            If blnClienteExiste Or Not blnConsultaOAC Then

                'Consulta BSCS ----------------------------------------------------------------------------------------------------------------
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "INICIO CONSULTA DETALLE BSCS/SGA")
                Dim dsListaBSCS As DataSet = (New ConsumerNegocio).ListarDetalleLinea(strTipoDocBscs, strNroDoc)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "FIN CONSULTA BSCS")


                If Not IsNothing(dsListaBSCS) Then
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - dsListaBSCS.Tables(0).Rows.Count --> " & dsListaBSCS.Tables(0).Rows.Count)
                Else
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - IsNothing(dsListaBSCS) -->nulo ")
                End If

                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------INICIO DE DATOS POP DETALLE LINEA ------")

                If Not IsNothing(dsListaBSCS) AndAlso dsListaBSCS.Tables(0).Rows.Count > 0 Then
                    Dim dtResumen As DataTable = dsListaBSCS.Tables(0)

                    If Not blnConsultaOAC Then
                        strNombres = CheckStr(dtResumen.Rows(0)("NOMBRES"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "Nombres " & strNombres)
                        strApellidos = CheckStr(dtResumen.Rows(0)("APELLIDOS"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------Apellidos" & strApellidos)
                        strRazonSocial = CheckStr(dtResumen.Rows(0)("RAZON_SOCIAL"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------Razon Social" & strRazonSocial)
                        dblGeneralDeuda = CheckDbl(dtResumen.Rows(0)("DEUV"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Deuda" & CheckStr(dblGeneralDeuda))
                        dblGeneralDeudaCast = CheckDbl(dtResumen.Rows(0)("DEUC"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Deuda castigada" & CheckStr(dblGeneralDeudaCast))
                        intDiasDeuda = CheckInt(dtResumen.Rows(0)("DIAS_DEUDA"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------Dias Deuda" & CheckStr(intDiasDeuda))
                        intGeneralNroPlanes = CheckInt(dtResumen.Rows(0)("PLANES"))
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Nro Planes" & CheckStr(intGeneralNroPlanes))
                    End If

                    dblGeneralCF = CheckDbl(dtResumen.Rows(0)("CF"))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General CF" & CheckStr(dblGeneralCF))
                    intGeneralBloqueo = CheckInt(dtResumen.Rows(0)("BLOQ"))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Bloqueo" & CheckStr(intGeneralBloqueo))
                    intGeneralSuspension = CheckInt(dtResumen.Rows(0)("SUSP"))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Suspension" & CheckStr(intGeneralSuspension))
                    oClienteCta.nroBloqueoMovil = intGeneralBloqueo
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Bloqueo" & CheckStr(intGeneralBloqueo))
                    oClienteCta.nroSuspensionMovil = intGeneralSuspension
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------General Suspension Movil" & CheckStr(intGeneralSuspension))
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "-------FIN DE DATOS POP DETALLE LINEA ------")

                    'Consulta Líneas Menores y Mayores a 90 Días
                    If blnTipoDocumentoRUC Then
                        Dim arrParametro As ArrayList = (New MaestroNegocio).ListaParametros(0)
                        For Each item As Parametro In arrParametro
                            If item.Codigo = 28 Then
                                oClienteCta.nroRangoDiasBSCS = CheckInt(item.Valor)
                                Exit For
                            End If
                        Next
                        nroLineasMayorNmeses = CheckInt(dtResumen.Rows(0)("NRO_90_MAS"))
                        nroLineasMenorNmeses = CheckInt(dtResumen.Rows(0)("NRO_90"))
                    End If

                    'Obtener Detalle Líneas
                    dtDetalleBSCS = dsListaBSCS.Tables(1)
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - blnTipoDocumentoRUC --> " & blnTipoDocumentoRUC)
                    If Not blnTipoDocumentoRUC Then
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - antes de fraude --> ")
                        blnBloqueoLDIFraude = ValidarDeudaFraude(strNroDoc, strTipoDocBscs, dtDetalleBSCS, dblDeudaLDIFraude, dblDeudaCastLDIFraude, strCustomerIdFraude)
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - despues de fraude ")

                    End If
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - antes de obtenerdetallebscs  --> ")
                    ObtenerDetalleBSCS(dtDetalleBSCS, strCustomerIdFraude, intGeneralBloqueo, arrCuentaMonto, strPlanesActivos, intMesesBSCS)
                    oClienteCta.LineaBSCS = dtDetalleBSCS
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - despues de obtenerdetallebscs  --> ")
                End If

                'Consulta SGA -----------------------------------------------------------------------------------------------------------------
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "INICIO CONSULTA SGA")
                Dim dsListaSGA As DataSet = (New ConsumerNegocio).ListarDetalleLineaSGA(strTipoDocSGA, strNroDoc, intConsMesesRecurrente)

                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - INICIO PARAMETROS DE ENTRADA CONSULTAR POOL")
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Tipo Doc SGA" & strTipoDocSGA)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Nro Documento" & strNroDoc)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Constante Meses Recurrente" & intConsMesesRecurrente)
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - FIN PARAMETROS DE ENTRADA CONSULTAR POOL")
                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - FIN CONSULTA SGA")

                oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - FIN CONSULTA SGA")

                If Not IsNothing(dsListaSGA) AndAlso dsListaSGA.Tables(0).Rows.Count > 0 Then
                    Dim dtResumenSGA As DataTable = dsListaSGA.Tables(0)

                    'Imprimir nombres de las columnas del datatable
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Inicio -> Nombre de las columnas obtenidas en la lista SGA")
                    For Each column As DataColumn In dtResumenSGA.Columns
                        oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & column.ColumnName)
                    Next
                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Fin -> Nombre de las columnas obtenidas en la lista SGA")

                    oLog.Log_WriteLog(strArchivo, strNroDoc & " - " & "ConsultarPool - Fin -> blnConsultaOAC --> " & blnConsultaOAC)
                    If Not blnConsultaOAC Then
                        If Not hidClienteExiste.Value = "S" Then
                            strNombres = CheckStr(dtResumenSGA.Rows(0)("NOMCLI"))
                            strApellidos = Trim(CheckStr(dtResumenSGA.Rows(0)("APEPAT")) & " " & CheckStr(dtResumenSGA.Rows(0)("APEMAT")))
                            strRazonSocial = CheckStr(dtResumenSGA.Rows(0)("RAZON_SOCIAL"))
                        End If

                        If dtResumenSGA.Columns.Contains("DEUDA_VENC") Then
                            dblGeneralDeuda += CheckDbl(dtResumenSGA.Rows(0)("DEUDA_VENC"))
                        End If

                        If dtResumenSGA.Columns.Contains("DEUDA_CAST") Then
                            dblGeneralDeudaCast += CheckDbl(dtResumenSGA.Rows(0)("DEUDA_CAST"))
                        End If

                        intDiasDeuda += CheckInt(dtResumenSGA.Rows(0)("DIAS_DEUDA"))
                        intGeneralNroPlanes += CheckInt(dtResumenSGA.Rows(0)("NUM_PLAN"))
                    End If

                    dblGeneralCF += CheckDbl(dtResumenSGA.Rows(0)("CF_SERVICIOS"))

                    If dtResumenSGA.Columns.Contains("NUM_BLOQ") Then
                        intGeneralBloqueo += CheckInt(dtResumenSGA.Rows(0)("NUM_BLOQ"))
                    End If

                    intGeneralSuspension += CheckInt(dtResumenSGA.Rows(0)("NUM_SUSP"))

                    'Obtener Detalle Líneas
                    dtDetalleSGA = dsListaSGA.Tables(1)
                    'ObtenerDetalleSGA(dtDetalleSGA, strPlanesActivos, arrCuentaMonto, intMesesSGA)
                    oClienteCta.LineaSGA = dtDetalleSGA

                End If


                'Consulta Delimitador Nombres
                hidTokensApellido.Value = New MaestroNegocio().ListaPrefijosApellidoCompuesto()

                'Validaciones Generales ----------------------------------------------------------------------------------------------------------
                dblDeudaEvaluacion = dblGeneralDeuda + dblGeneralDeudaCast
                blnDeudaEvaluacion = (dblDeudaEvaluacion > 0)

                'Validación Bloqueo LDI/Fraude
                If Not blnTipoDocumentoRUC Then
                    If blnBloqueoLDIFraude Then
                        dblGeneralDeuda = dblGeneralDeuda - dblDeudaLDIFraude
                        dblGeneralDeudaCast = dblGeneralDeudaCast - dblDeudaCastLDIFraude
                        dblDeudaEvaluacion = dblGeneralDeuda + dblGeneralDeudaCast
                    End If

                End If

            End If

            'Datos Cliente
            oClienteCta.nroLineas = intGeneralNroPlanes
            oClienteCta.nroLineasMenor = nroLineasMenorNmeses
            oClienteCta.nroLineasMayor = nroLineasMayorNmeses
            oClienteCta.esClienteClaro = blnClienteClaro
            oClienteCta.CF = CheckDbl(dblGeneralCF, 2)
            oClienteCta.deudaVencida = CheckDbl(dblGeneralDeuda, 2)
            oClienteCta.deudaCastigada = CheckDbl(dblGeneralDeudaCast, 2)
            oClienteCta.nombres = IIf(blnTipoDocumentoRUC, strRazonSocial, Trim(strNombres & " " & strApellidos)).ToString
            oClienteCta.nroBloqueo = intGeneralBloqueo
            oClienteCta.nroSuspension = intGeneralSuspension
            oClienteCta.nroMesesClaro = intMesesClaro
            oClienteCta.montoCuenta = arrCuentaMonto
            oClienteCta.planActivos = strPlanesActivos
            oClienteCta.nroDocAsociado = strNroDocAnexo
            oClienteCta.listaLineasFraude = strCustomerIdFraude

            oLog.Log_WriteLog(strArchivo, strNroDoc & " - INICIO LOG DE DATOS DEL CLIENTE ")

            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - Numero Lineas: " & CheckStr(oClienteCta.nroLineas))
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - Nro Lineas Menor Meses: " & CheckStr(oClienteCta.nroLineasMenor))
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - Nro Lineas Mayor Meses: " & CheckStr(oClienteCta.nroLineasMayor))
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - Cliente Claro: " & CheckStr(oClienteCta.esClienteClaro))
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - General CF: " & CheckStr(oClienteCta.CF))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool  - General Deuda vencida: " & CheckStr(oClienteCta.deudaVencida))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - General Deuda Cast: " & CheckStr(oClienteCta.deudaCastigada))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Nombres: " & CheckStr(oClienteCta.nombres))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Numero Bloqueo: " & CheckStr(intGeneralBloqueo))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Numero Suspension: " & CheckStr(intGeneralSuspension))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Numero Meses Claro: " & CheckStr(intGeneralSuspension))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Numero Suspension: " & CheckStr(intMesesClaro))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Plan Activos: " & CheckStr(strPlanesActivos))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Nro Doc Asociado: " & CheckStr(strNroDocAnexo))
            oLog.Log_WriteLog(strArchivo, strNroDoc & "ConsultarPool - Lista Lineas Fraude: " & CheckStr(strCustomerIdFraude))


            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - FIN LOG DE DATOS DEL CLIENTE ")

            Session("oClienteCuenta" & strNroDoc) = oClienteCta

            'Datos Cliente
            hidNombres.Value = strNombres
            hidApellidos.Value = strApellidos
            hidRazonSocial.Value = strRazonSocial

            'Mostrar Info Cliente
            If blnConsultaOAC Then
                Mostrar(oClienteCta, oDetalleCliente(0).xCuentas)
            Else
                Mostrar(oClienteCta, Nothing)
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - " & "ERROR DETALLE LINEA: " & ex.Message)
        Finally
            oLog.Log_WriteLog(strArchivo, strNroDoc & " ConsultarPool - " & "FIN CONSULTA DETALLE BSCS/SGA")
        End Try
    End Sub

    Private Sub ObtenerDetalleSISACT(ByVal dtDetalle As DataTable, _
                                      ByRef strPlanes As String, _
                                      ByRef arrCuentaMonto As ArrayList, _
                                      ByRef arrNroPlanesxProducto As ArrayList)

        Dim arrPlanBilletera As ArrayList = (New ReglasEvaluacionNegocio).ObtenerPlanesxBilletera("0")

        Dim oCtaBilletera As New PlanBilletera
        Dim oBilletera As New PlanBilletera
        Dim flgOK As Boolean = False
        Dim dtDetalleTmp As New DataTable

        For Each dr As DataRow In dtDetalle.Rows
            flgOK = False

            'Planes Activos
            strPlanes = String.Format("{0}|{1};{2}", strPlanes, CheckStr(dr("PLAN_BSCS")), "0")

            oCtaBilletera = New PlanBilletera
            oCtaBilletera.Cuenta = CheckStr(dr("PLAN_BSCS"))
            oCtaBilletera.MontoNoFacturado = CheckDbl(dr("CARGO_FIJO"), 2)

            For Each item As ItemGenerico In arrPlanBilletera
                If item.Codigo = CheckStr(dr("PLAN_SISACT")) Then
                    flgOK = True
                    oCtaBilletera.CodigoBilletera += CheckInt(item.Codigo2)
                    Select Case item.Codigo2
                        Case ConfigurationSettings.AppSettings("constTipoBilleteraMovil")
                            oCtaBilletera.NroPlanesMovil += 1
                        Case ConfigurationSettings.AppSettings("constTipoBilleteraInter")
                            oCtaBilletera.NroPlanesInternet += 1
                        Case ConfigurationSettings.AppSettings("constTipoBilleteraTV")
                            oCtaBilletera.NroPlanesClaroTV += 1
                        Case ConfigurationSettings.AppSettings("constTipoBilleteraTelef")
                            oCtaBilletera.NroPlanesTelefonia += 1
                        Case ConfigurationSettings.AppSettings("constTipoBilleteraBAM")
                            oCtaBilletera.NroPlanesBAM += 1
                    End Select
                End If
            Next

            If Not flgOK Then
                oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraMovil"))
                oCtaBilletera.NroPlanesMovil = 1
            End If

            arrCuentaMonto.Add(oCtaBilletera)
            arrNroPlanesxProducto.Add(oCtaBilletera)
        Next

    End Sub

    Private Sub createTableLineasSISACT(ByRef dtLineaFormatSISACT As DataTable, ByVal dtListaSISACT As DataTable)

        Dim strCuenta As String = ""
        Try
            oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 1 ")
            If Not IsNothing(dtListaSISACT) Then
                oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 2 ")
                For Each drSISACT As DataRow In dtListaSISACT.Rows
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 3 ")
                    If Not CheckStr(drSISACT("CUENTA")) = strCuenta Then
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 4 ")
                        strCuenta = CheckStr(drSISACT("CUENTA"))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 5 ")
                        Dim dblCF As Double = 0.0
                        Dim dblPromFacturado As Double = 0.0
                        Dim dblDeudaReintegro As Double = 0.0
                        Dim dblDeudaVencida As Double = 0.0
                        Dim dblDeudaCastigada As Double = 0.0
                        Dim dblMontoNoFacturado As Double = 0.0
                        Dim dblNroServicios As Double = 0.0
                        Dim dblNroBloqueos As Double = 0.0
                        Dim dblNroSuspensiones As Double = 0.0
                        Dim strCustomerID As String = String.Empty
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 6")
                        For Each dr1 As DataRow In dtListaSISACT.Rows
                            If CheckStr(drSISACT("CUENTA")) = CheckStr(dr1("CUENTA")) Then
                                oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 6.1")
                                dblNroServicios += 1
                                dblCF += CheckDbl(dr1("CARGO_FIJO"), 2)
                                dblPromFacturado += 0
                                dblMontoNoFacturado += CheckDbl(dr1("CARGO_FIJO"), 2)
                                oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 6.2")
                            End If
                        Next
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 7")
                        Dim dr As DataRow = dtLineaFormatSISACT.NewRow
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 8")
                        dr("CODIGO_CUENTA") = strCuenta
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 9 ")
                        dr("ESTADO_CUENTA") = drSISACT("ESTADO")
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 10")
                        dr("CUSTOMER_ID") = strCustomerID
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 11 ")
                        dr("CENTRAL_RIESGO") = ""
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 12")
                        dr("CF") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblCF, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 13")
                        dr("PROMEDIO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblPromFacturado, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 14 ")
                        dr("MONTO_NO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblMontoNoFacturado, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 15 ")
                        dr("MONTO_VENCIDO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaVencida, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 16")
                        dr("MONTO_CASTIGADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaCastigada, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 17")
                        dr("DEUDA_REINTEGRO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaReintegro, 2))
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 18")
                        dr("CANTIDAD_SERVICIOS") = dblNroServicios
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 19")
                        dr("CANTIDAD_BLOQUEOS") = dblNroBloqueos
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 20")
                        dr("CANTIDAD_SUSPENDIDOS") = dblNroSuspensiones
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 21")

                        dtLineaFormatSISACT.Rows.Add(dr)
                        oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 22")
                    End If
                Next
                oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & " createTableLineasSISACT: 23")
            End If
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, idNroDocumento & " createTableLineasSISACT - " & "ERROR createTableLineasSISACT: " & ex.Message)
        End Try

    End Sub


#Region "Funciones"

    Function CalcularPromedioFacturado(ByVal arrMontoFacturadoxProducto As ArrayList) As Double
        Dim dblMontoFacturado As Double = 0.0
        For Each item As PlanBilletera In arrMontoFacturadoxProducto
            dblMontoFacturado = dblMontoFacturado + item.MontoFacturado
        Next
        Return dblMontoFacturado
    End Function

    Private Function CalcularCF_N_Meses(ByVal strNroDoc As String, ByVal intConsMesesRecurrente As Integer, ByVal tipo As Integer) As Double
        Dim dblCF As Double = 0.0
        Dim arrCF As ArrayList = New SolicitudNegocios().ObtenerFormulaRecurrente(strNroDoc, intConsMesesRecurrente, tipo)
        For Each item As FormulaRecurrente In arrCF
            dblCF = dblCF + Funciones.CheckDbl(item.CF * item.ACTIVOS)
        Next
        dblCF = CheckDbl(dblCF, 2)
        Return dblCF
    End Function

    Private Function nroLineaMayor_n_meses(ByVal dtDetalle As DataTable, ByVal intMeses As Integer) As Integer
        Dim nroLineas As Integer = 0
        Dim fecha As Date
        For Each dr As DataRow In dtDetalle.Rows
            If UCase(CheckStr(dr("ESTADO"))) = "ACTIVO" Then
                fecha = DateTime.Parse(CheckStr(dr("FECHA_ACTIVACION")))
                If DateDiff(DateInterval.Month, fecha, Date.Now) >= intMeses Then
                    nroLineas += 1
                End If
            End If
        Next
        Return nroLineas
    End Function

    Private Function nroLineaMenor_n_meses(ByVal dtDetalle As DataTable, ByVal intMeses As Integer) As Integer
        Dim nroLineas As Integer = 0
        Dim fecha As Date
        For Each dr As DataRow In dtDetalle.Rows
            If UCase(CheckStr(dr("ESTADO"))) = "ACTIVO" Then
                fecha = DateTime.Parse(CheckStr(dr("FECHA_ACTIVACION")))
                If DateDiff(DateInterval.Month, fecha, Date.Now) < intMeses Then
                    nroLineas += 1
                End If
            End If
        Next
        Return nroLineas
    End Function

    Private Sub nroPlanDatosVoz(ByVal strTipoDocBscs As Integer, ByVal strNroDoc As String)
        Try
            'Consulta Planes Activos x Tipo de Plan
            Dim nroPlanVoz, nroPlanDatos As Integer
            Dim CFPlanVoz, CFPlanDatos As Double
            Dim arrPlanes As ArrayList = (New SolicitudNegocios).ObtenerPlanesCliente(strTipoDocBscs, strNroDoc)
            For Each oPlan As Plan_AP In arrPlanes
                If oPlan.PLNN_TIPO_PLAN = Plan_AP.TIPO_PLAN.VOZ Then
                    CFPlanVoz += oPlan.CARGO_FIJO_BASE
                    nroPlanVoz += 1
                ElseIf oPlan.PLNN_TIPO_PLAN = Plan_AP.TIPO_PLAN.DATOS Then
                    CFPlanDatos += oPlan.CARGO_FIJO_BASE
                    nroPlanDatos += 1
                End If
            Next
            hidPlanesDatosVoz.Value = String.Format("{0};{1}|{2};{3}", nroPlanVoz, CFPlanVoz, nroPlanDatos, CFPlanDatos)
        Catch ex As Exception
            hidPlanesDatosVoz.Value = String.Format("{0};{1}|{2};{3}", "0", "0", "0", "0")
        End Try
    End Sub

    Private Sub ObtenerDetalleBSCS(ByVal dtDetalle As DataTable, _
                                        ByVal strCustomerIdFraude As String, _
                                            ByRef intNroBloqueo As Integer, _
                                            ByRef arrCuentaMonto As ArrayList, _
                                            ByRef strPlanes As String, _
                                            ByRef intMesesClaro As Int64)
        Dim fecha As Date
        Dim intMeses As Int64
        Dim arrCuenta As New ArrayList
        intMesesClaro = 0

        For Each dr As DataRow In dtDetalle.Rows
            arrCuenta.Add(CheckStr(dr("CUENTA")))

            'Tiempo Permanencia Claro
            If Not blnTipoDocumentoRUC Then
                If UCase(CheckStr(dr("ESTADO"))) = "ACTIVO" AndAlso CheckStr(dr("FECHA_ACTIVACION")) <> "" Then
                    fecha = DateTime.Parse(CheckStr(dr("FECHA_ACTIVACION")))
                    intMeses = DateDiff(DateInterval.Month, fecha, Date.Now)
                    If intMesesClaro < intMeses Then
                        intMesesClaro = intMeses
                    End If
                End If
            Else
                If CheckStr(dr("FECHA_ACTIVACION")) <> "" Then
                    fecha = DateTime.Parse(CheckStr(dr("FECHA_ACTIVACION")))
                    intMeses = DateDiff(DateInterval.Month, fecha, Date.Now)
                    If intMesesClaro < intMeses Then
                        intMesesClaro = intMeses
                    End If
                End If
            End If
        Next
        arrCuenta.Sort()

        Dim flgAdd As Boolean = False
        Dim strCuenta As String = ""
        Dim oCtaBilletera As New PlanBilletera

        For Each item As String In arrCuenta
            If strCuenta <> item Then
                strCuenta = item
                flgAdd = False
                For Each dr As DataRow In dtDetalle.Rows
                    If strCuenta = CheckStr(dr("CUENTA")) Then

                        If Not flgAdd Then
                            If strCustomerIdFraude.IndexOf("|" & CheckStr(dr("CUSTOMER_ID")) & "|") = -1 Then
                                flgAdd = True
                                oCtaBilletera = New PlanBilletera
                                oCtaBilletera.Cuenta = strCuenta
                                oCtaBilletera.MontoFacturado = CheckDbl(dr("PROM_FACT"), 2)
                                oCtaBilletera.MontoNoFacturado = CheckDbl(dr("MONTO_NO_FACT"), 2)
                                oCtaBilletera.NroPlanesMovil = CheckInt(dr("NRO_MOVIL"))
                                oCtaBilletera.NroPlanesInternet = CheckInt(dr("NRO_INTERNET_FIJO"))
                                oCtaBilletera.NroPlanesTelefonia = CheckInt(dr("NRO_TELEF_FIJA"))
                                oCtaBilletera.NroPlanesClaroTV = CheckInt(dr("NRO_CLARO_TV"))
                                oCtaBilletera.NroPlanesBAM = CheckInt(dr("NRO_BAM"))
                                oCtaBilletera.CodigoBilletera = ObtenerCodigoBilletera(oCtaBilletera)

                                arrCuentaMonto.Add(oCtaBilletera)
                            End If
                        End If
                        If Not blnTipoDocumentoRUC Then
                            'Lista de Planes Activos
                            If UCase(CheckStr(dr("ESTADO"))) = "ACTIVO" Then
                                strPlanes = String.Format("{0}|{1};{2}", strPlanes, CheckStr(dr("TMCODE")), "0")
                            End If

                            'Consulta Apadece Vigente SIGA
                            'If intNroBloqueo > 0 Then
                            '    If CheckStr(dr("COD_BLOQ")) = "BLOQ_PER" OrElse CheckStr(dr("COD_BLOQ")) = "BLOQ_ROB" Then
                            'Dim intEstado As Integer = (New ConsumerNegocio).ObtenerEstadoApadece(CheckInt64(dr("CO_ID")))
                            'intNroBloqueo -= intEstado
                            '    End If
                            'End If
                        End If
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub ObtenerDetalleSGA(ByVal dtDetalle As DataTable, _
                                        ByRef strPlanes As String, _
                                        ByRef arrCuentaMonto As ArrayList, _
                                        ByRef arrNroPlanesxProducto As ArrayList, _
                                        ByRef intMesesClaro As Int64)
        Dim fecha As Date
        Dim intMeses As Int64
        intMesesClaro = 0
        Dim arrPlanBilletera As ArrayList = (New ReglasEvaluacionNegocio).ObtenerPlanesxBilletera("1")
        Dim arrListaBilletera As ArrayList = (New ConsumerNegocio).ListarBilletera()

        Dim oCtaBilletera As New PlanBilletera
        Dim oBilletera As New PlanBilletera
        Dim flgOK As Boolean = False

        For Each dr As DataRow In dtDetalle.Rows
            flgOK = False
            'Tiempo Permanencia Claro
            If UCase(CheckStr(dr("ESTADO"))) = "ACTIVO" Then
                'Planes Activos
                strPlanes = String.Format("{0}|{1};{2}", strPlanes, CheckStr(dr("IDPAQ")), "1")

                oCtaBilletera = New PlanBilletera
                oCtaBilletera.Cuenta = CheckStr(dr("IDPAQ"))
                oCtaBilletera.MontoFacturado = CheckDbl(dr("PROM_FAC"), 2)
                oCtaBilletera.MontoNoFacturado = CheckDbl(dr("MONTO_NO_FAC"), 2)

                For Each item As ItemGenerico In arrPlanBilletera
                    If item.Codigo = CheckStr(dr("IDPAQ")) Then
                        flgOK = True
                        oCtaBilletera.CodigoBilletera += CheckInt(item.Codigo2)
                        Select Case item.Codigo2
                            Case ConfigurationSettings.AppSettings("constTipoBilleteraMovil")
                                oCtaBilletera.NroPlanesMovil += 1
                            Case ConfigurationSettings.AppSettings("constTipoBilleteraInter")
                                oCtaBilletera.NroPlanesInternet += 1
                            Case ConfigurationSettings.AppSettings("constTipoBilleteraTV")
                                oCtaBilletera.NroPlanesClaroTV += 1
                            Case ConfigurationSettings.AppSettings("constTipoBilleteraTelef")
                                oCtaBilletera.NroPlanesTelefonia += 1
                            Case ConfigurationSettings.AppSettings("constTipoBilleteraBAM")
                                oCtaBilletera.NroPlanesBAM += 1
                        End Select
                    End If
                Next

                If Not flgOK Then
                    oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilletera3Play"))
                    oCtaBilletera.NroPlanesInternet = 1
                    oCtaBilletera.NroPlanesClaroTV = 1
                    oCtaBilletera.NroPlanesTelefonia = 1
                End If

                arrCuentaMonto.Add(oCtaBilletera)
                arrNroPlanesxProducto.Add(oCtaBilletera)

                If Not CheckStr(dr("FECHA_ACTIVACION")) = "" Then
                    fecha = DateTime.Parse(CheckStr(dr("FECHA_ACTIVACION")))
                    intMeses = DateDiff(DateInterval.Month, fecha, Date.Now)
                    If intMesesClaro < intMeses Then
                        intMesesClaro = intMeses
                    End If
                End If
            End If
        Next

    End Sub

    Private Function ObtenerProductoBilletera(ByVal oCtaBilletera As PlanBilletera) As PlanBilletera
        If oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraInter")) Then
            oCtaBilletera.NroPlanesInternet += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraTelef")) Then
            oCtaBilletera.NroPlanesTelefonia += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraTV")) Then
            oCtaBilletera.NroPlanesClaroTV += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt("12") Then
            oCtaBilletera.NroPlanesInternet += 1
            oCtaBilletera.NroPlanesClaroTV += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt("20") Then
            oCtaBilletera.NroPlanesInternet += 1
            oCtaBilletera.NroPlanesTelefonia += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt("24") Then
            oCtaBilletera.NroPlanesTelefonia += 1
            oCtaBilletera.NroPlanesClaroTV += 1
        End If
        If oCtaBilletera.CodigoBilletera = CheckInt(ConfigurationSettings.AppSettings("constTipoBilletera3Play")) Then
            oCtaBilletera.NroPlanesInternet += 1
            oCtaBilletera.NroPlanesTelefonia += 1
            oCtaBilletera.NroPlanesClaroTV += 1
        End If

        Return oCtaBilletera
    End Function

    Private Function ObtenerCodigoBilletera(ByVal oCtaBilletera As PlanBilletera) As Integer
        Dim intCodBilletera As Integer = 0
        If oCtaBilletera.NroPlanesMovil > 0 Then
            intCodBilletera += CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraMovil"))
        End If
        If oCtaBilletera.NroPlanesInternet > 0 Then
            intCodBilletera += CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraInter"))
        End If
        If oCtaBilletera.NroPlanesClaroTV > 0 Then
            intCodBilletera += CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraTV"))
        End If
        If oCtaBilletera.NroPlanesTelefonia > 0 Then
            intCodBilletera += CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraTelef"))
        End If
        If oCtaBilletera.NroPlanesBAM > 0 Then
            intCodBilletera += CheckInt(ConfigurationSettings.AppSettings("constTipoBilleteraBAM"))
        End If

        Return intCodBilletera
    End Function

    Private Function ValidarBloqueoLDI_Fraude(ByVal strNroDoc As String, ByVal strTipoDoc As Integer, ByRef dblDeuda As Double) As Boolean
        Dim dblDeudaLDI As Double = 0.0
        Dim dblDeudaFraude As Double = 0.0
        Dim blnBloqueoLDI As Boolean = False
        Dim blnBloqueoFraude As Boolean = False
        Dim blnLDIFraude As Boolean = False

        Dim arrDeudaLDIFraude As ArrayList = (New ClienteCons_Negocio).BuscarClienteDeudaBloqueo("1", strNroDoc, strTipoDoc)

        For Each item As Cliente_Cons In CType(arrDeudaLDIFraude(0), ArrayList)
            'Líneas desactivadas por Fraude F02/F03
            Dim strBloqueosFraude As String = ConfigurationSettings.AppSettings("ConstCodBloqueoFraude")
            If UCase(item.ESTADO_LINEA) = "DESACTIVADO" And item.TIPO_ESTADO <> "" And strBloqueosFraude.IndexOf(UCase(item.TIPO_ESTADO)) > 0 Then
                blnBloqueoFraude = True
            Else
                'Líneas Bloqueadas por Motivo LDI
                If UCase(item.CODIGO_BLOQUEO) = ConfigurationSettings.AppSettings("ConstCodBloqueoLDI") Then
                    blnBloqueoLDI = True
                End If
                dblDeudaFraude = dblDeudaFraude + CheckDbl(item.DEUDA_VENCIDA_CUENTA)
            End If
            dblDeudaLDI = dblDeudaLDI + CheckDbl(item.DEUDA_VENCIDA_CUENTA)
        Next

        'Deuda Vencida obtenida de Bloqueo LDI/Fraude
        If blnBloqueoFraude Or blnBloqueoLDI Then
            blnLDIFraude = True
            If blnBloqueoFraude And blnBloqueoLDI Then
                dblDeuda = dblDeudaFraude
                If dblDeuda < dblDeudaLDI Then
                    dblDeuda = dblDeudaLDI
                End If
            ElseIf blnBloqueoFraude Then
                dblDeuda = dblDeudaFraude
            ElseIf blnBloqueoLDI Then
                dblDeuda = dblDeudaLDI
            End If
        End If

        Return blnLDIFraude
    End Function

    Private Sub createTableLineas(ByVal numDoc As String, ByVal listaCuentas As OACWS.DetalleCuentaType(), _
                                ByRef dtLineaFormatBSCS As DataTable, ByRef dtLineaFormatSGA As DataTable, _
                                ByVal dtListaBSCS As DataTable, ByVal dtListaSGA As DataTable, ByVal strCustomerIdFraude As String)

        Dim strCuenta As String = ""
        If Not IsNothing(dtListaBSCS) Then
            For Each drBscs As DataRow In dtListaBSCS.Rows
                If Not CheckStr(drBscs("CUENTA")) = strCuenta Then
                    strCuenta = CheckStr(drBscs("CUENTA"))

                    Dim dr As DataRow = dtLineaFormatBSCS.NewRow
                    Dim strEstado As String
                    Dim dblCF As Double = 0.0
                    Dim dblNroServicio As Double = 0.0
                    Dim dblPromFacturado As Double = 0.0
                    Dim dblDeudaReintegro As Double = 0.0
                    Dim dblDeudaVencida As Double = 0.0
                    Dim dblDeudaCastigada As Double = 0.0
                    Dim dblMontoNoFacturado As Double = 0.0
                    Dim dblNroBloqueos As Double = 0.0
                    Dim dblNroSuspensiones As Double = 0.0
                    Dim strCustomerID As String = String.Empty
                    Dim flgCuentaFraude As Boolean = False

                    'Consulta Deuda OAC
                    If blnConsultaOAC Then
                        If Not listaCuentas Is Nothing Then
                            For Each item As OACWS.DetalleCuentaType In listaCuentas
                                If item.xTipoServicio = "MOVIL" Then
                                    If item.xCodCuenta.Equals(strCuenta) Then
                                        dblDeudaVencida = CheckDbl(item.xDeudaVencida, 2)
                                        dblDeudaCastigada = CheckDbl(item.xDeudaCastigada, 2)
                                        dblDeudaReintegro = CheckDbl(dblDeudaReintegro, 2)
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If

                    For Each fila As DataRow In dtListaBSCS.Rows
                        If strCuenta.Equals(fila("CUENTA")) Then
                            If strCustomerIdFraude.IndexOf("|" & CheckStr(fila("CUSTOMER_ID")) & "|") = -1 Then
                                flgCuentaFraude = True
                                strCustomerID = CheckStr(fila("CUSTOMER_ID"))
                                dblCF += CheckDbl(fila("CF_CONTRATO"))
                                dblPromFacturado = CheckDbl(fila("PROM_FACT"))
                                dblMontoNoFacturado = CheckDbl(fila("MONTO_NO_FACT"))

                                If Not blnConsultaOAC Then
                                    dblDeudaReintegro = CheckDbl(fila("DEUDA_REINT_EQUIPO"))
                                    dblDeudaVencida = CheckDbl(fila("MONTO_VENCIDO"))
                                    dblDeudaCastigada = CheckDbl(fila("MONTO_CASTIGO"))
                                End If

                                strEstado = CheckStr(fila("ESTADO"))
                                dblNroServicio = CheckDbl(fila("NRO_PLANES"))
                                dblNroBloqueos = CheckDbl(fila("NRO_BLOQ"))
                                dblNroSuspensiones = CheckDbl(fila("NRO_SUSP"))
                            End If
                        End If
                    Next

                    If flgCuentaFraude Then
                        dr("CODIGO_CUENTA") = strCuenta
                        dr("ESTADO_CUENTA") = strEstado
                        dr("CUSTOMER_ID") = strCustomerID
                        dr("CENTRAL_RIESGO") = ""
                        dr("CF") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblCF, 2))
                        dr("PROMEDIO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblPromFacturado, 2))
                        dr("MONTO_NO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblMontoNoFacturado, 2))
                        dr("MONTO_VENCIDO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaVencida, 2))
                        dr("MONTO_CASTIGADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaCastigada, 2))
                        dr("DEUDA_REINTEGRO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaReintegro, 2))
                        dr("CANTIDAD_SERVICIOS") = dblNroServicio
                        dr("CANTIDAD_BLOQUEOS") = dblNroBloqueos
                        dr("CANTIDAD_SUSPENDIDOS") = dblNroSuspensiones

                        dtLineaFormatBSCS.Rows.Add(dr)
                    End If
                End If
            Next
        End If

        strCuenta = ""
        If Not IsNothing(dtListaSGA) Then
            For Each drSGA As DataRow In dtListaSGA.Rows
                If Not CheckStr(drSGA("CODCLI")) = strCuenta Then
                    strCuenta = CheckStr(drSGA("CODCLI"))

                    Dim dr As DataRow = dtLineaFormatSGA.NewRow
                    Dim strEstado As String
                    Dim dblCF As Double = 0.0
                    Dim dblPromFacturado As Double = 0.0
                    Dim dblDeudaReintegro As Double = 0.0
                    Dim dblDeudaVencida As Double = 0.0
                    Dim dblDeudaCastigada As Double = 0.0
                    Dim dblMontoNoFacturado As Double = 0.0
                    Dim dblNroServicios As Double = 0.0
                    Dim dblNroBloqueos As Double = 0.0
                    Dim dblNroSuspensiones As Double = 0.0
                    Dim strCustomerID As String = String.Empty

                    'Consulta Deuda OAC
                    If blnConsultaOAC Then
                        If Not listaCuentas Is Nothing Then
                            For Each item As OACWS.DetalleCuentaType In listaCuentas
                                If item.xTipoServicio = "FIJA" Then
                                    If item.xCodCuenta.Equals(strCuenta) Then
                                        dblDeudaVencida = CheckDbl(item.xDeudaVencida, 2)
                                        dblDeudaCastigada = CheckDbl(item.xDeudaCastigada, 2)
                                        dblDeudaReintegro = CheckDbl(dblDeudaReintegro, 2)
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End If

                    For Each fila As DataRow In dtListaSGA.Rows
                        If strCuenta.Equals(fila("CODCLI")) Then
                            dblCF += CheckDbl(fila("MONTO_CR"))
                            dblPromFacturado += CheckDbl(fila("PROM_FAC"))
                            dblMontoNoFacturado += CheckDbl(fila("MONTO_NO_FAC"))

                            If Not blnConsultaOAC Then
                                dblDeudaVencida += CheckDbl(fila("MONTO_VENCIDO"))
                                dblDeudaCastigada += CheckDbl(fila("MONTO_CASTIGO"))
                            End If

                            dblNroServicios += CheckDbl(fila("CANT_SRV"))
                            strEstado = CheckStr(fila("ESTADO"))
                            dblNroBloqueos += CheckDbl(fila("CANTIDAD_BLOQ"))
                            dblNroSuspensiones += CheckDbl(fila("CANTIDAD_SUSP"))
                        End If
                    Next

                    dr("CODIGO_CUENTA") = strCuenta
                    dr("ESTADO_CUENTA") = strEstado
                    dr("CUSTOMER_ID") = strCustomerID
                    dr("CENTRAL_RIESGO") = ""
                    dr("CF") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblCF, 2))
                    dr("PROMEDIO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblPromFacturado, 2))
                    dr("MONTO_NO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblMontoNoFacturado, 2))
                    dr("MONTO_VENCIDO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaVencida, 2))
                    dr("MONTO_CASTIGADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaCastigada, 2))
                    dr("DEUDA_REINTEGRO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaReintegro, 2))
                    dr("CANTIDAD_SERVICIOS") = dblNroServicios
                    dr("CANTIDAD_BLOQUEOS") = dblNroBloqueos
                    dr("CANTIDAD_SUSPENDIDOS") = dblNroSuspensiones

                    dtLineaFormatSGA.Rows.Add(dr)
                End If
            Next
        End If

    End Sub

    Private Sub createTableLineasOAC(ByVal numDoc As String, ByVal listaCuentas As OACWS.DetalleCuentaType(), _
                                        ByRef dtLineaFormatBSCS As DataTable, ByRef dtLineaFormatSGA As DataTable, _
                                        ByVal dtListaBSCS As DataTable, ByVal dtListaSGA As DataTable, ByVal strCustomerIdFraude As String)

        Try
            For Each item As OACWS.DetalleCuentaType In listaCuentas

                oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " createTableLineas - item.xTipoServicio  --> " & item.xTipoServicio)

                Select Case item.xTipoServicio
                    Case "MOVIL"
                        Dim dr As DataRow = dtLineaFormatBSCS.NewRow
                        Dim strCustomerID As String = String.Empty
                        Dim dblCF As Double = 0.0
                        Dim dblPromFacturado As Double = 0.0
                        Dim dblMontoNoFacturado As Double = 0.0
                        Dim dblDeudaReintegro As Double = 0.0
                        Dim dblNroBloqueos As Double = 0.0
                        Dim dblNroSuspensiones As Double = 0.0
                        Dim flgCuentaFraude As Boolean = False

                        If Not IsNothing(dtListaBSCS) Then
                            For Each fila As DataRow In dtListaBSCS.Rows
                                If item.xCodCuenta.Equals(fila("CUENTA")) Then
                                    If strCustomerIdFraude.IndexOf("|" & CheckStr(fila("CUSTOMER_ID")) & "|") = -1 Then
                                        flgCuentaFraude = True
                                        strCustomerID = CheckStr(fila("CUSTOMER_ID"))
                                        dblCF += CheckDbl(fila("CF_CONTRATO"))
                                        dblPromFacturado = CheckDbl(fila("PROM_FACT"))
                                        dblMontoNoFacturado = CheckDbl(fila("MONTO_NO_FACT"))
                                        dblDeudaReintegro = CheckDbl(fila("DEUDA_REINT_EQUIPO"))
                                        dblNroBloqueos = CheckDbl(fila("NRO_BLOQ"))
                                        dblNroSuspensiones = CheckDbl(fila("NRO_SUSP"))
                                    End If
                                End If
                            Next
                        End If
                        If flgCuentaFraude Then
                            dr("CODIGO_CUENTA") = item.xCodCuenta
                            dr("ESTADO_CUENTA") = IIf(item.xEstadoCuenta.Equals("A"), "Activa", "Inactiva")
                            dr("CUSTOMER_ID") = strCustomerID
                            dr("CENTRAL_RIESGO") = item.xIndCentralRiesgo
                            dr("CF") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblCF, 2))
                            dr("PROMEDIO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblPromFacturado, 2))
                            dr("MONTO_NO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblMontoNoFacturado, 2))
                            dr("MONTO_VENCIDO") = String.Format("{0:#,#,#,0.00}", CheckDbl(item.xDeudaVencida, 2))
                            dr("MONTO_CASTIGADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(item.xDeudaCastigada, 2))
                            dr("DEUDA_REINTEGRO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaReintegro, 2))
                            dr("CANTIDAD_SERVICIOS") = item.xCantServicios
                            dr("CANTIDAD_BLOQUEOS") = dblNroBloqueos
                            dr("CANTIDAD_SUSPENDIDOS") = dblNroSuspensiones

                            dtLineaFormatBSCS.Rows.Add(dr)
                        End If
                    Case "FIJA"
                        Dim dr As DataRow = dtLineaFormatSGA.NewRow
                        Dim strCustomerID As String = String.Empty
                        Dim dblCF As Double = 0.0
                        Dim dblPromFacturado As Double = 0.0
                        Dim dblMontoNoFacturado As Double = 0.0
                        Dim dblDeudaReintegro As Double = 0.0
                        Dim dblNroBloqueos As Double = 0.0
                        Dim dblNroSuspensiones As Double = 0.0

                        If Not IsNothing(dtListaSGA) Then
                            For Each fila As DataRow In dtListaSGA.Rows
                                If item.xCodCuenta.Equals(fila("CODCLI")) Then
                                    dblCF += CheckDbl(fila("MONTO_CR"))
                                    dblPromFacturado += CheckDbl(fila("PROM_FAC"))
                                    dblMontoNoFacturado += CheckDbl(fila("MONTO_NO_FAC"))
                                    dblNroBloqueos += CheckDbl(fila("CANTIDAD_BLOQ"))
                                    dblNroSuspensiones += CheckDbl(fila("CANTIDAD_SUSP"))
                                End If
                            Next
                        End If

                        dr("CODIGO_CUENTA") = item.xCodCuenta
                        dr("ESTADO_CUENTA") = IIf(item.xEstadoCuenta.Equals("A"), "Activa", "Inactiva")
                        dr("CUSTOMER_ID") = strCustomerID
                        dr("CENTRAL_RIESGO") = item.xIndCentralRiesgo
                        dr("CF") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblCF, 2))
                        dr("PROMEDIO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblPromFacturado, 2))
                        dr("MONTO_NO_FACTURADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblMontoNoFacturado, 2))
                        dr("MONTO_VENCIDO") = String.Format("{0:#,#,#,0.00}", CheckDbl(item.xDeudaVencida, 2))
                        dr("MONTO_CASTIGADO") = String.Format("{0:#,#,#,0.00}", CheckDbl(item.xDeudaCastigada, 2))
                        dr("DEUDA_REINTEGRO") = String.Format("{0:#,#,#,0.00}", CheckDbl(dblDeudaReintegro, 2))
                        dr("CANTIDAD_SERVICIOS") = item.xCantServicios
                        dr("CANTIDAD_BLOQUEOS") = dblNroBloqueos
                        dr("CANTIDAD_SUSPENDIDOS") = dblNroSuspensiones

                        dtLineaFormatSGA.Rows.Add(dr)

                End Select
            Next
        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " createTableLineasOAC - Error  --> " & ex.Message)
            Throw
        End Try



    End Sub

    Public Function tableDetalle_BSCS(ByVal id As String) As String
        Dim strTableHTML As StringBuilder = New StringBuilder

        strTableHTML.Append("<tr style='display:none' id='" & id & "'>")
        strTableHTML.Append("<td colspan='100%'>")
        strTableHTML.Append("<table align='center' width='85%' cellspacing='0' rules='all' border='1' style='border-collapse:collapse;Z-INDEX: 0'>")

        strTableHTML.Append("<tr class='TablaTitulos' nowrap='nowrap' align='Center'>")
        strTableHTML.Append("<td>Plan / Solucion</td>")
        strTableHTML.Append("<td>Número</td>")
        strTableHTML.Append("<td>Productos / servicios</td>")
        strTableHTML.Append("<td>Cargo Fijo</td>")
        strTableHTML.Append("<td>Fecha Activación</td>")
        strTableHTML.Append("<td>Fecha Estado</td>")
        strTableHTML.Append("<td>Estado</td>")
        strTableHTML.Append("<td>Motivo Bloqueo</td>")
        strTableHTML.Append("<td>Motivo Suspensión</td>")
        strTableHTML.Append("<td>Campaña</td>")
        strTableHTML.Append("</tr>")

        Dim strTableContentID As StringBuilder = New StringBuilder
        Dim oClienteCta As ClienteCuenta = CType(Session("oClienteCuenta" & idNroDocumento), ClienteCuenta)
        Dim strCustomerIdFraude As String = oClienteCta.listaLineasFraude

        If Not IsNothing(dtDetalleBSCS) Then
            For Each dr As DataRow In dtDetalleBSCS.Rows
                If CheckStr(dr("CUENTA")).Equals(id) Then
                    If strCustomerIdFraude.IndexOf("|" & CheckStr(dr("CUSTOMER_ID")) & "|") = -1 Then
                        strTableContentID.Append("<tr class='Arial10B' align='Center'>")
                        strTableContentID.Append("<td>" & CheckStr(dr("PLAN")) & "</td>")
                        Dim numero As String = CheckStr(dr("NUMERO"))
                        If numero.Length > 6 Then
                            numero = "xxxxxx" & numero.Substring(6, numero.Length - 6)
                        Else
                            numero = CheckStr(dr("NUMERO"))
                        End If
                        strTableContentID.Append("<td>" & CheckStr(numero) & "</td>")
                        strTableContentID.Append("<td><div style='word-wrap:break-word;width:160px'>" & CheckStr(dr("PRODUCTO/SERVICIO")) & "</div></td>")
                        strTableContentID.Append("<td>" & String.Format("{0:#,#,#,0.00}", CheckDbl(dr("CF_CONTRATO"), 2)) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("FECHA_ACTIVACION")) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("FECHA_ESTADO")) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("ESTADO")) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("MOT_BLOQ")) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("MOT_SUSP")) & "</td>")
                        strTableContentID.Append("<td>" & CheckStr(dr("CAMPANA")) & "</td>")
                        strTableContentID.Append("</tr>")
                    End If
                End If
            Next
        End If

        strTableHTML.Append(strTableContentID)
        strTableHTML.Append("</table>")
        strTableHTML.Append("<br/>")
        strTableHTML.Append("</td>")
        strTableHTML.Append("</tr>")

        Return strTableHTML.ToString

    End Function

    Public Function tableDetalle_SGA(ByVal id As String) As String
        Dim strTableHTML As StringBuilder = New StringBuilder

        strTableHTML.Append("<tr style='display:none' id='" & id & "'>")
        strTableHTML.Append("<td colspan='100%'>")
        strTableHTML.Append("<table align='center' width='85%' cellspacing='0' rules='all' border='1' style='border-collapse:collapse;Z-INDEX: 0'>")

        strTableHTML.Append("<tr class='TablaTitulos' nowrap='nowrap' align='Center'>")
        strTableHTML.Append("<td>Plan / Solucion</td>")
        strTableHTML.Append("<td>Número</td>")
        strTableHTML.Append("<td>Productos / servicios</td>")
        strTableHTML.Append("<td>Cargo Fijo</td>")
        strTableHTML.Append("<td>Fecha Activación</td>")
        strTableHTML.Append("<td>Fecha Estado</td>")
        strTableHTML.Append("<td>Estado</td>")
        strTableHTML.Append("<td>Motivo Bloqueo</td>")
        strTableHTML.Append("<td>Motivo Suspensión</td>")
        strTableHTML.Append("<td>Campaña</td>")
        strTableHTML.Append("</tr>")

        Dim strTableContentID As StringBuilder = New StringBuilder

        If Not IsNothing(dtDetalleSGA) Then
            For Each dr As DataRow In dtDetalleSGA.Rows
                If CheckStr(dr("CODCLI")).Equals(id) Then
                    strTableContentID.Append("<tr class='Arial10B' align='Center'>")
                    strTableContentID.Append("<td>" & CheckStr(dr("PAQUETE")) & "</td>")
                    strTableContentID.Append("<td>&nbsp;</td>")
                    strTableContentID.Append("<td><div style='word-wrap:break-word;width:160px'>" & CheckStr(dr("SERVICIO")) & "</div></td>")
                    strTableContentID.Append("<td>" & String.Format("{0:#,#,#,0.00}", CheckDbl(dr("MONTO_CR"), 2)) & "</td>")
                    strTableContentID.Append("<td>" & CheckStr(dr("FECHA_ACTIVACION")) & "</td>")
                    strTableContentID.Append("<td>" & CheckStr(dr("FECHA_ACTIVACION")) & "</td>")
                    strTableContentID.Append("<td>" & CheckStr(dr("ESTADO")).ToLower & "</td>")
                    strTableContentID.Append("<td>" & "" & "</td>")
                    strTableContentID.Append("<td>" & "" & "</td>")
                    strTableContentID.Append("<td>" & CheckStr("") & "</td>")
                    strTableContentID.Append("</tr>")
                End If
            Next
        End If

        strTableHTML.Append(strTableContentID)
        strTableHTML.Append("</table>")
        strTableHTML.Append("<br/>")
        strTableHTML.Append("</td>")
        strTableHTML.Append("</tr>")

        Return strTableHTML.ToString

    End Function

    Private Sub dgdListaBSCS_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdListaBSCS.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim hidCodCuentaBSCS As HtmlInputHidden = DirectCast(e.Item.FindControl("hidCodCuentaBSCS"), HtmlInputHidden)
            Dim btnMostrarDetalleBSCS As HtmlImage = DirectCast(e.Item.FindControl("btnMostrarDetalleBSCS"), HtmlImage)

            If Not blnTipoDocumentoRUC Then
                btnMostrarDetalleBSCS.Attributes.Add("onclick", "f_mostrarDetalle('" & hidCodCuentaBSCS.Value & "')")
                e.Item.Cells(14).Text = tableDetalle_BSCS(hidCodCuentaBSCS.Value)
            Else
                btnMostrarDetalleBSCS.Visible = False
            End If
        End If
    End Sub

    Private Sub dgdListaSGA_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdListaSGA.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim hidCodCuentaSGA As HtmlInputHidden = DirectCast(e.Item.FindControl("hidCodCuentaSGA"), HtmlInputHidden)
            Dim btnMostrarDetalleSGA As HtmlImage = DirectCast(e.Item.FindControl("btnMostrarDetalleSGA"), HtmlImage)

            If Not blnTipoDocumentoRUC Then
                btnMostrarDetalleSGA.Attributes.Add("onclick", "f_mostrarDetalle('" & hidCodCuentaSGA.Value & "')")
                e.Item.Cells(14).Text = tableDetalle_SGA(hidCodCuentaSGA.Value)
            Else
                btnMostrarDetalleSGA.Visible = False
            End If
        End If
    End Sub

    Private Sub estructuraTable(ByRef dtBase As DataTable)
        dtBase.Columns.Add(New DataColumn("CODIGO_CUENTA", GetType(String)))
        dtBase.Columns.Add(New DataColumn("ESTADO_CUENTA", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CUSTOMER_ID", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CENTRAL_RIESGO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CF", GetType(String)))
        dtBase.Columns.Add(New DataColumn("PROMEDIO_FACTURADO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("MONTO_NO_FACTURADO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("MONTO_VENCIDO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("MONTO_CASTIGADO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("DEUDA_REINTEGRO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CANTIDAD_SERVICIOS", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CANTIDAD_BLOQUEOS", GetType(String)))
        dtBase.Columns.Add(New DataColumn("CANTIDAD_SUSPENDIDOS", GetType(String)))
    End Sub

    Private Function DatosPlan(ByVal nroLinea As String) As Boolean
        Dim datosLinea As ClienteBSCS = Nothing
        Try

        Dim oPostpagoNegocios As New DatosPostpagoNegocios
        Dim mensajeError As String = String.Empty

        Dim codPlan As String = String.Empty
        Dim desPlan As String = String.Empty
        datosLinea = oPostpagoNegocios.LeerDatosCliente(nroLinea, "", mensajeError)
        Dim dsListaServicios As DataSet = (New ChipRepuestoPostpagoNegocio).ListaServicios(datosLinea.Co_id, codPlan, desPlan)

        Me.hidplancomercial.Value = desPlan
        oLog.Log_WriteLog(strArchivo, idNroDocumento & " - Plan Comercial: " & Me.hidplancomercial.Value)

        If Me.hidplancomercial.Value.ToUpper = ConfigurationSettings.AppSettings("consTextoNoAplica") Then
            Me.hidplancomercial.Value = String.Empty
                End If

        Catch ex As Exception
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " datosLinea.Co_id --> " & Funciones.CheckStr(datosLinea.Co_id))
            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " Error en BSCS --> " & ex.Message)
        End Try

        Return True

    End Function

    Private Function ObtenerDatosVenta(ByVal NroDocSap As String, _
                                        ByVal PuntoVenta As String, ByVal NroContrato As String) As Boolean
        'ByRef arrayPedido As ArrayList, _
        '                                ByRef arrayMaterial As ArrayList, _
        '                                ByRef arrayOrden As ArrayList

        Dim oConsultaSap As New SapGeneralNegocios
        Dim dsPedido As New DataSet
        Dim dtCabecera As New DataTable
        Dim dtDetalle As New DataTable
        Dim blnFound As Boolean = False
        Dim idx As Integer = 0
        Dim strKey As String = PuntoVenta & "|" & NroDocSap

        Try
            'Consulta Datos Pedido Sap
            'dsPedido = oConsultaSap.Get_ConsultaPedido("", PuntoVenta, NroDocSap, "")
            dsPedido = oConsultaSap.ConsultarAcuerdo(NroContrato, String.Empty)


            If IsNothing(dsPedido) OrElse dsPedido.Tables.Count = 0 Then
                Throw New Exception("No se encontro Registros Consulta Pedido Sap.")
            Else
                '0.Estructuras Tablas Detalle Pedido Sap
                dtCabecera = CType(dsPedido.Tables(0), DataTable)
                dtDetalle = CType(dsPedido.Tables(1), DataTable)

                If dtCabecera.Rows.Count = 0 Or dtDetalle.Rows.Count = 0 Then
                    Throw New Exception("No se encontro Registros Detalle Pedido Sap.")
                Else
                    Me.hidplancomercial.Value = CheckStr(dtDetalle.Rows(0)("DES_PTARIFARIO"))
                    oLog.Log_WriteLog(strArchivo, idNroDocumento & " - Plan Comercial: " & Me.hidplancomercial.Value)
                End If

                oLog.Log_WriteLog(strArchivo, idNroDocumento & " - Plan Comercial: " & Me.hidplancomercial.Value)

                If Me.hidplancomercial.Value.ToUpper = ConfigurationSettings.AppSettings("consTextoNoAplica") Then
                    Me.hidplancomercial.Value = String.Empty
                End If
            End If

            blnFound = True

        Catch ex As Exception
            blnFound = False
        Finally
            oConsultaSap = Nothing
            dsPedido = Nothing
            dtCabecera = Nothing
            dtDetalle = Nothing
        End Try

        Return blnFound
    End Function

    Private Function DatosServiciosxtelefono(ByVal dtdatoslinea As DataTable, ByVal dblGeneralCF As Double) As Boolean
        Dim resp As Boolean = True
        ' Dim arrservicio() As String
        'Dim servicios As String
        Try

            oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "hidnrolinea: " & CheckStr(Me.hidnrolinea.Value)) ' INC000000968945

            For Each dr As DataRow In dtdatoslinea.Rows
                If CheckStr(dr("NUMERO")) = CheckStr(Me.hidnrolinea.Value) Then

                    If CheckStr(dr("ESTADO")) = "Activo"  Then   '' INC000000968945 posible cambio de falla
                    ' arrservicio = CheckStr(dr("PRODUCTO/SERVICIO")).Split("+")
                    Me.hidcargofijo.Value = String.Format("{0:#,#,#,0.00}", CheckDbl(dr("CF_CONTRATO")))
                    Me.hidservicios.Value = CheckStr(dr("PRODUCTO/SERVICIO"))
                    End If ''FIN INC000000968945

                End If
            Next

            oLog.Log_WriteLog(strArchivo, CheckStr(hidnrolinea.Value) & " - " & "hidcargofijo Inicio: " & CheckStr(Me.hidcargofijo.Value)) ' INC000000968945
            oLog.Log_WriteLog(strArchivo, CheckStr(hidnrolinea.Value) & " - " & "hidservicios: " & CheckStr(Me.hidservicios.Value)) ' INC000000968945
            oLog.Log_WriteLog(strArchivo, CheckStr(hidnrolinea.Value) & " - " & "dblGeneralCF: " & CheckStr(dblGeneralCF))  ' INC000000968945

            If hidcargofijo.Value = String.Empty Or hidcargofijo.Value = "0" Then
                hidcargofijo.Value = String.Format("{0:#,#,#,0.00}", dblGeneralCF)
            End If


            oLog.Log_WriteLog(strArchivo, CheckStr(hidnrolinea.Value) & " - " & "hidcargofijo Final: " & CheckStr(Me.hidcargofijo.Value)) ' INC000000968945

        Catch ex As Exception
            resp = False
            Throw

        Finally


        End Try
        Return resp
    End Function

    Private Function ValidarDeudaFraude(ByVal strNroDoc As String, ByVal strTipoDoc As Integer, ByVal dtDetalleLinea As DataTable, _
                                            ByRef dblDeudaVencida As Double, ByRef dblDeudaCastigada As Double, ByRef strCustomerIdFraude As String) As Boolean
        Dim dblDeudaFraude As Double = 0.0
        Dim blnBloqueoFraude As Boolean = False

        'Líneas por Fraude F02/F03
        Dim strBloqueosFraude As String = ConfigurationSettings.AppSettings("ConstCodBloqueoFraude")
        Dim arrDeudaLDIFraude As ArrayList = (New ClienteCons_Negocio).BuscarClienteDeudaBloqueo("1", strNroDoc, strTipoDoc)
        For Each item As Cliente_Cons In CType(arrDeudaLDIFraude(0), ArrayList)
            If item.TIPO_ESTADO <> "" And strBloqueosFraude.IndexOf(UCase(item.TIPO_ESTADO)) >= 0 Then
                blnBloqueoFraude = True
                If strCustomerIdFraude.IndexOf(CheckStr(item.NRO_CUENTA)) = -1 Then
                    strCustomerIdFraude &= "|" & CheckStr(item.NRO_CUENTA) & "|"
                End If
            End If
        Next

        If blnBloqueoFraude Then
            Dim arrCustomerId As String() = strCustomerIdFraude.Split("|"c)
            For Each cuentaId As String In arrCustomerId
                If Not cuentaId = "" Then
                    For Each dr As DataRow In dtDetalleLinea.Rows
                        If CheckStr(dr("CUSTOMER_ID")) = cuentaId Then
                            dblDeudaVencida += CheckDbl(dr("MONTO_VENCIDO"))
                            dblDeudaCastigada += CheckDbl(dr("MONTO_CASTIGO"))
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        Return blnBloqueoFraude
    End Function

    Private Sub ObtenerFacturacionxProducto(ByVal _oMontoCuentaCliente As ArrayList, ByRef oClienteCta As ClienteCuenta)
        Dim strMontoFacturado As String = String.Empty
        Dim strMontoNoFacturado As String = String.Empty
        Dim oReglaNegocio As New ReglasEvaluacionNegocio

        For Each item As PlanBilletera In _oMontoCuentaCliente
            If item.MontoFacturado > 0 Then
                strMontoFacturado = String.Format("{0}|{1};{2}", strMontoFacturado, item.CodigoBilletera, item.MontoFacturado)
            End If
            If item.MontoNoFacturado > 0 Then
                strMontoNoFacturado = String.Format("{0}|{1};{2}", strMontoNoFacturado, item.CodigoBilletera, item.MontoNoFacturado)
            End If
        Next

        oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "strMontoFacturado: " & strMontoFacturado)
        oLog.Log_WriteLog(strArchivo, hidNroDoc.Value & " - " & "strMontoNoFacturado: " & strMontoNoFacturado)

        'Calcular Promedio Facturado x Producto
        Dim _oMontoFacturadoxProducto As ArrayList = oReglaNegocio.ObtenerFactxProducto(strMontoFacturado)
        'Calcular Monto NO Facturado x Producto
        Dim _oMontoNoFacturadoxProducto As ArrayList = oReglaNegocio.ObtenerFactxProducto(strMontoNoFacturado)

        oClienteCta.FacturaxProducto = _oMontoFacturadoxProducto
        oClienteCta.NoFacturaxProducto = _oMontoNoFacturadoxProducto
    End Sub

    Public Function ObtenerNroPlanesxProductoBSCS(ByVal dtDetalle As DataTable, ByRef strPlanActivoVozDatos As String) As ArrayList
        Dim array As New ArrayList
        Dim oBilletera As New PlanBilletera
        Dim strTipoPlan As String = String.Empty
        Dim strCantidad As Integer
        For Each dr As DataRow In dtDetalle.Rows
            oBilletera = New PlanBilletera
            oBilletera.Plan = CheckStr(dr("TMCODE"))
            oBilletera.NroPlanesMovil = CheckInt(dr("NRO_MOVIL"))
            oBilletera.NroPlanesInternet = CheckInt(dr("NRO_INTERNET_FIJO"))
            oBilletera.NroPlanesClaroTV = CheckInt(dr("NRO_CLARO_TV"))
            oBilletera.NroPlanesTelefonia = CheckInt(dr("NRO_TELEF_FIJA"))
            oBilletera.NroPlanesBAM = CheckInt(dr("NRO_BAM"))
            array.Add(oBilletera)

            If oBilletera.NroPlanesBAM > 0 Then
                strCantidad = oBilletera.NroPlanesBAM
                strTipoPlan = "2"
            Else
                strCantidad = oBilletera.NroPlanesMovil
                strTipoPlan = "1"
            End If

            strPlanActivoVozDatos = String.Format("{0}|{1};{2};{3}", strPlanActivoVozDatos, oBilletera.Plan, strTipoPlan, strCantidad)
        Next

        Return array
    End Function

#End Region

    Private Sub consultarLineasAbonado()


        detalle_linea_header.Visible = True
        detalle_linea_body.Visible = True
        dgListaLineas.Visible = False

        Dim strTipoDocumento As String = Trim(hidTipoDoc.Value)
        Dim strNroDoc As String = Trim(hidNroDoc.Value)

        Dim dtTable As New DataTable

        If strTipoDocumento = ConfigurationSettings.AppSettings("TipoDocumentoDNIDefecto") And ConfigurationSettings.AppSettings("consultarListaLineasVenta") = "1" Then
            oLog.Log_WriteLog(strArchivo, "====Consultar Lineas Abonado====")

            oLog.Log_WriteLog(strArchivo, "Parametros LineasAbonado:")
            oLog.Log_WriteLog(strArchivo, " ->strTipoDocumento: " & strTipoDocumento)
            oLog.Log_WriteLog(strArchivo, " ->strNroDoc: " & strNroDoc)


            Dim oBLConsultaDWH As ConsultaDWHNegocio = New ConsultaDWHNegocio

            Dim oBLConsultaSIAC As ConsultaSIACNegocios = New ConsultaSIACNegocios

            Dim listado As ArrayList = oBLConsultaDWH.LineasAbonado(ConfigurationSettings.AppSettings("TipoDocuIdentidad"), strNroDoc)

            Dim total As Integer = listado.Count

            oLog.Log_WriteLog(strArchivo, " RESULTADO => " & total)

            oLog.Log_WriteLog(strArchivo, "========================")

            Dim validaBloqueo As String = String.Empty
            Dim aBloqueo As String()

            Dim bBloqueo As Boolean = False
            Dim bTipoBloqueo As Boolean = False

            Dim sTipoBloqueo As String = String.Empty
            Dim numero_telefono As String = String.Empty


            oLog.Log_WriteLog(strArchivo, "Parametros Web.config:")

            Dim sMsgErrorNoDisponibles As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("consErrorLineasNoDisponibles"))
            Dim sMsgSuccessDisponibles As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("consSuccessLineasDisponibles"))

            oLog.Log_WriteLog(strArchivo, " sMsgErrorNoDisponibles:" & sMsgErrorNoDisponibles)
            oLog.Log_WriteLog(strArchivo, " sMsgSuccessDisponibles:" & sMsgSuccessDisponibles)

            Dim sListaLineaTipoBloqueo As String = Funciones.CheckStr(ConfigurationSettings.AppSettings("ListaLineaTipoBloqueo"))

            oLog.Log_WriteLog(strArchivo, " sListaLineaTipoBloqueo:" & sListaLineaTipoBloqueo)

            Dim aMaxRegistros As Integer = Funciones.CheckInt(ConfigurationSettings.AppSettings("consMaxListaLineasCliente"))

            oLog.Log_WriteLog(strArchivo, " aMaxRegistros:" & aMaxRegistros)

            Dim maskNumeroDigitos As Integer = Funciones.CheckInt(ConfigurationSettings.AppSettings("consMaskNumeroDigitosListaLinea"))

            oLog.Log_WriteLog(strArchivo, " maskNumeroDigitos:" & maskNumeroDigitos)

            Dim aTipoBloqueos As String() = sListaLineaTipoBloqueo.Split(Char.Parse(","))

            Dim sMaskNumeroTelefono As String = String.Empty


            Dim oRow As DataRow
            Dim c As DataColumn

            c = New DataColumn
            c.ColumnName = "LINEA_PREPAGO"
            dtTable.Columns.Add(c)

            c = New DataColumn
            c.ColumnName = "PLAN"
            dtTable.Columns.Add(c)

            c = New DataColumn
            c.ColumnName = "ESTADO"
            dtTable.Columns.Add(c)

            c = New DataColumn
            c.ColumnName = "TIPO_BLOQUEO"
            dtTable.Columns.Add(c)

            oLog.Log_WriteLog(strArchivo, "========================")

            'End columns
            Try

                oLog.Log_WriteLog(strArchivo, "INICIO DE CONSULTA POR LINEA")

                For Each oItem As LineaAbonado In listado

                    oLog.Log_WriteLog(strArchivo, " Nro Telefono:" & oItem.Nro_telefono)

                    If Not oItem.Nro_telefono = "" And dtTable.Rows.Count < aMaxRegistros Then

                        numero_telefono = ""
                        bBloqueo = False
                        bTipoBloqueo = False

                        If oItem.Nro_telefono.Length > 2 Then

                            numero_telefono = oItem.Nro_telefono.Substring(2, oItem.Nro_telefono.Length - 2)

                            oLog.Log_WriteLog(strArchivo, " Valida Bloqueo Linea ")
                            oLog.Log_WriteLog(strArchivo, " ->numero_telefono:" & numero_telefono)


                            validaBloqueo = oBLConsultaSIAC.ValidaBloqueoLinea(numero_telefono)

                            oLog.Log_WriteLog(strArchivo, " Resultado:" & validaBloqueo)


                            aBloqueo = validaBloqueo.Split(Char.Parse("|"))

                            If aBloqueo.Length = 3 Then

                                If aBloqueo(1) = "BLOQUEADO" Or aBloqueo(1) = "DESBLOQUEADO" Or aBloqueo(1) = "" Then
                                    bBloqueo = True
                                End If

                                If aBloqueo(1) = "DESBLOQUEADO" Then
                                    bTipoBloqueo = True
                                Else
                                    If Array.IndexOf(aTipoBloqueos, aBloqueo(0)) >= 0 Then
                                        bTipoBloqueo = True
                                    End If
                                End If

                            ElseIf aBloqueo(0) Is "" Then
                                bBloqueo = True
                                bTipoBloqueo = True

                                sTipoBloqueo = "DESBLOQUEADO"
                            End If


                            'AGREGAR
                            If bBloqueo And bTipoBloqueo Then

                                oLog.Log_WriteLog(strArchivo, "========================")
                                oLog.Log_WriteLog(strArchivo, " Linea Valida para mostrar ")

                                If aBloqueo.Length = 3 Then
                                    If aBloqueo(1) = "DESBLOQUEADO" Or aBloqueo(1) = "" Then
                                        sTipoBloqueo = "DESBLOQUEADO"
                                    Else
                                        Select Case aBloqueo(0)
                                            Case "BLOQ_ROB"
                                                sTipoBloqueo = "ROBO"
                                            Case "BLOQ_PER"
                                                sTipoBloqueo = "PERDIDA"
                                            Case "BLOQ_HUR"
                                                sTipoBloqueo = "PERDIDA"
                                            Case Else
                                                sTipoBloqueo = "BLOQUEADO"
                                        End Select
                                    End If
                                End If

                                sMaskNumeroTelefono = numero_telefono.Substring(0, numero_telefono.Length - maskNumeroDigitos) + "".PadRight(maskNumeroDigitos, Char.Parse("*"))


                                oLog.Log_WriteLog(strArchivo, " ->sMaskNumeroTelefono:" & sMaskNumeroTelefono)
                                oLog.Log_WriteLog(strArchivo, " ->Segmento:" & oItem.Segmento)
                                oLog.Log_WriteLog(strArchivo, " ->Estado:" & oItem.Estado)
                                oLog.Log_WriteLog(strArchivo, " ->sTipoBloqueo:" & sTipoBloqueo)

                                oRow = dtTable.NewRow
                                oRow.Item("LINEA_PREPAGO") = sMaskNumeroTelefono
                                oRow.Item("PLAN") = oItem.Segmento
                                oRow.Item("ESTADO") = oItem.Estado
                                oRow.Item("TIPO_BLOQUEO") = sTipoBloqueo
                                dtTable.Rows.Add(oRow)

                            End If
                        End If
                    End If
                Next

                If Not dtTable.Rows.Count = 0 Then
                    dgListaLineas.Visible = True
                End If

            Catch ex As Exception
                oLog.Log_WriteLog(strArchivo, " FATAL ERROR: " & ex.Message)
            End Try
        Else
            detalle_linea_header.Visible = False
            detalle_linea_body.Visible = False
        End If




        dgListaLineas.DataSource = dtTable
        dgListaLineas.DataBind()

    End Sub

    'Inicio Renovacion Por Bloqueo JAZ
    Private Function EsCanalPermitido(ByVal sCanalActual As String, ByVal sCanalesPermitidos() As String) As Boolean

        For i As Integer = 0 To sCanalesPermitidos.Length - 1
            If sCanalesPermitidos(i) = sCanalActual Then
                Return True
            End If
        Next

        Return False

    End Function
    'Fin Renovacion Por Bloqueo JAZ
End Class
