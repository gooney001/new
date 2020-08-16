﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTestApi
{
    public class MyAuthorizeFilter : AuthorizeFilter
    {

        private static AuthorizationPolicy _policy_ = new AuthorizationPolicy(new[] { new DenyAnonymousAuthorizationRequirement() }, new string[] { });

        public MyAuthorizeFilter() : base(_policy_) { }

        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            await base.OnAuthorizationAsync(context);
            if (!context.HttpContext.User.Identity.IsAuthenticated ||
                context.Filters.Any(item => item is IAllowAnonymousFilter)) return;
            //do something
        }
    }
}
