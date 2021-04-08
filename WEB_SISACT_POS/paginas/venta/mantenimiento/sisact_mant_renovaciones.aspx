<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_renovaciones.aspx.vb" Inherits="sisact_mant_renovaciones" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_cliente</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript">
			function inicio(){
				f_limpiar();
				mostrarMensaje();
			}
			function mostrarMensaje(){
				if (getValue('hidMsg') != ""){
					alert("Error: " + getValue('hidMsg'));
					setValue('hidMsg', '');
				}
			}
			function f_limpiar(){
				procesarDesdePool("Busqueda");
			}
			function procesarDesdePool(request) {
				setValue('hidRequest', request);

				switch (request) {					
					case "Consulta": //Consulta por TFI
						setValue('hidAccion','C');
						if (isVisible('tbPerfil148')) {
							hidden("Canal");
							hidden("PuntoVenta");
							hidden("VendedorSAP");
						}
						document.frmPrincipal.submit();	
						break;					
					case "Busqueda":
						
						if (isVisible('tbPerfil148')) {
							setEnabled('btnSiguiente', true, 'Boton');
							setEnabled('ddlCanal', true, 'clsSelectEnable');
							setEnabled('ddlPuntoVenta', true, 'clsSelectEnable');
							setEnabled('ddlVendedorSAP', true, 'clsSelectEnable');
							document.getElementById('chk148').checked = true;
						}
						setValue('hidResponse', 'Busqueda');
						break;
					case "Grabar":
						if (validarCampos()) {
							setValue('hidAccion','G');
							document.frmPrincipal.submit();		
						}
					break;
				}
				return;
			}
			function hidden(variable) {
				var objDdl = document.getElementById('ddl' + variable);
				var idx = objDdl.selectedIndex;
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hid' + variable, valorTmp + ";" + textoTmp);
			}

			function validarCampos() {
				var mensaje = "";
				if (document.getElementById('txtCantidad').value == ''){	mensaje = mensaje + "- Ingrese la cantidad de renovaciones permitidas\n"; }
				if (document.getElementById('txtPeriodo').value == ''){	mensaje = mensaje + "- Ingrese las cantidad de meses\n"; }
				
				if (mensaje != "") {
					alert(mensaje);
				}
				return (mensaje == "");
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
	<body onload="inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<table style="WIDTH: 832px" id="tbDatos" border="0" align="center" cellSpacing="0" cellPadding="0" width="832">
				<tr>
					<td class="Header" height="20" align="center">Limite de Renovaciones de Equipos 
						Prepago
					</td>
				</tr>
				<tr>
					<td>
						<table style="WIDTH: 832px" class="contenido" border="0" cellSpacing="2" cellPadding="0"
							width="832">
							<tr id="tr1">
								<td style="WIDTH: 25%; HEIGHT: 18px" class="Arial10B" width="19%">Cantidad de 
									Renovaciones(*)</td>
								<td width="1%" style="HEIGHT: 18px">:
								</td>
								<td style="WIDTH: 100px; HEIGHT: 18px" class="Arial10B" width="241">
									<asp:textbox id="txtCantidad" runat="server" CssClass="clsInputEnable" Width="50px" 
									onkeypress="f_ValidaIngreso('0123456789');" MaxLength="2">
									</asp:textbox></td>
							</tr>
							<tr id="tr2">
								<td style="WIDTH: 19%" class="Arial10B" width="19%">
									Periodo&nbsp;(*)</td>
								<td width="1%">:
								</td>
								<td style="WIDTH: 241px; HEIGHT: 13px" class="Arial10B" width="241">
									<asp:textbox id="txtPeriodo" runat="server" CssClass="clsInputEnable" Width="50px" 
									onkeypress="f_ValidaIngreso('0123456789');" MaxLength="2"></asp:textbox>&nbsp;Meses</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 19px" class="Arial10B" height="19" align="left">* Los campos en 
						(*) son los campos obligatorios que se deben llenar en el formulario.
					</td>
				</tr>
				<tr>
					<td height="5" align="left"></td>
				</tr>
				<TR>
					<TD height="20" align="center">
						<INPUT style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnGrabar" class="Boton" onmouseover="this.className='BotonResaltado';"
						onmouseout="this.className='Boton';" onclick="javascript:procesarDesdePool('Grabar');" value="Grabar" type="button" name="btnGrabar">&nbsp;
						<!--INPUT style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" id="btnCancelar" class="Boton" onmouseover="this.className='BotonResaltado';" 
						onmouseout="this.className='Boton';" onclick="f_cancelar()" value="Cancelar" type="button" name="btnCancelar"-->
					</TD>
				</TR>
				<TR>
					<TD height="20" align="left">
						<INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidAccion" size="1" type="hidden" name="hidAccion"
							runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidResponse" size="1" type="hidden" name="hidResponse"
							runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidMsg" size="1" type="hidden" name="hidMsg"
							runat="server"> <INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidPerfiles" size="1" type="hidden" name="hidMsg"
							runat="server">
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
