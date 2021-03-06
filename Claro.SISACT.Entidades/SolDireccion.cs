using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Definición de variables, propiedades y métodos de la Clase SolDireccion (Despacho)
	/// </summary>
	[Serializable]
	public class SolDireccion
	{
		#region "Variables"
			private long _SDIRN_CODIGO;
			private long _SOLIN_CODIGO;
			private char _SDIRC_TIPO;
			private string _PDIRC_CODIGO;
			private string _SDIRV_DIRECCION;
			private string _SDIRV_REFERENCIA;
			private string _DEPAC_CODIGO;
			private string _PROVC_CODIGO;
			private string _DISTC_CODIGO;
			private string _DISTC_CODIGO_POSTAL;
			private char _SDIRC_ESTADO;
			private string _CUENV_TELEFONO_REF;
			private string _SDIRV_USU_CREA;
			private DateTime _SDIRD_FEC_REG;
			private string _SDIRV_NUMERO;
			private char _SDIRV_FLAG_SN;
			private string _SDIRV_MZ;
			private string _SDIRV_LOTE;
			private string _SDIRV_TIPO;
			private string _SDIRV_NUMERO_TIPO;
			private string _SDIRV_TIPO_EDIFICACION;
			private string _SDIRV_TIPO_DENOMINACION;
			private string _SDIRV_NOMBRE_DENO;
			private string _SDIRV_TIPO_ZONA;
			private string _SDIRV_NOMBRE_ZONA;
		#endregion

		#region "Propiedades"
			public long SDIRN_CODIGO
			{
				get { return _SDIRN_CODIGO; }
				set { _SDIRN_CODIGO = value; }
			}
			public long SOLIN_CODIGO
			{
				get { return _SOLIN_CODIGO; }
				set { _SOLIN_CODIGO = value; }
			}
			public char SDIRC_TIPO
			{
				get { return _SDIRC_TIPO; }
				set { _SDIRC_TIPO = value; }
			}
			public string PDIRC_CODIGO
			{
				get { return _PDIRC_CODIGO; }
				set { _PDIRC_CODIGO = value; }
			}
			public string SDIRV_DIRECCION
			{
				get { return _SDIRV_DIRECCION; }
				set { _SDIRV_DIRECCION = value; }
			}
			public string SDIRV_REFERENCIA
			{
				get { return _SDIRV_REFERENCIA; }
				set { _SDIRV_REFERENCIA = value; }
			}
			public string DEPAC_CODIGO
			{
				get { return _DEPAC_CODIGO; }
				set { _DEPAC_CODIGO = value; }
			}
			public string PROVC_CODIGO
			{
				get { return _PROVC_CODIGO; }
				set { _PROVC_CODIGO = value; }
			}
			public string DISTC_CODIGO
			{
				get { return _DISTC_CODIGO; }
				set { _DISTC_CODIGO = value; }
			}
			public string DISTC_CODIGO_POSTAL
			{
				get { return _DISTC_CODIGO_POSTAL; }
				set { _DISTC_CODIGO_POSTAL = value; }
			}
			public char SDIRC_ESTADO
			{
				get { return _SDIRC_ESTADO; }
				set { _SDIRC_ESTADO = value; }
			}
			public string CUENV_TELEFONO_REF
			{
				get { return _CUENV_TELEFONO_REF; }
				set { _CUENV_TELEFONO_REF = value; }
			}
			public string SDIRV_USU_CREA
			{
				get { return _SDIRV_USU_CREA; }
				set { _SDIRV_USU_CREA = value; }
			}
			public DateTime SDIRD_FEC_REG
			{
				get { return _SDIRD_FEC_REG; }
				set { _SDIRD_FEC_REG = value; }
			}
			public string SDIRV_NUMERO
			{
				get { return _SDIRV_NUMERO; }
				set { _SDIRV_NUMERO = value; }
			}
			public char SDIRV_FLAG_SN
			{
				get { return _SDIRV_FLAG_SN; }
				set { _SDIRV_FLAG_SN = value; }
			}
			public string SDIRV_MZ
			{
				get { return _SDIRV_MZ; }
				set { _SDIRV_MZ = value; }
			}
			public string SDIRV_LOTE
			{
				get { return _SDIRV_LOTE; }
				set { _SDIRV_LOTE = value; }
			}
			public string SDIRV_TIPO
			{
				get { return _SDIRV_TIPO; }
				set { _SDIRV_TIPO = value; }
			}
			public string SDIRV_NUMERO_TIPO
			{
				get { return _SDIRV_NUMERO_TIPO; }
				set { _SDIRV_NUMERO_TIPO = value; }
			}
			public string SDIRV_TIPO_EDIFICACION
			{
				get { return _SDIRV_TIPO_EDIFICACION; }
				set { _SDIRV_TIPO_EDIFICACION = value; }
			}
			public string SDIRV_TIPO_DENOMINACION
			{
				get { return _SDIRV_TIPO_DENOMINACION; }
				set { _SDIRV_TIPO_DENOMINACION = value; }
			}
			public string SDIRV_NOMBRE_DENO
			{
				get { return _SDIRV_NOMBRE_DENO; }
				set { _SDIRV_NOMBRE_DENO = value; }
			}
			public string SDIRV_TIPO_ZONA
			{
				get { return _SDIRV_TIPO_ZONA; }
				set { _SDIRV_TIPO_ZONA = value; }
			}
			public string SDIRV_NOMBRE_ZONA
			{
				get { return _SDIRV_NOMBRE_ZONA; }
				set { _SDIRV_NOMBRE_ZONA = value; }
			}
		#endregion

		#region "Constructores"
			public SolDireccion()
			{
				//Here code
			}
		#endregion

	}
}
