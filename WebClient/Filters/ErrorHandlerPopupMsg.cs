using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using System.Data;

namespace WebClient.Filters
{
    public class ErrorHandlerPopupMsg : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            
            var e = filterContext.Exception;
            if(e is ValidationException ||
               e is DBConcurrencyException ||
               e is TimeoutException)
            {
                var controller = filterContext.Controller;
                var vp = controller.ValueProvider;
                var value = controller.ViewData;
                var form = filterContext.HttpContext.Request.Form;
                var view = filterContext.ParentActionViewContext;
                var da = filterContext.RequestContext.RouteData;
                var modelValues = GetModelValues(filterContext);
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.Url.PathAndQuery);
                filterContext.ExceptionHandled = true;
            }
        }

        private dynamic GetModelValues(ExceptionContext context)
        {
            var form = context.HttpContext.Request.Form;
            var values = new List<object>();
            foreach(var key in form.AllKeys)
            {
                var val = form.GetValues(key);
                values.Add(val);
            }
            return values;
        }
    }
}