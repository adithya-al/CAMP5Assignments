using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessorList.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        //First Name
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string FirstName { get; set; }

        //Last Name
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string LastName { get; set; }

        //salary
        [Required(ErrorMessage = "Salary is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        public decimal Salary { get; set; }

        //DOB
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        //Join Date
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Join Date is required")]
        public DateTime JoinDate { get; set; }

        //Gender
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male/Female/Other")]
        public string Gender { get; set; }

        //HOD name
        [Required(ErrorMessage = "Manager Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s\.]+$", ErrorMessage = "HOD name can only contain letters, spaces, and periods")]
        public string HOD { get; set; }

        //Department ID
        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        //Navigation Property
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}