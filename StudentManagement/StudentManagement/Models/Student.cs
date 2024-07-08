using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{   
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }

        [Required]
        public string Student_Name { get; set; }

        [Required, EmailAddress]
        public string Student_Email { get; set; }

        [Required]
        public string Mobile_number { get; set; }

        public string Student_Address { get; set; }

        [Required]
        public DateTime admission_date { get; set; }

        [Required]
        public decimal fees { get; set; }

        [Required]
        public string Status { get; set; }
    }

}
