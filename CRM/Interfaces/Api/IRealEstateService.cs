using AccountingAndAnalytics.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Api
{
    public interface IRealEstateService
    {
        Task<List<RealEstateModel>> GetRealEstateAsync();
    }
}
