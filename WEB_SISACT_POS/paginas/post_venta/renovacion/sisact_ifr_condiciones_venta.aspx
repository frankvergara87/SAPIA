<%@ Page Language="vb" AutoEventWireup="false" Codebehind="sisact_ifr_condiciones_venta.aspx.vb" Inherits="sisact_ifr_condiciones_venta" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>sisact_ifr_condiciones_venta</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../estilos/general.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../../../script/funciones_sec.js"></script>
		<LINK title="win2k-cold-1" media="all" href="../../../estilos/calendar-blue.css" type="text/css"
			rel="stylesheet">
		<script src="../../../script/calendar/calendar.js" type="text/javascript"></script>
		<script src="../../../script/calendar/calendar_es.js" type="text/javascript"></script>
		<script src="../../../script/calendar/calendario_call.js" type="text/javascript"></script>
		<script src="../../../script/calendar/calendar_setup.js" type="text/javascript"></script>
		<script language="javascript" src="../../../librerias/validaciones.js"></script>
		<script language="JavaScript">
			
			//Inicio 09012014
			var cursorSaldos = new HashTable();
			//Fin 09012014
			var constModalidadPagoEnCuota = '<%= ConfigurationSettings.AppSettings("constCodModalidadPagoEnCuota") %>';
			 //PROY-24724-IDEA-28174 - Parametros  INI
			var concatCodTipoPdvProteccionMovil;
			var codServProteccionMovil;
			 
			//PROY-24724-IDEA-28174 - Parametros  FIN
			//gaa20161027
			var familiaFlag = '<%= ConfigurationSettings.AppSettings("FamiliaPlanFlag") %>';
			//fin gaa20161027
			function asignarTipoProducto(idFila)
			{
				var ddlTipoProducto = document.getElementById('ddlTipoProducto_' + idFila);
				var strValores = getValue('hidListaTipoProducto');
				llenarDatosCombo(ddlTipoProducto, strValores, true);
			}

			function eventoSoloNumerosEnteros()
			{
				var CaracteresPermitidos = '0123456789';
				var key = String.fromCharCode(window.event.keyCode)
				var valid = new String(CaracteresPermitidos)
				var ok = "no";

				for (var i = 0; i < valid.length; i++)
				{
					if (key == valid.substring(i, i+1))
						ok = "yes";
				}

				if(window.event.keyCode != 16)
				{
					if (ok == "no")
						window.event.keyCode=0;
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

			function mostrarColumna(idCol, booVer)
			{
				var tblTablaTituloMovil = document.getElementById('tblTablaTituloMovil');

				if (booVer)
					tblTablaTituloMovil.rows[0].cells[idCol].style.display = "inline";
				else
					tblTablaTituloMovil.rows[0].cells[idCol].style.display = "none";
			}

			function mostrarColumnaCuota(visible)
			{			
				var tblTablaTituloMovil = document.getElementById('tblTablaTituloMovil');
				var tblTablaTituloFijo = document.getElementById('tblTablaTituloFijo');
				var tblTablaTituloBAM = document.getElementById('tblTablaTituloBAM');

				var ver = "inline";
				if (!visible) ver = "none";
//gaa20161024
				//tblTablaTituloMovil.rows[0].cells[11].style.display = ver;
				var c = 11;
				if (familiaFlag == '1')
					c++;

				tblTablaTituloMovil.rows[0].cells[c].style.display = ver;
//fin gaa20161024
				tblTablaTituloFijo.rows[0].cells[10].style.display = ver;
				tblTablaTituloBAM.rows[0].cells[10].style.display = ver;
			}

			function mostrarColumnaPlazo(visible) {
				var tblTablaTituloMovil = document.getElementById('tblTablaTituloMovil');
				var tblTablaTituloFijo = document.getElementById('tblTablaTituloFijo');
				var tblTablaTituloBAM = document.getElementById('tblTablaTituloBAM');

				var ver = "inline";
				if (!visible) ver = "none";

				tblTablaTituloMovil.rows[0].cells[2].style.display = ver;
				tblTablaTituloFijo.rows[0].cells[2].style.display = ver;
				tblTablaTituloBAM.rows[0].cells[2].style.display = ver;
			}

			function mostrarColumnaPorta(visible)
			{
				var tblTablaTituloMovil = document.getElementById('tblTablaTituloMovil');
				var tblTablaTituloBAM = document.getElementById('tblTablaTituloBAM');

				var ver = "inline";
				if (!visible) ver = "none";
//gaa20161024
				//tblTablaTituloMovil.rows[0].cells[13].style.display = ver;
				var c = 13;
				if (familiaFlag == '1')
					c++;

				tblTablaTituloMovil.rows[0].cells[c].style.display = ver;
//fin gaa20161024
				tblTablaTituloBAM.rows[0].cells[12].style.display = ver;
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

			function asignarPlan(idFila, strValor, strResultadoPlan) //modificado 25112015
			{
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				strValor = validarPlanesFijo(strValor);

				//inicio campañas nuevas 25112015
				
				setValue('hidPlanNuevo', strResultadoPlan);
				
				//fin campañas nuevas 25112015
				
				llenarDatosCombo(ddlPlan, strValor, true);
				//Inicio Plan No Vigente
				var strMantenerPlan = getValue('hidMantenerPlan');
				if (strMantenerPlan == 'N'){
					ddlPlan.selectedIndex = 1;
					cambiarPlan(strValor, idFila);
				}
				//Inicio Plan No Vigente
				calcularLCxProductoFijo();
			}

			function validarPlanesFijo(strValor)
			{
				var strPlanes = strValor;
				if (parent.getValue('hidEvaluarMovil') == 'N')
				{
					var arrPlanes = strPlanes.split('|');
					strPlanes = '';
					for (var i = 0; i < arrPlanes.length; i++)
					{
						if (arrPlanes[i] != '')
						{
							var plan = arrPlanes[i].split(';')[0];
							var claseProducto = getValor(plan, 7).replace(',', '');
							if (claseProducto == '<%= ConfigurationSettings.AppSettings("constClaseProductoFijo") %>')
								strPlanes += '|' + arrPlanes[i];
						}
					}
				}
				return strPlanes;
			}

			function validarSolucionFijo(strValor)
			{
				var strSolucion = strValor;
				if (parent.getValue('hidEvaluarMovil') == 'N')
				{
					var arrSolucion = strSolucion.split('|');
					strSolucion = '';
					for (var i = 0; i < arrSolucion.length; i++)
					{
						if (arrSolucion[i] != '')
						{
							var solucion = arrSolucion[i].split(';')[0];
							if (solucion == '<%= ConfigurationSettings.AppSettings("constSolucion1PlayFijo") %>')
								strSolucion += '|' + arrSolucion[i];
						}
					}
				}
				return strSolucion;
			}

			function validarPaqueteFijo(strValor)
			{
				var strPaquete = strValor;
				if (parent.getValue('hidEvaluarMovil') == 'N')
				{
					var arrPaquete = strPaquete.split('|');
					strPaquete = '';
					for (var i = 0; i < arrPaquete.length; i++)
					{
						if (arrPaquete[i] != '')
						{
							var paquete = arrPaquete[i].split(';')[0].split('_')[0];
							if (paquete == '<%= ConfigurationSettings.AppSettings("constPaquete1PlayFijo") %>')
								strPaquete += '|' + arrPaquete[i];
						}
					}
				}
				return strPaquete;
			}

			function asignarPlazo(idFila, strValor)
			{
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);

				if (strValor.indexOf('|') < 0)
				{
					strValor = '|' + strValor;
					strValor = strValor.replace('_', ';');
				}

				llenarDatosCombo(ddlPlazo, strValor, true);

				var codSinPlazo = '<%= ConfigurationSettings.AppSettings("constCodSinPlazo") %>';
				if (getValue('hidTipModalidad') == constModalidadPagoEnCuota)
				{
					setValue('ddlPlazo' + idFila, codSinPlazo);
					cambiarPlazo(ddlPlazo.value, idFila);
				}
			}

			function asignarPlazoCampanaDTH(idFila, strValor)
			{
				var arrValor = strValor.split('¬');
				var strPlazos = arrValor[0];
				var strCampanasDTH = arrValor[1];

				if (document.getElementById('ddlPlazo' + idFila).disabled == false)
					asignarPlazo(idFila, strPlazos);

				var ddlCampana = document.getElementById('ddlCampana' + idFila);

				if (strCampanasDTH.length > 0)
					setValue('hidCampanasDTH', strCampanasDTH);

				if (ddlCampana != null)
					llenarDatosCombo(ddlCampana, getValue('hidCampanasDTH'), true);
			}
/*
			function llenarMaterial(idFila, strValor)
			{
				var hidMaterial = document.getElementById('hidMaterial');
				hidMaterial.value = strValor;
			}

			function asignarMaterial(idFila)
			{	
				var strMaterial = document.getElementById('hidMaterial').value;
				var ddlEquipo = document.getElementById('ddlEquipo' + idFila);
				document.getElementById('txtEquipoPrecio' + idFila).value = '0';
				llenarDatosCombo(ddlEquipo, strMaterial, true);
				borrarCuota(idFila);
			}
*/
			function llenarCampana(idFila, strValor)
			{
				var hidCampana = document.getElementById('hidCampana');
				hidCampana.value = strValor;

				asignarCampana(idFila);
			}

			function asignarCampana(idFila)
			{
				if (idFila < 0)
					idFila = document.getElementById('hidLineaActual').value;

				var strCampana = document.getElementById('hidCampana').value;
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				strCampana = sortSelect(strCampana);
				llenarDatosCombo(ddlCampana, strCampana, true);
			}

			function sortSelect(strCampana)
			{
				var tmpAry = new Array();
				var arrCadena = strCampana.split('|');
				var cadena = "";
				for (var i=0; i<arrCadena.length; i++)
				{
					tmpAry[i] = new Array();
					tmpAry[i][0] = arrCadena[i].split(';')[1];
					tmpAry[i][1] = arrCadena[i].split(';')[0];
				}
				tmpAry.sort();
				for (var i=0; i<tmpAry.length; i++)
				{
					if (tmpAry[i][1] != "")
						cadena = cadena + "|" + tmpAry[i][1] + ";" + tmpAry[i][0];
				}
				return cadena;
			}

			function traerPlazo(strValor)
			{
				var hidTraerPlazo = document.getElementById('hidTraerPlazo');
				hidTraerPlazo.value = strValor;
			}

			function validarBusqueda()
			{
				var ddlOferta = parent.document.getElementById('ddlOferta');
				if (ddlOferta.value.length == 0)
				{
					ddlOferta.focus();
					alert('Seleccione la oferta.');
					return false;
				}
				return true;
			}

			function obtenerFlujo()
			{
				var strTienePortabilidad = parent.document.getElementById('hidTienePortabilidad').value;
				var strFlujo = flujoAlta;

				if (strTienePortabilidad == 'S')
					strFlujo = flujoPortabilidad;

				return strFlujo;
			}

			function cambiarTipoProducto(idFila)
			{
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var tipoProductoActual = getValue('hidTipoProductoActual');
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				var strCampanasDTH = getValue('hidCampanasDTH');
				var ddlCampana = document.getElementById('ddlCampana' + idFila);

				if (ddlPlazo == null)
					return;

				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				var tabla = document.getElementById('tblTabla' + tipoProductoActual);
				var strPlazos;
				var imgVerCuota = document.getElementById('imgVerCuota' + idFila);

				if (ddlPaquete != null)
					llenarDatosCombo(ddlPaquete, '', true);

				llenarDatosCombo(document.getElementById('ddlPlan' + idFila), '', true);
				//inicio plan no vigente 30102015 imgServicios
				var  ddlPlan = document.getElementById('ddlPlan' + idFila);
				var  MantenerPlan =	document.getElementById('hidMantenerPlan').value
				var imgServicios = document.getElementById('imgServicios' + idFila);				
				if (MantenerPlan == 'N'){
					ddlPlan.disabled = true;
					imgServicios.disabled = true;
				}
				var strddlGProducto = parent.getValue('ddlGProducto');
				if (strddlGProducto != '00'){
					ddlCampana.disabled = true;
				}
				//fin plan no vigente 30102015
				

				if (codigoTipoProductoActual != codTipoProdDTH && ddlCampana != null)
					llenarDatosCombo(ddlCampana, '', true);

				if (!mostrarDirInst(idFila))
				{
					eliminarFilaTotal(null, idFila, false);
					return;
				}

				//visualizar iconos Dir.Instalación - Oferta
				if (codigoTipoProductoActual == codTipoProdDTH || codigoTipoProductoActual == codTipoProd3Play)
				{
					if (imgVerCuota != null)
						imgVerCuota.style.display = 'none';

					var imgDirInst = document.getElementById('imgDirInst' + idFila);

					if (imgDirInst != null)
						imgDirInst.style.display = '';

					if (codigoTipoProductoActual == codTipoProd3Play)
						document.getElementById('imgDetOfert' + idFila).style.display = '';
				}
				else
				{
					if (imgVerCuota != null)
						imgVerCuota.style.display = '';
				}

				ddlPlazo.value = '';
				strPlazos = verificarPlazo(getValue('hidTipoProductoActual'));

				if (strPlazos.length > 0)
				{
					llenarDatosCombo(ddlPlazo, strPlazos, false);
					ddlPlazo.disabled = true;
					cambiarPlazo(ddlPlazo.value, idFila);
				}
				else
				{
//gaa20150504
					//llenarPlazoCampanaDTHIfr(idFila);
//fin gaa20150504
					ddlPlazo.disabled = false;
				}
//gaa20150504
				//Inicio Modificacion Plan No Vigente
				llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', true);
				//Fin Modificacion Plan No Vigente
				llenarCampanaPlazoIfr(idFila);
/*
				if (codigoTipoProductoActual == codTipoProdDTH)
				{
					if (strCampanasDTH.length == 0)
						llenarPlazoCampanaDTHIfr(idFila);
					else
						llenarDatosCombo(ddlCampana, strCampanasDTH, true);
				}
*/
//fin gaa20150504
			}
//gaa20150504
			function llenarCampanaPlazoIfr(idFila) {
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				var strCampanasDTH = getValue('hidCampanasDTH');
				var strCampanasHFC = getValue('hidCampanasHFC');
				var strCampanasMovil = getValue('hidCampanasMovil');
				var strCampanasFijo = getValue('hidCampanasFijo');
				var strCampanasBAM = getValue('hidCampanasBAM');
				var strCampanasVentaVarios = getValue('hidCampanasVentaVarios');
				var sMantenerPlan = parent.getValue('hidMantenerPlan');				

				switch (codigoTipoProductoActual) {
					case codTipoProdMovil:
						//Modificacion Plan No Vigente						
						//Si se selecciono Mantener Plan, debe consultar a LlenarCampanaPlazo																							
						/*
						if (strCampanasMovil.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasMovil, true);
							return;
						}
						*/
						break;
					case codTipoProdFijo:
						if (strCampanasFijo.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasFijo, true);
							return;
						}
						break;
					case codTipoProdBAM:
						if (strCampanasBAM.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasBAM, true);
							return;
						}
						break;
					case codTipoProdDTH:
						if (strCampanasDTH.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasDTH, true);
							return;
						}
						break;
					case codTipoProd3Play:
						if (strCampanasHFC.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasHFC, true);
							return;
						}
						break;
					case codTipoProdVentaVarios:
						if (strCampanasVentaVarios.length > 0) {
							llenarDatosCombo(ddlCampana, strCampanasVentaVarios, true);
							return;
						}
						break;
				}

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strCasoEspecial=' + getValor(parent.getValue('ddlCasoEspecial'), 0);
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strCampana=' + getValue('ddlCampana' + idFila);
				url += '&strCombo=' + '';
				url += '&strNroDoc=' + parent.getValue('txtNroDoc');
				url += '&strTipoModalidadVenta=' + parent.getValue('ddlModalidad');
				//inicio 24112015
				url += '&strGrupoProducto=' + parent.getValue('ddlGProducto');
				//fin 24112015
				//Inicio Modificacion Plan No Vigente
				url += '&strIdPlanVig=' + parent.getValue('hidIdPlanVig');				
				url += '&strMantenerPlan=' + parent.getValue('hidMantenerPlan');				
				url += '&strCampanasNoVig=' + parent.getValue('hidCampanasNoVig');			
				//Fin Modificacion Plan No Vigente
				url += '&strMetodo=' + 'LlenarCampanaPlazo';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
			
			function asignarCampanaPlazo(idFila, strValor) {
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var arrValor = strValor.split('¬');
				var strCampanas = arrValor[0];
				var strPlazos = arrValor[1];
				var ddlCampana = document.getElementById('ddlCampana' + idFila);

				switch (codigoTipoProductoActual) {
					case codTipoProdMovil:
						setValue('hidCampanasMovil', strCampanas);
						setValue('hidPlazosMovil', strPlazos);
						break;
					case codTipoProdFijo:
						setValue('hidCampanasFijo', strCampanas);
						setValue('hidPlazosFijo', strPlazos);
						break;
					case codTipoProdBAM:
						setValue('hidCampanasBAM', strCampanas);
						setValue('hidPlazosBAM', strPlazos);
						break;
					case codTipoProdDTH:
						setValue('hidCampanasDTH', strCampanas);
						setValue('hidPlazosDTH', strPlazos);
						break;
					case codTipoProd3Play:
						setValue('hidCampanasHFC', strCampanas);
						setValue('hidPlazosHFC', strPlazos);
						break;
					case codTipoProdVentaVarios:
						setValue('hidCampanasVentaVarios', strCampanas);
						setValue('hidPlazosVentaVarios', strPlazos);
						break;
				}
				var strddlGProducto = parent.getValue('ddlGProducto');
				if (strddlGProducto != '00'){
					llenarDatosCombo(ddlCampana, strCampanas, false);
					var arrValorCampana = strCampanas.split('|');
					var strCampanasPost = arrValorCampana[1];
					var arrValorCampana1 = strCampanasPost.split(';');
					var strCampanasPost1 = arrValorCampana1[0];
					cambiarCampana(idFila, strCampanasPost1)
				}else{
				llenarDatosCombo(ddlCampana, strCampanas, true);
			}
			}
			
			function cambiarCampana(idFila, strValor) {
				cambiarPlazo('', idFila);

				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				if (ddlPlazo.disabled) {
					cambiarPlazo(getValue('hidPlazoActual').split('_')[0], idFila) 
					return;
				}

				var strPlazosDTH = getValue('hidPlazosDTH');
				var strPlazosHFC = getValue('hidPlazosHFC');
				var strPlazosMovil = getValue('hidPlazosMovil');
				var strPlazosFijo = getValue('hidPlazosFijo');
				var strPlazosBAM = getValue('hidPlazosBAM');
				var strPlazosVentaVarios = getValue('hidPlazosVentaVarios');

				switch (getValue('hidCodigoTipoProductoActual')) {
					case codTipoProdMovil:
						if (strPlazosMovil.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosMovil, true);
						}
						break;
					case codTipoProdFijo:
						if (strPlazosFijo.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosFijo, true);
						}
						break;
					case codTipoProdBAM:
						if (strPlazosBAM.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosBAM, true);
						}
						break;
					case codTipoProdDTH:
						if (strPlazosDTH.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosDTH, true);
							return;
						}
						break;
					case codTipoProd3Play:
						if (strPlazosHFC.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosHFC, true);
						}
						break;
					case codTipoProdVentaVarios:
						if (strPlazosVentaVarios.length > 0) {
							llenarDatosCombo(ddlPlazo, strPlazosVentaVarios, true);
						}
						break;
				}

				// Seleccionar plazo x defecto
				if (ddlPlazo.length == 2) {
					ddlPlazo.selectedIndex = 1;
					cambiarPlazo(ddlPlazo.value, idFila);
				}
				//Inicio Modificacion Plan No Vigente
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				ddlPlan.selectedIndex = 0;
				//Fin Modificacion Plan No Vigente

				
				//PROY-32129 :: INI
				Anthem_InvokePageMethod('ValidarDocCasoEspecial',[idFila,strValor], ValidarDocCasoEspecial_Callback);
				//PROY-32129 :: FIN

			}
			
			//PROY-32129 :: INI
			function ValidarDocCasoEspecial_Callback(objResponse){
				
				
				if(objResponse === undefined){
					alert('Error al validar la campaña');
					return false;
				}
				var sResponse = objResponse.value;
				var sResultado = sResponse.split(';')[0];
				var sFilaActual = sResponse.split(';')[1];
				var sParamMensaje = sResponse.split(';')[2];
				var campanaactual= sResponse.split(';')[3];//
				var ddlCampanaActual = document.getElementById('ddlCampana' + sFilaActual);
				var ddlPlazoActual = document.getElementById('ddlPlazo' + sFilaActual);
				parent.document.getElementById('hidFila').value = sFilaActual;
				
				if (sResultado == '0'){
					if (confirm(sParamMensaje))
					{
			
					setValue('hidcampanaactual', campanaactual);
					
						parent.document.getElementById('trCasoEspecial').style.display = '';
						DesabilitarDetalleGrilla();
					}else{
						ddlCampanaActual.selectedIndex = 0;
						return false;
			}
				}else{
					parent.document.getElementById('trCasoEspecial').style.display = 'none';
				}
				parent.document.getElementById('hidIdCampSelec').value = 'ddlCampana' + sFilaActual;
			}
			
			function EliminarAlumno_Callback(objResponse){
				
				if(objResponse === undefined){
					alert('Error eliminar el registro en el whitelist');
					return false;
				}
				var sResponse = objResponse.value;
				if (sResponse == '0'){
					alert('SE ELIMINO EL REGISTRO EN EL WHITELIST');
				}
			}
				
			function DesabilitarDetalleGrilla() {
				var tblDetalleItems = document.getElementById('tblTabla' + document.getElementById('hidTipoProductoActual').value);
				var controlComboBox = tblDetalleItems.getElementsByTagName("select");
				for (var i = 0; i < controlComboBox.length; i++)
				controlComboBox[i].disabled = true;
			}
			//PROY-32129 :: FIN
			
			function cambiarPlazo(strPlazo, idFila) {
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var ddlPlan = document.getElementById('ddlPlan' + idFila);

				if (ddlPlan == null)
					ddlPlan = document.getElementById('ddlPaquete' + idFila);

				var strFlujo = flujoAlta;
				if (parent.getValue('hidTienePortabilidad') == 'S')
					strFlujo = flujoPortabilidad;

				var strTienePaquete = document.getElementById('hidTienePaquete').value;
				inicializarPlan(idFila);

				if (codigoTipoProductoActual != codTipoProd3Play) {
					llenarDatosCombo(ddlPlan, '', true);
					llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);

					calcularCFxProducto();
				}

				if (strPlazo.length > 0) {
					if (codigoTipoProductoActual == codTipoProd3Play) {
						var strCampana = getValue('ddlCampana' + idFila);
						LlenarPaquete3PlayIfr(strCampana, strPlazo, idFila);

						return;
					}
				}

				if (strPlazo.length > 0) {
					if (strTienePaquete == 'S') {
						var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
						if (ddlPaquete != null)
							llenarDatosCombo(ddlPaquete, '', true);

						if (codigoTipoProductoActual != codTipoProd3Play) {
							if (codigoTipoProductoActual == codTipoProdMovil) {
								LlenarPaquetePlanIfr(idFila, strPlazo, strFlujo); //Movil y otros
							}
							else {
								LlenarPlanIfr(idFila, strPlazo, strFlujo);
							}
						}
					}
					else {
//gaa20161020
						//LlenarPlanIfr(idFila, strPlazo, strFlujo);
						if (document.getElementById('tdFamiliaPlanMovil').style.display != 'none' && codigoTipoProductoActual == codTipoProdMovil)
							LlenarFamiliaPlanIfr(idFila, strPlazo);
					else
						LlenarPlanIfr(idFila, strPlazo, strFlujo);
//fin gaa20161020
					}
				}
				else {
					asignarPlan(idFila, '', ''); //modificado 25112015
					if (strTienePaquete == 'S')
						asignarPaquete(idFila, '');
				}
										
				parent.setValue('hidPlazoAcuerdo', getValue('ddlPlazo' + idFila));
			}
			
			function inicializarPlan(idFila) {
				borrarServicio(idFila);
				cerrarServicio();

				inicializarEquipo(idFila);

				borrarCuota(idFila)
				cerrarCuota();

				var txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
				var txtMontoTopeConsumo = document.getElementById('txtMontoTopeConsumo' + idFila);
				var txtCFMenAlqKit = document.getElementById('txtCFMenAlqKit' + idFila);
				var txtCFTotMensual = document.getElementById('txtCFTotMensual' + idFila);
				var hidMontoServicios = document.getElementById('hidMontoServicios' + idFila);
				var hidMontoCuota = document.getElementById('hidMontoCuota' + idFila);

				if (txtCFPlanServicio != null)
					txtCFPlanServicio.value = '';

				if (txtMontoTopeConsumo != null)
					txtMontoTopeConsumo.value = '';

				if (txtCFMenAlqKit != null)
					txtCFMenAlqKit.value = '';
	            
				if (txtCFTotMensual != null)
					txtCFTotMensual.value = '';

				if (hidMontoServicios != null)
					hidMontoServicios.value = '0';

				if (hidMontoCuota != null)
					hidMontoCuota.value = '0';
			}
			
			function cambiarPlan(strPlan, idFila) {
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');

				//inicio campañas nuevas 25112015
				
				var ddlGProducto = parent.getValue('ddlGProducto');
				
				if (ddlGProducto != "00"){
					var strPlanNuevo = getValue('hidPlanNuevo');
					var strPlanAsignado = getValor(strPlan, 1);
					var strPlanCodigoAsignado = getValor(strPlan, 0);
					
					if (strPlanNuevo != null){
						var arrplanNuevo = strPlanNuevo.split("|");
					}else{
						return;
					}
					
					for (i = 0; i < arrplanNuevo.length; i++)
					{
						if (arrplanNuevo[i].length > 0)
						{
							strDato = arrplanNuevo[i];
							arrItem = strDato.split(";");
							var strPlanMayor = getValor(strDato,1);
							var strPlanCodigo = getValor(strDato,0);
							   
							if (strDato != 'null')
							{
								//post + post 31032016
								if (parseFloat(strPlanMayor) > parseFloat(strPlanAsignado)){
									var strMensajeMayor = '<%= ConfigurationSettings.AppSettings("constPlanMayor") %>';
									alert(strMensajeMayor);
									strPlan = "";
									//return;
									break;
								}								
								if (strPlanCodigoAsignado != strPlanCodigo){
									setValue('hidplanAsoc', strPlanCodigo)
									parent.document.getElementById('hidplanAsoc').value = getValue('hidplanAsoc');
								}
							}
						}
					}
				}
				//fin campañas nuevas 25112015
					

				inicializarPlan(idFila);
				if (strPlan.length == 0) {
					document.getElementById('hidLineaActual').value = idFila;

					calcularLCxProductoFijo();
					calcularCFxProducto();

					llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);

					return;
				}

				if (codigoTipoProductoActual == codTipoProd3Play) {
					LlenarServicioHFCIfr(idFila, strPlan);
					return;
				}

				var strPlanCodigo = getValor(strPlan, 0);
				
				//inicio campaña post post 02/12/2015
				/*var codPlan15 = '<%= ConfigurationSettings.AppSettings("constCodPlan15") %>';
				if (strPlanCodigo == codPlan15){
					var strPlanDesc15 = '<%= ConfigurationSettings.AppSettings("constDesCodPlan15") %>';
					alert(strPlanDesc15);
					//return;
				}
				*/
				//fin campaña post post 02/12/2015
				
				var strPlanCodigoSap = getValor(strPlan, 2);
				var strPlanCF = getValor(strPlan, 1);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strCampana = document.getElementById('ddlCampana' + idFila).value;
				var strPlazo = ddlPlazo.value;

				var strPlanesBolsa = window.parent.document.getElementById('hidPlanBase').value;
				var ddlPlan = document.getElementById('ddlPlan' + idFila);

				if (strPlanesBolsa.indexOf('|' + strPlanCodigo) > -1) {
					var datosBolsa = mostrarPopupPlanCombo(strPlanCodigo, obtenerTextoSeleccionado(ddlPlan));

					if (datosBolsa != undefined) {
						if (datosBolsa.length > 0) {
							var strPlanActualizado = datosBolsa.split('|')[0];

							llenarDatosCombo(ddlPlan, '|' + strPlanActualizado, false);
							ddlPlan.value = strPlanActualizado.split(';')[0];
							cambiarPlan(strPlanActualizado, idFila);
							ddlPlan.disabled = true;
							return;
						}
					}
				}

				document.getElementById('hidLineaActual').value = idFila;
				document.getElementById('txtCFPlanServicio' + idFila).value = strPlanCF;
				document.getElementById('btnCerrarServicios').value = 'Cerrar y Guardar';

				calcularCFxProducto();

				if (codigoTipoProductoActual != codTipoProdDTH)
					LlenarServicioMaterialIfr(idFila, strPlanCodigo, strPlanCodigoSap, strCampana, strPlazo);
				else
					LlenarServicioKitIfr(idFila, strPlanCodigo, strPlanCodigoSap, strCampana, strPlazo);
					
				var planTarifaSelected = getValor(strPlan, 0) + "," + getValor(strPlan, 2) + "," + getText('ddlPlan' + idFila);
				parent.setValue('hidPlanTarifaSelected', planTarifaSelected);

			}
			
			function LlenarServicioMaterialIfr(idFila, strPlan, pstrPlanCodigoSap, strCampana, strPlazo) {
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila
				url += '&strCasoEspecial=' + getValor(parent.getValue('ddlCasoEspecial'), 0);
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strPlan=' + strPlan;
				url += '&strPlanSap=' + pstrPlanCodigoSap;
				url += '&strFlagServicioRI=' + parent.getValue('hidFlagRoamingI');
				url += '&strCampana=' + strCampana;
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&nroDoc=' + parent.getValue('txtNroDoc');
				url += '&strOrgVenta=' + parent.getValue('hidOrgVenta');
				url += '&strCentro=' + parent.getValue('hidCentro');
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strCombo=' + parent.getValue('ddlCombo');
				url += '&strPlazo=' + strPlazo;
				url += '&strTipoOficina=' + parent.getValue('hidOficinaActual').split(',')[2];
				//gaa20151106
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				//fin gaa20151106
				url += '&strMetodo=' + 'LlenarServicioMaterial';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
			
			function asignarServicioMaterial(idFila, pstrResultado) {
				var arrResultado;
				var strServicios;

				if (pstrResultado.indexOf('~') > -1) {
					arrResultado = pstrResultado.split('~');

					strServicios = arrResultado[0];

					llenarMaterial(idFila, arrResultado[1]);
					asignarMaterial(idFila);

					if (strServicios.indexOf('¬') > -1) {
						arrResultado = strServicios.split('¬');
						var lbxServiciosDisponibles1 = document.getElementById('lbxServiciosDisponibles1');
						var lbxServiciosAgregados1 = document.getElementById('lbxServiciosAgregados1');

						llenarDatosCombo(lbxServiciosDisponibles1, arrResultado[0], false);
						llenarDatosCombo(lbxServiciosAgregados1, arrResultado[1], false);

						agregarGrupo(idFila, true);
						guardarServicio();
					}
					else
						calcularCFxProducto();

					calcularLCxProductoFijo();
				}
			}

			function llenarMaterial(idFila, strValor) {
				document.getElementById('hidMaterial' + idFila).value = strValor;
			}
        
			function asignarMaterial(idFila) {
				var strMaterial = document.getElementById('hidMaterial' + idFila).value;
				var divListaEquipo = document.getElementById('divListaEquipo' + idFila);

				inicializarEquipo(idFila);

				llenarDatosCombo1(divListaEquipo, strMaterial, idFila, 'Equipo', false);

				if (document.getElementById('imgVerCuota' + idFila) != null)
					borrarCuota(idFila);
			}
//fin gaa20150504
			
//gaa20130521
			function llenarPlazoCampanaDTHIfr(idFila)
			{
				//cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strOficina=' + parent.getValue('hidOficina');
//gaa20130523
				url += '&intTraerCampanasDTH=' + getValue('hidCampanasDTH').length;
//fin gaa20130523
				url += '&strMetodo=' + 'LlenarPlazoCampanaDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
//fin gaa20130521
			function mostrarDirInst(idFila)
			{
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
//gaa20130522
				if (codigoTipoProductoActual != codTipoProdDTH && codigoTipoProductoActual != codTipoProd3Play)
					return true;
//fin gaa20130522
				var strTieneDireccion = '2';
				var intDeshabilitado = '0';
				var flgVentaProactiva = parent.getValue('hidVerVentaProactiva');
				//var nroPlanes = 0;
				var url = 'sisact_direccion_hfc.aspx?idFila=' + idFila;

				if (document.getElementById('ddlPlan' + idFila).disabled)
					intDeshabilitado = '1';

				if (codigoTipoProductoActual == codTipoProdDTH)
				{
					url += '&flgHFC=0';
					url += '&flgReadOnly=' + intDeshabilitado;
					url += '&flgVentaProactiva=' + flgVentaProactiva;
					//nroPlanes = parseInt(0) + parent.nroPlanesEvaluados('', codTipoProdDTH);
					//url += '&nroPlanes=' + nroPlanes;

					strTieneDireccion = window.showModalDialog(url, '', 'dialogHeight:280px; dialogWidth:1000px');
				}
				else
				{
					if (codigoTipoProductoActual == codTipoProd3Play)
					{
						url += '&flgHFC=1';
						url += '&flgReadOnly=' + intDeshabilitado;
						//nroPlanes = parseInt(0) + parent.nroPaqEvaluadosHFC();
						//url += '&nroPlanes=' + nroPlanes;

						strTieneDireccion = window.showModalDialog(url, '', 'dialogHeight:550px; dialogWidth:1000px');
					}
				}
//gaa20130522
				//if (strTieneDireccion == undefined || strTieneDireccion.length == 0)
					//return false;
				if (strTieneDireccion == undefined || strTieneDireccion.indexOf('|') < 0)
					return false;

				var hidFlagVOD = document.getElementById('hidFlagVOD');
				var strFlagsVOD = hidFlagVOD.value;
				var strCadena =  '[' + idFila + ']:' + strTieneDireccion.split('|')[1] + '|';
				var intPosIni = strFlagsVOD.indexOf('[' + idFila + ']');
				var str = '';
				var intPosFin;

				if (intPosIni > -1)
				{
					str = strFlagsVOD.substring(intPosIni);
					intPosFin = str.indexOf('|');
					intPosFin += intPosIni + 1;

					hidFlagVOD.value = strFlagsVOD.replace(strFlagsVOD.substring(intPosIni, intPosFin), strCadena);
				}
				else
					hidFlagVOD.value += strCadena;
//fin gaa20130522
				return true;
			}

			function llenarPlazoIfr(idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strMetodo=' + 'LlenarPlazo';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function llenarDatosCombo(ddl, strDatos, booSeleccione)
			{
				var arrDatos;
				var arrItem;
				var strDato;
				var option;
				if(ddl != undefined)
				{
					ddl.innerHTML = "";
				}
				
				if (booSeleccione)
				{
					option = document.createElement('option');
					option.value = '';
					option.text = 'SELECCIONE...';
					if(ddl != undefined)
					{
						ddl.add(option);
					}
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
							if(ddl != undefined)
							{
								ddl.add(option);
							}
						}
					}
				}
			}

			function llenarComboHid(strDdl, idFila)
			{
				var ddl = document.getElementById('ddl' + strDdl + idFila);
				var str = document.getElementById('hid' + strDdl).value;

				llenarDatosCombo(ddl, str, true);
			}

			function eliminarFilaGrupo(fila, idFila, mostrarAdvertencia, borrarGrupo)
			{
				if (mostrarAdvertencia)
				{
					if (!confirm('¿Desea eliminar Solución/Paquete/Plan?'))
						return false;
				}

				if (document.getElementById('hidValidarGuardarCuota').value.length > 0)
				{
					alert('Debe guardar las cuotas antes de ejecutar esta acción');
					return false;
				}

				var hidGrupoPaquete = document.getElementById('hidGrupoPaquete');
				var strGrupoPaquete = hidGrupoPaquete.value;
				var strVB = '[' + idFila + ']';
				var intPosFin = strGrupoPaquete.indexOf(strVB);
				var intPosIni;
				var intPosFin;
				var arrGrupo;

				if (intPosFin > -1)
				{
					intPosIni = strGrupoPaquete.substring(0, intPosFin).lastIndexOf('{') + 1;
					intPosFin = strGrupoPaquete.substring(intPosIni).indexOf('}') + intPosIni;

					arrGrupo = strGrupoPaquete.substring(intPosIni, intPosFin).split(',')

					for (var i = 1; i < arrGrupo.length; i++)
					{
						eliminarFilaGrupal(arrGrupo[i].replace('[','').replace(']', ''));
					}

					intPosIni = strGrupoPaquete.substring(0, intPosFin).lastIndexOf('{');
					intPosFin = strGrupoPaquete.substring(intPosIni).indexOf('}') + intPosIni + 1;

					if (borrarGrupo)
						hidGrupoPaquete.value = strGrupoPaquete.replace(strGrupoPaquete.substring(intPosIni, intPosFin), '');
					else
						return strGrupoPaquete.substring(intPosIni, intPosFin);
				}
				else
					eliminarFila(fila, idFila);

				return true;
			}

			function eliminarFilaGrupal(idFila)
			{
				var producto = obtenerProductoxIdFila(idFila);
				var tabla = document.getElementById('tblTabla' + producto);
				var cont = tabla.rows.length;
				var strValor;
				var intPosIni;

				cerrarServicio();
				cerrarCuota();

				for (var i = 0; i < cont; i++)
				{
					strValor = tabla.rows(i).cells[2].innerHTML;
					intPosIni = strValor.indexOf('ddlPlazo') + 8;
					intPosFin = strValor.substring(intPosIni).indexOf(' ') + intPosIni;

					if (idFila == strValor.substring(intPosIni, intPosFin))
					{
						tabla.deleteRow(i);

						eliminarItem(idFila);
						borrarServicio(idFila);
						borrarCuota(idFila);

						if (tabla.rows.length == 0)
						{
							document.getElementById('hidPlazoActual').value = '';
							traerPlazo('S');
							document.getElementById('txtCFTotal').value = '0';
						}
						else
							calcularCFxProducto();

						return;
					}
				}
			}

			function eliminarFila(fila, idFila)
			{
				borrarServicio(idFila);
				borrarCuota(idFila);

				cerrarServicio();
				cerrarCuota();
				CerrarSaldoCC();

				if (fila == null)
					fila = document.getElementById('ddlPlazo' + idFila);

				if (fila == null)
					return;

				var id = fila.parentNode.parentNode.rowIndex;
				var tabla = document.getElementById(fila.parentNode.parentNode.parentNode.parentNode.id);

				tabla.deleteRow(id);
				eliminarItem(idFila);

				if (tabla.rows.length == 0)
				{
					document.getElementById('hidPlazoActual').value = '';
					traerPlazo('S');
					document.getElementById('txtCFTotal').value = '0';
				}
				else
					calcularCFxProducto();
			}

			function verificarConfirmacion(booEnviarAlerta)
			{
				var tabla = document.getElementById('tblTablaMovil');

				var cont = tabla.rows.length;

				for (var i = 0; i < cont; i++)
				{
					if (tabla.rows(i).cells[0].innerHTML.indexOf('DISPLAY: none') == -1)
					{
						if (booEnviarAlerta)
							alert('Para agregar un nuevo plan debe confirmar el plan anterior');

						return false;
					}
				}

				return true;
			}
			
			function verificarPlanes()
			{
				var tabla = document.getElementById('tblTabla' + getValue('hidTipoProductoActual'));
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var codigoSinCuota = '00';
				var codigoOtro = '';
				var codigoCuota;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];

					if (getValue('hidCodigoTipoProductoActual') != codTipoProdDTH) //ddlPlazo
						idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
					else //ddlCampana
						idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

					if (!preservarFila(idFila))
						return false;

					arrCuota = obtenerCuotaValores(idFila);

					if (arrCuota != null)
					{
						codigoCuota = arrCuota[0].split('_')[0];

						if (codigoCuota.length == 0)
							codigoCuota = codigoSinCuota;

						if (codigoOtro.length == 0)
						{
							codigoOtro = codigoCuota;
							if (codigoOtro.length == 0)
								codigoOtro = codigoSinCuota;
						}
						else
						{
							if (codigoOtro != codigoCuota)
							{
								alert('Se debe emplear una misma cuota para todos los planes');
								return false;
							}
						}
					}
					else
					{
						codigoCuota = codigoSinCuota;
						if (codigoOtro.length == 0)
							codigoOtro = codigoSinCuota;

						if (codigoOtro != codigoCuota)
						{
							alert('Se debe emplear una misma cuota para todos los planes');
							return false;
						}
					}
				}
				
				return true;
			}

			function quitarFilas()
			{
				var tabla = document.getElementById('tblTablaMovil');
				var cont = tabla.rows.length;
				for (var i = 0; i < cont; i++)
				{
					tabla.deleteRow(0);
				}
				document.getElementById('hidPlanServicio').value = '';
				document.getElementById('hidPlanServicioNo').value = '';
				document.getElementById('hidPlanServicioNoGrupo').value = '';
				document.getElementById('hidPlanServicioNGTemp').value = '';
				document.getElementById('hidLineaActual').value = '0';
				document.getElementById('hidTotalLineas').value = '0';
				document.getElementById('hidPlazoActual').value = '';
				document.getElementById('hidCuota').value = '';
				document.getElementById('hidNroCuotaActual').value = '';
				document.getElementById('hidGrupoPaquete').value = '';

				cerrarServicio();
				cerrarCuota();
				traerPlazo('S');
				document.getElementById('txtCFTotal').value = '0';
			}

			function editarFila(idFila, soloHabilitar)
			{
				var imgEditarFila = document.getElementById('imgEditarFila' + idFila);

				if (imgEditarFila == null)
					return;

				var booEs3Play = false;

				if (getValue('hidCodigoTipoProductoActual') == codTipoProd3Play && !soloHabilitar)
				{
					if (!confirm('¿Cambiar de Solución y Paquete? presione Sí, sino se editarán planes y/o servicios y dirección de instalación'))
						booEs3Play = true;
					else
					{
						eliminarFilaTotal(null, idFila, false);
						agregarFila1(false);

						return;
					}
				}

				if (document.getElementById('hidValidarGuardarCuota').value.length > 0)
				{
					alert('Debe guardar las cuotas antes de ejecutar esta acción');
					return;
				}

				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				//var ddlEquipo = document.getElementById('ddlEquipo' + idFila);
				var txtNroPortar = document.getElementById('txtNroPortar' + idFila);
				//var strTieneEquipo = document.getElementById('hidTieneCuotas').value;
				var imgListaEquipo = document.getElementById('imgListaEquipo' + idFila);
//gaa20161024
				var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
//fin gaa20161024
				//if (strTieneEquipo == 'S' && !booEs3Play)
				if (imgListaEquipo != null && !booEs3Play)
				{
					var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
					//var imgListaEquipo = document.getElementById('imgListaEquipo' + idFila);
					txtTextoEquipo.disabled = false;
					imgListaEquipo.style.display = '';
				}
				if (txtNroPortar != null)
					setEnabled('txtNroPortar' + idFila, true, 'clsInputEnabled');

				if (ddlPaquete != null)
				{
					if (ddlPaquete.value.length == 0)
						ddlPlan.disabled = false;
				}
				else
					ddlPlan.disabled = false;

				if (ddlCampana != null)
					ddlCampana.disabled = false;

				if (ddlPlan != null)
					ddlPlan.disabled = false;

				//Paquete Corporativo
				if ((ddlPaquete != null) && (getValue('hidCodigoTipoProductoActual') != codTipoProd3Play))
					ddlPlan.disabled = true;
//gaa20161024
				if (ddlFamiliaPlan != null)
					ddlFamiliaPlan.disabled = false;
//fin gaa20161024
				cerrarServicio();
				cerrarCuota();

				autoSizeProducto();
			}

			function preservarFila(idFila)
			{
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				var hidValorEquipo = document.getElementById('hidValorEquipo' + idFila);
				var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
				var hidPlazoActual = document.getElementById('hidPlazoActual');
				var txtNroPortar = document.getElementById('txtNroPortar' + idFila);
				var strNroPortar;
				//gaa20161024
				var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
				//fin gaa20161024
				if (ddlPlazo.value.length == 0)
				{
					if (!ddlPlan.disabled)
					{
						ddlPlazo.focus();
						alert('Debe seleccionar un plazo');
						return false;
					}
				}
				if (ddlPlan.value.length == 0)
				{
					if (!ddlPlan.disabled)
					{
						ddlPlan.focus();
						alert('Debe seleccionar un plan');
						return false;
					}
				}
				//gaa20161024
				if (ddlFamiliaPlan != null) {
					if (ddlFamiliaPlan.value.length == 0) {
						if (!ddlFamiliaPlan.disabled) {
							ddlFamiliaPlan.focus();
							alert('Debe seleccionar una familia de plan');
							return false;
						}
					}
				}
				//fin gaa20161024
				if (getValue('hidCodigoTipoProductoActual') != codTipoProd3Play)
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
						if (listaPlazoEquipo.indexOf(plazo) > 0 || parent.getValue('ddlModalidad') == constModalidadPagoEnCuota)
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

				if (document.getElementById('tblServicios').style.display != 'none')
				{
					alert('Debe guardar los servicios');
					return false;
				}

				if (document.getElementById('tblCuotas').style.display != 'none')
				{
					alert('Debe guardar las cuotas');
					return false;
				}

				if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota) {
					if (hidListaPrecio.value == null || hidListaPrecio.value == '') {
						alert('Debe seleccionar la cuota');
						return false;
					}
				}
            
				if (txtNroPortar != null)
				{
					strNroPortar = txtNroPortar.value;
					if (strNroPortar.length != 9)
					{
						if (!txtNroPortar.disabled)
						{
							txtNroPortar.focus();
							alert('Debe ingresar un número de portabilidad válido');
							return false;
						}
					}
				}

				preservarFila1(idFila);

				return true;
			}

			function validarNroPortabilidad(idFila, nroPorta)
			{
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strNroPorta=' + nroPorta;
				url += '&strMetodo=' + 'ValidarNroPortabilidad';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarValidarNroPortabilidad(idFila, strResultado)
			{
				var idCodigo = strResultado.split('|')[0];
				if (idCodigo != '1')
				{
					var strMensaje = strResultado.split('|')[1];
					var txtNroPortar = document.getElementById('txtNroPortar' + idFila);
					txtNroPortar.focus();
					alert(strMensaje);
					return false;
				}
				else
					preservarFila1(idFila);

				return true;
			}

			function preservarFila1(idFila)
			{
				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				var strTieneEquipo = document.getElementById('hidTieneCuotas').value;
				//if (strTieneEquipo == 'S')
				//{
				var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
				if (txtTextoEquipo != null)
				{
					txtTextoEquipo.disabled = true;

					var imgListaEquipo = document.getElementById('imgListaEquipo' + idFila);
					if (imgListaEquipo != null)
						imgListaEquipo.style.display = 'none';
				}
				var hidPlazoActual = document.getElementById('hidPlazoActual');
				var txtNroPortar = document.getElementById('txtNroPortar' + idFila);
//gaa20161024
				var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
//fin gaa20161024
				if (txtNroPortar != null)
					setEnabled('txtNroPortar' + idFila, false, 'clsInputDisabled');

				if (ddlPaquete != null)
					ddlPaquete.disabled = true;
				ddlPlan.disabled = true;
				ddlPlazo.disabled = true;

				if (ddlCampana != null)
					ddlCampana.disabled = true;
//gaa20161024
				if (ddlFamiliaPlan != null)
					ddlFamiliaPlan.disabled = true;
//fin gaa20161024
				cerrarServicio();
				cerrarCuota();
				hidPlazoActual.value = ddlPlazo.value + "_" + obtenerTextoSeleccionado(ddlPlazo);

				var strNroCuotas = document.getElementById('ddlNroCuotas').value;
				var hidNroCuotaActual = document.getElementById('hidNroCuotaActual');

				if (strNroCuotas.length > 0)
				{
					if (parseInt(strNroCuotas.substring(0, 2)) > 0)
						hidNroCuotaActual.value = strNroCuotas;
				}
			}

			function enviarMsj(mensaje)
			{
				alert(mensaje);
			}
			/*
			String.prototype.insert = function( idx, rem, s )
			{
				return (this.slice(0,idx) + s + this.slice(idx + Math.abs(rem)));
			};
			*/
/*
			function inicializarPlan(idFila)
			{
				if (getValue('hidCodigoTipoProductoActual') != codTipoProd3Play)
				{
					borrarServicio(idFila);
					cerrarServicio();
				}

				if (getValue('hidCodigoTipoProductoActual') != codTipoProdDTH)
				{
					document.getElementById('txtCFPlanServicio' + idFila).value = '';

					var txtMontoTopeConsumo = document.getElementById('txtMontoTopeConsumo' + idFila);
					var ddlCampana = document.getElementById('ddlCampana' + idFila);

					if (txtMontoTopeConsumo != null)
						txtMontoTopeConsumo.value = '';
					if (ddlCampana != null)
						ddlCampana.value = '';

					inicializarEquipo(idFila);
					borrarCuota(idFila)
					cerrarCuota();
				}
			}
*/
/*
			function cambiarPlan(strPlan, idFila)
			{
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');

				inicializarPlan(idFila);
				if (strPlan.length == 0)
				{
					document.getElementById('hidLineaActual').value = idFila;

					calcularLCxProductoFijo();
					calcularCFxProducto();

					if (codigoTipoProductoActual == codTipoProdDTH)
					{
						document.getElementById('ddlPlazo' + idFila).value = '';
						setValue('txtCFPlanServicio' + idFila, '0');
						setValue('txtCFTotMensual' + idFila, '0');
						inicializarEquipo(idFila);
						llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);
					}
					else
					{
						llenarDatosCombo(document.getElementById('ddlCampana' + idFila), '', true);
						llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);
					}

					return;
				}
				var strPlanCodigo = getValor(strPlan, 0);
				var strPlanCodigoSap = getValor(strPlan, 2);
				var strPlanCF = getValor(strPlan, 1);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strPlazo = ddlPlazo.value;
// --- Bolsa compartida
			var strPlanesBolsa = window.parent.document.getElementById('hidPlanBase').value;
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				
				if (strPlanesBolsa.indexOf('|' + strPlanCodigo) > -1)
				{
					var datosBolsa = mostrarPopupPlanCombo(strPlanCodigo, obtenerTextoSeleccionado(ddlPlan));
					
					if (datosBolsa != undefined)
					{
						if (datosBolsa.length > 0)
						{
							var strPlanActualizado = datosBolsa.split('|')[0];

							llenarDatosCombo(ddlPlan, '|' + strPlanActualizado, false);
							ddlPlan.value = strPlanActualizado.split(';')[0];
							cambiarPlan(strPlanActualizado, idFila);
							ddlPlan.disabled = true;
							return;
						}
					}
				}

//--- Bolsa compartida

				document.getElementById('hidLineaActual').value = idFila;

				document.getElementById('txtCFPlanServicio' + idFila).value = strPlanCF;

				document.getElementById('btnCerrarServicios').value = 'Cerrar y Guardar';

				if (codigoTipoProductoActual != codTipoProdDTH)
				{
					if (codigoTipoProductoActual != codTipoProd3Play)
					{
						LlenarServicioCampana(strPlanCodigo, strPlazo, idFila, strPlanCodigoSap)
					}
					else
					{
						calcularCFxProducto();

						asignarPromocion3Play(idFila);
						llenarServicio(idFila);
					}
				}
				else
					LlenarPlazoServicioDthIfr(strPlanCodigo, idFila);
				

				var planTarifaSelected = getValor(strPlan, 0) + "," + getValor(strPlan, 2) + "," + getText('ddlPlan' + idFila);
				parent.setValue('hidPlanTarifaSelected', planTarifaSelected);
			}
*/
			function LlenarPlazoServicioDthIfr(strPlan, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strPlan=' + strPlan;
				url += '&strMetodo=' + 'LlenarPlazoServicioDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarPlazoServicio(idFila, pstrResultado)
			{
				var arrResultado;
				var strServicios;
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);

				if (pstrResultado.indexOf('~') > -1)
				{
					arrResultado = pstrResultado.split('~');

					llenarDatosCombo(ddlPlazo, arrResultado[0], true);

					strServicios = arrResultado[1];

					if (strServicios.indexOf('¬') > -1)
					{
						arrResultado = strServicios.split('¬');
						var lbxServiciosDisponibles1 = document.getElementById('lbxServiciosDisponibles1');
						var lbxServiciosAgregados1 = document.getElementById('lbxServiciosAgregados1');

						llenarDatosCombo(lbxServiciosDisponibles1, arrResultado[0], false);
						llenarDatosCombo(lbxServiciosAgregados1, arrResultado[1], false);

						agregarGrupo(idFila, true);
						guardarServicio();
					}
				}

				if (ddlPlazo.disabled)
				{
					strPlazos = verificarPlazo(getValue('hidTipoProductoActual'));

					if (strPlazos.length > 0)
					{
						llenarDatosCombo(ddlPlazo, strPlazos, false);
						cambiarPlazo(ddlPlazo.value, idFila);
					}
					else
						ddlPlazo.disabled = false;
				}
			}

			function LlenarCampanaIfr(strPlan, strPlazo, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strPlazo=' + strPlazo + '&strPlan=' + strPlan;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strTipoProducto=' + getValue('ddlTipoProducto_' + idFila);
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&strMetodo=' + 'LlenarCampana';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarServicioIfr(pstrCasoEspecial, pstrPlanCodigo, pstrPlanCodigoSap, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strCasoEspecial=' + pstrCasoEspecial + '&strPlan=' + pstrPlanCodigo;
				url += '&strPlanSap=' + pstrPlanCodigoSap;
				url += '&strMetodo=' + 'LlenarServicio';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarServicioCampana(strPlan, strPlazo, idFila, pstrPlanCodigoSap)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strPlazo=' + strPlazo + '&strPlan=' + strPlan;
				url += '&strOferta=' + parent.getValue('ddlOferta') + '&strTipoProducto=' + getValue('ddlTipoProducto_' + idFila);
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&strPlanSap=' + pstrPlanCodigoSap;
				url += '&strTipoModalidadVenta=' + parent.getValue('ddlModalidad');
				url += '&strMetodo=' + 'LlenarServicioCampana';
				url += '&strFlagServicioRI=' + parent.getValue('hidFlagRoamingI');

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarServicioCampanaDTH(strPlan, strPlazo, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila + '&strPlazo=' + strPlazo + '&strPlan=' + strPlan;
				url += '&strMetodo=' + 'LlenarServicioCampanaDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarServicioCampana(idFila, pstrResultado)
			{
				var arrResultado;
				var strServicios;

				if (pstrResultado.indexOf('~') > -1)
				{
					arrResultado = pstrResultado.split('~');

					llenarCampana(idFila, arrResultado[0]);

					strServicios = arrResultado[1];

					if (strServicios.indexOf('¬') > -1)
					{
						arrResultado = strServicios.split('¬');
						var lbxServiciosDisponibles1 = document.getElementById('lbxServiciosDisponibles1');
						var lbxServiciosAgregados1 = document.getElementById('lbxServiciosAgregados1');

						llenarDatosCombo(lbxServiciosDisponibles1, arrResultado[0], false);
						llenarDatosCombo(lbxServiciosAgregados1, arrResultado[1], false);

						agregarGrupo(idFila, true);
						guardarServicio();
					}
					else
						calcularCFxProducto();

					calcularLCxProductoFijo();
				}
			}

			function LlenarServCampCorpTot(strPlanes)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&strPlanes=' + strPlanes;
				url += '&strMetodo=' + 'LlenarServCampCorpTot';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function retornarServCampCorpTot(pstrResultado)
			{
				var arrResultado;
				var arrResultado1;
				var j = 0;

				if (pstrResultado.indexOf('°') > -1)
				{
					arrResultado = pstrResultado.split('°');

					var total = arrResultado.length;

					for (j = 0; j < total; j++)
					{
						arrResultado1 = arrResultado[j].split('!');

						if (arrResultado1 != null && arrResultado1 != undefined)
						{
							if (arrResultado1[1] != null && arrResultado1[1] != undefined)
								retornarServicioCampanaCorp(arrResultado1[0], arrResultado1[1]);
						}
					}
				}
			}

			function retornarServicioCampanaCorp(idFila, pstrResultado)
			{
				var arrResultado;
				var strServicios;

				asignarLineaActual(idFila);

				if (pstrResultado.indexOf('~') > -1)
				{
					arrResultado = pstrResultado.split('~');

					llenarCampana(-1, arrResultado[0]);

					strServicios = arrResultado[1];

					if (strServicios.indexOf('¬') > -1)
					{
						arrResultado = strServicios.split('¬');
						var lbxServiciosDisponibles1 = document.getElementById('lbxServiciosDisponibles1');
						var lbxServiciosAgregados1 = document.getElementById('lbxServiciosAgregados1');

						llenarDatosCombo(lbxServiciosDisponibles1, arrResultado[0], false);
						llenarDatosCombo(lbxServiciosAgregados1, arrResultado[1], false);

						agregarGrupo(-1, true);
						guardarServicio();
					}
				}
			}
/*
			function LlenarCampanaDTH()
			{
				cargarImagenEsperando();
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'strMetodo=' + 'LlenarCampanaDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
*/
			function asignarPlanMultiLinea(idFila, strValor, strPaquete)
			{
				var strTipoProducto = getValue('hidCodigoTipoProductoActual');
				var ddlTipoProducto;
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strPlazo = ddlPlazo.value + "_" + obtenerTextoSeleccionado(ddlPlazo);
				var strPlazos = '|' + ddlPlazo.value + ";" + obtenerTextoSeleccionado(ddlPlazo);
				var strPlazoCodigo = ddlPlazo.value;
				var hidPlazoActual = document.getElementById('hidPlazoActual');
				var hidPaqueteActual = document.getElementById('hidPaqueteActual');
				var hidGrupoPaquete = document.getElementById('hidGrupoPaquete');
				var txtCFPlanServicio;
				var strPlan;
				var strPlanCodigo;
				var strPlanCF;
				var strSecuencia;
				var strPlanCodigoSap;
				idFila = parseInt(idFila);

				if (strValor == null)
					return;

				var arrPlanes = strValor.split("|");
				var arrPlan;
				var ddlPlan;
				var ddlPaquete;
				var strPlanes = '';

				hidPlazoActual.value = strPlazo;

				hidGrupoPaquete.value += '{'

				for (var i = 1; i < arrPlanes.length; i++)
				{
					if (i > 1)
					{
						agregarFila(false);
						idFila += 1;
					}

					ddlPlan = document.getElementById('ddlPlan' + idFila);
					llenarDatosCombo(ddlPlan, strValor, true);
					arrPlan = arrPlanes[i].split(";");
					strPlan = arrPlan[0];
					ddlPlan.value = strPlan;
					strPlanCodigo = getValor(strPlan, 0);
					strPlanCF = getValor(strPlan, 1);
					strSecuencia = getValor(strPlan, 4);
					strPlanCodigoSap = getValor(strPlan, 2);

					txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
					txtCFPlanServicio.value = strPlanCF;

					ddlPaquete = document.getElementById('ddlPaquete' + idFila);
					ddlPlazo = document.getElementById('ddlPlazo' + idFila);

					llenarDatosCombo(ddlPlazo, strPlazos, false);

					ddlPlazo.disabled = true;
					ddlPaquete.disabled = true;
					ddlPlan.disabled = true;

					strPlanes += '|' + strPlanCodigo + ',' + strPlazoCodigo + ',' + idFila + ',' + strPlanCodigoSap + ',' + strPaquete + ',' + strSecuencia;
					hidGrupoPaquete.value += ',[' + idFila + ']';
					llenarMaterial(idFila, ''); asignarMaterial1(idFila);
				}

				LlenarServCampCorpTot(strPlanes);

				hidGrupoPaquete.value += '}'

				quitarImagenEsperando();
			}

			function seleccionarValorCombo(ddl, valor)
			{
				for (var i = 0; i < ddl.options.length; i++)
				{
					if (ddl.options[i].value == valor)
					{
						ddl.value = valor;
						return true;
					}
				}

				return false;
			}

			function asignarPlanMultiLinea3Play(idFila, strValor, strPaquete)
			{
				if (strValor == '' || strValor == null) return;

				cargarImagenEsperando();

				var arrServProm = strValor.split('¬');
				var strTipoProducto = getValue('hidCodigoTipoProductoActual');
				//var ddlTipoProducto;
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strPlazo = '|' + ddlPlazo.value + ";" + obtenerTextoSeleccionado(ddlPlazo);
				var hidPlazoActual = document.getElementById('hidPlazoActual');
				var hidPaqueteActual = document.getElementById('hidPaqueteActual');
				var hidGrupoPaquete = document.getElementById('hidGrupoPaquete');
				var idFilaIni = idFila;
				idFila = parseInt(idFila);
				hidPlazoActual.value = strPlazo;
				var arrPlanes = arrServProm[0].split('|');
				var arrPlanCodigo;
				var cont = arrPlanes.length;
				var strPlanesCombo = '';
				var strPlan;
				var strPlanCodigo;
				var intSecuenciaAnt = 0;
				var intSecuenciaAct = 0;
				var intDefecto = 0;
				var intPrincipal = 0;
				var intOpcional = 0;
				var fltCF = 0;
				var strPlanxDefecto = '';
				var ddlPlan;
				var txtCFPlanServicio;
				var strPlanCodigo1;
				var hidPlanServicio = document.getElementById('hidPlanServicio');
				var hidPlanServicioNo = document.getElementById('hidPlanServicioNo');
				var strPlanServicio = '*ID*' + idFila;
				var strPlanServicioNo = '*ID*' + idFila;
				var booIngreso;
				var hidMontoServicios;
				var fltMonto = 0;

				var ddlCampana;
				var imgVerCuota;
				var txtTextoEquipo;
				var imgListaEquipo;
				var txtEquipoPrecio;
				var strSolucion = '';
				var arrPlan;

				hidGrupoPaquete.value += '{'

				for (j = 1; j < cont; j++)
				{
					strPlan = arrPlanes[j];
					strPlanCodigo = strPlan.split(';')[0];
					arrPlanCodigo = strPlanCodigo.split('_');

					intSecuenciaAct = arrPlanCodigo[4];
					intDefecto = arrPlanCodigo[6];
					intPrincipal = arrPlanCodigo[7];
					intOpcional = arrPlanCodigo[8];
					strPlanCodigo1 = arrPlanCodigo[0];
					fltCF = parseFloat(arrPlanCodigo[1]);

					if (intSecuenciaAnt == 0)
					{
						intSecuenciaAnt = intSecuenciaAct;

						ddlTipoProducto = document.getElementById('ddlTipoProducto_' + idFila);
						ddlPlazo =  document.getElementById('ddlPlazo' + idFila);
						ddlPaquete = document.getElementById('ddlPaquete' + idFila);
						ddlPlazo.disabled = true;
						ddlPaquete.disabled = true;

						hidGrupoPaquete.value += ',[' + idFila + ']';
					}

					if (intPrincipal == 1) //Si es plan
					{
						if (intSecuenciaAnt == intSecuenciaAct)
						{
							strPlanesCombo += '|' + strPlan;

							if (intDefecto == 1)
								strPlanxDefecto = strPlan.split(';')[0];

							document.getElementById('ddlSolucion' + idFila).disabled = true;
						}
						else
						{
							ddlPlan = document.getElementById('ddlPlan' + idFila);
							llenarDatosCombo(ddlPlan, strPlanesCombo, true);

							if (seleccionarValorCombo(ddlPlan, strPlanxDefecto))
							{
								txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
								txtCFPlanServicio.value = strPlanxDefecto.split('_')[1];

								calcularCFxProducto();
							}

							if (intDefecto == 1)
								strPlanxDefecto = strPlan.split(';')[0];

							strPlanesCombo = '|' + strPlan;
							agregarFila(false);

							if (strSolucion.length == 0)
							{
								var ddlSolucion = document.getElementById('ddlSolucion' + idFila);
								var strSolucion = '|' + ddlSolucion.value + ";" + obtenerTextoSeleccionado(ddlSolucion);
								ddlSolucion.disabled = true;
							}

							idFila += 1;

							ddlSolucion = document.getElementById('ddlSolucion' + idFila);
							ddlSolucion.disabled = true;
							llenarDatosCombo(ddlSolucion, strSolucion, false);

							intSecuenciaAnt = intSecuenciaAct;

							ddlPlazo =  document.getElementById('ddlPlazo' + idFila);
							llenarDatosCombo(ddlPlazo, strPlazo, false);

							ddlPaquete = document.getElementById('ddlPaquete' + idFila);

							ddlPlazo.disabled = true;
							ddlPaquete.disabled = true;

							hidGrupoPaquete.value += ',[' + idFila + ']';

							strPlanServicio += '*ID*' + idFila;
							strPlanServicioNo += '*ID*' + idFila;
						}
					}
					else //Si es servicio
					{
						if (intOpcional == 0)
						{
							arrPlan = strPlan.split(';');
							//strPlanServicio += strPlanServicio = '|' + '__2_' + strPlan;
							strPlanServicio += strPlanServicio = '|' + '__2_' + arrPlan[0] + ';(*) ' + arrPlan[1];

							hidMontoServicios = document.getElementById('hidMontoServicios' + idFila);
							fltMonto = (hidMontoServicios.value.length > 0)? parseFloat(hidMontoServicios.value):0;
							hidMontoServicios.value = fltMonto + fltCF;
						}
						else
						{
							strPlanServicioNo += strPlanServicioNo = '|' + '__0_' + strPlan;
						}
					}

					if (j == cont - 1)
					{
						ddlPlan = document.getElementById('ddlPlan' + idFila);
						llenarDatosCombo(ddlPlan, strPlanesCombo, true);

						if (seleccionarValorCombo(ddlPlan, strPlanxDefecto))
						{
							txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
							txtCFPlanServicio.value = strPlanxDefecto.split('_')[1];
						}
					}
				}

				hidPlanServicio.value += strPlanServicio;
				hidPlanServicioNo.value += strPlanServicioNo;

				hidGrupoPaquete.value += '}';

				calcularCFxProducto();
				calcularLCxProductoFijo();

				//setValue('hidPromociones', arrServProm[1]);
				document.getElementById('hidPromociones').value += arrServProm[1];

				asignarPromocion3Play(idFilaIni, idFila);

				quitarImagenEsperando();
			}

			function asignarPromocion3Play(idFila, idFilaFinal)
			{
				if (idFilaFinal == null)
					idFilaFinal = -1;

				var tabla = document.getElementById('tblTablaHFC');
				var cont = tabla.rows.length;
				var nCell; //0: Imagen, 1:Imagen
				var strSrvSel = '';
				var strPromociones = getValue('hidPromociones');
				var arrPromociones = strPromociones.split('|');
				var strServicio = getValue('hidPlanServicio');

				//Obtengo promociones del plan(es) seleccionado
				for (var i = 0; i < cont; i++)
				{
					nCell = 3; //0: Imagen Confirmar, 1:Imagen Eliminar, 2:Plazo, 3:Solucion
					fila = tabla.rows[i];

					//idFila
					idFilaX = fila.cells[nCell].getElementsByTagName("select")[0].id.substring(11);

					if (idFila == 0 || (idFila < idFilaX && idFilaX < idFilaFinal) || idFila == idFilaX)
					{
						strSrvSel = '';

						nCell+=2;
						planSel = fila.cells[nCell].getElementsByTagName("select")[0].value.split('_')[0];
						strSrvSel += ';' + planSel;

						borrarPromocion(idFilaX);

						strSrvSel += extraerCodigoServicio(idFilaX);

						asignarPromocion3Play1(idFilaX, strSrvSel, false);
					}
				}
			}

			function asignarPromocion3Play1(idFila, strSrvSel, haciaTemp)
			{
				var strPromociones = getValue('hidPromociones');
				var arrPromociones = strPromociones.split('|');
				var arrPromocion;
				var strPromocion;
				var strCodProm = '';
				var arrCodProm;
				var strIDDET;
				var strIDPRODUCTO;
				var strIDLINEA;
				var intPosIni;
				var strCodSrv;
				var strResultado = '';
				var hidPromocion;
				var arrSrv = strSrvSel.split(';');

				if (!haciaTemp)
					hidPromocion = document.getElementById('hidPromocion');
				else
					hidPromocion = document.getElementById('hidPromocionTemp');

				for (var i = 1; i < arrSrv.length; i++)
				{
					strCodSrv = arrSrv[i];
					intPosIni = strPromociones.indexOf(strCodSrv);

					if (intPosIni > -1)
					{
						for (var j = 1; j < arrPromociones.length; j++)
						{
							strPromocion = arrPromociones[j];
							arrPromocion = strPromocion.split('_');
							strCodProm = arrPromocion[0];
							arrCodProm = strCodProm.split('.');
							strIDDET = arrCodProm[0];
							strIDPRODUCTO = arrCodProm[1];
							strIDLINEA = arrCodProm[2];

							strFLGEDI = arrPromocion[3];

							if (strCodSrv == strIDDET + '.' + strIDPRODUCTO + '.' + strIDLINEA)
							{
								if (strFLGEDI == '0')
									strResultado += '|' + '__2_' + strCodProm + ';' + strPromocion.split(';')[1];
								else
									strResultado += '|' + '__1_' + strCodProm + ';' + strPromocion.split(';')[1];
							}
						}
					}
				}

				hidPromocion.value += '*ID*' + idFila + strResultado;
			}

			function extraerCodigoServicio(idFila)
			{
				var strResultado = '';
				var strServicio = getValue('hidPlanServicio');
				var arrServicios;
				var strIdFila = '*ID*' + idFila;
				var strCodigo;

				var intPosIni = strServicio.indexOf(strIdFila);
				var intPosFin = 0;

				if (intPosIni > -1)
				{
					intPosFin = strServicio.substring(intPosIni + 4).indexOf('*ID*');

					if (intPosFin == -1)
						intPosFin = strServicio.length;
					else
						intPosFin += intPosIni + 4;

					strServicio = strServicio.substring(intPosIni, intPosFin);

					arrServicios = strServicio.split('|');

					for (var i = 1; i < arrServicios.length; i++)
					{
						strCodigo = arrServicios[i].split('_')[3];
						strResultado += ';' + strCodigo;
					}
				}

				return strResultado;
			}

			function borrarPromocion(idFila)
			{
				var hidPromocion = document.getElementById('hidPromocion');
				var strPromocion = hidPromocion.value;
				var strIdFila = '*ID*' + idFila;

				var intPosIni = strPromocion.indexOf(strIdFila);
				var intPosFin = 0;

				if (intPosIni > -1)
				{
					intPosFin = strPromocion.substring(intPosIni + 4).indexOf('*ID*');

					if (intPosFin == -1)
						intPosFin = strPromocion.length;
					else
						intPosFin += intPosIni + 4;

					hidPromocion.value = strPromocion.replace(strPromocion.substring(intPosIni, intPosFin), '');
				}
			}

			function asignarPaquete(idFila, strValor)
			{
				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				var strPaqueteActual = document.getElementById('hidPaqueteActual').value;

				llenarDatosCombo(ddlPaquete, strValor, true);

				if (strPaqueteActual.length > 0)
					ddlPaquete.value = strPaqueteActual;
			}

			function cambiarPaquete(strPaquete, idFila)
			{
				if (strPaquete.length > 0)
				{
					var strPaqueteDesc = obtenerTextoSeleccionado(document.getElementById('ddlPaquete' + idFila));
					var strPaqCompleto = '|' + strPaquete + ";" + strPaqueteDesc;
					setValue('hidPaqueteActual', strPaquete);
					setValue('hidPaqActCompleto', strPaqCompleto);

					if (getValue('hidCodigoTipoProductoActual') != codTipoProd3Play)
						LlenarPlanPaqIfr(strPaquete, idFila);
					else
					{
						LlenarPlanPaq3PlayIfr(getValor(strPaquete, 0), idFila);
						setValue('hidPaquete3Play', strPaqueteDesc);
					}
				}
				else
					calcularLCxProductoFijo();
			}

			function LlenarPlanPaqIfr(strPaquete, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strPaquete=' + strPaquete;
				url += '&strMetodo=' + 'LlenarPlanPaq';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarPlanPaq3PlayIfr(strPaquete, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strPaquete=' + strPaquete;
				url += '&strMetodo=' + 'LlenarPlanPaq3Play';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
//gaa20150504
/*
			function cambiarPlazo(strPlazo, idFila)
			{
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var strFlujo = flujoAlta;
				if (parent.getValue('hidTienePortabilidad') == 'S')
					strFlujo = flujoPortabilidad;

				var strTienePaquete = document.getElementById('hidTienePaquete').value;
				cerrarCuota();
				inicializarEquipo(idFila);

				if (codigoTipoProductoActual != codTipoProdDTH && codigoTipoProductoActual != codTipoProd3Play)
				{
					if (document.getElementById('ddlPlan' + idFila) != undefined)
					{
						llenarDatosCombo(document.getElementById('ddlPlan' + idFila), '', true);
					}
					if (document.getElementById('ddlCampana' + idFila) != undefined)
					{
						llenarDatosCombo(document.getElementById('ddlCampana' + idFila), '', true);
					}
					if (document.getElementById('txtCFPlanServicio' + idFila) != undefined)
					{
						setValue('txtCFPlanServicio' + idFila, '0');
					}
					if (document.getElementById('hidMontoServicios' + idFila) != undefined)
					{
						setValue('hidMontoServicios' + idFila, '0');
					}
					if (document.getElementById('hidMontoCuota' + idFila) != undefined)
					{
						setValue('hidMontoCuota' + idFila, '0');
					}
					if (document.getElementById('divListaEquipo' + idFila) != undefined)
					{
						llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);
					}
					calcularCFxProducto();
				}

				if (strPlazo.length > 0)
				{
					if (codigoTipoProductoActual == codTipoProdDTH)
					{
						LlenarKitDthIfr(idFila);
						return;
					}
					else
					{
						if (codigoTipoProductoActual == codTipoProd3Play)
						{
							LlenarSolucionIfr(idFila, strPlazo);
							return;
						}
					}
				}

				if (strPlazo.length > 0)
				{
					if (strTienePaquete == 'S')
					{
						var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
						if (ddlPaquete != null)
							llenarDatosCombo(ddlPaquete, '', true);

						if (codigoTipoProductoActual != codTipoProd3Play)
						{
							if (codigoTipoProductoActual == codTipoProdMovil)
							{
								LlenarPaquetePlanIfr(idFila, strPlazo, strFlujo); //Movil y otros
							}
							else
							{
								LlenarPlanIfr(idFila, strPlazo, strFlujo);
							}
						}
					}
					else
						LlenarPlanIfr(idFila, strPlazo, strFlujo);
				}
				else
				{
					asignarPlan(idFila, '');
					if (strTienePaquete == 'S')
						asignarPaquete(idFila, '');
				}
				var plazoSeleccionado = getValue('ddlPlazo' + idFila); 
				parent.setValue('hidPlazoAcuerdo', plazoSeleccionado);
			}
*/
//fin gaa20150504
			function LlenarSolucionIfr(idFila, strPlazo)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strPlazo=' + strPlazo;
				url += '&strMetodo=' + 'LlenarSolucion';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function asignarSolucion(idFila, strValor)
			{
				strValor = validarSolucionFijo(strValor);
				llenarDatosCombo(document.getElementById('ddlSolucion' + idFila), strValor, true);
			}

			function LlenarPaqueteIfr(idFila, strPlazo)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strPlazo=' + strPlazo;
				url += '&strFlujo=' + strFlujo;
				url += '&strTipoProducto=' + getValue('ddlTipoProducto');
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&strMetodo=' + 'LlenarPaquete';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarPlanIfr(idFila, strPlazo, strFlujo)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strPlazo=' + strPlazo;
				url += '&strFlujo=' + strFlujo;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&nroDoc=' + parent.getValue('txtNroDoc');
				url += '&strCampana=' + document.getElementById('ddlCampana' + idFila).value;
				//Inicio Plan No Vigente
				url += '&strMantenerPlan=' + parent.getValue('hidMantenerPlan');
				url += '&strCodPlanNoVigente=' + parent.getValue('hidCodPlanNoVigente');
				url += '&strIdPlanVig=' + parent.getValue('hidIdPlanVig');
				url += '&strplanDesNoVig=' + parent.getValue('hidplanDesNoVig');
				//Fin Plan No Vigente
				//inicio 24/11/2015
				url += '&strGrupoProducto=' + parent.getValue('ddlGProducto');
				//fin 24/11/2015
				//gaa20161020
				if (getValue('hidCodigoTipoProductoActual') == codTipoProdMovil)
				{
					if (document.getElementById('tdFamiliaPlanMovil').style.display != 'none')
						url += '&strFamiliaPlan=' + document.getElementById('ddlFamiliaPlan' + idFila).value;
				}
				//fin gaa20161020
				url += '&strMetodo=' + 'LlenarPlan';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarPaquetePlanIfr(idFila, strPlazo, strFlujo)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strPlazo=' + strPlazo;
				url += '&strFlujo=' + strFlujo;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
//gaa20170828
				url += '&strNroDocumento=' + parent.getValue('txtNroDoc');
				url += '&strCampana=' + document.getElementById('ddlCampana' + idFila).value;
//fin gaa20170828
				url += '&strMetodo=' + 'LlenarPaquetePlan';

				self.frames['iframeAuxiliar'].location.replace(url);
			}
//gaa20161020
			function cambiarFamiliaPlan(strValor, idFila) {
				var strPlazo = document.getElementById('ddlPlazo' + idFila).value;
				var strFlujo = flujoAlta;
				if (parent.getValue('hidTienePortabilidad') == 'S')
					strFlujo = flujoPortabilidad;

				LlenarPlanIfr(idFila, strPlazo, strFlujo);
			}

			function LlenarFamiliaPlanIfr(idFila, strPlazo) {
				cargarImagenEsperando();

				var strFlujo = flujoAlta;
				if (parent.getValue('hidTienePortabilidad') == 'S')
					strFlujo = flujoPortabilidad;

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strPlazo=' + strPlazo;
				url += '&strFlujo=' + strFlujo;
				url += '&strTipoProducto=' + getValue('hidCodigoTipoProductoActual');
				url += '&strTipoDocumento=' + parent.getValue('ddlTipoDocumento');
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strCasoEspecial=' + parent.getValue('ddlCasoEspecial');
				url += '&strRiesgo=' + parent.getValue('hidRiesgoDC');
				url += '&nroDoc=' + parent.getValue('txtNroDoc');
				url += '&strCampana=' + document.getElementById('ddlCampana' + idFila).value;
				url += '&strMantenerPlan=' + parent.getValue('hidMantenerPlan');
				url += '&strCodPlanNoVigente=' + parent.getValue('hidCodPlanNoVigente');
				url += '&strIdPlanVig=' + parent.getValue('hidIdPlanVig');
				url += '&strplanDesNoVig=' + parent.getValue('hidplanDesNoVig');
				url += '&strGrupoProducto=' + parent.getValue('ddlGProducto');
				url += '&strTipoModalidadVenta=' + parent.getValue('ddlModalidad');
				url += '&strMetodo=' + "LlenarFamiliaPlan";

				self.frames['iframeAuxiliar'].location.replace(url);
			}
			
			function asignarFamiliaPlan(idFila, strValor) {
				var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
				var arrValor = strValor.split('¬');

				llenarDatosCombo(ddlFamiliaPlan, arrValor[0], false);

				ddlFamiliaPlan.value = '<%= ConfigurationSettings.AppSettings("FamiliaPlanxDefecto") %>';

				asignarPlan(idFila, arrValor[1]);

				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);

				if (ddlPlazo.disabled && ddlPlazo.value == '') {
					ddlPlazo.value = getValue('hidPlazoActual').split('_')[0];
				}
			}
//fin gaa20161020
//gaa20150504
/*
			function cambiarCampana(idFila, strValor)
			{
				if (getValue('hidCodigoTipoProductoActual') == codTipoProdDTH)
				{
					LlenarPlanDthIfr(idFila, strValor)

					if (strValor.length == 0)
					{
						llenarDatosCombo(document.getElementById('ddlPlan' + idFila), '', true);

						var ddlPlazo = document.getElementById('ddlPlazo' + idFila);

						if (!ddlPlazo.disabled)
							ddlPlazo.value = '';

						setValue('txtCFPlanServicio' + idFila, '0');
						setValue('txtCFTotMensual' + idFila, '0');
						inicializarEquipo(idFila);
						llenarDatosCombo1(document.getElementById('divListaEquipo' + idFila), '', idFila, 'Equipo', false);
					}

					return;
				}

				cerrarCuota();
				inicializarEquipo(idFila);
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var strPlan = getValor(ddlPlan.value, 2);

				if (strValor.length > 0)
				{
					if (getValue('hidCodigoTipoProductoActual') != codTipoProdDTH)
						LlenarMaterialIfr(idFila, strValor, strPlan);
				}
				else
					asignarCampanasMateriales(idFila, strValor, '');
			}
*/
//fin gaa20150504
			function LlenarPlanDthIfr(idFila, strCampana)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strCampana=' + strCampana;
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strMetodo=' + 'LlenarPlanDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarMaterialIfr(idFila, strCampana, strPlan)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strCampana=' + strCampana;
				url += '&strPlan=' + strPlan;
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&nroDoc=' + parent.getValue('txtNroDoc');
				url += '&strOrgVenta=' + parent.getValue('hidOrgVenta');
				url += '&strCentro=' + parent.getValue('hidCentro');
				url += '&strMetodo=' + 'LlenarMaterial';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function LlenarKitDthIfr(idFila)
			{
				cargarImagenEsperando();

				var strPlazo = document.getElementById('ddlPlazo' + idFila).value;
				var strCampana = document.getElementById('ddlCampana' + idFila).value;
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strCampana=' + strCampana;
				url += '&strPlazo=' + strPlazo;
				url += '&strMetodo=' + 'LlenarKitDTH';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function asignarCampanasMateriales(idFila, strCampCod, strMateriales)
			{
				llenarMaterial(idFila, strMateriales);
				asignarCampanaPaquete(idFila, strCampCod);
			}

			function seleccionarPlazo(idFila)
			{
				var booExiste = false;
				var strPlazoActual = document.getElementById('hidPlazoActual').value;
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strPlazoCodigo = '';

				if (strPlazoActual.length == 0)
					return;

				for (var i = 0; i < ddlPlazo.options.length; i++)
				{
					strPlazoCodigo = getValor(strPlazoActual, 0);

					if (ddlPlazo.options[i].value == strPlazoCodigo)
					{
						booExiste = true;
						break;
					}
				}

				if (!booExiste)
				{
					alert('No existe el plazo para el plan seleccionado');
					ddlPlazo.value = '';
					document.getElementById('ddlPlan' + idFila).value = '';
				}
				else
					ddlPlazo.value = strPlazoCodigo;
			}

			function cambiarEquipo(ddlEquipo, idFila)
			{
				cerrarCuota();
				borrarCuota(idFila);
				var strEquipo = ddlEquipo.value;
				if (strEquipo.length == 0)
				{
					inicializarEquipo(idFila);
					return;
				}

				var strPlan = document.getElementById('ddlPlan' + idFila).value;
				strPlan = getValor(strPlan, 0);
				var strPlazo = document.getElementById('ddlPlazo' + idFila).value;
				var strCampana = document.getElementById('ddlCampana' + idFila).value;

				if (strPlan.length == 0 || strPlazo.length == 0 || strCampana.length == 0)
				{
					alert('Debe seleccionar el plan, plazo y campaña antes que el equipo')
					ddlEquipo.value = '';
					return;
				}

				LlenarEquipoPrecioIfr(idFila, strPlan, strPlazo, strCampana, strEquipo);
			}

			function LlenarEquipoPrecioIfr(idFila, strPlanSap, strPlazo, strCampana, strEquipo)
			{
				cargarImagenEsperando();

				var strCuota = '';
				if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota) {
					var arrCuota = obtenerCuotaValores(idFila);
					if (arrCuota != null) {
						strCuota = arrCuota[0].split('_')[0];
					}
				}	
				
				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strOficina=' + parent.getValue('hidOficina');
				url += '&strOferta=' + parent.getValue('ddlOferta');
				url += '&strPlazo=' + strPlazo;
				url += '&strPlanSap=' + strPlanSap;
				url += '&strCampana=' + strCampana;
				url += '&strMaterial=' + strEquipo;
				url += '&strCanal=' + parent.getValue('hidCanalSap');
				url += '&strOrgVenta=' + parent.getValue('hidOrgVenta');
				url += '&strTipoDocVenta=' + parent.getValue('hidTipoDocVentaSap');
				url += '&strTipoModalidadVenta=' + parent.getValue('ddlModalidad'); 
				url += '&strTipoOficina=' + parent.getValue('hidOficinaActual').split(',')[2];
				url += '&strCuota=' + strCuota;
				url += '&strMetodo=' + "LlenarEquipoPrecio";

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function asignarPrecio(idFila, strValor) {
				if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota)
					asignarEquipoPrecioCuota(idFila, strValor);
				else
					asignarEquipoPrecio(idFila, strValor);
			}
        
			function asignarEquipoPrecio(idFila, strValor)
			{
				var cfPlanServicio = getValue('txtCFPlanServicio' + idFila);

				if (strValor == 0)
				{
					var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
					if (codigoTipoProducto != codTipoProdDTH)
						inicializarEquipo(idFila);
					else
					{
						document.getElementById('txtPrecioInst' + idFila).value = 0;
						document.getElementById('txtCFMenAlqKit' + idFila).value = 0;
						document.getElementById('txtCFTotMensual' + idFila).value = (parseFloat(cfPlanServicio)).toFixed(2);
					}
				}
				else
				{
					var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
					var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);

					if (hidListaPrecio != null)
					{
						hidListaPrecio.value = strValor;
						txtEquipoPrecio.value = strValor.split('_')[0];
						//Asignar Precio de Venta y Precio de Lista
						parent.document.getElementById('hidPrecioVentaEv').value = strValor.split('_')[0];
						parent.document.getElementById('hidPrecioListaEv').value = strValor.split('_')[3];
					}
					else
					{
						if (strValor.indexOf('_') > -1)
						{
							var arrValor = strValor.split('_');
							var cfMenAlqKit = arrValor[1];

							document.getElementById('txtPrecioInst' + idFila).value = arrValor[0];
							document.getElementById('txtCFMenAlqKit' + idFila).value = cfMenAlqKit;
							document.getElementById('txtCFTotMensual' + idFila).value = (parseFloat(cfPlanServicio) + parseFloat(cfMenAlqKit)).toFixed(2);
						}
					}
				}
			}

			function asignarEquipoPrecioCuota(idFila, strValor) {
				
				//INC000000715147 - INICIO
				
				var cfPlanServicio = getValue('txtCFPlanServicio' + idFila);

				if (strValor == 0)
				{
					var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
					if (codigoTipoProducto != codTipoProdDTH)
						inicializarEquipo(idFila);
					else
					{
						document.getElementById('txtPrecioInst' + idFila).value = 0;
						document.getElementById('txtCFMenAlqKit' + idFila).value = 0;
						document.getElementById('txtCFTotMensual' + idFila).value = (parseFloat(cfPlanServicio)).toFixed(2);
					}
				}
				else
				{
					var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
					var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);

					if (hidListaPrecio != null)
					{
						hidListaPrecio.value = strValor;
						txtEquipoPrecio.value = strValor.split('_')[0];
						//Asignar Precio de Venta y Precio de Lista
						parent.document.getElementById('hidPrecioVentaEv').value = strValor.split('_')[0];
						parent.document.getElementById('hidPrecioListaEv').value = strValor.split('_')[3];
					}
					else
					{
						if (strValor.indexOf('_') > -1)
						{
							var arrValor = strValor.split('_');
							var cfMenAlqKit = arrValor[1];

							document.getElementById('txtPrecioInst' + idFila).value = arrValor[0];
							document.getElementById('txtCFMenAlqKit' + idFila).value = cfMenAlqKit;
							document.getElementById('txtCFTotMensual' + idFila).value = (parseFloat(cfPlanServicio) + parseFloat(cfMenAlqKit)).toFixed(2);
						}
					}
				}
                                //INC000000715147 - INICIO
				document.getElementById('hidListaPrecio' + idFila).value = strValor;
			}
        
			function asignarCampanaPaquete(idFila, strValor)
			{
				var strGrupoPaquete = document.getElementById('hidGrupoPaquete').value;
				var strVB = '[' + idFila + ']';
				var intPosFin = strGrupoPaquete.indexOf(strVB);
				var intPosIni;
				var intPosFin;
				var arrGrupo;
				var idFila1;

				asignarMaterial1(idFila);
			}

			function agregarFila1(booVeriConf)
			{
				//inicio plan no vigente 30102015
				var MantenerPlan = parent.document.getElementById('hidMantenerPlan').value;
				document.getElementById('hidMantenerPlan').value  = MantenerPlan;
				//fin plan no vigente 30102015
				if (agregarFila(booVeriConf) != false)
				{
					var idFila = getValue('hidTotalLineas');
					cambiarTipoProducto(idFila);
					
					//Inicio Modificacion Plan No Vigente
					document.getElementById('ddlPlazo'+idFila).selectedIndex = 0;
					//Fin Modificacion Plan No Vigente
					
				}
			}

			function eliminarItem(idx)
			{
				var strCadenaDetalle = getValue('hidCadenaDetalle');
				var arrCadenaDetalle = strCadenaDetalle.split('|');

				for (var i=0; i<arrCadenaDetalle.length; i++)
				{
					var id = arrCadenaDetalle[i].split(';')[0];
					if (id == idx)
					{
						arrCadenaDetalle.splice(i, 1);
						setValue('hidCadenaDetalle', arrCadenaDetalle.join('|'));
						break;
					}
				}
			}

			function eliminarItem1(strCadenaDetalle, idx) {
				var arrCadenaDetalle = strCadenaDetalle.split('|');

				for (var i = 0; i < arrCadenaDetalle.length; i++) {
					var id = arrCadenaDetalle[i].split(';')[0];
					if (id == idx) {
						arrCadenaDetalle.splice(i, 1);
						strCadenaDetalle = arrCadenaDetalle.join('|');
						break;
					}
				}
				return strCadenaDetalle;
			}
	        
			function planesxCantidad(strPlanes)
			{
				var plan;
				var cuota;
				var monto_cuota;
				var arrPlanes = strPlanes.split('|');
				var nroPlanes = 0;
				var strCadena = '';
				var planBscs;
				var plazo;

				for (var i = 0; i < arrPlanes.length; i++)
				{
					nroPlanes = 0;
					if (arrPlanes[i] != '')
					{
						for (var ii = 0; ii < arrPlanes.length; ii++)
						{
							if (arrPlanes[i].split(';')[1] == arrPlanes[ii].split(';')[1])
							{
								nroPlanes += parseInt(1);
							}
						}
						plan = arrPlanes[i].split(';')[1];
						planBscs = arrPlanes[i].split(';')[2];
						plazo = arrPlanes[i].split(';')[3];
						cuota = arrPlanes[i].split(';')[4];
						monto_cuota = arrPlanes[i].split(';')[5];

						if (strCadena == '')
							strCadena = nroPlanes + ';' + plan + ';' + planBscs + ';' + plazo + ';' + cuota + ';' + monto_cuota;
						else
							strCadena = strCadena + '|' + nroPlanes + ';' + plan + ';' + planBscs + ';' + plazo + ';' + cuota + ';' + monto_cuota;
					}
				}
				return strCadena;
			}

			function planesEvaluados(strPlanDetalle)
			{
				var idFila= '';
				var strProducto = '';
				var strPlanes = '';
				var strPlan = '';
				var strPlanBscs = '';
				var strPlazo = '';
				var strCuota = '';
				var strCuotaMonto = '';
				var arrPlanDetalle = strPlanDetalle.split('|');

				for (var i = 0; i < arrPlanDetalle.length; i++)
				{
					if (arrPlanDetalle[i] != '')
					{
						idFila = arrPlanDetalle[i].split(';')[0];
						strProducto = arrPlanDetalle[i].split(';')[1];
						strPlan = arrPlanDetalle[i].split(';')[10];
						strPlanBscs = getValor(arrPlanDetalle[i].split(';')[9], 6);
						strPlazo = arrPlanDetalle[i].split(';')[2];
						strCuota = arrPlanDetalle[i].split(';')[28];
						strCuotaMonto = arrPlanDetalle[i].split(';')[29];

						strPlanes += '|' + strProducto;
						strPlanes += ';' + strPlan;
						strPlanes += ';' + strPlanBscs;
						strPlanes += ';' + strPlazo;
						strPlanes += ';' + strCuota;
						strPlanes += ';' + strCuotaMonto;
						strPlanes += ';' + idFila;
					}
				}
				return strPlanes;
			}

			function guardarItem() {
				var strCadenaDetalle = consultarItem('');
				setValue('hidCadenaDetalle', strCadenaDetalle);
				parent.setValue('hidCadenaDetalle', getValue('hidCadenaDetalle'));

				return strCadenaDetalle;
			}

			function consultarItem(idx) {
				var tipoProducto = getValue('hidTipoProductoActual');
				var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
				var tabla = document.getElementById('tblTabla' + tipoProducto);
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var strCadena = '';
				var strPlazo = '';
				var strPlazoTexto = '';
				var strSolucion = '';
				var strSolucionTexto = '';
				var strPaquete = '';
				var strPaqueteTexto = '';
				var strAgrupaPaquete = '';
				var strPlan = '';
				var strPlanCodigo = '';
				var strPlanTexto = '';
				var strPlanGrupoTexto = '';
				var strPlanTipo = '';
				var strCargoFijo = '';
				var strTopeConsumo = '';
				var strCampana = '';
				var strCampanaTexto = '';
				var strEquipo = '';
				var strEquipoTexto = '';
				var strMontoTopeConsumo = '';
				var strCargoFijo = '';
				var strPrecioInst = '';
				var strCFMenAlqKit = '';
				var strCFTotMensual = '';
				var strListaPrecioEquipo = '';
				var strEquipoEnCuotas = '';
				var strNroCuotas = '00';
				var strPorcentajeCuotas = '100';
				var strMontoCuota = 0;
				var strPrecioLista = '';
				var strPrecioVenta = '';
				var strNroPorta = '';
				var strServicio = '';
				var strServicioTexto = '';
				var strTopeConsumo = '';
				var strTopeConsumoFijo = '';
				var strTopeConsumoTexto = '';
//gaa20161024
				var strFamiliaPlan = '';
//fin gaa20161024
				var strCadenaDetalle = getValue('hidCadenaDetalle');

				for (var i = 0; i < cont; i++) {
					fila = tabla.rows[i];

					if (codigoTipoProducto != codTipoProdDTH && codigoTipoProducto != codTipoProd3Play)
						idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
					else //ddlCampana
						idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

					strCadenaDetalle = eliminarItem1(strCadenaDetalle, idFila);

					var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
					if (ddlPlazo != null) {
						strPlazo = ddlPlazo.value;
						strPlazoTexto = obtenerTextoSeleccionado(ddlPlazo);
					}

					var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
					if (ddlPaquete != null) {
						strPaquete = ddlPaquete.value;
						strPaqueteTexto = obtenerTextoSeleccionado(ddlPaquete);
						strAgrupaPaquete = obtenerPaqueteActual(idFila);
					}

					var ddlPlan = document.getElementById('ddlPlan' + idFila);
					if (ddlPlan != null) {
						if (codigoTipoProducto == codTipoProd3Play) {
							strPlan = ddlPlan.value;
							strPlanTexto = obtenerTextoSeleccionado(ddlPlan);
							strPlanCodigo = ddlPlan.value;
						}
						else {
							strPlan = ddlPlan.value;
							strPlanTexto = obtenerTextoSeleccionado(ddlPlan);
						strPlanCodigo = getValor(ddlPlan.value, 0);
						strCargoFijo = getValor(ddlPlan.value, 1);
						strPlanGrupoTexto = getValor(ddlPlan.value, 5);
						strPlanTipo = getValor(ddlPlan.value, 3);
					}
					}

					var ddlCampana = document.getElementById('ddlCampana' + idFila);
					if (ddlCampana != null) {
						strCampana = ddlCampana.value;
						strCampanaTexto = obtenerTextoSeleccionado(ddlCampana);
					}

					if (codigoTipoProducto == codTipoProdMovil || codigoTipoProducto == codTipoProdFijo)
						strTopeConsumo = tieneTope(idFila);

					var ddlEquipo = document.getElementById('hidValorEquipo' + idFila);
					if (ddlEquipo != null)
						strEquipo = ddlEquipo.value;

					if (strEquipo != '') {
						var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
						if (txtTextoEquipo != null)
							strEquipoTexto = txtTextoEquipo.value;
					}

					var txtMontoTopeConsumo = document.getElementById('txtMontoTopeConsumo' + idFila);
					if (txtMontoTopeConsumo != null)
						strMontoTopeConsumo = txtMontoTopeConsumo.value;

					if (codigoTipoProducto == codTipoProdDTH) {
						var txtPrecioInst = document.getElementById('txtPrecioInst' + idFila);
						if (txtPrecioInst != null)
							strPrecioInst = txtPrecioInst.value;

						var txtCFMenAlqKit = document.getElementById('txtCFMenAlqKit' + idFila);
						if (txtCFMenAlqKit != null)
							strCFMenAlqKit = txtCFMenAlqKit.value;

						var txtCFTotMensual = document.getElementById('txtCFTotMensual' + idFila);
						if (txtCFTotMensual != null)
							strCFTotMensual = txtCFTotMensual.value;
					}
					else {
						var txtCargoFijo = document.getElementById('txtCFPlanServicio' + idFila);
						if (txtCargoFijo != null)
							strCFTotMensual = txtCargoFijo.value;
							//consolidado 12012015
							parent.document.getElementById('hidCargoFijoSeleccionado').value = strCFTotMensual;
							//consolidado 12012015
					}

					var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
					if (hidListaPrecio != null) {
						if (hidListaPrecio.value != '') {
							strListaPrecioEquipo = hidListaPrecio.value;
							strPrecioLista = hidListaPrecio.value.split('_')[3];
							strPrecioVenta = hidListaPrecio.value.split('_')[0];
						}
					}

					if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota) {
						var arrCuota = obtenerCuotaValores(idFila);
						if (arrCuota != null) {
							strNroCuotas = arrCuota[0].split('_')[0];
							strPorcentajeCuotas = arrCuota[1];
							strMontoCuota = arrCuota[3];
							strEquipoEnCuotas = 'S';

							strCFTotMensual = parseFloat(strCFTotMensual) + parseFloat(strMontoCuota);
						}
					}

					var txtNroPortar = document.getElementById('txtNroPortar' + idFila);
					if (txtNroPortar != null)
						strNroPorta = txtNroPortar.value;

					if (codigoTipoProducto == codTipoProd3Play) {
						var ddlServicio = document.getElementById('ddlServicio' + idFila);
						if (ddlServicio != null) {
							strServicio = ddlServicio.value;
							strServicioTexto = obtenerTextoSeleccionado(ddlServicio);
						}

						var montoEquipo = document.getElementById('hidMontoEquipo' + idFila).value;
						if (montoEquipo.length > 0) {
							strCFTotMensual = parseFloat(strCFTotMensual) + parseFloat(montoEquipo);
						}
					}

					var ddlTopeConsumo = document.getElementById('ddlTopeConsumo' + idFila);
					if (ddlTopeConsumo != null) {
						if (ddlTopeConsumo.style.display != 'none') {
							strTopeConsumoFijo = ddlTopeConsumo.value;
							strTopeConsumoTexto = obtenerTextoSeleccionado(ddlTopeConsumo);
						}
					}
//gaa20161024
					var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
					if (ddlFamiliaPlan != null) {
						if (ddlFamiliaPlan.style.display != 'none') {
							strFamiliaPlan = ddlFamiliaPlan.value;
						}
					}
//fin gaa20161024
					if (idx == '' || idx == idFila) {
					strCadena += idFila + ';';
					strCadena += codigoTipoProducto + ';';
					strCadena += strPlazo + ';';
					strCadena += strPlazoTexto + ';';
					strCadena += strSolucion + ';';
					strCadena += strSolucionTexto + ';';
					strCadena += strPaquete + ';';
					strCadena += strPaqueteTexto + ';';
					strCadena += strAgrupaPaquete + ';';
					strCadena += strPlan + ';';
					strCadena += strPlanCodigo + ';';
					strCadena += strPlanTexto + ';';
					strCadena += strPlanGrupoTexto + ';';
					strCadena += strPlanTipo + ';';
					strCadena += strTopeConsumo + ';';
					strCadena += strCampana + ';';
					strCadena += strCampanaTexto + ';';
					strCadena += strEquipo + ';';
					strCadena += strEquipoTexto + ';';
					strCadena += strMontoTopeConsumo + ';';
					strCadena += strCargoFijo + ';';
					strCadena += strPrecioInst + ';';
					strCadena += strCFMenAlqKit + ';';
					strCadena += strCFTotMensual + ';';
					strCadena += strListaPrecioEquipo + ';';
					strCadena += strPrecioLista + ';';
					strCadena += strPrecioVenta + ';';
					strCadena += strEquipoEnCuotas + ';';
					strCadena += strNroCuotas + ';';
					strCadena += strPorcentajeCuotas + ';';
						strCadena += strNroPorta + ';';
						strCadena += strMontoCuota + ';';
						strCadena += strServicio + ';';
						strCadena += strServicioTexto + ';';
						strCadena += strTopeConsumoFijo + ';';
					strCadena += strTopeConsumoTexto + ';';
//gaa20161024
                    strCadena += strFamiliaPlan + '|';
//fin gaa20161024
					}
				}

				strCadena = strCadena + strCadenaDetalle;
				return strCadena;
			}

			function obtenerPaqueteActual(idFila)
			{
				var strGrupoPaquete = getValue('hidGrupoPaquete');
				var strResultado = '';
				var intPosFin = strGrupoPaquete.indexOf('[' + idFila + ']');
				var intPosIni = -1;
				var nroPos;

				if (intPosFin > -1)
					intPosIni = strGrupoPaquete.substring(0, intPosFin).lastIndexOf('{');

				if (intPosIni > -1)
				{
					nroPos = strGrupoPaquete.substring(intPosFin).indexOf('}');
					strResultado = strGrupoPaquete.substring(intPosIni, intPosFin + nroPos + 1);
				}

				return strResultado;
			}

			function tieneTope(idFila)
			{
				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				var posIniPS = strPlanServicio.indexOf('*ID*' + idFila);
				var posFinPS = 0;
				var servicio = "";

				if (posIniPS > -1)
				{
					posFinPS = strPlanServicio.substring(posIniPS + 4).indexOf('*ID*') + 4;

					if (posFinPS == 3)
						posFinPS = strPlanServicio.length;
					else
						posFinPS += posIniPS;

					var arrPS = strPlanServicio.substring(posIniPS, posFinPS).split('|');

					for (var i = 1; i < arrPS.length; i++)
					{
						var arrCodDes = arrPS[i].split(';');
						var codServicio = arrCodDes[0].split('_')[3];
						if (codServicio == topeConsumoCero || codServicio == topeConsumoSinCF || codServicio == topeConsumoAuto)
						{
							servicio = codServicio;
							break;
						}
					}
				}

				return servicio;
			}

			function obtenerCuotaValores(idFila, strCadenaCuota)
			{
				var strCuota = document.getElementById('hidCuota').value;

				if (strCadenaCuota != null)
					strCuota = strCadenaCuota;

				var strValIni = '|*ID' + idFila + '*';
				var strValFin = '*/ID' + idFila + '*';
				var arrCuota;
				var intPosIni = strCuota.indexOf(strValIni);
				var intPosFin;

				if (intPosIni > -1)
				{
					intPosIni += strValIni.length;
					intPosFin = strCuota.indexOf(strValFin);

					strCuota = strCuota.substring(intPosIni, intPosFin);
					arrCuota = strCuota.split(';')

					return arrCuota;
				}
			}

			function mostrarSecPendiente1(pstrValor, tiposProducto)
			{
				var idFila;
				var fltMontoServicios = 0;
				var fltMontoCuota = 0;
				var strServicioFila;

				if (pstrValor.length == 0)
					return;

				if (pstrValor.indexOf('¬') > -1)
				{
					setValue('hidListaTipoProducto', tiposProducto);

					var arrValores = pstrValor.split('¬');
					var arrCadena;
					var strCuota = '';
					var strServicio = '';
					var strPromocion = '';
					var hidTienePaquete = document.getElementById('hidTienePaquete');
					var strCuotaActual = '';

					for (var i = 1; i < arrValores.length; i++)
					{
						arrCadena = arrValores[i].split('©');

						strCuotaActual = arrCadena[15];
						strServicioFila = arrCadena[24];
						strServicio += strServicioFila;
						strPromocion += arrCadena[25];

						idFila = arrCadena[0];
						//fltMontoServicios = calcularMontoServicio(strServicio);
						fltMontoServicios = calcularMontoServicio(strServicioFila);

						if (strCuotaActual.length > 0)
						{
//gaa20130520
							//fltMontoCuota = strCuota.split('*')[2].split(';')[3];
							if (strCuota.indexOf(strCuotaActual) < 0)
								strCuota += strCuotaActual;

							fltMontoCuota = obtenerCuotaValores(idFila, strCuota)[3];
//fin gaa20130520
						}
						if (isNaN(fltMontoCuota))
							fltMontoCuota = 0;

						if (parent.getValue('ddlOferta') == '<%= ConfigurationSettings.AppSettings("TipoProductoBusiness") %>')
						{
							mostrarColumna(columnaPaquete, true);
							document.all('hidTienePaquete').value = 'S';
						}
						else
						{
							mostrarColumna(columnaPaquete, false);
							document.all('hidTienePaquete').value = 'N';
						}
//gaa20161027
						agregarFilaDatos(idFila, arrCadena[1], arrCadena[2], arrCadena[3], arrCadena[4], arrCadena[5], arrCadena[6],
							arrCadena[7], arrCadena[8], arrCadena[9], arrCadena[10], arrCadena[11], arrCadena[12], arrCadena[13], 
                                                        arrCadena[14], arrCadena[16], arrCadena[17], arrCadena[18], arrCadena[19], arrCadena[20], arrCadena[21], 
                                                        arrCadena[22], arrCadena[23], fltMontoServicios, fltMontoCuota, tiposProducto, arrCadena[26]);
//fin gaa20161027
						document.getElementById('hidTotalLineas').value = arrCadena[0];
					}

					setValue('hidCuota', strCuota);
					setValue('hidPlanServicio', strServicio);
					setValue('hidPromocion', strPromocion);

					calcularCFxProducto();

					traerPlazo('S');
				}
				else
					alert(pstrValor);
			}

			function calcularMontoServicio(strCadenaServicios)
			{
				var arrServicios = strCadenaServicios.split('|');
				var arrServicio;
				var total = 0;

				for (var i = 1; i < arrServicios.length; i++)
				{
					arrServicio = arrServicios[i].split('_');
					total += parseFloat(arrServicio[4]);
				}

				return total.toFixed(2);
			}
