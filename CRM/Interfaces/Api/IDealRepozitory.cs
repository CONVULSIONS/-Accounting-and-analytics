using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.CRM.Models.Deals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Repozitories
{
    public interface IDealRepozitory
    {
        Task<List<Deal>> GetAllAsync();
    }
}
