<%@ Register TagPrefix="uc1" TagName="ctr_Menu" Src="../controles/ctr_Menu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Top.aspx.vb" Inherits="Top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<LINK href="../estilos/general.css" type="text/css" rel="styleSheet">
			<style>BODY { MARGIN: 0px; BACKGROUND-COLOR: white }
	</style>
	</HEAD>
	<body>
		<form id="frmPrincipal" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="1009" border="0" height="104">
				<TR vAlign="top">
					<TD width="67">
						<TABLE cellSpacing="0" cellPadding="0" width="1008" border="0" ms_2d_layout="TRUE" height="88">
							<TR vAlign="top">
								<TD width="1" height="65"></TD>
								<TD width="171">
									<table height="64" cellSpacing="1" cellPadding="0" width="1006" border="0">
										<tr>
											<td class="marco_top" bgColor="#ffffff">
												<table height="40" cellSpacing="0" cellPadding="0" width="999" border="0">
													<tr height="30">
														<td align="center" width="32" rowSpan="2"><IMG src="..\images\logoClaroBlanco.gif"></td>
														<td width="1" height="23">&nbsp;</td>
														<td align="left" width="796" height="23"><span class="styleTop1">SISACT - Sistema de 
                        Activaciones</span></td>
														<td align="right" width="35%" height="23">
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><span class="styleTop2">Usuario: </span><asp:label id="lblUsuario" CssClass="styleTop2" runat="server"></asp:label></td>
																</tr>
																<tr>
																	<td align="right"><span class="styleTop2">Nodo :</span>
																		<asp:label id="lblNodo" CssClass="styleTop2" runat="server"></asp:label></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
 
 
 
 
