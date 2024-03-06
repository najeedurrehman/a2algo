using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Sell
{
    public class ForSellOrderDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SellingQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; }

    }
}
