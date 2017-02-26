﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CurrencyTranslator.ServiceLayer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceLayer.ICurrencyService")]
    public interface ICurrencyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICurrencyService/TranslateIntoWords", ReplyAction="http://tempuri.org/ICurrencyService/TranslateIntoWordsResponse")]
        string TranslateIntoWords(string numberText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICurrencyService/TranslateIntoWords", ReplyAction="http://tempuri.org/ICurrencyService/TranslateIntoWordsResponse")]
        System.Threading.Tasks.Task<string> TranslateIntoWordsAsync(string numberText);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICurrencyServiceChannel : CurrencyTranslator.ServiceLayer.ICurrencyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CurrencyServiceClient : System.ServiceModel.ClientBase<CurrencyTranslator.ServiceLayer.ICurrencyService>, CurrencyTranslator.ServiceLayer.ICurrencyService {
        
        public CurrencyServiceClient() {
        }
        
        public CurrencyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CurrencyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CurrencyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string TranslateIntoWords(string numberText) {
            return base.Channel.TranslateIntoWords(numberText);
        }
        
        public System.Threading.Tasks.Task<string> TranslateIntoWordsAsync(string numberText) {
            return base.Channel.TranslateIntoWordsAsync(numberText);
        }
    }
}