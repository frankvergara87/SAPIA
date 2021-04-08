<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_blacklist_dac.aspx.vb" Inherits="sisact_mant_blacklist_dac" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_blacklist_dac</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
			function f_ValidarEnterBus()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						//f_Buscar();
						document.getElementById('<%=btnBusBuscar.ClientId%>').click();
						event.keyCode = 0;
					}
				}
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
					setVisible('trGrillaEdicion', false);
					setVisible('trAceptar', false);
					
					f_mostrarBotoneraListado();
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
				}
				if (valor == 'NUEVO')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);	
					setVisible('trGrillaEdicion', true);
					setVisible('trAceptar', true);					
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
				}
			}
			
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
			}			
			
			function f_Eliminar(codigo)
			{
				if (confirm('¿Está seguro de eliminar el registro seleccionado?'))
				{
					setValue('hidCodigo', codigo);
					__doPostBack('btnEliminar', '');
				}
			}
			
			function f_Cancelar()
			{
				f_MostrarTab('BUSQUEDA');
				setValue('hidCodigos', '');
			}

			function f_SeleccionarTodo(booSel, clave)
			{
				var tabla;
				
				if (clave.length == 0)
					tabla = document.getElementById('<%=dgrGrillaDetalleEdicion.ClientId %>');
				else
					tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
					
				if (tabla == null)
					return;					
					
				var cont = tabla.rows.length;
				var fila;
				var chkFila;
				var hidBusqItemsSel = document.getElementById('hidBusqItemsSel' + clave);
				var hidCheckTotal = document.getElementById('hidCheckTotal' + clave);
				
				if (booSel)
				{
					hidBusqItemsSel.value = document.getElementById('hidBusqItems' + clave).value;
					hidCheckTotal.value = 'S';
				}
				else
				{
					hidBusqItemsSel.value = '';
					hidCheckTotal.value = '';
				}
				
				for (var i = 0; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					chkFila = fila.cells[0].getElementsByTagName("input")[0];
					chkFila.checked = booSel;
				}
			}
			
			function f_LlenarCheckXPagina(clave)
			{
				var tabla;
				
				if (clave.length == 0)
					tabla = document.getElementById('<%=dgrGrillaDetalleEdicion.ClientId %>');
				else
					tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
					
				if (tabla == null)
					return;
					
				var cont = tabla.rows.length;
				var fila;
				var chkFila;
				var strBusqItemsSel = document.getElementById('hidBusqItemsSel' + clave).value;
				var strCodigo;
				var chkTotalGrilla = document.getElementById('chkTotalGrilla' + clave);
				var strCheckTotal = document.getElementById('hidCheckTotal' + clave).value;
				
				for (var i = 0; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					chkFila = fila.cells[0].getElementsByTagName("input")[0];
					strCodigo = fila.cells[0].getElementsByTagName("input")[1].value;
					
					if (strBusqItemsSel.indexOf('[' + strCodigo + ']') > -1)
						chkFila.checked = true;
					else
						chkFila.checked = false;
				}
				
				if (strCheckTotal == 'S')
					chkTotalGrilla.checked = true;
				else
					chkTotalGrilla.checked = false;
					
				if (clave.length == 0)
					f_MostrarTab('NUEVO');
				else
				{
					f_MostrarTab('BUSQUEDA');
					f_mostrarBotoneraListado();
				}
			}
			
			function f_mostrarBotoneraListado()
			{
				var strBusqItems = document.getElementById('hidBusqItemsCons').value;
				
				if (strBusqItems.length > 0)
					document.getElementById('btnEliminarCons').style.display = '';
				else
					document.getElementById('btnEliminarCons').style.display = 'none';
			}
			
			function f_Seleccionar(booSel, strCodigo, clave)
			{					
				var chkTotalGrilla = document.getElementById('chkTotalGrilla' + clave);
				var hidCheckTotal = document.getElementById('hidCheckTotal' + clave);
				var hidBusqItemsSel = document.getElementById('hidBusqItemsSel' + clave);
				var strBusqItemsSel = hidBusqItemsSel.value;
				chkTotalGrilla.checked = false;
				hidCheckTotal.value = '';
				
				if (!booSel)
					hidBusqItemsSel.value = strBusqItemsSel.replace('[' + strCodigo + ']', '');
				else
					hidBusqItemsSel.value += '[' + strCodigo + ']';
			}
			
			function f_EliminarCons()
			{
				var strBusqItemsSel = getValue('hidBusqItemsSelCons');
				
				if (strBusqItemsSel.length == 0)
				{
					alert('Debe seleccionar al menos un registro para Eliminar');
					return false;
				}

				if (!confirm('¿Esta seguro de eliminar el(los) registro(s) seleccionado(s)?'))
					return false;

				return true;
			}

		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="tblContenido" border="0" cellSpacing="0" cellPadding="0">
				<tr>
					<td style="WIDTH: 980px; HEIGHT: 23px" class="header" align="center">Mantenimiento 
						de Blacklist DACs</td>
				</tr>
				<tr>
					<td class="contenido">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>
									<table id="tblDetalleLista" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td colSpan="4">
												<table border="0" cellSpacing="0" cellPadding="0">
													<tr>
														<td><IMG src="../../spacer.gif" width="2" height="2"></td>
														<td id="tdListado" class="tab_activo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG src="../../spacer.gif" width="2" height="2"></td>
														<td id="tdAgregar" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td style="HEIGHT: 19px" class="header" colSpan="6" align="left">&nbsp;Busqueda de 
															DAC</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px" class="Arial10B">&nbsp;Descripción</td>
														<td><asp:textbox onkeydown="javascript:f_ValidarEnterBus();" id="txtBusDescripcion" ondrop="return false;"
																onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" runat="server" MaxLength="50"
																Width="300px" CssClass="clsInputEnable"></asp:textbox>&nbsp;<asp:button style="CURSOR: hand" id="btnBusBuscar" onmouseover="this.className='BotonResaltado';"
																onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Buscar" Runat="server"></asp:button>&nbsp;
															<asp:button style="CURSOR: hand" id="btnBusLimpiar" onmouseover="this.className='BotonResaltado';"
																onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Limpiar"
																Runat="server"></asp:button></td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px" class="Arial10B">&nbsp;Departamento</td>
														<td><asp:dropdownlist id="ddlBusDepartamento" runat="server" Width="130px" CssClass="clsSelectEnable"></asp:dropdownlist></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trGrilla">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" autogeneratecolumns="False">
													<Columns>
														<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
															<HeaderStyle horizontalalign="Center" CssClass="TablaTitulos"></HeaderStyle>
															<HeaderTemplate>
																<input type="checkbox" name="chkTotalGrillaCons" id="chkTotalGrillaCons" onclick="f_SeleccionarTodo(this.checked, 'Cons')" />
															</HeaderTemplate>
														</asp:templatecolumn>
														<asp:TemplateColumn HeaderText="COD DAC">
															<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n DAC">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Departamento">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div style="WIDTH: 765px" id="divGrillaDetalle" class="clsGridRow">
										<table border="0" cellSpacing="0" cellPadding="0" width="735">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" AllowPaging="True"
														PageSize="10" showheader="False">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<input type="checkbox" name="chkFilaCons" id="chkFilaCons" onclick="f_Seleccionar(this.checked, '<%# DataBinder.Eval(Container.DataItem, "ovenc_codigo")%>', 'Cons')" />
																	<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "ovenc_codigo")%>" />
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="ovenc_codigo" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="ovenv_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="300px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="depav_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="300px"></itemstyle>
															</asp:boundcolumn>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "ovenc_codigo")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Servicio'></a>
																</itemtemplate>
															</asp:templatecolumn>
														</columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
										</table>
									</div>
									<asp:button id="btnEliminarCons" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Eliminar"
										Height="19"></asp:button>
								</td>
							</tr>
							<tr id="trEdicion">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="header" height="25" colSpan="5">Detalle del DAC</td>
										</tr>
										<tr>
											<td style="HEIGHT: 26px" class="Arial10B">&nbsp;Descripción</td>
											<td><asp:textbox onkeydown="javascript:f_ValidarEnter();" id="txtDescripcion" ondrop="return false;"
													onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" runat="server" MaxLength="50"
													Width="300px" CssClass="clsInputEnable"></asp:textbox>&nbsp;<asp:button style="CURSOR: hand" id="btnBuscar" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Buscar" Runat="server"></asp:button>&nbsp;
												<asp:button style="CURSOR: hand" id="btnLimpiar" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Limpiar"
													Runat="server"></asp:button></td>
										</tr>
										<tr>
											<td style="HEIGHT: 26px" class="Arial10B">&nbsp;Departamento</td>
											<td><asp:dropdownlist id="ddlDepartamento" runat="server" Width="130px" CssClass="clsSelectEnable"></asp:dropdownlist></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trGrillaEdicion">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabeceraEdicion" runat="server" autogeneratecolumns="False">
													<Columns>
														<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
															<HeaderStyle horizontalalign="Center" CssClass="TablaTitulos"></HeaderStyle>
															<HeaderTemplate>
																<input type="checkbox" name="chkTotalGrilla" id="chkTotalGrilla" onclick="f_SeleccionarTodo(this.checked, '')" />
															</HeaderTemplate>
														</asp:templatecolumn>
														<asp:TemplateColumn HeaderText="COD DAC">
															<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n DAC">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Departamento">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div style="WIDTH: 740px" id="divGrillaDetalleEdicion" class="clsGridRow">
										<table border="0" cellSpacing="0" cellPadding="0" width="710">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalleEdicion" runat="server" autogeneratecolumns="False" AllowPaging="True"
														PageSize="10" showheader="False">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<input type="checkbox" name="chkFila" id="chkFila" onclick="f_Seleccionar(this.checked, '<%# DataBinder.Eval(Container.DataItem, "ovenc_codigo")%>', '')" />
																	<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "ovenc_codigo")%>" />
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="ovenc_codigo" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="70px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="ovenv_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="300px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="depav_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="300px"></itemstyle>
															</asp:boundcolumn>
														</columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr id="trAceptar" height="25">
								<td colSpan="4" align="center"><asp:button style="CURSOR: hand" id="btnAceptar" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" Width="126" CssClass="Boton" Height="19" Text="Agregar" Runat="server"></asp:button>&nbsp;
									<INPUT class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="f_Cancelar()" onmouseout="this.className='Boton';" type="button" value="Cancelar"
										name="btnCancelar">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input style="DISPLAY: none" id="btnAgregar" type="button" name="btnAgregar" runat="server">
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input type="hidden" id="hidBusqItems" name="hidBusqItems" runat="server"> <input type="hidden" id="hidBusqItemsSel" name="hidBusqItemsSel" runat="server">
			<input type="hidden" id="hidCheckTotal" name="hidCheckTotal" runat="server"> <input type="hidden" id="hidBusqItemsCons" name="hidBusqItemsCons" runat="server">
			<input type="hidden" id="hidBusqItemsSelCons" name="hidBusqItemsSelCons" runat="server">
			<input type="hidden" id="hidCheckTotalCons" name="hidCheckTotalCons" runat="server">
			<input type="hidden" id="hidCodigo" name="hidCodigo" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
