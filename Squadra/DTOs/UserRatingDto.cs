namespace Squadra.DTOs
{
    public class UserRatingDto
    {
        public double AverageRating { get; set; }
        public List<RatingDto> Ratings { get; set; }
    }
}