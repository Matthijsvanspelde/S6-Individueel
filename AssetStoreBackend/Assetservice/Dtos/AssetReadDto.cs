using AssetService.Dtos;
using System;

namespace Assetservice.Dtos
{
    public class AssetReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FileName { get; set; }
        public UserReadDto User { get; set; }
    }
}
