function setValue(id,v){
	var c = document.getElementById(id);
	if (c != null ) c.value = v;
}

function getValue(id){
	var c = document.getElementById(id);
	if (c != null ) return Trim(c.value);
	return '';
}
function getValueHTML(id){
	var c = document.getElementById(id);
	if (c != null ) return Trim(c.innerHTML);
	return '';
}
function getText(id){
	var c = document.getElementById(id);
	if (c != null )return c.options[c.selectedIndex].text;
	return '';
}
function setValueHTML(id,v){
	var c = document.getElementById(id);	
	if (c != null ) 
	try{
		c.innerHTML = v;
	}catch(ex){}
}
function setValueInnerText(id,v){
	var c = document.getElementById(id);	
	if (c != null ) c.innerText = v;	
}
function setFocus(id){
	var c = document.getElementById(id);
	if (c != null )
		if (c.disabled == false && isVisible(id)==true )
			c.focus();
}
function setFocusSelect(id){
	var c = document.getElementById(id);
	if (c != null )
		if (c.disabled == false && isVisible(id)==true ){
			c.select();
			c.focus();
		}
}
function isVisible(id){
	var c = document.getElementById(id);
	if (c == null ) return false;		
	if (c.style.display == '')
		return true; 
	else
		return false;
}
function isEnabled(id){
	var c = document.getElementById(id);
	if (c==null) return false;
	if (c.disabled == true)
		return false
	else
		return true
}
function setEnabled(id,habilitar,classname){
	var c = document.getElementById(id);
	if (c==null) return;
	if (c.type == 'text')
		if (habilitar == true) 
			c.readOnly = false;
		else
			c.readOnly = true;
	else
		if (habilitar == true)
			c.disabled =  false;
		else
			c.disabled = true;	
	if (classname != '') c.className = classname;
}

function setReadOnly(id,soloLectura,classname){
	var c = document.getElementById(id);
	if (c==null) return;
	c.readOnly = soloLectura;
	if (classname != '') c.className = classname;
}

function setVisible(id,visible){
	var c = document.getElementById(id);
	if (c == null ) return;	
	if (visible == true)	
		c.style.display = '';
	else
		c.style.display = 'none';
	
}

function abrirVentana(url,opciones,w,h,nombre,focus){
	var v;
	if( w =='') w = 0;
	if( h =='') h = 0;
	var	leftScreen =(screen.width - w) / 2;
	var topScreen = (screen.height - h) / 2;
	
	if(opciones =='')
		opciones = 'directories=no,menubar=no,scrollbars=yes,status=yes,resizable=yes,width=' +w +',height='+ h +',left='+leftScreen +',top=' + topScreen;
		
	if(focus == true){
		v = window.open(url,nombre,opciones);
		v.focus();
	}else{
		window.open(url,nombre,opciones);
	}				
}

