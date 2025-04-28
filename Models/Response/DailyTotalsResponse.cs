namespace ApiDataFetcher.Models.Response
{
    public class DailyTotalsResponse
    {
        public DailyTotalsSales? Sales { get; set; }
        public DailyTotalsTaxes? Taxes { get; set; }
        public DailyTotalsPayments? Payments { get; set; }
        public DailyTotalsDiscounts? Discounts { get; set; }
        public DailyTotalsUsers? Users { get; set; }
        public DailyTotalsStatistics? Statistics { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    // Sales
    public class DailyTotalsSales
    {
        public List<SalesItem>? Items { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalRefundAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
    }

    public class SalesItem
    {
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }

    // Taxes
    public class DailyTotalsTaxes
    {
        public List<TaxesItem>? Items { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class TaxesItem
    {
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    // Payments
    public class DailyTotalsPayments
    {
        public List<PaymentsItem>? Items { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class PaymentsItem
    {
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    // Discounts
    public class DailyTotalsDiscounts
    {
        public List<DiscountsItem>? Items { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class DiscountsItem
    {
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    // Users
    public class DailyTotalsUsers
    {
        public List<UsersItem>? Items { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalRefundAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
    }

    public class UsersItem
    {
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }

    // Statistics
    public class DailyTotalsStatistics
    {
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal TotalHours { get; set; }
        public decimal AvgHourGross { get; set; }
        public decimal AvgHourNet { get; set; }
        public decimal AvgGuestHour { get; set; }
        public int CheckCount { get; set; }
        public decimal AvgCheckGross { get; set; }
        public decimal AvgCheckNet { get; set; }
        public int EntreeCount { get; set; }
        public int GuestCount { get; set; }
        public decimal AvgGuestGross { get; set; }
        public decimal AvgGuestNet { get; set; }
        public decimal AverageStay { get; set; }
    }
}
