using System.Data; 
using System.Xml; 
using System;
namespace Claro.SisAct.DAAB
{
	public abstract class DAABAbstracFactory : IDisposable 
	{ 

		public abstract int ExecuteNonQuery(ref DAABRequest Request); 

		public abstract DataSet ExecuteDataset(ref DAABRequest Request); 

		public abstract void FillDataset(ref DAABRequest Request); 

		public abstract void UpdateDataSet(ref DAABRequest RequestInsert, ref DAABRequest RequestUpdate, ref DAABRequest RequestDelete); 

		public abstract DAABDataReader ExecuteReader(ref DAABRequest Repuest); 

		public abstract object ExecuteScalar(ref DAABRequest Request); 

		public abstract void CommitTransaction(); 

		public abstract void RollBackTransaction(); 

		public abstract void Dispose(); 
	}
}

