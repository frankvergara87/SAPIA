using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for Usuario.
	[Serializable]
	public class Linea  
	{
		private Int64 _nro_sec;
		private Int64 _customer_id;
		private Int64 _co_id;
		private Int64 _contrato_id;
		private string _custcode;
		private int _linea_id;
		private string _nro_telefono;
		private string _simcard;
		private DateTime _fecha_activacion;
		private string _flag_existe_bscs;
		private string _imei;
		private string _plan_des;
		private int _plan_id;		
		private string _plazo_id;
		private int _plazo_equipo_id;
		private string _plazo_equipo_des;

		private int _promocion_id;
		private string _promocion_des;
		private int _vendedor_id;
		private string _vendedor_des;


		private string _plazo_des;
		private string _paquete_des;
		private string _tipo_producto_id;
		private string _paquete_id;
		private string _datos_linea;
		private string _lista_servicios;
		private string _lista_bolsas;
		private string _lista_paquetes;

		private double _cargo_fijo;
		private double _cargo_fijo_igv;
		private string _tipo_descuento_id ;
		private string _tipo_descuento_des ;
		private double _descuento;
		private double _cargo_final;
		private double _cargo_final_igv;
		private string _almacen_id;
		private string _almacen_des;
		private string _oficina_venta_id;
		private string _oficina_venta_des;
		
		private string _estado;
		private string _estado_des;
		private string _des_error;

		private string _material_id;
		private string _material_des;

		private ArrayList _detalle_servicio;
		private ArrayList _detalle_bolsas;

		private string _unidad_tope;
		private string _monto_tope;
		private string _monto_tope_adicional;
		
		//plan especial: email to sms
		private string _dominio_email_sms;
		private string _ip_email_sms;
		private string _telefono_email_sms;
		private string _estado_reg_email_sms;
		private string _estado_proc_email_sms;
		private string _nroSec_email_sms;
		//Nuevas Funcionalidades Fase2
		private string _TelfActivado;//Omar Garcia

		//E75559
		private string _nro_hrl;
		private string _cantidad_hlr;
		private string _cedente;
		private string _nroFolio;


		/// <summary>
		/// DOL
		/// </summary>
		private string _EsTFI;

		public Linea(){}
				
		public string cedente
		{
			set{_cedente= value;}
			get{return _cedente;}
		}

		public string nroFolio
		{
			set{_nroFolio= value;}
			get{return _nroFolio;}
		}

		public string nro_hrl
		{
			set{_nro_hrl= value;}
			get{return _nro_hrl;}
		}
		
		public string cantidad_hlr
		 {
			 set{_cantidad_hlr= value;}
			 get{return _cantidad_hlr;}
		 }
				
		public Int64 nro_sec
		{
			set{_nro_sec= value;}
			get{return _nro_sec;}
		}
		
		public Int64 customer_id
		{
			set{_customer_id= value;}
			get{return _customer_id;}
		}
		public Int64 co_id
		{
			set{_co_id= value;}
			get{return _co_id;}
		}
		public Int64 contrato_id
		{
			set{_contrato_id= value;}
			get{return _contrato_id;}
		}		
		public string custcode
		{
			set{_custcode= value;}
			get{return _custcode;}
		}
		public int linea_id
		{
			set{_linea_id = value;}
			get{return _linea_id;}
		}
		public string nro_telefono
		{
			set{_nro_telefono = value;}
			get{return _nro_telefono;}
		}
		public string SimCARD
		{
			set{_simcard = value;}
			get{return _simcard;}
		}
		public DateTime fecha_activacion
		{
			set{_fecha_activacion= value;}
			get{return _fecha_activacion;}
		}
		public string flag_existe_bscs
		{
			set{_flag_existe_bscs= value;}
			get{return _flag_existe_bscs;}
		}
		public string IMEI
		{
			set{_imei = value;}
			get{return _imei;}
		}
		public string plan_des
		{
			set{_plan_des = value;}
			get{return _plan_des;}
		}
		public int plan_id
		{
			set{_plan_id= value;}
			get{return _plan_id;}
		}
		public string plazo_des
		{
			set{_plazo_des= value;}
			get{return _plazo_des;}
		}
		public string plazo_id
		{
			set{_plazo_id = value;}
			get{return _plazo_id;}
		}
		public int plazo_equipo_id
		{
			set{_plazo_equipo_id= value;}
			get{return _plazo_equipo_id;}
		}
		public string plazo_equipo_des
		{
			set{_plazo_equipo_des = value;}
			get{return _plazo_equipo_des;}
		}
		public int promocion_id
		{
			set{_promocion_id= value;}
			get{return _promocion_id;}
		}
		public string promocion_des
		{
			set{_promocion_des= value;}
			get{return _promocion_des;}
		}
		public int vendedor_id
		{
			set{_vendedor_id = value;}
			get{return _vendedor_id;}
		}
		public string vendedor_des
		{
			set{_vendedor_des= value;}
			get{return _vendedor_des;}
		}
		public string tipo_producto_id
		{
			set{_tipo_producto_id= value;}
			get{return _tipo_producto_id;}
		}
		
		public string paquete_id
		{
			set{_paquete_id = value;}
			get{return _paquete_id ;}
		}
		public string paquete_des
		{
			set{_paquete_des = value;}
			get{return _paquete_des;}
		}
		
		public string datos_linea
		{
			set{_datos_linea= value;}
			get{return _datos_linea;}
		}
		public string lista_servicios
		{
			set{_lista_servicios= value;}
			get{return _lista_servicios;}
		}
		public string lista_paquetes
		{
			set{_lista_paquetes = value;}
			get{return _lista_paquetes;}
		}

		public string lista_bolsas
		{
			set{_lista_bolsas= value;}
			get{return _lista_bolsas;}
		}
		public double cargo_fijo
		{
			set{_cargo_fijo = value;}
			get{ return _cargo_fijo;}
		}
		public double cargo_fijo_igv
		{
			set{_cargo_fijo_igv= value;}
			get{ return _cargo_fijo_igv;}
		}
		public double cargo_final
		{
			set{_cargo_final= value;}
			get{ return _cargo_final;}
		}
		public double cargo_final_igv
		{
			set{_cargo_final_igv= value;}
			get{ return _cargo_final_igv;}
		}
		public double descuento
		{
			set{_descuento = value;}
			get{ return _descuento;}
		}

		public string tipo_descuento_id 
		{
			get{return _tipo_descuento_id; }
			set{_tipo_descuento_id = value;}
		}
		public string tipo_descuento_des 
		{
			get{return _tipo_descuento_des; }
			set{_tipo_descuento_des = value;}
		}
		public string almacen_id 
		{
			get{return _almacen_id; }
			set{_almacen_id = value;}
		}
		public string almacen_des 
		{
			get{return _almacen_des; }
			set{_almacen_des = value;}
		}

		public string oficina_venta_id 
		{
			get{return _oficina_venta_id; }
			set{_oficina_venta_id= value;}
		}
		public string oficina_venta_des
		{
			get{return _oficina_venta_des; }
			set{_oficina_venta_des= value;}
		}
		
		
		public string estado
		{
			get{return _estado; }
			set{_estado= value;}
		}
		public string estado_des
		{
			get{return _estado_des; }
			set{_estado_des= value;}
		}
		public string des_error
		{
			get{return _des_error; }
			set{_des_error= value;}
		}
		
		public ArrayList Detalle_Servicio
		{
			set{_detalle_servicio = value;}
			get{return _detalle_servicio;}
		}
		public ArrayList Detalle_Bolsas
		{
			set{_detalle_bolsas = value;}
			get{return _detalle_bolsas ;}
		}

		public string material_id 
		{
			get{return _material_id; }
			set{_material_id = value;}
		}
		public string material_des 
		{
			get{return _material_des; }
			set{_material_des = value;}
		}

		public string unidad_tope 
		{
			get{return _unidad_tope; }
			set{_unidad_tope = value;}
		}
		public string monto_tope 
		{
			get{return _monto_tope; }
			set{_monto_tope = value;}
		}
		public string monto_tope_adicional 
		{
			get{return _monto_tope_adicional; }
			set{_monto_tope_adicional = value;}
		}
		public string dominio_email_sms 
		{
			get{return _dominio_email_sms; }
			set{_dominio_email_sms = value;}
		}
		public string ip_email_sms 
		{
			get{return _ip_email_sms; }
			set{_ip_email_sms = value;}
		}
		public string telefono_email_sms 
		{
			get{return _telefono_email_sms; }
			set{_telefono_email_sms = value;}
		}
		public string estado_reg_email_sms 
		{
			get{return _estado_reg_email_sms; }
			set{_estado_reg_email_sms = value;}
		}
		public string estado_proc_email_sms 
		{
			get{return _estado_proc_email_sms; }
			set{_estado_proc_email_sms = value;}
		}
		public string nroSec_email_sms 
		{
			get{return _nroSec_email_sms; }
			set{_nroSec_email_sms = value;}
		}
		//Nuevas Funcionalidades Fase2
		public string TelfActivado 
		{
			get{return _TelfActivado; }
			set{_TelfActivado = value;}
		}

		/// <summary>
		/// DOL
		/// </summary>
		public string EsTFI
		{
			set{_EsTFI=value;}
			get{return _EsTFI;}
		}
	}
}