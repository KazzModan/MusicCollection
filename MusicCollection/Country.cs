using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
   public class Country
    {
        public Country()
        {
            Publishers = new HashSet<Publisher>();
            Groups = new HashSet<Group>();
            Singers = new HashSet<Singer>();

        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Singer> Singers { get; set; }

    }
}
