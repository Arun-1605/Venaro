using System.ComponentModel.DataAnnotations;

namespace Venaro.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Usertype { get; set; }

        public bool Isdeleted { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public User()
        {
            Guid Id = Guid.NewGuid();
        }
    }
}
