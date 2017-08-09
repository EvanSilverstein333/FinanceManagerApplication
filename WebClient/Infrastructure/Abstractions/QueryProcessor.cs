using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Controllers.Code;
using FinanceMngr = FinanceManager.Contract.Queries;



namespace WebClient.Infrastructure.Abstractions
{
    class QueryProcessor : IQueryProcessor
    {
        public TResult Execute<TResult>(FinanceMngr.IQuery<TResult> query)
        {
            var handlerType =
            typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Bootstrapper.Container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);

        }

    }
}
