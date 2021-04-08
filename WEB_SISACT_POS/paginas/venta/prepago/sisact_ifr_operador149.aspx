<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_operador149.aspx.vb" Inherits="sisact_ifr_operador149" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact - Pool Venta Express</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-Equiv="Cache-Control" Content="no-cache">
		<meta http-Equiv="Pragma" Content="no-cache">
		<meta http-Equiv="Expires" Content="0">
		<link href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
			}

			function cargarListaPuntosVenta(valor) {
				//debugger
				// Resetear las opciones ya agregadas en el DDL
				// Poner uno a uno los Puntos de Venta asociados al Canal actual
				if (valor==""){
					var selObjP = document.getElementById('ddlPuntoVenta');
					selObjP.length = 0;

					var canal = getValue('ddlCanal');
					var puntosVenta = getValue('hidPuntosVentas').split('|');
					for (var i=0; i<puntosVenta.length; i++) {
						var items = puntosVenta[i].split(';');
						if (items[2] == canal || items[2] == '00') {
							addOption(selObjP, items[0], items[1]);
						}
					}
					consultarListaVendedores(getValue('ddlPuntoVenta'));
					setFocus('ddlPuntoVenta');
				}
				else
				{
					consultarListaVendedores(valor);
					setFocus('ddlPuntoVenta');				
				}
			}

			function cargarListaVendedores(valor) {
			
				var objDdl = document.getElementById('ddlPuntoVenta');
				var idx = objDdl.selectedIndex
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hidPuntoVenta', valorTmp + ";" + textoTmp);

				setValue('hidVendedor', "");
				// Actualizar la Lista de Vendedores
				consultarListaVendedores(getValue('ddlPuntoVenta'));				
				setFocus('ddlVendedorSAP');			
			}

			function consultarListaVendedores(oficina) {
				// No permitir la consulta, si no hay cod_oficina. Retornar la lista de vendedores solo: "Seleccionar"
				//debugger				
				if (oficina == "00") {
					respuestaConsultarListaVendedores("00,<%= ConfigurationSettings.AppSettings("Seleccionar") %>");
					return;
				}

				document.getElementById("ifrConsultarListaVendedores").src = "sisact_ifr_consulta_lista_vendedores_.aspx?oficina="+oficina;
				document.getElementById("ifrConsultarListaVendedores").contentWindow.opener = window.opener;
				
			}

			function respuestaConsultarListaVendedores(datos) {
				// Poner uno a uno los Vendedores de la Lista que deben pertenecen al Punto de Venta actual
				var selObjV = document.getElementById('ddlVendedorSAP');
				selObjV.length = 0;

				var listaVendedores = datos.split(';');
				for (var i=0; i<listaVendedores.length; i++) {
					var opcion = listaVendedores[i].split(',');
					addOption(selObjV, opcion[0], opcion[1]);
				}
				habilitarContinuar();
			}

			function habilitarContinuar() {
				var flag = true;
				if (getValue('ddlCanal')=="00" || getValue('ddlPuntoVenta')=="00" || getValue('ddlVendedorSAP')=="00"){
					flag = false;
				}
				var objDdl = document.getElementById('ddlVendedorSAP');
				var idx = objDdl.selectedIndex
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hidVendedorSAP', valorTmp + ";" + textoTmp);

				setEnabled('btnPaso1', !flag, 'Boton');
			}
			
			function verificar() {
				return !(getValue('ddlCanal')=="00" || getValue('ddlPuntoVenta')=="00" || getValue('ddlVendedorSAP')=="00");
			}
			function mostrarMensaje() {
				if (getValue('hidMsg') != '') {
					alert(getValue('hidMsg'));
					setValue('hidMsg','');
				}
			}
					
		</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" MS_POSITIONING="GridLayout"
		onload='inicio();' onkeydown="cancelBack();">
		<form id="frmOperador149" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trPaso1">
					<td>
						<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="20" colspan="7">&nbsp;Selección del Punto 
									de Venta</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">Canal (*)</td>
								<td style="WIDTH: 160px">
									<asp:dropdownlist id="ddlCanal" runat="server" onchange="cargarListaPuntosVenta('');" Width="150px"
										CssClass="clsSelectEnable"></asp:dropdownlist>
								</td>
								<td class="Arial10b" width="150">Punto Venta (*)</td>
								<td style="WIDTH: 210px">
									<asp:dropdownlist id="ddlPuntoVenta" runat="server" onchange="cargarListaVendedores('');" Width="200px"
										CssClass="clsSelectEnable"></asp:dropdownlist>
								</td>
								<td class="Arial10b" width="150">Vendedor (*)</td>
								<td style="WIDTH: 210px">
									<asp:dropdownlist id="ddlVendedorSAP" runat="server" onchange="habilitarContinuar();" Width="200px"
										CssClass="clsSelectEnable" ></asp:dropdownlist>
								</td>
								<td class="Arial10B" style="WIDTH: 150px" align="right">
									<asp:Button CssClass="Boton" id="btnPaso1" Runat="server" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" style="CURSOR: hand" Text="Siguiente -->" disabled
										Width="100" Height="19" />
									&nbsp;&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidPuntosVentas" type="hidden" name="hidMsg" runat="server" style="WIDTH: 30px; HEIGHT: 22px"
				size="1"> <input id="hidPuntoVenta" type="hidden" name="hidMsg" runat="server" style="WIDTH: 30px; HEIGHT: 22px"
				size="1"> <input id="hidVendedorSAP" type="hidden" name="hidMsg" runat="server" style="WIDTH: 30px; HEIGHT: 22px"
				size="1"> <input id="hidParamsListaVendedores" type="hidden" name="hidMsg" runat="server" style="WIDTH: 30px; HEIGHT: 22px"
				size="1"> <iframe id="ifrConsultarListaVendedores" name="ifrConsultarListaVendedores" width="0" height="0"
				scrolling="no"></iframe>
		</form>
	</body>
</HTML>
 
 
 
 
