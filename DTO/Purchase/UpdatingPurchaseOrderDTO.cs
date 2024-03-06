using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Purchase
{
    public class UpdatingPurchaseOrderDTO
    {
        public int Id { get; set; }

        [Required]
        public int PurchasingQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasingPrice { get; set; }

        public int ProductId { get; set; }
    }
}
