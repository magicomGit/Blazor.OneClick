namespace OneClick.Domain.Domain.Balances
{
    public class OneClickInvoice
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public virtual List<OneClickInvoiceItem> Items { get; set; } = new List<OneClickInvoiceItem>();
    }

    public class OneClickInvoiceItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Sum { get; set; }
        public string? Description { get; set; }
    }
}
