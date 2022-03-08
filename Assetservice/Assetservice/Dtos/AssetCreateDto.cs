using System.ComponentModel.DataAnnotations;

namespace Assetservice.Dtos
{
    public class AssetCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
