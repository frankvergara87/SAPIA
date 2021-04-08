<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_planes.aspx.vb" Inherits="sisact_mant_planes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>sisact_mant_plan3play</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
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
					setVisible('trServicio', false);
					setVisible('trEquipo', false);
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='none';
//gaa20130724					
					document.getElementById('trSelEquipos').style.display='none';
					document.getElementById('trAceptar').style.display='none';
//fin gaa20130724
				}
				if (valor == 'NUEVO')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);	
//gaa20130724
					//setVisible('trServicio', true);
					document.getElementById('trSelEquipos').style.display='';
					document.getElementById('trAceptar').style.display='';
//fin gaa20130724					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
					
					//document.getElementById('txtCodigo').className='clsInputEnable';
					//document.getElementById('txtCodigo').readOnly=false;					
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);
//gaa20130724
					//setVisible('trServicio', true);
					document.getElementById('trSelEquipos').style.display='';
					document.getElementById('trAceptar').style.display='';
//fin gaa20130724
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
					
					//document.getElementById('txtCodigo').className='clsInputDisable';
					//document.getElementById('txtCodigo').readOnly=true;					
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
				if (getValue('txtMonto') == '')
				{
					//alert('Debe ingresar el precio'); 19/06/2013 DH
					//return false; 19/06/2013 DH
				}
				else
				{
					if (Number(getValue('txtMonto')) == 0)
					{
						alert('El precio debe ser mayor a 0');
						return false;
					}
				}
				if (getValue('txtCostoInstalacion') == '')
				{
					//alert('Debe ingresar el costo de instalación'); 19/06/2013 DH
					//return false; 19/06/2013 DH
				}
				else
				{
					if (Number(getValue('txtCostoInstalacion')) == 0)
					{
						alert('El costo de instalación debe ser mayor a 0');
						return false;
					}
				}
//gaa20130724
				return validarServiciosAdicionales();
				//return true;
//fin gaa20130724
				
			}
			
//gaa20130724			
			function validarServiciosAdicionales()
			{
				var tabla = document.getElementById('<%=dgrServicioAsociado.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var strGrupo;
				var strPadre;
				var strPadres = '';
				var strPrincipal;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					strPrincipal = fila.cells[4].getElementsByTagName("INPUT")[0].value;
					
					if (strPrincipal == 1)
					{
						strPadre = fila.cells[4].getElementsByTagName("INPUT")[2].value;
						
						if (strPadres.indexOf(strPadre) < 0)
							strPadres += ";" + strPadre;
					}
				}

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					strPrincipal = fila.cells[4].getElementsByTagName("INPUT")[0].value;
					
					if (strPrincipal == 0)
					{
						strPadre = fila.cells[4].getElementsByTagName("INPUT")[2].value;
						
						if (strPadres.indexOf(strPadre) < 0)
						{
							alert('No se pueden grabar servicios adicionales sin al menos un servicio principal');
							return false;
						}
					}
				}

				return true;				
			}
//fin gaa20130724
			
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
//gaa20130724
			function f_CheckAllEA(chk)
			{
				var frm = document.forms[0];                                                                                         
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkEA') != -1)
						e.checked= ChkState ;
				} 			
			}
			
			function f_CheckAllE(chk)
			{
				var frm = document.forms[0];                                                                                         
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkENA') != -1)
						e.checked= ChkState ;
				} 			
			}
