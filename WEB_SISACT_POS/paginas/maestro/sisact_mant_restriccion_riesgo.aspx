<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_restriccion_riesgo.aspx.vb" Inherits="sisact_mant_restriccion_riesgo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Restricción por Riesgo</title>
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
			
			function LimpiarGrilla()
			{
				setVisible('trGrilla', false);
				/*
					var ddlTipDoc=document.getElementById("ddlTipoDocumento");
					ddlTipDoc.selectedIndex=0;
					*/
					var ddlTipDoc=document.getElementById("ddlRiesgo");
					ddlTipDoc.selectedIndex=0;
					
					var ddlTipDoc=document.getElementById("ddlPlazoAcuerdo");
					ddlTipDoc.selectedIndex=0;
					
					var ddlTipDoc=document.getElementById("ddlPlan");
					ddlTipDoc.selectedIndex=0;	
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
					
					//document.getElementById('tblCampana').style.display = 'none';
					//document.getElementById('tblPlan').style.display = 'none';
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
					
					//document.getElementById('tblCampana').style.display = 'none';
					//document.getElementById('tblPlan').style.display = 'none';					
				}
			}
			
			function f_Inicio()
			{	
				
						
				f_MostrarTab('BUSQUEDA');
			}
			function resetCboBusqueda()
			{
				var ddlTipDoc=document.getElementById("ddlTipoDocumento");
				ddlTipDoc.selectedIndex=0;
				
				var ddlRies=document.getElementById("ddlRiesgo");
				ddlRies.selectedIndex=0;
				
				var ddlPlaz=document.getElementById("ddlPlazoAcuerdo");
				ddlPlaz.selectedIndex=0;
				
				var ddlPla=document.getElementById("ddlPlan");
				ddlPla.selectedIndex=0;
				
			}
			
			function f_Agregar()
			{
				f_LimpiarCheck();
				setValue('hidCodigo','');
				
				var ddlTipDoc=document.getElementById("ddlTipoDocumentoMant");
				ddlTipDoc.selectedIndex=0;
				ddlTipDoc.disabled=false;

				var ddlRies=document.getElementById("ddlRiesgoMant");
				ddlRies.selectedIndex=0;
				ddlRies.disabled=false;
				
				
				//__doPostBack('btnAgregar','');
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
					if(e.type=='checkbox' && e.name.indexOf('FilaSeleccionada') != -1)
					{
						if(e.checked== true)
						{
							result=true;
						}
					}
				} 
				return result;
			}
			
			function validarCheckPlazoAcuerdo()
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var result=false;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('ctlPlazoAcuerdo') != -1)
					{
						if(e.checked== true)
						{
							return true;
						}
					}
				} 
				return false;
			}
			
			function validarCheckPlanes()
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var result=false;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('FilaPlan') != -1)
					{
						if(e.checked== true)
						{
							return true;
						}
					}
				} 
				return false;
			}
			
			function validarCheckCampana()
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var result=false;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('FilaCampana') != -1)
					{
						if(e.checked== true)
						{
							return true;
						}
					}
				} 
				return false;
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
					alert('Seleccione riesgo');
					setFocus('ddlRiesgoMant');
					return false;
				}
				
				if(!validarCheckPlazoAcuerdo())
				{
					alert('Debe seleccionar como mínimo un plazo');
					return false;
				}
				
				if(!validarCheckPlanes())
				{
					alert('Debe seleccionar como mínimo un plan');
					return false;
				}
				
				if(!validarCheckCampana())
				{
					alert('Debe seleccionar como mínimo una Campaña');
					return false;
				}
								
				return true;
								
				
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
			
			
			function f_LimpiarCheck()
	        {                                                                                                                                                                       
				var frm = document.forms[0];                                                                                       
				var ChkState = false;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox')
						e.checked= ChkState ;
				} 
			}								
			
			function f_VerSeccion()
			{
				if (getValue('hidPV_Visible') == 'true')
					document.getElementById('tblCampana').style.display = 'inline';
				else
					document.getElementById('tblCampana').style.display = 'none';
					
				if (getValue('hidPlan_Visible') == 'true')
					document.getElementById('tblPlan').style.display = 'inline';
				else
					document.getElementById('tblPlan').style.display = 'none';					
					
				return false;	
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
			
			function f_CheckAllOA(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('FilaSeleccionada') != -1)
						e.checked= ChkState ;
				} 
			}		
			
			function f_CheckAllOACampana(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('FilaCampana') != -1)
						e.checked= ChkState ;
				} 
			}	
			
			function f_CheckAllOAPlanes(chk)
	        {                                                                                                                                                                       
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('FilaPlan') != -1)
						e.checked= ChkState ;
				} 
			}	
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento Campañas por Riesgo</td>
				</tr>
				<tr>
					<td class="contenido">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td style="WIDTH: 940px">
									<table id="tblDetalleLista" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><IMG height="2" src="../../spacer.gif" width="2"></td>
														<td class="tab_activo" id="tdListado" borderColor="#000099" align="center" width="122"><A href="javascript:f_MostrarTab('BUSQUEDA');resetCboBusqueda();LimpiarGrilla();">Listado</A></td>
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
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlTipoDocumento" Runat="server" Width="184px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></TD>
														<TD class="Arial10B" colSpan="2"><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Text="Buscar" Height="19"></asp:button></TD>
													</TR>
													<TR> <!--Codigo Del Plan Sisact-->
														<TD class="Arial10B" style="WIDTH: 150px">&nbsp;Riesgo</TD>
														<TD class="Arial10B" style="WIDTH: 5px">:</TD>
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlRiesgo" Runat="server" Width="184px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
														<TD class="Arial10B" colSpan="2"></TD>
													</TR>
													<TR> <!--Codigo Del Plan Sisact-->
														<TD class="Arial10B" style="WIDTH: 150px">&nbsp;Plazo</TD>
														<TD class="Arial10B" style="WIDTH: 5px">:</TD>
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlPlazoAcuerdo" Runat="server" Width="184px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
														<TD class="Arial10B" colSpan="2"></TD>
													</TR>
													<TR> <!--Codigo Del Plan Sisact-->
														<TD class="Arial10B" style="WIDTH: 150px">&nbsp;Plan</TD>
														<TD class="Arial10B" style="WIDTH: 5px">:</TD>
														<TD class="Arial10B" style="WIDTH: 200px"><asp:dropdownlist id="ddlPlan" Runat="server" Width="184px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
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
									<table cellSpacing="0" cellPadding="0" width="900" border="0">
										<tr>
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" showheader="True" autogeneratecolumns="False">
													<columns>
														<asp:boundcolumn headertext=" " headerstyle-width="25px" itemstyle-width="30px">
															<headerstyle wrap="False" horizontalalign="Center" width="25px" cssclass="TablaTitulos" height="25"></headerstyle>
														</asp:boundcolumn>
														<asp:templatecolumn headertext=" DOCUMENTO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="80px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="RIESGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="120px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PLAZO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="160px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="OFERTA ">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="80px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PLAN ">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="170px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CAMPAÑA">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="150px" Wrap="False"></headerstyle>
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
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 900px">
										<table cellSpacing="0" cellPadding="0" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" showheader="False" autogeneratecolumns="False"
														AllowPaging="True">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "RIEN_CODIGO")%>,<%# DataBinder.Eval(Container.DataItem, "TDOCC_CODIGO")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Plan'> </a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="TDOCC_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="80px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="RIEN_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:BoundColumn DataField="RIEV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="120px"></itemstyle>
															</asp:BoundColumn>
															<asp:boundcolumn datafield="PACUC_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="PACUV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="160px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="tofv_descripcion" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="80px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLANC_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="PLANV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="170px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="CMPV_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:boundcolumn datafield="CMPV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																<headerstyle horizontalalign="Center"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="150px"></itemstyle>
															</asp:boundcolumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center" Width="12px"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox id="FilaSeleccionada" runat="server"></asp:CheckBox>
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
							<tr id="trEdicion">
								<td style="WIDTH: 940px">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="header" colSpan="6" height="25">&nbsp;Detalle</td>
										</tr>
										<TR> <!-- Documento -->
											<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 22px">&nbsp;Tipo Documento (*)</TD>
											<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px">&nbsp;&nbsp;<asp:dropdownlist id="ddlTipoDocumentoMant" Runat="server" Width="184px" cssclass="clsSelectEnable"
													AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR> <!-- Riesgo -->
											<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 22px">&nbsp;Riesgo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px">&nbsp;&nbsp;<asp:dropdownlist id="ddlRiesgoMant" Runat="server" Width="184px" cssclass="clsSelectEnable" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR> <!-- Plazo -->
											<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 22px">&nbsp;Plazo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><div style="OVERFLOW: auto; HEIGHT: 75px">
													<asp:checkboxlist id="ctlPlazoAcuerdo" runat="server" CssClass="Arial11BV"></asp:checkboxlist></div>
											</TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="HEIGHT: 10px" colSpan="6"></TD>
										</TR>
										<TR> <!-- Campañas -->
											<TD class="Arial10B" style="WIDTH: 88px; HEIGHT: 22px">&nbsp;Campañas (*)</TD>
											<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px">
												<table id="tblCampanaDisponible" cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td style="WIDTH: 250px"><asp:datagrid id="dgrODCabecera" runat="server" Width="395px" showheader="True" autogeneratecolumns="False">
																<columns>
																	<asp:templatecolumn headertext="" headerstyle-width="20px" itemstyle-width="20px">
																	<HeaderTemplate>
																		<asp:CheckBox id="chkAllCampanas" onclick="javascript:f_CheckAllOACampana(this);" runat="server"></asp:CheckBox>
																	</HeaderTemplate>
																		<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:templatecolumn>
																	<asp:templatecolumn headertext="CÓDIGO">
																		<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																	</asp:templatecolumn>
																	<asp:templatecolumn headertext="CAMPAÑA">
																		<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="180px"></headerstyle>
																	</asp:templatecolumn>
																</columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 424px; HEIGHT: 150px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgCampana" runat="server" Width="395px" showheader="False" autogeneratecolumns="False"
																	PageSize="5">
																	<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="25px"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="FilaCampana" Runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="Codigo">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Descripcion">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle Wrap="False" HorizontalAlign="Center" Width="180px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="HEIGHT: 10px" colSpan="6"></TD>
										</TR>
										<TR> <!-- Planes -->
											<TD class="Arial10B" style="WIDTH: 120px; HEIGHT: 22px">&nbsp;Planes (*)</TD>
											<TD class="Arial10B" style="WIDTH: 1px; HEIGHT: 22px">:</TD>
											<td>
												<table id="tblPlanDisponible" cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td><asp:datagrid id="dgrPDCabecera" runat="server" Width="400px" showheader="True" autogeneratecolumns="False">
																<columns>
																	<asp:templatecolumn headertext="" headerstyle-width="20px" itemstyle-width="20px">
																	<HeaderTemplate>
																		<asp:CheckBox id="chkAllPlanes" onclick="javascript:f_CheckAllOAPlanes(this);" Runat="server" ></asp:CheckBox>
																	</HeaderTemplate>
																		<HeaderStyle horizontalalign="Center" CssClass="TablaTitulos"></HeaderStyle>
																	</asp:templatecolumn>
																	<asp:templatecolumn headertext="CÓDIGO">
																		<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																	</asp:templatecolumn>
																	<asp:templatecolumn headertext="OFERTA">
																		<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="80px"></headerstyle>
																	</asp:templatecolumn>
																	<asp:templatecolumn headertext="DESCRIPCIÓN">
																		<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="200px"></headerstyle>
																	</asp:templatecolumn>
																</columns>
															</asp:datagrid></td>
													</tr>
												</table>
												<div class="clsGridRow" style="WIDTH: 424px; HEIGHT: 150px">
													<table cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgPlanes" runat="server" Width="400px" showheader="False" autogeneratecolumns="False"
																	PageSize="5">
																	<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																	<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																	<Columns>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="20px"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
																			<ItemTemplate>
																				<asp:CheckBox ID="FilaPlan" Runat="server"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="planc_codigo">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="tofv_descripcion">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="planv_descripcion">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center" Width="200px" CssClass="Arial10B"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</td>
										</TR>
										<TR>
											<TD class="Arial10B" style="HEIGHT: 10px" colSpan="6"></TD>
										</TR>
										<tr height="25">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Text="Aceptar" Height="19" DESIGNTIMEDRAGDROP="2054"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Text="Cancelar"
													Height="19"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE> <input id="btnAgregar" style="DISPLAY: none" type="button" name="btnAgregar" runat="server">
			<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input id="hidCodigo" type="hidden" name="hidCodigo" runat="server"> <input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server">
			<input id="hidPV_Visible" type="hidden" name="hidPV" runat="server"> <input id="hidPlan_Visible" type="hidden" name="hidPlan" runat="server">
			<input id="hid_Validacion" type="hidden" name="hidPlan" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
