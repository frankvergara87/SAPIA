<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_whitelist_asesor.aspx.vb" Inherits="sisact_mant_whitelist_asesor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_asesores_corporativos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
			function f_Buscar()
			{					
				if (getValue('ddlBusqueda') == 'N' && getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar los nombres.');
					return false;
				}
				if (getValue('ddlBusqueda') == 'D' && getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar DNI.');
					return false;
				}				
				return true;
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
						document.getElementById('<%=btnBuscar.ClientId%>').click;
						event.keyCode = 0;
					}
				}
			}
			
			function f_MostrarTab(valor)
			{
				if (valor == 'INICIO')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', false);	
					setVisible('trEdicion', false);	

					document.getElementById('ddlBusqueda').value = 'T';
					f_CambiarBusqueda(true);
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdAgregar').style.display = 'inline';
					document.getElementById('tdAgregar').className = 'tab_inactivo';
					document.getElementById('tdModificar').style.display = 'none';
				}			
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trEdicion', false);	
					
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdAgregar').style.display = 'inline';
					document.getElementById('tdAgregar').className = 'tab_inactivo';
					document.getElementById('tdModificar').style.display = 'none';
				}
				if (valor == 'NUEVO')
				{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);
					setVisible('trEdicion', true);
					setVisible('trEstado', false);
					
					document.getElementById('tdListado').className = 'tab_inactivo';
					document.getElementById('tdAgregar').style.display = 'inline';
					document.getElementById('tdAgregar').className = 'tab_activo';
					document.getElementById('tdModificar').style.display = 'none';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);
					setVisible('trEdicion', true);
					setVisible('trEstado', true);	
					
					document.getElementById('tdListado').className = 'tab_inactivo';
					document.getElementById('tdAgregar').style.display = 'none';
					document.getElementById('tdModificar').style.display = 'inline';
					document.getElementById('tdModificar').className = 'tab_activo';
				}
			}
			
			function f_Inicio()
			{
				if (getValue('hidOficina') == '')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trEdicion', false);	
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdAgregar').style.display = 'none';
					document.getElementById('tdModificar').style.display = 'none';	
					setEnabled('btnBuscar', false, '');
					setEnabled('btnLimpiar', false, '');
					alert('<%= ConfigurationSettings.AppSettings("constMensajeUsuarioPDV") %>');
				} 
				else 
				{
					f_MostrarTab('BUSQUEDA');
					f_CambiarBusqueda(true);
				}
			}
			
			function f_Modificar(cod)
			{
				setValue('hidCodigo', cod);
				__doPostBack('btnModificar', '');
			}
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de inactivar este registro?'))
				{
					setValue('hidCodigo', cod);
					__doPostBack('btnEliminar', '');
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

			function f_CambiarBusqueda(blnLimpiar)
			{
				txtBusDescripcion = document.getElementById('<%=txtBusDescripcion.ClientId%>');
				if (blnLimpiar)
					txtBusDescripcion.value = '';
				if (getValue('ddlBusqueda') == 'T') 
				{
					txtBusDescripcion.readOnly = true;
					txtBusDescripcion.className = 'clsInputDisable';
				}
				else 
				{		
					txtBusDescripcion.readOnly = false;
					txtBusDescripcion.className = 'clsInputEnable';
					txtBusDescripcion.focus();
											
					if (getValue('ddlBusqueda') == 'D') 
					{
						document.getElementById('txtBusDescripcion').onkeypress = function() { validaCaracteres('0123456789') };
						txtBusDescripcion.maxLength = 8;						
					}
					else
					{
						document.getElementById('txtBusDescripcion').onkeypress = function() { validaCaracterNombre() };	
						txtBusDescripcion.maxLength = 30;
					}
				}		
			}

			function f_ValidarGrabar()
			{
				if (!validarControl('txtDNI', '', 'Debe ingresar el dni.')) return false;
				if (!validarControl('txtNombres', '', 'Debe ingresar el nombre.')) return false;
				if (!validarControl('txtPaterno', '', 'Debe ingresar el apellido paterno.')) return false;
				if (!validarControl('txtMaterno', '', 'Debe ingresar el apellido materno.')) return false;
				if (!validarControl('txtTelefono', '', 'Debe ingresar el teléfono.')) return false;
							
				if (getValue('txtDNI').length != 8)
				{
					alert('Debe ingresar un dni válido.');
					return false;
				}
				if (getValue('txtTelefono').length != 9 || getValue('txtTelefono').substring(0, 1) != '9')
				{
					alert('Debe ingresar un teléfono válido.');
					return false;
				}		
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						Whitelist Asesores DACs / CACs</td>
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
															Asesor DAC/CAC</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="T" Selected="True">TODOS</asp:ListItem>
																<asp:ListItem Value="N">NOMBRES</asp:ListItem>
																<asp:ListItem Value="D">DNI</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox id="txtBusDescripcion" runat="server" Width="300px" CssClass="clsInputEnable" MaxLength="30"></asp:textbox>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="650px" autogeneratecolumns="False"
													showheader="True">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="DNI">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="NOMBRES Y APELLIDOS">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TELEFONO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="65px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA ACTUALIZACION">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 700px">
										<table cellSpacing="0" cellPadding="0" width="650" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="650px" autogeneratecolumns="False" showheader="False"
														PageSize="25" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "DNI")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Asesor'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="DNI">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NOMBRES">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NRO_CELULAR">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="65px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FECHA_MOD">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "DNI")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Asesor'></a>
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
									<table cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">&nbsp;Detalle del Asesor DAC/CAC</td>
										</tr>
										<tr id="trEstado">
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 5px"></td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="120px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Nro. de DNI</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return validaCaracteres('0123456789');" onpaste="return false;" id="txtDNI"
													runat="server" MaxLength="8" width="120px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1754"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Nombres</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="validaCaracterNombre();" onpaste="return false;" id="txtNombres" runat="server"
													width="250px" cssclass="clsInputEnable" maxlength="30"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Apellido Paterno</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="validaCaracterNombre();" onpaste="return false;" id="txtPaterno" runat="server"
													width="250px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1425" maxlength="30"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Apellido Materno</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="validaCaracterNombre();" onpaste="return false;" id="txtMaterno" runat="server"
													width="250px" cssclass="clsInputEnable" maxlength="30"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Teléfono</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return validaCaracteres('0123456789');" id="txtTelefono" runat="server"
													MaxLength="9" width="120px" cssclass="clsInputEnable" onpaste="return false;"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
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
			<input id="hidOficina" type="hidden" name="hidOficina" runat="server"> <input id="hidTipoOficina" type="hidden" name="hidTipoOficina" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
