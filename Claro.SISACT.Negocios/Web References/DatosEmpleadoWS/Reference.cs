﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2463
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=1.1.4322.2463.
// 
namespace Claro.SisAct.Negocios.DatosEmpleadoWS {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="EbsDatosEmpleadoServiceSoapBinding", Namespace="http://pe/com/claro/esb/services/datosempleado/ws")]
    public class EbsDatosEmpleadoService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public EbsDatosEmpleadoService() {
            this.Url = "http://limdeseaiv06.tim.com.pe:8909/DatosEmpleadoWS/EbsDatosEmpleado";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://pe/com/claro/esb/services/datosempleado/ws", ResponseNamespace="http://pe/com/claro/esb/services/datosempleado/ws", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DatosEmpleadoResponse", Namespace="http://www.claro.com.pe/esb/services/datosempleado/schemas/")]
        public DatosEmpleadoResponse obtenerDatosEmpleadoPorId([System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.claro.com.pe/esb/services/datosempleado/schemas/")] DatosEmpleadoRequest DatosEmpleadoRequest) {
            object[] results = this.Invoke("obtenerDatosEmpleadoPorId", new object[] {
                        DatosEmpleadoRequest});
            return ((DatosEmpleadoResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginobtenerDatosEmpleadoPorId(DatosEmpleadoRequest DatosEmpleadoRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("obtenerDatosEmpleadoPorId", new object[] {
                        DatosEmpleadoRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public DatosEmpleadoResponse EndobtenerDatosEmpleadoPorId(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((DatosEmpleadoResponse)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.claro.com.pe/esb/services/datosempleado/schemas/")]
    public class DatosEmpleadoRequest {
        
        /// <remarks/>
        public string idUsu;
        
        /// <remarks/>
        public string loginNt;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.claro.com.pe/esb/services/datosempleado/schemas/")]
    public class EmpleadoType {
        
        /// <remarks/>
        public string idEmp;
        
        /// <remarks/>
        public string login;
        
        /// <remarks/>
        public string nombre;
        
        /// <remarks/>
        public string apellido;
        
        /// <remarks/>
        public string apellidoMaterno;
        
        /// <remarks/>
        public string nomCompleto;
        
        /// <remarks/>
        public string idCodvendedorSap;
        
        /// <remarks/>
        public string idArea;
        
        /// <remarks/>
        public string descArea;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.claro.com.pe/esb/services/datosempleado/schemas/")]
    public class DatosEmpleadoResponse {
        
        /// <remarks/>
        public string codRes;
        
        /// <remarks/>
        public string mensaje;
        
        /// <remarks/>
        public EmpleadoType empleado;
    }
}