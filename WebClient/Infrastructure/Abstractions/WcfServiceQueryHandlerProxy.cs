using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FinanceMngr = FinanceManager.Contract.Queries;
using WebClient.Services.FinanceManagerServices.QueryService;
using WebClient.Controllers.Code;

namespace WebClient.Infrastructure.Abstractions
{
    public class WcfServiceQueryHandlerProxy<TQuery, TResult> : IQueryHandler<TQuery,TResult>
    {
        public TResult Handle(TQuery query)
        {
            var service = new FinanceManagerQueryProcessorClient("BasicHttpBinding_FinanceManagerQueryProcessor");

            try
            {
                
                var result = service.Submit(query);
                return (TResult)result;
            }

            finally
            {
                try
                {
                    ((IDisposable)service).Dispose();
                }
                catch
                {
                    // Against good practice and the Framework Design Guidelines, WCF can throw an
                    // exception during a call to Dispose, which can result in loss of the original exception.
                    // See: https://marcgravell.blogspot.com/2008/11/dontdontuse-using.html
                    // See: https://msdn.microsoft.com/en-us/library/aa355056.aspx


                }
            }
        }
    }
}
