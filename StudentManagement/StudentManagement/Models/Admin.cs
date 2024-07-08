using System.ComponentModel.DataAnnotations;
namespace StudentManagement.Models

{   
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }

        [Required]
        public string Admin_Username { get; set; }

        [Required]
        public string Admin_Password { get; set; }
    }

}
