using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Product Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Please enter only letters and spaces in product name.")]
        public string? ProductName { get; set; } 

        public string? ProductDescription { get; set; } 
    }
}