<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_cargarCanal.aspx.vb" Inherits="sisact_pop_cargarCanal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_pop_cargarCanal</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
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
				window.opener.refrescarCanal();
				window.close();
			}
		</script>
		<style type="text/css">.textgrilla { FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #e06704; FONT-SIZE: 12px; FONT-WEIGHT: bold; TEXT-DECORATION: none }
	A:hover { COLOR: #e06704; FONT-SIZE: 12px; TEXT-DECORATION: none }
	A:active { COLOR: #384e7a; FONT-SIZE: 12px; TEXT-DECORATION: none }
	A:visited { COLOR: #384e7a; FONT-SIZE: 12px; TEXT-DECORATION: none }
	A:link { COLOR: #384e7a; FONT-SIZE: 12px; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="80%" align="center">
				<tr>
					<td class="header" height="20" borderColor="#ffffff" colSpan="2" align="center">Canales 
						- Planes
					</td>
				</tr>
				<tr>
					<td borderColor="#ffffff" colSpan="2"><IMG border="0" alt="" src="../../images/spacer.gif" width="2" height="3"></td>
				</tr>
				<tr>
					<td style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px"
						colSpan="2" align="center">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<tr>
								<td colSpan="2"><IMG border="0" alt="" src="../../images/spacer.gif" width="2" height="3"></td>
							</tr>
							<tr>
								<td style="PADDING-BOTTOM: 10px; PADDING-LEFT: 10px; PADDING-RIGHT: 10px; PADDING-TOP: 10px"
									colSpan="2" align="center">
									<div id="divBusquedaPdv" runat="server">
										<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
											<tr>
												<TD class="Arial11BV" noWrap>Canal:</TD>
												<TD class="Arial11BV" rowSpan="3"><asp:checkboxlist id="cltCanal" runat="server" CssClass="Arial11BV"></asp:checkboxlist></TD>
												<td class="Arial11BV" noWrap><asp:checkbox id="chkBusqueda2" runat="server"></asp:checkbox>Codigo 
													PDV:
													<asp:textbox id="txtBusquedaCodPdv"  onPaste="return false" runat="server" CssClass="clsInputEnable" Width="80px" Enabled="false"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV">&nbsp;</TD>
											</TR>
											<TR>
												<TD class="Arial11BV" noWrap></TD>
												<TD class="Arial11BV" noWrap><asp:checkbox id="chkBusqueda3" runat="server"></asp:checkbox>Descripción 
													PDV:
													<asp:textbox id="txtDescripcionPdv"  onPaste="return false" runat="server" CssClass="clsInputEnable" Width="184px" Enabled="false"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV">&nbsp;</TD>
												<TD class="Arial11BV"></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 17px" class="Arial11BV" colSpan="4" align="center"><asp:button id="btnBuscarPDV" runat="server" CssClass="Boton" Text="Buscar"></asp:button></TD>
											</TR>
										</table>
									</div>
								</td>
							</tr>
							<TR id="trGrillaPdv" align="center" runat="server">
								<td colSpan="2"><asp:datagrid style="Z-INDEX: 0" id="dgCanal" runat="server" Width="100%" AutoGenerateColumns="False"
										AllowPaging="True" BorderColor="#95B7F3" CellPadding="1" CellSpacing="2" DataKeyField="CANAC_CODIGO">
										<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Width="12px" CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center" Width="12px"></ItemStyle>
												<HeaderTemplate>
													<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True"></asp:CheckBox>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:CheckBox id="fila" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="CANAC_CODIGO" HeaderText="Codigo"></asp:BoundColumn>
											<asp:BoundColumn DataField="CANAV_DESCRIPCION" HeaderText="Descripcion"></asp:BoundColumn>
											<asp:BoundColumn DataField="TPROC_CODIGO" HeaderText="Canal"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</TR>
							<tr align="center">
								<td height="30" colSpan="2"><asp:button id="btnAgregarPdv" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Agregar"></asp:button>&nbsp;&nbsp; <input id="btnCancelar" class="Boton" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										onclick="window.close();" value="Cancelar" type="button">
								</td>
							</tr>
						</table>
						<asp:label id="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtAccionGrabarPDV" runat="server"></asp:textbox></div>
		</form>
		<script language="javascript" type="text/javascript">

		</script>
	</body>
</HTML>
 
 
 
 
