<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_consulta_venta_cuotas.aspx.vb" Inherits="sisact_consulta_venta_cuotas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_consulta_venta_cuotas</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
		
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
				return f_ComprobarBusqueda();
			}
			 
			function f_ComprobarBusqueda()
			{
				if ((getValue('ddlTipoDocumento') == '00' || getValue('txtNroDoc') == '') && getValue('txtNroLinea') == '' && getValue('txtIMEI') == '')
				{
					alert('Debe especificar algún parámetro de búsqueda.');
					return false;
				}
				
				if (getValue('txtNroLinea').length > 0 && getValue('txtNroLinea').length < 9)
				{
					alert('Debe especificar un telefono válido.');
					return false;
				}
							
				return true;
			}
		
		</script>
	</HEAD>
	<body>
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td class="Contenido">
						<table cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="header" style="HEIGHT: 19px" align="left" colspan="5">&nbsp;Consulta 
									Venta en Cuotas</td>
							</tr>
							<tr>
								<td class="Arial10b">&nbsp;Tipo Documento:</td>
								<td class="Arial10b"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="clsSelectEnableC" Width="120px" onChange="cambiarTipoDocumento();">
										<asp:ListItem Value="00">-- SELECCIONAR --</asp:ListItem>
										<asp:ListItem Value="01">DNI</asp:ListItem>
										<asp:ListItem Value="04">CE</asp:ListItem>
										<asp:ListItem Value="06">RUC</asp:ListItem>
									</asp:dropdownlist></td>
								<td class="Arial10b">&nbsp;Nro. Documento:</td>
								<td class="Arial10b">&nbsp;<INPUT class="clsInputEnabled" onkeypress="validaCaracteres('0123456789')" id="txtNroDoc"
										maxLength="8" size="22" name="txtNroDoc" runat="server">
								</td>
								<td>&nbsp;
									<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Height="19" Text="Buscar"
										Runat="server"></asp:button>&nbsp;
									<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Height="19" Text="Limpiar"
										Runat="server"></asp:button>&nbsp;
									<asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
										onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Height="19" Text="Exportar"
										Runat="server"></asp:button></td>
							</tr>
							<tr>
								<td class="Arial10b" style="HEIGHT: 26px">&nbsp;Nro. Línea:</td>
								<td class="Arial10b"><INPUT class="clsInputEnabled" onkeypress="validaCaracteres('0123456789')" id="txtNroLinea"
										maxLength="9" size="21" name="txtNroLinea" runat="server"></td>
								<td class="Arial10b">&nbsp;IMEI:</td>
								<td class="Arial10b" colSpan="2">&nbsp;<INPUT class="clsInputEnabled" onkeypress="validaCaracteres('0123456789')" id="txtIMEI"
										maxLength="18" size="22" name="txtIMEI" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trGrilla">
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="1250px" autogeneratecolumns="False"
										showheader="True" AllowPaging="True" PageSize="20">
										<HeaderStyle CssClass="TablaTitulos" BackColor="#E9EBEE"></HeaderStyle>
										<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
										<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="DNI/RUC" DataField="nro_documento">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="RAZÓN SOCIAL/NOMBRES" DataField="cliente">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="IMEI" DataField="imei">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MODELO" DataField="des_equipo">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="200px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="TELEFONO" DataField="telefono">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="NRO CUOTAS" DataField="nro_cuotas">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="BOLETA/FACTURA" DataField="documento_venta">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="100px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="PRECIO VENTA" DataField="precio_venta">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="PRECIO LISTA" DataField="precio_lista">
												<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Font-Size="11px" CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
