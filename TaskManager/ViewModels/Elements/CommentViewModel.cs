using AccountingAndAnalytics.TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public class CommentViewModel
    {
        public string UserName { get; set; }
        public string Time { get; set; }
        public string Text { get; set; }

        public void Init(CommentModel comment)
        {
            UserName = comment.UserName;
            Text = comment.Text;
            Time = comment.Time.ToString("HH:mm dd.MM.yy");
        }
    }
}
