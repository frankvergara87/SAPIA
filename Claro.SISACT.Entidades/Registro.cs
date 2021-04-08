using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de Registro.
	/// </summary>
	public class Registro
	{
		private DateTime _fecha_creacion;
		private DateTime _fecha_modificacion;
		private string _usuario_creacion;
		private string _usuario_modificacion;
		private string _activo;
		private int _orden;

		public Registro()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public DateTime FECHA_CREACION
		{
			set{_fecha_creacion = value;}
			get{ return _fecha_creacion;}
		}

		public DateTime FECHA_MODIFICACION
		{
			set{_fecha_modificacion = value;}
			get{ return _fecha_modificacion;}
		}

		public string USUARIO_CREACION
		{
			set{_usuario_creacion = value;}
			get{ return _usuario_creacion;}
		}

		public string USUARIO_MODIFICACION
		{
			set{_usuario_modificacion = value;}
			get{ return _usuario_modificacion;}
		}

		public string ACTIVO
		{
			set{_activo = value;}
			get{ return _activo;}
		}

		public int ORDEN
		{
			set{_orden = value;}
			get{ return _orden;}
		}


	}
}
