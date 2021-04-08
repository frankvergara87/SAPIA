using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Documento.
	/// </summary>
	public class DetalleLineaMaterial
	{


		private string _DVPR_LINEA;
		private string _DVPR_COD_MATERIAL_CHIP;
		private string _DVPR_DES_MATERIAL_CHIP;



		public string LINEA
		{
			set{  _DVPR_LINEA= value;}
			get{ return _DVPR_LINEA;}
		}
		public string COD_MATERIAL_CHIP
		{
			set{  _DVPR_COD_MATERIAL_CHIP= value;}
			get{ return _DVPR_COD_MATERIAL_CHIP;}
		}
		public string DES_MATERIAL_CHIP
		{
			set{  _DVPR_DES_MATERIAL_CHIP= value;}
			get{ return _DVPR_DES_MATERIAL_CHIP;}
		}
		
		

	}
}
