<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_varios.aspx.vb" Inherits="sisact_pop_varios"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Búsqueda</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../estilos/general.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript" src="../../script/funciones_sec.js"></script>
		<script language="javascript" type="text/javascript">
			
			function f_ValidarEnter()
			{	
				if (document.all)
				{
					if (event.keyCode == 13)
					{	
						document.getElementById('<%=btnBuscar.ClientId%>').click();	
						event.keyCode = 0;
					}
				}
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
			
			function f_Buscar()
			{					
				if (getValue('txtCodigo').length == 0 && getValue('txtDescripcion').length == 0)
				{
					alert('Debe ingresar un código o una descripción');
					return false;
				}
			}
			
			function f_Aceptar()
			{
				var tabla = document.getElementById('<%=dgrLista.ClientId %>');
				
				if (tabla == null)
				{
					alert('Primero debe ingresar valores de búsqueda y hacer clic en Buscar');
					return false;
				}
				
				var fila;
				var cont = tabla.rows.length;
				var resultado = '';
//gaa20130918
				var otro = '';
//fin gaa20130918				
				for (var i = 1; i < cont; i++)
				{
					fila = tabla.rows[i];
					
					if (fila.cells[0].firstChild.checked)
					{
						resultado = fila.cells[1].innerHTML;
						if (fila.cells.length > 2)
						{
							resultado += '|' + fila.cells[2].innerHTML;
//gaa20130918
							resultado += '|' + fila.cells[0].getElementsByTagName("input")[1].value;
//fin gaa20130918							
						}
						window.returnValue = resultado;
						window.close();						
					}
				}
				
				alert('Debe seleccionar algun registro');
				return false;
			}
			
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellspacing="1" border="0">
				<tr>
					<td class="Arial10B">Código</td>
					<td><asp:textbox onkeypress="return f_EventoSoloNumerosEnteros();" onpaste="return false;" id="txtCodigo"
							onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" MaxLength="10"
							CssClass="clsInputEnable" Width="100px"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td class="Arial10B">Descripción</td>
					<td><asp:textbox onkeypress="return f_EventoSoloAlfanumericos();" onpaste="return false;" id="txtDescripcion"
							onkeydown="javascript:f_ValidarEnter();" ondrop="return false;" runat="server" MaxLength="30"
							CssClass="clsInputEnable" Width="300px"></asp:textbox></td>
					<td><asp:button id="btnBuscar" onmouseover="this.className='BotonResaltado';" style="CURSOR: hand"
							onmouseout="this.className='Boton';" CssClass="Boton" Width="90" Text="Buscar" Height="19"
							Runat="server"></asp:button></td>
				</tr>
				<tr>
					<td align="center" colSpan="3">&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="3"><asp:datagrid id="dgrLista" Runat="server" PageSize="10" AllowPaging="True" AutoGenerateColumns="False">
							<AlternatingItemStyle BackColor="#DDDEE2"></AlternatingItemStyle>
							<ItemStyle CssClass="Arial10B" BackColor="#E9EBEE"></ItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-CssClass="TablaTitulos">
									<ItemTemplate>
										<input type="radio" name="rbtLista" /> <input type="hidden" name="hidOtro" id="hidOtro" value="" runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CODIGO" HeaderText="Código" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
									HeaderStyle-CssClass="TablaTitulos" ItemStyle-Width="100px"></asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPCION" HeaderText="Descripción" HeaderStyle-HorizontalAlign="Center"
									HeaderStyle-CssClass="TablaTitulos" ItemStyle-Width="300px"></asp:BoundColumn>
								<asp:BoundColumn DataField="OTRO" Visible="False" HeaderStyle-HorizontalAlign="Center"
									HeaderStyle-CssClass="TablaTitulos" ItemStyle-Width="300px"></asp:BoundColumn>									
							</Columns>
							<PagerStyle CssClass="textgrilla" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="center" colSpan="3">&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="3"><input class="Boton" id="btnAceptar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 90px; CURSOR: hand; HEIGHT: 19px"
							onclick="f_Aceptar();" onmouseout="this.className='Boton';" type="button" value="Aceptar" name="btnAceptar">
						<input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" style="WIDTH: 90px; CURSOR: hand; HEIGHT: 19px"
							onclick="window.close();" onmouseout="this.className='Boton';" type="button" value="Cancelar"
							name="btnCancelar">
					</td>
				</tr>
			</table>
			<input id="hidTipo" type="hidden" name="hidTipo" runat="server">
		</form>
	</body>
</HTML>
 
 
 
 
