using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeritageTrailsAPI.Models
{
    public class Trail
    {
        public int TrailId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Time { get; set; }
        public string Length { get; set; }
        public int PictureInt { get; set; }
    }
}