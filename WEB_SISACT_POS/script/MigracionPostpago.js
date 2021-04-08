var objWhiteList ;///obtenido del whitelist

function ocultarPanel(ant){	
	if(ant =='tblResultado'){
		setVisible('trResultado',false);
		setVisible('trSgte3',false);
			
		setEnabled('btnSgte3',true,'boton');
		//setEnabled('btnAnt3',true,'boton');		
		
		setEnabled('ddlPlazoAcuerdo',true,'clsSelectEnable0');
		setEnabled('ddlPlan',true,'clsSelectEnable0');
		setEnabled('btnQuitarPlan',true,'boton');
		setEnabled('btnAgregarPlan',true,'boton');
		setEnabled('chkCorreo',true,'Arial10B');	
	
	}
	/*
	if(ant == 'tblDatosCliente'){
				
		setVisible('trDatosCliente',false);		
		
		setVisible('trSgte1',false);		
		setEnabled('btnBuscar',true,'boton');	
		
		setEnabled('txtDocumento',true,'clsInputEnableB  ');
		setEnabled('txtNumero',true,'clsInputEnableB  ');	
		
	}else if(ant =='tblCondicionesVenta'){	
		setVisible('trCondicionesVenta',false);
		setVisible('trSgte2',false);
		
		setEnabled('btnSgte2',true,'boton');
		setEnabled('btnAnt2',true,'boton');						

	}else if(ant =='tblResultado'){
		setVisible('trResultado',false);
		setVisible('trSgte3',false);
			
		setEnabled('btnSgte3',true,'boton');
		setEnabled('btnAnt3',true,'boton');		
		
		setEnabled('ddlPlazoAcuerdo',true,'clsSelectEnable0');
		setEnabled('ddlPlan',true,'clsSelectEnable0');
		setEnabled('btnQuitarPlan',true,'boton');
		setEnabled('btnAgregarPlan',true,'boton');
		setEnabled('chkCorreo',true,'Arial10B');		
		
	}else if(ant =='trDirFact'){
		setVisible('trDirFact',false);	
		setVisible('trSgte4',false);
		
		setEnabled('btnSgte4',true,'boton');
		setEnabled('btnAnt4',true,'boton');	
	}else if(ant =='tblCampana'){
		setVisible('trCampana',false);	
		setVisible('trSgte5',false);
		
		setEnabled('btnSgte6',true,'boton');
		setEnabled('btnAnt6',true,'boton');	
		
		habilitarDireccion('Usc_direccion1',true)
		habilitarDireccion('Usc_direccion2',true)
		habilitarDireccion('Usc_direccion3',true)
		
		setEnabled('btnMostrarDirCli',true,'boton');
		
		setEnabled('btnMostrarDirTra',true,'boton');	
	}*/
}

