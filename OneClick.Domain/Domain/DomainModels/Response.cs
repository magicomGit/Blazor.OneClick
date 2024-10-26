namespace OneClick.Domain.Domain.DomainModels
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
        public T Data { get; set; }
    }
}
