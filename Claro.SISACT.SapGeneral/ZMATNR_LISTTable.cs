
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 1.0
//     Created at 19/09/2013
//     Created from Windows 2000
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// 
//------------------------------------------------------------------------------
using System;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using SAP.Connector;

namespace Claro.SisAct.SapGeneral
{

  public class ZMATNR_LISTTable : SAPTable 
  {
    public static Type GetElementType() 
    {
        return (typeof(ZMATNR_LIST));
    }
 
    public override object CreateNewRow()
    { 
        return new ZMATNR_LIST();
    }
     
    public ZMATNR_LIST this[int index] 
    {
        get 
        {
            return ((ZMATNR_LIST)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    public int Add(ZMATNR_LIST value) 
    {
        return List.Add(value);
    }
        
    public void Insert(int index, ZMATNR_LIST value) 
    {
        List.Insert(index, value);
    }
        
    public int IndexOf(ZMATNR_LIST value) 
    {
        return List.IndexOf(value);
    }
        
    public bool Contains(ZMATNR_LIST value) 
    {
        return List.Contains(value);
    }
        
    public void Remove(ZMATNR_LIST value) 
    {
        List.Remove(value);
    }
        
    public void CopyTo(ZMATNR_LIST[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
