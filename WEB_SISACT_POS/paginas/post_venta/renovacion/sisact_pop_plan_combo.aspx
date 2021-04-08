<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_pop_plan_combo.aspx.vb" Inherits="sisact_pop_plan_combo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>sisact_pop_plan_combo</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="javascript" type="text/javascript">
		
			function window.confirm(str)
			{
				execScript('n = msgbox("' + str + '","4132")', "vbscript");
				return (n == 6);
			}

			function aceptar()
			{
				var strPlan = getValue('hidPlanActualizado');
				if (strPlan.length > 0)
					var arrPlan = strPlan.split('|');
				else
				{
					window.returnValue = '';
					window.close();
					return;
				}

				var strPlanActualizado = arrPlan[1];
				var strBolsaSeleccionada = arrPlan[3];

				if (strBolsaSeleccionada.length > 0)
				{
					var str = 'Ha seleccionado la ' + strBolsaSeleccionada + ', se actualizará el plan a: ' + strPlanActualizado + '. ¿Desea confirmar su selección?';
					if (!window.confirm(str) )
						return false;
					else
					{
						window.returnValue = strPlan;
						window.close();
						return;
					}
				}
				else
				{
					window.returnValue = '';
					window.close();
				}
			}
			
			function cancelar()
			{
				window.returnValue = '';
				window.close();
			}


			function seleccionarBolsa(valor)
			{				
				setValue('hidPlanActualizado', '');
								
				if (valor.split('|')[2] > 0)
				{
					setValue('hidPlanActualizado', valor);
				}
			}
			
		</script>
  </head>
  <body MS_POSITIONING="GridLayout">

    <form id="Form1" method="post" runat="server">
<table border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="Header" height="18" align="left">&nbsp;Asociar Servicio Bolsa</td>
				</tr>
			</table>
			<table class="contenido" border="0" cellSpacing="0" cellPadding="1" width="100%">
				<tr>
					<td class="Arial10b">Plan Seleccionado:
					</td>
					<td><asp:textbox id="txtDesPlanSeleccionado" Width="200px" Runat="server" CssClass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD></TD>
					&nbsp;
					<TD></TD>
				</TR>
				<tr>
					<td class="Arial10b" colSpan="2"><asp:radiobuttonlist id="rblLista" runat="server" RepeatLayout="Flow" Font-Size="8pt" AutoPostBack="True"></asp:radiobuttonlist><asp:literal id="litLista" Runat="server"></asp:literal></td>
				</tr>
			</table>
			<table width="100%">
				<tr>
					<td height="30" vAlign="bottom" colSpan="2" align="center"><input style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px" id="btnAceptar" class="Boton" onmouseover="this.className='BotonResaltado';"
							onmouseout="this.className='Boton';" onclick="javascript:aceptar();" value="Aceptar" type="button" name="btnAceptar">
						<input style="WIDTH: 126px; CURSOR: hand; HEIGHT: 19px" id="btnCancelar" class="Boton"
							onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
							onclick="javascript:cancelar();" value="Cancelar" type="button" name="btnCancelar">
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidPlanActualizado" name="hidPlanActualizado">
		</form>
    </form>

  </body>
</html>
 
 
 
 
