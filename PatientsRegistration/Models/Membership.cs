using System.ComponentModel.DataAnnotations;
namespace PatientsRegistration.Models
{
    public class Membership
    {
        [Key]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Membership Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 characters")]
        public string MemberDescrip { get; set; }

        [Required(ErrorMessage = "Insurance Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Insurance Amount must be greater than or equal to 0")]
        public decimal InsureAmt { get; set; }

    }
}
