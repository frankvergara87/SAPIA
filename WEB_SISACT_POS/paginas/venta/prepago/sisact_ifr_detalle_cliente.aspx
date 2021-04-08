<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_detalle_cliente.aspx.vb" Inherits="sisact_ifr_detalle_cliente" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Sisact - Pool Venta Express</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name=vs_defaultClientScript content="JavaScript">
		<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-Equiv="Cache-Control" Content="no-cache">
		<meta http-Equiv="Pragma" Content="no-cache">
		<meta http-Equiv="Expires" Content="0">
		<link href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/funciones_express.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			function inicio() {
				mostrarMensaje();
			}
		</script>
	</head>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" MS_POSITIONING="GridLayout" onkeydown="cancelBack();" onload='inicio();'>
		<form id="frmDetalleCliente" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<!-- Inicio Tabla Datos del Cliente -->
				<tr id="trPaso3">
					<td>
					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<!-- Inicio Tabla Datos del Cliente -->
						<tr id="trCliente" runat="server">
							<td>
								<table cellPadding="0" width="100%" border="0">
									<tr>
										<td class="header" height="20">&nbsp;Datos del Cliente</td>
									</tr>
									<tr>
										<td>
											<table class="contenido" cellSpacing="1" cellPadding="0" width="100%" border="0">
												<tr id="trDocIdentidad" runat="server">
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Tipo de Documento</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtTipoDoc" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="100px" Enabled="false"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">
														&nbsp;Numero&nbsp;<asp:Label id="lblTipoDoc" runat="server" cssclass="Arial10B"></asp:Label>
													</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtNumDoc" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="120px" Enabled="false"></asp:TextBox></td>
												</tr>											
												<tr id="trNombre" runat="server">
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Nombre(s)</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtNombre" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px" Enabled="false"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Apellido Paterno</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtApPat" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px" Enabled="false"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Apellido Materno</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtApMat" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px" Enabled="false"></asp:TextBox></td>
												</tr>
												<tr id="trReferencia" runat="server">
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Referencia</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 515px" colspan="4"><asp:TextBox id="txtReferenciaCliente" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="507px"></asp:TextBox></td>
												</tr>
												<tr id="trUbigeo" runat="server">
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Departamento</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtDepartamentoCliente" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Provincia</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtProvinciaCliente" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Distrito</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtDistritoCliente" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<!-- Fin Tabla Datos de Facturación -->
						<!-- Inicio Tabla Datos del Cliente -->
						<tr id="trFacturacion" runat="server">
							<td>
								<table cellPadding="0" width="100%" border="0">
									<tr>
										<td class="header" height="20">&nbsp;Datos de Facturación</td>
									</tr>
									<tr>
										<td>
											<table class="contenido" cellSpacing="1" cellPadding="0" width="100%" border="0">
												<tr>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Dirección</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 515px" colspan="4"><asp:TextBox id="txtDireccionFactura" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="507px"></asp:TextBox></td>
												</tr>
												<tr>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Referencia</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 515px" colspan="4"><asp:TextBox id="txtReferenciaFactura" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="507px"></asp:TextBox></td>
												</tr>
												<tr>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Departamento</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtDepartamentoFactura" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Provincia</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtProvinciaFactura" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Distrito</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 190px"><asp:TextBox id="txtDistritoFactura" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:TextBox></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<!-- Fin Tabla Datos de Facturación -->
						<!-- Inicio Tabla Datos del Pago -->
						<tr id="trPago" runat="server">
							<td>
								<table cellPadding="0" width="100%" border="0">
									<tr>
										<td class="header" height="20">&nbsp;Datos del Pago</td>
									</tr>
									<tr>
										<td>
											<table class="contenido" cellSpacing="1" cellPadding="0" width="100%" border="0">
												<tr>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Forma de Pago</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 880px"><asp:TextBox id="txtFormaPago" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="120px"></asp:TextBox></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<!-- Fin Tabla Datos del Pago -->
						<!-- Inicio Tabla Datos Garantia -->
						<tr id="trGarantia" runat="server">
							<td>
								<table cellPadding="0" width="100%" border="0">
									<tr>
										<td class="header" height="20">&nbsp;Datos de la Garantia</td>
									</tr>
									<tr>
										<td>
											<table class="contenido" cellSpacing="1" cellPadding="0" width="100%" border="0">
												<tr>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Tipo de Garantia</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 410px"><asp:TextBox id="txtTipoGarantia" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="150px"></asp:TextBox></td>
													<td class="Arial10B" style="WIDTH: 120px">&nbsp;Monto</td>
													<td class="Arial10B" style="WIDTH: 15px">:</td>
													<td class="Arial10B" style="WIDTH: 320px"><asp:TextBox id="txtMontoGarantia" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="150px"></asp:TextBox></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<!-- Fin Tabla Datos Garantia -->
						<!-- Inicio Boton Siguiente (Mostrar Datos de cada Plan) -->
						<tr id="trPasoSiguiente">
							<td>
								<table cellSpacing="2" cellPadding="0" width="100%" border="0">
									<tr>
										<td class="Arial10B" style="WIDTH: 100%" align="right">
											<asp:Button CssClass="Boton" id="btnPaso3" Runat="server" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" Text="Siguiente -->" disabled="disabled" />
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					</td>
				</tr>
			</table>
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server" style="WIDTH: 16px; HEIGHT: 22px" size="1">
		</form>
	</body>
</html>
 
 
 
 
