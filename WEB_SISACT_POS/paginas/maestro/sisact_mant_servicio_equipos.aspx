<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_servicio_equipos.aspx.vb" Inherits="sisact_mant_servicio_equipos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_servicio_equipos</title>
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
			
			function f_Modificar(cod)
			{
				setValue('hidServCodigo',cod);
				__doPostBack('btnModificar','');
			}
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
					setValue('hidServCodigo',cod);
					__doPostBack('btnEliminar','');
				}
			}
			
			function f_Inicio()
			{				
				f_MostrarTab('BUSQUEDA');
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
			
			function fAsociarOficina()
			{	
				var tablaOD = document.getElementById('dgrODDetalle');
				var tablaOA = document.getElementById('dgrOADetalle');
				var hidMoverItem = document.getElementById('hidMoverItem');
				//var hidOfiDescrips = document.getElementById('hidOfiDescrips');
				//var hidOfiTipos = document.getElementById('hidOfiTipos');
				var fila;
				var totalLineas = tablaOD.rows.length - 1;
				var filaNueva;
				var chk;
				var iddet;
				var idlinea;
				var idequipo;
				var equipo;
				var cantidad;
				var cant=0;
				
				/*if (hidMoverItem.value == 'NO'){
					return false;
				}*/
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaOD.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Asociados
						filaNueva = tablaOA.insertRow(0);
						chk = filaNueva.insertCell(0);
						iddet = filaNueva.insertCell(1);
						idlinea = filaNueva.insertCell(2);
						idequipo = filaNueva.insertCell(3);
						equipo = filaNueva.insertCell(4);
						cantidad = filaNueva.insertCell(5);
						//Inserto valores en fila nueva de Asociados
						chk.innerHTML = "<input type='checkbox' id='chkOA' name='chkOA'/>";
						iddet.innerHTML = fila.cells[1].innerHTML;
						idlinea.innerHTML = fila.cells[2].innerHTML;
						idequipo.innerHTML = fila.cells[3].innerHTML;
						equipo.innerHTML = fila.cells[4].innerHTML;
						cantidad.innerHTML = "<input type='text' id='txtCant' name='txtCant' value='1' class='Arial10B' size='1' style='TEXT-ALIGN: right' onkeypress='return f_EventoSoloNumerosEnteros();' onpaste='return false;' MaxLength='2' ondrop='return false;' onblur='return f_ValidaCantidad(this);'/>";
						//Asignando estilos a las celdas de la nueva fila de Asociados
						iddet.className = 'Arial10B';
						idlinea.className = 'Arial10B';
						idequipo.className = 'Arial10B';
						equipo.className = 'Arial10B';
						cantidad.className = 'Arial10B';
						
						iddet.style.width = '71px';
						idlinea.style.width = '71px';
						idequipo.style.width = '71px';
						equipo.style.width = '71px';
						cantidad.style.width = '71px';
						
						iddet.style.textAlign = 'center';
						idlinea.style.textAlign = 'center';
						idequipo.style.textAlign = 'center';
						equipo.style.textAlign = 'center';
						cantidad.style.textAlign = 'center';					
						
						//Elimino fila de Disponibles
						tablaOD.deleteRow(i);
						i--;
						totalLineas--;
						//hidEquipos.value += idequipo.innerHTML + '|';
						//idOfiDescrips.value += descripcion.innerHTML + '|';
						//hidOfiTipos.value += oficina.innerHTML + '|';
					}
				} 
				//Quitar check en cabecera de Disponibles
				document.getElementById('dgrODCabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function fQuitarOficina()
			{
				var tablaOD = document.getElementById('dgrODDetalle');
				var tablaOA = document.getElementById('dgrOADetalle');
				var hidMoverItem = document.getElementById('hidMoverItem');
				//var hidOfiDescrips = document.getElementById('hidOfiDescrips');
				//var hidOfiTipos = document.getElementById('hidOfiTipos');				
				var fila;
				var totalLineas = tablaOA.rows.length - 1;
				var filaNueva;
				var chk;
				var iddet;
				var idlinea;
				var idequipo;
				var equipo;


				/*if (hidMoverItem.value == 'NO'){
					return false;
				}*/
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaOA.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Disponibles
						filaNueva = tablaOD.insertRow(0);
						chk = filaNueva.insertCell(0);
						iddet = filaNueva.insertCell(1);
						idlinea = filaNueva.insertCell(2);
						idequipo = filaNueva.insertCell(3);
						equipo = filaNueva.insertCell(4);
						//Inserto valores en fila nueva de Disponibles
						chk.innerHTML = "<input type='checkbox' id='chkOD' name='chkOD'/>";
						iddet.innerHTML = fila.cells[1].innerHTML;
						idlinea.innerHTML = fila.cells[2].innerHTML;
						idequipo.innerHTML = fila.cells[3].innerHTML;
						equipo.innerHTML = fila.cells[4].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						iddet.className = 'Arial10B';
						idlinea.className = 'Arial10B';
						idequipo.className = 'Arial10B';
						equipo.className = 'Arial10B';
						
						iddet.style.width = '71px';
						idlinea.style.width = '71px';
						idequipo.style.width = '71px';
						equipo.style.width = '71px';
						
						iddet.style.textAlign = 'center';
						idlinea.style.textAlign = 'center';
						idequipo.style.textAlign = 'center';
						equipo.style.textAlign = 'center';
						//Elimino fila de Disponibles
						tablaOA.deleteRow(i);
						i--;
						totalLineas--;
						//hidPDVs.value = hidPDVs.value.replace((idequipo.innerHTML + '|'), '');
						//hidOfiDescrips.value = hidOfiDescrips.value.replace((descripcion.innerHTML + '|'), '');
						//hidOfiTipos.value = hidOfiTipos.value.replace((oficina.innerHTML + '|'), '');
					}
				}
				//Quitar check en cabecera de Asociados
				document.getElementById('dgrOACabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function grabar(){
			
				if (!f_ValidarGrabar())
					return false;
					
				if (!confirm('¿Desea guardar los cambios?'))
					return false;
					
				var tablaOA = document.getElementById('dgrOADetalle');
				var hidEquipos = document.getElementById('hidEquipos');
				var fila;
				if (tablaOA == null){
					return false;
				}
				var totalLineas = tablaOA.rows.length - 1;
				if (totalLineas + 1 > 0){
					for (var i = 0; i <= totalLineas; i++) {
						fila = tablaOA.rows[i];
						hidEquipos.value += fila.cells[3].innerHTML + ';' + fila.cells[4].innerHTML + ';' + fila.cells[5].getElementsByTagName("input")[0].value + '|';
					} 				
				}
				
				if (getValue('hidServCodigo') == '' && getValue('hidEquipos') == '')
				{
					alert('Selecione al menos un equipo.');
					return false;
				}			
			
			}
			
			function f_ValidarGrabar()			
			{	
				if (getValue('ddlSolucion') == '-1')
				{
					alert('Debe seleccionar la Solución.');
					setFocus('ddlSolucion');
					return false;
				}
				
				if (getValue('ddlPaquete') == '-1')
				{
					alert('Debe seleccionar el Paquete.');
					setFocus('ddlPaquete');
					return false;
				}
				if (getValue('ddlProducto') == '-1')
				{
					alert('Debe seleccionar el Producto.');
					setFocus('ddlProducto');
					return false;
				}
				if (getValue('ddlServicio') == '-1')
				{
					alert('Debe seleccionar el Servicio.');
					setFocus('ddlServicio');
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
			
			function f_ValidaCantidad(oTxt){
				if(oTxt.value == '0'){
					alert('Ingrese una cantidad mayor a cero.');
					oTxt.focus();
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						Servicio&nbsp;x equipos HFC</td>
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
															Kit</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" Width="300px" CssClass="clsInputEnable"
																MaxLength="100"></asp:textbox>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="648px" autogeneratecolumns="False">
													<Columns>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO">
															<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DESCRIPCI&#211;N">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="SERVICIO">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ESTADO">
															<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 656px; HEIGHT: 344px">
										<table cellSpacing="0" cellPadding="0" width="630" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="630px" autogeneratecolumns="False" showheader="False"
														AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "codigo")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="codigo">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="idpaquete">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="1px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="paquete">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="230px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Idservicio">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="1px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="servicio">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="230px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="estado">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "codigo")%>");'>
																		<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Equipo'></a>
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
											<td class="header" colSpan="6" height="25">Detalle Distribuidor</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px; HEIGHT: 18px">Solución</td>
											<td class="Arial10B" style="WIDTH: 5px; HEIGHT: 18px">:</td>
											<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 18px"><asp:dropdownlist id="ddlSolucion" runat="server" width="224px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></td>
											<TD class="Arial10B" style="HEIGHT: 18px"></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Paquete</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlPaquete" runat="server" width="224px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></td>
											<TD class="Arial10B"></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Producto</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlProducto" runat="server" width="224px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">Servicio</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlServicio" runat="server" width="224px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></td>
											<TD class="Arial10B"></TD>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">Estado</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="112px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="Arial10B"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px"></TD>
											<TD class="Arial10B" style="WIDTH: 5px"></TD>
											<TD class="Arial10B" style="WIDTH: 40px"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" colSpan="6">
												<table id="tblPV" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="Arial10B" width="45%">Lista de Equipos Activos x Producto</td>
														<td class="Arial10B" width="10%"></td>
														<td class="Arial10B" width="45%">Asociación Servicio x Equipos</td>
													</tr>
													<tr>
														<td>
															<table id="tblOficinaDisponible" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrODCabecera" runat="server" autogeneratecolumns="False">
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																					<ItemStyle Width="25px"></ItemStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalOD" Runat="server" onclick="javascript:f_CheckAll('OD',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="IDET">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="IDLINEA">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="COD. EQUIPO">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="EQUIPO">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 365px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrODDetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkOD" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="IDDET">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="IdLinea">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="IdEquipo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Equipo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><INPUT class="Boton" id="hbtAsociarOficina" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fAsociarOficina();" onmouseout="this.className='Boton';"
																			type="button" value=">>" name="hbtAsociarOficina">
																	</td>
																</tr>
																<tr>
																	<td height="19"></td>
																</tr>
																<tr>
																	<td><input class="Boton" id="hbtQuitarOficina" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fQuitarOficina();" onmouseout="this.className='Boton';"
																			type="button" value="<<" name="hbtQuitarOficina">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table id="tblOficinaAsociada" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrOACabecera" runat="server" autogeneratecolumns="False">
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																					<ItemStyle Width="25px"></ItemStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalOA" Runat="server" onclick="javascript:f_CheckAll('OA',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="IDET">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="IDLINEA">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="COD. EQUIPO">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="EQUIPO">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="CANTIDAD">
																					<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 400px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrOADetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkOA" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="IDDET">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="IdLinea">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="IdEquipo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Equipo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="cant_equipo">
																						<ItemStyle Wrap="False" HorizontalAlign="Center" CssClass="Arial10B" Width="90px"></ItemStyle>
																						<ItemTemplate>
																						<input type='text' id='txtCant' value='<%# DataBinder.Eval(Container,"DataItem.cant_equipo") %>' size ="1" Class="Arial10B" style="TEXT-ALIGN: right" onkeypress="return f_EventoSoloNumerosEnteros();" onpaste="return false;" MaxLength="2" ondrop="return false;" onblur="return f_ValidaCantidad(this);">
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Aceptar" DESIGNTIMEDRAGDROP="2054"></asp:button>&nbsp;
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
			<input id="hidEquipos" type="hidden" name="hidEquipos" runat="server"> <input id="hidServCodigo" type="hidden" name="hidServCodigo" runat="server">
			<input id="hidMoverItem" type="hidden" runat="server" NAME="hidMoverItem">
		</form>
	</body>
</HTML>
 
 
 
 
