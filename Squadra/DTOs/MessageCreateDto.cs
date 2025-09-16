using System.ComponentModel.DataAnnotations;

namespace Squadra.DTOs
{
    public class MessageCreateDto
    {
        [Required]
        public string Content { get; set; }
    }
}