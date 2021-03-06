﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.Services.FinanceManagerServices.QueryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Services.FinanceManagerServices.QueryService.FinanceManagerQueryProcessor")]
    public interface FinanceManagerQueryProcessor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FinanceManagerQueryProcessor/Submit", ReplyAction="http://tempuri.org/FinanceManagerQueryProcessor/SubmitResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ValueObjects.Wcf.MyValidator), Action="http://tempuri.org/FinanceManagerQueryProcessor/SubmitMyValidatorFault", Name="MyValidator", Namespace="http://schemas.datacontract.org/2004/07/ValueObjects.Wcf")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.FindFinancialTransactionsByDateQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.FindFinancialAccountsBySearchTextQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.GetAllFinancialAccountsQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.GetFinancialAccountBalanceQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.GetFinancialTransactionByIdQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.GetFinancialTransactionsByAccountIdQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Queries.GetFinancialAccountByIdQuery))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Dto.FinancialTransactionDto[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Dto.FinancialTransactionDto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Dto.FinancialAccountDto[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(FinanceManager.Contract.Dto.FinancialAccountDto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ValueObjects.Wcf.MyValidator))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ValueObjects.Wcf.MyValidationFailure[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ValueObjects.Wcf.MyValidationFailure))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ValueObjects.Finance.Money))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ValueObjects.Finance.TransactionType))]
        object Submit(object query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FinanceManagerQueryProcessor/Submit", ReplyAction="http://tempuri.org/FinanceManagerQueryProcessor/SubmitResponse")]
        System.Threading.Tasks.Task<object> SubmitAsync(object query);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FinanceManagerQueryProcessorChannel : WebClient.Services.FinanceManagerServices.QueryService.FinanceManagerQueryProcessor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FinanceManagerQueryProcessorClient : System.ServiceModel.ClientBase<WebClient.Services.FinanceManagerServices.QueryService.FinanceManagerQueryProcessor>, WebClient.Services.FinanceManagerServices.QueryService.FinanceManagerQueryProcessor {
        
        public FinanceManagerQueryProcessorClient() {
        }
        
        public FinanceManagerQueryProcessorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FinanceManagerQueryProcessorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FinanceManagerQueryProcessorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FinanceManagerQueryProcessorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public object Submit(object query) {
            return base.Channel.Submit(query);
        }
        
        public System.Threading.Tasks.Task<object> SubmitAsync(object query) {
            return base.Channel.SubmitAsync(query);
        }
    }
}
