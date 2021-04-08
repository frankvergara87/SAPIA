<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_cargar_archivo_solicitud_consumer.aspx.vb" Inherits="sisact_cargar_archivo_solicitud_consumer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SISACT CARGA ARCHIVO SOLICITUD</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript">
				
			function soloMontosIngreso(event, obj){
				var code = (event.which) ? event.which : event.keyCode;
				var character = String.fromCharCode(code);
				var decimales = 0;
				var cantidad_decimales = 2;
				var salida = false;	
				if ((code >= 48 && code <= 57)){ // check digits
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
				}else if (code == 46){ // Check dot
					if (obj.value.indexOf(".") < 0){						
						if (obj.value.length == 0) obj.value = "0";				
						return true;
					}
				}else if (code == 8){ // Allow backspace, F5
					return true;
				}else if (code >=37 && code <= 40){ // Allow directional arrows
					return true;
				}else if (code ==9 || code == 16){ // tab control + tab
					return true;
				}
				return false;
			}

			function trim(cadena)
			{
				for(i=0; i<cadena.length; i++)
				{
					if(cadena.charAt(i)==" ")
						cadena=cadena.substring(i+1, cadena.length);
					else
						break;
				}
				for(i=cadena.length-1; i>=0; i=cadena.length-1)
				{
					if(cadena.charAt(i)==" ")
						cadena=cadena.substring(0,i);
					else
						break;
				}
				return cadena;
			}
			
			function ValidaDecimalB(control,campo,vacio)
			{
				var flag=true;
				var i,j,a,cadena;
				eval("cadena = " + control + ".value");
				cadena=trim(cadena);
				if ((cadena == null) || (cadena.length == 0)&&(!vacio)){
					eval("" + control + ".select()");
					alert('Debe ingresar ' + campo );
					return false;
				}
					
				for(i=0;i<cadena.length;i++)
				{ 	
					a=(cadena.substr(i,1));
					if (a==' ') {
						flag=false;
					}
					j=a.charCodeAt(0);
					if (!( ((j>=48) && (j<=57)) || (j==45) || (j==46)))
						flag=false;
				}
				
				if (! flag)
				{
					alert(campo + " contiene caracteres no válidos");
					eval(control + ".select()")
				}
				return flag;
			}
			
			function iframeAgregarMontoIngreso()
			{
				document.getElementById('divFrameRecibo').style.display='none';
				document.getElementById('divFrameIngreso').style.display='block';
			}		
			function iframeAgregarRecibo()
			{		   
				document.getElementById('divFrameRecibo').style.display='block';
				document.getElementById('divFrameIngreso').style.display='none';
				ifrRecibo.agregarRecibo(1);
			}		
			function f_Limpiar()
			{
				self.parent.location = "sisact_cargar_archivo_consumer.aspx?numSolicitud=";
			}
			
			function mostrarBotones(flag)
			{
				setVisible('trBotones',flag);
			}
			function grabar(){
				var nroSEC = document.form1.hidNroSec.value;
				var monto = document.form1.txtMontoIngreso.value;
				var hid = ifrArchivos.document.getElementById('hidLista');
				var lista;
				
				if (hid==null){
					alert("La solicitud Nº " + nroSEC + " Rechazada por no adjuntar Sustento de ingreso");
					setValue('hidProceso','grabarRechazo');  
					//self.parent.location="../evaluacion_cons/sisact_cargar_archivo_consumer.aspx?numSolicitud=";
					document.form1.submit();
					cerrarVentana();
					return false;                                       
				}
				else{
					lista = hid.value
					if (lista == ""){
					    alert("La solicitud Nº " + nroSEC + " Rechazada por no adjuntar Sustento de ingreso");
						setValue('hidProceso','grabarRechazo');   
						document.form1.submit();  
						cerrarVentana();
						return false; 
					}
				}
				setValue('hidListaArchivos',lista);				
				//if (monto!=""){
				if (confirm('Se grabaran los datos ingresados. ¿Desea continuar?')==false){
					return false;
				}
				setValue('hidProceso','grabar');
				setValue('hidAnexar','');				
				document.form1.submit();	
				alert('Se Registraron los Datos Satisfactoriamente');								
				cerrarVentana();
				//}
				/*else{
				 alert("Por favor, ingrese un monto sustento para la Solicitud Nº " + nroSEC );
				}*/
			}
			function cargarLista(lista){
				setValue('hidListaArchivos',lista);				
			}
			function retornarLista(){
				return getValue('hidListaArchivos');
			}
			function agregar(){
				var hid = ifrArchivos.document.getElementById('hidLista');
				var lista;
				if(hid==null){
					lista = "";
				}else{
					lista = hid.value;
				}
				
				var url = "sisact_upload_consumer.aspx?listaArchivos=" + lista;
				var estilo = "";
				var estilo = "titlebar=NO,toolbar=0,location=0,directories=0,status=0,menubar=NO,scrollbars=yes,resizable=No,copyhistory=0,width=390,height=90,top=250,left=250";
				window.open(url,"",estilo);
			}
			function inicio(){
				var accion = document.form1.hidProceso.value;
				var msg  = document.form1.hidMsg.value;
				if (accion == "LIMPIAR")
				{
					if (msg != '') alert(msg);
					
					f_Limpiar();
					return;
				}                                              
				if (msg != '') alert(msg);
				
				document.getElementById('trPanelMonto').style.display='none';
				document.getElementById('txtMontoIngreso').value='0';
			}                       
			function retornoRecibo(listaRecibo,nroFilas)
			{
				if(listaRecibo != '' && nroFilas != '')
				{
					setValue('hidListaRecibo',listaRecibo);
					setValue('hidNroFilas',nroFilas);
				}
			}
			function cerrarVentana()
			{				
				window.close();					
				parent.cerrarVentana();
			}
			
			function eventoSoloNumerosEnteros(){
				var CaracteresPermitidos = '0123456789.';
				var key = String.fromCharCode(window.event.keyCode);
				var valid = new String(CaracteresPermitidos);
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
		</script>
	</HEAD>
	<body onload="inicio()">
		<form id="form1" method="post" target="_top" runat="server">
			<table id="tblEvaluacion" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:label id="Label2" runat="server" CssClass="Arial12B">Código de Solicitud : </asp:label><asp:label id="lblCodSol" runat="server" CssClass="clsSoloLectura"></asp:label></td>
					<td><asp:label id="Label1" runat="server" CssClass="Arial12B">Tipo de Documento : </asp:label><asp:label id="lblTipoDoc" runat="server" CssClass="clsSoloLectura"></asp:label></td>
					<td><asp:label id="Label3" runat="server" CssClass="Arial12B">Número de Documento : </asp:label><asp:label id="lblNroDoc" runat="server" CssClass="clsSoloLectura"></asp:label></td>
					<td><asp:label id="Label4" runat="server" CssClass="Arial12B"> Nombres y Apellidos : </asp:label><asp:label id="lblRazon" runat="server" CssClass="clsSoloLectura"></asp:label></td>
				</tr>
				<tr>
					<td colSpan="4">
						<table class="contenido" id="tblAnexar" cellSpacing="2" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="header" align="center" height="20">&nbsp;Documentos Adjuntos</td>
							</tr>
							<tr>
								<td><IFRAME id="ifrArchivos" style="WIDTH: 100%; HEIGHT: 130px" name="ifrArchivos" frameBorder="no">
									</IFRAME>
								</td>
							</tr>
							<tr>
								<td align="center"><INPUT class="Boton" id="btnAgregar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
										onclick="javascript:agregar();" onmouseout="this.className='Boton';" type="button" value="Agregar"
										name="btnAgregar">
								</td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr id="trPanelMonto">
								<td>
									<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="header" vAlign="middle">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="WIDTH: 65px" width="65"><asp:label id="Label7" runat="server" CssClass="Arial10b" Width="104px">Registro de Monto</asp:label></TD>
														<TD align="left" style="DISPLAY: none; WIDTH: 120px"><INPUT class="BotonOptm" id="btnAgregarRecibo" style="WIDTH: 170px; CURSOR: hand; HEIGHT: 19px"
																onclick="iframeAgregarRecibo()" type="button" value="Agregar Recibo" name="btnAgregarRecibo">
														</TD>
														<TD align="left" style="DISPLAY: none; WIDTH: 259px"><INPUT class="BotonOptm" id="btnAgregarMontoIngreso" style="WIDTH: 170px; CURSOR: hand; HEIGHT: 19px"
																onclick="iframeAgregarMontoIngreso()" type="button" value="Agregar Monto Ingreso" name="btnAgregarMontoIngreso">
														</TD>
														<TD align="left" style="WIDTH: 100px">
														</TD>
														<TD align="left" style="WIDTH: 100px">
														</TD>
														<TD align="left" style="WIDTH: 100px">
														</TD>
														<TD align="left" style="WIDTH: 100px">
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="contenido" colSpan="2">
												<div id="divFrameRecibo" align="left" style="DISPLAY:none">
													<IFRAME id="ifrRecibo" style="WIDTH: 100%" name="ifrRecibo" src="sisact_recibo_consumer.aspx"
														frameBorder="no" scrolling="yes"></IFRAME>
												</div>
											</TD>
										</TR>
										<TR>
											<TD class="contenido" colSpan="2">
												<div id="divFrameIngreso" align="left" style="WIDTH: 100%">
													<TABLE id="tblDetalle" style="WIDTH: 100%" runat="server">
														<tr>
															<td>
																<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
																	<TR>
																		<TD></TD>
																		<TD></TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 181px"><asp:label id="Label5" runat="server" CssClass="Arial10b"> Monto de Sustento de Ingreso: </asp:label></TD>
																		<TD><asp:textbox id="txtMontoIngreso" runat="server" Width="135px" CssClass="clsInputEnable" onkeypress="eventoSoloNumerosEnteros(); return soloMontosIngreso(event, this);"
																				MaxLength="10"></asp:textbox></TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 181px"></TD>
																		<TD>
																			<TABLE id="Table3" cellSpacing="0" cellPadding="0" border="0">
																				<TR>
																					<TD></TD>
																					<td>
																					</td>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																</TABLE>
															</td>
														</tr>
														<TR>
															<TD align="center">
															</TD>
														</TR>
													</TABLE>
												</div>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><IMG height="3" alt="" src="../../../images/spacer.gif" width="2" border="0"></td>
				</tr>
				<tr id="trBotones">
					<td align="center" colSpan="4"><INPUT class="Boton" id="btnGrabar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
							onclick="javascript:grabar();" onmouseout="this.className='Boton';" type="button" value="Grabar" name="btnGrabar">
						<input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px"
							onclick="javascript:grabar();" onmouseout="this.className='Boton';" type="button"
							value="Cancelar" name="btnCancelar"><input id="hidProceso" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidProceso"
							runat="server"> <input id="hidListaArchivos" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidListaArchivos"
							runat="server"><input id="hidMsg" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidMsg"
							runat="server"> <input id="hidAnexar" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidAnexar"
							runat="server"> <input id="hidVisible" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidVisible"
							runat="server"><input id="hidListaRecibo" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidListaRecibo"
							runat="server"><input id="hidNroFilas" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNroFilas"
							runat="server"><input id="hidNroSec" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hidNroSec"
							runat="server">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
 
 
 
 
