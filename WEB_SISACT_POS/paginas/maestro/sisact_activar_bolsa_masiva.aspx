<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_activar_bolsa_masiva.aspx.vb" Inherits="sisact_activar_bolsa_masiva" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_activar_bolsa_masiva</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
			}		
		
			function f_Inicio()
			{
				f_MostrarTab('BUSQUEDA');
			}
			
			function realizarAccion(strCustcode, strAccion, intBolsa)
			{
				var strAccionDescrip;
				var strPregunta = 'Esta seguro de ';
				
				switch (strAccion)
				{
					case "S":
						strAccionDescrip = 'suspender la bolsa';
						break;
					case "D":
						strAccionDescrip = 'desactivar la bolsa';
						break;
					case "R":
						strAccionDescrip = 'reactivar la bolsa';
						break;
				}
				
				if (confirm(strPregunta + strAccionDescrip))
				{
					setValue('hidCodigo', strCustcode);
					setValue('hidAccion', strAccion);
					setValue('hidBolsa', intBolsa);
					
					__doPostBack('btnModificarEstado','');
				}
			}
			
			function getMaxLengthDocumento(tipoDoc)
			{
				var nroCaracter;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>')
					nroCaracter = 8;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") %>')
					nroCaracter = 9;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
					nroCaracter = 11;
				return nroCaracter;
			}
			
			function cambiarTipoDocumento()
			{
				document.getElementById('txtNroDoc').value = '';
				document.getElementById('txtNroDoc').maxLength = getMaxLengthDocumento(getValue('ddlTipoDocumento'));
				setFocus('txtNroDoc');
			}
			
			function f_Buscar()
			{
				if (getValue('txtNroDoc') == '')
				{
					alert('Debe ingresar número de documento.');
					setFocus('txtNroDoc');
					return false;
				}
				return true;
			}
			function f_ConfirmarGrabar()
			{
//gaa20131115
				if (getValue('ddlCanal') == '')
				{
					alert('Debe seleccionar el canal.');
					setFocus('ddlCanal');
					return false;
				}
				if (getValue('ddlPuntoVenta') == '')
				{
					alert('Debe seleccionar el punto de venta.');
					setFocus('ddlPuntoVenta');
					return false;
				}
//fin gaa20131115											
				if (getValue('txtCustcode') == '')
				{
					alert('Debe seleccionar Custcode.');
					setFocus('txtCustcode');
					return false;
				}			
				if (getValue('ddlGrupoBolsa') == '')
				{
					alert('Debe seleccionar Grupo Bolsa.');
					setFocus('ddlGrupoBolsa');
					return false;
				}
				if (getValue('ddlBolsa') == '')
				{
					alert('Debe seleccionar Bolsa.');
					setFocus('ddlBolsa');
					return false;
				}
				return true;
			}
//gaa20131115
			function cambiarCanal()
			{
				var strCodCanal = getValue('ddlCanal');
				var ddlPuntoVenta = document.getElementById('ddlPuntoVenta');

				inicializarCombo(ddlPuntoVenta);

				if (strCodCanal != '')
				{
					setValue('hidCanal', strCodCanal);
					var arrPuntoVenta = document.getElementById('hidListaPuntoVenta').value.split('|');
					for (var i=0; i < arrPuntoVenta.length; i++)
					{
						var colPuntoVenta = arrPuntoVenta[i].split(';');
						if (colPuntoVenta[2] == strCodCanal)
						{
							cargarCombo(ddlPuntoVenta, colPuntoVenta[0], colPuntoVenta[1]);
						}
					}
				}
			}
			
			function cambiarPDV()
			{
				setValue('hidPDVactual', getValue('ddlPuntoVenta'));
			}
			
			function inicio()
			{
				cambiarCanal();
				setValue('ddlPuntoVenta', getValue('hidPDVactual'));
			}
