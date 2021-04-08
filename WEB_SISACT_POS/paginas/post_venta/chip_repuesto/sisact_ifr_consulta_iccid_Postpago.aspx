<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_iccid_Postpago.aspx.vb" Inherits="sisact_ifr_consulta_iccid_Postpago"%>
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
						window.parent.responseConsultarIccid(getValue('hidDatosRetorno'));
					}
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
			<INPUT id="hidUsoHLR" style="Z-INDEX: 101; LEFT: 152px; WIDTH: 16px; POSITION: absolute; TOP: 16px; HEIGHT: 22px"
				type="hidden" size="1" name="hidUsoHLR" runat="server"> <input id="hidCodIccid" type="hidden" name="hidCodIccid" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidDatosRetorno" type="hidden" name="hidDatosRetorno" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidNroLinea" type="hidden" name="hidNroLinea" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidHlr" type="hidden" name="hidNroLinea" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidOficina" type="hidden" name="hidOficina" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1">
		</form>
	</body>
</HTML>
 
 
 
 