function mostrarPanel(sgte)
{
	//usado para mostrar los paneles.	
	var strMostrarRF ='';
	var strNumeroDocumento= '';
	
	if(sgte == 'tblDatosCliente')
	{
		if(validacionCliente())
		{
			setVisible('trDatosCliente',true);				
			setVisible('trSgte1',true);
			
			//obtener los datos del cliente
			objWhiteList = obtenerDatosWhiteList();
			
			setValue('ddlTipoDoc',objWhiteList.tipodoc);	
			setValue('txtNroDoc',objWhiteList.documento);	
			setValue('txtNombre',objWhiteList.nombre.toUpperCase());	
			setValue('txtApePat',objWhiteList.ape_pat.toUpperCase());
			setValue('txtApeMat',objWhiteList.ape_mat.toUpperCase());
			
			setValue('hdnCargoFijoMax',objWhiteList.cf_max);
			setValue('hdnFlagControlConsumo',objWhiteList.control_consumo);
			
			setEnabled('btnSgte1',false,'boton');
			setEnabled('btnBuscar',false,'boton');			
		}
	}else if(sgte=='tblCondicionesVenta')
	{
		setVisible('trCondicionesVenta',true);				
		setVisible('trSgte2',true);
		
		//se asigna el plazo acuerdo obtenido del WL sino uno por default obtenido del webconfig
		//cambio manuelito, ya no se tiene un default, se filtra la lista para que cargen los plazos del whitelist
		
		if(objWhiteList.plazo_acuerdo!=null || objWhiteList.plazo_acuerdo !='')
		{
			var ddlPlazo = document.getElementById('ddlPlazoAcuerdo');

			//filtrar los plazo acuerdo
			
			for(var y=0;y<ddlPlazo.options.length;y++)
			{
				
				if(objWhiteList.plazo_acuerdo.indexOf(ddlPlazo.options[y].value)==-1 && ddlPlazo.options[y].value!='-1')
				{
					ddlPlazo.remove(y);
					y--;
				}
			}	
		}
		document.getElementById('btnCargarPlanes').click();
		
		setEnabled('btnSgte2',false,'boton');
		
		//setEnabled('btnAnt2',false,'boton');		
		setEnabled('btnAgregarPlan',true,'boton');
		//setEnabled('btnAgregarPlan',true,'clsSelectEnable0');
			
	}else if(sgte=='tblResultado')
	{
		if(validacionPlanServicios())
		{
			setVisible('trResultado',true);				
			setVisible('trSgte3',true);
			setVisible('divServicios',false);
			
			//NUEVA VALIDACION MANUELITO, si el cf del plan seleccionado es igual al cf_min,
			//entonces usar los campos que terminen en min
			
			var tblPlan = document.getElementById('dgPlan');
			var cfPlanSeleccionado = tblPlan.rows[1].cells[1].childNodes[2].value;
			
			//alert('cf sel: ' + cfPlanSeleccionado);
			//alert('cf min: '+ objWhiteList.cf_min);
			
			setValue('txtRiesgo',objWhiteList.riesgo);
			
			if(cfPlanSeleccionado==objWhiteList.cf_min)
			{
				if(objWhiteList.tipo_cargo_min_desc == ''){
					setValue('txtTipoGarantia','NINGUNO');
					setValue('txtImporte','0');
				}else{
					setValue('txtTipoGarantia',objWhiteList.tipo_cargo_min_desc);
					setValue('txtImporte',obtenerImportePlanesServicio('MIN'));
				}				
				//setValue('txtTipoGarantia',objWhiteList.tipo_cargo_min_desc);
				//setValue('txtImporte',obtenerImportePlanesServicio('MIN'));
								
				setValue('txtNumeroCF',objWhiteList.num_cf_min);				
				setValue('hdnTipoCargo',objWhiteList.tipo_cargo_min);
			}else
			{
				if(objWhiteList.tipo_cargo_max_desc == ''){
					setValue('txtTipoGarantia','NINGUNO');
					setValue('txtImporte','0');
				}else{
					setValue('txtTipoGarantia',objWhiteList.tipo_cargo_max_desc);
					setValue('txtImporte',obtenerImportePlanesServicio('MAX'));
				}							
				setValue('txtNumeroCF',objWhiteList.num_cf_max);				
				setValue('hdnTipoCargo',objWhiteList.tipo_cargo_max);
			}
			
			//setea el resultado de cf del plan + cf de servicios seleccionados
			setValue('hdnCFPlanServicios',String(cf_seleccionado));
			
			setEnabled('btnSgte3',false,'boton');
			//setEnabled('btnAnt3',false,'boton');
			
			setEnabled('btnAgregarPlan',false,'boton');
			setEnabled('btnQuitarPlan',false,'boton');
			setEnabled('ddlPlazoAcuerdo',false,'clsSelectEnable0');
			setEnabled('ddlPlan',false,'clsSelectEnable0');
			setEnabled('chkCorreo',false,'Arial10B');
			
			setValue('txtCorreo',getValue('txtCorreo').toUpperCase());
			
			setEnabled('txtCorreo',false,'clsInputDisable');
			
			setValue('txtConfirmCorreo',getValue('txtConfirmCorreo').toUpperCase());
			
			setEnabled('txtConfirmCorreo',false,'clsInputDisable');
			
		}
			
	}else if(sgte=='tblDirFact')
	{
		//mostrar direccion de facturacion
		setVisible('trDirFact',true);				
		setVisible('trSgte4',true);	
		
		setEnabled('btnSgte4',false,'boton');
		setEnabled('btnAnt4',false,'boton');		
		
	}else if(sgte=='dirCliente')
	{
		//mostrar la direccion del cliente
		var btn = getObject('btnMostrarDirCli');
		btn.presionado = btn.presionado=='0'?'1':'0';
		
		if(btn.presionado=='1')
		{
			setVisible('trDir2',true);
			btn.value=btn.value.replace('Mostrar','Ocultar');
		}else if(btn.presionado=='0')
		{
			setVisible('trDir2',false);
			btn.value=btn.value.replace('Ocultar','Mostrar');
			limpiarDireccion('dircli');
		}
	}else if(sgte=='dirTrabajo')
	{
		//mostra la direccion del trabajo
		var btn = getObject('btnMostrarDirTra');
		btn.presionado = btn.presionado=='0'?'1':'0';
		
		if(btn.presionado=='1')
		{
			setVisible('trDir3',true);
			btn.value=btn.value.replace('Mostrar','Ocultar');
		}else if(btn.presionado=='0')
		{
			setVisible('trDir3',false);
			btn.value=btn.value.replace('Ocultar','Mostrar');
			limpiarDireccion('dirtra');
		}
		
	}else if(sgte=='tblCampana')
	{
		var msjDir; 
		
		msjDir = validacionDireccion('dirfact');
		if(msjDir!='')
		{
			alert(msjDir);
			return false;
		}
		
		if(getObject('btnMostrarDirCli').presionado==1)
		{
			msjDir = validacionDireccion('dircli');
			if(msjDir!='')
			{
				alert(msjDir);
				return false;
			}
		}else
		{
			copiarDireccion('Usc_direccion1','Usc_direccion2');
		}
		
		if(getObject('btnMostrarDirTra').presionado==1)
		{
			msjDir = validacionDireccion('dirtra');
			if(msjDir!='')
			{
				alert(msjDir);
				return false;
			}
		}else
		{
			copiarDireccion('Usc_direccion1','Usc_direccion3');
		}
		
		//if(getValue('hdnTipoCargo')!='0' && getValue('hdnTipoCargo')!='')
		if(getValue('txtNumeroCF')!='0' && getValue('txtNumeroCF')!='')
		{
			setVisible('trOficina',true);
		}
		
		/*
		habilitarDireccion('Usc_direccion1',false)
		habilitarDireccion('Usc_direccion2',false)
		habilitarDireccion('Usc_direccion3',false)
		
		setEnabled('btnMostrarDirCli',false,'boton');
		
		setEnabled('btnMostrarDirTra',false,'boton');
		*/
			
		setVisible('trCampana',true);				
		setVisible('trSgte5',true);
		
		setEnabled('btnSgte6',false,'boton');
		//setEnabled('btnAnt6',false,'boton');
		
	}else if(sgte=='migrar')
	{
		//if( (getValue('hdnTipoCargo')!='0' && getValue('hdnTipoCargo')!='') && getValue('ddlOficina')=='0' || getValue('ddlOficina')=='')
		if( (getValue('txtNumeroCF')!='0' && getValue('txtNumeroCF')!='') && getValue('ddlOficina')=='0' || getValue('ddlOficina')=='')
		{
			alert('Debe seleccionar una oficina.');
			return false;
		}
		
		setEnabled('ddlOficina',false,'clsSelectEnable0');
		
		setVisible('trMigrar',true);
		setEnabled('btnSgte5',false,'boton');
		setEnabled('ddlCampana',false,'clsSelectEnable0');	
		
		//setEnabled('btnAnt5',false,'boton');			
	}
}

