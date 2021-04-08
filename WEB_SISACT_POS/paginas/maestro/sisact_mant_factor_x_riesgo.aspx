<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_factor_x_riesgo.aspx.vb" Inherits="sisact_mant_factor_x_riesgo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Mantenimiento Factor por Riesgo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="JavaScript" src="../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script src="../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript">

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
					
					var ddlEst=document.getElementById("ddlEstado");
					ddlEst.disabled=true;
					
				}
				if (valor == 'EDICION')
				{
					setVisible('trBusqueda',false);	
					setVisible('trGrilla',false);
					setVisible('trPDV',false);
					setVisible('trBoton',false);
					setVisible('trEdicion', true);

					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='none';
					document.getElementById('tdModificar').style.display='inline';
					document.getElementById('tdModificar').className='tab_activo';
					
				}
			}
			
			function f_Inicio()
			{				
				f_MostrarTab('BUSQUEDA');
			}

			function f_Agregar()
			{
				setValue('hidCodigo','');
				//f_MostrarMyTr(2);
				__doPostBack('btnAgregar','');
			}
			
			function f_MostrarMyTr(opcion)
			{				
				var mytr=document.getElementById("miTr");
				if(opcion==1)
					setVisible('miTr',true);
				else
					setVisible('miTr',false);	
											
			}
			function f_Modificar(cod)
			{
				setValue('hidCodigo',cod);
				__doPostBack('btnModificar','');
			}
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de desactivar este registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminar','');
				}
			}
			
			function f_EliminarItems()
			{
				if(validarCheck()==false)
				{
					alert('Debe seleccionar un registro para eliminar');
					return false;
				}
				
				if (confirm('¿Esta seguro de eliminar el(los) registro(s) Seleccionado(s)?'))
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
					if(e.type=='checkbox' && e.name.indexOf('fila') != -1)
					{
						if(e.checked== true)
						{
							result=true;
						}
					}
				} 
				return result;
			}
			
			
			function f_EliminarDetallePlan(cod)
			{
				if (confirm('¿Desea eliminar el registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminarDetalle','');
				}
			}
			
			
			function f_ConfirmarGrabar()
			{	
				//if (!f_ValidarGrabar())
				//	return false;
				var ddlTipDoc=document.getElementById("ddlTipoDocumentoMant");
				var valor=ddlTipDoc.options[ddlTipDoc.selectedIndex].value;
				if (valor=="")
				{
					alert('Seleccionar un tipo de documento');
					setFocus('ddlTipoDocumentoMant');
					return false;
				}
				
				var ddlRiesgo=document.getElementById("ddlRiesgoMant");
				var valorR=ddlRiesgo.options[ddlRiesgo.selectedIndex].value;
				if (valorR=="")
				{
					alert('Seleccionar Riesgo');
					setFocus('ddlRiesgoMant');
					return false;
				}
				
				var valid=document.getElementById("hid_Validacion");
				var txtV=valid.value;
				if (txtV=="SI")
				{
					var myddl=document.getElementById("ddlEsalud");
					var valor=myddl.options[myddl.selectedIndex].value;
					if (valor=="")
					{
						alert('Seleccionar Essalud/Sunat');
						setFocus('ddlEsalud');
						return false;
					}
				}
				
				var txtFactor=document.getElementById("txtFactor");
				var txtC=txtFactor.value;
				if (txtC=="")
				{
					alert('Ingresar el Factor');
					setFocus('txtFactor');
					txtFactor.value = '0.0';
					//f_MostrarTab('NUEVO')
					return false;
				}
				
				if (parseFloat(eval(txtFactor.value))>100 || parseFloat(eval(txtFactor.value))<0)
				{
					alert('El Factor debe estar entre 0 y 100');
					setFocus('txtFactor');
					txtFactor.value = '0.0';		
					return false;
				}
					
				if (confirm('¿Desea guardar los cambios?'))
					return true;
				else
					return false;
			}
			
			function f_ValidarGrabar()
			{	
				var ddlTipDoc=document.getElementById("ddlTipoDocumentoMant");
				var valor=ddlTipDoc.options[ddlTipDoc.selectedIndex].value;
				if (valor=="")
				{
					alert('Seleccione un tipo de documento');
					return false;
				}
				
				var ddlRiesgo=document.getElementById("ddlRiesgoMant");
				var valorR=ddlRiesgo.options[ddlRiesgo.selectedIndex].value;
				if (valorR=="")
				{
					alert('Seleccione riesgo');
					return false;
				}
				/*
				var ddlCuota=document.getElementById("ddlCuotaMant");
				var valorC=ddlCuota.options[ddlCuota.selectedIndex].value;
				if (valorC=="")
				{
					alert('Seleccione cuota');
					return false;
				}
				*/
				var txtFactor=document.getElementById("txtFactor");
				var txtC=txtFactor.value;
				if (txtC=="")
				{
					alert('el campo Faactor % no debe estar vacío');
					txtFactor.value='0';
					return false;
				}
				
				if (parseFloat(eval(txtFactor.value))>100 || parseFloat(eval(txtFactor.value))<0)
				{
					alert('el campo % cuota inicial debe estar entre 0 y 100');
					txtCuota.value='0';
					return false;
				}
				
					return true;			
				
			}
			/*
			function f_MostrarPV()
			{
				if (document.getElementById('tblPV').style.display == 'none')
				{
					document.getElementById('tblPV').style.display = 'inline';
					setValue('hidPV_Visible', 'true');
				}
				else
				{
					document.getElementById('tblPV').style.display = 'none';
					setValue('hidPV_Visible', 'false');
				}
					
				return false;
			}
			
			function f_MostrarPlan()
			{
				if (document.getElementById('tblPlan').style.display == 'none')
				{
					document.getElementById('tblPlan').style.display = 'inline';
					setValue('hidPlan_Visible', 'true');
				}
				else
				{
					document.getElementById('tblPlan').style.display = 'none';
					setValue('hidPlan_Visible', 'false');
				}
					
				return false;
			}
			
			function f_MostrarKit()
			{
				if (document.getElementById('tblKit').style.display == 'none')
				{
					document.getElementById('tblKit').style.display = 'inline';
					setValue('hidKit_Visible', 'true');
				}
				else
				{
					document.getElementById('tblKit').style.display = 'none';
					setValue('hidKit_Visible', 'false');
				}
					
				return false;
			}
			*/
			function f_CheckAllOA(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkOA') != -1)
						e.checked= ChkState ;
				} 
			}
			
			function f_CheckAllOD(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkOD') != -1)
						e.checked= ChkState ;
				} 
			}
			
			/*		
			
			function f_VerSeccion()
			{
				if (getValue('hidPV_Visible') == 'true')
					document.getElementById('tblPV').style.display = 'inline';
				else
					document.getElementById('tblPV').style.display = 'none';
					
				if (getValue('hidPlan_Visible') == 'true')
					document.getElementById('tblPlan').style.display = 'inline';
				else
					document.getElementById('tblPlan').style.display = 'none';
					
				if (getValue('hidKit_Visible') == 'true')
					document.getElementById('tblKit').style.display = 'inline';
				else
					document.getElementById('tblKit').style.display = 'none';
					
				return false;	
			}*/
			
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
			function fSoloMontos(event, obj){
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey)
					return false;
					
				var decimales = 0;
				var cantidad_decimales = 2;
				var salida = false;	
				if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105)){ // check digits
					if (obj.value == "0") return false;
					if (!isNaN(obj.value)){
						if (obj.value == "0.0" && code == 48){
							return false;
						}
					}
					if (obj.value.indexOf('.')>=0){
						decimales = obj.value.substring(obj.value.indexOf('.')+1, obj.value.length);	
						if (decimales.length >= cantidad_decimales){  
							//alert('decimales = ' + obj.value);
							return false;
						}
					}
					return true;
				}else if (code == 46 || code == 110 || code == 190){ // Check dot
					if (obj.value.indexOf(".") < 0){						
						if (obj.value.length == 0) obj.value = "0";				
						return true;
					}
				}else if (code == 8 || code == 116){ // Allow backspace, F5
					return true;
				}else if (code >=37 && code <= 40){ // Allow directional arrows
					return true;
				}else if (code ==9 || code == 16){ // tab control + tab
					return true;
				}
				return false;
			}
				
			function f_CheckAllOA(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('fila') != -1)
						e.checked= ChkState ;
				} 
			}			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Factor por Riesgo</td>
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
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');">Listado</A></td>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_inactivo" id="tdAgregar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('NUEVO');f_Agregar();">Agregar</A></td>
														<td class="tab_inactivo" id="tdModificar" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('EDICION');">Modificar</A></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="0" cellPadding="1" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Riesgo</td>
													</tr>
													<TR> <!--Codigo Del Plan Sisact-->
														<TD class="Arial10B" style="WIDTH: 150px">&nbsp;Tipo de Documento</TD>
														<TD class="Arial10B" style="WIDTH: 5px">:</TD>
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlTipoDocumento" AutoPostBack="True" cssclass="clsSelectEnable" Width="184px"
																Runat="server"></asp:dropdownlist></TD>
														<TD class="Arial10B" colSpan="2"><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Width="90" Runat="server" Height="19" Text="Buscar" CssClass="Boton"></asp:button></TD>
													</TR>
													<TR> <!--Codigo Del Plan Sisact-->
														<TD class="Arial10B" style="WIDTH: 150px">&nbsp;Riesgo</TD>
														<TD class="Arial10B" style="WIDTH: 5px">:</TD>
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlRiesgo" cssclass="clsSelectEnable" Width="184px" Runat="server"></asp:dropdownlist></TD>
														<TD class="Arial10B" colSpan="2"></TD>
													</TR>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD class="Arial10B" style="HEIGHT: 5px"></TD>
							</TR>
							<!---------------------------- TR donde se encuentra la grilla ------------------------>
							<tr id="trGrilla">
								<td>
									<table cellSpacing="0" cellPadding="0" width="600" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" autogeneratecolumns="False" showheader="True">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="25px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext="RIESGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext=" DOCUMENTO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="85px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESSALUD / SUNAT ">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="FACTOR %">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="85px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO ">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="85px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:TemplateColumn>
															<HeaderTemplate>
																<asp:CheckBox cssclass="TablaTitulos" id="chkTotalGrilla" onclick="javascript:f_CheckAllOA(this);"
																	runat="server"></asp:CheckBox>
															</HeaderTemplate>
														</asp:TemplateColumn>
													</columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 690px">
										<table cellSpacing="0" cellPadding="0" width="600" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" showheader="False"
														AllowPaging="True">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "RIEN_CODIGO")%>,<%# DataBinder.Eval(Container.DataItem, "TDOCC_CODIGO")%>,<%# DataBinder.Eval(Container.DataItem, "ITEMN_CODIGO")%>,<%# DataBinder.Eval(Container.DataItem, "RIEN_FACTOR")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Plan'> </a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="RIEN_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:BoundColumn DataField="RIEV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
															</asp:BoundColumn>
															<asp:boundcolumn datafield="TDOCC_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" width="85px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="ITEMN_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="ITEMN_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="RIEN_FACTOR" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="85px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="RIEC_ESTADO" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="85px"></itemstyle>
															</asp:boundcolumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center" Width="12px"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="fila" runat="server"></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
														</columns>
														<PagerStyle Font-Size="12px" Mode="NumericPages"></PagerStyle>
													</asp:datagrid><asp:button id="btnEliminarItems" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="90" Runat="server" Height="19" Text="Eliminar" CssClass="Boton"
														Visible="False"></asp:button>
													<asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Width="90" Runat="server" Height="19" Text="Exportar"
														CssClass="Boton" Visible="False"></asp:button></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr id="trEdicion" width="100%">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="6" height="25">Detalle</td>
										</tr>
										<TR> <!-- Documento -->
											<TD class="Arial10B" style="WIDTH: 200px; HEIGHT: 22px">&nbsp;Tipo Documento (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTipoDocumentoMant" AutoPostBack="True" cssclass="clsSelectEnable" Width="184px"
													Runat="server"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR> <!-- Riesgo -->
											<TD class="Arial10B" style="WIDTH: 200px; HEIGHT: 22px">&nbsp;Riesgo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlRiesgoMant" cssclass="clsSelectEnable" Width="184px" Runat="server"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR id="miTr"> <!-- Essalud/Sunat -->
											<TD class="Arial10B" style="WIDTH: 200px; HEIGHT: 22px">&nbsp;Essalud / Sunat (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlEsalud" cssclass="clsSelectEnable" Width="184px" Runat="server"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR> <!--Factor-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Factor % (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onpaste="return false" id="txtFactor" onkeydown="return fSoloMontos(event, this);"
													runat="server" cssclass="clsInputEnable" width="100px" MaxLength="10"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!-- Estado -->
											<TD class="Arial10B" style="WIDTH: 200px; HEIGHT: 22px">&nbsp;Estado (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlEstado" cssclass="clsSelectEnable" Width="184px" Runat="server"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR> <!--  -->
											<TD class="Arial10B" style="WIDTH: 200px; HEIGHT: 22px"></TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px"></TD>
											<TD class="Arial10B" style="WIDTH: 400px"></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Width="126" Runat="server" Height="19" Text="Aceptar" CssClass="Boton" DESIGNTIMEDRAGDROP="2054"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Width="126" Runat="server" Height="19" Text="Cancelar"
													CssClass="Boton"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE><input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
			<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input id="btnEliminarDetalle" style="DISPLAY: none" type="button" name="btnEliminarDetalle"
				runat="server"> <input id="hidCodigo" type="hidden" name="hidCodigo" runat="server">
			<input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server">
			<input id="hidPV_Visible" type="hidden" name="hidPV" runat="server"> <input id="hidPlan_Visible" type="hidden" name="hidPlan" runat="server">
			<input id="hid_Validacion" type="hidden" name="hidPlan" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
