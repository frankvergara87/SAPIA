<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_nivel_aprobacion_soles.aspx.vb" Inherits="sisact_nivel_aprobacion_soles"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Mantenimiento - Nivel de Aprobación por Soles</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 832px" id="tbDatos" border="0" cellSpacing="0" cellPadding="0" width="832"
				align="center">
				<tr>
					<td class="Header" height="20" align="center">Nivel de Aprobación para 
						el&nbsp;Descuento de Equipos (Renovaciones Adelantadas)
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td style="HEIGHT: 19px" class="Arial10B" height="19" align="left">
						<P><asp:datagrid style="Z-INDEX: 0" id="dgNivelAprobacion" runat="server" PageSize="15" AllowPaging="false"
								autogeneratecolumns="False" width="832px">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ESTADO">
										<HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="TablaTitulos"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="12%" CssClass="Arial10B"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="item_lblEstado" runat="server">
												<%# iif(DataBinder.Eval(Container.DataItem, "NAC_ESTADO" )="1","Activo","Inactivo") %>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox style="Z-INDEX: 0" id="edit_ckbEstado" runat="server" Checked ='<%# iif(DataBinder.Eval(Container.DataItem, "NAC_ESTADO" )="1","true","false") %>'>
											</asp:CheckBox>
											<INPUT style="WIDTH: 8px; HEIGHT: 22px" id="edit_hidCodigo" size="1" type="hidden" name="hidAccion" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "NAN_CODIGO" )%>'>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="PERFIL">
										<HeaderStyle HorizontalAlign="Center" Width="68%" CssClass="TablaTitulos"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="30%" CssClass="Arial10B"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="Label3" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "NAV_PERFIL_DESC" )%>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:Label id="Label4" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "NAV_PERFIL_DESC" )%>
											</asp:Label>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="LIMITE DE APROBACION SOLES">
										<HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="TablaTitulos"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="30%" CssClass="Arial10B"></ItemStyle>
										<ItemTemplate>
											<asp:Label style="Z-INDEX: 0" id="item_lblCantidad" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "NAC_CANTIDAD" )%>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox style="Z-INDEX: 0" id=edit_txtCantidad onkeypress="validarNumero(event);" onkeydown="validarNumero(event);" runat="server" Width="80px" value='<%# DataBinder.Eval(Container.DataItem, "NAC_CANTIDAD") %>'>
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Edici&#243;n">
										<HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="TablaTitulos"></HeaderStyle>
									</asp:EditCommandColumn>
								</Columns>
								<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P></P>
					</td>
				</tr>
				<tr>
					<td height="5" align="left"></td>
				</tr>
				<TR>
					<TD height="20" align="center">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD height="20" align="left"><INPUT style="WIDTH: 8px; HEIGHT: 22px" id="hidAccion" size="1" type="hidden" name="hidAccion"
							runat="server">&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
