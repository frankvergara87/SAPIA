<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_camp_kits.aspx.vb" Inherits="sisact_mant_camp_kits" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_materiales</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
			
			function f_InactivarTxtLista()
			{
				txtBusDescripcion = document.getElementById('<%=txtBusDescripcion.ClientId%>');
				txtBusDescripcion.value = '';
			
				if (getValue('ddlBusqueda') == '1')
				{
					txtBusDescripcion.readOnly = true;
					txtBusDescripcion.className = 'clsInputDisable';
				}
				else
				{
					txtBusDescripcion.readOnly = false;
					txtBusDescripcion.className = 'clsInputEnable';
					txtBusDescripcion.focus();
				}
			}
			
			function f_Buscar()
			{					
				if (getValue('ddlBusqueda') == '0' && getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar una Descripción');
					return false;
				}
			}
			
			function f_Limpiar()
			{
				setValue('txtBusDescripcion', '');
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						//f_Buscar();
						document.getElementById('<%=btnBuscar.ClientId%>').click();
						event.keyCode = 0;
					}
				}
			}
			
			function f_MostrarTab(valor)
			{
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trEdicion', false);	
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='none';
				}
				if (valor == 'NUEVO')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
				}
			}
			
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
			}
			
			function f_Modificar(cod)
			{
				setValue('hidCodigo',cod);
				__doPostBack('btnModificar','');
			}
			
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
					
				if (confirm('¿Desea guardar los cambios?'))
					return true;
				else
					return false;
			}
			
			function f_ValidarGrabar()
			{			
				if (getValue('txtPrecio') == '')
				{
					setFocus('txtPrecio');
					alert('Debe ingresar el precio.');					
					return false;
				}else if(getValue('txtInstalacion') == ''){
					setFocus('txtInstalacion');
					alert('Debe ingresar el costo de la instalación.');
					return false;
				}else if(getValue('txtCFAlquilerKit') == ''){
					setFocus('txtCFAlquilerKit');
					alert('Debe ingresar el Cargo Fijo de Alquiler Kit.');
					return false;
				}
								
				return true;
			}
			
			function f_EventoSoloNumerosDecimales()
			{
				var CaracteresPermitidos = '0123456789.';
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++) 
				{
						if (key == valid.substring(i,i+1))
							ok = "yes"        
				}
				if(window.event.keyCode != 16){
					if (ok == "no")
							window.event.keyCode=0
				}
			}			
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Kits por Campaña</td>
				</tr>
				<tr>
					<td class="contenido">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('EDICION');">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Kits por Campaña</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox id="txtBusDescripcion" onkeydown="javascript:f_ValidarEnter();" runat="server" Width="300px"
																CssClass="clsInputEnable" MaxLength="30" onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;"
																ondrop="return false;"></asp:textbox>
															&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19" Text="Buscar"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Limpiar"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trGrilla">
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="490px" autogeneratecolumns="False"
													showheader="True">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CAMPAÑA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="KIT">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="300px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PLAZO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 520px">
										<table cellSpacing="0" cellPadding="0" width="490" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="440px" autogeneratecolumns="False" showheader="False"
														PageSize="30" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "ckitn_correlativo")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar kit por campaña'>
																	</a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="campv_descripcion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="kitv_descripcion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="290px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="plzav_descripcion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "ckitn_correlativo")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Eliminar Kit por campaña'></a>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr id="trEdicion">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">Detalle de Kit por Campaña</td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Campaña</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:dropdownlist id="ddlCampana" runat="server" width="200px" cssclass="clsSelectEnable" DESIGNTIMEDRAGDROP="301"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Kit</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:dropdownlist id="ddlKit" runat="server" width="200px" cssclass="clsSelectEnable" DESIGNTIMEDRAGDROP="302"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Plazo</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:dropdownlist id="ddlPlazo" runat="server" width="200px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Precio lista</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:textbox id="txtPrecio" runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"
													onkeypress="return fSoloMontos(event, this);" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Costo de Instalación</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:textbox id="txtInstalacion" runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"
													onkeypress="return fSoloMontos(event, this);" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">CF Alquiler KIT</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<asp:textbox id="txtCFAlquilerKit" runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"
													onkeypress="return fSoloMontos(event, this);" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="5"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Aceptar"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19"
													Text="Cancelar"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
			<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input id="hidCodigo" type="hidden" runat="server"> <input id="hidCargaInicial" type="hidden" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
