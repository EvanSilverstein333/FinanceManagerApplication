using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    public static class ControllerExtensionMethods
    {
        public static void SetErrorMessageContents(this Controller controller, MessageContents contents)
        {
            controller.ViewBag.MessageContents = contents;
        }
    }
}