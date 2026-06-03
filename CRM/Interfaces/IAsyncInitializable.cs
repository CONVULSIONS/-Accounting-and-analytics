using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces
{
    public interface IAsyncInitializable
    {
        Task InitializeAsync();
    }
}
