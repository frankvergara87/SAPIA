<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_consulta3g.aspx.vb" Inherits="sisact_pop_consulta3g" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Consulta Líneas 3G</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<script language="javascript">
		function cerrar()
		{window.close();}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div class="clsGridRow" style="WIDTH:100%; HEIGHT:100%">
				<table style="WIDTH:98%; HEIGHT:98%">
					<tr>
						<td class="Header">Líneas del cliente</td>
					</tr>
					<tr>
						<td class="Arial10B"><%=consMensajeLineas3G%></td>
					</tr>
					<tr>
						<td style="HEIGHT:100px">
							<asp:DataGrid id="dgLineas3g" runat="server" AutoGenerateColumns="False" Width="100%">
								<HeaderStyle Wrap="False" horizontalalign="Center" CssClass="TablaTitulos" />
								<ItemStyle BackColor="#E9EBEE" horizontalalign="Center" CssClass="Arial10" />
								<AlternatingItemStyle BackColor="#DDDEE2" HorizontalAlign="Center" CssClass="Arial10" />
								<Columns>
									<asp:TemplateColumn HeaderText="L&#237;nea">
										<ItemTemplate>
											<asp:Label ID="tplLinea" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Plan">
										<itemtemplate>
											<asp:Label ID="tpplanLinea" runat="server"></asp:Label>
										</itemtemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Estado">
										<ItemTemplate>
											<asp:Label ID="tpestadoLinea" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tipo bloqueo">
										<ItemTemplate>
											<asp:Label ID="tptipoBloqueo" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid></td>
					<tr>
						<td align="right">
							<INPUT class="BotonOptm" id="btnAceptarLineas3G" onclick="cerrar();" type="button" value="Aceptar"
								name="btnAceptarLineas3G">
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
