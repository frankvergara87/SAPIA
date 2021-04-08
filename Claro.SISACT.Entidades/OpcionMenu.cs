using System;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for OpcionMenu.
	/// </summary>
	public class OpcionMenu 
	{
		private int _aplicacion_id;
		private int _opcion_padre_id;
		private int _opcion_id;				
		private int _opcion_nivel_padre;
		private int _opcion_nivel;
		private string _opcion_des;
		private string _opcion_abrev;
		private string _opcion_nombre_pagina;
		private int _opcion_orden;
		private int _opcion_d1;
		private bool _tiene_hijos;
		private string _opcion_menu_script;

		public OpcionMenu(){}

		public int AplicacionId{
			get{return _aplicacion_id ;}
			set{_aplicacion_id = value;}
		}
		public int OpcionPadreId
		{
			get{return _opcion_padre_id ;}
			set{_opcion_padre_id = value;}
		}
		public int OpcionId
		{
			get{return _opcion_id ;}
			set{_opcion_id = value;}
		}
		public int OpcionNivelPadre
		{
			get{return _opcion_nivel_padre ;}
			set{_opcion_nivel_padre = value;}
		}
		public int OpcionNivel
		{
			get{return _opcion_nivel ;}
			set{_opcion_nivel = value;}
		}
		public string OpcionDes
		{
			get{return _opcion_des ;}
			set{_opcion_des = value;}
		}
		public string OpcionAbrev
		{
			get{return _opcion_abrev ;}
			set{_opcion_abrev = value;}
		}
		public string OpcionNombrePagina
		{
			get{return _opcion_nombre_pagina ;}
			set{_opcion_nombre_pagina = value;}
		}
		public int OpcionOrden
		{
			get{return _opcion_orden ;}
			set{_opcion_orden = value;}
		}
		public int OpcionD1
		{
			get{return _opcion_d1 ;}
			set{_opcion_d1 = value;}
		}
		public string OpcionMenuScript{
			get{return _opcion_menu_script;}
			set{_opcion_menu_script= value;}
		}
		public bool TieneHijos
		{
		
			set{_tiene_hijos= value;}
			get{return _tiene_hijos;}
		}	
	}
}
