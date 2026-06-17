using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Interfaces.Factory
{
    public interface ICommentVmFactory
    {
        CommentViewModel Create(CommentModel comment);
    }
}
