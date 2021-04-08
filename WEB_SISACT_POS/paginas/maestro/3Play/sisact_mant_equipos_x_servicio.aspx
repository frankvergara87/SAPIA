<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_equipos_x_servicio.aspx.vb" Inherits="sisact_mant_equipos_x_servicio"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_equipos_x_servicio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="JavaScript" src="../../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">	
			function f_Inicio()
			{				
				f_MostrarTab('BUSQUEDA');
			}			
			function f_Buscar()
			{					
				if (getValue('ddlBusqueda') == '0' && getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar una Descripción');
					return false;
				}
				Anthem_InvokePageMethod('BuscarAnthem',null,null);
				f_MostrarTab('BUSQUEDA');
			}
			function f_Limpiar()
			{
				setValue('txtBusDescripcion', '');		
				Anthem_InvokePageMethod('LimpiarDatosAnthem',null,null);			
			}
			//ldrz
function f_Modificar(cod,codprod)
			{
			    setValue('hidCodigo',cod)
			    setValue('hidProducto',codprod)
				Anthem_InvokePageMethod('ModificarAnthem',[cod,codprod],null);
				f_MostrarTab('EDICION');
			}			
			function f_Eliminar(cod)
			{
			    var strMensaje="";
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
				    setValue('hidCodigo',cod)
				    Anthem_InvokePageMethod('EliminarAnthem',[cod],
				    function(result) 
                    {
                        f_Buscar();
                        alert(result.value);
                    }
				    );				    
				}
			}		
			function f_Aceptar(){
			
				if (!f_ValidarGrabar())
					return false;
					
				var tablaMA = document.getElementById('dgrMADetalle');
				var hidEquipos = document.getElementById('hidEquipos');
				hidEquipos.value = "";
				var fila;
				if (tablaMA == null){
					return false;
				}
				var totalLineas = tablaMA.rows.length - 1;
				if (totalLineas + 1 > 0){
					for (var i = 0; i <= totalLineas; i++) {
						fila = tablaMA.rows[i];
						hidEquipos.value += fila.cells[1].innerHTML + ';' + fila.cells[2].innerHTML + ';' + fila.cells[3].getElementsByTagName("input")[0].value + '|';
					} 				
				}
				
				if (getValue('hidEquipos') == '')
				{
					alert('Selecione al menos un equipo.');
					return false;
				}
				
				if (!confirm('¿Desea guardar los cambios?'))
					return false;
					
				Anthem_InvokePageMethod('AceptarAnthem',[hidEquipos.value],
				    function(result) 
                    {
                        f_Buscar();
                        alert(result.value);		
                    }
                    );  
			}					
			function f_Cancelar()
			{			
				f_MostrarTab('BUSQUEDA');                
			}	
			function f_ValidarGrabar()			
			{	
				if (getValue('ddlGrupo') == '')
				{
					alert('Debe seleccionar Grupo.');
					setFocus('ddlGrupo');
					return false;
				}		
				if (getValue('ddlServicio') == '')
				{
					alert('Debe seleccionar Descripción.');
					setFocus('ddlServicio');
					return false;
				}
					
				if (getValue('ddlEstado') == '')
				{
					alert('Debe seleccionar Estado.');
					setFocus('ddlDescripcion');
					return false;
				}				
				return true;	
			}						
			function f_InactivarTxtLista()
			{
				txtBusDescripcion = document.getElementById('<%=txtBusDescripcion.ClientId%>');
				//txtBusDescripcion.value = '';
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
						
						f_InactivarTxtLista();
						
						Anthem_InvokePageMethod('LimpiarRegistroAnthem',null,null);							
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
						
						setValue('hidCodigo','')
						
						Anthem_InvokePageMethod('LimpiarRegistroAnthem',null,null);	
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
			function fAsociar()
			{	
				var tablaMD = document.getElementById('dgrMDDetalle');
				var tablaMA = document.getElementById('dgrMADetalle');
				var hidMoverItem = document.getElementById('hidMoverItem');
				var fila;
				var totalLineas = tablaMD.rows.length - 1;
				var filaNueva;
				var chk;
				var idequipo;
				var equipo;
				var cantidad;
				var cant=0;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaMD.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						filaNueva = tablaMA.insertRow(0);
						chk = filaNueva.insertCell(0);
						idequipo = filaNueva.insertCell(1);
						equipo = filaNueva.insertCell(2);
						cantidad = filaNueva.insertCell(3);
						
						chk.innerHTML = "<input type='checkbox' id='chkMA' name='chkMA'/>";
						idequipo.innerHTML = fila.cells[1].innerHTML;
						equipo.innerHTML = fila.cells[2].innerHTML;
						cantidad.innerHTML = "<input type='text' id='txtCant' name='txtCant' value='1' class='Arial10B' size='1' style='TEXT-ALIGN: right' onkeypress='return f_EventoSoloNumerosEnteros();' onpaste='return false;' MaxLength='2' ondrop='return false;' onblur='return f_ValidaCantidad(this);'/>";
						
						idequipo.className = 'Arial10B';
						equipo.className = 'Arial10B';
						cantidad.className = 'Arial10B';
						
						idequipo.style.width = '71px';
						equipo.style.width = '201px';
						cantidad.style.width = '71px';
						
						idequipo.style.textAlign = 'center';
						equipo.style.textAlign = 'center';
						cantidad.style.textAlign = 'center';					
						
						tablaMD.deleteRow(i);
						i--;
						totalLineas--;

					}
				} 
				document.getElementById('dgrMDCabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			function fQuitar()
			{
				var tablaMD = document.getElementById('dgrMDDetalle');
				var tablaMA = document.getElementById('dgrMADetalle');
				var hidMoverItem = document.getElementById('hidMoverItem');
				var fila;
				var totalLineas = tablaMA.rows.length - 1;
				var filaNueva;
				var chk;
				var idequipo;
				var equipo;
			
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaMA.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						filaNueva = tablaMD.insertRow(0);
						chk = filaNueva.insertCell(0);
						idequipo = filaNueva.insertCell(1);
						equipo = filaNueva.insertCell(2);

						chk.innerHTML = "<input type='checkbox' id='chkMD' name='chkMD'/>";
						idequipo.innerHTML = fila.cells[1].innerHTML;
						equipo.innerHTML = fila.cells[2].innerHTML;

						idequipo.className = 'Arial10B';
						equipo.className = 'Arial10B';
						
						idequipo.style.width = '71px';
						equipo.style.width = '201px';
						
						idequipo.style.textAlign = 'center';
						equipo.style.textAlign = 'center';

						tablaMA.deleteRow(i);
						i--;
						totalLineas--;

					}
				}
				document.getElementById('dgrMACabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						Anthem_InvokePageMethod('BuscarAnthem',null,null);
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
	<body onkeydown="cancelarBackSpace();" MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<INPUT id="hidProducto" type="hidden" name="hidProducto" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Equipos&nbsp;x Servicios</td>
				</tr>
				<tr>
					<td class="contenido">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('NUEVO');">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:void(0);">Modificar</A>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Servicio</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px" vAlign="top"><table style="HEIGHT: 26px" cellSpacing="1" cellPadding="0" width="100%" border="0">
																<tr>
																	<td class="Arial10B" style="HEIGHT: 9px">&nbsp;Producto:</td>
																	<td class="Arial10B" style="HEIGHT: 9px"></td>
																	<td class="Arial10B" style="HEIGHT: 9px" align="left"><anthem:dropdownlist id="ddlProductoBuscar" runat="server" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True"
																			UpdateAfterCallBack="True" cssclass="clsSelectEnable" width="224px"></anthem:dropdownlist></td>
																</tr>
																<tr>
																	<td class="Arial10B" style="HEIGHT: 29px">&nbsp;Equipo:</td>
																	<td class="Arial10B" style="HEIGHT: 29px"></td>
																	<td class="Arial10B" style="HEIGHT: 29px" align="left"><asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																			<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																			<asp:ListItem Value="1">TODOS</asp:ListItem>
																		</asp:dropdownlist>&nbsp;<asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtBusDescripcion"
																			onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" Width="300px" CssClass="clsInputEnable"
																			MaxLength="100"></asp:textbox>
																		&nbsp;<input class="Boton" id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																			onclick="f_Buscar();" onmouseout="this.className='Boton';" type="button" value="Buscar" width="90"
																			height="19"> &nbsp;<input class="Boton" id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																			onclick="f_Limpiar();" onmouseout="this.className='Boton';" type="button" value="Limpiar" width="90" height="19">
																	</td>
																</tr>
																<tr>
																	<td class="Arial10B">&nbsp;Estado:</td>
																	<td class="Arial10B"></td>
																	<td class="Arial10B" align="left"><anthem:dropdownlist id="ddlEstadoBuscar" runat="server" cssclass="clsSelectEnable" width="100px"></anthem:dropdownlist></td>
																</tr>
															</table>
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
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><anthem:datagrid id="dgrGrillaCabecera" runat="server" UpdateAfterCallBack="True" width="648px" autogeneratecolumns="False">
													<Columns>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO">
															<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="SERVICIO">
															<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="EQUIPO">
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
												</anthem:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 656px; HEIGHT: 344px">
										<table cellSpacing="0" cellPadding="0" width="648" border="0">
											<tr>
												<td><anthem:datagrid id="dgrGrillaDetalle" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"
														width="630px" autogeneratecolumns="False" showheader="False" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>,<%# DataBinder.Eval(Container.DataItem, "PRDC_CODIGO")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="65px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="IDSERVICIO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="1px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="SERVICIO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="235px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="IDEQUIPO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="1px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EQUIPO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="225px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="65px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="PRDC_CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="1px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>");'>
																		<img src="../../../images/ico_Eliminar.gif" border="0" alt='Desactivar Equipo'></a>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</anthem:datagrid><anthem:label id="lblMensaje" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Runat="server">No se han encontrado registros</anthem:label></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr id="trEdicion">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" colSpan="4" height="25">Detalle del Equipo por Servicio</td>
													</tr>
													<tr>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 90px; HEIGHT: 8px">&nbsp;Producto</td>
														<td class="Arial10B" style="WIDTH: 5px; HEIGHT: 8px">:</td>
														<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 8px"><anthem:dropdownlist id="ddlProducto" runat="server" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True"
																UpdateAfterCallBack="True" cssclass="clsSelectEnable" width="224px"></anthem:dropdownlist></td>
														<td class="Arial10B" style="HEIGHT: 8px"></td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 90px; HEIGHT: 8px">&nbsp;Grupo</td>
														<td class="Arial10B" style="WIDTH: 5px; HEIGHT: 8px">:</td>
														<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 8px"><anthem:dropdownlist id="ddlGrupo" runat="server" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True"
																UpdateAfterCallBack="True" cssclass="clsSelectEnable" width="224px"></anthem:dropdownlist></td>
														<td class="Arial10B" style="HEIGHT: 8px"></td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 90px; HEIGHT: 17px">&nbsp;Descripción</td>
														<td class="Arial10B" style="WIDTH: 5px; HEIGHT: 17px">:</td>
														<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 17px"><anthem:dropdownlist id="ddlServicio" runat="server" AutoCallBack="True" AutoPostBack="True" AutoUpdateAfterCallBack="True"
																UpdateAfterCallBack="True" cssclass="clsSelectEnable" width="224px"></anthem:dropdownlist></td>
														<td class="Arial10B" style="HEIGHT: 17px"></td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 90px">&nbsp;Estado</td>
														<td class="Arial10B" style="WIDTH: 5px">:</td>
														<td class="Arial10B" style="WIDTH: 40px"><anthem:dropdownlist id="ddlEstado" runat="server" AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True"
																cssclass="clsSelectEnable" width="112px"></anthem:dropdownlist></td>
														<td class="Arial10B"></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="Arial10B" style="HEIGHT: 15px" width="48%">Materiales asociados al 
															Servicio</td>
														<td class="Arial10B" style="HEIGHT: 15px" width="4%"></td>
														<td class="Arial10B" style="HEIGHT: 15px" width="48%">Lista de materiales activos</td>
													</tr>
													<tr>
														<td>
															<table id="tblMaterialAsociado" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><anthem:datagrid id="dgrMACabecera" runat="server" UpdateAfterCallBack="True" autogeneratecolumns="False">
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																					<ItemStyle Width="25px"></ItemStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalOA" Runat="server" onclick="javascript:f_CheckAll('MA',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="C&Oacute;DIGO">
																					<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="DESCRIPCI&Oacute;N">
																					<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="CANTIDAD">
																					<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</anthem:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 400px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><anthem:datagrid id="dgrMADetalle" runat="server" UpdateAfterCallBack="True" autogeneratecolumns="False"
																				showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkMA" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="IDEQUIPO">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="EQUIPO">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="CANT_EQUIPO">
																						<ItemStyle Wrap="False" HorizontalAlign="Center" CssClass="Arial10B" Width="60px"></ItemStyle>
																						<ItemTemplate>
																							<input type='text' id='txtCant' value='<%# DataBinder.Eval(Container,"DataItem.CANT_EQUIPO") %>' size ="1" Class="Arial10B" style="TEXT-ALIGN: right" onkeypress="return f_EventoSoloNumerosEnteros();" onpaste="return false;" MaxLength="2" ondrop="return false;" onblur="return f_ValidaCantidad(this);">
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																			</anthem:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><INPUT class="Boton" id="hbtAsociar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 18px"
																			onclick="fAsociar();" onmouseout="this.className='Boton';" type="button" value="<<"
																			name="hbtAsociarOficina">
																	</td>
																</tr>
																<tr>
																	<td height="10"></td>
																</tr>
																<tr>
																	<td><input class="Boton" id="hbtQuitar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 18px"
																			onclick="fQuitar();" onmouseout="this.className='Boton';" type="button" value=">>"
																			name="hbtQuitarOficina">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table id="tblMaterialDisponible" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><anthem:datagrid id="dgrMDCabecera" runat="server" UpdateAfterCallBack="True" autogeneratecolumns="False">
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																					<ItemStyle Width="25px"></ItemStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalMD" Runat="server" onclick="javascript:f_CheckAll('MD',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="C&Oacute;DIGO">
																					<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="DESCRIPCI&Oacute;N">
																					<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="TablaTitulos"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</anthem:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 365px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><anthem:datagrid id="dgrMDDetalle" runat="server" UpdateAfterCallBack="True" autogeneratecolumns="False"
																				showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkMD" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="MATV_CODIGO">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="MATV_DESCRIPCION">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</anthem:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr height="25">
											<td align="center"><input class="Boton" id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onclick="f_Aceptar();" onmouseout="this.className='Boton';" type="button" value="Aceptar" Width="126"
													Height="19"> &nbsp;<input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onclick="f_Cancelar();" onmouseout="this.className='Boton';" type="button" value="Cancelar" width="126" height="19">
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hidCodigo" type="hidden" name="hidCodigo" runat="server"> <input id="hidEquipos" type="hidden" name="hidEquipos" runat="server">
			<input id="hidMoverItem" type="hidden" name="hidMoverItem" runat="server">
		</form>
	</body>
</HTML>
