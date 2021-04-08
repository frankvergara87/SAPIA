<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_imei.aspx.vb" Inherits="sisact_ifr_consulta_imei" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact Consulta Imei</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
				switch (document.getElementById('hidResponse').value) {
					case "ExtraerDatos":
						if (window.parent) {
							setValue('hidCodImei', window.parent.document.getElementById('txtImei').value);
						}
						setValue('hidRequest', 'BuscarImei');
						document.frmPrincipal.submit();
						return;
						break;
					case "RetornarDatos": // Despues de obtener la respuesta hay que volver a padre
						// Hacer un llamado a la funcion del Padre
						//alert("retorna")
						//debugger;
						if (window.parent) {
							//alert(document.getElementById('hidDatosRetorno').value)
							window.parent.respuestaBuscarImei(document.getElementById('hidDatosRetorno').value, document.getElementById('hidResponse').value);
						}
						break;
					case "Error": // Despues de obtener la respuesta hay que volver a padre
						// Hacer un llamado a la funcion del Padre
						//alert("retorna")
						//debugger;
						if (window.parent) {
							//alert(document.getElementById('hidDatosRetorno').value)
							window.parent.respuestaBuscarImei(document.getElementById('hidDatosRetorno').value, document.getElementById('hidResponse').value);
						}
						break;						
				}
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
			<input id="hidCodImei" type="hidden" name="hidCodImei" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidRequest" type="hidden" name="hidRequest" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidCanal" type="hidden" name="hidCanal" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidskuimei" type="hidden" name="hidskuimei" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidOfVentaCod" type="hidden" name="hidOfVentaCod" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidUsoHLR" type="hidden" name="hidUsoHLR" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidHlr" type="hidden" name="hidHlr" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1">
		</form>
	</body>
</HTML>
