using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pmboard.Models
{
    public class Schedules
    {
        [Key, ForeignKey("Projectmanagers")]
        public int ProjectmanagerId { get; set; }
        
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }

        public virtual Projectmanagers Projectmanagers { get; set; }
    }
}