//fin gaa20131115
		</script>
	</HEAD>
	<body onload="inicio()">
		<form id="Form1" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Activación de 
						Bolsa Masiva</td>
				</tr>
				<tr>
					<td class="contenido">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Arial10b">
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Consulta</A></td>
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
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Consulta 
															Bolsa</td>
													</tr>
													<tr>
														<td class="Arial10b" style="HEIGHT: 26px">&nbsp;Tipo Documento:&nbsp;&nbsp;
															<asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="clsSelectEnableC" Width="130px" onChange="cambiarTipoDocumento();">
																<asp:ListItem Value="01">DNI</asp:ListItem>
																<asp:ListItem Value="04">CE</asp:ListItem>
																<asp:ListItem Value="06">RUC</asp:ListItem>
															</asp:dropdownlist>&nbsp; Nro. Documento:&nbsp;<INPUT class="clsInputEnabled" onkeypress="validaCaracteres('0123456789')" id="txtNroDoc"
																maxLength="8" size="22" name="txtNroDoc" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Height="19" Text="Buscar"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Height="19"
																Text="Limpiar"></asp:button></td>
													</tr>
													<tr id="trNombres" style="DISPLAY: none">
														<td class="Arial10b">&nbsp;Nombres:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<INPUT class="clsInputDisabled" id="txtNombres" readOnly size="80" name="txtNombres" runat="server">
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD></TD>
							</TR>
							<tr id="trGrilla">
								<td>
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="850px" autogeneratecolumns="False"
													showheader="True">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="60px" itemstyle-width="60px">
															<headerstyle wrap="False" horizontalalign="Center" width="60px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CUSTCODE">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CUSTOMER_ID">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="BOLSA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="180px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA ACTIVACIÓN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="60px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FECHA ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px"></headerstyle>
														</asp:templatecolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 880px">
										<table cellSpacing="0" cellPadding="0" width="840" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="560px" autogeneratecolumns="False" showheader="False"
														AllowPaging="True" PageSize="30">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="60px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Wrap="False" Width="60px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:realizarAccion("<%# DataBinder.Eval(Container.DataItem, "custcode")%>", "S", <%# DataBinder.Eval(Container.DataItem, "fu_pack_id")%>);'>
																		<img src="../../images/error.gif" border="0" alt='Suspender' id="imgSuspender" name="imgSuspender"
																			runat="server"></a> <a href='javascript:realizarAccion("<%# DataBinder.Eval(Container.DataItem, "custcode")%>", "R", <%# DataBinder.Eval(Container.DataItem, "fu_pack_id")%>);'>
																		<img src="../../images/activar.gif" border="0" alt='Reactivar' id="imgReactivar" name="imgReactivar"
																			runat="server"></a> <a href='javascript:realizarAccion("<%# DataBinder.Eval(Container.DataItem, "custcode")%>", "D", <%# DataBinder.Eval(Container.DataItem, "fu_pack_id")%>);'>
																		<img src="../../images/rechazar.gif" border="0" alt='Desactivar' id="imgDesactivar" name="imgDesactivar"
																			runat="server"></a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="CUSTCODE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CUSTOMER_ID">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="180px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FEC_ALTA">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FEC_ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="150px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
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
									<table cellSpacing="0" cellPadding="1" width="100%" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">&nbsp;Detalle</td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">&nbsp;Canal</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlCanal" runat="server" CssClass="clsSelectEnableC" Width="130px" onChange="cambiarCanal();"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">&nbsp;Punto de Venta</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlPuntoVenta" runat="server" CssClass="clsSelectEnableC" Width="200px" onChange="cambiarPDV();"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">&nbsp;Custcode</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="validaCaracteres('0123456789.')" id="txtCustcode" runat="server" width="150px"
													MaxLength="24" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<tr>
											<td class="Arial10B" style="WIDTH: 90px">&nbsp;Grupo Bolsa</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlGrupoBolsa" runat="server" width="180px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 90px">&nbsp;Bolsa</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlBolsa" runat="server" width="180px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Height="19" Text="Aceptar"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Height="19"
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
			<input id="btnModificarEstado" style="DISPLAY: none" type="button" name="btnModificarEstado"
				runat="server"> <input id="hidCodigo" type="hidden" name="hidCodigo" runat="server">
			<input id="hidBolsa" type="hidden" name="hidBolsa" runat="server"> <input id="hidAccion" type="hidden" name="hidAccion" runat="server">
			<input id="hidListaPuntoVenta" type="hidden" name="hidListaPuntoVenta" runat="server">
			<input type="hidden" id="hidPDVactual" name="hidPDVactual" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
