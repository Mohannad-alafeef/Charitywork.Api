using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Repository
{
    public class GoalRepository: IGoalRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public GoalRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public async void createGoal(Goal goal)
        {
            var parm = new DynamicParameters();
            parm.Add("ch_Goal_Text", goal.GoalText, DbType.String, ParameterDirection.Input);
            parm.Add("ch_id", goal.CharityId, DbType.Int64, ParameterDirection.Input);


            await _connection.ExecuteAsync("Goals_Package.CreateGoal", param: parm, commandType: CommandType.StoredProcedure);

        }
        public void updateGoal(Goal goal)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", goal.GoalId, DbType.Int64, ParameterDirection.Input);
            parm.Add("ch_Goal_Text", goal.GoalText, DbType.String, ParameterDirection.Input);
            parm.Add("ch_id", goal.CharityId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Goals_Package.UpdateGoal", parm, commandType: CommandType.StoredProcedure);


        }
        public void deleteGoal(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Goals_Package.DeleteGoal", parm, commandType: CommandType.StoredProcedure);

        }
      
        public Task<IEnumerable<Goal>> allChartyGoals(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryAsync<Goal>("Goals_Package.GetAllCharityGoals", parm, commandType: CommandType.StoredProcedure);

        }
        public Goal getGoal(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<Goal>("Goals_Package.GetGoalById", parm, commandType: CommandType.StoredProcedure);

        }
    }
}
