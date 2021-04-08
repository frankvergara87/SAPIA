<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_campania.aspx.vb" Inherits="sisact_mant_campania" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_mant_campania</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script language="JavaScript" src="../../../script/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script src="../../../Script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../../Script/calendar/calendar_setup.js" type="text/javascript"></script>
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
					
					document.getElementById('tblPV').style.display = 'none';
					document.getElementById('tblPlan').style.display = 'none';
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
					
					document.getElementById('trCodigo').style.display = '';
					document.getElementById('tblPV').style.display = 'none';
					document.getElementById('tblPlan').style.display = 'none';					
					document.getElementById('btnValidar').style.display = 'none';
				}
			}
			
			function f_Inicio()
			{				
				f_MostrarTab('BUSQUEDA');
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
				var fechaInicio = getValue('txtFechaInicio');
				var fechaFin = getValue('txtFechaFin');
				
				/*if (getValue('txtCodigo') == '')
				{
					alert('Debe ingresar el código');
					return false;
				}*/
						
				if (getValue('txtDescripcion') == '')
				{
					alert('Debe ingresar la descripción');
					return false;
				}
				
				if (getValue('txtNomPromo') == '')
				{
					alert('Debe ingresar la Nombre de Promoción');
					return false;
				}
				
				if (fechaInicio == '')
				{
					alert('Debe ingresar la fecha de inicio');
					return false;
				}
				
				if (fechaFin == '')
				{
					alert('Debe ingresar la fecha de fin');
					return false;
				}
				
				if (Date.parse(fechaInicio) > Date.parse(fechaFin))
				{
					alert('La fecha de inicio es mayor que la fecha de fin');
					return false;
				}
								
				return true;
			}
			
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
			
			function f_CheckAll(prefijo, chk)
	        {  
/*                                                                                                                                                                     
				var frm = document.forms[0];
				var ChkState = chk.checked;
				for(i=0;i< frm.length;i++)
				{                                                                                                                                                                  
					e=frm.elements[i];                                                                                                     
					if(e.type=='checkbox' && e.name.indexOf('chkOA') != -1)
						e.checked= ChkState ;
				} 
*/
				var ChkState = chk.checked;
				var strTabla = 'dgr' + prefijo + 'Detalle';
				var tabla = document.getElementById(strTabla);
				var fila;
				var totalLineas = tabla.rows.length - 1;
				var chk;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tabla.rows[i];
					fila.cells[0].getElementsByTagName("input")[0].checked = ChkState;
				}
			}			
			
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
					
				return false;	
			}
			
			function f_EventoSoloNumeros()
			{
				var CaracteresPermitidos = '0123456789.';
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
			
			function fAsociarOficina()
			{	
				var tablaOD = document.getElementById('dgrODDetalle');
				var tablaOA = document.getElementById('dgrOADetalle');
				var hidPDVs = document.getElementById('hidPDVs');
				var hidOfiDescrips = document.getElementById('hidOfiDescrips');
				var hidOfiTipos = document.getElementById('hidOfiTipos');
				var fila;
				var totalLineas = tablaOD.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				var oficina;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaOD.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Asociados
						filaNueva = tablaOA.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						oficina = filaNueva.insertCell(3);
						//Inserto valores en fila nueva de Asociados
						chk.innerHTML = "<input type='checkbox' id='chkOA' name='chkOA'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						oficina.innerHTML = fila.cells[3].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						oficina.className = 'Arial10B';
						codigo.style.width = '70px';
						descripcion.style.width = '140px';
						oficina.style.width = '100px';
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						oficina.style.textAlign = 'center';
						//Elimino fila de Disponibles
						tablaOD.deleteRow(i);
						i--;
						totalLineas--;
						hidPDVs.value += codigo.innerHTML + '|';
						hidOfiDescrips.value += descripcion.innerHTML + '|';
						hidOfiTipos.value += oficina.innerHTML + '|';
					}
				} 
				//Quitar check en cabecera de Disponibles
				document.getElementById('dgrODCabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function fQuitarOficina()
			{
				var tablaOD = document.getElementById('dgrODDetalle');
				var tablaOA = document.getElementById('dgrOADetalle');
				var hidPDVs = document.getElementById('hidPDVs');
				var hidOfiDescrips = document.getElementById('hidOfiDescrips');
				var hidOfiTipos = document.getElementById('hidOfiTipos');				
				var fila;
				var totalLineas = tablaOA.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				var oficina;

				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaOA.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Disponibles
						filaNueva = tablaOD.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						oficina = filaNueva.insertCell(3);
						//Inserto valores en fila nueva de Disponibles
						chk.innerHTML = "<input type='checkbox' id='chkOD' name='chkOD'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						oficina.innerHTML = fila.cells[3].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						oficina.className = 'Arial10B';
						codigo.style.width = '70px';
						descripcion.style.width = '140px';
						oficina.style.width = '100px';
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						oficina.style.textAlign = 'center';
						//Elimino fila de Disponibles
						tablaOA.deleteRow(i);
						i--;
						totalLineas--;
						hidPDVs.value = hidPDVs.value.replace((codigo.innerHTML + '|'), '');
						hidOfiDescrips.value = hidOfiDescrips.value.replace((descripcion.innerHTML + '|'), '');
						hidOfiTipos.value = hidOfiTipos.value.replace((oficina.innerHTML + '|'), '');
					}
				}
				//Quitar check en cabecera de Asociados
				document.getElementById('dgrOACabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function fAsociarPlan()
			{	
				var tablaPD = document.getElementById('dgrPDDetalle');
				var tablaPA = document.getElementById('dgrPADetalle');
				var hidPlanes = document.getElementById('hidPlanes');
				var hidPlaDescrips = document.getElementById('hidPlaDescrips');
				var fila;
				var totalLineas = tablaPD.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				
				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaPD.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Asociados
						filaNueva = tablaPA.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						//Inserto valores en fila nueva de Asociados
						chk.innerHTML = "<input type='checkbox' id='chkPA' name='chkPA'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						codigo.style.width = '70px';
						descripcion.style.width = '140px';
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						//Elimino fila de Disponibles
						tablaPD.deleteRow(i);
						i--;
						totalLineas--;
						hidPlanes.value += codigo.innerHTML + '|';
						hidPlaDescrips.value += descripcion.innerHTML + '|';
					}
				} 
				//Quitar check en cabecera de Disponibles
				document.getElementById('dgrPDCabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}
			
			function fQuitarPlan()
			{
				var tablaPD = document.getElementById('dgrPDDetalle');
				var tablaPA = document.getElementById('dgrPADetalle');
				var hidPlanes = document.getElementById('hidPlanes');
				var hidPlaDescrips = document.getElementById('hidPlaDescrips');
				var fila;
				var totalLineas = tablaPA.rows.length - 1;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;

				for (var i = 0; i <= totalLineas; i++) 
				{ 
					fila = tablaPA.rows[i];
					if (fila.cells[0].getElementsByTagName("input")[0].checked)
					{
						//Creo fila nueva en Disponibles
						filaNueva = tablaPD.insertRow(0);
						chk = filaNueva.insertCell(0);
						codigo = filaNueva.insertCell(1);
						descripcion = filaNueva.insertCell(2);
						//Inserto valores en fila nueva de Disponibles
						chk.innerHTML = "<input type='checkbox' id='chkPD' name='chkPD'/>";
						codigo.innerHTML = fila.cells[1].innerHTML;
						descripcion.innerHTML = fila.cells[2].innerHTML;
						//Asignando estilos a las celdas de la nueva fila de Asociados
						codigo.className = 'Arial10B';
						descripcion.className = 'Arial10B';
						codigo.style.width = '70px';
						descripcion.style.width = '140px';
						codigo.style.textAlign = 'center';
						descripcion.style.textAlign = 'center';
						//Elimino fila de Disponibles
						tablaPA.deleteRow(i);
						i--;
						totalLineas--;
						hidPlanes.value = hidPlanes.value.replace(codigo.innerHTML + '|', '');
						hidPlaDescrips.value = hidPlaDescrips.value.replace(descripcion.innerHTML + '|', '');
					}
				}
				//Quitar check en cabecera de Asociados
				document.getElementById('dgrPACabecera').rows[0].cells[0].getElementsByTagName("input")[0].checked = false;
			}				

			function fAsociarOficinas()
			{			
				var tablaOA = document.getElementById('dgrOADetalle');
				var tablaOD = document.getElementById('dgrODDetalle');
				var strOfiCodigos = document.getElementById('hidPDVs').value;
				var strOfiDescrips = document.getElementById('hidOfiDescrips').value;
				var strOfiTipos = document.getElementById('hidOfiTipos').value;
				var totLinOfiAso = strOfiCodigos.split("|").length - 1;
				var totLinOfiDis = tablaOD.rows.length - 1;
				var fila;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				var oficina;
				var arrOfiCodigo = strOfiCodigos.split("|");
				var arrOfiDescrip = strOfiDescrips.split("|");
				var arrOfiTipo = strOfiTipos.split("|");
				
				for (var i = 0; i < totLinOfiAso; i++) 
				{ 
					//Creo fila nueva en Asociadas
					filaNueva = tablaOA.insertRow(0);
					chk = filaNueva.insertCell(0);
					codigo = filaNueva.insertCell(1);
					descripcion = filaNueva.insertCell(2);
					oficina = filaNueva.insertCell(3);
					//Inserto valores en fila nueva de Asociados
					chk.innerHTML = "<input type='checkbox' id='chkOA' name='chkOA'/>";
					codigo.innerHTML = arrOfiCodigo[i];
					descripcion.innerHTML = arrOfiDescrip[i];
					oficina.innerHTML = arrOfiTipo[i];
					//Asignando estilos a las celdas de la nueva fila de Asociados
					codigo.className = 'Arial10B';
					descripcion.className = 'Arial10B';
					oficina.className = 'Arial10B';
					codigo.style.width = '70px';
					descripcion.style.width = '140px';
					oficina.style.width = '100px';
					codigo.style.textAlign = 'center';
					descripcion.style.textAlign = 'center';
					oficina.style.textAlign = 'center';
					//Elimino fila de Disponibles
					for (var j = 0; j <= totLinOfiDis; j++) 
					{
						fila = tablaOD.rows[j];
						if (fila.cells[1].innerHTML == arrOfiCodigo[i])
						{
							tablaOD.deleteRow(j);
							j--;
							totLinOfiDis--;
						}
					}
				}		
			}
			function fAsociarPlanes()
			{			
				var tablaPA = document.getElementById('dgrPADetalle');
				var tablaPD = document.getElementById('dgrPDDetalle');
				var strPlaCodigos = document.getElementById('hidPlanes').value;
				var strPlaDescrips = document.getElementById('hidPlaDescrips').value;
				var totLinPlaAso = strPlaCodigos.split("|").length - 1;
				var totLinPlaDis = tablaPD.rows.length - 1;
				var fila;
				var filaNueva;
				var chk;
				var codigo;
				var descripcion;
				var arrPlaCodigo = strPlaCodigos.split("|");
				var arrPlaDescrip = strPlaDescrips.split("|");

				for (var i = 0; i < totLinPlaAso; i++) 
				{ 
					//Creo fila nueva en Asociadas
					filaNueva = tablaPA.insertRow(0);
					chk = filaNueva.insertCell(0);
					codigo = filaNueva.insertCell(1);
					descripcion = filaNueva.insertCell(2);
					//Inserto valores en fila nueva de Asociados
					chk.innerHTML = "<input type='checkbox' id='chkPA' name='chkPA'/>";
					codigo.innerHTML = arrPlaCodigo[i];
					descripcion.innerHTML = arrPlaDescrip[i];
					//Asignando estilos a las celdas de la nueva fila de Asociados
					codigo.className = 'Arial10B';
					descripcion.className = 'Arial10B';
					codigo.style.width = '70px';
					descripcion.style.width = '140px';
					codigo.style.textAlign = 'center';
					descripcion.style.textAlign = 'center';
					//Elimino fila de Disponibles
					for (var j = 0; j <= totLinPlaDis; j++) 
					{
						fila = tablaPD.rows[j];
						if (fila.cells[1].innerHTML == arrPlaCodigo[i])
						{
							tablaPD.deleteRow(j);
							j--;
							totLinPlaDis--;
						}
					}
				}		
			}			
		
			function f_ValidarCampana()
			{
				var url = '../sisact_pop_varios.aspx?strTipo=Cmp';
				var str = window.showModalDialog(url, '', 'dialogHeight:400px; dialogWidth:500px');
				
				if (str != null)
					setValue('txtDescripcion', str);
			}
		
		</script>
	</HEAD>
	<body onkeydown="cancelarBackSpace();" MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Campaña 3Play</td>
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
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Campaña</td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable">
																<asp:ListItem Value="0">DESCRIPCI&#211;N</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtBusDescripcion"
																onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" Width="300px" CssClass="clsInputEnable"
																MaxLength="30"></asp:textbox>
															&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19" Text="Buscar"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Limpiar"></asp:button></td>
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
											<td><asp:datagrid id="dgrGrillaCabecera" runat="server" width="850px" autogeneratecolumns="False">
													<Columns>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="C&#211;DIGO">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="DESCRIPCI&#211;N">
															<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="PROMOCI&#211;N">
															<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ESTADO">
															<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="FECHA INICIO">
															<HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="FECHA FIN">
															<HeaderStyle HorizontalAlign="Center" Width="65px" CssClass="TablaTitulos"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn HeaderText=" ">
															<HeaderStyle Wrap="False" HorizontalAlign="Center" Height="25px" Width="25px" CssClass="TablaTitulos"></HeaderStyle>
															<ItemStyle Width="25px"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 900px">
										<table cellSpacing="0" cellPadding="0" width="850" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" width="850px" autogeneratecolumns="False" showheader="False"
														AllowPaging="True">
														<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
														<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "campv_codigo")%>");'>
																		<img src="../../../images/btn_edit.jpg" border="0" alt='Modificar'> </a>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="campv_codigo">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="campv_descripcion">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="campv_promocion">
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="250px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Estado">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="campd_fecha_inicio" DataFormatString="{0:dd/MM/yyyy}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="65px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="campd_fecha_fin" DataFormatString="{0:dd/MM/yyyy}">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle Wrap="False" HorizontalAlign="Center" Width="65px" CssClass="Arial10B"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="25px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																<ItemTemplate>
																	<a href='javascript:f_Eliminar("<%# DataBinder.Eval(Container.DataItem, "campv_codigo")%>");'>
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
											<td class="header" colSpan="4" height="25">Detalle Campaña</td>
										</tr>
										<TR id="trCodigo" style="display: none">
											<TD class="Arial10B" style="WIDTH: 120px">&nbsp;Código</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return f_EventoSoloNumeros();" onpaste="return false;" id="txtCodigo"
													ondrop="return false;" runat="server" MaxLength="4" width="60px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B"></TD>
										</TR>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Descripción</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px">
												<table border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td>
															<asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtDescripcion"
																ondrop="return false;" runat="server" width="320px" cssclass="clsInputDisable" maxlength="50"
																ReadOnly="True"></asp:textbox>
														</td>
														<td>&nbsp;
															<INPUT class="Boton" id="btnValidar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 110px; CURSOR: hand; HEIGHT: 19px"
																onclick="f_ValidarCampana();" onmouseout="this.className='Boton';" type="button" value="Validar Campaña"
																name="btnValidar">
														</td>
													</tr>
												</table>
											</td>
											<TD class="Arial10B"></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Nombre Promoción</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:textbox onkeypress="return validarSoloAlfanumerico();" onpaste="return false;" id="txtNomPromo"
													ondrop="return false;" runat="server" width="320px" cssclass="clsInputEnable" maxlength="50"></asp:textbox></td>
											<TD class="Arial10B"></TD>
										</tr>
										<tr>
											<td class="Arial10B" style="WIDTH: 120px">&nbsp;Estado</td>
											<td class="Arial10B" style="WIDTH: 5px">:</td>
											<td class="Arial10B" style="WIDTH: 40px"><asp:dropdownlist id="ddlEstado" runat="server" width="100px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
													<asp:ListItem Value="0">INACTIVO</asp:ListItem>
												</asp:dropdownlist></td>
											<TD class="Arial10B"></TD>
										</tr>
										<TR>
											<TD class="Arial10B" style="WIDTH: 120px">&nbsp;Fecha de Campaña</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 40px">
												<TABLE cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD class="Arial10B"><asp:textbox id="txtFechaInicio" runat="server" Width="80px" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
														<TD class="Arial10B"><IMG id="btnFechaInicio" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																src="../../../images/calendario.gif" border="0">
															<script type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtFechaInicio",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnFechaInicio",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
															</script>
														</TD>
														<TD class="Arial10B">&nbsp;al&nbsp;</TD>
														<TD class="Arial10B"><asp:textbox id="txtFechaFin" runat="server" Width="80px" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></TD>
														<TD class="Arial10B"><IMG id="btnFechaFin" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																src="../../../images/calendario.gif" border="0">
															<script type="text/javascript">
                                                        Calendar.setup(
                                                            {
                                                                inputField     :    "txtFechaFin",      // id of the input field
                                                                ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
                                                                button         :    "btnFechaFin",   // trigger for the calendar (button ID)
                                                                singleClick    :    true,           // double-click mode
                                                                step           :    1                // show all years in drop-down boxes (instead of every other year as default)
                                                            }
                                                        );
															</script>
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="Arial10B"></TD>
										</TR>
										<TR>
											<TD class="Arial10B" style="WIDTH: 120px"></TD>
											<TD class="Arial10B" style="WIDTH: 5px"></TD>
											<TD class="Arial10B" style="WIDTH: 40px"></TD>
											<TD class="Arial10B" align="right"><asp:button id="btnSeleccionarPDV" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Seleccionar PDV" DESIGNTIMEDRAGDROP="308"></asp:button></TD>
										</TR>
										<TR>
											<TD class="Arial10B" colSpan="4">
												<table id="tblPV" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 25px" align="left" colSpan="3">&nbsp;Asociar 
															Puntos de Venta</td>
													</tr>
													<tr>
														<td class="Arial10B" width="40%">&nbsp;Oficinas asociadas</td>
														<td class="Arial10B" width="15%"></td>
														<td class="Arial10B" width="45%">Oficinas disponibles</td>
													</tr>
													<tr>
														<td>
															<table id="tblOficinaAsociada" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrOACabecera" runat="server" autogeneratecolumns="False" showheader="True">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalOA" Runat="server" onclick="javascript:f_CheckAll('OA',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="180px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="TIPO DE OFICINA">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="80px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 365px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrOADetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkOA" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="ovenc_codigo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="ovenv_descripcion">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="180px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="tofiv_descripcion">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><input class="Boton" id="hbtQuitarOficina" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fQuitarOficina();" onmouseout="this.className='Boton';"
																			type="button" value=">>" name="hbtQuitarOficina">
																	</td>
																</tr>
																<tr>
																	<td height="10"></td>
																</tr>
																<tr>
																	<td><input class="Boton" id="hbtAsociarOficina" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fAsociarOficina();" onmouseout="this.className='Boton';"
																			type="button" value="<<" name="hbtAsociarOficina">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table id="tblOficinaDisponible" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrODCabecera" runat="server" autogeneratecolumns="False" showheader="True">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalOD" Runat="server" onclick="javascript:f_CheckAll('OD',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="180px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="TIPO DE OFICINA">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="80px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 365px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrODDetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
																				<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25px"></HeaderStyle>
																						<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox ID="chkOD" Runat="server"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="ovenc_codigo">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="ovenv_descripcion">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="180px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="tofiv_descripcion">
																						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																						<ItemStyle Wrap="False" HorizontalAlign="Center" Width="80px" CssClass="Arial10B"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<tr>
											<td class="Arial10B" align="right" colSpan="6"><asp:button id="btnSeleccionarPlan" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Seleccionar Planes"></asp:button></td>
										</tr>
										<tr>
											<td class="Arial10B" colSpan="6">
												<table id="tblPlan" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 25px" align="left" colSpan="3">&nbsp;Asociar 
															Planes</td>
													</tr>
													<tr>
														<td class="Arial10B" width="40%">&nbsp;Planes asociados</td>
														<td class="Arial10B" width="15%"></td>
														<td class="Arial10B" width="45%">Planes disponibles</td>
													</tr>
													<tr>
														<td>
															<table id="tblPlanAsociado" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrPACabecera" runat="server" autogeneratecolumns="False" showheader="True">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalPA" Runat="server" onclick="javascript:f_CheckAll('PA',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 400px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrPADetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
																				<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
																				<columns>
																					<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																						<itemstyle horizontalalign="Center"></itemstyle>
																						<itemtemplate>
																							<asp:CheckBox ID="chkPA" Runat="server"></asp:CheckBox>
																						</itemtemplate>
																					</asp:templatecolumn>
																					<asp:boundcolumn datafield="plnv_codigo" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="plnv_descripcion" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
																					</asp:boundcolumn>
																				</columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
														<td>
															<table cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><input class="Boton" id="hbtQuitarPlan" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fQuitarPlan();" onmouseout="this.className='Boton';"
																			type="button" value=">>" name="hbtQuitarPlan">
																	</td>
																</tr>
																<tr>
																	<td height="10"></td>
																</tr>
																<tr>
																	<td><input class="Boton" id="hbtAsociarPlan" onmouseover="this.className='BotonResaltado';"
																			style="WIDTH: 126px; HEIGHT: 19px" onclick="fAsociarPlan();" onmouseout="this.className='Boton';"
																			type="button" value="<<" name="hbtAsociarPlan">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table id="tblPlanDisponible" cellSpacing="0" cellPadding="0" border="0">
																<tr>
																	<td><asp:datagrid id="dgrPDCabecera" runat="server" autogeneratecolumns="False" showheader="True">
																			<columns>
																				<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																					<HeaderStyle horizontalalign="Center" Wrap="False" CssClass="TablaTitulos"></HeaderStyle>
																					<HeaderTemplate>
																						<asp:CheckBox ID="chkTotalPD" Runat="server" onclick="javascript:f_CheckAll('PD',this);"></asp:CheckBox>
																					</HeaderTemplate>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="CÓDIGO">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="50px"></headerstyle>
																				</asp:templatecolumn>
																				<asp:templatecolumn headertext="DESCRIPCIÓN">
																					<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="250px"></headerstyle>
																				</asp:templatecolumn>
																			</columns>
																		</asp:datagrid></td>
																</tr>
															</table>
															<div class="clsGridRow" style="WIDTH: 400px; HEIGHT: 200px">
																<table cellSpacing="0" cellPadding="0" border="0">
																	<tr>
																		<td><asp:datagrid id="dgrPDDetalle" runat="server" autogeneratecolumns="False" showheader="False">
																				<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
																				<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
																				<columns>
																					<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																						<itemstyle horizontalalign="Center"></itemstyle>
																						<itemtemplate>
																							<asp:CheckBox ID="chkPD" Runat="server"></asp:CheckBox>
																						</itemtemplate>
																					</asp:templatecolumn>
																					<asp:boundcolumn datafield="plnv_codigo" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="50px"></itemstyle>
																					</asp:boundcolumn>
																					<asp:boundcolumn datafield="plnv_descripcion" itemstyle-cssclass="Arial10B">
																						<headerstyle horizontalalign="Center"></headerstyle>
																						<itemstyle wrap="False" horizontalalign="Center" width="250px"></itemstyle>
																					</asp:boundcolumn>
																				</columns>
																			</asp:datagrid></td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr height="25" valign="middle">
											<td align="center" colSpan="6"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19" Text="Aceptar" DESIGNTIMEDRAGDROP="2054"></asp:button>&nbsp;
												<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
													onmouseout="this.className='Boton';" Runat="server" Width="126" CssClass="Boton" Height="19"
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
			<input id="btnModificar" style="DISPLAY: none" type="button" name="btnModificar" runat="server">
			<input id="btnEliminar" style="DISPLAY: none" type="button" name="btnEliminar" runat="server">
			<input id="hidCodigo" type="hidden" runat="server"> <input id="hidCargaInicial" type="hidden" runat="server">
			<input id="hidPV_Visible" type="hidden" name="hidPV" runat="server"> <input id="hidPlan_Visible" type="hidden" name="hidPlan" runat="server">
			<input id="hidKit_Visible" type="hidden" name="hidPlan" runat="server"> <input id="hidPDVs" type="hidden" name="hidPDVs" runat="server">
			<input id="hidOfiDescrips" type="hidden" name="hidOfiDescrips" runat="server"> <input id="hidOfiTipos" type="hidden" name="hidOfiTipos" runat="server">
			<input id="hidPlanes" type="hidden" name="hidPlanes" runat="server"> <input id="hidPlaDescrips" type="hidden" name="hidPlaDescrips" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
