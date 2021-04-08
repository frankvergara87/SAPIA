using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TipoDocumento.
	/// </summary>
	public class TipoDocumento
	{
		private string _TDOCC_CODIGO;
		private string _TDOCV_DESCRIPCION;
		private string _TDOCC_ESTADO;
		private int _ID_INFOCORP;
		private string _ID_ABDCP;
		private string _ID_DC_CORP;
		private string _COD_BSCS;
		private string _COD_SGA;

		public TipoDocumento(){}

		public string _ID_SISACT;


		public string _ID_OAC;
		public string ID_OAC
		{
			set{_ID_OAC= value;}
			get{return _ID_OAC;}
		}


		public string ID_SISACT
		{
			set{_ID_SISACT= value;}
			get{return _ID_SISACT;}
		}

		public TipoDocumento(int CODIGO,string DESCRIPCION)
		{
			_ID_INFOCORP = CODIGO;
			_TDOCV_DESCRIPCION = DESCRIPCION;			
		}

		public string TDOCC_CODIGO
		{
			set{_TDOCC_CODIGO= value;}
			get{return _TDOCC_CODIGO;}
		}

		public string TDOCV_DESCRIPCION
		{
			set{_TDOCV_DESCRIPCION= value;}
			get{return _TDOCV_DESCRIPCION;}
		}

		public string TDOCC_ESTADO
		{
			set{_TDOCC_ESTADO= value;}
			get{return _TDOCC_ESTADO;}
		}

		public int ID_INFOCORP
		{
			set{_ID_INFOCORP= value;}
			get{return _ID_INFOCORP;}
		}

		private int _ID_BSCS;
		public int ID_BSCS
		{
			set{_ID_BSCS= value;}
			get{return _ID_BSCS;}
		}

		public string ID_VALUES
		{
			get{return _ID_BSCS.ToString()+";"+_ID_INFOCORP.ToString()+";"+_TDOCC_CODIGO;}
		}
		public string ID_ABDCP
		{
			set{_ID_ABDCP= value;}
			get{return _ID_ABDCP;}
		}
		public string ID_DC_CORP
		{
			set{ _ID_DC_CORP = value; }
			get{return _ID_DC_CORP; }
		}
		public string COD_BSCS
		{
			set{_COD_BSCS = value;}
			get{return _COD_BSCS;}
		}
		public string COD_SGA
		{
			set{ _COD_SGA = value; }
			get{return _COD_SGA; }
		}
	}
}
