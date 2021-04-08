<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_venta_prepago.aspx.vb" Inherits="sisact_venta_prepago" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact - Venta Chip Repuesto Prepago</title>
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
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript">
			//                     DNI   CIP   CE    RUC   PAS
			var arrayTipoDocPVU = ['01', '02', '04', '06', '07'];
			var arraySizeDocPVU = [ 8  ,  15 ,  9 ,  11 ,  15 ];

			function consultar() {
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
			function validaFlujo(mensaje) {
				if(getValue('hidMensajeValidaCliente') == mensaje){
					document.getElementById('btnConsultar').value = 'Nueva Busqueda';
					HabilitarControles(false);
					setVisible('trDetalle', true);
					setVisible('trBotones', true);			
					LimpiarControlesDetalle();	
					document.getElementById('btnGenerarPedido').disabled = true;										
				}
			}			
			function cambiarTipoDoc(valor) {
				if ( valor != '00' ) {
					setValue('txtNumeroDocId','');
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
				document.getElementById('ifrBuscarIccid').src= "sisact_ifr_consulta_iccid.aspx?codIccid="+getValue('txtSerieChip')+"&nroLinea="+getValue('txtNroLinea');
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;
			}	
			function responseConsultarIccid(datos) {
				var arrayDatos = datos.split(',');
				setValue('txtCodMaterial', arrayDatos[0]);
				setValue('txtDescArticulo', arrayDatos[1]);
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
				document.getElementById('ifrConsultarListaPrecios').src = "sisact_ifr_consulta_lista_precios.aspx?params="+params;
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
							getValue('txtSerieChip') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocVenta');
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
				if ( !ValidaCampo('document.frmPrincipal.txtSerieChip','Debe ingresar el número de Serie(Iccid).') ) return false;				
				if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) return false;
				if ( !ValidaCampo('document.frmPrincipal.ddlPrecio','Debe seleccionar una Lista de Precios.') ) return false;
				
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
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="inicio();" marginwidth="0" marginheight="0"
		MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table class="contenido" style="WIDTH: 100%; HEIGHT: 100px" cellSpacing="2" cellPadding="0"
							border="0">
							<tr>
								<td class="Header" align="center" height="20">&nbsp;Venta de Chip Repuesto Prepago</td>
							</tr>
							<tr>
								<td class="Header" align="left" height="20">&nbsp;Validación del Cliente</td>
							</tr>
							<tr>
								<td>
									<table style="WIDTH: 100%" cellSpacing="4" cellPadding="0" border="0">
										<tr>
											<td class="Arial10B" style="WIDTH: 109px">Tipo Documento(*) :</td>
											<td class="Arial10B" style="WIDTH: 3px"><asp:dropdownlist id="ddlTipoDocId" onkeydown="javascript:validarEnter(event);" runat="server" CssClass="clsSelectEnable"
													Width="150px"></asp:dropdownlist></td>
											<td class="Arial10B" style="WIDTH: 110px">N° Doc. Identidad(*) :</td>
											<td class="Arial10B" style="WIDTH: 100px"><asp:textbox id="txtNumeroDocId" runat="server" CssClass="clsInputEnableB" Width="100px" MaxLength="11"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 110px">Número de Línea(*):
											</td>
											<td class="Arial10B" style="WIDTH: 100px"><asp:textbox id="txtNroLinea" onkeydown="javascript:validarNumero(event);" runat="server" CssClass="clsInputEnableB"
													Width="100px" MaxLength="9"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 100px"><input class="Boton" id="btnConsultar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
													onclick="consultar();" onmouseout="this.className='Boton';" type="button" value="Buscar" name="btnConsultar"></td>
										<tr>
											<td class="Arial10B" style="WIDTH: 109px">HLR :</td>
											<td class="Arial10B" colSpan="6"><asp:textbox id="txtHlr" runat="server" CssClass="clsInputDisable" Width="150px" ReadOnly="true"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPasoDetalle">
					<td>
						<table cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr>
								<!--td class="Arial10B" style="WIDTH: 100%" align="right"><input class="Boton" id="btnSiguiente" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
										onclick="pasoVenta();" onmouseout="this.className='Boton';" type="button" value="Siguiente --" name="btnSiguiente">
								</td-->
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trDetalle" style="DISPLAY: none">
					<td>
						<table class="contenido" height="200" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td class="header" width="100%" height="20">&nbsp;Datos y Detalle de Venta</td>
							</tr>
							<tr>
								<td class="contenido">
									<table cellSpacing="4" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="6" height="20">Datos de la Venta</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp; Vendedor</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:textbox id="txtVendedor" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp;Fecha de Venta</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:textbox id="txtFecha" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
										<tr>
											<td class="header" colSpan="6" height="20">Detalle de la Venta</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp; Serie Chip (Iccid)</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" colSpan="4">&nbsp;<asp:textbox id="txtSerieChip" runat="server" Width="120px" cssclass="clsInputEnableB" onkeydown="javascript:validarNumero(event);"
													MaxLength="18"></asp:textbox>&nbsp;<INPUT class="Boton" id="btnValidarICCID" onmouseover="this.className='BotonResaltado';"
													style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" onclick="javascript:consultarIccid();" onmouseout="this.className='Boton';"
													type="button" value="Validar ICCID" name="btnValidarICCID"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp; Código de Material</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:textbox id="txtCodMaterial" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp;Descripción de Artículo</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:textbox id="txtDescArticulo" runat="server" Width="200px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp; Campaña</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:dropdownlist id="ddlCampania" runat="server" CssClass="clsSelectEnable0" Width="230px"></asp:dropdownlist>
											</td>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp;Lista de Precios</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" style="WIDTH: 250px">&nbsp;<asp:dropdownlist id="ddlPrecio" runat="server" CssClass="clsSelectEnable0" Width="200px"></asp:dropdownlist>
											</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 150px">&nbsp; Total S/.</td>
											<td class="Arial10B" style="WIDTH: 10px">:</td>
											<td class="Arial10B" colSpan="4">&nbsp;<asp:textbox id="txtTotal" runat="server" Width="120px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBotones" style="DISPLAY: none">
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="50%" border="0">
							<tr style="HEIGHT: 30px">
								<td class="Arial10B" style="WIDTH: 50%" align="center">&nbsp; <input class="Boton" id="btnGenerarPedido" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" onclick="javascript:generarAcuerdo();" onmouseout="this.className='Boton';" type="button" value="Grabar"
										name="btnGenerarPedido">
								</td>
								<td class="Arial10B" style="WIDTH: 50%" align="center"><input class="Boton" id="btnCancelarPlan" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" onclick="javascript:cancelar();" onmouseout="this.className='Boton';" type="button" value="Cancelar"
										name="btnCancelarPlan">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<iframe id="ifrBuscarIccid" name="ifrBuscarIccid" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrConsultarListaPrecios" name="ifrConsultarListaPrecios" width="0" scrolling="no"
				height="0"></iframe><iframe id="ifrConsultarPrecio" name="ifrConsultarPrecio" width="0" scrolling="no" height="0">
			</iframe><input id="hidMsg" type="hidden" name="hidMsg" runat="server"> <input id="hidAccion" type="hidden" name="hidAccion" runat="server">
			<input id="hidMensajeValidaCliente" type="hidden" name="hidMensajeValidaCliente" runat="server">
			<input id="hidTipoVenta" type="hidden" name="hidTipoVenta" runat="server"> <input id="hidTipoCliente" type="hidden" name="hidTipoCliente" runat="server">
			<input id="hidTipoOperacion" runat="server" type="hidden" name="hidTipoOperacion"> <input id="hidTelefono" type="hidden" name="hidTelefono" runat="server">
			<input id="hidPrecioSubTotal" type="hidden" name="hidPrecioSubTotal" runat="server">
			<input id="hidPrecioTotal" type="hidden" name="hidPrecioTotal" runat="server"> <input id="hidOfVenta" type="hidden" name="hidOfVenta" runat="server">
			<input id="hidIccid" type="hidden" name="hidIccid" runat="server"> <input id="hidOK" type="hidden" name="hidOK" runat="server">
			<input id="hidCampaniaDefault" type="hidden" name="hidCampaniaDefault" runat="server">
			<input id="hidListaPrecioDefault" type="hidden" name="hidListaPrecioDefault" runat="server">
			<input id="hidTipoDocVenta" type="hidden" name="hidTipoDocVenta" runat="server">
			<input id="hidCampanias" type="hidden" name="hidCampanias" runat="server"> <input id="hidPlanDefault" type="hidden" name="hidPlanDefault" runat="server">
			<input id="hidPLSelected" type="hidden" name="hidPLSelected" runat="server"> <input id="hidCampaniaSelected" type="hidden" name="hidCampaniaSelected" runat="server">
			<input id="hidCanal" type="hidden" name="hidCanal" runat="server"> <input id="hidOrgVenta" type="hidden" name="hidOrgVenta" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