//gaa20161027
			function agregarFilaDatos(idFila, codPlazo, plazDescr, codPaqu, paquDescr, codPlan, planDescr, cargFijo, montTope, codCamp, campDescr, codEqui, equiDescr, equiPrec, nroPort, listaPrecio, codTipoProducto, tipoProducto, codSolu, soluDescr, costoInstDTH, CFAlqKit, nroSec, montoServicios, montoCuota, tiposProducto, strFamilia)
			{
				var codPlan1 = codPlan.split('_')[2];
				var strTienePaquete = document.getElementById('hidTienePaquete').value;
				var strTienePortab = parent.document.getElementById('hidTienePortabilidad').value;
				document.getElementById('hidPlazoActual').value = codPlazo + '_' + plazDescr;
				var newRow;

				switch (codTipoProducto)
				{
					case codTipoProdMovil: tipoProducto = 'Movil'; break;
					case codTipoProdFijo: tipoProducto = 'Fijo'; break;
					case codTipoProdBAM: tipoProducto = 'BAM'; break;
					case codTipoProdDTH: tipoProducto = 'DTH'; break;
					case codTipoProd3Play: tipoProducto = 'HFC'; break;
				}

				newRow = document.all('tblTabla' + tipoProducto).insertRow();

				oCell = newRow.insertCell();
				oCell.style.width = '20px';
				oCell.innerHTML = "<input type='hidden' id='hidNroSec" + idFila + "' name='hidNroSec" + idFila + "' value='" + nroSec + "' />";

				oCell = newRow.insertCell();
				oCell.style.width = '20px';
				oCell.innerHTML = "<img src='../../../images/rechazar.gif' border='0' style='cursor:hand' alt='Eliminar Fila' onclick='eliminarFilaTotal(this, " + idFila +  ", true);' />";

				if (codTipoProducto != codTipoProdDTH)
				{

					oCell = newRow.insertCell();
					oCell.style.width = '145px';
					oCell.align = 'center';
					oCell.innerHTML = "<select disabled style='width:100%' class='clsSelectEnable0' name='ddlPlazo"  + idFila + "' id='ddlPlazo"  + idFila +  "' onchange='cambiarPlazo(this.value, "  + idFila +  ");'><option>SELECCIONE...</option></select>";

					if (codTipoProducto == codTipoProd3Play)
					{
						oCell = newRow.insertCell();
						oCell.style.width = '282px';
						oCell.innerHTML = "<select disabled style='width:100%' class='clsSelectEnable0' name='ddlSolucion" + idFila + "' id='ddlSolucion" + idFila + "' onchange='cambiarSolucion(this.value, " + idFila + ");'><option>SELECCIONE...</option></select>";
					}

					if (strTienePaquete == 'S' || codTipoProducto == codTipoProd3Play)
					{
						var oCell = newRow.insertCell();

						if (codTipoProducto == codTipoProd3Play)
							oCell.style.width = '312px';
						else
							oCell.style.width = '202px';

						oCell.align = 'center';
						oCell.innerHTML ="<select disabled style='width:100%' class='clsSelectEnable0' name='ddlPaquete" + idFila + "' id='ddlPaquete"  + idFila + "' onchange='cambiarPaquete(this.value, " + idFila + ");'><option>SELECCIONE...</option></select>";
					}
//gaa20161027: Si es masivo y movil
					if (codTipoProducto == codTipoProdMovil && familiaFlag == '1') {
						oCell = newRow.insertCell();
						oCell.style.width = '152px';
						oCell.innerHTML = "<select" + disabled + " style='width:100%' class='clsSelectEnable0' name='ddlFamiliaPlan" + idFila + "' id='ddlFamiliaPlan" + idFila + "'onchange='cambiarFamiliaPlan(this.value, " + idFila + ");'></select>";
					}
//fin gaa20161027
					var oCell = newRow.insertCell();
					oCell.style.width = '152px';
					oCell.innerHTML = "<select disabled style='width:100%' class='clsSelectEnable0' name='ddlPlan" + idFila + "' id='ddlPlan" + idFila + "' onchange='cambiarPlan(this.value, "  + idFila +  ");'><option>SELECCIONE...</option></select>";
					oCell.align = 'center';

					setValue('hidCodPlan1', codPlan1);

					oCell = newRow.insertCell();
					oCell.style.width = '30px';
					oCell.innerHTML = "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicioGuardado(" + idFila + ");' />";
					oCell.align = 'center';

					oCell = newRow.insertCell();
					oCell.style.width = '45px';
					oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFPlanServicio" + idFila +  "' id='txtCFPlanServicio" + idFila + "' /><input type='hidden' id='hidMontoServicios" + idFila + "' name='hidMontoServicios" + idFila + "' value='" + montoServicios + "' /><input type='hidden' id='hidMontoCuota" + idFila + "' name='hidMontoCuota" + idFila + "' value='" + montoCuota + "' />";
					oCell.align = 'center';

					if (codTipoProducto != codTipoProd3Play)
					{
						if (codTipoProducto == codTipoProdMovil)
						{
							oCell = newRow.insertCell();
							oCell.style.width = '52px';
							oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtMontoTopeConsumo" + idFila + "' id='txtMontoTopeConsumo"  + idFila +  "' />" ;
							oCell.align = 'center';
						}

						oCell = newRow.insertCell();
						oCell.style.width = '185px';
						oCell.innerHTML = "<select disabled style='width:100%' class='clsSelectEnable0' name='ddlCampana"  + idFila + "' id='ddlCampana"  + idFila + "' onchange='cambiarCampana("  + idFila + ");'><option>SELECCIONE...</option></select>";
						oCell.align = 'center';

						oCell = newRow.insertCell();
						oCell.style.width = '200px';
						oCell.innerHTML = "<input type='hidden' id='hidValorEquipo" + idFila + "' name='hidValorEquipo" + idFila + "' /><input style='width:100%' disabled type='text' id='txtTextoEquipo" + idFila + "' name='txtTextoEquipo" + idFila + "' class='clsSelectEnable0' />";
						oCell.align = 'center';

						oCell = newRow.insertCell();
						oCell.style.width = '62px';
						oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtEquipoPrecio" + idFila + "' id='txtEquipoPrecio" + idFila + "' /><input id='hidListaPrecio" + idFila + "' type='hidden' name='hidListaPrecio" + idFila + "' />" ;
						oCell.align = 'center';

						if (getValue('hidTieneCuotas') == 'S')
						{
							oCell = newRow.insertCell();
							oCell.style.width = '37px';
							oCell.align = 'center';

							if (codTipoProducto == codTipoProdDTH || codTipoProducto == codTipoProd3Play)
								oCell.innerHTML = "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand;display:none' alt='Ver Cuotas' onclick='mostrarCuotaGuardada("  + idFila + ");' id='imgVerCuota" + idFila + "' name='imgVerCuota" + idFila + "' />";
							else
								oCell.innerHTML = "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Cuotas' onclick='mostrarCuotaGuardada("  + idFila + ");' id='imgVerCuota" + idFila + "' name='imgVerCuota" + idFila + "' />";
						}

						if (strTienePortab == 'S')
						{
							oCell = newRow.insertCell();
							oCell.style.width = '60px';
							oCell.innerHTML = "<input readonly style='width:100%' class='clsInputEnable' maxlength='9' name='txtNroPortar" + idFila + "' id='txtNroPortar" + idFila + "' onkeypress='eventoSoloNumerosEnteros();' />";
							oCell.align = 'center';
						}
					}
					else
					{
						oCell = newRow.insertCell();
						oCell.style.width = '40px';
						oCell.align = 'center';
						oCell.innerHTML = "<img name='imgDirInst" + idFila + "' id='imgDirInst" + idFila + "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand' alt='Dir. Inst.' onclick='mostrarDirInst(" + idFila + ");' />";

						oCell = newRow.insertCell();
						oCell.style.width = '40px';
						oCell.align = 'center';
						oCell.innerHTML = "<img name='imgDetOfert" + idFila + "' id='imgDetOfert" + idFila + "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand' alt='Det. Ofert.' onclick='mostrarDetOfert(" + idFila + ");' />";
					}
				}
				else
				{
					oCell = newRow.insertCell();
					oCell.style.width = '185px';
					oCell.innerHTML = "<select style='width:100%' class='clsSelectEnable0' name='ddlCampana" + idFila + "' id='ddlCampana" + idFila + "' onchange='cambiarCampana(" + idFila + ", this.value);'><option value=''>SELECCIONE...</option></select>";

					oCell = newRow.insertCell();
					oCell.style.width = '200px';
					oCell.innerHTML = "<select style='width:100%' class='clsSelectEnable0' name='ddlPlan" + idFila + "' id='ddlPlan" + idFila + "' onchange='cambiarPlan(this.value, " + idFila + ");'><option>SELECCIONE...</option></select>";

					oCell = newRow.insertCell();
					oCell.style.width = '30px';
					oCell.align = 'center';
					oCell.innerHTML = "<img src = '../../../images/abrir.gif' border='0' style='cursor:hand' alt='Ver Servicios' onclick='mostrarServicio(" + idFila + ");' />";

					oCell = newRow.insertCell();
					oCell.style.width = '150px';
					oCell.innerHTML = "<select style='width:100%' class='clsSelectEnable0' name='ddlPlazo" + idFila + "' id='ddlPlazo" + idFila + "' onchange='cambiarPlazo(this.value, " + idFila + ");'><option>SELECCIONE...</option></select>";

					oCell = newRow.insertCell();
					oCell.style.width = '200px';
					oCell.innerHTML = "<input type='hidden' id='hidValorEquipo" + idFila + "' name='hidValorEquipo" + idFila + "' /><input style='width:100%' disabled type='text' id='txtTextoEquipo" + idFila + "' name='txtTextoEquipo" + idFila + "' class='clsSelectEnable0' />";

					oCell = newRow.insertCell();
					oCell.style.width = '55px';
					oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtPrecioInst" + idFila + "' id='txtPrecioInst" + idFila + "' />";

					oCell = newRow.insertCell();
					oCell.style.width = '55px';
					oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFPlanServicio" + idFila + "' id='txtCFPlanServicio" + idFila + "' /><input type='hidden' id='hidMontoServicios" + idFila + "' name='hidMontoServicios" + idFila + "' />";

					oCell = newRow.insertCell();
					oCell.style.width = '50px';
					oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFMenAlqKit" + idFila + "' id='txtCFMenAlqKit" + idFila + "' />";

					oCell = newRow.insertCell();
					oCell.style.width = '50px';
					oCell.innerHTML = "<input style='width:100%' style='text-align:right' readonly class='clsInputDisable' name='txtCFTotMensual" + idFila + "' id='txtCFTotMensual" + idFila + "' />";

					oCell = newRow.insertCell();
					oCell.style.width = '40px';
					oCell.align = 'center';
					oCell.innerHTML = "<img name='imgDirInst" + idFila + "' id='imgDirInst" + idFila + "' src='../../../images/ico_lupa.gif' border='0' style='cursor:hand' alt='Dir. Inst.' onclick='mostrarDirInst(" + idFila + ");' />";
				}
//gaa20161027
				asignarValoresClient(idFila, codPlazo, plazDescr, codPaqu, paquDescr, codPlan, planDescr, cargFijo, montTope, codCamp, campDescr, codEqui, equiDescr, equiPrec, nroPort, listaPrecio, codTipoProducto, tipoProducto, codSolu, soluDescr, costoInstDTH, CFAlqKit, tiposProducto, strFamilia);
//fin gaa20161027:
			}

			function asignarValoresAdicionales(pstrGrupoPaq, pstrDdl, pstrCuotaActual)
			{
				setValue('hidGrupoPaquete', pstrGrupoPaq);
				llenarDatosCombo(document.getElementById('ddlNroCuotas'), pstrDdl, true);
				setValue('hidNroCuotaActual', pstrCuotaActual);
			}

			function verificarPlazo(strTipoProducto)
			{
				var tabla = document.getElementById('tblTabla' + strTipoProducto);
				var cont = tabla.rows.length;
				var ddlPlazo;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];

					if (strTipoProducto != 'DTH')
						ddlPlazo = fila.cells[3].getElementsByTagName("select")[0];
					else
						ddlPlazo = fila.cells[5].getElementsByTagName("select")[0];

					if (ddlPlazo.value.length > 0)
						return '|' + ddlPlazo.value + ';' + obtenerTextoSeleccionado(ddlPlazo);
				}

				return '';
			}

			function calcularCFTotal()
			{
				var tabla = document.getElementById('tblTablaMovil');
				var cont = tabla.rows.length;

				var nCell = 12;
				var suma = 0;
				var nro;

				if (document.getElementById('hidTienePaquete').value == 'S')
					nCell++;
				else {
//gaa20161020
					if (familiaFlag == '1')
						nCell++;
				}
//fin gaa20161020
				if (getValue('hidTieneCuotas') == 'S')
					nCell++;

				if (parent.getValue('hidTienePortabilidad') == 'S')
					nCell++;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					nro = fila.cells[nCell].getElementsByTagName("input")[0].value;
					if (nro.length == 0)
						nro = 0;
					suma += parseFloat(nro);
				}

				document.getElementById('txtCFTotal').value = suma.toFixed(2);
			}

			function habilitarServicio(hab)
			{
				document.getElementById('btnAgregarServicio').disabled = hab;
				document.getElementById('btnQuitarServicio').disabled = hab;
				document.getElementById('btnResetServicios').disabled = hab;

				if (hab)
					document.getElementById('btnCerrarServicios').value = 'Cerrar';
				else
					document.getElementById('btnCerrarServicios').value = 'Cerrar y Guardar';
			}

			function borrarGrupoServicio(idFila)
			{
				var hidPlanServicioNoGrupo = document.getElementById('hidPlanServicioNoGrupo');
				var strPSNG = hidPlanServicioNoGrupo.value;
				var intPosIni;
				var intPosFin;
				var intPosFin1;

				intPosIni = strPSNG.indexOf('{ID' + idFila + '}');
				intPosFin = strPSNG.indexOf('{/ID' + idFila);
				intPosFin1 = strPSNG.substring(intPosFin).indexOf('}');
				intPosFin = intPosFin + intPosFin1 + 1;

				if (intPosIni > -1)
					hidPlanServicioNoGrupo.value = strPSNG.replace(strPSNG.substring(intPosIni, intPosFin), '');
			}

			function guardarGrupoTemp(strValor)
			{
				var hidPlanServicioNGTemp = document.getElementById('hidPlanServicioNGTemp');
				hidPlanServicioNGTemp.value = strValor;
			}

			function asignarGrupoTemp(idFila)
			{
				var strPlanServicioNoGrupo = document.getElementById('hidPlanServicioNoGrupo').value;
				var hidPlanServicioNGTemp = document.getElementById('hidPlanServicioNGTemp');
				var intPosIni = strPlanServicioNoGrupo.indexOf('{ID' + idFila + '}');
				var intPosFin1 = strPlanServicioNoGrupo.indexOf('{/ID' + idFila + '}');
				var intPosFin = strPlanServicioNoGrupo.substring(intPosFin1).indexOf('}') + intPosFin1 + 1;

				hidPlanServicioNGTemp.value = strPlanServicioNoGrupo.substring(intPosIni, intPosFin);
			}

			function guardarGrupo(idFila)
			{
				var hidPlanServicioNoGrupo = document.getElementById('hidPlanServicioNoGrupo');
				var strPlanServicioNGTemp = document.getElementById('hidPlanServicioNGTemp').value;

				hidPlanServicioNoGrupo.value += strPlanServicioNGTemp
			}

			function agregarGrupo(idFila, esNuevo)
			{
				if (esNuevo)
				{
					var linea = document.getElementById('hidLineaActual').value;
					if (idFila < 0)
						idFila = linea;

					var hidPlanServicioNoGrupo = document.getElementById('hidPlanServicioNoGrupo');
					var lbxSD = document.getElementById('lbxServiciosDisponibles1');
					var lbxSA = document.getElementById('lbxServiciosAgregados1');
					var strGrpSA;
					var strGrpSD;
					var arrCodSA;
					var arrCodSD;
					var strPSNG = hidPlanServicioNoGrupo.value;
					var strGrupoTotal = '{ID' + idFila + '}';
					var contSD = lbxSD.length;
					var contSA = lbxSA.length;

					for (var i = 0; i < contSA; i++)
					{
						arrCodSA = lbxSA.options[i].value.split('_');
						strGrpSA = arrCodSA[1];

						strGrupoTotal += '{' + strGrpSA + '}';

						for (var x = 0; x < contSD; x++)
						{
							arrCodSD = lbxSD.options[x].value.split('_');
							strGrpSD = arrCodSD[1];

							if (strGrpSA == strGrpSD && strGrpSA.length > 0)
							{
								strGrupoTotal += '|' + lbxSD.options[x].value + ';' + lbxSD.options[x].text;
								lbxSD.remove(x);
								x--;
								contSD--;
							}
						}

						strGrupoTotal += '{/' + strGrpSA + '}';
					}

					strGrupoTotal += '{/ID' + idFila + '}';

					borrarGrupoServicio(idFila);
					hidPlanServicioNoGrupo.value += strGrupoTotal;
					guardarGrupoTemp(strGrupoTotal);
				}
				else
					asignarGrupoTemp(idFila);
			}

			function reseteartblRoaming()
			{
				document.getElementById('rbtValDeterminado').checked = false;
				document.getElementById('rbtValIndeterminado').checked = false;
				document.getElementById('tdLblFechaDesde').style.display = 'none';
				document.getElementById('tdLblFechaHasta').style.display = 'none';
				document.getElementById('tdTxtFechaDesde').style.display = 'none';
				document.getElementById('tdTxtFechaHasta').style.display = 'none';
				setValue('txtFechaDesde',FechaActual());
				setValue('txtFechaHasta',FechaEspecifica(1));
				setVisible('btnFechaDesde', true);
				setVisible('btnFechaHasta', true);
				setEnabled('rbtValDeterminado', true, '');
				setEnabled('rbtValIndeterminado', true, '');
			}

			function llenarServicio(idFila)
			{
				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				var strPlanServicioNo = document.getElementById('hidPlanServicioNo').value;

				var posIniPS = strPlanServicio.indexOf('*ID*' + idFila);
				var posFinPS = 0;
				var posIniPSNo = strPlanServicioNo.indexOf('*ID*' + idFila);
				var posFinPSNo = 0;
				var lbxSD = document.getElementById('lbxServiciosDisponibles1');
				var lbxSA = document.getElementById('lbxServiciosAgregados1');

				lbxSD.length = 0;
				lbxSA.length = 0;

				if (posIniPS > -1)
				{
					posFinPS = strPlanServicio.substring(posIniPS + 4).indexOf('*ID*') + 4;

					if (posFinPS == 3)
						posFinPS = strPlanServicio.length;
					else
						posFinPS += posIniPS;

					var arrPS = strPlanServicio.substring(posIniPS, posFinPS).split('|');

					for (i = 1; i < arrPS.length; i++)
					{
						var arrCodDes = arrPS[i].split(';');
						var option = document.createElement('option');
                                                 //-Limpiar Plazo -Fecha Activacion - Fecha Desactivacion
						var codServSelected = arrCodDes[0].split('_');
						var arrayList = new Array;;
						var j = 0;
						option.value = arrCodDes[0];
						option.text = arrCodDes[1];
						lbxSA.options[i-1] = option;

						//Verificar si es Servicio Roaming Internacional
						if (codServSelected[3] == '<%= ConfigurationSettings.AppSettings("codServRoamingI") %>')
						{
							document.getElementById('tblRoamingI').style.display = 'inline';
							if (codServSelected[0] == '0')
							{
								if(codServSelected[5] == '<%= ConfigurationSettings.AppSettings("codPlazoDeterminado") %>')	
								{
									document.getElementById('rbtValDeterminado').checked = true;
									document.getElementById('rbtValIndeterminado').checked = false;
									document.getElementById('tdLblFechaDesde').style.display = '';
									document.getElementById('tdLblFechaHasta').style.display = '';
									document.getElementById('tdTxtFechaDesde').style.display = '';
									document.getElementById('tdTxtFechaHasta').style.display = '';
									setValue('txtFechaDesde',codServSelected[6]);
									setValue('txtFechaHasta',codServSelected[7]);
									setVisible('btnFechaDesde', false);
									setVisible('btnFechaHasta', false);
									setEnabled('rbtValDeterminado', false, '');
									setEnabled('rbtValIndeterminado', false, '');
								}
								else
								{
									document.getElementById('rbtValDeterminado').checked = false;
									document.getElementById('rbtValIndeterminado').checked = true;
									document.getElementById('tdLblFechaDesde').style.display = '';
									document.getElementById('tdLblFechaHasta').style.display = 'none';
									document.getElementById('tdTxtFechaDesde').style.display = '';
									document.getElementById('tdTxtFechaHasta').style.display = 'none';
									setValue('txtFechaDesde',codServSelected[6]);
									setValue('txtFechaHasta','');
									setVisible('btnFechaDesde', false);
									setVisible('btnFechaHasta', false);
									setEnabled('rbtValDeterminado', false, '');
									setEnabled('rbtValIndeterminado', false, '');
								}
							}
							else
							{
								if(codServSelected[5] == '<%= ConfigurationSettings.AppSettings("codPlazoDeterminado") %>')	
								{
									document.getElementById('rbtValDeterminado').checked = true;
									document.getElementById('rbtValIndeterminado').checked = false;
									document.getElementById('tdLblFechaDesde').style.display = '';
									document.getElementById('tdLblFechaHasta').style.display = '';
									document.getElementById('tdTxtFechaDesde').style.display = '';
									document.getElementById('tdTxtFechaHasta').style.display = '';
									setValue('txtFechaDesde',codServSelected[6]);
									setValue('txtFechaHasta',codServSelected[7]);
									setVisible('btnFechaDesde', true);
									setVisible('btnFechaHasta', true);
									setEnabled('rbtValDeterminado', true, '');
									setEnabled('rbtValIndeterminado', true, '');
								}
								else
								{
									document.getElementById('rbtValDeterminado').checked = false;
									document.getElementById('rbtValIndeterminado').checked = true;
									document.getElementById('tdLblFechaDesde').style.display = '';
									document.getElementById('tdLblFechaHasta').style.display = 'none';
									document.getElementById('tdTxtFechaDesde').style.display = '';
									document.getElementById('tdTxtFechaHasta').style.display = 'none';
									setValue('txtFechaDesde',codServSelected[6]);
									setValue('txtFechaHasta','');
									setVisible('btnFechaDesde', true);
									setVisible('btnFechaHasta', true);
									setEnabled('rbtValDeterminado', true, '');
									setEnabled('rbtValIndeterminado', true, '');
								}
							}
						}
                                        
					}
				}
				if (posIniPSNo > -1)
				{
					posFinPSNo = strPlanServicioNo.substring(posIniPSNo + 4).indexOf('*ID*') + 4;

					if (posFinPSNo == 3)
						posFinPSNo = strPlanServicioNo.length;
					else
						posFinPSNo += posIniPSNo;

					var arrPSNo = strPlanServicioNo.substring(posIniPSNo, posFinPSNo).split('|');

					for (i = 1; i < arrPSNo.length; i++)
					{
						var arrCodDes = arrPSNo[i].split(';');
						var option = document.createElement('option');
						option.value = arrCodDes[0];
						option.text = arrCodDes[1];
						lbxSD.options[i-1] = option;
					}
				}

				agregarGrupo(idFila, false);

				if (getValue('hidCodigoTipoProductoActual') == codTipoProd3Play)
					llenarPromocion(idFila, false);
			}

			function llenarPromocion(idFila, desdeTemp)
			{
				var strPromocion;

				if (!desdeTemp)
					strPromocion = document.getElementById('hidPromocion').value;
				else
					strPromocion = document.getElementById('hidPromocionTemp').value;

				var posIniPS = strPromocion.indexOf('*ID*' + idFila);
				var posFinPS = 0;
				var lbxSA = document.getElementById('lbxPromocionesAgregadas');

				lbxSA.length = 0;

				if (posIniPS > -1)
				{
					posFinPS = strPromocion.substring(posIniPS + 4).indexOf('*ID*') + 4;

					if (posFinPS == 3)
						posFinPS = strPromocion.length;
					else
						posFinPS += posIniPS;

					var arrPS = strPromocion.substring(posIniPS, posFinPS).split('|');

					for (i = 1; i < arrPS.length; i++)
					{
						var arrCodDes = arrPS[i].split(';');
						var option = document.createElement('option');
						option.value = arrCodDes[0];
						option.text = arrCodDes[1];
						lbxSA.options[i-1] = option;
					}
				}
			}

			function asignarPromocion3PlayTemp(idFila)
			{
				var strSrvSel = '';
				var strPlanCodigo = document.getElementById('ddlPlan' + idFila).value;
				var strCodServ = strPlanCodigo.split('_')[0];

				setValue('hidPromocionTemp', '');

				strSrvSel += ';' + strCodServ;

				strSrvSel += extraerCodigoServicioTemp();

				asignarPromocion3Play1(idFila, strSrvSel, true);

				llenarPromocion(idFila, true);
			}

			function extraerCodigoServicioTemp()
			{
				var lbxSA = document.getElementById('lbxServiciosAgregados1');
				var strResultado = '';

				for (var i = 0; i < lbxSA.length; i++)
				{
					strResultado += ';' + lbxSA.options[i].value.split('_')[3];
				}

				return strResultado;
			}

			function mostrarServicio(idFila)
			{
				
				if(document.getElementById('tblPuntosCC').style.display == 'inline') return;
				
				parent.document.getElementById('trEvaluarResultado').style.display = 'none';
				if (document.getElementById('hidValidarGuardarCuota').value.length > 0)
				{
					alert('Debe guardar las cuotas antes de ejecutar esta acción');
					return;
				}

				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				var strPlanServicioNo = document.getElementById('hidPlanServicioNo').value;
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var strPlan = ddlPlan.value;
				var ddlCampana = document.getElementById('ddlCampana' + idFila);

				//- Oculta y resetear Tabla para Servicio Roaming
				document.getElementById('tblRoamingI').style.display = 'none';
				reseteartblRoaming();
				
				if (strPlan.length > 0)
				{
					document.getElementById('tblServicios').style.display = 'inline';

					if (getValue('hidCodigoTipoProductoActual') == codTipoProd3Play)
					{
						var strIdProducto = ddlPlan.value.split('.')[1];
						if (strIdProducto == '<%= ConfigurationSettings.AppSettings("IdProductoServicioEmail") %>')
						{
							document.getElementById('tblServicios').style.display = 'none';
							return;
						}

						document.getElementById('trPromocion').style.display = 'inline';
						document.getElementById('trPromocion1').style.display = 'inline';
						if (ddlPlan != undefined)
						{
							habilitarServicio(ddlPlan.disabled);
						}
					}
					else
					{
						document.getElementById('trPromocion').style.display = 'none';
						document.getElementById('trPromocion1').style.display = 'none';
						if (ddlCampana != undefined)
						{
							habilitarServicio(ddlCampana.disabled);
						}
					}

					document.getElementById('hidLineaActual').value = idFila;
					document.getElementById('lblIdLista').innerHTML = obtenerTextoSeleccionado(ddlPlan);

					if (strPlanServicio.indexOf('*ID*' + idFila) > -1 || strPlanServicioNo.indexOf('*ID*' + idFila) > -1)
						llenarServicio(idFila);

					cerrarCuota();
				}
				else
					cerrarServicio();

				parent.autoSizeIframe();
			}

			function mostrarServicioGuardado(idFila)
			{
				var strPlan = getValue('hidCodPlan1');
				cerrarCuota();
				document.getElementById('tblServicios').style.display = 'none';

				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				if (strPlanServicio.indexOf('*ID*' + idFila) > -1)
				{
					llenarServicio(idFila);
					document.getElementById('tblServicios').style.display = 'inline';
				}

				document.getElementById('lblIdLista').innerHTML = obtenerTextoSeleccionado(document.getElementById('ddlPlan' + idFila));

				if (getValue('hidCodigoTipoProductoActual') == codTipoProd3Play)
				{
					var ddlPlan = document.getElementById('ddlPlan' + idFila);
					var strPlan = ddlPlan.value;
					var strIdProducto = ddlPlan.value.split('.')[1];
					if (strIdProducto == '<%= ConfigurationSettings.AppSettings("IdProductoServicioEmail") %>')
					{
						document.getElementById('tblServicios').style.display = 'none';
						return;
					}

					document.getElementById('tblServicios').style.display = 'inline';
					document.getElementById('trPromocion').style.display = 'inline';
					document.getElementById('trPromocion1').style.display = 'inline';

					llenarPromocion(idFila, false);
				}
				else
				{
					document.getElementById('trPromocion').style.display = 'none';
					document.getElementById('trPromocion1').style.display = 'none';
				}

				habilitarServicio(true);
				habilitarCuota(idFila);

				parent.autoSizeIframe();
			}

