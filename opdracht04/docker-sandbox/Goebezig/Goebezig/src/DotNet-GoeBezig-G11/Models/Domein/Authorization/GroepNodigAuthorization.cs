using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_GoeBezig_G11.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_GoeBezig_G11.Models.Domein.Authorization
{

    public class GroepNodigAuthorization : AuthorizationHandler<GroepNodigRequirement>
    {

        private Cursist _cursist;
        private readonly ICursistRepository _repository;

        public GroepNodigAuthorization(ICursistRepository repository)
        {
            _repository = repository;
        }




        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroepNodigRequirement requirement)
        {
            try
            {
                _cursist = _repository.GetBy(context.User.Identity.Name);
                if (_cursist.Groep == null)
                {
                    context.Fail();
                }
                else
                {
                    context.Succeed(requirement);
                }
            }
            catch (Exception )
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
