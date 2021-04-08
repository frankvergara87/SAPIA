<%@ Page Language="vb" AspCompat="true" AutoEventWireup="false" Codebehind="sisact_carga_masiva_whitelist_televentas.aspx.vb" Inherits="sisact_carga_masiva_whitelist_televentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Carga Masiva de Whitelist</title>
		<meta http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="Mon, 06 Jan 1990 00:00:01 GMT">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
			<meta http-equiv="pragma" content="no-cache">
			<script language="javascript">
	function validar()
	{
		var chkBorrarAgregar = document.getElementById('chkBorrarAgregar');
		var chkAgregar = document.getElementById('chkAgregar');
		
		if(chkBorrarAgregar.checked==false && chkAgregar.checked==false)
		{
			alert('Debe marcar el check para cargar.');
			return false;
		}
		
		return true;
	}
	
	function chequear(obj)
	{
		if(obj.id=='chkBorrarAgregar' && obj.checked==true)
		{
			document.getElementById('chkAgregar').checked = false;
		}else if(obj.id=='chkAgregar' && obj.checked==true)
		{
			document.getElementById('chkBorrarAgregar').checked = false;
		}
	}
	</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<form id="frmPrincipal" name="frmPrincipal" method="post" runat="server">
			<input id="txtNombreFile" type="hidden" name="txtNombreFile"> <input id="txtListaSolicitud" type="hidden" name="txtListaSolicitud">
			<table cellSpacing="0" cellPadding="0" width="790" align="center" border="0" name="Contenedor">
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="790" align="center">
							<TBODY>
								<tr>
									<td align="center">
										<table class="Arial10B" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<TBODY>
												<tr>
													<td class="header" vAlign="middle" align="center" width="98%" height="20">Carga de 
														whiteList - Televentas - Migración</td>
												</tr>
												<tr>
													<td class="contenido" width="98%">
														<table cellSpacing="0" cellPadding="0" width="770" border="0">
															<tr>
																<br>
															</tr>
														</table>
														<table height="50" cellSpacing="0" cellPadding="0" align="center" border="0">
															<TBODY>
																<tr class="Arial10b">
																	<td width="104" height="25">Archivo a Cargar:</td>
																	<td align="center" width="260" height="25"><INPUT class="boton" id="FileToUpload" style="WIDTH: 250px; HEIGHT: 19px" type="file" size="62"
																			name="FileToUpload" runat="server">
																	</td>
																</tr>
																<tr class="Arial10b">
																	<td align="center" height="40">
																		<asp:CheckBox ID="chkBorrarAgregar" onclick="chequear(this)" Runat="server" Text="Borrar y Agregar"></asp:CheckBox></td>
																	<td style="PADDING-LEFT:90px">
																		<asp:CheckBox ID="chkAgregar" onclick="chequear(this)" Runat="server" Text="Solo Agregar"></asp:CheckBox></td>
																</tr>
																<tr>
																	<td align="center" width="370" colSpan="2" height="25"><asp:button id="btnCargar" runat="server" Width="100"  CssClass="BotonOptm"
																			Text="Cargar"></asp:button></td>
													</td>
												</tr>
											</TBODY></table>
									</td>
					</td>
				</tr>
				</TD></TR></table>
			</TD></TR></TBODY></TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="Arial12BldB" id="TDCargaArchivo" vAlign="middle" align="center" colSpan="6"
						height="25"></td>
				</tr>
			</table>
			<div id="divResultado">
				<table class="tabla_borde" cellSpacing="0" cellPadding="0" width="790" align="center">
					<tr>
						<td align="center">
							<table class="Arial10B" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<tr>
									<td class="TituloResultado" vAlign="middle" align="center" width="98%" height="30"><asp:label id="lblResultado" runat="server" Width="293px" Font-Size="18pt" Font-Bold="True"
											ForeColor="Black" ReadOnly="True" Height="26px" BorderColor="Transparent" BackColor="White">Consolidado</asp:label></td>
								</tr>
							</table>
							<table cellSpacing="0" cellPadding="0" width="790" align="center" border="0">
								<tr>
									<td align="center" width="100%">
										<P><asp:textbox id="txtConsolidado" runat="server" Width="731px" ForeColor="Black" ReadOnly="True"
												Height="184px" BorderColor="Black" BackColor="#E0E0E0" TextMode="MultiLine"></asp:textbox></P>
										<P>&nbsp;</P>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
 
 
 
 