//gaa20161025
			//function agregarServicio() {
			function agregarServicio(strServicio)
			{
				var lbxSD = document.getElementById('lbxServiciosDisponibles1');
				var lbxSA = document.getElementById('lbxServiciosAgregados1');
				var contSD = lbxSD.options.length;
				var contSA = lbxSA.options.length;
				var arrCodigo;
				var strGrupo;
				var linea = document.getElementById('hidLineaActual').value;
				var strFinLinea = '{/ID' + linea + '}';
				var hidPlanServicioNGTemp = document.getElementById('hidPlanServicioNGTemp');
				var strPlanServicioNGTemp = hidPlanServicioNGTemp.value;
				var strGrupoResultado = '';
				var strGrupo1 = '';
				var strGrupo2 = '';

				for (var i = 0; i < contSD; i++)
				{
					
//gaa20161025: Permite agregar un servicio por defecto 
					//if (lbxSD.options[i].selected)
					if (lbxSD.options[i].selected || (strServicio != null && lbxSD.options[i].value.split("_")[3] == strServicio))
					{
						var option = document.createElement('option');
						option.value = lbxSD.options[i].value;
						option.text = lbxSD.options[i].text;
						lbxSA.options[contSA] = option;

						arrCodigo = lbxSA.options[contSA].value.split('_');
						strGrupo = arrCodigo[1];

						contSA++;
						lbxSD.remove(i);
						i--;
						contSD--;

						asignarPromocion3PlayTemp(linea);
//gaa20161025
						break;
//fin gaa20161025
					}
				}

				for (var i = 0; i < contSD; i++)
				{
					arrCodigo = lbxSD.options[i].value.split('_');
					strGrupo1 = arrCodigo[1];

					if (strGrupo == strGrupo1 && strGrupo.length > 0)
					{
						if (strGrupoResultado.length == 0)
						{
							strGrupo2 = strGrupo1
							strGrupoResultado = '{' + strGrupo1 + '}';
						}
						strGrupoResultado += '|' + lbxSD.options[i].value + ';' + lbxSD.options[i].text;
						lbxSD.remove(i);
						i--;
						contSD--;
					}
				}

				if (strGrupoResultado.length > 0)
					strGrupoResultado += '{/' + strGrupo2 + '}';

				strPlanServicioNGTemp = strPlanServicioNGTemp.replace(strFinLinea, strGrupoResultado + strFinLinea);
				hidPlanServicioNGTemp.value = strPlanServicioNGTemp;

				document.getElementById('lbxPromocionesDisponibles').innerHTML = "";
				document.getElementById('lbxPromocionesSeleccionadas').innerHTML = "";
				lbxSD.selectedIndex = -1;
				lbxSA.selectedIndex = -1;
			}

			function quitarServicio(strParametro)
			{
				var lbxSD = document.getElementById('lbxServiciosDisponibles1');
				var lbxSA = document.getElementById('lbxServiciosAgregados1');
				var contSD = lbxSD.options.length;
				var contSA = lbxSA.options.length;
				var strGrupo = '';
				var hidPlanServicioNGTemp = document.getElementById('hidPlanServicioNGTemp');
				var strPlanServicioNGTemp = hidPlanServicioNGTemp.value;
				var intPosIni;
				var intPosFin;
				var intPosFin2;
				var arrServicios;
				var arrValores;
				var arrCodigo;
				var linea = document.getElementById('hidLineaActual').value;
//gaa20161025
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');
				var codTopeAutomatico = '<%= ConfigurationSettings.AppSettings("constCodTopeAutomaticoServicio") %>';
				var codTopeCero = '<%= ConfigurationSettings.AppSettings("constCodTopeCeroServicio") %>';
				var strServicioTope = '';
				var codFamiliaLocal = '<%= ConfigurationSettings.AppSettings("FamiliaPlanLocal") %>';
				var contadortope = 0;
//fin gaa20161025
				for (var i = 0; i < contSA; i++)
				{
					if (lbxSA.options[i].selected)
					{
						arrCodigo = lbxSA.options[i].value.split('_');
						var codServSelected = arrCodigo[3];
						if (codServSelected == '<%= ConfigurationSettings.AppSettings("codServRoamingI") %>')
						{
							document.getElementById('tblRoamingI').style.display = 'none';
							reseteartblRoaming();
						}
						//Si SELECCIONADO_OBLIGATORIO es igual a vacio
						//if (arrCodigo[2].length == 0)
						//Si SELECCIONADO_OBLIGATORIO no aparece
						if (arrCodigo[2] != '2')
						{
							var option = document.createElement('option');
							option.value = lbxSA.options[i].value;
							option.text = lbxSA.options[i].text;
							lbxSD.options[contSD] = option;

							strGrupo = arrCodigo[1];

							lbxSA.remove(i);
							contSD++;
							i--;
							contSA--;

							asignarPromocion3PlayTemp(linea);
//gaa20161025
							if (document.getElementById('tdFamiliaPlanMovil').style.display != 'none' && codigoTipoProductoActual == codTipoProdMovil) {
								if (document.getElementById('ddlFamiliaPlan' + linea).value == codFamiliaLocal && strParametro != 'r') {
									if (codServSelected == codTopeAutomatico)
										strServicioTope = codTopeCero;
									else {
										if (codServSelected == codTopeCero)
											strServicioTope = codTopeAutomatico;
									}
								}
							}

							break;
//fin gaa20161025
						}
					}
				}

				if (strGrupo.length > 0)
				{
					intPosIni = strPlanServicioNGTemp.indexOf('{' + strGrupo + '}');

					if (intPosIni > -1)
					{
						intPosFin = strPlanServicioNGTemp.indexOf('{/' + strGrupo + '}');
						intPosFin2 = strPlanServicioNGTemp.substring(intPosFin).indexOf('}') + intPosFin;

						arrServicios = strPlanServicioNGTemp.substring(intPosIni, intPosFin).split('|');

						for (var i = 1; i < arrServicios.length; i++)
						{
							arrValores = arrServicios[i].split(';');

							var option = document.createElement('option');
							option.value = arrValores[0];
							option.text = arrValores[1];
							lbxSD.options[contSD] = option;
							contSD++;	
						}
						
						var strCodServDisTope;
						
						for (var j = 0; j < contSD; j++)
						{
							strCodServDisTope=lbxSD.options[j].value;			   				   	
							if (strCodServDisTope.split('_')[3] == '<%= ConfigurationSettings.AppSettings("SERVV_CODIGO") %>') 
							{ 
								contadortope++;
								if(contadortope == 2){
								lbxSD.remove(j);
								j--;
								contSD--;
								}
							} 
						}

						hidPlanServicioNGTemp.value = strPlanServicioNGTemp.replace(strPlanServicioNGTemp.substring(intPosIni, intPosFin2), '');
					}
				}

				document.getElementById('lbxPromocionesDisponibles').innerHTML = "";
				document.getElementById('lbxPromocionesSeleccionadas').innerHTML = "";
				lbxSD.selectedIndex = -1;
				lbxSA.selectedIndex = -1;
//gaa20161025
				if (strServicioTope.length > 0)
					agregarServicio(strServicioTope);
//fin gaa20161025
			}

			function resetServicio()
			{
				var idFila = document.getElementById('hidLineaActual').value;
				var strPlan = document.getElementById('ddlPlan' + idFila).value;

				if (strPlan.length > 0)
				{
					var lbxSA = document.getElementById('lbxServiciosAgregados1');
					var contSA = lbxSA.options.length;

					for (var i = 0; i < contSA; i++)
					{
						arrCodigo = lbxSA.options[i].value.split('_');

						if (arrCodigo[2] != '2' && arrCodigo[2] != '3')
						{
							lbxSA.options[i].selected = true;

							quitarServicio('r');
							contSA--;
							i--;
						}
					}
					return
				}

				document.getElementById('lbxPromocionesDisponibles').innerHTML = "";
				document.getElementById('lbxPromocionesSeleccionadas').innerHTML = "";
				document.getElementById('lbxServiciosDisponibles1').selectedIndex = -1;
				document.getElementById('lbxServiciosAgregados1').selectedIndex = -1;
			}

			function cerrarServicio()
			{
				document.getElementById('lbxServiciosDisponibles1').length = 0;
				document.getElementById('lbxServiciosAgregados1').length = 0;
				document.getElementById('tblServicios').style.display = 'none';
			}

			function asignarLineaActual(idFila)
			{
				var hidLineaActual = document.getElementById('hidLineaActual');

				hidLineaActual.value = idFila;
			}

			function FechaActual() {
				var fec;
				var cad;
				
				fec = new Date()
				if (fec.getDate()<10) {
					cad = '0' + fec.getDate();
				} else {
					cad = '' + fec.getDate();
				}
				
				if ((fec.getMonth()+1)<10) {
					cad = cad + '/0' + (fec.getMonth()+1);
				} else {
					cad = cad + '/' + (fec.getMonth()+1);
				}
				
				cad = cad + '/' + fec.getFullYear();
				
				return cad;
			}
			
			function FechaEspecifica(dias)
			{
				var cad;
				var fec = new Date(),
				dia = fec.getDate(),
				addTime = dias * 86400; //Tiempo en segundos
				
				fec.setSeconds(addTime); //Añado el tiempo
				if (fec.getDate() <10) {
					cad = '0' + fec.getDate();
				} else {
					cad = '' + fec.getDate();
				}
				
				if ((fec.getMonth()+1)<10) {
					cad = cad + '/0' + (fec.getMonth()+1);
				} else {
					cad = cad + '/' + (fec.getMonth()+1);
				}
				cad = cad + "/" + fec.getFullYear();
				return cad;
			}
			
			function ValidaFechaMayor(control1,control2,campo1,campo2){ 
				var cadena1;
				var cadena2;				
				eval("cadena1 = " + control1 + ".value");
				eval("cadena2 = " + control2 + ".value");
				if ((cadena1!='')&&(cadena2!='')){
					comp1 	= cadena1.substr(6,4) + '' + cadena1.substr(3,2) + '' + cadena1.substr(0,2);
					comp2 	= cadena2.substr(6,4) + '' + cadena2.substr(3,2) + '' + cadena2.substr(0,2);
					if 	((comp1) <= (comp2)){
						alert('' + campo1 +' debe ser MAYOR que la ' + campo2 + '');
						return false;
					}
				}
				return true;
			}
			
			
			function ValidaFechaMayorActual(control1,campo1){ 
				var cadena1;
				var cadena2 = FechaActual();			
				eval("cadena1 = " + control1 + ".value");
				if (cadena1!=''){
					comp1 	= cadena1.substr(6,4) + '' + cadena1.substr(3,2) + '' + cadena1.substr(0,2);
					comp2 	= cadena2.substr(6,4) + '' + cadena2.substr(3,2) + '' + cadena2.substr(0,2);
					if 	((comp1) < (comp2)){
						alert('' + campo1 +' debe ser MAYOR o IGUAL que la fecha actual');
						return false;
					}
				}
				return true;
			}
			
			function validarParametrosServRI()
			{
				if (document.getElementById('tblRoamingI').style.display == 'none')
				{
					alert('Seleccione e ingrese parametros para Servicio Roaming Internacional');
					return false;
				}
				
				if (document.getElementById('rbtValDeterminado').checked == false && document.getElementById('rbtValIndeterminado').checked == false)
				{
					alert('Debe seleccionar un plazo');
					return false;
				}
				
				if (getValue('txtFechaDesde') == '')
				{
					alert('Debe ingresar la fecha de Activación');
					return false;
				}
				
				if(!ValidaFechaMayorActual("document.getElementById('txtFechaDesde')",'La Fecha Desde')){
					return false;
				}	
				
				if(isVisible('tdTxtFechaHasta'))
				{
					if (getValue('txtFechaHasta') == '')
					{
						alert('Debe ingresar la fecha de Desactivación');
						return false;
					}
					
					if(!ValidaFechaMayor("document.getElementById('txtFechaHasta')","document.getElementById('txtFechaDesde')",'La Fecha Hasta','Fecha Desde')){
						return false;
					}	
				}
				
				document.getElementById('tblRoamingI').style.display = 'none';
				return true;
			}

			function guardarServicio()
			{
				if (document.getElementById('btnCerrarServicios').value == 'Cerrar')
				{
					parent.document.getElementById('trEvaluarResultado').style.display = '';
					cerrarServicio()
					parent.autoSizeIframe();
					return;
				}
				
				parent.document.getElementById('trEvaluarResultado').style.display = '';
				
				var hidPlanServicio = document.getElementById('hidPlanServicio');
				var hidPlanServicioNo = document.getElementById('hidPlanServicioNo');
				var lbxSD = document.getElementById('lbxServiciosDisponibles1');
				var lbxSA = document.getElementById('lbxServiciosAgregados1');
				var linea = document.getElementById('hidLineaActual').value;
				var strPlanServicio = '*ID*' + linea;
				var strPlanServicioNo = '*ID*' + linea;
				var contSD = lbxSD.options.length;
				var contSA = lbxSA.options.length;
				var strCodSA;
				var arrCodSA;
				var totalServicios = 0;

				var hidMontoServicios = document.getElementById('hidMontoServicios' + linea);

				borrarServicio(linea);
				var txtMontoTopeConsumo = document.getElementById('txtMontoTopeConsumo' + linea);
				if (txtMontoTopeConsumo != null)
					txtMontoTopeConsumo.value = '';

				for (var i = 0; i < contSA; i++)
				{
					strCodSA = lbxSA.options[i].value;
					arrCodSA = strCodSA.split('_');

					//Verificar si el servicio es Roaming Internacional
					
					var codServSelected = arrCodSA[3];
					if (codServSelected == '<%= ConfigurationSettings.AppSettings("codServRoamingI") %>')
					{
						if (!validarParametrosServRI())
							return;
						
						if (document.getElementById('rbtValDeterminado').checked == true)
							strPlanServicio += '|' + strCodSA + '_' + document.getElementById('rbtValDeterminado').value + '_' + getValue('txtFechaDesde') + '_' + getValue('txtFechaHasta') + ';' + lbxSA.options[i].text
						else
							strPlanServicio += '|' + strCodSA + '_' + document.getElementById('rbtValIndeterminado').value + '_' + getValue('txtFechaDesde') + '_' + getValue('txtFechaHasta') + ';' + lbxSA.options[i].text
							
					}
					else
					{
					strPlanServicio += '|' + strCodSA + ';' + lbxSA.options[i].text
					}
					
					//-----------------------
					totalServicios += parseFloat(arrCodSA[4]);

					if (arrCodSA[3] == topeConsumoAuto)
					{
						var strPlanCodigo = getValor(document.getElementById('ddlPlan' + linea).value, 0);
						LlenarMontoTopeConsumoIfr(linea, strPlanCodigo);
					}
					//'PROY-24724-IDEA-28174 - INICIO
					if (arrCodSA[3] == codServProteccionMovil)
					{
						var strFlagPM = 'PM';
					parent.setValue('hidflagProTMovil', strFlagPM);
					}
					//'PROY-24724-IDEA-28174 - FIN
				}
				var strCodServDis ; //'PROY-24724-IDEA-28174  
				for (var i = 0; i < contSD; i++)
				{
				   //'PROY-24724-IDEA-28174 - INICIO
				   strCodServDis=lbxSD.options[i].value;			   
				   	
					if (strCodServDis.split('_')[3] == codServProteccionMovil) 
					{ 
						if (concatCodTipoPdvProteccionMovil.indexOf(parent.getValue('hidCanal')) >= 0) 			
						strPlanServicioNo += '|' + lbxSD.options[i].value + ';' + lbxSD.options[i].text 
						else 
						lbxSD.remove[i]; 
					} 
					else //'PROY-24724-IDEA-28174 - FIN 				
					strPlanServicioNo += '|' + lbxSD.options[i].value + ';' + lbxSD.options[i].text
				}

				hidPlanServicio.value += strPlanServicio;
				hidPlanServicioNo.value += strPlanServicioNo;

				cerrarServicio();
				borrarGrupoServicio(linea);
				guardarGrupo(linea);

				hidMontoServicios.value = totalServicios;

				calcularCFxProducto();

				var ddlCampana = document.getElementById('ddlCampana' + linea);
				if (ddlCampana != null)
				{
					if (ddlCampana.value.length > 0 &&
						getValue('hidCodigoTipoProductoActual') == codTipoProdDTH)
						evaluarKits(linea);
				}

				if (getValue('hidCodigoTipoProductoActual') == codTipoProd3Play)

					asignarPromocion3Play(linea);

				document.getElementById('lbxPromocionesDisponibles').innerHTML = "";
				document.getElementById('lbxPromocionesSeleccionadas').innerHTML = "";
				document.getElementById('lbxServiciosDisponibles1').selectedIndex = -1;
				document.getElementById('lbxServiciosAgregados1').selectedIndex = -1;

				parent.autoSizeIframe();
			}

			function asignarKits(idFila, strResultado)
			{
				document.getElementById('hidKit' + idFila).value = strResultado;
				evaluarKits(idFila);
			}

			function evaluarKits(idFila)
			{
				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				var posIniPS = strPlanServicio.indexOf('*ID*' + idFila);
				var posFinPS = 0;
				var arrPS;
				var arrCodDes;
				var strTipoServicio;
				var intContarHD = 0;
				var intContarDigital = 0;
				var intCantServ = 0;

				if (posIniPS > -1)
				{
					posFinPS = strPlanServicio.substring(posIniPS + 4).indexOf('*ID*') + 4;

					if (posFinPS == 3)
						posFinPS = strPlanServicio.length;
					else
						posFinPS += posIniPS;

					arrPS = strPlanServicio.substring(posIniPS, posFinPS).split('|');
					intCantServ = arrPS.length;

					for (i = 1; i < intCantServ; i++)
					{
						arrCodDes = arrPS[i].split(';');
						strTipoServicio = arrCodDes[0].split('_')[1];

						if (strTipoServicio == 'SHD')
							intContarHD++;
						else
						{
							if (strTipoServicio == 'SNL')
								intContarDigital++;
						}
					}

					if (intContarHD > 0)
						quitarKits(idFila, '1'); //Digital
					else
					{
						if (intContarHD == 0 && intCantServ > 0)
							quitarKits(idFila, '2,3'); //HD,DVR
						else
						{
							if (intCantServ == 0)
								quitarKits(idFila, '2,3'); //HD,DVR
						}
					}
				}
				else
					quitarKits(idFila, '2,3');
			}

			function quitarKits(idFila, tipos)
			{
				var arrTipo = tipos.split(',');
				var strKits = document.getElementById('hidKit' + idFila).value;
				var arrKits = strKits.split('|');
				var contKits = arrKits.length;
				var arrKit;
				var arrCodigo;
				var strResultado = '';

				for (j = 0; j < arrTipo.length; j++)
				{
					for (i = 1; i < contKits; i++)
					{
						arrKit = arrKits[i].split(';');
						arrCodigo = arrKit[0].split('_');

						if (arrCodigo[1] == arrTipo[j])
						{
							arrKits.splice(i,1);
							i--;
							contKits--;
						}
					}
				}

				for (i = 1; i < contKits; i++)
				{
					arrKit = arrKits[i].split(';');
					arrCodigo = arrKit[0].split('_');

					strResultado += '|' + arrCodigo[0] + ';' + arrKit[1];
				}

				var codKit = '<%= ConfigurationSettings.AppSettings("CodKITCambioTitularidad") %>';
				strResultado += '|' + codKit + ';' + '<%= ConfigurationSettings.AppSettings("KITCambioTitularidad") %>';

				llenarMaterial(idFila, strResultado);
				asignarMaterial1(idFila);
			}

			function obtenerPrecioKit(idFila, codigoKit)
			{
				var strKits = document.getElementById('hidKit' + idFila).value;
				var arrKits = strKits.split('|');
				var contKits = arrKits.length;
				var arrKit;
				var arrCodigo;
				var resultado = 0;

				for (i = 1; i < contKits; i++)
				{
					arrKit = arrKits[i].split(';');
					arrCodigo = arrKit[0].split('_');

					if (arrCodigo[0] == codigoKit)
						resultado = arrCodigo[3] + '_' + arrCodigo[2];
				}

				return resultado;
			}

			function LlenarMontoTopeConsumoIfr(idFila, strPlan)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strPlan=' + strPlan;
				url += '&strMetodo=' + 'LlenarMontoTopeConsumo';

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function borrarServicio(idFila)
			{
				var hidPlanServicio = document.getElementById('hidPlanServicio');
				var hidPlanServicioNo = document.getElementById('hidPlanServicioNo');
				var strPlanServicio = '*ID*' + idFila;

				var intPosIni = hidPlanServicio.value.indexOf(strPlanServicio);
				var intPosFin = 0;

				if (intPosIni > -1)
				{
					intPosFin = hidPlanServicio.value.substring(intPosIni + 4).indexOf('*ID*');

					if (intPosFin == -1)
						intPosFin = hidPlanServicio.value.length;
					else
						intPosFin += intPosIni + 4;

					hidPlanServicio.value = hidPlanServicio.value.replace(hidPlanServicio.value.substring(intPosIni, intPosFin), '');
				}

				intPosIni = hidPlanServicioNo.value.indexOf(strPlanServicio);

				if (intPosIni > -1)
				{
					intPosFin = hidPlanServicioNo.value.substring(intPosIni + 4).indexOf('*ID*');

					if (intPosFin == -1)
						intPosFin = hidPlanServicioNo.value.length;
					else
						intPosFin += intPosIni + 4;

					hidPlanServicioNo.value = hidPlanServicioNo.value.replace(hidPlanServicioNo.value.substring(intPosIni, intPosFin), '');
				}

				borrarGrupoServicio(idFila);

				setValue('hidMontoServicios' + idFila, '');
			}
			// ******************************************************* SERVICIOS ******************************************************* //

			// ******************************************************* CUOTAS ******************************************************* //
			function habilitarCuota(idFila)
			{
				var ddlCampana = document.getElementById('ddlCampana' + idFila);

				if (ddlCampana == null)
					return;

				var hab = ddlCampana.disabled;
				var ddlNroCuotas = document.getElementById('ddlNroCuotas');

				ddlNroCuotas.disabled = hab;

				if (hab)
					document.getElementById('btnCerrarCuotas').value = 'Cerrar';
				else
					document.getElementById('btnCerrarCuotas').value = 'Cerrar y Guardar';
			}

			function llenarDatosCuota(strDatos,arrayCuotaMonto) {
				var idFila = document.getElementById('hidLineaActual').value;
				var ddlNroCuotas = document.getElementById('ddlNroCuotas');
				var txtPorcCuotaIni = document.getElementById('txtPorcCuotaIni');
				var txtMontoCuotaIni = document.getElementById('txtMontoCuotaIni');
				var txtMontoCuota = document.getElementById('txtMontoCuota');
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				var strNroCuotaActual = document.getElementById('hidNroCuotaActual').value;

				var cuotasMax = 0, montoMax = 0;//PROY-29123 VENTA EN CUOTAS
				
				llenarDatosCombo(ddlNroCuotas, strDatos, true);

				txtPorcCuotaIni.value = '';
				txtMontoCuotaIni.value = '';
				txtMontoCuota.value = '';

				if (ddlCampana.disabled)
					obtenerCuota(idFila);
				else {
					var strCuotas = document.getElementById('hidCuota').value;
					var strCuota;
					var strId = '|*ID' + idFila + '*';
					var intPosIni = strCuotas.indexOf(strId);
					var intPosFin;
					var ddlNroCuotas = document.getElementById('ddlNroCuotas');
					if (intPosIni > -1) {
						intPosIni += strId.length;
						strCuota = strCuotas.substring(intPosIni);
						intPosFin = strCuota.indexOf(';') + intPosIni;
						strCuota = strCuotas.substring(intPosIni, intPosFin);

						strNroCuotaActual = strCuota;
					}
					//PROY-29123 VENTA EN CUOTAS INICIO
					cuotasMax = parseInt(arrayCuotaMonto[0]);
					montoMax = parseFloat(arrayCuotaMonto[1]);
					mensajeBRMS = arrayCuotaMonto[2];


					if(mensajeBRMS && mensajeBRMS != "" && mensajeBRMS == "SI"){
						document.getElementById('lblMensajeCuotas').innerHTML = '"Cliente califica hasta ' + cuotasMax + ' cuotas con un equipo maximo de ' + montoMax.toLocaleString("es-Mx") + ' soles"'; 
					}
					//PROY-29123 VENTA EN CUOTAS FIN
					cambiarCuota(strNroCuotaActual);
				}

				quitarImagenEsperando();
				autoSizeIframe();
			}

			function mostrarCuota(idFila) {
				if (document.getElementById('hidValidarGuardarCuota').value.length > 0) {
					alert('Debe guardar las cuotas antes de ejecutar esta acción');
					return;
				}

				document.getElementById('tblCuotas').style.display = 'none';

				if (document.getElementById('hidValorEquipo' + idFila).value.length == 0) {
					alert('Para seleccionar cuotas debe escoger un equipo');
					return;
				}

					document.getElementById('hidLineaActual').value = idFila;
					document.getElementById('tblCuotas').style.display = 'inline';
					cerrarServicio();

					habilitarCuota(idFila);

				var strCadenaDetalle = consultarItem(idFila);
				parent.consultaReglasCreditosCuotas(strCadenaDetalle);
			}

			function mostrarCuotaGuardada(idFila)
			{
				document.getElementById('tblServicios').style.display = 'none';

				if (document.getElementById('hidCuota').value.indexOf('*ID' + idFila + '*') > -1)
				{
					document.getElementById('tblCuotas').style.display = 'inline';
					obtenerCuota(idFila);
					document.getElementById('hidLineaActual').value = idFila;
					habilitarCuota(idFila);
				}
				else
					document.getElementById('tblCuotas').style.display = 'none';

				parent.autoSizeIframe();
			}

			function cambiarCuota(strCuota) {
				var idFila = document.getElementById('hidLineaActual').value;

				var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);
				var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
				var txtPorcCuotaIni = document.getElementById('txtPorcCuotaIni');
				var txtMontoCuotaIni = document.getElementById('txtMontoCuotaIni');
				var txtMontoCuota = document.getElementById('txtMontoCuota');
				var ddlNroCuotas = document.getElementById('ddlNroCuotas');
				var fltPrecio;
				var fltMontoCuotaIni;
				var strListaPrecio;

				txtEquipoPrecio.value = '';
				txtPorcCuotaIni.value = '';
				txtMontoCuotaIni.value = '';
				txtMontoCuota.value = '';

				if (strCuota != '') {
				    var idCuota = getValor(strCuota, 0);
					var intNroCuotas = parseFloat(idCuota);
					var fltPorcCuotaIni = parseFloat(getValor(strCuota, 1));

					strListaPrecio = document.getElementById('hidListaPrecio' + idFila).value;

					if (strListaPrecio == '') {
						ddlNroCuotas.value = '';
						alert("No se tiene configurado lista de precios");
						return;
					}

					hidListaPrecio.value = strListaPrecio;
					fltPrecio = strListaPrecio.split('_')[0];
					txtEquipoPrecio.value = fltPrecio;

					if (seleccionarCuota(strCuota)) {
						txtPorcCuotaIni.value = fltPorcCuotaIni;
						fltMontoCuotaIni = (fltPrecio * fltPorcCuotaIni / 100).toFixed(2);
						txtMontoCuotaIni.value = fltMontoCuotaIni;
						txtMontoCuota.value = ((fltPrecio - fltMontoCuotaIni) / intNroCuotas).toFixed(2);
					}

					document.getElementById('hidValidarGuardarCuota').value = 'S';
				}
			}

			function seleccionarCuota(strCuota)
			{
				var booExiste = false;
				var ddlNroCuotas = document.getElementById('ddlNroCuotas');

				for (var i = 0; i < ddlNroCuotas.options.length; i++)
				{
					if (ddlNroCuotas.options[i].value == strCuota)
					booExiste = true;
				}

				if (booExiste)
					ddlNroCuotas.value = strCuota;

				return booExiste;
			}

			function cerrarCuota()
			{
				document.getElementById('tblCuotas').style.display = 'none';
			}

			function borrarCuota(idFila)
			{
				var hidCuota = document.getElementById('hidCuota');
				var strValIni = '|*ID' + idFila + '*';
				var strValFin = '*/ID' + idFila + '*';
				var strCuotas = hidCuota.value;
				var strCuota;
				var intPosIni = strCuotas.indexOf(strValIni);
				var intPosFin;

				if (intPosIni > -1)
				{
					intPosFin = strCuotas.indexOf(strValFin);

					strCuota = strCuotas.substring(intPosIni, intPosFin + strValFin.length);

					hidCuota.value = strCuotas.replace(strCuota, '');

					asignarCuotaActual(idFila);
				}

				setValue('hidMontoCuota' + idFila, '');

				var imgVerCuota = document.getElementById('imgVerCuota' + idFila);
				if (imgVerCuota != null)
					imgVerCuota.src = '../../../images/abrir.gif';
			}

			function asignarCuotaActual()
			{
				var strCuotas = document.getElementById('hidCuota').value;
				var hidNroCuotaActual = document.getElementById('hidNroCuotaActual');
				var arrCuotas;
				var arrCuota;
				var strNroCuota = '';
				var strValIni = '|*ID';
				var intPosIni;
				var strCuota;

				if (strCuotas.length > 0)
				{
					arrCuotas = strCuotas.split('|');

					for (var i = 0; i < arrCuotas.length; i++)
					{
						strCuota = arrCuotas[i];

						intPosIni = strCuota.indexOf(strValIni) + 3;
						strCuota = strCuota.substring(intPosIni);
						intPosIni = strCuota.indexOf('*') + 1;
						strCuota = strCuota.substring(intPosIni);

						arrCuota = strCuota.split(";");

						if (arrCuota[0].length > 0)
							strNroCuota = arrCuota[0];
					}
				}

				hidNroCuotaActual.value = strNroCuota;
			}

			function guardarCuota()
			{
			    var ddlNroCuotas = document.getElementById('ddlNroCuotas');
				if (ddlNroCuotas.value.length == 0) {
					ddlNroCuotas.focus();
					alert('Debe seleccionar una cuota');
					return false;
				}
            
				document.getElementById('hidValidarGuardarCuota').value = '';

				cerrarCuota();

				if (document.getElementById('btnCerrarCuotas').value == 'Cerrar')
				{
					parent.autoSizeIframe();
					return;
				}

				var idFila = document.getElementById('hidLineaActual').value;
				var hidCuota = document.getElementById('hidCuota');
				var strNroCuotas = document.getElementById('ddlNroCuotas').value;
				var strPorcCuotaIni = document.getElementById('txtPorcCuotaIni').value;
				var strMontoCuotaIni = document.getElementById('txtMontoCuotaIni').value;
				var strMontoCuota = document.getElementById('txtMontoCuota').value;
				var hidMontoCuota = document.getElementById('hidMontoCuota' + idFila);

				borrarCuota(idFila);

				hidCuota.value += '|*ID' + idFila + '*' + strNroCuotas + ';' + strPorcCuotaIni + ';' + strMontoCuotaIni + ';' + strMontoCuota + '*/ID' + idFila + '*';

				hidMontoCuota.value = strMontoCuota;

				calcularCFxProducto();

				imgVerCuota = document.getElementById('imgVerCuota' + idFila);
				imgVerCuota.src = '../../../images/btn_seleccionar.gif';

				parent.autoSizeIframe();
			}

			function obtenerCuota(idFila)
			{
				var strCuota = document.getElementById('hidCuota').value;
				var strValIni = '|*ID' + idFila + '*';
				var strValFin = '*/ID' + idFila + '*';
				var arrCuota;
				var strNroCuotas = '';
				var strPorcCuotaIni = '';
				var strMontoCuotaIni = '';
				var strMontoCuota = '';
				var intPosIni = strCuota.indexOf(strValIni);
				var intPosFin;
				var ddlNroCuotas = document.getElementById('ddlNroCuotas');
				var txtPorcCuotaIni = document.getElementById('txtPorcCuotaIni');
				var txtMontoCuotaIni = document.getElementById('txtMontoCuotaIni');
				var txtMontoCuota = document.getElementById('txtMontoCuota');
				var hab = document.getElementById('ddlCampana' + idFila).disabled;

				if (intPosIni > -1)
				{
					intPosIni += strValIni.length;
					intPosFin = strCuota.indexOf(strValFin);

					strCuota = strCuota.substring(intPosIni, intPosFin);
					arrCuota = strCuota.split(';')

					strNroCuotas = arrCuota[0];
					strPorcCuotaIni = arrCuota[1];
					strMontoCuotaIni = arrCuota[2];
					strMontoCuota = arrCuota[3];
				}

				ddlNroCuotas.value = strNroCuotas;
				txtPorcCuotaIni.value = strPorcCuotaIni;
				txtMontoCuotaIni.value = strMontoCuotaIni;
				txtMontoCuota.value = strMontoCuota;
			}

			function confirmarCuota(idFila)
			{
				var strCuota = document.getElementById('hidCuota').value;
				if (strCuota.indexOf('|*ID' + idFila + '*') > -1)
					return true;
				else
					return false;
			}
			// ******************************************************* CUOTAS ******************************************************* //
