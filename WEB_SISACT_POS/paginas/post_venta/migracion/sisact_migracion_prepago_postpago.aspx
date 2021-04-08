<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_migracion_prepago_postpago.aspx.vb" Inherits="sisact_migracion_prepago_postpago" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="uc1" TagName="usc_direccion" Src="../../../controles/usc_direccion.ascx" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_migracion_prepago_postpago.aspx.vb" Inherits="sisact_migracion_prepago_postpago" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_migracion_prepago_postpago</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_direccion.js"></script>
		<script language="javascript" src="../../../script/json.js"></script>
		<script language="javascript" src="../../../script/MigracionPostpago.js"></script>
		<script language="javascript">
		</script>
	</HEAD>
	<body>
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblPrincipal" style="WIDTH: 100%">
				<tr>
					<td>
						<table id="tblValidacionCliente" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="header" align="left" height="20">Validación del Cliente</td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table4" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" border="0">
										<TR>
											<TD style="WIDTH: 70px"><asp:label id="Label1" runat="server" CssClass="Arial10B" Width="88px">Buscar por:</asp:label></TD>
											<TD style="WIDTH: 20%"><asp:dropdownlist id="ddlDoc" runat="server" CssClass="clsSelectEnable0" Width="100%" onchange="ddlDoc_change()"></asp:dropdownlist></TD>
											<TD style="WIDTH: 20%"><asp:textbox onkeypress="OnKeyPressNumeros()" id="txtDocumento" runat="server" CssClass="clsInputDisable"
													Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 15%" align="left"><asp:label id="Label2" runat="server" CssClass="Arial10B" Width="136px">Número Telefónico:</asp:label></TD>
											<TD style="WIDTH: 20%" align="left"><asp:textbox onkeypress="OnKeyPressNumeros()" id="txtNumero" runat="server" CssClass="clsInputEnableB"
													Width="100%" MaxLength="9"></asp:textbox></TD>
											<TD align="left"><anthem:button id="btnBuscar" runat="server" CssClass="Boton" Width="98px" PreCallBackFunction="validarBuscar"
													Enabled="true" EnableViewState="False" TextDuringCallBack="Consultando..." EnabledDuringCallBack="False"
													CausesValidation="False" Text="Buscar"></anthem:button></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="right"><INPUT class="Boton" id="btnSgte1" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
							disabled onclick="mostrarPanel('tblDatosCliente')" onmouseout="this.className='Boton';" type="button"
							value="Siguiente Paso ->" name="btnPuntoVenta">
					</td>
				</tr>
				<tr id="trDatosCliente" style="DISPLAY: none">
					<td>
						<table id="tblDatosCliente" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="header" align="left" height="20">Datos del cliente</td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table4" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" width="712" border="0">
										<TR>
											<TD style="WIDTH: 70px"><asp:label id="Label3" runat="server" CssClass="Arial10B" Width="128px">Tipo de Documento(*):</asp:label></TD>
											<TD style="WIDTH: 20%"><asp:dropdownlist id="ddlTipoDoc" runat="server" CssClass="clsSelectEnable0" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											<TD style="WIDTH: 15%"></TD>
											<TD style="WIDTH: 136px"><asp:label id="Label5" runat="server" CssClass="Arial10B" Width="128px"> Nro Doc de Identidad(*):</asp:label></TD>
											<TD style="WIDTH: 20%" align="right"><asp:textbox id="txtNroDoc" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 20%" align="right"><asp:label id="Label4" runat="server" CssClass="Arial10B" Width="136px">Nombre(*):</asp:label></TD>
											<TD align="right"><asp:textbox id="txtNombre" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 70px"><asp:label id="Label6" runat="server" CssClass="Arial10B" Width="128px">Apellido Paterno(*):</asp:label></TD>
											<TD style="WIDTH: 20%"><asp:textbox id="txtApePat" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 15%"></TD>
											<TD style="WIDTH: 136px"><asp:label id="Label7" runat="server" CssClass="Arial10B" Width="128px">Apellido Materno(*):</asp:label></TD>
											<TD style="WIDTH: 20%"><asp:textbox id="txtApeMat" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD></TD>
											<TD style="WIDTH: 20%"></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trSgte1" style="DISPLAY: none">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="left">
									<!--
								<INPUT class="Boton" id="btnAnt2" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="ocultarPanel('tblDatosCliente')" onmouseout="this.className='Boton';" type="button" value="<- Regresar"
										name="btnPuntoVenta">
								--></td>
								<td align="right"><INPUT class="Boton" id="btnSgte2" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="mostrarPanel('tblCondicionesVenta')" onmouseout="this.className='Boton';" type="button"
										value="Siguiente Paso ->" name="btnPuntoVenta">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trCondicionesVenta" style="DISPLAY: none">
					<td>
						<table id="tblCondicionesVenta" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="header" align="left" height="20">Condiciones de Venta</td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table4" style="WIDTH: 100%" cellSpacing="1" cellPadding="1" width="712" border="0">
										<TR>
											<TD style="WIDTH: 15%"><asp:checkbox id="chkCorreo" runat="server" CssClass="Arial10B" Width="168px" Text="Envio de recibo por correo"></asp:checkbox></TD>
											<TD style="WIDTH: 5%"></TD>
											<TD style="WIDTH: 15%"><asp:label id="Label9" runat="server" CssClass="Arial10B" Width="112px"> Correo Electrónico:</asp:label></TD>
											<TD style="WIDTH: 20%" align="right"><asp:textbox id="txtCorreo" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 5%" align="right"></TD>
											<TD style="WIDTH: 15%" align="right"></TD>
											<TD style="WIDTH: 20%" align="right"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 15%"></TD>
											<TD style="WIDTH: 5%"></TD>
											<TD style="WIDTH: 15%"><asp:label id="Label11" runat="server" CssClass="Arial10B">Confirm. Correo Electrónico:</asp:label></TD>
											<TD style="WIDTH: 20%" align="right"><asp:textbox id="txtConfirmCorreo" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 5%" align="right"></TD>
											<TD style="WIDTH: 15%" align="right"></TD>
											<TD style="WIDTH: 20%" align="right"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 15%; HEIGHT: 20px"></TD>
											<TD style="WIDTH: 5%"></TD>
											<TD style="WIDTH: 15%"></TD>
											<TD style="WIDTH: 20%" align="right"></TD>
											<TD style="WIDTH: 5%" align="right"></TD>
											<TD style="WIDTH: 15%" align="right"></TD>
											<TD style="WIDTH: 20%" align="right"></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label8" runat="server" CssClass="Arial10B" Width="128px"> Plazo Acuerdo(*):</asp:label></TD>
											<TD colSpan="2"><anthem:dropdownlist id="ddlPlazoAcuerdo" runat="server" CssClass="clsSelectEnable0" Width="100%" AutoPostBack="False"
													AutoUpdateAfterCallBack="False" AutoCallBack="False"></anthem:dropdownlist></TD>
											<TD vAlign="top" align="left" colSpan="3" rowSpan="4"><anthem:datagrid id="dgPlan" runat="server" EnableViewState="True" autogeneratecolumns="false" width="100%">
													<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
													<ItemStyle CssClass="Arial11B" BackColor="#E9EBEE"></ItemStyle>
													<Columns>
														<asp:BoundColumn DataField="PLANV_DESCRIPCION" headerText="Plan">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="35%" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="35%" CssClass="Arial11B"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Servicios">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="65%" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="65%"></ItemStyle>
															<ItemTemplate>
																<input type="hidden" runat="server" id="hdnCodPlan" NAME="hdnCodPlan" /> <input type="hidden" runat="server" id="hdnCF" NAME="hdnCF" />
																<asp:Table ID="tblServicios" CssClass="Arial11B" BackColor="#E9EBEE" Runat="server" />
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</anthem:datagrid></TD>
											<TD vAlign="middle" align="center" rowSpan="4"></TD>
										</TR>
										<TR>
											<TD><asp:label id="Label10" runat="server" CssClass="Arial10B" Width="128px">Plan(*):</asp:label></TD>
											<TD colSpan="2"><anthem:dropdownlist id="ddlPlan" runat="server" CssClass="clsSelectEnable0" Width="100%" AutoPostBack="True"
													AutoUpdateAfterCallBack="False" AutoCallBack="True" preCallBackFunction="ddlPlan_change(this.value)" postCallBackFunction="ddlplan_post_callback"></anthem:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD colSpan="2">
												<div id="divServicios" style="WIDTH: 250px; DISPLAY: none; HEIGHT: 150px; OVERFLOW: auto">
													<anthem:datagrid id="dgServicios" runat="server" EnableViewState="false" autogeneratecolumns="false"
														width="100%" showheader="False">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial11B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="Marcar">
																<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos"></headerstyle>
																<itemstyle horizontalalign="Center" width="25px"></itemstyle>
																<itemtemplate>
																	<input id='chk_<%# DataBinder.Eval(Container.DataItem, "Servicio_Solicit" )%>' type="checkbox" 
																		name="Servicios" 
																		Descripcion='<%# DataBinder.Eval(Container.DataItem, "Descripcion")%>' 
																		grupo='<%# DataBinder.Eval(Container.DataItem, "Grupo")%>' 
																		cargoFijo='<%# DataBinder.Eval(Container.DataItem, "Cargo_Fijo")%>' 
																		codigo='<%# DataBinder.Eval(Container.DataItem, "Servicio_Solicit")%>' 
																		sel='<%# DataBinder.Eval(Container.DataItem, "Seleccionable")%>' 
																		onclick = "return seleccionarItem(this);" 
																		value='<%# DataBinder.Eval(Container.DataItem, "Servicio_Solicit" )%>'> <input id="hidCodServ" type="hidden" runat="server" name="hidCodServ" value='<%# DataBinder.Eval(Container.DataItem, "Servicio_Solicit" )%>'>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="DESCRIPCION" itemstyle-cssclass="Arial11B">
																<headerstyle horizontalalign="center"></headerstyle>
																<itemstyle wrap="false" horizontalalign="left" width="90%"></itemstyle>
															</asp:boundcolumn>
														</columns>
													</anthem:datagrid>
												</div>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 70px"><anthem:button id="btnQuitarPlan" runat="server" CssClass="Boton" Width="98px" Enabled="true" EnableViewState="False"
													TextDuringCallBack="Procesando..." EnabledDuringCallBack="False" CausesValidation="False" Text="Quitar plan"></anthem:button></TD>
											<TD style="WIDTH: 79px" colSpan="2"><anthem:button id="btnAgregarPlan" runat="server" CssClass="Boton" Width="98px" Enabled="true"
													EnableViewState="False" TextDuringCallBack="Agregando..." EnabledDuringCallBack="False" CausesValidation="False" Text="Agregar plan"
													preCallBackFunction="btnAgregarPlan_click"></anthem:button></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trSgte2" style="DISPLAY: none">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="left">
									<!--
								<INPUT class="Boton" id="btnAnt3" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="ocultarPanel('tblCondicionesVenta')" onmouseout="this.className='Boton';" type="button"
										value="<- Regresar" name="btnPuntoVenta">
								--></td>
								<td align="right"><INPUT class="Boton" id="btnSgte3" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="mostrarPanel('tblResultado')" onmouseout="this.className='Boton';" type="button" value="Siguiente Paso ->"
										name="btnPuntoVenta">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trResultado" style="DISPLAY: none">
					<td>
						<table id="tblResultado" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="header" align="left" height="20">Resultado Preliminar de la Evaluación</td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table4" style="WIDTH: 712px; HEIGHT: 58px" cellSpacing="1" cellPadding="1" width="712"
										border="0">
										<TR>
											<TD style="WIDTH: 70px; HEIGHT: 25px"><asp:label id="Label12" runat="server" CssClass="Arial10B" Width="96px">Tipo de Garantía:</asp:label></TD>
											<TD style="WIDTH: 155px; HEIGHT: 25px"><asp:textbox id="txtTipoGarantia" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 336px" align="right"><asp:label id="Label13" runat="server" CssClass="Arial10B" Width="96px">Nro CF:</asp:label></TD>
											<TD style="HEIGHT: 25px" align="right"><asp:textbox id="txtNumeroCF" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 70px"><asp:label id="Label14" runat="server" CssClass="Arial10B" Width="96px">Riesgo:</asp:label></TD>
											<TD style="WIDTH: 155px" align="right"><asp:textbox id="txtRiesgo" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
											<TD style="WIDTH: 336px" align="right"><asp:label id="Label15" runat="server" CssClass="Arial10B" Width="96px">Importe S/. :</asp:label></TD>
											<TD><asp:textbox id="txtImporte" runat="server" CssClass="clsInputDisable" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trSgte3" style="DISPLAY: none">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="left"><INPUT class="Boton" id="btnAnt4" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="ocultarPanel('tblResultado')" onmouseout="this.className='Boton';" type="button" value="<- Regresar"
										name="btnPuntoVenta">
								</td>
								<td align="right"><INPUT class="Boton" id="btnSgte4" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="mostrarPanel('tblDirFact')" onmouseout="this.className='Boton';" type="button" value="Siguiente Paso ->"
										name="btnPuntoVenta">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table style="WIDTH: 100%">
				<tr id="trDirFact" style="DISPLAY: none">
					<td>
						<TABLE id="tblDirFact" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<td class="header" align="left" height="20">Dirección de Facturación</td>
							</TR>
							<tr>
								<td style="HEIGHT: 23px"><uc1:usc_direccion id="Usc_direccion1" runat="server"></uc1:usc_direccion></td>
							</tr>
							<tr>
								<td>
									<!--<input type="button" value="Copiar" id="btnCop" onclick="prueba1()" />--><INPUT class="Boton" id="btnMostrarDirCli" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 160px; HEIGHT: 19px; CURSOR: hand" onclick="mostrarPanel('dirCliente')" onmouseout="this.className='Boton';" type="button" value="Mostrar Dirección Cliente"
										name="btnMostrarDirCli" presionado="0">
								</td>
							</tr>
							<tr id="trDir2" style="DISPLAY: none">
								<td><uc1:usc_direccion id="Usc_direccion2" runat="server"></uc1:usc_direccion></td>
							</tr>
							<tr>
								<td><INPUT class="Boton" id="btnMostrarDirTra" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 160px; HEIGHT: 19px; CURSOR: hand" onclick="mostrarPanel('dirTrabajo')"
										onmouseout="this.className='Boton';" type="button" value="Mostrar Dirección Trabajo"
										name="btnMostrarDirTra" presionado="0">
								</td>
							</tr>
							<tr id="trDir3" style="DISPLAY: none">
								<td><uc1:usc_direccion id="Usc_direccion3" runat="server"></uc1:usc_direccion></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="trSgte4" style="DISPLAY: none" align="right">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="left">
									<!--
								<INPUT class="Boton" id="btnAnt6" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="ocultarPanel('trDirFact')" onmouseout="this.className='Boton';" type="button" value="<- Regresar"
										name="btnPuntoVenta">
										--></td>
								<td align="right"><INPUT class="Boton" id="btnSgte6" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="mostrarPanel('tblCampana')" onmouseout="this.className='Boton';" type="button" value="Siguiente Paso ->"
										name="btnPuntoVenta">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table style="WIDTH: 100%">
				<tr id="trCampana" style="DISPLAY: none">
					<td>
						<table id="tblCampana" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="header" style="WIDTH: 100%" align="left" height="20">Operación y Campaña</td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 58px" cellSpacing="1" cellPadding="1" width="712"
										border="0">
										<TR>
											<TD style="WIDTH: 70px; HEIGHT: 25px"><asp:label id="Label16" runat="server" CssClass="Arial10B" Width="120px">Tipo de Operación(*):</asp:label></TD>
											<TD style="WIDTH: 155px; HEIGHT: 25px"><asp:dropdownlist id="ddlTipoOperacion" runat="server" CssClass="clsSelectEnable0" Width="224px" Enabled="False"></asp:dropdownlist></TD>
											<TD style="WIDTH: 336px" align="right"><asp:label id="Label17" runat="server" CssClass="Arial10B" Width="96px">Campaña(*):</asp:label></TD>
											<TD style="HEIGHT: 25px" align="right"><asp:dropdownlist id="ddlCampana" runat="server" CssClass="clsSelectEnable0" Width="248px" enabled="true"></asp:dropdownlist></TD>
										</TR>
										<TR id="trOficina" style="DISPLAY: none">
											<TD style="WIDTH: 70px; HEIGHT: 25px"><asp:label id="Label18" runat="server" CssClass="Arial10B" Width="96px">Oficina:</asp:label></TD>
											<TD style="WIDTH: 155px; HEIGHT: 25px"><asp:dropdownlist id="ddlOficina" runat="server" CssClass="clsSelectEnable0" Width="224px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 336px" align="right"></TD>
											<TD style="HEIGHT: 25px" align="right"></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trSgte5" style="DISPLAY: none">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="left">
									<!--
								<INPUT class="Boton" id="btnAnt5" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="ocultarPanel('tblCampana')" onmouseout="this.className='Boton';" type="button" value="<- Regresar"
										name="btnPuntoVenta">
										--></td>
								<td align="right"><INPUT class="Boton" id="btnSgte5" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; HEIGHT: 19px; CURSOR: hand"
										onclick="mostrarPanel('migrar')" onmouseout="this.className='Boton';" type="button" value="Siguiente Paso ->"
										name="btnPuntoVenta">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trMigrar" style="DISPLAY: none">
					<td>
						<table style="WIDTH: 100%">
							<tr>
								<td align="right">&nbsp;
									<anthem:button id="btnMigrar" runat="server" CssClass="Boton" Width="113px" Enabled="true" EnableViewState="False"
										TextDuringCallBack="Procesando..." EnabledDuringCallBack="False" CausesValidation="False" Text="MIGRAR"
										preCallBackFunction="validarMigrar"></anthem:button></td>
								<td align="left">&nbsp;
									<anthem:button id="btnCancelar" runat="server" CssClass="Boton" Width="113px" EnableViewState="False"
										TextDuringCallBack="Procesando..." EnabledDuringCallBack="False" CausesValidation="False" Text="CANCELAR"
										preCallBackFunction="validarCancelar"></anthem:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hdnValCliente" style="WIDTH: 5px" type="hidden" name="hdnValCliente" runat="server">
			<input id="hdnWhitelist" style="WIDTH: 5px" type="hidden" name="hdnWhitelist" runat="server">
			<input id="hdnCargoFijoMax" style="WIDTH: 5px" type="hidden" name="hdnCargoFijoMax" runat="server">
			<input id="hdnPlazoDefault" style="WIDTH: 5px" type="hidden" name="hdnPlazoDefault" runat="server">
			<input id="hdnServicios" style="WIDTH: 5px" type="hidden" name="hdnServicios" runat="server">
			<input id="hdnTipoCargo" style="WIDTH: 5px" type="hidden" name="hdnTipoCargo" runat="server">
			<input id="hdnCFPlanServicios" style="WIDTH: 5px" type="hidden" name="hdnCFPlanServicios"
				runat="server"> <input id="hdnFlagControlConsumo" style="WIDTH: 5px" type="hidden" name="hdnFlagControlConsumo"
				runat="server"> <input id="hdnTiposDocumento" style="WIDTH: 5px" type="hidden" name="hdnTiposDocumento"
				runat="server"> <input id="hdnCampanaDefault" style="WIDTH: 5px" type="hidden" name="hdnCampanaDefault"
				runat="server"> <input id="hdnMontoFlat" style="WIDTH: 5px" type="hidden" name="hdnMontoFlat" runat="server">
			<anthem:button id="btnCargarPlanes" style="DISPLAY: none" runat="server" Width="98px" Enabled="true"
				EnableViewState="False" TextDuringCallBack="Consultando..." EnabledDuringCallBack="False" CausesValidation="False"
				Text="Cargar planes"></anthem:button></form>
	</body>
</HTML>
 
 
 
 
