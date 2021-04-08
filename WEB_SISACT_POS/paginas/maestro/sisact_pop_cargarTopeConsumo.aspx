<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_cargarTopeConsumo.aspx.vb" Inherits="sisact_pop_cargarTopeConsumo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tope Consumo - Caso Especial</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta charset="utf-8" http-equiv="Content-Type" content="text/html">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<style type="text/css">.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
	A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
		<script language="javascript" type="text/javascript">
		
			function f_Validar() { 
				document.getElementById("<%=btnValidarServer.ClientID%>").click(); 
				return false; 
			}
			
			function f_Aceptar() { 
				document.getElementById("<%=btnAceptarServer.ClientID%>").click(); 
				return false; 
			}
			
			function f_Actualizar() { 
				if(confirm('¿Esta Seguro de Actualizar la Información?')) 
				{
					document.getElementById("<%=btnActualizarServer.ClientID%>").click(); 
				} 
				return false; 
			}

			function f_Eliminar(Codigo) { 
				if(confirm('¿Esta Seguro de Eliminar este Registro?')) 
				{
					document.getElementById("<%=hidCodigo.ClientID %>").value = Codigo;
					document.getElementById('hidCondicion').value = 'ELIMINAR'; 
					document.getElementById("<%=btnEliminarServer.ClientID%>").click(); 
				} 
				return false; 
			}

			function chkEditar_Click(chk,txt)
			{
				var obj_chk = document.getElementById(chk);
				var obj_txt = document.getElementById(txt);
			
				if(obj_chk.checked)
				{
					obj_txt.readOnly = false;
					obj_txt.focus();
				}
				else
				{
					obj_txt.readOnly = true;
					obj_txt.value = ""
				}
			}
			
			function f_OnFocus(obj)
			{
				obj.style.background= "#ccffff";
			}

			function f_OnBlur(obj)
			{
				obj.style.background= "#ffffff";
			}
			
			function llamarPadre()
			{
				window.opener.refrescarRestricciones();
				window.close();
			}

			/*función que cierra la ventana*/
			function f_CerrarVentana()
			{
				window.close();
				return false;
			}

			function formatDecimal2(obj) { 
				var num = obj.value; 
				//if(num=="") return;
				num = num.toString().replace(/\$|\,/g,''); 
				if(isNaN(num)) num = "0"; 
				sign = (num == (num = Math.abs(num))); 
				num = Math.floor(num*100+0.50000000001); 
				cents = num%100; 
				num = Math.floor(num/100).toString(); 
			 
				if (cents<0) cents=cents*-1; 
				if(cents<10) cents = "0" + cents; 
			 
				for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++) 
				{
					num = num.substring(0,num.length-(4*i+3))+','+ num.substring(num.length-(4*i+3)); 
				}
			 
				obj.value = (((sign)?'':'-') + num + '.' + cents); 
			}

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
			
			function f_EventoNumerosDecimales()
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
			
			function f_EnterKeyPress(evento,pos) { 
				var tecla = (document.all) ? evento.keyCode : evento.which;
				if(tecla == 13) {
					if(pos == 1) document.getElementById("ddlRiesgo").focus();
					else if(pos ==  2) document.getElementById("ddlPlan").focus();
					else if(pos ==  3) document.getElementById("txtNroPlanes").focus();
					else if(pos ==  4) document.getElementById("txtPlazos").focus();
					else if(pos ==  5) document.getElementById("btnAgregar").click();
					return false; 
				}
				else
				{
					if(pos ==  4) f_EventoSoloNumerosEnteros();
					else if(pos == 5) f_EventoSoloNumerosEnteros();
				}
				return true;
			}
		
		</script>
	</HEAD>
	<body style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; MARGIN: 0px; PADDING-TOP: 5px">
		<form id="frmRiesgos" method="post" runat="server">
			<table style="BORDER-RIGHT: #95b7f3 1px solid; BORDER-TOP: #95b7f3 1px solid; BORDER-LEFT: #95b7f3 1px solid; BORDER-BOTTOM: #95b7f3 1px solid"
				cellSpacing="1" cellPadding="1" width="100%" align="center">
				<tr height="20">
					<td class="TablaTitulos" style="FONT-SIZE: 11px" align="center">Tope por Consumo - 
						Caso Especial
					</td>
				</tr>
				<tr>
					<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
						align="center">
						<table class="Arial11BV" cellSpacing="1" cellPadding="1">
							<tr>
								<td style="HEIGHT: 18px" align="right" width="120">Plan :&nbsp;
								</td>
								<td style="HEIGHT: 18px" align="left" width="310"><asp:dropdownlist onkeypress="return f_EnterKeyPress(event,1)" id="ddlPlan" runat="server" CssClass="Arial11BV"
										Width="300px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td style="PADDING-BOTTOM: 5px" align="center" colSpan="2"><asp:datagrid id="dgTope" CssClass="Arial11BV" Width="450px" Runat="Server" BorderColor="#95B7F3"
										PageSize="7" CellPadding="1" CellSpacing="1" DataKeyField="TPCN_CODIGO" AutoGenerateColumns="False">
										<ItemStyle CssClass="TablaFilasGrid"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="20px" CssClass="TablaTitulos"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="TPCN_CODIGO" HeaderText="IdTope"></asp:BoundColumn>
											<asp:BoundColumn DataField="TPCV_DESCRIPCION" HeaderText="Tope Consumo">
												<HeaderStyle Width="250px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Estado Tope">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:DropDownList ID="ddlEstadoTope" Runat="Server" Width="190" CssClass="Arial11BV"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:button id="btnAceptar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										CssClass="Boton" Width="80px" Runat="Server" Text="Aceptar"></asp:button>&nbsp;<asp:button id="btnCerrar" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										CssClass="Boton" Width="80px" Runat="Server" Text="Cerrar"></asp:button></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:label id="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hidCodigo" type="hidden" name="hidCodigo" runat="server"> <input id="hidCondicion" type="hidden" name="hidCondicion" runat="server">
			<asp:button id="btnMarcarServer" style="DISPLAY: none" Runat="Server"></asp:button>
			<asp:button id="btnValidarServer" style="DISPLAY: none" Runat="Server"></asp:button>
			<asp:button id="btnActualizarServer" style="DISPLAY: none" Runat="Server"></asp:button>
			<asp:button id="btnAceptarServer" style="DISPLAY: none" Runat="Server"></asp:button>
			<asp:textbox id="txtCodigo" style="DISPLAY: none" Runat="Server"></asp:textbox><asp:button id="btnEliminarServer" style="DISPLAY: none" Runat="server"></asp:button><asp:button id="btnEliminarTodosServer" style="DISPLAY: none" Runat="server"></asp:button></form>
	</body>
</HTML>
 
 
 
 
