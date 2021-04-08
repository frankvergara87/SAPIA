using System.Data;
namespace Claro.SisAct.DAAB
	{ 

	/// <summary>
	/// Summary description for DAABDataReader.
	/// </summary>
	public abstract class DAABDataReader 
	{ 

		public abstract IDataReader ReturnDataReader 
		{ 
			get; 
			set; 
		} 
	}
	}

