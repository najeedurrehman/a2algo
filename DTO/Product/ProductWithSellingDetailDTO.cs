namespace a2Algo.DTO.Product
{
    public record struct ProductWithSellingDetailDTO
    (       
        int Id,
        string ProductName,
        decimal Price,
        DateTime OrderDate,
        int SellingQuantity
    );
}
