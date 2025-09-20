namespace WebApi.DTOs
{
    public class ParticipationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime DateInscription { get; set; }
    }
}