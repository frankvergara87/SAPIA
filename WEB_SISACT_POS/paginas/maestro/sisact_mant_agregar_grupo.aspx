<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_mant_agregar_grupo.aspx.vb" Inherits="sisact_mant_agregar_grupo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Agregar Grupo</title>
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
				window.opener.refrescarGrupo();
				window.close();
			}
			
			function validaCaracteres() 
			{
				var CaracteresPermitidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_-() ";
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";
				for (var i=0; i<valid.length; i++)
				{
					if (key == valid.substring(i,i+1))
						ok = "yes";
				}
				if (ok == "no")
					window.event.keyCode=0;

				if ((key > 0x60) && (key < 0x7B))
					window.event.keyCode = key-0x20;
			}
			
		</script>
		<style type="text/css">.textgrilla { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #e06704; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
	A:hover { FONT-SIZE: 12px; COLOR: #e06704; TEXT-DECORATION: none }
	A:active { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:visited { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
	A:link { FONT-SIZE: 12px; COLOR: #384e7a; TEXT-DECORATION: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmPrincipal" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="80%" align="center" border="0">
				<tr>
					<td class="header" borderColor="#ffffff" align="center" colSpan="2" height="20" style="WIDTH: 767px">Agregar 
						Grupo
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
							<TR> <!--Cargo Fijo-->
								<TD class="Arial10B" style="WIDTH: 266px">&nbsp;Descripción Grupo </TD>
								<TD class="Arial10B" style="WIDTH: 180px"><asp:textbox id="txtNombreGrupo"  onkeypress="validaCaracteres();"  onPaste="return false" runat="server" MaxLength="50" width="166px" cssclass="clsInputEnable"></asp:textbox></TD>
								<TD class="Arial10B" style="WIDTH: 400px"></TD>
								<TD class="Arial10B" colSpan="2"></TD>
							</TR>
							<tr>
								<td style="WIDTH: 266px"></td>
							</tr>
							<tr align="center">
								<td colSpan="2" height="30" style="WIDTH: 456px">
									<asp:button id="btnAgregarPdv" onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
										runat="server" CssClass="Boton" Text="Agregar"></asp:button>&nbsp;&nbsp; <input class="Boton" id="btnCancelar" onmouseover="this.className='BotonResaltado';" onclick="window.close();"
										onmouseout="this.className='Boton';" type="button" value="Cancelar">
								</td>
							</tr>
						</table>
						<asp:label id="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
				</tr>
			</table>
			<div style="DISPLAY: none"><asp:textbox id="txtAccionGrabarPDV" runat="server"></asp:textbox></div>
		</form>
		<script language="javascript" type="text/javascript">

		</script>
	</body>
</HTML>
 
 
 
 
