using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Models
{
    public class Statuses
    {
        public enum Application
        {
            IN_PROCESS = 1,
            APPROVED = 2,
            REJECTED = 3
        }
        public enum Deal
        {
            IN_WAITING = 4,
            IN_PROGRESS = 5,
            CLOSED = 6,
            TERMINATED = 7
        }
        public enum Task
        {
            IN_WORK = 8,
            COMPLETED = 9
        }

    }
}
