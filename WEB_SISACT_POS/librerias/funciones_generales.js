include('validaciones.js');

function include(filename)
{
	var head = document.getElementsByTagName('head')[0];
	
	script = document.createElement('script');
	script.src = filename;
	script.type = 'text/javascript';
	
	head.appendChild(script)
}

function setValue(id,v){
	var c = document.getElementById(id);
	if (c != null )
		c.value = v;
}

function getValue(id){
	var c = document.getElementById(id);
	if (c != null )
		return c.value;
	return '';
}
function getText(id){
	var c = document.getElementById(id);
	if (c != null )
		return c.options[c.selectedIndex].text;
	return '';
}

function setValueHTML(id,v){
	var c = document.getElementById(id);
	if (c != null )
		c.innerHTML = v;	
}
function setFocus(id){
	var c = document.getElementById(id);
	if (c != null )
		if (c.disabled == false && isVisible(id)==true )
			c.focus();
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
function setEnabled(id,soloLectura,classname){
	var c = document.getElementById(id);
	if (c==null) return;
	c.disabled = soloLectura;
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

// Elimina los espacios en blanco que son innecesarios.
// " prueba para  ver   " -> "prueba para ver"
function trim(cadena) {
	cadena = cadena.toString().replace(/^\s+(.*)\s+$/, "$1");
	cadena = cadena.toString().replace(/\s{2,}/g, " ");
	return cadena;
}

// Convierte un String a Hash.
// De la forma: "1,r|key,value|item,60" -> { '1'=>'r', 'key'=>'value', 'item'=>'60' }
function strToHash(strCadena) {
	var temp = strCadena.split('|');
	var response = new Array();
	for ( var index in temp ) {
	    var item = temp[index].split(',');
	    if (item.length == 2) {
	        response[item[0]] = item[1];
	    } else {
	        response[item[0]] = item[0];
	    }
	}
	return response;
}

// Convierte un String a Array.
// De la forma: "1$r$value$item$60" -> ['1', 'r', 'value', 'item', '60' ]
// strToArray(strCadena, '$')
function strToArray(strCadena, sepElementos) {
	var response = strCadena.split(sepElementos);
	return response;
}

// Convierte una Hora en un equivalente Numerico (no tiene q ser necesariamente un estandar ya establecido).
// 03:30 PM -> 10330 | 12:45 AM -> 1245
function hourToInt(hora) {
	// Hora debe ester formato "HH:MM AM/PM"
	if ( !isHour(hora) ) {
		return;
	}
	hora = hora.toUpperCase();
	return ( (hora.substr(6,1) == 'P' ? '1' : '') + '' + hora.substr(0,2) + '' + hora.substr(3,2) );
}

// Convierte una Fecha en un equivalente Numerico (no tiene q ser necesariamente un estandar ya establecido).
// 15/12/1982 -> 19821215 | 01/05/2009 -> 20090501
function dateToInt(fecha) {
	// Fecha debe ester formato "DD/MM/AAAA"
	if ( !isDate(fecha) ) {
		return;
	}
	return ( fecha.substr(6,4) + '' + fecha.substr(3,2) + '' + fecha.substr(0,2) );
}

// Convierte el Numero de Mes a su representacion Literal.
// 01 -> Enero | 09 -> Septiembre
function mesString(strNumero) {
	// Validar que el strNumero ingresado se convierta a Numero si el caso lo requiera.
	// ejm: "02" -> 2 | "11" -> 11
	var index = strNumero.replace(/^0+/, "");
	var meses = new Array ('', 'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
						'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre');
	return meses[index];
}

// Controla el evento KeyPress, permitiendo solo valores numericos (0,1,2,3,4,5,6,7,8,9)
function eventoSoloNumeros(event) {
	if( (event.keyCode>=48 && event.keyCode<=57) || (event.keyCode>=96 && event.keyCode<=105) ) {
		event.returnValue = true;
	}
	else {
		event.returnValue = false;
	}
	/*var tecla = String.fromCharCode(event.keyCode)
	alert(isNumber(tecla));
	if( !isNumber(tecla) ) {
		event.returnValue = false;
	}*/
}

// Controla el evento KeyPress, permitiendo solo valores alfa-numericos (a,b..y,z, 0,1..8,9)
function eventoAlfaNumerico(event) {
	if( (event.keyCode>=65 && event.keyCode<=90) ) {
		event.returnValue = true;
	}
	else {
		eventoSoloNumeros(event);
	}
}

function eventoSoloMontos(event, obj){
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

function getIndexOf(aElementos, elemento) {
	var i;
	for (i = 0; i < aElementos.length; i++) {
		if (aElementos[i] == elemento) {
			return i;
		}
	}
	return -1;
}

function addOption(selectbox, value, text) {
	var optn = document.createElement("OPTION");
	optn.value = value;
	optn.text = text;
	selectbox.options.add(optn);
}

//Bloqueamos la tecla BACKSPACE en la ventana
function cancelBack()   
{   
	if (
	(event.keyCode == 8 ||    
	(event.keyCode == 37 && event.altKey) ||    
	(event.keyCode == 39 && event.altKey)
	)   
	&&    
	(
	event.srcElement.form == null || 
	(event.srcElement.isTextEdit == false && !event.srcElement.readOnly)
	)   
	)   
{   
	event.cancelBubble = true;   
	event.returnValue = false;   
}   
}   

function removeOption(selectbox, index) {
	//selectbox.remove(index);
	selectbox.options.remove(index);
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
 
