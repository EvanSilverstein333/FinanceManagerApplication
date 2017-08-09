using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceMngr = FinanceManager.Contract.Queries;

namespace WebClient.Controllers.Code
{
    public interface IQueryHandler<TQuery,TResult> //where TQuery : PatientMngr.IQuery<TResult>, FinanceMngr.IQuery<TResult>
        //where TQuery : PatientMngr.IQuery<TResult>, FinanceMngr.IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
