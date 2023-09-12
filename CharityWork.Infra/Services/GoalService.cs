using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
    public class GoalService: IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }
        public void createGoal(Goal goal)
        {
            _goalRepository.createGoal(goal);
        }
        public void updateGoal(Goal goal)
        {
            _goalRepository.updateGoal(goal);
        }
        public void deleteGoal(int id)
        {
            _goalRepository.deleteGoal(id);
        }
        public Task<IEnumerable<Goal>> allChartyGoals(int id)
        {
            return _goalRepository.allChartyGoals(id);
        }
        public Goal getGoal(int id)
        {
            return _goalRepository.getGoal(id);
        }
    }
}