function eventoSoloNumeros(){
	// NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57		
	var key = event.keyCode;	
	if ((key <= 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key == 33) || (key == 34) || (key == 35) || (key == 36)|| (key == 37) || (key == 38) || (key == 39) || (key == 40)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
		event.returnValue = true;
	else
		event.returnValue = false;	
}

function eventoSoloNumeros2(){
	// NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57		
	var key = event.keyCode;	
		if ((key <= 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key == 33) || (key == 34) || (key == 35) || (key == 36)|| (key == 37) || (key == 38) || (key == 39) || (key == 40)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
		event.returnValue = true;		
	else
		event.returnValue = false;	
}

function onchangeBuscarPor(control,txt){
	var por = control.value;
	if (por == '1' || por == '2'){// RUC Y FONO (SOLO NUMEROS)
		document.getElementById('hidFlagSoloNumero').value = 'S';
	}else{
		document.getElementById('hidFlagSoloNumero').value = 'N';
	}
	setValue(txt,'');
	setFocus(txt);	
}
function f_ValidarEnter()
{	
	if (document.all)
	{
		if (event.keyCode == 13)
		{	
			buscarEmpresa();	
			event.keyCode = 0;
		}
	}
}
function validaEnterCriterio(control){				
	if (document.all){
		if (event.keyCode == 13){
			if (trim(control.value)!=''){	
				buscarEmpresa();
				event.keyCode = 0;
				return;
			}
		}
	}				
	var soloNumero = document.getElementById('hidFlagSoloNumero').value;
	if (soloNumero=='S'){
		eventoSoloNumeros();
		return;
	}				
}
function txtNumDoc_onkeydown(control,flag_solo_nro,siguiente){				
	if (document.all){
		if (event.keyCode == 13){
			if (trim(control.value)!=''){
				setFocus(siguiente);
				event.keyCode = 0;
				return;
			}
		}
	}				
	var soloNumero = getValue(flag_solo_nro);
	if (soloNumero=='S'){
		eventoSoloNumeros();
		return;
	}
}
function textCounter(obj,cbo_id) {
		var maximo;
		var nro = parseInt(getValue(cbo_id));
		switch (nro){
			case 1 : 
				maximo = 8;
				break;
			case 2 : 
				maximo = 10;
				break;
			case 3 : 
				maximo = 7;
				break;
			case 6 : 
				maximo = 11;
				break;
			default : 
				maximo = 15;
				break;
	}
	if (obj.value.length > maximo) // if too long...trim it!
		obj.value = obj.value.substring(0, maximo); // otherwise, update 'characters left' counter
}
function cambiarLink(link_ocultar,link_mostrar,flag_contenido,contenido){
	setVisible(link_mostrar,true);
	setVisible(link_ocultar,false);
	if (flag_contenido == '1')
		setVisible(contenido,true);
	else
		setVisible(contenido,false);
	//document.getElementById(link_mostrar).className='link_activo';
	//document.getElementById(link_ocultar).className='link_activo';
}
function deshabilitarPaso(opcion){
	document.getElementById(opcion).className = 'evento_inactivo';
}
function cambiarEstilo(control,nuevo_estilo){
	document.getElementById(control).className = nuevo_estilo;
}
function habilitarPaso(opcion){
	document.getElementById(opcion).className = 'eventos';
}
function mostrarEvento(evento,valor){
	try{
		document.getElementById('lbl'+evento).innerHTML = valor;
		document.getElementById('tr'+evento).style.display = '';
		document.getElementById('td'+evento).style.display = ''
	}catch(ex){}
}
function f_UbicarFoco(valor){
	document.getElementById('btnGrabar').style.display = ''
	var id;
	if (valor== 'D') 
		id = 'txtTelefono';
	else if (valor== 'T') 
		id = 'txtTelFijoTrabajo';
	else if (valor== 'R1') 
		id = 'txtTelefonoReferencia1';
	else if (valor== 'R2') 
		id = 'txtTelefonoReferencia2';
		 
	var control = document.getElementById(id);
	if (control == null){
		return;
	}
	if (control.disabled==true){
		control.disbaled=false;
		control.focus();
	}
}


function textBuscarPor(obj,cbo_id) {
		var maximo;
		var nro = parseInt(getValue(cbo_id)); 		
		switch (nro){
			case 1 : 
				maximo = 8;
				break;
			case 2 : 
				maximo = 12;
				break;
			case 3 : 
				maximo = 40;
				break;			
			default : 
				maximo = 40;
				break;
	}
	if (obj.value.length > maximo) // if too long...trim it!
		obj.value = obj.value.substring(0, maximo); // otherwise, update 'characters left' counter
}
function suma(a,b){
	return a + b;
}
function Mid(str, start, len){
	if (start < 0 || len < 0) return "";
	var iEnd, iLen = String(str).length;
	if (start + len > iLen)
		iEnd = iLen;
	else
		iEnd = start + len;
	return String(str).substring(start,iEnd);
}
/*
function Mid(cadena,inicio,longitud){
	var fin,total;
	if ( parseInt(inicio) < 0 || parseInt(longitud) < 0) return '';
	total = String(cadena).length;
	fin = parseInt(inicio) + parseInt(longitud);
	if (parseInt(inicio) + parseInt(longitud)>total) fin = total;
	return String(cadena).substring(inicio,fin);
}
*/
function ascii_value(c){
	c = c.charAt(0);
	var i;
	for (i=0;i<255;i++){
		var h = i.toString(16);
		if (h.length == 1) h = "0" + h;
		// insert a % character into the string
		h = "%" + h;
		// determine the character represented by the escape code
		h = unescape(h);
		// if the characters match, we've found the ASCII value
		if (h == c) break;
	}
	return i;
}
function e_validacaracter(valorcaracter){
	var sRetorna=valorcaracter;
	if ((valorcaracter==34)|| (valorcaracter==39) || (valorcaracter==124) || (valorcaracter==59) || (valorcaracter==13)){
	sRetorna=0;
	}
	else
	{
	if ((valorcaracter>96&&valorcaracter<123)||(valorcaracter==241)||(valorcaracter==250)||(valorcaracter==243)||(valorcaracter==237)||(valorcaracter==233)||(valorcaracter==225))
	sRetorna=valorcaracter-32;
	}
	return sRetorna;
}
function e_mayuscula_car(){
	event.keyCode=e_validacaracter(event.keyCode);
}
function f_ValidaTextArea(obj, longitud){
	var i;
	if (obj.value.length > longitud){
		alert("Debe ingresar un texto menor o igual a " + longitud + " caracteres.");
		obj.focus();
		return false;
	}else{
		for (i=0; i<=obj.value.length; i=i+1){
			if (e_validacaracter(ascii_value(Mid(obj.value, i, 1))) == 0){
				if (ascii_value(Mid(obj.value, i, 1)) == 13){
					alert("Se han ingresado caracteres inv?lidos: {ENTER} ")
				}else{
					alert("Se han ingresado caracteres inv?lidos: ' " + Mid(obj.value, i, 1) + " '")
				}
				obj.focus()
				return false
			}
		}
		return true;
	}
}
function e_direccion(){
	if ((event.keyCode==34) || (event.keyCode==39) || (event.keyCode==124)){
		event.keyCode=0;
	}else{
		if ((event.keyCode>96&&event.keyCode<123)||(event.keyCode==241)||(event.keyCode==250)||(event.keyCode==243)||(event.keyCode==237)||(event.keyCode==233)||(event.keyCode==225))
		{	
			event.keyCode=event.keyCode-32;
		}
	}
}
function quitarCerosDecimal(monto){
	if (monto.indexOf('.') == -1) return monto;
	var aMonto = monto.split('.');
	if (parseInt(aMonto[1]) == 0) 
		return aMonto[0];
	else
		return monto;
	
}
function LTrim(String)
{
	var i = 0;
	var j = String.length - 1;

	if (String == null)
		return (false);

	for (i = 0; i < String.length; i++)
	{
		if (String.substr(i, 1) != ' ' &&
		    String.substr(i, 1) != '\t')
			break;
	}

	if (i <= j)
		return (String.substr(i, (j+1)-i));
	else
		return ('');
}

/**************************************************************
 RTrim: Returns a String containing a copy of a specified 
        string without trailing spaces 

 Parameters:
      String = The required string argument is any valid 
               string expression. If string contains null, 
               false is returned

 Returns: String
***************************************************************/
function RTrim(String)
{
	var i = 0;
	var j = String.length - 1;

	if (String == null)
		return (false);

	for(j = String.length - 1; j >= 0; j--)
	{
		if (String.substr(j, 1) != ' ' &&
			String.substr(j, 1) != '\t')
		break;
	}

	if (i <= j)
		return (String.substr(i, (j+1)-i));
	else
		return ('');
}

/**************************************************************
 RTrim: Returns a String containing a copy of a specified 
        string without both leading and trailing spaces 

 Parameters:
      String = The required string argument is any valid 
               string expression. If string contains null, 
               false is returned

 Returns: String
***************************************************************/
function Trim(String)
{
	if (String == null)
		return (false);

	return RTrim(LTrim(String));
}
function isNumberChar (InString)  {
 if(InString.length!=1)
  return (false);
 RefString="1234567890";
 if (RefString.indexOf (InString, 0)==-1)
  return (false);
 return (true);
} 
function isNumOrChar (InString)  {
 if(InString.length!=1)
  return (false);
 InString=InString.toLowerCase();
 RefString="1234567890abcdefghijklmnopqrstuvwxyz";
 if (RefString.indexOf (InString, 0)==-1) 
  return (false);
 return (true);
}
function isAlphabeticChar (InString)  {
 if(InString.length!=1)
  return (false);
 InString=InString.toLowerCase();
 RefString="abcdefghijklmnopqrstuvwxyz";
 if (RefString.indexOf (InString.toLowerCase(), 0)==-1)
  return (false);
 return (true);
}
function mask (InString, Mask)  {
	LenStr = InString.length;
	LenMsk = Mask.length;
	if ((LenStr==0) || (LenMsk==0))	
		return 0;
	if (LenStr!=LenMsk)
		return 0;
	TempString = ""
	for (Count=0; Count<=InString.length; Count++)  {
		StrChar = InString.substring(Count, Count+1);
		MskChar = Mask.substring(Count, Count+1);
		if (MskChar=='#') {
			if(!isNumberChar(StrChar))
				return 0;
		}
		else if (MskChar=='?') {
			if(!isAlphabeticChar(StrChar))
				return 0;
		}
		else if (MskChar=='!') {
			if(!isNumOrChar(StrChar))
				return 0;
		}
		else if (MskChar=='*') {
		}
		else {
			if (MskChar!=StrChar)
				return 0;
		}
	}
 return  1;
}
function isNumber(pString){
	
	var ok = "yes";	var temp;
    var valid = "0123456789"; 
	for (var i=0; i< pString.length ; i++){
		temp = "" + pString.substring(i, i+1);
		if (valid.indexOf(temp) == "-1") ok = "no";
	}
	if (ok == "no") {return (false);} else {return (true);}
	
}

function isChar(pString){
	var ok = "yes";	var temp;
        var valid = "abcdefghijklmn?opqrstuvwxyzABCDEFGHIJKLMN?OPQRSTUVWXYZ";
	for (var i=0; i< pString.length ; i++) 	{
                temp = "" + pString.substring(i, i+1);
		if (valid.indexOf(temp) == "-1") ok = "no";
	}
	if (ok == "no") {return (false);} else {return (true);}
}

function validateDateMask(strDate) {
    if (mask(strDate,'##/##/####')!=1)
        return false;    
    else 
		return true;
}
function validarFecha(oControl) { 
    var Day, Month, Year;
    var Fecha=document.getElementById(oControl);
    //var Fecha = xname.value;
	var valor=Fecha.value;
	var controlValida;
	controlValida=Fecha.id;
	
	if ( validateDateMask(valor)==false ){
		alert('Fecha no valida. Debe ingresar el formato (DD/MM/AAAA)');
		return false;
	}
	
    Day = getValueSeparator(valor,1,"/");
    Month = getValueSeparator(valor,2,"/");
    Year = getValueSeparator(valor,3,"/");

    if ((isNumber(Day) && isNumber(Month) && isNumber(Year) && (Year.length==4)&& (Day.length<=2) && (Month.length<=2)) ||((Month==2) && (Day<=29)))    {
        if ((Day!=0)&&(Month!=0)&&(Year!=0)&&(Month<=12)&&(Day<=31)&&(Month!=2)){
			
			if ( Month==4 || Month==6 || Month==9 || Month==11  ){
				if (Day>30 ){					
					alert('Fecha no valida. Debe ingresar el formato (DD/MM/AAAA)');
					return false;
				}			
			}else if ( Month==1 || Month==3 || Month==5 || Month==7 || Month==8 || Month==10 || Month==12 ){
				if (Day>31 ){					
					alert('Fecha no valida. Debe ingresar el formato (DD/MM/AAAA)');
					return false;
				}		
			}		
            return true;
         }
        else if((Month==2)&&(Day<=29)&&((Year%4)==0)&&((Year % 100)!=0))
            return true;
        else if((Month==2)&&(Day<=29)&&((Year%400)==0))
            return true;
        else if((Month==2)&&(Day<=28))
            return true;
        else    {
            if(Month > 12) {				
                alert('El campo de mes debe como maximo 12.');
            }
            else if(Year.length!=4) {				
                alert("El a?o debe tener 4 cifras.");
            }
            else if((Month==2)&&(Day==29)&&((Year%4)==0)&&(Year%100)==0) {				
                alert('A?o no bisiesto.');
            }
            else{
                alert('Fecha no valida');
            }    
            if(Fecha.disabled==false)        
				Fecha.focus();
				
            Fecha.select();
            return false;
        }
    }
    else    {
		alert('Fecha no valida. Debe ingresar el formato (DD/MM/AAAA)');	
        return false;
    }
}
function compararFecha(fechainicio,fechafin,flagIgual){ 
	comp1 	= fechainicio.substr(6,4) + '' + fechainicio.substr(3,2) + '' + fechainicio.substr(0,2);
	comp2 	= fechafin.substr(6,4) + '' + fechafin.substr(3,2) + '' + fechafin.substr(0,2);
	if (flagIgual=='0')
	{		
		if 	((comp1) > (comp2)){
			return false;
		}
	}
	if (flagIgual=='1'){
		if 	((comp1) >= (comp2)){
			return false;
		}
	}
	return true;
}
function getValueSeparator(strData, intFieldNumber, separator)   { 
    var intCurrentField, intFoundPos, strValue, strNames;
    var bool = false;
    strNames = strData;
    intCurrentField = 0;
    while( (intCurrentField != intFieldNumber)&& !bool )    {
        intFoundPos = strNames.indexOf(separator);
        intCurrentField = intCurrentField + 1;
        if (intFoundPos != 0)   { 
            strValue = strNames.substring(0,intFoundPos);
            strNames = strNames.substring(intFoundPos + 1, strNames.length);
        }
        else    { 
            if(intCurrentField == intFieldNumber)
                strValue = strNames;
            else
                strValue = ""; 
            bool = true;
        }
    }
    if(strValue!="")
        return strValue;
    else
        return strNames;
}
function soloMontos(event, obj){
	var code = (event.which) ? event.which : event.keyCode;
	var character = String.fromCharCode(code);
	var decimales = 0;
	var cantidad_decimales = 2;
	var salida = false;	
	if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105)){ // check digits
		if (obj.value == "0") return false;
		if (!isNaN(obj.value)){
			if (obj.value == "0.0" && code == 48){
				return false;
			}
		}
		if (obj.value.indexOf('.')>=0){
			decimales = obj.value.substring(obj.value.indexOf('.')+1, obj.value.length);	
			if (decimales.length >= cantidad_decimales){  
				//alert('decimales = ' + obj.value);
				return false;
			}
		}
		return true;
	}else if (code == 46 || code == 110){ // Check dot
		if (obj.value.indexOf(".") < 0){						
			if (obj.value.length == 0) obj.value = "0";				
			return true;
		}
	}else if (code == 8 || code == 116){ // Allow backspace, F5
		return true;
	}else if (code >=37 && code <= 40){ // Allow directional arrows
		return true;
	}else if (code ==9 || code == 16){ // tab control + tab
		return true;
	}
	return false;
}

