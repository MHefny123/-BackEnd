using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class User
    {
         [Key]  
        public int? ID { get; set; }  
        public string FName { get; set; }  
        public string LName { get; set; }  
        public string Username { get; set; }  
        public string Password { get; set; }  
        public string Email { get; set; }  
        public string Phone { get; set; }  
        

    }

}