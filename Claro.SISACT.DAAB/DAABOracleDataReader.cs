using System.Data; 

namespace Claro.SisAct.DAAB
{ 
	
	public class DAABOracleDataReader : DAABDataReader 
	{ 
		IDataReader m_oReturnedDataReader; 

		public override System.Data.IDataReader ReturnDataReader 
		{ 
			get 
			{ 
				return m_oReturnedDataReader; 
			} 
			set 
			{ 
				m_oReturnedDataReader = value; 
			} 
		} 
	}
}