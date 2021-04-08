
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

  public class ZST_PV_CAMPANATable : SAPTable 
  {
    public static Type GetElementType() 
    {
        return (typeof(ZST_PV_CAMPANA));
    }
 
    public override object CreateNewRow()
    { 
        return new ZST_PV_CAMPANA();
    }
     
    public ZST_PV_CAMPANA this[int index] 
    {
        get 
        {
            return ((ZST_PV_CAMPANA)(List[index]));
        }
        set 
        {
            List[index] = value;
        }
    }
        
    public int Add(ZST_PV_CAMPANA value) 
    {
        return List.Add(value);
    }
        
    public void Insert(int index, ZST_PV_CAMPANA value) 
    {
        List.Insert(index, value);
    }
        
    public int IndexOf(ZST_PV_CAMPANA value) 
    {
        return List.IndexOf(value);
    }
        
    public bool Contains(ZST_PV_CAMPANA value) 
    {
        return List.Contains(value);
    }
        
    public void Remove(ZST_PV_CAMPANA value) 
    {
        List.Remove(value);
    }
        
    public void CopyTo(ZST_PV_CAMPANA[] array, int index) 
    {
        List.CopyTo(array, index);
	}
  }
}
