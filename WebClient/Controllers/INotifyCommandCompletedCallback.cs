using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Controllers.Code.CrossCuttingConcerns;

namespace WebClient.Controllers
{
    public interface INotifyCommandCompletedCallback
    {
        event Action<RequestResultArgs> Completed;

    }
}
