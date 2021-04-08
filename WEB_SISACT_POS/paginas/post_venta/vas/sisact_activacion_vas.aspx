<%@ Page Language="vb" validateRequest="false" AutoEventWireup="false" Codebehind="sisact_activacion_vas.aspx.vb" Inherits="sisact_activacion_vas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_activacion_vas</title>
		<meta charset="utf-8">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../librerias/lib_funcvalidacion.js"></script>
		<script language="javascript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" type="text/javascript">
				
		function cargaPaquete()
		{
			var valPaquete = document.frmPrincipal.ddlPaquete.value;
			var arrayDataPaquete = getValue('hidArrayDataPaquete'); //Los valores de todos los paquetes
			
			if (valPaquete != "0"){
				if (arrayDataPaquete != ""){
					var _reg = arrayDataPaquete.split('|');
					for (i=0; i<=_reg.length-1;i++)
					{
						var _val = _reg[i].split('=');
						
						if(_val[0] == valPaquete){						
							document.getElementById("dvmsgpaquete").style.display = '';
							//document.getElementById("dvmsgpaquete").innerHTML = _val[1];
							//setValue('lblTextoPaqueteDesc', _val[1]);							
							document.getElementById("lblTextoPaqueteDesc").innerText = _val[1]; 
							document.getElementById("hidTextoPaqueteDesc").value = document.getElementById("lblTextoPaqueteDesc").innerHTML;
							document.getElementById('HidCostoPaquete').value = _val[2];
							document.getElementById('HidFrecuenciaPaquete').value =  _val[3];
							
							if (getValue('hidOpcionServicioVAS') == '<%= ConfigurationSettings.AppSettings("consOpcionClaroProteccion") %>'){							
								//document.getElementById("dvmsgCaution").innerHTML = '<%= ConfigurationSettings.AppSettings("consEtiqueteClaroProteccion") %>';
								document.getElementById("lblTextoCaution").innerText = '<%= ConfigurationSettings.AppSettings("consEtiqueteClaroProteccion") %>'; 
							}else {							
								//document.getElementById("dvmsgCaution").innerHTML = '<%= ConfigurationSettings.AppSettings("consEtiqueteClaroIdeasMusik") %>';
								document.getElementById("lblTextoCaution").innerText = '<%= ConfigurationSettings.AppSettings("consEtiqueteClaroIdeasMusik") %>'; 
							}
							document.getElementById('hidTextoCaution').value= document.getElementById("lblTextoCaution").innerText;
						}
					}
				}			
			}else{
				//document.getElementById("dvmsgCaution").innerHTML = "";
				document.getElementById("lblTextoCaution").innerText = "";
				document.getElementById("dvmsgpaquete").style.display = 'none';
			}
		}
				
		function cambiarTipoDocumento()
			{
				setValue('txtNroDocumento', '');
				document.getElementById('txtNroDocumento').maxLength = getMaxLengthDocumento(document.frmPrincipal.ddlTipoDocumento.value);
				setFocus('txtNroDocumento');
			}
		
		function getMaxLengthDocumento(tipoDoc)
			{
				var nroCaracter;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>')
					nroCaracter = 8;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") %>')
					nroCaracter = 9;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
					nroCaracter = 11;
			    if (tipoDoc == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC10") %>')
					nroCaracter = 11;
				return nroCaracter;
			}
	
		function inicio()
		{
			document.getElementById("dvmsgpaquete").style.display = 'none';
			cambiarTipoDocumento();
			setValue('txtNroCelular', '');
			setFocus('txtNroCelular');
		}
			
			
		function validarClaro()
		{				
			//Validar numero de celular
			if (Trim(getValue('txtNroCelular')) == '') {
				alert("Ingrese Número de Celular");
				setFocus('txtNroCelular');
				return false;
			}else {
				if (!isNumber(getValue('txtNroCelular')) ) {
					alert('Error. Número de Celular invalido.');
					setFocus('txtNroCelular');
					return false;
				}					
				if (getValue('txtNroCelular').length != 9) {
					alert("Número de Celular inválido.");
					setFocus('txtNroCelular');
					return false;
				}
				
				if (!ValidaTelefono('document.frmPrincipal.txtNroCelular','Numero de Celular',true)){
					return false;					
				}					
			}
			
			//Validar Tipo de documento
			if (getValue('ddlTipoDocumento') == "00" || getValue('ddlTipoDocumento') == '') {
				alert("Seleccione Tipo de Documento.");
				setFocus('ddlTipoDocumento');
				return false;
			} else {
				if (!isNumber(getValue('txtNroDocumento')) ) {
					alert('Error. Número de documento no válido.');
					setFocus('txtNroDocumento');
					return false;
				}					
				if (getValue('txtNroDocumento').length != getMaxLengthDocumento(getValue('ddlTipoDocumento'))) {
					setFocus('txtNroDocumento');
					alert("Ingresar número de documento válido.");
					return false;
				}
			}				

			//Se valida el valor del tipo del documento
			if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>')
			{
				if (!ValidaDNI('document.frmPrincipal.txtNroDocumento','El campo Nro Documento',false)) return false;
				
			}

			if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
			{
				if (!ValidaRUC('document.frmPrincipal.txtNroDocumento','El campo Nro Documento',false)) return false;
				
			}
			
			if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoCE") %>')
			{
				if (!ValidaEXTR('document.frmPrincipal.txtNroDocumento','El campo Nro Documento',false)) return false;
				
			}
			
			//Se valida el email
			//if(document.getElementById("trEmail").style.display == '') {
			if (getValue('hidOpcionServicioVAS') == '<%= ConfigurationSettings.AppSettings("consOpcionClaroProteccion") %>'){	
				if (Trim(getValue('txtemail')) == '') {
					alert("Ingrese su Email.");
					setFocus('txtemail');
					return false;
				}					
				if (!checkEmail('document.frmPrincipal.txtemail','El campo Email',true))return false;
			}				
			
			//Se valida el paquete
			if (getValue('ddlPaquete') == "0" || getValue('ddlPaquete') == '') {
				alert("No ha seleccionado el paquete");
				setFocus('ddlPaquete');
				return false;	
			}
						
			setValue('hidAccion', 'Validar');				
					
			document.frmPrincipal.submit();		
		}	
					
		function f_cancelar()
		{			
			setValue('txtNroCelular','');
			document.frmPrincipal.ddlTipoDocumento.selectedIndex = 0;
			document.frmPrincipal.ddlPaquete.selectedIndex = 0;
			setValue('txtNroDocumento','');
			setValue('txtemail','');
			//document.getElementById("dvmsgpaquete").innerHTML = "";
			document.getElementById("dvmsgpaquete").style.display = "none";
			//document.getElementById("dvmsgCaution").innerHTML = "";
			document.getElementById("lblTextoCaution").innerText = "";
			setFocus('txtNroCelular');		 
		}
		
		
		
		</script>
	</HEAD>
	<body>
		<form id="frmPrincipal" method="post" runat="server">
			<table style="WIDTH: 850px; HEIGHT: 65px" cellSpacing="0" cellPadding="0" width="776" border="0">
				<tr>
					<td class="Header" align="left" height="20" style="WIDTH: 829px">
						<asp:label id="lbOpcion" runat="server"></asp:label>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 830px">
						<table class="contenido" cellSpacing="2" cellPadding="0" width="850" border="0">
							<tr>
								<td class="Arial10B" style="WIDTH: 120px">Número de Celular:</td>
								<td width="198" style="WIDTH: 198px"><asp:textbox onkeypress="validaCaracteres('0123456789')" id="txtNroCelular" runat="server" MaxLength="9"
										CssClass="clsInputEnable" Width="100px"></asp:textbox></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 120px">Tipo Documento:</td>
								<td width="199" style="WIDTH: 198px"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="clsSelectEnable" onChange="cambiarTipoDocumento();"
										Width="216px"></asp:dropdownlist></td>
								<td><asp:textbox onkeypress="validaCaracteres('0123456789')" id="txtNroDocumento" runat="server"
										CssClass="clsInputEnable" Width="150px"></asp:textbox></td>
							</tr>
							<asp:panel id="pnlEmail" Runat="server">
								<TR>
									<TD style="WIDTH: 120px" class="Arial10B">Email:</TD>
									<TD style="WIDTH: 199px" width="199">
										<asp:textbox id="txtemail" runat="server" Width="150px" CssClass="clsInputEnable" MaxLength="50"></asp:textbox></TD>
									<TD>&nbsp;</TD>
								</TR>
							</asp:panel>
							<tr>
								<td class="Arial10B" style="WIDTH: 120px; VERTICAL-ALIGN: top">Paquete:</td>
								<td style="WIDTH: 199px; VERTICAL-ALIGN: top"><asp:dropdownlist id="ddlPaquete" runat="server" CssClass="clsSelectEnable" onChange="cargaPaquete();"
										Width="216px"></asp:dropdownlist></td>
								<td style="VERTICAL-ALIGN: top">
									<div id="dvmsgpaquete" style="BORDER-BOTTOM: #99ccff 1px solid; TEXT-ALIGN: left; BORDER-LEFT: #99ccff 1px solid; PADDING-BOTTOM: 2px; MARGIN: 1px; PADDING-LEFT: 2px; PADDING-RIGHT: 2px; COLOR: #3366ff; BORDER-TOP: #99ccff 1px solid; BORDER-RIGHT: #99ccff 1px solid; PADDING-TOP: 2px">
										<asp:Label id="lblTextoPaqueteDesc" runat="server"></asp:Label>
									</div>
								</td>
							</tr>
							<tr>
								<td></td>
								<td style="WIDTH: 199px"></td>
								<td>
									<div id="dvmsgCaution" style="COLOR: #ff0000"><asp:Label id="lblTextoCaution" runat="server"></asp:Label></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD align="center" style="WIDTH: 829px"><INPUT class="Boton" id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand"
							onclick="validarClaro();" onmouseout="this.className='Boton';" type="button" value="Aceptar" name="btnAceptar">&nbsp;
						<INPUT class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 100px; CURSOR: hand"
							onclick="f_cancelar()" onmouseout="this.className='Boton';" type="button" value="Cancelar"
							name="btnCancelar"></TD>
				</TR>
			</table>
			<input id="hidAccion" type="hidden" name="hidAccion" runat="server"> <input id="hidArrayDataPaquete" type="hidden" name="hidArrayDataPaquete" runat="server">
			<input id="HidCostoPaquete" type="hidden" name="HidCostoPaquete" runat="server">
			<input id="HidFrecuenciaPaquete" type="hidden" name="HidFrecuenciaPaquete" runat="server">
			<input id="hidOpcionServicioVAS" type="hidden" name="hidOpcionServicioVAS" runat="server">
			<input id="hidTextoPaqueteDesc" type="hidden" name="hidTextoPaqueteDesc" runat="server">
			<input id="hidTextoCaution" type="hidden" name="hidTextoCaution" runat="server">
			<input id="hidMensajesRespuestaWS" type="hidden" name="hidTextoCaution" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