//gaa20161027
			function asignarValoresClient(idFila, codPlazo, plazDescr, codPaqu, paquDescr, codPlan, planDescr, cargFijo, montTope, codCamp, campDescr, codEqui, equiDescr, equiPrec, nroPort, listaPrecio, codTipoProducto, tipoProducto, codSolu, soluDescr, costoInstDTH, CFAlqKit, tiposProducto, strFamilia)
			{
				var ddlSolucion = document.getElementById('ddlSolucion' + idFila);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				var txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
				var txtMontoTopeConsumo = document.getElementById('txtMontoTopeConsumo' + idFila);
				var ddlCampana = document.getElementById('ddlCampana' + idFila);
				//var ddlEquipo = document.getElementById('ddlEquipo' + idFila);
				var hidValorEquipo = document.getElementById('hidValorEquipo' + idFila);
				var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
				var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);
				var hidListaPrecio = document.getElementById('hidListaPrecio' + idFila);
				var txtNroPortar = document.getElementById('txtNroPortar' + idFila);

				var txtPrecioInst = document.getElementById('txtPrecioInst' + idFila);
				var txtCFMenAlqKit = document.getElementById('txtCFMenAlqKit' + idFila);
				var txtCFTotMensual = document.getElementById('txtCFTotMensual' + idFila);
