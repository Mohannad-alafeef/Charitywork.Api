using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IIssuesReportRepository
    {
        public Task<IEnumerable<IssuesReport>> GetAllIssues();
        public void CreateIssue(IssuesReport issuesReport);
        public IssuesReport GetIssueById(int id);
        public Task<IEnumerable<IssuesReport>> NumberOfIssues();
    }
}
