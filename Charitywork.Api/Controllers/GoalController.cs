﻿using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _GoalService;

        public GoalController(IGoalService goalService)
        {
            _GoalService = goalService;
        }
        [HttpPost("create")]
        public void createGoal(Goal goal)
        {
            _GoalService.createGoal(goal);
        }
        [HttpPut("update")]
        public void updateGoal(Goal goal)
        {
            _GoalService.updateGoal(goal);
        }
        [HttpDelete("{id}")]
        public void deleteGoal(int id)
        {
            _GoalService.deleteGoal(id);
        }
        [HttpGet("CharityGoals/{id}")]
        public Task<IEnumerable<Goal>> allChartyGoals(int id)
        {
            return _GoalService.allChartyGoals(id);
        }
        [HttpGet("getGoalById/{id}")]
        public IActionResult getGoal(int id)
        {
            var goal = _GoalService.getGoal(id);
            if (goal == null) {
                return NotFound();
            }else
                return Ok(goal);
            
        }
    }
}