function soloMontosIngreso(event, obj){
	var code = (event.which) ? event.which : event.keyCode;
	var character = String.fromCharCode(code);
	var decimales = 0;
	var cantidad_decimales = 2;
	var salida = false;	
	if ((code >= 48 && code <= 57) ){ // check digits
		if (obj.value == "0") return false;
		if (!isNaN(obj.value)){
			if (obj.value == "0.0" && code == 48){
				return false;
			}
		}
		if (obj.value.indexOf('.')>=0){
			decimales = obj.value.substring(obj.value.indexOf('.')+1, obj.value.length);	
			if (decimales.length >= cantidad_decimales){  
				//alert('decimales = ' + obj.value);
				return false;
			}
		}
		return true;
	}else if (code == 46){ // Check dot
		if (obj.value.indexOf(".") < 0){						
			if (obj.value.length == 0) obj.value = "0";				
			return true;
		}
	}else if (code == 8){ // Allow backspace, F5
		return true;
	}else if (code >=37 && code <= 40){ // Allow directional arrows
		return true;
	}else if (code ==9 || code == 16){ // tab control + tab
		return true;
	}
	return false;
}

function soloNumeros(event){
	// NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57		
	var key = (event.which) ? event.which : event.keyCode;	
	if ((key <= 13 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || (key >=33 && key <= 40)|| (key == 45) || (key == 46) || (key == 86) || (key == 67)|| (key == 88))==true)
		return true;
	else
		return false;	
}
function checknumb(entero, decima, limite , objtname){		
	var snumero = eval("document.all['"+objtname+"'].value");
	if (isNaN(snumero)){	
		alert("Debe ingresar un numero");
		eval("document.all['"+objtname+"'].focus();");
		eval("document.all['"+objtname+"'].select();");
		return false;
	}else{
		if (Trim(snumero)!=""){
			var npnumero = parseFloat(snumero);
			var spnumero = npnumero.toString();
			var sindicepunto = spnumero.indexOf(".");
				
			var strentero ="" , strdecimal= "" 
				
			if (sindicepunto!=-1){
				strentero = spnumero.substring( 0, sindicepunto);
				strdecimal = spnumero.substring( sindicepunto+1,spnumero.length);
			}else{
				strentero = spnumero
			}
			if (strentero.length > entero ){
				alert("Debe ingresar como m\u00E1ximo "+entero+" enteros");
				eval("document.all['"+objtname+"'].focus();");
				eval("document.all['"+objtname+"'].select();");
				return false;
			}
			if (strdecimal.length > decima ) {
				alert("Debe ingresar como m\u00E1ximo "+decima+" decimales");
				eval("document.all['"+objtname+"'].focus();");
				eval("document.all['"+objtname+"'].select();");
				return false;
			}
			if (( npnumero > limite )&&( limite != -1 )) {
				alert("Debe ingresar un valor menor o igual a " + limite );
				eval("document.all['"+objtname+"'].focus();");
				eval("document.all['"+objtname+"'].select();");
				return false;
			}						
			eval("document.all['"+objtname+"'].value="+spnumero);
		}
	}
	return true;
}
function siguienteControl(event,tipo,current,next){
	if (document.all){
		if (event.keyCode == 13){
			setFocusSelect(next),
			event.keyCode = 0;
			return false;
		}
		if (tipo == 1)
			return eventoSoloNumeros();
		if (tipo == 2){
			var s = soloMontos(event,current);
			return s;
		}
	}
}

