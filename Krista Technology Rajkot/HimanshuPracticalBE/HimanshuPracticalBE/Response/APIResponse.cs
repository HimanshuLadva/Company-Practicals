namespace HimanshuPracticalBE.Response
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
