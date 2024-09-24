using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Models.Entities
{
    [Table("Orders")]
    public class Order
    {

        [Key]
        [Column("OrderId", TypeName = "int")]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User OUser { get; set; }
        
        public virtual List<ItemOrdered> OItemsOrdered { get; set; }

        [Required]
        [Column("OrderPurchaseDate", TypeName = "date")]
        public DateTime OrderPurchaseDate { get; set; }

        [Column("IsOrderActive", TypeName = "bit")]
        public bool IsOrderActive { get; set; }

    }
}
