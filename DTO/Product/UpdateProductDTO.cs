using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Product
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Please enter only letters and spaces in product name.")]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
    }
}
