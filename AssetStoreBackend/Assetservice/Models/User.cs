using Assetservice.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Biography { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
