namespace OneClick.Services.Contracts
{
    public class AppResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Object { get; set; }
    }

    public class Response<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
        public T? Data { get; set; }
    }
}
