using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GMUProject.Models
{
    public class Application
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Must Match ###-##-####")]
        public string SSN { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Home Phone Number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Must Match ###-###-####")]
        public string HomePhone { get; set; }
        [Required]
        [Display(Name = "Cell Phone Number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Must Match ###-###-####")]
        public string CellPhone { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Highschool Name")]
        public string HighschoolName { get; set; }
        [Required]
        [Display(Name = "Highschool City")]
        public string HighschoolCity { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Graduation Date")]
        public DateTime GraduationDate { get; set; }
        [Required]
        [Range(3.00, 4.00, ErrorMessage = "You Do Not Meet The Minimum Qualifications.")]
        public decimal GPA { get; set; }
        [Required]
        [Display(Name = "Math SAT Score")]
        public int MathSat { get; set; }
        [Required]
        [Display(Name = "Verbal SAT Score")]
        public int VerbalSat { get; set; }
        [Required]
        public int? MajorID { get; set; }

        public virtual Major Major { get; set; }
        [Required]
        [Display(Name = "Enrollment Date")]
        public string EnrollmentDate { get; set; }
        [Required]
        public int? TermID { get; set; }
        public virtual Term Term { get; set; }
        [Required]
        public string Year { get; set; }
        public int? DecisionID { get; set; }
        public virtual Decision Decision { get; set; }
    }
}