function validacionPlanServicios()
{
	var tbl = document.getElementById('dgPlan');
	
	var chk = document.getElementById('chkCorreo');
	
	if(getValue('ddlPlazoAcuerdo')=='-1')
	{
		alert('Debe seleccionar el plazo del acuerdo.');
		return false;
	}
	if(tbl==null || tbl.rows.length<=0)
	{
		alert('Debe seleccionar el plan y servicios.');
		return false;
	}
	
	if(chk.checked && (getValue('txtCorreo')=='' || getValue('txtConfirmCorreo')=='') )
	{
		alert('Debe ingresar el correo y confirmacion de correo.');
		return false;
	}else
	{		
		if(getValue('txtCorreo')!='' && !ValidarEMailAfi('txtCorreo','Correo'))
		{
			return false;
		}
		
		if( getValue('txtCorreo')!='' && (getValue('txtCorreo').toUpperCase()!=getValue('txtConfirmCorreo').toUpperCase()) )
		{
			alert('Los correos no coinciden.');return false;
		}
	}
	
	return true;
}

function validacionCliente()
{
	if(getValue('hdnValCliente')==0)
	{
		return false;
	}
	return true;
}

function datosWhiteList(cadena)
{
	setValue('hdnWhitelist',cadena)
}

function obtenerDatosWhiteList()
{
	var cadena = getValue('hdnWhitelist');
	//alert(cadena);
	if(cadena!='')
	{
		var objW = JSON.parse(cadena,null);
		//alert(objW);
		//alert(objW.whitelist);
		//alert(objW.whitelist.whitelist[0]);
		return objW.whitelist.whitelist[0];
	}
	return null;
}

