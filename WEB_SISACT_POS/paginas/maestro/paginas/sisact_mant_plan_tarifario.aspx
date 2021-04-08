<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_plan_tarifario.aspx.vb" Inherits="sisact_mant_plan_tarifario"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Mantenimiento Plan Tarifario</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="ConsumerValidacion.js"></script>
		<script language="javascript" type="text/javascript">
			function f_EventoSoloNumerosEnteros()
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
			
			function fSoloMontosPorcentaje(event, obj){
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey)
					return false;
					
				var decimales = 0;
				var cantidad_decimales = 2;
				var salida = false;	
				if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105)){ // check digits
					if (obj.value == "0") return false;
					if (parseInt(obj.value) > 100)
					{
					 alert('El valor máximo de % debe ser 100');
					 obj.value='';
					 return false;
					} 
					if (parseInt(obj.value) <0)
					{
					 alert('El valor mínimo de % debe ser 0');
					 obj.value='';
					 return false;
					}
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
			
			//inactivar las cuotas
			function f_InactivarCuotas(txt,chk)
			{			
				if (chk.checked)
				{
					document.getElementById(txt).readOnly = false;
					document.getElementById(txt).className = 'clsInputEnable';
					document.getElementById(txt).focus();				
				}
				else
				{
					document.getElementById(txt).readOnly = true;
					document.getElementById(txt).className = 'clsInputDisable';
					document.getElementById(txt).value = ""
				}
			}
			/*
			function fMostrarPDV()
			{

					trPDV.style.display = 'block';

			}*/

			function cargarPopUpPdv()
			{
				window.open("sisact_pop_cargarPdv.aspx",null,"width=800,height=540,top=150px,left=200px");
			}

			function refrescarPdv()
			{
				document.getElementById("hidCondicion").value="PDV";
				frmPlanTarifario.submit();
			}							
			
			function fMostrarDetalle()
			{
					trDetalle.style.display = 'block';
			}

			function cargarPopUpDetalle()
			{
				window.open("sisact_pop_detalle_plan.aspx",null,"width=500,height=240,top=150px,left=200px");
			}

			function refrescarDetalle()
			{
				document.getElementById("hidCondicion").value="DETALLE";
				frmPlanTarifario.submit();
			}	
			
			function fMostrarGrupo()
			{
			}

			function cargarPopUpGrupo()
			{
				window.open("sisact_mant_agregar_grupo.aspx",null,"width=500,height=140,top=150px,left=200px");
			}

			function refrescarGrupo()
			{
				document.getElementById("hidCondicion").value="GRUPO";
				frmPlanTarifario.submit();
			}
			
			function f_Buscar()
			{	
				//f_MostrarTab('BUSQUEDA')			;
				if (getValue('ddlBusqueda') == '0' && getValue('txtBusDescripcion') == '')
				{
					alert('Debe ingresar una Descripción.');
					setFocus('txtBusDescripcion');
					return false;
				}
			}
			
			function f_Limpiar()
			{
			//$("#txtBusDescripcion").val('');
				setValue('txtBusDescripcion', '');
			}
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{
						document.getElementById('<%=btnBuscar.ClientId%>').click;
						event.keyCode = 0;
					}
				}
			}
			
			function f_MostrarTab(valor)
			{
					setVisible('trBusqueda', false);	
					setVisible('trGrilla', false);	
					setVisible('trEdicion', false);
						
				if (valor == 'BUSQUEDA')
				{
					setVisible('trBusqueda', true);	
					setVisible('trGrilla', true);	
					
					document.getElementById('tdListado').className='tab_activo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_inactivo';
					document.getElementById('tdModificar').style.display='none';
				}
				if (valor == 'NUEVO')
				{
					setVisible('trEdicion', true);	
					
					document.getElementById('tdListado').className='tab_inactivo';
					document.getElementById('tdAgregar').style.display='inline';
					document.getElementById('tdAgregar').className='tab_activo';
					document.getElementById('tdModificar').style.display='none';
					
					var ddlEst=document.getElementById("ddlEstado");
					ddlEst.disabled=true;

					
					f_mostrarPestaña(1);
				}
				if (valor == 'EDICION')
				{
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
			
			function f_Modificar(cod)
			{
				setValue('hidCodigo',cod);
				__doPostBack('btnModificar','');
			}
			
			function f_Agregar()
			{
				setValue('hidCodigo','');
				f_mostrarPestaña(1);
				__doPostBack('btnAgregar','');
			}
			
			
			function f_Eliminar(cod)
			{
				if (confirm('¿Esta seguro de inactivar este registro?'))
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
			
			function f_EliminarTodosPDV()
			{
				if (confirm('¿Esta seguro de quitar todos los registros?'))
				{
					__doPostBack('btnEliminarTodosPDV','');
				}
			}
			
			function f_EliminarPDV(cod)
			{
			//alert(cod);
				if (confirm('¿Esta seguro de quitar este registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminarPDV','');
				}
			}
			
			function f_EliminarCanal(cod)
			{
			//alert(cod);
				if (confirm('¿Esta seguro de quitar este registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminarCanal','');
				}
			}
			
			function f_EliminarTodosDetallePlan()
			{
				if (confirm('¿Esta seguro de quitar todos los registros?'))
				{
					__doPostBack('btnEliminarTodosDetallePlan','');
				}
			}
			
			function f_EliminarDetallePlan(cod)
			{
			//alert(cod);
				if (confirm('¿Esta seguro de quitar este registro?'))
				{
					setValue('hidCodigo',cod);
					__doPostBack('btnEliminarDetallePlan','');
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
				/*validando el codigo del plan exista*/
				if (getValue('txtCodPlanSisact') == '')
				{
					alert('Ingresar Código Plan');
					setFocus('txtCodPlanSisact');
					return false;
				}
				
				/*validando la descripcion del plan a ingresar exista*/
				if (getValue('txtDesPlanSisact') == '')
				{
					alert('Ingresar descripción del plan');
					setFocus('txtDesPlanSisact');
					return false;
				}
				
				/*validacion de la seleccion del grupo*/
				var ddlGrupo=document.getElementById("ddlGrupoPlan");
				var valorG=ddlGrupo.options[ddlGrupo.selectedIndex].value;
				if (valorG=="")
				{
					alert('Seleccionar el Grupo del Plan');
					setFocus('ddlGrupoPlan');
					return false;
				}
				/*validacion de cargo fijo que no debe estar vacío*/
				var txtCargo=document.getElementById("txtCargoFijo");
				var txtCa=txtCargo.value;
				if (txtCa=="")
				{
					alert('Ingresar Cargo Fijo del Plan');
					setFocus('txtCargoFijo');
					txtCargo.value = '0.0';
					return false;
				}
				
				/*validacion de límite de credito que no debe estar vacío*/
				var txtLimite=document.getElementById("txtLimiteCredito");
				var txtL=txtLimite.value;
				if (txtL=="")
				{
					alert('Ingresar Límite de Crédito del Plan');
					setFocus('txtLimiteCredito');
					txtLimite.value = '0.0';
					return false;
				}				
				
				/*validando la grilla con el tope de consumo*/
				var tabla = document.getElementById('dgrTopeConsumoDetalle');
				var rows = tabla.getElementsByTagName('tr');
				var contSel = 0;
				var contHab = 0;
				var contSelEdit = 0;
									
				for (i=0; i<rows.length; i++)
				{
					var columns = rows[i].getElementsByTagName('td');
					if (columns.length > 0)
					{
						var cadenaHTML, arrayCadenaHTML;
						arrayCadenaHTML = columns[2].innerHTML.split('>');
						
						for (ii=0; ii<arrayCadenaHTML.length; ii++)
						{		
							if(arrayCadenaHTML[ii].indexOf('selected') != -1)
							{
								var codTope = arrayCadenaHTML[ii].split('=')[1].substring(0,1);	
								
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoHabilitado") %>")	
									contHab = contHab + 1;
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoSelect") %>")	
									contSel = contSel + 1;
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoSelectEdit") %>")	
									contSelEdit = contSelEdit + 1;
							}
						}
					}
				}	
				
				if (contSel > 1)
				{
					alert("No puede haber más de un registro seleccionado.");
					return false;
				}
				if (contSelEdit > 1)
				{
					alert("No puede haber más de un registro seleccionado-editable.");					
					return false;
				}
				if (contSel == 1 && contHab > 0)
				{
					alert("No puede haber registros habilitados si hay uno seleccionado.");
					return false;
				}
				if (contSel == 1 && contSelEdit > 0)
				{
					alert("No puede haber registros seleccionado-editable si hay uno seleccionado.");
					return false;
				}
				if (contSelEdit == 1 && contSel > 0)
				{
					alert("No puede haber registros seleccionados si hay uno seleccionado-editable.");
					return false;
				}
				
				return true;				
			}
			
			function validaCaracteres() 
			{
				var CaracteresPermitidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_-() ";
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++)
				{
					if (key == valid.substring(i,i+1))
						ok = "yes";
				}
				if (ok == "no")
					window.event.keyCode=0;

				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}	
			
			function copiarPlan(txt,chk)
			{
				if (chk.checked)
					document.getElementById(txt).value = getValue('txtCodPlanSisact'); 
				else
					document.getElementById(txt).value = "";
			}
			
			function f_ValidarGrabar_Plan()
			{	
				var tabla = document.getElementById('dgrTopeConsumoDetalle');
				var rows = tabla.getElementsByTagName('tr');
				var contSel = 0;
				var contHab = 0;
				var contSelEdit = 0;
									
				for (i=0; i<rows.length; i++)
				{
					var columns = rows[i].getElementsByTagName('td');
					if (columns.length > 0)
					{
						var cadenaHTML, arrayCadenaHTML;
						arrayCadenaHTML = columns[2].innerHTML.split('>');
						
						for (ii=0; ii<arrayCadenaHTML.length; ii++)
						{		
							if(arrayCadenaHTML[ii].indexOf('selected') != -1)
							{
								var codTope = arrayCadenaHTML[ii].split('=')[1].substring(0,1);	
								
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoHabilitado") %>")	
									contHab = contHab + 1;
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoSelect") %>")	
									contSel = contSel + 1;
								if (codTope == "<%= ConfigurationSettings.AppSettings("ConstEstadoSelectEdit") %>")	
									contSelEdit = contSelEdit + 1;
							}
						}
					}
				}	
				
				if (contSel > 1)
				{
					alert("Error: No puede haber más de un registro seleccionado.");
					return false;
				}
				if (contSelEdit > 1)
				{
					alert("Error: No puede haber más de un registro seleccionado-editable.");					
					return false;
				}
				if (contSel == 1 && contHab > 0)
				{
					alert("Error: No puede haber registros habilitados si hay uno seleccionado.");
					return false;
				}
				if (contSel == 1 && contSelEdit > 0)
				{
					alert("Error: No puede haber registros seleccionado-editable si hay uno seleccionado.");
					return false;
				}
				if (contSelEdit == 1 && contSel > 0)
				{
					alert("Error: No puede haber registros seleccionados si hay uno seleccionado-editable.");
					return false;
				}
				
				return true;
			}
			
			function f_mostrarPestaña(ind){
				//debugger;
				//document.getElementById("trCampanias").style.display='none';
				document.getElementById("trPDV").style.display='none';
				document.getElementById("trDetalle").style.display='none';
				//document.getElementById("trRestricciones").style.display='none';
				//document.getElementById("hidIndice").value=ind;
				//document.getElementById("lblMensaje").innerHTML = "";

				if(ind == 1) //Campanias
				{
					document.getElementById("trPDV").style.display='block';
					/*
					document.getElementById("tdCampanias").bgColor="#f59130";
					document.getElementById("tdPDV").bgColor="#ffffff";*/
					//document.getElementById("trPDV").style.color="#ffffff";
					
					//document.getElementById("trDetalle").style.backgroundColor = "#f59130";
					//document.getElementById("trDetalle").style.color="ffffff";
					
				}
				else if(ind == 2) //Puntos de Venta
				{
					document.getElementById("trDetalle").style.display='block';
					/*document.getElementById("tdPDV").bgColor="#f59130";
					document.getElementById("tdCampanias").bgColor="#ffffff";
					document.getElementById("tdCampanias").bgColor="#ffffff";*/
					
					//document.getElementById("trDetalle").style.color="ffffff";
					
					//document.getElementById("trPDV").style.backgroundColor = "#f59130";
					//document.getElementById("trPDV").style.color="#ffffff";					
				}
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
		<form id="frmPlanTarifario" method="post" runat="server">
			<table id="tblContenido" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td class="header" style="WIDTH: 980px; HEIGHT: 23px" align="center">Mantenimiento 
						de Plan
					</td>
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
										<!----------------------TR para establecer los criterios de busqueda--------------->
										<tr id="trBusqueda">
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="header" style="HEIGHT: 19px" align="left" colSpan="6">&nbsp;Busqueda de 
															Plan
														</td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Plan :</TD>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlBusqueda" Runat="server" Width="100px" CssClass="clsSelectEnable" onchange=" f_InactivarTxtLista();">
																<asp:ListItem Value="0">DESCRIPCIÓN</asp:ListItem>
																<asp:ListItem Value="1">TODOS</asp:ListItem>
															</asp:dropdownlist>
															&nbsp;<asp:textbox onpaste="return false" id="txtBusDescripcion" onkeydown="javascript:f_ValidarEnter();"
																runat="server" Width="200px" CssClass="clsInputEnable" MaxLength="50"></asp:textbox>
															&nbsp;<asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19" Text="Buscar"></asp:button>&nbsp;
															<asp:button id="btnLimpiar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
																onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19"
																Text="Limpiar"></asp:button></td>
													</tr>
													<tr>
														<TD class="Arial10B" style="WIDTH: 80px">&nbsp;Estado :</TD>
														<td style="HEIGHT: 26px">&nbsp;<asp:dropdownlist id="ddlEstadoListado" Runat="server" Width="100px" CssClass="clsSelectEnable" onchange=" f_InactivarTxtLista();">
																<asp:ListItem Value="0">INACTIVO</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">ACTIVO</asp:ListItem>
															</asp:dropdownlist>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
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
														<asp:templatecolumn headertext="CÓDIGO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="60px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="PLAN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="220px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="OFERTA ">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TIPO PRODUCTO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CODIGO SAP">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CODIGO BSCS">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TIPO DESPACHO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TIPO FLUJO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="EXCLUSIVO CE">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="TIPO PLAN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="GRUPO PLAN">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="CARGO FIJO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="LIMITE CREDITO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
														</asp:templatecolumn>
														<asp:templatecolumn headertext="ESTADO">
															<headerstyle horizontalalign="Center" cssclass="TablaTitulos" width="100px" Wrap="False"></headerstyle>
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
									<div class="clsGridRow" id="divGrillaDetalle" style="WIDTH: 690px; HEIGHT: 374px">
										<table cellSpacing="0" cellPadding="0" width="600" border="0">
											<tr>
												<td><asp:datagrid id="dgrGrillaDetalle" runat="server" autogeneratecolumns="False" showheader="True"
														AllowPaging="True">
														<alternatingitemstyle backcolor="#dddee2"></alternatingitemstyle>
														<itemstyle cssclass="Arial10B" backcolor="#E9EBEE"></itemstyle>
														<columns>
															<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																<itemstyle horizontalalign="Center"></itemstyle>
																<itemtemplate>
																	<a href='javascript:f_Modificar("<%# DataBinder.Eval(Container.DataItem, "PLANC_CODIGO")%>");'>
																		<img src="../../images/btn_edit.jpg" border="0" alt='Modificar Plan'> </a>
																</itemtemplate>
															</asp:templatecolumn>
															<asp:boundcolumn datafield="PLANC_CODIGO" Visible="False"></asp:boundcolumn>
															<asp:BoundColumn DataField="PLANC_CODIGO" itemstyle-cssclass="Arial10B" HeaderText="CODIGO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" horizontalalign="Center" width="60px"></itemstyle>
															</asp:BoundColumn>
															<asp:boundcolumn datafield="PLANV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="PLAN">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="220px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="TOFV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="OFERTA ">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PRDV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="TIPO PRODUCTO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="CODIGO_SAP" itemstyle-cssclass="Arial10B" HeaderText="CODIGO SAP">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="CODIGO_BSCS" itemstyle-cssclass="Arial10B" HeaderText="CODIGO BSCS">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="DPCHV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="TIPO DESPACHO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLNV_TIPO_FLUJO" itemstyle-cssclass="Arial10B" HeaderText="TIPO FLUJO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLNC_EXCLUSIVO_CE" itemstyle-cssclass="Arial10B" HeaderText="EXCLUSIVO CE">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLNV_TIPO_PLAN" itemstyle-cssclass="Arial10B" HeaderText="TIPO PLAN">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="GPLNV_DESCRIPCION" itemstyle-cssclass="Arial10B" HeaderText="GRUPO PLAN">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLANN_CAR_FIJ" itemstyle-cssclass="Arial10B" HeaderText="CARGO FIJO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLANN_LIM_CRED_CON" itemstyle-cssclass="Arial10B" HeaderText="LIMITE CREDITO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
															</asp:boundcolumn>
															<asp:boundcolumn datafield="PLANC_ESTADO" itemstyle-cssclass="Arial10B" HeaderText="ESTADO">
																<headerstyle horizontalalign="Center" cssclass="TablaTitulos"></headerstyle>
																<itemstyle wrap="False" width="100px"></itemstyle>
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
														onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19" Text="Eliminar"
														Visible="False"></asp:button><asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
														onmouseout="this.className='Boton';" Runat="server" Width="90" CssClass="Boton" Height="19" Text="Exportar CSV" Visible="False"></asp:button></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<!-------------------- TR para el panel de Nuevo/Editar ------------------>
							<tr id="trEdicion" width="100%">
								<td>
									<table cellSpacing="0" cellPadding="1" width="690" border="0">
										<tr>
											<td class="header" colSpan="5" height="25">&nbsp;Detalle</td>
										</tr>
										<TR> <!--Codigo Del Plan Sisact-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Código Plan Sisact (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" onkeypress="f_EventoSoloNumerosEnteros();" id="txtCodPlanSisact"
													runat="server" MaxLength="3" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!--Oferta-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Oferta (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlOferta" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!-- Tipo de Producto - -->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Tipo de Producto (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTipoProducto" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!--Descripción Plan-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Descripción Plan (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" onkeypress="validaCaracteres();" id="txtDesPlanSisact" runat="server"
													MaxLength="40" width="300px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!--Código Plan SAP-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Código Plan SAP</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" onkeypress="f_EventoSoloNumerosEnteros();" id="txtCodPlanSAP"
													runat="server" MaxLength="3" width="100px" cssclass="clsInputEnable"></asp:textbox>&nbsp;<asp:checkbox id="chkCopiarPlan" onclick="copiarPlan('txtCodPlanSAP', this);" runat="server" Text="Copiar código SISACT"></asp:checkbox>
											</TD>
											<TD class="Arial10B"></TD>
										</TR>
										<TR> <!--Código Plan BSCS-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Código Plan BSCS</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" onkeypress="f_EventoSoloNumerosEnteros();" id="txtCodPlanBSCS"
													runat="server" MaxLength="4" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B"></TD>
										</TR>
										<TR> <!--Descripción Plan Base-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Descripción Plan Base</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" onkeypress="validaCaracteres();" id="txtDesPlanBase" runat="server"
													MaxLength="40" width="300px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<tr> <!--Estado-->
											<td class="Arial10B" style="WIDTH: 200px">&nbsp;Estado Plan (*)</td>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlEstado" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</tr>
										<TR> <!-- Tipo de Despacho -->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Tipo de Despacho (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTipoDespacho" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!-- Tipo de Flujo --Alta/Portabilidad-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Alta / Portabilidad (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTipoFlujo" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<!--<TR> 
											<TD style="WIDTH: 205px" class="Arial10B">&nbsp;Tipo de Cliente (*)</TD> --Restriccion por canal
											<TD style="WIDTH: 5px" class="Arial10B">:</TD>
											<TD style="WIDTH: 400px" class="Arial10B"><asp:dropdownlist id="ddlTipoCliente" runat="server" width="100px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> 
											<TD style="WIDTH: 205px" class="Arial10B">&nbsp;Tipo de Cliente (*)</TD>--restriccion por PDV
											<TD style="WIDTH: 5px" class="Arial10B">:</TD>
											<TD style="WIDTH: 400px" class="Arial10B"><asp:dropdownlist id="Dropdownlist3" runat="server" width="100px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> 
											<TD style="WIDTH: 205px" class="Arial10B">&nbsp;Tipo de Cliente (*)</TD>
											<TD style="WIDTH: 5px" class="Arial10B">:</TD>
											<TD style="WIDTH: 400px" class="Arial10B"><asp:dropdownlist id="Dropdownlist4" runat="server" width="100px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>-->
										<TR> <!--  Exclusivo caso especial -->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Exclusivo Caso Especial (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlExcCasoEsp" runat="server" width="160px" cssclass="clsSelectEnable">
													<asp:ListItem Value="1">SI</asp:ListItem>
													<asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!-- Tipo de Plan -->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Tipo de Plan (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTipoPlan" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!-- Grupo de plan -->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Grupo de Plan (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlGrupoPlan" runat="server" width="160px" cssclass="clsSelectEnable"></asp:dropdownlist>
												<INPUT class="Boton" id="btnAgregarGrupo" onclick="cargarPopUpGrupo();" type="button" value="Agregar"
													name="btnAgregarGrupo" Width="90"></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<!--cuotas -->
										<!-- fin cuotas -->
										<!-- Documento -->
										<!--TR> 
											<TD class="Arial10B" style="WIDTH: 205px; HEIGHT: 22px">&nbsp;Documento (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:checkboxlist id="ctlTipoDocumento" runat="server" CssClass="Arial11BV"></asp:checkboxlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR-->
										<TR> <!--Cargo Fijo-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Cargo Fijo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" id="txtCargoFijo" onkeydown="return fSoloMontos(event, this);"
													runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> <!--Límite de Crédito-->
											<TD class="Arial10B" style="WIDTH: 200px">&nbsp;Límite de Crédito (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:textbox onPaste="return false" id="txtLimiteCredito" onkeydown="return fSoloMontos(event, this);"
													runat="server" MaxLength="7" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<!-- Plazo Acuerdo -->
										<!--TR> 
											<TD class="Arial10B" style="WIDTH: 205px; HEIGHT: 22px">&nbsp;Plazo Acuerdo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px; HEIGHT: 22px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:checkboxlist id="ctlPlazoAcuerdo" runat="server" CssClass="Arial11BV"></asp:checkboxlist></TD>
											<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
										</TR-->
										<!--TR> 
											<TD class="Arial10B" style="WIDTH: 205px">&nbsp;Tope de Consumo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlTopeConsumo" runat="server" width="179px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR>
										<TR> 
											<TD class="Arial10B" style="WIDTH: 205px">&nbsp;Estado Tope Consumo (*)</TD>
											<TD class="Arial10B" style="WIDTH: 5px">:</TD>
											<TD class="Arial10B" style="WIDTH: 400px"><asp:dropdownlist id="ddlEstadoTope" runat="server" width="179px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
											<TD class="Arial10B" colSpan="2"></TD>
										</TR-->
										<TR>
											<TD class="Arial10B" colSpan="6">
												<div>
													<table cellSpacing="1" cellPadding="0" border="0">
														<tr>
															<td><asp:datagrid id="dgrTopeConsumoDetalle" runat="server" showheader="False" autogeneratecolumns="False"
																	CellSpacing="0" CellPadding="1" BorderWidth="0">
																	<columns>
																		<asp:boundcolumn datafield="TPCV_DESCRIPCION" itemstyle-cssclass="Arial10B">
																			<headerstyle horizontalalign="Center"></headerstyle>
																			<itemstyle wrap="False" width="198px"></itemstyle>
																		</asp:boundcolumn>
																		<asp:TemplateColumn ItemStyle-Width="5px" itemstyle-cssclass="Arial10B">
																			<ItemTemplate>
																				<asp:Label ID="lblPuntos" Runat="server">:</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:boundcolumn datafield="TPCN_CODIGO" Visible="False"></asp:boundcolumn>
																		<asp:TemplateColumn headerstyle-width="40px" itemstyle-cssclass="Arial10B" itemstyle-width="40px">
																			<ItemTemplate>
																				<asp:DropDownList ID="ddlConsumoEstado" Runat="server" Width="160px" cssclass="clsSelectEnable"></asp:DropDownList>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:boundcolumn datafield="TPCN_CODIGO" Visible="False" />
																	</columns>
																</asp:datagrid></td>
														</tr>
													</table>
												</div>
											</TD>
										</TR>
										<tr id="trPestanas" runat="server">
											<td colSpan="7"><br>
												<table borderColor="#f48d29" cellSpacing="1" cellPadding="1" width="100%" align="center"
													border="1">
													<tr width="100%">
														<td class="Arial11BV" id="tdCampanias" style="PADDING-LEFT: 15px; CURSOR: hand; COLOR: white; BACKGROUND-COLOR: #325493"
															onclick="f_mostrarPestaña(1);" align="center" width="25%">
															<P><FONT size="2"><STRONG>Restricción PDV</STRONG></FONT><FONT size="2"><STRONG></STRONG></FONT></P>
														</td>
														<td class="Arial11BV" id="tdPDV" style="CURSOR: hand" onclick="f_mostrarPestaña(2);"
															align="center" width="25%" bgColor="#f59130"><FONT color="#ffffff" size="2"><STRONG>Restricción 
																	Cuota</STRONG> </FONT>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr id="trPDV">
											<TD class="Arial10B" colSpan="5" height="25">
												<TABLE id="tblPDV" style="BORDER-COLLAPSE: collapse" borderColor="#95b7f3" cellSpacing="0"
													cellPadding="0" width="616" align="center" border="1">
													<TR>
														<TD class="header" borderColor="#ffffff" align="center" height="20">PDV
														</TD>
													</TR>
													<TR>
														<TD borderColor="#ffffff" colSpan="2"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></TD>
													</TR>
													<TR id="trBusquedaPdv" runat="server">
														<TD class="Arial11BV" style="HEIGHT: 9px"><INPUT class="Boton" id="btnAgregarPDV" onclick="cargarPopUpPdv();" type="button" value="Agregar"
																name="btnAgregarPDV">
														</TD>
													</TR>
													<TR id="trGrillaPdv" align="center" runat="server">
														<TD><asp:datagrid id="dgPDV" runat="server" Width="100%" AllowPaging="True" CellSpacing="2" CellPadding="1"
																BorderColor="#95B7F3" AutoGenerateColumns="False" DataKeyField="OVENC_CODIGO" PageSize="7">
																<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
																<HeaderStyle HorizontalAlign="Center" Width="12px" CssClass="TablaTitulos"></HeaderStyle>
																<Columns>
																	<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																		<HeaderStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																		<HeaderTemplate>
																			<a href='javascript:f_EliminarTodosPDV("<%# DataBinder.Eval(Container.DataItem, "OVENC_CODIGO")%>");'>
																				<img src="../../images/ico_Eliminar.gif" border="0"></a>
																		</HeaderTemplate>
																		<itemstyle horizontalalign="Center"></itemstyle>
																		<itemtemplate>
																			<a href='javascript:f_EliminarPDV("<%# DataBinder.Eval(Container.DataItem, "OVENC_CODIGO")%>");'>
																				<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Plan'></a>
																		</itemtemplate>
																	</asp:templatecolumn>
																	<asp:BoundColumn DataField="OVENC_CODIGO" HeaderText="Codigo"></asp:BoundColumn>
																	<asp:BoundColumn DataField="OVENV_DESCRIPCION" HeaderText="Descripcion"></asp:BoundColumn>
																	<asp:BoundColumn DataField="CANAC_CODIGO" HeaderText="Canal"></asp:BoundColumn>
																</Columns>
																<PagerStyle Font-Size="12px" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</tr>
										<tr id="trDetalle">
											<TD class="Arial10B" colSpan="5" height="25">
												<TABLE id="TblDetalle" style="BORDER-COLLAPSE: collapse" borderColor="#95b7f3" cellSpacing="0"
													cellPadding="0" width="616" align="center" border="1">
													<TR>
														<TD class="header" borderColor="#ffffff" align="center" height="20">Detalle
														</TD>
													</TR>
													<TR>
														<TD borderColor="#ffffff" colSpan="2"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></TD>
													</TR>
													<TR id="Tr3" runat="server">
														<TD class="Arial11BV" style="HEIGHT: 9px"><INPUT class="Boton" id="btnAgregarDetallePlan" onclick="cargarPopUpDetalle();" type="button"
																value="Agregar" name="btnAgregarDetallePlan">
														</TD>
													</TR>
													<TR id="Tr4" align="center" runat="server">
														<TD><asp:datagrid id="dgDetallePlan" runat="server" Width="100%" AllowPaging="True" CellSpacing="2"
																CellPadding="1" BorderColor="#95B7F3" AutoGenerateColumns="False" DataKeyField="IdDocumento"
																PageSize="7">
																<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
																<HeaderStyle HorizontalAlign="Center" Width="12px" CssClass="TablaTitulos"></HeaderStyle>
																<Columns>
																	<asp:boundcolumn datafield="IdDocumento" Visible="False"></asp:boundcolumn>
																	<asp:boundcolumn datafield="IdPlazo" Visible="False"></asp:boundcolumn>
																	<asp:boundcolumn datafield="IdCuota" Visible="False"></asp:boundcolumn>
																	<asp:templatecolumn headertext="" headerstyle-width="25px" itemstyle-width="25px">
																		<HeaderStyle Width="30px" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																		<HeaderTemplate>
																			<a href='javascript:f_EliminarTodosDetallePlan("<%# DataBinder.Eval(Container.DataItem, "IdDocumento")%>,<%# DataBinder.Eval(Container.DataItem, "IdPlazo")%>,<%# DataBinder.Eval(Container.DataItem, "IdCuota")%>");'>
																				<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Plan'></a>
																		</HeaderTemplate>
																		<itemstyle horizontalalign="Center"></itemstyle>
																		<itemtemplate>
																			<a href='javascript:f_EliminarDetallePlan("<%# DataBinder.Eval(Container.DataItem, "IdDocumento")%>,<%# DataBinder.Eval(Container.DataItem, "IdPlazo")%>,<%# DataBinder.Eval(Container.DataItem, "IdCuota")%>");'>
																				<img src="../../images/ico_Eliminar.gif" border="0" alt='Desactivar Plan'></a>
																		</itemtemplate>
																	</asp:templatecolumn>
																	<asp:BoundColumn DataField="DescripcionDocumento" HeaderText="Tipo Documento"></asp:BoundColumn>
																	<asp:BoundColumn DataField="DescripcionPlazo" HeaderText="Plazo Acuerdo"></asp:BoundColumn>
																	<asp:BoundColumn DataField="DescripcionCuota" HeaderText="Cuota"></asp:BoundColumn>
																	<asp:BoundColumn DataField="ValorCuota" HeaderText="% Cuota Inicial"></asp:BoundColumn>
																</Columns>
																<PagerStyle Font-Size="12px" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</tr>
										<!-- fin restriccion PDV-->
										<tr height="25">
											<td align="center" colSpan="5"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
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
			<input id="btnEliminarDetalle" style="DISPLAY: none" type="button" name="btnEliminarDetalle"
				runat="server"> <input id="btnEliminarPDV" style="DISPLAY: none" type="button" name="btnEliminarPDV" runat="server">
			<input id="btnEliminarTodosPDV" style="DISPLAY: none" type="button" name="btnEliminarTodosPDV"
				runat="server"> <input id="btnEliminarCanal" style="DISPLAY: none" type="button" name="btnEliminarCanal"
				runat="server"> 
				
				<input id="btnEliminarTodosDetallePlan" style="DISPLAY: none" type="button" name="btnEliminarTodosDetallePlan" runat="server">
				
				
				<input id="btnEliminarDetallePlan" style="DISPLAY: none" type="button" name="btnEliminarDetallePlan"
				runat="server">&nbsp; <input id="hidCodigo" type="hidden" name="hidCodigo" runat="server" style="WIDTH: 123px; HEIGHT: 22px"
				size="15"> <input id="hidCargaInicial" type="hidden" name="hidCargaInicial" runat="server" style="WIDTH: 123px; HEIGHT: 22px"
				size="15"> <input id="hidCondicion" type="hidden" name="hidCondicion" runat="server" style="WIDTH: 123px; HEIGHT: 22px"
				size="15">
		</form>
	</body>
</HTML>
 
 
 
 
