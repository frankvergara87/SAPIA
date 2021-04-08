<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_detalle_plan_tarifario.aspx.vb" Inherits="sisact_pop_detalle_plan_tarifario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<HEAD>
		<title>Cargar Detalle a Plan Tarifario</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="ConsumerValidacion.js"></script>
		<script language="javascript" type="text/javascript">
		
			function deshabilitarControles(check,control){
				//debugger;
				if(check.checked==true){
					control.disabled = false;
					control.focus();
				}
				else{
					control.disabled = true;
					control.value = '';
				}
			}
			
			function llamarPadre()
			{
				window.opener.refrescarPdv();
				window.close();
			}
		</script>
		<style type="text/css">.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
	A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td class="header" borderColor="#ffffff" align="center" colSpan="2" height="20">Puntos 
						de Venta - Planes
					</td>
				</tr>
				<tr>
					<td borderColor="#ffffff" colSpan="2"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></td>
				</tr>
				<tr>
					<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"
						align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td colSpan="2"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"
									align="center" colSpan="2">
									<div id="divBusquedaPdv" runat="server">
										<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<tr>
												<TD class="Arial11BV" noWrap>Canal:</TD>
												<TD class="Arial11BV" rowSpan="3"><asp:checkboxlist id="cltCanal" runat="server" CssClass="Arial11BV"></asp:checkboxlist></TD>
												<td class="Arial11BV" noWrap>
													<asp:checkbox id="chkBusqueda2" runat="server"></asp:checkbox>Codigo PDV:
													<asp:textbox id="txtBusquedaCodPdv" runat="server" Enabled="false" CssClass="clsInputEnable"
														Width="80px"></asp:textbox>
												</td>
											</tr>
											<TR>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV">&nbsp;</TD>
											</TR>
											<TR>
												<TD class="Arial11BV" noWrap></TD>
												<TD class="Arial11BV" noWrap>
													<asp:checkbox id="chkBusqueda3" runat="server"></asp:checkbox>Descripción PDV:
													<asp:textbox id="txtDescripcionPdv" runat="server" Enabled="false" CssClass="clsInputEnable"
														Width="184px"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV">&nbsp;</TD>
												<TD class="Arial11BV"></TD>
											</TR>
											<TR>
												<TD class="Arial11BV" style="HEIGHT: 17px" align="center" colSpan="4"><asp:button id="btnBuscarPDV" runat="server" CssClass="Boton" Text="Buscar"></asp:button></TD>
											</TR>
										</table>
									</div>
								</td>
							</tr>
							<TR id="trGrillaPdv" align="center" runat="server">
								<td colSpan="2"><asp:datagrid id="dgPDV" runat="server" Width="100%" DataKeyField="OVENC_CODIGO" CellSpacing="2"
										CellPadding="1" BorderColor="#95B7F3" AllowPaging="True" AutoGenerateColumns="False">
										<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Width="12px" CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderTemplate>
													<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True"></asp:CheckBox>
												</HeaderTemplate>
												<ItemStyle HorizontalAlign="Center" Width="12px"></ItemStyle>
												<ItemTemplate>
													<asp:CheckBox id="fila" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="OVENC_CODIGO" HeaderText="Codigo"></asp:BoundColumn>
											<asp:BoundColumn DataField="OVENV_DESCRIPCION" HeaderText="Descripcion"></asp:BoundColumn>
											<asp:BoundColumn DataField="CANAC_CODIGO" HeaderText="Canal"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</TR>
							<tr align="center">
								<td colSpan="2" height="30">
									<asp:button id="btnAgregarPdv" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Agregar"></asp:button>&nbsp;&nbsp; <input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" onclick="window.close();"
										onmouseout="this.className='Boton';" type="button" value="Cancelar">
								</td>
							</tr>
						</table>
						<asp:label id="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtAccionGrabarPDV" runat="server"></asp:textbox></div>
		</form>
		<script language="javascript" type="text/javascript">

		</script>
	</body>
</html>
 
 
 
 
