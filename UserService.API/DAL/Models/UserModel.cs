using System.ComponentModel.DataAnnotations;

namespace UserService.API.DAL.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
