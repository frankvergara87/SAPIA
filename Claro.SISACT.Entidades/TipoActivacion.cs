using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TipoActivacion.
	/// Author: Miguel Ayll�n Samaniego
	/// </summary>
	public class TipoActivacion
	{
		//Tomado de los campos de la tabla
		//sect_tipo_activacion
		
		//C�digo de Tipo de Activaci�n
		private string _TACTC_CODIGO;
		//Descripci�n de Tipo de Activaci�n
		private string _TACTV_DESCRIPCION;
		//Estado de registro de Tipo de Activaci�n
		private string _TACTC_ESTADO;
		
		
		public TipoActivacion()
		{
		}

		public string TACTC_CODIGO
		{
			set { _TACTC_CODIGO=value;}
			get { return _TACTC_CODIGO;}
		}
		public string TACTV_DESCRIPCION
		{
			set { _TACTV_DESCRIPCION=value;}
			get { return _TACTV_DESCRIPCION;}
		}
		public string TACTC_ESTADO
		{
			set { _TACTC_ESTADO=value;}
			get { return _TACTC_ESTADO;}
		
		}
	}
}
