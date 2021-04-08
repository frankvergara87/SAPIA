<%@ Page Language="vb" AspCompat="true" AutoEventWireup="false" Codebehind="sisact_interaccion_dol.aspx.vb" Inherits="sisact_interaccion_dol"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Registro DOL</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
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
		<script language="javascript" src="../../librerias/validaciones.js"></script>
		<SCRIPT language="javascript">
		
			function inicio(){
				if(document.getElementById('hidAccion').value == 'C'){
					var vCargarDatosLinea = document.getElementById('hidCargarDatosLinea').value ;
					var vCargarDatosRecarga = "";
					window.parent.f_retornar();							
					
					//location.href = "sisact_registro_dol.aspx?cu=" + document.getElementById("hidUsuarioExt").value;
					return;
				}else{								
					if (document.getElementById('hidFocus').value !=''){
						// validacion de la plantilla
						document.getElementById(document.getElementById('hidFocus').value).focus();
					}				
					if (document.getElementById('hidAccion').value == 'OK_CLOSE' ){ //cierra y refresca la ventana de datos generales
						document.getElementById('btnGrabar').style.display = 'none';
						if(document.getElementById('hidMsg').value != '')
							alert(document.getElementById('hidMsg').value);					
						var vCargarDatosLinea = document.getElementById('hidCargarDatosLinea').value ;
						var vCargarDatosRecarga = "";
						window.onerror = noLlamoDesdeDatosGenerales;
						
						window.close();
						return;
					}else{
						if(document.getElementById('hidMsg').value != ''){
							alert(document.getElementById('hidMsg').value);
							document.getElementById('btnGrabar').style.display = '';
							document.getElementById('hidMsg').value = '';
						}
					}
				}	
				if (document.getElementById('hidPlantillaid').value=='DOL'){					
					var control = document.getElementById('txtNumDocumento');
										
					if (control == null){
						return;
					}							
					var tipo   = document.getElementById('ddlTipoDocumento').value;
					var maxLength  = 10;
					tipo = tipo.toUpperCase();
					
					if ( tipo == 'DNI' || tipo == 'Libreta Electoral'){
						maxLength = 8;  
					}
					if ( tipo == 'RUC' ){
						maxLength = 11;  
					}					
					if ( tipo == 'Pasaporte'.toUpperCase() || tipo == 'CIP'){
						maxLength = 11;
					}				
					control.maxLength = maxLength ;
					var valor = control.value;
					if (valor != '' ){					
						if (valor.length>maxLength)
							control.value  = valor.substring(0,maxLength);
					}
				}
			}
			function noLlamoDesdeDatosGenerales(){
				return true;
			}
			function f_Contador()
			{
				var strNotas=document.getElementById('txtNotas').value
				return (strNotas.length<3800)				
			}
			function onkeypressUpperCase(){
				f_ValidaIngreso('ABCDEFGHIJKLMNÑOPQRSTVUWXYZabcdefghijklmnñopqrstvuwxyz ');
				var key = window.event.keyCode;
				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}
			function onchangeTipoDocuIdentidad(cbo,texto){
				var control = document.getElementById('txt' + texto);
				control.value = '';
				
				if (control == null){
					return;
				}				
				var tipo   = cbo.value;
				var maxLength  = 10;
				tipo = tipo.toUpperCase();
				if ( tipo == 'DNI' || tipo == 'Libreta Electoral'){
					maxLength = 8;  
				}
				if ( tipo == 'RUC' || tipo == 'R.U.C' ){
					maxLength = 11;  
				}
				
				if (tipo == 'Carnet Extranjería'.toUpperCase())
				{
					maxLength = 9;  
				}
				
				if ( tipo == 'Pasaporte'.toUpperCase() || tipo == 'CIP'){
					maxLength = 11;
				}				
				control.maxLength = maxLength ;
				var valor = control.value;
				if (valor != '' ){					
					if (valor.length>maxLength)
						control.value  = valor.substring(0,maxLength);
				}
				control.focus();
			}
			
			function onkeypressValidarTipoDocuIdentidad(txt,cbo){
				control = document.getElementById('ddl' + cbo);
				if (control == null){
					eventoSoloNumeros();
					return;
				}				
				var tipo = control.value;				
				tipo = tipo.toUpperCase();
				if (tipo == 'DNI' || tipo == 'RUC' || tipo == 'R.U.C' || tipo == 'Carnet Extranjería'.toUpperCase()){
					document.getElementById('txtNumDocumento').onkeydown = function() { validarNumero(event) };
					//EventoSoloNumeros();
					return;
				}
				else if(tipo == 'Pasaporte'.toUpperCase() || tipo == 'CIP'){
					f_ValidaIngreso('ABCDEFGHIJKLMNÑOPQRSTVUWXYZabcdefghijklmnñopqrstvuwxyz0123456789');
					return;
				}
			}
			
			function f_ValidaIngreso(CaracteresPermitidos)   {
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++) 
				{
						if (key == valid.substring(i,i+1))
							ok = "yes"        
				}
				if (ok == "no")
						window.event.keyCode=0
			}
			function InhabilitarTecla()
			{			
				event.returnValue = false;
			}
			function Adjuntar(){
				if (document.getElementById('txtNombre').value==''){
					alert('El campo Nombre es un dato obligatorio');
					document.getElementById('txtNombre').focus();					
					return false;
				}
				if (document.getElementById('txtApellidos').value==''){
					alert('El campo Apellidos es un dato obligatorio');
					document.getElementById('txtApellidos').focus();					
					return false;
				}
				
				var tipo_docu = document.getElementById('ddlTipoDocumento').value;				
				if (tipo_docu.toUpperCase() != '-1' ){
					if (document.getElementById('txtNumDocumento').value==''){
						alert('El campo Nro Documento es un dato obligatorio');
						document.getElementById('txtNumDocumento').focus();
						document.getElementById('txtNumDocumento').select();
						return false;
					} 
				}else{
					alert('El campo Tipo Documento es un dato obligatorio');
					document.getElementById('ddlTipoDocumento').focus();
					return false;
				}
			
				var nombreFile = document.getElementById('flDNI').value;		
				if( nombreFile == '')
				{
					alert('Debe ingresar un archivo para cargar.');
					document.getElementById('flDNI').focus();
					return false;
				}
				
			    document.getElementById('hidCodRegistro').value = '';
				document.getElementById('hidAccion').value='A';
				document.getElementById('btnGrabar').style.display = 'none';
				document.getElementById('btnAdjuntar').style.display = 'none';
				document.Form1.submit();
			}
			
			function noEspecificado(control){
				if( document.getElementById(control).value == '')
					document.getElementById(control).value = document.getElementById('hidNoEspecificado').value;
			}
			function Guardar(){				
				var resultado;				
				resultado = validarInteraccion();
				if (resultado == false)
					return;
				if (document.getElementById('hidPlantillaId').value == 'DOL'){
					if(ValidarControlesPlantilla()==false){
						return;
					}
					
					if(validarDocumento('NumDocumento')== false){
							return;
					}
					document.getElementById('hidAccion').value='C';
				}else{
				document.getElementById('hidAccion').value='G';
				}
								
				document.getElementById('btnGrabar').style.display = 'none';
				document.Form1.submit();
			}
			function validarDocumento(txt){
				
				var controlTexto = document.getElementById('txt' + txt);			
				var control = document.getElementById('ddlTipoDocumento').value;			
				control = control.toUpperCase();			
				
				if(esNumerico(controlTexto.value)==false && control != 'PASAPORTE')
				{
					alert('El Numero de Documento debe estar conformado por solo digitos.');
					return false;
				}			
				if(isNumOrCharCIP(controlTexto.value)==false && control == 'PASAPORTE')
				{
					alert('El Pasaporte debe estar conformado por caracteres válidos.');
					return false;				
				}					
				if(control == 'Carnet Extranjería'.toUpperCase() &&  controlTexto.value.length < 9)
				{
					alert('El Carnet de Extranjeria esta conformado por 9 dígitos.');
					controlTexto.focus();
					return false;				
				}			
				if(control == 'Carnet Extranjería'.toUpperCase() && controlTexto.value.substr(0,3) != '000')
				{
					alert('Los tres primeros digitos del Carnet de Extrangeria deben ser 000');
					return false;
				}
				
				if ((controlTexto.value.length < controlTexto.maxLength ) && (control != 'Pasaporte'.toUpperCase() && control != 'Carnet Extranjería'.toUpperCase() && control != 'CIP')  ){
					alert('Por favor, ingresar todos los dígitos del documento de identidad');
					controlTexto.focus();
					return false;	
				}			
				
				if(control == 'Pasaporte'.toUpperCase() && controlTexto.value.length<4)
				{
					alert('Por favor, ingresar el Nro Documento correctamente.');
					controlTexto.focus();
					return false;
				}

				else if(control == 'RUC'.toUpperCase() &&  controlTexto.value.length ==11){
									
					if(ValidarNumeroRUC(controlTexto.value) ==0){
						alert('Por favor, ingrese un numero de documento valido');
						document.getElementById('ddl__x_type_document').focus();					
						controlTexto.focus();
						return false;
					}				
				}						
				return true;				
			}	
			function isNumOrCharCIP(InString)  
			{
				var flag = true;
				var i,j,a;
				var cadena;
				cadena=InString;
				cadena=cadena.toUpperCase();
				if ((cadena == null) || (cadena.length == 0)&&(!vacio))
				{
					alert('Debe ingresar un valor');
					return false;
				}
		
				for(i=0;i<cadena.length;i++)
				{ 	
					a=(cadena.substr(i,1));
					
					j=a.charCodeAt(0);
					if ( !( ((j>=48) && (j<=57)) || ((j>64) && (j<=91)) ) )
						flag=false;						
				}
					
				return (flag);
			}
			function validarInteraccion(){
				var control = '';				
				var strNotas=document.getElementById('txtNotas').value
					if(strNotas.length>3800)
					{
						alert("El campo Notas solo acepta 3800 caracteres");
						document.getElementById('txtNotas').value=strNotas.substring(0,3800)
						document.getElementById('txtNotas').focus();
						return false;
					}
				var strFecha = document.getElementById('txtFechaNac').value
				if(isDate(strFecha)==false){
				document.getElementById('txtFechaNac').focus();
				}
				return true;
			}
			
			function ValidarControlesPlantilla(){ 
				if (document.getElementById('txtNombre').value==''){
					alert('El campo Nombre es un dato obligatorio');
					document.getElementById('txtNombre').focus();					
					return false;
				}
				if (document.getElementById('txtApellidos').value==''){
					alert('El campo Apellidos es un dato obligatorio');
					document.getElementById('txtApellidos').focus();					
					return false;
				}
				var tipo_docu = document.getElementById('ddlTipoDocumento').value;				
				if (tipo_docu.toUpperCase() != '-1' ){
					if (document.getElementById('txtNumDocumento').value==''){
						alert('El campo Nro Documento es un dato obligatorio');
						document.getElementById('txtNumDocumento').focus();
						document.getElementById('txtNumDocumento').select();
						return false;
					} 
				}else{
					alert('El campo Tipo Documento es un dato obligatorio');
					document.getElementById('ddlTipoDocumento').focus();
					return false;
				}
				if (esNumerico(document.getElementById('txtNroReferencia').value)==false)   {
					alert('En el campo Nro telefono referencia debe ingresar sólo numeros');
					document.getElementById('txtNroReferencia').focus();
					document.getElementById('txtNroReferencia').select();
					return false;
				}				
				
				if(document.getElementById('txtFechaNac').value!=''){
					if( validarFecha('txtFechaNac')==false){
						document.getElementById('txtFechaNac').focus();
						document.getElementById('txtFechaNac').select();
						return false;
					}
				}
											
				if (document.getElementById('ddlMotivoRegistro').value=='-1' || document.getElementById('ddlMotivoRegistro').value=='')     {
					alert('El campo Motivo de registro es un dato obligatorio');
					document.getElementById('ddlMotivoRegistro').focus();
					return false;
				}				
				
				if (esNumerico(document.getElementById('txtNroReferencia').value)==false)   {
					alert('En el campo Nro telefono referencia debe ingresar sólo numeros');
					document.getElementById('txtNroReferencia').focus();
					document.getElementById('txtNroReferencia').select();
					return false;
				}				
				return true;
			}
			function esNumerico(pString){	
				var ok = "yes";	var temp;
				var valid = "0123456789"; 
				for (var i=0; i< pString.length ; i++){
					temp = "" + pString.substring(i, i+1);
					if (valid.indexOf(temp) == "-1") ok = "no";
				}
				if (ok == "no") {return (false);} else {return (true);}
				
			}
			function validarNumero(event) {
				if (event.keyCode == 8 || event.keyCode == 46) {
					return;
				}
				if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
					return;
				}
				eventoSoloNumeros(event);
			}
			function eventoSoloNumeros(event) {
				if( (event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105) ) {
					event.returnValue = true;
				}
				else {
					event.returnValue = false;
				}
				/*var tecla = String.fromCharCode(event.keyCode)
				alert(isNumber(tecla));
				if( !isNumber(tecla) ) {
					event.returnValue = false;
				}*/
			}
			function Cerrar(){
				window.parent.f_retornar();				
			}
			function verArchivo(cod,td,nd,fn,file)
			{					
				document.getElementById('ddlTipoDocumento').value = td;
				onchangeTipoDocuIdentidad(document.getElementById('ddlTipoDocumento'),'NumDocumento');
				document.getElementById('txtNumDocumento').value = nd;
				document.getElementById('hidCodRegistro').value = cod;	
				
				var strFn= fn
				if(fn!=''){
					strFn = fn.substring(0,2)+'/'+ fn.substring(2,4)+'/'+fn.substring(4,8);
				}
				document.getElementById('txtFechaNac').value = strFn;
				w = 770;
				h = 352;
				var url = file;
				url = "sisact_ver_documento.aspx?id="+cod+"&strNomArchivo="+url;				
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" +w +",height="+ h +",left="+leftScreen +",top=" + topScreen;
				
				var ventanaDocumento;
				ventanaDocumento = window.open(url,"ImagenDNIDolMMS",opciones);				
				ventanaDocumento.focus();					
			}
		</SCRIPT>
	</HEAD>
	<body onload="inicio();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellPadding="0" width="784" border="0" style="WIDTH: 784px; HEIGHT: 100%">
				<TBODY>
					<tr>
						<td class="header" style="HEIGHT: 20px" align="center" height="20">Creación de 
							Casos / Interacción</td>
					</tr>
					<tr>
						<td>
							<table class="contenido" style="WIDTH: 776px; HEIGHT: 600px" cellSpacing="1" cellPadding="0"
								width="776" border="0">
								<TBODY>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 3px">Nro Teléfono</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 3px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 3px"><asp:textbox id="txtNroTelefono" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="112px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 3px">Contacto</TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 3px">:</TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 3px"><asp:textbox id="txtContacto" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="180px"></asp:textbox></TD>
										<TD class="Arial10B" style="HEIGHT: 3px"></TD>
									</TR>
									<tr>
										<td class="Arial10B" style="WIDTH: 591px; HEIGHT: 9px">&nbsp;Caso/Inter</td>
										<td class="Arial10B" style="WIDTH: 20px; HEIGHT: 9px">:</td>
										<td class="Arial10B" style="WIDTH: 278px; HEIGHT: 9px">INTERACCIÓN</td>
										<td class="Arial10B" style="WIDTH: 145px; HEIGHT: 9px"></td>
										<td class="Arial10B" style="WIDTH: 13px; HEIGHT: 9px"></td>
										<td class="Arial10B" style="WIDTH: 212px; HEIGHT: 9px"></td>
										<TD class="Arial10B" style="HEIGHT: 9px"></TD>
									</tr>
									<tr>
										<td class="Arial10B" style="WIDTH: 591px; HEIGHT: 14px">Tipo
										</td>
										<td class="Arial10B" style="WIDTH: 20px; HEIGHT: 14px">:</td>
										<td class="Arial10B" style="WIDTH: 375px; HEIGHT: 14px" colSpan="2"><asp:textbox id="txtTipo" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="304px"></asp:textbox></td>
										<td class="Arial10B" style="WIDTH: 13px; HEIGHT: 14px"></td>
										<td class="Arial10B" style="WIDTH: 212px; HEIGHT: 14px"></td>
										<TD class="Arial10B" style="HEIGHT: 14px"></TD>
									</tr>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 7px">Clase</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 7px">:</TD>
										<TD class="Arial10B" style="WIDTH: 375px; HEIGHT: 7px" colSpan="2"><asp:textbox id="txtClase" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="304px"></asp:textbox></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 7px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 7px"></TD>
										<TD class="Arial10B" style="HEIGHT: 7px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 3px">Sub Clase</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 3px">:</TD>
										<TD class="Arial10B" style="WIDTH: 375px; HEIGHT: 3px" colSpan="2"><asp:textbox id="txtSubclase" runat="server" cssclass="clsInputDisable" ReadOnly="True" Width="304px"></asp:textbox></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 3px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 3px"></TD>
										<TD class="Arial10B" style="HEIGHT: 3px"></TD>
									</TR>
									<tr>
										<td class="Arial10B" style="WIDTH: 591px; HEIGHT: 50px">Notas</td>
										<td class="Arial10B" style="WIDTH: 20px; HEIGHT: 50px">:</td>
										<td class="Arial10B" style="WIDTH: 542px; HEIGHT: 50px" colSpan="4"><asp:textbox onkeypress="javascript:return f_Contador()" onpaste="javascript:return f_Contador()"
												id="txtNotas" runat="server" cssclass="clsInputDisable" Width="505px" Height="50px" TextMode="MultiLine" MaxLength="3800"></asp:textbox></td>
										<TD class="Arial10B" style="HEIGHT: 39px"></TD>
									</tr>
									<TR>
										<TD class="Arial10B" style="WIDTH: 647px; HEIGHT: 1px" colSpan="6">
											<P><asp:label id="lblEspere" runat="server" Font-Bold="True" ForeColor="Red" Visible="False">Por favor espere mientras se verifica si el teléfono tiene registro DOL...</asp:label></P>
										</TD>
										<TD class="Arial10B" style="HEIGHT: 1px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 647px; HEIGHT: 10px" colSpan="6"></TD>
										<TD class="Arial10B" style="HEIGHT: 10px"></TD>
									</TR>
									<TR>
										<td class="header" style="WIDTH: 647px; HEIGHT: 9px" align="center" colSpan="6" height="9">Plantilla 
											Asociada a DOL</td>
										<TD class="header" style="HEIGHT: 9px" align="center" height="9"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 647px; HEIGHT: 2px" colSpan="6"></TD>
										<TD class="Arial10B" style="HEIGHT: 2px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Nombre</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px"><asp:textbox id="txtNombre" onkeypress="onkeypressUpperCase()" runat="server" cssclass="clsInputEnableObligatory"
												Width="180px"></asp:textbox></TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px">Apellidos</TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"><asp:textbox id="txtApellidos" onkeypress="onkeypressUpperCase()" runat="server" cssclass="clsInputEnableObligatory"
												Width="180px"></asp:textbox></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Tipo Documento</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px"><asp:dropdownlist id="ddlTipoDocumento" runat="server" onchange="onchangeTipoDocuIdentidad(this,'NumDocumento')"
												CssClass="clsSelectEnableObligatory" width="181px"></asp:dropdownlist></TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px">Nro Documento</TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px">
										<asp:textbox id="txtNumDocumento" onkeydown="javascript:validarNumero(event);" onkeypress="return onkeypressValidarTipoDocuIdentidad(this,'TipoDocumento')" runat="server" Width="180px" CssClass="clsInputEnableObligatory"></asp:textbox>
								</TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Nombre del Archivo</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 375px; HEIGHT: 16px" colSpan="2"><INPUT class="Boton" onkeypress="javascript:InhabilitarTecla();" id="flDNI" title="Seleccionar Archivo"
												style="WIDTH: 335px; HEIGHT: 16px; TEXT-ALIGN: left" type="file" size="36" name="flDNI" runat="server"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 229px; HEIGHT: 16px" colSpan="2">
											<INPUT type="button" class="Boton" id="btnAdjuntar" value="Adjuntar Documento de Identidad"
												onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
												style="WIDTH: 217px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:Adjuntar();" NAME="btnAdjuntar">
										</TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 5px"></TD>
										<TD class="Arial10B" style="HEIGHT: 5px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 611px; HEIGHT: 100px" colSpan="7">
											<fieldset style="WIDTH: 769px; HEIGHT: 100px"><legend>Registro de Documento de 
													Identidad</legend>
												<div id="divDolMMS">
													<table width="764" style="WIDTH: 764px; HEIGHT: 100px">
														<TBODY>
															<tr>
																<td>
																	<div style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 752px; HEIGHT: 128px"><asp:datagrid id="dgListado" runat="server" CellSpacing="1" CellPadding="1" BorderColor="#95B7F3"
																			AutoGenerateColumns="False" AllowPaging="True" PageSize="5" Width="712px">
																			<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
																			<HeaderStyle HorizontalAlign="Center" CssClass="TablaTitulos"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="Código">
																	<HeaderStyle HorizontalAlign="Center" Wrap="false" CssClass="TablaTitulos"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" CssClass="Arial11BV"></ItemStyle>
																	<ItemTemplate>
																		<a id="<%# DataBinder.Eval(Container.DataItem, "CodRegistro")%>" name="<%# DataBinder.Eval(Container.DataItem, "CodRegistro")%>" 
