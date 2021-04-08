using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for PlazoAcuerdo.
	/// Author: Miguel Ayllón Samaniego
	/// </summary>
	public class PlazoAcuerdo
	{
		//Tomado de los campos de la tabla
		//sect_plazo_acuerdo			
		
		//Código de Plazo de Acuerdo
		private string _PACUC_CODIGO;
		//Código de Tipo de Producto
		private string _TPROC_CODIGO;
		//Descripción de Plazo de Acuerdo
		private string _PACUV_DESCRIPCION;
		//Estado de registro de Plazo de Acuerdo
		private string _PACUC_ESTADO;
		
		public PlazoAcuerdo()
		{		
		}

		public string PACUC_CODIGO
		{
			set{ _PACUC_CODIGO = value;}
			get{ return _PACUC_CODIGO;}
		}

		public string TPROC_CODIGO
		{
			set{ _TPROC_CODIGO = value;}
			get{ return _TPROC_CODIGO;}
		}

		public string PACUV_DESCRIPCION
		{
			set{ _PACUV_DESCRIPCION = value;}
			get{ return _PACUV_DESCRIPCION;}
		}

		public string PACUC_ESTADO
		{
			set{ _PACUC_ESTADO= value;}
			get{ return _PACUC_ESTADO;}
		}

	}
}
