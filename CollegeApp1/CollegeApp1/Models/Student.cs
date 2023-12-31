﻿using System.ComponentModel.DataAnnotations;

namespace CollegeApp1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required][EmailAddress]
        public string? Email { get; set; }

    }
}
