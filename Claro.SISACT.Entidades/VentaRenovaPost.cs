using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Descripción breve de VentaRenovaPost.
	/// </summary>
	public class VentaRenovaPost
	{
		private DateTime _fecha_registro;
		private string _correo;
		private string _plan_actual;
		private string _plan_nuevo;
		private string _tope_consumo;
		private double _limite_credito;
		private string _ciclo_fact;
		private string _iter_cambio_plan;
		private DateTime _fecha_pago;
		private string _flag_fidelizado_retenido;
		private string _tipo_renovacion;
		private int _flag_exoneracion;
		private int _flag_descuento;
		private string _oficina;
		private string _titular;
		private string _representante;
		private string _telefono;
		private string _interaccion;
		private string _tipo_documento;
		private string _doc_clien_numero;
		private string _vendedor;
		private string _servidor;
		private string _canal;
		private Int64 _numero_sec;
		private double _renof_cactual;
		private double _renof_cnuevo;
		private string _usuario_validador;
		private string _numero_factura;
		private string _numero_contrato;
		private string _numero_pedido;
		private decimal _descuento;
		private string _renof_Flaggener;

	        //inicio whzr 05112014
		private string _num_vendedor;
		private string _nom_vendedor;
		//fin whzr 05112014
                private int _flag_renovacion_y_chip;

		//consolidado 03012015
		private string _mot_tip_renovchip;
		//consolidado 03012015


		public VentaRenovaPost(){}

		//consolidado 03012015
		public string mot_tip_renovchip
		{
			set{_mot_tip_renovchip = value;}
			get{return _mot_tip_renovchip;}
		}
		//consolidado 03012015

		//inicio whzr 05112014
		public string num_vendedor
		{
			set{_num_vendedor = value;}
			get{return _num_vendedor;}
		}
		public string nom_vendedor
		{
			set{_nom_vendedor = value;}
			get{return _nom_vendedor;}
		}
		//fin whzr 05112014
		public string flag_fidelizado_retenido
		{
			set{_flag_fidelizado_retenido = value;}
			get{return _flag_fidelizado_retenido;}
		}

		public DateTime fecha_registro
		{
			set{_fecha_registro = value;}
			get{return _fecha_registro;}
		}
		
		public string correo
		{
			set{_correo = value;}
			get{return _correo;}
		}

		public string plan_actual
		{
			set{_plan_actual = value;}
			get{return _plan_actual;}
		}

		public string plan_nuevo
		{
			set{_plan_nuevo = value;}
			get{return _plan_nuevo;}
		}

		public string tope_consumo
		{
			set{_tope_consumo = value;}
			get{return _tope_consumo;}
		}
		
		public double limite_credito
		{
			set{_limite_credito = value;}
			get{return _limite_credito;}
		}

		public string ciclo_fact
		{
			set{_ciclo_fact = value;}
			get{return _ciclo_fact;}
		}

		public string iter_cambio_plan
		{
			set{_iter_cambio_plan = value;}
			get{return _iter_cambio_plan;}
		}
		
		public DateTime fecha_pago
		{
			set{_fecha_pago = value;}
			get{return _fecha_pago;}
		}

		public string tipo_renovacion
		{
			set{_tipo_renovacion = value;}
			get{return _tipo_renovacion;}
		}

		public int flag_exoneracion
		{
			set{_flag_exoneracion = value;}
			get{return _flag_exoneracion;}
		}

		public int flag_descuento
		{
			set{_flag_descuento = value;}
			get{return _flag_descuento;}
		}

		public string oficina
		{
			set{_oficina = value;}
			get{return _oficina;}
		}

		public string titular
		{
			set{_titular = value;}
			get{return _titular;}
		}

		public string representante
		{
			set{_representante = value;}
			get{return _representante;}
		}

		public string telefono
		{
			set{_telefono = value;}
			get{return _telefono;}
		}

		public string interaccion
		{
			set{_interaccion = value;}
			get{return _interaccion;}
		}
		
		public string tipo_documento
		{
			set{_tipo_documento = value;}
			get{return _tipo_documento;}
		}

		public string doc_clien_numero
		{
			set{_doc_clien_numero = value;}
			get{return _doc_clien_numero;}
		}
		
		public string vendedor
		{
			set{_vendedor = value;}
			get{return _vendedor;}
		}

		public string servidor
		{
			set{_servidor = value;}
			get{return _servidor;}
		}

		public string canal
		{
			set{_canal = value;}
			get{return _canal;}
		}

		public Int64 numero_sec
		{
			set{_numero_sec = value;}
			get{return _numero_sec;}
		}

		public double renof_cactual
		{
			set{_renof_cactual = value;}
			get{return _renof_cactual;}
		}

		public double renof_cnuevo
		{
			set{_renof_cnuevo = value;}
			get{return _renof_cnuevo;}
		}

		public string usuario_validador
		{
			set{_usuario_validador = value;}
			get{return _usuario_validador;}
		}

		public string numero_factura
		{
			set{_numero_factura = value;}
			get{return _numero_factura;}
		}

		public string numero_contrato
		{
			set{_numero_contrato = value;}
			get{return _numero_contrato;}
		}

		public string numero_pedido
		{
			set{_numero_pedido = value;}
			get{return _numero_pedido;}
		}

		public decimal descuento
		{
			set{_descuento = value;}
			get{return _descuento;}
		}

		public string renof_Flaggener
		{
			set{_renof_Flaggener = value;}
			get{return _renof_Flaggener;}
		}

		public int flag_renovacion_y_chip
		{
			set{_flag_renovacion_y_chip = value;}
			get{return _flag_renovacion_y_chip;}
		}

		//20151029UB
		private string _VigenciaPlan;
		public string VigenciaPlan
		{
			set{_VigenciaPlan = value;}
			get{return _VigenciaPlan;}
		}
		//20151029UB
	}
}