//gaa20161024
				var ddlFamiliaPlan = document.getElementById('ddlFamiliaPlan' + idFila);
//fin gaa20161024
				if (ddlSolucion != null)
				{
					llenarDatosCombo(ddlSolucion, '|' + codSolu + ';' + soluDescr, true);
					ddlSolucion.value = codSolu;
				}

				llenarDatosCombo(ddlPlazo, '|' + codPlazo + ';' + plazDescr, true);
				ddlPlazo.value = codPlazo;

				if (ddlPaquete != null)
				{
					llenarDatosCombo(ddlPaquete, '|' + codPaqu + ';' + paquDescr, true);
					ddlPaquete.value = codPaqu;
				}

				llenarDatosCombo(ddlPlan, '|' + codPlan + ';' + planDescr, true);
				ddlPlan.value = codPlan;
//gaa20161027: Seleccionado el unico dato
				llenarDatosCombo(ddlFamiliaPlan, strFamilia, false);
//fin gaa20161027
				txtCFPlanServicio.value = cargFijo;
				if (montTope != 0)
					txtMontoTopeConsumo.value = montTope;

				if (ddlCampana != null)
				{
					llenarDatosCombo(ddlCampana, '|' + codCamp + ';' + campDescr, true);
					ddlCampana.value = codCamp;
				}
				//if (ddlEquipo != null)
				if (txtTextoEquipo != null)
				{
					//llenarDatosCombo(ddlEquipo, '|' + codEqui + ';' + equiDescr, true);
					//ddlEquipo.value = codEqui;
					hidValorEquipo.value = codEqui;
					txtTextoEquipo.value = equiDescr;
				}
				if (txtEquipoPrecio != null)
					txtEquipoPrecio.value = equiPrec;
				if (hidListaPrecio != null)
					hidListaPrecio.value = listaPrecio;

				if (txtNroPortar != null)
					txtNroPortar.value = nroPort;

				if (txtPrecioInst != null)
					txtPrecioInst.value = costoInstDTH;

				if (txtCFMenAlqKit != null)
					txtCFMenAlqKit.value = CFAlqKit;

				if (txtCFMenAlqKit != null)
					txtCFTotMensual.value = (parseFloat(cargFijo) + parseFloat(CFAlqKit)).toFixed(2)

				autoSizeProducto();
			}

			function validarReglasComerciales(idPlan)
			{
				var idPlanxAgregar = idPlan;
				var ddlCasoEspecial = parent.document.getElementById('ddlCasoEspecial');
				var strCasoEspecial = ddlCasoEspecial.value;
				strCasoEspecial = strCasoEspecial.split('_')[0];

				var plan = 0;
				var nroPlanesTotal = 0;
				var strCodPlanBscs = 0;
				var strCodPlanSisact = 0;
				var strPlanesAgregados = getPlanesAgregados();
				var arrPlanesAgregados = strPlanesAgregados.split('|');
				idPlanxAgregar = parseInt(idPlanxAgregar, 10);

				//*********************************************************************************************************************
				//Plan Exacto Y
				if (strCasoEspecial == '')
				{
					if (idPlanxAgregar == 140)
					{
						alert("PLAN EXACTO Y es de uso exclusivo para CASO ESPECIAL OFERTA BACKUS O YANACOCHA");
						return false;
					}
				}
				//*********************************************************************************************************************
				//Plan Smart 25P
				var planBase = "<%= ConfigurationSettings.AppSettings("ConstPlanSmart25P") %>";
				var strCodPlanBscs = planBase.split('|')[0];
				var strCodPlanSisact = parseInt(planBase.split('|')[1], 10);
				var intNroMaxPlanes = parseInt(planBase.split('|')[2], 10);

				if (strCodPlanSisact == idPlanxAgregar)
				{
					nroPlanesTotal = 0;
					nroPlanesTotal = parseInt(getNroPlanesActivos(strCodPlanBscs), 10) + parseInt(getNroPlanesAgregados(strCodPlanSisact), 10) + 1;

					if (nroPlanesTotal > intNroMaxPlanes)
					{
						alert('<%= ConfigurationSettings.AppSettings("ConstMensajeExcedePlanes") %>');
						return false;
					}
				}
				//*********************************************************************************************************************
				//Validación Nro Planes Caso Especial
				if (strCasoEspecial != "")
				{
					nroPlanesTotal = 0;
					nroPlanesTotal = parseInt(getNroPlanesActivos('ALL'), 10) + parseInt(getNroPlanesAgregados('ALL'), 10) + 1;
					var nroMaxPlanes = getValor(ddlCasoEspecial.value, 2);
					if (nroPlanesTotal > parseInt(nroMaxPlanes, 10))
					{
						alert("La suma Total de Planes excede al permitido");
						return false;
					}
				}
				//*********************************************************************************************************************
				//Campaña Enamorados 2012
				var CE_BBEnamorados = '<%= ConfigurationSettings.AppSettings("ConstCasoEspBBEnamorados") %>';
				var CE_SmartEnamorados = '<%= ConfigurationSettings.AppSettings("ConstCasoEspSmartEnamorados") %>';

				if (strCasoEspecial == CE_BBEnamorados || strCasoEspecial == CE_SmartEnamorados)
				{
					nroPlanes = 0;
					for (var i = 0; i < arrPlanesAgregados.length; i++)
					{
						if (arrPlanesAgregados[i] != '')
						{
							plan = parseInt(arrPlanesAgregados[i].split('_')[0], 10);
							if (plan != idPlanxAgregar)
							{
								alert("Debe elegir planes iguales para esta campaña.");
								return false;
							}
						}
					}
					nroPlanes = parseInt(getNroPlanesAgregados('ALL'), 10);
					if (nroPlanes + 1 > 2)
					{
						alert("La suma total de Planes excede al Maximo permitido.");
						return false;
					}
				}
				//*********************************************************************************************************************
				//Claro Exacto
				var strPlanesClaroExacto = '<%= ConfigurationSettings.AppSettings("PlanesClaroExactoIlimitado") %>';
				var arrPlanesClaroExacto = strPlanesClaroExacto.split('|');
				var blnPlanesClaroExacto = false;

				for (var i = 0; i < arrPlanesClaroExacto.length; i++)
				{
					plan = parseInt(arrPlanesClaroExacto[i].split(';')[0], 10);
					if (plan == idPlanxAgregar)
					{
						blnPlanesClaroExacto = true;
						break;
					}
				}
				if (blnPlanesClaroExacto)
				{
					nroPlanesTotal = 0;
					for (var i = 0; i < arrPlanesClaroExacto.length; i++)
					{
						strCodPlanBscs = arrPlanesClaroExacto[i].split(';')[1];
						strCodPlanSisact = parseInt(arrPlanesClaroExacto[i].split(';')[0], 10);
						nroPlanesTotal = nroPlanesTotal + parseInt(getNroPlanesActivos(strCodPlanBscs), 10) + parseInt(getNroPlanesAgregados(strCodPlanSisact), 10);
						if (nroPlanesTotal + 1 > 3)
						{
							alert("La suma total de planes Exacto + Ilimitado excede al permitido.");
							return false;
						}
					}
				}
				//*********************************************************************************************************************
				//Planes C Ilimitado
				var strPlanesModemCIlimitado = '<%= ConfigurationSettings.AppSettings("PlanesModemCIlimitado") %>';
				var arrPlanesModemCIlimitado = strPlanesModemCIlimitado.split('|');
				var blnPlanesModemCIlimitado = false;

				for (var i = 0; i < arrPlanesModemCIlimitado.length; i++)
				{
					plan = parseInt(arrPlanesModemCIlimitado[i].split(';')[0], 10);
					if (plan == idPlanxAgregar)
					{
						blnPlanesModemCIlimitado = true;
						break;
					}
				}
				if (blnPlanesModemCIlimitado)
				{
					nroPlanesTotal = 0;
					for (var i = 0; i < arrPlanesModemCIlimitado.length; i++)
					{
						strCodPlanBscs = arrPlanesModemCIlimitado[i].split(';')[1];
						strCodPlanSisact = parseInt(arrPlanesModemCIlimitado[i].split(';')[0], 10);
						nroPlanesTotal = nroPlanesTotal + parseInt(getNroPlanesActivos(strCodPlanBscs), 10) + parseInt(getNroPlanesAgregados(strCodPlanSisact), 10);
						if (nroPlanesTotal + 1 > 3)
						{
							alert("La suma total de Planes Modem (C) excede al permitido.");
							return false;
						}
					}
				}
				//*********************************************************************************************************************
				//Exclusion Planes
				var strListaPlanesRPC = '<%= ConfigurationSettings.AppSettings("constCodPlanesRPC") %>';
				if (validarExclusionPlanes(idPlan, strListaPlanesRPC))
				{
					alert("Los planes Exacto RPC6 o Exato RPC12 no pueden ser combinados con otros");
					return false;
				}
				//2Play Corporativo
				var strListaPlanes2Play = '<%=ConfigurationSettings.AppSettings("CodPlanes2PlayCorporativo")%>';
				if (validarExclusionPlanes(idPlan, strListaPlanes2Play))
				{
					alert("Los planes Fono Claro Internet son excluyentes, no pueden evaluarse junto a otros planes.");
					return false;
				}
				return true;
			}

			function tieneTipoProducto(tipoProducto, flgLineaActual)
			{
				var tabla = document.getElementById('tblTablaMovil');
				var cont = tabla.rows.length;

				if (flgLineaActual)
					cont = cont - 1;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					if (tipoProducto == fila.cells[2].getElementsByTagName("select")[0].value)
						return true;
				}

				return false;
			}

			//Bloqueamos la tecla BACKSPACE en la ventana
			function cancelarBackSpace()
			{
				if (event.keyCode == 119) {
					if (trEvaluacion.style.display != 'none')
						document.getElementById('btnEvaluar').click();
				}

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
				parent.cargarImagenEsperando();
			}

			function quitarImagenEsperando()
			{
				parent.quitarImagenEsperando();
			}

			function mostrarImagenCargando()
			{
				var loading1 = document.createElement("div");
				loading1.id = "loading1";
				loading1.style.color = "black";
				loading1.style.backgroundColor = "black";
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
				loading.style.right = screen.width /2;//"10px";
				loading.style.top = screen.height /2;//"10px";
				loading.style.zIndex = "9999";
				loading.innerHTML = "<img src='../../../images/cargando3.gif'>";
				document.body.appendChild(loading);
			}

			function quitarImagenCargando()
			{
				var loading1 = document.getElementById("loading1");
				if (loading1 != null)
				{
					document.body.removeChild(loading1);
					var loading = document.getElementById("loading");
					document.body.removeChild(loading);
				}
			}


			function mostrarLista(strDivLista, idFila)
			{
				var divLista = document.getElementById(strDivLista + idFila);
				if (divLista.style.display == 'none')
				{
					divLista.style.display = 'inline';
					divGrillaDetalle.style.height = '500px';
					divCondVent.style.height = '575px';
				}
				else
				{
					divLista.style.display = 'none';
					divGrillaDetalle.style.height = '100px';
					divCondVent.style.height = '175px';
				}
			}

			function ocultarListaTxt(idFila)
			{
				ocultarLista('txt', idFila);
			}

			function ocultarLista(control, idFila)
			{
				if (control != 'txt')
					estiloNoSel(control);

				var idElementoActivo = document.activeElement.id;

				if (idElementoActivo.indexOf('txtTextoEquipo' + idFila) < 0 &&
					idElementoActivo.indexOf('divOption' + idFila + '_') < 0 &&
					idElementoActivo.indexOf('divListaEquipo' + idFila) < 0)
				{
					document.getElementById('divListaEquipo' + idFila).style.display = 'none';
					divGrillaDetalle.style.height = '100px';
					divCondVent.style.height = '175px';
				}
			}

			function seleccionarItem(txtValor, txtTexto, divLista, div, idFila, prefijo)
			{
				var arrValores = div.id.split('_');
				var valor = '';
				if (arrValores.length > 1)
					valor = arrValores[1];
				txtValor += prefijo + idFila;
				txtTexto += prefijo + idFila;
				divLista += prefijo + idFila;
				//gaa20151102
				if (valor.indexOf('^') > -1) {
					valor = valor.replace('^', '');
					document.getElementById(txtTexto).style.color = '<%= ConfigurationSettings.AppSettings("BloqueoEquipoSinStockColor") %>';
					alert('<%= ConfigurationSettings.AppSettings("constMsjEquipoSinStockSel") %>');
				}
				else
					document.getElementById(txtTexto).style.color = '';
				//fin gaa20151102
				document.getElementById(txtValor).value = valor;
				document.getElementById(txtTexto).value = arrValores[2];
				document.getElementById(divLista).style.display = 'none';
				divGrillaDetalle.style.height = '100px';
				divCondVent.style.height = '175px';

				if (prefijo == 'Equipo')
					cambiarEquipo1(idFila)
			}

			function estiloSel(div) {
				div.className = "AutoComplete_Highlight";
			}
			function estiloNoSel(div) {
				div.className = "AutoComplete_Item";
			}
			function imgSel(img) {
				img.src = '../../../images/cmb.gif';
			}
			function imgNoSel(img) {
				img.src = '../../../images/cmb.gif';
			}

			function mostrarListaSel(idFila)
			{
				var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
				mostrarLista('divListaEquipo', idFila);
				txtTextoEquipo.select();
			}

			function selText(input, inicio, fin)
			{
				if (typeof document.selection != 'undefined' && document.selection)
				{
					tex=input.value;
					input.value='';
					input.focus();
					var str = document.selection.createRange();
					input.value=tex;
					str.move('character', inicio);
					str.moveEnd("character", fin-inicio);
					str.select();
				}
				else
					if(typeof input.selectionStart != 'undefined')
					{
						input.setSelectionRange(inicio,fin);
						input.focus();
					}
			}

			function buscarCoincidente(idFila)
			{
				var valorIngresado = window.event.keyCode;
				if (valorIngresado == 46)
					return;

				var hidValorEquipo = document.getElementById('hidValorEquipo' + idFila);
				var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
				var strTexto = txtTextoEquipo.value.toUpperCase();
				var strTextoCoincid;
				var strTextoEnc = '';
				var intLongTexto = strTexto.length;
				var strEquipos = getValue('hidMaterial' + idFila);
				var strCoincid = '';
				var arrEquipos = strEquipos.split('|');
				var arrEquipo;
				var strEquiposC = '';
				var divListaEquipo = document.getElementById('divListaEquipo' + idFila);
				var intIndEncontro = -1;

				if (intLongTexto > 0)
				{
					for (i = 0; i < arrEquipos.length; i++)
					{
						arrEquipo = arrEquipos[i].split(';');

						if (arrEquipo[0].length > 0)
						{
							strTextoCoincid = arrEquipo[1];

							if (strTextoCoincid.length >= intLongTexto)
							{
								strTextoCoincid = strTextoCoincid.toUpperCase();
								intIndEncontro = strTextoCoincid.indexOf(strTexto);

								if (intIndEncontro > -1)
									strEquiposC += '|' + arrEquipo[0] + ';' + arrEquipo[1];
							}
						}
					}
				}

				if (strEquiposC.length == 0)
					strEquiposC = strEquipos;

				llenarDatosCombo1(divListaEquipo, strEquiposC, idFila, 'Equipo', false);

				divListaEquipo.style.display = 'inline';
				divGrillaDetalle.style.height = '500px';
				divCondVent.style.height = '575px';

				if (valorIngresado == 40)
				{
					var arrDatos = strEquiposC.split('|');
					if (arrDatos.length > 1)
					{
						var arrItem = arrDatos[1].split(';');
						var divOpcion = document.getElementById('divOption' + idFila + '_' + arrItem[0] + '_' + arrItem[1] + '_' + 1);
						divOpcion.focus();

						setValue('hidEquiposSel', strEquiposC);
					}
				}
				else
				{
					hidValorEquipo.value = '';
					document.getElementById('txtEquipoPrecio' + idFila).value = 0;
					borrarCuota(idFila);

					calcularCFxProducto();
				}
			}

			function cambiarFocoSpan(strId, idFila)
			{
				var idSel = parseInt(strId.split('_')[3]);
				var idAnterior = idSel - 1;
				var idSiguiente = idSel + 1;
				var strEquipos = getValue('hidEquiposSel');
				var arrDatos = strEquipos.split('|');
				var strDato;
				var arrItem;
				var divAnterior = 0;
				var divSiguiente = 1;

				if (arrDatos[idAnterior].length > 0)
				{
					strDato = arrDatos[idAnterior];
					arrItem = strDato.split(";");

					if (strDato != 'null')
					{
						if (arrItem.length > 1)
							divAnterior = document.getElementById('divOption' + idFila + '_' + arrItem[0] + '_' + arrItem[1] + '_' + idAnterior);
					}
				}

				if (idSiguiente == arrDatos.length)
					idSiguiente = 0;

				if (arrDatos[idSiguiente].length > 0)
				{
					strDato = arrDatos[idSiguiente];
					arrItem = strDato.split(";");

					if (strDato != 'null')
					{
						if (arrItem.length > 1)
							divSiguiente = document.getElementById('divOption' + idFila + '_' + arrItem[0] + '_' + arrItem[1] + '_' + idSiguiente);
					}
				}


				if (window.event.keyCode == 40)
				{
					if (divSiguiente != 1)
						divSiguiente.focus();
				}
				else
				{
					if (window.event.keyCode == 38)
					{
						if (divAnterior != 0)
							divAnterior.focus();
						else
						{
							var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
							txtTextoEquipo.select();
							txtTextoEquipo.focus();
							return false;
						}

					}
					else
					{
						if (window.event.keyCode == 13)
						{
							seleccionarItem('hidValor', 'txtTexto', 'divLista', document.getElementById(strId), idFila, 'Equipo');
							return false;
						}
					}
				}
			}

			function inicializarEquipo(idFila)
			{
				var hidValorEquipo = document.getElementById('hidValorEquipo' + idFila);
				var txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
				var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);

				if (hidValorEquipo != null)
				{
					hidValorEquipo.value = '';
					txtTextoEquipo.value = 'SELECCIONE...';
					if (txtEquipoPrecio != null)
						txtEquipoPrecio.value = '';
					else
					{
						document.getElementById('txtPrecioInst' + idFila).value = 0;
						document.getElementById('txtCFMenAlqKit' + idFila).value = 0;
						document.getElementById('txtCFTotMensual' + idFila).value = 0;
					}

					calcularCFxProducto();
				}
			}

			function inicializarPrecioEquipo(idFila) {
				var txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);

				if (txtEquipoPrecio != null) {
					txtEquipoPrecio.value = '';

					calcularCFxProducto();
				}
			}
        
			function cambiarEquipo1(idFila)
			{
				cerrarCuota();
				borrarCuota(idFila);
				var strEquipo = document.getElementById('hidValorEquipo' + idFila).value;
				var codigoTipoProductoActual = getValue('hidCodigoTipoProductoActual');

				if (strEquipo.length == 0)
				{
					inicializarEquipo(idFila);
					return;
				}

				document.getElementById('hidValidarGuardarCuota').value = '';

				if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota) {
					inicializarPrecioEquipo(idFila);
				}
            
				var strEquipoDesc = document.getElementById('txtTextoEquipo' + idFila);
				var strPlan = document.getElementById('ddlPlan' + idFila).value;
				strPlan = getValor(strPlan, 0);
				var strPlazo = document.getElementById('ddlPlazo' + idFila).value;
				var strCampana = document.getElementById('ddlCampana' + idFila).value;

				if (getValor(strPlan, 0).length == 0 || strPlazo.length == 0 || strCampana.length == 0)
				{
					alert('Debe seleccionar el plan, plazo y campaña antes que el equipo')
					document.getElementById('hidValorEquipo' + idFila).value = '';
					document.getElementById('txtTextoEquipo' + idFila).value = '';
					return;
				}

				if (codigoTipoProductoActual != codTipoProdDTH)
					LlenarEquipoPrecioIfr(idFila, strPlan, strPlazo, strCampana, strEquipo);
				else
				{
					asignarEquipoPrecio(idFila, obtenerPrecioKit(idFila, document.getElementById('hidValorEquipo' + idFila).value));
					calcularCFxProducto();
				}
			}

			function asignarMaterial1(idFila)
			{
				var strMaterial = document.getElementById('hidMaterial').value;
				var divListaEquipo = document.getElementById('divListaEquipo' + idFila);

				inicializarEquipo(idFila);

				llenarDatosCombo1(divListaEquipo, strMaterial, idFila, 'Equipo', false);

				if (document.getElementById('imgVerCuota' + idFila) != null)
					borrarCuota(idFila);
			}

			function llenarDatosCombo1(div, strDatos, idFila, prefijo, booSeleccione)
			{
				var arrDatos;
				var arrItem;
				var strDato;
				var prefijo1 = prefijo + idFila;
				var strAnterior = '';
				var strSiguiente = '';
				if (div != undefined) {
					div.innerHTML = "";
				}
				
				if (booSeleccione)
				{
					if (div != undefined) {
						divOpcion = document.createElement('span');
						divOpcion.style.width = '100%';
						divOpcion.id = '';
						divOpcion.innerHTML = 'SELECCIONE...';
						document.getElementById('hidValor' + prefijo1).value = '';
						document.getElementById('txtTexto' + prefijo1).value = 'SELECCIONE...';

						divOpcion.className = "AutoComplete_Item";
						divOpcion.onmouseover = function() {estiloSel(this);};
						divOpcion.onmouseout = function() {estiloNoSel(this);};
						divOpcion.onclick = function() {seleccionarItem('hidValor', 'txtTexto', 'divLista', this, idFila, prefijo);};
						divOpcion.onfocus = function() {estiloSel(this);};
						//divOpcion.onblur = function() {estiloNoSel(this);};
						divOpcion.onblur = function() {ocultarLista(this, idFila);};
						div.appendChild(divOpcion);
					}
				}
				if (strDatos != null)
					var arrDatos = strDatos.split("|");
				else
					return;

				for (i = 0; i < arrDatos.length; i++)
				{
					if (div != undefined) {
					
						divOpcion = document.createElement('span');
						divOpcion.style.width = '100%';
						divOpcion.className = "AutoComplete_Item";
						divOpcion.onmouseover = function() {estiloSel(this);};
						divOpcion.onmouseout = function() {estiloNoSel(this);};
						divOpcion.onclick = function() {seleccionarItem('hidValor', 'txtTexto', 'divLista', this, idFila, prefijo);};
						divOpcion.onfocus = function() {estiloSel(this);};
						//divOpcion.onblur = function() {estiloNoSel(this);};
						divOpcion.onblur = function() {ocultarLista(this, idFila);};

						if (arrDatos[i].length > 0)
						{
							strDato = arrDatos[i];
							arrItem = strDato.split(";");

							if (strDato != 'null')
							{
								if (arrItem.length > 1)
								{
									//gaa20151029
									if (arrItem[0].indexOf('^') > -1) {
										divOpcion.style.color = '<%= ConfigurationSettings.AppSettings("BloqueoEquipoSinStockColor") %>';
										//arrItem[0] = arrItem[0].replace('^', '');
										//divOpcion.title = 'sto';
									}
									//fin gaa20151029
									divOpcion.id = 'divOption' + idFila + '_' + arrItem[0] + '_' + arrItem[1] + '_' + i;
									divOpcion.innerHTML = arrItem[1];

									divOpcion.onkeydown = function() {return cambiarFocoSpan(this.id, idFila);};
								}
								else
								{
									option.value = 'divOption_' + arrDatos[i] + '_' + arrDatos[i];
									divOpcion.innerHTML = arrDatos[i];
								}
								
								
								div.appendChild(divOpcion);
							}
						}
					}
				}
			}

			function cambiarSolucion(strSolucion, idFila)
			{
				LlenarPaquete3PlayIfr(strSolucion, idFila);
			}

			function LlenarPaquete3PlayIfr(strSolucion, idFila)
			{
				cargarImagenEsperando();

				var url = 'sisact_ifr_consulta_unificada.aspx?';
				url += 'idFila=' + idFila;
				url += '&strSolucion=' + strSolucion;
				url += '&strMetodo=' + "LlenarPaquete3Play";

				self.frames['iframeAuxiliar'].location.replace(url);
			}

			function asignarPaquete3Play(idFila, strValores)
			{
				strValores = validarPaqueteFijo(strValores);
				var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
				llenarDatosCombo(ddlPaquete, strValores, true);
			}

			function mostrarDetOfert(idFila)
			{
				var ddlPlan = document.getElementById('ddlPlan' + idFila);
				if (ddlPlan.value != '')
				{
					var nroSec = getValue('hidNroSec' + idFila);
					var str = '';

					if (nroSec.length == 0)
						str = obtenerCadenaDetOfert(idFila);

					var url = ''
					var w = 980;
					var h = 400;
					var	leftScreen =(screen.width - w) / 2;
					var topScreen = (screen.height - h) / 2;
					var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
					var strPaquete = obtenerTextoSeleccionado(document.getElementById('ddlPaquete' + idFila)).replace(/\+/g, '*');
					url = 'sisact_consulta_detalle_oferta.aspx?strDetalleHFC=' + str + '&strSolucion=' + obtenerTextoSeleccionado(document.getElementById('ddlSolucion' + idFila)) + '&strPaquete=' + strPaquete + '&nroSec=' + nroSec;

					window.open( url, '_blank',opciones);
				}
			}

			function obtenerCadenaDetOfert(idFila)
			{
				var tabla = document.getElementById('tblTablaHFC');
				var fila;
				var cont = tabla.rows.length;
				var nCell; //0: Imagen, 1:Imagen
				var arrPlanCodigo;
				var strTipoProducto;
				var strPlanCodigo;
				var strGrupo;
				var strTipo;
				var strProducto;
				var strServicio
				var strIdServicio;
				var strPromocion;
				var strResultado = '';
				var strFlgPrincipal;
				var strServicioCodigo;
				var idFila;
				var arrServicio;
				var strPrecio;

				//GRUPO/TIPO/PRODUCTO/IDSERVICIO/SERVICIO/PROMOCION/PRINCIPAL

				var strIdFilas = obtenerFilasGrupo(idFila, '', false);

				for (var i = 0; i < cont; i++)
				{
					nCell = 1; //0: Imagen Confirmar, 1:Imagen Eliminar

					fila = tabla.rows[i];

					strTipoProducto = getValue('hidCodigoTipoProductoActual');

					if (strTipoProducto == codTipoProd3Play)
					{
						nCell += 1;

						idFila = fila.cells[nCell].getElementsByTagName("select")[0].id.substring(8);

						if (strIdFilas.indexOf('[' + idFila + ']') < 0)
							continue;

						nCell += 3;

						//Servicio Principal
						arrPlanCodigo = fila.cells[nCell].getElementsByTagName("select")[0].value.split('_');
						strPlanCodigo = arrPlanCodigo[0];
						strServicio = obtenerTextoSeleccionado(fila.cells[nCell].getElementsByTagName("select")[0]);
						strServicioCodigo = arrPlanCodigo[0];
						strGrupo = arrPlanCodigo[4];
						strTipo = '1'; //Serv. Principal';
						strProducto = arrPlanCodigo[9];
						strIdServicio = arrPlanCodigo[10];
						strPrecio = arrPlanCodigo[1];

						strFlgPrincipal = '1';

						//Servicios Adicionales
						strResultado += obtenerPromocionDetOfert(idFila, strServicioCodigo, strGrupo, strTipo, strProducto, strIdServicio, strServicio, strPrecio, strFlgPrincipal, strResultado.length);
						strResultado += obtenerCadenaDetOfertServ(idFila);
					}
				}

				return strResultado;
			}

			function obtenerCadenaDetOfertServ(idFila)
			{
				var strPlanServicio = document.getElementById('hidPlanServicio').value;
				var posIniPS = strPlanServicio.indexOf('*ID*' + idFila);
				var posFinPS = 0;
				var arrServicio;
				var strServicio;
				var arrServicioCodigo;
				var strServicioCodigo;
				var strResultado = '';
				var strGrupo;
				var strTipo;
				var strProducto;
				var strIdServicio;
				var strPromocion;
				var strFlgPrincipal;
				var strPrecio;

				if (posIniPS > -1)
				{
					posFinPS = strPlanServicio.substring(posIniPS + 4).indexOf('*ID*') + 4;

					if (posFinPS == 3)
						posFinPS = strPlanServicio.length;
					else
						posFinPS += posIniPS;

					var arrPS = strPlanServicio.substring(posIniPS, posFinPS).split('|');

					for (var i = 1; i < arrPS.length; i++)
					{
						arrServicio = arrPS[i].split(';');
						strServicio = arrServicio[1];

						arrServicioCodigo = arrServicio[0].split('_');

						strServicioCodigo = arrServicioCodigo[3];
						strServicio = arrServicio[1];
						strGrupo = arrServicioCodigo[7];
						strTipo = '0'; //Adicional';
						strProducto = arrServicioCodigo[12];
						strIdServicio = arrServicioCodigo[13];
						strPrecio =  arrServicioCodigo[4];
						strFlgPrincipal = '0';

						strResultado += obtenerPromocionDetOfert(idFila, strServicioCodigo, strGrupo, strTipo, strProducto, strIdServicio, strServicio, strPrecio, strFlgPrincipal, 1);
					}
				}

				return strResultado;
			}

			function obtenerPromocionDetOfert(idFila, strCodSrv, strGrupo, strTipo, strProducto, strIdServicio, strServicio, strPrecio, strFlgPrincipal, intCantidadCar)
			{
				var strPromocion = getValue('hidPromocion');
				var posIni = strPromocion.indexOf('*ID*' + idFila);
				var posFin = 0;
				var arrPromociones;
				var arrPromocion;
				var strCodigo;
				var arrCodigo;
				var strIDDET;
				var strIDPRODUCTO;
				var strIDLINEA;
				var strPromoComodin = '{Promocion}';
				var strResultado = strGrupo + ';' + strTipo + ';' + strProducto + ';' + strIdServicio + ';' + strServicio + ';' + strPrecio + ';' + strPromoComodin + ';' + strFlgPrincipal;
				if (intCantidadCar > 0)
					strResultado = '|' + strResultado;
				var booEntro = false;

				if (posIni > -1)
				{
					posFin = strPromocion.substring(posIni + 4).indexOf('*ID*') + 4;

					if (posFin == 3)
						posFin = strPromocion.length;
					else
						posFin += posIni;

					arrPromociones = strPromocion.substring(posIni, posFin).split('|');

					for (var i = 1; i < arrPromociones.length; i++)
					{
						arrPromocion = arrPromociones[i].split(';');

						arrCodigo = arrPromocion[0].split('_');

						arrCodigo = arrCodigo[3].split('.');
						strIDDET = arrCodigo[0];
						strIDPRODUCTO = arrCodigo[1];
						strIDLINEA = arrCodigo[2];

						if (strCodSrv == strIDDET + '.' + strIDPRODUCTO + '.' + strIDLINEA)
						{
							if (booEntro)
								strResultado += '|' + strGrupo + ';' + ';' + ';' + ';' + ';' + ';' + arrPromocion[1] + ';' + strFlgPrincipal;
							else
							{
								strResultado = strResultado.replace(strPromoComodin, arrPromocion[1]);
								booEntro = true;
							}
						}
					}
				}

				strResultado = strResultado.replace(strPromoComodin, '');
				return strResultado;
			}

			function mostrarAllTablaInactivo()
			{
				tblTablaTituloMovil.style.display = 'none';
				tblTablaTituloFijo.style.display = 'none';
				tblTablaTituloBAM.style.display = 'none';
				tblTablaTituloDTH.style.display = 'none';
				tblTablaTituloHFC.style.display = 'none';

				tblTablaMovil.style.display = 'none';
				tblTablaFijo.style.display = 'none';
				tblTablaBAM.style.display = 'none';
				tblTablaDTH.style.display = 'none';
				tblTablaHFC.style.display = 'none';
			}

			function mostrarTablaActivo(tipoProducto)
			{
				document.getElementById('tblTablaTitulo' + tipoProducto).style.display = '';
				document.getElementById('tblTabla' + tipoProducto).style.display = '';
			}

			function verificarCondicServRI()
			{
				//Validar Si es CAC / DAC / Corner
				var strConstCanalCAC = '<%= ConfigurationSettings.AppSettings("constRoamingCAC") %>';
				var strConstCanalDAC = '<%= ConfigurationSettings.AppSettings("constRoamingDAC") %>';
				var strConstCanalCorner = '<%= ConfigurationSettings.AppSettings("constRoamingCorner") %>';
				
				//Validar Si es MASIVO / B2E / Corporativo
				var strConstMasivo = '<%= ConfigurationSettings.AppSettings("constRoamingMasivo") %>';
				var strConstB2E = '<%= ConfigurationSettings.AppSettings("constRoamingB2E") %>';
				var strConstCorporativo = '<%= ConfigurationSettings.AppSettings("constRoamingCorporativo") %>';
				
				if (parent.getValue('hidCanal') == strConstCanalCAC || parent.getValue('hidCanal') == strConstCanalDAC || parent.getValue('hidCanal') == strConstCanalCorner)
				{
					if (parent.getValue('hidTipoOferta') == strConstMasivo || parent.getValue('hidTipoOferta') == strConstB2E || parent.getValue('hidTipoOferta') == strConstCorporativo)
					{
						//Activar Flag para mostrar Roaming Internacional
						parent.setValue('hidFlagRoamingI', '1');
					}
				}
			}


			function f_MostrarTab(tipoProducto)
			{
				if (!verificarPlanes()) return;
				
				mostrarAllTablaInactivo();
				mostrarTablaActivo(tipoProducto);
				parent.mostrarAllTabInactivo();
				parent.mostrarTabActivo('td' + tipoProducto);
				

				//Seteo Codigo Tipo Producto Actual
				setValue('hidTipoProductoActual', tipoProducto);
				verificarCondicServRI();
				var idProducto;
				var desProducto;
				switch (tipoProducto)
				{
					case 'Movil': setValue('hidCodigoTipoProductoActual', codTipoProdMovil);
								idProducto = '2'; desProducto = 'Móvil'; 
								if (parent.getValue('hidFlagRoamingI') == '1')
								{
									parent.setValue('hidFlagRoamingI','1');
								}
								break;
					case 'Fijo': setValue('hidCodigoTipoProductoActual', codTipoProdFijo);
								desProducto = 'Fijo Inalámbrico'; 
								if (parent.getValue('hidFlagRoamingI') == '1')
								{
									parent.setValue('hidFlagRoamingI','');
								}
								break;
					case 'BAM': setValue('hidCodigoTipoProductoActual', codTipoProdBAM);
								idProducto = '32'; desProducto = tipoProducto; 
								if (parent.getValue('hidFlagRoamingI') == '1')
								{
									parent.setValue('hidFlagRoamingI','1');
								}
								break;
					case 'DTH': setValue('hidCodigoTipoProductoActual', codTipoProdDTH);
								idProducto = '8'; desProducto = 'Claro TV SAT'; 
								if (parent.getValue('hidFlagRoamingI') == '1')
								{
									parent.setValue('hidFlagRoamingI','');
								}
								break;
					case 'HFC': setValue('hidCodigoTipoProductoActual', codTipoProd3Play);
								desProducto = '3Play'; 
								if (parent.getValue('hidFlagRoamingI') == '1')
								{
									parent.setValue('hidFlagRoamingI','');
								}
								break;
				}

				autoSizeProducto();

				parent.document.getElementById('lblLCDisponiblexProd').innerHTML = desProducto + ':&nbsp;&nbsp;&nbsp;&nbsp;';
				if (tipoProducto == 'Fijo' || tipoProducto == 'HFC')
					calcularLCxProductoFijo();
				else
					calcularLCxProducto(idProducto);

				calcularCFxProducto();
				
			}
			
			function consultarEquipos(idFila)
			{
				var w = 750;
				var h = 190;
				var	leftScreen =(screen.width - w) / 2;
				var topScreen = (screen.height - h) / 2;
				var opciones = "directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=" + w + ",height=" + h + ",left=" + leftScreen + ",top=" + topScreen;
				var url = 'sisact_pop_consulta_equipo.aspx?';
				var stridFila = idFila;
				
				var strPlan = document.getElementById('ddlPlan' + idFila).value;
				var strPlanCodigo = getValor(strPlan, 0);
				var strPlanCodigoSap = getValor(strPlan, 2);
				var ddlPlazo = document.getElementById('ddlPlazo' + idFila);
				var strPlazo = ddlPlazo.value;
				var strtipoDoc = parent.getValue('hidTipoDocumento'); 
				var strpuntoVenta = parent.getValue('ddlPuntoVenta'); 
				
				if (strPlazo == '' || strPlazo == undefined)
				{
					alert('Seleccione un Plazo por favor!')
					return false;
				}
				
				if (strPlan == '' || strPlan == undefined)
				{
					alert('Seleccione un Plan por favor!')
					return false;
				}
				
				url += 'plazo=' + strPlazo + '&planCodigo=' + strPlanCodigo + '&planCodigoSap=' + strPlanCodigoSap + '&idFila=' + stridFila + '&tipoDoc=' + strtipoDoc + '&ptoVenta=' + strpuntoVenta;
				window.open( url, '_blank', opciones);
			}
			
			function calcularLCxProducto(idProducto)
			{
				var strLCDisponiblexProd = parent.document.getElementById('hidLCDisponiblexProd').value;
				var arrLCDisponiblexProd = strLCDisponiblexProd.split('|');

				for (var i = 0; i < arrLCDisponiblexProd.length; i++)
				{
					var array = arrLCDisponiblexProd[i].split(';');
					if (idProducto == array[0])
						parent.document.getElementById('txtLCDisponiblexProd').value = parseFloat(array[1]).toFixed(2);
				}
			}

			function calcularLCxProductoFijo()
			{
				var tipoProducto = getValue('hidTipoProductoActual');
				var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
				var tabla = document.getElementById('tblTabla' + tipoProducto);
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var strProductos = '';
				var dblLC = 0;

				if (codigoTipoProducto == codTipoProdFijo || codigoTipoProducto == codTipoProd3Play)
				{
					for (var i = 0; i < cont; i++)
					{
						fila = tabla.rows[i];

						if (codigoTipoProducto != codTipoProdDTH)
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
						else //ddlCampana
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

						if (codigoTipoProducto == codTipoProd3Play)
						{
							var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
							if (ddlPaquete != null)
							{
								strProductos += getValor(ddlPaquete.value, 2) + ',';
							}
						}
						else
						{
							var ddlPlan = document.getElementById('ddlPlan' + idFila);
							if (ddlPlan != null)
							{
								strProductos += getValor(ddlPlan.value, 7) + ',';
							}
						}
					}

					if (strProductos != '')
					{
						var strLCDisponiblexProd = parent.document.getElementById('hidLCDisponiblexProd').value;
						var arrLCDisponiblexProd = strLCDisponiblexProd.split('|');
						for (var i = 0; i < arrLCDisponiblexProd.length; i++)
						{
							var array = arrLCDisponiblexProd[i].split(';');
							if (array[0] != '')
							{
								if (strProductos.indexOf(array[0]) > 0)
									dblLC += parseFloat(array[1]);
							}
						}
					}

					parent.document.getElementById('txtLCDisponiblexProd').value = parseFloat(dblLC).toFixed(2);
				}
			}
