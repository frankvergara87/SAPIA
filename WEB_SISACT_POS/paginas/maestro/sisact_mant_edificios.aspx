<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_edificios.aspx.vb" Inherits="sisact_mant_edificios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_edificios</title>
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
		<script language="javascript" type="text/javascript">
			
			function f_Buscar()
			{					
				return true;
			}
			
			function f_Limpiar()
			{
				setValue('txtDireccion', '');
				document.getElementById('<%=ddlDpto.ClientId %>').selectedIndex = -1;
				document.getElementById('<%=ddlProvincia.ClientId %>').selectedIndex = -1;						
				document.getElementById('<%=ddlDistrito.ClientId %>').selectedIndex = -1;
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
					setVisible('trCargaMasiva', false);	
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='none';
					document.getElementById('tdCargaMasiva').className='tab_inactivo';
				}
				if (valor == 'NUEVO')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);
					setVisible('trCargaMasiva', false);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
					document.getElementById('tdCargaMasiva').className='tab_inactivo';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);
					setVisible('trCargaMasiva', false);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
					document.getElementById('tdCargaMasiva').className='tab_inactivo';
				}
				if (valor == 'CARGAMASIVA')
				{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);	
					setVisible('trEdicion', false);	
					setVisible('trCargaMasiva', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='none';
					document.getElementById('tdCargaMasiva').className='tab_activo';
				}				
			}
			
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
			}
			
			function f_Modificar(secuencia)
			{
				setValue('hidSecuencia', secuencia);
				__doPostBack('btnModificar','');
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
				
				if (getValue('ddlDptoM') == '-1')
				{
					alert('Debe seleccionar un Departamento');
					setFocus('ddlDptoM');
					return false;
				}
				if (getValue('ddlProvinciaM') == '-1')
				{
					alert('Debe seleccionar una Provincia');
					setFocus('ddlProvinciaM');
					return false;
				}
				if (getValue('ddlDistritoM') == '-1')
				{
					alert('Debe seleccionar un Distrito');
					setFocus('ddlDistritoM');
					return false;
				}
				if (getValue('txtNodo') == '')
				{
					alert('Debe ingresar Nodo');
					setFocus('txtNodo');
					return false;
				}
				if (getValue('txtEdificio') == '')
				{
					alert('Debe ingresar Edificio');
					setFocus('txtEdificio');
					return false;
				}
				if (getValue('txtDireccionM') == '')
				{
					alert('Debe ingresar Direccion');
					setFocus('txtDireccionM');
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
			
			function f_guardarSeleccion(booGuardar, nroDoc)
			{
				var hidEliminar = document.getElementById('<%=hidEliminar.ClientId %>');
				var strCadena = hidEliminar.value;
				nroDoc = '|' + nroDoc;
				
				if (booGuardar)
					strCadena += nroDoc;
				else
					strCadena = strCadena.replace(nroDoc, '');
					
				hidEliminar.value = strCadena;
			}
			
			function f_eliminarSeleccionados()
			{		
				if (confirm('¿Desea eliminar estos registros?'))
					return true;
				else
					return false;
			}
			
			function validarSoloNumeros(txt)
			{
				var strCadena = txt.value
				if (strCadena.length > 0)
				{
					if (!isNumber(strCadena))
						txt.value = '';
				}
			}
				
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
							de Edificios</td>
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
															<td class="tab_inactivo" id="tdCargaMasiva" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('CARGAMASIVA');">Carga 
																	Masiva</A></td>
														</tr>
													</table>
												</td>
											</tr>
											<tr id="trBusqueda">
												<td>
													<table cellSpacing="0" cellPadding="0" width="100%" border="0">
														<tr>
															<td class="header" style="HEIGHT: 19px" align="left" colSpan="7">&nbsp;Busqueda de 
																Edificios</td>
														</tr>
														<TR>
															<TD class="Arial10B" style="HEIGHT: 4px">Departamento</TD>
															<TD class="Arial10B" style="HEIGHT: 4px">:</TD>
															<TD class="Arial10B" style="HEIGHT: 4px"><asp:dropdownlist id="ddlDpto" runat="server" CssClass="clsSelectEnable" Width="125px" AutoPostBack="True"></asp:dropdownlist></TD>
															<TD style="HEIGHT: 4px">&nbsp;</TD>
															<TD class="Arial10B" style="HEIGHT: 4px">Distrito</TD>
															<TD class="Arial10B" style="HEIGHT: 4px">:</TD>
															<TD class="Arial10B" style="HEIGHT: 4px"><asp:dropdownlist id="ddlDistrito" runat="server" CssClass="clsSelectEnable" Width="125px"></asp:dropdownlist></TD>
														</TR>
														<tr>
															<TD class="Arial10B">Provincia</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:dropdownlist id="ddlProvincia" runat="server" CssClass="clsSelectEnable" Width="125px" AutoPostBack="True"></asp:dropdownlist></TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B">Dirección</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:textbox id="txtDireccion" runat="server" MaxLength="15" width="275px" cssclass="clsInputEnable"></asp:textbox></TD>
														</tr>
														<tr>
															<td style="HEIGHT: 26px" align="center" colSpan="7"><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																	onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Buscar" Height="19"></asp:button>&nbsp;
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
												<td colSpan="2"><asp:datagrid id="dgrGrillaDetalle" runat="server" width="700px" DataKeyField="EDIFV_CODIGO" AllowPaging="True"
														autogeneratecolumns="False">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "EDIFV_CODIGO")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar registro'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="EDIFV_CODIGO" HeaderText="Item">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="40px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="DEPAC_CODIGO" HeaderText="codDepartamento">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DEPAV_DESCRIPCION" HeaderText="Departamento">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="PROVC_CODIGO" HeaderText="codProvincia">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PROVV_DESCRIPCION" HeaderText="Provincia">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="DISTC_CODIGO" HeaderText="codDistrito">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DISTV_DESCRIPCION" HeaderText="Distrito">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EDIFV_DIRECCION" HeaderText="Direccion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EDIFV_NODO" HeaderText="Nodo">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EDIFV_DESCRIPCION" HeaderText="Edificio">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EDIFD_FECHA_ACTIV" HeaderText="Fecha Activaci&#243;n">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EDIFC_ESTADO" HeaderText="Estado">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<HeaderTemplate>
																	<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True" OnCheckedChanged="chkTotalGrilla_CheckedChanged"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:CheckBox ID="fila" Runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td><asp:button id="btnEliminar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="135" Runat="server" Text="Eliminar seleccionados"
														Height="19"></asp:button></td>
												<td align="right"><asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Exportar" Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trEdicion">
									<td>
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="header" colSpan="7" height="25">Detalle del Edificio</td>
											</tr>
											<TR>
												<TD class="Arial10B" style="HEIGHT: 19px">Departamento</TD>
												<TD class="Arial10B" style="HEIGHT: 19px">:</TD>
												<TD class="Arial10B" style="HEIGHT: 19px"><asp:dropdownlist id="ddlDptoM" runat="server" CssClass="clsSelectEnable" Width="200px" DESIGNTIMEDRAGDROP="117"
														AutoPostBack="True"></asp:dropdownlist></TD>
												<TD style="HEIGHT: 19px">&nbsp;</TD>
												<TD class="Arial10B" style="HEIGHT: 19px">Nodo</TD>
												<TD class="Arial10B" style="HEIGHT: 19px">:</TD>
												<TD class="Arial10B" style="HEIGHT: 19px"><asp:textbox id="txtNodo" runat="server" MaxLength="15" width="100px" cssclass="clsInputEnable"
														DESIGNTIMEDRAGDROP="1478"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Provincia</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlProvinciaM" runat="server" CssClass="clsSelectEnable" Width="200px" DESIGNTIMEDRAGDROP="117"
														AutoPostBack="True"></asp:dropdownlist></TD>
												<TD></TD>
												<td class="Arial10B">Edificio</td>
												<td class="Arial10B">:</td>
												<td class="Arial10B"><asp:textbox id="txtEdificio" ondrop="return false;" runat="server" MaxLength="5" width="100px"
														cssclass="clsInputEnable"></asp:textbox></td>
											</TR>
											<tr>
												<TD class="Arial10B">Distrito</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlDistritoM" runat="server" CssClass="clsSelectEnable" Width="200px" DESIGNTIMEDRAGDROP="117"></asp:dropdownlist></TD>
												<TD></TD>
												<TD class="Arial10B">Fecha Activación</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onpaste="return false;" id="txtfechaActiv" ondrop="return false;" runat="server"
														width="100px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
											</tr>
											<tr>
												<TD class="Arial10B">Dirección</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox id="txtDireccionM" runat="server" MaxLength="15" width="264px" cssclass="clsInputEnable"
														DESIGNTIMEDRAGDROP="1478"></asp:textbox></TD>
												<TD></TD>
												<TD class="Arial10B">
													<P>Estado</P>
												</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlEstado" runat="server" CssClass="clsSelectEnable" Width="104px" DESIGNTIMEDRAGDROP="117">
														<asp:ListItem Value="1" Selected="True">Habilitado</asp:ListItem>
														<asp:ListItem Value="0">Deshabilitado</asp:ListItem>
													</asp:dropdownlist></TD>
											</tr>
											<tr height="25">
												<td align="center" colSpan="7"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Aceptar" Height="19" DESIGNTIMEDRAGDROP="528"></asp:button>&nbsp;
													<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Cancelar"
														Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trCargaMasiva">
									<td>
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="header" style="HEIGHT: 19px" align="left" colSpan="7">&nbsp;Carga Masiva</td>
											</tr>
											<TR>
												<TD class="Arial10B">&nbsp;</TD>
											</TR>
											<TR>
												<td><INPUT class="boton" id="FileToUpload" style="WIDTH: 250px; HEIGHT: 19px" type="file" size="62"
														name="FileToUpload" runat="server">
													<asp:button id="btnCargar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Cargar"
														Height="19" DESIGNTIMEDRAGDROP="340"></asp:button></td>
											</TR>
										</table>
									</td>
								</tr>
							</table>
							<input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
							<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
							<input id="hidEliminar" type="hidden" name="hidEliminar" runat="server"> <input id="hidSecuencia" type="hidden" name="hidSecuencia" runat="server">
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
 
 
 
 
