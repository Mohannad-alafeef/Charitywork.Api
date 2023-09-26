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
    public class CharityService: ICharityService
    {
        private readonly ICharityRepository _charityRepository;

        public CharityService(ICharityRepository charityRepository)
        {
            _charityRepository = charityRepository;
        }
        public Task<IEnumerable<Charity>> allstatusCharity()
        {
           return _charityRepository.allstatusCharity();
        }
       public Task<int> createCharity(Charity charity)
        {
            return _charityRepository.createCharity(charity);
        }
        public void updateCharity(Charity charity)
        {
            _charityRepository.updateCharity(charity);
        }
        public void deleteCharity(int id)
        {
            _charityRepository.deleteCharity(id);
        }
        public Task<IEnumerable<Charity>> allCharity()
        {
            return _charityRepository.allCharity();
        }
        public Charity getCharity(int id)
        {
            return _charityRepository.getCharity(id);
        }
        public Task<IEnumerable<Charity>> SearchByName(string name)
        {
            return _charityRepository.SearchByName(name);
        }
        public Task<IEnumerable<Charity>> SearchByDate(DateSearch dateSearch)
        {
            return _charityRepository.SearchByDate(dateSearch);
        }
    }
}
