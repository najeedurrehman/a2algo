namespace a2Algo.DTO.Product
{
    public record struct ProductForUserDTO (
            int Id,
            string ProductName,
            string? ProductDescription,
            int AvilableStock,
            decimal Price
        );
}
