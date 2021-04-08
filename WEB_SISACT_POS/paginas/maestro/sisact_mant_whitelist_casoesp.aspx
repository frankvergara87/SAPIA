<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_whitelist_casoesp.aspx.vb" Inherits="sisact_mant_whitelist_casoesp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_whitelist_casoesp</title>
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
				if (getValue('ddlBusquedaTipoDocumento') == '00' && getValue('txtBusquedaNroDocumento').length > 0)
				{
					alert('Debe seleccionar el tipo de documento');
					setFocus('ddlBusquedaTipoDocumento');
					return false;
				}
				if (getValue('ddlBusquedaTipoDocumento') != '00' && getValue('txtBusquedaNroDocumento').length == 0)
				{
					alert('Debe ingresar el nro de documento');
					setFocus('txtBusquedaNroDocumento');
					return false;
				}
				if (getValue('txtBusquedaVigenciaInicio').length > 0 && getValue('txtBusquedaVigenciaFin').length == 0)
				{
					alert('Debe ingresar la vigencia fin');
					setFocus('txtBusquedaVigenciaFin');
					return false;
				}
				if (getValue('txtBusquedaVigenciaInicio').length == 0 && getValue('txtBusquedaVigenciaFin').length > 0)
				{
					alert('Debe ingresar la vigencia de inicio');
					setFocus('txtBusquedaVigenciaInicio');
					return false;
				}
				if (getValue('ddlBusquedaTipoDocumento') == '01')
				{
					if (getValue('txtBusquedaNroDocumento').length != 8)
					{
						alert('El dni debe tener 8 dígitos');
						setFocus('txtBusquedaNroDocumento');
						return false;						
					}
				}
				if (getValue('ddlBusquedaTipoDocumento') == '04')
				{
					if (getValue('txtBusquedaNroDocumento').length != 9)
					{
						alert('El ce debe tener 9 caracteres');
						setFocus('txtBusquedaNroDocumento');
						return false;						
					}
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

    //PROY 31636
    var strTipoDoc = getValue('ddlBusquedaTipoDocumento');
    var longitud = getValue('txtBusquedaNroDocumento').length;

    if (getValue('hidCodigoDocMigraYPasaporte').indexOf(strTipoDoc) > -1) {
        if (longitud < getValue('hidMinLengthDocMigratorios') || longitud > getValue('hidMaxLengthDocMigratorios')) {
            alert('Ingresar número de documento válido.');
            return false;
        }
    }
    //PROY 31636
			}
			
			//PROY 31636
			function validarPorTipoDoc(txtTipoDoc,strOpcion)
			{
				var strTipoDoc = (strOpcion=='01') ? getValue('ddlBusquedaTipoDocumento') : getValue('ddlTipoDocumento');
				if(getValue('hidCodigoDocMigraYPasaporte').indexOf(strTipoDoc) >-1)
				{
					return validaCaracteresNombres();
				}
				else
				{
					return f_EventoSoloNumeros();
				}
			}
			//PROY 31636
			
			function f_Limpiar()
			{
				setValue('txtBusquedaVigenciaInicio', '');
				setValue('txtBusquedaVigenciaFin', '');
				document.getElementById('<%=ddlBusquedaTipoDocumento.ClientId %>').selectedIndex = -1;
				setValue('txtBusquedaNroDocumento', '');
				document.getElementById('<%=ddlBusquedaCasoEspecial.ClientId %>').selectedIndex = -1;
				setValue('txtBusquedaFechaInicio', '');
				setValue('txtBusquedaFechaFin', '');	
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
			
			function f_ValidarNombre()
			{				
				if (getValue('txtNroDocumento').length == 0)
				{
					alert('Debe ingresar el nro de documento');
					//setFocus('txtNroDocumento');
					return false;
				}
				if (getValue('ddlTipoDocumento') == '01')
				{
					//isNaN(getValue('txtNroDocumento')) || 
					if (getValue('txtNroDocumento').length != 8)
					{
						alert('El dni debe tener 8 dígitos');
						//setFocus('txtNroDocumento');
						return false;					
					}
				}
				if (getValue('ddlTipoDocumento') == '04')
				{
					if (getValue('txtNroDocumento').length != 9)
					{
						alert('El ce debe tener 9 dígitos');
						//setFocus('txtNroDocumento');
						return false;						
					}
				}
				if (getValue('ddlTipoDocumento') == '06')
				{
					if (getValue('txtNroDocumento').length != 11)
					{
						alert('El ruc debe tener 11 dígitos');
						//setFocus('txtNroDocumento');
						return false;						
					}
				}
    //PROY 31636
    var strTipoDoc = getValue('ddlTipoDocumento');
    var longitud = getValue('txtNroDocumento').length;

    if (getValue('hidCodigoDocMigraYPasaporte').indexOf(strTipoDoc) > -1) {
        if (longitud < getValue('hidMinLengthDocMigratorios') || longitud > getValue('hidMaxLengthDocMigratorios') ) {
            alert('Ingresar número de documento válido.');
            return false;
        }
    }
    //PROY 31636

				return true;
			}			
			
			function f_ValidarGrabar()
			{	
				var booResultado;
				
				booResultado = f_ValidarNombre();
				
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
							de Whitelist de Caso Especial</td>
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
																Whitelist</td>
														</tr>
														<TR>
															<TD class="Arial10B">Tipo de Documento</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:dropdownlist id="ddlBusquedaTipoDocumento" runat="server" DESIGNTIMEDRAGDROP="614" Width="130px"
																	CssClass="clsSelectEnable">
																	<asp:ListItem Value="00">TODOS...</asp:ListItem>
																	<asp:ListItem Value="01">DNI</asp:ListItem>
																	<asp:ListItem Value="04">CE</asp:ListItem>
																	<asp:ListItem Value="06">RUC</asp:ListItem>
																	<asp:ListItem Value="07">PASAPORTE</asp:ListItem>
																	<asp:ListItem Value="11">CIRE</asp:ListItem>
																	<asp:ListItem Value="12">CIE</asp:ListItem>
																	<asp:ListItem Value="13">CPP</asp:ListItem>
																	<asp:ListItem Value="14">CTM</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD>&nbsp;</TD>
															<TD class="Arial10B">Nro. de Documento</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:textbox onkeypress="return validarPorTipoDoc(this,01);" onkeyup="this.value = this.value.toUpperCase();"
																	id="txtBusquedaNroDocumento" runat="server" DESIGNTIMEDRAGDROP="494" cssclass="clsInputEnable" width="100px"
																	MaxLength="15"></asp:textbox></TD>
														</TR>
														<tr>
															<TD class="Arial10B">Vigencia</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtBusquedaVigenciaInicio"
																				ondrop="return false;" runat="server" Width="50px" CssClass="clsInputEnable" MaxLength="5"></asp:textbox></TD>
																		<TD class="Arial10B">&nbsp;a&nbsp;</TD>
																		<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtBusquedaVigenciaFin"
																				ondrop="return false;" runat="server" Width="50px" CssClass="clsInputEnable" MaxLength="5"></asp:textbox></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B">
																Caso Especial</TD>
															<TD class="Arial10B">:</TD>
															<TD class="Arial10B"><asp:dropdownlist id="ddlBusquedaCasoEspecial" runat="server" Width="200px" CssClass="clsSelectEnable"></asp:dropdownlist></TD>
														</tr>
														<TR>
															<TD class="Arial10B">Fecha de Registro</TD>
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
															<TD class="Arial10B"></TD>
															<TD class="Arial10B"></TD>
															<TD class="Arial10B"></TD>
														</TR>
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
												<td colSpan="2"><asp:datagrid id="dgrGrillaDetalle" width="700px" runat="server" autogeneratecolumns="False" AllowPaging="True"
														DataKeyField="whln_secuencia">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "whln_secuencia")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar registro'> </a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="whlsv_casoespe" itemstyle-cssclass="Arial10B" HeaderText="CASO ESPECIAL">
																<itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whlsc_tipodocudesc" itemstyle-cssclass="Arial10B" HeaderText="TIPO DOC">
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whlv_nro_documento" itemstyle-cssclass="Arial10B" HeaderText="NRO DOC">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whln_vigencia" itemstyle-cssclass="Arial10B" HeaderText="VIGENCIA">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whln_cargo_fijo_max" itemstyle-cssclass="Arial10B" HeaderText="CARGO FIJO">
																<headerstyle horizontalalign="center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whlv_usuario_crea" itemstyle-cssclass="Arial10B" HeaderText="USUARIO CREA">
																<headerstyle horizontalalign="center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="whlv_fecha_registro" itemstyle-cssclass="Arial10B" HeaderText="FECHA REG">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
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
												<td class="header" colSpan="7" height="25">Detalle del Whitelist</td>
											</tr>
											<TR>
												<TD class="Arial10B">Tipo de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlTipoDocumento" runat="server" DESIGNTIMEDRAGDROP="869" Width="130px" CssClass="clsSelectEnable">
														<asp:ListItem Value="01">DNI</asp:ListItem>
														<asp:ListItem Value="04">CE</asp:ListItem>
														<asp:ListItem Value="06">RUC</asp:ListItem>
														<asp:ListItem Value="07">PASAPORTE</asp:ListItem>
														<asp:ListItem Value="11">CIRE</asp:ListItem>
														<asp:ListItem Value="12">CIE</asp:ListItem>
														<asp:ListItem Value="13">CPP</asp:ListItem>
														<asp:ListItem Value="14">CTM</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD>&nbsp;</TD>
												<TD class="Arial10B">Nro. de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeyup="this.value = this.value.toUpperCase();" onkeypress="return validarPorTipoDoc(this,02);"
														id="txtNroDocumento" runat="server" DESIGNTIMEDRAGDROP="1478" cssclass="clsInputEnable" width="100px" MaxLength="15"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="Arial10B">Vigencia</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtVigencia"
														ondrop="return false;" runat="server" cssclass="clsInputEnable" width="50px" MaxLength="5"></asp:textbox></TD>
												<TD></TD>
												<td class="Arial10B">Cargo Fijo Máximo</td>
												<td class="Arial10B">:</td>
												<td class="Arial10B"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtCargoFijoMaximo"
														ondrop="return false;" runat="server" cssclass="clsInputEnable" width="50px" MaxLength="5"></asp:textbox></td>
											</TR>
											<tr>
												<TD class="Arial10B">Caso Especial</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B">
													<asp:dropdownlist id="ddlCasoEspecial" runat="server" CssClass="clsSelectEnable" Width="200px" DESIGNTIMEDRAGDROP="117"></asp:dropdownlist></TD>
												<TD></TD>
												<TD class="Arial10B">Fecha Registro</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onpaste="return false;" id="txtFechaRegistro" ondrop="return false;" runat="server"
														cssclass="clsInputDisable" width="100px" ReadOnly="True"></asp:textbox></TD>
											</tr>
											<tr height="25">
												<td align="center" colSpan="7"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" DESIGNTIMEDRAGDROP="528" Width="126" CssClass="Boton" Height="19" Text="Aceptar"
														Runat="server"></asp:button>&nbsp;
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
												<TD class="Arial10B">Caso Especial :&nbsp;
													<asp:dropdownlist id="ddlCMCasoEspecial" runat="server" CssClass="clsSelectEnable" Width="200px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<td><INPUT class="boton" id="FileToUpload" style="WIDTH: 250px; HEIGHT: 19px" type="file" size="62"
														name="FileToUpload" runat="server">
													<asp:button id="btnCargar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" DESIGNTIMEDRAGDROP="340" Width="126" CssClass="Boton"
														Height="19" Text="Cargar" Runat="server"></asp:button></td>
											</TR>
										</table>
									</td>
								</tr>
							</table>
							<input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
							<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
							<input id="hidEliminar" type="hidden" name="hidEliminar" runat="server"> <input id="hidSecuencia" type="hidden" name="hidSecuencia" runat="server">
							<!--PROY 31636 RENTESEG Inicio-->
							<input id="hidCodigoDocMigraYPasaporte" type="hidden" runat="server" name="hidCodigoDocMigraYPasaporte">
							<input id="hidMinLengthDocMigratorios" type="hidden" runat="server" name="hidMinLengthDocMigratorios">
							<input id="hidMaxLengthDocMigratorios" type="hidden" runat="server" name="hidMaxLengthDocMigratorios">
			<!--PROY 31636 RENTESEG Fin-->
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
 
 
 
 
