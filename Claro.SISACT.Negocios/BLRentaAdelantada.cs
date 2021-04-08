using System;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;
using Claro.SisAct.Datos;
using System.Data;
using System.Collections;

namespace Claro.SisAct.Negocios
{
	public class BLRentaAdelantada
	{
		public BLRentaAdelantada()
		{
		}

		public BERentaAdelantada GrabarRentaAdelantadaPVUDB(BERentaAdelantada ra)
		{
			return new DARentaAdelantada().GrabarRentaAdelantadaPVUDB(ra);
		}

public void obtenerSKURentaAdelantada(string p_cod_pdv, double p_precio, ref string p_sku)
		{
			DARentaAdelantada obj = new DARentaAdelantada();
			obj.obtenerSKURentaAdelantada(p_cod_pdv, p_precio, ref p_sku);
		}

		public string GrabarRentaAdelantadaSISCAD(BERentaAdelantada ra)
		{
			DARentaAdelantada obj = new DARentaAdelantada();
			return obj.GrabarRentaAdelantadaSISCAD(ra);
		}

public bool actualizaVendedor(string p_nroSap, string dniVendedor, string nomVendedor, string codPago, string codSinergia, ref string msg_resp)
		{
			DARentaAdelantada obj = new DARentaAdelantada();
			return obj.actualizaVendedor(p_nroSap, dniVendedor, nomVendedor, codPago, codSinergia,ref msg_resp);
		}

public void actualizarUbigeo(Int64 pSolinCodigo, string numDocumento, ref string msg_resp)
		{
			DARentaAdelantada obj = new DARentaAdelantada();
			obj.actualizarUbigeo(pSolinCodigo, numDocumento, ref msg_resp);
		}


	}
}
