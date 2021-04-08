<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_venta_prepago.aspx.vb" Inherits="sisact_ifr_venta_prepago" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact - Pool Venta Express</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Cache-Control" content="no-cache">
		<meta http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="0">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
	
		<script language="javascript">
			function inicio() {
				reset();
				cargarPlan(getValue('hidPlanActual'));
				mostrarMensaje();
			}
			function reset() {
				// Resetear la suma total de Planes
				setValue('txtMontoTotal', '0.00')

				// Resetear los Planes guardados para procesar
				resetPlanes();

				// Resetear los Campos Ingresados
				resetCampos();

				// Resetear el Estado de los Botones de Accion
				resetBotones();
			}
			function resetPlanes() {
				setValue('hidProcesarPlanes', '');
				setValue('hidPlanActual', '1');
				setValueHTML('lblPlan', '1');
			}
			function resetBotones() {
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					//setEnabled('btnBuscarIccid', false, 'Boton');
					setEnabled('btnBuscarImei', false, 'Boton');
				}

				setEnabled('btnAceptarPlan', false, 'Boton');
				var planes = nroPlanesProcesados();
				if ( eval(planes) == 0 ) {
					setEnabled('btnCancelarPlan', true, 'Boton');
					setEnabled('btnGenerarAcuerdo', true, 'Boton');
				}
				else {
					setEnabled('btnCancelarPlan', false, 'Boton');
					setEnabled('btnGenerarAcuerdo', false, 'Boton');
				}
			}
			function resetCampos() {
				//debugger;
				// Plan
				setEnabled('txtPlan', false, "clsInputDisable");
				//debugger
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					// Codigo de Iccid
					setValue('txtIccid', "");
					setEnabled('txtIccid', false, "clsInputDisable"); setReadOnly('txtIccid', true, "clsInputDisable");
					// Codigo de Material de Iccid
					setValue('hidMaterialIccid', "");
					// Descripcion de Articulo de Iccid
					setValue('hidArticuloIccid', "");

					// Número de la Linea
					setValue('txtNroLinea', "");
					setEnabled('txtNroLinea', false, "clsInputDisable"); setReadOnly('txtNroLinea', true, "clsInputDisable");

					// Codigo de Imei
					setValue('txtImei', "");
					setEnabled('txtImei', false, "clsInputEnable"); setReadOnly('txtImei', false, "clsInputEnable");

					// Codigo de Material
					setValue('txtMaterialImei', "");
					setEnabled('txtMaterialImei', false, "clsInputEnable"); setReadOnly('txtMaterialImei', true, "clsInputDisable");
					document.getElementById('txtImei').onkeydown = function(){resetBuscarImei();};

					// Descripcion de Artículo
					setValue('txtArticuloImei', "");
					setEnabled('txtArticuloImei', false, "clsInputEnable"); setReadOnly('txtArticuloImei', true, "clsInputDisable");
				}
				else {
					// Codigo de Iccid
					setValue('txtSerieIccid', "");
					setEnabled('txtSerieIccid', false, "clsInputDisable"); setReadOnly('txtSerieIccid', true, "clsInputDisable");

					// Número de la Linea
					setValue('txtNroLineaCAC', "");
					setEnabled('txtNroLineaCAC', false, "clsInputDisable"); setReadOnly('txtNroLineaCAC', true, "clsInputDisable");

					// Codigo de Imei
					strHTML = '<INPUT class="clsInputDisable" id="txtSerieImei" type="text" readonly style="width:160px">';
					document.getElementById("tdSerieImei").innerHTML = strHTML;

					// Codigo de Material
					setValue('txtMaterialImeiCAC', "");
					setEnabled('txtMaterialImeiCAC', false, "clsInputDisable"); setReadOnly('txtMaterialImeiCAC', true, "clsInputDisable");

					// Descripcion de Artículo
					setEnabled('ddlArticuloIMEI', false, "clsSelectEnable");
					setValue('ddlArticuloIMEI',"0000000000");
				}

				// Codigo de la Campania
				setEnabled('ddlCampania', false, "clsSelectEnable");
				setValue('ddlCampania', "00");
				setValue('hidCampaniaDesc', "");
				seleccionadoCampania(getValue('ddlCampania'));
				// Lista Precio
				setEnabled('ddlPrecio', false, "clsSelectEnable");
				//setValue('ddlPrecio', "00"); // Ya fue cambiado en base a la Campania.
				setValue('hidParamsListaPrecios', "");
				// Precio Respuesta Plan
				setValue('hidRespuestaPrecioPlan', "");
			}
			
			function noEditarPlan() {
				// Campos
				// Plan
				setEnabled('txtPlan', true, "clsInputDisable");

				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					// Codigo de Iccid
					setEnabled('txtIccid', true, "clsInputEnable"); setReadOnly('txtIccid', true, "clsInputEnable");
					// Número de la Linea
					setEnabled('txtNroLinea', true, "clsInputEnable"); setReadOnly('txtNroLinea', true, "clsInputEnable");
					// Codigo de Imei
					setEnabled('txtImei', true, "clsInputEnable"); setReadOnly('txtImei', true, "clsInputEnable");
					document.getElementById('txtImei').onkeydown = "";
					// Codigo de Material
					setEnabled('txtMaterialImei', true, "clsInputEnable"); setReadOnly('txtMaterialImei', true, "clsInputDisable");
					// Descripcion de Artículo
					setEnabled('txtArticuloImei', true, "clsInputEnable"); setReadOnly('txtArticuloImei', true, "clsInputDisable");
				}
				else {
					// Codigo de Iccid
					setEnabled('txtSerieIccid', true, "clsInputEnable"); setReadOnly('txtSerieIccid', true, "clsInputEnable");
					// Número de la Linea
					setEnabled('txtNroLineaCAC', true, "clsInputEnable"); setReadOnly('txtNroLineaCAC', true, "clsInputEnable");
					// Codigo de Imei
					setEnabled('txtSerieImei', true, "clsInputEnable"); setReadOnly('txtSerieImei', true, "clsInputEnable");
					// Codigo de Material
					setEnabled('txtMaterialImeiCAC', true, "clsInputEnable"); setReadOnly('txtMaterialImeiCAC', true, "clsInputEnable");
					// Descripcion de Artículos ICCID - IMEI
					setEnabled('ddlArticuloICCID', true, "clsSelectEnable");
					setEnabled('ddlArticuloIMEI', true, "clsSelectEnable");
				}
				// Codigo de la Campania
				setEnabled('ddlCampania', true, "clsSelectEnable");
				// Lista Precio
				setEnabled('ddlPrecio', true, "clsSelectEnable");
				
				// Botones
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					//setEnabled('btnBuscarIccid', true, 'Boton');
					setEnabled('btnBuscarImei', true, 'Boton');
				}

				setEnabled('btnAceptarPlan', true, 'Boton');
				//setEnabled('btnCancelarPlan', true, 'Boton');
			}

			function nroPlanesProcesados() {
				//Si la variable 'hidProcesarPlanes' tiene datos, el numero de Planes es "restado en 1" (el primero de la lista es vacio)
				var arrayPlanes;
				if (getValue('hidProcesarPlanes') != '')
					arrayPlanes = getValue('hidProcesarPlanes').split('|');
				else
					arrayPlanes = new Array(1);
				var planes = arrayPlanes.length - 1;
				arrayPlanes = null;
				
				return planes;
			}

			function buscarImei() {
				if (getValue('txtImei').length < 14)
				{
				alert("Ingrese el código IMEI completo");
				return;
				}
				// Verificar el Codigo Imei
				if (getValue('txtImei') == "") {
					alert("Error. Serie de Equipo (Imei) es requerido.");
					setFocus('txtImei');
					return;
				}
				// Completar con "0" a la izquierda
				var vImei = '000000000000000000'.substr(getValue('txtImei').length) + getValue('txtImei');
				//setValue('txtImei', '000000000000000000'.substr(getValue('txtImei').length) + getValue('txtImei'));
				if (serieYaProcesado(vImei, 'imei')) {
					alert("Error. Serie de Equipo (Imei) ya ha sido utilizado.");
					setFocus('txtImei');
					return;
				}

				//setValue('txtMaterialImei', '');
				setValue('txtArticuloImei', '');
				
				setEnabled('txtImei', true, "clsInputEnable"); setReadOnly('txtImei', true, "clsInputEnable");
				//document.getElementById("txtImei").readOnly=true;
				document.getElementById("btnCancelarPlan").disabled=false;
				
				document.getElementById("ifrBuscarImei").src= "sisact_ifr_consulta_imei.aspx?codImei="+vImei+"&hidCanal="+getValue('hidCanal')+"&hidOfVentaCod="+getValue('hidOfVenta');
				document.getElementById("ifrBuscarImei").contentWindow.opener = window.opener;
			}
			function respuestaBuscarImei(datos, rspta) {
			//debugger
				var arrayDatos = datos.split(',');

				if (rspta=="Error")
				{
					// Deshabilitar el Validar de nuevo
					setEnabled('btnCancelarPlan', true, 'Boton');
					setEnabled('btnBuscarImei', false, 'Boton');
					setEnabled('txtImei', false, "clsInputEnable"); 
					setReadOnly('txtImei', false, "clsInputEnable");
					setValue('txtMaterialImei',"")
					setValue('txtArticuloImei',"")
					setValue('txtImei',"")
					
					setValue('ddlCampania', '00');
					setValue('ddlPrecio', '00');				
				}
				else
				{
					setValue('txtMaterialImei', arrayDatos[0]);
					setValue('txtArticuloImei', arrayDatos[1]);
					
					// Deshabilitar el Validar de nuevo
					setEnabled('btnBuscarImei', true, 'Boton');
				
					// Cargar Campañas - Valor por default
					cargarCampanias(); 
					setValue('ddlCampania', getValue('hidCampaniaDefault'));
					
					// Cargar Lista de Precios - Valor por default
					cargarListaPrecio();
					cargarListaPrecioDefault();	
					setValue('ddlPrecio', getValue('hidListaPrecioDefault'));		
				}
			}
			function cargarCampanias() {
				// Resetear las campañas ya agregadas
				var selObjC = document.getElementById('ddlCampania');
				selObjC.length = 0;

				// Poner uno a uno las Campañas disponibles
				var campanias = getValue('hidCampanias').split(';');
				for (var i=0; i<campanias.length; i++) {
					var opcion = campanias[i].split(',');
					addOption(selObjC, opcion[0], opcion[1]);
				}
			}
			function cargarListaPrecio() {
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlPrecio');
				selObjP.length = 0;

				// Invocar al iframe, con los parametros necesarios
				var planActual = getValue('hidPlanActual');
				if (getValue('hidPlanes') != '')
					arrayPlanes = getValue('hidPlanes').split('|');
				else {
					arrayPlanes = new Array();
					return;
				}

				var items = arrayPlanes[planActual].split(',');
				var planCodTmp = items[0];
				var planTmp = items[1];
				
				var fecha = new Date();

				var params = "";
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					params = getValue('hidTipoVenta') + "," + planCodTmp + "," + getValue('hidMaterialIccid') + "," +
							getValue('txtMaterialImei') + "," + getValue('ddlCampania') + "," + getValue('hidOfVenta') + "," +
							fecha.format('Y/m/d') + "," + getValue('hidTipoOperacion');
				}
				else{
					params = getValue('hidTipoVenta') + "," + planCodTmp + "," + getValue('ddlArticuloICCID') + "," +
							getValue('txtMaterialImeiCAC') + "," + getValue('ddlCampania') + "," + getValue('hidOfVenta') + "," +
							fecha.format('Y/m/d') + "," + getValue('hidTipoOperacion');
				}

				consultarListaPrecios(params);
			}
				
			function planYaProcesado(idxPlan) {
				//alert("planYaProcesado dentro");
				var response = false;
				var arrayPlanes;
				var Arreglo = document.getElementById('hidProcesarPlanes').value;
				//alert(Arreglo);
				//alert("armo arreglo")
				if (document.getElementById('hidProcesarPlanes').value != '')
					arrayPlanes = Arreglo.split('|');
				else
					arrayPlanes = new Array();
				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(';');
					// Item 0: contiene el valor de Orden de Plan (Ejm: orden,1)
					var ordenTmp = items[0].split(',');
					ordenTmp = ordenTmp[1];
					if (ordenTmp == idxPlan) {
						response = true;
						break;
					}
				}
				arrayPlanes = null;
				return response;
				//alert(response);
			}
			function liberarPlan(idxPlan, flagPreguntar) { // Libera el Plan indicado (segun codificacion nunca podra ser plan actual)
				// Preguntar antes de continuar
				if (flagPreguntar) {
					if ( !confirm("Está seguro de CANCELAR el Plan " + idxPlan + "?") ) {
						return;
					}
				}
				var cadenaAudit = "CancelarPlan," + "0" + "," + getValue('hidOfVenta');

				var arrayPlanes;
				if (getValue('hidProcesarPlanes') != '')
					arrayPlanes = getValue('hidProcesarPlanes').split('|');
				else
					arrayPlanes = new Array();

				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(';');
					// Item 0: contiene el valor de Orden de Plan (Ejm: orden,1)
					var ordenTmp = items[0].split(',');
					ordenTmp = ordenTmp[1];
					if (ordenTmp == idxPlan) {
						var codigoPlan = getValue('hidPlanes').split('|');
						codigoPlan = codigoPlan[ordenTmp].split(',');
						codigoPlan = codigoPlan[0];
						
						var precioPlan = getValue('txtMontoTotal');
						setValue('txtMontoTotal', (eval(getValue('txtMontoTotal')) - eval(precioPlan)).toFixed(2));

						setValue('hidProcesarPlanes', getValue('hidProcesarPlanes').replace('|' + arrayPlanes[i], ''));

						// Cargar valores para Auditoria
						var valoresPlan = arrayPlanes[i].split(";");
						var cadenaAudit = cadenaAudit + ","
										valoresPlan[2].split(",")[1] + "," + valoresPlan[6].split(",")[1];

						break;
					}
				}
				arrayPlanes = null;

				// Auditoria
				document.getElementById("ifrConsultarPrecio").src="sisact_ifr_consulta_precio_.aspx?auditoria="+cadenaAudit;
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
				
				// Cargar el Plan
				cargarPlan(idxPlan);

				// Resetear el Estado de los Botones de Accion
				//resetBotones();
			}
			function cargarPlan(idxPlan) {
				// Resetear los campos antes de utilizarlos
				resetCampos();
				
				// Resetear los botones
				resetBotones();

				var arrayPlanes;
				if (getValue('hidProcesarPlanes') != '')
					arrayPlanes = getValue('hidProcesarPlanes').split('|');
				else
					arrayPlanes = new Array();
				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(';');
					// Item 0: contiene el valor de Orden de Plan (Ejm: orden,1)
					var ordenTmp = items[0].split(',');
					ordenTmp = ordenTmp[1];
					if (ordenTmp == idxPlan) {
						setValueHTML('lblPlan', idxPlan);
						for (var j=1; j<items.length; j++) {
							var keyTmp = items[j].split(',');
							setValue(keyTmp[0], keyTmp[1]);
						}
						break;
					}
				}

				// Poner el Valor del Plan (guardado de forma ordenada al Inicio de la Pag: cod VB)
				if (getValue('hidPlanes') != '')
					arrayPlanes = getValue('hidPlanes').split('|');
				else
					arrayPlanes = new Array();

				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(',');
					var planCodTmp = items[0];
					var planTmp = items[1];
					var nroTelfTmp = items[3];
					var iccidTmp = items[4];

					if (i == idxPlan) {
						setValue('txtPlan', planTmp);
						setValueHTML('lblPlan', idxPlan);
						setValue('hidPlanActual', idxPlan);
						if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
							setValue('txtNroLinea', nroTelfTmp);
							setValue('txtIccid', iccidTmp);
						}
						else{
							setValue('txtNroLineaCAC', nroTelfTmp);
							setValue('txtSerieIccid', iccidTmp);
						}
					}
				}
				arrayPlanes = null;

				// Cargar la lista de Precios
				cargarListaPrecio();

				if (planYaProcesado(idxPlan)) {
					// No permitir editar el Plan
					noEditarPlan();
				}
			}

			function aceptarPlan() {
				// Verificar el Codigo del Plan actual
				//alert("aceptarPlan");
				if (getValue('txtPlan') == "") {
					alert("Error. Plan a contratar es requerido.");
					setFocus('txtPlan');
					return;
				}
				
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					// Verificar el Número de la Linea
					if (getValue('txtNroLinea') == "") {
						alert("Error. Número de la Linea es requerido.");
						setFocus('txtNroLinea');
						return;
					}
					// Verificar el Codigo de Imei (puede vender sin Imei)
					if (getValue('txtImei') == "") {
						alert("Error. Serie de Equipo (Imei) es requerido.");
						setFocus('txtImei');
						return;
					}
					// Verificar el Codigo de Material
					if (getValue('txtMaterialImei') == "") {
						alert("Error. Código de Material de Equipo es requerido.");
						setFocus('txtMaterialImei');
						return;
					}
					// Verificar la Descripcion de Artículo
					if (getValue('txtArticuloImei') == "") {
						alert("Error. Descripción de Artículo de Equipo es requerido.");
						setFocus('txtArticuloImei');
						return;
					}
				}
				else {
					// Verificar el Número de la Linea
					if (getValue('txtNroLineaCAC') == "") {
						alert("Error. Número de la Linea es requerido.");
						setFocus('txtNroLineaCAC');
						return;
					}
					// Verificar el Codigo de Imei
					if (getValue('cboIMEIArt') == "0000000000") {
						alert("Error. Serie Equipo (Imei) es requerido.");
						setFocus('cboIMEIArt');
						return;
					}
					// Verificar el Codigo de Material y Descripcion de Articulo de Iccid
					if (getValue('ddlArticuloIMEI') == "0000000000") {
						alert("Error. Material de Equipo es requerido.");
						setFocus('ddlArticuloIMEI');
						return;
					}
				}
				// Verificar el Codigo de la Campania
				if (getValue('ddlCampania') == "00") {
					alert("Error. Debe seleccionar una Campaña para la oferta comercial.");
					setFocus('ddlCampania');
					return;
				}
				// Verificar la Lista de Precios
				if (getValue('ddlPrecio') == "00") {
					alert("Error. Debe seleccionar un Precio relacionado al plazo de acuerdo bajo la oferta comercial seleccionada.");
					setFocus('ddlPrecio');
					return;
				}
				
				// Preguntar antes de continuar
				var planActual = getValue('hidPlanActual');

				// Obtener el Precio del Plan Actual (segun los datos escogidos por el cliente)
				var cantidad = "1";
				var disponibImei = "";
				var materialIccid = "";
				var nroSEC = "<%= Ctype(Session("SolicitudSelected"), Claro.SisAct.Entidades.SolicitudPersona).SOLIN_CODIGO %>";
				var tipo = "<%= Claro.Sisact.Common.Funciones.CheckStr(Session("TipoVentaExpress")) %>";
				
				var consultaPlan = "";
				//debugger
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
					consultaPlan = getValue('hidOfVenta') + "," + getValue('hidTipoDoc') + "," + materialIccid + "," +
						getValue('txtMaterialImei') + "," + getValue('ddlPrecio') + "," + cantidad + "," + getValue('txtIccid') + "," +
						getValue('txtNroLinea') + "," + getValue('txtImei') + "," + disponibImei + "," + nroSEC + "," + tipo;
				}
				else {
					consultaPlan = getValue('hidOfVenta') + "," + getValue('hidTipoDoc') + "," + materialIccid + "," +
						getValue('txtMaterialImeiCAC') + "," + getValue('ddlPrecio') + "," + cantidad + "," + getValue('cboICCIDArt').substring(0,15) + "," +
						getValue('txtNroLineaCAC') + "," + getValue('cboIMEIArt').substring(0,15) + "," + disponibImei + "," + nroSEC + "," + tipo;
				}
				consultarPrecio(consultaPlan);
			}
			
			function cancelarPlan(){
				// Preguntar antes de continuar
				var planActual = getValue('hidPlanActual');

				//var mensaje = "Está seguro de CANCELAR el Plan " + planActual + " (" + getValue('txtPlan') + ") ?";
				var mensaje = "Está seguro de CANCELAR los datos ingresados para la Renovación?";
				if ( !confirm(mensaje) ) {
					return;
				}
				
				// Liberar Plan Actual
				liberarPlan(planActual, false);
			}
			
			function cargarCampania(idxPlan) {
				// Resetear las campañas ya agregadas
				var selObjC = document.getElementById('ddlCampania');
				selObjC.length = 0;

				// Poner uno a uno las Campañas que deben estar disponibles para el Plan Actual
				var campaniasDisponibles = getValue('hidCampaniasDisponibles').split('|');
				for (var i=1; i<campaniasDisponibles.length; i++) {
					var items = campaniasDisponibles[i].split(';');
					var orden = items[0].split(',');
					if (orden[1] == idxPlan) {
						for (var j=1; j<items.length; j++) {
							var opcion = items[j].split(',');
							addOption(selObjC, opcion[0], opcion[1]);
						}
						break;
					}
				}
				//selObjC.selectedIndex = 0;
			}

			function consultarPrecio(consultaPlan) {
				//alert(consultaPlan)
				setValue('hidConsultaPrecio', consultaPlan);
				document.getElementById("ifrConsultarPrecio").src="sisact_ifr_consulta_precio_.aspx?consultaPlan="+consultaPlan;
				document.getElementById("ifrConsultarPrecio").contentWindow.opener = window.opener;
			}
			
			function respuestaConsultarPrecio(cadenaRespuesta) {
				var planActual = document.getElementById("hidPlanActual").value;
				var objSelCamp = document.getElementById("ddlCampania");
				var objSelPrecio = document.getElementById("ddlPrecio");
				//objSelMatImei.options[objSelMatImei.selectedIndex].text

				var cadenaPlan = "";
				//alert("compara: " + getValue('hidVentaExpress'))
				if (getValue('hidVentaExpress') == "<%= ConfigurationSettings.AppSettings("ExpressVentaDAC") %>"){
				
					var Plan = getValue('txtPlan');
					var Iccid = getValue('txtIccid');
					var MaterialIccid = getValue('hidMaterialIccid');
					var ArticuloIccid = getValue('hidArticuloIccid');
					var NroLinea = getValue('txtNroLinea');
					var Imei = getValue('txtImei');
					var MaterialImei = getValue('txtMaterialImei');
					var ArticuloImei = getValue('txtArticuloImei');
					var Campania = getValue('ddlCampania');
					var Precio = getValue('ddlPrecio');
					if (Campania==0){
						Campania=0
					}
					else
					{
					var ValorCampania = objSelCamp.options[objSelCamp.selectedIndex].text;
					}
		
					var Precio = getValue('ddlPrecio');
					if (Precio =="")
						{
						var ValorPrecio=0
						}
						else
						{
						var ValorPrecio = objSelPrecio.options[objSelPrecio.selectedIndex].text;
						}					
					
					var cadenaRespuesta = cadenaRespuesta;

					cadenaPlan = "|orden," + planActual + ";txtPlan," + Plan + ";txtIccid," + Iccid +
						";hidMaterialIccid," + MaterialIccid + ";hidArticuloIccid," + ArticuloIccid +
						";txtNroLinea," + getValue('txtNroLinea') + ";txtImei," + getValue('txtImei') +
						";txtMaterialImei," + getValue('txtMaterialImei') + ";txtArticuloImei," + getValue('txtArticuloImei') +
						";ddlCampania," + getValue('ddlCampania') + ";hidCampaniaDesc," + objSelCamp.options[objSelCamp.selectedIndex].text +
						";ddlPrecio," + Precio + ";hidPrecioDesc," + ValorPrecio +
						";hidRespuestaPrecioPlan," + cadenaRespuesta;
				}
				else {
					var objSelMatImei = document.getElementById('ddlArticuloIMEI');
					cadenaPlan = "|orden," + planActual + ";txtPlan," + getValue('txtPlan') + ";txtSerieIccid," + getValue('txtSerieIccid') +
						";hidMaterialIccid," + getValue('hidMaterialIccid') + ";hidArticuloIccid," + getValue('hidArticuloIccid') +
						";txtNroLineaCAC," + getValue('txtNroLineaCAC') + ";txtSerieImei," + getValue('cboIMEIArt').split("#")[0] +
						";txtMaterialImeiCAC," + getValue('txtMaterialImeiCAC') + ";ddlArticuloIMEI," + objSelMatImei.options[objSelMatImei.selectedIndex].text +
						";ddlCampania," + getValue('ddlCampania') + ";hidCampaniaDesc," + objSelCamp.options[objSelCamp.selectedIndex].text +
						";ddlPrecio," + getValue('ddlPrecio') + ";hidPrecioDesc," + objSelPrecio.options[objSelPrecio.selectedIndex].text +
						";hidRespuestaPrecioPlan," + cadenaRespuesta + ";ddlArticuloIMEI," + getValue('ddlArticuloIMEI');
				}
				//alert(cadenaPlan)
				// Agregar el Plan a la lista de Planes ya procesados, Si ya fue procesado anteriormente, quitarlo antes de agregarlo
				if (planYaProcesado(planActual)) {
					liberarPlan(planActual, false);
				}

				// Agregar el Plan a la lista de Planes ya procesados
				//setValue('hidProcesarPlanes', getValue('hidProcesarPlanes') + "xxx|xxx|");				
				setValue('hidProcesarPlanes', getValue('hidProcesarPlanes') + cadenaPlan);
				
				var planLibre = getValue('hidPlanActual');
				// Cargar datos del Plan
				cargarPlan(planLibre);
				// Actualizar los Montos (Monto del Plan y Monto Total)
				var arrayPrecios = cadenaRespuesta.split(',');
				var precioPlan = eval(arrayPrecios[1]) + eval(arrayPrecios[5]); // Precio de Ambos productos (Iccid + Imei) incluye IGV
				setValue('txtMontoTotal', (eval(precioPlan)).toFixed(2));

				//resetBotones();
			}
			
			function seleccionadoCampania(control) {
				//reset descripcion precio
				setValue('hidPrecioDesc', "");
				
				// Actualizar la Lista de Precios
				cargarListaPrecio();
			}

			function consultarListaPrecios(params) {
				var items = params.split(',');
				// Si falta alguno de los parametros, no hacer la consulta y retornar la lista de precios solo: "Seleccionar"
				// Podra hacer la venta, sin IMEI
				for (var i=0; i<items.length; i++) {
					if (items[i] == "" || items[i] == "00") {
						if (i != 2) {
							respuestaConsultarListaPrecios("00,<%= ConfigurationSettings.AppSettings("Seleccionar") %>");
							//return;
						}
					}
				}

				setValue('hidParamsListaPrecios', params);
				//alert("parametros lista precio: " + params);
				document.getElementById("ifrConsultarListaPrecios").src= "sisact_ifr_consulta_lista_precios_.aspx?parametros="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window.opener;
				//alert("padre1")
			}
			
			function respuestaConsultarListaPrecios(datos) {
				// Poner uno a uno los Precios de la Lista que deben estar disponibles para la Campaña actual
				var selObjP = document.getElementById('ddlPrecio');
				selObjP.length = 0;
				var preciosDisponibles = datos.split(';');
				for (var i=0; i<preciosDisponibles.length; i++) {
					var opcion = preciosDisponibles[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}

				// Restaurar el valor seleccionado (si lo hubiese)
				var idxPlan = getValue('hidPlanActual');
				var arrayPlanes;
				if (getValue('hidProcesarPlanes') != '')
					arrayPlanes = getValue('hidProcesarPlanes').split('|');
				else
					arrayPlanes = new Array();
				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(';');
					// Item 0: contiene el valor de Orden de Plan (Ejm: orden,1)
					var ordenTmp = items[0].split(',');
					ordenTmp = ordenTmp[1];
					if (ordenTmp == idxPlan) {
						for (var j=1; j<items.length; j++) {
							var keyTmp = items[j].split(',');
							if (keyTmp[0] == "ddlPrecio") {
								setValue(keyTmp[0], keyTmp[1]);
								break;
							}
						}
						break;
					}
				}
				arrayPlanes = null;
				// Poner Valores por Defecto
				//cargarListaPrecioDefault();				
			}
			
			function resetBuscarImei() {
				setEnabled('btnBuscarImei', false, 'Boton');
			}

			function serieYaProcesado(codSerie, tipo) {
				var response = false;
				var arrayPlanes;
				if (getValue('hidProcesarPlanes') != '')
					arrayPlanes = getValue('hidProcesarPlanes').split('|');
				else
					arrayPlanes = new Array();
					
				var idx;
				// Item 2: contiene el valor de la Serie Iccid
				if (tipo == 'iccid') { idx=2; }
				// Item 6: contiene el valor de la Serie Imei
				else if (tipo == 'imei') { idx=6; }
				else {
					alert("Error. Tipo de Serie no definido.");
					arrayPlanes = null;
					return true;
				}
				for (var i=1; i<arrayPlanes.length; i++) {
					var items = arrayPlanes[i].split(';');
					var serieTmp = items[idx].split(',')[1];
					if (serieTmp == codSerie) {
						response = true;
						break;
					}
				}
				arrayPlanes = null;
				return response;
			}

			function generarAcuerdo() {
				// Verificar el Total de Planes aprobados
				var planes = nroPlanesProcesados();
				//alert(planes)
				if ( eval(planes) == 0 ) {
					alert("Error. Debe Aceptar por lo menos un Plan Prepago antes de Generar el Pedido.");
					return;
				}
				// Preguntar antes de continuar
				if ( !confirm("Está seguro de GENERAR el Pedido?") ) {
					return;
				}
				//Generar el Acuerdo

				// Obtener el Monto Total (con IGV, sin IGV) de todo el pedido
				setValue('hidPrecioSubTotal', '0.00');
				setValue('hidPrecioTotal', '0.00');

				var arrayPlanes = getValue('hidProcesarPlanes').split('|');
				//alert("arrayPlanes : " + arrayPlanes)
				for (var i=1; i<arrayPlanes.length; i++) {
					var elms = arrayPlanes[i].split(';')[13].split(',');
					//alert("elms: " + elms);
					setValue('hidPrecioSubTotal', (eval(getValue('hidPrecioSubTotal')) + eval(elms[4]) + eval(elms[8])).toFixed(2));
					setValue('hidPrecioTotal', (eval(getValue('hidPrecioTotal')) + eval(elms[2]) + eval(elms[6])).toFixed(2));
				}

				setValue('hidRequest', 'GenerarAcuerdo');
				//alert("submit!!!");
				document.frmDetalleVenta.submit();
			}
			
			function f_CambiaImei() {
				var serverURL = "../sisact_iframe_combo.aspx";
				
				if ( getValue('ddlArticuloIMEI') != "" ) {		
					setValue('txtMaterialImeiCAC',getValue('ddlArticuloIMEI'));
				}
				else {
					setFocus('ddlArticuloIMEI');
				}
				var puntoVenta = trim(getValue('hidOfVenta'));
				var artImei = getValue('ddlArticuloIMEI').substring(0,10);
				var telef = "";

				RSExecute(serverURL,"CargaIMEIS",artImei,telef,puntoVenta,cbImei,cbError,"X");
			}

		    function cbError(co) {
				alert("Error callback fired.");
				if (co.message) {
					alert("Context:" + co.context + "\nError: " + co.message);
				}
		    }

		    function cbImei(co) {
				if (co.return_value == "") {
					alert("No hay series IMEIS disponibles");
				}
				if (co.return_value) {
					strHTML = co.return_value;
					document.getElementById("tdSerieImei").innerHTML = strHTML;
				}
			}
			function resetearMontos() {
				setValue('hidPrecioTotal', '0.00');
				setValue('hidPrecioSubTotal', '0.00');
				setValue('txtTotal', '0.00');				
			}
			function cargarListaPrecioDefault() {
				if (getValue('ddlCampania') == getValue('hidCampaniaDefault')) {
					// Si existe la Lista de Precio poner x defecto
					var selObjP = document.getElementById('ddlPrecio');
					for (var i=0; i<selObjP.options.length; i++) {
						//alert(selObjP.options[i].value + " = " + getValue('hidListaPrecioDefault'));
						if (selObjP.options[i].value == getValue('hidListaPrecioDefault')) {
							setValue('ddlPrecio', getValue('hidListaPrecioDefault'));
							break;
						}
					}
				}
			}

			function f_ValidaIngreso(CaracteresPermitidos)   {
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++) 
				{
						if (key == valid.substring(i,i+1))
							ok = "yes"        				
														
				}
				if (ok == "no")
						window.event.keyCode=0
			}			
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="inicio();" onkeydown="cancelBack();"
		MS_POSITIONING="GridLayout" marginheight="0" marginwidth="0">
		<form id="frmDetalleVenta" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<!-- Inicio Tabla Detalle de la Venta -->
				<tr id="trPaso4">
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<!-- Inicio Tabla Datos de los Planes -->
							<tr id="trPlanesDetalle">
								<td>
									<table cellPadding="0" width="100%" border="0">
										<!--tr>
											<td class="header" style="HEIGHT: 20px">&nbsp;Detalle de la Venta</td>
										</tr-->
										<tr>
											<td id="tdPlan" style="WIDTH: 100%; HEIGHT: 250px" vAlign="top">
												<table class="contenido" height="100%" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" height="20">&nbsp;Detalle de la Venta</td>
													</tr>
													<tr>
														<td class="contenido">
															<table cellSpacing="5" cellPadding="0" width="100%" border="0">
																<tr>
																	<td class="Arial10B" style="WIDTH: 145px">&nbsp;Plan</td>
																	<td class="Arial10B" style="WIDTH: 10px">:</td>
																	<td class="Arial10B" style="WIDTH: 670px">&nbsp;<asp:textbox id="txtPlan" runat="server" Width="210px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																</tr>
																<tr id="trVentaDAC" runat="server">
																	<td colSpan="3">
																		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Número de la Línea</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 300px" colSpan="4">&nbsp;<asp:textbox id="txtNroLinea" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Serie Equipo (Imei)</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 300px" colSpan="4">
																					&nbsp;<asp:textbox onkeypress="f_ValidaIngreso('0123456789');" id="txtImei" onPaste="return false;"
																						onkeydown="resetBuscarImei();" disabled runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable" MaxLength="15"></asp:textbox>
																					&nbsp;&nbsp;<input class="Boton" id="btnBuscarImei" onmouseover='this.className="BotonResaltado";'
																						style="WIDTH: 80px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:buscarImei();" onmouseout='this.className="Boton";'
																						type="button" value="Validar Imei" name="btnBuscarImei">
																				</td>
																			</tr>
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Código de Material</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 200px">&nbsp;<asp:textbox id="txtMaterialImei" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Descripción de Artículo</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 220px">&nbsp;<asp:textbox id="txtArticuloImei" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr id="trVentaCAC" runat="server">
																	<td colSpan="3">
																		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 18px">&nbsp;Número de la Línea</td>
																				<td class="Arial10B" style="WIDTH: 10px; HEIGHT: 18px">:</td>
																				<td class="Arial10B" style="WIDTH: 300px; HEIGHT: 18px" colSpan="2">&nbsp;<asp:textbox id="txtNroLineaCAC" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Descripción de Artículo</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 200px">&nbsp;<asp:dropdownlist id="ddlArticuloIMEI" runat="server" Width="260px" CssClass="clsSelectEnable"></asp:dropdownlist></td>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Serie Equipo (Imei)</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" id="tdSerieImei" style="WIDTH: 220px">&nbsp;<INPUT class="clsInputDisable" id="txtSerieImei" readOnly type="text" size="15" Width="120px"></td>
																			</tr>
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Código de Material</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 300px" colSpan="2">&nbsp;<asp:textbox id="txtMaterialImeiCAC" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td colSpan="3">
																		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Campaña</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 200px">&nbsp;<asp:dropdownlist id="ddlCampania" runat="server" CssClass="clsSelectEnable" onchange="javascript:seleccionadoCampania(this);"
																						width="260px"></asp:dropdownlist>
																					<input id="hidCampaniaDesc" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCampaniaDesc"
																						runat="server">
																				</td>
																				<td class="Arial10B" style="WIDTH: 150px">&nbsp;Lista de Precios</td>
																				<td class="Arial10B" style="WIDTH: 10px">:</td>
																				<td class="Arial10B" style="WIDTH: 220px">&nbsp;<asp:dropdownlist id="ddlPrecio" runat="server" CssClass="clsSelectEnable" onchange="javascript:aceptarPlan();"
																						width="160px"></asp:dropdownlist>
																					<input id="hidPrecioDesc" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioDesc"
																						runat="server">
																				</td>
																			</tr>
																		</table>
																	</td>
																<tr>
																	<td colSpan="3">
																		<table cellSpacing="0" cellPadding="0" width="50%" border="0">
																			<tr style="HEIGHT: 30px">
																				<td class="Arial10B" style="WIDTH: 80px">&nbsp;Total S/.</td>
																				<td class="Arial10B" style="WIDTH: 15px">:</td>
																				<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtMontoTotal" style="FONT-WEIGHT: bold; TEXT-ALIGN: right" runat="server" Width="95px"
																						enabled="false" cssclass="clsInputEnable" value="0.00"></asp:textbox></td>
																			</tr>
																		</table>
																	</td>
																</tr>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table cellSpacing="0" cellPadding="0" width="50%" border="0">
													<tr style="HEIGHT: 30px">
														<td class="Arial10B" style="WIDTH: 50%" align="center">
															<input class="Boton" id="btnGenerarAcuerdo" onmouseover="this.className='BotonResaltado';"
																style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:generarAcuerdo();"
																onmouseout="this.className='Boton';" type="button" value="Grabar" name="btnGenerarAcuerdo">
														</td>
														<td class="Arial10B" style="WIDTH: 50%" align="center"><input class="Boton" id="btnCancelarPlan" onmouseover="this.className='BotonResaltado';"
																style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:cancelarPlan();" onmouseout="this.className='Boton';" type="button"
																value="Cancelar" name="btnCancelarPlan">
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- Fin Tabla Datos de los Planes --></table>
			</td></tr></table><input id="hidCampaniaDefault" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidCampaniaDefault" runat="server"> <input id="hidListaPrecioDefault" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidListaPrecioDefault" runat="server"> <input id="hidPlanDefault" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPlanDefault"
				runat="server"> <input id="hidMsg" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
				runat="server"> <input id="hidNumeroPlanes" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidNumeroPlanes"
				runat="server"> <input id="hidPlanes" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPlanes"
				runat="server"> <input id="hidProcesarPlanes" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidProcesarPlanes" runat="server"> <input id="hidPlanActual" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPlanActual"
				runat="server"> <input id="hidCampaniasDisponibles" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidCampaniasDisponibles" runat="server"> <input id="hidConsultaPrecio" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidConsultaPrecio" runat="server"> <input id="hidCampanias" type="hidden" name="hidCampanias" runat="server">
			<input id="hidPLSelected" type="hidden" name="hidPLSelected" runat="server"> <input id="hidRespuestaPrecioPlan" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidRespuestaPrecioPlan" runat="server"> <input id="hidPrecioSubTotal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidPrecioSubTotal" runat="server"> <input id="hidPrecioTotal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioTotal"
				runat="server"> <input id="hidOfVenta" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidOfVenta"
				runat="server"> <input id="hidCanal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCanal"
				runat="server"><input id="hidOfVentaDesc" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidOfVentaDesc"
				runat="server"> <input id="hidScoreCred" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidScoreCred"
				runat="server"> <input id="hidPlazoAcuerdo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPlazoAcuerdo"
				runat="server"> <input id="hidTipoDoc" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoDoc"
				runat="server"> <input id="hidTipoCliente" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoCliente"
				runat="server"> <input id="hidTipoVenta" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoVenta"
				runat="server"> <input id="hidTipoOperacion" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoOperacion"
				runat="server"> <input id="hidVendedor" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidVendedor"
				runat="server"> <input id="hidTipoDocPrefijo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidTipoDocPrefijo" runat="server"> <input id="hidPrefijo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidPrefijo"
				runat="server"> <input id="hidFlagPrefijoManual" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFlagPrefijoManual" runat="server"> <input id="hidNroContrato" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidNroContrato"
				runat="server"> <input id="hidNroPedido" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidNroPedido"
				runat="server"> <input id="hidNroDeposito" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidNroDeposito"
				runat="server"> <input id="hidParamsListaPrecios" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
				name="hidParamsListaPrecios" runat="server"> <iframe id="ifrBuscarIccid" name="ifrBuscarIccid" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrBuscarImei" name="ifrBuscarImei" frameBorder="0" width="0" scrolling="yes"
				height="0"></iframe><iframe id="ifrConsultarListaPrecios" name="ifrConsultarListaPrecios" width="0" scrolling="no"
				height="0"></iframe><iframe id="ifrBuscarPrefijo" name="ifrBuscarPrefijo" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrConsultarPrecio" name="ifrConsultarPrecio" width="1" scrolling="200" height="0">
			</iframe><iframe id="ifrConsultarDesArticulos" name="ifrConsultarDesArticulos" width="0" scrolling="no"
				height="0"></iframe><input id="hidRequest" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidRequest"
				runat="server"> <input id="hidResponse" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidResponse"
				runat="server"> <input id="hidVentaExpress" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidVentaExpress"
				runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
