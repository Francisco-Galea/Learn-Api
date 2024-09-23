using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Models.Entities
{
    [Table("ItemsOrdered")]
    public class ItemOrdered
    {
        [Key]
        [Column("ItemOrderedId", TypeName = "int")]
        public int ItemOrderedId { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product OProduct { get; set; }

        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual Order OOrder { get; set; }

        [Required]
        [Column("ProductQuantity", TypeName = "int")]
        public int ProductQuantity { get; set; }

        [Column("IsItemOrderedActive", TypeName = "bit")]
        public bool IsItemOrderedActive { get; set; }

       
    }
}
