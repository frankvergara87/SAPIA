//#Region Inicio PROY-25335 | Contratación Electrónica | Bryan Chumbes Lizarraga

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


$(document).ready(function () {
debugger;
    Anthem_InvokePageMethod('getParametros',[],
						function(result){
						var response = result.value
							getParametros_CallBack(response);		
						}
					);

    function getParametros_CallBack(response) {
debugger;
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
    }
});

//#Region Fin PROY-25335 | Contratación Electrónica | Bryan Chumbes Lizarraga