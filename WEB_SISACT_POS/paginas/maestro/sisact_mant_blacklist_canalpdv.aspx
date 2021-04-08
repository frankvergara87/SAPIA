<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_blacklist_canalpdv.aspx.vb" Inherits="sisact_mant_blacklist_canalpdv" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Mantenimiento Black List Canal PDV</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="JavaScript" src="../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script src="../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" src="../../librerias/funciones_generales.js"></script>
		<script language="javascript" type="text/javascript">

			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de eliminar este registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminar','');
				}
			}
			
			function f_ConfirmarGrabar()
			{	
				if (!f_ValidarGrabar())
					return false;
				else
					return true;
				
			}
			
			function f_ValidarGrabar()
			{		
				var codCanal = getValue('ddlCanal');
				var codPdv = getValue('ddlPuntoVenta');
				//alert("codCanal: " + codCanal)
				//alert("codPdv: " + codPdv)
				if (codCanal=='00' && codPdv==''){
					alert("Debe seleccionar un Canal y Punto de Venta")
					return false;
				}
				
				if (codCanal=='00'){
					alert("Debe seleccionar un Canal")
					return false;
				}				
				
				if (codCanal!='00' && codPdv==''){
					alert("Debe seleccionar un Punto de Venta")
					return false;
				}				

				//alert(codCanal)
				//alert(codPdv)
				return true;
			}
			
			function cargarListaPuntosVenta() {
				// Resetear las opciones ya agregadas en el DDL
				// Poner uno a uno los Puntos de Venta asociados al Canal actual
				var selObjP = document.getElementById('ddlPuntoVenta');
				selObjP.length = 0;

				var canal = getValue('ddlCanal');
				var puntosVenta = getValue('hidPuntosVentas').split('|');
				//debugger;
				for (var i=0; i<puntosVenta.length; i++) {
					var items = puntosVenta[i].split(';');
					if (items[2] == canal || items[2] == '00') {
						addOption(selObjP, items[0], items[1]);
					}
				}
				
				// JAZ - Todos
				//addOption(selObjP, 'XX', '-- TODOS --');
				//
				setFocus('ddlPuntoVenta');
				setValue('hidPuntoVenta',"");
			}			
			
			function cargarPdvSeleccionado() {
				//debugger;
				var objDdl = document.getElementById('ddlPuntoVenta');
				var idx = objDdl.selectedIndex
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hidPuntoVenta', valorTmp + ";" + textoTmp);
			}			
			
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Black List - Canales y PDV</td>
				</tr>
				<tr>
					<td class="contenido" align="center">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr id="trBusqueda">
											<td class="Arial10B" style="HEIGHT: 26px" width="100"><nobr> Canal :
													<asp:dropdownlist id="ddlCanal" runat="server" onchange="cargarListaPuntosVenta();" Width="150px"
														CssClass="clsSelectEnable"></asp:dropdownlist></nobr>
											</td>
											<td class="Arial10B" style="HEIGHT: 26px" width="400" nowrap><nobr> Punto de Venta :
													<asp:dropdownlist id="ddlPuntoVenta" runat="server" onchange="cargarPdvSeleccionado();" Width="250px"
														CssClass="clsSelectEnable"></asp:dropdownlist></nobr>
											</td>
											<td class="Arial10B" style="HEIGHT: 26px" width="100"><nobr>
													<asp:button id="btnAgregar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Agregar"
														Height="19"></asp:button></nobr>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 5px">&nbsp;</td>
							</tr>
							<tr id="trGrilla">
								<td align="center">
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="450px" autogeneratecolumns="False"
													showheader="True">
													<columns>
														<asp:templatecolumn headertext="ITEM">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="10%"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CANAL">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="30%"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PUNTO DE VENTA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50%"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="10%"></headerstyle>
														</asp:templatecolumn>																								
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<asp:datagrid id="dgrGrillaDetalle" runat="server" width="450px" autogeneratecolumns="False" showheader="False"
										AllowPaging="True" PageSize="15">
										<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
										<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ORDEN" HeaderText="ITEM">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="0%" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DES_CANAL" HeaderText="CANAL">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="30%" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DES_PDV" HeaderText="PUNTO DE VENTA">
												<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50%" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10%" CssClass="TablaTitulos"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "ID")%>");'>
														<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Equipo'></a>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidCodigo" type="hidden" runat="server" NAME="hidCodigo">
			<input id="hidPuntosVentas" type="hidden" name="hidPuntosVentas" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="hidPuntoVenta" type="hidden" name="hidPuntoVenta" runat="server" style="WIDTH: 16px; HEIGHT: 22px"
				size="1"> <input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
