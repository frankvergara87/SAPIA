function mostrarProvincia(ddlDep){	

	var pos_usc= Mid(ddlDep.id, 0, 15);
	
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(ddlDep.id, 0, 21);
	
	var dpto_id,provincia,distrito,cad;
	cad = getValue(pos_usc + 'hidProvincias');			
	dpto_id = '';
	dpto_id =getValue(pos_usc + 'ddlDepartamento');	
	provincia =document.getElementById(pos_usc + 'ddlProvincia');
	distrito = document.getElementById(pos_usc + 'ddlDistrito');
	
	setValue(pos_usc + 'txtCodigoPostal','');
	setValue(pos_usc + 'hidDptoId',dpto_id);		
	
	var i,j;
	var oElm;
	for (j=provincia.length - 1;j>=0;j--)
		provincia.remove(j);
		
	for (j=distrito.length - 1;j>=0;j--)
		distrito.remove(j);
			
	oElm = document.createElement("OPTION");
	oElm.value = "";
	oElm.text = "--Seleccionar--";
	provincia.add(oElm);
			
	oElm = document.createElement("OPTION");
	oElm.value = "";
	oElm.text = "--Seleccionar--";
	distrito.add(oElm);			
		
	if (dpto_id != ''){
		var aProvincia = cad.split("|")
		var aDatos;
		for (i=0;i < aProvincia.length;i++){
			aDatos = aProvincia[i].split(";");
			if ( aDatos[2] == dpto_id){
				oElm = document.createElement("OPTION");
				oElm.value = aDatos[0];
				oElm.text = aDatos[1];
				provincia.add(oElm);
			}
		}
	}
}	
function mostrarDistrito(ddlProv)	{
	var pos_usc= Mid(ddlProv.id, 0, 15);
	
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(ddlProv.id, 0, 21);
		
	var dpto_id,provincia_id,distrito,cad;
	cad =getValue(pos_usc + 'hidDistritos');
	
	dpto_id =getValue(pos_usc + 'ddlDepartamento'); 
	provincia_id =getValue(pos_usc + 'ddlProvincia');
	distrito = document.getElementById(pos_usc + 'ddlDistrito');	
	setValue(pos_usc + 'txtCodigoPostal','');
	
	document.getElementById(pos_usc + 'hidProvinciaId').value=provincia_id;
	
	var i,j;
	var oElm;							
	for (j=distrito.length - 1;j>=0;j--)
		distrito.remove(j);
						
	oElm = document.createElement("OPTION");
	oElm.value = "";
	oElm.text = "Seleccione...";
	distrito.add(oElm);
			
	if (provincia_id != ''){
		var aDistrito = cad.split("|")
		var aDatos;
		for (i=0;i < aDistrito.length;i++){
			aDatos = aDistrito[i].split(";");
			if ( aDatos[2] == provincia_id){
				oElm = document.createElement("OPTION");
				oElm.value = aDatos[0];
				oElm.text = aDatos[1];
				oElm.id =  aDatos[3];
				distrito.add(oElm);
			}
		}
	}
}

