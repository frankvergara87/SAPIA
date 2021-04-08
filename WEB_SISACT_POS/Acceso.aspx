<%@ Page Language="vb" aspcompat="true" AutoEventWireup="false" Codebehind="Acceso.aspx.vb" Inherits="Acceso"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Prueba</title>
		<script language="javascript">
			top.window.moveTo(0,0);
			if (document.all) {
				top.window.resizeTo(screen.availWidth,screen.availHeight);
			}else if (document.layers||document.getElementById) {
				if (top.window.outerHeight<screen.availHeight||top.window.outerWidth<screen.availWidth){
					top.window.outerHeight = screen.availHeight;
					top.window.outerWidth = screen.availWidth;
				}
			}	
		</script>
		<LINK href="estilos/general.css" type="text/css" rel="styleSheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0">
		<form name="frmPrincipal" method="post" runat="server">
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<table borderColor="#95b7f3" cellSpacing="0" cellPadding="3" width="640" align="center"
				bgColor="#ffffff" border="1">
				<tr vAlign="middle">
					<td vAlign="middle">
						<table cellSpacing="0" cellPadding="0" width="630" bgColor="#ffffff" border="0">
							<tr>
								<td vAlign="middle" align="center" bgColor="#95b7f3" colSpan="3" height="75"><span style="PADDING-LEFT: 20px; FONT-WEIGHT: bold; FONT-SIZE: 24px; PADDING-BOTTOM: 5px; CURSOR: default; COLOR: #ffffff; PADDING-TOP: 12px; FONT-FAMILY: Verdana, Arial, Helvetica">Sistema 
										de Activaciones -&nbsp;SISACT</span>
								</td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="3"><img height="3" width="1" border="0"></td>
							</tr>
							<tr bgColor="#95b7f3">
								<td colSpan="3"><img height="3" width="1" border="0"></td>
							</tr>
							<tr bgColor="#ffffff">
								<td colSpan="3"><img height="3" width="1"></td>
							</tr>
							<tr>
								<td bgColor="#ffffff" colSpan="3">&nbsp;</td>
							</tr>
							<tr vAlign="top">
								<td class="login01" style="WIDTH: 133px" vAlign="top" align="center" width="133"><IMG src="images/principal/hm_tim.gif"><br>
									América Móvil Peru</td>
								<td style="WIDTH: 331px" vAlign="middle" bgColor="#ffffff" height="170">
									<table cellPadding="3" width="100%" align="center">
										<tr>
											<td class="login01" id="lblOficina" align="right" width="30%"><b>Usuario:</b></td>
											<td width="70%">
												<P class="login01"><asp:label id="lblNombreCompleto" runat="server"></asp:label></P>
											</td>
										</tr>
										<tr>
											<td class="login01" align="right"><b>Area:</b></td>
											<td>
												<P class="login01"><asp:label id="lblArea" runat="server"></asp:label></P>
											</td>
										</tr>
										<TR>
											<TD class="login01" align="left" colSpan="2"></TD>
										</TR>
									</table>
								</td>
								<td vAlign="middle" align="center"><IMG src="images/LogoAM.gif"></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><asp:imagebutton id="imgIngresar" runat="server" ImageUrl="images/principal/hm_ingreso.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></form>
	</body>
</HTML>
 
 
 
 
