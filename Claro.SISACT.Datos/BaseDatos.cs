using System;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for Funciones.
	/// </summary>
	public class BaseDatos
	{
		//-inicio-dga-31072015
		private static string _BD_MSSAP="BD_SINERGIA";
		//-fin-dga-31072015

		private static string _BD_CLARIFY="BD_CLARIFY";
		private static string _BD_SISACT="BD_SISACT";
		private static string _BD_SIAC="BD_SIAC";
		private static string _BD_DBAUDIT="BD_DBAUDIT";		
		private static string _NOMBRE_PACKAGE_CUSTOMER_CLFY = ""; 
		private static string _NOMBRE_PACKAGE_INTERCCION_CLFY = "";
		private static string _NOMBRE_PACKAGE_PROCESO_DOL="";
		private static string _NOMBRE_PACKAGE_SIAC_ST_CONSULTA = ""; 
		private static string _BD_BSCS = "BD_BSCS";
		private static string _NOMBRE_PACKAGE_PROCESO_MIGRACION = "";
		private static string _BD_EAI="BD_EAI";
		private static string _NOMBRE_PACKAGE_SIAC_GENERICO="";
		private static string _BD_SISCAD="BD_SISCAD";
		private static string _BD_SGA="BD_SGA";
		private static string _BD_SIGA="BD_SIGA";
		private static string _BD_PUNTOSCC = "BD_PUNTOSCC";
		private static string _BD_DWH="BD_DWH";
		//inicio whzr 02102014
		private static string _BD_NSIGA="BD_NSIGA";
		public static string SISACT_PKG_CONTRATO = "SISACT_PKG_CONTRATO_";
		//fin whzr 02102014

		//Inicio RIHU 19122014 - Everis
		private static string _PKG_SISACT_CONSULTA_BRMS = "SISACT_PKG_CONSULTA_BRMS";
		private static string _PKG_SISACT_GENERAL_II = "SISACT_PKG_GENERAL_II";
		//Fin RIHU 19122014 - Everis
		//Inicio RIHU 30122014 - DesbloqueoEquipo
		private static string _BD_SIMLOCK ="BD_PROCPPDB";
		private static string _SISACT_PKG_DES_IMEI = "SISACT_PKG_DES_IMEI";
		private static string _PKG_SIMLOCK = "PKG_DESBLOQUEO_EQUIPO";
// MRAF
		private static string _BD_SIAPDV="BD_SIAPDV";

		//private static string _BD_MSSAP = "BD_MSSAP";
// MRAF
		public static string BD_SIAPDV
		{
			get{ return _BD_SIAPDV;}
		}

		public static string BD_SIMLOCK
		{
			get{ return _BD_SIMLOCK;}
		}
		// FMES
		private static string _BD_REPTDM= "BD_REPTDM";

		public static string BD_REPTDM
		{
			get{ return _BD_REPTDM;}
		}
		
		//<!-- INICIO PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
		//<!-- INICIO MUC2016 -->
		public static string PKG_RENO_ANTICIPADA
		{
			get
			{
				string p = "PKG_SISACT_ACUERDO_RENOV";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//<!-- FIN MUC2016 -->
		//<!-- FIN PROY-9067 - IDEA-11443 Mejora en procesos de Cambio de Plan para renovaciones -->
		
		public static string PKG_SISACT_DTH_REPTDM
		{
			get
			{
				string p = "SISACT_PKG_DTH";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaREPTDM"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		// FMES
		//REINTEGRO APADECE
		private static string _NOMBRE_PACKAGE_SIGA_ACUERDO =""; // OK NO BORRAR
		private static string _NOMBRE_PACKAGE_BSCS_SIAC_TRAN=""; //OCC	
		public static string BD_SISACT
		{
			get{ return _BD_SISACT;}
		}				
		public static string BD_SIAC
		{
			get{ return _BD_SIAC;}
		}
		public static string BD_DBAUDIT
		{
			get{ return _BD_DBAUDIT;}
		}

		public static string BD_SISCAD
		{
			get{ return _BD_SISCAD;}
		}

		public static string BD_SGA
		{
			get{ return _BD_SGA;}
		}

		public static string BD_SIGA
		{
			get{ return _BD_SIGA;}
		}
		public static string BD_PUNTOSCC
		{
			get{ return _BD_PUNTOSCC;}
		}

		public static string BD_DWH
		{
			get{ return _BD_DWH;}
		}

		//inicio whzr 02102014
		public static string BD_NSIGA
		{
			get{ return _BD_NSIGA;}
		}

		public static string PKG_SIGA_CONSULTAS
		{
			get
			{
				string p = "pkg_siga_consultas";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaNSIGA"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin whzr 02102014
		

		public static string PKG_CC_TRANSACCION
		{
			get
			{
				string p = "PKG_CC_TRANSACCION";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaPUNTOSCC"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SISACT_SOLICITUD
		{
			get
			{
				string p = "SISACT_PKG_SOLICITUD";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string SISACT_PKG_PLAN_TARIFARIO
		{
			get
			{ 
				string p = "SISACT_PKG_PLAN_TARIFARIO";	
				//SISACT_PKG_PLAN_TARIFARIO
							
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SISACT_CONSULTAS
		{
			get
			{ 
				string p = "SISACT_PKG_CONSULTA_GENERAL";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SISACT_MAESTROS
		{
			get
			{
				string p = "SISACT_PKG_MAESTROS_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_MANTENIMIENTO
		{
			get
			{
				string p = "SISACT_PKG_MANTENIMIENTO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_EVALUACION_CONS_2
		{
			get
			{
				string p = "SISACT_PKG_EVALUACION_CONS_2";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//gaa20170327
		public static string PKG_SISACT_EVALUACION_CONS_2_
		{
			get
			{
				string p = "SISACT_PKG_EVALUACION_CONS_2_";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin gaa20170327
		public static string BD_CLARIFY
		{
			get
			{				
				_BD_CLARIFY = "BD_CLARIFY";
				return _BD_CLARIFY;				
			}
		}		
		public static string NOMBRE_PACKAGE_CUSTOMER_CLFY
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaCLF"];
				if (esquema != "")
					_NOMBRE_PACKAGE_CUSTOMER_CLFY = esquema + ".PCK_CUSTOMER_CLFY";
				else
					_NOMBRE_PACKAGE_CUSTOMER_CLFY = "PCK_CUSTOMER_CLFY";
				return _NOMBRE_PACKAGE_CUSTOMER_CLFY;

			}
		}
		public static string PCK_MANT_TABLAS
		{
			get
			{
				string p = "SISACT_PCK_MANT_TABLAS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string NOMBRE_PACKAGE_INTERCCION_CLFY
		{
			get
			{
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaCLF"];
				if (esquema != "")
					_NOMBRE_PACKAGE_INTERCCION_CLFY = esquema + ".PCK_INTERACT_CLFY";
				else
					_NOMBRE_PACKAGE_INTERCCION_CLFY= "PCK_INTERACT_CLFY";
				return _NOMBRE_PACKAGE_INTERCCION_CLFY;				
			}
		}

		public static string PKG_SISACT_MANT_PLN
		{
			get
			{
				string p = "SISACT_PKG_MANT_PLN";                                            
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
                  
			}
		}
		public static string NOMBRE_PACKAGE_PROCESO_DOL
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIAC"];
				if (esquema != "")
					_NOMBRE_PACKAGE_PROCESO_DOL = esquema + ".PKG_PROCESO_DOL";
				else
					_NOMBRE_PACKAGE_PROCESO_DOL = "PKG_PROCESO_DOL";
				return _NOMBRE_PACKAGE_PROCESO_DOL;

			}
		}
		public static string NOMBRE_PACKAGE_SIAC_ST_CONSULTA
		{
			get
			{ 
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIAC"];
				if (esquema != "")
					_NOMBRE_PACKAGE_SIAC_ST_CONSULTA = esquema + ".PKG_SIAC_ST_CONSULTAS";
				else
					_NOMBRE_PACKAGE_SIAC_ST_CONSULTA= "PKG_SIAC_ST_CONSULTAS";
				
				return _NOMBRE_PACKAGE_SIAC_ST_CONSULTA;
			}
		}
		public static string PKG_SISACT_VENTA_EXPRESS
		{
			get
			{
				string p = "SISACT_PKG_VENTA_EXPRESS_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_EXPRESS_PORTABILIDAD
		{
			get
			{
				string p = "SISACT_PKG_EXPRESS_PORTA_";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if(esquema != null && esquema != "") p= esquema + "." + p;
				return p;
			}
		}       
    
		public static string PKG_SECP_MAESTROS
		{
			get
			{ 
				string p = "SECP_PKG_MAESTROS";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string BD_BSCS
		{
			get{ return _BD_BSCS;}
		}

		public static string PKG_BSCS_CONSULTA_CONS
		{
			get
			{
				string p = "PKG_PARAMETRICO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_SOLICITUD_CONS
		{
			get
			{
				string p = "SISACT_PKG_SOLICITUD_CONS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string SECP_PKG_SOLICITUDES
		{
			get
			{
				string p = "SECP_PKG_SOLICITUDES_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string NOMBRE_PACKAGE_PROCESO_MIGRACION
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaEAI"];
				if (esquema != "")
					_NOMBRE_PACKAGE_PROCESO_MIGRACION = esquema + ".PKG_PROCESO_MIGRACION";
				else
					_NOMBRE_PACKAGE_PROCESO_MIGRACION = "PKG_PROCESO_MIGRACION";
				return _NOMBRE_PACKAGE_PROCESO_MIGRACION;
			}
		}

		public static string BD_EAI
		{
			get{return _BD_EAI;}
		}
		public static string NOMBRE_PACKAGE_SIAC_GENERICO
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIAC"];
				if (esquema != "")
					_NOMBRE_PACKAGE_SIAC_GENERICO = esquema + ".PKG_SIAC_GENERICO";
				else
					_NOMBRE_PACKAGE_SIAC_GENERICO = "PKG_SIAC_GENERICO";
				return _NOMBRE_PACKAGE_SIAC_GENERICO;

			}
		}
		public static string PKG_SEGU_SEGURIDAD
		{
			get
			{
				string p = "SEGU_PKG_SEGURIDAD";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaDBAUDIT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISCAD_MANTENIMIENTO
		{
			get
			{
				string p = "SISCAD_PKG_MANTENIMIENTO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SISCAD_VENTA
		{
			get
			{
				string p = "SISCAD_PKG_VENTA";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_DATAENTRY
		{
			get
			{
				string p = "SISACT_PKG_DATAENTRY";                                            
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
                  
			}
		}

		public static string pkg_siscad_mantenimiento
		{
			get
			{
				string p = "siscad_pkg_mantenimiento";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string SISCAD_PKG_RENTAADELANTADA
		{
			get
			{
				string p = "SISCAD_PKG_RENTAADELANTADA";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISCAD_CONSULTAS
		{
			get
			{
				string p = "SISCAD_PKG_CONSULTAS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISCAD"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//gaa20120514
		public static string PKG_SISACT_DTH
		{
			get
			{
				string p = "SISACT_PKG_DTH";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin gaa20120514

		public static string PKG_SISACT_TIPO_BLOQUEO
		{
			get
			{
				string p = "SISACT_PKG_TIPO_BLOQUEO";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_BSCS_PARAMETRICO_BLOQUEO
		{
			get
			{
				string p = "PKG_PARAMETRICO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string SISACT_PKG_CASOESPECIAL
		{
			get
			{
				string p = "SISACT_PKG_CASOESPECIAL";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}
		public static string SISACT_PKG_GENERAL
		{
			get
			{
				string p = "SISACT_PKG_GENERAL";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}
		//gaa20121119
		public static string PKG_SISACT_GENERAL_II
		{
			get
			{ 
				string p = "SISACT_PKG_GENERAL_II";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin gaa20121119
		public static string NOMBRE_PACKAGE_SIGA_ACUERDO
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIGA"];
				if (esquema != "")
					_NOMBRE_PACKAGE_SIGA_ACUERDO = esquema + ".PKG_SIGA_ACUERDO";
				else
					_NOMBRE_PACKAGE_SIGA_ACUERDO = "PKG_SIGA_ACUERDO";
				return _NOMBRE_PACKAGE_SIGA_ACUERDO;

			}
		}
		//***** EMC//
		public static string SISACT_PKG_VENTA_PREPAGO
		{
			get
			{
				string p = "SISACT_PKG_VENTA_PREPAGO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string NOMBRE_PACKAGE_BSCS_SIAC_TRAN
		{
			get
			{				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if (esquema != "")
					_NOMBRE_PACKAGE_BSCS_SIAC_TRAN = esquema + ".PP005_SIAC_TRX";
				else
					_NOMBRE_PACKAGE_BSCS_SIAC_TRAN = "PP005_SIAC_TRX";
				return _NOMBRE_PACKAGE_BSCS_SIAC_TRAN;

			}
		}
		public static string PKG_SISACT_GENERAL
		{
			get
			{ 
				//string p = "SISACT_PKG_GENERAL_HFC";
				string p = "SISACT_PKG_GENERAL";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_BSCS_BOLSA
		{
			get
			{
				string p = "pp_bolsa";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS_ADM"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}
		public static string PKG_SISACT_BURO_CREDITICIO
		{
			get
			{
				string p = "SISACT_PKG_BURO_CREDITICIO";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_PORCEN_FACT
		{
			get
			{
				string p = "PKG_SISACT_PORCEN_FACT";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PQ_INT_SISACT_CONSULTA
		{
			get
			{ 
				string p = "PQ_INT_SISACT_CONSULTA";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["Esquema_SGA2"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_INTEGRACION_DTH
		{
			get
			{ 
				string p = "PQ_INTEGRACION_DTH";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["Esquema_SGA"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string SISACT_PKG_PROCESOS
		{
			get
			{
				string p = "SISACT_PKG_PROCESOS";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if(esquema != null && esquema != "") p= esquema + "." + p;
				return p;
			}
		} 
		public static string PKG_SISACT_EVALUACION_SMS
		{
			get
			{ 
				string p = "SISACT_PKG_EVALUACION_SMS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SISACT_EVALUACION_UNI
		{
			get
			{ 
				string p = "SISACT_PKG_EVALUACION_UNI";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}


		public static string PKG_PORTABILIDAD
		{
			get
			{
				string p = "SISACT_PKG_PORTABILIDAD_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_RENOVACION
		{
			get
			{ 
				string p = "SISACT_PKG_RENOVACION";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_TATENCION
		{
			get
			{
				string p = "SISACT_PKG_TATENCION";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_HISTORICO_DC
		{
			get
			{
				string p = "SISACT_PKG_HISTORICO_DC";                                            
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}


		public static string PQ_INTEGRACION_DTH
		{
			get
			{ 
				string p = "PQ_INTEGRACION_DTH";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSGA"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string TIM098_LISTA_PLAN_TC
		{
			get
			{
				string p = "TIM098_LISTA_PLAN_TC";                                            
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		//************************************************** INICIO WHZR **********************************************

		public static string TIM150_VAL_SALE_4G
		{
			get
			{
				string p = "TIM150_VAL_SALE_4G";                                            
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		//************************************************** FIN WHZR    **********************************************


		public static string PKG_SISACT_EVALUACION
		{
			get
			{
				string p = "SISACT_PKG_EVALUACION";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_PQ_CONSULTA_SIAC_SRV
		{
			get
			{ 
				string p = "PQ_CONSULTA_SIAC_SRV";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["Esquema_SGA2"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_CLIENTE
		{
			get
			{
				string p = "PKG_PARAMETRICO";								
				//string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_REGLAS
		{
			get
			{
				string p = "SISACT_PKG_REGLAS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string TIM142_PKG_EMPRESAS
		{
			get
			{ 
				string p = "TIM142_PKG_EMPRESAS";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_PORTABILIDAD_CORP
		{
			get
			{
				string p = "SISACT_PKG_PORTABILIDAD_CORP";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_EVALUACION_SEC
		{
			get
			{
				string p = "SISACT_PKG_EVALUACION_SEC";	//MARVIN
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_ACUERDO
		{
			get
			{ 
				string p= "SISACT_PKG_ACUERDO_6";		
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		//DRC
		public static string PKG_SISACT_VENDEDOR_SEGURIDAD
		{
			get
			{
				string p = "SISACT_PKG_VENDEDOR_SEGURIDAD";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			
			}
		}

		public static string PKG_SISACT_CONSULTA_BRMS
		{
			get
			{
				string p = "SISACT_PKG_CONSULTA_BRMS";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
	
		//-----Roaming Internacional -----------------

		public static string PKG_ROAMING_SERV
		{
			get
			{ 
				string p = "SISACT_PKG_ROAMING_SERV";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//------Roaming Internacional --------------------


		//--------------- VAS ---------------------
		public static string PKG_SISACT_SERVICIO_VAS
		{
			get
			{
				string p = "SISACT_PKG_SERVICIO_VAS";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//--------------- VAS ---------------------

		//--------------- CHIP REPUESTO POSTPAGO ---------------------
		public static string SP_LISTA_SERVICIOS
		{
			get
			{
				string p = "lista_servicios";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//--------------- CHIP REPUESTO POSTPAGO ---------------------

		public static string PKG_DWH_ABONADOS_CLARO
		{
			get
			{ 
				string p = "pkg_abonados_claro";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaDWH"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		public static string PKG_SIAC_GENERICO
		{
			get
			{ 
				string p = "pkg_siac_generico";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIAC"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

//ldrz
		public static string PKG_SISACT_MANT_POSTVENTA
		{
			get
			{
				string p = "SISACT_PKG_MANT_POSTVENTA";  //SISACT_PKG_MANT_POSTVENTA  //MAC  maquino				
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string PKG_SISACT_MANTENIMIENTO_3PLAY
		{
			get
			{
				string p = "SISACT_PKG_MANTENIMIENTO_3PLAY";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		public static string SISACT_PKG_VENDEDOR_SEGURIDAD
		{
			get
			{
				string p = "SISACT_PKG_VENDEDOR_SEGURIDAD";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if(esquema != null && esquema != "") p= esquema + "." + p;
				return p;
			}
		}

		public static string Tim127CompPago
		{
			get
			{
				string p = "TIM127_COMP_PAGO";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		// Inicio RIHU - 19-12-14 - Everis
		public static string BSCS_LINEAS_ACTIVAS
		{
			get
			{
				//string p = "SP_LISTA_LINEA_X_DOCUM";
				string p = "SP_LISTA_LINEA_X_DOCUM_OPT";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if(esquema != null && esquema != "") p= esquema + "." + p;
				return p;
			}
		} 

		public static string SISACT_OBTENERPARAMETRO
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SP_OBTENER_PARAMETRO_CONFI";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_VALIDARWHITEBLACKLIST
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SISACTSS_BLACKWHITELIST";
				return p;
			}
		}

		public static string SISACT_ENVIARSMS
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".MANT_INSERT_CLAVE_ENVIOSMS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_VALIDARBRMS
		{
			get
			{
				string p = _PKG_SISACT_CONSULTA_BRMS + ".SP_CON_VALIDACION_BRMS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_OBTENERSMS
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SP_OBTENER_CLAVE_SMS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_GUARDARLOGS
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SP_INSERT_SISACT_AUDI_LOGS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_ACTUALIZARLOGS
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SP_UPDATE_SISACT_AUDI_LOGS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}
		public static string SISACT_CONSULTARLOGS
		{
			get
			{
				string p = _PKG_SISACT_GENERAL_II + ".SP_CONSUL_SISACT_AUDI_LOGS";
				//				string esquema = ConfigurationManager.AppSettings["EsquemaSISACT"];
				//				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		//FIN RIHU - 19-12-14 - Everis
		//Inicio RIHU 30122014 - Desbloqueo de Equipo
		public static string SISACT_ValidarEquipoBloqueado
		{
			get
			{
				string p = _SISACT_PKG_DES_IMEI + ".SP_EVAL_DES_IMEI_MATE";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_ObtenerEquipoBloqueado
		{
			get
			{
				string p = _PKG_SIMLOCK + ".SP_OBTENER_SIMLOCK";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIMLOCK"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}
		//Fin RIHU 30122014 - Desbloqueo de Equipo

		public static string PKG_SISACT_REPORTE
		{
			get
			{
				string p = "SISACT_PKG_REPORTE";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_PKG_GENERAL_3PLAY
		{
			get
			{
				string p = "SISACT_PKG_GENERAL_3PLAY_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p;	
			}
		}

		public static string BD_MSSAP
		{
			get{ return _BD_MSSAP;}
		}

		public static string PKG_CONSULTA_MSSAP
		{
			get
			{
				string p = "PKG_CONSULTA";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaMSSap"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p;
			}
		}

		public static string SISACT_PKG_NUEVA_LISTAPRECIOS
		{
			get
			{
				string p = "SISACT_PKG_NUEVA_LISTAPRECIOS";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string PKG_PEDIDO
		{
			get
			{
				string p = "PKG_PEDIDO";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaMSSap"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}

		public static string SISACT_PKG_CONS_MAESTRA_SAP
		{
			get
			{
				string p = "SISACT_PKG_CONS_MAESTRA_SAP_6";							
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
                                       
		public static string SISACT_PKG_DRA_CVE
		{
			get
			{
				string p = "SISACT_PKG_DRA_CVE_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}         
        //--inicio-dga-31072015
		public static string PCK_SICAR_OFF_SAP
		{
			get
			{
				string p = "PCK_SICAR_OFF_SAP";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSICAR"];
				if(esquema != null && esquema != "") p= esquema + "." + p;
				return p;
			}
		}
		public static string PkgMSSap
		{
			get
			{
				string p = "PKG_MSSAP";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaMSSap"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		} 
    

	public static string PKG_SISACT_REPO_ACT
		{
			get
			{
				string p = "PKG_SISACT_REPO_ACT";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		
		public static string PkgMantConv
		{
			get
			{
				string p = "SISACT_PKG_MANT_CONVERGENTE_6";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if (esquema != null && esquema != "") p = esquema + "." + p;
				return p;
			}
		}
		//--fin-dga-31072015

	//ini sinergia 31072015
		public static string PKG_VENTA
		{
			get
			{
				string p = "PKG_VENTA";							
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaMSSap"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin sinergia 31072015
		public static string PKG_MATERIAL_LISTA
		{
			get
			{
				string p = "PKG_MATERIAL_LISTA";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}

		//Inicio Renovacion Por Bloqueo JAZ
		public static string TIM_SISACT_PKG_VENTA_EXPRESS_6
		{
			get
			{
				string p = "PKG_SISACT_VENTA_EXPRESS_6";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//Fin Renovacion Por Bloqueo JAZ	
		//gaa20160315 - MRAF
		public static string SISACT_PKG_VENTA_EXPRESS_6
		{
			get
			{
                string p = "PKG_SISACT_VENTA_EXPRESS_6";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaBSCS"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin gaa20160315
		//gaa20160315 - MRAF
		public static string PKG_CONSULTA_PDV
		{
			get
			{
				string p = "PKG_CONSULTA_PDV";                                                    
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSIAPDV"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		//fin gaa20160315
		//PROY-24724-IDEA-28174 - INICIO
		public static string PKG_SISACT_PKG_NUEVA_LISTAPRE_6
		{
			get
			{
				string p = "SISACT_PKG_NUEVA_LISTAPRE_6";								
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p ;
			}
		}
		
		public static string SISACT_PKG_TRANS_ASURION
		{
			get
			{
				string p = "PKG_TRANS_ASURION";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p;
			}
		}//PROY-24724-IDEA-28174 - FIN
		//SD820360 - INICIO
		public static string SISACT_PKG_MANT_LIMITE_AUT
		{
			get
			{
				string p = "PKG_MANT_LIMITE_AUT";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p;
			}
		}

			
		//SD820360 - FIN

		//PROY-32129 :: INI
		public static string PKG_SISACT_CAMPANA_ESPECIAL
		{
			get
			{
				string p = "PKG_SISACT_CAMPANA_ESPECIAL";
				string esquema = System.Configuration.ConfigurationSettings.AppSettings["EsquemaSISACT"];
				if ( esquema != null && esquema != "") p = esquema  + "." + p;
				return p;
			}
		}
		//PROY-32129 :: FIN

	}	
}
