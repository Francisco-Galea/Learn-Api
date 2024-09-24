using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Models.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductId", TypeName = "int")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category OCategory { get; set; }

        [Required]
        [Column("ProductName", TypeName = "nvarchar(500)")]
        public string ProductName { get; set; }

        [Required]
        [Column("ProductDescription", TypeName = "nvarchar(1000)")]
        public string ProductDescription { get; set; }

        [Required]
        [Column("ProductPrice", TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        
        [Column("IsProductActive", TypeName = "bit")]
        public bool IsProductActive { get; set; }

    }
}
