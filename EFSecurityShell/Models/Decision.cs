using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMUProject.Models
{
    public class Decision
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Decision")]
        public string EnrollmenDecision { get; set; }
        public virtual ICollection<Application> Applications{ get; set; }
    }
}