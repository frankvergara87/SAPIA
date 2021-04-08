Option Strict Off
Imports Claro.SisAct.Entidades
Imports Claro.SisAct.Common.Funciones
Imports Claro.SisAct.Common
Imports Claro.SisAct.Negocios
Imports Claro.SisAct.Web.Funciones
Imports Claro.SisAct.Web.Funciones.LoginUsuario
Imports System.Text.RegularExpressions
Imports System.Text

Public Class sisact_ifr_condiciones_venta
    Inherits SisAct_WebBase

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblIdLista As System.Web.UI.WebControls.Label
    Protected WithEvents tblCuotas As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents hidPlazoActual As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValidarGuardarCuota As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlazos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents tblServicios As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents hidPerfil As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents tblPuntosCC As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents hidTipoDocumentos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblClaroClubMsgError As System.Web.UI.WebControls.Label
    Protected WithEvents hidMinimoSoles As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidOtrosSaldos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dgSaldosCC As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtClaroClubCampana As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidClaroClubPuntosPostpago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtClaroClubSaldoActual As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidSaldoActualWS As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidClaroClubPuntosUtilizar As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtClaroClubSolesDeDescuento As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidClaroClubSolesDeDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidValorPuntosPostpago As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblClaroClubCampana As System.Web.UI.WebControls.Label
    Protected WithEvents lblClaroClubSaldoActual As System.Web.UI.WebControls.Label
    Protected WithEvents lblClaroClubPuntosUtilizar As System.Web.UI.WebControls.Label
    Protected WithEvents lblClaroClubSolesDeDescuento As System.Web.UI.WebControls.Label
    Protected WithEvents hidIDCAMPANA As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidFactorClaroClub As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTieneReserva As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCCMinimoPuntos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorCCPuntosMinimos As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorClaroClub As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidErrorClaroClubDesfase As System.Web.UI.HtmlControls.HtmlInputHidden

    Protected WithEvents hidTipoCanal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtFechaDesde As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFechaDesde As System.Web.UI.WebControls.ImageButton
    Protected WithEvents txtFechaHasta As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFechaHasta As System.Web.UI.WebControls.ImageButton
    Protected WithEvents tblRoamingI As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents hidTienePortabilidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtFechaIniCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFechaFinCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSegmentoCC As System.Web.UI.WebControls.TextBox
    Protected WithEvents hidDetalleDescuento As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidTipModalidad As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidListaPreciosEquipo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidCargoFijoSeleccionado As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidMantenerPlan As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hidPlanNuevo As System.Web.UI.HtmlControls.HtmlInputHidden

    ''PROY-24724-IDEA-28174 - Parametros - INI
    Protected WithEvents hidCodServProteccionMovil As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents hidCanalesPermitidosPrimaSeguros As System.Web.UI.HtmlControls.HtmlInputText
    ''PROY-24724-IDEA-28174 - Parametros - FIN
    Protected WithEvents hidcampanaactual As System.Web.UI.HtmlControls.HtmlInputHidden'PROY-32129

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region


#Region "Constantes"
    Dim objLog As New SISACT_Log
    Dim strFlujoAlta As String = ConfigurationSettings.AppSettings("flujoAlta")
    Dim strFlujoPortabilidad As String = ConfigurationSettings.AppSettings("flujoPortabilidad")
    Dim constTipoProductoCON As String = ConfigurationSettings.AppSettings("constTipoProductoCON")
    Dim constTipoProductoBUS As String = ConfigurationSettings.AppSettings("constTipoProductoBUS")
    Dim constTipoProductoB2E As String = ConfigurationSettings.AppSettings("constCodTipoProductoB2E")
    Dim constSegmentoCON As String = ConfigurationSettings.AppSettings("constSegmentoCON")
    Dim constSegmentoECA As String = ConfigurationSettings.AppSettings("constSegmentoECA")
    Dim constDesResultadoFinalAPR As String = ConfigurationSettings.AppSettings("constDesResultadoFinalAPR")
    Dim constEstadoAPRENVACT As String = ConfigurationSettings.AppSettings("constEstadoAprobadoEnvActiva")
    Dim constDesEstadoAPRENVACT As String = ConfigurationSettings.AppSettings("constDesEstadoAprobadoEnvActiva")
    Dim constEstadoEnvCreditos As String = ConfigurationSettings.AppSettings("constEstadoEnvCreditos")
    Dim constDesEstadoEnvCreditos As String = ConfigurationSettings.AppSettings("constDesEstadoEnvCreditos")
    Dim constEstadoPENDADJARCH As String = ConfigurationSettings.AppSettings("constcodEstadoSECPENDADJARCHIVOS")
    Dim constDesEstadoPENDADJARCH As String = ConfigurationSettings.AppSettings("constdesEstadoSECPENDADJARCHIVOS")
    Dim constEstadoENVPOOLEMIT As String = ConfigurationSettings.AppSettings("constEstadoENVPOOLEMIT")
    Dim constCodCodCanalDefectoMT As String = ConfigurationSettings.AppSettings("constCodCodCanalDefectoMT")
    Dim constCodEvaluadorPDV As String = ConfigurationSettings.AppSettings("constCodEvaluadorPDV")
    Dim constCodEvaluadorCET As String = ConfigurationSettings.AppSettings("constCodEvaluadorCET")
    Dim constDesEstadoENVPOOLEMIT As String = ConfigurationSettings.AppSettings("constDesEstadoENVPOOLEMIT")
    Dim constVentaRegistrado As String = ConfigurationSettings.AppSettings("constVentaRegistrado")
    Dim constVentaAprobado As String = ConfigurationSettings.AppSettings("constVentaAprobado")
    Dim constEstadoAPR As String = ConfigurationSettings.AppSettings("constEstadoAPR")
    Dim dblIGV As Double = ConfigurationSettings.AppSettings("TasaIGV")
