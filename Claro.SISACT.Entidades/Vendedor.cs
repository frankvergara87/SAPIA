using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Vendedor.
	/// </summary>
	[Serializable]
	public class Vendedor
	{
		private Int64 _id;
		private string _nombre;
		private string _apellidos;
		private string _nombre_completo;
		private string _tipo_documento;
		private string _numero_documento;
		private string _fecha_nacimiento;
		private string _direccion;
		private string _fecha_registro;
		private string _fecha_modificacion;
		private string _verificacion_reniec;
		private string _motivo;
		private string _estado_id;
		private string _estado_desc;
		private string _distribuidor_id;
		private string _distribuidor_descripcion;
		private string _punto_venta_id;
		private string _punto_venta_descripcion;
		private string _usuario_registro_id;
		private string _usuario_modificacion_id;

		//Pablo Zea - Vendedores 20/05/2009 Inicio
		private Estado _estado;
		private Distribuidor _distribuidor;
		private PuntoVenta _punto_venta;
		private Usuario _usuario_reg;
		private Usuario _usuario_mod;
		private ArrayList _historial;
		private string _fecha_habilitado;
		private string _fecha_deshabilitado;
		//Pablo Zea - Vendedores 20/05/2009 Fin
	
		//T12646 Vendedores Inicio
		private string _flag_bl;
		private string _Id_Distribuidor;
		private string _Id_Distribuidor_Vendedor;
		//T12646 Vendedores Fin
		
		private string _numero_celular;
		private string _clave;

		private string _prov_exter;

		public Vendedor(){}

		public Vendedor(string vCodigo,string vDescripcion)
		{			
			_Id_Distribuidor_Vendedor = vCodigo;
			_nombre = vDescripcion;
		}

		public Int64 VendedorId
		{
			set{_id = value;}
			get{return _id;}
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
			get
			{
				if (_nombre != "" && _apellidos !="")
					_nombre_completo = _nombre + " " +_apellidos;
				return _nombre_completo;			
			}
		}
		public string TipoDocumento
		{
			set{_tipo_documento = value;}
			get{return _tipo_documento ;}
		}
		public string NumeroDocumento
		{
			set{_numero_documento = value;}
			get{return _numero_documento;}
		}
		public string FechaNacimiento
		{
			set{_fecha_nacimiento = value;}
			get{return _fecha_nacimiento;}
		}
		public string Direccion
		{
			set{_direccion = value;}
			get{return _direccion ;}
		}
		public string FechaRegistro
		{
			set{_fecha_registro = value;}
			get{return _fecha_registro;}
		}
		public string FechaModificacion
		{
			set{_fecha_modificacion = value;}
			get{return _fecha_modificacion;}
		}
		public string VerificacionReniec
		{
			set{_verificacion_reniec = value;}
			get{return _verificacion_reniec;}
		}
		public string Motivo
		{
			set{_motivo = value;}
			get{return _motivo;}
		}

		public string EstadoId
		{
			set{_estado_id = value;}
			get{return _estado_id ;}
		}
		public string EstadoDescripcion
		{
			set{_estado_desc = value;}
			get{return _estado_desc ;}
		}
		public string distribuidorId
		{
			set{_distribuidor_id = value;}
			get{return _distribuidor_id;}
		}
		public string PuntoVentaId
		{
			set{_punto_venta_id = value;}
			get{return _punto_venta_id;}
		}
		public string PuntoVentaDescripcion
		{
			set{ _punto_venta_descripcion = value; }
			get{ return _punto_venta_descripcion; }
		}
		public string DistribuidorDescripcion
		{
			set{ _distribuidor_descripcion = value; }
			get{ return _distribuidor_descripcion; }
		}
		public string UsuarioRegistroId
		{
			set{_usuario_registro_id = value;}
			get{return _usuario_registro_id;}
		}
		public string UsuarioModificacionId
		{
			set{_usuario_modificacion_id = value;}
			get{return _usuario_modificacion_id;}
		}
		
		//Pablo Zea - Vendedores 20/05/2009 Inicio
		public Estado Estado
		{
			set{ _estado = value; }
			get{ return _estado; }
		}
		public string EstadoDesc
		{
			set{ _estado.ESTAV_DESCRIPCION = value; }
			get{ return _estado.ESTAV_DESCRIPCION; }
		}
		public Distribuidor Distribuidor
		{
			set{ _distribuidor = value; }
			get{ return _distribuidor; }
		}
		public string DistribuidorDesc
		{
			set{ _distribuidor.DISTV_DESCRIPCION = value; }
			get{ return _distribuidor.DISTV_DESCRIPCION; }
		}
		public PuntoVenta PuntoVenta
		{
			set{ _punto_venta = value; }
			get{ return _punto_venta; }
		}
		public string PuntoVentaDesc
		{
			set{ _punto_venta.OVENV_DESCRIPCION = value; }
			get{ return _punto_venta.OVENV_DESCRIPCION; }
		}
		public Usuario UsuarioReg
		{
			set{ _usuario_reg = value; }
			get{ return _usuario_reg; }
		}
		public string UsuarioRegDesc
		{
			set{ _usuario_reg.NombreCompleto = value; }
			get{ return _usuario_reg.NombreCompleto; }
		}
		public Usuario UsuarioMod
		{
			set{ _usuario_mod = value; }
			get{ return _usuario_mod; }
		}
		public string UsuarioModDesc
		{
			set{ _usuario_mod.NombreCompleto = value; }
			get{ return _usuario_mod.NombreCompleto; }
		}
		public ArrayList Historial
		{
			set{ _historial = value; }
			get{ return _historial; }
		}
		public string FechaHabilitado
		{
			set{_fecha_habilitado = value;}
			get{return _fecha_habilitado;}
		}
		public string FechaDeshabilitado
		{
			set{_fecha_deshabilitado = value;}
			get{return _fecha_deshabilitado;}
		}
		//Pablo Zea - Vendedores 20/05/2009 Fin

		//T12646 Vendedores Inicio
		public string Flag_bl
		{
			set{_flag_bl = value;}
			get{return _flag_bl;}
		}
		public string Id_Distribuidor
		{
			set{_Id_Distribuidor = value;}
			get{return _Id_Distribuidor;}
		}
		public string Id_Distribuidor_Vendedor
		{
			set{_Id_Distribuidor_Vendedor = value;}
			get{return _Id_Distribuidor_Vendedor;}
		}		
		//T12646 Vendedores Fin

		public string NumeroCelular
		{
			set{_numero_celular = value;}
			get{return _numero_celular;}
		}

		public string Clave
		{
			set{_clave = value;}
			get{return _clave;}
		}
	
		
		public string Prov_exter
		{
			set{_prov_exter = value;}
			get{return _prov_exter;}
		}
	
	}
}


