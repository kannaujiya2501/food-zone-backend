using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Zone.Models
{
    public class contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int contactid { get; set; }

        [MaxLength(30)]
        public string name { get; set; }

        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(50)]
        public string message { get; set; }
    }
}
