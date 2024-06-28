﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Pquyquy.WebAPI.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