//gaa20130522
			function tieneServicioVOD(idFila)
			{
				var strResultado = '';
				var strServicio = getValue('hidPlanServicio');
				var arrServicios;
				var strIdFila = '*ID*' + idFila;
				var strCodigo;
				var arrServicio;
				var intPosIni = strServicio.indexOf(strIdFila);
				var intPosFin = 0;

				if (intPosIni > -1)
				{
					intPosFin = strServicio.substring(intPosIni + 4).indexOf('*ID*');

					if (intPosFin == -1)
						intPosFin = strServicio.length;
					else
						intPosFin += intPosIni + 4;

					strServicio = strServicio.substring(intPosIni, intPosFin);

					arrServicios = strServicio.split('|');

					for (var i = 1; i < arrServicios.length; i++)
					{
						arrServicio = arrServicios[i].split('_');

						if (arrServicio[14].split(';')[0] == '1')
							return true;
					}
				}

				return false;
			}

			function verificarVOD()
			{
				var strFlagsVOD = document.getElementById('hidFlagVOD').value;
				var arrVOD;
				var arrVODactual;
				var tabla = document.getElementById('tblTablaHFC');
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var strFilas = '';
				var strFilasRevisadas = '';
				var strPlan;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);

					//evaluo si servicio principal seleccionado tiene vod = 1
					strPlanCodigo = document.getElementById('ddlPlan' + idFila).value;

					if (fila.style.display != 'none')
					{
						if (strPlanCodigo.split('_')[11] == '1' || tieneServicioVOD(idFila))
						{
							strFilas = obtenerFilasGrupo(idFila, '', false) + '';

							if (strFlagsVOD.indexOf('|') > -1)
							{
								arrVOD = strFlagsVOD.split('|');

								for (var j = 0; j < arrVOD.length; j++)
								{
									arrVODactual = arrVOD[j].split(':');
									if (strFilas.indexOf(arrVODactual[0]) && arrVODactual[1] == '0')
									{
										alert('El HUB asociado no está habilitado para VOD, no puede realizar la venta de este servicio.')
										return false;
									}
								}
							}
						}
					}
				}

				return true;
			}
