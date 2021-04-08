using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de FormularioSEC.
	/// </summary>
	public class FormularioSEC
	{
		private string _TipoEvaluadorCod;
		private string _CanalCod;
		private string _CanalDesc;
		private string _ResultadoFinalCod;
		private string _ResultadoFinalDesc;
		private string _FlagTerminado;
		private string _VendedorCod;
		private string _UsuarioCod;
		private string _EvaluadorCod;
		private string _SegmentoCod;
		private string _TipoCliente;
		private string _ComentarioEvaluacion;
		private string _EstadoCod;
		private string _EstadoDesc;
		private string _ResultadoDirCod;
		private string _ResultadoDirDesc;
		private string _FlagInfocorp;
		private string _MensajeExplicacion;
		private string _ControlConsumo;
		private string _PuntoVentaCod;
		private string _ExisteBSCSorg;
		private string _TipoVentaCod;
		private string _TipoActivacionCod;
		private string _TipoOperacionCod;
		private string _PlazoAcuerdoCod;
		private string _FormaPagoCod;
		private string _PuntoVentaDesc;
		private string _TipoActivacionDesc;
		private string _ComentarioPDV;
		private string _ValidacionEssalud;
		private string _ValidacionSunat;
		private string _TipoCaractCliente;
		private string _ClienteEspecialCod;
		private string _SECpadre;
		private string _ExisteBSCS;
		private string _FlagCorreo;
		private string _Correo;
		private string _EstadoCivilCod;
		private string _DistritoCod;
		private string _FlagPortabilidad;
		/*private string _CheckNombres;
		private string _CheckEssaludSunat;
		private string _CheckEdad;*/
		private int _CheckAdjuntos;
		private int _CheckAutonomia;
		private string _TiempoInicio;
		private int _ContadorIntentosTipo09;
		private int _ContadorIntentosTipo10;
		private int _ContadorIntentosTipo13;
		private int _CheckDatos;

		private string _TipoDocCliente;
		private string _NroDocCliente;
		private string _NombreCliente;
		private string _ApPaternoCliente;
		private string _ApMaternoCliente;


		//JAR - Datos de Portabilidad
		private int _Port_Oper_Ced;
		private string _Por_Estado;
		private string _Port_Telef_Cont;
		private string _Port_Flag_Rec_Ope_Ced;
		private string _Port_Cargo_Fijo_Ope_Ced;
		private string _Port_Solin_Nro_Formato;
		//Fin Cambios JAR

		private string _Direccion_Cli_IdPrefijo;
		private string _Direccion_Cli_Completa;
		private string _Direccion_Cli_Referencia;
		private string _Direccion_Cli_Departamento;
		private string _Direccion_Cli_Provincia;
		private string _Direccion_Cli_Distrito;
		private string _Direccion_Cli_Codigo_Postal;
		private string _Direccion_Cli_Pref_Telefono;
		private string _Direccion_Cli_Num_Telefono;

		private string _Direccion_Fac_IdPrefijo;
		private string _Direccion_Fac_Completa;
		private string _Direccion_Fac_Referencia;
		private string _Direccion_Fac_Departamento;
		private string _Direccion_Fac_Provincia;
		private string _Direccion_Fac_Distrito;
		private string _Direccion_Fac_Codigo_Postal;
		private string _Direccion_Fac_Pref_Telefono;
		private string _Direccion_Fac_Num_Telefono;
		private string _Direccion_Fac_Prefijo;
		private string _Direccion_Fac_NroPuerta;
		private string _Direccion_Fac_IdUrbanizacion;
		private string _Direccion_Fac_Urbanizacion;
		private string _Direccion_Fac_Manzana;
		private string _Direccion_Fac_Lote;

		private string _Direccion_Inst_IdPrefijo;
		private string _Direccion_Inst_Completa;
		private string _Direccion_Inst_Referencia;
		private string _Direccion_Inst_Departamento;
		private string _Direccion_Inst_Provincia;
		private string _Direccion_Inst_Distrito;
		private string _Direccion_Inst_Codigo_Postal;
		private string _Direccion_Inst_Pref_Telefono;
		private string _Direccion_Inst_Num_Telefono;
		private string _Direccion_Inst_Prefijo;
		private string _Direccion_Inst_NroPuerta;
		private string _Direccion_Inst_IdUrbanizacion;
		private string _Direccion_Inst_Urbanizacion;
		private string _Direccion_Inst_Manzana;
		private string _Direccion_Inst_Lote;
		//gaa20120214
		private string _Direccion_Inst_TipoDomicilio;
		//gaa20120214

		private string _Telefono_Referencia1;
		private string _Telefono_Referencia2;
		private string _VentaProactiva;
		private string _ProductoComercializar;
		private string _CampanaCodigo;
		private string _CampanaDescripcion;

		//gaa20120217
		private string _CentroPoblado;
		private string _VendedorDNI;
		//fin gaa20120217
		//gaa20120523
		private string _fechaNacPDV;
		//fin gaa20120523
		private double _cf_alquiler_kit;
		
		public string TipoDocCliente {get{ return _TipoDocCliente;} set{_TipoDocCliente = value;}}
		public string NroDocCliente {get{ return _NroDocCliente;} set{_NroDocCliente = value;}}
		public string NombreCliente {get{ return _NombreCliente;} set{_NombreCliente = value;}}
		public string ApPaternoCliente {get{ return _ApPaternoCliente;} set{_ApPaternoCliente = value;}}
		public string ApMaternoCliente {get{ return _ApMaternoCliente;} set{_ApMaternoCliente = value;}}

		public string TipoEvaluadorCod {get{ return _TipoEvaluadorCod;} set{_TipoEvaluadorCod = value;}}
		public string CanalCod {get{ return _CanalCod;} set{_CanalCod = value;}}
		public string CanalDesc {get{ return _CanalDesc;} set{_CanalDesc = value;}}
		public string ResultadoFinalCod {get{ return _ResultadoFinalCod;} set{_ResultadoFinalCod = value;}}
		public string ResultadoFinalDesc {get{ return _ResultadoFinalDesc;} set{_ResultadoFinalDesc = value;}}
		public string FlagTerminado {get{ return _FlagTerminado;} set{_FlagTerminado = value;}}
		public string VendedorCod {get{ return _VendedorCod;} set{_VendedorCod = value;}}
		public string UsuarioCod {get{ return _UsuarioCod;} set{_UsuarioCod = value;}}
		public string EvaluadorCod {get{ return _EvaluadorCod;} set{_EvaluadorCod = value;}}
		public string SegmentoCod {get{ return _SegmentoCod;} set{_SegmentoCod = value;}}
		public string TipoCliente {get{ return _TipoCliente;} set{_TipoCliente = value;}}
		public string ComentarioEvaluacion {get{ return _ComentarioEvaluacion;} set{_ComentarioEvaluacion = value;}}
		public string EstadoCod {get{ return _EstadoCod;} set{_EstadoCod = value;}}
		public string EstadoDesc {get{ return _EstadoDesc;} set{_EstadoDesc = value;}}
		public string ResultadoDirCod {get{ return _ResultadoDirCod;} set{_ResultadoDirCod = value;}}
		public string ResultadoDirDesc {get{ return _ResultadoDirDesc;} set{_ResultadoDirDesc = value;}}
		public string FlagInfocorp {get{ return _FlagInfocorp;} set{_FlagInfocorp = value;}}

		public string MensajeExplicacion {get{ return _MensajeExplicacion;} set{_MensajeExplicacion = value;}}
		public string ControlConsumo {get{ return _ControlConsumo;} set{_ControlConsumo = value;}}
		public string PuntoVentaCod {get{ return _PuntoVentaCod;} set{_PuntoVentaCod = value;}}
		public string ExisteBSCSorg {get{ return _ExisteBSCSorg;} set{_ExisteBSCSorg = value;}}
		public string TipoVentaCod {get{ return _TipoVentaCod;} set{_TipoVentaCod = value;}}
		public string TipoActivacionCod {get{ return _TipoActivacionCod;} set{_TipoActivacionCod = value;}}
		public string TipoOperacionCod {get{ return _TipoOperacionCod;} set{_TipoOperacionCod = value;}}
		public string PlazoAcuerdoCod {get{ return _PlazoAcuerdoCod;} set{_PlazoAcuerdoCod = value;}}
		public string FormaPagoCod {get{ return _FormaPagoCod;} set{_FormaPagoCod = value;}}
		public string PuntoVentaDesc {get{ return _PuntoVentaDesc;} set{_PuntoVentaDesc = value;}}
		public string TipoActivacionDesc {get{ return _TipoActivacionDesc;} set{_TipoActivacionDesc = value;}}
		public string ComentarioPDV {get{ return _ComentarioPDV;} set{_ComentarioPDV = value;}}
		public string ValidacionEssalud {get{ return _ValidacionEssalud;} set{_ValidacionEssalud = value;}}
		public string ValidacionSunat {get{ return _ValidacionSunat;} set{_ValidacionSunat = value;}}
		public string TipoCaractCliente {get{ return _TipoCaractCliente;} set{_TipoCaractCliente = value;}}
		public string ClienteEspecialCod {get{ return _ClienteEspecialCod;} set{_ClienteEspecialCod = value;}}
		public string SECpadre {get{ return _SECpadre;} set{_SECpadre = value;}}
		public string ExisteBSCS {get{ return _ExisteBSCS;} set{_ExisteBSCS = value;}}
		public string FlagCorreo {get{ return _FlagCorreo;} set{_FlagCorreo = value;}}
		public string Correo {get{ return _Correo;} set{_Correo = value;}}
		public string EstadoCivilCod {get{ return _EstadoCivilCod;} set{_EstadoCivilCod = value;}}
		public string DistritoCod {get{ return _DistritoCod;} set{_DistritoCod = value;}}
		public string FlagPortabilidad {get{ return _FlagPortabilidad;} set{_FlagPortabilidad = value;}}
		/*public string CheckNombres {get{ return _CheckNombres;} set{_CheckNombres = value;}}
		public string CheckEssaludSunat {get{ return _CheckEssaludSunat;} set{_CheckEssaludSunat = value;}}
		public string CheckEdad {get{ return _CheckEdad;} set{_CheckEdad = value;}}*/
		public int CheckAdjuntos {get{ return _CheckAdjuntos;} set{_CheckAdjuntos = value;}}
		public int CheckAutonomia {get{ return _CheckAutonomia;} set{_CheckAutonomia = value;}}

		public string TiempoInicio {get{ return _TiempoInicio;} set{_TiempoInicio = value;}}
		public int ContadorIntentosTipo09 {get{ return _ContadorIntentosTipo09;} set{_ContadorIntentosTipo09 = value;}}
		public int ContadorIntentosTipo10 {get{ return _ContadorIntentosTipo10;} set{_ContadorIntentosTipo10 = value;}}
		public int ContadorIntentosTipo13 {get{ return _ContadorIntentosTipo13;} set{_ContadorIntentosTipo13 = value;}}
		public int CheckDatos {get{ return _CheckDatos;} set{_CheckDatos = value;}}


		//JAR - Datos de Portabilidad
		public int Port_Oper_Ced {get{ return _Port_Oper_Ced;} set{_Port_Oper_Ced = value;}}
		public string Por_Estado {get{ return _Por_Estado;} set{_Por_Estado = value;}}
		public string Port_Telef_Cont {get{ return _Port_Telef_Cont;} set{_Port_Telef_Cont = value;}}
		public string Port_Flag_Rec_Ope_Ced {get{ return _Port_Flag_Rec_Ope_Ced;} set{_Port_Flag_Rec_Ope_Ced = value;}}
		public string Port_Cargo_Fijo_Ope_Ced {get{ return _Port_Cargo_Fijo_Ope_Ced;} set{_Port_Cargo_Fijo_Ope_Ced = value;}}
		public string Port_Solin_Nro_Formato {get{ return _Port_Solin_Nro_Formato;} set{_Port_Solin_Nro_Formato = value;}}
		//Fin Cambios JAR

		public string Direccion_Cli_IdPrefijo {get{ return _Direccion_Cli_IdPrefijo;} set{_Direccion_Cli_IdPrefijo = value;}}
		public string Direccion_Cli_Completa {get{ return _Direccion_Cli_Completa;} set{_Direccion_Cli_Completa = value;}}
		public string Direccion_Cli_Referencia {get{ return _Direccion_Cli_Referencia;} set{_Direccion_Cli_Referencia = value;}}
		public string Direccion_Cli_Departamento {get{ return _Direccion_Cli_Departamento;} set{_Direccion_Cli_Departamento = value;}}
		public string Direccion_Cli_Provincia {get{ return _Direccion_Cli_Provincia;} set{_Direccion_Cli_Provincia = value;}}
		public string Direccion_Cli_Distrito {get{ return _Direccion_Cli_Distrito;} set{_Direccion_Cli_Distrito = value;}}
		public string Direccion_Cli_Codigo_Postal {get{ return _Direccion_Cli_Codigo_Postal;} set{_Direccion_Cli_Codigo_Postal = value;}}
		public string Direccion_Cli_Pref_Telefono {get{ return _Direccion_Cli_Pref_Telefono;} set{_Direccion_Cli_Pref_Telefono = value;}}
		public string Direccion_Cli_Num_Telefono {get{ return _Direccion_Cli_Num_Telefono;} set{_Direccion_Cli_Num_Telefono = value;}}

		public string Direccion_Fac_IdPrefijo {get{ return _Direccion_Fac_IdPrefijo;} set{_Direccion_Fac_IdPrefijo = value;}}
		public string Direccion_Fac_Completa {get{ return _Direccion_Fac_Completa;} set{_Direccion_Fac_Completa = value;}}
		public string Direccion_Fac_Referencia {get{ return  _Direccion_Fac_Referencia;} set{_Direccion_Fac_Referencia = value;}}
		public string Direccion_Fac_Departamento {get{ return _Direccion_Fac_Departamento;} set{_Direccion_Fac_Departamento = value;}}
		public string Direccion_Fac_Provincia {get{ return _Direccion_Fac_Provincia;} set{_Direccion_Fac_Provincia = value;}}
		public string Direccion_Fac_Distrito {get{ return _Direccion_Fac_Distrito;} set{_Direccion_Fac_Distrito = value;}}
		public string Direccion_Fac_Codigo_Postal {get{ return _Direccion_Fac_Codigo_Postal;} set{_Direccion_Fac_Codigo_Postal = value;}}
		public string Direccion_Fac_Pref_Telefono {get{ return _Direccion_Fac_Pref_Telefono;} set{_Direccion_Fac_Pref_Telefono = value;}}
		public string Direccion_Fac_Num_Telefono {get{ return _Direccion_Fac_Num_Telefono;} set{_Direccion_Fac_Num_Telefono = value;}}
		public string Direccion_Fac_Prefijo {get{ return _Direccion_Fac_Prefijo;} set{_Direccion_Fac_Prefijo = value;}}
		public string Direccion_Fac_NroPuerta {get{ return _Direccion_Fac_NroPuerta;} set{_Direccion_Fac_NroPuerta = value;}}
		public string Direccion_Fac_IdUrbanizacion {get{ return _Direccion_Fac_IdUrbanizacion;} set{_Direccion_Fac_IdUrbanizacion = value;}}
		public string Direccion_Fac_Urbanizacion {get{ return _Direccion_Fac_Urbanizacion;} set{_Direccion_Fac_Urbanizacion = value;}}
		public string Direccion_Fac_Manzana {get{ return _Direccion_Fac_Manzana;} set{_Direccion_Fac_Manzana = value;}}
		public string Direccion_Fac_Lote {get{ return _Direccion_Fac_Lote;} set{_Direccion_Fac_Lote = value;}}
		
		public string Direccion_Inst_IdPrefijo {get{ return _Direccion_Inst_IdPrefijo;} set{_Direccion_Inst_IdPrefijo = value;}}
		public string Direccion_Inst_Completa {get{ return _Direccion_Inst_Completa;} set{_Direccion_Inst_Completa = value;}}
		public string Direccion_Inst_Referencia {get{ return _Direccion_Inst_Referencia;} set{_Direccion_Inst_Referencia = value;}}
		public string Direccion_Inst_Departamento {get{ return _Direccion_Inst_Departamento;} set{_Direccion_Inst_Departamento = value;}}
		public string Direccion_Inst_Provincia {get{ return _Direccion_Inst_Provincia;} set{_Direccion_Inst_Provincia = value;}}
		public string Direccion_Inst_Distrito {get{ return _Direccion_Inst_Distrito;} set{_Direccion_Inst_Distrito = value;}}
		public string Direccion_Inst_Codigo_Postal {get{ return _Direccion_Inst_Codigo_Postal;} set{_Direccion_Inst_Codigo_Postal = value;}}
		public string Direccion_Inst_Pref_Telefono {get{ return _Direccion_Inst_Pref_Telefono;} set{_Direccion_Inst_Pref_Telefono = value;}}
		public string Direccion_Inst_Num_Telefono {get{ return _Direccion_Inst_Num_Telefono;} set{_Direccion_Inst_Num_Telefono = value;}}
		public string Direccion_Inst_Prefijo {get{ return _Direccion_Inst_Prefijo;} set{_Direccion_Inst_Prefijo = value;}}
		public string Direccion_Inst_NroPuerta {get{ return _Direccion_Inst_NroPuerta;} set{_Direccion_Inst_NroPuerta = value;}}
		public string Direccion_Inst_IdUrbanizacion {get{ return _Direccion_Inst_IdUrbanizacion;} set{_Direccion_Inst_IdUrbanizacion = value;}}
		public string Direccion_Inst_Urbanizacion {get{ return _Direccion_Inst_Urbanizacion;} set{_Direccion_Inst_Urbanizacion = value;}}
		public string Direccion_Inst_Manzana {get{ return _Direccion_Inst_Manzana;} set{_Direccion_Inst_Manzana = value;}}
		public string Direccion_Inst_Lote {get{ return _Direccion_Inst_Lote;} set{_Direccion_Inst_Lote = value;}}
		//gaa20120214
		public string Direccion_Inst_TipoDomicilio {get{ return _Direccion_Inst_TipoDomicilio;} set{_Direccion_Inst_TipoDomicilio = value;}}
		//gaa20120214
		
		public string Telefono_Referencia1 {get{ return _Telefono_Referencia1;} set{_Telefono_Referencia1 = value;}}
		public string Telefono_Referencia2 {get{ return _Telefono_Referencia2;} set{_Telefono_Referencia2 = value;}}

		public string VentaProactiva {get{ return _VentaProactiva;} set{_VentaProactiva = value;}}
		public string ProductoComercializar {get{ return _ProductoComercializar;} set{_ProductoComercializar = value;}}
		public string CampanaCodigo {get{ return _CampanaCodigo;} set{_CampanaCodigo = value;}}
		public string CampanaDescripcion {get{ return _CampanaDescripcion;} set{_CampanaDescripcion = value;}}

		//gaa20120217
		public string CentroPoblado {get{ return _CentroPoblado;} set{_CentroPoblado = value;}}
		public string VendedorDNI {get{ return _VendedorDNI;} set{_VendedorDNI = value;}}
		//fin gaa20120217
		//gaa20120523
		public string fechaNacPDV
		{
			get{ return _fechaNacPDV;} set{_fechaNacPDV = value;}
		}
		//fin gaa20120523
		public double cf_alquiler_kit {get{ return _cf_alquiler_kit;} set{_cf_alquiler_kit = value;}}

		public FormularioSEC()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
	}
}
