﻿using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Repository
{
    public class IssuesReportRepository : IIssuesReportRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public IssuesReportRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public Task<IEnumerable<IssuesReport>> GetAllIssues()
        {

            return _connection.QueryAsync<IssuesReport>("Issues_report_package.get_all_Issues", commandType: CommandType.StoredProcedure);
        }

        public void CreateIssue(IssuesReport issuesReport)
        {
            var parm = new DynamicParameters();
            parm.Add("reportDate", issuesReport.ReportDate, DbType.Date, ParameterDirection.Input);
            parm.Add("subject", issuesReport.Subject, DbType.String, ParameterDirection.Input);
            parm.Add("status", issuesReport.IssueStatus, DbType.String, ParameterDirection.Input);
            parm.Add("msg", issuesReport.Message, DbType.String, ParameterDirection.Input);
            parm.Add("userId ", issuesReport.UserId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Issues_report_package.create_Issues", parm, commandType: CommandType.StoredProcedure);
        }
        public IssuesReport GetIssueById(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<IssuesReport>("Issues_report_package. get_by_id", parm, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> NumberOfIssues()
        {
           
           return await _connection.QuerySingleAsync<int>("Issues_report_package.number_of_Issues", commandType: CommandType.StoredProcedure);
        }

        public async void DeleteIssue(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("id", id, DbType.Int64, ParameterDirection.Input);

            await _connection.ExecuteAsync("Issues_report_package.delete_Issue", parm, commandType: CommandType.StoredProcedure);
        }
        public async void ChangeStatus(IssuesReport issuesReport)
        {
            var parm = new DynamicParameters();
            parm.Add("id", issuesReport.ProblemId, DbType.Int64, ParameterDirection.Input);
            parm.Add("Status", issuesReport.IssueStatus, DbType.Int64, ParameterDirection.Input);
            await _connection.ExecuteAsync("Issues_report_package.change_status", parm, commandType: CommandType.StoredProcedure);
        }


    }
}
