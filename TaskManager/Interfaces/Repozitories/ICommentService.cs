using AccountingAndAnalytics.TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Interfaces.Repozitories
{
    public interface ICommentService
    {
        Task<List<CommentModel>> GetByDealAsync(int dealId);
        Task CreateAsync(int dealId, string text);
    }
}