function chkCorreo_click()
{
	var txtCorreo = document.getElementById('txtCorreo');
	var txtConfirmCorreo = document.getElementById('txtConfirmCorreo');
	
	if(document.getElementById('chkCorreo').checked)
	{
		txtCorreo.className='clsInputEnableB';
		txtCorreo.readOnly=false;
		txtConfirmCorreo.className='clsInputEnableB';
		txtConfirmCorreo.readOnly=false;
		setFocus('txtCorreo')
		
	}else
	{
		txtCorreo.value='';
		txtConfirmCorreo.value='';
		txtCorreo.className='clsInputDisable';
		txtConfirmCorreo.className='clsInputDisable';
		txtCorreo.readOnly=true;
		txtConfirmCorreo.readOnly=true;
	}
}

function ddlDoc_change()
{
	setValue('txtDocumento','');
	setFocus('txtDocumento');
	
	var arrTipo = document.getElementById('hdnTiposDocumento').value.split('|');
	
	if(getValue('ddlDoc')=='-1')
	{
		setEnabled('txtDocumento',false,'clsInputDisable  ')
	}else
	{
		var idTipoDoc = getValue('ddlDoc').split('|')[0];
		var txtDocumento = document.getElementById('txtDocumento');
		
		if(idTipoDoc==arrTipo[0])
		{
			//dni
			txtDocumento.maxLength = 8;
			txtDocumento.onkeydown = function() { validarNumero(event) };
		}else if(idTipoDoc==arrTipo[1])
		{
			//Carnet extranjeria
			txtDocumento.maxLength = 9;
			txtDocumento.onkeydown = function() { validarAlfaNumerico(event) };
		}
		setEnabled('txtDocumento',true,'clsInputEnableB  ')
	}
}

function validacionClienteOk()
{
	if(getValue('hdnValCliente')=='1')
	{
		setEnabled('ddlDoc',false,'clsSelectEnable0');
		setEnabled('txtDocumento',false,'clsInputDisable');
		
		setEnabled('txtNumero',false,'clsInputDisable');
		
	}
}

function validarBuscar()
{
	if(getValue('txtDocumento')=='' || getValue('txtNumero')=='')
	{
		alert('Debe ingresar el numero de documento y numero telefonico.');
		return false;
	}
	return true;
}

//funcion de la grilla de servicios

function seleccionarItem(chk)
{
			var xState = chk.checked;
			var theBox = chk;
			var nombre = "chk_";
			var idBox;
			var cfmax = getValue('hdnCargoFijoMax');
			elm = theBox.form.elements;

			if(xState==true)
			{
				if( (cf_seleccionado+eval(chk.cargoFijo)) >cfmax)
				{
					alert('No se puede seleccionar porque excede el cargo fijo maximo: ' + cfmax);
					return false;
				}
				cf_seleccionado+=eval(chk.cargoFijo);
			}else
			{
				cf_seleccionado-=eval(chk.cargoFijo);
			}			
			
			for(i=0;i<elm.length;i++){
				if( elm[i].type == "checkbox" && elm[i].id != theBox.id && elm[i].grupo==theBox.grupo && elm[i].grupo!="" && elm[i].sel != '1' ){
					idBox = elm[i].id;
					var index = idBox.indexOf(nombre);
					if ( index>-1 ){
							elm[i].disabled= xState;
					}
				}
			}
			return true;
}

var cf_seleccionado=0;//cargo fijo de planes y servicios seleccionados
function ddlPlan_change(value)
{
	//alert(value.split('|')[1]);
	if(value!='0')
	{
		cf_seleccionado = eval(value.split('|')[1]);		
	}
}

