using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for BLCanalPDV.
	/// </summary>
	public class BLCanalPDV
	{
		private int _ID;
		private string _COD_CANAL;
		private string _DES_CANAL;
		private string _COD_PDV;
		private string _DES_PDV;
		private string _ESTADO;
		private string _USUARIO_REG;
		private string _FECHA_REG;
		private string _ORDEN;

		public BLCanalPDV(){}
	
		public int ID
		{
			get{ return _ID;}
			set{ _ID = value;}
		}
		public string COD_CANAL
		{
			get{ return _COD_CANAL;}
			set{ _COD_CANAL = value;}
		}
		public string DES_CANAL
		{
			get{ return _DES_CANAL;}
			set{ _DES_CANAL = value;}
		}
		public string COD_PDV
		{
			get{ return _COD_PDV;}
			set{ _COD_PDV= value;}
		}
		public string DES_PDV
		{
			get{ return _DES_PDV;}
			set{ _DES_PDV= value;}
		}
		public string ESTADO
		{
			get{ return _ESTADO;}
			set{ _ESTADO= value;}
		}
		public string USUARIO_REG
		{
			get{ return _USUARIO_REG;}
			set{ _USUARIO_REG= value;}
		}
		public string FECHA_REG
		{
			get{ return _FECHA_REG;}
			set{ _FECHA_REG= value;}
		}
		public string ORDEN
		{
			get{ return _ORDEN;}
			set{ _ORDEN= value;}
		}
		
	}
}
