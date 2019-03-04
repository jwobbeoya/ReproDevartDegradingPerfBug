using System;
using System.Net;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ReproDevartDegradingPerfBug.OData
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EnableNavigationQuery : EnableQueryAttribute
    {
        /// <summary>
        /// Performs the query composition after action is executed. It first tries to retrieve the IQueryable from the
        /// returning response message. It then validates the query from uri based on the validation settings on
        /// <see cref="T:System.Web.OData.EnableQueryAttribute" />. It finally applies the query appropriately, and reset it back on
        /// the response message.
        /// </summary>
        /// <param name="actionExecutedContext">The context related to this action, including the response message,
        /// request message and HttpConfiguration etc.</param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.HttpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                actionExecutedContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
        }

    }
}