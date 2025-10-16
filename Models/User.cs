﻿using System.ComponentModel.DataAnnotations;

namespace MVCAssignmentThree.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Role field is required.")]
        public int? RoleId { get; set; }

        public Role? Role { get; set; }
    }
}
