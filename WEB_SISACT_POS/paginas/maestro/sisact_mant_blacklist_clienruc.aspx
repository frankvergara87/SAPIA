<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_blacklist_clienruc.aspx.vb" Inherits="sisact_mant_blacklist_clienruc" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_blacklist_clienruc</title>
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
				/*if (getValue('txtBusquedaNroDocumento').length == 0 &&
					getValue('txtBusquedaFechaInicio').length == 0 && getValue('txtBusquedaFechaFin').length == 0 &&
					getValue('ddlBusquedaTipoEmpresa') == 0)
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
					alert('Debe ingresar la fecha de fin');
					return false;
				}
				if (getValue('txtBusquedaFechaInicio').length == 0 && getValue('txtBusquedaFechaFin').length > 0)
				{
					alert('Debe ingresar la fecha de inicio');
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
				if (getValue('txtBusquedaNroDocuRRLL').length > 0 && getValue('txtBusquedaNroDocuRRLL').length < 8)
				{
					alert('El nro de documento rrll debe tener 8 dígitos');
					setFocus('txtBusquedaNroDocuRRLL');
					return false;						
				}
			}
			
			function f_Limpiar()
			{
				setValue('txtBusquedaFechaInicio', '');
				setValue('txtBusquedaFechaFin', '');
				document.getElementById('<%=ddlBusquedaTipoDocumento.ClientId %>').selectedIndex = -1;
				setValue('txtBusquedaNroDocumento', '');
				document.getElementById('<%=ddlBusquedaTipoEmpresa.ClientId %>').selectedIndex = -1;
				setValue('txtBusquedaNroDocuRRLL', '');
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
			
			function f_Eliminar(tipoDocu, nroDocu)
			{
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
					setValue('hidTipoDocumento',tipoDocu);
					setValue('hidNroDocumento',nroDocu);
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
				var booResultado;
				
				booResultado = f_ValidarNombre();

				if (booResultado)
					booResultado = f_ValidarUsuarioNombre();
									
				if (booResultado)
				{
					if (getValue('txtUsuarioAprobador').length == 0)
					{
						alert('No existe el usuario');
						//setFocus('txtUsuario');
						return false;						
					}
					if (getValue('txtNroDocuRRLL').length > 0 && getValue('txtNroDocuRRLL').length != 8)
					{
						alert('El documento rrll debe tener 8 dígitos');
						//setFocus('txtNroDocuRRLL');
						return false;						
					}
				}
				
				return booResultado;
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
			
			function f_ValidarNombre()
			{				
				if (getValue('txtNroDocumento').length == 0)
				{
					alert('Debe ingresar el nro de documento');
					//setFocus('txtNroDocumento');
					return false;
				}
				if (getValue('txtNroDocumento').length != 11)
				{
					alert('El ruc debe tener 11 dígitos');
					//setFocus('txtNroDocumento');
					return false;						
				}

				return true;
			}
			
			function f_ValidarUsuarioNombre()
			{				
				if (getValue('txtUsuario').length == 0)
				{
					alert('Debe ingresar el usuario');
					//setFocus('txtUsuario');
					return false;						
				}
				
				return true;
			}
			
			function f_TraerNombre(nroDocumento)
			{
				//if (f_ValidarNombre())
					__doPostBack('btnTraerCliente','');
			}
			
			function f_TraerUsuarioNombre()
			{
				if (f_ValidarUsuarioNombre())
					__doPostBack('btnTraerUsuarioNombre','');
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
				if (!txt.readOnly)
				{			
					var strCadena = txt.value
					if (strCadena.length > 0)
					{
						if (!isNumber(strCadena))
							txt.value = '';
					}
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
							de Blacklist Clientes RUC</td>
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
																Blacklist Cliente RUC</td>
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
																	runat="server" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="494" width="100px" MaxLength="11"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="Arial10B">Nro. de Documento de RRLL</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B">
																<asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtBusquedaNroDocuRRLL" onblur="validarSoloNumeros(this);"
																	runat="server" MaxLength="8" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
															<TD></TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B"></TD>
														</TR>
														<tr>
															<TD class="Arial10B">Rango de Fecha de Registro</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
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
															<TD class="Arial10B"></TD>
															<TD class="Arial10B">Tipo Empresa</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:dropdownlist id="ddlBusquedaTipoEmpresa" runat="server" Width="130px" CssClass="clsSelectEnable">
																	<asp:ListItem Value="0">TODOS...</asp:ListItem>
																	<asp:ListItem Value="2">Locutorio</asp:ListItem>
																	<asp:ListItem Value="3">Comercializadora</asp:ListItem>
																	<asp:ListItem Value="4">Blacklist Fraude</asp:ListItem>
																	<asp:ListItem Value="5">Graylist Fraude</asp:ListItem>
																	<asp:ListItem Value="6">Blacklist Fija</asp:ListItem>
																	<asp:ListItem Value="7">Blacklist Prepago</asp:ListItem>
																</asp:dropdownlist></TD>
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
												<td colspan="2"><asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" showheader="True"
														AllowPaging="True" DataKeyField="bklsv_nrodocu">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "bklsc_tipodocu")%>", "<%# DataBinder.Eval(Container.DataItem, "bklsv_nrodocu")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar cliente'> </a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="bklsc_tipodocudesc" itemstyle-cssclass="Arial10B" HeaderText="TIPO DOC">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsv_nrodocuform" itemstyle-cssclass="Arial10B" HeaderText="NRO DOC">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsv_nrodocurrll" itemstyle-cssclass="Arial10B" HeaderText="NRO DOC RRLL">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>															
															<asp:boundcolumn datafield="bklsv_nombre" itemstyle-cssclass="Arial10B" HeaderText="NOMBRE">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="300px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsn_tipoempr" itemstyle-cssclass="Arial10B" HeaderText="TIPO EMPR">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsv_comentario" itemstyle-cssclass="Arial10B" HeaderText="COMENTARIO">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsc_vigeinde" itemstyle-cssclass="Arial10B" HeaderText="VIGE INDEF">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsn_vigedias" itemstyle-cssclass="Arial10B" HeaderText="VIGE DIAS">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsv_usuaapro" itemstyle-cssclass="Arial10B" HeaderText="USUA APRO">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bklsv_nombusuaapro" itemstyle-cssclass="Arial10B" HeaderText="NOMB APRO">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="bkLSC_FECHREGI" itemstyle-cssclass="Arial10B" HeaderText="FECHA REG">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<HeaderTemplate>
																	<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True" OnCheckedChanged="chkTotalGrilla_CheckedChanged"></asp:CheckBox>
																</HeaderTemplate>
																<itemtemplate>
																	<asp:CheckBox ID="fila" Runat="server"></asp:CheckBox>
																</itemtemplate>
															</asp:templatecolumn>
														</columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid>
												</td>
											</tr>
											<tr>
												<td>
													<asp:button id="btnEliminar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="135" CssClass="Boton" Height="19" Text="Eliminar seleccionados"
														Runat="server"></asp:button>
												</td>
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
												<td class="header" colSpan="7" height="25">Detalle de Blacklist Cliente RUC</td>
											</tr>
											<TR>
												<TD class="Arial10B">Tipo de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlTipoDocumento" runat="server" Width="130px" CssClass="clsSelectEnable" DESIGNTIMEDRAGDROP="268">
														<asp:ListItem Value="06">RUC</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD>&nbsp;</TD>
												<TD class="Arial10B">Nro. de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtNroDocumento" onblur="validarSoloNumeros(this);f_TraerNombre(this.value);"
														runat="server" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1478" width="100px" MaxLength="11"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Nro. de Documento de RRLL</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtNroDocuRRLL" onblur="validarSoloNumeros(this);f_TraerUsuarioNombre();"
														runat="server" cssclass="clsInputEnable" width="100px" MaxLength="8"></asp:textbox></TD>
												<TD></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Nombres Cliente / Razón Social</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox id="txtNombre" runat="server" cssclass="clsInputDisable" onblur="validarAlfanumerico(this);"
														width="400px" ReadOnly="True" MaxLength="100"></asp:textbox></TD>
												<TD></TD>
												<td class="Arial10B">Tipo Empresa</td>
												<td class="Arial10B">:</td>
												<td class="Arial10B"><asp:dropdownlist id="ddlTipoEmpresa" runat="server" Width="130px" CssClass="clsSelectEnable">
														<asp:ListItem Value="2">Locutorio</asp:ListItem>
														<asp:ListItem Value="3">Comercializadora</asp:ListItem>
														<asp:ListItem Value="4">Blacklist Fraude</asp:ListItem>
														<asp:ListItem Value="5">Graylist Fraude</asp:ListItem>
														<asp:ListItem Value="6">Blacklist Fija</asp:ListItem>
														<asp:ListItem Value="7">Blacklist Prepago</asp:ListItem>
													</asp:dropdownlist></td>
											</TR>
											<tr>
												<TD class="Arial10B">Comentarios</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox id="txtComentario" runat="server" cssclass="clsInputEnable" width="400px" TextMode="MultiLine"
														maxlength="1000"></asp:textbox></TD>
												<TD></TD>
												<TD class="Arial10B">Flag Vigencia Indefinida</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:checkbox id="chkVigenciaIndef" onclick="fActivarVigencia(this.checked, true);" Runat="server"></asp:checkbox></TD>
											</tr>
											<tr>
												<TD class="Arial10B">Vigencia (días)</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtVigenciaDias"
														ondrop="return false;" runat="server" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="324" width="50px" MaxLength="3"></asp:textbox></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B">Fecha de Registro</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onpaste="return false;" id="txtFechaRegistro" ondrop="return false;" runat="server"
														cssclass="clsInputDisable" width="100px" ReadOnly="True"></asp:textbox></TD>
											</tr>
											<TR>
												<TD class="Arial10B">Usuario Analista</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtUsuario"
														onblur="f_TraerUsuarioNombre(this.value);" ondrop="return false;" runat="server" cssclass="clsInputDisable"
														width="50px" MaxLength="10" ReadOnly="True"></asp:textbox></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Nombre Analista</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onpaste="return false;" id="txtUsuarioAprobador" ondrop="return false;" runat="server"
														cssclass="clsInputDisable" width="400px" ReadOnly="True"></asp:textbox></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B"></TD>
											</TR>
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
								runat="server"> <input id="hidEliminar" type="hidden" runat="server"> <input id="btnTraerUsuarioNombre" style="DISPLAY: none" type="button" name="btnTraerUsuarioNombre"
								runat="server">
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
 
 
 
 
