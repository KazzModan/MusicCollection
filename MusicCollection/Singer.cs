using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{

    public class Singer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public int GroupId { get; set; }
        public virtual Country Country { get; set; }
        public virtual Group Group { get; set; }
    }

}
