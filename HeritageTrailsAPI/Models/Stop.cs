using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeritageTrailsAPI.Models
{
    public class Stop
    {
        public int StopId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string FullDesc { get; set; }
        public string Location { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }
        public string Built { get; set; }
        public int Image { get; set; }
        public string VideoURL { get; set; }

        //Foreign Key
        [ForeignKey("Trail")]
        public int TrailId { get; set; }
        //Navigation property
        public Trail Trail { get; set; }
    }
}