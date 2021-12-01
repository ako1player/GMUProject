using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMUProject.Models
{
    public class Major
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Major")]
        public string MajorName { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}