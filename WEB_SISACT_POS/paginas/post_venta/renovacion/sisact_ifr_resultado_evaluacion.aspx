<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_resultado_evaluacion.aspx.vb" Inherits="sisact_ifr_resultado_evaluacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_resultado_eval</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="../../../librerias/Lib_FuncValidacion.js"></script>
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="JavaScript">
			function inicio()
			{
				var blnOK = (getValue('hidMensaje') == '');
				if (!blnOK) {
					alert(getValue('hidMensaje'));
					parent.habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
					parent.quitarImagenEsperando();
				}
				if (getValue('hidMetodo') == 'CalcularLCDisponible') {
					parent.document.getElementById('hidLCDisponiblexProd').value = getValue('hidLCDisponiblexProd');
					parent.retornoConsultarLCDisponible(blnOK);
				}
				if (getValue('hidMetodo') == 'Evaluar') {
					parent.asignarDatosEvaluacionSEC(blnOK, getValue('hidPlanAutonomia'), getValue('hidGarantiaxProducto'), 
							getValue('hidLCDisponible'), getValue('hidImporte'), getValue('hidPoderes'), getValue('hidResultado'),getValue('hidTextoLCDisponible'),
                                                   getValue('hidRiesgoClaro'), getValue('hidComportaClaroC1'), getValue('hidFactorRenovacion'), getValue('hidMSJMontoRegistrado'), getValue('hidRespuestaMontoR'),
                                                   "","","","","");//PROY-24724-IDEA-28174 
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="inicio()">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMensaje" type="hidden" size="1" name="hidMensaje" runat="server"> <input id="hidNroDocumento" type="hidden" name="hidNroDocumento" runat="server">
			<input id="hidOficina" type="hidden" name="hidOficina" runat="server"> <input id="hidClaseCliente" type="hidden" name="hidClaseCliente" runat="server">
			<input id="hidTipoDoc" type="hidden" name="hidTipoDoc" runat="server"> <input id="hidOferta" type="hidden" name="hidOferta" runat="server">
			<input id="hidCanal" type="hidden" name="hidCanal" runat="server"> <input id="hidRiesgo" type="hidden" name="hidRiesgo" runat="server">
			<input id="hidEdad" type="hidden" name="hidEdad" runat="server"> <input id="hidScore" type="hidden" name="hidScore" runat="server">
			<input id="hidCasoEspecial" type="hidden" name="hidCasoEspecial" runat="server">
			<input id="hidNroRRLL" type="hidden" name="hidNroRRLL" runat="server"> <input id="hiCadenaDrools" type="hidden" name="hiCadenaDrools" runat="server">
			<input id="hidPlanesActivos" type="hidden" name="hidPlanesActivos" runat="server">
			<input id="hidNroPlanes" type="hidden" name="hidNroPlanes" runat="server"> <input id="hidListaParam" type="hidden" name="hidListaParam" runat="server">
			<input id="hidPlanAutonomia" type="hidden" name="hidPlanAutonomia" runat="server">
			<input id="hidGarantiaxProducto" type="hidden" name="hidGarantiaxProducto" runat="server">
			<input id="hidImporte" type="hidden" name="hidImporte" runat="server"> <input id="hidLCDisponible" type="hidden" name="hidLCDisponible" runat="server">
			<input id="hidPoderes" type="hidden" name="hidPoderes" runat="server"> <input id="hidLCDisponiblexProd" type="hidden" name="hidLCDisponiblexProd" runat="server">
			<input id="hidGrupoCadena" type="hidden" name="hidGrupoCadena" runat="server"> <input id="hidMetodo" type="hidden" name="hidMetodo" runat="server">
			<input id="hidTipoOperacion" type="hidden" name="hidTipoOperacion" runat="server"><input id="hidResultado" type="hidden" name="hidResultado" runat="server">
			<input id="hidFacRenovacion" type="hidden" name="hidFacRenovacion" runat="server"><input id="hidComporPago" type="hidden" name="hidComporPago" runat="server">
			<input id="hidTextoLCDisponible" type="hidden" name="hidTextoLCDisponible" runat="server"><input id="hidRiesgoClaro" type="hidden" name="hidRiesgoClaro" runat="server">
			<input id="hidComportaConsolidado" type="hidden" name="hidComportaConsolidado" runat="server">
			<input id="hidComportaClaroC1" type="hidden" name="hidComportaClaroC1" runat="server">
			<input id="hidFactorRenovacion" type="hidden" name="hidFactorRenovacion" runat="server">
			<input id="hidMontoRegistrado" type="hidden" name="hidMontoRegistrado" runat="server">
			
			<input id="hidMSJMontoRegistrado" type="hidden" name="hidMSJMontoRegistrado" runat="server">
			<input id="hidRespuestaMontoR" type="hidden" name="hidRespuestaMontoR" runat="server">
			
			<input id="hidPermanencia" type="hidden" name="hidPermanencia" runat="server">
			<input id="hidPlazoAcuerdoBRMS" type="hidden" name="hidPlazoAcuerdoBRMS" runat="server">
			
		</form>
	</body>
</HTML>
 
 
 
 
