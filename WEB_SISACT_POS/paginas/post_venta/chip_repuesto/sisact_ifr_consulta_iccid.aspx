<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_iccid.aspx.vb" Inherits="sisact_ifr_consulta_iccid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact Consulta Iccid</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
			
				mostrarMensaje();
				if (getValue('hidResponse') == "RetornarDatos") { 
					// Hacer un llamado a la funcion del Padre
					if (window.parent) {
					    parent.document.getElementById('hidTLE').value = getValue('hidTLE');
						window.parent.responseConsultarIccid(getValue('hidDatosRetorno'));
					}
				}
				if (getValue('hidResponse') == "RetornarDatosCAC") { 
					if (window.parent) {
					    parent.document.getElementById('hidTLE').value = getValue('hidTLE');
						window.parent.responseConsultarIccidCAC(getValue('hidDatosRetorno'));
					}
				}
				
				//PROY 28949 INI
				if (getValue('hidResponse') == "Validar4G") { 
					if (window.parent) {
					window.parent.document.getElementById('txtSerieChip').value = "";						
					}
				}
				//PROY 28949 FIN 	
			}		
			function mostrarMensaje() {
				if (getValue('hidMsg') != '') {
					alert(getValue('hidMsg'));
					setValue('hidMsg','');
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="javascript:inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<input id="hidCodIccid" type="hidden" name="hidCodIccid" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidNroLinea" type="hidden" name="hidNroLinea" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> 
			<!--consolidado 17122014-->
			<input id="hidRespuestaChip" type="hidden" name="hidRespuestaChip" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidEstadoRenov" type="hidden" name="hidEstadoRenov" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidTLE" type="hidden" name="hidTLE" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> 
			<!--consolidado 17122014-->
		</form>
	</body>
</HTML>
