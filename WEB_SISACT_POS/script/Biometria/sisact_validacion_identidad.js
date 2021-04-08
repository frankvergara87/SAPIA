//#Region Inicio PROY-25335 | Contratación Electrónica | Bryan Chumbes Lizarraga

var flagBuscarSec = '0'; // "0" No mostrara el detalle de la sec / "1" Mostrara el Detalle de la Sec.
var NoBiometria = 'N'; // "N" No pasará por la NoBiometría / "S" Pasará por la NoBiometría
var tipodniconfig = null;
var hit = '0';
var ValOk = '';

function f_ValidacionIdentidad() 
{
NoBiometria = 'N';
flagBuscarSec = '0';
 $("#hidBiometriaExito").val('0');
   ValidacionIdentidad();

  if (NoBiometria == 'S') OpenValidarNoBiometria(ValOk);

  if (flagBuscarSec == '1') 
  {
  $("#hidBiometriaExito").val('1');
  RealizarVenta();
  }
  //else setVisible('trSecDetalle', false); //cambiar
}

function ValidacionIdentidad() {
    var tipodoc = getValue('ddlTipoDocumento');
    tipodniconfig = Key_documentoDNI;
    var flagBioPost = $('#hidflagBioPost').val();
    var flagHuelleroPost = $('#hidflagHuelleroPost').val();
    var flagTipoOperacion = $('#hidRespuestaChip').val();

if (flagTipoOperacion == '') 
{
	flagTipoOperacion = '-1';
}

    if (Key_TipoOperacionPermitidoReno.indexOf(flagTipoOperacion) > -1) 
    {
        if (flagBioPost == 'S') {
            if (Key_documentoPermitido.indexOf(tipodoc) > -1) {
                if (flagHuelleroPost == 'S') AbrirConfirmacion();
                else OpenValidarBiometria();
            }
            else flagBuscarSec = '1';
        }
        else flagBuscarSec = '1';
    }
    else flagBuscarSec = '1';

}

function AbrirConfirmacion() {

  if (confirm(Key_HuelleroPostpago)) OpenValidarBiometria();
  else NoBiometria = 'S'
}

function OpenValidarBiometria() {

  var tipDoc = getValue('ddlTipoDocumento');
  var numDoc = getValue('txtNroDoc');
  var canal = getValue('hidTipoCanal');
  var oficinaVenta = getValue('hidOficina');
  var sec = getValue('hidNroSEC'); 
  var flagOrigen = "RN";
  var ctaUsuario = $("#hidCurrentUser").val();

    if ($("#hidPerfil_149").val() != "")
    {
        canal = getValue('ddlCanal');
        oficinaVenta = getValue('ddlPuntoVenta');
    }
    
  var url1 = consUrlPaginaBiometria + "?tipDoc=" + tipDoc + "&numDoc=" + numDoc + "&pdv=" + oficinaVenta + "&canal=" + canal + "&sec=" + sec + "&idPadre=" + $("#hidIdPadreBio").val() + "&flagOrigen=" + flagOrigen + "&ctaUsuario=" + ctaUsuario;
  var opc = 'dialogWidth:700px;dialogHeight:460px;Menubar=no;Status=no;Titlebar=no;Toolbar=no;Location=no';
  var retVal = window.showModalDialog(url1, '', opc); 
  if (retVal == null) {
    flagBuscarSec = '0';
    return;
  }
  else {
    var retorno = retVal.split('|');
    ValOk = retorno[0];
    var nombrereniec = retorno[1];
    var apepatreniec = retorno[2];
    var apematreniec = retorno[3];
    var dniCaducado = retorno[4];
    var fechaCaducidad = retorno[5];
    var serieLector = retorno[6];

    RetornarValidacionBiometrica(ValOk, nombrereniec, apepatreniec, apematreniec, dniCaducado, fechaCaducidad,serieLector,numDoc);
  }
}



function RetornarValidacionBiometrica(ValOk, nombrereniec,apepatreniec, apematreniec, dniCaducado, fechaCaducidad,serieLector,numDoc) {
$('#hidSerieLector').val(serieLector);
  hit = '0'
  if (ValOk == '1') {
    if (dniCaducado == 'S') 
    {
      if (Key_validarDNIVencido == '1') {
                alert(Key_DNIVencido);
            }
            else {
                alert(Key_validacionBioExitosa);
                  flagBuscarSec = '1';
                hit = '1'
                $('#hidDatosBio').val(nombrereniec + ';' + apepatreniec + ';' + apematreniec + ';' + numDoc);
            }
    }
    else {
      alert(Key_validacionBioExitosa);
      flagBuscarSec = '1';
      hit = '1'
      $('#hidDatosBio').val(nombrereniec + ';' + apepatreniec + ';' + apematreniec + ';' + numDoc);
    }
  }
  else if (ValOk == '2') {
    alert(Key_errorHuellaDNI);
    return;
  }
  else if (ValOk == '-2') {
    alert(Key_errorReniec);
    NoBiometria = 'S'
  }
  else if (ValOk == '-3') {
    alert(Key_errorSixBio);
    return;
  }
  else if (ValOk == '-4') {
    alert(Key_clienteDiscapacidad);
    NoBiometria = 'S'
  }
  else if (ValOk == '5') {
    alert(Key_mensajeErrorMaximoIntentos);
    NoBiometria = 'S'
  }
  else if (ValOk == '-5') {
    alert(Key_msjErrorCalidadHuella);
    return;
  }
  else {
    alert(Key_cancelacionBiometria);
    return;
  }
}

function OpenValidarNoBiometria(motivoNoBio) {
  var url1 = '';
  var numDoc = getValue('txtNroDoc');
  var canal = getValue('hidTipoCanal');
  var oficinaVenta = getValue('hidOficina');
  var sec = getValue('hidNroSEC'); 

    if ($("#hidPerfil_149").val() != "")
    {
        canal = getValue('ddlCanal');
        oficinaVenta = getValue('ddlPuntoVenta');
    }
    
  url1 = consUrlPaginaNoBiometria + "?nrodoc=" + numDoc + "&pdv=" + oficinaVenta + "&ofi=" + canal + "&sec=" + sec + "&idPadre=" + $("#hidIdPadreBio").val() + "&motivoNoBio=" + motivoNoBio ;
  var opc ='dialogWidth:700px;dialogHeight:300px;Menubar=no;Status=no;Titlebar=no;Toolbar=no;Location=no';
  var retVal = window.showModalDialog(url1, '', opc);

  if (retVal == null) {
    flagBuscarSec = '0';
    return;
  }
  else {
    var retorno = retVal.split('|');

    var ValOkNoBio = retorno[0];
    var nombrereniec = retorno[1];
    var apepatreniec = retorno[2];
    var apematreniec = retorno[3];
    var fechaNacimiento = retorno[4];

    RetornarValidacionNoBiometrica(ValOkNoBio, nombrereniec, apepatreniec,apematreniec, fechaNacimiento,numDoc)
  }
}


function RetornarValidacionNoBiometrica(ValOkNoBio, nombrereniec,apepatreniec, apematreniec, fechaNacimiento,numDoc) {

  if (ValOkNoBio == "0") {
    hit = '1';
    flagBuscarSec = '1';
    $('#hidDatosBio').val(nombrereniec + ';' + apepatreniec + ';' + apematreniec + ';' + numDoc);
  }
  else
    flagBuscarSec = '0';
}

//#Region Fin PROY-25335 | Contratación Electrónica | Bryan Chumbes Lizarraga