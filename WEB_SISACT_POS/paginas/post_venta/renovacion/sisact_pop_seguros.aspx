<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_seguros.aspx.vb" Inherits="sisact_pop_seguros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_pop_seguros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" type="text/javascript">
		
					

		function f_Cerrar() { 
						window.close(); 
					}
			
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="Header" align="left" height="18">&nbsp;Detalle de Prima</td>
				</tr>
			</table>
			<table class="contenido" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<tr>
					<td class="Arial10b" align="center">Equipo</td>
					<td class="Arial10b" align="center">Prima</td>
					<td class="Arial10b" align="center">Deducible</td>
				</tr>
				<TR>
					<td align="center"><asp:textbox id="txtEquipo" ReadOnly="True" CssClass="clsInputDisable" Runat="server" Width="100%"></asp:textbox></td>
					<td align="center"><asp:textbox id="txtPrima" ReadOnly="True" CssClass="clsInputDisable" Runat="server" Width="100%"></asp:textbox></td>
					<td align="center"><asp:textbox id="txtDeducible" ReadOnly="True" CssClass="clsInputDisable" Runat="server" Width="100%"></asp:textbox></td>
				</TR>
			</table>
			<table width="100%">
				<tr>
					<td vAlign="bottom" align="center" colSpan="2" height="30"><input class="Boton" id="btnCerrar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
							onclick="javascript:f_Cerrar();" onmouseout="this.className='Boton';" type="button" value="Cerrar" name="btnCerrar">
					</td>
				</tr>
			</table>
		</form>
		</FORM>
	</body>
</HTML>