using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Garantia_AP.
	/// </summary>
	public class ReglaConsumer
	{
		private Int64 _REGCN_CORRELATIVO;
		private double _REGCN_CAR_FIJ_MIN;
		private double _REGCN_CAR_FIJ_MAX;
		private string _REGCC_COND_CLIENTE;
		private int _REGCN_NRO_LINEAS;
		private double _REGCN_NUM_CAR_FIJ;
		private double _REGCN_MONTO_FLAT;
		private string _REGCV_MENSAJE;
		private string _REGCC_ESTADO;
		private DateTime _REGCD_FECHA_CREA;
		private string _REGCV_USUARIO_CREA;

		private TipoCargo _TIPO_CARGO;
		private Riesgo _RIESGO;
		private PlazoAcuerdo _PLAZO_ACUERDO;
		private TipoActivacion _TIPO_ACTIVACION;
		private FormaPago _FORMA_PAGO;

		public Int64 REGCN_CORRELATIVO {get{ return _REGCN_CORRELATIVO;} set{_REGCN_CORRELATIVO = value;}}
		public double REGCN_CAR_FIJ_MIN {get{ return _REGCN_CAR_FIJ_MIN;} set{_REGCN_CAR_FIJ_MIN = value;}}
		public double REGCN_CAR_FIJ_MAX {get{ return _REGCN_CAR_FIJ_MAX;} set{_REGCN_CAR_FIJ_MAX = value;}}
		public string REGCC_COND_CLIENTE {get{ return _REGCC_COND_CLIENTE;} set{_REGCC_COND_CLIENTE = value;}}
		public int REGCN_NRO_LINEAS {get{ return _REGCN_NRO_LINEAS;} set{_REGCN_NRO_LINEAS = value;}}
		public double REGCN_NUM_CAR_FIJ {get{ return _REGCN_NUM_CAR_FIJ;} set{_REGCN_NUM_CAR_FIJ = value;}}
		public double REGCN_MONTO_FLAT {get{ return _REGCN_MONTO_FLAT;} set{_REGCN_MONTO_FLAT = value;}}
		public string REGCV_MENSAJE {get{ return _REGCV_MENSAJE;} set{_REGCV_MENSAJE = value;}}
		public string REGCC_ESTADO {get{ return _REGCC_ESTADO;} set{_REGCC_ESTADO = value;}}
		public DateTime REGCD_FECHA_CREA {get{ return _REGCD_FECHA_CREA;} set{_REGCD_FECHA_CREA = value;}}
		public string REGCV_USUARIO_CREA {get{ return _REGCV_USUARIO_CREA;} set{_REGCV_USUARIO_CREA = value;}}

		public TipoCargo TIPO_CARGO {get{ return _TIPO_CARGO;} set{_TIPO_CARGO = value;}}
		public Riesgo RIESGO {get{ return _RIESGO;} set{_RIESGO = value;}}
		public PlazoAcuerdo PLAZO_ACUERDO {get{ return _PLAZO_ACUERDO;} set{_PLAZO_ACUERDO = value;}}
		public TipoActivacion TIPO_ACTIVACION {get{ return _TIPO_ACTIVACION;} set{_TIPO_ACTIVACION = value;}}
		public FormaPago FORMA_PAGO {get{ return _FORMA_PAGO;} set{_FORMA_PAGO = value;}}

		public enum CONDICION
		{
			R = 1, //Relativo
			A = 2 //Absoluto
		}
		public enum TIPO
		{
			NINGUNO = 0,
			DG = 1,
			RA = 2,
			PA = 3
		}

		public ReglaConsumer()
		{
		}
	}
}
