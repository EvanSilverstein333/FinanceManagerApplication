using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public class RequestResultArgs : EventArgs
    {
        public RequestResultArgs(bool succeeded, MessageContents messageContents)
        {
            Succeeded = succeeded;
            MessageContents = messageContents;
        }
        public bool Succeeded { get; }
        public MessageContents MessageContents { get; set; }
    }
}