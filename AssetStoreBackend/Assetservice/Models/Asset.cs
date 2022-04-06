using AssetService.Models;
using System.ComponentModel.DataAnnotations;

namespace Assetservice.Models
{
    public class Asset
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FileLocation { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
