using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTrack.Models
{
    public class Tracker
    {
        [Key]
        public int entryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Time { get; set; }
    }
}
