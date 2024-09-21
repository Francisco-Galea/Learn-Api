using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.Entities
{
    [Table("Users")]
    public class User
    {

        [Key]
        [Column("UserId", TypeName = "int")]
        public int UserId { get; set; }

        [Required]
        [Column("UserName", TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Required]
        [Column("UserPassword", TypeName = "nvarchar(30)")]
        public string UserPassword { get; set; }

        [Required]
        [Column("UserEmail", TypeName = "nvarchar(100)")]
        public string UserEmail { get; set; }

        [Column("IsUserActive", TypeName = "bit")]
        public bool IsUserActive { get; set; }

    }
}
