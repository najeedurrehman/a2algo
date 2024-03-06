using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace a2Algo.DTO.Purchase
{
    public record struct GettingPurchaseOrderDTO(
            int Id,
            int PurchasingQuantity,
            decimal PurchasingPrice,
            DateTime PurchaseDate
        );
}
