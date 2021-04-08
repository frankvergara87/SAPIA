<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_venta_postpago.aspx.vb" Inherits="sisact_venta_postpago"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact - Venta Chip Repuesto Postventa</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta content="no-cache" http-equiv="Cache-Control">
		<meta content="no-cache" http-equiv="Pragma">
		<meta content="0" http-equiv="Expires">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript">
			//                     DNI   CIP   CE    RUC   PAS
			var arrayTipoDocPVU = ['01', '02', '04', '06', '07'];
			var arraySizeDocPVU = [ 8  ,  15 ,  9 ,  11 ,  15 ];

			function consultar() {
				//Validar Punto de venta reposicion
				if (!validarPuntoVentaReposicion()){
					alert(getValue('hidMensajeReposicion'));
					return false;
				}
				var objCombo = document.getElementById('btnConsultar').value;
				if ( objCombo == 'Buscar' ) {

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
					setValue('hidAccion', 'Consultar');
					document.frmPrincipal.submit();			
							
				} else if ( objCombo == 'Nueva Busqueda' ) {
					HabilitarControles(true);
					LimpiarControles();
					setVisible('trPasoDetalle', false);
					setVisible('trDetalle', false);
					setVisible('trBotones', false);
					document.getElementById('btnConsultar').value = 'Buscar';
				}
			}
			function validarPuntoVentaReposicion(){
				if(getValue('hidMensajeReposicion') != ""){
					return false;
				}
				return true;
			}
			
			function validaFlujo(mensaje) {
				if(getValue('hidMensajeValidaCliente') == mensaje){
					//Se validad Black list
					validarBlackListComision();
					
					//Muestra el detalle de la venta
					//muestraDetalleVenta();	
				}
			}		
			function muestraDetalleVenta(){
				document.getElementById('btnConsultar').value = 'Nueva Busqueda';
				HabilitarControles(false);
				setVisible('trDetalle', true);
				setVisible('trBotones', true);			
				LimpiarControlesDetalle();	
				document.getElementById('btnGenerarPedido').disabled = true;
				mostrarArticuloPorCanal();	
			}	
			function mostrarArticuloPorCanal(){
				var codCanalVenta = getValue('hidCanalVenta');
				switch(codCanalVenta)
				{
				case "01":
					setVisible('trCAC', true);
					setVisible('trDAC_CORNER', false);
					document.getElementById('spanDesArticulo').style.display = 'none';					
					document.getElementById('spanPuntosArticulo').style.display = 'none';
					document.getElementById('txtDescArticulo').style.display = 'none';
					break;
				default:
					setVisible('trCAC', false);
					setVisible('trDAC_CORNER', true);
					document.getElementById('spanDesArticulo').style.display = '';					
					document.getElementById('spanPuntosArticulo').style.display = '';
					document.getElementById('txtDescArticulo').style.display = '';
				}
			}			
			
			//Cambiar Articulo
			function f_CambiaIccid()
			{
				// Deshabilitar combos
				setEnabled('ddlCampania', true, 'clsSelectEnable0');
				setEnabled('ddlPrecio', true, 'clsSelectEnable0');
					
				if (getValue('ddlDesArticulo') == "00")
				{
					setValue('txtCodMaterial', '');					
					setValue('hidDesMaterial', '');	
					ResetSerie();
				}
				else{
					var serverURL = 'sisact_ifr_combos.aspx';
					
					var objICCID = document.getElementById('ddlDesArticulo');
					var articuloImei = getValue('ddlDesArticulo').substring(0,10);

					//se carga el codigo del material seleccionado
					setValue('txtCodMaterial', getValue('ddlDesArticulo'));
					setValue('hidDesMaterial', getText('ddlDesArticulo'));

					if (objICCID.selectedIndex > 0){
						consultarIccidCAC(articuloImei);
					}else{
						ResetSerie();
					}
				}
			}
			
			function consultarIccidCAC(codIccid) {				
				var _parametros = "codIccid="+codIccid+"&nroLinea="+getValue('txtNroLinea')+"&canalVenta="+getValue('hidCanalVenta')+"&codOfVenta="+getValue('hidOfVenta');
				document.getElementById('ifrBuscarIccid').src= "sisact_ifr_consulta_iccid.aspx?"+_parametros;
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;
			}
			
			function responseConsultarIccidCAC(datos){
				if (datos != ""){
					document.getElementById("tdSerieIccid").innerHTML = datos;
					setEnabled('cboICCIDArt', false, 'clsSelectEnable0');
				}
				else {
					ResetSerie();
					alert("No hay series IMEIS disponibles");
				}
			}
			
			function ResetSerie(){
				var strHTML = "&nbsp;<select id=cboICCIDArt name=cboICCIDArt class=clsSelectEnable style='width:200px'></select>";
				document.getElementById("tdSerieIccid").innerHTML = strHTML;
				setEnabled('cboICCIDArt', true, 'clsSelectEnable0');
			}
			
			function selectedICCID(val){		
				if (val == "0000000000"){
					// Resetear 
					var selObjP = document.getElementById('ddlPrecio');
					var selObjC = document.getElementById('ddlCampania');
					selObjP.length = 0;
					selObjC.length = 0;
					setEnabled('ddlCampania', true, 'clsSelectEnable0');
					setEnabled('ddlPrecio', true, 'clsSelectEnable0');
				}else{
					setValue('hidIccid', val);
					// Habilitar combos
					setEnabled('ddlCampania', false, 'clsSelectEnable0');
					setEnabled('ddlPrecio', false, 'clsSelectEnable0');					
					// Cargar Campañas - Valor por default
					cargarCampanias(); setValue('ddlCampania', getValue('hidCampaniaDefault'));
					// Cargar Lista de Precios - Valor por default
					cargarListaPrecios();
				}
			}
			
			function cambiarTipoDoc(valor) {
				if ( valor != '00' ) {
					setValue('txtNumeroDocId','');
					setValue('txtNroLinea','');
					setValue('txtHlr','');
					setValue('txtNombreCliente','');
					document.getElementById('lblMensaje').innerHTML = '';
					var indexOf = getIndexOf(arrayTipoDocPVU, valor);
					document.getElementById('txtNumeroDocId').readOnly = false;
					document.getElementById('txtNumeroDocId').maxLength = arraySizeDocPVU[indexOf];
					
					// Validar Ingreso Numerico solo para los Casos DNI y RUC
					if (valor == '01' || valor== '06') {
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarNumero(event) };
					} else {
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarAlfaNumerico(event) };
					}
				}
			}	
			function consultarIccid() {
				if ( !ValidaCampo('document.frmPrincipal.txtSerieChip','Debe ingresar el número de serie(Iccid).') ) return false;
				var _parametros = "codIccid="+getValue('txtSerieChip')+"&nroLinea="+getValue('txtNroLinea')+"&canalVenta="+getValue('hidCanalVenta')+"&codOfVenta="+getValue('hidOfVenta');
				document.getElementById('ifrBuscarIccid').src= "sisact_ifr_consulta_iccid.aspx?"+_parametros;
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;
			}	
			
			function responseConsultarIccid(datos) {
				var arrayDatos = datos.split(',');
				// Se valida el material
				if ( !validarMaterialesPostpago(arrayDatos[0]) ){
					setFocus('txtSerieChip');
					alert('El material ' + arrayDatos[0] + ' no está disponible para la reposición.');
					return false;
				}
				setValue('txtCodMaterial', arrayDatos[0]);
				setValue('txtDescArticulo', arrayDatos[1]);
				setValue('hidDesMaterial', arrayDatos[1]);
				setValue('hidIccid', getValue('txtSerieChip'));

				// Codigo de Iccid
				setEnabled('txtSerieChip', true, 'clsInputEnable'); setReadOnly('txtSerieChip', true, 'clsInputEnable');
				// Deshabilitar el boton Validar Iccid
				setEnabled('btnValidarICCID', true, 'Boton');
				// Cargar Campañas - Valor por default
				cargarCampanias(); setValue('ddlCampania', getValue('hidCampaniaDefault'));
				// Cargar Lista de Precios - Valor por default
				cargarListaPrecios();
			}
			
			function validarMaterialesPostpago(codMaterial){
				// Validar uno a uno los materiales disponibles
				var _materiales = getValue('hidMaterialesPostpago').split('|');
				for (var i=0; i<_materiales.length; i++) {
					if (codMaterial == _materiales[i]){
						return true;
					}					
				}
				return false;
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
			function cargarListaPrecios() {
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlPrecio');
				selObjP.length = 1;
				
				// Resetear precios en las Hidden
				resetearMontos();
				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) return false;
				//if ( !ValidaCampo('document.frmPrincipal.hidIccid','Debe seleccionar una Serie.') ) return false;
				
				// Obtener la Campania Seleccionada
				var campaniaSelected = getValue('ddlCampania') + "," + getText('ddlCampania');
				setValue('hidCampaniaSelected', campaniaSelected);
														
				var params = "";
				var fecha = new Date();
				params = getValue('hidTipoVenta') + "," +
							getValue('hidPlanDefault') + "," +
							getValue('txtCodMaterial') + "," +
							getValue('ddlCampania') + "," +
							fecha.format('Y/m/d') + "," +
							getValue('hidTipoOperacion')  + "," +
							getValue('hidOrgVenta');
				consultarListaPrecios(params);
			}
			function consultarListaPrecios(params) {
				document.getElementById('ifrConsultarListaPrecios').src = "sisact_ifr_consulta_lista_precios.aspx?flgPrecioMae=1&params="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window.opener;
			}
			function responseConsultarListaPrecios(datos) {
				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlPrecio');
				selObjP.length = 0;

				// Poner uno a uno lista de precios disponibles
				var listaPrecios = datos.split(';');
				for (var i=0; i<listaPrecios.length; i++) {
					var opcion = listaPrecios[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}
				// Poner Valores por Defecto
				cargarListaPrecioDefault();
			}
			function cargarListaPrecioDefault() {
				if (getValue('ddlCampania') == getValue('hidCampaniaDefault')) {
					// Si existe la Lista de Precio poner x defecto
					var selObjP = document.getElementById('ddlPrecio');
					for (var i=0; i<selObjP.options.length; i++) {
						if (selObjP.options[i].value == getValue('hidListaPrecioDefault')) {
							setValue('ddlPrecio', getValue('hidListaPrecioDefault'));
							// Consultar Precios
							cargarPrecio();
							break;
						}
					}
				}
			}
			function cargarPrecio() {
				if ( !ValidaCampo('document.frmPrincipal.ddlPrecio','Debe seleccionar una Lista de Precios.') ) return false;
				// Obtener la Lista de Precio Seleccionado
				var listaPrecioSelected = getValue('ddlPrecio') + "," + getText('ddlPrecio');
				setValue('hidPLSelected', listaPrecioSelected);
							
				var params = "";
				params = getValue('hidOfVenta') + "," +
							getValue('txtCodMaterial') + "," +
							getValue('ddlPrecio') + "," +
							getValue('hidIccid') + "," +  //getValue('txtSerieChip') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocVenta') 
							+ "," + "" + "," + "" + "," + "";
				consultarPrecios(params);
			}
			function consultarPrecios(params) {
				resetearMontos(); // Resetear precios
				document.getElementById('ifrConsultarPrecio').src = "sisact_ifr_consulta_precio.aspx?params="+params;
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
			}
			function responseConsultarPrecios(datos) {
				// Obtener Precio de Venta - Precio de Lista
				var arrayPrecio = datos.split(',');
				var precioLista = eval(arrayPrecio[0]);
				var precioVenta = eval(arrayPrecio[1]);
				// Precio Venta - Precio Lista
				setValue('hidPrecioTotal', precioVenta);
				setValue('hidPrecioSubTotal', precioLista);
				setValue('txtTotal', precioVenta);
				// Habilitar el boton Grabar
				setEnabled('btnGenerarPedido', false, 'Boton');				
			}											
			function LimpiarControles() {
				setValue('txtHlr', '');
				setValue('txtNroLinea', '');
				setValue('txtNombreCliente', '');			
				setValue('ddlTipoDocId', '00');
				setValue('txtNumeroDocId', '');
			}
			function LimpiarControlesDetalle() {
				setValue('txtCodMaterial', '');
				setValue('txtDescArticulo', '');
				setValue('ddlPrecio', '00');
				setValue('ddlCampania', '00');
				setValue('txtTotal', '0.00');
				setValue('txtSerieChip', '');
			} 
			function resetearMontos() {
				setValue('hidPrecioTotal', '0.00');
				setValue('hidPrecioSubTotal', '0.00');
				setValue('txtTotal', '0.00');				
			}
			function HabilitarControles(flag) {
				document.getElementById('ddlTipoDocId').disabled = !flag;			
				document.getElementById('txtNumeroDocId').disabled = !flag;
				document.getElementById('txtNroLinea').disabled = !flag;
			} 				
			function generarAcuerdo() {
				//if ( !ValidaCampo('document.frmPrincipal.txtSerieChip','Debe ingresar el número de Serie(Iccid).') ) return false;				
				if ( !ValidaCampo('document.frmPrincipal.hidIccid','Debe ingresar el número de Serie(Iccid).') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlPrecio','Debe seleccionar una Lista de Precios.') ) return false;
				
				//Validar Ubigeo
				if ( !ValidaCampo('document.frmPrincipal.ddlDepartamento','Debe seleccionar un departamento.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlProvincia','Debe seleccionar una provincia.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlDistrito','Debe seleccionar un distrito.') ) return false;
				
				if ( !confirm("Está seguro de GENERAR el Pedido?") ) {
					return;
				} else {
					setValue('hidAccion', 'GenerarPedido');
					document.frmPrincipal.submit();				
				}
			}
			function cancelar() {
				setValue('txtSerieChip','');			
				LimpiarControlesDetalle();
				document.getElementById('btnGenerarPedido').disabled = true;
				setEnabled('btnValidarICCID', false, 'Boton');
				setEnabled('txtSerieChip', false, 'clsInputEnable'); setReadOnly('txtSerieChip', false, 'clsInputEnable');
			}
			function inicio() {
				mostrarMensaje();
			}
			function reload() {
				setVisible('trDetalle', false);
				setVisible('trBotones', false);			
				LimpiarControlesDetalle();
				mostrarMensaje();
				window.location = window.location;
			}				
			function mostrarMensaje() {
				if ( getValue('hidMsg') != '' ) {
					alert(getValue('hidMsg'));
					setValue('hidMsg', '');
				}
			}
			function validarEnter(event) {
				if (event.keyCode == 13) {
					event.keyCode = 0;
					document.getElementById('btnConsultar').click();
				}
			}	
			
			function validarBlackListComision()
			{
				var url = '../renovacion/sisact_ifr_consulta_unificada.aspx?';
				url += 'strPerfil149=' + getValue('hidPerfil_149');
				url += '&strTipoDocumento=' + getValue('ddlTipoDocId');
				url += '&strNroDoc=' + getValue('txtNumeroDocId');
				url += '&strOficina=' + getValue('hidOfVenta');
				url += '&strTipoOficina=' + getValue('hidCanalVenta');
				url += '&strMetodo=' + 'ValidarBlacklistComisionPostpago';
				//url += '&strPageInvoke=' + 'ChipRepuestoPostpago';
				self.frames['iframeAuxiliar'].location.replace(url);
			}
			
			function consultarBlacklist(blnBlackComision)
			{
				if (blnBlackComision == 'S')
				{
					alert("Cliente ingresado no puede ser evaluado, si requiere mayor información comunicarse al correo comisionesclaro@claro.com.pe");
					return;
				}
				consultarBSCS();
			}
			
			function consultarBSCS()
			{
				var url = '../renovacion/sisact_pop_detalle_linea.aspx?';
				url += 'nroDoc=' + getValue('txtNumeroDocId') + '&tipoDoc=' + getValue('ddlTipoDocId') + '&pageOpen=CR' + '&nrolinea=' + getValue('txtNroLinea');
				self.frames['iframeAuxiliar'].location.replace(url);
			}
			
			function retornoConsultaBSCS(blnBlackList, lblDeudaBloqueo, lblCategoriaCliente, blnEvaluarMovil, blnClienteExiste,strCalificacionPago)
			{
				if (blnBlackList == 'S') {
					alert("Cliente se encuentra en blacklist de clientes RUC");
					return;
				}
				//Deuda y/o Bloqueo				
				document.getElementById('lblMensaje').innerHTML = lblDeudaBloqueo;	
				if (blnEvaluarMovil.toUpperCase() == 'N')
				{					
					return;
				}
				
				if (blnClienteExiste == 'N') {
					alert("Cliente no existe!");
					return;
				}
				muestraDetalleVenta();		
			}
			
			function cargarProvincias(dpto_id){		
				
				var provincia = document.getElementById('ddlProvincia');				
				provincia.length = 0;
				var distrito = document.getElementById('ddlDistrito');					
				distrito.length = 0;	
					
				if (dpto_id == ""){							
					alert("Debe seleccionar un departamento");
				}
				else{
					var oElm, cad;
					provincia = document.getElementById('ddlProvincia');
					cad = getValue('hidCadenaProvincias');
					
					//Se carga el primer elememnto
					oElm = document.createElement("OPTION");
					oElm.value = "";
					oElm.text = "--Seleccionar--";
					provincia.add(oElm);
					
					//Recorrer las provincias
					var aProvincia = cad.split("|")
					var aDatos;
					for (i=0;i < aProvincia.length;i++){
						//alert(aProvincia[i]);
						aDatos = aProvincia[i].split(";");
						if ( aDatos[2] == dpto_id){
							oElm = document.createElement("OPTION");
							oElm.value = aDatos[0];
							oElm.text = aDatos[1];
							provincia.add(oElm);
						}
					}
				}
			}
			
			function cargarDistritos(prov_id){	
				
				var distrito = document.getElementById('ddlDistrito');
				distrito.length = 0;
				
				if (prov_id == ""){						
					setValue('hidProvinciaSelected','');	
					alert("Debe seleccionar una provincia");
				}
				else{
					var oElm, cad;
					cad = getValue('hidCadenaDistritos');
					
					//se guarda la provincia seleccionada					
					setValue('hidProvinciaSelected',prov_id);
					
					//Se carga el primer elememnto
					oElm = document.createElement("OPTION");
					oElm.value = "";
					oElm.text = "--Seleccionar--";
					distrito.add(oElm);
					
					//Recorrer las provincias
					var aDistrito = cad.split("|")
					var aDatos;
					for (i=0;i < aDistrito.length;i++){
						aDatos = aDistrito[i].split(";");
						if ( aDatos[3] == prov_id){
							oElm = document.createElement("OPTION");
							oElm.value = aDatos[0];
							oElm.text = aDatos[1];
							distrito.add(oElm);
						}
					}
				}
			}			
			
			function selectedDistrito(dist_id)
			{
				if (dist_id == ""){						
					setValue('hidDistritoSelected','');	
					alert("Debe seleccionar un distrito");
				}
				else
				{
					//se guarda el distrito seleccionado				
					setValue('hidDistritoSelected',dist_id);
				}
			}
								
		</script>
	</HEAD>
	<body onload="inicio();" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table style="WIDTH: 100%; HEIGHT: 100px" class="contenido" border="0" cellSpacing="2"
							cellPadding="0">
							<tr>
								<td class="Header" height="20" align="center">&nbsp;Venta de Chip Repuesto Postpago</td>
							</tr>
							<tr>
								<td class="Header" height="20" align="left">&nbsp;Validación del Cliente</td>
							</tr>
							<tr>
								<td>
									<table style="WIDTH: 100%" border="0" cellSpacing="4" cellPadding="0">
										<tr>
											<td style="WIDTH: 109px" class="Arial10B">Tipo Documento(*) :</td>
											<td style="WIDTH: 3px" class="Arial10B"><asp:dropdownlist onkeydown="javascript:validarEnter(event);" id="ddlTipoDocId" runat="server" CssClass="clsSelectEnable"
													Width="150px"></asp:dropdownlist></td>
											<td style="WIDTH: 110px" class="Arial10B">N° Doc. Identidad(*) :</td>
											<td style="WIDTH: 100px" class="Arial10B"><asp:textbox id="txtNumeroDocId" onkeypress="validaCaracteres('0123456789')" runat="server" CssClass="clsInputEnableB"
													Width="100px" MaxLength="11"></asp:textbox></td>
											<td style="WIDTH: 110px" class="Arial10B">Número de Línea(*):
											</td>
											<td style="WIDTH: 100px" class="Arial10B"><asp:textbox id="txtNroLinea" onkeypress="validaCaracteres('0123456789')" runat="server" CssClass="clsInputEnableB"
													Width="100px" MaxLength="9"></asp:textbox></td>
											<td style="WIDTH: 100px" class="Arial10B"><input style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnConsultar" class="Boton"
													onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="consultar();" value="Buscar"
													type="button" name="btnConsultar"></td>
										<tr>
											<td style="WIDTH: 109px" class="Arial10B">HLR :</td>
											<td class="Arial10B"><asp:textbox id="txtHlr" runat="server" CssClass="clsInputEnableB" Width="150px" ReadOnly="true"></asp:textbox></td>
											<td style="WIDTH: 110px" class="Arial10B">Nombre :</td>
											<td style="WIDTH: 300px" class="Arial10B" colSpan="3"><asp:textbox id="txtNombreCliente" runat="server" CssClass="clsInputEnableB" Width="200px" ReadOnly="true"></asp:textbox></td>
											<td style="WIDTH: 100px"><label id="lblMensaje" class="Arial10BRed"></label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPasoDetalle">
					<td>
						<table border="0" cellSpacing="1" cellPadding="0" width="100%">
							<tr>
								<!--td class="Arial10B" style="WIDTH: 100%" align="right"><input class="Boton" id="btnSiguiente" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="pasoVenta();" onmouseout="this.className='Boton';" type="button" value="Siguiente --" name="btnSiguiente">
								</td-->
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="DISPLAY: none" id="trDetalle">
					<td>
						<table class="contenido" cellSpacing="0" cellPadding="0" width="100%" height="200">
							<tr>
								<td class="header" height="20" width="100%">&nbsp;Dirección de Domicilio del 
									Cliente</td>
							</tr>
							<tr>
								<td class="contenido">
									<table style="WIDTH: 100%" border="0" cellSpacing="4" cellPadding="0">
										<tr>
											<td style="WIDTH: 109px" class="Arial10B">&nbsp;Departamento :</td>
											<td style="WIDTH: 100px" class="Arial10B">
												<asp:DropDownList id="ddlDepartamento" runat="server" Width="170px" CssClass="clsSelectEnable0"></asp:DropDownList></td>
											<td style="WIDTH: 109px" class="Arial10B">&nbsp;Provincia :</td>
											<td style="WIDTH: 100px" class="Arial10B">
												<asp:DropDownList id="ddlProvincia" runat="server" Width="170px" CssClass="clsSelectEnable0"></asp:DropDownList></td>
											<td style="WIDTH: 109px" class="Arial10B">&nbsp;Distrito :</td>
											<td style="WIDTH: 100px" class="Arial10B">
												<asp:DropDownList id="ddlDistrito" runat="server" Width="170px" CssClass="clsSelectEnable0"></asp:DropDownList></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="header" height="20" width="100%">&nbsp;Datos y Detalle de Venta</td>
							</tr>
							<tr>
								<td class="contenido">
									<table border="0" cellSpacing="4" cellPadding="0" width="100%">
										<tr>
											<td class="header" height="20" colSpan="6">Datos de la Venta</td>
										</tr>
										<tr>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Vendedor</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:textbox id="txtVendedor" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp;Fecha de Venta</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:textbox id="txtFecha" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
										<tr>
											<td class="header" height="20" colSpan="6">Detalle de la Venta</td>
										</tr>
										<tr id="trCAC">
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Descripción de Artículo</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:dropdownlist id="ddlDesArticulo" runat="server" CssClass="clsSelectEnable0" Width="230px"></asp:dropdownlist>
											</td>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Serie Chip (Iccid)</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" id="tdSerieIccid" class="Arial10B">&nbsp;<select style="WIDTH: 200px" id="cboICCIDArt" class="clsSelectEnable" name="cboICCIDArt"></select></td>
										</tr>
										<tr id="trDAC_CORNER">
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Serie Chip (Iccid)</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td class="Arial10B" colSpan="4">&nbsp;<asp:textbox id="txtSerieChip" onkeypress="validaCaracteres('0123456789')" runat="server" Width="120px"
													MaxLength="18" cssclass="clsInputEnableB"></asp:textbox>&nbsp;<INPUT style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnValidarICCID" class="Boton"
													onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:consultarIccid();" value="Validar ICCID" type="button"
													name="btnValidarICCID"></td>
										</tr>
										<tr>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Código de Material</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:textbox id="txtCodMaterial" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp;<span id="spanDesArticulo">Descripción 
													de Artículo</span></td>
											<td style="WIDTH: 10px" class="Arial10B"><span id="spanPuntosArticulo">:</span></td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:textbox id="txtDescArticulo" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
										<tr>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Campaña</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:dropdownlist id="ddlCampania" runat="server" CssClass="clsSelectEnable0" Width="230px"></asp:dropdownlist>
											</td>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp;Lista de Precios</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td style="WIDTH: 250px" class="Arial10B">&nbsp;<asp:dropdownlist id="ddlPrecio" runat="server" CssClass="clsSelectEnable0" Width="200px"></asp:dropdownlist>
											</td>
										</tr>
										<tr>
											<td style="WIDTH: 150px" class="Arial10B">&nbsp; Total S/.</td>
											<td style="WIDTH: 10px" class="Arial10B">:</td>
											<td class="Arial10B" colSpan="4">&nbsp;<asp:textbox id="txtTotal" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="DISPLAY: none" id="trBotones">
					<td align="center">
						<table border="0" cellSpacing="0" cellPadding="0" width="50%">
							<tr style="HEIGHT: 30px">
								<td style="WIDTH: 50%" class="Arial10B" align="center">&nbsp; <input style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnGenerarPedido" class="Boton"
										onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:generarAcuerdo();" value="Grabar" type="button"
										name="btnGenerarPedido">
								</td>
								<td style="WIDTH: 50%" class="Arial10B" align="center"><input style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnCancelarPlan" class="Boton"
										onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:cancelar();" value="Cancelar"
										type="button" name="btnCancelarPlan">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<iframe id="ifrBuscarIccid" height="0" width="0" name="ifrBuscarIccid" scrolling="no">
			</iframe><iframe id="ifrConsultarListaPrecios" height="0" width="0" name="ifrConsultarListaPrecios"
				scrolling="no"></iframe><iframe id="ifrConsultarPrecio" height="0" width="0" name="ifrConsultarPrecio" scrolling="no">
			</iframe><iframe id="iframeAuxiliar" height="10" frameBorder="no" width="10" name="iframeAuxiliar">
			</iframe><input id="hidMsg" type="hidden" name="hidMsg" runat="server"> <input id="hidAccion" type="hidden" name="hidAccion" runat="server">
			<input id="hidMensajeValidaCliente" type="hidden" name="hidMensajeValidaCliente" runat="server">
			<input id="hidTipoVenta" type="hidden" name="hidTipoVenta" runat="server"> <input id="hidTipoCliente" type="hidden" name="hidTipoCliente" runat="server">
			<input id="hidTipoOperacion" type="hidden" name="hidTipoOperacion" runat="server">
			<input id="hidTelefono" type="hidden" name="hidTelefono" runat="server"> <input id="hidPrecioSubTotal" type="hidden" name="hidPrecioSubTotal" runat="server">
			<input id="hidPrecioTotal" type="hidden" name="hidPrecioTotal" runat="server"> <input id="hidOfVenta" type="hidden" name="hidOfVenta" runat="server">
			<input id="hidIccid" type="hidden" name="hidIccid" runat="server"> <input id="hidOK" type="hidden" name="hidOK" runat="server">
			<input id="hidCampaniaDefault" type="hidden" name="hidCampaniaDefault" runat="server">
			<input id="hidListaPrecioDefault" type="hidden" name="hidListaPrecioDefault" runat="server">
			<input id="hidTipoDocVenta" type="hidden" name="hidTipoDocVenta" runat="server">
			<input id="hidCampanias" type="hidden" name="hidCampanias" runat="server"> <input id="hidPlanDefault" type="hidden" name="hidPlanDefault" runat="server">
			<input id="hidPLSelected" type="hidden" name="hidPLSelected" runat="server"> <input id="hidCampaniaSelected" type="hidden" name="hidCampaniaSelected" runat="server">
			<input id="hidCanal" type="hidden" name="hidCanal" runat="server"> <input id="hidOrgVenta" type="hidden" name="hidOrgVenta" runat="server">
			<input id="hidCanalVenta" type="hidden" name="hidCanalVenta" runat="server"> <input id="hidNroDoc" type="hidden" name="hidNroDoc" runat="server">
			<input id="hidCadenaPlanesAceptados" type="hidden" name="hidCadenaPlanesAceptados" runat="server">
			<input id="hidCadenaServiciosRechazados" type="hidden" name="hidCadenaServiciosRechazados"
				runat="server"> <input id="hidMaterialesPostpago" type="hidden" name="hidMaterialesPostpago" runat="server">
			<input id="hidMensajeReposicion" type="hidden" name="hidMensajeReposicion" runat="server">
			<input id="hidPerfil_149" type="hidden" name="hidPerfil_149" runat="server"> <input id="hidCadenaProvincias" type="hidden" name="hidCadenaProvincias" runat="server">
			<input id="hidCadenaDistritos" type="hidden" name="hidCadenaDistritos" runat="server">
			<input id="hidDatosCliente" type="hidden" name="hidDatosCliente" runat="server">
			<input id="hidTipoDocCliente" type="hidden" name="hidTipoDocCliente" runat="server">
			<input id="hidDesMaterial" type="hidden" name="hidDesMaterial" runat="server"> 
                        <input id="hidProvinciaSelected" type="hidden" name="hidProvinciaSelected" runat="server">
			<input id="hidDistritoSelected" type="hidden" name="hidDistritoSelected" runat="server">
		</form>
	</body>
</HTML>
