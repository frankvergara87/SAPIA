<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_consulta_unificada.aspx.vb" Inherits="sisact_ifr_consulta_unificada" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_consulta_unificada</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="JavaScript" src="../../../librerias/Lib_FuncValidacion.js"></script>
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="javascript" src="../../../librerias/funciones_generales.js"></script>
		<script language="JavaScript">
		
		
			function inicio()
			{

				var PlanVigente  = getValue('hidVigente');
				var CodPlanNoVigente = getValue('hidCodPlanNoVigente'); 
				var IdPlanVig =  getValue('hidIdPlanVig');
				var PlanDesNoVig =  getValue('hidplanDesNoVig');
//gaa20180301
				var msjInformativo;
				msjInformativo = getValue('hidInformativo');
				
				if (msjInformativo != ''){
					alert(msjInformativo);
					setValue('hidInformativo', '');
				}
//fin gaa20180301
				if (getValue('hidMensaje') != ''){
						if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanVigente") %>'){
						
								parent.document.getElementById('hidVigente').value = PlanVigente;
						parent.document.getElementById('hidCodPlanNoVigente').value = CodPlanNoVigente;
						parent.document.getElementById('hidIdPlanVig').value = IdPlanVig;
						parent.document.getElementById('hidplanDesNoVig').value = PlanDesNoVig;	
						
						}else if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
							parent.document.getElementById('hidVigente').value = PlanVigente;
							parent.document.getElementById('hidCodPlanNoVigente').value = CodPlanNoVigente;
							parent.document.getElementById('hidIdPlanVig').value = IdPlanVig;
							parent.document.getElementById('hidplanDesNoVig').value = PlanDesNoVig;	
						//alert(getValue('hidMensaje'));
						}else{
							alert(getValue('hidMensaje'));
						
						if (parent.document.getElementById('trDetalleValidacionBloqueo') != null)
						{					
						parent.document.getElementById('trDetalleValidacionBloqueo').style.display='none';
							parent.nuevaEvaluacion();
							return;
						}
						parent.quitarImagenEsperando();
						if (parent.document.getElementById('txtEquipoPrecio' + getValue('hidIdFila')) != null)
						{
							parent.document.getElementById('hidValorEquipo' + getValue('hidIdFila')).value = '';
							parent.document.getElementById('txtTextoEquipo' + getValue('hidIdFila')).value = 'SELECCIONE...';
							parent.document.getElementById('txtEquipoPrecio' + getValue('hidIdFila')).value = '';
						}
						return;
					}
				}
					
				setValue('hidMensaje', '');
				if (getValue('hidMetodo') == 'LlenarPlan')
					asignarPlan();
				if (getValue('hidMetodo') == 'LlenarMaterial')
					asignarCampanaMaterial();
				if (getValue('hidMetodo') == 'LlenarCampana')
					llenarCampana();	
				if (getValue('hidMetodo') == 'LlenarEquipoPrecio')
					asignarEquipoPrecio();
				if (getValue('hidMetodo') == 'LlenarMontoTopeConsumo')
					LlenarMontoTopeConsumo();					
				if (getValue('hidMetodo') == 'CambiarTipoOferta')
					CambiarTipoOferta();
				if (getValue('hidMetodo') == 'ValidarBlacklistComision')
					consultarBlacklist();	
				if (getValue('hidMetodo') == 'ValidarBlacklistComisionPostpago'){
					consultarBlacklistPostpago();	
					return;
					}
				if (getValue('hidMetodo') == 'CambiarCasoEspecial')
					CambiarCasoEspecial();						
				if (getValue('hidMetodo') == 'LlenarServicio')
					LlenarServicio();
				if (getValue('hidMetodo') == 'LlenarServicioCampana')
					LlenarServicioCampana();	
				if (getValue('hidMetodo') == 'LlenarPaquete')
					asignarPaquete();				
				if (getValue('hidMetodo') == 'LlenarServicioCampanaCorp')
					LlenarServicioCampanaCorp();
				if (getValue('hidMetodo') == 'LlenarServCampCorpTot')				
					LlenarServCampCorpTot();
				if (getValue('hidMetodo') == 'MostrarSecPendiente')
					MostrarSecPendiente();			
				if (getValue('hidMetodo') == 'LlenarPlanPaq')
					LlenarPlanPaq();
				if (getValue('hidMetodo') == 'LlenarPaquetePlan')
					LlenarPaquetePlan();									
				if (getValue('hidMetodo') == 'LlenarPlazo')
					LlenarPlazo();						
				if (getValue('hidMetodo') == 'LlenarServicioCampanaDTH')
					LlenarServicioCampana();
				if (getValue('hidMetodo') == 'LlenarKitDTH')
					asignarKits();
				if (getValue('hidMetodo') == 'LlenarPlanPaq3Play')
					LlenarPlanPaq3Play();					
				if (getValue('hidMetodo') == 'LlenarPlazoCampanaDTH')
					LlenarPlazoCampanaDTH();
				if (getValue('hidMetodo') == 'LlenarPlanDTH')
					asignarPlan();
				if (getValue('hidMetodo') == 'LlenarPlazoServicioDTH')
					LlenarPlazoServicioDTH();
				if (getValue('hidMetodo') == 'LlenarSolucion')
					LlenarSolucion();
				if (getValue('hidMetodo') == 'LlenarPaquete3Play')
					LlenarPaquete3Play();
				if (getValue('hidMetodo') == 'LlenarCuota')
					LlenarCuota();
				if (getValue('hidMetodo') == 'ValidarNroPortabilidad')
					ValidarNroPortabilidad();
				if (getValue('hidMetodo') == 'ValidarSECRecurrente')
					ValidarSECRecurrente();
				if (getValue('hidMetodo') == 'ValidarTitularidad')
					ValidarTitularidad();
				//ECM s8 regresando llamada
				if (getValue('hidMetodo') == 'consultarCantidadLineas3G')
					regresarConsultarCantidadLineas3G();
				//FIN ECM S8
