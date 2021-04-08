<%@ Page Language="vb" AspCompat="true" AutoEventWireup="false" Codebehind="sisact_carga_masiva_lprecio_pacuerdo.aspx.vb" Inherits="sisact_carga_masiva_lprecio_pacuerdo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Carga Masiva de Lista de Precio - PLazo acuerdo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta http-equiv="Pragma" content="no-cache">
		<meta http-equiv="Expires" content="Mon, 06 Jan 1990 00:00:01 GMT">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<meta http-equiv="pragma" content="no-cache">
		<script language="javascript">
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="frmPrincipal" name="frmPrincipal" method="post" runat="server">
			<input id="txtNombreFile" type="hidden" name="txtNombreFile"> <input id="txtListaSolicitud" type="hidden" name="txtListaSolicitud">
			<table cellSpacing="0" cellPadding="0" width="790" align="center" border="0" name="Contenedor">
				<TBODY>
					<tr>
						<td align="center">
							<table class="Arial10B" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<tbody>
									<tr>
										<td class="header" vAlign="middle" align="center" width="98%" height="20">Carga 
											Lista de precio - Plazo acuerdo</td>
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
													<tr>
														<td align="center" width="370" colSpan="2" height="25"><asp:button id="btnCargar" runat="server" Text="Cargar" CssClass="BotonOptm" Width="100"></asp:button></td>
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
									<tr>
										<td class="header" vAlign="middle" align="center" width="98%" height="20">Estado de 
											carga de Archivo</td>
									</tr>
									<tr>
										<td class="contenido" width="98%">
											<table cellSpacing="0" cellPadding="0" width="770" border="0">
												<tr>
													<br>
												</tr>
											</table>
											<table height="50" cellSpacing="0" cellPadding="0" align="center" border="0">
												<tbody>
													<tr class="Arial10b">
														<td width="300"><asp:datagrid id="dgResultado" runat="server" width="100%" autogeneratecolumns="false" EnableViewState="True">
																<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																<ItemStyle CssClass="Arial11B" BackColor="#E9EBEE"></ItemStyle>
																<Columns>
																	<asp:BoundColumn DataField="RSL_DESCRIPCION" headerText="Descripción">
																		<HeaderStyle Wrap="False" HorizontalAlign="center" Width="35%" CssClass="TablaTitulos"></HeaderStyle>
																		<ItemStyle HorizontalAlign="left" Width="75%" CssClass="Arial11B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="RSL_CANTIDAD" HeaderText="Cantidad">
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="65%" CssClass="TablaTitulos"></HeaderStyle>
																		<ItemStyle HorizontalAlign="right" Width="25%"></ItemStyle>
																	</asp:BoundColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</tbody>
											</table>
											<table align="right">
												<tbody align="center" border="0" cellPadding="0" cellSpacing="0" height="50">
													<tr class="Arial10b">
														<td width="80"><asp:linkbutton id="btDetalle" Runat="server">Detalle Carga</asp:linkbutton></td>
														<td width="60"><asp:linkbutton id="btExportar" Runat="server">Exportar</asp:linkbutton></td>
													</tr>
												</tbody>
											</table>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
 
 
 
 
