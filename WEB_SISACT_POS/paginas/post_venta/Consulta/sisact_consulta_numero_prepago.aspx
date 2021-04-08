<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_consulta_numero_prepago.aspx.vb" Inherits="sisact_consulta_numero_prepago" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_consulta_numero_prepago</title>
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
			// inicio validaciones
			function f_ValidarEnter(event)
			{	
				validarNumero(event);
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						f_Buscar();	
						event.keyCode = 0;
					}
				}
			}
			function f_ValidaIngreso(CaracteresPermitidos)   {
				var key = String.fromCharCode(window.event.keyCode);
				var valid = new String(CaracteresPermitidos);
				var ok = "no";
				for (var i=0; i<valid.length; i++) 
				{
						if (key == valid.substring(i,i+1))
							ok = "yes";   				
														
				}
				if (ok == "no")
						window.event.keyCode=0;
			}
			//fin validaciones		
		
		
			function limpiarDatos() {
				setValue('txtSerie','');
				setValue('txtCodMaterial','');
				setValue('txtDescripcion','');
				setValue('txtLinea','');
			}
			function buscarSerie(){
				setValue('txtSerie', '000000000000000000'.substr(getValue('txtSerie').length) + getValue('txtSerie'));
				if (document.getElementById('txtSerie').value != '') {
					var _serie = document.getElementById('txtSerie').value;
					document.getElementById("ifrConsultaSerie").src = "sisact_ifr_consulta_numero.aspx?codSerie=" + _serie;
					document.getElementById("ifrConsultaSerie").contentWindow.opener = window.opener;
				}
				else {
					alert('Debe ingresar una válida.');
				}
				
			}
			function respuestaConsultaNumero(datos, rspta) {
				
				if (rspta=="Error"){
					limpiarDatos();	
					alert('Ingrese una serie válida.');		
				}
				else{
					var arrayDatos = datos.split('|');
					for (var i=0; i<arrayDatos.length; i++) {
						var opcion = arrayDatos[i].split(';');
						setValue('txtCodMaterial',opcion[0]);
						setValue('txtDescripcion',opcion[1]);
						setValue('txtLinea',opcion[2]);
					}
					if (document.getElementById('txtLinea').value == ''){
						alert('Dicha serie no cuenta con una línea asignada.');
					}
				}
			}
			
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<table class="contenido" cellSpacing="0" cellPadding="0" width="45%" align="center" border="0">
				<tr>
					<td class="header" style="HEIGHT: 15px" align="center" colSpan="3" height="15">Consulta 
						de números</td>
				</tr>
				<tr>
					<td colSpan="3" height="10%">&nbsp;</td>
				</tr>
				<tr>
					<td class="Arial10b" width="30%">&nbsp;&nbsp;Nro. de Serie:
					</td>
					<td width="5%">&nbsp;:&nbsp;</td>
					<td width="40%"><asp:textbox id="txtSerie" runat="server" MaxLength="18" CssClass="clsInputEnable" Width="148px"
							onkeypress="f_ValidaIngreso('0123456789');" onkeydown="javascript:f_ValidarEnter(event);"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td align="right" width="20%">
						<input class="Boton" id="btnConsultar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
							onmouseout="this.className='Boton';" type="button" value="Consultar" name="btnConsultar"
							onclick="javascript:buscarSerie();">&nbsp;&nbsp;
					</td>
					<td width="10%">&nbsp;</td>
					<td align="left" width="20%">
						<input class="Boton" id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
							onmouseout="this.className='Boton';" type="button" value="Limpiar" name="btnLimpiar"
							onclick="javascript:limpiarDatos();">&nbsp;&nbsp;
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="45%" align="center" border="0">
				<tr>
					<td width="35%" height="10%">&nbsp;</td>
				</tr>
			</table>
			<table class="contenido" cellSpacing="0" cellPadding="0" width="45%" align="center" border="0">
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td class="Arial10b" width="30%">&nbsp;&nbsp;Cod. Material
					</td>
					<td width="5%">&nbsp;:&nbsp;</td>
					<td width="40%"><asp:textbox onpaste="return false;" id="txtCodMaterial" runat="server" MaxLength="20" CssClass="clsInputDisable"
							Width="148px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="Arial10b" width="30%">&nbsp;&nbsp;Descripción del Material
					</td>
					<td width="5%">&nbsp;:&nbsp;</td>
					<td width="40%"><asp:textbox onpaste="return false;" id="txtDescripcion" runat="server" MaxLength="20" CssClass="clsInputDisable"
							Width="250px"></asp:textbox></td>
				</tr>
				<tr>
					<td class="Arial10b" width="30%">&nbsp;&nbsp;Nro. de línea
					</td>
					<td width="5%">&nbsp;:&nbsp;</td>
					<td width="40%"><asp:textbox onpaste="return false;" id="txtLinea" runat="server" MaxLength="20" CssClass="clsInputDisable"
							Width="148px"></asp:textbox></td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
			</table>
			<iframe id="ifrConsultaSerie" name="ifrConsultaSerie" width="0" scrolling="no" height="0">
		</form>
	</body>
</HTML>
</IFRAME></FORM> </BODY></HTML>
 
 
 
 
