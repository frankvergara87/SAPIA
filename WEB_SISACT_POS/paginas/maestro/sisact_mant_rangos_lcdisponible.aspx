<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_rangos_lcdisponible.aspx.vb" Inherits="sisact_mant_rangos_lcdisponible"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_rangos_lcdisponible</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
			
			function f_EventoSoloAlfanumericos()
			{
				code = window.event.keyCode;
									
				if (code == 32 || code == 44 || code == 46 || code == 47 || code == 60 || code == 61 || code == 62 ||
					(code > 47 && code < 58) ||
					(code > 64 && code < 91) ||
					(code > 96 && code < 123) ||
					code == 209 || code == 241 || code == 43  || code == 45)
					return true
				else
					return false;
			}
						
			function f_SeleccionarTodo(booSel)
			{
				var tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var chkFila;
				var hidBusqItemsSel = document.getElementById('hidBusqItemsSel');
				var hidCheckTotal = document.getElementById('hidCheckTotal');
				
				if (booSel)
				{
					hidBusqItemsSel.value = document.getElementById('hidBusqItems').value;
					hidCheckTotal.value = 'S';
				}
				else
				{
					hidBusqItemsSel.value = '';
					hidCheckTotal.value = '';
				}
				
				for (var i = 1; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					chkFila = fila.cells[7].getElementsByTagName("input")[0];
					chkFila.checked = booSel;
				}
			}
			
			function f_LlenarCheckXPagina()
			{
				var tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var chkFila;
				var strBusqItemsSel = document.getElementById('hidBusqItemsSel').value;
				var strCodigo;
				var chkTotalGrilla = document.getElementById('chkTotalGrilla');
				var strCheckTotal = document.getElementById('hidCheckTotal').value;
				
				for (var i = 1; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					chkFila = fila.cells[7].getElementsByTagName("input")[0];
					strCodigo = fila.cells[7].getElementsByTagName("input")[1].value;
					
					if (strBusqItemsSel.indexOf('[' + strCodigo + ']') > -1)
						chkFila.checked = true;
					else
						chkFila.checked = false;
				}
				
				if (strCheckTotal == 'S')
					chkTotalGrilla.checked = true;
				else
					chkTotalGrilla.checked = false;
					
				f_mostrarBotoneraListado();
			}
			
			function f_mostrarBotoneraListado()
			{
				var strBusqItems = document.getElementById('hidBusqItems').value;
				if (strBusqItems.length > 0)
					trBotonesListado.style.display = '';
				else
					trBotonesListado.style.display = 'none';
			}
			
			function f_Seleccionar(booSel, strCodigo)
			{
				var chkTotalGrilla = document.getElementById('chkTotalGrilla');
				var hidCheckTotal = document.getElementById('hidCheckTotal');
				var hidBusqItemsSel = document.getElementById('hidBusqItemsSel');
				var strBusqItemsSel = hidBusqItemsSel.value;
				chkTotalGrilla.checked = false;
				hidCheckTotal.value = '';
				
				if (!booSel)
					hidBusqItemsSel.value = strBusqItemsSel.replace('[' + strCodigo + ']', '');
				else
					hidBusqItemsSel.value += '[' + strCodigo + ']';
			}
			
			function f_MostrarTab(valor)
			{
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trEdicion', false);	
					
					f_mostrarBotoneraListado();
					
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
					setVisible('trBotonesListado', false);
					
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
					setVisible('trBotonesListado', false);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
				}
			}
			
			function f_Limpiar(esNuevo)
			{
				var ddlTipoDocumento = document.getElementById('<%=ddlTipoDocumento.ClientId %>');
				var ddlEstado = document.getElementById('<%=ddlEstado.ClientId %>');
				
				setValue('hidCodigo', '');
				ddlTipoDocumento.selectedIndex = 0;
				setValue('txtRangoInicial', '0');
				setValue('txtRangoFinal', '0');
				setValue('txtMensajeSISACT', '');
				setValue('txtMensajeSMS', '');
				ddlEstado.selectedIndex = 0;
				
				if (esNuevo)
				{
					ddlTipoDocumento.disabled = false;
					ddlEstado.disabled = true;
				}
				else
				{
					ddlTipoDocumento.disabled = true;
					ddlEstado.disabled = false;				
				}
			}
			
			function f_Agregar()
			{
				f_Limpiar(true);				
				f_MostrarTab('NUEVO');
			}
			
			function f_Modificar(strCodigo)
			{
				f_Limpiar(false);
				f_MostrarTab('EDICION');
				
				setValue('hidCodigo', strCodigo);
				
				var tabla = document.getElementById('<%=dgrGrillaDetalle.ClientId %>');
				var cont = tabla.rows.length;
				var fila;
				var strCodigoActual;
				var strTipoDocumento;
				var strEstado;
				var strRangoInicial;
				var strRangoFinal;
				var strMensajeSISACT;
				var strMensajeSMS;
				
				for (var i = 1; i < cont - 1; i++)
				{
					fila = tabla.rows[i];
					strCodigoActual = fila.cells[7].getElementsByTagName("input")[1].value;
					strTipoDocumento = fila.cells[7].getElementsByTagName("input")[2].value;
					strEstado = fila.cells[7].getElementsByTagName("input")[3].value;
					strMensajeSISACT = fila.cells[7].getElementsByTagName("input")[4].value;
					strMensajeSMS = fila.cells[7].getElementsByTagName("input")[5].value;
										
					strRangoInicial = fila.cells[2].innerHTML;
					strRangoFinal = fila.cells[3].innerHTML;

					if (strCodigo == strCodigoActual)
					{
						document.getElementById('<%=ddlTipoDocumento.ClientId %>').value = strTipoDocumento;
						document.getElementById('<%=ddlEstado.ClientId %>').value = strEstado;
						setValue('txtRangoInicial', strRangoInicial);
						setValue('txtRangoFinal', strRangoFinal);
						setValue('txtMensajeSISACT', strMensajeSISACT);
						setValue('txtMensajeSMS', strMensajeSMS);
					}
				}
			}
			
			function f_Aceptar()
			{
				if (getValue('txtRangoInicial').length == 0)
				{
					alert('Debe ingresar el rango inicial');
					return false;
				}
				if (getValue('txtRangoFinal').length == 0)
				{
					alert('Debe ingresar el rango final');
					return false;
				}
				
				if (parseFloat(getValue('txtRangoInicial')) > parseFloat(getValue('txtRangoFinal')))
				{
					alert('El rango inicial debe ser menor al rango final');
					return false;					
				}
				
				if (getValue('txtMensajeSISACT').length == 0)
				{
					alert('Debe ingresar el mensaje SISACT');
					return false;
				}
				if (getValue('txtMensajeSMS').length == 0)
				{
					alert('Debe ingresar el mensaje SMS');
					return false;
				}
				
				return true;		
			}
			
			function f_Cancelar()
			{
				f_MostrarTab('BUSQUEDA');				
			}
			
			function f_Activar()
			{
				var strActivar = document.getElementById('<%= btnActivar.ClientId %>').value;
				var strBusqItemsSel = getValue('hidBusqItemsSel');
				
				if (strBusqItemsSel.length == 0)
				{
					alert('Debe seleccionar al menos un registro para ' + strActivar);
					return false;
				}

				return true;
			}
			
			function f_Eliminar()
			{
				var strBusqItemsSel = getValue('hidBusqItemsSel');
				
				if (strBusqItemsSel.length == 0)
				{
					alert('Debe seleccionar al menos un registro para Eliminar');
					return false;
				}

				if (!confirm('¿Esta seguro de eliminar el(los) registro(s) seleccionado(s)?'))
					return false;

				return true;
			}
						
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Rangos para mostrar LC Disponible</td>
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
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:f_Agregar();">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122" style="display:none"><A href="javascript:void();">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="4">&nbsp;Busqueda de 
															Rango</td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 120px">&nbsp;Tipo de documento</td>
														<td style="WIDTH: 1px">:</td>
														<td style="WIDTH: 130px"><asp:dropdownlist id="ddlBusquedaTipoDocumento" runat="server" CssClass="clsSelectEnable" Width="130px">
																<asp:ListItem Value="00">TODOS...</asp:ListItem>
																<asp:ListItem Value="01|04">DNI/CE</asp:ListItem>
																<asp:ListItem Value="06">RUC</asp:ListItem>
															</asp:dropdownlist></td>
														<td><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Buscar"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 117px">&nbsp;Estado</td>
														<td style="WIDTH: 1px">:</td>
														<td style="WIDTH: 135px"><asp:dropdownlist id="ddlBusquedaEstado" CssClass="clsSelectEnable" Width="100px" Runat="server">
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
															</asp:dropdownlist></td>
														<td></td>
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
											<td><asp:datagrid id="dgrGrillaDetalle" runat="server" DataKeyField="RNG_CODIGO" AllowPaging="True"
													autogeneratecolumns="False">
													<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
													<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
													<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
													<columns>
														<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
															<itemstyle horizontalalign="Center"></itemstyle>
															<itemtemplate>
																<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "RNG_CODIGO")%>");'>
																	<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Rango'> </a>
															</itemtemplate>
														</asp:templatecolumn>
														<asp:boundcolumn datafield="TDOCV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="TIPO DE DOC.">
															<itemstyle wrap="False" width="100px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="RNG_MINIMO" itemstyle-cssclass="Arial10B" HeaderText="DESDE">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="RNG_MAXIMO" itemstyle-cssclass="Arial10B" HeaderText="HASTA">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="RNG_COMENTARIO" itemstyle-cssclass="Arial10B" HeaderText="MOSTRAR MENSAJE SISACT">
															<headerstyle horizontalalign="center"></headerstyle>
															<itemstyle wrap="False" width="250px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="RNG_TEXTO_SMS" itemstyle-cssclass="Arial10B" HeaderText="MOSTRAR MENSAJE SMS">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" width="250px"></itemstyle>
														</asp:boundcolumn>
														<asp:boundcolumn datafield="RNG_ESTADO_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="ESTADO">
															<headerstyle horizontalalign="Center"></headerstyle>
															<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
															<itemstyle horizontalalign="Center"></itemstyle>
															<HeaderTemplate>
																<input type="checkbox" name="chkTotalGrilla" id="chkTotalGrilla" onclick="f_SeleccionarTodo(this.checked)" />
															</HeaderTemplate>
															<itemtemplate>
																<input type="checkbox" name="chkFila" id="chkFila" onclick="f_Seleccionar(this.checked, <%# DataBinder.Eval(Container.DataItem, "RNG_CODIGO")%>)" />
																<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "RNG_CODIGO")%>" />
																<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "TDOCC_CODIGO")%>" />
																<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "RNG_ESTADO")%>" />
																<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "RNG_COMENTARIO")%>" />
																<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "RNG_TEXTO_SMS")%>" />
															</itemtemplate>
														</asp:templatecolumn>
													</columns>
													<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trBotonesListado" style="display:none">
								<td>
									<asp:button id="btnActivar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Activar"
										Height="19" DESIGNTIMEDRAGDROP="279"></asp:button>&nbsp;
									<asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Exportar"
										Height="19" DESIGNTIMEDRAGDROP="286"></asp:button>&nbsp;
									<asp:button id="btnEliminar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Eliminar"
										Height="19"></asp:button>								
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trEdicion" style="display:none">
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="header" colSpan="3" height="19">Detalle</td>
							</tr>
							<TR>
								<TD class="Arial10B" style="WIDTH: 150px">Tipo Documento(*)</TD>
								<TD class="Arial10B" style="WIDTH: 5px">:</TD>
								<TD class="Arial10B" style="WIDTH: 40px">
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" width="100px" cssclass="clsSelectEnable">
										<asp:ListItem Value="01">DNI/CE</asp:ListItem>
										<asp:ListItem Value="06">RUC</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr>
								<td class="Arial10B">Rango Inicial(*)</td>
								<td class="Arial10B">:</td>
								<td class="Arial10B"><asp:textbox id="txtRangoInicial" runat="server" width="100px" cssclass="clsInputEnable" maxlength="9"
										onkeypress="return OnKeyPressNumeros();" onpaste="return false;" ondrop="return false;"></asp:textbox></td>
							</tr>
							<TR>
								<TD class="Arial10B">Rango Final(*)</TD>
								<TD class="Arial10B">:</TD>
								<TD class="Arial10B"><asp:textbox id="txtRangoFinal" runat="server" width="100px" cssclass="clsInputEnable" maxlength="9"
										onkeypress="return OnKeyPressNumeros();" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Arial10B">Mostrar Mensaje SISACT(*)</TD>
								<TD class="Arial10B">:</TD>
								<TD class="Arial10B"><asp:textbox id="txtMensajeSISACT" runat="server" width="500px" cssclass="clsInputEnableB" maxlength="150"
										onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
							</TR>							
							<TR>
								<TD class="Arial10B">Mostrar Mensaje SMS(*)</TD>
								<TD class="Arial10B">:</TD>
								<TD class="Arial10B"><asp:textbox id="txtMensajeSMS" runat="server" width="500px" cssclass="clsInputEnableB" maxlength="150"
										onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" ondrop="return false;"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Arial10B">Estado(*)</TD>
								<TD class="Arial10B">:</TD>
								<TD class="Arial10B">
									<asp:dropdownlist id="ddlEstado" runat="server" width="100px" cssclass="clsSelectEnable">
										<asp:ListItem Value="1">ACTIVO</asp:ListItem>
										<asp:ListItem Value="0">INACTIVO</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr>
								<td colspan="3" align="center">
									<asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Aceptar"
										Height="19"></asp:button>&nbsp;
									<input type="button" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand; height: 19; width: 90"
										onmouseout="this.className='Boton';" class="Boton" value="Cancelar" onclick="f_Cancelar();" />
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidBusqItems" name="hidBusqItems" runat="server"> 
			<input type="hidden" id="hidBusqItemsSel" name="hidBusqItemsSel" runat="server">
			<input type="hidden" id="hidCheckTotal" name="hidCheckTotal" runat="server">
			<input type="hidden" id="hidCambiarEstado" name="hidCambiarEstado" runat="server">
			<input type="hidden" id="hidCodigo" name="hidCodigo" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
