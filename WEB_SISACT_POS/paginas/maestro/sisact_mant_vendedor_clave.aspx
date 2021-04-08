<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_vendedor_clave.aspx.vb" Inherits="sisact_mant_vendedor_clave" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SISACT Mantenimiento de Claves de Vendedores</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/lib_funcvalidacion.js"></script>
		<script language="JavaScript" src="../../librerias/DATE-PICKER.JS"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script type="text/javascript">
				
			function inicio(){
				var sProceso = getValue('hidProceso');
								
				if(sProceso == 'GenerarClave'){
					setVisible('trClaveGenerar', false);
					setVisible('trClaveAceptar', true);
					f_OpenGenerar(getValue('txtNombreUsuario'), getValue('txtDniUsuario'));
				}else if(sProceso == 'GenerarClave'){					
					setValue('hidProceso', 'Buscar');
					alert(getValue('hidErrorMensaje'));
				}
			}
						
			function cambiarEstado(){
				if(getValue('ddlBusqueda')=='0' || getValue('ddlBusqueda')=='5'){					
					document.getElementById('txtBusUsuario').className='clsInputEnable';
					document.frmPrincipal.txtBusUsuario.readOnly=false;					
				}else if(getValue('ddlBusqueda')=='1'){
					setValue('txtBusUsuario','');
					document.getElementById('txtBusUsuario').className='clsInputDisable';
					document.frmPrincipal.txtBusUsuario.readOnly=true;
				}else if(getValue('ddlBusqueda')=='2'){
					document.getElementById('txtBusUsuario').className='clsInputEnable';
					document.frmPrincipal.txtBusUsuario.readOnly=false;
				}
			}
			
			function f_Buscar(limpiar){
				if (limpiar == true){ 
					setValue('txtBusUsuario','');					
				}
				if (getValue('ddlBusqueda')=='0' && getValue('txtBusUsuario')==''){
					alert('Debe ingresar un Nombre o Apellido');
					return;
				}					
				if (getValue('ddlBusqueda')=='2' && getValue('txtBusUsuario')==''){
					alert('Debe ingresar DNI');
					return;
				}
				setValue('hidProceso','Buscar');
				document.frmPrincipal.submit();	
			}
			
			function f_OpenGenerar(nombre, nroDocumento){
				setVisible('updateClaveShadow', true);
				setVisible('updateClaveContent', true);
				setValue('txtNombreUsuario', nombre);
				setValue('txtDniUsuario', nroDocumento);					
			}
			
			function f_CerrarGenerar(){
				setVisible('trClaveGenerar', true);
				setVisible('trClaveAceptar', false);
				
				setVisible('updateClaveShadow', false);
				setVisible('updateClaveContent', false);
				setValue('txtNombreUsuario', '');
				setValue('txtDniUsuario', '');
				setValue('txtClaveGen', '');
			}
			
			function f_GenerarClave(){
				setValue('hidProceso','GenerarClave');
				document.frmPrincipal.submit();
			}
			
			function f_GuardarClave(){
				setValue('hidProceso','GuardarClave');
				document.frmPrincipal.submit();
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						f_Buscar(false);	
						event.keyCode = 0;
					}
				}	
			}
		</script>
	</HEAD>
	<body style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px"
		onload="inicio()">
		<div id="updateClaveShadow" style="DISPLAY: none; Z-INDEX: 5; FILTER: alpha(opacity=45); WIDTH: 100%; POSITION: absolute; HEIGHT: 100%; BACKGROUND-COLOR: darkgray; opacity: 0.45"></div>
		<form id="frmPrincipal" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px"
			method="post" runat="server">
			<div id="updateClaveContent" style="MARGIN-TOP: -89px; DISPLAY: none; Z-INDEX: 9; LEFT: 50%; MARGIN-LEFT: -121px; POSITION: absolute; TOP: 50%">
				<table class="contenido">
					<tr>
						<td class="header" style="TEXT-ALIGN: center" colSpan="2">Autenticación Usuario
						</td>
					</tr>
					<tr>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:label id="Label3" runat="server">Usuario</asp:label></td>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:textbox id="txtNombreUsuario" runat="server" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:label id="Label1" runat="server">DNI</asp:label></td>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:textbox id="txtDniUsuario" runat="server" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:label id="Label2" runat="server">Clave</asp:label></td>
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"><asp:textbox id="txtClaveGen" runat="server" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr id="trClaveGenerar">
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"
							align="center" colSpan="2"><input class="Boton" id="generarGenerar" onclick="javascript:f_GenerarClave();" type="button"
								value="Generar"> <input class="Boton" onclick="javascript:f_CerrarGenerar();" type="button" value="Cancelar">
						</td>
					</tr>
					<tr id="trClaveAceptar" style="DISPLAY: none">
						<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px"
							align="center" colSpan="2"><input class="Boton" id="aceptarGenerar" onclick="javascript:f_GuardarClave();" type="button"
								value="Aceptar"> <input class="Boton" onclick="javascript:f_CerrarGenerar();" type="button" value="Cancelar">
						</td>
					</tr>
				</table>
			</div>
			<table class="contenido" id="tblUsuario" style="Z-INDEX: 1; LEFT: 1px; WIDTH: 690px; POSITION: absolute; TOP: 1px"
				cellSpacing="0" cellPadding="0" border="0">
				<tr id="trTitulo">
					<td class="header" style="WIDTH: 100%; HEIGHT: 23px" align="center"><asp:label id="lblTipoMant" runat="server" text="">Mantenimiento de Clave Vendedores</asp:label></td>
				</tr>
				<tr>
					<td style="WIDTH: 980px">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td height="5"></td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><IMG height="2" src="../../spacer.gif" width="2">
											</td>
											<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:mostrarTabVisible('Listado');">Listado</A>
											</td>
											<td><IMG height="2" src="../../spacer.gif" width="2">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trBusqueda">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" style="WIDTH: 100%; HEIGHT: 20px" colSpan="2" height="20">&nbsp;Busqueda 
												de Usuarios
											</td>
										</tr>
										<tr>
											<td class="Arial10B" style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" onclick="cambiarEstado();" runat="server" cssclass="clsSelectEnable"></asp:dropdownlist>
												&nbsp;<asp:textbox id="txtBusUsuario" onkeydown="javascript:f_ValidarEnter();" runat="server" cssclass="clsInputEnable"
													width="400px"></asp:textbox>&nbsp;<input class="Boton" id="btnBuscar" onclick="f_Buscar(false)" type="button" value="Buscar"
													name="btnBuscar">&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trUsuario">
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><asp:datagrid id="dgCabUsuario" runat="server" width="735px" showheader="True" autogeneratecolumns="False">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="NOMBRES Y APELLIDOS" headerstyle-width="310px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="310px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="DNI" headerstyle-width="75px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="75px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CELULAR" headerstyle-width="75px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="75px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA ACTUALIZACION" headerstyle-width="200px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="180px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO" headerstyle-width="70px">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="70px"></headerstyle>
														</asp:templatecolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divUsuario" style="WIDTH: 800px">
										<table cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td><asp:datagrid id="dgUsuario" runat="server" autogeneratecolumns="False" ShowHeader="false">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_OpenGenerar("<%# DataBinder.Eval(Container.DataItem, "Nombre")%>", "<%# DataBinder.Eval(Container.DataItem, "NumeroDocumento")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Usuario'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Nombre" headertext="NOMBRES Y APELLIDOS">
																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="298px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NumeroDocumento" headertext="DNI">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="73px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NumeroCelular" headertext="CELULAR">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="74px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FechaModificacion" headertext="FECHA ACTUALIZACION">
																<ItemStyle Wrap="False" HorizontalAlign="Right" Width="176px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EstadoId" headertext="ESTADO">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="69px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
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
			</table>
			<input id="hidErrorMensaje" type="hidden" name="hidErrorMensaje" runat="server">
			<input id="hidProceso" type="hidden" name="hidProceso" runat="server"> <input id="hidMostrar" type="hidden" name="hidMostrar" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