function mostrarCodigoPostal(ddldist){	
	var pos_usc= Mid(ddldist.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(ddldist.id, 0, 21);
	var distrito;
	var codigoPostal = '';				
	distrito = document.getElementById(pos_usc + 'ddlDistrito');
	codigoPostal = distrito[distrito.selectedIndex].id;
	
	if (codigoPostal == '' || codigoPostal == 'undefined') {		
		codigoPostal =obtenerCodigoPostal(distrito.value,pos_usc);
		if (codigoPostal == 'undefined') codigoPostal = '';
	}
	setValue(pos_usc + 'txtCodigoPostal',codigoPostal);
	setValue(pos_usc + 'hidDistritoId',distrito.value);
		
	document.getElementById(pos_usc + 'hidDistritoId').value=distrito.value;
		
	//var almacenDefecto = obtenerAlmacenDefecto(distrito.value);
	//setValue('hidAlmacenDefecto',almacenDefecto);		
}
function obtenerCodigoPostal(distrito_id,pos_usc){			
	///var pos_usc= Mid(distrito_id.id, 0, 15);
	if (distrito_id == '-1' || distrito_id == '') return '';
	var cad = getValue(pos_usc + 'hidListaCodigoPostal');
	
	if (cad == '') return '';				
	var aDistrito = cad.split("|")
	var i,aDatos;
	
	for (i=0;i < aDistrito.length;i++){
		aDatos = aDistrito[i].split(";");
		if ( aDatos[0] == distrito_id){
			return aDatos[1];
		}
	}
	return '';
}
/***************************************************************************************************/

function sinNumero(chk){	
	//chk=this
	var pos_usc= Mid(chk.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(chk.id, 0, 21);
	if (chk.checked == true){			
		setEnabled(pos_usc + 'txtNroPuerta',false,'clsInputDisable');
		setValue(pos_usc + 'txtNroPuerta',getValue(pos_usc + 'hidSinNumero'));
	}else{			
		setEnabled(pos_usc + 'txtNroPuerta',true,'clsInputEnable');
		setValue(pos_usc + 'txtNroPuerta','');
		setFocus(pos_usc + 'txtNroPuerta');
	}
	//onkeyup_NroPuerta(pos_usc + 'txtNroPuerta');
	onkeyup_NroPuerta(document.getElementById(pos_usc + 'txtNroPuerta'));
}
function onkeyup_NroPuerta(txt){
	//txt=this
	var pos_usc= Mid(txt.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(txt.id, 0, 21);
	var key = event.keyCode;

	var salida = txt.value;
	salida = eliminaCaracteresNroPuerta(salida);
	if (salida != ''){					
		
		setEnabled(pos_usc +'ddlEdificacion',true,'');
		setValue(pos_usc +'ddlEdificacion','-1');
		setValue(pos_usc +'txtManzana','');
		setValue(pos_usc +'txtLote','');
		setEnabled(pos_usc +'txtManzana',false,'clsInputDisable');
		setEnabled(pos_usc +'txtLote',false,'clsInputDisable');
	}else{					
		setEnabled(pos_usc +'ddlEdificacion',true,'');					
	}				
	var total = contador_d('D',pos_usc);
	if (total > K_CANTIDAD_DIRECCION){
		salida = salida.substr(0,salida.length-1);
		setValueHTML(pos_usc +'lblContadorDireccion',K_CANTIDAD_DIRECCION);
	}
	txt.value = salida;	
}

function onchange_prefijo(idusc){
	//idusc=this	
	//var pos_usc='Usc_direccion1_';	
	var pos_usc= Mid(idusc.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(idusc.id, 0, 21);
	
	setValue(pos_usc + 'txtDireccion','');
	setValue(pos_usc + 'txtNroPuerta','');
		
	var cbo=idusc;//document.getElementById('<%=ddlPrefijo.ClientId %>');
	
	var total = contador_d('D',pos_usc);
	
	var prefijo = cbo.value;
	var cambiar = false;		
	if (prefijo != '-1'){
		cambiar = true;
	}
	
	if (prefijo == '99'){				
		cambiar = false;
		
		var textoprefijo =cbo[cbo.options.selectedIndex].text					
		textoprefijo = trim(textoprefijo.split("-")[1]);		
		setValue(pos_usc + 'txtDireccion',textoprefijo);										
		
		total+=textoprefijo.length;
		setValue(pos_usc + 'ddlEdificacion','MZ');			
		contador_d('D',pos_usc);			
		setEnabled(pos_usc + 'txtManzana',true,'clsInputEnable');
		setEnabled(pos_usc + 'txtLote',true,'clsInputEnable');
	}
		
	if (cambiar == true){			
		if (total > K_CANTIDAD_DIRECCION){
			setValueHTML(pos_usc + 'lblContadorDireccion',K_CANTIDAD_DIRECCION);			
			cbo.value = '-1';
			return ;
		}else{
			total = parseInt(total,10)-2;
		}
				
		setEnabled(pos_usc + 'txtDireccion',true,'clsInputEnable');
		setEnabled(pos_usc + 'txtNroPuerta',true,'clsInputEnable');
		setEnabled(pos_usc + 'divSinNumero',true,'');//panelSinNumero
	}else{						
		setEnabled(pos_usc + 'txtDireccion',false,'clsInputDisable');
		setEnabled(pos_usc + 'txtNroPuerta',false,'clsInputDisable');
		setEnabled(pos_usc + 'divSinNumero',false,'');
				
		document.getElementById(pos_usc + 'chkSinNumero').checked = false;		
	}
	if (total == 0) total = '';
	setValueHTML(pos_usc + 'lblContadorDireccion',total);	
}
function onkeyup_direccion(txt,cbo_id,flagReferencia){
	//this,'ddlPrefijo'	
	var pos_usc= Mid(txt.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(txt.id, 0, 21);
	var key = event.keyCode;
	
	var maximo = 40;
	var cbo_des =getText(pos_usc + cbo_id); //getText(cbo_id);
	var tamanno_cbo = cbo_des.length + 1 ;
	var txt_des = Trim(txt.value);
	var tamanno_txt = txt_des.length;
	var total = tamanno_txt + tamanno_cbo;
	var total_cortado = 0; 				
	if (total >= maximo){
		total_cortado = maximo - (tamanno_cbo + 1);
		txt.value = txt_des.substring(0, total_cortado); 
	}
	var salida = txt.value;				
	salida = eliminaCaracteresInvalidos(salida);
	var total = contador_d(flagReferencia,pos_usc);				
	if (total > K_CANTIDAD_DIRECCION){					
		salida = salida.substr(0,salida.length-1);				
		if (flagReferencia == 'D')		
			setValueHTML(pos_usc + 'lblContadorDireccion',K_CANTIDAD_DIRECCION);
		else				
			setValueHTML(pos_usc + 'lblContadorReferencia',K_CANTIDAD_DIRECCION);
	}
	txt.value = salida;
}	
function onchange_edificacion(cbo){
	//cbo=this
	var pos_usc= Mid(cbo.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(cbo.id, 0, 21);
	setValue(pos_usc + 'txtManzana','');
	setValue(pos_usc + 'txtLote','');
	setEnabled(pos_usc + 'txtLote',false,'clsInputDisable');
	var total = contador_d('D',pos_usc);
	
	if (cbo.value != '-1'){
		if (total > K_CANTIDAD_DIRECCION){
			setValueHTML(pos_usc + 'lblContadorDireccion',K_CANTIDAD_DIRECCION);
			cbo.value = '-1';
			return ;
		}else{
			total = parseInt(total,10)-3;
			if (total == 0) total = '';
			setValueHTML(pos_usc + 'lblContadorDireccion',total);				
		}		
		setEnabled(pos_usc + 'txtManzana',true,'clsInputEnable');
		if (cbo.value == 'MZ'){
			setEnabled(pos_usc + 'txtLote',true,'clsInputEnable');
		}
	}else{
		setEnabled(pos_usc + 'txtManzana',false,'clsInputDisable');		
	}
}
function onkeyup_mz_lote(txt,flagReferencia){		
	var pos_usc= Mid(txt.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(txt.id, 0, 21);
	if (document.all){		
		var salida = txt.value;
		salida = eliminaCaracteresInvalidos(salida);
		var total = contador_d(flagReferencia,pos_usc);
		if (total > K_CANTIDAD_DIRECCION){
			salida = salida.substr(0,salida.length-1);
			if (flagReferencia == 'D')
				setValueHTML(pos_usc + 'lblContadorDireccion',K_CANTIDAD_DIRECCION);
			else
				setValueHTML(pos_usc + 'lblContadorReferencia',K_CANTIDAD_DIRECCION);
		}
		txt.value = salida;
	}
}

function onchange_interior(cbo){
	//cbo=this
	var pos_usc= Mid(cbo.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(cbo.id, 0, 21);
	setValue(pos_usc + 'txtNroInterior','');	
	var total = contador_d('D',pos_usc);
	if (cbo.value != '-1'){					
		if (total > K_CANTIDAD_DIRECCION){
			setValueHTML(pos_usc + 'lblContadorDireccion',total);				
			cbo.value = '-1';
			return ;
		}else{
			total = parseInt(total,10)-4;
			if (total == 0) total = '';				
			setValueHTML(pos_usc + 'lblContadorDireccion',total);				
		}			
		setEnabled(pos_usc + 'txtNroInterior',true,'clsInputEnable');
	}else{			
		setEnabled(pos_usc + 'txtNroInterior',false,'clsInputDisable');
	}		
}
function onchange_urbanizacion(cbo){
	var pos_usc= Mid(cbo.id, 0, 15);
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(cbo.id, 0, 21);
	
	setValue(pos_usc + 'txtUrbanizacion','');
	var total = contador_d('R',pos_usc);
	if (cbo.value != '-1'){
		if (total > K_CANTIDAD_DIRECCION){
			setValueHTML(pos_usc + 'lblContadorReferencia',K_CANTIDAD_DIRECCION);
			cbo.value = '-1';
			return ;
		}else{
			total = parseInt(total,10)-4;
			if (total == 0) total = '';
			setValueHTML(pos_usc + 'lblContadorReferencia',total);
		}
		setEnabled(pos_usc + 'txtUrbanizacion',true,'clsInputEnable');
	}else{
		setEnabled(pos_usc + 'txtUrbanizacion',false,'clsInputDisable');
	}
}
function onchange_zona(cbo){
	var pos_usc= Mid(cbo.id, 0, 15);	
	if(pos_usc=="Usc_direccion_c")
		pos_usc= Mid(cbo.id, 0, 21);	
	setValue(pos_usc + 'txtNombreZona','');
	var total = contador_d('R',pos_usc);
	if (cbo.value != '-1'){					
		if (total > K_CANTIDAD_DIRECCION){			
			setValueHTML(pos_usc + 'lblContadorReferencia',K_CANTIDAD_DIRECCION);
			cbo.value = '-1';
			return ;
		}else{
			total = parseInt(total,10)-4;
			if (total == 0) total = '';							
			setValueHTML(pos_usc + 'lblContadorReferencia.ClientId',total);
		}
		setEnabled(pos_usc + 'txtNombreZona',true,'clsInputEnable');
	}else{
		setEnabled(pos_usc + 'txtNombreZona',false,'clsInputDisable');
	}				
}

function contador_d(flagReferencia,pos_usc){
	//tipoDireccion(F),flagReferencia(D)
	var completaD = '';
	var completaR = '';
	var total = '';
	
	if (flagReferencia == 'D'){
		var tipoVia =getValue(pos_usc + 'ddlPrefijo');
		var nombreVia =getValue(pos_usc + 'txtDireccion');
		var nroPuerta = getValue(pos_usc + 'txtNroPuerta');
		var tipoEdificacion = getValue(pos_usc + 'ddlEdificacion');
		var nroEdificacion = getValue(pos_usc + 'txtManzana');
		var lote = getValue(pos_usc + 'txtLote');
		var tipoInterior =getValue(pos_usc + 'ddlTipoInterior');
		var nroInterior = getValue(pos_usc + 'txtNroInterior');
		if (tipoVia != '-1') completaD = 'XX';
		if (nombreVia != '') completaD += ' ' + nombreVia;
		if (nroPuerta != '') completaD += ' ' + nroPuerta;
		if (tipoEdificacion != '-1') completaD += ' ' + tipoEdificacion;
		if (nroEdificacion != '') completaD += ' ' + nroEdificacion;
		if (lote != '') completaD += ' LT ' + lote;
		if (tipoInterior != '-1') completaD += ' ' + tipoInterior;
		if (nroInterior != '') completaD += ' ' + nroInterior;
		
		total = '';
		if (completaD != '') total = completaD.length;
		setValueHTML(pos_usc + 'lblContadorDireccion',total);		
	}else if (flagReferencia == 'R'){//Para la Referencia
		var tipoUrbanizacion =  getValue(pos_usc + 'ddlUrbanizacion');
		var nombreUrbanizacion = getValue(pos_usc + 'txtUrbanizacion');
		var tipoZona = getValue(pos_usc + 'ddlZona');
		var nombreZona = getValue(pos_usc + 'txtNombreZona');
		var referencia = getValue(pos_usc + 'txtReferencia');
		if (tipoUrbanizacion != '-1') completaR += ' ' + tipoUrbanizacion;
		if (nombreUrbanizacion != '') completaR += ' ' + nombreUrbanizacion;
		if (tipoZona != '-1') completaR += ' ' + tipoZona;
		if (nombreZona != '') completaR += ' ' + nombreZona;
		if (referencia != '') completaR += ' ' + referencia;
		total = '';
		if (completaR != '') total = trim(completaR).length;					
		setValueHTML(pos_usc + 'lblContadorReferencia',total);			
	}
	if (total == '') total = 0;
	return total;
}


function eliminaCaracteresInvalidos(cadena){
	var invalidos = "\/°~#+!$%=?¿¡|;*\'\\\""
	var c = "";
	for(var i=0;i<invalidos.length;i++){
		c = invalidos.substr(i,1);
		cadena = cadena.replace(c,"");	
	}				
	return cadena;
}		
function eliminaCaracteresNroPuerta(cadena){
	var invalidos = "°~#+!$%=?¿¡|;*\'\\\""
	var c = '';
	for(var i=0;i<invalidos.length;i++){
		c = invalidos.substr(i,1);
		cadena = cadena.replace(c,"");	
	}
	cadena = cadena.replace('\/\/',"/");	
	return cadena;
}

function validarDireccion(valida_ctrl,flagValidarFactura,flagValidarTelRef){
	var pos_usc= valida_ctrl;	
	
	var nroPuerta = '';
	var flagSinNumero = false;
	var tipoEdificacion = '';
	var lote = '';
	if (flagValidarFactura == true){
		if(getValue(pos_usc + 'ddlPrefijo')=='-1'){
			alert('El Prefijo de la Dirección es un dato requerido');
			setFocus('ddlPrefijo');
			return false;
		}
		if( (getValue(pos_usc + 'ddlPrefijo') != '99') && (getValue(pos_usc + 'txtDireccion')=='')){
			alert('El nombre de la via en la Dirección es un dato requerido');
			setFocus(pos_usc + 'txtDireccion');				
			return false;
		}
		nroPuerta = getValue(pos_usc + 'txtNroPuerta');
		flagSinNumero = document.getElementById(pos_usc + 'chkSinNumero').checked;
		if (nroPuerta == '' && flagSinNumero == false){
			if (getValue(pos_usc + 'ddlEdificacion') == '-1'){
				alert('El Nro de la Via o El Tipo de Edificación en la Dirección es un dato requerido');
				setFocus(pos_usc + 'txtNroPuerta');					
				return false;
			}						
			if ( getValue(pos_usc + 'txtManzana') == ''){
				alert('El Nro/Mz/Bloq en la Dirección es un dato requerido');
				setFocus(pos_usc + 'txtManzana');
				return false;
			}						
			lote = getValue(pos_usc + 'txtLote') ;
			if ( getValue(pos_usc + 'ddlEdificacion') == 'MZ' && lote == '' ){
				alert('El Lote en la Dirección es un dato requerido');
				setFocus(pos_usc + 'txtLote');
				return false;
			}
		}

		if (getValue(pos_usc + 'ddlTipoInterior') != '-1' && getValue(pos_usc + 'txtNroInterior') == ''){
			alert('El Nro en el Tipo Interior de la Dirección es un dato requerido');
			setFocus(pos_usc + 'txtNroInterior');
			return false;
		}			
		if (getValue(pos_usc + 'ddlUrbanizacion') != '-1' && getValue(pos_usc + 'txtUrbanizacion') == ''){
			alert('El Nombre de Denominación Urbana en la Dirección es un dato requerido');
			setFocus(pos_usc + 'txtUrbanizacion');
			return false;
		}
		
		if (getValue(pos_usc + 'ddlZona') != '-1' && getValue(pos_usc + 'txtNombreZona') == ''){
			alert('El Nombre de la Zona en la Dirección es un dato requerido');
			setFocus(pos_usc + 'txtNombreZona');
			return false;
		}					
		if(getValue(pos_usc + 'ddlDepartamento')==''){
			alert('El Departamento de la Dirección es un dato requerido');
			setFocus(pos_usc + 'ddlDepartamento');
			return false;
		}
		if(getValue(pos_usc + 'ddlProvincia')==''){
			alert('La Provincia es de la Dirección un dato requerido');
			setFocus(pos_usc + 'ddlProvincia');
			return false;
		}
		if(getValue(pos_usc + 'ddlDistrito')==''){
			alert('El Distrito de la Dirección es un dato requerido');
			setFocus(pos_usc + 'ddlDistrito');
			return false;
		}
		if (flagValidarTelRef == true){			
			if(getValue(pos_usc + 'txtTelefonoReferencia')==''){
				alert('El teléfono de referencia es un dato requerido');
				setFocus(pos_usc + 'txtTelefonoReferencia');
				return false;
			}
		}
	}
			
	return true;
}	

function f_Prueba(control)
	{
		alert('hola');	
	} 
 
