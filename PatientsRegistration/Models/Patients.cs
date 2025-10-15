using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientsRegistration.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string RegisterNo { get; set; }
        //Name
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string PatientName { get; set; }

        //DOB required, past date only
        [BindProperty, DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        //Gender
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male/female/Other")]
        public string Gender { get; set; }

        //Address
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s,.-]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, periods, and hyphens")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(?!0{10})(?!([0-9])\1{9})[6-9][0-9]{9}$",
            ErrorMessage = "Phone number must start with 6,7,8,9; exactly 10 digits; cannot be all zeros or repeated digits.")]
        public string PhoneNo { get; set; }

        //Membershipid
        [ForeignKey("Membership")]
        [Required(ErrorMessage = "Membership selection is required")]
        public int MemberId { get; set; }
        //Object property
        public virtual Membership? Membership { get; set; }
    }
}

