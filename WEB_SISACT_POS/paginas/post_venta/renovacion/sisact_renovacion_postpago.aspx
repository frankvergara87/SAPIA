<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_renovacion_postpago.aspx.vb" Inherits="sisact_renovacion_postpago" aspcompat="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_renovacion_postpago_dac</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<LINK href="../../estilos/bsa2.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../librerias/jquery_ultimate.js"></script>
		<script language="JavaScript" src="../../../librerias/Lib_FuncValidacion.js"></script>
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<script language="JavaScript" src="../../../librerias/json2.js"></script><!-- PROY-29123 -->
		<script language="javascript" src="../../../script/Biometria/sisact_validacion_identidad.js"></script>
		<script language="JavaScript">		
		
			var constModalidadPagoEnCuota = '<%= ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota") %>';	
			var constTipoOperacionRenovacion = '<%= ConfigurationSettings.AppSettings("constTextoOperacionRenovacion") %>';
			var constTipoOperacionAltaRenovacion = '<%= ConfigurationSettings.AppSettings("constTipoOperacionAltaRenovacion") %>';			
			var consCPValorEspecial = '<%= ConfigurationSettings.AppSettings("consCPValorEspecial") %>';	
				var MsjValidarBlackList = '<%= ConfigurationSettings.AppSettings("MsjValidarBlackList") %>';
			var consUrlPaginaBiometria = '<%=ConfigurationSettings.AppSettings("consUrlPaginaBiometria")%>';
			var consUrlPaginaNoBiometria = '<%=ConfigurationSettings.AppSettings("consUrlPaginaNoBiometria")%>';
		
			var Key_documentoDNI = null;
					var Key_documentoPermitido = null;
					var Key_HuelleroPostpago = null;
					var Key_DNIVencido = null;
					var Key_validacionBioExitosa = null;
					var Key_errorHuellaDNI = null;
					var Key_errorReniec = null;
					var Key_errorSixBio = null;
					var Key_clienteDiscapacidad = null;
					var Key_cancelacionBiometria = null;
					var Key_msjErrorCalidadHuella = null;
					var Key_mensajeErrorMaximoIntentos = null;
					var Key_canalesPermitidosCP = null;
					var Key_validarDNIVencido = null;
					var Key_canalesPermitidosBiometria = null;
					var Key_TipoOperacionPermitidoReno = null;
		
					/*Inicio PROY-31636-RENTESEG*/
					var Key_codigoDocMigratorios = null;
					var Key_codigoDocMigraYPasaporte = null;
					var Key_codDocMigra_Pasaporte_CE = null;
					var Key_codigoDocCIRE = null;
					var Key_codigoDocCIE = null;
					var Key_codigoDocCPP = null;
					var Key_codigoDocCTM = null;
					var Key_minLengthDocMigratorios = null;
					var Key_maxLengthDocMigratorios = null;
					var Key_codigoDocPasaporte07 = null;
					var Key_codigoDocPasaporte08 = null;
					var Key_flagPermitirProductosLTE = null;
					var Key_docsExistEvaluacionPost = null;
					var Key_tipoDocPermitidoPostCAC = null;
					var Key_tipoDocPermitidoPostDAC = null;
					var Key_tipoDocPermitidoPostCAD = null;
					/*Fin PROY-31636-RENTESEG*/
		
		//INICIO RIHU - 19122014 EVERIS
			$(document).ready(function() {
			 
				//select all the a tag with name equal to modal
				$('a[name=modal]').click(function(e) {
					//Cancel the link behavior
					e.preventDefault();
				});
				
				//if close button is clicked
				$('.window .close').click(function (e) {
					//Cancel the link behavior
					e.preventDefault();
					
					$('#mask').hide();
					$('.window').hide();
				});		
				
				//if mask is clicked
				$('#mask').click(function () {
				});	
				
				$('#CloseDiv').click(function () {
					closethisDiv(1);
				});
				$('#CloseDivReintegro').click(function () {
					closethisDivReintegro(1);
				});
			 
				$(window).resize(function () {
				 
 					var box = $('#boxes .window');
			 
					//Get the screen height and width
					var maskHeight = $(document).height();
					var maskWidth = $(document).width();
			      
					$('#mask').css({'width':maskWidth,'height':maskHeight});
			               
					//Get the window height and width
					var winH = $(document).height();
					var winW = $(document).width();
			 
					//Set the popup window to center
					box.css('top',  winH/2 - box.height()/2);
					box.css('left', winW/2 - box.width()/2);
				});
			});
			//Fin RIHU - 19122014 EVERIS

			var msjreint = "";
            var valorConfigApadece = '<%= ConfigurationSettings.AppSettings("ValorConfig") %>';//jmori
			var mydate = new Date();
			var fechaActual = mydate.getDate() + "/" + parseInt(mydate.getMonth()) + 1 + "/" + mydate.getFullYear();
			var codTipoProductoMovil;
			var codTipoProductoFijo;
			var codTipoProductoDTH;
			var codTipoProductoBAM;
			var codTipoProductoHFC;
					
						//PROY-24724-IDEA-28174 - Parametros  INI
			var vCodPrecioPrepagoMinimo;
			var vPM_NoCalifica;
			var vPM_NoCumpleRequisito;
			var vErrorGrabarEvalProtMovil;
			var vConsErrorGrabarProtMovil;
			var vPM_MontoPrimaMayor;
			var vConfirmEliminarProtMovil;
			var vMsjEquipoEvaluado;
			var vMsjSeleccionarEquipo;
			var vMsjPMOfrecerSeguro;
			var vCodServProteccionMovil;
			var vClienteWsError;
			//PROY-24724-IDEA-28174 - Parametros  FIN
			
			function validaCaracteresNombres() 
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

                         function ValidarVendedor(v_PO){
				
				var url = '../renovacion/sisact_valida_vendedor.aspx?';
				var params = "";
					params = "PO="+ v_PO;
							
					url = url + params;				
																	
					window.showModalDialog(url,window,'dialogTop:200;status:no;edge:sunken;dialogHide:true;help:no;dialogWidth:389px;dialogHeight:206px');								
					return

			}
			
			function LoadPageValidate(vpage){
				document.location = vpage;
			}
           
		
			
			function inicio()
			{
			   //#Region Inicio PROY-25335
				
				if (getValue('hidAccion')!= 'Grabar' && getValue('hidAccion')!= 'GenerarPedido')
				{
					Anthem_InvokePageMethod('getParametros',[],
						function(result){
						var response = result.value
							getParametros_CallBack(response);		
						}
					);
					
					function getParametros_CallBack(response)
					{
                                                if(response != null && response != '')
						{
						Key_documentoDNI = response.Key_documentoDNI;
						Key_documentoPermitido = response.Key_documentoPermitido;
						Key_HuelleroPostpago = response.Key_HuelleroPostpago;
						Key_DNIVencido = response.Key_DNIVencido;
						Key_validacionBioExitosa = response.Key_validacionBioExitosa;
						Key_errorHuellaDNI = response.Key_errorHuellaDNI;
						Key_errorReniec = response.Key_errorReniec;
						Key_errorSixBio = response.Key_errorSixBio;
						Key_clienteDiscapacidad = response.Key_clienteDiscapacidad;
						Key_cancelacionBiometria = response.Key_cancelacionBiometria;
						Key_msjErrorCalidadHuella = response.Key_msjErrorCalidadHuella;
						Key_mensajeErrorMaximoIntentos = response.Key_mensajeErrorMaximoIntentos;
						Key_canalesPermitidosCP = response.Key_canalesPermitidosCP;
						Key_validarDNIVencido = response.Key_validarDNIVencido;
						Key_canalesPermitidosBiometria = response.Key_canalesPermitidosBiometria;
						Key_TipoOperacionPermitidoReno = response.Key_TipoOperacionPermitidoReno;
						
						/*Inicio PROY-31636-RENTESEG*/
						Key_codigoDocMigratorios = response.Key_codigoDocMigratorios;
						Key_codigoDocMigraYPasaporte = response.Key_codigoDocMigraYPasaporte;
						Key_codDocMigra_Pasaporte_CE = response.Key_codDocMigra_Pasaporte_CE;
						Key_codigoDocCIRE = response.Key_codigoDocCIRE;
						Key_codigoDocCIE = response.Key_codigoDocCIE;
						Key_codigoDocCPP = response.Key_codigoDocCPP;
						Key_codigoDocCTM = response.Key_codigoDocCTM;
						Key_minLengthDocMigratorios = response.Key_minLengthDocMigratorios;
						Key_maxLengthDocMigratorios = response.Key_maxLengthDocMigratorios;
						Key_codigoDocPasaporte07 = response.Key_codigoDocPasaporte07;
						Key_codigoDocPasaporte08 = response.Key_codigoDocPasaporte08;
						Key_flagPermitirProductosLTE = response.Key_flagPermitirProductosLTE;
						Key_docsExistEvaluacionPost = response.Key_docsExistEvaluacionPost;
						Key_tipoDocPermitidoPostCAC = response.Key_tipoDocPermitidoPostCAC;
						Key_tipoDocPermitidoPostDAC = response.Key_tipoDocPermitidoPostDAC;
						Key_tipoDocPermitidoPostCAD = response.Key_tipoDocPermitidoPostCAD;
						}
						/*Fin PROY-31636-RENTESEG*/
						setValue('hidCodigoDocMigraYPasaporte',Key_codigoDocMigraYPasaporte)
					}
				}
			   //#Region Fin  PROY-25335

			if(getValue('hidMensajeRenovacion') != ''){
				return;
			}

//'PROY-24724-IDEA-28174 - Parametros INI
				vCodPrecioPrepagoMinimo =getValue('hidCodPrecioPrepagoMinimo');
				vPM_NoCalifica=getValue('hidPM_NoCalifica');
				vPM_NoCumpleRequisito=getValue('hidPM_NoCumpleRequisito');
				vErrorGrabarEvalProtMovil=getValue('hidErrorGrabarEvalProtMovil');
				vConsErrorGrabarProtMovil=getValue('hidConsErrorGrabarProtMovil');
				vPM_MontoPrimaMayor=getValue('hidPM_MontoPrimaMayor');
				vConfirmEliminarProtMovil=getValue('hidConfirmEliminarProtMovil');
				vMsjEquipoEvaluado=getValue('hidMsjEquipoEvaluado');
				vMsjSeleccionarEquipo=getValue('hidMsjSeleccionarEquipo');
				vMsjPMOfrecerSeguro=getValue('hidMsjPMOfrecerSeguro');
				vCodServProteccionMovil=getValue('hidCodServProteccionMovil');
				vClienteWsError=getValue('hidClienteWsError');
				//'PROY-24724-IDEA-28174 - Parametros FIN
				
			if(getValue('hidPuntoVenta') == '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>' && getValue('hidOvencAsistencia') == '1'){
				if(getValue('hidFlagVendedor') == 'S')	{
				document.getElementById('trPrincipal').style.display = 'block';
				document.getElementById('trPrincipal1').style.display = 'block';
				document.getElementById('trPrincipal2').style.display = 'block';
				document.getElementById('trPrincipal3').style.display = 'block';
				document.getElementById('trPrincipal4').style.display = 'block';
				document.getElementById('trPrincipal5').style.display = 'block';
				var msjValidaDAC = getValue('hidValidaInicial');
				if (Trim(msjValidaDAC).length > 0)
				{
					alert(msjValidaDAC);
					//setValue('hidValidaInicial', '')
					habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', false);
					habilitarBoton('btnvalidarClaro', 'Validación Claro', false);
					return;
				}
				else
				{
					habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
					habilitarBoton('btnvalidarClaro', 'Validación Claro', true);
				}
				
				cambiarCanal();
				cambiarTipoDocumento();
				
				if (getValue('hidUsuarioNoRegistrado') == 'S')
				{
					alert('<%= ConfigurationSettings.AppSettings("constMensajeUsuarioPDV") %>');
					setEnabled('btnvalidarClaro', false, '');
					return false;
				}

				//Constantes Tipos Productos
				codTipoProductoMovil = '<%= ConfigurationSettings.AppSettings("constTipoProductoMovil") %>';
				codTipoProductoFijo = '<%= ConfigurationSettings.AppSettings("constTipoProductoFijo") %>';
				codTipoProductoDTH = '<%= ConfigurationSettings.AppSettings("CodTipoProductoDTH") %>';
				codTipoProductoBAM = '<%= ConfigurationSettings.AppSettings("constTipoProductoBAM") %>';
				codTipoProductoHFC = '<%= ConfigurationSettings.AppSettings("CodTipoProductoHFC") %>';
				
				if (getValue('hidPerfil_149') == 'S')
					document.getElementById('trPuntoVenta').style.display = '';
				else { 
					document.frmPrincipal.ddlPuntoVenta.selectedIndex = 1;
					cambiarPuntoVenta()
				}

				if (getValue('hidAccion') == 'Grabar')
				{
					quitarImagenEsperando();
					
					var nroSEC = getValue('hidNroSEC');
					var mensaje = getValue('hidMensaje');
					var blnOK = (getValue('hidCodError') != '1');
					var blnAjuntar = (getValue('hidAdjuntarIngreso') == 'S');
					var strTipoDoc = getValue('hidTipoDocumento');
					var blnIrCreditos = (getValue('hidCreditosxAsesor') == 'S');
					var strEstadoSEC = getValue('hidCodEstadoSEC');
					var blnPortabilidad = (getValue('hidTienePortabilidad') == 'S');
					
					nuevaEvaluacion();
					alert(mensaje);

					if (blnOK)
					{
						if (strTipoDoc == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
						{
							if (blnIrCreditos)
								AdjuntarDocumentos(nroSEC);
							
						}
						else
						{
							if (blnAjuntar)
								verAdjuntarDocumentos(nroSEC);
							
						}	
					}
							
							setValue('hidAccion', '');
							cambiarCanal();
				}
				else if (getValue('hidAccion') == 'GenerarPedido')
				{
					quitarImagenEsperando();
					
					var resultadoGrabar = (getValue('hidCodError') != '1');
					var resultadoPedido = (getValue('hidCodErrorPedido') != '1');
					var mensajeGrabado = getValue('hidMensaje');
					var mensajePedido = getValue('hidMsg');
					
					//gaa20160609
					if (resultadoPedido)
					{
						var strMsgPlanEmpleadoDatos = getValue('hidMsgPlanEmpleadoDatos');
						if (strMsgPlanEmpleadoDatos.length > 0)
						alert(strMsgPlanEmpleadoDatos);
					}
					//fin gaa20160609
					
					nuevaEvaluacion();
					if (resultadoPedido)
						alert(mensajePedido);
					else
						alert(mensajeGrabado + ' '+ mensajePedido);	
							
							
							setValue('hidAccion', '');
							cambiarCanal();
				}
				}else{
					ValidarVendedor('VE');
				}
			}else{
				document.getElementById('trPrincipal').style.display = 'block';
				document.getElementById('trPrincipal1').style.display = 'block';
				document.getElementById('trPrincipal2').style.display = 'block';
				document.getElementById('trPrincipal3').style.display = 'block';
				document.getElementById('trPrincipal4').style.display = 'block';
				document.getElementById('trPrincipal5').style.display = 'block';
				var msjValidaDAC = getValue('hidValidaInicial');
				if (Trim(msjValidaDAC).length > 0)
				{
					alert(msjValidaDAC);
					//setValue('hidValidaInicial', '')
					habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', false);
					habilitarBoton('btnvalidarClaro', 'Validación Claro', false);
					return;
				}
				else
				{
					habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
					habilitarBoton('btnvalidarClaro', 'Validación Claro', true);
				}
				
				cambiarCanal();
				cambiarTipoDocumento();
							
				if (getValue('hidUsuarioNoRegistrado') == 'S')
				{
					alert('<%= ConfigurationSettings.AppSettings("constMensajeUsuarioPDV") %>');
					setEnabled('btnvalidarClaro', false, '');
					return false;
				}

				//Constantes Tipos Productos
				codTipoProductoMovil = '<%= ConfigurationSettings.AppSettings("constTipoProductoMovil") %>';
				codTipoProductoFijo = '<%= ConfigurationSettings.AppSettings("constTipoProductoFijo") %>';
				codTipoProductoDTH = '<%= ConfigurationSettings.AppSettings("CodTipoProductoDTH") %>';
				codTipoProductoBAM = '<%= ConfigurationSettings.AppSettings("constTipoProductoBAM") %>';
				codTipoProductoHFC = '<%= ConfigurationSettings.AppSettings("CodTipoProductoHFC") %>';
				
				if (getValue('hidPerfil_149') == 'S')
					document.getElementById('trPuntoVenta').style.display = '';
				else { 
					document.getElementById('frmPrincipal').ddlPuntoVenta.selectedIndex = 1;
					cambiarPuntoVenta()
				}

				if (getValue('hidAccion') == 'Grabar')
				{
					quitarImagenEsperando();
					
					var nroSEC = getValue('hidNroSEC');
					var mensaje = getValue('hidMensaje');
					var blnOK = (getValue('hidCodError') != '1');
					var blnAjuntar = (getValue('hidAdjuntarIngreso') == 'S');
					var strTipoDoc = getValue('hidTipoDocumento');
					var blnIrCreditos = (getValue('hidCreditosxAsesor') == 'S');
					var strEstadoSEC = getValue('hidCodEstadoSEC');
					var blnPortabilidad = (getValue('hidTienePortabilidad') == 'S');
					var strMsgPM = getValue('hidErrorGrabarProtMovil'); //'PROY-24724-IDEA-28174 
					//alert('strMsgPM :: ' + strMsgPM); //'PROY-24724-IDEA-28174 
					
					nuevaEvaluacion();
					alert(mensaje);

					if (blnOK)
					{
					     //'PROY-24724-IDEA-28174 - INicio -Parametro
						if (strMsgPM == '1')						
						 alert(vErrorGrabarEvalProtMovil);
						 //'PROY-24724-IDEA-28174 - FIN -Parametro
						 
						if (strTipoDoc == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
						{
							if (blnIrCreditos)
								AdjuntarDocumentos(nroSEC);
							
						}
						else
						{
							if (blnAjuntar)
								verAdjuntarDocumentos(nroSEC);
							
				}
			}
						
						
						setValue('hidAccion', '');
						cambiarCanal();
				}
				else if (getValue('hidAccion') == 'GenerarPedido')
				{
					quitarImagenEsperando();
					
					var resultadoGrabar = (getValue('hidCodError') != '1');
					var resultadoPedido = (getValue('hidCodErrorPedido') != '1');
					var mensajeGrabado = getValue('hidMensaje');
					var mensajePedido = getValue('hidMsg');
					var strMsgPM = getValue('hidErrorGrabarProtMovil'); //'PROY-24724-IDEA-28174
					//gaa20160609
					if (resultadoPedido)
					{
						var strMsgPlanEmpleadoDatos = getValue('hidMsgPlanEmpleadoDatos');
						if (strMsgPlanEmpleadoDatos.length > 0)
						alert(strMsgPlanEmpleadoDatos);
					}
					//fin gaa20160609
					
					nuevaEvaluacion();
					if (resultadoPedido){
						alert(mensajePedido);
	                      //'PROY-24724-IDEA-28174 - INicio -Parametro
						if (strMsgPM == '1')						
						 alert(vConsErrorGrabarProtMovil);
						 //'PROY-24724-IDEA-28174 - FIN -Parametro
                                        }
					else
						alert(mensajeGrabado + ' '+ mensajePedido);	
							
						
						setValue('hidAccion', '');
						cambiarCanal();
				}
			}

			}

			function nuevaEvaluacion()
			{
				inicializarDatosInicial();
				inicializarPanelDatosInicial();
				inicializarPanelDetalleCliente();
				inicializarPanelRepresentante();
				inicializarPanelCondicionVenta();
				inicializarPanelResultado();
				inicializarPanelComentarios();
				inicializarPanelGrabar();
				inicializarPanelResVenta();
				trConsultarDC.style.display = 'none';
				tdPlanNoVigente.style.display = 'none';
				tdPlanNoVigente1.style.display = 'none';
				
				trDetalleValidacionBloqueo.style.display='none';
				LimpiaDatosPM(); //'PROY-24724-IDEA-28174 
				setValue('hidDatosBRMS',"");//PROY-29123
			}

			function inicializarDatosInicial()
			{
				var arrControles = document.getElementById('frmPrincipal').all;
				var strListaHidden = ",__EVENTTARGET,__EVENTARGUMENT,__VIEWSTATE";
				strListaHidden = strListaHidden + ",hidTiempoInicioReg,hidUsuarioNoRegistrado,hidVerDetalleLinea,hidVerVentaProactiva,hidPerfil_149,hidListaPuntoVenta,hidTipoVenta,hidListaBlackList,hidBLVendedor,hidListaRiesgo,hidPlanBase,hidPlanCombo,hidPlanBolsaCompartida";
				strListaHidden = strListaHidden + ",hidDocVendedor,hidNomVendedor,hidFlagVendedor,hidListaParametroGeneral,hidFactorLC,hidCanalSap,hidOrgVenta,hidCentro,hidGrupoCadena,hidCreditosxCE,hidTipoDocumentos,hidSubsidioMenor,hidSubsidioMayor,hidListaTipoOperacion,hidRatioFactorMin,hidRatioFactorMax,hidTipoOferta,hidIccid,hidDesMaterialIccid,hidPuntoVenta,hidOfVentaCod,hidPerfilCreditos,hidPerfilSEC,hidCanalOf,hidGrabar,hidMesesMaxAS,hidVigente,hidCodPlanNoVigente,hidIdPlanVig,hidMantenerPlan,hidplanDesNoVig,hidMesesMaxASMax";
				for (var i=0; i< arrControles.length; i++)
				{
					if (arrControles[i].type == 'hidden' || arrControles[i].tagName == 'HIDDEN')
					{
						if (strListaHidden.indexOf(arrControles[i].name) < 0)
												arrControles[i].value = '';
							}
						}
								setValue('hidNroConsultaBRMS', '0');
				quitarImagenEsperando();
			}
			
			function retornarConsultaDataCredito(msg)
			{

				habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
				alert(''+ msg + '');
				quitarImagenEsperando();
			}
			
			function AdjuntarDocumentos(nroSec)
			{
				var url = '../documentos/sisact_generacion_acuerdos.aspx?nroSec=' + nroSec + '&llamadoDesde=Evaluacion';
				abrirVentana(url,'','660','150','Acuerdos',false);
			}

			function inicializarPanelDatosInicial()
			{
				if (getValue('hidUsuarioNoRegistrado') != 'S')
					setEnabled('btnvalidarClaro', true, 'BotonOptm');

				if (getValue('hidPerfil_149') == 'S')
				{
					setValue('hidBLVendedor', '');
					document.frmPrincipal.ddlCanal.selectedIndex = 1;
					cambiarCanal();
				}else{
					 document.frmPrincipal.ddlCanal.selectedIndex = 1;
					 var strCodCanal = getValue('ddlCanal');
					 setValue('hidTipoCanal',strCodCanal)
				}
				setValue('txtNroDoc', '');
				setValue('txtNroLinea', '');
				
				    $("#checkCartaPoder").attr('checked', false);    //PROY-25335 - Contratación Electrónica - Release 0
                                    document.getElementById('hidCheckCartaPoder').value = 'N';   //PROY-25335 - Contratación Electrónica - Release 0
				
				habilitarControl(true);
				document.getElementById('ddlTipoDocumento').selectedIndex = 0;
				cambiarTipoDocumento();

				document.getElementById('ddlModalidad').selectedIndex = 0;
				setValue('hidModalidadVenta', getValue('ddlModalidad'));
				
				document.getElementById('btnDetalleLinea').style.display = 'none';
				document.getElementById('lblMensaje').innerHTML = '';
				cambiarPortabilidad(false);
				setEnabled('btnvalidarClaro', true, 'BotonOptm');
			}
			
			function inicializarPanelDetalleCliente()
			{
				setEnabled('txtNombre', true, 'clsInputEnabled');
				setEnabled('txtApePat', true, 'clsInputEnabled');
				setEnabled('txtApeMat', true, 'clsInputEnabled');
				setEnabled('txtRazonSocial', true, 'clsInputEnabled');
				habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', true);

				setValue('txtNombre', '');
				setValue('txtApePat', '');
				setValue('txtApeMat', '');
				setValue('txtRazonSocial', '');
				setValue('hidIntentos10', '0');
				document.getElementById('lblCategoriaCliente').innerHTML = '';

				trDetalleCliente.style.display = 'none';
				
				//consolidado 12122014
				trDetalleLinea.style.display = 'none';
				trDatosLineaCAC.style.display = 'none';	
		     	trDatosLineaDAC.style.display = 'none';
				trDetalleFacturacion.style.display = 'none';
				trDetalleAcuerdoLinea.style.display = 'none';
				//trDetalleVenta.style.display = 'none';
				//consolidado 12122014
				
				trConsultarDC.style.display = 'none';
				trDetalleRUC.style.display = 'none';
				document.getElementById('trDetalleRepLegal').style.display = 'none';
				trDetalleDNI_1.style.display = '';
				trDetalleDNI_2.style.display = '';
				
			}

			function inicializarPanelRepresentante()
			{
				trRepresentante.style.display = 'none'; 
			}

			function inicializarPanelCondicionVenta()
			{
				var ddlOferta = document.getElementById('ddlOferta');
				ddlOferta.selectedIndex = 0;
				document.getElementById('ddlModalidad').selectedIndex = 0;

				setValue('hidCadenaDetalle', '');
				self.frames["ifraCondicionesVenta"].window.location.reload();

				document.getElementById('txtLCDisponiblexProd').value = '';
				document.getElementById('tdMovil').style.display = '';
				document.getElementById('tdBAM').style.display = '';
				
				if (isVisible('tdMovil')) { setEnabled('tdMovil', true, ''); }
				if (isVisible('tdBAM')) { setEnabled('tdBAM', true, ''); }
				
				setEnabled('ddlTipoOperacion', true, '');
				setEnabled('ddlOferta', true, '');
				trCondicionVenta.style.display = 'none';
				trCondicionVentaDetalle.style.display = 'none';
				trConsultarDC.style.display = 'none';
				document.getElementById("ddlTipoRenovacion").disabled=false;
				document.getElementById('chkPlanNoVigente').checked = false;				
				
				setValue('hidVigente','');
				
				
				
			}

			function inicializarPanelResultado()
			{
				setValue('txtResultado', '');
				setValue('txtFactorRenovacion', '');
				setValue('txtRiesgo', '');
				setValue('txtLCDisponible', '');
				setValue('txtTipoGarantia', '');
				setValue('txtImporte', '');

				setValue('hidAutonomia', '');
				//setValue('hidFactorRenovacion', '');
				setValue('hidCreditosxCE', '');
				setValue('hidCreditosxDC7', '');
				setValue('hidCreditosxReglas', '');

				document.getElementById('chkPresentaPoderes').checked = false;
				document.getElementById('btnDetalleGarantia').style.display = 'none';
				setValue('hidPoderes', '');
				
				trPresentaPoderes.style.display = 'none';
				//trGarantia.style.display = 'none';
				trGarantia.style.display = '';
				trResultado.style.display = 'none';
				tdLCDisponible.style.display = 'none';		
				tdTxtLCDisponible.style.display = 'none';
			}
			
			function inicializarPanelResVenta()
			{
				trEvaluarResultado.style.display = 'none';
				habilitarBoton('btnEvaluar', 'Evaluar', true);
				trResultadoRVenta.style.display = 'none';
				document.getElementById('txtImei').value = '';
				document.getElementById('txtMaterialImei').value = '';
				document.getElementById('txtArticuloImei').value = '';
				document.getElementById('ddlPrecio').length = 0;
				document.getElementById('txtSerieChip').value = '';
				document.getElementById('lblPlanChip').value = '';
				document.getElementById('txtMaterialICCID').value = '';
				document.getElementById('txtArticuloICCID').value = '';
				
				
				
				document.getElementById('txtClaroClubPuntosUtilizar').value = '';
				document.getElementById('txtDescuentoClaroClub').value = '';
				document.getElementById('lblClaroClubMsgError').value = '';
				document.getElementById('txtPrecioVenta').value = '0';
				document.getElementById('txtTotalAPagar').value = '0';
				trGenerarPedido.style.display = 'none';
				
				//consolidado 27122014
				
				trDetalleVentaChip.style.display = 'none';
				trResultadoRVentaChip.style.display = 'none';
				document.getElementById('txtIniApadece').value = '';
				document.getElementById('txtReintegro').value = '';
				document.getElementById('txtFinApadece').value = '';
				document.getElementById('txtTotalReintgro').value = '';
				document.getElementById('txtReferenciaFact').value = '';
				document.getElementById('txtCorreoElecFact').value = '';
				document.getElementById('txtDistritoFact').value = '';
				document.getElementById('txtDepartamentoFact').value = '';
				document.getElementById('txtDireccionFact').value = '';
				document.getElementById('txtPlanComercial').value = '';
				document.getElementById('txtIMSI').value = '';
				document.getElementById('txtSegmento').value = '';
				document.getElementById('txtLimiteCredito').value = '';
				
				
				trDetalleVentaEquipo.style.display = 'none';
				trProteccionMovil.style.display = 'none'; //PROY-24724-IDEA-28174 
				
				
				tblClaroPuntosDescuento.style.display = 'none';
				tblClaroPuntosDescuento1.style.display = 'none';
				trDetalleDatosVenta.style.display = 'none';
				
				document.getElementById('ddlCodEquipo').selectedIndex = 0;
				document.getElementById('ddlCodChip').selectedIndex = 0;
				
				var ddlListaPrecio = document.getElementById("ddlListaPrecio");
				ddlListaPrecio.length = 0;
				
				var ddlPrecioChips = document.getElementById("ddlPrecioChips");
				ddlPrecioChips.length = 0;
				
				
				
				var cboIMEIArt = document.getElementById("cboIMEIArt");
				cboIMEIArt.length = 0;
				
				var cboICCIDChips = document.getElementById("cboICCIDChip");
				cboICCIDChips.length = 0;
				
				var ddlPrecioChip = document.getElementById("ddlPrecioChip");
				ddlPrecioChip.length = 0;
				
				document.getElementById('ddlTipoRenovacion').selectedIndex = 0;
				//document.getElementById('chkRetenido').checked = false;
				//document.getElementById('chkFidelizado').checked = false;
				
				habilitarBoton('btnDescuentoEquipo', 'Validar Descuento', true);
				
				
				
				document.getElementById('txtCodEquipo').value = '';
				document.getElementById('txtPrecioVentaEquipo').value = '';
				document.getElementById('txtDescuentoEquipo').value = '';
				
				setReadOnly('txtDescuentoEquipo', false, 'clsInputEnable');
				
				document.getElementById('txtCodChip').value = '';
				document.getElementById('txtpreciochip').value = '';
				
				
				//consolidado 27122014
				
				//inicio campañas nuevas 26/11/2015
				document.getElementById('ddlGProducto').selectedIndex = 0;
				setEnabled('ddlGProducto', true, '');
				setEnabled('chkPlanNoVigente', true, '');
				document.getElementById('chkPlanNoVigente').checked = false;
				//fin campañas nuevas 26/11/2015
			}

			function inicializarPanelComentarios()
			{
				setValue('txtComentarioPDV', '');
				setValue('hidComentarioPDV', '');
				trComentario.style.display = 'none';
			}

			function inicializarPanelGrabar()
			{
				setValue('hidCreditosxAsesor', '');
				setValue('hidArchivosEnvioCreditos', '');
				setValue('hidCreditosxNombres', '');
				setValue('hidAdjuntarIngreso', '');
				habilitarBoton('btnGrabarSec', 'Grabar', true);
				habilitarBoton('btnRealizarVenta', 'Realizar Venta', true);
				habilitarBoton('btnEnviarACreditos', 'Enviar a Créditos', true);
				document.getElementById('btnGrabarSec').style.display = 'none';
				document.getElementById('btnRealizarVenta').style.display = 'none';
				document.getElementById('btnEnviarACreditos').style.display = 'none';
			}

			function habilitarControl(bln)
			{

				if (bln)
				{
					if (isVisible('trPuntoVenta')) {
						setEnabled('ddlCanal', true, '');
						setEnabled('ddlPuntoVenta', true, '');
						setEnabled('ddlVendedorSAP', true, '');
					}
					setEnabled('ddlTipoDocumento', true, '');
					setEnabled('txtNroDoc', true, 'clsInputEnabled');
					setEnabled('txtNroLinea', true, 'clsInputEnabled');
					setEnabled('ddlNacionalidad',true,'');//PROY 31636 RENTESEG
				}
				else
				{
					if (isVisible('trPuntoVenta')) {
						setEnabled('ddlCanal', false, '');
						setEnabled('ddlPuntoVenta', false, '');
						setEnabled('ddlVendedorSAP', false, '');
					}
					setEnabled('ddlTipoDocumento', false, '');
					setEnabled('txtNroDoc', false, 'clsInputDisabled');
					setEnabled('txtNroLinea', false, 'clsInputDisabled');
					setEnabled('ddlNacionalidad',false,'');//PROY 31636 RENTESEG
				}
			}

			function getParametroGeneral(idx)
			{
				var valor;
				var lista = getValue('hidListaParametroGeneral').split('|');
				for (var i=0; i < lista.length; i++)
				{
					var col = lista[i].split(';');
					if (col[0] == idx) {
						valor = col[1];
						break;
					}
				}
				return valor;
			}

function cambiarTipoDocumento() {
				document.getElementById('txtNroDoc').value = '';
				document.getElementById('txtNroDoc').maxLength = getMaxLengthDocumento(document.frmPrincipal.ddlTipoDocumento.value);
				setFocus('txtNroDoc');
    //PROY 31636 RENTESEG
    if (getValue('ddlTipoDocumento') == '06') {
        setVisible('ddlNacionalidad', false);
        setVisible('lblNacionalidad', false);
    } else {
        setVisible('ddlNacionalidad', true);
        setVisible('lblNacionalidad', true);
			}

    var strNacionalidadCliente = getValue('hidNacionalidadCliente');
    if (strNacionalidadCliente == "") {
        Anthem_InvokePageMethod('obtenerNacionalidad', [],
							function (response) {
							    var strNacionalidad = response.value;
							    setValue('hidNacionalidadCliente', strNacionalidad);
							    cargarNacionalidad_callback(strNacionalidad);
							}
						);
    } else {
        cargarNacionalidad_callback(strNacionalidadCliente);
			}
    //PROY 31636 RENTESEG
}
//PROY 31636 RENTESEG
function cargarNacionalidad_callback(strNacionalidadCliente) {
    var objddlNacionalidad = document.getElementById('ddlNacionalidad');
    inicializarCombo(objddlNacionalidad);
    var arrClienteNacionalidad = strNacionalidadCliente.split('|');
    var objddlNacionalidad = document.getElementById('ddlNacionalidad');
    var strTipoDoc = getValue('ddlTipoDocumento');
    var strNacionalidadCliente = getValue('hidNacionalidadCliente');

    if (strTipoDoc == '01' || strTipoDoc == '06' || strTipoDoc == '' || strTipoDoc == '00') {
        for (var i = 0; i < arrClienteNacionalidad.length; i++) {
            var arrNacionalidad = arrClienteNacionalidad[i].split(';');
            cargarCombo(objddlNacionalidad, arrNacionalidad[0], arrNacionalidad[1]);
        }
        if (strTipoDoc == '01') {
            setValue('ddlNacionalidad', '154')
            setEnabled('ddlNacionalidad', false, '')
        }
    } else {
        for (var i = 0; i < arrClienteNacionalidad.length; i++) {
            var arrNacionalidad = arrClienteNacionalidad[i].split(';');
            if (arrNacionalidad[0] != '154') {
                cargarCombo(objddlNacionalidad, arrNacionalidad[0], arrNacionalidad[1]);
            }
        }
        setEnabled('ddlNacionalidad', true, '');
    }
}
//PROY 31636 RENTESEG

			var codDocMigratoriosYPasaporte = null;
			
			function getMaxLengthDocumento(tipoDoc)
			{
				if(codDocMigratoriosYPasaporte == null){
					codDocMigratoriosYPasaporte = getValue('hidCodigoDocMigraYPasaporte') == '' ? Key_codigoDocMigraYPasaporte : getValue('hidCodigoDocMigraYPasaporte');
				}
				var nroCaracter;
				if(tipoDoc !== '' || tipoDoc !== '00' ){
					
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>')
					nroCaracter = 8;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") %>')
					nroCaracter = 9;
				if (tipoDoc == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					nroCaracter = 11;
			    if (tipoDoc == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC10") %>')
					nroCaracter = 11;
				if(codDocMigratoriosYPasaporte.indexOf(tipoDoc) >-1) /*PROY-31636-RENTESEG*/
					nroCaracter = 12;
				return nroCaracter;
				}else{
					return nroCaracter = 0;
				}
			}

			function cambiarCanal()
			{
				var strCodCanal = getValue('ddlCanal');
				var ddlPuntoVenta = document.getElementById('ddlPuntoVenta');

				if (strCodCanal == '')
				{
					if (getValue('hidPerfil_149') == 'S') 
					{ 
					document.getElementById("ddlPuntoVenta").options.length = 0;
					inicializarCombo(ddlPuntoVenta);
					return ;
				}
				}
				//INI PROY 31636 RENTESEG 
					var strTipoDoc = getValue('hidTodoTipoDoc');
					var arrTipoDocumentos = strTipoDoc.split('|');
					var strTipoCanal = getValue('ddlCanal');
					var strCadenaFinal = "";
					var TipoDocPermitidoPostCAC = getValue('hidTipoDocPermitidoPostCAC') == '' ? Key_tipoDocPermitidoPostCAC : getValue('hidTipoDocPermitidoPostCAC');
					var TipoDocPermitidoPostDAC = getValue('hidTipoDocPermitidoPostDAC') == '' ? Key_tipoDocPermitidoPostDAC : getValue('hidTipoDocPermitidoPostDAC');
					var TipoDocPermitidoPostCAD = getValue('hidTipoDocPermitidoPostCAD') == '' ? Key_tipoDocPermitidoPostCAD : getValue('hidTipoDocPermitidoPostCAD');
			
					if(strTipoDoc != ""){
						for (var i = 0; i < arrTipoDocumentos.length; i++){
							if(strTipoCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
								if(TipoDocPermitidoPostCAC.indexOf(arrTipoDocumentos[i].split(';')[0]) > -1){
									strCadenaFinal += (strCadenaFinal == "") ? arrTipoDocumentos[i] : "|" + arrTipoDocumentos[i];
								}
							}
							else if(strTipoCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoDAC") %>'){
								if(TipoDocPermitidoPostDAC.indexOf(arrTipoDocumentos[i].split(";")[0]) > -1){
									strCadenaFinal += (strCadenaFinal=="") ? arrTipoDocumentos[i]: "|" + arrTipoDocumentos[i];
								}
							}
							else if(strTipoCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCRN") %>'){
								if(TipoDocPermitidoPostCAD.indexOf(arrTipoDocumentos[i].split(";")[0]) > -1){
									strCadenaFinal += (strCadenaFinal=="") ? arrTipoDocumentos[i]: "|" + arrTipoDocumentos[i];
								}
							}
							
							if (arrTipoDocumentos[i].split(";")[0] == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoDNI") %>' ||
								arrTipoDocumentos[i].split(";")[0] == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>' ||
								arrTipoDocumentos[i].split(";")[0] == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoCEX") %>') {
								strCadenaFinal += (strCadenaFinal=="") ? arrTipoDocumentos[i]: "|" + arrTipoDocumentos[i];
							}
						}
			
						var ddlTipoDocumento = document.getElementById('ddlTipoDocumento');
						inicializarCombo(ddlTipoDocumento);
						var arrTipoDocFinal = strCadenaFinal.split('|');
						for(var j = 0; j<arrTipoDocFinal.length; j++){
							var arrOption = arrTipoDocFinal[j].split(';');
							cargarCombo(ddlTipoDocumento,arrOption[0],arrOption[1]);
						}
					}
			
				
				//INI PROY 31636 RENTESEG 
				//#########################
				trCargandoPuntoVenta.style.display ='block';
				document.getElementById('ddlCanal').disabled = true;
				document.getElementById('ddlPuntoVenta').disabled = true;
				document.getElementById('ddlVendedorSAP').disabled = true;
				document.getElementById('ddlTipoDocumento').disabled = true;
				document.getElementById('txtNroDoc').disabled = true;
				document.getElementById('txtNroLinea').disabled = true;
				document.getElementById('btnvalidarClaro').disabled = true;
				//#########################	
				
				//666
				setValue('hidTipoCanal',strCodCanal)
								
				inicializarCombo(ddlPuntoVenta);
				
				if (strCodCanal != '' && getValue('hidAccion')!= 'Grabar' && getValue('hidAccion')!= 'GenerarPedido')
				{
					Anthem_InvokePageMethod('CargarComboPuntoVenta', [strCodCanal], CallBack_CargarComboPuntoVenta);
					Anthem_InvokePageMethod('MostrarCheckCartaPoder',[strCodCanal], CallBack_MostrarCheckCartaPoder);
				}	
	                        else
				{
					trCargandoPuntoVenta.style.display ='none';
					document.getElementById('ddlCanal').disabled = false;
					document.getElementById('ddlPuntoVenta').disabled = false;
					document.getElementById('ddlVendedorSAP').disabled = false;
					document.getElementById('ddlTipoDocumento').disabled = false;
					document.getElementById('txtNroDoc').disabled = false;
					document.getElementById('txtNroLinea').disabled = false;
					document.getElementById('btnvalidarClaro').disabled = false;
				}
			}



var cartaPoder = '0';

		function CallBack_MostrarCheckCartaPoder(response) {
    cartaPoder = response.value;
    document.getElementById('checkCartaPoder').checked = false;
    document.getElementById('hidCheckCartaPoder').value = 'N';
    if (cartaPoder == '1') {
        trCartaPoder.style.display = '';
    } else {
        trCartaPoder.style.display = 'none';
    }
}
        
         function cambiarCartaPoder(chk) {
            if (chk.checked) {
                document.getElementById('hidCheckCartaPoder').value = 'S';
            } else {
                document.getElementById('hidCheckCartaPoder').value = 'N';
        }
			}

			function CallBack_CargarComboPuntoVenta(result)
			{
				var arrPuntoVenta = result.value.split('|');
				var ddlPuntoVenta = document.getElementById('ddlPuntoVenta');
				
				for (var i=0; i < arrPuntoVenta.length; i++)
				{
					var colPuntoVenta = arrPuntoVenta[i].split(';');
					cargarCombo(ddlPuntoVenta, colPuntoVenta[0], colPuntoVenta[1] + " - " + colPuntoVenta[0]);
				}
				
				if (getValue('hidPerfil_149') != 'S')
				{
					document.getElementById('frmPrincipal').ddlPuntoVenta.selectedIndex = 1;
				}
				
				//#########################
				trCargandoPuntoVenta.style.display ='none';
				document.getElementById('ddlCanal').disabled = false;
				document.getElementById('ddlPuntoVenta').disabled = false;
				document.getElementById('ddlVendedorSAP').disabled = false;
				document.getElementById('ddlTipoDocumento').disabled = false;
				document.getElementById('txtNroDoc').disabled = false;
				document.getElementById('txtNroLinea').disabled = false;
				document.getElementById('btnvalidarClaro').disabled = false;
				//#########################	
			}

			function cambiarPuntoVenta()
			{
				if (getValue('hidPerfil_149') == 'S')
					document.getElementById('hidBLVendedor').value = '';
				
				
				//DNI Vendedor - Se mantiene funcionalidad anterior
				var ListaBL = getValue('hidListaBlackList');
				if (ListaBL.length > 0) {
					var arrayBL = ListaBL.split('|');
					var SelUsr = getValue('ddlCanal') + "-" + getValue('ddlPuntoVenta').split('-')[0];
					var iExiste = 0;
					if (arrayBL.length>0)
					{
						for (i=0;i<arrayBL.length;i++)
						{
							// Si la columna pdv tiene todos...
							if (arrayBL[i].split('-')[1] == '0') {
								// Valido unicamente por el canal...
								if (arrayBL[i].split('-')[0] == getValue('ddlCanal'))
									iExiste = iExiste + 1;
							}
							else {
								// Sino valido por el canal y el pdv...
								if (arrayBL[i] == SelUsr)
									iExiste = iExiste + 1;
							}
						}
					}
				}
				if (iExiste > 0)
					setValue('hidBLVendedor', 'S');

				
				cargarListaVendedores()
			}

			function validarClaro()
			{
				document.getElementById('lblMensaje').innerHTML = '';
				
				setValue('hidDatosBRMS',""); //PROY-29123				
				if (isVisible('trPuntoVenta')) {
					if (!validarControl('ddlCanal', '', 'Seleccione el Canal.')) return false;
					if (!validarControl('ddlPuntoVenta', '', 'Seleccione el Punto de Venta.')) return false;
				}
				
				if (getValue('ddlTipoDocumento') == "00" || getValue('ddlTipoDocumento') == '') {
					alert("Seleccione Tipo de Documento.");
					setFocus('ddlTipoDocumento');
					return;
				}
				var codTipoDocumento = getValue('ddlTipoDocumento');
				var longitud = getValue('txtNroDoc').length;
				
				if(Key_codigoDocMigraYPasaporte.indexOf(codTipoDocumento) >-1)
				{
					if(longitud < Key_minLengthDocMigratorios)
					{
						alert("Ingresar número de documento válido.");
						return false;
					}
				}
				else if (getValue('txtNroDoc').length != getMaxLengthDocumento(getValue('ddlTipoDocumento'))) { //CAMBIO PROY 31636 RENTESEG
					setFocus('txtNroDoc');
					alert("Ingresar número de documento válido.");
					return false;
				}
				
				if(isVisible('ddlNacionalidad') && (getValue('ddlNacionalidad')=='-1' || getValue('ddlNacionalidad')=='')){
					alert("Seleccione Nacionalidad");
						return false;
				}
				//PROY 31636
				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
				{
					if (!ValidaRUC('document.frmPrincipal.txtNroDoc','El campo Nro Documento',false)) return false;
				}
							
				// Validar nro Línea
				if (Trim(getValue('txtNroLinea')) == '') {
					alert("Ingrese Numero de Linea");
					setFocus('txtNroLinea');
					return false;
				}
				
				if ( getValue('txtNroLinea').length != 9) {
					alert("Numero de Línea no válida.");
					setFocus('txtNroLinea');
					return false;
				}
				
				if (isVisible('trPuntoVenta')) {
					if (getValue('ddlVendedorSAP') == "00" || getValue('ddlVendedorSAP') == '') {
						alert("Seleccione Vendedor.");
						setFocus('ddlVendedorSAP');
						return;
					}
				}
				
				//Obtener Datos Punto de Venta
				var strCodCanal = getValue('ddlCanal');
				var ddlPuntoVenta = document.getElementById('ddlPuntoVenta');
				if (strCodCanal != '')
				{
					Anthem_InvokePageMethod('CargarComboPuntoVenta', [strCodCanal], CallBack_validarClaro);
				}
			}

			function CallBack_validarClaro(result)
			{
				var arrPuntoVenta = result.value.split('|');
				var ddlPuntoVenta = document.getElementById('ddlPuntoVenta');
				
				for (var i=0; i < arrPuntoVenta.length; i++)
				{
					var colPuntoVenta = arrPuntoVenta[i].split(';');
					if (colPuntoVenta[0] == getValue('ddlPuntoVenta'))
					{
						setValue('hidOficina', colPuntoVenta[0])
						setValue('hidOficinaActual', colPuntoVenta)
						break;
					}
				}
				
				var Oficina = getValue('hidOficina');
				var OficinaActual = getValue('hidOficinaActual');
				
				//Guardar Info
				setValue('hidNroDocumento', getValue('txtNroDoc'));
				var numeroDoc = getValue('hidNroDocumento');
				setValue('hidTipoDocumento', getValue('ddlTipoDocumento'));
				setValue('hidNroLinea', getValue('txtNroLinea'))

				//Deshabilitar Controles
				habilitarControl(false);
				setEnabled('btnvalidarClaro', false, '');	

				//Excepción DC Tipo 7
				var strCanal = getValue('ddlCanal');
				setValue('hidCanal', getValue('ddlCanal'))
				var codParametroCanal = '<%= ConfigurationSettings.AppSettings("COD_GRUPO_CANAL_NO_ERROR_TIPO_7") %>';
				var strCanalExcepcionDC7 = getParametroGeneral(codParametroCanal);

				var blnCondicionExcepcionDC7 = (strCanalExcepcionDC7.indexOf(strCanal) > -1);

				var codParametroDoc = '<%= ConfigurationSettings.AppSettings("COD_GRUPO_DOC_NO_ERROR_TIPO_7") %>';
				var strTipoDocExcepcionDC7 = getParametroGeneral(codParametroDoc);
				var strTipoDocClie = getValue('ddlTipoDocumento');

				if (blnCondicionExcepcionDC7 && (strTipoDocExcepcionDC7.indexOf(strTipoDocClie) == -1))
					blnCondicionExcepcionDC7 = false;

				if (blnCondicionExcepcionDC7)
					document.getElementById('hidFlagExcepcionDC7').value = 'S';
					
				//validacion de titularidad de linea
				validarTitulridad();
			}

			function validarBlackListComision()
			{
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strPerfil149=' + getValue('hidPerfil_149');
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strNroDoc=' + getValue('txtNroDoc');
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strTipoOficina=' + getValue('hidOficinaActual').split(',')[2];
				
				url += '&strMetodo=' + 'ValidarBlacklistComision';
				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function consultarBlacklist(blnBlackComision)
			{
				if (blnBlackComision == 'S')
				{
				
					var MsjBlackComision = alert(MsjValidarBlackList);
				
					inicializarDatosInicial();
					inicializarPanelDatosInicial();
					return;
				}
				consultarBSCS();
			}

			function verDetalleLinea()
			{
				var w = 900;
				var h = 540;
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
				var url = 'sisact_pop_detalle_linea.aspx?';
				url += 'nroDoc=' + getValue('txtNroDoc') + '&tipoDoc=' + getValue('ddlTipoDocumento') + '&pageOpen=S' + '&nrolinea=' + getValue('txtNroLinea');
				window.open( url, '_blank', opciones);
			}

			function consultarBSCS()
			{
				var url = 'sisact_pop_detalle_linea.aspx?';
				url += 'nroDoc=' + getValue('txtNroDoc') + '&tipoDoc=' + getValue('ddlTipoDocumento') + '&pageOpen=C' + '&nrolinea=' + getValue('txtNroLinea') 
				//Inicio Renovacion por Bloqueo JAZ
						+ '&CanalActual=' + getValue('ddlCanal') + '&CoId='+ getValue('hidCO');
				//Fin Renovacion por Bloqueo JAZ
				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornoConsultaBSCS(blnBlackList, lblDeudaBloqueo, lblCategoriaCliente, blnEvaluarMovil, blnClienteExiste, strCalificacionPago)
			{
				//Inicio Renovacion por Bloqueo JAZ
				
				if (getValue('hidCalificacionPago')==null || getValue('hidCalificacionPago')=='')
				{
					setValue('hidCalificacionPago', strCalificacionPago);
				}
												
				trDetalleValidacionBloqueo.style.display='none';
				//Fin Renovacion por Bloqueo JAZ			

				if (blnBlackList == 'S' && consCPValorEspecial != getValue('hidCalificacionPago')) {
					alert("Cliente se encuentra en blacklist de clientes RUC");
					inicializarDatosInicial();
					inicializarPanelDatosInicial();
					return;
				}
				//Deuda y/o Bloqueo
				if(Trim(getValue('hidMsgTitularidad')).length > 0 && consCPValorEspecial != getValue('hidCalificacionPago'))
				{
					document.getElementById('lblMensaje').innerHTML = getValue('hidMsgTitularidad') + " <br />" + lblDeudaBloqueo;
					if (getValue('hidVerDetalleLinea') == 'S')
						document.getElementById('btnDetalleLinea').style.display = '';
						
					return;
				}
				
				if (blnEvaluarMovil.toUpperCase() == 'N' && consCPValorEspecial != getValue('hidCalificacionPago'))
				{
					document.getElementById('lblMensaje').innerHTML = getValue('hidMsgTitularidad') + " <br />" + lblDeudaBloqueo;
					if (getValue('hidVerDetalleLinea') == 'S')
						document.getElementById('btnDetalleLinea').style.display = '';
						
					return;
				}
				else {
					document.getElementById('lblMensaje').innerHTML = getValue('hidMsgTitularidad') + " <br />" +  lblDeudaBloqueo;
					//Inicio Renovacion por Bloqueo JAZ
					if ( lblDeudaBloqueo.length > 0 && consCPValorEspecial != getValue('hidCalificacionPago'))
					{
						document.getElementById('btnDetalleLinea').style.display = '';
							
						return;
					}
					//Fin Renovacion por Bloqueo JAZ
				}
				
				//Clasificación del Cliente
				document.getElementById('lblCategoriaCliente').innerHTML = lblCategoriaCliente;
				//Validación Evaluar Planes Fijo
				if (getValue('hidTienePortabilidad') == 'S' && blnEvaluarMovil != 'S') return;

				//Guardar Info BSCS
				setValue('hidEvaluarMovil', blnEvaluarMovil);
				if (getValue('hidVerDetalleLinea') == 'S')
					document.getElementById('btnDetalleLinea').style.display = '';
				var serv = getValue('hidserviciosactuales');
				 var retor='';
				 var salto='\n\r';
				for (i=1; i<= serv.split('+').length -1; i++ ){
				retor=retor + serv.split('+')[i] + salto;
				}
				document.getElementById('txtservadic').value=retor;
				document.getElementById('txtservadicdac').value=retor;
				var plan = document.getElementById('txtplanactual').value;
				//Mostrar Productos Configurados
				mostrarTabxOferta();

				//Cargar Tipo Operación
				asignarTipoOperacion();
				
				if (blnClienteExiste != 'N') {
				
					if (getValue('hidTienePortabilidad') != 'S') {
						if (getValue('hidTieneSECPendiente') == 'S'){
							
							if (getValue('ddlCanal') == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
								buscarSEC();
							}else{
								alert('El Cliente tiene una SEC de Renovación pendiente');//buscarSEC();
								//alert('El Cliente tiene una SEC de Renovación pendiente de pago');
							retornarConsultaSEC('');
						}
						}
						else{
							retornarConsultaSEC('');
						}
					} 
					else
						retornarConsultaSEC('');
					
				}
				else {
					alert("Cliente no existe!");
					return;
				}
					
			}

			function buscarSEC()
			{
				var w = 800;
				var h = 450;
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
				var url = 'sisact_pop_consulta_sec.aspx?';
				url += 'tipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&nroDocumento=' + getValue('txtNroDoc');
				window.open( url, '_blank',opciones);
			}

			function retornarConsultaSEC(nroSec)
			{
			    
				
				//inicio plan no vigente 30102015
			    
				var PlanVigente  = getValue('hidVigente');
				
				//fin plan no vigente 30102015
				
				document.getElementById('txtplanactual').value = getValue('hidPlanAct');							
				document.getElementById('txtplanactualdac').value = getValue('hidPlanAct');						
				document.getElementById('txtplanactualRUC').value = getValue('hidPlanAct');
				document.getElementById('hidPlanActual').value=getValue('txtplancomercial');
				//document.getElementById('txtplancomercial').value=getValue('hidPlanActual');
				
				

			    //jmori
			     var cfsiga = document.getElementById('hiCFSiga').value;
				if(cfsiga != ''){
					document.getElementById('txtcargofijo').value= cfsiga;
				}
				 //end jmori
				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
				{
					
					setEnabled('txtRazonSocial', false, 'clsInputDisabled');
					setEnabled('txtplanactualRUC', false, 'clsInputDisabled');
					setEnabled('txtRepLegal', false, 'clsInputDisabled');
					
					//consolidado 11122014
					setEnabled('txtPlanComercial', false, 'clsInputDisabled');
					setEnabled('txtSegmento', false, 'clsInputDisabled');
					setEnabled('txtIMSI', false, 'clsInputDisabled');
					setEnabled('txtLimiteCredito', false, 'clsInputDisabled');
					setEnabled('txtDireccionFact', false, 'clsInputDisabled');
					setEnabled('txtDepartamentoFact', false, 'clsInputDisabled');
					setEnabled('txtProvinciaFact', false, 'clsInputDisabled');
					setEnabled('txtDistritoFact', false, 'clsInputDisabled');
					setEnabled('txtCorreoElecFact', false, 'clsInputDisabled');
					setEnabled('txtReferenciaFact', false, 'clsInputDisabled');
					setEnabled('txtIniApadece', false, 'clsInputDisabled');
					setEnabled('txtReintegro', false, 'clsInputDisabled');
					setEnabled('txtFinApadece', false, 'clsInputDisabled');
					setEnabled('txtTotalReintgro', false, 'clsInputDisabled');
					setEnabled('txtNroLineaD', false, 'clsInputDisabled');
					//consolidado 11122014
					
					setEnabled('txtplanactual', false, 'clsInputDisabled');
				} 
				else {
					
					/*
					trDetalleDNI_1.style.display = '';
					trDetalleDNI_2.style.display = '';
					trDetalleRUC.style.display = 'none';
					document.getElementById('trDetalleRepLegal').style.display = 'none';
					trDetalleRUC_2.style.display = 'none';
					*/
					
					setEnabled('txtNombre', false, 'clsInputDisabled');
					setEnabled('txtApePat', false, 'clsInputDisabled');
					setEnabled('txtApeMat', false, 'clsInputDisabled');
					setEnabled('txtplanactual', false, 'clsInputDisabled');
					
					//consolidado 11122014
					setEnabled('txtPlanComercial', false, 'clsInputDisabled');
					setEnabled('txtSegmento', false, 'clsInputDisabled');
					setEnabled('txtIMSI', false, 'clsInputDisabled');
					setEnabled('txtLimiteCredito', false, 'clsInputDisabled');
					setEnabled('txtDireccionFact', false, 'clsInputDisabled');
					setEnabled('txtDepartamentoFact', false, 'clsInputDisabled');
					setEnabled('txtProvinciaFact', false, 'clsInputDisabled');
					setEnabled('txtDistritoFact', false, 'clsInputDisabled');
					setEnabled('txtCorreoElecFact', false, 'clsInputDisabled');
					setEnabled('txtReferenciaFact', false, 'clsInputDisabled');
					setEnabled('txtIniApadece', false, 'clsInputDisabled');
					setEnabled('txtReintegro', false, 'clsInputDisabled');
					setEnabled('txtFinApadece', false, 'clsInputDisabled');
					setEnabled('txtTotalReintgro', false, 'clsInputDisabled');
					setEnabled('txtNroLineaD', false, 'clsInputDisabled');
					//consolidado 11122014
				}
				
				setEnabled('txtplanactualdac', false, 'clsInputDisabled');
				setEnabled('txtcargofijo', false, 'clsInputDisabled');
				setEnabled('txtservadic', false, 'clsInputDisabled');
				setEnabled('txtcicloFacturacion', false, 'clsInputDisabled');
				setEnabled('txtcargofijodac', false, 'clsInputDisabled');
				setEnabled('txtservadicdac', false, 'clsInputDisabled');
				setEnabled('txtcicloFacturaciondac', false, 'clsInputDisabled');
				//trDetalleCliente.style.display = '';
				
				//inicio whzr 11122014
//gaa20170823
				var reintegro =document.getElementById('txtReintegro').value;
				msjreint= "El Monto de Reintegro del Equipo es S/." + reintegro;
//fin gaa20170823
				var strCanal = getValue('ddlCanal');
				if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
					
					var flgapp = document.getElementById('hidFlagRenovacionAdelantada').value;
					
					if(flgapp == 'true'){
								
							if(getValue('hidMesesPorVencer') > 0)
							{
								if (confirm("¿Usted realizará una renovación anticipada, Desea Continuar?"))
								{
									if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
									{
									   trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = 'none';
										trDetalleDNI_2.style.display = 'none';
										trDetalleRUC.style.display = '';
										document.getElementById('trDetalleRepLegal').style.display = '';
										trDetalleRUC_2.style.display = '';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
										trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
										
									}
									else{
									   trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = '';
										trDetalleDNI_2.style.display = '';
										trDetalleRUC.style.display = 'none';
										document.getElementById('trDetalleRepLegal').style.display = 'none';
										trDetalleRUC_2.style.display = 'none';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
										trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
									}
									
									
									//jmori add
//gaa20170823
									//var reintegro =document.getElementById('txtReintegro').value;
//fin gaa20170823
									var canal = document.getElementById('hidCanal').value;
									
									//consolidado 28012015
									
									var errorApadece = '<%= ConfigurationSettings.AppSettings("msjErrorRevPoAPEDECE") %>';
								   var MesesMinimoCEDE = '<%= ConfigurationSettings.AppSettings("consMesesMinimoCEDE") %>';	
									//consolidado 28012015 
									
									
									if(getValue('ddlCanal') == '01')
									{
										msjreint= "El Monto de Reintegro del Equipo es S/." + reintegro;
									}
									//end jmori
																		
									//Inicio Renovacion Anticipada 12																		
									var msjExcedeRenoAnticipada = '<%= ConfigurationSettings.AppSettings("constMsjExcedeMaxRenoAnticipada") %>';																										
									if(getValue('hdAutoriza') == "-1"){
										solicitaAutorizacion('Aprobacion Renovacion Adelantada',getValue('hidMesesPorVencer'),'2');
										if(getValue('hidCerrarValid') == "1"){
											if (!confirm(msjExcedeRenoAnticipada)) {											
												nuevaEvaluacion();	
											}
										}
											f_MostrarMsgSeguro();   //'PROY-24724-IDEA-28174
										
									} else {//if (parseFloat(getValue("hidDiasPendientes")) > parseFloat(getValue('hidMesesMaxASMaxDias'))) {									
										//Si excedió el máximo permitido a renovar
										if (!confirm(msjExcedeRenoAnticipada)) {											
											nuevaEvaluacion();	
										} else {
											//Obs: No implementado formulario de autorizacion
											//solicitaAutorizacion('Aprobacion Renovacion Adelantada',getValue('hidMesesPorVencer'),'2');
											f_MostrarMsgSeguro();   //'PROY-24724-IDEA-28174 
										}
									}
									//Fin Renovacion anticipada 12
									//'PROY-24724-IDEA-28174 - INICIO
									//else {
										   
									//}
									//'PROY-24724-IDEA-28174 - FIN

								}
								else
								{
								  nuevaEvaluacion();	
								}
							}
							else
							{
								//jmori add
								document.getElementById('hidFlagReintegro').value='false';
								document.getElementById('hidFlagExonerarReintegro').value='true';
								
									if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
									{
									   trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = 'none';
										trDetalleDNI_2.style.display = 'none';
										trDetalleRUC.style.display = '';
										document.getElementById('trDetalleRepLegal').style.display = '';
										trDetalleRUC_2.style.display = '';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
										trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
									}
									else{
									   trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = '';
										trDetalleDNI_2.style.display = '';
										trDetalleRUC.style.display = 'none';
										document.getElementById('trDetalleRepLegal').style.display = 'none';
										trDetalleRUC_2.style.display = 'none';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
										trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
									}
								
								//end jmori
								f_MostrarMsgSeguro();   //'PROY-24724-IDEA-28174 
							}
					}else{
							//jmori add
							document.getElementById('hidFlagReintegro').value='false';
							document.getElementById('hidFlagExonerarReintegro').value='true';
							
				
								if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
									{
				trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = 'none';
										trDetalleDNI_2.style.display = 'none';
										trDetalleRUC.style.display = '';
										document.getElementById('trDetalleRepLegal').style.display = '';
										trDetalleRUC_2.style.display = '';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
				trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
			}
									else{
									   trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = '';
										trDetalleDNI_2.style.display = '';
										trDetalleRUC.style.display = 'none';
										document.getElementById('trDetalleRepLegal').style.display = 'none';
										trDetalleRUC_2.style.display = 'none';
										trDetalleLinea.style.display = '';
										trDatosLineaCAC.style.display = '';
										trDetalleFacturacion.style.display = '';
										trDetalleAcuerdoLinea.style.display = '';
										tdRetFideCAC.style.display = '';
										tdRetFideCAC1.style.display = '';
										trConsultarDC.style.display = '';
										
										if (PlanVigente == '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>'){
											tdPlanNoVigente.style.display = 'block';
											tdPlanNoVigente1.style.display = 'block';
										}
									}
							
							//end jmori
							
							f_MostrarMsgSeguro();  //'PROY-24724-IDEA-28174 
					} 
				}else{
					//jmori add
					document.getElementById('hidFlagReintegro').value='false';
					document.getElementById('hidFlagExonerarReintegro').value='true';
					//end jmori
				
					//trDetalleLinea.style.display = '';
					//trDatosLineaDAC.style.display = '';
					//trDetalleCicloFac.style.display = '';
					
					                if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
									{
									    
									    trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = 'none';
										trDetalleDNI_2.style.display = 'none';
										trDetalleRUC.style.display = '';
										document.getElementById('trDetalleRepLegal').style.display = '';
										trDetalleRUC_2.style.display = '';
										trDetalleLinea.style.display = '';
										trDatosLineaDAC.style.display = '';
										trConsultarDC.style.display = '';
									}
									else{
									    trDetalleCliente.style.display = '';
									    trDetalleDNI_1.style.display = '';
										trDetalleDNI_2.style.display = '';
										trDetalleRUC.style.display = 'none';
										document.getElementById('trDetalleRepLegal').style.display = 'none';
										trDetalleRUC_2.style.display = 'none';
										trDetalleLinea.style.display = '';
										trDatosLineaDAC.style.display = '';
										trConsultarDC.style.display = '';
										
									}
					
				}
				//fin whzr 11122014
				//trConsultarDC.style.display = '';

			    //ECM s8 mostrar linea
			    //mostrarPanelLineas3G();

			    //FVERGARA  .:Inicio:.  
			    //Implementacion del Activador para Consultas 3G    Date: 18/08/2017
			    var strSwicht_3G = '<%= ConfigurationSettings.AppSettings("Swicht_3G") %>';                                          
			    if (strSwicht_3G == '1')
			    {                                    
				//ECM s8 mostrar linea
				mostrarPanelLineas3G();
			}
			    //.:Fin:.

			}

			//'PROY-24724-IDEA-28174 - INICIO -Parametro
			function f_MostrarMsgSeguro()   
			{
				var strValidadProtMovil = getValue('hidValidadProtMovil');		
				setValue('hidContPopPupPM','0'); 
				setValue('hidContAlertPM','0');
															
				if (strValidadProtMovil == '2')
						{
						  var msgPM=vMsjPMOfrecerSeguro;
						alert(msgPM);
				}	
			}
			//'PROY-24724-IDEA-28174 - FIN -Parametro

			function btningcondventa()
			{
				
				habilitarBoton('btnConsultaDC', 'Procesando...', false);
				trCondicionVenta.style.display = '';
				trCondicionVentaDetalle.style.display = '';
				setEnabled('btnAgregarPlan', true, 'Boton');
				
				
				//Inicio Renovacion anticipada JAZ				
				var nMaxMesesARenovar = parseInt(getValue('hidMesesMaxASMax'));
				var nMesPorVencer = parseInt(getValue('hidMesesPorVencer'));
								
				if (nMesPorVencer > nMaxMesesARenovar ) {
					var sCodTipRenoRegular = '<%= ConfigurationSettings.AppSettings("constCodTipoRenovRegular") %>';
					setValue('ddlTipoRenovacion', sCodTipRenoRegular);
					setEnabled('ddlTipoRenovacion', false, '');
					
				} else {					
					setEnabled('ddlTipoRenovacion', true, '');
				}				
				//Fin Renovacion anticipada JAZ
				
				//Inicio Modificacion Plan Vigente JAZ
				var strCanalActual = getValue('ddlCanal');
				var strCanalesPermitidos = '<%= ConfigurationSettings.AppSettings("constCanalesPermitidosPlanNoVig") %>';
				if (EsCanalPermitido(strCanalActual,strCanalesPermitidos)){
															
					if(getValue('hidVigente') == '<%= ConfigurationSettings.AppSettings("consCodPlanVigente") %>') {
						document.getElementById("tdPlanNoVigente").style.display="block";
						document.getElementById("tdPlanNoVigente1").style.display="block";
					}
					
				} else {
					document.getElementById("tdPlanNoVigente").style.display="none";
					document.getElementById("tdPlanNoVigente1").style.display="none";					
				}
				//Fin Modificacion Plan Vigente JAZ
																								
				setValue('ddlOferta','01');
				//gaa20160526
				var ofertaLinea = getValue('hidOfertaLinea');
				if (ofertaLinea.length > 0){
					setValue('ddlOferta', ofertaLinea);					
				}
				setEnabled('ddlOferta', false, '');
				//fin gaa20160526
//gaa20170823
				if (getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>')
				{
					var sCodTipRenoRegular = '<%= ConfigurationSettings.AppSettings("constCodTipoRenovRegular") %>';
					setValue('ddlTipoRenovacion', sCodTipRenoRegular);
				}
//fin gaa20170823											
				cambiarTipoOferta();
				
			}
			
			//PROY-29123
			function consultarClienteBRMS() {
				document.getElementById('imgCuotasBRMS').style.display = "inline";
			    //variables JSON para el Storage
				var objCuotas = { cuota: [] };
				var objStorageJson;
				var objCuotaJson;
				
				//Variables para obtener datos del JSON
				var cuotas = 0;
				var monto = 0.0;
				var mensajeCuotas = "";
            
				var tipoDoc = getValue('ddlTipoDocumento');
				document.getElementById('lblCuotas').innerHTML = '';

					
				var nroDocumento = getValue('txtNroDoc');
				var strCanal = getValue('ddlCanal');
				
				//Valida y Crea localStorage
				if (!getValue('hidDatosBRMS') || getValue('hidDatosBRMS') == null || getValue('hidDatosBRMS') == "") {
					setValue('hidDatosBRMS', JSON.stringify(objCuotas));
                }
                
                
					if (nroDocumento && nroDocumento != '') {
						objStorageJson = JSON.parse(getValue('hidDatosBRMS'));
					
					
						for (var i in objStorageJson.cuota) {
						
							if (objStorageJson.cuota[i].operacion == getValue('ddlTipoOperacion')) {
								if (objStorageJson.cuota[i].msjbrms == "") {
									objStorageJson.cuota.splice(i,1);
									setValue('hidDatosBRMS', JSON.stringify(objStorageJson));
								}
								else 
								objCuotaJson = objStorageJson.cuota[i];
							}
						}	
						
						if (objCuotaJson) {
							cuotas = parseInt(objCuotaJson.cuotamax);
							mont = parseFloat(objCuotaJson.topemax);
							mensajeCuotas = objCuotaJson.msjbrms;

							if (mensajeCuotas && mensajeCuotas != "" && mensajeCuotas == "SI") {
								document.getElementById('lblCuotas').innerHTML = 'Cuotas: Max. ' + cuotas + ' Tope de Equipo: S/ ' + mont.toLocaleString("es-Mx");
							}
							else {
								document.getElementById('lblCuotas').innerHTML = '';
							}
							document.getElementById('imgCuotasBRMS').style.display = "none";
						}
						else {
							//Agregar Metodo Iframe
							var url = '../iframe/sisact_ifr_consulta_reglas.aspx?';
							
							url += '&nroDocumento=' + nroDocumento;
							url += '&tipoDocumento=' + tipoDoc;
							url += '&strOficina=' + getValue('hidOficina');
							url += '&strDatos=' + cadenaGeneral();
							url += '&strMetodo=' + 'EvaluarCliente';	
							url += '&strCoID=' + getValue('hidCO');//SD1052592
													
							self.frames['iframeAuxiliar'].location.replace(url);
						}

					}
				
			}
			//PROY-29123
			function consultarClienteBRMSCallBack(objRespuesta,objError){
				if(objError != ""){
					alert(objError);
					return;
				}
				else{

					var msj = objRespuesta;
					var arr = new Array();
					var cuotas = 0;
					var monto = 0.0;
					var mensajeCuotas = "";
					
					var tipOpe = getValue('ddlTipoOperacion');
					var objStorageJson = JSON.parse(getValue('hidDatosBRMS'));
					var objJson;
					
					arr = msj.split(';');
																
					cuotas = parseInt(arr[0]);
					mont = parseFloat(arr[1]);
					mensajeCuotas = arr[2];
																
					objJson = { operacion: tipOpe, cuotamax: cuotas, topemax: mont, msjbrms: mensajeCuotas };
					
					objStorageJson.cuota.push(objJson);
					
					setValue('hidDatosBRMS',JSON.stringify(objStorageJson));
																
					if (mensajeCuotas && mensajeCuotas != "" && mensajeCuotas == "SI") {
						document.getElementById('lblCuotas').innerHTML = 'Cuotas: Max. ' + cuotas + ' Tope de Equipo: S/ ' + mont.toLocaleString("es-Mx");
					}
					else {
						document.getElementById('lblCuotas').innerHTML = '';
					}
				
			}
				document.getElementById('imgCuotasBRMS').style.display = "none";
			}
			
			function EsCanalPermitido(strCanalActual,strCanalesPermitidos) {								
				var aCanalesPermitidos = strCanalesPermitidos.split(',');				
				
				var i;
				for (i = 0; i < aCanalesPermitidos.length; i++) {
															
					if (aCanalesPermitidos[i] == strCanalActual)
						return true;
				}								
				
				return false;
			}
			
			
			function consultarDC()
			{

				if (getValue('ddlTipoDocumento') != '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
				{
					var flag = '<%= ConfigurationSettings.AppSettings("FlagPrueba") %>';
					if (flag == '1') //Pruebas Desarrollo
						f_ByPass_DataCredito_Equifax('20090929123456');
					else
						self.frames['ifrmEvaluacion'].location.replace("NumeroOperacion.asp?CodUsuarioSisact=" + "<%= Session("CodUsuarioSisact") %>");
				}
				else
					f_ConsultaDataCreditoCorp();
			}

			function f_ByPass_DataCredito_Equifax(strNumeroOperacion)
			{

				var flagExperto = '<%= ConfigurationSettings.AppSettings("Flag_DC_Equifax") %>';
				if (flagExperto == '1')
					f_ConsultaDataCredito(strNumeroOperacion);
			}

			function f_ConsultaDataCreditoCorp()
			{

				var strParametros, strTipoPersona, strRazonSocial;
				if (getValue('txtNroDoc').substring(0,1) == '<%= ConfigurationSettings.AppSettings("constRUCInicio")%>') {
					strTipoPersona = 'J';
					strRazonSocial = '';
				} else {
					strTipoPersona = 'N';
					strRazonSocial = 'NN';
				}
				strParametros = "strTipoDocumento=" + parseInt(getValue('ddlTipoDocumento'), 10);
				strParametros += "&strNumeroDocumento=" + getValue('txtNroDoc');
				strParametros += "&strApellidoPaterno=" + strRazonSocial;
				strParametros += "&strApellidoMaterno=" + strRazonSocial;
				strParametros += "&strNombre=" + strRazonSocial;
				strParametros += "&strTipoPersona=" + strTipoPersona;
				strParametros += "&strCodSolicitud=";
				strParametros += "&strTipoSEC=B";

				document.getElementById('ifraRepresentante').src = "../renovacion/sisact_listado_representante_legal.aspx?" + strParametros;
			}

			function f_RetornoDataCreditoCorp(strNumeroOperacion, strRazonSocial, strNombres, strApePaterno, strApeMaterno,
												strRiesgo, strTipoPersona, deudaFinanciera, nroFilas, buroConsultado)//ADD PROY-20054-IDEA-23849
			{
				//Guardar Info DC
				document.getElementById('txtRazonSocial').value = strRazonSocial;
				document.getElementById('hidNroOperacionDC').value = strNumeroOperacion;
				document.getElementById('hidDeudaFinancieraDC').value = deudaFinanciera;
				document.getElementById('hidRiesgoDC').value = strRiesgo;
				document.getElementById('hidNroRepresentante').value = nroFilas;
				document.getElementById('hidRiesgoTextoDC').value = getRiesgoTexto(strRiesgo);
				document.getElementById('txtRiesgo').size = 40;
				document.getElementById('txtRiesgo').value = getRiesgoTexto(strRiesgo);
				document.getElementById('hidBuroConsultado').value = buroConsultado; //ADD PROY-20054-IDEA-23849
				
				setEnabled('txtRazonSocial', false, 'clsInputDisabled');

				// Consultar LC Disponible x Producto
				consultarLCDisponible();
			}
			// ********************************************* Consulta DataCredito RUC ********************************************* //

			// ********************************************* Consulta DataCredito DNI/CE ********************************************* //
			function f_ConsultaDataCredito(strNumeroOperacion)
			{
				var strSecuencia = "0"; //OJO FALTA OBTENER CAMPO document.getElementById("hidExisteBSCSOriginal").value;
				var istrDatoComplemento, istrEdad, istrIngresoOLineaCredito, istrTIPOTARJETA, istrANTIGUEDADLABORAL;
				var istrDatoEntrada = "0";
				var strTipoCliente = "0";
				var strTipoProducto = "0";

				if (strSecuencia == "0") {
					istrDatoComplemento = "";
					istrEdad = "";
					istrIngresoOLineaCredito = "";
					istrTIPOTARJETA = "";
					istrANTIGUEDADLABORAL = "";
				}
				else {
					istrDatoComplemento = "00";
					istrEdad = "00";
					istrIngresoOLineaCredito = "0";
					istrTIPOTARJETA = "00";
					istrANTIGUEDADLABORAL = "0";
				}

				var usuarioDC = "";
				var claveDC = "";
				var istrNumOperaPVU = strNumeroOperacion;
				var istrRegion = "<%= ConfigurationSettings.AppSettings("ConstUbigeoLima") %>";
				var istrArea =  0; //OJO -- document.getElementById('hidTipoCliente').value;
				var istrCanal = usuarioDC;
				var istrPuntoVenta = document.getElementById('ddlPuntoVenta').value;
				var istrIDCanal = claveDC;
				var istrIDTerminal = "";
				var istrUsuarioACC = "";
				var ostrNumOperaEFT = strNumeroOperacion;
				var istrNUMCUENTAS = 0;//OJO FALTA OBTENER CAMPO GetPlanes().length; //numero planes
				var strEstadoCivil = "<%= ConfigurationSettings.AppSettings("ConstEstadoCivilSoltero") %>";
				var istrRucClaro = "<%= ConfigurationSettings.AppSettings("RUC_Claro") %>";

				var strApellidoPaterno = document.getElementById('txtApePat').value.replace(/\#/g, '').replace(/\%/g, ''); //.replace(/\'/g, '');
				var strApellidoMaterno = document.getElementById('txtApeMat').value.replace(/\#/g, '').replace(/\%/g, ''); //.replace(/\'/g, '');
				var strNombres = document.getElementById('txtNombre').value.replace(/\#/g, '').replace(/\%/g, ''); //.replace(/\'/g, '');

				//Entradas WS DC
				var strParametros = "";
				strParametros = "istrSecuencia=" + strSecuencia + "&";
				strParametros += "istrTipoDocumento=" + parseInt(document.getElementById('ddlTipoDocumento').value, 10) + "&";
				strParametros += "istrNumeroDocumento=" + document.getElementById('txtNroDoc').value + "&";
				strParametros += "istrApellidoPaterno=" + strApellidoPaterno + "&";
				strParametros += "istrApellidoMaterno=" + strApellidoMaterno + "&";
				strParametros += "istrNombres=" + strNombres + "&";
				strParametros += "istrDatoEntrada=" + istrDatoEntrada + "&";
				strParametros += "istrDatoComplemento=" + istrDatoComplemento + "&";
				strParametros += "istrTipoProducto=" + strTipoProducto + "&";
				strParametros += "istrTipoCliente=" + strTipoCliente + "&";
				strParametros += "istrEdad=" + istrEdad + "&";
				strParametros += "istrIngresoOLineaCredito=" + istrIngresoOLineaCredito + "&";
				strParametros += "istrTIPOTARJETA=" + istrTIPOTARJETA + "&";
				strParametros += "istrRUC=" + istrRucClaro + "&";
				strParametros += "istrANTIGUEDADLABORAL=" + istrANTIGUEDADLABORAL + "&";
				strParametros += "istrNumOperaPVU=" + istrNumOperaPVU + "&";
				strParametros += "istrRegion=" + istrRegion + "&";
				strParametros += "istrArea=" + istrArea + "&";
				strParametros += "istrCanal=" + istrCanal + "&";
				strParametros += "istrPuntoVenta=" + istrPuntoVenta + "&";
				strParametros += "istrIDCanal=" + istrIDCanal + "&";
				strParametros += "istrIDTerminal=" + istrIDTerminal + "&";
				strParametros += "istrUsuarioACC=" + istrUsuarioACC + "&";
				strParametros += "ostrNumOperaEFT=" + ostrNumOperaEFT + "&";
				strParametros += "istrNUMCUENTAS=" + istrNUMCUENTAS + "&";
				strParametros += "strEstadoCivil=" + strEstadoCivil;

//gaa20170226
				//var url = "../renovacion/ConsultaDataCredito.aspx?" + strParametros;
				var flagBuroAntiguo = '<%= ConfigurationSettings.AppSettings("flagBuroAntiguo") %>';	
				if (flagBuroAntiguo == '1')
				var url = "../renovacion/ConsultaDataCredito.aspx?" + strParametros;
				else
					var url = "../renovacion/ConsultaCreditosEbs.aspx?" + strParametros;
//fin gaa20170226
				self.frames["ifrmEvaluacion"].location.replace(url);
			}

			function f_ConsultaRegla_Previo_DataCredito(strResultadoInfocorp,strRiesgo,strLineaCredito,strClaseCliente,strNroOperacion,
														strTipoCliente,strIngreso,strExplicacion,strLetraSC,strNumSC,strApePaterno, strApeMaterno,
														strNombres, strRespuesta, strTipoTarjeta, strNumDocumento, strMensajeRespuesta,
														strORIGEN_LC_DC,strAnalisis,strScoreRankinOperativo,strPUNTAJE,strlimiteCreditoDataCredito,
														strlimiteCreditoBaseExterna,strlimiteCreditoClaro,strRAZONES,strFechaNacimiento,strBuro
														,strBuroCrediticio)//gaa20170215
			{
				//Mensaje de Error DC
				var blnError = (strMensajeRespuesta != '');
				if (blnError)
				{
					alert(strMensajeRespuesta);
					setEnabled('txtNombre', true, 'clsInputEnabled');
					setEnabled('txtApePat', true, 'clsInputEnabled');
					setEnabled('txtApeMat', true, 'clsInputEnabled');
					habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', true);
					return;
				}

				//Guardar Info DC
				var datosDC = "";
				datosDC = datosDC + strResultadoInfocorp + "?";			//[0]
				datosDC = datosDC + strRiesgo + "?";					//[1]
				datosDC = datosDC + strLineaCredito + "?";				//[2]
				datosDC = datosDC + strClaseCliente + "?";				//[3]
				datosDC = datosDC + strNroOperacion + "?";				//[4]
				datosDC = datosDC + strTipoCliente + "?";				//[5]
				datosDC = datosDC + strIngreso + "?";					//[6]
				datosDC = datosDC + strExplicacion + "?";				//[7]
				datosDC = datosDC + strLetraSC + "?";					//[8]
				datosDC = datosDC + strNumSC + "?";						//[9]
				datosDC = datosDC + strApePaterno + "?";				//[10]
				datosDC = datosDC + strApeMaterno + "?";				//[11]
				datosDC = datosDC + strNombres + "?";					//[12]
				datosDC = datosDC + strRespuesta + "?";					//[13]
				datosDC = datosDC + strTipoTarjeta + "?";				//[14]
				datosDC = datosDC + strNumDocumento + "?";				//[15]
				datosDC = datosDC + strMensajeRespuesta + "?";			//[16]
				datosDC = datosDC + strORIGEN_LC_DC + "?";				//[17]
				datosDC = datosDC + strAnalisis + "?";					//[18]
				datosDC = datosDC + strScoreRankinOperativo + "?";		//[19]
				datosDC = datosDC + strPUNTAJE + "?";					//[20]
				datosDC = datosDC + strlimiteCreditoDataCredito + "?";	//[21]
				datosDC = datosDC + strlimiteCreditoBaseExterna + "?";	//[22]
				datosDC = datosDC + strlimiteCreditoClaro + "?";		//[23]
				datosDC = datosDC + strRAZONES + "?";					//[24]
				datosDC = datosDC + strFechaNacimiento + "?";			//[25]
				datosDC = datosDC + strBuro + "?";						//[26]
				//gaa20170215
				datosDC = datosDC + strBuroCrediticio + "?";			//[27]
				document.getElementById('hidBuroConsultado').value = strBuroCrediticio;
				//fin gaa20170215
				//Guardar Info DC
				document.getElementById('hidDatosDC').value = datosDC;
				document.getElementById('hidRespuestaDC').value = strRespuesta;
				document.getElementById('hidRiesgoDC').value = strRiesgo;
				document.getElementById('hidRiesgoTextoDC').value = getRiesgoTexto(strRiesgo);
				document.getElementById('hidNroOperacionDC').value = strNroOperacion;
				
				//Por Defecto Edad 18
				var strEdad = '<%= ConfigurationSettings.AppSettings("ConstAnioMayorEdad") %>';
				var strFechaNacDC = strFechaNacimiento.substr(0,10);
				//if (getValue('hidRespuestaDC') != '<%= ConfigurationSettings.AppSettings("constRespDataCredTipo7") %>')
					//strEdad = calculaEdad(strFechaNacDC, fechaActual);

				//document.getElementById('hidEdadDC').value = strEdad;

				if (strRespuesta == '<%= ConfigurationSettings.AppSettings("constRespDataCredTipo6") %>') //10
				{
					//Contador10
					var contadorDCTipo10 = getValue('hidIntentos10');
					if (contadorDCTipo10 >= 2)
						nuevaEvaluacion();
					else
					{
						if (confirm("Documento de identidad no coincide con el Apellido ingresado. ¿Desea modificar datos?"))
						{
							setEnabled('txtNombre', true, 'clsInputEnabled');
							setEnabled('txtApePat', true, 'clsInputEnabled');
							setEnabled('txtApeMat', true, 'clsInputEnabled');
							habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', true);

							setValue('hidIntentos10', parseInt(getValue('hidIntentos10'),10) + 1);
							//mostrarDatosResultado();
							habilitarBoton('btnEvaluar', 'Evaluar', true);
							quitarImagenEsperando();
						}
						else{
							nuevaEvaluacion();
							habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
						}
					}
				}
				else if (strRespuesta == '<%= ConfigurationSettings.AppSettings("constRespDataCredTipo7") %>') //09
				{
					// Excepción Respuesta Tipo 7 DC
					var blnExcepcionDC7 = (document.getElementById('hidFlagExcepcionDC7').value == 'S');
					if (!blnExcepcionDC7)
					{
						if (confirm("SEC irá a Créditos para validación de identidad."))
						{
							setEnabled('txtNombre', false, 'clsInputDisabled');
							setEnabled('txtApePat', false, 'clsInputDisabled');
							setEnabled('txtApeMat', false, 'clsInputDisabled');
							habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', false);

							// Consultar LC Disponible x Producto
							consultarLCDisponible();
						}
						else{
							nuevaEvaluacion();
					         }
					}
					else
					{
						setEnabled('txtNombre', false, 'clsInputDisabled');
						setEnabled('txtApePat', false, 'clsInputDisabled');
						setEnabled('txtApeMat', false, 'clsInputDisabled');
						habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', false);

						// Consultar LC Disponible x Producto
						consultarLCDisponible();
					}
					mostrarDatosResultado();
				}
				else if(strRespuesta == '<%= ConfigurationSettings.AppSettings("constRespDataCredTipo1") %>') //13
				{
					//Respuesta Datos del Cliente DC
					document.getElementById('txtApePat').value = strApePaterno;
					document.getElementById('txtApeMat').value = strApeMaterno;
					document.getElementById('txtNombre').value = strNombres;
					habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', false);

					//Campos Editable Carnet Extranjeria
					if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("constTipoDocumentoCEX") %>')
					{
						setEnabled('txtNombre', true, 'clsInputEnabled');
						setEnabled('txtApePat', true, 'clsInputEnabled');
						setEnabled('txtApeMat', true, 'clsInputEnabled');
					}
					else
					{
						setEnabled('txtNombre', false, 'clsInputDisabled');
						setEnabled('txtApePat', false, 'clsInputDisabled');
						setEnabled('txtApeMat', false, 'clsInputDisabled');
					}

					// Consultar LC Disponible x Producto
					     consultarLCDisponible();
			             mostrarDatosResultado();
			       }

			}

			function mostrarSecPendienteIfr(pstrNroSec)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strNroSec=' + pstrNroSec;
				url += '&strFlujo=' + obtenerFlujo();
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strRiesgo=' + getValue('hidRiesgoDC');
				url += '&strOrgVenta=' + getValue('hidOrgVenta');
				url += '&strCentro=' + getValue('hidCentro');
				url += '&strTipoDocVentaSap=' + getValue('hidTipoDocVentaSap');
				url += '&strCanalSap=' + getValue('hidCanalSap');
				url += '&strFlgEvaluarMovil=' + getValue('hidEvaluarMovil');
//gaa20161027
				url += '&strTipoModalidadVenta=' + parent.getValue('ddlModalidad');
//fin gaa20161027
				url += '&strMetodo=' + 'MostrarSecPendiente';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function mostrarSecPendiente(strValor)
			{
				setValue('hidCadenaSECPendiente', strValor);
				self.frames["ifraCondicionesVenta"].window.location.reload();
			}

			function asignarTipoOperacion()
			{
				var strCanal = getValue('ddlCanal');
				var arrTipoOperacion = getValue('hidListaTipoOperacion').split('|');
				var ddlTipoOperacion = document.getElementById('ddlTipoOperacion');
				var strDatos = '';
				for (var i = 0; i < arrTipoOperacion.length; i++)
				{
					var arrTipo = arrTipoOperacion[i].split(';');
					if (arrTipo[0] == strCanal && arrTipo[1] == getValue('ddlTipoDocumento'))
					{
						if (getValue('hidTienePortabilidad') == 'S')
						{
							if (arrTipo[2] == '1')
								strDatos = strDatos + '|' + arrTipo[2] + ';' + arrTipo[3];
						}
						else
						{
							if (getValue('hidEvaluarMovil') == 'N')
							{
								if (arrTipo[2] != '<%= ConfigurationSettings.AppSettings("constTipoOperacionMIG") %>')
									strDatos = strDatos + '|' + arrTipo[2] + ';' + arrTipo[3];
							}
							else
								strDatos = strDatos + '|' + arrTipo[2] + ';' + arrTipo[3];
						}
					}
				}
				llenarDatosCombo(ddlTipoOperacion, strDatos, false);
				//IMP SD 986863 
				setValue('hidTipoOperacion', '3');
			}

			function cambiarTipoOperacion(ddl)
			{
				if (getValue('hidCadenaDetalle') != '')
				{
					if (!confirm('Se perderá la información del carrito de compras ¿Desea Continuar?'))
					{
						//IMP SD 986863 
						setValue('hidTipoOperacion', '3');
						return;
					}
				}
				
				if (ddl.value == '<%= ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto") %>'){
					setValue('hidTipoOperacion', '3');
					setValue('hid4G', '<%= ConfigurationSettings.AppSettings("Cambio4G") %>');
					setValue('hidRespuestaChip', '<%= ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto") %>');
				}else{
				//IMP SD 986863
				setValue('hidTipoOperacion', '3');
				setValue('hidRespuestaChip', '3');	
				}
				
				setValue('hidCadenaDetalle', '');
				//var ddlOferta = document.getElementById('ddlOferta');
				//ddlOferta.selectedIndex = 0;
				//cambiarTipoOferta();
				consultarClienteBRMS();
			}

			function asignarCasoEspecial(strValores, strSeleccionado)
			{
			}

			function consultarLCDisponible()
			{
				var dblLC = 0;
				var strEssaludSunat = '<%= ConfigurationSettings.AppSettings("EssaludSunatPositivo") %>';

				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					dblLC = getValue('hidDeudaFinancieraDC');
				else {
					if (getValue('hidDatosDC').split('?')[2] != undefined || getValue('hidDatosDC').split('?')[2] != null)
					{
						dblLC = getValue('hidDatosDC').split('?')[2];
					}
					if (getValue('hidDatosDC').split('?')[5] == '0')
						strEssaludSunat = '<%= ConfigurationSettings.AppSettings("EssaludSunatNegativo") %>';
				}

				var url = '../iframe/sisact_ifr_consulta_reglas.aspx?';
				url += 'tipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&nroDocumento=' + getValue('txtNroDoc');
				url += '&strRiesgo=' + getValue('hidRiesgoDC');
				url += '&strEssaludSunat=' + strEssaludSunat;
				url += '&dblLC=' + dblLC;
				url += '&nroOperacion=' + getValue('hidNroOperacionDC');
				url += '&strMetodo=CalcularLCDisponible';
				url += '&strCoID=' + getValue('hidCO');//SD1052592
				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornoConsultarLCDisponible(blnOK)
			{
				if (blnOK)
				{
					trCondicionVenta.style.display = '';
					trCondicionVentaDetalle.style.display = '';

					if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					{
						trRepresentante.style.display = '';		//Mostrar Representante Legal
					}

					// SEC Pendiente
					if (getValue('hidNroSEC') != '')
						mostrarSecPendienteIfr(getValue('hidNroSEC'));
					
					//Código Nuevo para renovación DAC
					

				
				} else {
					habilitarBoton('btnConsultaDC', 'Ingresar Condiciones de Venta', true);
					return;
				}
			}

			function obtenerTextoSeleccionado(ddl)
			{
				var resultado = '';

				for (var i = 0; i < ddl.options.length; i++)
				{
					if (ddl.options[i].selected)
						resultado = ddl.options[i].text;
				}

				return resultado;
			}

			function getValor(strValor, idValor)
			{
				if (strValor.indexOf('_') > -1)
				{
					var arrCodigo = strValor.split('_');
					return arrCodigo[idValor];
				}
				else
					return 0;
			}

			function cambiarPortabilidad(chk)
			{
				
				document.getElementById('hidTienePortabilidad').value = 'N';
				if (chk.checked)
					document.getElementById('hidTienePortabilidad').value = 'S';
			}

			function cambiarTipoOferta()
			{

				if (getValue('hidCadenaDetalle') != '')
				{
					if (!confirm('Se perderá la información del carrito de compras ¿Desea Continuar?'))
					{
						setValue('ddlOferta', getValue('hidTipoOferta'));
						return;
					}
				}
				//gaa20160516
				//if (getValue('ddlOferta') == '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>' && getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>')
				if (getValue('ddlOferta') == '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>')
					document.getElementById('ddlModalidad').disabled = true;
				else
					document.getElementById('ddlModalidad').disabled = false;
				//fin gaa20160516
				setValue('hidTipoOferta', getValue('ddlOferta'));
				setEnabled('btnAgregarPlan', true, 'Boton');
				
				document.getElementById('tdMovil').style.display = '';
				document.getElementById('tdBAM').style.display = '';
				if (isVisible('tdMovil')) { setEnabled('tdMovil', true, ''); }
				if (isVisible('tdBAM')) { setEnabled('tdBAM', true, ''); }
				
				inicializarDatosCasoEspecial();
				inicializarPanelResultado();
				inicializarPanelComentarios();
				inicializarPanelGrabar();

				cambiarTipoOfertaIfr();
			}

			function cambiarModalidadVenta(ddl) {
				if (getValue('hidCadenaDetalle') != '') {
					if (!confirm('Se perderá la información del carrito de compras ¿Desea Continuar?')) {
						ddl.value = getValue('hidModalidadVenta');
						return;
					}
				}
				setValue('hidModalidadVenta', ddl.value);

				setEnabled('btnAgregarPlan', true, 'Boton');
				
				document.getElementById('tdMovil').style.display = '';
				document.getElementById('tdBAM').style.display = '';
				if (isVisible('tdMovil')) { setEnabled('tdMovil', true, ''); }
				if (isVisible('tdBAM')) { setEnabled('tdBAM', true, ''); }
				
				inicializarDatosCasoEspecial();
				inicializarPanelResultado();
				inicializarPanelComentarios();
				inicializarPanelGrabar();
				
				setValue('hidCadenaDetalle', '');
				self.frames["ifraCondicionesVenta"].location.replace("sisact_ifr_condiciones_venta.aspx?TipDoc=" + getValue('hidTipoDocumento') + "&NroLinea=" + getValue('hidNroLinea')+ "&NumDoc=" + getValue('hidNroDocumento') + "&TipCanal=" + getValue('ddlCanal') + "&TipModalidad=" + getValue('ddlModalidad') + "&PlanNoVigente=" + getValue('hidVigente'));
			}
			
			//inicio 24/11/2015
			function cambiarGrupoProducto(ddl) {

		     if (getValue('ddlGProducto') != "00"){
		    	document.getElementById('tdMovil').style.display = '';
				document.getElementById('tdBAM').style.display = '';
				if (isVisible('tdMovil')) { setEnabled('tdMovil', true, ''); }
				if (isVisible('tdBAM')) { setEnabled('tdBAM', false, ''); } 
				
				setEnabled('chkPlanNoVigente', false, '');
				document.getElementById('chkPlanNoVigente').checked = false;
				
		     }else{
		        document.getElementById('tdMovil').style.display = '';
				document.getElementById('tdBAM').style.display = '';
				if (isVisible('tdMovil')) { setEnabled('tdMovil', true, ''); }
				if (isVisible('tdBAM')) { setEnabled('tdBAM', true, ''); } 
				setEnabled('chkPlanNoVigente', true, '');
		     }
			}
			
			//fin 24/11/2015
			
			function obtenerFlujo()
			{
				var strTienePortabilidad = document.getElementById('hidTienePortabilidad').value;
				var strFlujo = '<%= ConfigurationSettings.AppSettings("flujoAlta") %>';

				if (strTienePortabilidad == 'S')
					strFlujo = '<%= ConfigurationSettings.AppSettings("flujoPortabilidad") %>';

				return strFlujo;
			}

			function cambiarTipoOfertaIfr()
			{
				cargarImagenEsperando();
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strTipoCliente=' + getValue('ddlOferta');
				url += '&strFlujo=' + obtenerFlujo();
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strTipoOficina=' + getValue('hidOficina');
				url += '&strFlgEvaluarMovil=' + getValue('hidEvaluarMovil');
				url += '&strOficina=' + getValue('hidOficina');				
				url += '&strMetodo=' + 'CambiarTipoOferta';
				//999
				url += '&strCanal=' + getValue('ddlCanal');
				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarCambioTipoOferta(strResultado)
			{
				if (strResultado.indexOf('¬') > -1)
				{
					var arrResultado = strResultado.split('¬');
					//var ddlCasoEspecial = document.getElementById('ddlCasoEspecial');
					//llenarDatosCombo(ddlCasoEspecial, arrResultado[1], true);

					setValue('hidPlazos', arrResultado[2]);
					setValue('hidListaTipoProducto', arrResultado[0]);
//gaa20170714
					setValue('hidPenalidadBRMS', arrResultado[3]);
//fin gaa20170714
					setValue('hidCadenaDetalle', '');
					
					self.frames["ifraCondicionesVenta"].location.replace("sisact_ifr_condiciones_venta.aspx?TipDoc=" + getValue('hidTipoDocumento') + "&NroLinea=" + getValue('hidNroLinea')+ "&NumDoc=" + getValue('hidNroDocumento') + "&TipCanal=" + getValue('ddlCanal')  + "&PlanNoVigente=" + getValue('hidVigente'));
				}
				else {
					setValue('hidListaTipoProducto', '');
				}
				
				//PROY-29123
				consultarClienteBRMS();
				
			}

			function llenarDatosCombo(ddl, strDatos, booSeleccione)
			{
				var arrDatos;
				var arrItem;
				var strDato;
				var option;
				ddl.innerHTML = "";

				if (booSeleccione)
				{
					option = document.createElement('option');
					option.value = '';
					option.text = '--SELECCIONAR--';
					ddl.add(option);
				}
				if (strDatos != null)
					var arrDatos = strDatos.split("|");
				else
					return;

				for (i = 0; i < arrDatos.length; i++)
				{
					option = document.createElement('option');

					if (arrDatos[i].length > 0)
					{
						strDato = arrDatos[i];
						arrItem = strDato.split(";");

						if (strDato != 'null')
						{
							if (arrItem.length > 1)
							{
								option.value = arrItem[0];
								option.text = arrItem[1];
							}
							else
							{
								option.value = arrDatos[i];
								option.text = arrDatos[i];
							}

							ddl.add(option);
						}
					}
				}
			}

			function getRiesgoTexto(strRiesgo)
			{
				var strTextoRiesgo = '';
				var strCadenaRiesgo = getValue('hidListaRiesgo');
				var arrCadenaRiesgo = strCadenaRiesgo.split('|');
				for (var i = 0; i < arrCadenaRiesgo.length; i++)
				{
					var fila = arrCadenaRiesgo[i].split(';');
					if (strRiesgo == fila[0])
					{
						strTextoRiesgo = fila[1];
						break;
					}
				}
				return strTextoRiesgo;
			}
			// ******************************************************* REGLAS COMERCIALES ******************************************************* //

			// ******************************************************* CASO ESPECIAL ******************************************************* //
			//[0] TCESC_CODIGO
			//[1] FLAG_WHITELIST
			//[2] TCEN_MAX_PLANES
			//[3] TCEN_MAX_PLAN_VOZ
			//[4] TCEN_MAX_PLAN_DATOS

			function inicializarDatosCasoEspecial()
			{
				setValue('hidWhitelistCE', '');
				setValue('hidCargoFijoMaxCE', '');
				setValue('hidlistaCEPlanBscs', '');
				setValue('hidlistaCEPlan', '');
				setValue('hidlistaCERiesgo', '');
				setValue('hidCasoEspecial', '');
				setValue('hidCasoEspecialText', '');
			}

			function cambiarCasoEspecial(ddl)
			{
				if (getValue('hidCadenaDetalle') != '')
				{
					if (!confirm('Se perderá la información del carrito de compras ¿Desea Continuar?'))
					{
						setValue('ddlCasoEspecial', getValue('hidCasoEspecial'));
						return;
					}
				}

				inicializarDatosCasoEspecial();
				var arrCasoEspecial = ddl.value.split('_');
				var strWhiteList;
				if (arrCasoEspecial[0] != '')
					strWhiteList = arrCasoEspecial[1];

				inicializarDatosCasoEspecial();
				inicializarPanelResultado();
				inicializarPanelComentarios();
				inicializarPanelGrabar();

				cambiarCasoEspecialIfr(arrCasoEspecial[0], strWhiteList, getValue('hidRiesgoDC'));
			}

			function cambiarCasoEspecialIfr(strCasoEspecial, strWhiteList, strRiesgo)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strOferta=' + getValue('ddlOferta');
				url += '&strFlujo=' + obtenerFlujo();
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strNroDoc=' + getValue('txtNroDoc');
				//url += '&strCasoEspecial=' + strCasoEspecial;
				url += '&strWhitellist=' + strWhiteList;
				url += '&strRiesgo=' + strRiesgo;
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strMetodo=' + 'CambiarCasoEspecial';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarCambioCE(blnWhiteList, dblCFMaximo, listaCEPlanBscs, listaCEPlan, listaCERiesgo)
			{
				/*var ddlCasoEspecial = document.getElementById('ddlCasoEspecial');
				var whiteList = ddlCasoEspecial.value.split('_')[1];
				if (whiteList == '1')
				{
					if (blnWhiteList != 'S')
					{
						alert('El Nro de documento no se encuentra en la lista del caso especial seleccionado.');
						inicializarDatosCasoEspecial();
						ddlCasoEspecial.value = '';
						setValue('hidCadenaDetalle', '');
						self.frames["ifraCondicionesVenta"].window.location.reload();
						return;
					}
				}*/
				//setValue('hidCasoEspecial', ddlCasoEspecial.value);
				//setValue('hidCasoEspecialText', obtenerTextoSeleccionado(ddlCasoEspecial));
				setValue('hidWhitelistCE', blnWhiteList);
				setValue('hidCargoFijoMaxCE', dblCFMaximo);
				setValue('hidlistaCEPlanBscs', listaCEPlanBscs);
				setValue('hidlistaCEPlan', listaCEPlan);
				setValue('hidlistaCERiesgo', listaCERiesgo);

				setValue('hidCadenaDetalle', '');
				self.frames["ifraCondicionesVenta"].window.location.reload();
			}

			function nroPlanesEvalxProducto()
			{
				var nroPlanesEval = 0;
				var nroPlanesEvalTotal = 0;

				//Validacion 4Play
				var strCodCasoEspecial = getValor(getValue('ddlCasoEspecial'), 0);
				if (strCodCasoEspecial != '')
				{
					strCodCasoEspecial = '|' + strCodCasoEspecial + '|';
					var listaVentaCE4Play = '<%= ConfigurationSettings.AppSettings("constVentaCE4Play") %>';
					var listaPostventaCE4Play = '<%= ConfigurationSettings.AppSettings("constPostVentaCE4Play") %>';
					if (listaVentaCE4Play.indexOf(strCodCasoEspecial) > -1 || listaPostventaCE4Play.indexOf(strCodCasoEspecial) > -1)
						return true;
				}

				var nroNroMaxPlanes;
				var nroNroMaxPlanesMovil;
				var nroNroMaxPlanesFijo;
				var nroNroMaxPlanesBAM;
				var nroNroMaxPlanesDTH;
				var nroNroMaxPlanesHFC;

				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
				{
					nroNroMaxPlanes = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaximoPlanesEmpresa") %>');
					nroNroMaxPlanesMovil = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesMovilEmpresa") %>');
					nroNroMaxPlanesFijo = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesFijoEmpresa") %>');
					nroNroMaxPlanesBAM = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesBAMEmpresa") %>');
					nroNroMaxPlanesDTH = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesDTHEmpresa") %>');
					nroNroMaxPlanesHFC = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesHFCEmpresa") %>');
				}
				else
				{
					nroNroMaxPlanes = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaximoPlanesPersona") %>');
					nroNroMaxPlanesMovil = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesMovilPersona") %>');
					nroNroMaxPlanesFijo = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesFijoPersona") %>');
					nroNroMaxPlanesBAM = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesBAMPersona") %>');
					nroNroMaxPlanesDTH = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesDTHPersona") %>');
					nroNroMaxPlanesHFC = getParametroGeneral('<%= ConfigurationSettings.AppSettings("constNroMaxPlanesHFCPersona") %>');
				}

				nroPlanesEval = parseInt(0) + nroPlanesEvaluados('', codTipoProductoFijo);
				nroPlanesEvalTotal += parseInt(nroPlanesEval, 10);
				if (nroPlanesEval > parseInt(nroNroMaxPlanesFijo, 10)) return false;

				//Excepción a Conteo de Planes
				if (!((getValue('ddlOferta') == '<%= ConfigurationSettings.AppSettings("constCodTipoProductoBUS") %>')
				    && (getValue('ddlTipoDocumento') != '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')))
				{
					nroPlanesEval = parseInt(0) + nroPlanesEvaluados('', codTipoProductoMovil);
					nroPlanesEvalTotal += parseInt(nroPlanesEval, 10);
					if (nroPlanesEval > parseInt(nroNroMaxPlanesMovil, 10)) return false;

					nroPlanesEval = parseInt(0) + nroPlanesEvaluados('', codTipoProductoBAM);
					nroPlanesEvalTotal += parseInt(nroPlanesEval, 10);
					if (nroPlanesEval > parseInt(nroNroMaxPlanesBAM, 10)) return false;
				}

				nroPlanesEval = parseInt(0) + nroPlanesEvaluados('', codTipoProductoDTH);
				nroPlanesEvalTotal += parseInt(nroPlanesEval, 10);
				if (nroPlanesEval > parseInt(nroNroMaxPlanesDTH, 10)) return false;

				nroPlanesEval = parseInt(0) + nroPaqEvaluadosHFC();
				nroPlanesEvalTotal += parseInt(nroPlanesEval, 10);
				if (nroPlanesEval > parseInt(nroNroMaxPlanesHFC, 10)) return false;

				if (nroPlanesEvalTotal > parseInt(nroNroMaxPlanes, 10)) return false;

				return true;
			}

			function nroPaqEvaluadosHFC()
			{
				var strCadenaDetalle = getValue('hidCadenaDetalle');
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var idProducto;
				var idFila;
				var nroPlanes = 0;
				for (var i = 0; i < arrCadenaDetalle.length; i++)
				{
					if (arrCadenaDetalle[i] != '')
					{
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];
						if (idProducto == codTipoProductoHFC)
						{
							var strGrupoPaquete = arrCadenaDetalle[i].split(';')[8];
							var idFilaPaquete = obtenerFilaPaquete(strGrupoPaquete);
							if (idFila == idFilaPaquete)
							{
								nroPlanes += parseInt(1);
							}
						}
					}
				}
				return nroPlanes;
			}

			function nroPlanesEvaluados(idPlan, idProducto)
			{
				var nroPlanes = 0;
				var strPlanes = getValue('hidPlanDetalle');
				var arrPlanes = strPlanes.split('|');
				for (var i = 0; i < arrPlanes.length; i++)
				{
					if (arrPlanes[i] != '')
					{
						if (idPlan == 'ALL' && idProducto == 'ALL')
							nroPlanes += parseInt(1);
						else
						{
							if (idProducto != '')
							{
								var producto = arrPlanes[i].split(';')[0];
								if (producto == idProducto)
									nroPlanes += parseInt(1);
							}
							else
							{
								var plan = arrPlanes[i].split(';')[1];
								if (parseInt(plan, 10) == parseInt(idPlan, 10))
									nroPlanes += parseInt(1);
							}
						}
					}
				}
				return nroPlanes;
			}

			function nroPlanesActivosxId(idPlan)
			{
				var nroPlanes = 0;
				var strPlanesActivos = getValue('hidPlanesActivos');
				var arrPlanesActivos = strPlanesActivos.split('|');
				for (var i = 0; i < arrPlanesActivos.length; i++)
				{
					if (arrPlanesActivos[i] != '')
					{
						if (idPlan == 'ALL')
							nroPlanes += parseInt(1);
						else {
							var plan = arrPlanesActivos[i].split(';')[0];
							if (parseInt(plan, 10) == parseInt(idPlan, 10))
								nroPlanes += parseInt(1);
						}
					}
				}
				return nroPlanes;
			}

			function CalcularFactorRenovacion()
			{
				var cargoFActual = getValue('hidCargoFijoActual');
				var cargoFNuevo = getValue('hidCargoFijoNuevo');
				var RatioFR = parseFloat(cargoFNuevo/cargoFActual);
					
				var RatioMin = getValue('hidRatioFactorMin'); 
				var RatioMax = getValue('hidRatioFactorMax'); 
				if (RatioFR <= RatioMin)
				{
					setValue('hidFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionBueno") %>')
					setValue('txtFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionBueno") %>')
				}
				else if(RatioFR > RatioMin && RatioFR < RatioMax)
				{	
					setValue('hidFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionRegular") %>')
					setValue('txtFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionRegular") %>')
				}
				else if(RatioFR > RatioMax)
				{	
					setValue('hidFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionMalo") %>')
					setValue('txtFactorRenovacion', '<%= ConfigurationSettings.AppSettings("consCalFactorRenovacionMalo") %>')
				}
			}
			
			function ValidarEvaluacionSEC()
			{
				
				// Requiere Seleccion Plazo, Plan, Campaña y Equipo
				var ifr = self.frames['ifraCondicionesVenta'];
				var tipoProd = ifr.getValue('hidTipoProductoActual');
				var tabla = ifr.document.getElementById('tblTabla' + tipoProd );
				var cont = tabla.rows.length;
				if (cont >= 1){
					for (var i = 0; i < cont; i++)
					{
						fila = tabla.rows[i];

						if (ifr.getValue('hidCodigoTipoProductoActual') != ifr.codTipoProdDTH) 
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
						else 
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

						var ddlPlan = ifr.document.getElementById('ddlPlan' + idFila);
						var ddlPlazo = ifr.document.getElementById('ddlPlazo' + idFila);
						var ddlCampana = ifr.document.getElementById('ddlCampana' + idFila);
						var hidValorEquipo = ifr.document.getElementById('hidValorEquipo' + idFila);
						
						if (ddlPlazo != undefined)
						{
							if (ddlPlazo.value.length == 0)
							{
								if (!ddlPlan.disabled)
								{
									ddlPlazo.focus();
									alert('Debe seleccionar un plazo');
									return false;
								}
							}
						}
						if (ddlPlan != undefined)
						{
							if (ddlPlan.value.length == 0)
							{
								if (!ddlPlan.disabled)
								{
									ddlPlan.focus();
									alert('Debe seleccionar un plan');
									return false;
								}
							}
						}

						if (ifr.getValue('hidCodigoTipoProductoActual') != ifr.codTipoProd3Play)
						{
							if (ddlCampana != undefined)
							{
								if (ddlCampana.value.length == 0)
								{
									if (!ddlCampana.disabled)
									{
										ddlCampana.focus();
										alert('Debe seleccionar una campaña');
										return false;
									}
								}
							}
							
							if (ddlPlazo != undefined)
							{
								var plazo = ddlPlazo.value;
								var listaPlazoEquipo = '<%= ConfigurationSettings.AppSettings("constPlazoConEquipo") %>';
								if (listaPlazoEquipo.indexOf(plazo) > 0)
								{
									if (hidValorEquipo != undefined)
									{
										if (hidValorEquipo.value.length == 0)
										{
											alert('Debe seleccionar un equipo');
											return false;
										}
									}
								}
							}
						}
						
						if (getValue('ddlModalidad') == constModalidadPagoEnCuota) {
							var arrCuota = ifr.obtenerCuotaValores(idFila);
							if (arrCuota != null) {
								var codigoCuota = arrCuota[0].split('_')[0];

								if (codigoCuota.length == 0) {
									alert('Debe seleccionar una cuota para el plan');
									return false;
								}
							}
							else
							{						
								alert('Debe seleccionar una cuota para el plan');
								return false;
							}
						}
					}
				}
				var codTipoProductoActual = ifr.getValue('hidCodigoTipoProductoActual');
				if (!ifr.verificarPlanes())
					return false;
				
				setEnabled('ddlOferta', false, '');
				setEnabled('ddlTipoOperacion', false, '');
				
				//01122015
				setEnabled('ddlGProducto', false, '');
				setEnabled('ddlTipoRenovacion', false, '');
				setEnabled('chkPlanNoVigente', false, '');
				setEnabled('ddlModalidad', false, '');
				
				//01122015
				var imgEditarFila1 = ifr.document.getElementById('imgEditarFila1');
				var imgEliminarFila1 = ifr.document.getElementById('imgEliminarFila1');
				imgEditarFila1.onclick = function() {}
				imgEliminarFila1.onclick = function() {}
				habilitarBoton('btnEvaluar', 'Procesando...', false);
				habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', false);
				return true;
			}
			
			// Consulta BRMS
			function cadenaGeneral() {
				var strCadena = "";
						
				strCadena = constTipoOperacionRenovacion;
				strCadena += "|" + getText('ddlOferta');
				strCadena += "|" + getText('ddlModalidad');
				
				return strCadena;
				}

			function cadenaPlanesDetalle(strCadenaDetalle) {
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var strCadena = '';
				var idFila = '';
				var idProducto = '';
				var dblCF = 0;
				var arrDetalle;
				var strGrupoPaquete;
				var idFilaPaquete;
				var topeConsumo = '';
//gaa20170215
				var cfAcumulado = 0;
				var cantidadPlanes = 0;
				var montoActual;
				var idProductoAnt = '';
//fin gaa20170215
				for (var i = 0; i < arrCadenaDetalle.length; i++) {
					if (arrCadenaDetalle[i] != '') {
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];
						arrDetalle = arrCadenaDetalle[i].split(';');
						dblCF = 0;
						strGrupoPaquete = arrCadenaDetalle[i].split(';')[8];
//gaa20170215
					if (idProductoAnt != idProducto) {
						cfAcumulado = 0;
						cantidadPlanes = 0;
						idProductoAnt = idProducto;
					}
//fin gaa20170215
						if (idProducto == codTipoProductoHFC) {
							idFilaPaquete = obtenerFilaPaquete(strGrupoPaquete);

							if (idFila == idFilaPaquete) {
								for (var ii = 0; ii < arrCadenaDetalle.length; ii++) {
									if (arrCadenaDetalle[ii] != '') {
										if (strGrupoPaquete == arrCadenaDetalle[ii].split(';')[8])
										{
											montoActual = parseFloat(arrCadenaDetalle[ii].split(';')[23]);
											dblCF += montoActual;
//gaa20170215
											cfAcumulado += montoActual;
//fin gaa20170215
										}
										if (arrCadenaDetalle[ii].split(';')[35] != '')
											topeConsumo = arrCadenaDetalle[ii].split(';')[35];
									}
								}

								strCadena += idFila + ";"; 		    //[0] - idFila
								strCadena += idProducto + ";"; 	    //[1] - idProducto
								strCadena += arrDetalle[2] + ";";   //[2] - idPlazo
								strCadena += arrDetalle[6] + ";";   //[3] - idPaquete
								strCadena += arrDetalle[7] + ";";   //[4] - Paquete Texto
								strCadena += arrDetalle[10] + ";"; 	//[5] - idPlan
								strCadena += arrDetalle[11] + ";"; 	//[6] - Plan Texto
								strCadena += topeConsumo + ";";     //[7] - Tope Consumo
								strCadena += arrDetalle[15] + ";"; 	//[8] - idCampana
								strCadena += arrDetalle[16] + ";"; 	//[9] - Campana Texto
//gaa20170215
								//strCadena += dblCF + "|"; 		    //[10]- CF
								strCadena += dblCF + ";"; 		    //[10]- CF
								strCadena += cfAcumulado + ';';
								cantidadPlanes += 1;
								strCadena += cantidadPlanes + '|';
//fin gaa20170215
							}
						}
						else {
						strCadena += idFila + ";";			//[0] - idFila
						strCadena += idProducto + ";";		//[1] - idProducto
							strCadena += arrDetalle[2] + ";";   //[2] - idPlazo
						strCadena += arrDetalle[6] + ";";	//[3] - idPaquete
						strCadena += arrDetalle[7] + ";";	//[4] - Paquete Texto
						strCadena += arrDetalle[10] + ";";	//[5] - idPlan
						strCadena += arrDetalle[11] + ";";	//[6] - Plan Texto
						strCadena += arrDetalle[14] + ";";	//[7] - Tope Consumo
						strCadena += arrDetalle[15] + ";";	//[8] - idCampana
						strCadena += arrDetalle[16] + ";";	//[9] - Campana Texto
//gaa20170215
						dblCF = parseFloat(arrDetalle[23]);
						cfAcumulado += dblCF;
						//strCadena += arrDetalle[23] + "|";  //[10]- CF
						strCadena += dblCF + ";"; 		    //[10]- CF
						strCadena += cfAcumulado + ';';
						cantidadPlanes += 1;
						strCadena += cantidadPlanes + '|';
//fin gaa20170215
						}
					}
				}
				strCadena = strCadena.replace(/\+/g, '*');
				return strCadena;
			}

			function cadenaEquiposDetalle(strCadenaDetalle) {
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var strCadena = '';
				var idFila = '';
				var idProducto = '';
				var arrDetalle;
				var strGrupoPaquete;
				var idFilaPaquete;

				for (var i = 0; i < arrCadenaDetalle.length; i++) {
					if (arrCadenaDetalle[i] != '') {
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];
						arrDetalle = arrCadenaDetalle[i].split(';');
						strGrupoPaquete = arrCadenaDetalle[i].split(';')[8];
						
						if (idProducto != codTipoProductoHFC) {
							strCadena += idFila + ";"; 		    //[0] - idFila
							strCadena += idProducto + ";"; 	    //[1] - idProducto
							strCadena += arrDetalle[17] + ";";  //[2] - idEquipo
							strCadena += arrDetalle[18] + ";";  //[3] - Equipo
							strCadena += arrDetalle[25] + ";";  //[4] - Costo
							strCadena += arrDetalle[26] + ";";  //[5] - Precio Venta
							strCadena += arrDetalle[28] + ";";  //[6] - nro Cuota
							strCadena += arrDetalle[29] + ";";  //[7] - porcentaje Cuota
							strCadena += arrDetalle[31] + "|";  //[8] - Monto Cuota
						}
					}
				}
				strCadena = strCadena.replace(/\+/g, '*');
				return strCadena;
			}

			function cadenaServiciosDetalle(strCadenaDetalle) {
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var strCadena = '';
				var idFila = '';
				var idProducto = '';
				var arrDetalle;
				var strGrupoPaquete;
				var idFilaPaquete;
				var strCadenaSrv = '';

				for (var i = 0; i < arrCadenaDetalle.length; i++) {
					if (arrCadenaDetalle[i] != '') {
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];
						arrDetalle = arrCadenaDetalle[i].split(';');
						strGrupoPaquete = arrCadenaDetalle[i].split(';')[8];

						if (idProducto == codTipoProductoHFC) {
							idFilaPaquete = obtenerFilaPaquete(strGrupoPaquete);

							if (idFila == idFilaPaquete) {
								for (var ii = 0; ii < arrCadenaDetalle.length; ii++) {
									if (arrCadenaDetalle[ii] != '') {
										if (strGrupoPaquete == arrCadenaDetalle[ii].split(';')[8]) {
											strCadenaSrv += arrCadenaDetalle[ii].split(';')[33] + ";";
										}
									}
								}

								strCadena += idFila + ";";			//[0] - idFila
								strCadena += strCadenaSrv + "|"; //[1] - servicios
							}
						}
					}
							}

				strCadena = strCadena.replace(/\+/g, '*');
				return strCadena;
						}

			function consultaReglasCreditos() {
				var strCadenaDetalle = self.frames['ifraCondicionesVenta'].consultarItem('');
			
				var strCadenaPlan = cadenaPlanesDetalle(strCadenaDetalle);
				var strCadenaEquipo = cadenaEquiposDetalle(strCadenaDetalle);
				var strCadenaServicio = cadenaServiciosDetalle(strCadenaDetalle);
				var strCadenaDatos = cadenaGeneral();

				setValue('hidDetquip',strCadenaEquipo); //'PROY-24724-IDEA-28174 
				
				if (getValue('hidNroConsultaBRMS') == '1')
					strCadenaDatos = strCadenaDatos.replace(constTipoOperacionRenovacion, constTipoOperacionAltaRenovacion);

				cargarImagenEsperando();

				var url = '../iframe/sisact_ifr_consulta_reglas.aspx?';
				url += 'tipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&nroDocumento=' + getValue('txtNroDoc');
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strCadenaDatos=' + strCadenaDatos;
				url += '&strCadenaPlan=' + strCadenaPlan;
				url += '&strCadenaEquipo=' + strCadenaEquipo;
				//gaa20170215
				url += '&strBuroConsultado=' + getValue('hidBuroConsultado');
				//fin gaa20170215
				url += '&strMetodo=' + 'Evaluar';	
				url += '&strFlagProTMovil=' + getValue('hidflagProTMovil'); //'PROY-24724-IDEA-28174 
				url += '&strTipoCliente=' + getValue('hidTipoOferta'); ////'PROY-24724-IDEA-28174 
				url += '&strCoID=' + getValue('hidCO'); //SD1052592
				
				self.frames['iframeAuxiliar'].location.replace(url);
						}

			function consultaReglasCreditosCuotas(strCadenaDetalle) {
				var strCadenaPlan = cadenaPlanesDetalle(strCadenaDetalle);
				var strCadenaEquipo = cadenaEquiposDetalle(strCadenaDetalle);
				var strCadenaDatos = cadenaGeneral();

				cargarImagenEsperando();

				var url = '../iframe/sisact_ifr_consulta_reglas.aspx?';
				url += 'tipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&nroDocumento=' + getValue('txtNroDoc');
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strCadenaDatos=' + strCadenaDatos;
				url += '&strCadenaPlan=' + strCadenaPlan;
				url += '&strCadenaEquipo=' + strCadenaEquipo;
				//gaa20170215
				url += '&strBuroConsultado=' + getValue('hidBuroConsultado');
				//fin gaa20170215
				url += '&strMetodo=' + 'EvaluarCuota';	
				url += '&strFlagProTMovil=' + getValue('hidflagProTMovil'); //'PROY-24724-IDEA-28174 
				url += '&strTipoCliente=' + getValue('hidTipoOferta'); ////'PROY-24724-IDEA-28174 
				url += '&strCoID=' + getValue('hidCO');//SD1052592
				
				self.frames['iframeAuxiliar'].location.replace(url);
					}

			function asignarDatosCuotas(strCadena) {
				quitarImagenEsperando();
				
				//PROY-29123
				var datosCuotaPrecioMax = "";
				var arrDatosMonto = new Array();
				
				datosCuotaPrecioMax = strCadena.substr(strCadena.indexOf("^") + 1, strCadena.length);
				strCadena = strCadena.substr(0, strCadena.indexOf("^"));
												
				//'PROY-24724-IDEA-28174 - INICIO
				var arrCuotas = strCadena.split('*')
				var strCadena2 = arrCuotas[0];
				
				arrDatosMonto = datosCuotaPrecioMax.split("^");

	                        if (strCadena2 == '')
				{
					if(!datosCuotaPrecioMax || datosCuotaPrecioMax == ""){
					alert('<%= ConfigurationSettings.AppSettings("consMsjNoConfiguracionCuotas") %>');
					self.frames['ifraCondicionesVenta'].document.getElementById('tblCuotas').style.display = 'none';
					
					}
					else{
						
						var cuotasMax = parseInt(arrDatosMonto[0]);
						var montoMax = parseFloat(arrDatosMonto[1]);
						var mensajeBRMS = arrDatosMonto[2];
						
						if (mensajeBRMS && mensajeBRMS == "SI") {
							alert('"Cliente no califica a la opcion de cuotas seleccionada"' + '\n' + '"Cliente califica hasta ' + cuotasMax + ' cuotas con un equipo maximo de ' + montoMax.toLocaleString("es-Mx") + ' soles"');
						}
						else if(mensajeBRMS == "NO"){
					alert('<%= ConfigurationSettings.AppSettings("consMsjNoConfiguracionCuotas") %>');
						}
					}
					self.frames['ifraCondicionesVenta'].document.getElementById('tblCuotas').style.display = 'none';
					return;
				}
												
	                       if (strCadena.indexOf('*')!=-1) {
				setValue('hidPrima', arrCuotas[1]); 
				setValue('hidDeducible',arrCuotas[2]); 
				setValue('hidEvalPM',arrCuotas[3]); 
				setValue('hidCertificadoPM',arrCuotas[4]); 
				setValue('hidPrimaEval',arrCuotas[1]);
				setValue('hidDatosAdicionalesPM',arrCuotas[5]); 
				}
				
				self.frames['ifraCondicionesVenta'].llenarDatosCuota(strCadena2,arrDatosMonto);
				//'PROY-24724-IDEA-28174 - FIN
								
			}

			function obtenerFilaPaquete(strGrupoPaquete)
			{
				var idFila = '';
				strGrupoPaquete = strGrupoPaquete.replace('{','').replace('}','');
				var arrGrupoPaquete = strGrupoPaquete.split(',');
				for (i = 0; i < arrGrupoPaquete.length; i++)
				{
					if (arrGrupoPaquete[i] != '')
					{
						idFila = arrGrupoPaquete[i].replace('[','').replace(']','');
						break;
					}
				}
				return idFila;
			}
			//modificar whzr 29092014
			function asignarDatosEvaluacionSEC(blnOK, strPlanAutonomia, strGarantiaxProducto, strLCDisponible, dblImporte, strPoderes, strResultado,strTextLCDisponible,
	                                                    strRiesgoClaro, strComportamiento, strFactorRenovacion, strMSJMontoRegistrado, strRespuestaMontoR,strMontoPrima,strDeducible,strFlagEvalPM,strCertificado,strDatosAdicionales)
			{

				inicializarPanelResultado();
				inicializarPanelGrabar();
				quitarImagenEsperando();
				if (!blnOK) return;
				var VarVariable = /#/g;
				

			if (strRespuestaMontoR == "False"){
			
				habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
				alert(''+ strMSJMontoRegistrado + '');
				nuevaEvaluacion();
				return;
			}
				
				var ifr = self.frames['ifraCondicionesVenta'];
				if (ifr.getValue('hidFlagEvaluar') == '1')
					ifr.document.getElementById('hidFlagEvaluar').value = '';
				
				ifr.guardarItem();
				
				autoSizeIframe();
				var blnTipoDocRUC = (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>');
				var blnAutonomiaCE = true;

				// Garantia/Importe
				var tipoGarantia;
				var arrGarantia = strGarantiaxProducto.split('|');
				for (var i=0; i < arrGarantia.length; i++)
				{
					if (arrGarantia[i] != '')
						tipoGarantia = arrGarantia[i].split(';')[1];
				}

				//Datos Cliente BRMS
				document.getElementById('hidRiesgoClaro').value = strRiesgoClaro;
				document.getElementById('txtRiesgo').value = strRiesgoClaro;
				document.getElementById('hidComportamiento').value = strComportamiento;
				document.getElementById('txtComportamientoClaro').value = strComportamiento;
				document.getElementById('hidFactorRenovacion').value = strFactorRenovacion;
				document.getElementById('txtFactorRenovacion').value = strFactorRenovacion;

				// Autonomia
				var strAutonomia = 'S';
				var arrAutonomia = strPlanAutonomia.split('|');
				for (var i=0; i < arrAutonomia.length; i++)
				{
					if (arrAutonomia[i] != '')
					{
						var strAutonomia = arrAutonomia[i].split(';')[1];
						strAutonomia = strAutonomia.replace(VarVariable,"_");
						if (strAutonomia == 'NO_CONDICION')
						{
							// No puede acceder a las Condiciones de Venta seleccionadas
							trResultado.style.display = '';
							tdLCDisponible.style.display = 'none';
							tdTxtLCDisponible.style.display = 'none';
							setValue('txtResultado', '<%= ConfigurationSettings.AppSettings("constTextoNoAplicaCondiciones") %>');
							quitarImagenEsperando();
							return;
						}
						else if ((strAutonomia == 'SIN_REGLAS'))
						{
							setValue('hidCreditosxReglas', 'S');	// NO CUMPLE AUTONOMIA: MOTIVO --> No Existe Reglas Configuradas
							strAutonomia = 'N';
						}
						else if ((strAutonomia == 'N'))
							strAutonomia = 'N';
					}
				}

				// Controles Resultado Evaluación
				if (document.getElementById('hidAutonomia').value != undefined) document.getElementById('hidAutonomia').value = strAutonomia;
				if (document.getElementById('txtTipoGarantia').value != undefined) document.getElementById('txtTipoGarantia').value = tipoGarantia;
				
				if(parseFloat(dblImporte) > 0)
					document.getElementById('txtImporte').value = parseFloat(dblImporte).toFixed(2);
				else
					document.getElementById('txtImporte').value = '0.00';
				
				if(parseFloat(strLCDisponible) > 0)
					document.getElementById('txtLCDisponible').value = parseFloat(strLCDisponible).toFixed(2);
				else
				{
					document.getElementById('txtLCDisponible').value = '0.00';	
					if (parseInt(getValue('hidNroConsultaBRMS'), 0) < 1)
						document.getElementById('txtLCDisponible').value = '';	
				}
					
				if (document.getElementById('hidLCDisponible').value != undefined) document.getElementById('hidLCDisponible').value = strLCDisponible;
				
				if (document.getElementById('hidGarantiaxProducto').value != undefined) document.getElementById('hidGarantiaxProducto').value = strGarantiaxProducto;
				
				if (document.getElementById('hidPoderes').value != undefined) document.getElementById('hidPoderes').value = strPoderes;

				if (document.getElementById('hidTextRangoLC').value != undefined) document.getElementById('hidTextRangoLC').value = strTextLCDisponible;	
				
				if (blnTipoDocRUC)
				{
					if (getValue('hidAutonomia') == 'S' && blnAutonomiaCE)
					{
						//trPresentaPoderes.style.display = '';
						//trGarantia.style.display = '';
						if (document.getElementById('hidPoderes').value == '1')
							document.getElementById('chkPresentaPoderes').checked = true;

						//setValue('txtResultado', '<%= ConfigurationSettings.AppSettings("constTextoAprobadoAutonomia") %>');
					}
					else {
						//setValue('txtResultado', '<%= ConfigurationSettings.AppSettings("constTextoNoAprobadoAutonomia") %>');
						//trComentario.style.display = '';
						//trGarantia.style.display = 'none';
					}
				}
				else
				{
					//NO CUMPLE AUTONOMIA: MOTIVO --> Respuesta Tipo 7 y NO tiene excepción DC7
					var blnExcepcionDC7 = (document.getElementById('hidFlagExcepcionDC7').value == 'S');
					var blnRespuestaDC7 = (getValue('hidRespuestaDC') == '<%= ConfigurationSettings.AppSettings("constRespDataCredTipo7") %>');
					var blnAutonomiaDC7 = (!blnRespuestaDC7 || (blnExcepcionDC7 && blnRespuestaDC7));
					if (!blnAutonomiaDC7)
						setValue('hidCreditosxDC7', 'S');

					if ((blnAutonomiaDC7) && (getValue('hidAutonomia') == 'S') && (blnAutonomiaCE)) {
						//trGarantia.style.display = '';
						//setValue('txtResultado', '<%= ConfigurationSettings.AppSettings("constTextoAprobadoAutonomia") %>');
					} else {
						//trGarantia.style.display = 'none';
						//trComentario.style.display = '';
						//setValue('txtResultado', '<%= ConfigurationSettings.AppSettings("constTextoNoAprobadoAutonomia") %>');
					}
				}
				
				var constTextoAprobado = '<%= ConfigurationSettings.AppSettings("constTextoAprobado") %>';
				var constTextoRequiereEvaluacion = '<%= ConfigurationSettings.AppSettings("constTextoRequiereEvaluacion") %>';
				if(strResultado.toUpperCase() == constTextoAprobado.toUpperCase())
				{
					setValue('txtResultado', constTextoAprobado);
					mostrarDatosResultado();
					
					//Validar chip repuesto
					var constOperacionRenovChipRepuesto = '<%= ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto") %>';
					
					if (getValue('ddlTipoOperacion') == constOperacionRenovChipRepuesto){
						setValue('hidValidarIccid','1');
					}
					else
					{					
						setValue('hidValidarIccid','');	
						document.getElementById('trResultadoRVentaChip').style.display = 'none';
					}
				}
				else
				{
					setValue('txtResultado', constTextoRequiereEvaluacion);
					
					var nroConsultaBRMS = parseInt(getValue('hidNroConsultaBRMS'), 10) + 1;
					if (nroConsultaBRMS < 2)
					{	
						if (getValue('hidNroOperacionDC') == '')
						consultarDC();			
						else
							consultaReglasCreditos();
					}
					else
					{
						mostrarDatosResultado();
					}
					setValue('hidNroConsultaBRMS', nroConsultaBRMS);
				}
				
				//jmori LC - PERFIL 149
				
				
				
				//end jmori
				
				 //'PROY-24724-IDEA-28174 - INICIO
				 if (strFlagEvalPM != '')
			      {
						var ifr = self.frames['ifraCondicionesVenta'];
				
						var MsgPM ='';
						MsgPM=mensajesRespuestaAsurion(strFlagEvalPM);
				
						setValue('hidPrima', strMontoPrima); 
						setValue('hidDeducible',strDeducible); 
						setValue('hidEvalPM',strFlagEvalPM); 
						setValue('hidCertificadoPM',strCertificado); 
						setValue('hidPrimaEval',strMontoPrima);
						setValue('hidDatosAdicionalesPM',strDatosAdicionales);
				
				
						if (strFlagEvalPM != '1')
						{
							QuitarPMContratados();						
							
							var nroContAlertPM = parseInt(getValue('hidContAlertPM'), 10) + 1; 
							if (nroContAlertPM < 2)
							{
								alert(MsgPM);
								setValue('hidContAlertPM',nroContAlertPM);
							}
						}
						else
						{		
							var nroMostrarPopUp = parseInt(getValue('hidContPopPupPM'), 10) + 1; 
							if (nroMostrarPopUp < 2)
							{
								var strDetquip = getValue('hidDetquip');
								var arrStrDescEquip=strDetquip.split(';');
								var strDescEquipo=arrStrDescEquip[3];
				
								var montoPrima=getValue('hidPrima');
								var monto=ifr.getValue('txtCFTotal');
								var montoTotalCF= parseFloat(montoPrima) + parseFloat(monto);
								ifr.setValue('txtCFTotal', montoTotalCF.toFixed(2));
								setValue('hidContPopPupPM',nroMostrarPopUp);
								mostrarPopSeguros(strDescEquipo,strMontoPrima,strDeducible);
							}						
				
						}				
				}
				//'PROY-24724-IDEA-28174 - FIN
				
				
					
				// Asignar Factor Renovacion
				setValue('txtFactorRenovacion', getValue('hidFactorRenovacion'));
			}
			
			
				 //'PROY-24724-IDEA-28174 - INICIo
				 
				 function mostrarPopSeguros(strDescEquipo,strMontoPrima,strDeducible) { 
												
								var altoVentana = "100";
														
								var strDeducibleT = strDeducible.replace(new RegExp("['ñ']", 'g'), '='); //Remplamos 'ñ' por '=' 
							
								var opciones = "dialogHeight: " + altoVentana + "px; dialogWidth: 400px; edge: raised; center: yes; resizable: no; status: no"; 
								
								var url = 'sisact_pop_seguros.aspx?strPrima=S/.' + strMontoPrima; 
								    url += '&strDesEquipo=' + strDescEquipo;
								    url += '&strDeducible=' + strDeducibleT;
								window.showModalDialog(url, '', opciones); 
							}			 
				 
			function LimpiaDatosPM()
			{
			
				var arrControles = document.getElementById('frmPrincipal').all;
				
		        var strListaHidden=",hidValidadProtMovil,hidflagProTMovil,hidPrima,hidDeducible,hidCertificadoPM,hidEvalPM,hidCodTipoClientePM,hidMsjErrorGrabarPM,hidEquipoEvaluado,hidErrorGrabarProtMovil";
				strListaHidden = strListaHidden + ",hidPrimaEval,HidSecGra,hidDatosAdicionalesPM,hidDetquip,hidContPopPupPM,hidContAlertPM";
				
				for (var i=0; i< arrControles.length; i++)
				{
					if (arrControles[i].type == 'hidden' || arrControles[i].tagName == 'HIDDEN')
					{						
						if (strListaHidden.indexOf(arrControles[i].name) >-1)
									arrControles[i].value = '';						
					}
				}
				setValue('hidContPopPupPM', '0');
				setValue('hidContAlertPM', '0');
				quitarImagenEsperando();
			}
							 
			function mensajesRespuestaAsurion(tipo)
			{
			 var strMsgPM='';
			 
			   if (tipo=='2'){
					strMsgPM= vPM_NoCalifica;
					
				}
				else if (tipo=='3'){
					strMsgPM=vClienteWsError;
					
				}
				else if (tipo=='4'){
					var msg=vPM_NoCumpleRequisito;
					var montoPrecioPrepagoAsurion=vCodPrecioPrepagoMinimo; //PROY-24724-IDEA-28174 - Parametro
					strMsgPM = msg + " " + "S/." + montoPrecioPrepagoAsurion + "."; 
				}
				else if (tipo=='5'){
					strMsgPM=vPM_MontoPrimaMayor;
				}
			return strMsgPM;
			}
			//'PROY-24724-IDEA-28174 - FIN
			
			function mostrarDatosResultado()
			{
				habilitarBoton('btnNuevaEvaluacion', 'Nueva Evaluación', true);
				quitarImagenEsperando();
				var constTextoAprobado = '<%= ConfigurationSettings.AppSettings("constTextoAprobado") %>';
				var constTextoRequiereEvaluacion = '<%= ConfigurationSettings.AppSettings("constTextoRequiereEvaluacion") %>';
				
				document.getElementById('trGarantia').style.display = 'none';
				document.getElementById('tdRiesgo').style.display = 'none';
				document.getElementById('tdTxtRiesgo').style.display = 'none';
					
				if(getValue('txtResultado').toUpperCase() == constTextoAprobado.toUpperCase())
				{
					document.getElementById('btnRealizarVenta').style.display = '';
					document.getElementById('btnGrabarSec').style.display = '';
					document.getElementById('trGarantia').style.display = '';
					trRepresentante.style.display = 'none';	
				}
				else
				{
					if (getValue('txtResultado').toUpperCase() == constTextoRequiereEvaluacion.toUpperCase())
					{
						document.getElementById('btnEnviarACreditos').style.display = '';
					
						if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
						{
							trRepresentante.style.display = '';
						}
						else
						{
							trRepresentante.style.display = 'none';
						}	
					}
					trComentario.style.display = '';
				}
				
				mostrarControlesCreditos();
				
				trResultado.style.display = '';
			}

			function mostrarControlesCreditos()
			{
				var strDisplay = 'none';
				var constTextoAprobado = '<%= ConfigurationSettings.AppSettings("constTextoAprobado") %>';
				
				if (getValue('hidPerfilCreditos') == 'S') 
					strDisplay = '';

				document.getElementById('tdRiesgo').style.display = strDisplay;
				document.getElementById('tdTxtRiesgo').style.display = strDisplay;
				
				if (getValue('txtResultado').toUpperCase() == constTextoAprobado.toUpperCase())
				{
					document.getElementById('tdLCDisponible').style.display = strDisplay;
					document.getElementById('tdTxtLCDisponible').style.display = strDisplay;
				}
			}
			
			function verAdjuntarDocumentos(nroSEC)
			{
				var url = 'sisact_cargar_archivo_consumer.aspx?numSolicitud=' + nroSEC;
				abrirVentana(url,'','800','600','Sustento_de_Ingresos',true);
			}


			function validarDatosCliente()
			{
				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>') {
					if (!validarControl('txtRazonSocial', '', 'Ingresar la razón social del cliente.')) return false;
				} else {
					if (!validarControl('txtNombre', '', 'Ingresar nombres del cliente.')) return false;
					if (!validarControl('txtApePat', '', 'Ingresar apellido paterno del cliente.')) return false;
					if (!validarControl('txtApeMat', '', 'Ingresar apellido materno del cliente.')) return false;
				}
				return true;
			}

			function validarDatosRRLL()
			{
				setValue('hidListaRepresentante', '');
				if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("constCodTipoDocumentoRUC") %>')
				{
					var listaRepresentante = ifraRepresentante.obtenerRepresentanteSeleccionado(); //ifraRepresentante.obtenerRepresentanteSeleccionado();
					if (listaRepresentante == '')
					{
						alert('Debe seleccionar al menos un Representante Legal.');
						return false;
					}
					//PROY 31636 RENTESEG
					if(listaRepresentante == undefined){
						return false;
					}
					//PROY 31636 RENTESEG
					setValue('hidListaRepresentante', listaRepresentante);
				}
				return true;
			}

			function validarSoloPlanesFijo()
			{
			
				var strCadenaDetalle = getValue('hidCadenaDetalle');
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var strCadena = '';
				var idFila = '';
				var idProducto = '';
				var arrDetalle;
				var plan;

				for (var i = 0; i < arrCadenaDetalle.length; i++)
				{
					if (arrCadenaDetalle[i] != '')
					{
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];

						if (idProducto != codTipoProductoFijo)
							return false;

						arrDetalle = arrCadenaDetalle[i].split(';');
						plan = arrDetalle[9];

						var claseProducto = getValor(plan, 7).replace(',', '');
						if (claseProducto != '<%= ConfigurationSettings.AppSettings("constClaseProductoFijo") %>')
							return false;
					}
				}

				return true;
			}

			function validarRequiereEvaluacion()
			{
				// Representante Legal
				if (!validarDatosRRLL()) return false;

				return true;
			}

			function validarSECRecurrente(flujo)
			{
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += '&idFila=' + flujo;
				url += '&strOferta=' + getValue('ddlOferta');
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strNroDocumento=' + getValue('txtNroDoc');
				url += '&strCadenaDetalle=' + cadenaSECRecurrente();
				url += '&strMetodo=' + 'ValidarSECRecurrente';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarSECRecurrente(flujo, valor)
			{
				var nroSEC = valor.split('|')[0];
				var flgReingreso = valor.split('|')[1];
			
				if (nroSEC == '0')
				{
					setValue('hidAccion', flujo);
					document.frmPrincipal.submit();
				}
				else
				{
					if (getValue('hidAdjuntarIngreso') == 'S' && flgReingreso != '1')
					{
						setValue('hidAccion', flujo);
						document.frmPrincipal.submit();					
					}
					else
					{
						alert('Ya existe una SEC reciente con las mismas condiciones, y ésta ya fue rechazada por Créditos');

						if (flujo == 'Grabar')
							habilitarBoton('btnGrabar', 'Grabar', true);
					    else if (flujo == 'GenerarPedido')
							habilitarBoton('btnGenerarPedido', 'Generar Pedido', true);
						else
						{
							setValue('hidCreditosxAsesor', '');
							setValue('hidArchivosEnvioCreditos', '');
							setValue('hidComentarioPDV', '');
							habilitarBoton('btnEnviarCreditos', 'Enviar a Créditos', true);
						}
						return;
					}
				}
			}

			function cadenaSECRecurrente()
			{

				var strCadenaDetalle = getValue('hidCadenaDetalle');
				var arrCadenaDetalle = strCadenaDetalle.split('|');
				var strCadena = '';
				var idFila = '';
				var idProducto = '';
				var arrDetalle;

				for (var i = 0; i < arrCadenaDetalle.length; i++)
				{
					if (arrCadenaDetalle[i] != '')
					{
						idFila = arrCadenaDetalle[i].split(';')[0];
						idProducto = arrCadenaDetalle[i].split(';')[1];
						arrDetalle = arrCadenaDetalle[i].split(';');

						strCadena += idFila + ";";			//[0] - idFila
						strCadena += idProducto + ";";		//[1] - idProducto
						strCadena += arrDetalle[2] + ";";	//[2] - strPlazo
						strCadena += arrDetalle[4] + ";";	//[3] - strSolucion

						var paquete = arrDetalle[6];
						if (idProducto == codTipoProductoHFC)
							strCadena += paquete.split('_')[0] + ";";	//[4] - strPaquete
						else
							strCadena += paquete + ";";					//[4] - strPaquete

						var plan = arrDetalle[10];
						if (idProducto == codTipoProductoHFC)
							strCadena += plan.split('.')[2] + ";";	//[5] - strPlanCodigo
						else
							strCadena += plan + ";";				//[5] - strPlanCodigo

						strCadena += arrDetalle[15] + ";";		//[6] - strCampana
						strCadena += arrDetalle[25] + ";";		//[7] - strPrecioLista
						strCadena += arrDetalle[26] + ";";		//[8]- strPrecioVenta

						if (idProducto == codTipoProductoDTH || idProducto == codTipoProductoHFC) {
							strCadena += '00' + ";";			//[9]- strCuotas
							strCadena += '100' + ";";			//[10]- strPorcentajeCuotas
						} else {
							strCadena += arrDetalle[28] + ";";	//[9]- strCuotas
							strCadena += arrDetalle[29] + ";";	//[10]- strPorcentajeCuotas
						}
						strCadena += arrDetalle[14] + "|";		//[11] - strTopeConsumo
					}
				}
			
				return strCadena;
			}

			//Bloqueamos la tecla BACKSPACE en la ventana
			function cancelarBackSpace()
			{
				if ((event.keyCode == 8 || (event.keyCode == 37 && event.altKey) || (event.keyCode == 39 && event.altKey))
					&& (event.srcElement.form == null || (event.srcElement.isTextEdit == false && !event.srcElement.readOnly)))
				{
					event.cancelBubble = true;
					event.returnValue = false;
				}
			}

			function window.confirm(str)
			{
				execScript('n = msgbox("' + str + '","4132")', "vbscript");
				return (n == 6);
			}

			function cargarImagenEsperando()
			{
				var loading1 = document.createElement("div");
				loading1.id = "loading1";
				loading1.style.position = "absolute";
				loading1.style.right = "0px";
				loading1.style.top = "0px";
				loading1.style.zIndex = "9998";
				loading1.style.width = screen.width;
				loading1.style.height = screen.height;
				loading1.className = 'transparente';
				document.body.appendChild(loading1);

				var loading = document.createElement("div");
				loading.id = "loading";
				loading.style.position = "absolute";
				loading.style.right = screen.width /3;
				loading.style.top = screen.height;
				loading.style.zIndex = "9999";
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

			function verDetalleGarantia()
			{
				var w = 500;
				var h = 160;
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
				var url = 'sisact_consulta_detalle_garantia.aspx?';
				url += 'nroDocumento=' + getValue('txtNroDoc');
				url += '&garantiaxProducto=' + getValue('hidGarantiaxProducto');
				window.open( url, '_blank',opciones);
			}

			function f_MostrarTab(tipoProducto)
			{
				if (isEnabled('td' + tipoProducto))
				{				
					self.frames['ifraCondicionesVenta'].f_MostrarTab(tipoProducto);
				}
			}

			function agregarPlan()
			{

				if(getValue('ddlCanal') == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
					if ( !ValidaCampo('document.frmPrincipal.ddlTipoRenovacion','Debe indicar si el cliente es Regular o Retenido.') ) {
						setValue('ddlTipoRenovacion','00');
						return false;
					}else{
							self.frames['ifraCondicionesVenta'].agregarFila1(true);
							setEnabled('btnAgregarPlan', false, '');
							setEnabled('ddlGProducto', false, '');
							document.getElementById('trEvaluarResultado').style.display ='';
							var ifrConVenta = self.frames['ifraCondicionesVenta'];
							var tipoProd = ifrConVenta.getValue('hidTipoProductoActual');
							switch (tipoProd)
							{
								case 'Movil':
											if (isVisible('tdBAM')) { setEnabled('tdBAM', false, ''); }
											if (isVisible('tdDTH')) { setEnabled('tdDTH', false, ''); }
											if (isVisible('tdHFC')) { setEnabled('tdHFC', false, ''); }
											if (isVisible('tdFijo')) { setEnabled('tdFijo', false, ''); } 
											break;		
								case 'BAM': 
											if (isVisible('tdMovil')) { setEnabled('tdMovil', false, ''); }
											if (isVisible('tdDTH')) { setEnabled('tdDTH', false, ''); }
											if (isVisible('tdHFC')) { setEnabled('tdHFC', false, ''); }
											if (isVisible('tdFijo')) { setEnabled('tdFijo', false, ''); }
											break;
							}
							
							habilitarBoton('btnEvaluar', 'Evaluar', true);
						}
					
						
				}else{
				self.frames['ifraCondicionesVenta'].agregarFila1(true);
				setEnabled('btnAgregarPlan', false, '');
				
				//campaña post post 18/12/2015
				setEnabled('ddlGProducto', false, '');
				//campaña post post 18/12/2015
				
				document.getElementById('trEvaluarResultado').style.display ='';
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				var tipoProd = ifrConVenta.getValue('hidTipoProductoActual');
				switch (tipoProd)
				{
					case 'Movil':
								if (isVisible('tdBAM')) { setEnabled('tdBAM', false, ''); }
								if (isVisible('tdDTH')) { setEnabled('tdDTH', false, ''); }
								if (isVisible('tdHFC')) { setEnabled('tdHFC', false, ''); }
								if (isVisible('tdFijo')) { setEnabled('tdFijo', false, ''); } 
								break;		
					case 'BAM': 
								if (isVisible('tdMovil')) { setEnabled('tdMovil', false, ''); }
								if (isVisible('tdDTH')) { setEnabled('tdDTH', false, ''); }
								if (isVisible('tdHFC')) { setEnabled('tdHFC', false, ''); }
								if (isVisible('tdFijo')) { setEnabled('tdFijo', false, ''); }
								break;
				}
				
				habilitarBoton('btnEvaluar', 'Evaluar', true);
			}

				}

			function autoSizeIframe()
			{
				var id = document.getElementById('ifraCondicionesVenta');
				if (!window.opera && document.all && document.getElementById) {
					id.style.height = id.contentWindow.document.body.scrollHeight;
				} else if(document.getElementById) {
					id.style.height = id.contentDocument.body.scrollHeight + "px";
				}
			}

			function mostrarAllTabProducto(visible)
			{
				setVisible('tdMovil', visible);
				setVisible('tdFijo', visible);
				setVisible('tdDTH', visible);
				setVisible('tdBAM', visible);
				setVisible('tdHFC', visible);
			}

			function mostrarAllTabInactivo()
			{
				document.getElementById('tdMovil').className = 'tab_inactivo';
				document.getElementById('tdFijo').className = 'tab_inactivo';
				document.getElementById('tdBAM').className = 'tab_inactivo';
				document.getElementById('tdDTH').className = 'tab_inactivo';
				document.getElementById('tdHFC').className = 'tab_inactivo';
			}

			function mostrarTabActivo(idProducto)
			{
				document.getElementById(idProducto).className = 'tab_activo';
			}

			function mostrarTabxOferta() {
				mostrarAllTabProducto(false);
				trTabProducto.style.display = '';
				trLCDisponible.style.display = 'none'; 
				trCarrito.style.display = '';
    var codTipoDocumento = getValue('ddlTipoDocumento');

    if (getValue('ddlOferta') != '') {
					var strTipoProducto = getValue('hidListaTipoProducto');
        //PROY 31636 RENTESEG
        if (Key_codigoDocMigratorios.indexOf(codTipoDocumento) > -1) {
            strTipoProducto = strTipoProducto.split('|')[0];
        }

        if (codTipoDocumento == Key_codigoDocPasaporte07) {
            if (Key_flagPermitirProductosLTE == '0') {
                strTipoProducto = strTipoProducto.split('|')[0];
            }
        }

        //PROY 31636 RENTESEG
					var arrTipoProducto = strTipoProducto.split('|');
        if (strTipoProducto != '') {
            for (var i = 0; i < arrTipoProducto.length; i++) {
							var idProducto = arrTipoProducto[i].split(';')[0];
							if (getValue('hidEvaluarMovil') == 'N') //Cliente solo accede a Productos Fijos
							{
								if (idProducto == codTipoProductoFijo || idProducto == codTipoProductoHFC)
									mostrarTabProducto(idProducto, true);
							}
                else {
                    if (getValue('ddlTipoOperacion') == '<%= ConfigurationSettings.AppSettings("constTipoOperacionMIG") %>') {
									if (idProducto == codTipoProductoMovil || idProducto == codTipoProductoBAM)
										mostrarTabProducto(idProducto, true);
								}
                    else if (getValue('ddlTipoOperacion') == '<%= ConfigurationSettings.AppSettings("constTipoOperacionRenovacion") %>') {
									if (idProducto == codTipoProductoMovil || idProducto == codTipoProductoBAM)
										mostrarTabProducto(idProducto, true);
								}
								else
									mostrarTabProducto(idProducto, true);
							}
						}

						if (isVisible('tdMovil')) { self.frames['ifraCondicionesVenta'].f_MostrarTab('Movil'); return; }
						if (isVisible('tdBAM')) { self.frames['ifraCondicionesVenta'].f_MostrarTab('BAM'); return; }
						if (isVisible('tdDTH')) { self.frames['ifraCondicionesVenta'].f_MostrarTab('DTH'); return; }
						if (isVisible('tdHFC')) { self.frames['ifraCondicionesVenta'].f_MostrarTab('HFC'); return; }
						if (isVisible('tdFijo')) { self.frames['ifraCondicionesVenta'].f_MostrarTab('Fijo'); return; }
					}
				}

				trTabProducto.style.display = 'none';
				trLCDisponible.style.display = 'none';
				trCarrito.style.display = 'none';
			}

			function mostrarTabProducto(idProducto, visible)
			{
				switch (idProducto)
				{
					case codTipoProductoMovil: setVisible('tdMovil', visible); break;
					case codTipoProductoBAM: setVisible('tdBAM', visible); break;
				}
			}

			function textoProducto(idProducto)
			{ 
				var strProducto = '';
				switch (idProducto)
				{
					case codTipoProductoMovil: strProducto = 'Movil'; break;
					case codTipoProductoFijo: strProducto = 'Fijo'; break;
					case codTipoProductoDTH: strProducto = 'DTH'; break;
					case codTipoProductoBAM: strProducto = 'BAM'; break;
					case codTipoProductoHFC: strProducto = 'HFC'; break;
				}
				return strProducto;
			}
			
				
			function validarTitulridad()
			{
				
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strPerfil149=' + getValue('hidPerfil_149');
				url += '&strTipoDocumento=' + getValue('ddlTipoDocumento');
				url += '&strNroDoc=' + getValue('txtNroDoc');
				url += '&strOficina=' + getValue('hidOficina');
				url += '&strTipoOficina=' + getValue('hidOficinaActual').split(',')[2];
				url += '&strNrolinea=' + getValue('hidNroLinea');
				url += '&strTipoDocumentos=' + getValue('hidTipoDocumentos');
				url += '&strMetodo=' + 'ValidarTitularidad';
				//888
				url += '&strCanal=' + getValue('hidTipoCanal');
				url += '&MesesMaxAS=' + getValue('hidMesesMaxASMax');
				
				
				
				self.frames['iframeAuxiliar'].location.replace(url);
				
				//Inicio Renovacion por Bloqueo JAZ
				trDetalleValidacionBloqueo.style.display='block';
				//Fin Renovacion por Bloqueo JAZ
				
			}
			
			function retornoTitularidad(resultado,tipocliente){
				resultadoRetornoTitularidadTipoCliente=tipocliente;	//ECM s8 tipo de cliente
				if(resultado=="True"){
					
					//Validar Blacklist Cliente Comisiones
					validarBlackListComision();
				}			
			}//fin ecm s8
			
			//ADD JMORI
	         function validarcargofijo()
			{
			   var canal = document.getElementById('hidCanal').value;
//gaa20170814
/*
			   if(canal == '01')
			   {
*/	   
//fin gaa20170814 
			    var ddlPlan;
				var ddlPlazo;
				var ddlCampana;
				var hidValorEquipo;
			    var cfnuevo;
			    var ind = 0;
				var ifr = self.frames['ifraCondicionesVenta'];
				var tipoProd = ifr.getValue('hidTipoProductoActual');
				var tabla = ifr.document.getElementById('tblTabla' + tipoProd );
				var cont = tabla.rows.length;
				if (cont >= 1){
					for (var i = 0; i < cont; i++)
					{
						fila = tabla.rows[i];

						if (ifr.getValue('hidCodigoTipoProductoActual') != ifr.codTipoProdDTH) 
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
						else 
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

						 ddlPlan = ifr.document.getElementById('ddlPlan' + idFila);
						 ddlPlazo = ifr.document.getElementById('ddlPlazo' + idFila);
						 ddlCampana = ifr.document.getElementById('ddlCampana' + idFila);
						 hidValorEquipo = ifr.document.getElementById('hidValorEquipo' + idFila);
						 cfnuevo = ifr.document.getElementById('txtCFPlanServicio' + idFila).value;
						 
						if (ddlPlazo != undefined)
						{
							if (ddlPlazo.value.length == 0)
							{
								if (!ddlPlan.disabled)
								{
									ddlPlazo.focus();
									alert('Debe seleccionar un plazo');
									return false;
								}
							}
							ind = 1;
						}
						if (ddlPlan != undefined)
						{
							if (ddlPlan.value.length == 0)
							{
								if (!ddlPlan.disabled)
								{
									ddlPlan.focus();
									alert('Debe seleccionar un plan');
									return false;
								}
							}
							ind = 1;
						}

						if (ifr.getValue('hidCodigoTipoProductoActual') != ifr.codTipoProd3Play)
						{
							if (ddlCampana != undefined)
							{
								if (ddlCampana.value.length == 0)
								{
									if (!ddlCampana.disabled)
									{
										ddlCampana.focus();
										alert('Debe seleccionar una campaña');
										return false;
									}
								}
								ind = 1;
							}
							
							if (ddlPlazo != undefined)
							{
								var plazo = ddlPlazo.value;
								var listaPlazoEquipo = '<%= ConfigurationSettings.AppSettings("constPlazoConEquipo") %>';
								if (listaPlazoEquipo.indexOf(plazo) > 0)
								{
									if (hidValorEquipo != undefined)
									{
										if (hidValorEquipo.value.length == 0)
										{
											alert('Debe seleccionar un equipo');
											return false;
										}
									}
									ind = 1;
								}
							}
						}
					}
				}
				
				if(ind = 1){
					var reintegro = document.getElementById('txtTotalReintgro').value;
					var ddlTipoRenovacion = getValue('ddlTipoRenovacion');
					var penalidadBRMS = getValue('hidPenalidadBRMS');

					if(reintegro > '0')
					{
					    //logica para mostrar popup reintegro descomentar despues 
					    if(reintegro == ''){
						    alert('Validar el reintegro del Equipo, Comunicarse con soporte de Sistemas');
							nuevaEvaluacion();
						}
						else if(reintegro > '0' && getValue('hidMesesPorVencer') > 0 && penalidadBRMS == 'S'){
					        f_PopUpReintegro(ddlTipoRenovacion);
						}
						else{
							retornoReintegro();
						}//jmori
						//retornoReintegro(); //comentar despues  jmori
					   
					}else{
						alert('El monto del Reintegro del Equipo es S/. 0.00');// descomentar despues jmorid
						document.getElementById('hidFlagExonerarReintegro').value= 'true';
						retornoReintegro();
					}
				}
//gaa20170814
/*
			   }
			   else
			   {
			        retornoReintegro();
			   }
*/
//fin gaa20170814
			}
			
			
			//END JMORI
			
			function retornoReintegro()
			{
			    if (ValidarEvaluacionSEC())
				{
					consultaReglasCreditos();
				}
				else
				{
					quitarImagenEsperando();
					return;
				}
			 
			}
			//fdq
			
			function ServRoamingEsContratado(){
			
				var ifrConVen = self.frames['ifraCondicionesVenta'];
			
				var lbxsa = ifrConVen.document.getElementById('lbxserviciosagregados1');
				var strcodsa;
				var contsa = lbxsa.options.length;
												
				for (var i = 0; i < contsa; i++)
				{
					strcodsa = lbxsa.options[i].value;
					arrcodsa = strcodsa.split('_');
				
					var codservselected = arrcodsa[3];								
					if (codservselected == '<%= configurationsettings.appsettings("codservroamingi") %>')
					{							
						if (!validarParametrosServRI())
							return;
					
					}
				
				}	
				return true;							
				//fin fdq
			}
			
			function validarParametrosServRI()
			{
				var ifrCondi = self.frames['ifraCondicionesVenta'];
				
				if (ifrCondi.document.getElementById('rbtValDeterminado').checked == false && ifrCondi.document.getElementById('rbtValIndeterminado').checked == false)
				{
				   alert('Seleccione e ingrese parametros para Servicio Roaming Internacional');
					return false;
				}
						
				ifrCondi.document.getElementById('tblRoamingI').style.display = 'none';
				return true;
			}
			
			//fdq
			function EvaluarSec(){
			//debugger;		
					//PROY-31948			
					Anthem_InvokePageMethod('CheckCuotasPendientes', [], function(result){
					//debugger; 
						var strRpta = result.value;
							if (strRpta != ""){
							var arrRpta = strRpta.split(';');
								if (arrRpta[0] == '0'){
									trResultado.style.display = 'none'; 
									trComentario.style.display = 'none'; 
									document.getElementById('btnEnviarACreditos').style.display = 'none'; 
									document.getElementById('btnRealizarVenta').style.display = 'none'; 
									document.getElementById('btnGrabarSec').style.display = 'none'; 									
									alert(arrRpta[1]);									
									nuevaEvaluacion();
									return;
								}
								else{ 
									if(arrRpta[0] == '2'){									
									nuevaEvaluacion();
									alert(arrRpta[1]);
									return;
									}
								}
						}
						
				if(!ServRoamingEsContratado()){return;}
				
				var ifr = self.frames['ifraCondicionesVenta'];
			
				if (ifr.validarEquipoSinStock() > 0) {
					var strMensaje = '<%= ConfigurationSettings.AppSettings("constMsjEquipoSinStock") %>';
					if (!confirm(strMensaje)) {
						return;
					}
				}

			   setEnabled('ddlTipoRenovacion', false, '');
			   setEnabled('chkPlanNoVigente', false, '');
			   
			   setEnabled('ddlGProducto', false, '');
			   setEnabled('ddlModalidad', false, '');
			   
                           var constOperacionRenovChipRepuesto = '<%= ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto") %>';
					
					if (getValue('ddlTipoOperacion') == constOperacionRenovChipRepuesto && getValue('ddlModalidad') == constModalidadPagoEnCuota){
						alert('<%= ConfigurationSettings.AppSettings("msjcuotas") %>')
					}

				cargarImagenEsperando();
				  var canal = document.getElementById('hidCanal').value;
	               validarcargofijo();
						});
                    //FIN PROY-31948					
			}
			
			function cerrarConsultaPuntosCC(){
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				ifrConVenta.document.getElementById('tblPuntosCC').style.display = 'none';
				ifrConVenta.autoSizeIframe();
			}	
			
			// Javascript para equipos
			
			function cargarPrecio() {
				
				if (getValue('ddlPrecio') == "00" || getValue('ddlPrecio') == '' || getValue('ddlPrecio') == undefined){
					resetearMontos();
					return;
				}
					//Obtener la lisa de precios
					var listaPreciosSelected = getValue('ddlPrecio') + "," + getText('ddlPrecio');
					setValue('hidlistaPrecioSelected', listaPreciosSelected);
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				// Obtener la Campania Seleccionada
				var campaniaSelected = ifrConVenta.getValue('ddlCampana1') + "," + ifrConVenta.getText('ddlCampana1');
				setValue('hidCampaniaSelected', campaniaSelected);
				
				setValue('txtTotalAPagar','');
				setValue('txtPrecioVenta','');
				
 
				var params = "";
				
				params = getValue('ddlPuntoVenta') + "," +
							getValue('txtMaterialImei') + "," +
							getValue('ddlPrecio') + "," +
							getValue('txtImei') + "," +
							getValue('txtNroLinea') + "," +
							getValue('hidTipoDocVenta') + "," +
							getValue('txtMaterialICCID') + "," +
							getValue('txtSerieChip') + "," +
							'';
				
				consultarPrecios(params);
			}
			
			function consultarPrecios(params) {
				var tipoOficina = getValue('hidOficinaActual').split(',')[2];
				document.getElementById('ifrConsultarPrecio').src = "../../post_venta/chip_repuesto/sisact_ifr_consulta_precio.aspx?params="+params+"&renov=RP"+"&tipoOficina="+tipoOficina;
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
			}
			
			function resetearMontos() {
				setValue('hidPrecioVenta', '');
				setValue('hidPrecioTotal', '');
				setValue('txtPrecioVenta','0');
				setValue('txtTotalAPagar', '0');					
			}
			
			function habilitarDescuento()
			{
				//setValue('hidDescuento','');
				//setValue('hidFlagDescuento','false');
				
				
				
				//setValue('hidDescuento','');
				//setValue('txtDescuentoEquipo','');
				
				//habilitarBoton('btnDescuentoEquipo', 'Validar Descuento', true);
				//setReadOnly('txtDescuentoEquipo', false, 'clsInputEnableB');
				
				
			}
			
			function responseConsultarPrecios(datos) {
				
				resetearMontos();
				habilitarDescuento();
				
				
				
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				
				var strCanal = getValue('ddlCanal');
				if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
					
					 
						setValue('hidDatosEquipo', datos);
						if (getValue('hidDatosEquipo') != ''){
							var listaPrecio = getValue('ddlListaPrecio');
							var datosEquipo = getValue('hidDatosEquipo');
							var arrayPrecio = datosEquipo.split(',');
						}
					 
					
					 
					
				}else{
					 
						setValue('hidDatosEquipo', datos);
						if (getValue('hidDatosEquipo') != ''){
				var listaPrecio = getValue('ddlPrecio');
							var datosEquipo = getValue('hidDatosEquipo');
							var arrayPrecio = datosEquipo.split(',');							
						
						}
					 
				}

				if (listaPrecio != "00" || listaPrecio != ''){
					// Obtener Precio de Venta - Precio de Lista
					//var arrayPrecio = datos.split(',');
					
					//Evaluando Subsidio
					var  existePrecioVenta = (getValue('hidPrecioVentaEv') != undefined && Trim(getValue('hidPrecioVentaEv')) != '');
					var existePrecioLista = (getValue('hidPrecioListaEv') != undefined && Trim(getValue('hidPrecioListaEv')) != '');
					
					//INC000000715147 - INICIO
						var fltPrecioVentaEva = parseFloat(getValue('hidPrecioVentaEv'));
						var fltPrecioCompraEva = parseFloat(getValue('hidPrecioListaEv')); 
						
						var fltPrecioVenta = parseFloat(arrayPrecio[1]);
						var fltPrecioCompra = parseFloat(arrayPrecio[2]);	
						
						var factorCostoSubsidio = parseFloat('<%= ConfigurationSettings.AppSettings("constFactorCostoSubsidio") %>');
												
						if(fltPrecioCompraEva >= (factorCostoSubsidio*fltPrecioCompra))
						{
							var dblFactorSubsidioEval = parseFloat(fltPrecioVentaEva / fltPrecioCompraEva).toFixed(2);
							var dblFactorSubsidioVenta = parseFloat(fltPrecioVenta / fltPrecioCompra).toFixed(2);

							if (dblFactorSubsidioVenta < dblFactorSubsidioEval)
							{
								alert('No cumple condiciones iniciales de la evaluación');
								limpiarSubsidio();
								return;
							}
						}
						else 
						{
								alert('No cumple condiciones iniciales de la evaluación');
							limpiarSubsidio();
								return;			
							}	
					//INC000000715147 - FIN
					
					setValue('hidDatosEquipo', datos);
					
					//setValue('txtPrecioVenta', arrayPrecio[1]);
					//setValue('hidPrecios', datos);
					//setValue('txtTotalAPagar', arrayPrecio[1]);
					
					//consolidado 16122014
					
					setValue('txtPrecioVenta', arrayPrecio[1]);
					setValue('txtTotalAPagar', arrayPrecio[1]);
					setValue('txtPrecioVentaEquipo', arrayPrecio[1]);
					setValue('txtPrecioVentaEquipoDAC', arrayPrecio[1]);

					//consolidado 16122014
					
					
					setValue('hidPrecioVenta', arrayPrecio[1]);
					setValue('hidPrecioTotal', arrayPrecio[1]);
				
					// Actualizar el total a pagar txtTotalAPagar	
					if (ifrConVenta.getValue('hidTieneReserva') != "1") {
						var precioVenta = parseFloat(getValue('txtPrecioVenta'));
						var descuentoClaroClub;
						if(getValue('txtDescuentoClaroClub')!="0"){
							descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
						}else{
							descuentoClaroClub = 0;
						}
						
						//Inicio Renovacion B2E JAZ
						if (getValue('ddlOferta') == '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>'){
							descuentoClaroClub = 0;
						}
						//Fin Renovacion B2E JAZ
						
						var PrecioNeto = precioVenta - descuentoClaroClub;
						
						if(PrecioNeto < 0){
							setValue('hidPrecioTotal', '0');
							setValue('txtTotalAPagar', '0');
						}else{
							 
						 setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
						 setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
						 
					
					
						if (getValue('hidValidarIccid') == "1"){
												if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
													
												
												if(getValue('txtpreciochip') != ""){
														var PrecioNetochip = parseFloat(PrecioNeto) + parseFloat(getValue('txtpreciochip'));
												
													
												
													
													setValue('hidPrecioTotal', PrecioNetochip.toFixed(2));
													setValue('txtTotalAPagar', PrecioNetochip.toFixed(2));
													setValue('txtPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													setValue('hidPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													}
													
												}else{
											
											
													if(getValue('txtPrecioVentaChip') != ""){
												
														var PrecioNetochip  = parseFloat(PrecioNeto) + parseFloat(getValue('txtPrecioVentaChip'));
													
											
													
													setValue('hidPrecioTotal', PrecioNetochip.toFixed(2));
													setValue('txtTotalAPagar', PrecioNetochip.toFixed(2));
													setValue('txtPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													setValue('hidPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													}
												}
							
							 }
					}
							 
					}
					
					habilitarBoton('btnGenerarPedido', 'Generar Pedido', true);
				}
				else{
					setValue('txtPrecioVenta', '0');
					setValue('txtTotalAPagar', '0');
				}
			}
			
			//INC000000715147 - INICIO
			function limpiarSubsidio(){
				if (getValue('ddlCanal') == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>') {
					var cboIMEIArts = document.getElementById("cboIMEIArt");
					cboIMEIArts.length = 0;

					var ddlListaPrecio = document.getElementById("ddlListaPrecio");
					ddlListaPrecio.length = 0;

					var cboICCIDChips = document.getElementById("cboICCIDChip");
					cboICCIDChips.length = 0;

					var ddlPrecioChips = document.getElementById("ddlPrecioChip");
					ddlPrecioChips.length = 0;

					habilitarBoton('btnDescuentoEquipo', 'Validar Descuento', true);

					setValue('txtpreciochip', '');
					setValue('txtCodChip', '');
					setValue('txtDescuentoEquipo', '');
					setReadOnly('txtDescuentoEquipo', false, 'clsInputEnable');
					setValue('txtPrecioVentaEquipo', '');
					setValue('txtCodEquipo', '');

				} else {
					var ddlListaPrecios = document.getElementById("ddlPrecio");
					ddlListaPrecios.length = 0;

					var ddlPrecioChips = document.getElementById("ddlPrecioChips");
					ddlPrecioChips.length = 0;

					setValue('txtImei', '');
					setValue('txtMaterialImei', '');
					setValue('txtArticuloImei', '');
					setValue('hidlistaPrecioSelected', '');
					setValue('hidDatosEquipo', '');
					setValue('txtSerieChip', '');
					setValue('txtMaterialICCID', '');
					setValue('txtArticuloICCID', '');
					document.getElementById('lblPlanChip').innerHTML = '';
				}
								
			}
			//INC000000715147 - FIN
			
			function BuscarImei() {
				setValue('txtPrecioVentaEquipoDAC','');
				
				habilitarBoton('btnBuscarImei', 'Procesando...', false);
				if (getValue('txtImei') == "") {
					habilitarBoton('btnBuscarImei', 'Validar Imei', true);
					alert("Ingrese el IMEI");
					setFocus('txtImei');
					return;
				}
				
				setValue('txtImei', '000000000000000000'.substr(getValue('txtImei').length) + getValue('txtImei'));
				buscarImei(getValue('txtImei'));
				
			}
			
			function buscarImei(codImei) {
				setValue('txtMaterialImei', '');
				setValue('txtArticuloImei', '');

				document.getElementById("ifrBuscarImei").src= "../../venta/prepago/sisact_ifr_consulta_imei.aspx?codImei="+codImei + '&hidCanal=' + getValue('ddlCanal')+'&hidOfVentaCod=' + getValue('ddlPuntoVenta') + "&nroHLR="+''+"&usaHLR="+'RP';
				document.getElementById("ifrBuscarImei").contentWindow.opener = window;
			}
			
			function RealizarVenta()
			{
			
			cargarListadoEquipo();
			cargarListadoChips();
			
				habilitarBoton('btnRealizarVenta', 'Procesando...', false);
				setValue('hidModalidadVenta', getValue('ddlModalidad'));
				setValueHTML('lblHLR', "HLR: " + getValue('hidHLR'));
                setValueHTML('lblHLRCAC', "HLR: " + getValue('hidHLR'));
                
                //if(getValue('hidMantenerPlan') == "N"){
                 setValueHTML('lblPlanLTE', "Tecnología 4G:" + getValue('hidPl4G'));
				 setValueHTML('lblPlanLTECAC', "Tecnología 4G:" + getValue('hidPl4G'));
				//}
                  if(getValue('txtDescuentoClaroClub') == "0"){
							setEnabled('txtClaroClubPuntosUtilizar', false, 'clsInputDisabled');
				   }
				            
				 //consolidado 13012015
				 /*           
				if(getValue('ddlTipoRenovacion') == '<%= ConfigurationSettings.AppSettings("constRenoRetenido") %>')
				{
					tdDescuento.style.display = '';
				}else{
					tdDescuento.style.display = 'none';
				}
				*/
				//consolidado 13012015
				            
				//Inicio - RIHU 29122014 - Se adiciono una nueva Funcion Continuar_RealizarVenta()
				if ( '<%= ConfigurationSettings.AppSettings("VCLIENTE") %>' == '1')
				{
					habilitarBoton('btnGrabarSec', 'Procesando...', false);
					setValue('hidGrabar', '1');
					
					//Anthem_InvokePageMethod('GrabarSEC', [], Call_Grabasec(result));
					Anthem_InvokePageMethod('GrabarSEC', [], 
					function(result){
						var arrayDatos = result.value.split('-');
						setValue('hidValidarCliente', arrayDatos[0]);
						setValue('hidNroSEC', arrayDatos[1]);
						setValue('hidAuditoriaLogs', arrayDatos[2]);
                                                 setValue('hidCodTipoClientePM', arrayDatos[3]); //'PROY-24724-IDEA-28174 
						f_valida(arrayDatos[0]); 	}
					);
					}
                                else{
					Continuar_RealizarVenta();
				}
				//Fin - RIHU 29122014
			}

			
			//inicio consolidado idValidator 07012015
			
			function f_IdValidator(){
				var url = '<%= ConfigurationSettings.AppSettings("consurlIdValidator") %>'  //'sisact_pop_id_validator.aspx';
				var param;
				param = '?nroSec=' + getValue('hidNroSEC');			
				
				url = url + param;							
				var opciones = "dialogHeight: 700px; dialogWidth: 800px; edge: Raised; center:Yes; help: No; resizable=no; status: No";
				var vRetorno				
				cargarImagenEsperando();
				vRetorno = window.showModalDialog(url, '', opciones);				
				quitarImagenEsperando();
				if(vRetorno != 'undefined' && vRetorno != null){  //OK|N
					if(vRetorno.indexOf('|') > -1){
						var arrayRespuesta
						arrayRespuesta = vRetorno.split('|');						
						setValue('hidFlagIdValidator_RespPDV' , arrayRespuesta[1])
						if(arrayRespuesta[0] == 'OK'){							
							return true;
						}else{							
							f_IdValidator();
						}
					}else{
						return false;
					}
				}else{
					return false;
				}				
			}  
			
			//fin consolidado idValidator 07012015
			
			//Inicio RIHU - 29122014 - EVERIS - Cambio en RealizarVenta()
			function Continuar_RealizarVenta(){
				
				
				var ifr = self.frames['ifraCondicionesVenta'];
				var codTipoProductoActual = ifr.getValue('hidCodigoTipoProductoActual');
				setValue('hidBAM', codTipoProductoActual);
				
				
				
			   if(getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>'){
					if(codTipoProductoActual != codTipoProductoBAM){
						if (getValue('ddlModalidad') == constModalidadPagoEnCuota){
							document.getElementById('tblClaroPuntosDescuento').style.display = 'none';
							document.getElementById('tblClaroPuntosDescuento1').style.display = 'none';
							document.getElementById('tdPrecioVentaCAC').style.display = 'none';
							document.getElementById('tdtxtPrecioVentaCAC').style.display = 'none';
							document.getElementById('tdbtnValidarDescuentoCAC').style.display = 'none';	
							
							
							//INC000000830856
							if 	('<%= ConfigurationSettings.AppSettings("FlgDescuentoClaroClub") %>' == '1') 
							{
								if (getValue('ddlOferta') != '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>'){
									document.getElementById('tblClaroPuntosDescuento').style.display = 'block';
									document.getElementById('tblClaroPuntosDescuento1').style.display = 'block';
									document.getElementById('txtClaroClubPuntosUtilizar').value = ifr.getValue('txtClaroClubSaldoActual');
									ifr.CalcularClaroClubPuntos(document.getElementById('txtClaroClubPuntosUtilizar'), '0');
								}
							}	
							//INC000000830856
							
						}else{
						//gaa20160804
						if (getValue('ddlOferta') != '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>'){
						//fin gaa20160804
						document.getElementById('tblClaroPuntosDescuento').style.display = 'block';
						document.getElementById('tblClaroPuntosDescuento1').style.display = 'block';
				document.getElementById('txtClaroClubPuntosUtilizar').value = ifr.getValue('txtClaroClubSaldoActual');
							ifr.CalcularClaroClubPuntos(document.getElementById('txtClaroClubPuntosUtilizar'), '0');
						//gaa20160804
						}
						//fin gaa20160804
						}
						
					}else{
						document.getElementById('tblClaroPuntosDescuento').style.display = 'none';
						document.getElementById('tblClaroPuntosDescuento1').style.display = 'none';						
					}
			   }else{
					document.getElementById('tblClaroPuntosDescuento').style.display = 'none';
					document.getElementById('tblClaroPuntosDescuento1').style.display = 'none';
			   }
				
				//consolidado 12122014
				var strCanal = getValue('ddlCanal');
				if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
				
					setValue('txtNumeroLineaChip', getValue('txtNroLinea'));
				
					document.getElementById('trResultadoRVenta').style.display = 'none';
					document.getElementById('trDetalleVentaEquipo').style.display = '';
					
									//PROY-24724-IDEA-28174 - INICIO
									if(getValue('hidEvalPM') == "1"){ 
											document.getElementById('trProteccionMovil').style.display = '';
											setValue('txtPrima', getValue('hidPrima'));				
											setValue('txtDeducible',getValue('hidDeducible') );
											document.getElementById('chkProMovil').checked = true;
											document.getElementById('txtPrima').style.display = '';
											document.getElementById('txtDeducible').style.display = '';
											document.getElementById('lblPrima').style.display = '';
											document.getElementById('lblDeducible').style.display = '';		
									}  
									else {document.getElementById('trProteccionMovil').style.display = 'none'; }  
									//PROY-24724-IDEA-28174 - FIN
						
					if (getValue('hidValidarIccid') == "1"){
						document.getElementById('trDetalleVentaChip').style.display = '';
					}else{
						document.getElementById('trDetalleVentaChip').style.display = 'none';
					}
					
				}else{
				document.getElementById('trResultadoRVenta').style.display = '';
					document.getElementById('trDetalleVentaEquipo').style.display = 'none';
				
					if (getValue('hidValidarIccid') == "1"){
						document.getElementById('trResultadoRVentaChip').style.display = '';
					}else{
						document.getElementById('trResultadoRVentaChip').style.display = 'none';
					}
				}
				//consolidado 12122014
				document.getElementById('btnGrabarSec').style.display = 'none';
				document.getElementById('trGenerarPedido').style.display = '';
				//consolidado 12122014
				document.getElementById('trDetalleDatosVenta').style.display = '';
				//consolidado 12122014
				
				setValue('hidNombre', getValue('txtNombre'));
				setValue('hidApePaterno', getValue('txtApePat'));
				setValue('hidApeMaterno', getValue('txtApeMat'));
				setValue('hidRazonSocial', getValue('txtRazonSocial'));

				setValue('hidGrupoPaqueteServer', ifr.getValue('hidGrupoPaquete'));
				setValue('hidServicioServer', ifr.getValue('hidPlanServicio'));
				setValue('hidPromocionServer', ifr.getValue('hidPromocion'));
				
				var codTipoProductoActual = ifr.getValue('hidCodigoTipoProductoActual');
				if (codTipoProductoActual == codTipoProductoBAM)
				{
					setValue('txtClaroClubPuntosUtilizar', '0');
					setEnabled('txtClaroClubPuntosUtilizar', false, 'clsInputDisabled');
					ifr.CalcularClaroClubPuntos(document.getElementById('txtClaroClubPuntosUtilizar'));
				}
				else
				{
					if(getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>'){
					var TieneReserva = (Trim(ifr.getValue('hidTieneReserva')) == '1');
					if (TieneReserva)
					{
						setValue('txtClaroClubPuntosUtilizar', '0');
						setEnabled('txtClaroClubPuntosUtilizar', false, 'clsInputDisabled');
						ifr.CalcularClaroClubPuntos(document.getElementById('txtClaroClubPuntosUtilizar'));
					}
					else
					{
						setEnabled('txtClaroClubPuntosUtilizar', true, 'clsInputEnableB');
					}
				}
				}
					if(getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>'){
						if (codTipoProductoActual != codTipoProductoBAM)
						{
				cerrarConsultaPuntosCC();
			}
					}
			}
			//Fin RIHU - 29122014 - EVERIS - Cambio en RealizarVenta()
			
			//Inicio - RIHU 29122014
			function f_valida(resultado)
			{
				if (resultado > 0)
				{
					f_ValidarCliente();

				}else {
					Continuar();
				}
			}
			
			function GenerarPedido()
			{
			//debugger;
				setValue('hidNacSeleccionado',getValue('ddlNacionalidad')+';'+getText('ddlNacionalidad'));//PROY 31636 RENTESEG
				if(getValue('ddlCanal') == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
					if ( !ValidaCampo('document.frmPrincipal.ddlCodEquipo','Debe seleccionar un Equipo.') ) return false;
					
					
					if ( document.getElementById('cboIMEIArt').length == 0 || getText('cboIMEIArt')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>' || 
						getText('cboIMEIArt')== '' ){
						alert('Debe seleccionar una Serie de Equipo válida');
						return false;
					}
					
					
					if ( !ValidaCampo('document.frmPrincipal.ddlListaPrecio','Debe seleccionar una Lista de Precio.') ) {
						setValue('ddlListaPrecio','00');
						return false;
					}
					
					if (getValue('hidRespuestaChip') == '<%= ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto") %>'){
						if ( !ValidaCampo('document.frmPrincipal.ddlCodChip','Debe seleccionar un Chip.') ) return false;
					
						if ( document.getElementById('cboICCIDChip').length == 0 || getText('cboICCIDChip')== '<%= ConfigurationSettings.AppSettings("Seleccionar") %>' || 
							getText('cboICCIDChip')== '' ){
							alert('Debe seleccionar una Serie de Chip válida');
							return false;
						}
						
						if ( !ValidaCampo('document.frmPrincipal.ddlPrecioChip','Debe seleccionar una Lista de Precio del Chip.') ) {
							setValue('ddlPrecioChip','00');
							return false;
						}
					
					}
					//consolidado 30012015
					if(getValue('hidFlagValDcto') == 'false'){
						setFocus('btnDescuentoEquipo');
						alert("Usted ha ingresado un descuento, pero aun no a sido validado, por favor Validar Descuento.");
						return false;
					}
					//consolidado 30012015
					
					// Inicio E77568 

					if ( !ValidaCampo('document.frmPrincipal.ddlTipoRenovacion','Debe indicar si el cliente es Regular o Retenido.') ) {
						setValue('ddlTipoRenovacion','00');
						return false;
					}
					
					
				
				}else{

                if (getValue('hidRespuestaChip') == '<%=ConfigurationSettings.AppSettings("consCodTipoOperacionRenovChipRepuesto")%>'){
				
					var ddlPrecioSeleccionado = document.getElementById('ddlPrecioChips');
				if (ddlPrecioSeleccionado.value == "00" || ddlPrecioSeleccionado.value == '' || ddlPrecioSeleccionado.value == undefined) {
					alert('Seleccione el Precio de Lista');
					return;
				}
				
				
				
				}
				var imei = Trim(document.getElementById('txtImei').value);
				if (imei == ''){
					alert('Ingrese el IMEI');
					setFocus('txtImei');
					return;
				}
				
				var materialImei = Trim(document.getElementById('txtMaterialImei').value);
				if (materialImei == ''){
					alert('El Material esta vacío, valide el IMEI');
					return;
				}
				
				var articuloImei = Trim(document.getElementById('txtArticuloImei').value);
				if (articuloImei == ''){
					alert('El Artículo esta vacío, valide el IMEI');
					return;
				}
				
				var ddlPrecioSeleccionado = document.getElementById('ddlPrecio');
				if (ddlPrecioSeleccionado.value == "00" || ddlPrecioSeleccionado.value == '' || ddlPrecioSeleccionado.value == undefined) {
					alert('Seleccione el Precio de Lista');
					return;
				}
				
					
				}
				
		
					
				
				var precioVenta = Trim(document.getElementById('txtPrecioVenta').value);
				var precioEquipo = parseFloat(getValue('txtPrecioVenta'));
				
				if (precioVenta == '' || precioEquipo == 0){
					alert('El Precio del Equipo es Cero o Inválido, Valide la Lista de Precios');
					return;
				}
				if (getValue('txtDescuentoClaroClub') == ""){
					setValue('txtDescuentoClaroClub', "0");
				}
				
				var descuentoCC = Trim(document.getElementById('txtDescuentoClaroClub').value);
				var desctoEquipo = parseFloat(getValue('txtDescuentoClaroClub'));
				
				if (descuentoCC == ''){
					alert("El descuento no puede estar vacio");
					return;
				}
				
				if(desctoEquipo > precioEquipo) 
				{
					alert("El monto total del descuento excede el precio de venta del equipo!");
					return;
				}
				
				setValue('hidCreditosxNombres', '');
				setValue('hidGrupoPaqueteServer', '');
				setValue('hidServicioServer', '');
				setValue('hidPromocionServer', '');
				
				habilitarBoton('btnGenerarPedido', 'PROCESANDO...', false);
				
				if (!confirm("Está seguro de generar el Pedido?") ) {
					habilitarBoton('btnGenerarPedido', 'Generar Pedido', true);
					return;
				}
				else
				{
					cargarImagenEsperando();
					setValue('hidNombre', getValue('txtNombre'));
					setValue('hidApePaterno', getValue('txtApePat'));
					setValue('hidApeMaterno', getValue('txtApeMat'));
					setValue('hidRazonSocial', getValue('txtRazonSocial'));
					setValue('hidComentarioPDV', getValue('txtComentarioPDV'));
					setValue('hidMensajeAutonomia', getValue('txtResultado'));

					setValue('hidGrupoPaqueteServer', self.frames['ifraCondicionesVenta'].getValue('hidGrupoPaquete'));
					//'PROY-24724-IDEA-28174 - INICIO
					if(document.getElementById('chkProMovil').checked==false){ 
						QuitarPMContratados();
						}					
					//'PROY-24724-IDEA-28174 - FIN
					setValue('hidServicioServer', self.frames['ifraCondicionesVenta'].getValue('hidPlanServicio'));
					setValue('hidPromocionServer', self.frames['ifraCondicionesVenta'].getValue('hidPromocion'));
					
					setValue('hidCanal', getValue('ddlCanal'))
					
					if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					{
						setValue('hidNroDocumento', getValue('txtNroDoc'));
						setValue('hidTipoDocumento', getValue('ddlTipoDocumento'));
						setValue('hidNroLinea', getValue('txtNroLinea'));
						setValue('hidAccion', 'GenerarPedido');
						document.frmPrincipal.submit();
					}
					else
						validarSECRecurrente('GenerarPedido');
						
					habilitarBoton('btnGenerarPedido', 'Generar Pedido', false);
				}
			}
			
			
			function GrabarSEC()
			{
				setValue('hidNacSeleccionado',getValue('ddlNacionalidad')+';'+getText('ddlNacionalidad'));//PROY 31636 RENTESEG
				setValue('hidAdjuntarIngreso', '');
				setValue('hidCreditosxNombres', '');
				setValue('hidGrupoPaqueteServer', '');
				setValue('hidServicioServer', '');
				setValue('hidPromocionServer', '');
				
				habilitarBoton('btnGrabarSec', 'PROCESANDO...', false);
				
				setValue('hidModalidadVenta', getValue('ddlModalidad'));
				            
				if (confirm("Esta Seguro de Grabar la Evaluacion?"))
				{
					cargarImagenEsperando();
							
					setValue('hidNombre', getValue('txtNombre'));
					setValue('hidApePaterno', getValue('txtApePat'));
					setValue('hidApeMaterno', getValue('txtApeMat'));
					setValue('hidRazonSocial', getValue('txtRazonSocial'));
					setValue('hidComentarioPDV', getValue('txtComentarioPDV'));
					setValue('hidMensajeAutonomia', getValue('txtResultado'));

					setValue('hidGrupoPaqueteServer', self.frames['ifraCondicionesVenta'].getValue('hidGrupoPaquete'));
					setValue('hidServicioServer', self.frames['ifraCondicionesVenta'].getValue('hidPlanServicio'));
					setValue('hidPromocionServer', self.frames['ifraCondicionesVenta'].getValue('hidPromocion'));

					if (getValue('ddlTipoDocumento') == '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					{
						setValue('hidAccion', 'Grabar');
						document.frmPrincipal.submit();
					}
					else
						validarSECRecurrente('Grabar');
				}
				else
				{
					habilitarBoton('btnGrabarSec', 'Grabar', true);
					return;
				}
			}
			
			function respuestaBuscarImei(datos) {
				var arrayDatos = datos.split(',');
				if(arrayDatos[0] != undefined && arrayDatos[0] != '')
					setValue('txtMaterialImei', arrayDatos[0]);
					
				if(arrayDatos[1] != undefined && arrayDatos[1] != '')
					setValue('txtArticuloImei', arrayDatos[1]);
				
				setEnabled('btnBuscarImei', true, 'Boton');
				habilitarBoton('btnBuscarImei', 'Validar Imei', true);
				cargarListaPrecio();

				
			}
			
			function responseConsultarListaPreciosIMEI(datos) {

				// Resetear la lista de precios ya agregados
				var strCanal = getValue('ddlCanal');
				
					if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
						var selObjP = document.getElementById('ddlListaPrecio');
						selObjP.length = 0;
					}else{
						var selObjP = document.getElementById('ddlPrecio');
						selObjP.length = 0;
					}
						// Poner uno a uno lista de precios disponibles
						var listaPrecios = datos.split(';');
						for (var i=0; i<listaPrecios.length; i++) {
							var opcion = listaPrecios[i].split(',');
							addOption(selObjP, opcion[0], opcion[1]);
					}				
				
			}
			
			function responseConsultarListaPrecios(datos) {
				// Resetear la lista de precios ya agregados
				
				var selObjP = document.getElementById('ddlPrecioChip');
				selObjP.length = 0;
				// Poner uno a uno lista de precios disponibles
				var listaPrecios = datos.split(';');
				for (var i=0; i<listaPrecios.length; i++) {
					var opcion = listaPrecios[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}
				cargarListaPrecioDefault();
			}
			
			function cargarListaPrecio() {
				 
				var selObjP = document.getElementById('ddlPrecio');
				selObjP.length = 0;
				var codigoImei = getValue('txtMaterialImei');

				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				var campana = ifrConVenta.getValue('ddlCampana1');
				var plan = getValor(ifrConVenta.getValue('ddlPlan1'), 2); 
				var plazoAcuerdo = ifrConVenta.getValue('ddlPlazo1');
				var oficinaVenta = getValue('ddlPuntoVenta');
				var tipoOperacion = '<%= ConfigurationSettings.AppSettings("constCodOperRenovacion") %>';
		        var strTipoDocVentaSap=	getValue('hidTipoDocVentaSap');
		        var strOficina= getValue('hidOficina');
		        var strCanalSap= getValue('hidCanalSap');
				//setValue('hidEstadoPrecio', 'RE');				
				var params = getValue('hidTipoVenta') + "," +
							plan + ",," +  
							codigoImei + "," +
							campana + "," +  
							oficinaVenta + ",," +
							tipoOperacion + "," +  
							plazoAcuerdo+ "," + 
							strTipoDocVentaSap + "," +
							strOficina + "," + 
							strCanalSap + "," +
							getValue('hidNroSEC'); 
							
							
				consultarListaPrecios(params); 
			}
			
			
			function consultarListaPrecios(params) {
				
				var items = params.split(',');
				// Si falta algun parametro excepto codigo_material ICCID, no hace la consulta y retorna la lista de precios solo: "Seleccionar"			
				for (var i=0; i < items.length; i++) {
					if (items[i] == "") {
						if (i != 2 && i != 6 && i != 12) {
							responseConsultarListaPrecios("00,<%= ConfigurationSettings.AppSettings("Seleccionar") %>");
							setValue('txtMaterialImei', '');
							setValue('txtArticuloImei', '');
							setValue('txtPrecioVenta', '0.00');
							setValue('txtTotalAPagar', '0.00');
							setValue('hidPrecioVenta', '0');
							setValue('hidPrecioTotal', '0');
							setValue('hidlistaPrecioSelected', '');
							setValue('hidPrecios', '');
							return;
						}
					}
				}
				document.getElementById("ifrConsultarListaPrecios").src= "sisact_ifr_consulta_lista_precios_rp.aspx?parametros="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window;
			}
			
			function EnviarACreditos() 
			{
				//debugger;
				setValue('hidNacSeleccionado',getValue('ddlNacionalidad')+';'+getText('ddlNacionalidad'));//PROY 31636 RENTESEG
				setValue('hidAdjuntarIngreso', '');
				setValue('hidCreditosxNombres', '');
				setValue('hidGrupoPaqueteServer', '');
				setValue('hidServicioServer', '');
				setValue('hidPromocionServer', '');
				var strTipoDoc = getValue('hidTipoDocumento');
				setValue('hidModalidadVenta', getValue('ddlModalidad'));

	           if (strTipoDoc != '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
			   {	
					if(getValue('txtNombre') == ''){
					alert('Debe ingresar un nombre');
                                        //FGP - INICIO
					setEnabled('txtNombre', true, 'clsInputEnabled');
					setEnabled('txtApePat', true, 'clsInputEnabled');
					setEnabled('txtApeMat', true, 'clsInputEnabled');
                                        //FGP - FIN
					return false;
					}else if(getValue('txtApePat') == ''){
					alert('Debe ingresar un apellido paterno');
                                        //FGP - INICIO
					setEnabled('txtNombre', true, 'clsInputEnabled');
					setEnabled('txtApePat', true, 'clsInputEnabled');
					setEnabled('txtApeMat', true, 'clsInputEnabled');
                                        //FGP - FIN
					return false;
					}else if(getValue('txtApeMat')== ''){
					alert('Debe ingresar un apellido materno');
                                        //FGP - INICIO
					setEnabled('txtNombre', true, 'clsInputEnabled');
					setEnabled('txtApePat', true, 'clsInputEnabled');
					setEnabled('txtApeMat', true, 'clsInputEnabled');
                                        //FGP - FIN
					return false;
					}
				}else{
				   if(getValue('txtRazonSocial') == ''){
					alert('Debe ingresar una razon social');
					setEnabled('txtRazonSocial', true, 'clsInputEnabled'); //FGP
					return false;
					}
				}
				
				habilitarBoton('btnEnviarACreditos', 'PROCESANDO...', false);

				if (!validarRequiereEvaluacion()) {
					habilitarBoton('btnEnviarACreditos', 'Enviar a Créditos', true);
					return;
				}

				if (confirm("Esta Seguro de Enviar a Creditos?"))
				{
					cargarImagenEsperando();
					if (strTipoDoc != '<%= ConfigurationSettings.AppSettings("TipoDocumentoRUC") %>')
					{	
						if (confirm("¿Desea adicionalmente adjuntar sustentos de ingreso?"))
							document.getElementById('hidAdjuntarIngreso').value = 'S';	
			
							
					}
					
					setValue('hidCreditosxAsesor', '');		
					setValue('hidMensajeAutonomia', getValue('txtResultado'));

					setValue('hidNombre', getValue('txtNombre'));
					setValue('hidApePaterno', getValue('txtApePat'));
					setValue('hidApeMaterno', getValue('txtApeMat'));
					setValue('hidRazonSocial', getValue('txtRazonSocial'));
					setValue('hidComentarioPDV', getValue('txtComentarioPDV'));
					setValue('hidGrupoPaqueteServer', self.frames['ifraCondicionesVenta'].getValue('hidGrupoPaquete'));
					setValue('hidServicioServer', self.frames['ifraCondicionesVenta'].getValue('hidPlanServicio'));
					setValue('hidPromocionServer', self.frames['ifraCondicionesVenta'].getValue('hidPromocion'));
								
					setValue('hidAccion', 'Grabar');
					document.frmPrincipal.submit();
				}
				else
				{
					habilitarBoton('btnEnviarACreditos', 'Enviar a Créditos', true);
					return;
				}
			}

			function AsignarTipoDocVenta(resTipoDocVenta)
			{
				document.getElementById('hidTipoDocVenta').value = resTipoDocVenta;
			}
			
			function cancelar(){
				resetearMontos();
				habilitarDescuento();
			}
			
			function cancelarPedido(){
				LimpiarControlesDetalle();
				setFocus('ddlTipoDocumento');
			}
			
			function LimpiarControlesDetalle()	{
				document.location.reload();
			}

			
			//Cargar Vendedores SAP
			function cargarListaVendedores() {
				var objDdl = document.getElementById('ddlPuntoVenta');
				if(objDdl.value != '')
				{
					var idx = objDdl.selectedIndex
					var valorTmp = objDdl.options[idx].value;
					var textoTmp = objDdl.options[idx].text;
					consultarListaVendedores(getValue('ddlPuntoVenta'));
				}
			}
			
			function consultarListaVendedores(oficina) {
				if (oficina == "00" || oficina == "") {
					respuestaConsultarListaVendedores("00,<%= ConfigurationSettings.AppSettings("Seleccionar") %>");
					return;
				}
				document.getElementById("ifrConsultarListaVendedores").src = "../../post_venta/chip_repuesto/sisact_ifr_consulta_lista_vendedores.aspx?oficina="+oficina;
				document.getElementById("ifrConsultarListaVendedores").contentWindow.opener = window.opener;
			}
			
			function respuestaConsultarListaVendedores(datos) {
				// Poner uno a uno los Vendedores de la Lista que deben pertenecen al Punto de Venta actual
				var selObjV = document.getElementById('ddlVendedorSAP');
				selObjV.length = 0;

				var listaVendedores = datos.split(';');
				for (var i=0; i<listaVendedores.length; i++) {
					var opcion = listaVendedores[i].split(',');
					addOption(selObjV, opcion[0], opcion[1]);
				}
				cargarPDV(getValue('ddlPuntoVenta'));
				cambiarVendedor();
			}
			
			function cambiarVendedor() {
				var objDdl = document.getElementById('ddlVendedorSAP');
				var idx = objDdl.selectedIndex;
				var valorTmp = objDdl.options[idx].value;
				var textoTmp = objDdl.options[idx].text;
				setValue('hidVendedorSAP', valorTmp + ";" + textoTmp);
				
				
			}
			
			function BorrarDatosImei(){
				var txtimei = document.getElementById("txtImei");
				var ddlListaPrecios = document.getElementById("ddlPrecio");
				var imei = Trim(txtimei.value);
				if (imei == '' || imei.length < 15){
					ddlListaPrecios.length = 0;
					setValue('txtMaterialImei', '');
					setValue('txtArticuloImei', '');
					setValue('txtPrecioVenta', '0.00');
					setValue('txtTotalAPagar', '0.00');
					setValue('hidPrecioVenta', '0');
					setValue('hidPrecioTotal', '0');
					setValue('hidlistaPrecioSelected', '');
					setValue('hidPrecios', '');
				}
			}

			function BorrarDatosICCID(){
				var txtSerieChip = document.getElementById("txtSerieChip");
				var ddlListaPrecioChip = document.getElementById("ddlPrecioChips");
				var ICCID = Trim(txtSerieChip.value);
				if (ICCID == '' || ICCID.length < 15){
					ddlListaPrecioChip.length = 0;
					setValue('txtMaterialICCID', '');
					setValue('txtArticuloICCID', '');
					document.getElementById('lblPlanChip').innerHTML = '';
					//setValue('txtPrecioVenta', '0.00');
					//setValue('txtTotalAPagar', '0.00');
					//setValue('hidPrecioVenta', '0');
					//setValue('hidPrecioTotal', '0');
					//setValue('hidlistaPrecioSelected', '');
					//setValue('hidPLSelected', '');
					//setValue('hidPrecios', '');
				}
			}
			
			function validarBolsaCompartidaII()
			{
				var strPlanBolsa = getValue('hidPlanCombo');
				var arrPlanBolsa = strPlanBolsa.split('|');
				var strCodPlan;
				var nroPlanes;
				var cont = 0;

				for (var i = 0; i < arrPlanBolsa.length; i++)
				{
					strCodPlan = arrPlanBolsa[i];
					if (strCodPlan != '')
					{
						nroPlanes = nroPlanesEvaluados(strCodPlan, '');
						if (parseInt(nroPlanes, 10) == 1)
						{
							cont += parseInt(1);
						}
						if (parseInt(nroPlanes, 10) > 1) return false;
					}
				}
				if (cont > 1) return false;

				return true;
			}	
			
			//Segunda Fase
			function consultarIccid() {
				//alert('consultar ICCID');
				//if ( !ValidaCampo('document.frmPrincipal.txtSerieChip','Debe ingresar el número de serie(Iccid).') ) return false;
				
				setValue('txtPrecioVentaChip', '');
				
				if (getValue('txtSerieChip') == "") {
					alert("Debe ingresar el número de serie(Iccid).");
					setFocus('txtSerieChip');
					return;
				}
				var _parametros = "codIccid="+getValue('txtSerieChip')+"&nroLinea="+getValue('txtNroLinea')+"&canalVenta="+getValue('ddlCanal')+"&codOfVenta="+getValue('ddlPuntoVenta')+"&HLR="+getValue('hidHLR');
				document.getElementById('ifrBuscarIccid').src= "../chip_repuesto/sisact_ifr_consulta_iccid.aspx?"+_parametros;
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;
			}	
			
			function responseConsultarIccid(datos) {

				var arrayDatos = datos.split(',');
				// Se valida el material
				//if (!validarMaterialesPostpago(arrayDatos[0]) ){
				//	setFocus('txtSerieChip');
				//	alert('El material ' + arrayDatos[0] + ' no está disponible para la reposición.');
				//	return false;
				//}
				setValue('txtMaterialICCID', arrayDatos[0]);
				setValue('txtArticuloICCID', arrayDatos[1]);
				setValue('hidDesMaterialIccid', arrayDatos[1]);
				setValue('hidIccid', getValue('txtSerieChip'));
				setValueHTML('lblPlanChip', "SIM 4G-LTE:  "+getValue('hidTLE'));
				//setText('lblPlanChip', arrayDatos[2]);
				//document.getElementById('<%= lblPlanChip.ClientID %>').innerHTML = arrayDatos[2];

				// Codigo de Iccid
				//setEnabled('txtSerieChip', true, 'clsInputEnable'); 
				//setReadOnly('txtSerieChip', true, 'clsInputEnable');
				// Deshabilitar el boton Validar Iccid
				setEnabled('btnValidarICCID', true, 'Boton');
				
				cargarListaPreciosICCID_DAC_CAD();

			}
			
			//consolidado 12122014
				/*
			function chkRetenido_onclick() {
				var chkRetenido = document.getElementById("chkRetenido");
				var hdnRetenidoFidelizado = document.getElementById("hdnRetenidoFidelizado");

				if (chkRetenido.checked) {				
					var chkFidelizado = document.getElementById("chkFidelizado");

					chkFidelizado.checked = false;
					hdnRetenidoFidelizado.value = "Retenido";
				} else {
					hdnRetenidoFidelizado.value = "";
				}
			}

			function chkFidelizado_onclick() {
				var chkFidelizado = document.getElementById("chkFidelizado");
				var hdnRetenidoFidelizado = document.getElementById("hdnRetenidoFidelizado");

				if (chkFidelizado.checked) {
					var chkRetenido = document.getElementById("chkRetenido");

					chkRetenido.checked = false;
					hdnRetenidoFidelizado.value = "Fidelizado";
				} else {
					hdnRetenidoFidelizado.value = "";
				}
			}	
				*/
			function cargarSerieEquipo(){

				resetearBusquedaXSerie();
				
				var seleccionar = '<%= ConfigurationSettings.AppSettings("Seleccionar") %>';
				if ( getText('ddlCodEquipo') == seleccionar ) {
					alert('Seleccione un Equipo válido.');
					setValue('ddlSerieEquipo',seleccionar);
					setFocus('ddlCodEquipo');
					return false;
				}
				
				setValue('hidSerieEquipo',getValue('ddlSerieEquipo'));
				//setValue('ddlCampania','00');
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
			}
			
			function resetearBusquedaXSerie(){
			
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				
				//resetearMontos();
				//habilitarDescuento();
				
				//setValue('ddlPlanTarifario','');
				//setValue('ddlPlazoAcuerdo','00');
				
			}
			
			function f_CambiaImei() {
				
 
				
				if ( getValue('ddlCodEquipo') != "" ) {	
					setValue('txtCodEquipo',getValue('ddlCodEquipo'));
					//consolidado 27012015
					setValue('hidNombredelEquipoCAC', getText('ddlCodEquipo'));
					//consolidado 27012015
				}
				else {
					setFocus('ddlCodEquipo');
				}
				
				var objICCID = document.getElementById('ddlCodEquipo');
				var artImei = getValue('ddlCodEquipo').substring(0,18);
				setValue('hidFlagDescuento','false');
				
				if (objICCID.selectedIndex > 0){
						consultarIMEICAC(artImei);
					}else{
						ResetSerieIMEI();
					}
				//setValue('ddlListaPrecio','00'); cboICCIDArt
			}
			
			function consultarIMEICAC(articuloImei) {				
						
				var _parametros = "codIccid="+articuloImei+"&nroLinea="+getValue('txtNroLinea')+"&canalVenta="+getValue('hidPuntoVenta')+"&codOfVenta="+getValue('hidOfVentaCod')+"&tipoVenta="+getValue('hidTipoVenta');
				document.getElementById('ifrBuscarIccid').src= "../chip_repuesto/sisact_ifr_consulta_IMEI_Postpago.aspx?"+_parametros;
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;

			}
			
			function responseConsultarIccidCAC(datos){

				if (datos != ""){
                    setValueHTML('lbl4GCAC', "SIM 4G-LTE:  " + getValue('hidTLE'));
					document.getElementById("tdSerieChip").innerHTML = datos;
					setEnabled('cboICCIDChip', true, 'clsSelectEnable0');
				}
				else {
	                ResetSerieIccid();
					alert("No hay series ICCIDS disponibles");
				}
			}
			function ResetSerieIccid(){
				var strHTML = "&nbsp;<select id=cboICCIDChip name=cboICCIDChip class=clsSelectEnable style='width:200px'></select>";
				document.getElementById("tdSerieChip").innerHTML = strHTML;
			    document.getElementById('lbl4GCAC').innerHTML = '';
				setEnabled('cboICCIDChip', true, 'clsSelectEnable0');
			}
			
			function responseConsultarIMEICAC(datos){

				if (datos != ""){
					document.getElementById("tdSerieIccid").innerHTML = datos;
					setEnabled('cboIMEIArt', true, 'clsSelectEnable0');
					
					//'PROY-24724-IDEA-28174 - INICIO 
						if(getValue('hidEvalPM')=="1" && document.getElementById('chkProMovil').checked==true){ 
						f_ConsultarPrimaWS(); 
						}
				    //'PROY-24724-IDEA-28174 - FIN					
				}
				else {
					ResetSerieIMEI();
					ResetCamposCAC();
					alert("No hay series IMEIS disponibles");
				}
			}
			//consolidado 12122014
			
			function ResetSerieIMEI(){
				var strHTML = "&nbsp;<select id=cboIMEIArt name=cboIMEIArt class=clsSelectEnable style='width:200px'></select>";
				document.getElementById("tdSerieIccid").innerHTML = strHTML;
				setEnabled('cboIMEIArt', true, 'clsSelectEnable0');
			}
			function ResetCamposCAC(){
				
				setValue('txtCodEquipo','');
				setValue('txtPrecioVentaEquipo','');
				var ddlListaPrecio = document.getElementById("ddlListaPrecio");
				ddlListaPrecio.length = 0;
				setValue('txtDescuentoEquipo','');
				setValue('txtPrecioVenta','0');
				setValue('txtTotalAPagar','0');
			
			}
			
			
			function solicitaAutorizacion( v_descripcion, v_monto,pagina ){
				//document.getElementById("hidOpcion").value = v_opcion;
				//if(confirm('Se requiere autorización del Jefe/Supervisor')){
								
				var url = '../../soporte/sisact_validar.aspx?';
				var params = "";
					params ="v_pag="	+ pagina		+ "&" +
							"v_tipotx="	+ "M"			+ "&" +
							"v_monto="	+ v_monto		+ "&" +
							"v_descripcion="+ v_descripcion;
							
					url = url + params;				
																	
					window.showModalDialog(url,window,'dialogTop:200;status:no;edge:sunken;dialogHide:true;help:no;dialogWidth:382px;dialogHeight:176px');								
					return
				//}else{
				//	return false
				//}
			}
			
			function FC_CancelarVentana()
			{
				if (getValue('hidFlgCierre') == '1'){
					document.getElementById("txtDescuentoEquipo").value = '';
					
					//consolidado 28012015
					
					var precioVenta =  getValue('txtPrecioVentaEquipo');
					
					var PrecioNeto = parseFloat(precioVenta) - parseFloat(getValue('txtDescuentoClaroClub'));
						
						if (PrecioNeto <= 0){
							setValue('txtDescuentoEquipo', '');
							setValue('hidPrecioTotal', '0');
							setValue('txtTotalAPagar', '0');
							setFocus('txtDescuentoEquipo');
							
				}else{
							setValue('txtDescuentoEquipo', '');
							setValue('hidPrecioTotal', PrecioNeto);
							setValue('txtTotalAPagar', PrecioNeto);
							setFocus('txtDescuentoEquipo');
				}
				
						//consolidado 25012015
					
					
				}else{
					nuevaEvaluacion();
				}
			}
			
			function FC_GrabarCommit(User)
			{
			
				if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_ANTICIPADA_CON_EXONERACION'){			
					
					setValue('hidFlagConfExoneracionReintegro','true');
					setValue('hidFlagExonerarReintegro','true');
					//setValue('txtReintegro', parseFloat(getValue('hidReintegro')).toFixed(2) );
					//setValue('txtReintegroAFacturar', '0.00' );
							
					setValue('hidOpcionAutorizacion','');
					
					mostrarConsulta();
					
				}else if (document.getElementById("hidOpcionAutorizacion").value == 'RENOVACION_DESCUENTO'){
					
					setValue('hidOpcionAutorizacion','');
					ejecutarDescuento();
					
				}else if (document.getElementById("hidOpcionAutorizacion").value == 'PERMITIR_RENOVACION_NORMAL_CON_EXONERACION') {
				
				}
				document.getElementById('hidCerrarValid').value = "1";
			}
			
			function desabilitarBoton(id){
				document.getElementById(id).className='BotonResaltado'
				document.getElementById(id).style.cursor=  'default'
				document.getElementById(id).disabled = true;			
			}

			function FC_Fallo()
			{
				setValue('hidOpcionAutorizacion','');
				alert('Ud. no cuenta con autorización suficiente para realizar esta transacción.');
				nuevaEvaluacion();
			}
			function selectedIMEI(val){	

				if (val == "0000000000"){
					// Resetear 
					var selObjP = document.getElementById('ddlListaPrecio');
					selObjP.length = 0;
					setEnabled('ddlListaPrecio', true, 'clsSelectEnable0');
				}else{
					setValue('hidIMEI', val);
					setEnabled('ddlListaPrecio', true, 'clsSelectEnable0');					
                                        //INICIO|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados					
					buscarImei(val);
                                        //FIN|PROY-27029-IDEA-29524 - Venta fluida de equipos desbloqueados					
					cargarListaPrecioIMEI();
				}
			}
			
			
			function cargarListaPrecioIMEI() {
				
				var selObjP = document.getElementById('ddlListaPrecio');
				selObjP.length = 0;
				var codigoImei = getValue('txtCodEquipo');
				
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				var campana = ifrConVenta.getValue('ddlCampana1');
				var plan = getValor(ifrConVenta.getValue('ddlPlan1'), 2); 
				var plazoAcuerdo = ifrConVenta.getValue('ddlPlazo1');
				var oficinaVenta = getValue('ddlPuntoVenta');
				var tipoOperacion = '<%= ConfigurationSettings.AppSettings("constCodOperRenovacion") %>';
		                var strTipoDocVentaSap=	getValue('hidTipoDocVentaSap');
		                var strOficina= getValue('hidOficina');
		                var strCanalSap= getValue('hidCanalSap');
				
				var params = getValue('hidTipoVenta') + "," +
							plan + ",," +  
							codigoImei + "," +
							campana + "," +  
							oficinaVenta + ",," +
							tipoOperacion + "," +  
							plazoAcuerdo+ "," + 
							strTipoDocVentaSap + "," +
							strOficina + "," + 
							strCanalSap + "," + 
							getValue('hidNroSEC'); 
							
							
				consultarListaPrecios(params); 
			}
			
			
			function f_CambiaIccid()
			{
				// Deshabilitar combos
				//setEnabled('ddlCampania', true, 'clsSelectEnable0');
				//setEnabled('ddlPrecioChip', false, 'clsSelectEnable0');
					
				if (getValue('ddlCodChip') == "00")
				{
					setValue('txtCodChip', '');					
					//setValue('hidDesMaterial', '');	
					ResetSerie();
				}
				else{
					
					var objICCID = document.getElementById('ddlCodChip');
					//var articuloImei = getValue('ddlCodChip').substring(0,10);
                    var articuloImei = getValue('ddlCodChip');
					//se carga el codigo del material seleccionado
					setValue('txtCodChip', getValue('ddlCodChip'));
					setValue('hidNombredelChipCAC', getText('ddlCodChip'));
					//setValue('hidDesMaterial', getText('ddlDesArticulo'));

					if (objICCID.selectedIndex > 0){
						consultarIccidCAC(articuloImei);
					}else{
						ResetSerie();
					}
				}
			}
			
			function consultarIccidCAC(codIccid) {				
				var _parametros = "codIccid="+codIccid+"&nroLinea="+getValue('txtNroLinea')+"&canalVenta="+getValue('hidPuntoVenta')+"&codOfVenta="+getValue('hidOfVentaCod')+"&HLR="+getValue('hidHLR');
				document.getElementById('ifrBuscarIccid').src= "../chip_repuesto/sisact_ifr_consulta_iccid.aspx?"+_parametros;
				document.getElementById('ifrBuscarIccid').contentWindow.opener = window.opener;
			}
			
			
			function selectedICCID(val){	

				if (val == "0000000000"){
					var selObjP = document.getElementById('ddlPrecioChip');
					selObjP.length = 0;
					setEnabled('ddlPrecioChip', false, 'clsSelectEnable0');
				}else{
					setValue('hidIccid', val);
					setEnabled('ddlPrecioChip', true, 'clsSelectEnable0');					
					cargarListaPreciosICCID();
				}
			}
			
			
			function cargarListaPreciosICCID() {

				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlPrecioChip');
				selObjP.length = 1;
				
				// Resetear precios en las Hidden
				//resetearMontos();
				//if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) return false;
				//if ( !ValidaCampo('document.frmPrincipal.hidIccid','Debe seleccionar una Serie.') ) return false;
				
				// Obtener la Campania Seleccionada
				
				
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				
														
				var campana = ifrConVenta.getValue('ddlCampana1');
				var plan = getValor(ifrConVenta.getValue('ddlPlan1'), 2); 
				var plazoAcuerdo = ifrConVenta.getValue('ddlPlazo1');
				var oficinaVenta = getValue('ddlPuntoVenta');
				var tipoOperacion = '<%= ConfigurationSettings.AppSettings("constCodOperRenovacion") %>';
		                var strTipoDocVentaSap=	getValue('hidTipoDocVentaSap');
		                var strOficina= getValue('hidOficina');
		                var strCanalSap= getValue('hidCanalSap');
				
				var params = getValue('hidTipoVenta') + "," +
							plan + "," +  
							getValue('hidIccid') + "," +
							getValue('txtCodChip') + "," +
							campana + "," +  
							oficinaVenta + "," +
							getValue('hidHLR')+ "," +
							tipoOperacion + "," +  
							plazoAcuerdo+ "," + 
							strTipoDocVentaSap + "," +
							strOficina + "," + 
							strCanalSap + "," + 
							getValue('hidNroSEC'); 
							
							
				consultarListaPrecioChip(params);
			}
			function consultarListaPrecioChip(params) {
				document.getElementById('ifrConsultarListaPrecios').src = "../chip_repuesto/sisact_ifr_consulta_lista_precios.aspx?flgPrecioMae=1&params="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window.opener;
			}
			
			function cargarListaPrecioDefault() {

				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				var campaniaSelected = ifrConVenta.getValue('ddlCampana1');
			
				if (campaniaSelected == getValue('hidCampaniaDefault')) {
					// Si existe la Lista de Precio poner x defecto
					var selObjP = document.getElementById('ddlPrecioChip');
					for (var i=0; i<selObjP.options.length; i++) {
						if (selObjP.options[i].value == getValue('hidListaPrecioDefault')) {
							setValue('ddlPrecioChip', getValue('hidListaPrecioDefault'));
							// Consultar Precios
							cargarPrecioChip();
							break;
						}
					}
				}
			}
			
			
			function cargarPrecioEquipo() {
				
				var strCanal = getValue('ddlCanal');
				if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
					
						if (getValue('ddlListaPrecio') == "00" || getValue('ddlListaPrecio') == '' || getValue('ddlListaPrecio') == undefined){
							resetearMontos();
							return;
						}
						//Obtener la lisa de precios
						var listaPreciosSelected = getValue('ddlListaPrecio') + "," + getText('ddlListaPrecio');
						setValue('hidlistaPrecioSelected', listaPreciosSelected);
						var ifrConVenta = self.frames['ifraCondicionesVenta'];
						// Obtener la Campania Seleccionada
						var campaniaSelected = ifrConVenta.getValue('ddlCampana1') + "," + ifrConVenta.getText('ddlCampana1');
						setValue('hidCampaniaSelected', campaniaSelected);
						
						//setValue('hidEstadoPrecio', 'RE');
						setValue('txtTotalAPagar','');
						setValue('txtPrecioVenta','');
						
						var params = "";
						 
						params = getValue('ddlPuntoVenta') + "," +
								getValue('txtCodEquipo') + "," +
								getValue('ddlListaPrecio') + "," +
								getValue('cboIMEIArt') + "," +
								getValue('txtNroLinea') + "," +
								getValue('hidTipoDocVenta') + "," +
								"" + "," +
								"" + "," +
								"";
				}
						
				consultarPrecios(params);
			}
			
			
			function cargarPrecioChip() {
				
				if ( !ValidaCampo('document.frmPrincipal.ddlPrecioChip','Debe seleccionar una Lista de Precios.') ) return false;
				// Obtener la Lista de Precio Seleccionado
				var listaPrecioSelected = getValue('ddlPrecioChip') + "," + getText('ddlPrecioChip');
				setValue('hidPLSelected', listaPrecioSelected);
				//setValue('hidEstadoPrecio', 'RC');			
				var params = "";
				
				
				params = getValue('ddlPuntoVenta') + "," +
						 "" + "," +
						 getValue('ddlPrecioChip') + "," +
						 "" + "," +
						 getValue('txtNroLinea') + "," +
						 getValue('hidTipoDocVenta') + "," +
						 getValue('txtCodChip') + "," +
						 getValue('hidIccid') + "," +
						 getValue('hidRespuestaChip');
										
				consultarPreciosChips(params);
				
			}

			function validarDescuento(){

				//hiden de precio de venta de equipo
				var precioVenta =  getValue('txtPrecioVentaEquipo');
				var montoDescuento = getValue('txtDescuentoEquipo');
				
				//consolidado 30012015
				f_actualizaFlagDscto('true');
				//consolidado 30012015
				
	            var montoMaximoValDesc = '<%= ConfigurationSettings.AppSettings("consMontoMaximoDescuentoAS") %>';
	        
				if(precioVenta ==''){
					precioVenta = 0;
				}
	            
				if(montoDescuento ==''){
					montoDescuento = 0;
				}                       
	            
				if(parseFloat(montoDescuento) > 0){
				
					var dsctoTotal = parseFloat(montoDescuento) + parseFloat(getValue('txtDescuentoClaroClub'))
					
					precioTotal = parseFloat(precioVenta) - parseFloat(dsctoTotal);
					
					if(precioTotal < 1){
						alert('Monto de descuento NO permitido.');
						
						
						var PrecioNeto = parseFloat(precioVenta) - parseFloat(getValue('txtDescuentoClaroClub'));
						
						if (PrecioNeto <= 0){
							setValue('hidDescuento', '');
							setValue('txtDescuentoEquipo', '');
							setValue('hidPrecioTotal', '0');
							setValue('txtTotalAPagar', '0');
							setFocus('txtDescuentoEquipo');
							
						}else{
							setValue('hidDescuento', '');
						setValue('txtDescuentoEquipo', '');
							setValue('hidPrecioTotal',  PrecioNeto.toFixed(2));
							setValue('txtTotalAPagar',  PrecioNeto.toFixed(2));
						setFocus('txtDescuentoEquipo');
						}
						return false;
					}
					montoDescuento.value = parseInt(montoDescuento);
				
				}                       
	            
				if (parseFloat(montoDescuento) <= 0) {
					alert('Debe ingresar un descuento.');
					//consolidado 21012015
					precioTotal = precioVenta - (montoDescuento + parseFloat(getValue('txtDescuentoClaroClub')));
					
					setValue('hidPrecioTotal', precioTotal.toFixed(2));
					setValue('txtTotalAPagar', precioTotal.toFixed(2));
					
					//consolidado 21012015
					setValue('hidDescuento', '');
					setValue('txtDescuentoEquipo', '');
					setFocus('txtDescuentoEquipo');
					return false;
				}else if( parseFloat(montoDescuento) > parseFloat(precioVenta) ){
						alert('Monto de descuento NO permitido.');
						setValue('hidDescuento', '');
						setValue('txtDescuentoEquipo', '');
						setFocus('txtDescuentoEquipo');
						return false;
					}else
					{
					setValue('hidOpcionAutorizacion','RENOVACION_DESCUENTO');
		                    
						var montoMaxDesAS = parseFloat(getValue('hidMontoMaxDesAS'));
						if(parseFloat(montoDescuento) > montoMaxDesAS && parseFloat(montoDescuento) <= parseFloat(montoMaximoValDesc)){
							
							document.getElementById('hidFlgCierre').value='1';
							solicitaAutorizacion('Descuento por Renovacion',montoDescuento,'1');
						}else if(parseFloat(montoDescuento) <= montoMaxDesAS){
							FC_GrabarCommit('');
						}else{
							FC_Fallo_Monto_No_Permitido();
							//FC_GrabarCommit('');
						}
					}
				}
				
				
			function cargarListaPreciosICCID_DAC_CAD() {

				// Resetear la lista de precios ya agregados
				var selObjP = document.getElementById('ddlPrecioChips');
				selObjP.length = 1;
				
				// Resetear precios en las Hidden
				//resetearMontos();
				//if ( !ValidaCampo('document.frmPrincipal.ddlCampania','Debe seleccionar una Campaña.') ) return false;
				//if ( !ValidaCampo('document.frmPrincipal.hidIccid','Debe seleccionar una Serie.') ) return false;
				
				// Obtener la Campania Seleccionada
				
				
				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
			
							
							
			    var campana = ifrConVenta.getValue('ddlCampana1');
				var plan = getValor(ifrConVenta.getValue('ddlPlan1'), 2); 
				var plazoAcuerdo = ifrConVenta.getValue('ddlPlazo1');
				var oficinaVenta = getValue('ddlPuntoVenta');
				var tipoOperacion = '<%= ConfigurationSettings.AppSettings("constCodOperRenovacion") %>';
		        var strTipoDocVentaSap=	getValue('hidTipoDocVentaSap');
		        var strOficina= getValue('hidOficina');
		        var strCanalSap= getValue('hidCanalSap');
				
				var params = getValue('hidTipoVenta') + "," +
							plan + ",," +  
							getValue('txtMaterialICCID') + "," +
							campana + "," +  
							oficinaVenta + ",," +
							tipoOperacion + "," +  
							plazoAcuerdo+ "," + 
							strTipoDocVentaSap + "," +
							strOficina + "," + 
							strCanalSap + "," + 
							getValue('hidNroSEC'); 
							
				consultarListaPrecioChips(params);
			}
			
			function consultarListaPrecioChips(params) {
				document.getElementById('ifrConsultarListaPrecios').src = "../chip_repuesto/sisact_ifr_consulta_lista_precios_ICCID.aspx?flgPrecioMae=1&params="+params;
				document.getElementById('ifrConsultarListaPrecios').contentWindow.opener = window.opener;
			}
			
			
			function responseConsultarListaPreciosDAC_CAD(datos) {

				// Resetear la lista de precios ya agregados
				
				var selObjP = document.getElementById('ddlPrecioChips');
				selObjP.length = 0;
				// Poner uno a uno lista de precios disponibles
				var listaPrecios = datos.split(';');
				for (var i=0; i<listaPrecios.length; i++) {
					var opcion = listaPrecios[i].split(',');
					addOption(selObjP, opcion[0], opcion[1]);
				}
				cargarListaPrecioDefaultChips();
			}
			
			function cargarListaPrecioDefaultChips() {

				var ifrConVenta = self.frames['ifraCondicionesVenta'];
				
				var campaniaSelected = ifrConVenta.getValue('ddlCampana1');
			
				if (campaniaSelected == getValue('hidCampaniaDefault')) {
					// Si existe la Lista de Precio poner x defecto
					var selObjP = document.getElementById('ddlPrecioChips');
					for (var i=0; i<selObjP.options.length; i++) {
						if (selObjP.options[i].value == getValue('hidListaPrecioDefault')) {
							setValue('ddlPrecioChips', getValue('hidListaPrecioDefault'));
							// Consultar Precios
							cargarPrecioChips();
							break;
						}
					}
				}
			}
			
			function cargarPrecioChips() {
				
				if ( !ValidaCampo('document.frmPrincipal.ddlPrecioChips','Debe seleccionar una Lista de Precios.') ) return false;
				// Obtener la Lista de Precio Seleccionado
				var listaPrecioSelected = getValue('ddlPrecioChips') + "," + getText('ddlPrecioChips');
				setValue('hidPLSelected', listaPrecioSelected);		
				var params = "";
				
				
				params = getValue('ddlPuntoVenta') + "," +
						 "" + "," +
						 getValue('ddlPrecioChips') + "," +
						 "" + "," +
						 getValue('txtNroLinea') + "," +
						 getValue('hidTipoDocVenta') + "," +
						 getValue('txtMaterialICCID') + "," +
						 getValue('txtSerieChip') + "," +
						 getValue('hidRespuestaChip');
										
				consultarPreciosChips(params);
				
			}
			
			
			function responseConsultarPreciosChip(datos) {
				
				resetearMontos();
				habilitarDescuento();
				
				var ifrConVenta = self.frames['ifraCondicionesVenta'];				
				var strCanal = getValue('ddlCanal');
				if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
							//resetearMontosCAC();
							setValue('hidDatosChip', datos);
						if (getValue('hidDatosChip') != ''){
							var listaPrecio = getValue('ddlPrecioChip');
							var datosChip =  getValue('hidDatosChip');
							var arrayPrecio = datosChip.split(',');
						}
				}else{
						
						setValue('hidDatosChip', datos);
						if (getValue('hidDatosChip') != ''){
							var listaPrecio = getValue('ddlPrecioChips');
							var datosChip =  getValue('hidDatosChip');
							var arrayPrecio = datosChip.split(',');
						}
						
						
				}

				if (listaPrecio != "00" || listaPrecio != ''){
					// Obtener Precio de Venta - Precio de Lista
					//var arrayPrecio = datos.split(',');
					
					//Evaluando Subsidio
					var  existePrecioVenta = (getValue('hidPrecioVentaEv') != undefined && Trim(getValue('hidPrecioVentaEv')) != '');
					var existePrecioLista = (getValue('hidPrecioListaEv') != undefined && Trim(getValue('hidPrecioListaEv')) != '');
					
					//INC000000715147 - INICIO
						var fltPrecioVentaEva = parseFloat(getValue('hidPrecioVentaEv'));
						var fltPrecioCompraEva = parseFloat(getValue('hidPrecioListaEv')); 
						
						var fltPrecioVenta = parseFloat(arrayPrecio[1]);
						var fltPrecioCompra = parseFloat(arrayPrecio[2]);	
						
						var factorCostoSubsidio = parseFloat('<%= ConfigurationSettings.AppSettings("constFactorCostoSubsidio") %>');
												
						if(fltPrecioCompraEva >= (factorCostoSubsidio*fltPrecioCompra))
						{
							var dblFactorSubsidioEval = parseFloat(fltPrecioVentaEva / fltPrecioCompraEva).toFixed(2);
							var dblFactorSubsidioVenta = parseFloat(fltPrecioVenta / fltPrecioCompra).toFixed(2);

							if (dblFactorSubsidioVenta < dblFactorSubsidioEval)
							{
									alert('No cumple condiciones iniciales de la evaluación');
								limpiarSubsidio();
										return;
									}
							}
						else 
						{
							alert('No cumple condiciones iniciales de la evaluación');
							limpiarSubsidio();
										return;
			}
					//INC000000715147 - FIN
			
					//Fin Evaluacion
					
					setValue('hidDatosChip', datos);
					//var datosEquipo = getValue('hidDatosEquipo');
                    //var arrayPrecioEquipo = datosEquipo.split(',');
       

					
					
					setValue('txtPrecioVenta', getValue('txtPrecioVentaEquipo'));
					//setValue('txtTotalAPagar', arrayPrecio[1]);
					setValue('txtpreciochip', arrayPrecio[1]);
					setValue('txtPrecioVentaChip', arrayPrecio[1]);
 				
					
					
				
				
					// Actualizar el total a pagar txtTotalAPagar	
					if (ifrConVenta.getValue('hidTieneReserva') != "1") {
						var precioVenta = parseFloat(getValue('txtPrecioVenta'));
						var descuentoClaroClub;
						if(getValue('txtDescuentoClaroClub')!=""){
							descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
						}else{
							descuentoClaroClub = 0;
						}
						
						var PrecioNeto = precioVenta - descuentoClaroClub;
						
						if(PrecioNeto < 0){
							setValue('hidPrecioTotal', '0');
							setValue('txtTotalAPagar', '0');
						}else{
						//Validar si selecciono chip repuesto
							 
								if (getValue('hidValidarIccid') == "1"){
												if(strCanal == '<%= ConfigurationSettings.AppSettings("constCodTipoCAC") %>'){
													
													setValue('txtpreciochip', arrayPrecio[1]);
													
													if(getValue('txtDescuentoClaroClub')!="0"){
															descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
												     }else{
															descuentoClaroClub = 0;
													}
													
													
													var datosEquipo =  getValue('hidDatosEquipo');
													var arrayEquipo = datosEquipo.split(',');
													setValue('txtPrecioVenta', arrayEquipo[1]);
													if(datosEquipo !=""){
												    
												    var PrecioEquipo = getValue('txtPrecioVenta');
												    }else{
												     var PrecioEquipo = '0';
												    }
													
													if (getValue('hidFlagDescuento') == 'false'){
														PrecioNeto = parseFloat(PrecioEquipo) + parseFloat(getValue('txtpreciochip')) - parseFloat(descuentoClaroClub);
													}else{
														PrecioNeto = parseFloat(getValue('hidTotalAPagarCAC')) + parseFloat(getValue('txtpreciochip')) - parseFloat(descuentoClaroClub);
													}
													
													setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
													setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
													setValue('txtPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													setValue('hidPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
													
													
												}else{
												
												if(getValue('txtDescuentoClaroClub')!="0"){
																	descuentoClaroClub = parseFloat(getValue('txtDescuentoClaroClub'));
												     }else{
															descuentoClaroClub = 0;
													}
													
													
													
													var datosEquipo =  getValue('hidDatosEquipo');
												
													
													var arrayEquipo = datosEquipo.split(',');
													
													setValue('txtPrecioVenta', arrayEquipo[1]);
													
												    if(datosEquipo !=""){
												    
												    var PrecioEquipo = getValue('txtPrecioVenta');
												    }else{
												     var PrecioEquipo = '0';
												    }
													
													
													
													var strPrecioChip = arrayPrecio[1];
														PrecioNeto = parseFloat(PrecioEquipo) + parseFloat(strPrecioChip)- parseFloat(descuentoClaroClub);
										
														setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
														setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
														setValue('txtPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
														setValue('hidPrecioVenta', parseFloat(getValue('txtPrecioVenta')).toFixed(2));
												}
								}else{
										setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
										setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
								}
							
						}
					}
					
					habilitarBoton('btnGenerarPedido', 'Generar Pedido', true);
				}
				else{
					setValue('txtPrecioVenta', '0');
					setValue('txtTotalAPagar', '0');
				}
			}
			
			
			//consolidado 27122014
			
			function resetearMontosCAC() {
				setValue('hidPrecioVenta', '');
				setValue('hidPrecioTotal', '');
				setValue('txtPrecioVenta','0');
				//setValue('txtTotalAPagar', '0');					
			}
			
			//consolidado 27122014
			
			function consultarPreciosChips(params) {
				document.getElementById('ifrConsultarPrecio').src = "../../post_venta/chip_repuesto/sisact_ifr_consulta_lista_precio_chip.aspx?params="+params+"&renov=RR";
				document.getElementById('ifrConsultarPrecio').contentWindow.opener = window.opener;
			}
			
			
			function ejecutarDescuento(){

				// Inicio E77568
				///var precioVenta = parseFloat(getValue('hidPrecioVenta'));
				//var precioVenta = parseFloat(getValue('hidPrecioTotal'));
				//consolidado 13012015
				var precioVenta = parseFloat(getValue('txtPrecioVentaEquipo'));
				//consolidado 13012015
				var precioDescuento = 0.0;
				var precioTotal = 0.0;
				// Verificar si no hay reserva de puntos
				if (getValue('hidTieneReserva') != "1") {
					precioDescuento = parseFloat(getValue('txtDescuentoEquipo'));
					// PS - Automatización de canje y nota de crédito.
					var DescuentoClaroClub = getValue('txtDescuentoClaroClub');
					if (DescuentoClaroClub == "") {
						DescuentoClaroClub = 0.0;
					} else {
						DescuentoClaroClub = parseFloat(DescuentoClaroClub);
					}
					precioTotal = precioVenta - (precioDescuento + DescuentoClaroClub); // Se agrega ClaroClubSolesDeDescuento PS - Automatización de canje y nota de crédito.
					if ((precioDescuento + DescuentoClaroClub) > precioVenta) {
						alert("El monto total de descuentos no puede ser mayor al precio de venta de equipo.");
						return;
					}
				} else {
					precioDescuento = parseFloat(getValue('txtDescuentoEquipo'));
					precioTotal = precioVenta - precioDescuento;
				}
				// PS - Automatización de canje y nota de crédito.
				// Fin E77568
								
				//descuento
				setValue('hidDescuento', precioDescuento);
				var precioDescuentoDysplay = precioDescuento;
				setValue('txtDescuentoEquipo', precioDescuentoDysplay);
				
				//total
				setValue('hidPrecioTotal', precioTotal);
				setValue('txtTotalAPagar', precioTotal.toFixed(2));	
				
				//consolidado 27122014
				
				setValue('hidTotalAPagarCAC', precioTotal.toFixed(2));
				//consolidado 271220014
				//consolidado 13012015
				
				//setReadOnly('txtDescuentoEquipo', true, 'clsInputDisable');					
				//desabilitarBoton('btnDescuentoEquipo');
				
				//consolidado 13012015
				setValue('hidFlagDescuento','true');
			}

			function cambiarTipoRenovacion(){

				var ddlTipoRenovacion = document.getElementById("ddlTipoRenovacion").value;
				
				if (getValue('ddlTipoRenovacion') != "00"){
					if (getValue('ddlTipoRenovacion') == "Fidelizado"){
					
						setValue('hdnRetenidoFidelizado', 'Fidelizado');
						
						var prueba = getValue('hdnRetenidoFidelizado');
					}
					if (getValue('ddlTipoRenovacion') == "Retenido"){
						setValue('hdnRetenidoFidelizado', 'Retenido');
						// Inicio Plan No Vigente JAZ
						
						var EsPlanNoVigente = '<%= ConfigurationSettings.AppSettings("consCodPlanNoVigente") %>';													
						
						if(getValue('hidVigente') == EsPlanNoVigente) {
							if(confirm('Se requiere autorización del Jefe/Supervisor')) {
								solicitaAutorizacion("Aprobacion Renovacion Retenido","1","2");
							}	
						}																		
						// Fin Plan No Vigente JAZ
										
					}					
				}else{
						setValue('hdnRetenidoFidelizado', '');
				}
			}

			//jmori popup reintegro
			function f_PopUpReintegro(ddlTipoRenovacion){
				
				var id = '#dialog2';
				//Get the screen height and width
				var maskHeight = $(document).height();
				var maskWidth = $(document).width();
			
				//Set heigth and width to mask to fill up the whole screen
				$('#mask').css({'width':maskWidth,'height':maskHeight});
				
				//transition effect		
				$('#mask').fadeIn(1000);	
				$('#mask').fadeTo("slow",0.8);	
			
				//Get the window height and width
				var winH = $(document).height();
				var winW = $(document).width();
		             $(id).css('left', winW/2-$(id).width()/2);
		             $(id).css('top', winH/2-$(id).height()/2);
				//Set the popup window to center
			
				//transition effect
				$(id).fadeIn(2000);
			    	
			    	
				$('#ifrReintegro').attr('src', 'sisact_ifr_Reintegro.aspx' + '?msjmonto='+ msjreint + '&strModalidad='+ ddlTipoRenovacion);
			}
			function closethisDivReintegro(intResult)
			{
				$('#dialog2').hide();
				$('#mask').hide();
				//$('#ifrValidarCliente')="";
				//$('#ifrReintegro',window.parent.document).remove();

				if (intResult == 1){
				    quitarImagenEsperando();
				}
				else{
			      retornoReintegro();
				}
			}
			
			
			//end jmori
			
			
			//consolidado 12122014 
			
			//Inicio Rihu - 19122014 - everis
			function f_ValidarCliente(){
				
				var id = '#dialog1';
				//Get the screen height and width
				var maskHeight = $(document).height();
				var maskWidth = $(document).width();
			
				//Set heigth and width to mask to fill up the whole screen
				$('#mask').css({'width':maskWidth,'height':maskHeight});
				
				//transition effect		
				$('#mask').fadeIn(1000);	
				$('#mask').fadeTo("slow",0.8);	
			
				//Get the window height and width
				var winH = $(document).height();
				var winW = $(document).width();
		             $(id).css('left', winW/2-$(id).width()/2);
		             $(id).css('top', winH/2-$(id).height()/2);
				//Set the popup window to center
			
				//transition effect
				$(id).fadeIn(2000);
				
				//setValue('hidAuditoriaLogs', '03');					
				$('#ifrValidarCliente').attr('src', 'sisact_ifr_ValidarCliente.aspx' 
					+ '?nroSec=' + getValue('hidNroSEC') + '&TipoDocument=' + getValue('hidTipoDocumento') 
					+ '&Documento=' + getValue('hidNroDocumento') + '&intIDLog=' + getValue('hidAuditoriaLogs')
					+ '&ValidarCliente=' + getValue('hidValidarCliente'));
			}
			
			function closethisDiv(intResult)
			{
				$('#dialog1').hide();
				$('#mask').hide();
				//$('#ifrValidarCliente')="";
				$('#ifrValidarCliente',window.parent.document).remove();

				if (intResult == 1){
					nuevaEvaluacion();
				}
				else{
					Continuar_RealizarVenta();
				}
			}
			
			//Fin Rihu - 19122014 - everis
			
			function cargarListadoChips(){
			 var strPuntoVenta =	getValue('ddlPuntoVenta');
			 Anthem_InvokePageMethod('CargarMaterialesPostpago', [strPuntoVenta], function(result){
						var strprueba = result.value;
						llenarDatosCombo(document.getElementById('ddlCodChip'), strprueba, true);
					});
			}
			
			function cargarPDV(pdv){
				if(pdv != ""){
					setValue('hidOfVentaCod',pdv);
					Anthem_InvokePageMethod('cargarPDV', [pdv],null);
					
				}
			}
			
			function cargarListadoEquipo(){
			 var strPuntoVenta =	getValue('ddlPuntoVenta');
			 Anthem_InvokePageMethod('cargarListadoEquipo', [strPuntoVenta],
			 function(result){
						var strprueba = result.value;
						llenarDatosCombo(document.getElementById('ddlCodEquipo'), strprueba, true);
					});
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
			
			function FC_Fallo_Monto_No_Permitido()
			{
				alert('El monto ingresado NO esta permitido.');
				setValue('txtDescuentoEquipo', '');
				setFocus('txtDescuentoEquipo');
			}
			
			function FC_Fallo_Meses_No_Permitido()
			{
				alert('La cantidad de meses NO esta permitido para una renovación anticipada.');
				nuevaEvaluacion();
				
			}
			
			//consolidado 30012015
			function f_actualizaFlagDscto(valor)
			{
				setValue('hidFlagValDcto',valor);	
			}
			//consolidado 30012015
			
			
			//inicio plan no vigente 30102015
			
			function f_CheckPlanNoVigente(chk)
	        {                            

				if (chk.checked){
					document.getElementById('hidMantenerPlan').value= 'N';	
					setEnabled('ddlGProducto', false, '');
					document.getElementById('ddlGProducto').selectedIndex = 0;
					
					document.getElementById('tdBAM').style.display = '';
					if (isVisible('tdBAM')) { setEnabled('tdBAM', true, ''); } 
					
					alert('Cliente mantendrá su mismo plan.');
					
				}else{
					document.getElementById('hidMantenerPlan').value= 'S';
					setEnabled('ddlGProducto', true, '');
					document.getElementById('ddlGProducto').selectedIndex = 0;
				}                                                                                                                                            
			}
			
			//fin plan no vigente 30102015
			
			
			//PROY-24724-IDEA-28174  - INICIO			
			
			function f_ProteccionMovil(chk)
			{
				var objICCID = document.getElementById('ddlCodEquipo');
				var strEvalPM= getValue('hidEvalPM');
				var strEquipoEval=getValue('hidEquipoEvaluado');
				var strequipoActual=getValue('ddlCodEquipo').substring(0,18);
				var strMsgDesistitPM=vConfirmEliminarProtMovil;
		
                         
			
				if (chk.checked){
									
				   if(objICCID.selectedIndex > 0){
						if(strEquipoEval==strequipoActual)
						{
								if (strEvalPM=='1'||strEvalPM=='3'){
									f_ConsultarPrimaWS();
								}
								else{
								chk.checked=false;
								 alert(vMsjEquipoEvaluado);
								}							
						}
						else
						{
						 f_ConsultarPrimaWS();
						}													
					}
					else{
					    chk.checked=false;
						alert(vMsjSeleccionarEquipo);
						}
				}
				else if(!confirm(strMsgDesistitPM)){
					chk.checked=true
					}
			    else{
					document.getElementById('txtPrima').style.display = 'none';
					document.getElementById('txtDeducible').style.display = 'none';
					document.getElementById('lblPrima').style.display = 'none';
					document.getElementById('lblDeducible').style.display = 'none';
					}		
			}		
			
			function f_ConsultarPrimaWS() {
		
								
				var artImei = getValue('ddlCodEquipo').substring(0,18);
				var MsgPM ='';
				var strEvalPM='';
				var strNroDoc = getValue('txtNroDoc');
				
				
				Anthem_InvokePageMethod('ValidarProteccionMovil', [artImei,strNroDoc], 
							function(result){
							var arrayDatos = result.value.split('_');
							var resultt=result;
														
							setValue('hidPrima', arrayDatos[0]);
							setValue('hidDeducible', arrayDatos[1]);
							setValue('hidEvalPM', arrayDatos[2]);
							setValue('hidCertificadoPM', arrayDatos[3]);
							setValue('hidDatosAdicionalesPM', arrayDatos[4]);												
									
									setValue('hidEquipoEvaluado', artImei);	
									strEvalPM=getValue('hidEvalPM');
													
									var hiddPrima= getValue('hidPrima');
																		
									var hiddDeducible= getValue('hidDeducible');
											
									if (strEvalPM=='1'){
											
											setValue('txtPrima', getValue('hidPrima')); 
											
											setValue('txtDeducible', getValue('hidDeducible') ); 
											
									     	document.getElementById('chkProMovil').checked = true;
											document.getElementById('txtPrima').style.display = '';
											document.getElementById('txtDeducible').style.display = '';
											document.getElementById('lblPrima').style.display = '';
											document.getElementById('lblDeducible').style.display = '';	
											}
									else{		
														     
											MsgPM=mensajesRespuestaAsurion(strEvalPM);				        
											document.getElementById('chkProMovil').checked = false;
											document.getElementById('txtPrima').style.display = 'none';
											document.getElementById('txtDeducible').style.display = 'none';
											document.getElementById('lblPrima').style.display = 'none';
											document.getElementById('lblDeducible').style.display = 'none';
											alert(MsgPM);			             
										}					
							}
						);			 
			}
			
			function QuitarPMContratados() {	
			
				var ifr = self.frames['ifraCondicionesVenta'];
				var strRiesgo = '';
				var strPlanServicio =ifr.getValue('hidPlanServicio'); 
				var arrServicioContratado = strPlanServicio.split('|');
				var nombre = vCodServProteccionMovil;
				
				for (var i = 0; i < arrServicioContratado.length; i++)
				{
					var fila = arrServicioContratado[i];
					var Pos = fila.indexOf(nombre)
					if (Pos > -1)
					{	
						var Cortado = arrServicioContratado.splice(i,1);
						
						strPlanServicio = arrServicioContratado.join('|');
						break;
					}
				}
				ifr.setValue('hidPlanServicio',strPlanServicio);
				//asignar PM al ServNoContratado
				var strPlanServicioNO =ifr.getValue('hidPlanServicioNo'); 
				strPlanServicioNO = strPlanServicioNO+"|"+Cortado;
				ifr.setValue('hidPlanServicioNo',strPlanServicioNO);				
			}
			//PROY-24724-IDEA-28174  - FIN
			


			//ECM s8
			var resultadoRetornoTitularidadTipoCliente;
			var cteMasivo="<%=ConfigurationSettings.AppSettings("strPostTipClienteConsumer")%>";
			var cteB2E="<%=ConfigurationSettings.AppSettings("strPostTipClienteB2E")%>";
			
			function mostrarPanelLineas3G()
			{
				//función que permite obtener cantidad de lineas
				var url = 'sisact_ifr_consulta_unificada.aspx?';
					url += 'strTipoDocumentos=' + getValue('ddlTipoDocumento');
					url += '&strNroDoc=' + getValue('txtNroDoc');
					url += '&strMetodo=' + 'consultarCantidadLineas3G';
					self.frames['iframeAuxiliar'].location.replace(url);				
			}
			
			function retorno_mostrarLineas3G(rpta)
			{
				//en este caso obtengo la respuesta. SI rta=si, muestro el dialogo, sino continuo flujo
				var resultadotcli=resultadoRetornoTitularidadTipoCliente.toUpperCase();
				if( (rpta=="SI" && resultadotcli == cteMasivo.toUpperCase()) || (rpta=="SI" && resultadotcli == cteB2E.toUpperCase()) )
				{
					var w = 600;
					var h = 200;
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yno,status=no,resizable=no,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
				var url = 'sisact_pop_consulta3g.aspx?';
				url += 'tipodoc=' + getValue('ddlTipoDocumento');
				url += '&numdoc=' + getValue('txtNroDoc');
				url += '&canal=' + getValue('ddlCanal')
				window.open( url, '_blank',opciones);
				}
				
			}
			
			

			
//Inicio PROY-25335 - Contratación Electrónica - Release 0 | Bryan Chumbes Lizarraga			
function ValidarIdentidad() {
			
    var canal = getValue('hidTipoCanal');
    if ($("#hidPerfil_149").val() != "") {
        canal = getValue('ddlCanal');
    }

    if ($('#hidCheckCartaPoder').val() == 'S') 
    {
        RealizarVenta();
    }
    else 
    {
        if (Key_canalesPermitidosBiometria.indexOf(canal) > -1) 
        {
            Anthem_InvokePageMethod('ObtenerIdPadreBiometria', [],
				function (result) 
				{
				var response = result.value;
				var idpadre = response.split(',')[0];
				setValue('hidflagBioPost', response.split(',')[1]);
				setValue('hidflagHuelleroPost', response.split(',')[2]);
				setValue('hidIdPadreBio', idpadre);

				f_ValidacionIdentidad();
				});
        }
        else
            RealizarVenta();
    }
}
//Fin PROY-25335 - Contratación Electrónica - Release 0			

			//PROY-32129 :: INI
			function f_cerrar()
			{
				var nombreCtrlCamp = document.getElementById('hidIdCampSelec').value;
				var ifrGrillaItems = self.frames['ifraCondicionesVenta'];
				var ctrlCampUniv = ifrGrillaItems.document.getElementById(nombreCtrlCamp);
            
				ctrlCampUniv.selectedIndex = 0;
				document.getElementById('txtCodigoAlumno').value = '';
				document.getElementById('trCasoEspecial').style.display = 'none';
			}
			
			function f_guardarAlumno()
			{
				var tipoDoc = getValue('hidTipoDocumento');
				var nroDoc = getValue('hidNroDocumento');
				var uni = getValue('ddlListaUni');
				var codAlumno = getValue('txtCodigoAlumno');
				
				if (codAlumno == '') {
					alert('Debe ingresar el codigo del alumno');
				} else {
					Anthem_InvokePageMethod('registrarAlumno', [tipoDoc,nroDoc,uni,codAlumno], f_guardarAlumno_Callback);
				}
			}
			
			function f_guardarAlumno_Callback(objResponse)
			{
				var ifr = self.frames['ifraCondicionesVenta'];
			
				var fila = getValue('hidFila');
				var sResponse = objResponse.value;
				var sResultado = sResponse.split(';')[0];
				var sEstadoGrabar = sResponse.split(';')[1];
				if (sResultado == '1'){
					setValue('hidEstadoCasoEsp', sEstadoGrabar);
					
					HabilitarDetalleGrilla();
				document.getElementById('txtCodigoAlumno').value = '';
				document.getElementById('trCasoEspecial').style.display = 'none';
				}
				
			}
			function HabilitarDetalleGrilla() {
            var ifrGrillaDetalle2 = self.frames['ifraCondicionesVenta'];
            var strnombreGrillaDetalle2 = 'tblTabla' + ifrGrillaDetalle2.document.getElementById('hidTipoProductoActual').value;
            var tblDetalle2 = ifrGrillaDetalle2.document.getElementById(strnombreGrillaDetalle2);

            var controlComboBox = tblDetalle2.getElementsByTagName("select");
            for (var i = 0; i < controlComboBox.length; i++)
                controlComboBox[i].disabled = false;
        }
			//PROY-32129 :: FIN

	//INI PROY 31636-RENTESEG
			function validarDigitosTipoDoc(strNumDoc)
			{
				var stTipoDoc = getValue('ddlTipoDocumento');
				if(Key_codigoDocMigraYPasaporte.indexOf(stTipoDoc)>-1)
				{
					 validaCaracteres('ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789')
				}
				else
				{
					 validaCaracteres('0123456789')
				}
			}
			
			//INI PROY 31636-RENTESEG
		</script>
		<style>BODY { FONT-SIZE: 15px; FONT-FAMILY: verdana }
	A { COLOR: #333; TEXT-DECORATION: none }
	A:hover { COLOR: #ccc; TEXT-DECORATION: none }
	#mask { DISPLAY: none; Z-INDEX: 9000; LEFT: 0px; POSITION: absolute; TOP: 0px; BACKGROUND-COLOR: #000 }
	#boxes .window { PADDING-RIGHT: 20px; DISPLAY: none; PADDING-LEFT: 20px; Z-INDEX: 9999; LEFT: 0px; PADDING-BOTTOM: 20px; WIDTH: 460px; PADDING-TOP: 20px; POSITION: absolute; TOP: 0px; HEIGHT: 470px }
	#boxes #dialog { PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; WIDTH: 375px; PADDING-TOP: 10px; HEIGHT: 203px; BACKGROUND-COLOR: #ffffff }
	#boxes #dialog1 { WIDTH: 460px; HEIGHT: 470px }
	#dialog1 .d-header { BACKGROUND: url(images/login-header.png) no-repeat 0px 0px; WIDTH: 375px; HEIGHT: 150px }
	#dialog1 .d-header INPUT { BORDER-RIGHT: #cccccc 3px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 3px solid; MARGIN-TOP: 4px; PADDING-LEFT: 5px; FONT-SIZE: 15px; LEFT: 100px; PADDING-BOTTOM: 5px; BORDER-LEFT: #cccccc 3px solid; WIDTH: 200px; PADDING-TOP: 5px; BORDER-BOTTOM: #cccccc 3px solid; POSITION: relative; TOP: 60px; HEIGHT: 22px }
	#dialog1 .d-blank { BACKGROUND: url(images/login-blank.png) no-repeat 0px 0px; FLOAT: left; WIDTH: 267px; HEIGHT: 53px }
	#dialog1 .d-login { FLOAT: left; WIDTH: 108px; HEIGHT: 53px }
	#boxes #dialog2 { PADDING-RIGHT: 0px; PADDING-LEFT: 25px; BACKGROUND: url(images/notice.png) no-repeat 0px 0px; PADDING-BOTTOM: 20px; WIDTH: 150px; PADDING-TOP: 50px; HEIGHT: 150px }
		</style>
	</HEAD>
	<BODY onkeydown="cancelarBackSpace();" onload="inicio();">
		<form id="frmPrincipal" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trPrincipal" style="DISPLAY: none">
					<td class="header" align="center" height="19">Renovación PostPago</td>
				</tr>
				<tr id="trPrincipal1" style="DISPLAY: none">
					<td><IMG height="4" alt="" src="../../../images/spacer.gif"></td>
				</tr>
				<tr id="trPrincipal2" style="DISPLAY: none">
					<td><input class="Boton" id="btnNuevaEvaluacion" style="WIDTH: 125px; CURSOR: hand" onclick="nuevaEvaluacion();"
							type="button" value="Nueva Evaluación"></td>
				</tr>
				<tr id="trPrincipal3" style="DISPLAY: none">
					<td><IMG height="3" alt="" src="../../../images/spacer.gif"></td>
				</tr>
				<tr id="trPrincipal4" style="DISPLAY: none">
					<td>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr id="trPuntoVenta" style="DISPLAY: none">
								<td class="Arial10b" width="110">Canal:</td>
								<td width="150"><asp:dropdownlist id="ddlCanal" runat="server" CssClass="clsSelectEnableC" Width="130px" onChange="cambiarCanal();"></asp:dropdownlist></td>
								<td class="Arial10b" width="100">Punto de Venta:</td>
								<td><asp:dropdownlist id="ddlPuntoVenta" runat="server" CssClass="clsSelectEnableC" Width="230px" onChange="cambiarPuntoVenta();"
										DESIGNTIMEDRAGDROP="2537"></asp:dropdownlist></td>
								<td class="Arial10b">Vendedor</td>
								<td><asp:dropdownlist id="ddlVendedorSAP" runat="server" CssClass="clsSelectEnable" Width="200px" onchange="cambiarVendedor();"></asp:dropdownlist></td>
							</tr>
							<tr id="trDatosCliente" height="20">
								<td class="Arial10b" style="HEIGHT: 15px" width="110">Tipo Documento:</td>
								<td style="HEIGHT: 15px" width="150"><asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="clsSelectEnableC" Width="130px" onChange="cambiarTipoDocumento();"></asp:dropdownlist></td>
								<td class="Arial10b" style="HEIGHT: 15px" width="100">Nro. Documento:</td>
								<td style="HEIGHT: 15px" width="180"><asp:textbox onkeypress="validarDigitosTipoDoc(this);" onkeyup="this.value = this.value.toUpperCase();" id="txtNroDoc" runat="server" CssClass="clsInputEnabled"
										Width="120px"></asp:textbox></td>
								<td class="Arial10b" style="HEIGHT: 15px" align="left" width="60">Nro Línea:</td>
								<td style="HEIGHT: 15px" width="180"><asp:textbox onkeypress="validaCaracteres('0123456789')" id="txtNroLinea" runat="server" CssClass="clsInputEnabled"
										Width="100px" MaxLength="9"></asp:textbox></td>
								<td class="Arial10b" style="height:15px" width="100"><label id="lblNacionalidad">Nacionalidad:</label></td>
								<td style="height:15px" width="180"><asp:dropdownlist id="ddlNacionalidad" runat="server" CssClass="clsSelectEnableC" Width="130px" onChange=""></asp:dropdownlist></td>
							</tr>
								<tr id="trCartaPoder" height="20" runat="server">
								<td class="Arial10b" style="HEIGHT: 15px" width="110">Carta Poder:</td>
								<td style="HEIGHT: 15px" width="150"><asp:CheckBox id="checkCartaPoder" onclick="cambiarCartaPoder(this);" runat="server" CssClass="clsSelectEnable" ></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="Arial10b"></td>
								<td colSpan="4"></td>
								<td align="right" colSpan="2">
									<table>
										<tr>
											<td><label class="Arial10BRed" id="lblMensaje"></label></td>
											<td><input class="Boton" id="btnDetalleLinea" style="DISPLAY: none; WIDTH: 120px; CURSOR: hand"
													onclick="verDetalleLinea();" type="button" value="Ver Detalle Líneas">&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trPrincipal5" style="DISPLAY: none" height="23">
					<td align="center"><input class="BotonOptm" id="btnvalidarClaro" style="WIDTH: 150px; CURSOR: hand" onclick="validarClaro();"
							type="button" value="Validación Claro">
					</td>
				</tr>
				<tr id="trCargandoPuntoVenta" style="display:none">
					<td align="center">
						<div id="dvCargandoPuntoVenta" style="">
							<img src='../../../images/cargando3.gif'>
						</div>
					</td>
				</tr>
				<!--Inicio Renovacion por Bloqueo JAZ-->
				<tr id="trDetalleValidacionBloqueo" style="display:none">
					<td align="center">
						<div id="dvCargarImagenValidacionBloqueo" style="">
							<img src='../../../images/cargando3.gif'>
						</div>
					</td>
				</tr>
				<!--Fin Renovacion por Bloqueo JAZ-->
				<tr id="trDetalleCliente" style="DISPLAY: none">
					<td>
						<table cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="19">Datos del Cliente</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="Arial10b" width="125">&nbsp;Tipo Cliente:</td>
								<td class="Arial10b" colSpan="3"><label class="Arial10b" id="lblCategoriaCliente"></label></td>
								<td colSpan="2"></td>
							</tr>
							<tr id="trDetalleRUC" style="DISPLAY: none">
								<td class="Arial10b" width="125">&nbsp;Razón Social:</td>
								<td width="200"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtRazonSocial" maxLength="40" size="80"></td>
								<td colSpan="2"></td>
							</tr>
							<tr id="trDetalleDNI_1">
								<td class="Arial10b" width="125">&nbsp;Nombres:</td>
								<td width="200"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtNombre" maxLength="40" size="55"></td>
								<td class="Arial10b" width="125">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Apellido 
									Paterno:</td>
								<td width="300">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtApePat" maxLength="40" size="55"></td>
							</tr>
							<tr id="trDetalleDNI_2">
								<td class="Arial10b" width="125">&nbsp;Apellido Materno:</td>
								<td><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtApeMat" maxLength="40" size="55"></td>
								<td colSpan="2"></td>
							</tr>
							<tr id="trDetalleRUC_2" style="DISPLAY: none">
								<td class="Arial10b" width="125">&nbsp;Plan
								</td>
								<td width="275"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtplanactualRUC" maxLength="40" size="55"></td>
							</tr>
							<tr id="trDetalleRepLegal" style="DISPLAY: none">
								<td class="Arial10b" width="125">Representante Legal</td>
								<td width="275"><input class="clsInputEnabled" onpaste="return false;" id="txtRepLegal" maxLength="40"
										size="55">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!--Agregado para CAC-->
				<tr>
					<td>
						<table cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr id="trDetalleLinea" style="DISPLAY: none">
								<td class="Header" align="left" height="19">Datos de la Línea</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr id="trDatosLineaDAC" style="display:none">
								<td>
									<table>
										<tr>
											<td>
												<table>
													<tr>
														<td class="Arial10b" width="125">Cargo Fijo:</td>
														<td><input id="txtcargofijodac" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td></td>
														<td></td>
													</tr>
													<tr>
														<td class="Arial10b" width="125">Ciclo Facturación:</td>
														<td><input id="txtcicloFacturaciondac" class="clsInputEnabled" onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td></td>
													</tr>
													<tr>
														<td></td>
													</tr>
													<tr>
														<td></td>
													</tr>
												</table>
											</td>
											<td>
												<table>
													<tr>
														<td class="Arial10b" width="125">Plan:</td>
														<td><input id="txtplanactualdac" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td class="Arial10b" width="125">Servicios Activos
														</td>
														<td><textarea id="txtservadicdac" class="clsInputEnabled" rows="4" cols="40"></textarea>
														</td>
													</tr>
													<tr>
														<td></td>
													</tr>
													<tr>
														<td></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trDatosLineaCAC" style="display:none">
								<td>
									<table>
										<tr>
											<td>
												<table>
													<tr>
														<td class="Arial10b" width="150">Nro Linea:
														</td>
														<td><input id="txtNroLineaD" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td class="Arial10b" width="150">IMSI:</td>
														<td><input id="txtIMSI" class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
																maxLength="40"></td>
													</tr>
													<tr>
														<td class="Arial10b" width="150">Segmento:
														</td>
														<td><input id="txtSegmento" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td class="Arial10b" width="150">Ciclo Facturación</td>
														<td><input id="txtcicloFacturacion" class="clsInputEnabled" onpaste="return false;" maxLength="40"></td>
													</tr>
													<tr>
														<td class="Arial10b" width="150">Limite de Credito</td>
														<td><input id="txtLimiteCredito" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40">
														</td>
													</tr>
												</table>
											</td>
											<td>
											</td>
											<td>
												<table>
													<tr>

														<td class="Arial10b">Plan&nbsp;Comercial</td>
														<td><input id="txtPlanComercial" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40" style="WIDTH: 180px;"></td>		
														<td class="Arial10b">Plan&nbsp;Base</td>
														<td><input id="txtplanactual" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
														<td class="Arial10b">Cargo&nbsp;Fijo</td>
														<td><input id="txtcargofijo" class="clsInputEnabled" onkeypress="validaCaracteresNombres();"
																onpaste="return false;" maxLength="40"></td>
													</tr>
												</table>
												<table>
													<tr>
														<td class="Arial10b" width="125">Servicios Activos
														</td>
														<td><textarea id="txtservadic" class="clsInputEnabled" rows="4" cols="40"></textarea></td>
													</tr>
												</table>
												<table>
													<tr>
														<td></td>
													</tr>
												</table>
												<table>
													<tr>
														<td></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
								</td>
				</tr>
				<tr id="trDetalleFacturacion" style="DISPLAY: none">
								<td>
						<table cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="19">Datos de Facturación</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr id="trDetalleFacturacion_1">
								<td class="Arial10b" width="125">&nbsp;Dirección:</td>
								<td class="Arial10b" style="WIDTH: 363px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtDireccionFact" style="WIDTH: 322px; HEIGHT: 17px" maxLength="40" size="48"></td>
							</tr>
							<tr id="trDetalleFacturacion_2">
								<td class="Arial10b" width="125">&nbsp;Departamento:</td>
								<td class="Arial10b" style="WIDTH: 363px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtDepartamentoFact" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="25">
								</td>
								<td class="Arial10b" width="150">&nbsp;Provincia:</td>
								<td class="Arial10b"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtProvinciaFact" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="24"></td>
							</tr>
							<tr id="trDetalleFacturacion_3">
								<td class="Arial10b" width="125">&nbsp;Distrito:</td>
								<td class="Arial10b" style="WIDTH: 363px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtDistritoFact" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="25">
								</td>
								<td class="Arial10b" width="150">&nbsp;Correo Electrónico:</td>
								<td class="Arial10b"><INPUT class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtCorreoElecFact" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="24" name="txtCorreoElecFact">
								</td>
							</tr>
							<tr id="trDetalleFacturacion_4">
								<td class="Arial10b" width="125">&nbsp;Nro. Referencia:</td>
								<td class="Arial10b" style="WIDTH: 363px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtReferenciaFact" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="25"></td>
							</tr>
						</table>
					</td>
							</tr>
				<tr id="trDetalleAcuerdoLinea" style="DISPLAY: none">
					<td>
						<table cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="19">Datos de último acuerdo de la línea</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr id="trDetalleAcuerdoLinea_1">
								<td class="Arial10b" width="125">&nbsp;Fecha Inicio CEDE:</td>
								<td style="WIDTH: 364px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtIniApadece" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="17"></td>
								<td class="Arial10b" width="150">&nbsp;Reintegro:</td>
								<td><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtReintegro" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="16"></td>
							</tr>
							<tr id="trDetalleAcuerdoLinea_2">
								<td class="Arial10b" width="125">&nbsp;Fecha Fin CEDE:</td>
								<td style="WIDTH: 364px"><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtFinApadece" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="17"></td>
								<td class="Arial10b" width="150">&nbsp;Total Reintegro a Facturar:</td>
								<td><input class="clsInputEnabled" onkeypress="validaCaracteresNombres();" onpaste="return false;"
										id="txtTotalReintgro" style="WIDTH: 184px; HEIGHT: 17px" maxLength="40" size="16"></td>
							</tr>
						</table>
						<br>
					</td>
				</tr>
				<!--Agregado para CAC-->
				<tr id="trConsultarDC" style="DISPLAY: none" height="23">
					<td align="center"><input class="BotonOptm" id="btnConsultaDC" style="WIDTH: 185px; CURSOR: hand" onclick="btningcondventa();"
							type="button" value="Ingresar Condiciones de Venta">
					</td>
				</tr>
				<tr id="trCondicionVenta" style="DISPLAY: none">
					<td>
						<table cellPadding="1" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">Condiciones de Venta</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="Arial10b" width="125">&nbsp;Tipo Operación:</td>
								<td><asp:dropdownlist id="ddlTipoOperacion" runat="server" CssClass="clsSelectEnableC" Width="150px" onchange="cambiarTipoOperacion(this);"></asp:dropdownlist></td>
								<td class="Arial10b" colspan="2"><label id="lblCuotas" style="font-weight: bold;color:black"></label><!-- PROY-29123 VENTA EN CUOTAS -->
								<img id="imgCuotasBRMS" src='../../../images/cargando3.gif' style="display:none;" height="16" width="16">
								</td>
								<td class="Arial10b" style="DISPLAY: none">&nbsp;</td>
								<td colSpan="2" class="Arial10b" valign="middle" align="right">
								Color Equipos sin stock: &nbsp;
								                                 <span id="spaColor" 
								
                                style="border-color:DodgerBlue;border=3px solid DodgerBlue;color:<%= ConfigurationSettings.AppSettings("BloqueoEquipoSinStockColor") %>">
                                Equipo
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</span>
								</td>
							</tr>
							<tr>
								<td class="Arial10b" width="125">&nbsp;Oferta:</td>
								<td width="170"><asp:dropdownlist id="ddlOferta" runat="server" CssClass="clsSelectEnableC" Width="150px" onchange="cambiarTipoOferta();"></asp:dropdownlist></td>
								<td class="Arial10b" id="tdRetFideCAC" style="DISPLAY: none" width="125">&nbsp;Tipo Renovación:</td>
								<td class="Arial10b" id="tdRetFideCAC1" style="DISPLAY: none"><asp:dropdownlist id="ddlTipoRenovacion" runat="server" CssClass="clsSelectEnableC" Width="150px" onchange="cambiarTipoRenovacion(this);">
										<asp:ListItem Value="00">Seleccionar</asp:ListItem>
										<asp:ListItem Value="Fidelizado">Regular</asp:ListItem>
										<asp:ListItem Value="Retenido">Retenido</asp:ListItem>
									</asp:dropdownlist></td>
									
								<td id="tdPlanNoVigente"  width="125" class="Arial10b" style="DISPLAY: none">&nbsp;Mantener Plan:</td>
								<td id="tdPlanNoVigente1" class="Arial10b" style="DISPLAY: none"><asp:CheckBox ID="chkPlanNoVigente" runat="server" onclick="javascript:f_CheckPlanNoVigente(this);" Text=""></asp:CheckBox></td>
								<td colSpan="2">&nbsp;</td>
							</tr>
							<TR>
								<TD class="Arial10b" style="HEIGHT: 14px" width="125">&nbsp;Modalidad de Venta:</TD>
								<TD class="Arial10b" style="HEIGHT: 14px" width="170"><asp:dropdownlist id="ddlModalidad" runat="server" CssClass="clsSelectEnableC" Width="150px" onchange="cambiarModalidadVenta(this);"></asp:dropdownlist></TD>
								<td  width="125" class="Arial10b" >&nbsp;Grupo Producto:</td>
								<td  class="Arial10b"  style="HEIGHT: 14px" width="170"><asp:dropdownlist id="ddlGProducto" runat="server" CssClass="clsSelectEnableC" Width="150px" onchange="cambiarGrupoProducto(this);"></asp:dropdownlist></td>
								<TD style="HEIGHT: 14px" colSpan="2"></TD>
							</TR>
							<tr>
								<td colSpan="6"><IMG height="5" alt="" src="../../../images/spacer.gif" width="5" border="0"></td>
							</tr>
							<tr id="trTabProducto">
								<td colSpan="6">
									<table cellSpacing="0" cellPadding="1" border="0">
										<tr>
											<td class="tab_inactivo" id="tdMovil" borderColor="#000099" align="center" width="105"><A href="javascript:f_MostrarTab('Movil');">Móvil</A></td>
											<td class="tab_inactivo" id="tdBAM" borderColor="#000099" align="center" width="105"><A href="javascript:f_MostrarTab('BAM');">BAM</A></td>
											<td class="tab_inactivo" id="tdDTH" borderColor="#000099" align="center" width="105"><A href="javascript:f_MostrarTab('DTH');">Claro 
													TV SAT</A></td>
											<td class="tab_inactivo" id="tdHFC" borderColor="#000099" align="center" width="105"><A href="javascript:f_MostrarTab('HFC');">3Play</A></td>
											<td class="tab_inactivo" id="tdFijo" borderColor="#000099" align="center" width="105"><A href="javascript:f_MostrarTab('Fijo');">Fijo 
													Inalámbrico</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr id="trLCDisponible">
								<td class="Arial10b" colSpan="6">&nbsp;LC Disponible&nbsp;<label id="lblLCDisponiblexProd">Móvil:&nbsp;&nbsp;&nbsp;&nbsp;</label>
									<input class="clsInputDisabled" id="txtLCDisponiblexProd" style="TEXT-ALIGN: right" readOnly
										size="8">
								</td>
							</tr>
							<tr id="trCarrito">
								<td colSpan="5">&nbsp; <INPUT class="Boton" id="btnAgregarPlan" style="WIDTH: 125px; CURSOR: hand" onclick="agregarPlan();"
										type="button" value="Agregar Item" name="btnAgregarPlan">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trCondicionVentaDetalle" style="DISPLAY: none">
					<td><iframe id="ifraCondicionesVenta" style="WIDTH: 100%" name="ifraCondicionesVenta" src="sisact_ifr_condiciones_venta.aspx"
							frameBorder="no" scrolling="no" onload="autoSizeIframe();"></iframe>
					</td>
				</tr>
				<tr>
					<td height="20"></td>
				</tr>
				<tr id="trEvaluarResultado" style="DISPLAY: none">
					<td class="Arial10b" style="POSITION: relative; nowrap: false" align="center"><input class="BotonOptm" id="btnEvaluar" style="WIDTH: 150px; CURSOR: hand" onclick="javascript:EvaluarSec();"
							type="button" value="Evaluar" name="btnEvaluar">
					</td>
				</tr>
				<!--PROY-32129 :: INI -->
				<tr id="trCasoEspecial" style="DISPLAY: none">
					<td>
						<table cellPadding="1" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">INGRESAR DATOS DE INSTITUCION</td>
							</tr>
						</table>
						<table>
							<tr>
								<td class="Arial10b" width="125">&nbsp;Lista de Univ:</td>
								<td><asp:dropdownlist id="ddlListaUni" runat="server" CssClass="clsSelectEnableC" Width="170px" onchange="cambiarTipoOperacion(this);"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="Arial10b" width="125">&nbsp;Codigo de Alumno:</td>
								<td><asp:textbox onkeypress="validaCaracteres('0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz');" id="txtCodigoAlumno" runat="server" CssClass="clsInputEnabled" 
										Width="170px"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center"><input class="BotonOptm" id="btnCancelarCasoEsp" style="WIDTH: 185px; CURSOR: hand" onclick="f_cerrar();"
									type="button" value="Cerrar">
								</td>
								<td align="center"><input class="BotonOptm" id="btnGuardarCasoEsp" style="WIDTH: 185px; CURSOR: hand" onclick="f_guardarAlumno();"
									type="button" value="Guardar">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<!--PROY-32129 :: FIN -->
				<tr>
					<td height="20"></td>
				</tr>
				<tr id="trResultado" style="DISPLAY: none">
					<td>
						<table cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">&nbsp;Resultado Evaluación</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Arial10b" width="125">Resultado:</td>
								<td width="275"><input class="clsInputDisabled" id="txtResultado" style="TEXT-ALIGN: left" readOnly size="45"></td>
								<td class="Arial10b" style="DISPLAY: none" width="125">Factor Renovación:</td>
								<td style="DISPLAY: none" width="275"><input class="clsInputDisabled" id="txtFactorRenovacion" style="TEXT-ALIGN: left" readOnly
										size="45"></td>
								<td class="Arial10BRed" width="180">&nbsp;Comportamiento Consolidado Cliente:</td>
								<td width="100"><input class="clsInputDisabled" id="txtComportamientoClaro" style="TEXT-ALIGN: right" readOnly
										size="8"></td>
								<td class="Arial10b" id="tdRiesgo" width="105">&nbsp;Riesgo:</td>
								<td id="tdTxtRiesgo"><input class="clsInputDisabled" id="txtRiesgo" style="TEXT-ALIGN: left" readOnly size="12"></td>
							</tr>
							<tr id="trGarantia">
								<td class="Arial10b" width="125">Tipo Garantía:</td>
								<td width="275"><input class="clsInputDisabled" id="txtTipoGarantia" style="TEXT-ALIGN: left" readOnly
										size="45"></td>
								<td class="Arial10b" width="105">&nbsp;Importe S/.:</td>
								<td><input class="clsInputDisabled" id="txtImporte" style="TEXT-ALIGN: right" readOnly size="8"></td>
								<td class="Arial10b" id="tdLCDisponible" width="110">&nbsp;LC Disponible:</td>
								<td id="tdTxtLCDisponible"><input class="clsInputDisabled" id="txtLCDisponible" style="TEXT-ALIGN: right" readOnly
										size="12"></td>
								<td colSpan="2"><input class="BotonOptm" id="btnDetalleGarantia" style="WIDTH: 150px; CURSOR: hand" onclick="verDetalleGarantia();"
										type="button" value="Detalle Garantías"></td>
							</tr>
							<tr id="trPresentaPoderes" style="DISPLAY: none">
								<td class="Arial10b" colSpan="8"><input id="chkPresentaPoderes" disabled type="checkbox" value="">
									No Requiere Presentar Poderes
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trRepresentante" style="DISPLAY: none">
					<td>
						<table cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">&nbsp;Representante Legal</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr id="tblDatosRepresentante" height="70">
								<td><iframe class="clsGridRow" id="ifraRepresentante" style="WIDTH: 75%; HEIGHT: 100%" name="ifraRepresentante"
										src="" frameBorder="no" scrolling="yes"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><IMG height="2" alt="" src="../../../images/spacer.gif"></td>
				</tr>
				<tr id="trComentario" style="DISPLAY: none">
					<td>
						<table cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">Comentarios del Punto de Venta</td>
							</tr>
						</table>
						<table class="contenido" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<tr>
								<td class="Arial10b" vAlign="top" width="150">Comentario:<br>
									<SPAN style="COLOR: #ff0000">&nbsp; *(Max 200 Caracteres)</SPAN></td>
								<td class="Arial10b"><asp:textbox id="txtComentarioPDV" onblur="return validaTextAreaLongitud(this, 200, true);" style="TEXT-TRANSFORM: uppercase"
										runat="server" CssClass="inputTextArea" Width="80%" Rows="5" TextMode="MultiLine"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><IMG height="2" alt="" src="../../../images/spacer.gif"></td>
				</tr>
				<tr id="trGrabar" align="center">
					<td colSpan="6"><input class="BotonOptm" id="btnRealizarVenta" style="DISPLAY: none; WIDTH: 150px; CURSOR: hand"
							onclick="javascript:ValidarIdentidad();" type="button" value="Realizar Venta"> <input class="BotonOptm" id="btnEnviarACreditos" style="DISPLAY: none; WIDTH: 150px; CURSOR: hand"
							onclick="javascript:EnviarACreditos();" type="button" value="Enviar a Créditos">
						<input class="BotonOptm" id="btnGrabarSec" style="DISPLAY: none; WIDTH: 150px; CURSOR: hand"
							onclick="javascript:GrabarSEC();" type="button" value="Grabar">
					</td>
				</tr>
				<tr>
					<td colSpan="7" height="20"></td>
				</tr>
				<tr id="trResultadoRVenta" style="DISPLAY: none">
					<td>
						<table cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">Consulta Equipos</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="0" width="65%" border="0">
							<tr>
								<td class="Arial10B" style="WIDTH: 130px">Serie Equipo (Imei):</td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox onkeypress="validarNumero(event);" id="txtImei" onkeydown="validarNumero(event);"
										onkeyup="BorrarDatosImei();" runat="server" MaxLength="18" cssclass="clsInputEnableB" ReadOnly="False" width="140px"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px"><input class="Boton" id="btnBuscarImei" onmouseover='this.className="BotonResaltado";'
										style="WIDTH: 80px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:BuscarImei()" onmouseout='this.className="Boton";' type="button"
										value="Validar Imei" name="btnBuscarImei"></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 130px">Código de Material:</td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtMaterialImei" runat="server" Width="120px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">Descripción de Artículo:</td>
								<td class="Arial10B" style="WIDTH: 220px"><asp:textbox id="txtArticuloImei" runat="server" Width="250px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
							</tr>
							<TR>
								<TD class="Arial10B" style="WIDTH: 130px">Lista de Precio Equipo:</TD>
								<TD class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="ddlPrecio" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="150px"
										onchange="javascript:cargarPrecio();"></asp:dropdownlist></TD>
								<td class="Arial10B" style="WIDTH: 120px">Precio de Venta:</td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtPrecioVentaEquipoDAC" CssClass="clsInputDisable" ReadOnly="True" width="150px"
										Runat="server"></asp:textbox></td>
							</TR>
							<tr>
								<td colSpan="7" height="20" />
							</tr>
						</table>
					</td>
				</tr>
				<!--Consolidado 12122014-->
				<tr id="trResultadoRVentaChip" style="DISPLAY: none">
					<td>
						<table cellPadding="0" width="100%" border="0">
							<tr>
								<td class="Header" align="left" height="18">Precio Chip</td>
							</tr>
						</table>
						<table class="Contenido3" cellSpacing="1" cellPadding="0" width="65%" border="0">
							<tr>
								<td class="Arial10B" style="WIDTH: 130px">Serie Chip (Iccid):</td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox onkeypress="validaCaracteres('0123456789')" id="txtSerieChip" onkeyup="BorrarDatosICCID();"
										runat="server" Width="140px" MaxLength="18" cssclass="clsInputEnableB"></asp:textbox></td>
								<td><INPUT class="Boton" id="btnValidarICCID" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 100px; CURSOR: hand; HEIGHT: 19px" onclick="javascript:consultarIccid();"
										onmouseout="this.className='Boton';" type="button" value="Validar ICCID" name="btnValidarICCID"></td>
								<td>
									<asp:label id="lblHLR" runat="server" CssClass="Arial10BRed"></asp:label>&nbsp;&nbsp;
									<asp:label id="lblPlanChip" runat="server" CssClass="Arial10BRed"></asp:label>
								<td><asp:label id="lblPlanLTE" runat="server" CssClass="Arial10BRed"></asp:label></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 130px">Código de Material:</td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtMaterialICCID" runat="server" Width="120px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px">Descripción de Artículo:</td>
								<td class="Arial10B" style="WIDTH: 220px"><asp:textbox id="txtArticuloICCID" runat="server" Width="250px" cssclass="clsInputDisable" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 130px">Lista de Precio Chip:</td>
								<td class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="ddlPrecioChips" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="150px"
										onchange="javascript:cargarPrecioChips();"></asp:dropdownlist></td>
								<td class="Arial10B">Precio de Venta:</td>
								<td class="Arial10B"><asp:textbox id="txtPrecioVentaChip" runat="server" Width="160px" cssclass="clsInputDisable"
										ReadOnly="True"></asp:textbox></td>
								<TD class="Arial10B" style="WIDTH: 120px">Motivo de Reposición:</TD>
								<TD class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="dllMotivoDAC" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="199px"
										Enabled="False"></asp:dropdownlist></TD>
								<TD class="Arial10B" style="WIDTH: 150px"><P></P>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
				<!--Consolidado 12122014-->
				<!--Consolidado 12122014-->
				<tr id="trDetalleVentaEquipo" style="DISPLAY: none">
					<td>
						<table class="contenido" cellSpacing="2" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="9" height="20">Datos del Equipo&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 160px">Descripción del Equipo:</td>
								<td class="Arial10B" style="WIDTH: 204px"><asp:dropdownlist id="ddlCodEquipo" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="250px"
										onchange="f_CambiaImei();"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 130px">Código del Equipo:</td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtCodEquipo" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 130px">Serie del Equipo:</td>
								<td class="Arial10B" id="tdSerieIccid" style="WIDTH: 150px"><select class="clsSelectEnable" id="cboIMEIArt" style="WIDTH: 200px" name="cboIMEIArt"></select></td>
								<td class="Arial10B" align="right">&nbsp;&nbsp;
								</td>
							</tr>

							<tr id="trProteccionMovil" style="DISPLAY: none"><!--'PROY-24724-IDEA-28174 - INICIO-->
								<td class="Arial10B" style="WIDTH: 160px" id="lblProtmovil">Protección Móvil:</td>
								<td class="Arial10B" style="WIDTH: 130px"><asp:CheckBox ID="chkProMovil"  onclick="javascript:f_ProteccionMovil(this);" Text="" Checked="True"  runat="server"></asp:checkbox></td>                                                                                                                                                                                          
								<td class="Arial10B" style="WIDTH: 130px" id="lblPrima">Prima:</td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtPrima" autopostback="true" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server" Visible=True></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 130px" id="lblDeducible">Deducible:</td>
							    <td class="Arial10B" align="left" width="150"><asp:textbox id="txtDeducible" autopostback="true" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server" Visible=True></asp:textbox></td>
								<td class="Arial10B" align="right">&nbsp;&nbsp;</td>
							</tr><!--'PROY-24724-IDEA-28174 - FIN-->
						
				<tr>
								<td class="Arial10B" style="WIDTH: 160px">Lista de Precio Equipo:</td>
								<td class="Arial10B" style="WIDTH: 204px">
									<P><asp:dropdownlist id="ddlListaPrecio" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="150px"
											onchange="javascript:cargarPrecioEquipo();"></asp:dropdownlist></P>
					</td>
								<td class="Arial10B" style="WIDTH: 120px">Precio de Venta:</td>
								<td class="Arial10B" align="left" width="150"><asp:textbox id="txtPrecioVentaEquipo" CssClass="clsInputDisable" ReadOnly="True" width="150px"
										Runat="server"></asp:textbox></td>
								
								<td id= "tdPrecioVentaCAC" class="Arial10B" style="WIDTH: 120px">Descuento Equipo:</td>
								<td id= "tdtxtPrecioVentaCAC" class="Arial10B" style="WIDTH: 150px"><asp:textbox onkeypress="f_EventoSoloNumerosEnteros();f_actualizaFlagDscto('false');" onpaste="return false;" id="txtDescuentoEquipo"
										ondrop="return false;" CssClass="clsInputEnableB" MaxLength="7" width="150px" Runat="server"></asp:textbox></td>
								<td id= "tdbtnValidarDescuentoCAC" class="Arial10B" align="right"><INPUT class="Boton" id="btnDescuentoEquipo" onmouseover="this.className='BotonResaltado';"
										style="WIDTH: 120px; CURSOR: hand; HEIGHT: 19px" onclick="validarDescuento();" onmouseout="this.className='Boton';"
										type="button" value="Validar Descuento" name="btnDescuentoEquipo">&nbsp;&nbsp;
					</td>
				</tr>
						</table>
					</td>
				</tr>

				<!--Consolidado 12122014-->
				<!--Consolidado 12122014-->
				<tr id="trDetalleVentaChip" style="DISPLAY: none">
					<td>
						<table class="contenido" cellSpacing="2" width="100%" border="0">
							<tr>
								<td class="header" align="left" colSpan="9" height="20">Datos del Chip&nbsp;
								</td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">Número de Línea:</td>
								<TD class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtNumeroLineaChip" CssClass="clsInputDisable" ReadOnly="True" width="150px"
										Runat="server"></asp:textbox></TD>
								<td><asp:label id="lblHLRCAC" runat="server" CssClass="Arial10BRed"></asp:label></td>
								<td><asp:label id="lbl4GCAC" runat="server" CssClass="Arial10BRed" /></asp:label></td>
								<td><asp:label id="lblPlanLTECAC" runat="server" CssClass="Arial10BRed"></asp:label></td>
							</tr>
							<tr>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">Descripción del Chip:</td>
								<td class="Arial10B" style="WIDTH: 204px; HEIGHT: 16px"><asp:dropdownlist id="ddlCodChip" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="250px"
										onchange="javascript:f_CambiaIccid();"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">Código del Chip:</td>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px"><asp:textbox id="txtCodChip" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server"></asp:textbox></td>
								<td class="Arial10B" style="WIDTH: 150px; HEIGHT: 16px">Serie del Chip(ICCID):</td>
								<td class="Arial10B" id="tdSerieChip" style="HEIGHT: 16px" width="150"><select class="clsSelectEnable" id="cboICCIDChip" style="WIDTH: 200px" name="cboICCIDChip"></select></td>
							</tr>
							<!--Consolidado 12122014-->
							<tr>
								<td class="Arial10B" style="WIDTH: 150px">Lista de Precio Chip:</td>
								<td class="Arial10B" style="WIDTH: 204px"><asp:dropdownlist id="ddlPrecioChip" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="150px"></asp:dropdownlist></td>
								<td class="Arial10B" style="WIDTH: 120px">Precio de Venta:</td>
								<TD class="Arial10B" style="WIDTH: 150px"><asp:textbox id="txtpreciochip" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server"></asp:textbox></TD>
								<TD class="Arial10B" style="WIDTH: 120px">Motivo de Reposición:</TD>
								<TD class="Arial10B" style="WIDTH: 150px"><asp:dropdownlist id="ddlRenovChip" onkeydown="" runat="server" CssClass="clsSelectEnable" Width="199px"
										Enabled="False"></asp:dropdownlist></TD>
								<TD class="Arial10B" style="WIDTH: 150px"><P><!-- Inicio E77658 -->
										<!-- Fin E77658 --></P>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
				<!--Consolidado 12122014-->
				<tr>
					<td>
			<table id="tblClaroPuntosDescuento" style="DISPLAY: none" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td class="Header" align="left" height="18">Claro Puntos a Utilizar y Descuento en 
						Soles</td>
				</tr>
			</table>
						<table class="Contenido3" id="tblClaroPuntosDescuento1" style="DISPLAY: none" cellSpacing="1"
				cellPadding="0" width="50%" border="0">
				<tr>
					<td class="Arial10B">Claro puntos a utilizar
					</td>
					<td class="Arial10B"><asp:textbox onkeypress="return self.frames['ifraCondicionesVenta'].EvaluarKey(event, this);"
										onpaste="return false" id="txtClaroClubPuntosUtilizar" onblur="javascript:self.frames['ifraCondicionesVenta'].CalcularClaroClubPuntos(this, '1');"
							Width="92" MaxLength="6" cssclass="clsInputEnableB" Runat="server"></asp:textbox></td>
					<td class="Arial10B">Soles de Descuento
					</td>
					<td class="Arial10B"><asp:textbox id="txtDescuentoClaroClub" CssClass="clsInputDisable" ReadOnly="True" width="150px"
							Runat="server" Text="0"></asp:textbox></td>
				</tr>
				<tr>
					<td class="Arial10B" colSpan="4"><asp:label id="lblClaroClubMsgError" CssClass="Arial10BRed" Runat="server"></asp:label></td>
					<td class="Arial10B">&nbsp;</td>
					<td class="Arial10B">&nbsp;</td>
					<td class="Arial10B">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="7" height="20"></td>
				</tr>
			</table>
					</td>
				</tr>
				<tr id="trDetalleDatosVenta" style="DISPLAY: none">
					<td>
			<table cellPadding="0" width="100%" border="0">
				<tr>
					<td class="Header" align="left" height="18">Datos de Venta</td>
				</tr>
			</table>
			<table class="Contenido3" cellSpacing="1" cellPadding="0" width="80%" border="0">
				<tr>
					<td class="Arial10B" style="WIDTH: 130px">Precio de Equipo:</td>
					<td class="Arial10B"><asp:textbox id="txtPrecioVenta" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server"
							Text="0"></asp:textbox></td>
					<td class="Arial10B" style="WIDTH: 130px">Total a Pagar:</td>
					<td class="Arial10B"><asp:textbox id="txtTotalAPagar" CssClass="clsInputDisable" ReadOnly="True" width="150px" Runat="server"
							Text="0"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="7" height="20"></td>
				</tr>
			</table>
					</td>
				</tr>
			<tr>
				<td colSpan="7" height="20"></td>
			</tr>
			<tr id="trGenerarPedido" style="DISPLAY: none" align="center">
				<td colSpan="7" height="20"><input class="BotonOptm" id="btnGenerarPedido" style="WIDTH: 150px; CURSOR: hand" onclick="javascript:GenerarPedido()"
						type="button" value="Generar Pedido">
				</td>
			</tr>
			</TABLE>
			<iframe id="ifrmEvaluacion" name="ifrmEvaluacion" frameBorder="no" width="10" height="10">
			</iframe><iframe id="iframeAuxiliar" name="iframeAuxiliar" frameBorder="no" width="10" height="10">
			</iframe>
			<!-- ---------------------------------------------------------------------------------------------------------------------------><input id="hidFlagExcepcionDC7" type="hidden" name="hidFlagExcepcionDC7" runat="server">
			<input id="hidPerfil_149" type="hidden" name="hidPerfil_149" runat="server"> <input id="hidIntentos10" type="hidden" value="0" name="hidIntentos10" runat="server">
			<input id="hidBLVendedor" type="hidden" name="hidBLVendedor" runat="server"> <input id="hidListaPuntoVenta" type="hidden" name="hidListaPuntoVenta" runat="server">
			<input id="hidVerDetalleLinea" type="hidden" name="hidVerDetalleLinea" runat="server">
			<input id="hidVerVentaProactiva" type="hidden" name="hidVerVentaProactiva" runat="server">
			<input id="hidListaBlackList" type="hidden" name="hidListaBlackList" runat="server">
			<input id="hidListaParametroGeneral" type="hidden" name="hidListaParametroGeneral" runat="server">
			<input id="hidTiempoInicioReg" type="hidden" name="hidTiempoInicioReg" runat="server">
			<input id="hidMensaje" type="hidden" name="hidMensaje" runat="server"> <input id="hidCodError" type="hidden" name="hidCodError" runat="server">
			<input id="hidCodErrorPedido" type="hidden" name="hidCodErrorPedido" runat="server"><input id="hidUsuarioNoRegistrado" type="hidden" name="hidUsuarioNoRegistrado" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS DATACREDITO ---------------------------------------------><input id="hidListaRiesgo" type="hidden" name="hidListaRiesgo" runat="server">
			<input id="hidRiesgoDC" type="hidden" name="hidRiesgoDC" runat="server"> <input id="hidRiesgoTextoDC" type="hidden" name="hidRiesgoTextoDC" runat="server">
			<input id="hidNroOperacionDC" type="hidden" name="hidNroOperacionDC" runat="server">
			<input id="hidDeudaFinancieraDC" type="hidden" name="hidDeudaFinancieraDC" runat="server">
			<input id="hidRespuestaDC" type="hidden" name="hidRespuestaDC" runat="server"> <input id="hidAutonomia" type="hidden" name="hidAutonomia" runat="server">
			<input id="hidCreditosxNombres" type="hidden" name="hidCreditosxNombres" runat="server">
			<input id="hidCreditosxDC7" type="hidden" name="hidCreditosxDC7" runat="server">
			<input id="hidAdjuntarIngreso" type="hidden" name="hidAdjuntarIngreso" runat="server">
			<input id="hidBlacklistCred" type="hidden" name="hidBlacklistCred" runat="server">
			<input id="hidExcepcionBlacklist" type="hidden" name="hidExcepcionBlacklist" runat="server">
			<input id="hidDatosDC" type="hidden" name="hidDatosDC" runat="server"> <input id="hidEdadDC" type="hidden" name="hidEdadDC" runat="server"><input id="hidCreditosxReglas" type="hidden" name="hidCreditosxReglas" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS DATACREDITO --------------------------------------------->
			<!-- ------------------------------------------------------ PARAMETROS PORTABILIDAD --------------------------------------------><input id="hidOperadorCedente" type="hidden" name="hidOperadorCedente" runat="server">
			<input id="hidNumeroContacto" type="hidden" name="hidNumeroContacto" runat="server">
			<input id="hidNumeroFolio" type="hidden" name="hidNumeroFolio" runat="server"> <input id="hidModalidad" type="hidden" name="hidModalidad" runat="server">
			<input id="hidArchivos" type="hidden" name="hidArchivos" runat="server"> <input id="hidTienePortabilidad" type="hidden" name="hidTienePortabilidad" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS PORTABILIDAD -------------------------------------------->
			<!-- ------------------------------------------------------ PARAMETROS RUC -----------------------------------------------------><input id="hidNroRepresentante" type="hidden" name="hidNroRepresentante" runat="server">
			<input id="hidListaRepresentante" type="hidden" name="hidListaRepresentante" runat="server">
			<input id="hidComentarioPDV" type="hidden" name="hidComentarioPDV" runat="server"><input id="hidRazonSocial" type="hidden" name="hidRazonSocial" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS RUC ----------------------------------------------------->
			<!-- ------------------------------------------------------ PARAMETROS DNI -----------------------------------------------------><input id="hidNroDocumento" type="hidden" name="hidNroDocumento" runat="server">
			<input id="hidFechaNac" type="hidden" name="hidFechaNac" runat="server"> <input id="hidNombre" type="hidden" name="hidNombre" runat="server">
			<input id="hidApePaterno" type="hidden" name="hidApePaterno" runat="server"> <input id="hidApeMaterno" type="hidden" name="hidApeMaterno" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS DNI -----------------------------------------------------><input id="hidCFTotal" type="hidden" name="hidCFTotal" runat="server">
			<input id="hidNroSEC" type="hidden" name="hidNroSEC" runat="server"> <input id="hidOficinaActual" type="hidden" name="hidOficinaActual" runat="server">
			<input id="hidOficina" type="hidden" name="hidOficina" runat="server"> <input id="hidTipoOfertaActual" type="hidden" name="hidTipoOfertaActual">
			<input id="hidTipoProductoActual" type="hidden" name="hidTipoProductoActual"> <input id="hidCreditosxCE" type="hidden" name="hidCreditosxCE" runat="server"><input id="hidFactorLC" type="hidden" name="hidFactorLC" runat="server">
			<!-- ------------------------------------------------------ CASO ESPECIAL ------------------------------------------------------><input id="hidlistaCEPlanBscs" type="hidden" name="hidlistaCEPlanBscs">
			<input id="hidlistaCEPlan" type="hidden" name="hidlistaCEPlan"> <input id="hidlistaCERiesgo" type="hidden" name="hidlistaCERiesgo">
			<input id="hidWhitelistCE" type="hidden" name="hidWhitelistCE"> <input id="hidCargoFijoMaxCE" type="hidden" name="hidCargoFijoMaxCE">
			<input id="hidCasoEspecial" type="hidden" name="hidCasoEspecial" runat="server"><input id="hidCasoEspecialText" type="hidden" name="hidCasoEspecialText" runat="server">
			<!-- ------------------------------------------------------ PARAMETROS CONSULTA BSCS -------------------------------------------><input id="hidClienteClaro" type="hidden" name="hidClienteClaro" runat="server">
			<input id="hidNroLineas" type="hidden" name="hidNroLineas" runat="server"> <input id="hidTop" type="hidden" name="hidTop" runat="server">
			<input id="hidEvaluarMovil" type="hidden" name="hidEvaluarMovil" runat="server">
			<input id="hidDeuda" type="hidden" name="hidDeuda" runat="server"> <input id="hidPlanesActivos" type="hidden" name="hidPlanesActivos" runat="server">
			<input id="hidClaseCliente" type="hidden" name="hidClaseCliente" runat="server">
			<input id="hidArchivosEnvioCreditos" type="hidden" name="hidArchivosEnvioCreditos" runat="server">
			<input id="hidCreditosxAsesor" type="hidden" name="hidCreditosxAsesor" runat="server">
			<input id="hidMensajeAutonomia" type="hidden" name="hidMensajeAutonomia" runat="server">
			<input id="hidCentro" type="hidden" name="hidCentro" runat="server"> <input id="hidCanalSap" type="hidden" name="hidCanalSap" runat="server">
			<input id="hidOrgVenta" type="hidden" name="hidOrgVenta" runat="server"> <input id="hidTipoDocVentaSap" type="hidden" name="hidTipoDocVentaSap" runat="server">
			<input id="hidTieneSECPendiente" type="hidden" name="hidTieneSECPendiente"> <input id="hidPlazos" type="hidden" name="hidPlazos" runat="server">
			<input id="hidAccion" type="hidden" name="hidAccion" runat="server"> <input id="hidTipoDocumento" type="hidden" name="hidTipoDocumento" runat="server"><input id="hidGrupoCadena" type="hidden" name="hidGrupoCadena" runat="server">
			<!-- ------------------------------------------------------ UNIFICADA ---------------------------------------------------------><input id="hidMesesClaro" type="hidden" name="hidMesesClaro" runat="server">
			<input id="hidCodEstadoSEC" type="hidden" name="hidCodEstadoSEC" runat="server">
			<input id="hidLCDisponible" type="hidden" name="hidLCDisponible" runat="server">
			<input id="hidPlanesDatosVoz" type="hidden" name="hidPlanesDatosVoz"> <input id="hidLCDisponiblexProd" type="hidden" name="hidLCDisponiblexProd" runat="server">
			<input id="hidGarantiaxProducto" type="hidden" name="hidGarantiaxProducto" runat="server">
			<input id="hidPoderes" type="hidden" name="hidPoderes" runat="server"> <input id="hidListaTipoProducto" type="hidden" name="hidListaTipoProducto">
			<input id="hidCadenaSECPendiente" type="hidden" name="hidCadenaSECPendiente"> <input id="hidCadenaDetalle" type="hidden" name="hidCadenaDetalle" runat="server">
			<input id="hidPlanDetalle" type="hidden" name="hidPlanDetalle"> <input id="hidGrupoPaqueteServer" type="hidden" name="hidGrupoPaqueteServer" runat="server">
			<input id="hidServicioServer" type="hidden" name="hidServicioServer" runat="server">
			<input id="hidPromocionServer" type="hidden" name="hidPromocionServer" runat="server">
			<input id="hidCalificacionPago" type="hidden" name="hidCalificacionPago" runat="server">
			<input id="hidListaTipoOperacion" type="hidden" name="hidListaTipoOperacion" runat="server">
			<input id="hidTipoOperacion" type="hidden" name="hidTipoOperacion" runat="server">
			<input id="hidTipoOferta" type="hidden" name="hidTipoOferta" runat="server"> <input id="hidCanal" type="hidden" name="hidCanal" runat="server">
			<input id="hidTipoDocumentos" type="hidden" name="hidTipoDocumentos" runat="server">
			<input id="hidRatioFactorMin" type="hidden" name="hidRatioFactorMin" runat="server"><input id="hidRatioFactorMax" type="hidden" name="hidRatioFactorMax" runat="server">
			<!---------------- Renovacion Postpago -------------------------------------------><input id="hidNroLinea" type="hidden" name="hidNroLinea" runat="server">
			<input id="hidMsg" type="hidden" name="hidMsg" runat="server"> <input id="hidResultado" type="hidden" name="hidResultado">
			<input id="hidarrTipoOferta" type="hidden" name="hidarrTipoOferta"> <input id="hidserviciosactuales" type="hidden" name="hidserviciosactuales">
			<input id="hidCargoFijoActual" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidCargoFijoActual" runat="server"><input id="hidCicloFact" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCicloFact"
				runat="server"> <input id="hidLimiteCred" type="hidden" name="hidLimiteCred" runat="server">
			<input id="hidRepLegal" type="hidden" name="hidRepLegal" runat="server"> <input id="hidTitular" type="hidden" name="hidTitular" runat="server">
			<input id="hidNroPedido" type="hidden" name="hidNroPedido" runat="server"> <input id="hidnroContrato" type="hidden" name="hidnroContrato" runat="server">
			<input id="hidCorreo" type="hidden" name="hidCorreo" runat="server"> <input id="hidCargoFijoNuevo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoFijoNuevo"
				runat="server"> 
			<!-------- Consulta Equipos -------><input id="hidProcesarPlanes" type="hidden" name="hidProcesarPlanes" runat="server">
			<iframe id="ifrBuscarImei" name="ifrBuscarImei" width="0" scrolling="no" height="0">
			</iframe><iframe id="ifrBuscarIccid" name="ifrBuscarIccid" width="0" scrolling="no" height="0">
			</iframe><input id="hidPlanes" type="hidden" name="hidPlanes" runat="server"> <input id="hidPlanActual" type="hidden" name="hidPlanActual" runat="server">
			<input id="hidTipoVenta" type="hidden" name="hidTipoVenta" runat="server"> <input id="hidMaterialIccid" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidMaterialIccid"
				runat="server"> <input id="hidOfVentaCod" type="hidden" name="hidOfVentaCod" runat="server">
			<input id="hidPlazoAcuerdo" type="hidden" name="hidPlazoAcuerdo" runat="server">
			<input id="hidRequest" type="hidden" name="hidRequest" runat="server"> <input id="hidResponse" type="hidden" name="hidResponse" runat="server">
			<iframe id="ifrConsultarListaPrecios" name="ifrConsultarListaPrecios" width="0" scrolling="no"
				height="0"></iframe><iframe id="ifrConsultarPrecio" name="ifrConsultarPrecio" width="0" scrolling="no" height="0">
			</iframe><INPUT id="hidPrecioVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioVenta"
				runat="server"><INPUT id="hidPrecios" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecios"
				runat="server"> <INPUT id="hidCampaniaSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidCampaniaSelected" runat="server"> <INPUT id="hidPlanTarifaSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidPlanTarifaSelected" runat="server"> <INPUT id="hidlistaPrecioSelected" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidlistaPrecioSelected" runat="server"> <INPUT id="hidFlagDescuento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagBuscandoPaso1"
				runat="server"><INPUT id="hidTipoDocVenta" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidTipoDocVenta"
				runat="server"><INPUT id="hidFactorRenovacion" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
				name="hidFactorRenovacion" runat="server"><INPUT id="hidClienteSap" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidClienteSap"
				runat="server"> <INPUT id="hidTipoCliente" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidTipoCliente"
				runat="server"> <INPUT id="hidPrefijo" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidPrefijo"
				runat="server"> <INPUT id="hidScoreCred" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidScoreCred"
				runat="server"> <INPUT id="hidSubsidioMenor" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidSubsidioMenor"
				runat="server"> <INPUT id="hidSubsidioMayor" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidSubsidioMayor"
				runat="server"> <INPUT id="hidPrecioVentaEv" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidPrecioVentaEv"
				runat="server"> <INPUT id="hidPrecioListaEv" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidPrecioListaEv"
				runat="server"> <INPUT id="hidVendedorSAP" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidVendedorSAP"
				runat="server"> <iframe id="ifrConsultarListaVendedores" name="ifrConsultarListaVendedores" width="0" scrolling="no"
				height="0"></iframe><INPUT id="hidTipoClienteSAP" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidTipoClienteSAP"
				runat="server"> 
			<!-------- Puntos Claro Club -------><INPUT id="hidPrecioTotal" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidPrecioTotal"
				runat="server"> <INPUT id="hidDescuento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidDescuento"
				runat="server"><input id="hidIDCAMPANA" type="hidden" name="hidIDCAMPANA" runat="server"><input id="hidFactorClaroClub" type="hidden" name="hidFactorClaroClub" runat="server">
			<!----------Correcion Observaciones--------------><INPUT id="hidMsgTitularidad" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidMsgTitularidad"
				runat="server"> <INPUT id="hidValidaInicial" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidValidaInicial"
				runat="server"> <input id="hidFlagRoamingI" style="WIDTH: 3px; HEIGHT: 22px" type="hidden" size="1" name="hidFlagRoamingI"
				runat="server"> <input id="hidFechaIniCC" type="hidden" name="hidFechaIniCC" runat="server">
			<input id="hidFechaFinCC" type="hidden" name="hidFechaFinCC" runat="server"> <input id="hidSegmento" type="hidden" name="hidSegmento" runat="server"><input id="hidTextRangoLC" style="WIDTH: 3px; HEIGHT: 22px" type="hidden" size="1" name="hidTextRangoLC"
				runat="server"><INPUT id="hidRiesgoClaro" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidRiesgoClaro"
				runat="server"><INPUT id="hidComportamiento" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidComportamiento"
				runat="server"> <INPUT id="hidTipoCanal" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidComportamiento"
				runat="server"><INPUT id="hidBAM" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" name="hidBAM" runat="server">
			<input id="hidPlanBolsaCompartida" type="hidden" name="hidPlanBolsaCompartida" runat="server">
			<input id="hidPlanBase" type="hidden" name="hidPlanBase" runat="server"> <input id="hidPlanCombo" type="hidden" name="hidPlanCombo" runat="server">
			<!----------Campos ICCID --------------><input id="hidDesMaterialIccid" type="hidden" name="hidDesMaterialIccid" runat="server">
			<input id="hidIccid" type="hidden" name="hidIccid" runat="server"> <input id="hidValidarIccid" type="hidden" name="hidValidarIccid" runat="server">
			<input id="hidMontoRegistrado" type="hidden" name="hidMontoRegistrado" runat="server"><input id="hidMSJMontoRegistrado" type="hidden" name="hidMSJMontoRegistrado" runat="server">
			<!----------Validar Vendedor --------------><INPUT id="hidPuntoVenta" type="hidden" name="hidPuntoVenta" runat="server">
			<INPUT id="hidFlagVendedor" type="hidden" name="hidFlagVendedor" runat="server">
			<INPUT id="hidOvencAsistencia" type="hidden" name="hidOvencAsistencia" runat="server">
			<input id="hidPermanencia" type="hidden" name="hidPermanencia" runat="server"> <input id="hidPlazoAcuerdoBRMS" type="hidden" name="hidPlazoAcuerdoBRMS" runat="server">
			<input id="hidDocVendedor" type="hidden" name="hidDocVendedor" runat="server"> <input id="hidNomVendedor" type="hidden" name="hidNomVendedor" runat="server">
			<input id="hidMensajeRenovacion" type="hidden" name="hidMensajeRenovacion" runat="server"><input id="hidRespuestaChip" type="hidden" name="hidRespuestaChip" runat="server">
			<!--consolidado 12122014--><INPUT id="hdnRetenidoFidelizado" type="hidden" name="hdnRetenidoFidelizado" runat="server">
			<INPUT id="hidSeleccionado" type="hidden" name="hidSeleccionado" runat="server">
			<INPUT id="hidSerieEquipo" type="hidden" name="hidSerieEquipo" runat="server"> <input id="hidMesesPorVencer" type="hidden" name="hidMesesPorVencer" runat="server">
			<input id="hidMontoMaxDesAS" type="hidden" name="hidMontoMaxDesAS" runat="server">
			<input id="hidMesesMaxAS" type="hidden" name="hidMesesMaxAS" runat="server"> <INPUT id="hidPlanDefault" type="hidden" name="hidPlanDefault" runat="server">
			<INPUT id="hidCampaniaDefault" type="hidden" name="hidCampaniaDefault" runat="server">
			<input id="hidListaPrecioDefault" type="hidden" name="hidListaPrecioDefault" runat="server">
			<input id="hidIMEI" type="hidden" name="hidIMEI" runat="server"> <input id="hidDatosEquipo" type="hidden" name="hidDatosEquipo" runat="server">
			<input id="hidDatosChip" type="hidden" name="hidDatosChip" runat="server"> <input id="hidEstadoPrecio" type="hidden" name="hidEstadoPrecio" runat="server">
			<input id="hidIMSI" type="hidden" name="hidIMSI" runat="server"> <input id="hidPLSelected" type="hidden" name="hidPLSelected" runat="server">
			<input id="hidTipoDocVentaCAC" type="hidden" name="hidTipoDocVentaCAC" runat="server">
			<input id="hidPlanAct" type="hidden" name="hidPlanAct" runat="server"> <input id="hidFlagReintegro" type="hidden" name="hidFlagReintegro" runat="server">
			<input id="hidOpcionAutorizacion" type="hidden" name="hidOpcionAutorizacion" runat="server">
			<input id="hidFlagConfExoneracionReintegro" type="hidden" name="hidFlagConfExoneracionReintegro"
				runat="server"> <input id="hidFlagExonerarReintegro" type="hidden" name="hidFlagExonerarReintegro" runat="server">
			<input id="hidReintegro" type="hidden" name="hidReintegro" runat="server"> <input id="hidCO" type="hidden" name="hidCO" runat="server">
			<input id="hidCustumerId" type="hidden" name="hidCustumerId" runat="server"> <input id="hidNombresCli" type="hidden" name="hidNombresCli" runat="server">
			<input id="hidApellidosCli" type="hidden" name="hidApellidosCli" runat="server">
			<input id="hidTotalAPagarCAC" type="hidden" name="hidTotalAPagarCAC" runat="server">
			<input id="hidNroConsultaBRMS" type="hidden" value="0" name="hidNroConsultaBRMS">
			<input id="hidModalidadVenta" type="hidden" name="hidModalidadVenta" runat="server">
			<input id="hidPerfilCreditos" type="hidden" name="hidPerfilCreditos" runat="server">
			<input id="hidPerfilSEC" type="hidden" name="hidPerfilSEC" runat="server"> <input id="hidFlagRenovacionAdelantada" type="hidden" name="hidFlagRenovacionAdelantada"
				runat="server"> <input id="hidCanalOf" type="hidden" name="hidCanalOf" runat="server">
			<input id="hiCFSiga" type="hidden" name="hiCFSiga" runat="server">
			<input id="hidflagIdValidator" type="hidden" name="hidflagIdValidator" runat="server">
			<input id="hidFlagIdValidator_RespPDV" type="hidden" name="hidFlagIdValidator_RespPDV"
				runat="server"> <input id="hidSecPadre" type="hidden" name="hidSecPadre" runat="server">
				<input id="hidCargoFijoSeleccionado" type="hidden" name="hidCargoFijoSeleccionado" runat="server">
			<input id="hidImporteRenta" type="hidden" name="hidImporteRenta" runat="server">
			<input id="hidcodGarantia" type="hidden" name="hidcodGarantia" runat="server"> 
			<input id="hidNombredelEquipoCAC" type="hidden" name="hidNombredelEquipoCAC" runat="server">
			<input id="hidFlagValDcto" type="hidden" name="hidFlagValDcto" runat="server">
			<input id="hidCuota" type="hidden" name="hidCuota" runat="server">
<input id="hidCuentaBSCS" type="hidden" name="hidCuentaBSCS" runat="server">
			
			<!--consolidado 12122014-->
			<!-------Inicio 29122014 RIHU ValidacionClaro--><input id="hidValidarCliente" type="hidden" name="hidValidarCliente" runat="server">
			<input id="hidAuditoriaLogs" type="hidden" name="hidAuditoriaLogs" runat="server"><input id="hidGrabar" type="hidden" value="0" name="hidGrabar" runat="server">
			<!-------Fin 29122014 RIHU ValidacionClaro-->
		    <input id="hidFormaPagoReintegro" type="hidden" name="hidFormaPagoReintegro" runat="server">
			<input id="hidFlgCierre" type="hidden" name="hidFlgCierre" runat="server">
			<input id="hidIdSolPlan" type="hidden" name="hidIdSolPlan" runat="server">
			
			<input id="hidMontoMaxDesASMax" type="hidden" name="hidMontoMaxDesASMax" runat="server">
			<input id="hidMesesMaxASMax" type="hidden" name="hidMesesMaxASMax" runat="server">
			<input id="hidVigente" type="hidden" name="hidVigente" runat="server">
			<input id="hidMantenerPlan" type="hidden" name="hidMantenerPlan" value="S" runat="server">
			<input id="hidCodPlanNoVigente" type="hidden" name="hidCodPlanNoVigente" runat="server">
			<input id="hidIdPlanVig" type="hidden" name="hidIdPlanVig" runat="server">
			<input id="hidplanDesNoVig" type="hidden" name="hidplanDesNoVig" runat="server">
			<input id="hid4G" type="hidden" name="hid4G" runat="server">
                        <input id="hidplanAsoc" type="hidden" name="hidplanAsoc" runat="server">
			<input id="hidHLR" type="hidden" name="hidHLR" runat="server"><input id="hidTLE" type="hidden" name="hidTLE" runat="server">
			<input id="hidPl4G" type="hidden" name="hidPl4G" runat="server"><input id="hidNombredelChipCAC" type="hidden" name="hidNombredelChipCAC" runat="server">
			<input id="hidCampanasNoVig" type="hidden" name="hidCampanasNoVig" runat="Server">
			
			<input id="hidDiasPendientes" type="hidden" name="hidDiasPendientes" runat="Server">
			<input id="hidMesesMaxASMaxDias" type="hidden" name="hidMesesMaxASMaxDias" runat="Server">
			<input id="hidMesesMaxASDias" type="hidden" name="hidMesesMaxASDias" runat="Server">
			<input type="hidden" id="hidOfertaLinea" name="hidOfertaLinea" />
			<input type="hidden" id="hidMsgPlanEmpleadoDatos" name="hidMsgPlanEmpleadoDatos" runat="server" />
				<!--//'PROY-24724-IDEA-28174 - INICIO -->
			<input id="hidValidadProtMovil" type="hidden" name="hidValidadProtMovil" runat="Server">
			<input id="hidflagProTMovil" type="hidden" name="hidflagProTMovil" runat="server">
			<input id="hidPrima" type="hidden" name="hidPrima" runat="server">
			<input id="hidDeducible" type="hidden" name="hidDeducible"  runat="server">
			<input id="hidCertificadoPM" type="hidden" name="hidCertificadoPM" runat="server"> 
            <input id="hidEvalPM" type="hidden" name="hidEvalPM" runat="server"> 
            <input id="hidCodTipoClientePM" type="hidden" name="hidCodTipoClientePM" runat="server">
            <input id="hidMsjErrorGrabarPM" type="hidden" name="hidMsjErrorGrabarPM" runat="server">
            <input id="hidEquipoEvaluado" type="hidden" name="hidEquipoEvaluado" runat="Server"> 
            <input id="hidErrorGrabarProtMovil" type="hidden" name="hidErrorGrabarProtMovil" runat="Server"> 
            <input id="hidPrimaEval" type="hidden" name="hidPrimaEval" runat="Server">
            <input id="HidSecGra" type="hidden" name="HidSecGra" runat="Server">
            <input id="hidDatosAdicionalesPM" type="hidden" name="hidDatosAdicionalesPM" runat="Server">
            <input id="hidDetquip" type="hidden" name="hidDetquip" runat="Server">
            <input id="hidContPopPupPM" type="hidden" name="hidContPopPupPM" runat="Server">
            <input id="hidContAlertPM" type="hidden" name="hidContAlertPM" runat="Server">
			<!--//'PROY-24724-IDEA-28174 - FIN -->	
			
			<!--//'PROY-24724-IDEA-28174 - INI - Parametros -->	
			<input id="hidCodServProteccionMovil" type="text" name="hidCodServProteccionMovil" runat="server" style="display:none">
			<input id="hidCodPrecioPrepagoMinimo" type="text" name="hidCodPrecioPrepagoMinimo" runat="server" style="display:none">
			<input id="hidPM_NoCalifica" type="text" name="hidPM_NoCalifica" runat="server" style="display:none">
			<input id="hidPM_NoCumpleRequisito" type="text" name="hidPM_NoCumpleRequisito" runat="server" style="display:none">
			<input id="hidErrorGrabarEvalProtMovil" type="text" name="hidErrorGrabarEvalProtMovil" runat="server" style="display:none">
			<input id="hidConsErrorGrabarProtMovil" type="text" name="hidConsErrorGrabarProtMovil" runat="server" style="display:none">
			<input id="hidPM_MontoPrimaMayor" type="text" name="hidPM_MontoPrimaMayor" runat="server" style="display:none">
			<input id="hidConfirmEliminarProtMovil" type="text" name="hidConfirmEliminarProtMovil" runat="server" style="display:none">
			<input id="hidMsjEquipoEvaluado" type="text" name="hidMsjEquipoEvaluado" runat="server" style="display:none">
			<input id="hidMsjSeleccionarEquipo" type="text" name="hidMsjSeleccionarEquipo" runat="server" style="display:none">
			<input id="hidMsjPMOfrecerSeguro" type="text" name="hidMsjPMOfrecerSeguro" runat="server" style="display:none">
			<input id="hidClienteWsError" type="text" name="hidClienteWsError" runat="server" style="display:none">
			<!--//'PROY-24724-IDEA-28174 - FIN - Parametros -->	
<!--gaa20170215-->
			<input id="hidBuroConsultado" type="hidden" name="hidBuroConsultado" runat="server" />
<!--fin gaa20170215-->
<!--gaa20170714-->
			<input id="hidPenalidadBRMS" type="hidden" name="hidPenalidadBRMS" runat="server" />
<!--fin gaa20170714-->
			<!--PROY-29123 VENTA EN CUOTAS-->
			<input id="hidDatosBRMS" type="hidden" name="hidDatosBRMS" runat="server" />

                        <!-- Inicio PROY-25335 - Contratación Electrónica - Release 0-->
			<input id="hidCheckCartaPoder" type="hidden" name="hidCheckCartaPoder" runat="Server">
			<input id="hidOVENV_OUTOFFBIO" type="hidden" name="hidOVENV_OUTOFFBIO" runat="Server">
			<input id="hidflagBioPost" type="hidden" name="hidflagBioPost" runat="Server">
			<input id="hidflagHuelleroPost" type="hidden" name="hidflagHuelleroPost" runat="Server">
			<input id="hidIdPadreBio" type="hidden" name="hidIdPadreBio" runat="Server">
			<input id="hidBiometriaExito" type="hidden" name="hidBiometriaExito" runat="Server">
			<input id="hidDatosBio" type="hidden" name="hidDatosBio" runat="Server">
			<input id="hidCurrentUser" type="hidden" name="hidCurrentUser" runat="Server">
			<input id="hidSerieLector" type="hidden" name="hidSerieLector" runat="Server">
			<!-- Fin PROY-25335 - Contratación Electrónica - Release 0-->
                        <!-- Inicio SD820360 - Inicio-->
                        <input id="hdCanMaxMeses" type="hidden" name="hdCanMaxMeses" runat="Server">
		        <input id="hdCanMinMeses" type="hidden" name="hdCanMinMeses" runat="Server">
		        <input id="hdAutoriza" type="hidden" name="hdAutoriza" runat="Server">
		        <input id="hidCerrarValid" type="hidden" name="hidCerrarValid" runat="Server">
                        <!-- Inicio SD820360 - Fin-->		

			<!--PROY-32129 :: INI -->
			<input id="hidEstadoCasoEsp" type="hidden" name="hidEstadoCasoEsp" runat="Server">
			<input id='hidIdCampSelec' type="hidden" name="hidIdCampSelec" runat="Server" />
			<input id="hidFila" type="hidden" name="hidFila" runat="Server" />
			<!--PROY-32129 :: FIN-->
                        <!--PROY 31636 RENTESEG-->
                        <input id="hidNacionalidad" type="hidden" name="hidNacionalidad" runat="Server">
                        <input id="hidNacSeleccionado" type="hidden" name="hidNacSeleccionado" runat="Server">
                        <input id="hidTodoTipoDoc" type="hidden" name="hidTodoTipoDoc" runat="Server">
                        <input id="hidSoporteVentaCorp" type="hidden" name="hidSoporteVentaCopr" runat="Server">
                        <input id="hidNacionalidadCliente" type="hidden" name="hidNacionalidadCliente" runat="server"/>
                        <input id="hidTipoDocPermitidoPostCAC" type="hidden" name="hidTipoDocPermitidoPostCAC" runat="server"/>
                        <input id="hidTipoDocPermitidoPostDAC" type="hidden" name="hidTipoDocPermitidoPostDAC" runat="server"/>
                        <input id="hidTipoDocPermitidoPostCAD" type="hidden" name="hidTipoDocPermitidoPostCAD" runat="server"/>
                        <input id="hidCodigoDocMigraYPasaporte" type="hidden" name="hidCodigoDocMigraYPasaporte" runat="server"/>
                       
                        <!--PROY 31636 RENTESEG-->
		</form>
		<div id="boxes">
			<!-- Start of Login Dialog -->
			<div class="window" id="dialog1" style="LEFT: 0px; TOP: 48px"><a id="CloseDiv">Cerrar</a><iframe id="ifrValidarCliente" style="WIDTH: 460px; HEIGHT: 470px" src=""></iframe>
			</div>
			<div class="window" id="dialog2" style="LEFT: 0px; TOP: 48px"><a id="CloseDivReintegro">Cerrar</a><iframe id="ifrReintegro" style="WIDTH: 420px; HEIGHT: 260px" src=""></iframe>
			</div>
			<!-- End of Login Dialog -->
			<!-- Mask to cover the whole screen --><div id="mask"></div>
		</div>
	</BODY>
</HTML>