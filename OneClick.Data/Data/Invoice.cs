namespace OneClick.Data.Data
{
    public class Invoice
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public virtual List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Sum { get; set; }
        public string? Description { get; set; }
    }
}