//fin gaa20130724

			function f_MostrarServicios()
			{
				if (document.getElementById('trServicio').style.display == 'none')
				{
					document.getElementById('trServicio').style.display = 'inline';
				}
				else
					document.getElementById('trServicio').style.display = 'none';
					
				return false;
			}
			
			function f_MostrarEquipos()
			{
				if (document.getElementById('trEquipo').style.display == 'none')
				{
					document.getElementById('trEquipo').style.display = 'inline';
				}
				else
					document.getElementById('trEquipo').style.display = 'none';
					
				return false;
			}
			
			function cambiarValorDefecto(ddl)
			{
				var tabla = document.getElementById('<%=dgrServicioAsociado.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var ddlxDefecto;
				var id = ddl.id.split('_')[2];
//gaa20130724
				var grupoSeleccionado = '';
				var grupoActual;
//fin gaa20130724
				var valor = ddl.value;
				var grupo = document.getElementById('dgrServicioAsociado__' + id + '_hidPRINCIPAL').value;

				if (valor == '1' && grupo == '1')
				{
//gaa20130724				
					grupoSeleccionado = ddl.parentElement.parentElement.cells[2].innerHTML;
//fin gaa20130724					
					for (var i = 0; i < cont; i++)
					{
						fila = tabla.rows[i];
						ddlxDefecto = fila.cells[4].getElementsByTagName("select")[0];
//gaa20130724
						grupoActual = ddlxDefecto.parentElement.parentElement.cells[2].innerHTML;
//fin gaa20130724
//gaa20130724
						//if (ddlxDefecto.id != ddl.id)			
						if (ddlxDefecto.id != ddl.id && grupoSeleccionado == grupoActual) //fin gaa20130724
						{
							ddlxDefecto.value = '0';
						}
					}
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
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Paquete :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return validarSoloAlfanumerico();" id="txtBusDescripcion" onkeydown="javascript:f_ValidarEnter();"
																ondrop="return false;" runat="server" Width="350px" CssClass="clsInputEnable" MaxLength="100"></asp:textbox>&nbsp;&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="90" CssClass="Boton" Text="Buscar" Height="19"></asp:button>
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="90" CssClass="Boton" Text="Limpiar"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Estado :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlEstadoPlan3Play" Runat="server" Width="100px" CssClass="clsSelectEnable">
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
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" Width="700px" ShowHeader="True" AutoGenerateColumns="False">
													<Columns>
														<asp:BoundColumn HeaderText=" " HeaderStyle-Width="25px" ItemStyle-Width="25px">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos" Height="25"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CÓDIGO">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="40px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DESCRIPCIÓN">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="250px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="PRODUCTO">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="100px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="TIPO VENTA">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="80px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ESTADO">
															<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="80px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" " HeaderStyle-Width="25px" ItemStyle-Width="25px">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos" Height="25"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 710px">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" Width="700px" ShowHeader="False" AutoGenerateColumns="False"
														AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "PLNV_CODIGO")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="PLNV_CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="40px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PLNV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="TPROC_CODIGO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TPROV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="TVENC_CODIGO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TVENV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO_PLAN">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "PLNV_CODIGO")%>");'>
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
								<td align="right">
									<table cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="3" height="25">&nbsp;Detalle del Paquete</td>
										</tr>
										<tr style="DISPLAY: none">
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Código</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B"><asp:textbox onpaste="return false;" id="txtCodigo" runat="server" Width="75px" MaxLength="4"
													ReadOnly="True"></asp:textbox></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Descripción</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B"><asp:textbox onkeypress="return validarSoloAlfanumerico();" id="txtDescripcion"
													ondrop="return false;" runat="server" Width="350px" CssClass="clsInputEnable" MaxLength="100"></asp:textbox></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B"><asp:dropdownlist id="ddlEstado" runat="server" Width="120px" CssClass="clsSelectEnable" DESIGNTIMEDRAGDROP="3903"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px; HEIGHT: 19px">&nbsp;Tipo de Oferta</td>
											<td class="Arial10B" style="WIDTH: 5px; HEIGHT: 19px">:</td>
											<td class="Arial10B" style="HEIGHT: 19px"><asp:dropdownlist id="ddlTipoOferta" runat="server" Width="120px" CssClass="clsSelectEnable"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Plazo</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B"><asp:checkboxlist class="Arial10B" id="chkPlazo" runat="server" RepeatColumns="3"></asp:checkboxlist></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Plan BSCS</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B"><asp:dropdownlist id="ddlPlanBSCS" runat="server" Width="200px" CssClass="clsSelectEnable"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;</td>
											<td class="Arial10B" style="WIDTH: 5px">&nbsp;</td>
											<td class="Arial10B">&nbsp;</td>
										</tr>
									</table>
									<asp:button id="btnSeleccionarServicios" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Text="Seleccionar Servicios"
										Height="19" DESIGNTIMEDRAGDROP="308"></asp:button></td>
							</tr>
							<tr id="trServicio" style="DISPLAY: none">
								<td>
									<table>
										<tr>
											<td class="header" colSpan="5" height="25">Asociar Servicios</td>
										</tr>
										<tr>
											<td class="Arial10B" width="250">Servicios Asociados al Paquete</td>
											<td width="30"></td>
											<td class="Arial10B" width="350">Lista de Servicios Activos</td>
										</tr>
										<tr>
											<td class="Arial10B" style="VERTICAL-ALIGN: top">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:datagrid id="dgrServicioAsociadoCab" runat="server" ShowHeader="True" AutoGenerateColumns="False">
																<Columns>
																	<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																		<HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																		<HeaderTemplate>
																			<asp:CheckBox ID="chkTotalSD" runat="server" onclick="javascript:f_CheckAllSD(this);"></asp:CheckBox>
																		</HeaderTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="CÓDIGO" Visible="False">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="50px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="SERVICIO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="150px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="GRUPO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="150px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="CARGO FIJO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="50px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="DEFECTO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="55px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="SERV. OBLIGATORIO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="85px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="GRUPO PRINCIPAL" Visible="False">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="85px"></HeaderStyle>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 550px; HEIGHT: 350px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgrServicioAsociado" runat="server" ShowHeader="False" AutoGenerateColumns="False">
																	<AlternatingItemStyle BackColor="#dddee2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="chkSD" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="CODIGO_PLAN" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="CODIGO_SERVICIO" ItemStyle-CssClass="Arial10B" Visible="False">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION_SERVICIO" ItemStyle-CssClass="Arial10B">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="CODIGO_GRUPO_SERVICIO" ItemStyle-CssClass="Arial10B" Visible="False">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION_GRUPO_SERVICIO" ItemStyle-CssClass="Arial10B">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn HeaderStyle-Width="50px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemTemplate>
																				<asp:TextBox ID="txtCargoFijo" runat="server" Width="48px" CssClass="clsInputEnable" onkeypress="return fSoloMontos(event, this);"
																					onpaste="return false;" MaxLength="10" ondrop="return false;" style="TEXT-ALIGN:right"></asp:TextBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderStyle-Width="55px" ItemStyle-Width="55px" ItemStyle-HorizontalAlign="Center">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemTemplate>
																				<asp:DropDownList ID="ddlDefecto" runat="server" CssClass="clsSelectEnable" Width="50px" DESIGNTIMEDRAGDROP="3903"
																					DataMember="Defecto" onchange="cambiarValorDefecto(this);">
																					<asp:ListItem Value="1">Si</asp:ListItem>
																					<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
																				</asp:DropDownList>
																				<input id="hidPRINCIPAL" style="WIDTH: 1px; HEIGHT: 1px" value='<%# DataBinder.Eval(Container.DataItem, "GSRVC_PRINCIPAL")%>' type="hidden" size="1" name="hidDPCHN_CODIGO"
																				runat="server"><input id="hidGrupo" style="WIDTH: 1px; HEIGHT: 1px" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO_GRUPO_SERVICIO")%>' type="hidden" size="1" name="hidDPCHN_CODIGO"
																				runat="server"> <input id="hidGrupoPadre" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO_GRUPO_SERVICIO_PADRE")%>' type="hidden" name="hidGrupoPadre" runat="server" />
																				<input id="hidIdBSCS" value='<%# DataBinder.Eval(Container.DataItem, "SERVV_ID_BSCS")%>' type="hidden" name="hidIdBSCS" runat="server" />
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderStyle-Width="85px" ItemStyle-Width="85px" ItemStyle-HorizontalAlign="Center">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemTemplate>
																				<asp:DropDownList ID="ddlObligatorio" runat="server" CssClass="clsSelectEnable" Width="50px" DESIGNTIMEDRAGDROP="3903"
																					CommandName="Obligatorio">
																					<asp:ListItem Value="1">Si</asp:ListItem>
																					<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
																				</asp:DropDownList>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="CARGO_FIJO" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="DEFECTO" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="OBLIGATORIO" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="GSRVC_PRINCIPAL" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="CODIGO_GRUPO_SERVICIO_PADRE" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="SERVV_ID_BSCS" Visible="False"></asp:BoundColumn>
																	</Columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</td>
											<td align="center" width="40">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:button id="btnMaterialQuitar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="40" CssClass="Boton" Text=">>"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td><asp:button id="btnMaterialAgregar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="40" CssClass="Boton" Text="<<"
																Height="19"></asp:button></td>
													</tr>
												</table>
											</td>
											<td class="Arial10B" style="VERTICAL-ALIGN: top">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:datagrid id="dgrServicioCabecera" runat="server" ShowHeader="True" AutoGenerateColumns="False">
																<Columns>
																	<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																		<HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																		<HeaderTemplate>
																			<asp:CheckBox ID="chkTotalMD" runat="server" onclick="javascript:f_CheckAllMD(this);"></asp:CheckBox>
																		</HeaderTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="CÓDIGO" Visible="False">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="50px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="SERVICIO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="140px"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="GRUPO">
																		<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos" Width="140px"></HeaderStyle>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 330px; HEIGHT: 350px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgrServicioDetalle" runat="server" ShowHeader="False" AutoGenerateColumns="False">
																	<AlternatingItemStyle BackColor="#dddee2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="" HeaderStyle-Width="25px" ItemStyle-Width="25px">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="chkMD" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="CODIGO_SERVICIO" ItemStyle-CssClass="Arial10B" Visible="False">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION_SERVICIO" ItemStyle-CssClass="Arial10B">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="140px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="CODIGO_GRUPO_SERVICIO" ItemStyle-CssClass="Arial10B" Visible="false">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION_GRUPO_SERVICIO" ItemStyle-CssClass="Arial10B">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="140px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="GSRVC_PRINCIPAL" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="CODIGO_GRUPO_SERVICIO_PADRE" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="SERVV_ID_BSCS" Visible="False"></asp:BoundColumn>
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
							<tr id="trSelEquipos" style="DISPLAY: none">
								<td align="right" colSpan="5"><asp:button id="btnSeleccionarEquipos" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" Runat="server" Width="200px" CssClass="Boton" Text="Seleccionar Equipos - Alquiler"
										Height="19" DESIGNTIMEDRAGDROP="308"></asp:button></td>
							</tr>
							<tr id="trEquipo" style="DISPLAY: none">
								<td>
									<table>
										<tr>
											<td class="header" colSpan="3" height="25">Asociar Equipos en Alquiler</td>
										</tr>
										<TR>
											<td class="Arial10B" width="40%">Lista de Equipos Asociados al Paquete</td>
											<td width="10%"></td>
											<td class="Arial10B" width="50%">Lista de Equipos Activos</td>
										</TR>
										<tr>
											<td class="Arial10B" style="VERTICAL-ALIGN: top">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:datagrid id="dgrEquipoAsociadoCab" runat="server" ShowHeader="True" AutoGenerateColumns="False">
																<Columns>
																	<asp:TemplateColumn>
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Width="25px"></ItemStyle>
																		<HeaderTemplate>
																			<asp:CheckBox ID="chkTotalEA" runat="server" onclick="javascript:f_CheckAllEA(this);"></asp:CheckBox>
																		</HeaderTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="CODIGO">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="EQUIPO">
																		<HeaderStyle HorizontalAlign="Center" Width="350px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="PRECIO">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 550px; HEIGHT: 150px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgrEquipoAsociado" runat="server" ShowHeader="False" AutoGenerateColumns="False">
																	<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="25px"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="chkEA" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="CODIGO">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="350px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
																			<ItemTemplate>
																				<asp:TextBox ID="txtEquipoPrecio" runat="server" Width="48px" CssClass="clsInputEnable" onkeypress="return fSoloMontos(event, this);"
																					onpaste="return false;" MaxLength="8" ondrop="return false;" style="TEXT-ALIGN:right"></asp:TextBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="PRECIO" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="PRECIO_BASE" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="SERVV_ID_BSCS" Visible="False"></asp:BoundColumn>
																	</Columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</td>
											<td align="center">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:button id="btnEquipoQuitar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="40" CssClass="Boton" Text=">>"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<td height="5"></td>
													</tr>
													<tr>
														<td><asp:button id="btnEquipoAgregar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" runat="server" Width="40" CssClass="Boton" Text="<<"
																Height="19"></asp:button></td>
													</tr>
												</table>
											</td>
											<td class="Arial10B" style="VERTICAL-ALIGN: top">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:datagrid id="dgrEquipoCab" runat="server" ShowHeader="True" AutoGenerateColumns="False">
																<Columns>
																	<asp:TemplateColumn>
																		<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Width="25px"></ItemStyle>
																		<HeaderTemplate>
																			<asp:CheckBox ID="chkTotalE" runat="server" onclick="javascript:f_CheckAllE(this);"></asp:CheckBox>
																		</HeaderTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn Visible="False" HeaderText="C&#211;DIGO">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="CODIGO">
																		<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="EQUIPO">
																		<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 330px; HEIGHT: 150px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgrEquipo" runat="server" ShowHeader="False" AutoGenerateColumns="False">
																	<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="25px"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="chkENA" runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="CODIGO">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="DESCRIPCION">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="PRECIO_BASE" Visible="False"></asp:BoundColumn>
																		<asp:BoundColumn DataField="SERVV_ID_BSCS" Visible="False"></asp:BoundColumn>
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
							<tr id="trAceptar" vAlign="bottom" height="30" sryle="display:none">
								<td align="center" colSpan="3"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" runat="server" Width="126" CssClass="Boton" Text="Aceptar" Height="19"></asp:button>&nbsp;
									<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" runat="server" Width="126" CssClass="Boton" Text="Cancelar"
										Height="19"></asp:button></td>
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
			<input id="hidTelefoniaFija" type="hidden" name="hidTelefoniaFija" runat="server">
			<input id="hidInternetFijo" type="hidden" name="hidInternetFijo" runat="server">
			<input id="hidClaroTvDigital" type="hidden" name="hidClaroTvDigital" runat="server">
			<input id="hidClaroTvAnalogico" type="hidden" name="hidClaroTvAnalogico" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
