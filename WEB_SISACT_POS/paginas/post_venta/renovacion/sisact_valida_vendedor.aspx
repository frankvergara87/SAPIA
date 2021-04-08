<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_valida_vendedor.aspx.vb" Inherits="sisact_valida_vendedor"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_valida_vendedor</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<base target="_self">
		<script language="javascript">
		window.onbeforeunload = UnLoadPage;
		function UnLoadPage(){
				
			}
		function Buscar() {
				if (DatosValidos()) {
					setValue('hidRequest', 'Buscar');			
					document.getElementById('frmPrincipal').submit();
				}
			}
			
			function DatosValidos(){
							
				var numeroDoc = getValue('txtNumeroDocId');
				var claveAcceso = getValue('txtClaveAcceso');
				
				if (numeroDoc == "") {
					alert('Debe ingresar un número de documento.');
					setFocus('txtNumeroDocId');
					return false;
				}
				if (numeroDoc.length != "8") {
					alert('El número de documento debe contener 8 caracteres.');
					setFocus('txtNumeroDocId');
					return false;
				}
				if (claveAcceso == "" ) {
					alert('Debe ingresar la clave de acceso.');
					setFocus('txtClaveAcceso');
					return false;
				}
				if (claveAcceso.length != "2") {
					alert('La clave de acceso debe contener 2 caracteres.');
					setFocus('txtClaveAcceso');
					return false;
				}
				setValue('hidClave',getValue('txtClaveAcceso'));	
				
				return true;
			}
			
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
			
			function Alfanumericos() {
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				var salida = false;
				var key = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey) {
					return false;
				}
				
				var CaracteresPermitidos = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
				var valid = new String(CaracteresPermitidos);
				for (var i = 0; i < valid.length; i++) {
					if (key == valid.substring(i, i + 1))
						salida = true;
				}
				if (!salida) {
					salida = isChar(character);
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
			function f_accept_validate(vpage)
			{	
			
				var sData = dialogArguments;
       			sData.LoadPageValidate(vpage);
				window.close();		
			}
			
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<!-- Inicio E77568 -->
			<!-- PROY-7665 Pantalla Emergente De Validación Aplicativos Venta -->
			<TABLE class="Arial11BV" style="Z-INDEX: 101; LEFT: 2px; WIDTH: 376px; POSITION: absolute; TOP: 2px; HEIGHT: 169px"
				borderColor="#336699" cellSpacing="0" cellPadding="0" width="376" border="2" id="tblContenedor">
				<TR>
					<td>
						<TABLE class="Arial11BV" borderColor="#336699" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TBODY>
								<tr>
									<TD vAlign="top" align="center" bgColor="#5991bb" colSpan="3">
										<ASP:LABEL id="lblTitulo" runat="server" font-size="12pt" font-bold="True" forecolor="White">Autenticación de Usuario</ASP:LABEL></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 10px" colSpan="3"></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 150px; HEIGHT: 20px" align="right">DNI Usuario</TD>
									<TD style="PADDING-LEFT: 3px; WIDTH: 10px" align="left">:</TD>
									<TD align="left"><asp:textbox id="txtNumeroDocId" runat="server" CssClass="clsTxtFlat" Width="114px" MaxLength="8"
											ondrop="return false;" onpaste="return false;" onkeypress="return SoloEnteros(event, this);"></asp:textbox></TD>
								</TR>
								<TR align="center">
									<TD style="WIDTH: 150px; HEIGHT: 20px" align="right">Clave Acceso</TD>
									<TD style="PADDING-LEFT: 3px; WIDTH: 10px" align="left">:</TD>
									<TD align="left"><asp:textbox id="txtClaveAcceso" runat="server" CssClass="clsTxtFlat" TextMode="password"
											ondrop="return false;" onpaste="return false;" maxlength="2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 10px" colSpan="3"></TD>
								</TR>
								<TR>
									<td colSpan="3">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<TD align="center"><INPUT class="Boton" id="Aceptar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
														onclick="javascript:Buscar();" onmouseout="this.className='Boton';" type="button" value="Aceptar" name="btnAceptar"></TD>
												<TD style="WIDTH: 10px"></TD>
											</tr>
										</table>
									</td>
								</TR>
								<tr>
									<td style="HEIGHT: 10px" colSpan="3" align="center">
										<asp:label id="lblMensajeError" runat="server" ForeColor="#C00000"></asp:label>
									</td>
								</tr>
							</TBODY>
						</TABLE>
					</td>
				</TR>
			</TABLE>
			<INPUT id="hidRequest" type="hidden" name="hidRequest" runat="server"> <INPUT type="hidden" runat="server" id="hidClave" name="hidClave">
			<INPUT type="hidden" runat="server" id="hidPaginaOrigen" name="hidPaginaOrigen">
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
