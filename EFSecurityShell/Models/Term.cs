using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMUProject.Models
{
    public class Term
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Term")]
        public string TermName { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}