﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterServcie.ServiceVk {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceVk.IServiceVk")]
    public interface IServiceVk {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceVk/Posting", ReplyAction="http://tempuri.org/IServiceVk/PostingResponse")]
        void Posting(string token, string path, string group);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceVk/Posting", ReplyAction="http://tempuri.org/IServiceVk/PostingResponse")]
        System.Threading.Tasks.Task PostingAsync(string token, string path, string group);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceVkChannel : MasterServcie.ServiceVk.IServiceVk, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceVkClient : System.ServiceModel.ClientBase<MasterServcie.ServiceVk.IServiceVk>, MasterServcie.ServiceVk.IServiceVk {
        
        public ServiceVkClient() {
        }
        
        public ServiceVkClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceVkClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceVkClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceVkClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Posting(string token, string path, string group) {
            base.Channel.Posting(token, path, group);
        }
        
        public System.Threading.Tasks.Task PostingAsync(string token, string path, string group) {
            return base.Channel.PostingAsync(token, path, group);
        }
    }
}