href="javascript:verArchivo('<%# DataBinder.Eval(Container.DataItem, "CodRegistro")%>','<%# DataBinder.Eval(Container.DataItem, "TipoDocumento")%>','<%# DataBinder.Eval(Container.DataItem, "NumDocumento")%>','<%# DataBinder.Eval(Container.DataItem, "FecNac")%>','<%# DataBinder.Eval(Container.DataItem, "urlArchivo")%>');"><%# DataBinder.Eval(Container.DataItem, "CodRegistro")%></a>
																		<input type="hidden" id="hid<%# DataBinder.Eval(Container.DataItem, "CodRegistro")%>" name="hid<%# DataBinder.Eval(Container.DataItem, "CodRegistro")%>" value="<%# DataBinder.Eval(Container.DataItem, "urlArchivo")%>" />
																	</ItemTemplate>
																</asp:TemplateColumn>
																				<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo Documento"></asp:BoundColumn>
																				<asp:BoundColumn DataField="NumDocumento" HeaderText="Num. Documento"></asp:BoundColumn>
																				<asp:BoundColumn DataField="CodOficina" HeaderText="Oficina"></asp:BoundColumn>
																				<asp:BoundColumn DataField="CodUsuario" HeaderText="Usuario"></asp:BoundColumn>
																				<asp:BoundColumn DataField="FecRegistro" HeaderText="Fec. Registro"></asp:BoundColumn>
																				<asp:BoundColumn DataField="CodSistema" HeaderText="Sistema"></asp:BoundColumn>
																				<asp:BoundColumn DataField="FecNac" HeaderText="Fec. Nacimiento"></asp:BoundColumn>
																				<asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
																			</Columns>
																			<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></div>
																</td>
															</tr>
														</TBODY>
													</table>
												</div>
											</fieldset>
										</TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 611px; HEIGHT: 15px" colSpan="7"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Nro Teléfono Referencia</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px"><asp:textbox id="txtNroReferencia" onkeydown="javascript:validarNumero(event);" runat="server" Width="112px"
												cssclass="clsInputEnable"></asp:textbox>
												
												</TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Fecha de Nacimiento</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px">
											<TABLE id="tblFechaIni" cellSpacing="0" cellPadding="0" border="0">
												<TBODY>
													<TR>
														<TD><asp:textbox id="txtFechaNac" onkeypress="return f_ValidaIngreso('0123456789/')" runat="server" Width="80px"
																CssClass="clsInputEnable" MaxLength="10"></asp:textbox></TD>
														<TD><img id="btnFechaNac" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; CURSOR: pointer; BORDER-BOTTOM: 0px"
																src="../../images/calendario.gif" border="0">
															<script type="text/javascript">
																Calendar.setup(
																	{
																		inputField     :    "txtFechaNac",      // id of the input field
																		ifFormat       :    "%d/%m/%Y",       // format of the input field                                                        
																		button         :    "btnFechaNac",   // trigger for the calendar (button ID)
																		singleClick    :    true,           // double-click mode
																		step           :    1                // show all years in drop-down boxes (instead of every other year as default)
																	}
																);
															</script>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Lugar de Nacimiento</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px"><asp:DropDownList id="ddlLugarNac" runat="server" width="181px" CssClass="clsSelectEnable" onchange=""></asp:DropDownList></TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Motivo de registro</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px"><asp:DropDownList id="ddlMotivoRegistro" runat="server" width="181px" CssClass="clsSelectEnable" onchange=""></asp:DropDownList></TD>
										<TD class="Arial10B" style="WIDTH: 145px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 13px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Dirección Completa</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px" colSpan="3"><asp:textbox id="txtDireccion" runat="server" Width="342px" cssclass="clsInputEnable"></asp:textbox></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 591px; HEIGHT: 16px">Ciudad</TD>
										<TD class="Arial10B" style="WIDTH: 20px; HEIGHT: 16px">:</TD>
										<TD class="Arial10B" style="WIDTH: 278px; HEIGHT: 16px" colSpan="3"><asp:textbox id="txtCiudad" runat="server" Width="342px" cssclass="clsInputEnable"></asp:textbox></TD>
										<TD class="Arial10B" style="WIDTH: 212px; HEIGHT: 16px"></TD>
										<TD class="Arial10B" style="HEIGHT: 16px"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 611px; HEIGHT: 16px" colSpan="7"><asp:label id="lblMensaje" runat="server" Visible="False" ForeColor="Red" Font-Bold="True"></asp:label></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 611px; HEIGHT: 16px" align="center" colSpan="7"><INPUT class="Boton" id="btnGrabar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 96px; CURSOR: hand; HEIGHT: 19px"
												onclick="Guardar();" onmouseout="this.className='Boton';" type="button" value="Guardar" name="btnGrabar">&nbsp;&nbsp;&nbsp;&nbsp;
											<INPUT class="Boton" id="btnCerrar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 88px; CURSOR: hand; HEIGHT: 19px"
												onclick="javascript:Cerrar();" onmouseout="this.className='Boton';" type="button" value="Cerrar"
												name="btnCerrar"></TD>
									</TR>
									<TR>
										<TD class="Arial10B" style="WIDTH: 611px; HEIGHT: 19px" align="center" colSpan="7"><INPUT id="hidAccion" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidAccion"
												runat="server"><INPUT id="hidUsuarioExt" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="hidUsuarioExt" runat="server"><INPUT id="hidCargarDatosLinea" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
												name="hidCargarDatosLinea" runat="server"><INPUT id="hidContactoId" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidContactoId"
												runat="server"><INPUT id="hidPlantillaId" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidPlantillaId"
												runat="server"><INPUT id="hidFlagValidarDOL" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
												name="hidFlagValidarDOL" runat="server"><INPUT id="hidFocus" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidFocus"
												runat="server"><INPUT id="hidMsg" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidMsg"
												runat="server"><INPUT id="hidEjecutarTransaccion" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
												name="hidEjecutarTransaccion" runat="server"><INPUT id="hidIMSI" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidIMSI"
												runat="server"><INPUT id="hidIN" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidIN"
												runat="server"><INPUT id="hidTelefono" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidTelefono"
												runat="server"><INPUT id="hidCodRegistro" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidCodRegistro"
												runat="server"><INPUT id="hidNoEspecificado" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
												name="hidNoEspecificado" runat="server"> <INPUT id="hidEligeMedodoDOL" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
												name="hidEligeMedodoDOL" runat="server"><INPUT id="hidClaseDes" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidClaseDes"
												runat="server"><INPUT id="hidClaseId" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidClaseId"
												runat="server"><INPUT id="hidSubClaseId" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidSubClaseId"
												runat="server"><INPUT id="hidSubClaseDes" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidSubClaseDes"
												runat="server"></TD>
									</TR> <!--INICIO - E75688--> <!--FIN - E75688--></TBODY></table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
