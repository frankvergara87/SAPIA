using System;

namespace Claro.SisAct.Entidades
{
	public class HistorialDataCreditoRepLegCorp
	{
		
		public HistorialDataCreditoRepLegCorp()	{}
		
		#region Representante Legal
		
		private string _ws53_In_NumeroOperacionRepLeg = "";
		private string _ws53_Out_RepresentanteLegalTipoPersona = "";
		private string _ws53_Out_RepresentanteLegalTipoDocumento = "";
		private string _ws53_Out_RepresentanteLegalNumeroDocumento = "";
		private string _ws53_Out_RepresentanteLegalNombre = "";
		private string _ws53_Out_RepresentanteLegalCargo = "";

		public string ws53_In_NumeroOperacionRepLeg
		{
			set{ _ws53_In_NumeroOperacionRepLeg = value; }
			get{ return _ws53_In_NumeroOperacionRepLeg; }
		}
		public string ws53_Out_RepresentanteLegalTipoPersona
		{
			set{ _ws53_Out_RepresentanteLegalTipoPersona = value; }
			get{ return _ws53_Out_RepresentanteLegalTipoPersona; }
		}
		public string ws53_Out_RepresentanteLegalTipoDocumento
		{
			set{ _ws53_Out_RepresentanteLegalTipoDocumento = value; }
			get{ return _ws53_Out_RepresentanteLegalTipoDocumento; }
		}
		public string ws53_Out_RepresentanteLegalNumeroDocumento
		{
			set{ _ws53_Out_RepresentanteLegalNumeroDocumento = value; }
			get{ return _ws53_Out_RepresentanteLegalNumeroDocumento; }
		}
		public string ws53_Out_RepresentanteLegalNombre
		{
			set{ _ws53_Out_RepresentanteLegalNombre = value; }
			get{ return _ws53_Out_RepresentanteLegalNombre; }
		}
		public string ws53_Out_RepresentanteLegalCargo
		{
			set{ _ws53_Out_RepresentanteLegalCargo = value; }
			get{ return _ws53_Out_RepresentanteLegalCargo; }
		}
		
		#endregion

	}
}