//gaa20150504					
	            if (getValue('hidMetodo') == 'LlenarCampanaPlazo')
					LlenarCampanaPlazo();
				if (getValue('hidMetodo') == 'LlenarServicioMaterial')
					LlenarServicioMaterial();
//fin gaa20150504					
//gaa20161020
				if (getValue('hidMetodo') == 'LlenarFamiliaPlan')
					LlenarFamiliaPlan();
//fin gaa20161020				
				parent.quitarImagenEsperando();
				parent.autoSizeIframe();
			}
			
			function LlenarPlanPaq()
			{
				var idFila = getValue('hidIdFila');
				var strPaqueteActual = parent.document.getElementById('hidPaqueteActual').value;
				var strResultado = getValue('hidResultado');
				parent.asignarPlanMultiLinea(idFila, strResultado, strPaqueteActual);
			}
			function asignarCampanaMaterial()
			{
				var idFila = getValue('hidIdFila');
				var idCampana = getValue('hidCampana');
				var strResultado = getValue('hidResultado');								
				parent.asignarCampanasMateriales(idFila, idCampana, strResultado);
			}
			function asignarKits()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');								
				parent.asignarKits(idFila, strResultado);
			}	
			function asignarPlan()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');								
				
				//Inicio campañas nuevas 25/11/2015
				setValue('hidPlanNuevo',strResultado);
				var strResultadoPlan = getValue('hidPlanNuevo');
				//fin  campañas nuevas 25/11/2015	
				parent.asignarPlan(idFila, strResultado,strResultadoPlan); //modificado 25112015
			}
			function llenarCampana()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');								
				parent.llenarCampana(idFila, strResultado);
			}
			function asignarEquipoPrecio()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarPrecio(idFila, strResultado);
			}
			function LlenarMontoTopeConsumo()
			{
				var strResultado = getValue('hidResultado');
				var idFila = getValue('hidIdFila');
				var txtMontoTopeConsumo = parent.document.getElementById('txtMontoTopeConsumo' + idFila);
				txtMontoTopeConsumo.value = strResultado;
			}
			function consultarBlacklist()
			{
				var strCadena = getValue('hidResultado');
				var strResultado = strCadena.split('-')[0];
				if (strResultado != 'S')
				{	
					var strSap = strCadena.split('-')[1];				
					if (getValue('hidPerfil149') == 'S')
					{
						//debugger;
						parent.document.getElementById('hidCanalSap').value = strSap.split('|')[1];
						parent.document.getElementById('hidOrgVenta').value = strSap.split('|')[2];
						parent.document.getElementById('hidCentro').value = strSap.split('|')[3];
						parent.document.getElementById('hidGrupoCadena').value = strSap.split('|')[4];
					}
					parent.document.getElementById('hidTipoDocVentaSap').value = strSap.split('|')[0];
				}
				parent.consultarBlacklist(strResultado);			
			}
			function consultarBlacklistPostpago()
			{
				var strCadena = getValue('hidResultado');
				var strResultado = strCadena.split('-')[0];
				parent.consultarBlacklist(strResultado);			
			}
			function CambiarCasoEspecial()
			{
				var strResultado = getValue('hidResultado');
				parent.document.getElementById('hidListaTipoProducto').value = strResultado.split('¬')[0];
				var strCE = strResultado.split('¬')[1];
				parent.retornarCambioCE(strCE.split('_')[0], 
											strCE.split('_')[1], 
											strCE.split('_')[2], 
											strCE.split('_')[3], 
											strCE.split('_')[4]);			
			}	
			function asignarPaquete()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');			
				var ddlPaquete = parent.document.getElementById('ddlPaquete' + idFila);
				var strPaqueteActual = parent.document.getElementById('hidPaqueteActual').value;

				var strPaquete = strResultado.split('~')[1];
				var strPlan = strResultado.split('~')[0];
				
				parent.llenarDatosCombo(ddlPaquete, strPaquete, true);

				if (strPaqueteActual.length > 0)
					ddlPaquete.value = strPaqueteActual;
												
				parent.asignarPlan(idFila, strPlan, ''); //modificado 25112015
			}
