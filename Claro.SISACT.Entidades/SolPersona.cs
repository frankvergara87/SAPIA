using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Definición de variables, propiedades y métodos de la Clase SolPersona (Despacho)
	/// </summary>
	[Serializable]
	public class SolPersona
	{
		#region "Variables"
			private long _SPERN_CODIGO;
			private long _SOLIN_CODIGO;
			private char _SPERC_TIPO;
			private string _SPERV_NOMBRE;
			private string _SPERV_APEPATERNO;
			private string _SPERV_APEMATERNO;
			private string _TDOCC_CODIGO;
			private string _SPERV_NUM_DOC;
			private string _SPERV_CARGO;
			private string _SPERV_FAX;
			private string _SPERV_EMAIL;
			private char _SPERV_ESTADO;
			private string _SPERV_USU_CREA;
			private DateTime _SPERD_FEC_REG;
		#endregion

		#region "Propiedades"
			public long SPERN_CODIGO
			{
				get { return _SPERN_CODIGO; }
				set { _SPERN_CODIGO = value; }
			}
			public long SOLIN_CODIGO
			{
				get { return _SOLIN_CODIGO; }
				set { _SOLIN_CODIGO = value; }
			}
			public char SPERC_TIPO
			{
				get { return _SPERC_TIPO; }
				set { _SPERC_TIPO = value; }
			}
			public string SPERV_NOMBRE
			{
				get { return _SPERV_NOMBRE; }
				set { _SPERV_NOMBRE = value; }
			}
			public string SPERV_APEPATERNO
			{
				get { return _SPERV_APEPATERNO; }
				set { _SPERV_APEPATERNO = value; }
			}
			public string SPERV_APEMATERNO
			{
				get { return _SPERV_APEMATERNO; }
				set { _SPERV_APEMATERNO = value; }
			}
			public string TDOCC_CODIGO
			{
				get { return _TDOCC_CODIGO; }
				set { _TDOCC_CODIGO = value; }
			}
			public string SPERV_NUM_DOC
			{
				get { return _SPERV_NUM_DOC; }
				set { _SPERV_NUM_DOC = value; }
			}
			public string SPERV_CARGO
			{
				get { return _SPERV_CARGO; }
				set { _SPERV_CARGO = value; }
			}
			public string SPERV_FAX
			{
				get { return _SPERV_FAX; }
				set { _SPERV_FAX = value; }
			}
			public string SPERV_EMAIL
			{
				get { return _SPERV_EMAIL; }
				set { _SPERV_EMAIL = value; }
			}
			public char SPERV_ESTADO
			{
				get { return _SPERV_ESTADO; }
				set { _SPERV_ESTADO = value; }
			}
			public string SPERV_USU_CREA
			{
				get { return _SPERV_USU_CREA; }
				set { _SPERV_USU_CREA = value; }
			}
			public DateTime SPERD_FEC_REG
			{
				get { return _SPERD_FEC_REG; }
				set { _SPERD_FEC_REG = value; }
			}
		#endregion

		#region "Constructores"
			public SolPersona()
			{
				//Here code
			}
		#endregion

	}
}
