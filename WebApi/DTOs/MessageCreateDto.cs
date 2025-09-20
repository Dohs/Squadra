using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class MessageCreateDto
    {
        [Required]
        public string Content { get; set; }
    }
}