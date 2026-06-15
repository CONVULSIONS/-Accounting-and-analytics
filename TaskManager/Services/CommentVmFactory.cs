using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services
{
    public class CommentVmFactory : ICommentVmFactory
    {
        private readonly IServiceProvider _provider;
        public CommentVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public CommentViewModel Create(CommentModel comment)
        {
            var vm = _provider.GetRequiredService<CommentViewModel>();
            vm.Init(comment);
            return vm;
        }
    }
}
