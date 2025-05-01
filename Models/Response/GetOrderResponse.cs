using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Response
{
    public record GetOrderResponse
    {
        [JsonProperty("Order")]
        public Order? Order { get; init; }
    }

    public record Order
    {
        [Required]
        [JsonProperty("ID")]
        public required string Id { get; init; }

        [Required]
        [JsonProperty("OrderNumber")]
        public required string OrderNumber { get; init; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; init; }

        [JsonProperty("CloseDate")]
        public DateTime? CloseDate { get; init; }

        [JsonProperty("Total")]
        public decimal Total { get; init; }

        [JsonProperty("TaxTotal")]
        public decimal TaxTotal { get; init; }

        [JsonProperty("SubTotal")]
        public decimal SubTotal { get; init; }

        [JsonProperty("GratuityTotal")]
        public decimal GratuityTotal { get; init; }

        [JsonProperty("Checks")]
        public IReadOnlyList<Check> Checks { get; init; } = [];

        [JsonProperty("Guests")]
        public IReadOnlyList<Guest> Guests { get; init; } = [];

        [JsonProperty("GuestType")]
        public string? GuestType { get; init; }
    }

    public record Check
    {
        [Required]
        [JsonProperty("CheckNumber")]
        public required string CheckNumber { get; init; }

        [JsonProperty("CloseDate")]
        public DateTime? CloseDate { get; init; }

        [JsonProperty("Total")]
        public decimal Total { get; init; }

        [JsonProperty("TaxTotal")]
        public decimal TaxTotal { get; init; }

        [JsonProperty("SubTotal")]
        public decimal SubTotal { get; init; }

        [JsonProperty("GratuityTotalIncludingTax")]
        public decimal GratuityTotalIncludingTax { get; init; }

        [JsonProperty("Items")]
        public IReadOnlyList<OrderItem> Items { get; init; } = [];

        [JsonProperty("Taxes")]
        public IReadOnlyList<Tax> Taxes { get; init; } = [];

        [JsonProperty("Payments")]
        public IReadOnlyList<Payment> Payments { get; init; } = [];

        [JsonProperty("Gratuities")]
        public IReadOnlyList<Gratuity> Gratuities { get; init; } = [];
    }

    public record OrderItem
    {
        [Required]
        [JsonProperty("Description")]
        public required string Description { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("CalculatedAmount")]
        public decimal CalculatedAmount { get; init; }

        [JsonProperty("Modifiers")]
        public IReadOnlyList<Modifier> Modifiers { get; init; } = [];
    }

    public record Modifier
    {
        [Required]
        [JsonProperty("Description")]
        public required string Description { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("CalculatedAmount")]
        public decimal CalculatedAmount { get; init; }
    }

    public record Tax
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("TaxAmount")]
        public decimal TaxAmount { get; init; }
    }

    public record Payment
    {
        [Required]
        [JsonProperty("MethodName")]
        public required string PaymentMethod { get; init; }

        [JsonProperty("PayAmount")]
        public decimal PayAmount { get; init; }
    }

    public record Gratuity
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record Guest
    {
        [Required]
        [JsonProperty("ID")]
        public required string Id { get; init; }

        [JsonProperty("Sequence")]
        public int Sequence { get; init; }

        [JsonProperty("Type")]
        public int Type { get; init; }
    }
}