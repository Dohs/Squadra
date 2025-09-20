namespace WebApi.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}