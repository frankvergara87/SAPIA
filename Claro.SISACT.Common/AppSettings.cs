using System;

namespace Claro.SisAct.Common
{
	/// <summary>
	/// Llaves para la Validación de Identidad (Biometría y No Biometría) - PROY-25335 - Contratación Electrónica Release 0
	/// </summary>

	#region PROY-25335 | Contratación Electrónica - Release 0 | Bryan Chumbes Lizarraga 
	public class AppSettings
	{
		private static string _Key_documentoDNI;
		private static string _Key_documentoPermitido;
		private static string _Key_HuelleroPostpago;
		private static string _Key_DNIVencido;
		private static string _Key_validacionBioExitosa; 
		private static string _Key_errorHuellaDNI;
		private static string _Key_errorReniec;
		private static string _Key_errorSixBio;
		private static string _Key_clienteDiscapacidad;
		private static string _Key_cancelacionBiometria; 
		private static string _Key_msjErrorCalidadHuella; 
		private static string _Key_mensajeErrorMaximoIntentos;
		private static string _Key_canalesPermitidosCP;
		private static string _Key_validarDNIVencido;
		private static string _Key_canalesPermitidosBiometria;
		private static string _Key_TipoOperacionPermitidoReno;

		private static string _Key_codigoDocMigratorios;
		private static string _Key_codigoDocMigraYPasaporte;
		private static string _Key_codDocMigra_Pasaporte_CE;
		private static string _Key_codigoDocCIRE;
		private static string _Key_codigoDocCIE;
		private static string _Key_codigoDocCPP;
		private static string _Key_codigoDocCTM;
		private static string _Key_minLengthDocMigratorios;
		private static string _Key_maxLengthDocMigratorios;
		private static string _Key_codigoDocPasaporte07;
		private static string _Key_codigoDocPasaporte08;
		private static string _Key_flagPermitirProductosLTE;
		private static string _Key_docsExistEvaluacionPost;
		private static string _Key_tipoDocPermitidoPostCAC;
		private static string _Key_tipoDocPermitidoPostDAC;
		private static string _Key_tipoDocPermitidoPostCAD;
		private static string _Key_lineaNoCoincide;
		private static string _Key_ExpressTipoDocVentaPreRen;
		private static string _Key_ExpressTipoDocVentaPos;


		public static string Key_documentoDNI { get{return _Key_documentoDNI;} set{ _Key_documentoDNI = value;} } 
		public static string Key_documentoPermitido { get{return _Key_documentoPermitido;} set{ _Key_documentoPermitido = value;} } 
		public static string Key_HuelleroPostpago { get{return _Key_HuelleroPostpago;} set{ _Key_HuelleroPostpago = value;} }
		public static string Key_DNIVencido { get{return _Key_DNIVencido;} set{ _Key_DNIVencido = value;} }
		public static string Key_validacionBioExitosa { get{return _Key_validacionBioExitosa;} set{ _Key_validacionBioExitosa = value;} }
		public static string Key_errorHuellaDNI { get{return _Key_errorHuellaDNI;} set{ _Key_errorHuellaDNI = value;} }
		public static string Key_errorReniec { get{return _Key_errorReniec;} set{ _Key_errorReniec = value;} }
		public static string Key_errorSixBio { get{return _Key_errorSixBio;} set{ _Key_errorSixBio = value;} }
		public static string Key_clienteDiscapacidad { get{return _Key_clienteDiscapacidad;} set{ _Key_clienteDiscapacidad = value;} }
		public static string Key_cancelacionBiometria { get{return _Key_cancelacionBiometria;} set{ _Key_cancelacionBiometria = value;} }
		public static string Key_msjErrorCalidadHuella { get{return _Key_msjErrorCalidadHuella;} set{ _Key_msjErrorCalidadHuella = value;} }
		public static string Key_mensajeErrorMaximoIntentos { get{return _Key_mensajeErrorMaximoIntentos;} set{ _Key_mensajeErrorMaximoIntentos = value;} }
		public static string Key_canalesPermitidosCP { get{return _Key_canalesPermitidosCP;} set{ _Key_canalesPermitidosCP = value;} }
		public static string Key_validarDNIVencido { get{return _Key_validarDNIVencido;} set{ _Key_validarDNIVencido = value;} }
		public static string Key_canalesPermitidosBiometria { get{return _Key_canalesPermitidosBiometria;} set{ _Key_canalesPermitidosBiometria = value;} }
		public static string Key_TipoOperacionPermitidoReno { get{return _Key_TipoOperacionPermitidoReno;} set{ _Key_TipoOperacionPermitidoReno = value;} }

