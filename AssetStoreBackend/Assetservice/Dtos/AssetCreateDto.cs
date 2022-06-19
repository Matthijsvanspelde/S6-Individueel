using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assetservice.Dtos
{
    public class AssetCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public IFormFile CoverImage { get; set; }
    }
}
