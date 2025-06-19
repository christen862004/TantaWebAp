using Microsoft.AspNetCore.Mvc.Filters;

namespace TantaWebAp.Filtters
{
    public class MyActionAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logic
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //logic
        }
    }
}
