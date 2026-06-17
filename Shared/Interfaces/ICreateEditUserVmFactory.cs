using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Interfaces
{
    public interface ICreateEditUserVmFactory
    {
        Task<CreateEditUserViewModel> CreateAsync();
        Task<CreateEditUserViewModel> EditAsync(UserModel user);
    }
}
