using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Controllers.Code.CrossCuttingConcerns;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public sealed class NotifyCommandCompletedCallback : INotifyCommandCompletedCallback
    {

        public event Action<RequestResultArgs> Completed;

        public void ExecuteActions(RequestResult result)
        {
            var args = new RequestResultArgs(result.Succeeded, result.MessageContents);
            var handler = Completed;
            if(handler != null) { handler.Invoke(args); }
        }

        public void Reset()
        {
            // Clears the list of actions.
            this.Completed = (args) => { };
        }
    }
}
