<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_vendedor_pp.aspx.vb" Inherits="sisact_mant_vendedor_pp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_vendedor_pp</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
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
		
			function f_EventoSoloAlfanumericos()
			{
				code = window.event.keyCode;
									
				if (code == 32 || code == 44 || code == 46 || code == 47 || code == 60 || code == 61 || code == 62 || code == 64 ||
					(code > 47 && code < 58) ||
					(code > 64 && code < 91) ||
					(code > 96 && code < 123) ||
					code == 209 || code == 241 || code == 43  || code == 45)
					return true
				else
					return false;
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
					
			function f_Buscar()
			{				
				if (getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar un texto válido');
					return false;
				}
				
				if (document.getElementById('<%=dgrGrillaCabecera.ClientId %>') != null)
				{
					document.getElementById('<%=dgrGrillaCabecera.ClientId %>').style.display = '';
					document.getElementById('<%=dgrGrillaDetalle.ClientId %>').style.display = '';
				}
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						document.getElementById('<%=btnBuscar.ClientId%>').click();
						event.keyCode = 0;
					}
				}
			}
		
			function f_Agregar()
			{
				limpiar(true);				
				f_MostrarTab('NUEVO');
			}
			
			function limpiar(esNuevo)
			{
				var ddlPosicion = document.getElementById('<%=ddlPosicion.ClientId %>');
				var ddlSupervisor = document.getElementById('<%=ddlSupervisor.ClientId %>');
				var ddlEstado = document.getElementById('<%=ddlEstado.ClientId %>');
				//var ddlBusqueda = document.getElementById('<%=ddlBusqueda.ClientId %>');
				
				ddlPosicion.selectedIndex = 0;
				//ddlSupervisor.selectedIndex = 0;
				ddlSupervisor.innerHTML = '';
				ddlEstado.selectedIndex = 0;
				setValue('txtCodigo', '');
				setValue('txtNombre', '');
				setValue('txtEmail', '');
				setValue('txtDNI', '');
				setValue('txtTelefono', '');
				
				//ddlBusqueda.selectedIndex = 0;
				//setValue('txtBusDescripcion', '');
				
				if (esNuevo)
					ddlEstado.disabled = true;
				else
					ddlEstado.disabled = false;				
			}
			
			function f_Cancelar()
			{
				f_MostrarTab('BUSQUEDA');				
			}
			
			function f_Modificar(strCodigo)
			{
				limpiar(false);
				f_MostrarTab('EDICION');
				
				var tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var strCodigoActual;
				var strNombre;
				var strEmail;
				var strPosicion;
				var strEstado;
				var strDNI;
				var strTelefono;
				var strSupervisor;
				
				for (var i = 0; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					strCodigoActual = fila.cells[1].innerHTML;
					strNombre = fila.cells[2].innerHTML;
					strEmail = fila.cells[5].innerHTML;
					strPosicion = fila.cells[0].getElementsByTagName("input")[0].value;
					strEstado = fila.cells[0].getElementsByTagName("input")[1].value;
					strDNI = fila.cells[3].innerHTML;
					strTelefono = fila.cells[4].innerHTML;
					strSupervisor = fila.cells[0].getElementsByTagName("input")[2].value;
										
					if (strCodigo == strCodigoActual)
					{
						document.getElementById('<%=ddlPosicion.ClientId %>').value = strPosicion;
						document.getElementById('<%=ddlEstado.ClientId %>').value = strEstado;
						//document.getElementById('<%=ddlSupervisor.ClientId %>').value = strSupervisor;
						setValue('txtNombre', strNombre);
						setValue('txtEmail', strEmail);
						setValue('txtDNI', strDNI);
						setValue('txtTelefono', strTelefono);
						setValue('txtCodigo', strCodigo);
						setValue('hidSupervisor', strSupervisor);
						__doPostBack('btnModificar', '');
					}
				}
			}
			
			function f_Limpiar()
			{
				limpiar(false);
				document.getElementById('<%=dgrGrillaCabecera.ClientId %>').style.display = 'none';
				document.getElementById('<%=dgrGrillaDetalle.ClientId %>').style.display = 'none';
				var ddlBusqueda = document.getElementById('<%=ddlBusqueda.ClientId %>');
				ddlBusqueda.selectedIndex = 0;
				setValue('txtBusDescripcion', '');
			}
			
			function f_Eliminar(strCodigo)
			{
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
					setValue('hidCodigoEli',strCodigo);
					__doPostBack('btnEliminar','');
				}
			}
			
			function f_Aceptar()
			{
				if (getValue('txtNombre').length == 0)
				{
					alert('Debe ingresar el nombre');
					return false;
				}
				if (getValue('txtEmail').length == 0)
				{
					alert('Debe ingresar el email');
					return false;
				}
				
				if (getValue('txtDNI').length == 0)
				{
					alert('Debe ingresar el dni');
					return false;
				}
				if (getValue('txtDNI').length < 8)
				{
					alert('Debe ingresar un dni válido');
					return false;
				}				
				
				if (getValue('txtTelefono').length == 0)
				{
					alert('Debe ingresar el teléfono');
					return false;
				}
				
				if (getValue('txtTelefono').length == 0)
				{
					alert('Debe ingresar el teléfono');
					return false;
				}
				
				if (document.getElementById('<%=ddlPosicion.ClientId %>').selectedIndex == 0)
				{
					alert('Debe seleccionar la posición');
					return false;				
				}
				
				if (document.getElementById('<%=ddlSupervisor.ClientId %>').selectedIndex == 0)
				{
					alert('Debe seleccionar el supervisor');
					return false;				
				}
				
				return true;		
			}			
		
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Vendedores puerta a puerta</td>
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
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:f_Agregar();">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"
															style="DISPLAY:none"><A href="javascript:void();">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Vendedores</td>
													</tr>
													<tr>
														<td><asp:dropdownlist id="ddlBusqueda" tabIndex="0" Runat="server" Width="150px" CssClass="clsSelectEnable">
																<asp:ListItem Value="N" Selected="True">NOMBRES Y APELLIDOS</asp:ListItem>
																<asp:ListItem Value="D">DNI</asp:ListItem>
															</asp:dropdownlist>&nbsp;<asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" Width="320px" CssClass="clsInputEnable"
																MaxLength="100"></asp:textbox>&nbsp;
															<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Buscar"></asp:button>&nbsp;
															<input type="button" id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 90px; CURSOR: hand; HEIGHT: 19px"
																onmouseout="this.className='Boton';" class="Boton" value="Limpiar" onclick="f_Limpiar();"></td>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" autogeneratecolumns="False" showheader="True" Width="910px">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CÓDIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="60px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="NOMBRES Y APELLIDOS">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="300px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="DNI">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TELÉFONO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="E-MAIL">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>

										<table cellSpacing="0" cellPadding="0" width="900" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" showheader="False"
														AllowPaging="True" Width="850px">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "VNPPN_CODIGO")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Servicio'></a>
																	<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "vnppc_posicion")%>" />
																	<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "vnppc_estado")%>" />
																	<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "vnppn_supervisor")%>" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="VNPPN_CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VNPPV_NOMBRE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="295px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VNPPC_DNI">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VNPPV_TELEFONO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="VNPPV_EMAIL">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="198px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "VNPPN_CODIGO")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Vendedor'></a>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
										</table>
									
								</td>
							</tr>
							<tr id="trEdicion" style="DISPLAY:none">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" style="WIDTH: 322px" colSpan="7" height="25">Detalle del 
												Vendedor</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 121px">&nbsp;Código</td>
											<td class="Arial10B" style="WIDTH: 1px">:</td>
											<td class="Arial10B" style="WIDTH: 327px"><asp:textbox id="txtCodigo"
													runat="server" width="60px" ReadOnly="True" cssclass="clsInputDisable" DESIGNTIMEDRAGDROP="1141"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 67px">Estado</td>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B"><asp:dropdownlist id="ddlEstado" runat="server" width="100px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 121px">&nbsp;Nombres y apellidos</td>
											<td class="Arial10B" style="WIDTH: 1px">:</td>
											<td class="Arial10B"><asp:textbox onkeypress="return validaCaracterNombre();" onpaste="return false;" id="txtNombre"
													ondrop="return false;" runat="server" width="320px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1150"
													maxlength="100"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 67px">DNI</td>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtDNI" ondrop="return false;"
													runat="server" MaxLength="8" width="100px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1188"></asp:textbox></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 121px; HEIGHT: 22px">&nbsp;E-mail</td>
											<td class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</td>
											<td class="Arial10B" style="WIDTH: 327px; HEIGHT: 22px"><asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtEmail"
													ondrop="return false;" runat="server" width="320px" cssclass="clsInputEnable" maxlength="100"></asp:textbox></td>
											<td class="Arial10B" style="WIDTH: 67px">Teléfono</td>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtTelefono"
													ondrop="return false;" runat="server" MaxLength="15" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 121px">&nbsp;Posición</td>
											<td class="Arial10B" style="WIDTH: 1px">:</td>
											<td class="Arial10B" style="WIDTH: 327px">
												<asp:dropdownlist id="ddlPosicion" runat="server" width="321px" cssclass="clsSelectEnable" AutoPostBack="True">
													<asp:ListItem Selected="True">--SELECCIONAR--</asp:ListItem>
													<asp:ListItem Value="I">Vendedor de campo claro</asp:ListItem>
													<asp:ListItem Value="E">Vendedor de campo externo</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="Arial10B" style="WIDTH: 67px">Supervisor</td>
											<TD class="Arial10B" style="WIDTH: 2px">:</TD>
											<TD class="Arial10B"><asp:dropdownlist id="ddlSupervisor" runat="server" width="321px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
										</tr>
										<tr height="25">
											<td align="center" colSpan="6">
												<asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Aceptar"
													Height="19"></asp:button>&nbsp; 
												<input type="button" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 90px; CURSOR: hand; HEIGHT: 19px"
													onmouseout="this.className='Boton';" class="Boton" value="Cancelar" onclick="f_Cancelar();">
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidCodigoEli" name="hidCodigoEli" runat="server" />
			<input type="button" id="btnEliminar" name="btnEliminar" runat="server" style="display:none" />
			<input type="hidden" id="hidSupervisor" name="hidSupervisor" runat="server" />
			<input type="button" id="btnModificar" name="btnModificar" runat="server" style="display:none" />
		</form>
	</body>
</HTML>
 
 
 
 
