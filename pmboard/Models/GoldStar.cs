using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pmboard.Models
{
    public class GoldStar
    {
        [Key, ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public bool StarActive { get; set; }

        public virtual Projects Projects { get; set; }
    }
}