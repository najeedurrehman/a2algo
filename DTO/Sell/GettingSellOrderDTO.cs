using System.ComponentModel.DataAnnotations.Schema;

namespace a2Algo.DTO.Sell
{
    public class GettingSaleOrderDTO { 
            public int Id { get; set; }
            public int SellingQuantity { get; set; }
            [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; }
        public DateTime SellingDate { get; set; }
    };
}
