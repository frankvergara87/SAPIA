function mostrarMensaje() {
	if (getValue('hidMsg') != '') {
		alert(getValue('hidMsg'));
		setValue('hidMsg','');
	}
}

function HabilitarPaso(nroPaso, nroTotalPasos)
{	
	nroPaso = eval(nroPaso);
	nroTotalPasos = eval(nroTotalPasos);
	for(var i=1;i<nroPaso;i++){
		if (document.getElementById("trPaso" + i) != null) {
			setVisible("trPaso" + i,true);
			//setEnabled("trPaso" + i,true,'');
		}
	}
	if (document.getElementById("trPaso" + nroPaso) != null) {
		setVisible("trPaso" + nroPaso,true);
		//setEnabled("trPaso" + nroPaso,false,'');
		//setEnabled("btnPaso" + nroPaso,false,'');
	}

	for(var i=nroPaso+1;i<=nroTotalPasos;i++){
		if (document.getElementById("trPaso" + i) != null) {
			setVisible("trPaso" + i,false);
			//setEnabled("trPaso" + i,true,'');
		}
	}

	var objIfrs = document.getElementsByTagName("iframe");
	for (var k=0;k<objIfrs.length;k++){
		if (objIfrs[k].contentWindow != null) {
			//objIfrs[k].contentWindow.HabilitarPaso(nroPaso, nroTotalPasos);
			objIfrs[k].contentWindow.opener = window.opener;
		}
	}
	
	mostrarMensaje();
}

function validarNumero(event) {
	if (event.keyCode == 8 || event.keyCode == 46) {
		return;
	}
	if (event.keyCode >= 37 && event.keyCode <= 40) { // Allow directional arrows
		return;
	}
	eventoSoloNumeros(event);
}
 
 
