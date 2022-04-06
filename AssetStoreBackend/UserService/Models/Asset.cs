using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class Asset
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string Title { get; set; }

        //Relationships
        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
