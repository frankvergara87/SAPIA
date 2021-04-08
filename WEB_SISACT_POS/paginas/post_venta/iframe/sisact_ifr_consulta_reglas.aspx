<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_reglas.aspx.vb" Inherits="sisact_ifr_consulta_reglas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_consulta_reglas</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="JavaScript">
			function inicio()
			{
				var blnOK = (getValue('hidMensaje') == '');
			
				if (getValue('hidMetodo') == 'Evaluar')
				{
					var strResultado = getValue('hidResultado');
					var strVal = /_/g;
					var arrVal = strResultado.split(';');
					var strVal1 = /,/g;
					
					var Resultado = arrVal[1].replace(strVal,"#");
					arrVal[1] = Resultado.toString();
					
					strResultado = arrVal.join(";");
										
					var arrResultado = strResultado.split('_');
					
                                        //PROY-24724-IDEA-28174 - INICIO 
					var strProtMovil = strResultado.substring(strResultado.indexOf("=") + 1);					
					var arrResultadoPM = strProtMovil.split('_');
					
					parent.asignarDatosEvaluacionSEC(blnOK, arrResultado[0], arrResultado[1], arrResultado[8], arrResultado[2], "", arrResultado[3], arrResultado[4], 
							arrResultado[5], arrResultado[6], arrResultado[7], "", "",arrResultadoPM[0],arrResultadoPM[1],arrResultadoPM[2],arrResultadoPM[3],arrResultadoPM[4]); 
					//PROY-24724-IDEA-28174 - FIN
				}
					
				if (getValue('hidMetodo') == 'EvaluarCuota')
					parent.asignarDatosCuotas(getValue('hidResultado'));
				
				if (getValue('hidMetodo') == 'CalcularLCDisponible')
					parent.consultaReglasCreditos();	
				if (getValue('hidMetodo') == 'EvaluarCliente')
					parent.consultarClienteBRMSCallBack(getValue('hidResultado'),getValue('hidMensaje'));
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="inicio()">
		<form id="Form1" method="post" runat="server">
			<input id="hidIdFila" type="hidden" name="hidIdFila" runat="server"> <input id="hidTipoDocumento" type="hidden" name="hidTipoDocumento" runat="server">
			<input id="hidNroDocumento" type="hidden" name="hidNroDocumento" runat="server">
			<input id="hidOficina" type="hidden" name="hidOficina" runat="server"> <input id="hidMetodo" type="hidden" name="hidMetodo" runat="server">
			<input id="hidResultado" type="hidden" name="hidResultado" runat="server">
			<input id="hidMensaje" type="hidden" name="hidMensaje" runat="server">
			<!--//'PROY-24724-IDEA-28174 - INICIO -->
			<input id="hidflagProTMovil" type="hidden" name="hidflagProTMovil" runat="server">
			<input id="hidEvalPM" type="hidden" name="hidEvalPM" runat="server"> <input id="hidPrima" type="hidden" name="hidPrima" runat="server">
			<input id="hidDeducible" type="hidden" name="hidDeducible" runat="server"> <input id="hidCertificadoPM" type="hidden" name="hidCertificadoPM" runat="server">
			<!--//'PROY-24724-IDEA-28174 - FIN -->
			<!--Inicio - SD1052592 -->
			<input id="hidCoID" type="hidden" name="hidCoID" runat="server"> 
			<!--Fin - SD1052592 -->
		</form>
	</body>
</HTML>