function validarUrl()
{  
      var user_agent=navigator.userAgent;
//      if (user_agent.indexOf("MSIE 8.0") != -1 || user_agent.indexOf("Firefox") != -1) {
      if (user_agent.indexOf("Firefox") != -1) {
            alert ('Version incorrecta de Internet Browser');
            window.location.href('http://eclaro/default.aspx');
            return false;

      }
      document.onkeydown = function()
      {
            if (window.event && (window.event.keyCode == 122))
            {
                  window.event.keyCode = 505;  
            }

            if (window.event.keyCode == 505)
            {
                  return false;  
            }

            var controlPressed=0;
            controlPressed=event.ctrlKey;

            if (controlPressed)
            {
                  if (window.event.keyCode == 65 || window.event.keyCode == 76)
                  {
                        return false;  
                  }
            }
      }

      if (parseInt(navigator.appVersion)>3)
      {
            document.onmousedown = mouseDown;
      }

      if (document.layers)
      {
            document.captureEvents(Event.MOUSEDOWN);
      }
      else
      {
            document.oncontextmenu=clickIE;
      }

	  document.oncontextmenu=new Function("return false")

      if (window.parent.frames[0]==null)
      {
            if (window.opener && window.opener.closed)
            {
                  window.location.href('http://intranetsisact/sisact');
                  return false;
            }
            else
            {
                  if (window.opener == null)
                  {
                        window.location.href('http://intranetsisact/sisact');
                        return false;
                  }
            }
      }
      else
      {
            if (window.parent.document.location.toString() == window.document.location.toString())
            {
                  window.location.href('http://intranetsisact/sisact');
                  return false;
            }
      }
      return true;
}

