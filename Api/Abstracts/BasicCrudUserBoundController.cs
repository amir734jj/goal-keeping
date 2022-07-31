using System.Collections;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Abstracts;

[Authorize]
[ApiController]
public abstract class BasicCrudUserBoundController<T> : Controller where T : class
{
    [NonAction]
    protected abstract IBasicLogicUserBound<T> BasicLogic();

    [NonAction]
    protected abstract UserManager<User> UserManager();

    [NonAction]
    protected async Task<User> GetUser()
    {
        var user = await UserManager().FindByNameAsync(User.Identity?.Name);

        return user;
    }
    
    [HttpGet]
    [Route("")]
    [SwaggerOperation("GetAll")]
    [ProducesResponseType(typeof(IEnumerable), 200)]
    public virtual async Task<IActionResult> GetAll()
    {
        return Ok(await BasicLogic().GetAll(await GetUser()));
    }

    [HttpGet]
    [Route("{id:int}")]
    [SwaggerOperation("Get")]
    public virtual async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await BasicLogic().Get(await GetUser(), id));
    }

    [HttpPut]
    [Route("{id:int}")]
    [SwaggerOperation("Update")]
    public virtual async Task<IActionResult> Update([FromRoute] int id, [FromBody] T instance)
    {
        return Ok(await BasicLogic().Update(await GetUser(), id, instance));
    }

    [HttpDelete]
    [Route("{id:int}")]
    [SwaggerOperation("Delete")]
    public virtual async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await BasicLogic().Delete(await GetUser(), id));
    }

    [HttpPost]
    [Route("")]
    [SwaggerOperation("Save")]
    public virtual async Task<IActionResult> Save([FromBody] T instance)
    {
        return Ok(await BasicLogic().Save(await GetUser(), instance));
    }
}