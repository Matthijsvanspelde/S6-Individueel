using Assetservice.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetService.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
