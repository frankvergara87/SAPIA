<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_lista_precios_rp.aspx.vb" Inherits="sisact_ifr_consulta_lista_precios_rp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sisact Consulta Lista de Precios</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
				if (document.getElementById('hidResponse').value == "RetornarDatos") { 
					// Hacer un llamado a la funcion del Padre
					if (window.parent) {
						window.parent.responseConsultarListaPreciosIMEI(document.getElementById('hidDatosRetorno').value);
					}
				}
			}
			function mostrarMensaje() {
				if (document.getElementById('hidMsg').value != '') {
					alert(document.getElementById('hidMsg').value);
					document.getElementById('hidMsg').value = '';
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="javascript:inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<input id="hidParametros" type="hidden" name="hidParametros" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1">
		</form>
	</body>
</HTML>