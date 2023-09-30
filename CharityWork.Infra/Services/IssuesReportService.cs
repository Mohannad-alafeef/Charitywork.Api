using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
   public class IssuesReportService : IIssuesReportService
    {
        private readonly IIssuesReportRepository _issuesReportRepository;

        public IssuesReportService(IIssuesReportRepository issuesReportRepository)
        {
             _issuesReportRepository = issuesReportRepository;
        }

        public Task<IEnumerable<IssuesReport>> GetAllIssues() {return _issuesReportRepository.GetAllIssues();  }
        public void CreateIssue(IssuesReport issuesReport) { _issuesReportRepository.CreateIssue(issuesReport); }
        public IssuesReport GetIssueById(int id) { return _issuesReportRepository.GetIssueById(id); }
        public Task<int> NumberOfIssues() { return  _issuesReportRepository.NumberOfIssues(); }
        public async void DeleteIssue(int id)
        {  _issuesReportRepository.DeleteIssue(id); }
        public async void ChangeStatus(IssuesReport issuesReport)
        {  _issuesReportRepository.ChangeStatus(issuesReport); }
    }
}
