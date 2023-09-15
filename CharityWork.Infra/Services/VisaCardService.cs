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
    public class VisaCardService: IVisaCardService
    {
        private readonly IVisaCardRepository _visaCardRepository;

        public VisaCardService(IVisaCardRepository visaCardRepository)
        {
            _visaCardRepository = visaCardRepository;
        }

        public void createVisaCard(VisaCard visaCard)
        {
            _visaCardRepository.createVisaCard(visaCard);
        }
       public  void updateVisaCard(VisaCard visaCard)
        {
            _visaCardRepository.updateVisaCard(visaCard);
        }
        public void deleteVisaCard(int id)
        {
            _visaCardRepository.deleteVisaCard(id);
        }
        public Task<IEnumerable<VisaCard>> allVisaCard()
        {
            return _visaCardRepository.allVisaCard();
        }
        public VisaCard getVisaCard(int id)
        {
            return _visaCardRepository.getVisaCard(id);
        }
    }
}
