using System;
using System.Data; 
using Claro.SisAct.Datos;

namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Descripción breve de LBilletera.
	/// </summary>
	public class LBilletera
	{
		public LBilletera()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
        
        # region "Consultas"
        
        public DataTable ListarBilleterasActivas()
        {
            DBilletera obj = new DBilletera();        
            return obj.ListarBilleterasActivas();	
        }

        public DataTable ListarBilleterasList(string P_BILLETERA, string P_ESTADO)
        {
            DBilletera obj = new DBilletera();        
            DataTable listBilleteras = obj.ListarBilleterasLista(P_BILLETERA, P_ESTADO);	
            DataTable headerResultado = obj.ListarBilleterasActivas();
            
            DataTable tblResultado = new DataTable();
            
            //Primera Columna
            tblResultado.Columns.Add("CODIGO",typeof(string));
            tblResultado.Columns.Add("COMBINACIONES",typeof(string));
            //Columnas Dinamicas
            for (int i=0; i < headerResultado.Rows.Count; i++){
                tblResultado.Columns.Add(headerResultado.Rows[i]["PRCLV_DESCRIPCION"].ToString().ToUpper(),typeof(string));
            }
            //Ultima Columna
            tblResultado.Columns.Add("ESTADO",typeof(string));

            //Carga de filas
            string billetera = string.Empty;
            string codBilletera = string.Empty;
            string billeteraCombinada = string.Empty;
            DataRow dr = null;
            for (int i=0; i < listBilleteras.Rows.Count; i++)
            {
                
                string codigo = listBilleteras.Rows[i]["PRCLN_CODIGO"].ToString();
                string porcentFact = string.Format("{0:0.00}", decimal.Parse(listBilleteras.Rows[i]["PRCLN_FACTOR_FACT"].ToString()));
                string flgBase = listBilleteras.Rows[i]["PRCLC_FLG_BASE"].ToString();

                billetera = listBilleteras.Rows[i]["PRCLV_DESCRIPCION"].ToString();   

                if(!codBilletera.Equals(codigo))
                {
                    if(i > 0){
                        dr[0] = codBilletera;
                        dr[1] = billeteraCombinada;
                        dr[headerResultado.Rows.Count + 2] = (listBilleteras.Rows[i]["PRCLC_ESTADO"].ToString().Equals("1")) ? "ACTIVO" : "DESACTIVO";
                        tblResultado.Rows.Add(dr);    
                    }
                    dr = tblResultado.NewRow();
                    billeteraCombinada = billetera; 
                    codBilletera = codigo;
                }
                else{
                    billeteraCombinada += " + " + billetera;
                }

                //recorre la columna para pintar la facturacion
                for (int j=0; j < headerResultado.Rows.Count; j++)
                {
                    string columnBilletera = headerResultado.Rows[j]["PRCLV_DESCRIPCION"].ToString();
                    if(columnBilletera.Equals(billetera))
                    {
                        dr[j + 2] = porcentFact;
                        break;
                    }
                }  

                if(i == listBilleteras.Rows.Count - 1){
                    dr[0] = codBilletera;
                    dr[1] = billeteraCombinada;
                    dr[headerResultado.Rows.Count + 2] = (listBilleteras.Rows[i]["PRCLC_ESTADO"].ToString().Equals("1")) ? "ACTIVO" : "DESACTIVO";
                    tblResultado.Rows.Add(dr);                 
                }                
            }
            return tblResultado;
        }


        public DataTable ObtenerBilleteras(int P_CODIGO)
        {
            DBilletera obj = new DBilletera();        
            return obj.ObtenerBilleteras(P_CODIGO);	
        }

        #endregion


        #region Transacciones

        public bool ModificarPorcentaje(decimal P_PORCENTAJE, int P_CODIGO, int P_CODIGO_BASE)
        {
            DBilletera obj = new DBilletera(); 
            return obj.ModificarPorcentaje(P_PORCENTAJE, P_CODIGO, P_CODIGO_BASE);
        }


        public int AgregarPorcentaje(int P_CODIGO, string P_DESCRIPCION, int P_CODIGO_BASE, decimal P_PORCENTAJE, string P_USUARIO)
        {
            DBilletera obj = new DBilletera(); 
            return obj.AgregarPorcentaje(P_CODIGO, P_DESCRIPCION, P_CODIGO_BASE, P_PORCENTAJE, P_USUARIO);
        }

        public bool ModificarEstadoBilleteras(string P_BILLETERAS, string P_ESTADO){
            DBilletera obj = new DBilletera(); 
            return obj.ModificarEstadoBilleteras(P_BILLETERAS, P_ESTADO);
        }

        #endregion



	}    
}