//fin gaa20130522
			function agregarCarrito(mostrar)
			{
				if (!verificarPlanes())
					return;

				var tipoProducto = getValue('hidTipoProductoActual');
				var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
				var tabla = document.getElementById('tblTabla' + tipoProducto);
				var tablaResumen = document.getElementById('tbResumenCompras');
				var cont = tabla.rows.length;
				var tienePaquete = getValue('hidTienePaquete');
				var fila;
				var idFila;
				var newRow;
				var oCell;

				var strPlazo = '';
				var strPlan = '';
				var strCampana = '';
				var strEquipo = '';
				var strCargoFijoTotal = '';
				var strPrecioVentaEquipo = '';
				var strEquipoEnCuotas = '';
				var strNroCuotas = '';

				var ddlPlazo;
				var ddlPlan;
				var ddlCampana;
				var ddlEquipo;
				var hidValorEquipo;

				var strAgrupaPaquete;
				var blnAgregarItem;

				var filaActual;

				var tipoProductoVisual = tipoProducto;

				if (tipoProductoVisual == 'HFC')
					tipoProductoVisual = '3 Play';

				if (tipoProductoVisual == 'DTH')
					tipoProductoVisual = 'Claro TV SAT';

				if (tipoProductoVisual == 'FIJO' || tipoProductoVisual == 'Fijo')
					tipoProductoVisual = 'FIJO INALAMBRICO';

				if (getValue('hidTieneCuotas') != 'S')
				{
					tablaResumen.rows[0].cells[7].style.display = 'none';
					tablaResumen.rows[0].cells[8].style.display = 'none';
				}
				else
				{
					tablaResumen.rows[0].cells[7].style.display = '';
					tablaResumen.rows[0].cells[8].style.display = '';
				}

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					blnAgregarItem = true;

					if (fila.style.display != 'none')
					{
						if (codigoTipoProducto != codTipoProdDTH) //ddlPlazo
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
						else //ddlCampana
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

						ddlPlazo = document.getElementById('ddlPlazo' + idFila);
						if (ddlPlazo != null)
							strPlazo = obtenerTextoSeleccionado(ddlPlazo);

						ddlPlan = document.getElementById('ddlPlan' + idFila);
						if (ddlPlan != null)
							strPlan = obtenerTextoSeleccionado(ddlPlan);

						strCampana = '&nbsp;';
						ddlCampana = document.getElementById('ddlCampana' + idFila);
						if (ddlCampana != null)
						{
							if (ddlCampana.value != '')
								strCampana = obtenerTextoSeleccionado(ddlCampana);
						}

						strEquipo = '&nbsp;';
						ddlEquipo = document.getElementById('hidValorEquipo' + idFila);
						if (ddlEquipo != null)
						{
							if (ddlEquipo.value != '')
							{
								txtTextoEquipo = document.getElementById('txtTextoEquipo' + idFila);
								if (txtTextoEquipo != null)
									strEquipo = txtTextoEquipo.value;
							}
						}

						strCargoFijoTotal = calcularCF(idFila);

						strPrecioVentaEquipo = '0';
						txtEquipoPrecio = document.getElementById('txtEquipoPrecio' + idFila);
						if (txtEquipoPrecio != null)
							strPrecioVentaEquipo = txtEquipoPrecio.value;

						strEquipoEnCuotas = (confirmarCuota(idFila))? 'Si':'No';

						if (strEquipoEnCuotas == 'Si')
						{
							strNroCuotas = parseInt(obtenerCuotaValores(idFila)[0].split('_')[0]);

							if (isNaN(strNroCuotas))
								strNroCuotas = '0';

							if (strNroCuotas == '0')
								strEquipoEnCuotas = 'No';
						}
						else
							strNroCuotas = '0';

						if (codigoTipoProducto == codTipoProd3Play)
						{
							var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
							if (ddlPaquete != null)
							{
								strPlan = obtenerTextoSeleccionado(ddlPaquete);
								strAgrupaPaquete = obtenerPaqueteActual(idFila);
							}
							var idFilaPaquete = obtenerFilaPaquete(strAgrupaPaquete);
							if (idFila == idFilaPaquete)
								strCargoFijoTotal = calcularCF3Play(strAgrupaPaquete);
							else
								blnAgregarItem = false;
						}

						if (blnAgregarItem)
						{
							filaCarrito = obtenerFilaCarrito(idFila);

							if (filaCarrito == null) //Si es una fila nueva
							{
								newRow = tablaResumen.insertRow();

								oCell = newRow.insertCell();
								//oCell.style.width = '20px';
								oCell.align = 'center';
//gaa20130516
								//oCell.innerHTML = tipoProducto + "<input type='hidden' value=" + idFila + ">";
								oCell.innerHTML = tipoProductoVisual + "<input type='hidden' value=" + idFila + "><input type='hidden' value=" + tipoProducto + ">";
								oCell.className = 'TablaFilasGrid';
//fin gaa20130516
								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strPlazo;
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strPlan;
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strCampana;
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strEquipo;
								oCell.className = 'TablaFilasGrid';
								//gaa20151126
								if (document.getElementById('txtTextoEquipo' + idFila).style.color != '')
									oCell.style.color = '<%= ConfigurationSettings.AppSettings("BloqueoEquipoSinStockColor") %>';
								//fin gaa20151126
								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strCargoFijoTotal;
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strPrecioVentaEquipo;
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strEquipoEnCuotas;
								oCell.className = 'TablaFilasGrid';

								if (getValue('hidTieneCuotas') != 'S')
									oCell.style.display = 'none';
								else
									oCell.style.display = '';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = strNroCuotas;
								oCell.className = 'TablaFilasGrid';

								if (getValue('hidTieneCuotas') != 'S')
									oCell.style.display = 'none';
								else
									oCell.style.display = '';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = "";
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = "<img src='../../../images/editar.gif' border='0' style='cursor:hand' alt='Editar Fila' onclick='editarFilaCompra(" + idFila + ")' />";
								oCell.className = 'TablaFilasGrid';

								oCell = newRow.insertCell();
								oCell.align = 'center';
								oCell.innerHTML = "<img src='../../../images/rechazar.gif' border='0' style='cursor:hand' alt='Eliminar Fila' onclick='eliminarFilaTotal(null, " + idFila + ", true)' />";
								oCell.className = 'TablaFilasGrid';
							}
							else
							{
								filaCarrito.cells[1].innerHTML = strPlazo;
								filaCarrito.cells[2].innerHTML = strPlan;
								filaCarrito.cells[3].innerHTML = strCampana;
								filaCarrito.cells[4].innerHTML = strEquipo;
								filaCarrito.cells[5].innerHTML = strCargoFijoTotal;
								filaCarrito.cells[6].innerHTML = strPrecioVentaEquipo;
								filaCarrito.cells[7].innerHTML = strEquipoEnCuotas;
								filaCarrito.cells[8].innerHTML = strNroCuotas;
								filaCarrito.cells[9].innerHTML = '&nbsp;';
							}
						}
						fila.style.display = 'none';
					}

					calcularCFCarrito();
				}

				if (mostrar)
					trResumenCompras.style.display = '';
				document.getElementById('txtCFTotal').value = 0;
			}

			function cambiarLucesCarrito(strPlanAutonomia)
			{
				var arrPlanAutonomia = strPlanAutonomia.split('|');
				var idFila;
				var flgAutonomia;
				for (var x = 0; x < arrPlanAutonomia.length; x++)
				{
					if (arrPlanAutonomia[x] != '')
					{
						idFila = arrPlanAutonomia[x].split(';')[0];
						flgAutonomia = arrPlanAutonomia[x].split(';')[1];
						var filaCarrito = obtenerFilaCarrito(idFila);
						var imagen = '&nbsp;';

						// Cambio Temporal
						if (parent.getValue('ddlCanal') != '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>')
						{
							switch (flgAutonomia)
							{
								case 'S':
									imagen = "<img src='../../../images/imgColorVerde.gif' border='0' style='height:16px; width:16px' alt='Aprobado' />";
									break;
								case 'N':
									imagen = "<img src='../../../images/imgColorAmarillo.gif' border='0' style='height:16px; width:16px' alt='Requiere ir a créditos' />";
									break;
								case 'SIN_REGLAS':
									imagen = "<img src='../../../images/imgColorAmarillo.gif' border='0' style='height:16px; width:16px' alt='Requiere ir a créditos' />";
									break;
								case 'NO_CONDICION':
									imagen = "<img src='../../../images/imgColorRojo.gif' border='0' style='height:16px; width:16px' alt='No aplica condiciones de venta' />";
									break;
							}
						}
						filaCarrito.cells[9].innerHTML = imagen;
					}
				}
			}

			function tieneProductosFueraCarrito()
			{
				var fila;

				var tablaMovil = tblTablaMovil;
				var tablaFijo = tblTablaFijo;
				var tablaBAM = tblTablaBAM;
				var tablaDTH = tblTablaDTH;
				var tablaHFC = tblTablaHFC;

				var cont = tablaMovil.rows.length;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaMovil.rows[i];
					if (fila.style.display != 'none')
						return true;
				}

				var cont = tablaFijo.rows.length;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaFijo.rows[i];
					if (fila.style.display != 'none')
						return true;
				}

				var cont = tablaBAM.rows.length;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaBAM.rows[i];
					if (fila.style.display != 'none')
						return true;
				}

				var cont = tablaDTH.rows.length;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaDTH.rows[i];
					if (fila.style.display != 'none')
						return true;
				}

				var cont = tablaHFC.rows.length;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaHFC.rows[i];
					if (fila.style.display != 'none')
						return true;
				}

				return false;
			}

			function obtenerFilaCarrito(idFila)
			{
				var tablaResumen = document.getElementById('tbResumenCompras');
				var cont = tablaResumen.rows.length;
				var fila;
				var idFilaX;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaResumen.rows[i];

					hidFila = fila.cells[0].getElementsByTagName("input")[0];

					if (hidFila != null)
					{
						idFilaX = hidFila.value;

						if (idFila == idFilaX)
							return fila;
					}
				}
			}

			function obtenerFilaPaquete(strAgrupaPaquete)
			{
				var idFila = '';
				var strGrupo = strAgrupaPaquete.replace('{','').replace('}','');
				var arrGrupo = strGrupo.split(',');
				for (i = 0; i < arrGrupo.length; i++)
				{
					if (arrGrupo[i] != '')
					{
						idFila = arrGrupo[i].replace('[','').replace(']','');
						break;
					}
				}
				return idFila;
			}

			function calcularCF3Play(strGrupoPaquete)
			{
				var tabla = document.getElementById('tblTablaHFC');
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var strCargoFijo = 0;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];
					idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);

					var ddlPaquete = document.getElementById('ddlPaquete' + idFila);
					if (ddlPaquete != null)
					{
						strPlan = obtenerTextoSeleccionado(ddlPaquete);
						strAgrupaPaquete = obtenerPaqueteActual(idFila);
					}
					if (strGrupoPaquete == strAgrupaPaquete)
					{
						strCargoFijo += parseFloat(calcularCF(idFila));
					}
				}

				return strCargoFijo;
			}

			function calcularCF(idFila)
			{
				var strPlan = document.getElementById('ddlPlan' + idFila).value;
				var fltPlanCF = getValor(strPlan, 1);
				var txtCFPlanServicio = document.getElementById('txtCFPlanServicio' + idFila);
				var fltMontoServicios = document.getElementById('hidMontoServicios' + idFila).value;
				var hidMontoCuota = document.getElementById('hidMontoCuota' + idFila);
				var fltMontoCuota = 0;
				if (hidMontoCuota != null)
					fltMontoCuota = hidMontoCuota.value;

				if (isNaN(fltMontoServicios))
					fltMontoServicios = 0;

				if (isNaN(fltMontoCuota))
					fltMontoCuota = 0;

				if (fltMontoServicios.length == 0) fltMontoServicios = 0;
				if (fltMontoCuota.length == 0) fltMontoCuota = 0;

				txtCFPlanServicio.value = (parseFloat(fltPlanCF) + parseFloat(fltMontoServicios)).toFixed(2);
				var txtSubTotalCF = document.getElementById('txtSubTotalCF' + idFila);
				if (getValue('hidCodigoTipoProductoActual') != codTipoProdDTH)
					return (parseFloat(fltPlanCF) + parseFloat(fltMontoServicios) + parseFloat(fltMontoCuota)).toFixed(2);
				else
				{
					var fltEquipoPrecio = document.getElementById('txtCFTotMensual' + idFila).value;

					if (fltEquipoPrecio.length == 0)
						fltEquipoPrecio = 0;

					fltEquipoPrecio = parseFloat(fltEquipoPrecio);

					if (fltEquipoPrecio > 0)
						return fltEquipoPrecio;
					else
						return (parseFloat(fltPlanCF) + parseFloat(fltMontoServicios)).toFixed(2);
				}
			}

			function editarFilaCompra(idFila)
			{
				var strIdFilas = obtenerFilasGrupo(idFila, '', true) + '';
				strIdFilas = strIdFilas.replace('{', '').replace('}', '').replace('[', '').replace(']', '');
				var arrIdFilas = strIdFilas.split(',');
				var tablaResumen = document.getElementById('tbResumenCompras');
				var cont = tablaResumen.rows.length;
				var fila;
				var idFilaX;
				var hidFila;
				var booMostrarTab = false;
				var strTipoProducto = '';

				for (var i = 0; i < cont; i++)
				{
					fila = tablaResumen.rows[i];

					hidFila = fila.cells[0].getElementsByTagName("input")[0];

					if (hidFila != null)
					{
						idFilaX = hidFila.value;

						for (var k = 0; k < arrIdFilas.length; k++)
						{
							if (arrIdFilas[k] == idFilaX)
							{
								if (!booMostrarTab)
								{
									//f_MostrarTab(fila.cells[0].innerText);
									strTipoProducto = fila.cells[0].getElementsByTagName("input")[1].value;
									f_MostrarTab(strTipoProducto);
								}

								tablaResumen.deleteRow(i);
								eliminarItem(arrIdFilas[k]);
								cont--;
								i--;
								arrIdFilas.splice(k,1);
							}

							eliminarItem(arrIdFilas[k]);
						}
					}
				}

				arrIdFilas = strIdFilas.split(',');

				for (var x = 0; x < arrIdFilas.length; x++)
				{
					idFilaX = arrIdFilas[x];

					if (idFilaX.length > 0)
					{
						var ddlPlazo = document.getElementById('ddlPlazo' + idFilaX);
						ddlPlazo.parentElement.parentElement.style.display = '';

						editarFila(idFilaX, true);
						var imgEditarFila = document.getElementById('imgEditarFila' + idFila);

						if (document.getElementById('tblTabla' + strTipoProducto).rows.length == 1 && imgEditarFila != null)
							ddlPlazo.disabled = false;

					}
				}

				calcularCFCarrito();
				calcularCFxProducto();
				evaluar();
			}

			function eliminarFilaCompra(idFila, valorReemplazoGrupo)
			{
				var strIdFilas = obtenerFilasGrupo(idFila, valorReemplazoGrupo, true) + '';
				strIdFilas = strIdFilas.replace('{', '').replace('}', '').replace('[', '').replace(']', '');
				var arrIdFilas = strIdFilas.split(',');
				var tablaResumen = document.getElementById('tbResumenCompras');
				var cont = tablaResumen.rows.length;
				var fila;
				var idFilaX;
				var hidFila;
				var booElimino = false;

				for (var x = 0; x < arrIdFilas.length; x++)
				{
					for (var i = 0; i < cont; i++)
					{
						fila = tablaResumen.rows[i];

						hidFila = fila.cells[0].getElementsByTagName("input")[0];

						if (hidFila != null)
						{
							idFilaX = hidFila.value;

							if (arrIdFilas[x] == idFilaX)
							{
								booElimino = true;

								tablaResumen.deleteRow(i);

								cont--;
								i--;
							}
						}
					}
				}

				// Calcular nuevamente rentas
				if (booElimino)
				{
					calcularCFCarrito();
					evaluar();
				}
			}

			function evaluar()
			{
				parent.document.getElementById('hidCadenaDetalle').value = getValue('hidCadenaDetalle');
				if (getValue('hidCadenaDetalle') == '')
				{
					trResumenCompras.style.display = 'none';
					document.getElementById('txtCFTotalCarrito').value = 0;

					parent.trAdjuntoPorta.style.display = 'none';
					parent.inicializarPanelResultado();
					parent.inicializarPanelComentarios();
					parent.inicializarPanelGrabar();
				}
				else
				{
					parent.document.getElementById('hidPlanDetalle').value = planesEvaluados(getValue('hidCadenaDetalle'));
					setValue('hidFlagEvaluar', '1');
					parent.consultaReglasCreditos();
				}
			}

			function obtenerFilasGrupo(idFila, valorReemplazoGrupo, booQuitarCorchetes)
			{
				var hidGrupoPaquete = document.getElementById('hidGrupoPaquete');
				var strGrupoPaquete = hidGrupoPaquete.value;
				var strVB = '[' + idFila + ']';
				var intPosFin = strGrupoPaquete.indexOf(strVB);
				var intPosIni;
				var intPosFin;
				var arrGrupo;
				var strResultado = '';

				if (intPosFin > -1)
				{
					intPosIni = strGrupoPaquete.substring(0, intPosFin).lastIndexOf('{') + 1;
					intPosFin = strGrupoPaquete.substring(intPosIni).indexOf('}') + intPosIni;

					arrGrupo = strGrupoPaquete.substring(intPosIni, intPosFin).split(',')

					for (var i = 1; i < arrGrupo.length; i++)
					{
						if (booQuitarCorchetes)
							strResultado += ',' + arrGrupo[i].replace('[','').replace(']', '');
						else
							strResultado += ',' + arrGrupo[i];
					}

					hidGrupoPaquete.value = strGrupoPaquete.replace(valorReemplazoGrupo, '');

					return strResultado;
				}
				else
					return idFila;
			}

			function eliminarFilaTotal(fila, idFila, mostrarAdvertencia)
			{
				var valor = eliminarFilaGrupo(fila, idFila, mostrarAdvertencia, false);
				if (valor != false){
					eliminarFilaCompra(idFila, valor);
					var tabla = document.getElementById('tblTabla' + getValue('hidTipoProductoActual'));
					var cont = tabla.rows.length;
					if (cont == 0){
						parent.setEnabled('btnAgregarPlan', true, 'Boton');	
						parent.habilitarBoton('btnEvaluar', 'Evaluar', true);
						parent.document.getElementById('trEvaluarResultado').style.display = 'none';
						parent.document.getElementById('trResultado').style.display = 'none';
						
						//Inicio Renovacion Anticipada JAZ
						var nMaxMesesARenovar = parseInt(parent.getValue('hidMesesMaxASMax'));
						var nMesPorVencer = parseInt(parent.getValue('hidMesesPorVencer'));
												
						//Si se excedio el límite de meses a renovar
						if (nMesPorVencer > nMaxMesesARenovar ) {							
							var sCodTipRenoRegular = '<%= ConfigurationSettings.AppSettings("constCodTipoRenovRegular") %>';
							parent.setValue('ddlTipoRenovacion', sCodTipRenoRegular);
							parent.setEnabled('ddlTipoRenovacion', false, '');
																					
						} else {
						parent.setEnabled('ddlTipoRenovacion', true, '');
						parent.document.getElementById('ddlTipoRenovacion').selectedIndex = 0;
						}																		
						parent.document.getElementById('hidMantenerPlan').value = 'S';//Si mantiene su plan
						//Fin Renovacion Anticipada JAZ	
												
						parent.setEnabled('chkPlanNoVigente', true, '');
						parent.document.getElementById('chkPlanNoVigente').checked = false;
						
						//inicio campañas nuevas 26/11/2015
						parent.setEnabled('ddlGProducto', true, '');
						parent.document.getElementById('ddlGProducto').selectedIndex = 0;
						setValue('hidCampanasMovil', '');
						
						//fin campañas nuevas 26/11/2015
						
						var tipoProducto = getValue('hidTipoProductoActual');
						switch (tipoProducto)
						{
							case 'Movil':
										if (parent.isVisible('tdBAM')) { parent.setEnabled('tdBAM', true, 'tab_inactivo'); }
										if (parent.isVisible('tdDTH')) { parent.setEnabled('tdDTH', true, 'tab_inactivo'); }
										if (parent.isVisible('tdHFC')) { parent.setEnabled('tdHFC', true, 'tab_inactivo'); }
										if (parent.isVisible('tdFijo')) { parent.setEnabled('tdFijo', true, 'tab_inactivo'); } 
										break;		
							case 'BAM': 
										if (parent.isVisible('tdMovil')) { parent.setEnabled('tdMovil', true, 'tab_inactivo'); }
										if (parent.isVisible('tdDTH')) { parent.setEnabled('tdDTH', true, 'tab_inactivo'); }
										if (parent.isVisible('tdHFC')) { parent.setEnabled('tdHFC', true, 'tab_inactivo'); }
										if (parent.isVisible('tdFijo')) { parent.setEnabled('tdFijo', true, 'tab_inactivo'); }
										break;
						}
						document.getElementById('hidTotalLineas').value = '0';
					}
				}
				calcularCFCarrito();
				calcularLCxProductoFijo();
				
				//PROY-32129 :: INI
				Anthem_InvokePageMethod('EliminarAlumno',[idFila], EliminarAlumno_Callback);
				//PROY-32129 :: FIN
			}

			function calcularCFxProducto()
			{
				var codigoTipoProducto = getValue('hidCodigoTipoProductoActual');
				var tipoProducto = getValue('hidTipoProductoActual');
				var tabla = document.getElementById('tblTabla' + tipoProducto);
				var cont = tabla.rows.length;
				var fila;
				var idFila;
				var total = 0;

				for (var i = 0; i < cont; i++)
				{
					fila = tabla.rows[i];

					if (fila.style.display != 'none')
					{
						if (codigoTipoProducto != codTipoProdDTH) //ddlPlazo
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(8);
						else //ddlCampana
							idFila = fila.cells[3].getElementsByTagName("select")[0].id.substring(10);

						total += parseFloat(calcularCF(idFila));
					}
				}

				document.getElementById('txtCFTotal').value = total.toFixed(2);
				parent.setValue('hidCargoFijoNuevo', total.toFixed(2));
				parent.CalcularFactorRenovacion();
			}

			function calcularCFCarrito()
			{
				var tablaResumen = document.getElementById('tbResumenCompras');
				var cont = tablaResumen.rows.length;
				var fila;
				var total = 0;

				for (var i = 0; i < cont; i++)
				{
					fila = tablaResumen.rows[i];

					hidFila = fila.cells[0].getElementsByTagName("input")[0];

					if (hidFila != null)
						total += parseFloat(fila.cells[5].innerHTML);
				}

				document.getElementById('txtCFTotalCarrito').value = total.toFixed(2);
			}

			function autoSizeIframe()
			{
				parent.autoSizeIframe();
			}

			function obtenerProductoxIdFila(idFila)
			{
				var idProducto;
				var tablaProducto;
				var arrDetalle = getValue('hidCadenaDetalle').split('|');
				for (var x = 0; x < arrDetalle.length; x++)
				{
					if (arrDetalle[x] != '')
					{
						if (arrDetalle[x].split(';')[0] == idFila)
							idProducto = arrDetalle[x].split(';')[1];
					}
				}
				switch (idProducto)
				{
					case codTipoProdMovil: tablaProducto = 'Movil'; break;
					case codTipoProdFijo: tablaProducto = 'Fijo'; break;
					case codTipoProdBAM: tablaProducto = 'BAM'; break;
					case codTipoProdDTH: tablaProducto = 'DTH'; break;
					case codTipoProd3Play: tablaProducto = 'HFC'; break;
				}

				if (tablaProducto == null && tablaProducto == undefined)
					tablaProducto = getValue('hidTipoProductoActual');

				return tablaProducto;
			}

			function inicio()
			{
			//PROY-24724-IDEA-28174-INICIO
			codServProteccionMovil = getValue('hidCodServProteccionMovil');
			concatCodTipoPdvProteccionMovil = getValue('hidCanalesPermitidosPrimaSeguros');
			//PROY-24724-IDEA-28174-FIN
				//Cuotas
				if (parent.getValue('ddlModalidad') == constModalidadPagoEnCuota) {
					setValue('hidTieneCuotas', 'S');
					mostrarColumnaCuota(true);
				} else {
					setValue('hidTieneCuotas', 'N');
					mostrarColumnaCuota(false);
				}
            
				parent.document.getElementById('hidNroConsultaBRMS').value = '0';
				
				//Inicio 09012014
				LeerCursorSaldos();
				//Fin 09012014

				//SEC Pendiente
				var strValor = parent.getValue('hidCadenaSECPendiente');
				if (strValor != '') {
					parent.document.getElementById('hidCadenaSECPendiente').value = '';
					parent.mostrarTabxOferta();
					mostrarSecPendiente(strValor);
				}
				else
					parent.mostrarTabxOferta();
			}

			function autoSizeProducto()
			{
				var size;
				var hidTienePaquete = document.getElementById('hidTienePaquete');
				var ddlOferta = parent.document.getElementById('ddlOferta');
				var tipoProducto = document.getElementById('hidTipoProductoActual').value;
				//gaa20161020
				document.getElementById('tdFamiliaPlanMovil').style.display = 'none';
				//fin gaa20161020
				switch (tipoProducto)
				{
					case 'Movil': size = '1100px'; break;
					case 'Fijo': size = '925px'; break;
					case 'BAM': size = '925px'; break;
					case 'DTH': size = '1120px'; break;
					case 'HFC': size = '1140px'; break;
				}
				if (ddlOferta.value == '<%= ConfigurationSettings.AppSettings("TipoProductoBusiness") %>')
				{
					hidTienePaquete.value = 'S';
					mostrarColumna(columnaPaquete, true);
					if (tipoProducto == 'Movil')
					{
						document.getElementById('divGrillaCabecera').style.width = '1150px';
						document.getElementById('divGrillaDetalle').style.width = '1150px';
					}
					else
					{
						document.getElementById('divGrillaCabecera').style.width = size;
						document.getElementById('divGrillaDetalle').style.width = size;
					}
				}
				else if (ddlOferta.value == '<%= ConfigurationSettings.AppSettings("constCodTipoProductoB2E") %>')
				{
					hidTienePaquete.value = 'N';
					mostrarColumna(columnaPaquete, false);
					document.getElementById('divGrillaCabecera').style.width = size;
					document.getElementById('divGrillaDetalle').style.width = size;
					
					//Inicio JAZ B2E
					document.getElementById('tdPaqueteClaroPuntos').style.display = "none";
					document.getElementById('tdPaqueteClaroPuntos1').style.display = "none";
					//Fin JAZ B2E
				}
				else {
				
					//Validacion Claro putos 
						var strCanalCorner = getValue('hidTipoCanal');
						if(strCanalCorner != '<%= ConfigurationSettings.AppSettings("constCodTipoOficinaCorner") %>'){
							document.getElementById('tdPaqueteClaroPuntos').style.display = "block";
							document.getElementById('tdPaqueteClaroPuntos1').style.display = "block";
							
						}else{
							document.getElementById('tdPaqueteClaroPuntos').style.display = "none";
							document.getElementById('tdPaqueteClaroPuntos1').style.display = "block";
						}
				
					hidTienePaquete.value = 'N';
					mostrarColumna(columnaPaquete, false);
					document.getElementById('divGrillaCabecera').style.width = size;
					document.getElementById('divGrillaDetalle').style.width = size;
					//gaa20161020
					if (familiaFlag == '1')
						document.getElementById('tdFamiliaPlanMovil').style.display = 'inline';
					//fin gaa20161020
				}
				//Portabilidad
				if (parent.getValue('hidTienePortabilidad') == 'S')
				{
					//mostrarColumna(columnaPortabilidad, true);
					mostrarColumnaPorta(true);
					document.getElementById('divGrillaCabecera').style.width = '1040px';
					document.getElementById('divGrillaDetalle').style.width = '1040px';
				}
			}

			function mostrarSecPendiente(strValor)
			{
				if (strValor == null)
					return;

				if (strValor.indexOf('~') < 0)
					return;

				var arrValorTotal = strValor.split('~');
				var arrValor = arrValorTotal[0].split('¬');

				var ddlTipoOperacion = parent.document.getElementById('ddlTipoOperacion');
				ddlTipoOperacion.value = arrValor[5];
				parent.document.getElementById('hidTipoOperacion').value = arrValor[5];

				var ddlOferta = parent.document.getElementById('ddlOferta');
				ddlOferta.value = arrValor[0];
				parent.document.getElementById('hidTipoOferta').value = arrValor[0];

				parent.asignarCasoEspecial(arrValor[4], arrValor[2]);
				mostrarSecPendiente1(arrValorTotal[1], arrValor[3]);
				setValue('hidGrupoPaquete', arrValor[1]);

				var hidCodigoTipoProductoActual = document.getElementById('hidCodigoTipoProductoActual');
				var hidTipoProductoActual = document.getElementById('hidTipoProductoActual');
				var strCadenaDetalle = '';

				hidCodigoTipoProductoActual.value = codTipoProdMovil;
				hidTipoProductoActual.value = 'Movil';
				strCadenaDetalle = guardarItem();
				//setValue('hidCadenaDetalle', guardarItem());
				agregarCarrito(false);

				hidCodigoTipoProductoActual.value = codTipoProdFijo;
				hidTipoProductoActual.value = 'Fijo';
				strCadenaDetalle = strCadenaDetalle + guardarItem();
				//setValue('hidCadenaDetalle', guardarItem());
				agregarCarrito(false);

				hidCodigoTipoProductoActual.value = codTipoProdBAM;
				hidTipoProductoActual.value = 'BAM';
				strCadenaDetalle = strCadenaDetalle + guardarItem();
				//setValue('hidCadenaDetalle', guardarItem());
				agregarCarrito(false);

				hidCodigoTipoProductoActual.value = codTipoProdDTH;
				hidTipoProductoActual.value = 'DTH';
				strCadenaDetalle = strCadenaDetalle + guardarItem();
				//setValue('hidCadenaDetalle', guardarItem());
				agregarCarrito(false);

				hidCodigoTipoProductoActual.value = codTipoProd3Play;
				hidTipoProductoActual.value = 'HFC';
				strCadenaDetalle = strCadenaDetalle + guardarItem();
				//setValue('hidCadenaDetalle', guardarItem());
				agregarCarrito(false);

				setValue('hidCadenaDetalle', strCadenaDetalle);

				hidCodigoTipoProductoActual.value = codTipoProdMovil;
				hidTipoProductoActual.value = 'Movil';

				parent.mostrarTabxOferta();
				setValue('hidFlagEvaluar', '1');
				parent.document.getElementById('hidCadenaDetalle').value = getValue('hidCadenaDetalle');
				
				consultaReglasCreditos();
				trResumenCompras.style.display = '';
			}

			function mostrarPromociones(tipoServicio, strCodSrv)
			{
				var lbxPD;
				if (tipoServicio == 'D')
					lbxP = document.getElementById('lbxPromocionesDisponibles');
				else
					lbxP = document.getElementById('lbxPromocionesSeleccionadas');

				var strPromociones = getValue('hidPromociones');
				var arrPromociones = strPromociones.split('|');
				var arrPromocion;
				var strPromocion;
				var strCodProm = '';
				var arrCodProm;
				var strIDDET;
				var strIDPRODUCTO;
				var strIDLINEA;
				var intPosIni;
				var k = -1;

				strCodSrv = strCodSrv.split('_')[3];
				intPosIni = strPromociones.indexOf(strCodSrv);

				lbxP.innerHTML = "";

				if (intPosIni > -1)
				{
					for (var j = 1; j < arrPromociones.length; j++)
					{
						strPromocion = arrPromociones[j];
						arrPromocion = strPromocion.split('_');
						strCodProm = arrPromocion[0];
						arrCodProm = strCodProm.split('.');
						strIDDET = arrCodProm[0];
						strIDPRODUCTO = arrCodProm[1];
						strIDLINEA = arrCodProm[2];

						strFLGEDI = arrPromocion[3];

						if (strCodSrv == strIDDET + '.' + strIDPRODUCTO + '.' + strIDLINEA)
						{
							k++;

							var option = document.createElement('option');
							option.value = strCodProm;
							option.text = strPromocion.split(';')[1];
							lbxP.options[k] = option;
						}
					}
				}
				
	                          //Se valida que es Servicio Roaming Internacional
				if (tipoServicio == 'A')
				{
					if (strCodSrv == '<%= ConfigurationSettings.AppSettings("codServRoamingI") %>')
						document.getElementById('tblRoamingI').style.display = 'inline';
					else
						document.getElementById('tblRoamingI').style.display = 'none';
						
				}
			}
			
	               function f_cambiarPlazoRI(codPlazo)
			{
				var objectValue = codPlazo;
				if (objectValue == '02')
				{
					document.getElementById('tdTxtFechaDesde').style.display = '';
					document.getElementById('tdLblFechaDesde').style.display = '';
					document.getElementById('tdTxtFechaHasta').style.display = 'none';
					document.getElementById('tdLblFechaHasta').style.display = 'none';
				}
				else
				{
					document.getElementById('tdTxtFechaDesde').style.display = '';
					document.getElementById('tdLblFechaDesde').style.display = '';
					document.getElementById('tdTxtFechaHasta').style.display = '';
					document.getElementById('tdLblFechaHasta').style.display = '';
				}
			}
			
			// JavaScript para Claro Puntos
		
			function consultarSaldoPuntos(idFila)
			{
				if(document.getElementById('tblServicios').style.display == 'inline') return;
				
				parent.document.getElementById('trEvaluarResultado').style.display = 'none';	
				document.getElementById('tblPuntosCC').style.display = 'inline';
				parent.autoSizeIframe();
			}
			
			
			function CerrarSaldoCC()
			{
				parent.document.getElementById('trEvaluarResultado').style.display = '';	
				document.getElementById('tblPuntosCC').style.display = 'none';
				parent.autoSizeIframe();
			}
			
			function EnviarDscto() {
				document.getElementById('tblPuntosCC').style.display = 'none';
			}
			
			
			function CalcularClaroClubPuntos(obj, flag) {
				
				parent.document.getElementById('lblClaroClubMsgError').innerHTML = "";
				
				try {
					// Validaciones previas.
					if (obj.value.length == 0 || obj.value == 0) {
						parent.setValue("txtClaroClubPuntosUtilizar", "0");
						//setValue("txtClaroClubSolesDeDescuento", "0");	
						parent.setValue("txtDescuentoClaroClub", "0.00");
						//parent.setValue('txtTotalAPagar', parent.getValue('txtPrecioVenta'));
						
						//var precioVenta = parseFloat(parent.getValue('txtPrecioVenta'));
						//var descuentoEquipo = 0.0;
						//var dcto = parent.getValue('txtDescuentoEquipo');
						
							        var precioChip = 0.0;
									var precioEquipo = 0.0;
									var hidValidarIccid = parent.getValue('hidValidarIccid');
						            var PrecioNeto = 0.0;
									var descuentoEquipo = 0.0;
									var precioVenta = parseFloat(parent.getValue('txtPrecioVenta'));
									
									
									if(parent.getValue('txtDescuentoEquipo') != '')
									{
									   descuentoEquipo = parseFloat(parent.getValue('txtDescuentoEquipo'));
									}
									
								
                                    
                                    if(parent.getValue('txtpreciochip') != ''){
                                       precioChip = parseFloat(parent.getValue('txtpreciochip'));
                                    }
                                    if(parent.getValue('txtPrecioVentaEquipo') != ''){
                                       precioEquipo = parseFloat(parent.getValue('txtPrecioVentaEquipo'));
                                    }
								
									
								     
									if(hidValidarIccid == "1"){
									  PrecioNeto = precioVenta + precioChip - (descuentoEquipo);
									}
									else{
									  PrecioNeto = precioVenta - (descuentoEquipo);
									 
									}

								
									//Validar Precio de venta
										
										if (PrecioNeto <= 0){
											parent.setValue('hidPrecioTotal', '0');
											parent.setValue('txtTotalAPagar', '0');
										}else{
											parent.setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
											parent.setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
									}
				
						return;
					}
					if (obj.id == "txtClaroClubPuntosUtilizar") {
					  
						if (parseFloat(parent.getValue('txtClaroClubPuntosUtilizar')) > parseInt(getValue('hidClaroClubPuntosUtilizar'))) { //Modificado 22112013
							parent.document.getElementById('lblClaroClubMsgError').innerHTML = "Los puntos ingresados exceden la cantidad disponible.";
							ResetCifrasCC();
							return;
						}
						
						// Verificar que se cumpla el mínimo en puntos.
						//if (parseInt(getValue('hidClaroClubSolesDeDescuento')) >= 11)
						//{
							if (parseInt(parent.getValue('txtClaroClubPuntosUtilizar')) < parseInt(getValue('hidCCMinimoPuntos')))
							{
								parent.document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorCCPuntosMinimos');
								ResetCifrasCC();
								return;
							}
						//}
						
					} 
					else {
						if (parseFloat(getValue('txtClaroClubSolesDeDescuento')) > parseFloat(getValue('hidClaroClubSolesDeDescuento'))) {
							parent.document.getElementById('lblClaroClubMsgError').innerHTML = "Los soles ingresados exceden los soles disponibles.";
							ResetCifrasCC();
							return;
						}
					}
					
					var resu;					
					resu = CalcClaroClubPuntos(obj.id,
					                           parent.getValue('txtClaroClubPuntosUtilizar'),
					                           getValue('txtClaroClubSolesDeDescuento'));
	
					if (resu == "-1") {
						parent.document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorClaroClubDesfase');
						ResetCifrasCC();
					} 
					else {																	
						switch (obj.id) {
							case "txtClaroClubPuntosUtilizar":		
							 	
								//setValue('txtClaroClubSolesDeDescuento', resu);	
								parent.setValue('txtDescuentoClaroClub', resu.toString());  //+ ".00"	
								
								if (parent.getValue('txtPrecioVenta').length > 0) {
									var precioVenta = parseFloat(parent.getValue('txtPrecioVenta'));
									var precioChip = 0.0;
									var precioEquipo = 0.0;
									var hidValidarIccid = parent.getValue('hidValidarIccid');
						            var PrecioNeto = 0.0;
									var descuentoEquipo = 0.0;
									var descuentoClaroClub = 0.0;
									var descuentoEquipo = 0.0;
									var descuentoClaroClub = 0.0;
									
									if(parent.getValue('txtDescuentoEquipo') != '')
									{
									   descuentoEquipo = parseFloat(parent.getValue('txtDescuentoEquipo'));
									}
									
									if(parent.getValue('txtDescuentoClaroClub') != ''){
									  descuentoClaroClub = parseFloat(parent.getValue('txtDescuentoClaroClub'));
									}
                                    
                                    if(parent.getValue('txtpreciochip') != ''){
                                       precioChip = parseFloat(parent.getValue('txtpreciochip'));
                                    }
                                    if(parent.getValue('txtPrecioVentaEquipo') != ''){
                                       precioEquipo = parseFloat(parent.getValue('txtPrecioVentaEquipo'));
                                    }
								
									
								     
									if(hidValidarIccid == "1"){
									  PrecioNeto = precioVenta + precioChip - (descuentoEquipo + descuentoClaroClub);
									}
									else{
									  PrecioNeto = precioVenta - (descuentoEquipo + descuentoClaroClub);
									 
									}
									
								    
									//Validar Precio de venta
										
										if (PrecioNeto <= 0){
											parent.setValue('hidPrecioTotal', '0');
											parent.setValue('txtTotalAPagar', '0');
										}else{
									parent.setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
									parent.setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
									
								}
								
								var resta = precioVenta -  descuentoClaroClub;
						
								if (flag != '0'){
									if(resta < 1){
										parent.document.getElementById('lblClaroClubMsgError').innerHTML = "El saldo a descontar excede el precio de equipo." ;
										ResetCifrasCC();
										return;
									}
								}
								
								}
								break;
							case "txtClaroClubSolesDeDescuento":		
							   	
								// Verificar si el resultado de la conversión (a puntos) no excede los puntos disponibles.							
								if (parseFloat(resu) > parseFloat(getValue('hidClaroClubPuntosUtilizar'))) {
									parent.document.getElementById('lblClaroClubMsgError').innerHTML = "Los puntos equivalentes exceden los puntos disponibles.";
									ResetCifrasCC();
									return;
								}

								parent.setValue('txtClaroClubPuntosUtilizar', resu);
								parent.setValue('txtDescuentoClaroClub', parseFloat(getValue('txtClaroClubSolesDeDescuento')) ); //+ ".00"
								
								if (parent.getValue('txtPrecioVenta').length > 0) {
									var precioVenta = parseFloat(parent.getValue('txtPrecioVenta'));
									var descuentoClaroClub = parseFloat(parent.getValue('txtDescuentoClaroClub'));
									var descuentoEquipo = 0.0;
									var PrecioNeto = precioVenta - (descuentoEquipo + descuentoClaroClub);
									
										//Validar Precio de venta
										
										if (PrecioNeto <= 0){
											parent.setValue('hidPrecioTotal', '0');
											parent.setValue('txtTotalAPagar', '0');
										}else{
									parent.setValue('hidPrecioTotal', PrecioNeto.toFixed(2));
									parent.setValue('txtTotalAPagar', PrecioNeto.toFixed(2));
								}
								}
								break;							
						}
					}
					
					parent.setValue('hidFactorClaroClub', getValue('hidFactorClaroClub'));
					parent.setValue('hidIDCAMPANA', getValue('hidIDCAMPANA'));
				} 
				catch (ex) {
					parent.document.getElementById('lblClaroClubMsgError').innerHTML = getValue('hidErrorClaroClubDesfase');
					parent.setValue('txtClaroClubPuntosUtilizar', getValue('hidClaroClubPuntosUtilizar'));
					//setValue('txtClaroClubSolesDeDescuento', getValue('hidClaroClubSolesDeDescuento'));
					parent.setValue('txtDescuentoClaroClub', getValue('hidClaroClubSolesDeDescuento'));
				}
			}
			
			// Acepta solo datos de tipo fecha, mask(##/##/####)
			// No restringe la longitud del dato.
			function SoloEnteros(event, obj) {
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				var salida = false;
				var key = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey) {
					return false;
				}
				
				var CaracteresPermitidos = '0123456789';
				var valid = new String(CaracteresPermitidos);
				for (var i = 0; i < valid.length; i++) {
					if (key == valid.substring(i, i + 1))
						salida = true;
				}
				
				if (code == 8) { // Allow backspace, F5
					return true;
				} else if ((code >= 37 && code <= 40) && (code != 39)) { // Allow directional arrows
					return true;
				} else if (code == 9 || code == 16) {// tab control + tab
					return true;
				}
				
				return salida;
			}
			
			// Acepta solo numero entero o decimales con un punto (opcional)
			// No restringe la longitud del numero o de los decimales.
			function SoloNumerosReales(event, obj) {
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				var salida = false;
				var key = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey) {
					return false;	
				}				
				// Solo permitir un punto decimal.
				if (key == ".") {
					if (obj.value.indexOf('.') >= 0) {
						return false;
					} else {
						return true;
					}
				}
				
				var CaracteresPermitidos = '0123456789';
				var valid = new String(CaracteresPermitidos);
				for (var i = 0; i < valid.length; i++) {
					if (key == valid.substring(i, i + 1))
						salida = true;
				}
				
				if (code == 8){ // Allow backspace, F5
					return true;
				}else if ((code >=37 && code <= 40) && (code != 39)){ // Allow directional arrows
					return true;
				}else if (code == 9 || code == 16){ // tab control + tab
					return true;
				}
				
				return salida;
			}
			
			// Realiza la operaciòn calculo de equivalencias entre los puntos Claro Club y soles, aplicando el factor
			// de conversiòn.
			function CalcClaroClubPuntos(pstrObjId,
                                         pstrClaroClubPuntosUtilizar,
                                         pstrClaroClubSolesDeDescuento) {
                var resu;
                var FactorClaroClub;
                var constDecimalesClaroClub;
                var v_error;
                var v_des_error;

				try {
					FactorClaroClub = parseFloat(getValue('hidFactorClaroClub'));

					switch(pstrObjId) {
						case "txtClaroClubPuntosUtilizar":
							resu = EquivalenciaPuntosToSoles(); //Modificado 09012014  
							//EquivalenciaPuntosValorToSoles();
							break;
						case "txtClaroClubSolesDeDescuento":
							resu = EquivalenciaSolesToPuntosValor();
					}

					return resu;
				} 
				catch (ex) {
					return "-1";
				}
            }
            //Inicio 09012014
				function EquivalenciaPuntosToSoles() {
			
					try {
							var ClaroclubPuntosUtilizar =  parseFloat(parent.getValue('txtClaroClubPuntosUtilizar'));  //parseFloat(getValue('hidClaroClubPuntosUtilizar'));
							var constTipoClientePOSTPAGO = '<%= ConfigurationSettings.AppSettings("constTipoClientePOSTPAGO") %>';
							var constTipoClientePREPAGO = '<%= ConfigurationSettings.AppSettings("constTipoClientePREPAGO") %>';
							var FactorClaroClub = parseFloat(getValue('hidFactorClaroClub'));
							var fEqPOSTPAGO = 0.0;
							var fEqPREPAGO = 0.0;
							var puntosAcumUsados = 0;

							var vPOSTPAGO = cursorSaldos.get(constTipoClientePOSTPAGO).split('|');
							if (parseInt(vPOSTPAGO[0]) > ClaroclubPuntosUtilizar) {

								fEqPOSTPAGO = ClaroclubPuntosUtilizar * FactorClaroClub * parseFloat(vPOSTPAGO[1]);
								
								
								return Math.ceil(fEqPOSTPAGO);
							} else if (Math.ceil(parseFloat(vPOSTPAGO[0])) == ClaroclubPuntosUtilizar) {
								return Math.ceil(vPOSTPAGO[2]);
								} else {
								fEqPOSTPAGO = parseFloat(vPOSTPAGO[2]);
								}
							if (cursorSaldos.get(constTipoClientePREPAGO) != undefined) {
							var vPREPAGO = cursorSaldos.get(constTipoClientePREPAGO).split('|');
								fEqPREPAGO = (ClaroclubPuntosUtilizar - parseInt(vPOSTPAGO[0])) * FactorClaroClub * parseFloat(vPREPAGO[1]);
								if (Math.ceil(parseFloat(vPREPAGO[2])) >= fEqPREPAGO) {
									return Math.ceil(fEqPOSTPAGO + fEqPREPAGO);
								} else {
								fEqPREPAGO = parseFloat(vPREPAGO[2]);
								}
								puntosAcumUsados = parseInt(vPOSTPAGO[0]) + parseInt(vPREPAGO[0]);
								fEqSolesAcumulado = fEqPOSTPAGO + fEqPREPAGO;
							} else {
								puntosAcumUsados = parseInt(vPOSTPAGO[0]);
								fEqSolesAcumulado = fEqPOSTPAGO;
							}
							var i = 0;
							for (var i = 0; i < cursorSaldos.length; i++) {
								var constTipoClienteOTROS = cursorSaldos.item(i);
								if (constTipoClienteOTROS != constTipoClientePOSTPAGO && constTipoClienteOTROS != constTipoClientePREPAGO) {
									var vOTROS = cursorSaldos.get(constTipoClienteOTROS).split('|');
									var fEqOTROS = (ClaroclubPuntosUtilizar - puntosAcumUsados) * FactorClaroClub * parseFloat(vPOSTPAGO[1]);
									if (parseFloat(vOTROS[2]) >= fEqOTROS) {
										return Math.ceil(fEqSolesAcumulado + fEqOTROS);
								} else {
										puntosAcumUsados = puntosAcumUsados + parseInt(vOTROS[0]);
										fEqSolesAcumulado = fEqSolesAcumulado + parseFloat(vOTROS[2]);
							}
								}
							}

							return -1;
					} catch (ex) {
						return -1;
						}
			}
			
			function LeerCursorSaldos() {
				if (cursorSaldos.length == 0) {
					var vCursorSaldos = getValue('hidDetalleDescuento').split('~');

					for (var i = 0; i < vCursorSaldos.length - 1; i++) {
						var vSaldo = vCursorSaldos[i].split('|');
						// TIPO_CLIENTE=(5), PUNTOS=(7) + '|' + FACTOR=(4) + '|' + TOTAL=(2)
						cursorSaldos.put(vSaldo[5], vSaldo[7] + '|' + vSaldo[4] + '|' + vSaldo[2]);
					}				
				}				
			}
			
			
            //Fin 09012014
            
            
            // Verifica si se ha pulsado la tecla ENTER, para realizar el calsulo de puntos Claro Club
            // sino verifica que solo se ingresen números enteros
            function EvaluarKey(event, obj) {
				var code = (event.which) ? event.which : event.keyCode;	
				//Inicio 25112013
				verificarIzquierdaCeros(obj);
				//Fin 25112013				
				
				if (code == 13) { // key ENTER
					CalcularClaroClubPuntos(obj);
				} 
				else {
					return SoloEnteros(event, obj);
				}
			}
			//Inicio 25112013
			function verificarIzquierdaCeros(obj){
			
				var strCadena = obj.value;
				var aCaracteres = strCadena.split();
				var strFinal = "";
				obj.value = strFinal;
				for (i=0;i<aCaracteres.length;i++){
					if (aCaracteres[i]!= "0"){
						strFinal+=aCaracteres[i];
					}
				}
				obj.value=strFinal;
			}
			//Fin 25112013
			function EquivalenciaPuntosValorToSoles() {
				try {
					var claroClubPuntosPostpago = parseFloat(getValue('hidClaroClubPuntosPostpago'));
					var valorPuntosPostpago = parseFloat(getValue('hidValorPuntosPostpago'));
					var OtrosSaldos = parseFloat(getValue('hidOtrosSaldos'));
					var FactorClaroClub = parseFloat(getValue('hidFactorClaroClub'));


					var claroClubPuntosUtilizar = parseFloat(parent.getValue('txtClaroClubPuntosUtilizar'));     
					var saldoActual = valorPuntosPostpago * claroClubPuntosPostpago + OtrosSaldos;

					if (claroClubPuntosUtilizar > 0) {
						if (valorPuntosPostpago > 1) {
							if (claroClubPuntosUtilizar > claroClubPuntosPostpago) {
								return Math.ceil((claroClubPuntosPostpago * valorPuntosPostpago + (claroClubPuntosUtilizar - claroClubPuntosPostpago)) * FactorClaroClub);
							} 
							else {
								return Math.ceil(claroClubPuntosUtilizar * valorPuntosPostpago * FactorClaroClub);
							}
							} else {
							return Math.ceil(claroClubPuntosUtilizar * FactorClaroClub);
							}
						} else {
						return 0;
					}
				} 
				catch (ex) {
					return -1;
				}
			}
			//jmori  23012015
			function EquivalenciaSolesToPuntosValor() {
				try {
					var claroClubPuntosPostpago = parseFloat(getValue('hidClaroClubPuntosPostpago'));
					var valorPuntosPostpago = parseFloat(getValue('hidValorPuntosPostpago'));
					var OtrosSaldos = parseFloat(getValue('hidOtrosSaldos'));
					var FactorClaroClub = parseFloat(getValue('hidFactorClaroClub'));
					var solesEquivalentesPostpago = valorPuntosPostpago * claroClubPuntosPostpago * FactorClaroClub;


					var ClaroClubSolesDeDescuento = parseFloat(getValue('txtClaroClubSolesDeDescuento'));
					var saldoActual = valorPuntosPostpago * claroClubPuntosPostpago + OtrosSaldos;
					if (ClaroClubSolesDeDescuento > 0) {
						if (valorPuntosPostpago > 1) {
							if (ClaroClubSolesDeDescuento > solesEquivalentesPostpago) {
								return Math.ceil(claroClubPuntosPostpago + (ClaroClubSolesDeDescuento - solesEquivalentesPostpago) / FactorClaroClub);
							} else {
								return Math.ceil(ClaroClubSolesDeDescuento / (valorPuntosPostpago * FactorClaroClub));
						}
					} else {
							return Math.ceil(ClaroClubSolesDeDescuento / FactorClaroClub);
						}
					} else {
						return 0;
					}
				} catch (ex) {
					return -1;
				}
			}
			
			function ResetCifrasCC() {
				parent.setValue('txtClaroClubPuntosUtilizar', getValue('hidClaroClubPuntosUtilizar'));
				setValue('txtClaroClubSolesDeDescuento', getValue('hidClaroClubSolesDeDescuento'));	
				parent.setValue('txtDescuentoClaroClub', getValue('hidClaroClubSolesDeDescuento'));	
				
				if(parseFloat(parent.getValue('txtPrecioVenta')) > 0){
				       var ftotal_pagar = 0.0;
				      
				       if (parent.getValue('hidValidarIccid') == "1"){
				       ftotal_pagar = parseFloat(parent.getValue('txtPrecioVenta')) + parseFloat(parent.getValue('txtpreciochip')) - parseFloat(parent.getValue('txtDescuentoClaroClub')); 
				       }
				       else{
						ftotal_pagar = parseFloat(parent.getValue('txtPrecioVenta')- parent.getValue('txtDescuentoClaroClub')); 
						}
						
					if(parseFloat(ftotal_pagar) > 0 ) {
						parent.setValue('txtTotalAPagar', ftotal_pagar);
					}
				 }
			}
			
			function ejecutarDescuento(){
				var precioVenta = parseFloat(parent.getValue('hidPrecioVenta'));
				var precioTotal = 0.0;
				// Verificar si no hay reserva de puntos
				if (getValue('hidTieneReserva') != "1") {
					
					var DescuentoClaroClub = parent.getValue('txtDescuentoClaroClub');
					if (DescuentoClaroClub == "") {
						DescuentoClaroClub = 0.0;
					} else {
						DescuentoClaroClub = parseFloat(DescuentoClaroClub);
					}
					precioTotal = precioVenta - DescuentoClaroClub; 
					if (DescuentoClaroClub > precioVenta) {
						alert("El monto total de descuento no puede ser mayor al precio de venta de equipo.");
						return;
					}
				} else {
					precioTotal = precioVenta;
				}
				
				//total
				parent.setValue('hidPrecioTotal', precioTotal);
				parent.setValue('txtTotalAPagar', precioTotal.toFixed(2));	
					
				parent.setValue('hidFlagDescuento','true');
			}
			//
			
			//Inicio 26-11-2013 segmentacion
			// Inicio IDEA-13006 ClaroClub - Mejoras en notas de créditos			
			function VerDetalleDescuento() {				
				var url = 'sisact_renovacion_detalle_descuento.aspx?qs=';
				var params = getValue('hidDetalleDescuento');
						
				url = url +encodeURI(params);
				window.showModalDialog(url, window, 'dialogTop:200;status:no;edge:sunken;dialogHide:true;help:no;dialogWidth:560px;dialogHeight:300px');	
				return;
			}
			
			function CargarValoresSegmentacion(fecini,fecfin,seg){
				parent.setValue('hidFechaIniCC', fecini);
				parent.setValue('hidFechaFinCC', fecfin);
				parent.setValue('hidSegmento', seg);
			}
			
			//Fin 26-11-2013 segmentacion
			
			function mostrarPopupPlanCombo(strCodPlan, strDesPlan)
			{
				var opciones = "dialogHeight: 300px; dialogWidth: 400px; edge: Raised; center:Yes; help: No; resizable=no; status: No";
				var url = 'sisact_pop_plan_combo.aspx?idPlanBase=' + strCodPlan + '&planBase=' + strDesPlan;

				return window.showModalDialog(url, '', opciones);
			}
			//gaa20151109
			function validarEquipoSinStock() {
				var tabla = document.getElementById('tblTablaMovil');
				var contEquipoSinStock = 0;
				var cont = tabla.rows.length;
				for (var i = 0; i < cont; i++) {
					fila = tabla.rows[i];
					idFila = fila.cells[2].getElementsByTagName("select")[0].id.substring(10); //ddlCampana
					if (document.getElementById('txtTextoEquipo' + idFila).style.color != '')
						contEquipoSinStock++;
				}
				tabla = document.getElementById('tblTablaFijo');
				cont = tabla.rows.length;
				for (var i = 0; i < cont; i++) {
					fila = tabla.rows[i];
					idFila = fila.cells[2].getElementsByTagName("select")[0].id.substring(10); //ddlCampana
					if (document.getElementById('txtTextoEquipo' + idFila).style.color != '')
						contEquipoSinStock++;
				}
				tabla = document.getElementById('tblTablaBAM');
				cont = tabla.rows.length;
				for (var i = 0; i < cont; i++) {
					fila = tabla.rows[i];
					idFila = fila.cells[2].getElementsByTagName("select")[0].id.substring(10); //ddlCampana
					if (document.getElementById('txtTextoEquipo' + idFila).style.color != '')
						contEquipoSinStock++;
				}
			
				return contEquipoSinStock;
			}
			//fin gaa20151109
			
		</script>
		<style>BODY { MARGIN: 0px }
		</style>
	</HEAD>
	<BODY onload="inicio();">
		<form id="frmPrincipal2" method="post" runat="server">
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><table class="Contenido3" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr style="POSITION: relative" id="trGrilla">
								<td><div style="WIDTH: 980px; HEIGHT: 175px" id="divCondVent" class="clsGridRow1"><div style="POSITION: relative; WIDTH: 970px" id="divGrillaCabecera" class="clsGridRow">
											<table id="tblTablaTituloMovil" border="0" cellSpacing="0" borderColor="#95b7f3" cellPadding="0">
												<tr>
													<td class="TablaTitulos" width="16" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="18" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="180" align="center">Campaña</td>
													<td id="tdPlazo" class="TablaTitulos" width="145" align="center">Plazo
													</td>
													<td style="DISPLAY: none" id="tdPaqueteMovil" class="TablaTitulos" width="200" align="center">Paquete
													</td>
													<td class="TablaTitulos" id="tdFamiliaPlanMovil" style="DISPLAY: none" align="center" width="150">Familia Plan</td>
													<td class="TablaTitulos" width="150" align="center">Plan</td>
													<td class="TablaTitulos" width="30" align="center">Serv</td>
													<td class="TablaTitulos" width="45" align="center">Cargo Fijo</td>
													<td class="TablaTitulos" width="52" align="center">Monto Tope S/.</td>
													<td style="DISPLAY: none" id="tdPaqueteClaroPuntos" class="TablaTitulos" width="45"
														align="center">Claro Puntos</td>
													<td class="TablaTitulos" width="200" align="center">Equipo</td>
													<td style="DISPLAY: none" id="tdCuota" class="TablaTitulos" width="35" align="center">Cuotas</td>
													<td class="TablaTitulos" width="65" align="center">Precio Equipo</td>
													<td style="DISPLAY: none" class="TablaTitulos" width="57" align="center">Nro. a 
														Portar</td>
												</tr>
											</table>
											<table style="DISPLAY: none" id="tblTablaTituloFijo" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
												<tr>
													<td class="TablaTitulos" width="16" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="18" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="180" align="center">
														Campaña</td>
													<td class="TablaTitulos" width="145" align="center">Plazo</td>
													<td style="DISPLAY: none" id="tdPaqueteFijo" class="TablaTitulos" width="310" align="center">Paquete
													</td>
													<td class="TablaTitulos" width="150" align="center">Plan
													</td>
													<td class="TablaTitulos" width="30" align="center">
														Serv
													</td>
													<td class="TablaTitulos" width="45" align="center">
														Cargo Fijo</td>
													<td class="TablaTitulos" width="200" align="center">Equipo</td>
													<td class="TablaTitulos" width="62" align="center">
														Precio Equipo</td>
													<td class="TablaTitulos" width="35" align="center">Cuotas
													</td>
													<td style="DISPLAY: none" class="TablaTitulos" width="57" align="center">Nro. a 
														Portar
													</td>
													<td class="TablaTitulos" style="DISPLAY: none" align="center" width="57">Nro. a 
														Portar</td>
												</tr>
											</table>
											<table style="DISPLAY: none" id="tblTablaTituloBAM" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
												<tr>
													<td class="TablaTitulos" width="16" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="18" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="180" align="center">Campaña
													</td>
													<td class="TablaTitulos" width="145" align="center">Plazo</td>
													<td style="DISPLAY: none" id="tdPaqueteBAM" class="TablaTitulos" width="310" align="center">
														Paquete</td>
													<td class="TablaTitulos" width="150" align="center">Plan</td>
													<td class="TablaTitulos" width="30" align="center">Serv</td>
													<td class="TablaTitulos" width="45" align="center">Cargo Fijo</td>
													<td style="DISPLAY: none" id="tdPaqueteClaroPuntos1" class="TablaTitulos" width="45"
														align="center">Claro Puntos</td>	
													<td class="TablaTitulos" width="200" align="center">Equipo
													</td>
													<td class="TablaTitulos" width="35" align="center">Cuotas</td>
													<td class="TablaTitulos" width="62" align="center">Precio Equipo</td>
													<td style="DISPLAY: none" class="TablaTitulos" width="57" align="center">
														Nro. a Portar</td>
												</tr>
											</table>
											<table style="DISPLAY: none" id="tblTablaTituloDTH" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
												<tr>
													<td class="TablaTitulos" width="16" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="18" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="180" align="center">Campaña</td>
													<td class="TablaTitulos" width="200" align="center">
														Plan</td>
													<td class="TablaTitulos" width="30" align="center">Paq. Adic.
													</td>
													<td class="TablaTitulos" width="150" align="center">Plazo</td>
													<td class="TablaTitulos" width="200" align="center">Kits
													</td>
													<td class="TablaTitulos" width="50" align="center">Precio Inst.</td>
													<td class="TablaTitulos" width="50" align="center">CF Plan Mensual</td>
													<td class="TablaTitulos" width="50" align="center">CF Men. Alq. Kit</td>
													<td class="TablaTitulos" width="50" align="center">Tot. CF Mensual</td>
													<td class="TablaTitulos" width="35" align="center">Dir. Inst.</td>
												</tr>
											</table>
											<table style="DISPLAY: none" id="tblTablaTituloHFC" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
												<tr>
													<td class="TablaTitulos" width="16" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="18" align="center">&nbsp;</td>
													<td class="TablaTitulos" width="145" align="center">Plazo</td>
													<td class="TablaTitulos" width="280" align="center">
														Solución</td>
													<td class="TablaTitulos" width="310" align="center">Paquete</td>
													<td class="TablaTitulos" width="150" align="center">Servicio
													</td>
													<td class="TablaTitulos" width="30" align="center">Serv. Adic.</td>
													<td class="TablaTitulos" width="45" align="center">Cargo Fijo</td>
													<td class="TablaTitulos" width="35" align="center">Dir. Inst.
													</td>
													<td class="TablaTitulos" width="35" align="center">Det. Ofert.
													</td>
												</tr>
											</table>
										</div>
										<div style="POSITION: relative; WIDTH: 950px; HEIGHT: 100px" id="divGrillaDetalle" class="clsGridRow"><table id="tblTablaMovil" border="0" cellSpacing="0" borderColor="#95b7f3" cellPadding="0">
											</table>
											<table style="DISPLAY: none" id="tblTablaFijo" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
											</table>
											<table style="DISPLAY: none" id="tblTablaBAM" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
											</table>
											<table style="DISPLAY: none" id="tblTablaDTH" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
											</table>
											<table style="DISPLAY: none" id="tblTablaHFC" border="0" cellSpacing="0" borderColor="#95b7f3"
												cellPadding="0">
											</table>
										</div>
										<table style="POSITION: relative" id="tblCFTotal" border="0" cellSpacing="0" cellPadding="0"
											width="100%">
											<tr>
												<td style="POSITION: relative; nowrap: false" class="Arial10b" align="center">
													CF Total:&nbsp;&nbsp;<input style="TEXT-ALIGN: right; WIDTH: 50px" id="txtCFTotal" class="clsInputDisable" readOnly
														name="txtCFTotal"></td>
											</tr>
										</table>
									</div>
									<table style="DISPLAY: none" id="tblPuntosCC" border="0" cellSpacing="1" cellPadding="0"
										width="650" align="center" height="200" runat="server">
										<tr id="trPuntosClaroClub">
											<td>
												<table style="BORDER-COLLAPSE: collapse" class="contenido" border="0" cellSpacing="2" width="860">
													<tr>
														<td class="header" height="20" align="left">Claro Club - Datos de Claro 
															Puntos&nbsp;</td>
													</tr>
													<tr>
														<td><table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="100%">
																<tr>
																	<td style="WIDTH: 200px" class="Arial10B">&nbsp;<asp:label id="lblClaroClubCampana" Runat="server">Campaña</asp:label></td>
																	<td style="WIDTH: 218px" class="Arial10B" colSpan="3"><asp:textbox id="txtClaroClubCampana" Runat="server" width="300px" ReadOnly="True" CssClass="clsInputDisable" /></td>
																	<td class="Arial10B" colSpan="2">
																		<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="0" width="100%">
																			<tr>
																				<TD style="HEIGHT: 20px" class="Arial10B">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vigencia&nbsp;
																				</TD>
																				<TD style="HEIGHT: 20px" class="Arial10B"><asp:textbox id="txtFechaIniCC" Runat="server" width="80px" ReadOnly="True" CssClass="clsInputDisable Monto DeshabilitadoCC" /></TD>
																				<td style="HEIGHT: 20px" class="Arial10B">&nbsp;al&nbsp;</td>
																				<TD style="HEIGHT: 20px" class="Arial10B">
																					<asp:textbox id="txtFechaFinCC" Runat="server" width="80px" ReadOnly="True" CssClass="clsInputDisable Monto DeshabilitadoCC"></asp:textbox></TD>
																				<TD style="HEIGHT: 20px" class="Arial10B">&nbsp;&nbsp;&nbsp;&nbsp;Segmento
																				</TD>
																				<TD style="HEIGHT: 20px" class="Arial10B"><asp:textbox style="TEXT-ALIGN: center" id="txtSegmentoCC" Runat="server" ReadOnly="True" CssClass="clsInputDisable Monto DeshabilitadoCC"
																						Width="30" Font-Bold="True" /></TD>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
															<br>
															<table style="WIDTH: 100%; BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="1000">
																<tr id="trClaroClubSaldosCC">
																	<td style="WIDTH: 384px" class="Arial10B" vAlign="top"><asp:datagrid id="dgSaldosCC" runat="server" Width="315px" AllowPaging="False" AutoGenerateColumns="False"
																			BorderColor="#95B7F3" CellPadding="1" CellSpacing="1" ShowHeader="False" BorderWidth="0">
																			<Columns>
																				<asp:BoundColumn DataField="DESCRIP_BOLSA" HeaderText="DESCRIP_BOLSA">
																					<ItemStyle Font-Size="11px" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Left" ForeColor="Navy"
																						Width="270px"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="PUNTOS_ASIGNADOS" HeaderText="PUNTOS_ASIGNADOS">
																					<ItemStyle Font-Size="11px" Font-Names="Arial" Font-Bold="True" HorizontalAlign="Right" BorderWidth="1px"
																						ForeColor="Navy" BorderColor="#BFBEE9" Width="90px" BackColor="#E3EFFF"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="COD_BOLSA" HeaderText="COD_BOLSA"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></td>
																	<td style="PADDING-LEFT: 35px; VERTICAL-ALIGN: top" class="Arial10B">Ver Detalle de 
																		Descto.&nbsp;&nbsp;<input style="WIDTH: 28px; HEIGHT: 19px; CURSOR: hand" id="btnVerDetalleDescuento" class="Boton"
																			onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="VerDetalleDescuento();"
																			value="..." type="button" name="btnVerDetalleDescuento"></td>
																</tr>
															</table>
															<br>
															<table style="BORDER-COLLAPSE: collapse" border="0" cellSpacing="2" width="100%">
																<TR>
																	<TD style="WIDTH: 170px; HEIGHT: 21px" class="Arial10B">&nbsp;<asp:label id="lblClaroClubSaldoActual" Runat="server">Saldo actual de Puntos</asp:label></TD>
																	<TD style="WIDTH: 206px; HEIGHT: 21px" class="Arial10B"><asp:textbox id="txtClaroClubSaldoActual" Runat="server" ReadOnly="True" CssClass="clsInputDisable Monto"
																			Width="92" /></TD>
																	<TD style="WIDTH: 181px; HEIGHT: 21px" class="Arial10B">&nbsp;<asp:label id="lblClaroClubSolesDeDescuento" Runat="server">        Soles de Descuento</asp:label></TD>
																	<TD style="HEIGHT: 21px" class="Arial10B"><asp:textbox id="txtClaroClubSolesDeDescuento" Runat="server" width="90px" ReadOnly="True" CssClass="clsInputDisable Monto DeshabilitadoCC" /></TD>
																	<TD style="HEIGHT: 21px" class="Arial10B">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="Arial10B" colSpan="4">&nbsp;<asp:label id="lblClaroClubMsgError" Runat="server" CssClass="Arial10BRed"></asp:label></TD>
																	<TD class="Arial10B">&nbsp;
																	</TD>
																	<TD class="Arial10B">&nbsp;</TD>
																	<TD class="Arial10B">&nbsp;</TD>
																</TR>
																<tr>
																	<td colSpan="7" align="center"><input style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand" id="btnCerrarSaldoCC" class="Boton"
																			onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:CerrarSaldoCC();"
																			value="Cerrar" type="button" name="btnCerrarSaldoCC"></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table style="DISPLAY: none" id="tblServicios" class="contenido" border="0" cellSpacing="1"
										cellPadding="0" width="500" align="center" height="270" runat="server">
										<tr>
											<td class="header" height="20">
												Servicios Adicionales - Plan<asp:label id="lblIdLista" runat="server" Font-Bold="True" cssclass="Arial10B"></asp:label></td>
										</tr>
										<tr>
											<td class="contenido"><table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr vAlign="top">
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top"><u>Servicios 
																Adicionales</u></td>
														<td>&nbsp;
														</td>
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top"><u>Servicios 
																Contratados</u></td>
													</tr>
													<tr>
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top"><SELECT style="WIDTH: 310px" id="lbxServiciosDisponibles1" class="clsSelectEnable" onclick="mostrarPromociones('D', this.value)"
																size="5" name="lbxServiciosDisponibles1" DESIGNTIMEDRAGDROP="609"></SELECT></td>
														<td style="BACKGROUND-COLOR: white; WIDTH: 150px" class="Arial10B" vAlign="top" align="center"><input style="WIDTH: 90px; HEIGHT: 19px; CURSOR: hand" id="btnAgregarServicio" class="Boton"
																onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:agregarServicio();" value="Agregar >" type="button" name="btnAgregarServicio"><br>
															<br>
															<input style="WIDTH: 90px; HEIGHT: 19px; CURSOR: hand" id="btnQuitarServicio" class="Boton"
																onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
																onclick="javascript:quitarServicio();" value="< Quitar" type="button" name="btnQuitarServicio"><br>
															<br>
															<input style="WIDTH: 90px; HEIGHT: 19px; CURSOR: hand" id="btnResetServicios" class="Boton"
																onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
																onclick="javascript:resetServicio('');" value="Limpiar" type="button" name="btnResetServicios"><br>
															<br>
															<input style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand" id="btnCerrarServicios" class="Boton"
																onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';"
																onclick="javascript:guardarServicio();" value="Cerrar y Guardar" type="button" name="btnCerrarServicios"></td>
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top">
															<SELECT style="WIDTH: 310px" id="lbxServiciosAgregados1" class="clsSelectEnable" onclick="mostrarPromociones('A', this.value)"
																size="5" name="lbxServiciosAgregados1" DESIGNTIMEDRAGDROP="623">
															</SELECT></td>
													</tr>
													<tr style="DISPLAY: none" id="trPromocion" vAlign="top">
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top"><u>Promociones 
																Adicionales</u></td>
														<td>
														<td style="BACKGROUND-COLOR: white; WIDTH: 280px" class="Arial10B" vAlign="top"><u>Promociones 
																Agregadas</u></td>
													</tr>
													<tr style="DISPLAY: none" id="trPromocion1" vAlign="top">
														<td><select style="WIDTH: 310px" id="lbxPromocionesDisponibles" class="clsSelectEnable" size="5"
																name="lbxPromocionesDisponibles"></select></td>
														<td>
														<td><select style="WIDTH: 270px; DISPLAY: none" id="lbxPromocionesAgregadas" class="clsSelectEnable"
																size="5" name="lbxPromocionesAgregadas"></select><select style="WIDTH: 310px" id="lbxPromocionesSeleccionadas" class="clsSelectEnable" size="5"
																name="lbxPromocionesSeleccionadas" /></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td><table style="DISPLAY: none" id="tblRoamingI" class="contenido" border="0" cellSpacing="1"
													cellPadding="0" width="200" align="right" runat="server">
													<tr>
														<td class="contenido">
															<table border="0" cellSpacing="5" cellPadding="0" width="100%">
																<tr>
																	<td style="BACKGROUND-COLOR: white" class="Arial10B">PLAZO</td>
																	<td style="WIDTH: 320px" class="Arial10B">
																		<input id="rbtValDeterminado" onclick="f_cambiarPlazoRI(this.value)" value="01" type="radio"
																			name="rbtTipoPlazo">Determinado</td>
																	<td style="WIDTH: 400px" class="Arial10B"><input id="rbtValIndeterminado" onclick="f_cambiarPlazoRI(this.value)" value="02" type="radio"
																			name="rbtTipoPlazo">Indeterminado
																	</td>
																</tr>
																<tr>
																	<td style="DISPLAY: none" id="tdLblFechaDesde" class="Arial10b">Desde:</td>
																	<td style="DISPLAY: none" id="tdTxtFechaDesde" colSpan="2"><asp:textbox id="txtFechaDesde" runat="server" ReadOnly CssClass="clsInputDisable" Width="64px"
																			MaxLength="10" /><asp:imagebutton id="btnFechaDesde" runat="server" ImageUrl="../../../images/Botones/btn_Calendario.gif"></asp:imagebutton><script type="text/javascript">
																			Calendar.setup(
																				{
																					inputField     :    "txtFechaDesde",      // id of the input field
																					ifFormat       :    "%d/%m/%Y",           // format of the input field                                                        
																					button         :    "btnFechaDesde",      // trigger for the calendar (button ID)
																					singleClick    :    true,                 // double-click mode
																					step           :    1                     // show all years in drop-down boxes (instead of every other year as default)
																				}
																			);
																		</script></td>
																</tr>
																<tr>
																	<td style="DISPLAY: none" id="tdLblFechaHasta" class="Arial10b">
																		Hasta:</td>
																	<td style="DISPLAY: none" id="tdTxtFechaHasta" colSpan="2">
																		<asp:textbox id="txtFechaHasta" runat="server" ReadOnly CssClass="clsInputDisable" Width="64px"
																			MaxLength="10" /><asp:imagebutton id="btnFechaHasta" runat="server" ImageUrl="../../../images/Botones/btn_Calendario.gif"></asp:imagebutton><script type="text/javascript">
																		Calendar.setup(
																			{
																				inputField     :    "txtFechaHasta",      // id of the input field
																				ifFormat       :    "%d/%m/%Y",           // format of the input field                                                        
																				button         :    "btnFechaHasta",      // trigger for the calendar (button ID)
																				singleClick    :    true,                 // double-click mode
																				step           :    1                     // show all years in drop-down boxes (instead of every other year as default)
																			}
																		);
																		</script></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table style="DISPLAY: none" id="tblCuotas" class="contenido" border="0" cellSpacing="1"
										cellPadding="0" width="400" align="center" runat="server">
										<tr>
											<td class="header" height="20">Cuotas</td>
										</tr>
										<tr>
											<td class="contenido"><table border="0" cellSpacing="5" cellPadding="0" width="100%">
													<tr>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top">Nro Cuotas</td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top"><select style="WIDTH: 100px" id="ddlNroCuotas" class="clsSelectEnable0" onchange="cambiarCuota(this.value)"
																name="ddlNroCuotas" /></td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top">% Cuota Inicial</td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top"><input style="TEXT-ALIGN: right; WIDTH: 50px" id="txtPorcCuotaIni" class="clsInputDisable"
																readOnly name="txtPorcCuotaIni"></td>
													</tr>
													<tr>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top">Monto Cuota 
															Inicial</td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top"><input style="TEXT-ALIGN: right; WIDTH: 50px" id="txtMontoCuotaIni" class="clsInputDisable"
																readOnly name="txtMontoCuotaIni"></td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top">Monto Cuota
														</td>
														<td style="BACKGROUND-COLOR: white" class="Arial10B" vAlign="top"><input style="TEXT-ALIGN: right; WIDTH: 50px" id="txtMontoCuota" class="clsInputDisable"
																readOnly name="txtMontoCuota"></td>
													</tr>
													<tr>
														<td colSpan="4" align="center"><input style="WIDTH: 120px; HEIGHT: 19px; CURSOR: hand" id="btnCerrarCuotas" class="Boton"
																onmouseover="this.className='BotonResaltado';" onmouseout="this.className='Boton';" onclick="javascript:guardarCuota();"
																value="Cerrar y Guardar" type="button" name="btnCerrarCuotas">
														</td>
														
													</tr>
													<!-- Proy 29123 -->
													<tr>
														<td align="center" colspan="4" class="Arial10b">
															<label id="lblMensajeCuotas" style="font-weight: bold;color:black"></label>
														</td>
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
				<tr style="DISPLAY: none" id="trResumenCompras">
					<td><table border="0" cellPadding="1" width="100%">
							<tr>
								<td class="Header" height="18" align="left">&nbsp;Resumen de Compras
								</td>
							</tr>
						</table>
						<table id="tbResumenCompras" border="0" cellSpacing="0" borderColor="#95b7f3" cellPadding="0"
							width="100%">
							<tr>
								<td class="TablaTitulos" align="center">Tipo de Producto</td>
								<td class="TablaTitulos" align="center">Plazo</td>
								<td class="TablaTitulos" align="center">Plan</td>
								<td class="TablaTitulos" align="center">Campaña</td>
								<td class="TablaTitulos" align="center">Equipo</td>
								<td class="TablaTitulos" align="center">Cargo Fijo Total</td>
								<td class="TablaTitulos" align="center">Precio de Venta Equipo</td>
								<td class="TablaTitulos" align="center">Equipo en Cuotas</td>
								<td class="TablaTitulos" align="center">Nro. Cuotas</td>
								<td class="TablaTitulos" align="center">&nbsp;
								</td>
								<td class="TablaTitulos" align="center">&nbsp;</td>
								<td class="TablaTitulos" align="center">&nbsp;
								</td>
							</tr>
						</table>
						<table border="0" cellPadding="1" width="100%">
							<tr>
								<td class="Arial10b" align="center">CF Total:&nbsp;&nbsp;<input style="TEXT-ALIGN: right; WIDTH: 50px" id="txtCFTotalCarrito" class="clsInputDisable"
										readOnly name="txtCFTotalCarrito"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="DISPLAY: none">
					<td>
						<input id="hidPlanServicio" type="hidden" name="hidPlanServicio"><input id="hidPlanServicioNo" type="hidden" name="hidPlanServicioNo"><input id="hidPlanServicioNoGrupo" type="hidden" name="hidPlanServicioNoGrupo"><input id="hidPlanServicioNGTemp" type="hidden" name="hidPlanServicioNGTemp">
						<input id="hidLineaActual" type="hidden" name="hidLineaActual"><input id="hidTotalLineas" value="0" type="hidden" name="hidTotalLineas"><input id="hidPlazoActual" type="hidden" name="hidPlazoActual" runat="server"><input id="hidPaqueteActual" type="hidden" name="hidPaqueteActual"><input id="hidTienePaquete" value="N" type="hidden" name="hidTienePaquete"><input id="hidPlan" type="hidden" name="hidPlan"><input id="hidTraerPlazo" type="hidden" name="hidTraerPlazo"><input id="hidCuota" type="hidden" name="hidCuota">
						<input id="hidNroCuotaActual" type="hidden" name="hidNroCuotaActual"><input id="hidConfirmaCuota" type="hidden" name="hidConfirmaCuota"><input id="hidMaterial" type="hidden" name="hidMaterial"><input id="hidCampana" type="hidden" name="hidCampana">
						<input id="hidGrupoPaquete" type="hidden" name="hidGrupoPaquete"> <input id="hidTipoClienteActual" type="hidden" name="hidTipoClienteActual"><input id="hidTipoProductoActual" value="Movil" type="hidden" name="hidTipoProductoActual"><input id="hidTieneCuotas" type="hidden" name="hidTieneCuotas">
						<input id="hidValidarGuardarCuota" type="hidden" name="hidValidarGuardarCuota" runat="server"><input id="hidPlazos" type="hidden" name="hidPlazos" runat="server"><input id="hidAccion" type="hidden" name="hidAccion" runat="server"><input id="hidEquiposSel" type="hidden" name="hidEquiposSel"><input id="hidPaqActCompleto" type="hidden" name="hidPaqActCompleto"><input id="hidListaTipoProducto" type="hidden" name="hidListaTipoProducto"><input id="hidServicioOriginal" type="hidden" name="hidServicioOriginal"><input id="hidServicioOriginalNo" type="hidden" name="hidServicioOriginalNo"><input id="hidPromociones" type="hidden" name="hidPromociones"><input id="hidPromocion" type="hidden" name="hidPromocion"><input id="hidPromocionTemp" type="hidden" name="hidPromocionTemp">
						<input id="hidSolucion3Play" type="hidden" name="hidSolucion3Play"><input id="hidPaquete3Play" type="hidden" name="hidPaquete3Play"><input id="hidCodigoTipoProductoActual" value="01" type="hidden" name="hidCodigoTipoProductoActual"><input id="hidCampanasDTH" type="hidden" name="hidCampanasDTH"><input id="hidCadenaDetalle" type="hidden" name="hidCadenaDetalle">
						<input id="hidFlagEvaluar" type="hidden" name="hidFlagEvaluar"><iframe id="ifrmEvaluacion" height="100" frameBorder="no" width="550" name="ifrmEvaluacion" />
						<iframe id="iframeAuxiliar" height="0" frameBorder="no" width="0" name="iframeAuxiliar">
						</iframe><input id="hidFlagVOD" type="hidden" name="hidFlagVOD"><INPUT id="hidPerfil" type="hidden" name="hidPerfil" runat="Server"><input id="hidTipoDocumentos" type="hidden" name="hidTipoDocumentos" runat="server"><input id="hidMinimoSoles" type="hidden" name="hidMinimoSoles" runat="server"><input id="hidOtrosSaldos" type="hidden" name="hidOtrosSaldos" runat="server"><input id="hidClaroClubPuntosPostpago" type="hidden" name="hidClaroClubPuntosPostpago"
							runat="server"><input id="hidSaldoActualWS" type="hidden" name="hidSaldoActualWS" runat="server"><input id="hidClaroClubPuntosUtilizar" type="hidden" name="hidClaroClubPuntosUtilizar"
							runat="server"><input id="hidClaroClubSolesDeDescuento" type="hidden" name="hidClaroClubSolesDeDescuento"
							runat="server"><input id="hidValorPuntosPostpago" type="hidden" name="hidValorPuntosPostpago" runat="server"><input id="hidIDCAMPANA" type="hidden" name="hidIDCAMPANA" runat="server"><input id="hidFactorClaroClub" type="hidden" name="hidFactorClaroClub" runat="server"><input id="hidTieneReserva" type="hidden" name="hidTieneReserva" runat="server">
						<input id="hidCCMinimoPuntos" type="hidden" name="hidCCMinimoPuntos" runat="server">
						<input id="hidErrorCCPuntosMinimos" type="hidden" name="hidErrorCCPuntosMinimos" runat="server"><input id="hidErrorClaroClub" type="hidden" name="hidErrorClaroClub" runat="server"><input id="hidErrorClaroClubDesfase" type="hidden" name="hidErrorClaroClubDesfase" runat="server"><input id="hidTienePortabilidad" type="hidden" name="hidTienePortabilidad" runat="server"><input id="hidDetalleDescuento" type="hidden" name="hidDetalleDescuento" runat="server"><input id="hidTipoCanal" type="hidden" name="hidTipoCanal" runat="server"><input id="hidTipModalidad" type="hidden" name="hidTipModalidad" runat="server"><input id="hidListaPreciosEquipo" type="hidden" name="hidListaPreciosEquipo" runat="server"><input id="hidCargoFijoSeleccionado" type="hidden" name="hidCargoFijoSeleccionado" runat="server">
						<input id="hidCampanasMovil" type="hidden" name="hidCampanasMovil" /> <input id="hidCampanasFijo" type="hidden" name="hidCampanasFijo" />
						<input id="hidCampanasBAM" type="hidden" name="hidCampanasBAM" /> <input id="hidCampanasVentaVarios" type="hidden" name="hidCampanasVentaVarios" />
						<input id="hidPlazosMovil" type="hidden" name="hidPlazosMovil" />
						<input id="hidPlazosFijo" type="hidden" name="hidPlazosFijo" />
						<input id="hidPlazosBAM" type="hidden" name="hidPlazosBAM" />
						<input id="hidPlazosHFC" type="hidden" name="hidPlazosHFC" />
						<input id="hidPlazosDTH" type="hidden" name="hidPlazosDTH" />
						<input id="hidPlazosVentaVarios" type="hidden" name="hidPlazosVentaVarios" /> 
						<input id="hidMantenerPlan" type="hidden" name="hidMantenerPlan" /> 
						<input id="hidCodPlanNoVigente" type="hidden" name="hidCodPlanNoVigente" />
						<input id="hidIdPlanVig" type="hidden" name="hidIdPlanVig" />
						
						<input id="hidPlanNuevo" type="hidden" name="hidPlanNuevo">
						<input id="hidplanAsoc" type="hidden" name="hidplanAsoc">
						<!--PROY-24724-IDEA-28174-INICIO-->
						<input id="hidCodServProteccionMovil" type="text" name="hidCodServProteccionMovil" runat="server" style="display:none" >
						<input id="hidCanalesPermitidosPrimaSeguros" type="text" name="hidCanalesPermitidosPrimaSeguros" runat="server" style="display:none" >
						<!--PROY-24724-IDEA-28174-FIN-->
						<!--PROY-32129 :: INI -->
						<input id="hidcampanaactual" type="hidden" name="hidcampanaactual" runat="server">
						<!--PROY-32129 :: FIN -->
					</td>
				</tr>
			</TABLE>
		</form>
	</BODY>
</HTML>
