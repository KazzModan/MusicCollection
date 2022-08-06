using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
    public class Song
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public int StyleId { get; set; }
        public int DiscId { get; set; }
        [Range(0, 100)]
        public int Rating { get; set; }
        public virtual Style Style { get; set; }
        public virtual Disc Disc { get; set; }

    }
}
