using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for TipoDocumento.
	/// </summary>
	[Serializable]
	public class Parametro
	{
		private Int64 _codigo;
		private string _descripcion;		
		private string _valor;		
		private string _valor1;		
		private string _estado;
		private string _grupo;
		private string _grupo_des;
		private string _estado_des;
		private string _flag_sistema;
		public Parametro()
		{
			//
			// TODO: Add constructor logic here
			//
		}		
		public Int64 Codigo
		{
			set{_codigo= value;}
			get{ return _codigo;}
		}
		public string Descripcion
		{
			set{_descripcion= value;}
			get{ return _descripcion;}
		}
		public string Valor
		{
			set{_valor= value;}
			get{ return _valor;}
		}
		public string Valor1
		{
			set{_valor1= value;}
			get{ return _valor1;}
		}
		public string estado
		{
			set{_estado= value;}
			get{ return _estado;}
		}

		public string Grupo
		{
			set{_grupo= value;}
			get{ return _grupo;}
		}
		public string Grupo_Des
		{
			set{_grupo_des= value;}
			get{ return _grupo_des;}
		}
		
		public string Estado_Des
		{
			set{_estado_des= value;}
			get{ return _estado_des;}
		}
		public string flag_sistema
		{
			set{_flag_sistema= value;}
			get{ return _flag_sistema;}
		}
		
	}
}