function restringirEventos()
{  
	var user_agent=navigator.userAgent;
	//      if (user_agent.indexOf("MSIE 8.0") != -1 || user_agent.indexOf("Firefox") != -1) {
	if (user_agent.indexOf("Firefox") != -1) {
		alert ('Version incorrecta de Internet Browser');
		window.location.href('http://eclaro/default.aspx');
		return false;

	}
	document.onkeydown = function()
	{
		if (window.event && (window.event.keyCode == 122))
		{
				window.event.keyCode = 505;  
		}

		if (window.event.keyCode == 505)
		{
				return false;  
		}

		var controlPressed=0;
		controlPressed=event.ctrlKey;

		if (controlPressed)
		{
				if (window.event.keyCode == 65 || window.event.keyCode == 76)
				{
					return false;  
				}
		}
	}

	if (parseInt(navigator.appVersion)>3)
	{
		document.onmousedown = mouseDown;
	}

	if (document.layers)
	{
		document.captureEvents(Event.MOUSEDOWN);
	}
	else
	{
		document.oncontextmenu=clickIE;
	}

	document.oncontextmenu=new Function("return false")
	return true;
}

function mouseDown(e)
{
	var shiftPressed=0;
	if (parseInt(navigator.appVersion)>3)
	{
		shiftPressed=event.shiftKey;
		if (shiftPressed)
		{
			alert ('Accion invalida');
			return false;
		}
	}
	return true;
}

var message="";

function clickIE()
{
	if (document.all)
	{
		(message);
		return false;
	}
}

//INICIO - E75688						
		function HabilitarEmail(control, txtCorreo, txtCorreoConf){
			if(control.checked == true){  
				setEnabled(txtCorreo,true,'')
				setEnabled(txtCorreoConf,true,'')
				document.getElementById(txtCorreo).className = 'clsInputEnable'
				document.getElementById(txtCorreoConf).className = 'clsInputEnable'				
				setFocus(txtCorreo);
			}
			else{
				setValue(txtCorreo,'')
				setValue(txtCorreoConf,'')
			
				setEnabled(txtCorreo,false,'')
				setEnabled(txtCorreoConf,false,'')
				document.getElementById(txtCorreo).className = 'clsInputDisable'
				document.getElementById(txtCorreoConf).className = 'clsInputDisable'
			}
		}		
		
		function ValidarEmail(chk_Correo,txtCorreo, txtCorreoConf){
			var correo = getValue(txtCorreo);
			var ConfCorreo = getValue(txtCorreoConf);
			if(document.getElementById(chk_Correo).checked == true){
			    if(correo != ''){		
					if(!ValidarEMailAfi(txtCorreo,'Correo Electronico')){				
						return false;
					}
					if(ConfCorreo != ''){
						if(correo == ConfCorreo){
						   return true;					
					}					
					else{ 
							alert('No coinciden los correos ingresados.');
							setFocus(txtCorreo);
							return false;
						}
					}
					else{
					  alert('Confirme el Correo Electronico.');
					  setFocus(txtCorreoConf);    
					  return false;
					}			    					
			    }
			    else{
					  alert('Debe ingresar un Correo Electronico.');
					  setFocus(txtCorreo);    
					  return false;
				}				
			}
			else{ return true;}
		}	
		
		function validarCaracteresEmail() {
			var CaracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_.@";
			var key = String.fromCharCode(window.event.keyCode)
			var valid = new String(CaracteresPermitidos)
			var ok = "no";						
			
			for (var i=0; i<valid.length; i++) 
			{
				if (key == valid.substring(i,i+1))
					ok = "yes"        
			}
			if (ok == "no")
					window.event.keyCode=0								
					
			if ((key > 0x60) && (key < 0x7B))
				window.event.keyCode = key-0x20;				
		}								
		
		function ValidarEMailAfi(id, nmb)
		{
			var sValor = getValue(id); 
			if (sValor.length != 0) 
			{     
					var esValido = (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(sValor));
					if (!esValido) 
					{
						setFocus(id);
						alert(nmb + ' no tiene el formato correcto.');               
						return false;
					}     
					else
						return true;
			}
			else
					return false;                 
		}		