function ddlplan_post_callback()
{
	/*validacion control consumo, si en whitelist el campo control 
	consumo esta en 1, entonces el check control consumo
    debe estar marcado y deshabilitado*/
	//if(objWhiteList.control_consumo=='1')
	//{
		var tbl = document.getElementById('dgServicios');
		if(tbl!=null && tbl.rows.length>0)
		{
			var chk;
			for(var x=0;x<tbl.rows.length;x++)
			{
				chk = tbl.rows[x].cells[0].childNodes[0];
				if(chk.sel=='1')
				{
					chk.checked=true;
					chk.disabled=true;
				}
				if(chk.codigo==objWhiteList.cod_control_consumo)
				{
					chk.checked=true;
					chk.disabled=true;
				}
			}
		}
	//}
}

function btnAgregarPlan_click()
{
	var tbl = document.getElementById('dgPlan');
	if(tbl!=null && tbl.rows.length>1)
	{
		alert('Debe quitar el plan actual para agregar.');
		return false;
	}
	
	if(document.getElementById('ddlPlan').value=='0')
	{
		alert('Debe seleccionar el plan.');
		return false;
	}
	
	//validacion agregar
	tbl = document.getElementById('dgServicios');
	
	var chk;
	var valido=false;
	
	//por lo menos un servicio seleccionado
	if(tbl!=null)
	{
		for(var x=0;x<tbl.rows.length;x++)
		{
			chk = tbl.rows[x].cells[0].childNodes[0];
			if(chk.checked==true)
			{
				valido=true;
				break;
			}
		}
	}
	
	//ya no se valida los servicios, puede agregar un plan sin servicios
	/*if(!valido)
	{
		alert('Debe seleccionar algun servicio.');
		return false;
	}*/
	if(tbl!=null)
	{
		obtenerServiciosSeleccionados();
	}
}

function obtenerServiciosSeleccionados()
{
	var tbl = document.getElementById('dgServicios');
	
	var chk;
	var cadena='';
	for(var x=0;x<tbl.rows.length;x++)
	{
		chk = tbl.rows[x].cells[0].childNodes[0];
		if(chk.checked==true)
		{
			cadena += String(chk.codigo) +';'+ String(chk.Descripcion) + '|';		
		}
	}
	
	if(cadena!='')
	{
		cadena = cadena.substr(0,cadena.length-1);
	}
	
	setValue('hdnServicios',cadena);
}

function obtenerImportePlanesServicio(flag_cargo)
{
	var num_cf=0;
	if(flag_cargo=='MIN')
	{
		//cargo fijo min
		num_cf = objWhiteList.num_cf_min;
		
		if(objWhiteList.num_cf_min==0 || objWhiteList.num_cf_min==null || objWhiteList.num_cf_min=='')
		{
			return 	objWhiteList.monto_flat;
		}
	}else if(flag_cargo=='MAX')
	{
		//cargo fijo max
		num_cf = objWhiteList.num_cf_max;
		
		if(objWhiteList.num_cf_max==0 || objWhiteList.num_cf_max==null || objWhiteList.num_cf_max=='')
		{
			return 	objWhiteList.monto_flat;
		}
	}
	
	return num_cf * cf_seleccionado;
}


//funciones varias

//direcciones
function habilitarDireccion(idUc,estado)
{
	setEnabled(getUserControlFromUC(idUc,'ddlPrefijo').id,estado,'clsSelectEnable0');//,
	setEnabled(getUserControlFromUC(idUc,'txtDireccion').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtNroPuerta').id,estado,'clsInputDisable');
	
	setEnabled(getUserControlFromUC(idUc,'divSinNumero').id,false,'Arial10b');
	
	setEnabled(getUserControlFromUC(idUc,'ddlEdificacion').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'txtLote').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtManzana').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'ddlTipoInterior').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'txtNroInterior').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'ddlUrbanizacion').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'txtUrbanizacion').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'ddlZona').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'txtNombreZona').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtReferencia').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'ddlDepartamento').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'ddlProvincia').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'ddlDistrito').id,estado,'clsSelectEnable0');
	setEnabled(getUserControlFromUC(idUc,'txtCodigoPostal').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtUbigeo').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtPrefijoTelefonoReferencia').id,estado,'clsInputDisable');
	setEnabled(getUserControlFromUC(idUc,'txtTelefonoReferencia').id,estado,'clsInputDisable');
}

