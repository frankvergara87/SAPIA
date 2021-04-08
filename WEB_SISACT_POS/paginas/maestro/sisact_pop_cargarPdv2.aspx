<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_cargarPdv2.aspx.vb" Inherits="sisact_pop_cargarPdv2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cargar Punto de Ventas a Planes</title>
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
			
			function validaCaracteres() 
			{
				var CaracteresPermitidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_-() ";
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++)
				{
					if (key == valid.substring(i,i+1))
						ok = "yes";
				}
				if (ok == "no")
					window.event.keyCode=0;

				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}
			
			function f_CheckAllOA(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('fila') != -1)
					{						
						e.checked= ChkState ;
					}					
				} 
				if (ChkState==true)
				{
				setValue('hidCondicion',"TODOS");				
				}
				else
				setValue('hidCondicion',"NINGUNO");
				
				__doPostBack('btnCargarSesion','');
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
												<td class="Arial11BV" noWrap><asp:checkbox id="chkBusqueda2" runat="server"></asp:checkbox>Codigo 
													PDV:
													<asp:textbox onkeypress="validaCaracteres();" onpaste="return false" id="txtBusquedaCodPdv" runat="server"
														CssClass="clsInputEnable" Width="80px" Enabled="false"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="Arial11BV"></TD>
												<TD class="Arial11BV">&nbsp;</TD>
											</TR>
											<TR>
												<TD class="Arial11BV" noWrap></TD>
												<TD class="Arial11BV" noWrap><asp:checkbox id="chkBusqueda3" runat="server"></asp:checkbox>Descripción 
													PDV:
													<asp:textbox onkeypress="validaCaracteres();" onpaste="return false" id="txtDescripcionPdv" runat="server"
														CssClass="clsInputEnable" Width="184px" Enabled="false"></asp:textbox></TD>
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
								<td colSpan="2"><asp:datagrid id="dgPDV" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
										BorderColor="#95B7F3" CellPadding="1" CellSpacing="2" DataKeyField="OVENC_CODIGO">
										<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Width="12px" CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderTemplate>
													<asp:CheckBox id="chkTotalGrilla" onclick="javascript:f_CheckAllOA(this);" runat="server"></asp:CheckBox>
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
								<td colSpan="2" height="30"><asp:button id="btnAgregarPdv" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Agregar"></asp:button>&nbsp;&nbsp; <input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" onclick="window.close();"
										onmouseout="this.className='Boton';" type="button" value="Cancelar" name="btnCancelar" runat="server">
								</td>
							</tr>
						</table>
						<asp:label id="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtAccionGrabarPDV" runat="server"></asp:textbox></div>
			<input id="hidCondicion" style="WIDTH: 123px; HEIGHT: 22px" type="hidden" size="15" name="hidCondicion"
				runat="server"> <input id="btnCargarSesion" style="DISPLAY: none" type="button" name="btnCargarSesion"
				runat="server">
		</form>
		<script language="javascript" type="text/javascript">

		</script>
	</body>
</HTML>
 
 
 
 
