using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Repository;
using System;
using System.Collections.Generic;
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
        public Task<IEnumerable<IssuesReport>> NumberOfIssues() { return _issuesReportRepository.NumberOfIssues(); }

    }
}
