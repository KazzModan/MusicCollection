using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
   public class Client
    {
        public Client()
        {
            TotalSum = 0;
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public int TotalSum { get; set; }
    }
}
