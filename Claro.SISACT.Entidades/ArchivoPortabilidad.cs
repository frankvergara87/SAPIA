using System;

namespace Claro.SisAct.Entidades
{

	public class ArchivoPortabilidad
	{
		public ArchivoPortabilidad()
		{ }

		private int _ARCH_ID;
		public int ARCH_ID
		{
			set{_ARCH_ID = value;}
			get{ return _ARCH_ID;}
		}

		private int _SOLIN_CODIGO;
		public int SOLIN_CODIGO
		{
			set{_SOLIN_CODIGO = value;}
			get{ return _SOLIN_CODIGO;}
		}

		private string _ARCH_NOMBRE;
		public string ARCH_NOMBRE
		{
			set{_ARCH_NOMBRE = value;}
			get{ return _ARCH_NOMBRE;}
		}

		private string _ARCH_RUTA;
		public string ARCH_RUTA
		{
			set{_ARCH_RUTA = value;}
			get{ return _ARCH_RUTA;}
		}

		private string _FLAG_ESTADO;
		public string FLAG_ESTADO
		{
			set{_FLAG_ESTADO = value;}
			get{ return _FLAG_ESTADO;}
		}

		private string _ARCH_TIPO;
		public string ARCH_TIPO
		{
			set{_ARCH_TIPO = value;}
			get{ return _ARCH_TIPO;}
		}

		private ParametroPortabilidad _TIPO_ARCHIVO;
		public ParametroPortabilidad TIPO_ARCHIVO
		{
			set{_TIPO_ARCHIVO = value;}
			get{ return _TIPO_ARCHIVO;}
		}
	}
}
