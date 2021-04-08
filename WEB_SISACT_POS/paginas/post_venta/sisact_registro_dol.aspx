<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_registro_dol.aspx.vb" Inherits="sisact_registro_dol" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Registro DOL</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../librerias/validaciones.js"></script>
		<script language="javascript" type="text/javascript">
			function f_ValidarEnter(event)
			{	
				validarNumero(event)
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						f_Buscar();	
						event.keyCode = 0;
					}
				}
			}
			function validarNumero(event) {
				if (event.keyCode == 8 || event.keyCode == 46) {
					return;
				}
				if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
					return;
				}
				eventoSoloNumeros(event);
			}
			function eventoSoloNumeros(event) {
				if( (event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105) ) {
					event.returnValue = true;
				}
				else {
					event.returnValue = false;
				}
				/*var tecla = String.fromCharCode(event.keyCode)
				alert(isNumber(tecla));
				if( !isNumber(tecla) ) {
					event.returnValue = false;
				}*/
			}
			function f_Buscar()
			{
				var strNroTlf = document.frmPrincipal.txtNroTelefono.value;
				
				if(strNroTlf=='')
				{
					alert("Ingrese el Número Telefónico.")
					document.frmPrincipal.txtNroTelefono.focus();
					return false;
				}
				
				if(strNroTlf.length < 9){
					alert("El Número Telefónico debe tener 9 dígitos.")
					document.frmPrincipal.txtNroTelefono.focus();
					return false;
				}	
						
				document.getElementById("hidNroTelefono").value = document.getElementById("txtNroTelefono").value;
				document.frmPrincipal.action ="sisact_registro_dol.aspx?cu=" + document.getElementById("hidUsuarioExt").value;
				document.frmPrincipal.submit();
			}
			
			function f_Enviar(strNroTlf)
			{
				document.getElementById('iframeDOL').src = "sisact_interaccion_dol.aspx?numTelefono=" + strNroTlf + "&IMSI=" + document.getElementById("hidIMSI").value + "&IN=" + document.getElementById("hidIN").value + "&contactoId=" + document.getElementById("hidContactoId").value;
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
			function f_retornar(){
				document.getElementById('iframeDOL').src = '';	
				document.frmPrincipal.txtNroTelefono.value = '';		
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<form id="frmPrincipal" name="frmPrincipal" method="post" runat="server">
			<div id="divBusqueda" align="left">
				<table cellSpacing="3" cellPadding="0" width="100%"  border="0">
					<tr>
						<td class="header" align="center" colSpan="4" height="20">
							<P align="center">&nbsp;Registro de DOL</P>
						</td>
					</tr>
					<tr>
						<td>
							<table class="contenido" cellSpacing="2" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="Arial12b" width="100">Nro de Teléfono:</td>
									<td class="Arial12b">
									<INPUT id="txtNroTelefono" onkeydown="javascript:f_ValidarEnter(event);" class="clsInputEnableNroSEC" onkeypress="f_ValidaIngreso('0123456789');" style="WIDTH: 150px" tabIndex="1" type="text" maxLength="9" name="txtNroTelefono" runat="server"> 
							
									<INPUT class="Boton" id="btnRegistrarDOL" onmouseover="this.className='BotonResaltado';"	style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:f_Buscar();" onmouseout="this.className='Boton';" type="button" value="Registrar DOL" name="btnRegistrarDOL">
									</td>
								</tr>
							</table>
							&nbsp;
						</td>
					</tr>
				</table>
			</div>
			<iframe id="iframeDOL" name="iframeDOL" frameSpacing="0" frameBorder="0" width="100%" height="80%"></iframe>
			<INPUT id="hidNroTelefono" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidNroTelefono"
				runat="server"> <INPUT id="hidUsuarioExt" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidUsuarioExt"
				runat="server"> <INPUT id="hidIN" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidIN"
				runat="server"> <INPUT id="hidRC" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidRC"
				runat="server"><INPUT id="hidIMSI" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidIMSI"
				runat="server"> <INPUT id="hidContactoId" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidContactoId"
				runat="server"> 
		</form>
	</body>
</HTML>
 
 
 
 
