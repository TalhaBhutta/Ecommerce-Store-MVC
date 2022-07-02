using System.ComponentModel.DataAnnotations;

namespace NetCuisine.Models
{

    public class SignUpModel
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
