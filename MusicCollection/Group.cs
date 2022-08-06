using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollection
{
    public class Group
    {
        public Group()
        {
            Discs = new HashSet<Disc>();
            Singers = new HashSet<Singer>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Contacts { get; set; }
        [Range(0, 60)]
        public int Rating { get; set; }
        public int CountryId { get; set; }
        public int StyleId { get; set; }
        public DateTime FoundationDate { get; set; }
		
        public virtual ICollection<Disc> Discs { get; set; }
        public virtual ICollection<Singer> Singers { get; set; }
        public virtual Country Country { get; set; }
        public virtual Style Style { get; set; }
    }
}
