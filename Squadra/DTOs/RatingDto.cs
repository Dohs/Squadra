namespace Squadra.DTOs
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
        public int ParticipantId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}