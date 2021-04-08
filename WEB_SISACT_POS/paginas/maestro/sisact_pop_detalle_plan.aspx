<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_detalle_plan.aspx.vb" Inherits="sisact_pop_detalle_plan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cargar Detalle a Planes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../librerias/Lib_FuncValidacion.js"></script>
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" src="ConsumerValidacion.js"></script>
		<script language="javascript" type="text/javascript">
		
			function deshabilitarControles(check,control){
				//debugger;
				if(check.checked==true){
					control.disabled = false;
					control.focus();
				}
				else{
					control.disabled = true;
					control.value = '';
				}
			}
			
			function llamarPadre()
			{
				window.opener.refrescarDetalle();
				window.close();
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
			
			function f_ValidarGrabar()
			{							
				var txtCuota=document.getElementById("txtValorCuota");
				var txtC=txtCuota.value;
				if (txtC=="")
				{
					alert('Ingresar % de Cuota Inicial');
					setFocus('txtValorCuota');
					txtCuota.value = '0.0';
					return false;
				}
				
				if (parseFloat(eval(txtCuota.value))>100 || parseFloat(eval(txtCuota.value))<0)
				{
					alert('El % de Cuota Inicial debe estar entre 0 y 100');
					setFocus('txtValorCuota');
					txtCuota.value = '0.0';					
					return false;
				}
				var Cuota=document.getElementById("hidCuota");
				Cuota.value=txtCuota.value;
				return true;			
				
			}
			
			function validarCuotas()
			{
				var ddlTipDoc=document.getElementById("ddlCuotas");
				var valor=ddlTipDoc.options[ddlTipDoc.selectedIndex].value;
				var txtCuota=document.getElementById("txtValorCuota");
				var Cuota=document.getElementById("hidCuota");
				if (valor=="00")
				{					
					txtCuota.value="100";
					txtCuota.disabled=true;
				}
				else
				{
					txtCuota.value=Cuota.value;
					txtCuota.disabled=false;
					setFocus('txtValorCuota');
				}
			}
			
			function validarCuotasCombo()
			{
				var ddlTipDoc=document.getElementById("ddlCuotas");
				var valor=ddlTipDoc.options[ddlTipDoc.selectedIndex].value;
				var txtCuota=document.getElementById("txtValorCuota");
				var Cuota=document.getElementById("hidCuota");
				if (valor=="00")
				{					
					txtCuota.value="100";
					txtCuota.disabled=true;
				}
				else
				{
					txtCuota.value="";
					txtCuota.disabled=false;
					setFocus('txtValorCuota');
				}
			}
			

		</script>
		<style type="text/css">.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
	A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout"  onload=" validarCuotas();">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td class="header" borderColor="#ffffff" align="center" colSpan="2" height="20" style="WIDTH: 767px">Cargar 
						Detalle - Planes
					</td>
				</tr>
				<tr>
					<td borderColor="#ffffff" colSpan="2" style="WIDTH: 767px"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></td>
				</tr>
				<tr>
					<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 838px; PADDING-TOP: 10px"
						align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td colSpan="2" style="WIDTH: 456px"><IMG height="3" alt="" src="../../images/spacer.gif" width="2" border="0"></td>
							</tr>
							<TR> <!-- Documento -->
								<TD class="Arial10B" style="WIDTH: 337px; HEIGHT: 22px">&nbsp;Tipo Documento
								</TD>
								<TD class="Arial10B" style="WIDTH: 180px; HEIGHT: 22px"><asp:dropdownlist id="ddlTipoDocumento" Runat="server" Width="184px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
								<TD class="Arial10B" style="WIDTH: 400px"></TD>
								<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
							</TR>
							<TR> <!-- Riesgo -->
								<TD class="Arial10B" style="WIDTH: 337px; HEIGHT: 22px">&nbsp;Plazo de Acuerdo
								</TD>
								<TD class="Arial10B" style="WIDTH: 180px; HEIGHT: 22px"><asp:dropdownlist id="ddlPlazoAcuerdo" Runat="server" Width="184px" cssclass="clsSelectEnable"></asp:dropdownlist></TD>
								<TD class="Arial10B" style="WIDTH: 400px"></TD>
								<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
							</TR>
							<TR> <!-- Cuota -->
								<TD class="Arial10B" style="WIDTH: 337px; HEIGHT: 22px">&nbsp;Cuota
								</TD>
								<TD class="Arial10B" style="WIDTH: 180px; HEIGHT: 22px"><asp:dropdownlist id="ddlCuotas" Runat="server" Width="184px" cssclass="clsSelectEnable" onchange="validarCuotasCombo();"></asp:dropdownlist></TD>
								<TD class="Arial10B" style="WIDTH: 400px"></TD>
								<TD class="Arial10B" style="HEIGHT: 22px" colSpan="2"></TD>
							</TR>
							<TR> <!--Cargo Fijo-->
								<TD class="Arial10B" style="WIDTH: 337px">&nbsp;% Cuota Inicial (*)</TD>
								<TD class="Arial10B" style="WIDTH: 180px"><asp:textbox id="txtValorCuota" onPaste="return false" onkeydown="return fSoloMontos(event, this);"
										runat="server" MaxLength="6" width="100px" cssclass="clsInputEnable"></asp:textbox></TD>
								<TD class="Arial10B" style="WIDTH: 400px"></TD>
								<TD class="Arial10B" colSpan="2"></TD>
							</TR>
							<tr>
								<td style="WIDTH: 337px"></td>
							</tr>
							<tr align="center">
								<td colSpan="2" height="30" style="WIDTH: 456px">
									<asp:button id="btnAgregarPdv" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Agregar"></asp:button>&nbsp;&nbsp;
									<asp:button id="btnCancelar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Cancelar"></asp:button>
								</td>
							</tr>
						</table>
						<asp:label id="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtAccionGrabarPDV" runat="server"></asp:textbox></div>
			<input id="hidCuota" style="WIDTH: 123px; HEIGHT: 22px" type="hidden" size="15" name="hidCuota"
				runat="server">
		</form>
		<script language="javascript" type="text/javascript">

		</script>
	</body>
</HTML>
 
 
 
 
