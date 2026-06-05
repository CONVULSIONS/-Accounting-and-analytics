using AccountingAndAnalytics.CRM.Models.Applications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Repozitories
{
    public interface IApplicationRepozitory
    {
        Task<List<Application>> GetAllAsync();
        Task AppToDeal(int appId);
    }
}
