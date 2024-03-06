using a2Algo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a2Algo.DTO.Purchase
{
    public class PurchaseOrderDTO
    {
        [Required]
        public int PurchasingQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasingPrice { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
