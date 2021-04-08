<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_VentasDTHpostpago.aspx.vb" Inherits="sisact_VentasDTHpostpago"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<LINK title="win2k-cold-1" rel="stylesheet" type="text/css" href="../../../estilos/calendar-blue.css"
			media="all">
		<script type="text/javascript" src="../../../script/calendar/calendar.js"></script>
		<script type="text/javascript" src="../../../script/calendar/calendar_es.js"></script>
		<script type="text/javascript" src="../../../script/calendar/calendario_call.js"></script>
		<script type="text/javascript" src="../../../script/calendar/calendar_setup.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
			
			
			var primerslap;

			function formateafecha(fecha) 
			{ 
				var long = fecha.length; 
				var dia; 
				var mes; 
				var ano; 
				
				if ((long>=2) && (primerslap==false)) { dia=fecha.substr(0,2); 
				
					if ((IsNumeric(dia)==true) && (dia<=31) && (dia!="00")) { fecha=fecha.substr(0,2)+"/"+fecha.substr(3,7); primerslap=true; } 
					else { fecha=""; primerslap=false;} 
					} 
				else 
				{	dia=fecha.substr(0,1); 
					if (IsNumeric(dia)==false) 
					{fecha="";} 
					if ((long<=2) && (primerslap=true)) {fecha=fecha.substr(0,1); primerslap=false; } 
				} 
				
				if ((long>=5) && (segundoslap==false)) 
					{ mes=fecha.substr(3,2); 
						if ((IsNumeric(mes)==true) &&(mes<=12) && (mes!="00")) { fecha=fecha.substr(0,5)+"/"+fecha.substr(6,4); segundoslap=true; } 
						else { fecha=fecha.substr(0,3);; segundoslap=false;} 
					} 
				else { if ((long<=5) && (segundoslap=true)) { fecha=fecha.substr(0,4); segundoslap=false; } } 
				
				if (long>=7) 
					{ ano=fecha.substr(6,4); 
					if (IsNumeric(ano)==false) { fecha=fecha.substr(0,6); } 
				else { if (long==10){ if ((ano==0) || (ano<1900) || (ano>2100)) { fecha=fecha.substr(0,6); } } } 
				
				} 
			 
				if (long>=10) 
				{ 
					fecha=fecha.substr(0,10); 
					dia=fecha.substr(0,2); 
					mes=fecha.substr(3,2); 
					ano=fecha.substr(6,4); 
					// Año no viciesto y es febrero y el dia es mayor a 28 
				if ( (ano%4 != 0) && (mes ==02) && (dia > 28) ) { fecha=fecha.substr(0,2)+"/"; } 
				} 
				return (fecha); 
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			function IsNumeric(valor) 
			{ 
				var log=valor.length; var sw="S"; 
				for (x=0; x<log; x++){
					v1=valor.substr(x,1); 
					v2 = parseInt(v1); 
					//Compruebo si es un valor numérico 
					if (isNaN(v2)) { sw= "N";} 
					} 
				if (sw=="S") {return true;} else {return false; } 
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			
			function Limpiar()
			{
				
				setValue('txtNumeroDocId', '');
				setValue('txtSec', '');
				setValue('txtFechaInicio', '');
				setValue('txtFechaFin', '');
				setValue('ddlTipoDocId', '00');
				document.getElementById('ddlTipoOper').selectedIndex = 0;
				
				setValue('hidRequest', 'Limpiar');
				
				//document.frmPrincipal.submit();
				// return true;
				
			}
			
			function Busqueda()
			{
				
				if (validar()==false)
					return;
				
				setValue('hidRequest', 'Consulta');
				
				document.frmPrincipal.submit();
				return true;
				
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			function validar() {
			
				var strFechaInicio = getValue('txtFechaInicio');
				var strFechaFin = getValue('txtFechaFin');
				var strSec= getValue('txtSec');
				
				/*
				if(strFechaInicio == '' ){						
					alert("La fecha inicio es un dato requerido.");
					setFocus('txtFechaInicio');
					
					return false;
				}
				
				if(strFechaFin == '' ){						
					alert("La fecha fin es un dato requerido.");
					setFocus('txtFechaFin');
					
					return false;
				}
				
				if(strSec == '' ){						
					alert("Numero SEC es un dato requerido.");
					setFocus('txtSec');
					
					return false;
				}
				*/
				
				return consultar();
				
				
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			var arrayTipoDocPVU = ['01', '02', '03', '04', '06', '07'];
			var arrayTamaDocPVU = [ 8  ,  15 ,  15 ,  9 ,  11 ,  15 ];
			
			function cambiarNroDoc(valor) {
			
				setValue('txtNumeroDocId','');
				
				if (valor == '00') {
					// setReadOnly('txtNumeroDocId', true, 'clsInputDisable');
					if (isVisible('trBusqueda')) {
						setFocus('ddlTipoDocId');
					}
				}
				else {
					setReadOnly('txtNumeroDocId', false, 'clsInputEnable');

					var indexOf = getIndexOf(arrayTipoDocPVU, valor);
					document.getElementById('txtNumeroDocId').maxLength = arrayTamaDocPVU[indexOf];

					// Validar Ingreso Numerico solo para los Casos DNI y RUC
					if (valor == "01") { //DNI
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarNumero(event) };
					}
					else if (valor == "04") { //CE
						document.getElementById('txtNumeroDocId').onkeydown = function() { validarAlfaNumerico(event) };
					}

					if (isVisible('trBusqueda')) {
						setFocus('txtNumeroDocId');
					}
				}
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			function validarNumero(event) {
			
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
			
			//--------------------------------------------------------------------------------------------------------------
			
			function validarAlfaNumerico(event) {
				if (event.keyCode == 8 || event.keyCode == 46) {
					return;
				}
				if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
					return;
				}
				var key = event.keyCode;
				if ((key < 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key == 33) || (key == 34) || (key == 35) || (key == 36)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
					return;
				eventoAlfaNumerico(event);
			}
			
			//--------------------------------------------------------------------------------------------------------------

			function validarEnter(event) {
				
				if (event.keyCode == 13) {
					consultar();
					event.keyCode = 0;
					return false;
				}
				
			}
			
			//--------------------------------------------------------------------------------------------------------------
			
			function consultar() {
			
				var tipoDoc = getValue('ddlTipoDocId') == '00' ? '' : getValue('ddlTipoDocId');
				var numeroDoc = getValue('txtNumeroDocId');
				
				// Filtro por Tipo Documento
				if ( tipoDoc == "" ) {
					//alert('Error. Debe seleccionar un Tipo de Documento.');
					//setFocus('ddlTipoDocId');
					return true;
				}
				// Filtro por Numero Documento
				if ( numeroDoc == "") {
					//alert('Error. Debe ingresar un Numero de Documento.');
					//setFocus('txtNumeroDocId');
					return true;
				}
				
				var indexOf = getIndexOf(arrayTipoDocPVU, tipoDoc)
				// Validar Ingreso Numerico solo para los Casos DNI y RUC
				if (arrayTamaDocPVU[indexOf] != '15') {
					
					if ( !isNumber(numeroDoc) ) {
						alert('Error. Numero de Documento no válido.');
						setFocus('txtNumeroDocId');
						return false;
					}
					if (tipoDoc == "04") { //CE puede tener entre 8 y 9 digitos
						if ( numeroDoc.length < arrayTamaDocPVU[indexOf] - 1 || numeroDoc.length > arrayTamaDocPVU[indexOf]) {
							alert('Error. Numero de Documento debe contener por lo menos ' + (arrayTamaDocPVU[indexOf] - 1) + ' caracteres.');
							setFocus('txtNumeroDocId');
							return false;
						}
					}
					
					else {
						if ( numeroDoc.length != arrayTamaDocPVU[indexOf] ) {
							alert('Error. Numero de Documento debe contener ' + arrayTamaDocPVU[indexOf] + ' caracteres.');
							setFocus('txtNumeroDocId');
							return false;
						}
					}
					
				}
				
				return true;

			}
			
			//--------------------------------------------------------------------------------------------------------------
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td style="HEIGHT: 15px" class="header" height="15" align="left">Reporte de Ventas 
						DTH postpago
					</td>
				</tr>
				<tr>
					<td>
						<table class="contenido" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>&nbsp;&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" width="10%" align="center">Busqueda&nbsp;&nbsp;
								</td>
								<td class="Arial10B" width="10%" align="left">Fecha de venta del&nbsp;&nbsp;
								</td>
								<td width="50%"><input id="txtFechaInicio" class="clsInputEnable" onfocus="this.value='';" onkeyup="this.value=formateafecha(this.value);"
										maxLength="10" width="80" name="txtFechaInicio" runat="server"> <IMG style="BORDER-BOTTOM: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px; BORDE: 0px"
										id="btnFechaIni" border="0" src="../../../images/calendario.gif"> <font class="Arial10B">
										&nbsp;&nbsp;al&nbsp;&nbsp; </font><input id="txtFechaFin" class="clsInputEnable" onfocus="this.value='';" onkeyup="this.value=formateafecha(this.value);"
										maxLength="10" width="80" name="txtFechaFin" runat="server"> <IMG style="BORDER-BOTTOM: 0px; BORDER-TOP: 0px; CURSOR: pointer; BORDER-RIGHT: 0px; BORDE: 0px"
										id="btnFechaFin" border="0" src="../../../images/calendario.gif">
									<script type="text/javascript">
										Calendar.setup(
											{
												inputField     :    "txtFechaInicio",      // id of the input field
												ifFormat       :    "%d/%m/%Y",       // format of the input field
												button         :    "btnFechaIni",   // trigger for the calendar (button ID)
												singleClick    :    true,           // double-click mode
												step           :    1                // show all years in drop-down boxes (instead of every other year as default)
											}
										);
										
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
								</td>
								<td rowSpan="4" width="30%" align="left"><input style="WIDTH: 100px" id="btnbusqueda" class="Boton" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" onclick="Busqueda();" value="Busqueda" name="btnbusqueda">
									<asp:button id="btnExportar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										Runat="server" cssclass="Boton" Text="Exportar" Width="100px"></asp:button><input style="WIDTH: 100px" id="btnLimpiar" class="Boton" onmouseover="this.className='BotonResaltado';"
										onmouseout="this.className='Boton';" onclick="Limpiar();" value="Limpiar" name="btnLimpiar">
								</td>
							</tr>
							<tr>
								<td></td>
								<td class="Arial10B" align="left">Sec
								</td>
								<td><input id="txtSec" class="clsInputEnable" maxLength="20" width="80" name="txtSec" runat="server">
								</td>
								<td></td>
							</tr>
							<tr>
								<td></td>
								<td class="Arial10B" align="left">Tipo Documento
								</td>
								<td><asp:dropdownlist onkeydown="javascript:validarEnter(event);" id="ddlTipoDocId" runat="server" Width="150"
										onchange="javascript:cambiarNroDoc(this.value);" cssClass="clsSelectEnable"></asp:dropdownlist>&nbsp;&nbsp; 
									Nro Documento&nbsp;&nbsp;
									<asp:textbox onkeydown="javascript:validarNumero(event);" id="txtNumeroDocId" onkeyup="javascript:validarEnter(event);"
										Runat="server" Width="100" cssClass="clsInputEnable" maxLength="11"></asp:textbox></td>
								<td></td>
							</tr>
							<tr>
								<td></td>
								<td class="Arial10B" align="left">Tipos de Estado
								</td>
								<td><asp:dropdownlist id="ddlTipoOper" Runat="server" cssClass="clsSelectEnable"></asp:dropdownlist></td>
								<td></td>
							</tr>
							<tr>
								<td><input style="WIDTH: 16px; HEIGHT: 22px" id="hidRequest" type="hidden" name="hidRequest"
										runat="server">&nbsp;&nbsp; <input style="WIDTH: 16px; HEIGHT: 22px" id="hidCodPuntoVenta" type="hidden" name="hidCodPuntoVenta"
										runat="server">&nbsp;&nbsp; <input style="WIDTH: 16px; HEIGHT: 22px" id="hidDesPuntoVenta" type="hidden" name="hidDesPuntoVenta"
										runat="server">&nbsp;&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;&nbsp;
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td align="center">
									<div style="WIDTH: 100%; HEIGHT: 250px" id="divGrid" class="clsGridRow"><asp:datagrid id="dgLista" Runat="server" Width="100%" height="25px" AutoGenerateColumns="False"
											ShowHeader="True" BorderWidth="0">
											<HeaderStyle HorizontalAlign="Left" Height="22px" BorderWidth="1px" BorderColor="#999999" CssClass="TablaTitulos"></HeaderStyle>
											<ItemStyle Wrap="False" HorizontalAlign="Left" CssClass="Arial10B" Width="70px" backcolor="#E9EBEE"></ItemStyle>
											<Columns>
												<asp:BoundColumn DataField="NUMERO_SEC" HeaderText="SEC"></asp:BoundColumn>
												<asp:BoundColumn DataField="NUMERO_SOT" HeaderText="SOT"></asp:BoundColumn>
												<asp:BoundColumn DataField="ESTADO_SOT" HeaderText="ESTADO DE LA SOT"></asp:BoundColumn>
												<asp:BoundColumn DataField="NOMBRE_CLIENTE" HeaderText="CLIENTE"></asp:BoundColumn>
												<asp:BoundColumn DataField="OBSERVACION_SOT" HeaderText="OBSERVACION DE LA SOT"></asp:BoundColumn>
												<asp:BoundColumn DataField="MONTO_RA" HeaderText="MONTO RA"></asp:BoundColumn>
											</Columns>
										</asp:datagrid></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
