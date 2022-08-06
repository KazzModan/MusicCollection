using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
    public class Style
    {
        public Style()
        {
            Songs = new HashSet<Song>();
            Groups = new HashSet<Group>();
            Discs = new HashSet<Disc>();
        }
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Disc> Discs { get; set; }
    }
}
