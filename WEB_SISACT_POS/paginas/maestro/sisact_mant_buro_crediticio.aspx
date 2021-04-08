<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_buro_crediticio.aspx.vb" Inherits="sisact_mant_buro_crediticio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_buro_crediticio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
			function f_Buscar()
			{					
				if (getValue('ddlBusqueda') == 'N' && getValue('txtBuro') == '')
				{
					alert('Debe ingresar el nombre.');
					setFocus('txtBuro');
					return false;
				}
				return true;
			}
			
			function f_Limpiar()
			{
				setValue('txtBuro', '');
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						document.getElementById('<%=btnBuscar.ClientId%>').click;
						event.keyCode = 0;
					}
				}
			}
			
			function f_MostrarTab(valor)
			{
				if (valor == 'INICIO')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', false);	
					setVisible('trBotones', false);	
					setVisible('trEdicion', false);	

					document.getElementById('ddlBusqueda').value = 'T';
					f_CambiarBusqueda(true);
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdModificar').style.display = 'none';
				}			
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trBotones', true);	
					setVisible('trEdicion', false);	
					f_CambiarEstado();
					
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdModificar').style.display = 'none';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);
					setVisible('trBotones', false);	
					setVisible('trEdicion', true);
					
					document.getElementById('tdListado').className = 'tab_inactivo';
					document.getElementById('tdModificar').style.display = 'inline';
					document.getElementById('tdModificar').className = 'tab_activo';
				}
			}
		
			function f_Modificar(cod)
			{
				setValue('hidCodigo', cod);
				__doPostBack('btnModificar', '');
			}
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de inactivar este registro?'))
				{
					setValue('hidCodigo', cod);
					__doPostBack('btnEliminar', '');
				}
			}
			
			function f_eliminarSeleccionados()
			{
				if (!f_ValidarEliminar()) {
					alert('Debe seleccionar al menos un registro.')
					return false;
				}
				var msg;
				if (getValue('hidAccion') == 'D')
					msg = '¿Desea desactivar estos registros?';
				else
					msg = '¿Desea activar estos registros?';
					
				if (confirm(msg))
					return true;
				else
					return false;
			}

			function f_ValidarEliminar()
			{
				var tabla = document.getElementById('dgrGrillaDetalle');
				var nroFilas = tabla.rows.length;
				var id, ctl;
				var blnCheck = false;
				for (var i = 0; i < nroFilas; i++)
				{				
					id = "dgrGrillaDetalle__ctl" + (i+2) + "_fila";
					ctl = document.getElementById(id);
					
					if (ctl != null) {
						if (ctl.checked) {
							blnCheck = true;
							break;
						}
					}		
				}
				
				return blnCheck;
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

			function f_CambiarBusqueda(blnLimpiar)
			{
				var txtBuro = document.getElementById('<%=txtBuro.ClientId%>');
				if (blnLimpiar)
					txtBuro.value = '';
				if (getValue('ddlBusqueda') == 'T') 
				{
					txtBuro.readOnly = true;
					txtBuro.className = 'clsInputDisable';
				}
				else
				{		
					txtBuro.readOnly = false;
					txtBuro.className = 'clsInputEnable';
					txtBuro.focus();
				}
			}

			function f_CambiarEstado()
			{
				if (getValue('ddlEstado') == '1') {
					document.getElementById('btnAccion').value = 'Desactivar';
					document.getElementById('hidAccion').value = 'D';
				} else {
					document.getElementById('btnAccion').value = 'Activar';
					document.getElementById('hidAccion').value = 'A';
				}
			}

			function f_ValidarGrabar()
			{
				if (!validarControl('txtNombreBuro', '', 'Debe ingresar nombre del Buro.')) return false;
				if (!validarControl('txtDescripcionBuro', '', 'Debe ingresar descripción del Buro.')) return false;
	
				return true;
			}
			
			function f_BloquearBackSpace()
			{
				if ((event.keyCode == 8 || (event.keyCode == 37 && event.altKey) || (event.keyCode == 39 && event.altKey))
					&& (event.srcElement.form == null || (event.srcElement.isTextEdit == false && !event.srcElement.readOnly)))
				{
					event.cancelBubble = true;
					event.returnValue = false;
				}
			}
		</script>
	</HEAD>
	<body onkeydown="f_BloquearBackSpace();" MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Buros Crediticios</td>
				</tr>
				<tr>
					<td class="contenido">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%">
							<tr>
								<td>
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" border="0" width="100%">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');f_CambiarBusqueda(false);">Listado</A></td>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"
															style="DISPLAY:none"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('EDICION');">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="4">&nbsp;Busqueda de 
															Buros Crediticios</td>
													</tr>
													<tr>
														<td class="Arial10B" width="100">&nbsp;Buro :</td>
														<td width="150">
															<asp:dropdownlist id="ddlBusqueda" CssClass="clsSelectEnable" Runat="server" Width="120px">
																<asp:ListItem Value="T">TODOS</asp:ListItem>
																<asp:ListItem Value="N">NOMBRE</asp:ListItem>
															</asp:dropdownlist>
														</td>
														<td class="Arial10B" width="305"><asp:textbox id="txtBuro" runat="server" CssClass="clsInputEnable" Width="300px" MaxLength="30"
																onkeypress="validaCaracterNombre();"></asp:textbox></td>
														<td>
															<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Buscar"
																Height="19"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Limpiar"
																Height="19"></asp:button>
														</td>
													</tr>
													<tr>
														<td class="Arial10B" width="100">&nbsp;Documento :</td>
														<td width="150">
															<asp:dropdownlist id="ddlDocumento" CssClass="clsSelectEnable" Runat="server" Width="120px">
																<asp:ListItem Value="05">DNI / CE</asp:ListItem>
																<asp:ListItem Value="06">RUC</asp:ListItem>
															</asp:dropdownlist></td>
														<td colspan="4" class="Arial10B" style="HEIGHT: 26px">Estado : 
															&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:dropdownlist id="ddlEstado" CssClass="clsSelectEnable" Runat="server" Width="100px">
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
															</asp:dropdownlist></td>
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
											<td colspan="2">
												<asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" showheader="True"
													AllowPaging="False" DataKeyField="codigo">
													<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
													<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
													<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
													<columns>
														<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
															<itemstyle horizontalalign="Center"></itemstyle>
															<itemtemplate>
																<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "codigo")%>");'>
																	<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Buro'> </a>
															</itemtemplate>
														</asp:templatecolumn>
														<asp:boundcolumn datafield="NOMBRE" itemstyle-cssclass="Arial10B" HeaderText="NOMBRE DE BURO">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Center" width="200px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="DESCRIPCION">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Left" width="250px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="DOCUMENTO" itemstyle-cssclass="Arial10B" HeaderText="DOCUMENTO">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="ESTADO" itemstyle-cssclass="Arial10B" HeaderText="ESTADO">
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
												</asp:datagrid>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trBotones">
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td>
												<asp:button id="btnAccion" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Width="135" CssClass="Boton" Height="19" Text="Desactivar"
													Runat="server"></asp:button>
											</td>
											<td align="right"><asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Width="126" CssClass="Boton" Height="19" Text="Exportar" Runat="server"></asp:button>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trEdicion">
								<td>
									<table cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">&nbsp;Detalle</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Código</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px">
												<asp:textbox id="txtCodigo" runat="server" onpaste="return false;" MaxLength="8" width="50px"
													cssclass="clsInputDisable" DESIGNTIMEDRAGDROP="1754" ReadOnly></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Nombre de Buro</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox id="txtNombreBuro" runat="server" width="250px" onkeypress="validaCaracterNombre();"
													onpaste="return false;" cssclass="clsInputEnable" maxlength="50"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Descripción Buro</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px">
												<asp:textbox id="txtDescripcionBuro" runat="server" width="250px" onkeypress="validaCaracterNombre();"
													onpaste="return false;" cssclass="clsInputEnable" maxlength="100" DESIGNTIMEDRAGDROP="1425"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Documento</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px">
												<asp:dropdownlist id="ddlDocumentoEdit" runat="server" width="120px" cssclass="clsSelectEnable">
													<asp:ListItem Value="05">DNI / CE</asp:ListItem>
													<asp:ListItem Value="06">RUC</asp:ListItem>
												</asp:dropdownlist>
											</td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstadoEdit" runat="server" width="120px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr height="25">
											<td align="center" colSpan="5">
												<asp:Button CssClass="Boton" id="btnAceptar" Runat="server" onmouseover="this.className='BotonResaltado';"
													style="CURSOR: hand" onmouseout="this.className='Boton';" Text="Aceptar" Width="126" Height="19"></asp:Button>&nbsp;
												<asp:Button CssClass="Boton" id="btnCancelar" Runat="server" onmouseover="this.className='BotonResaltado';"
													style="CURSOR: hand" onmouseout="this.className='Boton';" Text="Cancelar" Width="126" Height="19"></asp:Button>
											</td>
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
			<input id="hidCodigo" type="hidden" runat="server">
			<input id="hidAccion" type="hidden" runat="server" name="hidAccion">
		</form>
	</body>
</HTML>
 
 
 
 
