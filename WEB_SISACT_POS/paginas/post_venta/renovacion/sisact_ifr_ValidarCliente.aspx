<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_ValidarCliente.aspx.vb" Inherits="sisact_ifr_ValidarCliente" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<HTML>
	<HEAD>
		<title>Validación Cliente Claro</title>
		<base target="_self">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<LINK title="win2k-cold-1" rel="stylesheet" type="text/css" href="../../../estilos/calendar-blue.css"
			media="all">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="javascript">
		
		
		var Timeout;
		
		function IniciarTiempo()
		{
			cargarImagenEsperando();
			Timeout = setTimeout(function(){ alert("Excedió el tiempo máximo de espera para ingresar la Clave SMS. Vuelva a solicitar una clave"); f_limpiar(); }, getValue('hitTiempoOut'));
		}
		
		function TerminarTiempo()	
		{
			f_ocultar();
			clearTimeout(Timeout);
		}
			
		function f_Salir(intResult)
		{
			f_ocultar();
			window.parent.closethisDiv(intResult);
		}
		
		function f_excepcion()
		{
			f_ocultar();
			if (confirm("¿Esta seguro de salir de la Validación?")) 
			{
				 f_Salir(0)
			} else {
				f_limpiar();
			}
		}
		
		function f_Confirmacion()
		{
				f_ocultar();
			if (confirm("¿Desea Continuar con la Venta? Si selecciona SI, podrá proceder con la venta pero bajo responsabilidad del PDV. Si selecciona NO, puede esperar a que el servicio se restablezca.")) 
			{
				Anthem_InvokePageMethod('LOGS', [1], f_Salir(0));
			} else {
				f_limpiar();
			}
		}
		
		function f_limpiar()
		{
				f_ocultar();
			setEnabled('btnSolicitarClave', false, 'Boton');
			setValue('txtClaveSMS','');
			setReadOnly('txtClaveSMS', true, 'clsInputDisable');
			setEnabled('btnAceptar', true, 'Boton');
		}
		function validaCaracteres(cadena)
		{
			f_ocultar();
			var key = String.fromCharCode(window.event.keyCode);
			var valid = new String(cadena);
			var ok = "no";
			for (var i=0; i<valid.length; i++)
			{
				if (key == valid.substring(i,i+1))
					ok = "yes";
			}
			if (window.event.keyCode != 16)
			{
				if (ok == "no")
					window.event.keyCode = 0;
			}
		}
		
		function HabilitarCheck()
		{
			var flag = document.getElementById('chbPermiso').checked;
			if (flag )
			{
				setEnabled('btnAceptar', false, 'Boton');
			}
			else
			{
				setEnabled('btnAceptar', true, 'Boton');
			}
		}
		
		function Inicio(){
			setTimeout("f_Salir(1)", '<%=ConfigurationSettings.AppSettings("VCLIENTE_TimeOut")%>');
		}
		
		function f_inicio()
		{
			setEnabled('btnAceptar', true, 'Boton');
		}
		
		
		function f_ocultar()
		{
			quitarImagenEsperando();
		}
		
		function cargarImagenEsperando()
		{
			var loading1 = document.createElement("div");
			loading1.id = "loading1";
			loading1.style.position = "absolute";
			loading1.style.right = "0px";
			loading1.style.top = "0px";
			loading1.style.zIndex = "988";
			loading1.style.width = screen.width/3;
			loading1.style.height = screen.height/3;
			loading1.className = 'transparente';
			document.body.appendChild(loading1);

			var loading = document.createElement("div");
			loading.id = "loading";
			loading.style.position = "absolute";
			loading.style.right = screen.width /14;
			loading.style.top = screen.height /4;
			loading.style.zIndex = "989";
			loading.innerHTML = "<img src='../../../images/cargando3.gif'>";
			document.body.appendChild(loading);
		}

		function quitarImagenEsperando()
		{
			var loading1 = document.getElementById("loading1");
			if (loading1 != null)
				document.body.removeChild(loading1);
			var loading = document.getElementById("loading");
			if (loading != null)
				document.body.removeChild(loading);
		}
		
		
		function window.confirm(str)
		{
			execScript('n = msgbox("' + str + '","4132")', "vbscript");
			return (n == 6);
		}
		
		</script>
	</HEAD>
	<body onload = "Inicio();">
		<form id="FrmPrincipal" target="_self" runat="server">
			<div style="Z-INDEX: 102; POSITION: absolute; WIDTH: 457px; HEIGHT: 375px; TOP: 4px; RIGHT: 834px; LEFT: 4px">
				<table class="Contenido" border="0" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="HEIGHT: 20px" class="Header">&nbsp;
							<asp:label id="lblValidacionClaro" runat="server" Text="Validación del Cliente Claro" Width="440px"
								Height="13px" BackColor="Transparent" BorderColor="Transparent"></asp:label></td>
					</tr>
					<tr>
						<td class="Arial10B"><br>
							&nbsp;&nbsp;"Para continuar con el proceso, el sistema debe realizar una 
							validación
							<br>
							&nbsp;&nbsp; previa de identidad. Se enviará una clave vía SMS al numero móvil 
							que
							<br>
							&nbsp;&nbsp; elija el cliente, la cual deberá ingresar a continuación".
							<br>
						</td>
					</tr>
					<tr>
						<td class="Arial10B"><br>
							&nbsp;&nbsp;&nbsp;&nbsp;Por favor, seleccione uno de los siguientes números:
						</td>
					</tr>
					<tr>
						<td class="Arial09B" align="center"><br>
							<div style="WIDTH: 110px; HEIGHT: 113px; OVERFLOW: auto"><asp:radiobuttonlist id="rblListaNumeros" runat="server">
									<asp:ListItem Value="Numero"></asp:ListItem>
								</asp:radiobuttonlist></div>
						</td>
					</tr>
					<tr>
						<td align="center"><br>
							<asp:button id="btnSolicitarClave" onclick="btnSolicitarClave_Click" runat="server" Text="Solicitar Clave SMS"
								CssClass="Boton"></asp:button></td>
					</tr>
					<tr style="STYLE:none">
						<td class="Arial10B"><br>
							&nbsp;&nbsp;&nbsp;&nbsp;Ingrese Clave SMS:
							<asp:textbox id="txtSMS" runat="server" Width="79px" BorderColor="Black" CssClass="clsInputDisable"
								MaxLength="4" ReadOnly="true" Enabled="true"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td align="center"><br>
							<asp:label id="lblClaveSMS" runat="server" CssClass="Arial10B">Clave SMS</asp:label>&nbsp;&nbsp;&nbsp;
							<asp:textbox id="txtClaveSMS" onkeypress="validaCaracteres('0123456789');" runat="server" Width="79px"
								BorderColor="Black" CssClass="clsInputDisable" MaxLength="4" ReadOnly="true"></asp:textbox></td>
					</tr>
					<tr>
						<td align="center"><br>
							<asp:label id="lblMensaje" runat="server" CssClass="Arial9B" Visible="false">Esperando Clave SMS...</asp:label><br>
						</td>
					</tr>
					<tr>
						<td align="center"><br>
							<asp:button id="btnAceptar" onclick="btnAceptar_Click" runat="server" Text="Aceptar" Width="82px"
								Height="26px" CssClass="BotonDisable" Enabled="false"></asp:button><br>
						</td>
					</tr>
					<tr>
						<td>&nbsp;&nbsp;&nbsp;<asp:checkbox id="chbPermiso" onclick="javascript:HabilitarCheck()" runat="server" Text="Permiso para Excepción de la validación&#13;&#10;  bajo responsabilidad del PDV "
								CssClass="Arial10B"></asp:checkbox>
							<br>
						</td>
					</tr>
				</table>
				<input id="hidNroSec" type="hidden" name="hidNroSec" runat="server"> <input id="hidIntentos" type="hidden" name="hidIntentos" runat="server">
				<input id="hidTipoDocu" type="hidden" name="hidTipoDocu" runat="server"> <input id="hidNroDocu" type="hidden" name="hidNroDocu" runat="server">
				<input id="hitTiempoOut" type="hidden" name="hitTiempoOut" runat="server"> <input id="hitTiempo" type="hidden" name="hitTiempo" runat="server">
				<input id="hidIDAudi" type="hidden" name="hidIDAudi" runat="server"> <input id="hidNuevo" type="hidden" name="hidNuevo" runat="server">
				<input id="hidValidarCliente" type="hidden" name="hidValidarCliente" runat="server">
				<input id="hidIntentoSMS" type="hidden" name="hidIntentoSMS" runat="server">
			</div>
		</form>
	</body>
</HTML>
