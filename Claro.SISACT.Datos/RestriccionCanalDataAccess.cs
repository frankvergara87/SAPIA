

using System;
using System.Data;
using System.Collections;
using System.Configuration; 
using Claro.SisAct.DAAB;
using Claro.SisAct.Entidades;
using Claro.SisAct.Common;

namespace Claro.SisAct.Datos
{
	/// <summary>
	/// Summary description for RestriccionCanalDataAccess.
	/// </summary>
	public class RestriccionCanalDataAccess
	{
		public RestriccionCanalDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable fdtbListarTipoOficina()
		{
			DataTable oDataTable=new DataTable();
			oDataTable.Columns.Add("TOFIC_CODIGO");
			oDataTable.Columns.Add("TOFIV_DESCRIPCION");

			DataRow oDataRow =  oDataTable.NewRow();
			oDataRow[0]=1;
			oDataRow[1]="Canal 1";
			oDataTable.Rows.Add(oDataRow);

			DataRow oDataRow1 =  oDataTable.NewRow();
			oDataRow1[0]=2;
			oDataRow1[1]="Canal 2";
			oDataTable.Rows.Add(oDataRow1);

			DataRow oDataRow2 =  oDataTable.NewRow();
			oDataRow2[0]=3;
			oDataRow2[1]="Canal 3";
			oDataTable.Rows.Add(oDataRow2);

			return oDataTable;
		}

		public ArrayList ListarCanal(string strCanales,string strCodigo,string strDescripcion)
		{
			ArrayList ListaCanal=new ArrayList();
			Canal oCanal;

			//PuntoVenta oPuntoVenta;//=new PuntoVenta();
			for(int i=0;i<15;i++)
			{
				oCanal = new Canal();
				//oPuntoVenta=new PuntoVenta();
				oCanal.CANAC_CODIGO="CANAL" + i+1;
				oCanal.CANAV_DESCRIPCION=" DESCRIPCION CANAL " + i+1;
				oCanal.TPROC_CODIGO="CODIGO" + i+1;

				ListaCanal.Add(oCanal);
			}

			return ListaCanal;
		}

		public DataTable fdtbListarPDVTotal(string strCanales,string strCodigo,string strDescripcion)
		{
			DataTable oDataTable=new DataTable();
			oDataTable.Columns.Add("OVENC_CODIGO");
			oDataTable.Columns.Add("OVENV_DESCRIPCION");
			oDataTable.Columns.Add("CANAC_CODIGO");

			for(int i=0;i<15;i++)
			{
				DataRow oDataRow =  oDataTable.NewRow();
				oDataRow[0]="CANAL " + i+1;
				oDataRow[1]="Descripcion CANAL  " + i+1;
				oDataRow[2]="Codigo Canal CANAL  " + i+1;
				oDataTable.Rows.Add(oDataRow);
			}
			return oDataTable;
		}





		public DataTable fdtbListarPDV(string strCodigo,string Pdv)
		{
			DataTable oDataTable=new DataTable();
			oDataTable.Columns.Add("OVENC_CODIGO");
			oDataTable.Columns.Add("OVENV_DESCRIPCION");
			oDataTable.Columns.Add("CANAC_CODIGO");

			DataRow oDataRow =  oDataTable.NewRow();
			oDataRow[0]="Canal Codigo 1";
			oDataRow[1]="CAC";
			oDataRow[2]="Codigo Canal 1";
			oDataTable.Rows.Add(oDataRow);

			DataRow oDataRow1 =  oDataTable.NewRow();
			oDataRow1[0]="Canal Codigo 2";
			oDataRow1[1]="CADENA";
			oDataRow1[2]="Codigo Canal 2";
			oDataTable.Rows.Add(oDataRow1);

			DataRow oDataRow2 =  oDataTable.NewRow();
			oDataRow2[0]="Canal Codigo 3";
			oDataRow2[1]="DAC";
			oDataRow2[2]="Codigo Canal 3";
			oDataTable.Rows.Add(oDataRow2);

			DataRow oDataRow3 =  oDataTable.NewRow();
			oDataRow3[0]="Canal Codigo 4";
			oDataRow3[1]="VENTA CORPORATIVA";
			oDataRow3[2]="Codigo Canal 4";
			oDataTable.Rows.Add(oDataRow3);

			return oDataTable;
		}
	}
}
