<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_empresa_top.aspx.vb" Inherits="sisact_mant_empresa_top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_whitelist_flexi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="JavaScript" src="../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../librerias/funciones_generales.js"></script>		
		<script src="../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript">
			
			function f_Buscar()
			{					
				/*if (getValue('txtBusquedaNroDocumento').length == 0 &&
					getValue('txtBusquedaRangoInicio').length == 0 && getValue('txtBusquedaRangoFin').length == 0 &&
					getValue('txtBusquedaFechaInicio').length == 0 && getValue('txtBusquedaFechaFin').length == 0)
				{
					alert('Debe seleccionar algun criterio de búsqueda');
					return false;
				}*/
				if (getValue('ddlBusquedaTipoDocumento') == '00' && getValue('txtBusquedaNroDocumento').length > 0)
				{
					alert('Debe seleccionar el tipo de documento');
					return false;
				}
				if (getValue('ddlBusquedaTipoDocumento') != '00' && getValue('txtBusquedaNroDocumento').length == 0)
				{
					alert('Debe ingresar el nro de documento');
					return false;
				}
				if (getValue('txtBusquedaFechaInicio').length > 0 && getValue('txtBusquedaFechaFin').length == 0)
				{
					alert('Debe ingresar la fecha final');
					return false;
				}
				if (getValue('txtBusquedaFechaInicio').length == 0 && getValue('txtBusquedaFechaFin').length > 0)
				{
					alert('Debe ingresar la fecha inicial');
					return false;
				}				
				if (getValue('txtBusquedaRangoInicio').length > 0 && getValue('txtBusquedaRangoFin').length == 0)
				{
					alert('Debe ingresar el ranking final');
					return false;
				}
				if (getValue('txtBusquedaRangoInicio').length == 0 && getValue('txtBusquedaRangoFin').length > 0)
				{
					alert('Debe ingresar el ranking inicial');
					return false;
				}
				if (getValue('ddlBusquedaTipoDocumento') == '06')
				{
					if (getValue('txtBusquedaNroDocumento').length != 11)
					{
						alert('El ruc debe tener 11 dígitos');
						setFocus('txtBusquedaNroDocumento');
						return false;						
					}
				}				
			}
			
			function f_Limpiar()
			{
				setValue('txtBusquedaRangoInicio', '');
				setValue('txtBusquedaRangoFin', '');
				setValue('txtBusquedaFechaInicio', '');
				setValue('txtBusquedaFechaFin', '');				
				document.getElementById('<%=ddlBusquedaTipoDocumento.ClientId %>').selectedIndex = -1;
				setValue('txtBusquedaNroDocumento', '');
				setValue('txtBusquedaNombre', '');
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
			
			function f_Modificar(tipoDocu, nroDocu)
			{
				setValue('hidTipoDocumento',tipoDocu);
				setValue('hidNroDocumento',nroDocu);
				__doPostBack('btnModificar','');
			}
			
			function f_ConfirmarGrabar()
			{	
				if (!f_ValidarGrabar(true))
					return false;
					
				if (confirm('¿Desea guardar los cambios?'))
					return true;
				else
					return false;
			}
			
			function f_ValidarGrabar(valObligatorio)
			{	
				if (valObligatorio)
				{
					if (getValue('txtNroDocumento').length == 0)
					{
						alert('Debe ingresar el nro de documento');
						setFocus('txtNroDocumento');
						return false;
					}
				}				
				if (getValue('txtNroDocumento').length > 0 && getValue('txtNroDocumento').length < 11)
				{
					alert('El ruc debe tener 11 dígitos');
					setFocus('txtNroDocumento');
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
			
			function fActivarVigencia(boo, borrar)
			{
				var txtVigenciaDias = document.getElementById('<%=txtVigenciaDias.ClientId %>')
				
				if (borrar)
					txtVigenciaDias.value = '0';
					
				txtVigenciaDias.readOnly = boo;

				if (!boo)
					txtVigenciaDias.className = 'clsInputEnable';
				else
					txtVigenciaDias.className = 'clsInputDisable';
			}
			
			function f_TraerNombre(nroDocumento)
			{
				if (f_ValidarGrabar(false))
					__doPostBack('btnTraerCliente','');
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
				/*var strCadena = document.getElementById('<%=hidEliminar.ClientId %>').value;
				
				if (strCadena.length == 0)
					return false;*/
					
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
			
			function validarAlfanumerico(txt)
			{
				if (!txt.readOnly)
				{
					var strCadena = txt.value
					if (strCadena.length > 0)
					{
						if (!isNumOrChar2(strCadena))
							txt.value = '';
					}
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
							de Empresas Top</td>
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
																Empresa</td>
														</tr>
														<TR>
															<TD class="Arial10B">Tipo de Documento</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:dropdownlist id="ddlBusquedaTipoDocumento" runat="server" Width="130px" CssClass="clsSelectEnable">
																	<asp:ListItem Value="00">TODOS...</asp:ListItem>
																	<asp:ListItem Value="06">RUC</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD>&nbsp;</TD>
															<TD class="Arial10B">Nro. de Documento</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtBusquedaNroDocumento" onblur="validarSoloNumeros(this);"
																	runat="server" cssclass="clsInputEnable" width="100px" MaxLength="11"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="Arial10B">Nombres Cliente / Razón Social</TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B" colSpan="5"><asp:textbox id="txtBusquedaNombre" onblur="validarAlfanumerico(this);" runat="server" cssclass="clsInputEnable"
																	width="400px" MaxLength="200"></asp:textbox></TD>
														</TR>
														<tr>
															<TD class="Arial10B">Rango de Ranking</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtBusquedaRangoInicio"
																				ondrop="return false;" runat="server" Width="50px" CssClass="clsInputEnable" MaxLength="5"></asp:textbox></TD>
																		<TD class="Arial10B">&nbsp;a&nbsp;</TD>
																		<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtBusquedaRangoFin"
																				ondrop="return false;" runat="server" Width="50px" CssClass="clsInputEnable" MaxLength="5"></asp:textbox></TD>
																	</TR>
																</TABLE>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B">Rango de Fecha de Registro</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B">
																<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="Arial10B"><asp:textbox id="txtBusquedaFechaInicio" runat="server" Width="80px" CssClass="clsInputDisable"
																				ReadOnly="True"></asp:textbox></TD>
																		<TD class="Arial10B"><IMG id="btnBusquedaFechaInicio" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																				src="../../images/calendario.gif" border="0">
																			<SCRIPT type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtBusquedaFechaInicio",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnBusquedaFechaInicio",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
																			</SCRIPT>
																		</TD>
																		<TD class="Arial10B">&nbsp;al&nbsp;</TD>
																		<TD class="Arial10B"><asp:textbox id="txtBusquedaFechaFin" runat="server" Width="80px" CssClass="clsInputDisable"
																				ReadOnly="True"></asp:textbox></TD>
																		<TD class="Arial10B"><IMG id="btnBusquedaFechaFin" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																				src="../../images/calendario.gif" border="0">
																			<SCRIPT type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtBusquedaFechaFin",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnBusquedaFechaFin",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
																			</SCRIPT>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
															<TD class="Arial10B"></TD>
														</tr>
														<tr>
															<td style="HEIGHT: 26px" align="center" colSpan="7"><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																	onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Buscar" Runat="server"></asp:button>&nbsp;
																<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																	onmouseout="this.className='Boton';" Width="90" CssClass="Boton" Height="19" Text="Limpiar"
																	Runat="server"></asp:button></td>
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
												<td colSpan="2"><asp:datagrid id="dgrGrillaDetalle" runat="server" width="970px" autogeneratecolumns="False" AllowPaging="True"
														DataKeyField="etopv_num_doc">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "tdocc_codigo")%>", "<%# DataBinder.Eval(Container.DataItem, "etopv_num_doc")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar cliente'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="tdocc_des" HeaderText="TIPO DOC">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopv_num_doc" HeaderText="NRO DOC">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopv_razon_social" HeaderText="NOMBRE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="300px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopc_tipo" HeaderText="TIPO EMPR">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopc_vige_inde" HeaderText="VIGE INDEF">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopn_dias_tolerancia" HeaderText="VIGE DIAS">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopn_ranking" HeaderText="RANKING">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="etopc_fech_regi" HeaderText="FECHA REG">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<HeaderTemplate>
																	<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True" OnCheckedChanged="chkTotalGrilla_CheckedChanged"></asp:CheckBox>
																</HeaderTemplate>
																<itemtemplate>
																	<asp:CheckBox ID="fila" Runat="server"></asp:CheckBox>
																</itemtemplate>
															</asp:templatecolumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td><asp:button id="btnEliminar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="135" CssClass="Boton" Height="19" Text="Eliminar seleccionados"
														Runat="server"></asp:button></td>
												<td align="right"><asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="126" CssClass="Boton" Height="19" Text="Exportar" Runat="server"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trEdicion">
									<td>
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="header" colSpan="7" height="25">Detalle de Empresa</td>
											</tr>
											<TR>
												<TD class="Arial10B">Tipo de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="130px" CssClass="clsSelectEnable" DESIGNTIMEDRAGDROP="1024">
														<asp:ListItem Value="06">RUC</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD>&nbsp;</TD>
												<TD class="Arial10B">Nro. de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtNroDocumento" onblur="validarSoloNumeros(this);f_TraerNombre(this.value);"
														runat="server" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="113" width="100px" MaxLength="11"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Nombres Cliente / Razón Social</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B">
													<asp:textbox id="txtNombre" onblur="validarAlfanumerico(this);" runat="server" MaxLength="200"
														width="400px" DESIGNTIMEDRAGDROP="121" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
												<TD></TD>
												<TD class="Arial10B">Tipo Empresa</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlTipoEmpresa" runat="server" Width="50px" CssClass="clsSelectDisable" Enabled="False">
														<asp:ListItem Value="1">TOP</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Ranking</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtRanking"
														ondrop="return false;" runat="server" cssclass="clsInputEnable" width="50px" MaxLength="5"></asp:textbox></TD>
												<TD></TD>
												<td class="Arial10B">Flag Vigencia Indefinida</td>
												<td class="Arial10B">:</td>
												<td class="Arial10B"><asp:checkbox id="chkVigenciaIndef" onclick="fActivarVigencia(this.checked, true);" Runat="server"></asp:checkbox></td>
											</TR>
											<tr>
												<TD class="Arial10B">Vigencia (días)</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtVigenciaDias"
														ondrop="return false;" runat="server" cssclass="clsInputEnable" width="50px" MaxLength="3"></asp:textbox></TD>
												<TD></TD>
												<TD class="Arial10B">Fecha de Registro</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onpaste="return false;" id="txtFechaRegistro" ondrop="return false;" runat="server"
														cssclass="clsInputDisable" width="100px" ReadOnly="True"></asp:textbox></TD>
											</tr>
											<tr height="25">
												<td align="center" colSpan="7"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="126" CssClass="Boton" Height="19" Text="Aceptar" Runat="server"></asp:button>&nbsp;
													<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="126" CssClass="Boton" Height="19" Text="Cancelar"
														Runat="server"></asp:button></td>
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
												<td>
													<INPUT class="boton" id="FileToUpload" style="WIDTH: 250px; HEIGHT: 19px" type="file" size="62"
														name="FileToUpload" runat="server">
													<asp:button id="btnCargar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="126" CssClass="Boton" DESIGNTIMEDRAGDROP="340"
														Height="19" Text="Cargar" Runat="server"></asp:button>
												</td>
											</TR>
										</table>
									</td>
								</tr>
							</table>
							<input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
							<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
							<input id="hidTipoDocumento" type="hidden" runat="server"> <input id="hidNroDocumento" type="hidden" runat="server">
							<input id="btnTraerCliente" style="DISPLAY: none" type="button" name="btnTraerCliente"
								runat="server"> <input id="hidEliminar" type="hidden" runat="server">
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
 
 
 
 
