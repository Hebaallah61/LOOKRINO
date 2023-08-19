using System.ComponentModel;

namespace RINO.Models
{
    public class Device
    {
        public int DeviceId {get;set;}
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Code { get; set; }
        public decimal? Price { get; set; }  
        public string? ImgUrl { get; set; }
        public string? ImgThumbnailUrl { get; set; }
        public bool? Instock { get; set; }
        public int? NumInstock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