#End Region

    Dim oLog As New SISACT_Log
    Dim oFile As String = oLog.Log_CrearNombreArchivo("sisact_ifr_condiciones_venta")
    Dim strIdentifyLog As String = ""
    Dim NroLinea As String = ""
    Dim TipoDocumento As String = ""
    Dim NumeroDoc As String = ""
    Dim strCanal As String = String.Empty
    Dim strPlanNoVigente As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Anthem.Manager.Register(Me) 'PROY-32129

        If Not Page.IsPostBack Then
            Try

                'PROY-24724-IDEA-28174 - Parametros INI 
                hidCodServProteccionMovil.Value = ClsKeyAPP.strCodServProteccionMovil
                hidCanalesPermitidosPrimaSeguros.Value = ClsKeyAPP.strCanalesPermitidosProtMovil
                'PROY-24724-IDEA-28174 - Parametros FIN

                strCanal = Request.QueryString("TipCanal")
                hidTipoCanal.Value = strCanal
                hidTipModalidad.Value = Request.QueryString("TipModalidad")
                strPlanNoVigente = Request.QueryString("PlanNoVigente")

                EnlazarScript()
                LlenarHiddenTipoDocumento()
                CargarHiddenClaroClub()

                TipoDocumento = Request.QueryString("TipDoc")
                NumeroDoc = Request.QueryString("NumDoc")
                NroLinea = Request.QueryString("NroLinea")
                'INICIO PROY -31008
                Session("NumeroLineaTope") = Request.QueryString("NroLinea")
                'FIN PROY-31008

                'gaa20160607
                Dim strB2E As String = ConfigurationSettings.AppSettings("strPostTipClienteB2E")
                Dim datosLinea As ClienteBSCS = Session("Cliente")
                'If Not IsNothing(TipoDocumento) And Not IsNothing(NumeroDoc) And Not IsNothing(NroLinea) Then
                If Not IsNothing(TipoDocumento) And Not IsNothing(NumeroDoc) And Not IsNothing(NroLinea) AndAlso UCase(datosLinea.Tipo_cliente) <> UCase(strB2E) Then
                    CargarDatosDePuntoClaroClub(TipoDocumento, NumeroDoc, NroLinea)
                End If
            Catch ex As Exception
                oLog.Log_WriteLog(oFile, " - " & "ERROR(): " & ex.StackTrace.ToString())
            End Try
        End If
    End Sub

    Private Sub CargarHiddenClaroClub()
        hidErrorClaroClubDesfase.Value = ConfigurationSettings.AppSettings("constErrorClaroClubDesfase")
        hidErrorClaroClub.Value = ConfigurationSettings.AppSettings("constErrorClaroClub")
        hidErrorCCPuntosMinimos.Value = (ConfigurationSettings.AppSettings("constErrorCCPuntosMinimos").Replace("{0}", ConfigurationSettings.AppSettings("constMinimoCC")))
        hidCCMinimoPuntos.Value = ConfigurationSettings.AppSettings("constMinimoCC")
    End Sub

    Private Sub EnlazarScript()
        Dim sb As New System.Text.StringBuilder

        sb.Append("var tipoProductoBussiness = '" & Claro.SisAct.Web.Funciones.K_TipoProductoBussinees & "';")
        'gaa20150504
        'sb.Append("var columnaPaquete = 3;")
        sb.Append("var columnaPaquete = 4;")
        'fin gaa20150504
        sb.Append("var columnaPortabilidad = 12;")
        sb.Append("var columnaEquipo = 9;")
        sb.Append("var columnaEquipoPrecio = 11;")
        sb.Append("var columnaCuota = 10;")
        'gaa20161107

        sb.Append("var familiaFlag = '" & ConfigurationSettings.AppSettings("FamiliaPlanFlag") & "';")
        sb.Append("var familiaOferta = '" & ConfigurationSettings.AppSettings("FamiliaPlanOferta") & "';")
        sb.Append("var strOferta = parent.getValue('hidTipoOferta');")
        'sb.Append("alert(strOferta);")
        'fin gaa20161020
        sb.Append(String.Format("var flujoAlta = '{0}';", strFlujoAlta))
        sb.Append(String.Format("var flujoPortabilidad = '{0}';", strFlujoPortabilidad))

        sb.Append("var topeConsumoAuto = " & ConfigurationSettings.AppSettings("constCodTopeAutomaticoServicio") & ";")
        sb.Append("var topeConsumoCero = " & ConfigurationSettings.AppSettings("constCodTopeCeroServicio") & ";")
        sb.Append("var topeConsumoSinCF = " & ConfigurationSettings.AppSettings("constCodTopeSinCFServicio") & ";")
        sb.Append("var codTipoOficinaCAC = " & ConfigurationSettings.AppSettings("constCodTipoOficinaCAC") & ";")

        sb.Append("var codTipoProdMovil = '" & ConfigurationSettings.AppSettings("constTipoProductoMovil") & "';")
        sb.Append("var codTipoProdFijo = '" & ConfigurationSettings.AppSettings("constTipoProductoFijo") & "';")
        sb.Append("var codTipoProdBAM = '" & ConfigurationSettings.AppSettings("constTipoProductoBAM") & "';")
        sb.Append("var codTipoProdDTH = '" & ConfigurationSettings.AppSettings("CodTipoProductoDTH") & "';")
        sb.Append("var codTipoProd3Play = '" & ConfigurationSettings.AppSettings("CodTipoProductoHFC") & "';")

        sb.Append("var modalidadPagoEnCuota = '" & ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota") & "';")

        sb.Append("function agregarFila(booVeriConf)")
        sb.Append("{")
        sb.Append("  var totalFilas = document.getElementById('tblTablaMovil').rows.length;")
        sb.Append("  var hidValidarGuardarCuota = document.getElementById('hidValidarGuardarCuota');")
        sb.Append("  if (totalFilas == 0) hidValidarGuardarCuota.value = '';")

        sb.Append("  if (hidValidarGuardarCuota.value.length > 0)")
        sb.Append("  {")
        sb.Append("     alert('Debe guardar las cuotas antes de ejecutar esta acción');")
        sb.Append("     return;")
        sb.Append("  }")
        sb.Append("  if (!validarBusqueda())")
        sb.Append("    return;")

        sb.Append("  if (booVeriConf)")
        sb.Append("  {")
        sb.Append("    if (!verificarPlanes()) return false;")
        sb.Append("  }")

        sb.Append("  var strPlazoActual = document.getElementById('hidPlazoActual').value;")
        sb.Append("  var strTienePaquete = document.getElementById('hidTienePaquete').value;")
        sb.Append("  var strTienePortab = parent.document.getElementById('hidTienePortabilidad').value;")
        sb.Append("  var hidTraerPlazo = document.getElementById('hidTraerPlazo');")
        sb.Append("  var hidConfirmaCuota = document.getElementById('hidConfirmaCuota');")
        sb.Append("  var hidPaqueteActual = document.getElementById('hidPaqueteActual');")
        sb.Append("  var hidTotalLineas = document.getElementById('hidTotalLineas');")
        sb.Append("  hidTotalLineas.value = parseInt(hidTotalLineas.value) + 1;")
        sb.Append("  var idFila = hidTotalLineas.value;")
        sb.Append("  var desTipoProductoActual = getValue('hidTipoProductoActual');")
        sb.Append("  var newRow = document.all('tblTabla' + desTipoProductoActual).insertRow();")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '20px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgEditarFila" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgEditarFila" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/editar.gif' border='0' style='cursor:hand' alt='Editar Fila' onclick='editarFila(" & Chr(34) & " + idFila + " & Chr(34) & ", false);' />" & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '20px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgEliminarFila" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgEliminarFila" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/rechazar.gif' border='0' style='cursor:hand' alt='Eliminar Fila' onclick='eliminarFilaTotal(this, " & Chr(34) & " + idFila + " & Chr(34) & ", true);' />" & Chr(34) & ";")

        'gaa20150504
        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '182px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarCampana(" & Chr(34) & " + idFila + " & Chr(34) & ", this.value);'><option value=''>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")
        'fin gaa20150504

        sb.Append("  if (desTipoProductoActual != 'DTH')")
        sb.Append("  {")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '145px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPlazo" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPlazo" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPlazo(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")

        sb.Append("    if (desTipoProductoActual == 'HFC')")
        sb.Append("    {")
        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '282px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlSolucion" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlSolucion" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarSolucion(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")
        sb.Append("    }")

        sb.Append("    if (strTienePaquete == 'S' && desTipoProductoActual == 'Movil')")
        sb.Append("    {")
        sb.Append("var oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '202px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPaquete" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPaquete" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPaquete(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")
        sb.Append("    }")
        'gaa20161107: Si es masivo y movil
        sb.Append("    if (strTienePaquete != 'S' && desTipoProductoActual == 'Movil' && familiaFlag == '1' && strOferta == familiaOferta)")
        sb.Append("    {")
        sb.Append("     oCell = newRow.insertCell();")
        sb.Append("     oCell.style.width = '152px';")
        sb.Append("     oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlFamiliaPlan" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlFamiliaPlan" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarFamiliaPlan(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'>")
        sb.Append("</select>" & Chr(34) & ";")
        sb.Append("    }")
        'fin gaa20161020
        sb.Append("    if (desTipoProductoActual == 'HFC')")
        sb.Append("    {")
        sb.Append("var oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '312px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPaquete" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPaquete" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPaquete(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")
        sb.Append("    }")


        sb.Append("var oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '152px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPlan" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPlan" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPlan(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")



        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '30px';")
        sb.Append("oCell.align = 'center';")
        'sb.Append("oCell.innerHTML = " & Chr(34) & "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicio(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgServicios" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgServicios" & Chr(34) & " + idFila + " & Chr(34) & "' src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicio(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '45px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFPlanServicio" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtCFPlanServicio" & Chr(34) & " + idFila + " & Chr(34) & "' />")

        sb.Append("<input type='hidden' id='hidMontoServicios" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidMontoServicios" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append("<input type='hidden' id='hidMontoCuota" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidMontoCuota" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append(Chr(34) & ";")

        sb.Append("    if (desTipoProductoActual != 'HFC')")
        sb.Append("    {")

        sb.Append("    if (desTipoProductoActual == 'Movil')")
        sb.Append("    {")
        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '52px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtMontoTopeConsumo" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtMontoTopeConsumo" & Chr(34) & " + idFila + " & Chr(34) & "' />" & Chr(34) & ";")
        sb.Append("      }")


        If (hidTipoCanal.Value <> ConfigurationSettings.AppSettings("constCodTipoOficinaCorner")) Then
            sb.Append("oCell = newRow.insertCell();")
            sb.Append("oCell.style.width = '50px';")
            sb.Append("oCell.align = 'center';")
            sb.Append("oCell.innerHTML = " & Chr(34) & "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Puntos Claro'  onclick='consultarSaldoPuntos(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")
            'gaa20160531
            sb.Append("if (document.getElementById('tdPaqueteClaroPuntos').style.display == 'none')")
            sb.Append("oCell.style.display = 'none';")
            'fin gaa20160531
        End If

        'gaa20150504
        'sb.Append("oCell = newRow.insertCell();")
        'sb.Append("oCell.style.width = '182px';")
        'sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarCampana(" & Chr(34) & " + idFila + " & Chr(34) & ", this.value);'><option value=''>SELECCIONE...</option>")
        'sb.Append("</select>" & Chr(34) & ";")
        'fin gaa20150504

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '200px';")
        sb.Append("oCell.style.whiteSpace = 'nowrap';")
        Dim strEquipo As String = "<div class='AutoComplete_Div'>"
        'gaa20150505
        strEquipo &= "<input type='hidden' id='hidMaterial" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidMaterial" & Chr(34) & " + idFila + " & Chr(34) & "' />"
        'fin gaa20150505
        strEquipo &= String.Format("<input type='hidden' id='hidValor{0}" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidValor{0}" & Chr(34) & " + idFila + " & Chr(34) & "' />", "Equipo")
        strEquipo &= "<input type='text' id='txtTextoEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' name='txtTextoEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' class='clsSelectEnable0' style='width: 179px' onclick=mostrarListaSel(" & Chr(34) & " + idFila + " & Chr(34) & ") onkeyup=buscarCoincidente(" & Chr(34) & " + idFila + " & Chr(34) & "); onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & "); />"
        strEquipo &= "<img id='imgListaEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/cmb.gif' style='height: 17px; cursor: pointer' align='absMiddle' title='Mostrar Lista' alt='Mostrar Lista' onclick=mostrarListaSel(" & Chr(34) & " + idFila + " & Chr(34) & ");" & " onmouseover='imgSel(this)' onmouseout='imgNoSel(this)'; onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & "); />"
        strEquipo &= "</div><div id='divListaEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' class='AutoComplete_List' style='width: 262px; display: none; z-index:10'; onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & ");></div>"
        strEquipo &= "<input type='hidden' id='hidKit" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidKit" & Chr(34) & " + idFila + " & Chr(34) & "' />"
        strEquipo &= "<input type='hidden' id='hidListaPreciosEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidListaPreciosEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' />"
        sb.Append("oCell.innerHTML = " & Chr(34) & strEquipo & Chr(34) & ";")

        'INICIO GEJ 20141222
        sb.Append("      if (getValue('hidTieneCuotas') == 'S')")
        sb.Append("      {")
        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '37px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgVerCuota" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgVerCuota" & Chr(34) & " + idFila + " & Chr(34) & "' src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Cuotas' onclick='mostrarCuota(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")
        sb.Append("      }")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '67px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtEquipoPrecio" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtEquipoPrecio" & Chr(34) & " + idFila + " & Chr(34) & "' /><input id='hidListaPrecio" & Chr(34) & " + idFila + " & Chr(34) & "' type='hidden' name='hidListaPrecio" & Chr(34) & " + idFila + " & Chr(34) & "' />" & Chr(34) & ";")
        'FIN GEJ 20141222

        sb.Append("      if (strTienePortab == 'S')")
        sb.Append("      {")
        sb.Append(" oCell = newRow.insertCell();")
        sb.Append(" oCell.style.width = '60px';")
        sb.Append(" oCell.innerHTML = " & Chr(34) & "<input style='width:100%' class='clsInputEnable' maxlength='9' name='txtNroPortar" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtNroPortar" & Chr(34) & " + idFila + " & Chr(34) & "' onkeypress='eventoSoloNumerosEnteros();' />" & Chr(34) & ";")
        sb.Append("      }")
        sb.Append("    }")

        sb.Append("    if (desTipoProductoActual == 'HFC')")
        sb.Append("    {")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '40px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgDirInst" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgDirInst" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand;display:none' alt='Dir. Inst.' onclick='mostrarDirInst(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '40px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgDetOfert" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgDetOfert" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand;display:none' alt='Det. Ofert.' onclick='mostrarDetOfert(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")

        sb.Append("    }")
        sb.Append("  }")

        sb.Append("  else")
        sb.Append("  {")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '185px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlCampana" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarCampana(" & Chr(34) & " + idFila + " & Chr(34) & ", this.value);'><option value=''>SELECCIONE...</option>")

        sb.Append("</select>" & Chr(34) & ";")

        sb.Append("  oCell = newRow.insertCell();")
        sb.Append("  oCell.style.width = '200px';")
        sb.Append("  oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPlan" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPlan" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPlan(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '30px';")
        sb.Append("oCell.align = 'center';")
        'sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgServicios" & Chr(34) & " + idFila + " & Chr(34) & "' src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicio(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgServicios" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgServicios" & Chr(34) & " + idFila + " & Chr(34) & "' src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicio(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")
        sb.Append("  oCell = newRow.insertCell();")
        sb.Append("  oCell.style.width = '150px';")
        sb.Append("  oCell.innerHTML = " & Chr(34) & "<select style='width:100%' class='clsSelectEnable0' name='ddlPlazo" & Chr(34) & " + idFila + " & Chr(34) & "' id='ddlPlazo" & Chr(34) & " + idFila + " & Chr(34) & "' onchange='cambiarPlazo(this.value, " & Chr(34) & " + idFila + " & Chr(34) & ");'><option>SELECCIONE...</option>")
        sb.Append("</select>" & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '200px';")
        sb.Append("oCell.style.whiteSpace = 'nowrap';")
        strEquipo = "<div class='AutoComplete_Div'>"
        strEquipo &= String.Format("<input type='hidden' id='hidValor{0}" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidValor{0}" & Chr(34) & " + idFila + " & Chr(34) & "' />", "Equipo")
        strEquipo &= "<input type='text' id='txtTextoEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' name='txtTextoEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' class='clsSelectEnable0' style='width: 179px' onclick=mostrarListaSel(" & Chr(34) & " + idFila + " & Chr(34) & ") onkeyup=buscarCoincidente(" & Chr(34) & " + idFila + " & Chr(34) & "); onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & "); />"
        strEquipo &= "<img id='imgListaEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/cmb.gif' style='height: 17px; cursor: pointer' align='absMiddle' title='Mostrar Lista' alt='Mostrar Lista' onclick=mostrarListaSel(" & Chr(34) & " + idFila + " & Chr(34) & ");" & " onmouseover='imgSel(this)' onmouseout='imgNoSel(this)'; onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & "); />"
        strEquipo &= "</div><div id='divListaEquipo" & Chr(34) & " + idFila + " & Chr(34) & "' class='AutoComplete_List' style='width: 262px; display: none; z-index:10'; onblur=ocultarListaTxt(" & Chr(34) & " + idFila + " & Chr(34) & ");></div>"
        strEquipo &= "<input type='hidden' id='hidKit" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidKit" & Chr(34) & " + idFila + " & Chr(34) & "' />"
        sb.Append("oCell.innerHTML = " & Chr(34) & strEquipo & Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '55px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtPrecioInst" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtPrecioInst" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append(Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '55px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFPlanServicio" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtCFPlanServicio" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append("<input type='hidden' id='hidMontoServicios" & Chr(34) & " + idFila + " & Chr(34) & "' name='hidMontoServicios" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append(Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '50px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFMenAlqKit" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtCFMenAlqKit" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append(Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '50px';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFTotMensual" & Chr(34) & " + idFila + " & Chr(34) & "' id='txtCFTotMensual" & Chr(34) & " + idFila + " & Chr(34) & "' />")
        sb.Append(Chr(34) & ";")

        sb.Append("oCell = newRow.insertCell();")
        sb.Append("oCell.style.width = '40px';")
        sb.Append("oCell.align = 'center';")
        sb.Append("oCell.innerHTML = " & Chr(34) & "<img name='imgDirInst" & Chr(34) & " + idFila + " & Chr(34) & "' id='imgDirInst" & Chr(34) & " + idFila + " & Chr(34) & "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand' alt='Dir. Inst.' onclick='mostrarDirInst(" & Chr(34) & " + idFila + " & Chr(34) & ");' />" & Chr(34) & ";")

        sb.Append("  }")

        sb.Append("  if (hidTraerPlazo.value == 'S')")
        sb.Append("  {")
        sb.Append("    hidTraerPlazo.value = 'N';")
        sb.Append("  }")

        sb.Append("  if (booVeriConf)") 'Si se llama desde el boton agregar fila
        sb.Append("    hidPaqueteActual.value = '';")

        sb.Append("  var ddlPlazo = document.getElementById('ddlPlazo' + idFila);")
        sb.Append("  var strFlujo = flujoAlta;")
        sb.Append("  if (parent.getValue('hidTienePortabilidad') == 'S')")
        sb.Append("    strFlujo = flujoPortabilidad;")

        sb.Append("  if (strPlazoActual.length > 0)")
        sb.Append("  {")
        sb.Append("    strPlazoActual = getValor(strPlazoActual, 0);")
        sb.Append("    if (!booVeriConf)")
        sb.Append("      asignarPaquete(idFila, getValue('hidPaqActCompleto'));")
        sb.Append("  }")

        sb.Append("cerrarServicio();")
        sb.Append("cerrarCuota();")

        sb.Append("hidConfirmaCuota.value = 'N';")
        sb.Append("}")

        RegisterStartupScript("script", "<script>" & sb.ToString & ";</script>")
    End Sub

    Private Sub LlenarHiddenTipoDocumento()
        Dim lista As ArrayList = (New VentaNegocios).ListaTipoDocumento("")

        Dim sbTipoDocumento As New StringBuilder
        For Each item As ItemGenerico In lista
            sbTipoDocumento.Append(item.Codigo)
            sbTipoDocumento.Append("=")
            sbTipoDocumento.Append(item.Codigo2)
            sbTipoDocumento.Append("|")
        Next item

        sbTipoDocumento.Remove(sbTipoDocumento.Length - 1, 1)
        hidTipoDocumentos.Value = sbTipoDocumento.ToString
    End Sub

    'PROY-24740
    Private Sub CargarDatosDePuntoClaroClub(ByVal TipoDocumento As String, ByVal NroDocumento As String, ByVal NroLinea As String)
        Dim PuntosPostpago As Integer = 0
        Dim SolesPostpago As Double = 0.0
        Dim SaldoActualWS As Integer = 0
        Dim SaldoActual As Integer = 0
        Dim SaldoEquivalente As Integer = 0
        Dim PuntosUtilizar As Integer = 0
        Dim SolesDeDescuento As Double = 0
        Dim constFactorClaroClub As Double
        Dim ValorPuntosPostpago As Integer
        Dim ClaroClubCampana As String
        Dim idCampana As String
        Dim idLog As String
        Dim constErrorBolsaMovilDes As String = ""
        Dim ErrorBolsaMovilDes As String = ""
        Dim bErrorBolsaMovilDes As Boolean = False
        Dim CCMinimoSoles As Double = 0.0

        Try
            idLog = TipoDocumento & " - " & NroDocumento

            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio CargarDatosDePuntoClaroClub()")
            Dim ipcliente As String = CurrentTerminal
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim usuario_id As String = CurrentUser
            Dim Packaged As String = ""
            Dim UsuarioProceso As String = ""
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString

            oLog.Log_WriteLog(oFile, idLog & " - " & "IP Origen:" & ipcliente)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Nombre de la PC:" & nombreHost)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Usuario Origen:" & usuario_id)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Packaged:" & Packaged)
            oLog.Log_WriteLog(oFile, idLog & " - " & "Usuario Proceso:" & UsuarioProceso)
            oLog.Log_WriteLog(oFile, idLog & " - " & "IP Proceso:" & ipServer)

            Dim ID_CCLUB As String
            ID_CCLUB = getCCLUB(TipoDocumento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "ID_CCLUB:" & ID_CCLUB)
            oLog.Log_WriteLog(oFile, idLog & " - " & "NroDocumento:" & NroDocumento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "CurrentUser:" & CurrentUser)
            oLog.Log_WriteLog(oFile, idLog & " - " & "NroLinea:" & NroLinea)

            Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
            Dim objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse
            objConsultarPuntosResponse = objPuntosClaroClubNegocio.consultarPuntos(ID_CCLUB, _
                                                                                   NroDocumento, _
                                                                                   CurrentUser, _
                                                                                   NroLinea)


            'Inicio leer WS

            oLog.Log_WriteLog(oFile, idLog & " - " & "out txId:" & objConsultarPuntosResponse.audit.txId)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorCode:" & objConsultarPuntosResponse.audit.errorCode)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out errorMsg:" & objConsultarPuntosResponse.audit.errorMsg)
            lblClaroClubMsgError.Text = ""

            constErrorBolsaMovilDes = ConfigurationSettings.AppSettings("constErrorBolsaMovilDes")
            If objConsultarPuntosResponse.audit.errorCode.Trim = constErrorBolsaMovilDes Then
                bErrorBolsaMovilDes = True
                ErrorBolsaMovilDes = objConsultarPuntosResponse.audit.errorMsg
                Throw New Exception(objConsultarPuntosResponse.audit.errorCode)
            ElseIf objConsultarPuntosResponse.audit.errorCode.Trim <> "0" Then
                Throw New Exception(ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible"))
            End If

            ' Leer Id de la campaña
            ValorPuntosPostpago = 1
            If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
                ClaroClubCampana = objConsultarPuntosResponse.curCampana(0).descripcion
                idCampana = objConsultarPuntosResponse.curCampana(0).idCampana
                ' Valor de conversión de puntos postpago.
                Dim constPOSTPAGO As String = ConfigurationSettings.AppSettings("constPOSTPAGO")
                For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                    If objConsultarPuntosResponse.curCampana(i).tipo = constPOSTPAGO Then
                        ValorPuntosPostpago = Funciones.CheckInt(objConsultarPuntosResponse.curCampana(i).valor)
                        Exit For
                    End If
                Next i
            Else
                ' Mensaje predeterminado si no hay campaña vigente
                ClaroClubCampana = Funciones.CheckStr(ConfigurationSettings.AppSettings("constNoCampanhas"))
            End If


            Dim constTipoClientePOSTPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO")
            constFactorClaroClub = Funciones.CheckDbl(objConsultarPuntosResponse.factorConversion)
            If (constFactorClaroClub = 0.0) Then
                Throw New Exception(ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible"))
            Else
                Dim CCMinimoPuntos As Integer
                CCMinimoPuntos = Funciones.CheckInt(ConfigurationSettings.AppSettings("constMinimoCC"))
                oLog.Log_WriteLog(oFile, idLog & " - " & "out CCMinimoPuntos:" & CCMinimoPuntos)
                CCMinimoSoles = Math.Ceiling(CCMinimoPuntos * constFactorClaroClub)
                oLog.Log_WriteLog(oFile, idLog & " - " & "out CCMinimoSoles:" & CCMinimoSoles)
                hidMinimoSoles.Value = CCMinimoSoles.ToString
            End If

            Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)

            Dim saldosCC As New Hashtable
            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
                saldosCC.Add(bolsaCC(0), bolsaCC(1))
            Next i

            Dim oBolsas As New ArrayList
            Dim OtrosSaldos As Integer = 0
            If Not objConsultarPuntosResponse Is Nothing Then
                For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                    Dim oCanjePuntos As New CanjePuntos
                    If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePOSTPAGO Then
                        PuntosPostpago = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).saldoTT)
                    Else
                        OtrosSaldos = OtrosSaldos + Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).saldoTT)
                    End If
                    oCanjePuntos.COD_BOLSA = objConsultarPuntosResponse.cursorSaldos(i).tipoCliente
                    oCanjePuntos.DESCRIP_BOLSA = saldosCC.Item(oCanjePuntos.COD_BOLSA).ToString
                    oCanjePuntos.PUNTOS_ASIGNADOS = objConsultarPuntosResponse.cursorSaldos(i).saldoTT

                    oBolsas.Add(oCanjePuntos)
                Next i
            End If
            hidOtrosSaldos.Value = OtrosSaldos

            dgSaldosCC.DataSource = oBolsas
            dgSaldosCC.DataBind()
            SaldoActual = PuntosPostpago + OtrosSaldos
            SaldoEquivalente = PuntosPostpago * ValorPuntosPostpago + OtrosSaldos

            oLog.Log_WriteLog(oFile, idLog & " - " & "out ClaroClubCampana:" & ClaroClubCampana)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out PuntosPostpago:" & PuntosPostpago)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out SaldoActualWS:" & SaldoActualWS)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out PuntosUtilizar:" & PuntosUtilizar)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out SolesDeDescuento:" & SolesDeDescuento)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out ValorPuntosPostpago:" & ValorPuntosPostpago)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out SaldoActual:" & SaldoActual)
            oLog.Log_WriteLog(oFile, idLog & " - " & "out idCampana:" & idCampana)

            txtClaroClubCampana.Text = ClaroClubCampana
            hidClaroClubPuntosPostpago.Value = PuntosPostpago.ToString
            txtClaroClubSaldoActual.Text = SaldoActual.ToString

            PuntosUtilizar = SaldoActual
            SolesDeDescuento = Math.Ceiling(SaldoEquivalente * constFactorClaroClub)
            hidSaldoActualWS.Value = SaldoActualWS.ToString

            hidClaroClubPuntosUtilizar.Value = txtClaroClubSaldoActual.Text
            txtClaroClubSolesDeDescuento.Text = SolesDeDescuento.ToString
            hidClaroClubSolesDeDescuento.Value = SolesDeDescuento.ToString
            hidValorPuntosPostpago.Value = ValorPuntosPostpago
            hidIDCAMPANA.Value = idCampana

            hidFactorClaroClub.Value = constFactorClaroClub.ToString

            ' Implementar la auditoría de cargar datos de Punto Claro Club.
            Dim codTrs As String = ConfigurationSettings.AppSettings("codTDatosPuntoClaroClub")
            Dim descTrs As New StringBuilder("Cargar Datos De Punto Claro Club. ClaroClubCampana: ")
            descTrs.Append(ClaroClubCampana)
            descTrs.AppendFormat(" PuntosPostpago: {0}", PuntosPostpago)
            descTrs.AppendFormat(" SaldoActual: {0}", SaldoActual)
            descTrs.AppendFormat(" SolesDeDescuento: {0}", SolesDeDescuento)
            descTrs.AppendFormat(" ClaroClubPuntosUtilizar: {0}", txtClaroClubSaldoActual.Text)
            descTrs.AppendFormat(" ClaroClubSolesDeDescuento: {0}", txtClaroClubSolesDeDescuento.Text)
            descTrs.AppendFormat(" FactorClaroClub: {0}", constFactorClaroClub.ToString)
            descTrs.AppendFormat(" idCampana: {0}", idCampana)

            ' Verificar si hay reserva de puntos
            If TieneReserva(ID_CCLUB, NroDocumento) Then
                txtClaroClubSolesDeDescuento.Text = "0"
                hidTieneReserva.Value = "1"
                lblClaroClubMsgError.Text = ConfigurationSettings.AppSettings("msjClienteNoPuntosClaroClub")
            Else
                hidTieneReserva.Value = String.Empty
                lblClaroClubMsgError.Text = String.Empty
            End If

            ' Inicio Modificación en SISACT la invocación de la WS de ConsultaPuntos
            Call VerVigenciaSegmento(objConsultarPuntosResponse)
            Call ConfigurarDatosDetalleDescuento(objConsultarPuntosResponse)

            Auditoria(codTrs, descTrs.ToString())
        Catch ex As Exception
            txtClaroClubSaldoActual.Text = "0"
            hidClaroClubPuntosUtilizar.Value = "0"
            txtClaroClubSolesDeDescuento.Text = "0"
            hidClaroClubSolesDeDescuento.Value = "0"
            If bErrorBolsaMovilDes Then
                lblClaroClubMsgError.Text = ErrorBolsaMovilDes
            Else
                lblClaroClubMsgError.Text = ConfigurationSettings.AppSettings("constErrorClaroClubNoDisponible")
            End If
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR CargarDatosDePuntoClaroClub(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR CargarDatosDePuntoClaroClub(): " & ex.StackTrace.ToString())
            Throw ex
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin CargarDatosDePuntoClaroClub(): ")
        End Try
    End Sub

    Public Function getCCLUB(ByVal TipoDocumento As String) As String
        Dim ID_CCLUB As String
        Dim TipoDocumentos() As String = hidTipoDocumentos.Value.Split("|"c)
        Dim hstTipoDocumentos As New Hashtable

        For Each item As String In TipoDocumentos
            Dim vItem() As String = item.Split("="c)
            hstTipoDocumentos.Add(vItem(0), vItem(1))
        Next item
        ID_CCLUB = hstTipoDocumentos.Item(TipoDocumento)

        Return ID_CCLUB
    End Function

    Public Function TieneReserva(ByVal k_tipo_doc As String, ByVal k_num_doc As String) As Boolean

        Dim objPuntosClaroClubNegocio As New PuntosClaroClubNegocio
        Dim k_tipo_clie As String = ConfigurationSettings.AppSettings("consClienteWS")
        Dim k_tipo_doc2 As String
        Dim k_estado As String
        Dim k_coderror As Double
        Dim k_descerror As String
        Dim bTieneReserva As Boolean = False
        Dim constVALBLOQUEOBOLSA As String = ConfigurationSettings.AppSettings("constVALBLOQUEOBOLSA")
        Dim idLog As String

        Try
            oLog.Log_WriteLog(oFile, idLog & " - " & "Inicio TieneReserva()")

            objPuntosClaroClubNegocio.ValidaBloqueoBolsa(k_tipo_doc, _
                                                         k_num_doc, _
                                                         k_tipo_clie, _
                                                         k_tipo_doc2, _
                                                         k_estado, _
                                                         k_coderror, _
                                                         k_descerror)
            oLog.Log_WriteLog(oFile, idLog & " - " & "k_tipo_doc2:" & k_tipo_doc2)
            oLog.Log_WriteLog(oFile, idLog & " - " & "k_estado:" & k_estado)
            oLog.Log_WriteLog(oFile, idLog & " - " & "k_coderror:" & k_coderror)
            oLog.Log_WriteLog(oFile, idLog & " - " & "k_descerror:" & k_descerror)

            If k_coderror = 0.0 Then
                If constVALBLOQUEOBOLSA = k_estado Then
                    bTieneReserva = True
                End If
            End If
            oLog.Log_WriteLog(oFile, idLog & " - " & "bTieneReserva:" & bTieneReserva)

            Return bTieneReserva
        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR TieneReserva(): " & ex.Message.ToString())
            oLog.Log_WriteLog(oFile, idLog & " - " & "ERROR TieneReserva(): " & ex.StackTrace.ToString())

            Return False
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - " & "Fin TieneReserva()")
        End Try
    End Function

    Private Sub Auditoria(ByVal desTrans As String, ByVal strCodTrans As String)
        Try

            Dim strCodServ As String = ConfigurationSettings.AppSettings("CONS_COD_SACT_SERV")
            Dim ipcliente As String = CurrentTerminal
            Dim nombreHost As String = System.Net.Dns.GetHostName
            Dim nombreServer As String = System.Net.Dns.GetHostName
            Dim ipServer As String = System.Net.Dns.GetHostByName(nombreServer).AddressList(0).ToString
            Dim usuario_id As String = CurrentUser
            Dim telefono As String = ""

            Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(nombreHost)


            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Inicio registrarAuditoria()")
            Dim auditoriaGrabado As Boolean = (New AuditoriaNegocio).registrarAuditoria(strCodTrans, _
                                                                                        strCodServ, _
                                                                                        ipcliente, _
                                                                                        nombreHost, _
                                                                                        ipServer, _
                                                                                        nombreServer, _
                                                                                        usuario_id, _
                                                                                        telefono, "0", _
                                                                                        desTrans)

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Exception registrarAuditoria() - Mensaje: " & ex.Message)
        Finally
            oLog.Log_WriteLog(oFile, strIdentifyLog & "- Fin registrarAuditoria()")
        End Try
    End Sub


    Private Sub VerVigenciaSegmento(ByRef objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse)
        Try
            If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
                If objConsultarPuntosResponse.curCampana(0).fecha_inicio.ToString.Trim.Length > 0 Then
                    Dim fecha_inicio As String = objConsultarPuntosResponse.curCampana(0).fecha_inicio.ToString.Trim.Substring(0, 10)
                    Dim vfechaInicio As String() = fecha_inicio.Split("-")
                    txtFechaIniCC.Text = vfechaInicio(2) + "/" + vfechaInicio(1) + "/" + vfechaInicio(0)
                Else
                    txtFechaIniCC.Text = ""
                End If

                If objConsultarPuntosResponse.curCampana(0).fecha_fin.ToString.Trim.Length > 0 Then
                    Dim fecha_fin As String = objConsultarPuntosResponse.curCampana(0).fecha_fin.ToString.Trim.Substring(0, 10)
                    Dim vfechaFin As String() = fecha_fin.Split("-")
                    txtFechaFinCC.Text = vfechaFin(2) + "/" + vfechaFin(1) + "/" + vfechaFin(0)
                Else
                    txtFechaFinCC.Text = ""
                End If
            Else
                txtFechaIniCC.Text = ""
                txtFechaFinCC.Text = ""
            End If

            If objConsultarPuntosResponse.codigoSegmento.Trim <> "" Then
                txtSegmentoCC.Text = objConsultarPuntosResponse.codigoSegmento.Trim.ToUpper
            Else
                txtSegmentoCC.Text = ""
            End If
        Catch ex As Exception
            txtFechaIniCC.Text = ""
            txtFechaFinCC.Text = ""
            txtSegmentoCC.Text = ""
        End Try

        'Ingresar Valores Padre
        Dim scriptParent As String = "<script>CargarValoresSegmentacion('" & txtFechaIniCC.Text & "','" & txtFechaFinCC.Text & "','" & txtSegmentoCC.Text & "');</script>"
        RegisterStartupScript("scriptSeg", scriptParent)
    End Sub


    Private Sub ConfigurarDatosDetalleDescuento(ByRef objConsultarPuntosResponse As ConsultarPuntosWS.consultarPuntosResponse)
        Dim factorConversion As Decimal
        Dim dtBase As New DataTable
        Dim orden As Integer = 1
        Dim bExiste As Boolean = False

        dtBase.Columns.Add(New DataColumn("NORMAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("PROMOCIONAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TOTAL", GetType(Decimal)))
        dtBase.Columns.Add(New DataColumn("TIPO_DE_DSCTO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("FACTOR", GetType(Integer)))
        dtBase.Columns.Add(New DataColumn("TIPO_CLIENTE", GetType(String)))
        dtBase.Columns.Add(New DataColumn("VALOR_SEGMENTO", GetType(String)))
        dtBase.Columns.Add(New DataColumn("PUNTOS", GetType(String)))
        dtBase.Columns.Add(New DataColumn("ORDEN", GetType(Integer)))

        factorConversion = Funciones.CheckDecimal(objConsultarPuntosResponse.factorConversion)
        If Not objConsultarPuntosResponse.curCampana Is Nothing AndAlso objConsultarPuntosResponse.curCampana.Length > 0 Then
            Dim cursorSaldo As ConsultarPuntosWS.CursorSaldosType

            ' Valor de conversión de puntos postpago.
            Dim constPOSTPAGO As String = ConfigurationSettings.AppSettings("constPOSTPAGO")
            Dim constTipoClientePOSTPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO")
            Dim PuntosPostCampaña As Integer = 1
            Dim PuntosPostSegmento As Integer = 1
            Dim FactorPost As Integer = 1
            Dim TipoDsctoPost As String
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                If objConsultarPuntosResponse.curCampana(i).tipo = constPOSTPAGO Then
                    PuntosPostCampaña = Funciones.CheckInt(objConsultarPuntosResponse.curCampana(i).valor)
                    Exit For
                End If
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePOSTPAGO Then
                    PuntosPostSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPostCampaña > PuntosPostSegmento) Then
                FactorPost = PuntosPostCampaña
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPost = PuntosPostSegmento
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPost As DataRow = dtBase.NewRow
            rowPost("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPost("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TIPO_DE_DSCTO") = TipoDsctoPost
            rowPost("FACTOR") = FactorPost
            rowPost("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPost("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPost("PUNTOS") = cursorSaldo.saldoTT
            rowPost("ORDEN") = orden
            If bExiste Then
                orden = orden + 1
                dtBase.Rows.Add(rowPost)
            End If
            bExiste = False

            ' Valor de conversión de puntos prepago.
            Dim constPREPAGO As String = ConfigurationSettings.AppSettings("constPREPAGO")
            Dim constTipoClientePREPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePREPAGO")
            Dim PuntosPreCampaña As Integer = 1
            Dim PuntosPreSegmento As Integer = 0
            Dim FactorPre As Integer = 1
            Dim TipoDsctoPre As String
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                If objConsultarPuntosResponse.curCampana(i).tipo = constPREPAGO Then
                    PuntosPreCampaña = Funciones.CheckInt(objConsultarPuntosResponse.curCampana(i).valor)
                    Exit For
                End If
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePREPAGO Then
                    PuntosPreSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPreCampaña > PuntosPreSegmento) Then
                FactorPre = PuntosPreCampaña
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPre = PuntosPreSegmento
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPre As DataRow = dtBase.NewRow
            rowPre("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPre("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TIPO_DE_DSCTO") = TipoDsctoPre
            rowPre("FACTOR") = FactorPre
            rowPre("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPre("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPre("PUNTOS") = cursorSaldo.saldoTT
            rowPre("ORDEN") = orden
            If bExiste Then
                orden = orden + 1
                dtBase.Rows.Add(rowPre)
            End If

            ' Los demás
            Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)
            Dim saldosCC As New Hashtable
            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
                saldosCC.Add(bolsaCC(0), bolsaCC(2))
            Next i
            For i As Integer = 0 To objConsultarPuntosResponse.curCampana.Length - 1
                ' Se evaluan aquellos que no son pre o postpago.
                If objConsultarPuntosResponse.curCampana(i).tipo <> constPOSTPAGO AndAlso objConsultarPuntosResponse.curCampana(i).tipo <> constPREPAGO Then
                    For j As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                        Dim tipo As String = saldosCC(objConsultarPuntosResponse.cursorSaldos(j).tipoCliente).ToString.Trim
                        If tipo = objConsultarPuntosResponse.curCampana(i).tipo.Trim Then
                            Dim rowOtros As DataRow = dtBase.NewRow
                            rowOtros("NORMAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion
                            rowOtros("PROMOCIONAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                            rowOtros("TOTAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                            rowOtros("TIPO_DE_DSCTO") = TipoDsctoPost
                            rowOtros("FACTOR") = FactorPost
                            rowOtros("TIPO_CLIENTE") = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                            rowOtros("VALOR_SEGMENTO") = objConsultarPuntosResponse.cursorSaldos(j).valorSegmento
                            rowOtros("PUNTOS") = objConsultarPuntosResponse.cursorSaldos(j).saldoTT
                            rowOtros("ORDEN") = orden
                            orden = orden + 1
                            dtBase.Rows.Add(rowOtros)
                        End If
                    Next j
                End If
            Next i
        Else
            Dim cursorSaldo As ConsultarPuntosWS.CursorSaldosType

            ' Valor de conversión de puntos postpago.
            Dim constPOSTPAGO As String = ConfigurationSettings.AppSettings("constPOSTPAGO")
            Dim constTipoClientePOSTPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO")
            Dim PuntosPostCampaña As Integer = 1
            Dim PuntosPostSegmento As Integer = 1
            Dim FactorPost As Integer = 1
            Dim TipoDsctoPost As String

            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePOSTPAGO Then
                    PuntosPostSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPostCampaña > PuntosPostSegmento) Then
                FactorPost = PuntosPostCampaña
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPost = PuntosPostSegmento
                TipoDsctoPost = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPost As DataRow = dtBase.NewRow
            rowPost("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPost("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPost
            rowPost("TIPO_DE_DSCTO") = TipoDsctoPost
            rowPost("FACTOR") = FactorPost
            rowPost("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPost("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPost("PUNTOS") = cursorSaldo.saldoTT
            rowPost("ORDEN") = orden
            If bExiste Then
                orden = orden + 1
                dtBase.Rows.Add(rowPost)
            End If
            bExiste = False

            ' Valor de conversión de puntos prepago.
            Dim constPREPAGO As String = ConfigurationSettings.AppSettings("constPREPAGO")
            Dim constTipoClientePREPAGO As String = ConfigurationSettings.AppSettings("constTipoClientePREPAGO")
            Dim PuntosPreCampaña As Integer = 1
            Dim PuntosPreSegmento As Integer = 0
            Dim FactorPre As Integer = 1
            Dim TipoDsctoPre As String
            For i As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                If objConsultarPuntosResponse.cursorSaldos(i).tipoCliente = constTipoClientePREPAGO Then
                    PuntosPreSegmento = Funciones.CheckInt(objConsultarPuntosResponse.cursorSaldos(i).valorSegmento)
                    cursorSaldo = objConsultarPuntosResponse.cursorSaldos(i)
                    bExiste = True
                    Exit For
                End If
            Next i
            If (PuntosPreCampaña > PuntosPreSegmento) Then
                FactorPre = PuntosPreCampaña
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoCampanha")
            Else
                FactorPre = PuntosPreSegmento
                TipoDsctoPre = ConfigurationSettings.AppSettings("constDescuentoSegmento")
            End If
            Dim rowPre As DataRow = dtBase.NewRow
            rowPre("NORMAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion
            rowPre("PROMOCIONAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TOTAL") = Funciones.CheckDecimal(cursorSaldo.saldoTT) * factorConversion * FactorPre
            rowPre("TIPO_DE_DSCTO") = TipoDsctoPre
            rowPre("FACTOR") = FactorPre
            rowPre("TIPO_CLIENTE") = cursorSaldo.tipoCliente
            rowPre("VALOR_SEGMENTO") = cursorSaldo.valorSegmento
            rowPre("PUNTOS") = cursorSaldo.saldoTT
            rowPre("ORDEN") = orden
            If bExiste Then
                orden = orden + 1
                dtBase.Rows.Add(rowPre)
            End If

            ' Los demás
            Dim vBolsasCC As String() = ConfigurationSettings.AppSettings("constBolsasCC").Split(";"c)
            Dim saldosCC As New Hashtable
            For i As Integer = 0 To vBolsasCC.Length - 1
                Dim bolsaCC As String() = vBolsasCC(i).Split(":"c)
                saldosCC.Add(bolsaCC(0), bolsaCC(2))
            Next i
            ' Se evaluan aquellos que no son pre o postpago.
            For j As Integer = 0 To objConsultarPuntosResponse.cursorSaldos.Length - 1
                Dim tipoCliente As String = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                If tipoCliente <> constTipoClientePOSTPAGO AndAlso tipoCliente <> constTipoClientePREPAGO Then
                    Dim rowOtros As DataRow = dtBase.NewRow
                    rowOtros("NORMAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion
                    rowOtros("PROMOCIONAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                    rowOtros("TOTAL") = Funciones.CheckDecimal(objConsultarPuntosResponse.cursorSaldos(j).saldoTT) * factorConversion * FactorPost
                    rowOtros("TIPO_DE_DSCTO") = TipoDsctoPost
                    rowOtros("FACTOR") = FactorPost
                    rowOtros("TIPO_CLIENTE") = objConsultarPuntosResponse.cursorSaldos(j).tipoCliente
                    rowOtros("VALOR_SEGMENTO") = objConsultarPuntosResponse.cursorSaldos(j).valorSegmento
                    rowOtros("PUNTOS") = objConsultarPuntosResponse.cursorSaldos(j).saldoTT
                    rowOtros("ORDEN") = orden
                    orden = orden + 1
                    dtBase.Rows.Add(rowOtros)
                End If
            Next j
        End If

        If dtBase.Rows.Count > 0 Then
            Dim qs As New StringBuilder
            Dim total As String 'Decimal = 0.0
            Dim puntos As String 'Integer = 0

            For Each dr As DataRow In dtBase.Rows
                qs.Append(dr.Item("NORMAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("PROMOCIONAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TOTAL").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TIPO_DE_DSCTO").ToString())
                qs.Append("|")
                qs.Append(dr.Item("FACTOR").ToString())
                qs.Append("|")
                qs.Append(dr.Item("TIPO_CLIENTE").ToString())
                qs.Append("|")
                qs.Append(dr.Item("VALOR_SEGMENTO").ToString())
                qs.Append("|")
                qs.Append(dr.Item("PUNTOS").ToString())
                qs.Append("|")
                qs.Append(dr.Item("ORDEN").ToString())
                qs.Append("~")
                puntos = puntos + Funciones.CheckInt(dr.Item("PUNTOS").ToString())
                total = total + Funciones.CheckDecimal(dr.Item("TOTAL").ToString())
            Next dr
            qs.Append(Math.Ceiling(total).ToString("n2"))

            txtClaroClubSolesDeDescuento.Text = Math.Ceiling(total).ToString()   'String.Format("{0:#,#,#,#}", CheckSng(total)) 
            hidClaroClubSolesDeDescuento.Value = Math.Ceiling(total).ToString()
            hidDetalleDescuento.Value = qs.ToString
        End If
    End Sub

    'PROY-32129 :: INI
    Private Function CargarParamCampanas() As String
        Dim objMaestroDatos As New MaestroNegocio
        Dim codGrupo As String = ConfigurationSettings.AppSettings("consGrupoCasoEspecial")
        Dim objParametro As ArrayList
        Dim idLog As String = Request.QueryString("NumDoc")
        Dim factor_parametro As New StringBuilder

        Try
            oLog.Log_WriteLog(oFile, idLog & " - *********** INICIO CARGAR PARAMETROS CAMPANAS CASO ESPECIAL ***********")
            oLog.Log_WriteLog(oFile, idLog & " - Valor de llave consGrupoCasoEspecial : " & codGrupo)

            objParametro = objMaestroDatos.ListaParametrosGrupo(codGrupo)

            For Each item As Parametro In objParametro
                If item.Valor1 = "2" Then
                    factor_parametro.AppendFormat("{0}", item.Valor)
                End If
            Next
            oLog.Log_WriteLog(oFile, idLog & " - Resulta de parametros de campanas habilitadas : " & factor_parametro.ToString())

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - Error al cargar parametros de campanas caso especial : " & ex.Message.ToString())
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - *********** INICIO CARGAR PARAMETROS CAMPANAS CASO ESPECIAL ***********")
        End Try

        Return factor_parametro.ToString()
    End Function

    <Anthem.Method()> _
    Public Function EliminarAlumno(ByVal sCampanaActual As String) As String

        Dim objBLCasoEspecial As New BLCasoEspecial
        Dim blEstado As Boolean = False
        Dim sTipoDoc As String = Request.QueryString("TipDoc")
        Dim sNroDoc As String = Request.QueryString("NumDoc")
        Dim sCodMensaje As String
        Dim sMensaje As String
        Dim sParamCampanas As String
        Dim sCampana As String
        Dim sParamMensajes As String
        Dim hideliminar As String

        Try
            hideliminar = hidcampanaactual.Value
            oLog.Log_WriteLog(oFile, sNroDoc & " - *********** INICIO VALIDACION DOC CASO ESPECIAL ***********")
            oLog.Log_WriteLog(oFile, sNroDoc & " - Parametro sCampanaActual : " & sCampanaActual)

            sParamMensajes = CargarParamMensajes()

            sParamCampanas = CargarParamCampanas()
            sCampana = "|" + hideliminar + "|"

            If (sParamCampanas.IndexOf(sCampana) > -1) Then
                blEstado = objBLCasoEspecial.EliminarAlumno(sTipoDoc, sNroDoc, CurrentUser, sCodMensaje, sMensaje)
                oLog.Log_WriteLog(oFile, sNroDoc & " - Resultado de consulta : " & sCodMensaje)
                oLog.Log_WriteLog(oFile, sNroDoc & " - Resultado de consulta : " & sMensaje)
            Else
                sCodMensaje = "-1"
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, sNroDoc & " - El DNI : " & sNroDoc & "NO se encuentra en el whitelist")
        Finally
            oLog.Log_WriteLog(oFile, sNroDoc & " - *********** FIN VALIDACION DOC CASO ESPECIAL ***********")
        End Try

        Return sCodMensaje
    End Function

    <Anthem.Method()> _
    Public Function ValidarDocCasoEspecial(ByVal sFilaActual As String, ByVal sCampanaActual As String) As String

        Dim objBLCasoEspecial As New BLCasoEspecial
        Dim blEstado As Boolean = False
        Dim sTipoDoc As String = Request.QueryString("TipDoc")
        Dim sNroDoc As String = Request.QueryString("NumDoc")
        Dim sCodMensaje As String
        Dim sMensaje As String
        Dim sParamCampanas As String
        Dim sCampana As String
        Dim sParamMensajes As String

        Try

            oLog.Log_WriteLog(oFile, sNroDoc & " - *********** INICIO VALIDACION DOC CASO ESPECIAL ***********")
            oLog.Log_WriteLog(oFile, sNroDoc & " - Parametro sFilaActual : " & sFilaActual)
            oLog.Log_WriteLog(oFile, sNroDoc & " - Parametro sCampanaActual : " & sCampanaActual)

            sParamMensajes = CargarParamMensajes()

            sParamCampanas = CargarParamCampanas()
            sCampana = "|" + sCampanaActual + "|"

            If (sParamCampanas.IndexOf(sCampana) > -1) Then
                blEstado = objBLCasoEspecial.ValidarAlumno(sTipoDoc, sNroDoc, sCodMensaje, sMensaje)
                oLog.Log_WriteLog(oFile, sNroDoc & " - Resultado de consulta : " & sCodMensaje)
                oLog.Log_WriteLog(oFile, sNroDoc & " - Resultado de consulta : " & sMensaje)
            Else
                sCodMensaje = "-1"
            End If

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, sNroDoc & " - El DNI : " & sNroDoc & "NO se encuentra en el whitelist")
        Finally
            oLog.Log_WriteLog(oFile, sNroDoc & " - *********** FIN VALIDACION DOC CASO ESPECIAL ***********")
        End Try

        Return sCodMensaje + ";" + sFilaActual + ";" + sParamMensajes + ";" + sCampanaActual
    End Function

    Private Function CargarParamMensajes() As String
        Dim objMaestroDatos As New MaestroNegocio
        Dim codGrupo As String = ConfigurationSettings.AppSettings("consGrupoCasoEspecial")
        Dim objParametro As ArrayList
        Dim idLog As String = Request.QueryString("NumDoc")
        Dim factor_parametro As New StringBuilder

        Try
            oLog.Log_WriteLog(oFile, idLog & " - *********** INICIO CARGAR PARAMETROS DE MENSAJES CASO ESPECIAL ***********")
            oLog.Log_WriteLog(oFile, idLog & " - Valor de llave consGrupoCasoEspecial : " & codGrupo)

            objParametro = objMaestroDatos.ListaParametrosGrupo(codGrupo)

            For Each item As Parametro In objParametro
                If item.Valor1 = "3" Then
                    factor_parametro.AppendFormat("{0}", item.Valor)
                End If
            Next
            oLog.Log_WriteLog(oFile, idLog & " - Resulta de parametros de mensajes : " & factor_parametro.ToString())

        Catch ex As Exception
            oLog.Log_WriteLog(oFile, idLog & " - Error al cargar parametros de mensajes caso especial : " & ex.Message.ToString())
        Finally
            oLog.Log_WriteLog(oFile, idLog & " - *********** INICIO CARGAR PARAMETROS DE MENSAJES CASO ESPECIAL ***********")
        End Try

        Return factor_parametro.ToString()
    End Function

    'PROY-32129 :: FIN

End Class
