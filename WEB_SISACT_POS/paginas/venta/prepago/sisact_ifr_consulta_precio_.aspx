<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_precio_.aspx.vb" Inherits="sisact_ifr_consulta_precio_" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Sisact Consulta Precio</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
				//alert("inicio - da precio")
				//alert(document.getElementById('hidResponse').value)
				switch (document.getElementById('hidResponse').value) {
					case "ExtraerDatos":
						if (window.parent) {
							setValue('hidConsultaPrecio', window.parent.getValue('hidConsultaPrecio'));
						}
						setValue('hidRequest', 'ConsultarPrecio');
						document.frmPrincipal.submit();
						return;
						break;
					case "RetornarDatos": // Despues de "Buscar Precio", hay que volver a padre
						// Hacer un llamado a la funcion del Padre
						//alert("llama a respuestaConsultarPrecio");
						if (window.parent) {
							window.parent.respuestaConsultarPrecio(document.getElementById('hidRespuestaPrecio').value);
						}
						break;
					case "Error": // Ocurrio Error, hay que volver a padre
						// Hacer un llamado a la funcion del Padre
						if (window.parent) {
							window.parent.respuestaBuscarImei('xxx', document.getElementById('hidResponse').value);
							//window.parent.respuestaConsultarPrecioError();
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
	<body MS_POSITIONING="GridLayout"><!-- onload="javascript:inicio();"-->
		<form id="frmPrincipal" method="post" runat="server">
			<input id="hidConsultaPrecio" type="hidden" name="hidConsultaPrecio" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidRespuestaPrecio" type="hidden" name="hidRespuestaPrecio" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">

			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">

			<input id="hidRequest" type="hidden" name="hidRequest" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
			<input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
		</form>
	</body>
</html>
 
 
 
 