//gaa20121206
			function CambiarTipoOferta()
			{
				var strResultado = getValue('hidResultado');
				parent.retornarCambioTipoOferta(strResultado);
			}
			function LlenarServicio()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.retornarServicio(idFila, strResultado);				
			}
			function LlenarServicioCampana()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.retornarServicioCampana(idFila, strResultado);				
			}			
			function LlenarServicioCampanaCorp()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.retornarServicioCampanaCorp(idFila, strResultado);				
			}			
			function LlenarServCampCorpTot()
			{
				var strResultado = getValue('hidResultado');
				parent.retornarServCampCorpTot(strResultado);
			}			
			function MostrarSecPendiente()
			{
				var strResultado = getValue('hidResultado');
				parent.mostrarSecPendiente(strResultado);
				
				if (strResultado.length != 0)
					parent.document.getElementById('hidListaTipoProducto').value = getValue('hidResultadoAux');				
			}
			function LlenarPaquetePlan()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				var arrListas = strResultado.split('¬');
				var ddlPaquete = parent.document.getElementById('ddlPaquete' + idFila);
				var strPaqueteActual = parent.document.getElementById('hidPaqueteActual').value;

				parent.llenarDatosCombo(ddlPaquete, arrListas[0], true);
				
				if (strPaqueteActual.length > 0)
					ddlPaquete.value = strPaqueteActual;				
				
				parent.asignarPlan(idFila, arrListas[1], ''); //modificado 25112015
			}
			function LlenarPlazo()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');								
				parent.asignarPlazo(idFila, strResultado);
			}					
			function LlenarPlanPaq3Play()
			{
				var idFila = getValue('hidIdFila');
				var strPaqueteActual = parent.document.getElementById('hidPaqueteActual').value;
				var strResultado = getValue('hidResultado');
				parent.asignarPlanMultiLinea3Play(idFila, strResultado, strPaqueteActual);
			}
			function quitarImagenEsperando()
			{
				var loading1 = parent.document.getElementById("loading1");
				if (loading1 != null)
				{
					parent.document.body.removeChild(loading1);
					var loading = parent.document.getElementById("loading");
					parent.document.body.removeChild(loading);
				}
			}
			function LlenarPlazoCampanaDTH()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarPlazoCampanaDTH(idFila, strResultado);
			}
			function LlenarPlazoServicioDTH()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.retornarPlazoServicio(idFila, strResultado);				
			}		
			function LlenarSolucion()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarSolucion(idFila, strResultado)
			}			
			function LlenarPaquete3Play()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarPaquete3Play(idFila, strResultado);			
			}
			function LlenarCuota()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.llenarDatosCuota(strResultado)
			}
			function ValidarNroPortabilidad()
			{
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.retornarValidarNroPortabilidad(idFila, strResultado);				
			}
			function ValidarSECRecurrente()
			{
				var idFila = getValue('hidIdFila');			
				var strResultado = getValue('hidResultado');
				parent.retornarSECRecurrente(idFila, strResultado);				
			}
			
			function ValidarTitularidad()
			{
				//ECM S8
				var res=getValue('hidResultado').split("|");
				var tipocliente=res[1];
				var strResultado = res[0];
				//var strResultado = getValue('hidResultado');
				//fin ecm s8
				//var strResultado = getValue('hidResultado');
				parent.document.getElementById('hidResultado').value=strResultado;
				if(strResultado=='False') {
					parent.habilitarControl(true);
					parent.document.getElementById('btnvalidarClaro').disabled = false;	
					parent.document.getElementById('txtNroDoc').value ='';
					parent.document.getElementById('txtNroLinea').value='';
					$("#checkCartaPoder").attr('checked', false);       //PROY-25335 - Contratación Electrónica - Release 0
                                        document.getElementById('hidCheckCartaPoder').value = 'N';  //PROY-25335 - Contratación Electrónica - Release 0
				}
				parent.document.getElementById('txtcicloFacturacion').value = document.getElementById('hidCicloFac').value;
				parent.document.getElementById('hidCicloFact').value = document.getElementById('hidCicloFac').value;
				parent.document.getElementById('txtRepLegal').value = document.getElementById('hidRepLegal').value;
				parent.document.getElementById('hidRepLegal').value = document.getElementById('hidRepLegal').value;
				parent.document.getElementById('hidLimiteCred').value = document.getElementById('hidLimiteCred').value;
				parent.document.getElementById('hidTitular').value = document.getElementById('hidTitular').value;
				parent.document.getElementById('hidCorreo').value = document.getElementById('hidCorreo').value;
				parent.document.getElementById('hidFechaNac').value = document.getElementById('hidFechaNac').value;
				parent.document.getElementById('hidMsgTitularidad').value = document.getElementById('hidMsgTitularidad').value;
				
				//INICIO WHZR 29092014
				parent.document.getElementById('hidMontoRegistrado').value = document.getElementById('hidMontoRegistrado').value;
				//FIN WHZR 29092014
				
				//INICIO WHZR 04112014
				parent.document.getElementById('hidPermanencia').value = document.getElementById('hidPermanencia').value;
				parent.document.getElementById('hidPlazoAcuerdo').value = document.getElementById('hidPlazoAcuerdo').value;
				
				parent.document.getElementById('hidMesesPorVencer').value = document.getElementById('hidMesesPorVencer').value;
				
				//FIN WHZR 04112014
				
				//CONSOLIDADO 11122014
				 
								parent.document.getElementById('txtDireccionFact').value=getValue('hidDireccion');
								parent.document.getElementById('txtDepartamentoFact').value=getValue('hidDepartamento');
								parent.document.getElementById('txtProvinciaFact').value=getValue('hidProvincia');
								parent.document.getElementById('txtDistritoFact').value=getValue('hidDistrito');
								parent.document.getElementById('txtCorreoElecFact').value=getValue('hidCorreo');
								parent.document.getElementById('txtReferenciaFact').value=getValue('hidTelefonoReferencia');
								parent.document.getElementById('txtIniApadece').value=getValue('hidFechaInicioApadece');
								parent.document.getElementById('txtFinApadece').value=getValue('hidFechaFinApadece');
								parent.document.getElementById('txtReintegro').value=parseFloat(getValue('hidReintegro'));
								parent.document.getElementById('hidReintegro').value=parseFloat(getValue('hidReintegro'));
								parent.document.getElementById('txtTotalReintgro').value=parseFloat(getValue('hidReintegro'));
								parent.document.getElementById('txtIMSI').value=getValue('hidIMSI');
								parent.document.getElementById('hidIMSI').value=getValue('hidIMSI');
								parent.document.getElementById('txtLimiteCredito').value=parseFloat(getValue('hidLimiteCred')).toFixed(2);
								parent.document.getElementById('txtSegmento').value=getValue('hidSegmento');
								parent.document.getElementById('hidPlanAct').value=getValue('hidPlanAct');
								parent.document.getElementById('hidFlagReintegro').value=getValue('hidFlagReintegro');
								parent.document.getElementById('hidCustumerId').value=getValue('hidCustumerId');
								parent.document.getElementById('hidCO').value=getValue('hidCO');
								parent.document.getElementById('hidApellidosCli').value=getValue('hidApellidosCli');
								parent.document.getElementById('hidNombresCli').value=getValue('hidNombresCli');
								parent.document.getElementById('hidFlagRenovacionAdelantada').value=getValue('hidFlagRenovacionAdelantada');
				
				//Inicio Modificacion Plan No Vigente
				if (getValue('hidplanDesNoVig') != '' ) {
					parent.document.getElementById('txtPlanComercial').value = getValue('hidplanDesNoVig');//jmori  23012015
				}
				else {
					parent.document.getElementById('txtPlanComercial').value = getValue('hidplancomercial');
				}
				//Fin Modificacion Plan No Vigente
				
                                parent.document.getElementById('hiCFSiga').value=getValue('hidCFSiga');//jmori
                                parent.document.getElementById('txtNroLineaD').value= getValue('hidNroLinea');//jmori
                                parent.document.getElementById('txtcicloFacturaciondac').value= getValue('hidCicloFac');//jmori
                                parent.document.getElementById('hidCuentaBSCS').value= getValue('hidCuentaBSCS');//jmori
                                parent.document.getElementById('hidHLR').value = getValue('hidHlr');
                                parent.document.getElementById('hidPl4G').value = getValue('hidPl4G');
                                
				//Inicio Modificacion Plan No Vigente
                parent.document.getElementById('hidCampanasNoVig').value= getValue('hidCampanasNoVig');
                //Fin Modificacion Plan No Vigente
                
                parent.document.getElementById('hidDiasPendientes').value= getValue('hidDiasPendientes');
				//gaa20160526
                 parent.document.getElementById('hidOfertaLinea').value = getValue('hidOfertaLinea');              
				//fin gaa20160526
                                
                                
                //Perfil Autorizado 
                parent.document.getElementById('hdAutoriza').value = getValue('hdAutoriza');
                                
                parent.document.getElementById('hidValidadProtMovil').value= getValue('hidValidadProtMovil'); //'PROY-24724-IDEA-28174  
                                

				//ECM s8 devuelvo resultado y si el tipo de cliente
				parent.retornoTitularidad(strResultado, tipocliente);
				//CONSOLIDADO 11122014
				//parent.retornoTitularidad(strResultado);
				//FIN ECM S8						
			}	
			
			function AsignarTipoDocVenta(resTipoDocVenta)
			{
				parent.AsignarTipoDocVenta(resTipoDocVenta);
			}	
