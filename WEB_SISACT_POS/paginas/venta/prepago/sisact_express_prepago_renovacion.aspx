<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_express_prepago_renovacion.aspx.vb" Inherits="sisact_express_prepago_renovacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Sisact - Pool Venta Express</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<link title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css" rel="stylesheet">
		<script src="../../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function consultar() {
				var numeroTelefono = getValue('txtNumeroTelefono');
				
				// Filtro por Numero Telefono
				if ( numeroTelefono == "" ) {
					alert('Error. Debe ingresar un Numero de Telefono.');
					setFocus('txtNumeroTelefono');
					return false;
				}

				return true;
			}

			function refrescar(pasoActual, pasosTotal){
				switch (pasoActual) {
					case 1:
						// Cargar Iframe de Operador 149
						document.getElementById('ifrOperador149').src = "sisact_ifr_operador149.aspx";
						document.getElementById('ifrOperador149').width = "100%";
						document.getElementById('ifrOperador149').height = "48px";

						// Quitar Referencia Iframe de Busqueda Prepago
						document.getElementById('ifrBusquedaPrepago').removeAttribute("src");
						document.getElementById('ifrBusquedaPrepago').width = "0px";
						document.getElementById('ifrBusquedaPrepago').height = "0px";

						// Quitar Referencia Iframe de Detalle Cliente
						document.getElementById('ifrDetalleCliente').removeAttribute("src");
						document.getElementById('ifrDetalleCliente').width = "0px";
						document.getElementById('ifrDetalleCliente').height = "0px";

						// Quitar Referencia Iframe de Detalle Venta Prepago
						document.getElementById('ifrDetalleVenta').removeAttribute("src");
						document.getElementById('ifrDetalleVenta').width = "0px";
						document.getElementById('ifrDetalleVenta').height = "0px";
						break;
					case 2:
						// Cargar Iframe de Busqueda Prepago
						document.getElementById('ifrBusquedaPrepago').src = "sisact_ifr_busqueda_prepago.aspx";
						document.getElementById('ifrBusquedaPrepago').width = "100%";
						document.getElementById('ifrBusquedaPrepago').height = "80px";

						// Quitar Referencia Iframe de Detalle Cliente
						document.getElementById('ifrDetalleCliente').removeAttribute("src");
						document.getElementById('ifrDetalleCliente').width = "0px";
						document.getElementById('ifrDetalleCliente').height = "0px";

						// Quitar Referencia Iframe de Detalle Venta Prepago
						//document.getElementById('ifrDetalleVenta').removeAttribute("src");
						document.getElementById('ifrDetalleVenta').width = "0px";
						document.getElementById('ifrDetalleVenta').height = "0px";
						break;
					case 3:
						// Cargar Iframe de Detalle Cliente
						document.getElementById('ifrDetalleCliente').src = "sisact_ifr_detalle_cliente.aspx";
						document.getElementById('ifrDetalleCliente').width = "100%";
						document.getElementById('ifrDetalleCliente').height = "120px";

						// Quitar Referencia Iframe de Detalle Venta Prepago
						document.getElementById('ifrDetalleVenta').removeAttribute("src");
						document.getElementById('ifrDetalleVenta').width = "0px";
						document.getElementById('ifrDetalleVenta').height = "0px";
						break;
					case 4:
						// Cargar Iframe de Detalle Venta Prepago
						document.getElementById('ifrDetalleVenta').src = "sisact_ifr_venta_prepago.aspx";
						document.getElementById('ifrDetalleVenta').width = "100%";
						document.getElementById('ifrDetalleVenta').height = "310px";
						break;
				}
				HabilitarPaso(pasoActual, pasosTotal);
			}

			function reload() {
				document.getElementById('ifrOperador149').removeAttribute("src");
				document.getElementById('ifrOperador149').width = "0px";
				document.getElementById('ifrOperador149').height = "0px";

				// Quitar Referencia Iframe de Busqueda Prepago
				document.getElementById('ifrBusquedaPrepago').removeAttribute("src");
				document.getElementById('ifrBusquedaPrepago').width = "0px";
				document.getElementById('ifrBusquedaPrepago').height = "0px";

				// Quitar Referencia Iframe de Detalle Cliente
				document.getElementById('ifrDetalleCliente').removeAttribute("src");
				document.getElementById('ifrDetalleCliente').width = "0px";
				document.getElementById('ifrDetalleCliente').height = "0px";

				// Quitar Referencia Iframe de Detalle Venta Prepago
				document.getElementById('ifrDetalleVenta').removeAttribute("src");
				document.getElementById('ifrDetalleVenta').width = "0px";
				document.getElementById('ifrDetalleVenta').height = "0px";

				mostrarMensaje();
				window.location = window.location;
			}
			function inicio() {
				mostrarMensaje();
			}
			function mostrarMensaje() {
				if (getValue('hidMsg') != '') {
					alert(getValue('hidMsg'));
					setValue('hidMsg','');
				}
			}			
		</script>
	</head>
	<body MS_POSITIONING="GridLayout" onload="inicio();" onkeydown="cancelBack();">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trPaso1" style="display: none">
					<td style="WIDTH: 988px">
						<table cellspacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<iframe id="ifrOperador149" name="ifrOperador149" runat="server" width="300px" height="300px" frameborder="3" scrolling="no"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPaso2" style="display: none">
					<td style="WIDTH: 988px">
						<table cellspacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<iframe id="ifrBusquedaPrepago" name="ifrBusquedaPrepago" runat="server" width="0px" height="0px" frameborder="0" scrolling="no"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPaso3" style="display: none">
					<td style="WIDTH: 988px">
						<table cellspacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<iframe id="ifrDetalleCliente" name="ifrDetalleCliente" runat="server" width="0px" height="0px" frameborder="0" scrolling="no"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPaso4" style="display: none">
					<td style="WIDTH: 988px">
						<table cellspacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<iframe id="ifrDetalleVenta" name="ifrDetalleVenta" runat="server" width="0px" height="0px" frameborder="0" scrolling="no"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:Button CssClass="Boton" id="btnActualizarFlujo" Runat="server" Text="Actualizar Flujo" style="display: none" />
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
		</form>
	</body>
</html>
 
 
 
 
