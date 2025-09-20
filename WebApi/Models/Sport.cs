using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Sport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
    }
}