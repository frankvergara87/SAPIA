<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_busqueda_prepago.aspx.vb" Inherits="sisact_ifr_busqueda_prepago" %>
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
			function limpiar() {
				setValue('txtNumeroTelefono','');
				return !isEnabled('btnPaso2');
			}

			function consultar() {
				var numeroTelefono = getValue('txtNumeroTelefono');

				// Filtro por Numero Telefono
				if ( numeroTelefono == "" ) {
					alert('Error. Debe ingresar un Numero de Telefono.');
					setFocus('txtNumeroTelefono');
					return false;
				}
				if (numeroTelefono.length < 9)
				{
					alert('Error. Número de línea incorrecto / no existe. Digite el número nuevamente.');
					setFocus('txtNumeroTelefono');
					return false;				
				}
				//setEnabled('btnPaso2', true, 'Boton');

				return true;
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
			
			function mostrarMensaje() {
				if (getValue('hidMsg') != '') {
					alert(getValue('hidMsg'));
					setValue('hidMsg','');
				}
			}					
				
		</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" MS_POSITIONING="GridLayout"
		onload="inicio()" onkeydown="cancelBack();">
		<form id="frmBusquedaRenovacion" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trPaso2">
					<td>
						<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="20" colspan="3">&nbsp;Venta Express -
									<asp:Label id="lblTipoVenta" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td style="WIDTH: 650px">
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr id="trNumeroTelefono">
											<td class="Arial10B" style="WIDTH: 150px">
											<asp:Button id="BtnFocus" CssClass="Boton" Runat="server" Text="" Width="1" Height="1" />Nro 
												Telefono</td>
											<td style="WIDTH: 220px">
												<div id="divNumeroTelefono">
													<asp:textbox id="txtNumeroTelefono" onkeypress="f_ValidaIngreso('0123456789');" onkeydown="validarNumero(event);"
														runat="server" MaxLength="9" Width="100px" CssClass="clsInputEnable" disabled></asp:textbox>
												</div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="2"></td>
								<td class="Arial10B" align="right" height="30">
									<asp:Button CssClass="Boton" id="btnPaso2" Runat="server" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" style="CURSOR: hand" Text="Buscar" disabled Width="100"
										Height="19" />
									&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:Button CssClass="Boton" id="btnLimpiar" Runat="server" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" style="CURSOR: hand" Text="Limpiar" disabled Width="100"
										Height="19" />
									&nbsp;&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1">
		</form>
	</body>
</HTML>
 
 
 
 
