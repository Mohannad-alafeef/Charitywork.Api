using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface ICharityRepository
    {
        void createCharity(Charity charity);
        void updateCharity(Charity charity);
        void deleteCharity(int id);
        Task<IEnumerable<Charity>> allCharity();
        Task<IEnumerable<Charity>> allstatusCharity();
        Charity getCharity(int id);
        Task<IEnumerable<Charity>> SearchByName(string name);
        Task<IEnumerable<Charity>> SearchByDate(DateSearch dateSearch);
    }
}
