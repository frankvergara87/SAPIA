<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_Reintegro.aspx.vb" Inherits="sisact_ifr_Reintegro"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_Reintegro</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../estilos/general.css">
		<LINK rel="stylesheet" type="text/css" href="../../estilos/bsa2.css">
		<script language="JavaScript" src="../../../librerias/jquery_ultimate.js"></script>
		<script language="JavaScript" src="../../../librerias/Lib_FuncValidacion.js"></script>
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script type="text/javascript">
	
	function ValidaSeleccion()
	{

	   var Efectivo = document.getElementById('rbEfectivo');
	   var OCC = document.getElementById('rbOCC');
	   var PagoModalidad = getValue('hidModalidadPago');	
		if (PagoModalidad == 'Fidelizado'){
	   
	     parent.document.getElementById('hidFlagExonerarReintegro').value ='false';
	     parent.document.getElementById('hidFlagConfExoneracionReintegro').value ='false';
	     parent.document.getElementById('hidOpcionAutorizacion').value ='';
	     parent.document.getElementById('hidFormaPagoReintegro').value ='01';
	      f_Salir(0);
		

		}else{
		    parent.document.getElementById('hidFlagExonerarReintegro').value ='true';
			parent.document.getElementById('hidFlagConfExoneracionReintegro').value ='true';
	     parent.document.getElementById('hidOpcionAutorizacion').value ='';
	     parent.document.getElementById('hidFormaPagoReintegro').value ='02';	  
	     f_Salir(0);
	   }
	}
	
	function f_Salir(intResult)
	{
		window.parent.closethisDivReintegro(intResult);
	}
	
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div style="Z-INDEX: 102; RIGHT: 200px; LEFT: 4px; POSITION: absolute; TOP: 4px; HEIGHT: 200px">
				<div style="Z-INDEX: 102; RIGHT: 200px; LEFT: 4px; POSITION: absolute; TOP: 4px; HEIGHT: 200px">
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="400" align="left" border="0">
					<TR>
							<td class="HeaderTitu" style="HEIGHT: 18px" align="left" colSpan="2">REINTEGRO DEL 
								EQUIPO<br>
							</td>
						</TR>
						<TR>
							<td colSpan="2"><br>
							</td>
						</TR>
						<TR>
							<td class="Header" align="center" colSpan="2"><asp:label id="lblMontoReintegro" runat="server" CssClass="Arial10B"></asp:label><br>
						</td>
					</TR>
					<tr>
							<TD align="center" colSpan="2"><asp:label id="lblMensajeReintegro" runat="server" CssClass="Arial10B"></asp:label></TD>
					</tr>
					<TR align="center">
							<TD style="WIDTH: 191px"><INPUT class="BotonOptm" id="btnAceptar" onclick="ValidaSeleccion();" type="button" value="Aceptar"
								name="btnAceptar">
						</TD>
							<td><INPUT class="BotonOptm" id="btnCancelar" onclick="f_Salir(1);" type="button" value="Cancelar"
								name="btnCancelar">
						</td>
					</TR>
				</TABLE>
			</div>
			</div>
			<INPUT id="hidFormaPagoReintegro" type="hidden" name="hidFormaPagoReintegro" runat="server">
			<INPUT id="hidFlagConfExoneracionReintegro" type="hidden" name="hidFlagConfExoneracionReintegro"
				runat="server"> <INPUT id="hidFlagExonerarReintegro" type="hidden" name="hidFlagExonerarReintegro" runat="server">
			<INPUT id="hidOpcionAutorizacion" type="hidden" name="hidOpcionAutorizacion" runat="server">
			<INPUT id="hidModalidadPago" type="hidden" name="hidModalidadPago" runat="server">
		</form>
		<DIV></DIV>
	</body>
</HTML>
