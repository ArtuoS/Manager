namespace Manager.API.Responses
{
    public class ResultViewModel
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}