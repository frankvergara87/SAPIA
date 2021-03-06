
//------------------------------------------------------------------------------
// 
//     This code was generated by a SAP. NET Connector Proxy Generator Version 1.0
//     Created at 25/08/2011
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

  public class ZWA_UTILIZACIONTable : SAPTable 
  {
    public static Type GetElementType() 
    {
        return (typeof(ZWA_UTILIZACION));
    }
 
    public override object CreateNewRow()
    { 
        return new ZWA_UTILIZACION();
    }
     
    public ZWA_UTILIZACION this[int index] 
    {
        get 
        {
            return ((ZWA_UTILIZACION)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    public int Add(ZWA_UTILIZACION value) 
    {
        return List.Add(value);
    }
        
    public void Insert(int index, ZWA_UTILIZACION value) 
    {
        List.Insert(index, value);
    }
        
    public int IndexOf(ZWA_UTILIZACION value) 
    {
        return List.IndexOf(value);
    }
        
    public bool Contains(ZWA_UTILIZACION value) 
    {
        return List.Contains(value);
    }
        
    public void Remove(ZWA_UTILIZACION value) 
    {
        List.Remove(value);
    }
        
    public void CopyTo(ZWA_UTILIZACION[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
