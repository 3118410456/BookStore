using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
    }
}
