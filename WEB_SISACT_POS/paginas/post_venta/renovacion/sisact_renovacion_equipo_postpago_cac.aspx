<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_renovacion_equipo_postpago_cac.aspx.vb" Inherits="sisact_renovacion_equipo_postpago_cac"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact - Renovacion Equipo Postpago CAC</title>
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
		<style type="text/css">
		.Monto { TEXT-ALIGN: right }
		#dgSaldosCC { MARGIN-TOP: -15px; MARGIN-BOTTOM: -18px; MARGIN-LEFT: 5px }
	.DeshabilitadoCC { COLOR: #6e6e6e }
		</style>
		<script language="javascript" type="text/javascript">
			//                     DNI   CIP   CE    RUC   PAS
			var arrayTipoDocPVU = ['01', '02', '04', '06', '07'];
			var arraySizeDocPVU = [ 8  ,  15 ,  9  ,  11 ,  15 ];
			
			var constFlagClaroClub = '<%=ConfigurationSettings.AppSettings("constFlagClaroClub")%>';
			var cursorSaldos = new HashTable();
			
			function inicio() {	
				habilitarBoton('btnGrabar');
				habilitarBoton('btnCancelarPedido');
				setearBusqueda();
				mostrarMensaje();
			}
			
			function validarReintegro(){
				
				setReadOnly('txtNumeroDocId', false, 'clsInputEnableB');
				// Inicio E77568				
				var hidMesesPorVencerApadece =  getValue('hidMesesPorVencerApadece');
				if (parseFloat(hidMesesPorVencerApadece) > 1.0) {
				// Fin E77568
				
					if (  (getValue('hidFlagRenovacionAdelantada') == 'true') && (getValue('hidFlagConfExoneracionReintegro') == 'false')   ){
							
						if(confirm('El Cliente cuenta con APADECE Vigente, desea realizar una Renovación Anticipada.'  )){
						
							if (getValue('hidFlagReintegro') == 'true'){
								if(confirm('El monto de Reintegro es: "S/.'+ parseFloat(getValue('hidReintegro')).toFixed(2).toString() + '", desea realizar la exoneración del reintegro.'  )){
									
									// Inicio E77568
									// var hidMesesPorVencerApadece =  getValue('hidMesesPorVencerApadece')
									// Fin E77568
									
									setValue('hidOpcionAutorizacion','PERMITIR_RENOVACION_ANTICIPADA_CON_EXONERACION');
									// Inicio E77568
									// PROY-7045 - RF01
									// SISACT NO deberá solicitar ingresar ninguna autorización del asesor.
									var MesesMaxAS = parseFloat(getValue('hidMesesMaxAS'));
									if(parseFloat(hidMesesPorVencerApadece) > MesesMaxAS){
										solicitaAutorizacion('Aprobacion Renovacion Adelantada',hidMesesPorVencerApadece,'2');
									}else{
										FC_GrabarCommit('');
									}
									return false;
									
									// Fin E77568
															
								}else{
								
									/*var hidMesesPorVencerApadece =  getValue('hidMesesPorVencerApadece')
									
									setValue('hidOpcionAutorizacion','PERMITIR_RENOVACION_ANTICIPADA_SIN_EXONERACION');
									solicitaAutorizacion('Aprobacion Renovacion Adelantada',hidMesesPorVencerApadece,'2');
									return false;	
									*/
									setValue('hidFlagConfExoneracionReintegro','true');
									setValue('hidFlagExonerarReintegro','false');
									setValue('txtReintegro', parseFloat(getValue('hidReintegro')).toFixed(2) );
									setValue('txtReintegroAFacturar', parseFloat(getValue('hidReintegro')).toFixed(2) );
											
									setValue('hidOpcionAutorizacion','');
									
									mostrarConsulta();
									
								}
							}else{
								setValue('hidFlagConfExoneracionReintegro','false');
								setValue('hidFlagExonerarReintegro','false');
								setValue('txtReintegro', '0.00' );
								setValue('txtReintegroAFacturar', '0.00' );
								return true;
							}
						}else{
						
							LimpiarControles();
							HabilitarBusqueda();
							
							return false;
							
						}
												
					}
				// Inicio E77568			
				} else {
						setValue('hidOpcionAutorizacion','PERMITIR_RENOVACION_NORMAL_CON_EXONERACION'); 
						FC_GrabarCommit('');
				}
				// Fin E77568				
			}
			
			function setearBusqueda(){
				//HabilitarBusqueda();
				//si se encuentra buscando desabilitar controles de busqueda
				if(getValue('hidFlagBuscando') == "true"){
					DeshabilitarBusqueda();
					//alert(getValue('hidFlagBuscando'));
				}else{
					HabilitarBusqueda();
				}
				
				if(getValue('hidFlagBuscandoPaso1') == "true"){
					//alert(getValue('hidFlagBuscandoPaso1'));
					//MostrarArea1(true);
					desabilitarBoton('btnSiguiente');
					desabilitarBoton('btnCancelar');
				
				}else{
					
					habilitarBoton('btnSiguiente');
					habilitarBoton('btnCancelar');
				
				}
				
				if(getValue('hidFlagDescuento') == "true"){
					desabilitarBoton('btnDescuentoEquipo');
				}else{
					habilitarBoton('btnDescuentoEquipo');
				}
				
			}
			
			function resetearBusquedaXSerie(){
			
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				
				resetearMontos();
				habilitarDescuento();
				
				setValue('ddlPlanTarifario','');
				setValue('ddlPlazoAcuerdo','00');
				
			}
			
			function resetearBusquedaXCampania(){
							
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				
				resetearMontos();
				habilitarDescuento();
											
				setValue('ddlPlanTarifario','');
				setValue('ddlPlazoAcuerdo','00');
				
			}
			
			function cargarListaPrecios() {
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 1;
				
				// Resetear precios en las Hidden
				resetearMontos();
				habilitarDescuento();
				
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				
				setValue('ddlPlazoAcuerdo','00');

				if ( document.getElementById('ddlSerieEquipo').length == 0 || getText('ddlSerieEquipo')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>' || 
					 getText('ddlSerieEquipo')== '' ){
					alert('Debe seleccionar una Serie de Equipo válida');
					setValue('ddlCampania','00');
					return false;
				}

				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) {
					setValue('ddlCampania','00');
					return false;
				}
				
				if ( !ValidaCampo('document.frmPrincipal.ddlPlanTarifario','Debe seleccionar un Plan Tarifario.') ) {
					setValue('ddlPlanTarifario','');
					return false;
				}
								
				
														
				var params = "";
				var fecha = new Date();
				
				params = getValue('hidTipoVenta') + "," +
						getValue('ddlPlanTarifario') + "," + 
						getValue('txtCodEquipo') + "," + //txtCodSIM
						getValue('ddlCampania') + "," +
						fecha.format('Y/m/d') + "," +
						getValue('hidTipoOperacion')  + "," +
						getValue('hidOfVenta');
				
				//alert(params);
				
				/*hidTipoVenta = 01
				PlanTarifario: 342
				txtCodEquipo: PBN6101001
				Campaña: 0136
				Fecha: 2012/10/12
				TipoOperacion: 11
				Oficina Venta : 0006*/
				
				consultarListaPrecios(params);
			}
			
			
			function resetearMontos() {
				setValue('hidPrecioVenta', '');
				setValue('hidPrecioTotal', '');
				setValue('hidDescuento','');
				
				setValue('txtPrecioVenta','');
				setValue('txtTotalAPagar', '');						
				setValue('txtDescuentoEquipo','');
				
				setValue('hidFlagDescuento','false');
					
			}
			
			function habilitarDescuento()
			{
				setValue('hidDescuento','');
				setValue('txtDescuentoEquipo','');
				
				setValue('hidFlagDescuento','false');
				habilitarBoton('btnDescuentoEquipo');
				setReadOnly('txtDescuentoEquipo', false, 'clsInputEnableB');
				
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
				for (var i=0; i<listaPrecios.length; i++) {
					var opcion = listaPrecios[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}
				// Poner Valores por Defecto 
				//cargarListaPrecioDefault();
			}
			
			function mostrarMensaje() {
				if (getValue('hidMsg') != '') {				
					alert(getValue('hidMsg'));
					setValue('hidMsg','');				
				}
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
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarNumeroPermitirControl(event) };
						//document.getElementById('txtNumeroDocId').onkeypress = function() { validarNumeroPermitirControl(event) };
					}
					else if (valor == "04") { //CE
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarAlfaNumerico(event) };
						document.getElementById('txtNumeroDocId').onkeypress = function() { validarAlfaNumerico(event) };
					}
					setFocus('txtNumeroDocId');
				}			
			}
			
			function consultar(){
				
				var objCombo = document.getElementById('btnConsultar').value;

				if ( objCombo == 'Buscar' ) {
						
										
					if ( !ValidaCampo('document.frmPrincipal.ddlTipoDocId','Debe seleccionar un Tipo de Documento.') ) return false;
					if ( !ValidaCampo('document.frmPrincipal.txtNumeroDocId','Debe ingresar el número de Documento.') ) return false;

					// Validar longitud Documento
					var indexOf = getIndexOf(arrayTipoDocPVU, getValue('ddlTipoDocId'));
					if (arrayTipoDocPVU[indexOf] == '04') { //CE puede tener entre 8 y 9 digitos
						if ( getValue('txtNumeroDocId').length < arraySizeDocPVU[indexOf] - 1 || getValue('txtNumeroDocId').length > arraySizeDocPVU[indexOf]) {
							alert('Numero de Documento debe contener por lo menos ' + (arraySizeDocPVU[indexOf] - 1) + ' caracteres.');
							setFocus('txtNumeroDocId');
							return false;
						}
					} else {
					
						//Validar si el valor de txtNumeroDocId son numeros
						 if (!/^([0-9])*$/.test(getValue('txtNumeroDocId'))){
							alert("Numero de Documento no es un número");
							setFocus('txtNumeroDocId');
							return false;
						}
						
						// Validar Ingreso Numerico para los Casos DNI y RUC
						if ( getValue('txtNumeroDocId').length != arraySizeDocPVU[indexOf]) {
							alert('Número de Documento debe contener ' + arraySizeDocPVU[indexOf] + ' caracteres.');
							setFocus('txtNumeroDocId');
							return false;
						}
					}

					//Validar si el valor de txtNroLinea son numeros
					if (!/^([0-9])*$/.test(getValue('txtNroLinea'))){
						alert("Numero de Línea no es un número");
						setFocus('txtNroLinea');
						return false;
					}
					
					// Validar nro Línea
					if ( getValue('txtNroLinea').length != 9) {
						alert("Numero de Línea no válida.");
						setFocus('txtNroLinea');
						return false;
					}

					// Setear Nro, Tipo Documento y Línea
					setValue('hidNroDocumento', getValue('txtNumeroDocId'));
					setValue('hidTipoDocumento', getValue('ddlTipoDocId'));
					setValue('hidNroLinea', getValue('txtNroLinea'));

					setValue('hidAccion', 'Consultar');
					
					LimpiarControlesDetalle();
					
					document.frmPrincipal.submit();

				} else if ( objCombo == 'Nueva Busqueda' ) {
													
					LimpiarControles();
					HabilitarBusqueda();
					MostrarArea1(false);
					LimpiarControlesDetalle();
					
					setValue('btnConsultar','Buscar');
					setFocus('btnConsultar');
				}
			}
			
				/*if (getValue('btnConsultar') == "Buscar"){
				
					setValue('btnConsultar','Nueva Búsqueda');
				
					//deshabilitar campos busqueda
					document.getElementById('ddlTipoDocId').disabled = true;				
					setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
					setReadOnly('txtNroLinea', true, 'clsInputDisable');
					
				
					setVisible('trDatosCliente',true); 
					setVisible('trDatosLinea',true); 
					setVisible('trDatosFacturacion',true); 
				
					setFocus('btnSiguiente');
				}else if(getValue('btnConsultar') == "Nueva Búsqueda"){
					cancelarPaso();
				}
				
			}*/
			
			
			
			function siguiente(){
				setVisible('trDetalleVenta',true); 
				
				setFocus('ddlMaterial');
				
				desabilitarBoton('btnSiguiente');
				desabilitarBoton('btnCancelar');
				
				setValue('hidFlagBuscandoPaso1','true');
				
				// Inicio E77568
				// PS - Automatización de canje y nota de crédito.
				if (getValue('hidTieneReserva') != "1") {
					setValue('txtDescuentoClaroClub', getValue('txtClaroClubSolesDeDescuento'));
				}
				// PS - Automatización de canje y nota de crédito.
				// Fin E77568				
			}
			function OcultarAreas(){
				// Inicio E77568
				// PS - Automatización de canje y nota de crédito.
				setVisible('trPuntosClaroClub',false); 
				VisualizarSaldosCC(false);
				// PS - Automatización de canje y nota de crédito.
				// Fin E77568
				setVisible('trDatosCliente',false); 
				setVisible('trDatosLinea',false); 
				setVisible('trDatosFacturacion',false); 
				setVisible('trDetalleVenta',false); 
			}
			
			function cancelar(){
				//LimpiarControlesDetalle();
				resetearMontos();
				habilitarDescuento();
			}
			
			function cancelarPaso(){
				
				LimpiarControlesDetalle();
				OcultarAreas();
				HabilitarBusqueda();
				
				setFocus('btnConsultar');
			}
			
			function cancelarPedido(){
				
				LimpiarControlesDetalle();
				OcultarAreas();
				HabilitarBusqueda();
				
				setFocus('btnConsultar');
			}
			
			function validarEnter(event) {
				if (event.keyCode == 13) {
					event.keyCode = 0;
					document.getElementById('btnConsultar').click();
				}
			}
			
			//deshabilitar campos busqueda
			function DeshabilitarBusqueda(){
				
				habilitarBoton('btnSiguiente');
				habilitarBoton('btnCancelar');
					
				setValue('hidFlagBuscando','true');				
					
				document.getElementById('ddlTipoDocId').disabled = true;				
				setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
				setReadOnly('txtNroLinea', true, 'clsInputDisable');	
				
				document.getElementById('btnConsultar').value = 'Nueva Busqueda';
			}
			
			//habilitar campos busqueda
			function HabilitarBusqueda() {
							
				setValue('hidFlagBuscando','false');
				setValue('hidFlagBuscandoPaso1','false');
				setValue('hidFlagDescuento','false');
				
				setValue('hidFlagConfExoneracionReintegro','false');
				setValue('hidFlagRenovacionAdelantada','false');
				
				
				
				
				document.getElementById('ddlTipoDocId').disabled = false;				
				//setReadOnly('txtNumeroDocId', false, 'clsInputEnableB');
				//setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
				
				if(getValue('ddlTipoDocId') == '00'){
					setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
				}else{
					setReadOnly('txtNumeroDocId', false, 'clsInputEnableB');	
				}				
				
				setReadOnly('txtNroLinea', false, 'clsInputEnableB');
				
				document.getElementById('btnConsultar').value = 'Buscar';
				// Inicio PS - Automatización de canje y nota de crédito
				// Fin E77568
				setValue('hidSaldosCC','');
				// Fin PS - Automatización de canje y nota de crédito	
				//Fin E77568	
			}
			
			function MostrarArea1(flag){
				if (flag){
					// Inicio E77568
				    // PS - Automatización de canje y nota de crédito.
				    if(constFlagClaroClub == '1'){
						setVisible('trPuntosClaroClub', true); 
						var saldosCC = getValue('hidSaldosCC');			
						if (saldosCC == "1") {
							VisualizarSaldosCC(true);
						} else {
							VisualizarSaldosCC(false);
						}
				    }else{
						setValue("txtDescuentoClaroClub", "0.00");
						setValue("txtClaroClubPuntosUtilizar", "0");
						setValue("txtClaroClubSolesDeDescuento", "0");
				    }					
			    	// PS - Automatización de canje y nota de crédito.
					// Fin E77568
					setVisible('trDatosCliente',true); 
					setVisible('trDatosLinea',true); 
					setVisible('trDatosFacturacion',true); 
					setFocus('btnSiguiente');
				} else {
					// Inicio E77568
				    // PS - Automatización de canje y nota de crédito.
					setValue('hidSaldosCC', '0');			    
					setVisible('trPuntosClaroClub', false); 
					VisualizarSaldosCC(false);
				    // PS - Automatización de canje y nota de crédito.
					// Fin E77568
					setVisible('trDatosCliente',false); 
					setVisible('trDatosLinea',false); 
					setVisible('trDatosFacturacion',false); 
					setVisible('trDetalleVenta',false); 
				}
				// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
				LeerCursorSaldos();
				// Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos
			}
			function LimpiarControlesDetalle()	{
				
				//datos del cliente
				setValue('txtNombreCLiente','');
				setValue('txtTipoCliente','');
				setValue('txtTelefonoReferencia','');
				
				setValue('hidNomCli','');
				setValue('hidTipoCli','');
				setValue('hidTelefonoReferencia','');

				//datos de la linea
				setValue('txtNroLineaD','');
				setValue('txtIMSI','');
				setValue('txtApadeceFechaInicio','');
				setValue('txtApadeceFechaFin','');

				setValue('hidIMSI','');
				setValue('hidFechaInicioApadece','')
				setValue('hidFechaFinApadece','')
				
				//datos de facturacion
				setValue('txtDireccion','');
				setValue('txtDepartamento','');
				setValue('txtDistrito','');
				setValue('txtCorreo','');
				
				setValue('txtReintegro','');
				setValue('txtReintegroAFacturar','');
				
				setValue('hidFlagRenovacionAdelantada','false');
				setValue('hidFlagExonerarReintegro','');
				setValue('hidFlagConfExoneracionReintegro','');
				setValue('hidFlagReintegro','');
				setValue('hidReintegro','');		
				
				setValue('hidDireccion','');
				setValue('hidDepartamento','');
				setValue('hidProvincia','');
				setValue('hidDistrito','');
				setValue('hidCorreo','');
				

				//datos d ela venta			
				setValue('ddlCodEquipo','00');
				setValue('txtCodEquipo','');
				setValue('ddlSerieEquipo','00');
				setValue('ddlCampania','00');
				setValue('ddlPlanTarifario','');
				setValue('ddlListaPrecio','00');
				setValue('ddlPlazoAcuerdo','00');
				
				setValue('txtPrecioVenta','');
				setValue('txtDescuentoEquipo','');
				setValue('txtTotalAPagar','');
				
				// Inicio E77568
				// PS - Automatización de canje y nota de crédito.
				setValue('txtClaroClubCampana', '');
				setValue('txtClaroClubPuntosUtilizar', '0');
				setValue('txtClaroClubSolesDeDescuento', '0');
				setValue('txtClaroClubSaldoActual', '0.00');
				setValue('lblClaroClubMsgError', '');
				setValue('txtDescuentoClaroClub', '');
				setValue('hidFactorClaroClub','0.00');
				setValue('hidClaroClubSolesDeDescuento', '00');
				setValue('hidTieneReserva', '');
				// PS - Automatización de canje y nota de crédito.
				// Fin E77568
				
				setValue('hidTipoDocVenta', '');
			}
			function LimpiarControles() {
				setValue('txtNroLinea', '');
				//setReadOnly('txtNumeroDocId', false, 'clsInputEnableB');
				//setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
				setValue('ddlTipoDocId', '00');
				setValue('txtNumeroDocId', '');
			}
			
			function mostrarConsulta(){
				/*setValue('hidReintegro', '0' );
					setValue('txtReintegro', '0.00' );
					setValue('txtReintegroAFacturar', '0.00' );
					*/
						
					//FIN REINTEGRO
					
					document.getElementById('btnConsultar').value = 'Nueva Busqueda';
					DeshabilitarBusqueda();
					MostrarArea1(true);
					
					//LimpiarControles();
					//document.getElementById('btnGrabar').disabled = true;
                                   
                    
                    //DATOS DEL CLIENTE
					setValue('txtNombreCLiente',getValue('hidNomCli'));					
					setValue('txtTipoCliente',getValue('hidTipoCli'));
					setValue('txtTelefonoReferencia',getValue('hidTelefonoReferencia'));

					//DATOS DE A LINEA
					
					setValue('txtIMSI',getValue('hidIMSI'));
					setValue('txtApadeceFechaInicio',getValue('hidFechaInicioApadece'));
					setValue('txtApadeceFechaFin',getValue('hidFechaFinApadece'));
					
					//APADECE INICIO
					//APADECE FIN

					//DATOS DE FACTURACIÓN
					setValue('txtDireccion',getValue('hidDireccion'));
					setValue('txtDepartamento',getValue('hidDepartamento'));
					setValue('txtProvincia',getValue('hidProvincia'));
					setValue('txtDistrito',getValue('hidDistrito'));
					setValue('txtCorreo',getValue('hidCorreo'));
			        
			        
                    var precio = getValue('hidLimiteCred');
                    if (precio.indexOf('.') < '0'){
						precio = precio + '.00';
                    }
                    //setValue('txtLimiteCred',precio);
                    setValue('txtNroLineaD',getValue('hidNroLinea'));
                    //validaCli(mensaje);
			}
			
			function validaFlujo(mensaje) {
								
				if(mensaje == "OK"){
										
					//VALIDAR REINTEGRO POR APADECE - PENDIENTE POR TERMINAR
					if (validarReintegro() == false){
						return false;
					}
					
					mostrarConsulta();
					// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos
					LeerCursorSaldos();
					// Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos
				}
			}
			
			function f_CambiaImei() {
				//setValue('hidAccion', 'Consultar');
				
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlSerieEquipo');
				selObjP.length = 1;
				
				
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
				
				
				//llenarHid();
				
				//variables para bloquear controles si es que se hace un submit
				setValue('hidFlagConfExoneracionReintegro',getValue('hidFlagConfExoneracionReintegro'));
				setValue('hidFlagBuscando',getValue('hidFlagBuscando'));
				setValue('hidFlagBuscandoPaso1',getValue('hidFlagBuscandoPaso1'));
				setValue('hidFlagDescuento','false');
				
				//Area 1
				setValue('hidNroLinea',getValue('txtNroLinea'));
				setValue('hidTipoDocumento',getValue('ddlTipoDocId'));
				setValue('hidNroDocumento',getValue('txtNumeroDocId'));
				
				//Area 4
				setValue('hidEqSeleccionado',getValue('ddlCodEquipo'));
				setValue('hidArticuloIccid',getValue('ddlSerieSim'));
				
				setValue('ddlCampania','00');
				setValue('ddlListaPrecio','00');
				setValue('ddlPlanTarifario','');
				
				//limpiarPrecios
				resetearMontos();
				habilitarDescuento();
				
				setValue('hidAccion', 'CargaAreaFinal');
				setValue('hidItemSeleccionado','ddlCodEquipo');
				document.frmPrincipal.submit();
				
				
			
			}
			
			
			function cargarSerieEquipo(){
			
				resetearBusquedaXSerie();
				
				var seleccionar = '<%= ConfigurationSettings.AppSettings("Seleccionar") %>';
				if ( getText('ddlCodEquipo') == seleccionar ) {
					alert('Seleccione un Equipo válido.');
					setValue('ddlSerieEquipo',seleccionar);
					setFocus('ddlCodEquipo');
					return false;
				}
				
				setValue('hidSerieEquipo',getValue('ddlSerieEquipo'));
				setValue('ddlCampania','00');
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
			}
			
			
			
			
			function solicitaAutorizacion( v_descripcion, v_monto,pagina ){
				//document.getElementById("hidOpcion").value = v_opcion;
				//if(confirm('Se requiere autorización del Jefe/Supervisor')){
								
				var url = '../../soporte/sisact_validar.aspx?';
				var params = "";
					params ="v_pag="	+ pagina		+ "&" +
							"v_tipotx="	+ "M"			+ "&" +
							"v_monto="	+ v_monto		+ "&" +
							"v_descripcion="+ v_descripcion;
							
					url = url + params;				
																	
					window.showModalDialog(url,window,'dialogTop:200;status:no;edge:sunken;dialogHide:true;help:no;dialogWidth:382px;dialogHeight:176px');								
					return
				//}else{
				//	return false
				//}
			}
			
			
			function FC_GrabarCommit(User)
			{
				//document.getElementById('hidAccion').value='A';
				//document.Form1.submit();
				//document.getElementById('hidAccion').value='';
				
				if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_ANTICIPADA_CON_EXONERACION'){			
					
					setValue('hidFlagConfExoneracionReintegro','true');
					setValue('hidFlagExonerarReintegro','true');
					setValue('txtReintegro', parseFloat(getValue('hidReintegro')).toFixed(2) );
					setValue('txtReintegroAFacturar', '0.00' );
							
					setValue('hidOpcionAutorizacion','');
					
					mostrarConsulta();
					
				}/*else if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_ANTICIPADA_SIN_EXONERACION'){			
					
					setValue('hidFlagConfExoneracionReintegro','true');
					setValue('hidFlagExonerarReintegro','false');
					setValue('txtReintegro', parseFloat(getValue('hidReintegro')).toFixed(2) );
					setValue('txtReintegroAFacturar', parseFloat(getValue('hidReintegro')).toFixed(2) );
							
					setValue('hidOpcionAutorizacion','');
					
					mostrarConsulta();
						
				}*/else if (document.getElementById("hidOpcionAutorizacion").value == 'RENOVACION_DESCUENTO'){
					
					setValue('hidOpcionAutorizacion','');
					ejecutarDescuento();
					
				}
				// Inicio E77568
				else if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_NORMAL_CON_EXONERACION') {
				
				}
				// Fin E77568
			}
						
			function FC_Fallo()
			{
				setValue('hidOpcionAutorizacion','');
				alert('Ud. no cuenta con autorización suficiente para realizar esta transacción.');
			}
			
			function FC_CancelarVentana()
			{
				
				if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_ANTICIPADA_CON_EXONERACION'){			
					
					LimpiarControles();
					HabilitarBusqueda();
						
					setValue('hidOpcionAutorizacion','');
				}/*else if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_ANTICIPADA_SIN_EXONERACION'){			
					
					LimpiarControles();
					HabilitarBusqueda();
						
					setValue('hidOpcionAutorizacion','');
						
				}*/else if (document.getElementById("hidOpcionAutorizacion").value == 'RENOVACION_DESCUENTO'){
					setFocus('txtDescuentoEquipo');
					setValue('hidOpcionAutorizacion','');
				}
			}
			function FC_Fallo_Monto_No_Permitido()
			{
				alert('El monto ingresado NO esta permitido.');
			}
			
			function FC_Fallo_Meses_No_Permitido()
			{
				alert('La cantidad de meses NO esta permitido para una renovación anticipada.');
			}
			
			function validarDescuento(){
				var precioVenta =  getValue('hidPrecioVenta');
				var montoDescuento = getValue('txtDescuentoEquipo');
				
			
				if(precioVenta ==''){
					precioVenta = 0;
				}
				
				if(montoDescuento ==''){
					montoDescuento = 0;
				}				
				
				if (parseFloat(montoDescuento) <= 0) {
					alert('Debe ingresar un descuento.')
					setFocus('txtDescuentoEquipo');
					return false;
				}else if( parseFloat(montoDescuento) > parseFloat(precioVenta) ){
					//alert('El precio no puede ser mayor al Precio de Venta');
					alert('Monto de descuento NO permitido.')
					setFocus('txtDescuentoEquipo');
					return false;
				}else
				{
					/*
					//VALIDAR NIVEL DE AUTORIZACIÓN ESTA ACTIVO SEGUN EL MONTO Y SI EL MONTO ES PERMITIDO
					
								
					//variables para bloquear controles si es que se hace un submit
					setValue('hidFlagConfExoneracionReintegro',getValue('hidFlagConfExoneracionReintegro'));
					setValue('hidFlagBuscando',getValue('hidFlagBuscando'));
					setValue('hidFlagBuscandoPaso1',getValue('hidFlagBuscandoPaso1'));
					setValue('hidFlagDescuento','false');
					
					setValue('hidPrecioSeleccionado',getValue('ddlListaPrecio'));
					
					setValue('hidAccion', 'ValidarDescuento');
					
					document.frmPrincipal.submit();
					*/
				
					setValue('hidOpcionAutorizacion','RENOVACION_DESCUENTO');
					
					// Inicio E77658
					// PROY-7045RF01 - RF01
					// Ya NO deberá mostrarse la pantalla para ingresar la autorización.
					
					var montoMaxDesAS = parseFloat(getValue('hidMontoMaxDesAS'));
					if(parseFloat(montoDescuento) > montoMaxDesAS){
						solicitaAutorizacion('Descuento por Renovacion',montoDescuento,'1');
					}else{
						FC_GrabarCommit('');
					}
					
					// Fin E77658
				}
				
				
				
			}
			function validarFlujoGenerarPedido(mensaje){
					
				if(mensaje == "OK"){
					cancelarPedido();
					
					setValue('txtNumeroDocId','');
					setValue('txtNroLinea','');
					
					alert("El Pedido ha sido generado satisfactoriamente.");

				}
				
				if(mensaje == "ERROR"){
									
					setValue('txtNumeroDocId', getValue('hidNroDocumento'));
					setValue('ddlTipoDocId', getValue('hidTipoDocumento'));
					setValue('txtNroLinea', getValue('hidNroLinea'));
					
					MostrarArea1(true);
					siguiente();
					cargarListaPrecios();					
				}
				
			}			
		
			function validarFlujoDescuento(mensaje){
			   MostrarArea1(true);
               siguiente();
                                                 
				var precioVenta =  getValue('hidPrecioVenta');
				var montoDescuento = getValue('txtDescuentoEquipo');
														
				if(mensaje == "ERROR"){
					//setearBusqueda();
					cargarListaPrecios();
					setValue('ddlListaPrecio',getValue('hidPrecioSeleccionado'));
					
					alert("Monto de descuento NO permitido.")
					setFocus('txtDescuentoEquipo');
					return false;
				}
				if(mensaje == "OK"){
					//abrir ventana de login para validar
					cargarListaPrecios();
					setValue('ddlListaPrecio',getValue('hidPrecioSeleccionado'));				
					// Inicio E77658
					// PROY-7045RF01 - RF01 - 
					// SISACT NO deberá solicitar ingresar ninguna autorización.
					var montoMaxDesAS = parseFloat(getValue('hidMontoMaxDesAS'));
					if(parseFloat(montoDescuento) > montoMaxDesAS){
						solicitaAutorizacion('Descuento por Renovacion',montoDescuento,'1');
					}					
					// original: solicitaAutorizacion('Descuento por Renovacion',montoDescuento,'1');
					
					// Fin E77658
				}
			}
			
			function ejecutarDescuento(){
				// Inicio E77568
				var precioVenta = parseFloat(getValue('hidPrecioVenta'));
				var precioDescuento = 0.0;
				var precioTotal = 0.0;
				// Verificar si no hay reserva de puntos
				if (getValue('hidTieneReserva') != "1") {
					precioDescuento = parseFloat(getValue('txtDescuentoEquipo'));
					// PS - Automatización de canje y nota de crédito.
					var DescuentoClaroClub = getValue('txtDescuentoClaroClub');
					if (DescuentoClaroClub == "") {
						DescuentoClaroClub = 0.0;
					} else {
						DescuentoClaroClub = parseFloat(DescuentoClaroClub);
					}
					precioTotal = precioVenta - (precioDescuento + DescuentoClaroClub); // Se agrega ClaroClubSolesDeDescuento PS - Automatización de canje y nota de crédito.
					if ((precioDescuento + DescuentoClaroClub) > precioVenta) {
						alert("El monto total de descuentos no puede ser mayor al precio de venta de equipo.");
						return;
					}
				} else {
					precioDescuento = parseFloat(getValue('txtDescuentoEquipo'));
					precioTotal = precioVenta - precioDescuento;
				}
				// PS - Automatización de canje y nota de crédito.
				// Fin E77568
								
				//descuento
				setValue('hidDescuento', precioDescuento);
				var precioDescuentoDysplay = precioDescuento;
				setValue('txtDescuentoEquipo', precioDescuentoDysplay.toFixed(2));
				
				//total
				setValue('hidPrecioTotal', precioTotal);
				setValue('txtTotalAPagar', precioTotal.toFixed(2));	
				
				setReadOnly('txtDescuentoEquipo', true, 'clsInputDisable');
					
				desabilitarBoton('btnDescuentoEquipo');
				setValue('hidFlagDescuento','true');
			}
			
			function desabilitarBoton(id){
				document.getElementById(id).className='BotonResaltado'
				document.getElementById(id).style.cursor=  'default'
				document.getElementById(id).disabled = true;			
			}
			
			function habilitarBoton(id){
				document.getElementById(id).className='Boton'
				document.getElementById(id).style.cursor=  'hand'
				document.getElementById(id).disabled = false;			
			}			
			
			function cargarPrecio() {			
				
				// Obtener la Campania Seleccionada
				var campaniaSelected = getValue('ddlCampania') + "," + getText('ddlCampania');
				setValue('hidCampaniaSelected', campaniaSelected);
				
				// Obtener el plan tarifario seleccionado
				var planTarifaSelected = getValue('ddlPlanTarifario') + "," + getText('ddlPlanTarifario');
				setValue('hidPlanTarifaSelected', planTarifaSelected);
				
				//Obtener la lisa de precios
				var listaPreciosSelected = getValue('ddlListaPrecio') + "," + getText('ddlListaPrecio');
				setValue('hidlistaPrecioSelected', listaPreciosSelected);
				
			
				var listaPrecio = getValue('ddlListaPrecio'); 
				setValue('txtTotalAPagar','');
				setValue('txtPrecioVenta','');
				
				var params = "";
				params = getValue('hidOfVenta') + "," + getValue('ddlCodEquipo') + "," + getValue('ddlListaPrecio') + "," + getValue('ddlSerieEquipo') + "," + getValue('txtNroLinea') + "," + getValue('hidTipoDocVenta') + "," + "" + "," + "" + "," + "";
				
				consultarPrecios(params);
			}
			function consultarPrecios(params) {
				document.getElementById('ifrConsultarPrecio').src = "../chip_repuesto/sisact_ifr_consulta_precio.aspx?params="+params+"&renov=RP";
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
			}
			function responseConsultarPrecios(datos) {
			
				resetearMontos();
				habilitarDescuento();
				
				setValue('ddlPlazoAcuerdo','00');
				
				var listaPrecio = getValue('ddlListaPrecio');

				if (listaPrecio != "00"){
					// Obtener Precio de Venta - Precio de Lista
					var arrayPrecio = datos.split(',');

					setValue('hidPrecios', datos);
					setValue('txtPrecioVenta', arrayPrecio[1]);
					setValue('txtTotalAPagar', arrayPrecio[1]);
					
					setValue('hidPrecioVenta', arrayPrecio[1]);
					setValue('hidPrecioTotal', arrayPrecio[1]);
				
					// Inicio E77568
					// Inicio PS - Automatización de canje y nota de crédito.
					// Actualizar el total a pagar txtTotalAPagar	
					if (getValue('hidTieneReserva') != "1") {
						var precioVenta = parseFloat(getValue('txtPrecioVenta'));
						var descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
						var PrecioNeto = precioVenta - descuentoClaroClub;
						setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
						setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
					}
					// Fin PS - Automatización de canje y nota de crédito.
					// Fin E77568
				}
				else{
					setValue('txtPrecioVenta', '0.00');
					setValue('txtTotalAPagar', '0.00');
				}
			}
			
			function grabarPedido()
			{				
				if ( !ValidaCampo('document.frmPrincipal.ddlTipoDocId','Debe seleccionar un Tipo de Documento.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.txtNumeroDocId','Debe ingresar el número de Documento.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.txtNroLinea','Debe ingresar el número de Línea.') ) return false;	
				
				if ( !ValidaCampo('document.frmPrincipal.ddlCodEquipo','Debe seleccionar un Equipo.') ) return false;
				if ( document.getElementById('ddlSerieEquipo').length == 0 || getText('ddlSerieEquipo')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>' || 
					 getText('ddlSerieEquipo')== '' ){
					alert('Debe seleccionar una Serie de Equipo válida');
					setValue('ddlCampania','00');
					return false;
				}

				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) {
					setValue('ddlCampania','00');
					return false;
				}
				
				if ( !ValidaCampo('document.frmPrincipal.ddlPlanTarifario','Debe seleccionar un Plan Tarifario.') ) {
					setValue('ddlPlanTarifario','');
					return false;
				}
				
				if ( !ValidaCampo('document.frmPrincipal.ddlListaPrecio','Debe seleccionar una Lista de Precio.') ) {
					setValue('ddlListaPrecio','00');
					return false;
				}
				
				if ( !ValidaCampo('document.frmPrincipal.ddlPlazoAcuerdo','Debe seleccionar un Plazo de Acuerdo.') ) {
					setValue('ddlPlazoAcuerdo','00');
					return false;
				}
				
				if ( (getValue('hidFlagDescuento') != "true")  && (getValue('txtDescuentoEquipo') != ""  ) ){
					alert("Usted ha ingresado un descuento, pero aun no a sido validado, por favor Validar Descuento.");
					return false;
				}
				
				// Inicio E77568
				if (getValue('hdnRetenidoFidelizado') == "") {
					alert("Debe indicar si el cliente es Retenido o Fidelizado.");
					return false;
				}
				
				// Inicio PS - Automatización de canje y nota de crédito.
				// Verificar que la suma del descuento y de los soles del descuento (si hubiere), no excedan el monto
				// del valor del equipo
				var precioVenta;
				var descuentoEquipo = 0.0;
				var descuentoSolesCC = 0.0;
				precioVenta = parseFloat(getValue('txtPrecioVenta'));
				if (getValue('txtDescuentoEquipo') != "") {
					descuentoEquipo = parseFloat(getValue('txtDescuentoEquipo'));
				}
				if (getValue('txtClaroClubSolesDeDescuento') != "") {
					descuentoSolesCC = parseFloat(getValue('txtClaroClubSolesDeDescuento'));
				}
				if (descuentoEquipo + descuentoSolesCC > precioVenta) {
					alert("El monto total de los descuentos exceden el precio de venta del equipo.");
					return false;
				}
				// Fin PS - Automatización de canje y nota de crédito.
				// Fin E77568
				
				if ( !confirm("Está seguro de GENERAR el Pedido?") ) {
					return;
				} else {
									
					desabilitarBoton('btnGrabar');
					desabilitarBoton('btnCancelarPedido');
					
					
					setValue('hidNroDocumento', getValue('txtNumeroDocId'));
					setValue('hidTipoDocumento', getValue('ddlTipoDocId'));
					setValue('hidNroLinea', getValue('txtNroLinea'));
					
					setValue('hidAccion', 'GenerarPedido');
					document.frmPrincipal.submit();				
				}	
				
			}				
		
			// Inicio E77568	
			function chkRetenido_onclick() {
				var chkRetenido = document.getElementById("chkRetenido");
				var hdnRetenidoFidelizado = document.getElementById("hdnRetenidoFidelizado");

				if (chkRetenido.checked) {				
					var chkFidelizado = document.getElementById("chkFidelizado");

					chkFidelizado.checked = false;
					hdnRetenidoFidelizado.value = "Retenido";
				} else {
					hdnRetenidoFidelizado.value = "";
				}
			}

			function chkFidelizado_onclick() {
				var chkFidelizado = document.getElementById("chkFidelizado");
				var hdnRetenidoFidelizado = document.getElementById("hdnRetenidoFidelizado");

				if (chkFidelizado.checked) {
					var chkRetenido = document.getElementById("chkRetenido");

					chkRetenido.checked = false;
					hdnRetenidoFidelizado.value = "Fidelizado";
				} else {
					hdnRetenidoFidelizado.value = "";
				}
			}	
			
			// Inicio PS - Automatización de canje y nota de crédito.
			
				    
					
																  
																  

			
						
			// Evalua la equivalencia entre los puntos Claro Club y su equivalente en soles y viceversa. 
			function CalcularClaroClubPuntos(obj) {
				document.getElementById('lblClaroClubMsgError').innerHTML = "";
				
				try {
					// Validaciones previas.
					if (obj.value.length == 0) {
						setValue("txtClaroClubPuntosUtilizar", "0");
						setValue("txtClaroClubSolesDeDescuento", "0");	
						setValue("txtDescuentoClaroClub", "0.00");
						return;
					}
					if (parseInt(getValue('txtClaroClubPuntosUtilizar')) > parseInt(getValue('txtClaroClubSaldoActual'))) {
							document.getElementById('lblClaroClubMsgError').innerHTML = "Los puntos ingresados exceden la cantidad disponible.";
							ResetCifrasCC();
							return;
						}
						// Verificar que se cumpla el mínimo en puntos.
					if (parseInt(getValue('hidCCMinimoPuntos')) > 0) {
							if (parseInt(getValue('txtClaroClubPuntosUtilizar')) < parseInt(getValue('hidCCMinimoPuntos')) && parseInt(getValue('txtClaroClubPuntosUtilizar')) > 0) {
								document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorCCPuntosMinimos');
								ResetCifrasCC();
								return;
							}
						}
					
					var resu = EquivalenciaPuntosToSoles();	
					if (resu.toString() == "-1") {
						document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorClaroClubDesfase');
						ResetCifrasCC();
					} else {
						// Verificar si el resultado de la conversión (a puntos) no excede los puntos disponibles.							
						if (parseFloat(resu) > parseFloat(getValue('txtClaroClubSaldoActual'))) {
							document.getElementById('lblClaroClubMsgError').innerHTML = "Los puntos equivalentes exceden los puntos disponibles.";
							ResetCifrasCC();
							return;
						}

						resu = resu.toString()+".00";

						setValue('txtClaroClubSolesDeDescuento', resu);
						setValue('txtDescuentoClaroClub', getValue('txtClaroClubSolesDeDescuento'));
								
								if (getValue('txtPrecioVenta').length > 0) {
									var precioVenta = parseFloat(getValue('txtPrecioVenta'));
									var descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
									var descuentoEquipo = 0.0;
									if (getValue('txtDescuentoEquipo').length > 0) {
										descuentoEquipo = parseFloat(getValue('txtDescuentoEquipo'));
									}
									var PrecioNeto = precioVenta - (descuentoEquipo + descuentoClaroClub);
									setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
									setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
								}
								
					}
				} catch (ex) {
					document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorClaroClubDesfase');
					setValue('txtClaroClubPuntosUtilizar', getValue('txtClaroClubSaldoActual'));
					setValue('txtClaroClubSolesDeDescuento', getValue('hidClaroClubSolesDeDescuento'));
					setValue('txtDescuentoClaroClub', getValue('hidClaroClubSolesDeDescuento'));
				}
			}
			
			// Acepta solo datos de tipo fecha, mask(##/##/####)
			// No restringe la longitud del dato.
			function SoloEnteros(event, obj) {
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				var salida = false;
				var key = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey) {
					return false;
				}
				
				var CaracteresPermitidos = '0123456789';
				var valid = new String(CaracteresPermitidos);
				for (var i = 0; i < valid.length; i++) {
					if (key == valid.substring(i, i + 1))
						salida = true;
				}
				
				if (code == 8) { // Allow backspace, F5
					return true;
				} else if ((code >= 37 && code <= 40) && (code != 39)) { // Allow directional arrows
					return true;
				} else if (code == 9 || code == 16) {// tab control + tab
					return true;
				}
				
				return salida;
			}
			
			// Acepta solo numero entero o decimales con un punto (opcional)
			// No restringe la longitud del numero o de los decimales.
			function SoloNumerosReales(event, obj) {
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				var salida = false;
				var key = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey) {
					return false;	
				}				
				// Solo permitir un punto decimal.
				if (key == ".") {
					if (obj.value.indexOf('.') >= 0) {
						return false;
					} else {
						return true;
					}
				}
				
				var CaracteresPermitidos = '0123456789';
				var valid = new String(CaracteresPermitidos);
				for (var i = 0; i < valid.length; i++) {
					if (key == valid.substring(i, i + 1))
						salida = true;
				}
				
				if (code == 8){ // Allow backspace, F5
					return true;
				}else if ((code >=37 && code <= 40) && (code != 39)){ // Allow directional arrows
					return true;
				}else if (code == 9 || code == 16){ // tab control + tab
					return true;
				}
				
				return salida;
			}
            
            // Verifica si se ha pulsado la tecla ENTER, para realizar el calsulo de puntos Claro Club
            // sino verifica que solo se ingresen números enteros
            function EvaluarKey(event, obj) {
				 if(constFlagClaroClub == '1'){
				var code = (event.which) ? event.which : event.keyCode;	
				
				if (code == 13) { // key ENTER
					CalcularClaroClubPuntos(obj);
				} else {
					return SoloEnteros(event, obj);
				}
			}
			}
			
			function EquivalenciaPuntosToSoles() {
            try {
					var ClaroclubPuntosUtilizar = parseFloat(getValue('txtClaroclubPuntosUtilizar'));
					var constTipoClientePOSTPAGO = '<%= ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO") %>';
					var constTipoClientePREPAGO = '<%= ConfigurationSettings.AppSettings("constTipoClientePREPAGO") %>';
                var FactorClaroClub = parseFloat(getValue('hidFactorClaroClub'));
					var fEqPOSTPAGO = 0.0;
					var fEqPREPAGO = 0.0;
					var puntosAcumUsados = 0;

					var vPOSTPAGO = cursorSaldos.get(constTipoClientePOSTPAGO).split('|');
					if (parseInt(vPOSTPAGO[0]) > ClaroclubPuntosUtilizar) {
						fEqPOSTPAGO = ClaroclubPuntosUtilizar * FactorClaroClub * parseFloat(vPOSTPAGO[1]);
						return Math.ceil(fEqPOSTPAGO);
					} else if (Math.ceil(parseFloat(vPOSTPAGO[0])) == ClaroclubPuntosUtilizar) {
						return Math.ceil(vPOSTPAGO[2]);
                        } else {
						fEqPOSTPAGO = parseFloat(vPOSTPAGO[2]);
                        }
					if (cursorSaldos.get(constTipoClientePREPAGO) != undefined) {
					var vPREPAGO = cursorSaldos.get(constTipoClientePREPAGO).split('|');
						fEqPREPAGO = (ClaroclubPuntosUtilizar - parseInt(vPOSTPAGO[0])) * FactorClaroClub * parseFloat(vPREPAGO[1]);
						if (Math.ceil(parseFloat(vPREPAGO[2])) >= fEqPREPAGO) {
							return Math.ceil(fEqPOSTPAGO + fEqPREPAGO);
						} else {
						fEqPREPAGO = parseFloat(vPREPAGO[2]);
						}
						puntosAcumUsados = parseInt(vPOSTPAGO[0]) + parseInt(vPREPAGO[0]);
						fEqSolesAcumulado = fEqPOSTPAGO + fEqPREPAGO;
					} else {
						puntosAcumUsados = parseInt(vPOSTPAGO[0]);
						fEqSolesAcumulado = fEqPOSTPAGO;
            }
					var i = 0;
					for (var i = 0; i < cursorSaldos.length; i++) {
						var constTipoClienteOTROS = cursorSaldos.item(i);
						if (constTipoClienteOTROS != constTipoClientePOSTPAGO && constTipoClienteOTROS != constTipoClientePREPAGO) {
							var vOTROS = cursorSaldos.get(constTipoClienteOTROS).split('|');
							var fEqOTROS = (ClaroclubPuntosUtilizar - puntosAcumUsados) * FactorClaroClub * parseFloat(vPOSTPAGO[1]);
							if (parseFloat(vOTROS[2]) >= fEqOTROS) {
								return Math.ceil(fEqSolesAcumulado + fEqOTROS);
                        } else {
								puntosAcumUsados = puntosAcumUsados + parseInt(vOTROS[0]);
								fEqSolesAcumulado = fEqSolesAcumulado + parseFloat(vOTROS[2]);
					}
						}
					}

					return -1;
            } catch (ex) {
                return -1;
				}
			}
        function VisualizarSaldosCC(ver) {
			if (ver) {
				document.getElementById("trClaroClubSaldosCC").style.display = "block";
			} else {
				document.getElementById("trClaroClubSaldosCC").style.display = "none";
			}
        }

        function ToogleSaldosCC() {
			var saldosCC = getValue('hidSaldosCC');

			if (saldosCC == "1") {
				VisualizarSaldosCC(false);
				setValue('hidSaldosCC', "0");
			} else {
				VisualizarSaldosCC(true);
				setValue('hidSaldosCC', "1");
			}
        }

        function ResetCifrasCC() {
				setValue('txtClaroClubPuntosUtilizar', getValue('txtClaroClubSaldoActual'));
			setValue('txtClaroClubSolesDeDescuento', getValue('hidClaroClubSolesDeDescuento'));	
				setValue('txtDescuentoClaroClub', getValue('hidClaroClubSolesDeDescuento'));	
        }
			// Fin PS - Automatización de canje y nota de crédito					

			// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos			
			function VerDetalleDescuento() {				
				var url = 'sisact_renovacion_detalle_descuento.aspx?qs=';
				var params = getValue('hidDetalleDescuento');
						
				url = url +encodeURI(params);
				window.showModalDialog(url, window, 'dialogTop:200;status:no;edge:sunken;dialogHide:true;help:no;dialogWidth:560px;dialogHeight:300px');	
				return;
			}
			function LeerCursorSaldos() {
				if (cursorSaldos.length == 0) {
					var vCursorSaldos = getValue('hidDetalleDescuento').split('~');

					for (var i = 0; i < vCursorSaldos.length - 1; i++) {
						var vSaldo = vCursorSaldos[i].split('|');
						// TIPO_CLIENTE=(5), PUNTOS=(7) + '|' + FACTOR=(4) + '|' + TOTAL=(2)
						cursorSaldos.put(vSaldo[5], vSaldo[7] + '|' + vSaldo[4] + '|' + vSaldo[2]);
					}				
				}				
			}
			// Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos

			// Fin E77568
		</script>
	</HEAD>
	<body onload="inicio();" MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table class="contenido" border="0" cellSpacing="2" cellPadding="0" width="100%">
							<tr>
								<td class="header" height="20" colSpan="7" align="left">&nbsp;Búsqueda del Cliente
								</td>
							</tr>
							<tr>
								<td class="Arial10B" width="120">&nbsp;
									<asp:label id="lblTipoDoc" Runat="server" Text="Tipo Documento (*): "></asp:label></td>
								<td class="Arial10B" width="180"><asp:dropdownlist id="ddlTipoDocId" runat="server" Width="150px" CssClass="clsSelectEnable" onchange="javascript:f_CambiaTipoDocumento(this.value);"></asp:dropdownlist></td>
								<td class="Arial10B" width="120"><asp:label id="Label21" Runat="server" Text="N° Doc. Identidad (*): "></asp:label></td>
								<td class="Arial10B" width="150"><asp:textbox onkeydown="validarNumeroPermitirControl(event);" id="txtNumeroDocId" onkeypress="validarNumeroPermitirControl(event);"
										runat="server" Width="120px" CssClass="clsInputDisable" MaxLength="11" ReadOnly="True"></asp:textbox></td>
								<td class="Arial10B" width="120"><asp:label id="Label3" Runat="server" Text="Número de Línea (*): "></asp:label></td>
								<td class="Arial10B" width="150"><asp:textbox onkeydown="validarNumeroPermitirControl(event); validarEnter(event);" id="txtNroLinea"
										onkeypress="validarNumeroPermitirControl(event);" runat="server" Width="120px" CssClass="clsInputEnableB" MaxLength="9"></asp:textbox></td>
								<td align="right"><input style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" id="btnConsultar" class="Boton"
										onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="consultar();"
										value="Buscar" type="button" name="btnConsultar">&nbsp;&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<!-- Inicio E77568-->
				<!-- Inicio PS - Automatización de canje y nota de crédito -->
				<tr style="DISPLAY: none" id="trPuntosClaroClub">
					<td>
						<table style="BORDER-COLLAPSE: collapse" class="contenido" border="0" cellSpacing="2" width="100%">
							<tr>
								<td class="header" height="20" align="left">&nbsp;Claro Club - Datos de Claro 
									Puntos&nbsp;
								</td>
							</tr>
							<tr>
								<td>
									<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="1035">
								<colgroup>
											<col style="MIN-WIDTH: 260px; WIDTH: 260px">
											<col style="WIDTH: 100px">
											<col style="WIDTH: 140px">
								</colgroup>
								<tr>
									<td class="Arial10B">&nbsp;
									<asp:label id="lblClaroClubCampana" Runat="server">Campaña</asp:label></td>
								<td class="Arial10B" colSpan="3"><asp:textbox id="txtClaroClubCampana" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
											width="360px"></asp:textbox></td>
								<TD class="Arial10B">&nbsp;<IMG style="CURSOR: pointer" id="imgVerSaldos" onclick="ToogleSaldosCC();" alt="" src="../../../images/ico_expandir.gif"></TD>
											<td class="Arial10B">
												<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="0" width="100%">
													<tr>
														<TD class="Arial10B">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vigencia&nbsp;</TD>
														<TD class="Arial10B"><asp:textbox style="Z-INDEX: 0" id="txtFechaIniCC" Runat="server" CssClass="clsInputDisable Monto DeshabilitadoCC"
																ReadOnly="True" width="80px"></asp:textbox></TD>
														<td class="Arial10B">&nbsp;al&nbsp;</td>
														<TD class="Arial10B"><asp:textbox style="Z-INDEX: 0" id="txtFechaFinCC" Runat="server" CssClass="clsInputDisable Monto DeshabilitadoCC"
																ReadOnly="True" width="80px"></asp:textbox></TD>
														<TD class="Arial10B">&nbsp;&nbsp;&nbsp;&nbsp;Segmento</TD>
														<TD class="Arial10B"><asp:textbox style="TEXT-ALIGN: center" id="txtSegmentoCC" Runat="server" Width="30" CssClass="clsInputDisable Monto DeshabilitadoCC"
																ReadOnly="True" Font-Bold="True"></asp:textbox></TD>
							</tr>
												</table>
											</td>
										</tr>
									</table>
									<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="1035">
										<colgroup>
											<col style="MIN-WIDTH: 295px; WIDTH: 295px">
											<col style="MIN-WIDTH: 100px">
										</colgroup>
							<tr id="trClaroClubSaldosCC">
											<td class="Arial10B">&nbsp;
												<asp:datagrid id="dgSaldosCC" runat="server" Width="350px" AllowPaging="False" AutoGenerateColumns="False"
													BorderColor="#95B7F3" CellPadding="1" CellSpacing="1" ShowHeader="False" BorderWidth="0">
										<Columns>
											<asp:BoundColumn DataField="DESCRIP_BOLSA" HeaderText="DESCRIP_BOLSA">
															<ItemStyle Width="260px" Font-Bold="true" Font-Names="Arial" Font-Size="11px" HorizontalAlign="Left"
													ForeColor="Navy" Wrap="true"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PUNTOS_ASIGNADOS" HeaderText="PUNTOS_ASIGNADOS">
												<ItemStyle Width="90px" Font-Bold="true" Font-Names="Arial" Font-Size="11px" HorizontalAlign="Right"
													ForeColor="Navy" BackColor="#e3efff" BorderColor="#bfbee9" BorderWidth="1px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="COD_BOLSA" HeaderText="COD_BOLSA"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>&nbsp;
								</td>
											<td style="PADDING-LEFT: 35px; VERTICAL-ALIGN: top" class="Arial10B">Ver Detalle de 
												Descto.&nbsp;&nbsp;<input style="WIDTH: 28px; HEIGHT: 19px; CURSOR: hand" id="btnVerDetalleDescuento" class="Boton"
													onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="VerDetalleDescuento();"
													value="..." type="button" name="btnVerDetalleDescuento"></td>
							</tr>
									</table>
									<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="1035">
										<colgroup>
											<col style="MIN-WIDTH: 260px; WIDTH: 260px">
											<col style="MIN-WIDTH: 100px">
											<col style="MIN-WIDTH: 100px">
										</colgroup>
							<TR>
								<TD class="Arial10B">&nbsp;
									<asp:label id="lblClaroClubSaldoActual" Runat="server"> Saldo actual de Claro Puntos </asp:label></TD>
											<TD class="Arial10B"><asp:textbox id="txtClaroClubSaldoActual" Runat="server" Width="92" CssClass="clsInputDisable Monto"
													ReadOnly="True"></asp:textbox></TD>
											<TD style="TEXT-ALIGN: right" class="Arial10B">&nbsp;
												<asp:label style="MARGIN-RIGHT: 10px" id="lblClaroClubPuntosUtilizar" Runat="server">Claro puntos a utilizar&nbsp;&nbsp;&nbsp;</asp:label></TD>
								<TD class="Arial10B"><asp:textbox onblur="javascript:CalcularClaroClubPuntos(this);" id="txtClaroClubPuntosUtilizar"
													onkeypress="return EvaluarKey(event, this);" onpaste="return false" Runat="server" Width="90" CssClass="clsInputDisable Monto"
													MaxLength="6"></asp:textbox></TD>
											<TD style="TEXT-ALIGN: right" class="Arial10B">&nbsp;<asp:label style="MARGIN-RIGHT: 10px" id="lblClaroClubSolesDeDescuento" Runat="server">Soles de Descuento&nbsp;&nbsp;&nbsp;</asp:label></TD>
											<TD class="Arial10B"><asp:textbox id="txtClaroClubSolesDeDescuento" Runat="server" CssClass="clsInputDisable Monto DeshabilitadoCC"
										ReadOnly="True" width="90px"></asp:textbox></TD>
							</TR>
							<TR>
											<TD class="Arial10B" colSpan="6">&nbsp;
									<asp:label id="lblClaroClubMsgError" Runat="server" CssClass="Arial10BRed"></asp:label></TD>
							</TR>
						</table>
					</td>
				</tr>
						</table>							
					</td>
				</tr>
				<!-- Fin PS - Automatización de canje y nota de crédito -->
				<!-- Fin E77568 -->
				<TR style="DISPLAY: none" id="trDatosCliente">
					<TD>
						<TABLE class="contenido" border="0" cellSpacing="2" width="100%">
							<TR>
								<td class="header" height="20" colSpan="4" align="left">&nbsp;Datos del Cliente
								</td>
							</TR>
							<tr>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="lbl" Runat="server" Text="Razón Social / Nombre: ">Razón Social / Nombre: </asp:label></td>
								<td style="WIDTH: 400px" class="Arial10B"><asp:textbox id="txtNombreCLiente" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="400px"></asp:textbox></td>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="LabelPaterno" Runat="server" Text="Tipo Cliente:">Tipo Cliente: </asp:label></td>
								<td class="Arial10B" align="left"><asp:textbox id="txtTipoCliente" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="170px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="Label2" Runat="server" Text="Teléfono de Referencia: "></asp:label></td>
								<td class="Arial10B" colSpan="3"><asp:textbox id="txtTelefonoReferencia" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="170px"></asp:textbox></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td height="3"></td>
				</tr>
				<tr style="DISPLAY: none" id="trDatosLinea">
					<td>
						<table class="contenido" border="0" cellSpacing="2" width="100%">
							<tr>
								<td class="header" height="20" colSpan="4" align="left">&nbsp;Datos de la Línea
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="Label1" Runat="server" Text="Razón Social / Nombre: ">Número de la Línea</asp:label>:</td>
								<td style="WIDTH: 400px" class="Arial10B"><asp:textbox id="txtNroLineaD" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="170px"></asp:textbox></td>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="Label4" Runat="server" Text="Tipo Cliente:">IMSI:</asp:label></td>
								<td class="Arial10B" align="left"><asp:textbox id="txtIMSI" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="170px"></asp:textbox></td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="Label5" Runat="server" Text="Teléfono de Referencia: ">APADECE Fecha Inicio:</asp:label></td>
								<td class="Arial10B"><asp:textbox id="txtApadeceFechaInicio" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="170px"></asp:textbox></td>
								<td style="WIDTH: 150px" class="Arial10B">&nbsp;
									<asp:label id="Label9" Runat="server" Text="Tipo Cliente:">APADECE Fecha Fin:</asp:label></td>
								<td class="Arial10B" align="left"><asp:textbox id="txtApadeceFechaFin" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="170px"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr style="DISPLAY: none" id="trDatosFacturacion">
					<td>
						<table class="contenido" border="0" cellSpacing="2" width="100%">
							<tr>
								<td class="header" height="20" colSpan="9" align="left">&nbsp;Datos de Facturación
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label6" Runat="server" Text="Dirección:">Dirección:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 200px"><asp:textbox id="txtDireccion" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="200px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label7" Runat="server" Text="Departamento:">Departamento:</asp:label></td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtDepartamento" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="120px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label11" Runat="server" Text="Provincia:">Provincia:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtProvincia" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="120px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label12" Runat="server" Text="Distrito:">Distrito:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtDistrito" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="120px"></asp:textbox></td>
								<td class="Arial10B" align="right"><input class="Boton" id="btnSiguiente" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
										onclick="siguiente();" onmouseout="this.className='Boton';" type="button" value="Siguiente" name="btnSiguiente">&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label8" Runat="server" Text="Correo Electrónico">Correo Electrónico:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 200px"><asp:textbox id="txtCorreo" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="200px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label10" Runat="server" Text="Reintegro:">Reintegro:</asp:label></td>
								<td class="Arial10B" align="left" width="170"><asp:textbox id="txtReintegro" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="120px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 190px" colSpan="2">&nbsp;
									<asp:label id="Label13" Runat="server" Text="Total Reintegro a Facturar:">Total Reintegro a Facturar:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px" colSpan="2"><asp:textbox id="txtReintegroAFacturar" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="120px"></asp:textbox></td>
								<td class="Arial10B" align="right"><input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
										onclick="cancelarPaso();" onmouseout="this.className='Boton';" type="button" value="Cancelar" name="btnCancelar">&nbsp;&nbsp;
								</td>
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
								<td class="header" align="left" colSpan="9" height="20">&nbsp;Datos de la Venta
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label14" Runat="server" Text="Dirección:">Descripción del Material:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 250px"><asp:dropdownlist id="ddlCodEquipo" onkeydown="" runat="server" Width="250px" CssClass="clsSelectEnable"
										onchange=""></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label15" Runat="server" Text="Departamento:">Código del Material:</asp:label></td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtCodEquipo" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="150px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label16" Runat="server" Text="Provincia:">Serie del Material:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="ddlSerieEquipo" onkeydown="" runat="server" Width="150px" CssClass="clsSelectEnable"
										onchange=""></asp:dropdownlist></td>
								<td class="Arial10B" align="right"><input class="Boton" id="btnGrabar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand"
										onclick="grabarPedido();" onmouseout="this.className='Boton';" type="button" value="Grabar" name="btnGrabar">&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label17" Runat="server" Text="Dirección:">Campaña:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 250px"><asp:dropdownlist id="ddlCampania" onkeydown="" runat="server" Width="250px" CssClass="clsSelectEnable"
										onchange="resetearBusquedaXCampania();"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label18" Runat="server" Text="Departamento:">Plan Tarifario:</asp:label></td>
								<td class="Arial10B" align="left" width="150"><asp:dropdownlist id="ddlPlanTarifario" onkeydown="" runat="server" Width="150px" CssClass="clsSelectEnable"
										onchange="cargarListaPrecios();"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label19" Runat="server" Text="Provincia:">Lista de Precio:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="ddlListaPrecio" onkeydown="" runat="server" Width="150px" CssClass="clsSelectEnable"
										onchange="javascript:cargarPrecio();"></asp:dropdownlist></td>
								<td class="Arial10B" align="right"><input class="Boton" id="btnCancelarPedido" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand" onclick="cancelarPedido();" onmouseout="this.className='Boton';"
										type="button" value="Cancelar" name="btnCancelarPedido">&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;
									<asp:label id="Label24" Runat="server" Text="Dirección:">Plazo Acuerdo:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 250px"><asp:dropdownlist id="ddlPlazoAcuerdo" runat="server" Width="250px" CssClass="clsSelectEnable0"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label20" Runat="server" Text="Dirección:">Precio de Venta:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtPrecioVenta" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="150px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label22" Runat="server" Text="Departamento:">Descuento Equipo:</asp:label></td>
								<td class="Arial10B" align="left" width="150"><asp:textbox onkeypress="return fSoloMontos(event, this);" onpaste="return false;" id="txtDescuentoEquipo"
										ondrop="return false;" Runat="server" CssClass="clsInputEnableB" MaxLength="7" width="150px"></asp:textbox></td>
								<td class="Arial10B" align="right"><input class="Boton" id="btnDescuentoEquipo" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand" onclick="validarDescuento();" onmouseout="this.className='Boton';"
										type="button" value="Validar Descuento" name="btnDescuentoEquipo">&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">&nbsp;</td>
								<td class="Arial10B" style="WIDTH: 250px">&nbsp;</td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="lblDescuentoClaroClub" Runat="server" Text="Provincia:">Descuento Claro Club:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtDescuentoClaroClub" Runat="server" CssClass="clsInputDisable" ReadOnly="True"
										width="150px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 120px">&nbsp;
									<asp:label id="Label23" Runat="server" Text="Provincia:">Total a Pagar:</asp:label></td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtTotalAPagar" Runat="server" CssClass="clsInputDisable" ReadOnly="True" width="150px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">
									<P>
										<!-- Inicio E77658 --><asp:checkbox id="chkRetenido" onclick="chkRetenido_onclick();" runat="server" Text="Retenido"></asp:checkbox><br>
										<asp:checkbox id="chkFidelizado" onclick="chkFidelizado_onclick();" runat="server" Text="Fidelizado"></asp:checkbox>
										<!-- Fin E77658 --></P>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="20"></td>
				</tr>
				<!-- Final del formulario --></table>
			<!-- los hidden que utilizo --><input id="hidMsg" type="hidden" name="hidMsg" runat="server">
			<input id="hidMaxLenTipoDoc" type="hidden" name="hidMaxLenTipoDoc" runat="server">
			<input id="hidNroDocumento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidNroDocumento"
				runat="server"> <input id="hidTipoDocumento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoDocumento"
				runat="server"> <input id="hidNroLinea" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidNroLinea"
				runat="server"> <input id="hidCO" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCO"
				runat="server"> <input id="hidAccion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidAccion"
				runat="server"> <INPUT id="hidIMSI" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidIMSI"
				runat="server"> <INPUT id="hidPlanAct" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPlanAct"
				runat="server"> <INPUT id="hidCicloFact" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCicloFact"
				runat="server"> <INPUT id="hidNomCli" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidNomCli"
				runat="server"> <INPUT id="hidTipoCli" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoCli"
				runat="server"> <INPUT id="hidLimiteCred" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidLimiteCred"
				runat="server"> <INPUT id="hidCorreo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCorreo"
				runat="server"> <INPUT id="hidTelefonoReferencia" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidTelefonoReferencia" runat="server"> <INPUT id="hidDireccion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidDireccion"
				runat="server"> <INPUT id="hidDepartamento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidDepartamento"
				runat="server"> <INPUT id="hidProvincia" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidProvincia"
				runat="server"> <INPUT id="hidDistrito" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidDistrito"
				runat="server"> <INPUT id="hidOfVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidOfVenta"
				runat="server"> <INPUT id="hidTipoVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoVenta"
				runat="server"> <INPUT id="hidEqSeleccionado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidEqSeleccionado"
				runat="server"> <INPUT id="hidItemSeleccionado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidItemSeleccionado" runat="server"> <INPUT id="hidSerieEquipo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidSerieEquipo"
				runat="server"> <INPUT id="hidPrecioTotal" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioTotal"
				runat="server"> <INPUT id="hidPrecioVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioVenta"
				runat="server"> <INPUT id="hidTipoOperacion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoOperacion"
				runat="server"> <INPUT id="hidFlagBuscando" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagBuscando"
				runat="server"> <INPUT id="hidFlagBuscandoPaso1" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFlagBuscandoPaso1" runat="server"> <INPUT id="hidFlagDescuento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagBuscandoPaso1"
				runat="server"> <INPUT id="hidDescuento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidDescuento"
				runat="server"> <INPUT id="hidTipoDocVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoDocVenta"
				runat="server"> <INPUT id="hidPrecios" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecios"
				runat="server"> <INPUT id="hidReintegro" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidReintegro"
				runat="server"> <INPUT id="hidFlagReintegro" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagReintegro"
				runat="server"> <INPUT id="hidFlagExonerarReintegro" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFlagExonerarReintegro" runat="server"> <INPUT id="hidFlagConfExoneracionReintegro" style="WIDTH: 8px; HEIGHT: 22px" type="hidden"
				size="1" name="hidFlagExonerarReintegro" runat="server"> <INPUT id="hidOpcionAutorizacion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidOpcionAutorizacion" runat="server"> <INPUT id="hidFechaPenalidad" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFechaPenalidad"
				runat="server"> <INPUT id="hidPrecioSeleccionado" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidPrecioSeleccionado" runat="server"> <INPUT id="hidNumeroDocumento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidNumeroDocumento" runat="server"> <INPUT id="hidModalidad" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidModalidad"
				runat="server"> <INPUT id="hidCuenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCuenta"
				runat="server"> <INPUT id="hidCustumerId" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCustumerId"
				runat="server"> <INPUT id="hidCanalOf" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCanal"
				runat="server"> <INPUT id="hidOrgVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidOrgVenta"
				runat="server"> <INPUT id="hidCampaniaSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidCampaniaSelected" runat="server"> <INPUT id="hidPlanTarifaSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidPlanTarifaSelected" runat="server"> <INPUT id="hidlistaPrecioSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidlistaPrecioSelected" runat="server"> <INPUT id="hidNroPedido" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidNroPedido"
				runat="server"> <INPUT id="hidnroContrato" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidnroContrato"
				runat="server"> <INPUT id="hidFlagRenovacionAdelantada" style="WIDTH: 8px; HEIGHT: 22px" type="hidden"
				size="1" name="hidFlagRenovacionAdelantada" runat="server"> <INPUT id="hidApellidosCli" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidApellidosCli"
				runat="server"> <INPUT id="hidNombresCli" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidNombresCli"
				runat="server"> <INPUT id="hidTitular" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTitular"
				runat="server"> <INPUT id="hidRepresentante" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidRepresentante"
				runat="server"> <INPUT id="hidMesesPorVencerApadece" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidMesesPorVencerApadece" runat="server"> <INPUT id="hidFechaInicioApadece" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFechaInicioApadece" runat="server"> <INPUT id="hidFechaFinApadece" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFechaFinApadece" runat="server"> 
			<!-- Inicio E77568	-->
			<INPUT id="hdnRetenidoFidelizado" type="hidden" name="hdnRetenidoFidelizado" runat="server">
			<INPUT id="hidMontoMaxDesAS" type="hidden" name="hidMontoMaxDesAS" runat="server">
			<INPUT id="hidMesesMaxAS" type="hidden" name="hidMesesMaxAS" runat="server"> 
			<!-- Inicio PS - Automatización de canje y nota de crédito -->
			<input id="hidFactorClaroClub" type="hidden" name="hidFactorClaroClub" runat="server">
			<input id="hidErrorClaroClub" type="hidden" name="hidErrorClaroClub" runat="server">
			<input id="hidErrorClaroClubDesfase" type="hidden" name="hidErrorClaroClubDesfase" runat="server">
			<input id="hidTipoDocumentos" type="hidden" name="hidTipoDocumentos" runat="server">
			<input id="hidTieneReserva" type="hidden" name="hidTieneReserva" runat="server">
			<input id="hidIDCAMPANA" type="hidden" name="hidIDCAMPANA" runat="server"> 
			<input id="hidCCMinimoPuntos" type="hidden" name="hidCCMinimoPuntos" runat="server">
			<input id="hidMinimoSoles" type="hidden" name="hidMinimoSoles" runat="server"> 
			<input id="hidErrorCCPuntosMinimos" type="hidden" name="hidErrorCCPuntosMinimos" runat="server">
			<input id="hidClaroClubSolesDeDescuento" type="hidden" name="hidClaroClubSolesDeDescuento"
				runat="server"> 
			<input id="hidSaldosCC" type="hidden" name="hidSaldosCC" value="0" runat="server" />
			<!-- Fin Inicio PS - Automatización de canje y nota de crédito	-->
			<!-- Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos	-->
			<input id="hidErrorCodeWSCC" type="hidden" name="hidErrorCodeWSCC" value="0" runat="server">
			<input id="hidDetalleDescuento" type="hidden" name="hidDetalleDescuento" runat="server">
			<input id="hidPuntosQuivalentes" type="hidden" name="hidPuntosQuivalentes" runat="server">
			<!-- Fin IDEA-13006 ClaroClub - Mejoras en notas de créditos-->
			<!-- Fin E77568	-->
			<!--iframes utilizados--><iframe id="ifrConsultarListaPrecios" name="ifrConsultarListaPrecios" width="0" scrolling="no"
				height="0"></iframe><iframe id="ifrConsultarPrecio" name="ifrConsultarPrecio" width="0" scrolling="no" height="0">
			</iframe>
		</form>
	</body>
</HTML>
 
 
 
 
