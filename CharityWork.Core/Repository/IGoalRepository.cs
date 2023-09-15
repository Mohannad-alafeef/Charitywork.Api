using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IGoalRepository
    {
        void createGoal(Goal goal);
        void updateGoal(Goal goal);
        void deleteGoal(int id);
        Task<IEnumerable<Goal>> allChartyGoals(int id);
        Goal getGoal(int id);
    }
}
