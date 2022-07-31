using Api.Abstracts;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

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
    public async Task<IActionResult> GetTodayGaols()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name);
        
        var goals = await _goalLogic.GetAll(user, DateTimeOffset.Now);

        return Ok(goals);
    }
    
    protected override async Task<IBasicLogic<Goal>> BasicLogic()
    {
        return _goalLogic;
    }
}