using System.ComponentModel.DataAnnotations;

namespace UserService.API.DAL.Models
{
    public class UserRegisterModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