function copiarDireccion(idUcOrigen,idUcDestino)
{
	setValue(getUserControlFromUC(idUcDestino,'ddlPrefijo').id,getUserControlFromUC(idUcOrigen,'ddlPrefijo').value);
	setValue(getUserControlFromUC(idUcDestino,'txtDireccion').id,getUserControlFromUC(idUcOrigen,'txtDireccion').value);
	setValue(getUserControlFromUC(idUcDestino,'txtNroPuerta').id,getUserControlFromUC(idUcOrigen,'txtNroPuerta').value);
	
	getUserControlFromUC(idUcDestino,'chkSinNumero').checked=getUserControlFromUC(idUcOrigen,'chkSinNumero').checked;
	
	setValue(getUserControlFromUC(idUcDestino,'ddlEdificacion').id,getUserControlFromUC(idUcOrigen,'ddlEdificacion').value);
	setValue(getUserControlFromUC(idUcDestino,'txtLote').id,getUserControlFromUC(idUcOrigen,'txtLote').value);
	setValue(getUserControlFromUC(idUcDestino,'txtManzana').id,getUserControlFromUC(idUcOrigen,'txtManzana').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlTipoInterior').id,getUserControlFromUC(idUcOrigen,'ddlTipoInterior').value);
	setValue(getUserControlFromUC(idUcDestino,'txtNroInterior').id,getUserControlFromUC(idUcOrigen,'txtNroInterior').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlUrbanizacion').id,getUserControlFromUC(idUcOrigen,'ddlUrbanizacion').value);
	setValue(getUserControlFromUC(idUcDestino,'txtUrbanizacion').id,getUserControlFromUC(idUcOrigen,'txtUrbanizacion').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlZona').id,getUserControlFromUC(idUcOrigen,'ddlZona').value);
	setValue(getUserControlFromUC(idUcDestino,'txtNombreZona').id,getUserControlFromUC(idUcOrigen,'txtNombreZona').value);
	setValue(getUserControlFromUC(idUcDestino,'txtReferencia').id,getUserControlFromUC(idUcOrigen,'txtReferencia').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlDepartamento').id,getUserControlFromUC(idUcOrigen,'ddlDepartamento').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlProvincia').id,getUserControlFromUC(idUcOrigen,'ddlProvincia').value);
	setValue(getUserControlFromUC(idUcDestino,'hidProvinciaId').id,getUserControlFromUC(idUcOrigen,'hidProvinciaId').value);
	setValue(getUserControlFromUC(idUcDestino,'ddlDistrito').id,getUserControlFromUC(idUcOrigen,'ddlDistrito').value);
	setValue(getUserControlFromUC(idUcDestino,'hidDistritoId').id,getUserControlFromUC(idUcOrigen,'hidDistritoId').value);
	setValue(getUserControlFromUC(idUcDestino,'txtCodigoPostal').id,getUserControlFromUC(idUcOrigen,'txtCodigoPostal').value);
	setValue(getUserControlFromUC(idUcDestino,'txtUbigeo').id,getUserControlFromUC(idUcOrigen,'txtUbigeo').value);
	setValue(getUserControlFromUC(idUcDestino,'txtPrefijoTelefonoReferencia').id,getUserControlFromUC(idUcOrigen,'txtPrefijoTelefonoReferencia').value);
	setValue(getUserControlFromUC(idUcDestino,'txtTelefonoReferencia').id,getUserControlFromUC(idUcOrigen,'txtTelefonoReferencia').value);
	
	//setValue(getUserControlFromUC(idUcDestino,'txtRUCEmpleador').id,getUserControlFromUC(idUcOrigen,'txtRUCEmpleador').value);
	//setValue(getUserControlFromUC(idUcDestino,'txtNombreEmpresa').id,getUserControlFromUC(idUcOrigen,'txtNombreEmpresa').value);
}

function validacionDireccion(flag)
{
	var ucid;
	var titulo;
	
	if(flag=='dirfact')
	{
		ucid='Usc_direccion1';
		titulo='Direccion de Facturacion:\n\n';
	}else if(flag=='dircli')
	{
		titulo='Direccion de Cliente:\n\n';
		ucid='Usc_direccion2';
	}else if(flag=='dirtra')
	{
		titulo='Direccion de Trabajo:\n\n';
		ucid='Usc_direccion3';
	}
	
	var msj='';
	
	if(getUserControlFromUC(ucid,'ddlPrefijo').value =='')
	{
		msj+= "Debe seleccionar el prefijo de direccion." + "\n";
	}
	
	if(getUserControlFromUC(ucid,'txtDireccion').value =='')
	{
		msj+= "Debe ingresar la direccion." + "\n";
	}
	
	if(getUserControlFromUC(ucid,'txtNroPuerta').value =='')
	{
		msj+= "Debe ingresar el numero de puerta." + "\n";
	}
	if(getUserControlFromUC(ucid,'txtReferencia').value =='')
	{
		msj+= "Debe ingresar la Referencia de la Direccion." + "\n";
	}
	if(getUserControlFromUC(ucid,'ddlDepartamento').value =='-1')
	{
		msj+= "Debe seleccionar el departamento." + "\n";
	}
	if(getUserControlFromUC(ucid,'ddlProvincia').value =='')
	{
		msj+= "Debe seleccionar la provincia." + "\n";
	}
	if(getUserControlFromUC(ucid,'ddlDistrito').value =='')
	{
		msj+= "Debe seleccionar el distrito." + "\n";
	}
	if(getUserControlFromUC(ucid,'txtPrefijoTelefonoReferencia').value =='')
	{
		msj+= "Debe Ingresar el Prefijo del Telefono." + "\n";
	}
	if(getUserControlFromUC(ucid,'txtTelefonoReferencia').value =='')
	{
		msj+= "Debe Ingresar el Telefono de Referencia." + "\n";
	}
	
	if(msj!='')
	{
		msj = titulo + msj;
	}
	
	return msj;
}

function getUserControlFromUC(ucid,cid)
{
	return document.getElementById(ucid + '_' + cid);
}

function validarMigrar()
{
	//alguna validacion adicional antes de la migracion
	setEnabled('btnCancelar',false,'Boton');
	return true;
}
function validarCancelar(){
	//setEnabled('btnMostrarDirCli',true,'Boton');
	return true;
}

function limpiar()
{
	//controles de validacion cliente
	setValue('ddlDoc','-1');
	setEnabled('ddlDoc',true,'clsSelectEnable0');
	
	setValue('txtDocumento','');
	setEnabled('txtDocumento',false,'clsInputDisable');
	
	setValue('txtNumero','');
	setEnabled('txtNumero',true,'clsInputEnable');
	
	setEnabled('btnBuscar',true,'Boton');
	
	//controles datos del cliente
	
	setValue('ddlTipoDoc','-1');
	setValue('txtNombre','');
	setValue('txtNroDoc','');
	setValue('txtApePat','');
	setValue('txtApeMat','');
	setEnabled('btnSgte2',true,'Boton');
	
	//controles condiciones de venta
	getObject('chkCorreo').checked=false;
	setValue('txtCorreo','');
	setEnabled('txtCorreo',false,'clsInputDisable');
	
	setValue('txtConfirmCorreo','');
	setEnabled('txtConfirmCorreo',false,'clsInputDisable');
	
	setValue('ddlPlazoAcuerdo','-1');
	setEnabled('ddlPlazoAcuerdo',true,'clsSelectEnable0');
	setValue('ddlPlan','0');
	setEnabled('ddlPlan',true,'clsSelectEnable0');
	
	setEnabled('btnQuitarPlan',true,'Boton');
	setEnabled('btnAgregarPlan',true,'Boton');
	setEnabled('btnSgte3',true,'Boton');
	
	//controles resultado preliminar de evaluacion
	setValue('txtTipoGarantia','');
	setValue('txtRiesgo','');
	setValue('txtNumeroCF','');
	setValue('txtImporte','');
	setEnabled('btnSgte4',true,'Boton');
	
	//controles de direccion
	limpiarDireccion('dirfact');
	limpiarDireccion('dircli');
	limpiarDireccion('dirtra');
	
	setEnabled('btnMostrarDirCli',true,'Boton');
	setEnabled('btnMostrarDirTra',true,'Boton');
	
	//controles operacion y campaña
	
	if(getValue('hdnCampanaDefault')!='')
	{
		setValue('ddlCampana',getValue('hdnCampanaDefault'));
	}
	
	setEnabled('ddlCampana',true,'clsSelectEnable0');
	setValue('ddlOficina','0');
	setEnabled('ddlOficina',true,'clsSelectEnable0');
	
	setEnabled('btnSgte6',true,'Boton');
	setEnabled('btnSgte5',true,'Boton');
	
	//controles hidden
	setValue('hdnValCliente','');
	setValue('hdnCargoFijoMax','');
	setValue('hdnServicios','');
	setValue('hdnTipoCargo','');
	setValue('hdnCFPlanServicios','');
	setValue('hdnFlagControlConsumo','');
	
	//tr
	setVisible('trMigrar',false);
	setVisible('trCampana',false);
	setVisible('trDirFact',false);
	setVisible('trDir2',false);
	setVisible('trDir3',false);
	setVisible('trResultado',false);
	setVisible('trCondicionesVenta',false);
	setVisible('trDatosCliente',false);
	
	
	//tr
	setVisible('trSgte1',false);
	setVisible('trSgte2',false);
	setVisible('trSgte3',false);
	setVisible('trSgte4',false);
	setVisible('trSgte5',false);
	
	objWhiteList=null;
	
}

function limpiarDireccion(flag)
{
	var ucid;
	
	if(flag=='dirfact')
	{
		ucid='Usc_direccion1';
	}else if(flag=='dircli')
	{
		ucid='Usc_direccion2';
	}else if(flag=='dirtra')
	{
		ucid='Usc_direccion3';
	}
	
	setValue(getUserControlFromUC(ucid,'ddlPrefijo').id,'');
	setEnabled(getUserControlFromUC(ucid,'ddlPrefijo').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'txtDireccion').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtDireccion').id,false,'clsInputDisable');
	setValue(getUserControlFromUC(ucid,'txtNroPuerta').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtNroPuerta').id,false,'clsInputDisable');
	
	getUserControlFromUC(ucid,'chkSinNumero').checked=false;
	setEnabled(getUserControlFromUC(ucid,'divSinNumero').id,false,'Arial10b');
	
	setValue(getUserControlFromUC(ucid,'ddlEdificacion').id,'-1');
	setEnabled(getUserControlFromUC(ucid,'ddlEdificacion').id,false,'clsSelectDisable');
	
	setValue(getUserControlFromUC(ucid,'txtLote').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtLote').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'txtManzana').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtManzana').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'ddlTipoInterior').id,'-1');
	setEnabled(getUserControlFromUC(ucid,'ddlTipoInterior').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'txtNroInterior').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtNroInterior').id,false,'clsInputDisable');
	setValue(getUserControlFromUC(ucid,'ddlUrbanizacion').id,'-1');
	setEnabled(getUserControlFromUC(ucid,'ddlUrbanizacion').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'txtUrbanizacion').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtUrbanizacion').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'ddlZona').id,'-1');
	setEnabled(getUserControlFromUC(ucid,'ddlZona').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'txtNombreZona').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtNombreZona').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'txtReferencia').id,'');
	setValue(getUserControlFromUC(ucid,'ddlDepartamento').id,'-1');
	setEnabled(getUserControlFromUC(ucid,'ddlDepartamento').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'ddlProvincia').id,'');
	setEnabled(getUserControlFromUC(ucid,'ddlProvincia').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'hidProvinciaId').id,'');
	setValue(getUserControlFromUC(ucid,'ddlDistrito').id,'');
	setEnabled(getUserControlFromUC(ucid,'ddlDistrito').id,true,'clsSelectEnable0');
	
	setValue(getUserControlFromUC(ucid,'hidDistritoId').id,'');
	setValue(getUserControlFromUC(ucid,'txtCodigoPostal').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtCodigoPostal').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'txtUbigeo').id,'');
	setEnabled(getUserControlFromUC(ucid,'txtUbigeo').id,false,'clsInputDisable');
	
	setValue(getUserControlFromUC(ucid,'txtPrefijoTelefonoReferencia').id,'');
	setValue(getUserControlFromUC(ucid,'txtTelefonoReferencia').id,'');
	
	getUserControlFromUC(ucid,'lblContadorDireccion').innerText='';
	getUserControlFromUC(ucid,'lblContadorReferencia').innerText='';
	
	//setValue(getUserControlFromUC(idUcDestino,'txtRUCEmpleador').id,getUserControlFromUC(idUcOrigen,'txtRUCEmpleador').value);
	//setValue(getUserControlFromUC(idUcDestino,'txtNombreEmpresa').id,getUserControlFromUC(idUcOrigen,'txtNombreEmpresa').value);
}

function f_finalizar(){

	//alert('finaliza!');
	setVisible('trCampana',false);	
	return true;
}

function prueba1()
{
	alert(getValue('hdnServicios'));
}
 
 
