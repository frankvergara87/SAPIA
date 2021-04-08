using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Claro.SisAct.Common
{

	public class Cryptografia
	{
		public  string CifrarCadena(string pStrTexto ) 
		{
			string objRetVal ="";
			if (pStrTexto == "")
			{
				return objRetVal;
			}
			Crypto objCrypto = new Crypto(Crypto.EnumCryptoProvider.Rijndael);

			objCrypto.Key = "12345678password";
			objCrypto.IV = "password12345678";
			objRetVal = objCrypto.CifrarCadena(pStrTexto);
			objCrypto = null;
			return objRetVal;
		}
		public  string DescifrarCadena(string pStrTexto )
		{
			string objRetVal = "";
			if (pStrTexto == "")
			{
				return objRetVal;
			}
			Crypto objCrypto = new Crypto(Crypto.EnumCryptoProvider.Rijndael);
			objCrypto.Key = "12345678password";
			objCrypto.IV = "password12345678";
			objRetVal = objCrypto.DescifrarCadena(pStrTexto);
			objCrypto = null;
			return objRetVal;
		}
	}
	/// <summary>
	/// Summary description for Encriptar.
	/// </summary>
	internal class Crypto
	{
		private string _key ;
		private string _IV ;
		EnumCryptoProvider _algorithm;
		public enum EnumCryptoProvider {DES, TripleDES, RC2, Rijndael }
		public enum EnumCryptoAction {Encrypt, Desencrypt}
		internal Crypto (EnumCryptoProvider Alg)
		{
			_algorithm =Alg;
		}
		public string Key
		{
			set { _key = value;}
			get { return _key;}
		}
		public string IV
		{
			set { _IV = value;}
			get { return _IV;}
		}

		public string CifrarCadena(string CadenaOriginal ) 
		{
			MemoryStream memStream = new MemoryStream();
			
			try
			{

				if (_key != null && _IV != null) 
				{

					byte[] bytKey = MakeKeyByteArray();
					byte[] bytIV = MakeIVByteArray();

					byte[] textoPlano = Encoding.UTF8.GetBytes(CadenaOriginal);

					memStream = new MemoryStream(CadenaOriginal.Length * 2);
					CryptoServiceProvider _cryptoProvider = new CryptoServiceProvider((CryptoServiceProvider.EnumCryptoProvider)_algorithm, CryptoServiceProvider.EnumCryptoAction.Encrypt);
					ICryptoTransform transform  =  _cryptoProvider.GetServiceProvider(bytKey, bytIV);
					CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
					cryptoStream.Write(textoPlano, 0, textoPlano.Length);

					cryptoStream.Close();
				}
				else
				{
					throw new Exception ("Error al inicializar la clave y el vector");
				}
			}
			catch
			{
				throw;
			}

			return Convert.ToBase64String(memStream.ToArray());
		}

		public string DescifrarCadena(string CadenaCifrada ) 
		{
			MemoryStream memStream  = null;
			try
			{
				if (_key != null && _IV != null) 
				{
					byte[] _bytkey= MakeKeyByteArray();
					byte[] _bytIV=  MakeIVByteArray();
					byte[] _byttextocifrado= Convert.FromBase64String(CadenaCifrada);

					memStream = new MemoryStream(CadenaCifrada.Length);
					CryptoServiceProvider _cryptoProvider = new CryptoServiceProvider((CryptoServiceProvider.EnumCryptoProvider)_algorithm, CryptoServiceProvider.EnumCryptoAction.Desencrypt);
					ICryptoTransform transform  = _cryptoProvider.GetServiceProvider(_bytkey, _bytIV);
					CryptoStream _cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
					_cryptoStream.Write(_byttextocifrado, 0, _byttextocifrado.Length);
					_cryptoStream.Close();
					}
				else
				{
					throw new Exception("Error al inicializar la clave y el vector.");
				}
			}
			catch
			{
				throw;
			}
			return Encoding.UTF8.GetString(memStream.ToArray());
		}
		
	

		private byte[] MakeKeyByteArray() 
		{
			switch(_algorithm)
			{
				case EnumCryptoProvider.DES:
					if (_key.Length < 8) 
					{
						_key = _key.PadRight(8);
					}
					else if (_key.Length > 8)
					{
						_key = _key.Substring(0, 8);
					}
					break;
				case EnumCryptoProvider.RC2:
					if (_key.Length < 8) 
					{
						_key = _key.PadRight(8);
					}
					else if (_key.Length > 8)
					{
						_key = _key.Substring(0, 8);
					}
						break;
				case EnumCryptoProvider.TripleDES:
					if (_key.Length < 16)
					{
						_key = _key.PadRight(16);
					}
					else if (_key.Length > 16)
					{
						_key = _key.Substring(16);
					}
						break;
				case EnumCryptoProvider.Rijndael:
					if (_key.Length < 16)
					{
						_key = _key.PadRight(16);
					}
					else if (_key.Length > 16)
					{
						_key = _key.Substring(16);
					}
						break;
			}					
            return Encoding.UTF8.GetBytes(_key);
		}
					 
		
		private byte[] MakeIVByteArray()
		{
			switch( _algorithm)
			{
				case EnumCryptoProvider.DES:
					if (_IV.Length < 8) 
					{ 
						_IV = _IV.PadRight(8) ;
					}
					else if (_IV.Length > 8)
					{
						_IV = _IV.Substring(8);
					}
						break;
				case EnumCryptoProvider.RC2:
					if (_IV.Length < 8) 
					{ 
						_IV = _IV.PadRight(8) ;
					}
						else if (_IV.Length > 8)
					{
						_IV = _IV.Substring(8);
					}
						break;
				case EnumCryptoProvider.TripleDES:
					if (_IV.Length < 8) 
					{ 
						_IV = _IV.PadRight(8) ;
					}
						else if (_IV.Length > 8)
					{
						_IV = _IV.Substring(8);

					}
						break;
				case EnumCryptoProvider.Rijndael:
					if (_IV.Length < 16) 
					{
						_IV = _IV.PadRight(16);
					}
						else if (_IV.Length > 16)
					{
						_IV = _IV.Substring(16);
					}
						break;
								  
			}

			return Encoding.UTF8.GetBytes(_IV);
		}


		public void CifrarDescifrarArchivo(string InFileName, string OutFileName, EnumCryptoAction EnumAction)
		{

			if ( !File.Exists(InFileName))
			{
				throw new Exception("No se ha encontrado el archivo.");
			}
			try
			{
				if (_key != null && _IV != null) 
				{

					FileStream fsIn = new FileStream(InFileName, FileMode.Open, FileAccess.Read);
					FileStream fsOut = new FileStream(OutFileName, FileMode.OpenOrCreate, FileAccess.Write);
					fsOut.SetLength(0);

					byte[] _bytKey = MakeKeyByteArray() ;
					byte[] _bytIV = MakeIVByteArray() ; 
					byte[] _bytebuffer = new byte[4096];
					long fileLength  = fsIn.Length ;
					long bytesProcesed  = 0   ;     
					int bytesInBlock  = 0;
		
		
					CryptoServiceProvider _cryptoProvider = new CryptoServiceProvider((CryptoServiceProvider.EnumCryptoProvider) _algorithm, (CryptoServiceProvider.EnumCryptoAction)EnumAction);

					ICryptoTransform _transform  = _cryptoProvider.GetServiceProvider(_bytKey, _bytIV);
					CryptoStream _cryptoStream = null ;
					switch (EnumAction)
					{
						case EnumCryptoAction.Encrypt:
							_cryptoStream = new CryptoStream(fsOut, _transform, CryptoStreamMode.Write);
								break;
						case EnumCryptoAction.Desencrypt:
							_cryptoStream = new CryptoStream(fsOut, _transform, CryptoStreamMode.Write);
								break;
					}
						
					while (bytesProcesed < fileLength)
					{

						bytesInBlock = fsIn.Read(_bytebuffer, 0, 4096);
						_cryptoStream.Write(_bytebuffer, 0, bytesInBlock);
						bytesProcesed += Convert.ToInt64(bytesInBlock);
					}

					if ( _cryptoStream != null )
					{
						_cryptoStream.Close();
					}
					fsIn.Close();
					fsOut.Close();
				}
				else
				{
					throw new Exception("Error al inicializar la clave y el vector.");
				}
			}
			catch
			{
				throw;
			}
		}
	}
		
		
	internal class CryptoServiceProvider
	
	{
		EnumCryptoProvider _algorithm;
		EnumCryptoAction _Action;
		public enum EnumCryptoProvider {DES, TripleDES, RC2, Rijndael}
		public enum EnumCryptoAction{ Encrypt, Desencrypt}
		internal CryptoServiceProvider(EnumCryptoProvider Alg, EnumCryptoAction Action)
		{
			_algorithm = Alg;
			_Action= Action;
		}
		internal ICryptoTransform GetServiceProvider(byte[] _Key, byte[] _IV)
		{
			ICryptoTransform _Transform = null;
			switch(_algorithm)
			{
				case EnumCryptoProvider.DES:
					DESCryptoServiceProvider des = new DESCryptoServiceProvider() ;
				switch(_Action)
				{
					case EnumCryptoAction.Encrypt:
						_Transform = des.CreateEncryptor(_Key, _IV);
							break;
					case EnumCryptoAction.Desencrypt:
						_Transform = des.CreateDecryptor(_Key, _IV);
							break;
				}
					return _Transform;
					
				case EnumCryptoProvider.TripleDES:
					TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
				switch (_Action)
				{
					case EnumCryptoAction.Encrypt:
						_Transform = des3.CreateEncryptor(_Key, _IV);
							break;
					case EnumCryptoAction.Desencrypt:
						_Transform = des3.CreateDecryptor(_Key, _IV);
							break;
				}
					return _Transform;
					
				case EnumCryptoProvider.RC2:
					RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
				switch (_Action)
				{
					case EnumCryptoAction.Encrypt:
						_Transform = rc2.CreateEncryptor(_Key, _IV);
							break;
					case EnumCryptoAction.Desencrypt:
						_Transform = rc2.CreateDecryptor(_Key, _IV);
							break;
				}
					return _Transform;
				case EnumCryptoProvider.Rijndael:
					RijndaelManaged rijndael = new RijndaelManaged();
				switch (_Action)
				{
					case EnumCryptoAction.Encrypt:
						_Transform = rijndael.CreateEncryptor(_Key, _IV);
							break;
					case EnumCryptoAction.Desencrypt:
						_Transform = rijndael.CreateDecryptor(_Key, _IV);
							break;
				}
					return _Transform;
					
				default:
					throw new CryptographicException("Error al inicializar al proveedor de cifrado");
					
			}
		}
	}
}