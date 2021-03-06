//------------------------------------------------------------------------------
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
namespace Claro.SisAct.Negocios.ConsultaUDBWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UDBWSBindingSOAP11", Namespace="http://claro.com.pe/eai/ConnectorUdb/ws")]
    public class UDBWSService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public UDBWSService() {
            this.Url = "http://172.19.91.191:8903/UDBConnectorWS/UDBWSSOAP11Port";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/ConnectorUdb/ws/Consulta", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("consultarResponse", Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Consulta")]
        public consultarResponse consultar([System.Xml.Serialization.XmlElementAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Consulta")] consultarRequest consultarRequest) {
            object[] results = this.Invoke("consultar", new object[] {
                        consultarRequest});
            return ((consultarResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginconsultar(consultarRequest consultarRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("consultar", new object[] {
                        consultarRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public consultarResponse Endconsultar(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((consultarResponse)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://claro.com.pe/eai/ConnectorUdb/ws/Ejecucion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ejecutarResponse", Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Ejecucion")]
        public ejecutarResponse ejecutar([System.Xml.Serialization.XmlElementAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Ejecucion")] ejecutarRequest ejecutarRequest) {
            object[] results = this.Invoke("ejecutar", new object[] {
                        ejecutarRequest});
            return ((ejecutarResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult Beginejecutar(ejecutarRequest ejecutarRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ejecutar", new object[] {
                        ejecutarRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public ejecutarResponse Endejecutar(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ejecutarResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Consulta")]
    public class consultarRequest {
        
        /// <remarks/>
        public parametrosAuditRequest auditRequest;
        
        /// <remarks/>
        public accionType accionRequest;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class parametrosAuditRequest {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string ipAplicacion;
        
        /// <remarks/>
        public string nombreAplicacion;
        
        /// <remarks/>
        public string usuarioAplicacion;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Ejecucion")]
    public class ejecutarResponse {
        
        /// <remarks/>
        public parametrosAuditResponse auditResponse;
        
        /// <remarks/>
        public accionType accionResponse;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class parametrosAuditResponse {
        
        /// <remarks/>
        public string idTransaccion;
        
        /// <remarks/>
        public string codRespuesta;
        
        /// <remarks/>
        public string msjRespuesta;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class accionType {
        
        /// <remarks/>
        public string idAccion;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("listaParametros")]
        public listaParametros[] listaParametros;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class listaParametros {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parametro")]
        public listaParametrosParametro[] parametro;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("subListaParametros")]
        public subListaParametros[] subListaParametros;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nombreLista;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class listaParametrosParametro {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string valor;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class subListaParametros {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("parametro")]
        public subListaParametrosParametro[] parametro;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nombreLista;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/types")]
    public class subListaParametrosParametro {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string campo;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string valor;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Ejecucion")]
    public class ejecutarRequest {
        
        /// <remarks/>
        public parametrosAuditRequest auditRequest;
        
        /// <remarks/>
        public accionType accionRequest;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://claro.com.pe/eai/ConnectorUdb/ws/Consulta")]
    public class consultarResponse {
        
        /// <remarks/>
        public parametrosAuditResponse auditResponse;
        
        /// <remarks/>
        public accionType accionResponse;
    }
}