//FIN
	function eventoSoloNumerosEnteros(){
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

	function f_RedondeoRentaDTH(valor){
		if(valor>0){
			var valorEntero = 0;
			var resto = 0;
			var agregar = 0;
			valorEntero = parseInt(valor,10);				
			resto =  valorEntero%5;
			if(resto > 0){
				agregar = 5 - resto;				
			}			
			return valorEntero + agregar;
		}else{
			return 0;
		}				
	}
	
	function esFechaValida(fecha)
	{
		if (fecha != "" )
		{
			if (!/^\d{2}\/\d{2}\/\d{4}$/.test(fecha))
				return false;

			var dia  =  parseInt(fecha.substring(0,2),10);
			var mes  =  parseInt(fecha.substring(3,5),10);
			var anio =  parseInt(fecha.substring(6),10);

			switch(mes)
			{
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					numDias = 31;
					break;
				case 4: case 6: case 9: case 11:
					numDias = 30;
					break;
				case 2:
					if (comprobarSiBisisesto(anio)){ numDias = 29 } else { numDias = 28};
					break;
				default:
					return false;
			}

			if (dia > numDias || dia == 0)
				return false;

			return true;
		}
		else
			return false;
	}
	
	function comprobarSiBisisesto(anio) {
		if ((anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0)))
			return true;
		else
			return false;
	}

	function calculaEdad(txtFecha, txtFecha1)
	{
		var fecha1 = new fecha( txtFecha1 );
		var fecha2 = new fecha( txtFecha );
		var edad = parseInt((fecha1.anio - fecha2.anio), 10);

		return edad;
	}
	
	function esMayorEdad(txtFecha, txtFecha1)
	{
		var fecha1 = new fecha( txtFecha1 );
		var fecha2 = new fecha( txtFecha );
		var edad = parseInt((fecha1.anio - fecha2.anio), 10);

		if (edad < 18)
			return false;
		else {
			if ((edad == 18) && (parseInt(fecha2.mes, 10) > parseInt(fecha1.mes, 10)))
				return false;
			else {
				if (edad == 18 && parseInt(fecha2.mes, 10) == parseInt(fecha1.mes, 10) && parseInt(fecha2.dia, 10) > parseInt(fecha1.dia, 10))
					return false;
			}
		}
		return true;
	}
	
	function fecha(cadena)
	{
		var separador = "/";
		if ( cadena.indexOf( separador ) != -1 )
		{
			var posi1 = 0;
			var posi2 = cadena.indexOf( separador, posi1 + 1 );
			var posi3 = cadena.indexOf( separador, posi2 + 1 );
			this.dia = cadena.substring( posi1, posi2 );
			this.mes = cadena.substring( posi2 + 1, posi3 );
			this.anio = cadena.substring( posi3 + 1, cadena.length );
		} else {
			this.dia = 0;
			this.mes = 0;
			this.anio = 0;
		}
	}
	
	function validaTextAreaLongitud(obj, longitud, m)
	{
		if (obj.value.length > longitud)
		{
			if (m == true)
				alert("Debe ingresar un texto menor o igual a " + longitud + " caracteres.");

			var c = obj.value;
			obj.value = c.substr(0, longitud);
			obj.focus();					
			return false;
		} else {
			for (var i=0; i<=obj.value.length; i=i+1) {
				if (e_validacaracter(ascii_value(Mid(obj.value, i, 1))) == 0) {
					if (ascii_value(Mid(obj.value, i, 1)) == 13) {
						alert("Se han ingresado caracateres inv?lidos: {ENTER} ");
					} else {
						alert("Se han ingresado caracateres inv?lidos: ' " + Mid(obj.value, i, 1) + " '")
					}
					obj.focus();
					return false;
				}
			}
			return true;
		}
	}	
	
	function CerrarVentanaDialog()
	{
		window.returnValue = '';
		window.close();
	}	
	
	function inicializarCombo(ddl)
	{
		var option;
		ddl.length = 0;
		option = document.createElement('option');
		option.value = '';
		option.text = 'SELECCIONE...';
		ddl.add(option);
	}
	
	function cargarCombo(ddl, value, txt)
	{
		var option;
		option = document.createElement('option');
		option.value = value;
		option.text = txt;
		ddl.add(option);
	}
	
	function validaCaracteresNombres()
	{
		var blnOK = validaCaracteres('ABCDEFGHIJKLMN?OPQRSTUVWXYZabcdefghijklmn?opqrstuvwxyz0123456789 ');
		return blnOK;
	}

	function habilitarBoton(ctrl, value, flg)
	{
		setValue(ctrl, value);
		if (!flg)
			setEnabled(ctrl, false, '');
		else
			setEnabled(ctrl, true, 'BotonOptm');
	}
	
	function addOption(selectbox, value, text) {
		var optn = document.createElement("OPTION");
		optn.value = value;
		optn.text = text;
		selectbox.options.add(optn);
	}
	
