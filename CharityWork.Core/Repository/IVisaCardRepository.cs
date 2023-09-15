using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IVisaCardRepository
    {
        void createVisaCard(VisaCard visaCard);
        void updateVisaCard(VisaCard visaCard);
        void deleteVisaCard(int id);
        Task<IEnumerable<VisaCard>> allVisaCard();
        VisaCard getVisaCard(int id);
    }
}
