using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pmboard.Models
{
    public class DashboardViewModel
    {
        public List<IGrouping<Categories, Projects>> ProjectList { get; set; }

        public List<Schedules> ScheduleList { get; set; }

        public List<Projects> Archive { get; set; }
    }
}