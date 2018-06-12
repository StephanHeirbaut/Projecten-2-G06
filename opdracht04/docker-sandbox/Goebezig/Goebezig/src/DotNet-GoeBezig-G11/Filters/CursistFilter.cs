using DotNet_GoeBezig_G11.Models.Domein;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet_GoeBezig_G11.Filters
{
    public class CursistFilter : ActionFilterAttribute
    {
        private readonly ICursistRepository _cursistRepository;
        private Cursist _cursist;

        public CursistFilter(ICursistRepository cursistRepository)
        {
            _cursistRepository = cursistRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                _cursist = _cursistRepository.GetBy(context.HttpContext.User.Identity.Name);
                context.ActionArguments["cursist"] = _cursist;
            }
            base.OnActionExecuting(context);
        }

       
    }
}
