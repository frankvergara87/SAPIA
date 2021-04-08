using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de SolicitudPersona.
	/// </summary>
	public class SolicitudPersona
	{
		private Int64 _SOLIN_CODIGO;
		private string _CANAC_CODIGO;
		private string _CANAV_DESCRIPCION;
		private string _TPROC_CODIGO;
		private string _TPROV_DESCRIPCION;
		private string _OVENC_CODIGO;
		private string _OVENV_DESCRIPCION;
		private string _TCESC_CODIGO;
		private string _TCESC_DESCRIPCION;
		private string _TDOCC_CODIGO;
		private string _TDOCV_DESCRIPCION;
		private string _CLIEC_NUM_DOC;
		private string _CLIEV_NOMBRE;
		private string _CLIEV_APE_PAT;
		private string _CLIEV_APE_MAT;
		private string _TACTC_CODIGO;
		private string _TACTV_DESCRIPCION;
		private string _TVENC_CODIGO;
		private string _TVENV_DESCRIPCION;
		private string _FPAGC_CODIGO;
		private string _FPAGV_DESCRIPCION;
		private string _PACUC_CODIGO;
		private string _PACUV_DESCRIPCION;
		private string _SOLIC_PLA_TAR_1;
		private string _SOLIC_PLA_TAR_2;
		private string _SOLIC_PLA_TAR_3;
		private string _SOLIC_EXI_BSC_FIN;
		private string _TOFIV_DESCRIPCION;
		private string _SOLIC_TIP_CAR_FIJ;
		private string _SOLIN_NUM_CAR_FIJ;
		private string _SOLIN_NRO_PLANES_PER;
		private string _SOLIC_COD_PLAN_MAX;
		private string _RDIRV_DESCRIPCION;
		private string _SOLIN_IMP_DG;
		private string _TIPO_GARANTIA_DES;
		private string _TCARV_DESCRIPCION;
		private string _SOLIV_MEN_PRE;
		private string _CCLIC_CODIGO;
		private string _SOLIC_EVA_SUN;

		private string _CLIEV_PRE_DIR;
		private string _CLIEV_DIRECCION;
		private string _CLIEV_REF_DIR;
		private string _CLIEC_COD_DEP_DIR;
		private string _DEPAV_DESCRIPCION;
		private string _CLIEC_COD_PRO_DIR;
		private string _PROVV_DESCRIPCION;
		private string _CLIEC_COD_DIS_DIR;
		private string _DISTV_DESCRIPCION;
		private string _CLIEC_COD_POS_DIR;
		private string _CLIEV_TEL_LEG;
		private string _CLIEV_PRE_DIR_TRA;
		private string _CLIEV_DIR_TRA;
		private string _CLIEV_REF_DIR_TRA;
		private string _CLIEC_COD_DEP_TRA;
		private string _DEPAV_DESCRIPCION_TRA;
		private string _CLIEC_COD_PRO_TRA;
		private string _PROVV_DESCRIPCION_TRA;
		private string _CLIEC_COD_DIS_TRA;
		private string _DISTV_DESCRIPCION_TRA;
		private string _CLIEC_COD_POS_TRA;

		private string _CLIEV_PRE_DIR_FAC;
		private string _CLIEV_DIR_FAC;
		private string _CLIEV_REF_DIR_FAC;
		private string _CLIEC_COD_DEP_FAC;
		private string _DEPAV_DESCRIPCION_FAC;
		private string _CLIEC_COD_PRO_FAC;
		private string _PROVV_DESCRIPCION_FAC;
		private string _CLIEC_COD_DIS_FAC;
		private string _DISTV_DESCRIPCION_FAC;
		private string _CLIEC_COD_POS_FAC;
		private string _CLIEV_PER_REF_1;
		

		private string _CLIEV_TEL_FIJ_TRA;
		private string _CLIEV_TEL_REF_1;
		private string _CLIEV_TEL_REF_2;

		private string _CONSULTOR_CODIGO;
		private string _CONSULTOR_NOMBRE;
		
		private DateTime _SOLID_FEC_REG;

		private string _SOLIN_CAN_LIN;
		private string _USUAV_NOMBRE;
		private string _TAFIV_DESCRIPCION;
		private string _SOLIV_NUM_TAR;
		private string _SOLIV_NOM_TIT_TAR;
		private string _SOLIV_DOC_TIT_TAR;
		private string _SOLIV_FEC_VEN_TAR;
		private string _ENTIV_DESCRIPCION;
		private string _TARJV_DESCRIPCION;
		private string _TMONV_DESCRIPCION;
		
		private string _SOLIN_MNTOMAX;

		//<CAA>		
		private string _SOLIV_DES_TIP_ACT; // tipo activacion des
		private string _SEGMV_DESCRIPCION;
		private string _ESTAV_DESCRIPCION;
		private string _CLIEV_RAZ_SOC;
		private string _ESTAC_CODIGO;
		private string _SOLIC_FLA_TER;
		private string _TEVAC_CODIGO;
		private string _ANALV_DESCRIPCION;
		private double _CLIEN_CAP_SOC;
		private string _PLANV_DESCRIPCION1;
		private string _PLANV_DESCRIPCION2;
		private string _PLANV_DESCRIPCION3;
		private string _RFINC_CODIGO;
		private string _RFINV_DESCRIPCION;
		private double _SOLIN_IMP_DG_MAN;
		private string _MRECV_DESCRIPCION;
		private string _TAFIC_CODIGO;
		private string _SOLIC_COD_TAR;
		private string _SOLIC_COD_TIP_MON;
		private string _SOLIV_NUM_OPE_CON;
		private double _SOLIN_LIM_CRE_CON;
		private double _SOLIN_LIM_CRE_FIN;
		private string _SOLIC_SCO_TXT_FIN;
		private double _SOLIN_SCO_NUM_FIN;
		private double _SOLIN_LIM_MAX_FIN;
		private string _SOLIC_POSTCONTROL;
		private string _CCLIV_DESCRIPCION;
		private string _SOLIC_EVA_ESS;
		private string _CLIEV_PRE_TEL_LEG;
		private string _DESCRIPCION_TELEFONO_LEGAL;
		private string _CLIEV_PER_REF1;
		private string _CLIEV_PER_REF2;
		private string _CLIEV_PER_CON_TRA;
		private string _DEPAV_DESCRIPCION_LEGAL;
		private string _PROVV_DESCRIPCION_LEGAL;
		private string _DISTV_DESCRIPCION_LEGAL;
		private string _DEPAV_DESCRIPCION_FACTURACION;
		private string _PROVV_DESCRIPCION_FACTURACION;
		private string _DISTV_DESCRIPCION_FACTURACION;
		private string _DEPAV_DESCRIPCION_TRABAJO;
		private string _PROVV_DESCRIPCION_TRABAJO;
		private string _DISTV_DESCRIPCION_TRABAJO;
		private string _PLANC_CODIGO1;
		private string _PLANC_CODIGO2;
		private string _PLANC_CODIGO3;
		private double _PLANN_CAR_FIJ1;
		private double _PLANN_CAR_FIJ2;
		private double _PLANN_CAR_FIJ3;
		private string _RDIRC_CODIGO;
		private string _SOLIV_RES_EXP_CON;
		private string _SOLIC_SCO_TXT_CON;
		private double _SOLIN_SCO_NUM_CON;
		private double _SOLIN_SUM_CAR_CON;
		private string _SOLIV_RUC_EMP_SUS;
		private string _SOLIV_EMP_SUS;
		private string _MRDIV_CAD_CODIGO;

		private DateTime _FECHA_NACIMIENTO;
		private string _TITULO_PERSONA_ID;
		private string _TITULO_PERSONA_DES;
		private string _SEXO;
		private string _ESTADO_CIVIL_ID;
		private string _ESTADO_CIVIL_DES;
		private string _TELEFONO_CASA;		
		private string _MENSAJE;
		private string _ESTADOESSALUDSUNAT;
		private string _ESTADODES;
		private Int64 _SOLIN_GRUPO_SEC;
		private string _PRDC_CODIGO;
		private string _COMEV_COMENTARIO;
		private string _NUMERO_LINEA;

		//JEP - TeamSoft
		private string _EstadoDeVentaDeDocumentoSEC;

		//</CAA>

		//E72373 - TeamSoft (INICIO)
		private string _SOLIV_COM_PUN_VEN;
		private string _SOLIV_COM_EVAL;
		private string _SOLIV_NUM_OPE_FIN;
		private double _SOLIN_ING_SUS;
		private string _RIEV_DESCRIPCION;
		private double _SOLIN_IMP_RA;
		private double _SOLIN_NUM_CAR_FIJ_ADI;
		private string _TCARC_CODIGO;
		private double _SOLIN_NUM_RA;
		private string _SOLIC_TIP_CAR_MAN;
		//E72373 - TeamSoft (FIN)

		//E75638 - COSAPISOFT (INICIO)
		private string _PDIRV_DESCRIPCION_LEGAL;
		private string _PDIRV_DESCRIPCION_FACTURACION;
		private string _PDIRV_DESCRIPCION_TRABAJO;
		private string _SOLIN_USU_VEN;
		//E75638 - COSAPISOFT (FIN)

                //E75606 - COSAPISOFT (INICIO)
		private string _DCREV_NUM_OPERACION;
		private string _DCREV_TIPO_RESPUESTA;
		private string _DCREV_TIPO_RESP_DESC;
		private string _DCREC_VALIDAR_CLIENTE;
		//E75606 - COSAPISOFT (FIN)

		//E72373 - TeamSoft (INICIO)
		private string _SOLIC_FLAG_CONSUMO;		
		//E72373 - TeamSoft (FIN)

		//E75606 - (VENTA EXPRESS INICIO)
		private string _TCLIC_CODIGO;
		private string _TOPEN_CODIGO;
		//E75606 - (VENTA EXPRESS FIN)
        
                	//T12618 - Portabilidad - INICIO
		private string _OPERADOR_CEDENTE;
		private string _ESTADO_PORTABILIDAD;
		private string _FLAG_PORTABILIDAD;
		//T12618 - Portabilidad - FIN

		//E75606 - (EXPRESS PORTABILIDAD INICIO)
		private string _OPERADOR_CEDENTE_DESC;
		private string _ESTADO_PORTABILIDAD_DESC;
		//E75606 - (EXPRESS PORTABILIDAD FIN)

		//INICIO "E75688"
		private string _FLAG_CORREO;
		private string _SOLIV_CORREO;
		private string _SOLIV_TEL_SMS;		
		//FIN

		//INICIO ub
		private string _PLANC_TIPOMP_1;
		private string _PLANC_TIPOMP_2;
		private string _PLANC_TIPOMP_3;
		//FIN UB

		public SolicitudPersona(){}
		
		//E72373 - TeamSoft (INICIO)
		public string SOLIC_FLAG_CONSUMO 
		{
			get{ return _SOLIC_FLAG_CONSUMO;}
			set{ _SOLIC_FLAG_CONSUMO = value; }
		}
		//E72373 - TeamSoft (FIN)

		//E72373 - TeamSoft (INICIO)

		//Renovacion
		private string _BURO_DESCRIPCION;
		private string _FLAG_REINGRESO_SEC = "";
		private string _CLIEC_BLOQUEO="";
		private double _CLIEN_MONTO_VENCIDO =0;
		private string _CREDV_OBS_FLEXIBILIZACION;
		private DateTime _FECHA_NACIMIENTO_PDV;
		private string _PRDV_DESCRIPCION;
		private string _TPROD_COMERCIALIZAR="";
		private double _SOLIN_COST_INST = 0;
		private double _SOLIN_CF_MAYORES = 0;
		private double _SOLIN_CF_MENORES = 0;
		private double _SOLIN_LC_DISPONIBLE = 0;
		private string _DEPAV_DESCRIPCION_DC="";
		private string _PROVV_DESCRIPCION_DC="";
		private int _SOLIN_PUNTAJE_DC=0;
		private string _SOLIC_ANALISIS_DC="";
		private string _SOLIC_SCORE_RANKING_OPER_DC="";
		private string _SOLIC_ORIGEN_LC_DC="";
		private double _SOLIN_LC_BASE_EXTERNA_DC=0;
		private double _SOLIN_LC_CLARO_DC=0;
		private string _CLIEV_CALIFICACION_PAGO;
		private double _SOLIN_LC_DATA_CREDITO_DC=0;
		private string _SOLIC_EVA_ESS_INI="";	
		private string _ID_VENTA_DTH = "";
		private string _TOPEV_DESCRIPCION;
		private string _SOLIC_EVA_SUN_INI="";

		//Renovacion
		private string _SOLIV_DES_EST;
		private string _SOLIV_NUM_CON;
		private string _CAMPV_CODIGO;


		public string SOLIC_TIP_CAR_MAN 
		{
			get{ return _SOLIC_TIP_CAR_MAN;}
			set{ _SOLIC_TIP_CAR_MAN = value; }
		}

		public double SOLIN_NUM_RA
		{
			get{ return _SOLIN_NUM_RA;}
			set{ _SOLIN_NUM_RA = value; }
		}

		public string TCARC_CODIGO 
		{
			get{ return _TCARC_CODIGO;}
			set{ _TCARC_CODIGO = value; }
		}

		public double SOLIN_IMP_RA 
		{
			get{ return _SOLIN_IMP_RA;}
			set{ _SOLIN_IMP_RA = value; }
		}

		public string RIEV_DESCRIPCION 
		{
			get{ return _RIEV_DESCRIPCION;}
			set{ _RIEV_DESCRIPCION = value; }
		}

		public string SOLIV_COM_PUN_VEN 
		{
			get{ return _SOLIV_COM_PUN_VEN;}
			set{ _SOLIV_COM_PUN_VEN = value; }
		}

		public string SOLIV_COM_EVAL 
		{
			get{ return _SOLIV_COM_EVAL;}
			set{ _SOLIV_COM_EVAL = value; }
		}

		public string SOLIV_NUM_OPE_FIN 
		{
			get{ return _SOLIV_NUM_OPE_FIN;}
			set{ _SOLIV_NUM_OPE_FIN = value; }
		}

		public double SOLIN_ING_SUS 
		{
			get{ return _SOLIN_ING_SUS;}
			set{ _SOLIN_ING_SUS = value; }
		}

		public double SOLIN_NUM_CAR_FIJ_ADI 
		{
			get{ return _SOLIN_NUM_CAR_FIJ_ADI;}
			set{ _SOLIN_NUM_CAR_FIJ_ADI = value; }
		}
		//E72373 - TeamSoft (Fin)

		public string EstadoDeVentaDeDocumentoSEC 
		{
			get{ return _EstadoDeVentaDeDocumentoSEC;}
			set{ _EstadoDeVentaDeDocumentoSEC = value; }
		}

		public String COMEV_COMENTARIO 
		{
			get{ return _COMEV_COMENTARIO;}
			set{ 	 _COMEV_COMENTARIO = value; }
		}

		public Int64 SOLIN_CODIGO 
		{
			get{ return _SOLIN_CODIGO;}
			set{ 	 _SOLIN_CODIGO = value; }
		}
		public DateTime SOLID_FEC_REG 
		{
			get{ return _SOLID_FEC_REG;}
			set{ 	 _SOLID_FEC_REG = value; }
		}

		public string CANAC_CODIGO 
		{
			get{ return _CANAC_CODIGO;}
			set{ 	 _CANAC_CODIGO = value; }
		}
		public string CANAV_DESCRIPCION 
		{
			get{ return _CANAV_DESCRIPCION;}
			set{ 	 _CANAV_DESCRIPCION = value; }
		}
		public string TPROC_CODIGO 
		{
			get{ return _TPROC_CODIGO;}
			set{ 	 _TPROC_CODIGO = value; }
		}
		public string TPROV_DESCRIPCION 
		{
			get{ return _TPROV_DESCRIPCION;}
			set{ 	 _TPROV_DESCRIPCION = value; }
		}
		public string OVENC_CODIGO 
		{
			get{ return _OVENC_CODIGO;}
			set{ 	 _OVENC_CODIGO = value; }
		}
		public string OVENV_DESCRIPCION 
		{
			get{ return _OVENV_DESCRIPCION;}
			set{ 	 _OVENV_DESCRIPCION = value; }
		}
		public string TCESC_CODIGO 
		{
			get{ return _TCESC_CODIGO;}
			set{ 	 _TCESC_CODIGO = value; }
		}
		public string TCESC_DESCRIPCION 
		{
			get{ return _TCESC_DESCRIPCION;}
			set{ 	 _TCESC_DESCRIPCION = value; }
		}
		public string TDOCC_CODIGO 
		{
			get{ return _TDOCC_CODIGO;}
			set{ 	 _TDOCC_CODIGO = value; }
		}
		public string TDOCV_DESCRIPCION 
		{
			get{ return _TDOCV_DESCRIPCION;}
			set{ 	 _TDOCV_DESCRIPCION = value; }
		}
		public string CLIEC_NUM_DOC 
		{
			get{ return _CLIEC_NUM_DOC;}
			set{ 	 _CLIEC_NUM_DOC = value; }
		}
		public string CLIEV_NOMBRE 
		{
			get{ return _CLIEV_NOMBRE;}
			set{ 	 _CLIEV_NOMBRE = value; }
		}
		public string CLIEV_APE_PAT 
		{
			get{ return _CLIEV_APE_PAT;}
			set{ 	 _CLIEV_APE_PAT = value; }
		}
		public string CLIEV_APE_MAT 
		{
			get{ return _CLIEV_APE_MAT;}
			set{ 	 _CLIEV_APE_MAT = value; }
		}
		public string TACTC_CODIGO 
		{
			get{ return _TACTC_CODIGO;}
			set{ 	 _TACTC_CODIGO = value; }
		}
		public string TACTV_DESCRIPCION 
		{
			get{ return _TACTV_DESCRIPCION;}
			set{ 	 _TACTV_DESCRIPCION = value; }
		}
		public string TVENC_CODIGO 
		{
			get{ return _TVENC_CODIGO;}
			set{ 	 _TVENC_CODIGO = value; }
		}
		public string TVENV_DESCRIPCION 
		{
			get{ return _TVENV_DESCRIPCION;}
			set{ 	 _TVENV_DESCRIPCION = value; }
		}
		public string FPAGC_CODIGO 
		{
			get{ return _FPAGC_CODIGO;}
			set{ 	 _FPAGC_CODIGO = value; }
		}
		public string FPAGV_DESCRIPCION 
		{
			get{ return _FPAGV_DESCRIPCION;}
			set{ 	 _FPAGV_DESCRIPCION = value; }
		}
		public string PACUC_CODIGO 
		{
			get{ return _PACUC_CODIGO;}
			set{ 	 _PACUC_CODIGO = value; }
		}
		public string PACUV_DESCRIPCION 
		{
			get{ return _PACUV_DESCRIPCION;}
			set{ 	 _PACUV_DESCRIPCION = value; }
		}
		public string SOLIC_PLA_TAR_1 
		{
			get{ return _SOLIC_PLA_TAR_1;}
			set{ 	 _SOLIC_PLA_TAR_1 = value; }
		}
		public string SOLIC_PLA_TAR_2 
		{
			get{ return _SOLIC_PLA_TAR_2;}
			set{ 	 _SOLIC_PLA_TAR_2 = value; }
		}
		public string SOLIC_PLA_TAR_3 
		{
			get{ return _SOLIC_PLA_TAR_3;}
			set{ 	 _SOLIC_PLA_TAR_3 = value; }
		}
		public string SOLIC_EXI_BSC_FIN 
		{
			get{ return _SOLIC_EXI_BSC_FIN;}
			set{ 	 _SOLIC_EXI_BSC_FIN = value; }
		}
		public string TOFIV_DESCRIPCION 
		{
			get{ return _TOFIV_DESCRIPCION;}
			set{ 	 _TOFIV_DESCRIPCION = value; }
		}
		public string SOLIC_TIP_CAR_FIJ 
		{
			get{ return _SOLIC_TIP_CAR_FIJ;}
			set{ 	 _SOLIC_TIP_CAR_FIJ = value; }
		}
		public string SOLIN_NUM_CAR_FIJ 
		{
			get{ return _SOLIN_NUM_CAR_FIJ;}
			set{ 	 _SOLIN_NUM_CAR_FIJ = value; }
		}
		public string SOLIN_NRO_PLANES_PER 
		{
			get{ return _SOLIN_NRO_PLANES_PER;}
			set{ 	 _SOLIN_NRO_PLANES_PER = value; }
		}
		public string SOLIC_COD_PLAN_MAX 
		{
			get{ return _SOLIC_COD_PLAN_MAX;}
			set{ 	 _SOLIC_COD_PLAN_MAX = value; }
		}
		public string RDIRV_DESCRIPCION
		{
			get{ return _RDIRV_DESCRIPCION;}
			set{ 	 _RDIRV_DESCRIPCION = value; }
		}
		public string SOLIN_IMP_DG
		{
			get{ return _SOLIN_IMP_DG;}
			set{ 	 _SOLIN_IMP_DG = value; }
		}
		public string TIPO_GARANTIA_DES
		{
			get{ return _TIPO_GARANTIA_DES;}
			set{ 	 _TIPO_GARANTIA_DES = value; }
		}
		public string TCARV_DESCRIPCION
		{
			get{ return _TCARV_DESCRIPCION;}
			set{ 	 _TCARV_DESCRIPCION = value; }
		}
		public string SOLIV_MEN_PRE
		{
			get{ return _SOLIV_MEN_PRE;}
			set{ 	 _SOLIV_MEN_PRE = value; }
		}
		public string CCLIC_CODIGO
		{
			get{ return _CCLIC_CODIGO;}
			set{ 	 _CCLIC_CODIGO = value; }
		}
		public string SOLIC_EVA_SUN
		{
			get{ return _SOLIC_EVA_SUN;}
			set{ 	 _SOLIC_EVA_SUN = value; }
		}
		public string CLIEV_PRE_DIR
		{
			get{ return _CLIEV_PRE_DIR;}
			set{ 	 _CLIEV_PRE_DIR = value; }
		}
		public string CLIEV_DIRECCION
		{
			get{ return _CLIEV_DIRECCION;}
			set{ 	 _CLIEV_DIRECCION = value; }
		}
		public string CLIEV_REF_DIR
		{
			get{ return _CLIEV_REF_DIR;}
			set{ 	 _CLIEV_REF_DIR = value; }
		}
		public string CLIEC_COD_DEP_DIR
		{
			get{ return _CLIEC_COD_DEP_DIR;}
			set{ 	 _CLIEC_COD_DEP_DIR = value; }
		}
		public string DEPAV_DESCRIPCION
		{
			get{ return _DEPAV_DESCRIPCION;}
			set{ 	 _DEPAV_DESCRIPCION = value; }
		}
		public string CLIEC_COD_PRO_DIR
		{
			get{ return _CLIEC_COD_PRO_DIR;}
			set{ 	 _CLIEC_COD_PRO_DIR = value; }
		}
		public string PROVV_DESCRIPCION
		{
			get{ return _PROVV_DESCRIPCION;}
			set{ 	 _PROVV_DESCRIPCION = value; }
		}
		public string CLIEC_COD_DIS_DIR
		{
			get{ return _CLIEC_COD_DIS_DIR;}
			set{ 	 _CLIEC_COD_DIS_DIR = value; }
		}
		public string DISTV_DESCRIPCION
		{
			get{ return _DISTV_DESCRIPCION;}
			set{ 	 _DISTV_DESCRIPCION = value; }
		}
		public string CLIEC_COD_POS_DIR
		{
			get{ return _CLIEC_COD_POS_DIR;}
			set{ 	 _CLIEC_COD_POS_DIR = value; }
		}
		public string CLIEV_TEL_LEG
		{
			get{ return _CLIEV_TEL_LEG;}
			set{ 	 _CLIEV_TEL_LEG = value; }
		}
		public string CLIEV_PRE_DIR_TRA
		{
			get{ return _CLIEV_PRE_DIR_TRA;}
			set{ 	 _CLIEV_PRE_DIR_TRA = value; }
		}
		public string CLIEV_DIR_TRA
		{
			get{ return _CLIEV_DIR_TRA;}
			set{ 	 _CLIEV_DIR_TRA = value; }
		}
		public string CLIEV_REF_DIR_TRA
		{
			get{ return _CLIEV_REF_DIR_TRA;}
			set{ 	 _CLIEV_REF_DIR_TRA = value; }
		}
		public string CLIEC_COD_DEP_TRA
		{
			get{ return _CLIEC_COD_DEP_TRA;}
			set{ 	 _CLIEC_COD_DEP_TRA = value; }
		}

		public string CLIEC_COD_PRO_TRA
		{
			get{ return _CLIEC_COD_PRO_TRA;}
			set{ 	 _CLIEC_COD_PRO_TRA = value; }
		}

	
		public string CLIEV_TEL_FIJ_TRA
		{
			get{ return _CLIEV_TEL_FIJ_TRA;}
			set{ 	 _CLIEV_TEL_FIJ_TRA = value; }
		}
		public string CLIEV_TEL_REF_1
		{
			get{ return _CLIEV_TEL_REF_1;}
			set{ 	 _CLIEV_TEL_REF_1 = value; }
		}
		public string CLIEV_TEL_REF_2
		{
			get{ return _CLIEV_TEL_REF_2;}
			set{ 	 _CLIEV_TEL_REF_2 = value; }
		}
		public string CLIEC_COD_DIS_TRA
		{
			get{ return _CLIEC_COD_DIS_TRA;}
			set{ 	 _CLIEC_COD_DIS_TRA = value; }
		}
		public string CLIEC_COD_POS_TRA
		{
			get{ return _CLIEC_COD_POS_TRA;}
			set{ 	 _CLIEC_COD_POS_TRA = value; }
		}
		public string DEPAV_DESCRIPCION_TRA
		{
			get{ return _DEPAV_DESCRIPCION_TRA;}
			set{ 	 _DEPAV_DESCRIPCION_TRA = value; }
		}
		public string PROVV_DESCRIPCION_TRA
		{
			get{ return _PROVV_DESCRIPCION_TRA;}
			set{ 	 _PROVV_DESCRIPCION_TRA = value; }
		}
		public string DISTV_DESCRIPCION_TRA
		{
			get{ return _DISTV_DESCRIPCION_TRA;}
			set{ 	 _DISTV_DESCRIPCION_TRA = value; }
		}


		public string CLIEV_PRE_DIR_FAC
		{
			get{ return _CLIEV_PRE_DIR_FAC;}
			set{ 	 _CLIEV_PRE_DIR_FAC = value; }
		}
		public string CLIEV_DIR_FAC
		{
			get{ return _CLIEV_DIR_FAC;}
			set{ 	 _CLIEV_DIR_FAC = value; }
		}
		public string CLIEV_REF_DIR_FAC
		{
			get{ return _CLIEV_REF_DIR_FAC;}
			set{ 	 _CLIEV_REF_DIR_FAC = value; }
		}
		public string CLIEC_COD_DEP_FAC
		{
			get{ return _CLIEC_COD_DEP_FAC;}
			set{ 	 _CLIEC_COD_DEP_FAC = value; }
		}

		public string CLIEC_COD_PRO_FAC
		{
			get{ return _CLIEC_COD_PRO_FAC;}
			set{ 	 _CLIEC_COD_PRO_FAC = value; }
		}

	
		public string CLIEC_COD_DIS_FAC
		{
			get{ return _CLIEC_COD_DIS_FAC;}
			set{ 	 _CLIEC_COD_DIS_FAC = value; }
		}
		public string CLIEC_COD_POS_FAC
		{
			get{ return _CLIEC_COD_POS_FAC;}
			set{ 	 _CLIEC_COD_POS_FAC = value; }
		}
		public string DEPAV_DESCRIPCION_FAC
		{
			get{ return _DEPAV_DESCRIPCION_FAC;}
			set{ 	 _DEPAV_DESCRIPCION_FAC = value; }
		}
		public string PROVV_DESCRIPCION_FAC
		{
			get{ return _PROVV_DESCRIPCION_FAC;}
			set{ 	 _PROVV_DESCRIPCION_FAC = value; }
		}
		public string DISTV_DESCRIPCION_FAC
		{
			get{ return _DISTV_DESCRIPCION_FAC;}
			set{ 	 _DISTV_DESCRIPCION_FAC = value; }
		}

		public string CONSULTOR_CODIGO
		{
			get{ return _CONSULTOR_CODIGO;}
			set{ 	 _CONSULTOR_CODIGO = value; }
		}
		public string CONSULTOR_NOMBRE
		{
			get{ return _CONSULTOR_NOMBRE;}
			set{ 	 _CONSULTOR_NOMBRE = value; }
		}
		public string SOLIN_CAN_LIN
		{
			get{ return _SOLIN_CAN_LIN;}
			set{ 	 _SOLIN_CAN_LIN = value; }
		}
		public string USUAV_NOMBRE
		{
			get{ return _USUAV_NOMBRE;}
			set{ 	 _USUAV_NOMBRE = value; }
		}
	
		public string TAFIV_DESCRIPCION
		{
			get{ return _TAFIV_DESCRIPCION;}
			set{ 	 _TAFIV_DESCRIPCION = value; }
		}
		public string SOLIV_NUM_TAR
		{
			get{ return _SOLIV_NUM_TAR;}
			set{ 	 _SOLIV_NUM_TAR = value; }
		}
		public string SOLIV_NOM_TIT_TAR
		{
			get{ return _SOLIV_NOM_TIT_TAR;}
			set{ 	 _SOLIV_NOM_TIT_TAR = value; }
		}
		public string SOLIV_DOC_TIT_TAR
		{
			get{ return _SOLIV_DOC_TIT_TAR;}
			set{ 	 _SOLIV_DOC_TIT_TAR = value; }
		}
		public string SOLIV_FEC_VEN_TAR
		{
			get{ return _SOLIV_FEC_VEN_TAR;}
			set{ 	 _SOLIV_FEC_VEN_TAR = value; }
		}
		public string ENTIV_DESCRIPCION
		{
			get{ return _ENTIV_DESCRIPCION;}
			set{ 	 _ENTIV_DESCRIPCION = value; }
		}
		public string TARJV_DESCRIPCION
		{
			get{ return _TARJV_DESCRIPCION;}
			set{ 	 _TARJV_DESCRIPCION = value; }
		}
		public string TMONV_DESCRIPCION
		{
			get{ return _TMONV_DESCRIPCION;}
			set{ 	 _TMONV_DESCRIPCION = value; }
		}

		public string SOLIN_MNTOMAX
		{
			get{ return _SOLIN_MNTOMAX;}
			set{ 	 _SOLIN_MNTOMAX = value; }
		}
		public string CLIEV_PER_REF_1
		{
			get{ return _CLIEV_PER_REF_1;}
			set{ 	 _CLIEV_PER_REF_1 = value; }
		}
		
		//E75638 - COSAPISOFT (INICIO)
		public string PDIRV_DESCRIPCION_LEGAL
		{
			get{ return _PDIRV_DESCRIPCION_LEGAL;}
			set{ 	 _PDIRV_DESCRIPCION_LEGAL = value; }
		}
		public string PDIRV_DESCRIPCION_FACTURACION
		{
			get{ return _PDIRV_DESCRIPCION_FACTURACION;}
			set{ 	 _PDIRV_DESCRIPCION_FACTURACION = value; }
		}
		public string PDIRV_DESCRIPCION_TRABAJO
		{
			get{ return _PDIRV_DESCRIPCION_TRABAJO;}
			set{ 	 _PDIRV_DESCRIPCION_TRABAJO = value; }
		}
		public string SOLIN_USU_VEN
		{
			get{ return _SOLIN_USU_VEN;}
			set{ 	 _SOLIN_USU_VEN = value; }
		}

		//INICIO UB
		public string PLANC_TIPOMP_1 
		{
			get{ return _PLANC_TIPOMP_1;}
			set{ 	 _PLANC_TIPOMP_1 = value; }
		}
		public string PLANC_TIPOMP_2 
		{
			get{ return _PLANC_TIPOMP_2;}
			set{ 	 _PLANC_TIPOMP_2 = value; }
		}
		public string PLANC_TIPOMP_3 
		{
			get{ return _PLANC_TIPOMP_3;}
			set{ 	 _PLANC_TIPOMP_3 = value; }
		}
		//FIN UB

		//E75638 - COSAPISOFT (FIN)

                //E75606 - COSAPISOFT (INICIO)
		public string DCREV_NUM_OPERACION
		{
			get{ return _DCREV_NUM_OPERACION; }
			set{ _DCREV_NUM_OPERACION = value; }
		}
		public string DCREV_TIPO_RESPUESTA
		{
			get{ return _DCREV_TIPO_RESPUESTA; }
			set{ _DCREV_TIPO_RESPUESTA = value; }
		}
		public string DCREV_TIPO_RESP_DESC
		{
			get{ return _DCREV_TIPO_RESP_DESC; }
			set{ _DCREV_TIPO_RESP_DESC = value; }
		}
		public string DCREC_VALIDAR_CLIENTE
		{
			get{ return _DCREC_VALIDAR_CLIENTE; }
			set{ _DCREC_VALIDAR_CLIENTE = value; }
		}
		//E75606 - COSAPISOFT (FIN)

		//E75606 - (VENTA EXPRESS INICIO)
		public string TCLIC_CODIGO
		{
			get{ return _TCLIC_CODIGO; }
			set{ _TCLIC_CODIGO = value; }
		}
		public string TOPEN_CODIGO
		{
			get{ return _TOPEN_CODIGO; }
			set{ _TOPEN_CODIGO = value; }
		}
		//E75606 - (VENTA EXPRESS FIN)

		//<CAA>
		public string SOLIV_DES_TIP_ACT { set {_SOLIV_DES_TIP_ACT = value;} get {return _SOLIV_DES_TIP_ACT;} }
		public string SEGMV_DESCRIPCION { set { _SEGMV_DESCRIPCION = value;} get { return _SEGMV_DESCRIPCION;} }
		public string ESTAV_DESCRIPCION { set {  _ESTAV_DESCRIPCION= value;} get { return _ESTAV_DESCRIPCION;} }
		public string CLIEV_RAZ_SOC{ set {  _CLIEV_RAZ_SOC= value;} get { return _CLIEV_RAZ_SOC;} }
		public string ESTAC_CODIGO{ set {  _ESTAC_CODIGO= value;} get { return _ESTAC_CODIGO;} }
		public string SOLIC_FLA_TER{ set {  _SOLIC_FLA_TER= value;} get { return _SOLIC_FLA_TER;} }
		public string TEVAC_CODIGO{ set {  _TEVAC_CODIGO= value;} get { return _TEVAC_CODIGO;} }
		public string ANALV_DESCRIPCION{ set {  _ANALV_DESCRIPCION= value;} get { return _ANALV_DESCRIPCION;} }
		public double CLIEN_CAP_SOC{ set {  _CLIEN_CAP_SOC= value;} get { return _CLIEN_CAP_SOC;} }
		public string PLANV_DESCRIPCION1{ set {  _PLANV_DESCRIPCION1= value;} get { return _PLANV_DESCRIPCION1;} }
		public string PLANV_DESCRIPCION2{ set {  _PLANV_DESCRIPCION2= value;} get { return _PLANV_DESCRIPCION2;} }
		public string PLANV_DESCRIPCION3{ set {  _PLANV_DESCRIPCION3= value;} get { return _PLANV_DESCRIPCION3;} }
		public string RFINC_CODIGO{ set {  _RFINC_CODIGO= value;} get { return _RFINC_CODIGO;} }
		public string RFINV_DESCRIPCION{ set {  _RFINV_DESCRIPCION= value;} get { return _RFINV_DESCRIPCION;} }
		public double SOLIN_IMP_DG_MAN{ set {  _SOLIN_IMP_DG_MAN= value;} get { return _SOLIN_IMP_DG_MAN;} }
		public string MRECV_DESCRIPCION{ set {  _MRECV_DESCRIPCION= value;} get { return _MRECV_DESCRIPCION;} }
		public string TAFIC_CODIGO{ set {  _TAFIC_CODIGO= value;} get { return _TAFIC_CODIGO;} }
		public string SOLIC_COD_TAR{ set {  _SOLIC_COD_TAR = value;} get { return _SOLIC_COD_TAR;} }
		public string SOLIC_COD_TIP_MON{ set {  _SOLIC_COD_TIP_MON= value;} get { return _SOLIC_COD_TIP_MON ;} }
		public string SOLIV_NUM_OPE_CON{ set { _SOLIV_NUM_OPE_CON = value;} get { return _SOLIV_NUM_OPE_CON;} }
		public double SOLIN_LIM_CRE_CON{ set {  _SOLIN_LIM_CRE_CON= value;} get { return _SOLIN_LIM_CRE_CON;} }
		public double SOLIN_LIM_CRE_FIN{ set {  _SOLIN_LIM_CRE_FIN= value;} get { return _SOLIN_LIM_CRE_FIN;} }
		public string SOLIC_SCO_TXT_FIN{ set {  _SOLIC_SCO_TXT_FIN= value;} get { return _SOLIC_SCO_TXT_FIN;} }
		public double SOLIN_SCO_NUM_FIN{ set {  _SOLIN_SCO_NUM_FIN= value;} get { return _SOLIN_SCO_NUM_FIN;} }
		public double SOLIN_LIM_MAX_FIN{ set {  _SOLIN_LIM_MAX_FIN= value;} get { return _SOLIN_LIM_MAX_FIN;} }
		public string SOLIC_POSTCONTROL{ set {  _SOLIC_POSTCONTROL= value;} get { return _SOLIC_POSTCONTROL;} }
		public string CCLIV_DESCRIPCION{ set {  _CCLIV_DESCRIPCION= value;} get { return _CCLIV_DESCRIPCION;} }
		public string SOLIC_EVA_ESS{ set {  _SOLIC_EVA_ESS= value;} get { return _SOLIC_EVA_ESS ;} }
		public string CLIEV_PRE_TEL_LEG{ set {  _CLIEV_PRE_TEL_LEG= value;} get { return _CLIEV_PRE_TEL_LEG;} }
		public string DESCRIPCION_TELEFONO_LEGAL{ set {  _DESCRIPCION_TELEFONO_LEGAL= value;} get { return _DESCRIPCION_TELEFONO_LEGAL;} }
		public string CLIEV_PER_REF1{ set {  _CLIEV_PER_REF1= value;} get { return _CLIEV_PER_REF1;} }
		public string CLIEV_PER_REF2{ set { _CLIEV_PER_REF2 = value;} get { return _CLIEV_PER_REF2;} }
		public string CLIEV_PER_CON_TRA{ set {_CLIEV_PER_CON_TRA  = value;} get { return _CLIEV_PER_CON_TRA;} }
		public string DEPAV_DESCRIPCION_LEGAL{ set { _DEPAV_DESCRIPCION_LEGAL = value;} get { return _DEPAV_DESCRIPCION_LEGAL;} }
		public string PROVV_DESCRIPCION_LEGAL{ set {  _PROVV_DESCRIPCION_LEGAL= value;} get { return _PROVV_DESCRIPCION_LEGAL;} }
		public string DISTV_DESCRIPCION_LEGAL{ set { _DISTV_DESCRIPCION_LEGAL = value;} get { return _DISTV_DESCRIPCION_LEGAL;} }
		public string DEPAV_DESCRIPCION_FACTURACION{ set {  _DEPAV_DESCRIPCION_FACTURACION= value;} get { return _DEPAV_DESCRIPCION_FACTURACION ;} }
		public string PROVV_DESCRIPCION_FACTURACION{ set {  _PROVV_DESCRIPCION_FACTURACION= value;} get { return _PROVV_DESCRIPCION_FACTURACION;} }
		public string DISTV_DESCRIPCION_FACTURACION{ set {  _DISTV_DESCRIPCION_FACTURACION= value;} get { return _DISTV_DESCRIPCION_FACTURACION;} }
		public string DEPAV_DESCRIPCION_TRABAJO{ set {  _DEPAV_DESCRIPCION_TRABAJO= value;} get { return _DEPAV_DESCRIPCION_TRABAJO;} }
		public string PROVV_DESCRIPCION_TRABAJO{ set {  _PROVV_DESCRIPCION_TRABAJO= value;} get { return _PROVV_DESCRIPCION_TRABAJO;} }
		public string DISTV_DESCRIPCION_TRABAJO{ set {  _DISTV_DESCRIPCION_TRABAJO= value;} get { return _DISTV_DESCRIPCION_TRABAJO;} }
		public string PLANC_CODIGO1{ set {  _PLANC_CODIGO1= value;} get { return _PLANC_CODIGO1;} }
		public string PLANC_CODIGO2{ set {  _PLANC_CODIGO2= value;} get { return _PLANC_CODIGO2;} }
		public string PLANC_CODIGO3{ set {  _PLANC_CODIGO3= value;} get { return _PLANC_CODIGO3;} }
		public double PLANN_CAR_FIJ1{ set {  _PLANN_CAR_FIJ1= value;} get { return _PLANN_CAR_FIJ1;} }
		public double PLANN_CAR_FIJ2{ set {  _PLANN_CAR_FIJ2= value;} get { return _PLANN_CAR_FIJ2;} }
		public double PLANN_CAR_FIJ3{ set {  _PLANN_CAR_FIJ3= value;} get { return _PLANN_CAR_FIJ3;} }
		public string RDIRC_CODIGO{ set { _RDIRC_CODIGO = value;} get { return _RDIRC_CODIGO;} }
		public string SOLIV_RES_EXP_CON{ set { _SOLIV_RES_EXP_CON = value;} get { return _SOLIV_RES_EXP_CON;} }
		public string SOLIC_SCO_TXT_CON{ set {_SOLIC_SCO_TXT_CON  = value;} get { return _SOLIC_SCO_TXT_CON;} }
		public double SOLIN_SCO_NUM_CON{ set {  _SOLIN_SCO_NUM_CON= value;} get { return _SOLIN_SCO_NUM_CON;} }
		public double SOLIN_SUM_CAR_CON{ set {  _SOLIN_SUM_CAR_CON= value;} get { return _SOLIN_SUM_CAR_CON;} }
		public string SOLIV_RUC_EMP_SUS{ set {  _SOLIV_RUC_EMP_SUS= value;} get { return _SOLIV_RUC_EMP_SUS ;} }
		public string SOLIV_EMP_SUS{ set {  _SOLIV_EMP_SUS = value;} get { return _SOLIV_EMP_SUS;} }
		public string MRDIV_CAD_CODIGO{ set {  _MRDIV_CAD_CODIGO= value;} get { return _MRDIV_CAD_CODIGO;} }


		
		public DateTime FECHA_NACIMIENTO{ set {  _FECHA_NACIMIENTO= value;} get { return _FECHA_NACIMIENTO;} }		
		public string TITULO_PERSONA_ID{ set {  _TITULO_PERSONA_ID= value;} get { return _TITULO_PERSONA_ID;} }		
		public string TITULO_PERSONA_DES{ set {  _TITULO_PERSONA_DES= value;} get { return _TITULO_PERSONA_DES;} }		
		public string SEXO{ set {  _SEXO= value;} get { return _SEXO;} }		
		public string ESTADO_CIVIL_ID{ set {  _ESTADO_CIVIL_ID= value;} get { return _ESTADO_CIVIL_ID;} }
		public string ESTADO_CIVIL_DES{ set {  _ESTADO_CIVIL_DES= value;} get { return _ESTADO_CIVIL_DES;} }
		public string TELEFONO_CASA{ set {  _TELEFONO_CASA= value;} get { return _TELEFONO_CASA;} }
		public string MENSAJE{ set {  _MENSAJE= value;} get { return _MENSAJE;} }
		public string ESTADOESSALUDSUNAT{ set {  _ESTADOESSALUDSUNAT= value;} get { return _ESTADOESSALUDSUNAT;} }
		public string ESTADODES{ set {  _ESTADODES= value;} get { return _ESTADODES;} }
		
		//</CAA>
		
		//T12618 - Portabilidad - INICIO
		public string OPERADOR_CEDENTE
		{
			get{ return _OPERADOR_CEDENTE;}
			set{ 	 _OPERADOR_CEDENTE = value; }
		}
		public string ESTADO_PORTABILIDAD
		{
			get{ return _ESTADO_PORTABILIDAD;}
			set{ 	 _ESTADO_PORTABILIDAD = value; }
		}
		public string FLAG_PORTABILIDAD
		{
			get{ return _FLAG_PORTABILIDAD;}
			set{ 	 _FLAG_PORTABILIDAD = value; }
		}
		//T12618 - Portabilidad - FIN

		//E75606 - (EXPRESS PORTABILIDAD INICIO)
		public string OPERADOR_CEDENTE_DESC
		{
			get{ return _OPERADOR_CEDENTE_DESC; }
			set{ _OPERADOR_CEDENTE_DESC = value; }
		}
		public string ESTADO_PORTABILIDAD_DESC
		{
			get{ return _ESTADO_PORTABILIDAD_DESC; }
			set{ _ESTADO_PORTABILIDAD_DESC = value; }
		}
		//E75606 - (EXPRESS PORTABILIDAD FIN)

		//INICIO - E75688
		public string FLAG_CORREO               {set { _FLAG_CORREO= value;} get{ return _FLAG_CORREO;}}
		public string SOLIV_CORREO				{set { _SOLIV_CORREO= value;} get{ return _SOLIV_CORREO;}}	
		public string SOLIV_TEL_SMS				{set { _SOLIV_TEL_SMS= value;} get{ return _SOLIV_TEL_SMS;}}			
		//FIN

		//Renovacion
		public string BURO_DESCRIPCION
		{
			get{ return _BURO_DESCRIPCION;}
			set{ _BURO_DESCRIPCION = value; }
		}
		public string FLAG_REINGRESO_SEC
		{
			get{ return _FLAG_REINGRESO_SEC;}
			set{ _FLAG_REINGRESO_SEC = value; }
		}

		public string CLIEC_BLOQUEO
		{
			get{ return _CLIEC_BLOQUEO;}
			set{ _CLIEC_BLOQUEO = value; }
		}

		public double CLIEN_MONTO_VENCIDO
		{
			get{ return _CLIEN_MONTO_VENCIDO; }
			set{ _CLIEN_MONTO_VENCIDO = value; }
		}

		public string CREDV_OBS_FLEXIBILIZACION
		{
			get{ return _CREDV_OBS_FLEXIBILIZACION;}
			set{ _CREDV_OBS_FLEXIBILIZACION = value; }
		}

		public DateTime FECHA_NACIMIENTO_PDV{ set {  _FECHA_NACIMIENTO_PDV= value;} get { return _FECHA_NACIMIENTO_PDV;} }		

		public string PRDV_DESCRIPCION
		{
			get{ return _PRDV_DESCRIPCION;}
			set{ _PRDV_DESCRIPCION = value; }
		}

		public string TPROD_COMERCIALIZAR
		{
			get{ return _TPROD_COMERCIALIZAR;}
			set{ _TPROD_COMERCIALIZAR = value; }
		}

		public double SOLIN_COST_INST
		{
			get{ return _SOLIN_COST_INST;}
			set{ _SOLIN_COST_INST = value; }
		}

		public double SOLIN_CF_MAYORES
		{
			get{ return _SOLIN_CF_MAYORES;}
			set{ _SOLIN_CF_MAYORES = value; }
		}

		public double SOLIN_CF_MENORES
		{
			get{ return _SOLIN_CF_MENORES;}
			set{ _SOLIN_CF_MENORES = value; }
		}

		public double SOLIN_LC_DISPONIBLE
		{
			get{ return _SOLIN_LC_DISPONIBLE;}
			set{ _SOLIN_LC_DISPONIBLE = value; }
		}

		public string DEPAV_DESCRIPCION_DC
		{
			get{ return _DEPAV_DESCRIPCION_DC; }
			set{ _DEPAV_DESCRIPCION_DC = value; }
		}

		public string PROVV_DESCRIPCION_DC
		{
			get{ return _PROVV_DESCRIPCION_DC; }
			set{ _PROVV_DESCRIPCION_DC = value; }
		}

		public int SOLIN_PUNTAJE_DC
		{
			get{ return _SOLIN_PUNTAJE_DC; }
			set{ _SOLIN_PUNTAJE_DC = value; }
		}

		public string SOLIC_ANALISIS_DC
		{
			get{ return _SOLIC_ANALISIS_DC; }
			set{ _SOLIC_ANALISIS_DC = value; }
		}

		public string SOLIC_SCORE_RANKING_OPER_DC
		{
			get{ return _SOLIC_SCORE_RANKING_OPER_DC; }
			set{ _SOLIC_SCORE_RANKING_OPER_DC = value; }
		}

		public string SOLIC_ORIGEN_LC_DC
		{
			get{ return _SOLIC_ORIGEN_LC_DC; }
			set{ _SOLIC_ORIGEN_LC_DC = value; }
		}

		public double SOLIN_LC_BASE_EXTERNA_DC
		{
			get{ return _SOLIN_LC_BASE_EXTERNA_DC; }
			set{ _SOLIN_LC_BASE_EXTERNA_DC = value; }
		}

		public double SOLIN_LC_CLARO_DC
		{
			get{ return _SOLIN_LC_CLARO_DC; }
			set{ _SOLIN_LC_CLARO_DC = value; }
		}

		public string CLIEV_CALIFICACION_PAGO
		{
			get{ return _CLIEV_CALIFICACION_PAGO;}
			set{ _CLIEV_CALIFICACION_PAGO = value; }
		}

		public double SOLIN_LC_DATA_CREDITO_DC
		{
			get{ return _SOLIN_LC_DATA_CREDITO_DC; }
			set{ _SOLIN_LC_DATA_CREDITO_DC = value; }
		}

		public string SOLIC_EVA_ESS_INI
		{
			get{ return _SOLIC_EVA_ESS_INI;}
			set{ _SOLIC_EVA_ESS_INI = value; }
		}

		public string ID_VENTA_DTH
		{
			get{ return _ID_VENTA_DTH;}
			set{ _ID_VENTA_DTH = value; }
		}

		public string SOLIC_EVA_SUN_INI
		{
			get{ return _SOLIC_EVA_SUN_INI;}
			set{ _SOLIC_EVA_SUN_INI = value; }
		}

		public string TOPEV_DESCRIPCION
		{
			get{ return _TOPEV_DESCRIPCION;}
			set{ _TOPEV_DESCRIPCION = value; }
		}

		public string SOLIV_DES_EST
		{
			get{ return _SOLIV_DES_EST;}
			set{ _SOLIV_DES_EST = value; }
		}

		public string SOLIV_NUM_CON
		{
			get{ return _SOLIV_NUM_CON;}
			set{ _SOLIV_NUM_CON = value; }
		}

		public string CAMPV_CODIGO 
		{
			get{ return _CAMPV_CODIGO;}
			set{ _CAMPV_CODIGO = value; }
		}

		public Int64 SOLIN_GRUPO_SEC
		{
			get{ return _SOLIN_GRUPO_SEC;}
			set
			{
				_SOLIN_GRUPO_SEC = value; 
			}	
		}

		public string PRDC_CODIGO
		{
			get{ return _PRDC_CODIGO;}
			set
			{
				_PRDC_CODIGO = value; 
			}	
		}

		public string NUMERO_LINEA
		{
			get{ return _NUMERO_LINEA;}
			set{ _NUMERO_LINEA = value; }
		}

	}
}
