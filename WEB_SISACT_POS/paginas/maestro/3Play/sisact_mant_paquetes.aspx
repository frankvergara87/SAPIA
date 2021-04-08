<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_paquetes.aspx.vb" Inherits="sisact_mant_paquetes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_paquete3play</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script src="../../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
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
					
					document.getElementById('txtCodigo').className='clsInputEnable';
					document.getElementById('txtCodigo').readOnly=false;
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
					
					document.getElementById('txtCodigo').className='clsInputDisable';
					document.getElementById('txtCodigo').readOnly=true;
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
				if (confirm('¿Esta seguro de desactivar este registro?'))
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
				if (getValue('txtDescripcion') == '')
				{
					alert('Debe ingresar la descripción');
					return false;
				}
								
				return true;
			}
			
			function f_EventoSoloNumerosEnteros()
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
			
			function f_CheckAllSD(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];                                                                                         
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkSD') != -1)
						e.checked= ChkState ;
				} 
			}
			
			function f_CheckAllMD(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];                                                                                         
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkMD') != -1)
						e.checked= ChkState ;
				} 
			}
						
		</script>
	</HEAD>
	<body onkeydown="cancelarBackSpace();" ms_positioning="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Paquetes 3Play
					</td>
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
														<td><IMG height="2" src="../../../spacer.gif" width="2">
														</td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A>
														</td>
														<td><IMG height="2" src="../../../spacer.gif" width="2">
														</td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A>
														</td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('EDICION');">Modificar</A>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="3">&nbsp;Busqueda de 
															Paquetes
														</td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Producto :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlProducto" Runat="server" Width="144px" CssClass="clsSelectEnable"></asp:dropdownlist>
														</td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Paquete :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" Width="300px" CssClass="clsInputEnable"
																MaxLength="30"></asp:textbox>&nbsp;&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="90" CssClass="Boton" Text="Buscar" Height="19"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="90" CssClass="Boton" Text="Limpiar"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Estado :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlEstadoPlan3Play" CssClass="clsSelectEnable" Width="100px" Runat="server">
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
															</asp:dropdownlist>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trGrilla">
								<td>
									<table cellSpacing="1" cellPadding="0" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" AutoGenerateColumns="False">
													<Columns>
														<asp:BoundColumn HeaderText=" " HeaderStyle-Width="25px" ItemStyle-Width="25px">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos" Height="25"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CÓDIGO">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="60px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DESCRIPCIÓN">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="400px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ESTADO">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="90px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" " HeaderStyle-Width="25px" ItemStyle-Width="25px">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos" Height="25"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 700px">
										<table cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" AutoGenerateColumns="False" ShowHeader="False"
														AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "PAQTV_CODIGO")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="PAQTV_CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PAQTV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="400px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO_PAQUETE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="90px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "PAQTV_CODIGO")%>");'>
																		<img src="../../../images/ico_Eliminar.gif" border="0" alt='Desactivar'></a>
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
											<td class="header" colSpan="3" height="25">Detalle del Plaquete</td>
										</tr>
										<tr style="DISPLAY: none">
											<td class="Arial10B" width="100">&nbsp;Código</td>
											<td class="Arial10B" width="5">:</td>
											<td class="Arial10B" width="500"><asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtCodigo"
													ondrop="return false;" runat="server" Width="60px" CssClass="clsInputDisable" MaxLength="5" ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<TD class="Arial10B" style="WIDTH: 80px; HEIGHT: 15px">&nbsp;Producto :</TD>
											<td class="Arial10B" width="5" style="HEIGHT: 15px">:</td>
											<td style="HEIGHT: 15px">&nbsp;<asp:dropdownlist id="ddlProductoMod"   Runat="server" Width="152px" CssClass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist>
											</td>
										</tr>
										<tr>
											<td class="Arial10B" width="100">&nbsp;Descripción</td>
											<td class="Arial10B" width="5">:</td>
											<td class="Arial10B" width="800"><asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtDescripcion"
													ondrop="return false;" runat="server" Width="320px" CssClass="clsInputEnable" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td class="Arial10B" style="HEIGHT: 42px" width="100">&nbsp;Estado</td>
											<td class="Arial10B" style="HEIGHT: 42px" width="5">:</td>
											<td class="Arial10B" style="HEIGHT: 42px"><asp:dropdownlist id="ddlEstado" runat="server" Width="120px" CssClass="clsSelectEnable" DESIGNTIMEDRAGDROP="3903"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="Arial10B" colSpan="3" height="15"></td>
										</tr>
										<tr>
											<td colSpan="3">
												<table>
													<tr>
														<td class="Arial10B" width="360">&nbsp;Planes Asociados al Paquete</td>
														<td class="Arial10B" width="50">&nbsp;</td>
														<td class="Arial10B" width="360">Lista de Planes Activos</td>
													</tr>
													<tr>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrKitMaterialCabecera" runat="server" AutoGenerateColumns="False">
																			<Columns>
																				<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																					<HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalSD" runat="server" onclick="javascript:f_CheckAllSD(this);"></asp:CheckBox>
																					</HeaderTemplate>
																					<ItemStyle Width="25px"></ItemStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="CÓDIGO">
																					<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="50px"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="PLAN">
																					<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="250px"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="ORDEN" Visible="False">
																					<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="70px"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 360px; HEIGHT: 300px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrKitMaterialDetalle" runat="server" AutoGenerateColumns="False" ShowHeader="False">
																				<AlternatingItemStyle BackColor="#dddee2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkSD" runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="CODIGO_PAQUETE" Visible="false"></asp:BoundColumn>
																					<asp:BoundColumn DataField="CODIGO_PLAN">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="DESCRIPCION_PLAN" ItemStyle-CssClass="Arial10B">
																						<HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn HeaderStyle-Width="140px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
																						Visible="False">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemTemplate>
																							<asp:Label ID="lblOrdenPaquete" runat="server" Width="70px"></asp:Label>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="ORDEN_PAQUETE" Visible="False"></asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
														<td align="center">
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:button id="btnMaterialQuitar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																			onmouseout="this.className='Boton';" runat="server" Width="70" CssClass="Boton" Text=">>"
																			Height="19"></asp:button></td>
																</tr>
																<tr height="5">
																	&nbsp;</tr>
																<tr>
																	<td><asp:button id="btnMaterialAgregar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																			onmouseout="this.className='Boton';" runat="server" Width="70" CssClass="Boton" Text="<<"
																			Height="19"></asp:button></td>
																</tr>
															</table>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrMaterialCabecera" runat="server" AutoGenerateColumns="False" ShowHeader="True">
																			<Columns>
																				<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																					<HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalMD" runat="server" onclick="javascript:f_CheckAllMD(this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="CÓDIGO">
																					<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="50px"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="PLAN">
																					<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="250px"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 360px; HEIGHT: 300px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrMaterialDetalle" runat="server" AutoGenerateColumns="False" ShowHeader="False">
																				<AlternatingItemStyle BackColor="#dddee2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkMD" runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="CODIGO_PLAN" ItemStyle-CssClass="Arial10B">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="DESCRIPCION_PLAN" ItemStyle-CssClass="Arial10B">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr vAlign="middle" height="50">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" runat="server" Width="126" CssClass="Boton" Text="Aceptar" Height="19"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" runat="server" Width="126" CssClass="Boton" Text="Cancelar"
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
			<input id="hidCodigo" type="hidden" name="hidCodigo" runat="server"> <input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server">
			<input id="hidCantidadPlazo" type="hidden" name="hidCantidadPlazo" runat="server">
			<input id="hidOrdenPaquete" type="hidden" name="hidOrdenPaquete" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
