<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_motivos_linea_desactiva.aspx.vb" Inherits="sisact_mant_motivos_linea_desactiva" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_motivos_linea_desactiva</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		
			function f_MostrarTab(valor)
			{
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trEdicion', false);	
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trEdicion', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
				}
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
			
			function f_Modificar(obj)
			{
				var id = obj.parentNode.parentNode.rowIndex;
				var tabla = document.getElementById('<%=dgrListado.ClientId %>');
				var fila;
				
				fila = tabla.rows[id];
				setValue('txtCodigo', fila.cells[1].innerHTML);
				setValue('txtDescripcion', fila.cells[2].innerHTML);
				setValue('txtMotivo', fila.cells[3].innerHTML);
				setValue('txtRecomendacion', fila.cells[4].innerHTML.replace('&nbsp;', ''));
				setValue('ddlEstado', fila.cells[6].getElementsByTagName("input")[0].value);
				setValue('txtMesesDesactiva', fila.cells[6].getElementsByTagName("input")[1].value);
				setValue('txtMesesActiva', fila.cells[6].getElementsByTagName("input")[2].value);
				
				f_MostrarTab('EDICION');
			}
			
			function f_Limpiar()
			{
				setValue('txtCodigo', '');
				setValue('txtDescripcion', '');
				setValue('txtMotivo', '');
				setValue('txtRecomendacion', '');
				setValue('ddlEstado', '');
				setValue('txtMesesDesactiva', '');
				setValue('txtMesesActiva', '');
			}
			
			function f_Cancelar()
			{
				f_Limpiar();
				f_MostrarTab('BUSQUEDA')
			}
			
			function f_Desactivar(codigo)
			{
				if (confirm('¿Está seguro de desactivar este registro?'))
				{			
					setValue('hidCodigo', codigo);
					__doPostBack('btnDesactivar', '');
				}
			}
			
			function f_Aceptar()
			{
				if (getValue('txtMesesDesactiva') == '')
				{
					alert('Debe ingresar los meses de desactivación');
					return false;	
				}
				
				if (!confirm('¿Desea guardar los cambios?'))
					return false;
			}
					
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">MANTENIMIENTO 
						DE MOTIVOS DE LINEAS DESACTIVAS</td>
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
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122">
															<A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"
															style="DISPLAY:none">
															<A href="javascript:void(0)">Modificar</A>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Listado de 
															Motivos de Lineas Desactivas</td>
													</tr>
													<tr>
														<TD>
															<asp:datagrid id="dgrListado" runat="server" autogeneratecolumns="False" width="700px" AllowPaging="False">
																<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																<Columns>
																	<asp:TemplateColumn>
																		<HeaderStyle Width="25px" cssclass="TablaTitulos" height="25"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																		<ItemTemplate>
																				<img src="../../images/btn_edit.jpg" border="0" alt='Modificar' onclick="f_Modificar(this);" style="cursor:hand">
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="MOLDN_CODIGO" HeaderText="CODIGO">
																		<HeaderStyle HorizontalAlign="Center" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="MOLDV_DESCRIPCION" HeaderText="TIPO LÍNEAS DESACTIVAS">
																		<HeaderStyle HorizontalAlign="Center" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Wrap="False" Width="250px" CssClass="Arial10B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="MOLDV_MOTIVO" HeaderText="MOTIVO">
																		<HeaderStyle HorizontalAlign="Center" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Wrap="False" Width="250px" CssClass="Arial10B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="MOLDV_RECOMENDACION" HeaderText="RECOMENDACIÓN">
																		<HeaderStyle HorizontalAlign="Center" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Wrap="False" Width="250px" CssClass="Arial10B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="ESTADO_DESCRIP" HeaderText="ESTADO">
																		<HeaderStyle HorizontalAlign="Center" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:TemplateColumn>
																		<HeaderStyle Width="25px" cssclass="TablaTitulos"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																		<ItemTemplate>
																			<a href='javascript:f_Desactivar("<%# DataBinder.Eval(Container.DataItem, "MOLDN_CODIGO")%>");'>
																				<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar'></a>
																			<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "MOLDC_ESTADO")%>" />
																			<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "MOLDN_MESES_DESACTIVA")%>" />
																			<input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "MOLDN_MESES_ACTIVA")%>" />
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
															</asp:datagrid>
														</TD>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trEdicion" style="DISPLAY:none">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" colSpan="5" height="25">Detalle de Motivo de Linea Desactiva</td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 116px">
															&nbsp;Código</td>
														<td class="Arial10B" style="WIDTH: 1px">:</td>
														<td class="Arial10B" style="WIDTH: 40px">
															<asp:textbox onpaste="return false;" id="txtCodigo" runat="server" width="50px" ReadOnly="True"
																cssclass="clsInputDisable" style="TEXT-ALIGN: right"></asp:textbox></td>
														<TD class="Arial10B" colSpan="2"></TD>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">&nbsp;Descripción</td>
														<td class="Arial10B" style="WIDTH: 1px; HEIGHT: 19px">:</td>
														<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px">
															<asp:textbox onpaste="return false;" id="txtDescripcion" runat="server" width="500px" ReadOnly="True"
																cssclass="clsInputDisable" DESIGNTIMEDRAGDROP="442"></asp:textbox>
														</td>
														<td class="Arial10B" style="HEIGHT: 19px" colSpan="2"></td>
													</tr>
													<TR>
														<TD class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">
															&nbsp;Motivo</TD>
														<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 19px">:</TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px">
															<asp:textbox onpaste="return false;" id="txtMotivo" runat="server" width="500px" ReadOnly="True"
																cssclass="clsInputDisable" DESIGNTIMEDRAGDROP="443"></asp:textbox>
														</TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</TR>
													<TR>
														<TD class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">
															&nbsp;Recomendación</TD>
														<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 19px">:</TD>
														<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px">
															<asp:textbox onpaste="return false;" id="txtRecomendacion" runat="server" width="500px"
																cssclass="clsInputEnableB" MaxLength="500"></asp:textbox></TD>
														<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
													</TR>
													<tr>
														<td class="Arial10B" style="WIDTH: 116px">&nbsp;Estado</td>
														<td class="Arial10B" style="WIDTH: 1px">:</td>
														<td class="Arial10B" style="WIDTH: 40px">
															<asp:dropdownlist id="ddlEstado" runat="server" width="100px" cssclass="clsSelectEnable">
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
															</asp:dropdownlist>
														</td>
														<td class="Arial10B" colSpan="2"></td>
													</tr>
													<tr>
														<td class="Arial10B" style="WIDTH: 116px">&nbsp;Meses desactiva</td>
														<td class="Arial10B" style="WIDTH: 1px">:</td>
														<td class="Arial10B" style="WIDTH: 40px">
															<asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtMesesDesactiva" runat="server"
																width="50px" cssclass="clsInputEnable" style="TEXT-ALIGN: right" MaxLength="3"></asp:textbox></td>
														<TD class="Arial10B" colSpan="2"></TD>
													</tr>
													<TR>
														<TD class="Arial10B" style="WIDTH: 116px">&nbsp;Meses activa</TD>
														<TD class="Arial10B" style="WIDTH: 1px">:</TD>
														<TD class="Arial10B" style="WIDTH: 40px">
															<asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtMesesActiva" runat="server" width="50px"
																cssclass="clsInputEnable" style="TEXT-ALIGN: right" MaxLength="3"></asp:textbox></TD>
														<TD class="Arial10B" colSpan="2"></TD>
													</TR>
													<tr height="25">
														<td align="center" colSpan="6">
															<asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Aceptar" Height="19"></asp:button>&nbsp;
															<input type="button" id="btnCancelar" style="CURSOR: hand; width:126; height:19"
																class="Boton" value="Cancelar" onclick="f_Cancelar();">
														</td>
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
			</table>
			<input type="hidden" id="hidCodigo" name="hidCodigo" runat="server" />
			<input type="button" id="btnDesactivar" name="btnDesactivar" runat="server" style="display:none" />
		</form>
	</body>
</HTML>
 
 
 
 
