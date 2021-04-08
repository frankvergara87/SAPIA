namespace Claro.SisAct.Configuracion
{ 

public class ClaroBDConfiguracion : IClaroBDConfiguracion 
{ 
	private string _strName;
		
		public string Name 
		{
			set{_strName = value;}
			get{return _strName;}
		}
		string mServidor = string.Empty;
		string mBaseDatos = string.Empty;
		string mUsuario = string.Empty;
		string mPassWord = string.Empty;
		string mProvider = string.Empty;
		string mIdioma = string.Empty;
		string mSistema = string.Empty;
		string mMaxPoolSize = string.Empty;
		string mMinPoolSize = string.Empty;
		string mConnectionLifetime = string.Empty;
		string mPooling = string.Empty;

	public string Servidor{ 
		get { return mServidor; } 
		set { mServidor = value; } 
	} 
	public string BaseDatos { 
		get { return mBaseDatos; } 
		set { mBaseDatos = value; } 
	} 
	public string Usuario { 
		get { return mUsuario; } 
		set { mUsuario = value; } 
	} 

	public string Password { 
		get { return mPassWord; } 
		set { mPassWord = value; } 
	} 

	public string Provider { 
		get { return mProvider; } 
		set { mProvider = value; } 
	} 

	public string Idioma 
	{ 
		get { return mIdioma; } 
		set { mIdioma = value; } 
	} 
	public string Sistema 
	{ 
		get { return mSistema; } 
		set { mSistema = value; } 
	} 
	public string MaxPoolSize { 
		get { return mMaxPoolSize; } 
		set { mMaxPoolSize = value; } 
	}	
	public string MinPoolSize { 
		get { return mMinPoolSize; } 
		set { mMinPoolSize = value; } 
	}
	public string ConnectionLifetime{ 
		get { return mConnectionLifetime; } 
		set { mConnectionLifetime = value; } 
	}
	public string Pooling { 
		get { return mPooling; } 
		set { mPooling = value; } 
	}
	public string CadenaConexion { 
		get { 		
			string cadena = "";
			if (mPooling == null) mPooling = "";
			if (mMaxPoolSize == null) mMaxPoolSize = "";
			if (mMinPoolSize == null) mMinPoolSize = "";
			if (mConnectionLifetime == null) mConnectionLifetime = "";
			if (mPooling == null) mPooling = "";


			if (mProvider.IndexOf("ORA") > 0 || mProvider == ""){ 				
				cadena = "User Id=" + ((mUsuario == null) ? "" : mUsuario) + ";Data Source=" + ((mBaseDatos == null) ? "" : mBaseDatos) + ";password=" + ((mPassWord == null) ? "" : mPassWord ) + ";";
				cadena += ((mPooling=="")?"":string.Format("Pooling={0};", mPooling)); 
				cadena += ((mMaxPoolSize=="")?"":string.Format("Max Pool Size={0};", mMaxPoolSize)); 
				cadena += ((mMinPoolSize=="")?"":string.Format("Min Pool Size={0};", mMinPoolSize)); 
				cadena += ((mConnectionLifetime=="")?"":string.Format("Connection Lifetime={0};", mConnectionLifetime)); 
				return cadena;
			} else { 
				cadena = "User Id=" + ((mUsuario == null)?"":mUsuario) + ";Data Source=" + ((Servidor == null)?"":Servidor) + ";password=" + ((mPassWord == null)?"":mPassWord) + ";Initial Catalog=" + ((mBaseDatos == null)?"":mBaseDatos);
				return cadena; 
			} 
		} 
	} 
	
}
}