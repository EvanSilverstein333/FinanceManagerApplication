using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared
{
    public class MessageContents
    {
        public MessageContents(string message, string title)
        {
            Message = message;
            Title = title;
        }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}