using System.ComponentModel.DataAnnotations;

namespace a2Algo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Please enter only letters and spaces in product name.")]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set;}
        public DateTime CreatedDate { get; set; }  = DateTime.Now;   
        public List<PurcahseModel> Purcahse { get; set;} = new List<PurcahseModel>();   
        public List<SaleModel> Sale { get; set; } = new List<SaleModel>();
    }
}
 