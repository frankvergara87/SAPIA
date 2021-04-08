<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_servicio.aspx.vb" Inherits="sisact_mant_servicio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_servicio3Play</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">

        function f_InactivarTxtLista()
		{
			txtBusDescripcion = document.getElementById('<%=txtBusDescripcion.ClientId%>');
			txtBusDescripcion.value = '';
		
			if (getValue('ddlBusqueda') == '1')
			{
				txtBusDescripcion.readOnly = true;
				txtBusDescripcion.className = 'clsInputDisable';
			}
			else
			{
				txtBusDescripcion.readOnly = false;
				txtBusDescripcion.className = 'clsInputEnable';
				txtBusDescripcion.focus();
			}
		}
        
        function f_Buscar()
		{					
			if (getValue('ddlBusqueda') == '0' && getValue('txtBusDescripcion') == '')
			{
				alert('Debe ingresar una Descripción');
				return false;
			}
		}
		
		function f_Limpiar()
		{
			setValue('txtBusDescripcion', '');
		}
        
        function f_ValidarEnter()
		{	
			if (document.all)
			{
				if (event.keyCode == 13)
				{	
					//f_Buscar();
					document.getElementById('<%=btnBuscar.ClientId%>').click();
					event.keyCode = 0;
				}
			}
		}
		
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
				//document.getElementById('txtCodigo').readOnly = false;
				//document.getElementById('txtCodigo').className = 'clsInputEnable';
				document.getElementById('btnValidar').style.display = '';
			}
			if (valor == 'EDICION')
			{
				setVisible('trBusqueda',false);	
				setVisible('trGrilla',false);
				setVisible('trEdicion', true);	
				
				document.getElementById('tdListado').className='tab_inactivo';
				document.getElementById('tdAgregar').style.display='none';
				document.getElementById('tdModificar').style.display='inline';
				document.getElementById('tdModificar').className='tab_activo';
				//document.getElementById('txtCodigo').readOnly = true;
				//document.getElementById('txtCodigo').className = 'clsInputDisable';
				document.getElementById('btnValidar').style.display = 'none';
			}
		}
		
		function f_Inicio()
		{
			f_MostrarTab('BUSQUEDA');
		}
		
		function f_Modificar(codServ)
		{
			setValue('hidServCodigo',codServ);
			__doPostBack('btnModificar','');
		}
			
		function f_Eliminar(codServ)
		{
			if (confirm('¿Esta seguro de desactivar este registro?'))
			{
				setValue('hidServCodigo',codServ);
				__doPostBack('btnEliminar','');
			}
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
			
		function f_ValidarGrabar()
		{	
			if (getValue('txtCodigo') == '' || getValue('txtDescripcionBSCS') == '')
			{
				alert('Debe validar el Servicio.');
				document.getElementById("btnValidar").focus();
				return false;
			}
			if (getValue('txtCodExterno') == '')
			{
				alert('Debe seleccionar el código externo');
				document.getElementById("btnValidarCodExterno").focus();
				return false;
			}
//gaa20131003
			if (getValue('txtDescripcion') == '')
			{
				alert('Debe ingresar la descripción SISACT');
				document.getElementById("<%=txtDescripcion.ClientId %>").focus();
				return false;
			}
//fin gaa20131003			
			/*if (getValue('txtOrden') == '')
			{
				alert('Debe ingresar el orden');
				document.getElementById("txtOrden").focus();
				return false;
			}
			else
			{
				if (Number(document.getElementById('<%=txtOrden.ClientId%>').value) < 1)
				{
					alert('El orden debe ser mayor a 0');
					document.getElementById("txtOrden").focus();
					return false;
				}
			}*/
			
			return true;
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
		
		function f_ValidarServicio()
		{
			var url = '../sisact_pop_varios.aspx?strTipo=Srv';
			var str = window.showModalDialog(url, '', 'dialogHeight:400px; dialogWidth:500px');
			
			if (str != null)
			{
				if (str.indexOf('|') > 0)
				{
					var arrValores = str.split('|');
					setValue('txtCodigo', arrValores[0]);
					setValue('txtDescripcionBSCS', arrValores[1]);
				}
			}
		}
//gaa20130923
		function f_ValidarServicioCodExt()
		{
			var url = '../sisact_pop_varios.aspx?strTipo=Sce';
			var str = window.showModalDialog(url, '', 'dialogHeight:400px; dialogWidth:500px');
			
			if (str != null)
			{
				if (str.indexOf('|') > 0)
				{
					var arrValores = str.split('|');
					setValue('hidIdConfigITW', arrValores[0]);
					setValue('hidDescripcion', arrValores[1]);
					setValue('txtCodExterno', arrValores[2]);
				}
			}		
		}
//fin gaa20130923
		</script>
	</HEAD>
	<body onkeydown="cancelarBackSpace();" MS_POSITIONING="GridLayout">
		<form id="FrmServicios3Play" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">MANTENIMIENTO 
						DE SERVICIOS 3PLAY</td>
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
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('EDICION');">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="1" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Servicios</td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Servicio :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlBusqueda" tabIndex="0" CssClass="clsSelectEnable" Width="100px" Runat="server">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" CssClass="clsInputEnable"
																Width="300px" MaxLength="50"></asp:textbox>
															&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Buscar"
																Height="19"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Runat="server" Text="Limpiar"
																Height="19"></asp:button></td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Estado :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlEstadoServ3Play" CssClass="clsSelectEnable" Width="100px" Runat="server">
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
															</asp:dropdownlist>
														</td>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" showheader="True" autogeneratecolumns="False"
													width="700px">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CÓDIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="60px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="DESCRIPCION">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="GRUPO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="60px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ORDEN" Visible="False">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 980px">
										<table cellSpacing="0" cellPadding="0" width="700" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalleServicios" runat="server" showheader="False" autogeneratecolumns="False"
														width="700px" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "servv_codigo")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="servv_codigo">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="servv_descripcion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="GSRVV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="SERVN_ORDEN" Visible="False">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "servv_codigo")%>");'>
																		<img src="../../../images/ico_Eliminar.gif" border="0" alt='Desactivar'></a>
																</ItemTemplate>
															</asp:TemplateColumn>
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
									<table cellSpacing="1" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">Detalle del Servicio</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 116px">&nbsp;Código BSCS</td>
											<td class="Arial10B" style="WIDTH: 31px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onpaste="return false;" id="txtCodigo" runat="server" width="60px" DESIGNTIMEDRAGDROP="64"
													cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">&nbsp;Descripción BSCS</td>
											<td class="Arial10B" style="WIDTH: 31px; HEIGHT: 19px">:</td>
											<td class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td>
															<asp:textbox onpaste="return false;" id="txtDescripcionBSCS" runat="server" width="320px" ReadOnly="True"
																cssclass="clsInputDisable" DESIGNTIMEDRAGDROP="78" maxlength="50"></asp:textbox>&nbsp;</td>
														<td><INPUT class="Boton" id="btnValidar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
																onclick="f_ValidarServicio();" onmouseout="this.className='Boton';" type="button" value="Validar Servicio"
																name="btnValidar">
														</td>
													</tr>
												</table>
											</td>
											<td class="Arial10B" style="HEIGHT: 19px" colSpan="2"></td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">&nbsp;Código Externo</TD>
											<TD class="Arial10B" style="WIDTH: 31px; HEIGHT: 19px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD>
															<asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtCodExterno"
																ondrop="return false;" runat="server" width="320px" ReadOnly="True" cssclass="clsInputDisable"></asp:textbox></TD>
														<TD>&nbsp;<INPUT class="Boton" id="btnValidarCodExterno" onmouseover="this.className='BotonResaltado';"
																style="WIDTH: 135px; CURSOR: hand; HEIGHT: 19px" onclick="f_ValidarServicioCodExt();" onmouseout="this.className='Boton';"
																type="button" size="20" value="Validar Código Externo" name="btnValidar">
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 116px; HEIGHT: 19px">&nbsp;Descripción SISACT</TD>
											<TD class="Arial10B" style="WIDTH: 31px; HEIGHT: 19px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px; HEIGHT: 19px"><asp:textbox onpaste="return false;" id="txtDescripcion" runat="server" width="320px" cssclass="clsInputEnable"
													maxlength="50"></asp:textbox></TD>
											<TD class="Arial10B" style="HEIGHT: 19px" colSpan="2"></TD>
										</TR>
										<tr>
											<td class="Arial10B" style="WIDTH: 116px; HEIGHT: 22px">&nbsp;Grupo</td>
											<td class="Arial10B" style="WIDTH: 31px; HEIGHT: 22px">:</td>
											<td class="Arial10B" style="WIDTH: 650px; HEIGHT: 22px"><asp:dropdownlist id="ddlGrupo" runat="server" width="250px" cssclass="clsSelectEnable"></asp:dropdownlist></td>
											<td class="Arial10B" style="HEIGHT: 22px" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 116px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 31px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="100px" cssclass="clsSelectEnable"></asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr style="DISPLAY: none">
											<td class="Arial10B" style="WIDTH: 116px">&nbsp;Orden</td>
											<td class="Arial10B" style="WIDTH: 31px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return f_EventoSoloNumeros();" id="txtOrden" runat="server" width="100px"
													DESIGNTIMEDRAGDROP="64" cssclass="clsInputEnable"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr height="25">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Aceptar" Height="19"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" CssClass="Boton" Width="126" Runat="server" Text="Cancelar"
													Height="19"></asp:button></td>
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
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input id="hidServCodigo" type="hidden" name="hidServCodigo" runat="server"> <input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server">
			<input id="hidIdConfigITW" type="hidden" name="hidIdConfigITW" runat="server"> <input id="hidDescripcion" type="hidden" name="hidDescripcion" runat="server">
			<input id="hidIdSISACT" type="hidden" name="hidIdSISACT" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
