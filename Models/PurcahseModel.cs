using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace a2Algo.Models
{
    public class PurcahseModel
    {
        public int Id { get; set; }

        [Required]
        public int PurchasingQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchasingPrice { get; set; }    
        public DateTime PurchaseDate { get; set; }  = DateTime.Now; 

        public int ProductId { get; set; }  

        [JsonIgnore]
        public ProductModel Product { get; set; }
    }
}
