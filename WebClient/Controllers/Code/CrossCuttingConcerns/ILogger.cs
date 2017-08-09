using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public interface ILogger
    {
        void Info(object message);
        void Error(object message);
        void Error(object message, Exception e);
    }
}
