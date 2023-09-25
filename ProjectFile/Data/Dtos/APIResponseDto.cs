namespace Data.Dtos
{
    public class APIResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
