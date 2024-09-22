using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Models.Entities
{
    [Table("Categories")]
    public class Category
    {

        [Key]
        [Column("CategoryId", TypeName = "int")]
        public int CategoryId { get; set; }

        [Required]
        [Column("CategoryName", TypeName = "nvarchar(100)")]
        public string CategoryName { get; set; }

        [Column("IsCategoryActive", TypeName = "bit")]
        public bool IsCategoryActive { get; set; }

    }
}
