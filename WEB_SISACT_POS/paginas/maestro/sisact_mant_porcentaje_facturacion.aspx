<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_porcentaje_facturacion.aspx.vb" Inherits="sisact_mant_porcentaje_facturacion"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_porcentaje_facturacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
		    
		    function f_MostrarTab(valor)
			{		
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					setVisible('trBotones', true);	
					setVisible('trEdicion', false);	
					f_CambiarEstado();
					
					document.getElementById('tdListado').className = 'tab_activo';
					document.getElementById('tdAccion').className = 'tab_inactivo';
					document.getElementById('lblTextAccion').innerText = 'Agregar';					
				}
				if (valor == 'ACCION')
				{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);
					setVisible('trBotones', false);	
					setVisible('trEdicion', true);
					
					document.getElementById('tdListado').className = 'tab_inactivo';
					//document.getElementById('tdAccion').style.display = 'inline';
					document.getElementById('tdAccion').className = 'tab_activo';
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
			
			function f_Modificar(cod, name)
			{
			    setValue('txtNombreCombinacion',name);
				setValue('hidCodigo', cod);				
				__doPostBack('btnModificar', '');
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
			
			function f_EventoSoloNumerosEnteros()
			{
				var CaracteresPermitidos = '0123456789.';
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

			function f_ConfirmarGrabar()
			{	
//gaa20130528
				if (!validarGrabar())
					return false;
//fin gaa20130528					
				if (confirm('¿Desea guardar los cambios?'))
					return true;
				else
					return false;
			}
//gaa20130528
			function validarGrabar()
			{
				var tabla = document.getElementById('<%=dgDetalleBilletera.ClientId %>');
				
				if (tabla == null)
				{
					alert('Debe seleccionar al menos una opción');
					return false;
				}					
				
				var cont = tabla.rows.length;
				var fila;
				var numero;				
				var punto;
				var txt;
				
				if (cont == 1)
				{
					alert('Debe seleccionar al menos una opción');
					return false;					
				}

				for (var i = 1; i < cont; i++)
				{
					fila = tabla.rows[i];
					txt = fila.cells[1].getElementsByTagName("input")[0];
					numero = txt.value;
					
					if (numero.length == 0)
					{
						alert('Debe ingresar un número entre 0.01 y 100');
						txt.focus();
						return false;
					}
					
					if (isNaN(numero))
					{
						alert('El porcentaje debe ser un número válido');
						txt.focus();
						return false;						
					}
					
					punto = numero.indexOf('.') + 1;
					
					if (punto == 1)
					{
						alert('El porcentaje debe ser un número válido');
						txt.focus();
						return false;						
					}
					else
					{
						if (punto > 0)
						{
							if (numero.substring(punto).length > 2)
							{
								alert('El porcentaje puede tener un máximo de 2 decimales')
								txt.focus();
								return false;
							}
						}
					}
					
					numero = parseFloat(numero);
					
					if (numero < 0.01)
					{
						alert('El porcentaje debe ser mayor a 0');
						txt.focus();
						return false;						
					}					
					
					if (numero > 100)
					{
						alert('El porcentaje no puede exceder el 100%');
						txt.focus();
						return false;						
					}
				}
				
				return true;
			}
//fin gaa20130528
			
			function f_ActivarItems()
			{
			    var strAccion = document.getElementById('hidAccion').value;			    
			    var textoAccion = (strAccion == 'D') ? 'desactivar':'activar';
				if(validarCheck()==false)
				{
					alert('Debe seleccionar un registro para ' + textoAccion);
					return false;
				}
			
				if (confirm('¿Esta seguro de ' + textoAccion + ' el(los) registro(s) seleccionado(s)?'))
				{
					return true;
				}
				return false;
			}
			
			function validarCheck()
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var result=false;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkFila') != -1)
					{
						if(e.checked== true)
						{
							result=true;
						}
					}
				} 
				return result;
			}
		</script>
	</HEAD>
	<body onkeydown="f_BloquearBackSpace();" MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" border="0" cellSpacing="0" cellPadding="0">
				<tr>
					<td style="WIDTH: 980px; HEIGHT: 23px" class="header" align="center">Mantenimiento 
						de Porcentaje Facturación</td>
				</tr>
				<tr>
					<td class="contenido">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>
									<table id="tblDetalleLista" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td colSpan="4">
												<table border="0" cellSpacing="0" cellPadding="0">
													<tr>
														<td><IMG src="../../spacer.gif" width="2" height="2"></td>
														<td id="tdListado" class="tab_activo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('BUSQUEDA');/*f_CambiarBusqueda(false);*/">Listado</A></td>
														<td><IMG src="../../spacer.gif" width="2" height="2"></td>
														<td id="tdAccion" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:__doPostBack('btnAgregar','');"><asp:label id="lblTextAccion" Runat="server">Agregar</asp:label></A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table border="0" cellSpacing="1" cellPadding="0" width="100%">
													<tr>
														<td style="HEIGHT: 19px" class="header" colSpan="4" align="left">&nbsp;Busqueda de 
															Porcentaje Facturación</td>
													</tr>
													<tr>
														<td colSpan="4"><asp:checkboxlist id="cblBilleteras" runat="server" Width="80%" CssClass="Arial11BV" RepeatDirection="Horizontal"
																RepeatColumns="3"></asp:checkboxlist></td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px" class="Arial10B" width="200">&nbsp;Estado : 
															&nbsp;&nbsp;&nbsp;&nbsp;
															<asp:dropdownlist id="ddlEstado" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
															</asp:dropdownlist></td>
														<td width="50"></td>
														<td class="Arial10B" width="305"></td>
														<td><asp:button style="CURSOR: hand" id="btnBuscar" onmouseover="this.className='BotonResaltado';"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Buscar"></asp:button>&nbsp;
															<asp:button style="CURSOR: hand" id="btnLimpiar" onmouseover="this.className='BotonResaltado';"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Limpiar"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<P>&nbsp;</P>
								</td>
							</tr>
							<tr id="trGrilla">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td colSpan="2"><asp:datagrid id="dgrGrillaDetalle" runat="server" AutoGenerateColumns="False" DataKeyField="CODIGO"
													AllowPaging="True" PageSize="20">
													<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
													<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
													<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<HeaderStyle Width="25px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
															<ItemTemplate>
																<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>","<%# DataBinder.Eval(Container.DataItem, "COMBINACIONES")%>");'>
																	<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Porcentaje Facturación'>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemStyle Wrap="False" HorizontalAlign="Left" Width="280px" CssClass="Arial10B"></ItemStyle>
															<HeaderTemplate>
																<table border="0" cellSpacing="0" cellPadding="0">
																	<tr>
																		<td class="Arial10B">Billetera %</td>
																	</tr>
																	<tr>
																		<td class="Arial10B">Combinaciones</td>
																	</tr>
																</table>
															</HeaderTemplate>
															<ItemTemplate>
																<%#Container.DataItem("COMBINACIONES")%>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="MOVIL" HeaderText="MOVIL %">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" Width="80px" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="INTERNET FIJO" HeaderText="INTERNET FIJO %">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" Width="80px" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CLARO TV" HeaderText="CLARO TV %">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TELEFONIA FIJA" HeaderText="TELEFONIA FIJA %">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" Width="80px" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="BAM" HeaderText="BAM %">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" Width="80px" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ESTADO" HeaderText="ESTADO">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="25px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox ID="chkFila" Runat="server"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
									</table>
									<P>&nbsp;</P>
								</td>
							</tr>
							<tr id="trBotones">
								<td>
									<table border="0" cellSpacing="0" cellPadding="0">
										<tr>
											<td><asp:button style="CURSOR: hand" id="btnAccion" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Runat="server" Width="135" CssClass="Boton" Height="19"
													Text="Desactivar"></asp:button></td>
											<td align="right"><asp:button style="CURSOR: hand" id="btnExportar" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Exportar"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr style="DISPLAY: none" id="trEdicion">
								<td>
									<table border="0" cellSpacing="1" cellPadding="0" width="100%">
										<tr>
											<td align="center"><asp:checkboxlist id="cblBilleterasAgregar" runat="server" Width="80%" CssClass="Arial11BV" RepeatDirection="Horizontal"
													RepeatColumns="3" AutoPostBack="True"></asp:checkboxlist></td>
										</tr>
										<tr>
											<td class="Arial10B" align="center">
												<div id="tblAccionPF">
													<table>
														<tr>
															<td class="Arial10B"><asp:label id="lblNombreCombinacion" Runat="server">Billetera(s) :</asp:label></td>
															<td><asp:textbox id="txtNombreCombinacion" onpaste="return false;" runat="server" ReadOnly DESIGNTIMEDRAGDROP
																	cssclass="clsInputDisable" width="312px"></asp:textbox></td>
														</tr>
														<tr>
															<td>&nbsp;</td>
															<td><asp:datagrid id="dgDetalleBilletera" runat="server" AutoGenerateColumns="False">
																	<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
																	<Columns>
																		<asp:BoundColumn DataField="PRCLV_DESCRIPCION" HeaderText="Billetera">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="Arial10B" Width="150px"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn HeaderText="Porcentaje %">
																			<ItemTemplate>
																				<asp:Label ID="lblCodigoBase" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PRCLN_PROD_BASE")%>' Visible="False">
																				</asp:Label>
																				<asp:TextBox style="width:60px;text-align:right;" Runat="server" onkeypress="return f_EventoSoloNumerosEnteros();" onpaste="return false;" MaxLength="5" ondrop="return false;" ID="txtFact" Text='<%#DataBinder.Eval(Container.DataItem, "PRCLN_FACTOR_FACT")%>'>
																				</asp:TextBox>
																			</ItemTemplate>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" CssClass="Arial10B" Width="85px"></ItemStyle>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:datagrid>
																<P>&nbsp;</P>
															</td>
														</tr>
													</table>
												</div>
											</td>
										</tr>
										<tr height="25">
											<td align="center"><asp:button style="CURSOR: hand" id="btnAceptar" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Aceptar"></asp:button>&nbsp;
												<asp:button style="CURSOR: hand" id="btnCancelar" onmouseover="this.className='BotonResaltado';"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19"
													Text="Cancelar" CausesValidation="False"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<input style="DISPLAY: none" id="btnAgregar" type="button" name="btnAgregar" runat="server">
						<input style="DISPLAY: none" id="btnModificar" type="button" name="btnModificar" runat="server">
						<input id="hidCodigo" type="hidden" name="hidCodigo" runat="server"> <input id="hidAccion" type="hidden" name="hidAccion" runat="server">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