		public static string Key_codigoDocMigratorios { get{return _Key_codigoDocMigratorios;} set{ _Key_codigoDocMigratorios = value;} } 
		public static string Key_codigoDocMigraYPasaporte { get{return _Key_codigoDocMigraYPasaporte;} set{ _Key_codigoDocMigraYPasaporte = value;} } 
		public static string Key_codDocMigra_Pasaporte_CE { get{return _Key_codDocMigra_Pasaporte_CE;} set{ _Key_codDocMigra_Pasaporte_CE = value;} }
		public static string Key_codigoDocCIRE { get{return _Key_codigoDocCIRE;} set{ _Key_codigoDocCIRE = value;} }
		public static string Key_codigoDocCIE { get{return _Key_codigoDocCIE;} set{ _Key_codigoDocCIE = value;} }
		public static string Key_codigoDocCPP { get{return _Key_codigoDocCPP;} set{ _Key_codigoDocCPP = value;} }
		public static string Key_codigoDocCTM { get{return _Key_codigoDocCTM;} set{ _Key_codigoDocCTM = value;} }
		public static string Key_minLengthDocMigratorios { get{return _Key_minLengthDocMigratorios;} set{ _Key_minLengthDocMigratorios = value;} }
		public static string Key_maxLengthDocMigratorios { get{return _Key_maxLengthDocMigratorios;} set{ _Key_maxLengthDocMigratorios = value;} }
		public static string Key_codigoDocPasaporte07 { get{return _Key_codigoDocPasaporte07;} set{ _Key_codigoDocPasaporte07 = value;} }
		public static string Key_codigoDocPasaporte08 { get{return _Key_codigoDocPasaporte08;} set{ _Key_codigoDocPasaporte08 = value;} }
		public static string Key_flagPermitirProductosLTE { get{return _Key_flagPermitirProductosLTE;} set{ _Key_flagPermitirProductosLTE = value;} }
		public static string Key_docsExistEvaluacionPost { get{return _Key_docsExistEvaluacionPost;} set{ _Key_docsExistEvaluacionPost = value;} }
		public static string Key_tipoDocPermitidoPostCAC { get{return _Key_tipoDocPermitidoPostCAC;} set{ _Key_tipoDocPermitidoPostCAC = value;} }
		public static string Key_tipoDocPermitidoPostDAC { get{return _Key_tipoDocPermitidoPostDAC;} set{ _Key_tipoDocPermitidoPostDAC = value;} }
		public static string Key_tipoDocPermitidoPostCAD { get{return _Key_tipoDocPermitidoPostCAD;} set{ _Key_tipoDocPermitidoPostCAD = value;} }
		public static string Key_lineaNoCoincide { get{return _Key_lineaNoCoincide;} set{ _Key_lineaNoCoincide = value;} }
		public static string Key_ExpressTipoDocVentaPreRen { get{return _Key_ExpressTipoDocVentaPreRen;} set{ _Key_ExpressTipoDocVentaPreRen = value;} }
		public static string Key_ExpressTipoDocVentaPos { get{return _Key_ExpressTipoDocVentaPos;} set{ _Key_ExpressTipoDocVentaPos = value;} }
	}

	public class JSAppSettings
	{
		private string _Key_documentoDNI;
		private string _Key_documentoPermitido;
		private string _Key_HuelleroPostpago;
		private string _Key_DNIVencido;
		private string _Key_validacionBioExitosa; 
		private string _Key_errorHuellaDNI;
		private string _Key_errorReniec;
		private string _Key_errorSixBio;
		private string _Key_clienteDiscapacidad;
		private string _Key_cancelacionBiometria; 
		private string _Key_msjErrorCalidadHuella; 
		private string _Key_mensajeErrorMaximoIntentos;
		private string _Key_canalesPermitidosCP;
		private string _Key_validarDNIVencido;
		private string _Key_canalesPermitidosBiometria;
		private string _Key_TipoOperacionPermitidoReno;

		private string _Key_codigoDocMigratorios;
		private string _Key_codigoDocMigraYPasaporte;
		private string _Key_codDocMigra_Pasaporte_CE;
		private string _Key_codigoDocCIRE;
		private string _Key_codigoDocCIE;
		private string _Key_codigoDocCPP;
		private string _Key_codigoDocCTM;
		private string _Key_minLengthDocMigratorios;
		private string _Key_maxLengthDocMigratorios;
		private string _Key_codigoDocPasaporte07;
		private string _Key_codigoDocPasaporte08;
		private string _Key_flagPermitirProductosLTE;
		private string _Key_docsExistEvaluacionPost;
		private string _Key_tipoDocPermitidoPostCAC;
		private string _Key_tipoDocPermitidoPostDAC;
		private string _Key_tipoDocPermitidoPostCAD;

