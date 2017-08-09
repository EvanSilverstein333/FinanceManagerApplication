using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public class RequestResult
    {
        public bool Succeeded { get; set; }
        public MessageContents MessageContents { get; set; }
    }
}