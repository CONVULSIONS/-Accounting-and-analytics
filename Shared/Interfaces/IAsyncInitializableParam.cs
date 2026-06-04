using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Interfaces
{
    public interface IAsyncInitializableParam<in T>
    {
        Task InitializeAsync(T parameter);
    }
}
