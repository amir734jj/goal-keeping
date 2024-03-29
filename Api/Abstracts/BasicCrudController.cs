﻿using System.Collections;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Abstracts;

[Authorize]
[ApiController]
public abstract class BasicCrudController<T> : Controller where T : class
{
    [NonAction]
    protected abstract IBasicLogic<T> BasicLogic();
    
    [HttpGet]
    [Route("")]
    [SwaggerOperation("GetAll")]
    [ProducesResponseType(typeof(IEnumerable), 200)]
    public virtual async Task<IActionResult> GetAll()
    {
        return Ok(await BasicLogic().GetAll());
    }

    [HttpGet]
    [Route("{id:int}")]
    [SwaggerOperation("Get")]
    public virtual async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await BasicLogic().Get(id));
    }

    [HttpPut]
    [Route("{id:int}")]
    [SwaggerOperation("Update")]
    public virtual async Task<IActionResult> Update([FromRoute] int id, [FromBody] T instance)
    {
        return Ok(await BasicLogic().Update(id, instance));
    }

    [HttpDelete]
    [Route("{id:int}")]
    [SwaggerOperation("Delete")]
    public virtual async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await BasicLogic().Delete(id));
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation("Save")]
    public virtual async Task<IActionResult> Save([FromBody] T instance)
    {
        return Ok(await BasicLogic().Save(instance));
    }
}