using Api.Abstracts;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels.Api;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("Api/[controller]")]
public class GoalController : BasicCrudController<Goal>
{
    private readonly IGoalLogic _goalLogic;
    private readonly UserManager<User> _userManager;

    public GoalController(IGoalLogic goalLogic, UserManager<User> userManager)
    {
        _goalLogic = goalLogic;
        _userManager = userManager;
    }
    
    [HttpGet]
    [Route("today")]
    public async Task<IActionResult> GetTodayGaol()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        
        var goals = await _goalLogic.GetTodayGaol(user);

        return Ok(goals);
    }
    
    [HttpPut]
    [Route("today")]
    public async Task<IActionResult> UpdateTodayGaol([FromBody]GoalViewModel goalViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        
        var goals = await _goalLogic.UpdateTodayGaol(user, goalViewModel);

        return Ok(goals);
    }
    
    [HttpPost]
    [Route("today")]
    public async Task<IActionResult> SaveTodayGaol([FromBody]GoalViewModel goalViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        
        var goals = await _goalLogic.SaveTodayGaol(user, goalViewModel);

        return Ok(goals);
    }

    protected override async Task<IBasicLogic<Goal>> BasicLogic()
    {
        return _goalLogic;
    }
}