//gaa20150504
			function LlenarCampanaPlazo() {
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarCampanaPlazo(idFila, strResultado);
			}
			
			function LlenarServicioMaterial() {
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarServicioMaterial(idFila, strResultado);
			}			
//fin gaa20150504
//gaa20161020
			function LlenarFamiliaPlan() {
				var idFila = getValue('hidIdFila');
				var strResultado = getValue('hidResultado');
				parent.asignarFamiliaPlan(idFila, strResultado);
			}
			//ECM s8
			function regresarConsultarCantidadLineas3G()
			{
				var strResultado = getValue('hidResultado');
				parent.retorno_mostrarLineas3G(strResultado);
			}
			//fin ECM S8
//fin gaa20161020
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="inicio()">
		<form id="Form1" method="post" runat="server">
			<input id="hidIdFila" type="hidden" name="hidIdFila" runat="server"> <input id="hidCampana" type="hidden" name="hidCampana" runat="server">
			<input id="idPlan" type="hidden" name="idPlan" runat="server"> <input id="hidResultado" type="hidden" name="hidResultado" runat="server">
			<input id="hidNroDocumento" type="hidden" name="nroDocumento" runat="server"> <input id="hidMetodo" type="hidden" name="hidMetodo" runat="server">
			<input id="hidMensaje" type="hidden" name="hidMensaje" runat="server"> <input id="hidPerfil149" type="hidden" name="hidPerfil149" runat="server">
			<input id="hidFlgEvaluarMovil" type="hidden" name="hidFlgEvaluarMovil" runat="server">
			<input id="hidResultadoAux" type="hidden" name="hidResultadoAux" runat="server">
			<input id="hidOficina" type="hidden" name="hidOficina" runat="server"><input id="hidCicloFac" type="hidden" name="hidCicloFac" runat="server">
			<input id="hidRepLegal" type="hidden" name="hidRepLegal" runat="server"><input id="hidLimiteCred" type="hidden" name="hidLimiteCred" runat="server"><input id="hidTitular" type="hidden" name="hidTitular" runat="server">
			<input id="hidCorreo" type="hidden" name="hidCorreo" runat="server"><input id="hidFechaNac" type="hidden" name="hidFechaNac" runat="server">
			<input id="hidMsgTitularidad" type="hidden" name="hidMsgTitularidad" runat="server">
			<input id="hidMontoRegistrado" type="hidden" name="hidMontoRegistrado" runat="server">
			<input id="hidPermanencia" type="hidden" name="hidPermanencia" runat="server"> <input id="hidPlazoAcuerdo" type="hidden" name="hidPlazoAcuerdo" runat="server">
			<!--Consolidado 11122014--><input id="hidDireccion" type="hidden" name="hidDireccion" runat="server">
			<input id="hidDepartamento" type="hidden" name="hidDepartamento" runat="server">
			<input id="hidProvincia" type="hidden" name="hidProvincia" runat="server"> <input id="hidDistrito" type="hidden" name="hidDistrito" runat="server">
			<input id="hidTelefonoReferencia" type="hidden" name="hidTelefonoReferencia" runat="server">
			<input id="hidFechaInicioApadece" type="hidden" name="hidFechaInicioApadece" runat="server">
			<input id="hidFechaFinApadece" type="hidden" name="hidFechaFinApadece" runat="server">
			<input id="hidReintegro" type="hidden" name="hidReintegro" runat="server"> <input id="hidIMSI" type="hidden" name="hidIMSI" runat="server">
			<input id="hidSegmento" type="hidden" name="hidSegmento" runat="server"> <input id="hidPlanAct" type="hidden" name="hidPlanAct" runat="server">
			<input id="hidFlagReintegro" type="hidden" name="hidFlagReintegro" runat="server">
			<input id="hidCustumerId" type="hidden" name="hidCustumerId" runat="server"> <input id="hidCO" type="hidden" name="hidCO" runat="server">
			<input id="hidApellidosCli" type="hidden" name="hidApellidosCli" runat="server">
			<input id="hidNombresCli" type="hidden" name="hidNombresCli" runat="server"> <input id="hidFlagConfExoneracionReintegro" type="hidden" name="hidFlagConfExoneracionReintegro"
				runat="server"> 
			<!--Consolidado 11122014--><input id="hidMesesPorVencer" type="hidden" name="hidMesesPorVencer" runat="server">
			<input id="hidFlagVentaCuota" type="hidden" name="hidFlagVentaCuota" runat="server">
			<input id="hidFlagRenovacionAdelantada" type="hidden" name="hidFlagRenovacionAdelantada"
				runat="server"> 
			<!--jmori-->
			<input id="hidCFSiga" type="hidden" name="hidCFSiga" runat="Server"> <input id="hidNroLinea" type="hidden" name="hidNroLinea" runat="Server">
			<input id="hidCuentaBSCS" type="hidden" name="hidCuentaBSCS" runat="Server">
			<input id="hidVigente" type="hidden" name="hidVigente" runat="Server">
			<input id="hidCodPlanNoVigente" type="hidden" name="hidCodPlanNoVigente" runat="Server">
			<input id="hidIdPlanVig" type="hidden" name="hidIdPlanVig" runat="Server">
			
			<input id="hidplanDesNoVig" type="hidden" name="hidplanDesNoVig" runat="Server">
			
			<input id="hidPlanNuevo" type="hidden" name="hidPlanNuevo" runat="Server">
			<input id="hidHlr" type="hidden" name="hidHlr" runat="Server">
			<input id="hidPl4G" type="hidden" name="hidPl4G" runat="Server">
			<!--Inicio Modificacion Plan No Vigente -->
			<input id="hidCampanasNoVig" type="hidden" name="hidCampanasNoVig" runat="Server">
			<!--Fin Modificacion Plan No Vigente -->
			<input id="hidDiasPendientes" type="hidden" name="hidDiasPendientes" runat="Server">
			<input type="hidden" id="hidOfertaLinea" name="hidOfertaLinea" runat="server">
	<!--//'PROY-24724-IDEA-28174 - INICIO-->
			<input id="hidValidadProtMovil" type="hidden" name="hidValidadProtMovil" runat="Server">
			<!--//'PROY-24724-IDEA-28174 - FIN-->
			<input id="hdAutoriza" type="hidden" name="hdAutoriza" runat="Server">
	<!--//PROY-21600 - INICIO-->
			<input id="hidInformativo" type="hidden" name="hidInformativo" runat="server">
	<!--//PROY-21600 - FIN-->
		</form>
	</body>
</HTML>
