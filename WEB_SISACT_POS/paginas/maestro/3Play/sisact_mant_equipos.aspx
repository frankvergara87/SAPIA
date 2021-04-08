<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_equipos.aspx.vb" Inherits="sisact_mant_equipos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_equipo3Play</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
        
        function f_GruposSeleccionados()
        {
            var strSel = '';
            var elmFrm=document.getElementsByTagName("input");
            var strIdChk = '';
            for (i=0;i<elmFrm.length;i++)
            {
				if (elmFrm[i].type=="checkbox")
				{
					if (elmFrm[i].checked)
					{
						strIdChk  = elmFrm[i].id;
						strSel += strIdChk + '|';                                    
					}
				}
            }
            strSel = strSel.substring(0,strSel.length - 1);
            setValue('hidGrupoSeleccion',strSel);
            return true;
        }     
           
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
				setValue('hidGrupo','');
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
			    setValue('hidObtValor', 'N');
			    document.getElementById('txtCodigo').readOnly = false;
				document.getElementById('txtCodigo').className = 'clsInputEnable';
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
				setValue('hidObtValor', 'E');
				document.getElementById('txtCodigo').readOnly=true;
				document.getElementById('txtCodigo').className = 'clsInputDisable';
			}
			
			var obj = document.getElementById('hidGrupo');
			var str = obj.value; 
			var arr1 = str.split('|');
			for(i=0;i<arr1.length;i++){
                if(arr1[i]!=''){
                    var objChk = document.getElementById(arr1[i]);
                    objChk.checked=true;               
                }
            }
		}
		
		function f_Inicio()
		{
            f_MostrarTab('BUSQUEDA');
		}
		
		function f_ConfirmarGrabar()
		{	
			f_GruposSeleccionados();
			if (!f_ValidarGrabar())
				return false;
				
			if (confirm('¿Desea guardar los cambios?'))
				return true;
			else
				return false;
		}
			
		function f_ValidarGrabar()
		{			
			if (getValue('txtCodigo') == '')
			{
				alert('Debe ingresar el código del equipo.');
                document.getElementById("txtCodigo").focus();
				return false;
			}
			if (getValue('txtDescripcion') == '')
			{
				alert('Debe ingresar la descripción.');
				document.getElementById("txtDescripcion").focus();
				return false;
			}
			if (getValue('hidGrupoSeleccion') == '')
			{
				alert('Debe seleccionar al menos un grupo.');
				return false;
			}
			if (getValue('txtCodigoE') == '' || getValue('txtDescripcionE') == '')
			{
				alert('Debe validar el equipo.');
				document.getElementById("btnValidar").focus();
				return false;
			}
			
			return true;
		}
		
		function f_Modificar(codEqui)
		{
			setValue('hidEquiCodigo',codEqui);
			__doPostBack('btnModificar','');
		}
		
		function f_Eliminar(codEqui)
		{
			if (confirm('¿Esta seguro de desactivar este registro?'))
			{
				setValue('hidEquiCodigo',codEqui);
				__doPostBack('btnEliminar','');
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
        
		function f_ValidarEquipo()
		{
			var url = '../sisact_pop_varios.aspx?strTipo=Eqp';
			var str = window.showModalDialog(url, '', 'dialogHeight:400px; dialogWidth:500px');
			if (str != null)
			{
				if (str.indexOf('|') > 0)
				{
					var arrValores = str.split('|');
					setValue('txtCodigoE', arrValores[0]);
					setValue('txtDescripcionE', arrValores[1]);
					setValue('hidTipEqu', arrValores[2]);
				}
			}			
		}
        
		</script>
	</HEAD>
	<body onkeydown="cancelarBackSpace();" MS_POSITIONING="GridLayout">
		<form id="FrmEquipos" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">MANTENIMIENTO 
						DE EQUIPOS 3PLAY</td>
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
															Equipos</td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Equipo :</TD>
														<td>&nbsp;<asp:dropdownlist id="ddlBusqueda" CssClass="clsSelectEnable" Width="100px" Runat="server">
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
														<td>&nbsp;<asp:dropdownlist id="ddlEstadoEquipo3Play" CssClass="clsSelectEnable" Width="100px" Runat="server">
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
													width="550px">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="CÓDIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="EQUIPOS">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="300px"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="55px"></headerstyle>
														</asp:templatecolumn>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos"></headerstyle>
														</asp:boundcolumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 620px">
										<table cellSpacing="0" cellPadding="0" width="550" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" showheader="False" autogeneratecolumns="False"
														width="550px" AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "MATV_CODIGO")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="MATV_CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="MATV_DESCRIPCION">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="300px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="55px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "MATV_CODIGO")%>");'>
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
											<td class="header" colSpan="5" height="25">Detalle del Equipo</td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 130px">&nbsp;Código</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtCodigo"
													runat="server" MaxLength="10" width="70px" DESIGNTIMEDRAGDROP="64" cssclass="clsInputEnable"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 130px">&nbsp;Descripción</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtDescripcion"
													ondrop="return false;" runat="server" width="350px" cssclass="clsInputEnable" maxlength="60"></asp:textbox></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 130px">&nbsp;Tipo</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlTipoEquipos" runat="server" width="125px" cssclass="clsSelectEnable"></asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 130px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstadoEquipos" runat="server" width="125px" cssclass="clsSelectEnable"></asp:dropdownlist></td>
											<td class="Arial10B" colSpan="2"></td>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 130px">&nbsp;Grupos</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" colSpan="3"><br>
												<div class="clsGridRow" id="divGrillaLstGrupo" style="WIDTH: 300px; HEIGHT: 210px"><asp:datagrid id="dgrListadoGrupo" runat="server" CssClass="Arial10B" Height="30px" showheader="False"
														autogeneratecolumns="False" width="260px">
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<INPUT type="checkbox" id='<%# DataBinder.Eval(Container.DataItem, "GSRVC_CODIGO")%>'>
																	<span>
																		<%# DataBinder.Eval(Container.DataItem, "GSRVV_DESCRIPCION")%>
																	</span>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></div>
											</td>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 130px">Equipo en Operaciones</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" colSpan="3">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:textbox onpaste="return false;" id="txtCodigoE" ondrop="return false;" runat="server" MaxLength="4"
																width="60px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
														<td>&nbsp;
															<asp:textbox onpaste="return false;" id="txtDescripcionE" runat="server" width="320px" cssclass="clsInputDisable"
																maxlength="50" ReadOnly="True"></asp:textbox></td>
														<td>&nbsp; <INPUT class="Boton" id="btnValidar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px"
																onclick="f_ValidarEquipo();" onmouseout="this.className='Boton';" type="button" value="Validar Equipo"
																name="btnValidar">
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<tr vAlign="bottom" height="35">
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
			<input id="hidEquiCodigo" type="hidden" name="hidEquiCodigo" runat="server"> <input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server">
			<input id="hidGrupo" type="hidden" name="hidGrupo" runat="server"> <input id="hidGrupoSeleccion" type="hidden" name="hidGrupoSeleccion" runat="server">
			<input id="hidObtValor" type="hidden" name="hidObtValor" runat="server"> <input id="hidTipEqu" type="hidden" name="hidTipEqu" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
