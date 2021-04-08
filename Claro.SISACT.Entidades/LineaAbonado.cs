using System;
using System.Collections;

namespace Claro.SisAct.Entidades
{
	/// <summary>
	/// Summary description for LineaAbonado.
	/// </summary>
	public class LineaAbonado
	{
		private string _nro_telefono = string.Empty;

		public string Nro_telefono
		{
			get { return _nro_telefono; }
			set { _nro_telefono = value; }
		}
		private string _nro_documento = string.Empty;

		public string Nro_documento
		{
			get { return _nro_documento; }
			set { _nro_documento = value; }
		}
		private string _tipo_documento = string.Empty;

		public string Tipo_documento
		{
			get { return _tipo_documento; }
			set { _tipo_documento = value; }
		}
		private string _nombres = string.Empty;

		public string Nombres
		{
			get { return _nombres; }
			set { _nombres = value; }
		}
		private string _apellidos = string.Empty;

		public string Apellidos
		{
			get { return _apellidos; }
			set { _apellidos = value; }
		}

		private string _plan_tarifario= string.Empty;
		public string Plan_tarifario
		{
			get { return _plan_tarifario; }
			set { _plan_tarifario = value; }
		}

		private string _segmento = string.Empty;

		public string Segmento
		{
			get { return _segmento; }
			set { _segmento = value; }
		}

		private string _create_date = string.Empty;

		public string Create_date
		{
			get { return _create_date; }
			set { _create_date = value; }
		}

		private string _estado = string.Empty;

		public string Estado
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		private string _fecha_activacion = string.Empty;

		public string Fecha_activacion
		{
			get { return _fecha_activacion; }
			set { _fecha_activacion = value; }
		}

		public LineaAbonado()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
