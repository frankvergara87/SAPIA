<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_idvalidator.aspx.vb" Inherits="sisact_mant_idvalidator" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Mantenimiento ID Validator</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
		<LINK title="win2k-cold-1" rel="stylesheet" type="text/css" href="../../estilos/calendar-blue.css"
			media="all">
		<script language="JavaScript" src="../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script type="text/javascript" src="../../Script/calendar/calendar.js"></script>
		<script type="text/javascript" src="../../Script/calendar/calendar_es.js"></script>
		<script type="text/javascript" src="../../Script/calendar/calendario_call.js"></script>
		<script type="text/javascript" src="../../Script/calendar/calendar_setup.js"></script>
		<script language="javascript" type="text/javascript">
			function f_MostrarTab(valor)
				{				
					if (valor == 'WHITELIST')
					{
						setValueHTML('lblTipoLista','Whitelist');
						setValueHTML('lblTipoListaE','Whitelist');
						setValue('hidTipoLista','W');
						
						setVisible('trBusqueda', true);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);
						setVisible('trPDV', false);		
						setVisible('trAgregarMant', false);
						setVisible('trConfiguracion', false);
						
						document.getElementById('tdWhiteList').className='tab_activo';
						document.getElementById('tdBlackList').style.display='inline';
						document.getElementById('tdBlackList').className='tab_inactivo';
						
						document.getElementById('tdListado').className='tab_activo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						document.getElementById('tdCargaMasiva').style.display='';
					}
					if (valor == 'BLACKLIST')
					{
						setValueHTML('lblTipoLista','Blacklist');
						setValueHTML('lblTipoListaE','Blacklist');
						setValue('hidTipoLista','B');
						setVisible('trBusqueda', true);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);
						setVisible('trPDV', false);
						setVisible('trAgregarMant', false);
						setVisible('trConfiguracion', false);	
						
						document.getElementById('tdWhiteList').className='tab_inactivo';
						document.getElementById('tdBlackList').style.display='inline';
						document.getElementById('tdBlackList').className='tab_activo';
						
						document.getElementById('tdListado').className='tab_activo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						document.getElementById('tdCargaMasiva').style.display='';
					}
				
					if (valor == 'NUEVO')
					{
						setVisible('trBusqueda',false);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);	
                        setVisible('trPDV', false);
						setVisible('trAgregarMant',false);
						setVisible('trConfiguracion', false);	
						
						document.getElementById('tdListado').className='tab_inactivo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_activo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						
						if (getValue('hidTipoLista') == 'W' ){
							setVisible('trEdicion', true);
						    setVisible('trBusqueda',false);	
						    setVisible('trGrilla',false);
							document.getElementById('tdWhiteList').className='tab_activo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_inactivo';
												    							
							setValueHTML('lblTipoLista','Whitelist');
							setValueHTML('lblTipoListaE','Whitelist');
						
						}
						if (getValue('hidTipoLista') == 'B' ){
							setVisible('trEdicion', true);
							document.getElementById('tdWhiteList').className='tab_inactivo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_activo';
							setValueHTML('lblTipoLista','Blacklist');
							setValueHTML('lblTipoListaE','Blacklist');
						}
					}
					if (valor == 'BUSQUEDA'){
					
						setVisible('trBusqueda', false);	
						//setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);
						setVisible('trPDV', false);
						setVisible('trAgregarMant',false);
						setVisible('trConfiguracion', false);		
						setVisible('tblPDV', false);							
						
						
						document.getElementById('tdListado').className='tab_activo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						
						if (getValue('hidTipoLista') == 'W' ){
						    setVisible('trBusqueda', true);	
						    //setVisible('trGrilla',true);
							document.getElementById('tdWhiteList').className='tab_activo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_inactivo';
							document.getElementById('tdCargaMasiva').className='tab_inactivo';
						    
							setValueHTML('lblTipoLista','Whitelist');
							setValueHTML('lblTipoListaE','Whitelist');
						
						}
						if (getValue('hidTipoLista') == 'B' ){
					        setVisible('trBusqueda', true);	
						    //setVisible('trGrilla',true);
							document.getElementById('tdWhiteList').className='tab_inactivo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_activo';
							document.getElementById('tdCargaMasiva').className='tab_inactivo';
						    
							setValueHTML('lblTipoLista','Blacklist');
							setValueHTML('lblTipoListaE','Blacklist');
						}						
					}
					if (valor == 'LIMPIAR'){
					
						setVisible('trBusqueda', false);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);
						setVisible('trPDV', false);
						setVisible('trAgregarMant',false);
						setVisible('trConfiguracion', false);		
						setVisible('tblPDV', false);							
						
						
						document.getElementById('tdListado').className='tab_activo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						
						if (getValue('hidTipoLista') == 'W' ){
						    setVisible('trBusqueda', true);	
						    setVisible('trGrilla',false);
							document.getElementById('tdWhiteList').className='tab_activo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_inactivo';
							document.getElementById('tdCargaMasiva').className='tab_inactivo';
						    
							setValueHTML('lblTipoLista','Whitelist');
							setValueHTML('lblTipoListaE','Whitelist');
						
						}
						if (getValue('hidTipoLista') == 'B' ){
					        setVisible('trBusqueda', true);	
						    setVisible('trGrilla',false);
							document.getElementById('tdWhiteList').className='tab_inactivo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_activo';
							document.getElementById('tdCargaMasiva').className='tab_inactivo';
						    
							setValueHTML('lblTipoLista','Blacklist');
							setValueHTML('lblTipoListaE','Blacklist');
						}						
					}
					if (valor == 'CARGAMASIVA'){
						setVisible('trBusqueda',false);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', true);
						setVisible('trPDV', false);
						setVisible('trAgregarMant',false);
						setVisible('trConfiguracion', false);	
						
						document.getElementById('tdListado').className='tab_inactivo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_activo';
						
						if (getValue('hidTipoLista') == 'W' ){
							document.getElementById('tdWhiteList').className='tab_activo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_inactivo';
							setValueHTML('lblTipoLista','Whitelist');
							setValueHTML('lblTipoListaE','Whitelist');
						
						}
						if (getValue('hidTipoLista') == 'B' ){
							document.getElementById('tdWhiteList').className='tab_inactivo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_activo';
							setValueHTML('lblTipoLista','Blacklist');
							setValueHTML('lblTipoListaE','Blacklist');
						}
						if (getValue('hidErrorCarga') == 'ERROR' ){
							document.getElementById('dvError').style.display='';	  
						}else{
							document.getElementById('dvError').style.display='none';
						}						
					}
					
					if (valor == 'EDICION')
					{
						setVisible('trBusqueda',false);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', true);
						setVisible('trCargaMasiva', false);	
						setVisible('trConfiguracion',false); 	
						setVisible('trAgregarMant',false); 
						setVisible('trPDV', false);		
																					
						setVisible('dgConfGen', false);
						
						document.getElementById('tdListado').className='tab_inactivo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_inactivo';
						document.getElementById('tdAgregar').style.display='none';
						document.getElementById('tdModificar').style.display='';
						document.getElementById('tdModificar').className='tab_activo';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						
						if (getValue('hidTipoLista') == 'W' ){
							document.getElementById('tdWhiteList').className='tab_activo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_inactivo';
							setValueHTML('lblTipoLista','Whitelist');
							setValueHTML('lblTipoListaE','Whitelist');
						
						}
						if (getValue('hidTipoLista') == 'B' ){
							document.getElementById('tdWhiteList').className='tab_inactivo';
							document.getElementById('tdBlackList').style.display='inline';
							document.getElementById('tdBlackList').className='tab_activo';
							setValueHTML('lblTipoLista','Blacklist');
							setValueHTML('lblTipoListaE','Blacklist');
						}																	
					}				
				}
		
			function f_Inicio()
				{
					f_MostrarTab('WHITELIST');
				}
				
			function f_EventoSoloNumeros(event)
				{
					if (event.keyCode == 8 || event.keyCode == 46) {
					return;
				}
				if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
					return;
				}
				var key = event.keyCode;
				if ((key < 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key == 33) || (key == 34) || (key == 35) || (key == 36)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
					return;
				eventoSoloNumeros(event);
				}
				
				function eventoSoloNumeros(){
					// NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57		
					var key = event.keyCode;	
					if ((key <= 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key == 33) || (key == 34) || (key == 35) || (key == 36)|| (key == 37) || (key == 38) || (key == 39) || (key == 40)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
						event.returnValue = true;
					else
						event.returnValue = false;	
				}
				
			function isNum(text){
				if(isNaN(text))
					return false
				else
				return true;
			}	
				
			
			function f_TraerNombre(nroDocumento)
			{
				//if (f_ValidarNombre())
					__doPostBack('btnTraerCliente','');
			}	
			
			function fActivarVigencia(boo, borrar)
			{
				var txtVigenciaDias = document.getElementById('<%=txtVigenciaDias.ClientId %>')
				
				if (borrar)
					txtVigenciaDias.value = '0';
					
				txtVigenciaDias.readOnly = boo;

				if (!boo)
					txtVigenciaDias.className = 'clsInputEnable';
				else
					txtVigenciaDias.className = 'clsInputDisable';
			}
			
			function f_Modificar(codigo) 
			{
				setValue('hidCodigo',codigo);
				__doPostBack('btnModificar','');
			}
		// funciones para trabajar con el sisact_pop_cargarPdv E77314 
			function cargarPopUpPdv()
			{
				window.open("sisact_pop_cargarPdv.aspx",null,"width=800,height=540,top=150px,left=200px");
			}
			function refrescarPdv()
			{
				document.getElementById("hidCondicion").value="PDV";
				frmPrincipal.submit();
			}
			function f_mostrarPestaña(ind){
				document.getElementById("trPDV").style.display='none';
				if(ind == 1) //Campanias
				{
					document.getElementById("trPDV").style.display='block';
				}
						setVisible('trBusqueda',false);	
						setVisible('trGrilla',false);
						setVisible('trEdicion', false);
						setVisible('trCargaMasiva', false);
					    setVisible('trAgregarMant',true);
					    setVisible('trPDV', true);
						setVisible('trConfiguracion', false);
						document.getElementById('tdWhiteList').className='tab_inactivo';
						document.getElementById('tdBlackList').style.display='inline';
						document.getElementById('tdBlackList').className='tab_inactivo';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
					    document.getElementById('tdCargaMasiva').style.display='none';
					    
					    document.getElementById('tdListado').className='tab_inactivo';
						document.getElementById('tdAgregar').style.display='inline';
						document.getElementById('tdAgregar').className='tab_activo';
						document.getElementById('tdModificar').style.display='none';
						document.getElementById('tdCargaMasiva').className='tab_inactivo';
						
						setValue('hidTipoLista','G');	
		
		    }
		    
			function f_ConfirmarEliminarItems()
			{	

				if (confirm('¿Desea eliminar todos los registros?'))
					return true;
				else
					return false;
			}		    		
		    
		   function f_EliminarPDV(cod)
			{
			//alert(cod);
				if (confirm('¿Esta seguro de quitar este registro?'))
				{
					setValue('hidCodigoPDV',cod);
					__doPostBack('btnEliminarPDV','');
				}
			}

			function f_ModificarGeneral(itemGen) 
			{
				setValue('hidCodigoGen',itemGen);
				__doPostBack('btnModifGeneral',''); 
			}
			function f_mostrarGrilla(){
				setVisible('trGrilla',true);
			}
			
			function f_mostrarGrillaGen(){
				setVisible('trGrillaGen', true);
			}	
			
			
			function validarSoloNumeros(txt)
			{
				var strCadena = txt.value
				if (strCadena.length > 0)
				{
					if (!isNumber(strCadena))
						txt.value = '';
				}
			}
			
			function cambiarTipoDocumento(valor)
			{
				document.getElementById('txtBusquedaNroDocumento').value = '';
				var txtBusquedaNroDocumento = document.getElementById('<%=txtBusquedaNroDocumento.ClientId %>');
				if (valor != '00') {
				    txtBusquedaNroDocumento.readOnly = false;
				    txtBusquedaNroDocumento.className = 'clsInputEnable';
					if(valor == '01'){
					  document.getElementById('txtBusquedaNroDocumento').maxLength = 8;
					}else{
					  document.getElementById('txtBusquedaNroDocumento').maxLength = 9;	
					}  
				}else{
					txtBusquedaNroDocumento.readOnly = true;
					txtBusquedaNroDocumento.className = 'clsInputDisable';
					
				}
			}

			function getMaxLengthDocumento(tipoDoc)
			{
				var nroCaracter;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>')
					nroCaracter = 8;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") %>')
					nroCaracter = 9;
				return nroCaracter;
			}
			
			function cambiarNroDoc(valor) {
				document.getElementById('txtNroDocumento').value = '';
				if (valor != '00') {
					if(valor == '01'){
					  document.getElementById('txtNroDocumento').maxLength = 8;
					}else{
					  document.getElementById('txtNroDocumento').maxLength = 9;	
					}  
				}
			}									
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" border="0" cellSpacing="0" cellPadding="0">
				<TBODY>
					<tr>
						<td style="WIDTH: 980px; HEIGHT: 23px" class="header" align="center">Mantenimiento 
							IDVALIDATOR</td>
					</tr>
					<tr>
						<td>
							<table id="tblDetalleLista" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td colSpan="4">
										<table border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td><IMG src="../../spacer.gif" width="2" height="2"></td>
												<td id="tdWhiteList" class="tab_activo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('WHITELIST');">Whitelist</A></td>
												<td><IMG src="../../spacer.gif" width="2" height="2"></td>
												<td id="tdBlackList" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('BLACKLIST');">Blacklist</A></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colSpan="4">
										<table border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td><IMG src="../../spacer.gif" width="2" height="2"></td>
												<td id="tdListado" class="tab_activo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
												<td><IMG src="../../spacer.gif" width="2" height="2"></td>
												<td id="tdAgregar" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:__doPostBack('btnAgregar','');">Agregar</A></td>
												<td id="tdModificar" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('MODIFICAR');">Modificar</A></td>
												<td id="tdCargaMasiva" class="tab_inactivo" borderColor="#000099" width="122" align="center"><A href="javascript:f_MostrarTab('CARGAMASIVA');">Carga 
														Masiva</A></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trBusqueda">
									<td>
										<table border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td style="HEIGHT: 19px" class="header" colSpan="7" align="left">&nbsp;Busqueda de
													<asp:label id="lblTipoLista" Runat="server"></asp:label></td>
											</tr>
											<TR>
												<TD style="HEIGHT: 49px" class="Arial10B">Tipo de Documento</TD>
												<TD style="HEIGHT: 49px" class="Arial10B">:</TD>
												<TD style="WIDTH: 298px; HEIGHT: 49px" class="Arial10B"><asp:dropdownlist id="ddlBusquedaTipoDocumento" runat="server" CssClass="clsSelectEnable" Width="130px"
														onChange="cambiarTipoDocumento(this.value);">
														<asp:ListItem Value="00">TODOS...</asp:ListItem>
														<asp:ListItem Value="01">DNI</asp:ListItem>
														<asp:ListItem Value="04">CE</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD style="HEIGHT: 49px" class="Arial10B">Nro. de Documento</TD>
												<TD style="HEIGHT: 49px" class="Arial10B">:</TD>
												<TD style="HEIGHT: 49px" class="Arial10B"><asp:textbox onblur="f_EventoSoloNumeros(event);" id="txtBusquedaNroDocumento" onkeypress="return f_EventoSoloNumeros(event);"
														onkeydown="return f_EventoSoloNumeros(event);" onpaste="return isNum(window.clipboardData.getData('Text'));" ondrop="return false;"
														runat="server" MaxLength="9" width="100px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<tr>
												<TD class="Arial10B">Rango de Fecha de Registro</TD>
												<TD class="Arial10B">:</TD>
												<TD style="WIDTH: 298px" class="Arial10B">
													<TABLE border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD class="Arial10B"><asp:textbox id="txtBusquedaFechaInicio" runat="server" CssClass="clsInputDisable" Width="80px"
																	ReadOnly="True"></asp:textbox></TD>
															<TD class="Arial10B"><IMG style="BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px"
																	id="btnBusquedaFechaInicio" border="0" src="../../images/calendario.gif">
																<SCRIPT type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtBusquedaFechaInicio",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnBusquedaFechaInicio",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
																</SCRIPT>
															</TD>
															<TD class="Arial10B">&nbsp;al&nbsp;</TD>
															<TD class="Arial10B"><asp:textbox id="txtBusquedaFechaFin" runat="server" CssClass="clsInputDisable" Width="80px"
																	ReadOnly="True"></asp:textbox></TD>
															<TD class="Arial10B"><IMG style="BORDER-BOTTOM: 0px; BORDER-LEFT: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px"
																	id="btnBusquedaFechaFin" border="0" src="../../images/calendario.gif">
																<SCRIPT type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtBusquedaFechaFin",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnBusquedaFechaFin",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
																</SCRIPT>
															</TD>
														</TR>
													</TABLE>
												</TD>
											<tr>
												<td style="HEIGHT: 26px" colSpan="7" align="center"><asp:button style="CURSOR: hand" id="btnBuscar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="90" Text="Buscar" Height="19"></asp:button>&nbsp;
													<asp:button style="CURSOR: hand" id="btnLimpiar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="90" Text="Limpiar"
														Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trGrilla">
									<td>
										<table border="0" cellSpacing="0" cellPadding="0">
											<tr>
												<td colSpan="2"><asp:datagrid id="dgrGrillaDetalle" runat="server" Width="760px" DataKeyField="LISTV_CODIGO" AllowPaging="True"
														autogeneratecolumns="False">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "LISTV_CODIGO")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar cliente'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="LISTV_CODIGO" HeaderText="CODIGO">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTC_TIPO_DOC" HeaderText="TIPO DOC">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTV_NRO_DOC" HeaderText="NRO DOC">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTV_NOMBRE" HeaderText="NOMBRE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="200px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTC_VIGE_INDEF" HeaderText="VIGE INDEF">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTN_VIGE_DIAS" HeaderText="VIGE DIAS">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTC_USUARIO" HeaderText="USUARIO REG">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTD_FCHA_REG" HeaderText="FECHA REG">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="LISTD_FCHA_VIGE" HeaderText="FECHA VIGE">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="70px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<HeaderTemplate>
																	<asp:CheckBox id="chkTotalGrilla" runat="server" AutoPostBack="True" OnCheckedChanged="chkTotalGrilla_CheckedChanged"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:CheckBox ID="fila" Runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td><asp:button style="CURSOR: hand" id="btnEliminar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="135" Text="Eliminar seleccionados"
														Height="19"></asp:button></td>
												<td align="right"><asp:button style="CURSOR: hand" id="btnExportar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="126" Text="Exportar" Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trEdicion">
									<td>
										<table border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="header" height="25" colSpan="7">Detalle de
													<asp:label id="lblTipoListaE" Runat="server"></asp:label></td>
											</tr>
											<TR>
												<TD class="Arial10B">Tipo de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:dropdownlist id="ddlTipoDocumento" onchange="javascript:cambiarNroDoc(this.value);" runat="server"
														CssClass="clsSelectEnable" Width="130px" DESIGNTIMEDRAGDROP="268">
														<asp:ListItem Value="01">DNI</asp:ListItem>
														<asp:ListItem Value="04">CE</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD>&nbsp;</TD>
												<TD class="Arial10B">Nro. de Documento</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox onblur="f_TraerNombre(this.value);" id="txtNroDocumento" onkeypress="return f_EventoSoloNumeros(event);"
														onkeydown="return f_EventoSoloNumeros(event);" onpaste="return isNum(window.clipboardData.getData('Text'));"
														ondrop="return false;" runat="server" width="100px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="1478" MaxLength="8"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 18px" class="Arial10B">Nombres Cliente / Razón Social</TD>
												<TD style="HEIGHT: 18px" class="Arial10B">:</TD>
												<TD style="HEIGHT: 18px" class="Arial10B"><asp:textbox onblur="validarAlfanumerico(this);" id="txtNombre" runat="server" MaxLength="100"
														width="400px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
												<TD style="HEIGHT: 18px"></TD>
												<td style="HEIGHT: 18px" class="Arial10B"></td>
												<td style="HEIGHT: 18px" class="Arial10B"></td>
												<td style="HEIGHT: 18px" class="Arial10B"></td>
											</TR>
											<tr>
												<TD class="Arial10B">Vigencia (días)</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:textbox id="txtVigenciaDias" ondrop="return false;" onkeypress="return f_EventoSoloNumeros(event);"
														onkeydown="return f_EventoSoloNumeros(event);" onpaste="return isNum(window.clipboardData.getData('Text'));"
														runat="server" MaxLength="3" width="50px" cssclass="clsInputEnable" DESIGNTIMEDRAGDROP="324"></asp:textbox></TD>
												<TD class="Arial10B"></TD>
												<TD class="Arial10B">Vigencia Indefinida</TD>
												<TD class="Arial10B">:</TD>
												<TD class="Arial10B"><asp:checkbox id="chkVigenciaIndef" onclick="fActivarVigencia(this.checked, true);" Runat="server"></asp:checkbox></TD>
											</tr>
											<tr height="25">
												<td colSpan="7" align="center"><asp:button style="CURSOR: hand" id="btnAceptar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="126" Text="Aceptar" Height="19"></asp:button>&nbsp;
													<asp:button style="CURSOR: hand" id="btnCancelar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="126" Text="Cancelar"
														Height="19"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr id="trCargaMasiva">
									<td>
										<table border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td style="HEIGHT: 19px" class="header" colSpan="7" align="left">&nbsp;Carga Masiva</td>
											</tr>
											<TR>
												<td><INPUT style="WIDTH: 250px; HEIGHT: 19px" id="FileToUpload" class="boton" size="62" type="file"
														name="FileToUpload" runat="server">
													<asp:button style="CURSOR: hand" id="btnCargar" onmouseover="this.className='BotonResaltado';"
														onmouseout="this.className='Boton';" Runat="server" CssClass="Boton" Width="126" Text="Cargar"
														Height="19" DESIGNTIMEDRAGDROP="340"></asp:button></td>
											</TR>
										</table>
										<div id="dvError" style="DIPLAY:NONE">
											<table border="0" cellSpacing="0" cellPadding="0" width="100%">
												<tr>
													<td>
														<asp:label id="Label1" Runat="server" CssClass="Arial10B" ForeColor="Red">No se realizo la carga masiva, debido a los siguientes errores:</asp:label>
													</td>
												</tr>
												<tr>
													<td>
														<asp:label id="lblError" Runat="server" CssClass="Arial10B" ForeColor="Black"></asp:label>
													</td>
												</tr>
											</table>
										</div>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
			<input style="DISPLAY: none" id="btnAgregar" type="button" name="btnAgregar" runat="server">
			<input style="DISPLAY: none" id="btnModificar" type="button" name="btnModificar" runat="server">
			<input style="DISPLAY: none" id="btnModifGeneral" type="button" name="btnModifGeneral"
				runat="server"> <input style="DISPLAY: none" id="btnTraerCliente" type="button" name="btnTraerCliente"
				runat="server"> <input id="hidTipoLista" type="hidden" name="hidTipoLista" runat="server">
			<input id="hidCodigoPDV" type="hidden" name="hidCodigoPDV" runat="server"> <input style="WIDTH: 123px; HEIGHT: 22px" id="hidCondicion" size="15" type="hidden" name="hidCondicion"
				runat="server"> <input style="WIDTH: 123px; HEIGHT: 22px" id="hidCodigo" size="15" type="hidden" name="hidCodigo"
				runat="server"> <input style="DISPLAY: none" id="btnEliminarPDV" type="button" name="btnEliminarPDV" runat="server">
			<input style="WIDTH: 123px; HEIGHT: 22px" id="hidCodigoGen" size="15" type="hidden" name="hidCodigoGen"
				runat="server"> <input id="hidErrorCarga" type="hidden" name="hidErrorCarga" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
