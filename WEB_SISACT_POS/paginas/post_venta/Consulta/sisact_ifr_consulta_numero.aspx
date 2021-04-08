<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_numero.aspx.vb" Inherits=".sisact_ifr_consulta_numero"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_consulta_numero</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
				switch (document.getElementById('hidResponse').value) {
					case "ExtraerDatos":
						if (window.parent) {
							setValue('hidCodSerie', window.parent.document.getElementById('txtImei').value);
						}
						setValue('hidRequest', 'BuscarSerie');
						document.frmPrincipal.submit();
						return;
						break;
					case "RetornarDatos": // Despues de obtener la respuesta hay que volver a padre
						if (window.parent) {
							window.parent.respuestaConsultaNumero(document.getElementById('hidDatosRetorno').value, document.getElementById('hidResponse').value);
						}
						break;
					case "Error": // Despues de obtener la respuesta hay que volver a padre
						if (window.parent) {
							window.parent.respuestaConsultaNumero(document.getElementById('hidDatosRetorno').value, document.getElementById('hidResponse').value);
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
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<input id="hidCodSerie" type="hidden" name="hidCodImei" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidRequest" type="hidden" name="hidRequest" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1">
		</form>
	</body>
</HTML>
 
 
 
 
