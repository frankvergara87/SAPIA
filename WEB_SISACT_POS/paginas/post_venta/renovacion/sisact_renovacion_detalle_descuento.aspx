<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_renovacion_detalle_descuento.aspx.vb" Inherits="sisact_renovacion_detalle_descuento" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle de Descuento</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<style type="text/css">.total { PADDING-LEFT: 215px }
	.scroll { Z-INDEX: 0; BORDER-BOTTOM: 1px; TEXT-ALIGN: center; BORDER-LEFT: 1px; OVERFLOW-X: scroll; OVERFLOW-Y: scroll; WIDTH: 540px; HEIGHT: 150px; BORDER-TOP: 1px; BORDER-RIGHT: 1px }
	.celda {
		padding-right: 6px;
	}
		</style>
		<script language="javascript" type="text/javascript">
			function cerrar() {
				window.close();
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE border="0" cellSpacing="1" cellPadding="1">
				<TR>
					<TD style="TEXT-ALIGN: center; BACKGROUND-COLOR: #5991bb; COLOR: white; FONT-WEIGHT: bold"
						noWrap>Detalle de Descuento</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>
						<DIV class="scroll"><asp:datagrid id="dgDescuentoPromocional" runat="server" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE" HorizontalAlign="Center"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="NORMAL" HeaderText="Normal" DataFormatString="{0:N2}">
										<ItemStyle Width="87px" HorizontalAlign="RIGHT" BackColor="White" Font-Bold="False" CssClass="celda"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROMOCIONAL" HeaderText="Promocional" DataFormatString="{0:N2}">
										<ItemStyle Width="87px" HorizontalAlign="RIGHT" BackColor="White" Font-Bold="False" CssClass="celda"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TOTAL" HeaderText="Total" DataFormatString="{0:N2}">
										<ItemStyle Width="87px" HorizontalAlign="RIGHT" BackColor="White" Font-Bold="False" CssClass="celda"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TIPO_DE_DSCTO" HeaderText="Tipo de Dscto.">
										<ItemStyle Width="140px" HorizontalAlign="Center" BackColor="White" Font-Bold="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FACTOR" HeaderText="Factor">
										<ItemStyle Width="87px" HorizontalAlign="Center" BackColor="White" Font-Bold="False"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></DIV>
					</TD>
				</TR>
				<TR>
					<TD class="total" noWrap><asp:textbox style="TEXT-ALIGN: right" id="txtTotal" Runat="server" CssClass="clsInputDisable Monto"
							ReadOnly="True" Font-Bold="True" ForeColor="#001B8C" Width="90"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap style="HEIGHT:16px; FONT-SIZE:12px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="TEXT-ALIGN: center" noWrap><INPUT style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" id="btnCerrar" class="Boton" onmouseover="this.className='BotonResaltado';"
							onmouseout="this.className='Boton';" onclick="javascript:cerrar();" value="Cerrar" type="button" name="btnConsultar"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
 
 
 
 
