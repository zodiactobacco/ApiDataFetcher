using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Response
{
    public record DailyTotalsResponse
    {
        [JsonProperty("Sales")]
        public Sales? Sales { get; init; }

        [JsonProperty("Gratuities")]
        public Gratuities? Gratuities { get; init; }

        [JsonProperty("ServiceCharges")]
        public ServiceCharges? ServiceCharges { get; init; }

        [JsonProperty("Taxes")]
        public Taxes? Taxes { get; init; }

        [JsonProperty("Payments")]
        public Payments? Payments { get; init; }

        [JsonProperty("Discounts")]
        public Discounts? Discounts { get; init; }

        [JsonProperty("Statistics")]
        public Statistics? Statistics { get; init; }
    }

    public record Sales
    {
        [JsonProperty("Items")]
        public IReadOnlyList<SalesItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalGrossAmount")]
        public decimal TotalGrossAmount { get; init; }

        [JsonProperty("TotalRefundAmount")]
        public decimal TotalRefundAmount { get; init; }

        [JsonProperty("TotalDiscountAmount")]
        public decimal TotalDiscountAmount { get; init; }

        [JsonProperty("TotalNetAmount")]
        public decimal TotalNetAmount { get; init; }
    }

    public record SalesItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("GrossAmount")]
        public decimal GrossAmount { get; init; }

        [JsonProperty("RefundAmount")]
        public decimal RefundAmount { get; init; }

        [JsonProperty("DiscountAmount")]
        public decimal DiscountAmount { get; init; }

        [JsonProperty("NetAmount")]
        public decimal NetAmount { get; init; }
    }

    public record Gratuities
    {
        [JsonProperty("Items")]
        public IReadOnlyList<GratuityItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; init; }
    }

    public record GratuityItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record ServiceCharges
    {
        [JsonProperty("Items")]
        public IReadOnlyList<ServiceChargeItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; init; }
    }

    public record ServiceChargeItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record Taxes
    {
        [JsonProperty("Items")]
        public IReadOnlyList<TaxItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; init; }
    }

    public record TaxItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record Payments
    {
        [JsonProperty("Items")]
        public IReadOnlyList<PaymentItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; init; }
    }

    public record PaymentItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record Discounts
    {
        [JsonProperty("Items")]
        public IReadOnlyList<DiscountItem> Items { get; init; } = [];

        [JsonProperty("TotalQuantity")]
        public decimal TotalQuantity { get; init; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; init; }
    }

    public record DiscountItem
    {
        [Required]
        [JsonProperty("Name")]
        public required string Name { get; init; }

        [JsonProperty("Quantity")]
        public decimal Quantity { get; init; }

        [JsonProperty("Amount")]
        public decimal Amount { get; init; }
    }

    public record Statistics
    {
        [Required]
        [JsonProperty("PeriodStart")]
        public required DateTime PeriodStart { get; init; }

        [Required]
        [JsonProperty("PeriodEnd")]
        public required DateTime PeriodEnd { get; init; }

        [JsonProperty("TotalHours")]
        public double? TotalHours { get; init; }

        [JsonProperty("CheckCount")]
        public double? CheckCount { get; init; }

        [JsonProperty("GuestCount")]
        public double? GuestCount { get; init; }
    }
}