function ValidaCampo (control, mensaje) {
	var cadena;
	var flag = true;
	eval("cadena = " + control + ".value");
	cadena = trim(cadena);
	if ( cadena == '00' || cadena == ''){
		eval("" + control + ".focus()");
		alert(mensaje);
		flag = false;
	}
	return flag;
}	
function validarNumero(event) {
	if (event.keyCode == 8 || event.keyCode == 46) {
		return;
	}
	if (event.keyCode >= 37 && event.keyCode <= 40) {
		return;
	}
	eventoSoloNumeros(event);
}	
function validarAlfaNumerico(event) {
	if (event.keyCode == 8 || event.keyCode == 46) {
		return;
	}
	if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
		return;
	}
	eventoAlfaNumerico(event);
}
	
	// Simulates PHP's date function
	Date.prototype.format = function(format) {
		var returnStr = '';
		var replace = Date.replaceChars;
		for (var i = 0; i < format.length; i++) {
			var curChar = format.charAt(i);
			if (replace[curChar]) {
				returnStr += replace[curChar].call(this);
			} else {
				returnStr += curChar;
			}
		}
		return returnStr;
	};
	Date.replaceChars = {
		shortMonths: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
		longMonths: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
		shortDays: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
		longDays: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
		
		// Day
		d: function() { return (this.getDate() < 10 ? '0' : '') + this.getDate(); },
		D: function() { return Date.replaceChars.shortDays[this.getDay()]; },
		j: function() { return this.getDate(); },
		l: function() { return Date.replaceChars.longDays[this.getDay()]; },
		N: function() { return this.getDay() + 1; },
		S: function() { return (this.getDate() % 10 == 1 && this.getDate() != 11 ? 'st' : (this.getDate() % 10 == 2 && this.getDate() != 12 ? 'nd' : (this.getDate() % 10 == 3 && this.getDate() != 13 ? 'rd' : 'th'))); },
		w: function() { return this.getDay(); },
		z: function() { return "Not Yet Supported"; },
		// Week
		W: function() { return "Not Yet Supported"; },
		// Month
		F: function() { return Date.replaceChars.longMonths[this.getMonth()]; },
		m: function() { return (this.getMonth() < 9 ? '0' : '') + (this.getMonth() + 1); },
		M: function() { return Date.replaceChars.shortMonths[this.getMonth()]; },
		n: function() { return this.getMonth() + 1; },
		t: function() { return "Not Yet Supported"; },
		// Year
		L: function() { return "Not Yet Supported"; },
		o: function() { return "Not Supported"; },
		Y: function() { return this.getFullYear(); },
		y: function() { return ('' + this.getFullYear()).substr(2); },
		// Time
		a: function() { return this.getHours() < 12 ? 'am' : 'pm'; },
		A: function() { return this.getHours() < 12 ? 'AM' : 'PM'; },
		B: function() { return "Not Yet Supported"; },
		g: function() { return this.getHours() % 12 || 12; },
		G: function() { return this.getHours(); },
		h: function() { return ((this.getHours() % 12 || 12) < 10 ? '0' : '') + (this.getHours() % 12 || 12); },
		H: function() { return (this.getHours() < 10 ? '0' : '') + this.getHours(); },
		i: function() { return (this.getMinutes() < 10 ? '0' : '') + this.getMinutes(); },
		s: function() { return (this.getSeconds() < 10 ? '0' : '') + this.getSeconds(); },
		// Timezone
		e: function() { return "Not Yet Supported"; },
		I: function() { return "Not Supported"; },
		O: function() { return (-this.getTimezoneOffset() < 0 ? '-' : '+') + (Math.abs(this.getTimezoneOffset() / 60) < 10 ? '0' : '') + (Math.abs(this.getTimezoneOffset() / 60)) + '00'; },
		T: function() { var m = this.getMonth(); this.setMonth(0); var result = this.toTimeString().replace(/^.+ \(?([^\)]+)\)?$/, '$1'); this.setMonth(m); return result;},
		Z: function() { return -this.getTimezoneOffset() * 60; },
		// Full Date/Time
		c: function() { return "Not Yet Supported"; },
		r: function() { return this.toString(); },
		U: function() { return this.getTime() / 1000; }
	};
//e75785

function OnKeyPressNumeros()
{
	var e_k = event.keyCode;						
	if (e_k >= 48 && e_k <= 57) //48-57 es 0 al 9
	{				
		event.returnValue = true;  
	}
	else
	{
		event.returnValue = false;
	}
}

function setClassName(objid,clase)
{
	document.getElementById(objid).className=clase;
}

function getObject(objid)
{
	return document.getElementById(objid);
}

