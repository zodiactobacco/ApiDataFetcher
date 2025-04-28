namespace ApiDataFetcher.Models.Response
{

    public class GetOrderResponse
    {
        public Order? Order { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class Order
    {
        public required string ID { get; set; }
        public double OrderNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool IsFuture { get; set; }
        public double LastBatch { get; set; }
        public List<Check>? Checks { get; set; }
        public List<Guest>? Guests { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double SubTotal { get; set; }
        public double GratuityTotal { get; set; }
        public string? HotelGuest { get; set; }
    }

    public class Check
    {
        public required string ID { get; set; }
        public double CheckNumber { get; set; }
        public double Status { get; set; }
        public DateTime? CloseDate { get; set; }
        public double Total { get; set; }
        public double TaxTotal { get; set; }
        public double SubTotal { get; set; }
        public double GratuityTotalIncludingTax { get; set; }
        public List<Item>? Items { get; set; }
        public List<Taxes>? Taxes { get; set; }
        public List<Payment>? Payments { get; set; }
    }

    public class Item
    {
        public required string ID { get; set; }
        public string? GuestID { get; set; }
        public double Sequence { get; set; }
        public double Course { get; set; }
        public double Qnty { get; set; }
        public double OriginalAmount { get; set; }
        public double TargetAmount { get; set; }
        public double CalculatedAmount { get; set; }
        public DateTime? DateEntered { get; set; }
        public List<Modifier>? Modifiers { get; set; }
        public List<Discount>? Discounts { get; set; }
        public DateTime? DateRefunded { get; set; }
        public DateTime? DateSent { get; set; }
        public double Batch { get; set; }
        public MenuItem? MenuItem { get; set; }
        public Price? Price { get; set; }
        public User? User { get; set; }
        public DateTime? DateVoided { get; set; }
    }

    public class Modifier
    {
        public required string ID { get; set; }
        public string? GuestID { get; set; }
        public double Sequence { get; set; }
        public double Course { get; set; }
        public double Qnty { get; set; }
        public double OriginalAmount { get; set; }
        public double TargetAmount { get; set; }
        public double CalculatedAmount { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateSent { get; set; }
        public double Batch { get; set; }
        public string? MiscData { get; set; }
        public MenuItem? MenuItem { get; set; }
        public Price? Price { get; set; }
    }

    public class Discount
    {
        public required string ID { get; set; }
        public string? OrderItemID { get; set; }
        public double Value { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateAuthorized { get; set; }
        public DiscountReason? DiscountReason { get; set; }
    }

    public class DiscountReason
    {
        public required string ID { get; set; }
        public string? Name { get; set; }
        public bool IsCheckLevel { get; set; }
    }

    public class Client
    {
        public required string ID { get; set; }
        public int ClientType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? Telephone { get; set; }
    }
    public class Guest
    {
        public required string ID { get; set; }
        public string? SeatID { get; set; }
        public Client? Client { get; set; }
        public double Sequence { get; set; }
        public string? Sex { get; set; }
        public int Type { get; set; }
    }

    public class MenuItem
    {
        public required string ID { get; set; }
        public string? Description { get; set; }
    }
    public class Payment
    {
        public required string ID { get; set; }
        public string? ClientID { get; set; }
        public double TipAmount { get; set; }
        public double PayAmount { get; set; }
        public double ForeignPayAmount { get; set; }
        public bool CashBack { get; set; }
        public bool ChangeDue { get; set; }
        public bool Deposit { get; set; }
        public DateTime? DateEntered { get; set; }
        public User? User { get; set; }
    }

    public class Price
    {
        public int PriceType { get; set; }
        public double Amount { get; set; }
        public bool AmountIncludesTax { get; set; }
    }

    public class Taxes
    {
        public required string ID { get; set; }
        public string? Name { get; set; }
        public double Rate { get; set; }
        public double TaxAmount { get; set; }
        public double SubTotal { get; set; }
        public double Qty { get; set; }
    }

    public class User
    {
        public required string ID { get; set; }
        public string? Alias { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
