namespace ProductAPI.Models.DTOs
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; } = true;
        public T Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> ErrorMessages { get; set; }
    }
}
