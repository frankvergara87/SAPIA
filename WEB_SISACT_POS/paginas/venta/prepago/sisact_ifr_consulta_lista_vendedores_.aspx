<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_lista_vendedores_.aspx.vb" Inherits="sisact_ifr_consulta_lista_vendedores_" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Sisact Consulta Lista de Vendedores</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				//alert(getValue('hidResponse'))
				switch (getValue('hidResponse')) {
					case "ExtraerDatos":
						if (window.parent) {
							setValue('hidParametros', window.parent.document.getElementById('hidParamsListaVendedores').value);
						}
						setValue('hidRequest', 'ConsultarListaVendedores');
						document.frmPrincipal.submit();
						return;
						break;
					case "RetornarDatos": // Despues de obtener la respuesta hay que volver a padre
						// Hacer un llamado a la funcion del Padre
						if (window.parent) {
							window.parent.respuestaConsultarListaVendedores(getValue('hidDatosRetorno'));
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
	</head>
	<body MS_POSITIONING="GridLayout" onload="javascript:inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<input id="hidParametros" type="hidden" name="hidParametros" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidRequest" type="hidden" name="hidRequest" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
		</form>
	</body>
</html>
 
 
 
 
