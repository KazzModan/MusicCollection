using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
   public class Disc
    {
        public Disc()
        {
            Songs = new HashSet<Song>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Rating { get; set; }
        [Range(1,100)]
        public int PublisherId { get; set; }
        public int StyleId { get; set; }
        public int GroupId { get; set; }
        public int Price { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Style Style { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

    }
}
