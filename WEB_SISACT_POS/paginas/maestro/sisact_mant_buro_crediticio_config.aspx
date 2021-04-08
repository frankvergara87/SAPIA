<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_buro_crediticio_config.aspx.vb" Inherits="sisact_mant_buro_crediticio_config" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_buro_crediticio_config</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
			function f_BloquearBackSpace()
			{
				if ((event.keyCode == 8 || (event.keyCode == 37 && event.altKey) || (event.keyCode == 39 && event.altKey))
					&& (event.srcElement.form == null || (event.srcElement.isTextEdit == false && !event.srcElement.readOnly)))
				{
					event.cancelBubble = true;
					event.returnValue = false;
				}
			}
		</script>
	</HEAD>
	<body onkeydown="f_BloquearBackSpace();">
		<form id="frmPrincipal" method="post" runat="server">
			<table class="contenido" cellSpacing="1" cellPadding="2" width="100%" align="center">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 20px" align="center" colSpan="6">Configuración 
						de Consultas a Buros Crediticios</td>
				</tr>
				<tr>
					<td width="5%"></td>
					<td class="Arial10B" colspan="5" align="left">Documento :&nbsp;
						<asp:dropdownlist id="ddlDocumento" runat="server" AutoPostBack="True" Width="125px" CssClass="Arial11BV">
							<asp:ListItem Value="05">DNI/CE</asp:ListItem>
							<asp:ListItem Value="06">RUC</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td width="5%"></td>
					<td width="20%" align="right">
						<asp:datagrid id="dgDocumento1" runat="server" Width="184px" CssClass="Arial11BV" autogeneratecolumns="False"
							showheader="True" Height="110px" BorderColor="#95B7F3" PageSize="1" CellPadding="0">
							<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Text" HeaderText="POSICION">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="BURO">
									<HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="140px"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList id="ddlTipoBuro" Width="130px" Runat="server" Enabled="False" cssclass="clsSelectEnable"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
					<td width="20%" align="right"><asp:datagrid id="dgDocumento2" Width="184px" CssClass="Arial11BV" Height="110px" BorderColor="#95B7F3"
							PageSize="7" CellPadding="0" AutoGenerateColumns="False" Runat="server">
							<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Text" HeaderText="POSICION">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn headerstyle-width="140px" itemstyle-width="140px" ItemStyle-HorizontalAlign="Center"
									HeaderText="BURO">
									<HeaderStyle horizontalalign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:DropDownList ID="ddlTipoBuro1" Runat="server" Width="130px" cssclass="clsSelectEnable" Enabled="False"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
					<td width="20%" align="right"><asp:datagrid id="dgDocumento3" Width="184px" CssClass="Arial11BV" Height="110px" BorderColor="#95B7F3"
							PageSize="7" CellPadding="0" AutoGenerateColumns="False" Runat="server">
							<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Text" HeaderText="POSICION">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn headerstyle-width="140px" itemstyle-width="140px" ItemStyle-HorizontalAlign="Center"
									HeaderText="BURO">
									<HeaderStyle horizontalalign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:DropDownList ID="ddlTipoBuro2" Runat="server" Width="130px" cssclass="clsSelectEnable" Enabled="False"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
					<td width="20%" align="right"><asp:datagrid id="dgDocumento4" Width="184px" CssClass="Arial11BV" Height="110px" BorderColor="#95B7F3"
							PageSize="7" CellPadding="0" AutoGenerateColumns="False" Runat="server">
							<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Text" HeaderText="POSICION">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn headerstyle-width="140px" itemstyle-width="140px" ItemStyle-HorizontalAlign="Center"
									HeaderText="BURO">
									<HeaderStyle horizontalalign="Center"></HeaderStyle>
									<ItemTemplate>
										<asp:DropDownList ID="ddlTipoBuro3" Runat="server" Width="130px" cssclass="clsSelectEnable" Enabled="False"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</td>
					<td width="5%" align="right"></td>
				</tr>
				<tr>
					<td width="5%" align="center"></td>
					<td width="20%" align="center"><asp:button id="btnEditar1" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Editar"></asp:button>
						<asp:button id="btnCancelar" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19"
							Runat="server" Text="Cancelar" Visible="False"></asp:button>
						<asp:button id="btnGrabar1" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Grabar" Enabled="False"></asp:button>
					</td>
					<td width="20%" align="center"><asp:button id="btnEditar2" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Editar"></asp:button><asp:button id="btnCancelar2" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19"
							Runat="server" Text="Cancelar" Visible="False"></asp:button>
						<asp:button id="btnGrabar2" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Grabar" Enabled="False"></asp:button>
					</td>
					<td width="20%" align="center"><asp:button id="btnEditar3" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Editar"></asp:button><asp:button id="btnCancelar3" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19"
							Runat="server" Text="Cancelar" Visible="False"></asp:button>
						<asp:button id="btnGrabar3" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Grabar" Enabled="False"></asp:button>
					</td>
					<td width="20%" align="center"><asp:button id="btnEditar4" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Editar"></asp:button><asp:button id="btnCancelar4" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19"
							Runat="server" Text="Cancelar" Visible="False"></asp:button>
						<asp:button id="btnGrabar4" style="CURSOR: hand" Width="80px" CssClass="Boton" Height="19" Runat="server"
							Text="Grabar" Enabled="False"></asp:button>
					</td>
					<td width="5%" align="center"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
