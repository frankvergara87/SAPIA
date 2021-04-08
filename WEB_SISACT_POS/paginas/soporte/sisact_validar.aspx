<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_validar.aspx.vb" Inherits="sisact_validar" AspCompat="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SISACT Autenticación</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/general.css">
		<base target="_self">
		<script language="JavaScript" type="text/JavaScript">
			window.onbeforeunload = UnLoadPage;
			function UnLoadPage(){
				
			}

		
			function fin()
			{
					var sData = dialogArguments;
				if(document.Form1.hidflgCerrarSoles.value == '-1')
				{
					if (document.Form1.HidVerificar.value == '' || document.Form1.HidVerificar.value == 'P' )
					{ 
                		document.getElementById('HidVerificar').value='';
                		sData.FC_CancelarVentana();
                		window.close();
					}
                }
			}
			
			function FC_Cerrar()
			{
			
				var sData = dialogArguments;
       			sData.FC_CancelarVentana();
				window.close();
			}
			
			function FC_Enter(event)
			{
				var nav4 = window.Event ? true : false;
				var key = nav4 ? event.which : event.keyCode; 
				if(key == 13) FC_Validar();
			}
			
			function FC_Validar()
			{
				var temp = parseFloat(document.getElementById('hidVeces').value);
				document.getElementById('hidAccion').value='V';
				document.getElementById('HidVerificar').value='1';                                                    
              			document.getElementById('btnValidar').disabled = true;
				document.getElementById('btnCancelar').disabled = true;
				temp = temp + 1;
				document.getElementById('hidVeces').value = temp;				
				document.Form1.submit();
			}
			
			function inicio()
			{	
				if (document.Form1.hidAccion.value == 'G' ){ //CUMPLE VALIDACION. cierra y refresca la ventana de gatos generales
					
					var sData = dialogArguments;
					var sUser = document.getElementById("hidUserValidator").value;
       				sData.FC_GrabarCommit(sUser);
					window.close();
				}	
				
				if (document.Form1.hidAccion.value == 'E' ){ // ERRROR. cierra y refresca la ventana de gatos generales
					var sData = dialogArguments;
       				sData.FC_Fallo();
					window.close();
				}
				
				if (document.Form1.hidAccion.value == 'E_MONTO_INACEPTABLE' ){ // ERRROR. cierra y retorna error
									
					var sData = dialogArguments;
					window.close();
       				sData.FC_Fallo_Monto_No_Permitido();
					
				}
				
				if (document.Form1.hidAccion.value == 'E_MESES_INACEPTABLE' ){ // ERRROR. cierra y retorna error
									
					var sData = dialogArguments;
					window.close();
       				sData.FC_Fallo_Meses_No_Permitido();
					
				}
				
				
				
				if (document.Form1.hidAccion.value == 'F' ){ // ERRROR. cierra y refresca la ventana de gatos generales
				
					document.getElementById('HidVerificar').value='P';
                    			var descripcion=document.getElementById("hidDescripcionProceso").value;
					var mensaje='La validación del usuario ingresado es incorrecto o no tiene permisos para continuar con el proceso, por favor verifiquelo.'
						
					if (descripcion!=''){
						mensaje='La validación del usuario ingresado es incorrecto o no tiene permisos para ' + descripcion + ', por favor verifiquelo.'
					}
					
					alert(mensaje);
					
					document.getElementById("txtUsuario").value = "";
					document.getElementById("txtPass").value = "";
					document.getElementById('btnValidar').disabled = false;
					document.getElementById('btnCancelar').disabled = false;
					
				}
			}
		</script>
		<base target="_self" />
	</HEAD>
	<body onload="inicio();" onunload="fin();">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidAccion" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidAccion"
				runat="server"> <INPUT id="hidPagina" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidPagina"
				runat="server"> <INPUT id="hidMonto" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidMonto"
				runat="server"> <INPUT id="hidUnidad" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidUnidad"
				runat="server"><INPUT id="hidTipoValidacion" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
				name="hidTipoValidacion" runat="server"><INPUT id="hidPerfiles" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidPerfiles"
				runat="server"><INPUT id="hidtipoMensaje" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidtipoMensaje"
				runat="server"> <INPUT id="hidOpcion" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidOpcion"
				runat="server"> <INPUT id="hidDescripcionProceso" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
				name="hidDescripcionProceso" runat="server"> <INPUT id="hidConcepto" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidConcepto"
				runat="server"><INPUT id="hidModalidad" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidModalidad"
				runat="server"><INPUT id="hidperfil" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidperfil"
				runat="server"><INPUT id="hidUserValidator" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidUserValidator"
				runat="server"><input id="hidAccionDetEnt" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidAccionDetEnt"
				runat="server"><INPUT id="HidVerificar" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="HidVerificar"
				runat="server"><INPUT id="hidflgCerrarSoles" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
				name="hidflgCerrarSoles" runat="server">
			<TABLE class="Arial11BV" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 376px; HEIGHT: 169px; TOP: 2px; LEFT: 2px"
				borderColor="#336699" cellSpacing="0" cellPadding="0" width="376" border="2" id="tblContenedor">
				<TR>
					<td>
						<TABLE class="Arial11BV" borderColor="#336699" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TBODY>
								<tr>
									<TD vAlign="top" align="center" bgColor="#5991bb" colSpan="3"><ASP:LABEL id="lblTitulo" runat="server" font-size="12pt" font-bold="True" forecolor="White">AUTORIZACIÓN</ASP:LABEL></TD>
								</tr>
								<tr>
									<TD vAlign="top" align="center" bgColor="#ffffff" colSpan="3"><ASP:LABEL id="lblMensaje" runat="server" font-size="10pt" font-bold="True" forecolor="Black"></ASP:LABEL></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 10px" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100px; HEIGHT: 20px" align="right">Usuario</TD>
									<TD style="PADDING-LEFT: 3px; WIDTH: 10px" align="left">:</TD>
									<TD><asp:textbox id="txtUsuario" runat="server" CssClass="clsTxtFlat"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100px; HEIGHT: 20px" align="right">Contraseña</TD>
									<TD style="PADDING-LEFT: 3px; WIDTH: 10px" align="left">:</TD>
									<TD><asp:textbox id="txtPass" runat="server" CssClass="clsTxtFlat" TextMode="Password"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 10px" colSpan="3"></TD>
								</TR>
								<TR>
									<td colSpan="3">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<TD align="right"><INPUT class="Boton" id="btnValidar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
														onclick="FC_Validar()" onmouseout="this.className='Boton';" type="button" value="Aceptar" name="btnValidar"
														runat="server"></TD>
												<TD style="WIDTH: 10px"></TD>
												<TD align="left"><INPUT class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; HEIGHT: 19px; CURSOR: hand"
														onclick="FC_Cerrar()" onmouseout="this.className='Boton';" type="button" value="Cancelar" name="btnCancelar"
														runat="server"></TD>
											</tr>
										</table>
									</td>
								</TR>
								<TR>
									<TD style="HEIGHT: 10px" colSpan="3"></TD>
								</TR>
				</TR>
			</TABLE>
			<INPUT id="hidMensaje" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidMensaje"
				runat="server"><INPUT id="hidLogin" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidLogin"
				runat="server"><INPUT id="hidCO" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidCO"
				runat="server"><INPUT id="hidVeces" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1" name="hidVeces"
				runat="server" value="0"> <INPUT id="hidPerfilesAValidar" style="WIDTH: 10px; HEIGHT: 18px" type="hidden" size="1"
				name="hidPerfilesAValidar" runat="server" value="0"> </TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
 
 
 
 
