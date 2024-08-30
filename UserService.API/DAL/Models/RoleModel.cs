using System.ComponentModel.DataAnnotations;

namespace UserService.API.DAL.Models
{
    public class RoleModel
    {
        /// <summary>
        /// Модель роли для хранения в базе данных.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<UserModel> Users { get; set; }
    }
}
