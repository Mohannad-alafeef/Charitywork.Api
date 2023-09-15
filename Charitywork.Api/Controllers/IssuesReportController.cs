using CharityWork.Core.Models;
using CharityWork.Core.Services;
using CharityWork.Infra.Repository;
using CharityWork.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesReportController : ControllerBase
    {

        private readonly IIssuesReportService _issuesReportService;

        public IssuesReportController(IIssuesReportService issuesReportService)
        {
            _issuesReportService = issuesReportService;
        }
        
        [HttpGet]
        [Route("GetAllIssues")]
        public Task<IEnumerable<IssuesReport>> GetAllIssues()
        {
            return _issuesReportService.GetAllIssues();
        }
        [HttpPost]
        [Route("CreateIssue")]
        public void CreateIssue(IssuesReport issuesReport)
        {
            _issuesReportService.CreateIssue(issuesReport);
        }


        [HttpGet]
        [Route("GetIssueById/{id}")]
        public IssuesReport GetIssueById(int id)
        {
            return _issuesReportService.GetIssueById(id);
        }

        [HttpGet]
        [Route("NumberOfIssues")]
        public Task<int> NumberOfIssues()
        {
          return _issuesReportService.NumberOfIssues();
        }

    }
}
