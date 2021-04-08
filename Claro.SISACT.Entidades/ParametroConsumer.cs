using System;

namespace Claro.SisAct.Entidades
{
	public class ParametroConsumer
	{
		public ParametroConsumer()
		{
			
		}
		
		private string _CONFI_CODIGO;
		public string CONFI_CODIGO	{set { _CONFI_CODIGO=value;} get { return _CONFI_CODIGO;}}

		private string _PCONI_CODIGO;
		public string PCONI_CODIGO	{set { _PCONI_CODIGO=value;} get { return _PCONI_CODIGO;}}

		private string _PCONV_DESCRIPCION;
		public string PCONV_DESCRIPCION	{set { _PCONV_DESCRIPCION=value;} get { return _PCONV_DESCRIPCION;}}

		private string _PCONV_VALOR;
		public string PCONV_VALOR	{set { _PCONV_VALOR=value;} get { return _PCONV_VALOR;}}

		private Int16 _PCONI_FLAG_ACTIVO;
		public Int16 PCONI_FLAG_ACTIVO	{set { _PCONI_FLAG_ACTIVO=value;} get { return _PCONI_FLAG_ACTIVO;}}

		private string _PCONV_MENSAJE;
		public string PCONV_MENSAJE	{set { _PCONV_MENSAJE=value;} get { return _PCONV_MENSAJE;}}

	}
}
