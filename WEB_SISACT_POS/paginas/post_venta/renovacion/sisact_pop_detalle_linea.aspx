<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_detalle_linea.aspx.vb" Inherits="sisact_pop_detalle_linea" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Detalle de Linea</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../librerias/Lib_FuncValidacion.js"></script>
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script>
			function inicio()
			{			
				var ConsultaOK = (getValue('hidCodError') != '1');
				var msgError = getValue('hidErrorConsulta');
				if (getValue('hidCodError') == '')
				{
					if (document.frmPrincipal.hidAccion.value == "CR")
					{
						var existe = getValue('hidClienteExiste');
						if (existe == 'S')
						{
							parent.retornoConsultaBSCS(getValue('hidBlackList'), getValue('hidLblDeudaBloqueo'), getValue('hidLblCliente'), getValue('hidEvaluarMovil'), 'S',getValue('hidCalificacionPago'));
						}
						else{
							parent.retornoConsultaBSCS('N', '', getValue('hidLblCliente'), 'S', 'N',getValue('hidCalificacionPago'));	
						}
					}
					else if (document.frmPrincipal.hidAccion.value == "C")
					{							
						var existe = getValue('hidClienteExiste');
						if (existe == 'S')
						{						
							parent.document.getElementById('hidPlanesActivos').value = document.frmPrincipal.hidPlanesActivos.value;
							parent.document.getElementById('hidNroLineas').value = document.frmPrincipal.hidNroLineas.value;
							parent.document.getElementById('hidTieneSECPendiente').value = document.frmPrincipal.hidTieneSECPendiente.value;
							parent.document.getElementById('hidClienteClaro').value = document.frmPrincipal.hidClienteClaro.value;

							var ape_pat, ape_mat, nombres;
							var razon_social = document.frmPrincipal.hidRazonSocial.value;
							if (getValue('hidTipoDoc') != '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
							{
								var arrApellPatMat = separarApellidos(getValue('hidApellidos'));
								ape_pat = arrApellPatMat[0];
								ape_mat = arrApellPatMat[1] != "" ? arrApellPatMat[1] : "NN";
								nombres = document.frmPrincipal.hidNombres.value;
							}													
							
							if (getValue('hidTipoDoc') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
							{
								parent.document.getElementById('txtApePat').value = ape_pat;
								parent.document.getElementById('txtApeMat').value = ape_mat;
								parent.document.getElementById('txtNombre').value = nombres;
								parent.document.getElementById('txtRazonSocial').value = razon_social;
							}
							else
							{
								parent.document.getElementById('txtApePat').value = ape_pat;
								parent.document.getElementById('txtApeMat').value = ape_mat;
								parent.document.getElementById('txtNombre').value = nombres;
							}
								parent.document.getElementById('txtplanactual').value = getValue('hidPlanAct');//jmori  23012015							
								parent.document.getElementById('txtplanactualdac').value = getValue('hidPlanAct');//jmori  23012015							
								parent.document.getElementById('txtplanactualRUC').value = getValue('hidPlanAct');//jmori  23012015
								parent.document.getElementById('hidPlanActual').value = getValue('hidPlanAct');	//jmori  23012015
								parent.document.getElementById('txtPlanComercial').value = getValue('hidplancomercial');	//jmori  23012015
								parent.document.getElementById('hidserviciosactuales').value=getValue('hidservicios');
								parent.document.getElementById('txtcargofijo').value=getValue('hidcargofijo');
								parent.document.getElementById('txtcargofijodac').value=getValue('hidcargofijo');
								parent.document.getElementById('hidCargoFijoActual').value=getValue('hidcargofijo');
								parent.retornoConsultaBSCS(getValue('hidBlackList'), getValue('hidLblDeudaBloqueo'), getValue('hidLblCliente'), getValue('hidEvaluarMovil'), 'S',getValue('hidCalificacionPago'));		
						}
						else
						{				
							parent.document.getElementById('hidPlanesActivos').value = "";
							parent.document.getElementById('hidNroLineas').value = "0";
							parent.document.getElementById('hidTieneSECPendiente').value = document.frmPrincipal.hidTieneSECPendiente.value;
								
							parent.retornoConsultaBSCS('N', '', getValue('hidLblCliente'), 'S', 'N',getValue('hidCalificacionPago'));					
						}
						parent.document.getElementById('hidPlanesDatosVoz').value = document.frmPrincipal.hidPlanesDatosVoz.value;
						parent.document.getElementById('hidCalificacionPago').value = document.frmPrincipal.hidCalificacionPago.value;
					}
					document.frmPrincipal.hidAccion.value = '';

                                        if (getValue('hidTipoDoc') == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
				        {
					    if (getValue('hidNroDoc').substring(0,1) != '<%= ConfigurationSettings.AppSettings("constRUCInicio")%>') 
						document.getElementById('trAnexoDocumento').style.display = '';
						
					    document.getElementById('trCantLineaMayorMenor').style.display = '';
				        }
				}
				else if(getValue('hidCodError') == '2') {
					//Inicio Renovacion por Bloqueo JAZ
					parent.document.getElementById('trDetalleValidacionBloqueo').style.display='none';										
					alert(msgError);
					parent.retornoConsultaBSCS('','','','N', 'S', getValue('hidCalificacionPago'));
					//Fin Renovacion por Bloqueo JAZ
				}
				else if (getValue('hidCodError') == '1')
				{
					parent.document.getElementById('trDetalleValidacionBloqueo').style.display='none';
					alert(msgError);
				}
			}
			
			Array.prototype.indexOf = function(s) {
				for (var x = 0; x < this.length; x++) if (this[x] == s) return x;
				return -1;
			}
			
			function separarApellidos(apellido)
			{
				var special_tokens = document.getElementById('hidTokensApellido').value.split(',');
				var apellido_ordenado = new Array();
				var tokens = apellido.split(' ');
				tokens = tokens.reverse();
				var contador = 0;
				var ap_paterno = '';
				var ap_materno = '';
				var tok;

				for (var i=0; i< tokens.length; i++)
				{
					tok = tokens[i];
					if (special_tokens.indexOf(tok.toLowerCase()) >= 0)
					{	if (apellido_ordenado.length > 0)
						{
							apellido_ordenado[contador - 1] = tok + " " + apellido_ordenado[contador - 1];
						}
					}
					else
					{
						contador += 1;
						apellido_ordenado[contador - 1] = tok;
					}
				}

				if (apellido_ordenado.length > 0)
				{
					if (apellido_ordenado.length == 1)
					{
						ap_paterno = apellido_ordenado[0];
						ap_materno = "";
					}
					else if (apellido_ordenado.length == 2)
					{
						ap_paterno = apellido_ordenado[1];
						ap_materno = apellido_ordenado[0];
					}
					else
					{
						for (var j=1; j<apellido_ordenado.length; j++)
						{
							if (j==1)
								ap_paterno = apellido_ordenado[j];
							else
								ap_paterno =  apellido_ordenado[j] + " " + ap_paterno;

						}
						ap_materno = apellido_ordenado[0];
					}
				}
				return [ap_paterno, ap_materno];
			}
			
			function cerrarVentana()
			{
				window.close();
			}			
			
			function f_mostrarDetalle(id) 
			{
				if (!document.getElementById) return false;
				fila = document.getElementById(id);
				if (fila.style.display != "none") {
					fila.style.display = "none";
				} else {
					fila.style.display = "";
				}
			}
					
		</script>
	</HEAD>
	<body onload="inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="Header" align="left" colSpan="5" height="20">Resumen</td>
				</tr>
				<tr>
					<td>
						<TABLE cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD class="Arial10B">Tipo y Nro Documento</TD>
								<TD><asp:textbox id="txtTipoDocumento" runat="server" DESIGNTIMEDRAGDROP="40" CssClass="clsinputdisabled"
										ReadOnly="True" Width="60px"></asp:textbox>&nbsp;</TD>
								<TD><asp:textbox id="txtNroDocumento" runat="server" DESIGNTIMEDRAGDROP="39" CssClass="clsinputdisabled"
										ReadOnly="True" Width="100px"></asp:textbox></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Nombres y apellidos/Razon Social</TD>
								<TD><asp:textbox id="txtNombre" runat="server" DESIGNTIMEDRAGDROP="48" CssClass="clsinputdisabled"
										ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR id="trAnexoDocumento" style="DISPLAY: none">
								<TD class="Arial10B">Tipo y Nro Documento Anexo</TD>
								<TD><asp:textbox id="txtTipoDocumentoAnexo" runat="server" DESIGNTIMEDRAGDROP="40" CssClass="clsinputdisabled"
										ReadOnly="True" Width="60px"></asp:textbox>&nbsp;</TD>
								<TD><asp:textbox id="txtNroDocumentoAnexo" runat="server" DESIGNTIMEDRAGDROP="39" CssClass="clsinputdisabled"
										ReadOnly="True" Width="100px"></asp:textbox></TD>
								<TD>&nbsp;</TD>
								<TD>&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD class="Arial10B">Cantidad de Planes/Soluciones</TD>
								<TD><asp:textbox id="txtCantidadPlan" runat="server" DESIGNTIMEDRAGDROP="41" CssClass="clsinputdisabled"
										ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Total Cargos Fijos (S/.)</TD>
								<TD><asp:textbox id="txtCargoFijo" runat="server" DESIGNTIMEDRAGDROP="49" CssClass="clsinputdisabled"
										ReadOnly="True" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Arial10B">Deuda vencida (S/.)</TD>
								<TD colspan="2"><asp:textbox id="txtDeudaVencida" runat="server" DESIGNTIMEDRAGDROP="42" CssClass="clsinputdisabled"
										ReadOnly="True" Width="100px"></asp:textbox></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Deuda Castigada (S/.)</TD>
								<TD><asp:textbox id="txtDeudaCastigada" runat="server" DESIGNTIMEDRAGDROP="50" CssClass="clsinputdisabled"
										ReadOnly="True" Width="55px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Arial10B">Bloqueos</TD>
								<TD><asp:textbox id="txtBloqueo" runat="server" CssClass="clsinputdisabled" ReadOnly="True" Width="60px"></asp:textbox></TD>
								<TD></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Suspensiones</TD>
								<TD><asp:textbox id="txtSuspension" runat="server" CssClass="clsinputdisabled" ReadOnly="True" Width="55px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="Arial10B">Cantidad de Lineas Bloqueadas</TD>
								<TD><asp:textbox id="txtCantBloqueoMovil" runat="server" CssClass="clsinputdisabled" ReadOnly="True"
										Width="60px"></asp:textbox></TD>
								<TD></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Cantidad de Lineas Suspendidas</TD>
								<TD><asp:textbox id="txtCantSuspMovil" runat="server" CssClass="clsinputdisabled" ReadOnly="True"
										Width="55px"></asp:textbox></TD>
							</TR>
							<TR id="trCantLineaMayorMenor" style="DISPLAY: none">
								<TD class="Arial10B">Cantidad de Lineas Menor a
									<asp:label id="lblCantLineaMenor" runat="server"></asp:label>&nbsp;dias</TD>
								<TD><asp:textbox id="txtCantLineaMenor" runat="server" CssClass="clsinputdisabled" ReadOnly="True"
										Width="60px"></asp:textbox></TD>
								<TD></TD>
								<TD>&nbsp;</TD>
								<TD class="Arial10B">Cantidad de Lineas Mayor a
									<asp:label id="lblCantLineaMayor" runat="server"></asp:label>&nbsp;dias</TD>
								<TD><asp:textbox id="txtCantLineaMayor" runat="server" CssClass="clsinputdisabled" ReadOnly="True"
										Width="55px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="Header" align="left" colSpan="5" height="20">Detalle BSCS</td>
				</tr>
				<tr>
					<td align="left">
						<div class="clsGridRow" id="divLista" runat="server">
							<!-- Grilla de BSCS --><asp:datagrid id="dgdListaBSCS" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CODIGO_CUENTA" HeaderText="C&#243;digo Cuenta">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ESTADO_CUENTA" HeaderText="Estado de<br />Cuenta">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_ID" HeaderText="Customer ID">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CENTRAL_RIESGO" HeaderText="Central de<br />Riesgo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CF" HeaderText="Cargo Fijo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROMEDIO_FACTURADO" HeaderText="Promedio<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_NO_FACTURADO" HeaderText="Monto aun NO<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_VENCIDO" HeaderText="Monto<br />Vencido">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_CASTIGADO" HeaderText="Monto<br />Castigado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DEUDA_REINTEGRO" HeaderText="Deuda Reintegro<br />de Equipo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SERVICIOS" HeaderText="Cantidad de Planes/<br />Servicios">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_BLOQUEOS" HeaderText="Cantidad de<br />Bloqueados">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SUSPENDIDOS" HeaderText="Cantidad de<br />Suspendidos">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<img id="btnMostrarDetalleBSCS" name="btnMostrarDetalleBSCS" src="../../../images/ico_lupa.gif"
												style="CURSOR: pointer;" alt="Ver Detalle Linea" runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<input id="hidCodCuentaBSCS" type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO_CUENTA")%>' size="1" name="hidCodCuentaBSCS"
										runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td class="Header" align="left" colSpan="5" height="20">Detalle SGA</td>
				</tr>
				<tr>
					<td align="left">
						<div class="clsGridRow" id="divListaSGA" runat="server">
							<!-- Grilla SGA --><asp:datagrid id="dgdListaSGA" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE" HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CODIGO_CUENTA" HeaderText="C&#243;digo Cuenta">
										<ItemStyle Width="100px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ESTADO_CUENTA" HeaderText="Estado de<br />Cuenta">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_ID" HeaderText="Customer ID">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CENTRAL_RIESGO" HeaderText="Central de<br />Riesgo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CF" HeaderText="Cargo Fijo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROMEDIO_FACTURADO" HeaderText="Promedio<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_NO_FACTURADO" HeaderText="Monto aun NO<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_VENCIDO" HeaderText="Monto<br />Vencido">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_CASTIGADO" HeaderText="Monto<br />Castigado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DEUDA_REINTEGRO" HeaderText="Deuda Reintegro<br />de Equipo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SERVICIOS" HeaderText="Cantidad de Planes/<br />Servicios">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_BLOQUEOS" HeaderText="Cantidad de<br />Bloqueados">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SUSPENDIDOS" HeaderText="Cantidad de<br />Suspendidos">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<img id="btnMostrarDetalleSGA" name="btnMostrarDetalleSGA" src="../../../images/ico_lupa.gif"
												style="CURSOR: pointer;" alt="Ver Detalle Linea" runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<input id="hidCodCuentaSGA" type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO_CUENTA")%>' size="1" name="hidCodCuentaSGA"
										runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td class="Header" height="20" colSpan="5" align="left">Detalle Venta Sisact</td>
				</tr>
				<tr>
					<td align="left">
						<div id="divListaSISACT" class="clsGridRow" runat="server"><asp:datagrid id="dgdListaSISACT" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
								<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE" HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CODIGO_CUENTA" HeaderText="C&#243;digo Cuenta">
										<ItemStyle Width="100px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ESTADO_CUENTA" HeaderText="Estado de<br />Cuenta">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUSTOMER_ID" HeaderText="Customer ID">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CENTRAL_RIESGO" HeaderText="Central de<br />Riesgo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CF" HeaderText="Cargo Fijo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PROMEDIO_FACTURADO" HeaderText="Promedio<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_NO_FACTURADO" HeaderText="Monto aún NO<br />Facturado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_VENCIDO" HeaderText="Monto<br />Vencido">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MONTO_CASTIGADO" HeaderText="Monto<br />Castigado">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DEUDA_REINTEGRO" HeaderText="Deuda Reintegro<br />de Equipo">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SERVICIOS" HeaderText="Cantidad de Planes/<br />Servicios">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_BLOQUEOS" HeaderText="Cantidad de<br />Bloqueados">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CANTIDAD_SUSPENDIDOS" HeaderText="Cantidad de<br />Suspendidos">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<img id="btnMostrarDetalleSISACT" name="btnMostrarDetalleSISACT" src="../../images/ico_lupa.gif"
												style="CURSOR: pointer;" alt="Ver Detalle Linea" runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<input id="hidCodCuentaSISACT" type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "CODIGO_CUENTA")%>' size="1" name="hidCodCuentaSISACT"
										runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr id="detalle_linea_header" runat="server">
					<td class="Header" height="20" colSpan="5" align="left"><%= ConfigurationSettings.AppSettings("PopopDetalleLineaTituloLineas") %></td>
				</tr>
				<tr id="detalle_linea_body" runat="server">
					<td align="left"><asp:datagrid id="dgListaLineas" runat="server" AutoGenerateColumns="False" CellPadding="5" EnableViewState="False">
							<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
							<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE" HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Wrap="False" HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="LINEA_PREPAGO" HeaderText="Linea Prepago">
									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="100"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PLAN" HeaderText="Plan">
									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="90"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ESTADO" HeaderText="Estado">
									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="90"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TIPO_BLOQUEO" HeaderText="Tipo de bloqueo">
									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="120"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td height="100" colSpan="5" align="center"><input style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand" id="btnCancelar" class="BotonOptm"
							onmouseover="this.className='BotonResaltado';" tabIndex="123" onmouseout="this.className='BotonOptm';" onclick="javascript:cerrarVentana();"
							value="Cerrar" type="button" name="btnCancelar"></td>
				</tr>
			</table>
			<input id="hidAccion" type="hidden" name="hidAccion" runat="server"> <input id="hidTokensApellido" type="hidden" name="hidTokensApellido" runat="server">
			<input id="hidNombres" type="hidden" name="hidNombres" runat="server"> <input id="hidApellidos" type="hidden" name="hidApellidos" runat="server">
			<input id="hidRazonSocial" type="hidden" name="hidRazonSocial" runat="server"> <input id="hidPlanesActivos" type="hidden" name="hidPlanesActivos" runat="server">
			<input id="hidNroLineas" type="hidden" value="0" name="hidNroLineas" runat="server">
			<input id="hidNroLineasBSCS" type="hidden" value="0" name="hidNroLineasBSCS" runat="server">
			<input id="hidTieneSECPendiente" type="hidden" name="hidTieneSECPendiente" runat="server">
			<input id="hidNroDoc" type="hidden" name="hidNroDoc" runat="server"> <input id="hidTipoDoc" type="hidden" name="hidTipoDoc" runat="server">
			<input id="hidClienteExiste" type="hidden" name="hidClienteExiste" runat="server">
			<input id="hidClienteClaro" type="hidden" name="hidClienteClaro" runat="server">
			<input id="hidBlackList" type="hidden" name="hidBlackList" runat="server"> <input id="hidLblDeudaBloqueo" type="hidden" name="hidLblDeudaBloqueo" runat="server">
			<input id="hidLblCliente" type="hidden" name="hidLblCliente" runat="server"> <input id="hidEvaluarMovil" type="hidden" name="hidEvaluarMovil" runat="server">
			<input id="hidPlanesDatosVoz" type="hidden" name="hidPlanesDatosVoz" runat="server">
			<input id="hidCalificacionPago" type="hidden" name="hidCalificacionPago" runat="server">
			<input id="hidnrolinea" type="hidden" name="hidnrolinea" runat="server"> <input id="hidservicios" type="hidden" name="hidservicios" runat="server">
			<input id="hidplancomercial" type="hidden" name="hidplancomercial" runat="server">
			<input id="hidcargofijo" type="hidden" name="hidcargofijo" runat="server"> <input id="hidCodError" type="hidden" name="hidCodError" runat="server">
			<input id="hidErrorConsulta" type="hidden" name="hidErrorConsulta" runat="server">
			<input id="hidTop" type="hidden" name="hidTop" runat="server">
			<!--Inicio Renovacion Por Bloqueo JAZ-->
			<input id="hidCoId" type="hidden" name="hidCoId" runat="server"> <input id="hidCanalActual" type="hidden" name="hidCanalActual" runat="server">
			<!--Fin Renovacion Por Bloqueo JAZ-->
		</form>
	</body>
</HTML>
