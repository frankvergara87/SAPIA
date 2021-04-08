<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_TipoProducto_Msjs.aspx.vb" Inherits="sisact_mant_TipoProducto_Msjs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_TipoProducto_Msjs</title>
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
					
					setEnabled('ddlTipo', true, 'clsSelectEnable');
					setEnabled('ddlTipoCli', true, 'clsSelectEnable');
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
					
					setEnabled('ddlTipo', false, 'clsSelectDisable');
					setEnabled('ddlTipoCli', false, 'clsSelectDisable');
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
			
			function f_Modificar(codServ,codCli)
			{
				setValue('hidServCodigo',codServ);
				setValue('hidTipoClienteCod', codCli);
				__doPostBack('btnModificar','');
			}
			
			function f_Eliminar(codServ,codCli)
			{
				if (confirm('¿Esta seguro de borrar este registro?'))
				{
					setValue('hidServCodigo',codServ);
					setValue('hidTipoClienteCod', codCli);
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
				if (getValue('txtCodCorreo') == '')
				{
					alert('Debe ingresar el código de mensaje de correo');
					return false;
				}
				
				if (getValue('txtCodApp') == '')
				{
					alert('Debe ingresar código de mensaje de APP.');
					return false;
				}
				return true;
			}
			
			function f_EventoSoloNumeros()
			{
				var CaracteresPermitidos = '0123456789';
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
						de Tipo de productos - Mensajes</td>
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
															Configuración</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" CssClass="clsSelectEnable" Width="100px" Runat="server">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" CssClass="clsInputEnable"
																Width="300px" MaxLength="50"></asp:textbox>
															&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Buscar"
																Height="19"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Limpiar"
																Height="19"></asp:button></td>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" autogeneratecolumns="False" width="770px">
													<Columns>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn Visible="False" HeaderText="C&#211;DIGO">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="TIPO CLIENTE">
															<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="PRODUCTO">
															<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO MS CORREO">
															<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO MS APP">
															<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 800px">
										<table cellSpacing="0" cellPadding="0" width="770" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" showheader="False" autogeneratecolumns="False"
														width="770px">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>","<%# DataBinder.Eval(Container.DataItem, "CODCLI")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Servicio'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="CODCLI">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TIPOCLIENTE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="120px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="120px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODIGO_MS_CORREO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="120px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CODIGO_MS_APP">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>","<%# DataBinder.Eval(Container.DataItem, "CODCLI")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Servicio'></a>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
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
											<td class="header" colSpan="5" height="25">Detalle de la Configuración</td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 70px">Tipo Cliente</TD>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlTipoCli" runat="server" width="128px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 70px">Producto</TD>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlTipo" runat="server" width="128px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 70px">cód Correo</TD>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtCodCorreo"
													ondrop="return false;" runat="server" MaxLength="2" width="48px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 70px">Cód APP</TD>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtCodApp"
													ondrop="return false;" runat="server" width="48px" cssclass="clsInputEnable" maxlength="2"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
									</table>
									<table align="center">
										<tr height="25">
											<td align="center" colSpan="4"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Aceptar" Height="19"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Cancelar"
													Height="19"></asp:button></td>
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
			<input id="hidServCodigo" type="hidden" runat="server"> <input id="hidTipoClienteCod" type="hidden" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
