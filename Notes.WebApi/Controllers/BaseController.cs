﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();

        internal Guid userId => !User.Identity.IsAuthenticated 
            ?Guid.Empty : Guid.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
