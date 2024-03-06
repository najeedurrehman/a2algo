using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Sell
{
    public class UpdatingSaleOrderDTO
    {
        public int Id { get; set; }
        [Required]
        public int SellingQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; }

        public int ProductId { get; set; }  
    }
}
