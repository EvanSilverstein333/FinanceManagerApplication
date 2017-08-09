using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceMngr = FinanceManager.Contract.Queries;


namespace WebClient.Controllers.Code
{
    public interface IQueryProcessor
    {
        // need to include for each bounded context because inference cannot be performed
        //from generic type constraints https://stackoverflow.com/questions/8511066/why-doesnt-c-sharp-infer-my-generic-types
        TResult Execute<TResult>(FinanceManager.Contract.Queries.IQuery<TResult> query);

    }
}
