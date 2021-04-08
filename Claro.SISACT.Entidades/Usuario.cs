using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Usuario.
	/// </summary>
	public class Usuario  
	{
		private Int64 _id;
		private string _login;
		private string _nombre;
		private string _apellidos;
		private string _nombre_completo;
		private string _area_usuario;
		private string _perfil;
		private bool _flag_consulta;
		private ArrayList _opciones_seguridad;
		private string _opciones_menu;
		private string _email;
		private string _telefono;
		//Pmarcos Inicio
		private string _CtaRed;
		private string _OficinaId;
		private string _OficinaDes;
		private string _Estado;
		private string _TipoUsuario;
		private string _distribuidorId;
		private string _CodigoBSCS;

		//Pmarcos Fin
		//E75606 - Venta Express Inicio
		private string _codigoVendedor;
		//E75606 - Venta Express Fin

		private string _TipoOficinaId;

		public Usuario(){}
		public Usuario(Int64 id,string login, string apellidos,string nombre)
		{
			_id = id;
			_login = login;
			_apellidos = apellidos;
			_nombre = nombre;
		}
		public Usuario(Int64 id,string login, string apellidos,string nombre,string email)
		{
			_id = id;
			_login = login;
			_apellidos = apellidos;
			_nombre = nombre;
			_email = email;
		}
		public Usuario(string login, string nombre_completo,string email)
		{
			_login = login;
			_nombre_completo= nombre_completo;
			_email = email;
		}
		public Usuario(Int64 id, string nombre)
		{
			_id = id;
			_nombre= nombre;		
		}
		public Int64 UsuarioId{
			set{_id = value;}
			get{return _id;}
		}
		
		public string Login
		{
			set{_login = value;}
			get{return _login;}
		}
		public string Nombre
		{
			set{_nombre = value;}
			get{return _nombre;}
		}
		public string Apellidos
		{
			set{_apellidos = value;}
			get{return _apellidos;}
		}
		public string NombreCompleto
		{
			set{_nombre_completo = value;}
			get{
				if (_nombre != "" && _apellidos !="")
					_nombre_completo = _nombre + " " +_apellidos;
				return _nombre_completo;			
			}
		}

		public string AreaUsuario
		{
			set{_area_usuario = value;}
			get{return _area_usuario;}
		}
		public string Perfil
		{
			set{_perfil = value;}
			get{return _perfil;}
		}
		public bool FlagConsulta
		{
			set{_flag_consulta = value;}
			get{return _flag_consulta;}
		}		
		public string OpcionesMenu
		{
			set{_opciones_menu = value;}
			get{return _opciones_menu;}
		}		
		public string Email
			{
				set{_email= value;}
				get{return _email;}
			}	
		public string Telefono
		{
			set{_telefono= value;}
			get{return _telefono;}
		}	
		public ArrayList OpcionesSeguridad{
		
			set{_opciones_seguridad= value;}
			get{return _opciones_seguridad;}
		}		
		//Pmarcos INicio
		public string CtaRed
		{
			set{_CtaRed= value;}
			get{return _CtaRed;}
		}
		public string OficinaId
		{
			set{_OficinaId= value;}
			get{return _OficinaId;}
		}	
		public string OficinaDes
		{
			set{_OficinaDes= value;}
			get{return _OficinaDes;}
		}
		public string Estado
		{
			set{_Estado= value;}
			get{return _Estado;}
		}
			
		public string TipoUsuario
		{
			set{_TipoUsuario= value;}
			get{return _TipoUsuario;}
		}
		public string distribuidorId
		{
			set{_distribuidorId= value;}
			get{return _distribuidorId;}
		}
		//Pmarcos Fin
		public string CodigoBSCS
		{
			set{_CodigoBSCS= value;}
			get{return _CodigoBSCS;}
		}				
				
		//E75606 - Venta Express Inicio
		public string CodigoVendedor
		{
			set{ _codigoVendedor = value; }
			get{ return _codigoVendedor; }
		}
		//E75606 - Venta Express Fin

		public string TipoOficinaId
		{
			set{_TipoOficinaId = value;}
			get{return _TipoOficinaId;}
		}
	}
}