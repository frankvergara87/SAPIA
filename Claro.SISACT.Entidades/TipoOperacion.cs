using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TipoPaquete.
	/// </summary>
	public class TipoOperacion
	{

		private int _TOPEN_CODIGO;
		private string _TPROC_CODIGO;
        private string _TOPEV_DESCRIPCION;
		private string _TOPEC_ESTADO;

		public TipoOperacion(){}
		
		public int TOPEN_CODIGO
		{
			set{_TOPEN_CODIGO= value;}
			get{return _TOPEN_CODIGO;}
		}

		public string TPROC_CODIGO
		{
			set{_TPROC_CODIGO= value;}
			get{return _TPROC_CODIGO;}
		}

		public string TOPEV_DESCRIPCION
		{
			set{_TOPEV_DESCRIPCION= value;}
			get{return _TOPEV_DESCRIPCION;}
		}
		public string TOPEC_ESTADO
		{
			set{_TOPEC_ESTADO= value;}
			get{return _TOPEC_ESTADO;}
		}

	}
}
