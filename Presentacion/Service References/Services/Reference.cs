﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presentacion.Services {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Services.IServiceWCFProveedores")]
    public interface IServiceWCFProveedores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWCFProveedores/ObtenerTodos", ReplyAction="http://tempuri.org/IServiceWCFProveedores/ObtenerTodosResponse")]
        System.Data.DataSet ObtenerTodos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWCFProveedores/ObtenerTodos", ReplyAction="http://tempuri.org/IServiceWCFProveedores/ObtenerTodosResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWCFProveedores/ObtenerPorRut", ReplyAction="http://tempuri.org/IServiceWCFProveedores/ObtenerPorRutResponse")]
        Dominio.Proveedor ObtenerPorRut(string rut);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWCFProveedores/ObtenerPorRut", ReplyAction="http://tempuri.org/IServiceWCFProveedores/ObtenerPorRutResponse")]
        System.Threading.Tasks.Task<Dominio.Proveedor> ObtenerPorRutAsync(string rut);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWCFProveedoresChannel : Presentacion.Services.IServiceWCFProveedores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWCFProveedoresClient : System.ServiceModel.ClientBase<Presentacion.Services.IServiceWCFProveedores>, Presentacion.Services.IServiceWCFProveedores {
        
        public ServiceWCFProveedoresClient() {
        }
        
        public ServiceWCFProveedoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceWCFProveedoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWCFProveedoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWCFProveedoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet ObtenerTodos() {
            return base.Channel.ObtenerTodos();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ObtenerTodosAsync() {
            return base.Channel.ObtenerTodosAsync();
        }
        
        public Dominio.Proveedor ObtenerPorRut(string rut) {
            return base.Channel.ObtenerPorRut(rut);
        }
        
        public System.Threading.Tasks.Task<Dominio.Proveedor> ObtenerPorRutAsync(string rut) {
            return base.Channel.ObtenerPorRutAsync(rut);
        }
    }
}
