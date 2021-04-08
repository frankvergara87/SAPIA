<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_config_planes.aspx.vb" Inherits="sisact_mant_con_pla" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_con_pla</title>
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
			
			function f_Modificar(codPlan)
			{
				setValue('hidPlanCodigo',codPlan);
				__doPostBack('btnModificar','');
			}
			
			function f_Eliminar(codPlan)
			{
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
					setValue('hidPlanCodigo',codPlan);
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
					return false
				}
				if (getValue('txtCargoFijoA') == '')
				{
					alert('Debe ingresar el cargo fijo');
					return false;
				}
				else
				{
					if (Number(document.getElementById('<%=txtCargoFijoA.ClientId%>').value) == 0)
					{
						alert('El cargo fijo debe ser mayor a 0');
						return false;
					}
				}				
				
				return true;
			}
			
			function mostrarServicio()
			{
				var trServicio = document.getElementById('trServicio');
				
				if (trServicio.style.display == 'none')
					trServicio.style.display = '';
				else
					trServicio.style.display = 'none';
			}
			
			function mostrarKit()
			{
				var trKit = document.getElementById('trKit');
				
				if (trKit.style.display == 'none')
					trKit.style.display = '';
				else
					trKit.style.display = 'none';				
			}
			
			function agregarKit()
			{
				var tablaKD = document.getElementById('dgrKDDetalle');
				var tablaKA = document.getElementById('dgrKADetalle');
				var hidKit = document.getElementById('hidKit');
				var fila;
				var totalLineas = tablaKD.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaKD.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Asociados
						filaNueva = tablaKA.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						//Inserto valores en fila nueva de Asociados
						chk.innerHTML = "<input type='checkbox' id='chkKA' name='chkKA'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						codigo.style.width = '50px';
						descripcion.style.width = '250px';
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						
						hidKit.value += '|' + fila.cells[1].innerHTML + ';' + fila.cells[2].innerHTML + ';' + fila.cells[3].innerHTML + ';' + fila.cells[4].innerHTML;
						
						//Elimino fila de Disponibles
						tablaKD.deleteRow(i);
						i--;
						totalLineas--;
					}
				} 
				//Quitar check en cabecera de Disponibles
				document.getElementById('dgrKDCabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;			
			}
			
			function quitarKit()
			{
				var tablaKD = document.getElementById('dgrKDDetalle');
				var tablaKA = document.getElementById('dgrKADetalle');
				var hidKit = document.getElementById('hidKit');
				var strKit = hidKit.value;
				var arrKits = strKit.split('|');
				var arrKit;
				var fila;
				var totalLineas = tablaKA.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;

				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaKA.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Disponibles
						filaNueva = tablaKD.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						tipo = filaNueva.insertCell(3);
						tipoOperacion = filaNueva.insertCell(4);
						//Inserto valores en fila nueva de Disponibles
						chk.innerHTML = "<input type='checkbox' id='chkKD' name='chkKD'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						
						for (var x = 1; x < arrKits.length; x++)
						{
							arrKit = arrKits[x].split(';');
							
							if (codigo.innerHTML == arrKit[0])
							{
								tipo.innerHTML = arrKit[2];
								tipoOperacion.innerHTML = arrKit[3];								
							}
						}
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						tipo.className = 'Arial10B';
						tipoOperacion.className = 'Arial10B';		
										
						codigo.style.width = '50px';
						descripcion.style.width = '250px';
						tipo.style.width = '50px';
						tipoOperacion.style.width = '250px';
						
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						tipo.style.textAlign = 'center';
						tipoOperacion.style.textAlign = 'center';
						
						hidKit.value = hidKit.value.replace('|' + codigo.innerHTML + ';' + descripcion.innerHTML + ';' + tipo.innerHTML + ';' + tipoOperacion.innerHTML, '');
						
						//Elimino fila de Disponibles
						tablaKA.deleteRow(i);
						i--;
						totalLineas--;
					}
				}
				//Quitar check en cabecera de Asociados
				document.getElementById('dgrKACabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function f_CheckAll(prefijo, chk)
	        {  
				var ChkState = chk.checked;
				var strTabla = 'dgr' + prefijo + 'Detalle';
				var tabla = document.getElementById(strTabla);
				var fila;
				var totalLineas = tabla.rows.length - 1;
				var chk;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tabla.rows[i];
					fila.cells[0].getElementsByTagName("input")[0].checked = ChkState;
				}
			}	
						
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Planes</td>
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
															Plan</td>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" showheader="True" autogeneratecolumns="False"
													width="770px">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CÓDIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PLAN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="300px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PRODUCTO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="140px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TIPO VENTA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="140px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 800px">
										<table cellSpacing="0" cellPadding="0" width="770" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" showheader="False" autogeneratecolumns="False"
														width="770px" AllowPaging="True" PageSize="30">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "plnv_codigo")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar configuracion de planes'>
																	</a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="plnv_codigo" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="plnv_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="290px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="tprov_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="140px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="tvenv_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="140px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="Estado" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
															</asp:boundcolumn>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "plnv_codigo")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar configuracion de planes'></a>
																</itemtemplate>
															</asp:templatecolumn>
														</columns>
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
											<td class="header" colSpan="5" height="25">Detalle del Plan</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Descripción</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtDescripcion"
													ondrop="return false;" runat="server" width="320px" cssclass="clsInputEnable" maxlength="50"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Estado</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="110px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Tipo de Producto</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlTipoProducto" runat="server" width="110px" cssclass="clsSelectEnable"></asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Cargo Fijo</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return fSoloMontos(event, this);" onpaste="return false;" id="txtCargoFijoA"
													ondrop="return false;" runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Plazo Acuerdo</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 100%"><asp:checkboxlist id="cblPlazoAcuerdo" CssClass="Arial10b" Runat="server" CellPadding="0" CellSpacing="0"></asp:checkboxlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px"></TD>
											<TD class="Arial10B" style="WIDTH: 5px"></TD>
											<TD class="Arial10B" style="WIDTH: 100%" align="right" colSpan="3"><INPUT class="Boton" id="btnSeleccionarKit" onmouseover="this.className='BotonResaltado';"
													style="WIDTH: 150px; CURSOR: hand" onclick="mostrarKit();" onmouseout="this.className='Boton';" type="button" size="20" value="Seleccionar Kit" name="btnSeleccionarKit"
													Width="126" Height="19"></TD>
										</TR>
										<tr id="trKit" style="DISPLAY: none">
											<td class="Arial10B" colSpan="5">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 25px" align="left" colSpan="3">&nbsp;Kits</td>
													</tr>
													<tr>
														<td class="Arial10B">Kits asociados
														</td>
														<td></td>
														<td class="Arial10B">Kits disponibles
														</td>
													</tr>
													<tr>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td>
																		<asp:datagrid id="dgrKACabecera" runat="server" showheader="True" autogeneratecolumns="False">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalKA" Runat="server" onclick="javascript:f_CheckAll('KA',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid>
																	</td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 355px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td>
																			<asp:datagrid id="dgrKADetalle" runat="server" showheader="False" autogeneratecolumns="False">
																				<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
																				<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
																				<columns>
																					<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																						<itemstyle horizontalalign="Center"></itemstyle>
																						<itemtemplate>
																							<asp:CheckBox ID="chkKA" Runat="server"></asp:CheckBox>
																						</itemtemplate>
																					</asp:templatecolumn>
																					<asp:boundcolumn datafield="kitv_codigo" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="kitv_descripcion" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="tkitdescrip" Visible="False">
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="toperdescrip" Visible="False">
																					</asp:boundcolumn>																					
																				</columns>
																			</asp:datagrid>
																		</td>
																	</tr>
																</table>
															</div>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><input class="Boton" id="hbtQuitarKit" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px"
																			onclick="quitarKit();" onmouseout="this.className='Boton';" type="button" value=">>"
																			name="hbtQuitarKit">
																	</td>
																</tr>
																<tr>
																	<td height="10"></td>
																</tr>
																<tr>
																	<td><input class="Boton" id="hbtAsociarKit" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="agregarKit();" onmouseout="this.className='Boton';"
																			type="button" value="<<" name="hbtAsociarKit">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrKDCabecera" runat="server" showheader="True" autogeneratecolumns="False">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalKD" Runat="server" onclick="javascript:f_CheckAll('KD',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="TIPO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="TIPO OPERACIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 660px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrKDDetalle" runat="server" showheader="False" autogeneratecolumns="False">
																				<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
																				<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
																				<columns>
																					<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																						<itemstyle horizontalalign="Center"></itemstyle>
																						<itemtemplate>
																							<asp:CheckBox ID="chkKD" Runat="server"></asp:CheckBox>
																						</itemtemplate>
																					</asp:templatecolumn>
																					<asp:boundcolumn datafield="kitv_codigo" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="kitv_descripcion" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="tkitdescrip" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="toperdescrip" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
																					</asp:boundcolumn>
																				</columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<TR>
											<TD colspan="5" style="height:19"></TD>
										</TR>										
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px"></TD>
											<TD class="Arial10B" style="WIDTH: 5px"></TD>
											<TD class="Arial10B" style="WIDTH: 100%" align="right" colSpan="3"><INPUT class="Boton" id="btnSeleccionarServicio" onmouseover="this.className='BotonResaltado';"
													style="WIDTH: 150px; CURSOR: hand" onclick="mostrarServicio();" onmouseout="this.className='Boton';" type="button" value="Seleccionar Servicio" name="btnSeleccionarServicio"
													Width="126" Height="19" DESIGNTIMEDRAGDROP="240"></TD>
										</TR>
										<tr id="trServicio" style="DISPLAY: none">
											<td class="Arial10B" colSpan="4">
												<table id="tblServicio" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 25px" align="left">&nbsp;Servicios</td>
													</tr>
													<tr id="trGrillaServicio">
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td>
																		<asp:datagrid id="dgrServicioCabecera" runat="server" showheader="True" autogeneratecolumns="False">
																			<columns>
																				<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
																					<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
																				</asp:boundcolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="140px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CARGO FIJO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="140px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="SELECCIONABLE">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="140px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>																
															<div class="clsGridRow" style="WIDTH: 550px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">																
																	<tr>
																		<td>
																			<asp:datagrid id="dgrServicioDetalle" runat="server" showheader="False" autogeneratecolumns="False">
																				<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
																				<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
																				<columns>
																					<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																						<itemstyle horizontalalign="Center"></itemstyle>
																						<itemtemplate>
																							<asp:CheckBox ID="chkSD" Runat="server"></asp:CheckBox>
																						</itemtemplate>
																					</asp:templatecolumn>
																					<asp:boundcolumn datafield="servv_codigo" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="servv_descripcion" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="140px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="cargoFijo" Visible="False"></asp:boundcolumn>
																					<asp:TemplateColumn headerstyle-width="140px" itemstyle-width="140px" ItemStyle-HorizontalAlign="Center">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<ItemTemplate>
																							<asp:TextBox ID="txtCargoFijo" Runat="server" Width="130px" cssclass="clsInputEnable" onkeypress="return fSoloMontos(event, this);"
																								onpaste="return false;" MaxLength="6" ondrop="return false;"></asp:TextBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:boundcolumn datafield="seleccionable" Visible="False"></asp:boundcolumn>
																					<asp:TemplateColumn headerstyle-width="140px" itemstyle-width="140px" ItemStyle-HorizontalAlign="Center">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<ItemTemplate>
																							<asp:DropDownList ID="ddlServicioSeleccionable" Runat="server" Width="130px" cssclass="clsSelectEnable">
																								<asp:ListItem Selected="True" Value="0">No SELECCIONADO</asp:ListItem>
																								<asp:ListItem Value="1">SELECCIONADO</asp:ListItem>
																							</asp:DropDownList>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
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
			<input id="hidPlanCodigo" type="hidden" runat="server"> <input id="hidCargaInicial" type="hidden" runat="server">
			<input type="hidden" id="hidKit" name="hidKit" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
