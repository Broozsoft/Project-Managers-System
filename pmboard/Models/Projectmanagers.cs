using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pmboard.Models
{
    public class Projectmanagers
    {   
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Projects> Projects { get; set; }
        public virtual Schedules Schedule { get; set; }
    }
}