using AccountingAndAnalytics.CRM.Models.Applications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Repozitories
{
    public interface IApplicationService
    {
        Task<List<Application>> GetAllAsync();
        Task AppToDeal(int appId);
        Task Create(string firstName, string secondName, string surname, int realEstateId, string realEstateName, DateOnly period);
    }
}
