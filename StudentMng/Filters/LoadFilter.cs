using System.Diagnostics;
using System.Web.Mvc;

namespace StudentMng.Filters
{
    public class LoadFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Debug.WriteLine("Application is starting ... ");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Debug.WriteLine("Execution is finished ... ");
        }
    }
}