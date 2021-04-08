<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_packprepago.aspx.vb" Inherits="sisact_packprepago" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Sisact - Reposición de Pack Prepago</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Cache-Control" content="no-cache">
		<meta http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="0">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript" src="../../../librerias/Funciones_PostVenta.js"></script>
		<script language="javascript" type="text/javascript">
			//                     DNI   CIP   CE    RUC   PAS
			var arrayTipoDocPVU = ['01', '02', '04', '06', '07'];
			var arraySizeDocPVU = [ 8  ,  15 ,  9  ,  11 ,  15 ];
   
			function cargarListaPrecios() {
				// Resetear la lista de precios ya agregados
				setValue('txtTotal','0.00');
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				
				// Resetear precios en las Hidden
				resetearMontos();
				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) {
					return false;
				} 
				
				if ( document.getElementById('ddlSerieSIM').length == 0 || document.getElementById('ddlSerieSIM').value == '-- SELECCIONAR --' ) {
					alert('Debe seleccionar una Serie de SIM válida');
					setValue('ddlCampania','00');
					return false;
				}
				if ( document.getElementById('ddlSerieEquipo').length == 0 || document.getElementById('ddlSerieEquipo').value == '-- SELECCIONAR --' ){
					alert('Debe seleccionar una Serie de Equipo válida');
					setValue('ddlCampania','00');
					return false;
				}
				// Obtener la Campania Seleccionada
				var campaniaSelected = getValue('ddlCampania') + "," + getText('ddlCampania');
				setValue('hidCampaniaSelected', campaniaSelected);
														
				var params = "";
				var fecha = new Date();
				
				params = getValue('hidTipoVenta') + "," +
						getValue('hidPlanDefault') + "," +
						getValue('txtCodSIM') + "," +
						getValue('ddlCampania') + "," +
						fecha.format('Y/m/d') + "," +
						getValue('hidTipoOperacion')  + "," +
						getValue('hidOfVenta');
				
				consultarListaPrecios(params);
				
			}
			function resetearMontosEquipo() {
				setValue('hidPrecioTotalEquipo','0.00');
				setValue('hidPrecioSubTotalEquipo','0.00');
			} 
			function resetearMontos() {
				setValue('hidPrecioTotal', '0.00');
				setValue('hidPrecioSubTotal', '0.00');
				setValue('txtTotal', '0.00');				
			}
			function consultarListaPrecios(params) {
				document.getElementById('ifrConsultarListaPrecios').src = "../chip_repuesto/sisact_ifr_consulta_lista_precios.aspx?params="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window.opener;
			}
			function responseConsultarListaPrecios(datos) {
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				// Poner uno a uno lista de precios disponibles
				var listaPrecios = datos.split(';');
				setValue('hidListaPrecios',datos);
				for (var i=0; i<listaPrecios.length; i++) {
					var opcion = listaPrecios[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}
				// Poner Valores por Defecto 
				//cargarListaPrecioDefault();
			}
			//-PANEL SUPERIOR 1 -------------------------------------------------------------------
								
			//Evento combo Vendedor
			function habilitarContinuar() {
				var objDdl = document.getElementById('ddlVendedorSAP');
				var idx = objDdl.selectedIndex;
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hidVendedorSAP', valorTmp + ";" + textoTmp);

			}
			//-----------------------------------------------------------------------------------------
			
			//-PANEL 2 -------------------------------------------------------------------
			function consultar() {
							
				validarCliente();
				var objCombo = document.getElementById('btnArea2').value;
				
				if ( objCombo == 'Buscar' ) {
					if ( !ValidaCampo('document.frmPrincipal.ddlCanal','Debe seleccionar un Canal válido.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.ddlPuntoVenta','Debe seleccionar un Punto de Venta válido.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.ddlVendedorSAP','Debe seleccionar un Vendedor válido.') ) return false;
					
					if ( !ValidaCampo('document.frmPrincipal.ddlTipoDocId','Debe seleccionar un Tipo de Documento.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.txtNumeroDocId','Debe ingresar el número de Documento.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.txtNroLinea','Debe ingresar el número de Línea.') ) return false;	
			
					// Validar longitud Documento
					var indexOf = getIndexOf(arrayTipoDocPVU, getValue('ddlTipoDocId'));
					if (arrayTipoDocPVU[indexOf] == "01" || arrayTipoDocPVU[indexOf] == "04" || arrayTipoDocPVU[indexOf] == "06") {
						if ( getValue('txtNumeroDocId').length != arraySizeDocPVU[indexOf]) {
							alert('Verifique longitud del Número de Documento.');
							setFocus('txtNumeroDocId');
							return false;
						}
					} 
					
					//Validar longitud de telefono
					if (getValue('txtNroLinea').length != 9){
						alert('Error. Número de línea incorrecto / no existe. Digite el número nuevamente.');
						setFocus('txtNroLinea');
						return false;	
					}
					
					setValue('hidAccion', 'Consultar');
					document.frmPrincipal.submit();
					
				} else if ( objCombo == 'Nueva Busqueda' ) {
					alert('entro al ELSE');
					HabilitarControles(true);
					LimpiarControles();
					setVisible('trPasoDetalle', false);
					setVisible('trDetalle', false);
					setVisible('trBotones', false);
					document.getElementById('btnConsultar').value = 'Buscar';
				}
			}
			
			function validaFlujo(mensaje) {
				if(getValue('hidMensajeValidaCliente') == mensaje){
					//document.getElementById('btnArea2').value = 'Nueva Busqueda';
					HabilitarControles(false);
					setVisible('trDatosCliente', true);
					//document.getElementById('btnGenerarPedido').disabled = true;	
				}
			}
			function HabilitarControles(flag) {
				/*document.getElementById('ddlCanal').disabled = !flag;	
				document.getElementById('ddlPuntoVenta').disabled = !flag;	
				document.getElementById('ddlVendedorSAP').disabled = !flag;*/	
								
				document.getElementById('btnArea2').disabled = !flag;	
			
			
				document.getElementById('ddlTipoDocId').disabled = !flag;	
				document.getElementById('txtNumeroDocId').disabled = !flag;
				document.getElementById('txtNroLinea').disabled = !flag;
				
				document.getElementById('txtNroLinea').disabled = !flag;

				if (flag == false) {
					setReadOnly('txtNroLinea',true,'clsInputDisable');
				}
				else if (flag == true) {
					setReadOnly('txtNroLinea',false,'clsInputEnableB');
				}
			}	
			
			function LimpiarControlesDetalle() {
				//AREA 2
				setValue('txtNombre', '');
				setValue('txtApellidoPaterno', '');
				setValue('txtApellidoMaterno','');
				//AREA 3
				setValue('txtTipoVenta','');
				setValue('txtTipoOperacion','');
				setValue('ddlTipoReposicion','00');
				setValue('ddlMotivoReposicion','00');
				//AREA 4
				TipoPrecio = 0;
				setValue('txtTotal','0.00');
				setValue('txtCodSIM','');
				setValue('txtCodEquipo','');
				setValue('ddlArticuloICCID','00');
				setValue('ddlCodEquipo','00');
				setValue('ddlCampania','00');
				setValue('ddlListaPrecio','00');
				setValue('ddlPlanTarifario','<%= ConfigurationSettings.AppSettings("constCodPlanChipRepuesto") %>');
				setValue('ddlSerieSim', '<%= ConfigurationSettings.AppSettings("Seleccionar") %>');
				setValue('ddlSerieEquipo', '<%= ConfigurationSettings.AppSettings("Seleccionar") %>');
				
			
				
				// Resetear
				
				var selObjC = document.getElementById('ddlSerieEquipo');
				selObjC.length = 0;
				var selObjB = document.getElementById('ddlSerieSim');
				selObjB.length = 0;
	
			} 
			
			function LimpiarControlesBusqueda(){
			//AREA 1
				setValue('ddlTipoDocId', '00');
				setValue('txtNumeroDocId', '');
				setValue('txtHlr', '');
				setValue('txtNroLinea', '');
			}
			
			//-PANEL 2 FIN-------------------------------------------------------------------//
			//-PANEL 3 -------------------------------------------------------------------
			 
			function mostrarArea3(accion) {
				if (accion == 1) { 
					setVisible('trDetalleVenta',true); 
					setValue('txtTipoVenta','PREPAGO');
					setValue('txtTipoOperacion','REPOSICION');
					document.getElementById('btnArea3').disabled = true;
					//cargarMotivosReposicion();
				}
				else if (accion == 2) { 
					setVisible('trDetalleVenta',false); 
					setValue('txtTipoVenta','');
					setValue('txtTipoOperacion','');
				}
			}  
			
			//-PANEL 3 FIN-------------------------------------------------------------------//
			//-PANEL 4 ----------------------------------------------------------------------//
			function mostrarArea4(accion) { //
				if (accion == 1) { 
					if ( !ValidaCampo('document.frmPrincipal.ddlTipoReposicion','Debe seleccionar un Tipo de Reposición.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.ddlMotivoReposicion','Debe seleccionar un Motivo de Reposición.') ) return false;	
					
					setVisible('trProductoPack',true); 
					setVisible('trBotones',true);
				}
				else if (accion == 2) { 
					setVisible('trProductoPack',false); 
					setVisible('trBotones',false);
				}
			}
			
			function f_CambiaIccid(){
				// Resetear la lista de precios ya agregados
				setValue('txtTotal','0.00');
				document.getElementById('btnGenerarPedido').disabled = true;
				//setValue('hidPrecioTotalEquipo','0.00');
				setValue('hidPrecioTotal','0.00');
				
				var selObjP = document.getElementById('ddlSerieSim');
				selObjP.length = 1;
				
				var strCanal, strArticulo;
				strCanal = trim(getValue('hidCanal'));
				var puntoVenta = trim(getValue('hidPuntoVenta'));
				strArticulo = document.frmPrincipal.ddlArticuloICCID.value.substring(0,10);
				
				//--------------------------------------------------------------------------------------------
				if ( getValue('ddlArticuloICCID') != "" ) {	
					setValue('txtCodSim', getValue('ddlArticuloICCID'));
				}
				else {
					setFocus('ddlArticuloICCID');
				}
				var objICCID = document.getElementById('ddlArticuloICCID');
				setValue('hidArticuloIccid',objICCID.options[objICCID.selectedIndex].text);
				
				var puntoVenta = trim(getValue('hidOfVenta'));
				var artImei = getValue('ddlArticuloICCID').substring(0,10);
				var telef = "";
				
				llenarHid();
				setValue('ddlCampania','00');
				setValue('ddlListaPrecio','00');
				setValue('hidAccion', 'CargaAreaFinal');
				setValue('hidItemSeleccionado','ddlArticuloICCID');
				document.frmPrincipal.submit();
			//	RSExecute(serverURL,"CargaICCID",artImei,telef,puntoVenta,cbICCID,cbError,"X");
				
			}
			
			function cbICCID(co) {
				if (co.return_value == "") {
					alert("No hay series ICCID disponibles");
				}
				if (co.return_value) {
					strHTML = co.return_value;
					alert(strHTML);
					document.getElementById("tdSerieIccid").innerHTML = strHTML;
				}
			}
					
			function f_CambiaImei() {
				// Resetear la lista de precios ya agregados
				setValue('txtTotal','0.00');
				document.getElementById('btnGenerarPedido').disabled = true;
				setValue('hidPrecioTotalEquipo','0.00');
				
				
				var selObjP = document.getElementById('ddlSerieEquipo');
				selObjP.length = 1;
				
				//var serverURL = "../WEB_SISACT_EXP/paginas/venta_express/sisact_iframe_combo.aspx";
				var serverURL = "../sisact_iframe_combo.aspx";
				
				if ( getValue('ddlCodEquipo') != "" ) {	
					setValue('txtCodEquipo',getValue('ddlCodEquipo'));
				}
				else {
					setFocus('ddlCodEquipo');
				}
				var puntoVenta = trim(getValue('hidOfVenta'));
				var artImei = getValue('ddlCodEquipo').substring(0,10);
				var telef = "";
				
				document.getElementById('hidEqSeleccionado').value = getValue('ddlCodEquipo');
				llenarHid();
				setValue('ddlCampania','00');
				setValue('ddlListaPrecio','00');
				setValue('hidAccion', 'CargaAreaFinal');
				setValue('hidItemSeleccionado','ddlCodEquipo');
				document.frmPrincipal.submit();
				
			//	RSExecute(serverURL,"CargaIMEIS",artImei,telef,puntoVenta,cbImei,cbError,"X"); 
			}
		
			
			function cbError(co) {
				alert("Error callback fired.");
				if (co.message) {
					alert("Context:" + co.context + "\nError: " + co.message);
				}
		    }
	
			function f_CambiaPrecio() {
				if ( getValue('ddlListaPrecio') != "" ) {	
					setValue('hidListaPreciosSeleccionado',getValue('ddlListaPrecio'));
				}
				else {
					setFocus('ddlListaPrecio');
				}
				var puntoVenta = trim(getValue('hidOfVenta'));
				
				document.getElementById('hidListaPreciosSeleccionado').value = getValue('ddlListaPrecio');
				llenarHid();
				setValue('ddlCampania','00');
				setValue('ddlListaPrecio','00');
				setValue('hidAccion', 'CargaAreaFinal');
				setValue('hidItemSeleccionado','ddlCodEquipo');
				document.frmPrincipal.submit();
				
			
			}
			function cargarListaPrecio(){
				if (getValue('hidListaPrecios') != '') {
					var selObjP = document.getElementById('ddlListaPrecio');
					selObjP.length = 0;
					var datos = getValue('hidListaPrecios');
					var listaPrecios = datos.split(';');
					for (var i=0; i<listaPrecios.length; i++) {
						var opcion = listaPrecios[i].split(',');
						addOption(selObjP, opcion[0], opcion[1]);
					}
				}
				if ( getValue('hidListaPreciosSeleccionado') != '' ) {
					setValue('ddlListaPrecio',getValue('hidListaPreciosSeleccionado'));
				}
				
				
			}
			
			
			function llenarHid() {
				 
				//Area 1
				setValue('hidNroLinea',getValue('txtNroLinea'));
				setValue('hidTipoDocumento',getValue('ddlTipoDocId'));
				setValue('hidNroDocumento',getValue('txtNumeroDocId'));
				//Area 3
				setValue('hidMotivoSel',getValue('ddlMotivoReposicion'));
				setValue('hidDesMotivoSel',getText('ddlMotivoReposicion'));
						
				//Area 4
				setValue('hidEqSeleccionado',getValue('ddlCodEquipo'));
				setValue('hidArticuloIccid',getValue('ddlSerieSim'));
				
				setValue('hidListaPreciosSeleccionado', getValue('ddlListaPrecio'));
							
					
			}
		    function cbImei(co) {
				if (co.return_value == "") {
					alert("No hay series IMEIS disponibles");
				}
				if (co.return_value) {
					strHTML = co.return_value;
					alert(strHTML);
					document.getElementById("tdSerieImei").innerHTML = strHTML;
				}
			}
			
			
			// ----- Cargar precio del CHIP -----
			var TipoPrecio = 0; // 0: Precio del Chip // 1: Precio del equipo // 2: Solo Chip // 3: Solo Equipo
			function cargarPrecio() {
				if ( document.getElementById('ddlListaPrecio').value == '00') {
					setValue('ddlSerieSim','<%= ConfigurationSettings.AppSettings("Seleccionar") %>');
					setValue('ddlSerieEquipo','<%= ConfigurationSettings.AppSettings("Seleccionar") %>');
				}
				if ( !ValidaCampo('document.frmPrincipal.ddlListaPrecio','Debe seleccionar una Lista de Precios.') ) {
					setValue('hidPrecioTotal','0.00');
					setValue('hidPrecioSubTotal','0.00');
					setValue('hidPrecioTotalEquipo','0.00');
					setValue('hidPrecioSubTotalEquipo','0.00');
					setValue('txtTotal', '0.00');	
					return false;
				}
				
				
				//document.frmPrincipal.submit();	
				//setValue('hidAccion', 'GenerarPedido');
				//---------------------------------------------------------------------------------------------------------
				// Obtener la Lista de Precio Seleccionado
				var listaPrecioSelected = getValue('ddlListaPrecio') + "," + getText('ddlListaPrecio');
				setValue('hidPLSelected', listaPrecioSelected);
				//alert('TipoPrecio');
				//alert(TipoPrecio);
				var params = "";
				if (TipoPrecio == 2) {
					params = getValue('hidOfVenta') + "," +
							getValue('txtCodSim') + "," +
							getValue('ddlListaPrecio') + "," +
							getText('ddlSerieSim') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocumento');
				}
				else if ( TipoPrecio == 3 ) {
					params = getValue('hidOfVenta') + "," +
							getValue('txtCodEquipo') + "," +
							getValue('ddlListaPrecio') + "," +
							getText('ddlSerieEquipo') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocumento');
				}
				else {
					params = getValue('hidOfVenta') + "," +
							getValue('txtCodSim') + "," +
							getValue('ddlListaPrecio') + "," +
							getText('ddlSerieSim') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocumento');
				}
				consultarPrecios(params);
			}
			
			function cargarPrecioEquipo(){
				
				var params = "";
				params = getValue('hidOfVenta') + "," +
							getValue('txtCodEquipo') + "," +
							getValue('ddlListaPrecio') + "," +
							getText('ddlSerieEquipo') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocumento');
				TipoPrecio = 1;
				
				consultarPrecios(params);	
			}
			
			function consultarPrecios(params) {
				resetearMontos(); // Resetear precios
				document.getElementById('ifrConsultarPrecio').src = "../chip_repuesto/sisact_ifr_consulta_precio.aspx?params="+params;
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
			}
			
			function responseConsultarPrecios(datos) {
				//alert('3');
				var indice = false;
				//alert('Datos');
				//alert(datos);
				// Obtener Precio de Venta - Precio de Lista
				var arrayPrecio = datos.split(',');
				var precioLista = eval(arrayPrecio[2]);
				var precioVenta = eval(arrayPrecio[1]);
				
				if ( TipoPrecio == 0 ) {
					// Precio Venta - Precio Lista
					setValue('hidPrecioTotal', precioVenta);
					setValue('hidPrecioSubTotal', precioLista);
					document.getElementById('btnGenerarPedido').disabled = true;	
				} 
				else if ( TipoPrecio == 1 ) {
					setValue('hidPrecioTotalEquipo', precioVenta);
					setValue('hidPrecioSubTotalEquipo', precioLista);
					TipoPrecio = 0;
					indice = true;
					
					var suma = parseFloat(getValue('hidPrecioTotal')) + parseFloat(getValue('hidPrecioTotalEquipo'));
					setValue('txtTotal', suma);
					
					if ( parseFloat(getValue('hidPrecioTotal')) > 0 ) {
						if (parseFloat(getValue('hidPrecioTotalEquipo')) > 0 ) {
							document.getElementById('btnGenerarPedido').disabled = false;			
						}
						else {
							alert('Seleccione una Serie de Equipo válida');
							document.getElementById('btnGenerarPedido').disabled = true;			
						}
					} else {
						alert('Seleccione una Serie SIM válida');
						document.getElementById('btnGenerarPedido').disabled = true;			
					}
					
					
				}
				else if ( TipoPrecio == 2 ) {
					setValue('hidPrecioTotal', precioVenta);
					setValue('hidPrecioSubTotal', precioLista);
					var suma = parseFloat(getValue('hidPrecioTotal')) + parseFloat(getValue('hidPrecioTotalEquipo'));
					setValue('txtTotal', suma);	
					if (parseFloat(getValue('hidPrecioTotal')) > 0){
						document.getElementById('btnGenerarPedido').disabled = false;	
					} else {
						document.getElementById('btnGenerarPedido').disabled = true;	
					}
				}
				else if ( TipoPrecio == 3 ) {
					setValue('hidPrecioTotalEquipo', precioVenta);
					setValue('hidPrecioSubTotalEquipo', precioLista);
					var suma = parseFloat(getValue('hidPrecioTotal')) + parseFloat(getValue('hidPrecioTotalEquipo'));
					setValue('txtTotal', suma);	
					if ( parseFloat(getValue('hidPrecioTotalEquipo')) > 0) {
						document.getElementById('btnGenerarPedido').disabled = false;	
					}else {
						document.getElementById('btnGenerarPedido').disabled = true;	
					}
					
				}
				
				if ( TipoPrecio == 0 || TipoPrecio == 1) {
					if ( indice == false ) { cargarPrecioEquipo(); }
				}	
				
				
			}
			
			function cancelar(){
				if ( TipoPrecio == 2 ) {
					//alert('Serie de SIM no disponible.');
					setEnabled('btnGenerarPedido', true, 'Boton');		
					setValue('hidPrecioTotal','0.00');
					var suma = parseFloat(getValue('hidPrecioTotal')) + parseFloat(getValue('hidPrecioTotalEquipo'));
					setValue('txtTotal', suma);	
				}
				else if ( TipoPrecio == 3 ) {
					//alert('Serie de Equipo no disponible.');
					setValue('hidPrecioTotalEquipo','0.00');
					setEnabled('btnGenerarPedido', true, 'Boton');		
					var suma = parseFloat(getValue('hidPrecioTotal')) + parseFloat(getValue('hidPrecioTotalEquipo'));
					setValue('txtTotal', suma);	
				}
				else 
				{
					document.getElementById('btnGenerarPedido').disabled = true;	
				}
				
			}
			
			
			function resetearMontos() {
				if ( TipoPrecio == 0 || TipoPrecio == 2 ) {
					setValue('hidPrecioTotal', '0.00');
					setValue('hidPrecioSubTotal', '0.00');
				}
				else if ( TipoPrecio == 1 || TipoPrecio == 3) {
					setValue('hidPrecioTotalEquipo', '0.00');
					setValue('hidPrecioSubTotalEquipo', '0.00');
				}
				//setValue('txtTotal', '0.00');				
			}
			
			
			//-PANEL 4 FIN-------------------------------------------------------------------//
			
			function ocultarPaneles(){ //
				LimpiarControlesBusqueda();
				LimpiarControlesDetalle();
				setVisible('trDatosCliente',false);
				setVisible('trDetalleVenta',false);
				setVisible('trProductoPack',false); 
				setVisible('trBotones',false);
				setValue('hidAccion','');
				HabilitarControles(true);
			}
			function mostrarPaneles(){
				setVisible('trDatosCliente',true);
				setVisible('trDetalleVenta',true);
				setVisible('trProductoPack',true); 
				setVisible('trBotones',true);
			}
			
			function f_CambiaTipoDocumento(valor)
			{
				setValue('txtNumeroDocId','');
				if (valor == '00') {
					setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
					setFocus('ddlTipoDocId');
				}
				else {
					setReadOnly('txtNumeroDocId', false, 'clsInputEnable');

					var indexOf = getIndexOf(arrayTipoDocPVU, valor);
					document.getElementById('txtNumeroDocId').maxLength = arraySizeDocPVU[indexOf];
					setValue('hidMaxLenTipoDoc',arraySizeDocPVU[indexOf]);

					// Validar Ingreso Numerico solo para los Casos DNI y RUC
					if (valor == "01" || valor == "06") { //DNI
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarNumero(event) };
						document.getElementById('txtNumeroDocId').onkeypress = function() { validarNumero(event) };
					}
					else if (valor == "04") { //CE
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarAlfaNumerico(event) };
						document.getElementById('txtNumeroDocId').onkeypress = function() { validarAlfaNumerico(event) };
					}
					setFocus('txtNumeroDocId');
				}			
			}
			
			
			function validarCliente(){
				if ( !ValidaCampo('document.frmPrincipal.ddlTipoDocId','Debe seleccionar un Tipo de Documento.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.txtNumeroDocId','Debe ingresar el número de Documento.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.txtNroLinea','Debe ingresar el número de Línea.') ) return false;																			
			}
			
			function validarBusqueda(){
				alert('entro');
				return false;
			}
			
			function generarAcuerdo() { //
				if ( !ValidaCampo('document.frmPrincipal.ddlCanal','Debe seleccionar un Canal válido.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlPuntoVenta','Debe seleccionar un Punto de Venta válido.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlVendedorSAP','Debe seleccionar un Vendedor válido.') ) return false;
					
				/*alert('Cabecera');
				alert(getValue('hidOfVenta'));	
				alert(getValue('hidNroDocumento'));
				alert(getValue('hidTipoDocumento'));
				alert(getValue('hidTipoVenta'));
				alert(getValue('hidTipoCliente'));
				alert(getValue('hidTipoOperacion'));
				alert(getValue('hidMotivoReposicion'));
				alert(getValue('hidPrecioSubTotal'));
				alert(getValue('hidPrecioSubTotalEquipo'));
				alert(getValue('hidPrecioTotal'));
				alert(getValue('hidPrecioTotalEquipo'));
				alert(getValue('hidCanal'));
				alert(getValue('hidOrgVenta'));
			
				alert('Detalle 1');
				alert(getValue('hidPLSelected'));
				alert(getValue('hidCampaniaSelected'));
				alert(getValue('hidPrecioSubTotal'));
				alert(getValue('hidPrecioTotal'));
				alert(getValue('hidIccid'));
				alert(getText('ddlArticuloICCID'));
				alert(getValue('txtCodSIM'));
				alert(getValue('hidTelefono'));
				
				return false */
				// ---- AREA 2
				// Tipo de Documento 
				if ( getValue('ddlTipoDocId') == '00' || getText('ddlTipoDocId') == '' ||
						getText('ddlTipoDocId')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>'	 ) {
					alert('Debe seleccionar un Tipo de Documento.');
					setFocus('ddlTipoDocId');
					return false;				
				}
				// Numero de documento
				if ( getValue('txtNumeroDocId') == '') {
					alert('Debe ingresar el número de Documento.');
					setFocus('txtNumeroDocId');
					return false;				
				}
				// Numero de linea
				if ( getValue('txtNroLinea') == '') {
					alert('Debe ingresar el número de Línea.');
					setFocus('txtNroLinea');
					return false;				
				}
				// --------------- FIN AREA 2	
				
				//----- AREA 3
				// Tipo de reposicion
				if ( getValue('ddlTipoReposicion') == '00' || getText('ddlTipoReposicion') == '' || 
					getText('ddlTipoReposicion')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar un Tipo de Reposición.');
					setFocus('ddlTipoReposicion');
					return false;				
				}
				// Motivo de reposicion
				if ( getValue('ddlMotivoReposicion') == '00' || getText('ddlMotivoReposicion') == '' || 
					getText('ddlMotivoReposicion')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar un motivo de reposición.');
					setFocus('ddlMotivoReposicion');
					return false;				
				}
				//------------- FIN AREA 3
				
				//--- area 4
				// Descripcion Codigo SIM 
				if ( getValue('ddlArticuloICCID') == '00' || getText('ddlArticuloICCID') == '' ||
						getText('ddlArticuloICCID')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>'	 ) {
					alert('Debe seleccionar una descripción de Código de SIM.');
					setFocus('ddlArticuloICCID');
					return false;				
				}
				// Serie de SIM 								
				if ( getValue('ddlSerieSim') == '00' || getText('ddlSerieSim') == '' ||
						getText('ddlSerieSim')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>'	 ) {
					alert('Debe seleccionar el número de Serie de SIM.');
					setFocus('ddlSerieSim');
					return false;				
				}
				// Descripcion Codigo de Equipo
				if ( getValue('ddlCodEquipo') == '00' || getText('ddlCodEquipo') == '' || 
					getText('ddlCodEquipo')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar una descripción de Código de Equipo.');
					setFocus('ddlCodEquipo');
					return false;				
				}
				// Serie de Equipo
				if ( getValue('ddlSerieEquipo') == '00' || getText('ddlSerieEquipo') == '' || 
					getText('ddlSerieEquipo')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar una Serie de Equipo.');
					setFocus('ddlSerieEquipo');
					return false;				
				}
				// Campaña
				if ( getValue('ddlCampania') == '00' || getText('ddlCampania') == '' || 
					getText('ddlCampania')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar una Campaña.');
					setFocus('ddlCampania');
					return false;				
				}
				
				// Lista de Precios
				if ( getValue('ddlListaPrecio') == '00' || getText('ddlListaPrecio') == '' || 
					getText('ddlListaPrecio')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar una Lista de Precios.');
					setFocus('ddlListaPrecio');
					return false;				
				}
				if ( getValue('ddlPlanTarifario') == '00' || getText('ddlPlanTarifario') == '' || 
					getText('ddlPlanTarifario')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>') {
					alert('Debe seleccionar un Plan Tarifario.');
					setFocus('ddlPlanTarifario');
					return false;				
				}
				//------------- FIN Area 4
					
				
				//nuevo calculo de precio
				/*var listaPrecioSelected = getValue('ddlListaPrecio') + "," + getText('ddlListaPrecio');
				setValue('hidPLSelected', listaPrecioSelected);
				
				var params = "";
				params = getValue('hidOfVenta') + "," +
							getValue('txtCodSim') + "," +
							getValue('ddlListaPrecio') + "," +
							getText('ddlSerieSim') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocumento');
				consultarPrecios(params);
				
			
				
				//--------------------------------
				if ( getValue('hidPrecioTotal') == '0.00' || getValue('hidPrecioSubTotal') == '0.00' ||
					getValue('hidPrecioTotalEquipo') == '0.00' || getValue('hidPrecioSubTotalEquipo') == '0.00'   ) {
					alert('Lista de Precio Inválida. Verifique.');
					
					var HidPrecioTotal = getValue('hidPrecioTotal')
					var hidPrecioSubTotal = getValue('hidPrecioSubTotal')
					var hidPrecioTotalEquipo = getValue('hidPrecioTotalEquipo')
					var hidPrecioSubTotalEquipo = getValue('hidPrecioSubTotalEquipo')
					alert(HidPrecioTotal);
					alert(hidPrecioSubTotal);
					alert(hidPrecioTotalEquipo);
					alert(hidPrecioSubTotalEquipo);
					return false;
				}*/
				//--------------------------------
								
				if ( !confirm("Está seguro de GENERAR el Pedido?") ) {
					return;
				} else {
					setValue('hidAccion', 'GenerarPedido');
					document.frmPrincipal.submit();				
				}			
			}
			
			function cargarICCID(){
				document.getElementById('btnGenerarPedido').disabled = true;
				setValue('hidPrecioTotal','0.00');
				var seleccionar = '<%= ConfigurationSettings.AppSettings("Seleccionar") %>';
				if ( getText('ddlArticuloICCID') == seleccionar) {
					alert('Seleccione un Pack válido.');
					setValue('ddlSerieSim',seleccionar);
					setFocus('ddlArticuloICCID');
					return false;
				}
				setValue('hidIccid',getValue('ddlSerieSim'));
				// Actualiza Precio
				if ( getValue('ddlCampania') != '00' && getValue('ddlListaPrecio') != '00') {
					TipoPrecio = 2;
					cargarPrecio();
				}
				//----
				//setValue('ddlCampania','00');
				//var selObjP = document.getElementById('ddlListaPrecio');
				//selObjP.length = 0;
			}
			
			function cargarSerieEquipo(){
				document.getElementById('btnGenerarPedido').disabled = true;
				setValue('hidPrecioTotalEquipo','0.00');
				var seleccionar = '<%= ConfigurationSettings.AppSettings("Seleccionar") %>';
				if ( getText('ddlCodEquipo') == seleccionar ) {
					alert('Seleccione un Equipo válido.');
					setValue('ddlSerieEquipo',seleccionar);
					setFocus('ddlCodEquipo');
					return false;
				}
				setValue('hidSerieEquipo',getValue('ddlSerieEquipo'));
				// Actualiza Precio
				if ( getValue('ddlCampania') != '00' && getValue('ddlListaPrecio') != '00') {
					TipoPrecio = 3;
					cargarPrecio();
				}
				//----
				//setValue('ddlCampania','00');
				//var selObjP = document.getElementById('ddlListaPrecio');
				//selObjP.length = 0;
			}
			
			function cargarMotivoReposicion() {
				setValue('hidMotivoReposicion', getValue('ddlMotivoReposicion'));
			}
			function validarEnter(event) {
				if (event.keyCode == 13) {
					event.keyCode = 0;
					//document.getElementById('btnConsultar').click();
				}
			}	
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr id="trPaso1">
								<td>
									<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="Header" align="left" colSpan="7" height="20">&nbsp;
												<asp:label id="Label17" Text="Selección del Punto de Venta" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp;
												<asp:label id="Label18" Text="Canal (*)" Runat="server"></asp:label></td>
											<td style="WIDTH: 160px"><asp:dropdownlist id="ddlCanal" runat="server" CssClass="clsSelectEnable" Width="150px"></asp:dropdownlist></td>
											<td class="Arial10b" width="150"><asp:label id="Label19" Text="Punto Venta (*)" Runat="server"></asp:label></td>
											<td style="WIDTH: 220px"><asp:dropdownlist id="ddlPuntoVenta" runat="server" CssClass="clsSelectEnable" Width="200px" onchange="cargarListaVendedores();"></asp:dropdownlist></td>
											<td class="Arial10b" width="120"><asp:label id="Label20" Text="Vendedor (*)" Runat="server"></asp:label></td>
											<td style="WIDTH: 220px"><asp:dropdownlist id="ddlVendedorSAP" runat="server" CssClass="clsSelectEnable" Width="220px" onchange="habilitarContinuar();"></asp:dropdownlist></td>
											<td class="Arial10B" style="WIDTH: 120px" align="right">&nbsp;&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr id="trPerfil"> <!--style="DISPLAY: none"> -->
					<td>
						<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="7" height="20">&nbsp;
									<asp:label id="Label1" Text="Validación del Cliente" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="lblTipoDoc" Text="Tipo Documento (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 180px"><asp:dropdownlist id="ddlTipoDocId" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="150px" onchange="javascript:f_CambiaTipoDocumento(this.value);"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px"><asp:label id="Label21" Text="N° Doc. Identidad (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px" colSpan="2"><asp:textbox onkeypress="validarNumero(event);" id="txtNumeroDocId" onkeydown="validarNumero(event);"
										runat="server" CssClass="clsInputDisable" Width="120px" ReadOnly="True" MaxLength="11"></asp:textbox></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label23" Text="HLR : " Runat="server" Visible="False"></asp:label></td>
								<td class="Arial10B"><asp:textbox id="txtHlr" runat="server" CssClass="clsInputDisable" Width="150px" ReadOnly="true"
										Visible="False"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 120px"><asp:label id="Label22" Text="Número de Línea (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox onkeypress="validarNumero(event);" id="txtNroLinea" onkeydown="validarNumero(event);"
										runat="server" CssClass="clsInputEnableB" Width="120px" MaxLength="9"></asp:textbox></td>
								<td class="Arial10B" align="right" colSpan="2"><input class="Boton" id="btnArea2" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="consultar();" onmouseout="this.className='Boton';" type="button" value="Buscar" name="btnArea2">&nbsp;&nbsp; 
									<!--<asp:button id="btnArea2" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" Text="Buscar" Runat="server" CssClass="Boton" Width="100"
										Height="19" OnClientClick="validarBusqueda();"/> &nbsp;&nbsp;  --><input class="Boton" id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="ocultarPaneles();" onmouseout="this.className='Boton';" type="button" value="Limpiar" name="btnLimpiar">&nbsp;&nbsp;  <!-- onclick="limpiar();" --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr id="trDatosCliente" style="DISPLAY: none">
					<td>
						<table class="contenido" cellSpacing="2" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="6" height="20">&nbsp;Datos del Cliente
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="lbl" Text="Nombre(s): " Runat="server"></asp:label></td>
								<td class="Arial10B" width="150"><asp:textbox id="txtNombre" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="140px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="LabelPaterno" Text="Apellido Paterno: " Runat="server">Apellidos:</asp:label></td>
								<td class="Arial10B" width="150"><asp:textbox id="txtApellidoPaterno" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="170px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label2" Text="Apellido Materno: " Runat="server" Visible="False">Apellido Materno:</asp:label></td>
								<td class="Arial10B" width="150"><asp:textbox id="txtApellidoMaterno" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										Visible="False" width="170px"></asp:textbox></td>
							</tr>
							<tr>
								<td class="Arial10B" align="right" colSpan="6"><input class="Boton" id="btnArea3" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="mostrarArea3(1);" onmouseout="this.className='Boton';" type="button" value="Siguiente -->" name="btnArea3">&nbsp;&nbsp; 
									<!--<asp:button id="btnArea3" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" Text="Siguiente " Runat="server" CssClass="Boton"
										Width="100" Height="19"></asp:button>&nbsp;&nbsp; --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr id="trDetalleVenta" style="DISPLAY: none">
					<td>
						<table class="contenido" cellSpacing="2" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="6" height="20">&nbsp;
									<asp:label id="Label6" Text="Detalle de Venta " Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label3" Text="Tipo de Venta (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" width="170"><asp:textbox id="txtTipoVenta" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="170px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label4" Text="Tipo de Operación (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" width="170"><asp:textbox id="txtTipoOperacion" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="170px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">
								&nbsp;
								<td class="Arial10B" style="WIDTH: 170px"></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label7" Text="Tipo de Reposición (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 170px"><asp:dropdownlist id="ddlTipoReposicion" onkeydown="javascript:validarEnter(event);" runat="server"
										CssClass="clsSelectEnable" Width="170px"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label8" Text="Motivo Reposición (*): " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 170px"><asp:dropdownlist id="ddlMotivoReposicion" onkeydown="javascript:validarEnter(event);" runat="server"
										CssClass="clsSelectEnable" Width="170px" OnChange="cargarMotivoReposicion();"></asp:dropdownlist></td>
								<td class="Arial10B" align="right" colSpan="2"><input class="Boton" id="btnArea4" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="mostrarArea4(1);" onmouseout="this.className='Boton';" type="button" value="Siguiente -->" name="btnArea3">&nbsp;&nbsp; 
									<!--<asp:button id="btnArea4" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" Text="Siguiente " Runat="server" CssClass="Boton" Width="100" Height="19"></asp:button>&nbsp;&nbsp; --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr id="trProductoPack" style="DISPLAY: none">
					<td>
						<table class="contenido" cellSpacing="2" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="6" height="20">&nbsp;
									<asp:label id="Label9" Text="Producto - Pack Prepago Reposición " Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 140px; HEIGHT: 17px">&nbsp;
									<asp:label id="Label10" Text="Cod. de SIM: " Runat="server"></asp:label></td>
								<td class="Arial10B" style="HEIGHT: 17px" width="190"><asp:textbox id="txtCodSIM" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="190px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 350px; HEIGHT: 17px" align="center" colSpan="2">
									<asp:dropdownlist id="ddlArticuloICCID" onkeydown="javascript:validarEnter(event);" runat="server"
										CssClass="clsSelectEnable" Width="300px"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 17px">&nbsp;
									<asp:label id="Label11" Text="Serie de SIM: " Runat="server"></asp:label></td>
								<td class="Arial10B" id="tdSerieIccid" style="WIDTH: 170px; HEIGHT: 17px"><asp:dropdownlist id="ddlSerieSim" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="170px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">&nbsp;
									<asp:label id="Label12" Text="Cod. de Equipo: " Runat="server"></asp:label></td>
								<td class="Arial10B" style="HEIGHT: 16px" width="190"><asp:textbox id="txtCodEquipo" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="190px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 350px; HEIGHT: 16px" align="center" colSpan="2"><asp:dropdownlist id="ddlCodEquipo" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="300px"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">&nbsp;
									<asp:label id="Label13" Text="Serie de Equipo: " Runat="server"></asp:label></td>
								<td class="Arial10B" id="tdSerieImei" style="WIDTH: 170px; HEIGHT: 16px"><asp:dropdownlist id="ddlSerieEquipo" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="170px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label14" Text="Campaña: " Runat="server"></asp:label></td>
								<td class="Arial10B" width="190"><asp:dropdownlist id="ddlCampania" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="190px" onchange="cargarListaPrecios();"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 170px" align="center"><asp:label id="Label16" Text="Lista de Precios: " Runat="server"></asp:label></td>
								<td><asp:dropdownlist id="ddlListaPrecio" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
										Width="170px"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label15" Text="Plan Tarifario: " Runat="server"></asp:label></td>
								<td class="Arial10B" style="WIDTH: 170px"><asp:dropdownlist id="ddlPlanTarifario" onkeydown="javascript:validarEnter(event);" runat="server"
										CssClass="clsSelectEnable" Width="170px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">&nbsp;
									<asp:label id="lblTotal" Text="TOTAL: " Runat="server"></asp:label></td>
								<td class="Arial10B" colSpan="4"><asp:textbox id="txtTotal" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="190px"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="20"></td>
				</tr>
				<tr id="trBotones" style="DISPLAY: none">
					<td align="center">
						<table class="contenido" cellSpacing="0" cellPadding="0" width="280" border="0">
							<tr style="HEIGHT: 50px">
								<td class="Arial10B" style="WIDTH: 50%" align="center">&nbsp; <input class="Boton" id="btnGenerarPedido" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:generarAcuerdo();" onmouseout="this.className='Boton';" type="button" value="Grabar"
										name="btnGenerarPedido" disabled>
								</td>
								<td class="Arial10B" style="WIDTH: 50%" align="center"><input class="Boton" id="btnCancelarPlan" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:ocultarPaneles();" onmouseout="this.className='Boton';" type="button"
										value="Cancelar" name="btnCancelarPlan">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!-- Final del formulario --></table>
			<!-- los hidden que utilizo --><input id="hidAccion" type="hidden" name="hidAccion" runat="server">
			<!-- Area 1 --><input id="hidOperacion" type="hidden" value="Ambos" name="hidOperacion" runat="server">
			<input id="hidNroLinea" type="hidden" name="hidNroLinea" runat="server"> <input id="hidTipoDocumento" type="hidden" name="hidTipoDocumento" runat="server">
			<input id="hidMaxLenTipoDoc" type="hidden" name="hidMaxLenTipoDoc" runat="server">
			<input id="hidMotivoReposicion" type="hidden" name="hidMotivoReposicion" runat="server">
			<input id="hidNroDocumento" type="hidden" name="hidNroDocumento" runat="server">
			<input id="hidItemSeleccionado" type="hidden" name="hidItemSeleccionado" runat="server">
			<input id="hidArticuloIccid" type="hidden" name="hidArticuloIccid" runat="server">
			<input id="hidEqSeleccionado" type="hidden" name="hidEqSeleccionado" runat="server">
			<input id="hidCargaIMEI" type="hidden" name="hidCargaIMEI" runat="server"> <input id="hidCargaICCID" type="hidden" name="hidCargaICCID" runat="server">
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server"> <input id="hidPuntoVenta" type="hidden" name="hidMsg" runat="server">
			<input id="hidVendedorSAP" type="hidden" name="hidMsg" runat="server"> <input id="hidIccid" type="hidden" name="hidIccid" runat="server">
			<input id="hidSerieEquipo" type="hidden" name="hidSerieEquipo" runat="server"> <input id="hidMotivoSel" type="hidden" name="hidMotivoSel" runat="server">
			<input id="hidMotivoDesSel" type="hidden" name="hidMotivoDesSel" runat="server">
			<input id="hidCampanias" type="hidden" name="hidCampanias" runat="server"> <input id="hidTipoVenta" type="hidden" name="hidTipoVenta" runat="server">
			<input id="hidMensajeValidaCliente" type="hidden" name="hidMensajeValidaCliente" runat="server">
			<input id="hidTelefono" type="hidden" name="hidTelefono" runat="server"> <input id="hidTipoCliente" type="hidden" name="hidTipoCliente" runat="server">
			<input id="hidTipoOperacion" type="hidden" name="hidTipoOperacion" runat="server">
			<input id="hidListaPrecios" type="hidden" name="hidListaPrecios" runat="server">
			<input id="hidListaPreciosSeleccionado" type="hidden" name="hidListaPreciosSeleccionado"
				runat="server"> <input id="hidPrecioSubTotal" type="hidden" name="hidPrecioSubTotal" runat="server">
			<input id="hidPrecioTotal" type="hidden" name="hidPrecioTotal" runat="server"> <input id="hidOrgVenta" type="hidden" name="hidOrgVenta" runat="server">
			<input id="hidPLSelected" type="hidden" name="hidPLSelected" runat="server"> <input id="hidCampaniaSelected" type="hidden" name="hidCampaniaSelected" runat="server">
			<input id="hidOfVenta" type="hidden" name="hidOfVenta" runat="server"> <input id="hidCanal" type="hidden" name="hidCanal" runat="server">
			<input id="hidCanalTexto" type="hidden" name="hidCanalTexto" runat="server"> <input id="hidPlanDefault" type="hidden" name="hidPlanDefault" runat="server">
			<input id="hidCampaniaDefault" type="hidden" name="hidCampaniaDefault" runat="server">
			<input id="hidPrecioTotalEquipo" type="hidden" name="hidPrecioTotalEquipo" runat="server">
			<input id="hidPrecioSubTotalEquipo" type="hidden" name="hidPrecioSubTotalEquipo" runat="server">
			<input id="hidTipoPostBack" type="hidden" name="hidTipoPostBack" runat="server">
			<!--Region Iframe --><iframe id="ifrBuscarIccid" name="ifrBuscarIccid" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrConsultarListaVendedores" name="ifrConsultarListaVendedores" width="0" scrolling="no"
				height="0"></iframe><iframe id="ifrConsultarPrecio" name="ifrConsultarPrecio" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrConsultarListaPrecios" name="ifrConsultarListaPrecios" width="0" scrolling="no"
				height="0"></iframe>
			<!-- Fin region iFrame --></form>
		</SCRIPT>
	</body>
</HTML>
 
 
 
 
