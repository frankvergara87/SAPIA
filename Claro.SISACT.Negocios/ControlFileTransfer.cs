using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Web;
using Claro.SisAct.Common;
using System.IO;


namespace Claro.SisAct.Negocios
{
	/// <summary>
	/// Summary description for ControlFileServer (Digitalizacion de  Acuerdos)
	/// </summary>
	public sealed class ControlFileTransfer
	{
	
		public ControlFileTransfer()
		{

		}

		public ControlFileTransfer(string pIP, string  pUser, string pPasword, string pPort)
		{
			
		}

		//*****---Transferencia de archivos usando FTP ---***********************

		public bool PutFileFTP( string pRutaTemporalArchivo, string pRutaArchivo)
		{
			return ProxyFileServer.ControlProxyFTP.PutFileFTP(pRutaTemporalArchivo,pRutaArchivo);
		}
	
		public bool DeleteFileFTP(string pRutaArchivo)
		{
			return ProxyFileServer.ControlProxyFTP.DeleteFileFTP(pRutaArchivo);
		}

		public bool DownloadFileFTP(string pRutaArchivoOrigen, string pRutaArchivoDestino)
		{
			return ProxyFileServer.ControlProxyFTP.DownloadFileFTP(pRutaArchivoOrigen, pRutaArchivoDestino);
		}

		//*****---Transferencia de archivos a un FIle Server ---***********************

		public bool MoveFile( string pRutaTemporalArchivo, string pRutaArchivo)
		{
			return ProxyFileServer.ControlProxyFileServer.MoveFile( pRutaTemporalArchivo,pRutaArchivo);
		}
	
		public bool DeleteFile(string pRutaArchivo)
		{
			return ProxyFileServer.ControlProxyFileServer.DeleteFile(pRutaArchivo);
			
		}


		
	}
}
