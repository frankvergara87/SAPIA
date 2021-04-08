using System;
using System.Reflection;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de MigracionWL.
	/// </summary>
	public class MigracionWL
	{
		public MigracionWL()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		private string _tipoDocumento;
		private string _nroDocumento;
		private string _nroLinea;
		private string _nombres;
		private string _apellido_paterno;
		private string _apellido_materno;
		private string _plazo_acuerdo;
		private double _cargoFijoMax;
		private double _cargoFijoMin;
		private int _nroCargosFijoMax;
		private int _nroCargosFijoMin;
		private double _montoFlat;
		private int _flag_control_consumo;
		private string _riesgo;
		private string _score;
		private string _scoreCred;
		private string _tipoCargoMax;
		private string _tipoCargoMaxDesc;
		private string _tipoCargoMin;
		private string _tipoCargoMinDesc;
		private double _limiteCredito;
		private int _flag_migracion;

		public string NOMBRES
		{
			set{_nombres = value;}
			get{ return _nombres;}
		}
		public string APELLIDO_PATERNO
		{
			set{_apellido_paterno = value;}
			get{ return _apellido_paterno;}
		}
		public string APELLIDO_MATERNO
		{
			set{_apellido_materno = value;}
			get{ return _apellido_materno;}
		}
		public string PLAZO_ACUERDO
		{
			set{_plazo_acuerdo = value;}
			get{ return _plazo_acuerdo;}
		}
		public string TIPO_DOCUMENTO
		{
			set{_tipoDocumento = value;}
			get{ return _tipoDocumento;}
		}
		public string NRO_DOCUMENTO
		{
			set{_nroDocumento = value;}
			get{ return _nroDocumento;}
		}

		public string NRO_LINEA
		{
			set{_nroLinea = value;}
			get{ return _nroLinea;}
		}

		public string RIESGO
		{
			set{_riesgo = value;}
			get{ return _riesgo;}
		}

		public string SCORE
		{
			set{_score = value;}
			get{ return _score;}
		}

		public string SCORE_CRED
		{
			set{_scoreCred = value;}
			get{ return _scoreCred;}
		}

		public string TIPO_CARGO_MAX
		{
			set{_tipoCargoMax = value;}
			get{ return _tipoCargoMax;}
		}

		public string TIPO_CARGO_MIN
		{
			set{_tipoCargoMin = value;}
			get{ return _tipoCargoMin;}
		}

		public string TIPO_CARGO_MAX_DESC
		{
			set{_tipoCargoMaxDesc = value;}
			get{ return _tipoCargoMaxDesc;}
		}

		public string TIPO_CARGO_MIN_DESC
		{
			set{_tipoCargoMinDesc = value;}
			get{ return _tipoCargoMinDesc;}
		}

		public double CARGO_FIJO_MAX
		{
			set{_cargoFijoMax = value;}
			get{ return _cargoFijoMax;}
		}

		public double CARGO_FIJO_MIN
		{
			set{_cargoFijoMin = value;}
			get{ return _cargoFijoMin;}
		}

		public double MONTO_FLAT
		{
			set{_montoFlat = value;}
			get{ return _montoFlat;}
		}

		public double LIMITE_CREDITO
		{
			set{_limiteCredito = value;}
			get{ return _limiteCredito;}
		}

		public int FLAG_CONTROL_CONSUMO
		{
			set{_flag_control_consumo = value;}
			get{ return _flag_control_consumo;}
		}

		public int FLAG_MIGRACION
		{
			set{_flag_migracion = value;}
			get{ return _flag_migracion;}
		}

		public int NRO_CARGOS_FIJOS_MAX
		{
			set{_nroCargosFijoMax = value;}
			get{ return _nroCargosFijoMax;}
		}

		public int NRO_CARGOS_FIJOS_MIN
		{
			set{_nroCargosFijoMin = value;}
			get{ return _nroCargosFijoMin;}
		}

		public override string ToString()
		{
			string cadena ="";
			Type tipo = this.GetType();
            System.Reflection.PropertyInfo[] properties = tipo.GetProperties();
			
			foreach (System.Reflection.PropertyInfo p  in properties)
			{
				cadena += p.GetValue(this,null).ToString() + "|";
			}
			
			cadena = cadena.Substring(0,cadena.Length-1);

			return cadena;
		}

	}
}
