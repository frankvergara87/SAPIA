﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2503
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2503.
// 
namespace Claro.SisAct.Negocios.WSConsultaClaves {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ebsConsultaClavesPortTypeSOAP11Binding", Namespace="http://claro.com.pe/eai/ebs/operaciones/consultaclaves")]
    public class ebsConsultaClavesService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ebsConsultaClavesService() {
            this.Url = "http://limdeseaiv30.tim.com.pe:8909/ConsultaClavesWS/ebsConsultaClavesSB11";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/ebs/operaciones/consultaclaves/desencriptar", RequestElementName="desencriptarRequest", RequestNamespace="http://claro.com.pe/eai/ebs/operaciones/consultaclaves", ResponseNamespace="http://claro.com.pe/eai/ebs/operaciones/consultaclaves", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("codigoResultado")]
        public string desencriptar(ref string idTransaccion, string ipAplicacion, string ipTransicion, string usrAplicacion, string idAplicacion, string codigoAplicacion, string usuarioAplicacionEncriptado, string claveEncriptado, out string mensajeResultado, out string usuarioAplicacion, out string clave) {
            object[] results = this.Invoke("desencriptar", new object[] {
                        idTransaccion,
                        ipAplicacion,
                        ipTransicion,
                        usrAplicacion,
                        idAplicacion,
                        codigoAplicacion,
                        usuarioAplicacionEncriptado,
                        claveEncriptado});
            idTransaccion = ((string)(results[1]));
            mensajeResultado = ((string)(results[2]));
            usuarioAplicacion = ((string)(results[3]));
            clave = ((string)(results[4]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Begindesencriptar(string idTransaccion, string ipAplicacion, string ipTransicion, string usrAplicacion, string idAplicacion, string codigoAplicacion, string usuarioAplicacionEncriptado, string claveEncriptado, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("desencriptar", new object[] {
                        idTransaccion,
                        ipAplicacion,
                        ipTransicion,
                        usrAplicacion,
                        idAplicacion,
                        codigoAplicacion,
                        usuarioAplicacionEncriptado,
                        claveEncriptado}, callback, asyncState);
        }
        
        /// <remarks/>
        public string Enddesencriptar(System.IAsyncResult asyncResult, out string idTransaccion, out string mensajeResultado, out string usuarioAplicacion, out string clave) {
            object[] results = this.EndInvoke(asyncResult);
            idTransaccion = ((string)(results[1]));
            mensajeResultado = ((string)(results[2]));
            usuarioAplicacion = ((string)(results[3]));
            clave = ((string)(results[4]));
            return ((string)(results[0]));
        }
    }
}