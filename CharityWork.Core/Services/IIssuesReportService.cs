using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services
{
    public interface IIssuesReportService 
    {
        public Task<IEnumerable<IssuesReport>> GetAllIssues();
        public void CreateIssue(IssuesReport issuesReport);
        public IssuesReport GetIssueById(int id);
       public Task<int> NumberOfIssues();
        public  void DeleteIssue(int id);
        public  void ChangeStatus(IssuesReport issuesReport);
    }
}
