<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_campana.aspx.vb" Inherits="sisact_mant_campana" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_campana</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script src="../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript">
				
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
			
			function f_validarNumeros()
			{
				if (getValue('ddlBusqueda') == 'D') 
					return f_EventoSoloNumerosEnteros();
			}
			
			function f_InactivarTxtLista()
			{
				txtBus = document.getElementById('<%=txtBus.ClientId%>');
			
				if (getValue('ddlBusqueda') == 'T')
				{
					txtBus.readOnly = true;
					txtBus.className = 'clsInputDisable';
					//txtBusDescripcion.value = '';
				}
				else
				{
					txtBus.readOnly = false;
					txtBus.className = 'clsInputEnable';
					txtBus.focus();
					
					if (getValue('ddlBusqueda') == 'D') 
					{
						document.getElementById('txtBus').onkeypress = function() { f_validarNumeros() };
						txtBus.maxLength = 8;						
					}
					else
					{
						document.getElementById('txtBus').onkeypress = function() { validaCaracteres() };	
						txtBus.maxLength = 30;
					}
				}
			}
			
			function f_Buscar()
			{					
				if (getValue('ddlBusqueda') == 'P' && getValue('txtBus') == '')
				{
					alert('Debe ingresar el producto.');
					return false;
				}
				if (getValue('ddlBusqueda') == 'N' && getValue('txtBus') == '')
				{
					alert('Debe ingresar el nombre.');
					return false;
				}				
				if (getValue('ddlBusqueda') == 'C' && getValue('txtBus') == '')
				{
					alert('Debe ingresar la fecha.');
					return false;
				}				
				if (getValue('ddlBusqueda') == 'F' && getValue('txtBus') == '')
				{
					alert('Debe ingresar la fecha.');
					return false;
				}				
				if (getValue('ddlBusqueda') == 'C' && isDate(getValue('txtBus')) == false)
				{
					alert('Debe ingresar correctamente la fecha.');
					return false;
				}				
				if (getValue('ddlBusqueda') == 'F' && isDate(getValue('txtBus')) == false)
				{
					alert('Debe ingresar correctamente la fecha.');
					return false;
				}				
				return true;
			}
			
			function f_Limpiar()
			{
				setValue('txtBus', '');
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						//f_Buscar();
						document.getElementById('<%=btnBuscar.ClientId%>').click;
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
					var txtDescripcion = document.getElementById('<%=txtDescripcion.ClientId%>');
					txtDescripcion.readOnly = false;
					
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);
					
					setVisible('trEstado', false);
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
					document.getElementById('btnFechaInicio').style.display='inline';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);
					
					setVisible('trEstado', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
					document.getElementById('btnFechaInicio').style.display='none';
					
				}
			}
			
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
				f_InactivarTxtLista();
			}
			
			function f_Modificar(cod)
			{
				setValue('hidCodigo',cod);
				__doPostBack('btnModificar','');
			}
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de inactivar este registro?'))
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
				if (getValue('ddlProductoPadre') == '-1')
				{
					alert('Debe seleccionar el tipo de producto padre');
					return false;
				}
				if (getValue('ddlProductoHija') == '-1')
				{
					alert('Debe seleccionar el tipo de producto hijo');
					return false;
				}
				if (getValue('ddlCampanaPadre') == null)
				{
					alert('Debe seleccionar la campaña padre');
					return false;
				}
				if (getValue('ddlCampanaHija') == null)
				{
					alert('Debe seleccionar la campaña hija');
					return false;
				}
				if (getValue('txtDescripcion') == '')
				{
					alert('Debe ingresar la descripcion');
					return false;
				}
							
				if (getValue('txtFechaInicio') == '')
				{
					alert('Debe ingresar la fecha de inicio');
					return false;
				}
				
				if (getValue('txtFechaFin') == '')
				{
					alert('Debe ingresar la fecha de fin');
					return false;
				}
				
				if (Date.parse(getValue('txtFechaInicio')) > Date.parse(getValue('txtFechaFin')))
				{
					alert('La fecha de inicio es mayor que la fecha de fin');
					return false;
				}
								
				return true;
			}
			
			function validaCaracteres() {
				var CaracteresPermitidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz_ +1234567890/";
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++)
				{
					if (key == valid.substring(i,i+1))
						ok = "yes";
				}
				if (ok == "no")
					window.event.keyCode=0;

				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}
			
			function isDate(value) {
				try {
					//Change the below values to determine which format of date you wish to check. It is set to dd/mm/yyyy by default.
					var DayIndex = 0;
					var MonthIndex = 1;
					var YearIndex = 2;
			 
					value = value.replace(/-/g, "/").replace(/\./g, "/"); 
					var SplitValue = value.split("/");
					var OK = true;
					if (!(SplitValue[DayIndex].length == 1 || SplitValue[DayIndex].length == 2)) {
						OK = false;
					}
					if (OK && !(SplitValue[MonthIndex].length == 1 || SplitValue[MonthIndex].length == 2)) {
						OK = false;
					}
					if (OK && SplitValue[YearIndex].length != 4) {
						OK = false;
					}
					if (OK) {
						var Day = parseInt(SplitValue[DayIndex], 10);
						var Month = parseInt(SplitValue[MonthIndex], 10);
						var Year = parseInt(SplitValue[YearIndex], 10);
			 
						if (OK = ((Year > 1900) )) {
							if (OK = (Month <= 12 && Month > 0)) {
								var LeapYear = (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0));
			 
								if (Month == 2) {
									OK = LeapYear ? Day <= 29 : Day <= 28;
								}
								else {
									if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11)) {
										OK = (Day > 0 && Day <= 30);
									}
									else {
										OK = (Day > 0 && Day <= 31);
									}
								}
							}
						}
					}
					return OK;
				}
				catch (e) {
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Campana</td>
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
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:__doPostBack('btnAgregar','');">Asociar</A></td>
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
															Campana</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="P" Selected="True">PRODUCTO</asp:ListItem>
																<asp:ListItem Value="C">FECHA DE CREACION</asp:ListItem>
																<asp:ListItem Value="F">FECHA DE FIN</asp:ListItem>
																<asp:ListItem Value="N">NOMBRE</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox id="txtBus" runat="server" Width="300px" CssClass="clsInputEnable" MaxLength="30"></asp:textbox>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="720px" autogeneratecolumns="False"
													showheader="True">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CODIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="DESCRIPCION">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CAMPANA PADRE">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CAMPANA HIJA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA INICIO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA FIN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
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
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 720px; HEIGHT: 924px">
										<table cellSpacing="0" cellPadding="0" width="630" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="440px" autogeneratecolumns="False" showheader="False"
														PageSize="30" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="23px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "COD_ASOCIACION")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Campana'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="COD_ASOCIACION" DataFormatString="{0}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="77px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="144px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CAMPANA_PADRE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="131px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CAMPANA_HIJA">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="135px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FECHA_INICIO" DataFormatString="{0:dd/MM/yyyy}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="58px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FECHA_FIN" DataFormatString="{0:dd/MM/yyyy}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="58px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="28px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="28px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "COD_ASOCIACION")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Campana'></a>
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
											<td class="header" colSpan="6" height="25">Detalle de la Campana</td>
										</tr>
										<tr>
											<td class="Arial10B" colSpan="3" height="25">Detalle de la Campana Padre</td>
											<td class="Arial10B" colSpan="3" height="25">Detalle de la Campana Hija</td>
										</tr>
										<TR id="trProducto">
											<td colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 19px">Producto:</TD>
														<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 19px"></TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px"><asp:dropdownlist id="ddlProductoPadre" runat="server" width="200px" cssclass="clsSelectEnable" AutoPostBack="True">
															</asp:dropdownlist></TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</tr>
												</table>
											</td>
											<td colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 19px">Producto:</TD>
														<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 19px"></TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px"><asp:dropdownlist id="ddlProductoHija" runat="server" width="200px" cssclass="clsSelectEnable" AutoPostBack="True">
															</asp:dropdownlist></TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</tr>
												</table>
											</td>
										</TR>
										<TR id="trCampana">
											<td colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 19px">Campaña Padre:</TD>
														<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 19px"></TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px"><asp:dropdownlist id="ddlCampanaPadre" runat="server" width="200px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</tr>
												</table>
											</td>
											<td colSpan="3">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 19px">Campaña Hija:</TD>
														<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 19px"></TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px"><asp:dropdownlist id="ddlCampanaHija" runat="server" width="200px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</tr>
												</table>
											</td>
										</TR>
										<tr>
											<td class="Arial10B" style="HEIGHT: 14px" colSpan="3">Descripcion de la asociación:</td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 40px" colSpan="3">
												<P><asp:textbox onkeypress="validaCaracteres();" onpaste="return false;" id="txtDescripcion" runat="server"
														Height="40px" width="328px" cssclass="clsInputEnable" maxlength="200" Rows="2"></asp:textbox>&nbsp;</P>
											</TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 13px">Vigencia:</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 13px"></TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<TABLE cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD class="Arial10B"><asp:textbox id="txtFechaInicio" runat="server" CssClass="clsInputDisable" Width="80px" ReadOnly="True"></asp:textbox></TD>
														<TD class="Arial10B"><IMG id="btnFechaInicio" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																src="../../images/calendario.gif" border="0">
															<script type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtFechaInicio",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnFechaInicio",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
															</script>
														</TD>
														<TD class="Arial10B">&nbsp;al&nbsp;</TD>
														<TD class="Arial10B"><asp:textbox id="txtFechaFin" runat="server" CssClass="clsInputDisable" Width="80px" ReadOnly="True"></asp:textbox></TD>
														<TD class="Arial10B"><IMG id="btnFechaFin" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																src="../../images/calendario.gif" border="0">
															<script type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtFechaFin",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnFechaFin",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
															</script>
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="Arial10B" colSpan="2" style="HEIGHT: 13px"></TD>
										</TR>
										<TR id="trEstado">
											<TD class="Arial10B" style="WIDTH: 120px">Estado:</TD>
											<TD class="Arial10B" style="WIDTH: 5px"></TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="200px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">Activo</asp:ListItem>
													<asp:ListItem Value="0">Inactivo</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="5"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Grabar"></asp:button>&nbsp;
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
		</form>
	</body>
</HTML>
 
 
 
 