//gaa20120514
function fSoloMontos(event, obj){
				var code = (event.which) ? event.which : event.keyCode;				
				var character = String.fromCharCode(code);
				
				if (event.shiftKey || event.altKey || event.ctrlKey)
					return false;
					
				var decimales = 0;
				var cantidad_decimales = 2;
				var salida = false;	
								
				//if ((code >= 48 && code <= 57) || (code >= 96 && code <= 105)){ // check digits
				if (code >= 48 && code <= 57){ // check digits
					if (obj.value == "0") return false;
					if (!isNaN(obj.value)){
						if (obj.value == "0.0" && code == 48){
							return false;
						}
					}
					if (obj.value.indexOf('.')>=0){
						decimales = obj.value.substring(obj.value.indexOf('.')+1, obj.value.length);	
						if (decimales.length >= cantidad_decimales){  
							//alert('decimales = ' + obj.value);
							return false;
						}
					}
					return true;
				}else if (code == 46 || code == 190){ // Check dot
					if (obj.value.indexOf(".") < 0){						
						if (obj.value.length == 0) obj.value = "0";
						return true;
					}
				}else if (code == 8){ // Allow backspace, F5
					return true;
				}else if ((code >=37 && code <= 40) && (code != 39)){ // Allow directional arrows
					return true;
				}else if (code ==9 || code == 16){ // tab control + tab
					return true;
				}
				return false;
			}
//fin gaa20120517
//gaa20120517
			function f_EventoSoloAlfanumericos()
			{
				code = window.event.keyCode;
				
				if (code == 32 ||
					(code > 47 && code < 58) ||
					(code > 64 && code < 91) ||
					(code > 96 && code < 123) ||
					code == 209 || code == 241 || code == 43  || code == 45)
					return true
				else
					return false;
			}	
			
			function isNumOrChar2(InString)
			{		
				var CaracteresPermitidos = "1234567890abcdefghijklmn?opqrstuvwxyz. ";
				InString = InString.toLowerCase();
				
				for (var i = 0; i < InString.length; i++)
				{
					if (CaracteresPermitidos.indexOf(InString.substring(i, i + 1)) < 0)
						return false;
				}
				
				return true;
			}
//fin gaa20120517	
//fin gaa20120517			

function validarNumeroPermitirControl(event) {
	if (event.keyCode == 8 || event.keyCode == 46) {
		return;
	}
	/*if (event.keyCode == 37 || event.keyCode ==39) { // Allow directional arrows
		return;
	}*/
	
	//Validacion para  permitir    ctrl + c     y    ctrl  + v
	var controlPressed=0;
	controlPressed=event.ctrlKey;

	if (controlPressed)
	{
			if (window.event.keyCode == 86 || window.event.keyCode == 67)
			{
				return false;  
			}
	}
	
	eventoSoloNumeros(event);
}		

function validaCaracteres(cadena)
{
	var key = String.fromCharCode(window.event.keyCode);
	var valid = new String(cadena);
	var ok = "no";
	for (var i=0; i<valid.length; i++)
	{
		if (key == valid.substring(i,i+1))
			ok = "yes";
	}
	if (window.event.keyCode != 16)
	{
		if (ok == "no")
			window.event.keyCode = 0;
	}
}

function validaCaracterNombre()
{
	var key = String.fromCharCode(window.event.keyCode);
	var cadena = "ABCDEFGHIJKLMN?OPQRSTUVWXYZabcdefghijklmn?opqrstuvwxyz_ ";
	var valid = new String(cadena);
	var ok = "no";
	for (var i=0; i<valid.length; i++)
	{
		if (key == valid.substring(i,i+1))
			ok = "yes";
	}

	if (window.event.keyCode == 241 || window.event.keyCode == 209)
		ok = "yes";

	if (window.event.keyCode != 16)
	{
		if (ok == "no")
			window.event.keyCode = 0;
	}
}

function validarSoloAlfanumerico()
{
	var key = String.fromCharCode(window.event.keyCode);
	var cadena = "ABCDEFGHIJKLMN?OPQRSTUVWXYZabcdefghijklmn?opqrstuvwxyz0123456789*+()-&%:/ ";
	var valid = new String(cadena);
	var ok = "no";
	for (var i=0; i<valid.length; i++)
	{
		if (key == valid.substring(i,i+1))
			ok = "yes";
	}

	if (window.event.keyCode == 241 || window.event.keyCode == 209)
		ok = "yes";

	if (window.event.keyCode != 16)
	{
		if (ok == "no")
			window.event.keyCode = 0;
	}
}

function validarControl(ctrl, value, msj)
{
	if (getValue(ctrl) == value) {
		document.getElementById(ctrl).focus();
		alert(msj);
		return false;
	}
	return true;
}
// Inicio E77568
// Implementa las funcionalidades de Hashtable en javascript
function HashTable() {
	this.hashArr = new Array();
	this.length = 0;
}
HashTable.prototype.item = function (n) {
	var i = 0;
	for (var elem in this.hashArr) {
		if (i == n) {
			return elem;
		}
		i++;
	}

	return undefined;
};
HashTable.prototype.get = function(key) {
	return this.hashArr[key];
};
HashTable.prototype.put = function(key, value) {
	if (typeof(this.hashArr[key]) == 'undefined') {
		this.length++;
	}
	this.hashArr[key] = value;
};
HashTable.prototype.remove = function(key) {
	if (typeof(this.hashArr[key]) != 'undefined') {
		this.length--;
		var value = this.hashArr[key];
		delete this.hashArr[key];
		
		return value;
	}
};
HashTable.prototype.has = function(key) {
	return (typeof(this.hashArr[key]) != 'undefined');
};
// Fin E77568 


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
 
