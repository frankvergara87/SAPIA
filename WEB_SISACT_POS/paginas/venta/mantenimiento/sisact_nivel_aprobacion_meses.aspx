<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_nivel_aprobacion_meses.aspx.vb" Inherits="sisact_nivel_aprobacion_meses"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Mantenimiento - Nivel de Aprobación por Meses</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript" type="text/javascript">

				function soloNumeros(e) {
					var key = window.Event ? e.which : e.keyCode
					return (key >= 48 && key <= 57)
				}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 832px" id="tbDatos" border="0" cellSpacing="0" cellPadding="0" width="832"
				align="center">
				<tr>
					<td class="Header" height="20" align="center">Nivel de Aprobacion para el Tiempo 
						Permanencia (Renovaciones Adelantadas)
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
				<tr>
					<td style="HEIGHT: 19px" class="Arial10B" height="19" align="left">
						<p><asp:datagrid style="Z-INDEX: 0" id="dgNivelAprobacion" runat="server" width="832px" autogeneratecolumns="False"
								AllowPaging="True" PageSize="100">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="ESTADO">
										<HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="TablaTitulos"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="12%" CssClass="Arial10B"></ItemStyle>
										<ItemTemplate>
											<asp:Label id="item_lblEstado" runat="server">
												<%# IIf(DataBinder.Eval(Container.DataItem, "ESTADO") = "1", "Activo", "Inactivo")%>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:CheckBox style="Z-INDEX: 0" id="edit_ckbEstado" runat="server" Checked ='<%# iif(DataBinder.Eval(Container.DataItem, "ESTADO" )="1","true","false") %>' />
											<input style="WIDTH: 8px; HEIGHT: 22px" id="edit_hidCodigo" size="1" type="hidden" name="hidAccion" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO" )%>' />
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="CODIGO">
										<HeaderStyle HorizontalAlign="Center" Width="12%" CssClass="TablaTitulos" />
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="12%" CssClass="Arial10B" />
										<ItemTemplate>
											<asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="PERFIL">
										<HeaderStyle HorizontalAlign="Center" Width="68%" CssClass="TablaTitulos" />
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="30%" CssClass="Arial10B" />
										<ItemTemplate>
											<asp:Label id="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CANAL")%>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="LIMITE DE APROBACION MESES">
										<HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="TablaTitulos" />
										<ItemStyle Wrap="False" HorizontalAlign="Center" Width="30%" CssClass="Arial10B" />
										<ItemTemplate>
											<asp:Label style="Z-INDEX: 0" id="item_lblCantidad" runat="server">
												<%# DataBinder.Eval(Container.DataItem, "DIASMINIMO")%>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox style="Z-INDEX: 0" id="edit_txtCantidad" onKeyPress="return soloNumeros(event)" runat="server" Width="80px" value='<%# DataBinder.Eval(Container.DataItem, "DIASMINIMO") %>' MaxLength="5">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Actualizar" CancelText="Cancelar" EditText="Edici&#243;n">
										<HeaderStyle HorizontalAlign="Center" Width="30%" CssClass="TablaTitulos"></HeaderStyle>
									</asp:EditCommandColumn>
								</Columns>
								<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></p>
						<p></p>
					</td>
				</tr>
				<tr>
					<td height="5" align="left"></td>
				</tr>
				<tr>
					<td height="20" align="center">&nbsp;</td>
				</tr>
				<tr>
					<td height="20" align="left"><input style="WIDTH: 8px; HEIGHT: 22px" id="hidAccion" size="1" type="hidden" name="hidAccion"
							runat="server">&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
