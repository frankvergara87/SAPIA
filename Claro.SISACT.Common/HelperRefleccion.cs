using System.Reflection;
using System;

namespace Claro.SisAct.Common
{
	/// <summary>
	/// Summary description for HelperRefleccion.
	/// </summary>
	public class HelperRefleccion
	{
		public HelperRefleccion()
		{
		}
		public const BindingFlags MemberAccess = 
			BindingFlags.Public | BindingFlags.NonPublic | 
			BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase ;

		public static object GetProperty(object vObject,string vPropertyName)
		{
			

			bool hasProperty=false;
			PropertyInfo[] properties = vObject.GetType().GetProperties();
			for (int i = 0; i < properties.Length; i++) 
			{
				if (properties[i].Name.ToUpper() == vPropertyName.ToUpper())
				{
					hasProperty=true;
					break;
				}
			}
			if(hasProperty	== true )
			{
				return vObject.GetType().GetProperty(vPropertyName,MemberAccess).GetValue(vObject,null);				
			}
			return null;
		}
 
		/// 
		/// Retrieve a dynamic 'non-typelib' field
		/// 
		/// Object to retreve Field from
		/// name of the field to retrieve
		/// 
		public static object GetField(object Object,string Property)
		{
			return Object.GetType().GetField(Property,MemberAccess).GetValue(Object);
		}
 
		/// 
		/// Returns a property or field value using a base object and sub members including . syntax.
		/// For example, you can access: this.oCustomer.oData.Company with (this,"oCustomer.oData.Company")
		/// 
		/// Parent object to 'start' parsing from.
		/// The property to retrieve. Example: 'oBus.oData.Company'
		/// 

		public static object GetPropertyEx(object Parent, string Property) 
		{
			MemberInfo Member = null;
			Type Type = Parent.GetType();
			int lnAt = Property.IndexOf(".");
			if ( lnAt < 0) 
			{
				if (Property == "this" || Property == "me")
					return Parent;

				// *** Get the member
				Member = Type.GetMember(Property,MemberAccess)[0];
				if (Member.MemberType == MemberTypes.Property )
					return ((PropertyInfo) Member).GetValue(Parent,null);
				else
					return ((FieldInfo) Member).GetValue(Parent);
			}
 

			// *** Walk the . syntax - split into current object (Main) and further parsed objects (Subs)
			string Main = Property.Substring(0,lnAt);
			string Subs = Property.Substring(lnAt+1);
			// *** Retrieve the current property

			Member = Type.GetMember(Main,MemberAccess)[0];

			object Sub;

			if (Member.MemberType == MemberTypes.Property )
			{
				// *** Get its value
				Sub = ((PropertyInfo) Member).GetValue(Parent,null);
			}
			else
			{
				Sub = ( (FieldInfo) Member).GetValue(Parent);
			}
			// *** Recurse further into the sub-properties (Subs)
			return GetPropertyEx(Sub,Subs);
		}


		/// 
		/// Sets the property on an object.
		/// 
		/// Object to set property on
		/// Name of the property to set
		/// value to set it to
		public static void SetProperty(object vObject,string vPropertyName,object vValue)
		{
			bool hasProperty=false;
			PropertyInfo[] properties = vObject.GetType().GetProperties();
			for (int i = 0; i < properties.Length; i++) {
				if (properties[i].Name.ToUpper() == vPropertyName.ToUpper()){
					hasProperty=true;
					break;
				}
			}
			if(hasProperty	== true )
			{
				vObject.GetType().GetProperty(vPropertyName,MemberAccess).SetValue(vObject,vValue,null);
			}
		}

		/// 
		/// Sets the field on an object.
		/// 
		/// Object to set property on
		/// Name of the field to set
		/// value to set it to
		public static void SetField(object Object,string Property,object Value)
		{
			Object.GetType().GetField(Property,MemberAccess).SetValue(Object,Value);
		}
		/// <summary>
		/// Get Type Data
		/// </summary>
		/// <param name="Object"></param>
		/// <param name="Property"></param>
		/// <returns></returns>
		public static string GetType(object vObject,string vPropertyName){			
			
			bool hasProperty=false;
			PropertyInfo[] properties = vObject.GetType().GetProperties();
			for (int i = 0; i < properties.Length; i++) 
			{
				if (properties[i].Name.ToUpper() == vPropertyName.ToUpper())
				{
					hasProperty=true;
					break;
				}
			}
			if(hasProperty	== true )
			{
				return vObject.GetType().GetProperty(vPropertyName,MemberAccess).PropertyType.Name;				
			}
			return "";
		}
 

		/// 
		/// Sets the value of a field or property via Reflection. This method alws 
		/// for using '.' syntax to specify objects multiple levels down.
		/// 
		/// wwUtils.SetPropertyEx(this,"Invoice.LineItemsCount",10)
		/// 
		/// which would be equivalent of:
		/// 
		/// this.Invoice.LineItemsCount = 10;
		/// 
		/// 
		/// Object to set the property on.
		/// 
		/// 
		/// Property to set. Can be an object hierarchy with . syntax.
		/// 
		/// 
		/// Value to set the property to
		/// 
		public static object SetPropertyEx(object Parent, string Property,object Value) 
		{
			Type Type = Parent.GetType();
			MemberInfo Member = null;

			// *** no more .s - we got our final object
			int lnAt = Property.IndexOf(".");
			if ( lnAt < 0) 
			{
				Member = Type.GetMember(Property,MemberAccess)[0];
				if ( Member.MemberType == MemberTypes.Property ) 
				{
					((PropertyInfo) Member).SetValue(Parent,Value,null);
					return null;
				}
				else 
				{
					((FieldInfo) Member).SetValue(Parent,Value);
					return null;
				}
			}    

			// *** Walk the . syntax
			string Main = Property.Substring(0,lnAt);
			string Subs = Property.Substring(lnAt+1);
			Member = Type.GetMember(Main,MemberAccess)[0];
			object Sub;
			if (Member.MemberType == MemberTypes.Property)
				Sub = ((PropertyInfo) Member).GetValue(Parent,null);
			else
				Sub = ((FieldInfo) Member).GetValue(Parent);
			// *** Recurse until we get the lowest ref
			SetPropertyEx(Sub,Subs,Value);
			return null;
	}

 

		/// 
		/// Wrapper method to call a 'dynamic' (non-typelib) method
		/// on a COM object
		/// 
		/// 
		/// 1st - Method name, 2nd - 1st parameter, 3rd - 2nd parm etc.
		/// 
		public static object CallMethod(object Object,string Method, params object[] Params)
		{

			return Object.GetType().InvokeMember(Method,MemberAccess | BindingFlags.InvokeMethod,null,Object,Params);
		}

		public static void CopyData(object vObjectOrigen,ref object vObjectDestino)
		{			
			PropertyInfo[] properties = vObjectOrigen.GetType().GetProperties();
			string propertyName = "";
			for (int i = 0; i < properties.Length; i++)
			{
				propertyName = properties[i].Name;
				object vValue = vObjectOrigen.GetType().GetProperty(propertyName,MemberAccess).GetValue(vObjectOrigen,null);
				vObjectDestino.GetType().GetProperty(propertyName ,MemberAccess).SetValue(vObjectDestino,vValue,null);
			}
		}
	}
}
