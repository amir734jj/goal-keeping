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
public class GoalController : BasicCrudUserBoundController<Goal>
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
        var goals = await _goalLogic.GetAll(await GetUser(), DateTimeOffset.Now.Date);

        return Ok(goals);
    }

    protected override IBasicLogicUserBound<Goal> BasicLogic()
    {
        return _goalLogic;
    }

    protected override UserManager<User> UserManager()
    {
        return _userManager;
    }
}