<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_cargarCampanias.aspx.vb" Inherits="sisact_pop_cargarCampanias" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Campañas - Caso Especial</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta charset="utf-8" http-equiv="Content-Type" content="text/html">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<style type="text/css">
			.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
			A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
			A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
			A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
			A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
		<script language="javascript" type="text/javascript">
		
			function llamarPadre()
			{
				window.opener.refrescarCampanias();
				window.close();
			}

			/*función que cierra la ventana*/
			function f_CerrarVentana()
			{
				window.close();
				return false;
			}
			
			function f_CheckAllOA(chk)
	        {
				var hid = document.getElementById('hidCondicion');                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];
					if(e.type=='checkbox' && e.name.indexOf('chkMarcar') != -1)
					{						
						e.checked= ChkState ;
					}	
				}
				if (ChkState==true)
				{
					hid.value = "TODOS";
				}
				else
				{
					hid.value = "NINGUNO";
				}
				__doPostBack('btnCargarSesion','');
			}
			
		</script>
	</HEAD>
	<body style="PADDING-RIGHT:5px;PADDING-LEFT:5px;PADDING-BOTTOM:5px;MARGIN:0px;PADDING-TOP:5px">
		<form id="frmRiesgos" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" align="center" width="100%" style="BORDER-RIGHT:#95b7f3 1px solid; BORDER-TOP:#95b7f3 1px solid; BORDER-LEFT:#95b7f3 1px solid; BORDER-BOTTOM:#95b7f3 1px solid">
				<tr height="20">
					<td style="FONT-SIZE: 11px" class="TablaTitulos" align="center">
						Campañas&nbsp;- Caso Especial
					</td>
				</tr>
				<tr>
					<td align="center" style="PADDING-RIGHT:5px; PADDING-LEFT:5px; PADDING-BOTTOM:5px; PADDING-TOP:5px">
						<table cellpadding="1" cellspacing="1" class="Arial11BV">
							<tr>
								<td align="center" colSpan="2" style="PADDING-BOTTOM:5px">
									<asp:datagrid id="dgrCampanias" Runat="Server" BorderColor="#95B7F3" AllowPaging="True" PageSize="5"
										CellPadding="1" CellSpacing="1" DataKeyField="IdCampania" AutoGenerateColumns="False">
										<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="30px"></HeaderStyle>
												<HeaderTemplate>
													<asp:CheckBox id="chkTodos" onclick="javascript:f_CheckAllOA(this);" runat="server" Checked="False"></asp:CheckBox>
												</HeaderTemplate>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Checkbox ID="chkMarcar" Runat="Server"></asp:Checkbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="IdCampania"></asp:BoundColumn>
											<asp:BoundColumn DataField="Campania" HeaderText="Campaña">
												<HeaderStyle Width="300px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Exclusiva">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Checkbox ID="chkExclusiva" Runat="Server"></asp:Checkbox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="2">
									<asp:button id="btnAgregar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										CssClass="Boton" Runat="Server" Text="Agregar"></asp:button>
									<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										CssClass="Boton" Runat="Server" Text="Cancelar"></asp:button>
								</td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<asp:Label id="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:button id="btnMarcarServer" style="DISPLAY: none" Runat="Server"></asp:button><asp:textbox id="txtCodigo" style="DISPLAY: none" Runat="Server"></asp:textbox>
			<input id="btnCargarSesion" style="DISPLAY: none" type="button" name="btnCargarSesion"
				runat="server"> <input id="hidCondicion" style="WIDTH: 123px; HEIGHT: 22px" type="hidden" size="15" name="hidCondicion"
				runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
