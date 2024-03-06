using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace a2Algo.Models
{
    public class SaleModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }  

        [JsonIgnore]
        public ProductModel Product { get; set; }

        [Required]
        public int SellingQuantity {  get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SalePrice { get; set; }  
        public DateTime SellingDate { get; set; } = DateTime.Now;
    }
}
