using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for SolicitudPortabilidad.
	/// </summary>
	public class SolicitudPortabilidad
	{
		private int _CODIGO;
		private int _PK_ANSOT_ANSON_ID;
		private int _NRO_SEC;
		private int _PK_HISUT_HISUN_ID;
		private string _ANSOC_NOMBRE_ANEXO;
		private string _NRO_SP;
		private string _ANSOC_ID_SOLICITUD;
		private string _ESTADO;
		private string _ANSOV_TIPO_ANEXO;
		private string _ANSON_ESTADO_ANEXO;
		private string _MODALIDAD_CODIGO;
		private string _OPERADOR_CEDENTE_CODIGO;
		private string _TIPO_DOC;
		private string _NRO_DOC;
		private string _USUARIO;
		private string _TIPO;
		private string _ARCH_RUTA;
		private string _ADJUNTO;
		private DateTime _FECHA_REGISTRO_DATE;
		private DateTime _FECHA_RECEPCION;
		private string _FECHA_PROGRAMADA;
		private DateTime _FECHA_PROGRAMACION;
		private string _USUARIO_MODIF;
		private string _ESTADO_PROCESO_CODIGO;
		private string _ANALISTA_PORT;
		//private string _OBSERVACIONES;
		private string _TIEMPO_RESTANTE;
		private string _P_RESPUESTA;
		private string _NUM_DOCUMENTO;
		private string _ANTIGUO;
		private string _NUEVO;
				private string _TIPO_ARCHIVO;
		private string _DESC_COD_CEDENTE;

		//E75606 - Inicio
		private int _PK_SOPOT_SOPON_ID;
		private string _SOPOC_ID_SOLICITUD;
		private string _SOPOC_NUM_SECUENCIAL;
		private string _SOPOV_OBSERVACIONES;

		private ParametroPortabilidad _OPERADOR_RECEPTOR;

		private ParametroPortabilidad _OPERADOR_CEDENTE;
		private string _SOPOC_CODIGO_CEDENTE;
		
		private ParametroPortabilidad _OPERADOR_CEDENTE_INICIAL;

		private ParametroPortabilidad _TIPO_DOCUMENTO;
		private string _SOPOV_NUM_DOCUMENTO;
		private int _SOPON_CANTIDAD_NUM;
		
		private int _SOPOC_SOLIN_CODIGO;
		private int _SOPON_SOLICITUD_ID;
		
		private string _SOPOC_INICIO_RANGO;
		private string _SOPOC_FINAL_RANGO;
		
		private ParametroPortabilidad _TIPO_PORTABILIDAD;
		
		private ParametroPortabilidad _MODALIDAD;

		private ParametroPortabilidad _PROCESO;

		private string _SOPOC_MODO_ENVIO;
		private string _SOPOT_FECHA_REFEREN;
		private string _SOPOT_FECHA_LIM_PROG;
		private string _SOPOT_FECHA_LIM_EJE;
		private string _SOPOT_FECHA_EJECUCION;
		private string _SOPOT_FECHA_RECEP_ANS;
		private string _SOPOT_FECHA_LIM_MENS;
		private string _SOPOT_FECHA_MENS_ANT;
		private string _SOPOC_ID_MENS_ERRONEO;

		private ParametroPortabilidad _ESTADO_PROCESO;
		
		private string _SOPOV_MOTIVO;
		private int _SOPON_ESTADO_DESACT;
		private string _SOPOC_MOTIVO_RETORNA;
		private string _SOPOV_NOMBRE_CONTACTO;
		private string _SOPOV_CORREO_CONTACTO;
		private string _SOPOC_TELF_CONTACTO;
		private string _SOPOC_FAX_CONTACTO;
		private string _SOPOV_ANALISTA_PORTA;
		private string _SOPOT_FECHA_REGISTRO;
		private string _SOPOV_USUARIO_CREA;
		private string _SOPOT_FECHA_MODIFICA;

		private AcuerdoPortIN _PORTT_ACUERDOS_PORTIN;

		private string _SOPOV_idOSM;
		private string _SOPOV_TIPO_MENSAJE;

		//E75606 - Fin

		private string _SOPON_SOLIN_CODIGO;
		private string _SOPOV_NOM_RASO_ABONAD;
		private string _SOPOC_MODALIDAD;
		private string _DESC_MODALIDAD;
		private string _SOPOC_TIPO_DOCUMENTO;
		private string _DESC_TIPO_DOC;
		private string _SOPOC_CODIGO_CENDENTE;
		private string _DESC_COD_CENDENTE;
		private string _SOPOC_ESTA_PROCESO;
		private string _PARAV_DESCRIPCION;
		private string _IDENTIFICADOR_MENSAJE;
		private string _FECHA_REGISTRO_IDEN;
	
		private string _ESTADO_PROCESO_DESCRIPCION;
		private string _PLAN_DESCRIPCION;
		private string _ARCH_NOMBRE;

		private string _MOTIVO_RECHAZO;
		private string _ANTIGUO_D;
		private string _NUEVO_D;
		private string _ANTIGUO_F;
		private string _NUEVO_F;
		private string _ANTIGUO_P;
		private string _NUEVO_P;
		private string _SOPOC_ICCID; //T13087
		private int _Flag_P;

		public int Flag_P
		{
			set{ _Flag_P = value;}
			get{ return _Flag_P;}
		}

		private string _TIPO_VENTA;
		private string _DES_OFICINA_VENTA;
		private string _TELEFONO_CONT_CLI;

		private string _SOLIN_USU_VEN;

		public string _MOTIVO_OBJECION;
		public string MOTIVO_OBJECION
		{
			set{ _MOTIVO_OBJECION = value;}
			get{ return _MOTIVO_OBJECION;}
		}

		public string SOLIN_USU_VEN
		{
			set{ _SOLIN_USU_VEN = value;}
			get{ return _SOLIN_USU_VEN;}
		}
		//E75686 inicio

		// T12618 - INICIO
		private string _FLAG_VENDIDO;
		public string FLAG_VENDIDO
		{
			set{ _FLAG_VENDIDO = value;}
			get{ return _FLAG_VENDIDO;}
		}
		
		private string _FLAG_RECIBO_CEDENTE;
		public string FLAG_RECIBO_CEDENTE
		{
			set{ _FLAG_RECIBO_CEDENTE = value;}
			get{ return _FLAG_RECIBO_CEDENTE;}
		}
		// T12618 - FIN
		
		private string _CONTROL;

		public string CONTROL
		{
			set{_CONTROL= value;}
			get{return _CONTROL;}
		}
		public string ARCH_NOMBRE
		{
			set{_ARCH_NOMBRE= value;}
			get{return _ARCH_NOMBRE;}
		}
		private string _CONTADOR;

		public string CONTADOR
		{
			set{_CONTADOR= value;}
			get{return _CONTADOR;}
		}

		//E75686 fin
		public string TIPO_VENTA
		{
			set{_TIPO_VENTA= value;}
			get{return _TIPO_VENTA;}
		}
		public string DES_OFICINA_VENTA
		{
			set{_DES_OFICINA_VENTA= value;}
			get{return _DES_OFICINA_VENTA;}
		}
		public string TELEFONO_CONT_CLI
		{
			set{_TELEFONO_CONT_CLI= value;}
			get{return _TELEFONO_CONT_CLI;}
		}

		public SolicitudPortabilidad() 
		{
			//E75606 - Inicio
			// Inicializar los Atributos con Referencias a otras Entidades
			_OPERADOR_RECEPTOR = new ParametroPortabilidad();
			_OPERADOR_RECEPTOR.PK_PARAT_PARAC_TP = "CO";

			_OPERADOR_CEDENTE = new ParametroPortabilidad();
			_OPERADOR_CEDENTE.PK_PARAT_PARAC_TP = "CO";

			_OPERADOR_CEDENTE_INICIAL = new ParametroPortabilidad();
			_OPERADOR_CEDENTE_INICIAL.PK_PARAT_PARAC_TP = "CO";
			
			_TIPO_DOCUMENTO = new ParametroPortabilidad();
			_TIPO_DOCUMENTO.PK_PARAT_PARAC_TP = "TD";

			_TIPO_PORTABILIDAD = new ParametroPortabilidad();
			_TIPO_PORTABILIDAD.PK_PARAT_PARAC_TP = "TP";

			_MODALIDAD = new ParametroPortabilidad();
			_MODALIDAD.PK_PARAT_PARAC_TP = "MO";

			_PROCESO = new ParametroPortabilidad();
			_PROCESO.PK_PARAT_PARAC_TP = "CP";

			_ESTADO_PROCESO = new ParametroPortabilidad();
			_ESTADO_PROCESO.PK_PARAT_PARAC_TP = "EP";

			_PORTT_ACUERDOS_PORTIN = new AcuerdoPortIN();
			//E75606 -Fin
		}

		public int CODIGO
		{
			set{_CODIGO= value;}
			get{return _CODIGO;}
		}
		public int NRO_SEC
		{
			set{_NRO_SEC= value;}
			get{return _NRO_SEC;}
		}
		public string NRO_SP
		{
			set{_NRO_SP= value;}
			get{return _NRO_SP;}
		}

		public string ESTADO
		{
			set{_ESTADO= value;}
			get{return _ESTADO;}
		}
		public string ARCH_RUTA
		{
			set{_ARCH_RUTA= value;}
			get{return _ARCH_RUTA;}
		}
		
		public string DESC_COD_CEDENTE
		{
			set{_DESC_COD_CEDENTE= value;}
			get{return _DESC_COD_CEDENTE;}
		}

		public string SOPON_SOLIN_CODIGO
		{
			set{_SOPON_SOLIN_CODIGO= value;}
			get{return _SOPON_SOLIN_CODIGO;}
		}
	

		public string SOPOC_MODALIDAD
		{
			set{_SOPOC_MODALIDAD= value;}
			get{return _SOPOC_MODALIDAD;}
		}
		public string DESC_MODALIDAD
		{
			set{_DESC_MODALIDAD= value;}
			get{return _DESC_MODALIDAD;}
		}
		public string SOPOC_CODIGO_CEDENTE
		{
			set{_SOPOC_CODIGO_CEDENTE= value;}
			get{return _SOPOC_CODIGO_CEDENTE;}
		}
		public string SOPOC_TIPO_DOCUMENTO
		{
			set{_SOPOC_TIPO_DOCUMENTO= value;}
			get{return _SOPOC_TIPO_DOCUMENTO;}
		}
		public string DESC_TIPO_DOC
		{
			set{_DESC_TIPO_DOC= value;}
			get{return _DESC_TIPO_DOC;}
		}
		
		public string SOPOC_CODIGO_CENDENTE
		{
			set{_SOPOC_CODIGO_CENDENTE= value;}
			get{return _SOPOC_CODIGO_CENDENTE;}
		}
		public string DESC_COD_CENDENTE
		{
			set{_DESC_COD_CENDENTE= value;}
			get{return _DESC_COD_CENDENTE;}
		}
		public string TIPO
		{
			set{_TIPO= value;}
			get{return _TIPO;}
		}
		public string SOPOC_ESTA_PROCESO
		{
			set{_SOPOC_ESTA_PROCESO= value;}
			get{return _SOPOC_ESTA_PROCESO;}
		}
		public string PARAV_DESCRIPCION
		{
			set{_PARAV_DESCRIPCION= value;}
			get{return _PARAV_DESCRIPCION;}
		}

		public string TIPO_ARCHIVO
		 {
			 set{_TIPO_ARCHIVO= value;}
			 get{return _TIPO_ARCHIVO;}
		 }

		public string MODALIDAD
		{
			set{_MODALIDAD_CODIGO = value;}
			get{return _MODALIDAD_CODIGO;}
		}
		public string OPERADOR_CEDENTE
		{
			set{_OPERADOR_CEDENTE_CODIGO= value;}
			get{return _OPERADOR_CEDENTE_CODIGO;}
		}
		public string TIPO_DOC
		{
			set{_TIPO_DOC= value;}
			get{return _TIPO_DOC;}
		}
		public string NRO_DOC
		{
			set{_NRO_DOC= value;}
			get{return _NRO_DOC;}
		}
		public string USUARIO
		{
			set{_USUARIO= value;}
			get{return _USUARIO;}
		}
		public string ADJUNTO
		{
			set{_ADJUNTO= value;}
			get{return _ADJUNTO;}
		}
		public string USUARIO_MODIF
		{
			set{_USUARIO_MODIF= value;}
			get{return _USUARIO_MODIF;}
		}
		
		public string ESTADO_PROCESO
		{
			set{_ESTADO_PROCESO_CODIGO = value;}
			get{return _ESTADO_PROCESO_CODIGO;}
		}
		public string ANALISTA_PORT
		{
			set{_ANALISTA_PORT= value;}
			get{return _ANALISTA_PORT;}
		}
		public string TIEMPO_RESTANTE
		{
			set{_TIEMPO_RESTANTE= value;}
			get{return _TIEMPO_RESTANTE;}
		}
		public DateTime FECHA_REGISTRO
		{
			set{_FECHA_REGISTRO_DATE= value;}
			get{return _FECHA_REGISTRO_DATE;}
		}
		public DateTime FECHA_PROGRAMACION
		{
			set{_FECHA_PROGRAMACION= value;}
			get{return _FECHA_PROGRAMACION;}
		}
		public DateTime FECHA_RECEPCION
		{
			set{_FECHA_RECEPCION= value;}
			get{return _FECHA_RECEPCION;}
		}
		public string ANTIGUO
		{
			set{_ANTIGUO= value;}
			get{return _ANTIGUO;}
		}
		public string NUEVO
		{
			set{_NUEVO= value;}
			get{return _NUEVO;}
		}
		public string IDENTIFICADOR_MENSAJE
		{
			set{_IDENTIFICADOR_MENSAJE= value;}
			get{return _IDENTIFICADOR_MENSAJE;}
		}
		public string FECHA_REGISTRO_IDEN
		{
			set{_FECHA_REGISTRO_IDEN= value;}
			get{return _FECHA_REGISTRO_IDEN;}
		}
		public string ESTADO_PROCESO_DESC
		{
			set{_ESTADO_PROCESO_DESCRIPCION= value;}
			get{return _ESTADO_PROCESO_DESCRIPCION;}
		}
		public string PLAN_DESCRIPCION
		{
			set{_PLAN_DESCRIPCION= value;}
			get{return _PLAN_DESCRIPCION;}
		}
		public string P_RESPUESTA
		{
			set{_P_RESPUESTA= value;}
			get{return _P_RESPUESTA;}
		}

		
		//E75606 - Inicio
			public int PK_ANSOT_ANSON_ID
			{
				set { _PK_ANSOT_ANSON_ID = value; }
				get { return _PK_ANSOT_ANSON_ID; }
			}
			public int PK_SOPOT_SOPON_ID
			{
				set { _PK_SOPOT_SOPON_ID = value; }
				get { return _PK_SOPOT_SOPON_ID; }
			}
		public string ID_SOLICITUD
		{
			set { _SOPOC_ID_SOLICITUD = value; }
			get { return _SOPOC_ID_SOLICITUD; }
		}
		public string SOPOC_ID_SOLICITUD
		{
			set { _SOPOC_ID_SOLICITUD = value; }
			get { return _SOPOC_ID_SOLICITUD; }
		}
		public string NUM_SECUENCIAL
		{
			set { _SOPOC_NUM_SECUENCIAL = value; }
			get { return _SOPOC_NUM_SECUENCIAL; }
		}
		public string SOPOC_NUM_SECUENCIAL
		{
			set { _SOPOC_NUM_SECUENCIAL = value; }
			get { return _SOPOC_NUM_SECUENCIAL; }
		}
		public string OBSERVACIONES
		{
			set { _SOPOV_OBSERVACIONES = value; }
			get { return _SOPOV_OBSERVACIONES; }
		}
		public ParametroPortabilidad OPERADOR_RECEPTOR
		{
			set { _OPERADOR_RECEPTOR = value; }
			get { return _OPERADOR_RECEPTOR; }
		}
		public ParametroPortabilidad OPERADOR_CEDENTE2
		{
			set { _OPERADOR_CEDENTE = value; }
			get { return _OPERADOR_CEDENTE; }
		}
		public ParametroPortabilidad OPERADOR_CEDENTE_INICIAL
		{
			set { _OPERADOR_CEDENTE_INICIAL = value; }
			get { return _OPERADOR_CEDENTE_INICIAL; }
		}
		public ParametroPortabilidad TIPO_DOCUMENTO
		{
			set { _TIPO_DOCUMENTO = value; }
			get { return _TIPO_DOCUMENTO; }
		}
		public string SOPOV_NUM_DOCUMENTO
		{
			set { _SOPOV_NUM_DOCUMENTO = value; }
			get { return _SOPOV_NUM_DOCUMENTO; }
		}
		public string NUM_DOCUMENTO
		{
			set { _NUM_DOCUMENTO = value; }
			get { return _NUM_DOCUMENTO; }
		}
		public int CANTIDAD_NUM
		{
			set { _SOPON_CANTIDAD_NUM = value; }
			get { return _SOPON_CANTIDAD_NUM; }
		}
		public int SOLIN_CODIGO
		{
			set { _SOPOC_SOLIN_CODIGO = value; }
			get { return _SOPOC_SOLIN_CODIGO; }
		}
		public int SOLICITUD_ID_PVU
		{
			set { _SOPON_SOLICITUD_ID = value; }
			get { return _SOPON_SOLICITUD_ID; }
		}
		public string INICIO_RANGO
		{
			set { _SOPOC_INICIO_RANGO = value; }
			get { return _SOPOC_INICIO_RANGO; }
		}
		public string SOPOC_INICIO_RANGO
		{
			set { _SOPOC_INICIO_RANGO = value; }
			get { return _SOPOC_INICIO_RANGO; }
		}
		public string FINAL_RANGO
		{
			set { _SOPOC_FINAL_RANGO = value; }
			get { return _SOPOC_FINAL_RANGO; }
		}
		public string SOPOV_NOM_RASO_ABONAD
		{
			set { _SOPOV_NOM_RASO_ABONAD = value; }
			get { return _SOPOV_NOM_RASO_ABONAD; }
		}
		public string NOM_RASO_ABONAD
		{
			set { _SOPOV_NOM_RASO_ABONAD = value; }
			get { return _SOPOV_NOM_RASO_ABONAD; }
		}
		public ParametroPortabilidad TIPO_PORTABILIDAD
		{
			set { _TIPO_PORTABILIDAD = value; }
			get { return _TIPO_PORTABILIDAD; }
		}
		public ParametroPortabilidad MODALIDAD2
		{
			set { _MODALIDAD = value; }
			get { return _MODALIDAD; }
		}
		public ParametroPortabilidad PROCESO
		{
			set { _PROCESO = value; }
			get { return _PROCESO; }
		}
		public string MODO_ENVIO
		{
			set { _SOPOC_MODO_ENVIO = value; }
			get { return _SOPOC_MODO_ENVIO; }
		}
		public string FECHA_REFEREN
		{
			set { _SOPOT_FECHA_REFEREN = value; }
			get { return _SOPOT_FECHA_REFEREN; }
		}
		public string FECHA_LIM_PROG
		{
			set { _SOPOT_FECHA_LIM_PROG = value; }
			get { return _SOPOT_FECHA_LIM_PROG; }
		}
		public string SOPOT_FECHA_LIM_PROG
		{
			set { _SOPOT_FECHA_LIM_PROG = value; }
			get { return _SOPOT_FECHA_LIM_PROG; }
		}
		public string FECHA_LIM_EJE
		{
			set { _SOPOT_FECHA_LIM_EJE = value; }
			get { return _SOPOT_FECHA_LIM_EJE; }
		}
		public string SOPOT_FECHA_LIM_EJE
		{
			set { _SOPOT_FECHA_LIM_EJE = value; }
			get { return _SOPOT_FECHA_LIM_EJE; }
		}

		public string FECHA_PROGRAMADA
		{
			set { _FECHA_PROGRAMADA = value; }
			get { return _FECHA_PROGRAMADA; }
		}
		public string FECHA_EJECUCION
		{
			set { _SOPOT_FECHA_EJECUCION = value; }
			get { return _SOPOT_FECHA_EJECUCION; }
		}
		public string FECHA_RECEP_ANS
		{
			set { _SOPOT_FECHA_RECEP_ANS = value; }
			get { return _SOPOT_FECHA_RECEP_ANS; }
		}
		public string SOPOT_FECHA_LIM_MENS
		{
			set { _SOPOT_FECHA_LIM_MENS = value; }
			get { return _SOPOT_FECHA_LIM_MENS; }
		}
		public string SOPOT_FECHA_MENS_ANT
		{
			set { _SOPOT_FECHA_MENS_ANT = value; }
			get { return _SOPOT_FECHA_MENS_ANT; }
		}
		public string SOPOC_ID_MENS_ERRONEO
		{
			set { _SOPOC_ID_MENS_ERRONEO = value; }
			get { return _SOPOC_ID_MENS_ERRONEO; }
		}
		public ParametroPortabilidad ESTADO_PROCESO2
		{
			set { _ESTADO_PROCESO = value; }
			get { return _ESTADO_PROCESO; }
		}
		public string SOPOV_MOTIVO
		{
			set { _SOPOV_MOTIVO = value; }
			get { return _SOPOV_MOTIVO; }
		}
		public int ESTADO_DESACT
		{
			set { _SOPON_ESTADO_DESACT = value; }
			get { return _SOPON_ESTADO_DESACT; }
		}
		public string NOMBRE_CONTACTO
		{
			set { _SOPOV_NOMBRE_CONTACTO = value; }
			get { return _SOPOV_NOMBRE_CONTACTO; }
		}
		public string SOPOV_NOMBRE_CONTACTO
		{
			set { _SOPOV_NOMBRE_CONTACTO = value; }
			get { return _SOPOV_NOMBRE_CONTACTO; }
		}
		public string SOPOV_CORREO_CONTACTO
		{
			set { _SOPOV_CORREO_CONTACTO = value; }
			get { return _SOPOV_CORREO_CONTACTO; }
		}
		public string CORREO_CONTACTO
		{
			set { _SOPOV_CORREO_CONTACTO = value; }
			get { return _SOPOV_CORREO_CONTACTO; }
		}
		public string SOPOC_TELF_CONTACTO
		{
			set { _SOPOC_TELF_CONTACTO = value; }
			get { return _SOPOC_TELF_CONTACTO; }
		}
		public string TELF_CONTACTO
		{
			set { _SOPOC_TELF_CONTACTO = value; }
			get { return _SOPOC_TELF_CONTACTO; }
		}
		public string FAX_CONTACTO
		{
			set { _SOPOC_FAX_CONTACTO = value; }
			get { return _SOPOC_FAX_CONTACTO; }
		}
		public string SOPOC_FAX_CONTACTO
		{
			set { _SOPOC_FAX_CONTACTO = value; }
			get { return _SOPOC_FAX_CONTACTO; }
		}
		public string ANALISTA_PORTA
		{
			set { _SOPOV_ANALISTA_PORTA = value; }
			get { return _SOPOV_ANALISTA_PORTA; }
		}
		public string USUARIO_CREA
		{
			set { _SOPOV_USUARIO_CREA = value; }
			get { return _SOPOV_USUARIO_CREA; }
		}
		public string FECHA_MODIFICA
		{
			set { _SOPOT_FECHA_MODIFICA = value; }
			get { return _SOPOT_FECHA_MODIFICA; }
		}
		public string SOPOT_FECHA_MODIFICA
		{
			set { _SOPOT_FECHA_MODIFICA = value; }
			get { return _SOPOT_FECHA_MODIFICA; }
		}
		
		public string MOTIVO_RETORNA
		{
			set { _SOPOC_MOTIVO_RETORNA = value; }
			get { return _SOPOC_MOTIVO_RETORNA; }
		}
		public string FECHA_REGISTRO2
		{
			set { _SOPOT_FECHA_REGISTRO = value; }
			get { return _SOPOT_FECHA_REGISTRO; }
		}
		public AcuerdoPortIN ACUERDO_PORTIN
		{
			set { _PORTT_ACUERDOS_PORTIN = value; }
			get { return _PORTT_ACUERDOS_PORTIN; }
		}
		public string SOPOV_idOSM
		{
			set { _SOPOV_idOSM = value; }
			get { return _SOPOV_idOSM; }
		}
		public string SOPOV_TIPO_MENSAJE
		{
			set { _SOPOV_TIPO_MENSAJE = value; }
			get { return _SOPOV_TIPO_MENSAJE; }
		}

		public string MOTIVO_RECHAZO
		{
			set{_MOTIVO_RECHAZO= value;}
			get{return _MOTIVO_RECHAZO;}
		}
		public string ANTIGUO_D
		{
			set{_ANTIGUO_D= value;}
			get{return _ANTIGUO_D;}
		}
		public string NUEVO_D
		{
			set{_NUEVO_D= value;}
			get{return _NUEVO_D;}
		}
		public string ANTIGUO_F
		{
			set{_ANTIGUO_F= value;}
			get{return _ANTIGUO_F;}
		}
		public string NUEVO_F
		{
			set{_NUEVO_F= value;}
			get{return _NUEVO_F;}
		}
		public string ANTIGUO_P
		{
			set{_ANTIGUO_P= value;}
			get{return _ANTIGUO_P;}
		}
		public string NUEVO_P
		{
			set{_NUEVO_P= value;}
			get{return _NUEVO_P;}
		}
		public string ANSOC_ID_SOLICITUD
		{
			set{_ANSOC_ID_SOLICITUD= value;}
			get{return _ANSOC_ID_SOLICITUD;}
		}
		public string ANSOC_NOMBRE_ANEXO
		{
			set{_ANSOC_NOMBRE_ANEXO= value;}
			get{return _ANSOC_NOMBRE_ANEXO;}
		}
		public string ANSOV_TIPO_ANEXO
		{
			set{_ANSOV_TIPO_ANEXO= value;}
			get{return _ANSOV_TIPO_ANEXO;}
		}
		public string ANSON_ESTADO_ANEXO
		{
			set{_ANSON_ESTADO_ANEXO= value;}
			get{return _ANSON_ESTADO_ANEXO;}
		}
		
		public int PK_HISUT_HISUN_ID
		{
			set{_PK_HISUT_HISUN_ID= value;}
			get{return _PK_HISUT_HISUN_ID;}
		}
		//E75606 - Fin

		public string SOPOC_ICCID
		{
			set{_SOPOC_ICCID= value;}
			get{return _SOPOC_ICCID;}
		}
	}
}