		public string Key_documentoDNI { get{return _Key_documentoDNI;} set{ _Key_documentoDNI = value;} } 
		public string Key_documentoPermitido { get{return _Key_documentoPermitido;} set{ _Key_documentoPermitido = value;} } 
		public string Key_HuelleroPostpago { get{return _Key_HuelleroPostpago;} set{ _Key_HuelleroPostpago = value;} }
		public string Key_DNIVencido { get{return _Key_DNIVencido;} set{ _Key_DNIVencido = value;} }
		public string Key_validacionBioExitosa { get{return _Key_validacionBioExitosa;} set{ _Key_validacionBioExitosa = value;} }
		public string Key_errorHuellaDNI { get{return _Key_errorHuellaDNI;} set{ _Key_errorHuellaDNI = value;} }
		public string Key_errorReniec { get{return _Key_errorReniec;} set{ _Key_errorReniec = value;} }
		public string Key_errorSixBio { get{return _Key_errorSixBio;} set{ _Key_errorSixBio = value;} }
		public string Key_clienteDiscapacidad { get{return _Key_clienteDiscapacidad;} set{ _Key_clienteDiscapacidad = value;} }
		public string Key_cancelacionBiometria { get{return _Key_cancelacionBiometria;} set{ _Key_cancelacionBiometria = value;} }
		public string Key_msjErrorCalidadHuella { get{return _Key_msjErrorCalidadHuella;} set{ _Key_msjErrorCalidadHuella = value;} }
		public string Key_mensajeErrorMaximoIntentos { get{return _Key_mensajeErrorMaximoIntentos;} set{ _Key_mensajeErrorMaximoIntentos = value;} }
		public string Key_canalesPermitidosCP { get{return _Key_canalesPermitidosCP;} set{ _Key_canalesPermitidosCP = value;} }
		public string Key_validarDNIVencido { get{return _Key_validarDNIVencido;} set{ _Key_validarDNIVencido = value;} }
		public string Key_canalesPermitidosBiometria { get{return _Key_canalesPermitidosBiometria;} set{ _Key_canalesPermitidosBiometria = value;} }
		public string Key_TipoOperacionPermitidoReno { get{return _Key_TipoOperacionPermitidoReno;} set{ _Key_TipoOperacionPermitidoReno = value;} }
		
		public string Key_codigoDocMigratorios { get{return _Key_codigoDocMigratorios;} set{ _Key_codigoDocMigratorios = value;} } 
		public string Key_codigoDocMigraYPasaporte { get{return _Key_codigoDocMigraYPasaporte;} set{ _Key_codigoDocMigraYPasaporte = value;} } 
		public string Key_codDocMigra_Pasaporte_CE { get{return _Key_codDocMigra_Pasaporte_CE;} set{ _Key_codDocMigra_Pasaporte_CE = value;} }
		public string Key_codigoDocCIRE { get{return _Key_codigoDocCIRE;} set{ _Key_codigoDocCIRE = value;} }
		public string Key_codigoDocCIE { get{return _Key_codigoDocCIE;} set{ _Key_codigoDocCIE = value;} }
		public string Key_codigoDocCPP { get{return _Key_codigoDocCPP;} set{ _Key_codigoDocCPP = value;} }
		public string Key_codigoDocCTM { get{return _Key_codigoDocCTM;} set{ _Key_codigoDocCTM = value;} }
		public string Key_minLengthDocMigratorios { get{return _Key_minLengthDocMigratorios;} set{ _Key_minLengthDocMigratorios = value;} }
		public string Key_maxLengthDocMigratorios { get{return _Key_maxLengthDocMigratorios;} set{ _Key_maxLengthDocMigratorios = value;} }
		public string Key_codigoDocPasaporte07 { get{return _Key_codigoDocPasaporte07;} set{ _Key_codigoDocPasaporte07 = value;} }
		public string Key_codigoDocPasaporte08 { get{return _Key_codigoDocPasaporte08;} set{ _Key_codigoDocPasaporte08 = value;} }
		public string Key_flagPermitirProductosLTE { get{return _Key_flagPermitirProductosLTE;} set{ _Key_flagPermitirProductosLTE = value;} }
		public string Key_docsExistEvaluacionPost { get{return _Key_docsExistEvaluacionPost;} set{ _Key_docsExistEvaluacionPost = value;} }
		public string Key_tipoDocPermitidoPostCAC { get{return _Key_tipoDocPermitidoPostCAC;} set{ _Key_tipoDocPermitidoPostCAC = value;} }
		public string Key_tipoDocPermitidoPostDAC { get{return _Key_tipoDocPermitidoPostDAC;} set{ _Key_tipoDocPermitidoPostDAC = value;} }
		public string Key_tipoDocPermitidoPostCAD { get{return _Key_tipoDocPermitidoPostCAD;} set{ _Key_tipoDocPermitidoPostCAD = value;} }
		
	}

	#endregion

}
